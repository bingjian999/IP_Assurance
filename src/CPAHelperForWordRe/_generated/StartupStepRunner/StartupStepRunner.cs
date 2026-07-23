using System;
using System.Collections.Generic;
using AiConfigBootstrap;
using AiSseStreamService3;
using SseStreamInitializer;

namespace StartupStepRunner;

internal sealed class StartupStepRunner
{
	private readonly List<KeyValuePair<string, Action>> _startupSteps;

	public void ValidateConfig(string P_0, Action P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("step");
		}
		_startupSteps.Add(new KeyValuePair<string, Action>(P_0, P_1));
	}

	public void RunStartup()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Action> item in _startupSteps)
		{
			string text = (string.IsNullOrWhiteSpace(item.Key) ? "启动步骤" : item.Key);
			try
			{
				item.Value();
			}
			catch (Exception ex)
			{
				list.Add(text);
				AiConfigBootstrap.LogError("[Startup] " + text + " failed", ex);
			}
		}
		if (list.Count > 0)
		{
			AiConfigBootstrap.LogWarn("以下启动步骤失败，加载项已继续加载： " + string.Join(", ", list));
		}
	}

	public StartupStepRunner()
	{
		SseStreamInitializer.InitializeRuntime();
		_startupSteps = new List<KeyValuePair<string, Action>>();
	}
}
