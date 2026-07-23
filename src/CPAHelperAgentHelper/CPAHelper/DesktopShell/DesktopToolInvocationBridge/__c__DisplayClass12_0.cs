using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CPAHelper.Agent.Adapters;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopToolInvocationBridge
{
	private readonly string _threadId;

	private readonly Func<ActiveSseStream> _getStream;

	private readonly Func<VisibleTurnRecorder> _getRecorder;

	private readonly Action _cancelCurrentTurn;

	private readonly ToolResultTurnCompletionPolicy _toolResultCompletionPolicy = new ToolResultTurnCompletionPolicy();

	private readonly ForcedTurnCompletionState _forcedTurnCompletion = new ForcedTurnCompletionState();

	private int _toolCallCounter;

	public DesktopToolInvocationBridge(string threadId, Func<ActiveSseStream> getStream, Func<VisibleTurnRecorder> getRecorder, Action cancelCurrentTurn)
	{
		_threadId = threadId ?? string.Empty;
		_getStream = getStream ?? throw new ArgumentNullException("getStream");
		_getRecorder = getRecorder ?? throw new ArgumentNullException("getRecorder");
		_cancelCurrentTurn = cancelCurrentTurn ?? throw new ArgumentNullException("cancelCurrentTurn");
	}

	public string BeginToolInvocation(string toolName, IReadOnlyDictionary<string, object> args)
	{
		ActiveSseStream stream = _getStream();
		VisibleTurnRecorder visibleTurnRecorder = _getRecorder();
		Action<string, string> emitStatus = ((stream == null) ? null : ((Action<string, string>)delegate(string status, string message)
		{
			stream.EmitStatus(status, message);
		}));
		string currentActivityId = SubAgentActivityRelay.CurrentActivityId;
		return ToolInvocationEventSink.Begin(_threadId, ref _toolCallCounter, stream?.Writer, stream?.SyncRoot, visibleTurnRecorder?.AssistantParts, visibleTurnRecorder?.PartsSyncRoot, toolName, args, currentActivityId, emitStatus);
	}

	public void CompleteToolInvocation(string invocationId, string toolName, object result, Exception exception)
	{
		ActiveSseStream stream = _getStream();
		VisibleTurnRecorder visibleTurnRecorder = _getRecorder();
		Action<string, string> emitStatus = ((stream == null) ? null : ((Action<string, string>)delegate(string status, string message)
		{
			stream.EmitStatus(status, message);
		}));
		string currentActivityId = SubAgentActivityRelay.CurrentActivityId;
		ToolInvocationEventSink.Complete(_threadId, stream?.Writer, stream?.SyncRoot, visibleTurnRecorder?.AssistantParts, visibleTurnRecorder?.PartsSyncRoot, invocationId, toolName, result, exception, currentActivityId, emitStatus);
		if (string.IsNullOrWhiteSpace(currentActivityId))
		{
			CompleteCurrentTurnFromToolResult(stream, visibleTurnRecorder, toolName, result, exception);
		}
	}

	public bool TryGetForcedTurnCompletion(out string assistantText)
	{
		return _forcedTurnCompletion.TryGet(out assistantText);
	}

	public void ResetForcedTurnCompletion()
	{
		_forcedTurnCompletion.Reset();
	}

	private void CompleteCurrentTurnFromToolResult(ActiveSseStream stream, VisibleTurnRecorder recorder, string toolName, object result, Exception exception)
	{
		if (stream != null && recorder != null && _toolResultCompletionPolicy.TryCreateCompletion(toolName, result, exception, out var completion) && _forcedTurnCompletion.TrySet(completion.AssistantText))
		{
			recorder.AppendText(completion.AssistantText);
			stream.WriteSync(new TextDeltaEvent
			{
				TextDelta = completion.AssistantText
			});
			Task.Run(async delegate
			{
				await Task.Delay(completion.CancelDelay).ConfigureAwait(continueOnCapturedContext: false);
				_cancelCurrentTurn();
			});
		}
	}
}
