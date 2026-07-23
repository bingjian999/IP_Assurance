using CPAHelper.Agent.Abstractions;
using FileDownloadHelper;
using AiSseStreamService3;
using IntranetAiConfigService;
using SseStreamInitializer;
using AiSseStreamService;
using ProviderConfig;
using AiHelper_9;

namespace AiSseStreamService5;

internal sealed class AiSseStreamService5 : IAgentConfigProvider, IAgentAuthenticationRecovery
{
	public AgentConfig GetActiveConfig()
	{
		ProviderConfig assistant = FileDownloadHelper.Current.Ai.Assistant;
		AgentConfig agentConfig = IntranetAiConfigService.Instance.GetAgentConfig(assistant.Runtime);
		agentConfig.Summary = (assistant.Summary ?? new AiHelper_9()).BuildSummaryOptions();
		agentConfig.Harness = new AgentHarnessOptions
		{
			FileAccessEnabled = true,
			FileMemoryEnabled = true,
			FileAccessRoot = AiSseStreamService.GetUserDataPath("Agent", "files"),
			FileMemoryRoot = AiSseStreamService.GetUserDataPath("Agent", "memory")
		};
		return agentConfig;
	}

	public bool IsConfigValid()
	{
		return GetActiveConfig().IsValid();
	}

	public bool TryRecoverFromUnauthorized(string P_0)
	{
		return IntranetAiConfigService.Instance.ReAuthenticate(P_0);
	}

	public AiSseStreamService5()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
