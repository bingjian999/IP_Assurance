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
	private sealed class SharedConfigWrapper
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

		public SharedConfigWrapper()
		{
			SseStreamInitializer.InitializeRuntime();
			bupVEohxDif = new Helper_22();
		}
	}

	private static readonly Lazy<FileDownloadHelper> _lazyInstance;

	private readonly object KwqtuCnaQw;

	private Helper_22 GjctDgWXbD;

	public static FileDownloadHelper Current => _lazyInstance.Value;

	public static FileDownloadHelper Instance => _lazyInstance.Value;

	public static string SharedConfigDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "IP_Assurance", "Agent");

	public static string SharedConfigPath => Path.Combine(SharedConfigDir, "agent-settings.json");

	public Helper_22 Ai
	{
		get
		{
			lock (KwqtuCnaQw)
			{
				EnsureConfigLoaded();
				return GjctDgWXbD;
			}
		}
	}

	public void RefreshConfig()
	{
		lock (KwqtuCnaQw)
		{
			EnsureConfigLoaded();
		}
	}

	public void UpdateConfig(Action<Helper_22> P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		lock (KwqtuCnaQw)
		{
			EnsureConfigLoaded();
			P_0(GjctDgWXbD);
			GjctDgWXbD.DuXtXcAhKd();
			SaveSharedConfig();
		}
	}

	private void EnsureConfigLoaded()
	{
		Helper_22 gjctDgWXbD2;
		if (vQOtRdkIHU(out var gjctDgWXbD))
		{
			GjctDgWXbD = gjctDgWXbD;
		}
		else if (TryLoadHostConfig(AiSseStreamService.MainConfigFilePath, out gjctDgWXbD2))
		{
			GjctDgWXbD = gjctDgWXbD2;
			SaveSharedConfig();
			AiConfigBootstrap.LogInfo("[AI Config] Migrated host AI config to shared path: " + SharedConfigPath);
		}
		else
		{
			GjctDgWXbD = new Helper_22();
			GjctDgWXbD.DuXtXcAhKd();
			SaveSharedConfig();
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
			SharedConfigWrapper sharedConfig = JsonConvert.DeserializeObject<SharedConfigWrapper>(File.ReadAllText(SharedConfigPath, Encoding.UTF8));
			if (sharedConfig?.Ai?.Assistant == null)
			{
				return false;
			}
			sharedConfig.Ai.DuXtXcAhKd();
			P_0 = sharedConfig.Ai;
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AI Config] Shared config load failed, falling back to host config: " + ex.Message);
			return false;
		}
	}

	private static bool TryLoadHostConfig(string P_0, out Helper_22 P_1)
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
			Helper_22 aiConfig = jToken.ToObject<Helper_22>();
			if (aiConfig?.Assistant == null)
			{
				return false;
			}
			aiConfig.DuXtXcAhKd();
			P_1 = aiConfig;
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AI Config] Host AI config migration skipped: " + ex.Message);
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
			AiHelper_8 aiProviderConfig = new AiHelper_8
			{
				Provider = AiHelper_8.CVZLBdQFXa((string?)jObject["AiProvider"]),
				ApiKey = (((string?)jObject["AiApiKey"]) ?? ""),
				BaseUrl = (((string?)jObject["AiBaseUrl"]) ?? ""),
				Model = (((string?)jObject["AiModel"]) ?? "")
			};
			if (!aiProviderConfig.IsValid())
			{
				return false;
			}
			Helper_22 aiConfig = new Helper_22();
			aiConfig.Assistant.WebUrl = ((string?)jObject["AssistantUrl"]) ?? "";
			aiConfig.Assistant.Runtime.FVULVTGET5(aiProviderConfig);
			aiConfig.Assistant.Providers = new List<AiProviderConfig> { AiProviderConfig.CreateProviderConfig("当前配置", aiProviderConfig) };
			aiConfig.Assistant.ActiveProviderIndex = 0;
			aiConfig.DuXtXcAhKd();
			P_1 = aiConfig;
			return true;
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[AI Config] Legacy AI assistant migration skipped: " + ex.Message);
			return false;
		}
	}

	private void SaveSharedConfig()
	{
		Directory.CreateDirectory(SharedConfigDir);
		GjctDgWXbD.DuXtXcAhKd();
		string contents = JsonConvert.SerializeObject(new SharedConfigWrapper
		{
			Ai = GjctDgWXbD
		}, Formatting.Indented);
		File.WriteAllText(SharedConfigPath, contents, Encoding.UTF8);
	}

	public FileDownloadHelper()
	{
		SseStreamInitializer.InitializeRuntime();
		KwqtuCnaQw = new object();
		GjctDgWXbD = new Helper_22();
	}

	static FileDownloadHelper()
	{
		SseStreamInitializer.InitializeRuntime();
		_lazyInstance = new Lazy<FileDownloadHelper>(() => new FileDownloadHelper());
	}
}
