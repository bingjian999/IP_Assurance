namespace CPAHelper.Agent.Abstractions;

public interface IAgentRuntimeContextBuilder
{
	string BuildRuntimeContext(AgentInstructionContext context);
}
