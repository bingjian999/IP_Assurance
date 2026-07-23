using System;
using System.Collections.Generic;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopTurnPreparationRequest
{
	public AgentSession CurrentAgentSession { get; set; }

	public string CurrentSessionInstructions { get; set; }

	public IReadOnlyList<string> SelectedTools { get; set; } = Array.Empty<string>();
}
