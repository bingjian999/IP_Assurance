namespace CPAHelper.Agent.DesktopShell;

internal sealed class CanceledTurnRecoveryInfo
{
	public int PreviousUserLength { get; set; }

	public int AssistantPartialLength { get; set; }

	public int InjectedAssistantPartialLength { get; set; }

	public bool HasToolSummary { get; set; }
}
