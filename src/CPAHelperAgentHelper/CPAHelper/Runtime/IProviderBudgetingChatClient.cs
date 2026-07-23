using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal interface IProviderBudgetingChatClient
{
	IChatClient InnerChatClient { get; }

	IProviderRequestBudgetEstimator BudgetEstimator { get; }
}
