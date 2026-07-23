using System.Threading;
using CPAHelper.Agent.Abstractions;

namespace CPAHelper.Agent.Adapters;

public class ArtifactSinkRelay : IArtifactSink
{
	private static readonly AsyncLocal<IArtifactSink> _current = new AsyncLocal<IArtifactSink>();

	public static void SetCurrent(IArtifactSink sink)
	{
		_current.Value = sink;
	}

	public static void ClearCurrent()
	{
		_current.Value = null;
	}

	public void Publish(AgentArtifact artifact)
	{
		_current.Value?.Publish(artifact);
	}
}
