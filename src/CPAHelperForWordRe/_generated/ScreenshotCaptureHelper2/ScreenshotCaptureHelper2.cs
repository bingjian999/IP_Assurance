using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ScreenshotCaptureHelper2;

internal static class ScreenshotCaptureHelper2
{
	public delegate bool EnumChildProcDelegate(IntPtr hWnd, IntPtr lParam);

	public struct SYRyATFyE10hKbRqs5x
	{
		public int X;

		public int Y;
	}

	public struct windowRect
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "FindWindow", SetLastError = true)]
	public static extern IntPtr FindWindow(string P_0, string P_1);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "FindWindowEx")]
	public static extern IntPtr FindWindowEx(IntPtr P_0, IntPtr P_1, string P_2, string P_3);

	[DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
	public static extern bool CaptureWindow(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "GetWindowRect")]
	public static extern bool GetWindowRect(IntPtr P_0, out windowRect P_1);

	[DllImport("user32.dll", EntryPoint = "GetClientRect")]
	public static extern bool GetClientRect(IntPtr P_0, out windowRect P_1);

	[DllImport("user32.dll", EntryPoint = "ClientToScreen")]
	public static extern bool ClientToScreen(IntPtr P_0, ref SYRyATFyE10hKbRqs5x P_1);

	[DllImport("user32.dll", EntryPoint = "IsWindowVisible")]
	public static extern bool IsWindowVisible(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow")]
	public static extern bool IsWindow(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "GetParent")]
	public static extern IntPtr GetParent(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "ShowWindow")]
	public static extern bool CaptureScreen(IntPtr P_0, int P_1);

	[DllImport("user32.dll", EntryPoint = "RegisterHotKey", SetLastError = true)]
	public static extern bool RegisterHotKey(IntPtr P_0, int P_1, uint P_2, uint P_3);

	[DllImport("user32.dll", EntryPoint = "UnregisterHotKey", SetLastError = true)]
	public static extern bool UnregisterHotKey(IntPtr P_0, int P_1);

	[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
	public static extern bool SetWindowPos(IntPtr P_0, IntPtr P_1, int P_2, int P_3, int P_4, int P_5, int P_6);

	[DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
	public static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
	public static extern int GetWindowThreadProcessId(IntPtr P_0, out int P_1);

	[DllImport("user32.dll", EntryPoint = "EnumChildWindows")]
	public static extern bool EnumChildWindows(IntPtr P_0, EnumChildProcDelegate P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetClassName")]
	public static extern int GetClassName(IntPtr P_0, StringBuilder P_1, int P_2);

	[DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
	private static extern int SetWindowLong(IntPtr P_0, int P_1, int P_2);

	[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
	private static extern IntPtr SetWindowLongPtr(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("shell32.dll", CharSet = CharSet.Auto, EntryPoint = "ShellExecute")]
	public static extern IntPtr ShellExecute(IntPtr P_0, string P_1, string P_2, string P_3, string P_4, int P_5);

	public static IntPtr SetWindowLongCompat(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size != 8)
		{
			return new IntPtr(SetWindowLong(P_0, P_1, P_2.ToInt32()));
		}
		return SetWindowLongPtr(P_0, P_1, P_2);
	}
}
