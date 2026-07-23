using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using CPAHelperForWordRe.UI.Forms;
using AiConfigBootstrap;
using TableBorderConfig;
using WordTableToolService5;
using TableComWriteService;
using AiSseStreamService3;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService;
using UiHelperService;

namespace ExcelDataSyncService;

internal static class ExcelDataSyncService
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass41_0
	{
		public TableComWriteService.SyncResult syncResult;

		public ProgressWindow progressWindow;

		public TableComWriteService.ProgressCallback progressCallback;

		public Action action;

		public _G_c__DisplayClass41_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ExecuteSyncWithUndo()
		{
			ExecuteWithUndoRecord(delegate
			{
				syncResult = TableComWriteService.SyncCurrentTable((int current, int total, string message) => UpdateProgress(progressWindow, current, total, message));
			}, "数据同步");
		}

		internal void ExecuteSyncDirect()
		{
			syncResult = TableComWriteService.SyncCurrentTable((int current, int total, string message) => UpdateProgress(progressWindow, current, total, message));
		}

		internal bool ReportProgress(int current, int total, string message)
		{
			return UpdateProgress(progressWindow, current, total, message);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass42_0
	{
		public TableComWriteService.SyncResult syncResult;

		public _G_c__DisplayClass42_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void GetCurrentSyncStatus()
		{
			try
			{
				syncResult = TableComWriteService.GetCurrentTableSyncStatus();
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogError("[ExcelSync] Context menu locate crashed", ex);
				syncResult = new TableComWriteService.SyncResult
				{
					Success = false,
					Message = "定位数据失败：" + ex.Message
				};
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass52_0
	{
		public ProgressWindow progressWindow;

		public _G_c__DisplayClass52_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void CloseWindowIfVisible()
		{
			if (progressWindow.IsVisible)
			{
				progressWindow.Close();
			}
		}
	}

	private static readonly string[] allCommandBarNames;

	private static readonly string[] wpsCommandBarNames;

	private static readonly object commandLock;

	private static readonly List<CommandBarButton> registeredButtons;

	private static IRibbonUI ribbonUI;

	private static bool isCommandExecuting;

	private static DateTime lastCommandUtc;

	[CompilerGenerated]
	private static bool _isLoaded;

	public static bool IsLoaded
	{
		[CompilerGenerated]
		get
		{
			return _isLoaded;
		}
		[CompilerGenerated]
		private set
		{
			_isLoaded = value;
		}
	}

	public static string GetExcelSyncStatus()
	{
		if (IsLoaded)
		{
			UnloadContextMenu();
			return "已卸载右键菜单。";
		}
		return LoadContextMenu();
	}

	public static string LoadContextMenu()
	{
		RemoveAllCustomButtons();
		if (WordTableToolService.IsWps)
		{
			string result = LoadWpsContextMenu();
			if (IsLoaded)
			{
				SetAutoLoadSetting( true);
			}
			InvalidateRibbon();
			return result;
		}
		IsLoaded = true;
		SetAutoLoadSetting( true);
		InvalidateRibbon();
		return "已加载右键菜单。";
	}

	public static void AutoLoadContextMenu()
	{
		RemoveAllCustomButtons();
		IsLoaded = GetAutoLoadSetting();
		if (IsLoaded && WordTableToolService.IsWps)
		{
			string text = LoadWpsContextMenu();
			if (!IsLoaded)
			{
				AiConfigBootstrap.LogWarn("[ExcelSync] WPS native context menu auto load skipped: " + text);
			}
			InvalidateRibbon();
		}
		else
		{
			InvalidateRibbon();
			_ = IsLoaded;
		}
	}

	public static void UnloadContextMenu()
	{
		IsLoaded = false;
		registeredButtons.Clear();
		RemoveAllCustomButtons();
		SetAutoLoadSetting( false);
		InvalidateRibbon();
	}

	public static void ResetContextMenu()
	{
		IsLoaded = false;
		registeredButtons.Clear();
		RemoveAllCustomButtons();
		InvalidateRibbon();
	}

	internal static bool IsContextMenuUsable()
	{
		if (!WordTableToolService.IsWps && IsLoaded)
		{
			return IsSelectionInTable();
		}
		return false;
	}

	internal static void SetRibbonUI(IRibbonUI P_0)
	{
		if (P_0 != null)
		{
			ribbonUI = P_0;
		}
	}

	internal static void HandleContextMenuCallback(string P_0)
	{
		if (IsLoaded)
		{
			if (!string.IsNullOrWhiteSpace(P_0) && P_0.IndexOf("Locate", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				LocateData();
			}
			else
			{
				SyncData();
			}
		}
	}

	private static void InvalidateRibbon()
	{
		try
		{
			ribbonUI?.Invalidate();
		}
		catch
		{
		}
	}

	private static bool GetAutoLoadSetting()
	{
		try
		{
			string text = TableBorderConfig.Current.GetString("Excel同步_右键菜单_自动加载", "false");
			if (bool.TryParse(text, out var result))
			{
				return result;
			}
			if (int.TryParse(text, out var result2))
			{
				return result2 != 0;
			}
		}
		catch
		{
		}
		return false;
	}

	private static bool IsSelectionInTable()
	{
		try
		{
			Selection selection = WordTableToolService.WordApp?.Selection;
			return selection != null && (dynamic)selection.get_Information(WdInformation.wdWithInTable);
		}
		catch
		{
			return false;
		}
	}

	private static void SetAutoLoadSetting(bool P_0)
	{
		try
		{
			TableBorderConfig.Current.SetValue("Excel同步_右键菜单_自动加载", P_0 ? "false" : "true");
		}
		catch
		{
		}
	}

	private static string LoadWpsContextMenu()
	{
		Application wordApp = WordTableToolService.WordApp;
		if (wordApp == null)
		{
			return "无法获取 WPS 应用对象，右键菜单未加载。";
		}
		CommandBars commandBars = null;
		try
		{
			commandBars = wordApp.CommandBars;
		}
		catch
		{
		}
		if (commandBars == null)
		{
			return "无法获取 WPS CommandBars，右键菜单未加载。";
		}
		bool flag = IsNormalTemplateSaved(wordApp);
		registeredButtons.Clear();
		IsLoaded = false;
		int num = 0;
		int num2 = 0;
		string[] array = wpsCommandBarNames;
		foreach (string index in array)
		{
			CommandBar commandBar = null;
			try
			{
				commandBar = commandBars[index];
			}
			catch
			{
			}
			if (commandBar != null)
			{
				RemoveMatchingControlsFromBar(commandBar, true, 0);
				CommandBarButton commandBarButton = CreateCommandBarButton(commandBar, "同步数据", "CPAHelper.ExcelSync.SyncData", true, OnSyncDataClick);
				CommandBarButton commandBarButton2 = CreateCommandBarButton(commandBar, "定位数据", "CPAHelper.ExcelSync.LocateData", false, OnLocateDataClick);
				if (commandBarButton != null)
				{
					registeredButtons.Add(commandBarButton);
					num2++;
				}
				if (commandBarButton2 != null)
				{
					registeredButtons.Add(commandBarButton2);
					num2++;
				}
				if (commandBarButton != null && commandBarButton2 != null)
				{
					num++;
				}
			}
		}
		RestoreNormalTemplateSaved(wordApp, flag);
		IsLoaded = num > 0;
		if (IsLoaded)
		{
			return "已加载右键菜单。";
		}
		registeredButtons.Clear();
		return "加载右键菜单失败：没有找到可挂载的 WPS 表格右键菜单。";
	}

	private static CommandBarButton CreateCommandBarButton(CommandBar P_0, string P_1, string P_2, bool P_3, _CommandBarButtonEvents_ClickEventHandler P_4)
	{
		try
		{
			if (!(P_0.Controls.Add(MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true) is CommandBarButton commandBarButton))
			{
				return null;
			}
			commandBarButton.Caption = P_1;
			commandBarButton.Tag = P_2;
			commandBarButton.BeginGroup = P_3;
			commandBarButton.Style = MsoButtonStyle.msoButtonCaption;
			commandBarButton.Visible = true;
			commandBarButton.Enabled = true;
			commandBarButton.Click += P_4;
			return commandBarButton;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static void OnSyncDataClick(CommandBarButton P_0, ref bool P_1)
	{
		P_1 = true;
		SyncData();
	}

	private static void OnLocateDataClick(CommandBarButton P_0, ref bool P_1)
	{
		P_1 = true;
		LocateData();
	}

	private static void RemoveAllCustomButtons()
	{
		try
		{
			Application wordApp = WordTableToolService.WordApp;
			bool flag = IsNormalTemplateSaved(wordApp);
			CommandBars commandBars = null;
			try
			{
				commandBars = wordApp?.CommandBars;
			}
			catch
			{
			}
			if (commandBars == null)
			{
				return;
			}
			int num = 0;
			string[] array = allCommandBarNames;
			foreach (string index in array)
			{
				CommandBar commandBar = null;
				try
				{
					commandBar = commandBars[index];
				}
				catch
				{
				}
				if (commandBar != null)
				{
					num += RemoveMatchingControlsFromBar(commandBar, true, 0);
				}
			}
			for (int num2 = commandBars.Count; num2 >= 1; num2--)
			{
				CommandBar commandBar2 = null;
				try
				{
					commandBar2 = commandBars[num2];
				}
				catch
				{
				}
				if (commandBar2 != null)
				{
					num += RemoveMatchingControlsFromBar(commandBar2, false, 0);
				}
			}
			if (num > 0)
			{
				RestoreNormalTemplateSaved(wordApp, flag);
			}
		}
		catch (Exception)
		{
		}
	}

	private static int RemoveMatchingControlsFromBar(CommandBar P_0, bool P_1, int P_2)
	{
		if (P_0 == null || P_2 > 8)
		{
			return 0;
		}
		CommandBarControls commandBarControls = null;
		try
		{
			commandBarControls = P_0?.Controls;
		}
		catch
		{
		}
		if (commandBarControls == null)
		{
			return 0;
		}
		int num = 0;
		int num2 = 0;
		try
		{
			num2 = commandBarControls.Count;
		}
		catch
		{
		}
		for (int num3 = num2; num3 >= 1; num3--)
		{
			CommandBarControl commandBarControl = null;
			try
			{
				commandBarControl = commandBarControls[num3];
			}
			catch
			{
			}
			if (commandBarControl != null)
			{
				string text = string.Empty;
				try
				{
					text = commandBarControl.Tag ?? string.Empty;
				}
				catch
				{
				}
				string text2 = string.Empty;
				try
				{
					text2 = NormalizeCaption(commandBarControl.Caption);
				}
				catch
				{
				}
				if (ShouldRemoveControl(text, text2, P_1))
				{
					if (TryDeleteControl(commandBarControl))
					{
						num++;
					}
				}
				else if (commandBarControl is CommandBarPopup commandBarPopup)
				{
					CommandBarControls commandBarControls2 = null;
					try
					{
						commandBarControls2 = commandBarPopup.Controls;
					}
					catch
					{
					}
					if (commandBarControls2 != null)
					{
						num += RemoveMatchingControlsFromPopup(commandBarControls2, P_1, P_2 + 1);
					}
				}
			}
		}
		return num;
	}

	private static int RemoveMatchingControlsFromPopup(CommandBarControls P_0, bool P_1, int P_2)
	{
		if (P_0 == null || P_2 > 8)
		{
			return 0;
		}
		int num = 0;
		int num2 = 0;
		try
		{
			num2 = P_0.Count;
		}
		catch
		{
		}
		for (int num3 = num2; num3 >= 1; num3--)
		{
			CommandBarControl commandBarControl = null;
			try
			{
				commandBarControl = P_0[num3];
			}
			catch
			{
			}
			if (commandBarControl != null)
			{
				string text = string.Empty;
				try
				{
					text = commandBarControl.Tag ?? string.Empty;
				}
				catch
				{
				}
				string text2 = string.Empty;
				try
				{
					text2 = NormalizeCaption(commandBarControl.Caption);
				}
				catch
				{
				}
				if (ShouldRemoveControl(text, text2, P_1))
				{
					if (TryDeleteControl(commandBarControl))
					{
						num++;
					}
				}
				else if (commandBarControl is CommandBarPopup commandBarPopup)
				{
					CommandBarControls commandBarControls = null;
					try
					{
						commandBarControls = commandBarPopup.Controls;
					}
					catch
					{
					}
					if (commandBarControls != null)
					{
						num += RemoveMatchingControlsFromPopup(commandBarControls, P_1, P_2 + 1);
					}
				}
			}
		}
		return num;
	}

	private static bool TryDeleteControl(CommandBarControl P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		try
		{
			P_0.Delete(false);
			return true;
		}
		catch
		{
		}
		try
		{
			P_0.Delete(true);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static bool ShouldRemoveControl(string P_0, string P_1, bool P_2)
	{
		if (IsOurCustomButton(P_0))
		{
			return true;
		}
		if (!P_2)
		{
			return false;
		}
		if (!string.Equals(P_1, "同步数据", StringComparison.Ordinal))
		{
			return string.Equals(P_1, "定位数据", StringComparison.Ordinal);
		}
		return true;
	}

	private static string NormalizeCaption(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			return P_0.Replace("&", string.Empty).Trim();
		}
		return string.Empty;
	}

	private static bool IsNormalTemplateSaved(Application P_0)
	{
		try
		{
			return P_0?.NormalTemplate == null || P_0.NormalTemplate.Saved;
		}
		catch
		{
			return false;
		}
	}

	private static void RestoreNormalTemplateSaved(Application P_0, bool P_1)
	{
		if (!P_1)
		{
			return;
		}
		try
		{
			if (P_0?.NormalTemplate != null)
			{
				P_0.NormalTemplate.Saved = true;
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[ExcelSync] Restore NormalTemplate saved state failed: " + ex.Message);
		}
	}

	private static bool IsOurCustomButton(string P_0)
	{
		if (!string.Equals(P_0, "CPAHelper.ExcelSync.SyncData", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(P_0, "CPAHelper.ExcelSync.LocateData", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static void SyncData()
	{
		ExecuteWithThrottle("同步数据", delegate
		{
			_G_c__DisplayClass41_0 CS_8_locals_17 = new _G_c__DisplayClass41_0();
			CS_8_locals_17.progressWindow = CreateProgressWindow("已卸载右键菜单。", "已加载右键菜单。");
			CS_8_locals_17.syncResult = null;
			try
			{
				SuppressAlertsAndExecute(delegate
				{
					ExecuteWithUndoRecord(delegate
					{
						CS_8_locals_17.syncResult = TableComWriteService.SyncCurrentTable((int current, int total, string message) => UpdateProgress(CS_8_locals_17.progressWindow, current, total, message));
					}, "[ExcelSync] WPS native context menu auto load skipped: ");
				});
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogError("Locate", ex);
				CS_8_locals_17.syncResult = new TableComWriteService.SyncResult
				{
					Success = false,
					Message = "Excel同步_右键菜单_自动加载" + ex.Message
				};
			}
			finally
			{
				CloseProgressWindow(CS_8_locals_17.progressWindow);
			}
			if (CS_8_locals_17.syncResult != null)
			{
				if (CS_8_locals_17.syncResult.Success)
				{
					AiConfigBootstrap.LogInfo("false" + CS_8_locals_17.syncResult.Message);
					UiHelperService.ShowToastInfo(string.IsNullOrWhiteSpace(CS_8_locals_17.syncResult.Message) ? "Excel同步_右键菜单_自动加载" : CS_8_locals_17.syncResult.Message, "false");
				}
				else if (CS_8_locals_17.syncResult.Cancelled)
				{
					UiHelperService.ShowToastWarning(string.IsNullOrWhiteSpace(CS_8_locals_17.syncResult.Message) ? "true" : CS_8_locals_17.syncResult.Message, "无法获取 WPS 应用对象，右键菜单未加载。");
				}
				else if (!string.IsNullOrWhiteSpace(CS_8_locals_17.syncResult.Message))
				{
					AiConfigBootstrap.LogWarn("无法获取 WPS CommandBars，右键菜单未加载。" + CS_8_locals_17.syncResult.Message);
					UiHelperService.ShowToastError(CS_8_locals_17.syncResult.Message, "同步数据");
				}
			}
		});
	}

	private static void LocateData()
	{
		ExecuteWithThrottle("定位数据", delegate
		{
			_G_c__DisplayClass42_0 CS_8_locals_11 = new _G_c__DisplayClass42_0();
			CS_8_locals_11.syncResult = null;
			SetStatusBar(GetLocatingStatusMessage());
			SuppressAlertsAndExecute(delegate
			{
				try
				{
					CS_8_locals_11.syncResult = TableComWriteService.GetCurrentTableSyncStatus();
				}
				catch (Exception ex)
				{
					AiConfigBootstrap.LogError("CPAHelper.ExcelSync.SyncData", ex);
					CS_8_locals_11.syncResult = new TableComWriteService.SyncResult
					{
						Success = false,
						Message = "定位数据" + ex.Message
					};
				}
			});
			if (CS_8_locals_11.syncResult == null)
			{
				ClearStatusBar();
			}
			else if (CS_8_locals_11.syncResult.Success)
			{
				ClearStatusBar();
				UiHelperService.ShowToastInfo(string.IsNullOrWhiteSpace(CS_8_locals_11.syncResult.Message) ? "CPAHelper.ExcelSync.LocateData" : CS_8_locals_11.syncResult.Message, "已加载右键菜单。");
			}
			else if (!string.IsNullOrWhiteSpace(CS_8_locals_11.syncResult.Message))
			{
				SetStatusBar(CS_8_locals_11.syncResult.Message);
				AiConfigBootstrap.LogWarn("加载右键菜单失败：没有找到可挂载的 WPS 表格右键菜单。" + CS_8_locals_11.syncResult.Message);
				UiHelperService.ShowToastWarning(CS_8_locals_11.syncResult.Message, "同步数据");
			}
			else
			{
				ClearStatusBar();
			}
		});
	}

	private static void SetStatusBar(string P_0)
	{
		try
		{
			Application wordApp = WordTableToolService.WordApp;
			if (wordApp != null)
			{
				wordApp.StatusBar = (string.IsNullOrWhiteSpace(P_0) ? string.Empty : P_0);
			}
		}
		catch
		{
		}
	}

	private static void ClearStatusBar()
	{
		try
		{
			Application wordApp = WordTableToolService.WordApp;
			if (wordApp != null)
			{
				wordApp.StatusBar = string.Empty;
			}
		}
		catch
		{
			SetStatusBar(string.Empty);
		}
	}

	private static string GetLocatingStatusMessage()
	{
		string text = GetBoundWorkbookName();
		if (!string.IsNullOrWhiteSpace(text))
		{
			return "正在打开 " + text + " 工作簿并定位源区域...";
		}
		return "正在打开 Excel 工作簿并定位源区域...";
	}

	private static string GetBoundWorkbookName()
	{
		try
		{
			TableComWriteService.TableSyncStatus TableSyncStatus = TableComWriteService.GetTableSyncStatus(false, false);
			if (TableSyncStatus == null || !TableSyncStatus.HasBinding)
			{
				return string.Empty;
			}
			if (!string.IsNullOrWhiteSpace(TableSyncStatus.BoundWorkbook))
			{
				return TableSyncStatus.BoundWorkbook;
			}
			string boundFullPath = TableSyncStatus.BoundFullPath;
			if (!string.IsNullOrWhiteSpace(boundFullPath))
			{
				return Path.GetFileName(boundFullPath);
			}
		}
		catch
		{
		}
		return string.Empty;
	}

	private static void ExecuteWithThrottle(string P_0, Action P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		P_0 = (string.IsNullOrWhiteSpace(P_0) ? "右键菜单命令" : P_0);
		lock (commandLock)
		{
			DateTime utcNow = DateTime.UtcNow;
			if (isCommandExecuting || utcNow - lastCommandUtc < TimeSpan.FromMilliseconds(800.0))
			{
				return;
			}
			isCommandExecuting = true;
		}
		try
		{
			P_1();
		}
		finally
		{
			lock (commandLock)
			{
				lastCommandUtc = DateTime.UtcNow;
				isCommandExecuting = false;
			}
		}
	}

	private static void SuppressAlertsAndExecute(Action P_0)
	{
		Application wordApp = WordTableToolService.WordApp;
		bool? flag = null;
		WdAlertLevel? wdAlertLevel = null;
		try
		{
			if (wordApp != null)
			{
				try
				{
					flag = wordApp.ScreenUpdating;
					wordApp.ScreenUpdating = false;
				}
				catch
				{
				}
				try
				{
					wdAlertLevel = wordApp.DisplayAlerts;
					wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
				}
				catch
				{
				}
			}
			P_0();
		}
		finally
		{
			if (wordApp != null)
			{
				if (wdAlertLevel.HasValue)
				{
					try
					{
						wordApp.DisplayAlerts = wdAlertLevel.Value;
					}
					catch
					{
					}
				}
				if (flag.HasValue)
				{
					try
					{
						wordApp.ScreenUpdating = flag.Value;
					}
					catch
					{
					}
				}
			}
		}
	}

	private static void ExecuteWithUndoRecord(Action P_0, string P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		Application wordApp = WordTableToolService.WordApp;
		if (wordApp == null)
		{
			P_0();
			return;
		}
		bool flag = false;
		try
		{
			try
			{
				wordApp.UndoRecord.StartCustomRecord(string.IsNullOrWhiteSpace(P_1) ? "Excel同步" : P_1);
				flag = true;
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogWarn("[ExcelSync] Context menu StartCustomRecord failed: " + ex.Message);
			}
			P_0();
		}
		finally
		{
			if (flag)
			{
				try
				{
					wordApp.UndoRecord.EndCustomRecord();
				}
				catch (Exception ex2)
				{
					AiConfigBootstrap.LogWarn("[ExcelSync] Context menu EndCustomRecord failed: " + ex2.Message);
				}
			}
		}
	}

	private static ProgressWindow CreateProgressWindow(string P_0, string P_1)
	{
		try
		{
			ProgressWindow progressWindow = new ProgressWindow();
			progressWindow.Title = (string.IsNullOrWhiteSpace(P_0) ? "处理中" : P_0);
			progressWindow.SetProgress(0, string.IsNullOrWhiteSpace(P_1) ? "正在处理..." : P_1);
			WordTableToolService5.ShowWpfWindow(progressWindow);
			return progressWindow;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static bool UpdateProgress(ProgressWindow P_0, int P_1, int P_2, string P_3)
	{
		if (P_0 == null)
		{
			return true;
		}
		try
		{
			if (!P_0.IsVisible || P_0.IsCancelRequested)
			{
				return false;
			}
			int percent = ((P_2 <= 0) ? 100 : ((int)Math.Round((double)P_1 * 100.0 / (double)P_2)));
			P_0.SetProgress(percent, string.IsNullOrWhiteSpace(P_3) ? "正在处理..." : P_3);
			P_0.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
			return P_0.IsVisible && !P_0.IsCancelRequested;
		}
		catch (Exception)
		{
			return true;
		}
	}

	private static void CloseProgressWindow(ProgressWindow P_0)
	{
		_G_c__DisplayClass52_0 CS_8_locals_8 = new _G_c__DisplayClass52_0();
		CS_8_locals_8.progressWindow = P_0;
		if (CS_8_locals_8.progressWindow == null)
		{
			return;
		}
		try
		{
			if (CS_8_locals_8.progressWindow.Dispatcher.CheckAccess())
			{
				if (CS_8_locals_8.progressWindow.IsVisible)
				{
					CS_8_locals_8.progressWindow.Close();
				}
				return;
			}
			CS_8_locals_8.progressWindow.Dispatcher.Invoke(delegate
			{
				if (CS_8_locals_8.progressWindow.IsVisible)
				{
					CS_8_locals_8.progressWindow.Close();
				}
			});
		}
		catch
		{
		}
	}

	static ExcelDataSyncService()
	{
		SseStreamInitializer.InitializeRuntime();
		allCommandBarNames = new string[8]
		{
			"Text",
			"Table Text",
			"Table Cells",
			"Table",
			"Table Whole",
			"Whole Table",
			"Table Row Popup Menu",
			"Table Column Popup Menu"
		};
		wpsCommandBarNames = new string[6]
		{
			"Table Text",
			"Table Cells",
			"Table",
			"Whole Table",
			"Table Row Popup Menu",
			"Table Column Popup Menu"
		};
		commandLock = new object();
		registeredButtons = new List<CommandBarButton>();
		lastCommandUtc = DateTime.MinValue;
	}
}
