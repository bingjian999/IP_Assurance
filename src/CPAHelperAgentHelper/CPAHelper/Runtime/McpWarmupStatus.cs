using System.Collections.Generic;

namespace CPAHelper.Agent.Runtime;

public sealed class McpWarmupStatus
{
	public string State { get; set; }

	public string Message { get; set; }

	public int EnabledServerCount { get; set; }

	public int LoadedServerCount { get; set; }

	public int FailedServerCount { get; set; }

	public int TotalToolCount { get; set; }

	public List<McpWarmupServerStatus> Servers { get; set; } = new List<McpWarmupServerStatus>();
}
