using System;
using System.Diagnostics;
using dL7TFPsQbAGqPywtHUK;
using hJKpQrVSwRwMyI2RyDQN;
using Microsoft.Office.Interop.Word;
using sNVQvmsNbF4pw13wHyu;
using YNri0QclKMfRh2PQoZV;

namespace w5Oql9FwFDU9FYHJXvj;

internal static class okTG2rFSnxjcTsuMG3L
{
	private static int SjxFmtrD1T;

	public static void iHUFttreO8(Action P_0, string P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		try
		{
			yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[Command] Begin: " + P_1);
			P_0();
			yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[Command] End: " + P_1);
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[Command] " + P_1 + " failed", ex);
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8(P_1 + " 执行失败：\r\n" + ex.Message, "IP_Assurance");
		}
		finally
		{
			b1BFNiPd8M();
		}
	}

	public static void sY9FLcxGhc(Action P_0, string P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		Application wordApp = eSfxffslhXbaGAjFNv1.WordApp;
		if (wordApp == null)
		{
			iHUFttreO8(P_0, P_1);
			return;
		}
		try
		{
			yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[Command] Begin (undo): " + P_1);
			YJ6FsYeGU1(wordApp, P_0, P_1);
			yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[Command] End (undo): " + P_1);
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[Command] " + P_1 + " failed", ex);
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8(P_1 + " 执行失败：\r\n" + ex.Message, "IP_Assurance");
		}
		finally
		{
			b1BFNiPd8M();
		}
	}

	private static void YJ6FsYeGU1(Application P_0, Action P_1, string P_2)
	{
		if (SjxFmtrD1T > 0)
		{
			P_1();
			return;
		}
		bool flag = false;
		try
		{
			try
			{
				P_0.UndoRecord.StartCustomRecord(P_2);
				SjxFmtrD1T++;
				flag = true;
			}
			catch (Exception ex)
			{
				yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[Undo] StartCustomRecord failed for " + P_2 + ": " + ex.Message);
			}
			P_1();
		}
		finally
		{
			if (flag)
			{
				try
				{
					P_0.UndoRecord.EndCustomRecord();
				}
				catch (Exception ex2)
				{
					yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[Undo] EndCustomRecord failed for " + P_2 + ": " + ex2.Message);
				}
				finally
				{
					SjxFmtrD1T = Math.Max(0, SjxFmtrD1T - 1);
				}
			}
		}
	}

	[Conditional("DEBUG")]
	private static void wjQFlQL3wU(string P_0, string P_1)
	{
	}

	private static void b1BFNiPd8M()
	{
		try
		{
			Application wordApp = eSfxffslhXbaGAjFNv1.WordApp;
			if (wordApp != null)
			{
				wordApp.ScreenUpdating = true;
				try
				{
					wordApp.DisplayAlerts = WdAlertLevel.wdAlertsAll;
					return;
				}
				catch
				{
					return;
				}
			}
		}
		catch
		{
		}
	}
}
