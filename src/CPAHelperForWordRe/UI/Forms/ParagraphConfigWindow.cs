using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using ghWYvT5gdl6wakj5jtn;
using hJKpQrVSwRwMyI2RyDQN;
using KcMwAolTikpycTfSXMj;
using ndRERvVtEjasqN2cQqiN;
using vUGRhtGtrlYF1FZxgIZ;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ParagraphConfigWindow : Window, IComponentConnector
{
	private readonly SnpZ0hlDCfiubxnCjcr i9eCUPlAlM;

	private bool erTCKRYVh2;

	public ParagraphConfigWindow()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		InitializeComponent();
		i9eCUPlAlM = new SnpZ0hlDCfiubxnCjcr(new Cscw9SGwoXyXJj7IFKX());
		i9eCUPlAlM.Y0ZlOZZU1c(base.Close);
		i9eCUPlAlM.hQml5xuThg(dTqC3t4uPZ);
		base.DataContext = i9eCUPlAlM;
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
		rA7neb5TDVvwyWyxwua.IPf5i0ZcV4(new TableConfigWindow());
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
