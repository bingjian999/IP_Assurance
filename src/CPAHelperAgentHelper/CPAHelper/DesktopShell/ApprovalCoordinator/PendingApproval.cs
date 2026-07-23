using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class ApprovalCoordinator
{
	private sealed class PendingApproval
	{
		public string ToolName { get; }

		public TaskCompletionSource<ApprovalDecision> Completion { get; }

		public PendingApproval(string toolName)
		{
			ToolName = toolName ?? string.Empty;
			Completion = new TaskCompletionSource<ApprovalDecision>(TaskCreationOptions.RunContinuationsAsynchronously);
		}
	}

	public sealed class ApprovalDecisionResult
	{
		public bool Approved { get; }

		public string ApprovalMode { get; }

		public bool AutoApproved { get; }

		public bool IsSessionToolApproval
		{
			get
			{
				if (Approved)
				{
					return string.Equals(ApprovalMode, "session-tool", StringComparison.OrdinalIgnoreCase);
				}
				return false;
			}
		}

		public ApprovalDecisionResult(bool approved, string approvalMode, bool autoApproved)
		{
			Approved = approved;
			ApprovalMode = (string.IsNullOrWhiteSpace(approvalMode) ? "once" : approvalMode);
			AutoApproved = autoApproved;
		}
	}

	private sealed class ApprovalDecision
	{
		public bool Approved { get; }

		public string ApprovalMode { get; }

		public bool AutoApproved { get; }

		public ApprovalDecision(bool approved, string approvalMode, bool autoApproved)
		{
			Approved = approved;
			ApprovalMode = (string.IsNullOrWhiteSpace(approvalMode) ? "once" : approvalMode);
			AutoApproved = autoApproved;
		}

		public static ApprovalDecision Rejected(string approvalMode)
		{
			return new ApprovalDecision(approved: false, approvalMode, autoApproved: false);
		}
	}

	private const string ApprovalModeOnce = "once";

	private const string ApprovalModeSessionTool = "session-tool";

	private readonly ConcurrentDictionary<string, PendingApproval> _pendingApprovals = new ConcurrentDictionary<string, PendingApproval>();

	public async Task<bool> RequestAsync(ApprovalRequest request, string threadId, StreamWriter writer, object syncRoot, Action<string, string> emitStatus, Action<ApprovalRequestEvent> onApprovalRequested = null, Action<ApprovalResolvedEvent> onApprovalResolved = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await RequestDecisionAsync(request, threadId, writer, syncRoot, emitStatus, onApprovalRequested, onApprovalResolved, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)).Approved;
	}

	public async Task<ApprovalDecisionResult> RequestDecisionAsync(ApprovalRequest request, string threadId, StreamWriter writer, object syncRoot, Action<string, string> emitStatus, Action<ApprovalRequestEvent> onApprovalRequested = null, Action<ApprovalResolvedEvent> onApprovalResolved = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (writer == null || syncRoot == null)
		{
			throw new InvalidOperationException("Approval requests can only be issued while a chat stream is active.");
		}
		string toolName = (request.ToolName ?? string.Empty).Trim();
		string requestId = "apr-" + Guid.NewGuid().ToString("N");
		ApprovalRequestEvent approvalRequestEvent = new ApprovalRequestEvent
		{
			RequestId = requestId,
			ThreadId = threadId,
			Title = (request.Title ?? "Confirm before continuing"),
			Message = (request.Message ?? "This action requires your approval before it can continue."),
			ToolName = toolName,
			ArgsPreview = (request.ArgsPreview ?? string.Empty),
			RiskLevel = (request.RiskLevel ?? "medium"),
			ConfirmLabel = (request.ConfirmLabel ?? "Continue"),
			CancelLabel = (request.CancelLabel ?? "Cancel"),
			ApprovalMode = "once",
			AutoApproved = false
		};
		PendingApproval pendingApproval = new PendingApproval(toolName);
		if (!_pendingApprovals.TryAdd(requestId, pendingApproval))
		{
			throw new InvalidOperationException("Failed to register the approval request.");
		}
		int timeoutSeconds = ((request.TimeoutSeconds > 0) ? request.TimeoutSeconds : 60);
		onApprovalRequested?.Invoke(approvalRequestEvent);
		await SseEventWriter.WriteAsync(writer, approvalRequestEvent, syncRoot).ConfigureAwait(continueOnCapturedContext: false);
		emitStatus?.Invoke("waiting_approval", "Waiting for your approval.");
		ApprovalDecision decision = ApprovalDecision.Rejected("once");
		try
		{
			if (await Task.WhenAny(pendingApproval.Completion.Task, Task.Delay(TimeSpan.FromSeconds(timeoutSeconds), cancellationToken)).ConfigureAwait(continueOnCapturedContext: false) == pendingApproval.Completion.Task && pendingApproval.Completion.Task.Status == TaskStatus.RanToCompletion)
			{
				decision = pendingApproval.Completion.Task.Result;
			}
		}
		catch (OperationCanceledException)
		{
			decision = ApprovalDecision.Rejected("once");
		}
		finally
		{
			_pendingApprovals.TryRemove(requestId, out var _);
		}
		ApprovalResolvedEvent approvalResolvedEvent = new ApprovalResolvedEvent
		{
			RequestId = requestId,
			Approved = decision.Approved,
			ApprovalMode = decision.ApprovalMode,
			AutoApproved = decision.AutoApproved
		};
		onApprovalResolved?.Invoke(approvalResolvedEvent);
		await SseEventWriter.WriteAsync(writer, approvalResolvedEvent, syncRoot).ConfigureAwait(continueOnCapturedContext: false);
		return new ApprovalDecisionResult(decision.Approved, decision.ApprovalMode, decision.AutoApproved);
	}

	public bool Resolve(string requestId, bool approved, string approvalMode = null)
	{
		if (string.IsNullOrWhiteSpace(requestId))
		{
			return false;
		}
		if (_pendingApprovals.TryGetValue(requestId, out var value))
		{
			return value.Completion.TrySetResult(new ApprovalDecision(approved, NormalizeApprovalMode(approved, approvalMode), autoApproved: false));
		}
		return false;
	}

	public void RejectPending()
	{
		foreach (KeyValuePair<string, PendingApproval> pendingApproval in _pendingApprovals)
		{
			pendingApproval.Value.Completion.TrySetResult(ApprovalDecision.Rejected("once"));
		}
		_pendingApprovals.Clear();
	}

	private static string NormalizeApprovalMode(bool approved, string approvalMode)
	{
		if (approved && string.Equals(approvalMode, "session-tool", StringComparison.OrdinalIgnoreCase))
		{
			return "session-tool";
		}
		return "once";
	}
}
