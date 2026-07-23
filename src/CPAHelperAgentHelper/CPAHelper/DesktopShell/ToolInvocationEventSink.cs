using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal static class ToolInvocationEventSink
{
	private static readonly JsonSerializerOptions ReadableIndentedJsonOptions = new JsonSerializerOptions
	{
		WriteIndented = true,
		Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
	};

	public static string Begin(string threadId, ref int toolCallCounter, StreamWriter writer, object syncRoot, List<PersistedMessagePart> parts, object partsSyncRoot, string toolName, IReadOnlyDictionary<string, object> args, string parentActivityId, Action<string, string> emitStatus)
	{
		if (writer == null || syncRoot == null)
		{
			return null;
		}
		string text = "tool-" + Interlocked.Increment(ref toolCallCounter);
		Dictionary<string, object> dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		if (args != null)
		{
			foreach (KeyValuePair<string, object> arg in args)
			{
				dictionary[arg.Key] = arg.Value;
			}
		}
		IDictionary<string, object> dictionary2 = ConvertArguments(dictionary);
		if (parts != null)
		{
			if (!string.IsNullOrWhiteSpace(parentActivityId))
			{
				ConversationPersistenceService.AppendSubAgentToolCallBegin(parts, partsSyncRoot, parentActivityId, text, toolName, dictionary2, (dictionary2 != null && dictionary2.Count > 0) ? JsonSerializer.Serialize(dictionary2, ReadableIndentedJsonOptions) : string.Empty);
			}
			else
			{
				ConversationPersistenceService.AppendToolCallPart(parts, partsSyncRoot, text, toolName, dictionary2, (dictionary2 != null && dictionary2.Count > 0) ? JsonSerializer.Serialize(dictionary2, ReadableIndentedJsonOptions) : string.Empty);
			}
		}
		if (string.IsNullOrWhiteSpace(parentActivityId))
		{
			emitStatus?.Invoke("tool", "Calling tool: " + toolName);
		}
		SseEventWriter.WriteSync(writer, syncRoot, new ToolCallBeginEvent
		{
			ToolCallId = text,
			ToolName = (toolName ?? "tool"),
			Args = (dictionary2 ?? new Dictionary<string, object>()),
			ParentActivityId = (string.IsNullOrWhiteSpace(parentActivityId) ? null : parentActivityId)
		});
		AgentRuntimeLogger.Info("Tool invocation started. ThreadId=" + threadId + "; ToolName=" + toolName + "; ToolCallId=" + text);
		return text;
	}

	public static void Complete(string threadId, StreamWriter writer, object syncRoot, List<PersistedMessagePart> parts, object partsSyncRoot, string invocationId, string toolName, object result, Exception exception, string parentActivityId, Action<string, string> emitStatus)
	{
		if (string.IsNullOrWhiteSpace(invocationId) || writer == null || syncRoot == null)
		{
			return;
		}
		string preview = ConversationPersistenceService.BuildToolResultPreview(result, exception);
		if (parts != null)
		{
			lock (partsSyncRoot ?? parts)
			{
				if (!string.IsNullOrWhiteSpace(parentActivityId))
				{
					ConversationPersistenceService.ApplySubAgentToolCallResult(parts, partsSyncRoot, parentActivityId, invocationId, toolName, preview);
				}
				else
				{
					ConversationPersistenceService.ApplyToolResult(parts, invocationId, toolName, preview);
				}
			}
		}
		if (string.IsNullOrWhiteSpace(parentActivityId))
		{
			emitStatus?.Invoke("summarizing", "Summarizing tool results.");
		}
		SseEventWriter.WriteSync(writer, syncRoot, new ToolCallResultEvent
		{
			ToolCallId = invocationId,
			ToolName = (toolName ?? "tool"),
			Preview = preview,
			ParentActivityId = (string.IsNullOrWhiteSpace(parentActivityId) ? null : parentActivityId)
		});
		AgentRuntimeLogger.Info($"Tool invocation completed. ThreadId={threadId}; ToolName={toolName}; ToolCallId={invocationId}; HasError={exception != null}");
	}

	private static IDictionary<string, object> ConvertArguments(IDictionary<string, object> args)
	{
		if (args == null || args.Count == 0)
		{
			return args;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>(args.Count);
		foreach (KeyValuePair<string, object> arg in args)
		{
			dictionary[arg.Key] = UnwrapValue(arg.Value);
		}
		return dictionary;
	}

	private static object UnwrapValue(object value)
	{
		if (value is JsonElement jsonElement)
		{
			switch (jsonElement.ValueKind)
			{
			case JsonValueKind.String:
				return jsonElement.GetString();
			case JsonValueKind.Number:
			{
				if (!jsonElement.TryGetInt64(out var value2))
				{
					return jsonElement.GetDouble();
				}
				return value2;
			}
			case JsonValueKind.True:
				return true;
			case JsonValueKind.False:
				return false;
			case JsonValueKind.Undefined:
			case JsonValueKind.Null:
				return null;
			case JsonValueKind.Array:
			{
				List<object> list = new List<object>();
				{
					foreach (JsonElement item in jsonElement.EnumerateArray())
					{
						list.Add(UnwrapValue(item));
					}
					return list;
				}
			}
			case JsonValueKind.Object:
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				{
					foreach (JsonProperty item2 in jsonElement.EnumerateObject())
					{
						dictionary[item2.Name] = UnwrapValue(item2.Value);
					}
					return dictionary;
				}
			}
			default:
				return jsonElement.GetRawText();
			}
		}
		return value;
	}
}
