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
using ndRERvVtEjasqN2cQqiN;

namespace CPAHelperForWordRe.UI.Forms.Common;

public sealed class TextPromptWindow : Window, IComponentConnector
{
	internal TextBlock PromptLabel;

	internal TextBox InputBox;

	private bool bIX5YLHCpy;

	public string InputText => InputBox.Text;

	public TextPromptWindow(string title, string label, string defaultValue)
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		InitializeComponent();
		base.Title = title;
		PromptLabel.Text = label;
		InputBox.Text = defaultValue ?? string.Empty;
		base.ContentRendered += delegate
		{
			InputBox.Focus();
			InputBox.SelectAll();
			Keyboard.Focus(InputBox);
		};
	}

	private void vom54bIIgc(object P_0, RoutedEventArgs P_1)
	{
		base.DialogResult = true;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bIX5YLHCpy)
		{
			bIX5YLHCpy = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/common/textpromptwindow.xaml", UriKind.Relative);
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
			PromptLabel = (TextBlock)target;
			break;
		case 2:
			InputBox = (TextBox)target;
			break;
		case 3:
			((Button)target).Click += vom54bIIgc;
			break;
		default:
			bIX5YLHCpy = true;
			break;
		}
	}

	[CompilerGenerated]
	private void XFc5jJS1aG(object P_0, EventArgs P_1)
	{
		InputBox.Focus();
		InputBox.SelectAll();
		Keyboard.Focus(InputBox);
	}
}
