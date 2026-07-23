using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace TableCellModel;

internal sealed class TableCellModel
{
	[CompilerGenerated]
	private int _localTableIndex;

	[CompilerGenerated]
	private int _tableIndex;

	[CompilerGenerated]
	private int _rowIndex;

	[CompilerGenerated]
	private int _columnIndex;

	[CompilerGenerated]
	private string _expectedOldText;

	[CompilerGenerated]
	private string _text;

	[CompilerGenerated]
	private string _newText;

	[CompilerGenerated]
	private bool JnIiFvWHqn;

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

	public bool IsHeader
	{
		[CompilerGenerated]
		get
		{
			return JnIiFvWHqn;
		}
		[CompilerGenerated]
		set
		{
			JnIiFvWHqn = value;
		}
	}

	public TableCellModel()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
