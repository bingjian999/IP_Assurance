namespace CPAHelper.Agent.Abstractions;

public interface IArtifactSink
{
	void Publish(AgentArtifact artifact);
}
