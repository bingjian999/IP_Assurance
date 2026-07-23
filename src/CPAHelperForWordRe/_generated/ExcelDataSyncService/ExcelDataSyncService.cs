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
		public TableComWriteService.B8Id9rVIwgTW2spgYNvs OQKVbeL2HSs;

		public ProgressWindow s7ZVbyORkkZ;

		public TableComWriteService.ffxcqxVIn1iOgk0nKLUY K2ZVbXqAMC3;

		public Action y2FVbFq16Tg;

		public _G_c__DisplayClass41_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void kDJVb74DwvM()
		{
			wMSXdLtYmv(delegate
			{
				OQKVbeL2HSs = TableComWriteService.XVJ45smyDw((int current, int total, string message) => GQlFRxrmSC(s7ZVbyORkkZ, current, total, message));
			}, "数据同步");
		}

		internal void oNjVb53J1er()
		{
			OQKVbeL2HSs = TableComWriteService.XVJ45smyDw((int current, int total, string message) => GQlFRxrmSC(s7ZVbyORkkZ, current, total, message));
		}

		internal bool zybVbcaYAMP(int current, int total, string message)
		{
			return GQlFRxrmSC(s7ZVbyORkkZ, current, total, message);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass42_0
	{
		public TableComWriteService.B8Id9rVIwgTW2spgYNvs BLYVba1rP6j;

		public _G_c__DisplayClass42_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void AGgVbhfKb0g()
		{
			try
			{
				BLYVba1rP6j = TableComWriteService.VuQ4c2ipxq();
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.ujWsURly3F("[ExcelSync] Context menu locate crashed", ex);
				BLYVba1rP6j = new TableComWriteService.B8Id9rVIwgTW2spgYNvs
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
		public ProgressWindow hcTVbPSNMJ4;

		public _G_c__DisplayClass52_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void aoLVbqcNxWq()
		{
			if (hcTVbPSNMJ4.IsVisible)
			{
				hcTVbPSNMJ4.Close();
			}
		}
	}

	private static readonly string[] swAFBWjhJe;

	private static readonly string[] qLtF9CsScg;

	private static readonly object B8rF6wKW4L;

	private static readonly List<CommandBarButton> Ns7FunudE5;

	private static IRibbonUI WsgFDokEbP;

	private static bool WvWFTkrxt9;

	private static DateTime ugWFgug1Fj;

	[CompilerGenerated]
	private static bool SwjF85yccl;

	public static bool IsLoaded
	{
		[CompilerGenerated]
		get
		{
			return SwjF85yccl;
		}
		[CompilerGenerated]
		private set
		{
			SwjF85yccl = value;
		}
	}

	public static string hlWXMtJ6TA()
	{
		if (IsLoaded)
		{
			YG5XwaPP7m();
			return "已卸载右键菜单。";
		}
		return nQjXbycZ23();
	}

	public static string nQjXbycZ23()
	{
		VvXX7RqLnd();
		if (WordTableToolService.IsWps)
		{
			string result = bmJXClxTxp();
			if (IsLoaded)
			{
				LCjXG6voSH( true);
			}
			CtJXNX8dgh();
			return result;
		}
		IsLoaded = true;
		LCjXG6voSH( true);
		CtJXNX8dgh();
		return "已加载右键菜单。";
	}

	public static void K5NXSH2mgl()
	{
		VvXX7RqLnd();
		IsLoaded = TOlXmIuJyF();
		if (IsLoaded && WordTableToolService.IsWps)
		{
			string text = bmJXClxTxp();
			if (!IsLoaded)
			{
				AiConfigBootstrap.z7Us3dJ6Cl("[ExcelSync] WPS native context menu auto load skipped: " + text);
			}
			CtJXNX8dgh();
		}
		else
		{
			CtJXNX8dgh();
			_ = IsLoaded;
		}
	}

	public static void YG5XwaPP7m()
	{
		IsLoaded = false;
		Ns7FunudE5.Clear();
		VvXX7RqLnd();
		LCjXG6voSH( false);
		CtJXNX8dgh();
	}

	public static void MXSXtSr5ZG()
	{
		IsLoaded = false;
		Ns7FunudE5.Clear();
		VvXX7RqLnd();
		CtJXNX8dgh();
	}

	internal static bool tE8XLlC6V1()
	{
		if (!WordTableToolService.IsWps && IsLoaded)
		{
			return F2EXoDU3KJ();
		}
		return false;
	}

	internal static void vpbXsP8YgS(IRibbonUI P_0)
	{
		if (P_0 != null)
		{
			WsgFDokEbP = P_0;
		}
	}

	internal static void T25Xl7T74U(string P_0)
	{
		if (IsLoaded)
		{
			if (!string.IsNullOrWhiteSpace(P_0) && P_0.IndexOf("Locate", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				qLOXPSqh3g();
			}
			else
			{
				mnnXqR7AH1();
			}
		}
	}

	private static void CtJXNX8dgh()
	{
		try
		{
			WsgFDokEbP?.Invalidate();
		}
		catch
		{
		}
	}

	private static bool TOlXmIuJyF()
	{
		try
		{
			string text = TableBorderConfig.Current.KxPSXHwy4c("Excel同步_右键菜单_自动加载", "false");
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

	private static bool F2EXoDU3KJ()
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

	private static void LCjXG6voSH(bool P_0)
	{
		try
		{
			TableBorderConfig.Current.pE1SyAiPWc("Excel同步_右键菜单_自动加载", P_0 ? "false" : "true");
		}
		catch
		{
		}
	}

	private static string bmJXClxTxp()
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
		bool flag = gJhXFr9Vpr(wordApp);
		Ns7FunudE5.Clear();
		IsLoaded = false;
		int num = 0;
		int num2 = 0;
		string[] array = qLtF9CsScg;
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
				DUEX5Nc0TM(commandBar, true, 0);
				CommandBarButton commandBarButton = thlXpInueV(commandBar, "同步数据", "CPAHelper.ExcelSync.SyncData", true, YPCXOcUbRB);
				CommandBarButton commandBarButton2 = thlXpInueV(commandBar, "定位数据", "CPAHelper.ExcelSync.LocateData", false, EloXnD5Gla);
				if (commandBarButton != null)
				{
					Ns7FunudE5.Add(commandBarButton);
					num2++;
				}
				if (commandBarButton2 != null)
				{
					Ns7FunudE5.Add(commandBarButton2);
					num2++;
				}
				if (commandBarButton != null && commandBarButton2 != null)
				{
					num++;
				}
			}
		}
		tr6Xh0jnAc(wordApp, flag);
		IsLoaded = num > 0;
		if (IsLoaded)
		{
			return "已加载右键菜单。";
		}
		Ns7FunudE5.Clear();
		return "加载右键菜单失败：没有找到可挂载的 WPS 表格右键菜单。";
	}

	private static CommandBarButton thlXpInueV(CommandBar P_0, string P_1, string P_2, bool P_3, _CommandBarButtonEvents_ClickEventHandler P_4)
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

	private static void YPCXOcUbRB(CommandBarButton P_0, ref bool P_1)
	{
		P_1 = true;
		mnnXqR7AH1();
	}

	private static void EloXnD5Gla(CommandBarButton P_0, ref bool P_1)
	{
		P_1 = true;
		qLOXPSqh3g();
	}

	private static void VvXX7RqLnd()
	{
		try
		{
			Application wordApp = WordTableToolService.WordApp;
			bool flag = gJhXFr9Vpr(wordApp);
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
			string[] array = swAFBWjhJe;
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
					num += DUEX5Nc0TM(commandBar, true, 0);
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
					num += DUEX5Nc0TM(commandBar2, false, 0);
				}
			}
			if (num > 0)
			{
				tr6Xh0jnAc(wordApp, flag);
			}
		}
		catch (Exception)
		{
		}
	}

	private static int DUEX5Nc0TM(CommandBar P_0, bool P_1, int P_2)
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
					text2 = P1TXXBYRoN(commandBarControl.Caption);
				}
				catch
				{
				}
				if (OxcXydn466(text, text2, P_1))
				{
					if (bKNXeMPExi(commandBarControl))
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
						num += i6UXcDTry8(commandBarControls2, P_1, P_2 + 1);
					}
				}
			}
		}
		return num;
	}

	private static int i6UXcDTry8(CommandBarControls P_0, bool P_1, int P_2)
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
					text2 = P1TXXBYRoN(commandBarControl.Caption);
				}
				catch
				{
				}
				if (OxcXydn466(text, text2, P_1))
				{
					if (bKNXeMPExi(commandBarControl))
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
						num += i6UXcDTry8(commandBarControls, P_1, P_2 + 1);
					}
				}
			}
		}
		return num;
	}

	private static bool bKNXeMPExi(CommandBarControl P_0)
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

	private static bool OxcXydn466(string P_0, string P_1, bool P_2)
	{
		if (HJeXatF5ua(P_0))
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

	private static string P1TXXBYRoN(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			return P_0.Replace("&", string.Empty).Trim();
		}
		return string.Empty;
	}

	private static bool gJhXFr9Vpr(Application P_0)
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

	private static void tr6Xh0jnAc(Application P_0, bool P_1)
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
			AiConfigBootstrap.z7Us3dJ6Cl("[ExcelSync] Restore NormalTemplate saved state failed: " + ex.Message);
		}
	}

	private static bool HJeXatF5ua(string P_0)
	{
		if (!string.Equals(P_0, "CPAHelper.ExcelSync.SyncData", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(P_0, "CPAHelper.ExcelSync.LocateData", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static void mnnXqR7AH1()
	{
		TKkXkjis2w("同步数据", delegate
		{
			_G_c__DisplayClass41_0 CS_8_locals_17 = new _G_c__DisplayClass41_0();
			CS_8_locals_17.s7ZVbyORkkZ = a9VXzcJTG2("已卸载右键菜单。", "已加载右键菜单。");
			CS_8_locals_17.OQKVbeL2HSs = null;
			try
			{
				HCDXxBpknD(delegate
				{
					wMSXdLtYmv(delegate
					{
						CS_8_locals_17.OQKVbeL2HSs = TableComWriteService.XVJ45smyDw((int current, int total, string message) => GQlFRxrmSC(CS_8_locals_17.s7ZVbyORkkZ, current, total, message));
					}, "[ExcelSync] WPS native context menu auto load skipped: ");
				});
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.ujWsURly3F("Locate", ex);
				CS_8_locals_17.OQKVbeL2HSs = new TableComWriteService.B8Id9rVIwgTW2spgYNvs
				{
					Success = false,
					Message = "Excel同步_右键菜单_自动加载" + ex.Message
				};
			}
			finally
			{
				wZJFVG9n37(CS_8_locals_17.s7ZVbyORkkZ);
			}
			if (CS_8_locals_17.OQKVbeL2HSs != null)
			{
				if (CS_8_locals_17.OQKVbeL2HSs.Success)
				{
					AiConfigBootstrap.swCsJ4IbrL("false" + CS_8_locals_17.OQKVbeL2HSs.Message);
					UiHelperService.SeXce6fgLN(string.IsNullOrWhiteSpace(CS_8_locals_17.OQKVbeL2HSs.Message) ? "Excel同步_右键菜单_自动加载" : CS_8_locals_17.OQKVbeL2HSs.Message, "false");
				}
				else if (CS_8_locals_17.OQKVbeL2HSs.Cancelled)
				{
					UiHelperService.Kn6cyKZe85(string.IsNullOrWhiteSpace(CS_8_locals_17.OQKVbeL2HSs.Message) ? "true" : CS_8_locals_17.OQKVbeL2HSs.Message, "无法获取 WPS 应用对象，右键菜单未加载。");
				}
				else if (!string.IsNullOrWhiteSpace(CS_8_locals_17.OQKVbeL2HSs.Message))
				{
					AiConfigBootstrap.z7Us3dJ6Cl("无法获取 WPS CommandBars，右键菜单未加载。" + CS_8_locals_17.OQKVbeL2HSs.Message);
					UiHelperService.IuZcXy6pki(CS_8_locals_17.OQKVbeL2HSs.Message, "同步数据");
				}
			}
		});
	}

	private static void qLOXPSqh3g()
	{
		TKkXkjis2w("定位数据", delegate
		{
			_G_c__DisplayClass42_0 CS_8_locals_11 = new _G_c__DisplayClass42_0();
			CS_8_locals_11.BLYVba1rP6j = null;
			GxjXAL3yeg(CYGXW3bHvB());
			HCDXxBpknD(delegate
			{
				try
				{
					CS_8_locals_11.BLYVba1rP6j = TableComWriteService.VuQ4c2ipxq();
				}
				catch (Exception ex)
				{
					AiConfigBootstrap.ujWsURly3F("CPAHelper.ExcelSync.SyncData", ex);
					CS_8_locals_11.BLYVba1rP6j = new TableComWriteService.B8Id9rVIwgTW2spgYNvs
					{
						Success = false,
						Message = "定位数据" + ex.Message
					};
				}
			});
			if (CS_8_locals_11.BLYVba1rP6j == null)
			{
				ygcXvh8pOP();
			}
			else if (CS_8_locals_11.BLYVba1rP6j.Success)
			{
				ygcXvh8pOP();
				UiHelperService.SeXce6fgLN(string.IsNullOrWhiteSpace(CS_8_locals_11.BLYVba1rP6j.Message) ? "CPAHelper.ExcelSync.LocateData" : CS_8_locals_11.BLYVba1rP6j.Message, "已加载右键菜单。");
			}
			else if (!string.IsNullOrWhiteSpace(CS_8_locals_11.BLYVba1rP6j.Message))
			{
				GxjXAL3yeg(CS_8_locals_11.BLYVba1rP6j.Message);
				AiConfigBootstrap.z7Us3dJ6Cl("加载右键菜单失败：没有找到可挂载的 WPS 表格右键菜单。" + CS_8_locals_11.BLYVba1rP6j.Message);
				UiHelperService.Kn6cyKZe85(CS_8_locals_11.BLYVba1rP6j.Message, "同步数据");
			}
			else
			{
				ygcXvh8pOP();
			}
		});
	}

	private static void GxjXAL3yeg(string P_0)
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

	private static void ygcXvh8pOP()
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
			GxjXAL3yeg(string.Empty);
		}
	}

	private static string CYGXW3bHvB()
	{
		string text = lwdX09nj1e();
		if (!string.IsNullOrWhiteSpace(text))
		{
			return "正在打开 " + text + " 工作簿并定位源区域...";
		}
		return "正在打开 Excel 工作簿并定位源区域...";
	}

	private static string lwdX09nj1e()
	{
		try
		{
			TableComWriteService.gMo5J5VI9LOS3nqRiEJZ gMo5J5VI9LOS3nqRiEJZ = TableComWriteService.inT4f2XO4S(false, false);
			if (gMo5J5VI9LOS3nqRiEJZ == null || !gMo5J5VI9LOS3nqRiEJZ.HasBinding)
			{
				return string.Empty;
			}
			if (!string.IsNullOrWhiteSpace(gMo5J5VI9LOS3nqRiEJZ.BoundWorkbook))
			{
				return gMo5J5VI9LOS3nqRiEJZ.BoundWorkbook;
			}
			string boundFullPath = gMo5J5VI9LOS3nqRiEJZ.BoundFullPath;
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

	private static void TKkXkjis2w(string P_0, Action P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		P_0 = (string.IsNullOrWhiteSpace(P_0) ? "右键菜单命令" : P_0);
		lock (B8rF6wKW4L)
		{
			DateTime utcNow = DateTime.UtcNow;
			if (WvWFTkrxt9 || utcNow - ugWFgug1Fj < TimeSpan.FromMilliseconds(800.0))
			{
				return;
			}
			WvWFTkrxt9 = true;
		}
		try
		{
			P_1();
		}
		finally
		{
			lock (B8rF6wKW4L)
			{
				ugWFgug1Fj = DateTime.UtcNow;
				WvWFTkrxt9 = false;
			}
		}
	}

	private static void HCDXxBpknD(Action P_0)
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

	private static void wMSXdLtYmv(Action P_0, string P_1)
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
				AiConfigBootstrap.z7Us3dJ6Cl("[ExcelSync] Context menu StartCustomRecord failed: " + ex.Message);
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
					AiConfigBootstrap.z7Us3dJ6Cl("[ExcelSync] Context menu EndCustomRecord failed: " + ex2.Message);
				}
			}
		}
	}

	private static ProgressWindow a9VXzcJTG2(string P_0, string P_1)
	{
		try
		{
			ProgressWindow progressWindow = new ProgressWindow();
			progressWindow.Title = (string.IsNullOrWhiteSpace(P_0) ? "处理中" : P_0);
			progressWindow.SetProgress(0, string.IsNullOrWhiteSpace(P_1) ? "正在处理..." : P_1);
			WordTableToolService5.IPf5i0ZcV4(progressWindow);
			return progressWindow;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static bool GQlFRxrmSC(ProgressWindow P_0, int P_1, int P_2, string P_3)
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

	private static void wZJFVG9n37(ProgressWindow P_0)
	{
		_G_c__DisplayClass52_0 CS_8_locals_8 = new _G_c__DisplayClass52_0();
		CS_8_locals_8.hcTVbPSNMJ4 = P_0;
		if (CS_8_locals_8.hcTVbPSNMJ4 == null)
		{
			return;
		}
		try
		{
			if (CS_8_locals_8.hcTVbPSNMJ4.Dispatcher.CheckAccess())
			{
				if (CS_8_locals_8.hcTVbPSNMJ4.IsVisible)
				{
					CS_8_locals_8.hcTVbPSNMJ4.Close();
				}
				return;
			}
			CS_8_locals_8.hcTVbPSNMJ4.Dispatcher.Invoke(delegate
			{
				if (CS_8_locals_8.hcTVbPSNMJ4.IsVisible)
				{
					CS_8_locals_8.hcTVbPSNMJ4.Close();
				}
			});
		}
		catch
		{
		}
	}

	static ExcelDataSyncService()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		swAFBWjhJe = new string[8]
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
		qLtF9CsScg = new string[6]
		{
			"Table Text",
			"Table Cells",
			"Table",
			"Whole Table",
			"Table Row Popup Menu",
			"Table Column Popup Menu"
		};
		B8rF6wKW4L = new object();
		Ns7FunudE5 = new List<CommandBarButton>();
		ugWFgug1Fj = DateTime.MinValue;
	}
}
