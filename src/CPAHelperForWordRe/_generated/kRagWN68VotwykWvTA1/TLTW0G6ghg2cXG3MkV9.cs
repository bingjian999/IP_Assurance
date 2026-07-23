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
using dL7TFPsQbAGqPywtHUK;
using EF4JHh6WXLdDqp0W9j7;
using fGo32Mwk81lacGmgK2T;
using ghWYvT5gdl6wakj5jtn;
using hgGWZZtyfkd02lD1RkA;
using hJKpQrVSwRwMyI2RyDQN;
using k73DZ2LKfdneKP0TqSV;
using ndRERvVtEjasqN2cQqiN;
using nVyjrx6CvCYAuWqOnp0;
using oBj8i4tzkFO0U03EgiU;
using sNVQvmsNbF4pw13wHyu;

namespace kRagWN68VotwykWvTA1;

internal sealed class TLTW0G6ghg2cXG3MkV9
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass18_0
	{
		public string YIFqZ4eEET;

		public string OhnqftjvMe;

		public Action UNgqMgJkv1;

		public _G_c__DisplayClass18_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void h7yqjt6cRs()
		{
			MessageBox.Show("当前内网 AI 版本低于要求版本，暂时无法继续使用内网 AI。\\n\\n当前 AI 版本：" + YIFqZ4eEET + "\\n要求 AI 版本：" + OhnqftjvMe + "\\n\\n请前往梭梭集市更新后再试。", "需要更新插件", MessageBoxButton.OK, MessageBoxImage.Exclamation);
		}

		internal void nT6qYHvI8e(object _)
		{
			UNgqMgJkv1();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_0
	{
		public string OIPqSKrpgR;

		public string hGNqwuT9Bx;

		public bool W8kqt9Yl8O;

		public _G_c__DisplayClass23_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void xffqbtCR9m(k8SSB2tefS63E9gSxuJ cfg)
		{
			cfg.Assistant.Intranet.RememberedUsername = OIPqSKrpgR;
			cfg.Assistant.Intranet.RememberedPassword = hGNqwuT9Bx;
			cfg.Assistant.Intranet.AutoLoginEnabled = W8kqt9Yl8O;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass26_0
	{
		public TLTW0G6ghg2cXG3MkV9 MqsqsqwoRw;

		public string m8gqlvH1Kq;

		public _G_c__DisplayClass26_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal bool irPqLvGlX8()
		{
			return MqsqsqwoRw.ARi6j7UZph(m8gqlvH1Kq);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass27_0
	{
		public bool bHcqmUm0Wl;

		public Func<bool> J0Oqokk6Fc;

		public Exception BdxqG9M9Mt;

		public _G_c__DisplayClass27_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void ycuqNhKHAH(object _)
		{
			try
			{
				bHcqmUm0Wl = J0Oqokk6Fc();
			}
			catch (Exception bdxqG9M9Mt)
			{
				BdxqG9M9Mt = bdxqG9M9Mt;
			}
		}
	}

	private static readonly Lazy<TLTW0G6ghg2cXG3MkV9> Qx86tBAOby;

	private static readonly TimeSpan Qg26LQWnKJ;

	private static readonly JavaScriptSerializer nvl6spHxmW;

	private static readonly HttpClient j486lb3YOS;

	private readonly object Evp6NMlqNd;

	private RMlEPI6GFJYIok22dBB fNb6mwnhsa;

	private string SXd6o3GKNH;

	public static TLTW0G6ghg2cXG3MkV9 Instance => Qx86tBAOby.Value;

	static TLTW0G6ghg2cXG3MkV9()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		Qx86tBAOby = new Lazy<TLTW0G6ghg2cXG3MkV9>(() => new TLTW0G6ghg2cXG3MkV9());
		Qg26LQWnKJ = TimeSpan.FromMinutes(2.0);
		nvl6spHxmW = new JavaScriptSerializer
		{
			MaxJsonLength = int.MaxValue
		};
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
		j486lb3YOS = new HttpClient((HttpMessageHandler)new HttpClientHandler
		{
			AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate)
		});
	}

	public bool gDh6IIK89w(string P_0 = null)
	{
		try
		{
			RMlEPI6GFJYIok22dBB rMlEPI6GFJYIok22dBB = nnc64FEB7B();
			if (!rMlEPI6GFJYIok22dBB.IsIntranetEnvironment)
			{
				return true;
			}
			if (!Aod618kkq1(rMlEPI6GFJYIok22dBB))
			{
				return false;
			}
			if (rMlEPI6GFJYIok22dBB.IsAuthenticated && !string.IsNullOrWhiteSpace(rMlEPI6GFJYIok22dBB.AccessToken))
			{
				return true;
			}
			return ARi6j7UZph(P_0);
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[AI] Intranet environment probe failed, falling back to local config: " + ex.Message);
			lock (Evp6NMlqNd)
			{
				fNb6mwnhsa.IsIntranetEnvironment = false;
				fNb6mwnhsa.IsManagedModeActive = false;
				fNb6mwnhsa.LastErrorMessage = ex.Message;
			}
			return true;
		}
	}

	public RMlEPI6GFJYIok22dBB Nju6iKu8Ci()
	{
		lock (Evp6NMlqNd)
		{
			return fNb6mwnhsa.TZk6pi7Ssm();
		}
	}

	public AgentConfig SyM6HN9NPf(cn1I4Itdi2pbX0gWYAr P_0)
	{
		RMlEPI6GFJYIok22dBB rMlEPI6GFJYIok22dBB = Nju6iKu8Ci();
		if (rMlEPI6GFJYIok22dBB.IsIntranetEnvironment && rMlEPI6GFJYIok22dBB.IsAuthenticated && !string.IsNullOrWhiteSpace(rMlEPI6GFJYIok22dBB.AccessToken) && !string.IsNullOrWhiteSpace(rMlEPI6GFJYIok22dBB.ChatModel) && !string.IsNullOrWhiteSpace(rMlEPI6GFJYIok22dBB.ChatBaseUrl))
		{
			return new AgentConfig
			{
				Provider = "openai",
				ApiKey = rMlEPI6GFJYIok22dBB.AccessToken,
				BaseUrl = rMlEPI6GFJYIok22dBB.ChatBaseUrl,
				Model = rMlEPI6GFJYIok22dBB.ChatModel
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

	public bool xeF6QqxCkO()
	{
		return Nju6iKu8Ci().IsManagedModeActive;
	}

	private bool Aod618kkq1(RMlEPI6GFJYIok22dBB P_0)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_0.ManagedVersion))
		{
			return true;
		}
		string text = "1.1.3";
		string text2 = P_0.ManagedVersion.Trim();
		if (!Ecj6J2070f(text, text2))
		{
			return true;
		}
		lock (Evp6NMlqNd)
		{
			fNb6mwnhsa.LastErrorMessage = "当前内网 AI 版本 " + text + " 低于要求版本 " + text2 + "。";
		}
		ik76rSKYTI(text, text2);
		return false;
	}

	private void ik76rSKYTI(string P_0, string P_1)
	{
		_G_c__DisplayClass18_0 CS_8_locals_9 = new _G_c__DisplayClass18_0();
		CS_8_locals_9.YIFqZ4eEET = P_0;
		CS_8_locals_9.OhnqftjvMe = P_1;
		string text = CS_8_locals_9.YIFqZ4eEET + "->" + CS_8_locals_9.OhnqftjvMe;
		lock (Evp6NMlqNd)
		{
			if (string.Equals(SXd6o3GKNH, text, StringComparison.Ordinal))
			{
				return;
			}
			SXd6o3GKNH = text;
		}
		CS_8_locals_9.UNgqMgJkv1 = delegate
		{
			MessageBox.Show("[AI] Intranet environment probe failed, falling back to local config: " + CS_8_locals_9.YIFqZ4eEET + "openai" + CS_8_locals_9.OhnqftjvMe + "1.1.3", "当前内网 AI 版本 ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
		};
		SynchronizationContext syncContext = eSfxffslhXbaGAjFNv1.SyncContext;
		if (syncContext != null && SynchronizationContext.Current != syncContext)
		{
			syncContext.Send(delegate
			{
				CS_8_locals_9.UNgqMgJkv1();
			}, null);
		}
		else
		{
			CS_8_locals_9.UNgqMgJkv1();
		}
	}

	private static bool Ecj6J2070f(string P_0, string P_1)
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

	public string ltA63dMPIj()
	{
		RMlEPI6GFJYIok22dBB rMlEPI6GFJYIok22dBB = nnc64FEB7B();
		if (!rMlEPI6GFJYIok22dBB.IsIntranetEnvironment)
		{
			return string.Empty;
		}
		if (rMlEPI6GFJYIok22dBB.IsManagedModeActive)
		{
			return "在内网环境中，Agent 配置已集中下发；本地配置仅作为外网回退。";
		}
		return "当前已识别为内网环境。登录成功后，Agent 将自动使用集中下发配置。";
	}

	public void GPA6UvJ0oX(string P_0)
	{
		lock (Evp6NMlqNd)
		{
			fNb6mwnhsa.AccessToken = string.Empty;
			fNb6mwnhsa.IsAuthenticated = false;
			fNb6mwnhsa.IsManagedModeActive = false;
			fNb6mwnhsa.LastErrorMessage = P_0 ?? string.Empty;
		}
	}

	public bool CLv6Kfj0Mw(string P_0)
	{
		GPA6UvJ0oX(P_0);
		return ARi6j7UZph(P_0 ?? "当前登录状态已失效，请重新登录后继续使用 AI 助手。");
	}

	public async Task<UJ41Qj6vhvynNA1tocZ> JrZ6E71S29(string P_0, string P_1, bool P_2 = false)
	{
		_G_c__DisplayClass23_0 CS_8_locals_14 = new _G_c__DisplayClass23_0();
		CS_8_locals_14.W8kqt9Yl8O = P_2;
		CS_8_locals_14.OIPqSKrpgR = (P_0 ?? string.Empty).Trim();
		CS_8_locals_14.hGNqwuT9Bx = P_1 ?? string.Empty;
		if (string.IsNullOrWhiteSpace(CS_8_locals_14.OIPqSKrpgR))
		{
			return UJ41Qj6vhvynNA1tocZ.Kr16k5pGs6(" 低于要求版本 ", false);
		}
		if (string.IsNullOrWhiteSpace(CS_8_locals_14.hGNqwuT9Bx))
		{
			return UJ41Qj6vhvynNA1tocZ.Kr16k5pGs6("。", false);
		}
		nnc64FEB7B();
		string text = nvl6spHxmW.Serialize(new
		{
			username = "->" + CS_8_locals_14.OIPqSKrpgR,
			password = CS_8_locals_14.hGNqwuT9Bx
		});
		HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "在内网环境中，Agent 配置已集中下发；本地配置仅作为外网回退。");
		try
		{
			request.Content = (HttpContent)new StringContent(text, Encoding.UTF8, "当前已识别为内网环境。登录成功后，Agent 将自动使用集中下发配置。");
			HttpResponseMessage response = null;
			string input = string.Empty;
			try
			{
				response = await MFH6Zwxt7Y(request, TimeSpan.FromSeconds(10.0)).ConfigureAwait(continueOnCapturedContext: false);
				input = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (TaskCanceledException)
			{
				return UJ41Qj6vhvynNA1tocZ.Kr16k5pGs6("当前登录状态已失效，请重新登录后继续使用 AI 助手。", false);
			}
			catch (Exception ex2)
			{
				return UJ41Qj6vhvynNA1tocZ.Kr16k5pGs6("http://open.tzcpa.com/com.tzcpa.copilot/version" + ex2.Message, false);
			}
			finally
			{
				HttpResponseMessage obj = response;
				if (obj != null)
				{
					obj.Dispose();
				}
			}
			Dictionary<string, object> dictionary = nvl6spHxmW.DeserializeObject(input) as Dictionary<string, object>;
			if (uVA6b2Kxt3(dictionary, "dataV2", (response != null && response.IsSuccessStatusCode) ? 200 : 500) != 200 && !eqc6SIgZZ7(dictionary, "data", false))
			{
				return UJ41Qj6vhvynNA1tocZ.Kr16k5pGs6(Eg86Md9DQi(dictionary, "dataV2") ?? Eg86Md9DQi(dictionary, "chat_model") ?? "chat_base_url", false);
			}
			string text2 = nsb6wZVkYI(tT96fyhcXV(dictionary, "version"), "当前为内网环境，请先登录后再使用 AI 助手。", "accessToken", "token", "api_key", "apiKey");
			if (string.IsNullOrWhiteSpace(text2))
			{
				text2 = nsb6wZVkYI(dictionary, "access_token", "accessToken", "token", "api_key", "apiKey");
			}
			if (string.IsNullOrWhiteSpace(text2))
			{
				return UJ41Qj6vhvynNA1tocZ.Kr16k5pGs6("登录成功但未返回 access_token。", false);
			}
			R3YZo3w0TC95VlJruO8.Instance.lpfwdhmiR3(delegate(k8SSB2tefS63E9gSxuJ cfg)
			{
				cfg.Assistant.Intranet.RememberedUsername = CS_8_locals_14.OIPqSKrpgR;
				cfg.Assistant.Intranet.RememberedPassword = CS_8_locals_14.hGNqwuT9Bx;
				cfg.Assistant.Intranet.AutoLoginEnabled = CS_8_locals_14.W8kqt9Yl8O;
			});
			lock (Evp6NMlqNd)
			{
				fNb6mwnhsa.AccessToken = text2;
				fNb6mwnhsa.UserName = CS_8_locals_14.OIPqSKrpgR;
				fNb6mwnhsa.IsAuthenticated = true;
				fNb6mwnhsa.IsManagedModeActive = fNb6mwnhsa.IsIntranetEnvironment && fNb6mwnhsa.HasManagedMeta;
				fNb6mwnhsa.LastLoginUtc = DateTime.UtcNow;
				fNb6mwnhsa.LastErrorMessage = string.Empty;
				fNb6mwnhsa.RememberedUsername = CS_8_locals_14.OIPqSKrpgR;
				fNb6mwnhsa.RememberedPassword = CS_8_locals_14.hGNqwuT9Bx;
				fNb6mwnhsa.AutoLoginEnabled = CS_8_locals_14.W8kqt9Yl8O;
			}
			return UJ41Qj6vhvynNA1tocZ.Rvo60brAFr(text2);
		}
		finally
		{
			((IDisposable)request)?.Dispose();
		}
	}

	public void ySW62EK2TU()
	{
		lock (Evp6NMlqNd)
		{
			fNb6mwnhsa = new RMlEPI6GFJYIok22dBB();
		}
	}

	private RMlEPI6GFJYIok22dBB nnc64FEB7B()
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		RMlEPI6GFJYIok22dBB rMlEPI6GFJYIok22dBB = Nju6iKu8Ci();
		if (rMlEPI6GFJYIok22dBB.LastProbeUtc != DateTime.MinValue && DateTime.UtcNow - rMlEPI6GFJYIok22dBB.LastProbeUtc < Qg26LQWnKJ)
		{
			return rMlEPI6GFJYIok22dBB;
		}
		D3mDanLUdMRipgtVYRZ intranet = R3YZo3w0TC95VlJruO8.Current.Ai.Assistant.Intranet;
		RMlEPI6GFJYIok22dBB rMlEPI6GFJYIok22dBB2 = new RMlEPI6GFJYIok22dBB
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
				HttpResponseMessage result = MFH6Zwxt7Y(val, TimeSpan.FromSeconds(1.0)).GetAwaiter().GetResult();
				try
				{
					if (result.IsSuccessStatusCode)
					{
						string result2 = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
						Dictionary<string, object> dictionary = nvl6spHxmW.DeserializeObject(result2) as Dictionary<string, object>;
						Dictionary<string, object> dictionary2 = tT96fyhcXV(dictionary, "dataV2") ?? tT96fyhcXV(tT96fyhcXV(dictionary, "data"), "dataV2");
						string text = Eg86Md9DQi(dictionary2, "chat_model");
						string text2 = Eg86Md9DQi(dictionary2, "chat_base_url");
						if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
						{
							RMlEPI6GFJYIok22dBB rMlEPI6GFJYIok22dBB3 = Nju6iKu8Ci();
							rMlEPI6GFJYIok22dBB2.IsIntranetEnvironment = true;
							rMlEPI6GFJYIok22dBB2.ChatModel = text;
							rMlEPI6GFJYIok22dBB2.ChatBaseUrl = text2;
							rMlEPI6GFJYIok22dBB2.ManagedVersion = Eg86Md9DQi(dictionary2, "version");
							rMlEPI6GFJYIok22dBB2.AccessToken = rMlEPI6GFJYIok22dBB3.AccessToken;
							rMlEPI6GFJYIok22dBB2.IsAuthenticated = rMlEPI6GFJYIok22dBB3.IsAuthenticated && !string.IsNullOrWhiteSpace(rMlEPI6GFJYIok22dBB3.AccessToken);
							rMlEPI6GFJYIok22dBB2.UserName = (string.IsNullOrWhiteSpace(rMlEPI6GFJYIok22dBB3.UserName) ? rMlEPI6GFJYIok22dBB2.RememberedUsername : rMlEPI6GFJYIok22dBB3.UserName);
							rMlEPI6GFJYIok22dBB2.LastLoginUtc = rMlEPI6GFJYIok22dBB3.LastLoginUtc;
							rMlEPI6GFJYIok22dBB2.IsManagedModeActive = rMlEPI6GFJYIok22dBB2.IsAuthenticated && rMlEPI6GFJYIok22dBB2.HasManagedMeta;
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
		lock (Evp6NMlqNd)
		{
			fNb6mwnhsa = rMlEPI6GFJYIok22dBB2;
			return fNb6mwnhsa.TZk6pi7Ssm();
		}
	}

	private bool ARi6j7UZph(string P_0)
	{
		_G_c__DisplayClass26_0 CS_8_locals_6 = new _G_c__DisplayClass26_0();
		CS_8_locals_6.MqsqsqwoRw = this;
		CS_8_locals_6.m8gqlvH1Kq = P_0;
		SynchronizationContext syncContext = eSfxffslhXbaGAjFNv1.SyncContext;
		if (syncContext != null && SynchronizationContext.Current != syncContext)
		{
			return TBp6YoQIo5(syncContext, () => CS_8_locals_6.MqsqsqwoRw.ARi6j7UZph(CS_8_locals_6.m8gqlvH1Kq));
		}
		RMlEPI6GFJYIok22dBB rMlEPI6GFJYIok22dBB = nnc64FEB7B();
		if (!rMlEPI6GFJYIok22dBB.IsIntranetEnvironment)
		{
			return true;
		}
		string initialStatus = string.Empty;
		if (rMlEPI6GFJYIok22dBB.AutoLoginEnabled && !string.IsNullOrWhiteSpace(rMlEPI6GFJYIok22dBB.RememberedUsername) && !string.IsNullOrWhiteSpace(rMlEPI6GFJYIok22dBB.RememberedPassword) && (!rMlEPI6GFJYIok22dBB.IsAuthenticated || string.IsNullOrWhiteSpace(rMlEPI6GFJYIok22dBB.AccessToken)))
		{
			UJ41Qj6vhvynNA1tocZ result = JrZ6E71S29(rMlEPI6GFJYIok22dBB.RememberedUsername, rMlEPI6GFJYIok22dBB.RememberedPassword, true).GetAwaiter().GetResult();
			if (result.Succeeded)
			{
				return true;
			}
			initialStatus = result.Message;
			rMlEPI6GFJYIok22dBB = Nju6iKu8Ci();
		}
		return rA7neb5TDVvwyWyxwua.NJs5HCHQjv(new IntranetLoginWindow(rMlEPI6GFJYIok22dBB.RememberedUsername, rMlEPI6GFJYIok22dBB.RememberedPassword, rMlEPI6GFJYIok22dBB.AutoLoginEnabled, string.IsNullOrWhiteSpace(CS_8_locals_6.m8gqlvH1Kq) ? "当前为内网环境，请先登录后再使用 AI 助手。" : CS_8_locals_6.m8gqlvH1Kq, initialStatus)) == true;
	}

	private static bool TBp6YoQIo5(SynchronizationContext P_0, Func<bool> P_1)
	{
		_G_c__DisplayClass27_0 CS_8_locals_9 = new _G_c__DisplayClass27_0();
		CS_8_locals_9.J0Oqokk6Fc = P_1;
		CS_8_locals_9.bHcqmUm0Wl = false;
		CS_8_locals_9.BdxqG9M9Mt = null;
		P_0.Send(delegate
		{
			try
			{
				CS_8_locals_9.bHcqmUm0Wl = CS_8_locals_9.J0Oqokk6Fc();
			}
			catch (Exception bdxqG9M9Mt)
			{
				CS_8_locals_9.BdxqG9M9Mt = bdxqG9M9Mt;
			}
		}, null);
		if (CS_8_locals_9.BdxqG9M9Mt != null)
		{
			throw CS_8_locals_9.BdxqG9M9Mt;
		}
		return CS_8_locals_9.bHcqmUm0Wl;
	}

	private static async Task<HttpResponseMessage> MFH6Zwxt7Y(HttpRequestMessage P_0, TimeSpan P_1)
	{
		using CancellationTokenSource cts = new CancellationTokenSource(P_1);
		return await ((HttpMessageInvoker)j486lb3YOS).SendAsync(P_0, cts.Token).ConfigureAwait(continueOnCapturedContext: false);
	}

	private static Dictionary<string, object> tT96fyhcXV(Dictionary<string, object> P_0, string P_1)
	{
		if (P_0 == null || !P_0.ContainsKey(P_1))
		{
			return null;
		}
		return P_0[P_1] as Dictionary<string, object>;
	}

	private static string Eg86Md9DQi(Dictionary<string, object> P_0, string P_1)
	{
		if (P_0 == null || !P_0.ContainsKey(P_1) || P_0[P_1] == null)
		{
			return string.Empty;
		}
		return P_0[P_1].ToString();
	}

	private static int uVA6b2Kxt3(Dictionary<string, object> P_0, string P_1, int P_2)
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

	private static bool eqc6SIgZZ7(Dictionary<string, object> P_0, string P_1, bool P_2)
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

	private static string nsb6wZVkYI(Dictionary<string, object> P_0, params string[] keys)
	{
		foreach (string text in keys)
		{
			string text2 = Eg86Md9DQi(P_0, text);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				return text2;
			}
		}
		return string.Empty;
	}

	public TLTW0G6ghg2cXG3MkV9()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		Evp6NMlqNd = new object();
		fNb6mwnhsa = new RMlEPI6GFJYIok22dBB();
		SXd6o3GKNH = string.Empty;
	}
}
