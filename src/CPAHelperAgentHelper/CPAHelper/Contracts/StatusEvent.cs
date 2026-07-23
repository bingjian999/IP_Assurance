using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class StatusEvent : SseEvent
{
	public override string Type => "status";

	[JsonPropertyName("status")]
	public string Status { get; set; }

	[JsonPropertyName("message")]
	public string Message { get; set; }
}
