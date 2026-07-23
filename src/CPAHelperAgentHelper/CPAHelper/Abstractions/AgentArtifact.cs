namespace CPAHelper.Agent.Abstractions;

public class AgentArtifact
{
	public string Type { get; set; }

	public string Title { get; set; }

	public object Data { get; set; }

	public int? RecordCount { get; set; }
}
