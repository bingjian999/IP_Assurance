using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using AiConfigBootstrap;
using AiProviderConfig;
using Helper_22;
using AiSseStreamService3;
using SseStreamInitializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AiHelper_8;
using AiSseStreamService;

namespace FileDownloadHelper;

internal sealed class FileDownloadHelper
{
	private sealed class j5N1K5VEmu1I1WqebZZK
	{
		[CompilerGenerated]
		private Helper_22 bupVEohxDif;

		public Helper_22 Ai
		{
			[CompilerGenerated]
			get
			{
				return bupVEohxDif;
			}
			[CompilerGenerated]
			set
			{
				bupVEohxDif = value;
			}
		}

		public j5N1K5VEmu1I1WqebZZK()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
			bupVEohxDif = new Helper_22();
		}
	}

	private static readonly Lazy<FileDownloadHelper> BTjt6fAYGp;

	private readonly object KwqtuCnaQw;

	private Helper_22 GjctDgWXbD;

	public static FileDownloadHelper Current => BTjt6fAYGp.Value;

	public static FileDownloadHelper Instance => BTjt6fAYGp.Value;

	public static string SharedConfigDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "IP_Assurance", "Agent");

	public static string SharedConfigPath => Path.Combine(SharedConfigDir, "agent-settings.json");

	public Helper_22 Ai
	{
		get
		{
			lock (KwqtuCnaQw)
			{
				S4hwzxoxhW();
				return GjctDgWXbD;
			}
		}
	}

	public void t9vwx1YSVk()
	{
		lock (KwqtuCnaQw)
		{
			S4hwzxoxhW();
		}
	}

	public void lpfwdhmiR3(Action<Helper_22> P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		lock (KwqtuCnaQw)
		{
			S4hwzxoxhW();
			P_0(GjctDgWXbD);
			GjctDgWXbD.DuXtXcAhKd();
			Bjmt9SQa8r();
		}
	}

	private void S4hwzxoxhW()
	{
		Helper_22 gjctDgWXbD2;
		if (vQOtRdkIHU(out var gjctDgWXbD))
		{
			GjctDgWXbD = gjctDgWXbD;
		}
		else if (f6UtVMJhV7(AiSseStreamService.MainConfigFilePath, out gjctDgWXbD2))
		{
			GjctDgWXbD = gjctDgWXbD2;
			Bjmt9SQa8r();
			AiConfigBootstrap.swCsJ4IbrL("[AI Config] Migrated host AI config to shared path: " + SharedConfigPath);
		}
		else
		{
			GjctDgWXbD = new Helper_22();
			GjctDgWXbD.DuXtXcAhKd();
			Bjmt9SQa8r();
		}
	}

	private static bool vQOtRdkIHU(out Helper_22 P_0)
	{
		P_0 = null;
		try
		{
			if (!File.Exists(SharedConfigPath))
			{
				return false;
			}
			j5N1K5VEmu1I1WqebZZK j5N1K5VEmu1I1WqebZZK2 = JsonConvert.DeserializeObject<j5N1K5VEmu1I1WqebZZK>(File.ReadAllText(SharedConfigPath, Encoding.UTF8));
			if (j5N1K5VEmu1I1WqebZZK2?.Ai?.Assistant == null)
			{
				return false;
			}
			j5N1K5VEmu1I1WqebZZK2.Ai.DuXtXcAhKd();
			P_0 = j5N1K5VEmu1I1WqebZZK2.Ai;
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.z7Us3dJ6Cl("[AI Config] Shared config load failed, falling back to host config: " + ex.Message);
			return false;
		}
	}

	private static bool f6UtVMJhV7(string P_0, out Helper_22 P_1)
	{
		P_1 = null;
		try
		{
			if (string.IsNullOrWhiteSpace(P_0) || !File.Exists(P_0))
			{
				return false;
			}
			JObject jObject = JObject.Parse(File.ReadAllText(P_0, Encoding.UTF8));
			JToken jToken = jObject["Ai"];
			if (jToken == null || jToken.Type == JTokenType.Null)
			{
				return kdKtBeOfPv(jObject, out P_1);
			}
			Helper_22 k8SSB2tefS63E9gSxuJ2 = jToken.ToObject<Helper_22>();
			if (k8SSB2tefS63E9gSxuJ2?.Assistant == null)
			{
				return false;
			}
			k8SSB2tefS63E9gSxuJ2.DuXtXcAhKd();
			P_1 = k8SSB2tefS63E9gSxuJ2;
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.z7Us3dJ6Cl("[AI Config] Host AI config migration skipped: " + ex.Message);
			return false;
		}
	}

	private static bool kdKtBeOfPv(JObject P_0, out Helper_22 P_1)
	{
		P_1 = null;
		try
		{
			if (!(P_0?["AiAssistant"] is JObject jObject))
			{
				return false;
			}
			AiHelper_8 cn1I4Itdi2pbX0gWYAr2 = new AiHelper_8
			{
				Provider = AiHelper_8.CVZLBdQFXa((string?)jObject["AiProvider"]),
				ApiKey = (((string?)jObject["AiApiKey"]) ?? ""),
				BaseUrl = (((string?)jObject["AiBaseUrl"]) ?? ""),
				Model = (((string?)jObject["AiModel"]) ?? "")
			};
			if (!cn1I4Itdi2pbX0gWYAr2.g0DLRYEicD())
			{
				return false;
			}
			Helper_22 k8SSB2tefS63E9gSxuJ2 = new Helper_22();
			k8SSB2tefS63E9gSxuJ2.Assistant.WebUrl = ((string?)jObject["AssistantUrl"]) ?? "";
			k8SSB2tefS63E9gSxuJ2.Assistant.Runtime.FVULVTGET5(cn1I4Itdi2pbX0gWYAr2);
			k8SSB2tefS63E9gSxuJ2.Assistant.Providers = new List<AiProviderConfig> { AiProviderConfig.PZwLIR4Stn("当前配置", cn1I4Itdi2pbX0gWYAr2) };
			k8SSB2tefS63E9gSxuJ2.Assistant.ActiveProviderIndex = 0;
			k8SSB2tefS63E9gSxuJ2.DuXtXcAhKd();
			P_1 = k8SSB2tefS63E9gSxuJ2;
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.z7Us3dJ6Cl("[AI Config] Legacy AI assistant migration skipped: " + ex.Message);
			return false;
		}
	}

	private void Bjmt9SQa8r()
	{
		Directory.CreateDirectory(SharedConfigDir);
		GjctDgWXbD.DuXtXcAhKd();
		string contents = JsonConvert.SerializeObject(new j5N1K5VEmu1I1WqebZZK
		{
			Ai = GjctDgWXbD
		}, Formatting.Indented);
		File.WriteAllText(SharedConfigPath, contents, Encoding.UTF8);
	}

	public FileDownloadHelper()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		KwqtuCnaQw = new object();
		GjctDgWXbD = new Helper_22();
	}

	static FileDownloadHelper()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		BTjt6fAYGp = new Lazy<FileDownloadHelper>(() => new FileDownloadHelper());
	}
}
