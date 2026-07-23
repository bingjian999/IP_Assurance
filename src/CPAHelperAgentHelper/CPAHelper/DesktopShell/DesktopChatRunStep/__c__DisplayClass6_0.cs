using System;
using System.Collections.Generic;
using CPAHelper.Agent.Runtime;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopChatRunStep
{
	private readonly string _userMessage;

	private readonly IReadOnlyList<ChatMessage> _messages;

	private DesktopChatRunStep(string userMessage, IReadOnlyList<ChatMessage> messages)
	{
		_userMessage = userMessage;
		_messages = messages;
	}

	public static DesktopChatRunStep ForUserMessage(string userMessage)
	{
		return new DesktopChatRunStep(userMessage, null);
	}

	public static DesktopChatRunStep ForApprovalResponses(AIContent[] approvalResponses)
	{
		return new DesktopChatRunStep(null, new ChatMessage[1]
		{
			new ChatMessage(ChatRole.User, approvalResponses ?? Array.Empty<AIContent>())
		});
	}

	public static DesktopChatRunStep ForMessages(IReadOnlyList<ChatMessage> messages)
	{
		return new DesktopChatRunStep(null, messages ?? Array.Empty<ChatMessage>());
	}

	public IAsyncEnumerable<AgentResponseUpdate> RunStreamingAsync(DesktopChatTurnContext context, Action<MafCompactionMetricsSnapshot> compactionObserver)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Action<string, string> statusObserver = delegate(string status, string message)
		{
			context.Stream.EmitStatus(status, message);
		};
		if (_messages != null)
		{
			return context.AgentRuntime.RunStreamingAsync(_messages, context.AgentSession, context.Instructions, context.ThreadId, statusObserver, compactionObserver, context.CancellationToken);
		}
		return context.AgentRuntime.RunStreamingAsync(_userMessage, context.AgentSession, context.Instructions, context.ThreadId, statusObserver, compactionObserver, context.CancellationToken);
	}
}
