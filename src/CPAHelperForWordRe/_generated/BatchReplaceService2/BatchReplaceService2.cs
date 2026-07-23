using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using WordWindowInfo;
using WordAgentRuntimeGuard2;
using AiSseStreamService3;
using AiTargetBinder;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using AiHelper_14;
using WordTableToolService4;
using DocumentLifecycleGuard;
using AiHelper_5;

namespace BatchReplaceService2;

internal sealed class BatchReplaceService2
{
	private sealed class DocumentSearchContext : IDisposable
	{
		[CompilerGenerated]
		private string jaNddUrZIG;

		[CompilerGenerated]
		private string xObdzUoZXM;

		[CompilerGenerated]
		private bool _documentSaved;

		[CompilerGenerated]
		private bool _trackRevisions;

		[CompilerGenerated]
		private SelectionRangeInfo ROgzBRlrSw;

		[CompilerGenerated]
		private Dictionary<string, int> dict1;

		[CompilerGenerated]
		private readonly List<ParagraphInfo> _documentName1;

		[CompilerGenerated]
		private readonly List<DocumentContextInfo> _documentName2;

		[CompilerGenerated]
		private List<CommentInfo> _comments;

		[CompilerGenerated]
		private readonly List<DocumentBlock> _documentName5;

		public string DocumentName
		{
			[CompilerGenerated]
			get
			{
				return jaNddUrZIG;
			}
			[CompilerGenerated]
			set
			{
				jaNddUrZIG = value;
			}
		}

		public string DocumentFullName
		{
			[CompilerGenerated]
			get
			{
				return xObdzUoZXM;
			}
			[CompilerGenerated]
			set
			{
				xObdzUoZXM = value;
			}
		}

		public bool DocumentSaved
		{
			[CompilerGenerated]
			get
			{
				return _documentSaved;
			}
			[CompilerGenerated]
			set
			{
				_documentSaved = value;
			}
		}

		public bool TrackRevisions
		{
			[CompilerGenerated]
			get
			{
				return _trackRevisions;
			}
			[CompilerGenerated]
			set
			{
				_trackRevisions = value;
			}
		}

		public SelectionRangeInfo Selection
		{
			[CompilerGenerated]
			get
			{
				return ROgzBRlrSw;
			}
			[CompilerGenerated]
			set
			{
				ROgzBRlrSw = value;
			}
		}

		public Dictionary<string, int> StyleOutlineLevels
		{
			[CompilerGenerated]
			get
			{
				return dict1;
			}
			[CompilerGenerated]
			set
			{
				dict1 = value;
			}
		}

		public List<ParagraphInfo> Paragraphs
		{
			[CompilerGenerated]
			get
			{
				return _documentName1;
			}
		}

		public List<DocumentContextInfo> Tables
		{
			[CompilerGenerated]
			get
			{
				return _documentName2;
			}
		}

		public List<CommentInfo> Comments
		{
			[CompilerGenerated]
			get
			{
				return _comments;
			}
			[CompilerGenerated]
			set
			{
				_comments = value;
			}
		}

		public List<DocumentBlock> Blocks
		{
			[CompilerGenerated]
			get
			{
				return _documentName5;
			}
		}

		public static DocumentSearchContext hhudkjcOIs(DocumentContextSnapshot P_0)
		{
			DocumentSearchContext searchContextInstance = new DocumentSearchContext
			{
				DocumentName = P_0.DocumentName,
				DocumentFullName = P_0.DocumentFullName,
				DocumentSaved = P_0.DocumentSaved,
				TrackRevisions = P_0.TrackRevisions,
				Selection = P_0.Selection
			};
			XDocument xDocument = ParseXmlDocument(P_0.WordOpenXml);
			searchContextInstance.StyleOutlineLevels = UPQrbSvBKH(xDocument);
			searchContextInstance.Comments = wpmrwTxSHp(xDocument);
			XElement xElement = (ParseXmlPart(xDocument, "/word/document.xml") ?? throw new InvalidDataException("word/document.xml not found.")).Root?.Element(wordNamespace + "body");
			if (xElement != null)
			{
				foreach (XElement item in xElement.Elements())
				{
					if (item.Name == wordNamespace + "p")
					{
						AddParagraphFromXml(searchContextInstance, item);
					}
					else if (item.Name == wordNamespace + "tbl")
					{
						AddTableFromXml(searchContextInstance, item);
					}
				}
			}
			return searchContextInstance;
		}

		private static XDocument ParseXmlDocument(string P_0)
		{
			if (string.IsNullOrWhiteSpace(P_0))
			{
				throw new InvalidDataException("Word content snapshot is empty.");
			}
			return XDocument.Parse(P_0);
		}

		public void Dispose()
		{
		}

		public DocumentSearchContext()
		{
			SseStreamInitializer.InitializeRuntime();
			_documentName1 = new List<ParagraphInfo>();
			_documentName2 = new List<DocumentContextInfo>();
			_documentName5 = new List<DocumentBlock>();
		}
	}

	private sealed class SelectionRangeInfo
	{
		[CompilerGenerated]
		private int DdFzIxjyKw;

		[CompilerGenerated]
		private int IMrzixgipR;

		[CompilerGenerated]
		private string TiLzHOGdgo;

		public int RangeStart
		{
			[CompilerGenerated]
			get
			{
				return DdFzIxjyKw;
			}
			[CompilerGenerated]
			set
			{
				DdFzIxjyKw = value;
			}
		}

		public int RangeEnd
		{
			[CompilerGenerated]
			get
			{
				return IMrzixgipR;
			}
			[CompilerGenerated]
			set
			{
				IMrzixgipR = value;
			}
		}

		public string Text
		{
			[CompilerGenerated]
			get
			{
				return TiLzHOGdgo;
			}
			[CompilerGenerated]
			set
			{
				TiLzHOGdgo = value;
			}
		}

		public static SelectionRangeInfo CaptureSelectionRange(Application P_0)
		{
			try
			{
				Selection selection = P_0?.Selection;
				if (selection == null || selection.Range == null)
				{
					return null;
				}
				return new SelectionRangeInfo
				{
					RangeStart = selection.Range.Start,
					RangeEnd = selection.Range.End,
					Text = CleanCellText(selection.Range.Text)
				};
			}
			catch
			{
				return null;
			}
		}

		public SelectionRangeInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class DocumentContextSnapshot
	{
		[CompilerGenerated]
		private AiHelper_5 _error;

		[CompilerGenerated]
		private string tmEzrjwGwQ;

		[CompilerGenerated]
		private string _documentFullName;

		[CompilerGenerated]
		private string _documentKey;

		[CompilerGenerated]
		private bool _documentSaved;

		[CompilerGenerated]
		private bool _trackRevisions;

		[CompilerGenerated]
		private SelectionRangeInfo _selection;

		[CompilerGenerated]
		private string _wordOpenXml;

		public AiHelper_5 Error
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

		public string DocumentName
		{
			[CompilerGenerated]
			get
			{
				return tmEzrjwGwQ;
			}
			[CompilerGenerated]
			set
			{
				tmEzrjwGwQ = value;
			}
		}

		public string DocumentFullName
		{
			[CompilerGenerated]
			get
			{
				return _documentFullName;
			}
			[CompilerGenerated]
			set
			{
				_documentFullName = value;
			}
		}

		public string DocumentKey
		{
			[CompilerGenerated]
			get
			{
				return _documentKey;
			}
			[CompilerGenerated]
			set
			{
				_documentKey = value;
			}
		}

		public bool DocumentSaved
		{
			[CompilerGenerated]
			get
			{
				return _documentSaved;
			}
			[CompilerGenerated]
			set
			{
				_documentSaved = value;
			}
		}

		public bool TrackRevisions
		{
			[CompilerGenerated]
			get
			{
				return _trackRevisions;
			}
			[CompilerGenerated]
			set
			{
				_trackRevisions = value;
			}
		}

		public SelectionRangeInfo Selection
		{
			[CompilerGenerated]
			get
			{
				return _selection;
			}
			[CompilerGenerated]
			set
			{
				_selection = value;
			}
		}

		public string WordOpenXml
		{
			[CompilerGenerated]
			get
			{
				return _wordOpenXml;
			}
			[CompilerGenerated]
			set
			{
				_wordOpenXml = value;
			}
		}

		public DocumentContextSnapshot()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class DocumentOperationResult
	{
		[CompilerGenerated]
		private AiHelper_5 _error;

		[CompilerGenerated]
		private string _documentName;

		[CompilerGenerated]
		private string _documentFullName;

		[CompilerGenerated]
		private bool _documentSaved;

		[CompilerGenerated]
		private int OgYzMuEEkU;

		[CompilerGenerated]
		private int _rangeEnd;

		[CompilerGenerated]
		private string qZKzSpIHZU;

		public AiHelper_5 Error
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

		public string DocumentName
		{
			[CompilerGenerated]
			get
			{
				return _documentName;
			}
			[CompilerGenerated]
			set
			{
				_documentName = value;
			}
		}

		public string DocumentFullName
		{
			[CompilerGenerated]
			get
			{
				return _documentFullName;
			}
			[CompilerGenerated]
			set
			{
				_documentFullName = value;
			}
		}

		public bool DocumentSaved
		{
			[CompilerGenerated]
			get
			{
				return _documentSaved;
			}
			[CompilerGenerated]
			set
			{
				_documentSaved = value;
			}
		}

		public int RangeStart
		{
			[CompilerGenerated]
			get
			{
				return OgYzMuEEkU;
			}
			[CompilerGenerated]
			set
			{
				OgYzMuEEkU = value;
			}
		}

		public int RangeEnd
		{
			[CompilerGenerated]
			get
			{
				return _rangeEnd;
			}
			[CompilerGenerated]
			set
			{
				_rangeEnd = value;
			}
		}

		public string WordOpenXml
		{
			[CompilerGenerated]
			get
			{
				return qZKzSpIHZU;
			}
			[CompilerGenerated]
			set
			{
				qZKzSpIHZU = value;
			}
		}

		public DocumentOperationResult()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class RangeReadResult
	{
		[CompilerGenerated]
		private AiHelper_5 _error;

		[CompilerGenerated]
		private string dapzLUMilH;

		[CompilerGenerated]
		private string _documentFullName;

		[CompilerGenerated]
		private bool _documentSaved;

		[CompilerGenerated]
		private int _rangeStart;

		[CompilerGenerated]
		private int ghnzmeBYED;

		[CompilerGenerated]
		private int _totalTablesInRange;

		[CompilerGenerated]
		private readonly List<TableStructureInfo> _error;

		public AiHelper_5 Error
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

		public string DocumentName
		{
			[CompilerGenerated]
			get
			{
				return dapzLUMilH;
			}
			[CompilerGenerated]
			set
			{
				dapzLUMilH = value;
			}
		}

		public string DocumentFullName
		{
			[CompilerGenerated]
			get
			{
				return _documentFullName;
			}
			[CompilerGenerated]
			set
			{
				_documentFullName = value;
			}
		}

		public bool DocumentSaved
		{
			[CompilerGenerated]
			get
			{
				return _documentSaved;
			}
			[CompilerGenerated]
			set
			{
				_documentSaved = value;
			}
		}

		public int RangeStart
		{
			[CompilerGenerated]
			get
			{
				return _rangeStart;
			}
			[CompilerGenerated]
			set
			{
				_rangeStart = value;
			}
		}

		public int RangeEnd
		{
			[CompilerGenerated]
			get
			{
				return ghnzmeBYED;
			}
			[CompilerGenerated]
			set
			{
				ghnzmeBYED = value;
			}
		}

		public int TotalTablesInRange
		{
			[CompilerGenerated]
			get
			{
				return _totalTablesInRange;
			}
			[CompilerGenerated]
			set
			{
				_totalTablesInRange = value;
			}
		}

		public List<TableStructureInfo> Tables
		{
			[CompilerGenerated]
			get
			{
				return _error;
			}
		}

		public RangeReadResult()
		{
			SseStreamInitializer.InitializeRuntime();
			_error = new List<TableStructureInfo>();
		}
	}

	private sealed class TableStructureInfo
	{
		[CompilerGenerated]
		private int iiDzpOXUGO;

		[CompilerGenerated]
		private int _rangeStart;

		[CompilerGenerated]
		private int YqOznlIqMg;

		[CompilerGenerated]
		private int _page;

		[CompilerGenerated]
		private string _wordOpenXml;

		[CompilerGenerated]
		private readonly List<TableCellInfo> fpdzcWHnZP;

		public int LocalTableIndex
		{
			[CompilerGenerated]
			get
			{
				return iiDzpOXUGO;
			}
			[CompilerGenerated]
			set
			{
				iiDzpOXUGO = value;
			}
		}

		public int RangeStart
		{
			[CompilerGenerated]
			get
			{
				return _rangeStart;
			}
			[CompilerGenerated]
			set
			{
				_rangeStart = value;
			}
		}

		public int RangeEnd
		{
			[CompilerGenerated]
			get
			{
				return YqOznlIqMg;
			}
			[CompilerGenerated]
			set
			{
				YqOznlIqMg = value;
			}
		}

		public int Page
		{
			[CompilerGenerated]
			get
			{
				return _page;
			}
			[CompilerGenerated]
			set
			{
				_page = value;
			}
		}

		public string WordOpenXml
		{
			[CompilerGenerated]
			get
			{
				return _wordOpenXml;
			}
			[CompilerGenerated]
			set
			{
				_wordOpenXml = value;
			}
		}

		public List<TableCellInfo> Cells
		{
			[CompilerGenerated]
			get
			{
				return fpdzcWHnZP;
			}
		}

		public TableStructureInfo()
		{
			SseStreamInitializer.InitializeRuntime();
			fpdzcWHnZP = new List<TableCellInfo>();
		}
	}

	private sealed class TableCellInfo
	{
		[CompilerGenerated]
		private int _rowIndex;

		[CompilerGenerated]
		private int _columnIndex;

		[CompilerGenerated]
		private int _rangeStart;

		[CompilerGenerated]
		private int NDozhxDxfG;

		[CompilerGenerated]
		private int qfCzaKdWTS;

		[CompilerGenerated]
		private string _text;

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

		public int RangeStart
		{
			[CompilerGenerated]
			get
			{
				return _rangeStart;
			}
			[CompilerGenerated]
			set
			{
				_rangeStart = value;
			}
		}

		public int RangeEnd
		{
			[CompilerGenerated]
			get
			{
				return NDozhxDxfG;
			}
			[CompilerGenerated]
			set
			{
				NDozhxDxfG = value;
			}
		}

		public int Page
		{
			[CompilerGenerated]
			get
			{
				return qfCzaKdWTS;
			}
			[CompilerGenerated]
			set
			{
				qfCzaKdWTS = value;
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

		public TableCellInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class TableRangeInfo
	{
		[CompilerGenerated]
		private int _rangeStart;

		[CompilerGenerated]
		private int QMqzvfUvvJ;

		public int RangeStart
		{
			[CompilerGenerated]
			get
			{
				return _rangeStart;
			}
			[CompilerGenerated]
			set
			{
				_rangeStart = value;
			}
		}

		public int RangeEnd
		{
			[CompilerGenerated]
			get
			{
				return QMqzvfUvvJ;
			}
			[CompilerGenerated]
			set
			{
				QMqzvfUvvJ = value;
			}
		}

		public TableRangeInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class MergedCellRange
	{
		[CompilerGenerated]
		private int _startRow;

		[CompilerGenerated]
		private int _startColumn;

		[CompilerGenerated]
		private int mOTzxhxmBC;

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
				return mOTzxhxmBC;
			}
			[CompilerGenerated]
			set
			{
				mOTzxhxmBC = value;
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

		public MergedCellRange()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class ParagraphInfo
	{
		[CompilerGenerated]
		private int count4;

		[CompilerGenerated]
		private string SUQVRVJLgrU;

		[CompilerGenerated]
		private bool _isHeading;

		[CompilerGenerated]
		private int _outlineLevel;

		public int ParagraphIndex
		{
			[CompilerGenerated]
			get
			{
				return count4;
			}
			[CompilerGenerated]
			set
			{
				count4 = value;
			}
		}

		public string Text
		{
			[CompilerGenerated]
			get
			{
				return SUQVRVJLgrU;
			}
			[CompilerGenerated]
			set
			{
				SUQVRVJLgrU = value;
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

		public int OutlineLevel
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

		public ParagraphInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class DocumentContextInfo
	{
		[CompilerGenerated]
		private string _documentName;

		[CompilerGenerated]
		private string _documentFullName;

		[CompilerGenerated]
		private bool _documentSaved;

		[CompilerGenerated]
		private int yrEVRgwrSdk;

		[CompilerGenerated]
		private int _firstParagraphIndex;

		[CompilerGenerated]
		private string _altTextTitle;

		[CompilerGenerated]
		private string _altTextDescription;

		[CompilerGenerated]
		private readonly List<List<string>> _documentName3;

		[CompilerGenerated]
		private readonly List<TableCellData> FptVRQWDyfr;

		[CompilerGenerated]
		private bool _hasMergedCells;

		[CompilerGenerated]
		private string SZAVRrQwPut;

		public string DocumentName
		{
			[CompilerGenerated]
			get
			{
				return _documentName;
			}
			[CompilerGenerated]
			set
			{
				_documentName = value;
			}
		}

		public string DocumentFullName
		{
			[CompilerGenerated]
			get
			{
				return _documentFullName;
			}
			[CompilerGenerated]
			set
			{
				_documentFullName = value;
			}
		}

		public bool DocumentSaved
		{
			[CompilerGenerated]
			get
			{
				return _documentSaved;
			}
			[CompilerGenerated]
			set
			{
				_documentSaved = value;
			}
		}

		public int TableIndex
		{
			[CompilerGenerated]
			get
			{
				return yrEVRgwrSdk;
			}
			[CompilerGenerated]
			set
			{
				yrEVRgwrSdk = value;
			}
		}

		public int FirstParagraphIndex
		{
			[CompilerGenerated]
			get
			{
				return _firstParagraphIndex;
			}
			[CompilerGenerated]
			set
			{
				_firstParagraphIndex = value;
			}
		}

		public string AltTextTitle
		{
			[CompilerGenerated]
			get
			{
				return _altTextTitle;
			}
			[CompilerGenerated]
			set
			{
				_altTextTitle = value;
			}
		}

		public string AltTextDescription
		{
			[CompilerGenerated]
			get
			{
				return _altTextDescription;
			}
			[CompilerGenerated]
			set
			{
				_altTextDescription = value;
			}
		}

		public List<List<string>> Matrix
		{
			[CompilerGenerated]
			get
			{
				return _documentName3;
			}
		}

		public List<TableCellData> Cells
		{
			[CompilerGenerated]
			get
			{
				return FptVRQWDyfr;
			}
		}

		public bool HasMergedCells
		{
			[CompilerGenerated]
			get
			{
				return _hasMergedCells;
			}
			[CompilerGenerated]
			set
			{
				_hasMergedCells = value;
			}
		}

		public string RawText
		{
			[CompilerGenerated]
			get
			{
				return SZAVRrQwPut;
			}
			[CompilerGenerated]
			set
			{
				SZAVRrQwPut = value;
			}
		}

		public DocumentContextInfo()
		{
			SseStreamInitializer.InitializeRuntime();
			_documentName3 = new List<List<string>>();
			FptVRQWDyfr = new List<TableCellData>();
		}
	}

	private sealed class TableCellData
	{
		[CompilerGenerated]
		private int _cellIndex;

		[CompilerGenerated]
		private int BIXVRUDjiDx;

		[CompilerGenerated]
		private int _columnIndex;

		[CompilerGenerated]
		private int _rowSpan;

		[CompilerGenerated]
		private int _columnSpan;

		[CompilerGenerated]
		private string _text;

		public int CellIndex
		{
			[CompilerGenerated]
			get
			{
				return _cellIndex;
			}
			[CompilerGenerated]
			set
			{
				_cellIndex = value;
			}
		}

		public int RowIndex
		{
			[CompilerGenerated]
			get
			{
				return BIXVRUDjiDx;
			}
			[CompilerGenerated]
			set
			{
				BIXVRUDjiDx = value;
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

		public TableCellData()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class CommentInfo
	{
		[CompilerGenerated]
		private string TfBVRYPQQuU;

		[CompilerGenerated]
		private string _author;

		[CompilerGenerated]
		private string _date;

		[CompilerGenerated]
		private string _text;

		public string Id
		{
			[CompilerGenerated]
			get
			{
				return TfBVRYPQQuU;
			}
			[CompilerGenerated]
			set
			{
				TfBVRYPQQuU = value;
			}
		}

		public string Author
		{
			[CompilerGenerated]
			get
			{
				return _author;
			}
			[CompilerGenerated]
			set
			{
				_author = value;
			}
		}

		public string Date
		{
			[CompilerGenerated]
			get
			{
				return _date;
			}
			[CompilerGenerated]
			set
			{
				_date = value;
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

		public CommentInfo()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class DocumentBlock
	{
		[CompilerGenerated]
		private int _paragraphIndex;

		[CompilerGenerated]
		private ParagraphInfo _paragraph;

		[CompilerGenerated]
		private int _tableIndex;

		[CompilerGenerated]
		private int _firstParagraphIndex;

		[CompilerGenerated]
		private DocumentContextInfo _table;

		public int ParagraphIndex
		{
			[CompilerGenerated]
			get
			{
				return _paragraphIndex;
			}
			[CompilerGenerated]
			set
			{
				_paragraphIndex = value;
			}
		}

		public ParagraphInfo Paragraph
		{
			[CompilerGenerated]
			get
			{
				return _paragraph;
			}
			[CompilerGenerated]
			set
			{
				_paragraph = value;
			}
		}

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

		public int FirstParagraphIndex
		{
			[CompilerGenerated]
			get
			{
				return _firstParagraphIndex;
			}
			[CompilerGenerated]
			set
			{
				_firstParagraphIndex = value;
			}
		}

		public DocumentContextInfo Table
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

		public DocumentBlock()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class DocumentBlockData
	{
		[CompilerGenerated]
		private string _type;

		[CompilerGenerated]
		private int WMaVRmTjjiJ;

		[CompilerGenerated]
		private object eDiVRoYXehq;

		public string Type
		{
			[CompilerGenerated]
			get
			{
				return _type;
			}
			[CompilerGenerated]
			set
			{
				_type = value;
			}
		}

		public int RangeStart
		{
			[CompilerGenerated]
			get
			{
				return WMaVRmTjjiJ;
			}
			[CompilerGenerated]
			set
			{
				WMaVRmTjjiJ = value;
			}
		}

		public object Data
		{
			[CompilerGenerated]
			get
			{
				return eDiVRoYXehq;
			}
			[CompilerGenerated]
			set
			{
				eDiVRoYXehq = value;
			}
		}

		public DocumentBlockData()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class TextMatchResult
	{
		[CompilerGenerated]
		private int _paragraphIndex;

		[CompilerGenerated]
		private int qwfVRpIFnSh;

		[CompilerGenerated]
		private int _charIndexEnd;

		[CompilerGenerated]
		private string _matchText;

		[CompilerGenerated]
		private string _excerpt;

		public int ParagraphIndex
		{
			[CompilerGenerated]
			get
			{
				return _paragraphIndex;
			}
			[CompilerGenerated]
			set
			{
				_paragraphIndex = value;
			}
		}

		public int CharIndexStart
		{
			[CompilerGenerated]
			get
			{
				return qwfVRpIFnSh;
			}
			[CompilerGenerated]
			set
			{
				qwfVRpIFnSh = value;
			}
		}

		public int CharIndexEnd
		{
			[CompilerGenerated]
			get
			{
				return _charIndexEnd;
			}
			[CompilerGenerated]
			set
			{
				_charIndexEnd = value;
			}
		}

		public string MatchText
		{
			[CompilerGenerated]
			get
			{
				return _matchText;
			}
			[CompilerGenerated]
			set
			{
				_matchText = value;
			}
		}

		public string Excerpt
		{
			[CompilerGenerated]
			get
			{
				return _excerpt;
			}
			[CompilerGenerated]
			set
			{
				_excerpt = value;
			}
		}

		public TextMatchResult()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_0
	{
		public int value;

		public int value;

		public BatchReplaceService2 pDGVVLIgVmK;

		public int value;

		public _G_c__DisplayClass10_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteTool3()
		{
			try
			{
				if (value < 0 || value < value)
				{
					return AiHelper_5.CreateError("rangeStart/rangeEnd 参数无效。", "invalid_arguments", new
					{
						rangeStart = value,
						rangeEnd = value
					});
				}
				DocumentOperationResult b4dteqz4khbXu1F8csG = pDGVVLIgVmK.ReadWordRange(value, value);
				if (b4dteqz4khbXu1F8csG.Error != null)
				{
					return b4dteqz4khbXu1F8csG.Error;
				}
				int num = ClampWithDefault(value, 30000, 30000);
				return AiHelper_5.CreateSuccess("Word range read.", BuildRangeInfo(b4dteqz4khbXu1F8csG, num, 0));
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateExceptionError("read_word_range failed", "word_read_error", ex);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass11_0
	{
		public BatchReplaceService2 jKPVVNnmOIw;

		public int lbMVVmZlVvE;

		public int value;

		public int XrmVVGfRwYu;

		public _G_c__DisplayClass11_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal RangeReadResult GetTableOperationResult()
		{
			return jKPVVNnmOIw.ExecuteTableReadOperation(lbMVVmZlVvE, value, XrmVVGfRwYu);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass12_0
	{
		public int value;

		public int value;

		public int DRKVVnbyDrk;

		public int value;

		public _G_c__DisplayClass12_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 GetParagraphs(DocumentSearchContext context)
		{
			_G_c__DisplayClass12_1 CS_8_locals_13 = new _G_c__DisplayClass12_1();
			int count = context.Paragraphs.Count;
			CS_8_locals_13.lEXVVebWsnI = Math.Max(1, (value <= 0) ? 1 : value);
			if (CS_8_locals_13.lEXVVebWsnI > count)
			{
				return AiHelper_5.CreateError("startParagraphIndex is out of range.", "invalid_arguments", new
				{
					totalParagraphs = count
				});
			}
			if (value > 0)
			{
				if (value < CS_8_locals_13.lEXVVebWsnI)
				{
					return AiHelper_5.CreateError("endParagraphIndex must be greater than or equal to startParagraphIndex.", "invalid_arguments");
				}
				CS_8_locals_13.value = Math.Min(count, value);
			}
			else
			{
				int num = ClampWithDefault(DRKVVnbyDrk, 20, 300);
				CS_8_locals_13.value = Math.Min(count, CS_8_locals_13.lEXVVebWsnI + num - 1);
			}
			CS_8_locals_13.bpvVVXkrWNt = ClampWithDefault(value, 1000, 5000);
			List<object> list = (from p in context.Paragraphs
				where p.ParagraphIndex >= CS_8_locals_13.lEXVVebWsnI && p.ParagraphIndex <= CS_8_locals_13.value
				select BuildParagraphInfo(p, CS_8_locals_13.bpvVVXkrWNt)).ToList();
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["totalParagraphs"] = count;
			dictionary["startParagraphIndex"] = CS_8_locals_13.lEXVVebWsnI;
			dictionary["endParagraphIndex"] = CS_8_locals_13.value;
			dictionary["returned"] = list.Count;
			dictionary["truncated"] = value <= 0 && CS_8_locals_13.value < count;
			dictionary["paragraphs"] = list;
			return AiHelper_5.CreateSuccess("Word paragraphs read.", dictionary);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass12_1
	{
		public int lEXVVebWsnI;

		public int value;

		public int bpvVVXkrWNt;

		public _G_c__DisplayClass12_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsParagraphInRange(ParagraphInfo p)
		{
			if (p.ParagraphIndex >= lEXVVebWsnI)
			{
				return p.ParagraphIndex <= value;
			}
			return false;
		}

		internal object BuildResult8(ParagraphInfo p)
		{
			return BuildParagraphInfo(p, bpvVVXkrWNt);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass13_0
	{
		public int ImSVVhZDaAJ;

		public int wesVVaUCmVo;

		public bool KEWVVqEbglr;

		public _G_c__DisplayClass13_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 GetParagraphs2(DocumentSearchContext context)
		{
			_G_c__DisplayClass13_1 CS_8_locals_5 = new _G_c__DisplayClass13_1();
			CS_8_locals_5.qIPVVvWNHDH = this;
			int num = ClampWithDefault(ImSVVhZDaAJ, 300, 1000);
			CS_8_locals_5.value = ClampOutlineLevel(wesVVaUCmVo);
			List<ParagraphInfo> list = (from p in context.Paragraphs
				where !string.IsNullOrWhiteSpace(p.Text)
				where (p.IsHeading && p.OutlineLevel <= CS_8_locals_5.value) || (!p.IsHeading & CS_8_locals_5.qIPVVvWNHDH.KEWVVqEbglr)
				select p).Take(num).ToList();
			int num2 = list.Count((ParagraphInfo p) => p.IsHeading);
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["maxOutlineLevel"] = CS_8_locals_5.value;
			dictionary["includeBodyText"] = KEWVVqEbglr;
			dictionary["headings"] = num2;
			dictionary["returned"] = list.Count;
			dictionary["truncated"] = list.Count >= num;
			dictionary["items"] = list.Select((ParagraphInfo p) => BuildParagraphInfo(p, 240)).ToList();
			return AiHelper_5.CreateSuccess("Word outline read.", dictionary);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass13_1
	{
		public int value;

		public _G_c__DisplayClass13_0 qIPVVvWNHDH;

		public _G_c__DisplayClass13_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool KUsVVPRNqWH(ParagraphInfo p)
		{
			if (!p.IsHeading || p.OutlineLevel > value)
			{
				return !p.IsHeading & qIPVVvWNHDH.KEWVVqEbglr;
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass14_0
	{
		public string text;

		public int value;

		public int value;

		public string text;

		public int value;

		public int value;

		public int qxpVBVJeiBo;

		public int value;

		public int value;

		public _G_c__DisplayClass14_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 wEjVVWmYVVM(DocumentSearchContext context)
		{
			_G_c__DisplayClass14_1 CS_8_locals_10 = new _G_c__DisplayClass14_1();
			CS_8_locals_10.ParagraphInfo = GetText7(context, text, value, value, text);
			if (CS_8_locals_10.ParagraphInfo == null)
			{
				return AiHelper_5.CreateError("未找到匹配的标题段落。", "not_found");
			}
			if (!CS_8_locals_10.ParagraphInfo.IsHeading)
			{
				return AiHelper_5.CreateError("目标段落不是 Word 标题/大纲段落。", "invalid_arguments", new
				{
					headingParagraphIndex = CS_8_locals_10.ParagraphInfo.ParagraphIndex
				});
			}
			int num = context.Paragraphs.Count;
			foreach (ParagraphInfo item2 in context.Paragraphs.Where((ParagraphInfo p) => p.ParagraphIndex > CS_8_locals_10.ParagraphInfo.ParagraphIndex))
			{
				if (item2.IsHeading && item2.OutlineLevel <= CS_8_locals_10.ParagraphInfo.OutlineLevel)
				{
					num = item2.ParagraphIndex - 1;
					break;
				}
			}
			int num2 = ClampWithDefault(value, 1000, 5000);
			int num3 = ClampWithDefault(value, 80, 500);
			int num4 = ClampWithDefault(qxpVBVJeiBo, 20, 100);
			List<DocumentBlockData> list = new List<DocumentBlockData>();
			foreach (DocumentBlock block in context.Blocks)
			{
				if (block.ParagraphIndex > 0 && block.ParagraphIndex >= CS_8_locals_10.ParagraphInfo.ParagraphIndex && block.ParagraphIndex <= num)
				{
					ParagraphInfo paragraph = block.Paragraph;
					list.Add(new DocumentBlockData
					{
						Type = "paragraph",
						RangeStart = 0,
						Data = BuildParagraphInfo(paragraph, num2)
					});
				}
				else if (block.TableIndex > 0 && block.FirstParagraphIndex >= CS_8_locals_10.ParagraphInfo.ParagraphIndex && block.FirstParagraphIndex <= num)
				{
					list.Add(new DocumentBlockData
					{
						Type = "table",
						RangeStart = 0,
						Data = BuildTableMatrixInfo(context, block.Table, num3, num4)
					});
				}
			}
			int num5 = Math.Max(0, value);
			int num6 = ClampWithDefault(value, 200, 1000);
			if (num5 > list.Count)
			{
				num5 = list.Count;
			}
			int num7 = Math.Min(list.Count, num5 + num6);
			List<object> list2 = new List<object>();
			List<object> list3 = new List<object>();
			List<object> list4 = new List<object>();
			for (int num8 = num5; num8 < num7; num8++)
			{
				DocumentBlockData block = list[num8];
				var item = new
				{
					blockIndex = num8,
					type = block.Type,
					rangeStart = block.RangeStart,
					data = block.Data
				};
				list2.Add(item);
				if (block.Type == "paragraph")
				{
					list3.Add(block.Data);
				}
				else if (block.Type == "table")
				{
					list4.Add(block.Data);
				}
			}
			bool flag = num7 < list.Count;
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["heading"] = BuildParagraphInfo(CS_8_locals_10.ParagraphInfo, 500);
			dictionary["startParagraphIndex"] = CS_8_locals_10.ParagraphInfo.ParagraphIndex;
			dictionary["endParagraphIndex"] = num;
			dictionary["rangeStart"] = 0;
			dictionary["rangeEnd"] = 0;
			dictionary["startBlock"] = num5;
			dictionary["totalBlocks"] = list.Count;
			dictionary["returnedBlocks"] = list2.Count;
			dictionary["hasMore"] = flag;
			dictionary["nextStartBlock"] = (flag ? new int?(num7) : ((int?)null));
			dictionary["returnedParagraphs"] = list3.Count;
			dictionary["returnedTables"] = list4.Count;
			dictionary["truncated"] = flag;
			dictionary["blocks"] = list2;
			dictionary["paragraphs"] = list3;
			dictionary["tables"] = list4;
			return AiHelper_5.CreateSuccess("Word section read.", dictionary);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass14_1
	{
		public ParagraphInfo ParagraphInfo;

		public Func<ParagraphInfo, bool> actionFunc1;

		public _G_c__DisplayClass14_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsAfterCurrentParagraph(ParagraphInfo p)
		{
			return p.ParagraphIndex > ParagraphInfo.ParagraphIndex;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass15_0
	{
		public int tableIndex;

		public int value;

		public int value;

		public int value;

		public BatchReplaceService2 batchReplaceService2;

		public _G_c__DisplayClass15_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteTool7(DocumentSearchContext context)
		{
			_G_c__DisplayClass15_1 CS_8_locals_20 = new _G_c__DisplayClass15_1();
			CS_8_locals_20.DocumentSearchContext = context;
			int count = CS_8_locals_20.DocumentSearchContext.Tables.Count;
			if (count == 0)
			{
				Dictionary<string, object> dictionary = BuildDocumentInfo(CS_8_locals_20.DocumentSearchContext);
				dictionary["totalTables"] = 0;
				dictionary["tables"] = new object[0];
				return AiHelper_5.CreateSuccess("No tables found.", dictionary);
			}
			CS_8_locals_20.NaoVBrVDusK = ((tableIndex <= 0) ? 1 : tableIndex);
			CS_8_locals_20.value = ((tableIndex > 0) ? tableIndex : Math.Min(count, ClampWithDefault(value, 5, 100)));
			if (CS_8_locals_20.NaoVBrVDusK < 1 || CS_8_locals_20.NaoVBrVDusK > count)
			{
				return AiHelper_5.CreateError("tableIndex is out of range.", "invalid_arguments", new
				{
					totalTables = count
				});
			}
			CS_8_locals_20.value = ClampWithDefault(value, 80, 500);
			CS_8_locals_20.value = ClampWithDefault(value, 20, 100);
			CS_8_locals_20.xEiVBEoubwj = batchReplaceService2.GetTableRangesFromApp(CS_8_locals_20.NaoVBrVDusK, CS_8_locals_20.value);
			List<object> list = (from t in CS_8_locals_20.DocumentSearchContext.Tables
				where t.TableIndex >= CS_8_locals_20.NaoVBrVDusK && t.TableIndex <= CS_8_locals_20.value
				select BuildTableMatrixInfo(CS_8_locals_20.DocumentSearchContext, t, CS_8_locals_20.value, CS_8_locals_20.value, CS_8_locals_20.xEiVBEoubwj)).ToList();
			Dictionary<string, object> dictionary2 = BuildDocumentInfo(CS_8_locals_20.DocumentSearchContext);
			dictionary2["totalTables"] = count;
			dictionary2["returned"] = list.Count;
			dictionary2["tables"] = list;
			return AiHelper_5.CreateSuccess("Word tables read.", dictionary2);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass15_1
	{
		public int NaoVBrVDusK;

		public int value;

		public DocumentSearchContext DocumentSearchContext;

		public int value;

		public int value;

		public Dictionary<int, TableRangeInfo> xEiVBEoubwj;

		public _G_c__DisplayClass15_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsTableInRange(DocumentContextInfo t)
		{
			if (t.TableIndex >= NaoVBrVDusK)
			{
				return t.TableIndex <= value;
			}
			return false;
		}

		internal object BuildResult11(DocumentContextInfo t)
		{
			return BuildTableMatrixInfo(DocumentSearchContext, t, value, value, xEiVBEoubwj);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_0
	{
		public int value;

		public _G_c__DisplayClass16_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteTool2(DocumentSearchContext context)
		{
			int num = ClampWithDefault(value, 200, 1000);
			List<object> list = ((IEnumerable<object>)(from c in context.Comments.Take(num)
				select new
				{
					id = c.Id,
					author = c.Author,
					date = c.Date,
					commentText = c.Text
				})).ToList();
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["totalComments"] = context.Comments.Count;
			dictionary["returned"] = list.Count;
			dictionary["truncated"] = list.Count >= num;
			dictionary["comments"] = list;
			return AiHelper_5.CreateSuccess("Word comments read.", dictionary);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass17_0
	{
		public int value;

		public string uUNVBfrqteP;

		public int value;

		public string text;

		public Func<ParagraphInfo, bool> actionFunc2;

		public _G_c__DisplayClass17_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 GetParagraphs6(DocumentSearchContext context)
		{
			_G_c__DisplayClass17_1 CS_8_locals_10 = new _G_c__DisplayClass17_1();
			CS_8_locals_10._G_c__DisplayClass17_0 = this;
			CS_8_locals_10.DocumentSearchContext = context;
			int num = ClampWithDefault(value, 50, 300);
			CS_8_locals_10.text = (uUNVBfrqteP ?? "contains").Trim().ToLowerInvariant();
			List<object> list = ((IEnumerable<object>)(from p in (from p in CS_8_locals_10.DocumentSearchContext.Paragraphs
					where p.IsHeading
					where value <= 0 || p.OutlineLevel == value
					where MatchesText(p.Text, CS_8_locals_10._G_c__DisplayClass17_0.text, CS_8_locals_10.text)
					select p).Take(num)
				select new
				{
					document = CS_8_locals_10.DocumentSearchContext.DocumentName,
					documentFullName = CS_8_locals_10.DocumentSearchContext.DocumentFullName,
					page = (int?)null,
					headingParagraphIndex = p.ParagraphIndex,
					paragraphIndex = p.ParagraphIndex,
					outlineLevel = p.OutlineLevel,
					text = p.Text,
					sectionReadHint = new
					{
						tool = "query",
						headingParagraphIndex = p.ParagraphIndex
					}
				})).ToList();
			Dictionary<string, object> dictionary = BuildDocumentInfo(CS_8_locals_10.DocumentSearchContext);
			dictionary["outlineLevel"] = text ?? string.Empty;
			dictionary["matchMode"] = ((value <= 0) ? ((int?)null) : new int?(value));
			dictionary["returned"] = CS_8_locals_10.text;
			dictionary["truncated"] = list.Count;
			dictionary["matches"] = list.Count >= num;
			dictionary["Word heading find completed."] = list;
			return AiHelper_5.CreateSuccess("startParagraphIndex is out of range.", dictionary);
		}

		internal bool GetOutlineLevel(ParagraphInfo p)
		{
			if (value > 0)
			{
				return p.OutlineLevel == value;
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass17_1
	{
		public string text;

		public DocumentSearchContext DocumentSearchContext;

		public _G_c__DisplayClass17_0 _G_c__DisplayClass17_0;

		public _G_c__DisplayClass17_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool hwTVBwxvJeS(ParagraphInfo p)
		{
			return MatchesText(p.Text, _G_c__DisplayClass17_0.text, text);
		}

		internal object jBpVBtGLAgp(ParagraphInfo p)
		{
			return new
			{
				document = DocumentSearchContext.DocumentName,
				documentFullName = DocumentSearchContext.DocumentFullName,
				page = (int?)null,
				headingParagraphIndex = p.ParagraphIndex,
				paragraphIndex = p.ParagraphIndex,
				outlineLevel = p.OutlineLevel,
				text = p.Text,
				sectionReadHint = new
				{
					tool = "read_word_section",
					headingParagraphIndex = p.ParagraphIndex
				}
			};
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass18_0
	{
		public string text;

		public int value;

		public bool flag;

		public bool flag;

		public _G_c__DisplayClass18_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 GetParagraphs4(DocumentSearchContext context)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return AiHelper_5.CreateError("text must not be empty.", "invalid_arguments");
			}
			int num = ClampWithDefault(value, 100, 500);
			StringComparison stringComparison = ((!flag) ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
			List<TextMatchResult> list = new List<TextMatchResult>();
			foreach (ParagraphInfo paragraph in context.Paragraphs)
			{
				if (list.Count >= num)
				{
					break;
				}
				moDrKNabHo(paragraph, text, stringComparison, flag, num, list);
			}
			return AiHelper_5.CreateSuccess("Word text find completed.", Find4(context, list, num));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass19_0
	{
		public string text;

		public int wjoVBnKCVJt;

		public bool flag;

		public _G_c__DisplayClass19_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 LoZVBpQVJLi(DocumentSearchContext context)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return AiHelper_5.CreateError("pattern must not be empty.", "invalid_arguments");
			}
			int num = ClampWithDefault(wjoVBnKCVJt, 100, 500);
			RegexOptions options = ((!flag) ? RegexOptions.IgnoreCase : RegexOptions.None);
			Regex regex = new Regex(text, options);
			List<TextMatchResult> list = new List<TextMatchResult>();
			foreach (ParagraphInfo paragraph in context.Paragraphs)
			{
				if (list.Count >= num)
				{
					break;
				}
				foreach (Match item in regex.Matches(paragraph.Text ?? string.Empty))
				{
					if (list.Count >= num)
					{
						break;
					}
					list.Add(new TextMatchResult
					{
						ParagraphIndex = paragraph.ParagraphIndex,
						CharIndexStart = item.Index + 1,
						CharIndexEnd = item.Index + item.Length,
						MatchText = item.Value,
						Excerpt = HyErOENeqf(paragraph.Text ?? string.Empty, item.Index, item.Length)
					});
				}
			}
			return AiHelper_5.CreateSuccess("Word regex find completed.", Find4(context, list, num));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass20_0
	{
		public string text;

		public int value;

		public bool flag;

		public _G_c__DisplayClass20_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteTool6(DocumentSearchContext context)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return AiHelper_5.CreateError("text must not be empty.", "invalid_arguments");
			}
			int num = ClampWithDefault(value, 100, 500);
			StringComparison comparisonType = ((!flag) ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
			List<object> list = new List<object>();
			foreach (DocumentContextInfo table in context.Tables)
			{
				if (list.Count >= num)
				{
					break;
				}
				for (int i = 0; i < table.Matrix.Count; i++)
				{
					if (list.Count >= num)
					{
						break;
					}
					for (int j = 0; j < table.Matrix[i].Count; j++)
					{
						if (list.Count >= num)
						{
							break;
						}
						string text = table.Matrix[i][j] ?? string.Empty;
						int num2 = text.IndexOf(text, comparisonType);
						if (num2 >= 0)
						{
							list.Add(new
							{
								actionableRange = false,
								tableIndex = table.TableIndex,
								rowIndex = i + 1,
								columnIndex = j + 1,
								rangeStart = (int?)null,
								rangeEnd = (int?)null,
								matchText = text.Substring(num2, text.Length),
								excerpt = HyErOENeqf(text, num2, text.Length)
							});
						}
					}
				}
			}
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["actionableRange"] = false;
			dictionary["rangeWarning"] = "该查找结果不包含可用于写入的 Word Range；如需批注、选中或替换，请使用 find_word_text 获取真实 Range。";
			dictionary["returned"] = list.Count;
			dictionary["truncated"] = list.Count >= num;
			dictionary["matches"] = list;
			return AiHelper_5.CreateSuccess("Word table text find completed.", dictionary);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_0
	{
		public Document VSQVBPeQEih;

		public _G_c__DisplayClass23_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetName7()
		{
			return VSQVBPeQEih.Name;
		}

		internal string GetFullName7()
		{
			return VSQVBPeQEih.FullName;
		}

		internal string IsSaved3()
		{
			return VSQVBPeQEih.Content.WordOpenXML;
		}

		internal bool KQxVBagcAWs()
		{
			return VSQVBPeQEih.Saved;
		}

		internal bool IsTrackRevisionsEnabled()
		{
			return VSQVBPeQEih.TrackRevisions;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass25_0
	{
		public int value;

		public int value;

		public _G_c__DisplayClass25_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal DocumentOperationResult BuildResult5(Application app)
		{
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new DocumentOperationResult
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			Document document = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = EnsureDocumentOpen3(document);
			if (insertResult != null)
			{
				return new DocumentOperationResult
				{
					Error = insertResult
				};
			}
			object Start = value;
			object End = value;
			return ReadRangeFromDocument(document, document.Range(ref Start, ref End));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass26_0
	{
		public Range range;

		public Document doc;

		public _G_c__DisplayClass26_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetName()
		{
			return range.WordOpenXML;
		}

		internal string GetName8()
		{
			return doc.Name;
		}

		internal string GetFullName9()
		{
			return doc.FullName;
		}

		internal bool fBJVBdjhVAY()
		{
			return doc.Saved;
		}

		internal int GetCount11()
		{
			return range.Start;
		}

		internal int GetCount14()
		{
			return range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass27_0
	{
		public int value;

		public int value;

		public _G_c__DisplayClass27_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal Dictionary<int, TableRangeInfo> GetTableRangeDictionary(Application app)
		{
			Dictionary<int, TableRangeInfo> dictionary = new Dictionary<int, TableRangeInfo>();
			try
			{
				_G_c__DisplayClass27_1 CS_8_locals_4 = new _G_c__DisplayClass27_1();
				if (!string.IsNullOrWhiteSpace(WordAgentRuntimeGuard2.GetNotReadyMessage(app)))
				{
					return dictionary;
				}
				CS_8_locals_4.doc = DocumentLifecycleGuard.GetActiveDocument(app);
				if (EnsureDocumentOpen3(CS_8_locals_4.doc) != null)
				{
					return dictionary;
				}
				int val = VMbreGvrrq(() => CS_8_locals_4.doc.Tables.Count, 0);
				int num = Math.Max(1, value);
				int num2 = Math.Min(val, value);
				for (int num3 = num; num3 <= num2; num3++)
				{
					try
					{
						Range range = CS_8_locals_4.doc.Tables[num3].Range;
						dictionary[num3] = new TableRangeInfo
						{
							RangeStart = range.Start,
							RangeEnd = range.End
						};
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			return dictionary;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass27_1
	{
		public Document doc;

		public _G_c__DisplayClass27_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetRangeCount2()
		{
			return doc.Tables.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_0
	{
		public int value;

		public int value;

		public int value;

		public _G_c__DisplayClass28_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal RangeReadResult ReadDocumentRange(Application app)
		{
			_G_c__DisplayClass28_1 CS_8_locals_18 = new _G_c__DisplayClass28_1();
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new RangeReadResult
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			CS_8_locals_18.doc = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = EnsureDocumentOpen3(CS_8_locals_18.doc);
			if (insertResult != null)
			{
				return new RangeReadResult
				{
					Error = insertResult
				};
			}
			int start = CS_8_locals_18.doc.Content.Start;
			int end = CS_8_locals_18.doc.Content.End;
			if (value < start || value > end || value <= value)
			{
				return new RangeReadResult
				{
					Error = AiHelper_5.CreateError("rangeStart/rangeEnd 超出文档范围或顺序无效。", "invalid_arguments", new
					{
						rangeStart = value,
						rangeEnd = value,
						contentStart = start,
						contentEnd = end
					})
				};
			}
			Document document = CS_8_locals_18.doc;
			object Start = value;
			object End = value;
			CS_8_locals_18.range = document.Range(ref Start, ref End);
			RangeReadResult instance3 = new RangeReadResult
			{
				DocumentName = TryEvaluateString(() => CS_8_locals_18.doc.Name),
				DocumentFullName = TryEvaluateString(() => CS_8_locals_18.doc.FullName),
				DocumentSaved = TryEvaluateBool2(() => CS_8_locals_18.doc.Saved, false),
				RangeStart = value,
				RangeEnd = value,
				TotalTablesInRange = VMbreGvrrq(() => CS_8_locals_18.range.Tables.Count, 0)
			};
			int num = Math.Min(instance3.TotalTablesInRange, value);
			for (int num2 = 1; num2 <= num; num2++)
			{
				_G_c__DisplayClass28_2 CS_8_locals_21 = new _G_c__DisplayClass28_2();
				Table table = CS_8_locals_18.range.Tables[num2];
				CS_8_locals_21.range = table.Range;
				TableStructureInfo tableStructureInfo = new TableStructureInfo
				{
					LocalTableIndex = num2,
					RangeStart = VMbreGvrrq(() => CS_8_locals_21.range.Start, 0),
					RangeEnd = VMbreGvrrq(() => CS_8_locals_21.range.End, 0),
					Page = GetRangeCount(CS_8_locals_21.range),
					WordOpenXml = TryEvaluateString(() => CS_8_locals_21.range.WordOpenXML)
				};
				try
				{
					IEnumerator enumerator = table.Range.Cells.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							_G_c__DisplayClass28_3 CS_8_locals_24 = new _G_c__DisplayClass28_3();
							CS_8_locals_24.cell = (Cell)enumerator.Current;
							if (TryGetCellPosition(CS_8_locals_24.cell, out var rowIndex, out var columnIndex))
							{
								tableStructureInfo.Cells.Add(new TableCellInfo
								{
									RowIndex = rowIndex,
									ColumnIndex = columnIndex,
									RangeStart = VMbreGvrrq(() => CS_8_locals_24.cell.Range.Start, 0),
									RangeEnd = VMbreGvrrq(() => CS_8_locals_24.cell.Range.End, 0),
									Page = GetRangeCount(CS_8_locals_24.cell.Range),
									Text = CleanCellText(TryEvaluateString(() => CS_8_locals_24.cell.Range.Text))
								});
							}
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				catch
				{
				}
				instance3.Tables.Add(tableStructureInfo);
			}
			return instance3;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_1
	{
		public Document doc;

		public Range range;

		public _G_c__DisplayClass28_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetName9()
		{
			return doc.Name;
		}

		internal string GetFullName8()
		{
			return doc.FullName;
		}

		internal bool IsSaved2()
		{
			return doc.Saved;
		}

		internal int GetCount12()
		{
			return range.Tables.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_2
	{
		public Range range;

		public _G_c__DisplayClass28_2()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetText5()
		{
			return range.Start;
		}

		internal int GetText9()
		{
			return range.End;
		}

		internal string GetText3()
		{
			return range.WordOpenXML;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_3
	{
		public Cell cell;

		public _G_c__DisplayClass28_3()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetRangeText2()
		{
			return cell.Range.Start;
		}

		internal int GetText8()
		{
			return cell.Range.End;
		}

		internal string GetText4()
		{
			return cell.Range.Text;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass39_0
	{
		public TableStructureInfo tableStructureInfo;

		public DocumentContextInfo DocumentContextInfo;

		public _G_c__DisplayClass39_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal Dictionary<string, object> BuildCellEditInfo(Dictionary<string, object> item)
		{
			return new Dictionary<string, object>
			{
				["cellId"] = GetDictionaryString(item, "cellId"),
				["localTableIndex"] = tableStructureInfo.LocalTableIndex,
				["rowIndex"] = GetDictionaryInt(item, "rowIndex"),
				["columnIndex"] = GetDictionaryInt(item, "columnIndex"),
				["isHeader"] = GetDictionaryBool(item, "isHeader"),
				["requiresAllowHeaderEdit"] = false,
				["oldText"] = GetDictionaryString(item, "text"),
				["columnHeaderPath"] = item["columnHeaderPath"],
				["rowLabelPath"] = item["rowLabelPath"],
				["rowLeftContext"] = item["rowLeftContext"]
			};
		}

		internal object BuildResult10(MergedCellRange m)
		{
			return new
			{
				startRow = m.StartRow,
				startColumn = m.StartColumn,
				endRow = m.EndRow,
				endColumn = m.EndColumn,
				text = (FindCellAtPosition(DocumentContextInfo, m.StartRow, m.StartColumn)?.Text ?? string.Empty)
			};
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass42_0
	{
		public int value;

		public _G_c__DisplayClass42_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsMergeInRange(MergedCellRange merge)
		{
			if (merge.StartRow <= value)
			{
				return merge.EndRow >= value;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass46_0
	{
		public int value;

		public int value;

		public _G_c__DisplayClass46_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsCellAtPosition(TableCellData cell)
		{
			if (cell.RowIndex <= value && value < cell.RowIndex + Math.Max(1, cell.RowSpan) && cell.ColumnIndex <= value)
			{
				return value < cell.ColumnIndex + Math.Max(1, cell.ColumnSpan);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass57_0
	{
		public int value;

		public _G_c__DisplayClass57_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsBlockForTable(DocumentBlock b)
		{
			if (b.Table != null)
			{
				return b.TableIndex == value;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass58_0
	{
		public DocumentSearchContext DocumentSearchContext;

		public _G_c__DisplayClass58_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal object BuildResult3(TextMatchResult match)
		{
			return new
			{
				actionableRange = false,
				document = DocumentSearchContext.DocumentName,
				documentFullName = DocumentSearchContext.DocumentFullName,
				page = (int?)null,
				paragraphIndex = match.ParagraphIndex,
				charIndexStart = match.CharIndexStart,
				charIndexEnd = match.CharIndexEnd,
				rangeStart = (int?)null,
				rangeEnd = (int?)null,
				matchText = match.MatchText,
				excerpt = match.Excerpt
			};
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass60_0
	{
		public int value;

		public int value;

		public string text;

		public string text;

		public _G_c__DisplayClass60_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool GetText6(ParagraphInfo p)
		{
			return p.ParagraphIndex == value;
		}

		internal bool GetText2(ParagraphInfo p)
		{
			if (!p.IsHeading)
			{
				return false;
			}
			if (value > 0 && p.OutlineLevel != value)
			{
				return false;
			}
			return MatchesText(p.Text, text, text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass71_0
	{
		public string text;

		public _G_c__DisplayClass71_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool GetValue2(XElement p)
		{
			return string.Equals(p.Attribute(names1 + "name")?.Value, text, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass7_0
	{
		public int value;

		public _G_c__DisplayClass7_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 GetParagraphs7(DocumentSearchContext context)
		{
			int num = ClampWithDefault(value, 240, 2000);
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["pageCount"] = null;
			dictionary["wordCount"] = null;
			dictionary["statisticsIncluded"] = false;
			dictionary["paragraphCount"] = context.Paragraphs.Count;
			dictionary["tableCount"] = context.Tables.Count;
			dictionary["commentCount"] = context.Comments.Count;
			dictionary["trackRevisions"] = context.TrackRevisions;
			dictionary["selection"] = BuildSelectionInfo(context.Selection, num);
			return AiHelper_5.CreateSuccess("Word context read.", dictionary);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass8_0
	{
		public int value;

		public int value;

		public int value;

		public int value;

		public int value;

		public _G_c__DisplayClass8_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 GetParagraphs5(DocumentSearchContext context)
		{
			_G_c__DisplayClass8_1 CS_8_locals_4 = new _G_c__DisplayClass8_1();
			int count = ClampWithDefault(value, 8, 50);
			int num = ClampWithDefault(value, 4, 50);
			int num2 = ClampWithDefault(value, 50, 300);
			CS_8_locals_4.value = ClampWithDefault(value, 180, 1000);
			int num3 = ClampWithDefault(value, 240, 2000);
			List<ParagraphInfo> list = context.Paragraphs.Where((ParagraphInfo p) => !string.IsNullOrWhiteSpace(p.Text)).ToList();
			List<object> list2 = (from p in list.Take(count)
				select BuildParagraphInfo(p, CS_8_locals_4.value)).ToList();
			List<object> list3 = (from p in list.Skip(Math.Max(0, list.Count - num))
				select BuildParagraphInfo(p, CS_8_locals_4.value)).ToList();
			List<object> list4 = (from p in context.Paragraphs.Where((ParagraphInfo p) => p.IsHeading && p.OutlineLevel == 1 && !string.IsNullOrWhiteSpace(p.Text)).Take(num2)
				select BuildParagraphInfo(p, CS_8_locals_4.value)).ToList();
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["paragraphCount"] = context.Paragraphs.Count;
			dictionary["tableCount"] = context.Tables.Count;
			dictionary["commentCount"] = context.Comments.Count;
			dictionary["trackRevisions"] = context.TrackRevisions;
			dictionary["selection"] = BuildSelectionInfo(context.Selection, num3);
			dictionary["headingLevel"] = 1;
			dictionary["headings"] = list4;
			dictionary["head"] = list2;
			dictionary["tail"] = list3;
			dictionary["truncated"] = list.Count > list2.Count + list3.Count || list4.Count >= num2;
			return AiHelper_5.CreateSuccess("Word document preview prepared.", dictionary);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass8_1
	{
		public int value;

		public _G_c__DisplayClass8_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal object BuildResult7(ParagraphInfo p)
		{
			return BuildParagraphInfo(p, value);
		}

		internal object BuildResult2(ParagraphInfo p)
		{
			return BuildParagraphInfo(p, value);
		}

		internal object BuildResult4(ParagraphInfo p)
		{
			return BuildParagraphInfo(p, value);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass9_0
	{
		public BatchReplaceService2 batchReplaceService2;

		public int value;

		public _G_c__DisplayClass9_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteTool4()
		{
			try
			{
				DocumentOperationResult b4dteqz4khbXu1F8csG = batchReplaceService2.ReadSelectionRange();
				if (b4dteqz4khbXu1F8csG.Error != null)
				{
					return b4dteqz4khbXu1F8csG.Error;
				}
				int num = ClampWithDefault(value, 6000, 30000);
				return AiHelper_5.CreateSuccess("Word selection preview prepared.", BuildRangeInfo(b4dteqz4khbXu1F8csG, num, null));
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateExceptionError("preview_word_selection failed", "word_read_error", ex);
			}
		}
	}

	private static readonly XNamespace wordNamespace;

	private static readonly XNamespace names1;

	private readonly AiTargetBinder _aiTargetBinder;

	private readonly WordTableToolService4 _wordTableToolService4;

	public BatchReplaceService2() : this(null)
	{
		SseStreamInitializer.InitializeRuntime();
	}

	public BatchReplaceService2(AiTargetBinder P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_aiTargetBinder = P_0;
		_wordTableToolService4 = new WordTableToolService4(P_0);
	}

	public AiHelper_5 GetCurrentContext(int P_0)
	{
		_G_c__DisplayClass7_0 CS_8_locals_2 = new _G_c__DisplayClass7_0();
		CS_8_locals_2.value = P_0;
		return ExecuteTool("get_current_word_context", delegate(DocumentSearchContext context)
		{
			int num = ClampWithDefault(CS_8_locals_2.value, 240, 2000);
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["get_current_word_context"] = null;
			dictionary["preview_word_document"] = null;
			dictionary["preview_word_selection"] = false;
			dictionary["read_word_range"] = context.Paragraphs.Count;
			dictionary["rangeStart/rangeEnd 参数无效。"] = context.Tables.Count;
			dictionary["invalid_arguments"] = context.Comments.Count;
			dictionary["read_word_tables_in_range"] = context.TrackRevisions;
			dictionary["read_word_tables_in_range failed"] = BuildSelectionInfo(context.Selection, num);
			return AiHelper_5.CreateSuccess("word_read_error", dictionary);
		});
	}

	public AiHelper_5 PreviewDocument(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		_G_c__DisplayClass8_0 CS_8_locals_12 = new _G_c__DisplayClass8_0();
		CS_8_locals_12.value = P_0;
		CS_8_locals_12.value = P_1;
		CS_8_locals_12.value = P_2;
		CS_8_locals_12.value = P_3;
		CS_8_locals_12.value = P_4;
		return ExecuteTool("preview_word_document", delegate(DocumentSearchContext context)
		{
			_G_c__DisplayClass8_1 CS_8_locals_15 = new _G_c__DisplayClass8_1();
			int count = ClampWithDefault(CS_8_locals_12.value, 8, 50);
			int num = ClampWithDefault(CS_8_locals_12.value, 4, 50);
			int num2 = ClampWithDefault(CS_8_locals_12.value, 50, 300);
			CS_8_locals_15.value = ClampWithDefault(CS_8_locals_12.value, 180, 1000);
			int num3 = ClampWithDefault(CS_8_locals_12.value, 240, 2000);
			List<ParagraphInfo> list = context.Paragraphs.Where((ParagraphInfo p) => !string.IsNullOrWhiteSpace(p.Text)).ToList();
			List<object> list2 = (from p in list.Take(count)
				select BuildParagraphInfo(p, CS_8_locals_15.value)).ToList();
			List<object> list3 = (from p in list.Skip(Math.Max(0, list.Count - num))
				select BuildParagraphInfo(p, CS_8_locals_15.value)).ToList();
			List<object> list4 = (from p in context.Paragraphs.Where((ParagraphInfo p) => p.IsHeading && p.OutlineLevel == 1 && !string.IsNullOrWhiteSpace(p.Text)).Take(num2)
				select BuildParagraphInfo(p, CS_8_locals_15.value)).ToList();
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["无法从该表格的 WordOpenXML 中解析表格结构。"] = context.Paragraphs.Count;
			dictionary["document"] = context.Tables.Count;
			dictionary["documentFullName"] = context.Comments.Count;
			dictionary["documentSaved"] = context.TrackRevisions;
			dictionary["rangeStart"] = BuildSelectionInfo(context.Selection, num3);
			dictionary["rangeEnd"] = 1;
			dictionary["selectedTableCount"] = list4;
			dictionary["returnedTables"] = list2;
			dictionary["truncated"] = list3;
			dictionary["coordinateSystem"] = list.Count > list2.Count + list3.Count || list4.Count >= num2;
			return AiHelper_5.CreateSuccess("localTableIndex,rowIndex,columnIndex are 1-based within the referenced Word range.", dictionary);
		});
	}

	public AiHelper_5 PreviewSelection(int P_0)
	{
		_G_c__DisplayClass9_0 CS_8_locals_4 = new _G_c__DisplayClass9_0();
		CS_8_locals_4.batchReplaceService2 = this;
		CS_8_locals_4.value = P_0;
		return AiHelper_14.RunWithTelemetry("preview_word_selection", delegate
		{
			try
			{
				DocumentOperationResult b4dteqz4khbXu1F8csG = CS_8_locals_4.batchReplaceService2.ReadSelectionRange();
				if (b4dteqz4khbXu1F8csG.Error != null)
				{
					return b4dteqz4khbXu1F8csG.Error;
				}
				int num = ClampWithDefault(CS_8_locals_4.value, 6000, 30000);
				return AiHelper_5.CreateSuccess("writeTool", BuildRangeInfo(b4dteqz4khbXu1F8csG, num, null));
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateExceptionError("fill_word_table_cells_by_model", "structureEditTools", ex);
			}
		});
	}

	public AiHelper_5 ReadRange(int P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass10_0 CS_8_locals_13 = new _G_c__DisplayClass10_0();
		CS_8_locals_13.value = P_0;
		CS_8_locals_13.value = P_1;
		CS_8_locals_13.pDGVVLIgVmK = this;
		CS_8_locals_13.value = P_2;
		return AiHelper_14.RunWithTelemetry("read_word_range", delegate
		{
			try
			{
				if (CS_8_locals_13.value < 0 || CS_8_locals_13.value < CS_8_locals_13.value)
				{
					return AiHelper_5.CreateError("insert_word_table_rows_by_model", "fill_word_table_cells_by_model", new
					{
						rangeStart = CS_8_locals_13.value,
						rangeEnd = CS_8_locals_13.value
					});
				}
				DocumentOperationResult b4dteqz4khbXu1F8csG = CS_8_locals_13.pDGVVLIgVmK.ReadWordRange(CS_8_locals_13.value, CS_8_locals_13.value);
				if (b4dteqz4khbXu1F8csG.Error != null)
				{
					return b4dteqz4khbXu1F8csG.Error;
				}
				int num = ClampWithDefault(CS_8_locals_13.value, 30000, 30000);
				return AiHelper_5.CreateSuccess("tables", BuildRangeInfo(b4dteqz4khbXu1F8csG, num, 0));
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateExceptionError("No tables found in range.", "Word range tables read.", ex);
			}
		});
	}

	public AiHelper_5 ReadTablesInRange(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		_G_c__DisplayClass11_0 CS_8_locals_13 = new _G_c__DisplayClass11_0();
		CS_8_locals_13.jKPVVNnmOIw = this;
		CS_8_locals_13.lbMVVmZlVvE = P_0;
		CS_8_locals_13.value = P_1;
		if (CS_8_locals_13.lbMVVmZlVvE < 0 || CS_8_locals_13.value <= CS_8_locals_13.lbMVVmZlVvE)
		{
			return AiHelper_5.CreateError("rangeStart/rangeEnd 参数无效。", "invalid_arguments", new
			{
				rangeStart = CS_8_locals_13.lbMVVmZlVvE,
				rangeEnd = CS_8_locals_13.value
			});
		}
		CS_8_locals_13.XrmVVGfRwYu = ClampWithDefault(P_2, 20, 100);
		int num = ClampWithDefault(P_3, 80, 500);
		int num2 = ClampWithDefault(P_4, 40, 120);
		RangeReadResult instance3;
		try
		{
			instance3 = AiHelper_14.RunWithTelemetry("read_word_tables_in_range", () => CS_8_locals_13.jKPVVNnmOIw.ExecuteTableReadOperation(CS_8_locals_13.lbMVVmZlVvE, CS_8_locals_13.value, CS_8_locals_13.XrmVVGfRwYu));
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateExceptionError("read_word_tables_in_range failed", "word_read_error", ex);
		}
		if (instance3.Error != null)
		{
			return instance3.Error;
		}
		try
		{
			List<object> list = new List<object>();
			foreach (TableStructureInfo table in instance3.Tables)
			{
				DocumentContextInfo tABVE1VR66mkVrCsbLlX2 = ExtractTableFromRange(instance3, table);
				if (tABVE1VR66mkVrCsbLlX2 == null)
				{
					list.Add(new
					{
						localTableIndex = table.LocalTableIndex,
						rangeStart = table.RangeStart,
						rangeEnd = table.RangeEnd,
						parsed = false,
						warning = "无法从该表格的 WordOpenXML 中解析表格结构。"
					});
				}
				else
				{
					list.Add(i041zjkxm7(tABVE1VR66mkVrCsbLlX2, table, num, num2));
				}
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["document"] = instance3.DocumentName;
			dictionary["documentFullName"] = instance3.DocumentFullName;
			dictionary["documentSaved"] = instance3.DocumentSaved;
			dictionary["rangeStart"] = instance3.RangeStart;
			dictionary["rangeEnd"] = instance3.RangeEnd;
			dictionary["selectedTableCount"] = instance3.TotalTablesInRange;
			dictionary["returnedTables"] = list.Count;
			dictionary["truncated"] = instance3.TotalTablesInRange > list.Count;
			dictionary["coordinateSystem"] = "localTableIndex,rowIndex,columnIndex are 1-based within the referenced Word range.";
			dictionary["writeTool"] = "fill_word_table_cells_by_model";
			dictionary["structureEditTools"] = new string[2]
			{
				"insert_word_table_rows_by_model",
				"fill_word_table_cells_by_model"
			};
			dictionary["tables"] = list;
			Dictionary<string, object> dictionary2 = dictionary;
			return AiHelper_5.CreateSuccess((instance3.TotalTablesInRange > 0) ? "No tables found in range." : "Word range tables read.", dictionary2);
		}
		catch (Exception ex2)
		{
			return AiHelper_5.CreateExceptionError("read_word_tables_in_range parse failed", "word_read_error", ex2);
		}
	}

	public AiHelper_5 ReadParagraphs(int P_0, int P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass12_0 CS_8_locals_22 = new _G_c__DisplayClass12_0();
		CS_8_locals_22.value = P_0;
		CS_8_locals_22.value = P_2;
		CS_8_locals_22.DRKVVnbyDrk = P_1;
		CS_8_locals_22.value = P_3;
		return ExecuteTool("read_word_paragraphs", delegate(DocumentSearchContext context)
		{
			_G_c__DisplayClass12_1 CS_8_locals_26 = new _G_c__DisplayClass12_1();
			int count = context.Paragraphs.Count;
			CS_8_locals_26.lEXVVebWsnI = Math.Max(1, (CS_8_locals_22.value <= 0) ? 1 : CS_8_locals_22.value);
			if (CS_8_locals_26.lEXVVebWsnI > count)
			{
				return AiHelper_5.CreateError("read_word_tables_in_range parse failed", "word_read_error", new
				{
					totalParagraphs = count
				});
			}
			if (CS_8_locals_22.value > 0)
			{
				if (CS_8_locals_22.value < CS_8_locals_26.lEXVVebWsnI)
				{
					return AiHelper_5.CreateError("read_word_paragraphs", "read_word_outline");
				}
				CS_8_locals_26.value = Math.Min(count, CS_8_locals_22.value);
			}
			else
			{
				int num = ClampWithDefault(CS_8_locals_22.DRKVVnbyDrk, 20, 300);
				CS_8_locals_26.value = Math.Min(count, CS_8_locals_26.lEXVVebWsnI + num - 1);
			}
			CS_8_locals_26.bpvVVXkrWNt = ClampWithDefault(CS_8_locals_22.value, 1000, 5000);
			List<object> list = (from p in context.Paragraphs
				where p.ParagraphIndex >= CS_8_locals_26.lEXVVebWsnI && p.ParagraphIndex <= CS_8_locals_26.value
				select BuildParagraphInfo(p, CS_8_locals_26.bpvVVXkrWNt)).ToList();
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["read_word_section"] = count;
			dictionary["read_word_tables"] = CS_8_locals_26.lEXVVebWsnI;
			dictionary["read_word_comments"] = CS_8_locals_26.value;
			dictionary["find_word_heading"] = list.Count;
			dictionary["find_word_text"] = CS_8_locals_22.value <= 0 && CS_8_locals_26.value < count;
			dictionary["find_word_regex"] = list;
			return AiHelper_5.CreateSuccess("find_word_table_text", dictionary);
		});
	}

	public AiHelper_5 ReadOutline(int P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass13_0 CS_8_locals_11 = new _G_c__DisplayClass13_0();
		CS_8_locals_11.ImSVVhZDaAJ = P_0;
		CS_8_locals_11.wesVVaUCmVo = P_2;
		CS_8_locals_11.KEWVVqEbglr = P_1;
		return ExecuteTool("read_word_outline", delegate(DocumentSearchContext context)
		{
			_G_c__DisplayClass13_1 CS_8_locals_13 = new _G_c__DisplayClass13_1();
			CS_8_locals_13.qIPVVvWNHDH = CS_8_locals_11;
			int num = ClampWithDefault(CS_8_locals_11.ImSVVhZDaAJ, 300, 1000);
			CS_8_locals_13.value = ClampOutlineLevel(CS_8_locals_11.wesVVaUCmVo);
			List<ParagraphInfo> list = (from p in context.Paragraphs
				where !string.IsNullOrWhiteSpace(p.Text)
				where (p.IsHeading && p.OutlineLevel <= CS_8_locals_13.value) || (!p.IsHeading & CS_8_locals_13.qIPVVvWNHDH.KEWVVqEbglr)
				select p).Take(num).ToList();
			int num2 = list.Count((ParagraphInfo p) => p.IsHeading);
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary[" failed"] = CS_8_locals_13.value;
			dictionary["word_read_error"] = CS_8_locals_11.KEWVVqEbglr;
			dictionary["word_openxml_com"] = num2;
			dictionary["当前没有打开的 Word 文档。"] = list.Count;
			dictionary["no_document"] = list.Count >= num;
			dictionary["document"] = list.Select((ParagraphInfo p) => BuildParagraphInfo(p, 240)).ToList();
			return AiHelper_5.CreateSuccess("documentFullName", dictionary);
		});
	}

	public AiHelper_5 ReadSection(string P_0, int P_1, int P_2, string P_3, int P_4, int P_5, int P_6, int P_7, int P_8)
	{
		_G_c__DisplayClass14_0 CS_8_locals_26 = new _G_c__DisplayClass14_0();
		CS_8_locals_26.text = P_0;
		CS_8_locals_26.value = P_1;
		CS_8_locals_26.value = P_2;
		CS_8_locals_26.text = P_3;
		CS_8_locals_26.value = P_6;
		CS_8_locals_26.value = P_7;
		CS_8_locals_26.qxpVBVJeiBo = P_8;
		CS_8_locals_26.value = P_4;
		CS_8_locals_26.value = P_5;
		return ExecuteTool("read_word_section", delegate(DocumentSearchContext context)
		{
			_G_c__DisplayClass14_1 CS_8_locals_29 = new _G_c__DisplayClass14_1();
			CS_8_locals_29.ParagraphInfo = GetText7(context, CS_8_locals_26.text, CS_8_locals_26.value, CS_8_locals_26.value, CS_8_locals_26.text);
			if (CS_8_locals_29.ParagraphInfo == null)
			{
				return AiHelper_5.CreateError("documentSaved", "document");
			}
			if (!CS_8_locals_29.ParagraphInfo.IsHeading)
			{
				return AiHelper_5.CreateError("documentFullName", "documentSaved", new
				{
					headingParagraphIndex = CS_8_locals_29.ParagraphInfo.ParagraphIndex
				});
			}
			int num = context.Paragraphs.Count;
			foreach (ParagraphInfo item2 in context.Paragraphs.Where((ParagraphInfo p) => p.ParagraphIndex > CS_8_locals_29.ParagraphInfo.ParagraphIndex))
			{
				if (item2.IsHeading && item2.OutlineLevel <= CS_8_locals_29.ParagraphInfo.OutlineLevel)
				{
					num = item2.ParagraphIndex - 1;
					break;
				}
			}
			int num2 = ClampWithDefault(CS_8_locals_26.value, 1000, 5000);
			int num3 = ClampWithDefault(CS_8_locals_26.value, 80, 500);
			int num4 = ClampWithDefault(CS_8_locals_26.qxpVBVJeiBo, 20, 100);
			List<DocumentBlockData> list = new List<DocumentBlockData>();
			foreach (DocumentBlock block in context.Blocks)
			{
				if (block.ParagraphIndex > 0 && block.ParagraphIndex >= CS_8_locals_29.ParagraphInfo.ParagraphIndex && block.ParagraphIndex <= num)
				{
					ParagraphInfo paragraph = block.Paragraph;
					list.Add(new DocumentBlockData
					{
						Type = "body",
						RangeStart = 0,
						Data = BuildParagraphInfo(paragraph, num2)
					});
				}
				else if (block.TableIndex > 0 && block.FirstParagraphIndex >= CS_8_locals_29.ParagraphInfo.ParagraphIndex && block.FirstParagraphIndex <= num)
				{
					list.Add(new DocumentBlockData
					{
						Type = "heading",
						RangeStart = 0,
						Data = BuildTableMatrixInfo(context, block.Table, num3, num4)
					});
				}
			}
			int num5 = Math.Max(0, CS_8_locals_26.value);
			int num6 = ClampWithDefault(CS_8_locals_26.value, 200, 1000);
			if (num5 > list.Count)
			{
				num5 = list.Count;
			}
			int num7 = Math.Min(list.Count, num5 + num6);
			List<object> list2 = new List<object>();
			List<object> list3 = new List<object>();
			List<object> list4 = new List<object>();
			for (int num8 = num5; num8 < num7; num8++)
			{
				DocumentBlockData block = list[num8];
				var item = new
				{
					blockIndex = num8,
					type = block.Type,
					rangeStart = block.RangeStart,
					data = block.Data
				};
				list2.Add(item);
				if (block.Type == "openxml_unavailable")
				{
					list3.Add(block.Data);
				}
				else if (block.Type == "document")
				{
					list4.Add(block.Data);
				}
			}
			bool flag = num7 < list.Count;
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["documentFullName"] = BuildParagraphInfo(CS_8_locals_29.ParagraphInfo, 500);
			dictionary["documentSaved"] = CS_8_locals_29.ParagraphInfo.ParagraphIndex;
			dictionary["page"] = num;
			dictionary["rangeStart"] = 0;
			dictionary["rangeEnd"] = 0;
			dictionary["characters"] = num5;
			dictionary["truncated"] = list.Count;
			dictionary["text"] = list2.Count;
			dictionary["paragraphIndex"] = flag;
			dictionary["index"] = (flag ? new int?(num7) : ((int?)null));
			dictionary["altTextTitle"] = list3.Count;
			dictionary["altTextDescription"] = list4.Count;
			dictionary["rows"] = flag;
			dictionary["columns"] = list2;
			dictionary["returnedRows"] = list3;
			dictionary["returnedColumns"] = list4;
			return AiHelper_5.CreateSuccess("page", dictionary);
		});
	}

	public AiHelper_5 ReadTables(int P_0, int P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass15_0 CS_8_locals_24 = new _G_c__DisplayClass15_0();
		CS_8_locals_24.tableIndex = P_0;
		CS_8_locals_24.value = P_1;
		CS_8_locals_24.value = P_2;
		CS_8_locals_24.value = P_3;
		CS_8_locals_24.batchReplaceService2 = this;
		return ExecuteTool("read_word_tables", delegate(DocumentSearchContext context)
		{
			_G_c__DisplayClass15_1 CS_8_locals_34 = new _G_c__DisplayClass15_1();
			CS_8_locals_34.DocumentSearchContext = context;
			int count = CS_8_locals_34.DocumentSearchContext.Tables.Count;
			if (count == 0)
			{
				Dictionary<string, object> dictionary = BuildDocumentInfo(CS_8_locals_34.DocumentSearchContext);
				dictionary["paragraphIndex"] = 0;
				dictionary["rangeStart"] = new object[0];
				return AiHelper_5.CreateSuccess("rangeEnd", dictionary);
			}
			CS_8_locals_34.NaoVBrVDusK = ((CS_8_locals_24.tableIndex <= 0) ? 1 : CS_8_locals_24.tableIndex);
			CS_8_locals_34.value = ((CS_8_locals_24.tableIndex > 0) ? CS_8_locals_24.tableIndex : Math.Min(count, ClampWithDefault(CS_8_locals_24.value, 5, 100)));
			if (CS_8_locals_34.NaoVBrVDusK < 1 || CS_8_locals_34.NaoVBrVDusK > count)
			{
				return AiHelper_5.CreateError("actionableRange", "rangeSource", new
				{
					totalTables = count
				});
			}
			CS_8_locals_34.value = ClampWithDefault(CS_8_locals_24.value, 80, 500);
			CS_8_locals_34.value = ClampWithDefault(CS_8_locals_24.value, 20, 100);
			CS_8_locals_34.xEiVBEoubwj = CS_8_locals_24.batchReplaceService2.GetTableRangesFromApp(CS_8_locals_34.NaoVBrVDusK, CS_8_locals_34.value);
			List<object> list = (from t in CS_8_locals_34.DocumentSearchContext.Tables
				where t.TableIndex >= CS_8_locals_34.NaoVBrVDusK && t.TableIndex <= CS_8_locals_34.value
				select BuildTableMatrixInfo(CS_8_locals_34.DocumentSearchContext, t, CS_8_locals_34.value, CS_8_locals_34.value, CS_8_locals_34.xEiVBEoubwj)).ToList();
			Dictionary<string, object> dictionary2 = BuildDocumentInfo(CS_8_locals_34.DocumentSearchContext);
			dictionary2["openxml_unavailable"] = count;
			dictionary2["word_com_table_range"] = list.Count;
			dictionary2["previousParagraph"] = list;
			return AiHelper_5.CreateSuccess("nextParagraph", dictionary2);
		});
	}

	public AiHelper_5 GetParagraphs3(int P_0)
	{
		_G_c__DisplayClass16_0 CS_8_locals_2 = new _G_c__DisplayClass16_0();
		CS_8_locals_2.value = P_0;
		return ExecuteTool("read_word_comments", delegate(DocumentSearchContext context)
		{
			int num = ClampWithDefault(CS_8_locals_2.value, 200, 1000);
			List<object> list = ((IEnumerable<object>)(from c in context.Comments.Take(num)
				select new
				{
					id = c.Id,
					author = c.Author,
					date = c.Date,
					commentText = c.Text
				})).ToList();
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["truncated"] = context.Comments.Count;
			dictionary["rowsData"] = list.Count;
			dictionary["cellsFlat"] = list.Count >= num;
			dictionary["markdown"] = list;
			return AiHelper_5.CreateSuccess("rawText", dictionary);
		});
	}

	public AiHelper_5 FindHeading(string P_0, int P_1, string P_2, int P_3)
	{
		_G_c__DisplayClass17_0 CS_8_locals_19 = new _G_c__DisplayClass17_0();
		CS_8_locals_19.value = P_3;
		CS_8_locals_19.uUNVBfrqteP = P_2;
		CS_8_locals_19.value = P_1;
		CS_8_locals_19.text = P_0;
		return ExecuteTool("find_word_heading", delegate(DocumentSearchContext context)
		{
			_G_c__DisplayClass17_1 CS_8_locals_23 = new _G_c__DisplayClass17_1();
			CS_8_locals_23._G_c__DisplayClass17_0 = CS_8_locals_19;
			CS_8_locals_23.DocumentSearchContext = context;
			int num = ClampWithDefault(CS_8_locals_19.value, 50, 300);
			CS_8_locals_23.text = (CS_8_locals_19.uUNVBfrqteP ?? "hasMergedOrUnavailableCells").Trim().ToLowerInvariant();
			List<object> list = ((IEnumerable<object>)(from p in (from p in CS_8_locals_23.DocumentSearchContext.Paragraphs
					where p.IsHeading
					where CS_8_locals_19.value <= 0 || p.OutlineLevel == CS_8_locals_19.value
					where MatchesText(p.Text, CS_8_locals_23._G_c__DisplayClass17_0.text, CS_8_locals_23.text)
					select p).Take(num)
				select new
				{
					document = CS_8_locals_23.DocumentSearchContext.DocumentName,
					documentFullName = CS_8_locals_23.DocumentSearchContext.DocumentFullName,
					page = (int?)null,
					headingParagraphIndex = p.ParagraphIndex,
					paragraphIndex = p.ParagraphIndex,
					outlineLevel = p.OutlineLevel,
					text = p.Text,
					sectionReadHint = new
					{
						tool = "expandedMergedCells",
						headingParagraphIndex = p.ParagraphIndex
					}
				})).ToList();
			Dictionary<string, object> dictionary = BuildDocumentInfo(CS_8_locals_23.DocumentSearchContext);
			dictionary["warnings"] = CS_8_locals_19.text ?? string.Empty;
			dictionary["localTableIndex"] = ((CS_8_locals_19.value <= 0) ? ((int?)null) : new int?(CS_8_locals_19.value));
			dictionary["rangeStart"] = CS_8_locals_23.text;
			dictionary["rangeEnd"] = list.Count;
			dictionary["page"] = list.Count >= num;
			dictionary["actionableRange"] = list;
			return AiHelper_5.CreateSuccess("rangeSource", dictionary);
		});
	}

	public AiHelper_5 GetParagraphs8(string P_0, bool P_1, bool P_2, int P_3)
	{
		_G_c__DisplayClass18_0 CS_8_locals_9 = new _G_c__DisplayClass18_0();
		CS_8_locals_9.text = P_0;
		CS_8_locals_9.value = P_3;
		CS_8_locals_9.flag = P_1;
		CS_8_locals_9.flag = P_2;
		return ExecuteTool("find_word_text", delegate(DocumentSearchContext context)
		{
			if (string.IsNullOrWhiteSpace(CS_8_locals_9.text))
			{
				return AiHelper_5.CreateError("word_com_selection_table_range", "rows");
			}
			int num = ClampWithDefault(CS_8_locals_9.value, 100, 500);
			StringComparison stringComparison = ((!CS_8_locals_9.flag) ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
			List<TextMatchResult> list = new List<TextMatchResult>();
			foreach (ParagraphInfo paragraph in context.Paragraphs)
			{
				if (list.Count >= num)
				{
					break;
				}
				moDrKNabHo(paragraph, CS_8_locals_9.text, stringComparison, CS_8_locals_9.flag, num, list);
			}
			return AiHelper_5.CreateSuccess("columns", Find4(context, list, num));
		});
	}

	public AiHelper_5 FindRegex(string P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass19_0 CS_8_locals_7 = new _G_c__DisplayClass19_0();
		CS_8_locals_7.text = P_0;
		CS_8_locals_7.wjoVBnKCVJt = P_2;
		CS_8_locals_7.flag = P_1;
		return ExecuteTool("find_word_regex", delegate(DocumentSearchContext context)
		{
			if (string.IsNullOrWhiteSpace(CS_8_locals_7.text))
			{
				return AiHelper_5.CreateError("returnedRows", "returnedColumns");
			}
			int num = ClampWithDefault(CS_8_locals_7.wjoVBnKCVJt, 100, 500);
			RegexOptions options = ((!CS_8_locals_7.flag) ? RegexOptions.IgnoreCase : RegexOptions.None);
			Regex regex = new Regex(CS_8_locals_7.text, options);
			List<TextMatchResult> list = new List<TextMatchResult>();
			foreach (ParagraphInfo paragraph in context.Paragraphs)
			{
				if (list.Count >= num)
				{
					break;
				}
				foreach (Match item in regex.Matches(paragraph.Text ?? string.Empty))
				{
					if (list.Count >= num)
					{
						break;
					}
					list.Add(new TextMatchResult
					{
						ParagraphIndex = paragraph.ParagraphIndex,
						CharIndexStart = item.Index + 1,
						CharIndexEnd = item.Index + item.Length,
						MatchText = item.Value,
						Excerpt = HyErOENeqf(paragraph.Text ?? string.Empty, item.Index, item.Length)
					});
				}
			}
			return AiHelper_5.CreateSuccess("headerRowCount", Find4(context, list, num));
		});
	}

	public AiHelper_5 ExecuteTool5(string P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass20_0 CS_8_locals_9 = new _G_c__DisplayClass20_0();
		CS_8_locals_9.text = P_0;
		CS_8_locals_9.value = P_2;
		CS_8_locals_9.flag = P_1;
		return ExecuteTool("find_word_table_text", delegate(DocumentSearchContext context)
		{
			if (string.IsNullOrWhiteSpace(CS_8_locals_9.text))
			{
				return AiHelper_5.CreateError("rowsData", "cellsFlat");
			}
			int num = ClampWithDefault(CS_8_locals_9.value, 100, 500);
			StringComparison comparisonType = ((!CS_8_locals_9.flag) ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
			List<object> list = new List<object>();
			foreach (DocumentContextInfo table in context.Tables)
			{
				if (list.Count >= num)
				{
					break;
				}
				for (int i = 0; i < table.Matrix.Count; i++)
				{
					if (list.Count >= num)
					{
						break;
					}
					for (int j = 0; j < table.Matrix[i].Count; j++)
					{
						if (list.Count >= num)
						{
							break;
						}
						string text = table.Matrix[i][j] ?? string.Empty;
						int num2 = text.IndexOf(CS_8_locals_9.text, comparisonType);
						if (num2 >= 0)
						{
							list.Add(new
							{
								actionableRange = false,
								tableIndex = table.TableIndex,
								rowIndex = i + 1,
								columnIndex = j + 1,
								rangeStart = (int?)null,
								rangeEnd = (int?)null,
								matchText = text.Substring(num2, CS_8_locals_9.text.Length),
								excerpt = HyErOENeqf(text, num2, CS_8_locals_9.text.Length)
							});
						}
					}
				}
			}
			Dictionary<string, object> dictionary = BuildDocumentInfo(context);
			dictionary["fillableCells"] = false;
			dictionary["mergedCells"] = "markdown";
			dictionary["rawText"] = list.Count;
			dictionary["hasMergedOrUnavailableCells"] = list.Count >= num;
			dictionary["expandedMergedCells"] = list;
			return AiHelper_5.CreateSuccess("truncated", dictionary);
		});
	}

	private AiHelper_5 ExecuteTool(string P_0, Func<DocumentSearchContext, AiHelper_5> P_1)
	{
		try
		{
			DocumentSearchContext searchContextInstance = GetCachedDocumentContext();
			if (searchContextInstance != null)
			{
				return P_1(searchContextInstance);
			}
			DocumentContextSnapshot ibFJ0vzQEvqcMM5hWZb = CaptureDocumentContext();
			if (ibFJ0vzQEvqcMM5hWZb.Error != null)
			{
				return ibFJ0vzQEvqcMM5hWZb.Error;
			}
			DocumentSearchContext documentContext = DocumentSearchContext.hhudkjcOIs(ibFJ0vzQEvqcMM5hWZb);
			DocumentLifecycleGuard.SetCachedProperty(ibFJ0vzQEvqcMM5hWZb.DocumentKey, documentContext);
			return P_1(documentContext);
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateExceptionError(P_0 + " failed", "word_read_error", ex);
		}
	}

	private DocumentSearchContext GetCachedDocumentContext()
	{
		WordWindowInfo current = DocumentLifecycleGuard.Current;
		if (current == null || !current.HasDocument)
		{
			return null;
		}
		if (_aiTargetBinder != null && !string.Equals(current.WindowKey, _aiTargetBinder.WindowKey, StringComparison.OrdinalIgnoreCase))
		{
			return null;
		}
		return DocumentLifecycleGuard.GetCachedProperty(ResolveDocumentKey(current.DocumentName, current.DocumentFullName)) as DocumentSearchContext;
	}

	private DocumentContextSnapshot CaptureDocumentContext()
	{
		return ExecuteWithWarnings(delegate(Application app)
		{
			_G_c__DisplayClass23_0 CS_8_locals_7 = new _G_c__DisplayClass23_0();
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new DocumentContextSnapshot
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			CS_8_locals_7.VSQVBPeQEih = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = EnsureDocumentOpen3(CS_8_locals_7.VSQVBPeQEih);
			if (insertResult != null)
			{
				return new DocumentContextSnapshot
				{
					Error = insertResult
				};
			}
			string text2 = TryEvaluateString(() => CS_8_locals_7.VSQVBPeQEih.Name);
			string text3 = TryEvaluateString(() => CS_8_locals_7.VSQVBPeQEih.FullName);
			string text4 = TryEvaluateString(() => CS_8_locals_7.VSQVBPeQEih.Content.WordOpenXML);
			if (string.IsNullOrWhiteSpace(text4))
			{
				throw new InvalidDataException("writeCoordinateExample");
			}
			return new DocumentContextSnapshot
			{
				DocumentName = text2,
				DocumentFullName = text3,
				DocumentKey = ResolveDocumentKey(text2, text3),
				DocumentSaved = TryEvaluateBool2(() => CS_8_locals_7.VSQVBPeQEih.Saved, false),
				TrackRevisions = TryEvaluateBool2(() => CS_8_locals_7.VSQVBPeQEih.TrackRevisions, false),
				Selection = SelectionRangeInfo.CaptureSelectionRange(app),
				WordOpenXml = text4
			};
		});
	}

	private DocumentOperationResult ReadSelectionRange()
	{
		return ExecuteWithWarnings(delegate(Application app)
		{
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new DocumentOperationResult
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			Document document = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = EnsureDocumentOpen3(document);
			if (insertResult != null)
			{
				return new DocumentOperationResult
				{
					Error = insertResult
				};
			}
			Selection selection = app?.Selection;
			return (selection == null || selection.Range == null) ? new DocumentOperationResult
			{
				Error = AiHelper_5.CreateError("1-based rowIndex from cellsFlat/fillableCells", "1-based columnIndex from cellsFlat/fillableCells")
			} : ReadRangeFromDocument(document, selection.Range);
		});
	}

	private DocumentOperationResult ReadWordRange(int P_0, int P_1)
	{
		_G_c__DisplayClass25_0 CS_8_locals_4 = new _G_c__DisplayClass25_0();
		CS_8_locals_4.value = P_0;
		CS_8_locals_4.value = P_1;
		return ExecuteWithWarnings(delegate(Application app)
		{
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new DocumentOperationResult
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			Document document = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = EnsureDocumentOpen3(document);
			if (insertResult != null)
			{
				return new DocumentOperationResult
				{
					Error = insertResult
				};
			}
			object Start = CS_8_locals_4.value;
			object End = CS_8_locals_4.value;
			return ReadRangeFromDocument(document, document.Range(ref Start, ref End));
		});
	}

	private static DocumentOperationResult ReadRangeFromDocument(Document P_0, Range P_1)
	{
		_G_c__DisplayClass26_0 CS_8_locals_8 = new _G_c__DisplayClass26_0();
		CS_8_locals_8.range = P_1;
		CS_8_locals_8.doc = P_0;
		string wordOpenXml = TryEvaluateString(() => CS_8_locals_8.range.WordOpenXML);
		return new DocumentOperationResult
		{
			DocumentName = TryEvaluateString(() => CS_8_locals_8.doc.Name),
			DocumentFullName = TryEvaluateString(() => CS_8_locals_8.doc.FullName),
			DocumentSaved = TryEvaluateBool2(() => CS_8_locals_8.doc.Saved, false),
			RangeStart = VMbreGvrrq(() => CS_8_locals_8.range.Start, 0),
			RangeEnd = VMbreGvrrq(() => CS_8_locals_8.range.End, 0),
			WordOpenXml = wordOpenXml
		};
	}

	private Dictionary<int, TableRangeInfo> GetTableRangesFromApp(int P_0, int P_1)
	{
		_G_c__DisplayClass27_0 CS_8_locals_7 = new _G_c__DisplayClass27_0();
		CS_8_locals_7.value = P_0;
		CS_8_locals_7.value = P_1;
		return ExecuteWithWarnings(delegate(Application app)
		{
			Dictionary<int, TableRangeInfo> dictionary = new Dictionary<int, TableRangeInfo>();
			try
			{
				_G_c__DisplayClass27_1 CS_8_locals_9 = new _G_c__DisplayClass27_1();
				if (!string.IsNullOrWhiteSpace(WordAgentRuntimeGuard2.GetNotReadyMessage(app)))
				{
					return dictionary;
				}
				CS_8_locals_9.doc = DocumentLifecycleGuard.GetActiveDocument(app);
				if (EnsureDocumentOpen3(CS_8_locals_9.doc) != null)
				{
					return dictionary;
				}
				int val = VMbreGvrrq(() => CS_8_locals_9.doc.Tables.Count, 0);
				int num = Math.Max(1, CS_8_locals_7.value);
				int num2 = Math.Min(val, CS_8_locals_7.value);
				for (int num3 = num; num3 <= num2; num3++)
				{
					try
					{
						Range range = CS_8_locals_9.doc.Tables[num3].Range;
						dictionary[num3] = new TableRangeInfo
						{
							RangeStart = range.Start,
							RangeEnd = range.End
						};
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			return dictionary;
		});
	}

	private RangeReadResult ExecuteTableReadOperation(int P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass28_0 CS_8_locals_21 = new _G_c__DisplayClass28_0();
		CS_8_locals_21.value = P_0;
		CS_8_locals_21.value = P_1;
		CS_8_locals_21.value = P_2;
		return ExecuteWithWarnings(delegate(Application app)
		{
			_G_c__DisplayClass28_1 CS_8_locals_33 = new _G_c__DisplayClass28_1();
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new RangeReadResult
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			CS_8_locals_33.doc = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = EnsureDocumentOpen3(CS_8_locals_33.doc);
			if (insertResult != null)
			{
				return new RangeReadResult
				{
					Error = insertResult
				};
			}
			int start = CS_8_locals_33.doc.Content.Start;
			int end = CS_8_locals_33.doc.Content.End;
			if (CS_8_locals_21.value < start || CS_8_locals_21.value > end || CS_8_locals_21.value <= CS_8_locals_21.value)
			{
				return new RangeReadResult
				{
					Error = AiHelper_5.CreateError("oldText from fillableCells", "new cell text", new
					{
						rangeStart = CS_8_locals_21.value,
						rangeEnd = CS_8_locals_21.value,
						contentStart = start,
						contentEnd = end
					})
				};
			}
			Document document = CS_8_locals_33.doc;
			object Start = CS_8_locals_21.value;
			object End = CS_8_locals_21.value;
			CS_8_locals_33.range = document.Range(ref Start, ref End);
			RangeReadResult instance3 = new RangeReadResult
			{
				DocumentName = TryEvaluateString(() => CS_8_locals_33.doc.Name),
				DocumentFullName = TryEvaluateString(() => CS_8_locals_33.doc.FullName),
				DocumentSaved = TryEvaluateBool2(() => CS_8_locals_33.doc.Saved, false),
				RangeStart = CS_8_locals_21.value,
				RangeEnd = CS_8_locals_21.value,
				TotalTablesInRange = VMbreGvrrq(() => CS_8_locals_33.range.Tables.Count, 0)
			};
			int num = Math.Min(instance3.TotalTablesInRange, CS_8_locals_21.value);
			for (int num2 = 1; num2 <= num; num2++)
			{
				_G_c__DisplayClass28_2 CS_8_locals_36 = new _G_c__DisplayClass28_2();
				Table table = CS_8_locals_33.range.Tables[num2];
				CS_8_locals_36.range = table.Range;
				TableStructureInfo tableStructureInfo = new TableStructureInfo
				{
					LocalTableIndex = num2,
					RangeStart = VMbreGvrrq(() => CS_8_locals_36.range.Start, 0),
					RangeEnd = VMbreGvrrq(() => CS_8_locals_36.range.End, 0),
					Page = GetRangeCount(CS_8_locals_36.range),
					WordOpenXml = TryEvaluateString(() => CS_8_locals_36.range.WordOpenXML)
				};
				try
				{
					IEnumerator enumerator = table.Range.Cells.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							_G_c__DisplayClass28_3 CS_8_locals_39 = new _G_c__DisplayClass28_3();
							CS_8_locals_39.cell = (Cell)enumerator.Current;
							if (TryGetCellPosition(CS_8_locals_39.cell, out var rowIndex, out var columnIndex))
							{
								tableStructureInfo.Cells.Add(new TableCellInfo
								{
									RowIndex = rowIndex,
									ColumnIndex = columnIndex,
									RangeStart = VMbreGvrrq(() => CS_8_locals_39.cell.Range.Start, 0),
									RangeEnd = VMbreGvrrq(() => CS_8_locals_39.cell.Range.End, 0),
									Page = GetRangeCount(CS_8_locals_39.cell.Range),
									Text = CleanCellText(TryEvaluateString(() => CS_8_locals_39.cell.Range.Text))
								});
							}
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				catch
				{
				}
				instance3.Tables.Add(tableStructureInfo);
			}
			return instance3;
		});
	}

	private T2 ExecuteWithWarnings<T2>(Func<Application, T2> P_0)
	{
		return _wordTableToolService4.runOperation("warnings", P_0);
	}

	private static string ResolveDocumentKey(string P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return (P_0 ?? string.Empty).Trim();
		}
		return P_1.Trim();
	}

	private static AiHelper_5 EnsureDocumentOpen3(Document P_0)
	{
		if (P_0 == null)
		{
			return AiHelper_5.CreateError("当前没有打开的 Word 文档。", "no_document");
		}
		return null;
	}

	private static Dictionary<string, object> BuildDocumentInfo(DocumentSearchContext P_0)
	{
		return new Dictionary<string, object>
		{
			["document"] = P_0.DocumentName,
			["documentFullName"] = P_0.DocumentFullName,
			["documentSaved"] = P_0.DocumentSaved
		};
	}

	private static Dictionary<string, object> BuildTableInfoDict(DocumentContextInfo P_0)
	{
		return new Dictionary<string, object>
		{
			["document"] = P_0.DocumentName,
			["documentFullName"] = P_0.DocumentFullName,
			["documentSaved"] = P_0.DocumentSaved
		};
	}

	private static object BuildParagraphInfo(ParagraphInfo P_0, int P_1)
	{
		string text = P_0.Text ?? string.Empty;
		bool flag = text.Length > P_1;
		int num = (P_0.IsHeading ? P_0.OutlineLevel : 0);
		return new
		{
			paragraphIndex = P_0.ParagraphIndex,
			isHeading = P_0.IsHeading,
			outlineKind = (P_0.IsHeading ? "body" : "heading"),
			outlineLevel = num,
			rawOutlineLevel = num,
			rangeStart = (int?)null,
			rangeEnd = (int?)null,
			actionableRange = false,
			rangeSource = "openxml_unavailable",
			characters = text.Length,
			truncated = flag,
			text = (flag ? text.Substring(0, P_1) : text)
		};
	}

	private static object BuildSelectionInfo(SelectionRangeInfo P_0, int P_1)
	{
		if (P_0 == null)
		{
			return null;
		}
		string text = P_0.Text ?? string.Empty;
		bool flag = text.Length > P_1;
		return new
		{
			page = (int?)null,
			rangeStart = P_0.RangeStart,
			rangeEnd = P_0.RangeEnd,
			characters = text.Length,
			truncated = flag,
			excerpt = (flag ? text.Substring(0, P_1) : text)
		};
	}

	private static Dictionary<string, object> BuildRangeInfo(DocumentOperationResult P_0, int P_1, int? P_2)
	{
		string text = ExtractWordXmlText(P_0.WordOpenXml);
		bool flag = text.Length > P_1;
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			["document"] = P_0.DocumentName,
			["documentFullName"] = P_0.DocumentFullName,
			["documentSaved"] = P_0.DocumentSaved,
			["page"] = null,
			["rangeStart"] = P_0.RangeStart,
			["rangeEnd"] = P_0.RangeEnd,
			["characters"] = text.Length,
			["truncated"] = flag,
			["text"] = (flag ? text.Substring(0, P_1) : text)
		};
		if (P_2.HasValue)
		{
			dictionary["paragraphIndex"] = P_2.Value;
		}
		return dictionary;
	}

	private static object BuildTableMatrixInfo(DocumentSearchContext P_0, DocumentContextInfo P_1, int P_2, int P_3, Dictionary<int, TableRangeInfo> P_4 = null)
	{
		int num = Math.Min(P_1.Matrix.Count, P_2);
		int num2 = ((P_1.Matrix.Count != 0) ? Math.Min(P_1.Matrix.Max((List<string> r) => r.Count), P_3) : 0);
		List<List<string>> list = new List<List<string>>();
		for (int num3 = 0; num3 < num; num3++)
		{
			List<string> list2 = new List<string>();
			for (int num4 = 0; num4 < num2; num4++)
			{
				list2.Add((num4 < P_1.Matrix[num3].Count) ? P_1.Matrix[num3][num4] : string.Empty);
			}
			list.Add(list2);
		}
		TableRangeInfo value = null;
		bool flag = P_4 != null && P_4.TryGetValue(P_1.TableIndex, out value) && value != null && value.RangeEnd >= value.RangeStart;
		Dictionary<string, object> dictionary = BuildTableInfoDict(P_1);
		dictionary["index"] = P_1.TableIndex;
		dictionary["altTextTitle"] = NjbrCnStHb(P_1.AltTextTitle);
		dictionary["altTextDescription"] = NjbrCnStHb(P_1.AltTextDescription);
		dictionary["rows"] = P_1.Matrix.Count;
		dictionary["columns"] = ((P_1.Matrix.Count != 0) ? P_1.Matrix.Max((List<string> r) => r.Count) : 0);
		dictionary["returnedRows"] = num;
		dictionary["returnedColumns"] = num2;
		dictionary["page"] = null;
		dictionary["paragraphIndex"] = P_1.FirstParagraphIndex;
		dictionary["rangeStart"] = (flag ? new int?(value.RangeStart) : ((int?)null));
		dictionary["rangeEnd"] = (flag ? new int?(value.RangeEnd) : ((int?)null));
		dictionary["actionableRange"] = flag;
		dictionary["rangeSource"] = (flag ? "openxml_unavailable" : "word_com_table_range");
		dictionary["previousParagraph"] = FindInDocument(P_0, P_1.TableIndex, -1);
		dictionary["nextParagraph"] = FindInDocument(P_0, P_1.TableIndex, 1);
		dictionary["truncated"] = P_1.Matrix.Count > num || (P_1.Matrix.Count > 0 && P_1.Matrix.Max((List<string> r) => r.Count) > num2);
		dictionary["rowsData"] = FlattenMatrix(list);
		dictionary["cellsFlat"] = ((IEnumerable<object>)P_1.Cells.Select((TableCellData c) => new
		{
			cellIndex = c.CellIndex,
			rowIndex = c.RowIndex,
			columnIndex = c.ColumnIndex,
			rowSpan = c.RowSpan,
			columnSpan = c.ColumnSpan,
			page = (int?)null,
			rangeStart = (int?)null,
			rangeEnd = (int?)null,
			actionableRange = false,
			rangeSource = "markdown",
			text = c.Text
		})).ToList();
		dictionary["rawText"] = BuildMarkdownTable(list);
		dictionary["hasMergedOrUnavailableCells"] = TruncateWithEllipsis(P_1.RawText, 3000);
		dictionary["expandedMergedCells"] = P_1.HasMergedCells;
		dictionary["warnings"] = P_1.HasMergedCells;
		dictionary["未能读取该表格的真实 Word COM 单元格坐标，写入工具可能无法定位。"] = new string[0];
		return dictionary;
	}

	private static DocumentContextInfo ExtractTableFromRange(RangeReadResult P_0, TableStructureInfo P_1)
	{
		if (P_0 == null || P_1 == null || string.IsNullOrWhiteSpace(P_1.WordOpenXml))
		{
			return null;
		}
		using DocumentSearchContext searchContextInstance = DocumentSearchContext.hhudkjcOIs(new DocumentContextSnapshot
		{
			DocumentName = P_0.DocumentName,
			DocumentFullName = P_0.DocumentFullName,
			DocumentSaved = P_0.DocumentSaved,
			TrackRevisions = false,
			WordOpenXml = P_1.WordOpenXml
		});
		DocumentContextInfo tABVE1VR66mkVrCsbLlX2 = searchContextInstance.Tables.FirstOrDefault();
		if (tABVE1VR66mkVrCsbLlX2 == null)
		{
			return null;
		}
		tABVE1VR66mkVrCsbLlX2.TableIndex = P_1.LocalTableIndex;
		return tABVE1VR66mkVrCsbLlX2;
	}

	private static object i041zjkxm7(DocumentContextInfo P_0, TableStructureInfo P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass39_0 CS_8_locals_25 = new _G_c__DisplayClass39_0();
		CS_8_locals_25.tableStructureInfo = P_1;
		CS_8_locals_25.DocumentContextInfo = P_0;
		int count = CS_8_locals_25.DocumentContextInfo.Matrix.Count;
		int num = ((CS_8_locals_25.DocumentContextInfo.Matrix.Count != 0) ? CS_8_locals_25.DocumentContextInfo.Matrix.Max((List<string> r) => r.Count) : 0);
		int num2 = Math.Min(count, P_2);
		int num3 = Math.Min(num, P_3);
		List<List<string>> list = new List<List<string>>();
		for (int num4 = 0; num4 < num2; num4++)
		{
			List<string> list2 = new List<string>();
			for (int num5 = 0; num5 < num3; num5++)
			{
				list2.Add((num5 < CS_8_locals_25.DocumentContextInfo.Matrix[num4].Count) ? CS_8_locals_25.DocumentContextInfo.Matrix[num4][num5] : string.Empty);
			}
			list.Add(list2);
		}
		List<MergedCellRange> list3 = nlxrVudBFD(CS_8_locals_25.DocumentContextInfo);
		int num6 = FindFirstNonMergedRow(CS_8_locals_25.DocumentContextInfo, list3);
		Dictionary<string, TableCellInfo> dictionary = BuildCellDictionaryFromTable(CS_8_locals_25.tableStructureInfo);
		List<Dictionary<string, object>> list4 = BuildCellInfoList(CS_8_locals_25.DocumentContextInfo, CS_8_locals_25.tableStructureInfo.LocalTableIndex, num6, num2, num3, dictionary);
		List<object> value = ((IEnumerable<object>)(from item in list4
			where string.Equals(GetDictionaryString(item, "localTableIndex"), "rangeStart", StringComparison.Ordinal) && GetDictionaryBool(item, "rangeEnd")
			select new Dictionary<string, object>
			{
				["page"] = GetDictionaryString(item, "actionableRange"),
				["rangeSource"] = CS_8_locals_25.tableStructureInfo.LocalTableIndex,
				["word_com_selection_table_range"] = GetDictionaryInt(item, "rows"),
				["columns"] = GetDictionaryInt(item, "returnedRows"),
				["returnedColumns"] = GetDictionaryBool(item, "headerRowCount"),
				["rowsData"] = false,
				["cellsFlat"] = GetDictionaryString(item, "fillableCells"),
				["mergedCells"] = item["markdown"],
				["rawText"] = item["hasMergedOrUnavailableCells"],
				["expandedMergedCells"] = item["truncated"]
			})).ToList();
		Dictionary<string, object> dictionary2 = BuildTableInfoDict(CS_8_locals_25.DocumentContextInfo);
		dictionary2["writeCoordinateExample"] = CS_8_locals_25.tableStructureInfo.LocalTableIndex;
		dictionary2["1-based rowIndex from cellsFlat/fillableCells"] = CS_8_locals_25.tableStructureInfo.RangeStart;
		dictionary2["1-based columnIndex from cellsFlat/fillableCells"] = CS_8_locals_25.tableStructureInfo.RangeEnd;
		dictionary2["oldText from fillableCells"] = CS_8_locals_25.tableStructureInfo.Page;
		dictionary2["new cell text"] = CS_8_locals_25.tableStructureInfo.RangeEnd >= CS_8_locals_25.tableStructureInfo.RangeStart;
		dictionary2["warnings"] = "未能读取该表格的真实 Word COM 单元格坐标，写入工具可能无法定位。";
		dictionary2["cellId"] = count;
		dictionary2["cellKind"] = num;
		dictionary2["origin"] = num2;
		dictionary2["localTableIndex"] = num3;
		dictionary2["rowIndex"] = num6;
		dictionary2["columnIndex"] = FlattenMatrix(list);
		dictionary2["rowSpan"] = list4;
		dictionary2["columnSpan"] = value;
		dictionary2["isHeader"] = ((IEnumerable<object>)list3.Select((MergedCellRange m) => new
		{
			startRow = m.StartRow,
			startColumn = m.StartColumn,
			endRow = m.EndRow,
			endColumn = m.EndColumn,
			text = (FindCellAtPosition(CS_8_locals_25.DocumentContextInfo, m.StartRow, m.StartColumn)?.Text ?? string.Empty)
		})).ToList();
		dictionary2["requiresAllowHeaderEdit"] = BuildMarkdownTable(list);
		dictionary2["defaultWritable"] = TruncateWithEllipsis(CS_8_locals_25.DocumentContextInfo.RawText, 3000);
		dictionary2["page"] = CS_8_locals_25.DocumentContextInfo.HasMergedCells;
		dictionary2["rangeStart"] = CS_8_locals_25.DocumentContextInfo.HasMergedCells;
		dictionary2["rangeEnd"] = count > num2 || num > num3;
		dictionary2["actionableRange"] = new
		{
			localTableIndex = CS_8_locals_25.tableStructureInfo.LocalTableIndex,
			rowIndex = "rangeSource",
			columnIndex = "unavailable",
			expectedOldText = "word_com_table_cell",
			text = "text"
		};
		dictionary2["columnHeaderPath"] = ((dictionary.Count != 0) ? new string[0] : new string[1] { "rowLabelPath" });
		return dictionary2;
	}

	private static List<Dictionary<string, object>> BuildCellInfoList(DocumentContextInfo P_0, int P_1, int P_2, int P_3, int P_4, Dictionary<string, TableCellInfo> P_5)
	{
		List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
		foreach (TableCellData item in from c in P_0.Cells
			orderby c.RowIndex, c.ColumnIndex
			select c)
		{
			if (item.RowIndex <= P_3 && item.ColumnIndex <= P_4)
			{
				TableCellInfo value;
				bool flag = P_5.TryGetValue(BuildCellKey(item.RowIndex, item.ColumnIndex), out value);
				bool flag2 = item.RowIndex <= P_2;
				string value2 = BuildCellId(P_1, item.RowIndex, item.ColumnIndex);
				list.Add(new Dictionary<string, object>
				{
					["cellId"] = value2,
					["cellKind"] = "origin",
					["localTableIndex"] = P_1,
					["rowIndex"] = item.RowIndex,
					["columnIndex"] = item.ColumnIndex,
					["rowSpan"] = item.RowSpan,
					["columnSpan"] = item.ColumnSpan,
					["isHeader"] = flag2,
					["requiresAllowHeaderEdit"] = false,
					["defaultWritable"] = flag,
					["page"] = (flag ? new int?(value.Page) : ((int?)null)),
					["rangeStart"] = (flag ? new int?(value.RangeStart) : ((int?)null)),
					["rangeEnd"] = (flag ? new int?(value.RangeEnd) : ((int?)null)),
					["actionableRange"] = flag,
					["rangeSource"] = (flag ? "unavailable" : "word_com_table_cell"),
					["text"] = item.Text ?? string.Empty,
					["columnHeaderPath"] = CollectContextStrings2(P_0, item.RowIndex, item.ColumnIndex, P_2),
					["rowLabelPath"] = CollectContextStrings3(P_0, item.RowIndex, item.ColumnIndex, P_2),
					["rowLeftContext"] = CollectContextStrings(P_0, item.RowIndex, item.ColumnIndex, P_2),
					["writeCoordinate"] = (flag ? new
					{
						localTableIndex = P_1,
						rowIndex = item.RowIndex,
						columnIndex = item.ColumnIndex
					} : null)
				});
			}
		}
		foreach (TableCellData item2 in from c in P_0.Cells
			orderby c.RowIndex, c.ColumnIndex
			select c)
		{
			for (int num = item2.RowIndex; num < item2.RowIndex + item2.RowSpan; num++)
			{
				for (int num2 = item2.ColumnIndex; num2 < item2.ColumnIndex + item2.ColumnSpan; num2++)
				{
					if ((num != item2.RowIndex || num2 != item2.ColumnIndex) && num <= P_3 && num2 <= P_4)
					{
						list.Add(new Dictionary<string, object>
						{
							["cellId"] = BuildCellId(P_1, num, num2),
							["cellKind"] = "mergedInterior",
							["localTableIndex"] = P_1,
							["rowIndex"] = num,
							["columnIndex"] = num2,
							["originCellId"] = BuildCellId(P_1, item2.RowIndex, item2.ColumnIndex),
							["originRowIndex"] = item2.RowIndex,
							["originColumnIndex"] = item2.ColumnIndex,
							["rowSpan"] = 0,
							["columnSpan"] = 0,
							["isHeader"] = num <= P_2,
							["requiresAllowHeaderEdit"] = false,
							["defaultWritable"] = false,
							["page"] = null,
							["rangeStart"] = null,
							["rangeEnd"] = null,
							["actionableRange"] = false,
							["rangeSource"] = "merged_interior",
							["text"] = item2.Text ?? string.Empty,
							["columnHeaderPath"] = CollectContextStrings2(P_0, num, num2, P_2),
							["rowLabelPath"] = CollectContextStrings3(P_0, num, num2, P_2),
							["rowLeftContext"] = CollectContextStrings(P_0, num, num2, P_2),
							["writeCoordinate"] = null
						});
					}
				}
			}
		}
		return (from item in list
			orderby GetDictionaryInt(item, "rowLeftContext"), GetDictionaryInt(item, "writeCoordinate"), (!string.Equals(GetDictionaryString(item, "cellId"), "cellKind", StringComparison.Ordinal)) ? 1 : 0
			select item).ToList();
	}

	private static List<MergedCellRange> nlxrVudBFD(DocumentContextInfo P_0)
	{
		List<MergedCellRange> list = new List<MergedCellRange>();
		if (P_0 == null)
		{
			return list;
		}
		foreach (TableCellData cell in P_0.Cells)
		{
			int num = cell.RowIndex + Math.Max(1, cell.RowSpan) - 1;
			int num2 = cell.ColumnIndex + Math.Max(1, cell.ColumnSpan) - 1;
			if (num > cell.RowIndex || num2 > cell.ColumnIndex)
			{
				list.Add(new MergedCellRange
				{
					StartRow = cell.RowIndex,
					StartColumn = cell.ColumnIndex,
					EndRow = num,
					EndColumn = num2
				});
			}
		}
		return list;
	}

	private static int FindFirstNonMergedRow(DocumentContextInfo P_0, List<MergedCellRange> P_1)
	{
		if (P_0 == null || P_0.Matrix.Count <= 0)
		{
			return 0;
		}
		if (P_1 == null || P_1.Count == 0)
		{
			return 1;
		}
		int num = 0;
		int count = P_0.Matrix.Count;
		_G_c__DisplayClass42_0 CS_8_locals_6 = new _G_c__DisplayClass42_0();
		CS_8_locals_6.value = 1;
		while (CS_8_locals_6.value <= count && P_1.Any((MergedCellRange merge) => merge.StartRow <= CS_8_locals_6.value && merge.EndRow >= CS_8_locals_6.value))
		{
			num = CS_8_locals_6.value;
			CS_8_locals_6.value++;
		}
		bool flag;
		do
		{
			flag = false;
			foreach (MergedCellRange item in P_1)
			{
				if (item.StartRow <= num && item.EndRow > num)
				{
					num = item.EndRow;
					flag = true;
				}
			}
		}
		while (flag);
		return Math.Min(Math.Max(1, num), count);
	}

	private static List<string> CollectContextStrings2(DocumentContextInfo P_0, int P_1, int P_2, int P_3)
	{
		List<string> list = new List<string>();
		if (P_0 == null || P_3 <= 0 || P_2 <= 0)
		{
			return list;
		}
		int num = ((P_1 <= P_3) ? Math.Min(P_1, P_3) : P_3);
		HashSet<string> hashSet = new HashSet<string>(StringComparer.Ordinal);
		for (int i = 1; i <= num; i++)
		{
			TableCellData yYk52kVRJmeQHGAAHZBB2 = FindCellAtPosition(P_0, i, P_2);
			if (yYk52kVRJmeQHGAAHZBB2 != null)
			{
				string item = BuildCellKey(yYk52kVRJmeQHGAAHZBB2.RowIndex, yYk52kVRJmeQHGAAHZBB2.ColumnIndex);
				string text = yYk52kVRJmeQHGAAHZBB2.Text ?? string.Empty;
				if (hashSet.Add(item) && !string.IsNullOrWhiteSpace(text) && !GetCount13(list, text))
				{
					list.Add(text);
				}
			}
		}
		return list;
	}

	private static List<string> CollectContextStrings3(DocumentContextInfo P_0, int P_1, int P_2, int P_3)
	{
		List<string> list = new List<string>();
		if (P_0 == null || P_1 <= P_3 || P_2 <= 1)
		{
			return list;
		}
		HashSet<string> hashSet = new HashSet<string>(StringComparer.Ordinal);
		for (int i = 1; i < P_2; i++)
		{
			TableCellData yYk52kVRJmeQHGAAHZBB2 = FindCellAtPosition(P_0, P_1, i);
			if (yYk52kVRJmeQHGAAHZBB2 != null && yYk52kVRJmeQHGAAHZBB2.RowIndex > P_3)
			{
				string item = BuildCellKey(yYk52kVRJmeQHGAAHZBB2.RowIndex, yYk52kVRJmeQHGAAHZBB2.ColumnIndex);
				string text = yYk52kVRJmeQHGAAHZBB2.Text ?? string.Empty;
				if (hashSet.Add(item) && !string.IsNullOrWhiteSpace(text) && !GetCount10(text) && !GetCount13(list, text))
				{
					list.Add(text);
				}
			}
		}
		return list;
	}

	private static List<string> CollectContextStrings(DocumentContextInfo P_0, int P_1, int P_2, int P_3)
	{
		List<string> list = new List<string>();
		if (P_0 == null || P_1 <= P_3 || P_2 <= 1)
		{
			return list;
		}
		HashSet<string> hashSet = new HashSet<string>(StringComparer.Ordinal);
		for (int i = 1; i < P_2; i++)
		{
			if (list.Count >= 8)
			{
				break;
			}
			TableCellData yYk52kVRJmeQHGAAHZBB2 = FindCellAtPosition(P_0, P_1, i);
			if (yYk52kVRJmeQHGAAHZBB2 != null && yYk52kVRJmeQHGAAHZBB2.RowIndex > P_3)
			{
				string item = BuildCellKey(yYk52kVRJmeQHGAAHZBB2.RowIndex, yYk52kVRJmeQHGAAHZBB2.ColumnIndex);
				string text = yYk52kVRJmeQHGAAHZBB2.Text ?? string.Empty;
				if (hashSet.Add(item) && !string.IsNullOrWhiteSpace(text) && !GetCount13(list, text))
				{
					list.Add(text);
				}
			}
		}
		return list;
	}

	private static TableCellData FindCellAtPosition(DocumentContextInfo P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass46_0 CS_8_locals_6 = new _G_c__DisplayClass46_0();
		CS_8_locals_6.value = P_1;
		CS_8_locals_6.value = P_2;
		return P_0?.Cells.FirstOrDefault((TableCellData cell) => cell.RowIndex <= CS_8_locals_6.value && CS_8_locals_6.value < cell.RowIndex + Math.Max(1, cell.RowSpan) && cell.ColumnIndex <= CS_8_locals_6.value && CS_8_locals_6.value < cell.ColumnIndex + Math.Max(1, cell.ColumnSpan));
	}

	private static Dictionary<string, TableCellInfo> BuildCellDictionaryFromTable(TableStructureInfo P_0)
	{
		Dictionary<string, TableCellInfo> dictionary = new Dictionary<string, TableCellInfo>(StringComparer.Ordinal);
		if (P_0 == null)
		{
			return dictionary;
		}
		foreach (TableCellInfo cell in P_0.Cells)
		{
			string key = BuildCellKey(cell.RowIndex, cell.ColumnIndex);
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = cell;
			}
		}
		return dictionary;
	}

	private static string BuildCellKey(int P_0, int P_1)
	{
		return P_0.ToString(CultureInfo.InvariantCulture) + ":" + P_1.ToString(CultureInfo.InvariantCulture);
	}

	private static string BuildCellId(int P_0, int P_1, int P_2)
	{
		return "t" + P_0.ToString(CultureInfo.InvariantCulture) + "r" + P_1.ToString(CultureInfo.InvariantCulture) + "c" + P_2.ToString(CultureInfo.InvariantCulture);
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

	private static int GetRangeCount(Range P_0)
	{
		try
		{
			return (P_0 != null) ? ((int)(dynamic)P_0.get_Information(WdInformation.wdActiveEndPageNumber)) : 0;
		}
		catch
		{
			return 0;
		}
	}

	private static bool GetCount10(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		string s = P_0.Trim().Replace(",", string.Empty).TrimEnd('%');
		if (!decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
		{
			return decimal.TryParse(s, NumberStyles.Number, CultureInfo.CurrentCulture, out result);
		}
		return true;
	}

	private static bool GetCount13(List<string> P_0, string P_1)
	{
		if (P_0.Count > 0)
		{
			return string.Equals(P_0[P_0.Count - 1], P_1, StringComparison.Ordinal);
		}
		return false;
	}

	private static string GetDictionaryString(Dictionary<string, object> P_0, string P_1)
	{
		if (P_0 == null || !P_0.TryGetValue(P_1, out var value) || value == null)
		{
			return string.Empty;
		}
		return Convert.ToString(value, CultureInfo.InvariantCulture);
	}

	private static int GetDictionaryInt(Dictionary<string, object> P_0, string P_1)
	{
		if (P_0 == null || !P_0.TryGetValue(P_1, out var value) || value == null)
		{
			return 0;
		}
		try
		{
			return Convert.ToInt32(value, CultureInfo.InvariantCulture);
		}
		catch
		{
			return 0;
		}
	}

	private static bool GetDictionaryBool(Dictionary<string, object> P_0, string P_1)
	{
		if (P_0 == null || !P_0.TryGetValue(P_1, out var value) || value == null)
		{
			return false;
		}
		try
		{
			return Convert.ToBoolean(value, CultureInfo.InvariantCulture);
		}
		catch
		{
			return false;
		}
	}

	private static object FindInDocument(DocumentSearchContext P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass57_0 CS_8_locals_2 = new _G_c__DisplayClass57_0();
		CS_8_locals_2.value = P_1;
		if (P_0 == null)
		{
			return null;
		}
		int num = P_0.Blocks.FindIndex((DocumentBlock b) => b.Table != null && b.TableIndex == CS_8_locals_2.value);
		if (num < 0)
		{
			return null;
		}
		for (int num2 = num + P_2; num2 >= 0 && num2 < P_0.Blocks.Count; num2 += P_2)
		{
			ParagraphInfo paragraph = P_0.Blocks[num2].Paragraph;
			if (paragraph != null && !string.IsNullOrWhiteSpace(paragraph.Text))
			{
				return BuildParagraphInfo(paragraph, 500);
			}
		}
		return null;
	}

	private static object Find4(DocumentSearchContext P_0, List<TextMatchResult> P_1, int P_2)
	{
		_G_c__DisplayClass58_0 CS_8_locals_4 = new _G_c__DisplayClass58_0();
		CS_8_locals_4.DocumentSearchContext = P_0;
		Dictionary<string, object> dictionary = BuildDocumentInfo(CS_8_locals_4.DocumentSearchContext);
		dictionary["actionableRange"] = false;
		dictionary["rangeWarning"] = "该查找结果不包含可用于写入的 Word Range；如需批注、选中或替换，请使用 find_word_text 获取真实 Range。";
		dictionary["returned"] = P_1.Count;
		dictionary["truncated"] = P_1.Count >= P_2;
		dictionary["matches"] = ((IEnumerable<object>)P_1.Select((TextMatchResult match) => new
		{
			actionableRange = false,
			document = CS_8_locals_4.DocumentSearchContext.DocumentName,
			documentFullName = CS_8_locals_4.DocumentSearchContext.DocumentFullName,
			page = (int?)null,
			paragraphIndex = match.ParagraphIndex,
			charIndexStart = match.CharIndexStart,
			charIndexEnd = match.CharIndexEnd,
			rangeStart = (int?)null,
			rangeEnd = (int?)null,
			matchText = match.MatchText,
			excerpt = match.Excerpt
		})).ToList();
		return dictionary;
	}

	private static void moDrKNabHo(ParagraphInfo P_0, string P_1, StringComparison P_2, bool P_3, int P_4, List<TextMatchResult> P_5)
	{
		string text = P_0.Text ?? string.Empty;
		int num = 0;
		while (num < text.Length && P_5.Count < P_4)
		{
			int num2 = text.IndexOf(P_1, num, P_2);
			if (num2 >= 0)
			{
				if (!P_3 || IsWholeWordMatch(text, num2, P_1.Length))
				{
					P_5.Add(new TextMatchResult
					{
						ParagraphIndex = P_0.ParagraphIndex,
						CharIndexStart = num2 + 1,
						CharIndexEnd = num2 + P_1.Length,
						MatchText = text.Substring(num2, P_1.Length),
						Excerpt = HyErOENeqf(text, num2, P_1.Length)
					});
				}
				num = num2 + Math.Max(1, P_1.Length);
				continue;
			}
			break;
		}
	}

	private static ParagraphInfo GetText7(DocumentSearchContext P_0, string P_1, int P_2, int P_3, string P_4)
	{
		_G_c__DisplayClass60_0 CS_8_locals_10 = new _G_c__DisplayClass60_0();
		CS_8_locals_10.value = P_2;
		CS_8_locals_10.value = P_3;
		CS_8_locals_10.text = P_1;
		if (CS_8_locals_10.value > 0)
		{
			return P_0.Paragraphs.FirstOrDefault((ParagraphInfo p) => p.ParagraphIndex == CS_8_locals_10.value);
		}
		CS_8_locals_10.text = (P_4 ?? "contains").Trim().ToLowerInvariant();
		return P_0.Paragraphs.FirstOrDefault(delegate(ParagraphInfo p)
		{
			if (!p.IsHeading)
			{
				return false;
			}
			return (CS_8_locals_10.value <= 0 || p.OutlineLevel == CS_8_locals_10.value) && MatchesText(p.Text, CS_8_locals_10.text, CS_8_locals_10.text);
		});
	}

	private static bool MatchesText(string P_0, string P_1, string P_2)
	{
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return true;
		}
		P_0 = (P_0 ?? string.Empty).Trim();
		P_1 = P_1.Trim();
		if (!(P_2 == "equals"))
		{
			if (P_2 == "startswith")
			{
				return P_0.StartsWith(P_1, StringComparison.CurrentCultureIgnoreCase);
			}
			return P_0.IndexOf(P_1, StringComparison.CurrentCultureIgnoreCase) >= 0;
		}
		return string.Equals(P_0, P_1, StringComparison.CurrentCultureIgnoreCase);
	}

	private static List<object> FlattenMatrix(List<List<string>> P_0)
	{
		List<object> list = new List<object>();
		for (int i = 0; i < P_0.Count; i++)
		{
			list.Add(new
			{
				row = i + 1,
				cells = P_0[i]
			});
		}
		return list;
	}

	private static string BuildMarkdownTable(List<List<string>> P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < P_0.Count; i++)
		{
			List<string> list = P_0[i];
			stringBuilder.Append("| ");
			stringBuilder.Append(string.Join(" | ", ReplaceHeaderNames(list)));
			stringBuilder.AppendLine(" |");
			if (i != 0)
			{
				continue;
			}
			stringBuilder.Append("| ");
			for (int j = 0; j < list.Count; j++)
			{
				if (j > 0)
				{
					stringBuilder.Append(" | ");
				}
				stringBuilder.Append("---");
			}
			stringBuilder.AppendLine(" |");
		}
		return stringBuilder.ToString().TrimEnd();
	}

	private static IEnumerable<string> ReplaceHeaderNames(IEnumerable<string> P_0)
	{
		foreach (string item in P_0)
		{
			yield return (item ?? string.Empty).Replace("mergedInterior", "localTableIndex").Replace("rowIndex", "columnIndex").Replace("originCellId", "originRowIndex")
				.Replace("originColumnIndex", "rowSpan");
		}
	}

	private static string ExtractElementText(XElement P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XElement item in P_0.Descendants())
		{
			if (item.Name == wordNamespace + "t")
			{
				stringBuilder.Append(item.Value);
			}
			else if (item.Name == wordNamespace + "tab")
			{
				stringBuilder.Append('\t');
			}
			else if (item.Name == wordNamespace + "br" || item.Name == wordNamespace + "cr")
			{
				stringBuilder.Append('\n');
			}
		}
		return CleanCellText(stringBuilder.ToString());
	}

	private static string ExtractWordXmlText(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return string.Empty;
		}
		XDocument xDocument = XDocument.Parse(P_0);
		return ExtractElementText((ParseXmlPart(xDocument, "/word/document.xml") ?? xDocument).Root);
	}

	private static int ParseOutlineLevelFromXml(XElement P_0, Dictionary<string, int> P_1)
	{
		if (TryParseOutlineLevel((P_0.Element(wordNamespace + "pPr")?.Element(wordNamespace + "outlineLvl"))?.Attribute(wordNamespace + "val")?.Value, out var value))
		{
			return value;
		}
		string text = P_0.Element(wordNamespace + "pPr")?.Element(wordNamespace + "pStyle")?.Attribute(wordNamespace + "val")?.Value;
		if (!string.IsNullOrWhiteSpace(text) && P_1.TryGetValue(text, out value))
		{
			return value;
		}
		return 0;
	}

	private static Dictionary<string, int> UPQrbSvBKH(XDocument P_0)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		XDocument xDocument = ParseXmlPart(P_0, "/word/styles.xml");
		if (xDocument == null)
		{
			return dictionary;
		}
		foreach (XElement item in xDocument.Descendants(wordNamespace + "style"))
		{
			string text = item.Attribute(wordNamespace + "styleId")?.Value;
			if (!string.IsNullOrWhiteSpace(text) && TryParseOutlineLevel(item.Descendants(wordNamespace + "outlineLvl").FirstOrDefault()?.Attribute(wordNamespace + "val")?.Value, out var value))
			{
				dictionary[text] = value;
			}
		}
		return dictionary;
	}

	private static bool TryParseOutlineLevel(string P_0, out int P_1)
	{
		P_1 = 0;
		if (!int.TryParse(P_0, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return false;
		}
		if (result < 0 || result > 8)
		{
			return false;
		}
		P_1 = result + 1;
		return true;
	}

	private static List<CommentInfo> wpmrwTxSHp(XDocument P_0)
	{
		List<CommentInfo> list = new List<CommentInfo>();
		XDocument xDocument = ParseXmlPart(P_0, "/word/comments.xml");
		if (xDocument == null)
		{
			return list;
		}
		foreach (XElement item in xDocument.Descendants(wordNamespace + "comment"))
		{
			list.Add(new CommentInfo
			{
				Id = (item.Attribute(wordNamespace + "id")?.Value ?? string.Empty),
				Author = (item.Attribute(wordNamespace + "author")?.Value ?? string.Empty),
				Date = (item.Attribute(wordNamespace + "date")?.Value ?? string.Empty),
				Text = ExtractElementText(item)
			});
		}
		return list;
	}

	private static XDocument ParseXmlPart(XDocument P_0, string P_1)
	{
		_G_c__DisplayClass71_0 CS_8_locals_3 = new _G_c__DisplayClass71_0();
		CS_8_locals_3.text = P_1;
		if (P_0?.Root == null)
		{
			return null;
		}
		if (P_0.Root.Name == wordNamespace + "document" && string.Equals(CS_8_locals_3.text, "/word/document.xml", StringComparison.OrdinalIgnoreCase))
		{
			return P_0;
		}
		XElement xElement = P_0.Root.Elements(names1 + "part").FirstOrDefault((XElement p) => string.Equals(p.Attribute(names1 + "xmlData")?.Value, CS_8_locals_3.text, StringComparison.OrdinalIgnoreCase))?.Element(names1 + "columnSpan")?.Elements().FirstOrDefault();
		if (xElement == null)
		{
			return null;
		}
		return new XDocument(new XElement(xElement));
	}

	private static void AddParagraphFromXml(DocumentSearchContext P_0, XElement P_1)
	{
		string text = ExtractElementText(P_1);
		int num = ParseOutlineLevelFromXml(P_1, P_0.StyleOutlineLevels);
		ParagraphInfo instance4 = new ParagraphInfo
		{
			ParagraphIndex = P_0.Paragraphs.Count + 1,
			Text = text,
			OutlineLevel = num,
			IsHeading = (num >= 1 && num <= 9)
		};
		P_0.Paragraphs.Add(instance4);
		P_0.Blocks.Add(new DocumentBlock
		{
			ParagraphIndex = instance4.ParagraphIndex,
			Paragraph = instance4
		});
	}

	private static void AddTableFromXml(DocumentSearchContext P_0, XElement P_1)
	{
		DocumentContextInfo tABVE1VR66mkVrCsbLlX2 = ParseTableFromXml(P_0, P_1, P_0.Tables.Count + 1);
		P_0.Tables.Add(tABVE1VR66mkVrCsbLlX2);
		P_0.Blocks.Add(new DocumentBlock
		{
			TableIndex = tABVE1VR66mkVrCsbLlX2.TableIndex,
			FirstParagraphIndex = tABVE1VR66mkVrCsbLlX2.FirstParagraphIndex,
			Table = tABVE1VR66mkVrCsbLlX2
		});
	}

	private static DocumentContextInfo ParseTableFromXml(DocumentSearchContext P_0, XElement P_1, int P_2)
	{
		DocumentContextInfo tABVE1VR66mkVrCsbLlX2 = new DocumentContextInfo
		{
			DocumentName = P_0.DocumentName,
			DocumentFullName = P_0.DocumentFullName,
			DocumentSaved = P_0.DocumentSaved,
			TableIndex = P_2,
			FirstParagraphIndex = P_0.Paragraphs.Count + 1,
			AltTextTitle = P_1.Element(wordNamespace + "tblPr")?.Element(wordNamespace + "tblCaption")?.Attribute(wordNamespace + "val")?.Value,
			AltTextDescription = P_1.Element(wordNamespace + "tblPr")?.Element(wordNamespace + "tblDescription")?.Attribute(wordNamespace + "val")?.Value
		};
		Dictionary<int, TableCellData> dictionary = new Dictionary<int, TableCellData>();
		foreach (XElement item in P_1.Elements(wordNamespace + "tr"))
		{
			List<string> list = new List<string>();
			int num = 1;
			HashSet<TableCellData> hashSet = new HashSet<TableCellData>();
			foreach (XElement item2 in item.Elements(wordNamespace + "tc"))
			{
				while (list.Count < num - 1)
				{
					list.Add(string.Empty);
				}
				int num2 = ParseColumnSpan(item2);
				XElement xElement = item2.Element(wordNamespace + "tcPr")?.Element(wordNamespace + "vMerge");
				bool flag = xElement != null;
				bool flag2 = flag && !string.Equals(xElement.Attribute(wordNamespace + "val")?.Value, "restart", StringComparison.OrdinalIgnoreCase);
				string text = ExtractElementText(item2);
				TableCellData value = null;
				if (flag2 && dictionary.TryGetValue(num, out value))
				{
					text = value.Text;
					if (!hashSet.Contains(value))
					{
						value.RowSpan++;
						hashSet.Add(value);
					}
				}
				else
				{
					value = new TableCellData
					{
						CellIndex = tABVE1VR66mkVrCsbLlX2.Cells.Count + 1,
						RowIndex = tABVE1VR66mkVrCsbLlX2.Matrix.Count + 1,
						ColumnIndex = num,
						RowSpan = 1,
						ColumnSpan = num2,
						Text = text
					};
					tABVE1VR66mkVrCsbLlX2.Cells.Add(value);
				}
				if (num2 > 1 || flag)
				{
					tABVE1VR66mkVrCsbLlX2.HasMergedCells = true;
				}
				for (int i = 0; i < num2; i++)
				{
					list.Add(text);
					if (flag && !flag2 && value != null)
					{
						dictionary[num + i] = value;
					}
					else if (!flag)
					{
						dictionary.Remove(num + i);
					}
				}
				num += num2;
			}
			tABVE1VR66mkVrCsbLlX2.Matrix.Add(list);
		}
		tABVE1VR66mkVrCsbLlX2.RawText = CleanCellText(string.Join("\n", tABVE1VR66mkVrCsbLlX2.Matrix.Select((List<string> r) => string.Join("p", r))));
		foreach (XElement item3 in P_1.Descendants(wordNamespace + "isHeader"))
		{
			string text2 = ExtractElementText(item3);
			int num3 = ParseOutlineLevelFromXml(item3, P_0.StyleOutlineLevels);
			P_0.Paragraphs.Add(new ParagraphInfo
			{
				ParagraphIndex = P_0.Paragraphs.Count + 1,
				Text = text2,
				OutlineLevel = num3,
				IsHeading = (num3 >= 1 && num3 <= 9)
			});
		}
		return tABVE1VR66mkVrCsbLlX2;
	}

	private static int ParseColumnSpan(XElement P_0)
	{
		if (!int.TryParse(P_0.Element(wordNamespace + "tcPr")?.Element(wordNamespace + "gridSpan")?.Attribute(wordNamespace + "val")?.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) || result < 1)
		{
			return 1;
		}
		return result;
	}

	private static int ClampWithDefault(int P_0, int P_1, int P_2)
	{
		if (P_0 <= 0)
		{
			P_0 = P_1;
		}
		return Math.Max(1, Math.Min(P_0, P_2));
	}

	private static int ClampOutlineLevel(int P_0)
	{
		if (P_0 <= 0)
		{
			P_0 = 1;
		}
		return Math.Max(1, Math.Min(P_0, 9));
	}

	private static string CleanCellText(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return string.Empty;
		}
		return Regex.Replace(P_0.Replace('\a', ' '), "[ \\\\t]+", " ").Trim();
	}

	private static string NjbrCnStHb(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			return P_0;
		}
		return null;
	}

	private static string TruncateWithEllipsis(string P_0, int P_1)
	{
		if (string.IsNullOrEmpty(P_0) || P_0.Length <= P_1)
		{
			return P_0 ?? string.Empty;
		}
		return P_0.Substring(0, P_1) + "...";
	}

	private static string HyErOENeqf(string P_0, int P_1, int P_2)
	{
		int num = Math.Max(20, (160 - P_2) / 2);
		int num2 = Math.Max(0, P_1 - num);
		int num3 = Math.Min(P_0.Length, P_1 + P_2 + num);
		string text = P_0.Substring(num2, num3 - num2).Trim();
		if (num2 > 0)
		{
			text = "..." + text;
		}
		if (num3 < P_0.Length)
		{
			text += "...";
		}
		return text;
	}

	private static bool IsWholeWordMatch(string P_0, int P_1, int P_2)
	{
		bool num = P_1 <= 0 || !IsWordCharacter(P_0[P_1 - 1]);
		int num2 = P_1 + P_2;
		bool flag = num2 >= P_0.Length || !IsWordCharacter(P_0[num2]);
		return num && flag;
	}

	private static bool IsWordCharacter(char P_0)
	{
		if (!char.IsLetterOrDigit(P_0))
		{
			return P_0 == '_';
		}
		return true;
	}

	private static string TryEvaluateString(Func<string> P_0)
	{
		try
		{
			return P_0() ?? string.Empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static bool TryEvaluateBool2(Func<bool> P_0, bool P_1)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return P_1;
		}
	}

	private static int VMbreGvrrq(Func<int> P_0, int P_1)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return P_1;
		}
	}

	static BatchReplaceService2()
	{
		SseStreamInitializer.InitializeRuntime();
		wordNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
		names1 = "http://schemas.microsoft.com/office/2006/xmlPackage";
	}
}
