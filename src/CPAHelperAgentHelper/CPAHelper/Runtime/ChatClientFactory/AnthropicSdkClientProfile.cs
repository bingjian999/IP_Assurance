using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Anthropic;
using CPAHelper.Agent.Abstractions;
using Microsoft.Extensions.AI;
using OpenAI;

namespace CPAHelper.Agent.Runtime;

public class ChatClientFactory : IDisposable
{
	private abstract class ProviderClientProfile : IDisposable
	{
		public abstract IChatClient CreateChatClient();

		public abstract void Dispose();
	}

	private sealed class DeepSeekClientProfile : ProviderClientProfile
	{
		private readonly AgentConfig _config;

		private readonly HttpClient _httpClient = new HttpClient
		{
			Timeout = TimeSpan.FromMinutes(10.0)
		};

		public DeepSeekClientProfile(AgentConfig config)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			_config = config;
		}

		public override IChatClient CreateChatClient()
		{
			DeepSeekOpenAIChatClient deepSeekClient = new DeepSeekOpenAIChatClient(_config.ApiKey, NormalizeDeepSeekBaseUrl(_config.BaseUrl), _config.Model, _httpClient, ownsHttpClient: false);
			return CreateBudgetedDeepSeekChatClient(_config, deepSeekClient);
		}

		public override void Dispose()
		{
			((HttpMessageInvoker)_httpClient).Dispose();
		}
	}

	private sealed class AnthropicCompatibleClientProfile : ProviderClientProfile
	{
		private readonly AgentConfig _config;

		private readonly HttpClient _httpClient = new HttpClient();

		public AnthropicCompatibleClientProfile(AgentConfig config)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			_config = config;
		}

		public override IChatClient CreateChatClient()
		{
			return new AnthropicChatClient(_config.ApiKey, NormalizeBaseUrl(_config.BaseUrl), _config.Model, _httpClient, ownsHttpClient: false);
		}

		public override void Dispose()
		{
			((HttpMessageInvoker)_httpClient).Dispose();
		}
	}

	private sealed class AnthropicSdkClientProfile : ProviderClientProfile
	{
		private readonly AnthropicClient _client;

		private readonly string _model;

		public AnthropicSdkClientProfile(AgentConfig config)
		{
			_model = config.Model;
			_client = new AnthropicClient
			{
				ApiKey = config.ApiKey,
				BaseUrl = NormalizeBaseUrl(config.BaseUrl)
			};
		}

		public override IChatClient CreateChatClient()
		{
			return new NonOwningChatClient(_client.AsIChatClient(_model));
		}

		public override void Dispose()
		{
			_client.Dispose();
		}
	}

	private sealed class OpenAiSdkClientProfile : ProviderClientProfile
	{
		private readonly OpenAIClient _client;

		private readonly IDisposable _owner;

		private readonly string _model;

		public OpenAiSdkClientProfile(AgentConfig config)
		{
			_model = config.Model;
			string text = NormalizeOpenAiBaseUrl(config.BaseUrl);
			if (string.IsNullOrWhiteSpace(text) || string.Equals(text.TrimEnd('/'), "https://api.openai.com/v1", StringComparison.OrdinalIgnoreCase))
			{
				_client = new OpenAIClient(new ApiKeyCredential(config.ApiKey));
			}
			else
			{
				_client = new OpenAIClient(new ApiKeyCredential(config.ApiKey), new OpenAIClientOptions
				{
					Endpoint = new Uri(text.TrimEnd('/'))
				});
			}
			_owner = _client as IDisposable;
		}

		public override IChatClient CreateChatClient()
		{
			return new NonOwningChatClient(_client.GetChatClient(_model).AsIChatClient());
		}

		public override void Dispose()
		{
			_owner?.Dispose();
		}
	}

	private readonly IAgentConfigProvider _configProvider;

	private readonly IModelTraceSink _modelTraceSink;

	private readonly object _profilesSyncRoot = new object();

	private readonly Dictionary<string, ProviderClientProfile> _profiles = new Dictionary<string, ProviderClientProfile>(StringComparer.Ordinal);

	private bool _disposed;

	public ChatClientFactory(IAgentConfigProvider configProvider, IModelTraceSink modelTraceSink = null)
	{
		_configProvider = configProvider ?? throw new ArgumentNullException("configProvider");
		_modelTraceSink = modelTraceSink;
	}

	public virtual IChatClient CreateChatClient()
	{
		AgentConfig activeConfig = _configProvider.GetActiveConfig();
		if (!activeConfig.IsValid())
		{
			throw new InvalidOperationException("AI配置无效，请检查API密钥和服务配置。");
		}
		IChatClient chatClient;
		lock (_profilesSyncRoot)
		{
			ThrowIfDisposed();
			string key = CreateProfileKey(activeConfig);
			if (!_profiles.TryGetValue(key, out var value))
			{
				value = CreateProviderProfile(CloneConfig(activeConfig));
				_profiles.Add(key, value);
			}
			chatClient = value.CreateChatClient();
		}
		if (_modelTraceSink != null)
		{
			chatClient = new TracingChatClient(chatClient, _modelTraceSink);
		}
		return chatClient;
	}

	public static IChatClient CreateChatClientCore(AgentConfig config, out IDisposable clientOwner)
	{
		if (config == null)
		{
			throw new ArgumentNullException("config");
		}
		switch ((config.Provider ?? "openai").Trim().ToLowerInvariant())
		{
		case "deepseek":
		case "moonshot":
		case "kimi":
		case "mimo":
		case "xiaomi":
		case "xiaomimimo":
			return CreateDeepSeekChatClient(config, out clientOwner);
		case "anthropic":
			if (IsClaudeModel(config.Model))
			{
				return ((IAnthropicClient)(clientOwner = new AnthropicClient
				{
					ApiKey = config.ApiKey,
					BaseUrl = NormalizeBaseUrl(config.BaseUrl)
				})).AsIChatClient(config.Model);
			}
			return (IChatClient)(clientOwner = new AnthropicChatClient(config.ApiKey, NormalizeBaseUrl(config.BaseUrl), config.Model));
		default:
			if (IsReasoningContentCompatibleConfig(config))
			{
				return CreateDeepSeekChatClient(config, out clientOwner);
			}
			return CreateOpenAiSdkChatClient(config, NormalizeOpenAiBaseUrl(config.BaseUrl), out clientOwner);
		}
	}

	private static IChatClient CreateDeepSeekChatClient(AgentConfig config, out IDisposable clientOwner)
	{
		DeepSeekOpenAIChatClient deepSeekClient = new DeepSeekOpenAIChatClient(config.ApiKey, NormalizeDeepSeekBaseUrl(config.BaseUrl), config.Model);
		return (IChatClient)(clientOwner = CreateBudgetedDeepSeekChatClient(config, deepSeekClient));
	}

	private static IChatClient CreateBudgetedDeepSeekChatClient(AgentConfig config, DeepSeekOpenAIChatClient deepSeekClient)
	{
		AgentChatRuntimeOptions.ResolvedSummaryOptions resolvedSummaryOptions = AgentChatRuntimeOptions.ResolveSummaryOptions(config.Summary);
		return new ProviderBudgetingChatClient(deepSeekClient, deepSeekClient, resolvedSummaryOptions, AgentChatRuntimeOptions.BuildProviderBudgetForcedHistoryCompactionReducer(deepSeekClient, resolvedSummaryOptions), AgentChatRuntimeOptions.BuildProviderBudgetFallbackHistoryCompactionReducer(resolvedSummaryOptions));
	}

	private static IChatClient CreateOpenAiSdkChatClient(AgentConfig config, string endpoint, out IDisposable clientOwner)
	{
		OpenAIClient openAIClient;
		if (string.IsNullOrWhiteSpace(endpoint) || string.Equals(endpoint.TrimEnd('/'), "https://api.openai.com/v1", StringComparison.OrdinalIgnoreCase))
		{
			openAIClient = new OpenAIClient(new ApiKeyCredential(config.ApiKey));
		}
		else
		{
			OpenAIClientOptions openAIClientOptions = new OpenAIClientOptions();
			openAIClientOptions.Endpoint = new Uri(endpoint.TrimEnd('/'));
			OpenAIClientOptions options = openAIClientOptions;
			openAIClient = new OpenAIClient(new ApiKeyCredential(config.ApiKey), options);
		}
		clientOwner = openAIClient as IDisposable;
		return openAIClient.GetChatClient(config.Model).AsIChatClient();
	}

	private static bool IsClaudeModel(string model)
	{
		if (string.IsNullOrWhiteSpace(model))
		{
			return false;
		}
		return model.IndexOf("claude", StringComparison.OrdinalIgnoreCase) >= 0;
	}

	private static string NormalizeBaseUrl(string baseUrl)
	{
		if (!string.IsNullOrWhiteSpace(baseUrl))
		{
			return baseUrl.TrimEnd('/');
		}
		return "https://api.anthropic.com";
	}

	private static string NormalizeOpenAiBaseUrl(string baseUrl)
	{
		if (!string.IsNullOrWhiteSpace(baseUrl))
		{
			return baseUrl.TrimEnd('/');
		}
		return "https://api.openai.com/v1";
	}

	private static string NormalizeDeepSeekBaseUrl(string baseUrl)
	{
		string text = (string.IsNullOrWhiteSpace(baseUrl) ? "https://api.deepseek.com" : baseUrl.TrimEnd('/'));
		if (text.EndsWith("/anthropic", StringComparison.OrdinalIgnoreCase))
		{
			text = text.Substring(0, text.Length - "/anthropic".Length);
		}
		return text;
	}

	internal static bool IsDeepSeekConfig(AgentConfig config)
	{
		if (config == null)
		{
			return false;
		}
		if (!string.IsNullOrWhiteSpace(config.Provider) && string.Equals(config.Provider.Trim(), "deepseek", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (!string.IsNullOrWhiteSpace(config.BaseUrl) && config.BaseUrl.IndexOf("deepseek", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return true;
		}
		if (!string.IsNullOrWhiteSpace(config.Model) && config.Model.IndexOf("deepseek", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return true;
		}
		return false;
	}

	internal static bool IsReasoningContentCompatibleConfig(AgentConfig config)
	{
		if (IsDeepSeekConfig(config))
		{
			return true;
		}
		if (config == null)
		{
			return false;
		}
		if (!string.IsNullOrWhiteSpace(config.Provider))
		{
			string a = config.Provider.Trim();
			if (string.Equals(a, "mimo", StringComparison.OrdinalIgnoreCase) || string.Equals(a, "xiaomi", StringComparison.OrdinalIgnoreCase) || string.Equals(a, "xiaomimimo", StringComparison.OrdinalIgnoreCase) || string.Equals(a, "kimi", StringComparison.OrdinalIgnoreCase) || string.Equals(a, "moonshot", StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		if (!string.IsNullOrWhiteSpace(config.BaseUrl) && (config.BaseUrl.IndexOf("xiaomimimo", StringComparison.OrdinalIgnoreCase) >= 0 || config.BaseUrl.IndexOf("moonshot.cn", StringComparison.OrdinalIgnoreCase) >= 0))
		{
			return true;
		}
		if (!string.IsNullOrWhiteSpace(config.Model) && (config.Model.IndexOf("mimo", StringComparison.OrdinalIgnoreCase) >= 0 || config.Model.IndexOf("kimi", StringComparison.OrdinalIgnoreCase) >= 0 || config.Model.IndexOf("moonshot", StringComparison.OrdinalIgnoreCase) >= 0))
		{
			return true;
		}
		return false;
	}

	private static ProviderClientProfile CreateProviderProfile(AgentConfig config)
	{
		switch ((config.Provider ?? "openai").Trim().ToLowerInvariant())
		{
		case "deepseek":
		case "moonshot":
		case "kimi":
		case "mimo":
		case "xiaomi":
		case "xiaomimimo":
			return new DeepSeekClientProfile(config);
		case "anthropic":
			if (!IsClaudeModel(config.Model))
			{
				return new AnthropicCompatibleClientProfile(config);
			}
			return new AnthropicSdkClientProfile(config);
		default:
			if (!IsReasoningContentCompatibleConfig(config))
			{
				return new OpenAiSdkClientProfile(config);
			}
			return new DeepSeekClientProfile(config);
		}
	}

	private static string CreateProfileKey(AgentConfig config)
	{
		AgentSummaryOptions agentSummaryOptions = config.Summary ?? new AgentSummaryOptions();
		string s = string.Join("|", config.Provider ?? string.Empty, config.ApiKey ?? string.Empty, config.BaseUrl ?? string.Empty, config.Model ?? string.Empty, agentSummaryOptions.ContextWindowTokens?.ToString() ?? string.Empty, agentSummaryOptions.TriggerRatio?.ToString("R", CultureInfo.InvariantCulture) ?? string.Empty, agentSummaryOptions.TargetRatio?.ToString("R", CultureInfo.InvariantCulture) ?? string.Empty, agentSummaryOptions.HardLimitRatio?.ToString("R", CultureInfo.InvariantCulture) ?? string.Empty, agentSummaryOptions.RecentMessageCount?.ToString() ?? string.Empty, agentSummaryOptions.TimeoutSeconds?.ToString() ?? string.Empty);
		using SHA256 sHA = SHA256.Create();
		return Convert.ToBase64String(sHA.ComputeHash(Encoding.UTF8.GetBytes(s)));
	}

	private static AgentConfig CloneConfig(AgentConfig config)
	{
		AgentSummaryOptions agentSummaryOptions = config.Summary ?? new AgentSummaryOptions();
		return new AgentConfig
		{
			Name = config.Name,
			Provider = config.Provider,
			ApiKey = config.ApiKey,
			BaseUrl = config.BaseUrl,
			Model = config.Model,
			Summary = new AgentSummaryOptions
			{
				ContextWindowTokens = agentSummaryOptions.ContextWindowTokens,
				TriggerRatio = agentSummaryOptions.TriggerRatio,
				TargetRatio = agentSummaryOptions.TargetRatio,
				HardLimitRatio = agentSummaryOptions.HardLimitRatio,
				RecentMessageCount = agentSummaryOptions.RecentMessageCount,
				TimeoutSeconds = agentSummaryOptions.TimeoutSeconds
			}
		};
	}

	private void ThrowIfDisposed()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("ChatClientFactory");
		}
	}

	public void Dispose()
	{
		List<ProviderClientProfile> list;
		lock (_profilesSyncRoot)
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
			list = new List<ProviderClientProfile>(_profiles.Values);
			_profiles.Clear();
		}
		foreach (ProviderClientProfile item in list)
		{
			item.Dispose();
		}
	}
}
