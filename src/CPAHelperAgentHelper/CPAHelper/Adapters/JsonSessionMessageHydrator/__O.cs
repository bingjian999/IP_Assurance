using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Adapters;

internal static class JsonSessionMessageHydrator
{
	internal static List<ChatMessage> LoadMessages(string sessionId)
	{
		JsonSessionIndexManager.SessionDetailDto sessionDetail = JsonSessionIndexManager.GetSessionDetail(sessionId);
		if (sessionDetail == null)
		{
			return new List<ChatMessage>();
		}
		if (HasCurrentRuntimeMessages(sessionDetail))
		{
			return (from message in sessionDetail.RuntimeMessages.Select(DeserializeRuntimeMessage)
				where message != null
				select message).ToList();
		}
		return (from message in (sessionDetail.Messages ?? new List<JsonSessionIndexManager.SessionMessageDto>()).SelectMany(DeserializeDisplayMessage)
			where message != null
			select message).ToList();
	}

	private static bool HasCurrentRuntimeMessages(JsonSessionIndexManager.SessionDetailDto detail)
	{
		if (detail?.RuntimeMessages == null || detail.RuntimeMessages.Count == 0)
		{
			return false;
		}
		if (!detail.ConversationRevision.HasValue && !detail.RuntimeMessagesRevision.HasValue && !detail.AgentSessionRevision.HasValue)
		{
			return true;
		}
		if (detail.ConversationRevision.HasValue && detail.RuntimeMessagesRevision.HasValue)
		{
			return detail.ConversationRevision.Value == detail.RuntimeMessagesRevision.Value;
		}
		return false;
	}

	private static ChatMessage DeserializeRuntimeMessage(JsonSessionIndexManager.RuntimeMessageDto dto)
	{
		if (dto == null || string.IsNullOrWhiteSpace(dto.Role))
		{
			return null;
		}
		try
		{
			List<AIContent> list = new List<AIContent>();
			if (!string.IsNullOrWhiteSpace(dto.ReasoningContent))
			{
				list.Add(new TextReasoningContent(dto.ReasoningContent));
			}
			if (!string.IsNullOrWhiteSpace(dto.Text))
			{
				list.Add(new TextContent(dto.Text));
			}
			if (dto.ToolCalls != null)
			{
				foreach (JsonSessionIndexManager.RuntimeToolCallDto toolCall in dto.ToolCalls)
				{
					if (toolCall != null && !string.IsNullOrWhiteSpace(toolCall.Name))
					{
						FunctionCallContent functionCallContent = new FunctionCallContent(string.IsNullOrWhiteSpace(toolCall.Id) ? Guid.NewGuid().ToString("N") : toolCall.Id, toolCall.Name, DeserializeArguments(toolCall.ArgumentsJson));
						if (!string.IsNullOrWhiteSpace(dto.ReasoningContent))
						{
							SetReasoning(functionCallContent, dto.ReasoningContent);
						}
						list.Add(functionCallContent);
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(dto.ToolCallId))
			{
				list.Add(new FunctionResultContent(dto.ToolCallId, dto.ToolResult ?? string.Empty));
			}
			ChatMessage chatMessage = ((list.Count > 0) ? new ChatMessage(new ChatRole(dto.Role), list) : new ChatMessage(new ChatRole(dto.Role), dto.Text ?? string.Empty));
			if (!string.IsNullOrWhiteSpace(dto.ReasoningContent))
			{
				SetReasoning(chatMessage, dto.ReasoningContent);
			}
			return chatMessage;
		}
		catch
		{
			return null;
		}
	}

	private static IEnumerable<ChatMessage> DeserializeDisplayMessage(JsonSessionIndexManager.SessionMessageDto dto)
	{
		if (dto == null || string.IsNullOrWhiteSpace(dto.Role))
		{
			yield break;
		}
		if (!string.Equals(dto.Role, "assistant", StringComparison.OrdinalIgnoreCase))
		{
			ChatMessage chatMessage = CreateTextMessage(dto.Role, dto.Text);
			if (chatMessage != null)
			{
				yield return chatMessage;
			}
			yield break;
		}
		if (dto.Parts == null || dto.Parts.Count == 0)
		{
			ChatMessage chatMessage2 = CreateTextMessage(dto.Role, dto.Text);
			if (chatMessage2 != null)
			{
				yield return chatMessage2;
			}
			yield break;
		}
		List<AIContent> pendingAssistantContents = new List<AIContent>();
		foreach (JsonElement part in dto.Parts)
		{
			string partString = GetPartString(part, "type");
			if (string.Equals(partString, "text", StringComparison.OrdinalIgnoreCase))
			{
				string partString2 = GetPartString(part, "text");
				if (!string.IsNullOrWhiteSpace(partString2))
				{
					pendingAssistantContents.Add(new TextContent(partString2));
				}
			}
			else if (string.Equals(partString, "tool-call", StringComparison.OrdinalIgnoreCase))
			{
				string partString3 = GetPartString(part, "toolName");
				if (!string.IsNullOrWhiteSpace(partString3))
				{
					string partString4 = GetPartString(part, "toolCallId");
					string normalizedToolCallId = (string.IsNullOrWhiteSpace(partString4) ? Guid.NewGuid().ToString("N") : partString4);
					pendingAssistantContents.Add(new FunctionCallContent(normalizedToolCallId, partString3, GetPartArguments(part)));
					yield return new ChatMessage(ChatRole.Assistant, pendingAssistantContents);
					pendingAssistantContents = new List<AIContent>();
					yield return new ChatMessage(ChatRole.Tool, new AIContent[1]
					{
						new FunctionResultContent(normalizedToolCallId, GetPartString(part, "result") ?? string.Empty)
					});
				}
			}
		}
		if (pendingAssistantContents.Count > 0)
		{
			yield return new ChatMessage(ChatRole.Assistant, pendingAssistantContents);
		}
	}

	private static ChatMessage CreateTextMessage(string role, string text)
	{
		try
		{
			return new ChatMessage(new ChatRole(role), text ?? string.Empty);
		}
		catch
		{
			return null;
		}
	}

	private static string GetPartString(JsonElement part, string propertyName)
	{
		if (part.ValueKind != JsonValueKind.Object || !part.TryGetProperty(propertyName, out var value) || value.ValueKind == JsonValueKind.Null || value.ValueKind == JsonValueKind.Undefined)
		{
			return null;
		}
		if (value.ValueKind != JsonValueKind.String)
		{
			return value.ToString();
		}
		return value.GetString();
	}

	private static Dictionary<string, object> GetPartArguments(JsonElement part)
	{
		if (part.ValueKind != JsonValueKind.Object || !part.TryGetProperty("args", out var value) || value.ValueKind == JsonValueKind.Null || value.ValueKind == JsonValueKind.Undefined)
		{
			return new Dictionary<string, object>();
		}
		try
		{
			return JsonSerializer.Deserialize<Dictionary<string, object>>(value.GetRawText()) ?? new Dictionary<string, object>();
		}
		catch
		{
			return new Dictionary<string, object>();
		}
	}

	private static Dictionary<string, object> DeserializeArguments(string json)
	{
		if (string.IsNullOrWhiteSpace(json))
		{
			return new Dictionary<string, object>();
		}
		try
		{
			return JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
		}
		catch
		{
			return new Dictionary<string, object>();
		}
	}

	private static void SetReasoning(ChatMessage message, string reasoning)
	{
		if (message != null && !string.IsNullOrWhiteSpace(reasoning))
		{
			if (message.AdditionalProperties == null)
			{
				message.AdditionalProperties = new AdditionalPropertiesDictionary();
			}
			message.AdditionalProperties["reasoning_content"] = reasoning;
		}
	}

	private static void SetReasoning(AIContent content, string reasoning)
	{
		if (content != null && !string.IsNullOrWhiteSpace(reasoning))
		{
			if (content.AdditionalProperties == null)
			{
				content.AdditionalProperties = new AdditionalPropertiesDictionary();
			}
			content.AdditionalProperties["reasoning_content"] = reasoning;
		}
	}
}
