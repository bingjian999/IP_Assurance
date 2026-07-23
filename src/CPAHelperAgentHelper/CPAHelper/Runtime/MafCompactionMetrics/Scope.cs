using System;
using System.Threading;

namespace CPAHelper.Agent.Runtime;

internal static class MafCompactionMetrics
{
	private sealed class Scope : IDisposable
	{
		private readonly Action _dispose;

		private bool _disposed;

		internal Scope(Action dispose)
		{
			_dispose = dispose;
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				_dispose?.Invoke();
			}
		}
	}

	private static readonly AsyncLocal<Action<MafCompactionMetricsSnapshot>> CurrentObserver = new AsyncLocal<Action<MafCompactionMetricsSnapshot>>();

	internal static IDisposable BeginObserve(Action<MafCompactionMetricsSnapshot> observer)
	{
		Action<MafCompactionMetricsSnapshot> previous = CurrentObserver.Value;
		CurrentObserver.Value = delegate(MafCompactionMetricsSnapshot snapshot)
		{
			previous?.Invoke(snapshot);
			observer?.Invoke(snapshot);
		};
		return new Scope(delegate
		{
			CurrentObserver.Value = previous;
		});
	}

	internal static void Publish(MafCompactionMetricsSnapshot snapshot)
	{
		if (snapshot != null)
		{
			CurrentObserver.Value?.Invoke(snapshot);
		}
	}
}
