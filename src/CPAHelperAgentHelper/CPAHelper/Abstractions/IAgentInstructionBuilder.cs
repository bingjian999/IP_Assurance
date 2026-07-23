namespace CPAHelper.Agent.Abstractions;

public interface IAgentInstructionBuilder
{
	string BuildInstructions(AgentInstructionContext context);
}
