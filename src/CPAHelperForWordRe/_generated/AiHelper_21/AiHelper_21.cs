using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;

namespace AiHelper_21;

internal sealed class AiHelper_21
{
	[CompilerGenerated]
	private int _requestIndex;

	[CompilerGenerated]
	private int _localTableIndex;

	[CompilerGenerated]
	private int JsZiAroKeq;

	[CompilerGenerated]
	private int _columnIndex;

	[CompilerGenerated]
	private int _headerRowCount;

	[CompilerGenerated]
	private bool _isHeader;

	[CompilerGenerated]
	private int _page;

	[CompilerGenerated]
	private int _rangeStart;

	[CompilerGenerated]
	private int olWidtcyQD;

	[CompilerGenerated]
	private string _oldText;

	[CompilerGenerated]
	private string _expectedOldText;

	[CompilerGenerated]
	private string _newText;

	[CompilerGenerated]
	private bool _writable;

	[CompilerGenerated]
	private string _errorCode;

	[CompilerGenerated]
	private string _errorMessage;

	[CompilerGenerated]
	private Cell _cell;

	public int RequestIndex
	{
		[CompilerGenerated]
		get
		{
			return _requestIndex;
		}
		[CompilerGenerated]
		set
		{
			_requestIndex = value;
		}
	}

	public int LocalTableIndex
	{
		[CompilerGenerated]
		get
		{
			return _localTableIndex;
		}
		[CompilerGenerated]
		set
		{
			_localTableIndex = value;
		}
	}

	public int RowIndex
	{
		[CompilerGenerated]
		get
		{
			return JsZiAroKeq;
		}
		[CompilerGenerated]
		set
		{
			JsZiAroKeq = value;
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

	public bool IsHeader
	{
		[CompilerGenerated]
		get
		{
			return _isHeader;
		}
		[CompilerGenerated]
		set
		{
			_isHeader = value;
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
			return olWidtcyQD;
		}
		[CompilerGenerated]
		set
		{
			olWidtcyQD = value;
		}
	}

	public string OldText
	{
		[CompilerGenerated]
		get
		{
			return _oldText;
		}
		[CompilerGenerated]
		set
		{
			_oldText = value;
		}
	}

	public string ExpectedOldText
	{
		[CompilerGenerated]
		get
		{
			return _expectedOldText;
		}
		[CompilerGenerated]
		set
		{
			_expectedOldText = value;
		}
	}

	public string NewText
	{
		[CompilerGenerated]
		get
		{
			return _newText;
		}
		[CompilerGenerated]
		set
		{
			_newText = value;
		}
	}

	public bool Writable
	{
		[CompilerGenerated]
		get
		{
			return _writable;
		}
		[CompilerGenerated]
		set
		{
			_writable = value;
		}
	}

	public string ErrorCode
	{
		[CompilerGenerated]
		get
		{
			return _errorCode;
		}
		[CompilerGenerated]
		set
		{
			_errorCode = value;
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

	public Cell Cell
	{
		[CompilerGenerated]
		get
		{
			return _cell;
		}
		[CompilerGenerated]
		set
		{
			_cell = value;
		}
	}

	public AiHelper_21()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
