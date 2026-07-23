using System.Collections.Generic;

namespace CPAHelper.Agent.Runtime;

public sealed class McpTestResult
{
	public bool Success { get; set; }

	public string Message { get; set; }

	public List<McpToolInfo> Tools { get; set; } = new List<McpToolInfo>();
}
