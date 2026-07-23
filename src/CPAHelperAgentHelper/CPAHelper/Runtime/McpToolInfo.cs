using System.Collections.Generic;

namespace CPAHelper.Agent.Runtime;

public sealed class McpToolInfo
{
	public string Name { get; set; }

	public string RuntimeName { get; set; }

	public string Description { get; set; }

	public List<string> Groups { get; set; } = new List<string>();

	public bool RequireApproval { get; set; }
}
