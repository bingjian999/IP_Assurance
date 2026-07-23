using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CPAHelper.Agent.Contracts;
using CPAHelper.Agent.Runtime;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopChatTurnRunner
{
	public async Task<DesktopChatTurnResult> RunAsync(DesktopChatTurnContext context, Func<bool> continuePendingMessages = null)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		VisibleAssistantTextFilter visibleTextFilter = new VisibleAssistantTextFilter();
		try
		{
			DesktopChatRunStep desktopChatRunStep = DesktopChatRunStep.ForUserMessage(context.ModelUserMessage);
			while (desktopChatRunStep != null)
			{
				List<ToolApprovalRequestContent> pendingApprovalRequests = new List<ToolApprovalRequestContent>();
				IAsyncEnumerable<AgentResponseUpdate> asyncEnumerable = desktopChatRunStep.RunStreamingAsync(context, delegate(MafCompactionMetricsSnapshot metrics)
				{
					HandleCompactionMetrics(context, metrics);
				});
				await foreach (AgentResponseUpdate update in asyncEnumerable)
				{
					visibleTextFilter.BeginMessage(ResolveMessageKey(update));
					context.AggregatedUsage = StreamingUpdateExtractor.AggregateUsageDetails(context.AggregatedUsage, update);
					if (context.ApprovalUiBridge.TryGetToolApprovalRequest(update, out var approvalRequests))
					{
						pendingApprovalRequests.AddRange(approvalRequests);
						context.Stream.MarkModelActivity();
					}
					foreach (StreamingContent item in StreamingUpdateExtractor.ExtractContents(update))
					{
						context.Stream.MarkModelActivity();
						if (item.IsReasoning)
						{
							context.Stream.WriteSync(new ReasoningDeltaEvent
							{
								TextDelta = item.Text
							});
						}
						else
						{
							AppendVisibleAssistantText(context, visibleTextFilter.Filter(item.Text));
						}
					}
					await context.Stream.EmitHarnessStateAsync(context.AgentSession, isRunning: true).ConfigureAwait(continueOnCapturedContext: false);
					if (update.FinishReason.HasValue)
					{
						visibleTextFilter.CompleteMessage();
					}
				}
				desktopChatRunStep = ((pendingApprovalRequests.Count != 0) ? DesktopChatRunStep.ForApprovalResponses(await context.ApprovalUiBridge.RequestToolApprovalResponsesAsync(pendingApprovalRequests, context.CancellationToken).ConfigureAwait(continueOnCapturedContext: false)) : ((continuePendingMessages?.Invoke() ?? false) ? DesktopChatRunStep.ForMessages(Array.Empty<ChatMessage>()) : null));
			}
			AppendVisibleAssistantText(context, visibleTextFilter.Flush());
			return DesktopChatTurnResult.FromContext(context);
		}
		catch
		{
			AppendVisibleAssistantText(context, visibleTextFilter.Flush());
			throw;
		}
		finally
		{
			context.AgentRuntime.EndTurn(context.AgentSession, context.ThreadId);
		}
	}

	private static void AppendVisibleAssistantText(DesktopChatTurnContext context, string text)
	{
		if (!string.IsNullOrEmpty(text))
		{
			context.FullResponse.Append(text);
			context.Recorder.AppendText(text);
			context.StreamedAnyAnswerText = true;
			context.Stream.WriteSync(new TextDeltaEvent
			{
				TextDelta = text
			});
		}
	}

	private static string ResolveMessageKey(AgentResponseUpdate update)
	{
		if (update == null)
		{
			return null;
		}
		if (!string.IsNullOrWhiteSpace(update.MessageId))
		{
			return "message:" + update.MessageId;
		}
		if (!string.IsNullOrWhiteSpace(update.ResponseId))
		{
			return "response:" + update.ResponseId;
		}
		return null;
	}

	private static void HandleCompactionMetrics(DesktopChatTurnContext context, MafCompactionMetricsSnapshot metrics)
	{
		context.LatestCompactionMetrics = metrics;
		if (metrics != null)
		{
			AgentRuntimeLogger.Info($"MAF compaction metrics. ThreadId={context.ThreadId}; Stage={metrics.Stage}; IncludedTokens={metrics.IncludedTokenCount}; TotalTokens={metrics.TotalTokenCount}; TriggerTokens={metrics.TriggerTokens}; TargetTokens={metrics.TargetTokens}; HardLimitTokens={metrics.HardLimitTokens}; IncludedMessages={metrics.IncludedMessageCount}; IncludedGroups={metrics.IncludedGroupCount}");
			if (string.Equals(metrics.Stage, "before", StringComparison.OrdinalIgnoreCase) && metrics.ExceedsTrigger)
			{
				context.CompactionTriggeredThisTurn = true;
				context.CompactionStatusEmitted = true;
				context.Stream.EmitStatus("compacting", "正在整理较长上下文...");
			}
			else if (string.Equals(metrics.Stage, "history-summary-gate", StringComparison.OrdinalIgnoreCase) && metrics.ExceedsTrigger)
			{
				context.CompactionTriggeredThisTurn = true;
				context.CompactionStatusEmitted = true;
				context.Stream.EmitStatus("compacting", "正在压缩较长上下文...");
			}
			else if (string.Equals(metrics.Stage, "after", StringComparison.OrdinalIgnoreCase) && context.CompactionStatusEmitted)
			{
				context.LatestAfterCompactionMetrics = metrics;
				context.Stream.EmitStatus("analyzing", "正在继续处理请求...");
			}
			else if (string.Equals(metrics.Stage, "history-after", StringComparison.OrdinalIgnoreCase) && context.CompactionStatusEmitted)
			{
				context.LatestAfterCompactionMetrics = metrics;
				context.Stream.EmitStatus("analyzing", "上下文整理完成，正在完成响应...");
			}
		}
	}
}
