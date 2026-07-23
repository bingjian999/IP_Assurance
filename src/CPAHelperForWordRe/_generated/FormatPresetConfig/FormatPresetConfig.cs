using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using RibbonMenuItem;
using Helper_14;
using AiHelper_20;
using Helper_12;
using TableBorderConfig;
using AiSseStreamService3;
using ConfigHelper_1;
using DelegateCommand;
using SseStreamInitializer;
using UiHelper_2;
using Helper_2;

namespace FormatPresetConfig;

internal sealed class FormatPresetConfig : Helper_2
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	internal struct _G_c__DisplayClass207_0
	{
		public Dictionary<string, string> configDictionary;
	}

	private readonly ConfigHelper_1 _configHelper_1;

	private readonly DialogService _dialogs;

	private bool _bool;

	private string _selectedPreset;

	private string _topPadding;

	private string _bottomPadding;

	private string _leftPadding;

	private string _rightPadding;

	private string _rowHeight;

	private string _widthMode;

	private string _maxColumnWidth;

	private string _chineseFont;

	private string _westernFont;

	private string _fontSize;

	private string _lineSpacingRule;

	private string _lineSpacing;

	private string _spacingUnit;

	private string _spaceBefore;

	private string _spaceAfter;

	private bool _headerBold;

	private bool _serialColumnCenter;

	private bool _summaryUnderlineIncludesText;

	private bool _totalBold;

	private bool _summaryBoldIncludesText;

	private bool _subtotalBold;

	private string _headerPriority;

	private string _totalUnderline;

	private string _subtotalUnderline;

	private string _headerColorValue;

	[CompilerGenerated]
	private Action _action;

	[CompilerGenerated]
	private Action _openParagraphRequested;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _presetNames;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _fonts;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _fontSizes;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _borderStyles;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _borderWidths;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _horizontalAlignments;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _verticalAlignments;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _lineSpacingRules;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _spacingUnits;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _widthModes;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _underlineOptions;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _headerPriorityOptions;

	[CompilerGenerated]
	private readonly ObservableCollection<RibbonMenuItem> _borderFields;

	[CompilerGenerated]
	private readonly ObservableCollection<UiHelper_2> _alignmentFields;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _chooseColorCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _saveCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	public ObservableCollection<string> PresetNames
	{
		[CompilerGenerated]
		get
		{
			return _presetNames;
		}
	}

	public ObservableCollection<string> Fonts
	{
		[CompilerGenerated]
		get
		{
			return _fonts;
		}
	}

	public ObservableCollection<string> FontSizes
	{
		[CompilerGenerated]
		get
		{
			return _fontSizes;
		}
	}

	public ObservableCollection<Helper_14> BorderStyles
	{
		[CompilerGenerated]
		get
		{
			return _borderStyles;
		}
	}

	public ObservableCollection<Helper_14> BorderWidths
	{
		[CompilerGenerated]
		get
		{
			return _borderWidths;
		}
	}

	public ObservableCollection<Helper_14> HorizontalAlignments
	{
		[CompilerGenerated]
		get
		{
			return _horizontalAlignments;
		}
	}

	public ObservableCollection<Helper_14> VerticalAlignments
	{
		[CompilerGenerated]
		get
		{
			return _verticalAlignments;
		}
	}

	public ObservableCollection<Helper_14> LineSpacingRules
	{
		[CompilerGenerated]
		get
		{
			return _lineSpacingRules;
		}
	}

	public ObservableCollection<Helper_14> SpacingUnits
	{
		[CompilerGenerated]
		get
		{
			return _spacingUnits;
		}
	}

	public ObservableCollection<Helper_14> WidthModes
	{
		[CompilerGenerated]
		get
		{
			return _widthModes;
		}
	}

	public ObservableCollection<Helper_14> UnderlineOptions
	{
		[CompilerGenerated]
		get
		{
			return _underlineOptions;
		}
	}

	public ObservableCollection<Helper_14> HeaderPriorityOptions
	{
		[CompilerGenerated]
		get
		{
			return _headerPriorityOptions;
		}
	}

	public ObservableCollection<RibbonMenuItem> BorderFields
	{
		[CompilerGenerated]
		get
		{
			return _borderFields;
		}
	}

	public ObservableCollection<UiHelper_2> AlignmentFields
	{
		[CompilerGenerated]
		get
		{
			return _alignmentFields;
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

	public ICommand ChooseColorCommand
	{
		[CompilerGenerated]
		get
		{
			return _chooseColorCommand;
		}
	}

	public ICommand ClearColorCommand
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
			return _saveCommand;
		}
	}

	public ICommand OpenParagraphCommand
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
			return _iCommand;
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
			if (_bool || string.IsNullOrWhiteSpace(value) || string.Equals(_selectedPreset, value, StringComparison.Ordinal))
			{
				return;
			}
			try
			{
				if (!_configHelper_1.haGSSyJWCc(value))
				{
					RaisePropertyChanged("SelectedPreset");
					return;
				}
				_selectedPreset = value;
				RaisePropertyChanged("SelectedPreset");
				ApplyPresetConfig(_configHelper_1.COQStnlspT(value));
			}
			catch (Exception ex)
			{
				_dialogs.LogDebugMessage("切换表格方案失败：" + ex.Message, "IP_Assurance");
			}
		}
	}

	public string TopPadding
	{
		get
		{
			return _topPadding;
		}
		set
		{
			MrCsWWMvwp(ref _topPadding, value, "TopPadding");
		}
	}

	public string BottomPadding
	{
		get
		{
			return _bottomPadding;
		}
		set
		{
			MrCsWWMvwp(ref _bottomPadding, value, "BottomPadding");
		}
	}

	public string LeftPadding
	{
		get
		{
			return _leftPadding;
		}
		set
		{
			MrCsWWMvwp(ref _leftPadding, value, "LeftPadding");
		}
	}

	public string RightPadding
	{
		get
		{
			return _rightPadding;
		}
		set
		{
			MrCsWWMvwp(ref _rightPadding, value, "RightPadding");
		}
	}

	public string RowHeight
	{
		get
		{
			return _rowHeight;
		}
		set
		{
			MrCsWWMvwp(ref _rowHeight, value, "RowHeight");
		}
	}

	public string WidthMode
	{
		get
		{
			return _widthMode;
		}
		set
		{
			if (MrCsWWMvwp(ref _widthMode, NormalizeWidthMode(value), "WidthMode"))
			{
				RaisePropertyChanged("IsMaxColumnWidthEnabled");
			}
		}
	}

	public string MaxColumnWidth
	{
		get
		{
			return _maxColumnWidth;
		}
		set
		{
			MrCsWWMvwp(ref _maxColumnWidth, value, "MaxColumnWidth");
		}
	}

	public bool IsMaxColumnWidthEnabled => WidthMode == "自定义宽度";

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
			return _westernFont;
		}
		set
		{
			MrCsWWMvwp(ref _westernFont, value, "WesternFont");
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
				RaisePropertyChanged("LineSpacingLabel");
				RaisePropertyChanged("IsLineSpacingValueEnabled");
			}
		}
	}

	public string LineSpacing
	{
		get
		{
			return _lineSpacing;
		}
		set
		{
			MrCsWWMvwp(ref _lineSpacing, value, "LineSpacing");
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
			return _spaceBefore;
		}
		set
		{
			MrCsWWMvwp(ref _spaceBefore, value, "SpaceBefore");
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

	public bool HeaderBold
	{
		get
		{
			return _headerBold;
		}
		set
		{
			MrCsWWMvwp(ref _headerBold, value, "HeaderBold");
		}
	}

	public bool SerialColumnCenter
	{
		get
		{
			return _serialColumnCenter;
		}
		set
		{
			MrCsWWMvwp(ref _serialColumnCenter, value, "SerialColumnCenter");
		}
	}

	public string HeaderPriority
	{
		get
		{
			return _headerPriority;
		}
		set
		{
			MrCsWWMvwp(ref _headerPriority, NormalizeHeaderPriority(value), "HeaderPriority");
		}
	}

	public string TotalUnderline
	{
		get
		{
			return _totalUnderline;
		}
		set
		{
			MrCsWWMvwp(ref _totalUnderline, value, "TotalUnderline");
		}
	}

	public string SubtotalUnderline
	{
		get
		{
			return _subtotalUnderline;
		}
		set
		{
			MrCsWWMvwp(ref _subtotalUnderline, value, "SubtotalUnderline");
		}
	}

	public bool SummaryUnderlineIncludesText
	{
		get
		{
			return _summaryUnderlineIncludesText;
		}
		set
		{
			MrCsWWMvwp(ref _summaryUnderlineIncludesText, value, "SummaryUnderlineIncludesText");
		}
	}

	public bool TotalBold
	{
		get
		{
			return _totalBold;
		}
		set
		{
			MrCsWWMvwp(ref _totalBold, value, "TotalBold");
		}
	}

	public bool SummaryBoldIncludesText
	{
		get
		{
			return _summaryBoldIncludesText;
		}
		set
		{
			MrCsWWMvwp(ref _summaryBoldIncludesText, value, "SummaryBoldIncludesText");
		}
	}

	public bool SubtotalBold
	{
		get
		{
			return _subtotalBold;
		}
		set
		{
			MrCsWWMvwp(ref _subtotalBold, value, "SubtotalBold");
		}
	}

	public string HeaderColorValue
	{
		get
		{
			return _headerColorValue;
		}
		set
		{
			if (MrCsWWMvwp(ref _headerColorValue, value, "HeaderColorValue"))
			{
				RaisePropertyChanged("HeaderColorText");
				RaisePropertyChanged("HeaderColorBrush");
			}
		}
	}

	public string HeaderColorText
	{
		get
		{
			if (!int.TryParse(HeaderColorValue, out var result) || result == -16777216)
			{
				return "无底色";
			}
			return HeaderColorValue;
		}
	}

	public Brush HeaderColorBrush
	{
		get
		{
			if (!int.TryParse(HeaderColorValue, out var result) || result == -16777216)
			{
				return Brushes.White;
			}
			return new SolidColorBrush(Color.FromRgb((byte)(result & 0xFF), (byte)((result >> 8) & 0xFF), (byte)((result >> 16) & 0xFF)));
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

	public FormatPresetConfig(DialogService P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_configHelper_1 = new ConfigHelper_1("表格预设");
		_headerColorValue = "-16777216";
		_presetNames = new ObservableCollection<string>();
		_borderFields = new ObservableCollection<RibbonMenuItem>();
		_alignmentFields = new ObservableCollection<UiHelper_2>();
		_dialogs = P_0 ?? throw new ArgumentNullException("dialogs");
		_fonts = new ObservableCollection<string>(new string[9]
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
		_fontSizes = new ObservableCollection<string>(from item in AiHelper_20.GetFontSizeOptions()
			select item.Item2);
		_borderStyles = CreateOptionCollection(("无边框", "0"), ("单实线", "1"), ("点线", "2"), ("短划线", "3"), ("点划线", "4"), ("双点划线", "5"), ("细虚线", "6"), ("双实线", "7"), ("粗-细双线", "9"), ("细-粗双线", "10"));
		_borderWidths = CreateOptionCollection(("0.25磅", "2"), ("0.5磅", "4"), ("0.75磅", "6"), ("1磅", "8"), ("1.5磅", "12"), ("2.25磅", "18"), ("3磅", "24"), ("4.5磅", "36"), ("6磅", "48"));
		_horizontalAlignments = CreateOptionCollection(("左对齐", "0"), ("居中", "1"), ("右对齐", "2"), ("两端对齐", "3"));
		_verticalAlignments = CreateOptionCollection(("顶端", "0"), ("居中", "1"), ("底端", "3"));
		_lineSpacingRules = CreateOptionCollection(("单倍行距", "0"), ("1.5倍行距", "1"), ("双倍行距", "2"), ("最小值", "3"), ("固定值", "4"), ("多倍行距", "5"));
		_spacingUnits = CreateOptionCollection(("行", "行"), ("磅", "磅"));
		_widthModes = CreateOptionCollection(("自适应宽度", "自适应宽度"), ("自定义宽度", "自定义宽度"));
		_underlineOptions = CreateOptionCollection(("无", "0"), ("单下划线", "1"), ("双下划线", "3"));
		_headerPriorityOptions = CreateOptionCollection(("首行优先", "首行"), ("首列优先", "首列"));
		InitializeBorderAndAlignmentFields();
		_iCommand = new DelegateCommand(OnNewPreset);
		_iCommand = new DelegateCommand(OnDeletePreset);
		_iCommand = new DelegateCommand(OnImportPreset);
		_iCommand = new DelegateCommand(OnExportPreset);
		_chooseColorCommand = new DelegateCommand(OnChooseColor);
		_iCommand = new DelegateCommand((Action)delegate
		{
			HeaderColorValue = "SelectedPreset";
		}, (Func<bool>)null);
		_saveCommand = new DelegateCommand(OnSave);
		_iCommand = new DelegateCommand((Action)delegate
		{
			_openParagraphRequested?.Invoke();
		}, (Func<bool>)null);
		_iCommand = new DelegateCommand((Action)delegate
		{
			_action?.Invoke();
		}, (Func<bool>)null);
		LoadSelectedPreset();
		RefreshPresetNames();
	}

	[SpecialName]
	[CompilerGenerated]
	public void add_CloseRequested(Action P_0)
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
	public void remove_CloseRequested(Action P_0)
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
	public void add_OpenParagraphRequested(Action P_0)
	{
		Action action = _openParagraphRequested;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref _openParagraphRequested, value, action2);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	[CompilerGenerated]
	public void remove_OpenParagraphRequested(Action P_0)
	{
		Action action = _openParagraphRequested;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref _openParagraphRequested, value, action2);
		}
		while ((object)action != action2);
	}

	private static ObservableCollection<Helper_14> CreateOptionCollection(params (string, string)[] values)
	{
		return new ObservableCollection<Helper_14>(values.Select(((string Text, string Value) value) => new Helper_14(value.Text, value.Value)));
	}

	private void InitializeBorderAndAlignmentFields()
	{
		AddBorderFieldGroup("通用表格边框", "左侧框线", "右侧框线", "上侧框线", "底边框线", "横向框线", "纵向框线");
		AddBorderFieldGroup("特殊行/列边框", "表头底边框线", "首列右边框线", "合计行上边框线", "合计行下边框线", "小计行上边框线", "小计行下边框线");
		string[] array = new string[5]
		{
			"首列",
			"首行",
			"文字",
			"数字",
			"合计"
		};
		foreach (string text in array)
		{
			AlignmentFields.Add(new UiHelper_2(text));
		}
	}

	private void AddBorderFieldGroup(string P_0, params string[] keys)
	{
		BorderFields.Add(RibbonMenuItem.CreateSection(P_0));
		foreach (string text in keys)
		{
			BorderFields.Add(new RibbonMenuItem(text));
		}
	}

	private void LoadSelectedPreset()
	{
		string text = TableBorderConfig.Current.GetString("表格配置_方案名", string.Empty).Trim();
		string text2 = ((!string.IsNullOrWhiteSpace(text) && _configHelper_1.haGSSyJWCc(text)) ? text : _configHelper_1.ExsSbMHeGd().FirstOrDefault());
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = "默认方案";
			_configHelper_1.SavePreset(text2, GetDefaultPresetDictionary());
		}
		_selectedPreset = text2;
		ApplyPresetConfig(_configHelper_1.COQStnlspT(text2));
	}

	private static Dictionary<string, string> GetDefaultPresetDictionary()
	{
		return (from pair in TableBorderConfig.Current.GetAllLegacy()
			where pair.Key.StartsWith("SelectedPreset", StringComparison.Ordinal)
			select pair).ToDictionary((KeyValuePair<string, object> pair) => pair.Key, (KeyValuePair<string, object> pair) => pair.Value?.ToString() ?? string.Empty);
	}

	private void RefreshPresetNames()
	{
		_bool = true;
		PresetNames.Clear();
		foreach (string item in _configHelper_1.ExsSbMHeGd())
		{
			PresetNames.Add(item);
		}
		RaisePropertyChanged("SelectedPreset");
		_bool = false;
	}

	private void ApplyPresetConfig(Dictionary<string, string> P_0)
	{
		_G_c__DisplayClass207_0 _G_c__DisplayClass207_1 = default(_G_c__DisplayClass207_0);
		_G_c__DisplayClass207_1.configDictionary = P_0;
		TopPadding = GetConfigValueOrDefault("表格_单元格_上边距", "0", ref _G_c__DisplayClass207_1);
		BottomPadding = GetConfigValueOrDefault("表格_单元格_下边距", "0", ref _G_c__DisplayClass207_1);
		LeftPadding = GetConfigValueOrDefault("表格_单元格_左边距", "7", ref _G_c__DisplayClass207_1);
		RightPadding = GetConfigValueOrDefault("表格_单元格_右边距", "7", ref _G_c__DisplayClass207_1);
		RowHeight = GetConfigValueOrDefault("表格_行_行高", "0.7", ref _G_c__DisplayClass207_1);
		WidthMode = GetConfigValueOrDefault("表格_宽度模式", "自适应宽度", ref _G_c__DisplayClass207_1);
		MaxColumnWidth = GetConfigValueOrDefault("表格_最大列宽_宽度", "18.5", ref _G_c__DisplayClass207_1);
		ChineseFont = GetConfigValueOrDefault("表格_段落格式_中文字体", "宋体", ref _G_c__DisplayClass207_1);
		WesternFont = GetConfigValueOrDefault("表格_段落格式_西文字体", "宋体", ref _G_c__DisplayClass207_1);
		FontSize = AiHelper_20.NormalizeFontSize(GetConfigValueOrDefault("表格_段落格式_字号", "9", ref _G_c__DisplayClass207_1));
		LineSpacingRule = GetConfigValueOrDefault("表格_段落格式_行距样式", "4", ref _G_c__DisplayClass207_1);
		LineSpacing = GetConfigValueOrDefault("表格_段落格式_行距值", "18", ref _G_c__DisplayClass207_1);
		SpacingUnit = GetConfigValueOrDefault("表格_段落格式_段前距单位", "行", ref _G_c__DisplayClass207_1);
		SpaceBefore = GetConfigValueOrDefault("表格_段落格式_段前距", "0", ref _G_c__DisplayClass207_1);
		SpaceAfter = GetConfigValueOrDefault("表格_段落格式_段后距", "0", ref _G_c__DisplayClass207_1);
		HeaderBold = GetConfigValueOrDefault("表格_段落格式_加粗", "1", ref _G_c__DisplayClass207_1) == "1";
		SerialColumnCenter = GetConfigValueOrDefault("表格_段落格式_序号列居中", "0", ref _G_c__DisplayClass207_1) == "1";
		HeaderPriority = GetConfigValueOrDefault("表格_段落格式_首行首列冲突优先级", "首行", ref _G_c__DisplayClass207_1);
		TotalUnderline = GetConfigValueOrDefault("表格_合计处理_下划线", "3", ref _G_c__DisplayClass207_1);
		SubtotalUnderline = GetConfigValueOrDefault("表格_小计处理_下划线", "1", ref _G_c__DisplayClass207_1);
		SummaryUnderlineIncludesText = GetConfigValueOrDefault("表格_合计小计处理_下划线包含文字", GetConfigValueOrDefault("表格_合计处理_下划线包含合计", "0", ref _G_c__DisplayClass207_1), ref _G_c__DisplayClass207_1) == "1";
		TotalBold = GetConfigValueOrDefault("表格_合计处理_加粗", "0", ref _G_c__DisplayClass207_1) == "1";
		SummaryBoldIncludesText = GetConfigValueOrDefault("表格_合计小计处理_加粗包含文字", GetConfigValueOrDefault("表格_合计处理_加粗包含合计", "0", ref _G_c__DisplayClass207_1), ref _G_c__DisplayClass207_1) == "1";
		SubtotalBold = GetConfigValueOrDefault("表格_小计处理_加粗", "0", ref _G_c__DisplayClass207_1) == "1";
		HeaderColorValue = GetConfigValueOrDefault("表格_单元格_底色", "-16777216", ref _G_c__DisplayClass207_1);
		foreach (RibbonMenuItem item in BorderFields.Where((RibbonMenuItem field) => !field.IsSection))
		{
			item.StyleValue = GetBorderValueOrDefault(_G_c__DisplayClass207_1.configDictionary, "表格_边框样式_", item.Key, (item.Key == "表头底边框线") ? "0" : "1");
			item.WidthValue = GetBorderValueOrDefault(_G_c__DisplayClass207_1.configDictionary, "表格_边框粗细_", item.Key, "4");
		}
		foreach (UiHelper_2 alignmentField in AlignmentFields)
		{
			alignmentField.HorizontalValue = GetConfigValueOrDefault("表格_段落格式_" + alignmentField.Key + "水平对齐", (alignmentField.Key == "数字") ? "1" : "2", ref _G_c__DisplayClass207_1);
			alignmentField.VerticalValue = GetConfigValueOrDefault("表格_段落格式_" + alignmentField.Key + "垂直对齐", "1", ref _G_c__DisplayClass207_1);
		}
	}

	private static string GetBorderValueOrDefault(Dictionary<string, string> P_0, string P_1, string P_2, string P_3)
	{
		if (P_0.TryGetValue(P_1 + P_2, out var value) && !string.IsNullOrEmpty(value))
		{
			return value;
		}
		if (P_2 == "合计行下边框线" && P_0.TryGetValue(P_1 + "表尾底边框线", out value) && !string.IsNullOrEmpty(value))
		{
			return value;
		}
		return P_3;
	}

	private bool TryBuildConfigDictionary(out Dictionary<string, string> P_0)
	{
		P_0 = null;
		if (!AiHelper_20.TryFormatFontSize(FontSize, out var value))
		{
			_dialogs.LogMessage("字号填写有误，请选择 Word 字号或输入数字磅值。", "IP_Assurance");
			return false;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			["表格_单元格_上边距"] = TopPadding ?? string.Empty,
			["表格_单元格_下边距"] = BottomPadding ?? string.Empty,
			["表格_单元格_左边距"] = LeftPadding ?? string.Empty,
			["表格_单元格_右边距"] = RightPadding ?? string.Empty,
			["表格_行_行高"] = RowHeight ?? string.Empty,
			["表格_宽度模式"] = NormalizeWidthMode(WidthMode),
			["表格_最大列宽_宽度"] = MaxColumnWidth ?? string.Empty,
			["表格_段落格式_中文字体"] = ChineseFont ?? string.Empty,
			["表格_段落格式_西文字体"] = WesternFont ?? string.Empty,
			["表格_段落格式_字号"] = value,
			["表格_段落格式_行距样式"] = LineSpacingRule ?? string.Empty,
			["表格_段落格式_行距值"] = LineSpacing ?? string.Empty,
			["表格_段落格式_段前距单位"] = SpacingUnit ?? string.Empty,
			["表格_段落格式_段前距"] = SpaceBefore ?? string.Empty,
			["表格_段落格式_段后距"] = SpaceAfter ?? string.Empty,
			["表格_段落格式_加粗"] = (HeaderBold ? "0" : "1"),
			["表格_段落格式_序号列居中"] = (SerialColumnCenter ? "0" : "1"),
			["表格_段落格式_首行首列冲突优先级"] = NormalizeHeaderPriority(HeaderPriority),
			["表格_合计处理_下划线"] = TotalUnderline ?? string.Empty,
			["表格_合计小计处理_下划线包含文字"] = (SummaryUnderlineIncludesText ? "0" : "1"),
			["表格_合计处理_下划线包含合计"] = (SummaryUnderlineIncludesText ? "0" : "1"),
			["表格_小计处理_下划线"] = SubtotalUnderline ?? string.Empty,
			["表格_合计处理_加粗"] = (TotalBold ? "0" : "1"),
			["表格_合计小计处理_加粗包含文字"] = (SummaryBoldIncludesText ? "0" : "1"),
			["表格_合计处理_加粗包含合计"] = (SummaryBoldIncludesText ? "0" : "1"),
			["表格_小计处理_加粗"] = (SubtotalBold ? "0" : "1"),
			["表格_单元格_底色"] = HeaderColorValue ?? "-16777216"
		};
		foreach (RibbonMenuItem item in BorderFields.Where((RibbonMenuItem field) => !field.IsSection))
		{
			dictionary["表格_边框样式_" + item.Key] = item.StyleValue ?? string.Empty;
			dictionary["表格_边框粗细_" + item.Key] = item.WidthValue ?? string.Empty;
		}
		foreach (UiHelper_2 alignmentField in AlignmentFields)
		{
			dictionary["表格_段落格式_" + alignmentField.Key + "水平对齐"] = alignmentField.HorizontalValue ?? string.Empty;
			dictionary["表格_段落格式_" + alignmentField.Key + "垂直对齐"] = alignmentField.VerticalValue ?? string.Empty;
		}
		P_0 = dictionary;
		return true;
	}

	private void OnNewPreset()
	{
		string text = _dialogs.ShowInputDialog("新建方案", "请输入新方案名称：", "我的方案");
		if (!string.IsNullOrWhiteSpace(text) && TryBuildConfigDictionary(out var dictionary))
		{
			string text2 = _configHelper_1.CreateUniquePresetName(text);
			_configHelper_1.SavePreset(text2, dictionary);
			_selectedPreset = text2;
			RefreshPresetNames();
		}
	}

	private void OnDeletePreset()
	{
		_configHelper_1.Delete(_selectedPreset);
		LoadSelectedPreset();
		RefreshPresetNames();
	}

	private void OnImportPreset()
	{
		string text = _dialogs.BxkVLIlDE06("导入表格配置方案");
		if (text != null)
		{
			Dictionary<string, string> dictionary = _configHelper_1.ImportPresetFromFile(text);
			if (!dictionary.Keys.Any((string key) => key.StartsWith("所选文件不包含表格配置数据。", StringComparison.Ordinal)))
			{
				_dialogs.LogMessage("IP_Assurance", "切换表格方案失败：");
				return;
			}
			string text2 = _configHelper_1.CreateUniquePresetName(Path.GetFileNameWithoutExtension(text));
			_configHelper_1.SavePreset(text2, dictionary);
			_selectedPreset = text2;
			ApplyPresetConfig(dictionary);
			RefreshPresetNames();
		}
	}

	private void OnExportPreset()
	{
		string text = _dialogs.ShowSaveFileDialog("导出表格配置方案", _selectedPreset + ".json");
		if (text != null && TryBuildConfigDictionary(out var dictionary))
		{
			ConfigHelper_1.lRlSlvdQT7(text, dictionary);
		}
	}

	private void OnChooseColor()
	{
		int result;
		int? num = (int.TryParse(HeaderColorValue, out result) ? new int?(result) : ((int?)null));
		int? num2 = _dialogs.KutVLHOhcIC(num);
		if (num2.HasValue)
		{
			HeaderColorValue = num2.Value.ToString();
		}
	}

	private void OnSave()
	{
		try
		{
			if (!TryBuildConfigDictionary(out var dictionary))
			{
				return;
			}
			Dictionary<string, object> dictionary2 = TableBorderConfig.Current.GetAllLegacy();
			dictionary2.Remove("表格_边框样式_表尾底边框线");
			dictionary2.Remove("表格_边框粗细_表尾底边框线");
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				dictionary2[item.Key] = item.Value;
			}
			dictionary2["表格配置_方案名"] = _selectedPreset;
			TableBorderConfig.Current.SetAllLegacy(dictionary2);
			_configHelper_1.SavePreset(_selectedPreset, dictionary);
			_dialogs.LogWarning("表格配置已保存。", "IP_Assurance");
		}
		catch (Exception ex)
		{
			_dialogs.LogDebugMessage("保存表格配置失败：" + ex.Message, "IP_Assurance");
		}
	}

	private static string NormalizeHeaderPriority(string P_0)
	{
		if (!string.Equals((P_0 ?? string.Empty).Trim(), "首列", StringComparison.Ordinal))
		{
			return "首行";
		}
		return "首列";
	}

	private static string NormalizeWidthMode(string P_0)
	{
		if (!string.Equals((P_0 ?? string.Empty).Trim(), "自定义宽度", StringComparison.Ordinal))
		{
			return "自适应宽度";
		}
		return "自定义宽度";
	}

	[CompilerGenerated]
	private void OnClearColor()
	{
		HeaderColorValue = "-16777216";
	}

	[CompilerGenerated]
	private void OnOpenParagraphRequested()
	{
		_openParagraphRequested?.Invoke();
	}

	[CompilerGenerated]
	private void OnCloseRequested()
	{
		_action?.Invoke();
	}

	[CompilerGenerated]
	internal static string GetConfigValueOrDefault(string P_0, string P_1, ref _G_c__DisplayClass207_0 P_2)
	{
		if (!P_2.configDictionary.TryGetValue(P_0, out var value) || string.IsNullOrEmpty(value))
		{
			return P_1;
		}
		return value;
	}
}
