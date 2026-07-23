using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using PageRange;
using AiSseStreamService3;
using SseStreamInitializer;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class SplitPageRangesWindow : Window, IComponentConnector
{
	private static readonly Regex PageRangeRegex;

	private readonly int _int;

	[CompilerGenerated]
	private IReadOnlyList<PageRange> TIonaklIR2;

	internal TextBox txtRanges;

	internal TextBlock txtHint;

	private bool _bool;

	internal IReadOnlyList<PageRange> PageRanges
	{
		[CompilerGenerated]
		get
		{
			return TIonaklIR2;
		}
		[CompilerGenerated]
		private set
		{
			TIonaklIR2 = value;
		}
	}

	public SplitPageRangesWindow(int totalPages)
	{
		SseStreamInitializer.InitializeRuntime();
		InitializeComponent();
		_int = Math.Max(1, totalPages);
		PageRanges = new List<PageRange>();
		txtHint.Text = string.Format("当前文档共 {0} 页。示例：5 或 8-12 或 3, 8-12, 20-21。", _int);
		base.PreviewKeyDown += delegate(object P_0, KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		base.Loaded += delegate
		{
			txtRanges.Focus();
			txtRanges.SelectAll();
		};
	}

	internal static bool TryParsePageRanges(string P_0, int P_1, out List<PageRange> P_2, out string P_3)
	{
		P_2 = new List<PageRange>();
		P_3 = null;
		if (string.IsNullOrWhiteSpace(P_0))
		{
			P_3 = "请输入需要拆分的页码或页段。";
			return false;
		}
		int num = Math.Max(1, P_1);
		HashSet<int> hashSet = new HashSet<int>();
		string[] array = Regex.Split(P_0.Trim(), "[\\\\r\\\\n,，;；]+");
		foreach (string text in array)
		{
			string text2 = ((text == null) ? string.Empty : text.Trim());
			if (text2.Length == 0)
			{
				continue;
			}
			Match match = PageRangeRegex.Match(text2);
			if (!match.Success)
			{
				P_3 = "页码格式不正确：" + text2;
				return false;
			}
			if (!int.TryParse(match.Groups[1].Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
			{
				P_3 = "页码格式不正确：" + text2;
				return false;
			}
			int result2;
			if (match.Groups[2].Success)
			{
				if (!int.TryParse(match.Groups[2].Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result2))
				{
					P_3 = "页码格式不正确：" + text2;
					return false;
				}
			}
			else
			{
				result2 = result;
			}
			PageRange pageRange = new PageRange(result, result2);
			if (result < 1 || result2 < 1)
			{
				P_3 = "页码必须从 1 开始：" + pageRange.DisplayText;
				return false;
			}
			if (result > result2)
			{
				P_3 = "页段起始页不能大于结束页：" + pageRange.DisplayText;
				return false;
			}
			if (result2 > num)
			{
				P_3 = string.Format("页码不能超过当前文档总页数 {0}：{1}", num, pageRange.DisplayText);
				return false;
			}
			for (int j = result; j <= result2; j++)
			{
				if (!hashSet.Add(j))
				{
					P_3 = "页码范围与前面的输入重复或重叠：" + pageRange.DisplayText;
					return false;
				}
			}
			P_2.Add(pageRange);
		}
		if (P_2.Count == 0)
		{
			P_3 = "请输入需要拆分的页码或页段。";
			return false;
		}
		return true;
	}

	private void OnConfirmButtonClick(object P_0, RoutedEventArgs P_1)
	{
		if (!TryParsePageRanges(txtRanges.Text, _int, out var pageRanges, out var messageBoxText))
		{
			MessageBox.Show(this, messageBoxText, "提示", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			txtRanges.Focus();
			txtRanges.SelectAll();
		}
		else
		{
			PageRanges = pageRanges;
			base.DialogResult = true;
			Close();
		}
	}

	private void crSneQumhk(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/splitpagerangeswindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			txtRanges = (TextBox)target;
			break;
		case 2:
			txtHint = (TextBlock)target;
			break;
		case 3:
			((Button)target).Click += OnConfirmButtonClick;
			break;
		case 4:
			((Button)target).Click += crSneQumhk;
			break;
		default:
			_bool = true;
			break;
		}
	}

	static SplitPageRangesWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		PageRangeRegex = new Regex("^\\\\s*(\\\\d+)\\\\s*(?:[-－—–~～]\\\\s*(\\\\d+)\\\\s*)?$", RegexOptions.Compiled);
	}

	[CompilerGenerated]
	private void OnPreviewKeyDown(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void OnWindowLoaded(object P_0, RoutedEventArgs P_1)
	{
		txtRanges.Focus();
		txtRanges.SelectAll();
	}
}
