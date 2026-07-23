using System;
using System.Collections.Generic;
using System.Linq;
using CPAHelper.Agent.Abstractions;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

public class ToolAggregator
{
	private sealed class ToolCatalogEntry
	{
		internal AITool RawTool { get; }

		internal AITool Tool { get; }

		internal ToolMetadata Metadata { get; }

		internal ToolCatalogEntry(AITool rawTool, AITool tool, ToolMetadata metadata)
		{
			RawTool = rawTool;
			Tool = tool;
			Metadata = metadata;
		}
	}

	private readonly IReadOnlyList<IToolProvider> _providers;

	private readonly object _catalogLock = new object();

	private Dictionary<string, ToolCatalogEntry> _catalog;

	public ToolAggregator(IEnumerable<IToolProvider> providers)
	{
		_providers = (providers ?? Enumerable.Empty<IToolProvider>()).Where((IToolProvider provider) => provider != null).ToList();
	}

	public IList<AITool> GetAllTools()
	{
		return GetCatalog().Values.Select((ToolCatalogEntry entry) => entry.Tool).ToList();
	}

	public IReadOnlyList<ToolMetadata> GetToolMetadata()
	{
		return GetCatalog().Values.Select((ToolCatalogEntry entry) => entry.Metadata).OrderBy((ToolMetadata metadata) => metadata.Name, StringComparer.OrdinalIgnoreCase).ToList();
	}

	public void RefreshCatalog()
	{
		lock (_catalogLock)
		{
			_catalog = null;
			foreach (McpToolProvider item in _providers.OfType<McpToolProvider>())
			{
				item.Refresh();
			}
		}
	}

	public McpWarmupStatus StartMcpWarmup()
	{
		List<McpToolProvider> list = _providers.OfType<McpToolProvider>().ToList();
		if (list.Count == 0)
		{
			return new McpWarmupStatus
			{
				State = "none",
				Message = "No MCP provider is registered."
			};
		}
		return MergeMcpStatuses(list.Select((McpToolProvider provider) => provider.StartWarmup(ClearCatalogCache)).ToList());
	}

	public McpWarmupStatus GetMcpWarmupStatus()
	{
		List<McpWarmupStatus> list = (from provider in _providers.OfType<McpToolProvider>()
			select provider.GetWarmupStatus()).ToList();
		if (list.Count != 0)
		{
			return MergeMcpStatuses(list);
		}
		return new McpWarmupStatus
		{
			State = "none",
			Message = "No MCP provider is registered."
		};
	}

	public IList<AITool> ResolveTools(IEnumerable<string> names, IEnumerable<string> groups, out List<string> notFound)
	{
		return ResolveTools(names, groups, null, out notFound);
	}

	public IList<AITool> ResolveTools(IEnumerable<string> names, IEnumerable<string> groups, IEnumerable<string> excludedGroups, out List<string> notFound)
	{
		Dictionary<string, ToolCatalogEntry> catalog = GetCatalog();
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		notFound = new List<string>();
		if (names != null)
		{
			foreach (string name in names)
			{
				string text = name?.Trim();
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (catalog.ContainsKey(text))
					{
						hashSet.Add(text);
					}
					else
					{
						notFound.Add(text);
					}
				}
			}
		}
		if (groups != null)
		{
			HashSet<string> hashSet = new HashSet<string>(from g in groups
				where !string.IsNullOrWhiteSpace(g)
				select g.Trim(), StringComparer.OrdinalIgnoreCase);
			if (hashSet.Count > 0)
			{
				foreach (ToolCatalogEntry value2 in catalog.Values)
				{
					if ((value2.Metadata.Groups ?? Array.Empty<string>()).Any(hashSet.Contains))
					{
						hashSet.Add(value2.Metadata.Name);
					}
				}
			}
		}
		HashSet<string> excludedGroupSet = BuildGroupSet(excludedGroups);
		if (excludedGroupSet.Count > 0)
		{
			hashSet.RemoveWhere((string name) => catalog.TryGetValue(name, out var value) && (value.Metadata.Groups ?? Array.Empty<string>()).Any(excludedGroupSet.Contains));
		}
		return (from name in hashSet.Where(catalog.ContainsKey)
			select catalog[name].Tool).ToList();
	}

	public IList<AITool> ResolveToolsByName(IEnumerable<string> names)
	{
		Dictionary<string, ToolCatalogEntry> catalog = GetCatalog();
		return (from name in names ?? Enumerable.Empty<string>()
			where !string.IsNullOrWhiteSpace(name) && catalog.ContainsKey(name.Trim())
			select catalog[name.Trim()].Tool).ToList();
	}

	public IList<AITool> ResolveRawToolsByName(IEnumerable<string> names)
	{
		Dictionary<string, ToolCatalogEntry> catalog = GetCatalog();
		return (from name in names ?? Enumerable.Empty<string>()
			where !string.IsNullOrWhiteSpace(name) && catalog.ContainsKey(name.Trim())
			select catalog[name.Trim()].RawTool).ToList();
	}

	public IList<AITool> ResolveDefaultTools()
	{
		return (from entry in GetCatalog().Values
			where entry.Metadata.IsDefault
			select entry.Tool).ToList();
	}

	public IReadOnlyList<string> GetProviderNames()
	{
		return _providers.Select((IToolProvider p) => p.ProviderName).ToList();
	}

	private static AITool WrapTool(AITool tool, ToolMetadata metadata)
	{
		if (!(tool is AIFunction aIFunction))
		{
			return tool;
		}
		AIFunction aIFunction2 = aIFunction;
		if (RequiresApproval(metadata) && !(aIFunction2 is ApprovalRequiredAIFunction))
		{
			aIFunction2 = new ApprovalRequiredAIFunction(aIFunction2);
		}
		return aIFunction2;
	}

	private Dictionary<string, ToolCatalogEntry> GetCatalog()
	{
		if (_catalog != null)
		{
			return _catalog;
		}
		lock (_catalogLock)
		{
			if (_catalog != null)
			{
				return _catalog;
			}
			Dictionary<string, ToolCatalogEntry> dictionary = new Dictionary<string, ToolCatalogEntry>(StringComparer.OrdinalIgnoreCase);
			foreach (IToolProvider provider in _providers)
			{
				IList<AITool> list = provider.GetTools() ?? new List<AITool>();
				Dictionary<string, ToolMetadata> dictionary2 = (provider.GetToolMetadata() ?? new List<ToolMetadata>()).Where((ToolMetadata item) => !string.IsNullOrWhiteSpace(item?.Name)).GroupBy((ToolMetadata item) => item.Name, StringComparer.OrdinalIgnoreCase).ToDictionary((IGrouping<string, ToolMetadata> group) => group.Key, (IGrouping<string, ToolMetadata> group) => group.First(), StringComparer.OrdinalIgnoreCase);
				foreach (AITool item in list)
				{
					string toolName = GetToolName(item);
					if (!string.IsNullOrWhiteSpace(toolName))
					{
						if (!dictionary2.TryGetValue(toolName, out var value))
						{
							value = new ToolMetadata(toolName, Array.Empty<string>(), item.Description);
						}
						ToolMetadata metadata = NormalizeMetadata(toolName, value);
						AITool tool = WrapTool(item, metadata);
						string toolName2 = GetToolName(tool);
						if (!string.IsNullOrWhiteSpace(toolName2))
						{
							dictionary[toolName2] = new ToolCatalogEntry(item, tool, metadata);
						}
					}
				}
			}
			_catalog = dictionary;
			return _catalog;
		}
	}

	private void ClearCatalogCache()
	{
		lock (_catalogLock)
		{
			_catalog = null;
		}
	}

	private static McpWarmupStatus MergeMcpStatuses(IReadOnlyList<McpWarmupStatus> statuses)
	{
		List<McpWarmupServerStatus> servers = statuses.Where((McpWarmupStatus status) => status?.Servers != null).SelectMany((McpWarmupStatus status) => status.Servers).ToList();
		int num = statuses.Sum((McpWarmupStatus status) => status?.EnabledServerCount ?? 0);
		int num2 = statuses.Sum((McpWarmupStatus status) => status?.LoadedServerCount ?? 0);
		int num3 = statuses.Sum((McpWarmupStatus status) => status?.FailedServerCount ?? 0);
		int num4 = statuses.Sum((McpWarmupStatus status) => status?.TotalToolCount ?? 0);
		List<string> source = (from status in statuses
			select status?.State into state
			where !string.IsNullOrWhiteSpace(state)
			select state).ToList();
		string text = ((num == 0) ? "none" : (source.Any((string item) => string.Equals(item, "loading", StringComparison.OrdinalIgnoreCase)) ? "loading" : ((num3 == 0) ? "ready" : ((num2 > 0) ? "partial" : "error"))));
		return new McpWarmupStatus
		{
			State = text,
			Message = text switch
			{
				"error" => $"MCP failed. {num3} server(s) failed.", 
				"partial" => $"MCP partially ready. {num2} server(s) loaded, {num3} failed.", 
				"ready" => $"MCP ready. {num4} tool(s) loaded.", 
				"loading" => "Connecting MCP servers and reading tool lists.", 
				_ => "No enabled MCP servers.", 
			},
			EnabledServerCount = num,
			LoadedServerCount = num2,
			FailedServerCount = num3,
			TotalToolCount = num4,
			Servers = servers
		};
	}

	private static string GetToolName(AITool tool)
	{
		return (tool as AIFunction)?.Name;
	}

	private static HashSet<string> BuildGroupSet(IEnumerable<string> groups)
	{
		return new HashSet<string>(from @group in groups ?? Array.Empty<string>()
			where !string.IsNullOrWhiteSpace(@group)
			select @group.Trim(), StringComparer.OrdinalIgnoreCase);
	}

	private static ToolMetadata NormalizeMetadata(string name, ToolMetadata metadata)
	{
		return new ToolMetadata(name, metadata.Groups ?? Array.Empty<string>(), metadata.Description, metadata.IsDefault);
	}

	private static bool RequiresApproval(ToolMetadata metadata)
	{
		if (metadata?.Groups != null)
		{
			return metadata.Groups.Any((string group) => string.Equals(group, "risk.confirm", StringComparison.OrdinalIgnoreCase) || string.Equals(group, "risk.high", StringComparison.OrdinalIgnoreCase));
		}
		return false;
	}
}
