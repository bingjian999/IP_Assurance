using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using dL7TFPsQbAGqPywtHUK;
using gLbVIZKLH6Vb5OK2mnj;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;
using wRnHPKcpkuhmwE9uGcA;
using YNri0QclKMfRh2PQoZV;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ExcelBindingManagerWindow : Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass15_0
	{
		public bool PUdV4md9nvj;

		public Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve oYRV4oOY0tY;

		public string oJ9V4G8gHG9;

		public bool erIV4Ct1Xjp;

		public _G_c__DisplayClass15_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void qI6V4NtifAT()
		{
			PUdV4md9nvj = Jk2boJKtvpW0C9HFNVs.pNqZ2V22ob(oYRV4oOY0tY, out oJ9V4G8gHG9, out erIV4Ct1Xjp);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_0
	{
		public bool SlkV4OsnsvT;

		public Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve yrWV4nJqaqJ;

		public string qH0V47W2Cel;

		public bool t1fV45usruo;

		public _G_c__DisplayClass16_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void YUrV4pI9No4()
		{
			SlkV4OsnsvT = Jk2boJKtvpW0C9HFNVs.jfJEYZIKi1(yrWV4nJqaqJ, out qH0V47W2Cel, out t1fV45usruo);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass5_0
	{
		public ExcelBindingManagerWindow UKJV4eqLFs8;

		public string NH3V4yrc834;

		public _G_c__DisplayClass5_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void MVUV4cIfW7X()
		{
			UKJV4eqLFs8.VOYpZMCNNR(NH3V4yrc834);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass6_0
	{
		public string B4xV4F5SMXX;

		public _G_c__DisplayClass6_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal bool V1kV4XcaKbK(Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve item)
		{
			return string.Equals(item.BindingId, B4xV4F5SMXX, StringComparison.OrdinalIgnoreCase);
		}
	}

	private readonly ObservableCollection<Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve> CcRpOWdY5y;

	private bool rvxpn9nyyL;

	internal ProgressBar barLoading;

	internal DataGrid gridBindings;

	internal TextBlock txtSummary;

	internal Button btnRefresh;

	internal Button btnJumpWord;

	internal Button btnJumpExcel;

	private bool c0mp7QwcuE;

	private Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve SelectedBinding => gridBindings.SelectedItem as Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve;

	public ExcelBindingManagerWindow()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		CcRpOWdY5y = new ObservableCollection<Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve>();
		InitializeComponent();
		gridBindings.ItemsSource = CcRpOWdY5y;
		base.PreviewKeyDown += delegate(object P_0, KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		base.Loaded += delegate
		{
			txtSummary.Text = "正在读取当前文档绑定...";
			base.Dispatcher.BeginInvoke((Action)delegate
			{
				KgdpYSCcQH(null);
			}, DispatcherPriority.ApplicationIdle);
		};
	}

	private void KgdpYSCcQH(string P_0)
	{
		_G_c__DisplayClass5_0 CS_8_locals_4 = new _G_c__DisplayClass5_0();
		CS_8_locals_4.UKJV4eqLFs8 = this;
		CS_8_locals_4.NH3V4yrc834 = P_0 ?? SelectedBinding?.BindingId;
		rvxpn9nyyL = true;
		barLoading.Visibility = Visibility.Visible;
		gridBindings.IsEnabled = false;
		txtSummary.Text = "正在读取当前文档绑定...";
		O3mpMsnbFJ();
		base.Dispatcher.BeginInvoke((Action)delegate
		{
			CS_8_locals_4.UKJV4eqLFs8.VOYpZMCNNR(CS_8_locals_4.NH3V4yrc834);
		}, DispatcherPriority.Background);
	}

	private void VOYpZMCNNR(string P_0)
	{
		_G_c__DisplayClass6_0 CS_8_locals_3 = new _G_c__DisplayClass6_0();
		CS_8_locals_3.B4xV4F5SMXX = P_0;
		try
		{
			CcRpOWdY5y.Clear();
			foreach (Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve item in Jk2boJKtvpW0C9HFNVs.cZEKsyo7XD())
			{
				CcRpOWdY5y.Add(item);
			}
			Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve eEHsHgVgzpw09onBAkve = ((!string.IsNullOrWhiteSpace(CS_8_locals_3.B4xV4F5SMXX)) ? CcRpOWdY5y.FirstOrDefault((Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve item) => string.Equals(item.BindingId, CS_8_locals_3.B4xV4F5SMXX, StringComparison.OrdinalIgnoreCase)) : null);
			gridBindings.SelectedItem = eEHsHgVgzpw09onBAkve ?? CcRpOWdY5y.FirstOrDefault();
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[ExcelSync] Load binding manager failed", ex);
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8("读取绑定列表失败，请保存 Word 文档后重新打开管理窗口。", "IP_Assurance");
		}
		finally
		{
			gridBindings.IsEnabled = true;
			barLoading.Visibility = Visibility.Collapsed;
			rvxpn9nyyL = false;
			QJIpf4tWaW();
			O3mpMsnbFJ();
		}
	}

	private void QJIpf4tWaW()
	{
		int count = CcRpOWdY5y.Count;
		int num = CcRpOWdY5y.Count((Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve item) => string.Equals(item.Status, "共 {0} 个绑定，正常 {1} 个，异常 {2} 个。", StringComparison.OrdinalIgnoreCase));
		txtSummary.Text = ((count == 0) ? "当前文档未发现 Excel 绑定关系。" : string.Format("[ExcelSync] Load binding manager failed", count, num, count - num));
	}

	private void O3mpMsnbFJ()
	{
		Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve selectedBinding = SelectedBinding;
		bool flag = selectedBinding != null;
		btnRefresh.IsEnabled = !rvxpn9nyyL;
		if (rvxpn9nyyL)
		{
			btnJumpWord.IsEnabled = false;
			btnJumpExcel.IsEnabled = false;
		}
		else
		{
			btnJumpWord.IsEnabled = flag && selectedBinding.CanJumpWord;
			btnJumpExcel.IsEnabled = flag && selectedBinding.CanJumpExcel;
		}
	}

	private void NTfpbF4Nkc(object P_0, RoutedEventArgs P_1)
	{
		KgdpYSCcQH(null);
	}

	private void JEapS9rlB6(object P_0, RoutedEventArgs P_1)
	{
		VEqplheac3();
	}

	private void qm5pwqDkMJ(object P_0, RoutedEventArgs P_1)
	{
		uYupNZ2SxS();
	}

	private void nYQpteU1fx(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void jLepLYGSdi(object P_0, SelectionChangedEventArgs P_1)
	{
		O3mpMsnbFJ();
	}

	private void JkupsA0Vx0(object P_0, MouseButtonEventArgs P_1)
	{
		if (SelectedBinding != null)
		{
			VEqplheac3();
		}
	}

	private void VEqplheac3()
	{
		_G_c__DisplayClass15_0 CS_8_locals_14 = new _G_c__DisplayClass15_0();
		CS_8_locals_14.oYRV4oOY0tY = SelectedBinding;
		CS_8_locals_14.PUdV4md9nvj = false;
		CS_8_locals_14.oJ9V4G8gHG9 = string.Empty;
		CS_8_locals_14.erIV4Ct1Xjp = false;
		t2VpoKEvfA(delegate
		{
			CS_8_locals_14.PUdV4md9nvj = Jk2boJKtvpW0C9HFNVs.pNqZ2V22ob(CS_8_locals_14.oYRV4oOY0tY, out CS_8_locals_14.oJ9V4G8gHG9, out CS_8_locals_14.erIV4Ct1Xjp);
		});
		if (CS_8_locals_14.PUdV4md9nvj)
		{
			CS_8_locals_14.oJ9V4G8gHG9 = "已定位到 Word 表格。";
			txtSummary.Text = CS_8_locals_14.oJ9V4G8gHG9;
			un7uUxcCbw6Q36geOYj.psZcncX5UL(CS_8_locals_14.oJ9V4G8gHG9, "Excel同步");
		}
		else
		{
			P1mpmjD7R9(CS_8_locals_14.oJ9V4G8gHG9, CS_8_locals_14.erIV4Ct1Xjp);
		}
	}

	private void uYupNZ2SxS()
	{
		_G_c__DisplayClass16_0 CS_8_locals_14 = new _G_c__DisplayClass16_0();
		CS_8_locals_14.yrWV4nJqaqJ = SelectedBinding;
		CS_8_locals_14.SlkV4OsnsvT = false;
		CS_8_locals_14.qH0V47W2Cel = string.Empty;
		CS_8_locals_14.t1fV45usruo = false;
		t2VpoKEvfA(delegate
		{
			CS_8_locals_14.SlkV4OsnsvT = Jk2boJKtvpW0C9HFNVs.jfJEYZIKi1(CS_8_locals_14.yrWV4nJqaqJ, out CS_8_locals_14.qH0V47W2Cel, out CS_8_locals_14.t1fV45usruo);
		});
		if (CS_8_locals_14.SlkV4OsnsvT)
		{
			CS_8_locals_14.qH0V47W2Cel = "已定位到 Excel 区域。";
			txtSummary.Text = CS_8_locals_14.qH0V47W2Cel;
			un7uUxcCbw6Q36geOYj.psZcncX5UL(CS_8_locals_14.qH0V47W2Cel, "Excel同步");
		}
		else
		{
			P1mpmjD7R9(CS_8_locals_14.qH0V47W2Cel, CS_8_locals_14.t1fV45usruo);
		}
	}

	private void P1mpmjD7R9(string P_0, bool P_1)
	{
		P_0 = (string.IsNullOrWhiteSpace(P_0) ? "未能完成定位。" : P_0);
		txtSummary.Text = P_0;
		un7uUxcCbw6Q36geOYj.CsKcO7u6di(new Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs
		{
			Success = false,
			RequiresUserAction = P_1,
			Message = P_0
		}, "Excel同步");
	}

	private static void t2VpoKEvfA(Action P_0)
	{
		Cursor overrideCursor = Mouse.OverrideCursor;
		Mouse.OverrideCursor = Cursors.Wait;
		try
		{
			P_0();
		}
		finally
		{
			Mouse.OverrideCursor = overrideCursor;
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!c0mp7QwcuE)
		{
			c0mp7QwcuE = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/excelbindingmanagerwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
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
			barLoading = (ProgressBar)target;
			break;
		case 2:
			gridBindings = (DataGrid)target;
			gridBindings.SelectionChanged += jLepLYGSdi;
			gridBindings.MouseDoubleClick += JkupsA0Vx0;
			break;
		case 3:
			txtSummary = (TextBlock)target;
			break;
		case 4:
			btnRefresh = (Button)target;
			btnRefresh.Click += NTfpbF4Nkc;
			break;
		case 5:
			btnJumpWord = (Button)target;
			btnJumpWord.Click += JEapS9rlB6;
			break;
		case 6:
			btnJumpExcel = (Button)target;
			btnJumpExcel.Click += qm5pwqDkMJ;
			break;
		case 7:
			((Button)target).Click += nYQpteU1fx;
			break;
		default:
			c0mp7QwcuE = true;
			break;
		}
	}

	[CompilerGenerated]
	private void BBApGSr4ZC(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void IJspCPVegF(object P_0, RoutedEventArgs P_1)
	{
		txtSummary.Text = "正在准备读取当前文档绑定...";
		base.Dispatcher.BeginInvoke((Action)delegate
		{
			KgdpYSCcQH(null);
		}, DispatcherPriority.ApplicationIdle);
	}

	[CompilerGenerated]
	private void aAyppFSsDQ()
	{
		KgdpYSCcQH(null);
	}
}
