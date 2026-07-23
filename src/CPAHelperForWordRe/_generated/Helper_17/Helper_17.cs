using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_17;

internal sealed class Helper_17
{
	[CompilerGenerated]
	private bool _succeeded;

	[CompilerGenerated]
	private string _accessToken;

	[CompilerGenerated]
	private string _message;

	[CompilerGenerated]
	private bool _isCanceled;

	public bool Succeeded
	{
		[CompilerGenerated]
		get
		{
			return _succeeded;
		}
		[CompilerGenerated]
		private set
		{
			_succeeded = value;
		}
	}

	public string AccessToken
	{
		[CompilerGenerated]
		get
		{
			return _accessToken;
		}
		[CompilerGenerated]
		private set
		{
			_accessToken = value;
		}
	}

	public string Message
	{
		[CompilerGenerated]
		get
		{
			return _message;
		}
		[CompilerGenerated]
		private set
		{
			_message = value;
		}
	}

	public bool IsCanceled
	{
		[CompilerGenerated]
		get
		{
			return _isCanceled;
		}
		[CompilerGenerated]
		private set
		{
			_isCanceled = value;
		}
	}

	public static Helper_17 Rvo60brAFr(string P_0)
	{
		return new Helper_17
		{
			Succeeded = true,
			AccessToken = (P_0 ?? string.Empty)
		};
	}

	public static Helper_17 Kr16k5pGs6(string P_0, bool P_1)
	{
		return new Helper_17
		{
			Succeeded = false,
			Message = (P_0 ?? string.Empty),
			IsCanceled = P_1
		};
	}

	public Helper_17()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
