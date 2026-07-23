using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using bWwioXMfw8EU8MWK7Iw;
using CPAHelperForWordRe.UI.Forms;
using dL7TFPsQbAGqPywtHUK;
using dpdiOwfLNrjZbpbZGek;
using ghWYvT5gdl6wakj5jtn;
using hJKpQrVSwRwMyI2RyDQN;
using Markdig;
using Markdig.Extensions.Tables;
using Markdig.Extensions.TaskLists;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;
using YNri0QclKMfRh2PQoZV;

namespace LgmURjbT0s9Qufho1dJ;

internal static class s2nMCybDnhhNsDsld0f
{
	private sealed class aAlPvcVUL6QeYdQQTx4o
	{
		private readonly Application S4MVKgeaWSv;

		private readonly Document tCAVK8nqeU8;

		private readonly List<raLl8RVKsxnTrBWY49kg> xI3VKICDWZW;

		private readonly List<pfvElaVK28PPZKRbg4It> diFVKiV96mN;

		private Range ALVVKHQJk1O;

		private int PlDVKQGgg5a;

		private int LYWVK1W4udM;

		private int GMjVKron835;

		[CompilerGenerated]
		private int JR4VKJWekPR;

		[CompilerGenerated]
		private int P9JVK3Pct0J;

		[CompilerGenerated]
		private int B8mVKU7atmJ;

		[CompilerGenerated]
		private int Q8PVKKtNGlW;

		[CompilerGenerated]
		private int sCLVKEodJ8w;

		public int HeadingCount
		{
			[CompilerGenerated]
			get
			{
				return JR4VKJWekPR;
			}
			[CompilerGenerated]
			private set
			{
				JR4VKJWekPR = value;
			}
		}

		public int ParagraphCount
		{
			[CompilerGenerated]
			get
			{
				return P9JVK3Pct0J;
			}
			[CompilerGenerated]
			private set
			{
				P9JVK3Pct0J = value;
			}
		}

		public int TableCount
		{
			[CompilerGenerated]
			get
			{
				return B8mVKU7atmJ;
			}
			[CompilerGenerated]
			private set
			{
				B8mVKU7atmJ = value;
			}
		}

		public int InlineStyleFailureCount
		{
			[CompilerGenerated]
			get
			{
				return Q8PVKKtNGlW;
			}
			[CompilerGenerated]
			private set
			{
				Q8PVKKtNGlW = value;
			}
		}

		public int HeadingNumberingFailureCount
		{
			[CompilerGenerated]
			get
			{
				return sCLVKEodJ8w;
			}
			[CompilerGenerated]
			private set
			{
				sCLVKEodJ8w = value;
			}
		}

		public aAlPvcVUL6QeYdQQTx4o(Application P_0, Document P_1)
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			xI3VKICDWZW = new List<raLl8RVKsxnTrBWY49kg>();
			diFVKiV96mN = new List<pfvElaVK28PPZKRbg4It>();
			S4MVKgeaWSv = P_0;
			tCAVK8nqeU8 = P_1;
		}

		public void zHcVUs5hLZv(MarkdownDocument P_0)
		{
			oTEVUG21RJh();
			foreach (Block item in P_0)
			{
				OwWVUCS7bIW(item);
			}
			LYWVK1W4udM = ALVVKHQJk1O.Start;
		}

		public Range byJVUlMc00b()
		{
			if (LYWVK1W4udM <= PlDVKQGgg5a)
			{
				return null;
			}
			Document document = tCAVK8nqeU8;
			object Start = PlDVKQGgg5a;
			object End = LYWVK1W4udM;
			return document.Range(ref Start, ref End);
		}

		public void gvvVUNAOj7c()
		{
			InlineStyleFailureCount = 0;
			int num = 0;
			string text = null;
			foreach (raLl8RVKsxnTrBWY49kg item in xI3VKICDWZW)
			{
				if6J2oVKC21QN5q6nYBW if6J2oVKC21QN5q6nYBW2 = item.iyaVKlfHfTe(tCAVK8nqeU8);
				if (!if6J2oVKC21QN5q6nYBW2.Success)
				{
					InlineStyleFailureCount++;
					num += if6J2oVKC21QN5q6nYBW2.FailureCount;
					if (string.IsNullOrWhiteSpace(text))
					{
						text = if6J2oVKC21QN5q6nYBW2.FirstFailure;
					}
				}
			}
			if (InlineStyleFailureCount > 0)
			{
				yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl(string.Format("[MarkdownImport] Inline styles partially applied; TotalSpans={0}; FailedSpans={1}; FailedProperties={2}; FirstFailure={3}", xI3VKICDWZW.Count, InlineStyleFailureCount, num, text ?? string.Empty));
			}
		}

		public void B27VUmfiUVg()
		{
			HeadingNumberingFailureCount = 0;
			if (diFVKiV96mN.Count == 0)
			{
				return;
			}
			ListTemplate listTemplate = X4OVK6e1jZf();
			if (listTemplate == null)
			{
				HeadingNumberingFailureCount = diFVKiV96mN.Count;
				return;
			}
			bool flag = true;
			int num = 0;
			string text = null;
			foreach (pfvElaVK28PPZKRbg4It item in diFVKiV96mN)
			{
				try
				{
					Document document = tCAVK8nqeU8;
					object Start = item.Start;
					object End = item.End;
					Range range = document.Range(ref Start, ref End);
					ListFormat listFormat = range.ListFormat;
					End = !flag;
					Start = WdListApplyTo.wdListApplyToWholeList;
					object DefaultListBehavior = WdDefaultListBehavior.wdWord10ListBehavior;
					object ApplyLevel = item.Level;
					listFormat.ApplyListTemplateWithLevel(listTemplate, ref End, ref Start, ref DefaultListBehavior, ref ApplyLevel);
					range.ListFormat.ListLevelNumber = item.Level;
					flag = false;
				}
				catch (Exception ex)
				{
					num++;
					if (string.IsNullOrWhiteSpace(text))
					{
						text = ex.Message;
					}
				}
			}
			if (num > 0)
			{
				HeadingNumberingFailureCount = num;
				yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl(string.Format("[MarkdownImport] Heading numbering partially applied; Total={0}; Failed={1}; FirstFailure={2}", diFVKiV96mN.Count, num, text ?? string.Empty));
			}
		}

		public void IXpVUo7IqG4()
		{
			try
			{
				Document document = tCAVK8nqeU8;
				object Start = LYWVK1W4udM;
				object End = LYWVK1W4udM;
				document.Range(ref Start, ref End).Select();
			}
			catch
			{
			}
		}

		private void oTEVUG21RJh()
		{
			Selection selection = S4MVKgeaWSv.Selection;
			Range range = ((selection != null) ? selection.Range.Duplicate : tCAVK8nqeU8.Content.Duplicate);
			int num = ((range != null) ? Math.Max(range.Start, range.End) : Math.Max(0, tCAVK8nqeU8.Content.End - 1));
			Document document = tCAVK8nqeU8;
			object Start = num;
			object End = num;
			ALVVKHQJk1O = document.Range(ref Start, ref End);
			ALVVKHQJk1O.Select();
			PlDVKQGgg5a = num;
			LYWVK1W4udM = num;
		}

		private void OwWVUCS7bIW(Block P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			if (P_0 is HeadingBlock headingBlock)
			{
				dNfVUpc2lFo(headingBlock);
			}
			else if (P_0 is ParagraphBlock paragraphBlock)
			{
				qhvVUO6n4l9(paragraphBlock.Inline, WdOutlineLevel.wdOutlineLevelBodyText, string.Empty);
			}
			else if (P_0 is Markdig.Extensions.Tables.Table table)
			{
				hBBVUhP5ZGf(table);
			}
			else if (P_0 is ListBlock listBlock)
			{
				NZuVUe1YgXu(listBlock, 0);
			}
			else if (P_0 is QuoteBlock quoteBlock)
			{
				Fo0VUcC8g24(quoteBlock);
			}
			else if (P_0 is CodeBlock codeBlock)
			{
				tSuVU7STA1F(codeBlock);
			}
			else if (P_0 is ThematicBreakBlock)
			{
				EkrVU5PIxQF();
			}
			else if (P_0 is HtmlBlock htmlBlock)
			{
				j8RVUnAUdUO(htmlBlock.Lines.ToString());
			}
			else
			{
				if (!(P_0 is ContainerBlock containerBlock))
				{
					return;
				}
				foreach (Block item in containerBlock)
				{
					OwWVUCS7bIW(item);
				}
			}
		}

		private void dNfVUpc2lFo(HeadingBlock P_0)
		{
			int num = Math.Max(1, Math.Min(5, P_0.Level));
			Range range = qhvVUO6n4l9(P_0.Inline, (WdOutlineLevel)num, string.Empty);
			if (range != null)
			{
				diFVKiV96mN.Add(new pfvElaVK28PPZKRbg4It(range.Start, range.End, num));
			}
			HeadingCount++;
		}

		private Range qhvVUO6n4l9(ContainerInline P_0, WdOutlineLevel P_1, string P_2)
		{
			int start = ALVVKHQJk1O.Start;
			string text = mIDVUWOawP9() + (P_2 ?? string.Empty);
			if (text.Length > 0)
			{
				rOsVUAVse01(text, LOUXUXVKZBmgcWu9S7lG.Normal);
			}
			eqrVUqU4btV(P_0, LOUXUXVKZBmgcWu9S7lG.Normal);
			bB5VUva3Dt6("\\r");
			Document document = tCAVK8nqeU8;
			object Start = start;
			object End = ALVVKHQJk1O.Start;
			Range range = document.Range(ref Start, ref End);
			range.ParagraphFormat.OutlineLevel = P_1;
			ParagraphCount++;
			return range;
		}

		private void j8RVUnAUdUO(string P_0)
		{
			string text = dCNVKVmSQse(P_0);
			if (!string.IsNullOrEmpty(text))
			{
				string[] array = text.Split(new char[1] { '\n' }, StringSplitOptions.None);
				foreach (string text2 in array)
				{
					qhvVUO6n4l9(VUPVU0SRBt5(text2), WdOutlineLevel.wdOutlineLevelBodyText, string.Empty);
				}
			}
		}

		private void tSuVU7STA1F(CodeBlock P_0)
		{
			string text = dCNVKVmSQse(P_0.Lines.ToString());
			if (text.Length == 0)
			{
				text = string.Empty;
			}
			string[] array = text.Split(new char[1] { '\n' }, StringSplitOptions.None);
			if (array.Length == 0)
			{
				array = new string[1] { string.Empty };
			}
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				int start = ALVVKHQJk1O.Start;
				rOsVUAVse01(mIDVUWOawP9(), LOUXUXVKZBmgcWu9S7lG.Normal);
				rOsVUAVse01(text2, LOUXUXVKZBmgcWu9S7lG.DruVKM09SLJ);
				bB5VUva3Dt6("\\r");
				Document document = tCAVK8nqeU8;
				object Start = start;
				object End = ALVVKHQJk1O.Start;
				document.Range(ref Start, ref End).ParagraphFormat.OutlineLevel = WdOutlineLevel.wdOutlineLevelBodyText;
				ParagraphCount++;
			}
		}

		private void EkrVU5PIxQF()
		{
			qhvVUO6n4l9(VUPVU0SRBt5("____________________________"), WdOutlineLevel.wdOutlineLevelBodyText, string.Empty);
		}

		private void Fo0VUcC8g24(QuoteBlock P_0)
		{
			GMjVKron835++;
			try
			{
				foreach (Block item in P_0)
				{
					OwWVUCS7bIW(item);
				}
			}
			finally
			{
				GMjVKron835 = Math.Max(0, GMjVKron835 - 1);
			}
		}

		private void NZuVUe1YgXu(ListBlock P_0, int P_1)
		{
			int num = LjiVUXT7txy(P_0);
			foreach (Block item in P_0)
			{
				if (item is ListItemBlock listItemBlock)
				{
					DAyVUyQ5ekU(P_0, listItemBlock, P_1, num);
					if (P_0.IsOrdered)
					{
						num++;
					}
				}
			}
		}

		private void DAyVUyQ5ekU(ListBlock P_0, ListItemBlock P_1, int P_2, int P_3)
		{
			bool flag = true;
			bool flag2 = false;
			foreach (Block item in P_1)
			{
				if (item is ParagraphBlock paragraphBlock)
				{
					string text = (flag ? O0NVUFp40Fq(P_0, P_2, P_3) : new string(' ', Math.Max(0, P_2 * 2 + 2)));
					qhvVUO6n4l9(paragraphBlock.Inline, WdOutlineLevel.wdOutlineLevelBodyText, text);
					flag = false;
					flag2 = true;
				}
				else if (item is ListBlock listBlock)
				{
					NZuVUe1YgXu(listBlock, P_2 + 1);
					flag2 = true;
				}
				else
				{
					OwWVUCS7bIW(item);
					flag2 = true;
				}
			}
			if (!flag2)
			{
				qhvVUO6n4l9(VUPVU0SRBt5(string.Empty), WdOutlineLevel.wdOutlineLevelBodyText, O0NVUFp40Fq(P_0, P_2, P_3));
			}
		}

		private static int LjiVUXT7txy(ListBlock P_0)
		{
			try
			{
				if (int.TryParse(P_0.OrderedStart, out var result) && result > 0)
				{
					return result;
				}
			}
			catch
			{
			}
			return 1;
		}

		private static string O0NVUFp40Fq(ListBlock P_0, int P_1, int P_2)
		{
			string text = new string(' ', Math.Max(0, P_1 * 2));
			if (P_0.IsOrdered)
			{
				return text + P_2 + ". ";
			}
			return text + "- ";
		}

		private void hBBVUhP5ZGf(Markdig.Extensions.Tables.Table P_0)
		{
			List<List<string>> list = MUXVUaXf2Vq(P_0);
			if (list.Count == 0)
			{
				return;
			}
			int count = list.Count;
			int num = Math.Max(1, list.Max((List<string> row) => row.Count));
			Tables tables = tCAVK8nqeU8.Tables;
			Range aLVVKHQJk1O = ALVVKHQJk1O;
			object DefaultTableBehavior = Type.Missing;
			object AutoFitBehavior = Type.Missing;
			Microsoft.Office.Interop.Word.Table table = tables.Add(aLVVKHQJk1O, count, num, ref DefaultTableBehavior, ref AutoFitBehavior);
			for (int num2 = 0; num2 < count; num2++)
			{
				List<string> list2 = list[num2];
				for (int num3 = 0; num3 < num; num3++)
				{
					string text = ((num3 < list2.Count) ? list2[num3] : string.Empty);
					table.Cell(num2 + 1, num3 + 1).Range.Text = text ?? string.Empty;
				}
			}
			Range duplicate = table.Range.Duplicate;
			AutoFitBehavior = WdCollapseDirection.wdCollapseEnd;
			duplicate.Collapse(ref AutoFitBehavior);
			duplicate.InsertParagraphAfter();
			AutoFitBehavior = WdCollapseDirection.wdCollapseEnd;
			duplicate.Collapse(ref AutoFitBehavior);
			ALVVKHQJk1O = duplicate.Duplicate;
			LYWVK1W4udM = ALVVKHQJk1O.Start;
			TableCount++;
		}

		private List<List<string>> MUXVUaXf2Vq(Markdig.Extensions.Tables.Table P_0)
		{
			List<List<string>> list = new List<List<string>>();
			foreach (Block item in P_0)
			{
				if (!(item is TableRow tableRow))
				{
					continue;
				}
				List<string> list2 = new List<string>();
				foreach (Block item2 in tableRow)
				{
					if (item2 is TableCell tableCell)
					{
						list2.Add(nQdVUkujHfi(tableCell));
					}
				}
				list.Add(list2);
			}
			return list;
		}

		private void eqrVUqU4btV(ContainerInline P_0, LOUXUXVKZBmgcWu9S7lG P_1)
		{
			if (P_0 != null)
			{
				for (Inline inline = P_0.FirstChild; inline != null; inline = inline.NextSibling)
				{
					EF3VUPsYT4O(inline, P_1);
				}
			}
		}

		private void EF3VUPsYT4O(Inline P_0, LOUXUXVKZBmgcWu9S7lG P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			if (P_0 is LiteralInline literalInline)
			{
				rOsVUAVse01(literalInline.Content.ToString(), P_1);
			}
			else if (P_0 is CodeInline codeInline)
			{
				LOUXUXVKZBmgcWu9S7lG lOUXUXVKZBmgcWu9S7lG = P_1.LPkVKfa2RCQ();
				lOUXUXVKZBmgcWu9S7lG.Code = true;
				rOsVUAVse01(codeInline.Content ?? string.Empty, lOUXUXVKZBmgcWu9S7lG);
			}
			else if (P_0 is LineBreakInline)
			{
				rOsVUAVse01("", P_1);
			}
			else if (P_0 is TaskList taskList)
			{
				rOsVUAVse01(taskList.Checked ? "[ ] " : "[x] ", P_1);
			}
			else if (P_0 is EmphasisInline emphasisInline)
			{
				LOUXUXVKZBmgcWu9S7lG lOUXUXVKZBmgcWu9S7lG2 = P_1.LPkVKfa2RCQ();
				if (emphasisInline.DelimiterChar == '~')
				{
					lOUXUXVKZBmgcWu9S7lG2.Strike = true;
				}
				else if (emphasisInline.DelimiterCount >= 2)
				{
					lOUXUXVKZBmgcWu9S7lG2.Bold = true;
				}
				else
				{
					lOUXUXVKZBmgcWu9S7lG2.Italic = true;
				}
				eqrVUqU4btV(emphasisInline, lOUXUXVKZBmgcWu9S7lG2);
			}
			else if (P_0 is LinkInline linkInline)
			{
				LOUXUXVKZBmgcWu9S7lG lOUXUXVKZBmgcWu9S7lG3 = P_1.LPkVKfa2RCQ();
				if (linkInline.IsImage)
				{
					string text = fyrVUdlcVT7(linkInline);
					rOsVUAVse01(string.IsNullOrWhiteSpace(text) ? "[image: " : ("]" + text + "[image]"), P_1);
				}
				else
				{
					lOUXUXVKZBmgcWu9S7lG3.Link = true;
					eqrVUqU4btV(linkInline, lOUXUXVKZBmgcWu9S7lG3);
				}
			}
			else if (P_0 is AutolinkInline autolinkInline)
			{
				LOUXUXVKZBmgcWu9S7lG lOUXUXVKZBmgcWu9S7lG4 = P_1.LPkVKfa2RCQ();
				lOUXUXVKZBmgcWu9S7lG4.Link = true;
				rOsVUAVse01(autolinkInline.Url ?? string.Empty, lOUXUXVKZBmgcWu9S7lG4);
			}
			else if (P_0 is HtmlEntityInline htmlEntityInline)
			{
				rOsVUAVse01(WebUtility.HtmlDecode(htmlEntityInline.Original.ToString()), P_1);
			}
			else if (P_0 is HtmlInline htmlInline)
			{
				rOsVUAVse01(HoPVK9KVASD(htmlInline.Tag), P_1);
			}
			else if (P_0 is ContainerInline containerInline)
			{
				eqrVUqU4btV(containerInline, P_1);
			}
			else
			{
				rOsVUAVse01(P_0.ToString(), P_1);
			}
		}

		private void rOsVUAVse01(string P_0, LOUXUXVKZBmgcWu9S7lG P_1)
		{
			string text = TWUVKR0rlfS(P_0);
			if (text.Length != 0)
			{
				int start = ALVVKHQJk1O.Start;
				bB5VUva3Dt6(text);
				int start2 = ALVVKHQJk1O.Start;
				if (P_1.HasFormatting)
				{
					raLl8RVKsxnTrBWY49kg item = new raLl8RVKsxnTrBWY49kg(start, start2, P_1.LPkVKfa2RCQ());
					xI3VKICDWZW.Add(item);
				}
			}
		}

		private void bB5VUva3Dt6(string P_0)
		{
			if (!string.IsNullOrEmpty(P_0))
			{
				int start = ALVVKHQJk1O.Start;
				ALVVKHQJk1O.Text = P_0;
				int num;
				try
				{
					num = ALVVKHQJk1O.End;
				}
				catch
				{
					num = start + P_0.Length;
				}
				if (num <= start)
				{
					num = start + P_0.Length;
				}
				Document document = tCAVK8nqeU8;
				object Start = num;
				object End = num;
				ALVVKHQJk1O = document.Range(ref Start, ref End);
				LYWVK1W4udM = num;
			}
		}

		private string mIDVUWOawP9()
		{
			if (GMjVKron835 <= 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < GMjVKron835; i++)
			{
				stringBuilder.Append("> ");
			}
			return stringBuilder.ToString();
		}

		private static ContainerInline VUPVU0SRBt5(string P_0)
		{
			ContainerInline containerInline = new ContainerInline();
			containerInline.AppendChild(new LiteralInline(P_0 ?? string.Empty));
			return containerInline;
		}

		private static string nQdVUkujHfi(ContainerBlock P_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Block item in P_0)
			{
				string text = TKlVUxutUor(item);
				if (text.Length != 0)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append('\n');
					}
					stringBuilder.Append(text);
				}
			}
			return YnNVKB3kKa1(stringBuilder.ToString());
		}

		private static string TKlVUxutUor(Block P_0)
		{
			if (P_0 == null)
			{
				return string.Empty;
			}
			if (P_0 is ParagraphBlock paragraphBlock)
			{
				return fyrVUdlcVT7(paragraphBlock.Inline);
			}
			if (P_0 is HeadingBlock headingBlock)
			{
				return fyrVUdlcVT7(headingBlock.Inline);
			}
			if (P_0 is CodeBlock codeBlock)
			{
				return dCNVKVmSQse(codeBlock.Lines.ToString());
			}
			if (P_0 is HtmlBlock htmlBlock)
			{
				return HoPVK9KVASD(htmlBlock.Lines.ToString());
			}
			if (P_0 is ContainerBlock containerBlock)
			{
				return nQdVUkujHfi(containerBlock);
			}
			return string.Empty;
		}

		private static string fyrVUdlcVT7(ContainerInline P_0)
		{
			if (P_0 == null)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			uRlVUzjkBrL(P_0, stringBuilder);
			return YnNVKB3kKa1(stringBuilder.ToString());
		}

		private static void uRlVUzjkBrL(Inline P_0, StringBuilder P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			if (P_0 is LiteralInline literalInline)
			{
				P_1.Append(literalInline.Content.ToString());
			}
			else if (P_0 is CodeInline codeInline)
			{
				P_1.Append(codeInline.Content ?? string.Empty);
			}
			else if (P_0 is LineBreakInline)
			{
				P_1.Append('\n');
			}
			else if (P_0 is TaskList taskList)
			{
				P_1.Append(taskList.Checked ? "[ ] " : "[x] ");
			}
			else if (P_0 is HtmlEntityInline htmlEntityInline)
			{
				P_1.Append(WebUtility.HtmlDecode(htmlEntityInline.Original.ToString()));
			}
			else if (P_0 is HtmlInline htmlInline)
			{
				P_1.Append(HoPVK9KVASD(htmlInline.Tag));
			}
			else if (P_0 is ContainerInline containerInline)
			{
				for (Inline inline = containerInline.FirstChild; inline != null; inline = inline.NextSibling)
				{
					uRlVUzjkBrL(inline, P_1);
				}
			}
		}

		private static string TWUVKR0rlfS(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return string.Empty;
			}
			return P_0.Replace("\r\n", "").Replace('\r', '\v').Replace('\n', '\v');
		}

		private static string dCNVKVmSQse(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return string.Empty;
			}
			return P_0.Replace("\r\n", "\n").Replace('\r', '\n').TrimEnd('\n');
		}

		private static string YnNVKB3kKa1(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return string.Empty;
			}
			return Regex.Replace(dCNVKVmSQse(P_0), "[ \\\\t]*\\\\n[ \\\\t]*", "\\r").Trim();
		}

		private static string HoPVK9KVASD(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return string.Empty;
			}
			return WebUtility.HtmlDecode(Regex.Replace(P_0, "<.*?>", string.Empty));
		}

		private ListTemplate X4OVK6e1jZf()
		{
			ListTemplate listTemplate = null;
			try
			{
				ListTemplates listTemplates = tCAVK8nqeU8.ListTemplates;
				object OutlineNumbered = true;
				object Name = "IPA_MD_" + Guid.NewGuid().ToString("N");
				listTemplate = listTemplates.Add(ref OutlineNumbered, ref Name);
			}
			catch (Exception)
			{
			}
			if (listTemplate == null)
			{
				try
				{
					ListTemplates listTemplates2 = S4MVKgeaWSv.ListGalleries[WdListGalleryType.wdOutlineNumberGallery].ListTemplates;
					object Name = 1;
					listTemplate = listTemplates2[ref Name];
				}
				catch (Exception ex2)
				{
					yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[MarkdownImport] Use outline number gallery failed: " + ex2.Message);
					return null;
				}
			}
			l3WVKuJFtmO(listTemplate);
			return listTemplate;
		}

		private void l3WVKuJFtmO(ListTemplate P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = 0;
			string text = null;
			for (int i = 1; i <= 5; i++)
			{
				try
				{
					ListLevel listLevel = P_0.ListLevels[i];
					listLevel.NumberFormat = hdmVKDNC4jD(i);
					listLevel.NumberStyle = jm7VKTxvHAB(i);
					listLevel.StartAt = 1;
					listLevel.ResetOnHigher = ((i != 1) ? (i - 1) : 0);
					listLevel.TrailingCharacter = WdTrailingCharacter.wdTrailingNone;
					listLevel.Alignment = WdListLevelAlignment.wdListLevelAlignLeft;
					float numberPosition = S4MVKgeaWSv.CentimetersToPoints((float)((double)(i - 1) * 0.65));
					float num2 = S4MVKgeaWSv.CentimetersToPoints((float)((double)i * 0.65));
					listLevel.NumberPosition = numberPosition;
					listLevel.TextPosition = num2;
					listLevel.TabPosition = num2;
				}
				catch (Exception ex)
				{
					num++;
					if (string.IsNullOrWhiteSpace(text))
					{
						text = ex.Message;
					}
				}
			}
			if (num > 0)
			{
				yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl(string.Format("[MarkdownImport] Heading number template partially configured; FailedLevels={0}; FirstFailure={1}", num, text ?? string.Empty));
			}
		}

		private static string hdmVKDNC4jD(int P_0)
		{
			return P_0 switch
			{
				1 => "%1、", 
				2 => "（%2）", 
				3 => "%3.", 
				4 => "(%4)", 
				5 => "%5", 
				_ => "%" + P_0, 
			};
		}

		private static WdListNumberStyle jm7VKTxvHAB(int P_0)
		{
			switch (P_0)
			{
			case 1:
			case 2:
				return WdListNumberStyle.wdListNumberStyleSimpChinNum1;
			case 5:
				return WdListNumberStyle.wdListNumberStyleNumberInCircle;
			default:
				return WdListNumberStyle.wdListNumberStyleArabic;
			}
		}
	}

	private sealed class pfvElaVK28PPZKRbg4It
	{
		[CompilerGenerated]
		private readonly int oOuVK4oZt0k;

		[CompilerGenerated]
		private readonly int N9MVKj0QxtD;

		[CompilerGenerated]
		private readonly int zpeVKYiyYMQ;

		public int Start
		{
			[CompilerGenerated]
			get
			{
				return oOuVK4oZt0k;
			}
		}

		public int End
		{
			[CompilerGenerated]
			get
			{
				return N9MVKj0QxtD;
			}
		}

		public int Level
		{
			[CompilerGenerated]
			get
			{
				return zpeVKYiyYMQ;
			}
		}

		public pfvElaVK28PPZKRbg4It(int P_0, int P_1, int P_2)
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			oOuVK4oZt0k = P_0;
			N9MVKj0QxtD = P_1;
			zpeVKYiyYMQ = P_2;
		}
	}

	private sealed class LOUXUXVKZBmgcWu9S7lG
	{
		public static readonly LOUXUXVKZBmgcWu9S7lG Normal;

		public static readonly LOUXUXVKZBmgcWu9S7lG DruVKM09SLJ;

		[CompilerGenerated]
		private bool NxmVKbaCLJ1;

		[CompilerGenerated]
		private bool uD6VKSin1kj;

		[CompilerGenerated]
		private bool XEhVKwqXa0I;

		[CompilerGenerated]
		private bool CDfVKteaRvr;

		[CompilerGenerated]
		private bool uCQVKLdXApF;

		public bool Bold
		{
			[CompilerGenerated]
			get
			{
				return NxmVKbaCLJ1;
			}
			[CompilerGenerated]
			set
			{
				NxmVKbaCLJ1 = value;
			}
		}

		public bool Italic
		{
			[CompilerGenerated]
			get
			{
				return uD6VKSin1kj;
			}
			[CompilerGenerated]
			set
			{
				uD6VKSin1kj = value;
			}
		}

		public bool Strike
		{
			[CompilerGenerated]
			get
			{
				return XEhVKwqXa0I;
			}
			[CompilerGenerated]
			set
			{
				XEhVKwqXa0I = value;
			}
		}

		public bool Code
		{
			[CompilerGenerated]
			get
			{
				return CDfVKteaRvr;
			}
			[CompilerGenerated]
			set
			{
				CDfVKteaRvr = value;
			}
		}

		public bool Link
		{
			[CompilerGenerated]
			get
			{
				return uCQVKLdXApF;
			}
			[CompilerGenerated]
			set
			{
				uCQVKLdXApF = value;
			}
		}

		public bool HasFormatting
		{
			get
			{
				if (!Bold && !Italic && !Strike && !Code)
				{
					return Link;
				}
				return true;
			}
		}

		public LOUXUXVKZBmgcWu9S7lG LPkVKfa2RCQ()
		{
			return new LOUXUXVKZBmgcWu9S7lG
			{
				Bold = Bold,
				Italic = Italic,
				Strike = Strike,
				Code = Code,
				Link = Link
			};
		}

		public LOUXUXVKZBmgcWu9S7lG()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		static LOUXUXVKZBmgcWu9S7lG()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			Normal = new LOUXUXVKZBmgcWu9S7lG();
			DruVKM09SLJ = new LOUXUXVKZBmgcWu9S7lG
			{
				Code = true
			};
		}
	}

	private sealed class raLl8RVKsxnTrBWY49kg
	{
		[CompilerGenerated]
		private sealed class _G_c__DisplayClass4_0
		{
			public Range u7OVSYHS4RI;

			public _G_c__DisplayClass4_0()
			{
				hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			}

			internal void sdBVS3Bc8CU()
			{
				u7OVSYHS4RI.Font.Bold = -1;
			}

			internal void i7QVSUrrYA5()
			{
				u7OVSYHS4RI.Font.Italic = -1;
			}

			internal void znjVSKAiWq1()
			{
				u7OVSYHS4RI.Font.StrikeThrough = -1;
			}

			internal void PI4VSE7Tjqx()
			{
				u7OVSYHS4RI.Font.NameAscii = "Consolas";
			}

			internal void p1ZVS24K1GG()
			{
				u7OVSYHS4RI.Font.NameOther = "Consolas";
			}

			internal void rIQVS415YRc()
			{
				u7OVSYHS4RI.Font.Underline = WdUnderline.wdUnderlineSingle;
			}

			internal void T2HVSjXmR7l()
			{
				u7OVSYHS4RI.Font.Color = WdColor.wdColorBlue;
			}
		}

		private readonly int GMWVKmnOZDC;

		private readonly int MxmVKon2JAK;

		private readonly LOUXUXVKZBmgcWu9S7lG p7HVKGYJfG3;

		public raLl8RVKsxnTrBWY49kg(int P_0, int P_1, LOUXUXVKZBmgcWu9S7lG P_2)
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			GMWVKmnOZDC = P_0;
			MxmVKon2JAK = P_1;
			p7HVKGYJfG3 = P_2;
		}

		public if6J2oVKC21QN5q6nYBW iyaVKlfHfTe(Document P_0)
		{
			_G_c__DisplayClass4_0 CS_8_locals_8 = new _G_c__DisplayClass4_0();
			if6J2oVKC21QN5q6nYBW if6J2oVKC21QN5q6nYBW2 = new if6J2oVKC21QN5q6nYBW(GMWVKmnOZDC, MxmVKon2JAK);
			if (P_0 == null)
			{
				if6J2oVKC21QN5q6nYBW2.CDvVKptgDXx("Document", 0, new InvalidOperationException("Word document is unavailable."));
				return if6J2oVKC21QN5q6nYBW2;
			}
			int start;
			int end;
			try
			{
				Range content = P_0.Content;
				start = content.Start;
				end = content.End;
			}
			catch (Exception ex)
			{
				if6J2oVKC21QN5q6nYBW2.CDvVKptgDXx("DocumentRange", 0, ex);
				return if6J2oVKC21QN5q6nYBW2;
			}
			if (MxmVKon2JAK <= GMWVKmnOZDC || GMWVKmnOZDC < start || MxmVKon2JAK > end)
			{
				if6J2oVKC21QN5q6nYBW2.CDvVKptgDXx("Range", end, new ArgumentOutOfRangeException("range", string.Format("Inline range {0}-{1} is outside document range {2}-{3}.", GMWVKmnOZDC, MxmVKon2JAK, start, end)));
				return if6J2oVKC21QN5q6nYBW2;
			}
			try
			{
				object Start = GMWVKmnOZDC;
				object End = MxmVKon2JAK;
				CS_8_locals_8.u7OVSYHS4RI = P_0.Range(ref Start, ref End);
			}
			catch (Exception ex2)
			{
				if6J2oVKC21QN5q6nYBW2.CDvVKptgDXx("Range", end, ex2);
				return if6J2oVKC21QN5q6nYBW2;
			}
			if (p7HVKGYJfG3.Bold)
			{
				x0YVKN486Vs(if6J2oVKC21QN5q6nYBW2, "Bold", end, delegate
				{
					CS_8_locals_8.u7OVSYHS4RI.Font.Bold = -1;
				});
			}
			if (p7HVKGYJfG3.Italic)
			{
				x0YVKN486Vs(if6J2oVKC21QN5q6nYBW2, "Italic", end, delegate
				{
					CS_8_locals_8.u7OVSYHS4RI.Font.Italic = -1;
				});
			}
			if (p7HVKGYJfG3.Strike)
			{
				x0YVKN486Vs(if6J2oVKC21QN5q6nYBW2, "StrikeThrough", end, delegate
				{
					CS_8_locals_8.u7OVSYHS4RI.Font.StrikeThrough = -1;
				});
			}
			if (p7HVKGYJfG3.Code)
			{
				x0YVKN486Vs(if6J2oVKC21QN5q6nYBW2, "NameAscii", end, delegate
				{
					CS_8_locals_8.u7OVSYHS4RI.Font.NameAscii = "NameOther";
				});
				x0YVKN486Vs(if6J2oVKC21QN5q6nYBW2, "Underline", end, delegate
				{
					CS_8_locals_8.u7OVSYHS4RI.Font.NameOther = "Color";
				});
			}
			if (p7HVKGYJfG3.Link)
			{
				x0YVKN486Vs(if6J2oVKC21QN5q6nYBW2, "Document", end, delegate
				{
					CS_8_locals_8.u7OVSYHS4RI.Font.Underline = WdUnderline.wdUnderlineSingle;
				});
				x0YVKN486Vs(if6J2oVKC21QN5q6nYBW2, "Word document is unavailable.", end, delegate
				{
					CS_8_locals_8.u7OVSYHS4RI.Font.Color = WdColor.wdColorBlue;
				});
			}
			return if6J2oVKC21QN5q6nYBW2;
		}

		private static void x0YVKN486Vs(if6J2oVKC21QN5q6nYBW P_0, string P_1, int P_2, Action P_3)
		{
			try
			{
				P_3();
			}
			catch (Exception ex)
			{
				P_0.CDvVKptgDXx(P_1, P_2, ex);
			}
		}
	}

	private sealed class if6J2oVKC21QN5q6nYBW
	{
		private readonly int vcMVKOkVh3C;

		private readonly int hRcVKnKxgwE;

		[CompilerGenerated]
		private int r5kVK7hkL3j;

		[CompilerGenerated]
		private string WFaVK5HJEXw;

		public int FailureCount
		{
			[CompilerGenerated]
			get
			{
				return r5kVK7hkL3j;
			}
			[CompilerGenerated]
			private set
			{
				r5kVK7hkL3j = value;
			}
		}

		public string FirstFailure
		{
			[CompilerGenerated]
			get
			{
				return WFaVK5HJEXw;
			}
			[CompilerGenerated]
			private set
			{
				WFaVK5HJEXw = value;
			}
		}

		public bool Success => FailureCount == 0;

		public if6J2oVKC21QN5q6nYBW(int P_0, int P_1)
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			vcMVKOkVh3C = P_0;
			hRcVKnKxgwE = P_1;
		}

		public void CDvVKptgDXx(string P_0, int P_1, Exception P_2)
		{
			FailureCount++;
			string firstFailure = string.Format("Property={0}; HResult=0x{1:X8}; Message={2}", P_0, P_2?.HResult ?? 0, (P_2 != null) ? P_2.Message : string.Empty);
			if (string.IsNullOrWhiteSpace(FirstFailure))
			{
				FirstFailure = firstFailure;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0
	{
		public ProgressWindow IYTVKhTpBD8;

		public _G_c__DisplayClass2_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal bool uPxVKXg9FaT(int current, int count, string message)
		{
			return YTWbi7fmXQ(IYTVKhTpBD8, JJNbQpNQHZ(42, 70, current, count), message);
		}

		internal bool puiVKFwbJhh(int current, int count, string message)
		{
			return YTWbi7fmXQ(IYTVKhTpBD8, JJNbQpNQHZ(72, 86, current, count), message);
		}
	}

	private static readonly MarkdownPipeline gTVb3YLUE9;

	public static bool WWLbgbduxa(string P_0)
	{
		return XiHb8xdPLA(P_0, true);
	}

	public static bool XiHb8xdPLA(string P_0, bool P_1)
	{
		_G_c__DisplayClass2_0 CS_8_locals_19 = new _G_c__DisplayClass2_0();
		if (string.IsNullOrWhiteSpace(P_0))
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("请先粘贴 Markdown 文本。", "IP_Assurance");
			return false;
		}
		Application wordApp = eSfxffslhXbaGAjFNv1.WordApp;
		if (wordApp == null)
		{
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8("未找到 Word/WPS 文档窗口。", "IP_Assurance");
			return false;
		}
		Document activeDocument;
		try
		{
			activeDocument = wordApp.ActiveDocument;
		}
		catch
		{
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8("请先打开一个 Word/WPS 文档。", "IP_Assurance");
			return false;
		}
		if (activeDocument == null)
		{
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8("请先打开一个 Word/WPS 文档。", "IP_Assurance");
			return false;
		}
		CS_8_locals_19.IYTVKhTpBD8 = null;
		MarkdownDocument markdownDocument;
		try
		{
			CS_8_locals_19.IYTVKhTpBD8 = kHPbISh9Qh();
			if (!YTWbi7fmXQ(CS_8_locals_19.IYTVKhTpBD8, 5, "正在解析 Markdown..."))
			{
				toUbrnO456(CS_8_locals_19.IYTVKhTpBD8);
				return jiab1MdR7Y();
			}
			markdownDocument = Markdown.Parse(P_0, gTVb3YLUE9);
		}
		catch (Exception ex)
		{
			toUbrnO456(CS_8_locals_19.IYTVKhTpBD8);
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[MarkdownImport] Parse failed", ex);
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8("Markdown 解析失败：" + ex.Message, "IP_Assurance");
			return false;
		}
		bool screenUpdating = wordApp.ScreenUpdating;
		try
		{
			wordApp.ScreenUpdating = false;
			if (!YTWbi7fmXQ(CS_8_locals_19.IYTVKhTpBD8, 15, "正在写入 Word 内容..."))
			{
				return jiab1MdR7Y();
			}
			aAlPvcVUL6QeYdQQTx4o aAlPvcVUL6QeYdQQTx4o2 = new aAlPvcVUL6QeYdQQTx4o(wordApp, activeDocument);
			aAlPvcVUL6QeYdQQTx4o2.zHcVUs5hLZv(markdownDocument);
			Range range = aAlPvcVUL6QeYdQQTx4o2.byJVUlMc00b();
			if (range == null || range.End <= range.Start)
			{
				F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("未生成可导入的 Word 内容。", "IP_Assurance");
				return false;
			}
			if (P_1)
			{
				if (!YTWbi7fmXQ(CS_8_locals_19.IYTVKhTpBD8, 35, "正在应用标题编号..."))
				{
					return jiab1MdR7Y();
				}
				aAlPvcVUL6QeYdQQTx4o2.B27VUmfiUVg();
				if (jlHbHchUTp(CS_8_locals_19.IYTVKhTpBD8))
				{
					return jiab1MdR7Y();
				}
			}
			if (!YTWbi7fmXQ(CS_8_locals_19.IYTVKhTpBD8, 42, "正在设置段落格式..."))
			{
				return jiab1MdR7Y();
			}
			INe7hoMZ2egQUJDl6fB.hn7MXTwgTj(range.Duplicate, false, (int current, int count, string message) => YTWbi7fmXQ(CS_8_locals_19.IYTVKhTpBD8, JJNbQpNQHZ(42, 70, current, count), message));
			if (jlHbHchUTp(CS_8_locals_19.IYTVKhTpBD8))
			{
				return jiab1MdR7Y();
			}
			if (!YTWbi7fmXQ(CS_8_locals_19.IYTVKhTpBD8, 72, "正在设置表格格式..."))
			{
				return jiab1MdR7Y();
			}
			MTM8HqftP23tlVOKhjT.EQ9fmGO0V5(range.Duplicate, false, (int current, int count, string message) => YTWbi7fmXQ(CS_8_locals_19.IYTVKhTpBD8, JJNbQpNQHZ(72, 86, current, count), message));
			if (jlHbHchUTp(CS_8_locals_19.IYTVKhTpBD8))
			{
				return jiab1MdR7Y();
			}
			if (!YTWbi7fmXQ(CS_8_locals_19.IYTVKhTpBD8, 92, "正在应用行内样式..."))
			{
				return jiab1MdR7Y();
			}
			aAlPvcVUL6QeYdQQTx4o2.gvvVUNAOj7c();
			if (jlHbHchUTp(CS_8_locals_19.IYTVKhTpBD8))
			{
				return jiab1MdR7Y();
			}
			YTWbi7fmXQ(CS_8_locals_19.IYTVKhTpBD8, 98, "正在定位导入结束位置...");
			aAlPvcVUL6QeYdQQTx4o2.IXpVUo7IqG4();
			YTWbi7fmXQ(CS_8_locals_19.IYTVKhTpBD8, 100, "Markdown 导入完成。");
			F2ZFeLcsiLlLr89kqUl.Ay3cNuEgJo(N5AbJXUjJs(aAlPvcVUL6QeYdQQTx4o2), "IP_Assurance");
			return true;
		}
		catch (Exception ex2)
		{
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[MarkdownImport] Import failed", ex2);
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8("Markdown 导入失败：" + ex2.Message, "IP_Assurance");
			return false;
		}
		finally
		{
			toUbrnO456(CS_8_locals_19.IYTVKhTpBD8);
			wordApp.ScreenUpdating = screenUpdating;
		}
	}

	private static ProgressWindow kHPbISh9Qh()
	{
		try
		{
			ProgressWindow obj = new ProgressWindow
			{
				Title = "Markdown 导入"
			};
			rA7neb5TDVvwyWyxwua.IPf5i0ZcV4(obj);
			return obj;
		}
		catch
		{
			return null;
		}
	}

	private static bool YTWbi7fmXQ(ProgressWindow P_0, int P_1, string P_2)
	{
		if (P_0 == null)
		{
			return true;
		}
		if (P_0.IsCancelRequested || !P_0.IsVisible)
		{
			return false;
		}
		P_0.SetProgress(P_1, P_2);
		try
		{
			P_0.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
		}
		catch
		{
		}
		if (P_0.IsVisible)
		{
			return !P_0.IsCancelRequested;
		}
		return false;
	}

	private static bool jlHbHchUTp(ProgressWindow P_0)
	{
		if (P_0 != null)
		{
			if (!P_0.IsCancelRequested)
			{
				return !P_0.IsVisible;
			}
			return true;
		}
		return false;
	}

	private static int JJNbQpNQHZ(int P_0, int P_1, int P_2, int P_3)
	{
		if (P_3 <= 0)
		{
			return P_1;
		}
		double num = Math.Max(0.0, Math.Min(1.0, (double)P_2 * 1.0 / (double)P_3));
		return P_0 + (int)Math.Round((double)(P_1 - P_0) * num);
	}

	private static bool jiab1MdR7Y()
	{
		F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("Markdown 导入已取消，可使用 Word 撤销回退本次导入。", "IP_Assurance");
		return false;
	}

	private static void toUbrnO456(ProgressWindow P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		try
		{
			P_0.Close();
		}
		catch
		{
		}
	}

	private static string N5AbJXUjJs(aAlPvcVUL6QeYdQQTx4o P_0)
	{
		string text = string.Format("Markdown 导入完成：标题 {0} 个，段落 {1} 个，表格 {2} 个。", P_0.HeadingCount, P_0.ParagraphCount, P_0.TableCount);
		if (P_0.InlineStyleFailureCount > 0)
		{
			text += string.Format("其中 {0} 处行内样式未完全应用，请检查导入结果。", P_0.InlineStyleFailureCount);
		}
		if (P_0.HeadingNumberingFailureCount > 0)
		{
			text += string.Format("另有 {0} 个标题未成功应用编号。", P_0.HeadingNumberingFailureCount);
		}
		return text;
	}

	static s2nMCybDnhhNsDsld0f()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		gTVb3YLUE9 = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
	}
}
