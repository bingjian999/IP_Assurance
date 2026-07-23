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
	private static readonly SemaphoreSlim IDiJ5M4ayu;

	private static readonly AsyncLocal<int> vMtJclmkWo;

	private static long iByJer1iZW;

	public static RSPKsxJn4mY9UNSKay8 no9JOmnkBj<RSPKsxJn4mY9UNSKay8>(string P_0, Func<RSPKsxJn4mY9UNSKay8> P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("action");
		}
		if (vMtJclmkWo.Value > 0 || elBJ7bwmZd())
		{
			return P_1();
		}
		long num = Interlocked.Increment(ref iByJer1iZW);
		Stopwatch stopwatch = Stopwatch.StartNew();
		IDiJ5M4ayu.Wait();
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
			IDiJ5M4ayu.Release();
			if (stopwatch.ElapsedMilliseconds >= 25 || stopwatch2.ElapsedMilliseconds >= 1000)
			{
				AiConfigBootstrap.LogInfo("[AI Tool][WordQueue] Exit: " + P_0 + "; QueueId=" + num + "; WaitMs=" + stopwatch.ElapsedMilliseconds + "; RunMs=" + stopwatch2.ElapsedMilliseconds);
			}
		}
	}

	private static bool elBJ7bwmZd()
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
		IDiJ5M4ayu = new SemaphoreSlim(1, 1);
		vMtJclmkWo = new AsyncLocal<int>();
	}
}
