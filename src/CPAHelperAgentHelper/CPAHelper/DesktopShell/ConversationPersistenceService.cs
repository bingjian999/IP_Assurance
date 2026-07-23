using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Adapters;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal static class ConversationPersistenceService
{
	private static readonly JsonSerializerOptions ReadableJsonOptions = new JsonSerializerOptions
	{
		Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
	};

	public static void PersistTurn(string threadId, string userMessage, string assistantMessage, List<PersistedMessagePart> assistantParts = null, object assistantPartsSyncRoot = null, string displayUserMessage = null, string selectedSkill = null, string finishReason = null)
	{
		PersistTurn(threadId, userMessage, assistantMessage, assistantParts, assistantPartsSyncRoot, displayUserMessage, string.IsNullOrWhiteSpace(selectedSkill) ? Array.Empty<string>() : new string[1] { selectedSkill }, Array.Empty<HostContextItem>(), Array.Empty<string>(), finishReason);
	}

	public static void PersistTurn(string threadId, string userMessage, string assistantMessage, List<PersistedMessagePart> assistantParts = null, object assistantPartsSyncRoot = null, string displayUserMessage = null, IReadOnlyList<string> selectedSkills = null, IReadOnlyList<HostContextItem> hostContextItems = null, IReadOnlyList<string> selectedTools = null, string finishReason = null)
	{
		if (string.IsNullOrWhiteSpace(threadId))
		{
			return;
		}
		List<JsonSessionIndexManager.SessionMessageDto> list = (JsonSessionIndexManager.GetSessionDetail(threadId) ?? new JsonSessionIndexManager.SessionDetailDto
		{
			SessionId = threadId,
			Messages = new List<JsonSessionIndexManager.SessionMessageDto>()
		}).Messages ?? new List<JsonSessionIndexManager.SessionMessageDto>();
		string modelUserMessage = (userMessage ?? string.Empty).Trim();
		string text = (string.IsNullOrWhiteSpace(displayUserMessage) ? userMessage : displayUserMessage).Trim();
		IReadOnlyList<string> selectedSkills2 = NormalizeSelectedSkills(selectedSkills);
		IReadOnlyList<string> selectedTools2 = NormalizeSelectedTools(selectedTools);
		IReadOnlyList<HostContextItem> hostContextItems2 = NormalizeHostContextItems(hostContextItems);
		string text2 = (assistantMessage ?? string.Empty).Trim();
		List<JsonElement> list2 = BuildPersistedContentParts(assistantParts, assistantPartsSyncRoot);
		NormalizeVisibleUserMessage(list, modelUserMessage, text, selectedSkills2, hostContextItems2, selectedTools2);
		if (list.Count >= 2 && string.Equals(list[list.Count - 2].Role, "user", StringComparison.OrdinalIgnoreCase) && string.Equals(list[list.Count - 2].Text ?? string.Empty, text, StringComparison.Ordinal) && string.Equals(list[list.Count - 1].Role, "assistant", StringComparison.OrdinalIgnoreCase) && string.Equals(list[list.Count - 1].Text ?? string.Empty, text2, StringComparison.Ordinal))
		{
			JsonSessionIndexManager.SessionMessageDto sessionMessageDto = list[list.Count - 1];
			string finishReason2 = sessionMessageDto.FinishReason;
			sessionMessageDto.FinishReason = NormalizeFinishReason(finishReason) ?? sessionMessageDto.FinishReason;
			if (list2.Count > 0 && (sessionMessageDto.Parts == null || sessionMessageDto.Parts.Count == 0))
			{
				sessionMessageDto.Parts = list2;
				JsonSessionIndexManager.SaveSessionDetail(threadId, list);
			}
			else if (!string.Equals(finishReason2, sessionMessageDto.FinishReason, StringComparison.Ordinal))
			{
				JsonSessionIndexManager.SaveSessionDetail(threadId, list);
			}
			return;
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			JsonSessionIndexManager.SessionMessageDto sessionMessageDto2 = list.LastOrDefault();
			if (sessionMessageDto2 == null || !string.Equals(sessionMessageDto2.Role, "user", StringComparison.OrdinalIgnoreCase) || !string.Equals(sessionMessageDto2.Text ?? string.Empty, text, StringComparison.Ordinal))
			{
				list.Add(new JsonSessionIndexManager.SessionMessageDto
				{
					Role = "user",
					Text = text,
					Parts = BuildUserMessageParts(text, selectedSkills2, hostContextItems2, selectedTools2)
				});
			}
		}
		if (!string.IsNullOrWhiteSpace(text2) || list2.Count > 0 || IsTerminalFinishReason(finishReason))
		{
			JsonSessionIndexManager.SessionMessageDto sessionMessageDto3 = list.LastOrDefault();
			if (sessionMessageDto3 == null || !string.Equals(sessionMessageDto3.Role, "assistant", StringComparison.OrdinalIgnoreCase) || !string.Equals(sessionMessageDto3.Text ?? string.Empty, text2, StringComparison.Ordinal))
			{
				list.Add(new JsonSessionIndexManager.SessionMessageDto
				{
					Role = "assistant",
					Text = text2,
					Parts = ((list2.Count > 0) ? list2 : null),
					FinishReason = NormalizeFinishReason(finishReason)
				});
			}
			else if (list2.Count > 0)
			{
				sessionMessageDto3.Parts = list2;
				sessionMessageDto3.FinishReason = NormalizeFinishReason(finishReason) ?? sessionMessageDto3.FinishReason;
			}
		}
		JsonSessionIndexManager.SaveSessionDetail(threadId, list);
	}

	public static bool TryBuildCanceledTurnRecoveryUserMessage(string threadId, string currentUserMessage, out string modelUserMessage, out CanceledTurnRecoveryInfo recoveryInfo)
	{
		modelUserMessage = currentUserMessage ?? string.Empty;
		recoveryInfo = null;
		if (string.IsNullOrWhiteSpace(threadId))
		{
			return false;
		}
		List<JsonSessionIndexManager.SessionMessageDto> list = JsonSessionIndexManager.GetSessionDetail(threadId)?.Messages;
		if (list == null || list.Count < 2)
		{
			return false;
		}
		int num = list.Count - 1;
		JsonSessionIndexManager.SessionMessageDto sessionMessageDto = list[num];
		if (sessionMessageDto == null || !string.Equals(sessionMessageDto.Role, "assistant", StringComparison.OrdinalIgnoreCase) || !IsRecoverableInterruptedFinishReason(sessionMessageDto.FinishReason))
		{
			return false;
		}
		JsonSessionIndexManager.SessionMessageDto sessionMessageDto2 = null;
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			JsonSessionIndexManager.SessionMessageDto sessionMessageDto3 = list[num2];
			if (sessionMessageDto3 != null && string.Equals(sessionMessageDto3.Role, "user", StringComparison.OrdinalIgnoreCase))
			{
				sessionMessageDto2 = sessionMessageDto3;
				break;
			}
		}
		if (sessionMessageDto2 == null || string.IsNullOrWhiteSpace(sessionMessageDto2.Text))
		{
			return false;
		}
		bool hasToolSummary;
		string text = BuildCanceledAssistantContext(sessionMessageDto, out hasToolSummary);
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		string text2 = TruncateForRecovery(text, 4000);
		string value = TruncateForRecovery(sessionMessageDto2.Text, 2000);
		string value2 = currentUserMessage ?? string.Empty;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("[Hidden continuation context]");
		stringBuilder.AppendLine(BuildRecoveryInstruction(sessionMessageDto.FinishReason));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Previous user message:");
		stringBuilder.AppendLine(value);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(string.Equals(sessionMessageDto.FinishReason, "error", StringComparison.OrdinalIgnoreCase) ? "Assistant output before the error:" : "Partial assistant output before stop:");
		stringBuilder.AppendLine(text2);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("[Current user message]");
		stringBuilder.Append(value2);
		modelUserMessage = stringBuilder.ToString();
		recoveryInfo = new CanceledTurnRecoveryInfo
		{
			PreviousUserLength = sessionMessageDto2.Text.Length,
			AssistantPartialLength = text.Length,
			InjectedAssistantPartialLength = text2.Length,
			HasToolSummary = hasToolSummary
		};
		return true;
	}

	private static bool IsRecoverableInterruptedFinishReason(string finishReason)
	{
		if (!string.Equals(finishReason, "cancel", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(finishReason, "error", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static bool IsTerminalFinishReason(string finishReason)
	{
		if (!string.Equals(finishReason, "stop", StringComparison.OrdinalIgnoreCase))
		{
			return IsRecoverableInterruptedFinishReason(finishReason);
		}
		return true;
	}

	private static string BuildRecoveryInstruction(string finishReason)
	{
		if (string.Equals(finishReason, "error", StringComparison.OrdinalIgnoreCase))
		{
			return "The previous assistant turn was interrupted by an error before completion. Use the partial context below only if it helps answer the current user message. If the current user message is unrelated, ignore this context. Do not mention this hidden context unless the user asks.";
		}
		return "The previous assistant turn was stopped by the user before completion. Use the partial context below only if it helps answer the current user message. If the current user message is unrelated, ignore this context. Do not mention this hidden context unless the user asks.";
	}

	private static void NormalizeVisibleUserMessage(List<JsonSessionIndexManager.SessionMessageDto> messages, string modelUserMessage, string displayUserMessage, IReadOnlyList<string> selectedSkills, IReadOnlyList<HostContextItem> hostContextItems, IReadOnlyList<string> selectedTools)
	{
		if (messages == null || string.IsNullOrWhiteSpace(displayUserMessage))
		{
			return;
		}
		for (int num = messages.Count - 1; num >= 0; num--)
		{
			JsonSessionIndexManager.SessionMessageDto sessionMessageDto = messages[num];
			if (sessionMessageDto != null && string.Equals(sessionMessageDto.Role, "user", StringComparison.OrdinalIgnoreCase))
			{
				string a = sessionMessageDto.Text ?? string.Empty;
				if (string.Equals(a, modelUserMessage, StringComparison.Ordinal) || string.Equals(a, displayUserMessage, StringComparison.Ordinal))
				{
					sessionMessageDto.Text = displayUserMessage;
					sessionMessageDto.Parts = BuildUserMessageParts(displayUserMessage, selectedSkills, hostContextItems, selectedTools);
					break;
				}
			}
		}
	}

	private static IReadOnlyList<string> NormalizeSelectedSkills(IReadOnlyList<string> selectedSkills)
	{
		return (from skill in selectedSkills ?? Array.Empty<string>()
			where !string.IsNullOrWhiteSpace(skill)
			select skill.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
	}

	private static IReadOnlyList<string> NormalizeSelectedTools(IReadOnlyList<string> selectedTools)
	{
		return (from tool in selectedTools ?? Array.Empty<string>()
			where !string.IsNullOrWhiteSpace(tool)
			select tool.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
	}

	private static IReadOnlyList<HostContextItem> NormalizeHostContextItems(IReadOnlyList<HostContextItem> hostContextItems)
	{
		return (from item in hostContextItems ?? Array.Empty<HostContextItem>()
			where item != null && (!string.IsNullOrWhiteSpace(item.DisplayText) || !string.IsNullOrWhiteSpace(item.PromptText))
			select new HostContextItem
			{
				Id = (string.IsNullOrWhiteSpace(item.Id) ? Guid.NewGuid().ToString("N") : item.Id.Trim()),
				Kind = (string.IsNullOrWhiteSpace(item.Kind) ? "reference" : item.Kind.Trim()),
				Label = (string.IsNullOrWhiteSpace(item.Label) ? "引用" : item.Label.Trim()),
				DisplayText = (item.DisplayText ?? string.Empty).Trim(),
				PromptText = (item.PromptText ?? string.Empty).Trim(),
				Metadata = item.Metadata
			}).ToList();
	}

	private static List<JsonElement> BuildUserMessageParts(string text, IReadOnlyList<string> selectedSkills, IReadOnlyList<HostContextItem> hostContextItems, IReadOnlyList<string> selectedTools)
	{
		List<JsonElement> list = new List<JsonElement>();
		foreach (HostContextItem item in hostContextItems ?? Array.Empty<HostContextItem>())
		{
			list.Add(ToJsonElement(new
			{
				type = "data-host-context",
				data = new
				{
					id = item.Id,
					kind = item.Kind,
					label = item.Label,
					displayText = item.DisplayText,
					promptText = item.PromptText,
					metadata = item.Metadata
				}
			}));
		}
		foreach (string item2 in selectedSkills ?? Array.Empty<string>())
		{
			list.Add(ToJsonElement(new
			{
				type = "data-skill",
				data = new
				{
					skillName = item2
				}
			}));
		}
		foreach (string item3 in selectedTools ?? Array.Empty<string>())
		{
			list.Add(ToJsonElement(new
			{
				type = "data-tool",
				data = new
				{
					toolName = item3
				}
			}));
		}
		list.Add(ToJsonElement(new
		{
			type = "text",
			text = (text ?? string.Empty)
		}));
		return list;
	}

	public static void AppendTextPart(List<PersistedMessagePart> parts, object syncRoot, string text)
	{
		if (parts == null || string.IsNullOrEmpty(text))
		{
			return;
		}
		lock (syncRoot ?? parts)
		{
			int num = FindVisibleAppendIndex(parts);
			PersistedMessagePart persistedMessagePart = ((num > 0) ? parts[num - 1] : null);
			if (persistedMessagePart != null && string.Equals(persistedMessagePart.Type, "text", StringComparison.Ordinal))
			{
				persistedMessagePart.Text = (persistedMessagePart.Text ?? string.Empty) + text;
				return;
			}
			InsertVisiblePart(parts, new PersistedMessagePart
			{
				Type = "text",
				Text = text
			});
		}
	}

	public static void AppendUserInterruptPart(List<PersistedMessagePart> parts, object syncRoot, UserInterruptEvent userInterrupt)
	{
		if (parts == null || userInterrupt == null || string.IsNullOrWhiteSpace(userInterrupt.InjectionId))
		{
			return;
		}
		lock (syncRoot ?? parts)
		{
			if (!parts.Any((PersistedMessagePart part) => string.Equals(part?.Type, "data-user-interrupt", StringComparison.Ordinal) && string.Equals(GetString(part.Data, "injectionId"), userInterrupt.InjectionId, StringComparison.Ordinal)))
			{
				InsertVisiblePart(parts, new PersistedMessagePart
				{
					Type = "data-user-interrupt",
					Data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
					{
						["injectionId"] = userInterrupt.InjectionId,
						["displayMessage"] = userInterrupt.DisplayMessage ?? string.Empty,
						["selectedSkills"] = userInterrupt.SelectedSkills ?? new List<string>(),
						["selectedTools"] = userInterrupt.SelectedTools ?? new List<string>(),
						["hostContextItems"] = userInterrupt.HostContextItems ?? new List<HostContextItem>(),
						["status"] = userInterrupt.Status ?? "accepted"
					}
				});
			}
		}
	}

	public static void UpdateUserInterruptStatus(List<PersistedMessagePart> parts, object syncRoot, string injectionId, string status)
	{
		if (parts == null || string.IsNullOrWhiteSpace(injectionId))
		{
			return;
		}
		lock (syncRoot ?? parts)
		{
			PersistedMessagePart persistedMessagePart = parts.LastOrDefault((PersistedMessagePart item) => string.Equals(item?.Type, "data-user-interrupt", StringComparison.Ordinal) && string.Equals(GetString(item.Data, "injectionId"), injectionId, StringComparison.Ordinal));
			if (persistedMessagePart?.Data != null)
			{
				persistedMessagePart.Data["status"] = status ?? "accepted";
			}
		}
	}

	public static void UpdatePersistedUserInterruptStatus(string threadId, string injectionId, string status)
	{
		if (string.IsNullOrWhiteSpace(threadId) || string.IsNullOrWhiteSpace(injectionId))
		{
			return;
		}
		JsonSessionIndexManager.SessionDetailDto sessionDetail = JsonSessionIndexManager.GetSessionDetail(threadId);
		if (sessionDetail?.Messages == null)
		{
			return;
		}
		bool flag = false;
		foreach (JsonSessionIndexManager.SessionMessageDto message in sessionDetail.Messages)
		{
			if (message?.Parts == null)
			{
				continue;
			}
			for (int i = 0; i < message.Parts.Count; i++)
			{
				JsonElement jsonElement = message.Parts[i];
				if (jsonElement.TryGetProperty("type", out var value) && string.Equals(value.GetString(), "data-user-interrupt", StringComparison.Ordinal) && jsonElement.TryGetProperty("data", out var value2) && value2.TryGetProperty("injectionId", out var value3) && string.Equals(value3.GetString(), injectionId, StringComparison.Ordinal))
				{
					Dictionary<string, object> dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(value2.GetRawText()) ?? new Dictionary<string, object>();
					dictionary["status"] = status ?? "accepted";
					message.Parts[i] = JsonSerializer.SerializeToElement(new
					{
						type = "data-user-interrupt",
						data = dictionary
					}, ReadableJsonOptions);
					flag = true;
				}
			}
		}
		if (flag)
		{
			JsonSessionIndexManager.SaveSessionDetail(threadId, sessionDetail.Messages);
		}
	}

	public static void AppendToolCallPart(List<PersistedMessagePart> parts, object syncRoot, string toolCallId, string toolName, IDictionary<string, object> args, string argsText)
	{
		if (parts == null || string.IsNullOrWhiteSpace(toolCallId))
		{
			return;
		}
		lock (syncRoot ?? parts)
		{
			InsertVisiblePart(parts, new PersistedMessagePart
			{
				Type = "tool-call",
				ToolCallId = toolCallId,
				ToolName = (toolName ?? "tool"),
				Args = (args ?? new Dictionary<string, object>()),
				ArgsText = (argsText ?? string.Empty)
			});
		}
	}

	public static bool HasPersistedContentParts(List<PersistedMessagePart> parts, object syncRoot)
	{
		if (parts == null)
		{
			return false;
		}
		lock (syncRoot ?? parts)
		{
			return parts.Any((PersistedMessagePart part) => part != null && (!string.Equals(part.Type, "text", StringComparison.Ordinal) || !string.IsNullOrWhiteSpace(part.Text)));
		}
	}

	public static void ApplyToolResult(List<PersistedMessagePart> parts, string toolCallId, string toolName, string preview)
	{
		if (parts != null && !string.IsNullOrWhiteSpace(toolCallId))
		{
			PersistedMessagePart persistedMessagePart = parts.LastOrDefault((PersistedMessagePart item) => string.Equals(item.Type, "tool-call", StringComparison.Ordinal) && string.Equals(item.ToolCallId, toolCallId, StringComparison.Ordinal));
			if (persistedMessagePart == null)
			{
				persistedMessagePart = new PersistedMessagePart
				{
					Type = "tool-call",
					ToolCallId = toolCallId,
					ToolName = (toolName ?? "tool"),
					Args = new Dictionary<string, object>(),
					ArgsText = string.Empty
				};
				InsertVisiblePart(parts, persistedMessagePart);
			}
			if (!string.IsNullOrWhiteSpace(toolName))
			{
				persistedMessagePart.ToolName = toolName;
			}
			persistedMessagePart.Result = preview ?? string.Empty;
		}
	}

	public static void UpsertSubAgentActivity(List<PersistedMessagePart> parts, object syncRoot, SubAgentActivityUpdate update)
	{
		if (parts == null || update == null || string.IsNullOrWhiteSpace(update.ActivityId))
		{
			return;
		}
		lock (syncRoot ?? parts)
		{
			IDictionary<string, object> dictionary = EnsureSubAgentActivityItem(parts, update.ActivityId, update.ActivityGroupId, update.ActivityGroupTitle);
			SetIfNotBlank(dictionary, "activityId", update.ActivityId);
			SetIfNotBlank(dictionary, "activityGroupId", update.ActivityGroupId);
			SetIfNotBlank(dictionary, "activityGroupTitle", update.ActivityGroupTitle);
			SetIfNotBlank(dictionary, "agentName", update.AgentName);
			SetIfNotBlank(dictionary, "title", update.Title);
			SetIfNotBlank(dictionary, "status", update.Status);
			SetIfNotBlank(dictionary, "detail", update.Detail);
			SetIfNotBlank(dictionary, "resultPreview", update.ResultPreview);
			SetIfNotBlank(dictionary, "taskId", update.TaskId);
			SetIfNotBlank(dictionary, "taskStatus", update.TaskStatus);
			if (update.ResultRetrieved.HasValue)
			{
				dictionary["resultRetrieved"] = update.ResultRetrieved.Value;
			}
			AppendIfNotEmpty(dictionary, "reasoningText", update.ReasoningDelta);
			dictionary["updatedAt"] = (string.IsNullOrWhiteSpace(update.UpdatedAt) ? DateTimeOffset.Now.ToString("O") : update.UpdatedAt);
		}
	}

	public static void AppendSubAgentToolCallBegin(List<PersistedMessagePart> parts, object syncRoot, string parentActivityId, string toolCallId, string toolName, IDictionary<string, object> args, string argsText)
	{
		if (parts == null || string.IsNullOrWhiteSpace(parentActivityId) || string.IsNullOrWhiteSpace(toolCallId))
		{
			return;
		}
		lock (syncRoot ?? parts)
		{
			IDictionary<string, object> dictionary = EnsureSubAgentToolCall(EnsureSubAgentActivityItem(parts, parentActivityId), toolCallId);
			dictionary["type"] = "tool-call";
			dictionary["toolCallId"] = toolCallId;
			dictionary["toolName"] = toolName ?? "tool";
			dictionary["args"] = args ?? new Dictionary<string, object>();
			dictionary["argsText"] = argsText ?? string.Empty;
			dictionary["parentActivityId"] = parentActivityId;
		}
	}

	public static void ApplySubAgentToolCallResult(List<PersistedMessagePart> parts, object syncRoot, string parentActivityId, string toolCallId, string toolName, string preview)
	{
		if (parts == null || string.IsNullOrWhiteSpace(parentActivityId) || string.IsNullOrWhiteSpace(toolCallId))
		{
			return;
		}
		lock (syncRoot ?? parts)
		{
			IDictionary<string, object> dictionary = EnsureSubAgentToolCall(EnsureSubAgentActivityItem(parts, parentActivityId), toolCallId);
			dictionary["type"] = "tool-call";
			dictionary["toolCallId"] = toolCallId;
			dictionary["toolName"] = toolName ?? GetString(dictionary, "toolName") ?? "tool";
			dictionary["result"] = preview ?? string.Empty;
			dictionary["parentActivityId"] = parentActivityId;
		}
	}

	public static void AppendApprovalPart(List<PersistedMessagePart> parts, object syncRoot, ApprovalRequestEvent request)
	{
		if (parts == null || request == null || string.IsNullOrWhiteSpace(request.RequestId))
		{
			return;
		}
		lock (syncRoot ?? parts)
		{
			parts.Add(new PersistedMessagePart
			{
				Type = "data-approval",
				RequestId = request.RequestId,
				ThreadId = request.ThreadId,
				Title = request.Title,
				Message = request.Message,
				ToolName = request.ToolName,
				ArgsPreview = request.ArgsPreview,
				RiskLevel = request.RiskLevel,
				ConfirmLabel = request.ConfirmLabel,
				CancelLabel = request.CancelLabel,
				ApprovalMode = request.ApprovalMode,
				AutoApproved = request.AutoApproved,
				Status = (request.AutoApproved ? "approved" : "pending")
			});
		}
	}

	public static void ApplyApprovalResult(List<PersistedMessagePart> parts, object syncRoot, ApprovalResolvedEvent resolved)
	{
		if (parts == null || resolved == null || string.IsNullOrWhiteSpace(resolved.RequestId))
		{
			return;
		}
		lock (syncRoot ?? parts)
		{
			PersistedMessagePart persistedMessagePart = parts.LastOrDefault((PersistedMessagePart item) => string.Equals(item.Type, "data-approval", StringComparison.Ordinal) && string.Equals(item.RequestId, resolved.RequestId, StringComparison.Ordinal));
			if (persistedMessagePart != null)
			{
				persistedMessagePart.Status = (resolved.Approved ? "approved" : "rejected");
				persistedMessagePart.ResolvedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				persistedMessagePart.ApprovalMode = resolved.ApprovalMode;
				persistedMessagePart.AutoApproved = resolved.AutoApproved;
				persistedMessagePart.ErrorMessage = null;
			}
		}
	}

	public static string BuildToolResultPreview(object result, Exception exception)
	{
		string text = ((exception != null) ? ("Error: " + exception.Message) : SerializeToolResultPreview(result));
		if (text == null)
		{
			text = string.Empty;
		}
		if (text.Length <= 500)
		{
			return text;
		}
		return text.Substring(0, 500) + "…";
	}

	private static void InsertVisiblePart(List<PersistedMessagePart> parts, PersistedMessagePart part)
	{
		if (parts != null && part != null)
		{
			parts.Insert(FindVisibleAppendIndex(parts), part);
		}
	}

	private static int FindVisibleAppendIndex(List<PersistedMessagePart> parts)
	{
		if (parts == null || parts.Count == 0)
		{
			return 0;
		}
		int num = parts.Count;
		while (num > 0 && IsActiveSubAgentActivityPart(parts[num - 1]))
		{
			num--;
		}
		return num;
	}

	private static bool IsActiveSubAgentActivityPart(PersistedMessagePart part)
	{
		if (part == null || !string.Equals(part.Type, "data-subagent-activity", StringComparison.Ordinal) || part.Data == null || !part.Data.TryGetValue("items", out var value))
		{
			return false;
		}
		if (!(value is IEnumerable<object> enumerable))
		{
			return false;
		}
		foreach (object item in enumerable)
		{
			string a = GetString(item as IDictionary<string, object>, "status");
			if (string.Equals(a, "starting", StringComparison.OrdinalIgnoreCase) || string.Equals(a, "running", StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	private static string SerializeToolResultPreview(object result)
	{
		if (result == null)
		{
			return string.Empty;
		}
		if (result is string result2)
		{
			return result2;
		}
		if (result is JsonElement jsonElement)
		{
			return jsonElement.GetRawText();
		}
		try
		{
			return JsonSerializer.Serialize(result, ReadableJsonOptions);
		}
		catch
		{
			return result.ToString();
		}
	}

	private static IDictionary<string, object> EnsureSubAgentActivityItem(List<PersistedMessagePart> parts, string activityId, string activityGroupId = null, string activityGroupTitle = null)
	{
		foreach (PersistedMessagePart item in parts.Where((PersistedMessagePart item) => string.Equals(item.Type, "data-subagent-activity", StringComparison.Ordinal)))
		{
			if (item.Data == null)
			{
				continue;
			}
			foreach (object item2 in EnsureObjectList(item.Data, "items"))
			{
				if (item2 is IDictionary<string, object> dictionary && string.Equals(GetString(dictionary, "activityId"), activityId, StringComparison.Ordinal))
				{
					return dictionary;
				}
			}
		}
		PersistedMessagePart persistedMessagePart = FindSubAgentActivityContainer(parts, activityGroupId);
		if (persistedMessagePart == null)
		{
			persistedMessagePart = new PersistedMessagePart
			{
				Type = "data-subagent-activity",
				Data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
			};
			parts.Add(persistedMessagePart);
		}
		if (persistedMessagePart.Data == null)
		{
			persistedMessagePart.Data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		}
		SetIfNotBlank(persistedMessagePart.Data, "groupId", activityGroupId);
		SetIfNotBlank(persistedMessagePart.Data, "title", activityGroupTitle);
		List<object> list = EnsureObjectList(persistedMessagePart.Data, "items");
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
		{
			["activityId"] = activityId,
			["agentName"] = "Sub agent",
			["title"] = "Sub agent",
			["status"] = "running",
			["updatedAt"] = DateTimeOffset.Now.ToString("O")
		};
		SetIfNotBlank(dictionary2, "activityGroupId", activityGroupId);
		SetIfNotBlank(dictionary2, "activityGroupTitle", activityGroupTitle);
		list.Add(dictionary2);
		return dictionary2;
	}

	private static PersistedMessagePart FindSubAgentActivityContainer(List<PersistedMessagePart> parts, string activityGroupId)
	{
		if (!string.IsNullOrWhiteSpace(activityGroupId))
		{
			PersistedMessagePart persistedMessagePart = parts.FirstOrDefault((PersistedMessagePart item) => string.Equals(item.Type, "data-subagent-activity", StringComparison.Ordinal) && item.Data != null && string.Equals(GetString(item.Data, "groupId"), activityGroupId, StringComparison.Ordinal));
			if (persistedMessagePart != null)
			{
				return persistedMessagePart;
			}
		}
		if (string.IsNullOrWhiteSpace(activityGroupId))
		{
			return parts.LastOrDefault((PersistedMessagePart item) => string.Equals(item.Type, "data-subagent-activity", StringComparison.Ordinal));
		}
		return null;
	}

	private static IDictionary<string, object> EnsureSubAgentToolCall(IDictionary<string, object> activity, string toolCallId)
	{
		List<object> list = EnsureObjectList(activity, "toolCalls");
		foreach (object item in list)
		{
			if (item is IDictionary<string, object> dictionary && string.Equals(GetString(dictionary, "toolCallId"), toolCallId, StringComparison.Ordinal))
			{
				return dictionary;
			}
		}
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
		{
			["type"] = "tool-call",
			["toolCallId"] = toolCallId,
			["toolName"] = "tool",
			["args"] = new Dictionary<string, object>(),
			["argsText"] = string.Empty
		};
		list.Add(dictionary2);
		return dictionary2;
	}

	private static List<object> EnsureObjectList(IDictionary<string, object> data, string key)
	{
		if (data.TryGetValue(key, out var value) && value is List<object> result)
		{
			return result;
		}
		return (List<object>)(data[key] = new List<object>());
	}

	private static void SetIfNotBlank(IDictionary<string, object> data, string key, string value)
	{
		if (!string.IsNullOrWhiteSpace(value))
		{
			data[key] = value;
		}
	}

	private static void AppendIfNotEmpty(IDictionary<string, object> data, string key, string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			data[key] = (GetString(data, key) ?? string.Empty) + value;
		}
	}

	private static string GetString(IDictionary<string, object> data, string key)
	{
		if (data == null || !data.TryGetValue(key, out var value))
		{
			return null;
		}
		object obj = value as string;
		if (obj == null)
		{
			if (value == null)
			{
				return null;
			}
			obj = value.ToString();
		}
		return (string)obj;
	}

	private static List<JsonElement> BuildPersistedContentParts(List<PersistedMessagePart> parts, object syncRoot)
	{
		List<JsonElement> list = new List<JsonElement>();
		if (parts == null)
		{
			return list;
		}
		List<PersistedMessagePart> list2;
		lock (syncRoot ?? parts)
		{
			list2 = parts.Select(ClonePersistedMessagePart).ToList();
		}
		foreach (PersistedMessagePart item in list2)
		{
			if (item == null)
			{
				continue;
			}
			if (string.Equals(item.Type, "text", StringComparison.Ordinal))
			{
				if (!string.IsNullOrEmpty(item.Text))
				{
					list.Add(ToJsonElement(new
					{
						type = "text",
						text = item.Text
					}));
				}
			}
			else if (string.Equals(item.Type, "tool-call", StringComparison.Ordinal))
			{
				list.Add(ToJsonElement(new
				{
					type = "tool-call",
					toolCallId = (item.ToolCallId ?? string.Empty),
					toolName = (item.ToolName ?? "tool"),
					args = (item.Args ?? new Dictionary<string, object>()),
					argsText = (item.ArgsText ?? string.Empty),
					result = item.Result
				}));
			}
			else if (string.Equals(item.Type, "data-subagent-activity", StringComparison.Ordinal))
			{
				list.Add(ToJsonElement(new
				{
					type = "data-subagent-activity",
					data = (item.Data ?? new Dictionary<string, object>())
				}));
			}
			else if (string.Equals(item.Type, "data-user-interrupt", StringComparison.Ordinal))
			{
				list.Add(ToJsonElement(new
				{
					type = "data-user-interrupt",
					data = (item.Data ?? new Dictionary<string, object>())
				}));
			}
			else if (string.Equals(item.Type, "data-approval", StringComparison.Ordinal))
			{
				list.Add(ToJsonElement(new
				{
					type = "data-approval",
					data = new
					{
						requestId = (item.RequestId ?? string.Empty),
						threadId = (item.ThreadId ?? string.Empty),
						title = (item.Title ?? string.Empty),
						message = (item.Message ?? string.Empty),
						toolName = (item.ToolName ?? string.Empty),
						argsPreview = (item.ArgsPreview ?? string.Empty),
						riskLevel = (item.RiskLevel ?? "medium"),
						confirmLabel = (item.ConfirmLabel ?? "Continue"),
						cancelLabel = (item.CancelLabel ?? "Cancel"),
						approvalMode = item.ApprovalMode,
						autoApproved = item.AutoApproved,
						status = (item.Status ?? "pending"),
						resolvedAt = item.ResolvedAt,
						errorMessage = item.ErrorMessage
					}
				}));
			}
		}
		return list;
	}

	private static PersistedMessagePart ClonePersistedMessagePart(PersistedMessagePart part)
	{
		if (part == null)
		{
			return null;
		}
		return new PersistedMessagePart
		{
			Type = part.Type,
			Text = part.Text,
			ToolCallId = part.ToolCallId,
			ToolName = part.ToolName,
			Args = ((part.Args != null) ? new Dictionary<string, object>(part.Args, StringComparer.OrdinalIgnoreCase) : null),
			ArgsText = part.ArgsText,
			Result = part.Result,
			Data = CloneData(part.Data),
			RequestId = part.RequestId,
			ThreadId = part.ThreadId,
			Title = part.Title,
			Message = part.Message,
			ArgsPreview = part.ArgsPreview,
			RiskLevel = part.RiskLevel,
			ConfirmLabel = part.ConfirmLabel,
			CancelLabel = part.CancelLabel,
			ApprovalMode = part.ApprovalMode,
			AutoApproved = part.AutoApproved,
			Status = part.Status,
			ResolvedAt = part.ResolvedAt,
			ErrorMessage = part.ErrorMessage
		};
	}

	private static IDictionary<string, object> CloneData(IDictionary<string, object> data)
	{
		if (data == null)
		{
			return null;
		}
		try
		{
			return JsonSerializer.Deserialize<Dictionary<string, object>>(JsonSerializer.Serialize(data, ReadableJsonOptions), ReadableJsonOptions);
		}
		catch
		{
			return new Dictionary<string, object>(data, StringComparer.OrdinalIgnoreCase);
		}
	}

	private static string BuildCanceledAssistantContext(JsonSessionIndexManager.SessionMessageDto assistant, out bool hasToolSummary)
	{
		hasToolSummary = false;
		if (assistant == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		string text = (assistant.Text ?? string.Empty).Trim();
		if (!string.IsNullOrWhiteSpace(text))
		{
			stringBuilder.AppendLine(text);
		}
		foreach (JsonElement item in assistant.Parts ?? new List<JsonElement>())
		{
			if (!TryGetStringProperty(item, "type", out var value))
			{
				continue;
			}
			if (string.Equals(value, "text", StringComparison.OrdinalIgnoreCase))
			{
				if (TryGetStringProperty(item, "text", out var value2) && !string.IsNullOrWhiteSpace(value2) && !text.Contains(value2))
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.AppendLine(value2.Trim());
				}
			}
			else if (string.Equals(value, "tool-call", StringComparison.OrdinalIgnoreCase))
			{
				hasToolSummary = true;
				TryGetStringProperty(item, "toolName", out var value3);
				TryGetStringProperty(item, "argsText", out var value4);
				TryGetStringProperty(item, "result", out var value5);
				if (stringBuilder.Length > 0)
				{
					stringBuilder.AppendLine();
				}
				stringBuilder.Append("[Tool call] ");
				stringBuilder.AppendLine(string.IsNullOrWhiteSpace(value3) ? "tool" : value3.Trim());
				if (!string.IsNullOrWhiteSpace(value4))
				{
					stringBuilder.Append("Args: ");
					stringBuilder.AppendLine(TruncateForRecovery(value4.Trim(), 600));
				}
				if (!string.IsNullOrWhiteSpace(value5))
				{
					stringBuilder.Append("Result: ");
					stringBuilder.AppendLine(TruncateForRecovery(value5.Trim(), 600));
				}
			}
			else
			{
				if (!string.Equals(value, "data-approval", StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				hasToolSummary = true;
				if (item.TryGetProperty("data", out var value6))
				{
					TryGetStringProperty(value6, "toolName", out var value7);
					TryGetStringProperty(value6, "title", out var value8);
					TryGetStringProperty(value6, "status", out var value9);
					if (stringBuilder.Length > 0)
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.Append("[Approval] ");
					stringBuilder.Append(string.IsNullOrWhiteSpace(value7) ? "tool" : value7.Trim());
					if (!string.IsNullOrWhiteSpace(value9))
					{
						stringBuilder.Append(" status=");
						stringBuilder.Append(value9.Trim());
					}
					if (!string.IsNullOrWhiteSpace(value8))
					{
						stringBuilder.Append(" title=");
						stringBuilder.Append(value8.Trim());
					}
					stringBuilder.AppendLine();
				}
			}
		}
		return stringBuilder.ToString().Trim();
	}

	private static bool TryGetStringProperty(JsonElement element, string propertyName, out string value)
	{
		value = null;
		if (element.ValueKind != JsonValueKind.Object || !element.TryGetProperty(propertyName, out var value2) || value2.ValueKind == JsonValueKind.Null || value2.ValueKind == JsonValueKind.Undefined)
		{
			return false;
		}
		value = ((value2.ValueKind == JsonValueKind.String) ? value2.GetString() : value2.GetRawText());
		return true;
	}

	private static string TruncateForRecovery(string value, int maxLength)
	{
		if (string.IsNullOrEmpty(value) || maxLength <= 0)
		{
			return string.Empty;
		}
		if (value.Length > maxLength)
		{
			return value.Substring(0, maxLength) + "…";
		}
		return value;
	}

	private static JsonElement ToJsonElement(object value)
	{
		using JsonDocument jsonDocument = JsonDocument.Parse(JsonSerializer.Serialize(value, ReadableJsonOptions));
		return jsonDocument.RootElement.Clone();
	}

	private static string NormalizeFinishReason(string finishReason)
	{
		if (string.IsNullOrWhiteSpace(finishReason))
		{
			return null;
		}
		string text = finishReason.Trim();
		if (!string.Equals(text, "cancel", StringComparison.OrdinalIgnoreCase) && !string.Equals(text, "error", StringComparison.OrdinalIgnoreCase) && !string.Equals(text, "stop", StringComparison.OrdinalIgnoreCase))
		{
			return text;
		}
		return text.ToLowerInvariant();
	}
}
