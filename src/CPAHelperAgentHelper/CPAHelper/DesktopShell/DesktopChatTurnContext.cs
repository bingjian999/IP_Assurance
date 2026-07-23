using System.Text;
using System.Threading;
using CPAHelper.Agent.Runtime;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopChatTurnContext
{
	public string ThreadId { get; }

	public IDesktopAgentRuntime AgentRuntime { get; }

	public IDesktopApprovalBridge ApprovalUiBridge { get; }

	public ActiveSseStream Stream { get; }

	public VisibleTurnRecorder Recorder { get; }

	public AgentSession AgentSession { get; }

	public string Instructions { get; }

	public string ModelUserMessage { get; }

	public CancellationToken CancellationToken { get; }

	public StringBuilder FullResponse { get; } = new StringBuilder();

	public bool StreamedAnyAnswerText { get; set; }

	public UsageDetails AggregatedUsage { get; set; }

	public MafCompactionMetricsSnapshot LatestCompactionMetrics { get; set; }

	public MafCompactionMetricsSnapshot LatestAfterCompactionMetrics { get; set; }

	public bool CompactionStatusEmitted { get; set; }

	public bool CompactionTriggeredThisTurn { get; set; }

	public string AssistantText => FullResponse.ToString().Trim();

	public DesktopChatTurnContext(string threadId, IDesktopAgentRuntime agentRuntime, IDesktopApprovalBridge approvalUiBridge, ActiveSseStream stream, VisibleTurnRecorder recorder, AgentSession agentSession, string instructions, string modelUserMessage, CancellationToken cancellationToken)
	{
		ThreadId = threadId;
		AgentRuntime = agentRuntime;
		ApprovalUiBridge = approvalUiBridge;
		Stream = stream;
		Recorder = recorder;
		AgentSession = agentSession;
		Instructions = instructions;
		ModelUserMessage = modelUserMessage;
		CancellationToken = cancellationToken;
	}

	public UsageDetails ResolveUsage()
	{
		return StreamingUpdateExtractor.ResolveUsageDetails(AggregatedUsage);
	}

	public MafCompactionMetricsSnapshot PreferAfterCompactionMetrics()
	{
		if (!CompactionTriggeredThisTurn || LatestAfterCompactionMetrics == null)
		{
			return LatestCompactionMetrics;
		}
		return LatestAfterCompactionMetrics;
	}
}
