using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace CPAHelperForWordRe.UI.Forms.Common;

public sealed class ConfigEntry
{
	[CompilerGenerated]
	private string _key;

	[CompilerGenerated]
	private string _value;

	public string Key
	{
		[CompilerGenerated]
		get
		{
			return _key;
		}
		[CompilerGenerated]
		set
		{
			_key = value;
		}
	}

	public string Value
	{
		[CompilerGenerated]
		get
		{
			return _value;
		}
		[CompilerGenerated]
		set
		{
			_value = value;
		}
	}

	public ConfigEntry()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
