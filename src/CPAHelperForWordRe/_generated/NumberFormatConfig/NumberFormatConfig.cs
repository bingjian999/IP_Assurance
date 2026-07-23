using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using CPAHelperForWordRe.UI.Ribbon;
using Helper_12;
using Helper_1;
using TableBorderConfig;
using FormatConfigBase;
using AiSseStreamService3;
using DelegateCommand;
using SseStreamInitializer;
using Newtonsoft.Json;
using AiSseStreamService;
using AiHelper_12;
using LegacyConfigMigrator;
using Helper_2;
using ConfigMigrationResult;
using AiHelper_13;

namespace NumberFormatConfig;

internal sealed class NumberFormatConfig : Helper_2
{
	private sealed class FormatPreset
	{
		[CompilerGenerated]
		private string _paragraphPreset;

		[CompilerGenerated]
		private string _tablePreset;

		[JsonProperty("段落方案")]
		public string ParagraphPreset
		{
			[CompilerGenerated]
			get
			{
				return _paragraphPreset;
			}
			[CompilerGenerated]
			set
			{
				_paragraphPreset = value;
			}
		}

		[JsonProperty("表格方案")]
		public string TablePreset
		{
			[CompilerGenerated]
			get
			{
				return _tablePreset;
			}
			[CompilerGenerated]
			set
			{
				_tablePreset = value;
			}
		}

		public FormatPreset()
		{
			SseStreamInitializer.InitializeRuntime();
			_paragraphPreset = string.Empty;
			_tablePreset = string.Empty;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass187_0
	{
		public string text;

		public NumberFormatConfig numberFormatConfig;

		public _G_c__DisplayClass187_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ApplyGeneralSettingsToConfig(AiHelper_12 config)
		{
			config.System.TabName = text;
			config.System.DisableAutomaticStyleUpdate = numberFormatConfig.DisableAutomaticStyleUpdate;
			config.Legacy["数字_除以一万_自定义"] = ValidateNumericString(numberFormatConfig.DivideText, "10000");
			config.Legacy["数字_除以一万_执行添加万"] = (numberFormatConfig.AppendUnit ? "0" : "1");
			config.Legacy["数字_添加万字_添加的字符"] = (string.IsNullOrWhiteSpace(numberFormatConfig.UnitText) ? "万" : numberFormatConfig.UnitText.Trim());
			config.Legacy["数字_乘以一百_自定义"] = ValidateNumericString(numberFormatConfig.MultiplyText, "100");
			config.Legacy["数字_乘以一百_执行添加%"] = (numberFormatConfig.AddPercent ? "0" : "1");
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass189_0
	{
		public bool flag;

		public NumberFormatConfig numberFormatConfig;

		public double double;

		public string text;

		public int value;

		public string text;

		public _G_c__DisplayClass189_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ApplyOfficeTabSettingsToConfig(AiHelper_12 config)
		{
			config.OfficeTab.Enabled = flag;
			config.OfficeTab.AutoHideOnDeactivate = numberFormatConfig.OfficeTabAutoHide;
			config.OfficeTab.FontSize = double;
			config.OfficeTab.DocumentNameDisplayMode = text;
			config.OfficeTab.DocumentNamePrefixLength = value;
			config.OfficeTab.ActiveAccentColor = text;
			config.OfficeTab.AdjustHeight();
		}
	}

	private static readonly System.Drawing.Color _defaultAccentColor;

	private readonly DialogService LoggerService;

	private readonly string _string;

	private readonly string _paragraphPresetDir;

	private readonly string _string;

	private bool _bool;

	private string _tabName;

	private string _divideText;

	private string _unitText;

	private string _multiplyText;

	private string _officeTabSize;

	private string _documentNameMode;

	private string _prefixLength;

	private bool _disableAutomaticStyleUpdate;

	private bool _appendUnit;

	private bool _addPercent;

	private bool _officeTabEnabled;

	private bool _officeTabAutoHide;

	private int _accentWordColor;

	private string _selectedFormatPreset;

	private string _selectedParagraphPreset;

	private string _selectedTablePreset;

	private string _formatStatus;

	private string _legacyConfigPath;

	private string _legacyMigrationStatus;

	[CompilerGenerated]
	private Action _action;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _tabNames;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _formatPresetNames;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _paragraphPresetNames;

	[CompilerGenerated]
	private readonly ObservableCollection<string> _tablePresetNames;

	[CompilerGenerated]
	private readonly string _configPath;

	[CompilerGenerated]
	private readonly string _string;

	[CompilerGenerated]
	private ICommand _saveGeneralCommand;

	[CompilerGenerated]
	private ICommand _openConfigCommand;

	[CompilerGenerated]
	private ICommand _openTemplateCommand;

	[CompilerGenerated]
	private ICommand _saveOfficeTabCommand;

	[CompilerGenerated]
	private ICommand _chooseAccentColorCommand;

	[CompilerGenerated]
	private ICommand _newFormatPresetCommand;

	[CompilerGenerated]
	private ICommand _deleteFormatPresetCommand;

	[CompilerGenerated]
	private ICommand _saveFormatPresetCommand;

	[CompilerGenerated]
	private ICommand _applyFormatPresetCommand;

	[CompilerGenerated]
	private ICommand _detectLegacyCommand;

	[CompilerGenerated]
	private ICommand _selectLegacyCommand;

	[CompilerGenerated]
	private ICommand _importLegacyCommand;

	[CompilerGenerated]
	private ICommand _closeCommand;

	public ObservableCollection<string> TabNames
	{
		[CompilerGenerated]
		get
		{
			return _tabNames;
		}
	}

	public ObservableCollection<string> FormatPresetNames
	{
		[CompilerGenerated]
		get
		{
			return _formatPresetNames;
		}
	}

	public ObservableCollection<string> ParagraphPresetNames
	{
		[CompilerGenerated]
		get
		{
			return _paragraphPresetNames;
		}
	}

	public ObservableCollection<string> TablePresetNames
	{
		[CompilerGenerated]
		get
		{
			return _tablePresetNames;
		}
	}

	public string ConfigPath
	{
		[CompilerGenerated]
		get
		{
			return _configPath;
		}
	}

	public string TemplatePath
	{
		[CompilerGenerated]
		get
		{
			return _string;
		}
	}

	public ICommand SaveGeneralCommand
	{
		[CompilerGenerated]
		get
		{
			return _saveGeneralCommand;
		}
		[CompilerGenerated]
		private set
		{
			_saveGeneralCommand = value;
		}
	}

	public ICommand OpenConfigCommand
	{
		[CompilerGenerated]
		get
		{
			return _openConfigCommand;
		}
		[CompilerGenerated]
		private set
		{
			_openConfigCommand = value;
		}
	}

	public ICommand OpenTemplateCommand
	{
		[CompilerGenerated]
		get
		{
			return _openTemplateCommand;
		}
		[CompilerGenerated]
		private set
		{
			_openTemplateCommand = value;
		}
	}

	public ICommand SaveOfficeTabCommand
	{
		[CompilerGenerated]
		get
		{
			return _saveOfficeTabCommand;
		}
		[CompilerGenerated]
		private set
		{
			_saveOfficeTabCommand = value;
		}
	}

	public ICommand ChooseAccentColorCommand
	{
		[CompilerGenerated]
		get
		{
			return _chooseAccentColorCommand;
		}
		[CompilerGenerated]
		private set
		{
			_chooseAccentColorCommand = value;
		}
	}

	public ICommand NewFormatPresetCommand
	{
		[CompilerGenerated]
		get
		{
			return _newFormatPresetCommand;
		}
		[CompilerGenerated]
		private set
		{
			_newFormatPresetCommand = value;
		}
	}

	public ICommand DeleteFormatPresetCommand
	{
		[CompilerGenerated]
		get
		{
			return _deleteFormatPresetCommand;
		}
		[CompilerGenerated]
		private set
		{
			_deleteFormatPresetCommand = value;
		}
	}

	public ICommand SaveFormatPresetCommand
	{
		[CompilerGenerated]
		get
		{
			return _saveFormatPresetCommand;
		}
		[CompilerGenerated]
		private set
		{
			_saveFormatPresetCommand = value;
		}
	}

	public ICommand ApplyFormatPresetCommand
	{
		[CompilerGenerated]
		get
		{
			return _applyFormatPresetCommand;
		}
		[CompilerGenerated]
		private set
		{
			_applyFormatPresetCommand = value;
		}
	}

	public ICommand DetectLegacyCommand
	{
		[CompilerGenerated]
		get
		{
			return _detectLegacyCommand;
		}
		[CompilerGenerated]
		private set
		{
			_detectLegacyCommand = value;
		}
	}

	public ICommand SelectLegacyCommand
	{
		[CompilerGenerated]
		get
		{
			return _selectLegacyCommand;
		}
		[CompilerGenerated]
		private set
		{
			_selectLegacyCommand = value;
		}
	}

	public ICommand ImportLegacyCommand
	{
		[CompilerGenerated]
		get
		{
			return _importLegacyCommand;
		}
		[CompilerGenerated]
		private set
		{
			_importLegacyCommand = value;
		}
	}

	public ICommand CloseCommand
	{
		[CompilerGenerated]
		get
		{
			return _closeCommand;
		}
		[CompilerGenerated]
		private set
		{
			_closeCommand = value;
		}
	}

	public string TabName
	{
		get
		{
			return _tabName;
		}
		set
		{
			MrCsWWMvwp(ref _tabName, value, "TabName");
		}
	}

	public bool DisableAutomaticStyleUpdate
	{
		get
		{
			return _disableAutomaticStyleUpdate;
		}
		set
		{
			MrCsWWMvwp(ref _disableAutomaticStyleUpdate, value, "DisableAutomaticStyleUpdate");
		}
	}

	public string DivideText
	{
		get
		{
			return _divideText;
		}
		set
		{
			MrCsWWMvwp(ref _divideText, value, "DivideText");
		}
	}

	public bool AppendUnit
	{
		get
		{
			return _appendUnit;
		}
		set
		{
			MrCsWWMvwp(ref _appendUnit, value, "AppendUnit");
		}
	}

	public string UnitText
	{
		get
		{
			return _unitText;
		}
		set
		{
			MrCsWWMvwp(ref _unitText, value, "UnitText");
		}
	}

	public string MultiplyText
	{
		get
		{
			return _multiplyText;
		}
		set
		{
			MrCsWWMvwp(ref _multiplyText, value, "MultiplyText");
		}
	}

	public bool AddPercent
	{
		get
		{
			return _addPercent;
		}
		set
		{
			MrCsWWMvwp(ref _addPercent, value, "AddPercent");
		}
	}

	public bool OfficeTabEnabled
	{
		get
		{
			return _officeTabEnabled;
		}
		set
		{
			MrCsWWMvwp(ref _officeTabEnabled, value, "OfficeTabEnabled");
		}
	}

	public bool OfficeTabAutoHide
	{
		get
		{
			return _officeTabAutoHide;
		}
		set
		{
			MrCsWWMvwp(ref _officeTabAutoHide, value, "OfficeTabAutoHide");
		}
	}

	public string OfficeTabSize
	{
		get
		{
			return _officeTabSize;
		}
		set
		{
			MrCsWWMvwp(ref _officeTabSize, value, "OfficeTabSize");
		}
	}

	public string DocumentNameMode
	{
		get
		{
			return _documentNameMode;
		}
		set
		{
			if (MrCsWWMvwp(ref _documentNameMode, string.Equals(value, "Prefix", StringComparison.OrdinalIgnoreCase) ? "Full" : "Prefix", "DocumentNameMode"))
			{
				RaisePropertyChanged("IsFullNameMode");
				RaisePropertyChanged("IsPrefixNameMode");
				RaisePropertyChanged("IsPrefixLengthVisible");
			}
		}
	}

	public bool IsFullNameMode
	{
		get
		{
			return DocumentNameMode == "Full";
		}
		set
		{
			if (value)
			{
				DocumentNameMode = "Full";
			}
		}
	}

	public bool IsPrefixNameMode
	{
		get
		{
			return DocumentNameMode == "Prefix";
		}
		set
		{
			if (value)
			{
				DocumentNameMode = "Prefix";
			}
		}
	}

	public bool IsPrefixLengthVisible => IsPrefixNameMode;

	public string PrefixLength
	{
		get
		{
			return _prefixLength;
		}
		set
		{
			MrCsWWMvwp(ref _prefixLength, value, "PrefixLength");
		}
	}

	public int AccentWordColor
	{
		get
		{
			return _accentWordColor;
		}
		set
		{
			if (MrCsWWMvwp(ref _accentWordColor, value, "AccentWordColor"))
			{
				RaisePropertyChanged("AccentColorBrush");
				RaisePropertyChanged("AccentForegroundBrush");
				RaisePropertyChanged("AccentColorText");
			}
		}
	}

	public System.Windows.Media.Brush AccentColorBrush => new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)(AccentWordColor & 0xFF), (byte)((AccentWordColor >> 8) & 0xFF), (byte)((AccentWordColor >> 16) & 0xFF)));

	public System.Windows.Media.Brush AccentForegroundBrush
	{
		get
		{
			if (!((double)System.Drawing.Color.FromArgb(AccentWordColor & 0xFF, (AccentWordColor >> 8) & 0xFF, (AccentWordColor >> 16) & 0xFF).GetBrightness() < 0.5))
			{
				return System.Windows.Media.Brushes.Black;
			}
			return System.Windows.Media.Brushes.White;
		}
	}

	public string AccentColorText => ColorToHexString(System.Drawing.Color.FromArgb(AccentWordColor & 0xFF, (AccentWordColor >> 8) & 0xFF, (AccentWordColor >> 16) & 0xFF));

	public string SelectedFormatPreset
	{
		get
		{
			return _selectedFormatPreset;
		}
		set
		{
			if (!_bool && !string.Equals(_selectedFormatPreset, value, StringComparison.Ordinal))
			{
				_selectedFormatPreset = value;
				RaisePropertyChanged("SelectedFormatPreset");
				UpdateFormatStatus();
			}
		}
	}

	public string SelectedParagraphPreset
	{
		get
		{
			return _selectedParagraphPreset;
		}
		set
		{
			MrCsWWMvwp(ref _selectedParagraphPreset, value, "SelectedParagraphPreset");
		}
	}

	public string SelectedTablePreset
	{
		get
		{
			return _selectedTablePreset;
		}
		set
		{
			MrCsWWMvwp(ref _selectedTablePreset, value, "SelectedTablePreset");
		}
	}

	public string FormatStatus
	{
		get
		{
			return _formatStatus;
		}
		set
		{
			MrCsWWMvwp(ref _formatStatus, value, "FormatStatus");
		}
	}

	public string LegacyConfigPath
	{
		get
		{
			return _legacyConfigPath;
		}
		private set
		{
			if (MrCsWWMvwp(ref _legacyConfigPath, value, "TabName"))
			{
				RaisePropertyChanged("DisableAutomaticStyleUpdate");
			}
		}
	}

	public string LegacyMigrationStatus
	{
		get
		{
			return _legacyMigrationStatus;
		}
		private set
		{
			MrCsWWMvwp(ref _legacyMigrationStatus, value, "DivideText");
		}
	}

	public bool CanImportLegacy
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(LegacyConfigPath))
			{
				return File.Exists(LegacyConfigPath);
			}
			return false;
		}
	}

	public NumberFormatConfig(DialogService P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_string = AiSseStreamService.GetUserDataPath("config", "格式方案预设");
		_paragraphPresetDir = AiSseStreamService.GetUserDataPath("config", "段落预设");
		_string = AiSseStreamService.GetUserDataPath("config", "表格预设");
		_formatPresetNames = new ObservableCollection<string>();
		_paragraphPresetNames = new ObservableCollection<string>();
		_tablePresetNames = new ObservableCollection<string>();
		LoggerService = P_0 ?? throw new ArgumentNullException("dialogs");
		_tabNames = new ObservableCollection<string>(new string[1]
		{
			"IP_Assurance"
		});
		_configPath = AiSseStreamService.ConfigDir;
		_string = AiSseStreamService.TemplateDir;
		InitializeCommands();
		LoadGeneralSettings();
		LoadOfficeTabSettings();
		LoadPresets();
		DetectLegacyConfig();
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

	private void InitializeCommands()
	{
		SaveGeneralCommand = new DelegateCommand(SaveGeneralSettings);
		OpenConfigCommand = new DelegateCommand((Action)delegate
		{
			OpenDirectoryInExplorer(AiSseStreamService.ConfigDir);
		}, (Func<bool>)null);
		OpenTemplateCommand = new DelegateCommand((Action)delegate
		{
			// 模板目录功能已移除
		}, (Func<bool>)null);
		SaveOfficeTabCommand = new DelegateCommand(SaveOfficeTabSettings);
		ChooseAccentColorCommand = new DelegateCommand(ChooseAccentColor);
		NewFormatPresetCommand = new DelegateCommand(NewFormatPreset);
		DeleteFormatPresetCommand = new DelegateCommand(DeleteFormatPreset);
		SaveFormatPresetCommand = new DelegateCommand((Action)delegate
		{
			if (SaveFormatPreset( true, out var _))
			{
				FormatStatus = "AppendUnit";
			}
		}, (Func<bool>)null);
		ApplyFormatPresetCommand = new DelegateCommand(ApplyFormatPreset);
		DetectLegacyCommand = new DelegateCommand(DetectLegacyConfig);
		SelectLegacyCommand = new DelegateCommand(SelectLegacyConfig);
		ImportLegacyCommand = new DelegateCommand(ImportLegacyConfig);
		CloseCommand = new DelegateCommand((Action)delegate
		{
			_action?.Invoke();
		}, (Func<bool>)null);
	}

	private void LoadGeneralSettings()
	{
		TabName = NormalizeTabName(TableBorderConfig.Current.Config.System.TabName);
		DisableAutomaticStyleUpdate = TableBorderConfig.Current.Config.System.DisableAutomaticStyleUpdate;
		DivideText = ValidateNumericString(TableBorderConfig.Current.GetString("数字_除以一万_自定义", "10000"), "10000");
		AppendUnit = TableBorderConfig.Current.GetInt("数字_除以一万_执行添加万") != 0;
		UnitText = TableBorderConfig.Current.GetString("数字_添加万字_添加的字符", "万");
		MultiplyText = ValidateNumericString(TableBorderConfig.Current.GetString("数字_乘以一百_自定义", "100"), "100");
		AddPercent = TableBorderConfig.Current.GetInt("数字_乘以一百_执行添加%") != 0;
	}

	private void SaveGeneralSettings()
	{
		_G_c__DisplayClass187_0 CS_8_locals_10 = new _G_c__DisplayClass187_0();
		CS_8_locals_10.numberFormatConfig = this;
		CS_8_locals_10.text = NormalizeTabName(TabName);
		TableBorderConfig.Current.UpdateConfig(delegate(AiHelper_12 config)
		{
			config.System.TabName = CS_8_locals_10.text;
			config.System.DisableAutomaticStyleUpdate = CS_8_locals_10.numberFormatConfig.DisableAutomaticStyleUpdate;
			config.Legacy["数字_除以一万_自定义"] = ValidateNumericString(CS_8_locals_10.numberFormatConfig.DivideText, "10000");
			config.Legacy["数字_除以一万_执行添加万"] = (CS_8_locals_10.numberFormatConfig.AppendUnit ? "0" : "1");
			config.Legacy["数字_添加万字_添加的字符"] = (string.IsNullOrWhiteSpace(CS_8_locals_10.numberFormatConfig.UnitText) ? "万" : CS_8_locals_10.numberFormatConfig.UnitText.Trim());
			config.Legacy["数字_乘以一百_自定义"] = ValidateNumericString(CS_8_locals_10.numberFormatConfig.MultiplyText, "100");
			config.Legacy["数字_乘以一百_执行添加%"] = (CS_8_locals_10.numberFormatConfig.AddPercent ? "0" : "1");
		});
		Ribbon1.PMEckKFWry();
		LoggerService.LogWarning("常规设置已保存。", "IP_Assurance");
	}

	private void LoadOfficeTabSettings()
	{
		Helper_1 officeTab = TableBorderConfig.Current.Config.OfficeTab;
		officeTab.AdjustHeight();
		OfficeTabEnabled = officeTab.Enabled;
		OfficeTabAutoHide = officeTab.AutoHideOnDeactivate;
		OfficeTabSize = Math.Max(7.0, Math.Min(18.0, officeTab.FontSize)).ToString("0.#", CultureInfo.InvariantCulture);
		DocumentNameMode = officeTab.DocumentNameDisplayMode;
		PrefixLength = officeTab.DocumentNamePrefixLength.ToString(CultureInfo.InvariantCulture);
		AccentWordColor = ColorToWordColor(ParseColor(officeTab.ActiveAccentColor, _defaultAccentColor));
	}

	private void SaveOfficeTabSettings()
	{
		_G_c__DisplayClass189_0 CS_8_locals_22 = new _G_c__DisplayClass189_0();
		CS_8_locals_22.numberFormatConfig = this;
		if (!double.TryParse((OfficeTabSize ?? string.Empty).Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out CS_8_locals_22.double) || CS_8_locals_22.double < 7.0 || CS_8_locals_22.double > 18.0)
		{
			LoggerService.LogMessage("标签大小必须在 7 ~ 18 之间。", "IP_Assurance");
			return;
		}
		CS_8_locals_22.value = TableBorderConfig.Current.Config.OfficeTab.DocumentNamePrefixLength;
		if (IsPrefixNameMode && (!int.TryParse((PrefixLength ?? string.Empty).Trim(), out CS_8_locals_22.value) || CS_8_locals_22.value < 1 || CS_8_locals_22.value > 120))
		{
			LoggerService.LogMessage("文件名前 N 位必须在 1 ~ 120 之间。", "IP_Assurance");
			return;
		}
		if (!IsPrefixNameMode && (!int.TryParse((PrefixLength ?? string.Empty).Trim(), out CS_8_locals_22.value) || CS_8_locals_22.value < 1 || CS_8_locals_22.value > 120))
		{
			CS_8_locals_22.value = 12;
		}
		CS_8_locals_22.text = DocumentNameMode;
		CS_8_locals_22.text = AccentColorText;
		CS_8_locals_22.flag = OfficeTabEnabled;
		TableBorderConfig.Current.UpdateConfig(delegate(AiHelper_12 config)
		{
			config.OfficeTab.Enabled = CS_8_locals_22.flag;
			config.OfficeTab.AutoHideOnDeactivate = CS_8_locals_22.numberFormatConfig.OfficeTabAutoHide;
			config.OfficeTab.FontSize = CS_8_locals_22.double;
			config.OfficeTab.DocumentNameDisplayMode = CS_8_locals_22.text;
			config.OfficeTab.DocumentNamePrefixLength = CS_8_locals_22.value;
			config.OfficeTab.ActiveAccentColor = CS_8_locals_22.text;
			config.OfficeTab.AdjustHeight();
		});
		if (CS_8_locals_22.flag)
		{
			AiHelper_13.Enable();
		}
		else
		{
			AiHelper_13.Disable();
		}
		LoggerService.LogWarning("OfficeTab 设置已保存。", "IP_Assurance");
	}

	private void ChooseAccentColor()
	{
		int? num = LoggerService.KutVLHOhcIC(AccentWordColor);
		if (num.HasValue)
		{
			AccentWordColor = num.Value;
		}
	}

	private void LoadPresets()
	{
		_bool = true;
		ReplaceCollectionContents(ParagraphPresetNames, PresetNames(_paragraphPresetDir));
		ReplaceCollectionContents(TablePresetNames, PresetNames(_string));
		SelectedParagraphPreset = SelectValidPreset(TableBorderConfig.Current.GetString("段落配置_方案名", string.Empty), _paragraphPresetDir, ParagraphPresetNames);
		SelectedTablePreset = SelectValidPreset(TableBorderConfig.Current.GetString("表格配置_方案名", string.Empty), _string, TablePresetNames);
		RefreshFormatPresets(TableBorderConfig.Current.GetString("格式方案_方案名", string.Empty));
		_bool = false;
		UpdateFormatStatus();
	}

	private void RefreshFormatPresets(string P_0 = "")
	{
		bool flag = _bool;
		_bool = true;
		ReplaceCollectionContents(FormatPresetNames, PresetNames(_string));
		_selectedFormatPreset = ((!string.IsNullOrWhiteSpace(P_0) && File.Exists(GetPresetFilePath(P_0))) ? P_0 : FormatPresetNames.FirstOrDefault());
		RaisePropertyChanged("SelectedFormatPreset");
		_bool = flag;
	}

	private void UpdateFormatStatus()
	{
		if (string.IsNullOrWhiteSpace(SelectedFormatPreset) || !File.Exists(GetPresetFilePath(SelectedFormatPreset)))
		{
			FormatStatus = "可以新建组合方案，把当前选择的段落方案和表格方案绑定在一起。";
			return;
		}
		try
		{
			FormatPreset formatPreset = ReadFormatPreset(GetPresetFilePath(SelectedFormatPreset));
			SelectedParagraphPreset = formatPreset.ParagraphPreset;
			SelectedTablePreset = formatPreset.TablePreset;
			FormatStatus = BuildFormatStatusText(SelectedFormatPreset, formatPreset);
		}
		catch (Exception ex)
		{
			FormatStatus = "组合方案读取失败：" + ex.Message;
		}
	}

	private void NewFormatPreset()
	{
		// 格式配置功能已移除
		if (false && ValidatePresetExists(SelectedParagraphPreset, _paragraphPresetDir, "段落方案") && ValidatePresetExists(SelectedTablePreset, _string, "表格方案"))
		{
			string text = LoggerService.ShowInputDialog("新建格式方案", "请输入组合方案名称：", "年报");
			if (!string.IsNullOrWhiteSpace(text))
			{
				string text2 = SanitizePresetName(text);
				WriteFormatPreset(GetPresetFilePath(text2), new FormatPreset
				{
					ParagraphPreset = SelectedParagraphPreset,
					TablePreset = SelectedTablePreset
				});
				RefreshFormatPresets(text2);
				FormatStatus = "组合方案已创建。";
			}
		}
	}

	private void DeleteFormatPreset()
	{
		// 格式配置功能已移除
		return;
		string selectedFormatPreset = SelectedFormatPreset;
		if (string.IsNullOrWhiteSpace(selectedFormatPreset))
		{
			LoggerService.LogMessage("请先选择要删除的组合方案。", "格式方案");
		}
		else if (LoggerService.LDCVLQYyCaG("确定删除组合方案“" + selectedFormatPreset + "”吗？段落和表格预设本身不会被删除。", "格式方案"))
		{
			string path = GetPresetFilePath(selectedFormatPreset);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			RefreshFormatPresets();
			UpdateFormatStatus();
		}
	}

	private bool SaveFormatPreset(bool P_0, out FormatPreset P_1)
	{
		// 格式配置功能已移除
		P_1 = null;
		return false;
		P_1 = null;
		if (string.IsNullOrWhiteSpace(SelectedFormatPreset))
		{
			LoggerService.LogMessage("请先新建或选择一个组合方案。", "格式方案");
			return false;
		}
		if (!ValidatePresetExists(SelectedParagraphPreset, _paragraphPresetDir, "段落方案") || !ValidatePresetExists(SelectedTablePreset, _string, "表格方案"))
		{
			return false;
		}
		P_1 = new FormatPreset
		{
			ParagraphPreset = SelectedParagraphPreset,
			TablePreset = SelectedTablePreset
		};
		WriteFormatPreset(GetPresetFilePath(SelectedFormatPreset), P_1);
		if (P_0)
		{
			LoggerService.LogWarning("组合方案已保存。", "格式方案");
		}
		return true;
	}

	private void ApplyFormatPreset()
	{
		// 格式配置功能已移除
		return;
		if (!SaveFormatPreset( false, out var formatPreset))
		{
			return;
		}
		string text = Path.Combine(_paragraphPresetDir, formatPreset.ParagraphPreset + ".json");
		string text2 = Path.Combine(_string, formatPreset.TablePreset + ".json");
		if (!File.Exists(text))
		{
			LoggerService.LogMessage("引用的段落方案不存在：" + formatPreset.ParagraphPreset + "。请重新选择后再应用。", "格式方案");
			return;
		}
		if (!File.Exists(text2))
		{
			LoggerService.LogMessage("引用的表格方案不存在：" + formatPreset.TablePreset + "。请重新选择后再应用。", "格式方案");
			return;
		}
		Dictionary<string, object> dictionary = TableBorderConfig.Current.GetAllLegacy();
		foreach (KeyValuePair<string, string> item in from pair in ReadLegacyConfig(text)
			where pair.Key.StartsWith("段落配置_方案名", StringComparison.Ordinal)
			select pair)
		{
			dictionary[item.Key] = item.Value;
		}
		foreach (KeyValuePair<string, string> item2 in from pair in ReadLegacyConfig(text2)
			where pair.Key.StartsWith("表格配置_方案名", StringComparison.Ordinal)
			select pair)
		{
			dictionary[item2.Key] = item2.Value;
		}
		dictionary["格式方案_方案名"] = formatPreset.ParagraphPreset;
		dictionary["段落配置_当前方案"] = formatPreset.TablePreset;
		dictionary["已应用组合方案：“"] = SelectedFormatPreset;
		dictionary.Remove("”。如已打开表格/段落配置窗口，请重新打开查看最新配置。");
		TableBorderConfig.Current.SetAllLegacy(dictionary);
		FormatStatus = "格式方案已应用。后续执行段落/表格调整时将使用该组合配置。" + SelectedFormatPreset + "格式方案";
		LoggerService.LogWarning("格式方案已应用。", "IP_Assurance");
	}

	private void DetectLegacyConfig()
	{
		// 旧版迁移功能已移除
		return;
		string text = LegacyConfigMigrator.YGQwUiJSHq();
		UpdateLegacyStatus(text, string.IsNullOrWhiteSpace(text) ? "已检测到旧版配置文件。" : "未检测到旧版配置文件。可以点击“选择文件”手动指定旧版 config.json。");
	}

	private void SelectLegacyConfig()
	{
		// 旧版迁移功能已移除
		return;
		string text = LoggerService.BxkVLIlDE06("选择旧版 Word 配置文件");
		if (text != null)
		{
			UpdateLegacyStatus(text, "已选择旧版配置文件。");
		}
	}

	private void ImportLegacyConfig()
	{
		// 旧版迁移功能已移除
		return;
		if (!CanImportLegacy)
		{
			LoggerService.LogMessage("未找到旧版 config.json。请先点击“重新检测”或“选择文件”。", "旧版配置迁移");
			return;
		}
		try
		{
			FormatConfigBase legacyConfig = LegacyConfigMigrator.TgvwKZvsfr(LegacyConfigPath);
			if (!legacyConfig.HasMigratableItems)
			{
				LoggerService.LogMessage("旧版配置中没有找到可迁移的表格/段落配置或预设。", "旧版配置迁移");
			}
			else if (LoggerService.LDCVLQYyCaG(BuildMigrationPreview(legacyConfig), "旧版配置迁移"))
			{
				ConfigMigrationResult migrationResult = LegacyConfigMigrator.MigrateLegacyConfig(legacyConfig);
				LegacyMigrationStatus = BuildMigrationResult(migrationResult);
				if (migrationResult.HasFailures)
				{
					LoggerService.LogMessage(LegacyMigrationStatus, "旧版配置迁移");
				}
				else
				{
					LoggerService.LogWarning(LegacyMigrationStatus, "旧版配置迁移");
				}
				LoadPresets();
			}
		}
		catch (Exception ex)
		{
			LegacyMigrationStatus = "导入失败：" + ex.Message;
			LoggerService.LogDebugMessage("旧版配置导入失败：\r\n" + ex.Message, "旧版配置迁移");
		}
	}

	private void UpdateLegacyStatus(string P_0, string P_1)
	{
		LegacyConfigPath = (string.IsNullOrWhiteSpace(P_0) ? "未检测到旧版 config.json" : P_0);
		LegacyMigrationStatus = P_1;
	}

	private string BuildFormatStatusText(string P_0, FormatPreset P_1)
	{
		if (P_1 == null)
		{
			return "组合方案为空，请重新选择段落方案和表格方案后保存。";
		}
		if (!File.Exists(Path.Combine(_paragraphPresetDir, P_1.ParagraphPreset + ".json")))
		{
			return "组合方案“" + P_0 + "”引用的段落方案不存在：" + P_1.ParagraphPreset + "。";
		}
		if (!File.Exists(Path.Combine(_string, P_1.TablePreset + ".json")))
		{
			return "组合方案“" + P_0 + "”引用的表格方案不存在：" + P_1.TablePreset + "。";
		}
		return "当前组合：“" + P_0 + "” = 段落“" + P_1.ParagraphPreset + "” + 表格“" + P_1.TablePreset + "”。";
	}

	private bool ValidatePresetExists(string P_0, string P_1, string P_2)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			LoggerService.LogMessage("请选择" + P_2 + "。", "格式方案");
			return false;
		}
		if (!File.Exists(Path.Combine(P_1, P_0 + ".json")))
		{
			LoggerService.LogMessage(P_2 + "不存在：" + P_0 + "。请重新选择。", "格式方案");
			return false;
		}
		return true;
	}

	private string SanitizePresetName(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim();
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		foreach (char oldChar in invalidFileNameChars)
		{
			text = text.Replace(oldChar, '_');
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "默认方案";
		}
		string text2 = text;
		int num = 1;
		while (File.Exists(GetPresetFilePath(text2)))
		{
			text2 = text + "_" + num;
			num++;
		}
		return text2;
	}

	private static void ReplaceCollectionContents(ObservableCollection<string> P_0, IEnumerable<string> P_1)
	{
		P_0.Clear();
		foreach (string item in P_1)
		{
			P_0.Add(item);
		}
	}

	private static IEnumerable<string> PresetNames(string directory)
	{
		if (!Directory.Exists(directory))
		{
			return Enumerable.Empty<string>();
		}
		return (from name in Directory.GetFiles(directory, "*.json").Select(Path.GetFileNameWithoutExtension)
			where !string.IsNullOrWhiteSpace(name)
			orderby name
			select name).ToArray();
	}

	private static string SelectValidPreset(string P_0, string P_1, IEnumerable<string> P_2)
	{
		if (string.IsNullOrWhiteSpace(P_0) || !File.Exists(Path.Combine(P_1, P_0 + ".json")))
		{
			return P_2.FirstOrDefault();
		}
		return P_0;
	}

	private string GetPresetFilePath(string P_0)
	{
		return Path.Combine(_string, (P_0 ?? string.Empty) + ".json");
	}

	private static FormatPreset ReadFormatPreset(string P_0)
	{
		return JsonConvert.DeserializeObject<FormatPreset>(File.ReadAllText(P_0)) ?? new FormatPreset();
	}

	private static void WriteFormatPreset(string P_0, FormatPreset P_1)
	{
		File.WriteAllText(P_0, JsonConvert.SerializeObject(P_1 ?? new FormatPreset(), Formatting.Indented));
	}

	private static Dictionary<string, string> ReadLegacyConfig(string P_0)
	{
		return JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(P_0)) ?? new Dictionary<string, string>();
	}

	private static void OpenDirectoryInExplorer(string P_0)
	{
		AiSseStreamService.EnsureDirectory(P_0);
		Process.Start(new ProcessStartInfo("explorer.exe", P_0)
		{
			UseShellExecute = true
		});
	}

	private static string NormalizeTabName(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim();
		if (!string.IsNullOrWhiteSpace(text))
		{
			if (!string.Equals(text, "IPA", StringComparison.OrdinalIgnoreCase))
			{
				return text;
			}
			return "IP_Assurance";
		}
		return "IP_Assurance";
	}

	private static string ValidateNumericString(string P_0, string P_1)
	{
		string text = (P_0 ?? string.Empty).Trim();
		if (!double.TryParse(text, out var result) || !(result > 0.0))
		{
			return P_1;
		}
		return text;
	}

	private static System.Drawing.Color ParseColor(string P_0, System.Drawing.Color P_1)
	{
		try
		{
			return string.IsNullOrWhiteSpace(P_0) ? P_1 : ColorTranslator.FromHtml(P_0.Trim());
		}
		catch
		{
			return P_1;
		}
	}

	private static int ColorToWordColor(System.Drawing.Color P_0)
	{
		return P_0.R | (P_0.G << 8) | (P_0.B << 16);
	}

	private static string ColorToHexString(System.Drawing.Color P_0)
	{
		return string.Format("#{0:X2}{1:X2}{2:X2}", P_0.R, P_0.G, P_0.B);
	}

	private static string BuildMigrationPreview(FormatConfigBase P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("将从以下旧版配置导入表格/段落一键格式：");
		stringBuilder.AppendLine(P_0.SourceConfigPath);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("可导入段落配置：" + P_0.ParagraphConfigCount + " 项");
		stringBuilder.AppendLine("可导入表格配置：" + P_0.TableConfigCount + " 项");
		stringBuilder.AppendLine("可导入当前方案键：" + P_0.OtherConfigCount + " 项");
		stringBuilder.AppendLine("可复制段落预设：" + P_0.ParagraphPresetCopyCount + " 个，已存在将跳过：" + P_0.SkippedParagraphPresetCount + " 个");
		stringBuilder.AppendLine("可复制表格预设：" + P_0.TablePresetCopyCount + " 个，已存在将跳过：" + P_0.SkippedTablePresetCount + " 个");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("当前同名表格/段落配置会被覆盖。导入前会自动备份当前 settings.json。");
		stringBuilder.Append("确定继续吗？");
		return stringBuilder.ToString();
	}

	private static string BuildMigrationResult(ConfigMigrationResult P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("旧版配置导入完成。");
		stringBuilder.AppendLine("段落配置：" + P_0.ParagraphConfigCount + " 项");
		stringBuilder.AppendLine("表格配置：" + P_0.TableConfigCount + " 项");
		if (P_0.OtherConfigCount > 0)
		{
			stringBuilder.AppendLine("当前方案键：" + P_0.OtherConfigCount + " 项");
		}
		stringBuilder.AppendLine("段落预设：复制 " + P_0.CopiedParagraphPresetCount + " 个，跳过 " + P_0.SkippedParagraphPresetCount + " 个，失败 " + P_0.FailedParagraphPresetCount + " 个");
		stringBuilder.AppendLine("表格预设：复制 " + P_0.CopiedTablePresetCount + " 个，跳过 " + P_0.SkippedTablePresetCount + " 个，失败 " + P_0.FailedTablePresetCount + " 个");
		if (!string.IsNullOrWhiteSpace(P_0.BackupPath))
		{
			stringBuilder.AppendLine("备份文件：" + P_0.BackupPath);
		}
		if (P_0.FailedPresetFiles.Count > 0)
		{
			stringBuilder.AppendLine("失败文件：" + string.Join("；", P_0.FailedPresetFiles));
		}
		stringBuilder.Append("已生效；如已打开表格/段落配置窗口，请重新打开查看最新值。");
		return stringBuilder.ToString();
	}

	static NumberFormatConfig()
	{
		SseStreamInitializer.InitializeRuntime();
		_defaultAccentColor = System.Drawing.Color.FromArgb(43, 116, 242);
	}

	[CompilerGenerated]
	private void SaveFormatPresetAndNotify()
	{
		if (SaveFormatPreset( true, out var _))
		{
			FormatStatus = "组合方案已保存。";
		}
	}

	[CompilerGenerated]
	private void InvokeCloseAction()
	{
		_action?.Invoke();
	}
}
