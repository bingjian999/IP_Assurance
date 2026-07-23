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

	private WebView2 _webView2;

	private DesktopAiBridgeServer _desktopAiBridgeServer;

	private bool _bool;

	private bool _bool;

	private bool _bool;

	private bool _bool;

	private string _string;

	[CompilerGenerated]
	private string _windowKey;

	[CompilerGenerated]
	private AiTargetBinder _target;

	public string WindowKey
	{
		[CompilerGenerated]
		get
		{
			return _windowKey;
		}
		[CompilerGenerated]
		set
		{
			_windowKey = value;
		}
	}

	public AiTargetBinder Target
	{
		[CompilerGenerated]
		get
		{
			return _target;
		}
		[CompilerGenerated]
		set
		{
			_target = value;
		}
	}

	public AiAssistantHost()
	{
		SseStreamInitializer.InitializeRuntime();
		O0p3l4nwwc();
		AiHelper_17.fWnUBnsIYw(HwR37nWbFR);
	}

	private void O0p3l4nwwc()
	{
		SuspendLayout();
		_webView2 = new WebView2
		{
			CreationProperties = new CoreWebView2CreationProperties
			{
				UserDataFolder = AiSseStreamService.GetUserDataPath("WebView2", "AgentTaskPane")
			},
			Dock = DockStyle.Fill
		};
		base.Controls.Add(_webView2);
		base.Name = "WordAgentTaskPaneControl";
		base.Size = new Size(560, 800);
		ResumeLayout(performLayout: false);
	}

	public async Task nb43Nxg93w()
	{
		if (_bool || _bool)
		{
			return;
		}
		_bool = true;
		try
		{
			if (!Mj53mPmCxk())
			{
				if (LoggerInitializer.ShowConfirm("WebView2", "AgentTaskPane"))
				{
					Process.Start(new ProcessStartInfo("WordAgentTaskPaneControl")
					{
						UseShellExecute = true
					});
				}
				return;
			}
			_desktopAiBridgeServer = AiAssistantHost2.mJIBvnaH0F(Target);
			if (_desktopAiBridgeServer != null)
			{
				await _webView2.EnsureCoreWebView2Async();
				PyX3CRqaXs();
				await _webView2.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(SOB3GPkoQ3());
				string text = Xvl3oTT4CU();
				if (text == null)
				{
					throw new FileNotFoundException("index.html" + AiSseStreamService.FrontendAssetsDir);
				}
				_webView2.CoreWebView2.SetVirtualHostNameToFolderMapping("app.local", text, CoreWebView2HostResourceAccessKind.Allow);
				try
				{
					await _webView2.CoreWebView2.Profile.ClearBrowsingDataAsync(CoreWebView2BrowsingDataKinds.CacheStorage | CoreWebView2BrowsingDataKinds.DiskCache);
				}
				catch
				{
				}
				_webView2.CoreWebView2.Navigate("https://app.local/index.html");
				wFK356xxfX();
				_bool = true;
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[AgentUI] initialization failed", ex);
			LoggerInitializer.ShowError("AI 助手初始化失败，请检查配置、网络环境和日志后重试。" + ex.Message, "AI 助手");
			_bool = false;
		}
		finally
		{
			_bool = false;
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
		bool isIntranetEnvironment = IntranetAiConfigService.Instance.GetConfig().IsIntranetEnvironment;
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
		return string.Format("window.__BRIDGE_PORT__ = {0}; ", _desktopAiBridgeServer.Port) + "window.__IS_LIGHT__ = true; window.__HOST_CONTEXT__ = " + text + ";window.__CPA_POST_ERROR__ = function (payload) {  try { if (window.chrome && window.chrome.webview && window.chrome.webview.postMessage) window.chrome.webview.postMessage(payload); } catch (_) { }};window.addEventListener('error', function (event) {  try { window.__CPA_POST_ERROR__('[agent-ui-error] ' + (event.message || 'unknown') + ' ' + (event.filename || '') + ':' + (event.lineno || 0)); } catch (_) { }});window.addEventListener('unhandledrejection', function (event) {  try { var r = event && event.reason; window.__CPA_POST_ERROR__('[agent-ui-rejection] ' + (typeof r === 'string' ? r : ((r && (r.stack || r.message)) || 'unknown'))); } catch (_) { }});(function(){function a(){if(!document.body)return;var b=document.getElementById('cpa-return-home');if(b)return;b=document.createElement('button');b.id='cpa-return-home';b.textContent='返回主界面';b.style.cssText='position:fixed;top:6px;right:8px;z-index:99999;background:rgba(255,255,255,0.92);border:1px solid #ccc;border-radius:6px;padding:3px 10px;font-size:12px;cursor:pointer;color:#444;box-shadow:0 1px 3px rgba(0,0,0,0.12);line-height:20px;transition:all .15s;white-space:nowrap';b.onmouseenter=function(){b.style.background='#e8e8e8';b.style.borderColor='#999'};b.onmouseleave=function(){b.style.background='rgba(255,255,255,0.92)';b.style.borderColor='#ccc'};b.onclick=function(){window.location.reload()};document.body.appendChild(b)}function init(){a();var m=new MutationObserver(function(){a()});m.observe(document.body,{childList:true,subtree:true})}if(document.readyState==='loading'){document.addEventListener('DOMContentLoaded',init)}else{init()}})();";
	}

	private void PyX3CRqaXs()
	{
		if (!_bool && _webView2?.CoreWebView2 != null)
		{
			_webView2.CoreWebView2.WebMessageReceived += VGG3pk7osX;
			_webView2.CoreWebView2.ProcessFailed += lMB3OQ8Rl8;
			_webView2.CoreWebView2.NavigationCompleted += ixs3nlkvjU;
			_bool = true;
		}
	}

	private void VGG3pk7osX(object P_0, CoreWebView2WebMessageReceivedEventArgs P_1)
	{
		try
		{
			string text = P_1.TryGetWebMessageAsString();
			if (!string.IsNullOrWhiteSpace(text))
			{
				AiConfigBootstrap.LogWarn("[AgentUI] " + text);
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AgentUI] Failed to read web message: " + ex.Message);
		}
	}

	private void lMB3OQ8Rl8(object P_0, CoreWebView2ProcessFailedEventArgs P_1)
	{
		AiConfigBootstrap.LogError(string.Format("[AgentUI] WebView process failed. Kind={0}; Reason={1}", P_1.ProcessFailedKind, P_1.Reason));
	}

	private void ixs3nlkvjU(object P_0, CoreWebView2NavigationCompletedEventArgs P_1)
	{
		if (P_1.IsSuccess)
		{
			eY03XNcEyA();
		}
		else
		{
			AiConfigBootstrap.LogWarn("[AgentUI] Navigation failed. Status=" + P_1.WebErrorStatus);
		}
	}

	private void HwR37nWbFR(AiTargetBinder P_0, AgentArtifact P_1)
	{
		if (P_1 == null || _webView2?.CoreWebView2 == null || (P_0 != null && !string.Equals(P_0.WindowKey, WindowKey, StringComparison.OrdinalIgnoreCase)))
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
			_webView2.CoreWebView2.ExecuteScriptAsync("window.dispatchEvent(new CustomEvent('cpa-agent-artifact', { detail: " + text + " }));");
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("HandleArtifactPublished failed: " + ex.Message);
		}
	}

	private void wFK356xxfX()
	{
		Microsoft.Office.Interop.Word.Application wordApp = WordTableToolService.WordApp;
		if (!_bool && wordApp != null)
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowActivate").AddEventHandler(wordApp, new ApplicationEvents4_WindowActivateEventHandler(tEu3ebUT5B));
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").AddEventHandler(wordApp, new ApplicationEvents4_WindowSelectionChangeEventHandler(Ink3y7HBFV));
			_bool = true;
		}
	}

	private void wBw3cW9FKn()
	{
		Microsoft.Office.Interop.Word.Application wordApp = WordTableToolService.WordApp;
		if (_bool && wordApp != null)
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowActivate").RemoveEventHandler(wordApp, new ApplicationEvents4_WindowActivateEventHandler(tEu3ebUT5B));
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").RemoveEventHandler(wordApp, new ApplicationEvents4_WindowSelectionChangeEventHandler(Ink3y7HBFV));
			_bool = false;
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
		if (_webView2?.CoreWebView2 == null)
		{
			return;
		}
		try
		{
			string text = CdZ3FO2FEj(Target);
			if (!string.IsNullOrWhiteSpace(text) && !(text == _string))
			{
				_string = text;
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
				_webView2.CoreWebView2.ExecuteScriptAsync("window.__HOST_STATUS__ = " + text2 + "; window.dispatchEvent(new CustomEvent('cpa-host-status', { detail: window.__HOST_STATUS__ }));");
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("PushCurrentHostStatus failed: " + ex.Message);
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
			if (_webView2?.CoreWebView2 != null && _bool)
			{
				_webView2.CoreWebView2.WebMessageReceived -= VGG3pk7osX;
				_webView2.CoreWebView2.ProcessFailed -= lMB3OQ8Rl8;
				_webView2.CoreWebView2.NavigationCompleted -= ixs3nlkvjU;
				_bool = false;
			}
			_webView2?.Dispose();
		}
		base.Dispose(P_0);
	}

	static AiAssistantHost()
	{
		SseStreamInitializer.InitializeRuntime();
		tSS3hxNHc0 = new JavaScriptSerializer();
	}
}
