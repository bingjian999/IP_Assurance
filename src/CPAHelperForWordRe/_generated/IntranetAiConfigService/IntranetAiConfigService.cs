using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using CPAHelper.Agent.Abstractions;
using CPAHelperForWordRe.UI.Forms.General;
using AiConfigBootstrap;
using Helper_17;
using FileDownloadHelper;
using WordTableToolService5;
using Helper_22;
using AiSseStreamService3;
using Helper_23;
using SseStreamInitializer;
using IntranetAuthState;
using AiHelper_8;
using WordTableToolService;

namespace IntranetAiConfigService;

internal sealed class IntranetAiConfigService
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass18_0
	{
		public string text;

		public string requiredVersion;

		public Action showUpdatePromptAction;

		public _G_c__DisplayClass18_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ShowVersionMismatchMessage()
		{
			MessageBox.Show("当前内网 AI 版本低于要求版本，暂时无法继续使用内网 AI。\\n\\n当前 AI 版本：" + text + "\\n要求 AI 版本：" + requiredVersion + "\\n\\n请前往梭梭集市更新后再试。", "需要更新插件", MessageBoxButton.OK, MessageBoxImage.Exclamation);
		}

		internal void InvokeAction(object _)
		{
			showUpdatePromptAction();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_0
	{
		public string username;

		public string text;

		public bool flag;

		public _G_c__DisplayClass23_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void SaveCredentialsToConfig(Helper_22 cfg)
		{
			cfg.Assistant.Intranet.RememberedUsername = username;
			cfg.Assistant.Intranet.RememberedPassword = text;
			cfg.Assistant.Intranet.AutoLoginEnabled = flag;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass26_0
	{
		public IntranetAiConfigService serviceInstance;

		public string text;

		public _G_c__DisplayClass26_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool CallEnsureLogin()
		{
			return serviceInstance.EnsureLoginWithDialog(text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass27_0
	{
		public bool flag;

		public Func<bool> retryFunction;

		public Exception exception;

		public _G_c__DisplayClass27_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ExecuteAndCaptureException(object _)
		{
			try
			{
				flag = retryFunction();
			}
			catch (Exception caughtException)
			{
				exception = caughtException;
			}
		}
	}

	private static readonly Lazy<IntranetAiConfigService> _lazyInstance;

	private static readonly TimeSpan probeInterval;

	private static readonly JavaScriptSerializer jsonSerializer;

	private static readonly HttpClient httpClient;

	private readonly object _object;

	private IntranetAuthState _intranetAuthState;

	private string _string;

	public static IntranetAiConfigService Instance => _lazyInstance.Value;

	static IntranetAiConfigService()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		SseStreamInitializer.InitializeRuntime();
		_lazyInstance = new Lazy<IntranetAiConfigService>(() => new IntranetAiConfigService());
		probeInterval = TimeSpan.FromMinutes(2.0);
		jsonSerializer = new JavaScriptSerializer
		{
			MaxJsonLength = int.MaxValue
		};
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
		httpClient = new HttpClient((HttpMessageHandler)new HttpClientHandler
		{
			AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate)
		});
	}

	public bool EnsureAuthenticated(string P_0 = null)
	{
		try
		{
			IntranetAuthState authState = ProbeIntranetEnvironment();
			if (!authState.IsIntranetEnvironment)
			{
				return true;
			}
			if (!CheckVersionRequirement(authState))
			{
				return false;
			}
			if (authState.IsAuthenticated && !string.IsNullOrWhiteSpace(authState.AccessToken))
			{
				return true;
			}
			return EnsureLoginWithDialog(P_0);
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AI] Intranet environment probe failed, falling back to local config: " + ex.Message);
			lock (_object)
			{
				_intranetAuthState.IsIntranetEnvironment = false;
				_intranetAuthState.IsManagedModeActive = false;
				_intranetAuthState.LastErrorMessage = ex.Message;
			}
			return true;
		}
	}

	public IntranetAuthState GetConfig()
	{
		lock (_object)
		{
			return _intranetAuthState.Clone();
		}
	}

	public AgentConfig GetAgentConfig(AiHelper_8 P_0)
	{
		IntranetAuthState authState = GetConfig();
		if (authState.IsIntranetEnvironment && authState.IsAuthenticated && !string.IsNullOrWhiteSpace(authState.AccessToken) && !string.IsNullOrWhiteSpace(authState.ChatModel) && !string.IsNullOrWhiteSpace(authState.ChatBaseUrl))
		{
			return new AgentConfig
			{
				Provider = "openai",
				ApiKey = authState.AccessToken,
				BaseUrl = authState.ChatBaseUrl,
				Model = authState.ChatModel
			};
		}
		return new AgentConfig
		{
			Provider = P_0?.Provider,
			ApiKey = P_0?.ApiKey,
			BaseUrl = P_0?.BaseUrl,
			Model = P_0?.Model
		};
	}

	public bool IsManagedModeActive()
	{
		return GetConfig().IsManagedModeActive;
	}

	private bool CheckVersionRequirement(IntranetAuthState P_0)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_0.ManagedVersion))
		{
			return true;
		}
		string text = "1.1.3";
		string text2 = P_0.ManagedVersion.Trim();
		if (!IsVersionNewer(text, text2))
		{
			return true;
		}
		lock (_object)
		{
			_intranetAuthState.LastErrorMessage = "当前内网 AI 版本 " + text + " 低于要求版本 " + text2 + "。";
		}
		ShowVersionUpdatePrompt(text, text2);
		return false;
	}

	private void ShowVersionUpdatePrompt(string P_0, string P_1)
	{
		_G_c__DisplayClass18_0 CS_8_locals_9 = new _G_c__DisplayClass18_0();
		CS_8_locals_9.text = P_0;
		CS_8_locals_9.requiredVersion = P_1;
		string text = CS_8_locals_9.text + "->" + CS_8_locals_9.requiredVersion;
		lock (_object)
		{
			if (string.Equals(_string, text, StringComparison.Ordinal))
			{
				return;
			}
			_string = text;
		}
		CS_8_locals_9.showUpdatePromptAction = delegate
		{
			MessageBox.Show("[AI] Intranet environment probe failed, falling back to local config: " + CS_8_locals_9.text + "openai" + CS_8_locals_9.requiredVersion + "1.1.3", "当前内网 AI 版本 ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
		};
		SynchronizationContext syncContext = WordTableToolService.SyncContext;
		if (syncContext != null && SynchronizationContext.Current != syncContext)
		{
			syncContext.Send(delegate
			{
				CS_8_locals_9.showUpdatePromptAction();
			}, null);
		}
		else
		{
			CS_8_locals_9.showUpdatePromptAction();
		}
	}

	private static bool IsVersionNewer(string P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		if (!Version.TryParse(P_0, out var result))
		{
			return true;
		}
		if (!Version.TryParse(P_1, out var result2))
		{
			return false;
		}
		return result2 > result;
	}

	public string GetEnvironmentDescription()
	{
		IntranetAuthState authState = ProbeIntranetEnvironment();
		if (!authState.IsIntranetEnvironment)
		{
			return string.Empty;
		}
		if (authState.IsManagedModeActive)
		{
			return "在内网环境中，Agent 配置已集中下发；本地配置仅作为外网回退。";
		}
		return "当前已识别为内网环境。登录成功后，Agent 将自动使用集中下发配置。";
	}

	public void ClearAuthentication(string P_0)
	{
		lock (_object)
		{
			_intranetAuthState.AccessToken = string.Empty;
			_intranetAuthState.IsAuthenticated = false;
			_intranetAuthState.IsManagedModeActive = false;
			_intranetAuthState.LastErrorMessage = P_0 ?? string.Empty;
		}
	}

	public bool ReAuthenticate(string P_0)
	{
		ClearAuthentication(P_0);
		return EnsureLoginWithDialog(P_0 ?? "当前登录状态已失效，请重新登录后继续使用 AI 助手。");
	}

	public async Task<Helper_17> LoginAsync(string P_0, string P_1, bool P_2 = false)
	{
		_G_c__DisplayClass23_0 CS_8_locals_14 = new _G_c__DisplayClass23_0();
		CS_8_locals_14.flag = P_2;
		CS_8_locals_14.username = (P_0 ?? string.Empty).Trim();
		CS_8_locals_14.text = P_1 ?? string.Empty;
		if (string.IsNullOrWhiteSpace(CS_8_locals_14.username))
		{
			return Helper_17.CreateFailureResult(" 低于要求版本 ", false);
		}
		if (string.IsNullOrWhiteSpace(CS_8_locals_14.text))
		{
			return Helper_17.CreateFailureResult("。", false);
		}
		ProbeIntranetEnvironment();
		string text = jsonSerializer.Serialize(new
		{
			username = "->" + CS_8_locals_14.username,
			password = CS_8_locals_14.text
		});
		HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "在内网环境中，Agent 配置已集中下发；本地配置仅作为外网回退。");
		try
		{
			request.Content = (HttpContent)new StringContent(text, Encoding.UTF8, "当前已识别为内网环境。登录成功后，Agent 将自动使用集中下发配置。");
			HttpResponseMessage response = null;
			string input = string.Empty;
			try
			{
				response = await SendHttpRequestAsync(request, TimeSpan.FromSeconds(10.0)).ConfigureAwait(continueOnCapturedContext: false);
				input = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (TaskCanceledException)
			{
				return Helper_17.CreateFailureResult("当前登录状态已失效，请重新登录后继续使用 AI 助手。", false);
			}
			catch (Exception ex2)
			{
				return Helper_17.CreateFailureResult("http://open.tzcpa.com/com.tzcpa.copilot/version" + ex2.Message, false);
			}
			finally
			{
				HttpResponseMessage obj = response;
				if (obj != null)
				{
					obj.Dispose();
				}
			}
			Dictionary<string, object> dictionary = jsonSerializer.DeserializeObject(input) as Dictionary<string, object>;
			if (GetIntValue(dictionary, "dataV2", (response != null && response.IsSuccessStatusCode) ? 200 : 500) != 200 && !GetBoolValue(dictionary, "data", false))
			{
				return Helper_17.CreateFailureResult(GetStringValue(dictionary, "dataV2") ?? GetStringValue(dictionary, "chat_model") ?? "chat_base_url", false);
			}
			string text2 = GetFirstNonEmptyStringValue(GetNestedDictionary(dictionary, "version"), "当前为内网环境，请先登录后再使用 AI 助手。", "accessToken", "token", "api_key", "apiKey");
			if (string.IsNullOrWhiteSpace(text2))
			{
				text2 = GetFirstNonEmptyStringValue(dictionary, "access_token", "accessToken", "token", "api_key", "apiKey");
			}
			if (string.IsNullOrWhiteSpace(text2))
			{
				return Helper_17.CreateFailureResult("登录成功但未返回 access_token。", false);
			}
			FileDownloadHelper.Instance.UpdateConfig(delegate(Helper_22 cfg)
			{
				cfg.Assistant.Intranet.RememberedUsername = CS_8_locals_14.username;
				cfg.Assistant.Intranet.RememberedPassword = CS_8_locals_14.text;
				cfg.Assistant.Intranet.AutoLoginEnabled = CS_8_locals_14.flag;
			});
			lock (_object)
			{
				_intranetAuthState.AccessToken = text2;
				_intranetAuthState.UserName = CS_8_locals_14.username;
				_intranetAuthState.IsAuthenticated = true;
				_intranetAuthState.IsManagedModeActive = _intranetAuthState.IsIntranetEnvironment && _intranetAuthState.HasManagedMeta;
				_intranetAuthState.LastLoginUtc = DateTime.UtcNow;
				_intranetAuthState.LastErrorMessage = string.Empty;
				_intranetAuthState.RememberedUsername = CS_8_locals_14.username;
				_intranetAuthState.RememberedPassword = CS_8_locals_14.text;
				_intranetAuthState.AutoLoginEnabled = CS_8_locals_14.flag;
			}
			return Helper_17.CreateSuccessResult(text2);
		}
		finally
		{
			((IDisposable)request)?.Dispose();
		}
	}

	public void ResetAuthState()
	{
		lock (_object)
		{
			_intranetAuthState = new IntranetAuthState();
		}
	}

	private IntranetAuthState ProbeIntranetEnvironment()
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		IntranetAuthState authState = GetConfig();
		if (authState.LastProbeUtc != DateTime.MinValue && DateTime.UtcNow - authState.LastProbeUtc < probeInterval)
		{
			return authState;
		}
		Helper_23 intranet = FileDownloadHelper.Current.Ai.Assistant.Intranet;
		IntranetAuthState newAuthState = new IntranetAuthState
		{
			RememberedUsername = (intranet?.RememberedUsername ?? string.Empty),
			RememberedPassword = (intranet?.RememberedPassword ?? string.Empty),
			AutoLoginEnabled = (intranet?.AutoLoginEnabled ?? false),
			LastProbeUtc = DateTime.UtcNow
		};
		try
		{
			HttpRequestMessage val = new HttpRequestMessage(HttpMethod.Get, "http://open.tzcpa.com/com.tzcpa.copilot/version");
			try
			{
				HttpResponseMessage result = SendHttpRequestAsync(val, TimeSpan.FromSeconds(1.0)).GetAwaiter().GetResult();
				try
				{
					if (result.IsSuccessStatusCode)
					{
						string result2 = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
						Dictionary<string, object> dictionary = jsonSerializer.DeserializeObject(result2) as Dictionary<string, object>;
						Dictionary<string, object> dictionary2 = GetNestedDictionary(dictionary, "dataV2") ?? GetNestedDictionary(GetNestedDictionary(dictionary, "data"), "dataV2");
						string text = GetStringValue(dictionary2, "chat_model");
						string text2 = GetStringValue(dictionary2, "chat_base_url");
						if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
						{
							IntranetAuthState existingAuthState = GetConfig();
							newAuthState.IsIntranetEnvironment = true;
							newAuthState.ChatModel = text;
							newAuthState.ChatBaseUrl = text2;
							newAuthState.ManagedVersion = GetStringValue(dictionary2, "version");
							newAuthState.AccessToken = existingAuthState.AccessToken;
							newAuthState.IsAuthenticated = existingAuthState.IsAuthenticated && !string.IsNullOrWhiteSpace(existingAuthState.AccessToken);
							newAuthState.UserName = (string.IsNullOrWhiteSpace(existingAuthState.UserName) ? newAuthState.RememberedUsername : existingAuthState.UserName);
							newAuthState.LastLoginUtc = existingAuthState.LastLoginUtc;
							newAuthState.IsManagedModeActive = newAuthState.IsAuthenticated && newAuthState.HasManagedMeta;
						}
					}
				}
				finally
				{
					((IDisposable)result)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch
		{
		}
		lock (_object)
		{
			_intranetAuthState = newAuthState;
			return _intranetAuthState.Clone();
		}
	}

	private bool EnsureLoginWithDialog(string P_0)
	{
		_G_c__DisplayClass26_0 CS_8_locals_6 = new _G_c__DisplayClass26_0();
		CS_8_locals_6.serviceInstance = this;
		CS_8_locals_6.text = P_0;
		SynchronizationContext syncContext = WordTableToolService.SyncContext;
		if (syncContext != null && SynchronizationContext.Current != syncContext)
		{
			return RunOnUiThread(syncContext, () => CS_8_locals_6.serviceInstance.EnsureLoginWithDialog(CS_8_locals_6.text));
		}
		IntranetAuthState authState = ProbeIntranetEnvironment();
		if (!authState.IsIntranetEnvironment)
		{
			return true;
		}
		string initialStatus = string.Empty;
		if (authState.AutoLoginEnabled && !string.IsNullOrWhiteSpace(authState.RememberedUsername) && !string.IsNullOrWhiteSpace(authState.RememberedPassword) && (!authState.IsAuthenticated || string.IsNullOrWhiteSpace(authState.AccessToken)))
		{
			Helper_17 result = LoginAsync(authState.RememberedUsername, authState.RememberedPassword, true).GetAwaiter().GetResult();
			if (result.Succeeded)
			{
				return true;
			}
			initialStatus = result.Message;
			authState = GetConfig();
		}
		return WordTableToolService5.ShowWpfDialog(new IntranetLoginWindow(authState.RememberedUsername, authState.RememberedPassword, authState.AutoLoginEnabled, string.IsNullOrWhiteSpace(CS_8_locals_6.text) ? "当前为内网环境，请先登录后再使用 AI 助手。" : CS_8_locals_6.text, initialStatus)) == true;
	}

	private static bool RunOnUiThread(SynchronizationContext P_0, Func<bool> P_1)
	{
		_G_c__DisplayClass27_0 CS_8_locals_9 = new _G_c__DisplayClass27_0();
		CS_8_locals_9.retryFunction = P_1;
		CS_8_locals_9.flag = false;
		CS_8_locals_9.exception = null;
		P_0.Send(delegate
		{
			try
			{
				CS_8_locals_9.flag = CS_8_locals_9.retryFunction();
			}
			catch (Exception caughtException)
			{
				CS_8_locals_9.exception = caughtException;
			}
		}, null);
		if (CS_8_locals_9.exception != null)
		{
			throw CS_8_locals_9.exception;
		}
		return CS_8_locals_9.flag;
	}

	private static async Task<HttpResponseMessage> SendHttpRequestAsync(HttpRequestMessage P_0, TimeSpan P_1)
	{
		using CancellationTokenSource cts = new CancellationTokenSource(P_1);
		return await ((HttpMessageInvoker)httpClient).SendAsync(P_0, cts.Token).ConfigureAwait(continueOnCapturedContext: false);
	}

	private static Dictionary<string, object> GetNestedDictionary(Dictionary<string, object> P_0, string P_1)
	{
		if (P_0 == null || !P_0.ContainsKey(P_1))
		{
			return null;
		}
		return P_0[P_1] as Dictionary<string, object>;
	}

	private static string GetStringValue(Dictionary<string, object> P_0, string P_1)
	{
		if (P_0 == null || !P_0.ContainsKey(P_1) || P_0[P_1] == null)
		{
			return string.Empty;
		}
		return P_0[P_1].ToString();
	}

	private static int GetIntValue(Dictionary<string, object> P_0, string P_1, int P_2)
	{
		try
		{
			return (P_0 != null && P_0.ContainsKey(P_1)) ? Convert.ToInt32(P_0[P_1]) : P_2;
		}
		catch
		{
			return P_2;
		}
	}

	private static bool GetBoolValue(Dictionary<string, object> P_0, string P_1, bool P_2)
	{
		try
		{
			return (P_0 != null && P_0.ContainsKey(P_1)) ? Convert.ToBoolean(P_0[P_1]) : P_2;
		}
		catch
		{
			return P_2;
		}
	}

	private static string GetFirstNonEmptyStringValue(Dictionary<string, object> P_0, params string[] keys)
	{
		foreach (string text in keys)
		{
			string text2 = GetStringValue(P_0, text);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				return text2;
			}
		}
		return string.Empty;
	}

	public IntranetAiConfigService()
	{
		SseStreamInitializer.InitializeRuntime();
		_object = new object();
		_intranetAuthState = new IntranetAuthState();
		_string = string.Empty;
	}
}
