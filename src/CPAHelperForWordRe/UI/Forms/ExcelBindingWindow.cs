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
using TableComWriteService;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService;
using AiHelper_7;
using ExcelSyncRibbonHelper;
using LoggerInitializer;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ExcelBindingWindow : System.Windows.Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass11_0
	{
		public int value;

		public _G_c__DisplayClass11_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal TableComWriteService.SyncResult setTableHeader()
		{
			return TableComWriteService.SetCurrentTableHeader(value);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass20_0
	{
		public Func<TableComWriteService.SyncResult> syncAction;

		public TableComWriteService.SyncResult syncResult;

		public _G_c__DisplayClass20_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void executeSyncAction()
		{
			syncResult = syncAction();
		}
	}

	private bool _bool;

	private bool _isCancelled;

	private readonly DispatcherTimer _dispatcherTimer;

	private Microsoft.Office.Interop.Word.Application _wordApp;

	private bool _bool;

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

	private bool _isInitialized;

	public ExcelBindingWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		InitializeComponent();
		_dispatcherTimer = new DispatcherTimer
		{
			Interval = TimeSpan.FromMilliseconds(150.0)
		};
		_dispatcherTimer.Tick += onTimerTick;
		base.PreviewKeyDown += delegate(object P_0, KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		base.Loaded += delegate
		{
			subscribeSelectionChange();
			refreshBindingStatus( false);
		};
		base.Closed += delegate
		{
			unsubscribeSelectionChange();
		};
	}

	private void onRefreshClick(object P_0, RoutedEventArgs P_1)
	{
		refreshBindingStatus( true);
	}

	private void onBindClick(object P_0, RoutedEventArgs P_1)
	{
		executeSyncOperation("绑定当前表", () => TableComWriteService.BindCurrentTable( false));
	}

	private void onRebindClick(object P_0, RoutedEventArgs P_1)
	{
		executeSyncOperation("重新绑定当前表", () => TableComWriteService.BindCurrentTable( true));
	}

	private void onUnbindClick(object P_0, RoutedEventArgs P_1)
	{
		if (MessageBox.Show(this, "确定要解除当前 Word 表格的 Excel 绑定吗？\\n\\n只会清理 Word 文档中的绑定信息，不会删除 Excel 工作簿里的名称区域。", "解除绑定", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			executeSyncOperation("解除当前表绑定", TableComWriteService.UnbindCurrentTable);
		}
	}

	private void onExportAllClick(object P_0, RoutedEventArgs P_1)
	{
		executeSyncOperation("导出全部表并绑定", () => TableComWriteService.SyncAllTables(onSyncProgress));
	}

	private void onSaveHeaderSettingClick(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass11_0 CS_8_locals_2 = new _G_c__DisplayClass11_0();
		if (tryParseHeaderRows(out CS_8_locals_2.value))
		{
			executeSyncOperation("保存表头设置", () => TableComWriteService.SetCurrentTableHeader(CS_8_locals_2.value));
		}
	}

	private void onCloseClick(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void subscribeSelectionChange()
	{
		if (_bool)
		{
			return;
		}
		_wordApp = WordTableToolService.WordApp;
		if (_wordApp == null)
		{
			return;
		}
		try
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").AddEventHandler(_wordApp, new ApplicationEvents4_WindowSelectionChangeEventHandler(onSelectionChange));
			_bool = true;
		}
		catch
		{
		}
	}

	private void unsubscribeSelectionChange()
	{
		if (_bool && _wordApp != null)
		{
			try
			{
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").RemoveEventHandler(_wordApp, new ApplicationEvents4_WindowSelectionChangeEventHandler(onSelectionChange));
			}
			catch
			{
			}
			_bool = false;
			_wordApp = null;
		}
	}

	private void onSelectionChange(Selection P_0)
	{
		if (_bool || !base.IsVisible)
		{
			return;
		}
		try
		{
			base.Dispatcher.BeginInvoke((Action)delegate
			{
				_dispatcherTimer.Stop();
				_dispatcherTimer.Start();
			}, DispatcherPriority.Background);
		}
		catch
		{
		}
	}

	private void onTimerTick(object P_0, EventArgs P_1)
	{
		_dispatcherTimer.Stop();
		if (!_bool && base.IsVisible)
		{
			refreshBindingStatus( false);
		}
	}

	private void refreshBindingStatus(bool P_0)
	{
		TableComWriteService.TableSyncStatus TableSyncStatus = TableComWriteService.GetTableSyncStatus(P_0);
		txtWordStatus.Text = TableSyncStatus.WordStatus ?? string.Empty;
		txtWordTable.Text = TableSyncStatus.WordTableLabel ?? string.Empty;
		txtBindingId.Text = (TableSyncStatus.HasBinding ? TableSyncStatus.BindingId : "未绑定");
		txtHeaderSetting.Text = TableSyncStatus.HeaderSettingText ?? string.Empty;
		txtHeaderRows.Text = (TableSyncStatus.HeaderRowCount.HasValue ? TableSyncStatus.HeaderRowCount.Value.ToString() : string.Empty);
		updateHeaderRowsEnabled();
		txtExcelStatus.Text = TableSyncStatus.ExcelStatus ?? string.Empty;
		txtExcelWorkbook.Text = TableSyncStatus.ExcelWorkbook ?? string.Empty;
		txtExcelSheet.Text = TableSyncStatus.ExcelSheet ?? string.Empty;
		txtExcelAddress.Text = TableSyncStatus.ExcelAddress ?? string.Empty;
		txtExcelSize.Text = TableSyncStatus.ExcelSize ?? string.Empty;
		txtStatus.Text = TableSyncStatus.Message ?? string.Empty;
		btnBind.IsEnabled = !_bool && TableSyncStatus.HasWordTable && TableSyncStatus.HasExcelSelection;
		btnRebind.IsEnabled = !_bool && TableSyncStatus.HasWordTable && TableSyncStatus.HasBinding && TableSyncStatus.HasExcelSelection;
		btnUnbind.IsEnabled = !_bool && TableSyncStatus.HasWordTable && TableSyncStatus.HasBinding;
		btnSaveHeaderSetting.IsEnabled = !_bool && TableSyncStatus.HasWordTable && TableSyncStatus.HasBinding;
	}

	private bool tryParseHeaderRows(out int P_0)
	{
		P_0 = 0;
		if (!int.TryParse((txtHeaderRows.Text ?? string.Empty).Trim(), out var result) || result < 0)
		{
			LoggerInitializer.ShowWarning("表头行数请输入 0 或正整数。", "IP_Assurance");
			txtHeaderRows.Focus();
			txtHeaderRows.SelectAll();
			return false;
		}
		P_0 = result;
		return true;
	}

	private void updateHeaderRowsEnabled()
	{
		txtHeaderRows.IsEnabled = !_bool;
	}

	private void executeSyncOperation(string P_0, Func<TableComWriteService.SyncResult> P_1)
	{
		_G_c__DisplayClass20_0 CS_8_locals_8 = new _G_c__DisplayClass20_0();
		CS_8_locals_8.syncAction = P_1;
		if (_bool || CS_8_locals_8.syncAction == null)
		{
			return;
		}
		setBusyState( true);
		_isCancelled = false;
		barProgress.Value = 0.0;
		txtStatus.Text = "正在处理...";
		try
		{
			CS_8_locals_8.syncResult = null;
			AiHelper_7.RunCommandWithUndo(delegate
			{
				CS_8_locals_8.syncResult = CS_8_locals_8.syncAction();
			}, P_0);
			if (CS_8_locals_8.syncResult != null)
			{
				txtStatus.Text = CS_8_locals_8.syncResult.Message ?? string.Empty;
				ExcelSyncRibbonHelper.ShowSyncResult(CS_8_locals_8.syncResult, "Excel同步");
			}
		}
		finally
		{
			setBusyState( false);
			refreshBindingStatus( false);
		}
	}

	private bool onSyncProgress(int P_0, int P_1, string P_2)
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
		if (!_isCancelled)
		{
			return base.IsVisible;
		}
		return false;
	}

	private void setBusyState(bool P_0)
	{
		_bool = P_0;
		base.Cursor = (P_0 ? Cursors.Wait : null);
		btnRefresh.IsEnabled = !P_0;
		btnBind.IsEnabled = !P_0;
		btnRebind.IsEnabled = !P_0;
		btnUnbind.IsEnabled = !P_0;
		btnSaveHeaderSetting.IsEnabled = !P_0;
		btnExportAll.IsEnabled = !P_0;
		updateHeaderRowsEnabled();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_isInitialized)
		{
			_isInitialized = true;
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
			btnRefresh.Click += onRefreshClick;
			break;
		case 14:
			btnBind = (Button)target;
			btnBind.Click += onBindClick;
			break;
		case 15:
			btnRebind = (Button)target;
			btnRebind.Click += onRebindClick;
			break;
		case 16:
			btnUnbind = (Button)target;
			btnUnbind.Click += onUnbindClick;
			break;
		case 17:
			btnSaveHeaderSetting = (Button)target;
			btnSaveHeaderSetting.Click += onSaveHeaderSettingClick;
			break;
		case 18:
			btnExportAll = (Button)target;
			btnExportAll.Click += onExportAllClick;
			break;
		case 19:
			((Button)target).Click += onCloseClick;
			break;
		default:
			_isInitialized = true;
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
		subscribeSelectionChange();
		refreshBindingStatus( false);
	}

	[CompilerGenerated]
	private void onWindowClosed(object P_0, EventArgs P_1)
	{
		unsubscribeSelectionChange();
	}

	[CompilerGenerated]
	private TableComWriteService.SyncResult syncAllTables()
	{
		return TableComWriteService.SyncAllTables(onSyncProgress);
	}

	[CompilerGenerated]
	private void restartTimer()
	{
		_dispatcherTimer.Stop();
		_dispatcherTimer.Start();
	}
}
