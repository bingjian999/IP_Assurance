namespace CPAHelper.Agent.Abstractions;

public class AgentSummaryOptions
{
	public int? ContextWindowTokens { get; set; }

	public double? TriggerRatio { get; set; }

	public double? TargetRatio { get; set; }

	public double? HardLimitRatio { get; set; }

	public int? RecentMessageCount { get; set; }

	public int? TimeoutSeconds { get; set; }
}
