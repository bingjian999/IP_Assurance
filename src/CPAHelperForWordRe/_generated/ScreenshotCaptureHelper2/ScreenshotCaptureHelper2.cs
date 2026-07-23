using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ScreenshotCaptureHelper2;

internal static class ScreenshotCaptureHelper2
{
	public delegate bool fJ8XynFenHxJS2xaciW(IntPtr hWnd, IntPtr lParam);

	public struct SYRyATFyE10hKbRqs5x
	{
		public int X;

		public int oURFXOAIJr;
	}

	public struct g776GxFFqI1ndqZk2gX
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "FindWindow", SetLastError = true)]
	public static extern IntPtr BuvaV6M5a(string P_0, string P_1);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "FindWindowEx")]
	public static extern IntPtr wktqq4ic3(IntPtr P_0, IntPtr P_1, string P_2, string P_3);

	[DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
	public static extern bool d2kP0Du2a(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "GetWindowRect")]
	public static extern bool DcLA6kaCn(IntPtr P_0, out g776GxFFqI1ndqZk2gX P_1);

	[DllImport("user32.dll", EntryPoint = "GetClientRect")]
	public static extern bool hTVvUjpi9(IntPtr P_0, out g776GxFFqI1ndqZk2gX P_1);

	[DllImport("user32.dll", EntryPoint = "ClientToScreen")]
	public static extern bool NZHWMtPPQ(IntPtr P_0, ref SYRyATFyE10hKbRqs5x P_1);

	[DllImport("user32.dll", EntryPoint = "IsWindowVisible")]
	public static extern bool USD0wZPHF(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow")]
	public static extern bool GAekICEQL(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "GetParent")]
	public static extern IntPtr OyTxvptUZ(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "ShowWindow")]
	public static extern bool eq5dmBARf(IntPtr P_0, int P_1);

	[DllImport("user32.dll", EntryPoint = "RegisterHotKey", SetLastError = true)]
	public static extern bool mIozr8woi(IntPtr P_0, int P_1, uint P_2, uint P_3);

	[DllImport("user32.dll", EntryPoint = "UnregisterHotKey", SetLastError = true)]
	public static extern bool TAqVRPUvsq(IntPtr P_0, int P_1);

	[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
	public static extern bool qVGVVA8Epe(IntPtr P_0, IntPtr P_1, int P_2, int P_3, int P_4, int P_5, int P_6);

	[DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
	public static extern IntPtr cH4VBSeFlb();

	[DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
	public static extern int Kl5V9YsO3Z(IntPtr P_0, out int P_1);

	[DllImport("user32.dll", EntryPoint = "EnumChildWindows")]
	public static extern bool sUYV6arCCC(IntPtr P_0, fJ8XynFenHxJS2xaciW P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetClassName")]
	public static extern int RajVuvo2tr(IntPtr P_0, StringBuilder P_1, int P_2);

	[DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
	private static extern int qeDVDvMnhe(IntPtr P_0, int P_1, int P_2);

	[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
	private static extern IntPtr P9hVTL61fZ(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("shell32.dll", CharSet = CharSet.Auto, EntryPoint = "ShellExecute")]
	public static extern IntPtr MHMVg9XYZc(IntPtr P_0, string P_1, string P_2, string P_3, string P_4, int P_5);

	public static IntPtr r8rV8AwJBn(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size != 8)
		{
			return new IntPtr(qeDVDvMnhe(P_0, P_1, P_2.ToInt32()));
		}
		return P9hVTL61fZ(P_0, P_1, P_2);
	}
}
