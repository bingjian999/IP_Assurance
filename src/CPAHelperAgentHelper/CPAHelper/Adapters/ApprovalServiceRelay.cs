using System;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;

namespace CPAHelper.Agent.Adapters;

public sealed class ApprovalServiceRelay : IApprovalService
{
	private static readonly AsyncLocal<IApprovalService> CurrentService = new AsyncLocal<IApprovalService>();

	public static void SetCurrent(IApprovalService service)
	{
		CurrentService.Value = service;
	}

	public static void ClearCurrent()
	{
		CurrentService.Value = null;
	}

	public Task<bool> RequestApprovalAsync(ApprovalRequest request, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (CurrentService.Value == null)
		{
			throw new InvalidOperationException("No active approval service is available for the current request.");
		}
		return CurrentService.Value.RequestApprovalAsync(request, cancellationToken);
	}
}
