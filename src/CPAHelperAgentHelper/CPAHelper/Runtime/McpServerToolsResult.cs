using System.Collections.Generic;

namespace CPAHelper.Agent.Runtime;

public sealed class McpServerToolsResult
{
	public bool Success { get; set; }

	public bool Enabled { get; set; }

	public string ServerId { get; set; }

	public string Message { get; set; }

	public List<McpToolInfo> Tools { get; set; } = new List<McpToolInfo>();
}
