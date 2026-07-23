using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using AiConfigBootstrap;
using AiHelper_20;
using BatchTableAdjustService;
using TableBorderConfig;
using AiSseStreamService3;
using ScreenshotCaptureHelper2;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using WordTableToolService;
using AiHelper_12;
using ExcelInteropService;
using LoggerInitializer;

namespace TableComWriteService;

internal static class TableComWriteService
{
	private sealed class TableBindingContext
	{
		[CompilerGenerated]
		private readonly List<TableBinding> NBvVTkSJVNH;

		[CompilerGenerated]
		private readonly List<WordTableInfo> tableInfo;

		[CompilerGenerated]
		private readonly Dictionary<string, BookmarkInfo> bookmark3;

		[CompilerGenerated]
		private readonly Dictionary<string, BookmarkInfo> zHDVTzrHiUp;

		[CompilerGenerated]
		private string _loadError;

		public List<TableBinding> Bindings
		{
			[CompilerGenerated]
			get
			{
				return NBvVTkSJVNH;
			}
		}

		public List<WordTableInfo> Tables
		{
			[CompilerGenerated]
			get
			{
				return tableInfo;
			}
		}

		public Dictionary<string, BookmarkInfo> BookmarksById
		{
			[CompilerGenerated]
			get
			{
				return bookmark3;
			}
		}

		public Dictionary<string, BookmarkInfo> BookmarksByName
		{
			[CompilerGenerated]
			get
			{
				return zHDVTzrHiUp;
			}
		}

		public string LoadError
		{
			[CompilerGenerated]
			get
			{
				return _loadError;
			}
			[CompilerGenerated]
			set
			{
				_loadError = value;
			}
		}

		public TableBindingContext()
		{
			SseStreamInitializer.InitializeRuntime();
			NBvVTkSJVNH = new List<TableBinding>();
			tableInfo = new List<WordTableInfo>();
			bookmark3 = new Dictionary<string, BookmarkInfo>(StringComparer.OrdinalIgnoreCase);
			zHDVTzrHiUp = new Dictionary<string, BookmarkInfo>(StringComparer.OrdinalIgnoreCase);
		}
	}

	private sealed class WordTableInfo
	{
		[CompilerGenerated]
		private int vIxVgBfXecP;

		[CompilerGenerated]
		private int _start;

		[CompilerGenerated]
		private int _end;

		[CompilerGenerated]
		private int _rowCount;

		[CompilerGenerated]
		private int _columnCount;

		[CompilerGenerated]
		private string _tableTitle;

		[CompilerGenerated]
		private string gttVggRSVeM;

		[CompilerGenerated]
		private List<HeadingPathItem> _headingPath;

		public int Index
		{
			[CompilerGenerated]
			get
			{
				return vIxVgBfXecP;
			}
			[CompilerGenerated]
			set
			{
				vIxVgBfXecP = value;
			}
		}

		public int Start
		{
			[CompilerGenerated]
			get
			{
				return _start;
			}
			[CompilerGenerated]
			set
			{
				_start = value;
			}
		}

		public int End
		{
			[CompilerGenerated]
			get
			{
				return _end;
			}
			[CompilerGenerated]
			set
			{
				_end = value;
			}
		}

		public int RowCount
		{
			[CompilerGenerated]
			get
			{
				return _rowCount;
			}
			[CompilerGenerated]
			set
			{
				_rowCount = value;
			}
		}

		public int ColumnCount
		{
			[CompilerGenerated]
			get
			{
				return _columnCount;
			}
			[CompilerGenerated]
			set
			{
				_columnCount = value;
			}
		}

		public string TableTitle
		{
			[CompilerGenerated]
			get
			{
				return _tableTitle;
			}
			[CompilerGenerated]
			set
			{
				_tableTitle = value;
			}
		}

		public string DisplayTitle
		{
			[CompilerGenerated]
			get
			{
				return gttVggRSVeM;
			}
			[CompilerGenerated]
			set
			{
				gttVggRSVeM = value;
			}
		}

		public List<HeadingPathItem> HeadingPath
		{
			[CompilerGenerated]
			get
			{
				return _headingPath;
			}
			[CompilerGenerated]
			set
			{
				_headingPath = value;
			}
		}

		public WordTableInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class BookmarkInfo
	{
		[CompilerGenerated]
		private string _name;

		[CompilerGenerated]
		private int _start;

		[CompilerGenerated]
		private int _end;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return _name;
			}
			[CompilerGenerated]
			set
			{
				_name = value;
			}
		}

		public int Start
		{
			[CompilerGenerated]
			get
			{
				return _start;
			}
			[CompilerGenerated]
			set
			{
				_start = value;
			}
		}

		public int End
		{
			[CompilerGenerated]
			get
			{
				return _end;
			}
			[CompilerGenerated]
			set
			{
				_end = value;
			}
		}

		public BookmarkInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class TableStructureContext
	{
		[CompilerGenerated]
		private readonly List<WordTableStructure> _tables;

		[CompilerGenerated]
		private readonly List<TableBinding> binding1;

		[CompilerGenerated]
		private readonly Dictionary<string, TableBookmarkInfo> bookmark2;

		[CompilerGenerated]
		private readonly Dictionary<string, TableBookmarkInfo> bookmark1;

		public List<WordTableStructure> Tables
		{
			[CompilerGenerated]
			get
			{
				return _tables;
			}
		}

		public List<TableBinding> Bindings
		{
			[CompilerGenerated]
			get
			{
				return binding1;
			}
		}

		public Dictionary<string, TableBookmarkInfo> BookmarksById
		{
			[CompilerGenerated]
			get
			{
				return bookmark2;
			}
		}

		public Dictionary<string, TableBookmarkInfo> BookmarksByName
		{
			[CompilerGenerated]
			get
			{
				return bookmark1;
			}
		}

		public TableStructureContext()
		{
			SseStreamInitializer.InitializeRuntime();
			_tables = new List<WordTableStructure>();
			binding1 = new List<TableBinding>();
			bookmark2 = new Dictionary<string, TableBookmarkInfo>(StringComparer.OrdinalIgnoreCase);
			bookmark1 = new Dictionary<string, TableBookmarkInfo>(StringComparer.OrdinalIgnoreCase);
		}
	}

	private sealed class WordTableStructure
	{
		[CompilerGenerated]
		private int pQdVgEsAJBe;

		[CompilerGenerated]
		private int _start;

		[CompilerGenerated]
		private int _end;

		[CompilerGenerated]
		private int _rowCount;

		[CompilerGenerated]
		private int jjNVgYlAkHw;

		[CompilerGenerated]
		private string _previousParagraphText;

		[CompilerGenerated]
		private readonly List<HeadingInfo> nuTVgfSwrKQ;

		[CompilerGenerated]
		private readonly List<TableCellData> GIDVgMSNIIx;

		[CompilerGenerated]
		private readonly List<CellMergeInfo> xgZVgbqBbad;

		public int Index
		{
			[CompilerGenerated]
			get
			{
				return pQdVgEsAJBe;
			}
			[CompilerGenerated]
			set
			{
				pQdVgEsAJBe = value;
			}
		}

		public int Start
		{
			[CompilerGenerated]
			get
			{
				return _start;
			}
			[CompilerGenerated]
			set
			{
				_start = value;
			}
		}

		public int End
		{
			[CompilerGenerated]
			get
			{
				return _end;
			}
			[CompilerGenerated]
			set
			{
				_end = value;
			}
		}

		public int RowCount
		{
			[CompilerGenerated]
			get
			{
				return _rowCount;
			}
			[CompilerGenerated]
			set
			{
				_rowCount = value;
			}
		}

		public int ColumnCount
		{
			[CompilerGenerated]
			get
			{
				return jjNVgYlAkHw;
			}
			[CompilerGenerated]
			set
			{
				jjNVgYlAkHw = value;
			}
		}

		public string PreviousParagraphText
		{
			[CompilerGenerated]
			get
			{
				return _previousParagraphText;
			}
			[CompilerGenerated]
			set
			{
				_previousParagraphText = value;
			}
		}

		public List<HeadingInfo> HeadingPath
		{
			[CompilerGenerated]
			get
			{
				return nuTVgfSwrKQ;
			}
		}

		public List<TableCellData> Cells
		{
			[CompilerGenerated]
			get
			{
				return GIDVgMSNIIx;
			}
		}

		public List<CellMergeInfo> Merges
		{
			[CompilerGenerated]
			get
			{
				return xgZVgbqBbad;
			}
		}

		public WordTableStructure()
		{
			SseStreamInitializer.InitializeRuntime();
			nuTVgfSwrKQ = new List<HeadingInfo>();
			GIDVgMSNIIx = new List<TableCellData>();
			xgZVgbqBbad = new List<CellMergeInfo>();
		}
	}

	private sealed class TableCellData
	{
		[CompilerGenerated]
		private int _rowIndex;

		[CompilerGenerated]
		private int kKqVgtXjeow;

		[CompilerGenerated]
		private int _rowSpan;

		[CompilerGenerated]
		private int NjLVgsmVvMs;

		[CompilerGenerated]
		private string YUwVglGhTWe;

		public int RowIndex
		{
			[CompilerGenerated]
			get
			{
				return _rowIndex;
			}
			[CompilerGenerated]
			set
			{
				_rowIndex = value;
			}
		}

		public int ColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return kKqVgtXjeow;
			}
			[CompilerGenerated]
			set
			{
				kKqVgtXjeow = value;
			}
		}

		public int RowSpan
		{
			[CompilerGenerated]
			get
			{
				return _rowSpan;
			}
			[CompilerGenerated]
			set
			{
				_rowSpan = value;
			}
		}

		public int ColumnSpan
		{
			[CompilerGenerated]
			get
			{
				return NjLVgsmVvMs;
			}
			[CompilerGenerated]
			set
			{
				NjLVgsmVvMs = value;
			}
		}

		public string Text
		{
			[CompilerGenerated]
			get
			{
				return YUwVglGhTWe;
			}
			[CompilerGenerated]
			set
			{
				YUwVglGhTWe = value;
			}
		}

		public TableCellData()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class CellMergeInfo
	{
		[CompilerGenerated]
		private int jcrVgmnbKQi;

		[CompilerGenerated]
		private int _startColumn;

		[CompilerGenerated]
		private int VEwVgGuMHpn;

		[CompilerGenerated]
		private int _endColumn;

		public int StartRow
		{
			[CompilerGenerated]
			get
			{
				return jcrVgmnbKQi;
			}
			[CompilerGenerated]
			set
			{
				jcrVgmnbKQi = value;
			}
		}

		public int StartColumn
		{
			[CompilerGenerated]
			get
			{
				return _startColumn;
			}
			[CompilerGenerated]
			set
			{
				_startColumn = value;
			}
		}

		public int EndRow
		{
			[CompilerGenerated]
			get
			{
				return VEwVgGuMHpn;
			}
			[CompilerGenerated]
			set
			{
				VEwVgGuMHpn = value;
			}
		}

		public int EndColumn
		{
			[CompilerGenerated]
			get
			{
				return _endColumn;
			}
			[CompilerGenerated]
			set
			{
				_endColumn = value;
			}
		}

		public CellMergeInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class TableBookmarkInfo
	{
		[CompilerGenerated]
		private string _name;

		[CompilerGenerated]
		private int RYGVgngjqnr;

		[CompilerGenerated]
		private int _end;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return _name;
			}
			[CompilerGenerated]
			set
			{
				_name = value;
			}
		}

		public int Start
		{
			[CompilerGenerated]
			get
			{
				return RYGVgngjqnr;
			}
			[CompilerGenerated]
			set
			{
				RYGVgngjqnr = value;
			}
		}

		public int End
		{
			[CompilerGenerated]
			get
			{
				return _end;
			}
			[CompilerGenerated]
			set
			{
				_end = value;
			}
		}

		public TableBookmarkInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class TableSyncContext
	{
		[CompilerGenerated]
		private WordTableStructure JoXVgcStFwQ;

		[CompilerGenerated]
		private string _bindingId;

		[CompilerGenerated]
		private TableBinding _binding;

		[CompilerGenerated]
		private readonly List<HeadingInfo> CSaVgXdGwXk;

		[CompilerGenerated]
		private bool WHdVgFWIkNw;

		[CompilerGenerated]
		private int count5;

		[CompilerGenerated]
		private int _startRow;

		[CompilerGenerated]
		private int iLcVgqkyRHR;

		public WordTableStructure Table
		{
			[CompilerGenerated]
			get
			{
				return JoXVgcStFwQ;
			}
			[CompilerGenerated]
			set
			{
				JoXVgcStFwQ = value;
			}
		}

		public string BindingId
		{
			[CompilerGenerated]
			get
			{
				return _bindingId;
			}
			[CompilerGenerated]
			set
			{
				_bindingId = value;
			}
		}

		public TableBinding Binding
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

		public List<HeadingInfo> HeadingRows
		{
			[CompilerGenerated]
			get
			{
				return CSaVgXdGwXk;
			}
		}

		public bool HasTitleRow
		{
			[CompilerGenerated]
			get
			{
				return WHdVgFWIkNw;
			}
			[CompilerGenerated]
			set
			{
				WHdVgFWIkNw = value;
			}
		}

		public int TitleRow
		{
			[CompilerGenerated]
			get
			{
				return count5;
			}
			[CompilerGenerated]
			set
			{
				count5 = value;
			}
		}

		public int StartRow
		{
			[CompilerGenerated]
			get
			{
				return _startRow;
			}
			[CompilerGenerated]
			set
			{
				_startRow = value;
			}
		}

		public int EndRow
		{
			[CompilerGenerated]
			get
			{
				return iLcVgqkyRHR;
			}
			[CompilerGenerated]
			set
			{
				iLcVgqkyRHR = value;
			}
		}

		public TableSyncContext()
		{
			SseStreamInitializer.InitializeRuntime();
			CSaVgXdGwXk = new List<HeadingInfo>();
		}
	}

	private sealed class HeadingInfo
	{
		[CompilerGenerated]
		private string _text;

		[CompilerGenerated]
		private int fFfVgWvWOOq;

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

		public int Level
		{
			[CompilerGenerated]
			get
			{
				return fFfVgWvWOOq;
			}
			[CompilerGenerated]
			set
			{
				fFfVgWvWOOq = value;
			}
		}

		public HeadingInfo Clone()
		{
			return new HeadingInfo
			{
				Text = Text,
				Level = Level
			};
		}

		public HeadingInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class StyleInfo
	{
		[CompilerGenerated]
		private string _styleId;

		[CompilerGenerated]
		private string QRoVgxwHGkI;

		[CompilerGenerated]
		private int? _outlineLevel;

		public string StyleId
		{
			[CompilerGenerated]
			get
			{
				return _styleId;
			}
			[CompilerGenerated]
			set
			{
				_styleId = value;
			}
		}

		public string BasedOnStyleId
		{
			[CompilerGenerated]
			get
			{
				return QRoVgxwHGkI;
			}
			[CompilerGenerated]
			set
			{
				QRoVgxwHGkI = value;
			}
		}

		public int? OutlineLevel
		{
			[CompilerGenerated]
			get
			{
				return _outlineLevel;
			}
			[CompilerGenerated]
			set
			{
				_outlineLevel = value;
			}
		}

		public StyleInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	public sealed class TableBindingStatus
	{
		[CompilerGenerated]
		private int _index;

		[CompilerGenerated]
		private string _status;

		[CompilerGenerated]
		private string _bindingId;

		[CompilerGenerated]
		private string _wordBookmark;

		[CompilerGenerated]
		private int _wordTableIndex;

		[CompilerGenerated]
		private string _wordTableLabel;

		[CompilerGenerated]
		private string _tableTitle;

		[CompilerGenerated]
		private string _displayTitle;

		[CompilerGenerated]
		private string _headingPathText;

		[CompilerGenerated]
		private List<HeadingPathItem> _headingPath;

		[CompilerGenerated]
		private string _excelFullPath;

		[CompilerGenerated]
		private string _resolvedExcelPath;

		[CompilerGenerated]
		private string _excelRelativePath;

		[CompilerGenerated]
		private string _workbookName;

		[CompilerGenerated]
		private string _sheetName;

		[CompilerGenerated]
		private string _excelName;

		[CompilerGenerated]
		private string _excelAddress;

		[CompilerGenerated]
		private string _refersToAddress;

		[CompilerGenerated]
		private int _excelRows;

		[CompilerGenerated]
		private int _excelColumns;

		[CompilerGenerated]
		private string _sourceSize;

		[CompilerGenerated]
		private string _syncMode;

		[CompilerGenerated]
		private string _errorMessage;

		[CompilerGenerated]
		private bool _canJumpWord;

		[CompilerGenerated]
		private bool _canJumpExcel;

		[CompilerGenerated]
		private bool _canSync;

		[CompilerGenerated]
		private int? _headerRowCount;

		[CompilerGenerated]
		private bool _sortEnabled;

		[CompilerGenerated]
		private int? _sortColumnIndex;

		[CompilerGenerated]
		private bool? _sortDescending;

		[CompilerGenerated]
		private bool? _sortPinOtherLast;

		[CompilerGenerated]
		private int _wordColumnCount;

		[CompilerGenerated]
		private List<ColumnMapping> _columnMappings;

		[CompilerGenerated]
		private TableBinding _tableBinding;

		[CompilerGenerated]
		private Table _table;

		public int Index
		{
			[CompilerGenerated]
			get
			{
				return _index;
			}
			[CompilerGenerated]
			set
			{
				_index = value;
			}
		}

		public string Status
		{
			[CompilerGenerated]
			get
			{
				return _status;
			}
			[CompilerGenerated]
			set
			{
				_status = value;
			}
		}

		public string BindingId
		{
			[CompilerGenerated]
			get
			{
				return _bindingId;
			}
			[CompilerGenerated]
			set
			{
				_bindingId = value;
			}
		}

		public string WordBookmark
		{
			[CompilerGenerated]
			get
			{
				return _wordBookmark;
			}
			[CompilerGenerated]
			set
			{
				_wordBookmark = value;
			}
		}

		public int WordTableIndex
		{
			[CompilerGenerated]
			get
			{
				return _wordTableIndex;
			}
			[CompilerGenerated]
			set
			{
				_wordTableIndex = value;
			}
		}

		public string WordTableLabel
		{
			[CompilerGenerated]
			get
			{
				return _wordTableLabel;
			}
			[CompilerGenerated]
			set
			{
				_wordTableLabel = value;
			}
		}

		public string TableTitle
		{
			[CompilerGenerated]
			get
			{
				return _tableTitle;
			}
			[CompilerGenerated]
			set
			{
				_tableTitle = value;
			}
		}

		public string DisplayTitle
		{
			[CompilerGenerated]
			get
			{
				return _displayTitle;
			}
			[CompilerGenerated]
			set
			{
				_displayTitle = value;
			}
		}

		public string HeadingPathText
		{
			[CompilerGenerated]
			get
			{
				return _headingPathText;
			}
			[CompilerGenerated]
			set
			{
				_headingPathText = value;
			}
		}

		public List<HeadingPathItem> HeadingPath
		{
			[CompilerGenerated]
			get
			{
				return _headingPath;
			}
			[CompilerGenerated]
			set
			{
				_headingPath = value;
			}
		}

		public string ExcelFullPath
		{
			[CompilerGenerated]
			get
			{
				return _excelFullPath;
			}
			[CompilerGenerated]
			set
			{
				_excelFullPath = value;
			}
		}

		public string ResolvedExcelPath
		{
			[CompilerGenerated]
			get
			{
				return _resolvedExcelPath;
			}
			[CompilerGenerated]
			set
			{
				_resolvedExcelPath = value;
			}
		}

		public string ExcelRelativePath
		{
			[CompilerGenerated]
			get
			{
				return _excelRelativePath;
			}
			[CompilerGenerated]
			set
			{
				_excelRelativePath = value;
			}
		}

		public string WorkbookName
		{
			[CompilerGenerated]
			get
			{
				return _workbookName;
			}
			[CompilerGenerated]
			set
			{
				_workbookName = value;
			}
		}

		public string SheetName
		{
			[CompilerGenerated]
			get
			{
				return _sheetName;
			}
			[CompilerGenerated]
			set
			{
				_sheetName = value;
			}
		}

		public string ExcelName
		{
			[CompilerGenerated]
			get
			{
				return _excelName;
			}
			[CompilerGenerated]
			set
			{
				_excelName = value;
			}
		}

		public string ExcelAddress
		{
			[CompilerGenerated]
			get
			{
				return _excelAddress;
			}
			[CompilerGenerated]
			set
			{
				_excelAddress = value;
			}
		}

		public string RefersToAddress
		{
			[CompilerGenerated]
			get
			{
				return _refersToAddress;
			}
			[CompilerGenerated]
			set
			{
				_refersToAddress = value;
			}
		}

		public int ExcelRows
		{
			[CompilerGenerated]
			get
			{
				return _excelRows;
			}
			[CompilerGenerated]
			set
			{
				_excelRows = value;
			}
		}

		public int ExcelColumns
		{
			[CompilerGenerated]
			get
			{
				return _excelColumns;
			}
			[CompilerGenerated]
			set
			{
				_excelColumns = value;
			}
		}

		public string SourceSize
		{
			[CompilerGenerated]
			get
			{
				return _sourceSize;
			}
			[CompilerGenerated]
			set
			{
				_sourceSize = value;
			}
		}

		public string SyncMode
		{
			[CompilerGenerated]
			get
			{
				return _syncMode;
			}
			[CompilerGenerated]
			set
			{
				_syncMode = value;
			}
		}

		public string ErrorMessage
		{
			[CompilerGenerated]
			get
			{
				return _errorMessage;
			}
			[CompilerGenerated]
			set
			{
				_errorMessage = value;
			}
		}

		public bool CanJumpWord
		{
			[CompilerGenerated]
			get
			{
				return _canJumpWord;
			}
			[CompilerGenerated]
			set
			{
				_canJumpWord = value;
			}
		}

		public bool CanJumpExcel
		{
			[CompilerGenerated]
			get
			{
				return _canJumpExcel;
			}
			[CompilerGenerated]
			set
			{
				_canJumpExcel = value;
			}
		}

		public bool CanSync
		{
			[CompilerGenerated]
			get
			{
				return _canSync;
			}
			[CompilerGenerated]
			set
			{
				_canSync = value;
			}
		}

		public int? HeaderRowCount
		{
			[CompilerGenerated]
			get
			{
				return _headerRowCount;
			}
			[CompilerGenerated]
			set
			{
				_headerRowCount = value;
			}
		}

		public bool SortEnabled
		{
			[CompilerGenerated]
			get
			{
				return _sortEnabled;
			}
			[CompilerGenerated]
			set
			{
				_sortEnabled = value;
			}
		}

		public int? SortColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return _sortColumnIndex;
			}
			[CompilerGenerated]
			set
			{
				_sortColumnIndex = value;
			}
		}

		public bool? SortDescending
		{
			[CompilerGenerated]
			get
			{
				return _sortDescending;
			}
			[CompilerGenerated]
			set
			{
				_sortDescending = value;
			}
		}

		public bool? SortPinOtherLast
		{
			[CompilerGenerated]
			get
			{
				return _sortPinOtherLast;
			}
			[CompilerGenerated]
			set
			{
				_sortPinOtherLast = value;
			}
		}

		public int WordColumnCount
		{
			[CompilerGenerated]
			get
			{
				return _wordColumnCount;
			}
			[CompilerGenerated]
			set
			{
				_wordColumnCount = value;
			}
		}

		public List<ColumnMapping> ColumnMappings
		{
			[CompilerGenerated]
			get
			{
				return _columnMappings;
			}
			[CompilerGenerated]
			set
			{
				_columnMappings = value;
			}
		}

		internal TableBinding Binding
		{
			[CompilerGenerated]
			get
			{
				return _tableBinding;
			}
			[CompilerGenerated]
			set
			{
				_tableBinding = value;
			}
		}

		internal Table Table
		{
			[CompilerGenerated]
			get
			{
				return _table;
			}
			[CompilerGenerated]
			set
			{
				_table = value;
			}
		}

		public TableBindingStatus()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	public sealed class WorkbookBindingSummary
	{
		[CompilerGenerated]
		private string _resolvedExcelPath;

		[CompilerGenerated]
		private string _workbookName;

		[CompilerGenerated]
		private int _bindingCount;

		[CompilerGenerated]
		private int _normalCount;

		[CompilerGenerated]
		private int _missingPathCount;

		[CompilerGenerated]
		private string _status;

		[CompilerGenerated]
		private List<TableBindingStatus> _bindings;

		public string ResolvedExcelPath
		{
			[CompilerGenerated]
			get
			{
				return _resolvedExcelPath;
			}
			[CompilerGenerated]
			set
			{
				_resolvedExcelPath = value;
			}
		}

		public string WorkbookName
		{
			[CompilerGenerated]
			get
			{
				return _workbookName;
			}
			[CompilerGenerated]
			set
			{
				_workbookName = value;
			}
		}

		public int BindingCount
		{
			[CompilerGenerated]
			get
			{
				return _bindingCount;
			}
			[CompilerGenerated]
			set
			{
				_bindingCount = value;
			}
		}

		public int NormalCount
		{
			[CompilerGenerated]
			get
			{
				return _normalCount;
			}
			[CompilerGenerated]
			set
			{
				_normalCount = value;
			}
		}

		public int MissingPathCount
		{
			[CompilerGenerated]
			get
			{
				return _missingPathCount;
			}
			[CompilerGenerated]
			set
			{
				_missingPathCount = value;
			}
		}

		public string Status
		{
			[CompilerGenerated]
			get
			{
				return _status;
			}
			[CompilerGenerated]
			set
			{
				_status = value;
			}
		}

		public List<TableBindingStatus> Bindings
		{
			[CompilerGenerated]
			get
			{
				return _bindings;
			}
			[CompilerGenerated]
			set
			{
				_bindings = value;
			}
		}

		public WorkbookBindingSummary()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	public sealed class ExcelPathUpdateResult
	{
		[CompilerGenerated]
		private string _oldPath;

		[CompilerGenerated]
		private string _newPath;

		[CompilerGenerated]
		private string _newWorkbookName;

		[CompilerGenerated]
		private List<BindingUpdateItem> _matchedItems;

		[CompilerGenerated]
		private List<BindingUpdateItem> _missingItems;

		public string OldPath
		{
			[CompilerGenerated]
			get
			{
				return _oldPath;
			}
			[CompilerGenerated]
			set
			{
				_oldPath = value;
			}
		}

		public string NewPath
		{
			[CompilerGenerated]
			get
			{
				return _newPath;
			}
			[CompilerGenerated]
			set
			{
				_newPath = value;
			}
		}

		public string NewWorkbookName
		{
			[CompilerGenerated]
			get
			{
				return _newWorkbookName;
			}
			[CompilerGenerated]
			set
			{
				_newWorkbookName = value;
			}
		}

		public List<BindingUpdateItem> MatchedItems
		{
			[CompilerGenerated]
			get
			{
				return _matchedItems;
			}
			[CompilerGenerated]
			set
			{
				_matchedItems = value;
			}
		}

		public List<BindingUpdateItem> MissingItems
		{
			[CompilerGenerated]
			get
			{
				return _missingItems;
			}
			[CompilerGenerated]
			set
			{
				_missingItems = value;
			}
		}

		public ExcelPathUpdateResult()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	public sealed class BindingUpdateItem
	{
		[CompilerGenerated]
		private string _bindingId;

		[CompilerGenerated]
		private string _displayTitle;

		[CompilerGenerated]
		private string _excelName;

		[CompilerGenerated]
		private string _newSheetName;

		public string BindingId
		{
			[CompilerGenerated]
			get
			{
				return _bindingId;
			}
			[CompilerGenerated]
			set
			{
				_bindingId = value;
			}
		}

		public string DisplayTitle
		{
			[CompilerGenerated]
			get
			{
				return _displayTitle;
			}
			[CompilerGenerated]
			set
			{
				_displayTitle = value;
			}
		}

		public string ExcelName
		{
			[CompilerGenerated]
			get
			{
				return _excelName;
			}
			[CompilerGenerated]
			set
			{
				_excelName = value;
			}
		}

		public string NewSheetName
		{
			[CompilerGenerated]
			get
			{
				return _newSheetName;
			}
			[CompilerGenerated]
			set
			{
				_newSheetName = value;
			}
		}

		public BindingUpdateItem()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	public sealed class SyncOperationResult
	{
		[CompilerGenerated]
		private bool _success;

		[CompilerGenerated]
		private int _updatedCount;

		[CompilerGenerated]
		private int _skippedCount;

		[CompilerGenerated]
		private string _message;

		public bool Success
		{
			[CompilerGenerated]
			get
			{
				return _success;
			}
			[CompilerGenerated]
			set
			{
				_success = value;
			}
		}

		public int UpdatedCount
		{
			[CompilerGenerated]
			get
			{
				return _updatedCount;
			}
			[CompilerGenerated]
			set
			{
				_updatedCount = value;
			}
		}

		public int SkippedCount
		{
			[CompilerGenerated]
			get
			{
				return _skippedCount;
			}
			[CompilerGenerated]
			set
			{
				_skippedCount = value;
			}
		}

		public string Message
		{
			[CompilerGenerated]
			get
			{
				return _message;
			}
			[CompilerGenerated]
			set
			{
				_message = value;
			}
		}

		public SyncOperationResult()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	public sealed class HeadingPathItem
	{
		[CompilerGenerated]
		private string _text;

		[CompilerGenerated]
		private int _level;

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

		public int Level
		{
			[CompilerGenerated]
			get
			{
				return _level;
			}
			[CompilerGenerated]
			set
			{
				_level = value;
			}
		}

		public HeadingPathItem()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	public sealed class ColumnMapping
	{
		[CompilerGenerated]
		private int sJsVIVteljU;

		[CompilerGenerated]
		private int _excelColumnIndex;

		public int WordColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return sJsVIVteljU;
			}
			[CompilerGenerated]
			set
			{
				sJsVIVteljU = value;
			}
		}

		public int ExcelColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return _excelColumnIndex;
			}
			[CompilerGenerated]
			set
			{
				_excelColumnIndex = value;
			}
		}

		public ColumnMapping()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	public sealed class TableSyncStatus
	{
		[CompilerGenerated]
		private bool _hasWordTable;

		[CompilerGenerated]
		private bool _hasBinding;

		[CompilerGenerated]
		private bool cSCVIDjOjxP;

		[CompilerGenerated]
		private string _wordStatus;

		[CompilerGenerated]
		private string _wordTableLabel;

		[CompilerGenerated]
		private string _bindingId;

		[CompilerGenerated]
		private string orwVIIyPddn;

		[CompilerGenerated]
		private string _excelWorkbook;

		[CompilerGenerated]
		private string _excelFullPath;

		[CompilerGenerated]
		private string _excelSheet;

		[CompilerGenerated]
		private string _excelAddress;

		[CompilerGenerated]
		private string EvZVIrSFucf;

		[CompilerGenerated]
		private string _boundWorkbook;

		[CompilerGenerated]
		private string _boundFullPath;

		[CompilerGenerated]
		private string _boundSheet;

		[CompilerGenerated]
		private string lJvVIKZGNjA;

		[CompilerGenerated]
		private int? KMjVIEfTHim;

		[CompilerGenerated]
		private string _headerSettingText;

		[CompilerGenerated]
		private bool _sortEnabled;

		[CompilerGenerated]
		private int? _sortColumnIndex;

		[CompilerGenerated]
		private bool? _sortDescending;

		[CompilerGenerated]
		private bool? AYQVIZ6B8EX;

		[CompilerGenerated]
		private int _wordColumnCount;

		[CompilerGenerated]
		private List<ColumnMapping> _columnMappings;

		[CompilerGenerated]
		private string _message;

		[CompilerGenerated]
		private string _technicalDetail;

		public bool HasWordTable
		{
			[CompilerGenerated]
			get
			{
				return _hasWordTable;
			}
			[CompilerGenerated]
			set
			{
				_hasWordTable = value;
			}
		}

		public bool HasBinding
		{
			[CompilerGenerated]
			get
			{
				return _hasBinding;
			}
			[CompilerGenerated]
			set
			{
				_hasBinding = value;
			}
		}

		public bool HasExcelSelection
		{
			[CompilerGenerated]
			get
			{
				return cSCVIDjOjxP;
			}
			[CompilerGenerated]
			set
			{
				cSCVIDjOjxP = value;
			}
		}

		public string WordStatus
		{
			[CompilerGenerated]
			get
			{
				return _wordStatus;
			}
			[CompilerGenerated]
			set
			{
				_wordStatus = value;
			}
		}

		public string WordTableLabel
		{
			[CompilerGenerated]
			get
			{
				return _wordTableLabel;
			}
			[CompilerGenerated]
			set
			{
				_wordTableLabel = value;
			}
		}

		public string BindingId
		{
			[CompilerGenerated]
			get
			{
				return _bindingId;
			}
			[CompilerGenerated]
			set
			{
				_bindingId = value;
			}
		}

		public string ExcelStatus
		{
			[CompilerGenerated]
			get
			{
				return orwVIIyPddn;
			}
			[CompilerGenerated]
			set
			{
				orwVIIyPddn = value;
			}
		}

		public string ExcelWorkbook
		{
			[CompilerGenerated]
			get
			{
				return _excelWorkbook;
			}
			[CompilerGenerated]
			set
			{
				_excelWorkbook = value;
			}
		}

		public string ExcelFullPath
		{
			[CompilerGenerated]
			get
			{
				return _excelFullPath;
			}
			[CompilerGenerated]
			set
			{
				_excelFullPath = value;
			}
		}

		public string ExcelSheet
		{
			[CompilerGenerated]
			get
			{
				return _excelSheet;
			}
			[CompilerGenerated]
			set
			{
				_excelSheet = value;
			}
		}

		public string ExcelAddress
		{
			[CompilerGenerated]
			get
			{
				return _excelAddress;
			}
			[CompilerGenerated]
			set
			{
				_excelAddress = value;
			}
		}

		public string ExcelSize
		{
			[CompilerGenerated]
			get
			{
				return EvZVIrSFucf;
			}
			[CompilerGenerated]
			set
			{
				EvZVIrSFucf = value;
			}
		}

		public string BoundWorkbook
		{
			[CompilerGenerated]
			get
			{
				return _boundWorkbook;
			}
			[CompilerGenerated]
			set
			{
				_boundWorkbook = value;
			}
		}

		public string BoundFullPath
		{
			[CompilerGenerated]
			get
			{
				return _boundFullPath;
			}
			[CompilerGenerated]
			set
			{
				_boundFullPath = value;
			}
		}

		public string BoundSheet
		{
			[CompilerGenerated]
			get
			{
				return _boundSheet;
			}
			[CompilerGenerated]
			set
			{
				_boundSheet = value;
			}
		}

		public string BoundExcelName
		{
			[CompilerGenerated]
			get
			{
				return lJvVIKZGNjA;
			}
			[CompilerGenerated]
			set
			{
				lJvVIKZGNjA = value;
			}
		}

		public int? HeaderRowCount
		{
			[CompilerGenerated]
			get
			{
				return KMjVIEfTHim;
			}
			[CompilerGenerated]
			set
			{
				KMjVIEfTHim = value;
			}
		}

		public string HeaderSettingText
		{
			[CompilerGenerated]
			get
			{
				return _headerSettingText;
			}
			[CompilerGenerated]
			set
			{
				_headerSettingText = value;
			}
		}

		public bool SortEnabled
		{
			[CompilerGenerated]
			get
			{
				return _sortEnabled;
			}
			[CompilerGenerated]
			set
			{
				_sortEnabled = value;
			}
		}

		public int? SortColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return _sortColumnIndex;
			}
			[CompilerGenerated]
			set
			{
				_sortColumnIndex = value;
			}
		}

		public bool? SortDescending
		{
			[CompilerGenerated]
			get
			{
				return _sortDescending;
			}
			[CompilerGenerated]
			set
			{
				_sortDescending = value;
			}
		}

		public bool? SortPinOtherLast
		{
			[CompilerGenerated]
			get
			{
				return AYQVIZ6B8EX;
			}
			[CompilerGenerated]
			set
			{
				AYQVIZ6B8EX = value;
			}
		}

		public int WordColumnCount
		{
			[CompilerGenerated]
			get
			{
				return _wordColumnCount;
			}
			[CompilerGenerated]
			set
			{
				_wordColumnCount = value;
			}
		}

		public List<ColumnMapping> ColumnMappings
		{
			[CompilerGenerated]
			get
			{
				return _columnMappings;
			}
			[CompilerGenerated]
			set
			{
				_columnMappings = value;
			}
		}

		public string Message
		{
			[CompilerGenerated]
			get
			{
				return _message;
			}
			[CompilerGenerated]
			set
			{
				_message = value;
			}
		}

		public string TechnicalDetail
		{
			[CompilerGenerated]
			get
			{
				return _technicalDetail;
			}
			[CompilerGenerated]
			set
			{
				_technicalDetail = value;
			}
		}

		public TableSyncStatus()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	public sealed class SyncResult
	{
		[CompilerGenerated]
		private bool _success;

		[CompilerGenerated]
		private bool _cancelled;

		[CompilerGenerated]
		private bool mnoVIsjusHR;

		[CompilerGenerated]
		private string EyKVIlUqaUw;

		[CompilerGenerated]
		private string _technicalDetail;

		[CompilerGenerated]
		private string _workbookPath;

		[CompilerGenerated]
		private int count6;

		[CompilerGenerated]
		private int _bound;

		[CompilerGenerated]
		private int _synced;

		[CompilerGenerated]
		private int _skippedCells;

		[CompilerGenerated]
		private int _failed;

		public bool Success
		{
			[CompilerGenerated]
			get
			{
				return _success;
			}
			[CompilerGenerated]
			set
			{
				_success = value;
			}
		}

		public bool Cancelled
		{
			[CompilerGenerated]
			get
			{
				return _cancelled;
			}
			[CompilerGenerated]
			set
			{
				_cancelled = value;
			}
		}

		public bool RequiresUserAction
		{
			[CompilerGenerated]
			get
			{
				return mnoVIsjusHR;
			}
			[CompilerGenerated]
			set
			{
				mnoVIsjusHR = value;
			}
		}

		public string Message
		{
			[CompilerGenerated]
			get
			{
				return EyKVIlUqaUw;
			}
			[CompilerGenerated]
			set
			{
				EyKVIlUqaUw = value;
			}
		}

		public string TechnicalDetail
		{
			[CompilerGenerated]
			get
			{
				return _technicalDetail;
			}
			[CompilerGenerated]
			set
			{
				_technicalDetail = value;
			}
		}

		public string WorkbookPath
		{
			[CompilerGenerated]
			get
			{
				return _workbookPath;
			}
			[CompilerGenerated]
			set
			{
				_workbookPath = value;
			}
		}

		public int Total
		{
			[CompilerGenerated]
			get
			{
				return count6;
			}
			[CompilerGenerated]
			set
			{
				count6 = value;
			}
		}

		public int Bound
		{
			[CompilerGenerated]
			get
			{
				return _bound;
			}
			[CompilerGenerated]
			set
			{
				_bound = value;
			}
		}

		public int Synced
		{
			[CompilerGenerated]
			get
			{
				return _synced;
			}
			[CompilerGenerated]
			set
			{
				_synced = value;
			}
		}

		public int SkippedCells
		{
			[CompilerGenerated]
			get
			{
				return _skippedCells;
			}
			[CompilerGenerated]
			set
			{
				_skippedCells = value;
			}
		}

		public int Failed
		{
			[CompilerGenerated]
			get
			{
				return _failed;
			}
			[CompilerGenerated]
			set
			{
				_failed = value;
			}
		}

		public SyncResult()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	internal delegate bool ProgressCallback(int current, int total, string message);

	internal sealed class SyncOptions
	{
		[CompilerGenerated]
		private bool _syncHeaders;

		public bool SyncHeaders
		{
			[CompilerGenerated]
			get
			{
				return _syncHeaders;
			}
			[CompilerGenerated]
			set
			{
				_syncHeaders = value;
			}
		}

		public SyncOptions()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	internal sealed class TableBinding
	{
		[CompilerGenerated]
		private string _id;

		[CompilerGenerated]
		private string _excelFullPath;

		[CompilerGenerated]
		private string text1;

		[CompilerGenerated]
		private string BVfVIFphOvb;

		[CompilerGenerated]
		private string _sheetName;

		[CompilerGenerated]
		private string _excelName;

		[CompilerGenerated]
		private string sKFVIqrdKnR;

		[CompilerGenerated]
		private string KuSVIPFneCX;

		[CompilerGenerated]
		private int? _headerRowCount;

		[CompilerGenerated]
		private bool flag2;

		[CompilerGenerated]
		private int? LnZVIWptMdU;

		[CompilerGenerated]
		private bool? _sortDescending;

		[CompilerGenerated]
		private bool? _sortPinOtherLast;

		[CompilerGenerated]
		private List<int> _columnMappings;

		[CompilerGenerated]
		private bool? cTKVIdZMATg;

		[CompilerGenerated]
		private int? dvQVIzpyXoB;

		[CompilerGenerated]
		private int? _wordTableRows;

		[CompilerGenerated]
		private int? _wordTableColumns;

		[CompilerGenerated]
		private string IZdViBZLHXG;

		[CompilerGenerated]
		private string _wordDisplayTitle;

		[CompilerGenerated]
		private List<HeadingPathItem> _wordHeadingPath;

		[CompilerGenerated]
		private string TZwViuWNygT;

		public string Id
		{
			[CompilerGenerated]
			get
			{
				return _id;
			}
			[CompilerGenerated]
			set
			{
				_id = value;
			}
		}

		public string ExcelFullPath
		{
			[CompilerGenerated]
			get
			{
				return _excelFullPath;
			}
			[CompilerGenerated]
			set
			{
				_excelFullPath = value;
			}
		}

		public string ExcelRelativePath
		{
			[CompilerGenerated]
			get
			{
				return text1;
			}
			[CompilerGenerated]
			set
			{
				text1 = value;
			}
		}

		public string WorkbookName
		{
			[CompilerGenerated]
			get
			{
				return BVfVIFphOvb;
			}
			[CompilerGenerated]
			set
			{
				BVfVIFphOvb = value;
			}
		}

		public string SheetName
		{
			[CompilerGenerated]
			get
			{
				return _sheetName;
			}
			[CompilerGenerated]
			set
			{
				_sheetName = value;
			}
		}

		public string ExcelName
		{
			[CompilerGenerated]
			get
			{
				return _excelName;
			}
			[CompilerGenerated]
			set
			{
				_excelName = value;
			}
		}

		public string WordBookmark
		{
			[CompilerGenerated]
			get
			{
				return sKFVIqrdKnR;
			}
			[CompilerGenerated]
			set
			{
				sKFVIqrdKnR = value;
			}
		}

		public string SyncMode
		{
			[CompilerGenerated]
			get
			{
				return KuSVIPFneCX;
			}
			[CompilerGenerated]
			set
			{
				KuSVIPFneCX = value;
			}
		}

		public int? HeaderRowCount
		{
			[CompilerGenerated]
			get
			{
				return _headerRowCount;
			}
			[CompilerGenerated]
			set
			{
				_headerRowCount = value;
			}
		}

		public bool SortEnabled
		{
			[CompilerGenerated]
			get
			{
				return flag2;
			}
			[CompilerGenerated]
			set
			{
				flag2 = value;
			}
		}

		public int? SortColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return LnZVIWptMdU;
			}
			[CompilerGenerated]
			set
			{
				LnZVIWptMdU = value;
			}
		}

		public bool? SortDescending
		{
			[CompilerGenerated]
			get
			{
				return _sortDescending;
			}
			[CompilerGenerated]
			set
			{
				_sortDescending = value;
			}
		}

		public bool? SortPinOtherLast
		{
			[CompilerGenerated]
			get
			{
				return _sortPinOtherLast;
			}
			[CompilerGenerated]
			set
			{
				_sortPinOtherLast = value;
			}
		}

		public List<int> ColumnMappings
		{
			[CompilerGenerated]
			get
			{
				return _columnMappings;
			}
			[CompilerGenerated]
			set
			{
				_columnMappings = value;
			}
		}

		public bool? WordTableIsComplex
		{
			[CompilerGenerated]
			get
			{
				return cTKVIdZMATg;
			}
			[CompilerGenerated]
			set
			{
				cTKVIdZMATg = value;
			}
		}

		public int? WordTableIndex
		{
			[CompilerGenerated]
			get
			{
				return dvQVIzpyXoB;
			}
			[CompilerGenerated]
			set
			{
				dvQVIzpyXoB = value;
			}
		}

		public int? WordTableRows
		{
			[CompilerGenerated]
			get
			{
				return _wordTableRows;
			}
			[CompilerGenerated]
			set
			{
				_wordTableRows = value;
			}
		}

		public int? WordTableColumns
		{
			[CompilerGenerated]
			get
			{
				return _wordTableColumns;
			}
			[CompilerGenerated]
			set
			{
				_wordTableColumns = value;
			}
		}

		public string WordTableTitle
		{
			[CompilerGenerated]
			get
			{
				return IZdViBZLHXG;
			}
			[CompilerGenerated]
			set
			{
				IZdViBZLHXG = value;
			}
		}

		public string WordDisplayTitle
		{
			[CompilerGenerated]
			get
			{
				return _wordDisplayTitle;
			}
			[CompilerGenerated]
			set
			{
				_wordDisplayTitle = value;
			}
		}

		public List<HeadingPathItem> WordHeadingPath
		{
			[CompilerGenerated]
			get
			{
				return _wordHeadingPath;
			}
			[CompilerGenerated]
			set
			{
				_wordHeadingPath = value;
			}
		}

		public string WordSnapshotUpdatedAt
		{
			[CompilerGenerated]
			get
			{
				return TZwViuWNygT;
			}
			[CompilerGenerated]
			set
			{
				TZwViuWNygT = value;
			}
		}

		public TableBinding()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private enum TableSourceKind
	{

	}

	private sealed class ExcelTableStructure
	{
		[CompilerGenerated]
		private sealed class _G_c__DisplayClass49_0
		{
			public int value;

			public _G_c__DisplayClass49_0()
			{
				SseStreamInitializer.InitializeRuntime();
			}

			internal bool mUjVSHEVpoE(ExcelCellData cell)
			{
				return cell.RowIndex == value;
			}
		}

		[CompilerGenerated]
		private TableSourceKind _sourceKind;

		[CompilerGenerated]
		private int fuyViKFRniy;

		[CompilerGenerated]
		private string _sheetName;

		[CompilerGenerated]
		private int _rowCount;

		[CompilerGenerated]
		private int _columnCount;

		[CompilerGenerated]
		private int _headerRowCount;

		[CompilerGenerated]
		private bool _hasVerticalMerge;

		[CompilerGenerated]
		private XElement _tableElement;

		[CompilerGenerated]
		private readonly List<XElement> _sourceKind1;

		[CompilerGenerated]
		private readonly List<ExcelCellData> _sourceKind3;

		[CompilerGenerated]
		private readonly List<ExcelMergeInfo> JZgVibIBcPj;

		private readonly Dictionary<string, ExcelCellData> CellMap;

		private readonly Dictionary<string, ExcelCellData> MergedCellMap;

		public TableSourceKind SourceKind
		{
			[CompilerGenerated]
			get
			{
				return _sourceKind;
			}
			[CompilerGenerated]
			set
			{
				_sourceKind = value;
			}
		}

		public int TableIndex
		{
			[CompilerGenerated]
			get
			{
				return fuyViKFRniy;
			}
			[CompilerGenerated]
			set
			{
				fuyViKFRniy = value;
			}
		}

		public string SheetName
		{
			[CompilerGenerated]
			get
			{
				return _sheetName;
			}
			[CompilerGenerated]
			set
			{
				_sheetName = value;
			}
		}

		public int RowCount
		{
			[CompilerGenerated]
			get
			{
				return _rowCount;
			}
			[CompilerGenerated]
			set
			{
				_rowCount = value;
			}
		}

		public int ColumnCount
		{
			[CompilerGenerated]
			get
			{
				return _columnCount;
			}
			[CompilerGenerated]
			set
			{
				_columnCount = value;
			}
		}

		public int HeaderRowCount
		{
			[CompilerGenerated]
			get
			{
				return _headerRowCount;
			}
			[CompilerGenerated]
			set
			{
				_headerRowCount = value;
			}
		}

		public bool HasVerticalMerge
		{
			[CompilerGenerated]
			get
			{
				return _hasVerticalMerge;
			}
			[CompilerGenerated]
			set
			{
				_hasVerticalMerge = value;
			}
		}

		public XElement TableElement
		{
			[CompilerGenerated]
			get
			{
				return _tableElement;
			}
			[CompilerGenerated]
			set
			{
				_tableElement = value;
			}
		}

		public List<XElement> RowElements
		{
			[CompilerGenerated]
			get
			{
				return _sourceKind1;
			}
		}

		public List<ExcelCellData> Cells
		{
			[CompilerGenerated]
			get
			{
				return _sourceKind3;
			}
		}

		public List<ExcelMergeInfo> Merges
		{
			[CompilerGenerated]
			get
			{
				return JZgVibIBcPj;
			}
		}

		public void AddCell(ExcelCellData P_0)
		{
			Cells.Add(P_0);
			CellMap[BuildCellKey(P_0.RowIndex, P_0.ColumnIndex)] = P_0;
		}

		public void SetMergedCell(int P_0, int P_1, ExcelCellData P_2)
		{
			MergedCellMap[BuildCellKey(P_0, P_1)] = P_2;
		}

		public bool HasCell(int P_0, int P_1)
		{
			return CellMap.ContainsKey(BuildCellKey(P_0, P_1));
		}

		public bool HasMergedCell(int P_0, int P_1)
		{
			return MergedCellMap.ContainsKey(BuildCellKey(P_0, P_1));
		}

		public bool TryGetCell(int P_0, int P_1, out ExcelCellData P_2)
		{
			return CellMap.TryGetValue(BuildCellKey(P_0, P_1), out P_2);
		}

		public bool TryGetMergedCell(int P_0, int P_1, out ExcelCellData P_2)
		{
			return MergedCellMap.TryGetValue(BuildCellKey(P_0, P_1), out P_2);
		}

		public IEnumerable<int> GetColumnIndicesInRow(int P_0)
		{
			_G_c__DisplayClass49_0 CS_8_locals_2 = new _G_c__DisplayClass49_0();
			CS_8_locals_2.value = P_0;
			return from cell in Cells
				where cell.RowIndex == CS_8_locals_2.value
				select cell.ColumnIndex into column
				orderby column
				select column;
		}

		public IEnumerable<ExcelCellData> GetHeaderCells()
		{
			if (HeaderRowCount <= 0)
			{
				return Enumerable.Empty<ExcelCellData>();
			}
			return from cell in Cells
				where cell.RowIndex <= HeaderRowCount
				orderby cell.RowIndex, cell.ColumnIndex
				select cell;
		}

		public void RebuildMerges()
		{
			Merges.Clear();
			foreach (ExcelCellData cell in Cells)
			{
				if (cell.RowSpan > 1 || cell.ColumnSpan > 1)
				{
					Merges.Add(new ExcelMergeInfo(cell.RowIndex, cell.ColumnIndex, cell.RowIndex + cell.RowSpan - 1, cell.ColumnIndex + cell.ColumnSpan - 1));
				}
			}
		}

		public ExcelTableStructure()
		{
			SseStreamInitializer.InitializeRuntime();
			_sourceKind1 = new List<XElement>();
			_sourceKind3 = new List<ExcelCellData>();
			JZgVibIBcPj = new List<ExcelMergeInfo>();
			CellMap = new Dictionary<string, ExcelCellData>(StringComparer.Ordinal);
			MergedCellMap = new Dictionary<string, ExcelCellData>(StringComparer.Ordinal);
		}

		[CompilerGenerated]
		private bool IsHeaderCell(ExcelCellData P_0)
		{
			return P_0.RowIndex <= HeaderRowCount;
		}
	}

	private sealed class ExcelCellData
	{
		[CompilerGenerated]
		private int _rowIndex;

		[CompilerGenerated]
		private int MJbVisMwVaF;

		[CompilerGenerated]
		private int _rowSpan;

		[CompilerGenerated]
		private int hkBViNrybhR;

		[CompilerGenerated]
		private string eUPVimIvHha;

		[CompilerGenerated]
		private XElement NCZViowOewq;

		public int RowIndex
		{
			[CompilerGenerated]
			get
			{
				return _rowIndex;
			}
			[CompilerGenerated]
			set
			{
				_rowIndex = value;
			}
		}

		public int ColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return MJbVisMwVaF;
			}
			[CompilerGenerated]
			set
			{
				MJbVisMwVaF = value;
			}
		}

		public int RowSpan
		{
			[CompilerGenerated]
			get
			{
				return _rowSpan;
			}
			[CompilerGenerated]
			set
			{
				_rowSpan = value;
			}
		}

		public int ColumnSpan
		{
			[CompilerGenerated]
			get
			{
				return hkBViNrybhR;
			}
			[CompilerGenerated]
			set
			{
				hkBViNrybhR = value;
			}
		}

		public string Text
		{
			[CompilerGenerated]
			get
			{
				return eUPVimIvHha;
			}
			[CompilerGenerated]
			set
			{
				eUPVimIvHha = value;
			}
		}

		public XElement Element
		{
			[CompilerGenerated]
			get
			{
				return NCZViowOewq;
			}
			[CompilerGenerated]
			set
			{
				NCZViowOewq = value;
			}
		}

		public ExcelCellData()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class ExcelMergeInfo
	{
		[CompilerGenerated]
		private readonly int UAyViCmEheo;

		[CompilerGenerated]
		private readonly int _startRow;

		[CompilerGenerated]
		private readonly int cAYViOZiELi;

		[CompilerGenerated]
		private readonly int olIVinoHIen;

		public int StartRow
		{
			[CompilerGenerated]
			get
			{
				return UAyViCmEheo;
			}
		}

		public int StartColumn
		{
			[CompilerGenerated]
			get
			{
				return _startRow;
			}
		}

		public int EndRow
		{
			[CompilerGenerated]
			get
			{
				return cAYViOZiELi;
			}
		}

		public int EndColumn
		{
			[CompilerGenerated]
			get
			{
				return olIVinoHIen;
			}
		}

		public ExcelMergeInfo(int P_0, int P_1, int P_2, int P_3)
		{
			SseStreamInitializer.InitializeRuntime();
			UAyViCmEheo = P_0;
			_startRow = P_1;
			cAYViOZiELi = P_2;
			olIVinoHIen = P_3;
		}
	}

	private sealed class GridDimensionInfo
	{
		[CompilerGenerated]
		private int _rowCount;

		[CompilerGenerated]
		private int _columnCount;

		[CompilerGenerated]
		private readonly HashSet<string> _rowCount;

		public int RowCount
		{
			[CompilerGenerated]
			get
			{
				return _rowCount;
			}
			[CompilerGenerated]
			set
			{
				_rowCount = value;
			}
		}

		public int ColumnCount
		{
			[CompilerGenerated]
			get
			{
				return _columnCount;
			}
			[CompilerGenerated]
			set
			{
				_columnCount = value;
			}
		}

		public HashSet<string> Cells
		{
			[CompilerGenerated]
			get
			{
				return _rowCount;
			}
		}

		public GridDimensionInfo()
		{
			SseStreamInitializer.InitializeRuntime();
			_rowCount = new HashSet<string>(StringComparer.Ordinal);
		}
	}

	private sealed class CellRange
	{
		[CompilerGenerated]
		private int _startRow;

		[CompilerGenerated]
		private int _startColumn;

		[CompilerGenerated]
		private int gqkVihEgUho;

		[CompilerGenerated]
		private int _endColumn;

		public int StartRow
		{
			[CompilerGenerated]
			get
			{
				return _startRow;
			}
			[CompilerGenerated]
			set
			{
				_startRow = value;
			}
		}

		public int StartColumn
		{
			[CompilerGenerated]
			get
			{
				return _startColumn;
			}
			[CompilerGenerated]
			set
			{
				_startColumn = value;
			}
		}

		public int EndRow
		{
			[CompilerGenerated]
			get
			{
				return gqkVihEgUho;
			}
			[CompilerGenerated]
			set
			{
				gqkVihEgUho = value;
			}
		}

		public int EndColumn
		{
			[CompilerGenerated]
			get
			{
				return _endColumn;
			}
			[CompilerGenerated]
			set
			{
				_endColumn = value;
			}
		}

		public CellRange()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class TableXmlProperties
	{
		[CompilerGenerated]
		private XElement _tableProperties;

		[CompilerGenerated]
		private readonly List<int> _tableProperties;

		[CompilerGenerated]
		private readonly List<int> fljVivYZvof;

		[CompilerGenerated]
		private int _tableWidthDxa;

		[CompilerGenerated]
		private readonly Dictionary<int, XElement> dict7;

		[CompilerGenerated]
		private readonly Dictionary<string, CellXmlProperties> FXfVikHogIW;

		[CompilerGenerated]
		private CellXmlProperties _defaultCell;

		public XElement TableProperties
		{
			[CompilerGenerated]
			get
			{
				return _tableProperties;
			}
			[CompilerGenerated]
			set
			{
				_tableProperties = value;
			}
		}

		public List<int> GridWidths
		{
			[CompilerGenerated]
			get
			{
				return _tableProperties;
			}
		}

		public List<int> RebuildGridWidths
		{
			[CompilerGenerated]
			get
			{
				return fljVivYZvof;
			}
		}

		public int TableWidthDxa
		{
			[CompilerGenerated]
			get
			{
				return _tableWidthDxa;
			}
			[CompilerGenerated]
			set
			{
				_tableWidthDxa = value;
			}
		}

		public Dictionary<int, XElement> RowProperties
		{
			[CompilerGenerated]
			get
			{
				return dict7;
			}
		}

		public Dictionary<string, CellXmlProperties> Cells
		{
			[CompilerGenerated]
			get
			{
				return FXfVikHogIW;
			}
		}

		public CellXmlProperties DefaultCell
		{
			[CompilerGenerated]
			get
			{
				return _defaultCell;
			}
			[CompilerGenerated]
			set
			{
				_defaultCell = value;
			}
		}

		public TableXmlProperties()
		{
			SseStreamInitializer.InitializeRuntime();
			_tableProperties = new List<int>();
			fljVivYZvof = new List<int>();
			dict7 = new Dictionary<int, XElement>();
			FXfVikHogIW = new Dictionary<string, CellXmlProperties>(StringComparer.Ordinal);
		}
	}

	private sealed class CellXmlProperties
	{
		[CompilerGenerated]
		private XElement _tableCellProperties;

		[CompilerGenerated]
		private XElement _paragraphProperties;

		[CompilerGenerated]
		private XElement _runProperties;

		public XElement TableCellProperties
		{
			[CompilerGenerated]
			get
			{
				return _tableCellProperties;
			}
			[CompilerGenerated]
			set
			{
				_tableCellProperties = value;
			}
		}

		public XElement ParagraphProperties
		{
			[CompilerGenerated]
			get
			{
				return _paragraphProperties;
			}
			[CompilerGenerated]
			set
			{
				_paragraphProperties = value;
			}
		}

		public XElement RunProperties
		{
			[CompilerGenerated]
			get
			{
				return _runProperties;
			}
			[CompilerGenerated]
			set
			{
				_runProperties = value;
			}
		}

		public CellXmlProperties()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class TableRebuildResult
	{
		[CompilerGenerated]
		private bool _success;

		[CompilerGenerated]
		private Table _table;

		[CompilerGenerated]
		private string mmbVHumRpCj;

		public bool Success
		{
			[CompilerGenerated]
			get
			{
				return _success;
			}
			[CompilerGenerated]
			set
			{
				_success = value;
			}
		}

		public Table Table
		{
			[CompilerGenerated]
			get
			{
				return _table;
			}
			[CompilerGenerated]
			set
			{
				_table = value;
			}
		}

		public string Error
		{
			[CompilerGenerated]
			get
			{
				return mmbVHumRpCj;
			}
			[CompilerGenerated]
			set
			{
				mmbVHumRpCj = value;
			}
		}

		public TableRebuildResult()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private enum ExecutorKind
	{

	}

	private sealed class WritePlan
	{
		[CompilerGenerated]
		private ExecutorKind _executorKind;

		[CompilerGenerated]
		private int _targetRows;

		[CompilerGenerated]
		private int _targetColumns;

		[CompilerGenerated]
		private bool _rowShapeChanged;

		[CompilerGenerated]
		private bool _columnShapeChanged;

		public ExecutorKind ExecutorKind
		{
			[CompilerGenerated]
			get
			{
				return _executorKind;
			}
			[CompilerGenerated]
			set
			{
				_executorKind = value;
			}
		}

		public int TargetRows
		{
			[CompilerGenerated]
			get
			{
				return _targetRows;
			}
			[CompilerGenerated]
			set
			{
				_targetRows = value;
			}
		}

		public int TargetColumns
		{
			[CompilerGenerated]
			get
			{
				return _targetColumns;
			}
			[CompilerGenerated]
			set
			{
				_targetColumns = value;
			}
		}

		public bool RowShapeChanged
		{
			[CompilerGenerated]
			get
			{
				return _rowShapeChanged;
			}
			[CompilerGenerated]
			set
			{
				_rowShapeChanged = value;
			}
		}

		public bool ColumnShapeChanged
		{
			[CompilerGenerated]
			get
			{
				return _columnShapeChanged;
			}
			[CompilerGenerated]
			set
			{
				_columnShapeChanged = value;
			}
		}

		public bool RequiresStructureRebuild
		{
			get
			{
				if (ExecutorKind != (ExecutorKind)2)
				{
					return ExecutorKind == (ExecutorKind)3;
				}
				return true;
			}
		}

		public bool UsesComplexComCellPlan => ExecutorKind == (ExecutorKind)1;

		public string ExecutorName => ExecutorKind switch
		{
			(ExecutorKind)0 => "普通表 COM", 
			(ExecutorKind)1 => "复杂表 COM 写值", 
			(ExecutorKind)2 => "复杂表 COM 重建", 
			(ExecutorKind)3 => "复杂表 XML 重建", 
			_ => Convert.ToString(ExecutorKind), 
		};

		public WritePlan()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class SortKeyItem
	{
		[CompilerGenerated]
		private int _rowIndex;

		[CompilerGenerated]
		private int _originalOrder;

		[CompilerGenerated]
		private string PmhVHJtPoXM;

		[CompilerGenerated]
		private bool _pinLast;

		public int RowIndex
		{
			[CompilerGenerated]
			get
			{
				return _rowIndex;
			}
			[CompilerGenerated]
			set
			{
				_rowIndex = value;
			}
		}

		public int OriginalOrder
		{
			[CompilerGenerated]
			get
			{
				return _originalOrder;
			}
			[CompilerGenerated]
			set
			{
				_originalOrder = value;
			}
		}

		public string Key
		{
			[CompilerGenerated]
			get
			{
				return PmhVHJtPoXM;
			}
			[CompilerGenerated]
			set
			{
				PmhVHJtPoXM = value;
			}
		}

		public bool PinLast
		{
			[CompilerGenerated]
			get
			{
				return _pinLast;
			}
			[CompilerGenerated]
			set
			{
				_pinLast = value;
			}
		}

		public SortKeyItem()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class TableBindingPair
	{
		[CompilerGenerated]
		private int _tableIndex;

		[CompilerGenerated]
		private Table _table;

		[CompilerGenerated]
		private TableBinding _binding;

		public int TableIndex
		{
			[CompilerGenerated]
			get
			{
				return _tableIndex;
			}
			[CompilerGenerated]
			set
			{
				_tableIndex = value;
			}
		}

		public Table Table
		{
			[CompilerGenerated]
			get
			{
				return _table;
			}
			[CompilerGenerated]
			set
			{
				_table = value;
			}
		}

		public TableBinding Binding
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

		public TableBindingPair()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private enum StructureValidationKind
	{

	}

	private sealed class FastStructureCache
	{
		[CompilerGenerated]
		private readonly Dictionary<int, ExcelTableStructure> dict6;

		[CompilerGenerated]
		private TableStructureSnapshot _snapshot;

		[CompilerGenerated]
		private bool _snapshotAttempted;

		[CompilerGenerated]
		private string _snapshotError;

		public Dictionary<int, ExcelTableStructure> FastStructuresByTableIndex
		{
			[CompilerGenerated]
			get
			{
				return dict6;
			}
		}

		public TableStructureSnapshot Snapshot
		{
			[CompilerGenerated]
			get
			{
				return _snapshot;
			}
			[CompilerGenerated]
			set
			{
				_snapshot = value;
			}
		}

		public bool SnapshotAttempted
		{
			[CompilerGenerated]
			get
			{
				return _snapshotAttempted;
			}
			[CompilerGenerated]
			set
			{
				_snapshotAttempted = value;
			}
		}

		public string SnapshotError
		{
			[CompilerGenerated]
			get
			{
				return _snapshotError;
			}
			[CompilerGenerated]
			set
			{
				_snapshotError = value;
			}
		}

		public FastStructureCache()
		{
			SseStreamInitializer.InitializeRuntime();
			dict6 = new Dictionary<int, ExcelTableStructure>();
		}
	}

	private sealed class TableStructureSnapshot
	{
		[CompilerGenerated]
		private readonly Dictionary<int, ExcelTableStructure> dict4;

		public Dictionary<int, ExcelTableStructure> StructuresByTableIndex
		{
			[CompilerGenerated]
			get
			{
				return dict4;
			}
		}

		public TableStructureSnapshot()
		{
			SseStreamInitializer.InitializeRuntime();
			dict4 = new Dictionary<int, ExcelTableStructure>();
		}
	}

	private sealed class ComCellPlan
	{
		[CompilerGenerated]
		private int _rowIndex;

		[CompilerGenerated]
		private int PutVHLsUnYp;

		[CompilerGenerated]
		private int _wordColumnIndex;

		[CompilerGenerated]
		private int _rowSpan;

		[CompilerGenerated]
		private int _columnSpan;

		[CompilerGenerated]
		private string _text;

		[CompilerGenerated]
		private bool _isMergeStart;

		public int RowIndex
		{
			[CompilerGenerated]
			get
			{
				return _rowIndex;
			}
			[CompilerGenerated]
			set
			{
				_rowIndex = value;
			}
		}

		public int ColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return PutVHLsUnYp;
			}
			[CompilerGenerated]
			set
			{
				PutVHLsUnYp = value;
			}
		}

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

		public int RowSpan
		{
			[CompilerGenerated]
			get
			{
				return _rowSpan;
			}
			[CompilerGenerated]
			set
			{
				_rowSpan = value;
			}
		}

		public int ColumnSpan
		{
			[CompilerGenerated]
			get
			{
				return _columnSpan;
			}
			[CompilerGenerated]
			set
			{
				_columnSpan = value;
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

		public bool IsMergeStart
		{
			[CompilerGenerated]
			get
			{
				return _isMergeStart;
			}
			[CompilerGenerated]
			set
			{
				_isMergeStart = value;
			}
		}

		public ComCellPlan()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class RowColumnSpan
	{
		[CompilerGenerated]
		private int _rowIndex;

		[CompilerGenerated]
		private int _startColumn;

		[CompilerGenerated]
		private int _columnSpan;

		public int RowIndex
		{
			[CompilerGenerated]
			get
			{
				return _rowIndex;
			}
			[CompilerGenerated]
			set
			{
				_rowIndex = value;
			}
		}

		public int StartColumn
		{
			[CompilerGenerated]
			get
			{
				return _startColumn;
			}
			[CompilerGenerated]
			set
			{
				_startColumn = value;
			}
		}

		public int ColumnSpan
		{
			[CompilerGenerated]
			get
			{
				return _columnSpan;
			}
			[CompilerGenerated]
			set
			{
				_columnSpan = value;
			}
		}

		public RowColumnSpan()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class TableStyleInfo
	{
		[CompilerGenerated]
		private readonly Dictionary<int, float> dict3;

		[CompilerGenerated]
		private readonly Dictionary<int, float> dict5;

		[CompilerGenerated]
		private readonly Dictionary<string, CellFormat> dict2;

		[CompilerGenerated]
		private CellFormat _defaultCell;

		[CompilerGenerated]
		private int kUDVHyejWGr;

		public Dictionary<int, float> ColumnWidths
		{
			[CompilerGenerated]
			get
			{
				return dict3;
			}
		}

		public Dictionary<int, float> RowHeights
		{
			[CompilerGenerated]
			get
			{
				return dict5;
			}
		}

		public Dictionary<string, CellFormat> Cells
		{
			[CompilerGenerated]
			get
			{
				return dict2;
			}
		}

		public CellFormat DefaultCell
		{
			[CompilerGenerated]
			get
			{
				return _defaultCell;
			}
			[CompilerGenerated]
			set
			{
				_defaultCell = value;
			}
		}

		public int SummaryFooterRow
		{
			[CompilerGenerated]
			get
			{
				return kUDVHyejWGr;
			}
			[CompilerGenerated]
			set
			{
				kUDVHyejWGr = value;
			}
		}

		public TableStyleInfo()
		{
			SseStreamInitializer.InitializeRuntime();
			dict3 = new Dictionary<int, float>();
			dict5 = new Dictionary<int, float>();
			dict2 = new Dictionary<string, CellFormat>(StringComparer.Ordinal);
		}
	}

	private sealed class CellFormat
	{
		[CompilerGenerated]
		private int? eqKVHFBSCPS;

		[CompilerGenerated]
		private int? dWUVHhqVEgX;

		[CompilerGenerated]
		private int? _underline;

		[CompilerGenerated]
		private int? _paragraphAlignment;

		[CompilerGenerated]
		private float? NRJVHPMLCid;

		[CompilerGenerated]
		private float? _firstLineIndent;

		[CompilerGenerated]
		private int? _outlineLevel;

		public int? Bold
		{
			[CompilerGenerated]
			get
			{
				return eqKVHFBSCPS;
			}
			[CompilerGenerated]
			set
			{
				eqKVHFBSCPS = value;
			}
		}

		public int? Italic
		{
			[CompilerGenerated]
			get
			{
				return dWUVHhqVEgX;
			}
			[CompilerGenerated]
			set
			{
				dWUVHhqVEgX = value;
			}
		}

		public int? Underline
		{
			[CompilerGenerated]
			get
			{
				return _underline;
			}
			[CompilerGenerated]
			set
			{
				_underline = value;
			}
		}

		public int? ParagraphAlignment
		{
			[CompilerGenerated]
			get
			{
				return _paragraphAlignment;
			}
			[CompilerGenerated]
			set
			{
				_paragraphAlignment = value;
			}
		}

		public float? LeftIndent
		{
			[CompilerGenerated]
			get
			{
				return NRJVHPMLCid;
			}
			[CompilerGenerated]
			set
			{
				NRJVHPMLCid = value;
			}
		}

		public float? FirstLineIndent
		{
			[CompilerGenerated]
			get
			{
				return _firstLineIndent;
			}
			[CompilerGenerated]
			set
			{
				_firstLineIndent = value;
			}
		}

		public int? VerticalAlignment
		{
			[CompilerGenerated]
			get
			{
				return _outlineLevel;
			}
			[CompilerGenerated]
			set
			{
				_outlineLevel = value;
			}
		}

		public CellFormat()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class SyncPlanContext
	{
		[CompilerGenerated]
		private int _tableIndex;

		[CompilerGenerated]
		private TableBinding _binding;

		[CompilerGenerated]
		private ExcelTableStructure _wordStructure;

		[CompilerGenerated]
		private ExcelTableStructure _excelStructure;

		[CompilerGenerated]
		private string[,] wyXVHzhjMsu;

		[CompilerGenerated]
		private WritePlan _plan;

		[CompilerGenerated]
		private string _sortSkippedReason;

		public int TableIndex
		{
			[CompilerGenerated]
			get
			{
				return _tableIndex;
			}
			[CompilerGenerated]
			set
			{
				_tableIndex = value;
			}
		}

		public TableBinding Binding
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

		public ExcelTableStructure WordStructure
		{
			[CompilerGenerated]
			get
			{
				return _wordStructure;
			}
			[CompilerGenerated]
			set
			{
				_wordStructure = value;
			}
		}

		public ExcelTableStructure ExcelStructure
		{
			[CompilerGenerated]
			get
			{
				return _excelStructure;
			}
			[CompilerGenerated]
			set
			{
				_excelStructure = value;
			}
		}

		public string[,] Values
		{
			[CompilerGenerated]
			get
			{
				return wyXVHzhjMsu;
			}
			[CompilerGenerated]
			set
			{
				wyXVHzhjMsu = value;
			}
		}

		public WritePlan Plan
		{
			[CompilerGenerated]
			get
			{
				return _plan;
			}
			[CompilerGenerated]
			set
			{
				_plan = value;
			}
		}

		public string SortSkippedReason
		{
			[CompilerGenerated]
			get
			{
				return _sortSkippedReason;
			}
			[CompilerGenerated]
			set
			{
				_sortSkippedReason = value;
			}
		}

		public SyncPlanContext()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class XmlRebuildResult
	{
		[CompilerGenerated]
		private int _tableIndex;

		[CompilerGenerated]
		private TableBinding _binding;

		[CompilerGenerated]
		private XElement BwmVQujbpSY;

		[CompilerGenerated]
		private bool _structureRebuilt;

		public int TableIndex
		{
			[CompilerGenerated]
			get
			{
				return _tableIndex;
			}
			[CompilerGenerated]
			set
			{
				_tableIndex = value;
			}
		}

		public TableBinding Binding
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

		public XElement TableXml
		{
			[CompilerGenerated]
			get
			{
				return BwmVQujbpSY;
			}
			[CompilerGenerated]
			set
			{
				BwmVQujbpSY = value;
			}
		}

		public bool StructureRebuilt
		{
			[CompilerGenerated]
			get
			{
				return _structureRebuilt;
			}
			[CompilerGenerated]
			set
			{
				_structureRebuilt = value;
			}
		}

		public XmlRebuildResult()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class DocumentReopenResult
	{
		[CompilerGenerated]
		private bool _success;

		[CompilerGenerated]
		private string _error;

		[CompilerGenerated]
		private string _backupPath;

		[CompilerGenerated]
		private Document UuIVQivYFAa;

		public bool Success
		{
			[CompilerGenerated]
			get
			{
				return _success;
			}
			[CompilerGenerated]
			set
			{
				_success = value;
			}
		}

		public string Error
		{
			[CompilerGenerated]
			get
			{
				return _error;
			}
			[CompilerGenerated]
			set
			{
				_error = value;
			}
		}

		public string BackupPath
		{
			[CompilerGenerated]
			get
			{
				return _backupPath;
			}
			[CompilerGenerated]
			set
			{
				_backupPath = value;
			}
		}

		public Document ReopenedDocument
		{
			[CompilerGenerated]
			get
			{
				return UuIVQivYFAa;
			}
			[CompilerGenerated]
			set
			{
				UuIVQivYFAa = value;
			}
		}

		public DocumentReopenResult()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class MergedCellInfo
	{
		[CompilerGenerated]
		private int FiGVQQgQDav;

		[CompilerGenerated]
		private int _columnIndex;

		[CompilerGenerated]
		private int _columnSpan;

		[CompilerGenerated]
		private XElement _rowIndex;

		[CompilerGenerated]
		private string _text;

		public int RowIndex
		{
			[CompilerGenerated]
			get
			{
				return FiGVQQgQDav;
			}
			[CompilerGenerated]
			set
			{
				FiGVQQgQDav = value;
			}
		}

		public int ColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return _columnIndex;
			}
			[CompilerGenerated]
			set
			{
				_columnIndex = value;
			}
		}

		public int ColumnSpan
		{
			[CompilerGenerated]
			get
			{
				return _columnSpan;
			}
			[CompilerGenerated]
			set
			{
				_columnSpan = value;
			}
		}

		public XElement CellElement
		{
			[CompilerGenerated]
			get
			{
				return _rowIndex;
			}
			[CompilerGenerated]
			set
			{
				_rowIndex = value;
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

		public MergedCellInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class ComplexCellPlan
	{
		[CompilerGenerated]
		private int _sequence;

		[CompilerGenerated]
		private int _rowIndex;

		[CompilerGenerated]
		private int _columnIndex;

		[CompilerGenerated]
		private int _wordColumnIndex;

		[CompilerGenerated]
		private int _mergeStartRowIndex;

		[CompilerGenerated]
		private int _mergeStartWordColumnIndex;

		[CompilerGenerated]
		private int OvWVQZCOGFm;

		[CompilerGenerated]
		private int _columnSpan;

		[CompilerGenerated]
		private string _text;

		[CompilerGenerated]
		private bool QfRVQbOupEV;

		[CompilerGenerated]
		private bool _isVerticalContinuation;

		[CompilerGenerated]
		private bool _xmlShowCell;

		public int Sequence
		{
			[CompilerGenerated]
			get
			{
				return _sequence;
			}
			[CompilerGenerated]
			set
			{
				_sequence = value;
			}
		}

		public int RowIndex
		{
			[CompilerGenerated]
			get
			{
				return _rowIndex;
			}
			[CompilerGenerated]
			set
			{
				_rowIndex = value;
			}
		}

		public int ColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return _columnIndex;
			}
			[CompilerGenerated]
			set
			{
				_columnIndex = value;
			}
		}

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

		public int MergeStartRowIndex
		{
			[CompilerGenerated]
			get
			{
				return _mergeStartRowIndex;
			}
			[CompilerGenerated]
			set
			{
				_mergeStartRowIndex = value;
			}
		}

		public int MergeStartWordColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return _mergeStartWordColumnIndex;
			}
			[CompilerGenerated]
			set
			{
				_mergeStartWordColumnIndex = value;
			}
		}

		public int RowSpan
		{
			[CompilerGenerated]
			get
			{
				return OvWVQZCOGFm;
			}
			[CompilerGenerated]
			set
			{
				OvWVQZCOGFm = value;
			}
		}

		public int ColumnSpan
		{
			[CompilerGenerated]
			get
			{
				return _columnSpan;
			}
			[CompilerGenerated]
			set
			{
				_columnSpan = value;
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

		public bool IsMergeStart
		{
			[CompilerGenerated]
			get
			{
				return QfRVQbOupEV;
			}
			[CompilerGenerated]
			set
			{
				QfRVQbOupEV = value;
			}
		}

		public bool IsVerticalContinuation
		{
			[CompilerGenerated]
			get
			{
				return _isVerticalContinuation;
			}
			[CompilerGenerated]
			set
			{
				_isVerticalContinuation = value;
			}
		}

		public bool XmlShowCell
		{
			[CompilerGenerated]
			get
			{
				return _xmlShowCell;
			}
			[CompilerGenerated]
			set
			{
				_xmlShowCell = value;
			}
		}

		public ComplexCellPlan()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass115_0
	{
		public int value;

		public int value;

		public _G_c__DisplayClass115_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsColumnBeyond3(WordTableStructure table)
		{
			if (value <= table.End)
			{
				return value >= table.Start;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass164_0
	{
		public string tJcVJbRSSXT;

		public _G_c__DisplayClass164_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsColumnBeyond2(XElement element)
		{
			return string.Equals((string)element.Attribute(XmlPackageNamespace + "name"), tJcVJbRSSXT, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass168_0
	{
		public int value;

		public _G_c__DisplayClass168_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsColumnGreaterThan(int column)
		{
			return column > value;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_0
	{
		public int value;

		public int value;

		public _G_c__DisplayClass16_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsTableInRange2(WordTableInfo table)
		{
			if (value <= table.End)
			{
				return value >= table.Start;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass171_0
	{
		public int AxRVJNkeKZE;

		public _G_c__DisplayClass171_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool xPFVJlpXRIs(ExcelMergeInfo merge)
		{
			if (merge.StartRow <= AxRVJNkeKZE)
			{
				return merge.EndRow >= AxRVJNkeKZE;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass172_0
	{
		public int RcXVJoFgptR;

		public _G_c__DisplayClass172_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsMergeInRange2(CellMergeInfo merge)
		{
			if (merge.StartRow <= RcXVJoFgptR)
			{
				return merge.EndRow >= RcXVJoFgptR;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass202_0
	{
		public bool flag;

		public _G_c__DisplayClass202_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void pWOVJGjVNsH(AiHelper_12 config)
		{
			config.EnsureConfigLoaded();
			config.ExcelSync.SyncHeaders = flag;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass212_0
	{
		public int value;

		public _G_c__DisplayClass212_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsMergeAfterRow(ExcelMergeInfo merge)
		{
			return merge.EndRow > value;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass217_0
	{
		public bool flag;

		public _G_c__DisplayClass217_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetValue3(SortKeyItem left, SortKeyItem right)
		{
			int num = CompareWithPinnedLast(left.Key, right.Key, flag);
			if (num != 0)
			{
				return num;
			}
			return left.OriginalOrder.CompareTo(right.OriginalOrder);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass243_0
	{
		public string text;

		public _G_c__DisplayClass243_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool ContainsText2(TableBinding item)
		{
			if (item != null)
			{
				return string.Equals(item.Id, text, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass367_0
	{
		public string text;

		public Func<XElement, bool> actionFunc3;

		public _G_c__DisplayClass367_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool ContainsText3(XElement element)
		{
			return string.Equals(GetAttributeValue(element, "name"), text, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass369_0
	{
		public string text;

		public HashSet<string> cellIds;

		public Func<XElement, bool> actionFunc7;

		public _G_c__DisplayClass369_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool ContainsText1(XElement element)
		{
			return string.Equals(GetAttributeValue(element, "name"), text, StringComparison.OrdinalIgnoreCase);
		}

		internal bool zdZVJhFqNCn(XElement element)
		{
			return cellIds.Contains(GetAttributeValue(element, "id"));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass385_0
	{
		public int value;

		public Func<ComplexCellPlan, bool> actionFunc4;

		public _G_c__DisplayClass385_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool GetName11(ComplexCellPlan cell)
		{
			if (cell.RowIndex == value)
			{
				return cell.XmlShowCell;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass420_0
	{
		public HashSet<string> elementNames;

		public _G_c__DisplayClass420_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool GetName10(XElement element)
		{
			return elementNames.Contains(element.Name.LocalName);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass453_0
	{
		public int MC7V3RVTZCT;

		public int value;

		public Func<ExcelCellData, bool> actionFunc6;

		public Func<ExcelCellData, bool> actionFunc8;

		public Func<ExcelCellData, bool> actionFunc5;

		public _G_c__DisplayClass453_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsCellInColumn(ExcelCellData item)
		{
			if (item.ColumnIndex == MC7V3RVTZCT && item.ColumnSpan == 1)
			{
				return item.RowIndex > value;
			}
			return false;
		}

		internal bool vPhVJdBEEqu(ExcelCellData item)
		{
			if (item.ColumnIndex == MC7V3RVTZCT)
			{
				return item.ColumnSpan == 1;
			}
			return false;
		}

		internal bool GetText10(ExcelCellData item)
		{
			if (item.ColumnIndex <= MC7V3RVTZCT)
			{
				return MC7V3RVTZCT < item.ColumnIndex + Math.Max(1, item.ColumnSpan);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass90_0
	{
		public HeadingInfo headingInfo;

		public string text;

		public _G_c__DisplayClass90_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool GetText11(HeadingInfo item)
		{
			if (item.Level == headingInfo.Level)
			{
				return string.Equals(CleanTitleText(item.Text), text, StringComparison.Ordinal);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private static class _G_o__253
	{
		public static CallSite<Func<CallSite, object, string, object>> toStringCallSite_Tc9;

		public static CallSite<Func<CallSite, object, string, object>> toStringCallSite_Tc18;

		public static CallSite<Action<CallSite, object, string, string>> addCallSite;
	}

	[CompilerGenerated]
	private static class _G_o__265
	{
		public static CallSite<Func<CallSite, object, string, object>> toStringCallSite_Tc12;

		public static CallSite<Action<CallSite, object>> deleteCallSite_Tc3;
	}

	[CompilerGenerated]
	private static class _G_o__284
	{
		public static CallSite<Func<CallSite, object, object>> toObjectCallSite_Tc18;

		public static CallSite<Func<CallSite, Type, object, object>> toBooleanCallSite_Tc2;

		public static CallSite<Func<CallSite, object, bool>> toObjectCallSite_Tc19;
	}

	[CompilerGenerated]
	private static class _G_o__305
	{
		public static CallSite<Action<CallSite, object, int>> insertRowsBelowCallSite_Tc1;
	}

	[CompilerGenerated]
	private static class _G_o__306
	{
		public static CallSite<Func<CallSite, object, object>> toObjectCallSite_Tc15;

		public static CallSite<Action<CallSite, object>> deleteCallSite_Tc5;
	}

	[CompilerGenerated]
	private static class _G_o__307
	{
		public static CallSite<Action<CallSite, object>> insertColumnsRightCallSite_Tc2;
	}

	[CompilerGenerated]
	private static class _G_o__308
	{
		public static CallSite<Func<CallSite, object, object>> toObjectCallSite_Tc23;

		public static CallSite<Action<CallSite, object, WdDeleteCells>> deleteCallSite_Tc2;
	}

	[CompilerGenerated]
	private static class _G_o__35
	{
		public static CallSite<Func<CallSite, object, object>> toObjectCallSite_Tc16;

		public static CallSite<Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object>> addressCallSite;

		public static CallSite<Func<CallSite, Type, object, object>> toStringCallSite_Tc19;

		public static CallSite<Func<CallSite, object, string>> toStringCallSite_Tc15;
	}

	[CompilerGenerated]
	private static class _G_o__36
	{
		public static CallSite<Func<CallSite, object, object>> toObjectCallSite_Tc24;

		public static CallSite<Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object>> toObjectCallSite_Tc14;

		public static CallSite<Func<CallSite, Type, object, object>> toStringCallSite_Tc10;

		public static CallSite<Func<CallSite, object, string>> toStringCallSite_Tc14;
	}

	[CompilerGenerated]
	private static class _G_o__445
	{
		public static CallSite<Func<CallSite, object, object>> toObjectCallSite_Tc22;

		public static CallSite<Action<CallSite, object, WdDeleteCells>> deleteCallSite_Tc6;

		public static CallSite<Func<CallSite, object, object>> toObjectCallSite_Tc20;

		public static CallSite<Action<CallSite, object>> deleteCallSite_Tc4;
	}

	[CompilerGenerated]
	private static class _G_o__446
	{
		public static CallSite<Action<CallSite, object, int>> insertRowsBelowCallSite_Tc2;
	}

	[CompilerGenerated]
	private static class _G_o__450
	{
		public static CallSite<Action<CallSite, object>> insertColumnsRightCallSite_Tc1;
	}

	[CompilerGenerated]
	private static class _G_o__451
	{
		public static CallSite<Func<CallSite, object, object>> toObjectCallSite_Tc11;

		public static CallSite<Action<CallSite, object, WdDeleteCells>> deleteCallSite_Tc1;
	}

	[CompilerGenerated]
	private static class _G_o__63
	{
		public static CallSite<Func<CallSite, object, object>> toObjectCallSite_Tc12;

		public static CallSite<Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object>> toObjectCallSite_Tc13;

		public static CallSite<Func<CallSite, Type, object, object>> toStringCallSite_Tc17;

		public static CallSite<Func<CallSite, object, string>> toStringCallSite_Tc11;
	}

	[CompilerGenerated]
	private static class _G_o__72
	{
		public static CallSite<Func<CallSite, Type, object, object>> toStringCallSite_Tc16;

		public static CallSite<Func<CallSite, object, string>> toStringCallSite_Tc13;
	}

	[CompilerGenerated]
	private static class _G_o__75
	{
		public static CallSite<Func<CallSite, Type, object, object>> toBooleanCallSite_Tc1;

		public static CallSite<Func<CallSite, object, object>> toObjectCallSite_Tc17;

		public static CallSite<Func<CallSite, bool, object, object>> toObjectCallSite_Tc10;

		public static CallSite<Func<CallSite, object, bool>> DynamicIsTruthyCallSite;
	}

	private static readonly XNamespace WordNamespace;

	private static readonly XNamespace XmlPackageNamespace;

	private static readonly XNamespace SpreadsheetNamespace;

	private static readonly XNamespace RelationshipsNamespace;

	private static Microsoft.Office.Interop.Word.Application App => WordTableToolService.WordApp;

	internal static IList<TableBindingStatus> GetAllTableBindings()
	{
		Document activeDocument = App.ActiveDocument;
		List<TableBinding> list = GetBindingsFromDocument(activeDocument);
		HashSet<string> hashSet = GetBookmarkNameSet(activeDocument);
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		List<TableBindingStatus> list2 = new List<TableBindingStatus>();
		foreach (TableBinding item in list)
		{
			if (item != null && IsValidBookmarkId(item.Id) && hashSet.Add(item.Id))
			{
				list2.Add(CreateBindingStatus(activeDocument, item, hashSet));
			}
		}
		List<TableBindingStatus> list3 = list2.OrderBy((TableBindingStatus item) => (item.WordTableIndex > 0) ? item.WordTableIndex : int.MaxValue).ThenBy((TableBindingStatus item) => item.BindingId, StringComparer.OrdinalIgnoreCase).ToList();
		int num = 1;
		foreach (TableBindingStatus item2 in list3)
		{
			item2.Index = num++;
		}
		return list3;
	}

	private static IList<TableBindingStatus> BuildBindingStatusListFromContext(Document P_0, TableBindingContext P_1)
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		List<TableBindingStatus> list = new List<TableBindingStatus>();
		foreach (TableBinding binding in P_1.Bindings)
		{
			if (binding != null && IsValidBookmarkId(binding.Id) && hashSet.Add(binding.Id))
			{
				list.Add(CreateBindingStatusFromContext(P_0, binding, P_1));
			}
		}
		List<TableBindingStatus> list2 = list.OrderBy((TableBindingStatus item) => (item.WordTableIndex > 0) ? item.WordTableIndex : int.MaxValue).ThenBy((TableBindingStatus item) => item.BindingId, StringComparer.OrdinalIgnoreCase).ToList();
		int num = 1;
		foreach (TableBindingStatus item in list2)
		{
			item.Index = num++;
		}
		return list2;
	}

	internal static SyncResult GetSyncAllTablesResult()
	{
		Document activeDocument = App.ActiveDocument;
		TableBindingContext bindingContext = LoadTableBindingContext(activeDocument);
		if (!string.IsNullOrWhiteSpace(bindingContext.LoadError))
		{
			return CreateSyncResult("刷新表格信息失败：" + bindingContext.LoadError, bindingContext.LoadError);
		}
		List<TableBinding> obj = ((bindingContext.Bindings.Count > 0) ? bindingContext.Bindings : GetBindingsFromDocument(activeDocument));
		int num = 0;
		int num2 = 0;
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		foreach (TableBinding item in obj)
		{
			if (item != null && IsValidBookmarkId(item.Id) && hashSet.Add(item.Id))
			{
				string text = GetBookmarkIdFromBinding(item);
				bool flag;
				WordTableInfo xJSRGPVgVcylOerTScS = FindTableByBookmark(bindingContext, text, out flag);
				if (xJSRGPVgVcylOerTScS == null || !flag)
				{
					num2++;
					continue;
				}
				CopyTableInfoToBinding(item, xJSRGPVgVcylOerTScS);
				ClearTableBindings(activeDocument, item);
				num++;
			}
		}
		return new SyncResult
		{
			Success = true,
			Total = hashSet.Count,
			Bound = num,
			Failed = num2,
			Message = ((num2 > 0) ? string.Format("已刷新 {0} 个表格信息。", num, num2) : string.Format("已刷新 {0} 个表格信息，{1} 个绑定的表格锚点丢失。", num))
		};
	}

	internal static SyncResult SyncAllTablesInternal()
	{
		Document activeDocument = App.ActiveDocument;
		List<TableBinding> list = GetBindingsFromDocument(activeDocument);
		if (!TryGetBookmarkNameSet(activeDocument, out var hashSet))
		{
			return CreateSyncResult("无法读取当前 Word 文档的表格锚点，未清理任何绑定。");
		}
		int num = 0;
		foreach (TableBinding item in list)
		{
			if (item != null && IsValidBookmarkId(item.Id))
			{
				string text = GetBookmarkIdFromBinding(item);
				if (string.IsNullOrWhiteSpace(text) || !hashSet.Contains(text))
				{
					RemoveBindingFromDocument(activeDocument, item);
					num++;
				}
			}
		}
		return new SyncResult
		{
			Success = true,
			Bound = num,
			Message = ((num == 0) ? "已清理 {0} 个表格锚点丢失的绑定。" : string.Format("没有需要清理的失效绑定。", num))
		};
	}

	private static HashSet<string> GetBookmarkNameSet(Document P_0)
	{
		if (!TryGetBookmarkNameSet(P_0, out var result))
		{
			return new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		}
		return result;
	}

	private static bool TryGetBookmarkNameSet(Document P_0, out HashSet<string> P_1)
	{
		P_1 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		try
		{
			for (int i = 1; i <= P_0.Bookmarks.Count; i++)
			{
				Bookmarks bookmarks = P_0.Bookmarks;
				object Index = i;
				string text = Convert.ToString(bookmarks[ref Index].Name);
				if (!string.IsNullOrWhiteSpace(text))
				{
					P_1.Add(text);
				}
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static TableBindingStatus CreateBindingStatus(Document P_0, TableBinding P_1, HashSet<string> P_2)
	{
		string text = GetBookmarkIdFromBinding(P_1);
		bool flag = !string.IsNullOrWhiteSpace(text) && P_2 != null && P_2.Contains(text);
		string status = (flag ? "表格锚点丢失" : "正常");
		string text2 = ResolveExcelPath(P_0, P_1);
		bool flag2 = !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(P_1.ExcelName);
		return new TableBindingStatus
		{
			Binding = P_1,
			BindingId = (P_1.Id ?? string.Empty),
			WordBookmark = (text ?? string.Empty),
			WordTableIndex = P_1.WordTableIndex.GetValueOrDefault(),
			WordTableLabel = GetTableLabelFromBinding(P_1),
			TableTitle = (P_1.WordTableTitle ?? string.Empty),
			DisplayTitle = FormatDisplayTitle(P_1.WordDisplayTitle, P_1.WordTableTitle, P_1.WordHeadingPath, P_1.WordTableIndex.GetValueOrDefault()),
			HeadingPath = CleanHeadingPath(P_1.WordHeadingPath),
			HeadingPathText = GetHeadingPathText(P_1.WordHeadingPath),
			ExcelFullPath = (P_1.ExcelFullPath ?? string.Empty),
			ResolvedExcelPath = text2,
			ExcelRelativePath = (P_1.ExcelRelativePath ?? string.Empty),
			WorkbookName = (P_1.WorkbookName ?? string.Empty),
			SheetName = (P_1.SheetName ?? string.Empty),
			ExcelName = (P_1.ExcelName ?? string.Empty),
			ExcelAddress = string.Empty,
			RefersToAddress = string.Empty,
			ExcelRows = 0,
			ExcelColumns = 0,
			SourceSize = string.Empty,
			SyncMode = (P_1.SyncMode ?? string.Empty),
			ErrorMessage = (flag ? string.Empty : "表格锚点丢失"),
			Status = status,
			CanJumpWord = flag,
			CanJumpExcel = flag2,
			CanSync = (flag && flag2),
			HeaderRowCount = P_1.HeaderRowCount,
			SortEnabled = P_1.SortEnabled,
			SortColumnIndex = (P_1.SortColumnIndex ?? 2),
			SortDescending = (P_1.SortDescending ?? true),
			SortPinOtherLast = HasBindingColumnMappings(P_1),
			WordColumnCount = P_1.WordTableColumns.GetValueOrDefault(),
			ColumnMappings = BuildColumnMappings(P_1, P_1.WordTableColumns.GetValueOrDefault())
		};
	}

	private static TableBindingContext LoadTableBindingContext(Document P_0)
	{
		TableBindingContext bindingContext = new TableBindingContext();
		try
		{
			string text = Convert.ToString(P_0.Content.WordOpenXML);
			if (string.IsNullOrWhiteSpace(text))
			{
				bindingContext.LoadError = SanitizeConfigKey("WordOpenXML为空");
				return bindingContext;
			}
			XDocument xDocument = XDocument.Parse(text);
			XDocument xDocument2 = CloneDocumentXml(xDocument, "/word/settings.xml");
			XDocument xDocument3 = CloneDocumentXml(xDocument, "/word/document.xml");
			XDocument xDocument4 = CloneDocumentXml(xDocument, "/word/styles.xml");
			bindingContext.Bindings.AddRange(ParseBindingsFromXml(xDocument2));
			if (xDocument3 != null)
			{
				ParseTablesFromXml(xDocument3, bindingContext, BuildStyleOutlineMap(xDocument4));
			}
			else
			{
				bindingContext.LoadError = SanitizeConfigKey("word/document.xml缺失");
			}
		}
		catch (Exception ex)
		{
			bindingContext.LoadError = SanitizeConfigKey(ex.Message);
		}
		return bindingContext;
	}

	private static List<TableBinding> GetBindingsFromDocument(Document P_0)
	{
		List<TableBinding> list = new List<TableBinding>();
		try
		{
			for (int i = 1; i <= P_0.Variables.Count; i++)
			{
				Variables variables = P_0.Variables;
				object Index = i;
				Variable variable = variables[ref Index];
				if (IsValidBookmarkId(Convert.ToString(variable.Name)))
				{
					TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingById(Convert.ToString(variable.Value));
					if (lnEK8VVIccoSQf18k7Ih2 != null)
					{
						list.Add(lnEK8VVIccoSQf18k7Ih2);
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	private static TableBindingStatus CreateBindingStatusFromContext(Document P_0, TableBinding P_1, TableBindingContext P_2)
	{
		string text = (string.IsNullOrWhiteSpace(P_1.WordBookmark) ? P_1.Id : P_1.WordBookmark);
		bool flag;
		WordTableInfo xJSRGPVgVcylOerTScS = FindTableByBookmark(P_2, text, out flag);
		string text2;
		string errorMessage;
		if (!string.IsNullOrWhiteSpace(P_2.LoadError))
		{
			bool num = IsTableInDocument(P_0, text);
			text2 = (num ? "表格锚点丢失" : "Word结构读取失败");
			errorMessage = (num ? P_2.LoadError : "表格锚点丢失");
			flag = num;
		}
		else if (string.IsNullOrWhiteSpace(text) || !flag)
		{
			text2 = "表格锚点丢失";
			errorMessage = "表格锚点丢失";
		}
		else if (xJSRGPVgVcylOerTScS == null)
		{
			text2 = "表格锚点丢失";
			errorMessage = "表格锚点丢失";
		}
		else
		{
			text2 = "正常";
			errorMessage = string.Empty;
		}
		string text3 = ResolveExcelPath(P_0, P_1);
		bool flag2 = string.Equals(text2, "正常", StringComparison.OrdinalIgnoreCase) || (string.Equals(text2, "Word结构读取失败", StringComparison.OrdinalIgnoreCase) && flag);
		bool flag3 = !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(P_1.ExcelName);
		return new TableBindingStatus
		{
			Binding = P_1,
			BindingId = (P_1.Id ?? string.Empty),
			WordBookmark = (text ?? string.Empty),
			WordTableIndex = (xJSRGPVgVcylOerTScS?.Index ?? P_1.WordTableIndex.GetValueOrDefault()),
			WordTableLabel = ((xJSRGPVgVcylOerTScS != null) ? string.Format("第 {0} 表", xJSRGPVgVcylOerTScS.Index) : GetTableLabelFromBinding(P_1)),
			TableTitle = (xJSRGPVgVcylOerTScS?.TableTitle ?? P_1.WordTableTitle ?? string.Empty),
			DisplayTitle = ((xJSRGPVgVcylOerTScS != null) ? FormatDisplayTitle(xJSRGPVgVcylOerTScS.DisplayTitle, xJSRGPVgVcylOerTScS.TableTitle, xJSRGPVgVcylOerTScS.HeadingPath, xJSRGPVgVcylOerTScS.Index) : FormatDisplayTitle(P_1.WordDisplayTitle, P_1.WordTableTitle, P_1.WordHeadingPath, P_1.WordTableIndex.GetValueOrDefault())),
			HeadingPath = ((xJSRGPVgVcylOerTScS != null) ? CleanHeadingPath(xJSRGPVgVcylOerTScS.HeadingPath) : CleanHeadingPath(P_1.WordHeadingPath)),
			HeadingPathText = ((xJSRGPVgVcylOerTScS != null) ? GetHeadingPathText(xJSRGPVgVcylOerTScS.HeadingPath) : GetHeadingPathText(P_1.WordHeadingPath)),
			ExcelFullPath = (P_1.ExcelFullPath ?? string.Empty),
			ResolvedExcelPath = text3,
			ExcelRelativePath = (P_1.ExcelRelativePath ?? string.Empty),
			WorkbookName = (P_1.WorkbookName ?? string.Empty),
			SheetName = (P_1.SheetName ?? string.Empty),
			ExcelName = (P_1.ExcelName ?? string.Empty),
			ExcelAddress = string.Empty,
			RefersToAddress = string.Empty,
			ExcelRows = 0,
			ExcelColumns = 0,
			SourceSize = string.Empty,
			SyncMode = (P_1.SyncMode ?? string.Empty),
			ErrorMessage = errorMessage,
			Status = text2,
			CanJumpWord = flag2,
			CanJumpExcel = flag3,
			CanSync = (flag2 && flag3),
			HeaderRowCount = P_1.HeaderRowCount,
			SortEnabled = P_1.SortEnabled,
			SortColumnIndex = (P_1.SortColumnIndex ?? 2),
			SortDescending = (P_1.SortDescending ?? true),
			SortPinOtherLast = HasBindingColumnMappings(P_1),
			WordColumnCount = (xJSRGPVgVcylOerTScS?.ColumnCount ?? P_1.WordTableColumns.GetValueOrDefault()),
			ColumnMappings = BuildColumnMappings(P_1, xJSRGPVgVcylOerTScS?.ColumnCount ?? P_1.WordTableColumns.GetValueOrDefault())
		};
	}

	private static void CopyTableInfoToBinding(TableBinding P_0, WordTableInfo P_1)
	{
		if (P_0 != null && P_1 != null)
		{
			P_0.WordTableIndex = ((P_1.Index > 0) ? new int?(P_1.Index) : ((int?)null));
			P_0.WordTableRows = ((P_1.RowCount > 0) ? new int?(P_1.RowCount) : ((int?)null));
			P_0.WordTableColumns = ((P_1.ColumnCount > 0) ? new int?(P_1.ColumnCount) : ((int?)null));
			P_0.WordTableTitle = P_1.TableTitle ?? string.Empty;
			P_0.WordDisplayTitle = P_1.DisplayTitle ?? string.Empty;
			P_0.WordHeadingPath = CleanHeadingPath(P_1.HeadingPath);
			P_0.WordSnapshotUpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
	}

	private static string GetTableLabelFromBinding(TableBinding P_0)
	{
		if (P_0 == null || !P_0.WordTableIndex.HasValue || P_0.WordTableIndex.Value <= 0)
		{
			return "未缓存";
		}
		return string.Format("第 {0} 表", P_0.WordTableIndex.Value);
	}

	private static IEnumerable<TableBinding> ParseBindingsFromXml(XDocument P_0)
	{
		if (P_0?.Root == null)
		{
			yield break;
		}
		foreach (XElement item in P_0.Descendants(WordNamespace + "Delete"))
		{
			if (IsValidBookmarkId(GetAttributeValue(item, "Cells")))
			{
				TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingById(GetAttributeValue(item, "Delete"));
				if (lnEK8VVIccoSQf18k7Ih2 != null)
				{
					yield return lnEK8VVIccoSQf18k7Ih2;
				}
			}
		}
	}

	private static void LoadTablesFromDocumentXml(XDocument P_0, TableBindingContext P_1)
	{
		ParseTablesFromXml(P_0, P_1, new Dictionary<string, StyleInfo>(StringComparer.OrdinalIgnoreCase));
	}

	private static void ParseTablesFromXml(XDocument P_0, TableBindingContext P_1, IDictionary<string, StyleInfo> P_2)
	{
		int num = 0;
		List<HeadingInfo> list = new List<HeadingInfo>();
		if (P_0?.Root != null)
		{
			ParseTableElement(P_0.Root, P_1, P_2, list, ref num);
		}
	}

	private static void ParseTableElement(XElement P_0, TableBindingContext P_1, IDictionary<string, StyleInfo> P_2, IList<HeadingInfo> P_3, ref int P_4)
	{
		int num = P_4++;
		WordTableInfo xJSRGPVgVcylOerTScS = null;
		if (P_0.Name == WordNamespace + "bookmarkStart")
		{
			string text = GetAttributeValue(P_0, "id");
			string text2 = GetAttributeValue(P_0, "name");
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
			{
				BookmarkInfo value = new BookmarkInfo
				{
					Name = text2,
					Start = num,
					End = num
				};
				P_1.BookmarksById[text] = value;
				P_1.BookmarksByName[text2] = value;
			}
		}
		else if (P_0.Name == WordNamespace + "bookmarkEnd")
		{
			string text3 = GetAttributeValue(P_0, "id");
			if (!string.IsNullOrWhiteSpace(text3) && P_1.BookmarksById.TryGetValue(text3, out var value2))
			{
				value2.End = num;
			}
		}
		else if (P_0.Name == WordNamespace + "tbl")
		{
			WordTableStructure hSmUUnVgKE1jrbUYMSFe2 = BuildTableStructureFromElement(P_0, P_1.Tables.Count + 1, num);
			string text4 = GetElementText(P_0);
			List<HeadingPathItem> list = P_3.Select((HeadingInfo item) => new HeadingPathItem
			{
				Text = CleanTitleText(item.Text),
				Level = item.Level
			}).ToList();
			string text5 = BuildDisplayTitleWithHeading(text4, list, P_1.Tables.Count + 1);
			xJSRGPVgVcylOerTScS = new WordTableInfo
			{
				Index = P_1.Tables.Count + 1,
				Start = num,
				RowCount = hSmUUnVgKE1jrbUYMSFe2.RowCount,
				ColumnCount = hSmUUnVgKE1jrbUYMSFe2.ColumnCount,
				TableTitle = text5,
				DisplayTitle = FormatDisplayTitle(string.Empty, text5, list, P_1.Tables.Count + 1),
				HeadingPath = list
			};
			P_1.Tables.Add(xJSRGPVgVcylOerTScS);
		}
		else if (P_0.Name == WordNamespace + "p" && IsTableStartElement(P_0))
		{
			ParseStylesFromXml(P_0, P_2, P_3);
		}
		foreach (XElement item in P_0.Elements())
		{
			ParseTableElement(item, P_1, P_2, P_3, ref P_4);
		}
		int end = P_4++;
		if (xJSRGPVgVcylOerTScS != null)
		{
			xJSRGPVgVcylOerTScS.End = end;
		}
	}

	private static WordTableInfo FindTableByBookmark(TableBindingContext P_0, string P_1, out bool P_2)
	{
		_G_c__DisplayClass16_0 CS_8_locals_4 = new _G_c__DisplayClass16_0();
		P_2 = false;
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		if (!P_0.BookmarksByName.TryGetValue(P_1, out var value))
		{
			return null;
		}
		P_2 = true;
		CS_8_locals_4.value = Math.Min(value.Start, value.End);
		CS_8_locals_4.value = Math.Max(value.Start, value.End);
		return P_0.Tables.FirstOrDefault((WordTableInfo table) => CS_8_locals_4.value <= table.End && CS_8_locals_4.value >= table.Start);
	}

	private static string ResolveExcelPath(Document P_0, TableBinding P_1)
	{
		if (!string.IsNullOrWhiteSpace(P_1.ExcelFullPath))
		{
			return P_1.ExcelFullPath;
		}
		try
		{
			string text = Convert.ToString(P_0.Path);
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(P_1.ExcelRelativePath))
			{
				return Path.GetFullPath(Path.Combine(text, P_1.ExcelRelativePath));
			}
		}
		catch
		{
		}
		return P_1.ExcelRelativePath ?? string.Empty;
	}

	private static string GetElementText(XElement P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		foreach (XElement item in P_0.ElementsBeforeSelf().Reverse())
		{
			if (item.Name == WordNamespace + "tbl")
			{
				break;
			}
			if (!(item.Name != WordNamespace + "p"))
			{
				string text = GetTableTitle(item);
				if (!string.IsNullOrWhiteSpace(text))
				{
					return text;
				}
			}
		}
		return string.Empty;
	}

	private static string BuildDisplayTitleWithHeading(string P_0, IList<HeadingPathItem> P_1, int P_2)
	{
		string text = CleanTitleText(P_0);
		string text2 = CleanTitleText(P_1?.LastOrDefault()?.Text);
		if (!string.IsNullOrWhiteSpace(text) && !string.Equals(text, text2, StringComparison.Ordinal))
		{
			return text;
		}
		if (!string.IsNullOrWhiteSpace(text2))
		{
			return text2;
		}
		if (P_2 <= 0)
		{
			return "Word 表格";
		}
		return string.Format("Word 表格 {0}", P_2);
	}

	private static string FormatDisplayTitle(string P_0, string P_1, IEnumerable<HeadingPathItem> P_2, int P_3)
	{
		string text = CleanTitleText(P_0);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		text = CleanTitleText(P_1);
		if (!string.IsNullOrWhiteSpace(text))
		{
			if (P_3 <= 0)
			{
				return text;
			}
			return string.Format("第 {0} 表：{1}", P_3, text);
		}
		text = CleanTitleText(P_2?.LastOrDefault()?.Text);
		if (!string.IsNullOrWhiteSpace(text))
		{
			if (P_3 <= 0)
			{
				return text;
			}
			return string.Format("第 {0} 表：{1}", P_3, text);
		}
		if (P_3 <= 0)
		{
			return "Word 表格";
		}
		return string.Format("第 {0} 表", P_3);
	}

	private static List<HeadingPathItem> CleanHeadingPath(IEnumerable<HeadingPathItem> P_0)
	{
		List<HeadingPathItem> list = new List<HeadingPathItem>();
		if (P_0 == null)
		{
			return list;
		}
		foreach (HeadingPathItem item in P_0)
		{
			if (item != null && !string.IsNullOrWhiteSpace(item.Text))
			{
				list.Add(new HeadingPathItem
				{
					Text = CleanTitleText(item.Text),
					Level = Math.Max(1, Math.Min(9, item.Level))
				});
			}
		}
		return list;
	}

	private static string GetHeadingPathText(IEnumerable<HeadingPathItem> P_0)
	{
		List<string> list = (from item in CleanHeadingPath(P_0)
			select item.Text into text
			where !string.IsNullOrWhiteSpace(text)
			select text).ToList();
		if (list.Count != 0)
		{
			return string.Join(" / ", list);
		}
		return string.Empty;
	}

	private static string GetTableTitle(XElement P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XElement item in P_0.Descendants())
		{
			if (item.Name == WordNamespace + "t")
			{
				stringBuilder.Append(item.Value);
			}
			else if (item.Name == WordNamespace + "tab")
			{
				stringBuilder.Append('\t');
			}
			else if (item.Name == WordNamespace + "br" || item.Name == WordNamespace + "cr")
			{
				stringBuilder.Append('\n');
			}
		}
		return CleanTitleText(stringBuilder.ToString());
	}

	private static string CleanTitleText(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return string.Empty;
		}
		string text = P_0.Replace('\a', ' ').Replace('\r', ' ').Replace('\n', ' ')
			.Replace('\t', ' ')
			.Trim();
		while (text.Contains("  "))
		{
			text = text.Replace(" ", "  ");
		}
		return text;
	}

	[Conditional("DEBUG")]
	private static void WriteCellToExcel(TableBinding P_0, Table P_1, Microsoft.Office.Interop.Excel.Range P_2, int P_3, int P_4)
	{
		try
		{
		}
		catch
		{
		}
	}

	[Conditional("DEBUG")]
	private static void SetExcelCellValue(Microsoft.Office.Interop.Excel.Range P_0, int P_1, int P_2, string P_3, bool P_4, string P_5)
	{
		try
		{
		}
		catch
		{
		}
	}

	[Conditional("DEBUG")]
	private static void ApplySortToBinding(TableBinding P_0, int P_1)
	{
		try
		{
		}
		catch
		{
		}
	}

	[Conditional("DEBUG")]
	private static void LogSyncTiming(TableBinding P_0, string P_1, TimeSpan P_2, TimeSpan P_3)
	{
		try
		{
		}
		catch
		{
		}
	}

	[Conditional("DEBUG")]
	private static void ApplyWritePlanToBinding(TableBinding P_0, WritePlan P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		try
		{
		}
		catch
		{
		}
	}

	private static string GetValidationKindName(StructureValidationKind P_0)
	{
		return P_0 switch
		{
			(StructureValidationKind)0 => "COM快速结构", 
			(StructureValidationKind)1 => "批量WordOpenXML快照", 
			(StructureValidationKind)2 => "单表WordOpenXML", 
			_ => Convert.ToString(P_0), 
		};
	}

	[Conditional("DEBUG")]
	private static void UpdateBindingWordTableInfo(TableBinding P_0, int P_1, string P_2)
	{
		try
		{
		}
		catch
		{
		}
	}

	private static string GetExcelRangeAddress(Microsoft.Office.Interop.Excel.Range P_0)
	{
		if (P_0 == null)
		{
			return "OpenXML";
		}
		try
		{
			if (_G_o__35.toStringCallSite_Tc19 == null)
			{
				_G_o__35.toStringCallSite_Tc19 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, Type, object, object> target = _G_o__35.toStringCallSite_Tc19.Target;
			CallSite<Func<CallSite, Type, object, object>> toStringCallSite_Tc19 = _G_o__35.toStringCallSite_Tc19;
			Type typeFromHandle = typeof(Convert);
			if (_G_o__35.addressCallSite == null)
			{
				_G_o__35.addressCallSite = CallSite<Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(TableComWriteService), new CSharpArgumentInfo[5]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "RowAbsolute"),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "ColumnAbsolute"),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "ReferenceStyle"),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "External")
				}));
			}
			Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object> target2 = _G_o__35.addressCallSite.Target;
			CallSite<Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object>> addressCallSiteLocal = _G_o__35.addressCallSite;
			if (_G_o__35.toObjectCallSite_Tc16 == null)
			{
				_G_o__35.toObjectCallSite_Tc16 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Address", typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			return (dynamic)(target(toStringCallSite_Tc19, typeFromHandle, target2(addressCallSiteLocal, _G_o__35.toObjectCallSite_Tc16.Target(_G_o__35.toObjectCallSite_Tc16, P_0), arg3: true, arg4: true, XlReferenceStyle.xlA1, arg6: true)) ?? string.Empty);
		}
		catch
		{
			return string.Empty;
		}
	}

	private static string GetExcelCellAddress(Microsoft.Office.Interop.Excel.Range P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return string.Format("OpenXML!R{0}C{1}", P_1, P_2);
		}
		try
		{
			object arg = P_0.Cells[P_1, P_2] as Microsoft.Office.Interop.Excel.Range;
			if (_G_o__36.toStringCallSite_Tc10 == null)
			{
				_G_o__36.toStringCallSite_Tc10 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, Type, object, object> target = _G_o__36.toStringCallSite_Tc10.Target;
			CallSite<Func<CallSite, Type, object, object>> bulV3bRhcZV = _G_o__36.toStringCallSite_Tc10;
			Type typeFromHandle = typeof(Convert);
			if (_G_o__36.toObjectCallSite_Tc14 == null)
			{
				_G_o__36.toObjectCallSite_Tc14 = CallSite<Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(TableComWriteService), new CSharpArgumentInfo[5]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "RowAbsolute"),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "ColumnAbsolute"),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "ReferenceStyle"),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "External")
				}));
			}
			Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object> target2 = _G_o__36.toObjectCallSite_Tc14.Target;
			CallSite<Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object>> mfQV3MfYPGD = _G_o__36.toObjectCallSite_Tc14;
			if (_G_o__36.toObjectCallSite_Tc24 == null)
			{
				_G_o__36.toObjectCallSite_Tc24 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Address", typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			return (dynamic)(target(bulV3bRhcZV, typeFromHandle, target2(mfQV3MfYPGD, _G_o__36.toObjectCallSite_Tc24.Target(_G_o__36.toObjectCallSite_Tc24, arg), arg3: true, arg4: true, XlReferenceStyle.xlA1, arg6: true)) ?? string.Format("R{0}C{1}", P_1, P_2));
		}
		catch
		{
			return string.Format("R{0}C{1}", P_1, P_2);
		}
	}

	private static int GetTableColumnCount(Table P_0)
	{
		try
		{
			return P_0.Columns.Count;
		}
		catch
		{
			return 0;
		}
	}

	private static string NormalizePath(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return string.Empty;
		}
		return P_0.Replace("\\\\", "\\\\\\\\").Replace("\\r", "\\\\r").Replace("\n", "\\\\n")
			.Replace("\"", "\\\\\"");
	}

	private static bool TryResolveRelativePath(string P_0, string P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (!IsPathRelative(P_0))
		{
			return false;
		}
		try
		{
			SetExcelLicense();
			using FileStream newStream = File.Open(P_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			using ExcelPackage excelPackage = new ExcelPackage(newStream);
			ExcelNamedRange excelNamedRange = GetExcelNamedRange(excelPackage, P_1);
			if (excelNamedRange == null || excelNamedRange.Worksheet == null)
			{
				return false;
			}
			P_2 = "=" + GetFileExtension(excelNamedRange.Worksheet.Name) + "!" + GetExcelColumnName(excelNamedRange.Start.Row, excelNamedRange.Start.Column) + ":" + GetExcelColumnName(excelNamedRange.End.Row, excelNamedRange.End.Column);
			return true;
		}
		catch
		{
			return false;
		}
	}

	internal static IList<WorkbookBindingSummary> GetWorkbookBindingSummaries()
	{
		return GroupBindingsByWorkbook(GetAllTableBindings());
	}

	internal static IList<WorkbookBindingSummary> GroupBindingsByWorkbook(IEnumerable<TableBindingStatus> P_0)
	{
		if (P_0 == null)
		{
			return new List<WorkbookBindingSummary>();
		}
		return (from @group in P_0.GroupBy(GetWorkbookKey, StringComparer.OrdinalIgnoreCase)
			select BuildWorkbookSummary(@group.ToList())).OrderBy((WorkbookBindingSummary group) => (!string.IsNullOrWhiteSpace(group.WorkbookName)) ? group.WorkbookName : group.ResolvedExcelPath, StringComparer.OrdinalIgnoreCase).ToList();
	}

	internal static bool TryPreviewExcelPathUpdate(WorkbookBindingSummary P_0, string P_1, out ExcelPathUpdateResult P_2, out string P_3)
	{
		P_2 = null;
		P_3 = string.Empty;
		if (P_0 == null || P_0.Bindings == null || P_0.Bindings.Count == 0)
		{
			P_3 = "请先选择一个 Excel 数据源。";
			return false;
		}
		if (string.IsNullOrWhiteSpace(P_1) || !File.Exists(P_1))
		{
			P_3 = "请选择存在的 Excel 文件。";
			return false;
		}
		if (!IsPathRelative(P_1))
		{
			P_3 = "更换数据源仅支持 .xlsx/.xlsm 文件。";
			return false;
		}
		try
		{
			SetExcelLicense();
			using FileStream newStream = File.Open(P_1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			using ExcelPackage excelPackage = new ExcelPackage(newStream);
			List<BindingUpdateItem> list = new List<BindingUpdateItem>();
			List<BindingUpdateItem> list2 = new List<BindingUpdateItem>();
			foreach (TableBindingStatus binding in P_0.Bindings)
			{
				string text = binding?.ExcelName ?? binding?.Binding?.ExcelName ?? string.Empty;
				BindingUpdateItem kY8DvBV8FJH80M7vjngB2 = new BindingUpdateItem
				{
					BindingId = (binding?.BindingId ?? binding?.Binding?.Id ?? string.Empty),
					DisplayTitle = (binding?.DisplayTitle ?? binding?.WordTableLabel ?? binding?.BindingId ?? string.Empty),
					ExcelName = text
				};
				ExcelNamedRange excelNamedRange = GetExcelNamedRange(excelPackage, text);
				if (excelNamedRange != null && excelNamedRange.Worksheet != null)
				{
					kY8DvBV8FJH80M7vjngB2.NewSheetName = excelNamedRange.Worksheet.Name;
					list.Add(kY8DvBV8FJH80M7vjngB2);
				}
				else
				{
					list2.Add(kY8DvBV8FJH80M7vjngB2);
				}
			}
			P_2 = new ExcelPathUpdateResult
			{
				OldPath = (P_0.ResolvedExcelPath ?? string.Empty),
				NewPath = P_1,
				NewWorkbookName = Path.GetFileName(P_1),
				MatchedItems = list,
				MissingItems = list2
			};
			return true;
		}
		catch (Exception ex)
		{
			P_3 = "读取新 Excel 文件失败：" + ex.Message;
			return false;
		}
	}

	internal static SyncOperationResult ApplyExcelPathUpdate(ExcelPathUpdateResult P_0)
	{
		if (P_0 == null || P_0.MatchedItems == null || P_0.MatchedItems.Count == 0)
		{
			return new SyncOperationResult
			{
				Success = false,
				Message = "新 Excel 文件没有匹配到任何名称区域，未修改绑定。"
			};
		}
		if (string.IsNullOrWhiteSpace(P_0.NewPath) || !File.Exists(P_0.NewPath))
		{
			return new SyncOperationResult
			{
				Success = false,
				Message = "新 Excel 文件不存在，未修改绑定。"
			};
		}
		Dictionary<string, BindingUpdateItem> dictionary = P_0.MatchedItems.Where((BindingUpdateItem item) => !string.IsNullOrWhiteSpace(item.BindingId)).GroupBy((BindingUpdateItem item) => item.BindingId, StringComparer.OrdinalIgnoreCase).ToDictionary((IGrouping<string, BindingUpdateItem> group) => group.Key, (IGrouping<string, BindingUpdateItem> group) => group.First(), StringComparer.OrdinalIgnoreCase);
		Document activeDocument = App.ActiveDocument;
		List<TableBinding> list = GetBindingsFromDocument(activeDocument);
		int num = 0;
		foreach (TableBinding item in list)
		{
			if (item != null && !string.IsNullOrWhiteSpace(item.Id) && dictionary.TryGetValue(item.Id, out var value))
			{
				item.ExcelFullPath = P_0.NewPath;
				item.ExcelRelativePath = GetTableBookmarkXml(activeDocument, P_0.NewPath);
				item.WorkbookName = P_0.NewWorkbookName ?? Path.GetFileName(P_0.NewPath);
				item.SheetName = value.NewSheetName ?? string.Empty;
				ClearTableBindings(activeDocument, item);
				num++;
			}
		}
		int num2 = P_0.MissingItems?.Count ?? 0;
		return new SyncOperationResult
		{
			Success = (num > 0),
			UpdatedCount = num,
			SkippedCount = num2,
			Message = ((num2 > 0) ? string.Format("已更换 {0} 个绑定的数据源。", num, num2) : string.Format("已更换 {0} 个绑定的数据源，{1} 个绑定因缺少名称区域已保留旧数据源。", num))
		};
	}

	internal static bool IsExcelFile(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		try
		{
			Microsoft.Office.Interop.Excel.Application application = ExcelInteropService.GetActiveExcelApp();
			return application != null && OpenExcelWorkbook(application, P_0) != null;
		}
		catch
		{
			return false;
		}
	}

	private static string GetWorkbookKey(TableBindingStatus P_0)
	{
		string text = P_0?.ResolvedExcelPath;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = P_0?.ExcelFullPath;
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			return string.Empty;
		}
		try
		{
			return Path.GetFullPath(text);
		}
		catch
		{
			return text;
		}
	}

	private static WorkbookBindingSummary BuildWorkbookSummary(List<TableBindingStatus> P_0)
	{
		string text = P_0.Select((TableBindingStatus item) => item.ResolvedExcelPath).Concat(P_0.Select((TableBindingStatus item) => item.ExcelFullPath)).FirstOrDefault((string item) => !string.IsNullOrWhiteSpace(item)) ?? string.Empty;
		int num = (string.IsNullOrWhiteSpace(text) ? P_0.Count : P_0.Count((TableBindingStatus item) => !File.Exists(GetWorkbookKey(item))));
		int num2 = P_0.Count((TableBindingStatus item) => string.Equals(item.Status, "Rows", StringComparison.OrdinalIgnoreCase));
		string text2 = P_0.Select((TableBindingStatus item) => item.WorkbookName).FirstOrDefault((string item) => !string.IsNullOrWhiteSpace(item));
		if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text))
		{
			text2 = Path.GetFileName(text);
		}
		return new WorkbookBindingSummary
		{
			ResolvedExcelPath = text,
			WorkbookName = (text2 ?? string.Empty),
			BindingCount = P_0.Count,
			NormalCount = num2,
			MissingPathCount = num,
			Status = BuildGridCellKey(P_0.Count, num2, num),
			Bindings = P_0
		};
	}

	private static string BuildGridCellKey(int P_0, int P_1, int P_2)
	{
		if (P_0 <= 0)
		{
			return "无绑定";
		}
		if (P_2 > 0)
		{
			return "路径不存在";
		}
		if (P_1 < P_0)
		{
			return "部分异常";
		}
		return "正常";
	}

	private static bool ReadExcelDataFromBinding(TableBinding P_0, out string[,] P_1, out ExcelTableStructure P_2, out int P_3, out int P_4, out string P_5)
	{
		P_1 = null;
		P_2 = null;
		P_3 = 0;
		P_4 = 0;
		P_5 = string.Empty;
		string text = GetBindingExcelAddress(P_0);
		if (string.IsNullOrWhiteSpace(text) || !File.Exists(text))
		{
			P_5 = "未找到源 Excel 文件：" + P_0.ExcelFullPath;
			return false;
		}
		if (!IsPathRelative(text))
		{
			P_5 = "源 Excel 工作簿未打开，且当前格式不能直接读取。请打开该工作簿后再同步，或使用 .xlsx/.xlsm 文件。";
			return false;
		}
		try
		{
			SetExcelLicense();
			using FileStream newStream = File.Open(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			using ExcelPackage excelPackage = new ExcelPackage(newStream);
			ExcelNamedRange excelNamedRange = GetExcelNamedRange(excelPackage, P_0.ExcelName);
			if (excelNamedRange == null)
			{
				P_5 = "未找到 Excel 名称区域：" + P_0.ExcelName;
				return false;
			}
			ExcelWorksheet worksheet = excelNamedRange.Worksheet;
			if (worksheet == null)
			{
				P_5 = "Excel 名称区域不是可识别的单工作表矩形区域：" + P_0.ExcelName;
				return false;
			}
			P_3 = excelNamedRange.Rows;
			P_4 = excelNamedRange.Columns;
			if (P_3 <= 0 || P_4 <= 0)
			{
				P_5 = "Excel 名称区域为空：" + P_0.ExcelName;
				return false;
			}
			P_1 = wUkEKEgopc(excelNamedRange, P_3, P_4);
			IList<ExcelMergeInfo> list = GetExcelMergedCells(worksheet, excelNamedRange.Start.Row, excelNamedRange.Start.Column, excelNamedRange.End.Row, excelNamedRange.End.Column);
			P_2 = BuildExcelStructureFromGrid(P_3, P_4, list);
			P_2.SheetName = worksheet.Name;
			return true;
		}
		catch (Exception ex)
		{
			P_5 = "读取 Excel 文件失败：" + ex.Message;
			return false;
		}
	}

	private static ExcelNamedRange GetExcelNamedRange(ExcelPackage P_0, string P_1)
	{
		if (P_0?.Workbook == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		ExcelNamedRange excelNamedRange = TryGetNamedRange(P_0.Workbook.Names, P_1);
		if (excelNamedRange != null)
		{
			return excelNamedRange;
		}
		foreach (ExcelWorksheet worksheet in P_0.Workbook.Worksheets)
		{
			excelNamedRange = TryGetNamedRange(worksheet.Names, P_1);
			if (excelNamedRange != null)
			{
				return excelNamedRange;
			}
		}
		return null;
	}

	private static ExcelNamedRange TryGetNamedRange(ExcelNamedRangeCollection P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		try
		{
			return P_0[P_1];
		}
		catch (KeyNotFoundException)
		{
			return null;
		}
	}

	private static string[,] wUkEKEgopc(ExcelRangeBase P_0, int P_1, int P_2)
	{
		string[,] array = new string[P_1 + 1, P_2 + 1];
		ExcelWorksheet worksheet = P_0.Worksheet;
		for (int i = 1; i <= P_1; i++)
		{
			for (int j = 1; j <= P_2; j++)
			{
				ExcelRange excelRange = worksheet.Cells[P_0.Start.Row + i - 1, P_0.Start.Column + j - 1];
				array[i, j] = ((excelRange == null) ? string.Empty : (Convert.ToString(excelRange.Text) ?? string.Empty));
			}
		}
		return array;
	}

	private static string GetExcelColumnName(int P_0, int P_1)
	{
		return "$" + GetExcelColumnLetter(P_1) + "$" + P_0;
	}

	private static string GetExcelColumnLetter(int P_0)
	{
		if (P_0 <= 0)
		{
			return "A";
		}
		string text = string.Empty;
		while (P_0 > 0)
		{
			P_0--;
			text = (char)(65 + P_0 % 26) + text;
			P_0 /= 26;
		}
		return text;
	}

	private static IList<ExcelMergeInfo> GetExcelMergedCells(ExcelWorksheet P_0, int P_1, int P_2, int P_3, int P_4)
	{
		List<ExcelMergeInfo> list = new List<ExcelMergeInfo>();
		if (P_0?.MergedCells == null)
		{
			return list;
		}
		foreach (string mergedCell in P_0.MergedCells)
		{
			if (TryParseCellRange(mergedCell, out var cellRange))
			{
				int num = Math.Max(P_1, cellRange.StartRow);
				int num2 = Math.Max(P_2, cellRange.StartColumn);
				int num3 = Math.Min(P_3, cellRange.EndRow);
				int num4 = Math.Min(P_4, cellRange.EndColumn);
				if (num <= num3 && num2 <= num4)
				{
					list.Add(new ExcelMergeInfo(num - P_1 + 1, num2 - P_2 + 1, num3 - P_1 + 1, num4 - P_2 + 1));
				}
			}
		}
		return list;
	}

	internal static bool ValidateBindingSync(TableBindingStatus P_0)
	{
		string text;
		bool flag;
		return ValidateBindingSyncInternal(P_0, out text, out flag);
	}

	internal static bool ValidateBindingSyncInternal(TableBindingStatus P_0, out string P_1, out bool P_2)
	{
		P_1 = string.Empty;
		P_2 = false;
		if (P_0 == null)
		{
			P_1 = "请先选择一个绑定关系。";
			P_2 = true;
			return false;
		}
		Microsoft.Office.Interop.Excel.Application application = ExcelInteropService.GetOrCreateExcelApp();
		if (application == null)
		{
			P_1 = "无法启动 Excel/WPS 表格。";
			P_2 = true;
			return false;
		}
		try
		{
			Workbook workbook = OpenExcelWorkbookForBinding(application, P_0.Binding);
			if (workbook == null)
			{
				string text = (string.IsNullOrWhiteSpace(P_0.ResolvedExcelPath) ? P_0.ExcelFullPath : P_0.ResolvedExcelPath);
				P_1 = "未找到源 Excel 文件：" + text;
				P_2 = true;
				return false;
			}
			Microsoft.Office.Interop.Excel.Range range = GetNamedRangeRefersTo(workbook, P_0.Binding.ExcelName);
			if (range == null)
			{
				P_1 = "未找到 Excel 名称区域：" + P_0.ExcelName;
				P_2 = true;
				return false;
			}
			application.Visible = true;
			workbook.Activate();
			try
			{
				range.Worksheet.Activate();
			}
			catch
			{
			}
			try
			{
				application.Goto(range, true);
			}
			catch
			{
				range.Select();
			}
			CloseExcelApplication(application);
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Jump to Excel binding failed", ex);
			P_1 = "定位 Excel 区域失败，请确认源文件、工作表和名称区域仍然存在。";
			P_2 = true;
			return false;
		}
	}

	private static void CloseExcelApplication(Microsoft.Office.Interop.Excel.Application P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		try
		{
			P_0.Visible = true;
		}
		catch
		{
		}
		try
		{
			if (P_0.WindowState == XlWindowState.xlMinimized)
			{
				P_0.WindowState = XlWindowState.xlNormal;
			}
		}
		catch
		{
		}
		try
		{
			P_0.ActiveWindow.Activate();
		}
		catch
		{
		}
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = new IntPtr(P_0.Hwnd);
		}
		catch
		{
		}
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		try
		{
			ScreenshotCaptureHelper2.CaptureScreen(intPtr, 9);
		}
		catch
		{
		}
		try
		{
			ScreenshotCaptureHelper2.CaptureWindow(intPtr);
		}
		catch
		{
		}
	}

	private static Workbook OpenExcelWorkbook(Microsoft.Office.Interop.Excel.Application P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		foreach (Workbook workbook in P_0.Workbooks)
		{
			try
			{
				if (string.Equals(Convert.ToString(workbook.FullName), P_1, StringComparison.OrdinalIgnoreCase))
				{
					return workbook;
				}
			}
			catch
			{
			}
		}
		return null;
	}

	private static bool TryResolveRelativePathWrapper(string P_0, string P_1, out string P_2)
	{
		return TryResolveRelativePath(P_0, P_1, out P_2);
	}

	private static bool IsPathRelative(string P_0)
	{
		string text = Path.GetExtension(P_0) ?? string.Empty;
		if (!text.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) && !text.Equals(".xlsm", StringComparison.OrdinalIgnoreCase) && !text.Equals(".xltx", StringComparison.OrdinalIgnoreCase))
		{
			return text.Equals(".xltm", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static int GetFirstNumberFromPath(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return 0;
		}
		int num = 0;
		string text = P_0.ToUpperInvariant();
		foreach (char c in text)
		{
			if (c < 'A' || c > 'Z')
			{
				return 0;
			}
			num = num * 26 + (c - 65 + 1);
		}
		return num;
	}

	private static int GetLastNumberFromPath(string P_0)
	{
		if (!int.TryParse(P_0, out var result))
		{
			return 0;
		}
		return result;
	}

	private static void WriteBindingDataToExcel(Workbook P_0, string P_1, string P_2, Microsoft.Office.Interop.Excel.Range P_3)
	{
		Name name = null;
		try
		{
			name = P_0.Names.Item(P_1, Type.Missing, Type.Missing);
			name.Delete();
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (name != null)
				{
					Marshal.ReleaseComObject(name);
				}
			}
			catch
			{
			}
		}
		if (_G_o__63.toStringCallSite_Tc17 == null)
		{
			_G_o__63.toStringCallSite_Tc17 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		Func<CallSite, Type, object, object> target = _G_o__63.toStringCallSite_Tc17.Target;
		CallSite<Func<CallSite, Type, object, object>> toStringCallSite_Tc17 = _G_o__63.toStringCallSite_Tc17;
		Type typeFromHandle = typeof(Convert);
		if (_G_o__63.toObjectCallSite_Tc13 == null)
		{
			_G_o__63.toObjectCallSite_Tc13 = CallSite<Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(TableComWriteService), new CSharpArgumentInfo[5]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "RowAbsolute"),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "ColumnAbsolute"),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "ReferenceStyle"),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant | CSharpArgumentInfoFlags.NamedArgument, "External")
			}));
		}
		Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object> target2 = _G_o__63.toObjectCallSite_Tc13.Target;
		CallSite<Func<CallSite, object, bool, bool, XlReferenceStyle, bool, object>> j87V3CYAcGt = _G_o__63.toObjectCallSite_Tc13;
		if (_G_o__63.toObjectCallSite_Tc12 == null)
		{
			_G_o__63.toObjectCallSite_Tc12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "Address", typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
		}
		string text = (dynamic)target(toStringCallSite_Tc17, typeFromHandle, target2(j87V3CYAcGt, _G_o__63.toObjectCallSite_Tc12.Target(_G_o__63.toObjectCallSite_Tc12, P_3), arg3: true, arg4: true, XlReferenceStyle.xlA1, arg6: false));
		string refersTo = "=" + GetFileExtension(P_2) + "!" + text;
		Name name2 = P_0.Names.Add(P_1, refersTo, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
		try
		{
			name2.Visible = false;
		}
		catch
		{
		}
	}

	private static bool TryGetExcelRangeName(Workbook P_0, Microsoft.Office.Interop.Excel.Range P_1, out string P_2)
	{
		P_2 = string.Empty;
		string text = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		try
		{
			foreach (Name name in P_0.Names)
			{
				string text2 = GetExcelNameDefinition(name, P_1);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					if (!text2.StartsWith("IPA_", StringComparison.OrdinalIgnoreCase) && text2.IndexOf("!IPA_", StringComparison.OrdinalIgnoreCase) < 0)
					{
						P_2 = text2;
						return true;
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						text = text2;
					}
				}
			}
		}
		catch
		{
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			P_2 = text;
			return true;
		}
		return false;
	}

	private static string GetExcelNameDefinition(Name P_0, Microsoft.Office.Interop.Excel.Range P_1)
	{
		Microsoft.Office.Interop.Excel.Range range = null;
		try
		{
			if (P_0 == null)
			{
				return string.Empty;
			}
			range = P_0.RefersToRange;
			if (!IsRangeWithinRange(range, P_1))
			{
				return string.Empty;
			}
			string text = Convert.ToString(P_0.Name);
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}
			return text;
		}
		catch
		{
			return string.Empty;
		}
		finally
		{
			try
			{
				if (range != null)
				{
					Marshal.ReleaseComObject(range);
				}
			}
			catch
			{
			}
		}
	}

	private static bool IsRangeWithinRange(Microsoft.Office.Interop.Excel.Range P_0, Microsoft.Office.Interop.Excel.Range P_1)
	{
		try
		{
			if (P_0 == null || P_1 == null)
			{
				return false;
			}
			string a = Convert.ToString(P_0.Worksheet.Name);
			string b = Convert.ToString(P_1.Worksheet.Name);
			if (!string.Equals(a, b, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			return P_0.Row == P_1.Row && P_0.Column == P_1.Column && P_0.Rows.Count == P_1.Rows.Count && P_0.Columns.Count == P_1.Columns.Count;
		}
		catch
		{
			return false;
		}
	}

	private static Workbook OpenExcelWorkbookForBinding(Microsoft.Office.Interop.Excel.Application P_0, TableBinding P_1)
	{
		string text = GetBindingExcelAddress(P_1);
		foreach (Workbook workbook in P_0.Workbooks)
		{
			try
			{
				if (string.Equals(Convert.ToString(workbook.FullName), text, StringComparison.OrdinalIgnoreCase))
				{
					return workbook;
				}
			}
			catch
			{
			}
		}
		if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
		{
			return P_0.Workbooks.Open(text, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
		}
		return null;
	}

	private static Microsoft.Office.Interop.Excel.Range GetNamedRangeRefersTo(Workbook P_0, string P_1)
	{
		try
		{
			return P_0.Names.Item(P_1, Type.Missing, Type.Missing).RefersToRange;
		}
		catch
		{
			try
			{
				foreach (Name name in P_0.Names)
				{
					if (string.Equals(Convert.ToString(name.Name), P_1, StringComparison.OrdinalIgnoreCase))
					{
						return name.RefersToRange;
					}
				}
			}
			catch
			{
			}
			return null;
		}
	}

	private static bool PrepareExcelForSync(Microsoft.Office.Interop.Excel.Application P_0, TableBinding P_1, out Workbook P_2, out Microsoft.Office.Interop.Excel.Range P_3, out string[,] P_4, out ExcelTableStructure P_5, out int P_6, out int P_7, out string P_8)
	{
		P_2 = null;
		P_3 = null;
		P_4 = null;
		P_5 = null;
		P_6 = 0;
		P_7 = 0;
		P_8 = string.Empty;
		string text = GetBindingExcelAddress(P_1);
		if (P_0 == null)
		{
			return false;
		}
		P_2 = OpenExcelWorkbook(P_0, text);
		if (P_2 == null)
		{
			return false;
		}
		P_3 = GetNamedRangeRefersTo(P_2, P_1.ExcelName);
		if (P_3 == null)
		{
			P_8 = "已打开的 Excel 工作簿中未找到名称区域：" + P_1.ExcelName;
			return false;
		}
		try
		{
			P_6 = P_3.Rows.Count;
			P_7 = P_3.Columns.Count;
			P_4 = BuildCellAddressGrid(P_3, P_6, P_7);
			P_5 = ParseExcelRangeToStructure(P_3);
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Read open workbook source failed", ex);
			P_8 = "读取已打开的 Excel 名称区域失败。";
			return false;
		}
	}

	private static bool ReadExcelDataFromBindingWrapper(TableBinding P_0, out string[,] P_1, out ExcelTableStructure P_2, out int P_3, out int P_4, out string P_5)
	{
		return ReadExcelDataFromBinding(P_0, out P_1, out P_2, out P_3, out P_4, out P_5);
	}

	private static string GetBindingExcelAddress(TableBinding P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0.ExcelFullPath) && File.Exists(P_0.ExcelFullPath))
		{
			return P_0.ExcelFullPath;
		}
		try
		{
			string path = App.ActiveDocument.Path;
			if (!string.IsNullOrWhiteSpace(path) && !string.IsNullOrWhiteSpace(P_0.ExcelRelativePath))
			{
				string fullPath = Path.GetFullPath(Path.Combine(path, P_0.ExcelRelativePath));
				if (File.Exists(fullPath))
				{
					return fullPath;
				}
			}
		}
		catch
		{
		}
		return P_0.ExcelFullPath;
	}

	private static string GetExcelRangeCellAddress(Microsoft.Office.Interop.Excel.Range P_0, int P_1, int P_2)
	{
		Microsoft.Office.Interop.Excel.Range range = null;
		try
		{
			range = P_0.Cells[P_1, P_2] as Microsoft.Office.Interop.Excel.Range;
			if (range == null)
			{
				return string.Empty;
			}
			if (_G_o__72.toStringCallSite_Tc16 == null)
			{
				_G_o__72.toStringCallSite_Tc16 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			string text = (dynamic)(_G_o__72.toStringCallSite_Tc16.Target(_G_o__72.toStringCallSite_Tc16, typeof(Convert), range.Text) ?? string.Empty);
			if (!IsExcelFileExtension(text))
			{
				return text;
			}
			if (range.Value2 is string text2 && string.Equals(text.Trim(), text2, StringComparison.Ordinal))
			{
				return text2;
			}
			return text;
		}
		catch
		{
			return string.Empty;
		}
		finally
		{
			try
			{
				if (range != null)
				{
					ReleaseComObject(range);
				}
			}
			catch
			{
			}
		}
	}

	private static bool IsExcelFileExtension(string P_0)
	{
		if (!string.IsNullOrEmpty(P_0))
		{
			if (!char.IsWhiteSpace(P_0[0]))
			{
				return char.IsWhiteSpace(P_0[P_0.Length - 1]);
			}
			return true;
		}
		return false;
	}

	private static string GetFileExtension(string P_0)
	{
		return "'" + (P_0 ?? string.Empty).Replace("'", "''") + "'";
	}

	private static ExcelTableStructure ParseExcelRangeToStructure(Microsoft.Office.Interop.Excel.Range P_0)
	{
		int count = P_0.Rows.Count;
		int count2 = P_0.Columns.Count;
		List<ExcelMergeInfo> list = new List<ExcelMergeInfo>();
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		for (int i = 1; i <= count; i++)
		{
			for (int j = 1; j <= count2; j++)
			{
				Microsoft.Office.Interop.Excel.Range range = null;
				Microsoft.Office.Interop.Excel.Range range2 = null;
				try
				{
					range = P_0.Cells[i, j] as Microsoft.Office.Interop.Excel.Range;
					bool flag = range == null;
					if (flag)
					{
						continue;
					}
					if (_G_o__75.toBooleanCallSite_Tc1 == null)
					{
						_G_o__75.toBooleanCallSite_Tc1 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToBoolean", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					if (flag | !(dynamic)_G_o__75.toBooleanCallSite_Tc1.Target(_G_o__75.toBooleanCallSite_Tc1, typeof(Convert), range.MergeCells))
					{
						continue;
					}
					range2 = range.MergeArea;
					int num = range2.Row - P_0.Row + 1;
					int num2 = range2.Column - P_0.Column + 1;
					int val = num + range2.Rows.Count - 1;
					int val2 = num2 + range2.Columns.Count - 1;
					num = Math.Max(1, num);
					num2 = Math.Max(1, num2);
					val = Math.Min(count, val);
					val2 = Math.Min(count2, val2);
					if (num <= val && num2 <= val2)
					{
						string item = BuildCellKey(num, num2) + ":" + BuildCellKey(val, val2);
						if (hashSet.Add(item))
						{
							list.Add(new ExcelMergeInfo(num, num2, val, val2));
						}
					}
				}
				catch
				{
				}
				finally
				{
					try
					{
						if (range2 != null)
						{
							ReleaseComObject(range2);
						}
					}
					catch
					{
					}
					try
					{
						if (range != null)
						{
							ReleaseComObject(range);
						}
					}
					catch
					{
					}
				}
			}
		}
		ExcelTableStructure excelStructure = BuildExcelStructureFromGrid(count, count2, list);
		excelStructure.SourceKind = (TableSourceKind)1;
		return excelStructure;
	}

	private static string[,] BuildCellAddressGrid(Microsoft.Office.Interop.Excel.Range P_0, int P_1, int P_2)
	{
		string[,] array = new string[P_1 + 1, P_2 + 1];
		for (int i = 1; i <= P_1; i++)
		{
			for (int j = 1; j <= P_2; j++)
			{
				array[i, j] = GetExcelRangeCellAddress(P_0, i, j);
			}
		}
		return array;
	}

	private static ExcelTableStructure BuildExcelStructureFromGrid(int P_0, int P_1, IList<ExcelMergeInfo> P_2)
	{
		ExcelTableStructure excelStructure = new ExcelTableStructure
		{
			SourceKind = (TableSourceKind)1,
			RowCount = P_0,
			ColumnCount = P_1
		};
		Dictionary<string, ExcelMergeInfo> dictionary = P_2.ToDictionary((ExcelMergeInfo item) => BuildCellKey(item.StartRow, item.StartColumn), (ExcelMergeInfo item) => item, StringComparer.Ordinal);
		HashSet<string> hashSet = new HashSet<string>(StringComparer.Ordinal);
		foreach (ExcelMergeInfo item in P_2)
		{
			excelStructure.Merges.Add(item);
			for (int num = item.StartRow; num <= item.EndRow; num++)
			{
				for (int num2 = item.StartColumn; num2 <= item.EndColumn; num2++)
				{
					if (num != item.StartRow || num2 != item.StartColumn)
					{
						hashSet.Add(BuildCellKey(num, num2));
					}
				}
			}
		}
		for (int num3 = 1; num3 <= P_0; num3++)
		{
			for (int num4 = 1; num4 <= P_1; num4++)
			{
				string text = BuildCellKey(num3, num4);
				if (hashSet.Contains(text))
				{
					continue;
				}
				int num5 = 1;
				int num6 = 1;
				if (dictionary.TryGetValue(text, out var value))
				{
					num5 = value.EndRow - value.StartRow + 1;
					num6 = value.EndColumn - value.StartColumn + 1;
				}
				ExcelCellData cellData = new ExcelCellData
				{
					RowIndex = num3,
					ColumnIndex = num4,
					RowSpan = num5,
					ColumnSpan = num6
				};
				excelStructure.AddCell(cellData);
				if (num5 <= 1 && num6 <= 1)
				{
					continue;
				}
				for (int num7 = num3; num7 < num3 + num5; num7++)
				{
					for (int num8 = num4; num8 < num4 + num6; num8++)
					{
						if (num7 != num3 || num8 != num4)
						{
							excelStructure.SetMergedCell(num7, num8, cellData);
						}
					}
				}
			}
		}
		excelStructure.HeaderRowCount = GetMaxColumnCount(excelStructure);
		return excelStructure;
	}

	private static bool TryParseCellRange(string P_0, out CellRange P_1)
	{
		P_1 = null;
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		Match match = Regex.Match(P_0.Trim(), "^\\\\$?([A-Z]{1,4})\\\\$?(\\\\d+)(?::\\\\$?([A-Z]{1,4})\\\\$?(\\\\d+))?$", RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return false;
		}
		int num = GetFirstNumberFromPath(match.Groups[1].Value);
		int num2 = GetLastNumberFromPath(match.Groups[2].Value);
		int num3 = (match.Groups[3].Success ? GetFirstNumberFromPath(match.Groups[3].Value) : num);
		int num4 = (match.Groups[4].Success ? GetLastNumberFromPath(match.Groups[4].Value) : num2);
		if (num <= 0 || num2 <= 0 || num3 <= 0 || num4 <= 0)
		{
			return false;
		}
		P_1 = new CellRange
		{
			StartRow = Math.Min(num2, num4),
			StartColumn = Math.Min(num, num3),
			EndRow = Math.Max(num2, num4),
			EndColumn = Math.Max(num, num3)
		};
		return true;
	}

	private static void ReleaseComObject(object P_0)
	{
		try
		{
			if (P_0 != null && Marshal.IsComObject(P_0))
			{
				Marshal.ReleaseComObject(P_0);
			}
		}
		catch
		{
		}
	}

	internal static SyncResult SyncAllTables(ProgressCallback P_0)
	{
		Document activeDocument = App.ActiveDocument;
		if (!TryGetDocumentSavePath(activeDocument, out var message))
		{
			return new SyncResult
			{
				Success = false,
				RequiresUserAction = true,
				Message = message
			};
		}
		bool screenUpdating = App.ScreenUpdating;
		try
		{
			App.ScreenUpdating = false;
			if (P_0 != null && !P_0(1, 4, "正在读取 Word 文档结构..."))
			{
				return new SyncResult
				{
					Cancelled = true,
					Message = "已取消导出。"
				};
			}
			if (!TryLoadTableStructureContext(activeDocument, out var structureContext, out var text))
			{
				string message2 = SanitizeConfigKey(text) + " 无法执行快速导出。";
				return new SyncResult
				{
					Success = false,
					RequiresUserAction = true,
					Message = message2,
					TechnicalDetail = text
				};
			}
			if (structureContext.Tables.Count == 0)
			{
				return new SyncResult
				{
					Success = false,
					Message = "当前文档没有表格。"
				};
			}
			string text2 = GetDocumentSavePath(activeDocument);
			List<TableSyncContext> list = Sync1(activeDocument, structureContext, text2);
			if (list.Count == 0)
			{
				return new SyncResult
				{
					Success = false,
					Message = "没有可导出的 Word 表格。"
				};
			}
			ApplyTableSyncContext(activeDocument, list);
			if (P_0 != null && !P_0(2, 4, "正在生成 Excel 工作簿..."))
			{
				return new SyncResult
				{
					Cancelled = true,
					Message = "已取消导出。"
				};
			}
			ExportSyncContextToExcel(text2, list);
			if (P_0 != null && !P_0(3, 4, "正在保存 Word 绑定..."))
			{
				return new SyncResult
				{
					Cancelled = true,
					Message = "已取消导出；Excel 文件已生成，但 Word 绑定未全部保存。"
				};
			}
			int num = GetTableStartRow(activeDocument, list);
			int num2 = list.Count - num;
			P_0?.Invoke(4, 4, "导出完成。");
			string message3 = BuildRangeAddress(structureContext.Tables.Count, list.Count, num, num2, text2);
			return new SyncResult
			{
				Success = (num2 == 0),
				Total = structureContext.Tables.Count,
				Bound = num,
				Failed = num2,
				WorkbookPath = text2,
				Message = message3
			};
		}
		catch (Exception ex)
		{
			string message4 = FormatErrorMessage("[ExcelSync] Export all tables failed", ex, "导出全部表并绑定失败，请保存 Word 文档后重试。");
			return new SyncResult
			{
				Success = false,
				RequiresUserAction = true,
				Message = message4,
				TechnicalDetail = ex.Message
			};
		}
		finally
		{
			App.ScreenUpdating = screenUpdating;
		}
	}

	private static bool TryGetDocumentSavePath(Document P_0, out string P_1)
	{
		P_1 = string.Empty;
		if (P_0 == null)
		{
			P_1 = "请先打开一个 Word 文档。";
			return false;
		}
		if (string.IsNullOrWhiteSpace(Convert.ToString(P_0.Path)))
		{
			P_1 = "请先保存 Word 文档后再导出绑定。";
			return false;
		}
		return true;
	}

	private static string GetDocumentSavePath(Document P_0)
	{
		string path = Convert.ToString(P_0.Path);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Convert.ToString(P_0.Name));
		string text = (string.IsNullOrWhiteSpace(fileNameWithoutExtension) ? "Word文档" : fileNameWithoutExtension);
		string text2 = Path.Combine(path, text + "_表格同步.xlsx");
		int num = 1;
		while (File.Exists(text2))
		{
			text2 = Path.Combine(path, text + "_表格同步_" + num + ".xlsx");
			num++;
		}
		return text2;
	}

	private static List<TableSyncContext> Sync1(Document P_0, TableStructureContext P_1, string P_2)
	{
		Dictionary<int, TableBinding> dictionary = BuildBindingIndexMap(P_1);
		List<TableSyncContext> list = new List<TableSyncContext>();
		int num = 1;
		List<HeadingInfo> list2 = new List<HeadingInfo>();
		foreach (WordTableStructure item in P_1.Tables.OrderBy((WordTableStructure item) => item.Index))
		{
			if (item.RowCount > 0 && item.ColumnCount > 0)
			{
				dictionary.TryGetValue(item.Index, out var value);
				string text = ((value != null && IsValidBookmarkId(value.Id)) ? value.Id : GetDefaultExcelSheetName());
				TableBinding binding = new TableBinding
				{
					Id = text,
					ExcelFullPath = P_2,
					ExcelRelativePath = GetTableBookmarkXml(P_0, P_2),
					WorkbookName = Path.GetFileName(P_2),
					SheetName = "Word表格同步",
					ExcelName = text,
					WordBookmark = text,
					SyncMode = "DisplayText",
					HeaderRowCount = (value?.HeaderRowCount ?? GetTableColumnCountFromStructure(item)),
					SortEnabled = (value?.SortEnabled ?? false),
					SortColumnIndex = (value?.SortColumnIndex ?? 2),
					SortDescending = (value?.SortDescending ?? true),
					SortPinOtherLast = (value?.SortPinOtherLast ?? true),
					WordTableIsComplex = (item.Merges.Count > 0),
					WordTableIndex = item.Index,
					WordTableRows = item.RowCount,
					WordTableColumns = item.ColumnCount,
					WordTableTitle = GetTableTitleFromStructure(item),
					WordDisplayTitle = GetFormattedTableTitle(item),
					WordHeadingPath = gAvEPIWeLu(item.HeadingPath),
					WordSnapshotUpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
				};
				List<HeadingInfo> list3 = GetHeadingDiff(list2, item.HeadingPath);
				bool flag = ShouldAddHeadingRow(item, list3);
				int titleRow = (flag ? (num + list3.Count) : 0);
				int num2 = num + list3.Count + (flag ? 1 : 0);
				int num3 = num2 + item.RowCount - 1;
				TableSyncContext syncContext = new TableSyncContext
				{
					Table = item,
					BindingId = text,
					Binding = binding,
					HasTitleRow = flag,
					TitleRow = titleRow,
					StartRow = num2,
					EndRow = num3
				};
				syncContext.HeadingRows.AddRange(list3);
				list.Add(syncContext);
				num = num3 + 3;
				list2 = item.HeadingPath.Select((HeadingInfo item) => item.Clone()).ToList();
			}
		}
		ClampTableRows(list);
		return list;
	}

	private static List<HeadingInfo> GetHeadingDiff(IList<HeadingInfo> P_0, IList<HeadingInfo> P_1)
	{
		List<HeadingInfo> list = new List<HeadingInfo>();
		if (P_1 == null || P_1.Count == 0)
		{
			return list;
		}
		int i = 0;
		for (int num = ((P_0 != null) ? Math.Min(P_0.Count, P_1.Count) : 0); i < num && P_0[i].Level == P_1[i].Level && string.Equals(CleanTitleText(P_0[i].Text), CleanTitleText(P_1[i].Text), StringComparison.Ordinal); i++)
		{
		}
		for (int j = i; j < P_1.Count; j++)
		{
			list.Add(P_1[j].Clone());
		}
		return list;
	}

	private static List<HeadingPathItem> gAvEPIWeLu(IEnumerable<HeadingInfo> P_0)
	{
		List<HeadingPathItem> list = new List<HeadingPathItem>();
		if (P_0 == null)
		{
			return list;
		}
		foreach (HeadingInfo item in P_0)
		{
			string text = CleanTitleText(item?.Text);
			if (!string.IsNullOrWhiteSpace(text))
			{
				list.Add(new HeadingPathItem
				{
					Text = text,
					Level = Math.Max(1, Math.Min(9, item.Level))
				});
			}
		}
		return list;
	}

	private static string GetTableTitleFromStructure(WordTableStructure P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		string text = CleanTitleText(P_0.PreviousParagraphText);
		string text2 = CleanTitleText(P_0.HeadingPath.LastOrDefault()?.Text);
		if (!string.IsNullOrWhiteSpace(text) && !string.Equals(text, text2, StringComparison.Ordinal))
		{
			return text;
		}
		if (!string.IsNullOrWhiteSpace(text2))
		{
			return text2;
		}
		if (P_0.Index <= 0)
		{
			return "Word 表格";
		}
		return string.Format("Word 表格 {0}", P_0.Index);
	}

	private static string GetFormattedTableTitle(WordTableStructure P_0)
	{
		string text = GetTableTitleFromStructure(P_0);
		if (P_0 == null || P_0.Index <= 0)
		{
			return text;
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			return string.Format("第 {0} 表：{1}", P_0.Index, text);
		}
		return string.Format("第 {0} 表", P_0.Index);
	}

	private static bool ShouldAddHeadingRow(WordTableStructure P_0, IList<HeadingInfo> P_1)
	{
		_G_c__DisplayClass90_0 CS_8_locals_8 = new _G_c__DisplayClass90_0();
		if (P_0 == null)
		{
			return true;
		}
		CS_8_locals_8.headingInfo = P_0.HeadingPath.LastOrDefault();
		string text = CleanTitleText(P_0.PreviousParagraphText);
		CS_8_locals_8.text = CleanTitleText(CS_8_locals_8.headingInfo?.Text);
		if (CS_8_locals_8.headingInfo != null && !string.IsNullOrWhiteSpace(CS_8_locals_8.text) && P_1 != null && P_1.Any((HeadingInfo item) => item.Level == CS_8_locals_8.headingInfo.Level && string.Equals(CleanTitleText(item.Text), CS_8_locals_8.text, StringComparison.Ordinal)) && (string.IsNullOrWhiteSpace(text) || string.Equals(text, CS_8_locals_8.text, StringComparison.Ordinal)))
		{
			return false;
		}
		return true;
	}

	private static Dictionary<int, TableBinding> BuildBindingIndexMap(TableStructureContext P_0)
	{
		Dictionary<int, TableBinding> dictionary = new Dictionary<int, TableBinding>();
		foreach (TableBinding binding in P_0.Bindings)
		{
			if (binding != null && IsValidBookmarkId(binding.Id))
			{
				bool flag;
				WordTableStructure hSmUUnVgKE1jrbUYMSFe2 = FindTableStructureByName(P_0, GetBookmarkIdFromBinding(binding), out flag);
				if (hSmUUnVgKE1jrbUYMSFe2 != null && flag && !dictionary.ContainsKey(hSmUUnVgKE1jrbUYMSFe2.Index))
				{
					dictionary[hSmUUnVgKE1jrbUYMSFe2.Index] = binding;
				}
			}
		}
		return dictionary;
	}

	private static void ClampTableRows(IList<TableSyncContext> P_0)
	{
		foreach (TableSyncContext item in P_0)
		{
			if (item.EndRow > 1048576)
			{
				throw new InvalidOperationException("导出的表格超过 Excel 最大行数限制。");
			}
			if (item.Table.ColumnCount > 16384)
			{
				throw new InvalidOperationException("导出的表格超过 Excel 最大列数限制。");
			}
		}
	}

	private static void ApplyTableSyncContext(Document P_0, IList<TableSyncContext> P_1)
	{
		int num = ((P_1.Count != 0) ? P_1.Max((TableSyncContext item) => item.Table.Index) : 0);
		int count;
		try
		{
			count = P_0.Tables.Count;
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException("无法读取当前 Word 文档表格集合，无法保存绑定书签。", innerException);
		}
		if (count < num)
		{
			throw new InvalidOperationException("WordOpenXML 表格数量与当前 Word 表格集合不一致，无法安全保存绑定书签。");
		}
	}

	private static int GetTableStartRow(Document P_0, IList<TableSyncContext> P_1)
	{
		HashSet<string> hashSet = new HashSet<string>(P_1.Select((TableSyncContext item) => item.BindingId), StringComparer.OrdinalIgnoreCase);
		RemoveInvalidBookmarks(P_0, hashSet);
		int num = 0;
		foreach (TableSyncContext item in P_1)
		{
			try
			{
				Table table = P_0.Tables[item.Table.Index];
				ClearTableBindings(P_0, item.Binding);
				RemoveTableBookmarkByName(P_0, table, item.Binding.WordBookmark);
				num++;
			}
			catch (Exception)
			{
			}
		}
		return num;
	}

	private static void RemoveInvalidBookmarks(Document P_0, HashSet<string> P_1)
	{
		try
		{
			for (int num = P_0.Variables.Count; num >= 1; num--)
			{
				Variables variables = P_0.Variables;
				object Index = num;
				Variable variable = variables[ref Index];
				string text = Convert.ToString(variable.Name);
				if (IsValidBookmarkId(text) && !P_1.Contains(text))
				{
					TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingById(Convert.ToString(variable.Value));
					UpdateTableRange(P_0, (lnEK8VVIccoSQf18k7Ih2 != null) ? lnEK8VVIccoSQf18k7Ih2.WordBookmark : text);
					try
					{
						variable.Delete();
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
	}

	private static string GetBookmarkIdFromBinding(TableBinding P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		if (!string.IsNullOrWhiteSpace(P_0.WordBookmark))
		{
			return P_0.WordBookmark;
		}
		return P_0.Id;
	}

	private static string GetDefaultExcelSheetName()
	{
		return "IPA_" + Guid.NewGuid().ToString("N").Substring(0, 12)
			.ToUpperInvariant();
	}

	private static string BuildRangeAddress(int P_0, int P_1, int P_2, int P_3, string P_4)
	{
		return string.Format("快速导出完成：共 {0} 张表，导出 {1} 张，绑定 {2} 张，失败 {3} 张。\\nExcel 文件：{4}", P_0, P_1, P_2, P_3, P_4);
	}

	private static bool TryLoadTableStructureContext(Document P_0, out TableStructureContext P_1, out string P_2)
	{
		P_1 = new TableStructureContext();
		P_2 = string.Empty;
		try
		{
			string text = Convert.ToString(P_0.Content.WordOpenXML);
			if (string.IsNullOrWhiteSpace(text))
			{
				P_2 = "WordOpenXML为空";
				return false;
			}
			XDocument xDocument = XDocument.Parse(text);
			XDocument xDocument2 = CloneDocumentXml(xDocument, "/word/settings.xml");
			XDocument xDocument3 = CloneDocumentXml(xDocument, "/word/document.xml");
			XDocument xDocument4 = CloneDocumentXml(xDocument, "/word/styles.xml");
			if (xDocument3 == null)
			{
				P_2 = "word/document.xml缺失";
				return false;
			}
			P_1.Bindings.AddRange(ParseBindingsFromXml(xDocument2));
			if (P_1.Bindings.Count == 0)
			{
				P_1.Bindings.AddRange(GetBindingsFromDocument(P_0));
			}
			ParseTablesFromStructureXml(xDocument3, P_1, BuildStyleOutlineMap(xDocument4));
			return true;
		}
		catch (Exception ex)
		{
			P_2 = ex.Message;
			return false;
		}
	}

	private static void ParseTablesFromStructureXml(XDocument P_0, TableStructureContext P_1, IDictionary<string, StyleInfo> P_2)
	{
		int num = 0;
		List<HeadingInfo> list = new List<HeadingInfo>();
		if (P_0?.Root != null)
		{
			ParseTableElementDetailed(P_0.Root, P_1, P_2, list, ref num);
		}
	}

	private static void ParseTableElementDetailed(XElement P_0, TableStructureContext P_1, IDictionary<string, StyleInfo> P_2, IList<HeadingInfo> P_3, ref int P_4)
	{
		int num = P_4++;
		WordTableStructure hSmUUnVgKE1jrbUYMSFe2 = null;
		if (P_0.Name == WordNamespace + "bookmarkStart")
		{
			string text = GetAttributeValue(P_0, "id");
			string text2 = GetAttributeValue(P_0, "name");
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
			{
				TableBookmarkInfo value = new TableBookmarkInfo
				{
					Name = text2,
					Start = num,
					End = num
				};
				P_1.BookmarksById[text] = value;
				P_1.BookmarksByName[text2] = value;
			}
		}
		else if (P_0.Name == WordNamespace + "bookmarkEnd")
		{
			string text3 = GetAttributeValue(P_0, "id");
			if (!string.IsNullOrWhiteSpace(text3) && P_1.BookmarksById.TryGetValue(text3, out var value2))
			{
				value2.End = num;
			}
		}
		else if (P_0.Name == WordNamespace + "tbl")
		{
			hSmUUnVgKE1jrbUYMSFe2 = BuildTableStructureFromElement(P_0, P_1.Tables.Count + 1, num);
			hSmUUnVgKE1jrbUYMSFe2.PreviousParagraphText = GetElementText(P_0);
			hSmUUnVgKE1jrbUYMSFe2.HeadingPath.AddRange(P_3.Select((HeadingInfo item) => item.Clone()));
			P_1.Tables.Add(hSmUUnVgKE1jrbUYMSFe2);
		}
		else if (P_0.Name == WordNamespace + "p" && IsTableStartElement(P_0))
		{
			ParseStylesFromXml(P_0, P_2, P_3);
		}
		foreach (XElement item in P_0.Elements())
		{
			ParseTableElementDetailed(item, P_1, P_2, P_3, ref P_4);
		}
		int end = P_4++;
		if (hSmUUnVgKE1jrbUYMSFe2 != null)
		{
			hSmUUnVgKE1jrbUYMSFe2.End = end;
		}
	}

	private static bool IsTableStartElement(XElement P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.Ancestors(WordNamespace + "tbl").Any())
		{
			return false;
		}
		return P_0.Ancestors(WordNamespace + "body").Any();
	}

	private static void ParseStylesFromXml(XElement P_0, IDictionary<string, StyleInfo> P_1, IList<HeadingInfo> P_2)
	{
		string text = CleanTitleText(GetTableTitle(P_0));
		if (string.IsNullOrWhiteSpace(text))
		{
			return;
		}
		int? num = GetValue5(P_0, P_1);
		if (num.HasValue)
		{
			int num2 = Math.Max(1, Math.Min(9, num.Value));
			while (P_2.Count > 0 && P_2[P_2.Count - 1].Level >= num2)
			{
				P_2.RemoveAt(P_2.Count - 1);
			}
			P_2.Add(new HeadingInfo
			{
				Text = text,
				Level = num2
			});
		}
	}

	private static Dictionary<string, StyleInfo> BuildStyleOutlineMap(XDocument P_0)
	{
		Dictionary<string, StyleInfo> dictionary = new Dictionary<string, StyleInfo>(StringComparer.OrdinalIgnoreCase);
		if (P_0?.Root == null)
		{
			return dictionary;
		}
		foreach (XElement item in P_0.Descendants(WordNamespace + "style"))
		{
			if (string.Equals(GetAttributeValue(item, "type"), "paragraph", StringComparison.OrdinalIgnoreCase))
			{
				string text = GetAttributeValue(item, "styleId");
				if (!string.IsNullOrWhiteSpace(text))
				{
					dictionary[text] = new StyleInfo
					{
						StyleId = text,
						BasedOnStyleId = GetAttributeValue(item.Element(WordNamespace + "basedOn"), "val"),
						OutlineLevel = ParseOutlineLevel(item.Element(WordNamespace + "pPr"))
					};
				}
			}
		}
		return dictionary;
	}

	private static int? GetValue5(XElement P_0, IDictionary<string, StyleInfo> P_1)
	{
		XElement xElement = P_0?.Element(WordNamespace + "pPr");
		int? num = ParseOutlineLevel(xElement);
		if (num.HasValue)
		{
			return num.Value;
		}
		return ResolveStyleInheritance(GetAttributeValue(xElement?.Element(WordNamespace + "pStyle"), "val"), P_1, new HashSet<string>(StringComparer.OrdinalIgnoreCase));
	}

	private static int? ResolveStyleInheritance(string P_0, IDictionary<string, StyleInfo> P_1, ISet<string> P_2)
	{
		if (string.IsNullOrWhiteSpace(P_0) || P_1 == null || !P_2.Add(P_0))
		{
			return null;
		}
		if (!P_1.TryGetValue(P_0, out var value) || value == null)
		{
			return null;
		}
		if (value.OutlineLevel.HasValue)
		{
			return value.OutlineLevel.Value;
		}
		return ResolveStyleInheritance(value.BasedOnStyleId, P_1, P_2);
	}

	private static int? ParseOutlineLevel(XElement P_0)
	{
		if (!int.TryParse(GetAttributeValue(P_0?.Element(WordNamespace + "outlineLvl"), "val"), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return null;
		}
		return Math.Max(1, Math.Min(9, result + 1));
	}

	private static WordTableStructure BuildTableStructureFromElement(XElement P_0, int P_1, int P_2)
	{
		WordTableStructure hSmUUnVgKE1jrbUYMSFe2 = new WordTableStructure
		{
			Index = P_1,
			Start = P_2
		};
		Dictionary<int, TableCellData> dictionary = new Dictionary<int, TableCellData>();
		int num = 0;
		foreach (XElement item in P_0.Elements(WordNamespace + "tr"))
		{
			num++;
			int num2 = 1;
			HashSet<TableCellData> hashSet = new HashSet<TableCellData>();
			foreach (XElement item2 in item.Elements(WordNamespace + "tc"))
			{
				int num3 = GetTableGridColumnCount(item2);
				string text = GetStyleVal(item2);
				bool flag = text != null;
				if (flag && !string.Equals(text, "restart", StringComparison.OrdinalIgnoreCase) && dictionary.TryGetValue(num2, out var value))
				{
					if (!hashSet.Contains(value))
					{
						value.RowSpan++;
						hashSet.Add(value);
					}
				}
				else
				{
					TableCellData f4Sg2uVgS5ync8KUfUIt2 = new TableCellData
					{
						RowIndex = num,
						ColumnIndex = num2,
						RowSpan = 1,
						ColumnSpan = num3,
						Text = GetElementTextTrimmed(item2)
					};
					hSmUUnVgKE1jrbUYMSFe2.Cells.Add(f4Sg2uVgS5ync8KUfUIt2);
					if (flag)
					{
						for (int i = 0; i < num3; i++)
						{
							dictionary[num2 + i] = f4Sg2uVgS5ync8KUfUIt2;
						}
					}
					else
					{
						for (int j = 0; j < num3; j++)
						{
							dictionary.Remove(num2 + j);
						}
					}
				}
				hSmUUnVgKE1jrbUYMSFe2.ColumnCount = Math.Max(hSmUUnVgKE1jrbUYMSFe2.ColumnCount, num2 + num3 - 1);
				num2 += num3;
			}
		}
		hSmUUnVgKE1jrbUYMSFe2.RowCount = num;
		ProcessTableStructure(hSmUUnVgKE1jrbUYMSFe2);
		return hSmUUnVgKE1jrbUYMSFe2;
	}

	private static int GetTableGridColumnCount(XElement P_0)
	{
		if (!int.TryParse(P_0.Element(WordNamespace + "tcPr")?.Element(WordNamespace + "gridSpan")?.Attribute(WordNamespace + "val")?.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) || result < 1)
		{
			return 1;
		}
		return result;
	}

	private static string GetStyleVal(XElement P_0)
	{
		XElement xElement = P_0.Element(WordNamespace + "tcPr")?.Element(WordNamespace + "vMerge");
		if (xElement == null)
		{
			return null;
		}
		return GetAttributeValue(xElement, "val");
	}

	private static void ProcessTableStructure(WordTableStructure P_0)
	{
		foreach (TableCellData cell in P_0.Cells)
		{
			if (cell.RowSpan > 1 || cell.ColumnSpan > 1)
			{
				P_0.Merges.Add(new CellMergeInfo
				{
					StartRow = cell.RowIndex,
					StartColumn = cell.ColumnIndex,
					EndRow = cell.RowIndex + cell.RowSpan - 1,
					EndColumn = cell.ColumnIndex + cell.ColumnSpan - 1
				});
			}
		}
	}

	private static string GetElementTextTrimmed(XElement P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XElement item in P_0.Elements(WordNamespace + "p"))
		{
			string value = GetElementRawText(item);
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append('\n');
			}
			stringBuilder.Append(value);
		}
		if (stringBuilder.Length == 0)
		{
			stringBuilder.Append(GetElementRawText(P_0));
		}
		return CleanText(stringBuilder.ToString());
	}

	private static string GetElementRawText(XElement P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XElement item in P_0.Descendants())
		{
			if (item.Name == WordNamespace + "t")
			{
				stringBuilder.Append(item.Value);
			}
			else if (item.Name == WordNamespace + "tab")
			{
				stringBuilder.Append('\t');
			}
			else if (item.Name == WordNamespace + "br" || item.Name == WordNamespace + "cr")
			{
				stringBuilder.Append('\n');
			}
		}
		return stringBuilder.ToString();
	}

	private static string CleanText(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return string.Empty;
		}
		return P_0.Replace('\a', ' ').Replace("\r\n", "\n").Replace('\r', '\n')
			.Trim();
	}

	private static WordTableStructure FindTableStructureByName(TableStructureContext P_0, string P_1, out bool P_2)
	{
		_G_c__DisplayClass115_0 CS_8_locals_4 = new _G_c__DisplayClass115_0();
		P_2 = false;
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		if (!P_0.BookmarksByName.TryGetValue(P_1, out var value))
		{
			return null;
		}
		P_2 = true;
		CS_8_locals_4.value = Math.Min(value.Start, value.End);
		CS_8_locals_4.value = Math.Max(value.Start, value.End);
		return P_0.Tables.FirstOrDefault((WordTableStructure table) => CS_8_locals_4.value <= table.End && CS_8_locals_4.value >= table.Start);
	}

	private static void ExportSyncContextToExcel(string P_0, IList<TableSyncContext> P_1)
	{
		SetExcelLicense();
		FileInfo fileInfo = new FileInfo(P_0);
		if (fileInfo.Exists)
		{
			fileInfo.Delete();
		}
		using ExcelPackage excelPackage = new ExcelPackage(fileInfo);
		ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Word表格同步");
		excelWorksheet.View.ShowGridLines = true;
		excelWorksheet.Cells.Style.Font.Name = "等线";
		excelWorksheet.Cells.Style.Font.Size = 11f;
		excelWorksheet.DefaultRowHeight = 15.0;
		int num = Math.Max(1, (P_1.Count == 0) ? 1 : P_1.Max((TableSyncContext item) => item.Table.ColumnCount));
		for (int num2 = 1; num2 <= num; num2++)
		{
			excelWorksheet.Column(num2).Width = 14.0;
		}
		foreach (TableSyncContext item in P_1)
		{
			WriteHeadingRowsToExcel(excelWorksheet, item);
			if (item.HasTitleRow)
			{
				WriteTitleRowToExcel(excelWorksheet, item);
			}
			WriteDataRowsToExcel(excelWorksheet, item);
			ApplyColumnWidths(excelWorksheet, item);
			AddNamedRangeForBinding(excelPackage, excelWorksheet, item);
		}
		if (P_1.Count > 0)
		{
			int toRow = P_1.Max((TableSyncContext item) => item.EndRow);
			excelWorksheet.Cells[1, 1, toRow, num].AutoFitColumns(10.0, 24.0);
		}
		excelPackage.Save();
	}

	private static void SetExcelLicense()
	{
		ExcelPackage.License.SetNonCommercialOrganization("cgzcpa");
	}

	private static void WriteTitleRowToExcel(ExcelWorksheet P_0, TableSyncContext P_1)
	{
		if (P_1 != null && P_1.HasTitleRow)
		{
			int titleRow = P_1.TitleRow;
			ExcelRange excelRange = P_0.Cells[titleRow, 1];
			P_0.Cells[titleRow, 1].Value = GetTableTitleForExcel(P_1);
			ApplyCellStyle(excelRange);
			P_0.Row(titleRow).Height = 18.0;
			ExcelRange range11 = P_0.Cells[titleRow, 1];
			string text = GetTableCommentForExcel(P_1);
			if (range11.Comment == null)
			{
				range11.AddComment(text, "IP_Assurance");
			}
			else
			{
				range11.Comment.Text = text;
			}
			range11.Comment.Visible = false;
		}
	}

	private static void WriteHeadingRowsToExcel(ExcelWorksheet P_0, TableSyncContext P_1)
	{
		if (P_1 == null || P_1.HeadingRows.Count == 0)
		{
			return;
		}
		int num = P_1.StartRow - P_1.HeadingRows.Count - (P_1.HasTitleRow ? 1 : 0);
		foreach (HeadingInfo headingRow in P_1.HeadingRows)
		{
			ExcelRange excelRange = P_0.Cells[num, 1];
			P_0.Cells[num, 1].Value = CleanTitleText(headingRow.Text);
			ApplyCellStyle(excelRange);
			P_0.Row(num).Height = 18.0;
			ExcelRange range11 = P_0.Cells[num, 1];
			string text = "大纲级别:" + Math.Max(1, Math.Min(9, headingRow.Level));
			if (range11.Comment == null)
			{
				range11.AddComment(text, "IP_Assurance");
			}
			else
			{
				range11.Comment.Text = text;
			}
			range11.Comment.Visible = false;
			num++;
		}
	}

	private static void WriteDataRowsToExcel(ExcelWorksheet P_0, TableSyncContext P_1)
	{
		Dictionary<string, TableCellData> dictionary = BuildCellDataMap(P_1.Table);
		int startRow = P_1.StartRow;
		int endRow = P_1.EndRow;
		int columnCount = P_1.Table.ColumnCount;
		ApplyCellBorders(P_0.Cells[startRow, 1, endRow, columnCount]);
		for (int i = 1; i <= P_1.Table.RowCount; i++)
		{
			int row = startRow + i - 1;
			for (int j = 1; j <= columnCount; j++)
			{
				dictionary.TryGetValue(GetExcelCellAddressByIndex(i, j), out var value);
				P_0.Cells[row, j].Value = ((value == null) ? string.Empty : SanitizeSheetName(value.Text));
			}
		}
	}

	private static void ApplyColumnWidths(ExcelWorksheet P_0, TableSyncContext P_1)
	{
		foreach (CellMergeInfo merge in P_1.Table.Merges)
		{
			int fromRow = P_1.StartRow + merge.StartRow - 1;
			int toRow = P_1.StartRow + merge.EndRow - 1;
			P_0.Cells[fromRow, merge.StartColumn, toRow, merge.EndColumn].Merge = true;
		}
	}

	private static void AddNamedRangeForBinding(ExcelPackage P_0, ExcelWorksheet P_1, TableSyncContext P_2)
	{
		ExcelRange range = P_1.Cells[P_2.StartRow, 1, P_2.EndRow, Math.Max(1, P_2.Table.ColumnCount)];
		try
		{
			if (P_0.Workbook.Names[P_2.BindingId] != null)
			{
				P_0.Workbook.Names.Remove(P_2.BindingId);
			}
		}
		catch (KeyNotFoundException)
		{
		}
		P_0.Workbook.Names.Add(P_2.BindingId, range).IsNameHidden = true;
	}

	private static void ApplyCellStyle(ExcelRange P_0)
	{
		P_0.Style.Font.Bold = true;
		P_0.Style.Fill.PatternType = ExcelFillStyle.None;
		P_0.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
		P_0.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
		P_0.Style.WrapText = false;
	}

	private static void ApplyCellBorders(ExcelRange P_0)
	{
		P_0.Style.Border.Left.Style = ExcelBorderStyle.Thin;
		P_0.Style.Border.Right.Style = ExcelBorderStyle.Thin;
		P_0.Style.Border.Top.Style = ExcelBorderStyle.Thin;
		P_0.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
		P_0.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
		P_0.Style.WrapText = true;
	}

	private static Dictionary<string, TableCellData> BuildCellDataMap(WordTableStructure P_0)
	{
		Dictionary<string, TableCellData> dictionary = new Dictionary<string, TableCellData>(StringComparer.Ordinal);
		foreach (TableCellData cell in P_0.Cells)
		{
			dictionary[GetExcelCellAddressByIndex(cell.RowIndex, cell.ColumnIndex)] = cell;
		}
		return dictionary;
	}

	private static string GetExcelCellAddressByIndex(int P_0, int P_1)
	{
		return P_0 + ":" + P_1;
	}

	private static string GetTableTitleForExcel(TableSyncContext P_0)
	{
		string text = CleanTitleText(P_0?.Table?.PreviousParagraphText);
		string b = CleanTitleText(P_0?.Table?.HeadingPath.LastOrDefault()?.Text);
		if (!string.IsNullOrWhiteSpace(text) && !string.Equals(text, b, StringComparison.Ordinal))
		{
			return text;
		}
		int valueOrDefault = (P_0?.Table?.Index).GetValueOrDefault();
		if (valueOrDefault <= 0)
		{
			return "Word 表格";
		}
		return string.Format("Word 表格 {0}", valueOrDefault);
	}

	private static string GetTableCommentForExcel(TableSyncContext P_0)
	{
		int val = ((P_0 != null && P_0.Table?.HeadingPath.Count > 0) ? (P_0.Table.HeadingPath[P_0.Table.HeadingPath.Count - 1].Level + 1) : 9);
		val = Math.Max(1, Math.Min(9, val));
		return "大纲级别:" + val;
	}

	private static string SanitizeSheetName(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(P_0.Length);
		foreach (char c in P_0)
		{
			if (XmlConvert.IsXmlChar(c))
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private static string BuildCellKey(int P_0, int P_1)
	{
		return P_0.ToString(CultureInfo.InvariantCulture) + ":" + P_1.ToString(CultureInfo.InvariantCulture);
	}

	private static XDocument CloneDocumentXml(XDocument P_0, string P_1)
	{
		_G_c__DisplayClass164_0 CS_8_locals_3 = new _G_c__DisplayClass164_0();
		CS_8_locals_3.tJcVJbRSSXT = P_1;
		if (P_0?.Root == null)
		{
			return null;
		}
		if (P_0.Root.Name == WordNamespace + "document" && string.Equals(CS_8_locals_3.tJcVJbRSSXT, "/word/document.xml", StringComparison.OrdinalIgnoreCase))
		{
			return P_0;
		}
		XElement xElement = P_0.Root.Elements(XmlPackageNamespace + "part").FirstOrDefault((XElement element) => string.Equals((string)element.Attribute(XmlPackageNamespace + "xmlData"), CS_8_locals_3.tJcVJbRSSXT, StringComparison.OrdinalIgnoreCase))?.Element(XmlPackageNamespace + "InsertRowsBelow")?.Elements().FirstOrDefault();
		if (xElement != null)
		{
			return new XDocument(new XElement(xElement));
		}
		return null;
	}

	private static string GetAttributeValue(XElement P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return string.Empty;
		}
		return ((string)P_0.Attribute(WordNamespace + P_1)) ?? ((string)P_0.Attribute(P_1)) ?? string.Empty;
	}

	private static List<ColumnMapping> BuildColumnMappings(TableBinding P_0, int P_1)
	{
		int num = Math.Max(0, P_1);
		if (num == 0 && P_0?.ColumnMappings != null)
		{
			num = P_0.ColumnMappings.Count;
		}
		List<ColumnMapping> list = new List<ColumnMapping>();
		for (int i = 1; i <= num; i++)
		{
			int excelColumnIndex = i;
			if (P_0?.ColumnMappings != null && P_0.ColumnMappings.Count >= i && P_0.ColumnMappings[i - 1] > 0)
			{
				excelColumnIndex = P_0.ColumnMappings[i - 1];
			}
			list.Add(new ColumnMapping
			{
				WordColumnIndex = i,
				ExcelColumnIndex = excelColumnIndex
			});
		}
		return list;
	}

	private static List<int> FilterPositiveInts(IEnumerable<int> P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		List<int> list = P_0.Where((int item) => item > 0).ToList();
		if (list.Count != 0)
		{
			return list;
		}
		return null;
	}

	private static bool SyncExcelDataToBinding(TableBinding P_0, ref string[,] P_1, ref ExcelTableStructure P_2, ref int P_3, out string P_4)
	{
		_G_c__DisplayClass168_0 CS_8_locals_3 = new _G_c__DisplayClass168_0();
		P_4 = string.Empty;
		if (P_0?.ColumnMappings == null || P_0.ColumnMappings.Count == 0)
		{
			return true;
		}
		if (P_1 == null)
		{
			return true;
		}
		List<int> list = P_0.ColumnMappings.Where((int item) => item > 0).ToList();
		if (list.Count == 0)
		{
			return true;
		}
		CS_8_locals_3.value = P_3;
		if (list.Any((int column) => column > CS_8_locals_3.value))
		{
			P_4 = string.Format("列映射超出 Excel 名称区域列数：当前 Excel 区域只有 {0} 列。", CS_8_locals_3.value);
			return false;
		}
		if (list.Distinct().Count() != list.Count)
		{
			P_4 = "列映射中存在重复的 Excel 列，请为当前 Word 表的每一列选择不同的 Excel 列。";
			return false;
		}
		for (int num = 1; num < list.Count; num++)
		{
			if (list[num] <= list[num - 1])
			{
				P_4 = "列映射中的 Excel 列号需要从左到右递增。";
				return false;
			}
		}
		P_1 = RemapGridColumns(P_1, P_2, list);
		if (P_2 != null)
		{
			P_2 = FilterExcelStructureByRows(P_2, list);
		}
		P_3 = list.Count;
		return true;
	}

	private static string[,] RemapGridColumns(string[,] P_0, ExcelTableStructure P_1, IList<int> P_2)
	{
		int num = P_0.GetLength(0) - 1;
		string[,] array = new string[num + 1, P_2.Count + 1];
		for (int i = 1; i <= num; i++)
		{
			for (int j = 1; j <= P_2.Count; j++)
			{
				int num2 = P_2[j - 1];
				int num3 = i;
				int num4 = num2;
				if (P_1 != null && P_1.TryGetMergedCell(i, num2, out var cellData))
				{
					num3 = cellData.RowIndex;
					num4 = cellData.ColumnIndex;
				}
				array[i, j] = GetCellValueFromGrid(P_0, num3, num4);
			}
		}
		return array;
	}

	private static ExcelTableStructure FilterExcelStructureByRows(ExcelTableStructure P_0, IList<int> P_1)
	{
		ExcelTableStructure excelStructure = new ExcelTableStructure
		{
			SourceKind = P_0.SourceKind,
			TableIndex = P_0.TableIndex,
			SheetName = P_0.SheetName,
			RowCount = P_0.RowCount,
			ColumnCount = P_1.Count,
			HeaderRowCount = Math.Min(Math.Max(0, P_0.HeaderRowCount), Math.Max(0, P_0.RowCount)),
			HasVerticalMerge = P_0.HasVerticalMerge
		};
		foreach (ExcelCellData item in from item in P_0.Cells
			orderby item.RowIndex, item.ColumnIndex
			select item)
		{
			int columnIndex = item.ColumnIndex;
			int num = item.ColumnIndex + Math.Max(1, item.ColumnSpan) - 1;
			List<int> list = new List<int>();
			for (int num2 = 0; num2 < P_1.Count; num2++)
			{
				int num3 = P_1[num2];
				if (num3 >= columnIndex && num3 <= num)
				{
					list.Add(num2 + 1);
				}
			}
			if (list.Count == 0)
			{
				continue;
			}
			int num4 = list.Min();
			int num5 = list.Max();
			ExcelCellData cellData = new ExcelCellData
			{
				RowIndex = item.RowIndex,
				ColumnIndex = num4,
				RowSpan = Math.Max(1, item.RowSpan),
				ColumnSpan = Math.Max(1, num5 - num4 + 1),
				Text = item.Text,
				Element = item.Element
			};
			excelStructure.AddCell(cellData);
			for (int num6 = cellData.RowIndex; num6 < cellData.RowIndex + cellData.RowSpan; num6++)
			{
				for (int num7 = cellData.ColumnIndex; num7 < cellData.ColumnIndex + cellData.ColumnSpan; num7++)
				{
					if (num6 != cellData.RowIndex || num7 != cellData.ColumnIndex)
					{
						excelStructure.SetMergedCell(num6, num7, cellData);
					}
				}
			}
		}
		excelStructure.RebuildMerges();
		return excelStructure;
	}

	private static int GetMaxColumnCount(ExcelTableStructure P_0)
	{
		if (P_0 == null || P_0.RowCount <= 0)
		{
			return 0;
		}
		if (P_0.Merges.Count == 0)
		{
			return 1;
		}
		int num = 0;
		_G_c__DisplayClass171_0 CS_8_locals_6 = new _G_c__DisplayClass171_0();
		CS_8_locals_6.AxRVJNkeKZE = 1;
		while (CS_8_locals_6.AxRVJNkeKZE <= P_0.RowCount && P_0.Merges.Any((ExcelMergeInfo merge) => merge.StartRow <= CS_8_locals_6.AxRVJNkeKZE && merge.EndRow >= CS_8_locals_6.AxRVJNkeKZE))
		{
			num = CS_8_locals_6.AxRVJNkeKZE;
			CS_8_locals_6.AxRVJNkeKZE++;
		}
		bool flag;
		do
		{
			flag = false;
			foreach (ExcelMergeInfo merge in P_0.Merges)
			{
				if (merge.StartRow <= num && merge.EndRow > num)
				{
					num = merge.EndRow;
					flag = true;
				}
			}
		}
		while (flag);
		return Math.Min(Math.Max(1, num), P_0.RowCount);
	}

	private static int GetTableColumnCountFromStructure(WordTableStructure P_0)
	{
		if (P_0 == null || P_0.RowCount <= 0)
		{
			return 0;
		}
		if (P_0.Merges.Count == 0)
		{
			return 1;
		}
		int num = 0;
		_G_c__DisplayClass172_0 CS_8_locals_6 = new _G_c__DisplayClass172_0();
		CS_8_locals_6.RcXVJoFgptR = 1;
		while (CS_8_locals_6.RcXVJoFgptR <= P_0.RowCount && P_0.Merges.Any((CellMergeInfo merge) => merge.StartRow <= CS_8_locals_6.RcXVJoFgptR && merge.EndRow >= CS_8_locals_6.RcXVJoFgptR))
		{
			num = CS_8_locals_6.RcXVJoFgptR;
			CS_8_locals_6.RcXVJoFgptR++;
		}
		bool flag;
		do
		{
			flag = false;
			foreach (CellMergeInfo merge in P_0.Merges)
			{
				if (merge.StartRow <= num && merge.EndRow > num)
				{
					num = merge.EndRow;
					flag = true;
				}
			}
		}
		while (flag);
		return Math.Min(Math.Max(1, num), P_0.RowCount);
	}

	private static void ApplyStructureChangesToBinding(TableBinding P_0, ExcelTableStructure P_1, ExcelTableStructure P_2)
	{
		if (P_0 != null && P_0.HeaderRowCount.HasValue)
		{
			int val = Math.Max(0, P_0.HeaderRowCount.Value);
			if (P_1 != null)
			{
				P_1.HeaderRowCount = Math.Min(val, Math.Max(0, P_1.RowCount));
			}
			if (P_2 != null)
			{
				P_2.HeaderRowCount = Math.Min(val, Math.Max(0, P_2.RowCount));
			}
		}
	}

	private static int GetExcelDataStartRow(TableBinding P_0, int P_1)
	{
		int num = Math.Max(0, P_1);
		if (P_0 == null)
		{
			return num;
		}
		if (!P_0.HeaderRowCount.HasValue)
		{
			P_0.HeaderRowCount = num;
		}
		return Math.Max(0, P_0.HeaderRowCount.Value);
	}

	private static string GetExcelSheetName(TableBinding P_0, int? P_1)
	{
		if (P_0 != null && P_0.HeaderRowCount.HasValue)
		{
			return string.Format("表头行数：{0} 行", Math.Max(0, P_0.HeaderRowCount.Value));
		}
		if (P_1.HasValue)
		{
			return string.Format("表头行数：{0} 行", Math.Max(0, P_1.Value));
		}
		return "表头行数：尚未识别";
	}

	private static bool PrepareTableForSync(Table P_0, TableBinding P_1, bool P_2, out int P_3, out TableBinding P_4, out bool P_5, out string P_6)
	{
		P_3 = 0;
		P_4 = null;
		P_5 = false;
		P_6 = string.Empty;
		Microsoft.Office.Interop.Excel.Application application = ExcelInteropService.GetActiveExcelApp();
		if (application == null)
		{
			P_6 = "请先在 Excel 中选中要绑定的区域。";
			return false;
		}
		if (!(application.Selection is Microsoft.Office.Interop.Excel.Range range))
		{
			P_6 = "请先在 Excel 中选中要绑定的区域。";
			return false;
		}
		Workbook activeWorkbook = application.ActiveWorkbook;
		if (activeWorkbook == null || string.IsNullOrWhiteSpace(Convert.ToString(activeWorkbook.FullName)) || !File.Exists(Convert.ToString(activeWorkbook.FullName)))
		{
			P_6 = "请先保存 Excel 工作簿后再绑定。";
			return false;
		}
		TableBinding lnEK8VVIccoSQf18k7Ih2 = (P_2 ? P_1 : null);
		string text = ((lnEK8VVIccoSQf18k7Ih2 != null && IsValidBookmarkId(lnEK8VVIccoSQf18k7Ih2.Id)) ? lnEK8VVIccoSQf18k7Ih2.Id : ("IPA_" + Guid.NewGuid().ToString("N").Substring(0, 12)
			.ToUpperInvariant()));
		string text2 = Convert.ToString(range.Worksheet.Name);
		if (!TryGetExcelRangeName(activeWorkbook, range, out var text3))
		{
			text3 = text;
			WriteBindingDataToExcel(activeWorkbook, text3, text2, range);
		}
		P_4 = new TableBinding
		{
			Id = text,
			ExcelFullPath = Convert.ToString(activeWorkbook.FullName),
			ExcelRelativePath = GetTableBookmarkXml(App.ActiveDocument, Convert.ToString(activeWorkbook.FullName)),
			WorkbookName = Convert.ToString(activeWorkbook.Name),
			SheetName = text2,
			ExcelName = text3,
			WordBookmark = text,
			SyncMode = "DisplayText",
			HeaderRowCount = lnEK8VVIccoSQf18k7Ih2?.HeaderRowCount,
			SortEnabled = (lnEK8VVIccoSQf18k7Ih2?.SortEnabled ?? false),
			SortColumnIndex = (lnEK8VVIccoSQf18k7Ih2?.SortColumnIndex ?? 2),
			SortDescending = (lnEK8VVIccoSQf18k7Ih2?.SortDescending ?? true),
			SortPinOtherLast = (lnEK8VVIccoSQf18k7Ih2?.SortPinOtherLast ?? true),
			ColumnMappings = ((lnEK8VVIccoSQf18k7Ih2?.ColumnMappings == null) ? null : new List<int>(lnEK8VVIccoSQf18k7Ih2.ColumnMappings)),
			WordTableIsComplex = (lnEK8VVIccoSQf18k7Ih2?.WordTableIsComplex ?? IsTableStructureValid(P_0))
		};
		if (P_1 != null && !string.Equals(P_1.Id, P_4.Id, StringComparison.OrdinalIgnoreCase))
		{
			RemoveBindingFromDocument(App.ActiveDocument, P_1);
		}
		RemoveTableBookmark(App.ActiveDocument, P_0, P_4);
		P_5 = SyncTableCore(P_4, P_0, GetDefaultSyncOptions(), null, null, out P_3, out var _, out var _, out P_6);
		return true;
	}

	private static bool SyncTableWithHeaders(TableBinding P_0, Table P_1, SyncOptions P_2, out int P_3)
	{
		bool flag;
		string text;
		string text2;
		return SyncTableCore(P_0, P_1, P_2, null, null, out P_3, out flag, out text, out text2);
	}

	private static bool SyncTableWithCache(TableBinding P_0, Table P_1, SyncOptions P_2, FastStructureCache P_3, out int P_4)
	{
		bool flag;
		string text;
		string text2;
		return SyncTableCore(P_0, P_1, P_2, P_3, null, out P_4, out flag, out text, out text2);
	}

	private static bool SyncTableCore(TableBinding P_0, Table P_1, SyncOptions P_2, FastStructureCache P_3, ProgressCallback P_4, out int P_5, out bool P_6, out string P_7, out string P_8)
	{
		P_5 = 0;
		P_6 = false;
		P_7 = string.Empty;
		P_8 = string.Empty;
		P_2 = P_2 ?? GetDefaultSyncOptions();
		Workbook workbook = null;
		Microsoft.Office.Interop.Excel.Range range = null;
		bool screenUpdating = App.ScreenUpdating;
		App.ScreenUpdating = false;
		try
		{
			int? num = P_0?.HeaderRowCount;
			bool? flag = P_0?.WordTableIsComplex;
			if (!ReportProgress(P_4, 2, "正在读取 Excel 源区域...", ref P_6))
			{
				return false;
			}
			if (!PrepareExcelForSync(ExcelInteropService.GetActiveExcelApp(), P_0, out workbook, out range, out var array, out var excelStructure, out var num2, out var num3, out var text))
			{
				if (workbook != null)
				{
					P_8 = GetBindingConfigKey(P_0, text);
					return false;
				}
				if (!ReadExcelDataFromBindingWrapper(P_0, out array, out excelStructure, out num2, out num3, out text))
				{
					P_8 = GetBindingConfigKey(P_0, text);
					return false;
				}
			}
			if (!ReportProgress(P_4, 3, "正在读取 Word 表格结构...", ref P_6))
			{
				return false;
			}
			if (!TryBuildExcelStructureForSync(App.ActiveDocument, P_1, P_0, P_3, out var aiS98lViTM5QHeakGIJC2, out var yZvr8GVH490gxwLVpGhc2, out var text2))
			{
				P_8 = SanitizeConfigKey(text2);
				return false;
			}
			GetExcelDataStartRow(P_0, aiS98lViTM5QHeakGIJC2.HeaderRowCount);
			int? num4 = num;
			int? headerRowCount = P_0.HeaderRowCount;
			num4.GetValueOrDefault();
			headerRowCount.GetValueOrDefault();
			_ = num4.HasValue;
			_ = headerRowCount.HasValue;
			ApplyStructureChangesToBinding(P_0, aiS98lViTM5QHeakGIJC2, excelStructure);
			if (!SyncExcelDataToBinding(P_0, ref array, ref excelStructure, ref num3, out var text3))
			{
				P_8 = text3;
				return false;
			}
			array = SortTableData(P_0, excelStructure, array, out P_7);
			if (!ReportProgress(P_4, 4, "正在生成同步计划...", ref P_6))
			{
				return false;
			}
			WritePlan writePlan = BuildWritePlan(aiS98lViTM5QHeakGIJC2, excelStructure, num2, num3, P_3 != null);
			bool flag2 = false;
			if (!ReportProgress(P_4, 5, "正在调整或重建 Word 表结构...", ref P_6))
			{
				return false;
			}
			if (writePlan.RequiresStructureRebuild)
			{
				if (writePlan.ExecutorKind == (ExecutorKind)2)
				{
					if (!ValidateAndAdjustTable(P_1, aiS98lViTM5QHeakGIJC2, excelStructure, array, out var text4))
					{
						P_8 = "Word 表格结构重建失败：" + (string.IsNullOrWhiteSpace(text4) ? "请检查 Excel 合并区域和 Word 表格后重试。" : text4);
						return false;
					}
					flag2 = true;
					int num5 = GetTableIndexInDocument(App.ActiveDocument, P_1);
					if (num5 <= 0 || !TryGetStructureByTableIndex(App.ActiveDocument, num5, out aiS98lViTM5QHeakGIJC2, out text2))
					{
						aiS98lViTM5QHeakGIJC2 = excelStructure;
					}
					ApplyStructureChangesToBinding(P_0, aiS98lViTM5QHeakGIJC2, excelStructure);
				}
				else
				{
					if (!RebuildTableViaCom(App.ActiveDocument, P_1, aiS98lViTM5QHeakGIJC2, excelStructure, P_0, array, out var table))
					{
						P_8 = "Word 表格结构重建失败，请检查 Excel 合并区域和 Word 表格后重试。";
						return false;
					}
					P_1 = table;
					flag2 = true;
					int num6 = GetTableIndexInDocument(App.ActiveDocument, P_1);
					if (num6 <= 0 || !TryGetStructureByTableIndex(App.ActiveDocument, num6, out aiS98lViTM5QHeakGIJC2, out text2))
					{
						P_8 = SanitizeConfigKey(text2);
						return false;
					}
					ApplyStructureChangesToBinding(P_0, aiS98lViTM5QHeakGIJC2, excelStructure);
				}
			}
			else
			{
				bool flag3 = WriteTableRowViaCom(P_1, writePlan.TargetRows, aiS98lViTM5QHeakGIJC2?.HeaderRowCount ?? 0, aiS98lViTM5QHeakGIJC2, array, num2);
				if (writePlan.ColumnShapeChanged && !RemoveEmptyRowsWrapper(P_1, writePlan.TargetColumns, aiS98lViTM5QHeakGIJC2))
				{
					P_8 = "Word 表格列数调整失败，请检查表格合并结构后重试。";
					return false;
				}
				if ((writePlan.RowShapeChanged && flag3) || writePlan.ColumnShapeChanged)
				{
					if (!TryBuildExcelStructureForSync(App.ActiveDocument, P_1, P_0, null, out aiS98lViTM5QHeakGIJC2, out yZvr8GVH490gxwLVpGhc2, out text2))
					{
						P_8 = SanitizeConfigKey(text2);
						return false;
					}
					ApplyStructureChangesToBinding(P_0, aiS98lViTM5QHeakGIJC2, excelStructure);
				}
			}
			ApplyBindingToStructure(P_0, aiS98lViTM5QHeakGIJC2);
			bool? flag4 = flag;
			bool? wordTableIsComplex = P_0.WordTableIsComplex;
			_ = flag4 == true;
			_ = wordTableIsComplex == true;
			_ = flag4.HasValue;
			_ = wordTableIsComplex.HasValue;
			if (flag2)
			{
				ReportProgress(P_4, 6, "Word 表结构已重建，正在完成数据写入...", ref P_6, false);
				P_5 = 0;
			}
			else
			{
				ReportProgress(P_4, 6, "正在写入 Word 单元格...", ref P_6, false);
				SyncOptions syncOptions = ((writePlan.ColumnShapeChanged && !P_2.SyncHeaders) ? new SyncOptions
				{
					SyncHeaders = true
				} : P_2);
				P_5 = (writePlan.UsesComplexComCellPlan ? WriteTableDataViaComDirect(P_1, excelStructure, array, range, syncOptions) : WriteTableDataViaCom(P_1, aiS98lViTM5QHeakGIJC2, excelStructure, array, range, num2, num3, syncOptions));
			}
			ReportProgress(P_4, 7, "正在应用绑定和合计格式...", ref P_6, false);
			BatchTableAdjustService.SyncTotalSubtotalFormat(P_1);
			AddTableBookmark(App.ActiveDocument, P_1, P_0);
			ClearTableBindings(App.ActiveDocument, P_0);
			ReportProgress(P_4, 8, "同步当前表完成。", ref P_6, false);
			return true;
		}
		catch (Exception ex)
		{
			P_8 = FormatErrorMessage("[ExcelSync] SyncOneBinding failed", ex, "同步失败，请检查 Word 表格结构和 Excel 绑定区域后重试。");
			return false;
		}
		finally
		{
			App.ScreenUpdating = screenUpdating;
			try
			{
				if (range != null)
				{
					Marshal.ReleaseComObject(range);
				}
			}
			catch
			{
			}
		}
	}

	private static bool ReportProgress(ProgressCallback P_0, int P_1, string P_2, ref bool P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			return true;
		}
		if (P_0(P_1, 8, P_2) || !P_4)
		{
			return true;
		}
		P_3 = true;
		return false;
	}

	private static WritePlan BuildWritePlan(ExcelTableStructure P_0, ExcelTableStructure P_1, int P_2, int P_3, bool P_4)
	{
		int num = CountMatchingColumns(P_0, P_1, P_2);
		int num2 = GetPinnedRowCount(P_3);
		if (AreStructuresCompatible(P_0, P_1))
		{
			return new WritePlan
			{
				ExecutorKind = (P_4 ? ((ExecutorKind)3) : ((ExecutorKind)2)),
				TargetRows = Math.Max(1, num),
				TargetColumns = Math.Max(1, num2),
				RowShapeChanged = (P_0 != null && P_0.RowCount != num),
				ColumnShapeChanged = (P_0 != null && P_0.ColumnCount != num2)
			};
		}
		bool rowShapeChanged = P_0 != null && P_0.RowCount != num;
		bool columnShapeChanged = P_0 != null && P_0.ColumnCount != num2;
		bool flag = CompareStructures(P_0, P_1);
		return new WritePlan
		{
			ExecutorKind = (flag ? ((ExecutorKind)1) : ((ExecutorKind)0)),
			TargetRows = Math.Max(1, num),
			TargetColumns = Math.Max(1, num2),
			RowShapeChanged = rowShapeChanged,
			ColumnShapeChanged = columnShapeChanged
		};
	}

	private static int CountMatchingColumns(ExcelTableStructure P_0, ExcelTableStructure P_1, int P_2)
	{
		int num = P_0?.HeaderRowCount ?? 0;
		int num2 = P_1?.HeaderRowCount ?? 0;
		if (num > 0 && num2 > 0)
		{
			return Math.Max(1, num + Math.Max(0, P_2 - num2));
		}
		return Math.Max(1, P_2);
	}

	private static int GetPinnedRowCount(int P_0)
	{
		return Math.Max(1, P_0);
	}

	private static int MapColumns(int P_0, ExcelTableStructure P_1, ExcelTableStructure P_2)
	{
		int num = P_1?.HeaderRowCount ?? 0;
		int num2 = P_2?.HeaderRowCount ?? 0;
		if (num <= 0 || num2 <= 0)
		{
			return P_0;
		}
		if (P_0 <= num2)
		{
			if (P_0 > Math.Max(1, num))
			{
				return 0;
			}
			return P_0;
		}
		return num + (P_0 - num2);
	}

	private static int WriteTableDataViaCom(Table P_0, ExcelTableStructure P_1, ExcelTableStructure P_2, string[,] P_3, Microsoft.Office.Interop.Excel.Range P_4, int P_5, int P_6, SyncOptions P_7)
	{
		P_7 = P_7 ?? GetDefaultSyncOptions();
		int num = 0;
		if (P_7.SyncHeaders)
		{
			num += WriteTableDataViaComFast(P_0, P_1, P_2, P_3, P_4);
		}
		for (int i = 1; i <= P_5; i++)
		{
			for (int j = 1; j <= P_6; j++)
			{
				string text = P_3[i, j] ?? string.Empty;
				if (P_2 != null && P_2.HasMergedCell(i, j))
				{
					continue;
				}
				int num2 = MapColumns(i, P_1, P_2);
				string text2;
				if (IsCellInStructure(i, num2, P_1, P_2))
				{
					if (P_7.SyncHeaders)
					{
					}
				}
				else if (!TryGetCellValue(P_1, num2, j, text, out text2))
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						num++;
					}
				}
				else if (!TrySetCellTextAt(P_0, num2, j, text, out text2) && !string.IsNullOrWhiteSpace(text))
				{
					num++;
				}
			}
		}
		return num;
	}

	private static int WriteTableDataViaComFast(Table P_0, ExcelTableStructure P_1, ExcelTableStructure P_2, string[,] P_3, Microsoft.Office.Interop.Excel.Range P_4)
	{
		if (!ValidateStructureCompatibility(P_1, P_2))
		{
			return 0;
		}
		List<ExcelCellData> list = P_1.GetHeaderCells().ToList();
		List<ExcelCellData> list2 = P_2.GetHeaderCells().ToList();
		Dictionary<string, Cell> dictionary = BuildCellDictionaryFromTable2(P_0, P_1.HeaderRowCount);
		List<Cell> list3 = GetCellsAboveRow(P_0, P_1.HeaderRowCount);
		bool flag = list3.Count == list.Count;
		int num = 0;
		for (int i = 0; i < list2.Count; i++)
		{
			ExcelCellData cellData = list[i];
			ExcelCellData oy5QGFVitTDJtPXLAlDX2 = list2[i];
			string text = P_3[oy5QGFVitTDJtPXLAlDX2.RowIndex, oy5QGFVitTDJtPXLAlDX2.ColumnIndex] ?? string.Empty;
			string key = BuildCellKey(cellData.RowIndex, cellData.ColumnIndex);
			if (!dictionary.TryGetValue(key, out var value))
			{
				value = ((flag && i < list3.Count) ? list3[i] : null);
			}
			string empty = string.Empty;
			bool num2 = value != null && TrySetCellText(value, text, out empty);
			if (value == null)
			{
				empty = "未找到对应的 Word 表头逻辑单元格";
			}
			if (!num2 && !string.IsNullOrWhiteSpace(text))
			{
				num++;
			}
		}
		return num;
	}

	private static bool ValidateStructureCompatibility(ExcelTableStructure P_0, ExcelTableStructure P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		if (P_0.HeaderRowCount <= 0 || P_1.HeaderRowCount <= 0)
		{
			return false;
		}
		if (P_0.HeaderRowCount != P_1.HeaderRowCount)
		{
			return false;
		}
		List<ExcelCellData> list = P_0.GetHeaderCells().ToList();
		List<ExcelCellData> list2 = P_1.GetHeaderCells().ToList();
		if (list.Count != list2.Count)
		{
			return false;
		}
		for (int i = 0; i < list.Count; i++)
		{
			ExcelCellData cellData = list[i];
			ExcelCellData oy5QGFVitTDJtPXLAlDX2 = list2[i];
			if (cellData.RowIndex != oy5QGFVitTDJtPXLAlDX2.RowIndex || cellData.ColumnIndex != oy5QGFVitTDJtPXLAlDX2.ColumnIndex || cellData.RowSpan != oy5QGFVitTDJtPXLAlDX2.RowSpan || cellData.ColumnSpan != oy5QGFVitTDJtPXLAlDX2.ColumnSpan)
			{
				return false;
			}
		}
		return true;
	}

	private static Dictionary<string, Cell> BuildCellDictionaryFromTable2(Table P_0, int P_1)
	{
		Dictionary<string, Cell> dictionary = new Dictionary<string, Cell>(StringComparer.Ordinal);
		try
		{
			foreach (Cell cell in P_0.Range.Cells)
			{
				if (TryGetCellPosition(cell, out var num, out var num2) && num > 0 && num <= P_1)
				{
					string key = BuildCellKey(num, num2);
					if (!dictionary.ContainsKey(key))
					{
						dictionary[key] = cell;
					}
				}
			}
		}
		catch
		{
		}
		return dictionary;
	}

	private static List<Cell> GetCellsAboveRow(Table P_0, int P_1)
	{
		List<Cell> list = new List<Cell>();
		try
		{
			foreach (Cell cell in P_0.Range.Cells)
			{
				if (!TryGetCellPosition(cell, out var num, out var _) || num <= P_1)
				{
					list.Add(cell);
					continue;
				}
				break;
			}
		}
		catch
		{
		}
		return list;
	}

	private static bool TryGetCellPosition(Cell P_0, out int P_1, out int P_2)
	{
		P_1 = 0;
		P_2 = 0;
		try
		{
			P_1 = P_0.RowIndex;
			P_2 = P_0.ColumnIndex;
			return P_1 > 0 && P_2 > 0;
		}
		catch
		{
			return false;
		}
	}

	private static bool IsCellInStructure(int P_0, int P_1, ExcelTableStructure P_2, ExcelTableStructure P_3)
	{
		int num = P_2?.HeaderRowCount ?? 0;
		int num2 = P_3?.HeaderRowCount ?? 0;
		if (num > 0 && num2 > 0 && P_0 <= num2)
		{
			return P_1 <= num;
		}
		return false;
	}

	private static bool TryGetCellValue(ExcelTableStructure P_0, int P_1, int P_2, string P_3, out string P_4)
	{
		P_4 = string.Empty;
		if (P_1 <= 0 || P_2 <= 0)
		{
			P_4 = "无法映射到 Word 目标行列";
			return false;
		}
		if (P_0 == null)
		{
			return true;
		}
		if (P_0.HasMergedCell(P_1, P_2))
		{
			P_4 = "目标坐标是 Word 合并区域内部占位";
			return false;
		}
		if (P_1 <= P_0.RowCount && P_2 <= P_0.ColumnCount && !P_0.HasCell(P_1, P_2))
		{
			P_4 = "目标坐标不是 Word 真实单元格起点";
			return false;
		}
		return true;
	}

	internal static bool GetSyncHeadersSetting()
	{
		return TableBorderConfig.Current.ReadConfigValue(delegate(AiHelper_12 config)
		{
			config.EnsureConfigLoaded();
			return config.ExcelSync.SyncHeaders;
		});
	}

	internal static void SetSyncHeadersSetting(bool P_0)
	{
		_G_c__DisplayClass202_0 CS_8_locals_2 = new _G_c__DisplayClass202_0();
		CS_8_locals_2.flag = P_0;
		TableBorderConfig.Current.UpdateConfig(delegate(AiHelper_12 config)
		{
			config.EnsureConfigLoaded();
			config.ExcelSync.SyncHeaders = CS_8_locals_2.flag;
		});
	}

	private static SyncOptions GetDefaultSyncOptions()
	{
		return new SyncOptions
		{
			SyncHeaders = GetSyncHeadersSetting()
		};
	}

	private static string FormatColumnLabel(string P_0, int P_1)
	{
		if (P_1 <= 0)
		{
			return P_0;
		}
		string arg = (P_0 ?? string.Empty).TrimEnd('。', '，', ',', '.');
		return string.Format("{0}，但有 {1} 个非空单元格因表格结构不一致未写入。请检查表头设置或重新绑定。", arg, P_1);
	}

	private static string BuildColumnConfigKey(string P_0, int P_1, string P_2)
	{
		string text = FormatColumnLabel(P_0, P_1);
		if (string.IsNullOrWhiteSpace(P_2))
		{
			return text;
		}
		return (text ?? string.Empty).TrimEnd('。', '，', ',', '.') + "；已跳过排序：" + P_2;
	}

	private static string GetBindingConfigKey(TableBinding P_0, string P_1)
	{
		string text = P_1 ?? string.Empty;
		string text2 = P_0?.ExcelName ?? string.Empty;
		if (text.IndexOf("未找到源 Excel 文件", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return "找不到绑定的 Excel 文件，请恢复文件路径或重新绑定当前表。";
		}
		if (text.IndexOf("未找到 Excel 名称区域", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("未找到名称区域", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			if (!string.IsNullOrWhiteSpace(text2))
			{
				return "Excel 中的绑定区域已丢失：" + text2 + "。请重新绑定当前表。";
			}
			return "Excel 中的绑定区域已丢失，请重新绑定当前表。";
		}
		if (text.IndexOf("未找到 Excel 工作表", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("工作表 XML 缺失", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return "绑定的 Excel 工作表不存在，可能已被重命名或删除。请重新绑定当前表。";
		}
		if (text.IndexOf("OpenXML", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf(".xlsx/.xlsm", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return "当前 Excel 文件无法直接读取。请打开该工作簿后再同步，或另存为 .xlsx/.xlsm 后重新绑定。";
		}
		if (text.IndexOf("名称区域不是可识别", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return "Excel 绑定区域不是标准矩形区域，请重新绑定当前表。";
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			return "读取 Excel 数据失败：" + text;
		}
		return "读取 Excel 数据失败，请检查绑定文件和名称区域。";
	}

	private static string SanitizeConfigKey(string P_0)
	{
		return "无法读取当前 Word 文档结构，请先保存文档后重试。";
	}

	private static string FormatErrorMessage(string P_0, Exception P_1, string P_2)
	{
		AiConfigBootstrap.LogError(P_0, P_1);
		return P_2;
	}

	private static string[,] SortTableData(TableBinding P_0, ExcelTableStructure P_1, string[,] P_2, out string P_3)
	{
		P_3 = string.Empty;
		if (P_0 == null || !P_0.SortEnabled || P_1 == null || P_2 == null)
		{
			return P_2;
		}
		int num = GetBindingHeaderRowCount(P_0);
		if (num < 1 || num > P_1.ColumnCount)
		{
			P_3 = string.Format("排序列超出 Excel 名称区域列数：第 {0} 列。", num);
			AiConfigBootstrap.LogWarn("[ExcelSync] Skip sort: " + P_3);
			return P_2;
		}
		int num2 = Math.Max(0, Math.Min(P_1.HeaderRowCount, P_1.RowCount));
		int num3 = num2 + 1;
		if (P_1.RowCount - num2 < 2)
		{
			return P_2;
		}
		if (IsSingleRowStructure(P_1, num2))
		{
			P_3 = "数据区存在合并单元格。";
			AiConfigBootstrap.LogWarn("[ExcelSync] Skip sort: " + P_3);
			return P_2;
		}
		int val = P_2.GetLength(0) - 1;
		int val2 = P_2.GetLength(1) - 1;
		int num4 = Math.Min(P_1.RowCount, val);
		int num5 = Math.Min(P_1.ColumnCount, val2);
		if (num > num5 || num4 - num2 < 2)
		{
			return P_2;
		}
		string[,] array = CloneStringGrid(P_2);
		bool flag = HasBindingSyncSettings(P_0);
		bool flag2 = HasBindingColumnMappings(P_0);
		List<SortKeyItem> list = new List<SortKeyItem>();
		int num6 = num3;
		int num7 = 0;
		for (int i = num3; i <= num4; i++)
		{
			if (IsOtherCategory(P_2, i, num5))
			{
				num6 = SortDataArray(P_2, array, list, num6, num5, flag);
				CopyDataRows(P_2, array, i, num6, num5);
				num6++;
				list.Clear();
			}
			else
			{
				list.Add(new SortKeyItem
				{
					RowIndex = i,
					OriginalOrder = num7++,
					Key = GetCellDisplayText(P_2, i, num),
					PinLast = (flag2 && IsOtherCategoryByIndex(P_2, i, num5))
				});
			}
		}
		SortDataArray(P_2, array, list, num6, num5, flag);
		return array;
	}

	private static bool IsSingleRowStructure(ExcelTableStructure P_0, int P_1)
	{
		_G_c__DisplayClass212_0 CS_8_locals_2 = new _G_c__DisplayClass212_0();
		CS_8_locals_2.value = P_1;
		return P_0.Merges.Any((ExcelMergeInfo merge) => merge.EndRow > CS_8_locals_2.value);
	}

	private static int GetBindingHeaderRowCount(TableBinding P_0)
	{
		int val = P_0?.SortColumnIndex ?? 2;
		return Math.Max(1, val);
	}

	private static bool HasBindingSyncSettings(TableBinding P_0)
	{
		return P_0?.SortDescending ?? true;
	}

	private static bool HasBindingColumnMappings(TableBinding P_0)
	{
		return P_0?.SortPinOtherLast ?? true;
	}

	private static int SortDataArray(string[,] P_0, string[,] P_1, List<SortKeyItem> P_2, int P_3, int P_4, bool P_5)
	{
		if (P_2 == null || P_2.Count == 0)
		{
			return P_3;
		}
		List<SortKeyItem> list = P_2.Where((SortKeyItem row) => !row.PinLast).ToList();
		List<SortKeyItem> second = P_2.Where((SortKeyItem row) => row.PinLast).ToList();
		ApplySortStability(list, P_5);
		foreach (SortKeyItem item in list.Concat(second))
		{
			CopyDataRows(P_0, P_1, item.RowIndex, P_3, P_4);
			P_3++;
		}
		return P_3;
	}

	private static void ApplySortStability(List<SortKeyItem> P_0, bool P_1)
	{
		_G_c__DisplayClass217_0 CS_8_locals_2 = new _G_c__DisplayClass217_0();
		CS_8_locals_2.flag = P_1;
		P_0.Sort(delegate(SortKeyItem left, SortKeyItem right)
		{
			int num = CompareWithPinnedLast(left.Key, right.Key, CS_8_locals_2.flag);
			return (num != 0) ? num : left.OriginalOrder.CompareTo(right.OriginalOrder);
		});
	}

	private static void CopyDataRows(string[,] P_0, string[,] P_1, int P_2, int P_3, int P_4)
	{
		for (int i = 1; i <= P_4; i++)
		{
			P_1[P_3, i] = GetCellDisplayText(P_0, P_2, i);
		}
	}

	private static bool IsOtherCategory(string[,] P_0, int P_1, int P_2)
	{
		string text = GetCellValueFromArray(P_0, P_1, P_2);
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		string text2 = NormalizeCategoryText(text);
		if (!(text2 == "合计") && !(text2 == "总计") && !(text2 == "小计") && !text2.EndsWith("合计", StringComparison.Ordinal))
		{
			return text2.EndsWith("小计", StringComparison.Ordinal);
		}
		return true;
	}

	private static bool IsOtherCategoryByIndex(string[,] P_0, int P_1, int P_2)
	{
		return NormalizeCategoryText(GetCellValueFromArray(P_0, P_1, P_2)) == "其他";
	}

	private static string GetCellValueFromArray(string[,] P_0, int P_1, int P_2)
	{
		for (int i = 1; i <= P_2; i++)
		{
			string text = GetCellDisplayText(P_0, P_1, i);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
		}
		return string.Empty;
	}

	private static string NormalizeCategoryText(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return string.Empty;
		}
		return P_0.Replace("\\r", string.Empty).Replace("\n", string.Empty).Replace("", string.Empty)
			.Replace(" ", string.Empty)
			.Replace("　", string.Empty)
			.Replace(":", string.Empty)
			.Replace("：", string.Empty)
			.Trim();
	}

	private static int CompareWithPinnedLast(string P_0, string P_1, bool P_2)
	{
		bool flag = string.IsNullOrWhiteSpace(P_0);
		bool flag2 = string.IsNullOrWhiteSpace(P_1);
		if (flag && flag2)
		{
			return 0;
		}
		if (flag)
		{
			return 1;
		}
		if (flag2)
		{
			return -1;
		}
		decimal num2;
		bool num = TryParseDecimal(P_0, out num2);
		decimal value;
		bool flag3 = TryParseDecimal(P_1, out value);
		if (num && flag3)
		{
			int num3 = num2.CompareTo(value);
			if (!P_2)
			{
				return num3;
			}
			return -num3;
		}
		int num4 = string.Compare(P_0, P_1, StringComparison.CurrentCultureIgnoreCase);
		if (!P_2)
		{
			return num4;
		}
		return -num4;
	}

	private static bool TryParseDecimal(string P_0, out decimal P_1)
	{
		P_1 = default(decimal);
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		string s = P_0.Trim().Replace(",", string.Empty).Replace("，", string.Empty)
			.Replace("￥", string.Empty)
			.Replace("¥", string.Empty);
		if (!decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out P_1))
		{
			return decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out P_1);
		}
		return true;
	}

	private static string[,] CloneStringGrid(string[,] P_0)
	{
		int length = P_0.GetLength(0);
		int length2 = P_0.GetLength(1);
		string[,] array = new string[length, length2];
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				array[i, j] = P_0[i, j];
			}
		}
		return array;
	}

	private static string GetCellDisplayText(string[,] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 < 0 || P_2 < 0 || P_1 >= P_0.GetLength(0) || P_2 >= P_0.GetLength(1))
		{
			return string.Empty;
		}
		return P_0[P_1, P_2] ?? string.Empty;
	}

	internal static TableSyncStatus GetTableSyncStatus(bool P_0 = false, bool P_1 = true)
	{
		TableSyncStatus gMo5J5VI9LOS3nqRiEJZ2 = new TableSyncStatus
		{
			WordStatus = "未定位 Word 表格",
			ExcelStatus = "未检测到 Excel 选区",
			Message = "请先把光标放到 Word 表格内。"
		};
		try
		{
			Table table = GetActiveTable();
			if (table != null)
			{
				gMo5J5VI9LOS3nqRiEJZ2.HasWordTable = true;
				int num = GetTableIndexInDocument(App.ActiveDocument, table);
				TryGetTableRowCount(table, out var num2);
				int num3 = GetTableColumnCount(table);
				gMo5J5VI9LOS3nqRiEJZ2.WordColumnCount = Math.Max(0, num3);
				gMo5J5VI9LOS3nqRiEJZ2.WordStatus = "已定位当前 Word 表格";
				gMo5J5VI9LOS3nqRiEJZ2.WordTableLabel = ((num > 0) ? string.Format("当前表格", num) : "第 {0} 张表");
				if (num2 > 0 || num3 > 0)
				{
					gMo5J5VI9LOS3nqRiEJZ2.WordTableLabel += string.Format("（{0} 行 x {1} 列）", num2, num3);
				}
				TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingForTable(table);
				if (lnEK8VVIccoSQf18k7Ih2 != null)
				{
					gMo5J5VI9LOS3nqRiEJZ2.HasBinding = true;
					gMo5J5VI9LOS3nqRiEJZ2.BindingId = lnEK8VVIccoSQf18k7Ih2.Id ?? string.Empty;
					gMo5J5VI9LOS3nqRiEJZ2.BoundWorkbook = lnEK8VVIccoSQf18k7Ih2.WorkbookName ?? string.Empty;
					gMo5J5VI9LOS3nqRiEJZ2.BoundFullPath = GetBindingExcelAddress(lnEK8VVIccoSQf18k7Ih2);
					gMo5J5VI9LOS3nqRiEJZ2.BoundSheet = lnEK8VVIccoSQf18k7Ih2.SheetName ?? string.Empty;
					gMo5J5VI9LOS3nqRiEJZ2.BoundExcelName = lnEK8VVIccoSQf18k7Ih2.ExcelName ?? string.Empty;
					gMo5J5VI9LOS3nqRiEJZ2.HeaderRowCount = lnEK8VVIccoSQf18k7Ih2.HeaderRowCount;
					gMo5J5VI9LOS3nqRiEJZ2.SortEnabled = lnEK8VVIccoSQf18k7Ih2.SortEnabled;
					gMo5J5VI9LOS3nqRiEJZ2.SortColumnIndex = lnEK8VVIccoSQf18k7Ih2.SortColumnIndex ?? 2;
					gMo5J5VI9LOS3nqRiEJZ2.SortDescending = lnEK8VVIccoSQf18k7Ih2.SortDescending ?? true;
					gMo5J5VI9LOS3nqRiEJZ2.SortPinOtherLast = HasBindingColumnMappings(lnEK8VVIccoSQf18k7Ih2);
					gMo5J5VI9LOS3nqRiEJZ2.ColumnMappings = BuildColumnMappings(lnEK8VVIccoSQf18k7Ih2, num3);
					gMo5J5VI9LOS3nqRiEJZ2.Message = "当前 Word 表格已经绑定，可重新绑定、解除绑定或同步。";
				}
				else
				{
					gMo5J5VI9LOS3nqRiEJZ2.ColumnMappings = BuildColumnMappings(null, num3);
					gMo5J5VI9LOS3nqRiEJZ2.Message = "当前 Word 表格尚未绑定，可选择 Excel 区域后执行绑定。";
				}
				if (P_0)
				{
					if (TryGetTableStructureFromWord(App.ActiveDocument, table, out var excelStructure, out var _))
					{
						if (lnEK8VVIccoSQf18k7Ih2 != null)
						{
							lnEK8VVIccoSQf18k7Ih2.HeaderRowCount = Math.Max(0, excelStructure.HeaderRowCount);
							RemoveTableBookmark(App.ActiveDocument, table, lnEK8VVIccoSQf18k7Ih2);
						}
						gMo5J5VI9LOS3nqRiEJZ2.HeaderRowCount = lnEK8VVIccoSQf18k7Ih2?.HeaderRowCount ?? Math.Max(0, excelStructure.HeaderRowCount);
						gMo5J5VI9LOS3nqRiEJZ2.HeaderSettingText = GetExcelSheetName(lnEK8VVIccoSQf18k7Ih2, excelStructure.HeaderRowCount);
					}
					else
					{
						gMo5J5VI9LOS3nqRiEJZ2.HeaderSettingText = ((lnEK8VVIccoSQf18k7Ih2 == null || !lnEK8VVIccoSQf18k7Ih2.HeaderRowCount.HasValue) ? "自动识别（当前未能读取 Word 表格结构）" : GetExcelSheetName(lnEK8VVIccoSQf18k7Ih2, null));
					}
				}
				else
				{
					gMo5J5VI9LOS3nqRiEJZ2.HeaderSettingText = GetExcelSheetName(lnEK8VVIccoSQf18k7Ih2, null);
				}
			}
		}
		catch (Exception ex)
		{
			gMo5J5VI9LOS3nqRiEJZ2.WordStatus = "读取 Word 表格失败";
			gMo5J5VI9LOS3nqRiEJZ2.Message = "读取当前 Word 表格失败，请重新点击表格后再试。";
			gMo5J5VI9LOS3nqRiEJZ2.TechnicalDetail = ex.Message;
		}
		if (P_1)
		{
			ApplySyncStatusToBinding(gMo5J5VI9LOS3nqRiEJZ2);
		}
		return gMo5J5VI9LOS3nqRiEJZ2;
	}

	private static void ApplySyncStatusToBinding(TableSyncStatus P_0)
	{
		try
		{
			Microsoft.Office.Interop.Excel.Application application = ExcelInteropService.GetActiveExcelApp();
			if (application == null)
			{
				P_0.ExcelStatus = "未检测到已打开的 Excel/WPS 表格";
				return;
			}
			if (!(application.Selection is Microsoft.Office.Interop.Excel.Range range))
			{
				P_0.ExcelStatus = "Excel 当前选区不是单元格区域";
				return;
			}
			Workbook activeWorkbook = application.ActiveWorkbook;
			P_0.HasExcelSelection = true;
			P_0.ExcelStatus = "已检测到 Excel 当前选区";
			P_0.ExcelWorkbook = ((activeWorkbook != null) ? Convert.ToString(activeWorkbook.Name) : string.Empty);
			P_0.ExcelFullPath = ((activeWorkbook != null) ? Convert.ToString(activeWorkbook.FullName) : string.Empty);
			P_0.ExcelSheet = Convert.ToString(range.Worksheet.Name);
			P_0.ExcelAddress = GetExcelRangeAddress(range);
			P_0.ExcelSize = string.Format("{0} 行 x {1} 列", range.Rows.Count, range.Columns.Count);
		}
		catch (Exception ex)
		{
			P_0.ExcelStatus = "读取 Excel 选区失败，请确认 Excel 已打开并选中了单元格区域。";
			P_0.TechnicalDetail = ex.Message;
		}
	}

	internal static SyncResult BindCurrentTable(bool P_0)
	{
		Table table = GetActiveTable();
		if (table == null)
		{
			return CreateSyncResult("请先将光标放在要绑定的 Word 表格内。", null, true);
		}
		try
		{
			TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingForTable(table);
			if (!PrepareTableForSync(table, lnEK8VVIccoSQf18k7Ih2, P_0, out var num, out var _, out var flag, out var text))
			{
				return CreateSyncResult(string.IsNullOrWhiteSpace(text) ? "绑定未完成，请检查 Word 表格和 Excel 选区。" : text, null, true);
			}
			string message = (flag ? FormatColumnLabel("绑定已保存，但首次同步未完成：", num) : (string.IsNullOrWhiteSpace(text) ? "绑定已保存，但首次同步未完成。请在同步区域重新执行同步。" : ("绑定完成，已创建 Excel 名称区域和 Word 书签。" + text)));
			return new SyncResult
			{
				Success = true,
				Bound = 1,
				SkippedCells = num,
				Message = message
			};
		}
		catch (Exception ex)
		{
			return CreateSyncResult(FormatErrorMessage("[ExcelSync] Bind current table failed", ex, "绑定未完成，请检查 Word 表格和 Excel 选区后重试。"), ex.Message, true);
		}
	}

	internal static SyncResult InsertExcelSelectionBelow()
	{
		if (GetActiveTable() != null)
		{
			return CreateSyncResult("当前光标已经在 Word 表格内；如需同步或绑定，请使用当前表主操作。", null, true);
		}
		Microsoft.Office.Interop.Excel.Application application = ExcelInteropService.GetActiveExcelApp();
		if (application == null)
		{
			return CreateSyncResult("未检测到已打开的 Excel/WPS 表格，请先在 Excel 中选择要插入的区域。", null, true);
		}
		if (!(application.Selection is Microsoft.Office.Interop.Excel.Range range))
		{
			return CreateSyncResult("Excel 当前选区不是单元格区域，请先选择要插入的单元格区域。", null, true);
		}
		try
		{
			int count = range.Rows.Count;
			int count2 = range.Columns.Count;
			if (count <= 0 || count2 <= 0)
			{
				return CreateSyncResult("Excel 当前选区为空，请重新选择要插入的单元格区域。", null, true);
			}
			string[,] array = BuildCellAddressGrid(range, count, count2);
			ExcelTableStructure excelStructure = ParseExcelRangeToStructure(range);
			string text;
			Table table = CreateWordTable(count, count2, out text);
			if (table == null)
			{
				return CreateSyncResult(string.IsNullOrWhiteSpace(text) ? "插入 Word 表格失败，请重新选择 Word 段落后再试。" : text, null, true);
			}
			int num = FillTableWithData(table, array, count, count2);
			ApplyStructureToTable(table, excelStructure);
			table.Range.Select();
			BatchTableAdjustService.AdjustTableLayout();
			table.Range.Select();
			if (!PrepareTableForSync(table, null, false, out var num2, out var _, out var flag, out var text2))
			{
				return CreateSyncResult(string.IsNullOrWhiteSpace(text2) ? "表格已插入，但自动绑定未完成：" : ("表格已插入，但自动绑定未完成。请确认 Excel 工作簿已保存后重新绑定。" + text2), null, true);
			}
			num += num2;
			string message = (flag ? FormatColumnLabel("已插入 Excel 选区并保存绑定，但首次同步未完成：", num) : (string.IsNullOrWhiteSpace(text2) ? "已插入 Excel 选区并保存绑定，但首次同步未完成。" : ("已插入 Excel 选区，并自动建立同步绑定。" + text2)));
			return new SyncResult
			{
				Success = true,
				Bound = 1,
				SkippedCells = num,
				Message = message
			};
		}
		catch (Exception ex)
		{
			return CreateSyncResult(FormatErrorMessage("[ExcelSync] Insert Excel selection below current paragraph failed", ex, "插入 Excel 选区失败，请确认 Word 段落和 Excel 选区有效后重试。"), ex.Message, true);
		}
	}

	private static Table CreateWordTable(int P_0, int P_1, out string P_2)
	{
		P_2 = string.Empty;
		try
		{
			Document activeDocument = App.ActiveDocument;
			Selection selection = App.Selection;
			if (activeDocument == null || selection == null)
			{
				P_2 = "请先在 Word 中选择一个段落位置。";
				return null;
			}
			Microsoft.Office.Interop.Word.Range duplicate = selection.Range.Duplicate;
			if (selection.Paragraphs.Count > 0)
			{
				duplicate = selection.Paragraphs[1].Range.Duplicate;
			}
			Microsoft.Office.Interop.Word.Range range = duplicate;
			object Direction = WdCollapseDirection.wdCollapseEnd;
			range.Collapse(ref Direction);
			Tables tables = activeDocument.Tables;
			Microsoft.Office.Interop.Word.Range range2 = duplicate;
			Direction = Type.Missing;
			object AutoFitBehavior = Type.Missing;
			return tables.Add(range2, P_0, P_1, ref Direction, ref AutoFitBehavior);
		}
		catch (Exception ex)
		{
			P_2 = "插入 Word 表格失败：" + ex.Message;
			return null;
		}
	}

	private static int FillTableWithData(Table P_0, string[,] P_1, int P_2, int P_3)
	{
		int num = 0;
		for (int i = 1; i <= P_2; i++)
		{
			for (int j = 1; j <= P_3; j++)
			{
				if (!TrySetCellTextAt(P_0, i, j, GetCellValueFromGrid(P_1, i, j), out var _))
				{
					num++;
				}
			}
		}
		return num;
	}

	private static void ApplyStructureToTable(Table P_0, ExcelTableStructure P_1)
	{
		if (P_0 == null || P_1?.Merges == null || P_1.Merges.Count == 0)
		{
			return;
		}
		foreach (ExcelMergeInfo item in from item in P_1.Merges
			orderby item.StartRow descending, item.StartColumn descending
			select item)
		{
			try
			{
				Cell cell = P_0.Cell(item.StartRow, item.StartColumn);
				Cell mergeTo = P_0.Cell(item.EndRow, item.EndColumn);
				cell.Merge(mergeTo);
			}
			catch
			{
			}
		}
	}

	internal static SyncResult SetCurrentTableHeader(int P_0)
	{
		return SaveHeaderSetting(P_0, null, null, null, null, null);
	}

	internal static SyncResult SplitCurrentTable()
	{
		Table table = GetActiveTable();
		if (table == null)
		{
			return CreateSyncResult("请先将光标放在要拆分的 Word 表格内。", null, true);
		}
		TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingForTable(table);
		if (lnEK8VVIccoSQf18k7Ih2 == null)
		{
			return CreateSyncResult("当前 Word 表格没有 Excel 同步绑定，请先绑定后再拆分。", null, true);
		}
		Document activeDocument = App.ActiveDocument;
		int num = GetTableIndexInDocument(activeDocument, table);
		if (num <= 0)
		{
			return CreateSyncResult("未能识别当前 Word 表格的位置，请重新选择表格后再试。", null, true);
		}
		if (string.IsNullOrWhiteSpace(lnEK8VVIccoSQf18k7Ih2.ExcelName))
		{
			return CreateSyncResult("当前表格的 Excel 名称区域无效，无法拆分。", null, true);
		}
		try
		{
			if (!TrySplitBoundTable(activeDocument, table, out var table2, out var text))
			{
				return CreateSyncResult(string.IsNullOrWhiteSpace(text) ? "复制当前 Word 表格失败，请重新选择表格后再试。" : text, null, true);
			}
			RemoveTableBookmarkByName(activeDocument, table, GetBookmarkIdFromBinding(lnEK8VVIccoSQf18k7Ih2));
			string text2 = GetDefaultExcelSheetName();
			TableBinding lnEK8VVIccoSQf18k7Ih3 = new TableBinding
			{
				Id = text2,
				ExcelFullPath = lnEK8VVIccoSQf18k7Ih2.ExcelFullPath,
				ExcelRelativePath = lnEK8VVIccoSQf18k7Ih2.ExcelRelativePath,
				WorkbookName = lnEK8VVIccoSQf18k7Ih2.WorkbookName,
				SheetName = lnEK8VVIccoSQf18k7Ih2.SheetName,
				ExcelName = lnEK8VVIccoSQf18k7Ih2.ExcelName,
				WordBookmark = text2,
				SyncMode = (string.IsNullOrWhiteSpace(lnEK8VVIccoSQf18k7Ih2.SyncMode) ? "DisplayText" : lnEK8VVIccoSQf18k7Ih2.SyncMode),
				HeaderRowCount = lnEK8VVIccoSQf18k7Ih2.HeaderRowCount,
				SortEnabled = lnEK8VVIccoSQf18k7Ih2.SortEnabled,
				SortColumnIndex = lnEK8VVIccoSQf18k7Ih2.SortColumnIndex,
				SortDescending = lnEK8VVIccoSQf18k7Ih2.SortDescending,
				SortPinOtherLast = lnEK8VVIccoSQf18k7Ih2.SortPinOtherLast,
				ColumnMappings = null,
				WordTableIsComplex = IsTableStructureValid(table2)
			};
			RemoveTableBookmark(activeDocument, table2, lnEK8VVIccoSQf18k7Ih3);
			try
			{
				table2.Range.Select();
				Microsoft.Office.Interop.Word.Window activeWindow = App.ActiveWindow;
				Microsoft.Office.Interop.Word.Range range = table2.Range;
				object Start = true;
				activeWindow.ScrollIntoView(range, ref Start);
			}
			catch
			{
			}
			return new SyncResult
			{
				Success = true,
				Bound = 1,
				Message = string.Format("已在第 {0} 表下方复制一张表，并绑定到同一个 Excel 来源；请分别删除两张 Word 表不需要的列，再设置列映射。", num)
			};
		}
		catch (Exception ex)
		{
			return CreateSyncResult(FormatErrorMessage("[ExcelSync] Split current bound table failed", ex, "拆分表失败，请重新选择 Word 表格后再试。"), ex.Message, true);
		}
	}

	private static bool TrySplitBoundTable(Document P_0, Table P_1, out Table P_2, out string P_3)
	{
		P_2 = null;
		P_3 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			P_3 = "复制表格参数不完整。";
			return false;
		}
		try
		{
			int num = GetTableIndexInDocument(P_0, P_1);
			int count = P_0.Tables.Count;
			if (num <= 0 || count <= 0)
			{
				P_3 = "未能识别当前 Word 表格的位置。";
				return false;
			}
			Microsoft.Office.Interop.Word.Range duplicate = P_1.Range.Duplicate;
			Microsoft.Office.Interop.Word.Range duplicate2 = P_1.Range.Duplicate;
			object Direction = WdCollapseDirection.wdCollapseEnd;
			duplicate2.Collapse(ref Direction);
			duplicate2.InsertParagraphAfter();
			Direction = WdCollapseDirection.wdCollapseEnd;
			duplicate2.Collapse(ref Direction);
			duplicate2.FormattedText = duplicate.FormattedText;
			if (P_0.Tables.Count <= count)
			{
				P_3 = "复制表格后未找到新增的 Word 表格。";
				return false;
			}
			int index = Math.Min(num + 1, P_0.Tables.Count);
			P_2 = P_0.Tables[index];
			if (P_2 == null || GetTableIndexInDocument(P_0, P_2) <= num)
			{
				P_2 = GetTableByIndex(P_0, duplicate.End);
			}
			if (P_2 == null)
			{
				P_3 = "复制表格后未能定位到新表格。";
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			P_3 = "复制 Word 表格失败：" + ex.Message;
			return false;
		}
	}

	private static Table GetTableByIndex(Document P_0, int P_1)
	{
		if (P_0 == null)
		{
			return null;
		}
		Table result = null;
		int num = int.MaxValue;
		try
		{
			for (int i = 1; i <= P_0.Tables.Count; i++)
			{
				Table table = P_0.Tables[i];
				int start = table.Range.Start;
				if (start >= P_1 && start < num)
				{
					result = table;
					num = start;
				}
			}
		}
		catch
		{
		}
		return result;
	}

	internal static SyncResult SaveHeaderSetting(int P_0, bool? P_1, int? P_2, bool? P_3, bool? P_4, IList<int> P_5)
	{
		Table table = GetActiveTable();
		if (table == null)
		{
			return CreateSyncResult("请先将光标放在要设置的 Word 表格内。", null, true);
		}
		TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingForTable(table);
		if (lnEK8VVIccoSQf18k7Ih2 == null)
		{
			return CreateSyncResult("当前 Word 表格没有 Excel 同步绑定，请先绑定后再设置表头。", null, true);
		}
		try
		{
			ApplyHeaderSettingsToBinding(lnEK8VVIccoSQf18k7Ih2, P_0, P_1, P_2, P_3, P_4, P_5);
			RemoveTableBookmark(App.ActiveDocument, table, lnEK8VVIccoSQf18k7Ih2);
			return new SyncResult
			{
				Success = true,
				Message = GetBindingDisplayLabel(lnEK8VVIccoSQf18k7Ih2)
			};
		}
		catch (Exception ex)
		{
			return CreateSyncResult(FormatErrorMessage("[ExcelSync] Save header setting failed", ex, "表头设置保存失败，请重新选择 Word 表格后再试。"), ex.Message, true);
		}
	}

	internal static SyncResult UnbindCurrentTable()
	{
		Table table = GetActiveTable();
		if (table == null)
		{
			return CreateSyncResult("请先将光标放在要解除绑定的 Word 表格内。", null, true);
		}
		TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingForTable(table);
		if (lnEK8VVIccoSQf18k7Ih2 == null)
		{
			return CreateSyncResult("当前 Word 表格没有 Excel 同步绑定。", null, true);
		}
		try
		{
			RemoveBindingFromDocument(App.ActiveDocument, lnEK8VVIccoSQf18k7Ih2);
			return new SyncResult
			{
				Success = true,
				Message = "已解除当前 Word 表格的绑定。"
			};
		}
		catch (Exception ex)
		{
			return CreateSyncResult(FormatErrorMessage("[ExcelSync] Unbind current table failed", ex, "解除绑定失败，请重新选择 Word 表格后再试。"), ex.Message, true);
		}
	}

	internal static SyncResult SyncCurrentTableShortcut()
	{
		return SyncCurrentTable(null);
	}

	internal static SyncResult SyncTableByLabel(string P_0, int P_1)
	{
		return SyncTableByLabelWithOptions(P_0, P_1, null, null, null, null, null);
	}

	internal static SyncResult SyncTableByLabelWithOptions(string P_0, int P_1, bool? P_2, int? P_3, bool? P_4, bool? P_5, IList<int> P_6)
	{
		_G_c__DisplayClass243_0 CS_8_locals_3 = new _G_c__DisplayClass243_0();
		CS_8_locals_3.text = P_0;
		if (string.IsNullOrWhiteSpace(CS_8_locals_3.text))
		{
			return CreateSyncResult("请先在左侧选择一张已绑定表。", null, true);
		}
		Document activeDocument = App.ActiveDocument;
		TableBinding lnEK8VVIccoSQf18k7Ih2 = GetBindingsFromDocument(activeDocument).FirstOrDefault((TableBinding item) => item != null && string.Equals(item.Id, CS_8_locals_3.text, StringComparison.OrdinalIgnoreCase));
		if (lnEK8VVIccoSQf18k7Ih2 == null)
		{
			return CreateSyncResult("未找到选中表的绑定信息，请刷新绑定信息后重试。", null, true);
		}
		try
		{
			ApplyHeaderSettingsToBinding(lnEK8VVIccoSQf18k7Ih2, P_1, P_2, P_3, P_4, P_5, P_6);
			ClearTableBindings(activeDocument, lnEK8VVIccoSQf18k7Ih2);
			return new SyncResult
			{
				Success = true,
				Message = GetBindingDisplayLabel(lnEK8VVIccoSQf18k7Ih2)
			};
		}
		catch (Exception ex)
		{
			return CreateSyncResult(FormatErrorMessage("[ExcelSync] Save binding header setting failed", ex, "表格配置保存失败，请刷新绑定信息后再试。"), ex.Message, true);
		}
	}

	private static void ApplyHeaderSettingsToBinding(TableBinding P_0, int P_1, bool? P_2, int? P_3, bool? P_4, bool? P_5, IList<int> P_6)
	{
		if (P_0 != null)
		{
			P_0.HeaderRowCount = Math.Max(0, P_1);
			if (P_2.HasValue)
			{
				P_0.SortEnabled = P_2.Value;
			}
			if (P_3.HasValue)
			{
				P_0.SortColumnIndex = Math.Max(1, P_3.Value);
			}
			if (P_4.HasValue)
			{
				P_0.SortDescending = P_4.Value;
			}
			if (P_5.HasValue)
			{
				P_0.SortPinOtherLast = P_5.Value;
			}
			if (P_6 != null)
			{
				P_0.ColumnMappings = FilterPositiveInts(P_6);
			}
		}
	}

	private static string GetBindingDisplayLabel(TableBinding P_0)
	{
		int num = Math.Max(0, (P_0?.HeaderRowCount).GetValueOrDefault());
		string text = ((P_0?.ColumnMappings != null && P_0.ColumnMappings.Count > 0) ? string.Format("，列映射 {0} 列", P_0.ColumnMappings.Count) : string.Empty);
		if (P_0 == null || !P_0.SortEnabled)
		{
			return string.Format("已保存表格配置：表头 {0} 行，未启用排序{1}。", num, text);
		}
		int num2 = GetBindingHeaderRowCount(P_0);
		string text2 = (HasBindingSyncSettings(P_0) ? "升序" : "降序");
		string text3 = (HasBindingColumnMappings(P_0) ? "，其他项置底" : string.Empty);
		return string.Format("已保存表格配置：表头 {0} 行，按第 {1} 列{2}排序{3}{4}。", num, num2, text2, text3, text);
	}

	internal static SyncResult SyncCurrentTable(ProgressCallback P_0)
	{
		bool flag = false;
		if (!ReportProgress(P_0, 0, "正在定位当前 Word 表格...", ref flag))
		{
			return CreateCancelledResult("已取消同步当前表。");
		}
		Table table = GetActiveTable();
		if (table == null)
		{
			return CreateSyncResult("请先将光标放在已绑定的 Word 表格内。", null, true);
		}
		if (!ReportProgress(P_0, 1, "正在读取当前表绑定信息...", ref flag))
		{
			return CreateCancelledResult("已取消同步当前表。");
		}
		TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingForTable(table);
		if (lnEK8VVIccoSQf18k7Ih2 == null)
		{
			return CreateSyncResult("当前表格未绑定 Excel 区域，请先执行绑定。", null, true);
		}
		int num;
		string text;
		string text2;
		bool flag2 = SyncTableCore(lnEK8VVIccoSQf18k7Ih2, table, GetDefaultSyncOptions(), null, P_0, out num, out flag, out text, out text2);
		return new SyncResult
		{
			Success = flag2,
			Cancelled = flag,
			RequiresUserAction = (!flag2 && !flag && !string.IsNullOrWhiteSpace(text2)),
			Synced = (flag2 ? 1 : 0),
			SkippedCells = num,
			Message = (flag ? "同步当前表未完成。" : (flag2 ? BuildColumnConfigKey("同步当前表完成。", num, text) : (string.IsNullOrWhiteSpace(text2) ? "已取消同步当前表。" : text2)))
		};
	}

	internal static SyncResult GetCurrentTableSyncStatus()
	{
		Table table = GetActiveTable();
		if (table == null)
		{
			return CreateSyncResult("请先将光标放在已绑定的 Word 表格内。", null, true);
		}
		TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingForTable(table);
		if (lnEK8VVIccoSQf18k7Ih2 == null)
		{
			return CreateSyncResult("当前表格未绑定 Excel 区域，请先执行绑定。", null, true);
		}
		string text;
		bool flag2;
		bool flag = ValidateBindingSyncInternal(new TableBindingStatus
		{
			Binding = lnEK8VVIccoSQf18k7Ih2,
			BindingId = (lnEK8VVIccoSQf18k7Ih2.Id ?? string.Empty),
			ExcelFullPath = (lnEK8VVIccoSQf18k7Ih2.ExcelFullPath ?? string.Empty),
			ResolvedExcelPath = GetBindingExcelAddress(lnEK8VVIccoSQf18k7Ih2),
			ExcelName = (lnEK8VVIccoSQf18k7Ih2.ExcelName ?? string.Empty)
		}, out text, out flag2);
		return new SyncResult
		{
			Success = flag,
			RequiresUserAction = (!flag && flag2),
			Message = (flag ? "未能定位到绑定的 Excel 区域。" : (string.IsNullOrWhiteSpace(text) ? "已定位到绑定的 Excel 区域。" : text))
		};
	}

	internal static SyncResult SyncAllTablesWithOptions(ProgressCallback P_0)
	{
		return SyncAllTablesViaXml(P_0, GetDefaultSyncOptions());
	}

	private static SyncResult CreateSyncResult(string P_0, string P_1 = null, bool P_2 = false)
	{
		return new SyncResult
		{
			Success = false,
			Message = (string.IsNullOrWhiteSpace(P_0) ? "操作未完成。" : P_0),
			TechnicalDetail = P_1,
			RequiresUserAction = P_2
		};
	}

	private static SyncResult CreateCancelledResult(string P_0)
	{
		return new SyncResult
		{
			Success = false,
			Cancelled = true,
			Message = (string.IsNullOrWhiteSpace(P_0) ? "已取消操作。" : P_0)
		};
	}

	private static void RemoveTableBookmark(Document P_0, Table P_1, TableBinding P_2)
	{
		AddTableBookmarkByName(P_0, P_1, P_2.Id);
		AddTableBookmark(P_0, P_1, P_2);
		ClearTableBindings(P_0, P_2);
		RemoveTableBookmarkByName(P_0, P_1, P_2.WordBookmark);
	}

	private static void RemoveTableBookmarkByName(Document P_0, Table P_1, string P_2)
	{
		object Index;
		try
		{
			if (P_0.Bookmarks.Exists(P_2))
			{
				Bookmarks bookmarks = P_0.Bookmarks;
				Index = P_2;
				bookmarks[ref Index].Delete();
			}
		}
		catch
		{
		}
		Microsoft.Office.Interop.Word.Range duplicate = P_1.Range.Duplicate;
		Bookmarks bookmarks2 = P_0.Bookmarks;
		Index = duplicate;
		bookmarks2.Add(P_2, ref Index);
	}

	private static void ClearTableBindings(Document P_0, TableBinding P_1)
	{
		string text = JsonConvert.SerializeObject(P_1);
		dynamic variables = P_0.Variables;
		try
		{
			if (_G_o__253.toStringCallSite_Tc18 == null)
			{
				_G_o__253.toStringCallSite_Tc18 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Value", typeof(TableComWriteService), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			_G_o__253.toStringCallSite_Tc18.Target(_G_o__253.toStringCallSite_Tc18, (object)variables[P_1.Id], text);
		}
		catch
		{
			try
			{
				if (_G_o__253.addCallSite == null)
				{
					_G_o__253.addCallSite = CallSite<Action<CallSite, object, string, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", null, typeof(TableComWriteService), new CSharpArgumentInfo[3]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				_G_o__253.addCallSite.Target(_G_o__253.addCallSite, (object)variables, P_1.Id, text);
			}
			catch
			{
			}
		}
	}

	private static void AddTableBookmark(Document P_0, Table P_1, TableBinding P_2)
	{
		if (P_0 == null || P_1 == null || P_2 == null)
		{
			return;
		}
		try
		{
			P_2.WordTableIndex = GetTableIndexInDocument(P_0, P_1);
			P_2.WordTableRows = ((TryGetTableRowCount(P_1, out var num) && num > 0) ? new int?(num) : ((int?)null));
			int num2 = GetTableColumnCount(P_1);
			P_2.WordTableColumns = ((num2 > 0) ? new int?(num2) : ((int?)null));
			P_2.WordSnapshotUpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
		catch
		{
		}
	}

	private static void AddTableBookmarkByName(Document P_0, Table P_1, string P_2)
	{
		try
		{
			for (int num = P_0.Variables.Count; num >= 1; num--)
			{
				Variables variables = P_0.Variables;
				object Index = num;
				Variable variable = variables[ref Index];
				string text = Convert.ToString(variable.Name);
				if (IsValidBookmarkId(text) && !string.Equals(text, P_2, StringComparison.OrdinalIgnoreCase))
				{
					TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingById(Convert.ToString(variable.Value));
					if (lnEK8VVIccoSQf18k7Ih2 != null && TryUpdateTableRangeById(P_0, lnEK8VVIccoSQf18k7Ih2.WordBookmark) && TryUpdateTableRange(P_0, lnEK8VVIccoSQf18k7Ih2.WordBookmark, P_1))
					{
						UpdateTableRange(P_0, lnEK8VVIccoSQf18k7Ih2.WordBookmark);
						RemoveAllBindingsFromRange(P_0, text);
					}
				}
			}
		}
		catch
		{
		}
	}

	private static TableBinding FindBindingForTable(Table P_0)
	{
		return FindBindingForTableInternal(P_0);
	}

	private static TableBinding FindBindingForTableInternal(Table P_0)
	{
		try
		{
			Document document = P_0.Range.Document;
			for (int i = 1; i <= document.Variables.Count; i++)
			{
				Variables variables = document.Variables;
				object Index = i;
				Variable variable = variables[ref Index];
				if (IsValidBookmarkId(Convert.ToString(variable.Name)))
				{
					TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingById(Convert.ToString(variable.Value));
					if (lnEK8VVIccoSQf18k7Ih2 != null && TryUpdateTableRange(document, lnEK8VVIccoSQf18k7Ih2.WordBookmark, P_0))
					{
						return lnEK8VVIccoSQf18k7Ih2;
					}
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static TableBinding FindBindingById(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return null;
		}
		try
		{
			TableBinding lnEK8VVIccoSQf18k7Ih2 = JsonConvert.DeserializeObject<TableBinding>(P_0);
			if (lnEK8VVIccoSQf18k7Ih2 == null || !IsValidBookmarkId(lnEK8VVIccoSQf18k7Ih2.Id))
			{
				return null;
			}
			if (string.IsNullOrWhiteSpace(lnEK8VVIccoSQf18k7Ih2.WordBookmark))
			{
				lnEK8VVIccoSQf18k7Ih2.WordBookmark = lnEK8VVIccoSQf18k7Ih2.Id;
			}
			if (string.IsNullOrWhiteSpace(lnEK8VVIccoSQf18k7Ih2.ExcelName))
			{
				lnEK8VVIccoSQf18k7Ih2.ExcelName = lnEK8VVIccoSQf18k7Ih2.Id;
			}
			SaveBindingToDocument(lnEK8VVIccoSQf18k7Ih2, P_0);
			return lnEK8VVIccoSQf18k7Ih2;
		}
		catch
		{
			return null;
		}
	}

	private static void SaveBindingToDocument(TableBinding P_0, string P_1)
	{
		if (P_0 == null || P_0.HeaderRowCount.HasValue || string.IsNullOrWhiteSpace(P_1))
		{
			return;
		}
		try
		{
			JObject jObject = JObject.Parse(P_1);
			int? num = GetJObjectInt(jObject, "HeaderRowCountOverride");
			int? num2 = GetJObjectInt(jObject, "DetectedHeaderRowCount");
			int? num3 = num ?? num2;
			if (num3.HasValue)
			{
				P_0.HeaderRowCount = Math.Max(0, num3.Value);
			}
		}
		catch
		{
		}
	}

	private static int? GetJObjectInt(JObject P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		JToken jToken = P_0[P_1];
		if (jToken == null || jToken.Type == JTokenType.Null)
		{
			return null;
		}
		if (int.TryParse(Convert.ToString(jToken), out var result))
		{
			return result;
		}
		return null;
	}

	private static bool TryUpdateTableRange(Document P_0, string P_1, Table P_2)
	{
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		try
		{
			if (!P_0.Bookmarks.Exists(P_1))
			{
				return false;
			}
			Bookmarks bookmarks = P_0.Bookmarks;
			object Index = P_1;
			Microsoft.Office.Interop.Word.Range range = bookmarks[ref Index].Range;
			Microsoft.Office.Interop.Word.Range range2 = P_2.Range;
			return range.Start <= range2.End && range.End >= range2.Start;
		}
		catch
		{
			return false;
		}
	}

	private static bool TryUpdateTableRangeById(Document P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		try
		{
			return P_0.Bookmarks.Exists(P_1);
		}
		catch
		{
			return false;
		}
	}

	private static void UpdateTableRange(Document P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return;
		}
		try
		{
			if (P_0.Bookmarks.Exists(P_1))
			{
				Bookmarks bookmarks = P_0.Bookmarks;
				object Index = P_1;
				bookmarks[ref Index].Delete();
			}
		}
		catch
		{
		}
	}

	private static void RemoveBindingFromDocument(Document P_0, TableBinding P_1)
	{
		if (P_1 != null)
		{
			UpdateTableRange(P_0, P_1.WordBookmark);
			RemoveAllBindingsFromRange(P_0, P_1.Id);
		}
	}

	private static void RemoveAllBindingsFromRange(Document P_0, string P_1)
	{
		if (P_0 == null || !IsValidBookmarkId(P_1))
		{
			return;
		}
		try
		{
			dynamic variables = P_0.Variables;
			if (_G_o__265.deleteCallSite_Tc3 == null)
			{
				_G_o__265.deleteCallSite_Tc3 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Delete", null, typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			_G_o__265.deleteCallSite_Tc3.Target(_G_o__265.deleteCallSite_Tc3, (object)variables[P_1]);
			return;
		}
		catch
		{
		}
		try
		{
			for (int num = P_0.Variables.Count; num >= 1; num--)
			{
				Variables variables2 = P_0.Variables;
				object Index = num;
				Variable variable = variables2[ref Index];
				if (string.Equals(Convert.ToString(variable.Name), P_1, StringComparison.OrdinalIgnoreCase))
				{
					try
					{
						variable.Delete();
						break;
					}
					catch
					{
						break;
					}
				}
			}
		}
		catch
		{
		}
	}

	private static string GetTableBookmarkXml(Document P_0, string P_1)
	{
		try
		{
			string path = P_0.Path;
			if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(P_1))
			{
				return string.Empty;
			}
			Uri uri = new Uri(DecodeBookmarkId(path));
			Uri uri2 = new Uri(P_1);
			return Uri.UnescapeDataString(uri.MakeRelativeUri(uri2).ToString()).Replace('/', Path.DirectorySeparatorChar);
		}
		catch
		{
			return string.Empty;
		}
	}

	private static string DecodeBookmarkId(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return P_0;
		}
		if (!P_0.EndsWith(Path.DirectorySeparatorChar.ToString()))
		{
			return P_0 + Path.DirectorySeparatorChar;
		}
		return P_0;
	}

	private static bool IsValidBookmarkId(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			return P_0.StartsWith("IPA_", StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	private static bool TryGetTableStructureFromWord(Document P_0, Table P_1, out ExcelTableStructure P_2, out string P_3)
	{
		P_2 = null;
		P_3 = string.Empty;
		try
		{
			int num = GetTableIndexInDocument(P_0, P_1);
			if (num <= 0)
			{
				P_3 = "无法确认当前 Word 表格序号";
				return false;
			}
			string text = Convert.ToString(P_0.Content.WordOpenXML);
			if (string.IsNullOrWhiteSpace(text))
			{
				P_3 = "WordOpenXML为空";
				return false;
			}
			XDocument xDocument = CloneDocumentXml(XDocument.Parse(text), "/word/document.xml");
			if (xDocument?.Root == null)
			{
				P_3 = "word/document.xml缺失";
				return false;
			}
			XElement xElement = xDocument.Descendants(WordNamespace + "tbl").Skip(num - 1).FirstOrDefault();
			if (xElement == null)
			{
				P_3 = "WordOpenXML中未找到对应表格";
				return false;
			}
			P_2 = ParseTableElementToStructure(xElement, num);
			return true;
		}
		catch (Exception ex)
		{
			P_3 = ex.Message;
			return false;
		}
	}

	private static bool TryBuildExcelStructureForSync(Document P_0, Table P_1, TableBinding P_2, FastStructureCache P_3, out ExcelTableStructure P_4, out StructureValidationKind P_5, out string P_6)
	{
		P_4 = null;
		P_5 = (StructureValidationKind)2;
		P_6 = string.Empty;
		int num = GetTableIndexInDocument(P_0, P_1);
		if (num <= 0)
		{
			P_6 = "无法确认当前 Word 表格序号";
			return false;
		}
		if (P_3 != null && P_3.FastStructuresByTableIndex.TryGetValue(num, out P_4))
		{
			P_5 = (StructureValidationKind)0;
			return true;
		}
		if (P_2 != null && P_2.WordTableIsComplex == false && TryGetExcelStructureFromTableByHeader(P_1, P_2, num, out P_4, out var text))
		{
			P_5 = (StructureValidationKind)0;
			return true;
		}
		if (TryGetExcelStructureFromTable(P_1, P_2, num, out P_4, out text))
		{
			P_5 = (StructureValidationKind)0;
			return true;
		}
		if (P_3?.Snapshot != null && P_3.Snapshot.StructuresByTableIndex.TryGetValue(num, out P_4))
		{
			P_5 = (StructureValidationKind)1;
			return true;
		}
		if (P_3 != null && P_3.SnapshotAttempted)
		{
			P_6 = (string.IsNullOrWhiteSpace(P_3.SnapshotError) ? "批量 WordOpenXML 快照不可用" : P_3.SnapshotError);
			if (!string.IsNullOrWhiteSpace(text))
			{
				P_6 = P_6 + "；COM快速结构：" + text;
			}
			return false;
		}
		if (TryGetStructureByTableIndex(P_0, num, out P_4, out P_6))
		{
			P_5 = (StructureValidationKind)2;
			return true;
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			P_6 = (string.IsNullOrWhiteSpace(P_6) ? text : (P_6 + "；COM快速结构：" + text));
		}
		return false;
	}

	private static bool TryGetExcelStructureFromTable(Table P_0, TableBinding P_1, int P_2, out ExcelTableStructure P_3, out string P_4)
	{
		P_3 = null;
		P_4 = string.Empty;
		try
		{
			if (!TryGetTableDimensions(P_0, out var num, out var num2, out P_4))
			{
				return false;
			}
			if ((!IsTableEmpty(P_0) || GetTableRowCount(P_0) != num * num2) && !TryGetCellText(P_0, num, num2, out P_4))
			{
				return false;
			}
			P_3 = BuildExcelStructureFromTable(P_0, P_1, P_2, num, num2);
			return true;
		}
		catch (Exception ex)
		{
			P_4 = ex.Message;
			P_3 = null;
			return false;
		}
	}

	private static bool TryGetExcelStructureFromTableByHeader(Table P_0, TableBinding P_1, int P_2, out ExcelTableStructure P_3, out string P_4)
	{
		P_3 = null;
		if (!TryGetTableDimensions(P_0, out var num, out var num2, out P_4))
		{
			return false;
		}
		P_3 = BuildExcelStructureFromTable(P_0, P_1, P_2, num, num2);
		return true;
	}

	private static bool TryGetTableDimensions(Table P_0, out int P_1, out int P_2, out string P_3)
	{
		P_1 = 0;
		P_2 = 0;
		P_3 = string.Empty;
		if (!TryGetTableRowCount(P_0, out P_1) || P_1 <= 0)
		{
			P_3 = "无法读取 Word 表格行数";
			return false;
		}
		P_2 = GetTableColumnCount(P_0);
		if (P_2 <= 0)
		{
			P_3 = "无法读取 Word 表格列数";
			return false;
		}
		return true;
	}

	private static ExcelTableStructure BuildExcelStructureFromTable(Table P_0, TableBinding P_1, int P_2, int P_3, int P_4)
	{
		ExcelTableStructure excelStructure = new ExcelTableStructure
		{
			SourceKind = (TableSourceKind)0,
			TableIndex = P_2,
			RowCount = P_3,
			ColumnCount = P_4,
			HeaderRowCount = Math.Min(Math.Max(0, P_1?.HeaderRowCount ?? 1), P_3),
			HasVerticalMerge = false
		};
		for (int i = 1; i <= P_3; i++)
		{
			for (int j = 1; j <= P_4; j++)
			{
				excelStructure.AddCell(new ExcelCellData
				{
					RowIndex = i,
					ColumnIndex = j,
					RowSpan = 1,
					ColumnSpan = 1,
					Text = ((i == P_3) ? GetCellText(P_0, i, j) : string.Empty)
				});
			}
		}
		return excelStructure;
	}

	private static bool? IsTableStructureValid(Table P_0)
	{
		try
		{
			if (!TryGetTableDimensions(P_0, out var num, out var num2, out var text))
			{
				return null;
			}
			if (IsTableEmpty(P_0) && GetTableRowCount(P_0) == num * num2)
			{
				return false;
			}
			if (TryGetCellText(P_0, num, num2, out text))
			{
				return false;
			}
		}
		catch
		{
		}
		return null;
	}

	private static void ApplyBindingToStructure(TableBinding P_0, ExcelTableStructure P_1)
	{
		if (P_0 != null && P_1 != null)
		{
			P_0.WordTableIsComplex = P_1.HasVerticalMerge || P_1.Merges.Count > 0;
		}
	}

	private static bool TryGetTableStructureSnapshot(Document P_0, out TableStructureSnapshot P_1, out string P_2)
	{
		bool flag;
		return TryGetTableStructureSnapshotWithProgress(P_0, null, out P_1, out P_2, out flag);
	}

	private static bool TryGetTableStructureSnapshotWithProgress(Document P_0, ProgressCallback P_1, out TableStructureSnapshot P_2, out string P_3, out bool P_4)
	{
		P_2 = null;
		P_3 = string.Empty;
		P_4 = false;
		try
		{
			if (!ShouldCancelSync(P_1, "正在读取 Word 文档 XML 结构..."))
			{
				P_4 = true;
				return false;
			}
			if (!TryGetDocumentXml(P_0, out var xDocument, out P_3))
			{
				return false;
			}
			P_2 = new TableStructureSnapshot();
			List<XElement> list = xDocument.Descendants(WordNamespace + "tbl").ToList();
			for (int i = 0; i < list.Count; i++)
			{
				int num = i + 1;
				if (P_1 != null && !P_1(num, list.Count, string.Format("正在解析 Word 表格结构：{0} / {1}", num, list.Count)))
				{
					P_4 = true;
					return false;
				}
				P_2.StructuresByTableIndex[num] = ParseTableElementToStructure(list[i], num);
			}
			return true;
		}
		catch (Exception ex)
		{
			P_3 = ex.Message;
			return false;
		}
	}

	private static bool TryGetStructureByTableIndex(Document P_0, int P_1, out ExcelTableStructure P_2, out string P_3)
	{
		P_2 = null;
		P_3 = string.Empty;
		try
		{
			if (!TryGetDocumentXml(P_0, out var xDocument, out P_3))
			{
				return false;
			}
			XElement xElement = xDocument.Descendants(WordNamespace + "tbl").Skip(P_1 - 1).FirstOrDefault();
			if (xElement == null)
			{
				P_3 = "WordOpenXML中未找到对应表格";
				return false;
			}
			P_2 = ParseTableElementToStructure(xElement, P_1);
			return true;
		}
		catch (Exception ex)
		{
			P_3 = ex.Message;
			return false;
		}
	}

	private static bool TryGetDocumentXml(Document P_0, out XDocument P_1, out string P_2)
	{
		P_1 = null;
		P_2 = string.Empty;
		string text = Convert.ToString(P_0.Content.WordOpenXML);
		if (string.IsNullOrWhiteSpace(text))
		{
			P_2 = "WordOpenXML为空";
			return false;
		}
		XDocument xDocument = XDocument.Parse(text);
		P_1 = CloneDocumentXml(xDocument, "/word/document.xml");
		if (P_1?.Root == null)
		{
			P_2 = "word/document.xml缺失";
			return false;
		}
		return true;
	}

	private static bool IsTableEmpty(Table P_0)
	{
		try
		{
			if (_G_o__284.toBooleanCallSite_Tc2 == null)
			{
				_G_o__284.toBooleanCallSite_Tc2 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToBoolean", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, Type, object, object> target = _G_o__284.toBooleanCallSite_Tc2.Target;
			CallSite<Func<CallSite, Type, object, object>> uCNV31Pb74x = _G_o__284.toBooleanCallSite_Tc2;
			Type typeFromHandle = typeof(Convert);
			if (_G_o__284.toObjectCallSite_Tc18 == null)
			{
				_G_o__284.toObjectCallSite_Tc18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Uniform", typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			return (dynamic)target(uCNV31Pb74x, typeFromHandle, _G_o__284.toObjectCallSite_Tc18.Target(_G_o__284.toObjectCallSite_Tc18, P_0));
		}
		catch
		{
			return true;
		}
	}

	private static int GetTableRowCount(Table P_0)
	{
		try
		{
			return P_0.Range.Cells.Count;
		}
		catch
		{
			return 0;
		}
	}

	private static bool TryGetCellText(Table P_0, int P_1, int P_2, out string P_3)
	{
		P_3 = string.Empty;
		HashSet<string> hashSet = new HashSet<string>(StringComparer.Ordinal);
		try
		{
			for (int i = 1; i <= P_1; i++)
			{
				for (int j = 1; j <= P_2; j++)
				{
					Microsoft.Office.Interop.Word.Range range = P_0.Cell(i, j).Range;
					string item = range.Start + ":" + range.End;
					if (!hashSet.Add(item))
					{
						P_3 = string.Format("Word 表格坐标 R{0}C{1} 指向重复单元格，可能存在合并单元格", i, j);
						return false;
					}
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			P_3 = "Word 表格坐标不可完整访问：" + ex.Message;
			return false;
		}
	}

	private static string GetCellText(Table P_0, int P_1, int P_2)
	{
		try
		{
			return CleanCellText(P_0.Cell(P_1, P_2).Range.Text).Trim();
		}
		catch
		{
			return string.Empty;
		}
	}

	private static ExcelTableStructure ParseTableElementToStructure(XElement P_0, int P_1)
	{
		ExcelTableStructure excelStructure = new ExcelTableStructure
		{
			SourceKind = (TableSourceKind)0,
			TableIndex = P_1,
			TableElement = new XElement(P_0)
		};
		Dictionary<int, ExcelCellData> dictionary = new Dictionary<int, ExcelCellData>();
		int num = 0;
		foreach (XElement item in P_0.Elements(WordNamespace + "tr"))
		{
			num++;
			excelStructure.RowElements.Add(new XElement(item));
			int num2 = 1;
			HashSet<ExcelCellData> hashSet = new HashSet<ExcelCellData>();
			foreach (XElement item2 in item.Elements(WordNamespace + "tc"))
			{
				int num3 = GetTableColumnCountFromXml(item2);
				string text = GetTableStyleVal(item2);
				bool flag = text != null;
				if (flag && !string.Equals(text, "restart", StringComparison.OrdinalIgnoreCase) && dictionary.TryGetValue(num2, out var value))
				{
					excelStructure.HasVerticalMerge = true;
					if (!hashSet.Contains(value))
					{
						value.RowSpan++;
						hashSet.Add(value);
					}
					for (int i = 0; i < num3; i++)
					{
						excelStructure.SetMergedCell(num, num2 + i, value);
					}
				}
				else
				{
					ExcelCellData cellData = new ExcelCellData
					{
						RowIndex = num,
						ColumnIndex = num2,
						RowSpan = 1,
						ColumnSpan = num3,
						Text = GetTableCellText(item2),
						Element = new XElement(item2)
					};
					excelStructure.AddCell(cellData);
					if (num3 > 1)
					{
						for (int j = 1; j < num3; j++)
						{
							excelStructure.SetMergedCell(num, num2 + j, cellData);
						}
					}
					if (flag)
					{
						excelStructure.HasVerticalMerge = true;
						for (int k = 0; k < num3; k++)
						{
							dictionary[num2 + k] = cellData;
						}
					}
					else
					{
						for (int l = 0; l < num3; l++)
						{
							dictionary.Remove(num2 + l);
						}
					}
				}
				excelStructure.ColumnCount = Math.Max(excelStructure.ColumnCount, num2 + num3 - 1);
				num2 += num3;
			}
		}
		excelStructure.RowCount = num;
		excelStructure.RebuildMerges();
		excelStructure.HeaderRowCount = GetMaxColumnCount(excelStructure);
		return excelStructure;
	}

	private static string GetTableCellText(XElement P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XElement item in P_0.Descendants())
		{
			if (item.Name == WordNamespace + "t")
			{
				stringBuilder.Append(item.Value);
			}
			else if (item.Name == WordNamespace + "tab")
			{
				stringBuilder.Append('\t');
			}
			else if (item.Name == WordNamespace + "br" || item.Name == WordNamespace + "cr")
			{
				stringBuilder.Append('\n');
			}
		}
		return stringBuilder.ToString().Replace('\a', ' ').Trim();
	}

	private static int GetTableColumnCountFromXml(XElement P_0)
	{
		if (!int.TryParse(P_0.Element(WordNamespace + "tcPr")?.Element(WordNamespace + "gridSpan")?.Attribute(WordNamespace + "val")?.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) || result < 1)
		{
			return 1;
		}
		return result;
	}

	private static string GetTableStyleVal(XElement P_0)
	{
		XElement xElement = P_0.Element(WordNamespace + "tcPr")?.Element(WordNamespace + "vMerge");
		if (xElement == null)
		{
			return null;
		}
		return GetAttributeValue(xElement, "val");
	}

	private static bool CompareStructures(ExcelTableStructure P_0, ExcelTableStructure P_1)
	{
		if (P_0 == null || (P_0.Merges.Count <= 0 && !P_0.HasVerticalMerge))
		{
			if (P_1 != null)
			{
				if (P_1.Merges.Count <= 0)
				{
					return P_1.HasVerticalMerge;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	private static List<ComCellPlan> BuildComCellPlans(ExcelTableStructure P_0, string[,] P_1)
	{
		List<ComCellPlan> list = new List<ComCellPlan>();
		if (P_0 == null)
		{
			return list;
		}
		for (int i = 1; i <= P_0.RowCount; i++)
		{
			int num = 0;
			for (int j = 1; j <= P_0.ColumnCount; j++)
			{
				ExcelCellData oy5QGFVitTDJtPXLAlDX2;
				if (P_0.TryGetCell(i, j, out var cellData))
				{
					num++;
					int num2 = Math.Max(1, cellData.RowSpan);
					int num3 = Math.Max(1, cellData.ColumnSpan);
					list.Add(new ComCellPlan
					{
						RowIndex = i,
						ColumnIndex = j,
						WordColumnIndex = num,
						RowSpan = num2,
						ColumnSpan = num3,
						Text = GetCellValueFromGrid(P_1, i, j),
						IsMergeStart = (num2 > 1 || num3 > 1)
					});
				}
				else if (P_0.TryGetMergedCell(i, j, out oy5QGFVitTDJtPXLAlDX2) && i > oy5QGFVitTDJtPXLAlDX2.RowIndex && j == oy5QGFVitTDJtPXLAlDX2.ColumnIndex)
				{
					num++;
				}
			}
		}
		return list;
	}

	private static bool ValidateAndAdjustTable(Table P_0, ExcelTableStructure P_1, ExcelTableStructure P_2, string[,] P_3, out string P_4)
	{
		P_4 = string.Empty;
		if (P_0 == null || P_2 == null || P_2.RowCount <= 0 || P_2.ColumnCount <= 0)
		{
			P_4 = "COM 重建参数不完整";
			return false;
		}
		Microsoft.Office.Interop.Word.Range range = null;
		try
		{
			range = App.Selection?.Range?.Duplicate;
		}
		catch
		{
		}
		WdAlertLevel? wdAlertLevel = null;
		try
		{
			try
			{
				wdAlertLevel = P_0.Application.DisplayAlerts;
				P_0.Application.DisplayAlerts = WdAlertLevel.wdAlertsNone;
			}
			catch
			{
			}
			P_0.Range.Revisions.AcceptAll();
			TableStyleInfo znUiB7VHnihVw3KU0MHk2 = ExtractTableStyleInfo(P_0, P_1);
			if (!ValidateTableStructure(P_0, P_1))
			{
				P_4 = "反合并当前 Word 表格失败";
				return false;
			}
			if (!IsRowEmpty(P_0, P_2.RowCount, P_2.ColumnCount))
			{
				P_4 = "调整 Word 规则表行列数失败";
				return false;
			}
			ApplyTableBorders(P_0, znUiB7VHnihVw3KU0MHk2);
			List<ComCellPlan> list = BuildComCellPlans(P_2, P_3);
			int num = GetEffectiveColumnCount(P_2, P_2.HeaderRowCount);
			if (!WriteCellsViaCom(P_0, list, znUiB7VHnihVw3KU0MHk2, num, out P_4))
			{
				return false;
			}
			P_0.Range.Revisions.AcceptAll();
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Rebuild Word table from Excel structure with COM failed", ex);
			P_4 = ex.Message;
			return false;
		}
		finally
		{
			try
			{
				if (wdAlertLevel.HasValue)
				{
					P_0.Application.DisplayAlerts = wdAlertLevel.Value;
				}
			}
			catch
			{
			}
			try
			{
				range?.Select();
			}
			catch
			{
			}
		}
	}

	private static TableStyleInfo ExtractTableStyleInfo(Table P_0, ExcelTableStructure P_1)
	{
		TableStyleInfo znUiB7VHnihVw3KU0MHk2 = new TableStyleInfo();
		if (P_0 == null)
		{
			return znUiB7VHnihVw3KU0MHk2;
		}
		znUiB7VHnihVw3KU0MHk2.SummaryFooterRow = GetEffectiveColumnCount(P_1, P_1?.HeaderRowCount ?? 0);
		ApplyTableStyleInfo(znUiB7VHnihVw3KU0MHk2, P_1);
		try
		{
			int num = GetTableColumnCount(P_0);
			for (int i = 1; i <= num; i++)
			{
				if (znUiB7VHnihVw3KU0MHk2.ColumnWidths.ContainsKey(i))
				{
					continue;
				}
				try
				{
					float preferredWidth = P_0.Columns[i].PreferredWidth;
					if (IsValidWidth(preferredWidth))
					{
						znUiB7VHnihVw3KU0MHk2.ColumnWidths[i] = preferredWidth;
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		try
		{
			if (TryGetTableRowCount(P_0, out var num2))
			{
				for (int j = 1; j <= num2; j++)
				{
					try
					{
						float height = P_0.Rows[j].Height;
						if (height > 0f)
						{
							znUiB7VHnihVw3KU0MHk2.RowHeights[j] = height;
						}
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		Dictionary<string, ComCellPlan> dictionary = BuildComCellPlans(P_1, null).ToDictionary((ComCellPlan dmw4ImVHwkHOAyaZBm6p2) => BuildCellKey(dmw4ImVHwkHOAyaZBm6p2.RowIndex, dmw4ImVHwkHOAyaZBm6p2.ColumnIndex), (ComCellPlan result) => result, StringComparer.Ordinal);
		if (P_1 != null)
		{
			foreach (ExcelCellData item in from cellData in P_1.Cells
				orderby cellData.RowIndex, cellData.ColumnIndex
				select cellData)
			{
				ComCellPlan value;
				int num3 = (dictionary.TryGetValue(BuildCellKey(item.RowIndex, item.ColumnIndex), out value) ? value.WordColumnIndex : item.ColumnIndex);
				if (!TryGetCellAtPosition(P_0, item.RowIndex, num3, out var cell))
				{
					continue;
				}
				CellFormat cellFormat = GetCellFormat(cell);
				if (cellFormat != null)
				{
					znUiB7VHnihVw3KU0MHk2.Cells[BuildCellKey(item.RowIndex, item.ColumnIndex)] = cellFormat;
					if (znUiB7VHnihVw3KU0MHk2.DefaultCell == null)
					{
						znUiB7VHnihVw3KU0MHk2.DefaultCell = cellFormat;
					}
				}
			}
		}
		if (znUiB7VHnihVw3KU0MHk2.DefaultCell == null && TryGetCellAtPosition(P_0, 1, 1, out var cell2))
		{
			znUiB7VHnihVw3KU0MHk2.DefaultCell = GetCellFormat(cell2);
		}
		return znUiB7VHnihVw3KU0MHk2;
	}

	private static void ApplyTableStyleInfo(TableStyleInfo P_0, ExcelTableStructure P_1)
	{
		XElement xElement = P_1?.TableElement?.Element(WordNamespace + "tblGrid");
		if (P_0 == null || xElement == null)
		{
			return;
		}
		int num = 0;
		foreach (XElement item in xElement.Elements(WordNamespace + "gridCol"))
		{
			num++;
			if (int.TryParse(GetAttributeValue(item, "w"), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) && result > 0)
			{
				float num2 = (float)result / 20f;
				if (IsValidWidth(num2))
				{
					P_0.ColumnWidths[num] = num2;
				}
			}
		}
	}

	private static CellFormat GetCellFormat(Cell P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		CellFormat cellFormat = new CellFormat();
		try
		{
			cellFormat.Bold = P_0.Range.Font.Bold;
		}
		catch
		{
		}
		try
		{
			cellFormat.Italic = P_0.Range.Font.Italic;
		}
		catch
		{
		}
		try
		{
			cellFormat.Underline = (int)P_0.Range.Font.Underline;
		}
		catch
		{
		}
		try
		{
			cellFormat.ParagraphAlignment = (int)P_0.Range.ParagraphFormat.Alignment;
		}
		catch
		{
		}
		try
		{
			cellFormat.LeftIndent = P_0.Range.ParagraphFormat.LeftIndent;
		}
		catch
		{
		}
		try
		{
			cellFormat.FirstLineIndent = P_0.Range.ParagraphFormat.FirstLineIndent;
		}
		catch
		{
		}
		try
		{
			cellFormat.VerticalAlignment = (int)P_0.VerticalAlignment;
		}
		catch
		{
		}
		return cellFormat;
	}

	private static bool ValidateTableStructure(Table P_0, ExcelTableStructure P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return true;
		}
		List<ExcelCellData> list = (from cellData in P_1.Cells
			where Math.Max(1, cellData.RowSpan) > 1 || Math.Max(1, cellData.ColumnSpan) > 1
			orderby cellData.RowIndex descending, cellData.ColumnIndex descending
			select cellData).ToList();
		if (list.Count == 0)
		{
			return true;
		}
		Dictionary<string, ComCellPlan> dictionary = BuildComCellPlans(P_1, null).ToDictionary((ComCellPlan dmw4ImVHwkHOAyaZBm6p2) => BuildCellKey(dmw4ImVHwkHOAyaZBm6p2.RowIndex, dmw4ImVHwkHOAyaZBm6p2.ColumnIndex), (ComCellPlan result) => result, StringComparer.Ordinal);
		foreach (ExcelCellData item in list)
		{
			ComCellPlan value;
			int num = (dictionary.TryGetValue(BuildCellKey(item.RowIndex, item.ColumnIndex), out value) ? value.WordColumnIndex : item.ColumnIndex);
			if (!TryGetCellAtPosition(P_0, item.RowIndex, num, out var cell))
			{
				AiConfigBootstrap.LogWarn(string.Format(CultureInfo.InvariantCulture, "[ExcelSync][ComRebuild] Cannot locate merged Word cell R{0}C{1}/W{2} before split", item.RowIndex, item.ColumnIndex, num));
				return false;
			}
			try
			{
				object NumRows = Math.Max(1, item.RowSpan);
				object NumColumns = Math.Max(1, item.ColumnSpan);
				cell.Split(ref NumRows, ref NumColumns);
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogWarn(string.Format(CultureInfo.InvariantCulture, "[ExcelSync][ComRebuild] Split merged Word cell failed R{0}C{1}: {2}", item.RowIndex, num, ex.Message));
				return false;
			}
		}
		return true;
	}

	private static bool IsRowEmpty(Table P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		P_1 = Math.Max(1, P_1);
		P_2 = Math.Max(1, P_2);
		try
		{
			if (!TryGetTableRowCount(P_0, out var i) || i <= 0)
			{
				return false;
			}
			for (; i < P_1; i++)
			{
				if (!IsRowEmptyByIndex(P_0, i))
				{
					return false;
				}
			}
			while (i > P_1 && i > 1)
			{
				try
				{
					P_0.Rows[i].Delete();
				}
				catch
				{
					if (!IsColumnEmpty(P_0, i))
					{
						return false;
					}
				}
				i--;
			}
			int j = GetTableColumnCount(P_0);
			if (j <= 0)
			{
				return false;
			}
			for (; j < P_2; j++)
			{
				if (!IsColumnEmptyByIndex(P_0, j))
				{
					return false;
				}
			}
			while (j > P_2 && j > 1)
			{
				if (!IsLastRowEmpty(P_0, j))
				{
					return false;
				}
				j--;
			}
			return i == P_1 && j == P_2;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[ExcelSync][ComRebuild] Adjust regular COM table size failed: " + ex.Message);
			return false;
		}
	}

	private static bool IsRowEmptyByIndex(Table P_0, int P_1)
	{
		try
		{
			if (!TryGetCellAtPosition(P_0, Math.Max(1, P_1), 1, out var cell))
			{
				return false;
			}
			cell.Select();
			object selection = App.Selection;
			if (_G_o__305.insertRowsBelowCallSite_Tc1 == null)
			{
				_G_o__305.insertRowsBelowCallSite_Tc1 = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertRowsBelow", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			_G_o__305.insertRowsBelowCallSite_Tc1.Target(_G_o__305.insertRowsBelowCallSite_Tc1, selection, 1);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool IsColumnEmpty(Table P_0, int P_1)
	{
		try
		{
			if (!TryGetCellAtPosition(P_0, Math.Max(1, P_1), 1, out var cell))
			{
				return false;
			}
			cell.Select();
			object selection = App.Selection;
			if (_G_o__306.deleteCallSite_Tc5 == null)
			{
				_G_o__306.deleteCallSite_Tc5 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Delete", null, typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Action<CallSite, object> target = _G_o__306.deleteCallSite_Tc5.Target;
			CallSite<Action<CallSite, object>> deleteCallSite_Tc5 = _G_o__306.deleteCallSite_Tc5;
			if (_G_o__306.toObjectCallSite_Tc15 == null)
			{
				_G_o__306.toObjectCallSite_Tc15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Rows", typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(deleteCallSite_Tc5, _G_o__306.toObjectCallSite_Tc15.Target(_G_o__306.toObjectCallSite_Tc15, selection));
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool IsColumnEmptyByIndex(Table P_0, int P_1)
	{
		try
		{
			if (!TryGetCellAtPosition(P_0, 1, Math.Max(1, P_1), out var cell))
			{
				return false;
			}
			cell.Select();
			object selection = App.Selection;
			if (_G_o__307.insertColumnsRightCallSite_Tc2 == null)
			{
				_G_o__307.insertColumnsRightCallSite_Tc2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertColumnsRight", null, typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			_G_o__307.insertColumnsRightCallSite_Tc2.Target(_G_o__307.insertColumnsRightCallSite_Tc2, selection);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool IsLastRowEmpty(Table P_0, int P_1)
	{
		try
		{
			if (!TryGetCellAtPosition(P_0, 1, Math.Max(1, P_1), out var cell))
			{
				return false;
			}
			cell.Select();
			object selection = App.Selection;
			if (_G_o__308.deleteCallSite_Tc2 == null)
			{
				_G_o__308.deleteCallSite_Tc2 = CallSite<Action<CallSite, object, WdDeleteCells>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Delete", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Action<CallSite, object, WdDeleteCells> target = _G_o__308.deleteCallSite_Tc2.Target;
			CallSite<Action<CallSite, object, WdDeleteCells>> nWCV32bQxvq = _G_o__308.deleteCallSite_Tc2;
			if (_G_o__308.toObjectCallSite_Tc23 == null)
			{
				_G_o__308.toObjectCallSite_Tc23 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Cells", typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(nWCV32bQxvq, _G_o__308.toObjectCallSite_Tc23.Target(_G_o__308.toObjectCallSite_Tc23, selection), WdDeleteCells.wdDeleteCellsEntireColumn);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static void ApplyTableBorders(Table P_0, TableStyleInfo P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		try
		{
			P_0.AllowAutoFit = false;
			P_0.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitFixed);
		}
		catch
		{
		}
		try
		{
			float num = GetColumnWidth(P_1, GetTableColumnCount(P_0));
			if (IsValidWidth(num))
			{
				P_0.PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPoints;
				P_0.PreferredWidth = num;
			}
		}
		catch
		{
		}
		try
		{
			foreach (KeyValuePair<int, float> rowHeight in P_1.RowHeights)
			{
				if (rowHeight.Key > 0 && IsValidWidth(rowHeight.Value))
				{
					try
					{
						P_0.Rows[rowHeight.Key].Height = rowHeight.Value;
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		try
		{
			int num2 = GetTableColumnCount(P_0);
			TryGetTableRowCount(P_0, out var val);
			ApplyCellBordersToRange(P_0, P_1, Math.Max(1, val), num2);
		}
		catch
		{
		}
	}

	private static void ApplyCellBordersToRange(Table P_0, TableStyleInfo P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 == null || P_2 <= 0 || P_3 <= 0)
		{
			return;
		}
		for (int i = 1; i <= P_2; i++)
		{
			for (int j = 1; j <= P_3; j++)
			{
				float num = GetRowHeight(P_1, j);
				if (!IsValidWidth(num) || !TryGetCellAtPosition(P_0, i, j, out var cell))
				{
					continue;
				}
				try
				{
					cell.Width = num;
				}
				catch
				{
					try
					{
						cell.PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPoints;
						cell.PreferredWidth = num;
					}
					catch
					{
					}
				}
			}
		}
	}

	private static float GetColumnWidth(TableStyleInfo P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = 1; i <= P_1; i++)
		{
			float num2 = GetRowHeight(P_0, i);
			if (num2 > 0f)
			{
				num += ConvertPointsToCm(num2);
			}
		}
		return num;
	}

	private static float GetRowHeight(TableStyleInfo P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0f;
		}
		if (P_0.ColumnWidths.TryGetValue(P_1, out var value) && value > 0f)
		{
			return ConvertPointsToCm(value);
		}
		value = P_0.ColumnWidths.Values.Where((float item) => item > 0f).DefaultIfEmpty(0f).LastOrDefault();
		if (!(value > 0f))
		{
			return 0f;
		}
		return ConvertPointsToCm(value);
	}

	private static float GetCellWidth(TableStyleInfo P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = P_1; i < P_1 + P_2; i++)
		{
			num += GetRowHeight(P_0, i);
		}
		return num;
	}

	private static bool IsValidWidth(float P_0)
	{
		if (P_0 > 0f)
		{
			return P_0 <= 1584f;
		}
		return false;
	}

	private static float ConvertPointsToCm(float P_0)
	{
		if (P_0 <= 0f)
		{
			return 0.1f;
		}
		if (P_0 > 1584f)
		{
			return 1584f;
		}
		return P_0;
	}

	private static bool WriteCellsViaCom(Table P_0, IList<ComCellPlan> P_1, TableStyleInfo P_2, int P_3, out string P_4)
	{
		P_4 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			P_4 = "COM 合并参数不完整";
			return false;
		}
		List<RowColumnSpan> list = new List<RowColumnSpan>();
		foreach (ComCellPlan item in from dmw4ImVHwkHOAyaZBm6p2 in P_1
			orderby dmw4ImVHwkHOAyaZBm6p2.RowIndex, dmw4ImVHwkHOAyaZBm6p2.ColumnIndex
			select dmw4ImVHwkHOAyaZBm6p2)
		{
			int num = CountCellsInSpan(item.RowIndex, item.ColumnIndex, list);
			if (!TryGetCellAtPosition(P_0, item.RowIndex, num, out var cell))
			{
				P_4 = string.Format(CultureInfo.InvariantCulture, "无法定位 Word 单元格 R{0}C{1}", item.RowIndex, num);
				return false;
			}
			if (item.IsMergeStart)
			{
				int num2 = item.RowIndex + Math.Max(1, item.RowSpan) - 1;
				int num3 = item.ColumnIndex + Math.Max(1, item.ColumnSpan) - 1;
				int num4 = CountCellsInSpan(num2, num3, list);
				if (!TryGetCellAtPosition(P_0, num2, num4, out var mergeTo))
				{
					P_4 = string.Format(CultureInfo.InvariantCulture, "无法定位 Word 合并终点 R{0}C{1}", num2, num4);
					return false;
				}
				try
				{
					cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
					cell.Merge(mergeTo);
				}
				catch (Exception ex)
				{
					P_4 = string.Format(CultureInfo.InvariantCulture, "合并 Word 单元格 R{0}C{1}:R{2}C{3} 失败：{4}", item.RowIndex, num, num2, num4, ex.Message);
					return false;
				}
				if (item.ColumnSpan > 1)
				{
					for (int num5 = item.RowIndex; num5 <= num2; num5++)
					{
						list.Add(new RowColumnSpan
						{
							RowIndex = num5,
							StartColumn = item.ColumnIndex,
							ColumnSpan = Math.Max(1, item.ColumnSpan)
						});
					}
				}
				TryGetCellAtPosition(P_0, item.RowIndex, num, out cell);
				float num6 = GetCellWidth(P_2, item.ColumnIndex, Math.Max(1, item.ColumnSpan));
				if (cell != null && IsValidWidth(num6))
				{
					try
					{
						cell.Width = num6;
					}
					catch
					{
					}
				}
			}
			CellFormat cellFormat = GetCellFormatByPosition(P_2, item.RowIndex, item.ColumnIndex, P_3);
			string arg;
			bool num7 = TrySetCellText(cell, item.Text, out arg);
			ApplyCellFormat(cell, cellFormat);
			if (!num7 && !string.IsNullOrWhiteSpace(item.Text))
			{
				P_4 = string.Format(CultureInfo.InvariantCulture, "写入 Word 单元格 R{0}C{1} 失败：{2}", item.RowIndex, num, arg);
				return false;
			}
		}
		return true;
	}

	private static int WriteTableDataViaComDirect(Table P_0, ExcelTableStructure P_1, string[,] P_2, Microsoft.Office.Interop.Excel.Range P_3, SyncOptions P_4)
	{
		P_4 = P_4 ?? GetDefaultSyncOptions();
		List<ComCellPlan> source = BuildComCellPlans(P_1, P_2);
		int num = 0;
		foreach (ComCellPlan item in from dmw4ImVHwkHOAyaZBm6p2 in source
			orderby dmw4ImVHwkHOAyaZBm6p2.RowIndex, dmw4ImVHwkHOAyaZBm6p2.ColumnIndex
			select dmw4ImVHwkHOAyaZBm6p2)
		{
			if (P_1 == null || P_1.HeaderRowCount <= 0 || item.RowIndex > P_1.HeaderRowCount || P_4.SyncHeaders)
			{
				string empty = string.Empty;
				Cell cell;
				bool num2 = TryGetCellAtPosition(P_0, item.RowIndex, item.WordColumnIndex, out cell) && TrySetCellText(cell, item.Text, out empty);
				if (cell == null)
				{
					empty = string.Format(CultureInfo.InvariantCulture, "未找到 Word COM 单元格 R{0}C{1}", item.RowIndex, item.WordColumnIndex);
				}
				if (!num2 && !string.IsNullOrWhiteSpace(item.Text))
				{
					num++;
				}
			}
		}
		return num;
	}

	private static int CountCellsInSpan(int P_0, int P_1, IList<RowColumnSpan> P_2)
	{
		if (P_0 <= 0 || P_1 <= 0)
		{
			return 0;
		}
		int num = 0;
		if (P_2 != null)
		{
			foreach (RowColumnSpan item in P_2)
			{
				if (item.RowIndex == P_0 && item.StartColumn < P_1)
				{
					num += Math.Max(0, item.ColumnSpan - 1);
				}
			}
		}
		return Math.Max(1, P_1 - num);
	}

	private static CellFormat GetCellFormatByPosition(TableStyleInfo P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return null;
		}
		if (P_3 > 0 && P_1 == P_3 && P_0.SummaryFooterRow > 0 && P_0.Cells.TryGetValue(BuildCellKey(P_0.SummaryFooterRow, P_2), out var value))
		{
			return value;
		}
		if (P_1 != P_0.SummaryFooterRow && P_0.Cells.TryGetValue(BuildCellKey(P_1, P_2), out value))
		{
			return value;
		}
		for (int num = P_1 - 1; num >= 1; num--)
		{
			if ((num != P_0.SummaryFooterRow || P_1 == P_3) && P_0.Cells.TryGetValue(BuildCellKey(num, P_2), out value))
			{
				return value;
			}
		}
		for (int num2 = P_2 - 1; num2 >= 1; num2--)
		{
			if (P_1 != P_0.SummaryFooterRow && P_0.Cells.TryGetValue(BuildCellKey(P_1, num2), out value))
			{
				return value;
			}
		}
		return P_0.DefaultCell;
	}

	private static void ApplyCellFormat(Cell P_0, CellFormat P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		try
		{
			if (P_1.Bold.HasValue)
			{
				P_0.Range.Font.Bold = P_1.Bold.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.Italic.HasValue)
			{
				P_0.Range.Font.Italic = P_1.Italic.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.Underline.HasValue)
			{
				P_0.Range.Font.Underline = (WdUnderline)P_1.Underline.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.ParagraphAlignment.HasValue)
			{
				P_0.Range.ParagraphFormat.Alignment = (WdParagraphAlignment)P_1.ParagraphAlignment.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.LeftIndent.HasValue)
			{
				P_0.Range.ParagraphFormat.LeftIndent = P_1.LeftIndent.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.FirstLineIndent.HasValue)
			{
				P_0.Range.ParagraphFormat.FirstLineIndent = P_1.FirstLineIndent.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.VerticalAlignment.HasValue)
			{
				P_0.VerticalAlignment = (WdCellVerticalAlignment)P_1.VerticalAlignment.Value;
			}
		}
		catch
		{
		}
	}

	private static bool TryGetCellAtPosition(Table P_0, int P_1, int P_2, out Cell P_3)
	{
		P_3 = null;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return false;
		}
		try
		{
			P_3 = P_0.Cell(P_1, P_2);
			return P_3 != null;
		}
		catch
		{
			return false;
		}
	}

	[Conditional("DEBUG")]
	private static void SortCellPlans(IList<ComCellPlan> P_0)
	{
		if (P_0 == null || P_0.Count == 0)
		{
			return;
		}
		try
		{
			foreach (IGrouping<int, ComCellPlan> item in from cell in P_0
				group cell by cell.RowIndex into @group
				orderby @group.Key
				select @group)
			{
				_ = from cell in item
					orderby cell.ColumnIndex
					select string.Format(CultureInfo.InvariantCulture, "InsertColumnsRight", cell.ColumnIndex, cell.WordColumnIndex, cell.RowSpan, cell.ColumnSpan, NormalizePath(cell.Text));
			}
		}
		catch
		{
		}
	}

	private static SyncResult SyncAllTablesViaXml(ProgressCallback P_0, SyncOptions P_1)
	{
		SyncResult syncResult = new SyncResult();
		bool screenUpdating = true;
		try
		{
			if (!ShouldCancelSync(P_0, "正在启动批量同步..."))
			{
				syncResult.Success = false;
				syncResult.Cancelled = true;
				syncResult.Message = "用户取消了同步。";
				return syncResult;
			}
			Document document = App?.ActiveDocument;
			if (document == null)
			{
				return CreateSyncResult("当前没有打开的 Word 文档。", null, true);
			}
			try
			{
				screenUpdating = App.ScreenUpdating;
				App.ScreenUpdating = false;
			}
			catch
			{
				screenUpdating = true;
			}
			string text = Convert.ToString(document.FullName, CultureInfo.InvariantCulture);
			if (!IsValidXmlName(text))
			{
				return CreateSyncResult("批量 XML 同步仅支持已保存的 .docx/.docm 文档，请先保存当前 Word 文档后再试。", null, true);
			}
			int num = (syncResult.Total = document.Tables.Count);
			if (num == 0)
			{
				syncResult.Success = true;
				syncResult.Message = "当前文档没有表格。";
				return syncResult;
			}
			if (!ShouldCancelSync(P_0, "正在扫描 Word 表格绑定..."))
			{
				syncResult.Success = false;
				syncResult.Cancelled = true;
				syncResult.Message = "用户取消了同步。";
				return syncResult;
			}
			bool flag;
			List<TableBindingPair> list = ScanTableBindings(document, P_0, out flag);
			if (flag)
			{
				syncResult.Success = false;
				syncResult.Cancelled = true;
				syncResult.Message = "用户取消了同步。";
				return syncResult;
			}
			syncResult.Bound = list.Count;
			if (list.Count == 0)
			{
				syncResult.Success = true;
				syncResult.Message = "当前文档没有已绑定的 Excel 同步表。";
				return syncResult;
			}
			if (!ShouldCancelSync(P_0, "正在检查 Excel 源文件状态..."))
			{
				syncResult.Success = false;
				syncResult.Cancelled = true;
				syncResult.Message = "用户取消了同步。";
				return syncResult;
			}
			if (HasAnySyncPairs(list) && !LoggerInitializer.ShowConfirm("批量同步将直接读取已保存的 Excel 文件，不读取当前打开但尚未保存的修改。\r\n\r\n如果 Excel 中有未保存内容，请先保存后再继续。是否继续同步？", "同步全部表"))
			{
				syncResult.Success = false;
				syncResult.Cancelled = true;
				syncResult.Message = "用户取消了同步。";
				return syncResult;
			}
			int num2 = list.Count + 3;
			if (!ShouldCancelSync(P_0, "正在读取 Word 文档 XML 结构..."))
			{
				syncResult.Success = false;
				syncResult.Cancelled = true;
				syncResult.Message = "用户取消了同步。";
				return syncResult;
			}
			if (!TryGetTableStructureSnapshotWithProgress(document, P_0, out var nmRqISVHbXuCPOhoghlw2, out var text2, out var flag2))
			{
				if (flag2)
				{
					syncResult.Success = false;
					syncResult.Cancelled = true;
					syncResult.Message = "用户取消了同步。";
					return syncResult;
				}
				return CreateSyncResult("无法读取当前 Word 文档结构，请先保存文档后重试。" + (string.IsNullOrWhiteSpace(text2) ? string.Empty : ("\n" + text2)), null, true);
			}
			string text3;
			bool flag3;
			List<SyncPlanContext> list2 = Read1(list, nmRqISVHbXuCPOhoghlw2, P_0, num2, P_1, out text3, out flag3);
			if (flag3)
			{
				syncResult.Success = false;
				syncResult.Cancelled = true;
				syncResult.Message = "用户取消了同步。";
				return syncResult;
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				syncResult.Failed = 1;
				return CreateSyncResult(text3, null, true);
			}
			List<XmlRebuildResult> list3 = new List<XmlRebuildResult>();
			for (int i = 0; i < list2.Count; i++)
			{
				SyncPlanContext nVooAoVHW4Yl15VG0vUp2 = list2[i];
				if (P_0 != null && !P_0(i + 1, list2.Count, string.Format("正在生成第 {0} 表的 Word XML...", nVooAoVHW4Yl15VG0vUp2.TableIndex)))
				{
					syncResult.Success = false;
					syncResult.Cancelled = true;
					syncResult.Message = "用户取消了同步。";
					return syncResult;
				}
				list3.Add(BuildXmlRebuildPlan(nVooAoVHW4Yl15VG0vUp2, P_1));
			}
			if (P_0 != null && !P_0(list.Count + 1, num2, "正在保存并关闭 Word/WPS 文档..."))
			{
				syncResult.Success = false;
				syncResult.Cancelled = true;
				syncResult.Message = "用户取消了同步。";
				return syncResult;
			}
			document.Save();
			DocumentReopenResult reopenResult = ReopenDocumentWithRebuiltTables(document, text, list3, P_0, list.Count, num2);
			if (!reopenResult.Success)
			{
				syncResult.Failed = list.Count;
				return CreateSyncResult(string.IsNullOrWhiteSpace(reopenResult.Error) ? "同步全部表失败，已尝试恢复原 Word 文档。" : reopenResult.Error, null, true);
			}
			P_0?.Invoke(num2, num2, "同步全部表完成。");
			syncResult.Success = true;
			syncResult.Synced = list3.Count;
			syncResult.Bound = list3.Count;
			syncResult.Total = num;
			syncResult.Message = string.Format("同步完成：{0} / {1} 个表格。", syncResult.Synced, syncResult.Bound);
			int num3 = list2.Count((SyncPlanContext item) => !string.IsNullOrWhiteSpace(item.SortSkippedReason));
			if (num3 > 0)
			{
				syncResult.Message = string.Format("{0} 已有 {1} 个表跳过排序。", syncResult.Message, num3);
			}
			DeleteTempFile(reopenResult.BackupPath);
			return syncResult;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("批量 XML 同步失败", ex);
			return CreateSyncResult("同步全部表失败：" + ex.Message, ex.Message, true);
		}
		finally
		{
			try
			{
				if (App != null)
				{
					App.ScreenUpdating = screenUpdating;
				}
			}
			catch
			{
			}
		}
	}

	private static List<TableBindingPair> ScanTableBindings(Document P_0, ProgressCallback P_1, out bool P_2)
	{
		P_2 = false;
		List<TableBindingPair> list = new List<TableBindingPair>();
		int count = P_0.Tables.Count;
		int num = 0;
		string text = null;
		for (int i = 1; i <= count; i++)
		{
			if (P_1 != null && !P_1(i, count, string.Format("正在扫描 Word 表格绑定：{0} / {1}", i, count)))
			{
				P_2 = true;
				break;
			}
			Table table = null;
			try
			{
				table = P_0.Tables[i];
				TableBinding lnEK8VVIccoSQf18k7Ih2 = FindBindingForTable(table);
				if (lnEK8VVIccoSQf18k7Ih2 != null)
				{
					list.Add(new TableBindingPair
					{
						TableIndex = i,
						Table = table,
						Binding = lnEK8VVIccoSQf18k7Ih2
					});
				}
			}
			catch (Exception ex)
			{
				num++;
				if (string.IsNullOrWhiteSpace(text))
				{
					text = ex.Message;
				}
			}
		}
		if (num > 0)
		{
			AiConfigBootstrap.LogWarn(string.Format("[ExcelSync] Some Word table bindings could not be read; Tables={0}; Failed={1}; FirstFailure={2}", count, num, text ?? string.Empty));
		}
		return list;
	}

	private static bool ShouldCancelSync(ProgressCallback P_0, string P_1)
	{
		return P_0?.Invoke(0, 0, P_1) ?? true;
	}

	private static bool HasAnySyncPairs(IEnumerable<TableBindingPair> P_0)
	{
		Microsoft.Office.Interop.Excel.Application application = ExcelInteropService.GetActiveExcelApp();
		if (application == null || P_0 == null)
		{
			return false;
		}
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		foreach (TableBindingPair item in P_0)
		{
			string text = GetBindingExcelAddress(item.Binding);
			if (!string.IsNullOrWhiteSpace(text) && hashSet.Add(text) && OpenExcelWorkbook(application, text) != null)
			{
				return true;
			}
		}
		return false;
	}

	private static List<SyncPlanContext> Read1(IList<TableBindingPair> P_0, TableStructureSnapshot P_1, ProgressCallback P_2, int P_3, SyncOptions P_4, out string P_5, out bool P_6)
	{
		P_5 = null;
		P_6 = false;
		List<SyncPlanContext> list = new List<SyncPlanContext>();
		for (int i = 0; i < P_0.Count; i++)
		{
			TableBindingPair bindingPair = P_0[i];
			if (P_2 != null && !P_2(i + 1, P_3, string.Format("正在准备第 {0} 表的 XML 同步计划...", bindingPair.TableIndex)))
			{
				P_6 = true;
				return list;
			}
			if (!P_1.StructuresByTableIndex.TryGetValue(bindingPair.TableIndex, out var value))
			{
				P_5 = string.Format("无法读取第 {0} 表的 Word XML 结构。", bindingPair.TableIndex);
				return list;
			}
			string[,] array = null;
			ExcelTableStructure excelStructure = null;
			int num = 0;
			int num2 = 0;
			string text = null;
			if (!ReadExcelDataFromBindingWrapper(bindingPair.Binding, out array, out excelStructure, out num, out num2, out text) || array == null || excelStructure == null)
			{
				P_5 = string.Format("第 {0} 表读取 Excel 名称区域失败：", bindingPair.TableIndex) + (string.IsNullOrWhiteSpace(text) ? "未找到有效数据源。" : text);
				return list;
			}
			GetExcelDataStartRow(bindingPair.Binding, value.HeaderRowCount);
			ApplyStructureChangesToBinding(bindingPair.Binding, value, excelStructure);
			if (!SyncExcelDataToBinding(bindingPair.Binding, ref array, ref excelStructure, ref num2, out var text2))
			{
				P_5 = string.Format("第 {0} 表列映射无效：", bindingPair.TableIndex) + text2;
				return list;
			}
			array = SortTableData(bindingPair.Binding, excelStructure, array, out var sortSkippedReason);
			ApplyBindingToStructure(bindingPair.Binding, excelStructure);
			WritePlan plan = BuildWritePlan(value, excelStructure, num, num2, true);
			list.Add(new SyncPlanContext
			{
				TableIndex = bindingPair.TableIndex,
				Binding = bindingPair.Binding,
				WordStructure = value,
				ExcelStructure = excelStructure,
				Values = array,
				Plan = plan,
				SortSkippedReason = sortSkippedReason
			});
		}
		return list;
	}

	private static XmlRebuildResult BuildXmlRebuildPlan(SyncPlanContext P_0, SyncOptions P_1)
	{
		bool flag = P_0.Plan != null && (P_0.Plan.RequiresStructureRebuild || P_0.Plan.RowShapeChanged || P_0.Plan.ColumnShapeChanged);
		XElement xElement;
		if (flag)
		{
			TableXmlProperties eyp1xWViqgWeojjBvqRB2 = BuildTableXmlProperties(P_0.WordStructure);
			xElement = BuildTableXmlWrapper(P_0.ExcelStructure, P_0.Values, eyp1xWViqgWeojjBvqRB2, true);
		}
		else
		{
			xElement = BuildTableXmlFromStructure(P_0.WordStructure, P_0.ExcelStructure, P_0.Values, P_1);
		}
		ProcessTableGrid(xElement);
		return new XmlRebuildResult
		{
			TableIndex = P_0.TableIndex,
			Binding = P_0.Binding,
			TableXml = xElement,
			StructureRebuilt = flag
		};
	}

	private static XElement BuildTableXmlWrapper(ExcelTableStructure P_0, string[,] P_1, TableXmlProperties P_2, bool P_3)
	{
		return BuildTableXmlCore(P_0, P_1, P_2);
	}

	private static XElement BuildTableXmlFromStructure(ExcelTableStructure P_0, ExcelTableStructure P_1, string[,] P_2, SyncOptions P_3)
	{
		if (P_0?.TableElement == null)
		{
			throw new InvalidOperationException("缺少 Word 原表 XML，无法执行文本替换。");
		}
		XElement xElement = new XElement(P_0.TableElement);
		List<XElement> list = xElement.Elements(WordNamespace + "tr").ToList();
		Dictionary<string, int> dictionary = BuildCellIndexMap(P_0);
		int num = ((P_1.HeaderRowCount > 0) ? P_1.HeaderRowCount : P_0.HeaderRowCount);
		bool flag = P_3?.SyncHeaders ?? true;
		foreach (ExcelCellData item in from cell in P_1.Cells
			orderby cell.RowIndex, cell.ColumnIndex
			select cell)
		{
			if (flag || item.RowIndex > num)
			{
				if (item.RowIndex < 1 || item.RowIndex > list.Count)
				{
					throw new InvalidOperationException(string.Format("Word 表缺少第 {0} 行，无法替换文本。", item.RowIndex));
				}
				string key = BuildCellReference(item.RowIndex, item.ColumnIndex);
				if (!dictionary.TryGetValue(key, out var value))
				{
					throw new InvalidOperationException(string.Format("Word 表缺少单元格 ({0}, {1})，无法替换文本。", item.RowIndex, item.ColumnIndex));
				}
				SetCellText(list[item.RowIndex - 1].Elements(WordNamespace + "tc").ElementAtOrDefault(value) ?? throw new InvalidOperationException(string.Format("Word 表第 {0} 行缺少第 {1} 个可见单元格。", item.RowIndex, value + 1)), GetCellValueFromGrid(P_2, item.RowIndex, item.ColumnIndex));
			}
		}
		return xElement;
	}

	private static Dictionary<string, int> BuildCellIndexMap(ExcelTableStructure P_0)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.Ordinal);
		foreach (IGrouping<int, ExcelCellData> item in from cell in P_0.Cells
			group cell by cell.RowIndex)
		{
			int num = 0;
			foreach (ExcelCellData item2 in item.OrderBy((ExcelCellData cell) => cell.ColumnIndex))
			{
				dictionary[BuildCellReference(item2.RowIndex, item2.ColumnIndex)] = num;
				num++;
			}
		}
		return dictionary;
	}

	private static void ProcessTableGrid(XElement P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		try
		{
			List<MergedCellInfo> list = XZBjzMAZoi(P_0);
			if (list.Count == 0)
			{
				return;
			}
			Dictionary<int, bool> dictionary = BuildHeaderColumnMap(list);
			bool flag = GetConfigBoolValue("表格_合计小计处理_下划线包含文字", GetConfigBoolValue("表格_合计处理_下划线包含合计", false));
			bool flag2 = GetConfigBoolValue("表格_合计小计处理_加粗包含文字", GetConfigBoolValue("表格_合计处理_加粗包含合计", false));
			foreach (IGrouping<int, MergedCellInfo> item in from cell in list
				group cell by cell.RowIndex)
			{
				List<MergedCellInfo> list2 = item.OrderBy((MergedCellInfo cell) => cell.ColumnIndex).ToList();
				foreach (MergedCellInfo item2 in list2)
				{
					if (item2.RowIndex != 1 && TryGetMergedCell(dictionary, item2, out var flag3))
					{
						SetTableBorders(item2.CellElement, flag3);
					}
					bool flag4 = IsSubtotalRow(item2.Text);
					bool flag5 = IsSubtotalRowByText(item2.Text);
					bool flag6 = IsHeaderRow(item2.Text);
					bool flag7 = IsHeaderRowByText(item2.Text);
					if (flag4 || flag5)
					{
						SetColumnWidth(item2.CellElement, "合计");
						ProcessMergedCells(list2, item2, flag4);
						SetTableProperties(item2.CellElement, flag4, flag, flag2);
					}
					else if (flag6 || flag7)
					{
						ProcessMergedCells(list2, item2, flag6);
						SetTableProperties(item2.CellElement, flag6, flag, flag2);
					}
				}
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[ExcelSync] Apply summary formatting in XML failed: " + ex.Message);
		}
	}

	private static List<MergedCellInfo> XZBjzMAZoi(XElement P_0)
	{
		List<MergedCellInfo> list = new List<MergedCellInfo>();
		int num = 0;
		foreach (XElement item in P_0.Elements(WordNamespace + "tr"))
		{
			num++;
			int num2 = GetGridRowCount(item) + 1;
			foreach (XElement item2 in item.Elements(WordNamespace + "tc"))
			{
				int num3 = GetGridColCount(item2);
				list.Add(new MergedCellInfo
				{
					RowIndex = num,
					ColumnIndex = num2,
					ColumnSpan = num3,
					CellElement = item2,
					Text = GetTableCellText(item2)
				});
				num2 += num3;
			}
		}
		return list;
	}

	private static int GetGridRowCount(XElement P_0)
	{
		if (!int.TryParse(GetAttributeValue(P_0?.Element(WordNamespace + "trPr")?.Element(WordNamespace + "gridBefore"), "val"), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) || result <= 0)
		{
			return 0;
		}
		return result;
	}

	private static int GetGridColCount(XElement P_0)
	{
		if (!int.TryParse(GetAttributeValue(P_0?.Element(WordNamespace + "tcPr")?.Element(WordNamespace + "gridSpan"), "val"), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) || result <= 0)
		{
			return 1;
		}
		return result;
	}

	private static Dictionary<int, bool> BuildHeaderColumnMap(IEnumerable<MergedCellInfo> P_0)
	{
		Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
		foreach (MergedCellInfo item in P_0.Where((MergedCellInfo cell) => cell.RowIndex == 1))
		{
			bool flag = IsSubtotalRow(item.Text) || IsHeaderRow(item.Text);
			bool flag2 = IsSubtotalRowByText(item.Text) || IsHeaderRowByText(item.Text);
			if (flag || flag2)
			{
				int num = Math.Max(1, item.ColumnSpan);
				for (int num2 = item.ColumnIndex; num2 < item.ColumnIndex + num; num2++)
				{
					dictionary[num2] = flag;
				}
			}
		}
		return dictionary;
	}

	private static bool TryGetMergedCell(IDictionary<int, bool> P_0, MergedCellInfo P_1, out bool P_2)
	{
		P_2 = false;
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		int num = Math.Max(1, P_1.ColumnSpan);
		for (int i = P_1.ColumnIndex; i < P_1.ColumnIndex + num; i++)
		{
			if (P_0.TryGetValue(i, out P_2))
			{
				return true;
			}
		}
		return false;
	}

	private static void ProcessMergedCells(IList<MergedCellInfo> P_0, MergedCellInfo P_1, bool P_2)
	{
		bool flag = false;
		foreach (MergedCellInfo item in P_0)
		{
			if (item == P_1)
			{
				flag = true;
			}
			else if (flag)
			{
				SetTableBorders(item.CellElement, P_2);
			}
		}
	}

	private static void SetTableBorders(XElement P_0, bool P_1)
	{
		int num = GetConfigIntValue(P_1 ? "表格_小计处理_下划线" : "表格_合计处理_下划线", (!P_1) ? 1 : 3);
		int num2 = GetConfigIntValue(P_1 ? "表格_小计处理_加粗" : "表格_合计处理_加粗", 0);
		SetCellWidths(P_0, num, num2);
	}

	private static void SetTableProperties(XElement P_0, bool P_1, bool P_2, bool P_3)
	{
		int num = (P_2 ? GetConfigIntValue(P_1 ? "表格_小计处理_下划线" : "表格_合计处理_下划线", (!P_1) ? 1 : 3) : 0);
		int num2 = (P_3 ? GetConfigIntValue(P_1 ? "表格_小计处理_加粗" : "表格_合计处理_加粗", 0) : 0);
		SetCellWidths(P_0, num, num2);
	}

	private static void SetCellWidths(XElement P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		List<XElement> list = P_0.Descendants(WordNamespace + "r").ToList();
		if (list.Count == 0)
		{
			return;
		}
		foreach (XElement item in list)
		{
			XElement xElement = item.Element(WordNamespace + "rPr");
			if (xElement == null)
			{
				xElement = new XElement(WordNamespace + "rPr");
				item.AddFirst(xElement);
			}
			SetCellMargins(xElement, "u", GetVerticalAlignmentCode(P_1));
			SetCellMargins(xElement, "b", (P_2 != 0) ? "0" : "1");
			SetCellMargins(xElement, "bCs", (P_2 != 0) ? "0" : "1");
		}
	}

	private static void SetColumnWidth(XElement P_0, string P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = GetConfigIntValue("表格_段落格式_" + P_1 + "水平对齐", (!string.Equals(P_1, "数字", StringComparison.Ordinal)) ? 1 : 2);
		int num2 = GetConfigIntValue("表格_段落格式_" + P_1 + "垂直对齐", 1);
		foreach (XElement item in P_0.Elements(WordNamespace + "p"))
		{
			XElement xElement = item.Element(WordNamespace + "pPr");
			if (xElement == null)
			{
				xElement = new XElement(WordNamespace + "pPr");
				item.AddFirst(xElement);
			}
			SetCellProperties(xElement, "jc", GetAlignmentName(num));
		}
		XElement xElement2 = P_0.Element(WordNamespace + "tcPr");
		if (xElement2 == null)
		{
			xElement2 = new XElement(WordNamespace + "tcPr");
			P_0.AddFirst(xElement2);
		}
		SetCellMargins(xElement2, "vAlign", GetVerticalAlignmentName(num2));
	}

	private static void SetCellProperties(XElement P_0, string P_1, string P_2)
	{
		if (P_0 != null && !string.IsNullOrWhiteSpace(P_1) && !string.IsNullOrWhiteSpace(P_2))
		{
			XElement xElement = P_0.Element(WordNamespace + P_1);
			if (xElement == null)
			{
				P_0.Add(new XElement(WordNamespace + P_1, new XAttribute(WordNamespace + "val", P_2)));
			}
			else
			{
				xElement.SetAttributeValue(WordNamespace + "val", P_2);
			}
		}
	}

	private static string GetAlignmentName(int P_0)
	{
		return P_0 switch
		{
			0 => "left", 
			1 => "center", 
			2 => "right", 
			3 => "both", 
			4 => "distribute", 
			_ => "center", 
		};
	}

	private static string GetVerticalAlignmentName(int P_0)
	{
		return P_0 switch
		{
			0 => "top", 
			3 => "bottom", 
			_ => "center", 
		};
	}

	private static string GetVerticalAlignmentCode(int P_0)
	{
		switch (P_0)
		{
		case 0:
			return "none";
		case 1:
			return "single";
		case 2:
			return "words";
		case 3:
			return "double";
		case 4:
			return "dotted";
		case 6:
			return "thick";
		case 7:
			return "dash";
		case 9:
			return "dotDash";
		case 10:
			return "dotDotDash";
		case 11:
			return "wave";
		case 20:
			return "dottedHeavy";
		case 23:
			return "dashHeavy";
		case 25:
			return "dotDashHeavy";
		case 26:
			return "dotDotDashHeavy";
		case 27:
			return "wavyHeavy";
		case 39:
			return "wavyDouble";
		default:
			if (P_0 > 0)
			{
				return "single";
			}
			return "none";
		}
	}

	private static bool IsSubtotalRow(string P_0)
	{
		string text = RemoveAllWhitespace(P_0);
		if (!(text == "合计"))
		{
			return text == "总计";
		}
		return true;
	}

	private static bool IsSubtotalRowByText(string P_0)
	{
		return RemoveAllWhitespace(P_0) == "小计";
	}

	private static bool IsHeaderRow(string P_0)
	{
		string text = RemoveAllWhitespace(P_0);
		if (text.Length > 2)
		{
			return text.EndsWith("合计", StringComparison.Ordinal);
		}
		return false;
	}

	private static bool IsHeaderRowByText(string P_0)
	{
		string text = RemoveAllWhitespace(P_0);
		if (text.Length > 2)
		{
			return text.EndsWith("小计", StringComparison.Ordinal);
		}
		return false;
	}

	private static string RemoveAllWhitespace(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(P_0.Length);
		foreach (char c in P_0)
		{
			if (!char.IsWhiteSpace(c))
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private static int GetConfigIntValue(string P_0, int P_1)
	{
		try
		{
			return TableBorderConfig.Current.GetInt(P_0, P_1);
		}
		catch
		{
			return P_1;
		}
	}

	private static bool GetConfigBoolValue(string P_0, bool P_1)
	{
		try
		{
			string text = TableBorderConfig.Current.GetString(P_0, P_1 ? "0" : "1");
			return text == "1" || text.Equals("true", StringComparison.OrdinalIgnoreCase);
		}
		catch
		{
			return P_1;
		}
	}

	private static string BuildCellReference(int P_0, int P_1)
	{
		return P_0.ToString(CultureInfo.InvariantCulture) + ":" + P_1.ToString(CultureInfo.InvariantCulture);
	}

	private static void SetCellText(XElement P_0, string P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		CellXmlProperties cellProps = ParseCellXmlProperties(P_0);
		XElement xElement = GetTableCellPropertiesElement(P_0);
		XElement xElement2 = xElement?.Ancestors(WordNamespace + "p").FirstOrDefault() ?? P_0.Elements(WordNamespace + "p").FirstOrDefault();
		foreach (XElement item in (from element in P_0.Descendants()
			where element.Name == WordNamespace + "p" || element.Name == WordNamespace + "r" || element.Name == WordNamespace + "Delete" || element.Name == WordNamespace + "Cells"
			select element).ToList())
		{
			item.Remove();
		}
		if (xElement2 == null)
		{
			xElement2 = new XElement(WordNamespace + ": ");
			P_0.Add(xElement2);
		}
		if (xElement == null)
		{
			xElement = new XElement(WordNamespace + ": ");
			xElement2.Add(xElement);
		}
		ApplyCellProperties(xElement, cellProps);
		ApplyBordersToCell(xElement, P_1 ?? string.Empty);
	}

	private static DocumentReopenResult ReopenDocumentWithRebuiltTables(Document P_0, string P_1, IList<XmlRebuildResult> P_2, ProgressCallback P_3, int P_4, int P_5)
	{
		DocumentReopenResult reopenResult = new DocumentReopenResult();
		string text = (reopenResult.BackupPath = EscapeXmlName(P_1));
		Document document = null;
		try
		{
			if (!TryReopenDocument(P_3, P_4 + 1, P_5, out document, out var error))
			{
				reopenResult.Success = false;
				reopenResult.Error = error;
				return reopenResult;
			}
			P_3?.Invoke(P_4 + 1, P_5, "正在保存并关闭 Word/WPS 文档...");
			CloseDocument(P_0);
			P_3?.Invoke(P_4 + 2, P_5, "正在写入 Word XML 包...");
			if (!ValidateAndRebuildTables(P_1, P_2, out var text3))
			{
				WriteStringToFile(text, P_1);
				reopenResult.Success = false;
				reopenResult.Error = "同步全部表失败，已恢复原 Word 文档。" + (string.IsNullOrWhiteSpace(text3) ? string.Empty : ("\n" + text3));
				reopenResult.ReopenedDocument = OpenDocument(P_1);
				CopyDocumentContent(document, reopenResult.ReopenedDocument);
				return reopenResult;
			}
			P_3?.Invoke(P_4 + 3, P_5, "正在重新打开 Word 文档...");
			reopenResult.ReopenedDocument = OpenDocument(P_1);
			CopyDocumentContent(document, reopenResult.ReopenedDocument);
			reopenResult.Success = true;
			return reopenResult;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("批量 XML 写入 Word 包失败", ex);
			WriteStringToFile(text, P_1);
			try
			{
				reopenResult.ReopenedDocument = OpenDocument(P_1);
			}
			catch (Exception ex2)
			{
				AiConfigBootstrap.LogError("恢复后重新打开 Word 文档失败", ex2);
			}
			reopenResult.Success = false;
			CopyDocumentContent(document, reopenResult.ReopenedDocument);
			string text4 = ((document != null && reopenResult.ReopenedDocument == null) ? "\\nWPS 临时保活文档已保留，请手动重新打开原文档检查。" : string.Empty);
			reopenResult.Error = "同步全部表失败，已尝试恢复原 Word 文档。\\n" + ex.Message + text4;
			return reopenResult;
		}
	}

	private static bool TryReopenDocument(ProgressCallback P_0, int P_1, int P_2, out Document P_3, out string P_4)
	{
		P_3 = null;
		P_4 = null;
		if (!WordTableToolService.IsWps)
		{
			return true;
		}
		Microsoft.Office.Interop.Word.Application app = App;
		if (app == null)
		{
			return true;
		}
		int num = 0;
		try
		{
			num = app.Documents.Count;
		}
		catch
		{
			num = 0;
		}
		if (num > 1)
		{
			return true;
		}
		try
		{
			P_0?.Invoke(P_1, P_2, "正在准备 WPS 临时保活文档...");
			object Template = Type.Missing;
			object NewTemplate = Type.Missing;
			object DocumentType = Type.Missing;
			object Visible = true;
			P_3 = app.Documents.Add(ref Template, ref NewTemplate, ref DocumentType, ref Visible);
			try
			{
				P_3.Saved = true;
			}
			catch
			{
			}
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Create WPS keep-alive document failed", ex);
			P_4 = "WPS 只有一个文档时需要创建临时保活文档，但创建失败，已取消批量同步。\\n" + ex.Message;
			return false;
		}
	}

	private static void CopyDocumentContent(Document P_0, Document P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		try
		{
			object SaveChanges = WdSaveOptions.wdDoNotSaveChanges;
			object OriginalFormat = Type.Missing;
			object RouteDocument = false;
			P_0.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
		}
		catch (Exception)
		{
		}
	}

	private static bool ValidateAndRebuildTables(string P_0, IList<XmlRebuildResult> P_1, out string P_2)
	{
		P_2 = null;
		try
		{
			using (Package package = Package.Open(P_0, FileMode.Open, FileAccess.ReadWrite))
			{
				Uri partUri = PackUriHelper.CreatePartUri(new Uri("/word/document.xml", UriKind.Relative));
				Uri partUri2 = PackUriHelper.CreatePartUri(new Uri("/word/settings.xml", UriKind.Relative));
				if (!package.PartExists(partUri))
				{
					P_2 = "Word 包中不存在 /word/document.xml。";
					return false;
				}
				if (!package.PartExists(partUri2))
				{
					P_2 = "Word 包中不存在 /word/settings.xml，无法保存 Excel 同步绑定。";
					return false;
				}
				PackagePart part = package.GetPart(partUri);
				PackagePart part2 = package.GetPart(partUri2);
				XDocument xDocument = ReadDocumentPart(part);
				XDocument xDocument2 = ReadDocumentPart(part2);
				List<XElement> list = xDocument.Descendants(WordNamespace + "tbl").ToList();
				foreach (XmlRebuildResult item in P_1)
				{
					if (item.TableIndex < 1 || item.TableIndex > list.Count)
					{
						P_2 = string.Format("Word 包中找不到第 {0} 个表格。", item.TableIndex);
						return false;
					}
				}
				HashSet<string> hashSet = new HashSet<string>(from update in P_1
					where update.Binding != null && !string.IsNullOrWhiteSpace(update.Binding.Id)
					select update.Binding.Id, StringComparer.OrdinalIgnoreCase);
				HashSet<int> hashSet = new HashSet<int>(P_1.Select((XmlRebuildResult update) => update.TableIndex));
				List<TableBinding> list2 = NeNYbSMjrx(xDocument2, xDocument, hashSet, hashSet);
				foreach (XmlRebuildResult item2 in P_1)
				{
					if (item2.Binding != null)
					{
						list2.Add(item2.Binding);
					}
				}
				Dictionary<int, XElement> dictionary = new Dictionary<int, XElement>();
				foreach (XmlRebuildResult item3 in P_1.OrderByDescending((XmlRebuildResult item) => item.TableIndex))
				{
					XElement xElement = new XElement(item3.TableXml);
					list[item3.TableIndex - 1].ReplaceWith(xElement);
					dictionary[item3.TableIndex] = xElement;
				}
				foreach (TableBinding item4 in list2)
				{
					if (item4 != null)
					{
						ReplaceTableInDocument(xDocument2, item4.Id);
						UpdateTableRangeInXml(xDocument, GetBookmarkIdFromBinding(item4));
					}
				}
				int num = GetTableCountFromXml(xDocument);
				foreach (XmlRebuildResult item5 in P_1.OrderBy((XmlRebuildResult item) => item.TableIndex))
				{
					if (item5.Binding != null && dictionary.TryGetValue(item5.TableIndex, out var value))
					{
						string text = GetBookmarkIdFromBinding(item5.Binding);
						UpdateCellRangeInTable(item5.Binding, value, item5.TableIndex);
						UpdateTableBookmarksInXml(xDocument2, item5.Binding);
						UpdateTableCellId(value, text, num++);
					}
				}
				WriteDocumentPart(part, xDocument);
				WriteDocumentPart(part2, xDocument2);
			}
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("批量替换 Word document.xml 表格失败", ex);
			P_2 = ex.Message;
			return false;
		}
	}

	private static XDocument ReadDocumentPart(PackagePart P_0)
	{
		using Stream stream = P_0.GetStream(FileMode.Open, FileAccess.Read);
		return XDocument.Load(stream, LoadOptions.PreserveWhitespace);
	}

	private static void WriteDocumentPart(PackagePart P_0, XDocument P_1)
	{
		using Stream stream = P_0.GetStream(FileMode.Create, FileAccess.Write);
		using StreamWriter textWriter = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
		P_1.Save(textWriter, SaveOptions.DisableFormatting);
	}

	private static List<TableBinding> NeNYbSMjrx(XDocument P_0, XDocument P_1, ISet<int> P_2, ISet<string> P_3)
	{
		List<TableBinding> list = new List<TableBinding>();
		if (P_0?.Root == null || P_1?.Root == null || P_2 == null || P_2.Count == 0)
		{
			return list;
		}
		try
		{
			TableBindingContext bindingContext = new TableBindingContext();
			bindingContext.Bindings.AddRange(ParseBindingsFromXml(P_0));
			LoadTablesFromDocumentXml(P_1, bindingContext);
			foreach (TableBinding binding in bindingContext.Bindings)
			{
				if (binding == null || string.IsNullOrWhiteSpace(binding.Id))
				{
					continue;
				}
				if (P_3 != null && P_3.Contains(binding.Id))
				{
					list.Add(binding);
					continue;
				}
				bool flag;
				WordTableInfo xJSRGPVgVcylOerTScS = FindTableByBookmark(bindingContext, GetBookmarkIdFromBinding(binding), out flag);
				if (xJSRGPVgVcylOerTScS != null && P_2.Contains(xJSRGPVgVcylOerTScS.Index))
				{
					list.Add(binding);
				}
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[ExcelSync] Find bindings on updated XML tables failed: " + ex.Message);
		}
		return list;
	}

	private static void ReplaceTableInDocument(XDocument P_0, string P_1)
	{
		_G_c__DisplayClass367_0 CS_8_locals_3 = new _G_c__DisplayClass367_0();
		CS_8_locals_3.text = P_1;
		if (P_0?.Root == null || string.IsNullOrWhiteSpace(CS_8_locals_3.text))
		{
			return;
		}
		foreach (XElement item in (from element in P_0.Descendants(WordNamespace + "docVar")
			where string.Equals(GetAttributeValue(element, "COM 合并参数不完整"), CS_8_locals_3.text, StringComparison.OrdinalIgnoreCase)
			select element).ToList())
		{
			item.Remove();
		}
	}

	private static void UpdateTableBookmarksInXml(XDocument P_0, TableBinding P_1)
	{
		if (P_0?.Root == null || P_1 == null || string.IsNullOrWhiteSpace(P_1.Id))
		{
			return;
		}
		XElement xElement = P_0.Root.Descendants(WordNamespace + "docVars").FirstOrDefault();
		if (xElement == null)
		{
			xElement = new XElement(WordNamespace + "docVars");
			XElement xElement2 = P_0.Root.Element(WordNamespace + "rsids");
			if (xElement2 != null)
			{
				xElement2.AddBeforeSelf(xElement);
			}
			else
			{
				P_0.Root.Add(xElement);
			}
		}
		ReplaceTableInDocument(P_0, P_1.Id);
		xElement.Add(new XElement(WordNamespace + "docVar", new XAttribute(WordNamespace + "name", P_1.Id), new XAttribute(WordNamespace + "val", JsonConvert.SerializeObject(P_1))));
	}

	private static void UpdateTableRangeInXml(XDocument P_0, string P_1)
	{
		_G_c__DisplayClass369_0 CS_8_locals_5 = new _G_c__DisplayClass369_0();
		CS_8_locals_5.text = P_1;
		if (P_0?.Root == null || string.IsNullOrWhiteSpace(CS_8_locals_5.text))
		{
			return;
		}
		List<XElement> list = (from element in P_0.Descendants(WordNamespace + "bookmarkStart")
			where string.Equals(GetAttributeValue(element, "bookmarkEnd"), CS_8_locals_5.text, StringComparison.OrdinalIgnoreCase)
			select element).ToList();
		if (list.Count == 0)
		{
			return;
		}
		CS_8_locals_5.cellIds = new HashSet<string>(from element in list
			select GetAttributeValue(element, "无法定位 Word 单元格 R{0}C{1}") into id
			where !string.IsNullOrWhiteSpace(id)
			select id, StringComparer.OrdinalIgnoreCase);
		foreach (XElement item in list)
		{
			item.Remove();
		}
		foreach (XElement item2 in (from element in P_0.Descendants(WordNamespace + "无法定位 Word 合并终点 R{0}C{1}")
			where CS_8_locals_5.cellIds.Contains(GetAttributeValue(element, "合并 Word 单元格 R{0}C{1}:R{2}C{3} 失败：{4}"))
			select element).ToList())
		{
			item2.Remove();
		}
	}

	private static int GetTableCountFromXml(XDocument P_0)
	{
		int num = 0;
		if (P_0?.Root == null)
		{
			return 1;
		}
		foreach (XElement item in from element in P_0.Descendants()
			where element.Name == WordNamespace + "id" || element.Name == WordNamespace + "写入 Word 单元格 R{0}C{1} 失败：{2}"
			select element)
		{
			if (int.TryParse(GetAttributeValue(item, "未找到 Word COM 单元格 R{0}C{1}"), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
			{
				num = Math.Max(num, result);
			}
		}
		return num + 1;
	}

	private static void UpdateTableCellId(XElement P_0, string P_1, int P_2)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return;
		}
		string value = Math.Max(1, P_2).ToString(CultureInfo.InvariantCulture);
		XElement xElement = P_0.Descendants(WordNamespace + "tc").Elements(WordNamespace + "p").FirstOrDefault();
		if (xElement == null)
		{
			XElement xElement2 = P_0.Descendants(WordNamespace + "tc").FirstOrDefault();
			if (xElement2 == null)
			{
				return;
			}
			xElement = new XElement(WordNamespace + "p");
			xElement2.Add(xElement);
		}
		xElement.AddFirst(new XElement(WordNamespace + "bookmarkStart", new XAttribute(WordNamespace + "id", value), new XAttribute(WordNamespace + "name", P_1)));
		P_0.Add(new XElement(WordNamespace + "bookmarkEnd", new XAttribute(WordNamespace + "id", value)));
	}

	private static void UpdateCellRangeInTable(TableBinding P_0, XElement P_1, int P_2)
	{
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		try
		{
			if (string.IsNullOrWhiteSpace(P_0.WordBookmark))
			{
				P_0.WordBookmark = P_0.Id;
			}
			WordTableStructure hSmUUnVgKE1jrbUYMSFe2 = BuildTableStructureFromElement(P_1, P_2, 0);
			P_0.WordTableIndex = ((P_2 > 0) ? new int?(P_2) : ((int?)null));
			P_0.WordTableRows = ((hSmUUnVgKE1jrbUYMSFe2.RowCount > 0) ? new int?(hSmUUnVgKE1jrbUYMSFe2.RowCount) : ((int?)null));
			P_0.WordTableColumns = ((hSmUUnVgKE1jrbUYMSFe2.ColumnCount > 0) ? new int?(hSmUUnVgKE1jrbUYMSFe2.ColumnCount) : ((int?)null));
			P_0.WordSnapshotUpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[ExcelSync] Update binding snapshot from table XML failed: " + ex.Message);
		}
	}

	private static bool IsValidXmlName(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0) || !File.Exists(P_0))
		{
			return false;
		}
		string extension = Path.GetExtension(P_0);
		if (!string.Equals(extension, ".docx", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(extension, ".docm", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static string EscapeXmlName(string P_0)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(P_0);
		string extension = Path.GetExtension(P_0);
		string path = string.Format("{0}.cpah-excel-sync.{1:yyyyMMddHHmmssfff}{2}", fileNameWithoutExtension, DateTime.Now, extension);
		string text = Path.Combine(Path.GetTempPath(), path);
		File.Copy(P_0, text, overwrite: true);
		return text;
	}

	private static void WriteStringToFile(string P_0, string P_1)
	{
		try
		{
			if (!string.IsNullOrWhiteSpace(P_0) && File.Exists(P_0))
			{
				File.Copy(P_0, P_1, overwrite: true);
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("恢复 Word 包备份失败", ex);
		}
	}

	private static void DeleteTempFile(string P_0)
	{
		try
		{
			if (!string.IsNullOrWhiteSpace(P_0) && File.Exists(P_0))
			{
				File.Delete(P_0);
			}
		}
		catch
		{
		}
	}

	private static GridDimensionInfo BuildGridDimensions(ExcelTableStructure P_0)
	{
		GridDimensionInfo nFJBVfVi7oAZ3NU5nkMk2 = new GridDimensionInfo();
		if (P_0 == null)
		{
			return nFJBVfVi7oAZ3NU5nkMk2;
		}
		nFJBVfVi7oAZ3NU5nkMk2.RowCount = P_0.RowCount;
		nFJBVfVi7oAZ3NU5nkMk2.ColumnCount = P_0.ColumnCount;
		foreach (ExcelCellData cell in P_0.Cells)
		{
			nFJBVfVi7oAZ3NU5nkMk2.Cells.Add(string.Join(":", cell.RowIndex.ToString(CultureInfo.InvariantCulture), cell.ColumnIndex.ToString(CultureInfo.InvariantCulture), Math.Max(1, cell.RowSpan).ToString(CultureInfo.InvariantCulture), Math.Max(1, cell.ColumnSpan).ToString(CultureInfo.InvariantCulture)));
		}
		return nFJBVfVi7oAZ3NU5nkMk2;
	}

	private static bool CompareGridDimensions(GridDimensionInfo P_0, GridDimensionInfo P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return P_0 == P_1;
		}
		if (P_0.RowCount != P_1.RowCount || P_0.ColumnCount != P_1.ColumnCount)
		{
			return false;
		}
		if (P_0.Cells.Count != P_1.Cells.Count)
		{
			return false;
		}
		return P_0.Cells.SetEquals(P_1.Cells);
	}

	private static bool RebuildTableViaCom(Document P_0, Table P_1, ExcelTableStructure P_2, ExcelTableStructure P_3, TableBinding P_4, string[,] P_5, out Table P_6)
	{
		P_6 = null;
		if (P_0 == null || P_1 == null || P_3 == null || P_3.RowCount <= 0 || P_3.ColumnCount <= 0)
		{
			return false;
		}
		try
		{
			TableXmlProperties eyp1xWViqgWeojjBvqRB2 = BuildTableXmlProperties(P_2);
			XElement xElement = BuildTableXmlCore(P_3, P_5, eyp1xWViqgWeojjBvqRB2);
			TableRebuildResult rebuildResult = RebuildTableFromXml(P_0, P_1, xElement, P_4);
			P_6 = rebuildResult.Table;
			if (!rebuildResult.Success)
			{
				AiConfigBootstrap.LogWarn("[ExcelSync] Rebuild Word table from Excel structure with XML failed: " + (rebuildResult.Error ?? string.Empty));
			}
			return rebuildResult.Success && P_6 != null;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Rebuild Word table from Excel structure with XML failed", ex);
			P_6 = null;
			return false;
		}
	}

	private static TableXmlProperties BuildTableXmlProperties(ExcelTableStructure P_0)
	{
		TableXmlProperties eyp1xWViqgWeojjBvqRB2 = new TableXmlProperties();
		XElement xElement = P_0?.TableElement;
		if (xElement == null)
		{
			return eyp1xWViqgWeojjBvqRB2;
		}
		XElement xElement2 = xElement.Element(WordNamespace + "tblPr");
		if (xElement2 != null)
		{
			eyp1xWViqgWeojjBvqRB2.TableProperties = new XElement(xElement2);
			XElement xElement3 = xElement2.Element(WordNamespace + "tblW");
			if (string.Equals(GetAttributeValue(xElement3, "type"), "dxa", StringComparison.OrdinalIgnoreCase) && int.TryParse(GetAttributeValue(xElement3, "w"), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) && result > 0)
			{
				eyp1xWViqgWeojjBvqRB2.TableWidthDxa = result;
			}
		}
		XElement xElement4 = xElement.Element(WordNamespace + "tblGrid");
		if (xElement4 != null)
		{
			foreach (XElement item in xElement4.Elements(WordNamespace + "gridCol"))
			{
				if (int.TryParse(GetAttributeValue(item, "w"), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2) && result2 > 0)
				{
					eyp1xWViqgWeojjBvqRB2.GridWidths.Add(result2);
				}
			}
		}
		if (eyp1xWViqgWeojjBvqRB2.TableWidthDxa <= 0 && eyp1xWViqgWeojjBvqRB2.GridWidths.Count > 0)
		{
			eyp1xWViqgWeojjBvqRB2.TableWidthDxa = eyp1xWViqgWeojjBvqRB2.GridWidths.Where((int width) => width > 0).Sum();
		}
		int num = 0;
		foreach (XElement item2 in xElement.Elements(WordNamespace + "tr"))
		{
			num++;
			XElement xElement5 = item2.Element(WordNamespace + "trPr");
			if (xElement5 != null)
			{
				eyp1xWViqgWeojjBvqRB2.RowProperties[num] = new XElement(xElement5);
			}
		}
		if (P_0 != null)
		{
			foreach (ExcelCellData cell in P_0.Cells)
			{
				CellXmlProperties cellProps = ParseCellXmlProperties(cell.Element);
				if (cellProps != null)
				{
					eyp1xWViqgWeojjBvqRB2.Cells[BuildCellKey(cell.RowIndex, cell.ColumnIndex)] = cellProps;
					if (eyp1xWViqgWeojjBvqRB2.DefaultCell == null)
					{
						eyp1xWViqgWeojjBvqRB2.DefaultCell = cellProps;
					}
				}
			}
		}
		if (eyp1xWViqgWeojjBvqRB2.DefaultCell == null)
		{
			XElement xElement6 = xElement.Descendants(WordNamespace + "tc").FirstOrDefault();
			eyp1xWViqgWeojjBvqRB2.DefaultCell = ParseCellXmlProperties(xElement6) ?? new CellXmlProperties();
		}
		return eyp1xWViqgWeojjBvqRB2;
	}

	private static CellXmlProperties ParseCellXmlProperties(XElement P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		XElement xElement = GetTableCellPropertiesElement(P_0);
		XElement xElement2 = xElement?.Ancestors(WordNamespace + "p").FirstOrDefault() ?? P_0.Elements(WordNamespace + "p").FirstOrDefault();
		return new CellXmlProperties
		{
			TableCellProperties = GetTableRowElements(P_0.Element(WordNamespace + "tcPr")),
			ParagraphProperties = GetTableRowElements(xElement2?.Element(WordNamespace + "pPr")),
			RunProperties = GetTableRowElements(xElement?.Element(WordNamespace + "rPr"))
		};
	}

	private static XElement GetTableCellPropertiesElement(XElement P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		List<XElement> list = P_0.Descendants(WordNamespace + "r").ToList();
		if (list.Count == 0)
		{
			return null;
		}
		return list.FirstOrDefault((XElement run) => HasTableCellProperties(run) && run.Element(WordNamespace + "正在启动批量同步...") != null) ?? list.FirstOrDefault(HasTableCellProperties) ?? list.FirstOrDefault((XElement run) => run.Element(WordNamespace + "用户取消了同步。") != null) ?? list.FirstOrDefault();
	}

	private static bool HasTableCellProperties(XElement P_0)
	{
		return P_0?.Descendants().Any((XElement element) => element.Name == WordNamespace + "当前没有打开的 Word 文档。" || element.Name == WordNamespace + "批量 XML 同步仅支持已保存的 .docx/.docm 文档，请先保存当前 Word 文档后再试。" || element.Name == WordNamespace + "当前文档没有表格。" || element.Name == WordNamespace + "正在扫描 Word 表格绑定...") ?? false;
	}

	private static XElement BuildTableXmlCore(ExcelTableStructure P_0, string[,] P_1, TableXmlProperties P_2)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("excelStructure");
		}
		P_2 = P_2 ?? new TableXmlProperties();
		P_2.RebuildGridWidths.Clear();
		foreach (int item in BlaYxMZnHX(P_0.ColumnCount, P_2))
		{
			P_2.RebuildGridWidths.Add(item);
		}
		XElement xElement = new XElement(WordNamespace + "tbl", new XAttribute(XNamespace.Xmlns + "w", WordNamespace.NamespaceName));
		xElement.Add(CreateTableElement(P_2));
		xElement.Add(CreateTableGridElement(P_0.ColumnCount, P_2));
		List<ComplexCellPlan> source = BuildComplexCellPlans(P_0, P_1);
		using IEnumerator<int> enumerator = (from row in source.Select((ComplexCellPlan cell) => cell.RowIndex).Distinct()
			orderby row
			select row).GetEnumerator();
		while (enumerator.MoveNext())
		{
			_G_c__DisplayClass385_0 CS_8_locals_3 = new _G_c__DisplayClass385_0();
			CS_8_locals_3.value = enumerator.Current;
			XElement xElement2 = new XElement(WordNamespace + "tr");
			XElement xElement3 = CreateGridColElement(P_2, CS_8_locals_3.value);
			if (xElement3 != null)
			{
				RemoveChildElements(xElement3, "gridBefore", "gridAfter", "wBefore", "wAfter");
				xElement2.Add(xElement3);
			}
			int num = 0;
			foreach (ComplexCellPlan item2 in from cell in source
				where cell.RowIndex == CS_8_locals_3.value && cell.XmlShowCell
				orderby cell.Sequence
				select cell)
			{
				num++;
				xElement2.Add(CreateComplexCellElement(item2, num, P_2));
			}
			xElement.Add(xElement2);
		}
		return xElement;
	}

	private static List<ComplexCellPlan> BuildComplexCellPlans(ExcelTableStructure P_0, string[,] P_1)
	{
		List<ComplexCellPlan> list = new List<ComplexCellPlan>();
		Dictionary<string, ComplexCellPlan> dictionary = new Dictionary<string, ComplexCellPlan>(StringComparer.Ordinal);
		int num = 0;
		for (int i = 1; i <= P_0.RowCount; i++)
		{
			int num2 = 0;
			for (int j = 1; j <= P_0.ColumnCount; j++)
			{
				num++;
				ExcelCellData oy5QGFVitTDJtPXLAlDX2;
				if (P_0.TryGetCell(i, j, out var cellData))
				{
					num2++;
					ComplexCellPlan cellPlan = new ComplexCellPlan
					{
						Sequence = num,
						RowIndex = i,
						ColumnIndex = j,
						WordColumnIndex = num2,
						MergeStartRowIndex = i,
						MergeStartWordColumnIndex = num2,
						RowSpan = Math.Max(1, cellData.RowSpan),
						ColumnSpan = Math.Max(1, cellData.ColumnSpan),
						Text = GetCellValueFromGrid(P_1, i, j),
						IsMergeStart = (cellData.RowSpan > 1 || cellData.ColumnSpan > 1),
						XmlShowCell = true
					};
					list.Add(cellPlan);
					if (cellPlan.IsMergeStart)
					{
						dictionary[BuildCellKey(i, j)] = cellPlan;
					}
				}
				else if (P_0.TryGetMergedCell(i, j, out oy5QGFVitTDJtPXLAlDX2))
				{
					dictionary.TryGetValue(BuildCellKey(oy5QGFVitTDJtPXLAlDX2.RowIndex, oy5QGFVitTDJtPXLAlDX2.ColumnIndex), out var value);
					int num3 = value?.WordColumnIndex ?? num2;
					num2 = num3;
					bool flag = oy5QGFVitTDJtPXLAlDX2.RowSpan > 1 && i > oy5QGFVitTDJtPXLAlDX2.RowIndex && j == oy5QGFVitTDJtPXLAlDX2.ColumnIndex;
					ComplexCellPlan item = new ComplexCellPlan
					{
						Sequence = num,
						RowIndex = i,
						ColumnIndex = j,
						WordColumnIndex = num3,
						MergeStartRowIndex = oy5QGFVitTDJtPXLAlDX2.RowIndex,
						MergeStartWordColumnIndex = num3,
						RowSpan = (flag ? 999 : Math.Max(1, oy5QGFVitTDJtPXLAlDX2.RowSpan)),
						ColumnSpan = Math.Max(1, oy5QGFVitTDJtPXLAlDX2.ColumnSpan),
						Text = string.Empty,
						IsMergeStart = false,
						IsVerticalContinuation = flag,
						XmlShowCell = flag
					};
					list.Add(item);
				}
				else
				{
					num2++;
					list.Add(new ComplexCellPlan
					{
						Sequence = num,
						RowIndex = i,
						ColumnIndex = j,
						WordColumnIndex = num2,
						MergeStartRowIndex = i,
						MergeStartWordColumnIndex = num2,
						RowSpan = 1,
						ColumnSpan = 1,
						Text = GetCellValueFromGrid(P_1, i, j),
						XmlShowCell = true
					});
				}
			}
		}
		return list;
	}

	private static TableRebuildResult RebuildTableFromXml(Document P_0, Table P_1, XElement P_2, TableBinding P_3)
	{
		TableRebuildResult rebuildResult = new TableRebuildResult();
		if (P_0 == null || P_1 == null || P_2 == null || P_3 == null)
		{
			rebuildResult.Error = "替换参数不完整";
			return rebuildResult;
		}
		string text = string.Empty;
		bool flag = false;
		try
		{
			int num = GetTableIndexInDocument(P_0, P_1);
			int num2 = GetTableBodyRowCount(P_2);
			if (num <= 0)
			{
				rebuildResult.Error = "无法确定绑定表在当前文档中的序号";
				return rebuildResult;
			}
			text = Convert.ToString(P_0.FullName);
			if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(Convert.ToString(P_0.Path)))
			{
				rebuildResult.Error = "当前 Word 文档尚未保存，复杂表结构重建需要先保存文档。";
				return rebuildResult;
			}
			P_0.Save();
			CloseDocument(P_0);
			flag = true;
			if (!TryValidateTableCell(text, num, P_2, num2, out var error))
			{
				OpenDocument(text);
				rebuildResult.Error = error;
				return rebuildResult;
			}
			Document document = OpenDocument(text);
			Table table = null;
			if (document.Tables.Count >= num)
			{
				table = document.Tables[num];
			}
			if (table == null)
			{
				rebuildResult.Error = "包级替换后未找到新表格";
				return rebuildResult;
			}
			RemoveTableBookmark(document, table, P_3);
			document.Save();
			rebuildResult.Success = true;
			rebuildResult.Table = table;
			return rebuildResult;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Replace Word table with XML failed", ex);
			rebuildResult.Error = ex.Message;
			if (flag && !string.IsNullOrWhiteSpace(text))
			{
				try
				{
					OpenDocument(text);
				}
				catch
				{
				}
			}
			return rebuildResult;
		}
	}

	private static int GetTableBodyRowCount(XElement P_0)
	{
		try
		{
			return (P_0?.Element(WordNamespace + "tblGrid")?.Elements(WordNamespace + "gridCol").Count()).GetValueOrDefault();
		}
		catch
		{
			return 0;
		}
	}

	private static void CloseDocument(Document P_0)
	{
		object SaveChanges = WdSaveOptions.wdSaveChanges;
		object OriginalFormat = Type.Missing;
		object RouteDocument = false;
		P_0.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
	}

	private static Document OpenDocument(string P_0)
	{
		Documents documents = App.Documents;
		object FileName = P_0;
		object ConfirmConversions = Type.Missing;
		object ReadOnly = false;
		object AddToRecentFiles = false;
		object PasswordDocument = Type.Missing;
		object PasswordTemplate = Type.Missing;
		object Revert = Type.Missing;
		object WritePasswordDocument = Type.Missing;
		object WritePasswordTemplate = Type.Missing;
		object Format = Type.Missing;
		object Encoding = Type.Missing;
		object Visible = true;
		object OpenAndRepair = Type.Missing;
		object DocumentDirection = Type.Missing;
		object NoEncodingDialog = Type.Missing;
		object XMLTransform = Type.Missing;
		return documents.Open(ref FileName, ref ConfirmConversions, ref ReadOnly, ref AddToRecentFiles, ref PasswordDocument, ref PasswordTemplate, ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format, ref Encoding, ref Visible, ref OpenAndRepair, ref DocumentDirection, ref NoEncodingDialog, ref XMLTransform);
	}

	private static bool TryValidateTableCell(string P_0, int P_1, XElement P_2, int P_3, out string P_4)
	{
		P_4 = string.Empty;
		if (string.IsNullOrWhiteSpace(P_0) || P_1 <= 0 || P_2 == null)
		{
			P_4 = "包级替换参数不完整";
			return false;
		}
		try
		{
			Uri partUri = PackUriHelper.CreatePartUri(new Uri("/word/document.xml", UriKind.Relative));
			using (Package package = Package.Open(P_0, FileMode.Open, FileAccess.ReadWrite))
			{
				if (!package.PartExists(partUri))
				{
					P_4 = "Word 包中未找到 /word/document.xml";
					return false;
				}
				PackagePart part = package.GetPart(partUri);
				XDocument xDocument;
				using (Stream stream = part.GetStream(FileMode.Open, FileAccess.Read))
				{
					xDocument = XDocument.Load(stream, LoadOptions.PreserveWhitespace);
				}
				List<XElement> list = xDocument.Descendants(WordNamespace + "tbl").ToList();
				if (P_1 > list.Count)
				{
					P_4 = string.Format(CultureInfo.InvariantCulture, "Word 包中表格数量不足：目标序号 {0}，实际数量 {1}", P_1, list.Count);
					return false;
				}
				XElement xElement = new XElement(P_2);
				list[P_1 - 1].ReplaceWith(xElement);
				SetTableCellText(xElement, P_3);
				using Stream stream2 = part.GetStream(FileMode.Create, FileAccess.Write);
				using StreamWriter textWriter = new StreamWriter(stream2, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
				xDocument.Save(textWriter, SaveOptions.DisableFormatting);
			}
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Replace table in Word package failed", ex);
			P_4 = "包级替换 Word 表格失败：" + ex.Message;
			return false;
		}
	}

	private static void SetTableCellText(XElement P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return;
		}
		string text = GetElementConcatenatedText(P_0);
		if (string.IsNullOrWhiteSpace(text))
		{
			return;
		}
		foreach (XElement item in P_0.ElementsAfterSelf())
		{
			if (!(item.Name == WordNamespace + "p") || !string.IsNullOrWhiteSpace(GetTableCellText(item)))
			{
				if (!(item.Name != WordNamespace + "tbl") && GetTableBodyRowCount(item) == P_1 && string.Equals(text, GetElementConcatenatedText(item), StringComparison.Ordinal))
				{
					item.Remove();
				}
				break;
			}
		}
	}

	private static string GetElementConcatenatedText(XElement P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return NormalizeText(string.Concat(from element in P_0.Descendants(WordNamespace + "t")
			select element.Value ?? string.Empty));
	}

	private static string NormalizeText(string P_0)
	{
		P_0 = (P_0 ?? string.Empty).Replace('\r', ' ').Replace('\n', ' ').Replace('\a', ' ')
			.Replace('\t', ' ')
			.Trim();
		while (P_0.Contains("  "))
		{
			P_0 = P_0.Replace(" ", "  ");
		}
		return P_0;
	}

	private static XElement GetDocumentBodyElement(XDocument P_0)
	{
		if (P_0?.Root == null)
		{
			return null;
		}
		if (P_0.Root.Name == WordNamespace + "tbl")
		{
			return P_0.Root;
		}
		if (P_0.Root.Name == WordNamespace + "document")
		{
			return P_0.Root.Descendants(WordNamespace + "tbl").FirstOrDefault();
		}
		XElement xElement = (P_0.Root.Elements(XmlPackageNamespace + "part").FirstOrDefault((XElement element) => string.Equals((string)element.Attribute(XmlPackageNamespace + "xmlData"), "tbl", StringComparison.OrdinalIgnoreCase))?.Element(XmlPackageNamespace + "tbl")?.Elements().FirstOrDefault())?.Descendants(WordNamespace + "用户取消了同步。").FirstOrDefault();
		if (xElement != null)
		{
			return xElement;
		}
		return P_0.Descendants(WordNamespace + "用户取消了同步。").FirstOrDefault();
	}

	private static XElement CreateTableGridElement(int P_0, TableXmlProperties P_1)
	{
		XElement xElement = new XElement(WordNamespace + "tblGrid");
		for (int i = 1; i <= Math.Max(1, P_0); i++)
		{
			xElement.Add(new XElement(WordNamespace + "gridCol", new XAttribute(WordNamespace + "w", GetGridColCount2(P_1, i).ToString(CultureInfo.InvariantCulture))));
		}
		return xElement;
	}

	private static XElement CreateTableElement(TableXmlProperties P_0)
	{
		XElement xElement = GetTableRowElements(P_0?.TableProperties) ?? new XElement(WordNamespace + "tblPr");
		RemoveChildElements(xElement, "tblW");
		xElement.AddFirst(new XElement(WordNamespace + "tblW", new XAttribute(WordNamespace + "w", "5000"), new XAttribute(WordNamespace + "type", "pct")));
		if (!xElement.Elements(WordNamespace + "tblLayout").Any())
		{
			xElement.Add(new XElement(WordNamespace + "tblLayout", new XAttribute(WordNamespace + "type", "fixed")));
		}
		return xElement;
	}

	private static IEnumerable<int> BlaYxMZnHX(int P_0, TableXmlProperties P_1)
	{
		P_0 = Math.Max(1, P_0);
		int num = GetGridColumnCount(P_1, P_0);
		List<int> list = new List<int>();
		if (P_1?.GridWidths != null && P_1.GridWidths.Count > 0)
		{
			list.AddRange(P_1.GridWidths.Where((int width) => width > 0));
		}
		if (list.Count == 0)
		{
			list.Add(num);
		}
		int num2 = (int)Math.Round(list.DefaultIfEmpty(num).Average());
		if (num2 <= 0)
		{
			num2 = Math.Max(1, num / P_0);
		}
		while (list.Count < P_0)
		{
			list.Add(num2);
		}
		if (list.Count > P_0)
		{
			list = list.Take(P_0).ToList();
		}
		int num3 = list.Sum();
		if (num3 <= 0)
		{
			num3 = P_0;
		}
		List<int> list2 = new List<int>();
		int num4 = 0;
		for (int num5 = 0; num5 < P_0; num5++)
		{
			int num6 = (int)Math.Round((double)list[num5] * (double)num / (double)num3);
			if (num6 <= 0)
			{
				num6 = 1;
			}
			list2.Add(num6);
			num4 += num6;
		}
		list2[list2.Count - 1] = Math.Max(1, list2[list2.Count - 1] + num - num4);
		return list2;
	}

	private static XElement CreateComplexCellElement(ComplexCellPlan P_0, int P_1, TableXmlProperties P_2)
	{
		CellXmlProperties cellProps = GetDefaultCellFormat(P_2, P_0.RowIndex, P_0.ColumnIndex);
		XElement xElement = CreateComplexCellWithProperties(cellProps, P_2, P_0, P_1);
		XElement xElement2 = CreateCellWithText(cellProps, P_0.Text);
		return new XElement(WordNamespace + "tc", xElement, xElement2);
	}

	private static XElement CreateCellElement(ExcelCellData P_0, string P_1, TableXmlProperties P_2, bool P_3, bool P_4)
	{
		CellXmlProperties cellProps = GetDefaultCellFormat(P_2, P_0.RowIndex, P_0.ColumnIndex);
		XElement xElement = CreateCellWithProperties(cellProps, P_2, P_0, P_3, P_4);
		XElement xElement2 = CreateCellWithText(cellProps, P_1);
		return new XElement(WordNamespace + "tc", xElement, xElement2);
	}

	private static XElement CreateComplexCellWithProperties(CellXmlProperties P_0, TableXmlProperties P_1, ComplexCellPlan P_2, int P_3)
	{
		XElement xElement = GetTableRowElements(P_0?.TableCellProperties) ?? new XElement(WordNamespace + "tcPr");
		RemoveChildElements(xElement, "tcW", "gridSpan", "hMerge", "vMerge");
		xElement.AddFirst(new XElement(WordNamespace + "tcW", new XAttribute(WordNamespace + "w", GetColumnWidthByIndex(P_1, P_2.ColumnIndex, Math.Max(1, P_2.ColumnSpan)).ToString(CultureInfo.InvariantCulture)), new XAttribute(WordNamespace + "type", "dxa")));
		if (P_2.ColumnSpan > 1)
		{
			xElement.Add(new XElement(WordNamespace + "gridSpan", new XAttribute(WordNamespace + "val", P_2.ColumnSpan.ToString(CultureInfo.InvariantCulture))));
		}
		if (P_2.IsMergeStart && P_2.RowSpan > 1)
		{
			xElement.Add(new XElement(WordNamespace + "vMerge", new XAttribute(WordNamespace + "val", "restart")));
		}
		else if (P_2.IsVerticalContinuation)
		{
			xElement.Add(new XElement(WordNamespace + "vMerge", new XAttribute(WordNamespace + "val", "continue")));
		}
		if (!xElement.Elements(WordNamespace + "vAlign").Any())
		{
			xElement.Add(new XElement(WordNamespace + "vAlign", new XAttribute(WordNamespace + "val", "center")));
		}
		return xElement;
	}

	private static XElement CreateCellWithProperties(CellXmlProperties P_0, TableXmlProperties P_1, ExcelCellData P_2, bool P_3, bool P_4)
	{
		XElement xElement = GetTableRowElements(P_0?.TableCellProperties) ?? new XElement(WordNamespace + "tcPr");
		RemoveChildElements(xElement, "tcW", "gridSpan", "hMerge", "vMerge");
		xElement.AddFirst(new XElement(WordNamespace + "tcW", new XAttribute(WordNamespace + "w", GetColumnWidthByIndex(P_1, P_2.ColumnIndex, Math.Max(1, P_2.ColumnSpan)).ToString(CultureInfo.InvariantCulture)), new XAttribute(WordNamespace + "type", "dxa")));
		if (P_2.ColumnSpan > 1)
		{
			xElement.Add(new XElement(WordNamespace + "gridSpan", new XAttribute(WordNamespace + "val", P_2.ColumnSpan.ToString(CultureInfo.InvariantCulture))));
		}
		if (P_3)
		{
			xElement.Add(new XElement(WordNamespace + "vMerge", new XAttribute(WordNamespace + "val", "restart")));
		}
		else if (P_4)
		{
			xElement.Add(new XElement(WordNamespace + "vMerge", new XAttribute(WordNamespace + "val", "continue")));
		}
		return xElement;
	}

	private static XElement CreateCellWithText(CellXmlProperties P_0, string P_1)
	{
		XElement xElement = new XElement(WordNamespace + "p");
		XElement xElement2 = GetTableRowElements(P_0?.ParagraphProperties);
		if (xElement2 != null)
		{
			xElement.Add(xElement2);
		}
		XElement xElement3 = new XElement(WordNamespace + "r");
		XElement xElement4 = GetTableRowElements(P_0?.RunProperties) ?? new XElement(WordNamespace + "rPr");
		ApplyRunProperties(xElement4, P_0);
		xElement3.Add(xElement4);
		ApplyBordersToCell(xElement3, P_1 ?? string.Empty);
		xElement.Add(xElement3);
		return xElement;
	}

	private static void ApplyCellProperties(XElement P_0, CellXmlProperties P_1)
	{
		if (P_0 != null)
		{
			XElement xElement = P_0.Element(WordNamespace + "rPr");
			if (xElement == null)
			{
				xElement = GetTableRowElements(P_1?.RunProperties) ?? new XElement(WordNamespace + "rPr");
				P_0.AddFirst(xElement);
			}
			ApplyRunProperties(xElement, P_1);
		}
	}

	private static void ApplyRunProperties(XElement P_0, CellXmlProperties P_1)
	{
		if (P_0 != null)
		{
			XElement xElement = P_0.Element(WordNamespace + "rFonts");
			XElement xElement2 = P_1?.ParagraphProperties?.Element(WordNamespace + "rPr")?.Element(WordNamespace + "rFonts");
			XElement xElement3 = P_1?.RunProperties?.Element(WordNamespace + "rFonts");
			if (xElement == null)
			{
				xElement = GetTableRowElements(xElement3) ?? GetTableRowElements(xElement2) ?? new XElement(WordNamespace + "rFonts");
				P_0.AddFirst(xElement);
			}
			string text = BuildBorderElement("表格_段落格式_中文字体", "宋体");
			string text2 = BuildBorderElement("表格_段落格式_西文字体", "宋体");
			SetCellWidthAttribute(xElement, "ascii", text2);
			SetCellWidthAttribute(xElement, "hAnsi", text2);
			SetCellWidthAttribute(xElement, "eastAsia", text);
			SetCellWidthAttribute(xElement, "cs", text);
			SetCellVerticalAlignment(P_0, GetDefaultBorderXml());
		}
	}

	private static void SetCellWidthAttribute(XElement P_0, string P_1, string P_2)
	{
		if (P_0 != null && !string.IsNullOrWhiteSpace(P_1) && !string.IsNullOrWhiteSpace(P_2))
		{
			P_0.SetAttributeValue(WordNamespace + P_1, P_2.Trim());
		}
	}

	private static void SetCellVerticalAlignment(XElement P_0, string P_1)
	{
		if (P_0 != null && !string.IsNullOrWhiteSpace(P_1))
		{
			SetCellMargins(P_0, "sz", P_1);
			SetCellMargins(P_0, "szCs", P_1);
		}
	}

	private static void SetCellMargins(XElement P_0, string P_1, string P_2)
	{
		XElement xElement = P_0.Element(WordNamespace + P_1);
		if (xElement == null)
		{
			P_0.Add(new XElement(WordNamespace + P_1, new XAttribute(WordNamespace + "val", P_2)));
		}
		else
		{
			xElement.SetAttributeValue(WordNamespace + "val", P_2);
		}
	}

	private static string BuildBorderElement(string P_0, string P_1)
	{
		try
		{
			return TableBorderConfig.Current.GetString(P_0, P_1);
		}
		catch
		{
			return P_1;
		}
	}

	private static string GetDefaultBorderXml()
	{
		double num = AiHelper_20.GetConfigFontSize(BuildBorderElement("表格_段落格式_字号", "9"), 9.0);
		return Math.Max(1, (int)Math.Round(num * 2.0, MidpointRounding.AwayFromZero)).ToString(CultureInfo.InvariantCulture);
	}

	private static void ApplyBordersToCell(XElement P_0, string P_1)
	{
		string[] array = P_1.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
		for (int i = 0; i < array.Length; i++)
		{
			if (i > 0)
			{
				P_0.Add(new XElement(WordNamespace + "br"));
			}
			P_0.Add(new XElement(WordNamespace + "t", new XAttribute(XNamespace.Xml + "space", "preserve"), array[i]));
		}
	}

	private static CellXmlProperties GetDefaultCellFormat(TableXmlProperties P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return null;
		}
		if (P_0.Cells.TryGetValue(BuildCellKey(P_1, P_2), out var value))
		{
			return value;
		}
		for (int num = P_1 - 1; num >= 1; num--)
		{
			if (P_0.Cells.TryGetValue(BuildCellKey(num, P_2), out value))
			{
				return value;
			}
		}
		for (int num2 = P_2 - 1; num2 >= 1; num2--)
		{
			if (P_0.Cells.TryGetValue(BuildCellKey(P_1, num2), out value))
			{
				return value;
			}
		}
		for (int i = P_1 + 1; i <= P_0.RowProperties.Count + 1; i++)
		{
			if (P_0.Cells.TryGetValue(BuildCellKey(i, P_2), out value))
			{
				return value;
			}
		}
		return P_0.DefaultCell;
	}

	private static XElement CreateGridColElement(TableXmlProperties P_0, int P_1)
	{
		if (P_0 == null)
		{
			return null;
		}
		if (P_0.RowProperties.TryGetValue(P_1, out var value))
		{
			return new XElement(value);
		}
		if (P_1 > 1 && P_0.RowProperties.TryGetValue(P_1 - 1, out value))
		{
			return new XElement(value);
		}
		if (P_0.RowProperties.TryGetValue(1, out value))
		{
			return new XElement(value);
		}
		return null;
	}

	private static int GetColumnWidthByIndex(TableXmlProperties P_0, int P_1, int P_2)
	{
		int num = 0;
		for (int i = P_1; i < P_1 + Math.Max(1, P_2); i++)
		{
			num += GetGridColCount2(P_0, i);
		}
		if (num <= 0)
		{
			return 2000 * Math.Max(1, P_2);
		}
		return num;
	}

	private static int GetGridColCount2(TableXmlProperties P_0, int P_1)
	{
		if (P_0?.RebuildGridWidths != null && P_1 > 0 && P_1 <= P_0.RebuildGridWidths.Count)
		{
			return P_0.RebuildGridWidths[P_1 - 1];
		}
		return GetGridColumnCountCore(P_0, P_1);
	}

	private static int GetGridColumnCount(TableXmlProperties P_0, int P_1)
	{
		if (P_0 != null)
		{
			if (P_0.TableWidthDxa > 0)
			{
				return P_0.TableWidthDxa;
			}
			int num = P_0.GridWidths.Where((int width) => width > 0).Sum();
			if (num > 0)
			{
				return num;
			}
		}
		return 2000 * Math.Max(1, P_1);
	}

	private static int GetGridColumnCountCore(TableXmlProperties P_0, int P_1)
	{
		if (P_0 != null && P_0.GridWidths.Count > 0)
		{
			if (P_1 > 0 && P_1 <= P_0.GridWidths.Count)
			{
				return P_0.GridWidths[P_1 - 1];
			}
			int num = P_0.GridWidths.LastOrDefault();
			if (num > 0)
			{
				return num;
			}
			int num2 = (int)Math.Round(P_0.GridWidths.Where((int width) => width > 0).DefaultIfEmpty(2000).Average());
			if (num2 > 0)
			{
				return num2;
			}
		}
		return 2000;
	}

	private static string GetCellValueFromGrid(string[,] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 < 0 || P_2 < 0 || P_1 >= P_0.GetLength(0) || P_2 >= P_0.GetLength(1))
		{
			return string.Empty;
		}
		return P_0[P_1, P_2] ?? string.Empty;
	}

	private static XElement GetTableRowElements(XElement P_0)
	{
		if (P_0 != null)
		{
			return new XElement(P_0);
		}
		return null;
	}

	private static void RemoveChildElements(XElement P_0, params string[] localNames)
	{
		_G_c__DisplayClass420_0 CS_8_locals_2 = new _G_c__DisplayClass420_0();
		if (P_0 != null && localNames != null && localNames.Length != 0)
		{
			CS_8_locals_2.elementNames = new HashSet<string>(localNames, StringComparer.Ordinal);
			(from element in P_0.Elements()
				where CS_8_locals_2.elementNames.Contains(element.Name.LocalName)
				select element).Remove();
		}
	}

	internal static bool ValidateBindingForSync(TableBindingStatus P_0)
	{
		string text;
		bool flag;
		return ValidateBindingForSyncInternal(P_0, out text, out flag);
	}

	internal static bool ValidateBindingForSyncInternal(TableBindingStatus P_0, out string P_1, out bool P_2)
	{
		P_1 = string.Empty;
		P_2 = false;
		if (P_0 == null)
		{
			P_1 = "请先选择一个绑定关系。";
			P_2 = true;
			return false;
		}
		if (P_0.Binding == null || string.IsNullOrWhiteSpace(P_0.Binding.WordBookmark))
		{
			SaveBindingToDocumentVar(P_0);
			P_1 = "表格锚点丢失，无法定位 Word 表格。";
			P_2 = true;
			return false;
		}
		try
		{
			Document activeDocument = App.ActiveDocument;
			string wordBookmark = P_0.Binding.WordBookmark;
			if (!activeDocument.Bookmarks.Exists(wordBookmark))
			{
				SaveBindingToDocumentVar(P_0);
				P_1 = "表格锚点丢失，无法定位 Word 表格。";
				P_2 = true;
				return false;
			}
			Bookmarks bookmarks = activeDocument.Bookmarks;
			object Index = wordBookmark;
			Microsoft.Office.Interop.Word.Range range = bookmarks[ref Index].Range;
			range.Select();
			try
			{
				Microsoft.Office.Interop.Word.Window activeWindow = App.ActiveWindow;
				Index = true;
				activeWindow.ScrollIntoView(range, ref Index);
			}
			catch
			{
			}
			RemoveBindingFromDocumentVar(P_0);
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[ExcelSync] Jump to Word binding failed", ex);
			P_1 = "定位 Word 表格失败，请确认绑定书签仍然存在。";
			P_2 = true;
			return false;
		}
	}

	private static void SaveBindingToDocumentVar(TableBindingStatus P_0)
	{
		if (P_0 != null)
		{
			P_0.Status = "表格锚点丢失";
			P_0.ErrorMessage = "表格锚点丢失";
			P_0.CanJumpWord = false;
			P_0.CanSync = false;
		}
	}

	private static void RemoveBindingFromDocumentVar(TableBindingStatus P_0)
	{
		if (P_0 != null)
		{
			P_0.Status = "正常";
			P_0.ErrorMessage = string.Empty;
			P_0.CanJumpWord = true;
			P_0.CanSync = P_0.CanJumpExcel;
		}
	}

	private static bool TryFindBoundTable(TableBindingStatus P_0, out Table P_1, out int P_2)
	{
		P_1 = null;
		P_2 = 0;
		if (P_0 == null)
		{
			return false;
		}
		Document activeDocument = App.ActiveDocument;
		if (TryFindTableByBookmarkId(activeDocument, P_0.Binding.WordBookmark, out P_1, out P_2, out var _))
		{
			return true;
		}
		if (P_0.Table != null)
		{
			P_1 = P_0.Table;
			P_2 = GetTableIndexInDocument(activeDocument, P_1);
			return P_2 > 0;
		}
		return false;
	}

	private static bool TryFindTableByBookmarkId(Document P_0, string P_1, out Table P_2, out int P_3, out bool P_4)
	{
		P_2 = null;
		P_3 = 0;
		P_4 = false;
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		try
		{
			P_4 = P_0.Bookmarks.Exists(P_1);
			if (!P_4)
			{
				return false;
			}
			Bookmarks bookmarks = P_0.Bookmarks;
			object Index = P_1;
			Microsoft.Office.Interop.Word.Range range = bookmarks[ref Index].Range;
			for (int i = 1; i <= P_0.Tables.Count; i++)
			{
				Table table = P_0.Tables[i];
				Microsoft.Office.Interop.Word.Range range2 = table.Range;
				if (range.Start <= range2.End && range.End >= range2.Start)
				{
					P_2 = table;
					P_3 = i;
					return true;
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private static int GetTableIndexInDocument(Document P_0, Table P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return 0;
		}
		try
		{
			int start = P_1.Range.Start;
			int end = P_1.Range.End;
			for (int i = 1; i <= P_0.Tables.Count; i++)
			{
				Microsoft.Office.Interop.Word.Range range = P_0.Tables[i].Range;
				if (range.Start == start && range.End == end)
				{
					return i;
				}
			}
		}
		catch
		{
		}
		return 0;
	}

	private static bool IsTableInDocument(Document P_0, string P_1)
	{
		try
		{
			return !string.IsNullOrWhiteSpace(P_1) && P_0.Bookmarks.Exists(P_1);
		}
		catch
		{
			return false;
		}
	}

	private static Table GetActiveTable()
	{
		try
		{
			if (App.Selection == null || App.Selection.Tables.Count == 0)
			{
				return null;
			}
			return App.Selection.Tables[1];
		}
		catch
		{
			return null;
		}
	}

	private static bool AreStructuresCompatible(ExcelTableStructure P_0, ExcelTableStructure P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		if (P_0.Merges.Count <= 0 && P_1.Merges.Count <= 0 && !P_0.HasVerticalMerge)
		{
			return false;
		}
		return !CompareGridDimensions(BuildGridDimensions(P_0), BuildGridDimensions(P_1));
	}

	private static bool WriteTableRowViaCom(Table P_0, int P_1, int P_2, ExcelTableStructure P_3, string[,] P_4, int P_5)
	{
		P_1 = Math.Max(1, P_1);
		P_2 = Math.Max(0, P_2);
		int num = GetEffectiveColumnCount(P_3, P_2);
		if (TryGetTableRowCount(P_0, out var num2) && ValidateAndWriteRow(P_0, num2, P_1, P_2, P_3, num))
		{
			return true;
		}
		num2 = P_3?.RowCount ?? num2;
		if (num2 <= 0)
		{
			return false;
		}
		return ValidateAndWriteRowCore(P_0, num2, P_1, P_2, P_3, num);
	}

	private static int GetEffectiveColumnCount(ExcelTableStructure P_0, int P_1)
	{
		if (P_0 == null || P_0.RowCount <= Math.Max(1, P_1))
		{
			return 0;
		}
		int num = Math.Max(2, P_1 + 1);
		for (int num2 = P_0.RowCount; num2 >= num; num2--)
		{
			if (IsHeaderRowText(GetColumnHeaderText(P_0, num2)))
			{
				return num2;
			}
		}
		return 0;
	}

	private static bool IsRowAllEmpty(string[,] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 1 || P_0.GetLength(0) <= P_1)
		{
			return false;
		}
		int num = P_0.GetLength(1) - 1;
		for (int i = 1; i <= num; i++)
		{
			string text = P_0[P_1, i];
			if (!string.IsNullOrWhiteSpace(text))
			{
				return IsHeaderRowText(text);
			}
		}
		return false;
	}

	private static string GetColumnHeaderText(ExcelTableStructure P_0, int P_1)
	{
		int num = int.MaxValue;
		string result = string.Empty;
		foreach (ExcelCellData cell in P_0.Cells)
		{
			if (cell.RowIndex == P_1 && cell.ColumnIndex < num && !string.IsNullOrWhiteSpace(cell.Text))
			{
				num = cell.ColumnIndex;
				result = cell.Text;
			}
		}
		return result;
	}

	private static bool IsHeaderRowText(string P_0)
	{
		string text = NormalizeHeaderRowText(P_0);
		if (!text.StartsWith("合计", StringComparison.Ordinal) && !text.StartsWith("总计", StringComparison.Ordinal))
		{
			return text.StartsWith("小计", StringComparison.Ordinal);
		}
		return true;
	}

	private static string NormalizeHeaderRowText(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return string.Empty;
		}
		return P_0.Replace("\\r", string.Empty).Replace("\n", string.Empty).Replace("\\t", string.Empty)
			.Replace("", string.Empty)
			.Replace(" ", string.Empty)
			.Replace("　", string.Empty)
			.Replace(":", string.Empty)
			.Replace("：", string.Empty)
			.Trim();
	}

	[Conditional("DEBUG")]
	private static void CopyValuesToArray(ExcelTableStructure P_0, string[,] P_1, int P_2, int P_3, int P_4, int P_5)
	{
		try
		{
			if (P_0 == null || P_0.RowCount <= 0)
			{
				_ = string.Empty;
			}
			else
			{
				GetColumnHeaderText(P_0, P_0.RowCount);
			}
			if (P_5 <= 0)
			{
				_ = string.Empty;
			}
			else
			{
				GetColumnHeaderText(P_0, P_5);
			}
			GetRowValues(P_1, P_2);
			IsRowAllEmpty(P_1, P_2);
		}
		catch
		{
		}
	}

	[Conditional("DEBUG")]
	private static void WriteCellToTable(string P_0, Table P_1, ExcelTableStructure P_2, int P_3, int P_4, int P_5, int P_6, int P_7)
	{
		try
		{
		}
		catch
		{
		}
	}

	private static string GetRowValues(string[,] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0 || P_0.GetLength(0) <= P_1)
		{
			return string.Empty;
		}
		int num = P_0.GetLength(1) - 1;
		for (int i = 1; i <= num; i++)
		{
			string text = P_0[P_1, i];
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
		}
		return string.Empty;
	}

	private static string GetCellDisplayValue(Table P_0, ExcelTableStructure P_1, int P_2)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return "row=" + P_2 + ":invalid";
		}
		List<string> list = new List<string>();
		int num = Math.Max(1, P_1?.ColumnCount ?? GetTableColumnCount(P_0));
		for (int i = 1; i <= num; i++)
		{
			if (list.Count >= 4)
			{
				break;
			}
			if (TryGetCellAtPosition(P_0, P_2, i, out var cell))
			{
				string text = string.Empty;
				try
				{
					Microsoft.Office.Interop.Word.Range duplicate = cell.Range.Duplicate;
					duplicate.End = Math.Max(duplicate.Start, duplicate.End - 1);
					text = CleanCellText(duplicate.Text);
				}
				catch
				{
				}
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				try
				{
					num2 = (int)cell.Range.Font.Underline;
				}
				catch
				{
				}
				try
				{
					num3 = (int)cell.Borders[WdBorderType.wdBorderBottom].LineStyle;
				}
				catch
				{
				}
				try
				{
					num4 = (int)cell.Borders[WdBorderType.wdBorderTop].LineStyle;
				}
				catch
				{
				}
				if (!string.IsNullOrWhiteSpace(text) || num2 != 0 || num3 != 0 || num4 != 0)
				{
					list.Add(string.Format("C{0}:\"{1}\",U={2},Top={3},Bottom={4}", i, NormalizePath(text), num2, num4, num3));
				}
			}
		}
		return string.Format("row={0}[{1}]", P_2, string.Join(" | ", list));
	}

	private static bool ValidateAndWriteRow(Table P_0, int P_1, int P_2, int P_3, ExcelTableStructure P_4, int P_5)
	{
		Microsoft.Office.Interop.Word.Range range = null;
		bool flag = false;
		try
		{
			range = App.Selection?.Range?.Duplicate;
		}
		catch
		{
		}
		try
		{
			while (P_1 < P_2)
			{
				if (P_5 > 0)
				{
					int num = ComputeColumnOffset(P_1, P_3, P_5);
					if (!RemoveEmptyRowsByHeader(P_0, num, P_4))
					{
						return false;
					}
					if (P_5 > num)
					{
						P_5++;
					}
					flag = true;
				}
				else
				{
					Rows rows = P_0.Rows;
					object BeforeRow = Type.Missing;
					rows.Add(ref BeforeRow);
				}
				P_1++;
			}
			int num2 = Math.Max(1, P_3);
			while (P_1 > P_2 && P_1 > num2)
			{
				int num3 = ComputeColumnOffsetAlt(P_1, P_3, P_5);
				if (num3 <= num2)
				{
					break;
				}
				P_0.Rows[num3].Delete();
				if (P_5 > num3)
				{
					P_5--;
				}
				P_1--;
			}
			return P_1 == P_2;
		}
		catch
		{
			return false;
		}
		finally
		{
			if (flag)
			{
				try
				{
					range?.Select();
				}
				catch
				{
				}
			}
		}
	}

	private static bool ValidateAndWriteRowCore(Table P_0, int P_1, int P_2, int P_3, ExcelTableStructure P_4, int P_5)
	{
		Microsoft.Office.Interop.Word.Range range = null;
		try
		{
			range = App.Selection?.Range?.Duplicate;
		}
		catch
		{
		}
		try
		{
			int num = Math.Max(1, P_3);
			while (P_1 > P_2 && P_1 > num)
			{
				int num2 = ComputeColumnOffsetAlt(P_1, P_3, P_5);
				if (num2 <= num)
				{
					break;
				}
				if (!RemoveEmptyRows(P_0, num2, P_4))
				{
					return false;
				}
				if (P_5 > num2)
				{
					P_5--;
				}
				P_1--;
			}
			while (P_1 < P_2)
			{
				int num3 = ComputeColumnOffset(P_1, P_3, P_5);
				if (!RemoveEmptyRowsByHeader(P_0, num3, P_4))
				{
					return false;
				}
				if (P_5 > num3)
				{
					P_5++;
				}
				P_1++;
			}
			return P_1 == P_2;
		}
		catch
		{
			return false;
		}
		finally
		{
			try
			{
				range?.Select();
			}
			catch
			{
			}
		}
	}

	private static int ComputeColumnOffset(int P_0, int P_1, int P_2)
	{
		P_0 = Math.Max(1, P_0);
		P_1 = Math.Max(0, P_1);
		if (P_2 <= 0)
		{
			return P_0;
		}
		int num = Math.Min(P_0, P_2) - 1;
		if (num > P_1)
		{
			return num;
		}
		if (P_1 > 0)
		{
			return Math.Min(P_0, P_1);
		}
		return P_0;
	}

	private static int ComputeColumnOffsetAlt(int P_0, int P_1, int P_2)
	{
		P_0 = Math.Max(1, P_0);
		P_1 = Math.Max(0, P_1);
		if (P_2 <= 0)
		{
			return P_0;
		}
		int num = Math.Min(P_0, P_2) - 1;
		if (num <= P_1)
		{
			return 0;
		}
		return num;
	}

	private static bool RemoveEmptyRows(Table P_0, int P_1, ExcelTableStructure P_2)
	{
		try
		{
			if (!TryGetCellForValidation(P_0, P_1, P_2, out var cell))
			{
				return false;
			}
			cell.Select();
			object selection = App.Selection;
			try
			{
				if (_G_o__445.deleteCallSite_Tc6 == null)
				{
					_G_o__445.deleteCallSite_Tc6 = CallSite<Action<CallSite, object, WdDeleteCells>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Delete", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Action<CallSite, object, WdDeleteCells> target = _G_o__445.deleteCallSite_Tc6.Target;
				CallSite<Action<CallSite, object, WdDeleteCells>> deleteCallSite_Tc6 = _G_o__445.deleteCallSite_Tc6;
				if (_G_o__445.toObjectCallSite_Tc22 == null)
				{
					_G_o__445.toObjectCallSite_Tc22 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Cells", typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target(deleteCallSite_Tc6, _G_o__445.toObjectCallSite_Tc22.Target(_G_o__445.toObjectCallSite_Tc22, selection), WdDeleteCells.wdDeleteCellsEntireRow);
			}
			catch
			{
				if (_G_o__445.deleteCallSite_Tc4 == null)
				{
					_G_o__445.deleteCallSite_Tc4 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Delete", null, typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Action<CallSite, object> target2 = _G_o__445.deleteCallSite_Tc4.Target;
				CallSite<Action<CallSite, object>> deleteCallSite_Tc4 = _G_o__445.deleteCallSite_Tc4;
				if (_G_o__445.toObjectCallSite_Tc20 == null)
				{
					_G_o__445.toObjectCallSite_Tc20 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Rows", typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target2(deleteCallSite_Tc4, _G_o__445.toObjectCallSite_Tc20.Target(_G_o__445.toObjectCallSite_Tc20, selection));
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool RemoveEmptyRowsByHeader(Table P_0, int P_1, ExcelTableStructure P_2)
	{
		try
		{
			if (!TryGetCellForValidation(P_0, P_1, P_2, out var cell))
			{
				return false;
			}
			cell.Select();
			object selection = App.Selection;
			if (_G_o__446.insertRowsBelowCallSite_Tc2 == null)
			{
				_G_o__446.insertRowsBelowCallSite_Tc2 = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertRowsBelow", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			_G_o__446.insertRowsBelowCallSite_Tc2.Target(_G_o__446.insertRowsBelowCallSite_Tc2, selection, 1);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool TryGetCellForValidation(Table P_0, int P_1, ExcelTableStructure P_2, out Cell P_3)
	{
		P_3 = null;
		if (P_1 <= 0)
		{
			return false;
		}
		if (P_2 != null)
		{
			foreach (int item in P_2.GetColumnIndicesInRow(P_1))
			{
				try
				{
					P_3 = P_0.Cell(P_1, item);
					return true;
				}
				catch
				{
				}
			}
		}
		int num = Math.Max(1, P_2?.ColumnCount ?? GetTableColumnCount(P_0));
		for (int i = 1; i <= num; i++)
		{
			try
			{
				P_3 = P_0.Cell(P_1, i);
				return true;
			}
			catch
			{
			}
		}
		return false;
	}

	private static bool RemoveEmptyRowsWrapper(Table P_0, int P_1, ExcelTableStructure P_2)
	{
		P_1 = Math.Max(1, P_1);
		int num = P_2?.ColumnCount ?? GetTableColumnCount(P_0);
		if (num <= 0)
		{
			num = GetTableColumnCount(P_0);
		}
		if (num <= 0)
		{
			return false;
		}
		return RemoveEmptyRowsByRange(P_0, num, P_1, P_2);
	}

	private static bool RemoveEmptyRowsByRange(Table P_0, int P_1, int P_2, ExcelTableStructure P_3)
	{
		Microsoft.Office.Interop.Word.Range range = null;
		try
		{
			range = App.Selection?.Range?.Duplicate;
		}
		catch
		{
		}
		try
		{
			while (P_1 < P_2)
			{
				if (!RemoveLastEmptyRows(P_0, P_1, P_3))
				{
					return false;
				}
				P_1++;
			}
			while (P_1 > P_2 && P_1 > 1)
			{
				if (!TryDeleteTableColumn(P_0, P_1, P_3))
				{
					return false;
				}
				P_1--;
			}
			return P_1 == P_2;
		}
		catch
		{
			return false;
		}
		finally
		{
			try
			{
				range?.Select();
			}
			catch
			{
			}
		}
	}

	private static bool RemoveLastEmptyRows(Table P_0, int P_1, ExcelTableStructure P_2)
	{
		try
		{
			if (!TryFindCellInTable(P_0, P_1, P_2, out var cell))
			{
				return false;
			}
			cell.Select();
			object selection = App.Selection;
			if (_G_o__450.insertColumnsRightCallSite_Tc1 == null)
			{
				_G_o__450.insertColumnsRightCallSite_Tc1 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertColumnsRight", null, typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			_G_o__450.insertColumnsRightCallSite_Tc1.Target(_G_o__450.insertColumnsRightCallSite_Tc1, selection);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool TryDeleteTableColumn(Table P_0, int P_1, ExcelTableStructure P_2)
	{
		try
		{
			if (!TryFindCellInTable(P_0, P_1, P_2, out var cell))
			{
				return false;
			}
			cell.Select();
			object selection = App.Selection;
			if (_G_o__451.deleteCallSite_Tc1 == null)
			{
				_G_o__451.deleteCallSite_Tc1 = CallSite<Action<CallSite, object, WdDeleteCells>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Delete", null, typeof(TableComWriteService), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Action<CallSite, object, WdDeleteCells> target = _G_o__451.deleteCallSite_Tc1.Target;
			CallSite<Action<CallSite, object, WdDeleteCells>> deleteCallSite = _G_o__451.deleteCallSite_Tc1;
			if (_G_o__451.toObjectCallSite_Tc11 == null)
			{
				_G_o__451.toObjectCallSite_Tc11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Cells", typeof(TableComWriteService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(deleteCallSite, _G_o__451.toObjectCallSite_Tc11.Target(_G_o__451.toObjectCallSite_Tc11, selection), WdDeleteCells.wdDeleteCellsEntireColumn);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool TryFindCellInTable(Table P_0, int P_1, ExcelTableStructure P_2, out Cell P_3)
	{
		P_3 = null;
		if (P_1 <= 0)
		{
			return false;
		}
		if (P_2 != null)
		{
			foreach (ExcelCellData item in GetCellsByColumn(P_2, P_1))
			{
				try
				{
					P_3 = P_0.Cell(item.RowIndex, item.ColumnIndex);
					return true;
				}
				catch
				{
				}
			}
		}
		int num = P_2?.RowCount ?? 0;
		if (num <= 0)
		{
			TryGetTableRowCount(P_0, out num);
		}
		for (int i = 1; i <= num; i++)
		{
			try
			{
				P_3 = P_0.Cell(i, P_1);
				return true;
			}
			catch
			{
			}
		}
		return false;
	}

	private static IEnumerable<ExcelCellData> GetCellsByColumn(ExcelTableStructure P_0, int P_1)
	{
		_G_c__DisplayClass453_0 CS_8_locals_7 = new _G_c__DisplayClass453_0();
		CS_8_locals_7.MC7V3RVTZCT = P_1;
		if (P_0 == null)
		{
			yield break;
		}
		HashSet<string> yielded = new HashSet<string>(StringComparer.Ordinal);
		CS_8_locals_7.value = Math.Max(0, P_0.HeaderRowCount);
		foreach (ExcelCellData item in from item in P_0.Cells
			where item.ColumnIndex == CS_8_locals_7.MC7V3RVTZCT && item.ColumnSpan == 1 && item.RowIndex > CS_8_locals_7.value
			orderby item.RowIndex
			select item)
		{
			if (yielded.Add(BuildCellKey(item.RowIndex, item.ColumnIndex)))
			{
				yield return item;
			}
		}
		foreach (ExcelCellData item2 in from item in P_0.Cells
			where item.ColumnIndex == CS_8_locals_7.MC7V3RVTZCT && item.ColumnSpan == 1
			orderby item.RowIndex
			select item)
		{
			if (yielded.Add(BuildCellKey(item2.RowIndex, item2.ColumnIndex)))
			{
				yield return item2;
			}
		}
		foreach (ExcelCellData item3 in from item in P_0.Cells
			where item.ColumnIndex <= CS_8_locals_7.MC7V3RVTZCT && CS_8_locals_7.MC7V3RVTZCT < item.ColumnIndex + Math.Max(1, item.ColumnSpan)
			orderby item.ColumnSpan, item.RowIndex
			select item)
		{
			if (yielded.Add(BuildCellKey(item3.RowIndex, item3.ColumnIndex)))
			{
				yield return item3;
			}
		}
	}

	private static bool TryGetTableRowCount(Table P_0, out int P_1)
	{
		P_1 = 0;
		try
		{
			P_1 = P_0.Rows.Count;
			return P_1 > 0;
		}
		catch
		{
			return false;
		}
	}

	private static bool TrySetCellTextAt(Table P_0, int P_1, int P_2, string P_3, out string P_4)
	{
		P_4 = string.Empty;
		try
		{
			return TrySetCellText(P_0.Cell(P_1, P_2), P_3, out P_4);
		}
		catch (Exception ex)
		{
			P_4 = ex.GetType().Name + ": " + ex.Message;
			return false;
		}
	}

	private static bool TrySetCellText(Cell P_0, string P_1, out string P_2)
	{
		P_2 = string.Empty;
		try
		{
			string text = P_1 ?? string.Empty;
			Microsoft.Office.Interop.Word.Range duplicate = P_0.Range.Duplicate;
			duplicate.End = Math.Max(duplicate.Start, duplicate.End - 1);
			if (string.Equals(CleanCellText(duplicate.Text), text, StringComparison.Ordinal))
			{
				return true;
			}
			duplicate.Text = text;
			return true;
		}
		catch (Exception ex)
		{
			P_2 = ex.GetType().Name + ": " + ex.Message;
			return false;
		}
	}

	private static string CleanCellText(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return string.Empty;
		}
		return P_0.TrimEnd('\r', '\a');
	}

	static TableComWriteService()
	{
		SseStreamInitializer.InitializeRuntime();
		WordNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
		XmlPackageNamespace = "http://schemas.microsoft.com/office/2006/xmlPackage";
		SpreadsheetNamespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
		RelationshipsNamespace = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
	}
}
