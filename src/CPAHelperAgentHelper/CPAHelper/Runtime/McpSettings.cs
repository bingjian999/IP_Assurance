using System.Collections.Generic;

namespace CPAHelper.Agent.Runtime;

public sealed class McpSettings
{
	public List<McpServerConfig> Servers { get; set; } = new List<McpServerConfig>();
}
