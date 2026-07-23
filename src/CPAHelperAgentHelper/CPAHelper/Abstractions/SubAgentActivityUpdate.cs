namespace CPAHelper.Agent.Abstractions;

public sealed class SubAgentActivityUpdate
{
	public string ActivityId { get; set; }

	public string AgentName { get; set; }

	public string Title { get; set; }

	public string Status { get; set; }

	public string Detail { get; set; }

	public string ResultPreview { get; set; }

	public string ReasoningDelta { get; set; }

	public string ActivityGroupId { get; set; }

	public string ActivityGroupTitle { get; set; }

	public string TaskId { get; set; }

	public string TaskStatus { get; set; }

	public bool? ResultRetrieved { get; set; }

	public string UpdatedAt { get; set; }
}
