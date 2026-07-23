using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using FileDownloadHelper;
using AiProviderConfig;
using Helper_22;
using AiSseStreamService3;
using IntranetAiConfigService;
using SseStreamInitializer;
using AiSseStreamService;
using AiHelper_3;
using ProviderConfig;
using AiConfigManager;
using AiHelper_9;
using LoggerInitializer;

namespace CPAHelperForWordRe.UI.Forms;

public class AIAssistantConfigWindow : Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass4_0
	{
		public AIAssistantConfigWindow aIAssistantConfigWindow;

		public int value;

		public AiProviderConfig aiProviderConfig;

		public _G_c__DisplayClass4_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ApplyConfigCallback(Helper_22 cfg)
		{
			cfg.Assistant.WebUrl = string.Empty;
			cfg.Assistant.Providers = CloneProviders(aIAssistantConfigWindow._providers);
			cfg.Assistant.ActiveProviderIndex = value;
			cfg.Assistant.Runtime.FVULVTGET5(aiProviderConfig.OsCL8QJeMd());
			cfg.Assistant.Summary = cfg.Assistant.Summary ?? new AiHelper_9();
			aIAssistantConfigWindow.SaveSummarySettings(cfg.Assistant.Summary);
		}
	}

	private List<AiProviderConfig> _providers;

	private int _int;

	private bool _bool;

	internal Border borderManagedHint;

	internal TextBlock txtManagedHint;

	internal ComboBox cboAssistantProfile;

	internal Button btnNewAssistantProfile;

	internal TextBox txtAssistantProfileName;

	internal PasswordBox txtAssistantApiKey;

	internal TextBox txtAssistantBaseUrl;

	internal TextBox txtAssistantModel;

	internal TextBlock lblAssistantEndpointHint;

	internal Button btnTestAssistantConnection;

	internal TextBox txtSummaryContextWindowTokens;

	internal TextBox txtSummaryTriggerRatio;

	internal TextBox txtSummaryTargetRatio;

	internal TextBox txtSummaryHardLimitRatio;

	internal TextBox txtSummaryRecentMessageCount;

	internal TextBox txtSummaryTimeoutSeconds;

	internal Button btnOpenFolder;

	internal Button btnHelp;

	internal Button btnSave;

	internal Button btnCancel;

	private bool _bool;

	public AIAssistantConfigWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		_providers = new List<AiProviderConfig>();
		_int = -1;
		InitializeComponent();
		LoadConfig();
		UpdateManagedHint();
	}

	private void OnSaveClick(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass4_0 CS_8_locals_9 = new _G_c__DisplayClass4_0();
		CS_8_locals_9.aIAssistantConfigWindow = this;
		try
		{
			SyncCurrentProfileFromUi();
			EnsureDefaultProviders();
			CS_8_locals_9.value = ValidateProviderIndex(_int);
			CS_8_locals_9.aiProviderConfig = _providers[CS_8_locals_9.value];
			FileDownloadHelper.Instance.UpdateConfig(delegate(Helper_22 cfg)
			{
				cfg.Assistant.WebUrl = string.Empty;
				cfg.Assistant.Providers = CloneProviders(CS_8_locals_9.aIAssistantConfigWindow._providers);
				cfg.Assistant.ActiveProviderIndex = CS_8_locals_9.value;
				cfg.Assistant.Runtime.FVULVTGET5(CS_8_locals_9.aiProviderConfig.OsCL8QJeMd());
				cfg.Assistant.Summary = cfg.Assistant.Summary ?? new AiHelper_9();
				CS_8_locals_9.aIAssistantConfigWindow.SaveSummarySettings(cfg.Assistant.Summary);
			});
			bool flag = IntranetAiConfigService.Instance.IsManagedModeActive();
			if (!flag && !HasApiKeyAndModel(CS_8_locals_9.aiProviderConfig))
			{
				LoggerInitializer.ShowWarning("AI 配置已保存，但当前方案缺少 API Key 或模型名称。", "AI 配置");
			}
			else if (flag)
			{
				LoggerInitializer.ShowInfo("AI 配置已保存。内网环境中将优先使用集中下发配置。", "AI 配置");
			}
			else
			{
				LoggerInitializer.ShowInfo("AI 配置已保存。", "AI 配置");
			}
			Close();
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError("AI 配置保存失败：\r\n" + ex.Message, "AI 配置");
		}
	}

	private void OnCancelClick(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void OnOpenFolderClick(object P_0, RoutedEventArgs P_1)
	{
		AiSseStreamService.EnsureDirectory(FileDownloadHelper.SharedConfigDir);
		Process.Start(new ProcessStartInfo("explorer.exe", FileDownloadHelper.SharedConfigDir)
		{
			UseShellExecute = true
		});
	}

	private void OnHelpClick(object P_0, RoutedEventArgs P_1)
	{
		AiHelper_3.BWIBRayGaa();
	}

	private async void OnTestConnectionClick(object P_0, RoutedEventArgs P_1)
	{
		SyncCurrentProfileFromUi();
		await RunWithButtonStateAsync(btnTestAssistantConnection, "AI 配置已保存，但当前方案缺少 API Key 或模型名称。", () => AiConfigManager.Xq56uj14fX("AI 配置", txtAssistantApiKey.Password, txtAssistantBaseUrl.Text, txtAssistantModel.Text), "AI 配置已保存。内网环境中将优先使用集中下发配置。", "AI 配置");
	}

	private void LoadConfig()
	{
		Helper_22 ai = FileDownloadHelper.Current.Ai;
		LoadProviderConfig(ai.Assistant);
		LoadSummarySettings(ai.Assistant?.Summary);
	}

	private void UpdateManagedHint()
	{
		string text = IntranetAiConfigService.Instance.GetEnvironmentDescription();
		bool flag = !string.IsNullOrWhiteSpace(text);
		borderManagedHint.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		txtManagedHint.Text = (flag ? text : string.Empty);
	}

	private void LoadProviderConfig(ProviderConfig P_0)
	{
		_providers = CloneProviders(P_0?.Providers);
		EnsureDefaultProviders();
		_int = ValidateProviderIndex(P_0?.ActiveProviderIndex ?? 0);
		RefreshProfileCombo();
		DisplayProvider(_int);
	}

	private void DisplayProvider(int P_0)
	{
		if (P_0 >= 0 && P_0 < _providers.Count)
		{
			_bool = true;
			AiProviderConfig provider = _providers[P_0];
			txtAssistantProfileName.Text = provider.Name;
			txtAssistantApiKey.Password = provider.ApiKey ?? string.Empty;
			txtAssistantBaseUrl.Text = provider.BaseUrl ?? string.Empty;
			txtAssistantModel.Text = provider.Model ?? string.Empty;
			_bool = false;
			UpdateEndpointHint();
		}
	}

	private void RefreshProfileCombo()
	{
		_bool = true;
		cboAssistantProfile.Items.Clear();
		foreach (AiProviderConfig item in _providers)
		{
			cboAssistantProfile.Items.Add(item.Name);
		}
		if (_providers.Count > 0)
		{
			cboAssistantProfile.SelectedIndex = ValidateProviderIndex(_int);
		}
		_bool = false;
	}

	private void SyncCurrentProfileFromUi()
	{
		if (_int < 0 || _int >= _providers.Count)
		{
			return;
		}
		int selectedIndex = cboAssistantProfile.SelectedIndex;
		AiProviderConfig provider = _providers[_int];
		provider.Name = AiProviderConfig.wFmLiEaskI(txtAssistantProfileName.Text, "配置" + (_int + 1));
		provider.Provider = "openai";
		provider.ApiKey = txtAssistantApiKey.Password.Trim();
		provider.BaseUrl = txtAssistantBaseUrl.Text.Trim();
		provider.Model = txtAssistantModel.Text.Trim();
		if (_int >= cboAssistantProfile.Items.Count)
		{
			return;
		}
		_bool = true;
		try
		{
			cboAssistantProfile.Items.RemoveAt(_int);
			cboAssistantProfile.Items.Insert(_int, provider.Name);
			if (selectedIndex >= 0 && selectedIndex < cboAssistantProfile.Items.Count)
			{
				cboAssistantProfile.SelectedIndex = selectedIndex;
			}
		}
		finally
		{
			_bool = false;
		}
	}

	private void EnsureDefaultProviders()
	{
		if (_providers == null)
		{
			_providers = new List<AiProviderConfig>();
		}
		if (_providers.Count != 0)
		{
			return;
		}
		foreach (AiProviderConfig item in AiProviderConfig.dV6LHfPZVP())
		{
			_providers.Add(CloneProvider(item));
		}
	}

	private int ValidateProviderIndex(int P_0)
	{
		EnsureDefaultProviders();
		if (P_0 >= 0 && P_0 < _providers.Count)
		{
			return P_0;
		}
		return 0;
	}

	private static bool HasApiKeyAndModel(AiProviderConfig P_0)
	{
		if (P_0 != null && !string.IsNullOrWhiteSpace(P_0.ApiKey))
		{
			return !string.IsNullOrWhiteSpace(P_0.Model);
		}
		return false;
	}

	private void LoadSummarySettings(AiHelper_9 P_0)
	{
		P_0 = P_0 ?? new AiHelper_9();
		P_0.qBDLf9An1g();
		txtSummaryContextWindowTokens.Text = P_0.ContextWindowTokens.ToString();
		txtSummaryTriggerRatio.Text = P_0.TriggerRatio.ToString("0.##", CultureInfo.InvariantCulture);
		txtSummaryTargetRatio.Text = P_0.TargetRatio.ToString("0.##", CultureInfo.InvariantCulture);
		txtSummaryHardLimitRatio.Text = P_0.HardLimitRatio.ToString("0.##", CultureInfo.InvariantCulture);
		txtSummaryRecentMessageCount.Text = P_0.RecentMessageCount.ToString();
		txtSummaryTimeoutSeconds.Text = P_0.TimeoutSeconds.ToString();
	}

	private void SaveSummarySettings(AiHelper_9 P_0)
	{
		if (P_0 != null)
		{
			P_0.ContextWindowTokens = ParseIntOrDefault(txtSummaryContextWindowTokens.Text, 200000);
			P_0.TriggerRatio = ParseRatioOrDefault(txtSummaryTriggerRatio.Text, 0.7);
			P_0.TargetRatio = ParseRatioOrDefault(txtSummaryTargetRatio.Text, 0.45);
			P_0.HardLimitRatio = ParseRatioOrDefault(txtSummaryHardLimitRatio.Text, 0.9);
			P_0.RecentMessageCount = ParseIntOrDefault(txtSummaryRecentMessageCount.Text, 12);
			P_0.TimeoutSeconds = ParseIntOrDefault(txtSummaryTimeoutSeconds.Text, 30);
			P_0.qBDLf9An1g();
		}
	}

	private static int ParseIntOrDefault(string P_0, int P_1)
	{
		if (!int.TryParse((P_0 ?? string.Empty).Trim(), out var result) || result <= 0)
		{
			return P_1;
		}
		return result;
	}

	private static double ParseRatioOrDefault(string P_0, double P_1)
	{
		if (!double.TryParse((P_0 ?? string.Empty).Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var result) || !(result > 0.0) || !(result < 1.0))
		{
			return P_1;
		}
		return result;
	}

	private void UpdateEndpointHint()
	{
		string text = txtAssistantBaseUrl.Text.Trim().TrimEnd('/');
		lblAssistantEndpointHint.Text = (string.IsNullOrWhiteSpace(text) ? "完整请求地址：" : ("/chat/completions" + text + "完整请求地址：.../chat/completions"));
	}

	private static List<AiProviderConfig> CloneProviders(List<AiProviderConfig> P_0)
	{
		List<AiProviderConfig> list = new List<AiProviderConfig>();
		if (P_0 == null)
		{
			return list;
		}
		foreach (AiProviderConfig item in P_0)
		{
			list.Add(CloneProvider(item));
		}
		return list;
	}

	private static AiProviderConfig CloneProvider(AiProviderConfig P_0)
	{
		if (P_0 == null)
		{
			return new AiProviderConfig();
		}
		return new AiProviderConfig
		{
			Name = (P_0.Name ?? string.Empty),
			Provider = "openai",
			ApiKey = (P_0.ApiKey ?? string.Empty),
			BaseUrl = (P_0.BaseUrl ?? string.Empty),
			Model = (P_0.Model ?? string.Empty)
		};
	}

	private void OnProfileSelectionChanged(object P_0, SelectionChangedEventArgs P_1)
	{
		if (!_bool)
		{
			int selectedIndex = cboAssistantProfile.SelectedIndex;
			if (selectedIndex >= 0 && selectedIndex < _providers.Count)
			{
				SyncCurrentProfileFromUi();
				_int = selectedIndex;
				DisplayProvider(_int);
			}
		}
	}

	private void OnNewProfileClick(object P_0, RoutedEventArgs P_1)
	{
		SyncCurrentProfileFromUi();
		EnsureDefaultProviders();
		_providers.Add(new AiProviderConfig
		{
			Name = "新配置" + (_providers.Count + 1),
			Provider = "openai"
		});
		_int = _providers.Count - 1;
		RefreshProfileCombo();
		DisplayProvider(_int);
		txtAssistantProfileName.Focus();
		txtAssistantProfileName.SelectAll();
	}

	private void OnBaseUrlTextChanged(object P_0, TextChangedEventArgs P_1)
	{
		if (!_bool)
		{
			UpdateEndpointHint();
		}
	}

	private async Task RunWithButtonStateAsync(Button P_0, string P_1, Func<Task> P_2, string P_3, string P_4)
	{
		object originalText = P_0.Content;
		P_0.IsEnabled = false;
		P_0.Content = P_1;
		try
		{
			await P_2().ConfigureAwait(continueOnCapturedContext: true);
			LoggerInitializer.ShowInfo(P_3, "AI 配置已保存。");
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError(P_4 + (ex.InnerException?.Message ?? ex.Message), "AI 配置");
		}
		finally
		{
			P_0.IsEnabled = true;
			P_0.Content = originalText;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/aiassistantconfigwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			borderManagedHint = (Border)target;
			break;
		case 2:
			txtManagedHint = (TextBlock)target;
			break;
		case 3:
			cboAssistantProfile = (ComboBox)target;
			cboAssistantProfile.SelectionChanged += OnProfileSelectionChanged;
			break;
		case 4:
			btnNewAssistantProfile = (Button)target;
			btnNewAssistantProfile.Click += OnNewProfileClick;
			break;
		case 5:
			txtAssistantProfileName = (TextBox)target;
			break;
		case 6:
			txtAssistantApiKey = (PasswordBox)target;
			break;
		case 7:
			txtAssistantBaseUrl = (TextBox)target;
			txtAssistantBaseUrl.TextChanged += OnBaseUrlTextChanged;
			break;
		case 8:
			txtAssistantModel = (TextBox)target;
			break;
		case 9:
			lblAssistantEndpointHint = (TextBlock)target;
			break;
		case 10:
			btnTestAssistantConnection = (Button)target;
			btnTestAssistantConnection.Click += OnTestConnectionClick;
			break;
		case 11:
			txtSummaryContextWindowTokens = (TextBox)target;
			break;
		case 12:
			txtSummaryTriggerRatio = (TextBox)target;
			break;
		case 13:
			txtSummaryTargetRatio = (TextBox)target;
			break;
		case 14:
			txtSummaryHardLimitRatio = (TextBox)target;
			break;
		case 15:
			txtSummaryRecentMessageCount = (TextBox)target;
			break;
		case 16:
			txtSummaryTimeoutSeconds = (TextBox)target;
			break;
		case 17:
			btnOpenFolder = (Button)target;
			btnOpenFolder.Click += OnOpenFolderClick;
			break;
		case 18:
			btnHelp = (Button)target;
			btnHelp.Click += OnHelpClick;
			break;
		case 19:
			btnSave = (Button)target;
			btnSave.Click += OnSaveClick;
			break;
		case 20:
			btnCancel = (Button)target;
			btnCancel.Click += OnCancelClick;
			break;
		default:
			_bool = true;
			break;
		}
	}

	[CompilerGenerated]
	private Task TestConnectionAsync()
	{
		return AiConfigManager.Xq56uj14fX("openai", txtAssistantApiKey.Password, txtAssistantBaseUrl.Text, txtAssistantModel.Text);
	}
}
