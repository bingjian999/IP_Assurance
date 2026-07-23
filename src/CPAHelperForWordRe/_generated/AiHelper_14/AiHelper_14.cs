using System;
using System.Diagnostics;
using System.Threading;
using AiConfigBootstrap;
using AiSseStreamService3;
using SseStreamInitializer;
using WordTableToolService;

namespace AiHelper_14;

internal static class AiHelper_14
{
	private static readonly SemaphoreSlim _semaphore;

	private static readonly AsyncLocal<int> vMtJclmkWo;

	private static long _queueIdCounter;

	public static T RunWithTelemetry<T>(string P_0, Func<T> P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("action");
		}
		if (vMtJclmkWo.Value > 0 || IsOnSyncContext())
		{
			return P_1();
		}
		long num = Interlocked.Increment(ref _queueIdCounter);
		Stopwatch stopwatch = Stopwatch.StartNew();
		_semaphore.Wait();
		stopwatch.Stop();
		Stopwatch stopwatch2 = Stopwatch.StartNew();
		vMtJclmkWo.Value += 1;
		try
		{
			if (stopwatch.ElapsedMilliseconds >= 25)
			{
				AiConfigBootstrap.LogInfo("[AI Tool][WordQueue] Enter: " + P_0 + "; QueueId=" + num + "; WaitMs=" + stopwatch.ElapsedMilliseconds);
			}
			return P_1();
		}
		finally
		{
			stopwatch2.Stop();
			vMtJclmkWo.Value = Math.Max(0, vMtJclmkWo.Value - 1);
			_semaphore.Release();
			if (stopwatch.ElapsedMilliseconds >= 25 || stopwatch2.ElapsedMilliseconds >= 1000)
			{
				AiConfigBootstrap.LogInfo("[AI Tool][WordQueue] Exit: " + P_0 + "; QueueId=" + num + "; WaitMs=" + stopwatch.ElapsedMilliseconds + "; RunMs=" + stopwatch2.ElapsedMilliseconds);
			}
		}
	}

	private static bool IsOnSyncContext()
	{
		SynchronizationContext syncContext = WordTableToolService.SyncContext;
		if (syncContext != null)
		{
			return SynchronizationContext.Current == syncContext;
		}
		return false;
	}

	static AiHelper_14()
	{
		SseStreamInitializer.InitializeRuntime();
		_semaphore = new SemaphoreSlim(1, 1);
		vMtJclmkWo = new AsyncLocal<int>();
	}
}
