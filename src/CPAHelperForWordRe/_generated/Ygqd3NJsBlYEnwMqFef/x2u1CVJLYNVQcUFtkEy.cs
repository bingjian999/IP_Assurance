using System;
using System.Runtime.CompilerServices;
using cCjw5xuBKfy3KrCEZTg;
using hJKpQrVSwRwMyI2RyDQN;
using IE65okus88MbfGVSFao;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;
using NLtQicJp6ZHeC4cBvpJ;
using sNVQvmsNbF4pw13wHyu;
using YYxtPnurDabQj37usVF;

namespace Ygqd3NJsBlYEnwMqFef;

internal sealed class x2u1CVJLYNVQcUFtkEy
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0<T>
	{
		public x2u1CVJLYNVQcUFtkEy _G_4__this;

		public Func<Application, T> action;

		public _G_c__DisplayClass2_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal T WYJVD7yq8Kk()
		{
			return _G_4__this.SboJmUGoUJ(action);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass3_0<T>
	{
		public x2u1CVJLYNVQcUFtkEy _G_4__this;

		public VVx8AbuVh8WDeqd4oUQ callerSnapshot;

		public Func<Application, T> action;

		public _G_c__DisplayClass3_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal T XJbVD5M1KHp()
		{
			VVx8AbuVh8WDeqd4oUQ current = BZOrlUu1R80X7V7qPHv.Current;
			bool flag = _G_4__this.w3LJGQNyx3 != null || callerSnapshot != null;
			try
			{
				Application wordApp = eSfxffslhXbaGAjFNv1.WordApp;
				if (wordApp == null)
				{
					throw new InvalidOperationException("Worksheet list retrieved.");
				}
				if (_G_4__this.w3LJGQNyx3 != null)
				{
					BZOrlUu1R80X7V7qPHv.Q9OuJfHKAR(BZOrlUu1R80X7V7qPHv.xeAu2ueFL1(wordApp, _G_4__this.w3LJGQNyx3));
				}
				else if (callerSnapshot != null)
				{
					BZOrlUu1R80X7V7qPHv.Q9OuJfHKAR(callerSnapshot);
				}
				BZOrlUu1R80X7V7qPHv.dDwu4bAmJp(wordApp);
				return action(wordApp);
			}
			finally
			{
				if (flag)
				{
					BZOrlUu1R80X7V7qPHv.Q9OuJfHKAR(current);
				}
			}
		}
	}

	private readonly RkZt4ZuLjXTP5cAL48p w3LJGQNyx3;

	public x2u1CVJLYNVQcUFtkEy(RkZt4ZuLjXTP5cAL48p P_0 = null)
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
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
		return cn0tKuJC81YLPVeEi9U.no9JOmnkBj(P_0, () => CS_8_locals_5._G_4__this.SboJmUGoUJ(CS_8_locals_5.action));
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
		obj.callerSnapshot = BZOrlUu1R80X7V7qPHv.Current;
		return eSfxffslhXbaGAjFNv1.xgnsoNTZsI(delegate
		{
			VVx8AbuVh8WDeqd4oUQ current = BZOrlUu1R80X7V7qPHv.Current;
			bool flag = obj._G_4__this.w3LJGQNyx3 != null || obj.callerSnapshot != null;
			try
			{
				Application wordApp = eSfxffslhXbaGAjFNv1.WordApp;
				if (wordApp == null)
				{
					throw new InvalidOperationException("Word 应用尚未初始化。");
				}
				if (obj._G_4__this.w3LJGQNyx3 != null)
				{
					BZOrlUu1R80X7V7qPHv.Q9OuJfHKAR(BZOrlUu1R80X7V7qPHv.xeAu2ueFL1(wordApp, obj._G_4__this.w3LJGQNyx3));
				}
				else if (obj.callerSnapshot != null)
				{
					BZOrlUu1R80X7V7qPHv.Q9OuJfHKAR(obj.callerSnapshot);
				}
				BZOrlUu1R80X7V7qPHv.dDwu4bAmJp(wordApp);
				return obj.action(wordApp);
			}
			finally
			{
				if (flag)
				{
					BZOrlUu1R80X7V7qPHv.Q9OuJfHKAR(current);
				}
			}
		});
	}
}
