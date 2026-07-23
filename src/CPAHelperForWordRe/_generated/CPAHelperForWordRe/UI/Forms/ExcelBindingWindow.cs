using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using gLbVIZKLH6Vb5OK2mnj;
using hJKpQrVSwRwMyI2RyDQN;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;
using w5Oql9FwFDU9FYHJXvj;
using wRnHPKcpkuhmwE9uGcA;
using YNri0QclKMfRh2PQoZV;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ExcelBindingWindow : System.Windows.Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass11_0
	{
		public int Q8YV4baVqTg;

		public _G_c__DisplayClass11_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs bb0V4MBOfUG()
		{
			return Jk2boJKtvpW0C9HFNVs.EER4smmpHc(Q8YV4baVqTg);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass20_0
	{
		public Func<Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs> PEgV4ww3jf2;

		public Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs k0RV4tJnAor;

		public _G_c__DisplayClass20_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void TpSV4S7gC3R()
		{
			k0RV4tJnAor = PEgV4ww3jf2();
		}
	}

	private bool Xf9pUsaY5v;

	private bool awIpKKeenS;

	private readonly DispatcherTimer g7xpE5l5VU;

	private Microsoft.Office.Interop.Word.Application Nhfp2FDw6q;

	private bool wg4p4d1yTc;

	internal TextBox txtWordStatus;

	internal TextBox txtWordTable;

	internal TextBox txtBindingId;

	internal TextBox txtHeaderSetting;

	internal TextBox txtHeaderRows;

	internal TextBox txtExcelStatus;

	internal TextBox txtExcelWorkbook;

	internal TextBox txtExcelSheet;

	internal TextBox txtExcelAddress;

	internal TextBox txtExcelSize;

	internal ProgressBar barProgress;

	internal TextBlock txtStatus;

	internal Button btnRefresh;

	internal Button btnBind;

	internal Button btnRebind;

	internal Button btnUnbind;

	internal Button btnSaveHeaderSetting;

	internal Button btnExportAll;

	private bool cukpjMYtpT;

	public ExcelBindingWindow()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		InitializeComponent();
		g7xpE5l5VU = new DispatcherTimer
		{
			Interval = TimeSpan.FromMilliseconds(150.0)
		};
		g7xpE5l5VU.Tick += osZpDRKqbe;
		base.PreviewKeyDown += delegate(object P_0, KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		base.Loaded += delegate
		{
			Swrp9UUswH();
			gTvpThPsSr( false);
		};
		base.Closed += delegate
		{
			zjdp6Q2yvl();
		};
	}

	private void fVYCkVE8Hn(object P_0, RoutedEventArgs P_1)
	{
		gTvpThPsSr( true);
	}

	private void i3PCxqFXcf(object P_0, RoutedEventArgs P_1)
	{
		JFRpIlKfJO("绑定当前表", () => Jk2boJKtvpW0C9HFNVs.kKW4bxDk3L( false));
	}

	private void UWNCdH6HN4(object P_0, RoutedEventArgs P_1)
	{
		JFRpIlKfJO("重新绑定当前表", () => Jk2boJKtvpW0C9HFNVs.kKW4bxDk3L( true));
	}

	private void gwlCzZ2gdJ(object P_0, RoutedEventArgs P_1)
	{
		if (MessageBox.Show(this, "确定要解除当前 Word 表格的 Excel 绑定吗？\\n\\n只会清理 Word 文档中的绑定信息，不会删除 Excel 工作簿里的名称区域。", "解除绑定", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			JFRpIlKfJO("解除当前表绑定", Jk2boJKtvpW0C9HFNVs.saY4G3LNKR);
		}
	}

	private void xIPpRcfn28(object P_0, RoutedEventArgs P_1)
	{
		JFRpIlKfJO("导出全部表并绑定", () => Jk2boJKtvpW0C9HFNVs.TcXEXakPZc(LaFpiooIwT));
	}

	private void si1pVLpUQE(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass11_0 CS_8_locals_2 = new _G_c__DisplayClass11_0();
		if (EmZpgI6rSj(out CS_8_locals_2.Q8YV4baVqTg))
		{
			JFRpIlKfJO("保存表头设置", () => Jk2boJKtvpW0C9HFNVs.EER4smmpHc(CS_8_locals_2.Q8YV4baVqTg));
		}
	}

	private void veipBw5P5u(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void Swrp9UUswH()
	{
		if (wg4p4d1yTc)
		{
			return;
		}
		Nhfp2FDw6q = eSfxffslhXbaGAjFNv1.WordApp;
		if (Nhfp2FDw6q == null)
		{
			return;
		}
		try
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").AddEventHandler(Nhfp2FDw6q, new ApplicationEvents4_WindowSelectionChangeEventHandler(tdlpuVBwkE));
			wg4p4d1yTc = true;
		}
		catch
		{
		}
	}

	private void zjdp6Q2yvl()
	{
		if (wg4p4d1yTc && Nhfp2FDw6q != null)
		{
			try
			{
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").RemoveEventHandler(Nhfp2FDw6q, new ApplicationEvents4_WindowSelectionChangeEventHandler(tdlpuVBwkE));
			}
			catch
			{
			}
			wg4p4d1yTc = false;
			Nhfp2FDw6q = null;
		}
	}

	private void tdlpuVBwkE(Selection P_0)
	{
		if (Xf9pUsaY5v || !base.IsVisible)
		{
			return;
		}
		try
		{
			base.Dispatcher.BeginInvoke((Action)delegate
			{
				g7xpE5l5VU.Stop();
				g7xpE5l5VU.Start();
			}, DispatcherPriority.Background);
		}
		catch
		{
		}
	}

	private void osZpDRKqbe(object P_0, EventArgs P_1)
	{
		g7xpE5l5VU.Stop();
		if (!Xf9pUsaY5v && base.IsVisible)
		{
			gTvpThPsSr( false);
		}
	}

	private void gTvpThPsSr(bool P_0)
	{
		Jk2boJKtvpW0C9HFNVs.gMo5J5VI9LOS3nqRiEJZ gMo5J5VI9LOS3nqRiEJZ = Jk2boJKtvpW0C9HFNVs.inT4f2XO4S(P_0);
		txtWordStatus.Text = gMo5J5VI9LOS3nqRiEJZ.WordStatus ?? string.Empty;
		txtWordTable.Text = gMo5J5VI9LOS3nqRiEJZ.WordTableLabel ?? string.Empty;
		txtBindingId.Text = (gMo5J5VI9LOS3nqRiEJZ.HasBinding ? gMo5J5VI9LOS3nqRiEJZ.BindingId : "未绑定");
		txtHeaderSetting.Text = gMo5J5VI9LOS3nqRiEJZ.HeaderSettingText ?? string.Empty;
		txtHeaderRows.Text = (gMo5J5VI9LOS3nqRiEJZ.HeaderRowCount.HasValue ? gMo5J5VI9LOS3nqRiEJZ.HeaderRowCount.Value.ToString() : string.Empty);
		XIDp8jhm7h();
		txtExcelStatus.Text = gMo5J5VI9LOS3nqRiEJZ.ExcelStatus ?? string.Empty;
		txtExcelWorkbook.Text = gMo5J5VI9LOS3nqRiEJZ.ExcelWorkbook ?? string.Empty;
		txtExcelSheet.Text = gMo5J5VI9LOS3nqRiEJZ.ExcelSheet ?? string.Empty;
		txtExcelAddress.Text = gMo5J5VI9LOS3nqRiEJZ.ExcelAddress ?? string.Empty;
		txtExcelSize.Text = gMo5J5VI9LOS3nqRiEJZ.ExcelSize ?? string.Empty;
		txtStatus.Text = gMo5J5VI9LOS3nqRiEJZ.Message ?? string.Empty;
		btnBind.IsEnabled = !Xf9pUsaY5v && gMo5J5VI9LOS3nqRiEJZ.HasWordTable && gMo5J5VI9LOS3nqRiEJZ.HasExcelSelection;
		btnRebind.IsEnabled = !Xf9pUsaY5v && gMo5J5VI9LOS3nqRiEJZ.HasWordTable && gMo5J5VI9LOS3nqRiEJZ.HasBinding && gMo5J5VI9LOS3nqRiEJZ.HasExcelSelection;
		btnUnbind.IsEnabled = !Xf9pUsaY5v && gMo5J5VI9LOS3nqRiEJZ.HasWordTable && gMo5J5VI9LOS3nqRiEJZ.HasBinding;
		btnSaveHeaderSetting.IsEnabled = !Xf9pUsaY5v && gMo5J5VI9LOS3nqRiEJZ.HasWordTable && gMo5J5VI9LOS3nqRiEJZ.HasBinding;
	}

	private bool EmZpgI6rSj(out int P_0)
	{
		P_0 = 0;
		if (!int.TryParse((txtHeaderRows.Text ?? string.Empty).Trim(), out var result) || result < 0)
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("表头行数请输入 0 或正整数。", "IP_Assurance");
			txtHeaderRows.Focus();
			txtHeaderRows.SelectAll();
			return false;
		}
		P_0 = result;
		return true;
	}

	private void XIDp8jhm7h()
	{
		txtHeaderRows.IsEnabled = !Xf9pUsaY5v;
	}

	private void JFRpIlKfJO(string P_0, Func<Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs> P_1)
	{
		_G_c__DisplayClass20_0 CS_8_locals_8 = new _G_c__DisplayClass20_0();
		CS_8_locals_8.PEgV4ww3jf2 = P_1;
		if (Xf9pUsaY5v || CS_8_locals_8.PEgV4ww3jf2 == null)
		{
			return;
		}
		fTPpHNZh29( true);
		awIpKKeenS = false;
		barProgress.Value = 0.0;
		txtStatus.Text = "正在处理...";
		try
		{
			CS_8_locals_8.k0RV4tJnAor = null;
			okTG2rFSnxjcTsuMG3L.sY9FLcxGhc(delegate
			{
				CS_8_locals_8.k0RV4tJnAor = CS_8_locals_8.PEgV4ww3jf2();
			}, P_0);
			if (CS_8_locals_8.k0RV4tJnAor != null)
			{
				txtStatus.Text = CS_8_locals_8.k0RV4tJnAor.Message ?? string.Empty;
				un7uUxcCbw6Q36geOYj.CsKcO7u6di(CS_8_locals_8.k0RV4tJnAor, "Excel同步");
			}
		}
		finally
		{
			fTPpHNZh29( false);
			gTvpThPsSr( false);
		}
	}

	private bool LaFpiooIwT(int P_0, int P_1, string P_2)
	{
		int num = ((P_1 <= 0) ? 100 : ((int)Math.Round((double)P_0 * 100.0 / (double)P_1)));
		if (num < 0)
		{
			num = 0;
		}
		if (num > 100)
		{
			num = 100;
		}
		barProgress.Value = num;
		txtStatus.Text = P_2 ?? string.Empty;
		try
		{
			base.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
		}
		catch
		{
		}
		if (!awIpKKeenS)
		{
			return base.IsVisible;
		}
		return false;
	}

	private void fTPpHNZh29(bool P_0)
	{
		Xf9pUsaY5v = P_0;
		base.Cursor = (P_0 ? Cursors.Wait : null);
		btnRefresh.IsEnabled = !P_0;
		btnBind.IsEnabled = !P_0;
		btnRebind.IsEnabled = !P_0;
		btnUnbind.IsEnabled = !P_0;
		btnSaveHeaderSetting.IsEnabled = !P_0;
		btnExportAll.IsEnabled = !P_0;
		XIDp8jhm7h();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!cukpjMYtpT)
		{
			cukpjMYtpT = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/excelbindingwindow.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			txtWordStatus = (TextBox)target;
			break;
		case 2:
			txtWordTable = (TextBox)target;
			break;
		case 3:
			txtBindingId = (TextBox)target;
			break;
		case 4:
			txtHeaderSetting = (TextBox)target;
			break;
		case 5:
			txtHeaderRows = (TextBox)target;
			break;
		case 6:
			txtExcelStatus = (TextBox)target;
			break;
		case 7:
			txtExcelWorkbook = (TextBox)target;
			break;
		case 8:
			txtExcelSheet = (TextBox)target;
			break;
		case 9:
			txtExcelAddress = (TextBox)target;
			break;
		case 10:
			txtExcelSize = (TextBox)target;
			break;
		case 11:
			barProgress = (ProgressBar)target;
			break;
		case 12:
			txtStatus = (TextBlock)target;
			break;
		case 13:
			btnRefresh = (Button)target;
			btnRefresh.Click += fVYCkVE8Hn;
			break;
		case 14:
			btnBind = (Button)target;
			btnBind.Click += i3PCxqFXcf;
			break;
		case 15:
			btnRebind = (Button)target;
			btnRebind.Click += UWNCdH6HN4;
			break;
		case 16:
			btnUnbind = (Button)target;
			btnUnbind.Click += gwlCzZ2gdJ;
			break;
		case 17:
			btnSaveHeaderSetting = (Button)target;
			btnSaveHeaderSetting.Click += si1pVLpUQE;
			break;
		case 18:
			btnExportAll = (Button)target;
			btnExportAll.Click += xIPpRcfn28;
			break;
		case 19:
			((Button)target).Click += veipBw5P5u;
			break;
		default:
			cukpjMYtpT = true;
			break;
		}
	}

	[CompilerGenerated]
	private void SbGpQqqqem(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void Ibip12QX8x(object P_0, RoutedEventArgs P_1)
	{
		Swrp9UUswH();
		gTvpThPsSr( false);
	}

	[CompilerGenerated]
	private void t0tprWd9mi(object P_0, EventArgs P_1)
	{
		zjdp6Q2yvl();
	}

	[CompilerGenerated]
	private Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs JbkpJcGTeY()
	{
		return Jk2boJKtvpW0C9HFNVs.TcXEXakPZc(LaFpiooIwT);
	}

	[CompilerGenerated]
	private void eGep3YQwFj()
	{
		g7xpE5l5VU.Stop();
		g7xpE5l5VU.Start();
	}
}
