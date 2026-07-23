namespace CPAHelper.Agent.Runtime;

internal sealed class McpWarmupBuildResult
{
	internal McpToolProvider.McpCatalogSnapshot Snapshot { get; }

	internal McpWarmupStatus Status { get; }

	internal McpWarmupBuildResult(McpToolProvider.McpCatalogSnapshot snapshot, McpWarmupStatus status)
	{
		Snapshot = snapshot;
		Status = status;
	}
}
