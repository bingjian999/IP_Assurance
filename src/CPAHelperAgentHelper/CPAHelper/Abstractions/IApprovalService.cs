using System.Threading;
using System.Threading.Tasks;

namespace CPAHelper.Agent.Abstractions;

public interface IApprovalService
{
	Task<bool> RequestApprovalAsync(ApprovalRequest request, CancellationToken cancellationToken = default(CancellationToken));
}
