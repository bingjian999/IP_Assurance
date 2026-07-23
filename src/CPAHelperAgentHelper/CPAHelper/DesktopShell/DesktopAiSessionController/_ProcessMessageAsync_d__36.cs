using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Contracts;
using CPAHelper.Agent.Runtime;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

public class DesktopAiSessionController : IDisposable, IArtifactSink, IApprovalService, IToolInvocationSink, ISubAgentActivitySink
{
	private int _disposed;

	private readonly IDesktopAgentRuntime _desktopAgentRuntime;

	private readonly AgentRuntime _agentRuntime;

	private readonly Action<AgentArtifact> _onArtifact;

	private readonly TodoProvider _todoProvider;

	private readonly AgentModeProvider _agentModeProvider;

	private readonly DesktopTitleGenerationCoordinator _titleGenerationCoordinator;

	private readonly DesktopChatTurnRunner _turnRunner = new DesktopChatTurnRunner();

	private readonly DesktopTurnFinalizer _turnFinalizer;

	private readonly DesktopTurnPreparationService _turnPreparation;

	private readonly DesktopTurnErrorHandler _turnErrorHandler;

	private readonly DesktopAgentSessionServices _sessionServices;

	private readonly DesktopToolInvocationBridge _toolInvocationBridge;

	private readonly DesktopSubAgentActivityBridge _subAgentActivityBridge;

	private readonly InterruptedTurnRecoveryPlanner _interruptedTurnRecovery;

	private readonly DesktopAuthenticationRecoveryPolicy _authRecovery;

	private readonly DesktopTurnCancellationManager _turnCancellation = new DesktopTurnCancellationManager();

	private readonly PendingArtifactDispatcher _artifactDispatcher = new PendingArtifactDispatcher();

	private readonly ApprovalCoordinator _approvalCoordinator = new ApprovalCoordinator();

	private readonly ApprovalUiBridge _approvalUiBridge;

	private static readonly TimeSpan SseHeartbeatInterval = TimeSpan.FromSeconds(ReadClampedIntEnvironment("CPAHELPER_SSE_HEARTBEAT_SECONDS", 15, 5, 45));

	private static readonly TimeSpan PreparingToolStatusDelay = TimeSpan.FromSeconds(ReadClampedIntEnvironment("CPAHELPER_PREPARING_TOOL_STATUS_SECONDS", 2, 1, 30));

	private ActiveSseStream _activeStream;

	private VisibleTurnRecorder _activeTurnRecorder;

	private readonly object _injectionSyncRoot = new object();

	private readonly HashSet<string> _pendingInjectionIds = new HashSet<string>(StringComparer.Ordinal);

	private bool _acceptingInjections;

	private AgentSession _agentSession;

	private string _sessionInstructions;

	public string ThreadId { get; }

	public DesktopAiSessionController(string threadId, AgentRuntime agentRuntime, IAgentConfigProvider configProvider, IAgentInstructionBuilder instructionBuilder, IHostContext hostContext, Func<AgentInstructionContext> instructionContextFactory = null, Action<AgentArtifact> onArtifact = null, TodoProvider todoProvider = null, AgentModeProvider agentModeProvider = null)
	{
		ThreadId = threadId;
		AgentRuntime runtime = agentRuntime ?? throw new ArgumentNullException("agentRuntime");
		_agentRuntime = runtime;
		configProvider = configProvider ?? throw new ArgumentNullException("configProvider");
		instructionBuilder = instructionBuilder ?? throw new ArgumentNullException("instructionBuilder");
		hostContext = hostContext ?? throw new ArgumentNullException("hostContext");
		Func<AgentInstructionContext> instructionContextFactory2 = instructionContextFactory ?? ((Func<AgentInstructionContext>)(() => new AgentInstructionContext()));
		_desktopAgentRuntime = new DesktopAgentRuntimeAdapter(runtime);
		_onArtifact = onArtifact;
		_todoProvider = todoProvider;
		_agentModeProvider = agentModeProvider;
		SessionTitleGenerator titleGenerator = new SessionTitleGenerator(configProvider);
		_titleGenerationCoordinator = new DesktopTitleGenerationCoordinator(ThreadId, titleGenerator);
		_sessionServices = new DesktopAgentSessionServices(ThreadId, () => _agentSession, (AgentSession session, string instructions, CancellationToken cancellationToken) => runtime.SaveSessionAsync(session, instructions, ThreadId, cancellationToken), (AgentSession session, string instructions, CancellationToken cancellationToken) => runtime.GetCurrentCompactionMetricsAsync(session, instructions, ThreadId, cancellationToken));
		_turnFinalizer = new DesktopTurnFinalizer(ThreadId, _sessionServices.PersistAgentSessionQuietlyAsync, _sessionServices.RefreshCompactionMetricsQuietlyAsync);
		_turnErrorHandler = new DesktopTurnErrorHandler(ThreadId, _sessionServices.PersistAgentSessionQuietlyAsync);
		_turnPreparation = new DesktopTurnPreparationService(ThreadId, configProvider, instructionBuilder, hostContext, instructionContextFactory2, (string instructions, CancellationToken cancellationToken) => runtime.CreateSessionAsync(instructions, ThreadId, cancellationToken), delegate
		{
			runtime.ResetSessionState(ThreadId);
		}, (AgentSession session, IEnumerable<string> tools) => runtime.EnsureToolsLoaded(session, ThreadId, tools));
		_toolInvocationBridge = new DesktopToolInvocationBridge(ThreadId, () => _activeStream, () => _activeTurnRecorder, _turnCancellation.CancelCurrentTurn);
		_subAgentActivityBridge = new DesktopSubAgentActivityBridge(() => _activeStream);
		_interruptedTurnRecovery = new InterruptedTurnRecoveryPlanner(ThreadId);
		_authRecovery = new DesktopAuthenticationRecoveryPolicy(ThreadId, configProvider);
		_approvalUiBridge = new ApprovalUiBridge(ThreadId, _approvalCoordinator, () => _activeStream, () => _activeTurnRecorder, () => runtime.GetToolMetadata());
	}

	public void Publish(AgentArtifact artifact)
	{
		_artifactDispatcher.Enqueue(artifact);
	}

	public async Task ProcessMessageAsync(string userMessage, Stream outputStream)
	{
		await ProcessMessageAsync(new DesktopMessageRequest(userMessage, outputStream));
	}

	public async Task ProcessMessageAsync(string userMessage, Stream outputStream, string displayUserMessage, string selectedSkill)
	{
		await ProcessMessageAsync(new DesktopMessageRequest(userMessage, outputStream, displayUserMessage, string.IsNullOrWhiteSpace(selectedSkill) ? Array.Empty<string>() : new string[1] { selectedSkill }, Array.Empty<HostContextItem>(), Array.Empty<string>()));
	}

	public async Task ProcessMessageAsync(string userMessage, Stream outputStream, string displayUserMessage, IReadOnlyList<string> selectedSkills)
	{
		await ProcessMessageAsync(new DesktopMessageRequest(userMessage, outputStream, displayUserMessage, selectedSkills, Array.Empty<HostContextItem>(), Array.Empty<string>()));
	}

	public async Task ProcessMessageAsync(string userMessage, Stream outputStream, string displayUserMessage, IReadOnlyList<string> selectedSkills, IReadOnlyList<HostContextItem> hostContextItems)
	{
		await ProcessMessageAsync(new DesktopMessageRequest(userMessage, outputStream, displayUserMessage, selectedSkills, hostContextItems, Array.Empty<string>()));
	}

	public async Task ProcessMessageAsync(string userMessage, Stream outputStream, string displayUserMessage, IReadOnlyList<string> selectedSkills, IReadOnlyList<HostContextItem> hostContextItems, IReadOnlyList<string> selectedTools, string requestedAgentMode = null, bool skipInterruptedRecovery = false)
	{
		await ProcessMessageAsync(new DesktopMessageRequest(userMessage, outputStream, displayUserMessage, selectedSkills, hostContextItems, selectedTools, requestedAgentMode, allowAuthRecovery: true, skipInterruptedRecovery));
	}

	private async Task ProcessMessageAsync(DesktopMessageRequest request)
	{
		DesktopTurnCancellationManager.DesktopTurnCancellationLease turnCancellation = await _turnCancellation.BeginTurnAsync().ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			CancellationToken token = turnCancellation.Token;
			StreamWriter writer = new StreamWriter(request.OutputStream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false))
			{
				AutoFlush = true
			};
			object writerSyncRoot = new object();
			bool retryAfterAuthRecovery;
			do
			{
				string visibleUserMessage = request.VisibleUserMessage;
				Stopwatch stopwatch = new Stopwatch();
				DesktopChatTurnContext turnContext = null;
				DesktopChatTurnResult turnResult = null;
				ActiveSseStream sseStream = new ActiveSseStream(ThreadId, writer, writerSyncRoot, _todoProvider, _agentModeProvider);
				VisibleTurnRecorder turnRecorder = new VisibleTurnRecorder(ThreadId, request.UserMessage, visibleUserMessage, request.SelectedSkills, request.HostContextItems, request.SelectedTools);
				bool shouldPersistTurn = false;
				retryAfterAuthRecovery = false;
				DesktopTurnLifecycleScope turnLifecycle = null;
				_toolInvocationBridge.ResetForcedTurnCompletion();
				try
				{
					turnLifecycle = new DesktopTurnLifecycleScope(this, this, this, this, sseStream, turnRecorder, SetActiveTurn, ClearActiveTurn, _approvalUiBridge.RejectPending, SseHeartbeatInterval);
					sseStream.EmitStatus("queued", "Request received.");
					sseStream.EmitStatus("analyzing", "正在思考");
					DesktopTurnPreparationResult preparation = await _turnPreparation.PrepareAsync(new DesktopTurnPreparationRequest
					{
						CurrentAgentSession = _agentSession,
						CurrentSessionInstructions = _sessionInstructions,
						SelectedTools = request.SelectedTools
					}, token).ConfigureAwait(continueOnCapturedContext: false);
					if (!preparation.IsReady)
					{
						await sseStream.WriteAsync(preparation.ToErrorEvent()).ConfigureAwait(continueOnCapturedContext: false);
						break;
					}
					string instructions = preparation.Instructions;
					_agentSession = preparation.AgentSession;
					_sessionInstructions = preparation.SessionInstructions;
					AgentRuntimeLogger.Info($"Session controller started. ThreadId={ThreadId}; InstructionLength={instructions?.Length ?? 0}; UserMessage={request.UserMessage}");
					AgentRuntimeLogger.Info("Helper runtime loaded. ThreadId=" + ThreadId + "; AssemblyPath=" + typeof(DesktopAiSessionController).Assembly.Location + "; ToolObservation=enabled");
					if (preparation.ResetForEmptyConversation)
					{
						AgentRuntimeLogger.Info("Agent session runtime state reset for empty conversation. ThreadId=" + ThreadId);
					}
					if (preparation.RefreshedSession)
					{
						AgentRuntimeLogger.Info("Agent session created or refreshed. ThreadId=" + ThreadId);
					}
					if (preparation.LoadedTools.Count > 0)
					{
						AgentRuntimeLogger.Info("Selected tools preloaded. ThreadId=" + ThreadId + "; Tools=" + string.Join(",", preparation.LoadedTools));
					}
					ApplyRequestedAgentMode(_agentSession, request.RequestedAgentMode);
					await sseStream.EmitHarnessStateAsync(_agentSession, isRunning: true).ConfigureAwait(continueOnCapturedContext: false);
					shouldPersistTurn = true;
					Task titleGenerationTask = _titleGenerationCoordinator.StartIfNeeded(preparation.SessionSummary, visibleUserMessage, sseStream);
					_artifactDispatcher.Clear();
					stopwatch.Restart();
					string modelUserMessage = (request.SkipInterruptedRecovery ? request.UserMessage : _interruptedTurnRecovery.BuildModelUserMessage(request.UserMessage));
					turnLifecycle.StartPreparingToolStatus(PreparingToolStatusDelay, "正在思考...", token);
					turnContext = new DesktopChatTurnContext(ThreadId, _desktopAgentRuntime, _approvalUiBridge, sseStream, turnRecorder, _agentSession, instructions, modelUserMessage, token);
					SetInjectionWindow(accepting: true);
					try
					{
						turnResult = await _turnRunner.RunAsync(turnContext, CloseInjectionWindowOrContinuePendingMessages).ConfigureAwait(continueOnCapturedContext: false);
					}
					finally
					{
						SetInjectionWindow(accepting: false);
					}
					UpdateUserInterruptStatuses("processed");
					sseStream.MarkModelActivity();
					await turnLifecycle.StopPreparingToolStatusAsync().ConfigureAwait(continueOnCapturedContext: false);
					string aiResponse = turnResult?.AssistantText ?? turnContext?.AssistantText ?? string.Empty;
					await _artifactDispatcher.DispatchAsync(_onArtifact, sseStream).ConfigureAwait(continueOnCapturedContext: false);
					DesktopChatTurnResult desktopChatTurnResult = turnResult;
					if ((desktopChatTurnResult == null || !desktopChatTurnResult.StreamedAnyAnswerText) && !string.IsNullOrWhiteSpace(aiResponse))
					{
						turnRecorder.AppendText(aiResponse);
						await sseStream.WriteAsync(new TextDeltaEvent
						{
							TextDelta = aiResponse
						});
					}
					stopwatch.Stop();
					AgentRuntimeLogger.Info($"Session controller completed successfully. ThreadId={ThreadId}; DurationMs={stopwatch.ElapsedMilliseconds}");
					UsageDetails usage = turnResult?.Usage ?? turnContext?.ResolveUsage();
					MafCompactionMetricsSnapshot compactionMetrics = turnResult?.PreferAfterCompactionMetrics() ?? turnContext?.PreferAfterCompactionMetrics();
					await _turnFinalizer.FinalizeAsync(new DesktopTurnFinalizationRequest
					{
						Stream = sseStream,
						AgentSession = _agentSession,
						Recorder = turnRecorder,
						Instructions = instructions,
						AssistantText = aiResponse,
						FinishReason = "stop",
						StatusMessage = "Finalizing response.",
						ShouldPersistTurn = true,
						DurationMs = stopwatch.ElapsedMilliseconds,
						Usage = usage,
						CompactionMetrics = compactionMetrics,
						HasAfterCompactionMetrics = (turnResult?.LatestAfterCompactionMetrics != null),
						CancellationToken = token
					}).ConfigureAwait(continueOnCapturedContext: false);
					_titleGenerationCoordinator.ObserveQuietly(titleGenerationTask);
				}
				catch (Exception ex) when (ex is OperationCanceledException || token.IsCancellationRequested)
				{
					SetInjectionWindow(accepting: false);
					UpdateUserInterruptStatuses("waiting-next-run");
					string assistantText;
					bool flag = _toolInvocationBridge.TryGetForcedTurnCompletion(out assistantText);
					stopwatch.Stop();
					AgentRuntimeLogger.Info(flag ? $"Session controller completed from tool result. ThreadId={ThreadId}; DurationMs={stopwatch.ElapsedMilliseconds}" : $"Session controller canceled. ThreadId={ThreadId}; DurationMs={stopwatch.ElapsedMilliseconds}");
					UsageDetails usage2 = turnContext?.ResolveUsage();
					MafCompactionMetricsSnapshot compactionMetrics2 = turnContext?.PreferAfterCompactionMetrics();
					string finishReason = (flag ? "stop" : "cancel");
					await _turnFinalizer.FinalizeAsync(new DesktopTurnFinalizationRequest
					{
						Stream = sseStream,
						AgentSession = _agentSession,
						Recorder = turnRecorder,
						Instructions = _sessionInstructions,
						AssistantText = (flag ? assistantText : (turnContext?.AssistantText ?? string.Empty)),
						FinishReason = finishReason,
						StatusMessage = (flag ? "Finalizing response." : "Cancelling current run."),
						ShouldPersistTurn = shouldPersistTurn,
						DurationMs = stopwatch.ElapsedMilliseconds,
						Usage = usage2,
						CompactionMetrics = compactionMetrics2,
						HasAfterCompactionMetrics = (turnContext?.LatestAfterCompactionMetrics != null),
						CancellationToken = CancellationToken.None
					}).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception ex2)
				{
					SetInjectionWindow(accepting: false);
					UpdateUserInterruptStatuses("waiting-next-run");
					string errorSummary = DesktopTurnErrorHandler.BuildExceptionSummary(ex2);
					if (!request.AllowAuthRecovery || (turnContext?.FullResponse.Length ?? 0) != 0 || !_authRecovery.TryRecover(ex2))
					{
						await _turnErrorHandler.HandleAsync(new DesktopTurnErrorRequest
						{
							Stream = sseStream,
							AgentSession = _agentSession,
							Recorder = turnRecorder,
							Instructions = _sessionInstructions,
							AssistantText = (turnContext?.AssistantText ?? string.Empty),
							ShouldPersistTurn = shouldPersistTurn,
							Exception = ex2,
							ErrorSummary = errorSummary,
							UserMessage = request.UserMessage
						}).ConfigureAwait(continueOnCapturedContext: false);
					}
					else
					{
						_agentSession = null;
						_sessionInstructions = null;
						request = request.WithoutAuthRecovery();
						retryAfterAuthRecovery = true;
					}
				}
				finally
				{
					if (turnLifecycle != null)
					{
						await turnLifecycle.DisposeAsync().ConfigureAwait(continueOnCapturedContext: false);
					}
					_toolInvocationBridge.ResetForcedTurnCompletion();
				}
			}
			while (retryAfterAuthRecovery);
		}
		finally
		{
			turnCancellation.Dispose();
		}
	}

	private void SetActiveTurn(ActiveSseStream stream, VisibleTurnRecorder recorder)
	{
		lock (_injectionSyncRoot)
		{
			_activeStream = stream;
			_activeTurnRecorder = recorder;
			_acceptingInjections = false;
		}
	}

	private void ClearActiveTurn()
	{
		lock (_injectionSyncRoot)
		{
			_acceptingInjections = false;
			_activeStream = null;
			_activeTurnRecorder = null;
		}
	}

	public DesktopMessageInjectionResult TryInjectMessage(InjectMessageRequest request)
	{
		if (request == null || string.IsNullOrWhiteSpace(request.InjectionId) || string.IsNullOrWhiteSpace(request.Message))
		{
			return DesktopMessageInjectionResult.Rejected("invalid_request", "注入消息不能为空。");
		}
		lock (_injectionSyncRoot)
		{
			if (!_acceptingInjections || _activeStream == null || _activeTurnRecorder == null || _agentSession == null)
			{
				return DesktopMessageInjectionResult.Rejected("not_running", "当前会话没有可注入的活动任务。");
			}
			try
			{
				MessageInjectingChatClient service = _agentRuntime.GetOrCreateAgent(_sessionInstructions, ThreadId).GetService<MessageInjectingChatClient>();
				if (service == null)
				{
					return DesktopMessageInjectionResult.Rejected("not_supported", "当前 Agent 不支持运行中消息注入。");
				}
				_agentRuntime.EnsureToolsLoaded(_agentSession, ThreadId, request.SelectedTools ?? new List<string>());
				ApplyRequestedAgentMode(_agentSession, request.AgentMode);
				if (_pendingInjectionIds.Contains(request.InjectionId))
				{
					return DesktopMessageInjectionResult.Rejected("already_accepted", "该追加指令已经被 Agent 接受。");
				}
				ChatMessage chatMessage = new ChatMessage(ChatRole.User, request.Message)
				{
					MessageId = request.InjectionId
				};
				service.EnqueueMessages(_agentSession, new ChatMessage[1] { chatMessage });
				UserInterruptEvent userInterruptEvent = new UserInterruptEvent
				{
					InjectionId = request.InjectionId,
					DisplayMessage = (string.IsNullOrWhiteSpace(request.DisplayMessage) ? request.Message : request.DisplayMessage),
					SelectedSkills = (request.SelectedSkills ?? new List<string>()).ToList(),
					SelectedTools = (request.SelectedTools ?? new List<string>()).ToList(),
					HostContextItems = (request.HostContextItems ?? new List<HostContextItem>()).ToList(),
					Status = "accepted"
				};
				_pendingInjectionIds.Add(request.InjectionId);
				_activeTurnRecorder.AppendUserInterrupt(userInterruptEvent);
				_activeStream.WriteSync(userInterruptEvent);
				return DesktopMessageInjectionResult.Accepted(request.InjectionId);
			}
			catch (Exception ex)
			{
				AgentRuntimeLogger.Error("Failed to inject message. ThreadId=" + ThreadId + "; InjectionId=" + request.InjectionId, ex);
				return DesktopMessageInjectionResult.Rejected("inject_failed", ex.Message);
			}
		}
	}

	private void SetInjectionWindow(bool accepting)
	{
		lock (_injectionSyncRoot)
		{
			_acceptingInjections = accepting;
		}
	}

	private bool CloseInjectionWindowOrContinuePendingMessages()
	{
		lock (_injectionSyncRoot)
		{
			if (!_acceptingInjections || _agentSession == null)
			{
				return false;
			}
			MessageInjectingChatClient? service = _agentRuntime.GetOrCreateAgent(_sessionInstructions, ThreadId).GetService<MessageInjectingChatClient>();
			int num;
			if (service == null)
			{
				num = 0;
			}
			else
			{
				num = ((service.GetPendingMessages(_agentSession).Count > 0) ? 1 : 0);
				if (num != 0)
				{
					goto IL_0066;
				}
			}
			_acceptingInjections = false;
			goto IL_0066;
			IL_0066:
			return (byte)num != 0;
		}
	}

	private void UpdateUserInterruptStatuses(string status)
	{
		lock (_injectionSyncRoot)
		{
			foreach (string item in _pendingInjectionIds.ToList())
			{
				_activeTurnRecorder?.UpdateUserInterruptStatus(item, status);
				ConversationPersistenceService.UpdatePersistedUserInterruptStatus(ThreadId, item, status);
				_activeStream?.WriteSync(new UserInterruptEvent
				{
					InjectionId = item,
					Status = status
				});
			}
			if (string.Equals(status, "processed", StringComparison.Ordinal))
			{
				_pendingInjectionIds.Clear();
			}
		}
	}

	public string BeginToolInvocation(string toolName, IReadOnlyDictionary<string, object> args)
	{
		return _toolInvocationBridge.BeginToolInvocation(toolName, args);
	}

	public void CompleteToolInvocation(string invocationId, string toolName, object result, Exception exception)
	{
		_toolInvocationBridge.CompleteToolInvocation(invocationId, toolName, result, exception);
	}

	public void PublishSubAgentActivity(SubAgentActivityUpdate update)
	{
		ConversationPersistenceService.UpsertSubAgentActivity(_activeTurnRecorder?.AssistantParts, _activeTurnRecorder?.PartsSyncRoot, update);
		_subAgentActivityBridge.Publish(update);
	}

	public async Task<bool> RequestApprovalAsync(ApprovalRequest request, CancellationToken cancellationToken = default(CancellationToken))
	{
		return await _approvalUiBridge.RequestApprovalAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	public bool ResolveApproval(string requestId, bool approved, string approvalMode = null)
	{
		return _approvalUiBridge.Resolve(requestId, approved, approvalMode);
	}

	private void ApplyRequestedAgentMode(AgentSession session, string requestedAgentMode)
	{
		string text = NormalizeRequestedAgentMode(requestedAgentMode);
		if (session == null || _agentModeProvider == null || text == null)
		{
			return;
		}
		try
		{
			_agentModeProvider.SetMode(session, text);
			AgentRuntimeLogger.Info("Agent mode set from request. ThreadId=" + ThreadId + "; Mode=" + text);
		}
		catch (ArgumentException exception)
		{
			AgentRuntimeLogger.Error("Ignoring unsupported agent mode request. ThreadId=" + ThreadId + "; Mode=" + requestedAgentMode, exception);
		}
	}

	internal static string NormalizeRequestedAgentMode(string requestedAgentMode)
	{
		string a = (requestedAgentMode ?? string.Empty).Trim().ToLowerInvariant();
		if (string.Equals(a, "plan", StringComparison.Ordinal))
		{
			return "plan";
		}
		if (string.Equals(a, "execute", StringComparison.Ordinal))
		{
			return "execute";
		}
		return null;
	}

	public void Cancel()
	{
		_approvalUiBridge.RejectPending();
		TryEmitStoppedHarnessStateSync();
		_turnCancellation.CancelCurrentTurn();
	}

	private void TryEmitStoppedHarnessStateSync()
	{
		_activeStream?.EmitStoppedHarnessState(_agentSession);
	}

	private static int ReadClampedIntEnvironment(string name, int fallback, int min, int max)
	{
		if (!int.TryParse(Environment.GetEnvironmentVariable(name), out var result))
		{
			return fallback;
		}
		if (result < min)
		{
			return min;
		}
		if (result <= max)
		{
			return result;
		}
		return max;
	}

	public void Dispose()
	{
		if (Interlocked.Exchange(ref _disposed, 1) == 0)
		{
			_approvalUiBridge.RejectPending();
			_turnCancellation.Dispose();
		}
	}
}
