using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI.Compaction;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal static class AgentChatRuntimeOptions
{
	internal sealed class ResolvedSummaryOptions
	{
		public int ContextWindowTokens { get; set; }

		public int TriggerTokens { get; set; }

		public int TargetTokens { get; set; }

		public int HardLimitTokens { get; set; }

		public int RecentMessageCount { get; set; }

		public int TimeoutSeconds { get; set; }
	}

	private const int ToolResultMinimumPreservedGroups = 4;

	private const int HistoryTargetMinimumPreservedGroups = 4;

	private const int HistoryFallbackMinimumPreservedGroups = 2;

	private const string SummarizationPrompt = "你负责为后续 assistant 回合压缩较早的聊天历史。请用中文总结，并保留：用户目标、已完成事项、关键决定、用户偏好、重要工具调用结果、当前未完成任务、下一步应该怎么继续。不要回答用户问题，不要寒暄，不要输出 Markdown 大标题，保持简洁，可直接作为后续上下文。";

	private static readonly AgentSummaryOptions EnvironmentSummaryOptions = new AgentSummaryOptions
	{
		ContextWindowTokens = ReadNullablePositiveIntEnvironment("CPAHELPER_SUMMARY_CONTEXT_WINDOW_TOKENS"),
		TriggerRatio = ReadNullableRatioEnvironment("CPAHELPER_SUMMARY_TRIGGER_RATIO"),
		TargetRatio = ReadNullableRatioEnvironment("CPAHELPER_SUMMARY_TARGET_RATIO"),
		HardLimitRatio = ReadNullableRatioEnvironment("CPAHELPER_SUMMARY_HARD_LIMIT_RATIO"),
		RecentMessageCount = ReadNullablePositiveIntEnvironment("CPAHELPER_SUMMARY_RECENT_MESSAGE_COUNT"),
		TimeoutSeconds = ReadNullablePositiveIntEnvironment("CPAHELPER_SUMMARY_TIMEOUT_SECONDS")
	};

	internal static IChatReducer BuildCompactionMetricsReducer(ResolvedSummaryOptions options)
	{
		return new MafCompactionMetricsStrategy("snapshot", options.TriggerTokens, options.TargetTokens, options.HardLimitTokens).AsChatReducer();
	}

	internal static CompactionStrategy BuildCompactionStrategy(IChatClient chatClient, ResolvedSummaryOptions options)
	{
		return BuildCompactionStrategy(chatClient, options, "before", "after");
	}

	internal static IChatReducer BuildHistoryCompactionReducer(IChatClient chatClient, ResolvedSummaryOptions options)
	{
		return new ObservableChatReducer(BuildStreamingHistoryCompactionReducer(chatClient, options), fallback: BuildHistoryFallbackCompactionReducer(options), timeout: (options.TimeoutSeconds > 0) ? TimeSpan.FromSeconds(options.TimeoutSeconds) : Timeout.InfiniteTimeSpan);
	}

	internal static IChatReducer BuildStreamingHistoryCompactionReducer(IChatClient chatClient, ResolvedSummaryOptions options)
	{
		if (chatClient == null)
		{
			throw new ArgumentNullException("chatClient");
		}
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		CompactionTrigger trigger = CompactionTriggers.TokensExceed(options.TriggerTokens);
		CompactionTrigger target = CompactionTriggers.TokensBelow(options.TargetTokens);
		int recentMessageCount = Math.Max(1, options.RecentMessageCount);
		int minimumPreservedGroups = Math.Max(1, Math.Min(4, options.RecentMessageCount));
		return new PipelineChatReducer(new IChatReducer[5]
		{
			new MafCompactionMetricsStrategy("history-before", options.TriggerTokens, options.TargetTokens, options.HardLimitTokens).AsChatReducer(),
			BuildToolResultCompactionStrategy(trigger, 4, target).AsChatReducer(),
			new TokenThresholdChatReducer(new StreamingSummarizingChatReducer(chatClient, recentMessageCount), options.TriggerTokens, options.TargetTokens, options.HardLimitTokens),
			new TruncationCompactionStrategy(trigger, minimumPreservedGroups, target).AsChatReducer(),
			new MafCompactionMetricsStrategy("history-after", options.TriggerTokens, options.TargetTokens, options.HardLimitTokens).AsChatReducer()
		});
	}

	internal static IChatReducer BuildHistoryFallbackCompactionReducer(ResolvedSummaryOptions options)
	{
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		CompactionTrigger trigger = CompactionTriggers.TokensExceed(options.TriggerTokens);
		CompactionTrigger target = CompactionTriggers.TokensBelow(options.TargetTokens);
		int minimumPreservedGroups = Math.Max(1, Math.Min(2, options.RecentMessageCount));
		return new PipelineCompactionStrategy(new MafCompactionMetricsStrategy("history-fallback-before", options.TriggerTokens, options.TargetTokens, options.HardLimitTokens), BuildToolResultCompactionStrategy(trigger, minimumPreservedGroups, target), new TruncationCompactionStrategy(trigger, minimumPreservedGroups, target), new MafCompactionMetricsStrategy("history-fallback-after", options.TriggerTokens, options.TargetTokens, options.HardLimitTokens)).AsChatReducer();
	}

	internal static IChatReducer BuildProviderBudgetForcedHistoryCompactionReducer(IChatClient chatClient, ResolvedSummaryOptions options)
	{
		if (chatClient == null)
		{
			throw new ArgumentNullException("chatClient");
		}
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		int recentMessageCount = Math.Max(1, Math.Min(4, options.RecentMessageCount));
		return new ObservableChatReducer(new PipelineChatReducer(new IChatReducer[4]
		{
			new MafCompactionMetricsStrategy("history-provider-force-before", options.TriggerTokens, options.TargetTokens, options.HardLimitTokens).AsChatReducer(),
			BuildToolResultCompactionStrategy(CompactionTriggers.HasToolCalls(), 1, null).AsChatReducer(),
			new StreamingSummarizingChatReducer(chatClient, recentMessageCount),
			new MafCompactionMetricsStrategy("history-provider-force-after", options.TriggerTokens, options.TargetTokens, options.HardLimitTokens).AsChatReducer()
		}), (options.TimeoutSeconds > 0) ? TimeSpan.FromSeconds(options.TimeoutSeconds) : Timeout.InfiniteTimeSpan, BuildProviderBudgetFallbackHistoryCompactionReducer(options));
	}

	internal static IChatReducer BuildProviderBudgetFallbackHistoryCompactionReducer(ResolvedSummaryOptions options)
	{
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		int num = Math.Max(1, Math.Min(2, options.RecentMessageCount));
		return new PipelineCompactionStrategy(new MafCompactionMetricsStrategy("history-provider-fallback-before", options.TriggerTokens, options.TargetTokens, options.HardLimitTokens), BuildToolResultCompactionStrategy(CompactionTriggers.HasToolCalls(), 1, null), new TruncationCompactionStrategy(CompactionTriggers.GroupsExceed(num), num), new MafCompactionMetricsStrategy("history-provider-fallback-after", options.TriggerTokens, options.TargetTokens, options.HardLimitTokens)).AsChatReducer();
	}

	private static CompactionStrategy BuildCompactionStrategy(IChatClient chatClient, ResolvedSummaryOptions options, string beforeStage, string afterStage)
	{
		if (chatClient == null)
		{
			throw new ArgumentNullException("chatClient");
		}
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		CompactionTrigger trigger = CompactionTriggers.TokensExceed(options.TriggerTokens);
		CompactionTrigger target = CompactionTriggers.TokensBelow(options.TargetTokens);
		CompactionTrigger trigger2 = CompactionTriggers.TokensExceed(options.HardLimitTokens);
		int minimumPreservedGroups = Math.Max(1, options.RecentMessageCount);
		return new PipelineCompactionStrategy(new MafCompactionMetricsStrategy(beforeStage, options.TriggerTokens, options.TargetTokens, options.HardLimitTokens), BuildToolResultCompactionStrategy(trigger, 4, target), new SummarizationCompactionStrategy(chatClient, trigger, minimumPreservedGroups, "你负责为后续 assistant 回合压缩较早的聊天历史。请用中文总结，并保留：用户目标、已完成事项、关键决定、用户偏好、重要工具调用结果、当前未完成任务、下一步应该怎么继续。不要回答用户问题，不要寒暄，不要输出 Markdown 大标题，保持简洁，可直接作为后续上下文。", target), new TruncationCompactionStrategy(trigger2, minimumPreservedGroups, target), new MafCompactionMetricsStrategy(afterStage, options.TriggerTokens, options.TargetTokens, options.HardLimitTokens));
	}

	private static ToolResultCompactionStrategy BuildToolResultCompactionStrategy(CompactionTrigger trigger, int minimumPreservedGroups, CompactionTrigger target)
	{
		return new ToolResultCompactionStrategy(trigger, minimumPreservedGroups, target)
		{
			ToolCallFormatter = FormatCompactedToolCallGroup
		};
	}

	internal static string FormatCompactedToolCallGroup(CompactionMessageGroup group)
	{
		List<string> list = ExtractToolNames(group).Distinct(StringComparer.OrdinalIgnoreCase).Take(6).ToList();
		int num = CountToolResults(group);
		bool flag = HasToolResultError(group);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("[Internal tool summary - do not quote]");
		stringBuilder.Append("Compacted tool results");
		if (list.Count > 0)
		{
			stringBuilder.Append(" for ").Append(string.Join(", ", list));
		}
		stringBuilder.Append(". Status: ").Append(flag ? "error" : "completed").Append("; result payloads omitted");
		if (num > 0)
		{
			stringBuilder.Append(" (").Append(num).Append((num == 1) ? " result" : " results")
				.Append(")");
		}
		stringBuilder.Append(". Call the relevant tool again with a narrower range if exact content is needed.");
		return TruncateForCompactionSummary(stringBuilder.ToString(), 1200);
	}

	private static IEnumerable<string> ExtractToolNames(CompactionMessageGroup group)
	{
		foreach (AIContent item in EnumerateGroupContents(group))
		{
			if (item is FunctionCallContent functionCallContent && !string.IsNullOrWhiteSpace(functionCallContent.Name))
			{
				yield return SanitizeToolName(functionCallContent.Name);
			}
		}
	}

	private static int CountToolResults(CompactionMessageGroup group)
	{
		return EnumerateGroupContents(group).OfType<FunctionResultContent>().Count();
	}

	private static bool HasToolResultError(CompactionMessageGroup group)
	{
		return EnumerateGroupContents(group).OfType<FunctionResultContent>().Any((FunctionResultContent result) => result.Exception != null);
	}

	private static IEnumerable<AIContent> EnumerateGroupContents(CompactionMessageGroup group)
	{
		if (group?.Messages == null)
		{
			yield break;
		}
		foreach (ChatMessage message in group.Messages)
		{
			if (message?.Contents == null)
			{
				continue;
			}
			foreach (AIContent content in message.Contents)
			{
				if (content != null)
				{
					yield return content;
				}
			}
		}
	}

	private static string SanitizeToolName(string toolName)
	{
		return TruncateForCompactionSummary((toolName ?? string.Empty).Replace('\r', ' ').Replace('\n', ' ').Replace('\t', ' ')
			.Trim(), 80);
	}

	private static string TruncateForCompactionSummary(string text, int maxLength)
	{
		if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
		{
			return text ?? string.Empty;
		}
		return text.Substring(0, Math.Max(0, maxLength - 1)) + "…";
	}

	internal static void ApplyProviderDefaults(ChatOptions options, AgentConfig config)
	{
		if (options != null && string.Equals(config?.Provider, "anthropic", StringComparison.OrdinalIgnoreCase))
		{
			ReasoningOptions reasoningOptions = options.Reasoning ?? new ReasoningOptions();
			if (!reasoningOptions.Effort.HasValue)
			{
				reasoningOptions.Effort = ReasoningEffort.Medium;
			}
			if (!reasoningOptions.Output.HasValue)
			{
				reasoningOptions.Output = ReasoningOutput.Full;
			}
			options.Reasoning = reasoningOptions;
		}
	}

	internal static ResolvedSummaryOptions ResolveSummaryOptions(AgentSummaryOptions hostOptions)
	{
		int num = ResolvePositive(hostOptions?.ContextWindowTokens, EnvironmentSummaryOptions.ContextWindowTokens, 128000);
		double num2 = ResolveRatio(hostOptions?.TriggerRatio, EnvironmentSummaryOptions.TriggerRatio, 0.7);
		double num3 = ResolveRatio(hostOptions?.TargetRatio, EnvironmentSummaryOptions.TargetRatio, 0.45);
		double num4 = ResolveRatio(hostOptions?.HardLimitRatio, EnvironmentSummaryOptions.HardLimitRatio, 0.9);
		if (num3 >= num2)
		{
			num3 = Math.Max(0.1, num2 * 0.65);
		}
		if (num4 <= num2)
		{
			num4 = Math.Min(0.98, Math.Max(num2 + 0.05, 0.9));
		}
		int num5 = Math.Max(1, (int)Math.Round((double)num * num2));
		int targetTokens = Math.Max(1, (int)Math.Round((double)num * num3));
		int hardLimitTokens = Math.Max(num5 + 1, (int)Math.Round((double)num * num4));
		return new ResolvedSummaryOptions
		{
			ContextWindowTokens = num,
			TriggerTokens = num5,
			TargetTokens = targetTokens,
			HardLimitTokens = hardLimitTokens,
			RecentMessageCount = ResolvePositive(hostOptions?.RecentMessageCount, EnvironmentSummaryOptions.RecentMessageCount, 12),
			TimeoutSeconds = ResolveNonNegative(hostOptions?.TimeoutSeconds, EnvironmentSummaryOptions.TimeoutSeconds, 0)
		};
	}

	private static int ResolveNonNegative(int? preferred, int? fallback, int defaultValue)
	{
		if (preferred.HasValue && preferred.Value >= 0)
		{
			return preferred.Value;
		}
		if (fallback.HasValue && fallback.Value >= 0)
		{
			return fallback.Value;
		}
		return defaultValue;
	}

	private static int ResolvePositive(int? preferred, int? fallback, int defaultValue)
	{
		if (preferred.HasValue && preferred.Value > 0)
		{
			return preferred.Value;
		}
		if (fallback.HasValue && fallback.Value > 0)
		{
			return fallback.Value;
		}
		return defaultValue;
	}

	private static int? ReadNullablePositiveIntEnvironment(string name)
	{
		if (!int.TryParse(Environment.GetEnvironmentVariable(name), out var result) || result <= 0)
		{
			return null;
		}
		return result;
	}

	private static double ResolveRatio(double? preferred, double? fallback, double defaultValue)
	{
		if (preferred.HasValue && preferred.Value > 0.0 && preferred.Value < 1.0)
		{
			return preferred.Value;
		}
		if (fallback.HasValue && fallback.Value > 0.0 && fallback.Value < 1.0)
		{
			return fallback.Value;
		}
		return defaultValue;
	}

	private static double? ReadNullableRatioEnvironment(string name)
	{
		if (!double.TryParse(Environment.GetEnvironmentVariable(name), NumberStyles.Float, CultureInfo.InvariantCulture, out var result) || !(result > 0.0) || !(result < 1.0))
		{
			return null;
		}
		return result;
	}
}
