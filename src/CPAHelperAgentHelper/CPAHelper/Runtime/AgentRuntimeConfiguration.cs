using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using CPAHelper.Agent.Abstractions;

namespace CPAHelper.Agent.Runtime;

internal static class AgentRuntimeConfiguration
{
	internal static string BuildAgentCacheHash(AgentConfig config, string instructions)
	{
		return config.Provider + "|" + config.ApiKey + "|" + config.BaseUrl + "|" + config.Model + "|" + BuildSummaryOptionsHash(config.Summary) + "|" + BuildHarnessOptionsHash(config.Harness) + "|" + NormalizeInstructions(instructions);
	}

	internal static string BuildSessionFingerprint(AgentConfig config, string instructions)
	{
		string s = string.Join("|", (config?.Provider ?? string.Empty).Trim(), (config?.BaseUrl ?? string.Empty).TrimEnd('/'), (config?.Model ?? string.Empty).Trim(), BuildSummaryOptionsHash(config?.Summary), BuildHarnessOptionsHash(config?.Harness), instructions ?? string.Empty);
		using SHA256 sHA = SHA256.Create();
		return Convert.ToBase64String(sHA.ComputeHash(Encoding.UTF8.GetBytes(s)));
	}

	internal static string NormalizeInstructions(string instructions)
	{
		return instructions ?? string.Empty;
	}

	internal static string BuildSummaryOptionsHash(AgentSummaryOptions options)
	{
		if (options == null)
		{
			return string.Empty;
		}
		return string.Join(",", options.ContextWindowTokens?.ToString() ?? string.Empty, options.TriggerRatio?.ToString("R", CultureInfo.InvariantCulture) ?? string.Empty, options.TargetRatio?.ToString("R", CultureInfo.InvariantCulture) ?? string.Empty, options.HardLimitRatio?.ToString("R", CultureInfo.InvariantCulture) ?? string.Empty, options.RecentMessageCount?.ToString() ?? string.Empty, options.TimeoutSeconds?.ToString() ?? string.Empty);
	}

	internal static string BuildHarnessOptionsHash(AgentHarnessOptions options)
	{
		if (options == null)
		{
			return string.Empty;
		}
		return string.Join(",", options.FileAccessEnabled?.ToString() ?? string.Empty, options.FileMemoryEnabled?.ToString() ?? string.Empty, options.SubAgentsEnabled?.ToString() ?? string.Empty, options.FileAccessRoot ?? string.Empty, options.FileMemoryRoot ?? string.Empty);
	}
}
