using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal static class AgentSessionSanitizer
{
	internal static List<ChatMessage> SanitizeMessages(IEnumerable<ChatMessage> messages)
	{
		if (messages == null)
		{
			return new List<ChatMessage>();
		}
		return (from message in messages.Select(SanitizeMessage)
			where message != null
			select message).ToList();
	}

	internal static List<ChatMessage> SanitizeReducedMessagesPreservingLiveToolTail(IReadOnlyList<ChatMessage> originalMessages, IEnumerable<ChatMessage> reducedMessages)
	{
		List<ChatMessage> list = SanitizeMessages(reducedMessages);
		if (list.Count == 0 || !EndsWithInternalToolSummary(list))
		{
			return list;
		}
		IReadOnlyList<ChatMessage> readOnlyList = ExtractLiveToolTail(originalMessages);
		while (list.Count > 0 && IsInternalToolSummaryMessage(list[list.Count - 1]))
		{
			list.RemoveAt(list.Count - 1);
		}
		if (readOnlyList.Count == 0)
		{
			return list;
		}
		List<ChatMessage> list2 = SanitizeMessages(readOnlyList);
		if (list2.Count == 0)
		{
			return list;
		}
		list.AddRange(list2);
		return list;
	}

	internal static void SanitizeInMemoryHistory(InMemoryChatHistoryProvider historyProvider, AgentSession session)
	{
		if (historyProvider == null || session == null)
		{
			return;
		}
		List<ChatMessage> messages = historyProvider.GetMessages(session);
		if (messages != null && messages.Count != 0)
		{
			List<ChatMessage> list = SanitizeMessages(messages);
			if (list.Count != messages.Count || list.Where((ChatMessage message, int index) => message != messages[index]).Any())
			{
				historyProvider.SetMessages(session, list);
			}
		}
	}

	internal static JsonElement SanitizeSerializedSession(JsonElement serializedSession)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using (Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream))
		{
			WriteSanitizedJson(serializedSession, writer);
		}
		using JsonDocument jsonDocument = JsonDocument.Parse(memoryStream.ToArray());
		return jsonDocument.RootElement.Clone();
	}

	private static ChatMessage SanitizeMessage(ChatMessage message)
	{
		if (message == null)
		{
			return null;
		}
		if (message.Role != ChatRole.Assistant || message.Contents == null || message.Contents.Count == 0)
		{
			return message;
		}
		List<AIContent> list = message.Contents.Where((AIContent content) => !(content is FunctionCallContent functionCallContent) || functionCallContent.Arguments != null).ToList();
		if (!HasMeaningfulAssistantContent(message, list))
		{
			return null;
		}
		if (list.Count == message.Contents.Count)
		{
			return message;
		}
		ChatMessage chatMessage = new ChatMessage(message.Role, list)
		{
			AuthorName = message.AuthorName,
			CreatedAt = message.CreatedAt,
			MessageId = message.MessageId,
			RawRepresentation = message.RawRepresentation
		};
		if (message.AdditionalProperties != null)
		{
			chatMessage.AdditionalProperties = message.AdditionalProperties.Clone();
		}
		return chatMessage;
	}

	private static bool EndsWithInternalToolSummary(IReadOnlyList<ChatMessage> messages)
	{
		if (messages != null && messages.Count > 0)
		{
			return IsInternalToolSummaryMessage(messages[messages.Count - 1]);
		}
		return false;
	}

	private static bool IsInternalToolSummaryMessage(ChatMessage message)
	{
		if (message == null || message.Role != ChatRole.Assistant)
		{
			return false;
		}
		if (StartsWithInternalToolSummaryMarker(message.Text))
		{
			return true;
		}
		if (message.Contents == null)
		{
			return false;
		}
		return message.Contents.OfType<TextContent>().Any((TextContent content) => StartsWithInternalToolSummaryMarker(content.Text));
	}

	private static bool StartsWithInternalToolSummaryMarker(string text)
	{
		return (text ?? string.Empty).TrimStart().StartsWith("[Internal tool summary - do not quote]", StringComparison.OrdinalIgnoreCase);
	}

	private static IReadOnlyList<ChatMessage> ExtractLiveToolTail(IReadOnlyList<ChatMessage> messages)
	{
		if (messages == null || messages.Count == 0 || !IsToolResultMessage(messages[messages.Count - 1]))
		{
			return new List<ChatMessage>();
		}
		int num = messages.Count - 1;
		while (num > 0 && IsToolResultMessage(messages[num]))
		{
			num--;
		}
		if (!IsAssistantToolCallMessage(messages[num]))
		{
			return new List<ChatMessage>();
		}
		return messages.Skip(num).ToList();
	}

	private static bool IsAssistantToolCallMessage(ChatMessage message)
	{
		if (message != null && message.Role == ChatRole.Assistant && message.Contents != null)
		{
			return message.Contents.OfType<FunctionCallContent>().Any((FunctionCallContent call) => call.Arguments != null);
		}
		return false;
	}

	private static bool IsToolResultMessage(ChatMessage message)
	{
		if (message != null)
		{
			if (!(message.Role == ChatRole.Tool))
			{
				if (message.Contents != null)
				{
					return message.Contents.OfType<FunctionResultContent>().Any();
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private static bool HasMeaningfulAssistantContent(ChatMessage message, IEnumerable<AIContent> contents)
	{
		if (!string.IsNullOrWhiteSpace(message.Text))
		{
			return true;
		}
		foreach (AIContent content in contents)
		{
			if (content is TextContent textContent && !string.IsNullOrWhiteSpace(textContent.Text))
			{
				return true;
			}
			if (content is TextReasoningContent textReasoningContent && !string.IsNullOrWhiteSpace(textReasoningContent.Text))
			{
				return true;
			}
			if (content is FunctionCallContent { Arguments: not null })
			{
				return true;
			}
			if (!(content is TextContent) && !(content is TextReasoningContent) && !(content is FunctionCallContent) && content != null)
			{
				return true;
			}
		}
		return false;
	}

	private static void WriteSanitizedJson(JsonElement element, Utf8JsonWriter writer)
	{
		switch (element.ValueKind)
		{
		case JsonValueKind.Object:
			writer.WriteStartObject();
			foreach (JsonProperty item in element.EnumerateObject())
			{
				writer.WritePropertyName(item.Name);
				WriteSanitizedJson(item.Value, writer);
			}
			writer.WriteEndObject();
			break;
		case JsonValueKind.Array:
			writer.WriteStartArray();
			foreach (JsonElement item2 in element.EnumerateArray())
			{
				if (!IsEmptyAssistantMessageAfterSanitization(item2) && !IsMalformedFunctionCall(item2))
				{
					WriteSanitizedJson(item2, writer);
				}
			}
			writer.WriteEndArray();
			break;
		default:
			element.WriteTo(writer);
			break;
		}
	}

	private static bool IsMalformedFunctionCall(JsonElement element)
	{
		JsonElement value2;
		if (element.ValueKind == JsonValueKind.Object && TryGetString(element, "$type", out var value) && string.Equals(value, "functionCall", StringComparison.Ordinal))
		{
			return !element.TryGetProperty("arguments", out value2);
		}
		return false;
	}

	private static bool IsEmptyAssistantMessageAfterSanitization(JsonElement element)
	{
		if (element.ValueKind != JsonValueKind.Object || !TryGetString(element, "role", out var value) || !string.Equals(value, "assistant", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (HasNonWhiteSpaceStringProperty(element, "text"))
		{
			return false;
		}
		if (!element.TryGetProperty("contents", out var value2) || value2.ValueKind != JsonValueKind.Array)
		{
			return true;
		}
		foreach (JsonElement item in value2.EnumerateArray())
		{
			if (!IsMalformedFunctionCall(item) && IsMeaningfulSerializedAssistantContent(item))
			{
				return false;
			}
		}
		return true;
	}

	private static bool IsMeaningfulSerializedAssistantContent(JsonElement content)
	{
		if (content.ValueKind != JsonValueKind.Object)
		{
			return false;
		}
		if (!TryGetString(content, "$type", out var value))
		{
			return true;
		}
		if (string.Equals(value, "text", StringComparison.Ordinal) || string.Equals(value, "reasoning", StringComparison.Ordinal))
		{
			return HasNonWhiteSpaceStringProperty(content, "text");
		}
		JsonElement value2;
		if (string.Equals(value, "functionCall", StringComparison.Ordinal))
		{
			return content.TryGetProperty("arguments", out value2);
		}
		return true;
	}

	private static bool HasNonWhiteSpaceStringProperty(JsonElement element, string propertyName)
	{
		if (TryGetString(element, propertyName, out var value))
		{
			return !string.IsNullOrWhiteSpace(value);
		}
		return false;
	}

	private static bool TryGetString(JsonElement element, string propertyName, out string value)
	{
		value = null;
		if (!element.TryGetProperty(propertyName, out var value2) || value2.ValueKind != JsonValueKind.String)
		{
			return false;
		}
		value = value2.GetString();
		return true;
	}
}
