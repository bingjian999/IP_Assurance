using System.CodeDom.Compiler;
using System.Diagnostics;
using CPAHelperForWordRe.UI.Ribbon;
using Microsoft.Office.Tools.Ribbon;
using SseStreamInitializer;

namespace UiHelper_6;

[GeneratedCode("Microsoft.VisualStudio.Tools.Office.ProgrammingModel.dll", "18.0.0.0")]
[DebuggerNonUserCode]
internal sealed class UiHelper_6 : RibbonCollectionBase
{
	internal Ribbon1 Ribbon1 => GetRibbon<Ribbon1>() ?? Ribbon1.Current;

	internal UiHelper_6(RibbonFactory P_0) : base(P_0)
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
