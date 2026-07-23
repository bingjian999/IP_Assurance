using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using CPAHelper.Agent.Abstractions;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

public sealed class ModelTraceFileSink : IModelTraceSink
{
	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		WriteIndented = false,
		Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
	};

	private readonly object _lock = new object();

	private readonly string _path;

	private readonly Func<AgentConfig> _configAccessor;

	private readonly Func<McpWarmupStatus> _mcpStatusAccessor;

	private readonly Func<IReadOnlyList<ToolMetadata>> _metadataAccessor;

	private readonly bool _writeFullConsole;

	public string Path => _path;

	public ModelTraceFileSink(string path, Func<AgentConfig> configAccessor, Func<McpWarmupStatus> mcpStatusAccessor, Func<IReadOnlyList<ToolMetadata>> metadataAccessor, bool writeFullConsole = false)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			throw new ArgumentException("Trace path is required.", "path");
		}
		_path = path;
		_configAccessor = configAccessor;
		_mcpStatusAccessor = mcpStatusAccessor;
		_metadataAccessor = metadataAccessor;
		_writeFullConsole = writeFullConsole;
		Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
	}

	public static ModelTraceFileSink CreateDevHost(string repoRoot, Func<AgentConfig> configAccessor, Func<McpWarmupStatus> mcpStatusAccessor, Func<IReadOnlyList<ToolMetadata>> metadataAccessor)
	{
		string path = System.IO.Path.Combine(System.IO.Path.Combine(repoRoot, ".dev", "model-traces"), $"model-trace-{Process.GetCurrentProcess().Id}.jsonl");
		bool writeFullConsole = string.Equals(Environment.GetEnvironmentVariable("CPAHELPER_DEV_TRACE_CONSOLE_FULL"), "1", StringComparison.Ordinal);
		return new ModelTraceFileSink(path, configAccessor, mcpStatusAccessor, metadataAccessor, writeFullConsole);
	}

	public ModelTraceRequest BeginRequest(string requestKind, IEnumerable<ChatMessage> messages, ChatOptions options)
	{
		ModelTraceRequest modelTraceRequest = new ModelTraceRequest(Guid.NewGuid().ToString("N"), DateTimeOffset.Now);
		List<ChatMessage> list = (messages ?? Array.Empty<ChatMessage>()).ToList();
		List<AITool> list2 = (options?.Tools ?? Array.Empty<AITool>()).ToList();
		AgentConfig agentConfig = SafeGet(_configAccessor);
		McpWarmupStatus mcpWarmupStatus = SafeGet(_mcpStatusAccessor);
		var payload = new
		{
			eventName = "request_start",
			timestamp = modelTraceRequest.StartedAt,
			requestId = modelTraceRequest.RequestId,
			requestKind = requestKind,
			turn = CreateTurnInfo(),
			provider = agentConfig?.Provider,
			baseUrl = agentConfig?.BaseUrl,
			model = ((!string.IsNullOrWhiteSpace(options?.ModelId)) ? options.ModelId : agentConfig?.Model),
			options = new
			{
				instructions = options?.Instructions,
				maxOutputTokens = options?.MaxOutputTokens,
				temperature = options?.Temperature,
				topP = options?.TopP,
				frequencyPenalty = options?.FrequencyPenalty,
				presencePenalty = options?.PresencePenalty
			},
			messageCount = list.Count,
			toolCount = list2.Count,
			mcpStatus = mcpWarmupStatus,
			messages = list.Select(DescribeMessage).ToList(),
			tools = DescribeTools(list2)
		};
		WriteEvent(payload);
		Console.WriteLine(string.Format("[ModelTrace] start request={0} session={1} messages={2} tools={3} mcp={4} file={5}", modelTraceRequest.RequestId, ModelTraceContext.Current?.SessionId ?? "", list.Count, list2.Count, mcpWarmupStatus?.State ?? "unknown", _path));
		return modelTraceRequest;
	}

	public void CompleteRequest(ModelTraceRequest request, object responseSummary)
	{
		if (request != null)
		{
			var payload = new
			{
				eventName = "request_end",
				timestamp = DateTimeOffset.Now,
				requestId = request.RequestId,
				elapsedMs = ElapsedMs(request),
				turn = CreateTurnInfo(),
				response = responseSummary
			};
			WriteEvent(payload);
			Console.WriteLine($"[ModelTrace] end request={request.RequestId} elapsedMs={ElapsedMs(request)} file={_path}");
		}
	}

	public void FailRequest(ModelTraceRequest request, Exception exception)
	{
		if (request != null)
		{
			var payload = new
			{
				eventName = "request_error",
				timestamp = DateTimeOffset.Now,
				requestId = request.RequestId,
				elapsedMs = ElapsedMs(request),
				turn = CreateTurnInfo(),
				error = new
				{
					type = exception?.GetType().FullName,
					message = exception?.Message,
					stackTrace = exception?.ToString()
				}
			};
			WriteEvent(payload);
			Console.WriteLine($"[ModelTrace] error request={request.RequestId} elapsedMs={ElapsedMs(request)} message={exception?.Message} file={_path}");
		}
	}

	private void WriteEvent(object payload)
	{
		try
		{
			string text = JsonSerializer.Serialize(payload, JsonOptions);
			lock (_lock)
			{
				File.AppendAllText(_path, text + Environment.NewLine, Encoding.UTF8);
			}
			if (_writeFullConsole)
			{
				Console.WriteLine("[ModelTrace.Json] " + text);
			}
		}
		catch (Exception)
		{
		}
	}

	private object CreateTurnInfo()
	{
		ModelTraceContext current = ModelTraceContext.Current;
		if (current == null)
		{
			return null;
		}
		return new { current.TurnId, current.SessionId, current.UserMessage, current.StartedAt };
	}

	private List<object> DescribeTools(IEnumerable<AITool> tools)
	{
		Dictionary<string, ToolMetadata> metadataByName = (SafeGet(_metadataAccessor) ?? Array.Empty<ToolMetadata>()).Where((ToolMetadata metadata) => !string.IsNullOrWhiteSpace(metadata?.Name)).GroupBy((ToolMetadata metadata) => metadata.Name, StringComparer.OrdinalIgnoreCase).ToDictionary((IGrouping<string, ToolMetadata> group) => group.Key, (IGrouping<string, ToolMetadata> group) => group.First(), StringComparer.OrdinalIgnoreCase);
		return (from tool in tools ?? Array.Empty<AITool>()
			select DescribeTool(tool, metadataByName) into tool
			where tool != null
			select tool).ToList();
	}

	private static object DescribeTool(AITool tool, IReadOnlyDictionary<string, ToolMetadata> metadataByName)
	{
		if (!(tool is AIFunction aIFunction))
		{
			return null;
		}
		metadataByName.TryGetValue(aIFunction.Name, out var value);
		string[] array = value?.Groups ?? Array.Empty<string>();
		return new
		{
			name = aIFunction.Name,
			description = aIFunction.Description,
			schema = ((aIFunction.JsonSchema.ValueKind == JsonValueKind.Undefined) ? null : JsonSerializer.Deserialize<object>(aIFunction.JsonSchema.GetRawText(), JsonOptions)),
			groups = array,
			isMcp = array.Any((string group) => string.Equals(group, "mcp", StringComparison.OrdinalIgnoreCase) || group.StartsWith("mcp.", StringComparison.OrdinalIgnoreCase)),
			requireApproval = array.Any((string group) => string.Equals(group, "risk.confirm", StringComparison.OrdinalIgnoreCase) || string.Equals(group, "risk.high", StringComparison.OrdinalIgnoreCase))
		};
	}

	private static object DescribeMessage(ChatMessage message)
	{
		if (message == null)
		{
			return null;
		}
		return new
		{
			role = message.Role.Value,
			text = message.Text,
			contents = (from content in (message.Contents ?? Array.Empty<AIContent>()).Select(DescribeContent)
				where content != null
				select content).ToList(),
			additionalProperties = DescribeAdditionalProperties(message.AdditionalProperties)
		};
	}

	private static object DescribeContent(AIContent content)
	{
		if (content == null)
		{
			return null;
		}
		if (content is TextContent textContent)
		{
			return new
			{
				type = content.GetType().Name,
				text = textContent.Text
			};
		}
		if (content is TextReasoningContent textReasoningContent)
		{
			return new
			{
				type = content.GetType().Name,
				text = textReasoningContent.Text
			};
		}
		if (content is FunctionCallContent functionCallContent)
		{
			return new
			{
				type = content.GetType().Name,
				CallId = functionCallContent.CallId,
				Name = functionCallContent.Name,
				arguments = functionCallContent.Arguments
			};
		}
		if (content is FunctionResultContent functionResultContent)
		{
			return new
			{
				type = content.GetType().Name,
				CallId = functionResultContent.CallId,
				result = SerializeUnknown(functionResultContent.Result),
				exception = functionResultContent.Exception?.ToString()
			};
		}
		if (content is DataContent dataContent)
		{
			return new
			{
				type = content.GetType().Name,
				Uri = dataContent.Uri,
				MediaType = dataContent.MediaType
			};
		}
		if (content is UriContent uriContent)
		{
			return new
			{
				type = content.GetType().Name,
				Uri = uriContent.Uri,
				MediaType = uriContent.MediaType
			};
		}
		return new
		{
			type = content.GetType().Name,
			text = content.ToString(),
			additionalProperties = DescribeAdditionalProperties(content.AdditionalProperties)
		};
	}

	private static object DescribeAdditionalProperties(AdditionalPropertiesDictionary properties)
	{
		if (properties == null || properties.Count == 0)
		{
			return null;
		}
		return properties.ToDictionary<KeyValuePair<string, object>, string, object>((KeyValuePair<string, object> item) => item.Key, (KeyValuePair<string, object> item) => SerializeUnknown(item.Value), StringComparer.OrdinalIgnoreCase);
	}

	private static object SerializeUnknown(object value)
	{
		if (value == null)
		{
			return null;
		}
		if (value is string || value is bool || value is int || value is long || value is double || value is decimal)
		{
			return value;
		}
		try
		{
			return JsonSerializer.Deserialize<object>(JsonSerializer.Serialize(value, JsonOptions), JsonOptions);
		}
		catch
		{
			return value.ToString();
		}
	}

	private static T SafeGet<T>(Func<T> accessor)
	{
		if (accessor == null)
		{
			return default(T);
		}
		try
		{
			return accessor();
		}
		catch
		{
			return default(T);
		}
	}

	private static long ElapsedMs(ModelTraceRequest request)
	{
		return (long)Math.Max(0.0, (DateTimeOffset.Now - request.StartedAt).TotalMilliseconds);
	}
}
