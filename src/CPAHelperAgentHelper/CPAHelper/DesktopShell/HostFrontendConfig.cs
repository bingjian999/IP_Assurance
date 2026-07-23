using System;

namespace CPAHelper.Agent.DesktopShell;

public sealed class HostFrontendConfig
{
	public string HostKind { get; set; }

	public string WelcomeTitle { get; set; }

	public string WelcomeDescription { get; set; }

	public string[] QuickPrompts { get; set; } = Array.Empty<string>();

	public string[] Capabilities { get; set; } = Array.Empty<string>();

	public string Branding { get; set; }

	public string ThemePreset { get; set; }

	public string ThemeAccent { get; set; }

	public string ThemeAccentStrong { get; set; }

	public string ThemeAccentSoft { get; set; }

	public string InputBorderColor { get; set; }

	public string CardBorderColor { get; set; }

	public bool RuntimeStatusEnabled { get; set; }

	public int RuntimeStatusPollIntervalMs { get; set; } = 1000;
}
