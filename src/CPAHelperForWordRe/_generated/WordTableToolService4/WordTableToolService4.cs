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
		public WordTableToolService4 _G_4__this;

		public Func<Application, T> action;

		public _G_c__DisplayClass2_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal T WYJVD7yq8Kk()
		{
			return _G_4__this.SboJmUGoUJ(action);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass3_0<T>
	{
		public WordTableToolService4 _G_4__this;

		public WordWindowInfo callerSnapshot;

		public Func<Application, T> action;

		public _G_c__DisplayClass3_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal T XJbVD5M1KHp()
		{
			WordWindowInfo current = DocumentLifecycleGuard.Current;
			bool flag = _G_4__this.w3LJGQNyx3 != null || callerSnapshot != null;
			try
			{
				Application wordApp = WordTableToolService.WordApp;
				if (wordApp == null)
				{
					throw new InvalidOperationException("Worksheet list retrieved.");
				}
				if (_G_4__this.w3LJGQNyx3 != null)
				{
					DocumentLifecycleGuard.Q9OuJfHKAR(DocumentLifecycleGuard.xeAu2ueFL1(wordApp, _G_4__this.w3LJGQNyx3));
				}
				else if (callerSnapshot != null)
				{
					DocumentLifecycleGuard.Q9OuJfHKAR(callerSnapshot);
				}
				DocumentLifecycleGuard.dDwu4bAmJp(wordApp);
				return action(wordApp);
			}
			finally
			{
				if (flag)
				{
					DocumentLifecycleGuard.Q9OuJfHKAR(current);
				}
			}
		}
	}

	private readonly AiTargetBinder w3LJGQNyx3;

	public WordTableToolService4(AiTargetBinder P_0 = null)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		w3LJGQNyx3 = P_0;
	}

	public Kc8iOkJNoalE6DtK4x6 MdXJlVhPku<Kc8iOkJNoalE6DtK4x6>(string P_0, Func<Application, Kc8iOkJNoalE6DtK4x6> P_1)
	{
		_G_c__DisplayClass2_0<Kc8iOkJNoalE6DtK4x6> CS_8_locals_5 = new _G_c__DisplayClass2_0<Kc8iOkJNoalE6DtK4x6>();
		CS_8_locals_5._G_4__this = this;
		CS_8_locals_5.action = P_1;
		if (CS_8_locals_5.action == null)
		{
			throw new ArgumentNullException("action");
		}
		return AiHelper_14.no9JOmnkBj(P_0, () => CS_8_locals_5._G_4__this.SboJmUGoUJ(CS_8_locals_5.action));
	}

	public PSG6ueJotabDtGQ958F SboJmUGoUJ<PSG6ueJotabDtGQ958F>(Func<Application, PSG6ueJotabDtGQ958F> P_0)
	{
		_G_c__DisplayClass3_0<PSG6ueJotabDtGQ958F> obj = new _G_c__DisplayClass3_0<PSG6ueJotabDtGQ958F>();
		obj._G_4__this = this;
		obj.action = P_0;
		if (obj.action == null)
		{
			throw new ArgumentNullException("action");
		}
		obj.callerSnapshot = DocumentLifecycleGuard.Current;
		return WordTableToolService.xgnsoNTZsI(delegate
		{
			WordWindowInfo current = DocumentLifecycleGuard.Current;
			bool flag = obj._G_4__this.w3LJGQNyx3 != null || obj.callerSnapshot != null;
			try
			{
				Application wordApp = WordTableToolService.WordApp;
				if (wordApp == null)
				{
					throw new InvalidOperationException("Word 应用尚未初始化。");
				}
				if (obj._G_4__this.w3LJGQNyx3 != null)
				{
					DocumentLifecycleGuard.Q9OuJfHKAR(DocumentLifecycleGuard.xeAu2ueFL1(wordApp, obj._G_4__this.w3LJGQNyx3));
				}
				else if (obj.callerSnapshot != null)
				{
					DocumentLifecycleGuard.Q9OuJfHKAR(obj.callerSnapshot);
				}
				DocumentLifecycleGuard.dDwu4bAmJp(wordApp);
				return obj.action(wordApp);
			}
			finally
			{
				if (flag)
				{
					DocumentLifecycleGuard.Q9OuJfHKAR(current);
				}
			}
		});
	}
}
