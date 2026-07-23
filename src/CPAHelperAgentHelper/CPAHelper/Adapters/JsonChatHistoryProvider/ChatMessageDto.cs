using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Adapters;

public class JsonChatHistoryProvider : ChatHistoryProvider
{
	internal class SessionFileDto
	{
		public string SessionId { get; set; }

		public List<ChatMessageDto> Messages { get; set; } = new List<ChatMessageDto>();

		public List<ChatMessageDto> RuntimeMessages { get; set; }
	}

	internal class ChatMessageDto
	{
		public string Role { get; set; }

		public string Text { get; set; }

		public List<JsonElement> Parts { get; set; }

		public string ReasoningContent { get; set; }

		public List<ToolCallDto> ToolCalls { get; set; }

		public string ToolCallId { get; set; }

		public string ToolResult { get; set; }
	}

	internal class ToolCallDto
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string ArgumentsJson { get; set; }
	}

	private const string ReasoningContentKey = "reasoning_content";

	private readonly string _sessionsDir;

	private readonly string _sessionId;

	private List<ChatMessage> _cachedMessages;

	private bool _loaded;

	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		PropertyNameCaseInsensitive = true
	};

	public JsonChatHistoryProvider(string sessionsDir, string sessionId)
	{
		_sessionsDir = sessionsDir;
		_sessionId = sessionId;
	}

	protected override async ValueTask<IEnumerable<ChatMessage>> ProvideChatHistoryAsync(InvokingContext context, CancellationToken cancellationToken)
	{
		await EnsureLoadedAsync();
		return _cachedMessages.Select(CloneMessage).ToList();
	}

	protected override async ValueTask StoreChatHistoryAsync(InvokedContext context, CancellationToken cancellationToken)
	{
		await EnsureLoadedAsync();
		List<ChatMessage> incomingMessages = ExtractPersistableMessages(context.RequestMessages);
		List<ChatMessage> incomingMessages2 = ExtractPersistableMessages(context.ResponseMessages);
		List<ChatMessage> existingHistory = MergeMessages(_cachedMessages, incomingMessages);
		existingHistory = MergeMessages(existingHistory, incomingMessages2);
		_cachedMessages = SanitizeMessages(existingHistory);
		await PersistSessionAsync();
	}

	private async Task EnsureLoadedAsync()
	{
		if (_loaded)
		{
			return;
		}
		await Task.Run(delegate
		{
			try
			{
				string sessionFilePath = GetSessionFilePath();
				if (File.Exists(sessionFilePath))
				{
					SessionFileDto sessionFileDto = JsonSerializer.Deserialize<SessionFileDto>(File.ReadAllText(sessionFilePath, Encoding.UTF8), JsonOptions);
					List<ChatMessageDto> list = sessionFileDto?.RuntimeMessages;
					if (list != null && list.Count > 0)
					{
						_cachedMessages = (from m in list.Select(DeserializeRuntimeMessage)
							where m != null
							select m).ToList();
					}
					else if (sessionFileDto?.Messages != null)
					{
						_cachedMessages = (from m in sessionFileDto.Messages.SelectMany(DeserializeDisplayMessages)
							where m != null
							select m).ToList();
					}
					else
					{
						_cachedMessages = new List<ChatMessage>();
					}
				}
				else
				{
					_cachedMessages = new List<ChatMessage>();
				}
			}
			catch
			{
				_cachedMessages = new List<ChatMessage>();
			}
		});
		_loaded = true;
	}

	private async Task PersistSessionAsync()
	{
		await Task.Run(delegate
		{
			try
			{
				List<JsonSessionIndexManager.SessionMessageDto> messages = JsonSessionIndexManager.GetSessionDetail(_sessionId)?.Messages ?? new List<JsonSessionIndexManager.SessionMessageDto>();
				JsonSessionIndexManager.SaveSessionDetail(_sessionId, messages, (from m in _cachedMessages.SelectMany(SerializeRuntimeMessages)
					where m != null
					select new JsonSessionIndexManager.RuntimeMessageDto
					{
						Role = m.Role,
						Text = m.Text,
						ReasoningContent = m.ReasoningContent,
						ToolCalls = m.ToolCalls?.Select((ToolCallDto tc) => new JsonSessionIndexManager.RuntimeToolCallDto
						{
							Id = tc.Id,
							Name = tc.Name,
							ArgumentsJson = tc.ArgumentsJson
						}).ToList(),
						ToolCallId = m.ToolCallId,
						ToolResult = m.ToolResult
					}).ToList());
			}
			catch
			{
			}
		});
	}

	private string GetSessionFilePath()
	{
		return Path.Combine(_sessionsDir, _sessionId + ".json");
	}

	private static List<ChatMessage> MergeMessages(List<ChatMessage> existingHistory, List<ChatMessage> incomingMessages)
	{
		if (existingHistory.Count == 0)
		{
			return incomingMessages.Select(CloneMessage).ToList();
		}
		if (incomingMessages.Count == 0)
		{
			return existingHistory.Select(CloneMessage).ToList();
		}
		List<ChatMessage> list = existingHistory.Select(CloneMessage).ToList();
		int count = FindTailOverlap(existingHistory, incomingMessages);
		list.AddRange(incomingMessages.Skip(count).Select(CloneMessage));
		return list;
	}

	private static int FindTailOverlap(List<ChatMessage> existingHistory, List<ChatMessage> incomingMessages)
	{
		for (int num = Math.Min(existingHistory.Count, incomingMessages.Count); num > 0; num--)
		{
			bool flag = true;
			for (int i = 0; i < num; i++)
			{
				ChatMessage a = existingHistory[existingHistory.Count - num + i];
				ChatMessage b = incomingMessages[i];
				if (!IsSameMessage(a, b))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return num;
			}
		}
		return 0;
	}

	private static List<ChatMessage> ExtractPersistableMessages(IEnumerable<ChatMessage> messages)
	{
		if (messages == null)
		{
			return new List<ChatMessage>();
		}
		return messages.Where(IsPersistableMessage).Select(CloneMessage).ToList();
	}

	private static bool IsPersistableMessage(ChatMessage message)
	{
		if (message == null)
		{
			return false;
		}
		if (message.Role != ChatRole.User && message.Role != ChatRole.Assistant && message.Role != ChatRole.Tool)
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(message.Text) && GetFunctionCallIds(message).Count <= 0)
		{
			return GetFunctionResult(message) != null;
		}
		return true;
	}

	private static bool IsDisplayMessage(ChatMessage message)
	{
		if (message != null && (message.Role == ChatRole.User || message.Role == ChatRole.Assistant))
		{
			return !string.IsNullOrWhiteSpace(message.Text);
		}
		return false;
	}

	private static List<ChatMessage> SanitizeMessages(List<ChatMessage> messages)
	{
		List<ChatMessage> list = new List<ChatMessage>();
		int? num = null;
		HashSet<string> hashSet = new HashSet<string>();
		foreach (ChatMessage message in messages)
		{
			if (num.HasValue)
			{
				if (message.Role == ChatRole.Tool)
				{
					list.Add(message);
					foreach (AIContent content in message.Contents)
					{
						if (content is FunctionResultContent functionResultContent && hashSet.Contains(functionResultContent.CallId))
						{
							hashSet.Remove(functionResultContent.CallId);
						}
					}
					if (hashSet.Count == 0)
					{
						num = null;
					}
					continue;
				}
				if (num.Value < list.Count)
				{
					list.RemoveAt(num.Value);
				}
				num = null;
				hashSet.Clear();
			}
			list.Add(message);
			List<string> functionCallIds = GetFunctionCallIds(message);
			if (functionCallIds.Count > 0)
			{
				num = list.Count - 1;
				hashSet = new HashSet<string>(functionCallIds);
			}
		}
		if (num.HasValue && num.Value < list.Count)
		{
			list.RemoveAt(num.Value);
		}
		return list;
	}

	private static List<string> GetFunctionCallIds(ChatMessage msg)
	{
		List<string> list = new List<string>();
		if (msg.Contents == null)
		{
			return list;
		}
		foreach (AIContent content in msg.Contents)
		{
			if (content is FunctionCallContent functionCallContent && !string.IsNullOrEmpty(functionCallContent.CallId))
			{
				list.Add(functionCallContent.CallId);
			}
		}
		return list;
	}

	private static bool IsSameMessage(ChatMessage a, ChatMessage b)
	{
		if (a.Role != b.Role)
		{
			return false;
		}
		return a.Text == b.Text;
	}

	private static ChatMessageDto SerializeDisplayMessage(ChatMessage msg)
	{
		return new ChatMessageDto
		{
			Role = msg.Role.Value,
			Text = msg.Text
		};
	}

	private static IEnumerable<ChatMessageDto> SerializeRuntimeMessages(ChatMessage msg)
	{
		if (msg == null)
		{
			yield break;
		}
		if (msg.Role == ChatRole.Tool)
		{
			List<FunctionResultContent> list = msg.Contents?.OfType<FunctionResultContent>().ToList();
			if (list != null && list.Count > 0)
			{
				foreach (FunctionResultContent item in list)
				{
					yield return new ChatMessageDto
					{
						Role = msg.Role.Value,
						Text = msg.Text,
						ToolCallId = item.CallId,
						ToolResult = ConvertToolResultToText(item)
					};
				}
				yield break;
			}
		}
		ChatMessageDto chatMessageDto = SerializeRuntimeMessage(msg);
		if (chatMessageDto != null)
		{
			yield return chatMessageDto;
		}
	}

	private static ChatMessageDto SerializeRuntimeMessage(ChatMessage msg)
	{
		if (msg == null)
		{
			return null;
		}
		ChatMessageDto chatMessageDto = new ChatMessageDto
		{
			Role = msg.Role.Value,
			Text = msg.Text,
			ReasoningContent = GetReasoning(msg)
		};
		List<ToolCallDto> list = (from call in msg.Contents?.OfType<FunctionCallContent>()
			select new ToolCallDto
			{
				Id = call.CallId,
				Name = call.Name,
				ArgumentsJson = SerializeArguments(call.Arguments)
			} into call
			where !string.IsNullOrWhiteSpace(call.Name)
			select call).ToList();
		if (list != null && list.Count > 0)
		{
			chatMessageDto.ToolCalls = list;
		}
		FunctionResultContent functionResult = GetFunctionResult(msg);
		if (functionResult != null)
		{
			chatMessageDto.ToolCallId = functionResult.CallId;
			chatMessageDto.ToolResult = ConvertToolResultToText(functionResult);
		}
		return chatMessageDto;
	}

	private static ChatMessage DeserializeMessage(ChatMessageDto dto)
	{
		if (dto == null)
		{
			return null;
		}
		try
		{
			return new ChatMessage(new ChatRole(dto.Role), dto.Text);
		}
		catch
		{
			return null;
		}
	}

	private static IEnumerable<ChatMessage> DeserializeDisplayMessages(ChatMessageDto dto)
	{
		if (dto == null)
		{
			yield break;
		}
		if (!string.Equals(dto.Role, "assistant", StringComparison.OrdinalIgnoreCase))
		{
			ChatMessage chatMessage = DeserializeMessage(dto);
			if (chatMessage != null)
			{
				yield return chatMessage;
			}
			yield break;
		}
		if (dto.Parts == null || dto.Parts.Count == 0)
		{
			ChatMessage chatMessage2 = DeserializeMessage(dto);
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
				string partString3 = GetPartString(part, "toolCallId");
				string partString4 = GetPartString(part, "toolName");
				if (!string.IsNullOrWhiteSpace(partString4))
				{
					string normalizedToolCallId = (string.IsNullOrWhiteSpace(partString3) ? Guid.NewGuid().ToString("N") : partString3);
					pendingAssistantContents.Add(new FunctionCallContent(normalizedToolCallId, partString4, GetPartArguments(part)));
					yield return new ChatMessage(ChatRole.Assistant, pendingAssistantContents);
					pendingAssistantContents = new List<AIContent>();
					yield return new ChatMessage(ChatRole.Tool, new List<AIContent>
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

	private static ChatMessage DeserializeRuntimeMessage(ChatMessageDto dto)
	{
		if (dto == null)
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
				foreach (ToolCallDto toolCall in dto.ToolCalls)
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
			return JsonSerializer.Deserialize<Dictionary<string, object>>(value.GetRawText(), JsonOptions) ?? new Dictionary<string, object>();
		}
		catch
		{
			return new Dictionary<string, object>();
		}
	}

	private static ChatMessage CloneMessage(ChatMessage msg)
	{
		if (msg == null)
		{
			return null;
		}
		ChatMessage chatMessage = ((msg.Contents == null || msg.Contents.Count == 0) ? new ChatMessage(msg.Role, msg.Text) : new ChatMessage(msg.Role, (from c in msg.Contents.Select(CloneContent)
			where c != null
			select c).ToList()));
		chatMessage.AuthorName = msg.AuthorName;
		chatMessage.CreatedAt = msg.CreatedAt;
		chatMessage.MessageId = msg.MessageId;
		chatMessage.RawRepresentation = msg.RawRepresentation;
		if (msg.AdditionalProperties != null)
		{
			chatMessage.AdditionalProperties = msg.AdditionalProperties.Clone();
		}
		return chatMessage;
	}

	private static AIContent CloneContent(AIContent content)
	{
		AIContent aIContent = null;
		if (content is TextReasoningContent textReasoningContent)
		{
			aIContent = new TextReasoningContent(textReasoningContent.Text)
			{
				ProtectedData = textReasoningContent.ProtectedData
			};
		}
		else if (content is TextContent textContent)
		{
			aIContent = new TextContent(textContent.Text);
		}
		else if (content is FunctionCallContent functionCallContent)
		{
			aIContent = new FunctionCallContent(functionCallContent.CallId, functionCallContent.Name, CloneArguments(functionCallContent.Arguments))
			{
				Exception = functionCallContent.Exception,
				InformationalOnly = functionCallContent.InformationalOnly
			};
		}
		else if (content is FunctionResultContent functionResultContent)
		{
			aIContent = new FunctionResultContent(functionResultContent.CallId, functionResultContent.Result)
			{
				Exception = functionResultContent.Exception
			};
		}
		if (aIContent == null)
		{
			return null;
		}
		aIContent.RawRepresentation = content.RawRepresentation;
		if (content.AdditionalProperties != null)
		{
			aIContent.AdditionalProperties = content.AdditionalProperties.Clone();
		}
		return aIContent;
	}

	private static IDictionary<string, object> CloneArguments(IDictionary<string, object> arguments)
	{
		if (arguments != null)
		{
			return arguments.ToDictionary((KeyValuePair<string, object> kv) => kv.Key, (KeyValuePair<string, object> kv) => kv.Value);
		}
		return new Dictionary<string, object>();
	}

	private static FunctionResultContent GetFunctionResult(ChatMessage message)
	{
		return message?.Contents?.OfType<FunctionResultContent>().FirstOrDefault();
	}

	private static string GetReasoning(ChatMessage message)
	{
		if (message == null)
		{
			return null;
		}
		if (message.AdditionalProperties != null && message.AdditionalProperties.TryGetValue("reasoning_content", out object value) && value != null)
		{
			string text = value.ToString();
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
		}
		IEnumerable<string> enumerable = (from c in message.Contents?.OfType<TextReasoningContent>()
			select c.Text into t
			where !string.IsNullOrEmpty(t)
			select t);
		string text2 = ((enumerable == null) ? null : string.Concat(enumerable));
		if (!string.IsNullOrWhiteSpace(text2))
		{
			return text2;
		}
		return (from c in message.Contents?.OfType<FunctionCallContent>()
			select (c.AdditionalProperties != null && c.AdditionalProperties.TryGetValue("reasoning_content", out object value2) && value2 != null) ? value2.ToString() : null).FirstOrDefault((string v) => !string.IsNullOrWhiteSpace(v));
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

	private static string SerializeArguments(IDictionary<string, object> arguments)
	{
		if (arguments != null && arguments.Count != 0)
		{
			return JsonSerializer.Serialize(arguments, JsonOptions);
		}
		return "{}";
	}

	private static Dictionary<string, object> DeserializeArguments(string json)
	{
		if (string.IsNullOrWhiteSpace(json))
		{
			return new Dictionary<string, object>();
		}
		try
		{
			return JsonSerializer.Deserialize<Dictionary<string, object>>(json, JsonOptions) ?? new Dictionary<string, object>();
		}
		catch
		{
			return new Dictionary<string, object>();
		}
	}

	private static string ConvertToolResultToText(FunctionResultContent result)
	{
		if (result == null)
		{
			return string.Empty;
		}
		if (result.Exception != null)
		{
			return "Error: " + result.Exception.Message;
		}
		if (result.Result == null)
		{
			return string.Empty;
		}
		if (result.Result is string result2)
		{
			return result2;
		}
		return JsonSerializer.Serialize(result.Result, JsonOptions);
	}
}
