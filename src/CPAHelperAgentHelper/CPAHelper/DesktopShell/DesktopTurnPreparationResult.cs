using System;
using System.Collections.Generic;
using CPAHelper.Agent.Adapters;
using CPAHelper.Agent.Contracts;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopTurnPreparationResult
{
	public bool IsReady { get; private set; }

	public string ErrorMessage { get; private set; }

	public string ErrorCode { get; private set; }

	public string Instructions { get; private set; }

	public AgentSession AgentSession { get; private set; }

	public string SessionInstructions { get; private set; }

	public JsonSessionIndexManager.SessionSummary SessionSummary { get; private set; }

	public IReadOnlyList<string> LoadedTools { get; private set; } = Array.Empty<string>();

	public bool ResetForEmptyConversation { get; private set; }

	public bool RefreshedSession { get; private set; }

	private DesktopTurnPreparationResult()
	{
	}

	public ErrorEvent ToErrorEvent()
	{
		return new ErrorEvent
		{
			Message = ErrorMessage,
			Code = ErrorCode
		};
	}

	public static DesktopTurnPreparationResult Failed(string message, string code)
	{
		return new DesktopTurnPreparationResult
		{
			IsReady = false,
			ErrorMessage = message,
			ErrorCode = code
		};
	}

	public static DesktopTurnPreparationResult Ready(string instructions, AgentSession agentSession, string sessionInstructions, JsonSessionIndexManager.SessionSummary sessionSummary, IReadOnlyList<string> loadedTools, bool resetForEmptyConversation, bool refreshedSession)
	{
		return new DesktopTurnPreparationResult
		{
			IsReady = true,
			Instructions = instructions,
			AgentSession = agentSession,
			SessionInstructions = sessionInstructions,
			SessionSummary = sessionSummary,
			LoadedTools = (loadedTools ?? Array.Empty<string>()),
			ResetForEmptyConversation = resetForEmptyConversation,
			RefreshedSession = refreshedSession
		};
	}
}
