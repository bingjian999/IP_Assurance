using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ErrorEvent : SseEvent
{
	public override string Type => "error";

	[JsonPropertyName("message")]
	public string Message { get; set; }

	[JsonPropertyName("code")]
	public string Code { get; set; }
}
