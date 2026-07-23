using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using WordTableToolService5;
using AiSseStreamService3;
using LegacyConfigMigrator2;
using SseStreamInitializer;
using JsonFileDialogHelper;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ParagraphConfigWindow : Window, IComponentConnector
{
	private readonly LegacyConfigMigrator2 _legacyConfigMigrator2;

	private bool erTCKRYVh2;

	public ParagraphConfigWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		InitializeComponent();
		_legacyConfigMigrator2 = new LegacyConfigMigrator2(new JsonFileDialogHelper());
		_legacyConfigMigrator2.add_OpenTableRequested(base.Close);
		_legacyConfigMigrator2.add_Closed(dTqC3t4uPZ);
		base.DataContext = _legacyConfigMigrator2;
		base.PreviewKeyDown += vg3CJM4XQx;
	}

	private void vg3CJM4XQx(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	private void dTqC3t4uPZ()
	{
		WordTableToolService5.ShowWpfWindow(new TableConfigWindow());
		Close();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!erTCKRYVh2)
		{
			erTCKRYVh2 = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/paragraphconfigwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		erTCKRYVh2 = true;
	}
}
