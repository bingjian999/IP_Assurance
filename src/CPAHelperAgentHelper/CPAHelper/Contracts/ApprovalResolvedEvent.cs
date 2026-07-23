using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ApprovalResolvedEvent : SseEvent
{
	public override string Type => "approval-resolved";

	[JsonPropertyName("requestId")]
	public string RequestId { get; set; }

	[JsonPropertyName("approved")]
	public bool Approved { get; set; }

	[JsonPropertyName("approvalMode")]
	public string ApprovalMode { get; set; }

	[JsonPropertyName("autoApproved")]
	public bool AutoApproved { get; set; }
}
