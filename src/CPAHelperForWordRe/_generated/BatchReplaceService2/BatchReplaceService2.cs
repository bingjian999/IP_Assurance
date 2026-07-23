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
	private sealed class a5lLcpd0tjOGP93a2IH : IDisposable
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
		private Y8ewNwzgQ3iuUtQ05mK ROgzBRlrSw;

		[CompilerGenerated]
		private Dictionary<string, int> XLTz9K9w3b;

		[CompilerGenerated]
		private readonly List<ubtWXyzzVHfe9SR37mW> JJXz6hPIUO;

		[CompilerGenerated]
		private readonly List<tABVE1VR66mkVrCsbLlX> JMJzuSFJ5k;

		[CompilerGenerated]
		private List<wcRTakVRjwo5pepnDBig> eWMzDTOs96;

		[CompilerGenerated]
		private readonly List<iltloQVRboLvh0PbMHDS> iE5zT2kBTY;

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

		public Y8ewNwzgQ3iuUtQ05mK Selection
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
				return XLTz9K9w3b;
			}
			[CompilerGenerated]
			set
			{
				XLTz9K9w3b = value;
			}
		}

		public List<ubtWXyzzVHfe9SR37mW> Paragraphs
		{
			[CompilerGenerated]
			get
			{
				return JJXz6hPIUO;
			}
		}

		public List<tABVE1VR66mkVrCsbLlX> Tables
		{
			[CompilerGenerated]
			get
			{
				return JMJzuSFJ5k;
			}
		}

		public List<wcRTakVRjwo5pepnDBig> Comments
		{
			[CompilerGenerated]
			get
			{
				return eWMzDTOs96;
			}
			[CompilerGenerated]
			set
			{
				eWMzDTOs96 = value;
			}
		}

		public List<iltloQVRboLvh0PbMHDS> Blocks
		{
			[CompilerGenerated]
			get
			{
				return iE5zT2kBTY;
			}
		}

		public static a5lLcpd0tjOGP93a2IH hhudkjcOIs(IbFJ0vzQEvqcMM5hWZb P_0)
		{
			a5lLcpd0tjOGP93a2IH a5lLcpd0tjOGP93a2IH2 = new a5lLcpd0tjOGP93a2IH
			{
				DocumentName = P_0.DocumentName,
				DocumentFullName = P_0.DocumentFullName,
				DocumentSaved = P_0.DocumentSaved,
				TrackRevisions = P_0.TrackRevisions,
				Selection = P_0.Selection
			};
			XDocument xDocument = AUidx3xcQW(P_0.WordOpenXml);
			a5lLcpd0tjOGP93a2IH2.StyleOutlineLevels = UPQrbSvBKH(xDocument);
			a5lLcpd0tjOGP93a2IH2.Comments = wpmrwTxSHp(xDocument);
			XElement xElement = (En9rt9aqSr(xDocument, "/word/document.xml") ?? throw new InvalidDataException("word/document.xml not found.")).Root?.Element(zA2ryEPNHO + "body");
			if (xElement != null)
			{
				foreach (XElement item in xElement.Elements())
				{
					if (item.Name == zA2ryEPNHO + "p")
					{
						tDfrL7gpkn(a5lLcpd0tjOGP93a2IH2, item);
					}
					else if (item.Name == zA2ryEPNHO + "tbl")
					{
						W5WrsPQn2V(a5lLcpd0tjOGP93a2IH2, item);
					}
				}
			}
			return a5lLcpd0tjOGP93a2IH2;
		}

		private static XDocument AUidx3xcQW(string P_0)
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

		public a5lLcpd0tjOGP93a2IH()
		{
			SseStreamInitializer.InitializeRuntime();
			JJXz6hPIUO = new List<ubtWXyzzVHfe9SR37mW>();
			JMJzuSFJ5k = new List<tABVE1VR66mkVrCsbLlX>();
			iE5zT2kBTY = new List<iltloQVRboLvh0PbMHDS>();
		}
	}

	private sealed class Y8ewNwzgQ3iuUtQ05mK
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

		public static Y8ewNwzgQ3iuUtQ05mK nPQz8YM8vZ(Application P_0)
		{
			try
			{
				Selection selection = P_0?.Selection;
				if (selection == null || selection.Range == null)
				{
					return null;
				}
				return new Y8ewNwzgQ3iuUtQ05mK
				{
					RangeStart = selection.Range.Start,
					RangeEnd = selection.Range.End,
					Text = W8DrGBw06b(selection.Range.Text)
				};
			}
			catch
			{
				return null;
			}
		}

		public Y8ewNwzgQ3iuUtQ05mK()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class IbFJ0vzQEvqcMM5hWZb
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
		private Y8ewNwzgQ3iuUtQ05mK _selection;

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

		public Y8ewNwzgQ3iuUtQ05mK Selection
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

		public IbFJ0vzQEvqcMM5hWZb()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class B4dteqz4khbXu1F8csG
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

		public B4dteqz4khbXu1F8csG()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class n0p396zwSZtGyZIAden
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
		private readonly List<YA2LiRzCEWFlxyIhtIs> JoZzGVV6N7;

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

		public List<YA2LiRzCEWFlxyIhtIs> Tables
		{
			[CompilerGenerated]
			get
			{
				return JoZzGVV6N7;
			}
		}

		public n0p396zwSZtGyZIAden()
		{
			SseStreamInitializer.InitializeRuntime();
			JoZzGVV6N7 = new List<YA2LiRzCEWFlxyIhtIs>();
		}
	}

	private sealed class YA2LiRzCEWFlxyIhtIs
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
		private readonly List<oTy5bPzeK1hVaoCKkSw> fpdzcWHnZP;

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

		public List<oTy5bPzeK1hVaoCKkSw> Cells
		{
			[CompilerGenerated]
			get
			{
				return fpdzcWHnZP;
			}
		}

		public YA2LiRzCEWFlxyIhtIs()
		{
			SseStreamInitializer.InitializeRuntime();
			fpdzcWHnZP = new List<oTy5bPzeK1hVaoCKkSw>();
		}
	}

	private sealed class oTy5bPzeK1hVaoCKkSw
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

		public oTy5bPzeK1hVaoCKkSw()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class mdqrdFzPxt9txWyKKJW
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

		public mdqrdFzPxt9txWyKKJW()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class bK7KpszWkypJdk2Xvox
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

		public bK7KpszWkypJdk2Xvox()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class ubtWXyzzVHfe9SR37mW
	{
		[CompilerGenerated]
		private int UmgVRROwaS3;

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
				return UmgVRROwaS3;
			}
			[CompilerGenerated]
			set
			{
				UmgVRROwaS3 = value;
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

		public ubtWXyzzVHfe9SR37mW()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class tABVE1VR66mkVrCsbLlX
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
		private readonly List<List<string>> K70VRH3a2fA;

		[CompilerGenerated]
		private readonly List<yYk52kVRJmeQHGAAHZBB> FptVRQWDyfr;

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
				return K70VRH3a2fA;
			}
		}

		public List<yYk52kVRJmeQHGAAHZBB> Cells
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

		public tABVE1VR66mkVrCsbLlX()
		{
			SseStreamInitializer.InitializeRuntime();
			K70VRH3a2fA = new List<List<string>>();
			FptVRQWDyfr = new List<yYk52kVRJmeQHGAAHZBB>();
		}
	}

	private sealed class yYk52kVRJmeQHGAAHZBB
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

		public yYk52kVRJmeQHGAAHZBB()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class wcRTakVRjwo5pepnDBig
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

		public wcRTakVRjwo5pepnDBig()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class iltloQVRboLvh0PbMHDS
	{
		[CompilerGenerated]
		private int _paragraphIndex;

		[CompilerGenerated]
		private ubtWXyzzVHfe9SR37mW sUhVRwXdsd1;

		[CompilerGenerated]
		private int _tableIndex;

		[CompilerGenerated]
		private int _firstParagraphIndex;

		[CompilerGenerated]
		private tABVE1VR66mkVrCsbLlX hIEVRsdBVC9;

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

		public ubtWXyzzVHfe9SR37mW Paragraph
		{
			[CompilerGenerated]
			get
			{
				return sUhVRwXdsd1;
			}
			[CompilerGenerated]
			set
			{
				sUhVRwXdsd1 = value;
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

		public tABVE1VR66mkVrCsbLlX Table
		{
			[CompilerGenerated]
			get
			{
				return hIEVRsdBVC9;
			}
			[CompilerGenerated]
			set
			{
				hIEVRsdBVC9 = value;
			}
		}

		public iltloQVRboLvh0PbMHDS()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class mEoL0hVRljv4wDAmJe79
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

		public mEoL0hVRljv4wDAmJe79()
		{
			SseStreamInitializer.InitializeRuntime();
		}
	}

	private sealed class MNdq0PVRGorZsHaxpvRr
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

		public MNdq0PVRGorZsHaxpvRr()
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

		internal AiHelper_5 PM7VVSQtQ67()
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
				B4dteqz4khbXu1F8csG b4dteqz4khbXu1F8csG = pDGVVLIgVmK.wkR1egPpPp(value, value);
				if (b4dteqz4khbXu1F8csG.Error != null)
				{
					return b4dteqz4khbXu1F8csG.Error;
				}
				int num = sFarm8rvtQ(value, 30000, 30000);
				return AiHelper_5.CreateSuccess("Word range read.", NR21kjpUWn(b4dteqz4khbXu1F8csG, num, 0));
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

		internal n0p396zwSZtGyZIAden NNoVVl2YqYm()
		{
			return jKPVVNnmOIw.Rta1F4FBcP(lbMVVmZlVvE, value, XrmVVGfRwYu);
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

		internal AiHelper_5 AiDVVC3g9xg(a5lLcpd0tjOGP93a2IH context)
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
				int num = sFarm8rvtQ(DRKVVnbyDrk, 20, 300);
				CS_8_locals_13.value = Math.Min(count, CS_8_locals_13.lEXVVebWsnI + num - 1);
			}
			CS_8_locals_13.bpvVVXkrWNt = sFarm8rvtQ(value, 1000, 5000);
			List<object> list = (from p in context.Paragraphs
				where p.ParagraphIndex >= CS_8_locals_13.lEXVVebWsnI && p.ParagraphIndex <= CS_8_locals_13.value
				select gEt1WsLuCr(p, CS_8_locals_13.bpvVVXkrWNt)).ToList();
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
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

		internal bool M8yVV5Soi31(ubtWXyzzVHfe9SR37mW p)
		{
			if (p.ParagraphIndex >= lEXVVebWsnI)
			{
				return p.ParagraphIndex <= value;
			}
			return false;
		}

		internal object bbNVVcg4IQ1(ubtWXyzzVHfe9SR37mW p)
		{
			return gEt1WsLuCr(p, bpvVVXkrWNt);
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

		internal AiHelper_5 BiyVVFiu6vu(a5lLcpd0tjOGP93a2IH context)
		{
			_G_c__DisplayClass13_1 CS_8_locals_5 = new _G_c__DisplayClass13_1();
			CS_8_locals_5.qIPVVvWNHDH = this;
			int num = sFarm8rvtQ(ImSVVhZDaAJ, 300, 1000);
			CS_8_locals_5.value = awRro3mnDA(wesVVaUCmVo);
			List<ubtWXyzzVHfe9SR37mW> list = (from p in context.Paragraphs
				where !string.IsNullOrWhiteSpace(p.Text)
				where (p.IsHeading && p.OutlineLevel <= CS_8_locals_5.value) || (!p.IsHeading & CS_8_locals_5.qIPVVvWNHDH.KEWVVqEbglr)
				select p).Take(num).ToList();
			int num2 = list.Count((ubtWXyzzVHfe9SR37mW p) => p.IsHeading);
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
			dictionary["maxOutlineLevel"] = CS_8_locals_5.value;
			dictionary["includeBodyText"] = KEWVVqEbglr;
			dictionary["headings"] = num2;
			dictionary["returned"] = list.Count;
			dictionary["truncated"] = list.Count >= num;
			dictionary["items"] = list.Select((ubtWXyzzVHfe9SR37mW p) => gEt1WsLuCr(p, 240)).ToList();
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

		internal bool KUsVVPRNqWH(ubtWXyzzVHfe9SR37mW p)
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

		internal AiHelper_5 wEjVVWmYVVM(a5lLcpd0tjOGP93a2IH context)
		{
			_G_c__DisplayClass14_1 CS_8_locals_10 = new _G_c__DisplayClass14_1();
			CS_8_locals_10.ubtWXyzzVHfe9SR37mW = q0ErEEV1r1(context, text, value, value, text);
			if (CS_8_locals_10.ubtWXyzzVHfe9SR37mW == null)
			{
				return AiHelper_5.CreateError("未找到匹配的标题段落。", "not_found");
			}
			if (!CS_8_locals_10.ubtWXyzzVHfe9SR37mW.IsHeading)
			{
				return AiHelper_5.CreateError("目标段落不是 Word 标题/大纲段落。", "invalid_arguments", new
				{
					headingParagraphIndex = CS_8_locals_10.ubtWXyzzVHfe9SR37mW.ParagraphIndex
				});
			}
			int num = context.Paragraphs.Count;
			foreach (ubtWXyzzVHfe9SR37mW item2 in context.Paragraphs.Where((ubtWXyzzVHfe9SR37mW p) => p.ParagraphIndex > CS_8_locals_10.ubtWXyzzVHfe9SR37mW.ParagraphIndex))
			{
				if (item2.IsHeading && item2.OutlineLevel <= CS_8_locals_10.ubtWXyzzVHfe9SR37mW.OutlineLevel)
				{
					num = item2.ParagraphIndex - 1;
					break;
				}
			}
			int num2 = sFarm8rvtQ(value, 1000, 5000);
			int num3 = sFarm8rvtQ(value, 80, 500);
			int num4 = sFarm8rvtQ(qxpVBVJeiBo, 20, 100);
			List<mEoL0hVRljv4wDAmJe79> list = new List<mEoL0hVRljv4wDAmJe79>();
			foreach (iltloQVRboLvh0PbMHDS block in context.Blocks)
			{
				if (block.ParagraphIndex > 0 && block.ParagraphIndex >= CS_8_locals_10.ubtWXyzzVHfe9SR37mW.ParagraphIndex && block.ParagraphIndex <= num)
				{
					ubtWXyzzVHfe9SR37mW paragraph = block.Paragraph;
					list.Add(new mEoL0hVRljv4wDAmJe79
					{
						Type = "paragraph",
						RangeStart = 0,
						Data = gEt1WsLuCr(paragraph, num2)
					});
				}
				else if (block.TableIndex > 0 && block.FirstParagraphIndex >= CS_8_locals_10.ubtWXyzzVHfe9SR37mW.ParagraphIndex && block.FirstParagraphIndex <= num)
				{
					list.Add(new mEoL0hVRljv4wDAmJe79
					{
						Type = "table",
						RangeStart = 0,
						Data = JDR1x5m387(context, block.Table, num3, num4)
					});
				}
			}
			int num5 = Math.Max(0, value);
			int num6 = sFarm8rvtQ(value, 200, 1000);
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
				mEoL0hVRljv4wDAmJe79 mEoL0hVRljv4wDAmJe80 = list[num8];
				var item = new
				{
					blockIndex = num8,
					type = mEoL0hVRljv4wDAmJe80.Type,
					rangeStart = mEoL0hVRljv4wDAmJe80.RangeStart,
					data = mEoL0hVRljv4wDAmJe80.Data
				};
				list2.Add(item);
				if (mEoL0hVRljv4wDAmJe80.Type == "paragraph")
				{
					list3.Add(mEoL0hVRljv4wDAmJe80.Data);
				}
				else if (mEoL0hVRljv4wDAmJe80.Type == "table")
				{
					list4.Add(mEoL0hVRljv4wDAmJe80.Data);
				}
			}
			bool flag = num7 < list.Count;
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
			dictionary["heading"] = gEt1WsLuCr(CS_8_locals_10.ubtWXyzzVHfe9SR37mW, 500);
			dictionary["startParagraphIndex"] = CS_8_locals_10.ubtWXyzzVHfe9SR37mW.ParagraphIndex;
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
		public ubtWXyzzVHfe9SR37mW ubtWXyzzVHfe9SR37mW;

		public Func<ubtWXyzzVHfe9SR37mW, bool> IlBVBDA2eWK;

		public _G_c__DisplayClass14_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool PLUVB6vLG9O(ubtWXyzzVHfe9SR37mW p)
		{
			return p.ParagraphIndex > ubtWXyzzVHfe9SR37mW.ParagraphIndex;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass15_0
	{
		public int TvKVBgUdUR8;

		public int value;

		public int value;

		public int value;

		public BatchReplaceService2 batchReplaceService2;

		public _G_c__DisplayClass15_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 y0CVBTqmF38(a5lLcpd0tjOGP93a2IH context)
		{
			_G_c__DisplayClass15_1 CS_8_locals_20 = new _G_c__DisplayClass15_1();
			CS_8_locals_20.a5lLcpd0tjOGP93a2IH = context;
			int count = CS_8_locals_20.a5lLcpd0tjOGP93a2IH.Tables.Count;
			if (count == 0)
			{
				Dictionary<string, object> dictionary = tvv1A6x1MO(CS_8_locals_20.a5lLcpd0tjOGP93a2IH);
				dictionary["totalTables"] = 0;
				dictionary["tables"] = new object[0];
				return AiHelper_5.CreateSuccess("No tables found.", dictionary);
			}
			CS_8_locals_20.NaoVBrVDusK = ((TvKVBgUdUR8 <= 0) ? 1 : TvKVBgUdUR8);
			CS_8_locals_20.value = ((TvKVBgUdUR8 > 0) ? TvKVBgUdUR8 : Math.Min(count, sFarm8rvtQ(value, 5, 100)));
			if (CS_8_locals_20.NaoVBrVDusK < 1 || CS_8_locals_20.NaoVBrVDusK > count)
			{
				return AiHelper_5.CreateError("tableIndex is out of range.", "invalid_arguments", new
				{
					totalTables = count
				});
			}
			CS_8_locals_20.value = sFarm8rvtQ(value, 80, 500);
			CS_8_locals_20.value = sFarm8rvtQ(value, 20, 100);
			CS_8_locals_20.xEiVBEoubwj = batchReplaceService2.hl01XRMNY4(CS_8_locals_20.NaoVBrVDusK, CS_8_locals_20.value);
			List<object> list = (from t in CS_8_locals_20.a5lLcpd0tjOGP93a2IH.Tables
				where t.TableIndex >= CS_8_locals_20.NaoVBrVDusK && t.TableIndex <= CS_8_locals_20.value
				select JDR1x5m387(CS_8_locals_20.a5lLcpd0tjOGP93a2IH, t, CS_8_locals_20.value, CS_8_locals_20.value, CS_8_locals_20.xEiVBEoubwj)).ToList();
			Dictionary<string, object> dictionary2 = tvv1A6x1MO(CS_8_locals_20.a5lLcpd0tjOGP93a2IH);
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

		public a5lLcpd0tjOGP93a2IH a5lLcpd0tjOGP93a2IH;

		public int value;

		public int value;

		public Dictionary<int, mdqrdFzPxt9txWyKKJW> xEiVBEoubwj;

		public _G_c__DisplayClass15_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool L2RVBQLsjmi(tABVE1VR66mkVrCsbLlX t)
		{
			if (t.TableIndex >= NaoVBrVDusK)
			{
				return t.TableIndex <= value;
			}
			return false;
		}

		internal object r7uVB1olUi3(tABVE1VR66mkVrCsbLlX t)
		{
			return JDR1x5m387(a5lLcpd0tjOGP93a2IH, t, value, value, xEiVBEoubwj);
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

		internal AiHelper_5 GlMVB2gA6b5(a5lLcpd0tjOGP93a2IH context)
		{
			int num = sFarm8rvtQ(value, 200, 1000);
			List<object> list = ((IEnumerable<object>)(from c in context.Comments.Take(num)
				select new
				{
					id = c.Id,
					author = c.Author,
					date = c.Date,
					commentText = c.Text
				})).ToList();
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
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

		public Func<ubtWXyzzVHfe9SR37mW, bool> rGWVBSA2rKn;

		public _G_c__DisplayClass17_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 XcMVBjiB3oV(a5lLcpd0tjOGP93a2IH context)
		{
			_G_c__DisplayClass17_1 CS_8_locals_10 = new _G_c__DisplayClass17_1();
			CS_8_locals_10._G_c__DisplayClass17_0 = this;
			CS_8_locals_10.a5lLcpd0tjOGP93a2IH = context;
			int num = sFarm8rvtQ(value, 50, 300);
			CS_8_locals_10.text = (uUNVBfrqteP ?? "contains").Trim().ToLowerInvariant();
			List<object> list = ((IEnumerable<object>)(from p in (from p in CS_8_locals_10.a5lLcpd0tjOGP93a2IH.Paragraphs
					where p.IsHeading
					where value <= 0 || p.OutlineLevel == value
					where hctr2dw2UI(p.Text, CS_8_locals_10._G_c__DisplayClass17_0.text, CS_8_locals_10.text)
					select p).Take(num)
				select new
				{
					document = CS_8_locals_10.a5lLcpd0tjOGP93a2IH.DocumentName,
					documentFullName = CS_8_locals_10.a5lLcpd0tjOGP93a2IH.DocumentFullName,
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
			Dictionary<string, object> dictionary = tvv1A6x1MO(CS_8_locals_10.a5lLcpd0tjOGP93a2IH);
			dictionary["outlineLevel"] = text ?? string.Empty;
			dictionary["matchMode"] = ((value <= 0) ? ((int?)null) : new int?(value));
			dictionary["returned"] = CS_8_locals_10.text;
			dictionary["truncated"] = list.Count;
			dictionary["matches"] = list.Count >= num;
			dictionary["Word heading find completed."] = list;
			return AiHelper_5.CreateSuccess("startParagraphIndex is out of range.", dictionary);
		}

		internal bool wEtVBYmYsX0(ubtWXyzzVHfe9SR37mW p)
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

		public a5lLcpd0tjOGP93a2IH a5lLcpd0tjOGP93a2IH;

		public _G_c__DisplayClass17_0 _G_c__DisplayClass17_0;

		public _G_c__DisplayClass17_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool hwTVBwxvJeS(ubtWXyzzVHfe9SR37mW p)
		{
			return hctr2dw2UI(p.Text, _G_c__DisplayClass17_0.text, text);
		}

		internal object jBpVBtGLAgp(ubtWXyzzVHfe9SR37mW p)
		{
			return new
			{
				document = a5lLcpd0tjOGP93a2IH.DocumentName,
				documentFullName = a5lLcpd0tjOGP93a2IH.DocumentFullName,
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

		internal AiHelper_5 HVhVBN7xdry(a5lLcpd0tjOGP93a2IH context)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return AiHelper_5.CreateError("text must not be empty.", "invalid_arguments");
			}
			int num = sFarm8rvtQ(value, 100, 500);
			StringComparison stringComparison = ((!flag) ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
			List<MNdq0PVRGorZsHaxpvRr> list = new List<MNdq0PVRGorZsHaxpvRr>();
			foreach (ubtWXyzzVHfe9SR37mW paragraph in context.Paragraphs)
			{
				if (list.Count >= num)
				{
					break;
				}
				moDrKNabHo(paragraph, text, stringComparison, flag, num, list);
			}
			return AiHelper_5.CreateSuccess("Word text find completed.", QLTrUfY8oq(context, list, num));
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

		internal AiHelper_5 LoZVBpQVJLi(a5lLcpd0tjOGP93a2IH context)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return AiHelper_5.CreateError("pattern must not be empty.", "invalid_arguments");
			}
			int num = sFarm8rvtQ(wjoVBnKCVJt, 100, 500);
			RegexOptions options = ((!flag) ? RegexOptions.IgnoreCase : RegexOptions.None);
			Regex regex = new Regex(text, options);
			List<MNdq0PVRGorZsHaxpvRr> list = new List<MNdq0PVRGorZsHaxpvRr>();
			foreach (ubtWXyzzVHfe9SR37mW paragraph in context.Paragraphs)
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
					list.Add(new MNdq0PVRGorZsHaxpvRr
					{
						ParagraphIndex = paragraph.ParagraphIndex,
						CharIndexStart = item.Index + 1,
						CharIndexEnd = item.Index + item.Length,
						MatchText = item.Value,
						Excerpt = HyErOENeqf(paragraph.Text ?? string.Empty, item.Index, item.Length)
					});
				}
			}
			return AiHelper_5.CreateSuccess("Word regex find completed.", QLTrUfY8oq(context, list, num));
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

		internal AiHelper_5 tJ3VB5iAHGV(a5lLcpd0tjOGP93a2IH context)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return AiHelper_5.CreateError("text must not be empty.", "invalid_arguments");
			}
			int num = sFarm8rvtQ(value, 100, 500);
			StringComparison comparisonType = ((!flag) ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
			List<object> list = new List<object>();
			foreach (tABVE1VR66mkVrCsbLlX table in context.Tables)
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
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
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

		internal string W4PVBXqVGBT()
		{
			return VSQVBPeQEih.Name;
		}

		internal string b3hVBFGETSn()
		{
			return VSQVBPeQEih.FullName;
		}

		internal string xPPVBhuH2U6()
		{
			return VSQVBPeQEih.Content.WordOpenXML;
		}

		internal bool KQxVBagcAWs()
		{
			return VSQVBPeQEih.Saved;
		}

		internal bool xW9VBqNUKun()
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

		internal B4dteqz4khbXu1F8csG WbwVBA8wuwO(Application app)
		{
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new B4dteqz4khbXu1F8csG
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			Document document = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = nNB1PSLKQE(document);
			if (insertResult != null)
			{
				return new B4dteqz4khbXu1F8csG
				{
					Error = insertResult
				};
			}
			object Start = value;
			object End = value;
			return bki1yLGJT9(document, document.Range(ref Start, ref End));
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

		internal string CfsVB0UhN9q()
		{
			return range.WordOpenXML;
		}

		internal string uDwVBk9UFWH()
		{
			return doc.Name;
		}

		internal string pt4VBx6fCs1()
		{
			return doc.FullName;
		}

		internal bool fBJVBdjhVAY()
		{
			return doc.Saved;
		}

		internal int V1QVBz0UUN1()
		{
			return range.Start;
		}

		internal int jaQV9RZ4A4m()
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

		internal Dictionary<int, mdqrdFzPxt9txWyKKJW> fIDV995FEUg(Application app)
		{
			Dictionary<int, mdqrdFzPxt9txWyKKJW> dictionary = new Dictionary<int, mdqrdFzPxt9txWyKKJW>();
			try
			{
				_G_c__DisplayClass27_1 CS_8_locals_4 = new _G_c__DisplayClass27_1();
				if (!string.IsNullOrWhiteSpace(WordAgentRuntimeGuard2.GetNotReadyMessage(app)))
				{
					return dictionary;
				}
				CS_8_locals_4.doc = DocumentLifecycleGuard.GetActiveDocument(app);
				if (nNB1PSLKQE(CS_8_locals_4.doc) != null)
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
						dictionary[num3] = new mdqrdFzPxt9txWyKKJW
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

		internal int EO4V9DHFRKt()
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

		internal n0p396zwSZtGyZIAden addV9gRTVDN(Application app)
		{
			_G_c__DisplayClass28_1 CS_8_locals_18 = new _G_c__DisplayClass28_1();
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new n0p396zwSZtGyZIAden
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			CS_8_locals_18.doc = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = nNB1PSLKQE(CS_8_locals_18.doc);
			if (insertResult != null)
			{
				return new n0p396zwSZtGyZIAden
				{
					Error = insertResult
				};
			}
			int start = CS_8_locals_18.doc.Content.Start;
			int end = CS_8_locals_18.doc.Content.End;
			if (value < start || value > end || value <= value)
			{
				return new n0p396zwSZtGyZIAden
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
			n0p396zwSZtGyZIAden n0p396zwSZtGyZIAden2 = new n0p396zwSZtGyZIAden
			{
				DocumentName = N75r5VKX8X(() => CS_8_locals_18.doc.Name),
				DocumentFullName = N75r5VKX8X(() => CS_8_locals_18.doc.FullName),
				DocumentSaved = PSHrcSln4y(() => CS_8_locals_18.doc.Saved, false),
				RangeStart = value,
				RangeEnd = value,
				TotalTablesInRange = VMbreGvrrq(() => CS_8_locals_18.range.Tables.Count, 0)
			};
			int num = Math.Min(n0p396zwSZtGyZIAden2.TotalTablesInRange, value);
			for (int num2 = 1; num2 <= num; num2++)
			{
				_G_c__DisplayClass28_2 CS_8_locals_21 = new _G_c__DisplayClass28_2();
				Table table = CS_8_locals_18.range.Tables[num2];
				CS_8_locals_21.range = table.Range;
				YA2LiRzCEWFlxyIhtIs yA2LiRzCEWFlxyIhtIs = new YA2LiRzCEWFlxyIhtIs
				{
					LocalTableIndex = num2,
					RangeStart = VMbreGvrrq(() => CS_8_locals_21.range.Start, 0),
					RangeEnd = VMbreGvrrq(() => CS_8_locals_21.range.End, 0),
					Page = CtirifWFy5(CS_8_locals_21.range),
					WordOpenXml = N75r5VKX8X(() => CS_8_locals_21.range.WordOpenXML)
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
							if (WX3rIraaAH(CS_8_locals_24.cell, out var rowIndex, out var columnIndex))
							{
								yA2LiRzCEWFlxyIhtIs.Cells.Add(new oTy5bPzeK1hVaoCKkSw
								{
									RowIndex = rowIndex,
									ColumnIndex = columnIndex,
									RangeStart = VMbreGvrrq(() => CS_8_locals_24.cell.Range.Start, 0),
									RangeEnd = VMbreGvrrq(() => CS_8_locals_24.cell.Range.End, 0),
									Page = CtirifWFy5(CS_8_locals_24.cell.Range),
									Text = W8DrGBw06b(N75r5VKX8X(() => CS_8_locals_24.cell.Range.Text))
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
				n0p396zwSZtGyZIAden2.Tables.Add(yA2LiRzCEWFlxyIhtIs);
			}
			return n0p396zwSZtGyZIAden2;
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

		internal string yyhV9H7epKm()
		{
			return doc.Name;
		}

		internal string bqnV9QLbqQy()
		{
			return doc.FullName;
		}

		internal bool LiXV91XjowG()
		{
			return doc.Saved;
		}

		internal int abwV9rWkkr6()
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

		internal int govV9UhvWUB()
		{
			return range.Start;
		}

		internal int zq0V9KgINTb()
		{
			return range.End;
		}

		internal string Xf0V9ENo6fy()
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

		internal int GRtV94jc0Fj()
		{
			return cell.Range.Start;
		}

		internal int tEpV9jWKYgx()
		{
			return cell.Range.End;
		}

		internal string aSsV9YNsPsN()
		{
			return cell.Range.Text;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass39_0
	{
		public YA2LiRzCEWFlxyIhtIs yA2LiRzCEWFlxyIhtIs;

		public tABVE1VR66mkVrCsbLlX tABVE1VR66mkVrCsbLlX;

		public _G_c__DisplayClass39_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal Dictionary<string, object> MMLV9fvVwyN(Dictionary<string, object> item)
		{
			return new Dictionary<string, object>
			{
				["cellId"] = t0Ar14Clfb(item, "cellId"),
				["localTableIndex"] = yA2LiRzCEWFlxyIhtIs.LocalTableIndex,
				["rowIndex"] = VUFrr6lVTF(item, "rowIndex"),
				["columnIndex"] = VUFrr6lVTF(item, "columnIndex"),
				["isHeader"] = zLtrJh4fJ9(item, "isHeader"),
				["requiresAllowHeaderEdit"] = false,
				["oldText"] = t0Ar14Clfb(item, "text"),
				["columnHeaderPath"] = item["columnHeaderPath"],
				["rowLabelPath"] = item["rowLabelPath"],
				["rowLeftContext"] = item["rowLeftContext"]
			};
		}

		internal object ikYV9MejFN9(bK7KpszWkypJdk2Xvox m)
		{
			return new
			{
				startRow = m.StartRow,
				startColumn = m.StartColumn,
				endRow = m.EndRow,
				endColumn = m.EndColumn,
				text = (QGOrDbp7Kg(tABVE1VR66mkVrCsbLlX, m.StartRow, m.StartColumn)?.Text ?? string.Empty)
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

		internal bool YpeV9wR7QwI(bK7KpszWkypJdk2Xvox merge)
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

		internal bool oLxV9L7bVxx(yYk52kVRJmeQHGAAHZBB cell)
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

		internal bool fSHV9NfX0hL(iltloQVRboLvh0PbMHDS b)
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
		public a5lLcpd0tjOGP93a2IH a5lLcpd0tjOGP93a2IH;

		public _G_c__DisplayClass58_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal object VtEV9ol06Zv(MNdq0PVRGorZsHaxpvRr match)
		{
			return new
			{
				actionableRange = false,
				document = a5lLcpd0tjOGP93a2IH.DocumentName,
				documentFullName = a5lLcpd0tjOGP93a2IH.DocumentFullName,
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

		internal bool jggV9CAgJ2L(ubtWXyzzVHfe9SR37mW p)
		{
			return p.ParagraphIndex == value;
		}

		internal bool Ok9V9poKaK2(ubtWXyzzVHfe9SR37mW p)
		{
			if (!p.IsHeading)
			{
				return false;
			}
			if (value > 0 && p.OutlineLevel != value)
			{
				return false;
			}
			return hctr2dw2UI(p.Text, text, text);
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

		internal bool Re3V9c1oqA6(XElement p)
		{
			return string.Equals(p.Attribute(noWrXsAkl3 + "name")?.Value, text, StringComparison.OrdinalIgnoreCase);
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

		internal AiHelper_5 nk1V9yNE9SC(a5lLcpd0tjOGP93a2IH context)
		{
			int num = sFarm8rvtQ(value, 240, 2000);
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
			dictionary["pageCount"] = null;
			dictionary["wordCount"] = null;
			dictionary["statisticsIncluded"] = false;
			dictionary["paragraphCount"] = context.Paragraphs.Count;
			dictionary["tableCount"] = context.Tables.Count;
			dictionary["commentCount"] = context.Comments.Count;
			dictionary["trackRevisions"] = context.TrackRevisions;
			dictionary["selection"] = G8H10y08aA(context.Selection, num);
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

		internal AiHelper_5 O6xV9FnlBGL(a5lLcpd0tjOGP93a2IH context)
		{
			_G_c__DisplayClass8_1 CS_8_locals_4 = new _G_c__DisplayClass8_1();
			int count = sFarm8rvtQ(value, 8, 50);
			int num = sFarm8rvtQ(value, 4, 50);
			int num2 = sFarm8rvtQ(value, 50, 300);
			CS_8_locals_4.value = sFarm8rvtQ(value, 180, 1000);
			int num3 = sFarm8rvtQ(value, 240, 2000);
			List<ubtWXyzzVHfe9SR37mW> list = context.Paragraphs.Where((ubtWXyzzVHfe9SR37mW p) => !string.IsNullOrWhiteSpace(p.Text)).ToList();
			List<object> list2 = (from p in list.Take(count)
				select gEt1WsLuCr(p, CS_8_locals_4.value)).ToList();
			List<object> list3 = (from p in list.Skip(Math.Max(0, list.Count - num))
				select gEt1WsLuCr(p, CS_8_locals_4.value)).ToList();
			List<object> list4 = (from p in context.Paragraphs.Where((ubtWXyzzVHfe9SR37mW p) => p.IsHeading && p.OutlineLevel == 1 && !string.IsNullOrWhiteSpace(p.Text)).Take(num2)
				select gEt1WsLuCr(p, CS_8_locals_4.value)).ToList();
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
			dictionary["paragraphCount"] = context.Paragraphs.Count;
			dictionary["tableCount"] = context.Tables.Count;
			dictionary["commentCount"] = context.Comments.Count;
			dictionary["trackRevisions"] = context.TrackRevisions;
			dictionary["selection"] = G8H10y08aA(context.Selection, num3);
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

		internal object avrV9vZaaBq(ubtWXyzzVHfe9SR37mW p)
		{
			return gEt1WsLuCr(p, value);
		}

		internal object TQ4V9WEImnO(ubtWXyzzVHfe9SR37mW p)
		{
			return gEt1WsLuCr(p, value);
		}

		internal object WZ5V905ivAc(ubtWXyzzVHfe9SR37mW p)
		{
			return gEt1WsLuCr(p, value);
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

		internal AiHelper_5 XcsV9xNq0th()
		{
			try
			{
				B4dteqz4khbXu1F8csG b4dteqz4khbXu1F8csG = batchReplaceService2.xum1cwwH8X();
				if (b4dteqz4khbXu1F8csG.Error != null)
				{
					return b4dteqz4khbXu1F8csG.Error;
				}
				int num = sFarm8rvtQ(value, 6000, 30000);
				return AiHelper_5.CreateSuccess("Word selection preview prepared.", NR21kjpUWn(b4dteqz4khbXu1F8csG, num, null));
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateExceptionError("preview_word_selection failed", "word_read_error", ex);
			}
		}
	}

	private static readonly XNamespace zA2ryEPNHO;

	private static readonly XNamespace noWrXsAkl3;

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
		return Edw1nKYtwj("get_current_word_context", delegate(a5lLcpd0tjOGP93a2IH context)
		{
			int num = sFarm8rvtQ(CS_8_locals_2.value, 240, 2000);
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
			dictionary["get_current_word_context"] = null;
			dictionary["preview_word_document"] = null;
			dictionary["preview_word_selection"] = false;
			dictionary["read_word_range"] = context.Paragraphs.Count;
			dictionary["rangeStart/rangeEnd 参数无效。"] = context.Tables.Count;
			dictionary["invalid_arguments"] = context.Comments.Count;
			dictionary["read_word_tables_in_range"] = context.TrackRevisions;
			dictionary["read_word_tables_in_range failed"] = G8H10y08aA(context.Selection, num);
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
		return Edw1nKYtwj("preview_word_document", delegate(a5lLcpd0tjOGP93a2IH context)
		{
			_G_c__DisplayClass8_1 CS_8_locals_15 = new _G_c__DisplayClass8_1();
			int count = sFarm8rvtQ(CS_8_locals_12.value, 8, 50);
			int num = sFarm8rvtQ(CS_8_locals_12.value, 4, 50);
			int num2 = sFarm8rvtQ(CS_8_locals_12.value, 50, 300);
			CS_8_locals_15.value = sFarm8rvtQ(CS_8_locals_12.value, 180, 1000);
			int num3 = sFarm8rvtQ(CS_8_locals_12.value, 240, 2000);
			List<ubtWXyzzVHfe9SR37mW> list = context.Paragraphs.Where((ubtWXyzzVHfe9SR37mW p) => !string.IsNullOrWhiteSpace(p.Text)).ToList();
			List<object> list2 = (from p in list.Take(count)
				select gEt1WsLuCr(p, CS_8_locals_15.value)).ToList();
			List<object> list3 = (from p in list.Skip(Math.Max(0, list.Count - num))
				select gEt1WsLuCr(p, CS_8_locals_15.value)).ToList();
			List<object> list4 = (from p in context.Paragraphs.Where((ubtWXyzzVHfe9SR37mW p) => p.IsHeading && p.OutlineLevel == 1 && !string.IsNullOrWhiteSpace(p.Text)).Take(num2)
				select gEt1WsLuCr(p, CS_8_locals_15.value)).ToList();
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
			dictionary["无法从该表格的 WordOpenXML 中解析表格结构。"] = context.Paragraphs.Count;
			dictionary["document"] = context.Tables.Count;
			dictionary["documentFullName"] = context.Comments.Count;
			dictionary["documentSaved"] = context.TrackRevisions;
			dictionary["rangeStart"] = G8H10y08aA(context.Selection, num3);
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
		return AiHelper_14.no9JOmnkBj("preview_word_selection", delegate
		{
			try
			{
				B4dteqz4khbXu1F8csG b4dteqz4khbXu1F8csG = CS_8_locals_4.batchReplaceService2.xum1cwwH8X();
				if (b4dteqz4khbXu1F8csG.Error != null)
				{
					return b4dteqz4khbXu1F8csG.Error;
				}
				int num = sFarm8rvtQ(CS_8_locals_4.value, 6000, 30000);
				return AiHelper_5.CreateSuccess("writeTool", NR21kjpUWn(b4dteqz4khbXu1F8csG, num, null));
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
		return AiHelper_14.no9JOmnkBj("read_word_range", delegate
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
				B4dteqz4khbXu1F8csG b4dteqz4khbXu1F8csG = CS_8_locals_13.pDGVVLIgVmK.wkR1egPpPp(CS_8_locals_13.value, CS_8_locals_13.value);
				if (b4dteqz4khbXu1F8csG.Error != null)
				{
					return b4dteqz4khbXu1F8csG.Error;
				}
				int num = sFarm8rvtQ(CS_8_locals_13.value, 30000, 30000);
				return AiHelper_5.CreateSuccess("tables", NR21kjpUWn(b4dteqz4khbXu1F8csG, num, 0));
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
		CS_8_locals_13.XrmVVGfRwYu = sFarm8rvtQ(P_2, 20, 100);
		int num = sFarm8rvtQ(P_3, 80, 500);
		int num2 = sFarm8rvtQ(P_4, 40, 120);
		n0p396zwSZtGyZIAden n0p396zwSZtGyZIAden2;
		try
		{
			n0p396zwSZtGyZIAden2 = AiHelper_14.no9JOmnkBj("read_word_tables_in_range", () => CS_8_locals_13.jKPVVNnmOIw.Rta1F4FBcP(CS_8_locals_13.lbMVVmZlVvE, CS_8_locals_13.value, CS_8_locals_13.XrmVVGfRwYu));
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateExceptionError("read_word_tables_in_range failed", "word_read_error", ex);
		}
		if (n0p396zwSZtGyZIAden2.Error != null)
		{
			return n0p396zwSZtGyZIAden2.Error;
		}
		try
		{
			List<object> list = new List<object>();
			foreach (YA2LiRzCEWFlxyIhtIs table in n0p396zwSZtGyZIAden2.Tables)
			{
				tABVE1VR66mkVrCsbLlX tABVE1VR66mkVrCsbLlX2 = rsf1dkOGI4(n0p396zwSZtGyZIAden2, table);
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
			dictionary["document"] = n0p396zwSZtGyZIAden2.DocumentName;
			dictionary["documentFullName"] = n0p396zwSZtGyZIAden2.DocumentFullName;
			dictionary["documentSaved"] = n0p396zwSZtGyZIAden2.DocumentSaved;
			dictionary["rangeStart"] = n0p396zwSZtGyZIAden2.RangeStart;
			dictionary["rangeEnd"] = n0p396zwSZtGyZIAden2.RangeEnd;
			dictionary["selectedTableCount"] = n0p396zwSZtGyZIAden2.TotalTablesInRange;
			dictionary["returnedTables"] = list.Count;
			dictionary["truncated"] = n0p396zwSZtGyZIAden2.TotalTablesInRange > list.Count;
			dictionary["coordinateSystem"] = "localTableIndex,rowIndex,columnIndex are 1-based within the referenced Word range.";
			dictionary["writeTool"] = "fill_word_table_cells_by_model";
			dictionary["structureEditTools"] = new string[2]
			{
				"insert_word_table_rows_by_model",
				"fill_word_table_cells_by_model"
			};
			dictionary["tables"] = list;
			Dictionary<string, object> dictionary2 = dictionary;
			return AiHelper_5.CreateSuccess((n0p396zwSZtGyZIAden2.TotalTablesInRange > 0) ? "No tables found in range." : "Word range tables read.", dictionary2);
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
		return Edw1nKYtwj("read_word_paragraphs", delegate(a5lLcpd0tjOGP93a2IH context)
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
				int num = sFarm8rvtQ(CS_8_locals_22.DRKVVnbyDrk, 20, 300);
				CS_8_locals_26.value = Math.Min(count, CS_8_locals_26.lEXVVebWsnI + num - 1);
			}
			CS_8_locals_26.bpvVVXkrWNt = sFarm8rvtQ(CS_8_locals_22.value, 1000, 5000);
			List<object> list = (from p in context.Paragraphs
				where p.ParagraphIndex >= CS_8_locals_26.lEXVVebWsnI && p.ParagraphIndex <= CS_8_locals_26.value
				select gEt1WsLuCr(p, CS_8_locals_26.bpvVVXkrWNt)).ToList();
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
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
		return Edw1nKYtwj("read_word_outline", delegate(a5lLcpd0tjOGP93a2IH context)
		{
			_G_c__DisplayClass13_1 CS_8_locals_13 = new _G_c__DisplayClass13_1();
			CS_8_locals_13.qIPVVvWNHDH = CS_8_locals_11;
			int num = sFarm8rvtQ(CS_8_locals_11.ImSVVhZDaAJ, 300, 1000);
			CS_8_locals_13.value = awRro3mnDA(CS_8_locals_11.wesVVaUCmVo);
			List<ubtWXyzzVHfe9SR37mW> list = (from p in context.Paragraphs
				where !string.IsNullOrWhiteSpace(p.Text)
				where (p.IsHeading && p.OutlineLevel <= CS_8_locals_13.value) || (!p.IsHeading & CS_8_locals_13.qIPVVvWNHDH.KEWVVqEbglr)
				select p).Take(num).ToList();
			int num2 = list.Count((ubtWXyzzVHfe9SR37mW p) => p.IsHeading);
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
			dictionary[" failed"] = CS_8_locals_13.value;
			dictionary["word_read_error"] = CS_8_locals_11.KEWVVqEbglr;
			dictionary["word_openxml_com"] = num2;
			dictionary["当前没有打开的 Word 文档。"] = list.Count;
			dictionary["no_document"] = list.Count >= num;
			dictionary["document"] = list.Select((ubtWXyzzVHfe9SR37mW p) => gEt1WsLuCr(p, 240)).ToList();
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
		return Edw1nKYtwj("read_word_section", delegate(a5lLcpd0tjOGP93a2IH context)
		{
			_G_c__DisplayClass14_1 CS_8_locals_29 = new _G_c__DisplayClass14_1();
			CS_8_locals_29.ubtWXyzzVHfe9SR37mW = q0ErEEV1r1(context, CS_8_locals_26.text, CS_8_locals_26.value, CS_8_locals_26.value, CS_8_locals_26.text);
			if (CS_8_locals_29.ubtWXyzzVHfe9SR37mW == null)
			{
				return AiHelper_5.CreateError("documentSaved", "document");
			}
			if (!CS_8_locals_29.ubtWXyzzVHfe9SR37mW.IsHeading)
			{
				return AiHelper_5.CreateError("documentFullName", "documentSaved", new
				{
					headingParagraphIndex = CS_8_locals_29.ubtWXyzzVHfe9SR37mW.ParagraphIndex
				});
			}
			int num = context.Paragraphs.Count;
			foreach (ubtWXyzzVHfe9SR37mW item2 in context.Paragraphs.Where((ubtWXyzzVHfe9SR37mW p) => p.ParagraphIndex > CS_8_locals_29.ubtWXyzzVHfe9SR37mW.ParagraphIndex))
			{
				if (item2.IsHeading && item2.OutlineLevel <= CS_8_locals_29.ubtWXyzzVHfe9SR37mW.OutlineLevel)
				{
					num = item2.ParagraphIndex - 1;
					break;
				}
			}
			int num2 = sFarm8rvtQ(CS_8_locals_26.value, 1000, 5000);
			int num3 = sFarm8rvtQ(CS_8_locals_26.value, 80, 500);
			int num4 = sFarm8rvtQ(CS_8_locals_26.qxpVBVJeiBo, 20, 100);
			List<mEoL0hVRljv4wDAmJe79> list = new List<mEoL0hVRljv4wDAmJe79>();
			foreach (iltloQVRboLvh0PbMHDS block in context.Blocks)
			{
				if (block.ParagraphIndex > 0 && block.ParagraphIndex >= CS_8_locals_29.ubtWXyzzVHfe9SR37mW.ParagraphIndex && block.ParagraphIndex <= num)
				{
					ubtWXyzzVHfe9SR37mW paragraph = block.Paragraph;
					list.Add(new mEoL0hVRljv4wDAmJe79
					{
						Type = "body",
						RangeStart = 0,
						Data = gEt1WsLuCr(paragraph, num2)
					});
				}
				else if (block.TableIndex > 0 && block.FirstParagraphIndex >= CS_8_locals_29.ubtWXyzzVHfe9SR37mW.ParagraphIndex && block.FirstParagraphIndex <= num)
				{
					list.Add(new mEoL0hVRljv4wDAmJe79
					{
						Type = "heading",
						RangeStart = 0,
						Data = JDR1x5m387(context, block.Table, num3, num4)
					});
				}
			}
			int num5 = Math.Max(0, CS_8_locals_26.value);
			int num6 = sFarm8rvtQ(CS_8_locals_26.value, 200, 1000);
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
				mEoL0hVRljv4wDAmJe79 mEoL0hVRljv4wDAmJe80 = list[num8];
				var item = new
				{
					blockIndex = num8,
					type = mEoL0hVRljv4wDAmJe80.Type,
					rangeStart = mEoL0hVRljv4wDAmJe80.RangeStart,
					data = mEoL0hVRljv4wDAmJe80.Data
				};
				list2.Add(item);
				if (mEoL0hVRljv4wDAmJe80.Type == "openxml_unavailable")
				{
					list3.Add(mEoL0hVRljv4wDAmJe80.Data);
				}
				else if (mEoL0hVRljv4wDAmJe80.Type == "document")
				{
					list4.Add(mEoL0hVRljv4wDAmJe80.Data);
				}
			}
			bool flag = num7 < list.Count;
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
			dictionary["documentFullName"] = gEt1WsLuCr(CS_8_locals_29.ubtWXyzzVHfe9SR37mW, 500);
			dictionary["documentSaved"] = CS_8_locals_29.ubtWXyzzVHfe9SR37mW.ParagraphIndex;
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
		CS_8_locals_24.TvKVBgUdUR8 = P_0;
		CS_8_locals_24.value = P_1;
		CS_8_locals_24.value = P_2;
		CS_8_locals_24.value = P_3;
		CS_8_locals_24.batchReplaceService2 = this;
		return Edw1nKYtwj("read_word_tables", delegate(a5lLcpd0tjOGP93a2IH context)
		{
			_G_c__DisplayClass15_1 CS_8_locals_34 = new _G_c__DisplayClass15_1();
			CS_8_locals_34.a5lLcpd0tjOGP93a2IH = context;
			int count = CS_8_locals_34.a5lLcpd0tjOGP93a2IH.Tables.Count;
			if (count == 0)
			{
				Dictionary<string, object> dictionary = tvv1A6x1MO(CS_8_locals_34.a5lLcpd0tjOGP93a2IH);
				dictionary["paragraphIndex"] = 0;
				dictionary["rangeStart"] = new object[0];
				return AiHelper_5.CreateSuccess("rangeEnd", dictionary);
			}
			CS_8_locals_34.NaoVBrVDusK = ((CS_8_locals_24.TvKVBgUdUR8 <= 0) ? 1 : CS_8_locals_24.TvKVBgUdUR8);
			CS_8_locals_34.value = ((CS_8_locals_24.TvKVBgUdUR8 > 0) ? CS_8_locals_24.TvKVBgUdUR8 : Math.Min(count, sFarm8rvtQ(CS_8_locals_24.value, 5, 100)));
			if (CS_8_locals_34.NaoVBrVDusK < 1 || CS_8_locals_34.NaoVBrVDusK > count)
			{
				return AiHelper_5.CreateError("actionableRange", "rangeSource", new
				{
					totalTables = count
				});
			}
			CS_8_locals_34.value = sFarm8rvtQ(CS_8_locals_24.value, 80, 500);
			CS_8_locals_34.value = sFarm8rvtQ(CS_8_locals_24.value, 20, 100);
			CS_8_locals_34.xEiVBEoubwj = CS_8_locals_24.batchReplaceService2.hl01XRMNY4(CS_8_locals_34.NaoVBrVDusK, CS_8_locals_34.value);
			List<object> list = (from t in CS_8_locals_34.a5lLcpd0tjOGP93a2IH.Tables
				where t.TableIndex >= CS_8_locals_34.NaoVBrVDusK && t.TableIndex <= CS_8_locals_34.value
				select JDR1x5m387(CS_8_locals_34.a5lLcpd0tjOGP93a2IH, t, CS_8_locals_34.value, CS_8_locals_34.value, CS_8_locals_34.xEiVBEoubwj)).ToList();
			Dictionary<string, object> dictionary2 = tvv1A6x1MO(CS_8_locals_34.a5lLcpd0tjOGP93a2IH);
			dictionary2["openxml_unavailable"] = count;
			dictionary2["word_com_table_range"] = list.Count;
			dictionary2["previousParagraph"] = list;
			return AiHelper_5.CreateSuccess("nextParagraph", dictionary2);
		});
	}

	public AiHelper_5 Eq21oOZC6p(int P_0)
	{
		_G_c__DisplayClass16_0 CS_8_locals_2 = new _G_c__DisplayClass16_0();
		CS_8_locals_2.value = P_0;
		return Edw1nKYtwj("read_word_comments", delegate(a5lLcpd0tjOGP93a2IH context)
		{
			int num = sFarm8rvtQ(CS_8_locals_2.value, 200, 1000);
			List<object> list = ((IEnumerable<object>)(from c in context.Comments.Take(num)
				select new
				{
					id = c.Id,
					author = c.Author,
					date = c.Date,
					commentText = c.Text
				})).ToList();
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
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
		return Edw1nKYtwj("find_word_heading", delegate(a5lLcpd0tjOGP93a2IH context)
		{
			_G_c__DisplayClass17_1 CS_8_locals_23 = new _G_c__DisplayClass17_1();
			CS_8_locals_23._G_c__DisplayClass17_0 = CS_8_locals_19;
			CS_8_locals_23.a5lLcpd0tjOGP93a2IH = context;
			int num = sFarm8rvtQ(CS_8_locals_19.value, 50, 300);
			CS_8_locals_23.text = (CS_8_locals_19.uUNVBfrqteP ?? "hasMergedOrUnavailableCells").Trim().ToLowerInvariant();
			List<object> list = ((IEnumerable<object>)(from p in (from p in CS_8_locals_23.a5lLcpd0tjOGP93a2IH.Paragraphs
					where p.IsHeading
					where CS_8_locals_19.value <= 0 || p.OutlineLevel == CS_8_locals_19.value
					where hctr2dw2UI(p.Text, CS_8_locals_23._G_c__DisplayClass17_0.text, CS_8_locals_23.text)
					select p).Take(num)
				select new
				{
					document = CS_8_locals_23.a5lLcpd0tjOGP93a2IH.DocumentName,
					documentFullName = CS_8_locals_23.a5lLcpd0tjOGP93a2IH.DocumentFullName,
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
			Dictionary<string, object> dictionary = tvv1A6x1MO(CS_8_locals_23.a5lLcpd0tjOGP93a2IH);
			dictionary["warnings"] = CS_8_locals_19.text ?? string.Empty;
			dictionary["localTableIndex"] = ((CS_8_locals_19.value <= 0) ? ((int?)null) : new int?(CS_8_locals_19.value));
			dictionary["rangeStart"] = CS_8_locals_23.text;
			dictionary["rangeEnd"] = list.Count;
			dictionary["page"] = list.Count >= num;
			dictionary["actionableRange"] = list;
			return AiHelper_5.CreateSuccess("rangeSource", dictionary);
		});
	}

	public AiHelper_5 vYa1CKwX1i(string P_0, bool P_1, bool P_2, int P_3)
	{
		_G_c__DisplayClass18_0 CS_8_locals_9 = new _G_c__DisplayClass18_0();
		CS_8_locals_9.text = P_0;
		CS_8_locals_9.value = P_3;
		CS_8_locals_9.flag = P_1;
		CS_8_locals_9.flag = P_2;
		return Edw1nKYtwj("find_word_text", delegate(a5lLcpd0tjOGP93a2IH context)
		{
			if (string.IsNullOrWhiteSpace(CS_8_locals_9.text))
			{
				return AiHelper_5.CreateError("word_com_selection_table_range", "rows");
			}
			int num = sFarm8rvtQ(CS_8_locals_9.value, 100, 500);
			StringComparison stringComparison = ((!CS_8_locals_9.flag) ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
			List<MNdq0PVRGorZsHaxpvRr> list = new List<MNdq0PVRGorZsHaxpvRr>();
			foreach (ubtWXyzzVHfe9SR37mW paragraph in context.Paragraphs)
			{
				if (list.Count >= num)
				{
					break;
				}
				moDrKNabHo(paragraph, CS_8_locals_9.text, stringComparison, CS_8_locals_9.flag, num, list);
			}
			return AiHelper_5.CreateSuccess("columns", QLTrUfY8oq(context, list, num));
		});
	}

	public AiHelper_5 FindRegex(string P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass19_0 CS_8_locals_7 = new _G_c__DisplayClass19_0();
		CS_8_locals_7.text = P_0;
		CS_8_locals_7.wjoVBnKCVJt = P_2;
		CS_8_locals_7.flag = P_1;
		return Edw1nKYtwj("find_word_regex", delegate(a5lLcpd0tjOGP93a2IH context)
		{
			if (string.IsNullOrWhiteSpace(CS_8_locals_7.text))
			{
				return AiHelper_5.CreateError("returnedRows", "returnedColumns");
			}
			int num = sFarm8rvtQ(CS_8_locals_7.wjoVBnKCVJt, 100, 500);
			RegexOptions options = ((!CS_8_locals_7.flag) ? RegexOptions.IgnoreCase : RegexOptions.None);
			Regex regex = new Regex(CS_8_locals_7.text, options);
			List<MNdq0PVRGorZsHaxpvRr> list = new List<MNdq0PVRGorZsHaxpvRr>();
			foreach (ubtWXyzzVHfe9SR37mW paragraph in context.Paragraphs)
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
					list.Add(new MNdq0PVRGorZsHaxpvRr
					{
						ParagraphIndex = paragraph.ParagraphIndex,
						CharIndexStart = item.Index + 1,
						CharIndexEnd = item.Index + item.Length,
						MatchText = item.Value,
						Excerpt = HyErOENeqf(paragraph.Text ?? string.Empty, item.Index, item.Length)
					});
				}
			}
			return AiHelper_5.CreateSuccess("headerRowCount", QLTrUfY8oq(context, list, num));
		});
	}

	public AiHelper_5 oOq1O59cQ7(string P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass20_0 CS_8_locals_9 = new _G_c__DisplayClass20_0();
		CS_8_locals_9.text = P_0;
		CS_8_locals_9.value = P_2;
		CS_8_locals_9.flag = P_1;
		return Edw1nKYtwj("find_word_table_text", delegate(a5lLcpd0tjOGP93a2IH context)
		{
			if (string.IsNullOrWhiteSpace(CS_8_locals_9.text))
			{
				return AiHelper_5.CreateError("rowsData", "cellsFlat");
			}
			int num = sFarm8rvtQ(CS_8_locals_9.value, 100, 500);
			StringComparison comparisonType = ((!CS_8_locals_9.flag) ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
			List<object> list = new List<object>();
			foreach (tABVE1VR66mkVrCsbLlX table in context.Tables)
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
			Dictionary<string, object> dictionary = tvv1A6x1MO(context);
			dictionary["fillableCells"] = false;
			dictionary["mergedCells"] = "markdown";
			dictionary["rawText"] = list.Count;
			dictionary["hasMergedOrUnavailableCells"] = list.Count >= num;
			dictionary["expandedMergedCells"] = list;
			return AiHelper_5.CreateSuccess("truncated", dictionary);
		});
	}

	private AiHelper_5 Edw1nKYtwj(string P_0, Func<a5lLcpd0tjOGP93a2IH, AiHelper_5> P_1)
	{
		try
		{
			a5lLcpd0tjOGP93a2IH a5lLcpd0tjOGP93a2IH2 = bob17xbVok();
			if (a5lLcpd0tjOGP93a2IH2 != null)
			{
				return P_1(a5lLcpd0tjOGP93a2IH2);
			}
			IbFJ0vzQEvqcMM5hWZb ibFJ0vzQEvqcMM5hWZb = JhP15OCSFR();
			if (ibFJ0vzQEvqcMM5hWZb.Error != null)
			{
				return ibFJ0vzQEvqcMM5hWZb.Error;
			}
			a5lLcpd0tjOGP93a2IH a5lLcpd0tjOGP93a2IH3 = a5lLcpd0tjOGP93a2IH.hhudkjcOIs(ibFJ0vzQEvqcMM5hWZb);
			DocumentLifecycleGuard.SetCachedProperty(ibFJ0vzQEvqcMM5hWZb.DocumentKey, a5lLcpd0tjOGP93a2IH3);
			return P_1(a5lLcpd0tjOGP93a2IH3);
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateExceptionError(P_0 + " failed", "word_read_error", ex);
		}
	}

	private a5lLcpd0tjOGP93a2IH bob17xbVok()
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
		return DocumentLifecycleGuard.GetCachedProperty(IYo1q1aGqt(current.DocumentName, current.DocumentFullName)) as a5lLcpd0tjOGP93a2IH;
	}

	private IbFJ0vzQEvqcMM5hWZb JhP15OCSFR()
	{
		return GV11hMNVs2(delegate(Application app)
		{
			_G_c__DisplayClass23_0 CS_8_locals_7 = new _G_c__DisplayClass23_0();
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new IbFJ0vzQEvqcMM5hWZb
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			CS_8_locals_7.VSQVBPeQEih = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = nNB1PSLKQE(CS_8_locals_7.VSQVBPeQEih);
			if (insertResult != null)
			{
				return new IbFJ0vzQEvqcMM5hWZb
				{
					Error = insertResult
				};
			}
			string text2 = N75r5VKX8X(() => CS_8_locals_7.VSQVBPeQEih.Name);
			string text3 = N75r5VKX8X(() => CS_8_locals_7.VSQVBPeQEih.FullName);
			string text4 = N75r5VKX8X(() => CS_8_locals_7.VSQVBPeQEih.Content.WordOpenXML);
			if (string.IsNullOrWhiteSpace(text4))
			{
				throw new InvalidDataException("writeCoordinateExample");
			}
			return new IbFJ0vzQEvqcMM5hWZb
			{
				DocumentName = text2,
				DocumentFullName = text3,
				DocumentKey = IYo1q1aGqt(text2, text3),
				DocumentSaved = PSHrcSln4y(() => CS_8_locals_7.VSQVBPeQEih.Saved, false),
				TrackRevisions = PSHrcSln4y(() => CS_8_locals_7.VSQVBPeQEih.TrackRevisions, false),
				Selection = Y8ewNwzgQ3iuUtQ05mK.nPQz8YM8vZ(app),
				WordOpenXml = text4
			};
		});
	}

	private B4dteqz4khbXu1F8csG xum1cwwH8X()
	{
		return GV11hMNVs2(delegate(Application app)
		{
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new B4dteqz4khbXu1F8csG
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			Document document = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = nNB1PSLKQE(document);
			if (insertResult != null)
			{
				return new B4dteqz4khbXu1F8csG
				{
					Error = insertResult
				};
			}
			Selection selection = app?.Selection;
			return (selection == null || selection.Range == null) ? new B4dteqz4khbXu1F8csG
			{
				Error = AiHelper_5.CreateError("1-based rowIndex from cellsFlat/fillableCells", "1-based columnIndex from cellsFlat/fillableCells")
			} : bki1yLGJT9(document, selection.Range);
		});
	}

	private B4dteqz4khbXu1F8csG wkR1egPpPp(int P_0, int P_1)
	{
		_G_c__DisplayClass25_0 CS_8_locals_4 = new _G_c__DisplayClass25_0();
		CS_8_locals_4.value = P_0;
		CS_8_locals_4.value = P_1;
		return GV11hMNVs2(delegate(Application app)
		{
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new B4dteqz4khbXu1F8csG
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			Document document = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = nNB1PSLKQE(document);
			if (insertResult != null)
			{
				return new B4dteqz4khbXu1F8csG
				{
					Error = insertResult
				};
			}
			object Start = CS_8_locals_4.value;
			object End = CS_8_locals_4.value;
			return bki1yLGJT9(document, document.Range(ref Start, ref End));
		});
	}

	private static B4dteqz4khbXu1F8csG bki1yLGJT9(Document P_0, Range P_1)
	{
		_G_c__DisplayClass26_0 CS_8_locals_8 = new _G_c__DisplayClass26_0();
		CS_8_locals_8.range = P_1;
		CS_8_locals_8.doc = P_0;
		string wordOpenXml = N75r5VKX8X(() => CS_8_locals_8.range.WordOpenXML);
		return new B4dteqz4khbXu1F8csG
		{
			DocumentName = N75r5VKX8X(() => CS_8_locals_8.doc.Name),
			DocumentFullName = N75r5VKX8X(() => CS_8_locals_8.doc.FullName),
			DocumentSaved = PSHrcSln4y(() => CS_8_locals_8.doc.Saved, false),
			RangeStart = VMbreGvrrq(() => CS_8_locals_8.range.Start, 0),
			RangeEnd = VMbreGvrrq(() => CS_8_locals_8.range.End, 0),
			WordOpenXml = wordOpenXml
		};
	}

	private Dictionary<int, mdqrdFzPxt9txWyKKJW> hl01XRMNY4(int P_0, int P_1)
	{
		_G_c__DisplayClass27_0 CS_8_locals_7 = new _G_c__DisplayClass27_0();
		CS_8_locals_7.value = P_0;
		CS_8_locals_7.value = P_1;
		return GV11hMNVs2(delegate(Application app)
		{
			Dictionary<int, mdqrdFzPxt9txWyKKJW> dictionary = new Dictionary<int, mdqrdFzPxt9txWyKKJW>();
			try
			{
				_G_c__DisplayClass27_1 CS_8_locals_9 = new _G_c__DisplayClass27_1();
				if (!string.IsNullOrWhiteSpace(WordAgentRuntimeGuard2.GetNotReadyMessage(app)))
				{
					return dictionary;
				}
				CS_8_locals_9.doc = DocumentLifecycleGuard.GetActiveDocument(app);
				if (nNB1PSLKQE(CS_8_locals_9.doc) != null)
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
						dictionary[num3] = new mdqrdFzPxt9txWyKKJW
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

	private n0p396zwSZtGyZIAden Rta1F4FBcP(int P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass28_0 CS_8_locals_21 = new _G_c__DisplayClass28_0();
		CS_8_locals_21.value = P_0;
		CS_8_locals_21.value = P_1;
		CS_8_locals_21.value = P_2;
		return GV11hMNVs2(delegate(Application app)
		{
			_G_c__DisplayClass28_1 CS_8_locals_33 = new _G_c__DisplayClass28_1();
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new n0p396zwSZtGyZIAden
				{
					Error = WordAgentRuntimeGuard2.CreateNotReadyError(text)
				};
			}
			CS_8_locals_33.doc = DocumentLifecycleGuard.GetActiveDocument(app);
			AiHelper_5 insertResult = nNB1PSLKQE(CS_8_locals_33.doc);
			if (insertResult != null)
			{
				return new n0p396zwSZtGyZIAden
				{
					Error = insertResult
				};
			}
			int start = CS_8_locals_33.doc.Content.Start;
			int end = CS_8_locals_33.doc.Content.End;
			if (CS_8_locals_21.value < start || CS_8_locals_21.value > end || CS_8_locals_21.value <= CS_8_locals_21.value)
			{
				return new n0p396zwSZtGyZIAden
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
			n0p396zwSZtGyZIAden n0p396zwSZtGyZIAden2 = new n0p396zwSZtGyZIAden
			{
				DocumentName = N75r5VKX8X(() => CS_8_locals_33.doc.Name),
				DocumentFullName = N75r5VKX8X(() => CS_8_locals_33.doc.FullName),
				DocumentSaved = PSHrcSln4y(() => CS_8_locals_33.doc.Saved, false),
				RangeStart = CS_8_locals_21.value,
				RangeEnd = CS_8_locals_21.value,
				TotalTablesInRange = VMbreGvrrq(() => CS_8_locals_33.range.Tables.Count, 0)
			};
			int num = Math.Min(n0p396zwSZtGyZIAden2.TotalTablesInRange, CS_8_locals_21.value);
			for (int num2 = 1; num2 <= num; num2++)
			{
				_G_c__DisplayClass28_2 CS_8_locals_36 = new _G_c__DisplayClass28_2();
				Table table = CS_8_locals_33.range.Tables[num2];
				CS_8_locals_36.range = table.Range;
				YA2LiRzCEWFlxyIhtIs yA2LiRzCEWFlxyIhtIs = new YA2LiRzCEWFlxyIhtIs
				{
					LocalTableIndex = num2,
					RangeStart = VMbreGvrrq(() => CS_8_locals_36.range.Start, 0),
					RangeEnd = VMbreGvrrq(() => CS_8_locals_36.range.End, 0),
					Page = CtirifWFy5(CS_8_locals_36.range),
					WordOpenXml = N75r5VKX8X(() => CS_8_locals_36.range.WordOpenXML)
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
							if (WX3rIraaAH(CS_8_locals_39.cell, out var rowIndex, out var columnIndex))
							{
								yA2LiRzCEWFlxyIhtIs.Cells.Add(new oTy5bPzeK1hVaoCKkSw
								{
									RowIndex = rowIndex,
									ColumnIndex = columnIndex,
									RangeStart = VMbreGvrrq(() => CS_8_locals_39.cell.Range.Start, 0),
									RangeEnd = VMbreGvrrq(() => CS_8_locals_39.cell.Range.End, 0),
									Page = CtirifWFy5(CS_8_locals_39.cell.Range),
									Text = W8DrGBw06b(N75r5VKX8X(() => CS_8_locals_39.cell.Range.Text))
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
				n0p396zwSZtGyZIAden2.Tables.Add(yA2LiRzCEWFlxyIhtIs);
			}
			return n0p396zwSZtGyZIAden2;
		});
	}

	private bofQyd1aG8OooLE9BF3 GV11hMNVs2<bofQyd1aG8OooLE9BF3>(Func<Application, bofQyd1aG8OooLE9BF3> P_0)
	{
		return _wordTableToolService4.MdXJlVhPku("warnings", P_0);
	}

	private static string IYo1q1aGqt(string P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return (P_0 ?? string.Empty).Trim();
		}
		return P_1.Trim();
	}

	private static AiHelper_5 nNB1PSLKQE(Document P_0)
	{
		if (P_0 == null)
		{
			return AiHelper_5.CreateError("当前没有打开的 Word 文档。", "no_document");
		}
		return null;
	}

	private static Dictionary<string, object> tvv1A6x1MO(a5lLcpd0tjOGP93a2IH P_0)
	{
		return new Dictionary<string, object>
		{
			["document"] = P_0.DocumentName,
			["documentFullName"] = P_0.DocumentFullName,
			["documentSaved"] = P_0.DocumentSaved
		};
	}

	private static Dictionary<string, object> E0o1v57WVB(tABVE1VR66mkVrCsbLlX P_0)
	{
		return new Dictionary<string, object>
		{
			["document"] = P_0.DocumentName,
			["documentFullName"] = P_0.DocumentFullName,
			["documentSaved"] = P_0.DocumentSaved
		};
	}

	private static object gEt1WsLuCr(ubtWXyzzVHfe9SR37mW P_0, int P_1)
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

	private static object G8H10y08aA(Y8ewNwzgQ3iuUtQ05mK P_0, int P_1)
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

	private static Dictionary<string, object> NR21kjpUWn(B4dteqz4khbXu1F8csG P_0, int P_1, int? P_2)
	{
		string text = cMcrfW1gSG(P_0.WordOpenXml);
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

	private static object JDR1x5m387(a5lLcpd0tjOGP93a2IH P_0, tABVE1VR66mkVrCsbLlX P_1, int P_2, int P_3, Dictionary<int, mdqrdFzPxt9txWyKKJW> P_4 = null)
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
		mdqrdFzPxt9txWyKKJW value = null;
		bool flag = P_4 != null && P_4.TryGetValue(P_1.TableIndex, out value) && value != null && value.RangeEnd >= value.RangeStart;
		Dictionary<string, object> dictionary = E0o1v57WVB(P_1);
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
		dictionary["previousParagraph"] = DHAr3WoUQu(P_0, P_1.TableIndex, -1);
		dictionary["nextParagraph"] = DHAr3WoUQu(P_0, P_1.TableIndex, 1);
		dictionary["truncated"] = P_1.Matrix.Count > num || (P_1.Matrix.Count > 0 && P_1.Matrix.Max((List<string> r) => r.Count) > num2);
		dictionary["rowsData"] = OdFr4eHT3G(list);
		dictionary["cellsFlat"] = ((IEnumerable<object>)P_1.Cells.Select((yYk52kVRJmeQHGAAHZBB c) => new
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
		dictionary["rawText"] = irdrjYZm1n(list);
		dictionary["hasMergedOrUnavailableCells"] = cmxrpX5s5e(P_1.RawText, 3000);
		dictionary["expandedMergedCells"] = P_1.HasMergedCells;
		dictionary["warnings"] = P_1.HasMergedCells;
		dictionary["未能读取该表格的真实 Word COM 单元格坐标，写入工具可能无法定位。"] = new string[0];
		return dictionary;
	}

	private static tABVE1VR66mkVrCsbLlX rsf1dkOGI4(n0p396zwSZtGyZIAden P_0, YA2LiRzCEWFlxyIhtIs P_1)
	{
		if (P_0 == null || P_1 == null || string.IsNullOrWhiteSpace(P_1.WordOpenXml))
		{
			return null;
		}
		using a5lLcpd0tjOGP93a2IH a5lLcpd0tjOGP93a2IH2 = a5lLcpd0tjOGP93a2IH.hhudkjcOIs(new IbFJ0vzQEvqcMM5hWZb
		{
			DocumentName = P_0.DocumentName,
			DocumentFullName = P_0.DocumentFullName,
			DocumentSaved = P_0.DocumentSaved,
			TrackRevisions = false,
			WordOpenXml = P_1.WordOpenXml
		});
		tABVE1VR66mkVrCsbLlX tABVE1VR66mkVrCsbLlX2 = a5lLcpd0tjOGP93a2IH2.Tables.FirstOrDefault();
		if (tABVE1VR66mkVrCsbLlX2 == null)
		{
			return null;
		}
		tABVE1VR66mkVrCsbLlX2.TableIndex = P_1.LocalTableIndex;
		return tABVE1VR66mkVrCsbLlX2;
	}

	private static object i041zjkxm7(tABVE1VR66mkVrCsbLlX P_0, YA2LiRzCEWFlxyIhtIs P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass39_0 CS_8_locals_25 = new _G_c__DisplayClass39_0();
		CS_8_locals_25.yA2LiRzCEWFlxyIhtIs = P_1;
		CS_8_locals_25.tABVE1VR66mkVrCsbLlX = P_0;
		int count = CS_8_locals_25.tABVE1VR66mkVrCsbLlX.Matrix.Count;
		int num = ((CS_8_locals_25.tABVE1VR66mkVrCsbLlX.Matrix.Count != 0) ? CS_8_locals_25.tABVE1VR66mkVrCsbLlX.Matrix.Max((List<string> r) => r.Count) : 0);
		int num2 = Math.Min(count, P_2);
		int num3 = Math.Min(num, P_3);
		List<List<string>> list = new List<List<string>>();
		for (int num4 = 0; num4 < num2; num4++)
		{
			List<string> list2 = new List<string>();
			for (int num5 = 0; num5 < num3; num5++)
			{
				list2.Add((num5 < CS_8_locals_25.tABVE1VR66mkVrCsbLlX.Matrix[num4].Count) ? CS_8_locals_25.tABVE1VR66mkVrCsbLlX.Matrix[num4][num5] : string.Empty);
			}
			list.Add(list2);
		}
		List<bK7KpszWkypJdk2Xvox> list3 = nlxrVudBFD(CS_8_locals_25.tABVE1VR66mkVrCsbLlX);
		int num6 = NeBrBnQFG6(CS_8_locals_25.tABVE1VR66mkVrCsbLlX, list3);
		Dictionary<string, oTy5bPzeK1hVaoCKkSw> dictionary = Hv3rTBRVQS(CS_8_locals_25.yA2LiRzCEWFlxyIhtIs);
		List<Dictionary<string, object>> list4 = vSgrRZ2rop(CS_8_locals_25.tABVE1VR66mkVrCsbLlX, CS_8_locals_25.yA2LiRzCEWFlxyIhtIs.LocalTableIndex, num6, num2, num3, dictionary);
		List<object> value = ((IEnumerable<object>)(from item in list4
			where string.Equals(t0Ar14Clfb(item, "localTableIndex"), "rangeStart", StringComparison.Ordinal) && zLtrJh4fJ9(item, "rangeEnd")
			select new Dictionary<string, object>
			{
				["page"] = t0Ar14Clfb(item, "actionableRange"),
				["rangeSource"] = CS_8_locals_25.yA2LiRzCEWFlxyIhtIs.LocalTableIndex,
				["word_com_selection_table_range"] = VUFrr6lVTF(item, "rows"),
				["columns"] = VUFrr6lVTF(item, "returnedRows"),
				["returnedColumns"] = zLtrJh4fJ9(item, "headerRowCount"),
				["rowsData"] = false,
				["cellsFlat"] = t0Ar14Clfb(item, "fillableCells"),
				["mergedCells"] = item["markdown"],
				["rawText"] = item["hasMergedOrUnavailableCells"],
				["expandedMergedCells"] = item["truncated"]
			})).ToList();
		Dictionary<string, object> dictionary2 = E0o1v57WVB(CS_8_locals_25.tABVE1VR66mkVrCsbLlX);
		dictionary2["writeCoordinateExample"] = CS_8_locals_25.yA2LiRzCEWFlxyIhtIs.LocalTableIndex;
		dictionary2["1-based rowIndex from cellsFlat/fillableCells"] = CS_8_locals_25.yA2LiRzCEWFlxyIhtIs.RangeStart;
		dictionary2["1-based columnIndex from cellsFlat/fillableCells"] = CS_8_locals_25.yA2LiRzCEWFlxyIhtIs.RangeEnd;
		dictionary2["oldText from fillableCells"] = CS_8_locals_25.yA2LiRzCEWFlxyIhtIs.Page;
		dictionary2["new cell text"] = CS_8_locals_25.yA2LiRzCEWFlxyIhtIs.RangeEnd >= CS_8_locals_25.yA2LiRzCEWFlxyIhtIs.RangeStart;
		dictionary2["warnings"] = "未能读取该表格的真实 Word COM 单元格坐标，写入工具可能无法定位。";
		dictionary2["cellId"] = count;
		dictionary2["cellKind"] = num;
		dictionary2["origin"] = num2;
		dictionary2["localTableIndex"] = num3;
		dictionary2["rowIndex"] = num6;
		dictionary2["columnIndex"] = OdFr4eHT3G(list);
		dictionary2["rowSpan"] = list4;
		dictionary2["columnSpan"] = value;
		dictionary2["isHeader"] = ((IEnumerable<object>)list3.Select((bK7KpszWkypJdk2Xvox m) => new
		{
			startRow = m.StartRow,
			startColumn = m.StartColumn,
			endRow = m.EndRow,
			endColumn = m.EndColumn,
			text = (QGOrDbp7Kg(CS_8_locals_25.tABVE1VR66mkVrCsbLlX, m.StartRow, m.StartColumn)?.Text ?? string.Empty)
		})).ToList();
		dictionary2["requiresAllowHeaderEdit"] = irdrjYZm1n(list);
		dictionary2["defaultWritable"] = cmxrpX5s5e(CS_8_locals_25.tABVE1VR66mkVrCsbLlX.RawText, 3000);
		dictionary2["page"] = CS_8_locals_25.tABVE1VR66mkVrCsbLlX.HasMergedCells;
		dictionary2["rangeStart"] = CS_8_locals_25.tABVE1VR66mkVrCsbLlX.HasMergedCells;
		dictionary2["rangeEnd"] = count > num2 || num > num3;
		dictionary2["actionableRange"] = new
		{
			localTableIndex = CS_8_locals_25.yA2LiRzCEWFlxyIhtIs.LocalTableIndex,
			rowIndex = "rangeSource",
			columnIndex = "unavailable",
			expectedOldText = "word_com_table_cell",
			text = "text"
		};
		dictionary2["columnHeaderPath"] = ((dictionary.Count != 0) ? new string[0] : new string[1] { "rowLabelPath" });
		return dictionary2;
	}

	private static List<Dictionary<string, object>> vSgrRZ2rop(tABVE1VR66mkVrCsbLlX P_0, int P_1, int P_2, int P_3, int P_4, Dictionary<string, oTy5bPzeK1hVaoCKkSw> P_5)
	{
		List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
		foreach (yYk52kVRJmeQHGAAHZBB item in from c in P_0.Cells
			orderby c.RowIndex, c.ColumnIndex
			select c)
		{
			if (item.RowIndex <= P_3 && item.ColumnIndex <= P_4)
			{
				oTy5bPzeK1hVaoCKkSw value;
				bool flag = P_5.TryGetValue(gUCrg3NX3q(item.RowIndex, item.ColumnIndex), out value);
				bool flag2 = item.RowIndex <= P_2;
				string value2 = sLjr8FSBCP(P_1, item.RowIndex, item.ColumnIndex);
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
					["columnHeaderPath"] = IbZr9IJvMH(P_0, item.RowIndex, item.ColumnIndex, P_2),
					["rowLabelPath"] = xStr6rQtES(P_0, item.RowIndex, item.ColumnIndex, P_2),
					["rowLeftContext"] = A87ru4tsrK(P_0, item.RowIndex, item.ColumnIndex, P_2),
					["writeCoordinate"] = (flag ? new
					{
						localTableIndex = P_1,
						rowIndex = item.RowIndex,
						columnIndex = item.ColumnIndex
					} : null)
				});
			}
		}
		foreach (yYk52kVRJmeQHGAAHZBB item2 in from c in P_0.Cells
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
							["cellId"] = sLjr8FSBCP(P_1, num, num2),
							["cellKind"] = "mergedInterior",
							["localTableIndex"] = P_1,
							["rowIndex"] = num,
							["columnIndex"] = num2,
							["originCellId"] = sLjr8FSBCP(P_1, item2.RowIndex, item2.ColumnIndex),
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
							["columnHeaderPath"] = IbZr9IJvMH(P_0, num, num2, P_2),
							["rowLabelPath"] = xStr6rQtES(P_0, num, num2, P_2),
							["rowLeftContext"] = A87ru4tsrK(P_0, num, num2, P_2),
							["writeCoordinate"] = null
						});
					}
				}
			}
		}
		return (from item in list
			orderby VUFrr6lVTF(item, "rowLeftContext"), VUFrr6lVTF(item, "writeCoordinate"), (!string.Equals(t0Ar14Clfb(item, "cellId"), "cellKind", StringComparison.Ordinal)) ? 1 : 0
			select item).ToList();
	}

	private static List<bK7KpszWkypJdk2Xvox> nlxrVudBFD(tABVE1VR66mkVrCsbLlX P_0)
	{
		List<bK7KpszWkypJdk2Xvox> list = new List<bK7KpszWkypJdk2Xvox>();
		if (P_0 == null)
		{
			return list;
		}
		foreach (yYk52kVRJmeQHGAAHZBB cell in P_0.Cells)
		{
			int num = cell.RowIndex + Math.Max(1, cell.RowSpan) - 1;
			int num2 = cell.ColumnIndex + Math.Max(1, cell.ColumnSpan) - 1;
			if (num > cell.RowIndex || num2 > cell.ColumnIndex)
			{
				list.Add(new bK7KpszWkypJdk2Xvox
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

	private static int NeBrBnQFG6(tABVE1VR66mkVrCsbLlX P_0, List<bK7KpszWkypJdk2Xvox> P_1)
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
		while (CS_8_locals_6.value <= count && P_1.Any((bK7KpszWkypJdk2Xvox merge) => merge.StartRow <= CS_8_locals_6.value && merge.EndRow >= CS_8_locals_6.value))
		{
			num = CS_8_locals_6.value;
			CS_8_locals_6.value++;
		}
		bool flag;
		do
		{
			flag = false;
			foreach (bK7KpszWkypJdk2Xvox item in P_1)
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

	private static List<string> IbZr9IJvMH(tABVE1VR66mkVrCsbLlX P_0, int P_1, int P_2, int P_3)
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
			yYk52kVRJmeQHGAAHZBB yYk52kVRJmeQHGAAHZBB2 = QGOrDbp7Kg(P_0, i, P_2);
			if (yYk52kVRJmeQHGAAHZBB2 != null)
			{
				string item = gUCrg3NX3q(yYk52kVRJmeQHGAAHZBB2.RowIndex, yYk52kVRJmeQHGAAHZBB2.ColumnIndex);
				string text = yYk52kVRJmeQHGAAHZBB2.Text ?? string.Empty;
				if (hashSet.Add(item) && !string.IsNullOrWhiteSpace(text) && !hjXrQLc8qf(list, text))
				{
					list.Add(text);
				}
			}
		}
		return list;
	}

	private static List<string> xStr6rQtES(tABVE1VR66mkVrCsbLlX P_0, int P_1, int P_2, int P_3)
	{
		List<string> list = new List<string>();
		if (P_0 == null || P_1 <= P_3 || P_2 <= 1)
		{
			return list;
		}
		HashSet<string> hashSet = new HashSet<string>(StringComparer.Ordinal);
		for (int i = 1; i < P_2; i++)
		{
			yYk52kVRJmeQHGAAHZBB yYk52kVRJmeQHGAAHZBB2 = QGOrDbp7Kg(P_0, P_1, i);
			if (yYk52kVRJmeQHGAAHZBB2 != null && yYk52kVRJmeQHGAAHZBB2.RowIndex > P_3)
			{
				string item = gUCrg3NX3q(yYk52kVRJmeQHGAAHZBB2.RowIndex, yYk52kVRJmeQHGAAHZBB2.ColumnIndex);
				string text = yYk52kVRJmeQHGAAHZBB2.Text ?? string.Empty;
				if (hashSet.Add(item) && !string.IsNullOrWhiteSpace(text) && !UHHrHo9YqJ(text) && !hjXrQLc8qf(list, text))
				{
					list.Add(text);
				}
			}
		}
		return list;
	}

	private static List<string> A87ru4tsrK(tABVE1VR66mkVrCsbLlX P_0, int P_1, int P_2, int P_3)
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
			yYk52kVRJmeQHGAAHZBB yYk52kVRJmeQHGAAHZBB2 = QGOrDbp7Kg(P_0, P_1, i);
			if (yYk52kVRJmeQHGAAHZBB2 != null && yYk52kVRJmeQHGAAHZBB2.RowIndex > P_3)
			{
				string item = gUCrg3NX3q(yYk52kVRJmeQHGAAHZBB2.RowIndex, yYk52kVRJmeQHGAAHZBB2.ColumnIndex);
				string text = yYk52kVRJmeQHGAAHZBB2.Text ?? string.Empty;
				if (hashSet.Add(item) && !string.IsNullOrWhiteSpace(text) && !hjXrQLc8qf(list, text))
				{
					list.Add(text);
				}
			}
		}
		return list;
	}

	private static yYk52kVRJmeQHGAAHZBB QGOrDbp7Kg(tABVE1VR66mkVrCsbLlX P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass46_0 CS_8_locals_6 = new _G_c__DisplayClass46_0();
		CS_8_locals_6.value = P_1;
		CS_8_locals_6.value = P_2;
		return P_0?.Cells.FirstOrDefault((yYk52kVRJmeQHGAAHZBB cell) => cell.RowIndex <= CS_8_locals_6.value && CS_8_locals_6.value < cell.RowIndex + Math.Max(1, cell.RowSpan) && cell.ColumnIndex <= CS_8_locals_6.value && CS_8_locals_6.value < cell.ColumnIndex + Math.Max(1, cell.ColumnSpan));
	}

	private static Dictionary<string, oTy5bPzeK1hVaoCKkSw> Hv3rTBRVQS(YA2LiRzCEWFlxyIhtIs P_0)
	{
		Dictionary<string, oTy5bPzeK1hVaoCKkSw> dictionary = new Dictionary<string, oTy5bPzeK1hVaoCKkSw>(StringComparer.Ordinal);
		if (P_0 == null)
		{
			return dictionary;
		}
		foreach (oTy5bPzeK1hVaoCKkSw cell in P_0.Cells)
		{
			string key = gUCrg3NX3q(cell.RowIndex, cell.ColumnIndex);
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = cell;
			}
		}
		return dictionary;
	}

	private static string gUCrg3NX3q(int P_0, int P_1)
	{
		return P_0.ToString(CultureInfo.InvariantCulture) + ":" + P_1.ToString(CultureInfo.InvariantCulture);
	}

	private static string sLjr8FSBCP(int P_0, int P_1, int P_2)
	{
		return "t" + P_0.ToString(CultureInfo.InvariantCulture) + "r" + P_1.ToString(CultureInfo.InvariantCulture) + "c" + P_2.ToString(CultureInfo.InvariantCulture);
	}

	private static bool WX3rIraaAH(Cell P_0, out int P_1, out int P_2)
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

	private static int CtirifWFy5(Range P_0)
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

	private static bool UHHrHo9YqJ(string P_0)
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

	private static bool hjXrQLc8qf(List<string> P_0, string P_1)
	{
		if (P_0.Count > 0)
		{
			return string.Equals(P_0[P_0.Count - 1], P_1, StringComparison.Ordinal);
		}
		return false;
	}

	private static string t0Ar14Clfb(Dictionary<string, object> P_0, string P_1)
	{
		if (P_0 == null || !P_0.TryGetValue(P_1, out var value) || value == null)
		{
			return string.Empty;
		}
		return Convert.ToString(value, CultureInfo.InvariantCulture);
	}

	private static int VUFrr6lVTF(Dictionary<string, object> P_0, string P_1)
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

	private static bool zLtrJh4fJ9(Dictionary<string, object> P_0, string P_1)
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

	private static object DHAr3WoUQu(a5lLcpd0tjOGP93a2IH P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass57_0 CS_8_locals_2 = new _G_c__DisplayClass57_0();
		CS_8_locals_2.value = P_1;
		if (P_0 == null)
		{
			return null;
		}
		int num = P_0.Blocks.FindIndex((iltloQVRboLvh0PbMHDS b) => b.Table != null && b.TableIndex == CS_8_locals_2.value);
		if (num < 0)
		{
			return null;
		}
		for (int num2 = num + P_2; num2 >= 0 && num2 < P_0.Blocks.Count; num2 += P_2)
		{
			ubtWXyzzVHfe9SR37mW paragraph = P_0.Blocks[num2].Paragraph;
			if (paragraph != null && !string.IsNullOrWhiteSpace(paragraph.Text))
			{
				return gEt1WsLuCr(paragraph, 500);
			}
		}
		return null;
	}

	private static object QLTrUfY8oq(a5lLcpd0tjOGP93a2IH P_0, List<MNdq0PVRGorZsHaxpvRr> P_1, int P_2)
	{
		_G_c__DisplayClass58_0 CS_8_locals_4 = new _G_c__DisplayClass58_0();
		CS_8_locals_4.a5lLcpd0tjOGP93a2IH = P_0;
		Dictionary<string, object> dictionary = tvv1A6x1MO(CS_8_locals_4.a5lLcpd0tjOGP93a2IH);
		dictionary["actionableRange"] = false;
		dictionary["rangeWarning"] = "该查找结果不包含可用于写入的 Word Range；如需批注、选中或替换，请使用 find_word_text 获取真实 Range。";
		dictionary["returned"] = P_1.Count;
		dictionary["truncated"] = P_1.Count >= P_2;
		dictionary["matches"] = ((IEnumerable<object>)P_1.Select((MNdq0PVRGorZsHaxpvRr match) => new
		{
			actionableRange = false,
			document = CS_8_locals_4.a5lLcpd0tjOGP93a2IH.DocumentName,
			documentFullName = CS_8_locals_4.a5lLcpd0tjOGP93a2IH.DocumentFullName,
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

	private static void moDrKNabHo(ubtWXyzzVHfe9SR37mW P_0, string P_1, StringComparison P_2, bool P_3, int P_4, List<MNdq0PVRGorZsHaxpvRr> P_5)
	{
		string text = P_0.Text ?? string.Empty;
		int num = 0;
		while (num < text.Length && P_5.Count < P_4)
		{
			int num2 = text.IndexOf(P_1, num, P_2);
			if (num2 >= 0)
			{
				if (!P_3 || YHJrn4XJoG(text, num2, P_1.Length))
				{
					P_5.Add(new MNdq0PVRGorZsHaxpvRr
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

	private static ubtWXyzzVHfe9SR37mW q0ErEEV1r1(a5lLcpd0tjOGP93a2IH P_0, string P_1, int P_2, int P_3, string P_4)
	{
		_G_c__DisplayClass60_0 CS_8_locals_10 = new _G_c__DisplayClass60_0();
		CS_8_locals_10.value = P_2;
		CS_8_locals_10.value = P_3;
		CS_8_locals_10.text = P_1;
		if (CS_8_locals_10.value > 0)
		{
			return P_0.Paragraphs.FirstOrDefault((ubtWXyzzVHfe9SR37mW p) => p.ParagraphIndex == CS_8_locals_10.value);
		}
		CS_8_locals_10.text = (P_4 ?? "contains").Trim().ToLowerInvariant();
		return P_0.Paragraphs.FirstOrDefault(delegate(ubtWXyzzVHfe9SR37mW p)
		{
			if (!p.IsHeading)
			{
				return false;
			}
			return (CS_8_locals_10.value <= 0 || p.OutlineLevel == CS_8_locals_10.value) && hctr2dw2UI(p.Text, CS_8_locals_10.text, CS_8_locals_10.text);
		});
	}

	private static bool hctr2dw2UI(string P_0, string P_1, string P_2)
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

	private static List<object> OdFr4eHT3G(List<List<string>> P_0)
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

	private static string irdrjYZm1n(List<List<string>> P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < P_0.Count; i++)
		{
			List<string> list = P_0[i];
			stringBuilder.Append("| ");
			stringBuilder.Append(string.Join(" | ", jnBrYy26Ad(list)));
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

	private static IEnumerable<string> jnBrYy26Ad(IEnumerable<string> P_0)
	{
		foreach (string item in P_0)
		{
			yield return (item ?? string.Empty).Replace("mergedInterior", "localTableIndex").Replace("rowIndex", "columnIndex").Replace("originCellId", "originRowIndex")
				.Replace("originColumnIndex", "rowSpan");
		}
	}

	private static string gbGrZEgL2Q(XElement P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XElement item in P_0.Descendants())
		{
			if (item.Name == zA2ryEPNHO + "t")
			{
				stringBuilder.Append(item.Value);
			}
			else if (item.Name == zA2ryEPNHO + "tab")
			{
				stringBuilder.Append('\t');
			}
			else if (item.Name == zA2ryEPNHO + "br" || item.Name == zA2ryEPNHO + "cr")
			{
				stringBuilder.Append('\n');
			}
		}
		return W8DrGBw06b(stringBuilder.ToString());
	}

	private static string cMcrfW1gSG(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return string.Empty;
		}
		XDocument xDocument = XDocument.Parse(P_0);
		return gbGrZEgL2Q((En9rt9aqSr(xDocument, "/word/document.xml") ?? xDocument).Root);
	}

	private static int o12rM5sYZ7(XElement P_0, Dictionary<string, int> P_1)
	{
		if (SUrrSJhv5e((P_0.Element(zA2ryEPNHO + "pPr")?.Element(zA2ryEPNHO + "outlineLvl"))?.Attribute(zA2ryEPNHO + "val")?.Value, out var value))
		{
			return value;
		}
		string text = P_0.Element(zA2ryEPNHO + "pPr")?.Element(zA2ryEPNHO + "pStyle")?.Attribute(zA2ryEPNHO + "val")?.Value;
		if (!string.IsNullOrWhiteSpace(text) && P_1.TryGetValue(text, out value))
		{
			return value;
		}
		return 0;
	}

	private static Dictionary<string, int> UPQrbSvBKH(XDocument P_0)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		XDocument xDocument = En9rt9aqSr(P_0, "/word/styles.xml");
		if (xDocument == null)
		{
			return dictionary;
		}
		foreach (XElement item in xDocument.Descendants(zA2ryEPNHO + "style"))
		{
			string text = item.Attribute(zA2ryEPNHO + "styleId")?.Value;
			if (!string.IsNullOrWhiteSpace(text) && SUrrSJhv5e(item.Descendants(zA2ryEPNHO + "outlineLvl").FirstOrDefault()?.Attribute(zA2ryEPNHO + "val")?.Value, out var value))
			{
				dictionary[text] = value;
			}
		}
		return dictionary;
	}

	private static bool SUrrSJhv5e(string P_0, out int P_1)
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

	private static List<wcRTakVRjwo5pepnDBig> wpmrwTxSHp(XDocument P_0)
	{
		List<wcRTakVRjwo5pepnDBig> list = new List<wcRTakVRjwo5pepnDBig>();
		XDocument xDocument = En9rt9aqSr(P_0, "/word/comments.xml");
		if (xDocument == null)
		{
			return list;
		}
		foreach (XElement item in xDocument.Descendants(zA2ryEPNHO + "comment"))
		{
			list.Add(new wcRTakVRjwo5pepnDBig
			{
				Id = (item.Attribute(zA2ryEPNHO + "id")?.Value ?? string.Empty),
				Author = (item.Attribute(zA2ryEPNHO + "author")?.Value ?? string.Empty),
				Date = (item.Attribute(zA2ryEPNHO + "date")?.Value ?? string.Empty),
				Text = gbGrZEgL2Q(item)
			});
		}
		return list;
	}

	private static XDocument En9rt9aqSr(XDocument P_0, string P_1)
	{
		_G_c__DisplayClass71_0 CS_8_locals_3 = new _G_c__DisplayClass71_0();
		CS_8_locals_3.text = P_1;
		if (P_0?.Root == null)
		{
			return null;
		}
		if (P_0.Root.Name == zA2ryEPNHO + "document" && string.Equals(CS_8_locals_3.text, "/word/document.xml", StringComparison.OrdinalIgnoreCase))
		{
			return P_0;
		}
		XElement xElement = P_0.Root.Elements(noWrXsAkl3 + "part").FirstOrDefault((XElement p) => string.Equals(p.Attribute(noWrXsAkl3 + "xmlData")?.Value, CS_8_locals_3.text, StringComparison.OrdinalIgnoreCase))?.Element(noWrXsAkl3 + "columnSpan")?.Elements().FirstOrDefault();
		if (xElement == null)
		{
			return null;
		}
		return new XDocument(new XElement(xElement));
	}

	private static void tDfrL7gpkn(a5lLcpd0tjOGP93a2IH P_0, XElement P_1)
	{
		string text = gbGrZEgL2Q(P_1);
		int num = o12rM5sYZ7(P_1, P_0.StyleOutlineLevels);
		ubtWXyzzVHfe9SR37mW ubtWXyzzVHfe9SR37mW2 = new ubtWXyzzVHfe9SR37mW
		{
			ParagraphIndex = P_0.Paragraphs.Count + 1,
			Text = text,
			OutlineLevel = num,
			IsHeading = (num >= 1 && num <= 9)
		};
		P_0.Paragraphs.Add(ubtWXyzzVHfe9SR37mW2);
		P_0.Blocks.Add(new iltloQVRboLvh0PbMHDS
		{
			ParagraphIndex = ubtWXyzzVHfe9SR37mW2.ParagraphIndex,
			Paragraph = ubtWXyzzVHfe9SR37mW2
		});
	}

	private static void W5WrsPQn2V(a5lLcpd0tjOGP93a2IH P_0, XElement P_1)
	{
		tABVE1VR66mkVrCsbLlX tABVE1VR66mkVrCsbLlX2 = Jksrl7uSPj(P_0, P_1, P_0.Tables.Count + 1);
		P_0.Tables.Add(tABVE1VR66mkVrCsbLlX2);
		P_0.Blocks.Add(new iltloQVRboLvh0PbMHDS
		{
			TableIndex = tABVE1VR66mkVrCsbLlX2.TableIndex,
			FirstParagraphIndex = tABVE1VR66mkVrCsbLlX2.FirstParagraphIndex,
			Table = tABVE1VR66mkVrCsbLlX2
		});
	}

	private static tABVE1VR66mkVrCsbLlX Jksrl7uSPj(a5lLcpd0tjOGP93a2IH P_0, XElement P_1, int P_2)
	{
		tABVE1VR66mkVrCsbLlX tABVE1VR66mkVrCsbLlX2 = new tABVE1VR66mkVrCsbLlX
		{
			DocumentName = P_0.DocumentName,
			DocumentFullName = P_0.DocumentFullName,
			DocumentSaved = P_0.DocumentSaved,
			TableIndex = P_2,
			FirstParagraphIndex = P_0.Paragraphs.Count + 1,
			AltTextTitle = P_1.Element(zA2ryEPNHO + "tblPr")?.Element(zA2ryEPNHO + "tblCaption")?.Attribute(zA2ryEPNHO + "val")?.Value,
			AltTextDescription = P_1.Element(zA2ryEPNHO + "tblPr")?.Element(zA2ryEPNHO + "tblDescription")?.Attribute(zA2ryEPNHO + "val")?.Value
		};
		Dictionary<int, yYk52kVRJmeQHGAAHZBB> dictionary = new Dictionary<int, yYk52kVRJmeQHGAAHZBB>();
		foreach (XElement item in P_1.Elements(zA2ryEPNHO + "tr"))
		{
			List<string> list = new List<string>();
			int num = 1;
			HashSet<yYk52kVRJmeQHGAAHZBB> hashSet = new HashSet<yYk52kVRJmeQHGAAHZBB>();
			foreach (XElement item2 in item.Elements(zA2ryEPNHO + "tc"))
			{
				while (list.Count < num - 1)
				{
					list.Add(string.Empty);
				}
				int num2 = g1GrNuNhZE(item2);
				XElement xElement = item2.Element(zA2ryEPNHO + "tcPr")?.Element(zA2ryEPNHO + "vMerge");
				bool flag = xElement != null;
				bool flag2 = flag && !string.Equals(xElement.Attribute(zA2ryEPNHO + "val")?.Value, "restart", StringComparison.OrdinalIgnoreCase);
				string text = gbGrZEgL2Q(item2);
				yYk52kVRJmeQHGAAHZBB value = null;
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
					value = new yYk52kVRJmeQHGAAHZBB
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
		tABVE1VR66mkVrCsbLlX2.RawText = W8DrGBw06b(string.Join("\n", tABVE1VR66mkVrCsbLlX2.Matrix.Select((List<string> r) => string.Join("p", r))));
		foreach (XElement item3 in P_1.Descendants(zA2ryEPNHO + "isHeader"))
		{
			string text2 = gbGrZEgL2Q(item3);
			int num3 = o12rM5sYZ7(item3, P_0.StyleOutlineLevels);
			P_0.Paragraphs.Add(new ubtWXyzzVHfe9SR37mW
			{
				ParagraphIndex = P_0.Paragraphs.Count + 1,
				Text = text2,
				OutlineLevel = num3,
				IsHeading = (num3 >= 1 && num3 <= 9)
			});
		}
		return tABVE1VR66mkVrCsbLlX2;
	}

	private static int g1GrNuNhZE(XElement P_0)
	{
		if (!int.TryParse(P_0.Element(zA2ryEPNHO + "tcPr")?.Element(zA2ryEPNHO + "gridSpan")?.Attribute(zA2ryEPNHO + "val")?.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) || result < 1)
		{
			return 1;
		}
		return result;
	}

	private static int sFarm8rvtQ(int P_0, int P_1, int P_2)
	{
		if (P_0 <= 0)
		{
			P_0 = P_1;
		}
		return Math.Max(1, Math.Min(P_0, P_2));
	}

	private static int awRro3mnDA(int P_0)
	{
		if (P_0 <= 0)
		{
			P_0 = 1;
		}
		return Math.Max(1, Math.Min(P_0, 9));
	}

	private static string W8DrGBw06b(string P_0)
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

	private static string cmxrpX5s5e(string P_0, int P_1)
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

	private static bool YHJrn4XJoG(string P_0, int P_1, int P_2)
	{
		bool num = P_1 <= 0 || !URtr77CxW6(P_0[P_1 - 1]);
		int num2 = P_1 + P_2;
		bool flag = num2 >= P_0.Length || !URtr77CxW6(P_0[num2]);
		return num && flag;
	}

	private static bool URtr77CxW6(char P_0)
	{
		if (!char.IsLetterOrDigit(P_0))
		{
			return P_0 == '_';
		}
		return true;
	}

	private static string N75r5VKX8X(Func<string> P_0)
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

	private static bool PSHrcSln4y(Func<bool> P_0, bool P_1)
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
		zA2ryEPNHO = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
		noWrXsAkl3 = "http://schemas.microsoft.com/office/2006/xmlPackage";
	}
}
