using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SubAgentStateEvent : SseEvent
{
	public override string Type => "subagent-state";

	[JsonPropertyName("activityId")]
	public string ActivityId { get; set; }

	[JsonPropertyName("agentName")]
	public string AgentName { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("status")]
	public string Status { get; set; }

	[JsonPropertyName("detail")]
	public string Detail { get; set; }

	[JsonPropertyName("resultPreview")]
	public string ResultPreview { get; set; }

	[JsonPropertyName("reasoningDelta")]
	public string ReasoningDelta { get; set; }

	[JsonPropertyName("activityGroupId")]
	public string ActivityGroupId { get; set; }

	[JsonPropertyName("activityGroupTitle")]
	public string ActivityGroupTitle { get; set; }

	[JsonPropertyName("taskId")]
	public string TaskId { get; set; }

	[JsonPropertyName("taskStatus")]
	public string TaskStatus { get; set; }

	[JsonPropertyName("resultRetrieved")]
	public bool? ResultRetrieved { get; set; }

	[JsonPropertyName("updatedAt")]
	public string UpdatedAt { get; set; }
}
