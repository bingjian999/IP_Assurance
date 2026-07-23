using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using SseStreamInitializer;

namespace AiHelper_4;

internal static class AiHelper_4
{
	private delegate IntPtr aVP7frFaxcXJLsEa41c(int code, IntPtr wParam, IntPtr lParam);

	private struct L4uBarFqRh3JxJg1SCu
	{
		public IntPtr cfnFPfMCaI;

		public int HXnFAfQ2Me;

		public IntPtr aIbFvfYn6O;

		public IntPtr gxbFWbUp1F;

		public int Uw6F0NqWdp;

		public int jRuFkSXreX;

		public int UWUFxie1Ta;
	}

	private static readonly HashSet<IntPtr> cAfVPkJWlC;

	private static readonly Dictionary<Window, IntPtr> iEsVA3v1o8;

	private static IntPtr KFhVvRQQW6;

	private static aVP7frFaxcXJLsEa41c HO6VWcxesM;

	private static bool oAbV0G1jGw;

	public static void b5KVmv3Pp9(Window P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		if (iEsVA3v1o8.ContainsKey(P_0))
		{
			NtfVpRtLSa();
			return;
		}
		WindowInteropHelper windowInteropHelper = new WindowInteropHelper(P_0);
		iEsVA3v1o8[P_0] = windowInteropHelper.Handle;
		if (windowInteropHelper.Handle != IntPtr.Zero)
		{
			cAfVPkJWlC.Add(windowInteropHelper.Handle);
		}
		P_0.SourceInitialized += U4KVGF3FTd;
		P_0.Closed += fdsVCFkUIE;
		NtfVpRtLSa();
	}

	public static void EdjVoDIVbd()
	{
		TENVns8Mrk();
		cAfVPkJWlC.Clear();
		iEsVA3v1o8.Clear();
	}

	private static void U4KVGF3FTd(object P_0, EventArgs P_1)
	{
		if (P_0 is Window window)
		{
			IntPtr handle = new WindowInteropHelper(window).Handle;
			if (iEsVA3v1o8.TryGetValue(window, out var value) && value != IntPtr.Zero)
			{
				cAfVPkJWlC.Remove(value);
			}
			iEsVA3v1o8[window] = handle;
			if (handle != IntPtr.Zero)
			{
				cAfVPkJWlC.Add(handle);
			}
		}
	}

	private static void fdsVCFkUIE(object P_0, EventArgs P_1)
	{
		if (!(P_0 is Window window))
		{
			return;
		}
		window.SourceInitialized -= U4KVGF3FTd;
		window.Closed -= fdsVCFkUIE;
		if (iEsVA3v1o8.TryGetValue(window, out var value))
		{
			if (value != IntPtr.Zero)
			{
				cAfVPkJWlC.Remove(value);
			}
			iEsVA3v1o8.Remove(window);
		}
		ednVO0NfeW();
	}

	private static void NtfVpRtLSa()
	{
		if (!(KFhVvRQQW6 != IntPtr.Zero))
		{
			HO6VWcxesM = qOZV7EsLTp;
			KFhVvRQQW6 = NwBVefG7Ch(3, HO6VWcxesM, IntPtr.Zero, mciVFrKOEn());
		}
	}

	private static void ednVO0NfeW()
	{
		if (iEsVA3v1o8.Count == 0)
		{
			TENVns8Mrk();
		}
	}

	private static void TENVns8Mrk()
	{
		if (!(KFhVvRQQW6 == IntPtr.Zero))
		{
			KvkVyFQDkh(KFhVvRQQW6);
			KFhVvRQQW6 = IntPtr.Zero;
		}
	}

	private static IntPtr qOZV7EsLTp(int P_0, IntPtr P_1, IntPtr P_2)
	{
		if (!oAbV0G1jGw && P_0 == 0 && P_1 == (IntPtr)1)
		{
			L4uBarFqRh3JxJg1SCu structure = (L4uBarFqRh3JxJg1SCu)Marshal.PtrToStructure(P_2, typeof(L4uBarFqRh3JxJg1SCu));
			if (gfRV5NHHnD(structure.HXnFAfQ2Me) && qMMVcyk2oU(structure.cfnFPfMCaI))
			{
				oAbV0G1jGw = true;
				try
				{
					VZaVhj40Ho(ref structure);
					CirVaL91lZ(ref structure);
				}
				finally
				{
					oAbV0G1jGw = false;
				}
				structure.HXnFAfQ2Me = 0;
				Marshal.StructureToPtr(structure, P_2, fDeleteOld: false);
			}
		}
		return lWWVXqHaPY(IntPtr.Zero, P_0, P_1, P_2);
	}

	private static bool gfRV5NHHnD(int P_0)
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

	private static bool qMMVcyk2oU(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero || cAfVPkJWlC.Count == 0)
		{
			return false;
		}
		if (cAfVPkJWlC.Contains(P_0))
		{
			return true;
		}
		foreach (IntPtr item in cAfVPkJWlC)
		{
			if (dYxVqeSJ7P(item, P_0))
			{
				return true;
			}
		}
		return false;
	}

	[DllImport("user32.dll", EntryPoint = "SetWindowsHookEx", SetLastError = true)]
	private static extern IntPtr NwBVefG7Ch(int P_0, aVP7frFaxcXJLsEa41c P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", EntryPoint = "UnhookWindowsHookEx", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool KvkVyFQDkh(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "CallNextHookEx")]
	private static extern IntPtr lWWVXqHaPY(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("kernel32.dll", EntryPoint = "GetCurrentThreadId")]
	private static extern uint mciVFrKOEn();

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool VZaVhj40Ho(ref L4uBarFqRh3JxJg1SCu P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	private static extern IntPtr CirVaL91lZ(ref L4uBarFqRh3JxJg1SCu P_0);

	[DllImport("user32.dll", EntryPoint = "IsChild")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool dYxVqeSJ7P(IntPtr P_0, IntPtr P_1);

	static AiHelper_4()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		cAfVPkJWlC = new HashSet<IntPtr>();
		iEsVA3v1o8 = new Dictionary<Window, IntPtr>();
		KFhVvRQQW6 = IntPtr.Zero;
	}
}
