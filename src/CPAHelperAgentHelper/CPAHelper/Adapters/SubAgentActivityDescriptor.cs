namespace CPAHelper.Agent.Adapters;

internal sealed class SubAgentActivityDescriptor
{
	public string ActivityId { get; }

	public string Title { get; }

	public string ActivityGroupId { get; }

	public string ActivityGroupTitle { get; }

	public SubAgentActivityDescriptor(string activityId, string title, string activityGroupId, string activityGroupTitle)
	{
		ActivityId = activityId;
		Title = title;
		ActivityGroupId = activityGroupId;
		ActivityGroupTitle = activityGroupTitle;
	}
}
