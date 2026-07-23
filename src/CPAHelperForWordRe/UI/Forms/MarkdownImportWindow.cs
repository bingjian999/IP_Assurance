using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using AiSseStreamService3;
using MarkdownImportService;
using SseStreamInitializer;
using AiHelper_7;
using LoggerInitializer;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class MarkdownImportWindow : Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0
	{
		public bool flag;

		public MarkdownImportWindow markdownImportWindow;

		public _G_c__DisplayClass2_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void W8PV4Vx80ng()
		{
			flag = MarkdownImportService.XiHb8xdPLA(markdownImportWindow.txtMarkdown.Text, markdownImportWindow.chkApplyHeadingNumbering.IsChecked == true);
		}
	}

	internal TextBox txtMarkdown;

	internal CheckBox chkApplyHeadingNumbering;

	private bool xAGCrIvaiu;

	public MarkdownImportWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		InitializeComponent();
		base.PreviewKeyDown += delegate(object P_0, KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		base.Loaded += delegate
		{
			txtMarkdown.Focus();
		};
	}

	private void dguCIrp1m7(object P_0, RoutedEventArgs P_1)
	{
		try
		{
			if (!Clipboard.ContainsText())
			{
				LoggerInitializer.ShowWarning("剪贴板中没有可粘贴的文本。", "IP_Assurance");
				return;
			}
			txtMarkdown.Text = Clipboard.GetText();
			txtMarkdown.CaretIndex = txtMarkdown.Text.Length;
			txtMarkdown.Focus();
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError("读取剪贴板失败：" + ex.Message, "IP_Assurance");
		}
	}

	private void sVxCiGSm3i(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass2_0 obj = new _G_c__DisplayClass2_0();
		obj.markdownImportWindow = this;
		obj.flag = false;
		AiHelper_7.RunCommandWithUndo(delegate
		{
			obj.flag = MarkdownImportService.XiHb8xdPLA(obj.markdownImportWindow.txtMarkdown.Text, obj.markdownImportWindow.chkApplyHeadingNumbering.IsChecked == true);
		}, "Markdown 导入");
		if (obj.flag)
		{
			Close();
		}
	}

	private void OYKCHcQEhT(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!xAGCrIvaiu)
		{
			xAGCrIvaiu = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/markdownimportwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			((Button)target).Click += dguCIrp1m7;
			break;
		case 2:
			txtMarkdown = (TextBox)target;
			break;
		case 3:
			chkApplyHeadingNumbering = (CheckBox)target;
			break;
		case 4:
			((Button)target).Click += sVxCiGSm3i;
			break;
		case 5:
			((Button)target).Click += OYKCHcQEhT;
			break;
		default:
			xAGCrIvaiu = true;
			break;
		}
	}

	[CompilerGenerated]
	private void TshCQtFR55(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void RbvC1UfJQh(object P_0, RoutedEventArgs P_1)
	{
		txtMarkdown.Focus();
	}
}
