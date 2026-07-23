using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace TextRange;

internal struct TextRange
{
	[CompilerGenerated]
	private readonly int DbvSYwHKn2;

	[CompilerGenerated]
	private readonly int B3MSZXkHR0;

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return DbvSYwHKn2;
		}
	}

	public int Length
	{
		[CompilerGenerated]
		get
		{
			return B3MSZXkHR0;
		}
	}

	public int End => Start + Length;

	public TextRange(int P_0, int P_1)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		DbvSYwHKn2 = P_0;
		B3MSZXkHR0 = P_1;
	}
}
