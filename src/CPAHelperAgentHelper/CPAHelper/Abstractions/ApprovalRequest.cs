namespace CPAHelper.Agent.Abstractions;

public sealed class ApprovalRequest
{
	public string Title { get; set; }

	public string Message { get; set; }

	public string ToolName { get; set; }

	public string ArgsPreview { get; set; }

	public string RiskLevel { get; set; }

	public string ConfirmLabel { get; set; }

	public string CancelLabel { get; set; }

	public int TimeoutSeconds { get; set; } = 60;
}
