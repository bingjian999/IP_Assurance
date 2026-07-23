using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ProgressWindow : Window, IComponentConnector
{
	[CompilerGenerated]
	private bool JC4njWCqLg;

	internal TextBlock txtMessage;

	internal ProgressBar barProgress;

	private bool i9xnYixbJ7;

	public bool IsCancelRequested
	{
		[CompilerGenerated]
		get
		{
			return JC4njWCqLg;
		}
		[CompilerGenerated]
		private set
		{
			JC4njWCqLg = value;
		}
	}

	public ProgressWindow()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		InitializeComponent();
	}

	public void SetProgress(int percent, string message = null)
	{
		if (percent < 0)
		{
			percent = 0;
		}
		if (percent > 100)
		{
			percent = 100;
		}
		barProgress.Value = percent;
		if (!string.IsNullOrWhiteSpace(message))
		{
			txtMessage.Text = message;
		}
	}

	private void flxn4AA95q(object P_0, RoutedEventArgs P_1)
	{
		IsCancelRequested = true;
		Close();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!i9xnYixbJ7)
		{
			i9xnYixbJ7 = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/progresswindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			txtMessage = (TextBlock)target;
			break;
		case 2:
			barProgress = (ProgressBar)target;
			break;
		case 3:
			((Button)target).Click += flxn4AA95q;
			break;
		default:
			i9xnYixbJ7 = true;
			break;
		}
	}
}
