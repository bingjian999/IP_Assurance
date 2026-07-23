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
using aQChPyBaZdbEBOJn4tr;
using COg0IZLh2s7ArUStIRP;
using CPAHelperForWordRe.UI.Forms;
using CPAHelperForWordRe.UI.Ribbon;
using cw0KtBshN86U0Owd58V;
using dL7TFPsQbAGqPywtHUK;
using e8p1CGVN194FjjKWWIg;
using emAOMVBT4r0jD8Vun2A;
using FiIb7mSOBD13BJBxsh0;
using hJKpQrVSwRwMyI2RyDQN;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Tools.Word;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using ndRERvVtEjasqN2cQqiN;
using P4BD1rLkpPbD4GJiVHK;
using qDDKriLz2Bft1Ehv17i;
using sNVQvmsNbF4pw13wHyu;
using UjKxD9CamCBgjOFybS;
using Vn2FNvXfBBVtqPcjIyB;
using VZXZf1ccDRAexK4cV58;
using yHKZ4oscwrqgArrSJ9K;
using zx0Oj9UTwBfDyTBLk9y;

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
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void Xi9F5XpDUc(object _, RoutedEventArgs __)
		{
			j1lFcKHKOf.Dispatcher.BeginInvoke(new System.Action(j1lFcKHKOf.Close), DispatcherPriority.ApplicationIdle);
		}
	}

	private static readonly Uri ugVtXaQGa;

	private readonly YulCYIsFR7cnsI3O2FF XvXL2tl66;

	private readonly dmUPiks5RapQGMIgwpF QDMsw544U;

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
			yR9thasHZ73xXm8eKwj.nCOs10kYTP();
			XvXL2tl66.CdpsaonsgL("刷新并关闭日志", yR9thasHZ73xXm8eKwj.pnHsrIThtj);
			ScRJrclkY();
			KN3FylL0CcE4FxM6SF8.BNmLxKn8Mc();
			eSfxffslhXbaGAjFNv1.wTdsm97f8t(fM3oNckkd, SynchronizationContext.Current);
			W6xTwMLd5RvSHoqDfEV.VyDsR9yN8r();
			W6xTwMLd5RvSHoqDfEV.i24sVuaOic(W6xTwMLd5RvSHoqDfEV.ConfigDir);
			QDMsw544U.f5nsePaaOi("加载配置", delegate
			{
				ftu1AgSpErBKqc6vp9f.Current.GZ2SaDxkVl();
			});
			QDMsw544U.f5nsePaaOi("刷新 Ribbon 标题", CompositeRibbonExtensibility.S0ZyWdvYIm);
			QDMsw544U.f5nsePaaOi("初始化轻量 AI 入口", RmFJn1BhW81y5YhCApL.GG6Bqc5aMd);
			QDMsw544U.f5nsePaaOi("初始化 OfficeTab", delegate
			{
				if (ftu1AgSpErBKqc6vp9f.Current.Config.OfficeTab.Enabled)
				{
					C2D1AyUDiquViJ7oeR7.EnuUgD338d();
				}
			});
			QDMsw544U.f5nsePaaOi("应用桌面钉图热键", delegate
			{
				if (!T2qy2kBDTEXPmLNlcDc.o6HBH667NB(out var text) && !string.IsNullOrWhiteSpace(text))
				{
					yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("恢复 Excel 同步右键菜单" + text);
				}
			});
			QDMsw544U.f5nsePaaOi("启动自动检查更新", Xwl2EJXZ1waT9LlFYjb.K5NXSH2mgl);
			QDMsw544U.f5nsePaaOi("[Startup] IP_Assurance started; Version=", lZGsUOLFg0eiGa6Xr1Q.uJJLaq5Qdq);
			QDMsw544U.DQUsymt3gA();
			yR9thasHZ73xXm8eKwj.swCsJ4IbrL("; Host=" + typeof(ThisAddIn).Assembly.GetName().Version?.ToString() + "Word" + (eSfxffslhXbaGAjFNv1.IsWps ? "WPS" : ""));
			Y813TQXXJ();
			XvXL2tl66.CdpsaonsgL("清理 OfficeTab", RmFJn1BhW81y5YhCApL.oCK9RZLXy4);
			XvXL2tl66.CdpsaonsgL("清理桌面钉图", C2D1AyUDiquViJ7oeR7.PSkUiNYvdJ);
			XvXL2tl66.CdpsaonsgL("清理 Excel 同步右键菜单", T2qy2kBDTEXPmLNlcDc.jTmBQtWvhT);
			XvXL2tl66.CdpsaonsgL("清理系统托盘通知", Xwl2EJXZ1waT9LlFYjb.MXSXtSr5ZG);
			XvXL2tl66.CdpsaonsgL("清理 WPF 键盘钩子", lRTy9Ic5uax0jm0RR1L.OpbcFWIPED);
			XvXL2tl66.CdpsaonsgL("DocumentOpen", Rd81EOVl9ycTdnhNP7H.EdjVoDIVbd);
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentOpen").AddEventHandler(fM3oNckkd, new ApplicationEvents4_DocumentOpenEventHandler(qZSrdDKvR));
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.ujWsURly3F("刷新并关闭日志", ex);
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
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[Shutdown] Failure", ex);
		}
	}

	private void qZSrdDKvR(Microsoft.Office.Interop.Word.Document P_0)
	{
		try
		{
			if (P_0 == null || !ftu1AgSpErBKqc6vp9f.Current.Config.System.DisableAutomaticStyleUpdate)
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
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[DocumentOpen]", ex);
		}
	}

	protected override IRibbonExtension[] CreateRibbonObjects()
	{
		return new IRibbonExtension[1] { (IRibbonExtension)new Ribbon1() };
	}

	protected override IRibbonExtensibility CreateRibbonExtensibilityObject()
	{
		return new CompositeRibbonExtensibility(d1MIweGrZBnHJqM9I4.Factory.GetRibbonFactory().CreateRibbonManager(this.CreateRibbonObjects()));
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
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		XvXL2tl66 = new YulCYIsFR7cnsI3O2FF();
		QDMsw544U = new dmUPiks5RapQGMIgwpF();
		mu1mGcWsS = Type.Missing;
		d1MIweGrZBnHJqM9I4.Factory = factory;
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
	protected override void Initialize()
	{
		base.Initialize();
		fM3oNckkd = GetHostItem<Microsoft.Office.Interop.Word.Application>(typeof(Microsoft.Office.Interop.Word.Application), "Application");
		d1MIweGrZBnHJqM9I4.ThisAddIn = this;
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
		D8nlJJriq = d1MIweGrZBnHJqM9I4.Factory.CreateCustomTaskPaneCollection(null, null, "CustomTaskPanes", "CustomTaskPanes", this);
		tXBNqmaPS = d1MIweGrZBnHJqM9I4.Factory.CreateSmartTagCollection(null, null, "VstoSmartTags", "VstoSmartTags", this);
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
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		ugVtXaQGa = new Uri("/CPAHelperForWordRe;component/UI/Themes/EnterprisePanelTheme.xaml", UriKind.Relative);
	}
}
