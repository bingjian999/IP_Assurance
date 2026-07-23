using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class DynamicToolCatalogTools
{
	public sealed class ToolRequestResult
	{
		public bool Success { get; set; }

		public string Message { get; set; }

		public int LoadedCount { get; set; }

		public int SkippedCount { get; set; }

		public string Scope { get; set; }

		public string[] Retained { get; set; }

		public string[] NotFound { get; set; }
	}

	private const int RetainedTurnsIncludingCurrentRunFinalization = 4;

	private readonly ToolAggregator _toolAggregator;

	private readonly SessionToolState _sessionToolState;

	private readonly AgentSession _session;

	private readonly string _sessionId;

	internal DynamicToolCatalogTools(ToolAggregator toolAggregator, SessionToolState sessionToolState, AgentSession session, string sessionId = null)
	{
		_toolAggregator = toolAggregator ?? throw new ArgumentNullException("toolAggregator");
		_sessionToolState = sessionToolState ?? throw new ArgumentNullException("sessionToolState");
		_session = session;
		_sessionId = sessionId ?? string.Empty;
	}

	internal IList<AITool> CreateTools()
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
		return new List<AITool>
		{
			Create("ListTools", "list_tools", flags),
			Create("RequestTools", "request_tools", flags)
		};
	}

	private AITool Create(string methodName, string toolName, BindingFlags flags)
	{
		return AIFunctionFactory.Create(GetType().GetMethod(methodName, flags), this, new AIFunctionFactoryOptions
		{
			Name = toolName
		});
	}

	[Description("List lightweight tool metadata (name, groups, description) without loading parameter schemas. Use this when deciding which tool or group to request.")]
	private IReadOnlyList<ToolMetadata> ListTools()
	{
		return _toolAggregator.GetToolMetadata();
	}

	[Description("Register real tool schemas by tool name or host-defined group. The tools become available on the next model step in this same agent run.")]
	private ToolRequestResult RequestTools([Description("Tool names to load. Optional.")] string[] names = null, [Description("Host-defined tool groups to load, for example [\"read\"] or [\"write\"]. Optional.")] string[] groups = null)
	{
		List<string> notFound;
		IList<AITool> list = _toolAggregator.ResolveTools(names, groups, out notFound);
		if (list.Count == 0 && IsMcpRequest(names, groups))
		{
			McpWarmupStatus mcpWarmupStatus = _toolAggregator.GetMcpWarmupStatus();
			if (string.Equals(mcpWarmupStatus.State, "loading", StringComparison.OrdinalIgnoreCase))
			{
				return new ToolRequestResult
				{
					Success = false,
					Message = "MCP 工具仍在连接中，请稍后重试。",
					LoadedCount = 0,
					SkippedCount = 0,
					Scope = "current_turn",
					Retained = Array.Empty<string>(),
					NotFound = BuildRequestedMcpIds(names, groups)
				};
			}
			if (string.Equals(mcpWarmupStatus.State, "error", StringComparison.OrdinalIgnoreCase) || string.Equals(mcpWarmupStatus.State, "partial", StringComparison.OrdinalIgnoreCase))
			{
				return new ToolRequestResult
				{
					Success = false,
					Message = "MCP 工具目录当前不可用：" + mcpWarmupStatus.Message,
					LoadedCount = 0,
					SkippedCount = 0,
					Scope = "current_turn",
					Retained = Array.Empty<string>(),
					NotFound = BuildRequestedMcpIds(names, groups)
				};
			}
		}
		List<string> list2 = (from tool in list.OfType<AIFunction>()
			select tool.Name into name
			where !string.IsNullOrWhiteSpace(name)
			select name).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
		HashSet<string> availableBeforeAppend = GetCurrentInvocationToolNames();
		List<string> list3 = list2.Where((string name) => !availableBeforeAppend.Contains(name)).ToList();
		List<string> list4 = list2.Where((string name) => availableBeforeAppend.Contains(name)).ToList();
		List<string> list5 = ResolveRetainableToolNames(list2);
		if (list5.Count > 0)
		{
			_sessionToolState.RememberRetainedTools(_session, _sessionId, list5, 4);
		}
		AppendToolsToCurrentInvocation(list);
		if (list3.Count > 0)
		{
			_sessionToolState.RememberTurnTools(_session, _sessionId, list3);
		}
		ModelContextDebugLogger.LogToolRequest(_sessionId, names, groups, list3, list4, notFound, list, list5);
		return new ToolRequestResult
		{
			Success = true,
			Message = $"Tools registered for this turn and next model step. Loaded {list3.Count}, already available {list4.Count}, retained {list5.Count}.",
			LoadedCount = list3.Count,
			SkippedCount = list4.Count,
			Scope = "current_turn",
			Retained = list5.ToArray(),
			NotFound = notFound.ToArray()
		};
	}

	private static bool IsMcpRequest(IEnumerable<string> names, IEnumerable<string> groups)
	{
		if (!(names ?? Array.Empty<string>()).Any((string name) => name?.Trim().StartsWith("mcp_", StringComparison.OrdinalIgnoreCase) ?? false))
		{
			return (groups ?? Array.Empty<string>()).Any((string group) => group?.Trim().StartsWith("mcp", StringComparison.OrdinalIgnoreCase) ?? false);
		}
		return true;
	}

	private static string[] BuildRequestedMcpIds(IEnumerable<string> names, IEnumerable<string> groups)
	{
		return (from value in (names ?? Array.Empty<string>()).Concat(groups ?? Array.Empty<string>())
			where !string.IsNullOrWhiteSpace(value)
			select value.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
	}

	private HashSet<string> GetCurrentInvocationToolNames()
	{
		return new HashSet<string>(from tool in (FunctionInvokingChatClient.CurrentContext?.Options?.Tools ?? Array.Empty<AITool>()).OfType<AIFunction>()
			select tool.Name into name
			where !string.IsNullOrWhiteSpace(name)
			select name, StringComparer.OrdinalIgnoreCase);
	}

	private List<string> ResolveRetainableToolNames(IEnumerable<string> toolNames)
	{
		HashSet<string> requested = new HashSet<string>(toolNames ?? Array.Empty<string>(), StringComparer.OrdinalIgnoreCase);
		return (from metadata in _toolAggregator.GetToolMetadata()
			where metadata != null && !string.IsNullOrWhiteSpace(metadata.Name) && requested.Contains(metadata.Name) && IsRetainableReadTool(metadata)
			select metadata.Name.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
	}

	private static bool IsRetainableReadTool(ToolMetadata metadata)
	{
		HashSet<string> hashSet = new HashSet<string>(metadata.Groups ?? Array.Empty<string>(), StringComparer.OrdinalIgnoreCase);
		if (hashSet.Contains("risk.confirm") || hashSet.Contains("risk.high") || hashSet.Contains("approval") || hashSet.Contains("write") || hashSet.Contains("excel.write") || hashSet.Contains("file.write"))
		{
			return false;
		}
		if (!hashSet.Contains("excel.read"))
		{
			if (hashSet.Contains("excel"))
			{
				return hashSet.Contains("read");
			}
			return false;
		}
		return true;
	}

	private static List<string> AppendToolsToCurrentInvocation(IEnumerable<AITool> tools)
	{
		List<AITool> source = (tools ?? Array.Empty<AITool>()).ToList();
		FunctionInvocationContext currentContext = FunctionInvokingChatClient.CurrentContext;
		if (currentContext?.Options != null)
		{
			return AddUniqueTools(currentContext.Options.Tools, delegate(IList<AITool> updated)
			{
				currentContext.Options.Tools = updated;
			}, source);
		}
		return new List<string>();
	}

	private static List<string> AddUniqueTools(IList<AITool> target, Action<IList<AITool>> setTarget, IEnumerable<AITool> source)
	{
		List<string> list = new List<string>();
		if (target == null)
		{
			target = new List<AITool>();
			setTarget(target);
		}
		HashSet<string> hashSet = new HashSet<string>(from tool in target.OfType<AIFunction>()
			select tool.Name into name
			where !string.IsNullOrWhiteSpace(name)
			select name, StringComparer.OrdinalIgnoreCase);
		foreach (AITool item in source ?? Array.Empty<AITool>())
		{
			string text = (item as AIFunction)?.Name;
			if (!string.IsNullOrWhiteSpace(text) && hashSet.Add(text))
			{
				target.Add(item);
				list.Add(text);
			}
		}
		return list;
	}
}
