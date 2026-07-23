using System;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.Adapters;

public sealed class JsonAgentSessionStore : IAgentSessionStore
{
	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		PropertyNameCaseInsensitive = true,
		TypeInfoResolver = new DefaultJsonTypeInfoResolver()
	};

	public async Task<AgentSession> TryRestoreAsync(AIAgent agent, string sessionId, string fingerprint, CancellationToken cancellationToken)
	{
		if (agent == null || !JsonSessionIndexManager.TryGetSerializedAgentSession(sessionId, fingerprint, out var serializedSession))
		{
			return null;
		}
		try
		{
			return await agent.DeserializeSessionAsync(serializedSession, JsonOptions, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch
		{
			return null;
		}
	}

	public async Task SaveAsync(AIAgent agent, AgentSession session, string sessionId, string fingerprint, CancellationToken cancellationToken)
	{
		if (agent != null && session != null && !string.IsNullOrWhiteSpace(sessionId))
		{
			long conversationRevision = JsonSessionIndexManager.GetConversationRevision(sessionId);
			if (!JsonSessionIndexManager.TrySaveSerializedAgentSession(sessionId, await agent.SerializeSessionAsync(session, JsonOptions, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), fingerprint, conversationRevision))
			{
				throw new InvalidOperationException($"Conversation changed while its MAF AgentSession was being serialized. SessionId={sessionId}; ExpectedRevision={conversationRevision}.");
			}
		}
	}

	public void Delete(string sessionId)
	{
	}
}
