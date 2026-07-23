using System;

namespace CPAHelper.Agent.Runtime;

internal static class ProviderBudgetDiagnostics
{
	private static readonly bool DebugEnabled = IsEnabled(Environment.GetEnvironmentVariable("CPAHELPER_PROVIDER_BUDGET_DEBUG"));

	internal static void Log(string stage, ProviderRequestBudgetSnapshot snapshot, string extra = null, bool forceConsole = false)
	{
		if (snapshot != null)
		{
			string value = "[CPAHelper.Agent] Provider budget. Stage=" + stage + "; Provider=" + snapshot.Provider + "; " + $"EstimatedTokens={snapshot.ProviderEstimatedTokens}; TriggerTokens={snapshot.TriggerTokens}; " + $"TargetTokens={snapshot.TargetTokens}; HardLimitTokens={snapshot.HardLimitTokens}; " + $"RequestJsonChars={snapshot.RequestJsonChars}; Utf8Bytes={snapshot.RequestUtf8Bytes}; " + $"MessageChars={snapshot.MessageChars}; ToolSchemaChars={snapshot.ToolSchemaChars}; " + $"ToolArgsChars={snapshot.ToolCallArgumentChars}; ToolResultChars={snapshot.ToolResultChars}; " + $"ReasoningChars={snapshot.ReasoningChars}; InstructionsChars={snapshot.InstructionsChars}" + (string.IsNullOrWhiteSpace(extra) ? string.Empty : ("; " + extra));
			if (DebugEnabled || forceConsole)
			{
				Console.WriteLine(value);
			}
		}
	}

	private static bool IsEnabled(string value)
	{
		if (!string.Equals(value, "1", StringComparison.OrdinalIgnoreCase) && !string.Equals(value, "true", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(value, "yes", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}
}
