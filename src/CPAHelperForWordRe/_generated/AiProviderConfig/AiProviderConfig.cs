using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;
using AiHelper_8;

namespace AiProviderConfig;

internal sealed class AiProviderConfig
{
	[CompilerGenerated]
	private string _name;

	[CompilerGenerated]
	private string _provider;

	[CompilerGenerated]
	private string _apiKey;

	[CompilerGenerated]
	private string _baseUrl;

	[CompilerGenerated]
	private string _model;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return _name;
		}
		[CompilerGenerated]
		set
		{
			_name = value;
		}
	}

	public string Provider
	{
		[CompilerGenerated]
		get
		{
			return _provider;
		}
		[CompilerGenerated]
		set
		{
			_provider = value;
		}
	}

	public string ApiKey
	{
		[CompilerGenerated]
		get
		{
			return _apiKey;
		}
		[CompilerGenerated]
		set
		{
			_apiKey = value;
		}
	}

	public string BaseUrl
	{
		[CompilerGenerated]
		get
		{
			return _baseUrl;
		}
		[CompilerGenerated]
		set
		{
			_baseUrl = value;
		}
	}

	public string Model
	{
		[CompilerGenerated]
		get
		{
			return _model;
		}
		[CompilerGenerated]
		set
		{
			_model = value;
		}
	}

	public AiHelper_8 ToRuntimeConfig()
	{
		return new AiHelper_8
		{
			Provider = AiHelper_8.CVZLBdQFXa(Provider),
			ApiKey = (ApiKey ?? ""),
			BaseUrl = (BaseUrl ?? ""),
			Model = (Model ?? "")
		};
	}

	public static AiProviderConfig CreateProviderConfig(string P_0, AiHelper_8 P_1)
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

	public static List<AiProviderConfig> GetBuiltinProviders()
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
		SseStreamInitializer.InitializeRuntime();
		_name = "";
		_provider = "openai";
		_apiKey = "";
		_baseUrl = "";
		_model = "";
	}
}
