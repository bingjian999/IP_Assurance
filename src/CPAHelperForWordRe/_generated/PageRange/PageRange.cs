using System.Globalization;
using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;

namespace PageRange;

internal sealed class PageRange
{
	[CompilerGenerated]
	private readonly int _startPage;

	[CompilerGenerated]
	private readonly int _endPage;

	public int StartPage
	{
		[CompilerGenerated]
		get
		{
			return _startPage;
		}
	}

	public int EndPage
	{
		[CompilerGenerated]
		get
		{
			return _endPage;
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
		SseStreamInitializer.InitializeRuntime();
		_startPage = P_0;
		_endPage = P_1;
	}
}
