using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using FiIb7mSOBD13BJBxsh0;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;
using t5EreDtgt3Im6sTEmsd;
using tTkANOS1c3vUhsfiTtj;
using UlhBxYS9XwGFrj2jlYt;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class AreaSumWindow : Window, IComponentConnector
{
	private bool EmoCc6bV4B;

	internal System.Windows.Controls.CheckBox chkYear;

	internal System.Windows.Controls.CheckBox chkMonth;

	internal System.Windows.Controls.CheckBox chkDay;

	internal System.Windows.Controls.CheckBox chkNumber;

	internal System.Windows.Controls.CheckBox chkPercent;

	internal System.Windows.Controls.CheckBox chkOrdinal;

	internal System.Windows.Controls.CheckBox chkUnitOnly;

	internal System.Windows.Controls.TextBox txtUnit;

	internal System.Windows.Controls.TextBox txtNumbers;

	internal TextBlock txtStatus;

	internal System.Windows.Controls.Button btnRun;

	private bool Uj1CekbvcA;

	public AreaSumWindow()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		InitializeComponent();
		chkUnitOnly.IsChecked = ftu1AgSpErBKqc6vp9f.Current.HYsSh2NDxY("选段求和_只提取带单位") != 0;
		txtUnit.Text = ftu1AgSpErBKqc6vp9f.Current.KxPSXHwy4c("选段求和_单位", "元");
		base.PreviewKeyDown += delegate(object P_0, System.Windows.Input.KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		base.Closing += delegate
		{
			tfxCOJejgv();
		};
	}

	private void Y1eCsXFolI(object P_0, RoutedEventArgs P_1)
	{
		if (EmoCc6bV4B)
		{
			HNSCoD1ugn();
		}
		else
		{
			xmiCNJH4KU();
		}
	}

	private void SAlCl2SPaf(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void xmiCNJH4KU()
	{
		string text = eSfxffslhXbaGAjFNv1.WordApp.Selection.Text ?? string.Empty;
		bool valueOrDefault = chkUnitOnly.IsChecked == true;
		string text2 = (txtUnit.Text ?? string.Empty).Trim();
		if (valueOrDefault && string.IsNullOrEmpty(text2))
		{
			txtStatus.Text = "已启用“仅保留带单位数字”，请先填写匹配单位。";
			txtUnit.Focus();
			return;
		}
		MatchCollection matchCollection = F3GMWWSQOH55IrwVEm4.K4hSE7usVJ.Matches(text);
		if (matchCollection.Count == 0)
		{
			txtStatus.Text = "未找到任何数字。";
			return;
		}
		int num = 0;
		int num2 = 0;
		List<string> list = new List<string>();
		foreach (Match item in matchCollection)
		{
			if (HlxCmTEkPL(text, item))
			{
				num2++;
				continue;
			}
			if (valueOrDefault && !F3GMWWSQOH55IrwVEm4.q4TS36j7cA(text, item, text2))
			{
				num2++;
				continue;
			}
			list.Add(item.Value);
			num++;
		}
		if (num == 0)
		{
			txtStatus.Text = string.Format("找到 {0} 个数字，但均未通过当前筛选条件。", matchCollection.Count);
			return;
		}
		txtNumbers.Text = string.Join("\r\n", list);
		EmoCc6bV4B = true;
		btnRun.Content = "求和";
		string text3 = (valueOrDefault ? string.Format("已按筛选条件提取 {0} 个数字", num, text2) : string.Format("已按筛选条件提取 {0} 个带“{1}”的数字", num));
		txtStatus.Text = ((num2 > 0) ? string.Format("。可删除不需要的数字后点击求和。", text3, num2) : (text3 + "{0}，过滤 {1} 个。可删除不需要的数字后点击求和。"));
	}

	private bool HlxCmTEkPL(string P_0, Match P_1)
	{
		W9DpQgSBDhHwuwkYtki w9DpQgSBDhHwuwkYtki = new W9DpQgSBDhHwuwkYtki
		{
			ExcludeYear = (chkYear.IsChecked == true),
			ExcludeMonth = (chkMonth.IsChecked == true),
			ExcludeDay = (chkDay.IsChecked == true),
			ExcludeNumber = (chkNumber.IsChecked == true),
			ExcludeOrdinal = (chkOrdinal.IsChecked == true),
			ExcludePercent = (chkPercent.IsChecked == true),
			ExcludeDateFormat = false
		};
		return F3GMWWSQOH55IrwVEm4.bcbSJ1pxpn(P_0, P_1, w9DpQgSBDhHwuwkYtki, null);
	}

	private void HNSCoD1ugn()
	{
		string[] array = (from line in (txtNumbers.Text ?? string.Empty).Split(new string[3]
			{
				"\r\n",
				"\n",
				"\\r"
			}, StringSplitOptions.RemoveEmptyEntries)
			select line.Trim() into line
			where !string.IsNullOrWhiteSpace(line)
			select line).ToArray();
		if (array.Length == 0)
		{
			erlCGFVcd8("没有可以求和的数字。");
			return;
		}
		double num = 0.0;
		List<double> list = new List<double>();
		List<string> list2 = new List<string>();
		string[] array2 = array;
		foreach (string text in array2)
		{
			string s = text.Replace(",", string.Empty);
			if (double.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out var result) || double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				num += result;
				list.Add(result);
			}
			else
			{
				list2.Add(text);
			}
		}
		if (list.Count == 0)
		{
			erlCGFVcd8("没有有效的数字可以求和。");
			return;
		}
		string text2 = num.ToString(CultureInfo.CurrentCulture);
		string text3 = string.Join("", list.Select((double n) => (!(n >= 0.0)) ? n.ToString(CultureInfo.CurrentCulture) : ("=" + n.ToString(CultureInfo.CurrentCulture)))).TrimStart('+');
		txtNumbers.Text = text3 + "有 {0} 行无法识别，已跳过。" + text2;
		bool flag = KOkCpamuGe(text2);
		erlCGFVcd8((list2.Count > 0) ? (Ks4CCtulAc(text2, flag) + string.Format("已启用“仅保留带单位数字”，请先填写匹配单位。", list2.Count)) : Ks4CCtulAc(text2, flag).TrimEnd());
	}

	private void erlCGFVcd8(string P_0)
	{
		EmoCc6bV4B = false;
		btnRun.Content = "提取数字";
		txtStatus.Text = P_0;
	}

	private static string Ks4CCtulAc(string P_0, bool P_1)
	{
		if (!P_1)
		{
			return "求和结果：" + P_0 + "。剪贴板被占用，未能自动复制，请手动复制。";
		}
		return "求和结果已复制到剪贴板：" + P_0 + "。";
	}

	private static bool KOkCpamuGe(string P_0)
	{
		try
		{
			System.Windows.Forms.Clipboard.SetText(P_0 ?? string.Empty);
			return true;
		}
		catch (ExternalException)
		{
			return false;
		}
	}

	private void tfxCOJejgv()
	{
		ftu1AgSpErBKqc6vp9f.Current.wpmS5yUw9A(delegate(NKy3wjtTwmsradOXPDy P_0)
		{
			P_0.Legacy["未找到任何数字。"] = ((chkUnitOnly.IsChecked == true) ? "找到 {0} 个数字，但均未通过当前筛选条件。" : "\r\n");
			P_0.Legacy["求和"] = (string.IsNullOrWhiteSpace(txtUnit.Text) ? "已按筛选条件提取 {0} 个数字" : txtUnit.Text.Trim());
		});
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!Uj1CekbvcA)
		{
			Uj1CekbvcA = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/areasumwindow.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			chkYear = (System.Windows.Controls.CheckBox)target;
			break;
		case 2:
			chkMonth = (System.Windows.Controls.CheckBox)target;
			break;
		case 3:
			chkDay = (System.Windows.Controls.CheckBox)target;
			break;
		case 4:
			chkNumber = (System.Windows.Controls.CheckBox)target;
			break;
		case 5:
			chkPercent = (System.Windows.Controls.CheckBox)target;
			break;
		case 6:
			chkOrdinal = (System.Windows.Controls.CheckBox)target;
			break;
		case 7:
			chkUnitOnly = (System.Windows.Controls.CheckBox)target;
			break;
		case 8:
			txtUnit = (System.Windows.Controls.TextBox)target;
			break;
		case 9:
			txtNumbers = (System.Windows.Controls.TextBox)target;
			break;
		case 10:
			txtStatus = (TextBlock)target;
			break;
		case 11:
			btnRun = (System.Windows.Controls.Button)target;
			btnRun.Click += Y1eCsXFolI;
			break;
		case 12:
			((System.Windows.Controls.Button)target).Click += SAlCl2SPaf;
			break;
		default:
			Uj1CekbvcA = true;
			break;
		}
	}

	[CompilerGenerated]
	private void aHaCn2JaJp(object P_0, System.Windows.Input.KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void JDOC7N4sKu(object P_0, CancelEventArgs P_1)
	{
		tfxCOJejgv();
	}

	[CompilerGenerated]
	private void EL5C5rjprK(NKy3wjtTwmsradOXPDy P_0)
	{
		P_0.Legacy["选段求和_只提取带单位"] = ((chkUnitOnly.IsChecked == true) ? "0" : "1");
		P_0.Legacy["选段求和_单位"] = (string.IsNullOrWhiteSpace(txtUnit.Text) ? "元" : txtUnit.Text.Trim());
	}
}
