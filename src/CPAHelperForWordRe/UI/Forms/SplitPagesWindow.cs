using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using AiSseStreamService3;
using SseStreamInitializer;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class SplitPagesWindow : Window, IComponentConnector
{
	private readonly int _int;

	[CompilerGenerated]
	private int FVennAYbFk;

	internal TextBox txtPages;

	internal TextBlock txtHint;

	private bool _bool;

	public int PagesPerDocument
	{
		[CompilerGenerated]
		get
		{
			return FVennAYbFk;
		}
		[CompilerGenerated]
		private set
		{
			FVennAYbFk = value;
		}
	}

	public SplitPagesWindow(int totalPages)
	{
		SseStreamInitializer.InitializeRuntime();
		InitializeComponent();
		_int = Math.Max(1, totalPages);
		int num = Math.Min(20, _int);
		txtPages.Text = num.ToString(CultureInfo.InvariantCulture);
		txtHint.Text = string.Format("当前文档共 {0} 页。请输入 1 ~ {1} 之间的整数。", _int, _int);
		base.PreviewKeyDown += delegate(object P_0, KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		base.Loaded += delegate
		{
			txtPages.Focus();
			txtPages.SelectAll();
		};
		DataObject.AddPastingHandler(txtPages, Y9YnouK8d5);
	}

	private void s86nlb1Mll(object P_0, RoutedEventArgs P_1)
	{
		if (!int.TryParse(txtPages.Text.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) || result < 1 || result > _int)
		{
			MessageBox.Show(this, string.Format("每份页数必须是 1 ~ {0} 之间的整数。", _int), "提示", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			txtPages.Focus();
			txtPages.SelectAll();
		}
		else
		{
			PagesPerDocument = result;
			base.DialogResult = true;
			Close();
		}
	}

	private void eipnN2KJkv(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void bjEnm5dI2N(object P_0, TextCompositionEventArgs P_1)
	{
		P_1.Handled = !mACnGytPYh(P_1.Text);
	}

	private void Y9YnouK8d5(object P_0, DataObjectPastingEventArgs P_1)
	{
		if (!mACnGytPYh(P_1.DataObject.GetDataPresent(DataFormats.Text) ? (P_1.DataObject.GetData(DataFormats.Text) as string) : null))
		{
			P_1.CancelCommand();
		}
	}

	private static bool mACnGytPYh(string P_0)
	{
		if (!string.IsNullOrEmpty(P_0))
		{
			return P_0.All(char.IsDigit);
		}
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/splitpageswindow.xaml", UriKind.Relative);
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
			txtPages = (TextBox)target;
			txtPages.PreviewTextInput += bjEnm5dI2N;
			break;
		case 2:
			txtHint = (TextBlock)target;
			break;
		case 3:
			((Button)target).Click += s86nlb1Mll;
			break;
		case 4:
			((Button)target).Click += eipnN2KJkv;
			break;
		default:
			_bool = true;
			break;
		}
	}

	[CompilerGenerated]
	private void OdOnCApQkS(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void GSBnpG97by(object P_0, RoutedEventArgs P_1)
	{
		txtPages.Focus();
		txtPages.SelectAll();
	}
}
