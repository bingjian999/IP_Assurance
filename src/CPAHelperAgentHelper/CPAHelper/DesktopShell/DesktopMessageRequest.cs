using System;
using System.Collections.Generic;
using System.IO;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopMessageRequest
{
	public string UserMessage { get; }

	public Stream OutputStream { get; }

	public string DisplayUserMessage { get; }

	public IReadOnlyList<string> SelectedSkills { get; }

	public IReadOnlyList<HostContextItem> HostContextItems { get; }

	public IReadOnlyList<string> SelectedTools { get; }

	public string RequestedAgentMode { get; }

	public bool AllowAuthRecovery { get; }

	public bool SkipInterruptedRecovery { get; }

	public string VisibleUserMessage
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(DisplayUserMessage))
			{
				return DisplayUserMessage;
			}
			return UserMessage;
		}
	}

	public DesktopMessageRequest(string userMessage, Stream outputStream, string displayUserMessage = null, IReadOnlyList<string> selectedSkills = null, IReadOnlyList<HostContextItem> hostContextItems = null, IReadOnlyList<string> selectedTools = null, string requestedAgentMode = null, bool allowAuthRecovery = true, bool skipInterruptedRecovery = false)
	{
		UserMessage = userMessage;
		OutputStream = outputStream ?? throw new ArgumentNullException("outputStream");
		DisplayUserMessage = displayUserMessage;
		SelectedSkills = selectedSkills ?? Array.Empty<string>();
		HostContextItems = hostContextItems ?? Array.Empty<HostContextItem>();
		SelectedTools = selectedTools ?? Array.Empty<string>();
		RequestedAgentMode = requestedAgentMode;
		AllowAuthRecovery = allowAuthRecovery;
		SkipInterruptedRecovery = skipInterruptedRecovery;
	}

	public DesktopMessageRequest WithoutAuthRecovery()
	{
		return new DesktopMessageRequest(UserMessage, OutputStream, DisplayUserMessage, SelectedSkills, HostContextItems, SelectedTools, RequestedAgentMode, allowAuthRecovery: false, SkipInterruptedRecovery);
	}
}
