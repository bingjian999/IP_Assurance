namespace CPAHelper.Agent.Runtime;

public sealed class McpWarmupServerStatus
{
	public string Id { get; set; }

	public string Name { get; set; }

	public bool Enabled { get; set; }

	public string State { get; set; }

	public int ToolCount { get; set; }

	public string Error { get; set; }
}
