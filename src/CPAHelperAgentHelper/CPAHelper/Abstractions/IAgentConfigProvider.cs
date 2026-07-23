namespace CPAHelper.Agent.Abstractions;

public interface IAgentConfigProvider
{
	AgentConfig GetActiveConfig();

	bool IsConfigValid();
}
