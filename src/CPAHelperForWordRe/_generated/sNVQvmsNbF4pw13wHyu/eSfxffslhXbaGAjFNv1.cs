using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using hJKpQrVSwRwMyI2RyDQN;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;

namespace sNVQvmsNbF4pw13wHyu;

internal static class eSfxffslhXbaGAjFNv1
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass21_0<T>
	{
		public Func<T> action;

		public T result;

		public Exception captured;

		public _G_c__DisplayClass21_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void hXFVEPHB6vT(object _)
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
	private static Microsoft.Office.Interop.Word.Application X9psCMqP7N;

	[CompilerGenerated]
	private static SynchronizationContext SXMspfTYy7;

	[CompilerGenerated]
	private static Dispatcher WmtsOSEWxX;

	[CompilerGenerated]
	private static int PBusnI4MQI;

	[CompilerGenerated]
	private static bool agOs7ClMS9;

	public static Microsoft.Office.Interop.Word.Application WordApp
	{
		[CompilerGenerated]
		get
		{
			return X9psCMqP7N;
		}
		[CompilerGenerated]
		private set
		{
			X9psCMqP7N = value;
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
			return PBusnI4MQI;
		}
		[CompilerGenerated]
		private set
		{
			PBusnI4MQI = value;
		}
	}

	public static bool IsWps
	{
		[CompilerGenerated]
		get
		{
			return agOs7ClMS9;
		}
		[CompilerGenerated]
		private set
		{
			agOs7ClMS9 = value;
		}
	}

	public static void wTdsm97f8t(Microsoft.Office.Interop.Word.Application P_0, SynchronizationContext P_1 = null)
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

	public static othpc1sGSo507cq3SG1 xgnsoNTZsI<othpc1sGSo507cq3SG1>(Func<othpc1sGSo507cq3SG1> P_0)
	{
		_G_c__DisplayClass21_0<othpc1sGSo507cq3SG1> CS_8_locals_12 = new _G_c__DisplayClass21_0<othpc1sGSo507cq3SG1>();
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
			CS_8_locals_12.result = default(othpc1sGSo507cq3SG1);
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
