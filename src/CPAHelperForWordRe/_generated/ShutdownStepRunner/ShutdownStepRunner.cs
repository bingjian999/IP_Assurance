using System;
using System.Collections.Generic;
using AiConfigBootstrap;
using AiSseStreamService3;
using SseStreamInitializer;

namespace ShutdownStepRunner;

internal sealed class ShutdownStepRunner
{
	private readonly List<KeyValuePair<string, Action>> chjsPcdIl7;

	public void CdpsaonsgL(string P_0, Action P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("step");
		}
		chjsPcdIl7.Add(new KeyValuePair<string, Action>(P_0, P_1));
	}

	public void wCBsq1dqWy()
	{
		for (int num = chjsPcdIl7.Count - 1; num >= 0; num--)
		{
			string text = (string.IsNullOrWhiteSpace(chjsPcdIl7[num].Key) ? "关闭步骤" : chjsPcdIl7[num].Key);
			try
			{
				chjsPcdIl7[num].Value();
			}
			catch (Exception ex)
			{
				AiConfigBootstrap.ujWsURly3F("[Shutdown] " + text + " failed", ex);
			}
		}
	}

	public ShutdownStepRunner()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		chjsPcdIl7 = new List<KeyValuePair<string, Action>>();
	}
}
