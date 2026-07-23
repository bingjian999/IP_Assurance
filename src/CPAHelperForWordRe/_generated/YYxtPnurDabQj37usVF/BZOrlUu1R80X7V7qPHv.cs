using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using cCjw5xuBKfy3KrCEZTg;
using hJKpQrVSwRwMyI2RyDQN;
using IE65okus88MbfGVSFao;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;

namespace YYxtPnurDabQj37usVF;

internal static class BZOrlUu1R80X7V7qPHv
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass11_0
	{
		public Document zZxqO2SkRt;

		public _G_c__DisplayClass11_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string aVlqC8Q22u()
		{
			return zZxqO2SkRt.FullName;
		}

		internal string maBqp2dq4M()
		{
			return zZxqO2SkRt.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass12_0
	{
		public Document t6Mq54Wf8e;

		public _G_c__DisplayClass12_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string VB4qnmDJtZ()
		{
			return t6Mq54Wf8e.Name;
		}

		internal string ccPq7HvAZ7()
		{
			return t6Mq54Wf8e.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass17_0
	{
		public Document doc;

		public _G_c__DisplayClass17_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string zaLqcCHkwj()
		{
			return doc.Name;
		}

		internal string DMXqebtrvA()
		{
			return doc.FullName;
		}

		internal string YwcqyD27yW()
		{
			return doc.Path;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass17_1
	{
		public Selection LooqFWR0QU;

		public _G_c__DisplayClass17_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string NJcqXkhUS6()
		{
			return LooqFWR0QU.Range.Text;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass7_0
	{
		public Document doc;

		public Selection wtsqAg3mgE;

		public _G_c__DisplayClass7_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string uxxqhc6nrb()
		{
			return doc.Name;
		}

		internal string maIqa2kdlg()
		{
			return doc.FullName;
		}

		internal string sWmqqcXEMN()
		{
			return doc.Path;
		}

		internal string so5qPPYSWp()
		{
			return wtsqAg3mgE.Range.Text;
		}
	}

	private static readonly AsyncLocal<VVx8AbuVh8WDeqd4oUQ> Cf3utiDaak;

	public static VVx8AbuVh8WDeqd4oUQ Current => Cf3utiDaak.Value;

	public static void Q9OuJfHKAR(VVx8AbuVh8WDeqd4oUQ P_0)
	{
		Cf3utiDaak.Value = P_0;
	}

	public static object hZfu3nWZl7(string P_0)
	{
		VVx8AbuVh8WDeqd4oUQ current = Current;
		if (current == null || string.IsNullOrWhiteSpace(P_0))
		{
			return null;
		}
		if (!j9tuMfqIC8(current.WordOpenXmlCacheDocumentKey, P_0))
		{
			return null;
		}
		return current.WordOpenXmlCache;
	}

	public static void hZYuUt7cr7(string P_0, object P_1)
	{
		VVx8AbuVh8WDeqd4oUQ current = Current;
		if (current != null && !string.IsNullOrWhiteSpace(P_0) && P_1 != null)
		{
			current.WordOpenXmlCacheDocumentKey = P_0;
			current.WordOpenXmlCache = P_1;
		}
	}

	public static void ySsuKsA6u8()
	{
		VVx8AbuVh8WDeqd4oUQ current = Current;
		if (current != null)
		{
			current.WordOpenXmlCacheDocumentKey = null;
			current.WordOpenXmlCache = null;
		}
	}

	public static VVx8AbuVh8WDeqd4oUQ HCFuEiq9tL(Application P_0)
	{
		VVx8AbuVh8WDeqd4oUQ vVx8AbuVh8WDeqd4oUQ = new VVx8AbuVh8WDeqd4oUQ();
		if (P_0 == null)
		{
			return vVx8AbuVh8WDeqd4oUQ;
		}
		try
		{
			_G_c__DisplayClass7_0 CS_8_locals_12 = new _G_c__DisplayClass7_0();
			CS_8_locals_12.doc = P_0.ActiveDocument;
			if (CS_8_locals_12.doc != null)
			{
				vVx8AbuVh8WDeqd4oUQ.DocumentName = iTNubDBlxS(() => CS_8_locals_12.doc.Name);
				vVx8AbuVh8WDeqd4oUQ.DocumentFullName = iTNubDBlxS(() => CS_8_locals_12.doc.FullName);
				vVx8AbuVh8WDeqd4oUQ.DocumentPath = iTNubDBlxS(() => CS_8_locals_12.doc.Path);
			}
			CS_8_locals_12.wtsqAg3mgE = P_0.Selection;
			if (CS_8_locals_12.wtsqAg3mgE != null && CS_8_locals_12.wtsqAg3mgE.Range != null)
			{
				vVx8AbuVh8WDeqd4oUQ.SelectionStart = CS_8_locals_12.wtsqAg3mgE.Range.Start;
				vVx8AbuVh8WDeqd4oUQ.SelectionEnd = CS_8_locals_12.wtsqAg3mgE.Range.End;
				vVx8AbuVh8WDeqd4oUQ.SelectionTextLength = iTNubDBlxS(() => CS_8_locals_12.wtsqAg3mgE.Range.Text).Length;
				vVx8AbuVh8WDeqd4oUQ.PageNumber = qv0uSgDm2s(CS_8_locals_12.wtsqAg3mgE.Range);
			}
		}
		catch
		{
		}
		return vVx8AbuVh8WDeqd4oUQ;
	}

	public static VVx8AbuVh8WDeqd4oUQ xeAu2ueFL1(Application P_0, RkZt4ZuLjXTP5cAL48p P_1)
	{
		if (P_1 == null)
		{
			return HCFuEiq9tL(P_0);
		}
		if (P_0 == null)
		{
			throw new InvalidOperationException("Word 应用尚未初始化。");
		}
		if (!P_1.c38uOkT1SI(P_0, out var message))
		{
			throw new InvalidOperationException(message);
		}
		Document document = P_1.iHlupRS7Nk(P_0);
		if (document == null)
		{
			throw new InvalidOperationException(P_1.FUHunlB6Z7());
		}
		VVx8AbuVh8WDeqd4oUQ vVx8AbuVh8WDeqd4oUQ = HcIuw328IO(P_0, document, P_1.WindowKey, P_1.WindowHwnd);
		if (!vVx8AbuVh8WDeqd4oUQ.HasDocument)
		{
			throw new InvalidOperationException(P_1.FUHunlB6Z7());
		}
		P_1.ML7uGGyNIv(document);
		return vVx8AbuVh8WDeqd4oUQ;
	}

	public static void dDwu4bAmJp(Application P_0)
	{
		VVx8AbuVh8WDeqd4oUQ current = Current;
		if (current == null || !current.HasPaneTarget || RkZt4ZuLjXTP5cAL48p.hYCuNwB2K0(current).c38uOkT1SI(P_0, out var message))
		{
			return;
		}
		throw new InvalidOperationException(message);
	}

	public static Document zrqujYgRXw(Application P_0, string P_1 = "")
	{
		if (P_0 == null)
		{
			throw new InvalidOperationException("Word 应用尚未初始化。");
		}
		string text = P_1;
		bool flag = false;
		VVx8AbuVh8WDeqd4oUQ current = Current;
		if (string.IsNullOrWhiteSpace(text) && current != null && current.HasPaneTarget)
		{
			Document document = RkZt4ZuLjXTP5cAL48p.hYCuNwB2K0(current).iHlupRS7Nk(P_0);
			if (document != null)
			{
				return document;
			}
			flag = true;
			text = ((!string.IsNullOrWhiteSpace(current.DocumentFullName)) ? current.DocumentFullName : current.DocumentName);
		}
		if (string.IsNullOrWhiteSpace(text) && current != null && current.HasDocument)
		{
			text = ((!string.IsNullOrWhiteSpace(current.DocumentFullName)) ? current.DocumentFullName : current.DocumentName);
			flag = true;
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			if (flag)
			{
				throw new InvalidOperationException("本轮 Agent 请求开始时的目标文档已关闭或不可用，已停止写入以避免改到当前活动文档。目标文档：" + ((current == null) ? string.Empty : current.DocumentName));
			}
			return P_0.ActiveDocument ?? throw new InvalidOperationException("当前没有打开的 Word 文档。");
		}
		Document document2 = SB8uZO400c(P_0, text);
		if (document2 != null)
		{
			return document2;
		}
		if (flag)
		{
			throw new InvalidOperationException("本轮 Agent 请求开始时的目标文档已关闭或不可用，已停止写入以避免改到当前活动文档。目标文档：" + text);
		}
		throw new InvalidOperationException("未找到 Word 文档“" + P_1 + "”。");
	}

	public static bool Se3uYFg09e(Document P_0)
	{
		_G_c__DisplayClass11_0 CS_8_locals_4 = new _G_c__DisplayClass11_0();
		CS_8_locals_4.zZxqO2SkRt = P_0;
		VVx8AbuVh8WDeqd4oUQ current = Current;
		if (CS_8_locals_4.zZxqO2SkRt == null || current == null || !current.HasDocument)
		{
			return false;
		}
		string text = iTNubDBlxS(() => CS_8_locals_4.zZxqO2SkRt.FullName);
		string text2 = iTNubDBlxS(() => CS_8_locals_4.zZxqO2SkRt.Name);
		if (!j9tuMfqIC8(text, current.DocumentFullName) && !j9tuMfqIC8(text2, current.DocumentName))
		{
			return j9tuMfqIC8(text2, Path.GetFileName(current.DocumentFullName ?? string.Empty));
		}
		return true;
	}

	private static Document SB8uZO400c(Application P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		string text = P_1.Trim();
		string fileName = Path.GetFileName(text);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
		bool flag = eJbuf0QLyt(text);
		IEnumerator enumerator = P_0.Documents.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				_G_c__DisplayClass12_0 CS_8_locals_5 = new _G_c__DisplayClass12_0();
				CS_8_locals_5.t6Mq54Wf8e = (Document)enumerator.Current;
				string text2 = iTNubDBlxS(() => CS_8_locals_5.t6Mq54Wf8e.Name);
				if (j9tuMfqIC8(iTNubDBlxS(() => CS_8_locals_5.t6Mq54Wf8e.FullName), text))
				{
					return CS_8_locals_5.t6Mq54Wf8e;
				}
				if (!flag && (j9tuMfqIC8(text2, text) || j9tuMfqIC8(text2, fileName) || j9tuMfqIC8(Path.GetFileNameWithoutExtension(text2), fileNameWithoutExtension)))
				{
					return CS_8_locals_5.t6Mq54Wf8e;
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
		return null;
	}

	private static bool eJbuf0QLyt(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		if (P_0.IndexOf('\\') < 0 && P_0.IndexOf('/') < 0)
		{
			return P_0.IndexOf(':') >= 0;
		}
		return true;
	}

	private static bool j9tuMfqIC8(string P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_0) || string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		return string.Equals(P_0.Trim(), P_1.Trim(), StringComparison.OrdinalIgnoreCase);
	}

	private static string iTNubDBlxS(Func<string> P_0)
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

	private static int qv0uSgDm2s(Range P_0)
	{
		try
		{
			return (P_0 != null) ? ((int)(dynamic)P_0.get_Information(WdInformation.wdActiveEndPageNumber)) : 0;
		}
		catch
		{
			return 0;
		}
	}

	private static VVx8AbuVh8WDeqd4oUQ HcIuw328IO(Application P_0, Document P_1, string P_2, int P_3)
	{
		_G_c__DisplayClass17_0 CS_8_locals_11 = new _G_c__DisplayClass17_0();
		CS_8_locals_11.doc = P_1;
		VVx8AbuVh8WDeqd4oUQ vVx8AbuVh8WDeqd4oUQ = new VVx8AbuVh8WDeqd4oUQ
		{
			WindowKey = (P_2 ?? string.Empty),
			WindowHwnd = P_3,
			DocumentName = iTNubDBlxS(() => CS_8_locals_11.doc.Name),
			DocumentFullName = iTNubDBlxS(() => CS_8_locals_11.doc.FullName),
			DocumentPath = iTNubDBlxS(() => CS_8_locals_11.doc.Path)
		};
		try
		{
			_G_c__DisplayClass17_1 CS_8_locals_12 = new _G_c__DisplayClass17_1();
			CS_8_locals_12.LooqFWR0QU = P_0.Selection;
			if (CS_8_locals_12.LooqFWR0QU != null && CS_8_locals_12.LooqFWR0QU.Range != null)
			{
				vVx8AbuVh8WDeqd4oUQ.SelectionStart = CS_8_locals_12.LooqFWR0QU.Range.Start;
				vVx8AbuVh8WDeqd4oUQ.SelectionEnd = CS_8_locals_12.LooqFWR0QU.Range.End;
				vVx8AbuVh8WDeqd4oUQ.SelectionTextLength = iTNubDBlxS(() => CS_8_locals_12.LooqFWR0QU.Range.Text).Length;
				vVx8AbuVh8WDeqd4oUQ.PageNumber = qv0uSgDm2s(CS_8_locals_12.LooqFWR0QU.Range);
			}
		}
		catch
		{
		}
		return vVx8AbuVh8WDeqd4oUQ;
	}

	static BZOrlUu1R80X7V7qPHv()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		Cf3utiDaak = new AsyncLocal<VVx8AbuVh8WDeqd4oUQ>();
	}
}
