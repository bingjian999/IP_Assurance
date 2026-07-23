using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

public interface IUsageTrackingChatClient
{
	void ResetUsage();

	UsageDetails GetUsageSnapshot();
}
