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
using AiConfigBootstrap;
using TableComWriteService;
using AiSseStreamService3;
using SseStreamInitializer;
using ExcelSyncRibbonHelper;
using LoggerInitializer;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ExcelBindingManagerWindow : Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass15_0
	{
		public bool flag;

		public TableComWriteService.TableBindingStatus oYRV4oOY0tY;

		public string text;

		public bool flag;

		public _G_c__DisplayClass15_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void qI6V4NtifAT()
		{
			flag = TableComWriteService.ValidateBindingForSyncInternal(oYRV4oOY0tY, out text, out flag);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_0
	{
		public bool flag;

		public TableComWriteService.TableBindingStatus yrWV4nJqaqJ;

		public string text;

		public bool flag;

		public _G_c__DisplayClass16_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void YUrV4pI9No4()
		{
			flag = TableComWriteService.ValidateBindingSyncInternal(yrWV4nJqaqJ, out text, out flag);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass5_0
	{
		public ExcelBindingManagerWindow excelBindingManagerWindow;

		public string text;

		public _G_c__DisplayClass5_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void MVUV4cIfW7X()
		{
			excelBindingManagerWindow.VOYpZMCNNR(text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass6_0
	{
		public string text;

		public _G_c__DisplayClass6_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool V1kV4XcaKbK(TableComWriteService.TableBindingStatus item)
		{
			return string.Equals(item.BindingId, text, StringComparison.OrdinalIgnoreCase);
		}
	}

	private readonly ObservableCollection<TableComWriteService.TableBindingStatus> CcRpOWdY5y;

	private bool _bool;

	internal ProgressBar barLoading;

	internal DataGrid gridBindings;

	internal TextBlock txtSummary;

	internal Button btnRefresh;

	internal Button btnJumpWord;

	internal Button btnJumpExcel;

	private bool _bool;

	private TableComWriteService.TableBindingStatus SelectedBinding => gridBindings.SelectedItem as TableComWriteService.TableBindingStatus;

	public ExcelBindingManagerWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		CcRpOWdY5y = new ObservableCollection<TableComWriteService.TableBindingStatus>();
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
		CS_8_locals_4.excelBindingManagerWindow = this;
		CS_8_locals_4.text = P_0 ?? SelectedBinding?.BindingId;
		_bool = true;
		barLoading.Visibility = Visibility.Visible;
		gridBindings.IsEnabled = false;
		txtSummary.Text = "正在读取当前文档绑定...";
		O3mpMsnbFJ();
		base.Dispatcher.BeginInvoke((Action)delegate
		{
			CS_8_locals_4.excelBindingManagerWindow.VOYpZMCNNR(CS_8_locals_4.text);
		}, DispatcherPriority.Background);
	}

	private void VOYpZMCNNR(string P_0)
	{
		_G_c__DisplayClass6_0 CS_8_locals_3 = new _G_c__DisplayClass6_0();
		CS_8_locals_3.text = P_0;
		try
		{
			CcRpOWdY5y.Clear();
			foreach (TableComWriteService.TableBindingStatus item in TableComWriteService.GetAllTableBindings())
			{
				CcRpOWdY5y.Add(item);
			}
			TableComWriteService.TableBindingStatus TableBindingStatus = ((!string.IsNullOrWhiteSpace(CS_8_locals_3.text)) ? CcRpOWdY5y.FirstOrDefault((TableComWriteService.TableBindingStatus item) => string.Equals(item.BindingId, CS_8_locals_3.text, StringComparison.OrdinalIgnoreCase)) : null);
			gridBindings.SelectedItem = TableBindingStatus ?? CcRpOWdY5y.FirstOrDefault();
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Load binding manager failed", ex);
			LoggerInitializer.ShowError("读取绑定列表失败，请保存 Word 文档后重新打开管理窗口。", "IP_Assurance");
		}
		finally
		{
			gridBindings.IsEnabled = true;
			barLoading.Visibility = Visibility.Collapsed;
			_bool = false;
			QJIpf4tWaW();
			O3mpMsnbFJ();
		}
	}

	private void QJIpf4tWaW()
	{
		int count = CcRpOWdY5y.Count;
		int num = CcRpOWdY5y.Count((TableComWriteService.TableBindingStatus item) => string.Equals(item.Status, "共 {0} 个绑定，正常 {1} 个，异常 {2} 个。", StringComparison.OrdinalIgnoreCase));
		txtSummary.Text = ((count == 0) ? "当前文档未发现 Excel 绑定关系。" : string.Format("[ExcelSync] Load binding manager failed", count, num, count - num));
	}

	private void O3mpMsnbFJ()
	{
		TableComWriteService.TableBindingStatus selectedBinding = SelectedBinding;
		bool flag = selectedBinding != null;
		btnRefresh.IsEnabled = !_bool;
		if (_bool)
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
		CS_8_locals_14.flag = false;
		CS_8_locals_14.text = string.Empty;
		CS_8_locals_14.flag = false;
		t2VpoKEvfA(delegate
		{
			CS_8_locals_14.flag = TableComWriteService.ValidateBindingForSyncInternal(CS_8_locals_14.oYRV4oOY0tY, out CS_8_locals_14.text, out CS_8_locals_14.flag);
		});
		if (CS_8_locals_14.flag)
		{
			CS_8_locals_14.text = "已定位到 Word 表格。";
			txtSummary.Text = CS_8_locals_14.text;
			ExcelSyncRibbonHelper.ShowSyncMessage(CS_8_locals_14.text, "Excel同步");
		}
		else
		{
			P1mpmjD7R9(CS_8_locals_14.text, CS_8_locals_14.flag);
		}
	}

	private void uYupNZ2SxS()
	{
		_G_c__DisplayClass16_0 CS_8_locals_14 = new _G_c__DisplayClass16_0();
		CS_8_locals_14.yrWV4nJqaqJ = SelectedBinding;
		CS_8_locals_14.flag = false;
		CS_8_locals_14.text = string.Empty;
		CS_8_locals_14.flag = false;
		t2VpoKEvfA(delegate
		{
			CS_8_locals_14.flag = TableComWriteService.ValidateBindingSyncInternal(CS_8_locals_14.yrWV4nJqaqJ, out CS_8_locals_14.text, out CS_8_locals_14.flag);
		});
		if (CS_8_locals_14.flag)
		{
			CS_8_locals_14.text = "已定位到 Excel 区域。";
			txtSummary.Text = CS_8_locals_14.text;
			ExcelSyncRibbonHelper.ShowSyncMessage(CS_8_locals_14.text, "Excel同步");
		}
		else
		{
			P1mpmjD7R9(CS_8_locals_14.text, CS_8_locals_14.flag);
		}
	}

	private void P1mpmjD7R9(string P_0, bool P_1)
	{
		P_0 = (string.IsNullOrWhiteSpace(P_0) ? "未能完成定位。" : P_0);
		txtSummary.Text = P_0;
		ExcelSyncRibbonHelper.ShowSyncResult(new TableComWriteService.SyncResult
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
		if (!_bool)
		{
			_bool = true;
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
			_bool = true;
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
