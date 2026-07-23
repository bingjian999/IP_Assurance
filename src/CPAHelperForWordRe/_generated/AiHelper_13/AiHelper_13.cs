using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AiConfigBootstrap;
using TableBorderConfig;
using AiSseStreamService3;
using ScreenshotCaptureHelper2;
using UiHelperService3;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using AiHelper_10;
using WordTableToolService;
using AiHelper_12;
using UiHelper_1;
using Helper_5;

namespace AiHelper_13;

internal static class AiHelper_13
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_0
	{
		public Rectangle _parentBounds;

		public long _maxArea;

		public Helper_5 helper_5;

		public _G_c__DisplayClass30_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool EvaluateChildWindow(IntPtr child, IntPtr _)
		{
			try
			{
				if (!ScreenshotCaptureHelper2.IsWindowVisible(child))
				{
					return true;
				}
				if (!ScreenshotCaptureHelper2.GetWindowRect(child, out var windowRect))
				{
					return true;
				}
				Rectangle rectangle = Rectangle.FromLTRB(windowRect.Left, windowRect.Top, windowRect.Right, windowRect.Bottom);
				if (rectangle.Width < _parentBounds.Width / 3 || rectangle.Height < _parentBounds.Height / 4)
				{
					return true;
				}
				if (rectangle.Top < _parentBounds.Top + 80 || rectangle.Bottom > _parentBounds.Bottom + 8)
				{
					return true;
				}
				string text = GetWindowClassName(child);
				if (!text.StartsWith("_Ww", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
				if (!TryGetWindowInfo(child, out var windowInfo))
				{
					return true;
				}
				long num = (long)rectangle.Width * (long)rectangle.Height;
				num = ((!text.StartsWith("_WwG", StringComparison.OrdinalIgnoreCase)) ? (num * 4) : (num * 10));
				if (num > _maxArea)
				{
					_maxArea = num;
					helper_5 = windowInfo;
				}
			}
			catch
			{
			}
			return true;
		}
	}

	private static readonly Timer _refreshTimer;

	private static bool _eventsHooked;

	private static bool _isActive;

	private static UiHelperService3 ConfigLoader;

	private static string _lastDocumentSignature;

	private static Rectangle _lastOverlayBounds;

	private static IntPtr _lastOwnerHwnd;

	private static IntPtr _trackedHwnd;

	private static IntPtr _lastInnerHwnd;

	private static Rectangle _lastClientBounds;

	private static Microsoft.Office.Interop.Word.Application App => WordTableToolService.WordApp;

	public static bool IsActive => _isActive;

	public static void Enable()
	{
		if (App != null)
		{
			_isActive = true;
			HookEvents();
			EnsureConfigLoader();
			RefreshTabs();
			UpdateOverlay();
			_refreshTimer.Start();
			TableBorderConfig.Instance.UpdateConfig(delegate(AiHelper_12 c)
			{
				c.OfficeTab.Enabled = true;
			});
			UpdateRibbonState();
		}
	}

	public static void Disable()
	{
		_isActive = false;
		_refreshTimer.Stop();
		ConfigLoader?.LoadConfig();
		ClearOverlayState();
		TableBorderConfig.Instance.UpdateConfig(delegate(AiHelper_12 c)
		{
			c.OfficeTab.Enabled = false;
		});
		UpdateRibbonState();
	}

	public static void Toggle()
	{
		if (IsActive)
		{
			Disable();
		}
		else
		{
			Enable();
		}
	}

	public static void Shutdown()
	{
		_isActive = false;
		_refreshTimer.Stop();
		UnhookEvents();
		ClearOverlayState();
		if (ConfigLoader != null)
		{
			ConfigLoader.Close();
		}
		ConfigLoader = null;
		_lastOverlayBounds = Rectangle.Empty;
		_lastOwnerHwnd = IntPtr.Zero;
		_trackedHwnd = IntPtr.Zero;
		_lastInnerHwnd = IntPtr.Zero;
		_lastClientBounds = Rectangle.Empty;
	}

	public static void RefreshTabs()
	{
		if (ConfigLoader != null && !ConfigLoader.IsDisposed)
		{
			ConfigLoader.SetTabs(BuildTabList());
		}
	}

	internal static void ActivateTab(string P_0)
	{
		try
		{
			Document document = FindDocumentByKey(P_0);
			if (document != null)
			{
				document.Activate();
				CaptureActiveWindow();
				RefreshTabs();
				UpdateOverlay();
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[OfficeTab] Activate document failed: " + ex.Message);
		}
	}

	internal static void CloseTab(string P_0)
	{
		try
		{
			Document document = FindDocumentByKey(P_0);
			if (document != null)
			{
				object SaveChanges = WdSaveOptions.wdPromptToSaveChanges;
				object OriginalFormat = Type.Missing;
				object RouteDocument = Type.Missing;
				document.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[OfficeTab] Close document failed: " + ex.Message);
		}
		finally
		{
			WordTableToolService.SyncContext?.Post(delegate
			{
				if (_isActive)
				{
					RefreshTabs();
					UpdateOverlay();
				}
			}, null);
		}
	}

	private static void HookEvents()
	{
		if (!_eventsHooked && App != null)
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentChange").AddEventHandler(App, new ApplicationEvents4_DocumentChangeEventHandler(OnDocumentChange));
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentOpen").AddEventHandler(App, new ApplicationEvents4_DocumentOpenEventHandler(OnDocumentOpen));
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "NewDocument").AddEventHandler(App, new ApplicationEvents4_NewDocumentEventHandler(OnNewDocument));
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentBeforeClose").AddEventHandler(App, new ApplicationEvents4_DocumentBeforeCloseEventHandler(OnDocumentBeforeClose));
			_refreshTimer.Tick += OnTimerTick;
			_eventsHooked = true;
		}
	}

	private static void UnhookEvents()
	{
		if (_eventsHooked && App != null)
		{
			try
			{
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentChange").RemoveEventHandler(App, new ApplicationEvents4_DocumentChangeEventHandler(OnDocumentChange));
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentOpen").RemoveEventHandler(App, new ApplicationEvents4_DocumentOpenEventHandler(OnDocumentOpen));
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "NewDocument").RemoveEventHandler(App, new ApplicationEvents4_NewDocumentEventHandler(OnNewDocument));
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentBeforeClose").RemoveEventHandler(App, new ApplicationEvents4_DocumentBeforeCloseEventHandler(OnDocumentBeforeClose));
			}
			catch
			{
			}
			_refreshTimer.Tick -= OnTimerTick;
			_eventsHooked = false;
		}
	}

	private static void EnsureConfigLoader()
	{
		if (ConfigLoader == null || ConfigLoader.IsDisposed)
		{
			ConfigLoader = new UiHelperService3();
			ConfigLoader.FormClosed += delegate
			{
				ConfigLoader = null;
			};
		}
	}

	private static void OnTimerTick(object P_0, EventArgs P_1)
	{
		if (!_isActive || ConfigLoader == null || ConfigLoader.IsDisposed)
		{
			return;
		}
		try
		{
			if (TableBorderConfig.Current.Config.OfficeTab.AutoHideOnDeactivate && !IsAppActive())
			{
				ConfigLoader.LoadConfig();
				ClearOverlayState();
				return;
			}
			string text = GetDocumentSignature();
			if (text != _lastDocumentSignature)
			{
				_lastDocumentSignature = text;
				RefreshTabs();
			}
			UpdateOverlay();
		}
		catch
		{
		}
	}

	private static bool UpdateOverlay()
	{
		if (ConfigLoader == null || ConfigLoader.IsDisposed || App == null)
		{
			return false;
		}
		IntPtr intPtr = GetActiveWindowHwnd();
		if (intPtr == IntPtr.Zero)
		{
			ConfigLoader.LoadConfig();
			ClearOverlayState();
			return false;
		}
		if (!FindBestChildWindow(intPtr, out var windowInfo))
		{
			ConfigLoader.LoadConfig();
			ClearOverlayState();
			return false;
		}
		int num = ConfigLoader.GetDesiredHeight(windowInfo.vBSKBPTg82.Width);
		if (!TryComputeOverlayRect(windowInfo, num, out var rectangle))
		{
			ConfigLoader.LoadConfig();
			ClearOverlayState();
			return false;
		}
		if (rectangle.Width <= 80 || rectangle.Height <= 12)
		{
			ConfigLoader.LoadConfig();
			ClearOverlayState();
			return false;
		}
		if (_lastOwnerHwnd != intPtr)
		{
			try
			{
				ScreenshotCaptureHelper2.SetWindowLongCompat(ConfigLoader.Handle, -8, intPtr);
			}
			catch
			{
			}
			_lastOwnerHwnd = intPtr;
		}
		if (_lastOverlayBounds != rectangle)
		{
			ScreenshotCaptureHelper2.SetWindowPos(ConfigLoader.Handle, IntPtr.Zero, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height, 80);
			_lastOverlayBounds = rectangle;
		}
		ConfigLoader.ShowOverlay();
		return true;
	}

	private static bool TryComputeOverlayRect(Helper_5 P_0, int P_1, out Rectangle P_2)
	{
		P_2 = Rectangle.Empty;
		if (P_0.intPtr == IntPtr.Zero || P_0.intPtr == IntPtr.Zero)
		{
			return false;
		}
		if (_trackedHwnd != IntPtr.Zero && _trackedHwnd != P_0.intPtr)
		{
			ClearOverlayState();
		}
		if (_trackedHwnd == IntPtr.Zero)
		{
			_trackedHwnd = P_0.intPtr;
			_lastInnerHwnd = P_0.intPtr;
			_lastClientBounds = P_0.vBSKBPTg82;
		}
		if (_lastInnerHwnd != P_0.intPtr)
		{
			ClearOverlayState();
			_trackedHwnd = P_0.intPtr;
			_lastInnerHwnd = P_0.intPtr;
			_lastClientBounds = P_0.vBSKBPTg82;
		}
		SyncClientBounds(P_0, P_1);
		if (!TryGetClientOrigin(_lastInnerHwnd, out var point))
		{
			return false;
		}
		Rectangle uLDUaIQyxK = _lastClientBounds;
		int num = uLDUaIQyxK.Height - P_1;
		if (num < 120)
		{
			return false;
		}
		Rectangle rectangle = new Rectangle(uLDUaIQyxK.Left, uLDUaIQyxK.Top + P_1, uLDUaIQyxK.Width, num);
		ScreenshotCaptureHelper2.SetWindowPos(P_0.intPtr, IntPtr.Zero, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height, 80);
		P_2 = new Rectangle(point.X + uLDUaIQyxK.Left, point.Y + uLDUaIQyxK.Top, uLDUaIQyxK.Width, P_1);
		return true;
	}

	private static void SyncClientBounds(Helper_5 P_0, int P_1)
	{
		if (_trackedHwnd != P_0.intPtr || _lastClientBounds == Rectangle.Empty)
		{
			return;
		}
		Rectangle uLDUaIQyxK = _lastClientBounds;
		Rectangle rectangle = new Rectangle(uLDUaIQyxK.Left, uLDUaIQyxK.Top + P_1, uLDUaIQyxK.Width, Math.Max(1, uLDUaIQyxK.Height - P_1));
		if (!RectApproxEquals(P_0.vBSKBPTg82, rectangle))
		{
			if (Math.Abs(P_0.vBSKBPTg82.Top - rectangle.Top) <= 4)
			{
				_lastClientBounds = new Rectangle(P_0.vBSKBPTg82.Left, P_0.vBSKBPTg82.Top - P_1, P_0.vBSKBPTg82.Width, P_0.vBSKBPTg82.Height + P_1);
			}
			else
			{
				_lastClientBounds = P_0.vBSKBPTg82;
			}
		}
	}

	private static bool RectApproxEquals(Rectangle P_0, Rectangle P_1)
	{
		if (Math.Abs(P_0.Left - P_1.Left) <= 4 && Math.Abs(P_0.Top - P_1.Top) <= 4 && Math.Abs(P_0.Width - P_1.Width) <= 8)
		{
			return Math.Abs(P_0.Height - P_1.Height) <= 8;
		}
		return false;
	}

	private static void ClearOverlayState()
	{
		if (_trackedHwnd == IntPtr.Zero)
		{
			return;
		}
		try
		{
			if (ScreenshotCaptureHelper2.IsWindow(_trackedHwnd) && _lastClientBounds != Rectangle.Empty)
			{
				ScreenshotCaptureHelper2.SetWindowPos(_trackedHwnd, IntPtr.Zero, _lastClientBounds.Left, _lastClientBounds.Top, _lastClientBounds.Width, _lastClientBounds.Height, 80);
			}
		}
		catch
		{
		}
		_trackedHwnd = IntPtr.Zero;
		_lastInnerHwnd = IntPtr.Zero;
		_lastClientBounds = Rectangle.Empty;
		_lastOverlayBounds = Rectangle.Empty;
	}

	private static bool FindBestChildWindow(IntPtr P_0, out Helper_5 P_1)
	{
		_G_c__DisplayClass30_0 CS_8_locals_12 = new _G_c__DisplayClass30_0();
		P_1 = default(Helper_5);
		if (!ScreenshotCaptureHelper2.GetWindowRect(P_0, out var windowRect))
		{
			return false;
		}
		CS_8_locals_12._parentBounds = Rectangle.FromLTRB(windowRect.Left, windowRect.Top, windowRect.Right, windowRect.Bottom);
		CS_8_locals_12.helper_5 = default(Helper_5);
		CS_8_locals_12._maxArea = 0L;
		ScreenshotCaptureHelper2.EnumChildWindows(P_0, delegate(IntPtr child, IntPtr _)
		{
			try
			{
				if (!ScreenshotCaptureHelper2.IsWindowVisible(child))
				{
					return true;
				}
				if (!ScreenshotCaptureHelper2.GetWindowRect(child, out var windowRect2))
				{
					return true;
				}
				Rectangle rectangle = Rectangle.FromLTRB(windowRect2.Left, windowRect2.Top, windowRect2.Right, windowRect2.Bottom);
				if (rectangle.Width < CS_8_locals_12._parentBounds.Width / 3 || rectangle.Height < CS_8_locals_12._parentBounds.Height / 4)
				{
					return true;
				}
				if (rectangle.Top < CS_8_locals_12._parentBounds.Top + 80 || rectangle.Bottom > CS_8_locals_12._parentBounds.Bottom + 8)
				{
					return true;
				}
				string text = GetWindowClassName(child);
				if (!text.StartsWith("[OfficeTab] Activate document failed: ", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
				if (!TryGetWindowInfo(child, out var windowInfo))
				{
					return true;
				}
				long num = (long)rectangle.Width * (long)rectangle.Height;
				num = ((!text.StartsWith("[OfficeTab] Close document failed: ", StringComparison.OrdinalIgnoreCase)) ? (num * 4) : (num * 10));
				if (num > CS_8_locals_12._maxArea)
				{
					CS_8_locals_12._maxArea = num;
					CS_8_locals_12.helper_5 = windowInfo;
				}
			}
			catch
			{
			}
			return true;
		}, IntPtr.Zero);
		if (CS_8_locals_12.helper_5.intPtr == IntPtr.Zero)
		{
			return false;
		}
		P_1 = CS_8_locals_12.helper_5;
		return true;
	}

	private static bool TryGetWindowInfo(IntPtr P_0, out Helper_5 P_1)
	{
		P_1 = default(Helper_5);
		IntPtr intPtr = ScreenshotCaptureHelper2.GetParent(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return false;
		}
		if (!ScreenshotCaptureHelper2.GetWindowRect(P_0, out var windowRect))
		{
			return false;
		}
		if (!TryGetClientOrigin(intPtr, out var point))
		{
			return false;
		}
		Rectangle rect = Rectangle.FromLTRB(windowRect.Left, windowRect.Top, windowRect.Right, windowRect.Bottom);
		P_1 = new Helper_5
		{
			intPtr = P_0,
			intPtr = intPtr,
			rectangle = rect,
			vBSKBPTg82 = new Rectangle(rect.Left - point.X, rect.Top - point.Y, rect.Width, rect.Height)
		};
		return true;
	}

	private static bool TryGetClientOrigin(IntPtr P_0, out Point P_1)
	{
		P_1 = Point.Empty;
		ScreenshotCaptureHelper2.SYRyATFyE10hKbRqs5x point = new ScreenshotCaptureHelper2.SYRyATFyE10hKbRqs5x
		{
			X = 0,
			Y = 0
		};
		if (!ScreenshotCaptureHelper2.ClientToScreen(P_0, ref point))
		{
			return false;
		}
		P_1 = new Point(point.X, point.Y);
		return true;
	}

	private static string GetWindowClassName(IntPtr P_0)
	{
		StringBuilder stringBuilder = new StringBuilder(128);
		if (ScreenshotCaptureHelper2.GetClassName(P_0, stringBuilder, stringBuilder.Capacity) <= 0)
		{
			return string.Empty;
		}
		return stringBuilder.ToString();
	}

	private static IntPtr GetActiveWindowHwnd()
	{
		try
		{
			if (App?.ActiveWindow != null)
			{
				return new IntPtr(App.ActiveWindow.Hwnd);
			}
		}
		catch
		{
		}
		return IntPtr.Zero;
	}

	private static void CaptureActiveWindow()
	{
		try
		{
			IntPtr intPtr = GetActiveWindowHwnd();
			if (!(intPtr == IntPtr.Zero))
			{
				ScreenshotCaptureHelper2.CaptureWindow(intPtr);
			}
		}
		catch
		{
		}
	}

	private static bool IsAppActive()
	{
		try
		{
			IntPtr intPtr = GetActiveWindowHwnd();
			IntPtr intPtr2 = ScreenshotCaptureHelper2.GetForegroundWindow();
			if (intPtr == IntPtr.Zero || intPtr2 == IntPtr.Zero)
			{
				return false;
			}
			if (!(intPtr2 == intPtr))
			{
				IntPtr value = intPtr2;
				IntPtr? obj = ConfigLoader?.Handle;
				if (!(value == obj))
				{
					ScreenshotCaptureHelper2.GetWindowThreadProcessId(intPtr, out var num);
					ScreenshotCaptureHelper2.GetWindowThreadProcessId(intPtr2, out var num2);
					return num != 0 && num == num2;
				}
			}
			return true;
		}
		catch
		{
			return true;
		}
	}

	private static string GetDocumentSignature()
	{
		try
		{
			if (App?.Documents == null)
			{
				return string.Empty;
			}
			string text = GetDocumentKey(App.ActiveDocument);
			return App.Documents.Count + "|" + text + "|" + GetActiveWindowHwnd();
		}
		catch
		{
			return string.Empty;
		}
	}

	private static List<AiHelper_10> BuildTabList()
	{
		List<AiHelper_10> list = new List<AiHelper_10>();
		try
		{
			if (App?.Documents == null)
			{
				return list;
			}
			string b = GetDocumentKey(App.ActiveDocument);
			foreach (Document document in App.Documents)
			{
				try
				{
					string text = GetDocumentKey(document);
					list.Add(new AiHelper_10
					{
						Key = text,
						Name = document.Name,
						FullName = GetDocumentFullName(document),
						IsActive = string.Equals(text, b, StringComparison.OrdinalIgnoreCase),
						IsSaved = IsDocumentSaved(document)
					});
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	private static Document FindDocumentByKey(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0) || App?.Documents == null)
		{
			return null;
		}
		foreach (Document document in App.Documents)
		{
			try
			{
				if (string.Equals(GetDocumentKey(document), P_0, StringComparison.OrdinalIgnoreCase))
				{
					return document;
				}
			}
			catch
			{
			}
		}
		return null;
	}

	private static string GetDocumentKey(Document P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		string text = GetDocumentFullName(P_0);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return P_0.Name;
	}

	private static string GetDocumentFullName(Document P_0)
	{
		try
		{
			return P_0.FullName ?? string.Empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static bool IsDocumentSaved(Document P_0)
	{
		try
		{
			return P_0.Saved;
		}
		catch
		{
			return true;
		}
	}

	private static void OnDocumentChange()
	{
		if (_isActive)
		{
			RefreshTabs();
			UpdateOverlay();
		}
	}

	private static void OnDocumentOpen(Document P_0)
	{
		if (_isActive)
		{
			RefreshTabs();
			UpdateOverlay();
		}
	}

	private static void OnNewDocument(Document P_0)
	{
		if (_isActive)
		{
			RefreshTabs();
			UpdateOverlay();
		}
	}

	private static void OnDocumentBeforeClose(Document P_0, ref bool P_1)
	{
		if (!_isActive)
		{
			return;
		}
		WordTableToolService.SyncContext?.Post(delegate
		{
			if (_isActive)
			{
				RefreshTabs();
				UpdateOverlay();
			}
		}, null);
	}

	private static void UpdateRibbonState()
	{
		try
		{
			UiHelper_1.Ribbons.Ribbon1.R2xeRcIY7q(IsActive);
		}
		catch
		{
		}
	}

	static AiHelper_13()
	{
		SseStreamInitializer.InitializeRuntime();
		_refreshTimer = new Timer
		{
			Interval = 220
		};
		_lastDocumentSignature = string.Empty;
		_lastOverlayBounds = Rectangle.Empty;
		_lastOwnerHwnd = IntPtr.Zero;
		_trackedHwnd = IntPtr.Zero;
		_lastInnerHwnd = IntPtr.Zero;
		_lastClientBounds = Rectangle.Empty;
	}
}
