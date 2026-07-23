using System.Collections.Generic;

namespace CPAHelper.Agent.Runtime;

public sealed class McpSettingsImportPreview
{
	public List<McpServerConfig> Servers { get; set; } = new List<McpServerConfig>();

	public List<McpSettingsImportIssue> Unsupported { get; set; } = new List<McpSettingsImportIssue>();

	public List<string> Conflicts { get; set; } = new List<string>();
}
