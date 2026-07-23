using Microsoft.Agents.AI;

namespace CPAHelper.Agent.Abstractions;

public interface IChatHistoryStoreFactory
{
	ChatHistoryProvider Create(string sessionId);
}
