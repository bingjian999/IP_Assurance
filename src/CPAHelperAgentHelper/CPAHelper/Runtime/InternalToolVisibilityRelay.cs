using System.Threading;

namespace CPAHelper.Agent.Runtime;

internal static class InternalToolVisibilityRelay
{
	private static readonly AsyncLocal<InternalToolVisibilityState> CurrentState = new AsyncLocal<InternalToolVisibilityState>();

	internal static InternalToolVisibilityState Current => CurrentState.Value;

	internal static void SetCurrent(InternalToolVisibilityState state)
	{
		CurrentState.Value = state;
	}

	internal static void ClearCurrent()
	{
		CurrentState.Value = null;
	}

	internal static void RecordHiddenToolResult(string toolName)
	{
		CurrentState.Value?.RecordHiddenToolResult(toolName);
	}

	internal static bool TryConsumeHiddenToolResult()
	{
		return CurrentState.Value?.TryConsumeHiddenToolResult() ?? false;
	}
}
