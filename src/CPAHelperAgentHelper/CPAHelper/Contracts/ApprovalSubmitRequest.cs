using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ApprovalSubmitRequest
{
	[JsonPropertyName("threadId")]
	public string ThreadId { get; set; }

	[JsonPropertyName("requestId")]
	public string RequestId { get; set; }

	[JsonPropertyName("approved")]
	public bool Approved { get; set; }

	[JsonPropertyName("approvalMode")]
	public string ApprovalMode { get; set; }
}
