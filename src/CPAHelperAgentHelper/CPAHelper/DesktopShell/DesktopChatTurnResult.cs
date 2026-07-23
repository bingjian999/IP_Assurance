using CPAHelper.Agent.Runtime;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopChatTurnResult
{
	public string AssistantText { get; }

	public bool StreamedAnyAnswerText { get; }

	public UsageDetails Usage { get; }

	public MafCompactionMetricsSnapshot LatestCompactionMetrics { get; }

	public MafCompactionMetricsSnapshot LatestAfterCompactionMetrics { get; }

	public bool CompactionTriggeredThisTurn { get; }

	private DesktopChatTurnResult(string assistantText, bool streamedAnyAnswerText, UsageDetails usage, MafCompactionMetricsSnapshot latestCompactionMetrics, MafCompactionMetricsSnapshot latestAfterCompactionMetrics, bool compactionTriggeredThisTurn)
	{
		AssistantText = assistantText;
		StreamedAnyAnswerText = streamedAnyAnswerText;
		Usage = usage;
		LatestCompactionMetrics = latestCompactionMetrics;
		LatestAfterCompactionMetrics = latestAfterCompactionMetrics;
		CompactionTriggeredThisTurn = compactionTriggeredThisTurn;
	}

	public MafCompactionMetricsSnapshot PreferAfterCompactionMetrics()
	{
		if (!CompactionTriggeredThisTurn || LatestAfterCompactionMetrics == null)
		{
			return LatestCompactionMetrics;
		}
		return LatestAfterCompactionMetrics;
	}

	public static DesktopChatTurnResult FromContext(DesktopChatTurnContext context)
	{
		return new DesktopChatTurnResult(context.AssistantText, context.StreamedAnyAnswerText, context.ResolveUsage(), context.LatestCompactionMetrics, context.LatestAfterCompactionMetrics, context.CompactionTriggeredThisTurn);
	}
}
