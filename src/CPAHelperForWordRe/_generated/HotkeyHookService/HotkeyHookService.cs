using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AiSseStreamService3;
using Helper_19;
using ScreenshotCaptureHelper2;
using SseStreamInitializer;
using UiHelperService2;

namespace HotkeyHookService;

internal static class HotkeyHookService
{
	private sealed class Yr12XUFhdtS3B7K8cNg : NativeWindow, IDisposable
	{
		public Yr12XUFhdtS3B7K8cNg()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
			CreateHandle(new CreateParams
			{
				Caption = "IPAssuranceWordHotKeyWindow"
			});
		}

		protected override void WndProc(ref Message P_0)
		{
			if (P_0.Msg == 786)
			{
				w4CVS1Yepv(P_0.WParam.ToInt32());
			}
			base.WndProc(ref P_0);
		}

		public void Dispose()
		{
			DestroyHandle();
		}
	}

	private static readonly Dictionary<string, int> b0YVwcUdpZ;

	private static readonly Dictionary<int, Action> e87VtAmKrn;

	private static Yr12XUFhdtS3B7K8cNg zMRVL5C0BL;

	private static int wsHVswknag;

	public static bool LflVUiaoHY(string P_0, SMvGfVVI8pN4lQroEEl P_1, Keys P_2, Action P_3)
	{
		if (string.IsNullOrWhiteSpace(P_0) || P_3 == null)
		{
			return false;
		}
		soIVb8dM0t();
		uQ7VKeL8py(P_0);
		int num = ++wsHVswknag;
		if (!ScreenshotCaptureHelper2.mIozr8woi(zMRVL5C0BL.Handle, num, (uint)P_1, (uint)P_2))
		{
			return false;
		}
		b0YVwcUdpZ[P_0] = num;
		e87VtAmKrn[num] = P_3;
		return true;
	}

	public static void uQ7VKeL8py(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0) && zMRVL5C0BL != null && b0YVwcUdpZ.TryGetValue(P_0, out var value))
		{
			ScreenshotCaptureHelper2.TAqVRPUvsq(zMRVL5C0BL.Handle, value);
			b0YVwcUdpZ.Remove(P_0);
			e87VtAmKrn.Remove(value);
		}
	}

	public static void qr8VE3D2J6()
	{
		if (zMRVL5C0BL == null)
		{
			return;
		}
		foreach (int key in e87VtAmKrn.Keys)
		{
			ScreenshotCaptureHelper2.TAqVRPUvsq(zMRVL5C0BL.Handle, key);
		}
		b0YVwcUdpZ.Clear();
		e87VtAmKrn.Clear();
		zMRVL5C0BL.Dispose();
		zMRVL5C0BL = null;
	}

	public static bool dHCV2a6XOA(string P_0, out Keys P_1)
	{
		P_1 = Keys.None;
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		string text = P_0.Trim().ToUpperInvariant();
		if (text.StartsWith("ALT+", StringComparison.OrdinalIgnoreCase))
		{
			text = text.Substring(4).Trim();
		}
		text = text.Replace(" ", string.Empty).Replace("-", string.Empty).Replace("_", string.Empty);
		if (text.Length == 1)
		{
			char c = text[0];
			if (c >= 'A' && c <= 'Z')
			{
				P_1 = (Keys)Enum.Parse(typeof(Keys), text, ignoreCase: true);
				return true;
			}
			if (c >= '0' && c <= '9')
			{
				P_1 = (Keys)Enum.Parse(typeof(Keys), "D" + text, ignoreCase: true);
				return true;
			}
		}
		if (text != null)
		{
			switch (text.Length)
			{
			case 3:
			{
				char c2 = text[0];
				if (c2 != 'D')
				{
					if (c2 != 'E')
					{
						if (c2 != 'I' || !(text == "ESC"))
						{
							break;
						}
						goto IL_06d7;
					}
					if (!(text == "DEL"))
					{
						break;
					}
					goto IL_06ba;
				}
				if (!(text == "INS"))
				{
					break;
				}
				goto IL_06d1;
			}
			case 6:
			{
				char c2 = text[0];
				if ((uint)c2 <= 69u)
				{
					if (c2 != 'D')
					{
						if (c2 != 'E' || !(text == "ESCAPE"))
						{
							break;
						}
						goto IL_06ba;
					}
					if (!(text == "RETURN"))
					{
						break;
					}
					goto IL_06d1;
				}
				if (c2 != 'I')
				{
					if (c2 != 'P')
					{
						if (c2 != 'R' || !(text == "DELETE"))
						{
							break;
						}
						goto IL_06c0;
					}
					if (!(text == "INSERT"))
					{
						break;
					}
					goto IL_06dd;
				}
				if (!(text == "PAGEUP"))
				{
					break;
				}
				goto IL_06d7;
			}
			case 5:
			{
				char c2 = text[0];
				if (c2 != 'E')
				{
					if (c2 != 'S' || !(text == "ENTER"))
					{
						break;
					}
					goto IL_06c6;
				}
				if (!(text == "SPACE"))
				{
					break;
				}
				goto IL_06c0;
			}
			case 8:
			{
				char c2 = text[0];
				if (c2 != 'C')
				{
					if (c2 != 'P')
					{
						if (c2 != 'S' || !(text == "SPACEBAR"))
						{
							break;
						}
						goto IL_06c6;
					}
					if (!(text == "PAGEDOWN"))
					{
						break;
					}
					goto IL_06e3;
				}
				if (!(text == "CAPSLOCK"))
				{
					break;
				}
				P_1 = Keys.Capital;
				return true;
			}
			case 9:
				switch (text[0])
				{
				case 'B':
					if (!(text == "BACKSPACE"))
					{
						break;
					}
					P_1 = Keys.Back;
					return true;
				case 'L':
					if (!(text == "LEFTARROW"))
					{
						break;
					}
					P_1 = Keys.Left;
					return true;
				case 'D':
					if (!(text == "DOWNARROW"))
					{
						break;
					}
					P_1 = Keys.Down;
					return true;
				}
				break;
			case 4:
			{
				char c2 = text[2];
				if (c2 != 'D')
				{
					if (c2 != 'U' || !(text == "PGUP"))
					{
						break;
					}
					goto IL_06dd;
				}
				if (!(text == "PGDN"))
				{
					break;
				}
				goto IL_06e3;
			}
			case 10:
				switch (text[0])
				{
				case 'R':
					if (!(text == "RIGHTARROW"))
					{
						break;
					}
					P_1 = Keys.Right;
					return true;
				case 'S':
					if (!(text == "SCROLLLOCK"))
					{
						break;
					}
					P_1 = Keys.Scroll;
					return true;
				}
				break;
			case 7:
				{
					switch (text[0])
					{
					case 'U':
						if (!(text == "UPARROW"))
						{
							break;
						}
						P_1 = Keys.Up;
						return true;
					case 'N':
						if (!(text == "NUMLOCK"))
						{
							break;
						}
						P_1 = Keys.NumLock;
						return true;
					}
					break;
				}
				IL_06ba:
				P_1 = Keys.Escape;
				return true;
				IL_06c6:
				P_1 = Keys.Space;
				return true;
				IL_06c0:
				P_1 = Keys.Return;
				return true;
				IL_06d7:
				P_1 = Keys.Insert;
				return true;
				IL_06e3:
				P_1 = Keys.Next;
				return true;
				IL_06d1:
				P_1 = Keys.Delete;
				return true;
				IL_06dd:
				P_1 = Keys.Prior;
				return true;
			}
		}
		if (text.StartsWith("F", StringComparison.OrdinalIgnoreCase) && int.TryParse(text.Substring(1), out var result) && result >= 1 && result <= 24)
		{
			P_1 = (Keys)(112 + (result - 1));
			return true;
		}
		if (Enum.TryParse<Keys>(text, ignoreCase: true, out var result2))
		{
			P_1 = result2;
			return hpIVjxJmGM(P_1);
		}
		return false;
	}

	public static bool kKcV477mFM(string P_0, SMvGfVVI8pN4lQroEEl P_1, out UiHelperService2 P_2)
	{
		P_2 = default(UiHelperService2);
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		SMvGfVVI8pN4lQroEEl sMvGfVVI8pN4lQroEEl = SMvGfVVI8pN4lQroEEl.None;
		string text = null;
		string[] array = P_0.Replace("＋", "+").Split(new char[1] { '+' }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text2 in array)
		{
			string text3 = QJPVMTwXDd(text2);
			if (string.IsNullOrWhiteSpace(text3))
			{
				continue;
			}
			if (Q4aVfJuxv0(text3, out var sMvGfVVI8pN4lQroEEl2))
			{
				sMvGfVVI8pN4lQroEEl |= sMvGfVVI8pN4lQroEEl2;
				continue;
			}
			if (string.Equals(text3, "FN", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			if (text != null)
			{
				return false;
			}
			text = text2;
		}
		if (text == null)
		{
			return false;
		}
		if (!dHCV2a6XOA(text, out var key))
		{
			return false;
		}
		if (sMvGfVVI8pN4lQroEEl == SMvGfVVI8pN4lQroEEl.None)
		{
			sMvGfVVI8pN4lQroEEl = P_1;
		}
		if (sMvGfVVI8pN4lQroEEl == SMvGfVVI8pN4lQroEEl.None)
		{
			return false;
		}
		P_2 = new UiHelperService2
		{
			Modifiers = sMvGfVVI8pN4lQroEEl,
			Key = key
		};
		return true;
	}

	public static bool hpIVjxJmGM(Keys P_0)
	{
		P_0 &= Keys.KeyCode;
		switch (P_0)
		{
		case Keys.None:
			return false;
		case Keys.ShiftKey:
		case Keys.ControlKey:
		case Keys.LWin:
		case Keys.RWin:
		case Keys.LShiftKey:
		case Keys.RShiftKey:
		case Keys.LControlKey:
		case Keys.RControlKey:
		case Keys.LMenu:
		case Keys.RMenu:
		case Keys.Alt:
			return false;
		default:
			return true;
		}
	}

	public static string KgeVYgBu4k(UiHelperService2 P_0)
	{
		List<string> list = new List<string>();
		if ((P_0.Modifiers & (SMvGfVVI8pN4lQroEEl)2u) == (SMvGfVVI8pN4lQroEEl)2u)
		{
			list.Add("Ctrl");
		}
		if ((P_0.Modifiers & (SMvGfVVI8pN4lQroEEl)4u) == (SMvGfVVI8pN4lQroEEl)4u)
		{
			list.Add("Shift");
		}
		if ((P_0.Modifiers & (SMvGfVVI8pN4lQroEEl)1u) == (SMvGfVVI8pN4lQroEEl)1u)
		{
			list.Add("Alt");
		}
		if ((P_0.Modifiers & (SMvGfVVI8pN4lQroEEl)8u) == (SMvGfVVI8pN4lQroEEl)8u)
		{
			list.Add("Win");
		}
		list.Add(Eo5VZsOR4p(P_0.Key));
		return string.Join("+", list);
	}

	public static string Eo5VZsOR4p(Keys P_0)
	{
		P_0 &= Keys.KeyCode;
		if (P_0 >= Keys.A && P_0 <= Keys.Z)
		{
			return P_0.ToString().ToUpperInvariant();
		}
		if (P_0 >= Keys.D0 && P_0 <= Keys.D9)
		{
			return ((int)(P_0 - 48)).ToString();
		}
		if (P_0 >= Keys.F1 && P_0 <= Keys.F24)
		{
			return "F" + (int)(P_0 - 112 + 1);
		}
		if (P_0 >= Keys.NumPad0 && P_0 <= Keys.NumPad9)
		{
			return "NUMPAD" + (int)(P_0 - 96);
		}
		return P_0 switch
		{
			Keys.Escape => "ESC", 
			Keys.Return => "ENTER", 
			Keys.Space => "SPACE", 
			Keys.Back => "BACKSPACE", 
			Keys.Delete => "DELETE", 
			Keys.Insert => "INSERT", 
			Keys.Prior => "PAGEUP", 
			Keys.Next => "PAGEDOWN", 
			Keys.Left => "LEFT", 
			Keys.Right => "RIGHT", 
			Keys.Up => "UP", 
			Keys.Down => "DOWN", 
			Keys.Capital => "CAPSLOCK", 
			Keys.NumLock => "NUMLOCK", 
			Keys.Scroll => "SCROLLLOCK", 
			_ => P_0.ToString().ToUpperInvariant(), 
		};
	}

	private static bool Q4aVfJuxv0(string P_0, out SMvGfVVI8pN4lQroEEl P_1)
	{
		P_1 = SMvGfVVI8pN4lQroEEl.None;
		if (P_0 != null)
		{
			switch (P_0.Length)
			{
			case 3:
			{
				char c = P_0[0];
				if (c != 'A')
				{
					if (c != 'W' || !(P_0 == "ALT"))
					{
						break;
					}
					goto IL_0217;
				}
				if (!(P_0 == "WIN"))
				{
					break;
				}
				goto IL_0208;
			}
			case 4:
			{
				char c = P_0[0];
				if (c != 'C')
				{
					if (c != 'M' || !(P_0 == "MENU"))
					{
						break;
					}
					goto IL_0208;
				}
				if (!(P_0 == "CTRL"))
				{
					break;
				}
				goto IL_020d;
			}
			case 7:
			{
				char c = P_0[3];
				if (c != 'D')
				{
					if (c != 'M')
					{
						if (c != 'T' || !(P_0 == "CONTROL"))
						{
							break;
						}
						goto IL_020d;
					}
					if (!(P_0 == "WINDOWS"))
					{
						break;
					}
				}
				else if (!(P_0 == "COMMAND"))
				{
					break;
				}
				goto IL_0217;
			}
			case 5:
				{
					if (!(P_0 == "SHIFT"))
					{
						break;
					}
					P_1 = (SMvGfVVI8pN4lQroEEl)4u;
					return true;
				}
				IL_0208:
				P_1 = (SMvGfVVI8pN4lQroEEl)1u;
				return true;
				IL_020d:
				P_1 = (SMvGfVVI8pN4lQroEEl)2u;
				return true;
				IL_0217:
				P_1 = (SMvGfVVI8pN4lQroEEl)8u;
				return true;
			}
		}
		return false;
	}

	private static string QJPVMTwXDd(string P_0)
	{
		return (P_0 ?? string.Empty).Trim().ToUpperInvariant().Replace(" ", string.Empty)
			.Replace("-", string.Empty)
			.Replace("_", string.Empty);
	}

	private static void soIVb8dM0t()
	{
		if (zMRVL5C0BL == null)
		{
			zMRVL5C0BL = new Yr12XUFhdtS3B7K8cNg();
		}
	}

	private static void w4CVS1Yepv(int P_0)
	{
		if (!e87VtAmKrn.TryGetValue(P_0, out var value))
		{
			return;
		}
		try
		{
			value();
		}
		catch
		{
		}
	}

	static HotkeyHookService()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		b0YVwcUdpZ = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		e87VtAmKrn = new Dictionary<int, Action>();
		wsHVswknag = 23040;
	}
}
