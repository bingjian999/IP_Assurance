using System;
using System.Collections.Generic;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class VisibleTurnRecorder
{
	private readonly string _threadId;

	private readonly string _userMessage;

	private readonly string _visibleUserMessage;

	private readonly IReadOnlyList<string> _selectedSkills;

	private readonly IReadOnlyList<HostContextItem> _hostContextItems;

	private readonly IReadOnlyList<string> _selectedTools;

	private readonly object _partsSyncRoot = new object();

	private readonly List<PersistedMessagePart> _assistantParts = new List<PersistedMessagePart>();

	public List<PersistedMessagePart> AssistantParts => _assistantParts;

	public object PartsSyncRoot => _partsSyncRoot;

	public VisibleTurnRecorder(string threadId, string userMessage, string visibleUserMessage, IReadOnlyList<string> selectedSkills, IReadOnlyList<HostContextItem> hostContextItems, IReadOnlyList<string> selectedTools)
	{
		_threadId = threadId;
		_userMessage = userMessage;
		_visibleUserMessage = visibleUserMessage;
		_selectedSkills = selectedSkills ?? Array.Empty<string>();
		_hostContextItems = hostContextItems ?? Array.Empty<HostContextItem>();
		_selectedTools = selectedTools ?? Array.Empty<string>();
	}

	public void AppendText(string text)
	{
		ConversationPersistenceService.AppendTextPart(_assistantParts, _partsSyncRoot, text);
	}

	public void AppendApproval(ApprovalRequestEvent approvalRequest)
	{
		ConversationPersistenceService.AppendApprovalPart(_assistantParts, _partsSyncRoot, approvalRequest);
	}

	public void ApplyApprovalResult(ApprovalResolvedEvent approvalResolved)
	{
		ConversationPersistenceService.ApplyApprovalResult(_assistantParts, _partsSyncRoot, approvalResolved);
	}

	public void AppendUserInterrupt(UserInterruptEvent userInterrupt)
	{
		ConversationPersistenceService.AppendUserInterruptPart(_assistantParts, _partsSyncRoot, userInterrupt);
	}

	public void UpdateUserInterruptStatus(string injectionId, string status)
	{
		ConversationPersistenceService.UpdateUserInterruptStatus(_assistantParts, _partsSyncRoot, injectionId, status);
	}

	public bool HasContentParts()
	{
		return ConversationPersistenceService.HasPersistedContentParts(_assistantParts, _partsSyncRoot);
	}

	public void Persist(string assistantMessage, string finishReason)
	{
		ConversationPersistenceService.PersistTurn(_threadId, _userMessage, assistantMessage, _assistantParts, _partsSyncRoot, _visibleUserMessage, _selectedSkills, _hostContextItems, _selectedTools, finishReason);
	}

	public static bool TryBuildInterruptedTurnRecoveryUserMessage(string threadId, string currentUserMessage, out string modelUserMessage, out CanceledTurnRecoveryInfo recoveryInfo)
	{
		return ConversationPersistenceService.TryBuildCanceledTurnRecoveryUserMessage(threadId, currentUserMessage, out modelUserMessage, out recoveryInfo);
	}
}
