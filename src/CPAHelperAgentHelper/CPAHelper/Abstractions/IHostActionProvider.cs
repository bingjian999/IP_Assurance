using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.Abstractions;

public interface IHostActionProvider
{
	Task<IReadOnlyList<HostActionInfo>> GetActionsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<HostContextItem> InvokeAsync(string actionId, HostActionInvokeRequest request, CancellationToken cancellationToken = default(CancellationToken));
}
