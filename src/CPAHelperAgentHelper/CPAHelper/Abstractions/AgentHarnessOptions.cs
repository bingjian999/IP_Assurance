namespace CPAHelper.Agent.Abstractions;

public class AgentHarnessOptions
{
	public bool? FileAccessEnabled { get; set; }

	public bool? FileMemoryEnabled { get; set; }

	public bool? SubAgentsEnabled { get; set; }

	public string FileAccessRoot { get; set; }

	public string FileMemoryRoot { get; set; }
}
