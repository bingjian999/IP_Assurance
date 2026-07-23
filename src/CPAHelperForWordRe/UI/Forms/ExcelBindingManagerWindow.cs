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

		public TableComWriteService.TableBindingStatus wordBindingStatus;

		public string text;

		public bool flag;

		public _G_c__DisplayClass15_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void validateBindingForSync()
		{
			flag = TableComWriteService.ValidateBindingForSyncInternal(wordBindingStatus, out text, out flag);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_0
	{
		public bool flag;

		public TableComWriteService.TableBindingStatus excelBindingStatus;

		public string text;

		public bool flag;

		public _G_c__DisplayClass16_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void validateBindingSync()
		{
			flag = TableComWriteService.ValidateBindingSyncInternal(excelBindingStatus, out text, out flag);
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

		internal void loadBindingsInternal()
		{
			excelBindingManagerWindow.loadBindingsIntoCollection(text);
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

		internal bool matchesBindingId(TableComWriteService.TableBindingStatus item)
		{
			return string.Equals(item.BindingId, text, StringComparison.OrdinalIgnoreCase);
		}
	}

	private readonly ObservableCollection<TableComWriteService.TableBindingStatus> _bindingList;

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
		_bindingList = new ObservableCollection<TableComWriteService.TableBindingStatus>();
		InitializeComponent();
		gridBindings.ItemsSource = _bindingList;
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
				refreshBindingList(null);
			}, DispatcherPriority.ApplicationIdle);
		};
	}

	private void refreshBindingList(string P_0)
	{
		_G_c__DisplayClass5_0 CS_8_locals_4 = new _G_c__DisplayClass5_0();
		CS_8_locals_4.excelBindingManagerWindow = this;
		CS_8_locals_4.text = P_0 ?? SelectedBinding?.BindingId;
		_bool = true;
		barLoading.Visibility = Visibility.Visible;
		gridBindings.IsEnabled = false;
		txtSummary.Text = "正在读取当前文档绑定...";
		updateButtonStates();
		base.Dispatcher.BeginInvoke((Action)delegate
		{
			CS_8_locals_4.excelBindingManagerWindow.loadBindingsIntoCollection(CS_8_locals_4.text);
		}, DispatcherPriority.Background);
	}

	private void loadBindingsIntoCollection(string P_0)
	{
		_G_c__DisplayClass6_0 CS_8_locals_3 = new _G_c__DisplayClass6_0();
		CS_8_locals_3.text = P_0;
		try
		{
			_bindingList.Clear();
			foreach (TableComWriteService.TableBindingStatus item in TableComWriteService.GetAllTableBindings())
			{
				_bindingList.Add(item);
			}
			TableComWriteService.TableBindingStatus TableBindingStatus = ((!string.IsNullOrWhiteSpace(CS_8_locals_3.text)) ? _bindingList.FirstOrDefault((TableComWriteService.TableBindingStatus item) => string.Equals(item.BindingId, CS_8_locals_3.text, StringComparison.OrdinalIgnoreCase)) : null);
			gridBindings.SelectedItem = TableBindingStatus ?? _bindingList.FirstOrDefault();
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
			updateSummaryText();
			updateButtonStates();
		}
	}

	private void updateSummaryText()
	{
		int count = _bindingList.Count;
		int num = _bindingList.Count((TableComWriteService.TableBindingStatus item) => string.Equals(item.Status, "共 {0} 个绑定，正常 {1} 个，异常 {2} 个。", StringComparison.OrdinalIgnoreCase));
		txtSummary.Text = ((count == 0) ? "当前文档未发现 Excel 绑定关系。" : string.Format("[ExcelSync] Load binding manager failed", count, num, count - num));
	}

	private void updateButtonStates()
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

	private void onRefreshClick(object P_0, RoutedEventArgs P_1)
	{
		refreshBindingList(null);
	}

	private void onJumpWordClick(object P_0, RoutedEventArgs P_1)
	{
		jumpToWordTable();
	}

	private void onJumpExcelClick(object P_0, RoutedEventArgs P_1)
	{
		jumpToExcelRange();
	}

	private void onCloseClick(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void onSelectionChanged(object P_0, SelectionChangedEventArgs P_1)
	{
		updateButtonStates();
	}

	private void onDoubleClick(object P_0, MouseButtonEventArgs P_1)
	{
		if (SelectedBinding != null)
		{
			jumpToWordTable();
		}
	}

	private void jumpToWordTable()
	{
		_G_c__DisplayClass15_0 CS_8_locals_14 = new _G_c__DisplayClass15_0();
		CS_8_locals_14.wordBindingStatus = SelectedBinding;
		CS_8_locals_14.flag = false;
		CS_8_locals_14.text = string.Empty;
		CS_8_locals_14.flag = false;
		runWithWaitCursor(delegate
		{
			CS_8_locals_14.flag = TableComWriteService.ValidateBindingForSyncInternal(CS_8_locals_14.wordBindingStatus, out CS_8_locals_14.text, out CS_8_locals_14.flag);
		});
		if (CS_8_locals_14.flag)
		{
			CS_8_locals_14.text = "已定位到 Word 表格。";
			txtSummary.Text = CS_8_locals_14.text;
			ExcelSyncRibbonHelper.ShowSyncMessage(CS_8_locals_14.text, "Excel同步");
		}
		else
		{
			showSyncError(CS_8_locals_14.text, CS_8_locals_14.flag);
		}
	}

	private void jumpToExcelRange()
	{
		_G_c__DisplayClass16_0 CS_8_locals_14 = new _G_c__DisplayClass16_0();
		CS_8_locals_14.excelBindingStatus = SelectedBinding;
		CS_8_locals_14.flag = false;
		CS_8_locals_14.text = string.Empty;
		CS_8_locals_14.flag = false;
		runWithWaitCursor(delegate
		{
			CS_8_locals_14.flag = TableComWriteService.ValidateBindingSyncInternal(CS_8_locals_14.excelBindingStatus, out CS_8_locals_14.text, out CS_8_locals_14.flag);
		});
		if (CS_8_locals_14.flag)
		{
			CS_8_locals_14.text = "已定位到 Excel 区域。";
			txtSummary.Text = CS_8_locals_14.text;
			ExcelSyncRibbonHelper.ShowSyncMessage(CS_8_locals_14.text, "Excel同步");
		}
		else
		{
			showSyncError(CS_8_locals_14.text, CS_8_locals_14.flag);
		}
	}

	private void showSyncError(string P_0, bool P_1)
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

	private static void runWithWaitCursor(Action P_0)
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
			gridBindings.SelectionChanged += onSelectionChanged;
			gridBindings.MouseDoubleClick += onDoubleClick;
			break;
		case 3:
			txtSummary = (TextBlock)target;
			break;
		case 4:
			btnRefresh = (Button)target;
			btnRefresh.Click += onRefreshClick;
			break;
		case 5:
			btnJumpWord = (Button)target;
			btnJumpWord.Click += onJumpWordClick;
			break;
		case 6:
			btnJumpExcel = (Button)target;
			btnJumpExcel.Click += onJumpExcelClick;
			break;
		case 7:
			((Button)target).Click += onCloseClick;
			break;
		default:
			_bool = true;
			break;
		}
	}

	[CompilerGenerated]
	private void onPreviewKeyDown(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void onWindowLoaded(object P_0, RoutedEventArgs P_1)
	{
		txtSummary.Text = "正在准备读取当前文档绑定...";
		base.Dispatcher.BeginInvoke((Action)delegate
		{
			refreshBindingList(null);
		}, DispatcherPriority.ApplicationIdle);
	}

	[CompilerGenerated]
	private void refreshBindings()
	{
		refreshBindingList(null);
	}
}
