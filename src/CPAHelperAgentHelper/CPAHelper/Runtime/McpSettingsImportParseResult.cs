using System.Collections.Generic;

namespace CPAHelper.Agent.Runtime;

internal sealed class McpSettingsImportParseResult
{
	public List<McpServerConfig> Servers { get; } = new List<McpServerConfig>();

	public List<McpSettingsImportIssue> Unsupported { get; } = new List<McpSettingsImportIssue>();
}
