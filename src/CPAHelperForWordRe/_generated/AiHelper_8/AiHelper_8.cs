using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;

namespace AiHelper_8;

internal sealed class AiHelper_8
{
	[CompilerGenerated]
	private string Hu1L9j1MIi;

	[CompilerGenerated]
	private string a7IL69pId7;

	[CompilerGenerated]
	private string zr0Luiygdy;

	[CompilerGenerated]
	private string L6fLDVDEXK;

	public string Provider
	{
		[CompilerGenerated]
		get
		{
			return Hu1L9j1MIi;
		}
		[CompilerGenerated]
		set
		{
			Hu1L9j1MIi = value;
		}
	}

	public string ApiKey
	{
		[CompilerGenerated]
		get
		{
			return a7IL69pId7;
		}
		[CompilerGenerated]
		set
		{
			a7IL69pId7 = value;
		}
	}

	public string BaseUrl
	{
		[CompilerGenerated]
		get
		{
			return zr0Luiygdy;
		}
		[CompilerGenerated]
		set
		{
			zr0Luiygdy = value;
		}
	}

	public string Model
	{
		[CompilerGenerated]
		get
		{
			return L6fLDVDEXK;
		}
		[CompilerGenerated]
		set
		{
			L6fLDVDEXK = value;
		}
	}

	public bool g0DLRYEicD()
	{
		if (string.IsNullOrWhiteSpace(ApiKey) && string.IsNullOrWhiteSpace(BaseUrl))
		{
			return !string.IsNullOrWhiteSpace(Model);
		}
		return true;
	}

	public void FVULVTGET5(AiHelper_8 P_0)
	{
		if (P_0 != null)
		{
			Provider = CVZLBdQFXa(P_0.Provider);
			ApiKey = P_0.ApiKey ?? "";
			BaseUrl = P_0.BaseUrl ?? "";
			Model = P_0.Model ?? "";
		}
	}

	public static string CVZLBdQFXa(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			return P_0.Trim().ToLowerInvariant();
		}
		return "openai";
	}

	public AiHelper_8()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		Hu1L9j1MIi = "openai";
		a7IL69pId7 = "";
		zr0Luiygdy = "";
		L6fLDVDEXK = "";
	}
}
