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
	private sealed class Ws1A6IV2tQ3IY0xZETbe
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

		public Ws1A6IV2tQ3IY0xZETbe()
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

		internal void ylgV2FbVgb8(AiHelper_12 config)
		{
			config.System.TabName = text;
			config.System.DisableAutomaticStyleUpdate = numberFormatConfig.DisableAutomaticStyleUpdate;
			config.Legacy["数字_除以一万_自定义"] = x5PolLGHZO(numberFormatConfig.DivideText, "10000");
			config.Legacy["数字_除以一万_执行添加万"] = (numberFormatConfig.AppendUnit ? "0" : "1");
			config.Legacy["数字_添加万字_添加的字符"] = (string.IsNullOrWhiteSpace(numberFormatConfig.UnitText) ? "万" : numberFormatConfig.UnitText.Trim());
			config.Legacy["数字_乘以一百_自定义"] = x5PolLGHZO(numberFormatConfig.MultiplyText, "100");
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

		internal void x8NV2qhjkXY(AiHelper_12 config)
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

	private static readonly System.Drawing.Color t1focbbthA;

	private readonly HDS8hJGbnCWyNGfO01j LoggerService;

	private readonly string _string;

	private readonly string yenoXGmBxE;

	private readonly string _string;

	private bool _bool;

	private string b7joa4fj3r;

	private string _divideText;

	private string OOSoPcsrhc;

	private string _multiplyText;

	private string WGhovnfRlX;

	private string xIVoWtKZPm;

	private string _prefixLength;

	private bool eJJokIRFjU;

	private bool KdgoxvArD4;

	private bool KMbodUwlA3;

	private bool _officeTabEnabled;

	private bool xQyGRqjYCF;

	private int _accentWordColor;

	private string _selectedFormatPreset;

	private string _selectedParagraphPreset;

	private string _selectedTablePreset;

	private string GSTGuwNw31;

	private string QkrGDBlTGS;

	private string cCqGTbbknq;

	[CompilerGenerated]
	private Action _action;

	[CompilerGenerated]
	private readonly ObservableCollection<string> TX8G8XOruX;

	[CompilerGenerated]
	private readonly ObservableCollection<string> TGjGINXrH6;

	[CompilerGenerated]
	private readonly ObservableCollection<string> fmQGiKAWHR;

	[CompilerGenerated]
	private readonly ObservableCollection<string> YRgGHs8AQj;

	[CompilerGenerated]
	private readonly string grNGQdmWDO;

	[CompilerGenerated]
	private readonly string _string;

	[CompilerGenerated]
	private ICommand IGyGrngUoZ;

	[CompilerGenerated]
	private ICommand _openConfigCommand;

	[CompilerGenerated]
	private ICommand _openTemplateCommand;

	[CompilerGenerated]
	private ICommand xObGUGLQdn;

	[CompilerGenerated]
	private ICommand aUTGKlxVGh;

	[CompilerGenerated]
	private ICommand _newFormatPresetCommand;

	[CompilerGenerated]
	private ICommand _deleteFormatPresetCommand;

	[CompilerGenerated]
	private ICommand _saveFormatPresetCommand;

	[CompilerGenerated]
	private ICommand MefGjGgrcX;

	[CompilerGenerated]
	private ICommand jASGYpLOQQ;

	[CompilerGenerated]
	private ICommand WuKGZletED;

	[CompilerGenerated]
	private ICommand _importLegacyCommand;

	[CompilerGenerated]
	private ICommand ERRGMkeuEj;

	public ObservableCollection<string> TabNames
	{
		[CompilerGenerated]
		get
		{
			return TX8G8XOruX;
		}
	}

	public ObservableCollection<string> FormatPresetNames
	{
		[CompilerGenerated]
		get
		{
			return TGjGINXrH6;
		}
	}

	public ObservableCollection<string> ParagraphPresetNames
	{
		[CompilerGenerated]
		get
		{
			return fmQGiKAWHR;
		}
	}

	public ObservableCollection<string> TablePresetNames
	{
		[CompilerGenerated]
		get
		{
			return YRgGHs8AQj;
		}
	}

	public string ConfigPath
	{
		[CompilerGenerated]
		get
		{
			return grNGQdmWDO;
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
			return IGyGrngUoZ;
		}
		[CompilerGenerated]
		private set
		{
			IGyGrngUoZ = value;
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
			return xObGUGLQdn;
		}
		[CompilerGenerated]
		private set
		{
			xObGUGLQdn = value;
		}
	}

	public ICommand ChooseAccentColorCommand
	{
		[CompilerGenerated]
		get
		{
			return aUTGKlxVGh;
		}
		[CompilerGenerated]
		private set
		{
			aUTGKlxVGh = value;
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
			return MefGjGgrcX;
		}
		[CompilerGenerated]
		private set
		{
			MefGjGgrcX = value;
		}
	}

	public ICommand DetectLegacyCommand
	{
		[CompilerGenerated]
		get
		{
			return jASGYpLOQQ;
		}
		[CompilerGenerated]
		private set
		{
			jASGYpLOQQ = value;
		}
	}

	public ICommand SelectLegacyCommand
	{
		[CompilerGenerated]
		get
		{
			return WuKGZletED;
		}
		[CompilerGenerated]
		private set
		{
			WuKGZletED = value;
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
			return ERRGMkeuEj;
		}
		[CompilerGenerated]
		private set
		{
			ERRGMkeuEj = value;
		}
	}

	public string TabName
	{
		get
		{
			return b7joa4fj3r;
		}
		set
		{
			MrCsWWMvwp(ref b7joa4fj3r, value, "TabName");
		}
	}

	public bool DisableAutomaticStyleUpdate
	{
		get
		{
			return eJJokIRFjU;
		}
		set
		{
			MrCsWWMvwp(ref eJJokIRFjU, value, "DisableAutomaticStyleUpdate");
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
			return KdgoxvArD4;
		}
		set
		{
			MrCsWWMvwp(ref KdgoxvArD4, value, "AppendUnit");
		}
	}

	public string UnitText
	{
		get
		{
			return OOSoPcsrhc;
		}
		set
		{
			MrCsWWMvwp(ref OOSoPcsrhc, value, "UnitText");
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
			return KMbodUwlA3;
		}
		set
		{
			MrCsWWMvwp(ref KMbodUwlA3, value, "AddPercent");
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
			return xQyGRqjYCF;
		}
		set
		{
			MrCsWWMvwp(ref xQyGRqjYCF, value, "OfficeTabAutoHide");
		}
	}

	public string OfficeTabSize
	{
		get
		{
			return WGhovnfRlX;
		}
		set
		{
			MrCsWWMvwp(ref WGhovnfRlX, value, "OfficeTabSize");
		}
	}

	public string DocumentNameMode
	{
		get
		{
			return xIVoWtKZPm;
		}
		set
		{
			if (MrCsWWMvwp(ref xIVoWtKZPm, string.Equals(value, "Prefix", StringComparison.OrdinalIgnoreCase) ? "Full" : "Prefix", "DocumentNameMode"))
			{
				fpVsxno8nm("IsFullNameMode");
				fpVsxno8nm("IsPrefixNameMode");
				fpVsxno8nm("IsPrefixLengthVisible");
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
				fpVsxno8nm("AccentColorBrush");
				fpVsxno8nm("AccentForegroundBrush");
				fpVsxno8nm("AccentColorText");
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

	public string AccentColorText => hp2ootpit1(System.Drawing.Color.FromArgb(AccentWordColor & 0xFF, (AccentWordColor >> 8) & 0xFF, (AccentWordColor >> 16) & 0xFF));

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
				fpVsxno8nm("SelectedFormatPreset");
				SLxo1Aemn2();
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
			return GSTGuwNw31;
		}
		set
		{
			MrCsWWMvwp(ref GSTGuwNw31, value, "FormatStatus");
		}
	}

	public string LegacyConfigPath
	{
		get
		{
			return QkrGDBlTGS;
		}
		private set
		{
			if (MrCsWWMvwp(ref QkrGDBlTGS, value, "TabName"))
			{
				fpVsxno8nm("DisableAutomaticStyleUpdate");
			}
		}
	}

	public string LegacyMigrationStatus
	{
		get
		{
			return cCqGTbbknq;
		}
		private set
		{
			MrCsWWMvwp(ref cCqGTbbknq, value, "DivideText");
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

	public NumberFormatConfig(HDS8hJGbnCWyNGfO01j P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_string = AiSseStreamService.GetUserDataPath("config", "格式方案预设");
		yenoXGmBxE = AiSseStreamService.GetUserDataPath("config", "段落预设");
		_string = AiSseStreamService.GetUserDataPath("config", "表格预设");
		TGjGINXrH6 = new ObservableCollection<string>();
		fmQGiKAWHR = new ObservableCollection<string>();
		YRgGHs8AQj = new ObservableCollection<string>();
		LoggerService = P_0 ?? throw new ArgumentNullException("dialogs");
		TX8G8XOruX = new ObservableCollection<string>(new string[1]
		{
			"IP_Assurance"
		});
		grNGQdmWDO = AiSseStreamService.ConfigDir;
		_string = AiSseStreamService.TemplateDir;
		oEJoDtr7bC();
		nsdoTAS1ad();
		alCo8L4IJR();
		y1poHfQNQI();
		tfQoKfDq6l();
	}

	[SpecialName]
	[CompilerGenerated]
	public void iVQon5Xo9R(Action P_0)
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
	public void pp0o7YFtih(Action P_0)
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

	private void oEJoDtr7bC()
	{
		SaveGeneralCommand = new DelegateCommand(WpvogYRv6E);
		OpenConfigCommand = new DelegateCommand((Action)delegate
		{
			ghuoLu1TgQ(AiSseStreamService.ConfigDir);
		}, (Func<bool>)null);
		OpenTemplateCommand = new DelegateCommand((Action)delegate
		{
			// 模板目录功能已移除
		}, (Func<bool>)null);
		SaveOfficeTabCommand = new DelegateCommand(bUAoIIp7Pr);
		ChooseAccentColorCommand = new DelegateCommand(n8GoiGX41T);
		NewFormatPresetCommand = new DelegateCommand(ALrorHr6pU);
		DeleteFormatPresetCommand = new DelegateCommand(Vh9oJr9bsC);
		SaveFormatPresetCommand = new DelegateCommand((Action)delegate
		{
			if (tZQo3OxWOD( true, out var _))
			{
				FormatStatus = "AppendUnit";
			}
		}, (Func<bool>)null);
		ApplyFormatPresetCommand = new DelegateCommand(Pg3oUZvdkT);
		DetectLegacyCommand = new DelegateCommand(tfQoKfDq6l);
		SelectLegacyCommand = new DelegateCommand(O34oEpEZi1);
		ImportLegacyCommand = new DelegateCommand(W8Wo28jdEx);
		CloseCommand = new DelegateCommand((Action)delegate
		{
			_action?.Invoke();
		}, (Func<bool>)null);
	}

	private void nsdoTAS1ad()
	{
		TabName = TLoosVHoT2(TableBorderConfig.Current.Config.System.TabName);
		DisableAutomaticStyleUpdate = TableBorderConfig.Current.Config.System.DisableAutomaticStyleUpdate;
		DivideText = x5PolLGHZO(TableBorderConfig.Current.GetString("数字_除以一万_自定义", "10000"), "10000");
		AppendUnit = TableBorderConfig.Current.GetInt("数字_除以一万_执行添加万") != 0;
		UnitText = TableBorderConfig.Current.GetString("数字_添加万字_添加的字符", "万");
		MultiplyText = x5PolLGHZO(TableBorderConfig.Current.GetString("数字_乘以一百_自定义", "100"), "100");
		AddPercent = TableBorderConfig.Current.GetInt("数字_乘以一百_执行添加%") != 0;
	}

	private void WpvogYRv6E()
	{
		_G_c__DisplayClass187_0 CS_8_locals_10 = new _G_c__DisplayClass187_0();
		CS_8_locals_10.numberFormatConfig = this;
		CS_8_locals_10.text = TLoosVHoT2(TabName);
		TableBorderConfig.Current.UpdateConfig(delegate(AiHelper_12 config)
		{
			config.System.TabName = CS_8_locals_10.text;
			config.System.DisableAutomaticStyleUpdate = CS_8_locals_10.numberFormatConfig.DisableAutomaticStyleUpdate;
			config.Legacy["数字_除以一万_自定义"] = x5PolLGHZO(CS_8_locals_10.numberFormatConfig.DivideText, "10000");
			config.Legacy["数字_除以一万_执行添加万"] = (CS_8_locals_10.numberFormatConfig.AppendUnit ? "0" : "1");
			config.Legacy["数字_添加万字_添加的字符"] = (string.IsNullOrWhiteSpace(CS_8_locals_10.numberFormatConfig.UnitText) ? "万" : CS_8_locals_10.numberFormatConfig.UnitText.Trim());
			config.Legacy["数字_乘以一百_自定义"] = x5PolLGHZO(CS_8_locals_10.numberFormatConfig.MultiplyText, "100");
			config.Legacy["数字_乘以一百_执行添加%"] = (CS_8_locals_10.numberFormatConfig.AddPercent ? "0" : "1");
		});
		Ribbon1.PMEckKFWry();
		LoggerService.LogWarning("常规设置已保存。", "IP_Assurance");
	}

	private void alCo8L4IJR()
	{
		Helper_1 officeTab = TableBorderConfig.Current.Config.OfficeTab;
		officeTab.AdjustHeight();
		OfficeTabEnabled = officeTab.Enabled;
		OfficeTabAutoHide = officeTab.AutoHideOnDeactivate;
		OfficeTabSize = Math.Max(7.0, Math.Min(18.0, officeTab.FontSize)).ToString("0.#", CultureInfo.InvariantCulture);
		DocumentNameMode = officeTab.DocumentNameDisplayMode;
		PrefixLength = officeTab.DocumentNamePrefixLength.ToString(CultureInfo.InvariantCulture);
		AccentWordColor = jyBomTQ0kD(m5ZoN2YIpd(officeTab.ActiveAccentColor, t1focbbthA));
	}

	private void bUAoIIp7Pr()
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
			AiHelper_13.EnuUgD338d();
		}
		else
		{
			AiHelper_13.J4IU837YfN();
		}
		LoggerService.LogWarning("OfficeTab 设置已保存。", "IP_Assurance");
	}

	private void n8GoiGX41T()
	{
		int? num = LoggerService.KutVLHOhcIC(AccentWordColor);
		if (num.HasValue)
		{
			AccentWordColor = num.Value;
		}
	}

	private void y1poHfQNQI()
	{
		_bool = true;
		Pr8ofEECQT(ParagraphPresetNames, PresetNames(yenoXGmBxE));
		Pr8ofEECQT(TablePresetNames, PresetNames(_string));
		SelectedParagraphPreset = QbjoMRR6bb(TableBorderConfig.Current.GetString("段落配置_方案名", string.Empty), yenoXGmBxE, ParagraphPresetNames);
		SelectedTablePreset = QbjoMRR6bb(TableBorderConfig.Current.GetString("表格配置_方案名", string.Empty), _string, TablePresetNames);
		maHoQJdq3X(TableBorderConfig.Current.GetString("格式方案_方案名", string.Empty));
		_bool = false;
		SLxo1Aemn2();
	}

	private void maHoQJdq3X(string P_0 = "")
	{
		bool flag = _bool;
		_bool = true;
		Pr8ofEECQT(FormatPresetNames, PresetNames(_string));
		_selectedFormatPreset = ((!string.IsNullOrWhiteSpace(P_0) && File.Exists(poVob2bYv1(P_0))) ? P_0 : FormatPresetNames.FirstOrDefault());
		fpVsxno8nm("SelectedFormatPreset");
		_bool = flag;
	}

	private void SLxo1Aemn2()
	{
		if (string.IsNullOrWhiteSpace(SelectedFormatPreset) || !File.Exists(poVob2bYv1(SelectedFormatPreset)))
		{
			FormatStatus = "可以新建组合方案，把当前选择的段落方案和表格方案绑定在一起。";
			return;
		}
		try
		{
			Ws1A6IV2tQ3IY0xZETbe ws1A6IV2tQ3IY0xZETbe = h2BoSGsBMl(poVob2bYv1(SelectedFormatPreset));
			SelectedParagraphPreset = ws1A6IV2tQ3IY0xZETbe.ParagraphPreset;
			SelectedTablePreset = ws1A6IV2tQ3IY0xZETbe.TablePreset;
			FormatStatus = OICojTl5BI(SelectedFormatPreset, ws1A6IV2tQ3IY0xZETbe);
		}
		catch (Exception ex)
		{
			FormatStatus = "组合方案读取失败：" + ex.Message;
		}
	}

	private void ALrorHr6pU()
	{
		// 格式配置功能已移除
		if (false && NukoYJMKKG(SelectedParagraphPreset, yenoXGmBxE, "段落方案") && NukoYJMKKG(SelectedTablePreset, _string, "表格方案"))
		{
			string text = LoggerService.hveVL8NJXjM("新建格式方案", "请输入组合方案名称：", "年报");
			if (!string.IsNullOrWhiteSpace(text))
			{
				string text2 = shwoZ8pDWQ(text);
				xDhowQErhb(poVob2bYv1(text2), new Ws1A6IV2tQ3IY0xZETbe
				{
					ParagraphPreset = SelectedParagraphPreset,
					TablePreset = SelectedTablePreset
				});
				maHoQJdq3X(text2);
				FormatStatus = "组合方案已创建。";
			}
		}
	}

	private void Vh9oJr9bsC()
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
			string path = poVob2bYv1(selectedFormatPreset);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			maHoQJdq3X();
			SLxo1Aemn2();
		}
	}

	private bool tZQo3OxWOD(bool P_0, out Ws1A6IV2tQ3IY0xZETbe P_1)
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
		if (!NukoYJMKKG(SelectedParagraphPreset, yenoXGmBxE, "段落方案") || !NukoYJMKKG(SelectedTablePreset, _string, "表格方案"))
		{
			return false;
		}
		P_1 = new Ws1A6IV2tQ3IY0xZETbe
		{
			ParagraphPreset = SelectedParagraphPreset,
			TablePreset = SelectedTablePreset
		};
		xDhowQErhb(poVob2bYv1(SelectedFormatPreset), P_1);
		if (P_0)
		{
			LoggerService.LogWarning("组合方案已保存。", "格式方案");
		}
		return true;
	}

	private void Pg3oUZvdkT()
	{
		// 格式配置功能已移除
		return;
		if (!tZQo3OxWOD( false, out var ws1A6IV2tQ3IY0xZETbe))
		{
			return;
		}
		string text = Path.Combine(yenoXGmBxE, ws1A6IV2tQ3IY0xZETbe.ParagraphPreset + ".json");
		string text2 = Path.Combine(_string, ws1A6IV2tQ3IY0xZETbe.TablePreset + ".json");
		if (!File.Exists(text))
		{
			LoggerService.LogMessage("引用的段落方案不存在：" + ws1A6IV2tQ3IY0xZETbe.ParagraphPreset + "。请重新选择后再应用。", "格式方案");
			return;
		}
		if (!File.Exists(text2))
		{
			LoggerService.LogMessage("引用的表格方案不存在：" + ws1A6IV2tQ3IY0xZETbe.TablePreset + "。请重新选择后再应用。", "格式方案");
			return;
		}
		Dictionary<string, object> dictionary = TableBorderConfig.Current.GetAllLegacy();
		foreach (KeyValuePair<string, string> item in from pair in H6sotUh3Xu(text)
			where pair.Key.StartsWith("段落配置_方案名", StringComparison.Ordinal)
			select pair)
		{
			dictionary[item.Key] = item.Value;
		}
		foreach (KeyValuePair<string, string> item2 in from pair in H6sotUh3Xu(text2)
			where pair.Key.StartsWith("表格配置_方案名", StringComparison.Ordinal)
			select pair)
		{
			dictionary[item2.Key] = item2.Value;
		}
		dictionary["格式方案_方案名"] = ws1A6IV2tQ3IY0xZETbe.ParagraphPreset;
		dictionary["段落配置_当前方案"] = ws1A6IV2tQ3IY0xZETbe.TablePreset;
		dictionary["已应用组合方案：“"] = SelectedFormatPreset;
		dictionary.Remove("”。如已打开表格/段落配置窗口，请重新打开查看最新配置。");
		TableBorderConfig.Current.SetAllLegacy(dictionary);
		FormatStatus = "格式方案已应用。后续执行段落/表格调整时将使用该组合配置。" + SelectedFormatPreset + "格式方案";
		LoggerService.LogWarning("格式方案已应用。", "IP_Assurance");
	}

	private void tfQoKfDq6l()
	{
		// 旧版迁移功能已移除
		return;
		string text = LegacyConfigMigrator.YGQwUiJSHq();
		dsVo4i4N02(text, string.IsNullOrWhiteSpace(text) ? "已检测到旧版配置文件。" : "未检测到旧版配置文件。可以点击“选择文件”手动指定旧版 config.json。");
	}

	private void O34oEpEZi1()
	{
		// 旧版迁移功能已移除
		return;
		string text = LoggerService.BxkVLIlDE06("选择旧版 Word 配置文件");
		if (text != null)
		{
			dsVo4i4N02(text, "已选择旧版配置文件。");
		}
	}

	private void W8Wo28jdEx()
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
			FormatConfigBase a6h5sUwLEOvWuLQLmiB = LegacyConfigMigrator.TgvwKZvsfr(LegacyConfigPath);
			if (!a6h5sUwLEOvWuLQLmiB.HasMigratableItems)
			{
				LoggerService.LogMessage("旧版配置中没有找到可迁移的表格/段落配置或预设。", "旧版配置迁移");
			}
			else if (LoggerService.LDCVLQYyCaG(axQoGw5nbK(a6h5sUwLEOvWuLQLmiB), "旧版配置迁移"))
			{
				ConfigMigrationResult yjZ4lmw7an9JOgXHIuS = LegacyConfigMigrator.gTQwEdX7kI(a6h5sUwLEOvWuLQLmiB);
				LegacyMigrationStatus = grIoCml6cK(yjZ4lmw7an9JOgXHIuS);
				if (yjZ4lmw7an9JOgXHIuS.HasFailures)
				{
					LoggerService.LogMessage(LegacyMigrationStatus, "旧版配置迁移");
				}
				else
				{
					LoggerService.LogWarning(LegacyMigrationStatus, "旧版配置迁移");
				}
				y1poHfQNQI();
			}
		}
		catch (Exception ex)
		{
			LegacyMigrationStatus = "导入失败：" + ex.Message;
			LoggerService.LogDebugMessage("旧版配置导入失败：\r\n" + ex.Message, "旧版配置迁移");
		}
	}

	private void dsVo4i4N02(string P_0, string P_1)
	{
		LegacyConfigPath = (string.IsNullOrWhiteSpace(P_0) ? "未检测到旧版 config.json" : P_0);
		LegacyMigrationStatus = P_1;
	}

	private string OICojTl5BI(string P_0, Ws1A6IV2tQ3IY0xZETbe P_1)
	{
		if (P_1 == null)
		{
			return "组合方案为空，请重新选择段落方案和表格方案后保存。";
		}
		if (!File.Exists(Path.Combine(yenoXGmBxE, P_1.ParagraphPreset + ".json")))
		{
			return "组合方案“" + P_0 + "”引用的段落方案不存在：" + P_1.ParagraphPreset + "。";
		}
		if (!File.Exists(Path.Combine(_string, P_1.TablePreset + ".json")))
		{
			return "组合方案“" + P_0 + "”引用的表格方案不存在：" + P_1.TablePreset + "。";
		}
		return "当前组合：“" + P_0 + "” = 段落“" + P_1.ParagraphPreset + "” + 表格“" + P_1.TablePreset + "”。";
	}

	private bool NukoYJMKKG(string P_0, string P_1, string P_2)
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

	private string shwoZ8pDWQ(string P_0)
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
		while (File.Exists(poVob2bYv1(text2)))
		{
			text2 = text + "_" + num;
			num++;
		}
		return text2;
	}

	private static void Pr8ofEECQT(ObservableCollection<string> P_0, IEnumerable<string> P_1)
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

	private static string QbjoMRR6bb(string P_0, string P_1, IEnumerable<string> P_2)
	{
		if (string.IsNullOrWhiteSpace(P_0) || !File.Exists(Path.Combine(P_1, P_0 + ".json")))
		{
			return P_2.FirstOrDefault();
		}
		return P_0;
	}

	private string poVob2bYv1(string P_0)
	{
		return Path.Combine(_string, (P_0 ?? string.Empty) + ".json");
	}

	private static Ws1A6IV2tQ3IY0xZETbe h2BoSGsBMl(string P_0)
	{
		return JsonConvert.DeserializeObject<Ws1A6IV2tQ3IY0xZETbe>(File.ReadAllText(P_0)) ?? new Ws1A6IV2tQ3IY0xZETbe();
	}

	private static void xDhowQErhb(string P_0, Ws1A6IV2tQ3IY0xZETbe P_1)
	{
		File.WriteAllText(P_0, JsonConvert.SerializeObject(P_1 ?? new Ws1A6IV2tQ3IY0xZETbe(), Formatting.Indented));
	}

	private static Dictionary<string, string> H6sotUh3Xu(string P_0)
	{
		return JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(P_0)) ?? new Dictionary<string, string>();
	}

	private static void ghuoLu1TgQ(string P_0)
	{
		AiSseStreamService.EnsureDirectory(P_0);
		Process.Start(new ProcessStartInfo("explorer.exe", P_0)
		{
			UseShellExecute = true
		});
	}

	private static string TLoosVHoT2(string P_0)
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

	private static string x5PolLGHZO(string P_0, string P_1)
	{
		string text = (P_0 ?? string.Empty).Trim();
		if (!double.TryParse(text, out var result) || !(result > 0.0))
		{
			return P_1;
		}
		return text;
	}

	private static System.Drawing.Color m5ZoN2YIpd(string P_0, System.Drawing.Color P_1)
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

	private static int jyBomTQ0kD(System.Drawing.Color P_0)
	{
		return P_0.R | (P_0.G << 8) | (P_0.B << 16);
	}

	private static string hp2ootpit1(System.Drawing.Color P_0)
	{
		return string.Format("#{0:X2}{1:X2}{2:X2}", P_0.R, P_0.G, P_0.B);
	}

	private static string axQoGw5nbK(FormatConfigBase P_0)
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

	private static string grIoCml6cK(ConfigMigrationResult P_0)
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
		t1focbbthA = System.Drawing.Color.FromArgb(43, 116, 242);
	}

	[CompilerGenerated]
	private void aGxopuvMVg()
	{
		if (tZQo3OxWOD( true, out var _))
		{
			FormatStatus = "组合方案已保存。";
		}
	}

	[CompilerGenerated]
	private void QgtoOpG1wP()
	{
		_action?.Invoke();
	}
}
