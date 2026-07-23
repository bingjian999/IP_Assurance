using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using AiSseStreamService3;
using SseStreamInitializer;
using ThousandsSeparatorService;
using UiHelper_4;
using LoggerInitializer;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ThousandsSeparatorConfigWindow : Window, IComponentConnector
{
	internal ComboBox cmbDecimalPlaces;

	internal CheckBox chkYear;

	internal CheckBox chkMonth;

	internal CheckBox chkDay;

	internal CheckBox chkNumber;

	internal CheckBox chkPercent;

	internal CheckBox chkOrdinal;

	internal CheckBox chkDateFormat;

	internal CheckBox chkUnitOnly;

	internal TextBox txtUnit;

	private bool _bool;

	public ThousandsSeparatorConfigWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		InitializeComponent();
		for (int i = 0; i <= 6; i++)
		{
			cmbDecimalPlaces.Items.Add(i.ToString());
		}
		base.PreviewKeyDown += delegate(object P_0, KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		LoadConfigToControls(ThousandsSeparatorService.ReadSeparatorConfig(), ThousandsSeparatorService.GetDecimalPlaces());
	}

	private void OnSaveButtonClick(object P_0, RoutedEventArgs P_1)
	{
		if (vddCqqexkg(out var separatorConfig) && TryGetDecimalPlaces(out var num))
		{
			ThousandsSeparatorService.WriteConfigWithOptions(separatorConfig, num);
			LoggerInitializer.ShowInfo("千分位符配置已保存。", "千分位符配置");
			Close();
		}
	}

	private void OnResetDefaultButtonClick(object P_0, RoutedEventArgs P_1)
	{
		UiHelper_4 separatorConfig = ThousandsSeparatorService.CreateDefaultConfig();
		LoadConfigToControls(separatorConfig, 2);
		ThousandsSeparatorService.WriteConfigWithOptions(separatorConfig, 2);
		LoggerInitializer.ShowInfo("千分位符配置已恢复默认。", "千分位符配置");
	}

	private void rqlCFRtGUg(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void OnUnitOnlyCheckedChanged(object P_0, RoutedEventArgs P_1)
	{
		UpdateUnitTextBoxState();
	}

	private void LoadConfigToControls(UiHelper_4 P_0, int P_1)
	{
		if (P_0 == null)
		{
			P_0 = ThousandsSeparatorService.CreateDefaultConfig();
		}
		cmbDecimalPlaces.Text = ThousandsSeparatorService.ClampDecimalPlaces(P_1).ToString();
		chkYear.IsChecked = P_0.ExcludeYear;
		chkMonth.IsChecked = P_0.ExcludeMonth;
		chkDay.IsChecked = P_0.ExcludeDay;
		chkNumber.IsChecked = P_0.ExcludeNumber;
		chkOrdinal.IsChecked = P_0.ExcludeOrdinal;
		chkPercent.IsChecked = P_0.ExcludePercent;
		chkDateFormat.IsChecked = P_0.ExcludeDateFormat;
		chkUnitOnly.IsChecked = P_0.IncludeUnitOnly;
		txtUnit.Text = gVlCvRBiPn(P_0.UnitText);
		UpdateUnitTextBoxState();
	}

	private bool vddCqqexkg(out UiHelper_4 P_0)
	{
		P_0 = null;
		string unitText = gVlCvRBiPn(txtUnit.Text);
		if (chkUnitOnly.IsChecked == true && string.IsNullOrWhiteSpace(txtUnit.Text))
		{
			LoggerInitializer.ShowWarning("已启用“仅处理带单位数字”，请先填写匹配单位。", "千分位符配置");
			txtUnit.Focus();
			return false;
		}
		P_0 = new UiHelper_4
		{
			ExcludeYear = (chkYear.IsChecked == true),
			ExcludeMonth = (chkMonth.IsChecked == true),
			ExcludeDay = (chkDay.IsChecked == true),
			ExcludeNumber = (chkNumber.IsChecked == true),
			ExcludeOrdinal = (chkOrdinal.IsChecked == true),
			ExcludePercent = (chkPercent.IsChecked == true),
			ExcludeDateFormat = (chkDateFormat.IsChecked == true),
			IncludeUnitOnly = (chkUnitOnly.IsChecked == true),
			UnitText = unitText
		};
		return true;
	}

	private bool TryGetDecimalPlaces(out int P_0)
	{
		P_0 = 2;
		if (!int.TryParse((cmbDecimalPlaces.Text ?? string.Empty).Trim(), out var result) || result < 0 || result > 6)
		{
			LoggerInitializer.ShowWarning("千分位符小数位数请输入 0 到 6 之间的整数。", "千分位符配置");
			cmbDecimalPlaces.Focus();
			return false;
		}
		P_0 = result;
		return true;
	}

	private void UpdateUnitTextBoxState()
	{
		txtUnit.IsEnabled = chkUnitOnly.IsChecked == true;
	}

	private static string gVlCvRBiPn(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			return P_0.Trim();
		}
		return "元";
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/thousandsseparatorconfigwindow.xaml", UriKind.Relative);
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
			cmbDecimalPlaces = (ComboBox)target;
			break;
		case 2:
			chkYear = (CheckBox)target;
			break;
		case 3:
			chkMonth = (CheckBox)target;
			break;
		case 4:
			chkDay = (CheckBox)target;
			break;
		case 5:
			chkNumber = (CheckBox)target;
			break;
		case 6:
			chkPercent = (CheckBox)target;
			break;
		case 7:
			chkOrdinal = (CheckBox)target;
			break;
		case 8:
			chkDateFormat = (CheckBox)target;
			break;
		case 9:
			chkUnitOnly = (CheckBox)target;
			chkUnitOnly.Checked += OnUnitOnlyCheckedChanged;
			chkUnitOnly.Unchecked += OnUnitOnlyCheckedChanged;
			break;
		case 10:
			txtUnit = (TextBox)target;
			break;
		case 11:
			((Button)target).Click += OnSaveButtonClick;
			break;
		case 12:
			((Button)target).Click += OnResetDefaultButtonClick;
			break;
		case 13:
			((Button)target).Click += rqlCFRtGUg;
			break;
		default:
			_bool = true;
			break;
		}
	}

	[CompilerGenerated]
	private void OnPreviewKeyDown(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}
}
