using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using hJKpQrVSwRwMyI2RyDQN;
using LgmURjbT0s9Qufho1dJ;
using ndRERvVtEjasqN2cQqiN;
using w5Oql9FwFDU9FYHJXvj;
using YNri0QclKMfRh2PQoZV;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class MarkdownImportWindow : Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0
	{
		public bool xGtV4BI5U0F;

		public MarkdownImportWindow vI1V49iRKoi;

		public _G_c__DisplayClass2_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void W8PV4Vx80ng()
		{
			xGtV4BI5U0F = s2nMCybDnhhNsDsld0f.XiHb8xdPLA(vI1V49iRKoi.txtMarkdown.Text, vI1V49iRKoi.chkApplyHeadingNumbering.IsChecked == true);
		}
	}

	internal TextBox txtMarkdown;

	internal CheckBox chkApplyHeadingNumbering;

	private bool xAGCrIvaiu;

	public MarkdownImportWindow()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
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
				F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("剪贴板中没有可粘贴的文本。", "IP_Assurance");
				return;
			}
			txtMarkdown.Text = Clipboard.GetText();
			txtMarkdown.CaretIndex = txtMarkdown.Text.Length;
			txtMarkdown.Focus();
		}
		catch (Exception ex)
		{
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8("读取剪贴板失败：" + ex.Message, "IP_Assurance");
		}
	}

	private void sVxCiGSm3i(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass2_0 obj = new _G_c__DisplayClass2_0();
		obj.vI1V49iRKoi = this;
		obj.xGtV4BI5U0F = false;
		okTG2rFSnxjcTsuMG3L.sY9FLcxGhc(delegate
		{
			obj.xGtV4BI5U0F = s2nMCybDnhhNsDsld0f.XiHb8xdPLA(obj.vI1V49iRKoi.txtMarkdown.Text, obj.vI1V49iRKoi.chkApplyHeadingNumbering.IsChecked == true);
		}, "Markdown 导入");
		if (obj.xGtV4BI5U0F)
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
