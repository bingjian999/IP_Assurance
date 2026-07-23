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
		public List<string> selectedModifiers;

		public _G_c__DisplayClass12_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool isModifierAvailable(string value)
		{
			if (value != "无")
			{
				return !selectedModifiers.Contains(value);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass4_0
	{
		public DesktopPinConfigWindow configWindow;

		public string text;

		public bool flag;

		public string originalHotkey;

		public _G_c__DisplayClass4_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void applyNewConfig(AiHelper_12 config)
		{
			config.DesktopPin.Enabled = configWindow.chkEnabled.IsChecked == true;
			config.DesktopPin.Hotkey = text;
		}

		internal void restoreOriginalConfig(AiHelper_12 config)
		{
			config.DesktopPin.Enabled = flag;
			config.DesktopPin.Hotkey = originalHotkey;
		}
	}

	private static readonly string[] modifierOptions;

	private readonly List<System.Windows.Controls.ComboBox> modifierComboBoxes;

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
		modifierComboBoxes = new List<System.Windows.Controls.ComboBox>();
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
		loadHotkeyConfig(desktopPin.Hotkey, "Alt+F1");
	}

	private void onSaveClick(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass4_0 CS_8_locals_11 = new _G_c__DisplayClass4_0();
		CS_8_locals_11.configWindow = this;
		bool flag = tryBuildHotkeyString(out CS_8_locals_11.text);
		HotkeyHookService2 desktopPin = TableBorderConfig.Current.Config.DesktopPin;
		CS_8_locals_11.flag = desktopPin.Enabled;
		CS_8_locals_11.originalHotkey = desktopPin.Hotkey;
		if (chkEnabled.IsChecked == true)
		{
			if (!flag)
			{
				System.Windows.MessageBox.Show(this, "请选择至少一个修饰键，并选择一个主键。", "IP_Assurance", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return;
			}
			if (!HotkeyHookService.TryRegisterHotkeyHook(CS_8_locals_11.text, (HotkeyAction)1u, out var hotkeyHook))
			{
				System.Windows.MessageBox.Show(this, "请选择至少一个修饰键，并选择一个主键。", "IP_Assurance", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return;
			}
			CS_8_locals_11.text = HotkeyHookService.formatHotkeyString(hotkeyHook);
		}
		else if (!flag)
		{
			CS_8_locals_11.text = "Alt+F1";
		}
		TableBorderConfig.Current.UpdateConfig(delegate(AiHelper_12 config)
		{
			config.DesktopPin.Enabled = CS_8_locals_11.configWindow.chkEnabled.IsChecked == true;
			config.DesktopPin.Hotkey = CS_8_locals_11.text;
		}, false);
		if (!ScreenshotService.TryRegisterHotkey(out var text) && !string.IsNullOrWhiteSpace(text))
		{
			TableBorderConfig.Current.UpdateConfig(delegate(AiHelper_12 config)
			{
				config.DesktopPin.Enabled = CS_8_locals_11.flag;
				config.DesktopPin.Hotkey = CS_8_locals_11.originalHotkey;
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

	private void onCancelClick(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void onAddModifierClick(object P_0, RoutedEventArgs P_1)
	{
		addModifierComboBox(findAvailableModifier());
		updateModifierButtonStates();
	}

	private void onRemoveModifierClick(object P_0, RoutedEventArgs P_1)
	{
		if (modifierComboBoxes.Count > 1)
		{
			System.Windows.Controls.ComboBox element = modifierComboBoxes[modifierComboBoxes.Count - 1];
			modifierPanel.Children.Remove(element);
			modifierComboBoxes.RemoveAt(modifierComboBoxes.Count - 1);
			updateModifierButtonStates();
		}
	}

	private void loadHotkeyConfig(string P_0, string P_1)
	{
		cmbMainKey.ItemsSource = getMainKeyOptions().ToList();
		if (!HotkeyHookService.TryRegisterHotkeyHook(P_0, (HotkeyAction)1u, out var hotkeyHook) && !HotkeyHookService.TryRegisterHotkeyHook(P_1, (HotkeyAction)1u, out hotkeyHook))
		{
			hotkeyHook = new UiHelperService2
			{
				Modifiers = (HotkeyAction)1u,
				Key = Keys.F1
			};
		}
		foreach (string item in modifiersToStrings(hotkeyHook.Modifiers))
		{
			addModifierComboBox(item);
		}
		if (modifierComboBoxes.Count == 0)
		{
			addModifierComboBox("Alt");
		}
		cmbMainKey.SelectedItem = HotkeyHookService.keyToDisplayString(hotkeyHook.Key);
		if (cmbMainKey.SelectedIndex < 0)
		{
			cmbMainKey.SelectedIndex = 0;
		}
		updateModifierButtonStates();
	}

	private void addModifierComboBox(string P_0)
	{
		if (modifierComboBoxes.Count < 4)
		{
			System.Windows.Controls.ComboBox comboBox = new System.Windows.Controls.ComboBox
			{
				Width = 94.0,
				Margin = new Thickness((modifierComboBoxes.Count != 0) ? 6 : 0, 0.0, 0.0, 0.0),
				ItemsSource = modifierOptions,
				SelectedItem = (string.IsNullOrWhiteSpace(P_0) ? "无" : P_0),
				Style = (Style)FindResource("ConfigComboBoxStyle")
			};
			modifierPanel.Children.Add(comboBox);
			modifierComboBoxes.Add(comboBox);
		}
	}

	private void updateModifierButtonStates()
	{
		btnAddModifier.IsEnabled = modifierComboBoxes.Count < 4;
		btnRemoveModifier.IsEnabled = modifierComboBoxes.Count > 1;
	}

	private bool tryBuildHotkeyString(out string P_0)
	{
		P_0 = null;
		List<string> list = (from box in modifierComboBoxes
			select box.SelectedItem as string into value
			where !string.IsNullOrWhiteSpace(value) && value != "+"
			select value).Distinct().ToList();
		string text = cmbMainKey.SelectedItem as string;
		if (list.Count == 0 || string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		if (!HotkeyHookService.TryRegisterHotkeyHook(string.Join("请选择至少一个修饰键，并选择一个主键。", list.Concat(new string[1] { text })), (HotkeyAction)1u, out var hotkeyHook))
		{
			return false;
		}
		P_0 = HotkeyHookService.formatHotkeyString(hotkeyHook);
		return true;
	}

	private string findAvailableModifier()
	{
		_G_c__DisplayClass12_0 CS_8_locals_2 = new _G_c__DisplayClass12_0();
		CS_8_locals_2.selectedModifiers = (from box in modifierComboBoxes
			select box.SelectedItem as string into value
			where !string.IsNullOrWhiteSpace(value) && value != "无"
			select value).ToList();
		return modifierOptions.FirstOrDefault((string value) => value != "IP_Assurance" && !CS_8_locals_2.selectedModifiers.Contains(value)) ?? "请选择至少一个修饰键，并选择一个主键。";
	}

	private static IEnumerable<string> getMainKeyOptions()
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

	private static IEnumerable<string> modifiersToStrings(HotkeyAction P_0)
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
			btnAddModifier.Click += onAddModifierClick;
			break;
		case 5:
			btnRemoveModifier = (System.Windows.Controls.Button)target;
			btnRemoveModifier.Click += onRemoveModifierClick;
			break;
		case 6:
			txtRecordHint = (TextBlock)target;
			break;
		case 7:
			((System.Windows.Controls.Button)target).Click += onSaveClick;
			break;
		case 8:
			((System.Windows.Controls.Button)target).Click += onCancelClick;
			break;
		default:
			_bool = true;
			break;
		}
	}

	static DesktopPinConfigWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		modifierOptions = new string[5]
		{
			"无",
			"Ctrl",
			"Alt",
			"Shift",
			"Win"
		};
	}

	[CompilerGenerated]
	private void onPreviewKeyDown(object P_0, System.Windows.Input.KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}
}
