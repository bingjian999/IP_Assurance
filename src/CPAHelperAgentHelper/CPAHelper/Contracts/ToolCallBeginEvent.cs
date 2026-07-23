using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ToolCallBeginEvent : SseEvent
{
	public override string Type => "tool-call-begin";

	[JsonPropertyName("toolCallId")]
	public string ToolCallId { get; set; }

	[JsonPropertyName("toolName")]
	public string ToolName { get; set; }

	[JsonPropertyName("args")]
	public IDictionary<string, object> Args { get; set; }

	[JsonPropertyName("parentActivityId")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string ParentActivityId { get; set; }
}
