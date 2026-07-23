using System;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Adapters;
using CPAHelper.Agent.Runtime;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopTurnLifecycleScope
{
	private readonly Action _rejectPendingApprovals;

	private readonly Action _clearActiveTurn;

	private readonly CancellationTokenSource _heartbeatCts;

	private readonly Task _heartbeatTask;

	private CancellationTokenSource _preparingToolStatusCts;

	private Task _preparingToolStatusTask;

	private readonly InternalToolVisibilityState _internalToolVisibilityState;

	private readonly IDisposable _subAgentActivityScope;

	private bool _disposed;

	public ActiveSseStream Stream { get; }

	public VisibleTurnRecorder Recorder { get; }

	public DesktopTurnLifecycleScope(IArtifactSink artifactSink, IApprovalService approvalService, IToolInvocationSink toolInvocationSink, ISubAgentActivitySink subAgentActivitySink, ActiveSseStream stream, VisibleTurnRecorder recorder, Action<ActiveSseStream, VisibleTurnRecorder> setActiveTurn, Action clearActiveTurn, Action rejectPendingApprovals, TimeSpan heartbeatInterval)
	{
		Stream = stream ?? throw new ArgumentNullException("stream");
		Recorder = recorder ?? throw new ArgumentNullException("recorder");
		_clearActiveTurn = clearActiveTurn ?? throw new ArgumentNullException("clearActiveTurn");
		_rejectPendingApprovals = rejectPendingApprovals ?? throw new ArgumentNullException("rejectPendingApprovals");
		ArtifactSinkRelay.SetCurrent(artifactSink);
		ApprovalServiceRelay.SetCurrent(approvalService);
		ToolInvocationRelay.SetCurrent(toolInvocationSink);
		_internalToolVisibilityState = new InternalToolVisibilityState();
		InternalToolVisibilityRelay.SetCurrent(_internalToolVisibilityState);
		_subAgentActivityScope = SubAgentActivityCoordinator.BeginTurn();
		SubAgentActivityRelay.SetCurrent(subAgentActivitySink);
		setActiveTurn?.Invoke(Stream, Recorder);
		Stream.MarkModelActivity();
		_heartbeatCts = new CancellationTokenSource();
		_heartbeatTask = Stream.StartHeartbeatAsync(heartbeatInterval, _heartbeatCts.Token);
	}

	public void StartPreparingToolStatus(TimeSpan delay, string message, CancellationToken cancellationToken)
	{
		ThrowIfDisposed();
		if (_preparingToolStatusCts != null)
		{
			throw new InvalidOperationException("Preparing-tool status is already running.");
		}
		_preparingToolStatusCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
		_preparingToolStatusTask = Stream.StartPreparingToolStatusAsync(delay, message, _preparingToolStatusCts.Token);
	}

	public async Task StopPreparingToolStatusAsync()
	{
		CancellationTokenSource cts = _preparingToolStatusCts;
		Task preparingToolStatusTask = _preparingToolStatusTask;
		if (cts == null)
		{
			return;
		}
		_preparingToolStatusCts = null;
		_preparingToolStatusTask = null;
		try
		{
			cts.Cancel();
			await ObserveBackgroundTaskQuietlyAsync(preparingToolStatusTask).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			cts.Dispose();
		}
	}

	public Task DisposeAsync()
	{
		if (_disposed)
		{
			return Task.CompletedTask;
		}
		_disposed = true;
		_rejectPendingApprovals();
		Stream.ResetModelActivity();
		_clearActiveTurn();
		ArtifactSinkRelay.ClearCurrent();
		ApprovalServiceRelay.ClearCurrent();
		ToolInvocationRelay.ClearCurrent();
		InternalToolVisibilityRelay.ClearCurrent();
		SubAgentActivityRelay.ClearCurrent();
		_subAgentActivityScope.Dispose();
		return StopBackgroundTasksAsync();
	}

	private async Task StopBackgroundTasksAsync()
	{
		_ = 1;
		try
		{
			await StopPreparingToolStatusAsync().ConfigureAwait(continueOnCapturedContext: false);
			_heartbeatCts.Cancel();
			await ObserveBackgroundTaskQuietlyAsync(_heartbeatTask).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			_heartbeatCts.Dispose();
		}
	}

	private void ThrowIfDisposed()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("DesktopTurnLifecycleScope");
		}
	}

	private static async Task ObserveBackgroundTaskQuietlyAsync(Task task)
	{
		if (task == null)
		{
			return;
		}
		try
		{
			await task.ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (OperationCanceledException)
		{
		}
		catch
		{
		}
	}
}
