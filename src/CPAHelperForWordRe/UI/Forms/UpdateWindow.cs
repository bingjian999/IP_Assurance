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

		public bool isUpdateAvailable;

		public string normalizedDescription;

		public _G_c__DisplayClass5_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void resetCheckUpdateUI()
		{
			updateWindow.btnCheck.IsEnabled = false;
			updateWindow.lblRemoteVersion.Text = "正在获取...";
			updateWindow.lblRemoteDate.Text = string.Empty;
			updateWindow.txtDescription.Text = string.Empty;
			updateWindow.btnDownload.IsEnabled = false;
			updateWindow.progressBar.Visibility = Visibility.Collapsed;
			updateWindow.lblProgress.Visibility = Visibility.Collapsed;
		}

		internal void showFetchFailedUI()
		{
			updateWindow.lblRemoteVersion.Text = "获取失败";
			updateWindow.txtDescription.Text = "无法连接更新服务器，请检查网络后重试。";
			updateWindow.btnCheck.IsEnabled = true;
		}

		internal void showVersionInfo()
		{
			updateWindow.lblRemoteVersion.Text = httpHelper_1.VersionText ?? "未知";
			updateWindow.lblRemoteDate.Text = httpHelper_1.ReleaseDate ?? string.Empty;
			updateWindow.txtDescription.Text = (isUpdateAvailable ? ("当前已是最新版本。" + Environment.NewLine + Environment.NewLine + normalizedDescription) : ("发现新版本！" + Environment.NewLine + Environment.NewLine + normalizedDescription));
			updateWindow.btnDownload.IsEnabled = isUpdateAvailable && !string.IsNullOrWhiteSpace(httpHelper_1.DownloadUrl);
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

		internal void showDownloadFailed()
		{
			MessageBox.Show(updateWindow, "下载失败：" + exception.Message, "检查更新", MessageBoxButton.OK, MessageBoxImage.Hand);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass9_0
	{
		public int? progressPercent;

		public UpdateWindow updateWindow;

		public string progressText;

		public _G_c__DisplayClass9_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void updateProgressBar()
		{
			if (progressPercent.HasValue)
			{
				updateWindow.progressBar.IsIndeterminate = false;
				updateWindow.progressBar.Value = Math.Max(0, Math.Min(100, progressPercent.Value));
			}
			else
			{
				updateWindow.progressBar.IsIndeterminate = true;
			}
			updateWindow.lblProgress.Text = progressText;
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
		base.Loaded += onWindowLoaded;
	}

	private void onWindowLoaded(object P_0, RoutedEventArgs P_1)
	{
		lblCurrentVersion.Text = AiSseStreamService4.GetAssemblyVersion();
		lblRemoteVersion.Text = "正在获取...";
		lblRemoteDate.Text = "";
		txtDescription.Text = "";
		chkAutoUpdate.IsChecked = AiSseStreamService4.isAutoUpdateEnabled();
		btnDownload.IsEnabled = false;
		checkForUpdates();
	}

	private async void checkForUpdates()
	{
		_G_c__DisplayClass5_0 CS_8_locals_30 = new _G_c__DisplayClass5_0();
		CS_8_locals_30.updateWindow = this;
		invokeOnUiThread(delegate
		{
			CS_8_locals_30.updateWindow.btnCheck.IsEnabled = false;
			CS_8_locals_30.updateWindow.lblRemoteVersion.Text = "正在获取...";
			CS_8_locals_30.updateWindow.lblRemoteDate.Text = string.Empty;
			CS_8_locals_30.updateWindow.txtDescription.Text = string.Empty;
			CS_8_locals_30.updateWindow.btnDownload.IsEnabled = false;
			CS_8_locals_30.updateWindow.progressBar.Visibility = Visibility.Collapsed;
			CS_8_locals_30.updateWindow.lblProgress.Visibility = Visibility.Collapsed;
		});
		CS_8_locals_30.httpHelper_1 = await AiSseStreamService4.fetchUpdateInfo();
		_httpHelper_1 = CS_8_locals_30.httpHelper_1;
		if (CS_8_locals_30.httpHelper_1 == null)
		{
			invokeOnUiThread(delegate
			{
				CS_8_locals_30.updateWindow.lblRemoteVersion.Text = "正在下载中，确定要取消吗？";
				CS_8_locals_30.updateWindow.txtDescription.Text = "检查更新";
				CS_8_locals_30.updateWindow.btnCheck.IsEnabled = true;
			});
			return;
		}
		CS_8_locals_30.normalizedDescription = normalizeDescriptionText(CS_8_locals_30.httpHelper_1.Description);
		CS_8_locals_30.isUpdateAvailable = AiSseStreamService4.isNewerVersion(AiSseStreamService4.GetAssemblyVersion(), CS_8_locals_30.httpHelper_1.VersionText);
		invokeOnUiThread(delegate
		{
			CS_8_locals_30.updateWindow.lblRemoteVersion.Text = CS_8_locals_30.httpHelper_1.VersionText ?? ".exe";
			CS_8_locals_30.updateWindow.lblRemoteDate.Text = CS_8_locals_30.httpHelper_1.ReleaseDate ?? string.Empty;
			CS_8_locals_30.updateWindow.txtDescription.Text = (CS_8_locals_30.isUpdateAvailable ? (".msi" + Environment.NewLine + Environment.NewLine + CS_8_locals_30.normalizedDescription) : (".zip" + Environment.NewLine + Environment.NewLine + CS_8_locals_30.normalizedDescription));
			CS_8_locals_30.updateWindow.btnDownload.IsEnabled = CS_8_locals_30.isUpdateAvailable && !string.IsNullOrWhiteSpace(CS_8_locals_30.httpHelper_1.DownloadUrl);
			CS_8_locals_30.updateWindow.btnCheck.IsEnabled = true;
		});
	}

	private void onBtnCheckClick(object P_0, RoutedEventArgs P_1)
	{
		if (!_bool)
		{
			checkForUpdates();
		}
	}

	private async void onBtnDownloadClick(object P_0, RoutedEventArgs P_1)
	{
		string text = _httpHelper_1?.DownloadUrl;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = " B";
		}
		if (isExecutableExtension(text))
		{
			await downloadFileAsync(text);
		}
		else
		{
			openInShell(text);
		}
	}

	private async Task downloadFileAsync(string P_0)
	{
		_bool = true;
		invokeOnUiThread(delegate
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
		string path = extractFileName(P_0, null);
		string tempPath = Path.Combine(tempDir, path);
		try
		{
			if (!FileDownloadHelper2.IsHttpsUrl(P_0))
			{
				throw new InvalidOperationException("F1");
			}
			HttpHelper_2.initializeHttpClient();
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
						path = extractFileName(P_0, response);
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
									reportDownloadProgress(num2, formatFileSize(bytesRead) + "\n" + formatFileSize(total.Value));
								}
							}
							else
							{
								reportDownloadProgress(null, "\\\\n" + formatFileSize(bytesRead));
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
			reportDownloadProgress(100, "\n");
			if (!File.Exists(tempPath) || new FileInfo(tempPath).Length == 0L)
			{
				FileDownloadHelper2.DeleteFileIfExists(tempPath);
				invokeOnUiThread(delegate
				{
					MessageBox.Show(this, "\\\\r", "\n", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				});
			}
			else
			{
				reportDownloadProgress(100, "\r\n");
				revealInExplorer(tempPath);
			}
		}
		catch (OperationCanceledException)
		{
			FileDownloadHelper2.DeleteFileIfExists(tempPath);
			invokeOnUiThread(delegate
			{
				lblProgress.Text = "\n";
			});
		}
		catch (Exception ex2)
		{
			_G_c__DisplayClass8_0 CS_8_locals_5 = new _G_c__DisplayClass8_0();
			CS_8_locals_5.updateWindow = this;
			Exception caughtException = ex2;
			CS_8_locals_5.exception = caughtException;
			FileDownloadHelper2.DeleteFileIfExists(tempPath);
			AiConfigBootstrap.LogError("explorer.exe", CS_8_locals_5.exception);
			invokeOnUiThread(delegate
			{
				MessageBox.Show(CS_8_locals_5.updateWindow, "/select,\"" + CS_8_locals_5.exception.Message, "\"", MessageBoxButton.OK, MessageBoxImage.Hand);
			});
		}
		finally
		{
			_bool = false;
			invokeOnUiThread(delegate
			{
				btnCheck.IsEnabled = true;
				btnDownload.IsEnabled = _httpHelper_1 != null && !string.IsNullOrWhiteSpace(_httpHelper_1.DownloadUrl) && AiSseStreamService4.isNewerVersion(AiSseStreamService4.GetAssemblyVersion(), _httpHelper_1.VersionText);
			});
		}
	}

	private void reportDownloadProgress(int? P_0, string P_1)
	{
		_G_c__DisplayClass9_0 CS_8_locals_10 = new _G_c__DisplayClass9_0();
		CS_8_locals_10.progressPercent = P_0;
		CS_8_locals_10.updateWindow = this;
		CS_8_locals_10.progressText = P_1;
		invokeOnUiThread(delegate
		{
			if (CS_8_locals_10.progressPercent.HasValue)
			{
				CS_8_locals_10.updateWindow.progressBar.IsIndeterminate = false;
				CS_8_locals_10.updateWindow.progressBar.Value = Math.Max(0, Math.Min(100, CS_8_locals_10.progressPercent.Value));
			}
			else
			{
				CS_8_locals_10.updateWindow.progressBar.IsIndeterminate = true;
			}
			CS_8_locals_10.updateWindow.lblProgress.Text = CS_8_locals_10.progressText;
		});
	}

	private void onAutoUpdateChecked(object P_0, RoutedEventArgs P_1)
	{
		AiSseStreamService4.setAutoUpdateEnabled(chkAutoUpdate.IsChecked == true);
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

	private void invokeOnUiThread(Action P_0)
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

	private static bool isExecutableExtension(string P_0)
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

	private static string formatFileSize(long P_0)
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

	private static string normalizeDescriptionText(string P_0)
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

	private static void openInShell(string P_0)
	{
		Process.Start(new ProcessStartInfo
		{
			FileName = P_0,
			UseShellExecute = true
		});
	}

	private static void revealInExplorer(string P_0)
	{
		string fullPath = Path.GetFullPath(P_0);
		Process.Start(new ProcessStartInfo
		{
			FileName = "explorer.exe",
			Arguments = "/select,\"" + fullPath + "\"",
			UseShellExecute = true
		});
	}

	private static string extractFileName(string P_0, HttpResponseMessage P_1)
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
			btnCheck.Click += onBtnCheckClick;
			break;
		case 8:
			btnDownload = (Button)target;
			btnDownload.Click += onBtnDownloadClick;
			break;
		case 9:
			chkAutoUpdate = (CheckBox)target;
			chkAutoUpdate.Checked += onAutoUpdateChecked;
			chkAutoUpdate.Unchecked += onAutoUpdateChecked;
			break;
		default:
			_bool = true;
			break;
		}
	}

	[CompilerGenerated]
	private void onPreviewKeyDown(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape && !_bool)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void beginDownloadUI()
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
	private void showEmptyFileError()
	{
		MessageBox.Show(this, "下载的文件为空，请重试。", "下载失败", MessageBoxButton.OK, MessageBoxImage.Exclamation);
	}

	[CompilerGenerated]
	private void showDownloadCancelled()
	{
		lblProgress.Text = "下载已取消";
	}

	[CompilerGenerated]
	private void restoreButtonStates()
	{
		btnCheck.IsEnabled = true;
		btnDownload.IsEnabled = _httpHelper_1 != null && !string.IsNullOrWhiteSpace(_httpHelper_1.DownloadUrl) && AiSseStreamService4.isNewerVersion(AiSseStreamService4.GetAssemblyVersion(), _httpHelper_1.VersionText);
	}
}
