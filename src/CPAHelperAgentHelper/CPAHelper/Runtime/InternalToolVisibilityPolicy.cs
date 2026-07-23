using System;

namespace CPAHelper.Agent.Runtime;

internal static class InternalToolVisibilityPolicy
{
	internal const string InternalToolSummaryMarker = "[Internal tool summary - do not quote]";

	private static readonly string[] VisibleTextSuppressionMarkers = new string[3] { "[Internal tool summary - do not quote]", "[Tool Calls]", "[Tool result:" };

	internal static bool ShouldHideToolCard(string toolName)
	{
		if (string.IsNullOrWhiteSpace(toolName))
		{
			return false;
		}
		if (toolName.StartsWith("TodoList_", StringComparison.OrdinalIgnoreCase) || toolName.StartsWith("todos_", StringComparison.OrdinalIgnoreCase) || toolName.StartsWith("background_agents_", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (!string.Equals(toolName, "mode_get", StringComparison.OrdinalIgnoreCase) && !string.Equals(toolName, "mode_set", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(toolName, "list_tools", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	internal static bool ShouldSuppressToolResultMirror(string toolName)
	{
		if (!ShouldHideToolCard(toolName))
		{
			return string.Equals(toolName, "request_tools", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	internal static bool IsToolResultMirrorText(string text)
	{
		return (text ?? string.Empty).TrimStart().StartsWith("[Tool result:", StringComparison.OrdinalIgnoreCase);
	}

	internal static int IndexOfVisibleToolTranscriptMarker(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return -1;
		}
		int num = -1;
		string[] visibleTextSuppressionMarkers = VisibleTextSuppressionMarkers;
		foreach (string value in visibleTextSuppressionMarkers)
		{
			int num2 = text.IndexOf(value, StringComparison.OrdinalIgnoreCase);
			if (num2 >= 0 && (num < 0 || num2 < num))
			{
				num = num2;
			}
		}
		return num;
	}

	internal static int GetVisibleToolTranscriptMarkerPrefixLength(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return 0;
		}
		int num = 0;
		string[] visibleTextSuppressionMarkers = VisibleTextSuppressionMarkers;
		foreach (string text2 in visibleTextSuppressionMarkers)
		{
			for (int num2 = Math.Min(text.Length, text2.Length - 1); num2 > num; num2--)
			{
				if (text.EndsWith(text2.Substring(0, num2), StringComparison.OrdinalIgnoreCase))
				{
					num = num2;
					break;
				}
			}
		}
		return num;
	}
}
