using System;
using System.Diagnostics;
using AiConfigBootstrap;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using WordTableToolService;
using LoggerInitializer;

namespace AiHelper_7;

internal static class AiHelper_7
{
	private static int _undoDepth;

	public static void RunCommand(Action P_0, string P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		try
		{
			AiConfigBootstrap.LogInfo("[Command] Begin: " + P_1);
			P_0();
			AiConfigBootstrap.LogInfo("[Command] End: " + P_1);
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[Command] " + P_1 + " failed", ex);
			LoggerInitializer.ShowError(P_1 + " 执行失败：\r\n" + ex.Message, "IP_Assurance");
		}
		finally
		{
			CleanupAfterCommand();
		}
	}

	public static void RunCommandWithUndo(Action P_0, string P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		Application wordApp = WordTableToolService.WordApp;
		if (wordApp == null)
		{
			RunCommand(P_0, P_1);
			return;
		}
		try
		{
			AiConfigBootstrap.LogInfo("[Command] Begin (undo): " + P_1);
			ExecuteWithUndoRecord(wordApp, P_0, P_1);
			AiConfigBootstrap.LogInfo("[Command] End (undo): " + P_1);
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[Command] " + P_1 + " failed", ex);
			LoggerInitializer.ShowError(P_1 + " 执行失败：\r\n" + ex.Message, "IP_Assurance");
		}
		finally
		{
			CleanupAfterCommand();
		}
	}

	private static void ExecuteWithUndoRecord(Application P_0, Action P_1, string P_2)
	{
		if (_undoDepth > 0)
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
				_undoDepth++;
				flag = true;
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogWarn("[Undo] StartCustomRecord failed for " + P_2 + ": " + ex.Message);
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
					AiConfigBootstrap.LogWarn("[Undo] EndCustomRecord failed for " + P_2 + ": " + ex2.Message);
				}
				finally
				{
					_undoDepth = Math.Max(0, _undoDepth - 1);
				}
			}
		}
	}

	[Conditional("DEBUG")]
	private static void DebugTrace(string P_0, string P_1)
	{
	}

	private static void CleanupAfterCommand()
	{
		try
		{
			Application wordApp = WordTableToolService.WordApp;
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
