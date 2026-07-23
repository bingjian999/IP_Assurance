using System.Collections.Generic;
using System.Linq;
using CPAHelper.Agent.Runtime;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal static class StreamingUpdateExtractor
{
	public static IEnumerable<StreamingContent> ExtractContents(AgentResponseUpdate update)
	{
		if (update == null)
		{
			yield break;
		}
		bool hasTextInUpdate = !string.IsNullOrEmpty(update.Text);
		if (hasTextInUpdate && !ShouldSuppressText(update.Text))
		{
			yield return new StreamingContent(update.Text, isReasoning: false);
		}
		if (update.Contents == null || update.Contents.Count == 0)
		{
			yield break;
		}
		foreach (AIContent content in update.Contents)
		{
			if (content is TextReasoningContent textReasoningContent && !string.IsNullOrEmpty(textReasoningContent.Text))
			{
				yield return new StreamingContent(textReasoningContent.Text, isReasoning: true);
			}
			else if (!hasTextInUpdate && content is TextContent textContent && !string.IsNullOrEmpty(textContent.Text) && !ShouldSuppressText(textContent.Text))
			{
				yield return new StreamingContent(textContent.Text, isReasoning: false);
			}
		}
	}

	public static UsageDetails AggregateUsageDetails(UsageDetails aggregate, AgentResponseUpdate update)
	{
		if (update?.Contents == null || update.Contents.Count == 0)
		{
			return aggregate;
		}
		foreach (UsageContent item in update.Contents.OfType<UsageContent>())
		{
			if (item?.Details != null)
			{
				if (aggregate == null)
				{
					aggregate = new UsageDetails();
				}
				aggregate.Add(item.Details);
			}
		}
		return aggregate;
	}

	public static UsageDetails ResolveUsageDetails(UsageDetails aggregatedUsage)
	{
		if (!HasUsage(aggregatedUsage))
		{
			return null;
		}
		return aggregatedUsage;
	}

	private static bool HasUsage(UsageDetails usage)
	{
		if (usage != null)
		{
			if (!(usage.InputTokenCount > 0) && !(usage.OutputTokenCount > 0))
			{
				return usage.TotalTokenCount > 0;
			}
			return true;
		}
		return false;
	}

	private static bool ShouldSuppressText(string text)
	{
		if (!InternalToolVisibilityPolicy.IsToolResultMirrorText(text))
		{
			return false;
		}
		return InternalToolVisibilityRelay.TryConsumeHiddenToolResult();
	}
}
