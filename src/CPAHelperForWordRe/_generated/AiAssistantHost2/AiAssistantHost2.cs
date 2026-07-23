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
	private sealed class RXCwJGhHcxjX0yklsaw : IDisposable
	{
		[CompilerGenerated]
		private DesktopAiBridgeServer zxQhQDWnk2;

		[CompilerGenerated]
		private ServiceProvider _serviceProvider;

		public DesktopAiBridgeServer Server
		{
			[CompilerGenerated]
			get
			{
				return zxQhQDWnk2;
			}
			[CompilerGenerated]
			set
			{
				zxQhQDWnk2 = value;
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

		public RXCwJGhHcxjX0yklsaw()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_0
	{
		public AiTargetBinder OTthKVmcnx;

		public WordAgentRuntimeGuard TKPhEGXwHy;

		public _G_c__DisplayClass10_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void OgDhU55L8X(AgentArtifact artifact)
		{
			_G_c__DisplayClass10_1 CS_8_locals_4 = new _G_c__DisplayClass10_1();
			CS_8_locals_4._G_c__DisplayClass10_0 = this;
			CS_8_locals_4.agentArtifact = artifact;
			TKPhEGXwHy.InvokeOnUiThread(delegate
			{
				AiHelper_17.VYkUViDjLf(CS_8_locals_4._G_c__DisplayClass10_0.OTthKVmcnx, CS_8_locals_4.agentArtifact);
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

		internal void rIIh2mrLbO()
		{
			AiHelper_17.VYkUViDjLf(_G_c__DisplayClass10_0.OTthKVmcnx, agentArtifact);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_0
	{
		public AiTargetBinder OOrhMhZJqR;

		public _G_c__DisplayClass28_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_15 EfkhYTMjkF(IServiceProvider _)
		{
			return new AiHelper_15(OOrhMhZJqR);
		}

		internal BatchReplaceService2 frBhZbbW1E(IServiceProvider _)
		{
			return new BatchReplaceService2(OOrhMhZJqR);
		}

		internal WpsVbaCompatService v1WhfuhFUu(IServiceProvider _)
		{
			return new WpsVbaCompatService(OOrhMhZJqR);
		}
	}

	private static readonly object CTS91vctKd;

	private static readonly HashSet<CustomTaskPane> Spc9riTU3E;

	private static readonly Dictionary<string, RXCwJGhHcxjX0yklsaw> HSw9JKPvWP;

	private static bool uyS93RQrn8;

	private static bool vyT9UyqU67;

	public static void GG6Bqc5aMd()
	{
		FileDownloadHelper.Current.t9vwx1YSVk();
	}

	public static bool UnXBPRAlgg()
	{
		if (uyS93RQrn8)
		{
			return true;
		}
		lock (CTS91vctKd)
		{
			if (uyS93RQrn8)
			{
				return true;
			}
			try
			{
				HttpHelper_2.BNmLxKn8Mc();
				wEr9HlqmQE();
				FileDownloadHelper.Current.t9vwx1YSVk();
				if (!IntranetAiConfigService.Instance.gDh6IIK89w())
				{
					AiConfigBootstrap.LogInfo("Agent initialization aborted because intranet authentication was not completed.");
					return false;
				}
				JsonSessionIndexManager.Initialize(AiSseStreamService.GetUserDataPath("Agent", "chat-sessions"));
				uyS93RQrn8 = true;
				return true;
			}
			catch (Exception ex)
			{
				RAo9QloHrl( false);
				AiConfigBootstrap.LogError("[AI] Agent initialization failed", ex);
				LoggerInitializer.ShowError("AI 助手初始化失败，请检查配置、网络环境和日志后重试。\r\n" + ex.Message, "AI 助手");
				return false;
			}
		}
	}

	public static DesktopAiBridgeServer liEBA242hS()
	{
		return mJIBvnaH0F(null);
	}

	public static DesktopAiBridgeServer mJIBvnaH0F(AiTargetBinder P_0)
	{
		_G_c__DisplayClass10_0 CS_8_locals_14 = new _G_c__DisplayClass10_0();
		CS_8_locals_14.OTthKVmcnx = P_0;
		if (!UnXBPRAlgg())
		{
			return null;
		}
		lock (CTS91vctKd)
		{
			string text = tvS9IeFZ37(CS_8_locals_14.OTthKVmcnx);
			if (HSw9JKPvWP.TryGetValue(text, out var value))
			{
				return value.Server;
			}
			ServiceProvider serviceProvider = null;
			DesktopAiBridgeServer desktopAiBridgeServer = null;
			try
			{
				CS_8_locals_14.TKPhEGXwHy = new WordAgentRuntimeGuard(CS_8_locals_14.OTthKVmcnx);
				HostActionDispatcher dguCpUJyDDpMGwLPwHA = new HostActionDispatcher(CS_8_locals_14.OTthKVmcnx);
				serviceProvider = yeJ9iDW5Vn(CS_8_locals_14.OTthKVmcnx, CS_8_locals_14.TKPhEGXwHy, dguCpUJyDDpMGwLPwHA);
				desktopAiBridgeServer = new DesktopAiBridgeServer(serviceProvider.GetRequiredService<AgentRuntime>(), serviceProvider.GetRequiredService<IAgentConfigProvider>(), serviceProvider.GetRequiredService<IAgentInstructionBuilder>(), instructionContextFactory: serviceProvider.GetRequiredService<AiHelper_19>().QhF3fbjxg1, hostContext: CS_8_locals_14.TKPhEGXwHy, onArtifact: delegate(AgentArtifact artifact)
				{
					_G_c__DisplayClass10_1 CS_8_locals_16 = new _G_c__DisplayClass10_1();
					CS_8_locals_16._G_c__DisplayClass10_0 = CS_8_locals_14;
					CS_8_locals_16.agentArtifact = artifact;
					CS_8_locals_14.TKPhEGXwHy.InvokeOnUiThread(delegate
					{
						AiHelper_17.VYkUViDjLf(CS_8_locals_16._G_c__DisplayClass10_0.OTthKVmcnx, CS_8_locals_16.agentArtifact);
					});
				}, hostActionProvider: dguCpUJyDDpMGwLPwHA);
				desktopAiBridgeServer.Start();
				HSw9JKPvWP[text] = new RXCwJGhHcxjX0yklsaw
				{
					Server = desktopAiBridgeServer,
					ServiceProvider = serviceProvider
				};
				AiConfigBootstrap.LogInfo("[AI] Pane bridge started. Key=" + text + "; Port=" + desktopAiBridgeServer.Port + "; Target=" + (CS_8_locals_14.OTthKVmcnx?.DisplayName ?? "(active)"));
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

	public static void Kf7BW0nRZX(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return;
		}
		lock (CTS91vctKd)
		{
			if (HSw9JKPvWP.TryGetValue(P_0, out var value))
			{
				HSw9JKPvWP.Remove(P_0);
				value.Dispose();
			}
		}
	}

	public static void aRJB0cfkok()
	{
		if (!UnXBPRAlgg() || !IntranetAiConfigService.Instance.gDh6IIK89w())
		{
			return;
		}
		try
		{
			Window window;
			AiTargetBinder rkZt4ZuLjXTP5cAL48p;
			CustomTaskPane customTaskPane = Im899AXlNf(out window, out rkZt4ZuLjXTP5cAL48p);
			if (window == null || rkZt4ZuLjXTP5cAL48p == null || string.IsNullOrWhiteSpace(rkZt4ZuLjXTP5cAL48p.WindowKey))
			{
				LoggerInitializer.ShowWarning("当前没有可用的 Word 文档窗口，无法打开 AI 助手。", "AI 助手");
				return;
			}
			if (customTaskPane == null)
			{
				customTaskPane = DCV9BmThLi(window, rkZt4ZuLjXTP5cAL48p);
			}
			else
			{
				if (customTaskPane.Visible)
				{
					TXh9TEEUCx(customTaskPane);
					return;
				}
				customTaskPane.Visible = true;
			}
			if (customTaskPane.Visible && customTaskPane.Control is AiAssistantHost yS7xFb3LM4W2adGhkTa)
			{
				yS7xFb3LM4W2adGhkTa.nb43Nxg93w();
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[AI] Open assistant pane failed", ex);
			LoggerInitializer.ShowError("打开 AI 助手失败：\r\n" + ex.Message, "AI 助手");
		}
	}

	public static void v7iBkI3KGG()
	{
		if (!UnXBPRAlgg() || !IntranetAiConfigService.Instance.gDh6IIK89w())
		{
			return;
		}
		try
		{
			Window window;
			AiTargetBinder rkZt4ZuLjXTP5cAL48p;
			CustomTaskPane customTaskPane = Im899AXlNf(out window, out rkZt4ZuLjXTP5cAL48p);
			if (window != null && rkZt4ZuLjXTP5cAL48p != null && !string.IsNullOrWhiteSpace(rkZt4ZuLjXTP5cAL48p.WindowKey))
			{
				if (customTaskPane == null)
				{
					customTaskPane = DCV9BmThLi(window, rkZt4ZuLjXTP5cAL48p);
				}
				else if (!customTaskPane.Visible)
				{
					customTaskPane.Visible = true;
				}
				if (customTaskPane.Control is AiAssistantHost yS7xFb3LM4W2adGhkTa)
				{
					yS7xFb3LM4W2adGhkTa.nb43Nxg93w();
				}
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AI] Ensure assistant pane visible failed: " + ex.Message);
		}
	}

	public static void zRLBxbssPX(AiTargetBinder P_0)
	{
		if (P_0 == null)
		{
			v7iBkI3KGG();
		}
		else
		{
			if (!UnXBPRAlgg() || !IntranetAiConfigService.Instance.gDh6IIK89w())
			{
				return;
			}
			try
			{
				CustomTaskPane customTaskPane = mEd96aKH0D(P_0.WindowKey);
				if (customTaskPane == null)
				{
					Window window = P_0.l1ouC0fgct(WordTableToolService.WordApp);
					if (window == null)
					{
						return;
					}
					customTaskPane = DCV9BmThLi(window, P_0);
				}
				else if (!customTaskPane.Visible)
				{
					customTaskPane.Visible = true;
				}
				if (customTaskPane.Control is AiAssistantHost yS7xFb3LM4W2adGhkTa)
				{
					yS7xFb3LM4W2adGhkTa.nb43Nxg93w();
				}
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogWarn("[AI] Ensure target assistant pane visible failed: " + ex.Message);
			}
		}
	}

	public static void SIRBdRBylk()
	{
		WordTableToolService5.ShowWpfWindow(new AIAssistantConfigWindow());
	}

	public static void KAcBz9syTd()
	{
		AiHelper_3.BWIBRayGaa();
	}

	public static void oCK9RZLXy4()
	{
		lock (CTS91vctKd)
		{
			RAo9QloHrl( true);
		}
	}

	private static void ePA9VbeQpk(object P_0, EventArgs P_1)
	{
		if (P_0 is CustomTaskPane customTaskPane && !Spc9riTU3E.Contains(customTaskPane))
		{
			if (customTaskPane.Visible && customTaskPane.Control is AiAssistantHost yS7xFb3LM4W2adGhkTa)
			{
				yS7xFb3LM4W2adGhkTa.nb43Nxg93w();
			}
			else
			{
				TXh9TEEUCx(customTaskPane);
			}
		}
	}

	private static CustomTaskPane DCV9BmThLi(Window P_0, AiTargetBinder P_1)
	{
		P_1 = P_1 ?? AiTargetBinder.wvGulrEfed(P_0);
		AiAssistantHost control = new AiAssistantHost
		{
			Target = P_1,
			WindowKey = P_1?.WindowKey
		};
		CustomTaskPane customTaskPane = UiHelper_1.ThisAddIn.D8nlJJriq.Add(control, Helper_21.CurrentTitle, P_0);
		customTaskPane.Width = 560;
		customTaskPane.VisibleChanged += ePA9VbeQpk;
		customTaskPane.Visible = true;
		return customTaskPane;
	}

	private static CustomTaskPane Im899AXlNf(out Window P_0, out AiTargetBinder P_1)
	{
		if (!bqr9uehUpM(out P_0, out P_1))
		{
			return null;
		}
		return mEd96aKH0D(P_1.WindowKey);
	}

	private static CustomTaskPane mEd96aKH0D(string P_0)
	{
		CustomTaskPaneCollection customTaskPaneCollection = UiHelper_1.ThisAddIn?.D8nlJJriq;
		if (customTaskPaneCollection == null)
		{
			return null;
		}
		for (int num = customTaskPaneCollection.Count - 1; num >= 0; num--)
		{
			CustomTaskPane customTaskPane = customTaskPaneCollection[num];
			if (X3S9DYhJgI(customTaskPane) && customTaskPane.Control is AiAssistantHost yS7xFb3LM4W2adGhkTa && string.Equals(yS7xFb3LM4W2adGhkTa.WindowKey, P_0, StringComparison.OrdinalIgnoreCase))
			{
				return customTaskPane;
			}
		}
		return null;
	}

	private static bool bqr9uehUpM(out Window P_0, out AiTargetBinder P_1)
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
			P_1 = AiTargetBinder.wvGulrEfed(P_0);
			return P_0 != null && P_1 != null && !string.IsNullOrWhiteSpace(P_1.WindowKey);
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AI] Unable to resolve active Word window for assistant pane: " + ex.Message);
			return false;
		}
	}

	private static bool X3S9DYhJgI(CustomTaskPane P_0)
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

	private static void TXh9TEEUCx(CustomTaskPane P_0)
	{
		if (P_0 == null || Spc9riTU3E.Contains(P_0))
		{
			return;
		}
		Spc9riTU3E.Add(P_0);
		try
		{
			P_0.VisibleChanged -= ePA9VbeQpk;
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
				if (P_0.Control is AiAssistantHost yS7xFb3LM4W2adGhkTa)
				{
					Kf7BW0nRZX(yS7xFb3LM4W2adGhkTa.WindowKey);
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
			Spc9riTU3E.Remove(P_0);
		}
		eFR9gjrSke();
	}

	private static void eFR9gjrSke()
	{
		if (!vyT9UyqU67 && !q5U98g8CvW())
		{
			oCK9RZLXy4();
			AiConfigBootstrap.LogInfo("All AI panes closed and bootstrapper shutdown completed.");
		}
	}

	private static bool q5U98g8CvW()
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
				if (X3S9DYhJgI(customTaskPaneCollection[num]))
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

	private static string tvS9IeFZ37(AiTargetBinder P_0)
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

	private static ServiceProvider yeJ9iDW5Vn(AiTargetBinder P_0, WordAgentRuntimeGuard P_1, HostActionDispatcher P_2)
	{
		_G_c__DisplayClass28_0 CS_8_locals_5 = new _G_c__DisplayClass28_0();
		CS_8_locals_5.OOrhMhZJqR = P_0;
		ServiceCollection services = new ServiceCollection();
		services.AddSingleton<IAgentConfigProvider, AiSseStreamService5>();
		services.AddSingleton<IAgentInstructionBuilder, AiConfigManager2>();
		services.AddSingleton(new WordTableToolService4(CS_8_locals_5.OOrhMhZJqR));
		services.AddSingleton<AiHelper_19>();
		((IServiceCollection)services).AddSingleton((Func<IServiceProvider, Func<AgentInstructionContext>>)((IServiceProvider sp) => sp.GetRequiredService<AiHelper_19>().QhF3fbjxg1));
		((IServiceCollection)services).AddSingleton((IHostContext)P_1);
		((IServiceCollection)services).AddSingleton((IHostActionProvider)P_2);
		services.AddSingleton<IArtifactSink, ArtifactSinkRelay>();
		services.AddSingleton<IChatHistoryStoreFactory, JsonChatHistoryStoreFactory>();
		services.AddSingleton((IServiceProvider _) => new AiHelper_15(CS_8_locals_5.OOrhMhZJqR));
		services.AddSingleton((IServiceProvider _) => new BatchReplaceService2(CS_8_locals_5.OOrhMhZJqR));
		services.AddSingleton<AiConfigBootstrap2>();
		services.AddSingleton((IServiceProvider _) => new WpsVbaCompatService(CS_8_locals_5.OOrhMhZJqR));
		services.AddSingleton<IToolProvider, WordContextPreviewService>();
		services.AddSingleton<IToolProvider, ExcelReadonlyService>();
		services.AddSingleton<IToolProvider, VbaValidationService>();
		services.AddSingleton<IToolProvider, CliCommandService>();
		services.AddSingleton<ISubAgentCatalog, SubAgentCatalog>();
		services.AddAgentRuntime();
		return services.BuildServiceProvider();
	}

	private static void wEr9HlqmQE()
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

	private static void RAo9QloHrl(bool P_0)
	{
		vyT9UyqU67 = true;
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
						if (X3S9DYhJgI(customTaskPane))
						{
							TXh9TEEUCx(customTaskPane);
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
				foreach (RXCwJGhHcxjX0yklsaw value in HSw9JKPvWP.Values)
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
				HSw9JKPvWP.Clear();
			}
			catch (Exception ex3)
			{
				AiConfigBootstrap.LogWarn("[AI] Bridge cleanup loop failed: " + ex3.Message);
			}
			if (P_0)
			{
				IntranetAiConfigService.Instance.ySW62EK2TU();
			}
			uyS93RQrn8 = false;
		}
		finally
		{
			vyT9UyqU67 = false;
		}
	}

	static AiAssistantHost2()
	{
		SseStreamInitializer.InitializeRuntime();
		CTS91vctKd = new object();
		Spc9riTU3E = new HashSet<CustomTaskPane>();
		HSw9JKPvWP = new Dictionary<string, RXCwJGhHcxjX0yklsaw>(StringComparer.OrdinalIgnoreCase);
	}
}
