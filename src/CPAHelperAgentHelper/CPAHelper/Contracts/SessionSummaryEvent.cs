using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SessionSummaryEvent : SseEvent
{
	public override string Type => "session-summary";

	[JsonPropertyName("sessionId")]
	public string SessionId { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("isCustomTitle")]
	public bool IsCustomTitle { get; set; }

	[JsonPropertyName("isTitleGenerating")]
	public bool IsTitleGenerating { get; set; }

	[JsonPropertyName("createdAt")]
	public string CreatedAt { get; set; }

	[JsonPropertyName("updatedAt")]
	public string UpdatedAt { get; set; }

	[JsonPropertyName("messageCount")]
	public int MessageCount { get; set; }
}
