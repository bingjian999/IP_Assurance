#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using Microsoft.Extensions.AI;
using ModelContextProtocol;
using ModelContextProtocol.Client;

namespace CPAHelper.Agent.Runtime;

public sealed class McpToolProvider : IToolProvider, IDisposable
{
	internal sealed class McpCatalogSnapshot : IDisposable
	{
		internal static readonly McpCatalogSnapshot Empty = new McpCatalogSnapshot(Array.Empty<McpServerSession>(), Array.Empty<AIFunction>(), Array.Empty<ToolMetadata>());

		internal IReadOnlyList<McpServerSession> Sessions { get; }

		internal IReadOnlyList<AIFunction> Tools { get; }

		internal IReadOnlyList<ToolMetadata> Metadata { get; }

		internal McpCatalogSnapshot(IReadOnlyList<McpServerSession> sessions, IReadOnlyList<AIFunction> tools, IReadOnlyList<ToolMetadata> metadata)
		{
			Sessions = sessions ?? Array.Empty<McpServerSession>();
			Tools = tools ?? Array.Empty<AIFunction>();
			Metadata = metadata ?? Array.Empty<ToolMetadata>();
		}

		public void Dispose()
		{
			foreach (McpServerSession session in Sessions)
			{
				session.Dispose();
			}
		}
	}

	internal sealed class McpServerSession : IDisposable
	{
		private McpClient Client { get; }

		internal IReadOnlyList<McpClientTool> Tools { get; }

		internal McpServerSession(McpClient client, IReadOnlyList<McpClientTool> tools)
		{
			Client = client;
			Tools = tools ?? Array.Empty<McpClientTool>();
		}

		public void Dispose()
		{
			try
			{
				Client?.DisposeAsync().AsTask().GetAwaiter()
					.GetResult();
			}
			catch
			{
			}
		}
	}

	private readonly object _sync = new object();

	private McpCatalogSnapshot _snapshot;

	private McpWarmupStatus _status;

	private Task _warmupTask;

	private int _generation;

	public string ProviderName => "mcp";

	public IList<AITool> GetTools()
	{
		return GetCurrentSnapshot().Tools.Cast<AITool>().ToList();
	}

	public IList<ToolMetadata> GetToolMetadata()
	{
		return GetCurrentSnapshot().Metadata.ToList();
	}

	public McpWarmupStatus StartWarmup(Action catalogChanged = null)
	{
		McpCatalogSnapshot mcpCatalogSnapshot = null;
		bool flag = false;
		McpWarmupStatus status;
		lock (_sync)
		{
			if (_warmupTask != null && !_warmupTask.IsCompleted)
			{
				return CloneStatus(GetStatusUnsafe());
			}
			McpSettings settings = McpSettingsStore.Read().Settings ?? new McpSettings();
			List<McpServerConfig> list = GetEnabledServers(settings).ToList();
			if (list.Count == 0)
			{
				mcpCatalogSnapshot = _snapshot;
				_snapshot = McpCatalogSnapshot.Empty;
				_status = CreateNoneStatus(settings);
				_warmupTask = null;
				_generation++;
				status = _status;
				flag = true;
			}
			else
			{
				mcpCatalogSnapshot = _snapshot;
				_snapshot = null;
				_status = CreateLoadingStatus(list);
				_generation++;
				int generation = _generation;
				_warmupTask = Task.Run(delegate
				{
					RunWarmup(settings, generation, catalogChanged);
				});
				status = _status;
				flag = true;
			}
		}
		mcpCatalogSnapshot?.Dispose();
		if (flag)
		{
			NotifyCatalogChanged(catalogChanged);
		}
		return CloneStatus(status);
	}

	public McpWarmupStatus GetWarmupStatus()
	{
		lock (_sync)
		{
			return CloneStatus(GetStatusUnsafe());
		}
	}

	public McpTestResult TestServer(McpServerConfig server)
	{
		McpServerConfig normalized = McpSettingsStore.NormalizeServerForTest(server);
		using McpServerSession mcpServerSession = Connect(normalized, CancellationToken.None);
		return new McpTestResult
		{
			Success = true,
			Tools = mcpServerSession.Tools.Select((McpClientTool tool) => new McpToolInfo
			{
				Name = tool.Name,
				RuntimeName = BuildToolName(normalized.Id, tool.Name),
				Description = tool.Description,
				Groups = BuildGroups(normalized).ToList(),
				RequireApproval = normalized.RequireApproval
			}).ToList()
		};
	}

	public McpServerToolsResult GetServerTools(string serverId)
	{
		McpServerConfig mcpServerConfig = (McpSettingsStore.Read().Settings.Servers ?? new List<McpServerConfig>()).FirstOrDefault((McpServerConfig item) => string.Equals(item?.Id, serverId, StringComparison.OrdinalIgnoreCase));
		if (mcpServerConfig == null)
		{
			return null;
		}
		if (!mcpServerConfig.Enabled)
		{
			return new McpServerToolsResult
			{
				Success = true,
				Enabled = false,
				ServerId = mcpServerConfig.Id,
				Message = "MCP server is disabled.",
				Tools = new List<McpToolInfo>()
			};
		}
		McpServerConfig normalized = McpSettingsStore.NormalizeServerForTest(mcpServerConfig);
		using McpServerSession mcpServerSession = Connect(normalized, CancellationToken.None);
		List<string> groups = BuildGroups(normalized).ToList();
		List<McpToolInfo> list = mcpServerSession.Tools.Select((McpClientTool tool) => new McpToolInfo
		{
			Name = tool.Name,
			RuntimeName = BuildToolName(normalized.Id, tool.Name),
			Description = tool.Description,
			Groups = groups,
			RequireApproval = normalized.RequireApproval
		}).ToList();
		return new McpServerToolsResult
		{
			Success = true,
			Enabled = true,
			ServerId = normalized.Id,
			Message = $"Connected. {list.Count} tool(s) found.",
			Tools = list
		};
	}

	public void Refresh()
	{
		McpCatalogSnapshot snapshot;
		lock (_sync)
		{
			snapshot = _snapshot;
			_snapshot = null;
			_status = null;
			_warmupTask = null;
			_generation++;
		}
		snapshot?.Dispose();
	}

	public void Dispose()
	{
		Refresh();
	}

	private McpCatalogSnapshot GetCurrentSnapshot()
	{
		lock (_sync)
		{
			return _snapshot ?? McpCatalogSnapshot.Empty;
		}
	}

	private void RunWarmup(McpSettings settings, int generation, Action catalogChanged)
	{
		McpWarmupBuildResult mcpWarmupBuildResult = BuildSnapshot(settings);
		McpCatalogSnapshot mcpCatalogSnapshot = null;
		bool flag = false;
		lock (_sync)
		{
			if (generation == _generation)
			{
				mcpCatalogSnapshot = _snapshot;
				_snapshot = mcpWarmupBuildResult.Snapshot;
				_status = mcpWarmupBuildResult.Status;
				_warmupTask = null;
				flag = true;
			}
		}
		if (flag)
		{
			mcpCatalogSnapshot?.Dispose();
			try
			{
				NotifyCatalogChanged(catalogChanged);
				return;
			}
			catch (Exception arg)
			{
				Trace.TraceError($"Failed to notify MCP catalog warmup completion: {arg}");
				return;
			}
		}
		mcpWarmupBuildResult.Snapshot.Dispose();
	}

	private static void NotifyCatalogChanged(Action catalogChanged)
	{
		try
		{
			catalogChanged?.Invoke();
		}
		catch (Exception arg)
		{
			Trace.TraceError($"Failed to notify MCP catalog change: {arg}");
		}
	}

	private static McpWarmupBuildResult BuildSnapshot(McpSettings settings)
	{
		List<McpServerSession> list = new List<McpServerSession>();
		List<AIFunction> list2 = new List<AIFunction>();
		List<ToolMetadata> list3 = new List<ToolMetadata>();
		List<McpWarmupServerStatus> list4 = new List<McpWarmupServerStatus>();
		foreach (McpServerConfig enabledServer in GetEnabledServers(settings))
		{
			try
			{
				McpServerConfig mcpServerConfig = McpSettingsStore.NormalizeServerForTest(enabledServer);
				McpServerSession mcpServerSession = Connect(mcpServerConfig, CancellationToken.None);
				list.Add(mcpServerSession);
				List<McpClientTool> list5 = mcpServerSession.Tools.ToList();
				foreach (McpClientTool item in list5)
				{
					string name = item.Name;
					string name2 = BuildToolName(mcpServerConfig.Id, name);
					McpClientTool mcpClientTool = item.WithName(name2);
					list2.Add(mcpClientTool);
					list3.Add(new ToolMetadata(name2, BuildGroups(mcpServerConfig), BuildDescription(mcpServerConfig, name, mcpClientTool.Description)));
				}
				list4.Add(new McpWarmupServerStatus
				{
					Id = mcpServerConfig.Id,
					Name = mcpServerConfig.Name,
					Enabled = true,
					State = "ready",
					ToolCount = list5.Count
				});
			}
			catch (Exception ex)
			{
				Trace.TraceError($"Failed to load MCP server '{enabledServer.Id}': {ex}");
				list4.Add(new McpWarmupServerStatus
				{
					Id = enabledServer.Id,
					Name = enabledServer.Name,
					Enabled = true,
					State = "error",
					ToolCount = 0,
					Error = ex.Message
				});
			}
		}
		return new McpWarmupBuildResult(new McpCatalogSnapshot(list, list2, list3), CreateCompletedStatus(list4));
	}

	private static IEnumerable<McpServerConfig> GetEnabledServers(McpSettings settings)
	{
		return (settings?.Servers ?? new List<McpServerConfig>()).Where((McpServerConfig server) => server?.Enabled ?? false);
	}

	private McpWarmupStatus GetStatusUnsafe()
	{
		if (_status != null)
		{
			return _status;
		}
		McpSettings settings = McpSettingsStore.Read().Settings ?? new McpSettings();
		List<McpServerConfig> list = GetEnabledServers(settings).ToList();
		if (list.Count != 0)
		{
			return CreateInitialLoadingStatus(list);
		}
		return CreateNoneStatus(settings);
	}

	private static McpWarmupStatus CreateNoneStatus(McpSettings settings)
	{
		return new McpWarmupStatus
		{
			State = "none",
			Message = "No enabled MCP servers.",
			EnabledServerCount = 0,
			LoadedServerCount = 0,
			FailedServerCount = 0,
			TotalToolCount = 0,
			Servers = (from server in settings?.Servers ?? new List<McpServerConfig>()
				where server != null
				select new McpWarmupServerStatus
				{
					Id = server.Id,
					Name = server.Name,
					Enabled = server.Enabled,
					State = (server.Enabled ? "pending" : "disabled"),
					ToolCount = 0
				}).ToList()
		};
	}

	private static McpWarmupStatus CreateInitialLoadingStatus(IReadOnlyList<McpServerConfig> servers)
	{
		return new McpWarmupStatus
		{
			State = "loading",
			Message = "MCP tools are not ready yet.",
			EnabledServerCount = servers.Count,
			LoadedServerCount = 0,
			FailedServerCount = 0,
			TotalToolCount = 0,
			Servers = servers.Select((McpServerConfig server) => new McpWarmupServerStatus
			{
				Id = server.Id,
				Name = server.Name,
				Enabled = true,
				State = "pending",
				ToolCount = 0
			}).ToList()
		};
	}

	private static McpWarmupStatus CreateLoadingStatus(IReadOnlyList<McpServerConfig> servers)
	{
		McpWarmupStatus mcpWarmupStatus = CreateInitialLoadingStatus(servers);
		mcpWarmupStatus.Message = "Connecting MCP servers and reading tool lists.";
		foreach (McpWarmupServerStatus server in mcpWarmupStatus.Servers)
		{
			server.State = "loading";
		}
		return mcpWarmupStatus;
	}

	private static McpWarmupStatus CreateCompletedStatus(IReadOnlyList<McpWarmupServerStatus> servers)
	{
		int count = servers.Count;
		int num = servers.Count((McpWarmupServerStatus server) => string.Equals(server.State, "ready", StringComparison.OrdinalIgnoreCase));
		int num2 = servers.Count((McpWarmupServerStatus server) => string.Equals(server.State, "error", StringComparison.OrdinalIgnoreCase));
		int num3 = servers.Sum((McpWarmupServerStatus server) => server.ToolCount);
		string text = ((count == 0) ? "none" : ((num2 == 0) ? "ready" : ((num > 0) ? "partial" : "error")));
		return new McpWarmupStatus
		{
			State = text,
			Message = text switch
			{
				"error" => $"MCP failed. {num2} server(s) failed.", 
				"partial" => $"MCP partially ready. {num} server(s) loaded, {num2} failed.", 
				"ready" => $"MCP ready. {num3} tool(s) loaded.", 
				_ => "No enabled MCP servers.", 
			},
			EnabledServerCount = count,
			LoadedServerCount = num,
			FailedServerCount = num2,
			TotalToolCount = num3,
			Servers = servers.Select(CloneServerStatus).ToList()
		};
	}

	private static bool IsLoadedState(string state)
	{
		if (!string.Equals(state, "ready", StringComparison.OrdinalIgnoreCase) && !string.Equals(state, "partial", StringComparison.OrdinalIgnoreCase) && !string.Equals(state, "error", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(state, "none", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static McpWarmupStatus CloneStatus(McpWarmupStatus status)
	{
		if (status == null)
		{
			return new McpWarmupStatus
			{
				State = "none",
				Message = "No enabled MCP servers."
			};
		}
		return new McpWarmupStatus
		{
			State = status.State,
			Message = status.Message,
			EnabledServerCount = status.EnabledServerCount,
			LoadedServerCount = status.LoadedServerCount,
			FailedServerCount = status.FailedServerCount,
			TotalToolCount = status.TotalToolCount,
			Servers = (status.Servers ?? new List<McpWarmupServerStatus>()).Select(CloneServerStatus).ToList()
		};
	}

	private static McpWarmupServerStatus CloneServerStatus(McpWarmupServerStatus status)
	{
		return new McpWarmupServerStatus
		{
			Id = status?.Id,
			Name = status?.Name,
			Enabled = (status?.Enabled ?? false),
			State = status?.State,
			ToolCount = (status?.ToolCount ?? 0),
			Error = status?.Error
		};
	}

	private static McpServerSession Connect(McpServerConfig server, CancellationToken cancellationToken)
	{
		McpClient result = McpClient.CreateAsync(new StdioClientTransport(new StdioClientTransportOptions
		{
			Name = (server.Name ?? server.Id),
			Command = server.Command,
			Arguments = (server.Args ?? new List<string>()),
			WorkingDirectory = server.WorkingDirectory,
			EnvironmentVariables = (server.Env ?? new Dictionary<string, string>(StringComparer.Ordinal))
		}), null, null, cancellationToken).GetAwaiter().GetResult();
		List<McpClientTool> tools = result.ListToolsAsync((RequestOptions?)null, cancellationToken).GetAwaiter().GetResult()
			.ToList();
		return new McpServerSession(result, tools);
	}

	private static string BuildToolName(string serverId, string toolName)
	{
		return "mcp_" + SanitizeName(serverId) + "_" + SanitizeName(toolName);
	}

	private static string SanitizeName(string value)
	{
		string text = new string((value ?? string.Empty).Select((char ch) => (!char.IsLetterOrDigit(ch) && ch != '_') ? '_' : ch).ToArray()).Trim('_');
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return "tool";
	}

	private static string[] BuildGroups(McpServerConfig server)
	{
		List<string> list = new List<string>
		{
			"mcp",
			"mcp." + server.Id
		};
		if (server.Groups != null)
		{
			list.AddRange(server.Groups);
		}
		if (server.RequireApproval)
		{
			list.Add("risk.confirm");
		}
		return (from @group in list
			where !string.IsNullOrWhiteSpace(@group)
			select @group.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
	}

	private static string BuildDescription(McpServerConfig server, string originalName, string description)
	{
		string text = "MCP " + (server.Name ?? server.Id) + "/" + originalName;
		if (!string.IsNullOrWhiteSpace(description))
		{
			return text + ": " + description;
		}
		return text;
	}
}
