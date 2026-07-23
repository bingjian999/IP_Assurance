using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class CancelRequest
{
	[JsonPropertyName("threadId")]
	public string ThreadId { get; set; }
}
