using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;
using AiHelper_8;

namespace AiProviderConfig;

internal sealed class AiProviderConfig
{
	[CompilerGenerated]
	private string qb1LQYMfIL;

	[CompilerGenerated]
	private string AkvL1qAYUE;

	[CompilerGenerated]
	private string nO8LrsZRmT;

	[CompilerGenerated]
	private string DvYLJ9GuQN;

	[CompilerGenerated]
	private string FI5L3Vw5oO;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return qb1LQYMfIL;
		}
		[CompilerGenerated]
		set
		{
			qb1LQYMfIL = value;
		}
	}

	public string Provider
	{
		[CompilerGenerated]
		get
		{
			return AkvL1qAYUE;
		}
		[CompilerGenerated]
		set
		{
			AkvL1qAYUE = value;
		}
	}

	public string ApiKey
	{
		[CompilerGenerated]
		get
		{
			return nO8LrsZRmT;
		}
		[CompilerGenerated]
		set
		{
			nO8LrsZRmT = value;
		}
	}

	public string BaseUrl
	{
		[CompilerGenerated]
		get
		{
			return DvYLJ9GuQN;
		}
		[CompilerGenerated]
		set
		{
			DvYLJ9GuQN = value;
		}
	}

	public string Model
	{
		[CompilerGenerated]
		get
		{
			return FI5L3Vw5oO;
		}
		[CompilerGenerated]
		set
		{
			FI5L3Vw5oO = value;
		}
	}

	public AiHelper_8 OsCL8QJeMd()
	{
		return new AiHelper_8
		{
			Provider = AiHelper_8.CVZLBdQFXa(Provider),
			ApiKey = (ApiKey ?? ""),
			BaseUrl = (BaseUrl ?? ""),
			Model = (Model ?? "")
		};
	}

	public static AiProviderConfig PZwLIR4Stn(string P_0, AiHelper_8 P_1)
	{
		return new AiProviderConfig
		{
			Name = wFmLiEaskI(P_0, "当前配置"),
			Provider = AiHelper_8.CVZLBdQFXa(P_1?.Provider),
			ApiKey = (P_1?.ApiKey ?? ""),
			BaseUrl = (P_1?.BaseUrl ?? ""),
			Model = (P_1?.Model ?? "")
		};
	}

	public static string wFmLiEaskI(string P_0, string P_1)
	{
		string text = (P_0 ?? string.Empty).Trim();
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return P_1;
	}

	public static List<AiProviderConfig> dV6LHfPZVP()
	{
		return new List<AiProviderConfig>
		{
			new AiProviderConfig
			{
				Name = "阿里云百炼",
				Provider = "openai",
				BaseUrl = "https://dashscope.aliyuncs.com/compatible-mode/v1",
				Model = "qwen3.5-plus"
			},
			new AiProviderConfig
			{
				Name = "DeepSeek",
				Provider = "openai",
				BaseUrl = "https://api.deepseek.com",
				Model = "deepseek-v4-flash"
			},
			new AiProviderConfig
			{
				Name = "硅基流动",
				Provider = "openai",
				BaseUrl = "https://api.siliconflow.cn/v1",
				Model = "Pro/moonshotai/Kimi-K2.5"
			},
			new AiProviderConfig
			{
				Name = "智谱清言",
				Provider = "openai",
				BaseUrl = "https://open.bigmodel.cn/api/paas/v4",
				Model = "glm-5.1"
			},
			new AiProviderConfig
			{
				Name = "Kimi (Moonshot)",
				Provider = "openai",
				BaseUrl = "https://api.moonshot.cn/v1",
				Model = "kimi-k2.5"
			},
			new AiProviderConfig
			{
				Name = "火山引擎 (豆包)",
				Provider = "openai",
				BaseUrl = "https://ark.cn-beijing.volces.com/api/v3",
				Model = "doubao-seed-2-0-pro-260215"
			}
		};
	}

	public AiProviderConfig()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		qb1LQYMfIL = "";
		AkvL1qAYUE = "openai";
		nO8LrsZRmT = "";
		DvYLJ9GuQN = "";
		FI5L3Vw5oO = "";
	}
}
