using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class AgentsFileResponse
{
	[JsonPropertyName("path")]
	public string Path { get; set; }

	[JsonPropertyName("content")]
	public string Content { get; set; }
}
