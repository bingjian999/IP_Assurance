using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_14;

internal sealed class Helper_14
{
	[CompilerGenerated]
	private readonly string _text;

	[CompilerGenerated]
	private readonly string _value;

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return _text;
		}
	}

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return _value;
		}
	}

	public Helper_14(string P_0, string P_1)
	{
		SseStreamInitializer.InitializeRuntime();
		_text = P_0 ?? string.Empty;
		_value = P_1 ?? string.Empty;
	}

	public override string ToString()
	{
		return Text;
	}
}
