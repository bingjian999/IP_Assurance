using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using AiConfigBootstrap;
using TableComWriteService;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using Hyperlink = System.Windows.Documents.Hyperlink;
using SseStreamInitializer;
using WordTableToolService;
using ExcelDataSyncService;
using UiHelperService;
using AiHelper_7;
using ExcelSyncRibbonHelper;
using LoggerInitializer;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ExcelSyncWindow : System.Windows.Window, IComponentConnector
{
	private sealed class ColumnMappingItem
	{
		[CompilerGenerated]
		private int _wordColumnIndex;

		[CompilerGenerated]
		private string _excelColumnText;

		public int WordColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return _wordColumnIndex;
			}
			[CompilerGenerated]
			set
			{
				_wordColumnIndex = value;
			}
		}

		public string WordColumnLabel => "第 " + WordColumnIndex + " 列";

		public string ExcelColumnText
		{
			[CompilerGenerated]
			get
			{
				return _excelColumnText;
			}
			[CompilerGenerated]
			set
			{
				_excelColumnText = value;
			}
		}

		public ColumnMappingItem()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class TableBindingTreeNode : INotifyPropertyChanged
	{
		private bool _isExpanded;

		private bool _isSelected;

		[CompilerGenerated]
		private readonly ObservableCollection<TableBindingTreeNode> _children;

		[CompilerGenerated]
		private TableBindingTreeNode _parent;

		[CompilerGenerated]
		private TableComWriteService.TableBindingStatus _binding;

		[CompilerGenerated]
		private string _text;

		[CompilerGenerated]
		private string _statusBadge;

		[CompilerGenerated]
		private int REqVjRKiDLT;

		[CompilerGenerated]
		private bool _isHeading;

		[CompilerGenerated]
		private bool _isTable;

		[CompilerGenerated]
		private bool _isError;

		[CompilerGenerated]
		private PropertyChangedEventHandler m_PropertyChanged;

		public ObservableCollection<TableBindingTreeNode> Children
		{
			[CompilerGenerated]
			get
			{
				return _children;
			}
		}

		public TableBindingTreeNode Parent
		{
			[CompilerGenerated]
			get
			{
				return _parent;
			}
			[CompilerGenerated]
			set
			{
				_parent = value;
			}
		}

		public TableComWriteService.TableBindingStatus Binding
		{
			[CompilerGenerated]
			get
			{
				return _binding;
			}
			[CompilerGenerated]
			set
			{
				_binding = value;
			}
		}

		public string Text
		{
			[CompilerGenerated]
			get
			{
				return _text;
			}
			[CompilerGenerated]
			set
			{
				_text = value;
			}
		}

		public string StatusBadge
		{
			[CompilerGenerated]
			get
			{
				return _statusBadge;
			}
			[CompilerGenerated]
			set
			{
				_statusBadge = value;
			}
		}

		public int Level
		{
			[CompilerGenerated]
			get
			{
				return REqVjRKiDLT;
			}
			[CompilerGenerated]
			set
			{
				REqVjRKiDLT = value;
			}
		}

		public bool IsHeading
		{
			[CompilerGenerated]
			get
			{
				return _isHeading;
			}
			[CompilerGenerated]
			set
			{
				_isHeading = value;
			}
		}

		public bool IsTable
		{
			[CompilerGenerated]
			get
			{
				return _isTable;
			}
			[CompilerGenerated]
			set
			{
				_isTable = value;
			}
		}

		public bool IsError
		{
			[CompilerGenerated]
			get
			{
				return _isError;
			}
			[CompilerGenerated]
			set
			{
				_isError = value;
			}
		}

		public bool IsExpanded
		{
			get
			{
				return _isExpanded;
			}
			set
			{
				if (_isExpanded != value)
				{
					_isExpanded = value;
					Execute10("IsExpanded");
				}
			}
		}

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				if (_isSelected != value)
				{
					_isSelected = value;
					Execute10("IsSelected");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.m_PropertyChanged;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.m_PropertyChanged;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		private void Execute10([CallerMemberName] string propertyName = null)
		{
			this.m_PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public TableBindingTreeNode()
		{
			SseStreamInitializer.InitializeRuntime();
			_children = new ObservableCollection<TableBindingTreeNode>();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_0
	{
		public int YCyVjLWQnEc;

		public ExcelSyncWindow excelSyncWindow;

		public int count7;

		public bool OwfVjNqotwf;

		public bool flag;

		public List<int> columnIndices;

		public _G_c__DisplayClass28_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal TableComWriteService.SyncResult SaveHeaderSetting()
		{
			return TableComWriteService.SaveHeaderSetting(YCyVjLWQnEc, excelSyncWindow.chkSortEnabled.IsChecked == true, count7, OwfVjNqotwf, flag, columnIndices);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass29_0
	{
		public TableComWriteService.TableBindingStatus binding3;

		public int value;

		public ExcelSyncWindow excelSyncWindow;

		public int bdBVjnriyke;

		public bool flag;

		public bool flag;

		public List<int> columnIndices2;

		public _G_c__DisplayClass29_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal TableComWriteService.SyncResult zvxVjGNIPWX()
		{
			return TableComWriteService.SyncTableByLabelWithOptions(binding3.BindingId, value, excelSyncWindow.chkAllSortEnabled.IsChecked == true, bdBVjnriyke, flag, flag, columnIndices2);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass36_0
	{
		public TableComWriteService.ExcelPathUpdateResult pathUpdateResult2;

		public _G_c__DisplayClass36_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal TableComWriteService.SyncResult FeFVjeEaljg()
		{
			TableComWriteService.SyncOperationResult pathUpdateResult = TableComWriteService.ApplyExcelPathUpdate(pathUpdateResult2);
			return new TableComWriteService.SyncResult
			{
				Success = pathUpdateResult.Success,
				RequiresUserAction = !pathUpdateResult.Success,
				Bound = pathUpdateResult.UpdatedCount,
				Failed = pathUpdateResult.SkippedCount,
				Message = pathUpdateResult.Message
			};
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass58_0
	{
		public ExcelSyncWindow excelSyncWindow;

		public bool flag;

		public bool VdaVjasONDp;

		public int value;

		public _G_c__DisplayClass58_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void oaCVjXCqqYD()
		{
			try
			{
				if (!excelSyncWindow._bool && excelSyncWindow.IsVisible)
				{
					excelSyncWindow.XvJOKeRLxt(flag);
				}
			}
			finally
			{
				if (VdaVjasONDp)
				{
					excelSyncWindow.Execute4(value);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass62_0
	{
		public ExcelSyncWindow cexVjAsRxWj;

		public string text;

		public _G_c__DisplayClass62_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void GetText12()
		{
			cexVjAsRxWj.Save2(text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass66_0
	{
		public string text;

		public _G_c__DisplayClass66_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool gKjVjWYbDZj(TableComWriteService.WorkbookBindingSummary group)
		{
			return string.Equals(group.ResolvedExcelPath, text, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass75_0
	{
		public TableComWriteService.HeadingPathItem headingItem;

		public string text2;

		public _G_c__DisplayClass75_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool GetText13(TableBindingTreeNode existing)
		{
			if (existing.IsHeading && existing.Level == headingItem.Level)
			{
				return string.Equals(existing.Text, text2, StringComparison.Ordinal);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass87_0
	{
		public int value;

		public _G_c__DisplayClass87_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsColumnMappingForWord(TableComWriteService.ColumnMapping item)
		{
			return item.WordColumnIndex == value;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass92_0
	{
		public Func<TableComWriteService.SyncResult> actionFunc10;

		public TableComWriteService.SyncResult syncResult2;

		public _G_c__DisplayClass92_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void Execute18()
		{
			syncResult2 = actionFunc10();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass93_0
	{
		public Func<TableComWriteService.SyncResult> actionFunc9;

		public TableComWriteService.SyncResult gTxVYDrAlNL;

		public _G_c__DisplayClass93_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void Execute11()
		{
			gTxVYDrAlNL = actionFunc9();
		}
	}

	private readonly ObservableCollection<TableComWriteService.TableBindingStatus> binding2;

	private readonly ObservableCollection<TableBindingTreeNode> _tableNodes;

	private readonly ObservableCollection<TableComWriteService.WorkbookBindingSummary> workbook2;

	private readonly ObservableCollection<ColumnMappingItem> _columnMappings;

	private readonly ObservableCollection<ColumnMappingItem> PtTngkISNu;

	private readonly DispatcherTimer _dispatcherTimer;

	private bool _bool;

	private bool MZEniWtslN;

	private bool _bool;

	private bool OMKnQSfJqs;

	private bool _bool;

	private bool _bool;

	private bool _bool;

	private int _int;

	private Microsoft.Office.Interop.Word.Application ClanUwKOlF;

	private TableComWriteService.TableSyncStatus bNZnKlpICU;

	private TableBindingTreeNode _tableBindingTreeNode;

	internal System.Windows.Controls.TabControl tabSync;

	internal TabItem tabCurrent;

	internal System.Windows.Controls.ProgressBar barCurrentLoading;

	internal TextBlock txtCurrentCardTitle;

	internal System.Windows.Controls.Button btnRefreshExcelSelection;

	internal TextBlock txtWordStatus;

	internal TextBlock txtWordTable;

	internal TextBlock txtBindingSourceSummary;

	internal Hyperlink linkCurrentBindingSource;

	internal Run runBindingSourceSummary;

	internal TextBlock txtHeaderSetting;

	internal TextBlock lblExcelSelectionSummary;

	internal TextBlock txtExcelSelectionSummary;

	internal System.Windows.Controls.TextBox txtBindingId;

	internal System.Windows.Controls.TextBox txtExcelName;

	internal System.Windows.Controls.TextBox txtBoundPath;

	internal System.Windows.Controls.TextBox txtBoundSheet;

	internal System.Windows.Controls.TextBox txtExcelStatus;

	internal System.Windows.Controls.TextBox txtExcelWorkbook;

	internal System.Windows.Controls.TextBox txtExcelSheet;

	internal System.Windows.Controls.TextBox txtExcelAddress;

	internal System.Windows.Controls.TextBox txtExcelSize;

	internal System.Windows.Controls.TextBox txtHeaderRows;

	internal System.Windows.Controls.CheckBox chkSortEnabled;

	internal System.Windows.Controls.TextBox txtSortColumnIndex;

	internal System.Windows.Controls.ComboBox cboSortDirection;

	internal System.Windows.Controls.CheckBox chkSortPinOtherLast;

	internal System.Windows.Controls.DataGrid gridColumnMappings;

	internal System.Windows.Controls.Button btnSaveHeaderSetting;

	internal System.Windows.Controls.Button btnPrimaryCurrent;

	internal System.Windows.Controls.Button btnSplitCurrentTable;

	internal System.Windows.Controls.Button btnRebind;

	internal System.Windows.Controls.Button btnUnbind;

	internal System.Windows.Controls.ProgressBar barCurrentProgress;

	internal TextBlock txtCurrentStatus;

	internal System.Windows.Controls.Button btnCancelCurrent;

	internal TabItem tabAll;

	internal TextBlock txtAllSummary;

	internal System.Windows.Controls.Button btnRefreshAll;

	internal System.Windows.Controls.Button btnCleanInvalidBindings;

	internal System.Windows.Controls.ProgressBar barAllLoading;

	internal System.Windows.Controls.TreeView treeBindings;

	internal TextBlock txtAllDetailEmpty;

	internal ScrollViewer panelAllDetailContent;

	internal TextBlock txtAllDetailTitle;

	internal TextBlock txtAllDetailHeading;

	internal TextBlock txtAllDetailStatus;

	internal TextBlock txtAllDetailWordTable;

	internal TextBlock txtAllDetailWorkbook;

	internal TextBlock txtAllDetailSheet;

	internal TextBlock txtAllDetailName;

	internal Hyperlink linkAllDetailPath;

	internal Run runAllDetailPath;

	internal System.Windows.Controls.TextBox txtAllHeaderRows;

	internal System.Windows.Controls.CheckBox chkAllSortEnabled;

	internal System.Windows.Controls.TextBox txtAllSortColumnIndex;

	internal System.Windows.Controls.ComboBox cboAllSortDirection;

	internal System.Windows.Controls.CheckBox chkAllSortPinOtherLast;

	internal System.Windows.Controls.DataGrid gridAllColumnMappings;

	internal System.Windows.Controls.Button btnSaveAllHeaderSetting;

	internal StackPanel panelAllAdvancedDetails;

	internal TextBlock txtAllDetailBindingId;

	internal TextBlock txtAllDetailBookmark;

	internal System.Windows.Controls.Border borderAllError;

	internal TextBlock txtAllError;

	internal System.Windows.Controls.ProgressBar barAllProgress;

	internal TextBlock txtAllStatus;

	internal System.Windows.Controls.Button btnSyncSelected;

	internal System.Windows.Controls.Button btnSyncAll;

	internal System.Windows.Controls.Button btnExportAll;

	internal System.Windows.Controls.Button btnCancelAll;

	internal TabItem tabDataSources;

	internal TextBlock txtDataSourceSummary;

	internal System.Windows.Controls.Button btnRefreshDataSources;

	internal System.Windows.Controls.DataGrid gridDataSources;

	internal TextBlock txtDataSourceEmpty;

	internal ScrollViewer panelDataSourceDetailContent;

	internal TextBlock txtDataSourceTitle;

	internal TextBlock txtDataSourceStatus;

	internal TextBlock txtDataSourceBindingCount;

	internal TextBlock txtDataSourceNormalCount;

	internal TextBlock txtDataSourceMissingPathCount;

	internal TextBlock txtDataSourcePath;

	internal System.Windows.Controls.Button btnReplaceDataSource;

	internal System.Windows.Controls.Button btnOpenDataSourceFolder;

	internal System.Windows.Controls.Button btnJumpDataSourceBinding;

	internal System.Windows.Controls.ListBox listDataSourceBindings;

	internal TextBlock txtDataSourceStatusBar;

	internal TabItem tabOptions;

	internal System.Windows.Controls.CheckBox chkSyncHeaders;

	internal TextBlock txtContextMenuStatus;

	internal System.Windows.Controls.Button btnToggleContextMenu;

	internal System.Windows.Controls.CheckBox chkShowAdvancedColumns;

	internal TextBlock txtOptionsStatus;

	private bool _bool;

	private TableComWriteService.TableBindingStatus SelectedBinding
	{
		get
		{
			if (_tableBindingTreeNode == null || !_tableBindingTreeNode.IsTable)
			{
				return null;
			}
			return _tableBindingTreeNode.Binding;
		}
	}

	private TableComWriteService.WorkbookBindingSummary SelectedDataSourceGroup => gridDataSources?.SelectedItem as TableComWriteService.WorkbookBindingSummary;

	private TableComWriteService.TableBindingStatus SelectedDataSourceBinding => listDataSourceBindings?.SelectedItem as TableComWriteService.TableBindingStatus;

	public ExcelSyncWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		binding2 = new ObservableCollection<TableComWriteService.TableBindingStatus>();
		_tableNodes = new ObservableCollection<TableBindingTreeNode>();
		workbook2 = new ObservableCollection<TableComWriteService.WorkbookBindingSummary>();
		_columnMappings = new ObservableCollection<ColumnMappingItem>();
		PtTngkISNu = new ObservableCollection<ColumnMappingItem>();
		InitializeComponent();
		treeBindings.ItemsSource = _tableNodes;
		gridDataSources.ItemsSource = workbook2;
		gridColumnMappings.ItemsSource = _columnMappings;
		gridAllColumnMappings.ItemsSource = PtTngkISNu;
		_dispatcherTimer = new DispatcherTimer
		{
			Interval = TimeSpan.FromMilliseconds(150.0)
		};
		_dispatcherTimer.Tick += Execute24;
		base.PreviewKeyDown += delegate(object P_0, System.Windows.Input.KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		base.Loaded += delegate
		{
			txtAllSummary.Text = "数据同步";
			txtDataSourceSummary.Text = "绑定当前表";
			jpROigfFHQ();
			mxOOHYibqA();
			Execute21(false, true);
			Execute20();
			Execute8();
			sJTOjaskhb();
			Sync8();
			Delete6();
			EohOwGuhvN();
		};
		base.Closed += delegate
		{
			YQpOQgxdib();
		};
	}

	private void Delete4(object P_0, RoutedEventArgs P_1)
	{
		if (bNZnKlpICU != null && bNZnKlpICU.HasBinding)
		{
			Execute9("数据同步", () => TableComWriteService.SyncCurrentTable(XGtOAmBcpX), false);
		}
		else if (bNZnKlpICU != null && bNZnKlpICU.HasWordTable)
		{
			Execute9("绑定当前表", () => TableComWriteService.BindCurrentTable( false), true);
		}
		else
		{
			Execute9("插入Excel选区", TableComWriteService.InsertExcelSelectionBelow, false);
		}
	}

	private void tbkpcqdVrT(object P_0, RoutedEventArgs P_1)
	{
		Execute9("重新绑定当前表", () => TableComWriteService.BindCurrentTable( true), true);
	}

	private void xifpeRxOvW(object P_0, RoutedEventArgs P_1)
	{
		Execute9("拆分表", TableComWriteService.SplitCurrentTable, true);
	}

	private void Save1(object P_0, RoutedEventArgs P_1)
	{
		if (System.Windows.MessageBox.Show(this, "确定要解除当前 Word 表格的 Excel 绑定吗？\\n\\n只会清理 Word 文档中的绑定信息，不会删除 Excel 工作簿里的名称区域。", "解除绑定", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			Execute9("解除当前表绑定", TableComWriteService.UnbindCurrentTable, true);
		}
	}

	private void Save3(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass28_0 CS_8_locals_12 = new _G_c__DisplayClass28_0();
		CS_8_locals_12.excelSyncWindow = this;
		CommitDataGridEdit(gridColumnMappings);
		if (ValidateSyncOptions(txtHeaderRows, chkSortEnabled, txtSortColumnIndex, cboSortDirection, chkSortPinOtherLast, _columnMappings, out CS_8_locals_12.YCyVjLWQnEc, out CS_8_locals_12.count7, out CS_8_locals_12.OwfVjNqotwf, out CS_8_locals_12.flag, out CS_8_locals_12.columnIndices))
		{
			Execute9("保存表格配置", () => TableComWriteService.SaveHeaderSetting(CS_8_locals_12.YCyVjLWQnEc, CS_8_locals_12.excelSyncWindow.chkSortEnabled.IsChecked == true, CS_8_locals_12.count7, CS_8_locals_12.OwfVjNqotwf, CS_8_locals_12.flag, CS_8_locals_12.columnIndices), false);
		}
	}

	private void afQpFDqfMW(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass29_0 CS_8_locals_15 = new _G_c__DisplayClass29_0();
		CS_8_locals_15.excelSyncWindow = this;
		CommitDataGridEdit(gridAllColumnMappings);
		CS_8_locals_15.binding3 = SelectedBinding;
		if (CS_8_locals_15.binding3 == null)
		{
			LoggerInitializer.ShowWarning("请先在左侧选择一张表。", "IP_Assurance");
		}
		else if (ValidateSyncOptions(txtAllHeaderRows, chkAllSortEnabled, txtAllSortColumnIndex, cboAllSortDirection, chkAllSortPinOtherLast, PtTngkISNu, out CS_8_locals_15.value, out CS_8_locals_15.bdBVjnriyke, out CS_8_locals_15.flag, out CS_8_locals_15.flag, out CS_8_locals_15.columnIndices2))
		{
			Execute9("保存表格配置", () => TableComWriteService.SyncTableByLabelWithOptions(CS_8_locals_15.binding3.BindingId, CS_8_locals_15.value, CS_8_locals_15.excelSyncWindow.chkAllSortEnabled.IsChecked == true, CS_8_locals_15.bdBVjnriyke, CS_8_locals_15.flag, CS_8_locals_15.flag, CS_8_locals_15.columnIndices2), true);
		}
	}

	private void Delete3(object P_0, RoutedEventArgs P_1)
	{
		if (!_bool)
		{
			Execute21(false, true);
		}
	}

	private void Delete7(object P_0, RoutedEventArgs P_1)
	{
		if (!_bool && bNZnKlpICU != null && bNZnKlpICU.HasBinding)
		{
			Execute23("跳转Excel", TableComWriteService.GetCurrentTableSyncStatus);
		}
	}

	private void Delete1(object P_0, RoutedEventArgs P_1)
	{
		Execute9("导出全部表并绑定", () => TableComWriteService.SyncAllTables(XGtOAmBcpX), true);
	}

	private void Delete2(object P_0, RoutedEventArgs P_1)
	{
		Execute9("刷新绑定信息", TableComWriteService.GetSyncAllTablesResult, true);
	}

	private void Delete5(object P_0, RoutedEventArgs P_1)
	{
		int num = binding2.Count((TableComWriteService.TableBindingStatus item) => string.Equals(item.Status, "没有需要清理的失效绑定。", StringComparison.OrdinalIgnoreCase));
		if (num == 0)
		{
			Execute7("没有需要清理的失效绑定。");
			ExcelSyncRibbonHelper.ShowSyncMessage("Excel同步", "将删除 {0} 个表格锚点丢失的绑定记录。\\n\\n不会删除 Excel 文件，也不会删除 Excel 名称区域。确定继续吗？");
		}
		else if (System.Windows.MessageBox.Show(this, string.Format("清理失效绑定", num), "清理失效绑定", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			Execute9("插入Excel选区", TableComWriteService.SyncAllTablesInternal, true);
		}
	}

	private void Save5(object P_0, RoutedEventArgs P_1)
	{
		lmoOEgXMdh(SelectedBinding?.BindingId);
	}

	private void Save4(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass36_0 CS_8_locals_6 = new _G_c__DisplayClass36_0();
		TableComWriteService.WorkbookBindingSummary selectedDataSourceGroup = SelectedDataSourceGroup;
		if (selectedDataSourceGroup == null)
		{
			LoggerInitializer.ShowWarning("请先选择一个 Excel 数据源。", "IP_Assurance");
			return;
		}
		string fileName;
		using (OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = "选择新的 Excel 数据源",
			Filter = "Excel 工作簿 (*.xlsx;*.xlsm)|*.xlsx;*.xlsm",
			Multiselect = false
		})
		{
			if (!string.IsNullOrWhiteSpace(selectedDataSourceGroup.ResolvedExcelPath) && File.Exists(selectedDataSourceGroup.ResolvedExcelPath))
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(selectedDataSourceGroup.ResolvedExcelPath);
			}
			if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
			{
				return;
			}
			fileName = openFileDialog.FileName;
		}
		if (TableComWriteService.IsExcelFile(fileName) && System.Windows.MessageBox.Show(this, "新 Excel 文件当前正在打开。\\n\\n更换数据源会读取该文件已经保存到磁盘的内容；如果 Excel 中有未保存修改，请先保存后继续。\\n\\n是否继续？", "更换数据源", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
		{
			return;
		}
		if (!TableComWriteService.TryPreviewExcelPathUpdate(selectedDataSourceGroup, fileName, out CS_8_locals_6.pathUpdateResult2, out var text))
		{
			ExcelSyncRibbonHelper.ShowSyncResult(new TableComWriteService.SyncResult
			{
				Success = false,
				RequiresUserAction = true,
				Message = (string.IsNullOrWhiteSpace(text) ? "更换数据源预检失败。" : text)
			}, "Excel同步");
		}
		else if (CS_8_locals_6.pathUpdateResult2.MatchedItems == null || CS_8_locals_6.pathUpdateResult2.MatchedItems.Count == 0)
		{
			System.Windows.MessageBox.Show(this, FormatPathUpdateResult(CS_8_locals_6.pathUpdateResult2, false), "更换数据源", MessageBoxButton.OK, MessageBoxImage.Exclamation);
		}
		else if (System.Windows.MessageBox.Show(this, FormatPathUpdateResult(CS_8_locals_6.pathUpdateResult2, true), "确认更换数据源", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			Execute9("更换数据源", delegate
			{
				TableComWriteService.SyncOperationResult pathUpdateResult = TableComWriteService.ApplyExcelPathUpdate(CS_8_locals_6.pathUpdateResult2);
				return new TableComWriteService.SyncResult
				{
					Success = pathUpdateResult.Success,
					RequiresUserAction = !pathUpdateResult.Success,
					Bound = pathUpdateResult.UpdatedCount,
					Failed = pathUpdateResult.SkippedCount,
					Message = pathUpdateResult.Message
				};
			}, true);
		}
	}

	private void LogError(object P_0, RoutedEventArgs P_1)
	{
		string text = SelectedDataSourceGroup?.ResolvedExcelPath;
		if (string.IsNullOrWhiteSpace(text))
		{
			LoggerInitializer.ShowWarning("当前数据源没有可打开的路径。", "IP_Assurance");
			return;
		}
		try
		{
			if (File.Exists(text))
			{
				Process.Start(new ProcessStartInfo("explorer.exe", "/select,\"" + text + "\"")
				{
					UseShellExecute = true
				});
				return;
			}
			string directoryName = Path.GetDirectoryName(text);
			if (!string.IsNullOrWhiteSpace(directoryName) && Directory.Exists(directoryName))
			{
				Process.Start(new ProcessStartInfo("explorer.exe", "\"" + directoryName + "\"")
				{
					UseShellExecute = true
				});
			}
			else
			{
				LoggerInitializer.ShowWarning("未找到 Excel 文件或所在文件夹。", "IP_Assurance");
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Open data source folder failed", ex);
			LoggerInitializer.ShowWarning("打开文件位置失败。", "IP_Assurance");
		}
	}

	private void Sync5(object P_0, RoutedEventArgs P_1)
	{
		TableComWriteService.TableBindingStatus selectedDataSourceBinding = SelectedDataSourceBinding;
		if (selectedDataSourceBinding == null)
		{
			LoggerInitializer.ShowWarning("请先在关联表中选择一张表。", "IP_Assurance");
			return;
		}
		tabAll.IsSelected = true;
		TableBindingTreeNode bindingNode = FindNodeByBindingId(_tableNodes, selectedDataSourceBinding.BindingId);
		rAUOlemBfZ(bindingNode);
		if (bindingNode != null && ValidateSelectedBinding())
		{
			Execute7("已定位到 Word 表格。");
		}
	}

	private void OWypxBxIqE(object P_0, RoutedEventArgs P_1)
	{
		TableComWriteService.TableBindingStatus selectedBinding = SelectedBinding;
		if (selectedBinding != null && selectedBinding.CanJumpExcel)
		{
			Sync4(selectedBinding);
		}
	}

	private void Sync7(object P_0, RoutedEventArgs P_1)
	{
		if (SelectedBinding == null)
		{
			LoggerInitializer.ShowWarning("请先选择一个绑定关系。", "IP_Assurance");
			return;
		}
		Execute9("数据同步", () => (!ValidateBindingForSync(out var text, out var requiresUserAction)) ? new TableComWriteService.SyncResult
		{
			Success = false,
			RequiresUserAction = requiresUserAction,
			Message = (string.IsNullOrWhiteSpace(text) ? "重新绑定当前表" : text)
		} : TableComWriteService.SyncCurrentTable(XGtOAmBcpX), false);
	}

	private void Write2(object P_0, RoutedEventArgs P_1)
	{
		Execute9("数据同步", () => TableComWriteService.SyncAllTablesWithOptions(XGtOAmBcpX), false);
	}

	private void Write1(object P_0, RoutedEventArgs P_1)
	{
		string text = ExcelDataSyncService.GetExcelSyncStatus();
		txtOptionsStatus.Text = text;
		Execute7(text);
		Execute20();
		if (ExcelDataSyncService.IsLoaded || text.StartsWith("已卸载", StringComparison.OrdinalIgnoreCase))
		{
			ExcelSyncRibbonHelper.ShowSyncMessage(text, "Excel同步");
		}
		else
		{
			ExcelSyncRibbonHelper.ShowSyncWarning(text, "Excel同步");
		}
	}

	private void vNHOVaYlKI(object P_0, RoutedEventArgs P_1)
	{
		MZEniWtslN = true;
		Execute7("正在取消，请等待当前表格处理完成...");
	}

	private void Write3(object P_0, RoutedEventArgs P_1)
	{
		if (!OMKnQSfJqs)
		{
			bool valueOrDefault = chkSyncHeaders.IsChecked == true;
			TableComWriteService.SetSyncHeadersSetting(valueOrDefault);
			txtOptionsStatus.Text = (valueOrDefault ? "已关闭同步表头内容；后续同步只写入数据区。" : "已开启同步表头内容。");
		}
	}

	private void Execute3(object P_0, RoutedEventArgs P_1)
	{
		Execute8();
	}

	private void Execute15(object P_0, RoutedEventArgs P_1)
	{
		jlKObjnrQv();
		Delete6();
	}

	private void Execute2(object P_0, RoutedPropertyChangedEventArgs<object> P_1)
	{
		TableBindingTreeNode bindingNode = P_1.NewValue as TableBindingTreeNode;
		_tableBindingTreeNode = ((bindingNode != null && bindingNode.IsTable) ? bindingNode : null);
		sJTOjaskhb();
		Delete6();
		if (!_bool && !_bool && tabAll.IsSelected && SelectedBinding != null && ValidateSelectedBinding())
		{
			Execute7("已定位到 Word 表格。");
		}
	}

	private void Execute13(object P_0, SelectionChangedEventArgs P_1)
	{
		Sync8();
		EohOwGuhvN();
	}

	private void Execute12(object P_0, SelectionChangedEventArgs P_1)
	{
		EohOwGuhvN();
	}

	private bool ValidateSelectedBinding()
	{
		string text;
		bool flag;
		return ValidateBindingForSync(out text, out flag);
	}

	private bool ValidateBindingForSync(out string P_0, out bool P_1)
	{
		bool num = TableComWriteService.ValidateBindingForSyncInternal(SelectedBinding, out P_0, out P_1);
		if (!num && !string.IsNullOrWhiteSpace(P_0))
		{
			Execute7(P_0);
		}
		sJTOjaskhb();
		Delete6();
		return num;
	}

	private void fFuOIGKZTj(object P_0, SelectionChangedEventArgs P_1)
	{
		if (P_1.Source == tabSync && (tabAll.IsSelected || tabDataSources.IsSelected) && !_bool && !_bool)
		{
			lmoOEgXMdh(bNZnKlpICU?.BindingId);
		}
	}

	private void jpROigfFHQ()
	{
		OMKnQSfJqs = true;
		try
		{
			chkSyncHeaders.IsChecked = TableComWriteService.GetSyncHeadersSetting();
		}
		finally
		{
			OMKnQSfJqs = false;
		}
	}

	private void mxOOHYibqA()
	{
		if (_bool)
		{
			return;
		}
		ClanUwKOlF = WordTableToolService.WordApp;
		if (ClanUwKOlF == null)
		{
			return;
		}
		try
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").AddEventHandler(ClanUwKOlF, new ApplicationEvents4_WindowSelectionChangeEventHandler(Execute16));
			_bool = true;
		}
		catch
		{
		}
	}

	private void YQpOQgxdib()
	{
		if (_bool && ClanUwKOlF != null)
		{
			try
			{
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").RemoveEventHandler(ClanUwKOlF, new ApplicationEvents4_WindowSelectionChangeEventHandler(Execute16));
			}
			catch
			{
			}
			_bool = false;
			ClanUwKOlF = null;
		}
	}

	private void Execute16(Selection P_0)
	{
		if (_bool || !base.IsVisible)
		{
			return;
		}
		try
		{
			base.Dispatcher.BeginInvoke((Action)delegate
			{
				if (tabCurrent.IsSelected)
				{
					Execute17();
				}
				_dispatcherTimer.Stop();
				_dispatcherTimer.Start();
			}, DispatcherPriority.Background);
		}
		catch
		{
		}
	}

	private void Execute24(object P_0, EventArgs P_1)
	{
		_dispatcherTimer.Stop();
		if (!_bool && base.IsVisible)
		{
			Execute21( false, tabCurrent.IsSelected);
		}
		else
		{
			Execute4();
		}
	}

	private void Execute21(bool P_0, bool P_1)
	{
		_G_c__DisplayClass58_0 CS_8_locals_13 = new _G_c__DisplayClass58_0();
		CS_8_locals_13.excelSyncWindow = this;
		CS_8_locals_13.flag = P_0;
		CS_8_locals_13.VdaVjasONDp = P_1;
		if (_bool || !base.IsVisible)
		{
			return;
		}
		CS_8_locals_13.value = _int;
		if (CS_8_locals_13.VdaVjasONDp)
		{
			CS_8_locals_13.value = ++_int;
			Execute17();
		}
		base.Dispatcher.BeginInvoke((Action)delegate
		{
			try
			{
				if (!CS_8_locals_13.excelSyncWindow._bool && CS_8_locals_13.excelSyncWindow.IsVisible)
				{
					CS_8_locals_13.excelSyncWindow.XvJOKeRLxt(CS_8_locals_13.flag);
				}
			}
			finally
			{
				if (CS_8_locals_13.VdaVjasONDp)
				{
					CS_8_locals_13.excelSyncWindow.Execute4(CS_8_locals_13.value);
				}
			}
		}, DispatcherPriority.Background);
	}

	private void Execute17()
	{
		try
		{
			barCurrentLoading.Visibility = Visibility.Visible;
			txtCurrentStatus.Text = "正在刷新当前表...";
		}
		catch
		{
		}
	}

	private void Execute4(int? P_0 = null)
	{
		try
		{
			if (!P_0.HasValue || P_0.Value == _int)
			{
				barCurrentLoading.Visibility = Visibility.Collapsed;
			}
		}
		catch
		{
		}
	}

	private void XvJOKeRLxt(bool P_0)
	{
		bNZnKlpICU = TableComWriteService.GetTableSyncStatus(P_0);
		txtCurrentCardTitle.Text = ddYOpUEEfn(bNZnKlpICU);
		txtWordStatus.Text = Insert3(bNZnKlpICU);
		txtWordTable.Text = bNZnKlpICU.WordTableLabel ?? string.Empty;
		txtBindingId.Text = (bNZnKlpICU.HasBinding ? bNZnKlpICU.BindingId : "未绑定");
		txtHeaderSetting.Text = Insert1(bNZnKlpICU);
		txtHeaderRows.Text = (bNZnKlpICU.HeaderRowCount.HasValue ? bNZnKlpICU.HeaderRowCount.Value.ToString() : string.Empty);
		chkSortEnabled.IsChecked = bNZnKlpICU.SortEnabled;
		txtSortColumnIndex.Text = (bNZnKlpICU.SortColumnIndex ?? 2).ToString();
		cboSortDirection.SelectedIndex = ((bNZnKlpICU.SortDescending == false) ? 1 : 0);
		chkSortPinOtherLast.IsChecked = bNZnKlpICU.SortPinOtherLast != false;
		PopulateColumnMappings(_columnMappings, bNZnKlpICU.ColumnMappings, bNZnKlpICU.WordColumnCount);
		runBindingSourceSummary.Text = Insert2(bNZnKlpICU);
		txtExcelStatus.Text = bNZnKlpICU.ExcelStatus ?? string.Empty;
		txtExcelWorkbook.Text = bNZnKlpICU.ExcelWorkbook ?? string.Empty;
		txtExcelSheet.Text = bNZnKlpICU.ExcelSheet ?? string.Empty;
		txtExcelAddress.Text = bNZnKlpICU.ExcelAddress ?? string.Empty;
		txtExcelSize.Text = bNZnKlpICU.ExcelSize ?? string.Empty;
		txtExcelSelectionSummary.Text = FormatExcelStatus(bNZnKlpICU);
		bool flag = !bNZnKlpICU.HasBinding || bNZnKlpICU.HasExcelSelection;
		lblExcelSelectionSummary.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		txtExcelSelectionSummary.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		txtBoundPath.Text = ((!string.IsNullOrWhiteSpace(bNZnKlpICU.BoundFullPath)) ? bNZnKlpICU.BoundFullPath : (bNZnKlpICU.BoundWorkbook ?? string.Empty));
		txtBoundSheet.Text = bNZnKlpICU.BoundSheet ?? string.Empty;
		txtExcelName.Text = bNZnKlpICU.BoundExcelName ?? string.Empty;
		txtCurrentStatus.Text = bNZnKlpICU.Message ?? string.Empty;
		jlKObjnrQv();
	}

	private void lmoOEgXMdh(string P_0)
	{
		_G_c__DisplayClass62_0 CS_8_locals_4 = new _G_c__DisplayClass62_0();
		CS_8_locals_4.cexVjAsRxWj = this;
		if (!_bool && !_bool)
		{
			CS_8_locals_4.text = P_0 ?? SelectedBinding?.BindingId;
			_bool = true;
			_bool = true;
			barAllLoading.Visibility = Visibility.Visible;
			treeBindings.IsEnabled = false;
			txtAllSummary.Text = "正在读取当前文档绑定...";
			Delete6();
			base.Dispatcher.BeginInvoke((Action)delegate
			{
				CS_8_locals_4.cexVjAsRxWj.Save2(CS_8_locals_4.text);
			}, DispatcherPriority.Background);
		}
	}

	private void Save2(string P_0)
	{
		try
		{
			binding2.Clear();
			foreach (TableComWriteService.TableBindingStatus item in TableComWriteService.GetAllTableBindings())
			{
				binding2.Add(item);
			}
			Execute5();
			cMdOYLAOjc();
			TableBindingTreeNode bindingNode = ((!string.IsNullOrWhiteSpace(P_0)) ? FindNodeByBindingId(_tableNodes, P_0) : null);
			rAUOlemBfZ(bindingNode ?? wDeOoeMhoh(_tableNodes));
			if (gridDataSources.SelectedItem == null && workbook2.Count > 0)
			{
				gridDataSources.SelectedIndex = 0;
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Load binding list failed", ex);
			LoggerInitializer.ShowError("读取绑定列表失败，请保存 Word 文档后重新打开 Excel 同步窗口。", "IP_Assurance");
		}
		finally
		{
			treeBindings.IsEnabled = true;
			barAllLoading.Visibility = Visibility.Collapsed;
			_bool = false;
			Execute6();
			sJTOjaskhb();
			Execute22();
			Sync8();
			Delete6();
			EohOwGuhvN();
		}
	}

	private void Execute6()
	{
		int count = binding2.Count;
		int num = binding2.Count((TableComWriteService.TableBindingStatus item) => string.Equals(item.Status, "共 {0} 个绑定，正常 {1} 个，异常 {2} 个。", StringComparison.OrdinalIgnoreCase));
		txtAllSummary.Text = ((count == 0) ? "当前文档未发现 Excel 绑定关系。" : string.Format("当前绑定还没有 Word 标题层级缓存；点击“刷新绑定信息”后会按 Word 标题树归类。", count, num, count - num));
		if (count > 0 && !binding2.Any((TableComWriteService.TableBindingStatus item) => item.HeadingPath != null && item.HeadingPath.Count > 0))
		{
			txtAllStatus.Text = "选择左侧表格会定位 Word 表格；可在右侧 Excel 路径处跳转源区域。";
		}
		else if (string.IsNullOrWhiteSpace(txtAllStatus.Text))
		{
			txtAllStatus.Text = ((count == 0) ? string.Empty : "拆分表");
		}
	}

	private void sJTOjaskhb()
	{
		TableComWriteService.TableBindingStatus selectedBinding = SelectedBinding;
		txtAllDetailEmpty.Visibility = ((selectedBinding != null) ? Visibility.Collapsed : Visibility.Visible);
		panelAllDetailContent.Visibility = ((selectedBinding == null) ? Visibility.Collapsed : Visibility.Visible);
		if (selectedBinding != null)
		{
			txtAllDetailTitle.Text = selectedBinding.DisplayTitle ?? selectedBinding.WordTableLabel ?? string.Empty;
			txtAllDetailHeading.Text = (string.IsNullOrWhiteSpace(selectedBinding.HeadingPathText) ? "未归类表格" : selectedBinding.HeadingPathText);
			txtAllDetailStatus.Text = selectedBinding.Status ?? string.Empty;
			txtAllDetailWordTable.Text = selectedBinding.WordTableLabel ?? string.Empty;
			txtAllDetailWorkbook.Text = selectedBinding.WorkbookName ?? string.Empty;
			txtAllDetailSheet.Text = selectedBinding.SheetName ?? string.Empty;
			txtAllDetailName.Text = selectedBinding.ExcelName ?? string.Empty;
			runAllDetailPath.Text = selectedBinding.ResolvedExcelPath ?? selectedBinding.ExcelFullPath ?? string.Empty;
			txtAllHeaderRows.Text = (selectedBinding.HeaderRowCount.HasValue ? selectedBinding.HeaderRowCount.Value.ToString() : string.Empty);
			chkAllSortEnabled.IsChecked = selectedBinding.SortEnabled;
			txtAllSortColumnIndex.Text = (selectedBinding.SortColumnIndex ?? 2).ToString();
			cboAllSortDirection.SelectedIndex = ((selectedBinding.SortDescending == false) ? 1 : 0);
			chkAllSortPinOtherLast.IsChecked = selectedBinding.SortPinOtherLast != false;
			PopulateColumnMappings(PtTngkISNu, selectedBinding.ColumnMappings, selectedBinding.WordColumnCount);
			txtAllDetailBindingId.Text = "绑定ID：" + (selectedBinding.BindingId ?? string.Empty);
			txtAllDetailBookmark.Text = "Word书签：" + (selectedBinding.WordBookmark ?? string.Empty);
		}
		else
		{
			txtAllDetailTitle.Text = string.Empty;
			txtAllDetailHeading.Text = string.Empty;
			txtAllDetailStatus.Text = string.Empty;
			txtAllDetailWordTable.Text = string.Empty;
			txtAllDetailWorkbook.Text = string.Empty;
			txtAllDetailSheet.Text = string.Empty;
			txtAllDetailName.Text = string.Empty;
			runAllDetailPath.Text = string.Empty;
			txtAllHeaderRows.Text = string.Empty;
			chkAllSortEnabled.IsChecked = false;
			txtAllSortColumnIndex.Text = "2";
			cboAllSortDirection.SelectedIndex = 0;
			chkAllSortPinOtherLast.IsChecked = true;
			PtTngkISNu.Clear();
			txtAllDetailBindingId.Text = string.Empty;
			txtAllDetailBookmark.Text = string.Empty;
		}
		string text = string.Empty;
		if (selectedBinding != null && !string.IsNullOrWhiteSpace(selectedBinding.ErrorMessage))
		{
			text = selectedBinding.ErrorMessage;
		}
		else if (selectedBinding != null && !string.Equals(selectedBinding.Status, "正常", StringComparison.OrdinalIgnoreCase))
		{
			text = selectedBinding.Status ?? string.Empty;
		}
		bool flag = !string.IsNullOrWhiteSpace(text);
		borderAllError.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		txtAllError.Text = (flag ? text : string.Empty);
	}

	private void cMdOYLAOjc()
	{
		_G_c__DisplayClass66_0 CS_8_locals_3 = new _G_c__DisplayClass66_0();
		CS_8_locals_3.text = SelectedDataSourceGroup?.ResolvedExcelPath;
		workbook2.Clear();
		foreach (TableComWriteService.WorkbookBindingSummary item in YEhOZcKFuM())
		{
			workbook2.Add(item);
		}
		TableComWriteService.WorkbookBindingSummary workbook3 = null;
		if (!string.IsNullOrWhiteSpace(CS_8_locals_3.text))
		{
			workbook3 = workbook2.FirstOrDefault((TableComWriteService.WorkbookBindingSummary group) => string.Equals(group.ResolvedExcelPath, CS_8_locals_3.text, StringComparison.OrdinalIgnoreCase));
		}
		if (workbook3 != null)
		{
			gridDataSources.SelectedItem = workbook3;
		}
		else if (workbook2.Count > 0)
		{
			gridDataSources.SelectedIndex = 0;
		}
	}

	private IList<TableComWriteService.WorkbookBindingSummary> YEhOZcKFuM()
	{
		return TableComWriteService.GroupBindingsByWorkbook(binding2);
	}

	private void Execute22()
	{
		int count = workbook2.Count;
		int num = workbook2.Sum((TableComWriteService.WorkbookBindingSummary group) => group.BindingCount);
		int num2 = workbook2.Sum((TableComWriteService.WorkbookBindingSummary group) => group.MissingPathCount);
		txtDataSourceSummary.Text = ((count == 0) ? "共 {0} 个数据源，{1} 个绑定，路径异常 {2} 个。" : string.Format("当前文档未发现 Excel 数据源。", count, num, num2));
		if (string.IsNullOrWhiteSpace(txtDataSourceStatusBar.Text))
		{
			txtDataSourceStatusBar.Text = ((count == 0) ? string.Empty : "选择一个 Excel 数据源后，可以查看关联表或更换来源。");
		}
	}

	private void Sync8()
	{
		TableComWriteService.WorkbookBindingSummary selectedDataSourceGroup = SelectedDataSourceGroup;
		txtDataSourceEmpty.Visibility = ((selectedDataSourceGroup != null) ? Visibility.Collapsed : Visibility.Visible);
		panelDataSourceDetailContent.Visibility = ((selectedDataSourceGroup == null) ? Visibility.Collapsed : Visibility.Visible);
		if (selectedDataSourceGroup != null)
		{
			txtDataSourceTitle.Text = (string.IsNullOrWhiteSpace(selectedDataSourceGroup.WorkbookName) ? "未命名数据源" : selectedDataSourceGroup.WorkbookName);
			txtDataSourceStatus.Text = selectedDataSourceGroup.Status ?? string.Empty;
			txtDataSourcePath.Text = selectedDataSourceGroup.ResolvedExcelPath ?? string.Empty;
			txtDataSourceBindingCount.Text = selectedDataSourceGroup.BindingCount.ToString();
			txtDataSourceNormalCount.Text = selectedDataSourceGroup.NormalCount.ToString();
			txtDataSourceMissingPathCount.Text = selectedDataSourceGroup.MissingPathCount.ToString();
			listDataSourceBindings.ItemsSource = selectedDataSourceGroup.Bindings ?? new List<TableComWriteService.TableBindingStatus>();
			if (listDataSourceBindings.SelectedItem == null && listDataSourceBindings.Items.Count > 0)
			{
				listDataSourceBindings.SelectedIndex = 0;
			}
		}
		else
		{
			txtDataSourceTitle.Text = string.Empty;
			txtDataSourceStatus.Text = string.Empty;
			txtDataSourcePath.Text = string.Empty;
			txtDataSourceBindingCount.Text = string.Empty;
			txtDataSourceNormalCount.Text = string.Empty;
			txtDataSourceMissingPathCount.Text = string.Empty;
			listDataSourceBindings.ItemsSource = null;
		}
	}

	private void jlKObjnrQv()
	{
		bool flag = bNZnKlpICU != null && bNZnKlpICU.HasWordTable;
		bool flag2 = bNZnKlpICU != null && bNZnKlpICU.HasBinding;
		bool flag3 = bNZnKlpICU != null && bNZnKlpICU.HasExcelSelection;
		bool isEnabled = !_bool && flag && flag2 && chkSortEnabled.IsChecked == true;
		if (flag2)
		{
			btnPrimaryCurrent.Content = "同步当前表";
		}
		else if (flag)
		{
			btnPrimaryCurrent.Content = "绑定当前表";
		}
		else
		{
			btnPrimaryCurrent.Content = "插入Excel选区";
		}
		btnPrimaryCurrent.IsEnabled = !_bool && (flag2 || (flag && flag3) || (!flag && flag3));
		btnSplitCurrentTable.IsEnabled = !_bool && flag && flag2;
		btnRebind.IsEnabled = !_bool && flag && flag2 && flag3;
		btnUnbind.IsEnabled = !_bool && flag && flag2;
		btnSaveHeaderSetting.IsEnabled = !_bool && flag && flag2;
		btnRefreshExcelSelection.IsEnabled = !_bool;
		linkCurrentBindingSource.IsEnabled = !_bool && flag2;
		txtHeaderRows.IsEnabled = !_bool && flag && flag2;
		gridColumnMappings.IsEnabled = !_bool && flag && flag2;
		gridColumnMappings.IsReadOnly = !(!_bool && flag && flag2);
		chkSortEnabled.IsEnabled = !_bool && flag && flag2;
		txtSortColumnIndex.IsEnabled = isEnabled;
		cboSortDirection.IsEnabled = isEnabled;
		chkSortPinOtherLast.IsEnabled = isEnabled;
	}

	private void Delete6()
	{
		TableComWriteService.TableBindingStatus selectedBinding = SelectedBinding;
		bool flag = selectedBinding != null;
		bool flag2 = !_bool && !_bool && !_bool;
		bool flag3 = binding2.Any((TableComWriteService.TableBindingStatus item) => string.Equals(item.Status, "确定要解除当前 Word 表格的 Excel 绑定吗？\\n\\n只会清理 Word 文档中的绑定信息，不会删除 Excel 工作簿里的名称区域。", StringComparison.OrdinalIgnoreCase));
		bool isEnabled = flag2 && flag && selectedBinding.CanSync && chkAllSortEnabled.IsChecked == true;
		btnRefreshAll.IsEnabled = flag2;
		linkAllDetailPath.IsEnabled = flag2 && flag && selectedBinding.CanJumpExcel;
		btnSyncSelected.IsEnabled = flag2 && flag && selectedBinding.CanSync;
		btnSyncAll.IsEnabled = flag2;
		btnExportAll.IsEnabled = flag2;
		btnCleanInvalidBindings.IsEnabled = flag2 && flag3;
		btnSaveAllHeaderSetting.IsEnabled = flag2 && flag && selectedBinding.CanSync;
		txtAllHeaderRows.IsEnabled = flag2 && flag && selectedBinding.CanSync;
		gridAllColumnMappings.IsEnabled = flag2 && flag && selectedBinding.CanSync;
		gridAllColumnMappings.IsReadOnly = !(flag2 && flag) || !selectedBinding.CanSync;
		chkAllSortEnabled.IsEnabled = flag2 && flag && selectedBinding.CanSync;
		txtAllSortColumnIndex.IsEnabled = isEnabled;
		cboAllSortDirection.IsEnabled = isEnabled;
		chkAllSortPinOtherLast.IsEnabled = isEnabled;
	}

	private void EohOwGuhvN()
	{
		TableComWriteService.WorkbookBindingSummary selectedDataSourceGroup = SelectedDataSourceGroup;
		bool flag = selectedDataSourceGroup != null;
		bool flag2 = !_bool && !_bool && !_bool;
		bool flag3 = flag && !string.IsNullOrWhiteSpace(selectedDataSourceGroup.ResolvedExcelPath);
		btnRefreshDataSources.IsEnabled = flag2;
		gridDataSources.IsEnabled = flag2;
		listDataSourceBindings.IsEnabled = flag2 && flag;
		btnReplaceDataSource.IsEnabled = flag2 && flag && selectedDataSourceGroup.BindingCount > 0;
		btnOpenDataSourceFolder.IsEnabled = flag2 && flag3;
		btnJumpDataSourceBinding.IsEnabled = flag2 && SelectedDataSourceBinding != null;
	}

	private void Execute20()
	{
		bool isLoaded = ExcelDataSyncService.IsLoaded;
		btnToggleContextMenu.Content = (isLoaded ? "加载右键菜单" : "卸载右键菜单");
		txtContextMenuStatus.Text = (isLoaded ? "状态：未加载。" : "状态：已加载。");
	}

	private void Execute8()
	{
		Visibility visibility = ((chkShowAdvancedColumns.IsChecked != true) ? Visibility.Collapsed : Visibility.Visible);
		panelAllAdvancedDetails.Visibility = visibility;
	}

	private void Execute5()
	{
		_tableNodes.Clear();
		TableBindingTreeNode bindingNode = null;
		foreach (TableComWriteService.TableBindingStatus item in binding2.OrderBy((TableComWriteService.TableBindingStatus binding) => (binding.WordTableIndex > 0) ? binding.WordTableIndex : int.MaxValue))
		{
			IList<TableComWriteService.HeadingPathItem> list = item.HeadingPath ?? new List<TableComWriteService.HeadingPathItem>();
			ObservableCollection<TableBindingTreeNode> children = _tableNodes;
			TableBindingTreeNode parent = null;
			if (list.Count == 0)
			{
				if (bindingNode == null)
				{
					bindingNode = new TableBindingTreeNode
					{
						Text = "未归类表格",
						IsHeading = true,
						IsExpanded = true
					};
					_tableNodes.Add(bindingNode);
				}
				parent = bindingNode;
				children = bindingNode.Children;
			}
			else
			{
				using IEnumerator<TableComWriteService.HeadingPathItem> enumerator2 = list.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_G_c__DisplayClass75_0 CS_8_locals_9 = new _G_c__DisplayClass75_0();
					CS_8_locals_9.headingItem = enumerator2.Current;
					CS_8_locals_9.text2 = (string.IsNullOrWhiteSpace(CS_8_locals_9.headingItem.Text) ? "未命名标题" : CS_8_locals_9.headingItem.Text);
					TableBindingTreeNode headingNode = children.FirstOrDefault((TableBindingTreeNode existing) => existing.IsHeading && existing.Level == CS_8_locals_9.headingItem.Level && string.Equals(existing.Text, CS_8_locals_9.text2, StringComparison.Ordinal));
					if (headingNode == null)
					{
						headingNode = new TableBindingTreeNode
						{
							Text = CS_8_locals_9.text2,
							Level = CS_8_locals_9.headingItem.Level,
							IsHeading = true,
							IsExpanded = (CS_8_locals_9.headingItem.Level <= 3),
							Parent = parent
						};
						children.Add(headingNode);
					}
					parent = headingNode;
					children = headingNode.Children;
				}
			}
			bool flag = !string.Equals(item.Status, "正常", StringComparison.OrdinalIgnoreCase);
			children.Add(new TableBindingTreeNode
			{
				Text = (item.DisplayTitle ?? item.WordTableLabel ?? item.BindingId),
				StatusBadge = (flag ? item.Status : string.Empty),
				IsTable = true,
				IsError = flag,
				Binding = item,
				Parent = parent
			});
		}
	}

	private void rAUOlemBfZ(TableBindingTreeNode P_0)
	{
		ClearAllSelections(_tableNodes);
		_tableBindingTreeNode = ((P_0 != null && P_0.IsTable) ? P_0 : null);
		if (P_0 != null)
		{
			ExpandAllParents(P_0);
			P_0.IsSelected = true;
		}
		sJTOjaskhb();
		Delete6();
	}

	private static void ClearAllSelections(IEnumerable<TableBindingTreeNode> P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		foreach (TableBindingTreeNode item in P_0)
		{
			item.IsSelected = false;
			ClearAllSelections(item.Children);
		}
	}

	private static void ExpandAllParents(TableBindingTreeNode P_0)
	{
		for (TableBindingTreeNode bindingNode = P_0?.Parent; bindingNode != null; bindingNode = bindingNode.Parent)
		{
			bindingNode.IsExpanded = true;
		}
	}

	private static TableBindingTreeNode wDeOoeMhoh(IEnumerable<TableBindingTreeNode> P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		foreach (TableBindingTreeNode item in P_0)
		{
			if (item.IsTable)
			{
				return item;
			}
			TableBindingTreeNode bindingNode = wDeOoeMhoh(item.Children);
			if (bindingNode != null)
			{
				return bindingNode;
			}
		}
		return null;
	}

	private static TableBindingTreeNode FindNodeByBindingId(IEnumerable<TableBindingTreeNode> P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		foreach (TableBindingTreeNode item in P_0)
		{
			if (item.IsTable && item.Binding != null && string.Equals(item.Binding.BindingId, P_1, StringComparison.OrdinalIgnoreCase))
			{
				return item;
			}
			TableBindingTreeNode bindingNode = FindNodeByBindingId(item.Children, P_1);
			if (bindingNode != null)
			{
				return bindingNode;
			}
		}
		return null;
	}

	private static string FormatPathUpdateResult(TableComWriteService.ExcelPathUpdateResult P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return "未生成更换数据源预检结果。";
		}
		int num = P_0.MatchedItems?.Count ?? 0;
		int num2 = P_0.MissingItems?.Count ?? 0;
		List<string> list = new List<string>
		{
			"旧数据源：",
			P_0.OldPath ?? string.Empty,
			string.Empty,
			"新数据源：",
			P_0.NewPath ?? string.Empty,
			string.Empty,
			string.Format("可更换：{0} 个绑定", num),
			string.Format("缺失名称区域：{0} 个绑定", num2)
		};
		if (num2 > 0)
		{
			list.Add(string.Empty);
			list.Add("缺失清单：");
			foreach (TableComWriteService.BindingUpdateItem item in P_0.MissingItems.Take(10))
			{
				list.Add("- " + (item.DisplayTitle ?? item.BindingId ?? string.Empty) + " / " + (item.ExcelName ?? string.Empty));
			}
			if (num2 > 10)
			{
				list.Add(string.Format("... 还有 {0} 个", num2 - 10));
			}
		}
		list.Add(string.Empty);
		list.Add(P_1 ? "新文件没有匹配到任何名称区域，未修改绑定。" : "确认后只会更新匹配项；缺失项保留旧数据源。是否继续？");
		return string.Join(Environment.NewLine, list);
	}

	private static string ddYOpUEEfn(TableComWriteService.TableSyncStatus P_0)
	{
		if (P_0 == null)
		{
			return "请选择 Word 表格或 Excel 区域";
		}
		if (!P_0.HasWordTable)
		{
			if (!P_0.HasExcelSelection)
			{
				return "请选择 Word 表格或 Excel 区域";
			}
			return "可插入 Excel 选区";
		}
		if (!P_0.HasBinding)
		{
			return "当前表未绑定";
		}
		return "当前表已绑定";
	}

	private static string Insert3(TableComWriteService.TableSyncStatus P_0)
	{
		if (P_0 == null)
		{
			return "将光标放到 Word 表格内可绑定/同步；也可以先在 Excel 中选择区域，再插入为 Word 表格。";
		}
		if (!P_0.HasWordTable)
		{
			if (P_0.HasExcelSelection)
			{
				return "未定位到 Word 表格。可以将当前 Excel 选区插入到 Word 当前段落下方，并自动建立同步绑定。";
			}
			return "将光标放到 Word 表格内可绑定/同步；也可以先在 Excel 中选择区域，再插入并绑定为 Word 表格。";
		}
		if (P_0.HasBinding)
		{
			return "可以直接同步当前表；如需变更来源，可点击“重新绑定”。";
		}
		if (P_0.HasExcelSelection)
		{
			return "已检测到 Excel 选区，可以绑定当前 Word 表格。";
		}
		return "请在 Excel 中选择源区域后绑定当前 Word 表格。";
	}

	private static string Insert1(TableComWriteService.TableSyncStatus P_0)
	{
		if (P_0 == null || !P_0.HasBinding)
		{
			return "绑定后可设置表头行数。";
		}
		if (!string.IsNullOrWhiteSpace(P_0.HeaderSettingText))
		{
			return P_0.HeaderSettingText;
		}
		return "表头行数：尚未识别";
	}

	private static string Insert2(TableComWriteService.TableSyncStatus P_0)
	{
		if (P_0 == null || !P_0.HasWordTable)
		{
			if (P_0 == null || !P_0.HasExcelSelection)
			{
				return "未定位 Word 表格。";
			}
			return "可从当前 Excel 选区插入并绑定表格。";
		}
		if (!P_0.HasBinding)
		{
			return "尚未绑定。";
		}
		string text = ((!string.IsNullOrWhiteSpace(P_0.BoundFullPath)) ? P_0.BoundFullPath : (P_0.BoundWorkbook ?? string.Empty));
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return "已绑定。";
	}

	private static string FormatExcelStatus(TableComWriteService.TableSyncStatus P_0)
	{
		if (P_0 == null || !P_0.HasExcelSelection)
		{
			return P_0?.ExcelStatus ?? "未检测到 Excel 选区。";
		}
		string text = P_0.ExcelWorkbook ?? string.Empty;
		string text2 = P_0.ExcelSheet ?? string.Empty;
		string text3 = P_0.ExcelAddress ?? string.Empty;
		string text4 = P_0.ExcelSize ?? string.Empty;
		string text5 = string.Join(" / ", new string[3] { text, text2, text3 }.Where((string item) => !string.IsNullOrWhiteSpace(item)));
		if (!string.IsNullOrWhiteSpace(text4))
		{
			if (!string.IsNullOrWhiteSpace(text5))
			{
				return text5 + "（" + text4 + "）";
			}
			return text4;
		}
		if (!string.IsNullOrWhiteSpace(text5))
		{
			return text5;
		}
		return "已检测到 Excel 当前选区。";
	}

	private static void PopulateColumnMappings(ObservableCollection<ColumnMappingItem> P_0, IList<TableComWriteService.ColumnMapping> P_1, int P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		P_0.Clear();
		int num = Math.Max(0, P_2);
		if (num == 0 && P_1 != null)
		{
			num = P_1.Count;
		}
		_G_c__DisplayClass87_0 CS_8_locals_6 = new _G_c__DisplayClass87_0();
		CS_8_locals_6.value = 1;
		while (CS_8_locals_6.value <= num)
		{
			TableComWriteService.ColumnMapping ColumnMapping = P_1?.FirstOrDefault((TableComWriteService.ColumnMapping item) => item.WordColumnIndex == CS_8_locals_6.value);
			int num2 = ((ColumnMapping != null && ColumnMapping.ExcelColumnIndex > 0) ? ColumnMapping.ExcelColumnIndex : CS_8_locals_6.value);
			P_0.Add(new ColumnMappingItem
			{
				WordColumnIndex = CS_8_locals_6.value,
				ExcelColumnText = num2.ToString()
			});
			CS_8_locals_6.value++;
		}
	}

	private bool ivyOeDvgeh(System.Windows.Controls.TextBox P_0, out int P_1)
	{
		P_1 = 0;
		if (P_0 == null || !int.TryParse((P_0.Text ?? string.Empty).Trim(), out var result) || result < 0)
		{
			LoggerInitializer.ShowWarning("表头行数请输入 0 或正整数。", "IP_Assurance");
			P_0?.Focus();
			P_0?.SelectAll();
			return false;
		}
		P_1 = result;
		return true;
	}

	private bool ValidateSyncOptions(System.Windows.Controls.TextBox P_0, System.Windows.Controls.CheckBox P_1, System.Windows.Controls.TextBox P_2, System.Windows.Controls.ComboBox P_3, System.Windows.Controls.CheckBox P_4, IEnumerable<ColumnMappingItem> P_5, out int P_6, out int P_7, out bool P_8, out bool P_9, out List<int> P_10)
	{
		P_7 = 2;
		P_8 = true;
		P_9 = true;
		P_10 = null;
		if (!ivyOeDvgeh(P_0, out P_6))
		{
			return false;
		}
		if (!int.TryParse((P_2.Text ?? string.Empty).Trim(), out P_7) || P_7 < 1)
		{
			LoggerInitializer.ShowWarning("排序列请输入 1 或更大的整数。", "IP_Assurance");
			P_2.Focus();
			P_2.SelectAll();
			return false;
		}
		P_8 = P_3 == null || P_3.SelectedIndex != 1;
		P_9 = P_4 == null || P_4.IsChecked != false;
		if (!ValidateColumnMappings(P_5, out P_10))
		{
			return false;
		}
		return true;
	}

	private bool ValidateColumnMappings(IEnumerable<ColumnMappingItem> P_0, out List<int> P_1)
	{
		P_1 = new List<int>();
		if (P_0 == null)
		{
			return true;
		}
		int num = 0;
		foreach (ColumnMappingItem item in P_0)
		{
			if (item != null)
			{
				if (!int.TryParse((item.ExcelColumnText ?? string.Empty).Trim(), out var result) || result < 1)
				{
					LoggerInitializer.ShowWarning(string.Format("第 {0} 个 Word 列的 Excel 列号请输入 1 或更大的整数。", item.WordColumnIndex), "IP_Assurance");
					return false;
				}
				if (result <= num)
				{
					LoggerInitializer.ShowWarning("列映射中的 Excel 列号需要从左到右递增。", "IP_Assurance");
					return false;
				}
				P_1.Add(result);
				num = result;
			}
		}
		return true;
	}

	private static void CommitDataGridEdit(System.Windows.Controls.DataGrid P_0)
	{
		if (P_0 != null)
		{
			P_0.CommitEdit(DataGridEditingUnit.Cell, exitEditingMode: true);
			P_0.CommitEdit(DataGridEditingUnit.Row, exitEditingMode: true);
		}
	}

	private void Execute9(string P_0, Func<TableComWriteService.SyncResult> P_1, bool P_2)
	{
		_G_c__DisplayClass92_0 CS_8_locals_7 = new _G_c__DisplayClass92_0();
		CS_8_locals_7.actionFunc10 = P_1;
		if (_bool || CS_8_locals_7.actionFunc10 == null)
		{
			return;
		}
		string text = bNZnKlpICU?.BindingId;
		Execute19( true);
		MZEniWtslN = false;
		barCurrentProgress.IsIndeterminate = false;
		barAllProgress.IsIndeterminate = false;
		barCurrentProgress.Value = 0.0;
		barAllProgress.Value = 0.0;
		Execute7("正在处理...");
		Execute14();
		string text2 = string.Empty;
		try
		{
			CS_8_locals_7.syncResult2 = null;
			AiHelper_7.RunCommandWithUndo(delegate
			{
				CS_8_locals_7.syncResult2 = CS_8_locals_7.actionFunc10();
			}, P_0);
			Sync2(CS_8_locals_7.syncResult2);
			text2 = CS_8_locals_7.syncResult2?.Message ?? string.Empty;
		}
		finally
		{
			Execute19( false);
			XvJOKeRLxt( false);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				Execute7(text2);
			}
			if (_bool && P_2)
			{
				lmoOEgXMdh(bNZnKlpICU?.BindingId ?? text);
			}
		}
	}

	private void Execute23(string P_0, Func<TableComWriteService.SyncResult> P_1)
	{
		_G_c__DisplayClass93_0 CS_8_locals_7 = new _G_c__DisplayClass93_0();
		CS_8_locals_7.actionFunc9 = P_1;
		if (_bool || CS_8_locals_7.actionFunc9 == null)
		{
			return;
		}
		Execute19( true);
		Execute7("正在处理...");
		string text = string.Empty;
		try
		{
			CS_8_locals_7.gTxVYDrAlNL = null;
			AiHelper_7.RunCommand(delegate
			{
				CS_8_locals_7.gTxVYDrAlNL = CS_8_locals_7.actionFunc9();
			}, P_0);
			Sync2(CS_8_locals_7.gTxVYDrAlNL);
			text = CS_8_locals_7.gTxVYDrAlNL?.Message ?? string.Empty;
		}
		finally
		{
			Execute19( false);
			XvJOKeRLxt( false);
			if (!string.IsNullOrWhiteSpace(text))
			{
				Execute7(text);
			}
		}
	}

	private void Sync4(TableComWriteService.TableBindingStatus P_0)
	{
		if (!_bool && !_bool && P_0 != null && P_0.CanJumpExcel)
		{
			_bool = true;
			base.Cursor = System.Windows.Input.Cursors.Wait;
			Execute7("正在打开 Excel 并定位源区域，请稍候...");
			Delete6();
			Execute14();
			bool flag = false;
			string empty = string.Empty;
			bool requiresUserAction = false;
			try
			{
				flag = TableComWriteService.ValidateBindingSyncInternal(P_0, out empty, out requiresUserAction);
			}
			finally
			{
				_bool = false;
				base.Cursor = (_bool ? System.Windows.Input.Cursors.Wait : null);
				Delete6();
			}
			if (flag)
			{
				Execute7("已定位到 Excel 区域。");
				UiHelperService.ShowToastInfo("已定位到 Excel 区域。", "Excel同步");
				return;
			}
			string text = (string.IsNullOrWhiteSpace(empty) ? "未能定位到 Excel 区域。" : empty);
			Execute7(text);
			ExcelSyncRibbonHelper.ShowSyncResult(new TableComWriteService.SyncResult
			{
				Success = false,
				RequiresUserAction = requiresUserAction,
				Message = text
			}, "Excel同步");
		}
	}

	private void Sync2(TableComWriteService.SyncResult P_0)
	{
		if (P_0 != null)
		{
			Execute7(P_0.Message ?? string.Empty);
			ExcelSyncRibbonHelper.ShowSyncResult(P_0, "Excel同步");
		}
	}

	private bool XGtOAmBcpX(int P_0, int P_1, string P_2)
	{
		if (P_1 <= 0)
		{
			barCurrentProgress.IsIndeterminate = true;
			barAllProgress.IsIndeterminate = true;
			Execute7(P_2 ?? string.Empty);
			try
			{
				base.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
				{
				});
			}
			catch
			{
			}
			if (!MZEniWtslN)
			{
				return base.IsVisible;
			}
			return false;
		}
		barCurrentProgress.IsIndeterminate = false;
		barAllProgress.IsIndeterminate = false;
		int num = ((P_1 <= 0) ? 100 : ((int)Math.Round((double)P_0 * 100.0 / (double)P_1)));
		if (num < 0)
		{
			num = 0;
		}
		if (num > 100)
		{
			num = 100;
		}
		barCurrentProgress.Value = num;
		barAllProgress.Value = num;
		Execute7(P_2 ?? string.Empty);
		try
		{
			base.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
		}
		catch
		{
		}
		if (!MZEniWtslN)
		{
			return base.IsVisible;
		}
		return false;
	}

	private void Execute14()
	{
		try
		{
			base.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
		}
		catch
		{
		}
	}

	private void Execute19(bool P_0)
	{
		_bool = P_0;
		if (P_0)
		{
			Execute4();
		}
		base.Cursor = (P_0 ? System.Windows.Input.Cursors.Wait : null);
		btnCancelCurrent.IsEnabled = P_0;
		btnCancelAll.IsEnabled = P_0;
		btnCancelCurrent.Visibility = ((!P_0) ? Visibility.Collapsed : Visibility.Visible);
		btnCancelAll.Visibility = ((!P_0) ? Visibility.Collapsed : Visibility.Visible);
		barCurrentProgress.Visibility = ((!P_0) ? Visibility.Collapsed : Visibility.Visible);
		barAllProgress.Visibility = ((!P_0) ? Visibility.Collapsed : Visibility.Visible);
		if (!P_0)
		{
			barCurrentProgress.IsIndeterminate = false;
			barAllProgress.IsIndeterminate = false;
		}
		chkSyncHeaders.IsEnabled = !P_0;
		chkShowAdvancedColumns.IsEnabled = !P_0;
		btnToggleContextMenu.IsEnabled = !P_0;
		jlKObjnrQv();
		Delete6();
		EohOwGuhvN();
	}

	private void Execute7(string P_0)
	{
		string text = P_0 ?? string.Empty;
		txtCurrentStatus.Text = text;
		txtAllStatus.Text = text;
		txtDataSourceStatusBar.Text = text;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/excelsyncwindow.xaml", UriKind.Relative);
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
			tabSync = (System.Windows.Controls.TabControl)target;
			tabSync.SelectionChanged += fFuOIGKZTj;
			break;
		case 2:
			tabCurrent = (TabItem)target;
			break;
		case 3:
			barCurrentLoading = (System.Windows.Controls.ProgressBar)target;
			break;
		case 4:
			txtCurrentCardTitle = (TextBlock)target;
			break;
		case 5:
			btnRefreshExcelSelection = (System.Windows.Controls.Button)target;
			btnRefreshExcelSelection.Click += Delete3;
			break;
		case 6:
			txtWordStatus = (TextBlock)target;
			break;
		case 7:
			txtWordTable = (TextBlock)target;
			break;
		case 8:
			txtBindingSourceSummary = (TextBlock)target;
			break;
		case 9:
			linkCurrentBindingSource = (Hyperlink)target;
			linkCurrentBindingSource.Click += Delete7;
			break;
		case 10:
			runBindingSourceSummary = (Run)target;
			break;
		case 11:
			txtHeaderSetting = (TextBlock)target;
			break;
		case 12:
			lblExcelSelectionSummary = (TextBlock)target;
			break;
		case 13:
			txtExcelSelectionSummary = (TextBlock)target;
			break;
		case 14:
			txtBindingId = (System.Windows.Controls.TextBox)target;
			break;
		case 15:
			txtExcelName = (System.Windows.Controls.TextBox)target;
			break;
		case 16:
			txtBoundPath = (System.Windows.Controls.TextBox)target;
			break;
		case 17:
			txtBoundSheet = (System.Windows.Controls.TextBox)target;
			break;
		case 18:
			txtExcelStatus = (System.Windows.Controls.TextBox)target;
			break;
		case 19:
			txtExcelWorkbook = (System.Windows.Controls.TextBox)target;
			break;
		case 20:
			txtExcelSheet = (System.Windows.Controls.TextBox)target;
			break;
		case 21:
			txtExcelAddress = (System.Windows.Controls.TextBox)target;
			break;
		case 22:
			txtExcelSize = (System.Windows.Controls.TextBox)target;
			break;
		case 23:
			txtHeaderRows = (System.Windows.Controls.TextBox)target;
			break;
		case 24:
			chkSortEnabled = (System.Windows.Controls.CheckBox)target;
			chkSortEnabled.Checked += Execute15;
			chkSortEnabled.Unchecked += Execute15;
			break;
		case 25:
			txtSortColumnIndex = (System.Windows.Controls.TextBox)target;
			break;
		case 26:
			cboSortDirection = (System.Windows.Controls.ComboBox)target;
			break;
		case 27:
			chkSortPinOtherLast = (System.Windows.Controls.CheckBox)target;
			break;
		case 28:
			gridColumnMappings = (System.Windows.Controls.DataGrid)target;
			break;
		case 29:
			btnSaveHeaderSetting = (System.Windows.Controls.Button)target;
			btnSaveHeaderSetting.Click += Save3;
			break;
		case 30:
			btnPrimaryCurrent = (System.Windows.Controls.Button)target;
			btnPrimaryCurrent.Click += Delete4;
			break;
		case 31:
			btnSplitCurrentTable = (System.Windows.Controls.Button)target;
			btnSplitCurrentTable.Click += xifpeRxOvW;
			break;
		case 32:
			btnRebind = (System.Windows.Controls.Button)target;
			btnRebind.Click += tbkpcqdVrT;
			break;
		case 33:
			btnUnbind = (System.Windows.Controls.Button)target;
			btnUnbind.Click += Save1;
			break;
		case 34:
			barCurrentProgress = (System.Windows.Controls.ProgressBar)target;
			break;
		case 35:
			txtCurrentStatus = (TextBlock)target;
			break;
		case 36:
			btnCancelCurrent = (System.Windows.Controls.Button)target;
			btnCancelCurrent.Click += vNHOVaYlKI;
			break;
		case 37:
			tabAll = (TabItem)target;
			break;
		case 38:
			txtAllSummary = (TextBlock)target;
			break;
		case 39:
			btnRefreshAll = (System.Windows.Controls.Button)target;
			btnRefreshAll.Click += Delete2;
			break;
		case 40:
			btnCleanInvalidBindings = (System.Windows.Controls.Button)target;
			btnCleanInvalidBindings.Click += Delete5;
			break;
		case 41:
			barAllLoading = (System.Windows.Controls.ProgressBar)target;
			break;
		case 42:
			treeBindings = (System.Windows.Controls.TreeView)target;
			treeBindings.SelectedItemChanged += Execute2;
			break;
		case 43:
			txtAllDetailEmpty = (TextBlock)target;
			break;
		case 44:
			panelAllDetailContent = (ScrollViewer)target;
			break;
		case 45:
			txtAllDetailTitle = (TextBlock)target;
			break;
		case 46:
			txtAllDetailHeading = (TextBlock)target;
			break;
		case 47:
			txtAllDetailStatus = (TextBlock)target;
			break;
		case 48:
			txtAllDetailWordTable = (TextBlock)target;
			break;
		case 49:
			txtAllDetailWorkbook = (TextBlock)target;
			break;
		case 50:
			txtAllDetailSheet = (TextBlock)target;
			break;
		case 51:
			txtAllDetailName = (TextBlock)target;
			break;
		case 52:
			linkAllDetailPath = (Hyperlink)target;
			linkAllDetailPath.Click += OWypxBxIqE;
			break;
		case 53:
			runAllDetailPath = (Run)target;
			break;
		case 54:
			txtAllHeaderRows = (System.Windows.Controls.TextBox)target;
			break;
		case 55:
			chkAllSortEnabled = (System.Windows.Controls.CheckBox)target;
			chkAllSortEnabled.Checked += Execute15;
			chkAllSortEnabled.Unchecked += Execute15;
			break;
		case 56:
			txtAllSortColumnIndex = (System.Windows.Controls.TextBox)target;
			break;
		case 57:
			cboAllSortDirection = (System.Windows.Controls.ComboBox)target;
			break;
		case 58:
			chkAllSortPinOtherLast = (System.Windows.Controls.CheckBox)target;
			break;
		case 59:
			gridAllColumnMappings = (System.Windows.Controls.DataGrid)target;
			break;
		case 60:
			btnSaveAllHeaderSetting = (System.Windows.Controls.Button)target;
			btnSaveAllHeaderSetting.Click += afQpFDqfMW;
			break;
		case 61:
			panelAllAdvancedDetails = (StackPanel)target;
			break;
		case 62:
			txtAllDetailBindingId = (TextBlock)target;
			break;
		case 63:
			txtAllDetailBookmark = (TextBlock)target;
			break;
		case 64:
			borderAllError = (System.Windows.Controls.Border)target;
			break;
		case 65:
			txtAllError = (TextBlock)target;
			break;
		case 66:
			barAllProgress = (System.Windows.Controls.ProgressBar)target;
			break;
		case 67:
			txtAllStatus = (TextBlock)target;
			break;
		case 68:
			btnSyncSelected = (System.Windows.Controls.Button)target;
			btnSyncSelected.Click += Sync7;
			break;
		case 69:
			btnSyncAll = (System.Windows.Controls.Button)target;
			btnSyncAll.Click += Write2;
			break;
		case 70:
			btnExportAll = (System.Windows.Controls.Button)target;
			btnExportAll.Click += Delete1;
			break;
		case 71:
			btnCancelAll = (System.Windows.Controls.Button)target;
			btnCancelAll.Click += vNHOVaYlKI;
			break;
		case 72:
			tabDataSources = (TabItem)target;
			break;
		case 73:
			txtDataSourceSummary = (TextBlock)target;
			break;
		case 74:
			btnRefreshDataSources = (System.Windows.Controls.Button)target;
			btnRefreshDataSources.Click += Save5;
			break;
		case 75:
			gridDataSources = (System.Windows.Controls.DataGrid)target;
			gridDataSources.SelectionChanged += Execute13;
			break;
		case 76:
			txtDataSourceEmpty = (TextBlock)target;
			break;
		case 77:
			panelDataSourceDetailContent = (ScrollViewer)target;
			break;
		case 78:
			txtDataSourceTitle = (TextBlock)target;
			break;
		case 79:
			txtDataSourceStatus = (TextBlock)target;
			break;
		case 80:
			txtDataSourceBindingCount = (TextBlock)target;
			break;
		case 81:
			txtDataSourceNormalCount = (TextBlock)target;
			break;
		case 82:
			txtDataSourceMissingPathCount = (TextBlock)target;
			break;
		case 83:
			txtDataSourcePath = (TextBlock)target;
			break;
		case 84:
			btnReplaceDataSource = (System.Windows.Controls.Button)target;
			btnReplaceDataSource.Click += Save4;
			break;
		case 85:
			btnOpenDataSourceFolder = (System.Windows.Controls.Button)target;
			btnOpenDataSourceFolder.Click += LogError;
			break;
		case 86:
			btnJumpDataSourceBinding = (System.Windows.Controls.Button)target;
			btnJumpDataSourceBinding.Click += Sync5;
			break;
		case 87:
			listDataSourceBindings = (System.Windows.Controls.ListBox)target;
			listDataSourceBindings.SelectionChanged += Execute12;
			break;
		case 88:
			txtDataSourceStatusBar = (TextBlock)target;
			break;
		case 89:
			tabOptions = (TabItem)target;
			break;
		case 90:
			chkSyncHeaders = (System.Windows.Controls.CheckBox)target;
			chkSyncHeaders.Checked += Write3;
			chkSyncHeaders.Unchecked += Write3;
			break;
		case 91:
			txtContextMenuStatus = (TextBlock)target;
			break;
		case 92:
			btnToggleContextMenu = (System.Windows.Controls.Button)target;
			btnToggleContextMenu.Click += Write1;
			break;
		case 93:
			chkShowAdvancedColumns = (System.Windows.Controls.CheckBox)target;
			chkShowAdvancedColumns.Checked += Execute3;
			chkShowAdvancedColumns.Unchecked += Execute3;
			break;
		case 94:
			txtOptionsStatus = (TextBlock)target;
			break;
		default:
			_bool = true;
			break;
		}
	}

	[CompilerGenerated]
	private void Read3(object P_0, System.Windows.Input.KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void Read2(object P_0, RoutedEventArgs P_1)
	{
		txtAllSummary.Text = "切换到“全部表”后读取当前文档绑定。";
		txtDataSourceSummary.Text = "切换到“数据源”后按 Excel 文件路径查看绑定来源。";
		jpROigfFHQ();
		mxOOHYibqA();
		Execute21(false, true);
		Execute20();
		Execute8();
		sJTOjaskhb();
		Sync8();
		Delete6();
		EohOwGuhvN();
	}

	[CompilerGenerated]
	private void zxrOdnuicL(object P_0, EventArgs P_1)
	{
		YQpOQgxdib();
	}

	[CompilerGenerated]
	private TableComWriteService.SyncResult Sync3()
	{
		return TableComWriteService.SyncCurrentTable(XGtOAmBcpX);
	}

	[CompilerGenerated]
	private TableComWriteService.SyncResult ttlnRHBwlD()
	{
		return TableComWriteService.SyncAllTables(XGtOAmBcpX);
	}

	[CompilerGenerated]
	private TableComWriteService.SyncResult Sync6()
	{
		if (!ValidateBindingForSync(out var text, out var requiresUserAction))
		{
			return new TableComWriteService.SyncResult
			{
				Success = false,
				RequiresUserAction = requiresUserAction,
				Message = (string.IsNullOrWhiteSpace(text) ? "未能定位到选中的 Word 表格，无法同步选中表。" : text)
			};
		}
		return TableComWriteService.SyncCurrentTable(XGtOAmBcpX);
	}

	[CompilerGenerated]
	private TableComWriteService.SyncResult SyncAllTables()
	{
		return TableComWriteService.SyncAllTablesWithOptions(XGtOAmBcpX);
	}

	[CompilerGenerated]
	private void Execute1()
	{
		if (tabCurrent.IsSelected)
		{
			Execute17();
		}
		_dispatcherTimer.Stop();
		_dispatcherTimer.Start();
	}
}
