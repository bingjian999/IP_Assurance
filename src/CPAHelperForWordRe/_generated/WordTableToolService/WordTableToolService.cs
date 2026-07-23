using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;

namespace WordTableToolService;

internal static class WordTableToolService
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass21_0<T>
	{
		public Func<T> action;

		public T result;

		public Exception captured;

		public _G_c__DisplayClass21_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ExecuteAction(object _)
		{
			try
			{
				result = action();
			}
			catch (Exception ex)
			{
				captured = ex;
			}
		}
	}

	[CompilerGenerated]
	private static Microsoft.Office.Interop.Word.Application _wordApp;

	[CompilerGenerated]
	private static SynchronizationContext SXMspfTYy7;

	[CompilerGenerated]
	private static Dispatcher WmtsOSEWxX;

	[CompilerGenerated]
	private static int _hostThreadId;

	[CompilerGenerated]
	private static bool _isWps;

	public static Microsoft.Office.Interop.Word.Application WordApp
	{
		[CompilerGenerated]
		get
		{
			return _wordApp;
		}
		[CompilerGenerated]
		private set
		{
			_wordApp = value;
		}
	}

	public static SynchronizationContext SyncContext
	{
		[CompilerGenerated]
		get
		{
			return SXMspfTYy7;
		}
		[CompilerGenerated]
		private set
		{
			SXMspfTYy7 = value;
		}
	}

	public static Dispatcher HostDispatcher
	{
		[CompilerGenerated]
		get
		{
			return WmtsOSEWxX;
		}
		[CompilerGenerated]
		private set
		{
			WmtsOSEWxX = value;
		}
	}

	public static int HostThreadId
	{
		[CompilerGenerated]
		get
		{
			return _hostThreadId;
		}
		[CompilerGenerated]
		private set
		{
			_hostThreadId = value;
		}
	}

	public static bool IsWps
	{
		[CompilerGenerated]
		get
		{
			return _isWps;
		}
		[CompilerGenerated]
		private set
		{
			_isWps = value;
		}
	}

	public static void Initialize(Microsoft.Office.Interop.Word.Application P_0, SynchronizationContext P_1 = null)
	{
		WordApp = P_0 ?? throw new ArgumentNullException("app");
		SyncContext = P_1 ?? SynchronizationContext.Current;
		HostThreadId = Thread.CurrentThread.ManagedThreadId;
		HostDispatcher = System.Windows.Application.Current?.Dispatcher ?? Dispatcher.FromThread(Thread.CurrentThread);
		try
		{
			IsWps = !string.IsNullOrEmpty(P_0.Path) && P_0.Path.IndexOf("WPS", StringComparison.OrdinalIgnoreCase) >= 0;
		}
		catch
		{
			IsWps = false;
		}
	}

	public static TResult xgnsoNTZsI<TResult>(Func<TResult> P_0)
	{
		_G_c__DisplayClass21_0<TResult> CS_8_locals_12 = new _G_c__DisplayClass21_0<TResult>();
		CS_8_locals_12.action = P_0;
		if (CS_8_locals_12.action == null)
		{
			throw new ArgumentNullException("app");
		}
		if (Thread.CurrentThread.ManagedThreadId == HostThreadId)
		{
			return CS_8_locals_12.action();
		}
		if (SyncContext != null)
		{
			CS_8_locals_12.result = default(TResult);
			CS_8_locals_12.captured = null;
			SyncContext.Send(delegate
			{
				try
				{
					CS_8_locals_12.result = CS_8_locals_12.action();
				}
				catch (Exception captured)
				{
					CS_8_locals_12.captured = captured;
				}
			}, null);
			if (CS_8_locals_12.captured != null)
			{
				throw CS_8_locals_12.captured;
			}
			return CS_8_locals_12.result;
		}
		if (HostDispatcher != null && !HostDispatcher.HasShutdownStarted && !HostDispatcher.HasShutdownFinished)
		{
			return HostDispatcher.Invoke(CS_8_locals_12.action);
		}
		throw new InvalidOperationException("WPS");
	}
}
