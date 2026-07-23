using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_11;

internal sealed class Helper_11
{
	[CompilerGenerated]
	private string _code;

	[CompilerGenerated]
	private string _message;

	public string code
	{
		[CompilerGenerated]
		get
		{
			return _code;
		}
		[CompilerGenerated]
		set
		{
			_code = value;
		}
	}

	public string message
	{
		[CompilerGenerated]
		get
		{
			return _message;
		}
		[CompilerGenerated]
		set
		{
			_message = value;
		}
	}

	public Helper_11()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
