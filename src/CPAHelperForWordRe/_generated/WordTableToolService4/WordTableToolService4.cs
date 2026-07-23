using System;
using System.Runtime.CompilerServices;
using WordWindowInfo;
using AiSseStreamService3;
using AiTargetBinder;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using AiHelper_14;
using WordTableToolService;
using DocumentLifecycleGuard;

namespace WordTableToolService4;

internal sealed class WordTableToolService4
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0<T>
	{
		public WordTableToolService4 wordTableToolService4;

		public Func<Application, T> action;

		public _G_c__DisplayClass2_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal T ExecuteWithTelemetry()
		{
			return wordTableToolService4.SboJmUGoUJ(action);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass3_0<T>
	{
		public WordTableToolService4 wordTableToolService4;

		public WordWindowInfo callerSnapshot;

		public Func<Application, T> action;

		public _G_c__DisplayClass3_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal T ExecuteWithContext()
		{
			WordWindowInfo current = DocumentLifecycleGuard.Current;
			bool flag = wordTableToolService4._aiTargetBinder != null || callerSnapshot != null;
			try
			{
				Application wordApp = WordTableToolService.WordApp;
				if (wordApp == null)
				{
					throw new InvalidOperationException("Worksheet list retrieved.");
				}
				if (wordTableToolService4._aiTargetBinder != null)
				{
					DocumentLifecycleGuard.SetCurrentWindow(DocumentLifecycleGuard.CaptureWindowInfoWithBinder(wordApp, wordTableToolService4._aiTargetBinder));
				}
				else if (callerSnapshot != null)
				{
					DocumentLifecycleGuard.SetCurrentWindow(callerSnapshot);
				}
				DocumentLifecycleGuard.ValidatePaneTarget(wordApp);
				return action(wordApp);
			}
			finally
			{
				if (flag)
				{
					DocumentLifecycleGuard.SetCurrentWindow(current);
				}
			}
		}
	}

	private readonly AiTargetBinder _aiTargetBinder;

	public WordTableToolService4(AiTargetBinder P_0 = null)
	{
		SseStreamInitializer.InitializeRuntime();
		_aiTargetBinder = P_0;
	}

	public T runOperation<T>(string P_0, Func<Application, T> P_1)
	{
		_G_c__DisplayClass2_0<T> CS_8_locals_5 = new _G_c__DisplayClass2_0<T>();
		CS_8_locals_5.wordTableToolService4 = this;
		CS_8_locals_5.action = P_1;
		if (CS_8_locals_5.action == null)
		{
			throw new ArgumentNullException("action");
		}
		return AiHelper_14.RunWithTelemetry(P_0, () => CS_8_locals_5.wordTableToolService4.SboJmUGoUJ(CS_8_locals_5.action));
	}

	public T SboJmUGoUJ<T>(Func<Application, T> P_0)
	{
		_G_c__DisplayClass3_0<T> obj = new _G_c__DisplayClass3_0<T>();
		obj.wordTableToolService4 = this;
		obj.action = P_0;
		if (obj.action == null)
		{
			throw new ArgumentNullException("action");
		}
		obj.callerSnapshot = DocumentLifecycleGuard.Current;
		return WordTableToolService.xgnsoNTZsI(delegate
		{
			WordWindowInfo current = DocumentLifecycleGuard.Current;
			bool flag = obj.wordTableToolService4._aiTargetBinder != null || obj.callerSnapshot != null;
			try
			{
				Application wordApp = WordTableToolService.WordApp;
				if (wordApp == null)
				{
					throw new InvalidOperationException("Word 应用尚未初始化。");
				}
				if (obj.wordTableToolService4._aiTargetBinder != null)
				{
					DocumentLifecycleGuard.SetCurrentWindow(DocumentLifecycleGuard.CaptureWindowInfoWithBinder(wordApp, obj.wordTableToolService4._aiTargetBinder));
				}
				else if (obj.callerSnapshot != null)
				{
					DocumentLifecycleGuard.SetCurrentWindow(obj.callerSnapshot);
				}
				DocumentLifecycleGuard.ValidatePaneTarget(wordApp);
				return obj.action(wordApp);
			}
			finally
			{
				if (flag)
				{
					DocumentLifecycleGuard.SetCurrentWindow(current);
				}
			}
		});
	}
}
