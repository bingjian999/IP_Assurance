using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using WordTableToolService5;
using AiSseStreamService3;
using FormatPresetConfig;
using SseStreamInitializer;
using JsonFileDialogHelper;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class TableConfigWindow : Window, IComponentConnector
{
	private readonly FormatPresetConfig _formatPresetConfig;

	private bool _bool;

	public TableConfigWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		InitializeComponent();
		_formatPresetConfig = new FormatPresetConfig(new JsonFileDialogHelper());
		_formatPresetConfig.add_CloseRequested(base.Close);
		_formatPresetConfig.add_OpenParagraphRequested(OnOpenParagraphRequested);
		base.DataContext = _formatPresetConfig;
		base.PreviewKeyDown += cgPCEufjgs;
	}

	private void cgPCEufjgs(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	private void OnOpenParagraphRequested()
	{
		WordTableToolService5.ShowWpfWindow(new ParagraphConfigWindow());
		Close();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/tableconfigwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		_bool = true;
	}
}
