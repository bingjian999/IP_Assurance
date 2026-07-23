using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AiConfigBootstrap;
using TableBorderConfig;
using AiSseStreamService3;
using ScreenshotCaptureHelper2;
using UiHelperService3;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using AiHelper_10;
using WordTableToolService;
using AiHelper_12;
using UiHelper_1;
using Helper_5;

namespace AiHelper_13;

internal static class AiHelper_13
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_0
	{
		public Rectangle zKmVTMLMmqG;

		public long zMMVTbLXwD5;

		public Helper_5 helper_5;

		public _G_c__DisplayClass30_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool BDrVTfvvg4V(IntPtr child, IntPtr _)
		{
			try
			{
				if (!ScreenshotCaptureHelper2.USD0wZPHF(child))
				{
					return true;
				}
				if (!ScreenshotCaptureHelper2.DcLA6kaCn(child, out var g776GxFFqI1ndqZk2gX))
				{
					return true;
				}
				Rectangle rectangle = Rectangle.FromLTRB(g776GxFFqI1ndqZk2gX.Left, g776GxFFqI1ndqZk2gX.Top, g776GxFFqI1ndqZk2gX.Right, g776GxFFqI1ndqZk2gX.Bottom);
				if (rectangle.Width < zKmVTMLMmqG.Width / 3 || rectangle.Height < zKmVTMLMmqG.Height / 4)
				{
					return true;
				}
				if (rectangle.Top < zKmVTMLMmqG.Top + 80 || rectangle.Bottom > zKmVTMLMmqG.Bottom + 8)
				{
					return true;
				}
				string text = y9KUMnj5eV(child);
				if (!text.StartsWith("_Ww", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
				if (!aOLUZ9Md4Z(child, out var fR3VTS5Zdu))
				{
					return true;
				}
				long num = (long)rectangle.Width * (long)rectangle.Height;
				num = ((!text.StartsWith("_WwG", StringComparison.OrdinalIgnoreCase)) ? (num * 4) : (num * 10));
				if (num > zMMVTbLXwD5)
				{
					zMMVTbLXwD5 = num;
					helper_5 = fR3VTS5Zdu;
				}
			}
			catch
			{
			}
			return true;
		}
	}

	private static readonly Timer fjWUni4xwA;

	private static bool fRAU7eu5Ui;

	private static bool FwQU5E6mY2;

	private static UiHelperService3 ConfigLoader;

	private static string NdIUeZlnm4;

	private static Rectangle fnoUyv1bhu;

	private static IntPtr WX1UXkkRIZ;

	private static IntPtr VtBUFW0YVW;

	private static IntPtr iL8UhoLpQ1;

	private static Rectangle ULDUaIQyxK;

	private static Microsoft.Office.Interop.Word.Application App => WordTableToolService.WordApp;

	public static bool IsActive => FwQU5E6mY2;

	public static void EnuUgD338d()
	{
		if (App != null)
		{
			FwQU5E6mY2 = true;
			S4iUrDh2aV();
			Oh4U3Zi9ay();
			JSMUHT53aW();
			oYhUKFtht4();
			fjWUni4xwA.Start();
			TableBorderConfig.Instance.UpdateConfig(delegate(AiHelper_12 c)
			{
				c.OfficeTab.Enabled = true;
			});
			atxUOg3h4C();
		}
	}

	public static void J4IU837YfN()
	{
		FwQU5E6mY2 = false;
		fjWUni4xwA.Stop();
		ConfigLoader?.LoadConfig();
		aBgUjMZb6b();
		TableBorderConfig.Instance.UpdateConfig(delegate(AiHelper_12 c)
		{
			c.OfficeTab.Enabled = false;
		});
		atxUOg3h4C();
	}

	public static void prXUI8btQK()
	{
		if (IsActive)
		{
			J4IU837YfN();
		}
		else
		{
			EnuUgD338d();
		}
	}

	public static void PSkUiNYvdJ()
	{
		FwQU5E6mY2 = false;
		fjWUni4xwA.Stop();
		iQKUJu2YEc();
		aBgUjMZb6b();
		if (ConfigLoader != null)
		{
			ConfigLoader.Close();
		}
		ConfigLoader = null;
		fnoUyv1bhu = Rectangle.Empty;
		WX1UXkkRIZ = IntPtr.Zero;
		VtBUFW0YVW = IntPtr.Zero;
		iL8UhoLpQ1 = IntPtr.Zero;
		ULDUaIQyxK = Rectangle.Empty;
	}

	public static void JSMUHT53aW()
	{
		if (ConfigLoader != null && !ConfigLoader.IsDisposed)
		{
			ConfigLoader.WNa744ZxJ3(wa8ULVjivm());
		}
	}

	internal static void fgqUQKfffo(string P_0)
	{
		try
		{
			Document document = fJFUsCKWg0(P_0);
			if (document != null)
			{
				document.Activate();
				EWXUS7nnLg();
				JSMUHT53aW();
				oYhUKFtht4();
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[OfficeTab] Activate document failed: " + ex.Message);
		}
	}

	internal static void hMTU1YUAHc(string P_0)
	{
		try
		{
			Document document = fJFUsCKWg0(P_0);
			if (document != null)
			{
				object SaveChanges = WdSaveOptions.wdPromptToSaveChanges;
				object OriginalFormat = Type.Missing;
				object RouteDocument = Type.Missing;
				document.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[OfficeTab] Close document failed: " + ex.Message);
		}
		finally
		{
			WordTableToolService.SyncContext?.Post(delegate
			{
				if (FwQU5E6mY2)
				{
					JSMUHT53aW();
					oYhUKFtht4();
				}
			}, null);
		}
	}

	private static void S4iUrDh2aV()
	{
		if (!fRAU7eu5Ui && App != null)
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentChange").AddEventHandler(App, new ApplicationEvents4_DocumentChangeEventHandler(NiiUoZnXPr));
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentOpen").AddEventHandler(App, new ApplicationEvents4_DocumentOpenEventHandler(jLeUG2FWg3));
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "NewDocument").AddEventHandler(App, new ApplicationEvents4_NewDocumentEventHandler(lZRUCIiDVA));
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentBeforeClose").AddEventHandler(App, new ApplicationEvents4_DocumentBeforeCloseEventHandler(y61UpFn2tI));
			fjWUni4xwA.Tick += a3lUUeMMTx;
			fRAU7eu5Ui = true;
		}
	}

	private static void iQKUJu2YEc()
	{
		if (fRAU7eu5Ui && App != null)
		{
			try
			{
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentChange").RemoveEventHandler(App, new ApplicationEvents4_DocumentChangeEventHandler(NiiUoZnXPr));
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentOpen").RemoveEventHandler(App, new ApplicationEvents4_DocumentOpenEventHandler(jLeUG2FWg3));
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "NewDocument").RemoveEventHandler(App, new ApplicationEvents4_NewDocumentEventHandler(lZRUCIiDVA));
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "DocumentBeforeClose").RemoveEventHandler(App, new ApplicationEvents4_DocumentBeforeCloseEventHandler(y61UpFn2tI));
			}
			catch
			{
			}
			fjWUni4xwA.Tick -= a3lUUeMMTx;
			fRAU7eu5Ui = false;
		}
	}

	private static void Oh4U3Zi9ay()
	{
		if (ConfigLoader == null || ConfigLoader.IsDisposed)
		{
			ConfigLoader = new UiHelperService3();
			ConfigLoader.FormClosed += delegate
			{
				ConfigLoader = null;
			};
		}
	}

	private static void a3lUUeMMTx(object P_0, EventArgs P_1)
	{
		if (!FwQU5E6mY2 || ConfigLoader == null || ConfigLoader.IsDisposed)
		{
			return;
		}
		try
		{
			if (TableBorderConfig.Current.Config.OfficeTab.AutoHideOnDeactivate && !zTdUwGdqmA())
			{
				ConfigLoader.LoadConfig();
				aBgUjMZb6b();
				return;
			}
			string text = mrdUtgmTLg();
			if (text != NdIUeZlnm4)
			{
				NdIUeZlnm4 = text;
				JSMUHT53aW();
			}
			oYhUKFtht4();
		}
		catch
		{
		}
	}

	private static bool oYhUKFtht4()
	{
		if (ConfigLoader == null || ConfigLoader.IsDisposed || App == null)
		{
			return false;
		}
		IntPtr intPtr = cgkUbBGhw1();
		if (intPtr == IntPtr.Zero)
		{
			ConfigLoader.LoadConfig();
			aBgUjMZb6b();
			return false;
		}
		if (!X5JUYxFvGK(intPtr, out var n9oC7GUxmq3PwnPT976))
		{
			ConfigLoader.LoadConfig();
			aBgUjMZb6b();
			return false;
		}
		int num = ConfigLoader.o1Y7jLQCiS(n9oC7GUxmq3PwnPT976.vBSKBPTg82.Width);
		if (!S71UEc0wa2(n9oC7GUxmq3PwnPT976, num, out var rectangle))
		{
			ConfigLoader.LoadConfig();
			aBgUjMZb6b();
			return false;
		}
		if (rectangle.Width <= 80 || rectangle.Height <= 12)
		{
			ConfigLoader.LoadConfig();
			aBgUjMZb6b();
			return false;
		}
		if (WX1UXkkRIZ != intPtr)
		{
			try
			{
				ScreenshotCaptureHelper2.r8rV8AwJBn(ConfigLoader.Handle, -8, intPtr);
			}
			catch
			{
			}
			WX1UXkkRIZ = intPtr;
		}
		if (fnoUyv1bhu != rectangle)
		{
			ScreenshotCaptureHelper2.qVGVVA8Epe(ConfigLoader.Handle, IntPtr.Zero, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height, 80);
			fnoUyv1bhu = rectangle;
		}
		ConfigLoader.lr57EfRfpj();
		return true;
	}

	private static bool S71UEc0wa2(Helper_5 P_0, int P_1, out Rectangle P_2)
	{
		P_2 = Rectangle.Empty;
		if (P_0.intPtr == IntPtr.Zero || P_0.intPtr == IntPtr.Zero)
		{
			return false;
		}
		if (VtBUFW0YVW != IntPtr.Zero && VtBUFW0YVW != P_0.intPtr)
		{
			aBgUjMZb6b();
		}
		if (VtBUFW0YVW == IntPtr.Zero)
		{
			VtBUFW0YVW = P_0.intPtr;
			iL8UhoLpQ1 = P_0.intPtr;
			ULDUaIQyxK = P_0.vBSKBPTg82;
		}
		if (iL8UhoLpQ1 != P_0.intPtr)
		{
			aBgUjMZb6b();
			VtBUFW0YVW = P_0.intPtr;
			iL8UhoLpQ1 = P_0.intPtr;
			ULDUaIQyxK = P_0.vBSKBPTg82;
		}
		D2OU2UZetx(P_0, P_1);
		if (!z3nUfQnt6I(iL8UhoLpQ1, out var point))
		{
			return false;
		}
		Rectangle uLDUaIQyxK = ULDUaIQyxK;
		int num = uLDUaIQyxK.Height - P_1;
		if (num < 120)
		{
			return false;
		}
		Rectangle rectangle = new Rectangle(uLDUaIQyxK.Left, uLDUaIQyxK.Top + P_1, uLDUaIQyxK.Width, num);
		ScreenshotCaptureHelper2.qVGVVA8Epe(P_0.intPtr, IntPtr.Zero, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height, 80);
		P_2 = new Rectangle(point.X + uLDUaIQyxK.Left, point.Y + uLDUaIQyxK.Top, uLDUaIQyxK.Width, P_1);
		return true;
	}

	private static void D2OU2UZetx(Helper_5 P_0, int P_1)
	{
		if (VtBUFW0YVW != P_0.intPtr || ULDUaIQyxK == Rectangle.Empty)
		{
			return;
		}
		Rectangle uLDUaIQyxK = ULDUaIQyxK;
		Rectangle rectangle = new Rectangle(uLDUaIQyxK.Left, uLDUaIQyxK.Top + P_1, uLDUaIQyxK.Width, Math.Max(1, uLDUaIQyxK.Height - P_1));
		if (!LqrU4OIMjJ(P_0.vBSKBPTg82, rectangle))
		{
			if (Math.Abs(P_0.vBSKBPTg82.Top - rectangle.Top) <= 4)
			{
				ULDUaIQyxK = new Rectangle(P_0.vBSKBPTg82.Left, P_0.vBSKBPTg82.Top - P_1, P_0.vBSKBPTg82.Width, P_0.vBSKBPTg82.Height + P_1);
			}
			else
			{
				ULDUaIQyxK = P_0.vBSKBPTg82;
			}
		}
	}

	private static bool LqrU4OIMjJ(Rectangle P_0, Rectangle P_1)
	{
		if (Math.Abs(P_0.Left - P_1.Left) <= 4 && Math.Abs(P_0.Top - P_1.Top) <= 4 && Math.Abs(P_0.Width - P_1.Width) <= 8)
		{
			return Math.Abs(P_0.Height - P_1.Height) <= 8;
		}
		return false;
	}

	private static void aBgUjMZb6b()
	{
		if (VtBUFW0YVW == IntPtr.Zero)
		{
			return;
		}
		try
		{
			if (ScreenshotCaptureHelper2.GAekICEQL(VtBUFW0YVW) && ULDUaIQyxK != Rectangle.Empty)
			{
				ScreenshotCaptureHelper2.qVGVVA8Epe(VtBUFW0YVW, IntPtr.Zero, ULDUaIQyxK.Left, ULDUaIQyxK.Top, ULDUaIQyxK.Width, ULDUaIQyxK.Height, 80);
			}
		}
		catch
		{
		}
		VtBUFW0YVW = IntPtr.Zero;
		iL8UhoLpQ1 = IntPtr.Zero;
		ULDUaIQyxK = Rectangle.Empty;
		fnoUyv1bhu = Rectangle.Empty;
	}

	private static bool X5JUYxFvGK(IntPtr P_0, out Helper_5 P_1)
	{
		_G_c__DisplayClass30_0 CS_8_locals_12 = new _G_c__DisplayClass30_0();
		P_1 = default(Helper_5);
		if (!ScreenshotCaptureHelper2.DcLA6kaCn(P_0, out var g776GxFFqI1ndqZk2gX))
		{
			return false;
		}
		CS_8_locals_12.zKmVTMLMmqG = Rectangle.FromLTRB(g776GxFFqI1ndqZk2gX.Left, g776GxFFqI1ndqZk2gX.Top, g776GxFFqI1ndqZk2gX.Right, g776GxFFqI1ndqZk2gX.Bottom);
		CS_8_locals_12.helper_5 = default(Helper_5);
		CS_8_locals_12.zMMVTbLXwD5 = 0L;
		ScreenshotCaptureHelper2.sUYV6arCCC(P_0, delegate(IntPtr child, IntPtr _)
		{
			try
			{
				if (!ScreenshotCaptureHelper2.USD0wZPHF(child))
				{
					return true;
				}
				if (!ScreenshotCaptureHelper2.DcLA6kaCn(child, out var g776GxFFqI1ndqZk2gX2))
				{
					return true;
				}
				Rectangle rectangle = Rectangle.FromLTRB(g776GxFFqI1ndqZk2gX2.Left, g776GxFFqI1ndqZk2gX2.Top, g776GxFFqI1ndqZk2gX2.Right, g776GxFFqI1ndqZk2gX2.Bottom);
				if (rectangle.Width < CS_8_locals_12.zKmVTMLMmqG.Width / 3 || rectangle.Height < CS_8_locals_12.zKmVTMLMmqG.Height / 4)
				{
					return true;
				}
				if (rectangle.Top < CS_8_locals_12.zKmVTMLMmqG.Top + 80 || rectangle.Bottom > CS_8_locals_12.zKmVTMLMmqG.Bottom + 8)
				{
					return true;
				}
				string text = y9KUMnj5eV(child);
				if (!text.StartsWith("[OfficeTab] Activate document failed: ", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
				if (!aOLUZ9Md4Z(child, out var fR3VTS5Zdu))
				{
					return true;
				}
				long num = (long)rectangle.Width * (long)rectangle.Height;
				num = ((!text.StartsWith("[OfficeTab] Close document failed: ", StringComparison.OrdinalIgnoreCase)) ? (num * 4) : (num * 10));
				if (num > CS_8_locals_12.zMMVTbLXwD5)
				{
					CS_8_locals_12.zMMVTbLXwD5 = num;
					CS_8_locals_12.helper_5 = fR3VTS5Zdu;
				}
			}
			catch
			{
			}
			return true;
		}, IntPtr.Zero);
		if (CS_8_locals_12.helper_5.intPtr == IntPtr.Zero)
		{
			return false;
		}
		P_1 = CS_8_locals_12.helper_5;
		return true;
	}

	private static bool aOLUZ9Md4Z(IntPtr P_0, out Helper_5 P_1)
	{
		P_1 = default(Helper_5);
		IntPtr intPtr = ScreenshotCaptureHelper2.OyTxvptUZ(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return false;
		}
		if (!ScreenshotCaptureHelper2.DcLA6kaCn(P_0, out var g776GxFFqI1ndqZk2gX))
		{
			return false;
		}
		if (!z3nUfQnt6I(intPtr, out var point))
		{
			return false;
		}
		Rectangle sl2KVgL5Cf = Rectangle.FromLTRB(g776GxFFqI1ndqZk2gX.Left, g776GxFFqI1ndqZk2gX.Top, g776GxFFqI1ndqZk2gX.Right, g776GxFFqI1ndqZk2gX.Bottom);
		P_1 = new Helper_5
		{
			intPtr = P_0,
			intPtr = intPtr,
			rectangle = sl2KVgL5Cf,
			vBSKBPTg82 = new Rectangle(sl2KVgL5Cf.Left - point.X, sl2KVgL5Cf.Top - point.Y, sl2KVgL5Cf.Width, sl2KVgL5Cf.Height)
		};
		return true;
	}

	private static bool z3nUfQnt6I(IntPtr P_0, out Point P_1)
	{
		P_1 = Point.Empty;
		ScreenshotCaptureHelper2.SYRyATFyE10hKbRqs5x sYRyATFyE10hKbRqs5x = new ScreenshotCaptureHelper2.SYRyATFyE10hKbRqs5x
		{
			X = 0,
			oURFXOAIJr = 0
		};
		if (!ScreenshotCaptureHelper2.NZHWMtPPQ(P_0, ref sYRyATFyE10hKbRqs5x))
		{
			return false;
		}
		P_1 = new Point(sYRyATFyE10hKbRqs5x.X, sYRyATFyE10hKbRqs5x.oURFXOAIJr);
		return true;
	}

	private static string y9KUMnj5eV(IntPtr P_0)
	{
		StringBuilder stringBuilder = new StringBuilder(128);
		if (ScreenshotCaptureHelper2.RajVuvo2tr(P_0, stringBuilder, stringBuilder.Capacity) <= 0)
		{
			return string.Empty;
		}
		return stringBuilder.ToString();
	}

	private static IntPtr cgkUbBGhw1()
	{
		try
		{
			if (App?.ActiveWindow != null)
			{
				return new IntPtr(App.ActiveWindow.Hwnd);
			}
		}
		catch
		{
		}
		return IntPtr.Zero;
	}

	private static void EWXUS7nnLg()
	{
		try
		{
			IntPtr intPtr = cgkUbBGhw1();
			if (!(intPtr == IntPtr.Zero))
			{
				ScreenshotCaptureHelper2.d2kP0Du2a(intPtr);
			}
		}
		catch
		{
		}
	}

	private static bool zTdUwGdqmA()
	{
		try
		{
			IntPtr intPtr = cgkUbBGhw1();
			IntPtr intPtr2 = ScreenshotCaptureHelper2.cH4VBSeFlb();
			if (intPtr == IntPtr.Zero || intPtr2 == IntPtr.Zero)
			{
				return false;
			}
			if (!(intPtr2 == intPtr))
			{
				IntPtr value = intPtr2;
				IntPtr? obj = ConfigLoader?.Handle;
				if (!(value == obj))
				{
					ScreenshotCaptureHelper2.Kl5V9YsO3Z(intPtr, out var num);
					ScreenshotCaptureHelper2.Kl5V9YsO3Z(intPtr2, out var num2);
					return num != 0 && num == num2;
				}
			}
			return true;
		}
		catch
		{
			return true;
		}
	}

	private static string mrdUtgmTLg()
	{
		try
		{
			if (App?.Documents == null)
			{
				return string.Empty;
			}
			string text = GnPUltXIIH(App.ActiveDocument);
			return App.Documents.Count + "|" + text + "|" + cgkUbBGhw1();
		}
		catch
		{
			return string.Empty;
		}
	}

	private static List<AiHelper_10> wa8ULVjivm()
	{
		List<AiHelper_10> list = new List<AiHelper_10>();
		try
		{
			if (App?.Documents == null)
			{
				return list;
			}
			string b = GnPUltXIIH(App.ActiveDocument);
			foreach (Document document in App.Documents)
			{
				try
				{
					string text = GnPUltXIIH(document);
					list.Add(new AiHelper_10
					{
						Key = text,
						Name = document.Name,
						FullName = epYUNGAqt4(document),
						IsActive = string.Equals(text, b, StringComparison.OrdinalIgnoreCase),
						IsSaved = JnAUmk5gOX(document)
					});
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	private static Document fJFUsCKWg0(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0) || App?.Documents == null)
		{
			return null;
		}
		foreach (Document document in App.Documents)
		{
			try
			{
				if (string.Equals(GnPUltXIIH(document), P_0, StringComparison.OrdinalIgnoreCase))
				{
					return document;
				}
			}
			catch
			{
			}
		}
		return null;
	}

	private static string GnPUltXIIH(Document P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		string text = epYUNGAqt4(P_0);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return P_0.Name;
	}

	private static string epYUNGAqt4(Document P_0)
	{
		try
		{
			return P_0.FullName ?? string.Empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static bool JnAUmk5gOX(Document P_0)
	{
		try
		{
			return P_0.Saved;
		}
		catch
		{
			return true;
		}
	}

	private static void NiiUoZnXPr()
	{
		if (FwQU5E6mY2)
		{
			JSMUHT53aW();
			oYhUKFtht4();
		}
	}

	private static void jLeUG2FWg3(Document P_0)
	{
		if (FwQU5E6mY2)
		{
			JSMUHT53aW();
			oYhUKFtht4();
		}
	}

	private static void lZRUCIiDVA(Document P_0)
	{
		if (FwQU5E6mY2)
		{
			JSMUHT53aW();
			oYhUKFtht4();
		}
	}

	private static void y61UpFn2tI(Document P_0, ref bool P_1)
	{
		if (!FwQU5E6mY2)
		{
			return;
		}
		WordTableToolService.SyncContext?.Post(delegate
		{
			if (FwQU5E6mY2)
			{
				JSMUHT53aW();
				oYhUKFtht4();
			}
		}, null);
	}

	private static void atxUOg3h4C()
	{
		try
		{
			UiHelper_1.Ribbons.Ribbon1.R2xeRcIY7q(IsActive);
		}
		catch
		{
		}
	}

	static AiHelper_13()
	{
		SseStreamInitializer.InitializeRuntime();
		fjWUni4xwA = new Timer
		{
			Interval = 220
		};
		NdIUeZlnm4 = string.Empty;
		fnoUyv1bhu = Rectangle.Empty;
		WX1UXkkRIZ = IntPtr.Zero;
		VtBUFW0YVW = IntPtr.Zero;
		iL8UhoLpQ1 = IntPtr.Zero;
		ULDUaIQyxK = Rectangle.Empty;
	}
}
