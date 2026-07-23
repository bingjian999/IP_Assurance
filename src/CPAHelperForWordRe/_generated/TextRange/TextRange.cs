using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace TextRange;

internal struct TextRange
{
	[CompilerGenerated]
	private readonly int _start;

	[CompilerGenerated]
	private readonly int _int;

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return _start;
		}
	}

	public int Length
	{
		[CompilerGenerated]
		get
		{
			return _int;
		}
	}

	public int End => Start + Length;

	public TextRange(int P_0, int P_1)
	{
		SseStreamInitializer.InitializeRuntime();
		_start = P_0;
		_int = P_1;
	}
}
