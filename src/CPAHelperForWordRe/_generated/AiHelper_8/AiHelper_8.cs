using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;

namespace AiHelper_8;

internal sealed class AiHelper_8
{
	[CompilerGenerated]
	private string _provider;

	[CompilerGenerated]
	private string _apiKey;

	[CompilerGenerated]
	private string _baseUrl;

	[CompilerGenerated]
	private string _model;

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
		SseStreamInitializer.InitializeRuntime();
		_provider = "openai";
		_apiKey = "";
		_baseUrl = "";
		_model = "";
	}
}
