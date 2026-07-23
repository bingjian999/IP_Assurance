using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;
using Helper_2;

namespace RibbonMenuItem;

internal sealed class RibbonMenuItem : Helper_2
{
	private string ON5mv1cLlB;

	private string IBwmWs89D4;

	[CompilerGenerated]
	private readonly string InLm0R4pbI;

	[CompilerGenerated]
	private readonly string DxJmksE0Sy;

	[CompilerGenerated]
	private readonly bool Soamx5oBjM;

	public string Key
	{
		[CompilerGenerated]
		get
		{
			return InLm0R4pbI;
		}
	}

	public string Label
	{
		[CompilerGenerated]
		get
		{
			return DxJmksE0Sy;
		}
	}

	public bool IsSection
	{
		[CompilerGenerated]
		get
		{
			return Soamx5oBjM;
		}
	}

	public string StyleValue
	{
		get
		{
			return ON5mv1cLlB;
		}
		set
		{
			MrCsWWMvwp(ref ON5mv1cLlB, value, "StyleValue");
		}
	}

	public string WidthValue
	{
		get
		{
			return IBwmWs89D4;
		}
		set
		{
			MrCsWWMvwp(ref IBwmWs89D4, value, "WidthValue");
		}
	}

	public RibbonMenuItem(string P_0)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		InLm0R4pbI = P_0;
		DxJmksE0Sy = P_0 + "：";
	}

	private RibbonMenuItem(string P_0, bool P_1)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		DxJmksE0Sy = P_0;
		Soamx5oBjM = P_1;
	}

	public static RibbonMenuItem SObmA0Jxbq(string P_0)
	{
		return new RibbonMenuItem(P_0, true);
	}
}
