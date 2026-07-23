using System.Threading;
using CPAHelper.Agent.Runtime;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopTurnFinalizationRequest
{
	public ActiveSseStream Stream { get; set; }

	public AgentSession AgentSession { get; set; }

	public VisibleTurnRecorder Recorder { get; set; }

	public string Instructions { get; set; }

	public string AssistantText { get; set; }

	public string FinishReason { get; set; }

	public string StatusMessage { get; set; }

	public bool ShouldPersistTurn { get; set; }

	public long DurationMs { get; set; }

	public UsageDetails Usage { get; set; }

	public MafCompactionMetricsSnapshot CompactionMetrics { get; set; }

	public bool HasAfterCompactionMetrics { get; set; }

	public CancellationToken CancellationToken { get; set; }
}
