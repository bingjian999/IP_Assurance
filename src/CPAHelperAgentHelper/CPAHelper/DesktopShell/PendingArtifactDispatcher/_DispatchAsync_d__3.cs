using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class PendingArtifactDispatcher
{
	private readonly ConcurrentQueue<AgentArtifact> _artifacts = new ConcurrentQueue<AgentArtifact>();

	public void Enqueue(AgentArtifact artifact)
	{
		if (artifact != null)
		{
			_artifacts.Enqueue(artifact);
		}
	}

	public void Clear()
	{
		AgentArtifact result;
		while (_artifacts.TryDequeue(out result))
		{
		}
	}

	public async Task DispatchAsync(Action<AgentArtifact> onArtifact, ActiveSseStream stream)
	{
		AgentArtifact result;
		while (_artifacts.TryDequeue(out result))
		{
			try
			{
				onArtifact?.Invoke(result);
			}
			catch
			{
			}
			if (stream != null)
			{
				await stream.WriteAsync(new ArtifactEvent
				{
					ArtifactType = (result.Type ?? "unknown"),
					Title = result.Title,
					RecordCount = result.RecordCount
				}).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
	}
}
