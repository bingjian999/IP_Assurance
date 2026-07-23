using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using DocumentRenameService;
using AiSseStreamService3;
using SseStreamInitializer;
using Helper_10;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class RenameDocumentWindow : Window, IComponentConnector
{
	internal TextBox txtCurrentName;

	internal TextBox txtNewName;

	internal TextBlock lblState;

	internal Button btnRename;

	private bool _bool;

	public RenameDocumentWindow()
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
			txtNewName.Focus();
			txtNewName.SelectAll();
		};
		HN9GNMbyHk();
	}

	private void HN9GNMbyHk()
	{
		txtCurrentName.Text = DocumentRenameService.p22B4gZ207() ?? "(当前没有打开的 Word 文档)";
		txtNewName.Text = DocumentRenameService.yNrBjmtqCf();
		string text;
		bool flag = DocumentRenameService.NDgBYYaMnF(out text);
		btnRename.IsEnabled = flag;
		lblState.Text = (flag ? "仅修改文件主名，后缀保持不变。" : text);
	}

	private void PwEGm0CK1p(object P_0, RoutedEventArgs P_1)
	{
		try
		{
			Helper_10 j5TqonBNY02JxhgwfnS2 = DocumentRenameService.wqTBZIKo0s(txtNewName.Text, gJAGoM4wmO);
			if (j5TqonBNY02JxhgwfnS2.IsCanceled)
			{
				lblState.Text = "已取消重命名。";
				return;
			}
			if (j5TqonBNY02JxhgwfnS2.IsNoChange)
			{
				lblState.Text = "新文件名与当前文件名一致，无需重命名。";
				txtNewName.Focus();
				txtNewName.SelectAll();
				return;
			}
			if (!j5TqonBNY02JxhgwfnS2.OldFileDeleted && !string.IsNullOrWhiteSpace(j5TqonBNY02JxhgwfnS2.OldFileDeleteError))
			{
				MessageBox.Show(this, "重命名成功，新文件已生成。\\n\\n旧文件未能自动删除：\\n" + j5TqonBNY02JxhgwfnS2.OldFileDeleteError, "IP_Assurance", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			}
			else
			{
				MessageBox.Show(this, "重命名成功", "IP_Assurance", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
			base.DialogResult = true;
			Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, ex.Message, "IP_Assurance", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			HN9GNMbyHk();
			txtNewName.Focus();
			txtNewName.SelectAll();
		}
	}

	private bool gJAGoM4wmO(string P_0)
	{
		return MessageBox.Show(this, P_0, "IP_Assurance", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
	}

	private void nbhGGR3871(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/renamedocumentwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			txtCurrentName = (TextBox)target;
			break;
		case 2:
			txtNewName = (TextBox)target;
			break;
		case 3:
			lblState = (TextBlock)target;
			break;
		case 4:
			btnRename = (Button)target;
			btnRename.Click += PwEGm0CK1p;
			break;
		case 5:
			((Button)target).Click += nbhGGR3871;
			break;
		default:
			_bool = true;
			break;
		}
	}

	[CompilerGenerated]
	private void YMKGCxgh9F(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void eYtGpR8d7r(object P_0, RoutedEventArgs P_1)
	{
		txtNewName.Focus();
		txtNewName.SelectAll();
	}
}
