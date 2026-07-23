namespace CPAHelper.Agent.Runtime;

internal sealed class AgentsFileSnapshot
{
	internal string Path { get; }

	internal string Content { get; }

	internal AgentsFileSnapshot(string path, string content)
	{
		Path = path;
		Content = content ?? string.Empty;
	}
}
