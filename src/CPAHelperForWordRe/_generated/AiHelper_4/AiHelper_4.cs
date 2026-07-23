using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using SseStreamInitializer;

namespace AiHelper_4;

internal static class AiHelper_4
{
	private delegate IntPtr HookProcDelegate(int code, IntPtr wParam, IntPtr lParam);

	private struct MsgStruct
	{
		public IntPtr hWnd;

		public int value;

		public IntPtr intPtr;

		public IntPtr intPtr;

		public int value;

		public int ptX;

		public int value;
	}

	private static readonly HashSet<IntPtr> _trackedHandles;

	private static readonly Dictionary<Window, IntPtr> _windowHandleMap;

	private static IntPtr _hookHandle;

	private static HookProcDelegate _hookCallback;

	private static bool _isDispatching;

	public static void RegisterWindow(Window P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		if (_windowHandleMap.ContainsKey(P_0))
		{
			EnsureHookInstalled();
			return;
		}
		WindowInteropHelper windowInteropHelper = new WindowInteropHelper(P_0);
		_windowHandleMap[P_0] = windowInteropHelper.Handle;
		if (windowInteropHelper.Handle != IntPtr.Zero)
		{
			_trackedHandles.Add(windowInteropHelper.Handle);
		}
		P_0.SourceInitialized += OnSourceInitialized;
		P_0.Closed += OnWindowClosed;
		EnsureHookInstalled();
	}

	public static void UnregisterAll()
	{
		RemoveHook();
		_trackedHandles.Clear();
		_windowHandleMap.Clear();
	}

	private static void OnSourceInitialized(object P_0, EventArgs P_1)
	{
		if (P_0 is Window window)
		{
			IntPtr handle = new WindowInteropHelper(window).Handle;
			if (_windowHandleMap.TryGetValue(window, out var value) && value != IntPtr.Zero)
			{
				_trackedHandles.Remove(value);
			}
			_windowHandleMap[window] = handle;
			if (handle != IntPtr.Zero)
			{
				_trackedHandles.Add(handle);
			}
		}
	}

	private static void OnWindowClosed(object P_0, EventArgs P_1)
	{
		if (!(P_0 is Window window))
		{
			return;
		}
		window.SourceInitialized -= OnSourceInitialized;
		window.Closed -= OnWindowClosed;
		if (_windowHandleMap.TryGetValue(window, out var value))
		{
			if (value != IntPtr.Zero)
			{
				_trackedHandles.Remove(value);
			}
			_windowHandleMap.Remove(window);
		}
		TryRemoveHook();
	}

	private static void EnsureHookInstalled()
	{
		if (!(_hookHandle != IntPtr.Zero))
		{
			_hookCallback = HookCallback;
			_hookHandle = SetWindowsHookEx(3, _hookCallback, IntPtr.Zero, GetCurrentThreadId());
		}
	}

	private static void TryRemoveHook()
	{
		if (_windowHandleMap.Count == 0)
		{
			RemoveHook();
		}
	}

	private static void RemoveHook()
	{
		if (!(_hookHandle == IntPtr.Zero))
		{
			UnhookWindowsHookEx(_hookHandle);
			_hookHandle = IntPtr.Zero;
		}
	}

	private static IntPtr HookCallback(int P_0, IntPtr P_1, IntPtr P_2)
	{
		if (!_isDispatching && P_0 == 0 && P_1 == (IntPtr)1)
		{
			MsgStruct structure = (MsgStruct)Marshal.PtrToStructure(P_2, typeof(MsgStruct));
			if (IsKeyboardMessage(structure.value) && IsTrackedWindow(structure.hWnd))
			{
				_isDispatching = true;
				try
				{
					TranslateMessage(ref structure);
					DispatchMessage(ref structure);
				}
				finally
				{
					_isDispatching = false;
				}
				structure.value = 0;
				Marshal.StructureToPtr(structure, P_2, fDeleteOld: false);
			}
		}
		return CallNextHookEx(IntPtr.Zero, P_0, P_1, P_2);
	}

	private static bool IsKeyboardMessage(int P_0)
	{
		if (P_0 >= 256 && P_0 <= 265)
		{
			return true;
		}
		if (P_0 >= 269 && P_0 <= 271)
		{
			return true;
		}
		return P_0 == 646;
	}

	private static bool IsTrackedWindow(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero || _trackedHandles.Count == 0)
		{
			return false;
		}
		if (_trackedHandles.Contains(P_0))
		{
			return true;
		}
		foreach (IntPtr item in _trackedHandles)
		{
			if (IsChild(item, P_0))
			{
				return true;
			}
		}
		return false;
	}

	[DllImport("user32.dll", EntryPoint = "SetWindowsHookEx", SetLastError = true)]
	private static extern IntPtr SetWindowsHookEx(int P_0, HookProcDelegate P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", EntryPoint = "UnhookWindowsHookEx", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool UnhookWindowsHookEx(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "CallNextHookEx")]
	private static extern IntPtr CallNextHookEx(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("kernel32.dll", EntryPoint = "GetCurrentThreadId")]
	private static extern uint GetCurrentThreadId();

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool TranslateMessage(ref MsgStruct P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	private static extern IntPtr DispatchMessage(ref MsgStruct P_0);

	[DllImport("user32.dll", EntryPoint = "IsChild")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool IsChild(IntPtr P_0, IntPtr P_1);

	static AiHelper_4()
	{
		SseStreamInitializer.InitializeRuntime();
		_trackedHandles = new HashSet<IntPtr>();
		_windowHandleMap = new Dictionary<Window, IntPtr>();
		_hookHandle = IntPtr.Zero;
	}
}
