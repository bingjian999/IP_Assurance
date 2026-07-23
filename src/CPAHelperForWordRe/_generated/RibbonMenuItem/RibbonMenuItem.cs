using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;
using Helper_2;

namespace RibbonMenuItem;

internal sealed class RibbonMenuItem : Helper_2
{
	private string _styleValue;

	private string _widthValue;

	[CompilerGenerated]
	private readonly string _string;

	[CompilerGenerated]
	private readonly string _string;

	[CompilerGenerated]
	private readonly bool _bool;

	public string Key
	{
		[CompilerGenerated]
		get
		{
			return _string;
		}
	}

	public string Label
	{
		[CompilerGenerated]
		get
		{
			return _string;
		}
	}

	public bool IsSection
	{
		[CompilerGenerated]
		get
		{
			return _bool;
		}
	}

	public string StyleValue
	{
		get
		{
			return _styleValue;
		}
		set
		{
			MrCsWWMvwp(ref _styleValue, value, "StyleValue");
		}
	}

	public string WidthValue
	{
		get
		{
			return _widthValue;
		}
		set
		{
			MrCsWWMvwp(ref _widthValue, value, "WidthValue");
		}
	}

	public RibbonMenuItem(string P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_string = P_0;
		_string = P_0 + "：";
	}

	private RibbonMenuItem(string P_0, bool P_1)
	{
		SseStreamInitializer.InitializeRuntime();
		_string = P_0;
		_bool = P_1;
	}

	public static RibbonMenuItem SObmA0Jxbq(string P_0)
	{
		return new RibbonMenuItem(P_0, true);
	}
}
