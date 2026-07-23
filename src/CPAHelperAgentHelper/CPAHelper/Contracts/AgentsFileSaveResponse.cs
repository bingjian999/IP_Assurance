using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class AgentsFileSaveResponse : AgentsFileResponse
{
	[JsonPropertyName("success")]
	public bool Success { get; set; }
}
