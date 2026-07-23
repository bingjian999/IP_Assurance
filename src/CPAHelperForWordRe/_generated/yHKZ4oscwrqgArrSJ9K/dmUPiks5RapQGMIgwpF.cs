using System;
using System.Collections.Generic;
using dL7TFPsQbAGqPywtHUK;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;

namespace yHKZ4oscwrqgArrSJ9K;

internal sealed class dmUPiks5RapQGMIgwpF
{
	private readonly List<KeyValuePair<string, Action>> glysX1qya0;

	public void f5nsePaaOi(string P_0, Action P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("step");
		}
		glysX1qya0.Add(new KeyValuePair<string, Action>(P_0, P_1));
	}

	public void DQUsymt3gA()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Action> item in glysX1qya0)
		{
			string text = (string.IsNullOrWhiteSpace(item.Key) ? "启动步骤" : item.Key);
			try
			{
				item.Value();
			}
			catch (Exception ex)
			{
				list.Add(text);
				yR9thasHZ73xXm8eKwj.ujWsURly3F("[Startup] " + text + " failed", ex);
			}
		}
		if (list.Count > 0)
		{
			yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("以下启动步骤失败，加载项已继续加载： " + string.Join(", ", list));
		}
	}

	public dmUPiks5RapQGMIgwpF()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		glysX1qya0 = new List<KeyValuePair<string, Action>>();
	}
}
