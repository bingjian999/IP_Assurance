using System.Threading;
using System.Threading.Tasks;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.Abstractions;

public interface IAgentSessionStore
{
	Task<AgentSession> TryRestoreAsync(AIAgent agent, string sessionId, string fingerprint, CancellationToken cancellationToken);

	Task SaveAsync(AIAgent agent, AgentSession session, string sessionId, string fingerprint, CancellationToken cancellationToken);

	void Delete(string sessionId);
}
