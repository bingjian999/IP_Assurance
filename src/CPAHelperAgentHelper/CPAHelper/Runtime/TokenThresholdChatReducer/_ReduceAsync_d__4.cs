using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Agents.AI.Compaction;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class TokenThresholdChatReducer : IChatReducer
{
	private readonly IChatReducer _inner;

	private readonly IChatReducer _metricsReducer;

	private readonly int _triggerTokens;

	internal TokenThresholdChatReducer(IChatReducer inner, int triggerTokens, int targetTokens, int hardLimitTokens)
	{
		_inner = inner ?? throw new ArgumentNullException("inner");
		_triggerTokens = Math.Max(1, triggerTokens);
		_metricsReducer = new MafCompactionMetricsStrategy("history-summary-gate", _triggerTokens, Math.Max(1, targetTokens), Math.Max(_triggerTokens + 1, hardLimitTokens)).AsChatReducer();
	}

	public async Task<IEnumerable<ChatMessage>> ReduceAsync(IEnumerable<ChatMessage> messages, CancellationToken cancellationToken)
	{
		IList<ChatMessage> materializedMessages = (messages as IList<ChatMessage>) ?? messages?.ToList() ?? new List<ChatMessage>();
		MafCompactionMetricsSnapshot snapshot = null;
		using (MafCompactionMetrics.BeginObserve(delegate(MafCompactionMetricsSnapshot metrics)
		{
			snapshot = metrics;
		}))
		{
			await _metricsReducer.ReduceAsync(materializedMessages, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		if (snapshot == null || snapshot.IncludedTokenCount <= _triggerTokens)
		{
			return materializedMessages;
		}
		ObservableChatReducer.PublishStatus("compacting", "正在压缩较长上下文...");
		IEnumerable<ChatMessage> result = await _inner.ReduceAsync(materializedMessages, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		ObservableChatReducer.PublishStatus("analyzing", "上下文整理完成，正在完成响应...");
		return result;
	}
}
