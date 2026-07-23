using System;
using System.Runtime.InteropServices;
using hJKpQrVSwRwMyI2RyDQN;
using Microsoft.Office.Interop.Excel;
using sNVQvmsNbF4pw13wHyu;

namespace x89WxLeaSJIPrFI7Yj;

internal static class xcAKcictyYcoMl6ObA
{
	public static Application X11yRCCGO()
	{
		try
		{
			return (Application)Marshal.GetActiveObject(eSfxffslhXbaGAjFNv1.IsWps ? "Excel.Application" : "Ket.Application");
		}
		catch (COMException)
		{
			return null;
		}
		catch
		{
			return null;
		}
	}

	public static Application gM4XBr1Rq()
	{
		Application application = X11yRCCGO();
		if (application != null)
		{
			return application;
		}
		try
		{
			return (Application)Activator.CreateInstance(Type.GetTypeFromProgID(eSfxffslhXbaGAjFNv1.IsWps ? "Excel.Application" : "KET.Application", throwOnError: true));
		}
		catch
		{
			return null;
		}
	}
}
