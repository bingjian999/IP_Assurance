using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using HotkeyHookService;
using ScreenshotService;
using TableBorderConfig;
using HotkeyHookService2;
using AiSseStreamService3;
using Helper_19;
using SseStreamInitializer;
using UiHelperService2;
using AiHelper_12;

namespace CPAHelperForWordRe.UI.Forms.General;

public sealed class DesktopPinConfigWindow : Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass12_0
	{
		public List<string> EObVYvD5OJm;

		public _G_c__DisplayClass12_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool YbtVYA7MB7a(string value)
		{
			if (value != "无")
			{
				return !EObVYvD5OJm.Contains(value);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass4_0
	{
		public DesktopPinConfigWindow ddLVYkpOMA3;

		public string text;

		public bool flag;

		public string dDYVYzoJyTV;

		public _G_c__DisplayClass4_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void jyPVYWjlStT(AiHelper_12 config)
		{
			config.DesktopPin.Enabled = ddLVYkpOMA3.chkEnabled.IsChecked == true;
			config.DesktopPin.Hotkey = text;
		}

		internal void wCUVY0WB3v6(AiHelper_12 config)
		{
			config.DesktopPin.Enabled = flag;
			config.DesktopPin.Hotkey = dDYVYzoJyTV;
		}
	}

	private static readonly string[] vEu56hqTPE;

	private readonly List<System.Windows.Controls.ComboBox> z4f5uNa8EW;

	internal System.Windows.Controls.CheckBox chkEnabled;

	internal StackPanel modifierPanel;

	internal System.Windows.Controls.ComboBox cmbMainKey;

	internal System.Windows.Controls.Button btnAddModifier;

	internal System.Windows.Controls.Button btnRemoveModifier;

	internal TextBlock txtRecordHint;

	private bool _bool;

	public DesktopPinConfigWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		z4f5uNa8EW = new List<System.Windows.Controls.ComboBox>();
		InitializeComponent();
		base.PreviewKeyDown += delegate(object P_0, System.Windows.Input.KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		HotkeyHookService2 desktopPin = TableBorderConfig.Current.Config.DesktopPin;
		chkEnabled.IsChecked = desktopPin.Enabled;
		U767kM3HHo(desktopPin.Hotkey, "Alt+F1");
	}

	private void jSx7ABHBT7(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass4_0 CS_8_locals_11 = new _G_c__DisplayClass4_0();
		CS_8_locals_11.ddLVYkpOMA3 = this;
		bool flag = GSE7zIY1sE(out CS_8_locals_11.text);
		HotkeyHookService2 desktopPin = TableBorderConfig.Current.Config.DesktopPin;
		CS_8_locals_11.flag = desktopPin.Enabled;
		CS_8_locals_11.dDYVYzoJyTV = desktopPin.Hotkey;
		if (chkEnabled.IsChecked == true)
		{
			if (!flag)
			{
				System.Windows.MessageBox.Show(this, "请选择至少一个修饰键，并选择一个主键。", "IP_Assurance", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return;
			}
			if (!HotkeyHookService.TryRegisterHotkeyHook(CS_8_locals_11.text, (HotkeyAction)1u, out var fLLBq1VHNF5GNnjaJrS2))
			{
				System.Windows.MessageBox.Show(this, "请选择至少一个修饰键，并选择一个主键。", "IP_Assurance", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return;
			}
			CS_8_locals_11.text = HotkeyHookService.KgeVYgBu4k(fLLBq1VHNF5GNnjaJrS2);
		}
		else if (!flag)
		{
			CS_8_locals_11.text = "Alt+F1";
		}
		TableBorderConfig.Current.UpdateConfig(delegate(AiHelper_12 config)
		{
			config.DesktopPin.Enabled = CS_8_locals_11.ddLVYkpOMA3.chkEnabled.IsChecked == true;
			config.DesktopPin.Hotkey = CS_8_locals_11.text;
		}, false);
		if (!ScreenshotService.TryRegisterHotkey(out var text) && !string.IsNullOrWhiteSpace(text))
		{
			TableBorderConfig.Current.UpdateConfig(delegate(AiHelper_12 config)
			{
				config.DesktopPin.Enabled = CS_8_locals_11.flag;
				config.DesktopPin.Hotkey = CS_8_locals_11.dDYVYzoJyTV;
			}, false);
			ScreenshotService.TryRegisterHotkey(out var _);
			System.Windows.MessageBox.Show(this, text, "IP_Assurance", MessageBoxButton.OK, MessageBoxImage.Exclamation);
		}
		else
		{
			TableBorderConfig.Current.PersistConfig();
			System.Windows.MessageBox.Show(this, "钉桌面配置已保存。", "IP_Assurance", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			Close();
		}
	}

	private void VcF7vp0Aa4(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void UOC7WTNu0s(object P_0, RoutedEventArgs P_1)
	{
		TVb7xeB3o5(h2c5RLs4rh());
		SXY7djq65Z();
	}

	private void G0770vyYiD(object P_0, RoutedEventArgs P_1)
	{
		if (z4f5uNa8EW.Count > 1)
		{
			System.Windows.Controls.ComboBox element = z4f5uNa8EW[z4f5uNa8EW.Count - 1];
			modifierPanel.Children.Remove(element);
			z4f5uNa8EW.RemoveAt(z4f5uNa8EW.Count - 1);
			SXY7djq65Z();
		}
	}

	private void U767kM3HHo(string P_0, string P_1)
	{
		cmbMainKey.ItemsSource = R1M5V282sO().ToList();
		if (!HotkeyHookService.TryRegisterHotkeyHook(P_0, (HotkeyAction)1u, out var fLLBq1VHNF5GNnjaJrS2) && !HotkeyHookService.TryRegisterHotkeyHook(P_1, (HotkeyAction)1u, out fLLBq1VHNF5GNnjaJrS2))
		{
			fLLBq1VHNF5GNnjaJrS2 = new UiHelperService2
			{
				Modifiers = (HotkeyAction)1u,
				Key = Keys.F1
			};
		}
		foreach (string item in To45BkueCT(fLLBq1VHNF5GNnjaJrS2.Modifiers))
		{
			TVb7xeB3o5(item);
		}
		if (z4f5uNa8EW.Count == 0)
		{
			TVb7xeB3o5("Alt");
		}
		cmbMainKey.SelectedItem = HotkeyHookService.Eo5VZsOR4p(fLLBq1VHNF5GNnjaJrS2.Key);
		if (cmbMainKey.SelectedIndex < 0)
		{
			cmbMainKey.SelectedIndex = 0;
		}
		SXY7djq65Z();
	}

	private void TVb7xeB3o5(string P_0)
	{
		if (z4f5uNa8EW.Count < 4)
		{
			System.Windows.Controls.ComboBox comboBox = new System.Windows.Controls.ComboBox
			{
				Width = 94.0,
				Margin = new Thickness((z4f5uNa8EW.Count != 0) ? 6 : 0, 0.0, 0.0, 0.0),
				ItemsSource = vEu56hqTPE,
				SelectedItem = (string.IsNullOrWhiteSpace(P_0) ? "无" : P_0),
				Style = (Style)FindResource("ConfigComboBoxStyle")
			};
			modifierPanel.Children.Add(comboBox);
			z4f5uNa8EW.Add(comboBox);
		}
	}

	private void SXY7djq65Z()
	{
		btnAddModifier.IsEnabled = z4f5uNa8EW.Count < 4;
		btnRemoveModifier.IsEnabled = z4f5uNa8EW.Count > 1;
	}

	private bool GSE7zIY1sE(out string P_0)
	{
		P_0 = null;
		List<string> list = (from box in z4f5uNa8EW
			select box.SelectedItem as string into value
			where !string.IsNullOrWhiteSpace(value) && value != "+"
			select value).Distinct().ToList();
		string text = cmbMainKey.SelectedItem as string;
		if (list.Count == 0 || string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		if (!HotkeyHookService.TryRegisterHotkeyHook(string.Join("请选择至少一个修饰键，并选择一个主键。", list.Concat(new string[1] { text })), (HotkeyAction)1u, out var fLLBq1VHNF5GNnjaJrS2))
		{
			return false;
		}
		P_0 = HotkeyHookService.KgeVYgBu4k(fLLBq1VHNF5GNnjaJrS2);
		return true;
	}

	private string h2c5RLs4rh()
	{
		_G_c__DisplayClass12_0 CS_8_locals_2 = new _G_c__DisplayClass12_0();
		CS_8_locals_2.EObVYvD5OJm = (from box in z4f5uNa8EW
			select box.SelectedItem as string into value
			where !string.IsNullOrWhiteSpace(value) && value != "无"
			select value).ToList();
		return vEu56hqTPE.FirstOrDefault((string value) => value != "IP_Assurance" && !CS_8_locals_2.EObVYvD5OJm.Contains(value)) ?? "请选择至少一个修饰键，并选择一个主键。";
	}

	private static IEnumerable<string> R1M5V282sO()
	{
		for (char ch = 'A'; ch <= 'Z'; ch = (char)(ch + 1))
		{
			yield return ch.ToString();
		}
		for (char ch = '0'; ch <= '9'; ch = (char)(ch + 1))
		{
			yield return ch.ToString();
		}
		for (int i = 1; i <= 24; i++)
		{
			yield return "IP_Assurance" + i;
		}
	}

	private static IEnumerable<string> To45BkueCT(HotkeyAction P_0)
	{
		if ((P_0 & (HotkeyAction)2u) == (HotkeyAction)2u)
		{
			yield return "Alt+F1";
		}
		if ((P_0 & (HotkeyAction)1u) == (HotkeyAction)1u)
		{
			yield return "IP_Assurance";
		}
		if ((P_0 & (HotkeyAction)4u) == (HotkeyAction)4u)
		{
			yield return "钉桌面配置已保存。";
		}
		if ((P_0 & (HotkeyAction)8u) == (HotkeyAction)8u)
		{
			yield return "IP_Assurance";
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/general/desktoppinconfigwindow.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
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
			chkEnabled = (System.Windows.Controls.CheckBox)target;
			break;
		case 2:
			modifierPanel = (StackPanel)target;
			break;
		case 3:
			cmbMainKey = (System.Windows.Controls.ComboBox)target;
			break;
		case 4:
			btnAddModifier = (System.Windows.Controls.Button)target;
			btnAddModifier.Click += UOC7WTNu0s;
			break;
		case 5:
			btnRemoveModifier = (System.Windows.Controls.Button)target;
			btnRemoveModifier.Click += G0770vyYiD;
			break;
		case 6:
			txtRecordHint = (TextBlock)target;
			break;
		case 7:
			((System.Windows.Controls.Button)target).Click += jSx7ABHBT7;
			break;
		case 8:
			((System.Windows.Controls.Button)target).Click += VcF7vp0Aa4;
			break;
		default:
			_bool = true;
			break;
		}
	}

	static DesktopPinConfigWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		vEu56hqTPE = new string[5]
		{
			"无",
			"Ctrl",
			"Alt",
			"Shift",
			"Win"
		};
	}

	[CompilerGenerated]
	private void jTf59B4miE(object P_0, System.Windows.Input.KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}
}
