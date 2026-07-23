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
		public AIAssistantConfigWindow LI8V2dgZYHL;

		public int NaWV2zGZ2I1;

		public AiProviderConfig pbkV4R50dS0;

		public _G_c__DisplayClass4_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void iICV2xcGsJ8(Helper_22 cfg)
		{
			cfg.Assistant.WebUrl = string.Empty;
			cfg.Assistant.Providers = gWlGzv3R5r(LI8V2dgZYHL.fisCDWUc56);
			cfg.Assistant.ActiveProviderIndex = NaWV2zGZ2I1;
			cfg.Assistant.Runtime.FVULVTGET5(pbkV4R50dS0.OsCL8QJeMd());
			cfg.Assistant.Summary = cfg.Assistant.Summary ?? new AiHelper_9();
			LI8V2dgZYHL.krdG0kvqar(cfg.Assistant.Summary);
		}
	}

	private List<AiProviderConfig> fisCDWUc56;

	private int Xh2CTxqH1Q;

	private bool tkZCgIqo5P;

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

	private bool UPbC8JmO7w;

	public AIAssistantConfigWindow()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		fisCDWUc56 = new List<AiProviderConfig>();
		Xh2CTxqH1Q = -1;
		InitializeComponent();
		I7cGyHnOsl();
		iTPGXIyvt5();
	}

	private void vkoGnmG7ZQ(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass4_0 CS_8_locals_9 = new _G_c__DisplayClass4_0();
		CS_8_locals_9.LI8V2dgZYHL = this;
		try
		{
			vTyGqN5uS6();
			WHIGPZyFCO();
			CS_8_locals_9.NaWV2zGZ2I1 = RI6GALeVx5(Xh2CTxqH1Q);
			CS_8_locals_9.pbkV4R50dS0 = fisCDWUc56[CS_8_locals_9.NaWV2zGZ2I1];
			FileDownloadHelper.Instance.lpfwdhmiR3(delegate(Helper_22 cfg)
			{
				cfg.Assistant.WebUrl = string.Empty;
				cfg.Assistant.Providers = gWlGzv3R5r(CS_8_locals_9.LI8V2dgZYHL.fisCDWUc56);
				cfg.Assistant.ActiveProviderIndex = CS_8_locals_9.NaWV2zGZ2I1;
				cfg.Assistant.Runtime.FVULVTGET5(CS_8_locals_9.pbkV4R50dS0.OsCL8QJeMd());
				cfg.Assistant.Summary = cfg.Assistant.Summary ?? new AiHelper_9();
				CS_8_locals_9.LI8V2dgZYHL.krdG0kvqar(cfg.Assistant.Summary);
			});
			bool flag = IntranetAiConfigService.Instance.xeF6QqxCkO();
			if (!flag && !sicGvmbu2d(CS_8_locals_9.pbkV4R50dS0))
			{
				LoggerInitializer.u0kcmnykTv("AI 配置已保存，但当前方案缺少 API Key 或模型名称。", "AI 配置");
			}
			else if (flag)
			{
				LoggerInitializer.Ay3cNuEgJo("AI 配置已保存。内网环境中将优先使用集中下发配置。", "AI 配置");
			}
			else
			{
				LoggerInitializer.Ay3cNuEgJo("AI 配置已保存。", "AI 配置");
			}
			Close();
		}
		catch (Exception ex)
		{
			LoggerInitializer.F9Ycoqv2I8("AI 配置保存失败：\r\n" + ex.Message, "AI 配置");
		}
	}

	private void BrJG7X3GCO(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private void kw2G5xe9uv(object P_0, RoutedEventArgs P_1)
	{
		AiSseStreamService.i24sVuaOic(FileDownloadHelper.SharedConfigDir);
		Process.Start(new ProcessStartInfo("explorer.exe", FileDownloadHelper.SharedConfigDir)
		{
			UseShellExecute = true
		});
	}

	private void v8TGcXBvWr(object P_0, RoutedEventArgs P_1)
	{
		AiHelper_3.BWIBRayGaa();
	}

	private async void aVsGe74PNw(object P_0, RoutedEventArgs P_1)
	{
		vTyGqN5uS6();
		await wJfC6L7KBN(btnTestAssistantConnection, "AI 配置已保存，但当前方案缺少 API Key 或模型名称。", () => AiConfigManager.Xq56uj14fX("AI 配置", txtAssistantApiKey.Password, txtAssistantBaseUrl.Text, txtAssistantModel.Text), "AI 配置已保存。内网环境中将优先使用集中下发配置。", "AI 配置");
	}

	private void I7cGyHnOsl()
	{
		Helper_22 ai = FileDownloadHelper.Current.Ai;
		yOUGFVIpfx(ai.Assistant);
		qGyGW877wr(ai.Assistant?.Summary);
	}

	private void iTPGXIyvt5()
	{
		string text = IntranetAiConfigService.Instance.ltA63dMPIj();
		bool flag = !string.IsNullOrWhiteSpace(text);
		borderManagedHint.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		txtManagedHint.Text = (flag ? text : string.Empty);
	}

	private void yOUGFVIpfx(ProviderConfig P_0)
	{
		fisCDWUc56 = gWlGzv3R5r(P_0?.Providers);
		WHIGPZyFCO();
		Xh2CTxqH1Q = RI6GALeVx5(P_0?.ActiveProviderIndex ?? 0);
		l0GGa5opIs();
		PQlGhSBn1g(Xh2CTxqH1Q);
	}

	private void PQlGhSBn1g(int P_0)
	{
		if (P_0 >= 0 && P_0 < fisCDWUc56.Count)
		{
			tkZCgIqo5P = true;
			AiProviderConfig tjgkXoLTQE08rAvKTCC = fisCDWUc56[P_0];
			txtAssistantProfileName.Text = tjgkXoLTQE08rAvKTCC.Name;
			txtAssistantApiKey.Password = tjgkXoLTQE08rAvKTCC.ApiKey ?? string.Empty;
			txtAssistantBaseUrl.Text = tjgkXoLTQE08rAvKTCC.BaseUrl ?? string.Empty;
			txtAssistantModel.Text = tjgkXoLTQE08rAvKTCC.Model ?? string.Empty;
			tkZCgIqo5P = false;
			BhjGdXY5M7();
		}
	}

	private void l0GGa5opIs()
	{
		tkZCgIqo5P = true;
		cboAssistantProfile.Items.Clear();
		foreach (AiProviderConfig item in fisCDWUc56)
		{
			cboAssistantProfile.Items.Add(item.Name);
		}
		if (fisCDWUc56.Count > 0)
		{
			cboAssistantProfile.SelectedIndex = RI6GALeVx5(Xh2CTxqH1Q);
		}
		tkZCgIqo5P = false;
	}

	private void vTyGqN5uS6()
	{
		if (Xh2CTxqH1Q < 0 || Xh2CTxqH1Q >= fisCDWUc56.Count)
		{
			return;
		}
		int selectedIndex = cboAssistantProfile.SelectedIndex;
		AiProviderConfig tjgkXoLTQE08rAvKTCC = fisCDWUc56[Xh2CTxqH1Q];
		tjgkXoLTQE08rAvKTCC.Name = AiProviderConfig.wFmLiEaskI(txtAssistantProfileName.Text, "配置" + (Xh2CTxqH1Q + 1));
		tjgkXoLTQE08rAvKTCC.Provider = "openai";
		tjgkXoLTQE08rAvKTCC.ApiKey = txtAssistantApiKey.Password.Trim();
		tjgkXoLTQE08rAvKTCC.BaseUrl = txtAssistantBaseUrl.Text.Trim();
		tjgkXoLTQE08rAvKTCC.Model = txtAssistantModel.Text.Trim();
		if (Xh2CTxqH1Q >= cboAssistantProfile.Items.Count)
		{
			return;
		}
		tkZCgIqo5P = true;
		try
		{
			cboAssistantProfile.Items.RemoveAt(Xh2CTxqH1Q);
			cboAssistantProfile.Items.Insert(Xh2CTxqH1Q, tjgkXoLTQE08rAvKTCC.Name);
			if (selectedIndex >= 0 && selectedIndex < cboAssistantProfile.Items.Count)
			{
				cboAssistantProfile.SelectedIndex = selectedIndex;
			}
		}
		finally
		{
			tkZCgIqo5P = false;
		}
	}

	private void WHIGPZyFCO()
	{
		if (fisCDWUc56 == null)
		{
			fisCDWUc56 = new List<AiProviderConfig>();
		}
		if (fisCDWUc56.Count != 0)
		{
			return;
		}
		foreach (AiProviderConfig item in AiProviderConfig.dV6LHfPZVP())
		{
			fisCDWUc56.Add(xyrCRRI7mn(item));
		}
	}

	private int RI6GALeVx5(int P_0)
	{
		WHIGPZyFCO();
		if (P_0 >= 0 && P_0 < fisCDWUc56.Count)
		{
			return P_0;
		}
		return 0;
	}

	private static bool sicGvmbu2d(AiProviderConfig P_0)
	{
		if (P_0 != null && !string.IsNullOrWhiteSpace(P_0.ApiKey))
		{
			return !string.IsNullOrWhiteSpace(P_0.Model);
		}
		return false;
	}

	private void qGyGW877wr(AiHelper_9 P_0)
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

	private void krdG0kvqar(AiHelper_9 P_0)
	{
		if (P_0 != null)
		{
			P_0.ContextWindowTokens = F2CGkRZLX6(txtSummaryContextWindowTokens.Text, 200000);
			P_0.TriggerRatio = ksFGxkx7d7(txtSummaryTriggerRatio.Text, 0.7);
			P_0.TargetRatio = ksFGxkx7d7(txtSummaryTargetRatio.Text, 0.45);
			P_0.HardLimitRatio = ksFGxkx7d7(txtSummaryHardLimitRatio.Text, 0.9);
			P_0.RecentMessageCount = F2CGkRZLX6(txtSummaryRecentMessageCount.Text, 12);
			P_0.TimeoutSeconds = F2CGkRZLX6(txtSummaryTimeoutSeconds.Text, 30);
			P_0.qBDLf9An1g();
		}
	}

	private static int F2CGkRZLX6(string P_0, int P_1)
	{
		if (!int.TryParse((P_0 ?? string.Empty).Trim(), out var result) || result <= 0)
		{
			return P_1;
		}
		return result;
	}

	private static double ksFGxkx7d7(string P_0, double P_1)
	{
		if (!double.TryParse((P_0 ?? string.Empty).Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var result) || !(result > 0.0) || !(result < 1.0))
		{
			return P_1;
		}
		return result;
	}

	private void BhjGdXY5M7()
	{
		string text = txtAssistantBaseUrl.Text.Trim().TrimEnd('/');
		lblAssistantEndpointHint.Text = (string.IsNullOrWhiteSpace(text) ? "完整请求地址：" : ("/chat/completions" + text + "完整请求地址：.../chat/completions"));
	}

	private static List<AiProviderConfig> gWlGzv3R5r(List<AiProviderConfig> P_0)
	{
		List<AiProviderConfig> list = new List<AiProviderConfig>();
		if (P_0 == null)
		{
			return list;
		}
		foreach (AiProviderConfig item in P_0)
		{
			list.Add(xyrCRRI7mn(item));
		}
		return list;
	}

	private static AiProviderConfig xyrCRRI7mn(AiProviderConfig P_0)
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

	private void M4gCVhpaRX(object P_0, SelectionChangedEventArgs P_1)
	{
		if (!tkZCgIqo5P)
		{
			int selectedIndex = cboAssistantProfile.SelectedIndex;
			if (selectedIndex >= 0 && selectedIndex < fisCDWUc56.Count)
			{
				vTyGqN5uS6();
				Xh2CTxqH1Q = selectedIndex;
				PQlGhSBn1g(Xh2CTxqH1Q);
			}
		}
	}

	private void O0sCBTHQZU(object P_0, RoutedEventArgs P_1)
	{
		vTyGqN5uS6();
		WHIGPZyFCO();
		fisCDWUc56.Add(new AiProviderConfig
		{
			Name = "新配置" + (fisCDWUc56.Count + 1),
			Provider = "openai"
		});
		Xh2CTxqH1Q = fisCDWUc56.Count - 1;
		l0GGa5opIs();
		PQlGhSBn1g(Xh2CTxqH1Q);
		txtAssistantProfileName.Focus();
		txtAssistantProfileName.SelectAll();
	}

	private void RpuC9JBvcA(object P_0, TextChangedEventArgs P_1)
	{
		if (!tkZCgIqo5P)
		{
			BhjGdXY5M7();
		}
	}

	private async Task wJfC6L7KBN(Button P_0, string P_1, Func<Task> P_2, string P_3, string P_4)
	{
		object originalText = P_0.Content;
		P_0.IsEnabled = false;
		P_0.Content = P_1;
		try
		{
			await P_2().ConfigureAwait(continueOnCapturedContext: true);
			LoggerInitializer.Ay3cNuEgJo(P_3, "AI 配置已保存。");
		}
		catch (Exception ex)
		{
			LoggerInitializer.F9Ycoqv2I8(P_4 + (ex.InnerException?.Message ?? ex.Message), "AI 配置");
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
		if (!UPbC8JmO7w)
		{
			UPbC8JmO7w = true;
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
			cboAssistantProfile.SelectionChanged += M4gCVhpaRX;
			break;
		case 4:
			btnNewAssistantProfile = (Button)target;
			btnNewAssistantProfile.Click += O0sCBTHQZU;
			break;
		case 5:
			txtAssistantProfileName = (TextBox)target;
			break;
		case 6:
			txtAssistantApiKey = (PasswordBox)target;
			break;
		case 7:
			txtAssistantBaseUrl = (TextBox)target;
			txtAssistantBaseUrl.TextChanged += RpuC9JBvcA;
			break;
		case 8:
			txtAssistantModel = (TextBox)target;
			break;
		case 9:
			lblAssistantEndpointHint = (TextBlock)target;
			break;
		case 10:
			btnTestAssistantConnection = (Button)target;
			btnTestAssistantConnection.Click += aVsGe74PNw;
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
			btnOpenFolder.Click += kw2G5xe9uv;
			break;
		case 18:
			btnHelp = (Button)target;
			btnHelp.Click += v8TGcXBvWr;
			break;
		case 19:
			btnSave = (Button)target;
			btnSave.Click += vkoGnmG7ZQ;
			break;
		case 20:
			btnCancel = (Button)target;
			btnCancel.Click += BrJG7X3GCO;
			break;
		default:
			UPbC8JmO7w = true;
			break;
		}
	}

	[CompilerGenerated]
	private Task lFtCuZnbgF()
	{
		return AiConfigManager.Xq56uj14fX("openai", txtAssistantApiKey.Password, txtAssistantBaseUrl.Text, txtAssistantModel.Text);
	}
}
