using System;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopTurnErrorRequest
{
	public ActiveSseStream Stream { get; set; }

	public AgentSession AgentSession { get; set; }

	public VisibleTurnRecorder Recorder { get; set; }

	public string Instructions { get; set; }

	public string AssistantText { get; set; }

	public bool ShouldPersistTurn { get; set; }

	public Exception Exception { get; set; }

	public string ErrorSummary { get; set; }

	public string UserMessage { get; set; }
}
