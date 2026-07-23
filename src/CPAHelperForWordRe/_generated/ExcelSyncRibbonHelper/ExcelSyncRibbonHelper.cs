using TableComWriteService;
using UiHelperService;
using LoggerInitializer;

namespace ExcelSyncRibbonHelper;

internal static class ExcelSyncRibbonHelper
{
	public static void ShowSyncResult(TableComWriteService.SyncResult P_0, string P_1 = "Excel同步")
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_0.Message))
		{
			return;
		}
		string text = P_0.Message.Trim();
		if (P_0.Success)
		{
			UiHelperService.ShowToastInfo(text, P_1);
		}
		else if (P_0.Cancelled)
		{
			UiHelperService.ShowToastWarning(text, P_1);
		}
		else if (P_0.RequiresUserAction)
		{
			if (string.IsNullOrWhiteSpace(P_0.TechnicalDetail))
			{
				LoggerInitializer.ShowWarning(text, P_1);
			}
			else
			{
				LoggerInitializer.ShowError(text, P_1);
			}
		}
		else
		{
			UiHelperService.ShowToastWarning(text, P_1);
		}
	}

	public static void ShowSyncMessage(string P_0, string P_1 = "Excel同步")
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			UiHelperService.ShowToastInfo(P_0.Trim(), P_1);
		}
	}

	public static void ShowSyncWarning(string P_0, string P_1 = "Excel同步")
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			UiHelperService.ShowToastWarning(P_0.Trim(), P_1);
		}
	}
}
