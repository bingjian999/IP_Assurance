using System.Runtime.CompilerServices;
using SseStreamInitializer;
using ProviderConfig;

namespace Helper_22;

internal sealed class Helper_22
{
	[CompilerGenerated]
	private ProviderConfig _assistant;

	public ProviderConfig Assistant
	{
		[CompilerGenerated]
		get
		{
			return _assistant;
		}
		[CompilerGenerated]
		set
		{
			_assistant = value;
		}
	}

	public void DuXtXcAhKd()
	{
		if (Assistant == null)
		{
			Assistant = new ProviderConfig();
		}
		Assistant.Initialize();
	}

	public Helper_22()
	{
		SseStreamInitializer.InitializeRuntime();
		_assistant = new ProviderConfig();
	}
}
