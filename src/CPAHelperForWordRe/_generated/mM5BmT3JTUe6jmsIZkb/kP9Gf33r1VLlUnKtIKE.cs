using System;
using System.Runtime.CompilerServices;
using System.Threading;
using cCjw5xuBKfy3KrCEZTg;
using CPAHelper.Agent.Abstractions;
using HGQOfdJM683ZRGDQPGT;
using hJKpQrVSwRwMyI2RyDQN;
using IE65okus88MbfGVSFao;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;
using Ygqd3NJsBlYEnwMqFef;
using YYxtPnurDabQj37usVF;

namespace mM5BmT3JTUe6jmsIZkb;

internal sealed class kP9Gf33r1VLlUnKtIKE : IHostContext
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass5_0
	{
		public Action Yw7VTigJ7VO;

		public _G_c__DisplayClass5_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void pG0VTI0t7Tg(object _)
		{
			Yw7VTigJ7VO();
		}
	}

	private readonly RkZt4ZuLjXTP5cAL48p yQh332O4pP;

	private readonly x2u1CVJLYNVQcUFtkEy zv13UnLTq2;

	public kP9Gf33r1VLlUnKtIKE() : this(null)
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
	}

	public kP9Gf33r1VLlUnKtIKE(RkZt4ZuLjXTP5cAL48p P_0)
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		yQh332O4pP = P_0;
		zv13UnLTq2 = new x2u1CVJLYNVQcUFtkEy(P_0);
	}

	public string GetProjectPath()
	{
		try
		{
			VVx8AbuVh8WDeqd4oUQ current = BZOrlUu1R80X7V7qPHv.Current;
			if (!string.IsNullOrWhiteSpace(current?.DocumentFullName))
			{
				return current.DocumentFullName;
			}
			if (!string.IsNullOrWhiteSpace(yQh332O4pP?.DocumentFullName))
			{
				return yQh332O4pP.DocumentFullName;
			}
			if (yQh332O4pP != null)
			{
				return yQh332O4pP.DocumentName;
			}
			return zv13UnLTq2.MdXJlVhPku("host_context_project_path", (Application app) => app.ActiveDocument?.FullName);
		}
		catch
		{
			return null;
		}
	}

	public void InvokeOnUiThread(Action P_0)
	{
		_G_c__DisplayClass5_0 CS_8_locals_3 = new _G_c__DisplayClass5_0();
		CS_8_locals_3.Yw7VTigJ7VO = P_0;
		SynchronizationContext syncContext = eSfxffslhXbaGAjFNv1.SyncContext;
		if (syncContext != null)
		{
			syncContext.Post(delegate
			{
				CS_8_locals_3.Yw7VTigJ7VO();
			}, null);
		}
		else
		{
			CS_8_locals_3.Yw7VTigJ7VO();
		}
	}

	public string EnsureDataSourceReady()
	{
		if (eSfxffslhXbaGAjFNv1.WordApp == null)
		{
			return "Word 应用尚未初始化。";
		}
		VVx8AbuVh8WDeqd4oUQ vVx8AbuVh8WDeqd4oUQ;
		try
		{
			vVx8AbuVh8WDeqd4oUQ = zv13UnLTq2.MdXJlVhPku("host_context_ensure_ready", delegate(Application app)
			{
				string text = TEu80pJf6BRff8wZLuh.gEFJbNPT5J(app);
				if (!string.IsNullOrWhiteSpace(text))
				{
					throw new InvalidOperationException(text);
				}
				return BZOrlUu1R80X7V7qPHv.Current ?? BZOrlUu1R80X7V7qPHv.HCFuEiq9tL(app);
			});
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
		if (vVx8AbuVh8WDeqd4oUQ == null || !vVx8AbuVh8WDeqd4oUQ.HasDocument)
		{
			return "当前没有打开的 Word 文档。";
		}
		BZOrlUu1R80X7V7qPHv.Q9OuJfHKAR(vVx8AbuVh8WDeqd4oUQ);
		return null;
	}
}
