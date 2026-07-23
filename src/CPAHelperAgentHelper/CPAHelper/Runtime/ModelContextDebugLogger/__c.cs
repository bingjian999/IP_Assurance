using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using CPAHelper.Agent.Abstractions;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal static class ModelContextDebugLogger
{
	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		WriteIndented = true,
		Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
	};

	public static void LogRunContext(string sessionId, AgentConfig config, string instructions, string userMessage, IEnumerable<AITool> tools, IEnumerable<string> loadedToolNames, IEnumerable<ToolMetadata> toolCatalog)
	{
		Write(new
		{
			eventName = "model_context",
			timestamp = DateTimeOffset.Now,
			sessionId = (sessionId ?? string.Empty),
			provider = config?.Provider,
			baseUrl = config?.BaseUrl,
			model = config?.Model,
			instructions = (instructions ?? string.Empty),
			userMessage = (userMessage ?? string.Empty),
			tools = GetToolNames(tools),
			sessionLoadedTools = (loadedToolNames ?? Array.Empty<string>()).OrderBy((string name) => name).ToArray(),
			toolCatalogCount = (toolCatalog ?? Array.Empty<ToolMetadata>()).Count(),
			note = "This is the context material CPAHelper passes into MAF. It may not be byte-for-byte identical to the provider HTTP payload."
		});
	}

	public static void LogToolRequest(string sessionId, IEnumerable<string> requestedNames, IEnumerable<string> requestedGroups, IEnumerable<string> loaded, IEnumerable<string> skipped, IEnumerable<string> notFound, IEnumerable<AITool> currentTools, IEnumerable<string> retained = null)
	{
		Write(new
		{
			eventName = "dynamic_tools_loaded",
			timestamp = DateTimeOffset.Now,
			sessionId = (sessionId ?? string.Empty),
			requestedNames = (requestedNames ?? Array.Empty<string>()),
			requestedGroups = (requestedGroups ?? Array.Empty<string>()),
			loaded = (loaded ?? Array.Empty<string>()),
			skipped = (skipped ?? Array.Empty<string>()),
			retained = (retained ?? Array.Empty<string>()),
			notFound = (notFound ?? Array.Empty<string>()),
			currentTools = GetToolNames(currentTools)
		});
	}

	private static string[] GetToolNames(IEnumerable<AITool> tools)
	{
		return (from tool in (tools ?? Array.Empty<AITool>()).OfType<AIFunction>()
			select tool.Name into name
			where !string.IsNullOrWhiteSpace(name)
			select name).OrderBy((string name) => name, StringComparer.OrdinalIgnoreCase).ToArray();
	}

	private static void Write(object payload)
	{
	}
}
