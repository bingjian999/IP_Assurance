using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AiSseStreamService3;
using Helper_16;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using SseStreamInitializer;
using Newtonsoft.Json.Linq;
using AiSseStreamService;
using ImageAssetInfo;

namespace ScreenshotCaptureHelper3;

internal sealed class ScreenshotCaptureHelper3
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass14_0
	{
		public Form renderForm;

		public Helper_16 helper_16;

		public string text;

		public string text;

		public string text;

		public ImageAssetInfo resultAsset;

		public string text;

		public Exception exception;

		public _G_c__DisplayClass14_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void RenderHtmlToPngCore()
		{
			try
			{
				_G_c__DisplayClass14_1 CS_8_locals_42 = new _G_c__DisplayClass14_1();
				CS_8_locals_42._G_c__DisplayClass14_0 = this;
				CS_8_locals_42.form = new Form();
				try
				{
					CS_8_locals_42.webView = new WebView2();
					try
					{
						renderForm = CS_8_locals_42.form;
						CS_8_locals_42.form.FormBorderStyle = FormBorderStyle.None;
						CS_8_locals_42.form.StartPosition = FormStartPosition.Manual;
						CS_8_locals_42.form.Location = new Point(-32000, -32000);
						CS_8_locals_42.form.ClientSize = new Size(helper_16.PixelWidth, helper_16.PixelHeight);
						CS_8_locals_42.form.ShowInTaskbar = false;
						CS_8_locals_42.form.Text = "IP_Assurance HTML Visual Renderer";
						CS_8_locals_42.webView.Dock = DockStyle.Fill;
						CS_8_locals_42.webView.CreationProperties = new CoreWebView2CreationProperties
						{
							UserDataFolder = AiSseStreamService.GetUserDataPath("WebView2", "HtmlVisualRenderer", Process.GetCurrentProcess().Id.ToString())
						};
						CS_8_locals_42.form.Controls.Add(CS_8_locals_42.webView);
						CS_8_locals_42.form.Shown += async delegate
						{
							try
							{
								await NavigateAndCaptureAsync(CS_8_locals_42.webView, CS_8_locals_42._G_c__DisplayClass14_0.text, CS_8_locals_42._G_c__DisplayClass14_0.text, CS_8_locals_42._G_c__DisplayClass14_0.helper_16.PixelWidth, CS_8_locals_42._G_c__DisplayClass14_0.helper_16.PixelHeight).ConfigureAwait(continueOnCapturedContext: true);
								ResizePngToExactSize(CS_8_locals_42._G_c__DisplayClass14_0.text, CS_8_locals_42._G_c__DisplayClass14_0.helper_16.PixelWidth, CS_8_locals_42._G_c__DisplayClass14_0.helper_16.PixelHeight);
								FileInfo fileInfo = new FileInfo(CS_8_locals_42._G_c__DisplayClass14_0.text);
								if (!fileInfo.Exists || fileInfo.Length == 0L)
								{
									throw new InvalidOperationException("Word document preview prepared.");
								}
								int width;
								int height;
								using (Image image = Image.FromFile(CS_8_locals_42._G_c__DisplayClass14_0.text))
								{
									width = image.Width;
									height = image.Height;
								}
								if (Math.Abs(width - CS_8_locals_42._G_c__DisplayClass14_0.helper_16.PixelWidth) > 2 || Math.Abs(height - CS_8_locals_42._G_c__DisplayClass14_0.helper_16.PixelHeight) > 2)
								{
									throw new InvalidOperationException(string.Format("IP_Assurance HTML Visual Renderer", CS_8_locals_42._G_c__DisplayClass14_0.helper_16.PixelWidth, CS_8_locals_42._G_c__DisplayClass14_0.helper_16.PixelHeight, width, height));
								}
								File.WriteAllText(CS_8_locals_42._G_c__DisplayClass14_0.text, CS_8_locals_42._G_c__DisplayClass14_0.text, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
								CS_8_locals_42._G_c__DisplayClass14_0.resultAsset = new ImageAssetInfo
								{
									PngPath = CS_8_locals_42._G_c__DisplayClass14_0.text,
									SourcePath = CS_8_locals_42._G_c__DisplayClass14_0.text,
									SourceHash = CS_8_locals_42._G_c__DisplayClass14_0.text,
									PixelWidth = width,
									PixelHeight = height,
									PngBytes = fileInfo.Length
								};
							}
							catch (Exception ex2)
							{
								CS_8_locals_42._G_c__DisplayClass14_0.exception = ex2;
							}
							finally
							{
								CS_8_locals_42.form.Close();
							}
						};
						Application.Run(CS_8_locals_42.form);
					}
					finally
					{
						if (CS_8_locals_42.webView != null)
						{
							((IDisposable)CS_8_locals_42.webView).Dispose();
						}
					}
				}
				finally
				{
					if (CS_8_locals_42.form != null)
					{
						((IDisposable)CS_8_locals_42.form).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				exception = ex;
			}
			finally
			{
				renderForm = null;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass14_1
	{
		public Form form;

		public WebView2 webView;

		public _G_c__DisplayClass14_0 _G_c__DisplayClass14_0;

		public _G_c__DisplayClass14_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal async void OnFormShown(object sender, EventArgs args)
		{
			try
			{
				await NavigateAndCaptureAsync(webView, _G_c__DisplayClass14_0.text, _G_c__DisplayClass14_0.text, _G_c__DisplayClass14_0.helper_16.PixelWidth, _G_c__DisplayClass14_0.helper_16.PixelHeight).ConfigureAwait(continueOnCapturedContext: true);
				ResizePngToExactSize(_G_c__DisplayClass14_0.text, _G_c__DisplayClass14_0.helper_16.PixelWidth, _G_c__DisplayClass14_0.helper_16.PixelHeight);
				FileInfo fileInfo = new FileInfo(_G_c__DisplayClass14_0.text);
				if (!fileInfo.Exists || fileInfo.Length == 0L)
				{
					throw new InvalidOperationException("WebView2 did not produce a PNG image.");
				}
				int width;
				int height;
				using (Image image = Image.FromFile(_G_c__DisplayClass14_0.text))
				{
					width = image.Width;
					height = image.Height;
				}
				if (Math.Abs(width - _G_c__DisplayClass14_0.helper_16.PixelWidth) > 2 || Math.Abs(height - _G_c__DisplayClass14_0.helper_16.PixelHeight) > 2)
				{
					throw new InvalidOperationException(string.Format("Rendered PNG size mismatch. Expected {0}x{1}, actual {2}x{3}.", _G_c__DisplayClass14_0.helper_16.PixelWidth, _G_c__DisplayClass14_0.helper_16.PixelHeight, width, height));
				}
				File.WriteAllText(_G_c__DisplayClass14_0.text, _G_c__DisplayClass14_0.text, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
				_G_c__DisplayClass14_0.resultAsset = new ImageAssetInfo
				{
					PngPath = _G_c__DisplayClass14_0.text,
					SourcePath = _G_c__DisplayClass14_0.text,
					SourceHash = _G_c__DisplayClass14_0.text,
					PixelWidth = width,
					PixelHeight = height,
					PngBytes = fileInfo.Length
				};
			}
			catch (Exception exception)
			{
				_G_c__DisplayClass14_0.exception = exception;
			}
			finally
			{
				form.Close();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass15_0
	{
		public CoreWebView2 coreWebView2;

		public EventHandler<CoreWebView2NavigationCompletedEventArgs> navigationCompletedHandler;

		public TaskCompletionSource<CoreWebView2NavigationCompletedEventArgs> navigationCompletionSource;

		public _G_c__DisplayClass15_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void OnNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs args)
		{
			coreWebView2.NavigationCompleted -= navigationCompletedHandler;
			navigationCompletionSource.TrySetResult(args);
		}
	}

	private static readonly SemaphoreSlim _renderSemaphore;

	private static readonly Regex _forbiddenTagRegex;

	private static readonly Regex _eventHandlerRegex;

	private static readonly Regex _urlSchemeRegex;

	private static readonly Regex _srcHrefRegex;

	private static readonly Regex _cssUrlRegex;

	private static readonly Regex _colorFormatRegex;

	public ImageAssetInfo RenderHtmlToPng(Helper_16 P_0)
	{
		ValidateRenderRequest(P_0);
		_renderSemaphore.Wait();
		try
		{
			return RenderHtmlToPngInternal(P_0);
		}
		finally
		{
			_renderSemaphore.Release();
		}
	}

	private static ImageAssetInfo RenderHtmlToPngInternal(Helper_16 P_0)
	{
		_G_c__DisplayClass14_0 CS_8_locals_47 = new _G_c__DisplayClass14_0();
		CS_8_locals_47.helper_16 = P_0;
		CS_8_locals_47.text = ComputeSha256Hash(CS_8_locals_47.helper_16.HtmlFragment);
		CS_8_locals_47.text = BuildFullHtmlDocument(CS_8_locals_47.helper_16);
		string path = AiSseStreamService.GetTempPath("AI", "HtmlVisuals");
		string path2 = AiSseStreamService.GetUserDataPath("Agent", "html-visuals");
		CS_8_locals_47.text = Path.Combine(path, "html-visual-" + Guid.NewGuid().ToString("N") + ".png");
		CS_8_locals_47.text = Path.Combine(path2, CS_8_locals_47.text + ".html");
		CS_8_locals_47.exception = null;
		CS_8_locals_47.resultAsset = null;
		CS_8_locals_47.renderForm = null;
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				_G_c__DisplayClass14_1 CS_8_locals_69 = new _G_c__DisplayClass14_1();
				CS_8_locals_69._G_c__DisplayClass14_0 = CS_8_locals_47;
				CS_8_locals_69.form = new Form();
				try
				{
					CS_8_locals_69.webView = new WebView2();
					try
					{
						CS_8_locals_47.renderForm = CS_8_locals_69.form;
						CS_8_locals_69.form.FormBorderStyle = FormBorderStyle.None;
						CS_8_locals_69.form.StartPosition = FormStartPosition.Manual;
						CS_8_locals_69.form.Location = new Point(-32000, -32000);
						CS_8_locals_69.form.ClientSize = new Size(CS_8_locals_47.helper_16.PixelWidth, CS_8_locals_47.helper_16.PixelHeight);
						CS_8_locals_69.form.ShowInTaskbar = false;
						CS_8_locals_69.form.Text = "CPAHelper.HtmlVisualRenderer";
						CS_8_locals_69.webView.Dock = DockStyle.Fill;
						CS_8_locals_69.webView.CreationProperties = new CoreWebView2CreationProperties
						{
							UserDataFolder = AiSseStreamService.GetUserDataPath("HTML visual rendering timed out after 30 seconds.", "HTML visual rendering failed: ", Process.GetCurrentProcess().Id.ToString())
						};
						CS_8_locals_69.form.Controls.Add(CS_8_locals_69.webView);
						CS_8_locals_69.form.Shown += async delegate
						{
							try
							{
								await NavigateAndCaptureAsync(CS_8_locals_69.webView, CS_8_locals_69._G_c__DisplayClass14_0.text, CS_8_locals_69._G_c__DisplayClass14_0.text, CS_8_locals_69._G_c__DisplayClass14_0.helper_16.PixelWidth, CS_8_locals_69._G_c__DisplayClass14_0.helper_16.PixelHeight).ConfigureAwait(continueOnCapturedContext: true);
								ResizePngToExactSize(CS_8_locals_69._G_c__DisplayClass14_0.text, CS_8_locals_69._G_c__DisplayClass14_0.helper_16.PixelWidth, CS_8_locals_69._G_c__DisplayClass14_0.helper_16.PixelHeight);
								FileInfo fileInfo = new FileInfo(CS_8_locals_69._G_c__DisplayClass14_0.text);
								if (!fileInfo.Exists || fileInfo.Length == 0L)
								{
									throw new InvalidOperationException("HTML visual rendering completed without a result.");
								}
								int width;
								int height;
								using (Image image = Image.FromFile(CS_8_locals_69._G_c__DisplayClass14_0.text))
								{
									width = image.Width;
									height = image.Height;
								}
								if (Math.Abs(width - CS_8_locals_69._G_c__DisplayClass14_0.helper_16.PixelWidth) > 2 || Math.Abs(height - CS_8_locals_69._G_c__DisplayClass14_0.helper_16.PixelHeight) > 2)
								{
									throw new InvalidOperationException(string.Format("AI", CS_8_locals_69._G_c__DisplayClass14_0.helper_16.PixelWidth, CS_8_locals_69._G_c__DisplayClass14_0.helper_16.PixelHeight, width, height));
								}
								File.WriteAllText(CS_8_locals_69._G_c__DisplayClass14_0.text, CS_8_locals_69._G_c__DisplayClass14_0.text, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
								CS_8_locals_69._G_c__DisplayClass14_0.resultAsset = new ImageAssetInfo
								{
									PngPath = CS_8_locals_69._G_c__DisplayClass14_0.text,
									SourcePath = CS_8_locals_69._G_c__DisplayClass14_0.text,
									SourceHash = CS_8_locals_69._G_c__DisplayClass14_0.text,
									PixelWidth = width,
									PixelHeight = height,
									PngBytes = fileInfo.Length
								};
							}
							catch (Exception renderException)
							{
								CS_8_locals_69._G_c__DisplayClass14_0.exception = renderException;
							}
							finally
							{
								CS_8_locals_69.form.Close();
							}
						};
						Application.Run(CS_8_locals_69.form);
					}
					finally
					{
						if (CS_8_locals_69.webView != null)
						{
							((IDisposable)CS_8_locals_69.webView).Dispose();
						}
					}
				}
				finally
				{
					if (CS_8_locals_69.form != null)
					{
						((IDisposable)CS_8_locals_69.form).Dispose();
					}
				}
			}
			catch (Exception exception)
			{
				CS_8_locals_47.exception = exception;
			}
			finally
			{
				CS_8_locals_47.renderForm = null;
			}
		});
		thread.IsBackground = true;
		thread.Name = "HtmlVisuals";
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		if (!thread.Join(30000))
		{
			try
			{
				Form form = CS_8_locals_47.renderForm;
				if (form != null && form.IsHandleCreated && !form.IsDisposed)
				{
					form.BeginInvoke(new Action(form.Close));
				}
			}
			catch
			{
			}
			thread.Join(2000);
			DeleteTempPng(CS_8_locals_47.text);
			throw new TimeoutException("Agent");
		}
		if (CS_8_locals_47.exception != null)
		{
			DeleteTempPng(CS_8_locals_47.text);
			throw new InvalidOperationException("html-visuals" + CS_8_locals_47.exception.Message, CS_8_locals_47.exception);
		}
		if (CS_8_locals_47.resultAsset == null)
		{
			DeleteTempPng(CS_8_locals_47.text);
			throw new InvalidOperationException("html-visual-");
		}
		return CS_8_locals_47.resultAsset;
	}

	private static async Task NavigateAndCaptureAsync(WebView2 P_0, string P_1, string P_2, int P_3, int P_4)
	{
		_G_c__DisplayClass15_0 CS_8_locals_21 = new _G_c__DisplayClass15_0();
		await P_0.EnsureCoreWebView2Async();
		CS_8_locals_21.coreWebView2 = P_0.CoreWebView2;
		CS_8_locals_21.coreWebView2.Settings.IsScriptEnabled = false;
		CS_8_locals_21.coreWebView2.Settings.IsWebMessageEnabled = false;
		CS_8_locals_21.coreWebView2.Settings.AreDefaultContextMenusEnabled = false;
		CS_8_locals_21.coreWebView2.Settings.AreDefaultScriptDialogsEnabled = false;
		CS_8_locals_21.coreWebView2.Settings.AreDevToolsEnabled = false;
		CS_8_locals_21.coreWebView2.Settings.IsStatusBarEnabled = false;
		CS_8_locals_21.coreWebView2.Settings.IsZoomControlEnabled = false;
		CS_8_locals_21.coreWebView2.NavigationStarting += delegate(object sender, CoreWebView2NavigationStartingEventArgs args)
		{
			if (!string.Equals(args.Uri, "N", StringComparison.OrdinalIgnoreCase) && (string.IsNullOrWhiteSpace(args.Uri) || !args.Uri.StartsWith(".png", StringComparison.OrdinalIgnoreCase)))
			{
				args.Cancel = true;
			}
		};
		CS_8_locals_21.navigationCompletionSource = new TaskCompletionSource<CoreWebView2NavigationCompletedEventArgs>();
		CS_8_locals_21.navigationCompletedHandler = null;
		CS_8_locals_21.navigationCompletedHandler = delegate(object sender, CoreWebView2NavigationCompletedEventArgs args)
		{
			CS_8_locals_21.coreWebView2.NavigationCompleted -= CS_8_locals_21.navigationCompletedHandler;
			CS_8_locals_21.navigationCompletionSource.TrySetResult(args);
		};
		CS_8_locals_21.coreWebView2.NavigationCompleted += CS_8_locals_21.navigationCompletedHandler;
		CS_8_locals_21.coreWebView2.NavigateToString(P_1);
		CoreWebView2NavigationCompletedEventArgs e = await CS_8_locals_21.navigationCompletionSource.Task.ConfigureAwait(continueOnCapturedContext: true);
		if (!e.IsSuccess)
		{
			throw new InvalidOperationException(".html" + e.WebErrorStatus);
		}
		await Task.Delay(350).ConfigureAwait(continueOnCapturedContext: true);
		await EnsureRenderSizeAsync(P_0, CS_8_locals_21.coreWebView2, P_3, P_4).ConfigureAwait(continueOnCapturedContext: true);
		using FileStream stream = new FileStream(P_2, FileMode.Create, FileAccess.Write, FileShare.Read);
		await CS_8_locals_21.coreWebView2.CapturePreviewAsync(CoreWebView2CapturePreviewImageFormat.Png, stream).ConfigureAwait(continueOnCapturedContext: true);
		await stream.FlushAsync().ConfigureAwait(continueOnCapturedContext: true);
	}

	private static async Task EnsureRenderSizeAsync(WebView2 P_0, CoreWebView2 P_1, int P_2, int P_3)
	{
		JObject jObject = JObject.Parse(await P_1.ExecuteScriptAsync("CPAHelper.HtmlVisualRenderer").ConfigureAwait(continueOnCapturedContext: true));
		int num = jObject.Value<int>("HTML visual rendering timed out after 30 seconds.");
		int num2 = jObject.Value<int>("HTML visual rendering failed: ");
		if (num <= 0 || num2 <= 0)
		{
			throw new InvalidOperationException("HTML visual rendering completed without a result.");
		}
		if (Math.Abs(num - P_2) > 8 || Math.Abs(num2 - P_3) > 8)
		{
			Form form = P_0.FindForm();
			if (form == null)
			{
				throw new InvalidOperationException(".resized.png");
			}
			double num3 = (double)P_2 / (double)num;
			double num4 = (double)P_3 / (double)num2;
			form.ClientSize = new Size(Math.Max(1, (int)Math.Ceiling((double)form.ClientSize.Width * num3)), Math.Max(1, (int)Math.Ceiling((double)form.ClientSize.Height * num4)));
			await Task.Delay(250).ConfigureAwait(continueOnCapturedContext: true);
			JObject jObject2 = JObject.Parse(await P_1.ExecuteScriptAsync("request").ConfigureAwait(continueOnCapturedContext: true));
			int num5 = jObject2.Value<int>("HTML fragment must not be empty.");
			int num6 = jObject2.Value<int>("HtmlFragment");
			if (Math.Abs(num5 - P_2) > 8 || Math.Abs(num6 - P_3) > 8)
			{
				throw new InvalidOperationException(string.Format("HTML fragment exceeds the {0:N0} character limit.", P_2, P_3, num5, num6));
			}
		}
	}

	private static void ResizePngToExactSize(string P_0, int P_1, int P_2)
	{
		string text = P_0 + ".resized.png";
		try
		{
			using (Image image = Image.FromFile(P_0))
			{
				if (image.Width == P_1 && image.Height == P_2)
				{
					return;
				}
				using Bitmap bitmap = new Bitmap(P_1, P_2, PixelFormat.Format32bppArgb);
				bitmap.SetResolution(96f, 96f);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.CompositingMode = CompositingMode.SourceCopy;
					graphics.CompositingQuality = CompositingQuality.HighQuality;
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
					graphics.DrawImage(image, new Rectangle(0, 0, P_1, P_2));
				}
				bitmap.Save(text, ImageFormat.Png);
			}
			File.Delete(P_0);
			File.Move(text, P_0);
		}
		finally
		{
			DeleteTempPng(text);
		}
	}

	private static void ValidateRenderRequest(Helper_16 P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("request");
		}
		if (string.IsNullOrWhiteSpace(P_0.HtmlFragment))
		{
			throw new ArgumentException("HTML fragment must not be empty.", "HtmlFragment");
		}
		if (P_0.HtmlFragment.Length > 500000)
		{
			throw new ArgumentException(string.Format("HTML fragment exceeds the {0:N0} character limit.", 500000), "HtmlFragment");
		}
		if (P_0.PixelWidth < 240 || P_0.PixelWidth > 1920)
		{
			throw new ArgumentException(string.Format("width must be between {0} and {1} pixels.", 240, 1920), "PixelWidth");
		}
		if (P_0.PixelHeight < 120 || P_0.PixelHeight > 1080)
		{
			throw new ArgumentException(string.Format("height must be between {0} and {1} pixels.", 120, 1080), "PixelHeight");
		}
		string input = (string.IsNullOrWhiteSpace(P_0.BackgroundColor) ? "#ffffff" : P_0.BackgroundColor.Trim());
		if (!_colorFormatRegex.IsMatch(input))
		{
			throw new ArgumentException("backgroundColor must be #RGB, #RRGGBB, or transparent.", "BackgroundColor");
		}
		string htmlFragment = P_0.HtmlFragment;
		if (_forbiddenTagRegex.IsMatch(htmlFragment))
		{
			throw new ArgumentException("HTML contains a forbidden active or embedding tag.", "HtmlFragment");
		}
		if (_eventHandlerRegex.IsMatch(htmlFragment))
		{
			throw new ArgumentException("HTML event handler attributes such as onclick are not allowed.", "HtmlFragment");
		}
		if (_urlSchemeRegex.IsMatch(htmlFragment) || Regex.IsMatch(htmlFragment, "@import\\\\b", RegexOptions.IgnoreCase))
		{
			throw new ArgumentException("External URLs, active URL schemes, and CSS @import are not allowed.", "HtmlFragment");
		}
		foreach (Match item in _srcHrefRegex.Matches(htmlFragment))
		{
			string text = item.Groups["value"].Value.Trim();
			if (!text.StartsWith("data:", StringComparison.OrdinalIgnoreCase) && !text.StartsWith("#", StringComparison.Ordinal))
			{
				throw new ArgumentException("src/href resources must use data: URLs or local SVG fragment references.", "HtmlFragment");
			}
		}
		foreach (Match item2 in _cssUrlRegex.Matches(htmlFragment))
		{
			if (!item2.Groups["value"].Value.Trim().Trim('\'', '"').StartsWith("data:", StringComparison.OrdinalIgnoreCase))
			{
				throw new ArgumentException("CSS url() resources must use data: URLs.", "HtmlFragment");
			}
		}
	}

	private static string BuildFullHtmlDocument(Helper_16 P_0)
	{
		string text = (string.IsNullOrWhiteSpace(P_0.BackgroundColor) ? "#ffffff" : P_0.BackgroundColor.Trim());
		return "<!doctype html><html><head><meta charset=\"utf-8\"><meta http-equiv=\"Content-Security-Policy\" content=\"default-src 'none'; img-src data:; style-src 'unsafe-inline'; font-src data:; script-src 'none'; connect-src 'none'; object-src 'none'; frame-src 'none';\"><style>html,body{margin:0;padding:0;width:100%;height:100%;overflow:hidden;background:" + text + ";}*,*::before,*::after{box-sizing:border-box;animation:none!important;transition:none!important;}#cpa-html-visual{width:100%;height:100%;overflow:hidden;}</style></head><body><div id=\"cpa-html-visual\">" + P_0.HtmlFragment + "</div></body></html>";
	}

	private static string ComputeSha256Hash(string P_0)
	{
		using SHA256 sHA = SHA256.Create();
		byte[] array = sHA.ComputeHash(Encoding.UTF8.GetBytes(P_0 ?? string.Empty));
		StringBuilder stringBuilder = new StringBuilder(array.Length * 2);
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			stringBuilder.Append(b.ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static void DeleteTempPng(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return;
		}
		try
		{
			if (File.Exists(P_0))
			{
				File.Delete(P_0);
			}
		}
		catch
		{
		}
	}

	public ScreenshotCaptureHelper3()
	{
		SseStreamInitializer.InitializeRuntime();
	}

	static ScreenshotCaptureHelper3()
	{
		SseStreamInitializer.InitializeRuntime();
		_renderSemaphore = new SemaphoreSlim(1, 1);
		_forbiddenTagRegex = new Regex("<\\\\s*(script|iframe|frame|frameset|object|embed|link|base|meta)\\\\b", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
		_eventHandlerRegex = new Regex("\\\\bon[a-z0-9_-]+\\\\s*=", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
		_urlSchemeRegex = new Regex("\\\\b(https?|file|ftp|javascript|vbscript)\\\\s*:", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
		_srcHrefRegex = new Regex("\\\\b(?:src|href|xlink:href)\\\\s*=\\\\s*(['\"])(?<value>.*?)\\\\1", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.CultureInvariant);
		_cssUrlRegex = new Regex("url\\\\s*\\\\(\\\\s*(['\"]?)(?<value>.*?)\\\\1\\\\s*\\\\)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
		_colorFormatRegex = new Regex("^(#[0-9a-f]{3}|#[0-9a-f]{6}|transparent)$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
	}
}
