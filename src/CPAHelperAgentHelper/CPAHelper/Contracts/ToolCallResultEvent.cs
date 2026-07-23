using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ToolCallResultEvent : SseEvent
{
	public override string Type => "tool-call-result";

	[JsonPropertyName("toolCallId")]
	public string ToolCallId { get; set; }

	[JsonPropertyName("toolName")]
	public string ToolName { get; set; }

	[JsonPropertyName("preview")]
	public string Preview { get; set; }

	[JsonPropertyName("parentActivityId")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string ParentActivityId { get; set; }
}
