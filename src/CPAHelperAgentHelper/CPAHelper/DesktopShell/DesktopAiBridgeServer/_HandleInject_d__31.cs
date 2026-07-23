using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Adapters;
using CPAHelper.Agent.Contracts;
using CPAHelper.Agent.Runtime;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.DesktopShell;

public class DesktopAiBridgeServer : IDisposable
{
	private int _disposed;

	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		PropertyNameCaseInsensitive = true,
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase
	};

	private HttpListener _listener;

	private CancellationTokenSource _serverCts;

	private readonly BridgeRequestRouter _router;

	private readonly ConcurrentDictionary<string, DesktopAiSessionController> _sessions = new ConcurrentDictionary<string, DesktopAiSessionController>();

	private readonly AgentRuntime _agentRuntime;

	private readonly IAgentConfigProvider _configProvider;

	private readonly IAgentInstructionBuilder _instructionBuilder;

	private readonly IHostContext _hostContext;

	private readonly TodoProvider _todoProvider;

	private readonly AgentModeProvider _agentModeProvider;

	private readonly BridgeCatalogEndpoints _catalogEndpoints;

	private readonly Func<AgentInstructionContext> _instructionContextFactory;

	private readonly Action<AgentArtifact> _onArtifact;

	public int Port { get; private set; }

	public DesktopAiBridgeServer(AgentRuntime agentRuntime, IAgentConfigProvider configProvider, IAgentInstructionBuilder instructionBuilder, IHostContext hostContext, Func<AgentInstructionContext> instructionContextFactory = null, Action<AgentArtifact> onArtifact = null, IHostActionProvider hostActionProvider = null)
	{
		_agentRuntime = agentRuntime ?? throw new ArgumentNullException("agentRuntime");
		_configProvider = configProvider ?? throw new ArgumentNullException("configProvider");
		_instructionBuilder = instructionBuilder ?? throw new ArgumentNullException("instructionBuilder");
		_hostContext = hostContext ?? throw new ArgumentNullException("hostContext");
		_todoProvider = _agentRuntime.TodoProvider;
		_agentModeProvider = _agentRuntime.AgentModeProvider;
		_instructionContextFactory = instructionContextFactory ?? ((Func<AgentInstructionContext>)(() => new AgentInstructionContext()));
		_onArtifact = onArtifact;
		_catalogEndpoints = new BridgeCatalogEndpoints(_agentRuntime, hostActionProvider, JsonOptions);
		_router = BuildRouter();
	}

	public void Start(int preferredPort = 0)
	{
		StartListener(preferredPort);
		_serverCts = new CancellationTokenSource();
		Task.Run(() => ListenLoop(_serverCts.Token));
	}

	private void StartListener(int preferredPort)
	{
		int port = ((preferredPort > 0) ? preferredPort : AllocateLoopbackPort());
		try
		{
			StartListenerOnPort(port);
		}
		catch (HttpListenerException) when (preferredPort > 0)
		{
			StartListenerOnPort(AllocateLoopbackPort());
		}
	}

	private void StartListenerOnPort(int port)
	{
		_listener = new HttpListener();
		_listener.Prefixes.Add($"http://127.0.0.1:{port}/");
		_listener.Start();
		Port = port;
	}

	private static int AllocateLoopbackPort()
	{
		TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 0);
		tcpListener.Start();
		try
		{
			return ((IPEndPoint)tcpListener.LocalEndpoint).Port;
		}
		finally
		{
			tcpListener.Stop();
		}
	}

	private async Task ListenLoop(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			try
			{
				HttpListenerContext context = await _listener.GetContextAsync();
				Task.Run(() => HandleRequest(context));
			}
			catch (HttpListenerException) when (token.IsCancellationRequested)
			{
				break;
			}
			catch (ObjectDisposedException)
			{
				break;
			}
			catch
			{
			}
		}
	}

	private async Task HandleRequest(HttpListenerContext context)
	{
		HttpListenerRequest request = context.Request;
		HttpListenerResponse response = context.Response;
		string text = request.Headers["Origin"];
		bool flag = !string.IsNullOrWhiteSpace(text);
		bool flag2 = IsAllowedBridgeOrigin(text);
		if (flag && flag2)
		{
			response.Headers.Add("Access-Control-Allow-Origin", text);
			response.Headers.Add("Vary", "Origin");
			response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
			response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-CPAHelper-Bridge-Token");
			response.Headers.Add("Access-Control-Allow-Private-Network", "true");
		}
		if (request.HttpMethod == "OPTIONS")
		{
			response.StatusCode = (flag2 ? 204 : 403);
			response.Close();
			return;
		}
		string path = request.Url.AbsolutePath.ToLower();
		try
		{
			if (flag && !flag2)
			{
				await WriteJsonError(response, 403, "Bridge origin is not allowed.");
				return;
			}
			if (!(await _router.TryDispatchAsync(request, response).ConfigureAwait(continueOnCapturedContext: false)))
			{
				response.StatusCode = 404;
				response.Close();
			}
		}
		catch (Exception ex)
		{
			AgentRuntimeLogger.Error("Bridge request failed: " + request.HttpMethod + " " + path, ex);
			try
			{
				if (!(path == "/api/chat") || !(request.HttpMethod == "POST"))
				{
					await WriteJsonError(response, 500, "服务器异常：" + ex.Message);
					return;
				}
				response.StatusCode = 500;
				response.Close();
			}
			catch
			{
			}
		}
	}

	private BridgeRequestRouter BuildRouter()
	{
		return new BridgeRequestRouter().Map("GET", "/api/health", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleHealth(response)).Map("POST", "/api/chat", (HttpListenerRequest request, HttpListenerResponse response, string _) => HandleChat(request, response)).Map("POST", "/api/chat/inject", (HttpListenerRequest request, HttpListenerResponse response, string _) => HandleInject(request, response))
			.Map("POST", "/api/chat/cancel", (HttpListenerRequest request, HttpListenerResponse response, string _) => HandleCancel(request, response))
			.Map("POST", "/api/chat/approval", (HttpListenerRequest request, HttpListenerResponse response, string _) => HandleApproval(request, response))
			.Map("GET", "/api/sessions", (HttpListenerRequest _, HttpListenerResponse response, string __) => HandleListSessions(response))
			.Map("POST", "/api/sessions/new", (HttpListenerRequest _, HttpListenerResponse response, string __) => HandleNewSession(response))
			.Map("GET", "/api/skills", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleListSkills(response))
			.Map("GET", "/api/skills/market", (HttpListenerRequest request, HttpListenerResponse response, string __) => _catalogEndpoints.HandleListSkillMarket(request, response))
			.Map("POST", "/api/skills/open", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleOpenSkillsFolder(response))
			.Map("GET", "/api/skills/install-session", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleSkillInstallSession(response))
			.Map("POST", "/api/skills/install", (HttpListenerRequest request, HttpListenerResponse response, string __) => _catalogEndpoints.HandleInstallSkill(request, response))
			.Map("POST", "/api/skills/uninstall", (HttpListenerRequest request, HttpListenerResponse response, string __) => _catalogEndpoints.HandleUninstallSkill(request, response))
			.Map("GET", "/api/agents-file", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleGetAgentsFile(response))
			.Map("PUT", "/api/agents-file", (HttpListenerRequest request, HttpListenerResponse response, string __) => _catalogEndpoints.HandleSaveAgentsFile(request, response))
			.Map("GET", "/api/settings/mcp", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleGetMcpSettings(response))
			.Map("PUT", "/api/settings/mcp", (HttpListenerRequest request, HttpListenerResponse response, string __) => _catalogEndpoints.HandleSaveMcpSettings(request, response))
			.Map("POST", "/api/settings/mcp/test", (HttpListenerRequest request, HttpListenerResponse response, string __) => _catalogEndpoints.HandleTestMcpServer(request, response))
			.Map("POST", "/api/settings/mcp/import/preview", (HttpListenerRequest request, HttpListenerResponse response, string __) => _catalogEndpoints.HandlePreviewMcpImport(request, response))
			.Map("POST", "/api/settings/mcp/import", (HttpListenerRequest request, HttpListenerResponse response, string __) => _catalogEndpoints.HandleImportMcpSettings(request, response))
			.MapMcpServerTools((HttpListenerRequest _, HttpListenerResponse response, string serverId) => _catalogEndpoints.HandleGetMcpServerTools(response, serverId))
			.Map("POST", "/api/mcp/warmup", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleStartMcpWarmup(response))
			.Map("GET", "/api/mcp/status", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleGetMcpWarmupStatus(response))
			.Map("GET", "/api/tools", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleListTools(response))
			.Map("GET", "/api/host/status", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleHostStatus(response))
			.Map("GET", "/api/host/actions", (HttpListenerRequest _, HttpListenerResponse response, string __) => _catalogEndpoints.HandleListHostActions(response))
			.MapHostAction((HttpListenerRequest request, HttpListenerResponse response, string actionId) => _catalogEndpoints.HandleInvokeHostAction(request, response, actionId))
			.MapSessionTitle((HttpListenerRequest request, HttpListenerResponse response, string sessionId) => HandleRenameSession(request, response, sessionId))
			.MapSession("GET", (HttpListenerRequest _, HttpListenerResponse response, string sessionId) => HandleGetSession(response, sessionId))
			.MapSession("DELETE", (HttpListenerRequest _, HttpListenerResponse response, string sessionId) => HandleDeleteSession(response, sessionId));
	}

	internal static bool IsAllowedBridgeOrigin(string origin)
	{
		if (string.IsNullOrWhiteSpace(origin))
		{
			return true;
		}
		if (!Uri.TryCreate(origin, UriKind.Absolute, out var result))
		{
			return false;
		}
		if (result.Host.Equals("app.local", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(result.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);
		}
		if (result.Host.Equals("127.0.0.1", StringComparison.OrdinalIgnoreCase) || result.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
		{
			if (!string.Equals(result.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(result.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}
		return false;
	}

	private async Task HandleChat(HttpListenerRequest request, HttpListenerResponse response)
	{
		string json;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			json = await reader.ReadToEndAsync();
		}
		ChatRequest chatRequest;
		try
		{
			chatRequest = JsonSerializer.Deserialize<ChatRequest>(json, JsonOptions);
		}
		catch (Exception ex)
		{
			await WriteJsonError(response, 400, "请求格式错误：" + ex.Message);
			return;
		}
		if (chatRequest == null || string.IsNullOrEmpty(chatRequest.Message))
		{
			await WriteJsonError(response, 400, "消息不能为空");
			return;
		}
		DesktopAiSessionController controller;
		try
		{
			string key = chatRequest.ThreadId ?? "default";
			controller = _sessions.GetOrAdd(key, (string tid) => new DesktopAiSessionController(tid, _agentRuntime, _configProvider, _instructionBuilder, _hostContext, _instructionContextFactory, _onArtifact, _todoProvider, _agentModeProvider));
		}
		catch (Exception ex2)
		{
			await WriteJsonError(response, 500, "会话初始化失败：" + ex2.Message);
			return;
		}
		response.ContentType = "text/event-stream";
		response.ContentEncoding = Encoding.UTF8;
		response.SendChunked = true;
		response.Headers.Add("Cache-Control", "no-cache");
		response.Headers.Add("Connection", "keep-alive");
		try
		{
			string message = chatRequest.Message;
			Stream outputStream = response.OutputStream;
			string displayMessage = chatRequest.DisplayMessage;
			IReadOnlyList<string> selectedSkills;
			if (chatRequest.SelectedSkills == null || chatRequest.SelectedSkills.Count <= 0)
			{
				selectedSkills = SplitSelectedSkills(chatRequest.SelectedSkill);
			}
			else
			{
				IReadOnlyList<string> selectedSkills2 = chatRequest.SelectedSkills;
				selectedSkills = selectedSkills2;
			}
			await controller.ProcessMessageAsync(message, outputStream, displayMessage, selectedSkills, chatRequest.HostContextItems ?? new List<HostContextItem>(), chatRequest.SelectedTools ?? new List<string>(), chatRequest.AgentMode, chatRequest.SkipInterruptedRecovery);
		}
		catch (Exception ex3)
		{
			AgentRuntimeLogger.Error("Bridge chat run failed.", ex3);
			try
			{
				ErrorEvent errorEvent = new ErrorEvent
				{
					Message = ex3.Message,
					Code = "bridge_error"
				};
				byte[] bytes = Encoding.UTF8.GetBytes(errorEvent.ToSseLine());
				await response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
			}
			catch
			{
			}
		}
		finally
		{
			try
			{
				response.Close();
			}
			catch
			{
			}
		}
	}

	private static Task WriteJsonError(HttpListenerResponse response, int statusCode, string message)
	{
		return BridgeResponseWriter.WriteJsonErrorAsync(response, statusCode, message, JsonOptions);
	}

	private async Task HandleCancel(HttpListenerRequest request, HttpListenerResponse response)
	{
		string json;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			json = await reader.ReadToEndAsync();
		}
		CancelRequest cancelRequest = JsonSerializer.Deserialize<CancelRequest>(json, JsonOptions);
		if (cancelRequest != null && _sessions.TryGetValue(cancelRequest.ThreadId, out var value))
		{
			value.Cancel();
		}
		await BridgeResponseWriter.WriteJsonAsync(response, new
		{
			success = true
		}, JsonOptions);
	}

	private async Task HandleInject(HttpListenerRequest request, HttpListenerResponse response)
	{
		string json;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			json = await reader.ReadToEndAsync();
		}
		InjectMessageRequest injectionRequest;
		try
		{
			injectionRequest = JsonSerializer.Deserialize<InjectMessageRequest>(json, JsonOptions);
		}
		catch (Exception ex)
		{
			await WriteJsonError(response, 400, "请求格式错误：" + ex.Message);
			return;
		}
		if (injectionRequest == null || string.IsNullOrWhiteSpace(injectionRequest.ThreadId) || string.IsNullOrWhiteSpace(injectionRequest.InjectionId) || string.IsNullOrWhiteSpace(injectionRequest.Message))
		{
			await WriteJsonError(response, 400, "注入消息参数不完整");
			return;
		}
		if (!_sessions.TryGetValue(injectionRequest.ThreadId, out var value))
		{
			await WriteJsonError(response, 409, "当前会话没有可注入的活动任务");
			return;
		}
		DesktopMessageInjectionResult desktopMessageInjectionResult = value.TryInjectMessage(injectionRequest);
		if (!desktopMessageInjectionResult.Success)
		{
			await WriteJsonError(response, 409, desktopMessageInjectionResult.Message ?? "消息注入失败");
		}
		else
		{
			await BridgeResponseWriter.WriteJsonAsync(response, desktopMessageInjectionResult, JsonOptions);
		}
	}

	private async Task HandleApproval(HttpListenerRequest request, HttpListenerResponse response)
	{
		string json;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			json = await reader.ReadToEndAsync();
		}
		ApprovalSubmitRequest approvalRequest;
		try
		{
			approvalRequest = JsonSerializer.Deserialize<ApprovalSubmitRequest>(json, JsonOptions);
		}
		catch (Exception ex)
		{
			await WriteJsonError(response, 400, "Failed to parse approval payload: " + ex.Message);
			return;
		}
		DesktopAiSessionController value;
		if (approvalRequest == null || string.IsNullOrWhiteSpace(approvalRequest.ThreadId) || string.IsNullOrWhiteSpace(approvalRequest.RequestId))
		{
			await WriteJsonError(response, 400, "Approval request requires threadId and requestId.");
		}
		else if (!_sessions.TryGetValue(approvalRequest.ThreadId, out value))
		{
			await WriteJsonError(response, 404, "Session not found.");
		}
		else if (!value.ResolveApproval(approvalRequest.RequestId, approvalRequest.Approved, approvalRequest.ApprovalMode))
		{
			await WriteJsonError(response, 404, "Approval request was not found or has already completed.");
		}
		else
		{
			await BridgeResponseWriter.WriteJsonAsync(response, new
			{
				success = true
			}, JsonOptions);
		}
	}

	private async Task HandleListSessions(HttpListenerResponse response)
	{
		List<JsonSessionIndexManager.SessionSummary> value = JsonSessionIndexManager.ListSessions();
		await BridgeResponseWriter.WriteJsonAsync(response, value, JsonOptions);
	}

	private async Task HandleNewSession(HttpListenerResponse response)
	{
		JsonSessionIndexManager.SessionSummary value = JsonSessionIndexManager.CreateSession();
		await BridgeResponseWriter.WriteJsonAsync(response, value, JsonOptions);
	}

	private static IReadOnlyList<string> SplitSelectedSkills(string selectedSkill)
	{
		if (string.IsNullOrWhiteSpace(selectedSkill))
		{
			return Array.Empty<string>();
		}
		return (from skill in selectedSkill.Split(new char[4] { ',', '，', ';', '；' }, StringSplitOptions.RemoveEmptyEntries)
			select skill.Trim() into skill
			where !string.IsNullOrWhiteSpace(skill)
			select skill).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
	}

	private async Task HandleRenameSession(HttpListenerRequest request, HttpListenerResponse response, string sessionId)
	{
		string json;
		using (StreamReader reader = new StreamReader(request.InputStream, Encoding.UTF8))
		{
			json = await reader.ReadToEndAsync();
		}
		RenameSessionRequest renameRequest;
		try
		{
			renameRequest = JsonSerializer.Deserialize<RenameSessionRequest>(json, JsonOptions);
		}
		catch (Exception ex)
		{
			await WriteJsonError(response, 400, "请求格式错误：" + ex.Message);
			return;
		}
		if (renameRequest == null || string.IsNullOrWhiteSpace(renameRequest.Title))
		{
			await WriteJsonError(response, 400, "会话名称不能为空");
			return;
		}
		JsonSessionIndexManager.SessionSummary sessionSummary = JsonSessionIndexManager.RenameSession(sessionId, renameRequest.Title);
		if (sessionSummary == null)
		{
			await WriteJsonError(response, 404, "会话不存在");
		}
		else
		{
			await BridgeResponseWriter.WriteJsonAsync(response, sessionSummary, JsonOptions);
		}
	}

	private async Task HandleGetSession(HttpListenerResponse response, string sessionId)
	{
		JsonSessionIndexManager.SessionDetailDto sessionDetail = JsonSessionIndexManager.GetSessionDetail(sessionId);
		if (sessionDetail == null)
		{
			await WriteJsonError(response, 404, "会话不存在");
		}
		else
		{
			await BridgeResponseWriter.WriteJsonAsync(response, sessionDetail, JsonOptions);
		}
	}

	private async Task HandleDeleteSession(HttpListenerResponse response, string sessionId)
	{
		JsonSessionIndexManager.DeleteSession(sessionId);
		_agentRuntime.RemoveSession(sessionId);
		if (_sessions.TryRemove(sessionId, out var value))
		{
			value.Dispose();
		}
		await BridgeResponseWriter.WriteJsonAsync(response, new
		{
			success = true
		}, JsonOptions);
	}

	public void Dispose()
	{
		if (Interlocked.Exchange(ref _disposed, 1) != 0)
		{
			return;
		}
		CancellationTokenSource cancellationTokenSource = Interlocked.Exchange(ref _serverCts, null);
		try
		{
			cancellationTokenSource?.Cancel();
		}
		catch (ObjectDisposedException)
		{
		}
		foreach (DesktopAiSessionController value in _sessions.Values)
		{
			value.Dispose();
		}
		_sessions.Clear();
		try
		{
			_listener?.Stop();
			_listener?.Close();
		}
		catch
		{
		}
		cancellationTokenSource?.Dispose();
	}
}
