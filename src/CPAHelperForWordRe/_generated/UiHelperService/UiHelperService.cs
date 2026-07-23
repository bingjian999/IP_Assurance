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
		public string message;

		public string title;

		public ToolTipIcon toolTipIcon;

		public Icon icon;

		public int timeout;

		public _G_c__DisplayClass9_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ShowToastCallback(object _)
		{
			ShowToastInternal(message, title, toolTipIcon, icon, timeout);
		}
	}

	private static readonly object _toastLock;

	private static NotifyIcon _notifyIcon;

	public static void ShowToastInfo(string P_0, string P_1 = "IP_Assurance", int P_2 = 3000)
	{
		ShowToast(P_0, P_1, ToolTipIcon.Info, SystemIcons.Information, P_2);
	}

	public static void ShowToastWarning(string P_0, string P_1 = "IP_Assurance", int P_2 = 3000)
	{
		ShowToast(P_0, P_1, ToolTipIcon.Warning, SystemIcons.Warning, P_2);
	}

	public static void ShowToastError(string P_0, string P_1 = "IP_Assurance", int P_2 = 3000)
	{
		ShowToast(P_0, P_1, ToolTipIcon.Error, SystemIcons.Error, P_2);
	}

	public static void DisposeNotifyIcon()
	{
		lock (_toastLock)
		{
			try
			{
				if (_notifyIcon != null)
				{
					_notifyIcon.Visible = false;
					_notifyIcon.Dispose();
					_notifyIcon = null;
				}
			}
			catch
			{
			}
		}
	}

	private static void ShowToast(string P_0, string P_1, ToolTipIcon P_2, Icon P_3, int P_4)
	{
		_G_c__DisplayClass9_0 CS_8_locals_16 = new _G_c__DisplayClass9_0();
		CS_8_locals_16.message = P_0;
		CS_8_locals_16.title = P_1;
		CS_8_locals_16.toolTipIcon = P_2;
		CS_8_locals_16.icon = P_3;
		CS_8_locals_16.timeout = P_4;
		if (string.IsNullOrWhiteSpace(CS_8_locals_16.message))
		{
			return;
		}
		SynchronizationContext syncContext = WordTableToolService.SyncContext;
		if (syncContext != null && SynchronizationContext.Current != syncContext)
		{
			syncContext.Post(delegate
			{
				ShowToastInternal(CS_8_locals_16.message, CS_8_locals_16.title, CS_8_locals_16.toolTipIcon, CS_8_locals_16.icon, CS_8_locals_16.timeout);
			}, null);
		}
		else
		{
			ShowToastInternal(CS_8_locals_16.message, CS_8_locals_16.title, CS_8_locals_16.toolTipIcon, CS_8_locals_16.icon, CS_8_locals_16.timeout);
		}
	}

	private static void ShowToastInternal(string P_0, string P_1, ToolTipIcon P_2, Icon P_3, int P_4)
	{
		try
		{
			lock (_toastLock)
			{
				EnsureNotifyIcon();
				_notifyIcon.Icon = P_3 ?? SystemIcons.Information;
				_notifyIcon.BalloonTipTitle = NormalizeTitle(P_1);
				_notifyIcon.BalloonTipText = NormalizeText(P_0);
				_notifyIcon.BalloonTipIcon = P_2;
				_notifyIcon.ShowBalloonTip(Math.Max(1000, P_4));
			}
		}
		catch (Exception)
		{
		}
	}

	private static void EnsureNotifyIcon()
	{
		if (_notifyIcon == null)
		{
			_notifyIcon = new NotifyIcon
			{
				Icon = SystemIcons.Information,
				Text = "IP_Assurance",
				Visible = true
			};
		}
	}

	private static string NormalizeTitle(string P_0)
	{
		string text = (string.IsNullOrWhiteSpace(P_0) ? "IP_Assurance" : P_0.Trim());
		if (text.Length > 63)
		{
			return text.Substring(0, 60) + "...";
		}
		return text;
	}

	private static string NormalizeText(string P_0)
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
		SseStreamInitializer.InitializeRuntime();
		_toastLock = new object();
	}
}
