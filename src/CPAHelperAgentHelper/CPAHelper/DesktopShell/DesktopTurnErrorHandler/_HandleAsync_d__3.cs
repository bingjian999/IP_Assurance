using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CPAHelper.Agent.Adapters;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopTurnErrorHandler
{
	private readonly string _threadId;

	private readonly Func<string, Task> _persistAgentSessionAsync;

	public DesktopTurnErrorHandler(string threadId, Func<string, Task> persistAgentSessionAsync)
	{
		_threadId = threadId ?? string.Empty;
		_persistAgentSessionAsync = persistAgentSessionAsync ?? throw new ArgumentNullException("persistAgentSessionAsync");
	}

	public async Task HandleAsync(DesktopTurnErrorRequest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		string errorSummary = request.ErrorSummary ?? BuildExceptionSummary(request.Exception);
		SubAgentActivityCoordinator.FlushCurrentAtTurnEnd(cancelled: false);
		if (request.ShouldPersistTurn && request.Recorder != null)
		{
			string assistantMessage = ResolveAssistantErrorText(request.AssistantText, request.Recorder.HasContentParts(), errorSummary);
			request.Recorder.Persist(assistantMessage, "error");
			await _persistAgentSessionAsync(request.Instructions).ConfigureAwait(continueOnCapturedContext: false);
		}
		AgentRuntimeLogger.Error("Session controller failed. ThreadId=" + _threadId + "; UserMessage=" + request.UserMessage + "; ErrorSummary=" + errorSummary, request.Exception);
		try
		{
			request.Stream?.EmitStatus("error", errorSummary);
			if (request.Stream != null)
			{
				await request.Stream.EmitHarnessStateAsync(request.AgentSession, isRunning: false).ConfigureAwait(continueOnCapturedContext: false);
				await request.Stream.WriteAsync(CreateErrorEvent(errorSummary)).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		catch
		{
		}
	}

	internal static ErrorEvent CreateErrorEvent(string errorSummary)
	{
		return new ErrorEvent
		{
			Message = errorSummary,
			Code = "internal_error"
		};
	}

	internal static string ResolveAssistantErrorText(string assistantText, bool hasContentParts, string errorSummary)
	{
		if (!string.IsNullOrWhiteSpace(assistantText))
		{
			return assistantText;
		}
		if (hasContentParts)
		{
			return string.Empty;
		}
		return "上一轮因异常中断：" + errorSummary;
	}

	internal static bool IsUnauthorizedException(Exception ex)
	{
		for (Exception ex2 = ex; ex2 != null; ex2 = ex2.InnerException)
		{
			string text = ex2.Message ?? string.Empty;
			if (text.IndexOf("401", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("unauthorized", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("authentication", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return true;
			}
		}
		return false;
	}

	internal static string BuildExceptionSummary(Exception ex)
	{
		List<string> list = new List<string>();
		for (Exception ex2 = ex; ex2 != null; ex2 = ex2.InnerException)
		{
			string text = ex2.Message?.Trim();
			if (!string.IsNullOrWhiteSpace(text) && !list.Contains(text))
			{
				list.Add(text);
			}
		}
		if (list.Count <= 0)
		{
			return "发生未知异常";
		}
		return string.Join(" | ", list);
	}
}
