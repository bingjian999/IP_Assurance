namespace CPAHelper.Agent.Runtime;

internal sealed class ProviderRequestBudgetSnapshot
{
	public string Provider { get; set; }

	public int ProviderEstimatedTokens { get; set; }

	public int RequestJsonChars { get; set; }

	public int RequestUtf8Bytes { get; set; }

	public int MessageChars { get; set; }

	public int ToolSchemaChars { get; set; }

	public int ToolCallArgumentChars { get; set; }

	public int ToolResultChars { get; set; }

	public int ReasoningChars { get; set; }

	public int InstructionsChars { get; set; }

	public int TriggerTokens { get; set; }

	public int TargetTokens { get; set; }

	public int HardLimitTokens { get; set; }

	public bool ExceedsTrigger => ProviderEstimatedTokens > TriggerTokens;

	public bool ExceedsHardLimit => ProviderEstimatedTokens > HardLimitTokens;
}
