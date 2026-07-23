namespace CPAHelper.Agent.Runtime;

public sealed class McpSettingsSnapshot
{
	public string Path { get; }

	public McpSettings Settings { get; }

	internal McpSettingsSnapshot(string path, McpSettings settings)
	{
		Path = path;
		Settings = settings ?? new McpSettings();
	}
}
