using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Contracts;
using CPAHelper.Agent.Runtime;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class BridgeCatalogEndpoints
{
	private readonly AgentRuntime _agentRuntime;

	private readonly IHostActionProvider _hostActionProvider;

	private readonly JsonSerializerOptions _jsonOptions;

	private readonly SkillMarketInstaller _skillMarketInstaller = new SkillMarketInstaller();

	private readonly SkillUninstaller _skillUninstaller = new SkillUninstaller();

	private readonly ISkillMarketClient _skillMarketClient;

	private readonly string _skillInstallToken = CreateToken();

	public BridgeCatalogEndpoints(AgentRuntime agentRuntime, IHostActionProvider hostActionProvider, JsonSerializerOptions jsonOptions, ISkillMarketClient skillMarketClient = null)
	{
		_agentRuntime = agentRuntime ?? throw new ArgumentNullException("agentRuntime");
		_hostActionProvider = hostActionProvider;
		_jsonOptions = jsonOptions ?? throw new ArgumentNullException("jsonOptions");
		_skillMarketClient = skillMarketClient ?? new SkillMarketClient();
	}

	public async Task HandleHealth(HttpListenerResponse response)
	{
		await BridgeResponseWriter.WriteJsonAsync(response, new
		{
			status = "ready",
			version = "1.0.0"
		}, _jsonOptions);
	}

	public async Task HandleHostStatus(HttpListenerResponse response)
	{
		await BridgeResponseWriter.WriteJsonAsync(response, new HostStatusResponse
		{
			Items = new List<HostStatusItem>()
		}, _jsonOptions);
	}

	public async Task HandleListHostActions(HttpListenerResponse response)
	{
		if (_hostActionProvider == null)
		{
			await BridgeResponseWriter.WriteJsonAsync(response, new HostActionsResponse(), _jsonOptions);
			return;
		}
		IReadOnlyList<HostActionInfo> source = (await _hostActionProvider.GetActionsAsync().ConfigureAwait(continueOnCapturedContext: false)) ?? Array.Empty<HostActionInfo>();
		await BridgeResponseWriter.WriteJsonAsync(response, new HostActionsResponse
		{
			Actions = source.Where((HostActionInfo action) => action != null && !string.IsNullOrWhiteSpace(action.Id)).ToList()
		}, _jsonOptions);
	}

	public async Task HandleInvokeHostAction(HttpListenerRequest request, HttpListenerResponse response, string actionId)
	{
		if (_hostActionProvider == null)
		{
			await WriteJsonError(response, 404, "The current host does not expose reference actions.");
			return;
		}
		string text;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			text = await reader.ReadToEndAsync();
		}
		HostActionInvokeRequest hostActionInvokeRequest = null;
		if (!string.IsNullOrWhiteSpace(text))
		{
			try
			{
				hostActionInvokeRequest = JsonSerializer.Deserialize<HostActionInvokeRequest>(text, _jsonOptions);
			}
			catch (Exception ex)
			{
				await WriteJsonError(response, 400, "Invalid request payload: " + ex.Message);
				return;
			}
		}
		HostContextItem hostContextItem = await _hostActionProvider.InvokeAsync(actionId, hostActionInvokeRequest ?? new HostActionInvokeRequest()).ConfigureAwait(continueOnCapturedContext: false);
		if (hostContextItem == null)
		{
			await WriteJsonError(response, 404, "The host action did not return reference content.");
		}
		else
		{
			await BridgeResponseWriter.WriteJsonAsync(response, hostContextItem, _jsonOptions);
		}
	}

	public async Task HandleListSkills(HttpListenerResponse response)
	{
		string text = AgentRuntime.ResolveSkillsPath();
		if (string.IsNullOrWhiteSpace(text))
		{
			await BridgeResponseWriter.WriteJsonAsync(response, new SkillsResponse
			{
				Skills = new List<SkillInfo>(),
				Error = "Skills directory was not found (.agent/skills or .claude/skills)."
			}, _jsonOptions);
			return;
		}
		List<SkillInfo> skills;
		try
		{
			skills = SkillCatalogReader.ListSkills(text);
		}
		catch (Exception ex)
		{
			AgentRuntimeLogger.Error("Failed to list skills: " + text, ex);
			await BridgeResponseWriter.WriteJsonAsync(response, new SkillsResponse
			{
				Path = text,
				Skills = new List<SkillInfo>(),
				Error = "Failed to read skills directory: " + ex.Message
			}, _jsonOptions);
			return;
		}
		await BridgeResponseWriter.WriteJsonAsync(response, new SkillsResponse
		{
			Path = text,
			Skills = skills
		}, _jsonOptions);
	}

	public async Task HandleSkillInstallSession(HttpListenerResponse response)
	{
		await BridgeResponseWriter.WriteJsonAsync(response, new SkillInstallSessionResponse
		{
			Token = _skillInstallToken
		}, _jsonOptions);
	}

	public async Task HandleListSkillMarket(HttpListenerRequest request, HttpListenerResponse response)
	{
		SkillMarketQuery query = new SkillMarketQuery
		{
			Search = GetQueryValue(request, "search"),
			Page = ParsePositiveInt(GetQueryValue(request, "page"), 1),
			PageSize = ParsePositiveInt(GetQueryValue(request, "pageSize"), 12),
			Sort = GetQueryValue(request, "sort")
		};
		try
		{
			await BridgeResponseWriter.WriteJsonAsync(response, await _skillMarketClient.ListAsync(query).ConfigureAwait(continueOnCapturedContext: false), _jsonOptions);
		}
		catch (Exception ex)
		{
			AgentRuntimeLogger.Error("Failed to fetch skill market catalog.", ex);
			await WriteJsonError(response, 502, "Failed to fetch skill market catalog: " + ex.Message);
		}
	}

	public async Task HandleInstallSkill(HttpListenerRequest request, HttpListenerResponse response)
	{
		if (!IsAllowedSkillInstallOrigin(request.Headers["Origin"]))
		{
			await WriteJsonError(response, 403, "Skill 安装来源不受信任，请从 CPAHelper 的 Skill 管理页重试。");
			return;
		}
		if (!string.Equals(request.Headers["X-CPAHelper-Bridge-Token"], _skillInstallToken, StringComparison.Ordinal))
		{
			await WriteJsonError(response, 403, "Skill 安装授权失效，请刷新 Skill 管理页后重试。");
			return;
		}
		string json;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			json = await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		SkillInstallRequest installRequest;
		try
		{
			installRequest = JsonSerializer.Deserialize<SkillInstallRequest>(json, _jsonOptions);
		}
		catch (Exception ex)
		{
			await WriteJsonError(response, 400, "Invalid skill install payload: " + ex.Message);
			return;
		}
		try
		{
			await BridgeResponseWriter.WriteJsonAsync(response, await _skillMarketInstaller.InstallAsync(installRequest).ConfigureAwait(continueOnCapturedContext: false), _jsonOptions);
		}
		catch (Exception ex2)
		{
			AgentRuntimeLogger.Error("Skill install failed.", ex2);
			await WriteJsonError(response, 400, ex2.Message);
		}
	}

	public async Task HandleUninstallSkill(HttpListenerRequest request, HttpListenerResponse response)
	{
		string json;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			json = await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		SkillUninstallRequest uninstallRequest;
		try
		{
			uninstallRequest = JsonSerializer.Deserialize<SkillUninstallRequest>(json, _jsonOptions);
		}
		catch (Exception ex)
		{
			await WriteJsonError(response, 400, "Invalid skill uninstall payload: " + ex.Message);
			return;
		}
		try
		{
			SkillUninstallResponse value = _skillUninstaller.Uninstall(uninstallRequest);
			await BridgeResponseWriter.WriteJsonAsync(response, value, _jsonOptions);
		}
		catch (Exception ex2)
		{
			AgentRuntimeLogger.Error("Skill uninstall failed.", ex2);
			await WriteJsonError(response, 400, ex2.Message);
		}
	}

	public async Task HandleGetAgentsFile(HttpListenerResponse response)
	{
		try
		{
			AgentsFileSnapshot agentsFileSnapshot = AgentsFileStore.Read();
			await BridgeResponseWriter.WriteJsonAsync(response, new AgentsFileResponse
			{
				Path = agentsFileSnapshot.Path,
				Content = agentsFileSnapshot.Content
			}, _jsonOptions);
		}
		catch (Exception ex)
		{
			AgentRuntimeLogger.Error("Failed to read AGENTS.md.", ex);
			await WriteJsonError(response, 500, "Failed to read AGENTS.md: " + ex.Message);
		}
	}

	public async Task HandleSaveAgentsFile(HttpListenerRequest request, HttpListenerResponse response)
	{
		string text;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			text = await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		AgentsFileSaveRequest saveRequest;
		try
		{
			saveRequest = (string.IsNullOrWhiteSpace(text) ? new AgentsFileSaveRequest() : JsonSerializer.Deserialize<AgentsFileSaveRequest>(text, _jsonOptions));
		}
		catch (Exception ex)
		{
			await WriteJsonError(response, 400, "Invalid AGENTS.md payload: " + ex.Message);
			return;
		}
		try
		{
			AgentsFileSnapshot agentsFileSnapshot = AgentsFileStore.Save(saveRequest?.Content);
			await BridgeResponseWriter.WriteJsonAsync(response, new AgentsFileSaveResponse
			{
				Success = true,
				Path = agentsFileSnapshot.Path,
				Content = agentsFileSnapshot.Content
			}, _jsonOptions);
		}
		catch (Exception ex2)
		{
			AgentRuntimeLogger.Error("Failed to save AGENTS.md.", ex2);
			await WriteJsonError(response, 500, "Failed to save AGENTS.md: " + ex2.Message);
		}
	}

	public async Task HandleGetMcpSettings(HttpListenerResponse response)
	{
		try
		{
			McpSettingsSnapshot mcpSettingsSnapshot = McpSettingsStore.Read();
			await BridgeResponseWriter.WriteJsonAsync(response, new
			{
				path = mcpSettingsSnapshot.Path,
				servers = mcpSettingsSnapshot.Settings.Servers
			}, _jsonOptions);
		}
		catch (Exception ex)
		{
			AgentRuntimeLogger.Error("Failed to read MCP settings.", ex);
			await WriteJsonError(response, 500, "Failed to read MCP settings: " + ex.Message);
		}
	}

	public async Task HandleSaveMcpSettings(HttpListenerRequest request, HttpListenerResponse response)
	{
		string text;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			text = await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		McpSettings settings;
		try
		{
			settings = (string.IsNullOrWhiteSpace(text) ? new McpSettings() : JsonSerializer.Deserialize<McpSettings>(text, _jsonOptions));
		}
		catch (Exception ex)
		{
			await WriteJsonError(response, 400, "Invalid MCP settings payload: " + ex.Message);
			return;
		}
		try
		{
			McpSettingsSnapshot mcpSettingsSnapshot = McpSettingsStore.Save(settings ?? new McpSettings());
			_agentRuntime.RefreshToolCatalog();
			await BridgeResponseWriter.WriteJsonAsync(response, new
			{
				success = true,
				path = mcpSettingsSnapshot.Path,
				servers = mcpSettingsSnapshot.Settings.Servers
			}, _jsonOptions);
		}
		catch (Exception ex2)
		{
			AgentRuntimeLogger.Error("Failed to save MCP settings.", ex2);
			await WriteJsonError(response, 400, ex2.Message);
		}
	}

	public async Task HandleTestMcpServer(HttpListenerRequest request, HttpListenerResponse response)
	{
		string json;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			json = await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		McpServerConfig server;
		try
		{
			server = JsonSerializer.Deserialize<McpServerConfig>(json, _jsonOptions);
		}
		catch (Exception ex)
		{
			await WriteJsonError(response, 400, "Invalid MCP server payload: " + ex.Message);
			return;
		}
		try
		{
			using McpToolProvider provider = new McpToolProvider();
			McpTestResult mcpTestResult = provider.TestServer(server);
			mcpTestResult.Message = $"Connected. {mcpTestResult.Tools.Count} tool(s) found.";
			await BridgeResponseWriter.WriteJsonAsync(response, mcpTestResult, _jsonOptions);
		}
		catch (Exception ex2)
		{
			AgentRuntimeLogger.Error("MCP server test failed.", ex2);
			await BridgeResponseWriter.WriteJsonAsync(response, new McpTestResult
			{
				Success = false,
				Message = ex2.Message
			}, _jsonOptions);
		}
	}

	public async Task HandlePreviewMcpImport(HttpListenerRequest request, HttpListenerResponse response)
	{
		McpSettingsImportRequest mcpSettingsImportRequest = await ReadMcpImportRequestOrNull(request, response).ConfigureAwait(continueOnCapturedContext: false);
		if (mcpSettingsImportRequest != null)
		{
			try
			{
				McpSettings settings = McpSettingsStore.Read().Settings;
				McpSettingsImportPreview value = McpSettingsImporter.Preview(mcpSettingsImportRequest.Content, settings);
				await BridgeResponseWriter.WriteJsonAsync(response, value, _jsonOptions);
			}
			catch (Exception ex)
			{
				AgentRuntimeLogger.Error("MCP import preview failed.", ex);
				await WriteJsonError(response, 400, ex.Message);
			}
		}
	}

	public async Task HandleImportMcpSettings(HttpListenerRequest request, HttpListenerResponse response)
	{
		McpSettingsImportRequest mcpSettingsImportRequest = await ReadMcpImportRequestOrNull(request, response).ConfigureAwait(continueOnCapturedContext: false);
		if (mcpSettingsImportRequest != null)
		{
			try
			{
				McpSettings settings = McpSettingsStore.Read().Settings;
				McpSettingsImportPreview mcpSettingsImportPreview = McpSettingsImporter.Preview(mcpSettingsImportRequest.Content, settings);
				McpSettingsSnapshot mcpSettingsSnapshot = McpSettingsStore.Save(McpSettingsImporter.Merge(settings, mcpSettingsImportPreview.Servers));
				_agentRuntime.RefreshToolCatalog();
				await BridgeResponseWriter.WriteJsonAsync(response, new
				{
					success = true,
					path = mcpSettingsSnapshot.Path,
					servers = mcpSettingsSnapshot.Settings.Servers,
					imported = mcpSettingsImportPreview.Servers,
					unsupported = mcpSettingsImportPreview.Unsupported,
					conflicts = mcpSettingsImportPreview.Conflicts
				}, _jsonOptions);
			}
			catch (Exception ex)
			{
				AgentRuntimeLogger.Error("MCP import failed.", ex);
				await WriteJsonError(response, 400, ex.Message);
			}
		}
	}

	public async Task HandleStartMcpWarmup(HttpListenerResponse response)
	{
		try
		{
			McpWarmupStatus value = _agentRuntime.StartMcpWarmup();
			await BridgeResponseWriter.WriteJsonAsync(response, value, _jsonOptions);
		}
		catch (Exception ex)
		{
			AgentRuntimeLogger.Error("Failed to start MCP warmup.", ex);
			await WriteJsonError(response, 500, "Failed to start MCP warmup: " + ex.Message);
		}
	}

	public async Task HandleGetMcpWarmupStatus(HttpListenerResponse response)
	{
		try
		{
			McpWarmupStatus mcpWarmupStatus = _agentRuntime.GetMcpWarmupStatus();
			await BridgeResponseWriter.WriteJsonAsync(response, mcpWarmupStatus, _jsonOptions);
		}
		catch (Exception ex)
		{
			AgentRuntimeLogger.Error("Failed to read MCP warmup status.", ex);
			await WriteJsonError(response, 500, "Failed to read MCP warmup status: " + ex.Message);
		}
	}

	public async Task HandleGetMcpServerTools(HttpListenerResponse response, string serverId)
	{
		if (string.IsNullOrWhiteSpace(serverId))
		{
			await WriteJsonError(response, 404, "MCP server was not specified.");
			return;
		}
		try
		{
			using McpToolProvider provider = new McpToolProvider();
			McpServerToolsResult serverTools = provider.GetServerTools(serverId);
			if (serverTools == null)
			{
				await WriteJsonError(response, 404, "MCP server '" + serverId + "' was not found.");
				return;
			}
			await BridgeResponseWriter.WriteJsonAsync(response, serverTools, _jsonOptions);
		}
		catch (Exception ex)
		{
			AgentRuntimeLogger.Error("Failed to list MCP tools for server '" + serverId + "'.", ex);
			await BridgeResponseWriter.WriteJsonAsync(response, new McpServerToolsResult
			{
				Success = false,
				Enabled = true,
				ServerId = serverId,
				Message = ex.Message
			}, _jsonOptions);
		}
	}

	public async Task HandleListTools(HttpListenerResponse response)
	{
		List<ToolInfo> tools = (from tool in _agentRuntime.GetToolMetadata()
			where tool != null && !string.IsNullOrWhiteSpace(tool.Name)
			select new ToolInfo
			{
				Name = tool.Name,
				Description = tool.Description,
				Groups = (from @group in tool.Groups ?? Array.Empty<string>()
					where !string.IsNullOrWhiteSpace(@group)
					select @group.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).ToList(),
				IsDefault = tool.IsDefault
			}).OrderBy((ToolInfo tool) => tool.Name, StringComparer.OrdinalIgnoreCase).ToList();
		await BridgeResponseWriter.WriteJsonAsync(response, new ToolsResponse
		{
			Tools = tools
		}, _jsonOptions);
	}

	private async Task<McpSettingsImportRequest> ReadMcpImportRequestOrNull(HttpListenerRequest request, HttpListenerResponse response)
	{
		string text;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			text = await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		McpSettingsImportRequest result = default(McpSettingsImportRequest);
		object obj;
		int num;
		try
		{
			result = (string.IsNullOrWhiteSpace(text) ? new McpSettingsImportRequest() : JsonSerializer.Deserialize<McpSettingsImportRequest>(text, _jsonOptions));
			return result;
		}
		catch (Exception ex)
		{
			obj = ex;
			num = 1;
		}
		if (num != 1)
		{
			return result;
		}
		Exception ex2 = (Exception)obj;
		await WriteJsonError(response, 400, "Invalid MCP import payload: " + ex2.Message);
		return null;
	}

	public async Task HandleOpenSkillsFolder(HttpListenerResponse response)
	{
		string text = AgentRuntime.ResolveSkillsPath();
		if (string.IsNullOrWhiteSpace(text))
		{
			await WriteJsonError(response, 404, "Skills directory was not found (.agent/skills or .claude/skills).");
			return;
		}
		try
		{
			Process.Start("explorer.exe", text);
		}
		catch (Exception ex)
		{
			await WriteJsonError(response, 500, "Failed to open skills directory: " + ex.Message);
			return;
		}
		await BridgeResponseWriter.WriteJsonAsync(response, new
		{
			success = true,
			path = text
		}, _jsonOptions);
	}

	private Task WriteJsonError(HttpListenerResponse response, int statusCode, string message)
	{
		return BridgeResponseWriter.WriteJsonErrorAsync(response, statusCode, message, _jsonOptions);
	}

	private static int ParsePositiveInt(string value, int fallback)
	{
		if (!int.TryParse(value, out var result) || result <= 0)
		{
			return fallback;
		}
		return result;
	}

	private static string GetQueryValue(HttpListenerRequest request, string key)
	{
		if (request == null || string.IsNullOrWhiteSpace(key))
		{
			return null;
		}
		string rawUrl = request.RawUrl;
		if (string.IsNullOrWhiteSpace(rawUrl))
		{
			return request.QueryString[key];
		}
		int num = rawUrl.IndexOf('?');
		if (num < 0 || num + 1 >= rawUrl.Length)
		{
			return request.QueryString[key];
		}
		string[] array = rawUrl.Substring(num + 1).Split('&');
		foreach (string text in array)
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				int num2 = text.IndexOf('=');
				if (string.Equals(Uri.UnescapeDataString(((num2 >= 0) ? text.Substring(0, num2) : text).Replace("+", " ")), key, StringComparison.OrdinalIgnoreCase))
				{
					return Uri.UnescapeDataString(((num2 >= 0) ? text.Substring(num2 + 1) : string.Empty).Replace("+", " "));
				}
			}
		}
		return request.QueryString[key];
	}

	internal static bool IsAllowedSkillInstallOrigin(string origin)
	{
		return DesktopAiBridgeServer.IsAllowedBridgeOrigin(origin);
	}

	private static string CreateToken()
	{
		byte[] array = new byte[32];
		using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
		{
			randomNumberGenerator.GetBytes(array);
		}
		return Convert.ToBase64String(array);
	}
}
