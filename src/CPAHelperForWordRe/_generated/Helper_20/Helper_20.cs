using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_20;

internal sealed class Helper_20
{
	[CompilerGenerated]
	private string _type;

	[CompilerGenerated]
	private int _rangeStart;

	[CompilerGenerated]
	private object TSGQNwarhb;

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
			return _rangeStart;
		}
		[CompilerGenerated]
		set
		{
			_rangeStart = value;
		}
	}

	public object Data
	{
		[CompilerGenerated]
		get
		{
			return TSGQNwarhb;
		}
		[CompilerGenerated]
		set
		{
			TSGQNwarhb = value;
		}
	}

	public Helper_20()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
