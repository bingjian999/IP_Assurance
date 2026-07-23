using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class HostActionInvokeRequest
{
	[JsonPropertyName("threadId")]
	public string ThreadId { get; set; }
}
