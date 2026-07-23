using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_17;

internal sealed class Helper_17
{
	[CompilerGenerated]
	private bool PHq6xwGiuC;

	[CompilerGenerated]
	private string ydW6dwQnAt;

	[CompilerGenerated]
	private string Wia6zfBoXq;

	[CompilerGenerated]
	private bool Iy9uRYXY9n;

	public bool Succeeded
	{
		[CompilerGenerated]
		get
		{
			return PHq6xwGiuC;
		}
		[CompilerGenerated]
		private set
		{
			PHq6xwGiuC = value;
		}
	}

	public string AccessToken
	{
		[CompilerGenerated]
		get
		{
			return ydW6dwQnAt;
		}
		[CompilerGenerated]
		private set
		{
			ydW6dwQnAt = value;
		}
	}

	public string Message
	{
		[CompilerGenerated]
		get
		{
			return Wia6zfBoXq;
		}
		[CompilerGenerated]
		private set
		{
			Wia6zfBoXq = value;
		}
	}

	public bool IsCanceled
	{
		[CompilerGenerated]
		get
		{
			return Iy9uRYXY9n;
		}
		[CompilerGenerated]
		private set
		{
			Iy9uRYXY9n = value;
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
		SseStreamInitializer.AlBVL0oCCKQ();
	}
}
