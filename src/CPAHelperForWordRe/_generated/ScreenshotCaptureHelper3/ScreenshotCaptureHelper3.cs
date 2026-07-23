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
		public Form xOadtJIvHV;

		public Helper_16 QH5dLJJKUU;

		public string vEydsAdH7C;

		public string O96dl7ylv6;

		public string ak5dNExhHw;

		public ImageAssetInfo umNdmxJMDT;

		public string e4BdoEk6pu;

		public Exception mSCdGE1K6J;

		public _G_c__DisplayClass14_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void w03dw18Z2c()
		{
			try
			{
				_G_c__DisplayClass14_1 CS_8_locals_42 = new _G_c__DisplayClass14_1();
				CS_8_locals_42.Am8dnU3Kek = this;
				CS_8_locals_42.fYAdpk6kMZ = new Form();
				try
				{
					CS_8_locals_42.JsPdOuZl9d = new WebView2();
					try
					{
						xOadtJIvHV = CS_8_locals_42.fYAdpk6kMZ;
						CS_8_locals_42.fYAdpk6kMZ.FormBorderStyle = FormBorderStyle.None;
						CS_8_locals_42.fYAdpk6kMZ.StartPosition = FormStartPosition.Manual;
						CS_8_locals_42.fYAdpk6kMZ.Location = new Point(-32000, -32000);
						CS_8_locals_42.fYAdpk6kMZ.ClientSize = new Size(QH5dLJJKUU.PixelWidth, QH5dLJJKUU.PixelHeight);
						CS_8_locals_42.fYAdpk6kMZ.ShowInTaskbar = false;
						CS_8_locals_42.fYAdpk6kMZ.Text = "IP_Assurance HTML Visual Renderer";
						CS_8_locals_42.JsPdOuZl9d.Dock = DockStyle.Fill;
						CS_8_locals_42.JsPdOuZl9d.CreationProperties = new CoreWebView2CreationProperties
						{
							UserDataFolder = AiSseStreamService.mSfs9VWIdb("WebView2", "HtmlVisualRenderer", Process.GetCurrentProcess().Id.ToString())
						};
						CS_8_locals_42.fYAdpk6kMZ.Controls.Add(CS_8_locals_42.JsPdOuZl9d);
						CS_8_locals_42.fYAdpk6kMZ.Shown += async delegate
						{
							try
							{
								await usK1uGbyeh(CS_8_locals_42.JsPdOuZl9d, CS_8_locals_42.Am8dnU3Kek.vEydsAdH7C, CS_8_locals_42.Am8dnU3Kek.O96dl7ylv6, CS_8_locals_42.Am8dnU3Kek.QH5dLJJKUU.PixelWidth, CS_8_locals_42.Am8dnU3Kek.QH5dLJJKUU.PixelHeight).ConfigureAwait(continueOnCapturedContext: true);
								pqB1TXqQGQ(CS_8_locals_42.Am8dnU3Kek.O96dl7ylv6, CS_8_locals_42.Am8dnU3Kek.QH5dLJJKUU.PixelWidth, CS_8_locals_42.Am8dnU3Kek.QH5dLJJKUU.PixelHeight);
								FileInfo fileInfo = new FileInfo(CS_8_locals_42.Am8dnU3Kek.O96dl7ylv6);
								if (!fileInfo.Exists || fileInfo.Length == 0L)
								{
									throw new InvalidOperationException("Word document preview prepared.");
								}
								int width;
								int height;
								using (Image image = Image.FromFile(CS_8_locals_42.Am8dnU3Kek.O96dl7ylv6))
								{
									width = image.Width;
									height = image.Height;
								}
								if (Math.Abs(width - CS_8_locals_42.Am8dnU3Kek.QH5dLJJKUU.PixelWidth) > 2 || Math.Abs(height - CS_8_locals_42.Am8dnU3Kek.QH5dLJJKUU.PixelHeight) > 2)
								{
									throw new InvalidOperationException(string.Format("IP_Assurance HTML Visual Renderer", CS_8_locals_42.Am8dnU3Kek.QH5dLJJKUU.PixelWidth, CS_8_locals_42.Am8dnU3Kek.QH5dLJJKUU.PixelHeight, width, height));
								}
								File.WriteAllText(CS_8_locals_42.Am8dnU3Kek.ak5dNExhHw, CS_8_locals_42.Am8dnU3Kek.vEydsAdH7C, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
								CS_8_locals_42.Am8dnU3Kek.umNdmxJMDT = new ImageAssetInfo
								{
									PngPath = CS_8_locals_42.Am8dnU3Kek.O96dl7ylv6,
									SourcePath = CS_8_locals_42.Am8dnU3Kek.ak5dNExhHw,
									SourceHash = CS_8_locals_42.Am8dnU3Kek.e4BdoEk6pu,
									PixelWidth = width,
									PixelHeight = height,
									PngBytes = fileInfo.Length
								};
							}
							catch (Exception ex2)
							{
								CS_8_locals_42.Am8dnU3Kek.mSCdGE1K6J = ex2;
							}
							finally
							{
								CS_8_locals_42.fYAdpk6kMZ.Close();
							}
						};
						Application.Run(CS_8_locals_42.fYAdpk6kMZ);
					}
					finally
					{
						if (CS_8_locals_42.JsPdOuZl9d != null)
						{
							((IDisposable)CS_8_locals_42.JsPdOuZl9d).Dispose();
						}
					}
				}
				finally
				{
					if (CS_8_locals_42.fYAdpk6kMZ != null)
					{
						((IDisposable)CS_8_locals_42.fYAdpk6kMZ).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				mSCdGE1K6J = ex;
			}
			finally
			{
				xOadtJIvHV = null;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass14_1
	{
		public Form fYAdpk6kMZ;

		public WebView2 JsPdOuZl9d;

		public _G_c__DisplayClass14_0 Am8dnU3Kek;

		public _G_c__DisplayClass14_1()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal async void ry4dCGg4Z6(object sender, EventArgs args)
		{
			try
			{
				await usK1uGbyeh(JsPdOuZl9d, Am8dnU3Kek.vEydsAdH7C, Am8dnU3Kek.O96dl7ylv6, Am8dnU3Kek.QH5dLJJKUU.PixelWidth, Am8dnU3Kek.QH5dLJJKUU.PixelHeight).ConfigureAwait(continueOnCapturedContext: true);
				pqB1TXqQGQ(Am8dnU3Kek.O96dl7ylv6, Am8dnU3Kek.QH5dLJJKUU.PixelWidth, Am8dnU3Kek.QH5dLJJKUU.PixelHeight);
				FileInfo fileInfo = new FileInfo(Am8dnU3Kek.O96dl7ylv6);
				if (!fileInfo.Exists || fileInfo.Length == 0L)
				{
					throw new InvalidOperationException("WebView2 did not produce a PNG image.");
				}
				int width;
				int height;
				using (Image image = Image.FromFile(Am8dnU3Kek.O96dl7ylv6))
				{
					width = image.Width;
					height = image.Height;
				}
				if (Math.Abs(width - Am8dnU3Kek.QH5dLJJKUU.PixelWidth) > 2 || Math.Abs(height - Am8dnU3Kek.QH5dLJJKUU.PixelHeight) > 2)
				{
					throw new InvalidOperationException(string.Format("Rendered PNG size mismatch. Expected {0}x{1}, actual {2}x{3}.", Am8dnU3Kek.QH5dLJJKUU.PixelWidth, Am8dnU3Kek.QH5dLJJKUU.PixelHeight, width, height));
				}
				File.WriteAllText(Am8dnU3Kek.ak5dNExhHw, Am8dnU3Kek.vEydsAdH7C, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
				Am8dnU3Kek.umNdmxJMDT = new ImageAssetInfo
				{
					PngPath = Am8dnU3Kek.O96dl7ylv6,
					SourcePath = Am8dnU3Kek.ak5dNExhHw,
					SourceHash = Am8dnU3Kek.e4BdoEk6pu,
					PixelWidth = width,
					PixelHeight = height,
					PngBytes = fileInfo.Length
				};
			}
			catch (Exception mSCdGE1K6J)
			{
				Am8dnU3Kek.mSCdGE1K6J = mSCdGE1K6J;
			}
			finally
			{
				fYAdpk6kMZ.Close();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass15_0
	{
		public CoreWebView2 JbLd5JvlJj;

		public EventHandler<CoreWebView2NavigationCompletedEventArgs> zBZdc5AXK9;

		public TaskCompletionSource<CoreWebView2NavigationCompletedEventArgs> XuOde93ZeH;

		public _G_c__DisplayClass15_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void LOXd74s6Kf(object sender, CoreWebView2NavigationCompletedEventArgs args)
		{
			JbLd5JvlJj.NavigationCompleted -= zBZdc5AXK9;
			XuOde93ZeH.TrySetResult(args);
		}
	}

	private static readonly SemaphoreSlim DjW1H937bG;

	private static readonly Regex MBr1QWZKDB;

	private static readonly Regex NCJ11K8E2o;

	private static readonly Regex Awv1rBgWBN;

	private static readonly Regex pya1JouFCr;

	private static readonly Regex jvb13lCcaS;

	private static readonly Regex ulT1Ux7OkM;

	public ImageAssetInfo vl619tBFs5(Helper_16 P_0)
	{
		eBW1ghIdqq(P_0);
		DjW1H937bG.Wait();
		try
		{
			return H6916YM8wK(P_0);
		}
		finally
		{
			DjW1H937bG.Release();
		}
	}

	private static ImageAssetInfo H6916YM8wK(Helper_16 P_0)
	{
		_G_c__DisplayClass14_0 CS_8_locals_47 = new _G_c__DisplayClass14_0();
		CS_8_locals_47.QH5dLJJKUU = P_0;
		CS_8_locals_47.e4BdoEk6pu = ofk1IFrjhT(CS_8_locals_47.QH5dLJJKUU.HtmlFragment);
		CS_8_locals_47.vEydsAdH7C = UNc18HvUui(CS_8_locals_47.QH5dLJJKUU);
		string path = AiSseStreamService.XOes64flqb("AI", "HtmlVisuals");
		string path2 = AiSseStreamService.mSfs9VWIdb("Agent", "html-visuals");
		CS_8_locals_47.O96dl7ylv6 = Path.Combine(path, "html-visual-" + Guid.NewGuid().ToString("N") + ".png");
		CS_8_locals_47.ak5dNExhHw = Path.Combine(path2, CS_8_locals_47.e4BdoEk6pu + ".html");
		CS_8_locals_47.mSCdGE1K6J = null;
		CS_8_locals_47.umNdmxJMDT = null;
		CS_8_locals_47.xOadtJIvHV = null;
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				_G_c__DisplayClass14_1 CS_8_locals_69 = new _G_c__DisplayClass14_1();
				CS_8_locals_69.Am8dnU3Kek = CS_8_locals_47;
				CS_8_locals_69.fYAdpk6kMZ = new Form();
				try
				{
					CS_8_locals_69.JsPdOuZl9d = new WebView2();
					try
					{
						CS_8_locals_47.xOadtJIvHV = CS_8_locals_69.fYAdpk6kMZ;
						CS_8_locals_69.fYAdpk6kMZ.FormBorderStyle = FormBorderStyle.None;
						CS_8_locals_69.fYAdpk6kMZ.StartPosition = FormStartPosition.Manual;
						CS_8_locals_69.fYAdpk6kMZ.Location = new Point(-32000, -32000);
						CS_8_locals_69.fYAdpk6kMZ.ClientSize = new Size(CS_8_locals_47.QH5dLJJKUU.PixelWidth, CS_8_locals_47.QH5dLJJKUU.PixelHeight);
						CS_8_locals_69.fYAdpk6kMZ.ShowInTaskbar = false;
						CS_8_locals_69.fYAdpk6kMZ.Text = "CPAHelper.HtmlVisualRenderer";
						CS_8_locals_69.JsPdOuZl9d.Dock = DockStyle.Fill;
						CS_8_locals_69.JsPdOuZl9d.CreationProperties = new CoreWebView2CreationProperties
						{
							UserDataFolder = AiSseStreamService.mSfs9VWIdb("HTML visual rendering timed out after 30 seconds.", "HTML visual rendering failed: ", Process.GetCurrentProcess().Id.ToString())
						};
						CS_8_locals_69.fYAdpk6kMZ.Controls.Add(CS_8_locals_69.JsPdOuZl9d);
						CS_8_locals_69.fYAdpk6kMZ.Shown += async delegate
						{
							try
							{
								await usK1uGbyeh(CS_8_locals_69.JsPdOuZl9d, CS_8_locals_69.Am8dnU3Kek.vEydsAdH7C, CS_8_locals_69.Am8dnU3Kek.O96dl7ylv6, CS_8_locals_69.Am8dnU3Kek.QH5dLJJKUU.PixelWidth, CS_8_locals_69.Am8dnU3Kek.QH5dLJJKUU.PixelHeight).ConfigureAwait(continueOnCapturedContext: true);
								pqB1TXqQGQ(CS_8_locals_69.Am8dnU3Kek.O96dl7ylv6, CS_8_locals_69.Am8dnU3Kek.QH5dLJJKUU.PixelWidth, CS_8_locals_69.Am8dnU3Kek.QH5dLJJKUU.PixelHeight);
								FileInfo fileInfo = new FileInfo(CS_8_locals_69.Am8dnU3Kek.O96dl7ylv6);
								if (!fileInfo.Exists || fileInfo.Length == 0L)
								{
									throw new InvalidOperationException("HTML visual rendering completed without a result.");
								}
								int width;
								int height;
								using (Image image = Image.FromFile(CS_8_locals_69.Am8dnU3Kek.O96dl7ylv6))
								{
									width = image.Width;
									height = image.Height;
								}
								if (Math.Abs(width - CS_8_locals_69.Am8dnU3Kek.QH5dLJJKUU.PixelWidth) > 2 || Math.Abs(height - CS_8_locals_69.Am8dnU3Kek.QH5dLJJKUU.PixelHeight) > 2)
								{
									throw new InvalidOperationException(string.Format("AI", CS_8_locals_69.Am8dnU3Kek.QH5dLJJKUU.PixelWidth, CS_8_locals_69.Am8dnU3Kek.QH5dLJJKUU.PixelHeight, width, height));
								}
								File.WriteAllText(CS_8_locals_69.Am8dnU3Kek.ak5dNExhHw, CS_8_locals_69.Am8dnU3Kek.vEydsAdH7C, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
								CS_8_locals_69.Am8dnU3Kek.umNdmxJMDT = new ImageAssetInfo
								{
									PngPath = CS_8_locals_69.Am8dnU3Kek.O96dl7ylv6,
									SourcePath = CS_8_locals_69.Am8dnU3Kek.ak5dNExhHw,
									SourceHash = CS_8_locals_69.Am8dnU3Kek.e4BdoEk6pu,
									PixelWidth = width,
									PixelHeight = height,
									PngBytes = fileInfo.Length
								};
							}
							catch (Exception mSCdGE1K6J2)
							{
								CS_8_locals_69.Am8dnU3Kek.mSCdGE1K6J = mSCdGE1K6J2;
							}
							finally
							{
								CS_8_locals_69.fYAdpk6kMZ.Close();
							}
						};
						Application.Run(CS_8_locals_69.fYAdpk6kMZ);
					}
					finally
					{
						if (CS_8_locals_69.JsPdOuZl9d != null)
						{
							((IDisposable)CS_8_locals_69.JsPdOuZl9d).Dispose();
						}
					}
				}
				finally
				{
					if (CS_8_locals_69.fYAdpk6kMZ != null)
					{
						((IDisposable)CS_8_locals_69.fYAdpk6kMZ).Dispose();
					}
				}
			}
			catch (Exception mSCdGE1K6J)
			{
				CS_8_locals_47.mSCdGE1K6J = mSCdGE1K6J;
			}
			finally
			{
				CS_8_locals_47.xOadtJIvHV = null;
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
				Form form = CS_8_locals_47.xOadtJIvHV;
				if (form != null && form.IsHandleCreated && !form.IsDisposed)
				{
					form.BeginInvoke(new Action(form.Close));
				}
			}
			catch
			{
			}
			thread.Join(2000);
			BmE1iWh1tY(CS_8_locals_47.O96dl7ylv6);
			throw new TimeoutException("Agent");
		}
		if (CS_8_locals_47.mSCdGE1K6J != null)
		{
			BmE1iWh1tY(CS_8_locals_47.O96dl7ylv6);
			throw new InvalidOperationException("html-visuals" + CS_8_locals_47.mSCdGE1K6J.Message, CS_8_locals_47.mSCdGE1K6J);
		}
		if (CS_8_locals_47.umNdmxJMDT == null)
		{
			BmE1iWh1tY(CS_8_locals_47.O96dl7ylv6);
			throw new InvalidOperationException("html-visual-");
		}
		return CS_8_locals_47.umNdmxJMDT;
	}

	private static async Task usK1uGbyeh(WebView2 P_0, string P_1, string P_2, int P_3, int P_4)
	{
		_G_c__DisplayClass15_0 CS_8_locals_21 = new _G_c__DisplayClass15_0();
		await P_0.EnsureCoreWebView2Async();
		CS_8_locals_21.JbLd5JvlJj = P_0.CoreWebView2;
		CS_8_locals_21.JbLd5JvlJj.Settings.IsScriptEnabled = false;
		CS_8_locals_21.JbLd5JvlJj.Settings.IsWebMessageEnabled = false;
		CS_8_locals_21.JbLd5JvlJj.Settings.AreDefaultContextMenusEnabled = false;
		CS_8_locals_21.JbLd5JvlJj.Settings.AreDefaultScriptDialogsEnabled = false;
		CS_8_locals_21.JbLd5JvlJj.Settings.AreDevToolsEnabled = false;
		CS_8_locals_21.JbLd5JvlJj.Settings.IsStatusBarEnabled = false;
		CS_8_locals_21.JbLd5JvlJj.Settings.IsZoomControlEnabled = false;
		CS_8_locals_21.JbLd5JvlJj.NavigationStarting += delegate(object sender, CoreWebView2NavigationStartingEventArgs args)
		{
			if (!string.Equals(args.Uri, "N", StringComparison.OrdinalIgnoreCase) && (string.IsNullOrWhiteSpace(args.Uri) || !args.Uri.StartsWith(".png", StringComparison.OrdinalIgnoreCase)))
			{
				args.Cancel = true;
			}
		};
		CS_8_locals_21.XuOde93ZeH = new TaskCompletionSource<CoreWebView2NavigationCompletedEventArgs>();
		CS_8_locals_21.zBZdc5AXK9 = null;
		CS_8_locals_21.zBZdc5AXK9 = delegate(object sender, CoreWebView2NavigationCompletedEventArgs args)
		{
			CS_8_locals_21.JbLd5JvlJj.NavigationCompleted -= CS_8_locals_21.zBZdc5AXK9;
			CS_8_locals_21.XuOde93ZeH.TrySetResult(args);
		};
		CS_8_locals_21.JbLd5JvlJj.NavigationCompleted += CS_8_locals_21.zBZdc5AXK9;
		CS_8_locals_21.JbLd5JvlJj.NavigateToString(P_1);
		CoreWebView2NavigationCompletedEventArgs e = await CS_8_locals_21.XuOde93ZeH.Task.ConfigureAwait(continueOnCapturedContext: true);
		if (!e.IsSuccess)
		{
			throw new InvalidOperationException(".html" + e.WebErrorStatus);
		}
		await Task.Delay(350).ConfigureAwait(continueOnCapturedContext: true);
		await V9S1Drrpqv(P_0, CS_8_locals_21.JbLd5JvlJj, P_3, P_4).ConfigureAwait(continueOnCapturedContext: true);
		using FileStream stream = new FileStream(P_2, FileMode.Create, FileAccess.Write, FileShare.Read);
		await CS_8_locals_21.JbLd5JvlJj.CapturePreviewAsync(CoreWebView2CapturePreviewImageFormat.Png, stream).ConfigureAwait(continueOnCapturedContext: true);
		await stream.FlushAsync().ConfigureAwait(continueOnCapturedContext: true);
	}

	private static async Task V9S1Drrpqv(WebView2 P_0, CoreWebView2 P_1, int P_2, int P_3)
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

	private static void pqB1TXqQGQ(string P_0, int P_1, int P_2)
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
			BmE1iWh1tY(text);
		}
	}

	private static void eBW1ghIdqq(Helper_16 P_0)
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
		if (!ulT1Ux7OkM.IsMatch(input))
		{
			throw new ArgumentException("backgroundColor must be #RGB, #RRGGBB, or transparent.", "BackgroundColor");
		}
		string htmlFragment = P_0.HtmlFragment;
		if (MBr1QWZKDB.IsMatch(htmlFragment))
		{
			throw new ArgumentException("HTML contains a forbidden active or embedding tag.", "HtmlFragment");
		}
		if (NCJ11K8E2o.IsMatch(htmlFragment))
		{
			throw new ArgumentException("HTML event handler attributes such as onclick are not allowed.", "HtmlFragment");
		}
		if (Awv1rBgWBN.IsMatch(htmlFragment) || Regex.IsMatch(htmlFragment, "@import\\\\b", RegexOptions.IgnoreCase))
		{
			throw new ArgumentException("External URLs, active URL schemes, and CSS @import are not allowed.", "HtmlFragment");
		}
		foreach (Match item in pya1JouFCr.Matches(htmlFragment))
		{
			string text = item.Groups["value"].Value.Trim();
			if (!text.StartsWith("data:", StringComparison.OrdinalIgnoreCase) && !text.StartsWith("#", StringComparison.Ordinal))
			{
				throw new ArgumentException("src/href resources must use data: URLs or local SVG fragment references.", "HtmlFragment");
			}
		}
		foreach (Match item2 in jvb13lCcaS.Matches(htmlFragment))
		{
			if (!item2.Groups["value"].Value.Trim().Trim('\'', '"').StartsWith("data:", StringComparison.OrdinalIgnoreCase))
			{
				throw new ArgumentException("CSS url() resources must use data: URLs.", "HtmlFragment");
			}
		}
	}

	private static string UNc18HvUui(Helper_16 P_0)
	{
		string text = (string.IsNullOrWhiteSpace(P_0.BackgroundColor) ? "#ffffff" : P_0.BackgroundColor.Trim());
		return "<!doctype html><html><head><meta charset=\"utf-8\"><meta http-equiv=\"Content-Security-Policy\" content=\"default-src 'none'; img-src data:; style-src 'unsafe-inline'; font-src data:; script-src 'none'; connect-src 'none'; object-src 'none'; frame-src 'none';\"><style>html,body{margin:0;padding:0;width:100%;height:100%;overflow:hidden;background:" + text + ";}*,*::before,*::after{box-sizing:border-box;animation:none!important;transition:none!important;}#cpa-html-visual{width:100%;height:100%;overflow:hidden;}</style></head><body><div id=\"cpa-html-visual\">" + P_0.HtmlFragment + "</div></body></html>";
	}

	private static string ofk1IFrjhT(string P_0)
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

	public static void BmE1iWh1tY(string P_0)
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
		SseStreamInitializer.AlBVL0oCCKQ();
	}

	static ScreenshotCaptureHelper3()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		DjW1H937bG = new SemaphoreSlim(1, 1);
		MBr1QWZKDB = new Regex("<\\\\s*(script|iframe|frame|frameset|object|embed|link|base|meta)\\\\b", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
		NCJ11K8E2o = new Regex("\\\\bon[a-z0-9_-]+\\\\s*=", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
		Awv1rBgWBN = new Regex("\\\\b(https?|file|ftp|javascript|vbscript)\\\\s*:", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
		pya1JouFCr = new Regex("\\\\b(?:src|href|xlink:href)\\\\s*=\\\\s*(['\"])(?<value>.*?)\\\\1", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.CultureInvariant);
		jvb13lCcaS = new Regex("url\\\\s*\\\\(\\\\s*(['\"]?)(?<value>.*?)\\\\1\\\\s*\\\\)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
		ulT1Ux7OkM = new Regex("^(#[0-9a-f]{3}|#[0-9a-f]{6}|transparent)$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
	}
}
