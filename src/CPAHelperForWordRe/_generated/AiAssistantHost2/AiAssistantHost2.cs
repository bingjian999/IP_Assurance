using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using AiHelper_19;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Adapters;
using CPAHelper.Agent.DesktopShell;
using CPAHelper.Agent.Runtime;
using CPAHelperForWordRe.UI.Forms;
using WpsVbaCompatService;
using AiConfigBootstrap;
using Helper_21;
using AiHelper_15;
using FileDownloadHelper;
using WordTableToolService5;
using HostActionDispatcher;
using AiSseStreamService3;
using AiTargetBinder;
using IntranetAiConfigService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools;
using WordAgentRuntimeGuard;
using SseStreamInitializer;
using AiSseStreamService5;
using VbaValidationService;
using AiConfigManager2;
using HttpHelper_2;
using CliCommandService;
using SubAgentCatalog;
using AiSseStreamService;
using AiHelper_3;
using WordTableToolService;
using AiConfigBootstrap2;
using WordContextPreviewService;
using UiHelper_1;
using ExcelReadonlyService;
using AiAssistantHost;
using BatchReplaceService2;
using WordTableToolService4;
using LoggerInitializer;
using AiHelper_17;

namespace AiAssistantHost2;

internal static class AiAssistantHost2
{
	private sealed class PaneBridgeHolder : IDisposable
	{
		[CompilerGenerated]
		private DesktopAiBridgeServer _server;

		[CompilerGenerated]
		private ServiceProvider _serviceProvider;

		public DesktopAiBridgeServer Server
		{
			[CompilerGenerated]
			get
			{
				return _server;
			}
			[CompilerGenerated]
			set
			{
				_server = value;
			}
		}

		public ServiceProvider ServiceProvider
		{
			[CompilerGenerated]
			get
			{
				return _serviceProvider;
			}
			[CompilerGenerated]
			set
			{
				_serviceProvider = value;
			}
		}

		public void Dispose()
		{
			try
			{
				Server?.Dispose();
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogWarn("[AI] Pane bridge cleanup failed: " + ex.Message);
			}
			try
			{
				ServiceProvider?.Dispose();
			}
			catch (Exception ex2)
			{
				AiConfigBootstrap.LogWarn("[AI] Pane service provider cleanup failed: " + ex2.Message);
			}
		}

		public PaneBridgeHolder()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_0
	{
		public AiTargetBinder _targetBinder;

		public WordAgentRuntimeGuard _runtimeGuard;

		public _G_c__DisplayClass10_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void OnArtifact(AgentArtifact artifact)
		{
			_G_c__DisplayClass10_1 CS_8_locals_4 = new _G_c__DisplayClass10_1();
			CS_8_locals_4._G_c__DisplayClass10_0 = this;
			CS_8_locals_4.agentArtifact = artifact;
			_runtimeGuard.InvokeOnUiThread(delegate
			{
				AiHelper_17.VYkUViDjLf(CS_8_locals_4._G_c__DisplayClass10_0._targetBinder, CS_8_locals_4.agentArtifact);
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_1
	{
		public AgentArtifact agentArtifact;

		public _G_c__DisplayClass10_0 _G_c__DisplayClass10_0;

		public _G_c__DisplayClass10_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ProcessArtifact()
		{
			AiHelper_17.VYkUViDjLf(_G_c__DisplayClass10_0._targetBinder, agentArtifact);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_0
	{
		public AiTargetBinder _targetBinder;

		public _G_c__DisplayClass28_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_15 CreateAiHelper15(IServiceProvider _)
		{
			return new AiHelper_15(_targetBinder);
		}

		internal BatchReplaceService2 CreateBatchReplaceService2(IServiceProvider _)
		{
			return new BatchReplaceService2(_targetBinder);
		}

		internal WpsVbaCompatService CreateWpsVbaCompatService(IServiceProvider _)
		{
			return new WpsVbaCompatService(_targetBinder);
		}
	}

	private static readonly object _syncLock;

	private static readonly HashSet<CustomTaskPane> _closingPanes;

	private static readonly Dictionary<string, PaneBridgeHolder> _paneBridges;

	private static bool _isInitialized;

	private static bool _isShuttingDown;

	public static void TriggerFileDownload()
	{
		FileDownloadHelper.Current.t9vwx1YSVk();
	}

	public static bool EnsureInitialized()
	{
		if (_isInitialized)
		{
			return true;
		}
		lock (_syncLock)
		{
			if (_isInitialized)
			{
				return true;
			}
			try
			{
				HttpHelper_2.initializeHttpClient();
				PrepareAgentRuntimeBase();
				FileDownloadHelper.Current.t9vwx1YSVk();
				if (!IntranetAiConfigService.Instance.EnsureAuthenticated())
				{
					AiConfigBootstrap.LogInfo("Agent initialization aborted because intranet authentication was not completed.");
					return false;
				}
				JsonSessionIndexManager.Initialize(AiSseStreamService.GetUserDataPath("Agent", "chat-sessions"));
				_isInitialized = true;
				return true;
			}
			catch (Exception ex)
			{
				CleanupAndShutdown( false);
				AiConfigBootstrap.LogError("[AI] Agent initialization failed", ex);
				LoggerInitializer.ShowError("AI 助手初始化失败，请检查配置、网络环境和日志后重试。\r\n" + ex.Message, "AI 助手");
				return false;
			}
		}
	}

	public static DesktopAiBridgeServer GetOrCreateBridge()
	{
		return CreatePaneBridge(null);
	}

	public static DesktopAiBridgeServer CreatePaneBridge(AiTargetBinder P_0)
	{
		_G_c__DisplayClass10_0 CS_8_locals_14 = new _G_c__DisplayClass10_0();
		CS_8_locals_14._targetBinder = P_0;
		if (!EnsureInitialized())
		{
			return null;
		}
		lock (_syncLock)
		{
			string text = GetPaneKey(CS_8_locals_14._targetBinder);
			if (_paneBridges.TryGetValue(text, out var value))
			{
				return value.Server;
			}
			ServiceProvider serviceProvider = null;
			DesktopAiBridgeServer desktopAiBridgeServer = null;
			try
			{
				CS_8_locals_14._runtimeGuard = new WordAgentRuntimeGuard(CS_8_locals_14._targetBinder);
				HostActionDispatcher hostActionDispatcher = new HostActionDispatcher(CS_8_locals_14._targetBinder);
				serviceProvider = BuildServiceProvider(CS_8_locals_14._targetBinder, CS_8_locals_14._runtimeGuard, hostActionDispatcher);
				desktopAiBridgeServer = new DesktopAiBridgeServer(serviceProvider.GetRequiredService<AgentRuntime>(), serviceProvider.GetRequiredService<IAgentConfigProvider>(), serviceProvider.GetRequiredService<IAgentInstructionBuilder>(), instructionContextFactory: serviceProvider.GetRequiredService<AiHelper_19>().QhF3fbjxg1, hostContext: CS_8_locals_14._runtimeGuard, onArtifact: delegate(AgentArtifact artifact)
				{
					_G_c__DisplayClass10_1 CS_8_locals_16 = new _G_c__DisplayClass10_1();
					CS_8_locals_16._G_c__DisplayClass10_0 = CS_8_locals_14;
					CS_8_locals_16.agentArtifact = artifact;
					CS_8_locals_14._runtimeGuard.InvokeOnUiThread(delegate
					{
						AiHelper_17.VYkUViDjLf(CS_8_locals_16._G_c__DisplayClass10_0._targetBinder, CS_8_locals_16.agentArtifact);
					});
				}, hostActionProvider: hostActionDispatcher);
				desktopAiBridgeServer.Start();
				_paneBridges[text] = new PaneBridgeHolder
				{
					Server = desktopAiBridgeServer,
					ServiceProvider = serviceProvider
				};
				AiConfigBootstrap.LogInfo("[AI] Pane bridge started. Key=" + text + "; Port=" + desktopAiBridgeServer.Port + "; Target=" + (CS_8_locals_14._targetBinder?.DisplayName ?? "(active)"));
				return desktopAiBridgeServer;
			}
			catch (Exception ex)
			{
				try
				{
					desktopAiBridgeServer?.Dispose();
					serviceProvider?.Dispose();
				}
				catch
				{
				}
				AiConfigBootstrap.LogError("[AI] Create pane bridge failed", ex);
				LoggerInitializer.ShowError("AI 助手通信服务启动失败：\r\n" + ex.Message, "AI 助手");
				return null;
			}
		}
	}

	public static void ClosePaneBridge(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return;
		}
		lock (_syncLock)
		{
			if (_paneBridges.TryGetValue(P_0, out var value))
			{
				_paneBridges.Remove(P_0);
				value.Dispose();
			}
		}
	}

	public static void OpenAssistantPane()
	{
		if (!EnsureInitialized() || !IntranetAiConfigService.Instance.EnsureAuthenticated())
		{
			return;
		}
		try
		{
			Window window;
			AiTargetBinder targetBinder;
			CustomTaskPane customTaskPane = FindActivePane(out window, out targetBinder);
			if (window == null || targetBinder == null || string.IsNullOrWhiteSpace(targetBinder.WindowKey))
			{
				LoggerInitializer.ShowWarning("当前没有可用的 Word 文档窗口，无法打开 AI 助手。", "AI 助手");
				return;
			}
			if (customTaskPane == null)
			{
				customTaskPane = CreateTaskPane(window, targetBinder);
			}
			else
			{
				if (customTaskPane.Visible)
				{
					CloseAndDisposePane(customTaskPane);
					return;
				}
				customTaskPane.Visible = true;
			}
			if (customTaskPane.Visible && customTaskPane.Control is AiAssistantHost assistantHost)
			{
				assistantHost.InitializeAsync();
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[AI] Open assistant pane failed", ex);
			LoggerInitializer.ShowError("打开 AI 助手失败：\r\n" + ex.Message, "AI 助手");
		}
	}

	public static void EnsureAssistantPaneVisible()
	{
		if (!EnsureInitialized() || !IntranetAiConfigService.Instance.EnsureAuthenticated())
		{
			return;
		}
		try
		{
			Window window;
			AiTargetBinder targetBinder;
			CustomTaskPane customTaskPane = FindActivePane(out window, out targetBinder);
			if (window != null && targetBinder != null && !string.IsNullOrWhiteSpace(targetBinder.WindowKey))
			{
				if (customTaskPane == null)
				{
					customTaskPane = CreateTaskPane(window, targetBinder);
				}
				else if (!customTaskPane.Visible)
				{
					customTaskPane.Visible = true;
				}
				if (customTaskPane.Control is AiAssistantHost assistantHost)
				{
					assistantHost.InitializeAsync();
				}
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AI] Ensure assistant pane visible failed: " + ex.Message);
		}
	}

	public static void EnsureTargetPaneVisible(AiTargetBinder P_0)
	{
		if (P_0 == null)
		{
			EnsureAssistantPaneVisible();
		}
		else
		{
			if (!EnsureInitialized() || !IntranetAiConfigService.Instance.EnsureAuthenticated())
			{
				return;
			}
			try
			{
				CustomTaskPane customTaskPane = FindPaneByKey(P_0.WindowKey);
				if (customTaskPane == null)
				{
					Window window = P_0.FindWindow(WordTableToolService.WordApp);
					if (window == null)
					{
						return;
					}
					customTaskPane = CreateTaskPane(window, P_0);
				}
				else if (!customTaskPane.Visible)
				{
					customTaskPane.Visible = true;
				}
				if (customTaskPane.Control is AiAssistantHost assistantHost)
				{
					assistantHost.InitializeAsync();
				}
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogWarn("[AI] Ensure target assistant pane visible failed: " + ex.Message);
			}
		}
	}

	public static void ShowConfigWindow()
	{
		WordTableToolService5.ShowWpfWindow(new AIAssistantConfigWindow());
	}

	public static void InvokeAiHelper3Action()
	{
		AiHelper_3.BWIBRayGaa();
	}

	public static void ShutdownAll()
	{
		lock (_syncLock)
		{
			CleanupAndShutdown( true);
		}
	}

	private static void OnPaneVisibleChanged(object P_0, EventArgs P_1)
	{
		if (P_0 is CustomTaskPane customTaskPane && !_closingPanes.Contains(customTaskPane))
		{
			if (customTaskPane.Visible && customTaskPane.Control is AiAssistantHost assistantHost)
			{
				assistantHost.InitializeAsync();
			}
			else
			{
				CloseAndDisposePane(customTaskPane);
			}
		}
	}

	private static CustomTaskPane CreateTaskPane(Window P_0, AiTargetBinder P_1)
	{
		P_1 = P_1 ?? AiTargetBinder.FromWindow(P_0);
		AiAssistantHost control = new AiAssistantHost
		{
			Target = P_1,
			WindowKey = P_1?.WindowKey
		};
		CustomTaskPane customTaskPane = UiHelper_1.ThisAddIn.D8nlJJriq.Add(control, Helper_21.CurrentTitle, P_0);
		customTaskPane.Width = 560;
		customTaskPane.VisibleChanged += OnPaneVisibleChanged;
		customTaskPane.Visible = true;
		return customTaskPane;
	}

	private static CustomTaskPane FindActivePane(out Window P_0, out AiTargetBinder P_1)
	{
		if (!TryResolveActiveWindow(out P_0, out P_1))
		{
			return null;
		}
		return FindPaneByKey(P_1.WindowKey);
	}

	private static CustomTaskPane FindPaneByKey(string P_0)
	{
		CustomTaskPaneCollection customTaskPaneCollection = UiHelper_1.ThisAddIn?.D8nlJJriq;
		if (customTaskPaneCollection == null)
		{
			return null;
		}
		for (int num = customTaskPaneCollection.Count - 1; num >= 0; num--)
		{
			CustomTaskPane customTaskPane = customTaskPaneCollection[num];
			if (IsAssistantPane(customTaskPane) && customTaskPane.Control is AiAssistantHost assistantHost && string.Equals(assistantHost.WindowKey, P_0, StringComparison.OrdinalIgnoreCase))
			{
				return customTaskPane;
			}
		}
		return null;
	}

	private static bool TryResolveActiveWindow(out Window P_0, out AiTargetBinder P_1)
	{
		P_0 = null;
		P_1 = null;
		try
		{
			Application application = WordTableToolService.WordApp ?? UiHelper_1.ThisAddIn?.fM3oNckkd;
			if (application == null || application.Documents == null || application.Documents.Count < 1)
			{
				return false;
			}
			P_0 = application.ActiveWindow;
			P_1 = AiTargetBinder.FromWindow(P_0);
			return P_0 != null && P_1 != null && !string.IsNullOrWhiteSpace(P_1.WindowKey);
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AI] Unable to resolve active Word window for assistant pane: " + ex.Message);
			return false;
		}
	}

	private static bool IsAssistantPane(CustomTaskPane P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.Control is AiAssistantHost)
		{
			return true;
		}
		if (!string.Equals(P_0.Title, "IP_Assurance in Word", StringComparison.Ordinal) && !string.Equals(P_0.Title, "IP in Word", StringComparison.Ordinal))
		{
			return string.Equals(P_0.Title, "AI助手", StringComparison.Ordinal);
		}
		return true;
	}

	private static void CloseAndDisposePane(CustomTaskPane P_0)
	{
		if (P_0 == null || _closingPanes.Contains(P_0))
		{
			return;
		}
		_closingPanes.Add(P_0);
		try
		{
			P_0.VisibleChanged -= OnPaneVisibleChanged;
			try
			{
				if (P_0.Visible)
				{
					P_0.Visible = false;
				}
			}
			catch
			{
			}
			try
			{
				if (P_0.Control is AiAssistantHost assistantHost)
				{
					ClosePaneBridge(assistantHost.WindowKey);
				}
				((IDisposable)P_0.Control)?.Dispose();
			}
			catch
			{
			}
			try
			{
				UiHelper_1.ThisAddIn?.D8nlJJriq?.Remove(P_0);
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogWarn("[AI] Remove assistant pane failed: " + ex.Message);
			}
		}
		finally
		{
			_closingPanes.Remove(P_0);
		}
		TryShutdownIfAllClosed();
	}

	private static void TryShutdownIfAllClosed()
	{
		if (!_isShuttingDown && !HasAssistantPane())
		{
			ShutdownAll();
			AiConfigBootstrap.LogInfo("All AI panes closed and bootstrapper shutdown completed.");
		}
	}

	private static bool HasAssistantPane()
	{
		try
		{
			CustomTaskPaneCollection customTaskPaneCollection = UiHelper_1.ThisAddIn?.D8nlJJriq;
			if (customTaskPaneCollection == null)
			{
				return false;
			}
			for (int num = customTaskPaneCollection.Count - 1; num >= 0; num--)
			{
				if (IsAssistantPane(customTaskPaneCollection[num]))
				{
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AI] Check assistant pane existence failed: " + ex.Message);
		}
		return false;
	}

	private static string GetPaneKey(AiTargetBinder P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0?.WindowKey))
		{
			return P_0.WindowKey;
		}
		if (!string.IsNullOrWhiteSpace(P_0?.DocumentFullName))
		{
			return "doc:" + P_0.DocumentFullName;
		}
		if (!string.IsNullOrWhiteSpace(P_0?.DocumentName))
		{
			return "doc:" + P_0.DocumentName;
		}
		return "__active__";
	}

	private static ServiceProvider BuildServiceProvider(AiTargetBinder P_0, WordAgentRuntimeGuard P_1, HostActionDispatcher P_2)
	{
		_G_c__DisplayClass28_0 CS_8_locals_5 = new _G_c__DisplayClass28_0();
		CS_8_locals_5._targetBinder = P_0;
		ServiceCollection services = new ServiceCollection();
		services.AddSingleton<IAgentConfigProvider, AiSseStreamService5>();
		services.AddSingleton<IAgentInstructionBuilder, AiConfigManager2>();
		services.AddSingleton(new WordTableToolService4(CS_8_locals_5._targetBinder));
		services.AddSingleton<AiHelper_19>();
		((IServiceCollection)services).AddSingleton((Func<IServiceProvider, Func<AgentInstructionContext>>)((IServiceProvider sp) => sp.GetRequiredService<AiHelper_19>().QhF3fbjxg1));
		((IServiceCollection)services).AddSingleton((IHostContext)P_1);
		((IServiceCollection)services).AddSingleton((IHostActionProvider)P_2);
		services.AddSingleton<IArtifactSink, ArtifactSinkRelay>();
		services.AddSingleton<IChatHistoryStoreFactory, JsonChatHistoryStoreFactory>();
		services.AddSingleton((IServiceProvider _) => new AiHelper_15(CS_8_locals_5._targetBinder));
		services.AddSingleton((IServiceProvider _) => new BatchReplaceService2(CS_8_locals_5._targetBinder));
		services.AddSingleton<AiConfigBootstrap2>();
		services.AddSingleton((IServiceProvider _) => new WpsVbaCompatService(CS_8_locals_5._targetBinder));
		services.AddSingleton<IToolProvider, WordContextPreviewService>();
		services.AddSingleton<IToolProvider, ExcelReadonlyService>();
		services.AddSingleton<IToolProvider, VbaValidationService>();
		services.AddSingleton<IToolProvider, CliCommandService>();
		services.AddSingleton<ISubAgentCatalog, SubAgentCatalog>();
		services.AddAgentRuntime();
		return services.BuildServiceProvider();
	}

	private static void PrepareAgentRuntimeBase()
	{
		string installPath = AiSseStreamService.InstallPath;
		if (string.IsNullOrWhiteSpace(installPath))
		{
			return;
		}
		try
		{
			string path = Path.Combine(installPath, ".agent", "skills");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			AppDomain.CurrentDomain.SetData("APPBASE", installPath);
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AI] Prepare agent runtime base directory failed: " + ex.Message);
		}
	}

	private static void CleanupAndShutdown(bool P_0)
	{
		_isShuttingDown = true;
		try
		{
			try
			{
				CustomTaskPaneCollection customTaskPaneCollection = UiHelper_1.ThisAddIn?.D8nlJJriq;
				if (customTaskPaneCollection != null)
				{
					for (int num = customTaskPaneCollection.Count - 1; num >= 0; num--)
					{
						CustomTaskPane customTaskPane = customTaskPaneCollection[num];
						if (IsAssistantPane(customTaskPane))
						{
							CloseAndDisposePane(customTaskPane);
						}
					}
				}
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogWarn("[AI] Task pane cleanup failed: " + ex.Message);
			}
			try
			{
				foreach (PaneBridgeHolder value in _paneBridges.Values)
				{
					try
					{
						value.Dispose();
					}
					catch (Exception ex2)
					{
						AiConfigBootstrap.LogWarn("[AI] Bridge cleanup failed: " + ex2.Message);
					}
				}
				_paneBridges.Clear();
			}
			catch (Exception ex3)
			{
				AiConfigBootstrap.LogWarn("[AI] Bridge cleanup loop failed: " + ex3.Message);
			}
			if (P_0)
			{
				IntranetAiConfigService.Instance.ResetAuthState();
			}
			_isInitialized = false;
		}
		finally
		{
			_isShuttingDown = false;
		}
	}

	static AiAssistantHost2()
	{
		SseStreamInitializer.InitializeRuntime();
		_syncLock = new object();
		_closingPanes = new HashSet<CustomTaskPane>();
		_paneBridges = new Dictionary<string, PaneBridgeHolder>(StringComparer.OrdinalIgnoreCase);
	}
}
