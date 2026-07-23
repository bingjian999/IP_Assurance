using System;
using System.Collections.Concurrent;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class AgentRuntimeAgentCache
{
	private readonly IAgentConfigProvider _configProvider;

	private readonly SessionToolState _sessionToolState;

	private readonly Func<AgentConfig, string, AIAgent> _createAgent;

	private readonly ConcurrentDictionary<string, AIAgent> _agents = new ConcurrentDictionary<string, AIAgent>(StringComparer.Ordinal);

	private string _cachedConfigHash;

	internal AgentRuntimeAgentCache(IAgentConfigProvider configProvider, SessionToolState sessionToolState, Func<AgentConfig, string, AIAgent> createAgent)
	{
		_configProvider = configProvider ?? throw new ArgumentNullException("configProvider");
		_sessionToolState = sessionToolState ?? throw new ArgumentNullException("sessionToolState");
		_createAgent = createAgent ?? throw new ArgumentNullException("createAgent");
	}

	internal AIAgent GetOrCreate(string instructions = null, string sessionId = null)
	{
		AgentConfig config = _configProvider.GetActiveConfig();
		string effectiveInstructions = AgentRuntimeConfiguration.NormalizeInstructions(instructions);
		string text = AgentRuntimeConfiguration.BuildAgentCacheHash(config, effectiveInstructions);
		if (!string.Equals(_cachedConfigHash, text, StringComparison.Ordinal))
		{
			_agents.Clear();
			_sessionToolState.Clear();
			_cachedConfigHash = text;
		}
		string key = sessionId ?? string.Empty;
		return _agents.GetOrAdd(key, (string _) => _createAgent(config, effectiveInstructions));
	}

	internal void RemoveSession(string sessionId)
	{
		if (sessionId != null)
		{
			_agents.TryRemove(sessionId, out var _);
			_sessionToolState.RemoveSession(sessionId);
		}
	}

	internal void ResetSessionState(string sessionId)
	{
		RemoveSession(sessionId);
	}

	internal void Clear()
	{
		_agents.Clear();
		_sessionToolState.Clear();
	}
}
