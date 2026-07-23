using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;

namespace WordTableToolService3;

internal sealed class WordTableToolService3
{
	[CompilerGenerated]
	private int _rows;

	[CompilerGenerated]
	private int _columns;

	[CompilerGenerated]
	private string FefHMfkGKa;

	[CompilerGenerated]
	private bool igrHbQaSOm;

	[CompilerGenerated]
	private bool _adjustAfterInsert;

	[CompilerGenerated]
	private int _paragraphStart;

	[CompilerGenerated]
	private int _paragraphEnd;

	[CompilerGenerated]
	private int wdpHLpwvHM;

	[CompilerGenerated]
	private string LVlHsxnFE7;

	[CompilerGenerated]
	private bool _paragraphIsEmpty;

	[CompilerGenerated]
	private int iZMHNpXBqv;

	[CompilerGenerated]
	private int HbkHmLFNnk;

	[CompilerGenerated]
	private Range _focusRange;

	public int Rows
	{
		[CompilerGenerated]
		get
		{
			return _rows;
		}
		[CompilerGenerated]
		set
		{
			_rows = value;
		}
	}

	public int Columns
	{
		[CompilerGenerated]
		get
		{
			return _columns;
		}
		[CompilerGenerated]
		set
		{
			_columns = value;
		}
	}

	public string Placement
	{
		[CompilerGenerated]
		get
		{
			return FefHMfkGKa;
		}
		[CompilerGenerated]
		set
		{
			FefHMfkGKa = value;
		}
	}

	public bool UseTrackChanges
	{
		[CompilerGenerated]
		get
		{
			return igrHbQaSOm;
		}
		[CompilerGenerated]
		set
		{
			igrHbQaSOm = value;
		}
	}

	public bool AdjustAfterInsert
	{
		[CompilerGenerated]
		get
		{
			return _adjustAfterInsert;
		}
		[CompilerGenerated]
		set
		{
			_adjustAfterInsert = value;
		}
	}

	public int ParagraphStart
	{
		[CompilerGenerated]
		get
		{
			return _paragraphStart;
		}
		[CompilerGenerated]
		set
		{
			_paragraphStart = value;
		}
	}

	public int ParagraphEnd
	{
		[CompilerGenerated]
		get
		{
			return _paragraphEnd;
		}
		[CompilerGenerated]
		set
		{
			_paragraphEnd = value;
		}
	}

	public int InsertionStart
	{
		[CompilerGenerated]
		get
		{
			return wdpHLpwvHM;
		}
		[CompilerGenerated]
		set
		{
			wdpHLpwvHM = value;
		}
	}

	public string ParagraphText
	{
		[CompilerGenerated]
		get
		{
			return LVlHsxnFE7;
		}
		[CompilerGenerated]
		set
		{
			LVlHsxnFE7 = value;
		}
	}

	public bool ParagraphIsEmpty
	{
		[CompilerGenerated]
		get
		{
			return _paragraphIsEmpty;
		}
		[CompilerGenerated]
		set
		{
			_paragraphIsEmpty = value;
		}
	}

	public int Page
	{
		[CompilerGenerated]
		get
		{
			return iZMHNpXBqv;
		}
		[CompilerGenerated]
		set
		{
			iZMHNpXBqv = value;
		}
	}

	public int TableCountBefore
	{
		[CompilerGenerated]
		get
		{
			return HbkHmLFNnk;
		}
		[CompilerGenerated]
		set
		{
			HbkHmLFNnk = value;
		}
	}

	public Range FocusRange
	{
		[CompilerGenerated]
		get
		{
			return _focusRange;
		}
		[CompilerGenerated]
		set
		{
			_focusRange = value;
		}
	}

	public WordTableToolService3()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
