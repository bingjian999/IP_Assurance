using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class FinishEvent : SseEvent
{
	public override string Type => "finish";

	[JsonPropertyName("finishReason")]
	public string FinishReason { get; set; }

	[JsonPropertyName("durationMs")]
	public long? DurationMs { get; set; }

	[JsonPropertyName("inputTokens")]
	public long? InputTokens { get; set; }

	[JsonPropertyName("outputTokens")]
	public long? OutputTokens { get; set; }

	[JsonPropertyName("totalTokens")]
	public long? TotalTokens { get; set; }

	[JsonPropertyName("contextTokens")]
	public long? ContextTokens { get; set; }

	[JsonPropertyName("contextTriggerTokens")]
	public long? ContextTriggerTokens { get; set; }

	[JsonPropertyName("contextTargetTokens")]
	public long? ContextTargetTokens { get; set; }

	[JsonPropertyName("contextHardLimitTokens")]
	public long? ContextHardLimitTokens { get; set; }

	[JsonPropertyName("finishedAt")]
	public string FinishedAt { get; set; }
}
