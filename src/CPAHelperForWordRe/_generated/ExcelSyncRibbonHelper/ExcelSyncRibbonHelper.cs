using TableComWriteService;
using UiHelperService;
using LoggerInitializer;

namespace ExcelSyncRibbonHelper;

internal static class ExcelSyncRibbonHelper
{
	public static void CsKcO7u6di(TableComWriteService.B8Id9rVIwgTW2spgYNvs P_0, string P_1 = "Excel同步")
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_0.Message))
		{
			return;
		}
		string text = P_0.Message.Trim();
		if (P_0.Success)
		{
			UiHelperService.SeXce6fgLN(text, P_1);
		}
		else if (P_0.Cancelled)
		{
			UiHelperService.Kn6cyKZe85(text, P_1);
		}
		else if (P_0.RequiresUserAction)
		{
			if (string.IsNullOrWhiteSpace(P_0.TechnicalDetail))
			{
				LoggerInitializer.u0kcmnykTv(text, P_1);
			}
			else
			{
				LoggerInitializer.F9Ycoqv2I8(text, P_1);
			}
		}
		else
		{
			UiHelperService.Kn6cyKZe85(text, P_1);
		}
	}

	public static void psZcncX5UL(string P_0, string P_1 = "Excel同步")
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			UiHelperService.SeXce6fgLN(P_0.Trim(), P_1);
		}
	}

	public static void kX7c742XgE(string P_0, string P_1 = "Excel同步")
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			UiHelperService.Kn6cyKZe85(P_0.Trim(), P_1);
		}
	}
}
