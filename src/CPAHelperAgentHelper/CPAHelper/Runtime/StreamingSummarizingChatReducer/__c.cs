using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Agents.AI.Compaction;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class StreamingSummarizingChatReducer : IChatReducer
{
	private const string SummaryPrefix = "[Conversation summary]";

	private const string DebugStreamEnvironmentName = "CPAHELPER_SUMMARY_DEBUG_STREAM";

	private static readonly bool DebugStreamEnabled = IsEnabled(Environment.GetEnvironmentVariable("CPAHELPER_SUMMARY_DEBUG_STREAM"));

	private readonly IChatClient _chatClient;

	private readonly int _recentMessageCount;

	internal StreamingSummarizingChatReducer(IChatClient chatClient, int recentMessageCount)
	{
		_chatClient = chatClient ?? throw new ArgumentNullException("chatClient");
		_recentMessageCount = Math.Max(1, recentMessageCount);
	}

	public async Task<IEnumerable<ChatMessage>> ReduceAsync(IEnumerable<ChatMessage> messages, CancellationToken cancellationToken)
	{
		IList<ChatMessage> materializedMessages = (messages as IList<ChatMessage>) ?? messages?.ToList() ?? new List<ChatMessage>();
		List<ChatMessage> systemMessages = materializedMessages.Where((ChatMessage message) => message?.Role == ChatRole.System).ToList();
		List<ChatMessage> list = materializedMessages.Where((ChatMessage message) => message?.Role != ChatRole.System).ToList();
		if (list.Count <= _recentMessageCount + 1)
		{
			return materializedMessages;
		}
		int num = FindRecentStart(list);
		if (num <= 0)
		{
			return materializedMessages;
		}
		List<ChatMessage> list2 = list.Take(num).ToList();
		List<ChatMessage> recentMessages = list.Skip(num).ToList();
		Log($"[CPAHelper.Agent] Streaming summary started. Older={list2.Count}; Recent={recentMessages.Count}", forceConsole: true);
		string text = await CreateSummaryAsync(list2, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		if (string.IsNullOrWhiteSpace(text))
		{
			Log("[CPAHelper.Agent] Streaming summary returned empty text; keeping original messages.", forceConsole: true);
			return materializedMessages;
		}
		List<ChatMessage> list3 = new List<ChatMessage>(systemMessages.Count + recentMessages.Count + 1);
		list3.AddRange(systemMessages);
		list3.Add(CreateSummaryMessage(text));
		list3.AddRange(recentMessages);
		if (DebugStreamEnabled)
		{
			Log("[CPAHelper.Agent] Streaming summary final: " + text.Trim());
		}
		Log($"[CPAHelper.Agent] Streaming summary completed. Before={materializedMessages.Count}; After={list3.Count}; SummaryChars={text.Length}", forceConsole: true);
		return list3;
	}

	private int FindRecentStart(IList<ChatMessage> conversationMessages)
	{
		int num = Math.Max(0, conversationMessages.Count - _recentMessageCount);
		int num2 = num;
		while (num2 > 0 && conversationMessages[num2].Role != ChatRole.User)
		{
			num2--;
		}
		if (num2 > 0)
		{
			return num2;
		}
		return FindToolSafeFallbackStart(conversationMessages, num);
	}

	private static int FindToolSafeFallbackStart(IList<ChatMessage> conversationMessages, int preferredStart)
	{
		if (preferredStart <= 0 || preferredStart >= conversationMessages.Count || conversationMessages[preferredStart].Role != ChatRole.Tool)
		{
			return preferredStart;
		}
		int num = preferredStart;
		while (num > 0 && conversationMessages[num].Role == ChatRole.Tool)
		{
			num--;
		}
		if (!(conversationMessages[num].Role == ChatRole.Assistant))
		{
			return preferredStart;
		}
		return num;
	}

	private async Task<string> CreateSummaryAsync(IReadOnlyList<ChatMessage> olderMessages, CancellationToken cancellationToken)
	{
		ChatMessage[] messages = new ChatMessage[2]
		{
			new ChatMessage(ChatRole.System, "你负责为后续 assistant 回合压缩较早的聊天历史。请用中文总结，并保留：用户目标、已完成事项、关键决定、用户偏好、重要工具调用结果、当前未完成任务、下一步应该怎么继续。不要回答用户问题，不要寒暄，不要输出 Markdown 大标题，保持简洁，可直接作为后续上下文。"),
			new ChatMessage(ChatRole.User, "请总结以下较早的对话历史，供后续继续处理时使用：\n\n" + FormatMessagesForSummary(olderMessages))
		};
		StringBuilder builder = new StringBuilder();
		await foreach (ChatResponseUpdate item in _chatClient.GetStreamingResponseAsync(messages, new ChatOptions(), cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
		{
			cancellationToken.ThrowIfCancellationRequested();
			string text = ExtractText(item);
			if (!string.IsNullOrEmpty(text))
			{
				builder.Append(text);
				if (DebugStreamEnabled)
				{
					Log("[CPAHelper.Agent] Streaming summary delta: " + text);
				}
			}
		}
		return builder.ToString();
	}

	private static ChatMessage CreateSummaryMessage(string summaryText)
	{
		return new ChatMessage(ChatRole.Assistant, "[Conversation summary]\n" + summaryText.Trim())
		{
			AdditionalProperties = new AdditionalPropertiesDictionary { [CompactionMessageGroup.SummaryPropertyKey] = true }
		};
	}

	private static string FormatMessagesForSummary(IReadOnlyList<ChatMessage> messages)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (ChatMessage message in messages)
		{
			if (message != null)
			{
				stringBuilder.Append('[').Append(message.Role).Append("] ");
				string text = ExtractText(message);
				stringBuilder.AppendLine(string.IsNullOrWhiteSpace(text) ? FormatStructuredContent(message) : text);
			}
		}
		return stringBuilder.ToString();
	}

	private static string ExtractText(ChatResponseUpdate update)
	{
		if (!string.IsNullOrEmpty(update?.Text))
		{
			return update.Text;
		}
		if (update?.Contents == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (AIContent content in update.Contents)
		{
			if (content is TextContent textContent && !string.IsNullOrEmpty(textContent.Text))
			{
				stringBuilder.Append(textContent.Text);
			}
		}
		return stringBuilder.ToString();
	}

	private static string ExtractText(ChatMessage message)
	{
		if (!string.IsNullOrEmpty(message?.Text))
		{
			return message.Text;
		}
		if (message?.Contents == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (AIContent content in message.Contents)
		{
			if (content is TextContent textContent && !string.IsNullOrEmpty(textContent.Text))
			{
				stringBuilder.Append(textContent.Text);
			}
		}
		return stringBuilder.ToString();
	}

	private static string FormatStructuredContent(ChatMessage message)
	{
		if (message?.Contents == null)
		{
			return string.Empty;
		}
		List<string> list = new List<string>();
		foreach (AIContent content in message.Contents)
		{
			if (content is FunctionCallContent functionCallContent)
			{
				list.Add("tool call: " + functionCallContent.Name);
			}
			else if (content is FunctionResultContent functionResultContent)
			{
				list.Add("tool result: " + Convert.ToString(functionResultContent.Result));
			}
		}
		return string.Join("; ", list);
	}

	private static bool IsEnabled(string value)
	{
		if (!string.Equals(value, "1", StringComparison.OrdinalIgnoreCase) && !string.Equals(value, "true", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(value, "yes", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static void Log(string message, bool forceConsole = false)
	{
		if (forceConsole || DebugStreamEnabled)
		{
			Console.WriteLine(message);
		}
	}
}
