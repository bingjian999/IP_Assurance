using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class SessionToolState
{
	private sealed class ToolState
	{
		public List<string> TurnToolNames { get; set; } = new List<string>();

		public List<RetainedToolState> RetainedTools { get; set; } = new List<RetainedToolState>();
	}

	private sealed class RetainedToolState
	{
		public string Name { get; set; }

		public int RemainingTurns { get; set; }
	}

	private const string ToolStateKey = "cpahelper.toolState.v2";

	private const int DefaultRetentionTurns = 3;

	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		PropertyNameCaseInsensitive = true,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
		TypeInfoResolver = new DefaultJsonTypeInfoResolver()
	};

	private readonly ToolAggregator _toolAggregator;

	private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, byte>> _pendingTurnToolsBySessionId = new ConcurrentDictionary<string, ConcurrentDictionary<string, byte>>(StringComparer.Ordinal);

	internal SessionToolState(ToolAggregator toolAggregator)
	{
		_toolAggregator = toolAggregator ?? throw new ArgumentNullException("toolAggregator");
	}

	internal void Clear()
	{
		_pendingTurnToolsBySessionId.Clear();
	}

	internal void RemoveSession(string sessionId)
	{
		if (sessionId != null)
		{
			_pendingTurnToolsBySessionId.TryRemove(sessionId, out var _);
		}
	}

	internal IReadOnlyList<string> EnsureToolsLoaded(string sessionId, IEnumerable<string> toolNames)
	{
		IReadOnlyList<string> readOnlyList = ResolveKnownToolNames(toolNames);
		RememberTurnTools(sessionId, readOnlyList);
		return readOnlyList;
	}

	internal IReadOnlyList<string> EnsureToolsLoaded(AgentSession session, string sessionId, IEnumerable<string> toolNames)
	{
		IReadOnlyList<string> readOnlyList = ResolveKnownToolNames(toolNames);
		RememberTurnTools(session, sessionId, readOnlyList);
		return readOnlyList;
	}

	internal void RememberTurnTools(string sessionId, IEnumerable<string> toolNames)
	{
		string key = sessionId ?? string.Empty;
		ConcurrentDictionary<string, byte> orAdd = _pendingTurnToolsBySessionId.GetOrAdd(key, (string _) => new ConcurrentDictionary<string, byte>(StringComparer.OrdinalIgnoreCase));
		foreach (string item in NormalizeNames(toolNames))
		{
			orAdd.TryAdd(item, 0);
		}
	}

	internal void RememberTurnTools(AgentSession session, string sessionId, IEnumerable<string> toolNames)
	{
		List<string> list = NormalizeNames(toolNames).ToList();
		if (list.Count == 0)
		{
			return;
		}
		if (session == null)
		{
			RememberTurnTools(sessionId, list);
			return;
		}
		ToolState sessionState = GetSessionState(session);
		HashSet<string> hashSet = new HashSet<string>(sessionState.TurnToolNames ?? new List<string>(), StringComparer.OrdinalIgnoreCase);
		foreach (string item in list)
		{
			hashSet.Add(item);
		}
		sessionState.TurnToolNames = hashSet.OrderBy((string name) => name, StringComparer.OrdinalIgnoreCase).ToList();
		SaveSessionState(session, sessionState);
	}

	internal void RememberRetainedTools(AgentSession session, string sessionId, IEnumerable<string> toolNames, int remainingTurns = 3)
	{
		List<string> list = ResolveKnownToolNames(toolNames).ToList();
		if (list.Count == 0)
		{
			return;
		}
		if (session == null)
		{
			RememberTurnTools(sessionId, list);
			return;
		}
		ToolState sessionState = GetSessionState(session);
		Dictionary<string, int> dictionary = BuildRetainedMap(sessionState);
		foreach (string item in list)
		{
			dictionary[item] = Math.Max(1, remainingTurns);
		}
		sessionState.RetainedTools = (from pair in dictionary.OrderBy((KeyValuePair<string, int> pair) => pair.Key, StringComparer.OrdinalIgnoreCase)
			select new RetainedToolState
			{
				Name = pair.Key,
				RemainingTurns = pair.Value
			}).ToList();
		SaveSessionState(session, sessionState);
	}

	internal void AttachPendingTurnToolsToSession(AgentSession session, string sessionId)
	{
		if (session != null && !string.IsNullOrWhiteSpace(sessionId))
		{
			List<string> list = GetTurnToolNames(sessionId).ToList();
			if (list.Count != 0)
			{
				RememberTurnTools(session, sessionId, list);
				_pendingTurnToolsBySessionId.TryRemove(sessionId, out var _);
			}
		}
	}

	internal void ClearTurnTools(AgentSession session, string sessionId = null)
	{
		if (sessionId != null)
		{
			_pendingTurnToolsBySessionId.TryRemove(sessionId, out var _);
		}
		if (session != null)
		{
			ToolState sessionState = GetSessionState(session);
			if (sessionState.TurnToolNames != null && sessionState.TurnToolNames.Count != 0)
			{
				sessionState.TurnToolNames = new List<string>();
				SaveSessionState(session, sessionState);
			}
		}
	}

	internal void AdvanceRetainedTools(AgentSession session)
	{
		if (session == null)
		{
			return;
		}
		ToolState sessionState = GetSessionState(session);
		if (sessionState.RetainedTools == null || sessionState.RetainedTools.Count == 0)
		{
			return;
		}
		sessionState.RetainedTools = (from @group in (from entry in sessionState.RetainedTools
				where !string.IsNullOrWhiteSpace(entry?.Name)
				select new RetainedToolState
				{
					Name = entry.Name.Trim(),
					RemainingTurns = entry.RemainingTurns - 1
				} into entry
				where entry.RemainingTurns > 0
				select entry).GroupBy((RetainedToolState entry) => entry.Name, StringComparer.OrdinalIgnoreCase)
			select @group.OrderByDescending((RetainedToolState entry) => entry.RemainingTurns).First()).OrderBy((RetainedToolState entry) => entry.Name, StringComparer.OrdinalIgnoreCase).ToList();
		SaveSessionState(session, sessionState);
	}

	internal IEnumerable<string> GetTurnToolNames(string sessionId)
	{
		string key = sessionId ?? string.Empty;
		if (!_pendingTurnToolsBySessionId.TryGetValue(key, out var value))
		{
			return Array.Empty<string>();
		}
		return value.Keys.ToArray();
	}

	internal IEnumerable<string> GetTurnToolNames(AgentSession session, string sessionId = null)
	{
		if (session == null)
		{
			return GetTurnToolNames(sessionId);
		}
		AttachPendingTurnToolsToSession(session, sessionId);
		return GetSessionState(session).TurnToolNames ?? new List<string>();
	}

	internal IEnumerable<string> GetRetainedToolNames(AgentSession session)
	{
		if (session == null)
		{
			return Array.Empty<string>();
		}
		return (from entry in GetSessionState(session).RetainedTools ?? new List<RetainedToolState>()
			where !string.IsNullOrWhiteSpace(entry?.Name) && entry.RemainingTurns > 0
			select entry.Name.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
	}

	internal IEnumerable<string> GetVisibleToolNames(AgentSession session, string sessionId = null)
	{
		return GetTurnToolNames(session, sessionId).Concat(GetRetainedToolNames(session)).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
	}

	private IReadOnlyList<string> ResolveKnownToolNames(IEnumerable<string> toolNames)
	{
		List<string> list = NormalizeNames(toolNames).ToList();
		if (list.Count == 0)
		{
			return Array.Empty<string>();
		}
		HashSet<string> requestedSet = new HashSet<string>(list, StringComparer.OrdinalIgnoreCase);
		return (from metadata in _toolAggregator.GetToolMetadata()
			where !string.IsNullOrWhiteSpace(metadata?.Name) && requestedSet.Contains(metadata.Name)
			select metadata.Name.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
	}

	private static IEnumerable<string> NormalizeNames(IEnumerable<string> toolNames)
	{
		return (from name in toolNames ?? Array.Empty<string>()
			where !string.IsNullOrWhiteSpace(name)
			select name.Trim()).Distinct(StringComparer.OrdinalIgnoreCase);
	}

	private static Dictionary<string, int> BuildRetainedMap(ToolState state)
	{
		return (state.RetainedTools ?? new List<RetainedToolState>()).Where((RetainedToolState entry) => !string.IsNullOrWhiteSpace(entry?.Name) && entry.RemainingTurns > 0).GroupBy((RetainedToolState entry) => entry.Name.Trim(), StringComparer.OrdinalIgnoreCase).ToDictionary((IGrouping<string, RetainedToolState> group) => group.Key, (IGrouping<string, RetainedToolState> group) => group.Max((RetainedToolState entry) => entry.RemainingTurns), StringComparer.OrdinalIgnoreCase);
	}

	private static ToolState GetSessionState(AgentSession session)
	{
		if (session?.StateBag == null)
		{
			return new ToolState();
		}
		if (session.StateBag.TryGetValue<string>("cpahelper.toolState.v2", out string value, JsonOptions) && !string.IsNullOrWhiteSpace(value))
		{
			try
			{
				return JsonSerializer.Deserialize<ToolState>(value, JsonOptions) ?? new ToolState();
			}
			catch
			{
				return new ToolState();
			}
		}
		if (session.StateBag.TryGetValue<ToolState>("cpahelper.toolState.v2", out ToolState value2, JsonOptions))
		{
			ToolState toolState = value2 ?? new ToolState();
			SaveSessionState(session, toolState);
			return toolState;
		}
		return new ToolState();
	}

	private static void SaveSessionState(AgentSession session, ToolState state)
	{
		if (session?.StateBag != null)
		{
			string value = JsonSerializer.Serialize(state ?? new ToolState(), JsonOptions);
			session.StateBag.SetValue("cpahelper.toolState.v2", value, JsonOptions);
		}
	}
}
