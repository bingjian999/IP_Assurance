using System;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Runtime;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopAgentSessionServices
{
	private readonly string _threadId;

	private readonly Func<AgentSession> _getSession;

	private readonly Func<AgentSession, string, CancellationToken, Task> _saveSessionAsync;

	private readonly Func<AgentSession, string, CancellationToken, Task<MafCompactionMetricsSnapshot>> _refreshCompactionMetricsAsync;

	public DesktopAgentSessionServices(string threadId, Func<AgentSession> getSession, Func<AgentSession, string, CancellationToken, Task> saveSessionAsync, Func<AgentSession, string, CancellationToken, Task<MafCompactionMetricsSnapshot>> refreshCompactionMetricsAsync)
	{
		_threadId = threadId ?? string.Empty;
		_getSession = getSession ?? throw new ArgumentNullException("getSession");
		_saveSessionAsync = saveSessionAsync ?? throw new ArgumentNullException("saveSessionAsync");
		_refreshCompactionMetricsAsync = refreshCompactionMetricsAsync ?? throw new ArgumentNullException("refreshCompactionMetricsAsync");
	}

	public async Task PersistAgentSessionQuietlyAsync(string instructions)
	{
		AgentSession agentSession = _getSession();
		if (agentSession == null)
		{
			return;
		}
		try
		{
			using (MafCompactionMetrics.BeginObserve(LogHistoryCompactionMetrics))
			{
				await _saveSessionAsync(agentSession, instructions, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		catch (Exception exception)
		{
			AgentRuntimeLogger.Error("Failed to persist MAF agent session. ThreadId=" + _threadId, exception);
		}
	}

	public async Task<MafCompactionMetricsSnapshot> RefreshCompactionMetricsQuietlyAsync(string instructions, MafCompactionMetricsSnapshot fallback, CancellationToken cancellationToken)
	{
		AgentSession agentSession = _getSession();
		if (agentSession == null)
		{
			return fallback;
		}
		try
		{
			MafCompactionMetricsSnapshot mafCompactionMetricsSnapshot = await _refreshCompactionMetricsAsync(agentSession, instructions, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (mafCompactionMetricsSnapshot != null)
			{
				AgentRuntimeLogger.Info($"MAF compaction metrics snapshot. ThreadId={_threadId}; IncludedTokens={mafCompactionMetricsSnapshot.IncludedTokenCount}; TotalTokens={mafCompactionMetricsSnapshot.TotalTokenCount}; TriggerTokens={mafCompactionMetricsSnapshot.TriggerTokens}; TargetTokens={mafCompactionMetricsSnapshot.TargetTokens}; HardLimitTokens={mafCompactionMetricsSnapshot.HardLimitTokens}; IncludedMessages={mafCompactionMetricsSnapshot.IncludedMessageCount}; IncludedGroups={mafCompactionMetricsSnapshot.IncludedGroupCount}");
				return mafCompactionMetricsSnapshot;
			}
		}
		catch (Exception exception)
		{
			AgentRuntimeLogger.Error("Failed to refresh MAF compaction metrics. ThreadId=" + _threadId, exception);
		}
		return fallback;
	}

	private void LogHistoryCompactionMetrics(MafCompactionMetricsSnapshot metrics)
	{
		if (metrics != null && !string.IsNullOrWhiteSpace(metrics.Stage) && metrics.Stage.StartsWith("history-", StringComparison.Ordinal))
		{
			AgentRuntimeLogger.Info($"MAF history compaction metrics. ThreadId={_threadId}; Stage={metrics.Stage}; IncludedTokens={metrics.IncludedTokenCount}; TotalTokens={metrics.TotalTokenCount}; TriggerTokens={metrics.TriggerTokens}; TargetTokens={metrics.TargetTokens}; HardLimitTokens={metrics.HardLimitTokens}; IncludedMessages={metrics.IncludedMessageCount}; IncludedGroups={metrics.IncludedGroupCount}");
			if (metrics.Stage.EndsWith("-before", StringComparison.Ordinal) && metrics.ExceedsTrigger)
			{
				ObservableChatReducer.PublishStatus("compacting", "正在压缩较长上下文...");
			}
			else if (metrics.Stage.EndsWith("-after", StringComparison.Ordinal))
			{
				ObservableChatReducer.PublishStatus("analyzing", "上下文整理完成，正在完成响应...");
			}
		}
	}
}
