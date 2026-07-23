using System.Threading;

namespace CPAHelper.Agent.Runtime;

internal sealed class InternalToolVisibilityState
{
	private int _pendingHiddenToolResults;

	internal int PendingHiddenToolResultCount => Volatile.Read(ref _pendingHiddenToolResults);

	internal void RecordHiddenToolResult(string toolName)
	{
		if (InternalToolVisibilityPolicy.ShouldSuppressToolResultMirror(toolName))
		{
			Interlocked.Increment(ref _pendingHiddenToolResults);
		}
	}

	internal bool TryConsumeHiddenToolResult()
	{
		int num;
		do
		{
			num = Volatile.Read(ref _pendingHiddenToolResults);
			if (num <= 0)
			{
				return false;
			}
		}
		while (Interlocked.CompareExchange(ref _pendingHiddenToolResults, num - 1, num) != num);
		return true;
	}
}
