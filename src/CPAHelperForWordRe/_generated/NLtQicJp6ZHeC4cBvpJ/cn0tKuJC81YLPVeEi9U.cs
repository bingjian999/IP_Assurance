using System;
using System.Diagnostics;
using System.Threading;
using dL7TFPsQbAGqPywtHUK;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;

namespace NLtQicJp6ZHeC4cBvpJ;

internal static class cn0tKuJC81YLPVeEi9U
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
				yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[AI Tool][WordQueue] Enter: " + P_0 + "; QueueId=" + num + "; WaitMs=" + stopwatch.ElapsedMilliseconds);
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
				yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[AI Tool][WordQueue] Exit: " + P_0 + "; QueueId=" + num + "; WaitMs=" + stopwatch.ElapsedMilliseconds + "; RunMs=" + stopwatch2.ElapsedMilliseconds);
			}
		}
	}

	private static bool elBJ7bwmZd()
	{
		SynchronizationContext syncContext = eSfxffslhXbaGAjFNv1.SyncContext;
		if (syncContext != null)
		{
			return SynchronizationContext.Current == syncContext;
		}
		return false;
	}

	static cn0tKuJC81YLPVeEi9U()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		IDiJ5M4ayu = new SemaphoreSlim(1, 1);
		vMtJclmkWo = new AsyncLocal<int>();
	}
}
