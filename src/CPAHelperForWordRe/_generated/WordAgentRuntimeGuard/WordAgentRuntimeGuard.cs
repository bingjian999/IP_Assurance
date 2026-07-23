using System;
using System.Runtime.CompilerServices;
using System.Threading;
using WordWindowInfo;
using CPAHelper.Agent.Abstractions;
using WordAgentRuntimeGuard2;
using AiSseStreamService3;
using AiTargetBinder;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService;
using WordTableToolService4;
using DocumentLifecycleGuard;

namespace WordAgentRuntimeGuard;

internal sealed class WordAgentRuntimeGuard : IHostContext
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass5_0
	{
		public Action Yw7VTigJ7VO;

		public _G_c__DisplayClass5_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void pG0VTI0t7Tg(object _)
		{
			Yw7VTigJ7VO();
		}
	}

	private readonly AiTargetBinder yQh332O4pP;

	private readonly WordTableToolService4 zv13UnLTq2;

	public WordAgentRuntimeGuard() : this(null)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
	}

	public WordAgentRuntimeGuard(AiTargetBinder P_0)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		yQh332O4pP = P_0;
		zv13UnLTq2 = new WordTableToolService4(P_0);
	}

	public string GetProjectPath()
	{
		try
		{
			WordWindowInfo current = DocumentLifecycleGuard.Current;
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
		SynchronizationContext syncContext = WordTableToolService.SyncContext;
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
		if (WordTableToolService.WordApp == null)
		{
			return "Word 应用尚未初始化。";
		}
		WordWindowInfo vVx8AbuVh8WDeqd4oUQ;
		try
		{
			vVx8AbuVh8WDeqd4oUQ = zv13UnLTq2.MdXJlVhPku("host_context_ensure_ready", delegate(Application app)
			{
				string text = WordAgentRuntimeGuard2.gEFJbNPT5J(app);
				if (!string.IsNullOrWhiteSpace(text))
				{
					throw new InvalidOperationException(text);
				}
				return DocumentLifecycleGuard.Current ?? DocumentLifecycleGuard.HCFuEiq9tL(app);
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
		DocumentLifecycleGuard.Q9OuJfHKAR(vVx8AbuVh8WDeqd4oUQ);
		return null;
	}
}
