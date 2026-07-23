using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class ProviderBudgetAwareChatReducer : IChatReducer
{
	private readonly IChatReducer _normalReducer;

	private readonly IChatReducer _forcedReducer;

	private readonly IChatReducer _fallbackReducer;

	private readonly IProviderRequestBudgetEstimator _budgetEstimator;

	private readonly AgentChatRuntimeOptions.ResolvedSummaryOptions _summaryOptions;

	private readonly ChatOptions _budgetOptions;

	internal ProviderBudgetAwareChatReducer(IChatReducer normalReducer, IChatReducer forcedReducer, IChatReducer fallbackReducer, IProviderRequestBudgetEstimator budgetEstimator, AgentChatRuntimeOptions.ResolvedSummaryOptions summaryOptions, ChatOptions budgetOptions)
	{
		_normalReducer = normalReducer ?? throw new ArgumentNullException("normalReducer");
		_forcedReducer = forcedReducer ?? throw new ArgumentNullException("forcedReducer");
		_fallbackReducer = fallbackReducer ?? throw new ArgumentNullException("fallbackReducer");
		_budgetEstimator = budgetEstimator ?? throw new ArgumentNullException("budgetEstimator");
		_summaryOptions = summaryOptions ?? throw new ArgumentNullException("summaryOptions");
		_budgetOptions = budgetOptions ?? new ChatOptions();
	}

	public async Task<IEnumerable<ChatMessage>> ReduceAsync(IEnumerable<ChatMessage> messages, CancellationToken cancellationToken)
	{
		IReadOnlyList<ChatMessage> materializedMessages = (messages as IReadOnlyList<ChatMessage>) ?? messages?.ToList() ?? new List<ChatMessage>();
		IReadOnlyList<ChatMessage> originalMessages = materializedMessages;
		List<ChatMessage> normalMessages = AgentSessionSanitizer.SanitizeReducedMessagesPreservingLiveToolTail(originalMessages, await _normalReducer.ReduceAsync(materializedMessages, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		if (normalMessages.Count == 0)
		{
			normalMessages = materializedMessages.ToList();
		}
		ProviderRequestBudgetSnapshot providerRequestBudgetSnapshot = _budgetEstimator.Estimate(normalMessages, _budgetOptions, stream: true, _summaryOptions);
		ProviderBudgetDiagnostics.Log("history-save-after-normal", providerRequestBudgetSnapshot);
		if (!providerRequestBudgetSnapshot.ExceedsTrigger)
		{
			return normalMessages;
		}
		ProviderBudgetDiagnostics.Log("history-save-force", providerRequestBudgetSnapshot, "Action=force-compact", forceConsole: true);
		originalMessages = normalMessages;
		List<ChatMessage> forcedMessages = AgentSessionSanitizer.SanitizeReducedMessagesPreservingLiveToolTail(originalMessages, await _forcedReducer.ReduceAsync(normalMessages, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		if (forcedMessages.Count == 0)
		{
			forcedMessages = normalMessages;
		}
		ProviderRequestBudgetSnapshot providerRequestBudgetSnapshot2 = _budgetEstimator.Estimate(forcedMessages, _budgetOptions, stream: true, _summaryOptions);
		ProviderBudgetDiagnostics.Log("history-save-after-force", providerRequestBudgetSnapshot2, null, providerRequestBudgetSnapshot2.ExceedsHardLimit);
		if (!providerRequestBudgetSnapshot2.ExceedsHardLimit)
		{
			return forcedMessages;
		}
		originalMessages = forcedMessages;
		List<ChatMessage> list = AgentSessionSanitizer.SanitizeReducedMessagesPreservingLiveToolTail(originalMessages, await _fallbackReducer.ReduceAsync(forcedMessages, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		if (list.Count == 0)
		{
			list = forcedMessages;
		}
		ProviderRequestBudgetSnapshot snapshot = _budgetEstimator.Estimate(list, _budgetOptions, stream: true, _summaryOptions);
		ProviderBudgetDiagnostics.Log("history-save-after-fallback", snapshot, null, forceConsole: true);
		return list;
	}
}
