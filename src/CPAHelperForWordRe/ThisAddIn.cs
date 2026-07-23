using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Threading;
using AiAssistantHost2;
using AiHelper_6;
using CPAHelperForWordRe.UI.Forms;
using CPAHelperForWordRe.UI.Ribbon;
using ShutdownStepRunner;
using AiConfigBootstrap;
using AiHelper_4;
using ScreenshotService;
using TableBorderConfig;
using AiSseStreamService3;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Tools.Word;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using SseStreamInitializer;
using HttpHelper_2;
using AiSseStreamService;
using WordTableToolService;
using UiHelper_1;
using ExcelDataSyncService;
using UiHelperService;
using StartupStepRunner;
using AiHelper_13;

namespace CPAHelperForWordRe;

[StartupObject(0)]
[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
public sealed class ThisAddIn : AddInBase
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_0
	{
		public ProgressWindow j1lFcKHKOf;

		public _G_c__DisplayClass10_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void Xi9F5XpDUc(object _, RoutedEventArgs __)
		{
			j1lFcKHKOf.Dispatcher.BeginInvoke(new System.Action(j1lFcKHKOf.Close), DispatcherPriority.ApplicationIdle);
		}
	}

	private static readonly Uri ugVtXaQGa;

	private readonly ShutdownStepRunner XvXL2tl66;

	private readonly StartupStepRunner QDMsw544U;

	internal CustomTaskPaneCollection D8nlJJriq;

	internal SmartTagCollection tXBNqmaPS;

	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	private object mu1mGcWsS;

	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	internal Microsoft.Office.Interop.Word.Application fM3oNckkd;

	private void UdYQeZUJM(object P_0, EventArgs P_1)
	{
		try
		{
			AiConfigBootstrap.nCOs10kYTP();
			XvXL2tl66.CdpsaonsgL("刷新并关闭日志", AiConfigBootstrap.pnHsrIThtj);
			ScRJrclkY();
			HttpHelper_2.BNmLxKn8Mc();
			WordTableToolService.wTdsm97f8t(fM3oNckkd, SynchronizationContext.Current);
			AiSseStreamService.VyDsR9yN8r();
			AiSseStreamService.i24sVuaOic(AiSseStreamService.ConfigDir);
			QDMsw544U.f5nsePaaOi("加载配置", delegate
			{
				TableBorderConfig.Current.GZ2SaDxkVl();
			});
			QDMsw544U.f5nsePaaOi("刷新 Ribbon 标题", CompositeRibbonExtensibility.S0ZyWdvYIm);
			QDMsw544U.f5nsePaaOi("初始化轻量 AI 入口", AiAssistantHost2.GG6Bqc5aMd);
			QDMsw544U.f5nsePaaOi("初始化 OfficeTab", delegate
			{
				if (TableBorderConfig.Current.Config.OfficeTab.Enabled)
				{
					AiHelper_13.EnuUgD338d();
				}
			});
			QDMsw544U.f5nsePaaOi("应用桌面钉图热键", delegate
			{
				if (!ScreenshotService.o6HBH667NB(out var text) && !string.IsNullOrWhiteSpace(text))
				{
					AiConfigBootstrap.z7Us3dJ6Cl("恢复 Excel 同步右键菜单" + text);
				}
			});
			QDMsw544U.f5nsePaaOi("启动自动检查更新", ExcelDataSyncService.K5NXSH2mgl);
			QDMsw544U.f5nsePaaOi("[Startup] IP_Assurance started; Version=", AiHelper_6.uJJLaq5Qdq);
			QDMsw544U.DQUsymt3gA();
			AiConfigBootstrap.swCsJ4IbrL("; Host=" + typeof(ThisAddIn).Assembly.GetName().Version?.ToString() + "Word" + (WordTableToolService.IsWps ? "WPS" : ""));
			Y813TQXXJ();
			XvXL2tl66.CdpsaonsgL("清理 OfficeTab", AiAssistantHost2.oCK9RZLXy4);
			XvXL2tl66.CdpsaonsgL("清理桌面钉图", AiHelper_13.PSkUiNYvdJ);
			XvXL2tl66.CdpsaonsgL("清理 Excel 同步右键菜单", ScreenshotService.jTmBQtWvhT);
			XvXL2tl66.CdpsaonsgL("清理系统托盘通知", ExcelDataSyncService.MXSXtSr5ZG);
			XvXL2tl66.CdpsaonsgL("清理 WPF 键盘钩子", UiHelperService.OpbcFWIPED);
			XvXL2tl66.CdpsaonsgL("DocumentOpen", AiHelper_4.EdjVoDIVbd);
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentOpen").AddEventHandler(fM3oNckkd, new ApplicationEvents4_DocumentOpenEventHandler(qZSrdDKvR));
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.ujWsURly3F("刷新并关闭日志", ex);
		}
	}

	private void R0T1ToAAD(object P_0, EventArgs P_1)
	{
		try
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentOpen").RemoveEventHandler(fM3oNckkd, new ApplicationEvents4_DocumentOpenEventHandler(qZSrdDKvR));
			XvXL2tl66.wCBsq1dqWy();
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.ujWsURly3F("[Shutdown] Failure", ex);
		}
	}

	private void qZSrdDKvR(Microsoft.Office.Interop.Word.Document P_0)
	{
		try
		{
			if (P_0 == null || !TableBorderConfig.Current.Config.System.DisableAutomaticStyleUpdate)
			{
				return;
			}
			foreach (Microsoft.Office.Interop.Word.Style style in P_0.Styles)
			{
				try
				{
					style.AutomaticallyUpdate = false;
				}
				catch
				{
				}
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.ujWsURly3F("[DocumentOpen]", ex);
		}
	}

	protected override IRibbonExtension[] CreateRibbonObjects()
	{
		return new IRibbonExtension[1] { (IRibbonExtension)new Ribbon1() };
	}

	protected override IRibbonExtensibility CreateRibbonExtensibilityObject()
	{
		return new CompositeRibbonExtensibility(UiHelper_1.Factory.GetRibbonFactory().CreateRibbonManager(this.CreateRibbonObjects()));
	}

	private static void ScRJrclkY()
	{
		System.Windows.Application application = System.Windows.Application.Current;
		if (application == null)
		{
			application = new System.Windows.Application
			{
				ShutdownMode = ShutdownMode.OnExplicitShutdown
			};
		}
		else if (application.ShutdownMode != ShutdownMode.OnExplicitShutdown)
		{
			application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
		}
		for (int i = 0; i < application.Resources.MergedDictionaries.Count; i++)
		{
			if (application.Resources.MergedDictionaries[i]?.Source == ugVtXaQGa)
			{
				return;
			}
		}
		application.Resources.MergedDictionaries.Insert(0, new ResourceDictionary
		{
			Source = ugVtXaQGa
		});
	}

	private static void Y813TQXXJ()
	{
		System.Windows.Application.Current?.Dispatcher.BeginInvoke(new System.Action(vknUEKULj), DispatcherPriority.ApplicationIdle);
	}

	private static void vknUEKULj()
	{
		try
		{
			_G_c__DisplayClass10_0 CS_8_locals_6 = new _G_c__DisplayClass10_0();
			CS_8_locals_6.j1lFcKHKOf = new ProgressWindow
			{
				ShowActivated = false,
				ShowInTaskbar = false,
				WindowStartupLocation = WindowStartupLocation.Manual,
				Left = -20000.0,
				Top = -20000.0,
				Opacity = 0.0
			};
			ElementHost.EnableModelessKeyboardInterop(CS_8_locals_6.j1lFcKHKOf);
			CS_8_locals_6.j1lFcKHKOf.Loaded += delegate
			{
				CS_8_locals_6.j1lFcKHKOf.Dispatcher.BeginInvoke(new System.Action(CS_8_locals_6.j1lFcKHKOf.Close), DispatcherPriority.ApplicationIdle);
			};
			CS_8_locals_6.j1lFcKHKOf.Show();
		}
		catch (Exception)
		{
		}
	}

	private void vZuKpag9F()
	{
		base.Startup += UdYQeZUJM;
		base.Shutdown += R0T1ToAAD;
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ThisAddIn(ApplicationFactory factory, IServiceProvider serviceProvider) : base((Microsoft.Office.Tools.Factory)factory, serviceProvider, "加载配置", "刷新 Ribbon 标题")
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		XvXL2tl66 = new ShutdownStepRunner();
		QDMsw544U = new StartupStepRunner();
		mu1mGcWsS = Type.Missing;
		UiHelper_1.Factory = factory;
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	protected override void Initialize()
	{
		base.Initialize();
		fM3oNckkd = GetHostItem<Microsoft.Office.Interop.Word.Application>(typeof(Microsoft.Office.Interop.Word.Application), "Application");
		UiHelper_1.ThisAddIn = this;
		System.Windows.Forms.Application.EnableVisualStyles();
		N1SEFfDNL();
		ViYbWSnJh();
		KpFSeVaRV();
		v2R2e0Rxp();
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	protected override void FinishInitialization()
	{
		vZuKpag9F();
		OnStartup();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	[DebuggerNonUserCode]
	protected override void InitializeDataBindings()
	{
		srofkR91K();
		rxN46k12d();
		uxSMWgduF();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private void N1SEFfDNL()
	{
		if (base.DataHost != null && base.DataHost.IsCacheInitialized)
		{
			base.DataHost.FillCachedData(this);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	[DebuggerNonUserCode]
	private void v2R2e0Rxp()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	private void rxN46k12d()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerNonUserCode]
	private void iORjcWvUN(string P_0)
	{
		base.DataHost.StartCaching(this, P_0);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerNonUserCode]
	private void KYiY6mImB(string P_0)
	{
		base.DataHost.StopCaching(this, P_0);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerNonUserCode]
	private bool nZQZSy8jw(string P_0)
	{
		return base.DataHost.IsCached(this, P_0);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	private void srofkR91K()
	{
		BeginInit();
		D8nlJJriq.BeginInit();
		tXBNqmaPS.BeginInit();
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	private void uxSMWgduF()
	{
		tXBNqmaPS.EndInit();
		D8nlJJriq.EndInit();
		EndInit();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	[DebuggerNonUserCode]
	private void ViYbWSnJh()
	{
		D8nlJJriq = UiHelper_1.Factory.CreateCustomTaskPaneCollection(null, null, "CustomTaskPanes", "CustomTaskPanes", this);
		tXBNqmaPS = UiHelper_1.Factory.CreateSmartTagCollection(null, null, "VstoSmartTags", "VstoSmartTags", this);
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	private void KpFSeVaRV()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerNonUserCode]
	private bool cQuwWnbb7(string P_0)
	{
		return base.DataHost.NeedsFill(this, P_0);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override void OnShutdown()
	{
		tXBNqmaPS.Dispose();
		D8nlJJriq.Dispose();
		base.OnShutdown();
	}

	static ThisAddIn()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		ugVtXaQGa = new Uri("/CPAHelperForWordRe;component/UI/Themes/EnterprisePanelTheme.xaml", UriKind.Relative);
	}
}
