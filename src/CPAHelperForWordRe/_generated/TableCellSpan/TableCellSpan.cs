using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace TableCellSpan;

internal sealed class TableCellSpan
{
	[CompilerGenerated]
	private int _rowIndex;

	[CompilerGenerated]
	private int YFLHOeOqYu;

	[CompilerGenerated]
	private int _rowSpan;

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

	public int ColumnIndex
	{
		[CompilerGenerated]
		get
		{
			return YFLHOeOqYu;
		}
		[CompilerGenerated]
		set
		{
			YFLHOeOqYu = value;
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

	public TableCellSpan()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
