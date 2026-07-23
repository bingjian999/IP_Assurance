using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using AiConfigBootstrap;
using TableBorderConfig;
using FormatConfigBase;
using AiSseStreamService3;
using SseStreamInitializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Helper_24;
using AiSseStreamService;
using ConfigMigrationResult;

namespace LegacyConfigMigrator;

internal static class LegacyConfigMigrator
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass6_0
	{
		public string text;

		public _G_c__DisplayClass6_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool reYVE2FENQa(string item)
		{
			return string.Equals(item, text, StringComparison.OrdinalIgnoreCase);
		}
	}

	public static string YGQwUiJSHq()
	{
		foreach (string item in NMGw2sXSI3())
		{
			try
			{
				if (File.Exists(item))
				{
					return item;
				}
			}
			catch
			{
			}
		}
		return string.Empty;
	}

	public static FormatConfigBase TgvwKZvsfr(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			throw new ArgumentException("旧版配置文件路径为空。", "sourceConfigPath");
		}
		P_0 = Path.GetFullPath(P_0.Trim());
		if (!File.Exists(P_0))
		{
			throw new FileNotFoundException("未找到旧版配置文件。", P_0);
		}
		string text = Path.GetDirectoryName(P_0) ?? string.Empty;
		Dictionary<string, object> configValues = ORrwjBdDKI(File.ReadAllText(P_0, Encoding.UTF8));
		return new FormatConfigBase
		{
			SourceConfigPath = P_0,
			ConfigValues = configValues,
			ParagraphPresetFiles = nIfwbYYaJt(text, "段落预设", CKIwSkJLmD("段落预设")),
			TablePresetFiles = nIfwbYYaJt(text, "表格预设", CKIwSkJLmD("表格预设"))
		};
	}

	public static ConfigMigrationResult gTQwEdX7kI(FormatConfigBase P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("preview");
		}
		if (!P_0.HasMigratableItems)
		{
			throw new InvalidOperationException("旧版配置中没有可导入的表格/段落配置或预设。");
		}
		ConfigMigrationResult yjZ4lmw7an9JOgXHIuS = new ConfigMigrationResult
		{
			SourceConfigPath = P_0.SourceConfigPath,
			ParagraphConfigCount = P_0.ParagraphConfigCount,
			TableConfigCount = P_0.TableConfigCount,
			OtherConfigCount = P_0.OtherConfigCount
		};
		yjZ4lmw7an9JOgXHIuS.BackupPath = k5Www6bih8();
		if (P_0.ConfigValues.Count > 0)
		{
			Dictionary<string, object> dictionary = TableBorderConfig.Current.GetAllLegacy();
			foreach (KeyValuePair<string, object> configValue in P_0.ConfigValues)
			{
				dictionary[configValue.Key] = configValue.Value;
			}
			TableBorderConfig.Current.SetAllLegacy(dictionary);
		}
		usdwt8HvqO(P_0.ParagraphPresetFiles, true, yjZ4lmw7an9JOgXHIuS);
		usdwt8HvqO(P_0.TablePresetFiles, false, yjZ4lmw7an9JOgXHIuS);
		AiConfigBootstrap.LogInfo("[ConfigMigration] Imported legacy Word table/paragraph config from: " + P_0.SourceConfigPath);
		return yjZ4lmw7an9JOgXHIuS;
	}

	private static IEnumerable<string> NMGw2sXSI3()
	{
		List<string> list = new List<string>();
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		YPFw4guD8A(list, Path.Combine(folderPath, "IP_Assurance_Old", "config", "config.json"));
		YPFw4guD8A(list, Path.Combine(folderPath, "IP_Assurance", "CPA Helper wd", "config", "config.json"));
		YPFw4guD8A(list, Path.Combine(folderPath2, "CPAHelperForWordRe", "config", "config.json"));
		return list;
	}

	private static void YPFw4guD8A(List<string> P_0, string P_1)
	{
		_G_c__DisplayClass6_0 CS_8_locals_6 = new _G_c__DisplayClass6_0();
		CS_8_locals_6.text = P_1;
		if (!string.IsNullOrWhiteSpace(CS_8_locals_6.text))
		{
			try
			{
				CS_8_locals_6.text = Path.GetFullPath(CS_8_locals_6.text);
			}
			catch
			{
				return;
			}
			if (!P_0.Any((string item) => string.Equals(item, CS_8_locals_6.text, StringComparison.OrdinalIgnoreCase)))
			{
				P_0.Add(CS_8_locals_6.text);
			}
		}
	}

	private static Dictionary<string, object> ORrwjBdDKI(string P_0)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>(StringComparer.Ordinal);
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return dictionary;
		}
		try
		{
			Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(P_0);
			if (dictionary2 != null)
			{
				foreach (KeyValuePair<string, object> item in dictionary2)
				{
					if (dl7wYepy91(item.Key))
					{
						dictionary[item.Key] = SgVwZyTomx(item.Value);
					}
				}
				return dictionary;
			}
		}
		catch (Exception)
		{
		}
		foreach (Match item2 in Regex.Matches(P_0, "\"(?<key>(?:\\\\\\\\.|[^\"])*)\"\\\\s*:\\\\s*(?<value>\"(?:\\\\\\\\.|[^\"])*\"|-?\\\\d+(?:\\\\.\\\\d+)?|true|false|null)", RegexOptions.Multiline))
		{
			string text = kfkwfrKoLS(item2.Groups["key"].Value);
			if (dl7wYepy91(text))
			{
				object value = zrgwMqqy4W(item2.Groups["value"].Value);
				dictionary[text] = value;
			}
		}
		return dictionary;
	}

	private static bool dl7wYepy91(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		if (!P_0.StartsWith("段落_", StringComparison.Ordinal) && !P_0.StartsWith("表格_", StringComparison.Ordinal) && !string.Equals(P_0, "段落配置_当前方案", StringComparison.Ordinal) && !string.Equals(P_0, "段落配置_方案名", StringComparison.Ordinal))
		{
			return string.Equals(P_0, "表格配置_方案名", StringComparison.Ordinal);
		}
		return true;
	}

	private static object SgVwZyTomx(object P_0)
	{
		if (P_0 is JValue jValue)
		{
			return jValue.Value;
		}
		if (P_0 is JToken jToken)
		{
			return jToken.ToString(Formatting.None);
		}
		return P_0;
	}

	private static string kfkwfrKoLS(string P_0)
	{
		try
		{
			return JsonConvert.DeserializeObject<string>("\"" + P_0 + "\"") ?? string.Empty;
		}
		catch
		{
			return P_0 ?? string.Empty;
		}
	}

	private static object zrgwMqqy4W(string P_0)
	{
		try
		{
			return SgVwZyTomx(JsonConvert.DeserializeObject<object>(P_0));
		}
		catch
		{
			return (P_0 ?? string.Empty).Trim().Trim('"');
		}
	}

	private static List<Helper_24> nIfwbYYaJt(string P_0, string P_1, string P_2)
	{
		List<Helper_24> list = new List<Helper_24>();
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return list;
		}
		string path = Path.Combine(P_0, P_1);
		if (!Directory.Exists(path))
		{
			return list;
		}
		try
		{
			string[] files = Directory.GetFiles(path, "*.json");
			foreach (string text in files)
			{
				string fileName = Path.GetFileName(text);
				if (!string.IsNullOrWhiteSpace(fileName))
				{
					string text2 = Path.Combine(P_2, fileName);
					list.Add(new Helper_24
					{
						SourcePath = text,
						TargetPath = text2,
						ExistsInTarget = File.Exists(text2)
					});
				}
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[ConfigMigration] Enumerate legacy preset files failed: " + ex.Message);
		}
		return list;
	}

	private static string CKIwSkJLmD(string P_0)
	{
		return AiSseStreamService.GetUserDataPath("config", P_0);
	}

	private static string k5Www6bih8()
	{
		string mainConfigFilePath = AiSseStreamService.MainConfigFilePath;
		if (!File.Exists(mainConfigFilePath))
		{
			return string.Empty;
		}
		string text = Path.Combine(AiSseStreamService.ConfigDir, "backups");
		AiSseStreamService.EnsureDirectory(text);
		string text2 = Path.Combine(text, "settings_before_legacy_import_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + ".json");
		File.Copy(mainConfigFilePath, text2, overwrite: false);
		return text2;
	}

	private static void usdwt8HvqO(IEnumerable<Helper_24> P_0, bool P_1, ConfigMigrationResult P_2)
	{
		foreach (Helper_24 item in P_0 ?? Enumerable.Empty<Helper_24>())
		{
			if (item.ExistsInTarget || File.Exists(item.TargetPath))
			{
				if (P_1)
				{
					P_2.SkippedParagraphPresetCount++;
				}
				else
				{
					P_2.SkippedTablePresetCount++;
				}
				continue;
			}
			try
			{
				string directoryName = Path.GetDirectoryName(item.TargetPath);
				if (!string.IsNullOrWhiteSpace(directoryName))
				{
					AiSseStreamService.EnsureDirectory(directoryName);
				}
				File.Copy(item.SourcePath, item.TargetPath, overwrite: false);
				if (P_1)
				{
					P_2.CopiedParagraphPresetCount++;
				}
				else
				{
					P_2.CopiedTablePresetCount++;
				}
			}
			catch (Exception ex)
			{
				P_2.FailedPresetFiles.Add(Path.GetFileName(item.SourcePath) + "：" + ex.Message);
				if (P_1)
				{
					P_2.FailedParagraphPresetCount++;
				}
				else
				{
					P_2.FailedTablePresetCount++;
				}
			}
		}
	}
}
