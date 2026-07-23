using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AiSseStreamService3;
using Microsoft.Win32;
using SseStreamInitializer;

namespace AiSseStreamService;

internal static class AiSseStreamService
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass31_0
	{
		public string WtuVEqLgtlj;

		public _G_c__DisplayClass31_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool MatchesPath(string existing)
		{
			return string.Equals(existing, WtuVEqLgtlj, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static readonly Lazy<string[]> _installPathCandidates;

	private static readonly Lazy<string> _installPath;

	public static string InstallPath => _installPath.Value;

	public static IReadOnlyList<string> InstallPathCandidates => _installPathCandidates.Value;

	public static string UserDataDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "IP_Assurance");

	public static string ConfigDir => Path.Combine(UserDataDir, "config");

	public static string MainConfigFilePath => Path.Combine(ConfigDir, "settings.json");

	public static string LegacyConfigFilePath => Path.Combine(ConfigDir, "config.json");

	public static string TemplateDir => Path.Combine(UserDataDir, "templates");

	public static string LogDir => Path.Combine(UserDataDir, "Logs");

	public static string UserTempDir => Path.Combine(UserDataDir, "Temp");

	public static string RibbonIconAssetsDir => Path.Combine(InstallPath, "Assets", "RibbonIcons");

	public static string FrontendAssetsDir => Path.Combine(InstallPath, "Assets", "FrontendAssets");

	public static void InitializeDirectories()
	{
		MigrateOldConfig();
		EnsureDirectory(UserDataDir);
		EnsureDirectory(LogDir);
		EnsureDirectory(UserTempDir);
	}

	private static void MigrateOldConfig()
	{
		try
		{
			string oldDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CPAHelperForWordRe");
			if (!Directory.Exists(oldDir)) return;
			if (!Directory.Exists(UserDataDir))
			{
				Directory.CreateDirectory(UserDataDir);
			}
			string oldConfig = Path.Combine(oldDir, "config");
			string newConfig = ConfigDir;
			if (Directory.Exists(oldConfig) && !Directory.Exists(newConfig))
			{
				CopyDirectory(oldConfig, newConfig);
			}
		}
		catch { }
	}

	private static void CopyDirectory(string sourceDir, string destDir)
	{
		Directory.CreateDirectory(destDir);
		foreach (string file in Directory.GetFiles(sourceDir))
		{
			string fileName = Path.GetFileName(file);
			File.Copy(file, Path.Combine(destDir, fileName), true);
		}
		foreach (string dir in Directory.GetDirectories(sourceDir))
		{
			string dirName = Path.GetFileName(dir);
			CopyDirectory(dir, Path.Combine(destDir, dirName));
		}
	}

	public static void EnsureDirectory(string P_0)
	{
		if (!Directory.Exists(P_0))
		{
			Directory.CreateDirectory(P_0);
		}
	}

	public static void EnsureAllDirectories()
	{
		string[] array = new string[5] { UserDataDir, ConfigDir, TemplateDir, LogDir, UserTempDir };
		for (int i = 0; i < array.Length; i++)
		{
			EnsureDirectory(array[i]);
		}
	}

	public static string GetUserDataPath(params string[] segments)
	{
		string text = UserDataDir;
		if (segments != null)
		{
			foreach (string text2 in segments)
			{
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text = Path.Combine(text, text2);
				}
			}
		}
		EnsureDirectory(text);
		return text;
	}

	public static string GetTempPath(params string[] segments)
	{
		string text = UserTempDir;
		if (segments != null)
		{
			foreach (string text2 in segments)
			{
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text = Path.Combine(text, text2);
				}
			}
		}
		EnsureDirectory(text);
		return text;
	}

	private static string[] CollectInstallPathCandidates()
	{
		List<string> list = new List<string>();
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		AddUniquePath(list, Path.GetDirectoryName(executingAssembly.Location));
		AddUniquePath(list, GetDirectoryFromCodeBase(executingAssembly.CodeBase));
		AddUniquePath(list, AppDomain.CurrentDomain.BaseDirectory);
		foreach (string item in GetRegistryInstallPaths())
		{
			AddUniquePath(list, item);
		}
		return list.ToArray();
	}

	private static void AddUniquePath(List<string> P_0, string P_1)
	{
		_G_c__DisplayClass31_0 CS_8_locals_6 = new _G_c__DisplayClass31_0();
		CS_8_locals_6.WtuVEqLgtlj = P_1;
		if (!string.IsNullOrWhiteSpace(CS_8_locals_6.WtuVEqLgtlj))
		{
			try
			{
				CS_8_locals_6.WtuVEqLgtlj = Path.GetFullPath(CS_8_locals_6.WtuVEqLgtlj.Trim());
			}
			catch
			{
				return;
			}
			if (!P_0.Any((string existing) => string.Equals(existing, CS_8_locals_6.WtuVEqLgtlj, StringComparison.OrdinalIgnoreCase)))
			{
				P_0.Add(CS_8_locals_6.WtuVEqLgtlj);
			}
		}
	}

	private static string GetDirectoryFromCodeBase(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return null;
		}
		try
		{
			return Path.GetDirectoryName(new Uri(P_0).LocalPath);
		}
		catch
		{
			return null;
		}
	}

	private static IEnumerable<string> GetRegistryInstallPaths()
	{
		using RegistryKey root = Registry.CurrentUser.OpenSubKey("IP_Assurance") ?? Registry.CurrentUser.OpenSubKey("CPAHelperForWordRe");
		if (root == null)
		{
			yield break;
		}
		string[] subKeyNames = root.GetSubKeyNames();
		foreach (string text in subKeyNames)
		{
			using RegistryKey subKey = root.OpenSubKey(text);
			string b = subKey?.GetValue("config") as string;
			if (string.Equals("settings.json", text, StringComparison.OrdinalIgnoreCase) || string.Equals("config.json", b, StringComparison.OrdinalIgnoreCase))
			{
				string text2 = ParseTemplatePath(subKey.GetValue("templates") as string);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					yield return Path.GetDirectoryName(text2);
				}
			}
		}
	}

	private static string ParseTemplatePath(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return null;
		}
		int num = P_0.IndexOf('|');
		string text = ((num >= 0) ? P_0.Substring(0, num) : P_0);
		if (text.StartsWith("file:///", StringComparison.OrdinalIgnoreCase))
		{
			try
			{
				return new Uri(text).LocalPath;
			}
			catch
			{
				return null;
			}
		}
		return text;
	}

	static AiSseStreamService()
	{
		SseStreamInitializer.InitializeRuntime();
		_installPathCandidates = new Lazy<string[]>(CollectInstallPathCandidates);
		_installPath = new Lazy<string>(() => GetDirectoryFromCodeBase(Assembly.GetExecutingAssembly().CodeBase) ?? _installPathCandidates.Value.FirstOrDefault((string path) => !string.IsNullOrWhiteSpace(path)) ?? string.Empty);
	}
}
