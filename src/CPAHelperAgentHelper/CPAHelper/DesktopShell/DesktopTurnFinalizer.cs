using System;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Adapters;
using CPAHelper.Agent.Contracts;
using CPAHelper.Agent.Runtime;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopTurnFinalizer
{
	private readonly string _threadId;

	private readonly Func<string, Task> _persistAgentSessionAsync;

	private readonly Func<string, MafCompactionMetricsSnapshot, CancellationToken, Task<MafCompactionMetricsSnapshot>> _refreshCompactionMetricsAsync;

	public DesktopTurnFinalizer(string threadId, Func<string, Task> persistAgentSessionAsync, Func<string, MafCompactionMetricsSnapshot, CancellationToken, Task<MafCompactionMetricsSnapshot>> refreshCompactionMetricsAsync)
	{
		_threadId = threadId ?? string.Empty;
		_persistAgentSessionAsync = persistAgentSessionAsync ?? throw new ArgumentNullException("persistAgentSessionAsync");
		_refreshCompactionMetricsAsync = refreshCompactionMetricsAsync ?? throw new ArgumentNullException("refreshCompactionMetricsAsync");
	}

	public async Task FinalizeAsync(DesktopTurnFinalizationRequest request)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (request.Stream == null)
		{
			throw new ArgumentNullException("Stream");
		}
		SubAgentActivityCoordinator.FlushCurrentAtTurnEnd(string.Equals(request.FinishReason, "cancel", StringComparison.OrdinalIgnoreCase));
		MafCompactionMetricsSnapshot prePersistCompactionMetrics = request.CompactionMetrics;
		if (request.ShouldPersistTurn && request.Recorder != null)
		{
			request.Recorder.Persist(request.AssistantText ?? string.Empty, request.FinishReason);
			prePersistCompactionMetrics = await _refreshCompactionMetricsAsync(request.Instructions, request.CompactionMetrics, request.CancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			bool shouldShowHistoryCompaction = !request.HasAfterCompactionMetrics && prePersistCompactionMetrics != null && prePersistCompactionMetrics.ExceedsTrigger;
			if (shouldShowHistoryCompaction)
			{
				request.Stream.EmitStatus("compacting", "正在压缩较长上下文...");
			}
			using (ObservableChatReducer.BeginObserve(delegate(string status, string message)
			{
				request.Stream.EmitStatus(status, message);
			}))
			{
				await _persistAgentSessionAsync(request.Instructions).ConfigureAwait(continueOnCapturedContext: false);
			}
			if (shouldShowHistoryCompaction)
			{
				request.Stream.EmitStatus("analyzing", "上下文整理完成，正在完成响应...");
			}
		}
		MafCompactionMetricsSnapshot latestCompactionMetrics = prePersistCompactionMetrics;
		if (request.HasAfterCompactionMetrics)
		{
			await _refreshCompactionMetricsAsync(request.Instructions, latestCompactionMetrics, request.CancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		else
		{
			latestCompactionMetrics = await _refreshCompactionMetricsAsync(request.Instructions, latestCompactionMetrics, request.CancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		JsonSessionIndexManager.SessionSummary sessionSummary = JsonSessionIndexManager.GetSessionSummary(_threadId);
		if (sessionSummary != null)
		{
			await request.Stream.WriteAsync(ToSessionSummaryEvent(sessionSummary)).ConfigureAwait(continueOnCapturedContext: false);
		}
		request.Stream.EmitStatus("finalizing", request.StatusMessage ?? "Finalizing response.");
		await request.Stream.EmitHarnessStateAsync(request.AgentSession, isRunning: false).ConfigureAwait(continueOnCapturedContext: false);
		await request.Stream.WriteAsync(CreateFinishEvent(request.FinishReason, request.DurationMs, request.Usage, latestCompactionMetrics, DateTime.Now)).ConfigureAwait(continueOnCapturedContext: false);
	}

	internal static FinishEvent CreateFinishEvent(string finishReason, long durationMs, UsageDetails usage, MafCompactionMetricsSnapshot compactionMetrics, DateTime finishedAt)
	{
		return new FinishEvent
		{
			FinishReason = finishReason,
			DurationMs = durationMs,
			InputTokens = usage?.InputTokenCount,
			OutputTokens = usage?.OutputTokenCount,
			TotalTokens = usage?.TotalTokenCount,
			ContextTokens = compactionMetrics?.IncludedTokenCount,
			ContextTriggerTokens = compactionMetrics?.TriggerTokens,
			ContextTargetTokens = compactionMetrics?.TargetTokens,
			ContextHardLimitTokens = compactionMetrics?.HardLimitTokens,
			FinishedAt = finishedAt.ToString("yyyy-MM-dd HH:mm:ss")
		};
	}

	internal static SessionSummaryEvent ToSessionSummaryEvent(JsonSessionIndexManager.SessionSummary summary)
	{
		if (summary == null)
		{
			return null;
		}
		return new SessionSummaryEvent
		{
			SessionId = summary.SessionId,
			Title = summary.Title,
			IsCustomTitle = summary.IsCustomTitle,
			IsTitleGenerating = summary.IsTitleGenerating,
			CreatedAt = summary.CreatedAt,
			UpdatedAt = summary.UpdatedAt,
			MessageCount = summary.MessageCount
		};
	}
}
