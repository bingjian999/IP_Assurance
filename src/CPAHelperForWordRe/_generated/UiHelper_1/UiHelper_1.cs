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
	private static ThisAddIn _thisAddIn;

	private static ApplicationFactory _factory;

	private static UiHelper_6 ioZntiWbx;

	internal static ThisAddIn ThisAddIn
	{
		get
		{
			return _thisAddIn;
		}
		set
		{
			if (_thisAddIn == null)
			{
				_thisAddIn = value;
				return;
			}
			throw new NotSupportedException();
		}
	}

	internal static ApplicationFactory Factory
	{
		get
		{
			return _factory;
		}
		set
		{
			if (_factory == null)
			{
				_factory = value;
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
				ioZntiWbx = new UiHelper_6(_factory.GetRibbonFactory());
			}
			return ioZntiWbx;
		}
	}

	private UiHelper_1()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
