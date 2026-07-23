using System;
using System.Collections.Generic;
using System.Threading;
using CPAHelper.Agent.Runtime;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopAgentRuntimeAdapter : IDesktopAgentRuntime
{
	private readonly AgentRuntime _agentRuntime;

	public DesktopAgentRuntimeAdapter(AgentRuntime agentRuntime)
	{
		_agentRuntime = agentRuntime ?? throw new ArgumentNullException("agentRuntime");
	}

	public IAsyncEnumerable<AgentResponseUpdate> RunStreamingAsync(string userMessage, AgentSession session = null, string instructions = null, string sessionId = null, Action<string, string> statusObserver = null, Action<MafCompactionMetricsSnapshot> compactionObserver = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _agentRuntime.RunStreamingAsync(userMessage, session, instructions, sessionId, statusObserver, compactionObserver, cancellationToken);
	}

	public IAsyncEnumerable<AgentResponseUpdate> RunStreamingAsync(IEnumerable<ChatMessage> messages, AgentSession session = null, string instructions = null, string sessionId = null, Action<string, string> statusObserver = null, Action<MafCompactionMetricsSnapshot> compactionObserver = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _agentRuntime.RunStreamingAsync(messages, session, instructions, sessionId, statusObserver, compactionObserver, cancellationToken);
	}

	public void EndTurn(AgentSession session, string sessionId = null)
	{
		_agentRuntime.EndTurn(session, sessionId);
	}
}
