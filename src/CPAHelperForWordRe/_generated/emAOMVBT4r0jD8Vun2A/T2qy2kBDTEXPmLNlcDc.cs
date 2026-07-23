using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using b34kL1V3mY6rixNCkZH;
using eSIXwQcfnNLVB8362qX;
using FiIb7mSOBD13BJBxsh0;
using Ggh3TatGPt12UEReD7h;
using ghWYvT5gdl6wakj5jtn;
using hJKpQrVSwRwMyI2RyDQN;
using IeFmyQViKuM7ZEqhrwq;
using IEtOQs5fTl6OqDwOHlX;
using ndRERvVtEjasqN2cQqiN;
using xCR41qcT3c17DlG5tyi;

namespace emAOMVBT4r0jD8Vun2A;

internal static class T2qy2kBDTEXPmLNlcDc
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass8_0
	{
		public tAKHV45ZlJVODNWxYiE DL7FzHGeRY;

		public _G_c__DisplayClass8_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void tKLFddnaYm(object _, FormClosedEventArgs __)
		{
			dfCBKMIQgW.Remove(DL7FzHGeRY);
		}
	}

	private static readonly List<tAKHV45ZlJVODNWxYiE> dfCBKMIQgW;

	public static void SqNBgKb64d()
	{
		List<Window> list = slNBrIHLn5();
		List<Form> list2 = V8wB3d2E8J();
		try
		{
			using rv5mvGcDycFl26EPlB1 rv5mvGcDycFl26EPlB2 = new rv5mvGcDycFl26EPlB1();
			if (rv5mvGcDycFl26EPlB2.ShowDialog() == DialogResult.OK && rv5mvGcDycFl26EPlB2.CapturedImage != null)
			{
				VOtB1a9A6x(rv5mvGcDycFl26EPlB2.CapturedImage, rv5mvGcDycFl26EPlB2.CaptureBounds.Location, 1.0);
			}
		}
		catch (Exception ex)
		{
			System.Windows.Forms.MessageBox.Show(rA7neb5TDVvwyWyxwua.KJy58rGLXb(), "启动截图功能失败：" + ex.Message, "IP_Assurance", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			l4sBJI6tVh(list);
			rJOBUBdGPp(list2);
		}
	}

	public static void lK0B8Dimq2()
	{
		try
		{
			Process.Start(new ProcessStartInfo("ms-screenclip:")
			{
				UseShellExecute = true
			});
		}
		catch
		{
			Process.Start(new ProcessStartInfo("SnippingTool.exe")
			{
				UseShellExecute = true
			});
		}
	}

	public static void V8uBId6JSR()
	{
		try
		{
			Bitmap bitmap = AVLlS1cZQQwJQ2RsefC.SEvcbGvKps();
			Screen screen = Screen.PrimaryScreen ?? Screen.AllScreens[0];
			double val = Math.Min(0.3, Math.Min((double)screen.Bounds.Width / 2.0 / (double)bitmap.Width, (double)screen.Bounds.Height / 2.0 / (double)bitmap.Height));
			val = Math.Max(0.1, val);
			int num = (int)Math.Round((double)bitmap.Width * val);
			int num2 = (int)Math.Round((double)bitmap.Height * val);
			System.Drawing.Point point = new System.Drawing.Point(screen.Bounds.X + (screen.Bounds.Width - num) / 2, screen.Bounds.Y + (screen.Bounds.Height - num2) / 2);
			VOtB1a9A6x(bitmap, point, val);
		}
		catch (Exception ex)
		{
			System.Windows.Forms.MessageBox.Show(rA7neb5TDVvwyWyxwua.KJy58rGLXb(), "快速截图失败：" + ex.Message, "IP_Assurance", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void bpaBiR3K57()
	{
		tAKHV45ZlJVODNWxYiE[] array = dfCBKMIQgW.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Close();
		}
		dfCBKMIQgW.Clear();
	}

	public static bool o6HBH667NB(out string P_0)
	{
		P_0 = null;
		ykgbLvtohdM8ZnE1Vnd desktopPin = ftu1AgSpErBKqc6vp9f.Current.Config.DesktopPin;
		if (!desktopPin.Enabled)
		{
			HnSWbwVJF57OgVhQ2No.uQ7VKeL8py("DesktopPin");
			return true;
		}
		if (!HnSWbwVJF57OgVhQ2No.kKcV477mFM(desktopPin.Hotkey, (SMvGfVVI8pN4lQroEEl)1u, out var fLLBq1VHNF5GNnjaJrS2))
		{
			HnSWbwVJF57OgVhQ2No.uQ7VKeL8py("DesktopPin");
			P_0 = "钉桌面热键无效，请录制或输入 Alt/Ctrl/Shift/Win + 一个按键，例如 Alt+F1、Ctrl+Shift+Q。Fn 不是 Windows 可注册的修饰键。";
			return false;
		}
		if (!HnSWbwVJF57OgVhQ2No.LflVUiaoHY("DesktopPin", fLLBq1VHNF5GNnjaJrS2.Modifiers, fLLBq1VHNF5GNnjaJrS2.Key, SqNBgKb64d))
		{
			P_0 = "钉桌面热键注册失败，可能已被系统、Word 或其他程序占用。";
			return false;
		}
		return true;
	}

	public static void jTmBQtWvhT()
	{
		HnSWbwVJF57OgVhQ2No.uQ7VKeL8py("DesktopPin");
		bpaBiR3K57();
	}

	private static void VOtB1a9A6x(Image P_0, System.Drawing.Point P_1, double P_2)
	{
		_G_c__DisplayClass8_0 CS_8_locals_5 = new _G_c__DisplayClass8_0();
		CS_8_locals_5.DL7FzHGeRY = new tAKHV45ZlJVODNWxYiE(P_0, P_1, P_2);
		CS_8_locals_5.DL7FzHGeRY.FormClosed += delegate
		{
			dfCBKMIQgW.Remove(CS_8_locals_5.DL7FzHGeRY);
		};
		dfCBKMIQgW.Add(CS_8_locals_5.DL7FzHGeRY);
		CS_8_locals_5.DL7FzHGeRY.Show();
	}

	private static List<Window> slNBrIHLn5()
	{
		List<Window> list = new List<Window>();
		System.Windows.Application current = System.Windows.Application.Current;
		if (current == null)
		{
			return list;
		}
		foreach (Window window in current.Windows)
		{
			if (window.IsVisible)
			{
				list.Add(window);
			}
		}
		foreach (Window item in list)
		{
			item.Hide();
		}
		return list;
	}

	private static void l4sBJI6tVh(List<Window> P_0)
	{
		if (P_0 == null || P_0.Count == 0)
		{
			return;
		}
		foreach (Window item in P_0)
		{
			if (item.IsLoaded)
			{
				item.Show();
			}
		}
	}

	private static List<Form> V8wB3d2E8J()
	{
		List<Form> list = new List<Form>();
		foreach (Form openForm in System.Windows.Forms.Application.OpenForms)
		{
			if (openForm.Visible)
			{
				list.Add(openForm);
			}
		}
		foreach (Form item in list)
		{
			if (!item.IsDisposed)
			{
				item.Hide();
			}
		}
		System.Windows.Forms.Application.DoEvents();
		return list;
	}

	private static void rJOBUBdGPp(List<Form> P_0)
	{
		if (P_0 == null || P_0.Count == 0)
		{
			return;
		}
		foreach (Form item in P_0)
		{
			if (!item.IsDisposed)
			{
				item.Show();
			}
		}
	}

	static T2qy2kBDTEXPmLNlcDc()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		dfCBKMIQgW = new List<tAKHV45ZlJVODNWxYiE>();
	}
}
