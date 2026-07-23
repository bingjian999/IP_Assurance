using System;
using CPAHelper.Agent.Abstractions;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopAuthenticationRecoveryPolicy
{
	private readonly string _threadId;

	private readonly IAgentConfigProvider _configProvider;

	public DesktopAuthenticationRecoveryPolicy(string threadId, IAgentConfigProvider configProvider)
	{
		_threadId = threadId ?? string.Empty;
		_configProvider = configProvider ?? throw new ArgumentNullException("configProvider");
	}

	public bool TryRecover(Exception exception)
	{
		if (!DesktopTurnErrorHandler.IsUnauthorizedException(exception))
		{
			return false;
		}
		if (!(_configProvider is IAgentAuthenticationRecovery agentAuthenticationRecovery))
		{
			return false;
		}
		try
		{
			string text = DesktopTurnErrorHandler.BuildExceptionSummary(exception);
			AgentRuntimeLogger.Info("Unauthorized detected, attempting auth recovery. ThreadId=" + _threadId + "; Error=" + text);
			return agentAuthenticationRecovery.TryRecoverFromUnauthorized(text);
		}
		catch (Exception exception2)
		{
			AgentRuntimeLogger.Error("Auth recovery failed. ThreadId=" + _threadId, exception2);
			return false;
		}
	}
}
