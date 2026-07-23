using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using AiSseStreamService3;
using SseStreamInitializer;
using WordTableToolService;

namespace UiHelperService;

internal static class UiHelperService
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass9_0
	{
		public string I6qVZH05DbW;

		public string JQQVZQ5OXNq;

		public ToolTipIcon WIoVZ1mLL3v;

		public Icon KKTVZrAlEHg;

		public int bLIVZJQZUYn;

		public _G_c__DisplayClass9_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void GbeVZixvIAd(object _)
		{
			TDwcaL4GpW(I6qVZH05DbW, JQQVZQ5OXNq, WIoVZ1mLL3v, KKTVZrAlEHg, bLIVZJQZUYn);
		}
	}

	private static readonly object duScvvFykF;

	private static NotifyIcon LBScW5bBBr;

	public static void SeXce6fgLN(string P_0, string P_1 = "IP_Assurance", int P_2 = 3000)
	{
		DjUchP5iGm(P_0, P_1, ToolTipIcon.Info, SystemIcons.Information, P_2);
	}

	public static void Kn6cyKZe85(string P_0, string P_1 = "IP_Assurance", int P_2 = 3000)
	{
		DjUchP5iGm(P_0, P_1, ToolTipIcon.Warning, SystemIcons.Warning, P_2);
	}

	public static void IuZcXy6pki(string P_0, string P_1 = "IP_Assurance", int P_2 = 3000)
	{
		DjUchP5iGm(P_0, P_1, ToolTipIcon.Error, SystemIcons.Error, P_2);
	}

	public static void OpbcFWIPED()
	{
		lock (duScvvFykF)
		{
			try
			{
				if (LBScW5bBBr != null)
				{
					LBScW5bBBr.Visible = false;
					LBScW5bBBr.Dispose();
					LBScW5bBBr = null;
				}
			}
			catch
			{
			}
		}
	}

	private static void DjUchP5iGm(string P_0, string P_1, ToolTipIcon P_2, Icon P_3, int P_4)
	{
		_G_c__DisplayClass9_0 CS_8_locals_16 = new _G_c__DisplayClass9_0();
		CS_8_locals_16.I6qVZH05DbW = P_0;
		CS_8_locals_16.JQQVZQ5OXNq = P_1;
		CS_8_locals_16.WIoVZ1mLL3v = P_2;
		CS_8_locals_16.KKTVZrAlEHg = P_3;
		CS_8_locals_16.bLIVZJQZUYn = P_4;
		if (string.IsNullOrWhiteSpace(CS_8_locals_16.I6qVZH05DbW))
		{
			return;
		}
		SynchronizationContext syncContext = WordTableToolService.SyncContext;
		if (syncContext != null && SynchronizationContext.Current != syncContext)
		{
			syncContext.Post(delegate
			{
				TDwcaL4GpW(CS_8_locals_16.I6qVZH05DbW, CS_8_locals_16.JQQVZQ5OXNq, CS_8_locals_16.WIoVZ1mLL3v, CS_8_locals_16.KKTVZrAlEHg, CS_8_locals_16.bLIVZJQZUYn);
			}, null);
		}
		else
		{
			TDwcaL4GpW(CS_8_locals_16.I6qVZH05DbW, CS_8_locals_16.JQQVZQ5OXNq, CS_8_locals_16.WIoVZ1mLL3v, CS_8_locals_16.KKTVZrAlEHg, CS_8_locals_16.bLIVZJQZUYn);
		}
	}

	private static void TDwcaL4GpW(string P_0, string P_1, ToolTipIcon P_2, Icon P_3, int P_4)
	{
		try
		{
			lock (duScvvFykF)
			{
				H8ecqfY1J1();
				LBScW5bBBr.Icon = P_3 ?? SystemIcons.Information;
				LBScW5bBBr.BalloonTipTitle = MGLcPCf5Bh(P_1);
				LBScW5bBBr.BalloonTipText = af1cALIZnk(P_0);
				LBScW5bBBr.BalloonTipIcon = P_2;
				LBScW5bBBr.ShowBalloonTip(Math.Max(1000, P_4));
			}
		}
		catch (Exception)
		{
		}
	}

	private static void H8ecqfY1J1()
	{
		if (LBScW5bBBr == null)
		{
			LBScW5bBBr = new NotifyIcon
			{
				Icon = SystemIcons.Information,
				Text = "IP_Assurance",
				Visible = true
			};
		}
	}

	private static string MGLcPCf5Bh(string P_0)
	{
		string text = (string.IsNullOrWhiteSpace(P_0) ? "IP_Assurance" : P_0.Trim());
		if (text.Length > 63)
		{
			return text.Substring(0, 60) + "...";
		}
		return text;
	}

	private static string af1cALIZnk(string P_0)
	{
		string text = P_0.Trim();
		if (text.Length > 180)
		{
			return text.Substring(0, 177) + "...";
		}
		return text;
	}

	static UiHelperService()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		duScvvFykF = new object();
	}
}
