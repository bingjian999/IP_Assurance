using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using AiAssistantHost2;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.DesktopShell;
using AiConfigBootstrap;
using AiSseStreamService3;
using AiTargetBinder;
using IntranetAiConfigService;
using Microsoft.Office.Interop.Word;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using SseStreamInitializer;
using AiSseStreamService;
using WordTableToolService;
using LoggerInitializer;
using AiHelper_17;

namespace AiAssistantHost;

internal sealed class AiAssistantHost : UserControl
{
	private static readonly JavaScriptSerializer tSS3hxNHc0;

	private WebView2 wAT3avlLMh;

	private DesktopAiBridgeServer Hsb3qVN1n2;

	private bool gdA3P70IOX;

	private bool XmG3AqiI65;

	private bool sRV3v4DOBf;

	private bool dfN3WbCGRG;

	private string Msd30L7SJ0;

	[CompilerGenerated]
	private string jj13kAM3U1;

	[CompilerGenerated]
	private AiTargetBinder iPJ3xa3Y18;

	public string WindowKey
	{
		[CompilerGenerated]
		get
		{
			return jj13kAM3U1;
		}
		[CompilerGenerated]
		set
		{
			jj13kAM3U1 = value;
		}
	}

	public AiTargetBinder Target
	{
		[CompilerGenerated]
		get
		{
			return iPJ3xa3Y18;
		}
		[CompilerGenerated]
		set
		{
			iPJ3xa3Y18 = value;
		}
	}

	public AiAssistantHost()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		O0p3l4nwwc();
		AiHelper_17.fWnUBnsIYw(HwR37nWbFR);
	}

	private void O0p3l4nwwc()
	{
		SuspendLayout();
		wAT3avlLMh = new WebView2
		{
			CreationProperties = new CoreWebView2CreationProperties
			{
				UserDataFolder = AiSseStreamService.mSfs9VWIdb("WebView2", "AgentTaskPane")
			},
			Dock = DockStyle.Fill
		};
		base.Controls.Add(wAT3avlLMh);
		base.Name = "WordAgentTaskPaneControl";
		base.Size = new Size(560, 800);
		ResumeLayout(performLayout: false);
	}

	public async Task nb43Nxg93w()
	{
		if (gdA3P70IOX || XmG3AqiI65)
		{
			return;
		}
		XmG3AqiI65 = true;
		try
		{
			if (!Mj53mPmCxk())
			{
				if (LoggerInitializer.JWucG2ERAH("WebView2", "AgentTaskPane"))
				{
					Process.Start(new ProcessStartInfo("WordAgentTaskPaneControl")
					{
						UseShellExecute = true
					});
				}
				return;
			}
			Hsb3qVN1n2 = AiAssistantHost2.mJIBvnaH0F(Target);
			if (Hsb3qVN1n2 != null)
			{
				await wAT3avlLMh.EnsureCoreWebView2Async();
				PyX3CRqaXs();
				await wAT3avlLMh.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(SOB3GPkoQ3());
				string text = Xvl3oTT4CU();
				if (text == null)
				{
					throw new FileNotFoundException("index.html" + AiSseStreamService.FrontendAssetsDir);
				}
				wAT3avlLMh.CoreWebView2.SetVirtualHostNameToFolderMapping("app.local", text, CoreWebView2HostResourceAccessKind.Allow);
				try
				{
					await wAT3avlLMh.CoreWebView2.Profile.ClearBrowsingDataAsync(CoreWebView2BrowsingDataKinds.CacheStorage | CoreWebView2BrowsingDataKinds.DiskCache);
				}
				catch
				{
				}
				wAT3avlLMh.CoreWebView2.Navigate("https://app.local/index.html");
				wFK356xxfX();
				gdA3P70IOX = true;
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.ujWsURly3F("[AgentUI] initialization failed", ex);
			LoggerInitializer.F9Ycoqv2I8("AI 助手初始化失败，请检查配置、网络环境和日志后重试。" + ex.Message, "AI 助手");
			gdA3P70IOX = false;
		}
		finally
		{
			XmG3AqiI65 = false;
		}
	}

	private static bool Mj53mPmCxk()
	{
		try
		{
			return !string.IsNullOrEmpty(CoreWebView2Environment.GetAvailableBrowserVersionString());
		}
		catch
		{
			return false;
		}
	}

	private static string Xvl3oTT4CU()
	{
		string frontendAssetsDir = AiSseStreamService.FrontendAssetsDir;
		if (!File.Exists(Path.Combine(frontendAssetsDir, "index.html")))
		{
			return null;
		}
		return frontendAssetsDir;
	}

	private string SOB3GPkoQ3()
	{
		bool isIntranetEnvironment = IntranetAiConfigService.Instance.Nju6iKu8Ci().IsIntranetEnvironment;
		var obj = new
		{
			hostKind = "word",
			welcomeTitle = (isIntranetEnvironment ? "你好，我是小帮手" : "大噶好，我是赵公子，今后的AFS由我买单"),
			welcomeDescription = "你可以直接提问，也可以引用当前 Word 文档或选中文本。",
			quickPrompts = new string[3]
			{
				"总结当前选中的文字",
				"帮我润色当前段落",
				"我有哪些 Word 文档处理能力"
			},
			capabilities = new string[3]
			{
				"word-document-context",
				"word-editing",
				"artifact-export"
			},
			branding = (isIntranetEnvironment ? "IP_Assurance Word" : "IP赵公子"),
			themePreset = (isIntranetEnvironment ? "default" : "intranet"),
			themeAccent = (isIntranetEnvironment ? "#D1EC51" : null),
			themeAccentStrong = (isIntranetEnvironment ? "#B8D63D" : null),
			themeAccentSoft = (isIntranetEnvironment ? "#F2FACD" : null),
			inputBorderColor = (isIntranetEnvironment ? "#D1EC51" : null),
			cardBorderColor = (isIntranetEnvironment ? "#E3EBBE" : null),
			runtimeStatusEnabled = true,
			runtimeStatusPollIntervalMs = 0
		};
		string text = tSS3hxNHc0.Serialize(obj);
		return string.Format("window.__BRIDGE_PORT__ = {0}; ", Hsb3qVN1n2.Port) + "window.__IS_LIGHT__ = true; window.__HOST_CONTEXT__ = " + text + ";window.__CPA_POST_ERROR__ = function (payload) {  try { if (window.chrome && window.chrome.webview && window.chrome.webview.postMessage) window.chrome.webview.postMessage(payload); } catch (_) { }};window.addEventListener('error', function (event) {  try { window.__CPA_POST_ERROR__('[agent-ui-error] ' + (event.message || 'unknown') + ' ' + (event.filename || '') + ':' + (event.lineno || 0)); } catch (_) { }});window.addEventListener('unhandledrejection', function (event) {  try { var r = event && event.reason; window.__CPA_POST_ERROR__('[agent-ui-rejection] ' + (typeof r === 'string' ? r : ((r && (r.stack || r.message)) || 'unknown'))); } catch (_) { }});(function(){function a(){if(!document.body)return;var b=document.getElementById('cpa-return-home');if(b)return;b=document.createElement('button');b.id='cpa-return-home';b.textContent='返回主界面';b.style.cssText='position:fixed;top:6px;right:8px;z-index:99999;background:rgba(255,255,255,0.92);border:1px solid #ccc;border-radius:6px;padding:3px 10px;font-size:12px;cursor:pointer;color:#444;box-shadow:0 1px 3px rgba(0,0,0,0.12);line-height:20px;transition:all .15s;white-space:nowrap';b.onmouseenter=function(){b.style.background='#e8e8e8';b.style.borderColor='#999'};b.onmouseleave=function(){b.style.background='rgba(255,255,255,0.92)';b.style.borderColor='#ccc'};b.onclick=function(){window.location.reload()};document.body.appendChild(b)}function init(){a();var m=new MutationObserver(function(){a()});m.observe(document.body,{childList:true,subtree:true})}if(document.readyState==='loading'){document.addEventListener('DOMContentLoaded',init)}else{init()}})();";
	}

	private void PyX3CRqaXs()
	{
		if (!sRV3v4DOBf && wAT3avlLMh?.CoreWebView2 != null)
		{
			wAT3avlLMh.CoreWebView2.WebMessageReceived += VGG3pk7osX;
			wAT3avlLMh.CoreWebView2.ProcessFailed += lMB3OQ8Rl8;
			wAT3avlLMh.CoreWebView2.NavigationCompleted += ixs3nlkvjU;
			sRV3v4DOBf = true;
		}
	}

	private void VGG3pk7osX(object P_0, CoreWebView2WebMessageReceivedEventArgs P_1)
	{
		try
		{
			string text = P_1.TryGetWebMessageAsString();
			if (!string.IsNullOrWhiteSpace(text))
			{
				AiConfigBootstrap.z7Us3dJ6Cl("[AgentUI] " + text);
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.z7Us3dJ6Cl("[AgentUI] Failed to read web message: " + ex.Message);
		}
	}

	private void lMB3OQ8Rl8(object P_0, CoreWebView2ProcessFailedEventArgs P_1)
	{
		AiConfigBootstrap.ujWsURly3F(string.Format("[AgentUI] WebView process failed. Kind={0}; Reason={1}", P_1.ProcessFailedKind, P_1.Reason));
	}

	private void ixs3nlkvjU(object P_0, CoreWebView2NavigationCompletedEventArgs P_1)
	{
		if (P_1.IsSuccess)
		{
			eY03XNcEyA();
		}
		else
		{
			AiConfigBootstrap.z7Us3dJ6Cl("[AgentUI] Navigation failed. Status=" + P_1.WebErrorStatus);
		}
	}

	private void HwR37nWbFR(AiTargetBinder P_0, AgentArtifact P_1)
	{
		if (P_1 == null || wAT3avlLMh?.CoreWebView2 == null || (P_0 != null && !string.Equals(P_0.WindowKey, WindowKey, StringComparison.OrdinalIgnoreCase)))
		{
			return;
		}
		try
		{
			string text = tSS3hxNHc0.Serialize(new
			{
				artifactType = P_1.Type,
				title = P_1.Title,
				recordCount = P_1.RecordCount
			});
			wAT3avlLMh.CoreWebView2.ExecuteScriptAsync("window.dispatchEvent(new CustomEvent('cpa-agent-artifact', { detail: " + text + " }));");
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.z7Us3dJ6Cl("HandleArtifactPublished failed: " + ex.Message);
		}
	}

	private void wFK356xxfX()
	{
		Microsoft.Office.Interop.Word.Application wordApp = WordTableToolService.WordApp;
		if (!dfN3WbCGRG && wordApp != null)
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowActivate").AddEventHandler(wordApp, new ApplicationEvents4_WindowActivateEventHandler(tEu3ebUT5B));
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").AddEventHandler(wordApp, new ApplicationEvents4_WindowSelectionChangeEventHandler(Ink3y7HBFV));
			dfN3WbCGRG = true;
		}
	}

	private void wBw3cW9FKn()
	{
		Microsoft.Office.Interop.Word.Application wordApp = WordTableToolService.WordApp;
		if (dfN3WbCGRG && wordApp != null)
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowActivate").RemoveEventHandler(wordApp, new ApplicationEvents4_WindowActivateEventHandler(tEu3ebUT5B));
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").RemoveEventHandler(wordApp, new ApplicationEvents4_WindowSelectionChangeEventHandler(Ink3y7HBFV));
			dfN3WbCGRG = false;
		}
	}

	private void tEu3ebUT5B(Document P_0, Window P_1)
	{
		eY03XNcEyA();
	}

	private void Ink3y7HBFV(Selection P_0)
	{
		eY03XNcEyA();
	}

	private void eY03XNcEyA()
	{
		if (wAT3avlLMh?.CoreWebView2 == null)
		{
			return;
		}
		try
		{
			string text = CdZ3FO2FEj(Target);
			if (!string.IsNullOrWhiteSpace(text) && !(text == Msd30L7SJ0))
			{
				Msd30L7SJ0 = text;
				string text2 = tSS3hxNHc0.Serialize(new
				{
					items = new[]
					{
						new
						{
							key = "currentDocument",
							label = "当前文档",
							value = text
						}
					}
				});
				wAT3avlLMh.CoreWebView2.ExecuteScriptAsync("window.__HOST_STATUS__ = " + text2 + "; window.dispatchEvent(new CustomEvent('cpa-host-status', { detail: window.__HOST_STATUS__ }));");
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.z7Us3dJ6Cl("PushCurrentHostStatus failed: " + ex.Message);
		}
	}

	private static string CdZ3FO2FEj(AiTargetBinder P_0)
	{
		try
		{
			Microsoft.Office.Interop.Word.Application wordApp = WordTableToolService.WordApp;
			Document document = ((P_0 != null) ? P_0.iHlupRS7Nk(wordApp) : wordApp?.ActiveDocument);
			if (document == null)
			{
				return null;
			}
			string text = document.Name ?? "未命名文档";
			string value = null;
			try
			{
				Document document2 = wordApp?.ActiveDocument;
				if (document2 != null && (string.Equals(document2.FullName, document.FullName, StringComparison.OrdinalIgnoreCase) || string.Equals(document2.Name, document.Name, StringComparison.OrdinalIgnoreCase)))
				{
					value = wordApp.Selection?.Range?.Text;
				}
			}
			catch
			{
			}
			string text2 = (string.IsNullOrWhiteSpace(value) ? "" : "，已选中文字");
			return text + text2;
		}
		catch
		{
			return null;
		}
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0)
		{
			AiHelper_17.vIPU93N8BE(HwR37nWbFR);
			AiAssistantHost2.Kf7BW0nRZX(WindowKey);
			wBw3cW9FKn();
			if (wAT3avlLMh?.CoreWebView2 != null && sRV3v4DOBf)
			{
				wAT3avlLMh.CoreWebView2.WebMessageReceived -= VGG3pk7osX;
				wAT3avlLMh.CoreWebView2.ProcessFailed -= lMB3OQ8Rl8;
				wAT3avlLMh.CoreWebView2.NavigationCompleted -= ixs3nlkvjU;
				sRV3v4DOBf = false;
			}
			wAT3avlLMh?.Dispose();
		}
		base.Dispose(P_0);
	}

	static AiAssistantHost()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		tSS3hxNHc0 = new JavaScriptSerializer();
	}
}
