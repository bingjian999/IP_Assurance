using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SessionMessagePayload
{
	[JsonPropertyName("role")]
	public string Role { get; set; }

	[JsonPropertyName("text")]
	public string Text { get; set; }
}
