using System.Diagnostics;
using AiSseStreamService3;

namespace AiHelper_3;

internal static class AiHelper_3
{
	public static void OpenUrl(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return;
		}
		try
		{
			Process.Start(new ProcessStartInfo(P_0)
			{
				UseShellExecute = true
			});
		}
		catch
		{
		}
	}

	public static void YWiVzgIWFQ()
	{
		OpenUrl("https://www.cgzcpa.com/");
	}

	public static void BWIBRayGaa()
	{
		OpenUrl("https://www.cgzcpa.com/");
	}

	public static void kTVBVZcQB1()
	{
		OpenUrl("https://www.cgzcpa.com/article/70");
	}

	public static void OpenHelpArticle()
	{
		OpenUrl("https://www.cgzcpa.com/article/70");
	}

	public static void OpenTutorialArticle()
	{
		OpenUrl("https://www.cgzcpa.com/article/71");
	}

	public static void OpenAiCourse()
	{
		OpenUrl("https://www.cgzcpa.com/ai-course/index.html");
	}

	public static void OpenSponsorshipPage()
	{
		OpenUrl("https://www.cgzcpa.com/sponsorship");
	}
}
