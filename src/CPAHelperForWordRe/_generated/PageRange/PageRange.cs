using System.Globalization;
using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;

namespace PageRange;

internal sealed class PageRange
{
	[CompilerGenerated]
	private readonly int nTnnvqCXgI;

	[CompilerGenerated]
	private readonly int qRxnWr32us;

	public int StartPage
	{
		[CompilerGenerated]
		get
		{
			return nTnnvqCXgI;
		}
	}

	public int EndPage
	{
		[CompilerGenerated]
		get
		{
			return qRxnWr32us;
		}
	}

	public string DisplayText
	{
		get
		{
			if (StartPage != EndPage)
			{
				return StartPage.ToString(CultureInfo.InvariantCulture) + "-" + EndPage.ToString(CultureInfo.InvariantCulture);
			}
			return StartPage.ToString(CultureInfo.InvariantCulture);
		}
	}

	public PageRange(int P_0, int P_1)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		nTnnvqCXgI = P_0;
		qRxnWr32us = P_1;
	}
}
