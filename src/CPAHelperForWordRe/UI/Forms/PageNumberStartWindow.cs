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
using FiIb7mSOBD13BJBxsh0;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;
using YNri0QclKMfRh2PQoZV;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class PageNumberStartWindow : Window, IComponentConnector
{
	internal TextBox txtStartNumber;

	private bool KYFnssBt8V;

	public PageNumberStartWindow()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		InitializeComponent();
		int num = dXHnSRT5B2(ftu1AgSpErBKqc6vp9f.Current.HYsSh2NDxY("页面_页码_起始值", 1));
		txtStartNumber.Text = num.ToString(CultureInfo.InvariantCulture);
		base.PreviewKeyDown += delegate(object P_0, KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		base.Loaded += delegate
		{
			txtStartNumber.Focus();
			txtStartNumber.SelectAll();
		};
		DataObject.AddPastingHandler(txtStartNumber, JWNnblH4qS);
	}

	private void ijVnZT2eYF(object P_0, RoutedEventArgs P_1)
	{
		if (!int.TryParse(txtStartNumber.Text.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) || result < 1 || result > 9999)
		{
			MessageBox.Show(this, string.Format("起始页码必须是 {0} ~ {1} 之间的整数。", 1, 9999), "提示", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			txtStartNumber.Focus();
			txtStartNumber.SelectAll();
		}
		else
		{
			ftu1AgSpErBKqc6vp9f.Current.pE1SyAiPWc("页面_页码_起始值", result.ToString(CultureInfo.InvariantCulture));
			F2ZFeLcsiLlLr89kqUl.Ay3cNuEgJo("页码起始值已保存。", "IP_Assurance");
			base.DialogResult = true;
			Close();
		}
	}

	private void Q5anfVee0d(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void eHMnMhv8vx(object P_0, TextCompositionEventArgs P_1)
	{
		P_1.Handled = !D9AnwkLfbT(P_1.Text);
	}

	private void JWNnblH4qS(object P_0, DataObjectPastingEventArgs P_1)
	{
		if (!D9AnwkLfbT(P_1.DataObject.GetDataPresent(DataFormats.Text) ? (P_1.DataObject.GetData(DataFormats.Text) as string) : null))
		{
			P_1.CancelCommand();
		}
	}

	internal static int dXHnSRT5B2(int P_0)
	{
		if (P_0 < 1)
		{
			return 1;
		}
		if (P_0 <= 9999)
		{
			return P_0;
		}
		return 9999;
	}

	private static bool D9AnwkLfbT(string P_0)
	{
		if (!string.IsNullOrEmpty(P_0))
		{
			return P_0.All(char.IsDigit);
		}
		return false;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!KYFnssBt8V)
		{
			KYFnssBt8V = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/pagenumberstartwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			txtStartNumber = (TextBox)target;
			txtStartNumber.PreviewTextInput += eHMnMhv8vx;
			break;
		case 2:
			((Button)target).Click += ijVnZT2eYF;
			break;
		case 3:
			((Button)target).Click += Q5anfVee0d;
			break;
		default:
			KYFnssBt8V = true;
			break;
		}
	}

	[CompilerGenerated]
	private void kZYntQtFWC(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void GHrnLYstKu(object P_0, RoutedEventArgs P_1)
	{
		txtStartNumber.Focus();
		txtStartNumber.SelectAll();
	}
}
