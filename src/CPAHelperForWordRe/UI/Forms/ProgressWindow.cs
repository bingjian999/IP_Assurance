using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using AiSseStreamService3;
using SseStreamInitializer;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ProgressWindow : Window, IComponentConnector
{
	[CompilerGenerated]
	private bool _isCancelRequested;

	internal TextBlock txtMessage;

	internal ProgressBar barProgress;

	private bool _bool;

	public bool IsCancelRequested
	{
		[CompilerGenerated]
		get
		{
			return _isCancelRequested;
		}
		[CompilerGenerated]
		private set
		{
			_isCancelRequested = value;
		}
	}

	public ProgressWindow()
	{
		SseStreamInitializer.InitializeRuntime();
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

	private void OnCancelButtonClick(object P_0, RoutedEventArgs P_1)
	{
		IsCancelRequested = true;
		Close();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
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
			((Button)target).Click += OnCancelButtonClick;
			break;
		default:
			_bool = true;
			break;
		}
	}
}
