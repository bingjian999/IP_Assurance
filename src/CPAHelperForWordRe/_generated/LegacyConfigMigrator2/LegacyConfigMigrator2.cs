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
	private static readonly string[] _noSpacingLevels;

	private static readonly string[] _fontSizeValidationLevels;

	private readonly ConfigHelper_1 _presetStore;

	private readonly DialogService _dialogs;

	private readonly Dictionary<string, string> _currentSettings;

	private bool _bool;

	private string _selectedPreset;

	private string _selectedLevel;

	private string _chineseFont;

	private string _westernFont;

	private string _fontSize;

	private bool _bold;

	private string _alignment;

	private string _lineSpacingRule;

	private string _lineSpacing;

	private string _spacingUnit;

	private string _spaceBefore;

	private string _spaceAfter;

	private string _indentUnit;

	private string _leftIndent;

	private string _rightIndent;

	private string _specialIndent;

	private string _indentValue;

	private bool _supportsFont;

	private bool _supportsSpacing;

	private bool _supportsAlignment;

	private bool _supportsIndent;

	private bool _supportsBold;

	[CompilerGenerated]
	private Action _action;

	[CompilerGenerated]
	private Action _action;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _presetNames;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _levels;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _fonts;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _fontSizes;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _spacingUnits;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _alignments;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _indentUnits;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _specialIndents;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> _lineSpacingRules;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _saveCommand;

	[CompilerGenerated]
	private readonly ICommand _iCommand;

	[CompilerGenerated]
	private readonly ICommand _closeCommand;

	public ObservableCollection<string> PresetNames
	{
		[CompilerGenerated]
		get
		{
			return _presetNames;
		}
	}

	public ObservableCollection<string> Levels
	{
		[CompilerGenerated]
		get
		{
			return _levels;
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

	public ObservableCollection<Helper_14> SpacingUnits
	{
		[CompilerGenerated]
		get
		{
			return _spacingUnits;
		}
	}

	public ObservableCollection<Helper_14> Alignments
	{
		[CompilerGenerated]
		get
		{
			return _alignments;
		}
	}

	public ObservableCollection<Helper_14> IndentUnits
	{
		[CompilerGenerated]
		get
		{
			return _indentUnits;
		}
	}

	public ObservableCollection<Helper_14> SpecialIndents
	{
		[CompilerGenerated]
		get
		{
			return _specialIndents;
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
			return _saveCommand;
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
			return _closeCommand;
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
				SwitchPreset(value);
			}
		}
	}

	public string SelectedLevel
	{
		get
		{
			return _selectedLevel;
		}
		set
		{
			if (!_bool && !string.IsNullOrWhiteSpace(value) && !string.Equals(_selectedLevel, value, StringComparison.Ordinal))
			{
				if (!CollectAndValidateSettings())
				{
					RaisePropertyChanged("SelectedLevel");
					return;
				}
				_selectedLevel = value;
				RaisePropertyChanged("SelectedLevel");
				ApplyLevelSettings(value);
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

	public bool Bold
	{
		get
		{
			return _bold;
		}
		set
		{
			MrCsWWMvwp(ref _bold, value, "Bold");
		}
	}

	public string Alignment
	{
		get
		{
			return _alignment;
		}
		set
		{
			MrCsWWMvwp(ref _alignment, value, "Alignment");
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
			return _supportsFont;
		}
		private set
		{
			MrCsWWMvwp(ref _supportsFont, value, "SelectedLevel");
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
			return _supportsAlignment;
		}
		private set
		{
			MrCsWWMvwp(ref _supportsAlignment, value, "ChineseFont");
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

	public LegacyConfigMigrator2(DialogService P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_presetStore = new ConfigHelper_1("段落预设");
		_currentSettings = new Dictionary<string, string>();
		_selectedLevel = "一级";
		_presetNames = new ObservableCollection<string>();
		_dialogs = P_0 ?? throw new ArgumentNullException("dialogs");
		_levels = new ObservableCollection<string>(new string[9]
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
		_spacingUnits = BuildOptionList(("行", "行"), ("磅", "磅"));
		_alignments = BuildOptionList(("左对齐", "0"), ("居中", "1"), ("右对齐", "2"), ("两端对齐", "3"));
		_indentUnits = BuildOptionList(("字符", "字符"), ("厘米", "厘米"));
		_specialIndents = BuildOptionList(("首行", "首行"), ("悬挂", "悬挂"), ("无", "无"));
		_lineSpacingRules = BuildOptionList(("单倍行距", "0"), ("1.5倍行距", "1"), ("双倍行距", "2"), ("最小值", "3"), ("固定值", "4"), ("多倍行距", "5"));
		_iCommand = new DelegateCommand(ExecuteNewPreset);
		_iCommand = new DelegateCommand(ExecuteDeletePreset);
		_iCommand = new DelegateCommand(ExecuteImportPreset);
		_iCommand = new DelegateCommand(ExecuteExportPreset);
		_saveCommand = new DelegateCommand(ExecuteSave);
		_iCommand = new DelegateCommand((Action)delegate
		{
			_action?.Invoke();
		}, (Func<bool>)null);
		_closeCommand = new DelegateCommand((Action)delegate
		{
			_action?.Invoke();
		}, (Func<bool>)null);
		LoadInitialPreset();
		RefreshPresetNames();
		ApplyLevelSettings(_selectedLevel);
	}

	[SpecialName]
	[CompilerGenerated]
	public void add_OpenTableRequested(Action P_0)
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
	public void remove_OpenTableRequested(Action P_0)
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
	public void add_Closed(Action P_0)
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
	public void remove_Closed(Action P_0)
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

	private static ObservableCollection<Helper_14> BuildOptionList(params (string, string)[] values)
	{
		return new ObservableCollection<Helper_14>(values.Select(((string Text, string Value) value) => new Helper_14(value.Text, value.Value)));
	}

	private void LoadInitialPreset()
	{
		string text = (_selectedPreset = GetInitialPresetName());
		LoadSettingsFromDict(_presetStore.COQStnlspT(text));
	}

	private string GetInitialPresetName()
	{
		string[] array = new string[2]
		{
			TableBorderConfig.Current.GetString("段落配置_方案名", string.Empty),
			TableBorderConfig.Current.GetString("段落配置_当前方案", string.Empty)
		};
		foreach (string text in array)
		{
			if (!string.IsNullOrWhiteSpace(text) && _presetStore.haGSSyJWCc(text.Trim()))
			{
				return text.Trim();
			}
		}
		string text2 = _presetStore.ExsSbMHeGd().FirstOrDefault();
		if (!string.IsNullOrWhiteSpace(text2))
		{
			return text2;
		}
		_presetStore.SavePreset("默认方案", BuildDefaultSettings());
		return "默认方案";
	}

	private static Dictionary<string, string> BuildDefaultSettings()
	{
		return (from pair in TableBorderConfig.Current.GetAllLegacy()
			where pair.Key.StartsWith("Bold", StringComparison.Ordinal)
			select pair).ToDictionary((KeyValuePair<string, object> pair) => pair.Key, (KeyValuePair<string, object> pair) => pair.Value?.ToString() ?? string.Empty);
	}

	private void RefreshPresetNames()
	{
		_bool = true;
		PresetNames.Clear();
		foreach (string item in _presetStore.ExsSbMHeGd())
		{
			PresetNames.Add(item);
		}
		RaisePropertyChanged("SelectedPreset");
		_bool = false;
	}

	private void SwitchPreset(string P_0)
	{
		try
		{
			if (!CollectAndValidateSettings() || string.IsNullOrWhiteSpace(P_0) || !_presetStore.haGSSyJWCc(P_0))
			{
				RaisePropertyChanged("SelectedPreset");
				return;
			}
			_selectedPreset = P_0;
			RaisePropertyChanged("SelectedPreset");
			LoadSettingsFromDict(_presetStore.COQStnlspT(P_0));
			ApplyLevelSettings(_selectedLevel);
		}
		catch (Exception ex)
		{
			_dialogs.LogDebugMessage("切换方案失败：" + ex.Message, "IP_Assurance");
		}
	}

	private void LoadSettingsFromDict(IDictionary<string, string> P_0)
	{
		_currentSettings.Clear();
		if (P_0 == null)
		{
			return;
		}
		foreach (KeyValuePair<string, string> item in P_0.Where((KeyValuePair<string, string> pair) => pair.Key.StartsWith("Alignment", StringComparison.Ordinal)))
		{
			_currentSettings[item.Key] = item.Value ?? string.Empty;
		}
	}

	private void ApplyLevelSettings(string P_0)
	{
		_bool = true;
		string text = "段落_" + GetLevelConfigKey(P_0) + "_";
		ChineseFont = GetSettingOrDefault(text + "中文字体", "宋体");
		WesternFont = GetSettingOrDefault(text + "西文字体", "宋体");
		FontSize = AiHelper_20.NormalizeFontSize(GetSettingOrDefault(text + "字号", "10.5"));
		SupportsFont = SupportsFontForLevel(P_0);
		SupportsSpacing = SupportsSpacingForLevel(P_0);
		SupportsAlignment = SupportsAlignmentForLevel(P_0);
		SupportsIndent = SupportsIndentForLevel(P_0);
		SupportsBold = SupportsBoldForLevel(P_0);
		if (SupportsBold)
		{
			Bold = GetSettingOrDefault(text + "加粗", "0") == "1";
		}
		if (SupportsAlignment)
		{
			Alignment = GetSettingOrDefault(text + "对齐方式", GetDefaultAlignment(P_0));
		}
		if (SupportsSpacing)
		{
			LineSpacingRule = GetSettingOrDefault(text + "行距样式", GetDefaultLineSpacingRule(P_0));
			LineSpacing = GetSettingOrDefault(text + "行距值", "18");
			SpacingUnit = GetSettingOrDefault(text + "段前距单位", GetDefaultSpacingUnit(P_0));
			SpaceBefore = GetSettingOrDefault(text + "段前距", "0");
			SpaceAfter = GetSettingOrDefault(text + "段后距", GetDefaultSpaceAfter(P_0));
		}
		if (SupportsIndent)
		{
			IndentUnit = GetSettingOrDefault(text + "缩进单位", GetDefaultIndentUnit(P_0));
			LeftIndent = GetSettingOrDefault(text + "左缩进", "0");
			RightIndent = GetSettingOrDefault(text + "右缩进", "0");
			SpecialIndent = GetSettingOrDefault(text + "特殊缩进", GetDefaultSpecialIndent(P_0));
			IndentValue = GetSettingOrDefault(text + "缩进值", GetDefaultIndentValue(P_0));
		}
		_bool = false;
	}

	private bool CollectAndValidateSettings()
	{
		string text = "段落_" + GetLevelConfigKey(_selectedLevel) + "_";
		if (SupportsFontForLevel(_selectedLevel))
		{
			if (!AiHelper_20.TryFormatFontSize(FontSize, out var value))
			{
				_dialogs.LogMessage("字号填写有误，请选择 Word 字号或输入数字磅值。", "IP_Assurance");
				return false;
			}
			_currentSettings[text + "中文字体"] = ChineseFont ?? string.Empty;
			_currentSettings[text + "西文字体"] = WesternFont ?? string.Empty;
			_currentSettings[text + "字号"] = value;
		}
		if (SupportsBoldForLevel(_selectedLevel))
		{
			_currentSettings[text + "加粗"] = (Bold ? "0" : "1");
		}
		if (SupportsAlignmentForLevel(_selectedLevel))
		{
			_currentSettings[text + "对齐方式"] = Alignment ?? string.Empty;
		}
		if (SupportsSpacingForLevel(_selectedLevel))
		{
			_currentSettings[text + "行距样式"] = LineSpacingRule ?? string.Empty;
			_currentSettings[text + "行距值"] = LineSpacing ?? string.Empty;
			_currentSettings[text + "段前距单位"] = SpacingUnit ?? string.Empty;
			_currentSettings[text + "段前距"] = SpaceBefore ?? string.Empty;
			_currentSettings[text + "段后距"] = SpaceAfter ?? string.Empty;
		}
		if (SupportsIndentForLevel(_selectedLevel))
		{
			_currentSettings[text + "缩进单位"] = IndentUnit ?? string.Empty;
			_currentSettings[text + "左缩进"] = LeftIndent ?? string.Empty;
			_currentSettings[text + "右缩进"] = RightIndent ?? string.Empty;
			_currentSettings[text + "特殊缩进"] = SpecialIndent ?? string.Empty;
			_currentSettings[text + "缩进值"] = IndentValue ?? string.Empty;
		}
		return true;
	}

	private bool BuildExportSettings(out Dictionary<string, string> P_0)
	{
		P_0 = null;
		if (!CollectAndValidateSettings())
		{
			return false;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>(_currentSettings);
		string[] array = dictionary.Keys.Where((string key) => key.StartsWith("字号填写有误：", StringComparison.Ordinal) && key.EndsWith(" = ", StringComparison.Ordinal)).ToArray();
		foreach (string text in array)
		{
			if (AiHelper_20.TryFormatFontSize(dictionary[text], out var value))
			{
				dictionary[text] = value;
			}
			else if (_fontSizeValidationLevels.Contains(ExtractLevelFromKey(text)))
			{
				_dialogs.LogMessage("。请选择 Word 字号或输入数字磅值。" + text + "IP_Assurance" + dictionary[text] + "LineSpacingRule", "LineSpacingLabel");
				return false;
			}
		}
		P_0 = dictionary;
		return true;
	}

	private void ExecuteNewPreset()
	{
		string text = _dialogs.ShowInputDialog("新建方案", "请输入新方案名称：", "我的段落方案");
		if (!string.IsNullOrWhiteSpace(text))
		{
			string text2 = text.Trim();
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			foreach (char oldChar in invalidFileNameChars)
			{
				text2 = text2.Replace(oldChar, '_');
			}
			Dictionary<string, string> dictionary;
			if (_presetStore.haGSSyJWCc(text2))
			{
				_dialogs.LogMessage("同名方案已存在。", "IP_Assurance");
			}
			else if (BuildExportSettings(out dictionary))
			{
				_presetStore.SavePreset(text2, dictionary);
				_selectedPreset = text2;
				RefreshPresetNames();
				_dialogs.LogWarning("段落方案已创建。", "IP_Assurance");
			}
		}
	}

	private void ExecuteDeletePreset()
	{
		_presetStore.Delete(_selectedPreset);
		LoadInitialPreset();
		RefreshPresetNames();
		ApplyLevelSettings(_selectedLevel);
	}

	private void ExecuteImportPreset()
	{
		string text = _dialogs.BxkVLIlDE06("导入段落配置方案");
		if (text != null)
		{
			Dictionary<string, string> dictionary = _presetStore.ImportPresetFromFile(text);
			if (!dictionary.Keys.Any((string key) => key.StartsWith("所选文件不包含段落配置数据。", StringComparison.Ordinal)))
			{
				_dialogs.LogMessage("IP_Assurance", "IsLineSpacingValueEnabled");
				return;
			}
			string text2 = _presetStore.CreateUniquePresetName(Path.GetFileNameWithoutExtension(text));
			_presetStore.SavePreset(text2, dictionary);
			_selectedPreset = text2;
			LoadSettingsFromDict(dictionary);
			RefreshPresetNames();
			ApplyLevelSettings(_selectedLevel);
		}
	}

	private void ExecuteExportPreset()
	{
		string text = _dialogs.ShowSaveFileDialog("导出段落配置方案", _selectedPreset + ".json");
		if (text != null && BuildExportSettings(out var dictionary))
		{
			ConfigHelper_1.lRlSlvdQT7(text, dictionary);
		}
	}

	private void ExecuteSave()
	{
		try
		{
			if (!BuildExportSettings(out var dictionary))
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
			_presetStore.SavePreset(_selectedPreset, dictionary);
			_dialogs.LogWarning("段落配置已保存。", "IP_Assurance");
		}
		catch (Exception ex)
		{
			_dialogs.LogDebugMessage("保存段落配置失败：" + ex.Message, "IP_Assurance");
		}
	}

	private string GetSettingOrDefault(string P_0, string P_1)
	{
		if (!_currentSettings.TryGetValue(P_0, out var value) || string.IsNullOrEmpty(value))
		{
			return P_1;
		}
		return value;
	}

	private static string GetLevelConfigKey(string P_0)
	{
		if (!IsTableEndParagraphLevel(P_0))
		{
			return P_0;
		}
		return "表后段落";
	}

	private static bool IsTableEndParagraphLevel(string P_0)
	{
		if (!(P_0 == "表后间距"))
		{
			return P_0 == "表后段落";
		}
		return true;
	}

	private static bool SupportsFontForLevel(string P_0)
	{
		return !IsTableEndParagraphLevel(P_0);
	}

	private static bool SupportsSpacingForLevel(string P_0)
	{
		return !_noSpacingLevels.Contains(P_0);
	}

	private static bool SupportsAlignmentForLevel(string P_0)
	{
		if (SupportsSpacingForLevel(P_0))
		{
			return !IsTableEndParagraphLevel(P_0);
		}
		return false;
	}

	private static bool SupportsIndentForLevel(string P_0)
	{
		if (!_noSpacingLevels.Contains(P_0))
		{
			return !IsTableEndParagraphLevel(P_0);
		}
		return false;
	}

	private static bool SupportsBoldForLevel(string P_0)
	{
		if (SupportsIndentForLevel(P_0))
		{
			return P_0 != "表后注释";
		}
		return false;
	}

	private static string GetDefaultAlignment(string P_0)
	{
		if (!(P_0 == "表后注释") && !IsTableEndParagraphLevel(P_0))
		{
			return "0";
		}
		return "3";
	}

	private static string GetDefaultLineSpacingRule(string P_0)
	{
		if (!(P_0 == "表后注释"))
		{
			return "4";
		}
		return "0";
	}

	private static string GetDefaultSpacingUnit(string P_0)
	{
		if (!IsTableEndParagraphLevel(P_0))
		{
			return "行";
		}
		return "磅";
	}

	private static string GetDefaultSpaceAfter(string P_0)
	{
		if (!IsTableEndParagraphLevel(P_0))
		{
			return "0";
		}
		return "2.5";
	}

	private static string GetDefaultIndentUnit(string P_0)
	{
		if (!IsTableEndParagraphLevel(P_0))
		{
			return "字符";
		}
		return "厘米";
	}

	private static string GetDefaultSpecialIndent(string P_0)
	{
		if (!(P_0 == "表后注释"))
		{
			return "首行";
		}
		return "无";
	}

	private static string GetDefaultIndentValue(string P_0)
	{
		if (!(P_0 == "表后注释"))
		{
			if (!IsTableEndParagraphLevel(P_0))
			{
				return "2";
			}
			return "0.74";
		}
		return "0";
	}

	private static string ExtractLevelFromKey(string P_0)
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
		_noSpacingLevels = new string[1] { "表前单位" };
		_fontSizeValidationLevels = new string[8]
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
	private void RaiseOpenTableRequested()
	{
		_action?.Invoke();
	}

	[CompilerGenerated]
	private void RaiseClosed()
	{
		_action?.Invoke();
	}
}
