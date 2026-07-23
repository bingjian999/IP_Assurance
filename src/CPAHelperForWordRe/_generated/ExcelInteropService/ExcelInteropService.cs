using System;
using System.Runtime.InteropServices;
using AiSseStreamService3;
using Microsoft.Office.Interop.Excel;
using WordTableToolService;

namespace ExcelInteropService;

internal static class ExcelInteropService
{
	public static Application GetActiveExcelApp()
	{
		try
		{
			return (Application)Marshal.GetActiveObject(WordTableToolService.IsWps ? "Excel.Application" : "Ket.Application");
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

	public static Application GetOrCreateExcelApp()
	{
		Application application = GetActiveExcelApp();
		if (application != null)
		{
			return application;
		}
		try
		{
			return (Application)Activator.CreateInstance(Type.GetTypeFromProgID(WordTableToolService.IsWps ? "Excel.Application" : "KET.Application", throwOnError: true));
		}
		catch
		{
			return null;
		}
	}
}
