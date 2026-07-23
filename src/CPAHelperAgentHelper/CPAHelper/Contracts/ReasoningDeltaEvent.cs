using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ReasoningDeltaEvent : SseEvent
{
	public override string Type => "reasoning-delta";

	[JsonPropertyName("textDelta")]
	public string TextDelta { get; set; }
}
