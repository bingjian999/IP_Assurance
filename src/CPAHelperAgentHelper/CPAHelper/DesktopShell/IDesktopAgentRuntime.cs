using System;
using System.Collections.Generic;
using System.Threading;
using CPAHelper.Agent.Runtime;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal interface IDesktopAgentRuntime
{
	IAsyncEnumerable<AgentResponseUpdate> RunStreamingAsync(string userMessage, AgentSession session = null, string instructions = null, string sessionId = null, Action<string, string> statusObserver = null, Action<MafCompactionMetricsSnapshot> compactionObserver = null, CancellationToken cancellationToken = default(CancellationToken));

	IAsyncEnumerable<AgentResponseUpdate> RunStreamingAsync(IEnumerable<ChatMessage> messages, AgentSession session = null, string instructions = null, string sessionId = null, Action<string, string> statusObserver = null, Action<MafCompactionMetricsSnapshot> compactionObserver = null, CancellationToken cancellationToken = default(CancellationToken));

	void EndTurn(AgentSession session, string sessionId = null);
}
