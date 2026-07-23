using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ApprovalRequestEvent : SseEvent
{
	public override string Type => "approval-request";

	[JsonPropertyName("requestId")]
	public string RequestId { get; set; }

	[JsonPropertyName("threadId")]
	public string ThreadId { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("message")]
	public string Message { get; set; }

	[JsonPropertyName("toolName")]
	public string ToolName { get; set; }

	[JsonPropertyName("argsPreview")]
	public string ArgsPreview { get; set; }

	[JsonPropertyName("riskLevel")]
	public string RiskLevel { get; set; }

	[JsonPropertyName("confirmLabel")]
	public string ConfirmLabel { get; set; }

	[JsonPropertyName("cancelLabel")]
	public string CancelLabel { get; set; }

	[JsonPropertyName("approvalMode")]
	public string ApprovalMode { get; set; }

	[JsonPropertyName("autoApproved")]
	public bool AutoApproved { get; set; }
}
