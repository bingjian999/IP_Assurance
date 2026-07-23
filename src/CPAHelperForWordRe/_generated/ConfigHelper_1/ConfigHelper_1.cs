using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AiSseStreamService3;
using SseStreamInitializer;
using Newtonsoft.Json;
using AiSseStreamService;

namespace ConfigHelper_1;

internal sealed class ConfigHelper_1
{
	private readonly string bHiSmuFwEd;

	public string DirectoryPath => bHiSmuFwEd;

	public ConfigHelper_1(string P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		bHiSmuFwEd = AiSseStreamService.GetUserDataPath("config", P_0);
	}

	public IReadOnlyList<string> ExsSbMHeGd()
	{
		return Directory.GetFiles(bHiSmuFwEd, "*.json").Select(Path.GetFileNameWithoutExtension).OrderBy((string name) => name, StringComparer.CurrentCulture)
			.ToArray();
	}

	public bool haGSSyJWCc(string P_0)
	{
		return File.Exists(GetFilePath(P_0));
	}

	public string GetFilePath(string P_0)
	{
		return Path.Combine(bHiSmuFwEd, (P_0 ?? string.Empty) + ".json");
	}

	public Dictionary<string, string> COQStnlspT(string P_0)
	{
		return ImportPresetFromFile(GetFilePath(P_0));
	}

	public Dictionary<string, string> ImportPresetFromFile(string P_0)
	{
		return JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(P_0)) ?? new Dictionary<string, string>();
	}

	public void SavePreset(string P_0, IDictionary<string, string> P_1)
	{
		lRlSlvdQT7(GetFilePath(P_0), P_1);
	}

	public static void lRlSlvdQT7(string P_0, IDictionary<string, string> P_1)
	{
		File.WriteAllText(P_0, JsonConvert.SerializeObject(P_1, Formatting.Indented));
	}

	public void Delete(string name)
	{
		string path = GetFilePath(name);
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	public string CreateUniquePresetName(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim();
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		foreach (char oldChar in invalidFileNameChars)
		{
			text = text.Replace(oldChar, '_');
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "新方案";
		}
		string text2 = text;
		int num = 1;
		while (haGSSyJWCc(text2))
		{
			text2 = text + "_" + num;
			num++;
		}
		return text2;
	}
}
