using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal interface IDesktopApprovalBridge
{
	bool TryGetToolApprovalRequest(AgentResponseUpdate update, out List<ToolApprovalRequestContent> approvalRequests);

	Task<AIContent[]> RequestToolApprovalResponsesAsync(IReadOnlyList<ToolApprovalRequestContent> approvalRequests, CancellationToken cancellationToken);
}
