using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Contracts;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class ActiveSseStream
{
	private readonly string _threadId;

	private readonly TodoProvider _todoProvider;

	private readonly AgentModeProvider _agentModeProvider;

	private string _lastStatusKey;

	private string _lastTodoStateKey;

	private string _lastAgentModeKey;

	private long _activeModelActivityTicks;

	public StreamWriter Writer { get; }

	public object SyncRoot { get; }

	public ActiveSseStream(string threadId, StreamWriter writer, object syncRoot, TodoProvider todoProvider, AgentModeProvider agentModeProvider)
	{
		_threadId = threadId ?? string.Empty;
		Writer = writer ?? throw new ArgumentNullException("writer");
		SyncRoot = syncRoot ?? throw new ArgumentNullException("syncRoot");
		_todoProvider = todoProvider;
		_agentModeProvider = agentModeProvider;
	}

	public Task WriteAsync(SseEvent evt)
	{
		return SseEventWriter.WriteAsync(Writer, evt, SyncRoot);
	}

	public void WriteSync(SseEvent evt)
	{
		SseEventWriter.WriteSync(Writer, SyncRoot, evt);
	}

	public void EmitStatus(string status, string message)
	{
		if (string.IsNullOrWhiteSpace(status))
		{
			return;
		}
		string text = status + "|" + (message ?? string.Empty);
		if (!string.Equals(_lastStatusKey, text, StringComparison.Ordinal))
		{
			_lastStatusKey = text;
			if (!string.Equals(status, "preparing_tool", StringComparison.OrdinalIgnoreCase))
			{
				MarkModelActivity();
			}
			WriteSync(new StatusEvent
			{
				Status = status,
				Message = (message ?? string.Empty)
			});
		}
	}

	public async Task EmitHarnessStateAsync(AgentSession session, bool isRunning)
	{
		if (session != null)
		{
			await EmitAgentModeAsync(session).ConfigureAwait(continueOnCapturedContext: false);
			await EmitTodoStateAsync(session, isRunning).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public void EmitStoppedHarnessState(AgentSession session)
	{
		if (session == null || _todoProvider == null)
		{
			return;
		}
		try
		{
			TodoStateEvent todoStateEvent = CreateStoppedTodoState(_todoProvider.GetAllTodosAsync(session).GetAwaiter().GetResult());
			_lastTodoStateKey = JsonSerializer.Serialize(todoStateEvent);
			WriteSync(todoStateEvent);
		}
		catch (Exception exception)
		{
			AgentRuntimeLogger.Error("Failed to emit stopped todo state. ThreadId=" + _threadId, exception);
		}
	}

	public void MarkModelActivity()
	{
		Interlocked.Exchange(ref _activeModelActivityTicks, DateTime.UtcNow.Ticks);
	}

	public void ResetModelActivity()
	{
		Interlocked.Exchange(ref _activeModelActivityTicks, 0L);
	}

	public Task StartHeartbeatAsync(TimeSpan interval, CancellationToken cancellationToken)
	{
		return Task.Run(async delegate
		{
			try
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					await Task.Delay(interval, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					SseEventWriter.WriteCommentSync(Writer, SyncRoot, "heartbeat");
				}
			}
			catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
			{
			}
		}, CancellationToken.None);
	}

	public Task StartPreparingToolStatusAsync(TimeSpan delay, string message, CancellationToken cancellationToken)
	{
		return Task.Run(async delegate
		{
			try
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					await Task.Delay(delay, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					long num = Interlocked.Read(ref _activeModelActivityTicks);
					if (num > 0 && !(DateTime.UtcNow - new DateTime(num, DateTimeKind.Utc) < delay) && !ShouldKeepCurrentPreparingStatus())
					{
						EmitStatus("preparing_tool", message);
					}
				}
			}
			catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
			{
			}
			catch (Exception exception)
			{
				AgentRuntimeLogger.Error("Failed to emit preparing tool status. ThreadId=" + _threadId, exception);
			}
		}, CancellationToken.None);
	}

	private Task EmitAgentModeAsync(AgentSession session)
	{
		if (_agentModeProvider == null)
		{
			return Task.CompletedTask;
		}
		try
		{
			string text = _agentModeProvider.GetMode(session) ?? string.Empty;
			if (string.Equals(_lastAgentModeKey, text, StringComparison.Ordinal))
			{
				return Task.CompletedTask;
			}
			_lastAgentModeKey = text;
			WriteSync(new AgentModeEvent
			{
				Mode = text
			});
		}
		catch (Exception exception)
		{
			AgentRuntimeLogger.Error("Failed to emit agent mode state. ThreadId=" + _threadId, exception);
		}
		return Task.CompletedTask;
	}

	private async Task EmitTodoStateAsync(AgentSession session, bool isRunning)
	{
		if (_todoProvider == null)
		{
			return;
		}
		try
		{
			TodoStateEvent todoStateEvent = CreateTodoState(await _todoProvider.GetAllTodosAsync(session).ConfigureAwait(continueOnCapturedContext: false), isRunning);
			string text = JsonSerializer.Serialize(todoStateEvent);
			if (!string.Equals(_lastTodoStateKey, text, StringComparison.Ordinal))
			{
				_lastTodoStateKey = text;
				await WriteAsync(todoStateEvent).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		catch (Exception exception)
		{
			AgentRuntimeLogger.Error("Failed to emit todo state. ThreadId=" + _threadId, exception);
		}
	}

	internal static TodoStateEvent CreateStoppedTodoState(IReadOnlyList<TodoItem> todos)
	{
		IReadOnlyList<TodoItem> readOnlyList = todos ?? Array.Empty<TodoItem>();
		int? stoppedTodoId = readOnlyList.FirstOrDefault((TodoItem todo) => !todo.IsComplete)?.Id;
		return new TodoStateEvent
		{
			RunStatus = "stopped",
			ActiveTodoId = null,
			CompletedCount = readOnlyList.Count((TodoItem todo) => todo.IsComplete),
			TotalCount = readOnlyList.Count,
			Items = readOnlyList.Select((TodoItem todo) => new TodoStateItem
			{
				Id = todo.Id,
				Title = (todo.Title ?? string.Empty),
				Description = todo.Description,
				Status = (todo.IsComplete ? "completed" : ((stoppedTodoId == todo.Id) ? "stopped" : "pending"))
			}).ToList()
		};
	}

	internal static TodoStateEvent CreateTodoState(IReadOnlyList<TodoItem> todos, bool isRunning)
	{
		IReadOnlyList<TodoItem> readOnlyList = todos ?? Array.Empty<TodoItem>();
		int? activeTodoId = ((!isRunning) ? ((int?)null) : readOnlyList.FirstOrDefault((TodoItem todo) => !todo.IsComplete)?.Id);
		return new TodoStateEvent
		{
			RunStatus = (isRunning ? "running" : "finished"),
			ActiveTodoId = activeTodoId,
			CompletedCount = readOnlyList.Count((TodoItem todo) => todo.IsComplete),
			TotalCount = readOnlyList.Count,
			Items = readOnlyList.Select((TodoItem todo) => new TodoStateItem
			{
				Id = todo.Id,
				Title = (todo.Title ?? string.Empty),
				Description = todo.Description,
				Status = (todo.IsComplete ? "completed" : ((activeTodoId == todo.Id) ? "in_progress" : "pending"))
			}).ToList()
		};
	}

	private bool ShouldKeepCurrentPreparingStatus()
	{
		string lastStatusKey = _lastStatusKey;
		if (string.IsNullOrWhiteSpace(lastStatusKey))
		{
			return false;
		}
		int num = lastStatusKey.IndexOf('|');
		string a = ((num >= 0) ? lastStatusKey.Substring(0, num) : lastStatusKey);
		if (!string.Equals(a, "queued", StringComparison.OrdinalIgnoreCase) && !string.Equals(a, "analyzing", StringComparison.OrdinalIgnoreCase) && !string.Equals(a, "compacting", StringComparison.OrdinalIgnoreCase) && !string.Equals(a, "preparing_tool", StringComparison.OrdinalIgnoreCase) && !string.Equals(a, "tool", StringComparison.OrdinalIgnoreCase) && !string.Equals(a, "finalizing", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(a, "error", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}
}
