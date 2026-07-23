using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using dL7TFPsQbAGqPywtHUK;
using fGoxrBLg8puPL9tYJjH;
using hgGWZZtyfkd02lD1RkA;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using oBj8i4tzkFO0U03EgiU;
using qDDKriLz2Bft1Ehv17i;

namespace fGo32Mwk81lacGmgK2T;

internal sealed class R3YZo3w0TC95VlJruO8
{
	private sealed class j5N1K5VEmu1I1WqebZZK
	{
		[CompilerGenerated]
		private k8SSB2tefS63E9gSxuJ bupVEohxDif;

		public k8SSB2tefS63E9gSxuJ Ai
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
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			bupVEohxDif = new k8SSB2tefS63E9gSxuJ();
		}
	}

	private static readonly Lazy<R3YZo3w0TC95VlJruO8> BTjt6fAYGp;

	private readonly object KwqtuCnaQw;

	private k8SSB2tefS63E9gSxuJ GjctDgWXbD;

	public static R3YZo3w0TC95VlJruO8 Current => BTjt6fAYGp.Value;

	public static R3YZo3w0TC95VlJruO8 Instance => BTjt6fAYGp.Value;

	public static string SharedConfigDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "IP_Assurance", "Agent");

	public static string SharedConfigPath => Path.Combine(SharedConfigDir, "agent-settings.json");

	public k8SSB2tefS63E9gSxuJ Ai
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

	public void lpfwdhmiR3(Action<k8SSB2tefS63E9gSxuJ> P_0)
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
		k8SSB2tefS63E9gSxuJ gjctDgWXbD2;
		if (vQOtRdkIHU(out var gjctDgWXbD))
		{
			GjctDgWXbD = gjctDgWXbD;
		}
		else if (f6UtVMJhV7(W6xTwMLd5RvSHoqDfEV.MainConfigFilePath, out gjctDgWXbD2))
		{
			GjctDgWXbD = gjctDgWXbD2;
			Bjmt9SQa8r();
			yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[AI Config] Migrated host AI config to shared path: " + SharedConfigPath);
		}
		else
		{
			GjctDgWXbD = new k8SSB2tefS63E9gSxuJ();
			GjctDgWXbD.DuXtXcAhKd();
			Bjmt9SQa8r();
		}
	}

	private static bool vQOtRdkIHU(out k8SSB2tefS63E9gSxuJ P_0)
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
			yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[AI Config] Shared config load failed, falling back to host config: " + ex.Message);
			return false;
		}
	}

	private static bool f6UtVMJhV7(string P_0, out k8SSB2tefS63E9gSxuJ P_1)
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
			k8SSB2tefS63E9gSxuJ k8SSB2tefS63E9gSxuJ2 = jToken.ToObject<k8SSB2tefS63E9gSxuJ>();
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
			yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[AI Config] Host AI config migration skipped: " + ex.Message);
			return false;
		}
	}

	private static bool kdKtBeOfPv(JObject P_0, out k8SSB2tefS63E9gSxuJ P_1)
	{
		P_1 = null;
		try
		{
			if (!(P_0?["AiAssistant"] is JObject jObject))
			{
				return false;
			}
			cn1I4Itdi2pbX0gWYAr cn1I4Itdi2pbX0gWYAr2 = new cn1I4Itdi2pbX0gWYAr
			{
				Provider = cn1I4Itdi2pbX0gWYAr.CVZLBdQFXa((string?)jObject["AiProvider"]),
				ApiKey = (((string?)jObject["AiApiKey"]) ?? ""),
				BaseUrl = (((string?)jObject["AiBaseUrl"]) ?? ""),
				Model = (((string?)jObject["AiModel"]) ?? "")
			};
			if (!cn1I4Itdi2pbX0gWYAr2.g0DLRYEicD())
			{
				return false;
			}
			k8SSB2tefS63E9gSxuJ k8SSB2tefS63E9gSxuJ2 = new k8SSB2tefS63E9gSxuJ();
			k8SSB2tefS63E9gSxuJ2.Assistant.WebUrl = ((string?)jObject["AssistantUrl"]) ?? "";
			k8SSB2tefS63E9gSxuJ2.Assistant.Runtime.FVULVTGET5(cn1I4Itdi2pbX0gWYAr2);
			k8SSB2tefS63E9gSxuJ2.Assistant.Providers = new List<TjgkXoLTQE08rAvKTCC> { TjgkXoLTQE08rAvKTCC.PZwLIR4Stn("当前配置", cn1I4Itdi2pbX0gWYAr2) };
			k8SSB2tefS63E9gSxuJ2.Assistant.ActiveProviderIndex = 0;
			k8SSB2tefS63E9gSxuJ2.DuXtXcAhKd();
			P_1 = k8SSB2tefS63E9gSxuJ2;
			return true;
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[AI Config] Legacy AI assistant migration skipped: " + ex.Message);
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

	public R3YZo3w0TC95VlJruO8()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		KwqtuCnaQw = new object();
		GjctDgWXbD = new k8SSB2tefS63E9gSxuJ();
	}

	static R3YZo3w0TC95VlJruO8()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		BTjt6fAYGp = new Lazy<R3YZo3w0TC95VlJruO8>(() => new R3YZo3w0TC95VlJruO8());
	}
}
