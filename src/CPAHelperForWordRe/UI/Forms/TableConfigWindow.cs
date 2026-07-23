using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using ghWYvT5gdl6wakj5jtn;
using hJKpQrVSwRwMyI2RyDQN;
using HTddqGNLSnobGkrvhXJ;
using ndRERvVtEjasqN2cQqiN;
using vUGRhtGtrlYF1FZxgIZ;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class TableConfigWindow : Window, IComponentConnector
{
	private readonly zq8V4sNtKK1fs0qvdVY tI5C4JoHK5;

	private bool I2tCjHwhcC;

	public TableConfigWindow()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		InitializeComponent();
		tI5C4JoHK5 = new zq8V4sNtKK1fs0qvdVY(new Cscw9SGwoXyXJj7IFKX());
		tI5C4JoHK5.BBoNAij429(base.Close);
		tI5C4JoHK5.QdBN0W28SI(hJsC2ywgN3);
		base.DataContext = tI5C4JoHK5;
		base.PreviewKeyDown += cgPCEufjgs;
	}

	private void cgPCEufjgs(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	private void hJsC2ywgN3()
	{
		rA7neb5TDVvwyWyxwua.IPf5i0ZcV4(new ParagraphConfigWindow());
		Close();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!I2tCjHwhcC)
		{
			I2tCjHwhcC = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/tableconfigwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		I2tCjHwhcC = true;
	}
}
