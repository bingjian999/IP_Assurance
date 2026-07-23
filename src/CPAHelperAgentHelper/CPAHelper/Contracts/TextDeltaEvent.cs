using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class TextDeltaEvent : SseEvent
{
	public override string Type => "text-delta";

	[JsonPropertyName("textDelta")]
	public string TextDelta { get; set; }
}
