using System;
using CPAHelper.Agent.Runtime;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class VisibleAssistantTextFilter
{
	private static readonly string[] InternalSummaryMarkers = new string[2] { "<analysis>", "[Conversation summary]" };

	private bool _suppressRemainderOfMessage;

	private string _currentMessageKey;

	private string _pendingPrefix = string.Empty;

	public void BeginMessage(string messageKey)
	{
		if (!string.IsNullOrWhiteSpace(messageKey) && !string.Equals(_currentMessageKey, messageKey, StringComparison.Ordinal))
		{
			_currentMessageKey = messageKey;
			ResetMessageState();
		}
	}

	public void CompleteMessage()
	{
		_currentMessageKey = null;
		ResetMessageState();
	}

	public string Filter(string text)
	{
		if (string.IsNullOrEmpty(text) || _suppressRemainderOfMessage)
		{
			return string.Empty;
		}
		string text2 = _pendingPrefix + text;
		_pendingPrefix = string.Empty;
		int num = MinNonNegative(InternalToolVisibilityPolicy.IndexOfVisibleToolTranscriptMarker(text2), IndexOfInternalSummaryMarker(text2));
		if (num >= 0)
		{
			_suppressRemainderOfMessage = true;
			return text2.Substring(0, num);
		}
		int num2 = Math.Max(InternalToolVisibilityPolicy.GetVisibleToolTranscriptMarkerPrefixLength(text2), GetInternalSummaryMarkerPrefixLength(text2));
		if (num2 <= 0)
		{
			return text2;
		}
		_pendingPrefix = text2.Substring(text2.Length - num2);
		return text2.Substring(0, text2.Length - num2);
	}

	public string Flush()
	{
		if (_suppressRemainderOfMessage || string.IsNullOrEmpty(_pendingPrefix))
		{
			return string.Empty;
		}
		string pendingPrefix = _pendingPrefix;
		_pendingPrefix = string.Empty;
		return pendingPrefix;
	}

	private void ResetMessageState()
	{
		_suppressRemainderOfMessage = false;
		_pendingPrefix = string.Empty;
	}

	private static int MinNonNegative(int first, int second)
	{
		if (first < 0)
		{
			return second;
		}
		if (second < 0)
		{
			return first;
		}
		return Math.Min(first, second);
	}

	private static int IndexOfInternalSummaryMarker(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return -1;
		}
		int num = -1;
		string[] internalSummaryMarkers = InternalSummaryMarkers;
		foreach (string value in internalSummaryMarkers)
		{
			int num2 = 0;
			while (num2 < text.Length)
			{
				int num3 = text.IndexOf(value, num2, StringComparison.OrdinalIgnoreCase);
				if (num3 < 0)
				{
					break;
				}
				if (IsLineStart(text, num3))
				{
					if (num < 0 || num3 < num)
					{
						num = num3;
					}
					break;
				}
				num2 = num3 + 1;
			}
		}
		return num;
	}

	private static int GetInternalSummaryMarkerPrefixLength(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return 0;
		}
		int num = 0;
		string[] internalSummaryMarkers = InternalSummaryMarkers;
		foreach (string text2 in internalSummaryMarkers)
		{
			num = Math.Max(num, text2.Length);
		}
		for (int num2 = Math.Min(text.Length, Math.Max(0, num - 1)); num2 > 0; num2--)
		{
			int num3 = text.Length - num2;
			if (IsLineStart(text, num3))
			{
				string value = text.Substring(num3, num2);
				internalSummaryMarkers = InternalSummaryMarkers;
				for (int i = 0; i < internalSummaryMarkers.Length; i++)
				{
					if (internalSummaryMarkers[i].StartsWith(value, StringComparison.OrdinalIgnoreCase))
					{
						return num2;
					}
				}
			}
		}
		return 0;
	}

	private static bool IsLineStart(string text, int index)
	{
		if (index <= 0)
		{
			return true;
		}
		char c = text[index - 1];
		if (c != '\n')
		{
			return c == '\r';
		}
		return true;
	}
}
