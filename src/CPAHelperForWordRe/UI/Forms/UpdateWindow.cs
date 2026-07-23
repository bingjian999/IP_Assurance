using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using FileDownloadHelper2;
using HttpHelper_1;
using AiConfigBootstrap;
using AiSseStreamService3;
using SseStreamInitializer;
using HttpHelper_2;
using AiSseStreamService;
using AiSseStreamService4;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class UpdateWindow : Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass5_0
	{
		public UpdateWindow updateWindow;

		public HttpHelper_1 httpHelper_1;

		public bool SPMVYHHvWZj;

		public string UJeVYQhHWDY;

		public _G_c__DisplayClass5_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void OyMVYTEtbNt()
		{
			updateWindow.btnCheck.IsEnabled = false;
			updateWindow.lblRemoteVersion.Text = "正在获取...";
			updateWindow.lblRemoteDate.Text = string.Empty;
			updateWindow.txtDescription.Text = string.Empty;
			updateWindow.btnDownload.IsEnabled = false;
			updateWindow.progressBar.Visibility = Visibility.Collapsed;
			updateWindow.lblProgress.Visibility = Visibility.Collapsed;
		}

		internal void ruiVYgKkGZ0()
		{
			updateWindow.lblRemoteVersion.Text = "获取失败";
			updateWindow.txtDescription.Text = "无法连接更新服务器，请检查网络后重试。";
			updateWindow.btnCheck.IsEnabled = true;
		}

		internal void GiJVY8EBqPv()
		{
			updateWindow.lblRemoteVersion.Text = httpHelper_1.VersionText ?? "未知";
			updateWindow.lblRemoteDate.Text = httpHelper_1.ReleaseDate ?? string.Empty;
			updateWindow.txtDescription.Text = (SPMVYHHvWZj ? ("当前已是最新版本。" + Environment.NewLine + Environment.NewLine + UJeVYQhHWDY) : ("发现新版本！" + Environment.NewLine + Environment.NewLine + UJeVYQhHWDY));
			updateWindow.btnDownload.IsEnabled = SPMVYHHvWZj && !string.IsNullOrWhiteSpace(httpHelper_1.DownloadUrl);
			updateWindow.btnCheck.IsEnabled = true;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass8_0
	{
		public Exception exception;

		public UpdateWindow updateWindow;

		public _G_c__DisplayClass8_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void grbVY1pDLQ2()
		{
			MessageBox.Show(updateWindow, "下载失败：" + exception.Message, "检查更新", MessageBoxButton.OK, MessageBoxImage.Hand);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass9_0
	{
		public int? LgfVYUvkI8j;

		public UpdateWindow aswVYKYTrHV;

		public string KxYVYEvaSjj;

		public _G_c__DisplayClass9_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void MBKVY3YkeNX()
		{
			if (LgfVYUvkI8j.HasValue)
			{
				aswVYKYTrHV.progressBar.IsIndeterminate = false;
				aswVYKYTrHV.progressBar.Value = Math.Max(0, Math.Min(100, LgfVYUvkI8j.Value));
			}
			else
			{
				aswVYKYTrHV.progressBar.IsIndeterminate = true;
			}
			aswVYKYTrHV.lblProgress.Text = KxYVYEvaSjj;
		}
	}

	private HttpHelper_1 _httpHelper_1;

	private CancellationTokenSource _cancellationTokenSource;

	private bool _bool;

	internal TextBlock lblCurrentVersion;

	internal TextBlock lblRemoteVersion;

	internal TextBlock lblRemoteDate;

	internal TextBox txtDescription;

	internal TextBlock lblProgress;

	internal ProgressBar progressBar;

	internal Button btnCheck;

	internal Button btnDownload;

	internal CheckBox chkAutoUpdate;

	private bool _bool;

	public UpdateWindow()
	{
		SseStreamInitializer.InitializeRuntime();
		InitializeComponent();
		base.PreviewKeyDown += delegate(object P_0, KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape && !_bool)
			{
				Close();
			}
		};
		base.Loaded += jvrn0yOKXs;
	}

	private void jvrn0yOKXs(object P_0, RoutedEventArgs P_1)
	{
		lblCurrentVersion.Text = AiSseStreamService4.GetAssemblyVersion();
		lblRemoteVersion.Text = "正在获取...";
		lblRemoteDate.Text = "";
		txtDescription.Text = "";
		chkAutoUpdate.IsChecked = AiSseStreamService4.pS8Leo78tt();
		btnDownload.IsEnabled = false;
		hnYnkOQoh2();
	}

	private async void hnYnkOQoh2()
	{
		_G_c__DisplayClass5_0 CS_8_locals_30 = new _G_c__DisplayClass5_0();
		CS_8_locals_30.updateWindow = this;
		rhf7BnFSKl(delegate
		{
			CS_8_locals_30.updateWindow.btnCheck.IsEnabled = false;
			CS_8_locals_30.updateWindow.lblRemoteVersion.Text = "正在获取...";
			CS_8_locals_30.updateWindow.lblRemoteDate.Text = string.Empty;
			CS_8_locals_30.updateWindow.txtDescription.Text = string.Empty;
			CS_8_locals_30.updateWindow.btnDownload.IsEnabled = false;
			CS_8_locals_30.updateWindow.progressBar.Visibility = Visibility.Collapsed;
			CS_8_locals_30.updateWindow.lblProgress.Visibility = Visibility.Collapsed;
		});
		CS_8_locals_30.httpHelper_1 = await AiSseStreamService4.PJYL5bLAxq();
		_httpHelper_1 = CS_8_locals_30.httpHelper_1;
		if (CS_8_locals_30.httpHelper_1 == null)
		{
			rhf7BnFSKl(delegate
			{
				CS_8_locals_30.updateWindow.lblRemoteVersion.Text = "正在下载中，确定要取消吗？";
				CS_8_locals_30.updateWindow.txtDescription.Text = "检查更新";
				CS_8_locals_30.updateWindow.btnCheck.IsEnabled = true;
			});
			return;
		}
		CS_8_locals_30.UJeVYQhHWDY = MGO7uTfOsY(CS_8_locals_30.httpHelper_1.Description);
		CS_8_locals_30.SPMVYHHvWZj = AiSseStreamService4.DodLcdpfxo(AiSseStreamService4.GetAssemblyVersion(), CS_8_locals_30.httpHelper_1.VersionText);
		rhf7BnFSKl(delegate
		{
			CS_8_locals_30.updateWindow.lblRemoteVersion.Text = CS_8_locals_30.httpHelper_1.VersionText ?? ".exe";
			CS_8_locals_30.updateWindow.lblRemoteDate.Text = CS_8_locals_30.httpHelper_1.ReleaseDate ?? string.Empty;
			CS_8_locals_30.updateWindow.txtDescription.Text = (CS_8_locals_30.SPMVYHHvWZj ? (".msi" + Environment.NewLine + Environment.NewLine + CS_8_locals_30.UJeVYQhHWDY) : (".zip" + Environment.NewLine + Environment.NewLine + CS_8_locals_30.UJeVYQhHWDY));
			CS_8_locals_30.updateWindow.btnDownload.IsEnabled = CS_8_locals_30.SPMVYHHvWZj && !string.IsNullOrWhiteSpace(CS_8_locals_30.httpHelper_1.DownloadUrl);
			CS_8_locals_30.updateWindow.btnCheck.IsEnabled = true;
		});
	}

	private void eL2nxb8BFW(object P_0, RoutedEventArgs P_1)
	{
		if (!_bool)
		{
			hnYnkOQoh2();
		}
	}

	private async void e5Vnd8VSTM(object P_0, RoutedEventArgs P_1)
	{
		string text = _httpHelper_1?.DownloadUrl;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = " B";
		}
		if (ITV79sAVxO(text))
		{
			await Lk8nz8vy6g(text);
		}
		else
		{
			Asl7DMBu0n(text);
		}
	}

	private async Task Lk8nz8vy6g(string P_0)
	{
		_bool = true;
		rhf7BnFSKl(delegate
		{
			btnDownload.IsEnabled = false;
			btnCheck.IsEnabled = false;
			progressBar.Visibility = Visibility.Visible;
			progressBar.Value = 0.0;
			progressBar.IsIndeterminate = false;
			lblProgress.Visibility = Visibility.Visible;
			lblProgress.Text = "F1";
		});
		_cancellationTokenSource?.Dispose();
		_cancellationTokenSource = new CancellationTokenSource();
		CancellationToken token = _cancellationTokenSource.Token;
		string tempDir = AiSseStreamService.GetTempPath(" KB");
		string path = YDq7gFVLhY(P_0, null);
		string tempPath = Path.Combine(tempDir, path);
		try
		{
			if (!FileDownloadHelper2.IsHttpsUrl(P_0))
			{
				throw new InvalidOperationException("F1");
			}
			HttpHelper_2.BNmLxKn8Mc();
			HttpClientHandler handler = new HttpClientHandler
			{
				AllowAutoRedirect = true
			};
			try
			{
				HttpClient client = new HttpClient((HttpMessageHandler)(object)handler)
				{
					Timeout = TimeSpan.FromMinutes(10.0)
				};
				try
				{
					HttpResponseMessage response = await client.GetAsync(P_0, (HttpCompletionOption)1, token);
					try
					{
						response.EnsureSuccessStatusCode();
						HttpRequestMessage requestMessage = response.RequestMessage;
						Uri uri = ((requestMessage != null) ? requestMessage.RequestUri : null);
						if (uri == null || !string.Equals(uri.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
						{
							throw new InvalidOperationException(" MB");
						}
						path = YDq7gFVLhY(P_0, response);
						tempPath = Path.Combine(tempDir, path);
						string extension = Path.GetExtension(tempPath);
						if (!string.Equals(extension, "<br />", StringComparison.OrdinalIgnoreCase) && !string.Equals(extension, "<br/>", StringComparison.OrdinalIgnoreCase) && !string.Equals(extension, "<br>", StringComparison.OrdinalIgnoreCase))
						{
							throw new InvalidOperationException("\\\\r\\\\n");
						}
						long? total = response.Content.Headers.ContentLength;
						int lastPercent = -1;
						using Stream contentStream = await response.Content.ReadAsStreamAsync();
						using FileStream fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true);
						byte[] buffer = new byte[8192];
						long bytesRead = 0L;
						while (true)
						{
							int num;
							int read = (num = await contentStream.ReadAsync(buffer, 0, buffer.Length, token));
							if (num <= 0)
							{
								break;
							}
							token.ThrowIfCancellationRequested();
							await fileStream.WriteAsync(buffer, 0, read, token);
							bytesRead += read;
							if (total.HasValue && total.Value > 0)
							{
								int num2 = (int)(bytesRead * 100 / total.Value);
								if (num2 != lastPercent)
								{
									lastPercent = num2;
									djs7R66JV1(num2, PWH76kexHZ(bytesRead) + "\n" + PWH76kexHZ(total.Value));
								}
							}
							else
							{
								djs7R66JV1(null, "\\\\n" + PWH76kexHZ(bytesRead));
							}
						}
					}
					finally
					{
						((IDisposable)response)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)client)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)handler)?.Dispose();
			}
			djs7R66JV1(100, "\n");
			if (!File.Exists(tempPath) || new FileInfo(tempPath).Length == 0L)
			{
				FileDownloadHelper2.DeleteFileIfExists(tempPath);
				rhf7BnFSKl(delegate
				{
					MessageBox.Show(this, "\\\\r", "\n", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				});
			}
			else
			{
				djs7R66JV1(100, "\r\n");
				Glf7T2J9g2(tempPath);
			}
		}
		catch (OperationCanceledException)
		{
			FileDownloadHelper2.DeleteFileIfExists(tempPath);
			rhf7BnFSKl(delegate
			{
				lblProgress.Text = "\n";
			});
		}
		catch (Exception ex2)
		{
			_G_c__DisplayClass8_0 CS_8_locals_5 = new _G_c__DisplayClass8_0();
			CS_8_locals_5.updateWindow = this;
			Exception h0VVYrHuupw = ex2;
			CS_8_locals_5.exception = h0VVYrHuupw;
			FileDownloadHelper2.DeleteFileIfExists(tempPath);
			AiConfigBootstrap.LogError("explorer.exe", CS_8_locals_5.exception);
			rhf7BnFSKl(delegate
			{
				MessageBox.Show(CS_8_locals_5.updateWindow, "/select,\"" + CS_8_locals_5.exception.Message, "\"", MessageBoxButton.OK, MessageBoxImage.Hand);
			});
		}
		finally
		{
			_bool = false;
			rhf7BnFSKl(delegate
			{
				btnCheck.IsEnabled = true;
				btnDownload.IsEnabled = _httpHelper_1 != null && !string.IsNullOrWhiteSpace(_httpHelper_1.DownloadUrl) && AiSseStreamService4.DodLcdpfxo(AiSseStreamService4.GetAssemblyVersion(), _httpHelper_1.VersionText);
			});
		}
	}

	private void djs7R66JV1(int? P_0, string P_1)
	{
		_G_c__DisplayClass9_0 CS_8_locals_10 = new _G_c__DisplayClass9_0();
		CS_8_locals_10.LgfVYUvkI8j = P_0;
		CS_8_locals_10.aswVYKYTrHV = this;
		CS_8_locals_10.KxYVYEvaSjj = P_1;
		rhf7BnFSKl(delegate
		{
			if (CS_8_locals_10.LgfVYUvkI8j.HasValue)
			{
				CS_8_locals_10.aswVYKYTrHV.progressBar.IsIndeterminate = false;
				CS_8_locals_10.aswVYKYTrHV.progressBar.Value = Math.Max(0, Math.Min(100, CS_8_locals_10.LgfVYUvkI8j.Value));
			}
			else
			{
				CS_8_locals_10.aswVYKYTrHV.progressBar.IsIndeterminate = true;
			}
			CS_8_locals_10.aswVYKYTrHV.lblProgress.Text = CS_8_locals_10.KxYVYEvaSjj;
		});
	}

	private void wEu7VM60YP(object P_0, RoutedEventArgs P_1)
	{
		AiSseStreamService4.KkHLyG7lhV(chkAutoUpdate.IsChecked == true);
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		if (_bool)
		{
			if (MessageBox.Show(this, "正在下载中，确定要取消吗？", "检查更新", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
			{
				e.Cancel = true;
				return;
			}
			_cancellationTokenSource?.Cancel();
		}
		base.OnClosing(e);
	}

	private void rhf7BnFSKl(Action P_0)
	{
		if (P_0 != null)
		{
			if (!base.Dispatcher.CheckAccess())
			{
				base.Dispatcher.BeginInvoke(P_0);
			}
			else
			{
				P_0();
			}
		}
	}

	private static bool ITV79sAVxO(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		string path = P_0;
		if (Uri.TryCreate(P_0, UriKind.Absolute, out var result))
		{
			path = result.LocalPath;
		}
		string extension = Path.GetExtension(path);
		if (!string.Equals(extension, ".exe", StringComparison.OrdinalIgnoreCase) && !string.Equals(extension, ".msi", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(extension, ".zip", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static string PWH76kexHZ(long P_0)
	{
		if (P_0 < 1024)
		{
			return P_0 + " B";
		}
		if (P_0 < 1048576)
		{
			return ((double)P_0 / 1024.0).ToString("F1") + " KB";
		}
		return ((double)P_0 / 1048576.0).ToString("F1") + " MB";
	}

	private static string MGO7uTfOsY(string P_0)
	{
		string[] array = (P_0 ?? string.Empty).Replace("<br />", Environment.NewLine).Replace("<br/>", Environment.NewLine).Replace("<br>", Environment.NewLine)
			.Replace("\\\\r\\\\n", "\n")
			.Replace("\\\\n", "\n")
			.Replace("\\\\r", "\n")
			.Replace("\r\n", "\n")
			.Replace('\r', '\n')
			.Split(new char[1] { '\n' }, StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].TrimEnd();
		}
		return string.Join(Environment.NewLine, array).Trim();
	}

	private static void Asl7DMBu0n(string P_0)
	{
		Process.Start(new ProcessStartInfo
		{
			FileName = P_0,
			UseShellExecute = true
		});
	}

	private static void Glf7T2J9g2(string P_0)
	{
		string fullPath = Path.GetFullPath(P_0);
		Process.Start(new ProcessStartInfo
		{
			FileName = "explorer.exe",
			Arguments = "/select,\"" + fullPath + "\"",
			UseShellExecute = true
		});
	}

	private static string YDq7gFVLhY(string P_0, HttpResponseMessage P_1)
	{
		string text = null;
		object obj;
		if (P_1 == null)
		{
			obj = null;
		}
		else
		{
			HttpContent content = P_1.Content;
			if (content == null)
			{
				obj = null;
			}
			else
			{
				HttpContentHeaders headers = content.Headers;
				obj = ((headers != null) ? headers.ContentDisposition : null);
			}
		}
		ContentDispositionHeaderValue val = (ContentDispositionHeaderValue)obj;
		if (val != null)
		{
			text = val.FileNameStar;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = val.FileName;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				text = text.Trim('"', ' ');
			}
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			object obj2;
			if (P_1 == null)
			{
				obj2 = null;
			}
			else
			{
				HttpRequestMessage requestMessage = P_1.RequestMessage;
				obj2 = ((requestMessage != null) ? requestMessage.RequestUri : null);
			}
			Uri uri = (Uri)obj2;
			if (uri != null)
			{
				text = Path.GetFileName(uri.LocalPath);
			}
		}
		if (string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(P_0) && Uri.TryCreate(P_0, UriKind.Absolute, out var result))
		{
			text = Path.GetFileName(result.LocalPath);
		}
		text = Path.GetFileName(text);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return "download.bin";
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/updatewindow.xaml", UriKind.Relative);
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
			lblCurrentVersion = (TextBlock)target;
			break;
		case 2:
			lblRemoteVersion = (TextBlock)target;
			break;
		case 3:
			lblRemoteDate = (TextBlock)target;
			break;
		case 4:
			txtDescription = (TextBox)target;
			break;
		case 5:
			lblProgress = (TextBlock)target;
			break;
		case 6:
			progressBar = (ProgressBar)target;
			break;
		case 7:
			btnCheck = (Button)target;
			btnCheck.Click += eL2nxb8BFW;
			break;
		case 8:
			btnDownload = (Button)target;
			btnDownload.Click += e5Vnd8VSTM;
			break;
		case 9:
			chkAutoUpdate = (CheckBox)target;
			chkAutoUpdate.Checked += wEu7VM60YP;
			chkAutoUpdate.Unchecked += wEu7VM60YP;
			break;
		default:
			_bool = true;
			break;
		}
	}

	[CompilerGenerated]
	private void J9S78dIwYv(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape && !_bool)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void a7M7In6iaH()
	{
		btnDownload.IsEnabled = false;
		btnCheck.IsEnabled = false;
		progressBar.Visibility = Visibility.Visible;
		progressBar.Value = 0.0;
		progressBar.IsIndeterminate = false;
		lblProgress.Visibility = Visibility.Visible;
		lblProgress.Text = "正在连接...";
	}

	[CompilerGenerated]
	private void MCH7iPe82e()
	{
		MessageBox.Show(this, "下载的文件为空，请重试。", "下载失败", MessageBoxButton.OK, MessageBoxImage.Exclamation);
	}

	[CompilerGenerated]
	private void T5j7HVbehU()
	{
		lblProgress.Text = "下载已取消";
	}

	[CompilerGenerated]
	private void URg7Qvog35()
	{
		btnCheck.IsEnabled = true;
		btnDownload.IsEnabled = _httpHelper_1 != null && !string.IsNullOrWhiteSpace(_httpHelper_1.DownloadUrl) && AiSseStreamService4.DodLcdpfxo(AiSseStreamService4.GetAssemblyVersion(), _httpHelper_1.VersionText);
	}
}
