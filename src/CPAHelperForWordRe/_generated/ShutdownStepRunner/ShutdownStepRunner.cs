using System;
using System.Collections.Generic;
using AiConfigBootstrap;
using AiSseStreamService3;
using SseStreamInitializer;

namespace ShutdownStepRunner;

internal sealed class ShutdownStepRunner
{
	private readonly List<KeyValuePair<string, Action>> _shutdownSteps;

	public void CdpsaonsgL(string P_0, Action P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("step");
		}
		_shutdownSteps.Add(new KeyValuePair<string, Action>(P_0, P_1));
	}

	public void RunShutdown()
	{
		for (int num = _shutdownSteps.Count - 1; num >= 0; num--)
		{
			string text = (string.IsNullOrWhiteSpace(_shutdownSteps[num].Key) ? "关闭步骤" : _shutdownSteps[num].Key);
			try
			{
				_shutdownSteps[num].Value();
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.LogError("[Shutdown] " + text + " failed", ex);
			}
		}
	}

	public ShutdownStepRunner()
	{
		SseStreamInitializer.InitializeRuntime();
		_shutdownSteps = new List<KeyValuePair<string, Action>>();
	}
}
