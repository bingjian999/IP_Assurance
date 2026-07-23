using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Adapters;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class AgentRuntimeSessionService
{
	private readonly IAgentConfigProvider _configProvider;

	private readonly IAgentSessionStore _agentSessionStore;

	private readonly SessionToolState _sessionToolState;

	private readonly Func<string, string, AIAgent> _getOrCreateAgent;

	internal AgentRuntimeSessionService(IAgentConfigProvider configProvider, IAgentSessionStore agentSessionStore, SessionToolState sessionToolState, Func<string, string, AIAgent> getOrCreateAgent)
	{
		_configProvider = configProvider ?? throw new ArgumentNullException("configProvider");
		_agentSessionStore = agentSessionStore ?? throw new ArgumentNullException("agentSessionStore");
		_sessionToolState = sessionToolState ?? throw new ArgumentNullException("sessionToolState");
		_getOrCreateAgent = getOrCreateAgent ?? throw new ArgumentNullException("getOrCreateAgent");
	}

	internal async Task<AgentSession> CreateSessionAsync(string instructions = null, string sessionId = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		AIAgent agent = _getOrCreateAgent(instructions, sessionId);
		string fingerprint = BuildFingerprint(instructions);
		AgentSession restoredSession = await _agentSessionStore.TryRestoreAsync(agent, sessionId, fingerprint, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		AgentSession agentSession = restoredSession;
		if (agentSession == null)
		{
			agentSession = await agent.CreateSessionAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		AgentSession agentSession2 = agentSession;
		if (restoredSession == null)
		{
			HydrateLegacyHistory(agent, agentSession2, sessionId);
		}
		_sessionToolState.AttachPendingTurnToolsToSession(agentSession2, sessionId);
		return agentSession2;
	}

	internal async Task SaveSessionAsync(AgentSession session, string instructions = null, string sessionId = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (session != null && !string.IsNullOrWhiteSpace(sessionId))
		{
			AIAgent agent = _getOrCreateAgent(instructions, sessionId);
			InMemoryChatHistoryProvider historyProvider = agent.GetService<ChatHistoryProvider>() as InMemoryChatHistoryProvider;
			AgentSessionSanitizer.SanitizeInMemoryHistory(historyProvider, session);
			await CompactInMemoryHistoryAsync(historyProvider, session, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			AgentSessionSanitizer.SanitizeInMemoryHistory(historyProvider, session);
			await _agentSessionStore.SaveAsync(agent, session, sessionId, BuildFingerprint(instructions), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	internal async Task<MafCompactionMetricsSnapshot> GetCurrentCompactionMetricsAsync(AgentSession session, string instructions = null, string sessionId = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (session == null)
		{
			return null;
		}
		List<ChatMessage> list = (_getOrCreateAgent(instructions, sessionId).GetService<ChatHistoryProvider>() as InMemoryChatHistoryProvider)?.GetMessages(session);
		if (list == null || list.Count == 0)
		{
			return null;
		}
		AgentChatRuntimeOptions.ResolvedSummaryOptions options = AgentChatRuntimeOptions.ResolveSummaryOptions(_configProvider.GetActiveConfig()?.Summary);
		MafCompactionMetricsSnapshot snapshot = null;
		IChatReducer chatReducer = AgentChatRuntimeOptions.BuildCompactionMetricsReducer(options);
		using (MafCompactionMetrics.BeginObserve(delegate(MafCompactionMetricsSnapshot metrics)
		{
			snapshot = metrics;
		}))
		{
			await chatReducer.ReduceAsync(list, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		return snapshot;
	}

	private string BuildFingerprint(string instructions)
	{
		return AgentRuntimeConfiguration.BuildSessionFingerprint(_configProvider.GetActiveConfig(), AgentRuntimeConfiguration.NormalizeInstructions(instructions));
	}

	private static void HydrateLegacyHistory(AIAgent agent, AgentSession session, string sessionId)
	{
		if (agent == null || session == null || string.IsNullOrWhiteSpace(sessionId) || !(agent.GetService<ChatHistoryProvider>() is InMemoryChatHistoryProvider inMemoryChatHistoryProvider))
		{
			return;
		}
		List<ChatMessage> messages = inMemoryChatHistoryProvider.GetMessages(session);
		if (messages == null || messages.Count <= 0)
		{
			List<ChatMessage> list = JsonSessionMessageHydrator.LoadMessages(sessionId);
			if (list.Count != 0)
			{
				inMemoryChatHistoryProvider.SetMessages(session, AgentSessionSanitizer.SanitizeMessages(list));
			}
		}
	}

	private static async Task CompactInMemoryHistoryAsync(InMemoryChatHistoryProvider historyProvider, AgentSession session, CancellationToken cancellationToken)
	{
		if (historyProvider == null || session == null || historyProvider.ChatReducer == null)
		{
			return;
		}
		List<ChatMessage> messages = historyProvider.GetMessages(session);
		if (messages == null || messages.Count == 0)
		{
			return;
		}
		try
		{
			List<ChatMessage> list = AgentSessionSanitizer.SanitizeReducedMessagesPreservingLiveToolTail(messages, await historyProvider.ChatReducer.ReduceAsync(messages, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			if (list.Count != 0)
			{
				historyProvider.SetMessages(session, list);
			}
		}
		catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
		{
			throw;
		}
		catch (Exception)
		{
		}
	}
}
