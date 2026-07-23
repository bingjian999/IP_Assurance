using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;
using Helper_2;

namespace UiHelper_2;

internal sealed class UiHelper_2 : Helper_2
{
	private string _horizontalValue;

	private string _verticalValue;

	[CompilerGenerated]
	private readonly string NDFoBgJNOB;

	[CompilerGenerated]
	private readonly string _string;

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
			return _string;
		}
	}

	public string HorizontalValue
	{
		get
		{
			return _horizontalValue;
		}
		set
		{
			MrCsWWMvwp(ref _horizontalValue, value, "HorizontalValue");
		}
	}

	public string VerticalValue
	{
		get
		{
			return _verticalValue;
		}
		set
		{
			MrCsWWMvwp(ref _verticalValue, value, "VerticalValue");
		}
	}

	public UiHelper_2(string P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		NDFoBgJNOB = P_0;
		_string = P_0 + "：";
	}
}
