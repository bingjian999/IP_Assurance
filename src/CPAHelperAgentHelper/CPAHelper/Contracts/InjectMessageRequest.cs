using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class InjectMessageRequest : ChatRequest
{
	[JsonPropertyName("injectionId")]
	public string InjectionId { get; set; }
}
