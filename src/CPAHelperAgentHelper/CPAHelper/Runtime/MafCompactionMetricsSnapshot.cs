namespace CPAHelper.Agent.Runtime;

public sealed class MafCompactionMetricsSnapshot
{
	public string Stage { get; set; }

	public int IncludedTokenCount { get; set; }

	public int TotalTokenCount { get; set; }

	public int IncludedMessageCount { get; set; }

	public int TotalMessageCount { get; set; }

	public int IncludedGroupCount { get; set; }

	public int TotalGroupCount { get; set; }

	public int TriggerTokens { get; set; }

	public int TargetTokens { get; set; }

	public int HardLimitTokens { get; set; }

	public bool ExceedsTrigger => IncludedTokenCount > TriggerTokens;

	public bool ExceedsHardLimit => IncludedTokenCount > HardLimitTokens;
}
