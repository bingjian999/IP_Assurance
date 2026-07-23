using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Helper_17;
using AiSseStreamService3;
using IntranetAiConfigService;
using SseStreamInitializer;

namespace CPAHelperForWordRe.UI.Forms.General;

public sealed class IntranetLoginWindow : Window, IComponentConnector
{
	internal TextBlock txtDescription;

	internal TextBox txtUsername;

	internal PasswordBox txtPassword;

	internal CheckBox chkAutoLogin;

	internal Button btnLogin;

	internal TextBlock txtStatus;

	private bool _bool;

	public IntranetLoginWindow(string rememberedUsername, string rememberedPassword, bool autoLoginEnabled, string description, string initialStatus)
	{
		SseStreamInitializer.InitializeRuntime();
		InitializeComponent();
		txtUsername.Text = rememberedUsername ?? string.Empty;
		txtPassword.Password = rememberedPassword ?? string.Empty;
		chkAutoLogin.IsChecked = autoLoginEnabled;
		txtDescription.Text = (string.IsNullOrWhiteSpace(description) ? "当前为内网环境，请登录后继续使用 AI 助手。" : description);
		if (!string.IsNullOrWhiteSpace(initialStatus))
		{
			SetStatus(initialStatus, Brushes.IndianRed);
		}
		base.Loaded += OnWindowLoaded;
		base.PreviewKeyDown += OnPreviewKeyDown;
	}

	private void OnWindowLoaded(object P_0, RoutedEventArgs P_1)
	{
		if (string.IsNullOrWhiteSpace(txtUsername.Text))
		{
			txtUsername.Focus();
		}
		else
		{
			txtPassword.Focus();
		}
	}

	private void OnPreviewKeyDown(object P_0, KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			base.DialogResult = false;
			Close();
		}
		else if (P_1.Key == Key.Return)
		{
			P_1.Handled = true;
			OnLoginButtonClick(this, new RoutedEventArgs());
		}
	}

	private async void OnLoginButtonClick(object P_0, RoutedEventArgs P_1)
	{
		SetLoginState( true, "登录", Brushes.DodgerBlue);
		try
		{
			Helper_17 loginResult = await IntranetAiConfigService.Instance.LoginAsync(txtUsername.Text, txtPassword.Password, chkAutoLogin.IsChecked == true).ConfigureAwait(continueOnCapturedContext: true);
			if (loginResult.Succeeded)
			{
				base.DialogResult = true;
				Close();
			}
			else
			{
				SetLoginState( false, string.IsNullOrWhiteSpace(loginResult.Message) ? "登录中..." : loginResult.Message, Brushes.IndianRed);
			}
		}
		catch (Exception ex)
		{
			SetLoginState( false, "/CPAHelperForWordRe;component/ui/forms/general/intranetloginwindow.xaml" + ex.Message, Brushes.IndianRed);
		}
	}

	private void SetLoginState(bool P_0, string P_1, Brush P_2)
	{
		btnLogin.IsEnabled = !P_0;
		txtUsername.IsEnabled = !P_0;
		txtPassword.IsEnabled = !P_0;
		chkAutoLogin.IsEnabled = !P_0;
		btnLogin.Content = (P_0 ? "登录" : "登录中...");
		SetStatus(P_1, P_2);
	}

	private void SetStatus(string P_0, Brush P_1)
	{
		txtStatus.Text = P_0 ?? string.Empty;
		txtStatus.Foreground = P_1 ?? Brushes.DimGray;
		txtStatus.Visibility = (string.IsNullOrWhiteSpace(P_0) ? Visibility.Collapsed : Visibility.Visible);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_bool)
		{
			_bool = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/general/intranetloginwindow.xaml", UriKind.Relative);
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
			txtDescription = (TextBlock)target;
			break;
		case 2:
			txtUsername = (TextBox)target;
			break;
		case 3:
			txtPassword = (PasswordBox)target;
			break;
		case 4:
			chkAutoLogin = (CheckBox)target;
			break;
		case 5:
			btnLogin = (Button)target;
			btnLogin.Click += OnLoginButtonClick;
			break;
		case 6:
			txtStatus = (TextBlock)target;
			break;
		default:
			_bool = true;
			break;
		}
	}
}
