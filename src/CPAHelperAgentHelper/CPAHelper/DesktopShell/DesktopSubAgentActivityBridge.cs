using System;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopSubAgentActivityBridge
{
	private readonly Func<ActiveSseStream> _getStream;

	public DesktopSubAgentActivityBridge(Func<ActiveSseStream> getStream)
	{
		_getStream = getStream ?? throw new ArgumentNullException("getStream");
	}

	public void Publish(SubAgentActivityUpdate update)
	{
		if (update == null)
		{
			return;
		}
		ActiveSseStream activeSseStream = _getStream();
		if (activeSseStream == null)
		{
			return;
		}
		try
		{
			activeSseStream.WriteSync(ToEvent(update));
		}
		catch
		{
		}
	}

	internal static SubAgentStateEvent ToEvent(SubAgentActivityUpdate update)
	{
		if (update == null)
		{
			return null;
		}
		return new SubAgentStateEvent
		{
			ActivityId = update.ActivityId,
			AgentName = update.AgentName,
			Title = update.Title,
			Status = update.Status,
			Detail = update.Detail,
			ResultPreview = update.ResultPreview,
			ReasoningDelta = update.ReasoningDelta,
			ActivityGroupId = update.ActivityGroupId,
			ActivityGroupTitle = update.ActivityGroupTitle,
			TaskId = update.TaskId,
			TaskStatus = update.TaskStatus,
			ResultRetrieved = update.ResultRetrieved,
			UpdatedAt = (string.IsNullOrWhiteSpace(update.UpdatedAt) ? DateTimeOffset.Now.ToString("O") : update.UpdatedAt)
		};
	}
}
