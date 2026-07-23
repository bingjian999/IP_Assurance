using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace WordSearchResult;

internal sealed class WordSearchResult
{
	[CompilerGenerated]
	private int? _paragraphIndex;

	[CompilerGenerated]
	private int _rangeStart;

	[CompilerGenerated]
	private int _rangeEnd;

	[CompilerGenerated]
	private string fncimGsLsj;

	[CompilerGenerated]
	private string _paragraphText;

	[CompilerGenerated]
	private int _paragraphTextCharacters;

	[CompilerGenerated]
	private bool lNHiCaRow4;

	public int? ParagraphIndex
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
			return _rangeEnd;
		}
		[CompilerGenerated]
		set
		{
			_rangeEnd = value;
		}
	}

	public string MatchText
	{
		[CompilerGenerated]
		get
		{
			return fncimGsLsj;
		}
		[CompilerGenerated]
		set
		{
			fncimGsLsj = value;
		}
	}

	public string ParagraphText
	{
		[CompilerGenerated]
		get
		{
			return _paragraphText;
		}
		[CompilerGenerated]
		set
		{
			_paragraphText = value;
		}
	}

	public int ParagraphTextCharacters
	{
		[CompilerGenerated]
		get
		{
			return _paragraphTextCharacters;
		}
		[CompilerGenerated]
		set
		{
			_paragraphTextCharacters = value;
		}
	}

	public bool ParagraphTextTruncated
	{
		[CompilerGenerated]
		get
		{
			return lNHiCaRow4;
		}
		[CompilerGenerated]
		set
		{
			lNHiCaRow4 = value;
		}
	}

	public WordSearchResult()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
