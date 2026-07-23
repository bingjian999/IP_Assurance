using System;
using System.Threading;
using CPAHelper.Agent.Abstractions;

namespace CPAHelper.Agent.Adapters;

public static class SubAgentActivityRelay
{
	private sealed class ActivityScope : IDisposable
	{
		private readonly string _previous;

		private bool _disposed;

		public ActivityScope(string previous)
		{
			_previous = previous;
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				CurrentActivity.Value = _previous;
			}
		}
	}

	private static readonly AsyncLocal<ISubAgentActivitySink> CurrentSink = new AsyncLocal<ISubAgentActivitySink>();

	private static readonly AsyncLocal<string> CurrentActivity = new AsyncLocal<string>();

	public static string CurrentActivityId => CurrentActivity.Value;

	public static void SetCurrent(ISubAgentActivitySink sink)
	{
		CurrentSink.Value = sink;
	}

	public static void ClearCurrent()
	{
		CurrentSink.Value = null;
		CurrentActivity.Value = null;
	}

	public static void Publish(SubAgentActivityUpdate update)
	{
		CurrentSink.Value?.PublishSubAgentActivity(update);
	}

	public static IDisposable EnterActivity(string activityId)
	{
		string value = CurrentActivity.Value;
		CurrentActivity.Value = activityId;
		return new ActivityScope(value);
	}
}
