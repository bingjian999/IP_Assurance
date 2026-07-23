using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AiSseStreamService3;
using SseStreamInitializer;

namespace DelegateCommand;

internal sealed class DelegateCommand : ICommand
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0
	{
		public Action DMZVEWkGhgT;

		public Func<bool> GAvVE0JwPK9;

		public _G_c__DisplayClass2_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void lHHVEAZNUvp(object _)
		{
			DMZVEWkGhgT();
		}

		internal bool lE6VEvOvRv6(object _)
		{
			return GAvVE0JwPK9();
		}
	}

	private readonly Action<object> LPVlR9wDEn;

	private readonly Predicate<object> jbLlVkNMjF;

	public event EventHandler CanExecuteChanged
	{
		add
		{
			CommandManager.RequerySuggested += value;
		}
		remove
		{
			CommandManager.RequerySuggested -= value;
		}
	}

	public DelegateCommand(Action P_0, Func<bool> P_1 = null)
	{
		_G_c__DisplayClass2_0 CS_8_locals_5 = new _G_c__DisplayClass2_0();
		CS_8_locals_5.DMZVEWkGhgT = P_0;
		CS_8_locals_5.GAvVE0JwPK9 = P_1;
		SseStreamInitializer.InitializeRuntime();
		LPVlR9wDEn = new Action<object>(CS_8_locals_5.lHHVEAZNUvp);
		jbLlVkNMjF = (CS_8_locals_5.GAvVE0JwPK9 == null) ? null : new Predicate<object>(CS_8_locals_5.lE6VEvOvRv6);
		SseStreamInitializer.InitializeRuntime();
	}

	public DelegateCommand(Action<object> P_0, Predicate<object> P_1 = null)
	{
		SseStreamInitializer.InitializeRuntime();
		LPVlR9wDEn = P_0 ?? throw new ArgumentNullException("execute");
		jbLlVkNMjF = P_1;
	}

	public bool CanExecute(object P_0)
	{
		if (jbLlVkNMjF != null)
		{
			return jbLlVkNMjF(P_0);
		}
		return true;
	}

	public void Execute(object P_0)
	{
		LPVlR9wDEn(P_0);
	}
}
