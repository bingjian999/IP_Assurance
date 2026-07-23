using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WordWindowInfo;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;

namespace AiTargetBinder;

internal sealed class AiTargetBinder
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_0
	{
		public Document doc;

		public _G_c__DisplayClass30_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal string rvxqW9cAcd()
		{
			return doc.FullName;
		}

		internal string owkq0LTwqi()
		{
			return doc.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass32_0
	{
		public Document UoHqz6wiT2;

		public _G_c__DisplayClass32_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal string EShqkH5YFs()
		{
			return UoHqz6wiT2.Name;
		}

		internal string N4pqx6IsCx()
		{
			return UoHqz6wiT2.FullName;
		}

		internal string BMuqdAhyxs()
		{
			return UoHqz6wiT2.Path;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass38_0
	{
		public Document IcoPBTyHo2;

		public _G_c__DisplayClass38_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal string BwoPRYb6HE()
		{
			return IcoPBTyHo2.FullName;
		}

		internal string WcLPVMnm2Z()
		{
			return IcoPBTyHo2.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass39_0
	{
		public Document JCBP6qPUa5;

		public _G_c__DisplayClass39_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal string Q1lP9djNlS()
		{
			return JCBP6qPUa5.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass40_0
	{
		public Document khWPDeUAXa;

		public _G_c__DisplayClass40_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal string gNtPuTLHwo()
		{
			return khWPDeUAXa.Name;
		}
	}

	[CompilerGenerated]
	private string EJBuqWERwe;

	[CompilerGenerated]
	private int zl1uPV5ea4;

	[CompilerGenerated]
	private string JqBuASpfAI;

	[CompilerGenerated]
	private string ri4uvtPvsG;

	[CompilerGenerated]
	private string sCPuWnOnOg;

	private Window hMwu01diWC;

	private Document bOYuksQ0qF;

	public string WindowKey
	{
		[CompilerGenerated]
		get
		{
			return EJBuqWERwe;
		}
		[CompilerGenerated]
		private set
		{
			EJBuqWERwe = value;
		}
	}

	public int WindowHwnd
	{
		[CompilerGenerated]
		get
		{
			return zl1uPV5ea4;
		}
		[CompilerGenerated]
		private set
		{
			zl1uPV5ea4 = value;
		}
	}

	public string DocumentName
	{
		[CompilerGenerated]
		get
		{
			return JqBuASpfAI;
		}
		[CompilerGenerated]
		private set
		{
			JqBuASpfAI = value;
		}
	}

	public string DocumentFullName
	{
		[CompilerGenerated]
		get
		{
			return ri4uvtPvsG;
		}
		[CompilerGenerated]
		private set
		{
			ri4uvtPvsG = value;
		}
	}

	public string DocumentPath
	{
		[CompilerGenerated]
		get
		{
			return sCPuWnOnOg;
		}
		[CompilerGenerated]
		private set
		{
			sCPuWnOnOg = value;
		}
	}

	public bool HasWindow => !string.IsNullOrWhiteSpace(WindowKey);

	public bool HasDocument
	{
		get
		{
			if (string.IsNullOrWhiteSpace(DocumentName))
			{
				return !string.IsNullOrWhiteSpace(DocumentFullName);
			}
			return true;
		}
	}

	public string DisplayName
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(DocumentName))
			{
				return DocumentName;
			}
			if (!string.IsNullOrWhiteSpace(DocumentFullName))
			{
				return Path.GetFileName(DocumentFullName);
			}
			return WindowKey ?? string.Empty;
		}
	}

	public static AiTargetBinder wvGulrEfed(Window P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		AiTargetBinder rkZt4ZuLjXTP5cAL48p = new AiTargetBinder
		{
			hMwu01diWC = P_0,
			WindowHwnd = ORluoOGP40(P_0)
		};
		try
		{
			rkZt4ZuLjXTP5cAL48p.ML7uGGyNIv(P_0.Document);
		}
		catch
		{
		}
		rkZt4ZuLjXTP5cAL48p.WindowKey = sssuXl8Uty(rkZt4ZuLjXTP5cAL48p.WindowHwnd, rkZt4ZuLjXTP5cAL48p.DocumentFullName, rkZt4ZuLjXTP5cAL48p.DocumentName);
		return rkZt4ZuLjXTP5cAL48p;
	}

	public static AiTargetBinder hYCuNwB2K0(WordWindowInfo P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new AiTargetBinder
		{
			WindowKey = P_0.WindowKey,
			WindowHwnd = P_0.WindowHwnd,
			DocumentName = P_0.DocumentName,
			DocumentFullName = P_0.DocumentFullName,
			DocumentPath = P_0.DocumentPath
		};
	}

	public static string xZLum40ueh(Window P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		int num = ORluoOGP40(P_0);
		string text = string.Empty;
		string text2 = string.Empty;
		try
		{
			_G_c__DisplayClass30_0 CS_8_locals_4 = new _G_c__DisplayClass30_0();
			CS_8_locals_4.doc = P_0.Document;
			if (CS_8_locals_4.doc != null)
			{
				text = b0QuaLFO45(() => CS_8_locals_4.doc.FullName);
				text2 = b0QuaLFO45(() => CS_8_locals_4.doc.Name);
			}
		}
		catch
		{
		}
		return sssuXl8Uty(num, text, text2);
	}

	public static int ORluoOGP40(Window P_0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		try
		{
			return P_0.Hwnd;
		}
		catch
		{
			return 0;
		}
	}

	public void ML7uGGyNIv(Document P_0)
	{
		_G_c__DisplayClass32_0 CS_8_locals_6 = new _G_c__DisplayClass32_0();
		CS_8_locals_6.UoHqz6wiT2 = P_0;
		if (CS_8_locals_6.UoHqz6wiT2 != null)
		{
			DocumentName = b0QuaLFO45(() => CS_8_locals_6.UoHqz6wiT2.Name);
			DocumentFullName = b0QuaLFO45(() => CS_8_locals_6.UoHqz6wiT2.FullName);
			DocumentPath = b0QuaLFO45(() => CS_8_locals_6.UoHqz6wiT2.Path);
			bOYuksQ0qF = CS_8_locals_6.UoHqz6wiT2;
		}
	}

	public Window l1ouC0fgct(Application P_0)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(WindowKey))
		{
			return null;
		}
		try
		{
			foreach (Window window in P_0.Windows)
			{
				if (window == null)
				{
					continue;
				}
				if (DrMuhvXNA4(window, hMwu01diWC))
				{
					return window;
				}
				if (mIAuFp0oKe(xZLum40ueh(window), WindowKey))
				{
					return window;
				}
				try
				{
					Document document = window.Document;
					if (AXWu5GjCxV(document))
					{
						hMwu01diWC = window;
						return window;
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return null;
	}

	public Document iHlupRS7Nk(Application P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		Document document = liEu7Hj5L6(P_0);
		if (document != null)
		{
			return document;
		}
		Window window = l1ouC0fgct(P_0);
		if (window != null)
		{
			try
			{
				Document document2 = window.Document;
				ML7uGGyNIv(document2);
				return document2;
			}
			catch
			{
			}
		}
		return a0SucXphrE(P_0, DocumentFullName) ?? NQhuemeD11(P_0, DocumentName);
	}

	public bool c38uOkT1SI(Application P_0, out string P_1)
	{
		P_1 = null;
		if (P_0 == null)
		{
			P_1 = "Word 应用尚未初始化。";
			return false;
		}
		Window window = l1ouC0fgct(P_0);
		if (window != null)
		{
			try
			{
				window.Activate();
				ML7uGGyNIv(window.Document);
				return true;
			}
			catch (Exception ex)
			{
				P_1 = "无法激活目标 Word 窗口：" + ex.Message;
				return false;
			}
		}
		Document document = iHlupRS7Nk(P_0);
		if (document != null)
		{
			try
			{
				document.Activate();
				ML7uGGyNIv(document);
				return true;
			}
			catch (Exception ex2)
			{
				P_1 = "无法激活目标 Word 文档：" + ex2.Message;
				return false;
			}
		}
		P_1 = FUHunlB6Z7();
		return false;
	}

	public string FUHunlB6Z7()
	{
		string text = DisplayName;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "(未知目标)";
		}
		return "AI 助手绑定的目标 Word 文档已关闭或不可用，已停止读取/写入以避免操作当前活动文档。目标文档：" + text;
	}

	private Document liEu7Hj5L6(Application P_0)
	{
		if (P_0 == null || bOYuksQ0qF == null)
		{
			return null;
		}
		try
		{
			foreach (Document document in P_0.Documents)
			{
				if (DrMuhvXNA4(document, bOYuksQ0qF))
				{
					ML7uGGyNIv(document);
					return document;
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private bool AXWu5GjCxV(Document P_0)
	{
		_G_c__DisplayClass38_0 CS_8_locals_5 = new _G_c__DisplayClass38_0();
		CS_8_locals_5.IcoPBTyHo2 = P_0;
		if (CS_8_locals_5.IcoPBTyHo2 == null)
		{
			return false;
		}
		if (DrMuhvXNA4(CS_8_locals_5.IcoPBTyHo2, bOYuksQ0qF))
		{
			return true;
		}
		if (!k40uyLIsKC(b0QuaLFO45(() => CS_8_locals_5.IcoPBTyHo2.FullName), DocumentFullName))
		{
			return k40uyLIsKC(b0QuaLFO45(() => CS_8_locals_5.IcoPBTyHo2.Name), DocumentName);
		}
		return true;
	}

	private static Document a0SucXphrE(Application P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		string text = P_1.Trim();
		try
		{
			IEnumerator enumerator = P_0.Documents.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					_G_c__DisplayClass39_0 CS_8_locals_3 = new _G_c__DisplayClass39_0();
					CS_8_locals_3.JCBP6qPUa5 = (Document)enumerator.Current;
					if (k40uyLIsKC(b0QuaLFO45(() => CS_8_locals_3.JCBP6qPUa5.FullName), text))
					{
						return CS_8_locals_3.JCBP6qPUa5;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static Document NQhuemeD11(Application P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		string text = P_1.Trim();
		try
		{
			IEnumerator enumerator = P_0.Documents.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					_G_c__DisplayClass40_0 CS_8_locals_3 = new _G_c__DisplayClass40_0();
					CS_8_locals_3.khWPDeUAXa = (Document)enumerator.Current;
					if (k40uyLIsKC(b0QuaLFO45(() => CS_8_locals_3.khWPDeUAXa.Name), text))
					{
						return CS_8_locals_3.khWPDeUAXa;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static bool k40uyLIsKC(string P_0, string P_1)
	{
		return mIAuFp0oKe(P_0, P_1);
	}

	private static string sssuXl8Uty(int P_0, string P_1, string P_2)
	{
		string text = ((!string.IsNullOrWhiteSpace(P_1)) ? P_1 : P_2);
		if (P_0 != 0 && !string.IsNullOrWhiteSpace(text))
		{
			return "hwnd:" + P_0.ToString(CultureInfo.InvariantCulture) + "|doc:" + text;
		}
		if (P_0 != 0)
		{
			return "hwnd:" + P_0.ToString(CultureInfo.InvariantCulture);
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			return "doc:" + text;
		}
		return string.Empty;
	}

	private static bool mIAuFp0oKe(string P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_0) || string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		return string.Equals(P_0.Trim(), P_1.Trim(), StringComparison.OrdinalIgnoreCase);
	}

	private static bool DrMuhvXNA4(object P_0, object P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		if (P_0 == P_1)
		{
			return true;
		}
		if (!Marshal.IsComObject(P_0) || !Marshal.IsComObject(P_1))
		{
			return false;
		}
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.GetIUnknownForObject(P_0);
			intPtr2 = Marshal.GetIUnknownForObject(P_1);
			return intPtr == intPtr2;
		}
		catch
		{
			return false;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.Release(intPtr);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				Marshal.Release(intPtr2);
			}
		}
	}

	private static string b0QuaLFO45(Func<string> P_0)
	{
		try
		{
			string text = P_0();
			return (text == null) ? string.Empty : Convert.ToString(text, CultureInfo.InvariantCulture);
		}
		catch
		{
			return string.Empty;
		}
	}

	public AiTargetBinder()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
	}
}
