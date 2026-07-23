using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using AiSseStreamService3;
using SseStreamInitializer;
using JsonFileDialogHelper;
using NumberFormatConfig;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class GlobalConfigWindow : Window, IComponentConnector
{
	private readonly NumberFormatConfig qVQGscCNQi;

	private bool _bool;

	public GlobalConfigWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		InitializeComponent();
		qVQGscCNQi = new NumberFormatConfig(new JsonFileDialogHelper());
		qVQGscCNQi.add_CloseRequested(base.Close);
		base.DataContext = qVQGscCNQi;
		base.PreviewKeyDown += OrgGL6BKje;
		base.Loaded += GHPdJlwoQG;
	}

	private void OrgGL6BKje(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	private void GHPdJlwoQG(object sender, RoutedEventArgs e)
	{
		try
		{
			TabControl tabControl = FindVisualChild<TabControl>(this);
			if (tabControl == null) return;
			for (int i = tabControl.Items.Count - 1; i >= 0; i--)
			{
				if (tabControl.Items[i] is TabItem tabItem)
				{
					string header = tabItem.Header?.ToString() ?? "";
					if (header.Contains("格式方案") || header.Contains("旧版迁移"))
					{
						tabControl.Items.RemoveAt(i);
					}
				}
			}
		}
		catch { }
	}

	private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
	{
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
		{
			DependencyObject child = VisualTreeHelper.GetChild(parent, i);
			if (child is T result) return result;
			T found = FindVisualChild<T>(child);
			if (found != null) return found;
		}
		return null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/globalconfigwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		_bool = true;
	}
}
