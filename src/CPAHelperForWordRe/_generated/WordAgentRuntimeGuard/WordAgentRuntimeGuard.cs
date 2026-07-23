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
		public Action action;

		public _G_c__DisplayClass5_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void pG0VTI0t7Tg(object _)
		{
			action();
		}
	}

	private readonly AiTargetBinder _aiTargetBinder;

	private readonly WordTableToolService4 _wordTableToolService4;

	public WordAgentRuntimeGuard() : this(null)
	{
		SseStreamInitializer.InitializeRuntime();
	}

	public WordAgentRuntimeGuard(AiTargetBinder P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_aiTargetBinder = P_0;
		_wordTableToolService4 = new WordTableToolService4(P_0);
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
			if (!string.IsNullOrWhiteSpace(_aiTargetBinder?.DocumentFullName))
			{
				return _aiTargetBinder.DocumentFullName;
			}
			if (_aiTargetBinder != null)
			{
				return _aiTargetBinder.DocumentName;
			}
			return _wordTableToolService4.MdXJlVhPku("host_context_project_path", (Application app) => app.ActiveDocument?.FullName);
		}
		catch
		{
			return null;
		}
	}

	public void InvokeOnUiThread(Action P_0)
	{
		_G_c__DisplayClass5_0 CS_8_locals_3 = new _G_c__DisplayClass5_0();
		CS_8_locals_3.action = P_0;
		SynchronizationContext syncContext = WordTableToolService.SyncContext;
		if (syncContext != null)
		{
			syncContext.Post(delegate
			{
				CS_8_locals_3.action();
			}, null);
		}
		else
		{
			CS_8_locals_3.action();
		}
	}

	public string EnsureDataSourceReady()
	{
		if (WordTableToolService.WordApp == null)
		{
			return "Word 应用尚未初始化。";
		}
		WordWindowInfo windowInfo;
		try
		{
			windowInfo = _wordTableToolService4.MdXJlVhPku("host_context_ensure_ready", delegate(Application app)
			{
				string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
				if (!string.IsNullOrWhiteSpace(text))
				{
					throw new InvalidOperationException(text);
				}
				return DocumentLifecycleGuard.Current ?? DocumentLifecycleGuard.CaptureWindowInfo(app);
			});
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
		if (windowInfo == null || !windowInfo.HasDocument)
		{
			return "当前没有打开的 Word 文档。";
		}
		DocumentLifecycleGuard.SetCurrentWindow(windowInfo);
		return null;
	}
}
