using System;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class ToolResultTurnCompletion
{
	public string AssistantText { get; }

	public TimeSpan CancelDelay { get; }

	public ToolResultTurnCompletion(string assistantText, TimeSpan cancelDelay)
	{
		AssistantText = assistantText;
		CancelDelay = cancelDelay;
	}
}
