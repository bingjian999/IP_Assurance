using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;
using Helper_2;

namespace UiHelper_2;

internal sealed class UiHelper_2 : Helper_2
{
	private string kBAoRK7Vi3;

	private string bHLoV0F0pN;

	[CompilerGenerated]
	private readonly string NDFoBgJNOB;

	[CompilerGenerated]
	private readonly string BRYo9Qnwe8;

	public string Key
	{
		[CompilerGenerated]
		get
		{
			return NDFoBgJNOB;
		}
	}

	public string Label
	{
		[CompilerGenerated]
		get
		{
			return BRYo9Qnwe8;
		}
	}

	public string HorizontalValue
	{
		get
		{
			return kBAoRK7Vi3;
		}
		set
		{
			MrCsWWMvwp(ref kBAoRK7Vi3, value, "HorizontalValue");
		}
	}

	public string VerticalValue
	{
		get
		{
			return bHLoV0F0pN;
		}
		set
		{
			MrCsWWMvwp(ref bHLoV0F0pN, value, "VerticalValue");
		}
	}

	public UiHelper_2(string P_0)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		NDFoBgJNOB = P_0;
		BRYo9Qnwe8 = P_0 + "：";
	}
}
