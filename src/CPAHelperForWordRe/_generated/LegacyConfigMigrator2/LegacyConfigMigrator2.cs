using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using Helper_14;
using AiHelper_20;
using Helper_12;
using TableBorderConfig;
using AiSseStreamService3;
using ConfigHelper_1;
using DelegateCommand;
using SseStreamInitializer;
using Helper_2;

namespace LegacyConfigMigrator2;

internal sealed class LegacyConfigMigrator2 : Helper_2
{
	private static readonly string[] WTalydwU2G;

	private static readonly string[] u2KlXNUBeC;

	private readonly ConfigHelper_1 WvflFuaXMm;

	private readonly HDS8hJGbnCWyNGfO01j _hDS8hJGbnCWyNGfO01j;

	private readonly Dictionary<string, string> Oppla8MvS7;

	private bool _bool;

	private string _selectedPreset;

	private string eOilAwjRjm;

	private string _chineseFont;

	private string HlBlWECXrD;

	private string _fontSize;

	private bool gSElkxPsNa;

	private string hgRlxflIIl;

	private string _lineSpacingRule;

	private string NaWlznssvC;

	private string _spacingUnit;

	private string koYNVIJhgU;

	private string _spaceAfter;

	private string _indentUnit;

	private string _leftIndent;

	private string _rightIndent;

	private string _specialIndent;

	private string _indentValue;

	private bool UwNNgEHlFd;

	private bool _supportsSpacing;

	private bool TEMNIEYRSA;

	private bool _supportsIndent;

	private bool _supportsBold;

	[CompilerGenerated]
	private Action _action;

	[CompilerGenerated]
	private Action _action;

	[CompilerGenerated]
	private readonly ObservableCollection<string> ea6Nrhmeu1;

	[CompilerGenerated]
	private readonly ObservableCollection<string> fLLNJFnKRD;

	[CompilerGenerated]
	private readonly ObservableCollection<string> Ya5N3623YN;

	[CompilerGenerated]
	private readonly ObservableCollection<string> MWkNUbk5wX;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> BAjNKUBXWP;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> vkQNEWgDDK;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> FjVN29oUiv;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> KcxN4MUHF3;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> eLRNjIvbe0;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand jhONbXOfRa;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand yPwNwXtvLW;

	public ObservableCollection<string> PresetNames
	{
		[CompilerGenerated]
		get
		{
			return ea6Nrhmeu1;
		}
	}

	public ObservableCollection<string> Levels
	{
		[CompilerGenerated]
		get
		{
			return fLLNJFnKRD;
		}
	}

	public ObservableCollection<string> Fonts
	{
		[CompilerGenerated]
		get
		{
			return Ya5N3623YN;
		}
	}

	public ObservableCollection<string> FontSizes
	{
		[CompilerGenerated]
		get
		{
			return MWkNUbk5wX;
		}
	}

	public ObservableCollection<Helper_14> SpacingUnits
	{
		[CompilerGenerated]
		get
		{
			return BAjNKUBXWP;
		}
	}

	public ObservableCollection<Helper_14> Alignments
	{
		[CompilerGenerated]
		get
		{
			return vkQNEWgDDK;
		}
	}

	public ObservableCollection<Helper_14> IndentUnits
	{
		[CompilerGenerated]
		get
		{
			return FjVN29oUiv;
		}
	}

	public ObservableCollection<Helper_14> SpecialIndents
	{
		[CompilerGenerated]
		get
		{
			return KcxN4MUHF3;
		}
	}

	public ObservableCollection<Helper_14> LineSpacingRules
	{
		[CompilerGenerated]
		get
		{
			return eLRNjIvbe0;
		}
	}

	public ICommand NewPresetCommand
	{
		[CompilerGenerated]
		get
		{
			return _iCommand;
		}
	}

	public ICommand DeletePresetCommand
	{
		[CompilerGenerated]
		get
		{
			return _iCommand;
		}
	}

	public ICommand ImportPresetCommand
	{
		[CompilerGenerated]
		get
		{
			return _iCommand;
		}
	}

	public ICommand ExportPresetCommand
	{
		[CompilerGenerated]
		get
		{
			return _iCommand;
		}
	}

	public ICommand SaveCommand
	{
		[CompilerGenerated]
		get
		{
			return jhONbXOfRa;
		}
	}

	public ICommand OpenTableCommand
	{
		[CompilerGenerated]
		get
		{
			return _iCommand;
		}
	}

	public ICommand CloseCommand
	{
		[CompilerGenerated]
		get
		{
			return yPwNwXtvLW;
		}
	}

	public string SelectedPreset
	{
		get
		{
			return _selectedPreset;
		}
		set
		{
			if (!_bool && !string.Equals(_selectedPreset, value, StringComparison.Ordinal))
			{
				YMDlQr1r9A(value);
			}
		}
	}

	public string SelectedLevel
	{
		get
		{
			return eOilAwjRjm;
		}
		set
		{
			if (!_bool && !string.IsNullOrWhiteSpace(value) && !string.Equals(eOilAwjRjm, value, StringComparison.Ordinal))
			{
				if (!FdUlJ0WwMF())
				{
					fpVsxno8nm("SelectedLevel");
					return;
				}
				eOilAwjRjm = value;
				fpVsxno8nm("SelectedLevel");
				o3XlrGPH47(value);
			}
		}
	}

	public string ChineseFont
	{
		get
		{
			return _chineseFont;
		}
		set
		{
			MrCsWWMvwp(ref _chineseFont, value, "ChineseFont");
		}
	}

	public string WesternFont
	{
		get
		{
			return HlBlWECXrD;
		}
		set
		{
			MrCsWWMvwp(ref HlBlWECXrD, value, "WesternFont");
		}
	}

	public string FontSize
	{
		get
		{
			return _fontSize;
		}
		set
		{
			MrCsWWMvwp(ref _fontSize, value, "FontSize");
		}
	}

	public bool Bold
	{
		get
		{
			return gSElkxPsNa;
		}
		set
		{
			MrCsWWMvwp(ref gSElkxPsNa, value, "Bold");
		}
	}

	public string Alignment
	{
		get
		{
			return hgRlxflIIl;
		}
		set
		{
			MrCsWWMvwp(ref hgRlxflIIl, value, "Alignment");
		}
	}

	public string LineSpacingRule
	{
		get
		{
			return _lineSpacingRule;
		}
		set
		{
			if (MrCsWWMvwp(ref _lineSpacingRule, value, "LineSpacingRule"))
			{
				fpVsxno8nm("LineSpacingLabel");
				fpVsxno8nm("IsLineSpacingValueEnabled");
			}
		}
	}

	public string LineSpacing
	{
		get
		{
			return NaWlznssvC;
		}
		set
		{
			MrCsWWMvwp(ref NaWlznssvC, value, "LineSpacing");
		}
	}

	public string SpacingUnit
	{
		get
		{
			return _spacingUnit;
		}
		set
		{
			MrCsWWMvwp(ref _spacingUnit, value, "SpacingUnit");
		}
	}

	public string SpaceBefore
	{
		get
		{
			return koYNVIJhgU;
		}
		set
		{
			MrCsWWMvwp(ref koYNVIJhgU, value, "SpaceBefore");
		}
	}

	public string SpaceAfter
	{
		get
		{
			return _spaceAfter;
		}
		set
		{
			MrCsWWMvwp(ref _spaceAfter, value, "SpaceAfter");
		}
	}

	public string IndentUnit
	{
		get
		{
			return _indentUnit;
		}
		set
		{
			MrCsWWMvwp(ref _indentUnit, value, "IndentUnit");
		}
	}

	public string LeftIndent
	{
		get
		{
			return _leftIndent;
		}
		set
		{
			MrCsWWMvwp(ref _leftIndent, value, "LeftIndent");
		}
	}

	public string RightIndent
	{
		get
		{
			return _rightIndent;
		}
		set
		{
			MrCsWWMvwp(ref _rightIndent, value, "RightIndent");
		}
	}

	public string SpecialIndent
	{
		get
		{
			return _specialIndent;
		}
		set
		{
			MrCsWWMvwp(ref _specialIndent, value, "SpecialIndent");
		}
	}

	public string IndentValue
	{
		get
		{
			return _indentValue;
		}
		set
		{
			MrCsWWMvwp(ref _indentValue, value, "IndentValue");
		}
	}

	public bool SupportsFont
	{
		get
		{
			return UwNNgEHlFd;
		}
		private set
		{
			MrCsWWMvwp(ref UwNNgEHlFd, value, "SelectedLevel");
		}
	}

	public bool SupportsSpacing
	{
		get
		{
			return _supportsSpacing;
		}
		private set
		{
			MrCsWWMvwp(ref _supportsSpacing, value, "SelectedLevel");
		}
	}

	public bool SupportsAlignment
	{
		get
		{
			return TEMNIEYRSA;
		}
		private set
		{
			MrCsWWMvwp(ref TEMNIEYRSA, value, "ChineseFont");
		}
	}

	public bool SupportsIndent
	{
		get
		{
			return _supportsIndent;
		}
		private set
		{
			MrCsWWMvwp(ref _supportsIndent, value, "WesternFont");
		}
	}

	public bool SupportsBold
	{
		get
		{
			return _supportsBold;
		}
		private set
		{
			MrCsWWMvwp(ref _supportsBold, value, "FontSize");
		}
	}

	public string LineSpacingLabel
	{
		get
		{
			if (!(LineSpacingRule == "3") && !(LineSpacingRule == "4"))
			{
				if (!(LineSpacingRule == "5"))
				{
					return "设置值";
				}
				return "设置值(倍数)";
			}
			return "设置值(磅)";
		}
	}

	public bool IsLineSpacingValueEnabled
	{
		get
		{
			if (!(LineSpacingRule == "3") && !(LineSpacingRule == "4"))
			{
				return LineSpacingRule == "5";
			}
			return true;
		}
	}

	public LegacyConfigMigrator2(HDS8hJGbnCWyNGfO01j P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		WvflFuaXMm = new ConfigHelper_1("段落预设");
		Oppla8MvS7 = new Dictionary<string, string>();
		eOilAwjRjm = "一级";
		ea6Nrhmeu1 = new ObservableCollection<string>();
		_hDS8hJGbnCWyNGfO01j = P_0 ?? throw new ArgumentNullException("dialogs");
		fLLNJFnKRD = new ObservableCollection<string>(new string[9]
		{
			"一级",
			"二级",
			"三级",
			"四级",
			"五级",
			"其他",
			"表前单位",
			"表后注释",
			"表后间距"
		});
		Ya5N3623YN = new ObservableCollection<string>(new string[9]
		{
			"宋体",
			"黑体",
			"微软雅黑",
			"楷体",
			"仿宋",
			"等线",
			"Arial",
			"Times New Roman",
			"Calibri"
		});
		MWkNUbk5wX = new ObservableCollection<string>(from item in AiHelper_20.csfwB6TYGU()
			select item.Item2);
		BAjNKUBXWP = LchlgaLZpb(("行", "行"), ("磅", "磅"));
		vkQNEWgDDK = LchlgaLZpb(("左对齐", "0"), ("居中", "1"), ("右对齐", "2"), ("两端对齐", "3"));
		FjVN29oUiv = LchlgaLZpb(("字符", "字符"), ("厘米", "厘米"));
		KcxN4MUHF3 = LchlgaLZpb(("首行", "首行"), ("悬挂", "悬挂"), ("无", "无"));
		eLRNjIvbe0 = LchlgaLZpb(("单倍行距", "0"), ("1.5倍行距", "1"), ("双倍行距", "2"), ("最小值", "3"), ("固定值", "4"), ("多倍行距", "5"));
		_iCommand = new DelegateCommand(DDClUp83O8);
		_iCommand = new DelegateCommand(DG8lKsffse);
		_iCommand = new DelegateCommand(DOklEaplEE);
		_iCommand = new DelegateCommand(KcQl2YSaFW);
		jhONbXOfRa = new DelegateCommand(CO7l40Llb1);
		_iCommand = new DelegateCommand((Action)delegate
		{
			_action?.Invoke();
		}, (Func<bool>)null);
		yPwNwXtvLW = new DelegateCommand((Action)delegate
		{
			_action?.Invoke();
		}, (Func<bool>)null);
		oajl8u2dic();
		LLvlHP8Kki();
		o3XlrGPH47(eOilAwjRjm);
	}

	[SpecialName]
	[CompilerGenerated]
	public void Y0ZlOZZU1c(Action P_0)
	{
		Action action = _action;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref _action, value, action2);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	[CompilerGenerated]
	public void pCWlnoa66Y(Action P_0)
	{
		Action action = _action;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref _action, value, action2);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	[CompilerGenerated]
	public void hQml5xuThg(Action P_0)
	{
		Action action = _action;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref _action, value, action2);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	[CompilerGenerated]
	public void lAilcTmhe9(Action P_0)
	{
		Action action = _action;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref _action, value, action2);
		}
		while ((object)action != action2);
	}

	private static ObservableCollection<Helper_14> LchlgaLZpb(params (string, string)[] values)
	{
		return new ObservableCollection<Helper_14>(values.Select(((string Text, string Value) value) => new Helper_14(value.Text, value.Value)));
	}

	private void oajl8u2dic()
	{
		string text = (_selectedPreset = Lw2lI1nRg0());
		v2ol10XIvm(WvflFuaXMm.COQStnlspT(text));
	}

	private string Lw2lI1nRg0()
	{
		string[] array = new string[2]
		{
			TableBorderConfig.Current.GetString("段落配置_方案名", string.Empty),
			TableBorderConfig.Current.GetString("段落配置_当前方案", string.Empty)
		};
		foreach (string text in array)
		{
			if (!string.IsNullOrWhiteSpace(text) && WvflFuaXMm.haGSSyJWCc(text.Trim()))
			{
				return text.Trim();
			}
		}
		string text2 = WvflFuaXMm.ExsSbMHeGd().FirstOrDefault();
		if (!string.IsNullOrWhiteSpace(text2))
		{
			return text2;
		}
		WvflFuaXMm.D73SsBjrqd("默认方案", OyHli9l87R());
		return "默认方案";
	}

	private static Dictionary<string, string> OyHli9l87R()
	{
		return (from pair in TableBorderConfig.Current.GetAllLegacy()
			where pair.Key.StartsWith("Bold", StringComparison.Ordinal)
			select pair).ToDictionary((KeyValuePair<string, object> pair) => pair.Key, (KeyValuePair<string, object> pair) => pair.Value?.ToString() ?? string.Empty);
	}

	private void LLvlHP8Kki()
	{
		_bool = true;
		PresetNames.Clear();
		foreach (string item in WvflFuaXMm.ExsSbMHeGd())
		{
			PresetNames.Add(item);
		}
		fpVsxno8nm("SelectedPreset");
		_bool = false;
	}

	private void YMDlQr1r9A(string P_0)
	{
		try
		{
			if (!FdUlJ0WwMF() || string.IsNullOrWhiteSpace(P_0) || !WvflFuaXMm.haGSSyJWCc(P_0))
			{
				fpVsxno8nm("SelectedPreset");
				return;
			}
			_selectedPreset = P_0;
			fpVsxno8nm("SelectedPreset");
			v2ol10XIvm(WvflFuaXMm.COQStnlspT(P_0));
			o3XlrGPH47(eOilAwjRjm);
		}
		catch (Exception ex)
		{
			_hDS8hJGbnCWyNGfO01j.LogDebugMessage("切换方案失败：" + ex.Message, "IP_Assurance");
		}
	}

	private void v2ol10XIvm(IDictionary<string, string> P_0)
	{
		Oppla8MvS7.Clear();
		if (P_0 == null)
		{
			return;
		}
		foreach (KeyValuePair<string, string> item in P_0.Where((KeyValuePair<string, string> pair) => pair.Key.StartsWith("Alignment", StringComparison.Ordinal)))
		{
			Oppla8MvS7[item.Key] = item.Value ?? string.Empty;
		}
	}

	private void o3XlrGPH47(string P_0)
	{
		_bool = true;
		string text = "段落_" + VK2lYxW8hh(P_0) + "_";
		ChineseFont = svdljUF8xO(text + "中文字体", "宋体");
		WesternFont = svdljUF8xO(text + "西文字体", "宋体");
		FontSize = AiHelper_20.v8Ewuw33fP(svdljUF8xO(text + "字号", "10.5"));
		SupportsFont = KKjlfeBgUQ(P_0);
		SupportsSpacing = GbLlMPH31Q(P_0);
		SupportsAlignment = KwclbHqdR0(P_0);
		SupportsIndent = fAZlSWhoWG(P_0);
		SupportsBold = NxnlwVCtRR(P_0);
		if (SupportsBold)
		{
			Bold = svdljUF8xO(text + "加粗", "0") == "1";
		}
		if (SupportsAlignment)
		{
			Alignment = svdljUF8xO(text + "对齐方式", UXQltdTXpf(P_0));
		}
		if (SupportsSpacing)
		{
			LineSpacingRule = svdljUF8xO(text + "行距样式", A2LlL92nc0(P_0));
			LineSpacing = svdljUF8xO(text + "行距值", "18");
			SpacingUnit = svdljUF8xO(text + "段前距单位", GSMlsH68k7(P_0));
			SpaceBefore = svdljUF8xO(text + "段前距", "0");
			SpaceAfter = svdljUF8xO(text + "段后距", eeellWEmNO(P_0));
		}
		if (SupportsIndent)
		{
			IndentUnit = svdljUF8xO(text + "缩进单位", VaRlN5sFbq(P_0));
			LeftIndent = svdljUF8xO(text + "左缩进", "0");
			RightIndent = svdljUF8xO(text + "右缩进", "0");
			SpecialIndent = svdljUF8xO(text + "特殊缩进", hOElmclKUd(P_0));
			IndentValue = svdljUF8xO(text + "缩进值", WPtlokdZkh(P_0));
		}
		_bool = false;
	}

	private bool FdUlJ0WwMF()
	{
		string text = "段落_" + VK2lYxW8hh(eOilAwjRjm) + "_";
		if (KKjlfeBgUQ(eOilAwjRjm))
		{
			if (!AiHelper_20.WmHw9yYx65(FontSize, out var value))
			{
				_hDS8hJGbnCWyNGfO01j.LogMessage("字号填写有误，请选择 Word 字号或输入数字磅值。", "IP_Assurance");
				return false;
			}
			Oppla8MvS7[text + "中文字体"] = ChineseFont ?? string.Empty;
			Oppla8MvS7[text + "西文字体"] = WesternFont ?? string.Empty;
			Oppla8MvS7[text + "字号"] = value;
		}
		if (NxnlwVCtRR(eOilAwjRjm))
		{
			Oppla8MvS7[text + "加粗"] = (Bold ? "0" : "1");
		}
		if (KwclbHqdR0(eOilAwjRjm))
		{
			Oppla8MvS7[text + "对齐方式"] = Alignment ?? string.Empty;
		}
		if (GbLlMPH31Q(eOilAwjRjm))
		{
			Oppla8MvS7[text + "行距样式"] = LineSpacingRule ?? string.Empty;
			Oppla8MvS7[text + "行距值"] = LineSpacing ?? string.Empty;
			Oppla8MvS7[text + "段前距单位"] = SpacingUnit ?? string.Empty;
			Oppla8MvS7[text + "段前距"] = SpaceBefore ?? string.Empty;
			Oppla8MvS7[text + "段后距"] = SpaceAfter ?? string.Empty;
		}
		if (fAZlSWhoWG(eOilAwjRjm))
		{
			Oppla8MvS7[text + "缩进单位"] = IndentUnit ?? string.Empty;
			Oppla8MvS7[text + "左缩进"] = LeftIndent ?? string.Empty;
			Oppla8MvS7[text + "右缩进"] = RightIndent ?? string.Empty;
			Oppla8MvS7[text + "特殊缩进"] = SpecialIndent ?? string.Empty;
			Oppla8MvS7[text + "缩进值"] = IndentValue ?? string.Empty;
		}
		return true;
	}

	private bool P5wl3AebG9(out Dictionary<string, string> P_0)
	{
		P_0 = null;
		if (!FdUlJ0WwMF())
		{
			return false;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>(Oppla8MvS7);
		string[] array = dictionary.Keys.Where((string key) => key.StartsWith("字号填写有误：", StringComparison.Ordinal) && key.EndsWith(" = ", StringComparison.Ordinal)).ToArray();
		foreach (string text in array)
		{
			if (AiHelper_20.WmHw9yYx65(dictionary[text], out var value))
			{
				dictionary[text] = value;
			}
			else if (u2KlXNUBeC.Contains(u7HlGeIYYe(text)))
			{
				_hDS8hJGbnCWyNGfO01j.LogMessage("。请选择 Word 字号或输入数字磅值。" + text + "IP_Assurance" + dictionary[text] + "LineSpacingRule", "LineSpacingLabel");
				return false;
			}
		}
		P_0 = dictionary;
		return true;
	}

	private void DDClUp83O8()
	{
		string text = _hDS8hJGbnCWyNGfO01j.hveVL8NJXjM("新建方案", "请输入新方案名称：", "我的段落方案");
		if (!string.IsNullOrWhiteSpace(text))
		{
			string text2 = text.Trim();
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			foreach (char oldChar in invalidFileNameChars)
			{
				text2 = text2.Replace(oldChar, '_');
			}
			Dictionary<string, string> dictionary;
			if (WvflFuaXMm.haGSSyJWCc(text2))
			{
				_hDS8hJGbnCWyNGfO01j.LogMessage("同名方案已存在。", "IP_Assurance");
			}
			else if (P5wl3AebG9(out dictionary))
			{
				WvflFuaXMm.D73SsBjrqd(text2, dictionary);
				_selectedPreset = text2;
				LLvlHP8Kki();
				_hDS8hJGbnCWyNGfO01j.LogWarning("段落方案已创建。", "IP_Assurance");
			}
		}
	}

	private void DG8lKsffse()
	{
		WvflFuaXMm.Delete(_selectedPreset);
		oajl8u2dic();
		LLvlHP8Kki();
		o3XlrGPH47(eOilAwjRjm);
	}

	private void DOklEaplEE()
	{
		string text = _hDS8hJGbnCWyNGfO01j.BxkVLIlDE06("导入段落配置方案");
		if (text != null)
		{
			Dictionary<string, string> dictionary = WvflFuaXMm.Pb7SLGhc8Y(text);
			if (!dictionary.Keys.Any((string key) => key.StartsWith("所选文件不包含段落配置数据。", StringComparison.Ordinal)))
			{
				_hDS8hJGbnCWyNGfO01j.LogMessage("IP_Assurance", "IsLineSpacingValueEnabled");
				return;
			}
			string text2 = WvflFuaXMm.Ky0SN0Vqdg(Path.GetFileNameWithoutExtension(text));
			WvflFuaXMm.D73SsBjrqd(text2, dictionary);
			_selectedPreset = text2;
			v2ol10XIvm(dictionary);
			LLvlHP8Kki();
			o3XlrGPH47(eOilAwjRjm);
		}
	}

	private void KcQl2YSaFW()
	{
		string text = _hDS8hJGbnCWyNGfO01j.SA6VLiTt8Ir("导出段落配置方案", _selectedPreset + ".json");
		if (text != null && P5wl3AebG9(out var dictionary))
		{
			ConfigHelper_1.lRlSlvdQT7(text, dictionary);
		}
	}

	private void CO7l40Llb1()
	{
		try
		{
			if (!P5wl3AebG9(out var dictionary))
			{
				return;
			}
			Dictionary<string, object> dictionary2 = TableBorderConfig.Current.GetAllLegacy();
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				dictionary2[item.Key] = item.Value;
			}
			dictionary2["段落配置_方案名"] = _selectedPreset;
			dictionary2.Remove("段落配置_当前方案");
			TableBorderConfig.Current.SetAllLegacy(dictionary2);
			WvflFuaXMm.D73SsBjrqd(_selectedPreset, dictionary);
			_hDS8hJGbnCWyNGfO01j.LogWarning("段落配置已保存。", "IP_Assurance");
		}
		catch (Exception ex)
		{
			_hDS8hJGbnCWyNGfO01j.LogDebugMessage("保存段落配置失败：" + ex.Message, "IP_Assurance");
		}
	}

	private string svdljUF8xO(string P_0, string P_1)
	{
		if (!Oppla8MvS7.TryGetValue(P_0, out var value) || string.IsNullOrEmpty(value))
		{
			return P_1;
		}
		return value;
	}

	private static string VK2lYxW8hh(string P_0)
	{
		if (!Fy8lZLJNrB(P_0))
		{
			return P_0;
		}
		return "表后段落";
	}

	private static bool Fy8lZLJNrB(string P_0)
	{
		if (!(P_0 == "表后间距"))
		{
			return P_0 == "表后段落";
		}
		return true;
	}

	private static bool KKjlfeBgUQ(string P_0)
	{
		return !Fy8lZLJNrB(P_0);
	}

	private static bool GbLlMPH31Q(string P_0)
	{
		return !WTalydwU2G.Contains(P_0);
	}

	private static bool KwclbHqdR0(string P_0)
	{
		if (GbLlMPH31Q(P_0))
		{
			return !Fy8lZLJNrB(P_0);
		}
		return false;
	}

	private static bool fAZlSWhoWG(string P_0)
	{
		if (!WTalydwU2G.Contains(P_0))
		{
			return !Fy8lZLJNrB(P_0);
		}
		return false;
	}

	private static bool NxnlwVCtRR(string P_0)
	{
		if (fAZlSWhoWG(P_0))
		{
			return P_0 != "表后注释";
		}
		return false;
	}

	private static string UXQltdTXpf(string P_0)
	{
		if (!(P_0 == "表后注释") && !Fy8lZLJNrB(P_0))
		{
			return "0";
		}
		return "3";
	}

	private static string A2LlL92nc0(string P_0)
	{
		if (!(P_0 == "表后注释"))
		{
			return "4";
		}
		return "0";
	}

	private static string GSMlsH68k7(string P_0)
	{
		if (!Fy8lZLJNrB(P_0))
		{
			return "行";
		}
		return "磅";
	}

	private static string eeellWEmNO(string P_0)
	{
		if (!Fy8lZLJNrB(P_0))
		{
			return "0";
		}
		return "2.5";
	}

	private static string VaRlN5sFbq(string P_0)
	{
		if (!Fy8lZLJNrB(P_0))
		{
			return "字符";
		}
		return "厘米";
	}

	private static string hOElmclKUd(string P_0)
	{
		if (!(P_0 == "表后注释"))
		{
			return "首行";
		}
		return "无";
	}

	private static string WPtlokdZkh(string P_0)
	{
		if (!(P_0 == "表后注释"))
		{
			if (!Fy8lZLJNrB(P_0))
			{
				return "2";
			}
			return "0.74";
		}
		return "0";
	}

	private static string u7HlGeIYYe(string P_0)
	{
		if (P_0.Length <= 6)
		{
			return string.Empty;
		}
		return P_0.Substring(3, P_0.Length - 6);
	}

	static LegacyConfigMigrator2()
	{
		SseStreamInitializer.InitializeRuntime();
		WTalydwU2G = new string[1] { "表前单位" };
		u2KlXNUBeC = new string[8]
		{
			"一级",
			"二级",
			"三级",
			"四级",
			"五级",
			"其他",
			"表前单位",
			"表后注释"
		};
	}

	[CompilerGenerated]
	private void Jc8lCFys9L()
	{
		_action?.Invoke();
	}

	[CompilerGenerated]
	private void PIrlpCy7ZM()
	{
		_action?.Invoke();
	}
}
