using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace WordWindowInfo;

internal sealed class WordWindowInfo
{
	[CompilerGenerated]
	private string _windowKey;

	[CompilerGenerated]
	private int _windowHwnd;

	[CompilerGenerated]
	private string _documentName;

	[CompilerGenerated]
	private string _documentFullName;

	[CompilerGenerated]
	private string _documentPath;

	[CompilerGenerated]
	private int _selectionStart;

	[CompilerGenerated]
	private int _selectionEnd;

	[CompilerGenerated]
	private int _selectionTextLength;

	[CompilerGenerated]
	private int _pageNumber;

	[CompilerGenerated]
	private string _wordOpenXmlCacheDocumentKey;

	[CompilerGenerated]
	private object dicuQthwMm;

	public string WindowKey
	{
		[CompilerGenerated]
		get
		{
			return _windowKey;
		}
		[CompilerGenerated]
		set
		{
			_windowKey = value;
		}
	}

	public int WindowHwnd
	{
		[CompilerGenerated]
		get
		{
			return _windowHwnd;
		}
		[CompilerGenerated]
		set
		{
			_windowHwnd = value;
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

	public string DocumentPath
	{
		[CompilerGenerated]
		get
		{
			return _documentPath;
		}
		[CompilerGenerated]
		set
		{
			_documentPath = value;
		}
	}

	public int SelectionStart
	{
		[CompilerGenerated]
		get
		{
			return _selectionStart;
		}
		[CompilerGenerated]
		set
		{
			_selectionStart = value;
		}
	}

	public int SelectionEnd
	{
		[CompilerGenerated]
		get
		{
			return _selectionEnd;
		}
		[CompilerGenerated]
		set
		{
			_selectionEnd = value;
		}
	}

	public int SelectionTextLength
	{
		[CompilerGenerated]
		get
		{
			return _selectionTextLength;
		}
		[CompilerGenerated]
		set
		{
			_selectionTextLength = value;
		}
	}

	public int PageNumber
	{
		[CompilerGenerated]
		get
		{
			return _pageNumber;
		}
		[CompilerGenerated]
		set
		{
			_pageNumber = value;
		}
	}

	public string WordOpenXmlCacheDocumentKey
	{
		[CompilerGenerated]
		get
		{
			return _wordOpenXmlCacheDocumentKey;
		}
		[CompilerGenerated]
		set
		{
			_wordOpenXmlCacheDocumentKey = value;
		}
	}

	public object WordOpenXmlCache
	{
		[CompilerGenerated]
		get
		{
			return dicuQthwMm;
		}
		[CompilerGenerated]
		set
		{
			dicuQthwMm = value;
		}
	}

	public bool HasDocument
	{
		get
		{
			if (string.IsNullOrWhiteSpace(DocumentName))
			{
				return !string.IsNullOrWhiteSpace(DocumentFullName);
			}
			return true;
		}
	}

	public bool HasPaneTarget => !string.IsNullOrWhiteSpace(WindowKey);

	public WordWindowInfo()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
