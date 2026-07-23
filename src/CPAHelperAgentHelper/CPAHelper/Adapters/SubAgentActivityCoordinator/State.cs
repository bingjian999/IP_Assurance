using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CPAHelper.Agent.Abstractions;

namespace CPAHelper.Agent.Adapters;

internal static class SubAgentActivityCoordinator
{
	private sealed class State
	{
		private readonly object _syncRoot = new object();

		private readonly List<TrackedActivity> _activities = new List<TrackedActivity>();

		private int _nextSequence;

		private int _nextGroupSequence;

		private ActivityGroup _openGroup;

		public TrackedActivity Register(string agentName, string description)
		{
			lock (_syncRoot)
			{
				ActivityGroup activityGroup = EnsureOpenGroup();
				TrackedActivity trackedActivity = new TrackedActivity
				{
					Sequence = ++_nextSequence,
					ActivityId = CreateActivityId(),
					AgentName = Normalize(agentName),
					Title = Normalize(description),
					Status = "registered",
					ActivityGroupId = activityGroup.Id,
					ActivityGroupTitle = activityGroup.Title
				};
				_activities.Add(trackedActivity);
				return trackedActivity;
			}
		}

		public SubAgentActivityDescriptor Claim(string agentName, string requestedDescription, string fallbackTitle)
		{
			lock (_syncRoot)
			{
				string normalizedAgentName = Normalize(agentName);
				string normalizedDescription = Normalize(requestedDescription);
				TrackedActivity trackedActivity = _activities.OrderBy((TrackedActivity item) => item.Sequence).FirstOrDefault((TrackedActivity item) => !item.Claimed && Matches(item.AgentName, normalizedAgentName) && Matches(item.Title, normalizedDescription));
				if (trackedActivity == null)
				{
					trackedActivity = _activities.OrderBy((TrackedActivity item) => item.Sequence).FirstOrDefault((TrackedActivity item) => !item.Claimed && Matches(item.AgentName, normalizedAgentName));
				}
				if (trackedActivity == null)
				{
					ActivityGroup activityGroup = EnsureOpenGroup();
					trackedActivity = new TrackedActivity
					{
						Sequence = ++_nextSequence,
						ActivityId = CreateActivityId(),
						AgentName = normalizedAgentName,
						Title = (normalizedDescription ?? Normalize(fallbackTitle)),
						Status = "registered",
						ActivityGroupId = activityGroup.Id,
						ActivityGroupTitle = activityGroup.Title
					};
					_activities.Add(trackedActivity);
				}
				trackedActivity.Claimed = true;
				trackedActivity.AgentName = normalizedAgentName ?? trackedActivity.AgentName;
				trackedActivity.Title = trackedActivity.Title ?? normalizedDescription ?? Normalize(fallbackTitle) ?? normalizedAgentName ?? "SubAgent";
				trackedActivity.Status = "starting";
				return new SubAgentActivityDescriptor(trackedActivity.ActivityId, trackedActivity.Title, trackedActivity.ActivityGroupId, trackedActivity.ActivityGroupTitle);
			}
		}

		public void RemovePending(TrackedActivity activity)
		{
			if (activity == null)
			{
				return;
			}
			lock (_syncRoot)
			{
				if (!activity.Claimed)
				{
					_activities.Remove(activity);
				}
			}
		}

		public void SealOpenGroup()
		{
			lock (_syncRoot)
			{
				if (_openGroup != null)
				{
					_openGroup.Sealed = true;
				}
				_openGroup = null;
			}
		}

		public void Observe(SubAgentActivityUpdate update)
		{
			lock (_syncRoot)
			{
				TrackedActivity trackedActivity = _activities.FirstOrDefault((TrackedActivity item) => string.Equals(item.ActivityId, update.ActivityId, StringComparison.Ordinal));
				if (trackedActivity != null)
				{
					trackedActivity.Status = Normalize(update.Status) ?? trackedActivity.Status;
					trackedActivity.ResultPreview = update.ResultPreview ?? trackedActivity.ResultPreview;
					trackedActivity.UpdatedAt = Normalize(update.UpdatedAt) ?? trackedActivity.UpdatedAt;
				}
			}
		}

		public IReadOnlyList<SubAgentActivityUpdate> BuildTurnEndUpdates(bool cancelled)
		{
			lock (_syncRoot)
			{
				List<SubAgentActivityUpdate> list = new List<SubAgentActivityUpdate>();
				foreach (TrackedActivity item in _activities.OrderBy((TrackedActivity item) => item.Sequence))
				{
					if (item.Claimed && !IsTerminal(item.Status))
					{
						item.Status = (cancelled ? "cancelled" : "detached");
						item.UpdatedAt = DateTimeOffset.Now.ToString("O");
						list.Add(new SubAgentActivityUpdate
						{
							ActivityId = item.ActivityId,
							AgentName = item.AgentName,
							Title = item.Title,
							Status = item.Status,
							Detail = (cancelled ? "子任务已随主回合取消。" : "主回合异常结束或达到完成性兜底上限，子任务已脱离当前回合。"),
							ResultPreview = item.ResultPreview,
							ActivityGroupId = item.ActivityGroupId,
							ActivityGroupTitle = item.ActivityGroupTitle,
							UpdatedAt = item.UpdatedAt
						});
					}
				}
				return list;
			}
		}

		private ActivityGroup EnsureOpenGroup()
		{
			if (_openGroup != null && !_openGroup.Sealed)
			{
				return _openGroup;
			}
			int num = ++_nextGroupSequence;
			_openGroup = new ActivityGroup
			{
				Id = "subagent-group-" + Guid.NewGuid().ToString("N"),
				Title = "SubAgent 批次 " + num
			};
			return _openGroup;
		}
	}

	private sealed class TrackedActivity
	{
		public int Sequence { get; set; }

		public string ActivityId { get; set; }

		public string AgentName { get; set; }

		public string Title { get; set; }

		public string Status { get; set; }

		public string ResultPreview { get; set; }

		public string UpdatedAt { get; set; }

		public string ActivityGroupId { get; set; }

		public string ActivityGroupTitle { get; set; }

		public bool Claimed { get; set; }
	}

	private sealed class ActivityGroup
	{
		public string Id { get; set; }

		public string Title { get; set; }

		public bool Sealed { get; set; }
	}

	private sealed class TurnScope : IDisposable
	{
		private readonly State _previous;

		private bool _disposed;

		public TurnScope(State previous)
		{
			_previous = previous;
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				CurrentState.Value = _previous;
			}
		}
	}

	private sealed class PendingRegistration : IDisposable
	{
		private readonly State _state;

		private readonly TrackedActivity _activity;

		private bool _disposed;

		public PendingRegistration(State state, TrackedActivity activity)
		{
			_state = state;
			_activity = activity;
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				_state.RemovePending(_activity);
			}
		}
	}

	private sealed class NullDisposable : IDisposable
	{
		public static readonly NullDisposable Instance = new NullDisposable();

		private NullDisposable()
		{
		}

		public void Dispose()
		{
		}
	}

	private const int MaxTextLength = 2400;

	private static readonly AsyncLocal<State> CurrentState = new AsyncLocal<State>();

	public static IDisposable BeginTurn()
	{
		State value = CurrentState.Value;
		CurrentState.Value = new State();
		return new TurnScope(value);
	}

	public static IDisposable RegisterStartRequest(string agentName, string description)
	{
		State value = CurrentState.Value;
		if (value == null)
		{
			return NullDisposable.Instance;
		}
		TrackedActivity activity = value.Register(agentName, description);
		return new PendingRegistration(value, activity);
	}

	public static SubAgentActivityDescriptor ClaimActivity(string agentName, string requestedDescription, string fallbackTitle)
	{
		State value = CurrentState.Value;
		if (value == null)
		{
			return new SubAgentActivityDescriptor(CreateActivityId(), Normalize(requestedDescription) ?? Normalize(fallbackTitle) ?? Normalize(agentName) ?? "SubAgent", null, null);
		}
		return value.Claim(agentName, requestedDescription, fallbackTitle);
	}

	public static void SealLaunchGroup(string toolName)
	{
		if (IsBackgroundCoordinationBoundary(toolName))
		{
			CurrentState.Value?.SealOpenGroup();
		}
	}

	public static void ObserveActivityUpdate(SubAgentActivityUpdate update)
	{
		if (update != null)
		{
			CurrentState.Value?.Observe(update);
		}
	}

	public static void FlushCurrentAtTurnEnd(bool cancelled)
	{
		IReadOnlyList<SubAgentActivityUpdate> readOnlyList = CurrentState.Value?.BuildTurnEndUpdates(cancelled);
		if (readOnlyList == null)
		{
			return;
		}
		foreach (SubAgentActivityUpdate item in readOnlyList)
		{
			SubAgentActivityRelay.Publish(item);
		}
	}

	private static bool IsBackgroundCoordinationBoundary(string toolName)
	{
		if (string.IsNullOrWhiteSpace(toolName))
		{
			return false;
		}
		if (!toolName.StartsWith("background_agents_", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (!string.Equals(toolName, "background_agents_start_task", StringComparison.OrdinalIgnoreCase))
		{
			return !string.Equals(toolName, "background_agents_create_task", StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	private static string CreateActivityId()
	{
		return "subagent-" + Guid.NewGuid().ToString("N");
	}

	private static string Normalize(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return null;
		}
		string text = string.Join(" ", value.Split((char[])null, StringSplitOptions.RemoveEmptyEntries));
		if (text.Length > 2400)
		{
			return text.Substring(0, 2400) + "...";
		}
		return text;
	}

	private static bool Matches(string left, string right)
	{
		if (!string.IsNullOrWhiteSpace(left) && !string.IsNullOrWhiteSpace(right))
		{
			return string.Equals(left, right, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	private static bool IsTerminal(string status)
	{
		if (!string.Equals(status, "completed", StringComparison.OrdinalIgnoreCase) && !string.Equals(status, "failed", StringComparison.OrdinalIgnoreCase) && !string.Equals(status, "cancelled", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(status, "detached", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}
}
