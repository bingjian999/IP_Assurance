using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using CPAHelperForWordRe;
using Microsoft.Office.Tools.Word;
using SseStreamInitializer;
using UiHelper_6;

namespace UiHelper_1;

[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
[DebuggerNonUserCode]
internal sealed class UiHelper_1
{
	private static ThisAddIn f9fpbjxOh;

	private static ApplicationFactory p6fOCIqmS;

	private static UiHelper_6 ioZntiWbx;

	internal static ThisAddIn ThisAddIn
	{
		get
		{
			return f9fpbjxOh;
		}
		set
		{
			if (f9fpbjxOh == null)
			{
				f9fpbjxOh = value;
				return;
			}
			throw new NotSupportedException();
		}
	}

	internal static ApplicationFactory Factory
	{
		get
		{
			return p6fOCIqmS;
		}
		set
		{
			if (p6fOCIqmS == null)
			{
				p6fOCIqmS = value;
				return;
			}
			throw new NotSupportedException();
		}
	}

	internal static UiHelper_6 Ribbons
	{
		get
		{
			if (ioZntiWbx == null)
			{
				ioZntiWbx = new UiHelper_6(p6fOCIqmS.GetRibbonFactory());
			}
			return ioZntiWbx;
		}
	}

	private UiHelper_1()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
