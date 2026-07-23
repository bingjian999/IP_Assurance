namespace CPAHelper.Agent.DesktopShell;

internal sealed class InterruptedTurnRecoveryPlanner
{
	private readonly string _threadId;

	public InterruptedTurnRecoveryPlanner(string threadId)
	{
		_threadId = threadId ?? string.Empty;
	}

	public string BuildModelUserMessage(string userMessage)
	{
		if (VisibleTurnRecorder.TryBuildInterruptedTurnRecoveryUserMessage(_threadId, userMessage, out var modelUserMessage, out var recoveryInfo))
		{
			AgentRuntimeLogger.Info($"Cancel recovery context injected. ThreadId={_threadId}; PreviousUserLength={recoveryInfo.PreviousUserLength}; AssistantPartialLength={recoveryInfo.AssistantPartialLength}; InjectedAssistantPartialLength={recoveryInfo.InjectedAssistantPartialLength}; HasToolSummary={recoveryInfo.HasToolSummary}");
			return modelUserMessage;
		}
		return userMessage;
	}
}
