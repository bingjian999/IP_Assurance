using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_4;

internal sealed class Helper_4
{
	[CompilerGenerated]
	private int _startRow;

	[CompilerGenerated]
	private int _startColumn;

	[CompilerGenerated]
	private int _endRow;

	[CompilerGenerated]
	private int MIWHFcdXRS;

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
			return _endRow;
		}
		[CompilerGenerated]
		set
		{
			_endRow = value;
		}
	}

	public int EndColumn
	{
		[CompilerGenerated]
		get
		{
			return MIWHFcdXRS;
		}
		[CompilerGenerated]
		set
		{
			MIWHFcdXRS = value;
		}
	}

	public Helper_4()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
