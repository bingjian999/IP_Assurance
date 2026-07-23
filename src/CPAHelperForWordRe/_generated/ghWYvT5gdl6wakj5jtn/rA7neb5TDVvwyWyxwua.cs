using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using e8p1CGVN194FjjKWWIg;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;

namespace ghWYvT5gdl6wakj5jtn;

internal static class rA7neb5TDVvwyWyxwua
{
	private sealed class S0SXuwVZRFoj8tCjb8xt : System.Windows.Forms.IWin32Window
	{
		[CompilerGenerated]
		private readonly IntPtr WytVZVC3GfP;

		public IntPtr Handle
		{
			[CompilerGenerated]
			get
			{
				return WytVZVC3GfP;
			}
		}

		public S0SXuwVZRFoj8tCjb8xt(IntPtr P_0)
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			WytVZVC3GfP = P_0;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_0
	{
		public System.Windows.Window clIVZ9Iiydu;

		public _G_c__DisplayClass10_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void CfrVZBpT5u6()
		{
			if (clIVZ9Iiydu.IsVisible)
			{
				clIVZ9Iiydu.Activate();
				xAc5Kb6teT(clIVZ9Iiydu);
			}
		}
	}

	public static System.Windows.Forms.IWin32Window KJy58rGLXb()
	{
		try
		{
			Microsoft.Office.Interop.Word.Application wordApp = eSfxffslhXbaGAjFNv1.WordApp;
			if (wordApp == null)
			{
				return null;
			}
			IntPtr intPtr = new IntPtr((wordApp.ActiveWindow != null) ? wordApp.ActiveWindow.Hwnd : 0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new S0SXuwVZRFoj8tCjb8xt(intPtr);
		}
		catch
		{
			return null;
		}
	}

	public static void I4W5IBiXJU(Form P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		System.Windows.Forms.IWin32Window win32Window = KJy58rGLXb();
		try
		{
			if (win32Window != null)
			{
				P_0.Show(win32Window);
			}
			else
			{
				P_0.Show();
			}
		}
		catch
		{
			P_0.Show();
		}
	}

	public static void IPf5i0ZcV4(System.Windows.Window P_0)
	{
		if (P_0 != null)
		{
			R0R51l5M47(P_0);
			fYx5r0teaL(P_0);
			Rd81EOVl9ycTdnhNP7H.b5KVmv3Pp9(P_0);
			ElementHost.EnableModelessKeyboardInterop(P_0);
			P_0.Show();
			LaD5UjoUA2(P_0);
		}
	}

	public static bool? NJs5HCHQjv(System.Windows.Window P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		R0R51l5M47(P_0);
		fYx5r0teaL(P_0);
		return P_0.ShowDialog();
	}

	public static DialogResult QIn5QOq3Ta(Form P_0)
	{
		if (P_0 == null)
		{
			return DialogResult.None;
		}
		System.Windows.Forms.IWin32Window win32Window = KJy58rGLXb();
		try
		{
			return (win32Window != null) ? P_0.ShowDialog(win32Window) : P_0.ShowDialog();
		}
		catch
		{
			return P_0.ShowDialog();
		}
	}

	private static void R0R51l5M47(System.Windows.Window P_0)
	{
		P_0.ShowInTaskbar = false;
		IntPtr intPtr = KJy58rGLXb()?.Handle ?? IntPtr.Zero;
		if (intPtr != IntPtr.Zero)
		{
			new WindowInteropHelper(P_0).Owner = intPtr;
			P_0.WindowStartupLocation = WindowStartupLocation.CenterOwner;
		}
		else
		{
			P_0.WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}
	}

	private static void fYx5r0teaL(System.Windows.Window P_0)
	{
		P_0.ShowActivated = true;
		P_0.Loaded -= nLg5JOqHYn;
		P_0.ContentRendered -= c7l53MATht;
		P_0.Loaded += nLg5JOqHYn;
		P_0.ContentRendered += c7l53MATht;
	}

	private static void nLg5JOqHYn(object P_0, RoutedEventArgs P_1)
	{
		if (P_0 is System.Windows.Window window)
		{
			LaD5UjoUA2(window);
		}
	}

	private static void c7l53MATht(object P_0, EventArgs P_1)
	{
		if (P_0 is System.Windows.Window window)
		{
			window.ContentRendered -= c7l53MATht;
			LaD5UjoUA2(window);
		}
	}

	private static void LaD5UjoUA2(System.Windows.Window P_0)
	{
		_G_c__DisplayClass10_0 CS_8_locals_6 = new _G_c__DisplayClass10_0();
		CS_8_locals_6.clIVZ9Iiydu = P_0;
		if (CS_8_locals_6.clIVZ9Iiydu == null)
		{
			return;
		}
		CS_8_locals_6.clIVZ9Iiydu.Dispatcher.BeginInvoke((Action)delegate
		{
			if (CS_8_locals_6.clIVZ9Iiydu.IsVisible)
			{
				CS_8_locals_6.clIVZ9Iiydu.Activate();
				xAc5Kb6teT(CS_8_locals_6.clIVZ9Iiydu);
			}
		}, DispatcherPriority.Input);
	}

	private static void xAc5Kb6teT(System.Windows.Window P_0)
	{
		if (P_0.Content is UIElement uIElement)
		{
			uIElement.Focus();
			uIElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
		}
		P_0.Focus();
		Keyboard.Focus(P_0);
	}
}
