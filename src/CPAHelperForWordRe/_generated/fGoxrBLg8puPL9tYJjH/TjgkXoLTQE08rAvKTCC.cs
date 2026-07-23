using System.Collections.Generic;
using System.Runtime.CompilerServices;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;
using oBj8i4tzkFO0U03EgiU;

namespace fGoxrBLg8puPL9tYJjH;

internal sealed class TjgkXoLTQE08rAvKTCC
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

	public cn1I4Itdi2pbX0gWYAr OsCL8QJeMd()
	{
		return new cn1I4Itdi2pbX0gWYAr
		{
			Provider = cn1I4Itdi2pbX0gWYAr.CVZLBdQFXa(Provider),
			ApiKey = (ApiKey ?? ""),
			BaseUrl = (BaseUrl ?? ""),
			Model = (Model ?? "")
		};
	}

	public static TjgkXoLTQE08rAvKTCC PZwLIR4Stn(string P_0, cn1I4Itdi2pbX0gWYAr P_1)
	{
		return new TjgkXoLTQE08rAvKTCC
		{
			Name = wFmLiEaskI(P_0, "当前配置"),
			Provider = cn1I4Itdi2pbX0gWYAr.CVZLBdQFXa(P_1?.Provider),
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

	public static List<TjgkXoLTQE08rAvKTCC> dV6LHfPZVP()
	{
		return new List<TjgkXoLTQE08rAvKTCC>
		{
			new TjgkXoLTQE08rAvKTCC
			{
				Name = "阿里云百炼",
				Provider = "openai",
				BaseUrl = "https://dashscope.aliyuncs.com/compatible-mode/v1",
				Model = "qwen3.5-plus"
			},
			new TjgkXoLTQE08rAvKTCC
			{
				Name = "DeepSeek",
				Provider = "openai",
				BaseUrl = "https://api.deepseek.com",
				Model = "deepseek-v4-flash"
			},
			new TjgkXoLTQE08rAvKTCC
			{
				Name = "硅基流动",
				Provider = "openai",
				BaseUrl = "https://api.siliconflow.cn/v1",
				Model = "Pro/moonshotai/Kimi-K2.5"
			},
			new TjgkXoLTQE08rAvKTCC
			{
				Name = "智谱清言",
				Provider = "openai",
				BaseUrl = "https://open.bigmodel.cn/api/paas/v4",
				Model = "glm-5.1"
			},
			new TjgkXoLTQE08rAvKTCC
			{
				Name = "Kimi (Moonshot)",
				Provider = "openai",
				BaseUrl = "https://api.moonshot.cn/v1",
				Model = "kimi-k2.5"
			},
			new TjgkXoLTQE08rAvKTCC
			{
				Name = "火山引擎 (豆包)",
				Provider = "openai",
				BaseUrl = "https://ark.cn-beijing.volces.com/api/v3",
				Model = "doubao-seed-2-0-pro-260215"
			}
		};
	}

	public TjgkXoLTQE08rAvKTCC()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		qb1LQYMfIL = "";
		AkvL1qAYUE = "openai";
		nO8LrsZRmT = "";
		DvYLJ9GuQN = "";
		FI5L3Vw5oO = "";
	}
}
