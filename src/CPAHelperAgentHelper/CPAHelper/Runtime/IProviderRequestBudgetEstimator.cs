using System.Collections.Generic;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal interface IProviderRequestBudgetEstimator
{
	ProviderRequestBudgetSnapshot Estimate(IEnumerable<ChatMessage> messages, ChatOptions options, bool stream, AgentChatRuntimeOptions.ResolvedSummaryOptions summaryOptions);
}
