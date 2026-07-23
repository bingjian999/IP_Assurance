using System.Collections.Generic;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class PersistedMessagePart
{
	public string Type { get; set; }

	public string Text { get; set; }

	public string ToolCallId { get; set; }

	public string ToolName { get; set; }

	public IDictionary<string, object> Args { get; set; }

	public string ArgsText { get; set; }

	public string Result { get; set; }

	public IDictionary<string, object> Data { get; set; }

	public string RequestId { get; set; }

	public string ThreadId { get; set; }

	public string Title { get; set; }

	public string Message { get; set; }

	public string ArgsPreview { get; set; }

	public string RiskLevel { get; set; }

	public string ConfirmLabel { get; set; }

	public string CancelLabel { get; set; }

	public string ApprovalMode { get; set; }

	public bool AutoApproved { get; set; }

	public string Status { get; set; }

	public string ResolvedAt { get; set; }

	public string ErrorMessage { get; set; }
}
