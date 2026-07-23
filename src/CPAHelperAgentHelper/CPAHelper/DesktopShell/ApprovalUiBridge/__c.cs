using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Contracts;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class ApprovalUiBridge : IDesktopApprovalBridge
{
	private readonly string _threadId;

	private readonly ApprovalCoordinator _approvalCoordinator;

	private readonly Func<ActiveSseStream> _streamAccessor;

	private readonly Func<VisibleTurnRecorder> _recorderAccessor;

	private readonly Func<IEnumerable<ToolMetadata>> _toolMetadataAccessor;

	public ApprovalUiBridge(string threadId, ApprovalCoordinator approvalCoordinator, Func<ActiveSseStream> streamAccessor, Func<VisibleTurnRecorder> recorderAccessor, Func<IEnumerable<ToolMetadata>> toolMetadataAccessor)
	{
		_threadId = threadId ?? string.Empty;
		_approvalCoordinator = approvalCoordinator ?? throw new ArgumentNullException("approvalCoordinator");
		_streamAccessor = streamAccessor ?? throw new ArgumentNullException("streamAccessor");
		_recorderAccessor = recorderAccessor ?? throw new ArgumentNullException("recorderAccessor");
		_toolMetadataAccessor = toolMetadataAccessor ?? ((Func<IEnumerable<ToolMetadata>>)(() => Array.Empty<ToolMetadata>()));
	}

	public async Task<bool> RequestApprovalAsync(ApprovalRequest request, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		ActiveSseStream activeSseStream = RequireActiveStream();
		VisibleTurnRecorder recorder = _recorderAccessor();
		return await _approvalCoordinator.RequestAsync(request, _threadId, activeSseStream.Writer, activeSseStream.SyncRoot, activeSseStream.EmitStatus, delegate(ApprovalRequestEvent approvalRequest)
		{
			recorder?.AppendApproval(approvalRequest);
		}, delegate(ApprovalResolvedEvent approvalResolved)
		{
			recorder?.ApplyApprovalResult(approvalResolved);
		}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task<AIContent[]> RequestToolApprovalResponsesAsync(IReadOnlyList<ToolApprovalRequestContent> approvalRequests, CancellationToken cancellationToken)
	{
		if (approvalRequests == null)
		{
			throw new ArgumentNullException("approvalRequests");
		}
		List<AIContent> responses = new List<AIContent>(approvalRequests.Count);
		foreach (ToolApprovalRequestContent approvalRequest in approvalRequests)
		{
			if (approvalRequest != null)
			{
				List<AIContent> list = responses;
				list.Add(await RequestToolApprovalResponseAsync(approvalRequest, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			}
		}
		return responses.ToArray();
	}

	public bool TryGetToolApprovalRequest(AgentResponseUpdate update, out List<ToolApprovalRequestContent> approvalRequests)
	{
		approvalRequests = update?.Contents?.OfType<ToolApprovalRequestContent>().ToList() ?? new List<ToolApprovalRequestContent>();
		return approvalRequests.Count > 0;
	}

	public bool Resolve(string requestId, bool approved, string approvalMode = null)
	{
		return _approvalCoordinator.Resolve(requestId, approved, approvalMode);
	}

	public void RejectPending()
	{
		_approvalCoordinator.RejectPending();
	}

	private async Task<AIContent> RequestToolApprovalResponseAsync(ToolApprovalRequestContent approvalRequest, CancellationToken cancellationToken)
	{
		if (approvalRequest == null)
		{
			throw new ArgumentNullException("approvalRequest");
		}
		ActiveSseStream activeSseStream = RequireActiveStream();
		VisibleTurnRecorder recorder = _recorderAccessor();
		ApprovalRequest request = BuildApprovalRequest(approvalRequest);
		ApprovalCoordinator.ApprovalDecisionResult approvalDecisionResult = await _approvalCoordinator.RequestDecisionAsync(request, _threadId, activeSseStream.Writer, activeSseStream.SyncRoot, activeSseStream.EmitStatus, delegate(ApprovalRequestEvent approvalEvent)
		{
			recorder?.AppendApproval(approvalEvent);
		}, delegate(ApprovalResolvedEvent resolvedEvent)
		{
			recorder?.ApplyApprovalResult(resolvedEvent);
		}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		if (approvalDecisionResult.IsSessionToolApproval)
		{
			return approvalRequest.CreateAlwaysApproveToolResponse("Approved by user for this session.");
		}
		return approvalRequest.CreateResponse(approvalDecisionResult.Approved, approvalDecisionResult.Approved ? "Approved by user." : "Rejected by user.");
	}

	private ApprovalRequest BuildApprovalRequest(ToolApprovalRequestContent approvalRequest)
	{
		string toolName = ExtractApprovalToolName(approvalRequest.ToolCall);
		ToolMetadata toolMetadata = (_toolMetadataAccessor() ?? Array.Empty<ToolMetadata>()).FirstOrDefault((ToolMetadata item) => string.Equals(item.Name, toolName, StringComparison.OrdinalIgnoreCase));
		string text = ((toolMetadata != null && toolMetadata.Groups?.Any((string group) => string.Equals(group, "risk.high", StringComparison.OrdinalIgnoreCase)) == true) ? "high" : "medium");
		return new ApprovalRequest
		{
			Title = "确认执行工具",
			Message = (string.IsNullOrWhiteSpace(toolName) ? "继续前需要你的确认。" : ("工具 " + toolName + " 需要在继续前获得确认。")),
			ToolName = toolName,
			ArgsPreview = BuildApprovalArgsPreview(approvalRequest.ToolCall),
			RiskLevel = text,
			ConfirmLabel = "继续",
			CancelLabel = "取消",
			TimeoutSeconds = (string.Equals(text, "high", StringComparison.OrdinalIgnoreCase) ? 120 : 60)
		};
	}

	private ActiveSseStream RequireActiveStream()
	{
		return _streamAccessor() ?? throw new InvalidOperationException("Approval requests can only be issued while a chat stream is active.");
	}

	private static string ExtractApprovalToolName(ToolCallContent toolCall)
	{
		if (!(toolCall is FunctionCallContent functionCallContent))
		{
			return toolCall?.GetType().Name ?? string.Empty;
		}
		return functionCallContent.Name ?? string.Empty;
	}

	private static string BuildApprovalArgsPreview(ToolCallContent toolCall)
	{
		try
		{
			if (toolCall is FunctionCallContent functionCallContent)
			{
				return JsonSerializer.Serialize(functionCallContent.Arguments);
			}
			return JsonSerializer.Serialize(new
			{
				toolCallId = toolCall?.CallId,
				type = toolCall?.GetType().Name
			});
		}
		catch
		{
			return toolCall?.CallId ?? string.Empty;
		}
	}
}
