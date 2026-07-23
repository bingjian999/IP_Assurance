using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class AgentsFileSaveRequest
{
	[JsonPropertyName("content")]
	public string Content { get; set; }
}
