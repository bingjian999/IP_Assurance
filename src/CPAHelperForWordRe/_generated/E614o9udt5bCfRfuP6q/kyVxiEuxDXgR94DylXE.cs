using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using bKwVJaKHQ9PJpSGiqkF;
using bWwioXMfw8EU8MWK7Iw;
using CFnjp5HCm3VNJaynxeu;
using dA68LaiUUFcpDRm4aMc;
using dL7TFPsQbAGqPywtHUK;
using dpdiOwfLNrjZbpbZGek;
using evP3VoQiyAKHarp7ISV;
using Fh5FEJQLhSKrbQbj77n;
using FiIb7mSOBD13BJBxsh0;
using HGQOfdJM683ZRGDQPGT;
using hJKpQrVSwRwMyI2RyDQN;
using IE65okus88MbfGVSFao;
using IoyiRBiaSfAhGWKe7nT;
using lwIf33HapEY34xFgYhf;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PcY4FmHTddIKsSgeNcA;
using pNO7Qri4x5uLAW3n8ge;
using qPcLehiLXDidbPregGS;
using QxQEUjHYrWF8UYgtlPk;
using sfEQOUHcxG5mqMZHoWq;
using VeCGWCiOGnOhH7Woc5n;
using XxsIHjQoTV4osLoOhQQ;
using Ygqd3NJsBlYEnwMqFef;
using YYxtPnurDabQj37usVF;
using zXs8EW9GijtvoeAXF0q;

namespace E614o9udt5bCfRfuP6q;

internal sealed class kyVxiEuxDXgR94DylXE
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass101_0
	{
		public string DcQPO8MZst;

		public Func<Microsoft.Office.Interop.Word.Application, rU18qH9owXvBsPZ0iiU> ntwPnGtes4;

		public Stopwatch L8uP766qcr;

		public _G_c__DisplayClass101_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU FmkPphZYfT(Microsoft.Office.Interop.Word.Application app)
		{
			string text = TEu80pJf6BRff8wZLuh.gEFJbNPT5J(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return TEu80pJf6BRff8wZLuh.dclJSetxGY(text);
			}
			yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[AI Tool][Word] Begin: " + DcQPO8MZst);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = ntwPnGtes4(app);
			L8uP766qcr.Stop();
			yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[AI Tool][Word] End: " + DcQPO8MZst + "; Success=" + (rU18qH9owXvBsPZ0iiU2?.success ?? false) + "; ElapsedMs=" + L8uP766qcr.ElapsedMilliseconds);
			return rU18qH9owXvBsPZ0iiU2;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass110_0
	{
		public Selection SxpPco33lP;

		public _G_c__DisplayClass110_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int v5dP5SVdCh()
		{
			return SxpPco33lP.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass112_0
	{
		public Document doc;

		public bool iHsPytK5nj;

		public Func<rU18qH9owXvBsPZ0iiU> mL2PXSVZkT;

		public _G_c__DisplayClass112_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU fLoPeAd4Hb()
		{
			bool trackRevisions = doc.TrackRevisions;
			try
			{
				doc.TrackRevisions = iHsPytK5nj;
				return mL2PXSVZkT();
			}
			finally
			{
				doc.TrackRevisions = trackRevisions;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass114_0
	{
		public Range KjZPAhp8aP;

		public Range irDPv8cQCT;

		public Document doc;

		public _G_c__DisplayClass114_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int kLKPFHqUgc()
		{
			return KjZPAhp8aP.Tables.Count;
		}

		internal string eDWPhqqcW2()
		{
			return irDPv8cQCT.Text;
		}

		internal int wWmPaQY7IC()
		{
			return irDPv8cQCT.Start;
		}

		internal int M6BPqcYX8K()
		{
			return irDPv8cQCT.End;
		}

		internal int iNMPPIpZX0()
		{
			return doc.Tables.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass116_0
	{
		public Document doc;

		public _G_c__DisplayClass116_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string X3yPW1ItXt()
		{
			return doc.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass120_0
	{
		public Range YFePdnGL8J;

		public Cell Og9PzULlg1;

		public _G_c__DisplayClass120_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int cZIP0LiFUZ()
		{
			return YFePdnGL8J.Tables.Count;
		}

		internal int WoFPkInXyF()
		{
			return Og9PzULlg1.Range.Start;
		}

		internal int QPEPxG9L8D()
		{
			return Og9PzULlg1.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass124_0
	{
		public Document doc;

		public _G_c__DisplayClass124_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string BokARIDrEs()
		{
			return doc.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass129_0
	{
		public Table X4DA9OZanO;

		public _G_c__DisplayClass129_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int l6RAV1QH2i()
		{
			return X4DA9OZanO.Rows.Count;
		}

		internal int sdTABJSY9C()
		{
			return X4DA9OZanO.Columns.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass132_0
	{
		public Range TNqAud7svs;

		public _G_c__DisplayClass132_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int wM7A6l3hn4()
		{
			return TNqAud7svs.Tables.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass132_1
	{
		public Cell bAiAg2Qtct;

		public _G_c__DisplayClass132_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int mBsADRNVfJ()
		{
			return bAiAg2Qtct.Range.Start;
		}

		internal int N6fATacHsr()
		{
			return bAiAg2Qtct.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass138_0
	{
		public Document doc;

		public _G_c__DisplayClass138_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string WvRA82xqXy()
		{
			return doc.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass13_0
	{
		public int J9aAilG42t;

		public bool RPPAH8g0Y1;

		public bool XVvAQYyUwY;

		public _G_c__DisplayClass13_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU RJvAIofXPq(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass13_1 CS_8_locals_9 = new _G_c__DisplayClass13_1();
			CS_8_locals_9.doc = ca8TtvS05W(app);
			Selection selection = app.Selection;
			int num = Qb88EN6Ey5(J9aAilG42t, 240, 2000);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word context read.", new
			{
				document = CS_8_locals_9.doc.Name,
				documentFullName = CS_8_locals_9.doc.FullName,
				pageCount = (RPPAH8g0Y1 ? new int?(iSW8Dscw3U(CS_8_locals_9.doc, WdStatistic.wdStatisticPages)) : ((int?)null)),
				wordCount = (RPPAH8g0Y1 ? new int?(iSW8Dscw3U(CS_8_locals_9.doc, WdStatistic.wdStatisticWords)) : ((int?)null)),
				statisticsIncluded = RPPAH8g0Y1,
				paragraphCount = Y1x8gkTvcF(() => CS_8_locals_9.doc.Paragraphs.Count),
				tableCount = Y1x8gkTvcF(() => CS_8_locals_9.doc.Tables.Count),
				commentCount = Y1x8gkTvcF(() => CS_8_locals_9.doc.Comments.Count),
				trackRevisions = qYW8T4YgwR(CS_8_locals_9.doc),
				selection = RTIgEY6EEf(selection, XVvAQYyUwY, num)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass13_1
	{
		public Document doc;

		public _G_c__DisplayClass13_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int PTiA1rsqdv()
		{
			return doc.Paragraphs.Count;
		}

		internal int YlhArOcLy8()
		{
			return doc.Tables.Count;
		}

		internal int oLAAJYFg4r()
		{
			return doc.Comments.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass141_0
	{
		public Cell sXuAUW1XT9;

		public _G_c__DisplayClass141_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string KJCA308JBw()
		{
			return sXuAUW1XT9.Range.Text;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass143_0
	{
		public Table vk1AEfduQP;

		public _G_c__DisplayClass143_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string U8xAKwaZFd()
		{
			return vk1AEfduQP.Range.WordOpenXML;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass144_0
	{
		public int R9eA4ukJ3b;

		public _G_c__DisplayClass144_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal bool StVA2MGlEs(JaeGYLH5MusMIC1Og5S merge)
		{
			if (merge.StartRow <= R9eA4ukJ3b)
			{
				return merge.EndRow >= R9eA4ukJ3b;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass145_0
	{
		public string DojAYMESMP;

		public _G_c__DisplayClass145_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal bool tt7AjO7u0h(XElement p)
		{
			return string.Equals(p.Attribute(hLV8L0pG1W + "name")?.Value, DojAYMESMP, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass148_0
	{
		public Document doc;

		public Range tI1AfO9S88;

		public string w8yAMEApiM;

		public _G_c__DisplayClass148_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU joXAZFdTOi()
		{
			bool trackRevisions = doc.TrackRevisions;
			try
			{
				doc.TrackRevisions = true;
				string text = Pfn84MVBvM(tI1AfO9S88.Text);
				int start = tI1AfO9S88.Start;
				tI1AfO9S88.Text = w8yAMEApiM ?? string.Empty;
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word range replaced with track changes.", new
				{
					document = doc.Name,
					documentFullName = doc.FullName,
					page = Y878QfFgDa(tI1AfO9S88),
					rangeStart = start,
					oldCharacters = text.Length,
					newCharacters = (w8yAMEApiM ?? string.Empty).Length,
					oldPreview = rYN8Y355we(text, 240)
				});
			}
			finally
			{
				doc.TrackRevisions = trackRevisions;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass14_0
	{
		public int fYKASMsLjm;

		public int RMsAwfQ3yh;

		public int CJEAt6PfJ1;

		public int fMuAL1vXEU;

		public int m7NAsZC1o6;

		public _G_c__DisplayClass14_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU D1DAbGb3we(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass14_1 CS_8_locals_10 = new _G_c__DisplayClass14_1();
			CS_8_locals_10.doc = ca8TtvS05W(app);
			Selection selection = app.Selection;
			int num = Y1x8gkTvcF(() => CS_8_locals_10.doc.Paragraphs.Count);
			int num2 = Qb88EN6Ey5(fYKASMsLjm, 8, 50);
			int num3 = Qb88EN6Ey5(RMsAwfQ3yh, 4, 50);
			int num4 = Qb88EN6Ey5(CJEAt6PfJ1, 50, 300);
			int num5 = Qb88EN6Ey5(fMuAL1vXEU, 180, 1000);
			int num6 = Qb88EN6Ey5(m7NAsZC1o6, 240, 2000);
			List<object> list = new List<object>();
			List<object> list2 = new List<object>();
			List<object> list3 = new List<object>();
			for (int num7 = 1; num7 <= num; num7++)
			{
				if (list.Count >= num2)
				{
					break;
				}
				Paragraph paragraph = CS_8_locals_10.doc.Paragraphs[num7];
				if (!string.IsNullOrWhiteSpace(Pfn84MVBvM(paragraph.Range.Text)))
				{
					list.Add(C71g2s9eOp(paragraph, num7, num5));
				}
			}
			for (int num8 = Math.Max(1, num - num3 + 1); num8 <= num; num8++)
			{
				Paragraph paragraph2 = CS_8_locals_10.doc.Paragraphs[num8];
				if (!string.IsNullOrWhiteSpace(Pfn84MVBvM(paragraph2.Range.Text)))
				{
					list2.Add(C71g2s9eOp(paragraph2, num8, num5));
				}
			}
			for (int num9 = 1; num9 <= num; num9++)
			{
				if (list3.Count >= num4)
				{
					break;
				}
				Paragraph paragraph3 = CS_8_locals_10.doc.Paragraphs[num9];
				if (fSO88F0gne(paragraph3) == 1 && !string.IsNullOrWhiteSpace(Pfn84MVBvM(paragraph3.Range.Text)))
				{
					list3.Add(C71g2s9eOp(paragraph3, num9, num5));
				}
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word document preview prepared.", new
			{
				document = CS_8_locals_10.doc.Name,
				documentFullName = CS_8_locals_10.doc.FullName,
				paragraphCount = num,
				tableCount = Y1x8gkTvcF(() => CS_8_locals_10.doc.Tables.Count),
				commentCount = Y1x8gkTvcF(() => CS_8_locals_10.doc.Comments.Count),
				trackRevisions = qYW8T4YgwR(CS_8_locals_10.doc),
				selection = RTIgEY6EEf(selection, false, num6),
				headingLevel = 1,
				headings = list3,
				head = list,
				tail = list2,
				truncated = (num > list.Count + list2.Count || list3.Count >= num4)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass14_1
	{
		public Document doc;

		public _G_c__DisplayClass14_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int FZuAldQelb()
		{
			return doc.Paragraphs.Count;
		}

		internal int VmXANckOSX()
		{
			return doc.Tables.Count;
		}

		internal int swYAm8P6Y6()
		{
			return doc.Comments.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass157_0
	{
		public Paragraph XbCACwggdo;

		public _G_c__DisplayClass157_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string x6mAoxVxID()
		{
			return XbCACwggdo.Range.Document.Name;
		}

		internal string d2QAG3yRf2()
		{
			return XbCACwggdo.Range.Document.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass158_0
	{
		public Table F3bAXyBVcX;

		public _G_c__DisplayClass158_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string SwkAp5CsRm()
		{
			return F3bAXyBVcX.Range.Document.Name;
		}

		internal string LHyAOPt2nr()
		{
			return F3bAXyBVcX.Range.Document.FullName;
		}

		internal string t8HAnhStOb()
		{
			return F3bAXyBVcX.Title;
		}

		internal string AKyA7NuJc0()
		{
			return F3bAXyBVcX.Descr;
		}

		internal string iQGA5hO7Rm()
		{
			return F3bAXyBVcX.Range.Document.Name;
		}

		internal string wwjAcsiftb()
		{
			return F3bAXyBVcX.Range.Document.FullName;
		}

		internal string fEpAe08k94()
		{
			return F3bAXyBVcX.Title;
		}

		internal string mrvAyFTqpY()
		{
			return F3bAXyBVcX.Descr;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass159_0
	{
		public Document doc;

		public _G_c__DisplayClass159_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int m99AFj3LJR()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass15_0
	{
		public int L1wAaU9BTc;

		public _G_c__DisplayClass15_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU gkxAhXRqiI(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Selection selection = app.Selection;
			if (selection == null || selection.Range == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前没有可读取的 Word 选区。", "empty_selection");
			}
			int num = Qb88EN6Ey5(L1wAaU9BTc, 6000, 30000);
			string text = Pfn84MVBvM(selection.Range.Text);
			bool flag = text.Length > num;
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word selection preview prepared.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = Y878QfFgDa(selection.Range),
				rangeStart = selection.Range.Start,
				rangeEnd = selection.Range.End,
				characters = text.Length,
				truncated = flag,
				text = (flag ? text.Substring(0, num) : text)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass169_0
	{
		public Comment GPkAA2kBUh;

		public _G_c__DisplayClass169_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string no8AqAOSfQ()
		{
			return GPkAA2kBUh.Author;
		}

		internal bool FM3APq4Cyt()
		{
			return GPkAA2kBUh.Done;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_0
	{
		public int bEEAWaNvfx;

		public int Ll8A0OxJ6L;

		public int PCtAkY60JX;

		public _G_c__DisplayClass16_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU sZFAvwt2as(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Range range = fyVTLmFfU6(document, bEEAWaNvfx, Ll8A0OxJ6L);
			int num = Qb88EN6Ey5(PCtAkY60JX, 30000, 30000);
			string text = Pfn84MVBvM(range.Text);
			bool flag = text.Length > num;
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word range read.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = Y878QfFgDa(range),
				paragraphIndex = EFt8ufX87I(document, range.Start),
				rangeStart = range.Start,
				rangeEnd = range.End,
				characters = text.Length,
				truncated = flag,
				text = (flag ? text.Substring(0, num) : text)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass170_0
	{
		public Comments cf4AdHv0sj;

		public _G_c__DisplayClass170_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int sQqAxpEtin()
		{
			return cf4AdHv0sj.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass171_0
	{
		public Comment SNfvVLBP8C;

		public _G_c__DisplayClass171_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string VNXAzPAdJT()
		{
			return SNfvVLBP8C.Author;
		}

		internal bool gLXvRCB6k5()
		{
			return SNfvVLBP8C.Done;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass173_0
	{
		public Document doc;

		public _G_c__DisplayClass173_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int cxcvBRALf7()
		{
			return doc.Comments.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass173_1
	{
		public Comments i0Hv6Nmgjt;

		public _G_c__DisplayClass173_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int nqKv9PZdYD()
		{
			return i0Hv6Nmgjt.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass174_0
	{
		public Document doc;

		public _G_c__DisplayClass174_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int Io2vu7GF6Q()
		{
			return doc.Comments.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass179_0
	{
		public Comment HThvTPlNIo;

		public _G_c__DisplayClass179_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string h8KvDod9xv()
		{
			return HThvTPlNIo.Range.Text;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass17_0
	{
		public int hADv8m57Le;

		public int xYgvIDRxGK;

		public int EHCvi3Xdu6;

		public int zJ6vHSXXXc;

		public _G_c__DisplayClass17_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU pJbvglHXj8(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass17_1 CS_8_locals_5 = new _G_c__DisplayClass17_1();
			CS_8_locals_5.doc = ca8TtvS05W(app);
			int num = Y1x8gkTvcF(() => CS_8_locals_5.doc.Paragraphs.Count);
			int num2 = Math.Max(1, (hADv8m57Le <= 0) ? 1 : hADv8m57Le);
			if (num2 > num)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("startParagraphIndex is out of range.", "invalid_arguments", new
				{
					totalParagraphs = num
				});
			}
			int num3;
			if (xYgvIDRxGK > 0)
			{
				if (xYgvIDRxGK < num2)
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("endParagraphIndex must be greater than or equal to startParagraphIndex.", "invalid_arguments");
				}
				num3 = Math.Min(num, xYgvIDRxGK);
			}
			else
			{
				int num4 = Qb88EN6Ey5(EHCvi3Xdu6, 20, 300);
				num3 = Math.Min(num, num2 + num4 - 1);
			}
			int num5 = Qb88EN6Ey5(zJ6vHSXXXc, 1000, 5000);
			List<object> list = new List<object>();
			for (int num6 = num2; num6 <= num3; num6++)
			{
				list.Add(KFSg410uKL(CS_8_locals_5.doc.Paragraphs[num6], num6, num5));
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word paragraphs read.", new
			{
				document = CS_8_locals_5.doc.Name,
				documentFullName = CS_8_locals_5.doc.FullName,
				totalParagraphs = num,
				startParagraphIndex = num2,
				endParagraphIndex = num3,
				returned = list.Count,
				truncated = (xYgvIDRxGK <= 0 && num3 < num),
				paragraphs = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass17_1
	{
		public Document doc;

		public _G_c__DisplayClass17_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int PqEvQuygdD()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass180_0
	{
		public Comment z7dvrWsTRd;

		public _G_c__DisplayClass180_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string weyv1Lgyt0()
		{
			return z7dvrWsTRd.Scope.Text;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass181_0
	{
		public Comment qQmv3ah72i;

		public _G_c__DisplayClass181_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string iANvJlsHhm()
		{
			return qQmv3ah72i.Date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass183_0
	{
		public Comments ObJvKEDR9S;

		public _G_c__DisplayClass183_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int ffIvUKbuZI()
		{
			return ObJvKEDR9S.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass189_0
	{
		public Document doc;

		public Comment dZqvjvPh60;

		public _G_c__DisplayClass189_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string HlRvEAifbI()
		{
			return doc.FullName;
		}

		internal string fs6v2S4X9s()
		{
			return doc.Name;
		}

		internal string ROUv4t6rvn()
		{
			return dZqvjvPh60.Author;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass18_0
	{
		public int qdXvZGOPXC;

		public int wy0vf7TCxm;

		public bool C34vMfFZPN;

		public _G_c__DisplayClass18_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU B5ivY8t421(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass18_1 CS_8_locals_5 = new _G_c__DisplayClass18_1();
			CS_8_locals_5.doc = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(qdXvZGOPXC, 300, 1000);
			int num2 = mrd82RKl0E(wy0vf7TCxm);
			int num3 = Y1x8gkTvcF(() => CS_8_locals_5.doc.Paragraphs.Count);
			List<object> list = new List<object>();
			int num4 = 0;
			for (int num5 = 1; num5 <= num3; num5++)
			{
				if (list.Count >= num)
				{
					break;
				}
				Paragraph paragraph = CS_8_locals_5.doc.Paragraphs[num5];
				int num6 = fSO88F0gne(paragraph);
				bool flag = num6 >= 1 && num6 <= 9;
				if ((flag || C34vMfFZPN) && (!flag || num6 <= num2) && !string.IsNullOrWhiteSpace(Pfn84MVBvM(paragraph.Range.Text)))
				{
					if (flag)
					{
						num4++;
					}
					list.Add(KFSg410uKL(paragraph, num5, 240));
				}
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word outline read.", new
			{
				document = CS_8_locals_5.doc.Name,
				documentFullName = CS_8_locals_5.doc.FullName,
				maxOutlineLevel = num2,
				includeBodyText = C34vMfFZPN,
				headings = num4,
				returned = list.Count,
				truncated = (list.Count >= num),
				items = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass18_1
	{
		public Document doc;

		public _G_c__DisplayClass18_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int kRTvbnOjRj()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass193_0
	{
		public Table v4mvtS4fDJ;

		public _G_c__DisplayClass193_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int GpxvSbABr6()
		{
			return v4mvtS4fDJ.Range.Start;
		}

		internal int aPbvwXpf7n()
		{
			return v4mvtS4fDJ.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass194_0
	{
		public Selection KaavoKjFKG;

		public Microsoft.Office.Interop.Word.Application Q3qvGo2NUJ;

		public Document doc;

		public _G_c__DisplayClass194_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int bgtvLPLLLr()
		{
			return KaavoKjFKG.Range.Start;
		}

		internal int SquvsbslZx()
		{
			return KaavoKjFKG.Range.End;
		}

		internal bool nxfvlwbZOb()
		{
			return Q3qvGo2NUJ.ScreenUpdating;
		}

		internal int psVvNEwPh7()
		{
			return doc.Content.Start;
		}

		internal int ypvvmjQxqY()
		{
			return doc.Content.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass194_1
	{
		public Range NSNvOLlBYV;

		public _G_c__DisplayClass194_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int EhSvCUAjhB()
		{
			return NSNvOLlBYV.Start;
		}

		internal int G01vpOrJtG()
		{
			return NSNvOLlBYV.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass196_0
	{
		public Document doc;

		public _G_c__DisplayClass196_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int Iq2vnIHwMY()
		{
			return doc.Content.Start;
		}

		internal int o7vv7wHxx7()
		{
			return doc.Content.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass197_0
	{
		public Document doc;

		public _G_c__DisplayClass197_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int vEpv5dM4wY()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass19_0
	{
		public string PxqveKcgAE;

		public int yIkvyKLbo5;

		public int kECvXN2fmB;

		public string R0bvF75Grg;

		public int kDLvhCZhco;

		public int E0OvaTFIS7;

		public int KYpvq4y0Ob;

		public int UF0vP5R36r;

		public int f11vABUbwN;

		public _G_c__DisplayClass19_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU nKYvcSO8v5(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass19_1 CS_8_locals_11 = new _G_c__DisplayClass19_1();
			CS_8_locals_11.doc = ca8TtvS05W(app);
			Paragraph paragraph = a2QgUnQhBr(CS_8_locals_11.doc, PxqveKcgAE, yIkvyKLbo5, kECvXN2fmB, R0bvF75Grg);
			if (paragraph == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("未找到匹配的标题段落。", "not_found");
			}
			int num = ((yIkvyKLbo5 > 0) ? yIkvyKLbo5 : EFt8ufX87I(CS_8_locals_11.doc, paragraph.Range.Start).GetValueOrDefault());
			int num2 = fSO88F0gne(paragraph);
			if (num2 < 1 || num2 > 9)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("目标段落不是 Word 标题/大纲段落。", "invalid_arguments", new
				{
					headingParagraphIndex = num
				});
			}
			int num3 = Y1x8gkTvcF(() => CS_8_locals_11.doc.Paragraphs.Count);
			int num4 = num3;
			for (int num5 = num + 1; num5 <= num3; num5++)
			{
				int num6 = fSO88F0gne(CS_8_locals_11.doc.Paragraphs[num5]);
				if (num6 >= 1 && num6 <= num2)
				{
					num4 = num5 - 1;
					break;
				}
			}
			int num7 = Math.Max(0, kDLvhCZhco);
			int num8 = Qb88EN6Ey5(E0OvaTFIS7, 200, 1000);
			int num9 = Qb88EN6Ey5(KYpvq4y0Ob, 1000, 5000);
			int num10 = Qb88EN6Ey5(UF0vP5R36r, 80, 500);
			int num11 = Qb88EN6Ey5(f11vABUbwN, 20, 100);
			int start = paragraph.Range.Start;
			int end = CS_8_locals_11.doc.Paragraphs[num4].Range.End;
			List<jaDcyWQtOojM0IicNQ7> list = new List<jaDcyWQtOojM0IicNQ7>();
			for (int num12 = num; num12 <= num4; num12++)
			{
				Paragraph paragraph2 = CS_8_locals_11.doc.Paragraphs[num12];
				if (!YsX81TpOe7(paragraph2.Range))
				{
					list.Add(new jaDcyWQtOojM0IicNQ7
					{
						Type = "paragraph",
						RangeStart = paragraph2.Range.Start,
						Data = KFSg410uKL(paragraph2, num12, num9)
					});
				}
			}
			for (int num13 = 1; num13 <= CS_8_locals_11.doc.Tables.Count; num13++)
			{
				Table table = CS_8_locals_11.doc.Tables[num13];
				if (table.Range.Start >= start && table.Range.End <= end)
				{
					list.Add(new jaDcyWQtOojM0IicNQ7
					{
						Type = "table",
						RangeStart = table.Range.Start,
						Data = WhFgjeRETB(table, num13, num10, num11)
					});
				}
			}
			list.Sort((jaDcyWQtOojM0IicNQ7 left, jaDcyWQtOojM0IicNQ7 right) => left.RangeStart.CompareTo(right.RangeStart));
			List<object> list2 = new List<object>();
			List<object> list3 = new List<object>();
			List<object> list4 = new List<object>();
			if (num7 > list.Count)
			{
				num7 = list.Count;
			}
			int num14 = Math.Min(list.Count, num7 + num8);
			for (int num15 = num7; num15 < num14; num15++)
			{
				jaDcyWQtOojM0IicNQ7 jaDcyWQtOojM0IicNQ8 = list[num15];
				var item = new
				{
					blockIndex = num15,
					type = jaDcyWQtOojM0IicNQ8.Type,
					rangeStart = jaDcyWQtOojM0IicNQ8.RangeStart,
					data = jaDcyWQtOojM0IicNQ8.Data
				};
				list2.Add(item);
				if (jaDcyWQtOojM0IicNQ8.Type == "paragraph")
				{
					list3.Add(jaDcyWQtOojM0IicNQ8.Data);
				}
				else if (jaDcyWQtOojM0IicNQ8.Type == "table")
				{
					list4.Add(jaDcyWQtOojM0IicNQ8.Data);
				}
			}
			bool flag = num14 < list.Count;
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word section read.", new
			{
				document = CS_8_locals_11.doc.Name,
				documentFullName = CS_8_locals_11.doc.FullName,
				heading = KFSg410uKL(paragraph, num, 500),
				startParagraphIndex = num,
				endParagraphIndex = num4,
				rangeStart = start,
				rangeEnd = end,
				startBlock = num7,
				totalBlocks = list.Count,
				returnedBlocks = list2.Count,
				hasMore = flag,
				nextStartBlock = (flag ? new int?(num14) : ((int?)null)),
				returnedParagraphs = list3.Count,
				returnedTables = list4.Count,
				truncated = flag,
				blocks = list2,
				paragraphs = list3,
				tables = list4
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass19_1
	{
		public Document doc;

		public _G_c__DisplayClass19_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int iUovvnOw6I()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass209_0
	{
		public Style ABCv01h65Y;

		public _G_c__DisplayClass209_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string vfUvWndrUx()
		{
			return ABCv01h65Y.NameLocal;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass20_0
	{
		public int XVXvxrblxn;

		public int umIvdDfpSj;

		public int Wtcvz7hlth;

		public int E0JWRCBpLv;

		public _G_c__DisplayClass20_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU DJcvk0069a(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass20_1 CS_8_locals_7 = new _G_c__DisplayClass20_1();
			CS_8_locals_7.doc = ca8TtvS05W(app);
			int num = Y1x8gkTvcF(() => CS_8_locals_7.doc.Tables.Count);
			if (num == 0)
			{
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("No tables found.", new
				{
					document = CS_8_locals_7.doc.Name,
					documentFullName = CS_8_locals_7.doc.FullName,
					totalTables = 0,
					tables = new object[0]
				});
			}
			int num2 = ((XVXvxrblxn <= 0) ? 1 : XVXvxrblxn);
			int num3 = ((XVXvxrblxn > 0) ? XVXvxrblxn : Math.Min(num, Qb88EN6Ey5(umIvdDfpSj, 5, 100)));
			if (num2 < 1 || num2 > num)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("tableIndex is out of range.", "invalid_arguments", new
				{
					totalTables = num
				});
			}
			int num4 = Qb88EN6Ey5(Wtcvz7hlth, 80, 500);
			int num5 = Qb88EN6Ey5(E0JWRCBpLv, 20, 100);
			List<object> list = new List<object>();
			for (int num6 = num2; num6 <= num3; num6++)
			{
				list.Add(WhFgjeRETB(CS_8_locals_7.doc.Tables[num6], num6, num4, num5));
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word tables read.", new
			{
				document = CS_8_locals_7.doc.Name,
				documentFullName = CS_8_locals_7.doc.FullName,
				totalTables = num,
				returned = list.Count,
				tables = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass20_1
	{
		public Document doc;

		public _G_c__DisplayClass20_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int Ub1WVvpkU4()
		{
			return doc.Tables.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass21_0
	{
		public int UiYW9EeJB2;

		public int NMqW6fM6SQ;

		public int TjwWuYNRhv;

		public bool GuoWDvWnI0;

		public _G_c__DisplayClass21_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU dAwWBlBdqL(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass21_1 CS_8_locals_6 = new _G_c__DisplayClass21_1();
			CS_8_locals_6.doc = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(UiYW9EeJB2, 200, 1000);
			int num2 = Qb88EN6Ey5(NMqW6fM6SQ, 120, 1000);
			int num3 = ((TjwWuYNRhv < 0) ? 20 : Math.Min(TjwWuYNRhv, 200));
			List<object> list = new List<object>();
			int num4 = Y1x8gkTvcF(() => CS_8_locals_6.doc.Comments.Count);
			bool truncated = false;
			for (int num5 = 1; num5 <= num4; num5++)
			{
				Comment comment = CS_8_locals_6.doc.Comments[num5];
				if (zBSgpYfGrc(comment) == null)
				{
					if (list.Count >= num)
					{
						truncated = true;
						break;
					}
					list.Add(qXYglKDlsW(CS_8_locals_6.doc, comment, GuoWDvWnI0, num2, num3));
				}
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word comments read.", new
			{
				document = CS_8_locals_6.doc.Name,
				documentFullName = CS_8_locals_6.doc.FullName,
				totalComments = num4,
				returned = list.Count,
				truncated = truncated,
				comments = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass21_1
	{
		public Document doc;

		public _G_c__DisplayClass21_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int KgDWTxcfY7()
		{
			return doc.Comments.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass22_0
	{
		public string KJfW8q3L1A;

		public string kMCWIJvhU4;

		public int ICJWijA90t;

		public string KuQWHnWj6I;

		public string xpEWQM2HQp;

		public _G_c__DisplayClass22_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU zPPWg6x2Ll(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass22_1 CS_8_locals_34 = new _G_c__DisplayClass22_1();
			CS_8_locals_34.rvpWKhLSmL = this;
			if (string.IsNullOrWhiteSpace(KJfW8q3L1A))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("replyText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_34.doc = ca8TtvS05W(app);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = (string.IsNullOrWhiteSpace(kMCWIJvhU4) ? xSQgG8pt5e(CS_8_locals_34.doc, ICJWijA90t, out CS_8_locals_34.DEVWU1kljM, out CS_8_locals_34.FUKWrYRDvi) : CLCgCUGOui(CS_8_locals_34.doc, kMCWIJvhU4, ICJWijA90t, out CS_8_locals_34.DEVWU1kljM, out CS_8_locals_34.FUKWrYRDvi));
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			string text = UNcg5o6WsG(CS_8_locals_34.DEVWU1kljM);
			string text2 = XPEgcZYWAO(CS_8_locals_34.FUKWrYRDvi);
			string text3 = VkRg0Eonap(KuQWHnWj6I);
			string text4 = VkRg0Eonap(xpEWQM2HQp);
			if (!string.IsNullOrWhiteSpace(text3) && !string.Equals(VkRg0Eonap(text), text3, StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前批注内容与 expectedCommentText 不一致。请重新读取批注后再回复。", "comment_target_mismatch", new
				{
					commentToken = TkI8jwiSoi(kMCWIJvhU4),
					commentIndex = ICJWijA90t,
					expectedCommentText = text3,
					currentCommentText = text
				});
			}
			if (!string.IsNullOrWhiteSpace(text4) && !gxWgapxYhe(text2, text4))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前批注原文与 expectedScopeText 不一致。请重新读取批注后再回复。", "comment_target_mismatch", new
				{
					commentToken = TkI8jwiSoi(kMCWIJvhU4),
					commentIndex = ICJWijA90t,
					expectedScopeText = text4,
					currentScopeText = rYN8Y355we(text2, 500)
				});
			}
			CS_8_locals_34.NkgW3GNZRG = QfAg7hyofH(CS_8_locals_34.FUKWrYRDvi) ?? Rt8gnHTE8S(CS_8_locals_34.FUKWrYRDvi);
			if (CS_8_locals_34.NkgW3GNZRG == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("无法定位批注对应的正文范围。请重新读取批注后再回复。", "comment_anchor_unavailable", new
				{
					commentToken = TkI8jwiSoi(kMCWIJvhU4),
					commentIndex = ICJWijA90t,
					threadCommentIndex = GQJgya6RkO(CS_8_locals_34.FUKWrYRDvi)
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = Q7Sg1pThfx(app, CS_8_locals_34.doc, CS_8_locals_34.NkgW3GNZRG);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_34.ex9WJXHkl6 = KJfW8q3L1A.Trim();
			return oBKTTgZY41(app, "AI 回复批注", delegate
			{
				try
				{
					Comments comments = DOYgOEfqSy(CS_8_locals_34.FUKWrYRDvi);
					if (comments == null)
					{
						return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("replyText must not be empty.", "invalid_arguments", new
						{
							commentToken = TkI8jwiSoi(CS_8_locals_34.rvpWKhLSmL.kMCWIJvhU4),
							commentIndex = CS_8_locals_34.rvpWKhLSmL.ICJWijA90t,
							threadCommentIndex = GQJgya6RkO(CS_8_locals_34.FUKWrYRDvi)
						});
					}
					object Text = CS_8_locals_34.ex9WJXHkl6;
					Comment comment = comments.Add(CS_8_locals_34.NkgW3GNZRG, ref Text);
					if (comment == null)
					{
						return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前批注内容与 expectedCommentText 不一致。请重新读取批注后再回复。", "comment_target_mismatch", new
						{
							commentToken = TkI8jwiSoi(CS_8_locals_34.rvpWKhLSmL.kMCWIJvhU4),
							commentIndex = CS_8_locals_34.rvpWKhLSmL.ICJWijA90t,
							threadCommentIndex = GQJgya6RkO(CS_8_locals_34.FUKWrYRDvi)
						});
					}
					return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("当前批注原文与 expectedScopeText 不一致。请重新读取批注后再回复。", XbygofR3TT(CS_8_locals_34.doc, CS_8_locals_34.FUKWrYRDvi, CS_8_locals_34.DEVWU1kljM, comment, CS_8_locals_34.ex9WJXHkl6));
				}
				catch (Exception ex)
				{
					return rU18qH9owXvBsPZ0iiU.g7A9nYlk8v("comment_target_mismatch", "无法定位批注对应的正文范围。请重新读取批注后再回复。", ex, new
					{
						commentToken = TkI8jwiSoi(CS_8_locals_34.rvpWKhLSmL.kMCWIJvhU4),
						commentIndex = CS_8_locals_34.rvpWKhLSmL.ICJWijA90t,
						threadCommentIndex = GQJgya6RkO(CS_8_locals_34.FUKWrYRDvi)
					});
				}
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass22_1
	{
		public Comment FUKWrYRDvi;

		public string ex9WJXHkl6;

		public Range NkgW3GNZRG;

		public Document doc;

		public Comment DEVWU1kljM;

		public _G_c__DisplayClass22_0 rvpWKhLSmL;

		public _G_c__DisplayClass22_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU zPYW1VDwEW()
		{
			try
			{
				Comments comments = DOYgOEfqSy(FUKWrYRDvi);
				if (comments == null)
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前 Word/WPS 不支持通过 COM 回复批注。", "comment_reply_not_supported", new
					{
						commentToken = TkI8jwiSoi(rvpWKhLSmL.kMCWIJvhU4),
						commentIndex = rvpWKhLSmL.ICJWijA90t,
						threadCommentIndex = GQJgya6RkO(FUKWrYRDvi)
					});
				}
				object Text = ex9WJXHkl6;
				Comment comment = comments.Add(NkgW3GNZRG, ref Text);
				if (comment == null)
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("Word 未返回新增的批注回复。", "comment_reply_failed", new
					{
						commentToken = TkI8jwiSoi(rvpWKhLSmL.kMCWIJvhU4),
						commentIndex = rvpWKhLSmL.ICJWijA90t,
						threadCommentIndex = GQJgya6RkO(FUKWrYRDvi)
					});
				}
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word comment reply added.", XbygofR3TT(doc, FUKWrYRDvi, DEVWU1kljM, comment, ex9WJXHkl6));
			}
			catch (Exception ex)
			{
				return rU18qH9owXvBsPZ0iiU.g7A9nYlk8v("Word comment reply failed", "comment_reply_not_supported", ex, new
				{
					commentToken = TkI8jwiSoi(rvpWKhLSmL.kMCWIJvhU4),
					commentIndex = rvpWKhLSmL.ICJWijA90t,
					threadCommentIndex = GQJgya6RkO(FUKWrYRDvi)
				});
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_0
	{
		public int KSbW2tLPiW;

		public string PflW4syEJR;

		public int KLAWj0WLqu;

		public string NABWYo9U2i;

		public _G_c__DisplayClass23_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU OVxWEqO5m5(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass23_1 CS_8_locals_7 = new _G_c__DisplayClass23_1();
			CS_8_locals_7.doc = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(KSbW2tLPiW, 50, 300);
			string text = (PflW4syEJR ?? "contains").Trim().ToLowerInvariant();
			List<object> list = new List<object>();
			int num2 = Y1x8gkTvcF(() => CS_8_locals_7.doc.Paragraphs.Count);
			for (int num3 = 1; num3 <= num2; num3++)
			{
				if (list.Count >= num)
				{
					break;
				}
				Paragraph paragraph = CS_8_locals_7.doc.Paragraphs[num3];
				int num4 = fSO88F0gne(paragraph);
				if (num4 >= 1 && num4 <= 9 && (KLAWj0WLqu <= 0 || num4 == KLAWj0WLqu))
				{
					string text2 = Pfn84MVBvM(paragraph.Range.Text);
					if (OYJgKddkFp(text2, NABWYo9U2i, text))
					{
						list.Add(new
						{
							document = CS_8_locals_7.doc.Name,
							documentFullName = CS_8_locals_7.doc.FullName,
							page = Y878QfFgDa(paragraph.Range),
							headingParagraphIndex = num3,
							paragraphIndex = num3,
							outlineLevel = num4,
							rangeStart = paragraph.Range.Start,
							rangeEnd = paragraph.Range.End,
							text = text2,
							sectionReadHint = new
							{
								tool = "read_word_section",
								headingParagraphIndex = num3
							}
						});
					}
				}
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word heading find completed.", new
			{
				document = CS_8_locals_7.doc.Name,
				documentFullName = CS_8_locals_7.doc.FullName,
				query = (NABWYo9U2i ?? string.Empty),
				outlineLevel = ((KLAWj0WLqu <= 0) ? ((int?)null) : new int?(KLAWj0WLqu)),
				matchMode = text,
				returned = list.Count,
				truncated = (list.Count >= num),
				matches = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_1
	{
		public Document doc;

		public _G_c__DisplayClass23_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int JlCWZ1QPp7()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass24_0
	{
		public string kJMWMFbwEh;

		public int IraWb9i9wR;

		public bool HMyWStZlE1;

		public bool PFZWwdLEQF;

		public _G_c__DisplayClass24_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU wQ1WfUjh4t(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(kJMWMFbwEh))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("text must not be empty.", "invalid_arguments");
			}
			Document document = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(IraWb9i9wR, 100, 500);
			List<JLaVmTitkrKJCiFb1D5> list = jIegxGSM8E(app, document, kJMWMFbwEh, HMyWStZlE1, PFZWwdLEQF, num);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word text range find completed.", o9s8V9QIyZ(document, list, num));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass25_0
	{
		public string IOPWLBITxB;

		public int sjVWs8uNuc;

		public bool EyLWlEVNRV;

		public _G_c__DisplayClass25_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU jNkWtZ3oCl(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(IOPWLBITxB))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("pattern must not be empty.", "invalid_arguments");
			}
			Document document = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(sjVWs8uNuc, 100, 500);
			List<GrMBSXi2HFwNBUhA3m6> list = wS88Rn9xSe(document, IOPWLBITxB, EyLWlEVNRV, num);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word regex find completed.", pMT896JE6T(document, list, num));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass26_0
	{
		public string EJdWmMjUeA;

		public int GtCWo3eG2v;

		public bool XQ2WGdsSr5;

		public _G_c__DisplayClass26_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU MqNWN0L4np(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(EJdWmMjUeA))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("text must not be empty.", "invalid_arguments");
			}
			Document document = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(GtCWo3eG2v, 100, 500);
			List<object> list = new List<object>();
			for (int i = 1; i <= document.Tables.Count; i++)
			{
				if (list.Count >= num)
				{
					break;
				}
				_G_c__DisplayClass26_1 CS_8_locals_4 = new _G_c__DisplayClass26_1();
				CS_8_locals_4.sEvWprZlaY = document.Tables[i];
				int num2 = Ex5TMxi7X1(() => CS_8_locals_4.sEvWprZlaY.Range.End, 0);
				Range range = CS_8_locals_4.sEvWprZlaY.Range.Duplicate;
				while (list.Count < num)
				{
					range.Find.ClearFormatting();
					Find find = range.Find;
					object FindText = EJdWmMjUeA;
					object MatchCase = XQ2WGdsSr5;
					object MatchWholeWord = false;
					object MatchWildcards = false;
					object MatchSoundsLike = false;
					object MatchAllWordForms = false;
					object Forward = true;
					object Wrap = WdFindWrap.wdFindStop;
					object Format = false;
					object ReplaceWith = Type.Missing;
					object Replace = Type.Missing;
					object MatchKashida = Type.Missing;
					object MatchDiacritics = Type.Missing;
					object MatchAlefHamza = Type.Missing;
					object MatchControl = Type.Missing;
					if (!find.Execute(ref FindText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref ReplaceWith, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl) || range.Start >= range.End)
					{
						break;
					}
					Range duplicate = range.Duplicate;
					list.Add(MAygkj8OcZ(document, CS_8_locals_4.sEvWprZlaY, i, duplicate));
					int num3 = Math.Max(duplicate.End, duplicate.Start + 1);
					if (num2 <= 0 || num3 >= num2)
					{
						break;
					}
					try
					{
						MatchControl = num3;
						MatchAlefHamza = num2;
						range = document.Range(ref MatchControl, ref MatchAlefHamza);
					}
					catch
					{
						break;
					}
				}
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word table text find completed.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				returned = list.Count,
				truncated = (list.Count >= num),
				matches = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass26_1
	{
		public Table sEvWprZlaY;

		public _G_c__DisplayClass26_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int LE2WCev1E6()
		{
			return sEvWprZlaY.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass27_0
	{
		public int yBuWn9FBJs;

		public int NSnW7NMjGb;

		public _G_c__DisplayClass27_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU wG0WOOMtS2(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Range range = fyVTLmFfU6(document, yBuWn9FBJs, NSnW7NMjGb);
			document.Activate();
			range.Select();
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word range selected.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = Y878QfFgDa(range),
				rangeStart = range.Start,
				rangeEnd = range.End
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_0
	{
		public int GJUWc1Ct7n;

		public _G_c__DisplayClass28_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU UdbW5SY1i1(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			if (GJUWc1Ct7n < 1 || GJUWc1Ct7n > document.Tables.Count)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("tableIndex is out of range.", "invalid_arguments", new
				{
					totalTables = document.Tables.Count
				});
			}
			Table table = document.Tables[GJUWc1Ct7n];
			document.Activate();
			table.Range.Select();
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word table selected.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = GJUWc1Ct7n,
				page = Y878QfFgDa(table.Range),
				rangeStart = table.Range.Start,
				rangeEnd = table.Range.End
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass29_0
	{
		public string po5WyTWvh4;

		public _G_c__DisplayClass29_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU zQhWespjjC(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass29_1 CS_8_locals_13 = new _G_c__DisplayClass29_1();
			CS_8_locals_13.DTFWhrapJW = this;
			if (string.IsNullOrWhiteSpace(po5WyTWvh4))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("commentText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_13.doc = ca8TtvS05W(app);
			CS_8_locals_13.IMfWFN3Nni = app.Selection;
			if (CS_8_locals_13.IMfWFN3Nni == null || CS_8_locals_13.IMfWFN3Nni.Range == null || string.IsNullOrWhiteSpace(Pfn84MVBvM(CS_8_locals_13.IMfWFN3Nni.Range.Text)))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前没有可批注的正文选区。请先选中正文，或用 find_word_text 获取真实 Range 后调用 add_word_comment_at_range。", "empty_selection");
			}
			if (!XMVgr0DwLb(CS_8_locals_13.IMfWFN3Nni.Range))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前选区不在正文区域，可能选中了批注或批注窗格。请先选中正文，或用 find_word_text 获取真实 Range 后调用 add_word_comment_at_range。", "selection_not_in_main_document");
			}
			return oBKTTgZY41(app, "AI 添加批注", delegate
			{
				Comments comments = CS_8_locals_13.doc.Comments;
				Range range = CS_8_locals_13.IMfWFN3Nni.Range;
				object Text = CS_8_locals_13.DTFWhrapJW.po5WyTWvh4.Trim();
				Comment comment = comments.Add(range, ref Text);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("commentText must not be empty.", WWcgsjc2XU(CS_8_locals_13.doc, CS_8_locals_13.IMfWFN3Nni.Range, comment.Index, CS_8_locals_13.DTFWhrapJW.po5WyTWvh4));
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass29_1
	{
		public Document doc;

		public Selection IMfWFN3Nni;

		public _G_c__DisplayClass29_0 DTFWhrapJW;

		public _G_c__DisplayClass29_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU MRrWXOwniT()
		{
			Comments comments = doc.Comments;
			Range range = IMfWFN3Nni.Range;
			object Text = DTFWhrapJW.po5WyTWvh4.Trim();
			Comment comment = comments.Add(range, ref Text);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word comment added.", WWcgsjc2XU(doc, IMfWFN3Nni.Range, comment.Index, DTFWhrapJW.po5WyTWvh4));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_0
	{
		public string iYMWq6x2ON;

		public int bHXWPpRCjJ;

		public int WKMWApZUrG;

		public _G_c__DisplayClass30_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU LN5Waied7n(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass30_1 CS_8_locals_12 = new _G_c__DisplayClass30_1();
			CS_8_locals_12.NcsW0mbLbI = this;
			if (string.IsNullOrWhiteSpace(iYMWq6x2ON))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("commentText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_12.doc = ca8TtvS05W(app);
			CS_8_locals_12.QVSWWNpqS5 = fyVTLmFfU6(CS_8_locals_12.doc, bHXWPpRCjJ, WKMWApZUrG);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = Q7Sg1pThfx(app, CS_8_locals_12.doc, CS_8_locals_12.QVSWWNpqS5);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			return oBKTTgZY41(app, "AI 添加批注", delegate
			{
				Comments comments = CS_8_locals_12.doc.Comments;
				Range range = CS_8_locals_12.QVSWWNpqS5;
				object Text = CS_8_locals_12.NcsW0mbLbI.iYMWq6x2ON.Trim();
				Comment comment = comments.Add(range, ref Text);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("commentText must not be empty.", WWcgsjc2XU(CS_8_locals_12.doc, CS_8_locals_12.QVSWWNpqS5, comment.Index, CS_8_locals_12.NcsW0mbLbI.iYMWq6x2ON));
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_1
	{
		public Document doc;

		public Range QVSWWNpqS5;

		public _G_c__DisplayClass30_0 NcsW0mbLbI;

		public _G_c__DisplayClass30_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU AThWv3d2sZ()
		{
			Comments comments = doc.Comments;
			Range range = QVSWWNpqS5;
			object Text = NcsW0mbLbI.iYMWq6x2ON.Trim();
			Comment comment = comments.Add(range, ref Text);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word comment added.", WWcgsjc2XU(doc, QVSWWNpqS5, comment.Index, NcsW0mbLbI.iYMWq6x2ON));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass31_0
	{
		public string JbiWxBXGfL;

		public int rNUWdaMass;

		public int r75WzWXpYy;

		public int FYo0RQ60pr;

		public _G_c__DisplayClass31_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU DepWkJtShM(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass31_1 CS_8_locals_12 = new _G_c__DisplayClass31_1();
			CS_8_locals_12.JKv09xg9ic = this;
			if (string.IsNullOrWhiteSpace(JbiWxBXGfL))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("commentText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_12.doc = ca8TtvS05W(app);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = JXpTldftkV(CS_8_locals_12.doc, rNUWdaMass, r75WzWXpYy, FYo0RQ60pr, out CS_8_locals_12.oo50BXZjWO);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = Q7Sg1pThfx(app, CS_8_locals_12.doc, CS_8_locals_12.oo50BXZjWO);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			return oBKTTgZY41(app, "AI 添加批注", delegate
			{
				Comments comments = CS_8_locals_12.doc.Comments;
				Range range = CS_8_locals_12.oo50BXZjWO;
				object Text = CS_8_locals_12.JKv09xg9ic.JbiWxBXGfL.Trim();
				Comment comment = comments.Add(range, ref Text);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("commentText must not be empty.", WWcgsjc2XU(CS_8_locals_12.doc, CS_8_locals_12.oo50BXZjWO, comment.Index, CS_8_locals_12.JKv09xg9ic.JbiWxBXGfL));
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass31_1
	{
		public Document doc;

		public Range oo50BXZjWO;

		public _G_c__DisplayClass31_0 JKv09xg9ic;

		public _G_c__DisplayClass31_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU Kuo0VVMmDG()
		{
			Comments comments = doc.Comments;
			Range range = oo50BXZjWO;
			object Text = JKv09xg9ic.JbiWxBXGfL.Trim();
			Comment comment = comments.Add(range, ref Text);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word comment added.", WWcgsjc2XU(doc, oo50BXZjWO, comment.Index, JKv09xg9ic.JbiWxBXGfL));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass32_0
	{
		public string Plj0uww7Lb;

		public int yl70DLkIZI;

		public int MVT0TM4BqQ;

		public int lDB0gUfIHi;

		public _G_c__DisplayClass32_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU wob06LXnvF(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass32_1 CS_8_locals_19 = new _G_c__DisplayClass32_1();
			CS_8_locals_19.qQI0ilX6hg = this;
			if (string.IsNullOrWhiteSpace(Plj0uww7Lb))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("commentText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_19.doc = ca8TtvS05W(app);
			CS_8_locals_19.U3N0IvjZMn = DOQTmyyLCk(CS_8_locals_19.doc, yl70DLkIZI, MVT0TM4BqQ, lDB0gUfIHi);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = Q7Sg1pThfx(app, CS_8_locals_19.doc, CS_8_locals_19.U3N0IvjZMn.Range);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			return oBKTTgZY41(app, "AI 添加表格批注", delegate
			{
				Comments comments = CS_8_locals_19.doc.Comments;
				Range range = CS_8_locals_19.U3N0IvjZMn.Range;
				object Text = CS_8_locals_19.qQI0ilX6hg.Plj0uww7Lb.Trim();
				Comment comment = comments.Add(range, ref Text);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("commentText must not be empty.", new
				{
					document = CS_8_locals_19.doc.Name,
					documentFullName = CS_8_locals_19.doc.FullName,
					commentIndex = comment.Index,
					tableIndex = CS_8_locals_19.qQI0ilX6hg.yl70DLkIZI,
					rowIndex = CS_8_locals_19.qQI0ilX6hg.MVT0TM4BqQ,
					columnIndex = CS_8_locals_19.qQI0ilX6hg.lDB0gUfIHi,
					page = Y878QfFgDa(CS_8_locals_19.U3N0IvjZMn.Range),
					rangeStart = CS_8_locals_19.U3N0IvjZMn.Range.Start,
					rangeEnd = CS_8_locals_19.U3N0IvjZMn.Range.End,
					targetPreview = rYN8Y355we(Pfn84MVBvM(CS_8_locals_19.U3N0IvjZMn.Range.Text), 240),
					comment = CS_8_locals_19.qQI0ilX6hg.Plj0uww7Lb.Trim()
				});
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass32_1
	{
		public Document doc;

		public Cell U3N0IvjZMn;

		public _G_c__DisplayClass32_0 qQI0ilX6hg;

		public _G_c__DisplayClass32_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU Sv108Qb7Cd()
		{
			Comments comments = doc.Comments;
			Range range = U3N0IvjZMn.Range;
			object Text = qQI0ilX6hg.Plj0uww7Lb.Trim();
			Comment comment = comments.Add(range, ref Text);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word table cell comment added.", new
			{
				document = doc.Name,
				documentFullName = doc.FullName,
				commentIndex = comment.Index,
				tableIndex = qQI0ilX6hg.yl70DLkIZI,
				rowIndex = qQI0ilX6hg.MVT0TM4BqQ,
				columnIndex = qQI0ilX6hg.lDB0gUfIHi,
				page = Y878QfFgDa(U3N0IvjZMn.Range),
				rangeStart = U3N0IvjZMn.Range.Start,
				rangeEnd = U3N0IvjZMn.Range.End,
				targetPreview = rYN8Y355we(Pfn84MVBvM(U3N0IvjZMn.Range.Text), 240),
				comment = qQI0ilX6hg.Plj0uww7Lb.Trim()
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass33_0
	{
		public int VVi0Qol0Kp;

		public string li901Ehx74;

		public string T0P0rR1iC0;

		public bool M430JdWIcm;

		public _G_c__DisplayClass33_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU N8e0HwJOd6(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass33_1 CS_8_locals_32 = new _G_c__DisplayClass33_1();
			CS_8_locals_32.ilr02ghHeZ = this;
			CS_8_locals_32.doc = ca8TtvS05W(app);
			CS_8_locals_32.tKg0UkP7mM = U09ToZPpqq(CS_8_locals_32.doc, VVi0Qol0Kp);
			CS_8_locals_32.it80KSGhhX = (li901Ehx74 ?? "after").Trim().ToLowerInvariant();
			if (CS_8_locals_32.it80KSGhhX != "before" && CS_8_locals_32.it80KSGhhX != "after")
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("position 只支持 before 或 after。", "invalid_arguments", new
				{
					position = li901Ehx74
				});
			}
			CS_8_locals_32.JMl0EihMlK = T0P0rR1iC0 ?? string.Empty;
			return PPXTOUDVLE(CS_8_locals_32.doc, M430JdWIcm, delegate
			{
				Range duplicate = CS_8_locals_32.tKg0UkP7mM.Range.Duplicate;
				if (CS_8_locals_32.it80KSGhhX == "AI 插入段落")
				{
					int start = duplicate.Start;
					object Direction = WdCollapseDirection.wdCollapseStart;
					duplicate.Collapse(ref Direction);
					duplicate.InsertBefore(CS_8_locals_32.JMl0EihMlK + "after");
					return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("before", new
					{
						document = CS_8_locals_32.doc.Name,
						documentFullName = CS_8_locals_32.doc.FullName,
						paragraphIndex = CS_8_locals_32.ilr02ghHeZ.VVi0Qol0Kp,
						position = CS_8_locals_32.it80KSGhhX,
						page = Y878QfFgDa(CS_8_locals_32.tKg0UkP7mM.Range),
						rangeStart = start,
						useTrackChanges = CS_8_locals_32.ilr02ghHeZ.M430JdWIcm,
						characters = CS_8_locals_32.JMl0EihMlK.Length,
						textPreview = rYN8Y355we(CS_8_locals_32.JMl0EihMlK, 240)
					});
				}
				int num = Math.Max(CS_8_locals_32.tKg0UkP7mM.Range.Start, CS_8_locals_32.tKg0UkP7mM.Range.End - 1);
				duplicate.SetRange(num, num);
				duplicate.InsertAfter("after" + CS_8_locals_32.JMl0EihMlK);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("position 只支持 before 或 after。", new
				{
					document = CS_8_locals_32.doc.Name,
					documentFullName = CS_8_locals_32.doc.FullName,
					paragraphIndex = CS_8_locals_32.ilr02ghHeZ.VVi0Qol0Kp,
					position = CS_8_locals_32.it80KSGhhX,
					page = Y878QfFgDa(CS_8_locals_32.tKg0UkP7mM.Range),
					rangeStart = num,
					useTrackChanges = CS_8_locals_32.ilr02ghHeZ.M430JdWIcm,
					characters = CS_8_locals_32.JMl0EihMlK.Length,
					textPreview = rYN8Y355we(CS_8_locals_32.JMl0EihMlK, 240)
				});
			}, app, CS_8_locals_32.tKg0UkP7mM.Range, "invalid_arguments");
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass33_1
	{
		public Paragraph tKg0UkP7mM;

		public string it80KSGhhX;

		public string JMl0EihMlK;

		public Document doc;

		public _G_c__DisplayClass33_0 ilr02ghHeZ;

		public _G_c__DisplayClass33_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU Ejw03pJKh6()
		{
			Range duplicate = tKg0UkP7mM.Range.Duplicate;
			if (it80KSGhhX == "before")
			{
				int start = duplicate.Start;
				object Direction = WdCollapseDirection.wdCollapseStart;
				duplicate.Collapse(ref Direction);
				duplicate.InsertBefore(JMl0EihMlK + "\\r");
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word paragraph inserted.", new
				{
					document = doc.Name,
					documentFullName = doc.FullName,
					paragraphIndex = ilr02ghHeZ.VVi0Qol0Kp,
					position = it80KSGhhX,
					page = Y878QfFgDa(tKg0UkP7mM.Range),
					rangeStart = start,
					useTrackChanges = ilr02ghHeZ.M430JdWIcm,
					characters = JMl0EihMlK.Length,
					textPreview = rYN8Y355we(JMl0EihMlK, 240)
				});
			}
			int num = Math.Max(tKg0UkP7mM.Range.Start, tKg0UkP7mM.Range.End - 1);
			duplicate.SetRange(num, num);
			duplicate.InsertAfter("\\r" + JMl0EihMlK);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word paragraph inserted.", new
			{
				document = doc.Name,
				documentFullName = doc.FullName,
				paragraphIndex = ilr02ghHeZ.VVi0Qol0Kp,
				position = it80KSGhhX,
				page = Y878QfFgDa(tKg0UkP7mM.Range),
				rangeStart = num,
				useTrackChanges = ilr02ghHeZ.M430JdWIcm,
				characters = JMl0EihMlK.Length,
				textPreview = rYN8Y355we(JMl0EihMlK, 240)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass34_0
	{
		public int VSY0j7rVLY;

		public int rIb0YiqNvi;

		public int tBl0ZKmmgV;

		public _G_c__DisplayClass34_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU NXo046wf4s(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass34_1 CS_8_locals_29 = new _G_c__DisplayClass34_1();
			CS_8_locals_29.ENA0sjUILf = this;
			if (VSY0j7rVLY < 0 || VSY0j7rVLY > 9)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("outlineLevel 必须为 0..9；0 表示正文，1..9 表示标题级次。", "invalid_arguments", new
				{
					outlineLevel = VSY0j7rVLY
				});
			}
			if (rIb0YiqNvi < 0 || tBl0ZKmmgV < 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("startParagraphIndex 和 endParagraphIndex 不能为负数。", "invalid_arguments", new
				{
					startParagraphIndex = rIb0YiqNvi,
					endParagraphIndex = tBl0ZKmmgV
				});
			}
			if (rIb0YiqNvi == 0 && tBl0ZKmmgV > 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("startParagraphIndex=0 表示当前选区，此时 endParagraphIndex 必须为 0。", "invalid_arguments", new
				{
					startParagraphIndex = rIb0YiqNvi,
					endParagraphIndex = tBl0ZKmmgV
				});
			}
			if (rIb0YiqNvi > 0 && tBl0ZKmmgV > 0 && tBl0ZKmmgV < rIb0YiqNvi)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("endParagraphIndex must be greater than or equal to startParagraphIndex.", "invalid_arguments", new
				{
					startParagraphIndex = rIb0YiqNvi,
					endParagraphIndex = tBl0ZKmmgV
				});
			}
			CS_8_locals_29.doc = ca8TtvS05W(app);
			CS_8_locals_29.doc.Activate();
			int num = Y1x8gkTvcF(() => CS_8_locals_29.doc.Paragraphs.Count);
			if (rIb0YiqNvi > num)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("startParagraphIndex is out of range.", "invalid_arguments", new
				{
					startParagraphIndex = rIb0YiqNvi,
					totalParagraphs = num
				});
			}
			if (tBl0ZKmmgV > num)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("endParagraphIndex is out of range.", "invalid_arguments", new
				{
					endParagraphIndex = tBl0ZKmmgV,
					totalParagraphs = num
				});
			}
			CS_8_locals_29.tt60bBXNOI = FMtTCCF91i(app, CS_8_locals_29.doc, rIb0YiqNvi, tBl0ZKmmgV);
			if (CS_8_locals_29.tt60bBXNOI.Count == 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前没有可设置大纲级次的段落。", "no_paragraph_selection", new
				{
					startParagraphIndex = rIb0YiqNvi,
					endParagraphIndex = tBl0ZKmmgV
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = Q7Sg1pThfx(app, CS_8_locals_29.doc, CS_8_locals_29.tt60bBXNOI[0].Paragraph.Range);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			CS_8_locals_29.wKn0SWcs43 = PZD8ivf3BX(VSY0j7rVLY);
			CS_8_locals_29.r4c0LaglLY = new List<object>();
			CS_8_locals_29.YFL0wKX8uQ = 0;
			CS_8_locals_29.AHE0tweHQB = 0;
			DyITDXSmDr(app, "AI 设置段落大纲级次", delegate
			{
				foreach (WKGvoki3QLNecqlT5em item in CS_8_locals_29.tt60bBXNOI)
				{
					Paragraph paragraph = item.Paragraph;
					int num2 = cjC8ImVBAy(fSO88F0gne(paragraph));
					string styleName = kBH8HcK06n(paragraph);
					string excerpt = rYN8Y355we(Pfn84MVBvM(paragraph.Range.Text), 160);
					bool flag = false;
					bool flag2 = false;
					string text = string.Empty;
					try
					{
						paragraph.OutlineLevel = (WdOutlineLevel)CS_8_locals_29.wKn0SWcs43;
						int num3 = cjC8ImVBAy(fSO88F0gne(paragraph));
						flag2 = num3 == CS_8_locals_29.ENA0sjUILf.VSY0j7rVLY;
						flag = flag2 && num2 != num3;
						if (!flag2)
						{
							text = "heading";
						}
					}
					catch (Exception ex)
					{
						text = ex.GetBaseException().Message;
					}
					int afterOutlineLevel = cjC8ImVBAy(fSO88F0gne(paragraph));
					if (flag)
					{
						CS_8_locals_29.YFL0wKX8uQ++;
					}
					if (!flag2)
					{
						CS_8_locals_29.AHE0tweHQB++;
					}
					CS_8_locals_29.r4c0LaglLY.Add(new
					{
						paragraphIndex = item.ParagraphIndex,
						rangeStart = paragraph.Range.Start,
						rangeEnd = paragraph.Range.End,
						page = Y878QfFgDa(paragraph.Range),
						styleName = styleName,
						beforeOutlineLevel = num2,
						targetOutlineLevel = CS_8_locals_29.ENA0sjUILf.VSY0j7rVLY,
						afterOutlineLevel = afterOutlineLevel,
						changed = flag,
						success = flag2,
						error = (string.IsNullOrWhiteSpace(text) ? null : text),
						excerpt = excerpt
					});
				}
			});
			var anon = new
			{
				document = CS_8_locals_29.doc.Name,
				documentFullName = CS_8_locals_29.doc.FullName,
				startParagraphIndex = rIb0YiqNvi,
				endParagraphIndex = tBl0ZKmmgV,
				targetOutlineLevel = VSY0j7rVLY,
				targetOutlineKind = ((VSY0j7rVLY == 0) ? "body" : "未能设置任何段落的大纲级次。"),
				totalParagraphs = CS_8_locals_29.tt60bBXNOI.Count,
				changedCount = CS_8_locals_29.YFL0wKX8uQ,
				failedCount = CS_8_locals_29.AHE0tweHQB,
				paragraphs = CS_8_locals_29.r4c0LaglLY
			};
			if (CS_8_locals_29.AHE0tweHQB == CS_8_locals_29.tt60bBXNOI.Count)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("outline_level_not_applied", "Word paragraph outline level updated.", anon);
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m((CS_8_locals_29.AHE0tweHQB > 0) ? "Word paragraph outline level updated with failures." : "outlineLevel 必须为 0..9；0 表示正文，1..9 表示标题级次。", anon);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass34_1
	{
		public Document doc;

		public List<WKGvoki3QLNecqlT5em> tt60bBXNOI;

		public int wKn0SWcs43;

		public int YFL0wKX8uQ;

		public int AHE0tweHQB;

		public List<object> r4c0LaglLY;

		public _G_c__DisplayClass34_0 ENA0sjUILf;

		public _G_c__DisplayClass34_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int sEA0fDkRmU()
		{
			return doc.Paragraphs.Count;
		}

		internal void q5P0M39Utk()
		{
			foreach (WKGvoki3QLNecqlT5em item in tt60bBXNOI)
			{
				Paragraph paragraph = item.Paragraph;
				int num = cjC8ImVBAy(fSO88F0gne(paragraph));
				string styleName = kBH8HcK06n(paragraph);
				string excerpt = rYN8Y355we(Pfn84MVBvM(paragraph.Range.Text), 160);
				bool flag = false;
				bool flag2 = false;
				string text = string.Empty;
				try
				{
					paragraph.OutlineLevel = (WdOutlineLevel)wKn0SWcs43;
					int num2 = cjC8ImVBAy(fSO88F0gne(paragraph));
					flag2 = num2 == ENA0sjUILf.VSY0j7rVLY;
					flag = flag2 && num != num2;
					if (!flag2)
					{
						text = "无法直接调整该段落的大纲级次，可能受段落样式限制。";
					}
				}
				catch (Exception ex)
				{
					text = ex.GetBaseException().Message;
				}
				int afterOutlineLevel = cjC8ImVBAy(fSO88F0gne(paragraph));
				if (flag)
				{
					YFL0wKX8uQ++;
				}
				if (!flag2)
				{
					AHE0tweHQB++;
				}
				r4c0LaglLY.Add(new
				{
					paragraphIndex = item.ParagraphIndex,
					rangeStart = paragraph.Range.Start,
					rangeEnd = paragraph.Range.End,
					page = Y878QfFgDa(paragraph.Range),
					styleName = styleName,
					beforeOutlineLevel = num,
					targetOutlineLevel = ENA0sjUILf.VSY0j7rVLY,
					afterOutlineLevel = afterOutlineLevel,
					changed = flag,
					success = flag2,
					error = (string.IsNullOrWhiteSpace(text) ? null : text),
					excerpt = excerpt
				});
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass35_0
	{
		public string U3X0Nu9BTy;

		public string e950mqvdUW;

		public string Mb30oMnlMg;

		public int sVt0G0vaxH;

		public int hBZ0CqvlP0;

		public bool ftr0pKNh6J;

		public bool Pnj0OjaV8W;

		public _G_c__DisplayClass35_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU cSF0leaRoM(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass35_1 CS_8_locals_41 = new _G_c__DisplayClass35_1();
			CS_8_locals_41.EqE0cr5Iep = this;
			string a = (U3X0Nu9BTy ?? "preview").Trim().ToLowerInvariant();
			if (!string.Equals(a, "preview", StringComparison.Ordinal) && !string.Equals(a, "execute", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("mode 仅支持 preview 或 execute。", "invalid_arguments", new
				{
					mode = U3X0Nu9BTy
				});
			}
			if (string.Equals(a, "execute", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(e950mqvdUW))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("执行模型填表前必须先调用 mode=preview，并把 previewToken 传入 execute。", "preview_required");
			}
			List<OGfXaqipg6f7TvJ8dbc> list;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = XIPTkGpqwW(Mb30oMnlMg, out list);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			CS_8_locals_41.doc = ca8TtvS05W(app);
			Range range;
			try
			{
				range = fyVTLmFfU6(CS_8_locals_41.doc, sVt0G0vaxH, hBZ0CqvlP0);
			}
			catch (Exception ex)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("rangeStart/rangeEnd 超出文档范围或顺序无效。", "invalid_arguments", new
				{
					rangeStart = sVt0G0vaxH,
					rangeEnd = hBZ0CqvlP0,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = yC3TxlssVj(range, list, out CS_8_locals_41.NsB07pVikL);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_41.T7P05P0rNv = EW0g9hbK9x(CS_8_locals_41.doc, sVt0G0vaxH, hBZ0CqvlP0, CS_8_locals_41.NsB07pVikL);
			object obj = iLJTdpgWxW(CS_8_locals_41.doc, sVt0G0vaxH, hBZ0CqvlP0, ftr0pKNh6J, Pnj0OjaV8W, CS_8_locals_41.T7P05P0rNv, CS_8_locals_41.NsB07pVikL);
			if (string.Equals(a, "preview", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Model table cell fill preview prepared.", obj);
			}
			if (CS_8_locals_41.NsB07pVikL.Count((ICsQGCih5R8sKlcw64k change) => !change.Writable) > 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前填表请求中存在不可写单元格，已停止执行。请根据 preview 结果修正后重试。", "model_cell_not_writable", obj);
			}
			if (!mx2g6RGYxJ(CS_8_locals_41.T7P05P0rNv, e950mqvdUW))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前表格旧值或坐标与预览结果不一致，已停止执行。请重新 preview 后再 execute。", "preview_mismatch", new
				{
					rangeStart = sVt0G0vaxH,
					rangeEnd = hBZ0CqvlP0,
					expectedPreviewToken = e950mqvdUW,
					currentPreviewToken = CS_8_locals_41.T7P05P0rNv,
					preview = obj
				});
			}
			Range range2 = ((CS_8_locals_41.NsB07pVikL.Count > 0 && CS_8_locals_41.NsB07pVikL[0].Cell != null) ? NPITpB49xY(CS_8_locals_41.NsB07pVikL[0].Cell) : range);
			return PPXTOUDVLE(CS_8_locals_41.doc, Pnj0OjaV8W, delegate
			{
				List<object> list2 = new List<object>();
				int num = 0;
				for (int i = 0; i < CS_8_locals_41.NsB07pVikL.Count; i++)
				{
					_G_c__DisplayClass35_2 CS_8_locals_43 = new _G_c__DisplayClass35_2();
					CS_8_locals_43.T5O0X047np = CS_8_locals_41.NsB07pVikL[i];
					bool flag2;
					string text;
					bool flag = bIRgTubXiW(CS_8_locals_43.T5O0X047np.Cell, CS_8_locals_43.T5O0X047np.NewText, out flag2, out text);
					if (flag && flag2)
					{
						num++;
					}
					list2.Add(new
					{
						requestIndex = CS_8_locals_43.T5O0X047np.RequestIndex,
						localTableIndex = CS_8_locals_43.T5O0X047np.LocalTableIndex,
						rowIndex = CS_8_locals_43.T5O0X047np.RowIndex,
						columnIndex = CS_8_locals_43.T5O0X047np.ColumnIndex,
						isHeader = CS_8_locals_43.T5O0X047np.IsHeader,
						page = Y878QfFgDa(CS_8_locals_43.T5O0X047np.Cell.Range),
						rangeStart = Ex5TMxi7X1(() => CS_8_locals_43.T5O0X047np.Cell.Range.Start, CS_8_locals_43.T5O0X047np.RangeStart),
						rangeEnd = Ex5TMxi7X1(() => CS_8_locals_43.T5O0X047np.Cell.Range.End, CS_8_locals_43.T5O0X047np.RangeEnd),
						oldText = CS_8_locals_43.T5O0X047np.OldText,
						newText = CS_8_locals_43.T5O0X047np.NewText,
						changed = (flag && flag2),
						success = flag,
						error = (flag ? null : text)
					});
				}
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("AI 模型填表", new
				{
					document = CS_8_locals_41.doc.Name,
					documentFullName = CS_8_locals_41.doc.FullName,
					rangeStart = CS_8_locals_41.EqE0cr5Iep.sVt0G0vaxH,
					rangeEnd = CS_8_locals_41.EqE0cr5Iep.hBZ0CqvlP0,
					totalRequests = CS_8_locals_41.NsB07pVikL.Count,
					changed = num,
					useTrackChanges = CS_8_locals_41.EqE0cr5Iep.Pnj0OjaV8W,
					allowHeaderEdit = CS_8_locals_41.EqE0cr5Iep.ftr0pKNh6J,
					previewToken = CS_8_locals_41.T7P05P0rNv,
					results = list2
				});
			}, app, range2, "preview");
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass35_1
	{
		public List<ICsQGCih5R8sKlcw64k> NsB07pVikL;

		public Document doc;

		public string T7P05P0rNv;

		public _G_c__DisplayClass35_0 EqE0cr5Iep;

		public _G_c__DisplayClass35_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU b5n0nHZco5()
		{
			List<object> list = new List<object>();
			int num = 0;
			for (int i = 0; i < NsB07pVikL.Count; i++)
			{
				_G_c__DisplayClass35_2 CS_8_locals_15 = new _G_c__DisplayClass35_2();
				CS_8_locals_15.T5O0X047np = NsB07pVikL[i];
				bool flag2;
				string text;
				bool flag = bIRgTubXiW(CS_8_locals_15.T5O0X047np.Cell, CS_8_locals_15.T5O0X047np.NewText, out flag2, out text);
				if (flag && flag2)
				{
					num++;
				}
				list.Add(new
				{
					requestIndex = CS_8_locals_15.T5O0X047np.RequestIndex,
					localTableIndex = CS_8_locals_15.T5O0X047np.LocalTableIndex,
					rowIndex = CS_8_locals_15.T5O0X047np.RowIndex,
					columnIndex = CS_8_locals_15.T5O0X047np.ColumnIndex,
					isHeader = CS_8_locals_15.T5O0X047np.IsHeader,
					page = Y878QfFgDa(CS_8_locals_15.T5O0X047np.Cell.Range),
					rangeStart = Ex5TMxi7X1(() => CS_8_locals_15.T5O0X047np.Cell.Range.Start, CS_8_locals_15.T5O0X047np.RangeStart),
					rangeEnd = Ex5TMxi7X1(() => CS_8_locals_15.T5O0X047np.Cell.Range.End, CS_8_locals_15.T5O0X047np.RangeEnd),
					oldText = CS_8_locals_15.T5O0X047np.OldText,
					newText = CS_8_locals_15.T5O0X047np.NewText,
					changed = (flag && flag2),
					success = flag,
					error = (flag ? null : text)
				});
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Model table cell fill executed.", new
			{
				document = doc.Name,
				documentFullName = doc.FullName,
				rangeStart = EqE0cr5Iep.sVt0G0vaxH,
				rangeEnd = EqE0cr5Iep.hBZ0CqvlP0,
				totalRequests = NsB07pVikL.Count,
				changed = num,
				useTrackChanges = EqE0cr5Iep.Pnj0OjaV8W,
				allowHeaderEdit = EqE0cr5Iep.ftr0pKNh6J,
				previewToken = T7P05P0rNv,
				results = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass35_2
	{
		public ICsQGCih5R8sKlcw64k T5O0X047np;

		public _G_c__DisplayClass35_2()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int DV80e35QH6()
		{
			return T5O0X047np.Cell.Range.Start;
		}

		internal int qLj0y5lR4s()
		{
			return T5O0X047np.Cell.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass36_0
	{
		public string oqq0hsqqAI;

		public string skx0ahCXbo;

		public int us70qblyBW;

		public string svA0P2EZkb;

		public int YXU0AnhhVg;

		public int PEy0vuw4bd;

		public int emx0WPoKaL;

		public int ivn00MgJWx;

		public bool MyU0kcBnLJ;

		public string NcM0xJMhM5;

		public _G_c__DisplayClass36_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU iMN0FWlS3B(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass36_1 CS_8_locals_42 = new _G_c__DisplayClass36_1();
			CS_8_locals_42.gZUkBpLoZF = this;
			CS_8_locals_42.F6s0zNQf7g = app;
			string a = (oqq0hsqqAI ?? "preview").Trim().ToLowerInvariant();
			if (!string.Equals(a, "preview", StringComparison.Ordinal) && !string.Equals(a, "execute", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("mode 仅支持 preview 或 execute。", "invalid_arguments", new
				{
					mode = oqq0hsqqAI
				});
			}
			string text = vq0TXPC0AY(skx0ahCXbo);
			if (text == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("position 仅支持 before 或 after。", "invalid_arguments", new
				{
					position = skx0ahCXbo
				});
			}
			if (us70qblyBW < 1 || us70qblyBW > 20)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("count 必须在 1 到 20 之间。", "invalid_arguments", new
				{
					count = us70qblyBW,
					min = 1,
					max = 20
				});
			}
			if (string.Equals(a, "execute", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(svA0P2EZkb))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("执行模型表格插行前必须先调用 mode=preview，并把 previewToken 传入 execute。", "preview_required");
			}
			CS_8_locals_42.doc = ca8TtvS05W(CS_8_locals_42.F6s0zNQf7g);
			Range range;
			try
			{
				range = fyVTLmFfU6(CS_8_locals_42.doc, YXU0AnhhVg, PEy0vuw4bd);
			}
			catch (Exception ex)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("rangeStart/rangeEnd 超出文档范围或顺序无效。", "invalid_arguments", new
				{
					rangeStart = YXU0AnhhVg,
					rangeEnd = PEy0vuw4bd,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = NioTFK99GE(range, emx0WPoKaL, ivn00MgJWx, text, us70qblyBW, MyU0kcBnLJ, NcM0xJMhM5, out CS_8_locals_42.TGIkR4H0Wl);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			CS_8_locals_42.g0ikVawc3w = lKeTPQlpbN(CS_8_locals_42.doc, YXU0AnhhVg, PEy0vuw4bd, CS_8_locals_42.TGIkR4H0Wl);
			object obj = fYyThhstYU(CS_8_locals_42.doc, YXU0AnhhVg, PEy0vuw4bd, CS_8_locals_42.g0ikVawc3w, CS_8_locals_42.TGIkR4H0Wl);
			if (string.Equals(a, "preview", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Model table row insert preview prepared.", obj);
			}
			if (!mx2g6RGYxJ(CS_8_locals_42.g0ikVawc3w, svA0P2EZkb))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前表格锚点或结构与预览结果不一致，已停止执行。请重新 preview 后再 execute。", "preview_mismatch", new
				{
					rangeStart = YXU0AnhhVg,
					rangeEnd = PEy0vuw4bd,
					expectedPreviewToken = svA0P2EZkb,
					currentPreviewToken = CS_8_locals_42.g0ikVawc3w,
					preview = obj
				});
			}
			return PPXTOUDVLE(CS_8_locals_42.doc, MyU0kcBnLJ, delegate
			{
				if (!M4PTA9V6B2(CS_8_locals_42.F6s0zNQf7g, CS_8_locals_42.TGIkR4H0Wl.AnchorCell, CS_8_locals_42.TGIkR4H0Wl.Position, CS_8_locals_42.TGIkR4H0Wl.Count, out var error))
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("AI 表格插行", "preview", new
					{
						rangeStart = CS_8_locals_42.gZUkBpLoZF.YXU0AnhhVg,
						rangeEnd = CS_8_locals_42.gZUkBpLoZF.PEy0vuw4bd,
						LocalTableIndex = CS_8_locals_42.TGIkR4H0Wl.LocalTableIndex,
						AnchorRowIndex = CS_8_locals_42.TGIkR4H0Wl.AnchorRowIndex,
						Position = CS_8_locals_42.TGIkR4H0Wl.Position,
						Count = CS_8_locals_42.TGIkR4H0Wl.Count,
						error = error
					});
				}
				HbPTWYrAup(CS_8_locals_42.TGIkR4H0Wl.Table, out var rowsAfter, out var columnsAfter);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("preview", new
				{
					document = CS_8_locals_42.doc.Name,
					documentFullName = CS_8_locals_42.doc.FullName,
					rangeStart = CS_8_locals_42.gZUkBpLoZF.YXU0AnhhVg,
					rangeEnd = CS_8_locals_42.gZUkBpLoZF.PEy0vuw4bd,
					localTableIndex = CS_8_locals_42.TGIkR4H0Wl.LocalTableIndex,
					anchorRowIndex = CS_8_locals_42.TGIkR4H0Wl.AnchorRowIndex,
					position = CS_8_locals_42.TGIkR4H0Wl.Position,
					count = CS_8_locals_42.TGIkR4H0Wl.Count,
					useTrackChanges = CS_8_locals_42.gZUkBpLoZF.MyU0kcBnLJ,
					previewToken = CS_8_locals_42.g0ikVawc3w,
					rowsBefore = CS_8_locals_42.TGIkR4H0Wl.RowsBefore,
					rowsAfter = rowsAfter,
					columnsBefore = CS_8_locals_42.TGIkR4H0Wl.ColumnsBefore,
					columnsAfter = columnsAfter,
					insertedRows = h6ATqqIsId(CS_8_locals_42.TGIkR4H0Wl),
					anchor = emITal7V84(CS_8_locals_42.TGIkR4H0Wl)
				});
			}, CS_8_locals_42.F6s0zNQf7g, CS_8_locals_42.TGIkR4H0Wl.AnchorCell.Range, "execute");
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass36_1
	{
		public Microsoft.Office.Interop.Word.Application F6s0zNQf7g;

		public cdmxD7HD8upDSKfXwCW TGIkR4H0Wl;

		public Document doc;

		public string g0ikVawc3w;

		public _G_c__DisplayClass36_0 gZUkBpLoZF;

		public _G_c__DisplayClass36_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU rWf0dZFnIS()
		{
			if (!M4PTA9V6B2(F6s0zNQf7g, TGIkR4H0Wl.AnchorCell, TGIkR4H0Wl.Position, TGIkR4H0Wl.Count, out var error))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格插行失败。", "table_row_insert_failed", new
				{
					rangeStart = gZUkBpLoZF.YXU0AnhhVg,
					rangeEnd = gZUkBpLoZF.PEy0vuw4bd,
					LocalTableIndex = TGIkR4H0Wl.LocalTableIndex,
					AnchorRowIndex = TGIkR4H0Wl.AnchorRowIndex,
					Position = TGIkR4H0Wl.Position,
					Count = TGIkR4H0Wl.Count,
					error = error
				});
			}
			HbPTWYrAup(TGIkR4H0Wl.Table, out var rowsAfter, out var columnsAfter);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Model table row insert executed.", new
			{
				document = doc.Name,
				documentFullName = doc.FullName,
				rangeStart = gZUkBpLoZF.YXU0AnhhVg,
				rangeEnd = gZUkBpLoZF.PEy0vuw4bd,
				localTableIndex = TGIkR4H0Wl.LocalTableIndex,
				anchorRowIndex = TGIkR4H0Wl.AnchorRowIndex,
				position = TGIkR4H0Wl.Position,
				count = TGIkR4H0Wl.Count,
				useTrackChanges = gZUkBpLoZF.MyU0kcBnLJ,
				previewToken = g0ikVawc3w,
				rowsBefore = TGIkR4H0Wl.RowsBefore,
				rowsAfter = rowsAfter,
				columnsBefore = TGIkR4H0Wl.ColumnsBefore,
				columnsAfter = columnsAfter,
				insertedRows = h6ATqqIsId(TGIkR4H0Wl),
				anchor = emITal7V84(TGIkR4H0Wl)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass37_0
	{
		public string xhnk6qWUAD;

		public string tBmkugaqPB;

		public int fnLkDwNHkT;

		public int FAJkTvvVfq;

		public string hIEkg4lPZD;

		public int N8Ik89nA2y;

		public int FHWkIpxSEj;

		public bool tWBkiSc1VI;

		public bool jdmkHkXOfG;

		public _G_c__DisplayClass37_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU rekk9BCohq(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass37_1 CS_8_locals_48 = new _G_c__DisplayClass37_1();
			CS_8_locals_48.SsLkJG4LDE = this;
			string a = (xhnk6qWUAD ?? "preview").Trim().ToLowerInvariant();
			if (!string.Equals(a, "preview", StringComparison.Ordinal) && !string.Equals(a, "execute", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("mode 仅支持 preview 或 execute。", "invalid_arguments", new
				{
					mode = xhnk6qWUAD
				});
			}
			string text = LvkTnN0GBt(tBmkugaqPB);
			if (text == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("placement 仅支持 replace_empty_paragraph、before 或 after。", "invalid_arguments", new
				{
					placement = tBmkugaqPB
				});
			}
			if (fnLkDwNHkT < 1 || fnLkDwNHkT > 200)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("rows 必须在 1 到 200 之间。", "invalid_arguments", new
				{
					rows = fnLkDwNHkT,
					min = 1,
					max = 200
				});
			}
			if (FAJkTvvVfq < 1 || FAJkTvvVfq > 63)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("columns 必须在 1 到 63 之间。", "invalid_arguments", new
				{
					columns = FAJkTvvVfq,
					min = 1,
					max = 63
				});
			}
			if (string.Equals(a, "execute", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(hIEkg4lPZD))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("执行插入表格前必须先调用 mode=preview，并把 previewToken 传入 execute。", "preview_required");
			}
			CS_8_locals_48.doc = ca8TtvS05W(app);
			Range range;
			try
			{
				range = k5cTsYBg89(CS_8_locals_48.doc, N8Ik89nA2y, FHWkIpxSEj);
			}
			catch (Exception ex)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("rangeStart/rangeEnd 超出文档范围或顺序无效。", "invalid_arguments", new
				{
					rangeStart = N8Ik89nA2y,
					rangeEnd = FHWkIpxSEj,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = CofT7m3Hd8(CS_8_locals_48.doc, range, fnLkDwNHkT, FAJkTvvVfq, text, tWBkiSc1VI, jdmkHkXOfG, out CS_8_locals_48.yvek1TO5he);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			CS_8_locals_48.jhNkrgvp5I = BIJTcpAmqJ(CS_8_locals_48.doc, N8Ik89nA2y, FHWkIpxSEj, CS_8_locals_48.yvek1TO5he);
			object obj = XayT5NOjBp(CS_8_locals_48.doc, N8Ik89nA2y, FHWkIpxSEj, CS_8_locals_48.jhNkrgvp5I, CS_8_locals_48.yvek1TO5he);
			if (string.Equals(a, "preview", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word table insert preview prepared.", obj);
			}
			if (!mx2g6RGYxJ(CS_8_locals_48.jhNkrgvp5I, hIEkg4lPZD))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前插表位置与预览结果不一致，已停止执行。请重新 preview 后再 execute。", "preview_mismatch", new
				{
					rangeStart = N8Ik89nA2y,
					rangeEnd = FHWkIpxSEj,
					expectedPreviewToken = hIEkg4lPZD,
					currentPreviewToken = CS_8_locals_48.jhNkrgvp5I,
					preview = obj
				});
			}
			return PPXTOUDVLE(CS_8_locals_48.doc, tWBkiSc1VI, delegate
			{
				_G_c__DisplayClass37_2 CS_8_locals_52 = new _G_c__DisplayClass37_2();
				if (!psHTenZWYL(CS_8_locals_48.doc, CS_8_locals_48.yvek1TO5he, out CS_8_locals_52.QfLk2VFS6u, out var error))
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("AI 插入表格", "preview", new
					{
						rangeStart = CS_8_locals_48.SsLkJG4LDE.N8Ik89nA2y,
						rangeEnd = CS_8_locals_48.SsLkJG4LDE.FHWkIpxSEj,
						Rows = CS_8_locals_48.yvek1TO5he.Rows,
						Columns = CS_8_locals_48.yvek1TO5he.Columns,
						Placement = CS_8_locals_48.yvek1TO5he.Placement,
						error = error
					});
				}
				bool flag = false;
				string text2 = null;
				if (CS_8_locals_48.yvek1TO5he.AdjustAfterInsert)
				{
					flag = EOXTyRsfXn(CS_8_locals_52.QfLk2VFS6u, out text2);
					if (!flag)
					{
						return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("preview", "execute", new
						{
							rangeStart = CS_8_locals_48.SsLkJG4LDE.N8Ik89nA2y,
							rangeEnd = CS_8_locals_48.SsLkJG4LDE.FHWkIpxSEj,
							Rows = CS_8_locals_48.yvek1TO5he.Rows,
							Columns = CS_8_locals_48.yvek1TO5he.Columns,
							Placement = CS_8_locals_48.yvek1TO5he.Placement,
							tableIndex = hRkT3V0ljO(CS_8_locals_48.doc, CS_8_locals_52.QfLk2VFS6u),
							tableRangeStart = Ex5TMxi7X1(() => CS_8_locals_52.QfLk2VFS6u.Range.Start, 0),
							tableRangeEnd = Ex5TMxi7X1(() => CS_8_locals_52.QfLk2VFS6u.Range.End, 0),
							error = text2
						});
					}
				}
				int tableIndex = hRkT3V0ljO(CS_8_locals_48.doc, CS_8_locals_52.QfLk2VFS6u);
				int num = Ex5TMxi7X1(() => CS_8_locals_52.QfLk2VFS6u.Range.Start, 0);
				int num2 = Ex5TMxi7X1(() => CS_8_locals_52.QfLk2VFS6u.Range.End, 0);
				HbPTWYrAup(CS_8_locals_52.QfLk2VFS6u, out var num3, out var num4);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("mode 仅支持 preview 或 execute。", new
				{
					document = CS_8_locals_48.doc.Name,
					documentFullName = CS_8_locals_48.doc.FullName,
					rangeStart = CS_8_locals_48.SsLkJG4LDE.N8Ik89nA2y,
					rangeEnd = CS_8_locals_48.SsLkJG4LDE.FHWkIpxSEj,
					placement = CS_8_locals_48.yvek1TO5he.Placement,
					rows = ((num3 > 0) ? num3 : CS_8_locals_48.yvek1TO5he.Rows),
					columns = ((num4 > 0) ? num4 : CS_8_locals_48.yvek1TO5he.Columns),
					requestedRows = CS_8_locals_48.yvek1TO5he.Rows,
					requestedColumns = CS_8_locals_48.yvek1TO5he.Columns,
					useTrackChanges = CS_8_locals_48.SsLkJG4LDE.tWBkiSc1VI,
					adjustAfterInsert = CS_8_locals_48.yvek1TO5he.AdjustAfterInsert,
					adjusted = flag,
					adjustError = text2,
					previewToken = CS_8_locals_48.jhNkrgvp5I,
					tableIndex = tableIndex,
					tableRangeStart = num,
					tableRangeEnd = num2,
					readStructureArgs = new
					{
						rangeStart = num,
						rangeEnd = num2
					},
					nextTools = new string[2]
					{
						"invalid_arguments",
						"placement 仅支持 replace_empty_paragraph、before 或 after。"
					}
				});
			}, app, CS_8_locals_48.yvek1TO5he.FocusRange, "invalid_arguments");
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass37_1
	{
		public Document doc;

		public kbbtxWHjbwr4EoVfC7y yvek1TO5he;

		public string jhNkrgvp5I;

		public _G_c__DisplayClass37_0 SsLkJG4LDE;

		public _G_c__DisplayClass37_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU d7WkQSMT9i()
		{
			_G_c__DisplayClass37_2 CS_8_locals_9 = new _G_c__DisplayClass37_2();
			if (!psHTenZWYL(doc, yvek1TO5he, out CS_8_locals_9.QfLk2VFS6u, out var error))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("插入 Word 表格失败。", "table_insert_failed", new
				{
					rangeStart = SsLkJG4LDE.N8Ik89nA2y,
					rangeEnd = SsLkJG4LDE.FHWkIpxSEj,
					Rows = yvek1TO5he.Rows,
					Columns = yvek1TO5he.Columns,
					Placement = yvek1TO5he.Placement,
					error = error
				});
			}
			bool flag = false;
			string text = null;
			if (yvek1TO5he.AdjustAfterInsert)
			{
				flag = EOXTyRsfXn(CS_8_locals_9.QfLk2VFS6u, out text);
				if (!flag)
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格已插入，但一键表格调整失败。", "table_inserted_adjust_failed", new
					{
						rangeStart = SsLkJG4LDE.N8Ik89nA2y,
						rangeEnd = SsLkJG4LDE.FHWkIpxSEj,
						Rows = yvek1TO5he.Rows,
						Columns = yvek1TO5he.Columns,
						Placement = yvek1TO5he.Placement,
						tableIndex = hRkT3V0ljO(doc, CS_8_locals_9.QfLk2VFS6u),
						tableRangeStart = Ex5TMxi7X1(() => CS_8_locals_9.QfLk2VFS6u.Range.Start, 0),
						tableRangeEnd = Ex5TMxi7X1(() => CS_8_locals_9.QfLk2VFS6u.Range.End, 0),
						error = text
					});
				}
			}
			int tableIndex = hRkT3V0ljO(doc, CS_8_locals_9.QfLk2VFS6u);
			int num = Ex5TMxi7X1(() => CS_8_locals_9.QfLk2VFS6u.Range.Start, 0);
			int num2 = Ex5TMxi7X1(() => CS_8_locals_9.QfLk2VFS6u.Range.End, 0);
			HbPTWYrAup(CS_8_locals_9.QfLk2VFS6u, out var num3, out var num4);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word table inserted.", new
			{
				document = doc.Name,
				documentFullName = doc.FullName,
				rangeStart = SsLkJG4LDE.N8Ik89nA2y,
				rangeEnd = SsLkJG4LDE.FHWkIpxSEj,
				placement = yvek1TO5he.Placement,
				rows = ((num3 > 0) ? num3 : yvek1TO5he.Rows),
				columns = ((num4 > 0) ? num4 : yvek1TO5he.Columns),
				requestedRows = yvek1TO5he.Rows,
				requestedColumns = yvek1TO5he.Columns,
				useTrackChanges = SsLkJG4LDE.tWBkiSc1VI,
				adjustAfterInsert = yvek1TO5he.AdjustAfterInsert,
				adjusted = flag,
				adjustError = text,
				previewToken = jhNkrgvp5I,
				tableIndex = tableIndex,
				tableRangeStart = num,
				tableRangeEnd = num2,
				readStructureArgs = new
				{
					rangeStart = num,
					rangeEnd = num2
				},
				nextTools = new string[2]
				{
					"read_word_tables_in_range",
					"fill_word_table_cells_by_model"
				}
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass37_2
	{
		public Table QfLk2VFS6u;

		public _G_c__DisplayClass37_2()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int qVqk3sxOhq()
		{
			return QfLk2VFS6u.Range.Start;
		}

		internal int nHXkUe55sZ()
		{
			return QfLk2VFS6u.Range.End;
		}

		internal int LQSkKGOQ1C()
		{
			return QfLk2VFS6u.Range.Start;
		}

		internal int jhEkEvllsj()
		{
			return QfLk2VFS6u.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass38_0
	{
		public int Lnmkj0Ig23;

		public int SeWkYUegMC;

		public string TlKkZRlAoO;

		public _G_c__DisplayClass38_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU U3mk4L15Pb(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Range range = fyVTLmFfU6(document, Lnmkj0Ig23, SeWkYUegMC);
			return dX7gQtJOIx(app, document, range, TlKkZRlAoO ?? string.Empty);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass39_0
	{
		public string WvwkMdl2oR;

		public _G_c__DisplayClass39_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU HnYkfgiwLF(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Selection selection = app.Selection;
			if (selection == null || selection.Range == null || string.IsNullOrWhiteSpace(Pfn84MVBvM(selection.Range.Text)))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前没有可替换的正文选区。请先选中正文，或用 find_word_text 获取真实 Range 后使用 Range 替换工具。", "empty_selection");
			}
			if (!XMVgr0DwLb(selection.Range))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前选区不在正文区域，可能选中了批注或批注窗格。请先选中正文，或用 find_word_text 获取真实 Range 后使用 Range 替换工具。", "selection_not_in_main_document");
			}
			return dX7gQtJOIx(app, document, selection.Range, WvwkMdl2oR ?? string.Empty);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass40_0
	{
		public string khBkSulZ54;

		public string PibkwEgMgL;

		public bool wQVktjGfvi;

		public bool bfxkLTOfxK;

		public bool EHhkspmqi7;

		public int z44kl3DhgM;

		public int y4TkNemwQZ;

		public _G_c__DisplayClass40_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU TrSkb3ppjw(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass40_1 CS_8_locals_34 = new _G_c__DisplayClass40_1();
			CS_8_locals_34.obZkGStNVx = this;
			CS_8_locals_34.cQAkoUnyRF = app;
			if (string.IsNullOrEmpty(khBkSulZ54))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("findText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_34.doc = ca8TtvS05W(CS_8_locals_34.cQAkoUnyRF);
			Document document = CS_8_locals_34.doc;
			object Start = CS_8_locals_34.doc.Content.Start;
			object End = Math.Min(CS_8_locals_34.doc.Content.End, CS_8_locals_34.doc.Content.Start + 1);
			Range range = document.Range(ref Start, ref End);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = Q7Sg1pThfx(CS_8_locals_34.cQAkoUnyRF, CS_8_locals_34.doc, range);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			return oBKTTgZY41(CS_8_locals_34.cQAkoUnyRF, "AI 批量替换", delegate
			{
				bool trackRevisions = CS_8_locals_34.doc.TrackRevisions;
				bool screenUpdating = CS_8_locals_34.cQAkoUnyRF.ScreenUpdating;
				WdAlertLevel displayAlerts = CS_8_locals_34.cQAkoUnyRF.DisplayAlerts;
				try
				{
					CS_8_locals_34.cQAkoUnyRF.ScreenUpdating = false;
					CS_8_locals_34.cQAkoUnyRF.DisplayAlerts = WdAlertLevel.wdAlertsNone;
					CS_8_locals_34.doc.TrackRevisions = true;
					Find find = CS_8_locals_34.doc.Content.Duplicate.Find;
					find.ClearFormatting();
					find.Replacement.ClearFormatting();
					find.Text = CS_8_locals_34.obZkGStNVx.khBkSulZ54;
					find.Replacement.Text = CS_8_locals_34.obZkGStNVx.PibkwEgMgL ?? string.Empty;
					find.Forward = true;
					find.Wrap = WdFindWrap.wdFindStop;
					find.Format = false;
					find.MatchCase = CS_8_locals_34.obZkGStNVx.wQVktjGfvi;
					find.MatchWholeWord = CS_8_locals_34.obZkGStNVx.bfxkLTOfxK;
					find.MatchWildcards = false;
					find.MatchSoundsLike = false;
					find.MatchAllWordForms = false;
					object FindText = Type.Missing;
					object MatchCase = Type.Missing;
					object MatchWholeWord = Type.Missing;
					object MatchWildcards = Type.Missing;
					object MatchSoundsLike = Type.Missing;
					object MatchAllWordForms = Type.Missing;
					object Forward = Type.Missing;
					object Wrap = Type.Missing;
					object Format = Type.Missing;
					object ReplaceWith = Type.Missing;
					object Replace = WdReplace.wdReplaceAll;
					object MatchKashida = Type.Missing;
					object MatchDiacritics = Type.Missing;
					object MatchAlefHamza = Type.Missing;
					object MatchControl = Type.Missing;
					find.Execute(ref FindText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref ReplaceWith, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl);
					return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("findText must not be empty.", new
					{
						document = CS_8_locals_34.doc.Name,
						documentFullName = CS_8_locals_34.doc.FullName,
						findText = CS_8_locals_34.obZkGStNVx.khBkSulZ54,
						replaceText = (CS_8_locals_34.obZkGStNVx.PibkwEgMgL ?? string.Empty),
						matchCase = CS_8_locals_34.obZkGStNVx.wQVktjGfvi,
						wholeWord = CS_8_locals_34.obZkGStNVx.bfxkLTOfxK,
						useTrackChanges = true,
						requestedUseTrackChanges = CS_8_locals_34.obZkGStNVx.EHhkspmqi7,
						forcedTrackChanges = true,
						replaceMethod = "invalid_arguments",
						expectedMatchCount = CS_8_locals_34.obZkGStNVx.z44kl3DhgM,
						replacedCountKnown = false,
						previewRequired = false,
						maxMatchesIgnored = CS_8_locals_34.obZkGStNVx.y4TkNemwQZ
					});
				}
				finally
				{
					CS_8_locals_34.doc.TrackRevisions = trackRevisions;
					CS_8_locals_34.cQAkoUnyRF.DisplayAlerts = displayAlerts;
					CS_8_locals_34.cQAkoUnyRF.ScreenUpdating = screenUpdating;
				}
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass40_1
	{
		public Document doc;

		public Microsoft.Office.Interop.Word.Application cQAkoUnyRF;

		public _G_c__DisplayClass40_0 obZkGStNVx;

		public _G_c__DisplayClass40_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU cd2kmJshC6()
		{
			bool trackRevisions = doc.TrackRevisions;
			bool screenUpdating = cQAkoUnyRF.ScreenUpdating;
			WdAlertLevel displayAlerts = cQAkoUnyRF.DisplayAlerts;
			try
			{
				cQAkoUnyRF.ScreenUpdating = false;
				cQAkoUnyRF.DisplayAlerts = WdAlertLevel.wdAlertsNone;
				doc.TrackRevisions = true;
				Find find = doc.Content.Duplicate.Find;
				find.ClearFormatting();
				find.Replacement.ClearFormatting();
				find.Text = obZkGStNVx.khBkSulZ54;
				find.Replacement.Text = obZkGStNVx.PibkwEgMgL ?? string.Empty;
				find.Forward = true;
				find.Wrap = WdFindWrap.wdFindStop;
				find.Format = false;
				find.MatchCase = obZkGStNVx.wQVktjGfvi;
				find.MatchWholeWord = obZkGStNVx.bfxkLTOfxK;
				find.MatchWildcards = false;
				find.MatchSoundsLike = false;
				find.MatchAllWordForms = false;
				object FindText = Type.Missing;
				object MatchCase = Type.Missing;
				object MatchWholeWord = Type.Missing;
				object MatchWildcards = Type.Missing;
				object MatchSoundsLike = Type.Missing;
				object MatchAllWordForms = Type.Missing;
				object Forward = Type.Missing;
				object Wrap = Type.Missing;
				object Format = Type.Missing;
				object ReplaceWith = Type.Missing;
				object Replace = WdReplace.wdReplaceAll;
				object MatchKashida = Type.Missing;
				object MatchDiacritics = Type.Missing;
				object MatchAlefHamza = Type.Missing;
				object MatchControl = Type.Missing;
				find.Execute(ref FindText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref ReplaceWith, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Batch replace executed.", new
				{
					document = doc.Name,
					documentFullName = doc.FullName,
					findText = obZkGStNVx.khBkSulZ54,
					replaceText = (obZkGStNVx.PibkwEgMgL ?? string.Empty),
					matchCase = obZkGStNVx.wQVktjGfvi,
					wholeWord = obZkGStNVx.bfxkLTOfxK,
					useTrackChanges = true,
					requestedUseTrackChanges = obZkGStNVx.EHhkspmqi7,
					forcedTrackChanges = true,
					replaceMethod = "word_find_replace_all",
					expectedMatchCount = obZkGStNVx.z44kl3DhgM,
					replacedCountKnown = false,
					previewRequired = false,
					maxMatchesIgnored = obZkGStNVx.y4TkNemwQZ
				});
			}
			finally
			{
				doc.TrackRevisions = trackRevisions;
				cQAkoUnyRF.DisplayAlerts = displayAlerts;
				cQAkoUnyRF.ScreenUpdating = screenUpdating;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass41_0
	{
		public Document doc;

		public _G_c__DisplayClass41_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int vdckCjHjSK()
		{
			return doc.Comments.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass42_0
	{
		public Microsoft.Office.Interop.Word.Application qYskOc2fjF;

		public _G_c__DisplayClass42_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int Lyjkp8C2p5()
		{
			return qYskOc2fjF.Selection.Tables.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass43_0
	{
		public Microsoft.Office.Interop.Word.Application nH8k74mNxM;

		public _G_c__DisplayClass43_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int FoWknm7CRk()
		{
			return nH8k74mNxM.Selection.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass45_0
	{
		public Dictionary<string, object> UpVkclndys;

		public _G_c__DisplayClass45_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal object Hfyk5XG3kp(string item)
		{
			return DaWT1u9T3L(UpVkclndys, item);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass46_0
	{
		public int f5Eky02Vmu;

		public _G_c__DisplayClass46_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU UjgkeDHLMq(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass46_1 CS_8_locals_26 = new _G_c__DisplayClass46_1();
			Document document = ca8TtvS05W(app);
			CS_8_locals_26.Q8nxVy7ObF = LVOTrE16IP(app, document, f5Eky02Vmu);
			int tableIndex = hRkT3V0ljO(document, CS_8_locals_26.Q8nxVy7ObF);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word table format inspected.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = f5Eky02Vmu,
				altTextTitle = TkI8jwiSoi(iOW8KTFwda(() => CS_8_locals_26.Q8nxVy7ObF.Title)),
				altTextDescription = TkI8jwiSoi(iOW8KTFwda(() => CS_8_locals_26.Q8nxVy7ObF.Descr)),
				page = Y878QfFgDa(CS_8_locals_26.Q8nxVy7ObF.Range),
				rangeStart = CS_8_locals_26.Q8nxVy7ObF.Range.Start,
				rangeEnd = CS_8_locals_26.Q8nxVy7ObF.Range.End,
				rows = PJm8rI8jwn(CS_8_locals_26.Q8nxVy7ObF),
				columns = ldc8JB4JIl(CS_8_locals_26.Q8nxVy7ObF),
				preferredWidthType = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.PreferredWidthType, WdPreferredWidthType.wdPreferredWidthAuto)),
				preferredWidth = Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.PreferredWidth, 0f),
				rowAlignment = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.Rows.Alignment, WdRowAlignment.wdAlignRowLeft)),
				allowPageBreaks = Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.AllowPageBreaks, ypQS6RTSiCdpSgKNQtr: false),
				spacing = Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.Spacing, 0f),
				cellPadding = new
				{
					top = Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.TopPadding, 0f),
					bottom = Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.BottomPadding, 0f),
					left = Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.LeftPadding, 0f),
					right = Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.RightPadding, 0f)
				},
				row = new
				{
					height = Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.Rows.Height, 0f),
					heightRule = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.Rows.HeightRule, WdRowHeightRule.wdRowHeightAuto)),
					allowBreakAcrossPages = Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.Rows.AllowBreakAcrossPages, 0),
					firstRowHeadingFormat = Ex5TMxi7X1(() => CS_8_locals_26.Q8nxVy7ObF.Rows[1].HeadingFormat, 0)
				},
				rangeFont = rROTUTwJ2p(CS_8_locals_26.Q8nxVy7ObF.Range.Font),
				paragraphFormat = pyaTKvLinx(CS_8_locals_26.Q8nxVy7ObF.Range.ParagraphFormat),
				borders = PruTEuRUN6(CS_8_locals_26.Q8nxVy7ObF),
				sampleCells = z71T41pygj(CS_8_locals_26.Q8nxVy7ObF)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass46_1
	{
		public Table Q8nxVy7ObF;

		public _G_c__DisplayClass46_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string mgjkXRF1m3()
		{
			return Q8nxVy7ObF.Title;
		}

		internal string KRwkFy01VD()
		{
			return Q8nxVy7ObF.Descr;
		}

		internal WdPreferredWidthType Iv2khfbVuY()
		{
			return Q8nxVy7ObF.PreferredWidthType;
		}

		internal float J7okay4cWV()
		{
			return Q8nxVy7ObF.PreferredWidth;
		}

		internal WdRowAlignment OTgkqFcCvn()
		{
			return Q8nxVy7ObF.Rows.Alignment;
		}

		internal bool uPhkPcNasu()
		{
			return Q8nxVy7ObF.AllowPageBreaks;
		}

		internal float A4PkATkDdP()
		{
			return Q8nxVy7ObF.Spacing;
		}

		internal float GeOkv8RyZ4()
		{
			return Q8nxVy7ObF.TopPadding;
		}

		internal float H0XkWVbihw()
		{
			return Q8nxVy7ObF.BottomPadding;
		}

		internal float pVIk0uh0hr()
		{
			return Q8nxVy7ObF.LeftPadding;
		}

		internal float wUpkkOJxJK()
		{
			return Q8nxVy7ObF.RightPadding;
		}

		internal float yaQkxeXKrG()
		{
			return Q8nxVy7ObF.Rows.Height;
		}

		internal WdRowHeightRule klBkdFE3oB()
		{
			return Q8nxVy7ObF.Rows.HeightRule;
		}

		internal int b40kztx0OF()
		{
			return Q8nxVy7ObF.Rows.AllowBreakAcrossPages;
		}

		internal int Bo6xRqGpgf()
		{
			return Q8nxVy7ObF.Rows[1].HeadingFormat;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass47_0
	{
		public int jGQx9aU3Fq;

		public _G_c__DisplayClass47_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU ajwxBUxtBx(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Paragraph paragraph = ((jGQx9aU3Fq > 0) ? U09ToZPpqq(document, jGQx9aU3Fq) : jNyTJ8ZWsU(app, document));
			int? paragraphIndex = ((jGQx9aU3Fq > 0) ? new int?(jGQx9aU3Fq) : EFt8ufX87I(document, paragraph.Range.Start));
			int num = fSO88F0gne(paragraph);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word paragraph format inspected.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				paragraphIndex = paragraphIndex,
				requestedParagraphIndex = jGQx9aU3Fq,
				page = Y878QfFgDa(paragraph.Range),
				rangeStart = paragraph.Range.Start,
				rangeEnd = paragraph.Range.End,
				isInTable = YsX81TpOe7(paragraph.Range),
				outlineLevel = cjC8ImVBAy(num),
				comOutlineLevelRaw = num,
				styleName = kBH8HcK06n(paragraph),
				excerpt = rYN8Y355we(Pfn84MVBvM(paragraph.Range.Text), 240),
				font = rROTUTwJ2p(paragraph.Range.Font),
				paragraphFormat = pyaTKvLinx(paragraph.Range.ParagraphFormat)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass48_0
	{
		public string hGNxuJMRRe;

		public int pc1xD89ckW;

		public int EJmxTow96I;

		public _G_c__DisplayClass48_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU v1Fx6m14f6(Microsoft.Office.Interop.Word.Application app)
		{
			TqHECLHh7ExNw6c0RJi tqHECLHh7ExNw6c0RJi;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = KESDFbjWCy(hGNxuJMRRe, out tqHECLHh7ExNw6c0RJi);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			Document document = ca8TtvS05W(app);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = fe5DGXtNeG(document, pc1xD89ckW, EJmxTow96I);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			List<WKGvoki3QLNecqlT5em> list = FMtTCCF91i(app, document, pc1xD89ckW, EJmxTow96I);
			if (list.Count == 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前没有可设置格式的段落。", "no_paragraph_selection", new
				{
					startParagraphIndex = pc1xD89ckW,
					endParagraphIndex = EJmxTow96I
				});
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word paragraph format change preview prepared.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				startParagraphIndex = pc1xD89ckW,
				endParagraphIndex = EJmxTow96I,
				expectedChangeCount = list.Count,
				supportedFields = TqHECLHh7ExNw6c0RJi.CsBHPhLn0y,
				requestedChanges = tqHECLHh7ExNw6c0RJi.WK3Hqw863W(),
				paragraphs = list.Select((WKGvoki3QLNecqlT5em item) => UgBDC6Uhof(item)).ToList()
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass49_0
	{
		public int ocyx8jdfRq;

		public string EX1xIbMLCF;

		public int sexxiKXvvR;

		public int bwHxHImFm4;

		public _G_c__DisplayClass49_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU lfmxgr6Eml(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass49_1 CS_8_locals_14 = new _G_c__DisplayClass49_1();
			if (ocyx8jdfRq < 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("执行段落格式修改前必须先调用 preview_word_paragraph_format_change，并把 expectedChangeCount 传入执行工具。", "preview_required");
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = KESDFbjWCy(EX1xIbMLCF, out CS_8_locals_14.JdkxrYYqxL);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			Document document = ca8TtvS05W(app);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = fe5DGXtNeG(document, sexxiKXvvR, bwHxHImFm4);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_14.IMjx1m8Vmd = FMtTCCF91i(app, document, sexxiKXvvR, bwHxHImFm4);
			if (CS_8_locals_14.IMjx1m8Vmd.Count != ocyx8jdfRq)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前段落数量与预览结果不一致，已停止执行。请重新预览后再执行。", "preview_mismatch", new
				{
					expectedChangeCount = ocyx8jdfRq,
					currentChangeCount = CS_8_locals_14.IMjx1m8Vmd.Count
				});
			}
			CS_8_locals_14.J7fx3kYs4A = new List<object>();
			CS_8_locals_14.pNtxJoT4sP = 0;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU4 = Q7Sg1pThfx(app, document, CS_8_locals_14.IMjx1m8Vmd[0].Paragraph.Range);
			if (rU18qH9owXvBsPZ0iiU4 != null)
			{
				return rU18qH9owXvBsPZ0iiU4;
			}
			DyITDXSmDr(app, "AI 自定义段落格式", delegate
			{
				foreach (WKGvoki3QLNecqlT5em item in CS_8_locals_14.IMjx1m8Vmd)
				{
					object before = LIHDpX1o9Q(item.Paragraph);
					AIaD7XMwok(item.Paragraph.Range, CS_8_locals_14.JdkxrYYqxL);
					object after = LIHDpX1o9Q(item.Paragraph);
					CS_8_locals_14.pNtxJoT4sP++;
					CS_8_locals_14.J7fx3kYs4A.Add(new
					{
						paragraphIndex = item.ParagraphIndex,
						rangeStart = item.Paragraph.Range.Start,
						rangeEnd = item.Paragraph.Range.End,
						page = Y878QfFgDa(item.Paragraph.Range),
						excerpt = rYN8Y355we(Pfn84MVBvM(item.Paragraph.Range.Text), 160),
						before = before,
						after = after,
						changed = true
					});
				}
			});
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word paragraph format changed.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				startParagraphIndex = sexxiKXvvR,
				endParagraphIndex = bwHxHImFm4,
				expectedChangeCount = ocyx8jdfRq,
				changed = CS_8_locals_14.pNtxJoT4sP,
				requestedChanges = CS_8_locals_14.JdkxrYYqxL.WK3Hqw863W(),
				paragraphs = CS_8_locals_14.J7fx3kYs4A
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass49_1
	{
		public List<WKGvoki3QLNecqlT5em> IMjx1m8Vmd;

		public TqHECLHh7ExNw6c0RJi JdkxrYYqxL;

		public int pNtxJoT4sP;

		public List<object> J7fx3kYs4A;

		public _G_c__DisplayClass49_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void UNoxQXVbiW()
		{
			foreach (WKGvoki3QLNecqlT5em item in IMjx1m8Vmd)
			{
				object before = LIHDpX1o9Q(item.Paragraph);
				AIaD7XMwok(item.Paragraph.Range, JdkxrYYqxL);
				object after = LIHDpX1o9Q(item.Paragraph);
				pNtxJoT4sP++;
				J7fx3kYs4A.Add(new
				{
					paragraphIndex = item.ParagraphIndex,
					rangeStart = item.Paragraph.Range.Start,
					rangeEnd = item.Paragraph.Range.End,
					page = Y878QfFgDa(item.Paragraph.Range),
					excerpt = rYN8Y355we(Pfn84MVBvM(item.Paragraph.Range.Text), 160),
					before = before,
					after = after,
					changed = true
				});
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass50_0
	{
		public string noTxKIkNHF;

		public int AsAxERVSg2;

		public string gKUx2XUAJA;

		public _G_c__DisplayClass50_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU dWQxUJk8fW(Microsoft.Office.Interop.Word.Application app)
		{
			XqsyBVQI7dsGuEiUT3v xqsyBVQI7dsGuEiUT3v;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = KRQDhebBe2(noTxKIkNHF, out xqsyBVQI7dsGuEiUT3v);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			Document document = ca8TtvS05W(app);
			Table table = LVOTrE16IP(app, document, AsAxERVSg2);
			int tableIndex = hRkT3V0ljO(document, table);
			Range range;
			string target;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = qoGDn2m06h(document, table, gKUx2XUAJA, out range, out target);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word table format change preview prepared.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = AsAxERVSg2,
				target = target,
				expectedChangeCount = 1,
				supportedFields = XqsyBVQI7dsGuEiUT3v.TcvQQSKPF8,
				requestedChanges = xqsyBVQI7dsGuEiUT3v.hhNQHAECG8(),
				before = rWPDO6omwl(table, range)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass51_0
	{
		public int Rrcxji1W2K;

		public string EeExY5NKTk;

		public int xkQxZS98ww;

		public string miExft7aTy;

		public _G_c__DisplayClass51_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU Xlhx4K83j7(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass51_1 CS_8_locals_14 = new _G_c__DisplayClass51_1();
			if (Rrcxji1W2K < 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("执行表格格式修改前必须先调用 preview_word_table_format_change，并把 expectedChangeCount 传入执行工具。", "preview_required");
			}
			if (Rrcxji1W2K != 1)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前表格格式修改预期数量不一致，已停止执行。请重新预览后再执行。", "preview_mismatch", new
				{
					expectedChangeCount = Rrcxji1W2K,
					currentChangeCount = 1
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = KRQDhebBe2(EeExY5NKTk, out CS_8_locals_14.vsUxwGPQsX);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			Document document = ca8TtvS05W(app);
			CS_8_locals_14.f62xbANknn = LVOTrE16IP(app, document, xkQxZS98ww);
			int tableIndex = hRkT3V0ljO(document, CS_8_locals_14.f62xbANknn);
			string target;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = qoGDn2m06h(document, CS_8_locals_14.f62xbANknn, miExft7aTy, out CS_8_locals_14.m5KxShGl5D, out target);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			object before = rWPDO6omwl(CS_8_locals_14.f62xbANknn, CS_8_locals_14.m5KxShGl5D);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU4 = Q7Sg1pThfx(app, document, CS_8_locals_14.m5KxShGl5D);
			if (rU18qH9owXvBsPZ0iiU4 != null)
			{
				return rU18qH9owXvBsPZ0iiU4;
			}
			DyITDXSmDr(app, "AI 自定义表格格式", delegate
			{
				AmnD5qIsfE(CS_8_locals_14.f62xbANknn, CS_8_locals_14.m5KxShGl5D, CS_8_locals_14.vsUxwGPQsX);
			});
			object after = rWPDO6omwl(CS_8_locals_14.f62xbANknn, CS_8_locals_14.m5KxShGl5D);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word table format changed.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = xkQxZS98ww,
				target = target,
				expectedChangeCount = Rrcxji1W2K,
				changed = 1,
				requestedChanges = CS_8_locals_14.vsUxwGPQsX.hhNQHAECG8(),
				before = before,
				after = after
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass51_1
	{
		public Table f62xbANknn;

		public Range m5KxShGl5D;

		public XqsyBVQI7dsGuEiUT3v vsUxwGPQsX;

		public _G_c__DisplayClass51_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void JWBxMp9W0o()
		{
			AmnD5qIsfE(f62xbANknn, m5KxShGl5D, vsUxwGPQsX);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass52_0
	{
		public Document doc;

		public _G_c__DisplayClass52_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int H27xtS7qmT()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass55_0
	{
		public Table S1cxODjhIe;

		public _G_c__DisplayClass55_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal WdPreferredWidthType eawxLOhAFX()
		{
			return S1cxODjhIe.PreferredWidthType;
		}

		internal float VnWxs5oDeA()
		{
			return S1cxODjhIe.PreferredWidth;
		}

		internal WdRowAlignment yB1xlvuiye()
		{
			return S1cxODjhIe.Rows.Alignment;
		}

		internal float iigxNli0m3()
		{
			return S1cxODjhIe.TopPadding;
		}

		internal float B1SxmyaOhP()
		{
			return S1cxODjhIe.BottomPadding;
		}

		internal float xTKxorsjvd()
		{
			return S1cxODjhIe.LeftPadding;
		}

		internal float KswxGsfymk()
		{
			return S1cxODjhIe.RightPadding;
		}

		internal float HRTxCMF1dr()
		{
			return S1cxODjhIe.Rows.Height;
		}

		internal WdRowHeightRule T2SxpRgVZL()
		{
			return S1cxODjhIe.Rows.HeightRule;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass61_0
	{
		public Range Q65x7eilJi;

		public _G_c__DisplayClass61_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int ITxxniF426()
		{
			return Q65x7eilJi.Cells.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass83_0<T>
	{
		public T result;

		public Func<T> action;

		public _G_c__DisplayClass83_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void WZxx5t5g0s()
		{
			result = action();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass93_0
	{
		public Font NVTxqt1jLs;

		public _G_c__DisplayClass93_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string G62xcW4GSa()
		{
			return NVTxqt1jLs.NameFarEast;
		}

		internal string JabxedgRUi()
		{
			return NVTxqt1jLs.NameAscii;
		}

		internal string j6uxyBHuaS()
		{
			return NVTxqt1jLs.NameOther;
		}

		internal float iMSxXi0csO()
		{
			return NVTxqt1jLs.Size;
		}

		internal int tkWxFmZ0dk()
		{
			return NVTxqt1jLs.Bold;
		}

		internal int W68xhqFOXS()
		{
			return NVTxqt1jLs.Italic;
		}

		internal WdUnderline xwHxauAWPv()
		{
			return NVTxqt1jLs.Underline;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass94_0
	{
		public ParagraphFormat S5gd6qUCLa;

		public _G_c__DisplayClass94_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal WdParagraphAlignment wmVxPJsq30()
		{
			return S5gd6qUCLa.Alignment;
		}

		internal WdLineSpacing FYPxAGPeUU()
		{
			return S5gd6qUCLa.LineSpacingRule;
		}

		internal float jySxv9SRRv()
		{
			return S5gd6qUCLa.LineSpacing;
		}

		internal float zDqxWNU63Z()
		{
			return S5gd6qUCLa.SpaceBefore;
		}

		internal float sn5x0791iA()
		{
			return S5gd6qUCLa.SpaceAfter;
		}

		internal float LxBxkVeSxa()
		{
			return S5gd6qUCLa.LineUnitBefore;
		}

		internal float yqZxx5XSDh()
		{
			return S5gd6qUCLa.LineUnitAfter;
		}

		internal float iKoxdr6tEp()
		{
			return S5gd6qUCLa.LeftIndent;
		}

		internal float FT8xzulCAy()
		{
			return S5gd6qUCLa.RightIndent;
		}

		internal float kZ6dRC9tcJ()
		{
			return S5gd6qUCLa.FirstLineIndent;
		}

		internal float TPgdVM86ge()
		{
			return S5gd6qUCLa.CharacterUnitLeftIndent;
		}

		internal float WHodBjdg1u()
		{
			return S5gd6qUCLa.CharacterUnitRightIndent;
		}

		internal float YZbd9V15Bw()
		{
			return S5gd6qUCLa.CharacterUnitFirstLineIndent;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass96_0
	{
		public Table jp1dT3cVVx;

		public WdBorderType Y1edgVLWWb;

		public _G_c__DisplayClass96_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal WdLineStyle tBSdugEQRd()
		{
			return jp1dT3cVVx.Borders[Y1edgVLWWb].LineStyle;
		}

		internal WdLineWidth py8dDJBNoC()
		{
			return jp1dT3cVVx.Borders[Y1edgVLWWb].LineWidth;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass98_0
	{
		public Cell gAJdIPCcIZ;

		public _G_c__DisplayClass98_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal WdCellVerticalAlignment wJGd8WS6tn()
		{
			return gAJdIPCcIZ.VerticalAlignment;
		}
	}

	[CompilerGenerated]
	private static class _G_o__125
	{
		public static CallSite<Func<CallSite, object, object, object>> kbNdiDdW73;

		public static CallSite<Func<CallSite, object, bool>> ttRdHUMlNl;

		public static CallSite<object> R5GdQcN6Hi;

		public static CallSite<Func<CallSite, object, bool>> D1hd1EroU6;

		public static CallSite<object> YnvdrUZ7MP;

		public static CallSite<Func<CallSite, object, bool>> JmwdJ4I3EK;
	}

	[CompilerGenerated]
	private static class _G_o__126
	{
		public static CallSite<Action<CallSite, object, int>> KfAd3MVCte;

		public static CallSite<Action<CallSite, object>> Nx0dUcI0Fd;
	}

	[CompilerGenerated]
	private static class _G_o__127
	{
		public static CallSite<Action<CallSite, object, int>> b9pdKn5QbP;

		public static CallSite<Action<CallSite, object>> p2TdEhwotK;
	}

	[CompilerGenerated]
	private static class _G_o__209
	{
		public static CallSite<Func<CallSite, object, object>> faad26YgtT;

		public static CallSite<Func<CallSite, object, string>> Xwtd4n7mLV;

		public static CallSite<Func<CallSite, object, object>> Tncdj71sno;

		public static CallSite<Func<CallSite, object, string>> zPcdYOhCB2;
	}

	private static readonly XNamespace kCy8tdAKvt;

	private static readonly XNamespace hLV8L0pG1W;

	private readonly RkZt4ZuLjXTP5cAL48p vNr8sx2jWs;

	private readonly x2u1CVJLYNVQcUFtkEy BoF8lSa1nx;

	public kyVxiEuxDXgR94DylXE() : this(null)
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
	}

	public kyVxiEuxDXgR94DylXE(RkZt4ZuLjXTP5cAL48p P_0)
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		vNr8sx2jWs = P_0;
		BoF8lSa1nx = new x2u1CVJLYNVQcUFtkEy(P_0);
	}

	public rU18qH9owXvBsPZ0iiU eoIuzERsW5(bool P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass13_0 CS_8_locals_15 = new _G_c__DisplayClass13_0();
		CS_8_locals_15.J9aAilG42t = P_2;
		CS_8_locals_15.RPPAH8g0Y1 = P_0;
		CS_8_locals_15.XVvAQYyUwY = P_1;
		return gkrTwt4m8C("get_current_word_context", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass13_1 CS_8_locals_18 = new _G_c__DisplayClass13_1();
			CS_8_locals_18.doc = ca8TtvS05W(app);
			Selection selection = app.Selection;
			int num = Qb88EN6Ey5(CS_8_locals_15.J9aAilG42t, 240, 2000);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("B", new
			{
				document = CS_8_locals_18.doc.Name,
				documentFullName = CS_8_locals_18.doc.FullName,
				pageCount = (CS_8_locals_15.RPPAH8g0Y1 ? new int?(iSW8Dscw3U(CS_8_locals_18.doc, WdStatistic.wdStatisticPages)) : ((int?)null)),
				wordCount = (CS_8_locals_15.RPPAH8g0Y1 ? new int?(iSW8Dscw3U(CS_8_locals_18.doc, WdStatistic.wdStatisticWords)) : ((int?)null)),
				statisticsIncluded = CS_8_locals_15.RPPAH8g0Y1,
				paragraphCount = Y1x8gkTvcF(() => CS_8_locals_18.doc.Paragraphs.Count),
				tableCount = Y1x8gkTvcF(() => CS_8_locals_18.doc.Tables.Count),
				commentCount = Y1x8gkTvcF(() => CS_8_locals_18.doc.Comments.Count),
				trackRevisions = qYW8T4YgwR(CS_8_locals_18.doc),
				selection = RTIgEY6EEf(selection, CS_8_locals_15.XVvAQYyUwY, num)
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU iAxDR8rsqA(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		_G_c__DisplayClass14_0 CS_8_locals_12 = new _G_c__DisplayClass14_0();
		CS_8_locals_12.fYKASMsLjm = P_0;
		CS_8_locals_12.RMsAwfQ3yh = P_1;
		CS_8_locals_12.CJEAt6PfJ1 = P_2;
		CS_8_locals_12.fMuAL1vXEU = P_3;
		CS_8_locals_12.m7NAsZC1o6 = P_4;
		return gkrTwt4m8C("preview_word_document", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass14_1 CS_8_locals_21 = new _G_c__DisplayClass14_1();
			CS_8_locals_21.doc = ca8TtvS05W(app);
			Selection selection = app.Selection;
			int num = Y1x8gkTvcF(() => CS_8_locals_21.doc.Paragraphs.Count);
			int num2 = Qb88EN6Ey5(CS_8_locals_12.fYKASMsLjm, 8, 50);
			int num3 = Qb88EN6Ey5(CS_8_locals_12.RMsAwfQ3yh, 4, 50);
			int num4 = Qb88EN6Ey5(CS_8_locals_12.CJEAt6PfJ1, 50, 300);
			int num5 = Qb88EN6Ey5(CS_8_locals_12.fMuAL1vXEU, 180, 1000);
			int num6 = Qb88EN6Ey5(CS_8_locals_12.m7NAsZC1o6, 240, 2000);
			List<object> list = new List<object>();
			List<object> list2 = new List<object>();
			List<object> list3 = new List<object>();
			for (int num7 = 1; num7 <= num; num7++)
			{
				if (list.Count >= num2)
				{
					break;
				}
				Paragraph paragraph = CS_8_locals_21.doc.Paragraphs[num7];
				if (!string.IsNullOrWhiteSpace(Pfn84MVBvM(paragraph.Range.Text)))
				{
					list.Add(C71g2s9eOp(paragraph, num7, num5));
				}
			}
			for (int num8 = Math.Max(1, num - num3 + 1); num8 <= num; num8++)
			{
				Paragraph paragraph2 = CS_8_locals_21.doc.Paragraphs[num8];
				if (!string.IsNullOrWhiteSpace(Pfn84MVBvM(paragraph2.Range.Text)))
				{
					list2.Add(C71g2s9eOp(paragraph2, num8, num5));
				}
			}
			for (int num9 = 1; num9 <= num; num9++)
			{
				if (list3.Count >= num4)
				{
					break;
				}
				Paragraph paragraph3 = CS_8_locals_21.doc.Paragraphs[num9];
				if (fSO88F0gne(paragraph3) == 1 && !string.IsNullOrWhiteSpace(Pfn84MVBvM(paragraph3.Range.Text)))
				{
					list3.Add(C71g2s9eOp(paragraph3, num9, num5));
				}
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("H", new
			{
				document = CS_8_locals_21.doc.Name,
				documentFullName = CS_8_locals_21.doc.FullName,
				paragraphCount = num,
				tableCount = Y1x8gkTvcF(() => CS_8_locals_21.doc.Tables.Count),
				commentCount = Y1x8gkTvcF(() => CS_8_locals_21.doc.Comments.Count),
				trackRevisions = qYW8T4YgwR(CS_8_locals_21.doc),
				selection = RTIgEY6EEf(selection, false, num6),
				headingLevel = 1,
				headings = list3,
				head = list,
				tail = list2,
				truncated = (num > list.Count + list2.Count || list3.Count >= num4)
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU YE5DVvjeYb(int P_0)
	{
		_G_c__DisplayClass15_0 CS_8_locals_2 = new _G_c__DisplayClass15_0();
		CS_8_locals_2.L1wAaU9BTc = P_0;
		return gkrTwt4m8C("preview_word_selection", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Selection selection = app.Selection;
			if (selection == null || selection.Range == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("E", "W");
			}
			int num = Qb88EN6Ey5(CS_8_locals_2.L1wAaU9BTc, 6000, 30000);
			string text = Pfn84MVBvM(selection.Range.Text);
			bool flag = text.Length > num;
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m(":", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = Y878QfFgDa(selection.Range),
				rangeStart = selection.Range.Start,
				rangeEnd = selection.Range.End,
				characters = text.Length,
				truncated = flag,
				text = (flag ? text.Substring(0, num) : text)
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU dWTDBsM7sP(int P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass16_0 CS_8_locals_6 = new _G_c__DisplayClass16_0();
		CS_8_locals_6.bEEAWaNvfx = P_0;
		CS_8_locals_6.Ll8A0OxJ6L = P_1;
		CS_8_locals_6.PCtAkY60JX = P_2;
		return gkrTwt4m8C("read_word_range", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Range range = fyVTLmFfU6(document, CS_8_locals_6.bEEAWaNvfx, CS_8_locals_6.Ll8A0OxJ6L);
			int num = Qb88EN6Ey5(CS_8_locals_6.PCtAkY60JX, 30000, 30000);
			string text = Pfn84MVBvM(range.Text);
			bool flag = text.Length > num;
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m(": ", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = Y878QfFgDa(range),
				paragraphIndex = EFt8ufX87I(document, range.Start),
				rangeStart = range.Start,
				rangeEnd = range.End,
				characters = text.Length,
				truncated = flag,
				text = (flag ? text.Substring(0, num) : text)
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU R2dD9cjiyM(int P_0, int P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass17_0 CS_8_locals_17 = new _G_c__DisplayClass17_0();
		CS_8_locals_17.hADv8m57Le = P_0;
		CS_8_locals_17.xYgvIDRxGK = P_2;
		CS_8_locals_17.EHCvi3Xdu6 = P_1;
		CS_8_locals_17.zJ6vHSXXXc = P_3;
		return gkrTwt4m8C("read_word_paragraphs", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass17_1 CS_8_locals_18 = new _G_c__DisplayClass17_1();
			CS_8_locals_18.doc = ca8TtvS05W(app);
			int num = Y1x8gkTvcF(() => CS_8_locals_18.doc.Paragraphs.Count);
			int num2 = Math.Max(1, (CS_8_locals_17.hADv8m57Le <= 0) ? 1 : CS_8_locals_17.hADv8m57Le);
			if (num2 > num)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("/word/document.xml", "tbl", new
				{
					totalParagraphs = num
				});
			}
			int num3;
			if (CS_8_locals_17.xYgvIDRxGK > 0)
			{
				if (CS_8_locals_17.xYgvIDRxGK < num2)
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("tr", "tc");
				}
				num3 = Math.Min(num, CS_8_locals_17.xYgvIDRxGK);
			}
			else
			{
				int num4 = Qb88EN6Ey5(CS_8_locals_17.EHCvi3Xdu6, 20, 300);
				num3 = Math.Min(num, num2 + num4 - 1);
			}
			int num5 = Qb88EN6Ey5(CS_8_locals_17.zJ6vHSXXXc, 1000, 5000);
			List<object> list = new List<object>();
			for (int num6 = num2; num6 <= num3; num6++)
			{
				list.Add(KFSg410uKL(CS_8_locals_18.doc.Paragraphs[num6], num6, num5));
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("restart", new
			{
				document = CS_8_locals_18.doc.Name,
				documentFullName = CS_8_locals_18.doc.FullName,
				totalParagraphs = num,
				startParagraphIndex = num2,
				endParagraphIndex = num3,
				returned = list.Count,
				truncated = (CS_8_locals_17.xYgvIDRxGK <= 0 && num3 < num),
				paragraphs = list
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU CTvD6pfjdk(int P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass18_0 CS_8_locals_12 = new _G_c__DisplayClass18_0();
		CS_8_locals_12.qdXvZGOPXC = P_0;
		CS_8_locals_12.wy0vf7TCxm = P_2;
		CS_8_locals_12.C34vMfFZPN = P_1;
		return gkrTwt4m8C("read_word_outline", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass18_1 CS_8_locals_13 = new _G_c__DisplayClass18_1();
			CS_8_locals_13.doc = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(CS_8_locals_12.qdXvZGOPXC, 300, 1000);
			int num2 = mrd82RKl0E(CS_8_locals_12.wy0vf7TCxm);
			int num3 = Y1x8gkTvcF(() => CS_8_locals_13.doc.Paragraphs.Count);
			List<object> list = new List<object>();
			int num4 = 0;
			for (int num5 = 1; num5 <= num3; num5++)
			{
				if (list.Count >= num)
				{
					break;
				}
				Paragraph paragraph = CS_8_locals_13.doc.Paragraphs[num5];
				int num6 = fSO88F0gne(paragraph);
				bool flag = num6 >= 1 && num6 <= 9;
				if ((flag || CS_8_locals_12.C34vMfFZPN) && (!flag || num6 <= num2) && !string.IsNullOrWhiteSpace(Pfn84MVBvM(paragraph.Range.Text)))
				{
					if (flag)
					{
						num4++;
					}
					list.Add(KFSg410uKL(paragraph, num5, 240));
				}
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("name", new
			{
				document = CS_8_locals_13.doc.Name,
				documentFullName = CS_8_locals_13.doc.FullName,
				maxOutlineLevel = num2,
				includeBodyText = CS_8_locals_12.C34vMfFZPN,
				headings = num4,
				returned = list.Count,
				truncated = (list.Count >= num),
				items = list
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU vCYDuXso2G(string P_0, int P_1, int P_2, string P_3, int P_4, int P_5, int P_6, int P_7, int P_8)
	{
		_G_c__DisplayClass19_0 CS_8_locals_25 = new _G_c__DisplayClass19_0();
		CS_8_locals_25.PxqveKcgAE = P_0;
		CS_8_locals_25.yIkvyKLbo5 = P_1;
		CS_8_locals_25.kECvXN2fmB = P_2;
		CS_8_locals_25.R0bvF75Grg = P_3;
		CS_8_locals_25.kDLvhCZhco = P_4;
		CS_8_locals_25.E0OvaTFIS7 = P_5;
		CS_8_locals_25.KYpvq4y0Ob = P_6;
		CS_8_locals_25.UF0vP5R36r = P_7;
		CS_8_locals_25.f11vABUbwN = P_8;
		return gkrTwt4m8C("read_word_section", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass19_1 CS_8_locals_32 = new _G_c__DisplayClass19_1();
			CS_8_locals_32.doc = ca8TtvS05W(app);
			Paragraph paragraph = a2QgUnQhBr(CS_8_locals_32.doc, CS_8_locals_25.PxqveKcgAE, CS_8_locals_25.yIkvyKLbo5, CS_8_locals_25.kECvXN2fmB, CS_8_locals_25.R0bvF75Grg);
			if (paragraph == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("document", "/word/document.xml");
			}
			int num = ((CS_8_locals_25.yIkvyKLbo5 > 0) ? CS_8_locals_25.yIkvyKLbo5 : EFt8ufX87I(CS_8_locals_32.doc, paragraph.Range.Start).GetValueOrDefault());
			int num2 = fSO88F0gne(paragraph);
			if (num2 < 1 || num2 > 9)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("part", "xmlData", new
				{
					headingParagraphIndex = num
				});
			}
			int num3 = Y1x8gkTvcF(() => CS_8_locals_32.doc.Paragraphs.Count);
			int num4 = num3;
			for (int num5 = num + 1; num5 <= num3; num5++)
			{
				int num6 = fSO88F0gne(CS_8_locals_32.doc.Paragraphs[num5]);
				if (num6 >= 1 && num6 <= num2)
				{
					num4 = num5 - 1;
					break;
				}
			}
			int num7 = Math.Max(0, CS_8_locals_25.kDLvhCZhco);
			int num8 = Qb88EN6Ey5(CS_8_locals_25.E0OvaTFIS7, 200, 1000);
			int num9 = Qb88EN6Ey5(CS_8_locals_25.KYpvq4y0Ob, 1000, 5000);
			int num10 = Qb88EN6Ey5(CS_8_locals_25.UF0vP5R36r, 80, 500);
			int num11 = Qb88EN6Ey5(CS_8_locals_25.f11vABUbwN, 20, 100);
			int start = paragraph.Range.Start;
			int end = CS_8_locals_32.doc.Paragraphs[num4].Range.End;
			List<jaDcyWQtOojM0IicNQ7> list = new List<jaDcyWQtOojM0IicNQ7>();
			for (int num12 = num; num12 <= num4; num12++)
			{
				Paragraph paragraph2 = CS_8_locals_32.doc.Paragraphs[num12];
				if (!YsX81TpOe7(paragraph2.Range))
				{
					list.Add(new jaDcyWQtOojM0IicNQ7
					{
						Type = "tcPr",
						RangeStart = paragraph2.Range.Start,
						Data = KFSg410uKL(paragraph2, num12, num9)
					});
				}
			}
			for (int num13 = 1; num13 <= CS_8_locals_32.doc.Tables.Count; num13++)
			{
				Table table = CS_8_locals_32.doc.Tables[num13];
				if (table.Range.Start >= start && table.Range.End <= end)
				{
					list.Add(new jaDcyWQtOojM0IicNQ7
					{
						Type = "gridSpan",
						RangeStart = table.Range.Start,
						Data = WhFgjeRETB(table, num13, num10, num11)
					});
				}
			}
			list.Sort((jaDcyWQtOojM0IicNQ7 left, jaDcyWQtOojM0IicNQ7 right) => left.RangeStart.CompareTo(right.RangeStart));
			List<object> list2 = new List<object>();
			List<object> list3 = new List<object>();
			List<object> list4 = new List<object>();
			if (num7 > list.Count)
			{
				num7 = list.Count;
			}
			int num14 = Math.Min(list.Count, num7 + num8);
			for (int num15 = num7; num15 < num14; num15++)
			{
				jaDcyWQtOojM0IicNQ7 jaDcyWQtOojM0IicNQ8 = list[num15];
				var item = new
				{
					blockIndex = num15,
					type = jaDcyWQtOojM0IicNQ8.Type,
					rangeStart = jaDcyWQtOojM0IicNQ8.RangeStart,
					data = jaDcyWQtOojM0IicNQ8.Data
				};
				list2.Add(item);
				if (jaDcyWQtOojM0IicNQ8.Type == "val")
				{
					list3.Add(jaDcyWQtOojM0IicNQ8.Data);
				}
				else if (jaDcyWQtOojM0IicNQ8.Type == "tcPr")
				{
					list4.Add(jaDcyWQtOojM0IicNQ8.Data);
				}
			}
			bool flag = num14 < list.Count;
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("vMerge", new
			{
				document = CS_8_locals_32.doc.Name,
				documentFullName = CS_8_locals_32.doc.FullName,
				heading = KFSg410uKL(paragraph, num, 500),
				startParagraphIndex = num,
				endParagraphIndex = num4,
				rangeStart = start,
				rangeEnd = end,
				startBlock = num7,
				totalBlocks = list.Count,
				returnedBlocks = list2.Count,
				hasMore = flag,
				nextStartBlock = (flag ? new int?(num14) : ((int?)null)),
				returnedParagraphs = list3.Count,
				returnedTables = list4.Count,
				truncated = flag,
				blocks = list2,
				paragraphs = list3,
				tables = list4
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU kVkDD8pm4v(int P_0, int P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass20_0 CS_8_locals_15 = new _G_c__DisplayClass20_0();
		CS_8_locals_15.XVXvxrblxn = P_0;
		CS_8_locals_15.umIvdDfpSj = P_1;
		CS_8_locals_15.Wtcvz7hlth = P_2;
		CS_8_locals_15.E0JWRCBpLv = P_3;
		return gkrTwt4m8C("read_word_tables", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass20_1 CS_8_locals_19 = new _G_c__DisplayClass20_1();
			CS_8_locals_19.doc = ca8TtvS05W(app);
			int num = Y1x8gkTvcF(() => CS_8_locals_19.doc.Tables.Count);
			if (num == 0)
			{
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("val", new
				{
					document = CS_8_locals_19.doc.Name,
					documentFullName = CS_8_locals_19.doc.FullName,
					totalTables = 0,
					tables = new object[0]
				});
			}
			int num2 = ((CS_8_locals_15.XVXvxrblxn <= 0) ? 1 : CS_8_locals_15.XVXvxrblxn);
			int num3 = ((CS_8_locals_15.XVXvxrblxn > 0) ? CS_8_locals_15.XVXvxrblxn : Math.Min(num, Qb88EN6Ey5(CS_8_locals_15.umIvdDfpSj, 5, 100)));
			if (num2 < 1 || num2 > num)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("continue", "AI 修订替换", new
				{
					totalTables = num
				});
			}
			int num4 = Qb88EN6Ey5(CS_8_locals_15.Wtcvz7hlth, 80, 500);
			int num5 = Qb88EN6Ey5(CS_8_locals_15.E0JWRCBpLv, 20, 100);
			List<object> list = new List<object>();
			for (int num6 = num2; num6 <= num3; num6++)
			{
				list.Add(WhFgjeRETB(CS_8_locals_19.doc.Tables[num6], num6, num4, num5));
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word 应用或目标文档不可用。", new
			{
				document = CS_8_locals_19.doc.Name,
				documentFullName = CS_8_locals_19.doc.FullName,
				totalTables = num,
				returned = list.Count,
				tables = list
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU nCKDTiP76T(int P_0, bool P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass21_0 CS_8_locals_13 = new _G_c__DisplayClass21_0();
		CS_8_locals_13.UiYW9EeJB2 = P_0;
		CS_8_locals_13.NMqW6fM6SQ = P_2;
		CS_8_locals_13.TjwWuYNRhv = P_3;
		CS_8_locals_13.GuoWDvWnI0 = P_1;
		return gkrTwt4m8C("read_word_comments", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass21_1 CS_8_locals_16 = new _G_c__DisplayClass21_1();
			CS_8_locals_16.doc = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(CS_8_locals_13.UiYW9EeJB2, 200, 1000);
			int num2 = Qb88EN6Ey5(CS_8_locals_13.NMqW6fM6SQ, 120, 1000);
			int num3 = ((CS_8_locals_13.TjwWuYNRhv < 0) ? 20 : Math.Min(CS_8_locals_13.TjwWuYNRhv, 200));
			List<object> list = new List<object>();
			int num4 = Y1x8gkTvcF(() => CS_8_locals_16.doc.Comments.Count);
			bool truncated = false;
			for (int num5 = 1; num5 <= num4; num5++)
			{
				Comment comment = CS_8_locals_16.doc.Comments[num5];
				if (zBSgpYfGrc(comment) == null)
				{
					if (list.Count >= num)
					{
						truncated = true;
						break;
					}
					list.Add(qXYglKDlsW(CS_8_locals_16.doc, comment, CS_8_locals_13.GuoWDvWnI0, num2, num3));
				}
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("word_not_ready", new
			{
				document = CS_8_locals_16.doc.Name,
				documentFullName = CS_8_locals_16.doc.FullName,
				totalComments = num4,
				returned = list.Count,
				truncated = truncated,
				comments = list
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU OhADgENodK(string P_0, string P_1, int P_2, string P_3, string P_4)
	{
		_G_c__DisplayClass22_0 CS_8_locals_39 = new _G_c__DisplayClass22_0();
		CS_8_locals_39.KJfW8q3L1A = P_1;
		CS_8_locals_39.kMCWIJvhU4 = P_0;
		CS_8_locals_39.ICJWijA90t = P_2;
		CS_8_locals_39.KuQWHnWj6I = P_3;
		CS_8_locals_39.xpEWQM2HQp = P_4;
		return gkrTwt4m8C("reply_word_comment", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass22_1 CS_8_locals_55 = new _G_c__DisplayClass22_1();
			CS_8_locals_55.rvpWKhLSmL = CS_8_locals_39;
			if (string.IsNullOrWhiteSpace(CS_8_locals_39.KJfW8q3L1A))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("无法将 Word 焦点切回正文区域。请点击正文后重试同一工具，不要改用无修订写入。", "main_document_focus_failed");
			}
			CS_8_locals_55.doc = ca8TtvS05W(app);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = (string.IsNullOrWhiteSpace(CS_8_locals_39.kMCWIJvhU4) ? xSQgG8pt5e(CS_8_locals_55.doc, CS_8_locals_39.ICJWijA90t, out CS_8_locals_55.DEVWU1kljM, out CS_8_locals_55.FUKWrYRDvi) : CLCgCUGOui(CS_8_locals_55.doc, CS_8_locals_39.kMCWIJvhU4, CS_8_locals_39.ICJWijA90t, out CS_8_locals_55.DEVWU1kljM, out CS_8_locals_55.FUKWrYRDvi));
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			string text = UNcg5o6WsG(CS_8_locals_55.DEVWU1kljM);
			string text2 = XPEgcZYWAO(CS_8_locals_55.FUKWrYRDvi);
			string text3 = VkRg0Eonap(CS_8_locals_39.KuQWHnWj6I);
			string text4 = VkRg0Eonap(CS_8_locals_39.xpEWQM2HQp);
			if (!string.IsNullOrWhiteSpace(text3) && !string.Equals(VkRg0Eonap(text), text3, StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前 Word 焦点仍不在正文区域，可能仍选中了批注或批注窗格。请点击正文后重试同一工具，不要改用无修订写入。", "main_document_focus_failed", new
				{
					commentToken = TkI8jwiSoi(CS_8_locals_39.kMCWIJvhU4),
					commentIndex = CS_8_locals_39.ICJWijA90t,
					expectedCommentText = text3,
					currentCommentText = text
				});
			}
			if (!string.IsNullOrWhiteSpace(text4) && !gxWgapxYhe(text2, text4))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("contains", "equals", new
				{
					commentToken = TkI8jwiSoi(CS_8_locals_39.kMCWIJvhU4),
					commentIndex = CS_8_locals_39.ICJWijA90t,
					expectedScopeText = text4,
					currentScopeText = rYN8Y355we(text2, 500)
				});
			}
			CS_8_locals_55.NkgW3GNZRG = QfAg7hyofH(CS_8_locals_55.FUKWrYRDvi) ?? Rt8gnHTE8S(CS_8_locals_55.FUKWrYRDvi);
			if (CS_8_locals_55.NkgW3GNZRG == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("startswith", "body", new
				{
					commentToken = TkI8jwiSoi(CS_8_locals_39.kMCWIJvhU4),
					commentIndex = CS_8_locals_39.ICJWijA90t,
					threadCommentIndex = GQJgya6RkO(CS_8_locals_55.FUKWrYRDvi)
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = Q7Sg1pThfx(app, CS_8_locals_55.doc, CS_8_locals_55.NkgW3GNZRG);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_55.ex9WJXHkl6 = CS_8_locals_39.KJfW8q3L1A.Trim();
			return oBKTTgZY41(app, "heading", delegate
			{
				try
				{
					Comments comments = DOYgOEfqSy(CS_8_locals_55.FUKWrYRDvi);
					if (comments == null)
					{
						return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("body", "heading", new
						{
							commentToken = TkI8jwiSoi(CS_8_locals_55.rvpWKhLSmL.kMCWIJvhU4),
							commentIndex = CS_8_locals_55.rvpWKhLSmL.ICJWijA90t,
							threadCommentIndex = GQJgya6RkO(CS_8_locals_55.FUKWrYRDvi)
						});
					}
					object Text = CS_8_locals_55.ex9WJXHkl6;
					Comment comment = comments.Add(CS_8_locals_55.NkgW3GNZRG, ref Text);
					if (comment == null)
					{
						return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("The table has merged cells or mixed widths and could not be read by row/column coordinates.", "Cell limit reached.", new
						{
							commentToken = TkI8jwiSoi(CS_8_locals_55.rvpWKhLSmL.kMCWIJvhU4),
							commentIndex = CS_8_locals_55.rvpWKhLSmL.ICJWijA90t,
							threadCommentIndex = GQJgya6RkO(CS_8_locals_55.FUKWrYRDvi)
						});
					}
					return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("[merged/unavailable]", XbygofR3TT(CS_8_locals_55.doc, CS_8_locals_55.FUKWrYRDvi, CS_8_locals_55.DEVWU1kljM, comment, CS_8_locals_55.ex9WJXHkl6));
				}
				catch (Exception ex)
				{
					return rU18qH9owXvBsPZ0iiU.g7A9nYlk8v("Some merged cells could not be read by row/column coordinates.", "Merged cells were expanded from table.Range.Cells where possible.", ex, new
					{
						commentToken = TkI8jwiSoi(CS_8_locals_55.rvpWKhLSmL.kMCWIJvhU4),
						commentIndex = CS_8_locals_55.rvpWKhLSmL.ICJWijA90t,
						threadCommentIndex = GQJgya6RkO(CS_8_locals_55.FUKWrYRDvi)
					});
				}
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU wCvD8ak3IE(string P_0, int P_1, string P_2, int P_3)
	{
		_G_c__DisplayClass23_0 CS_8_locals_19 = new _G_c__DisplayClass23_0();
		CS_8_locals_19.KSbW2tLPiW = P_3;
		CS_8_locals_19.PflW4syEJR = P_2;
		CS_8_locals_19.KLAWj0WLqu = P_1;
		CS_8_locals_19.NABWYo9U2i = P_0;
		return gkrTwt4m8C("find_word_heading", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass23_1 CS_8_locals_20 = new _G_c__DisplayClass23_1();
			CS_8_locals_20.doc = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(CS_8_locals_19.KSbW2tLPiW, 50, 300);
			string text = (CS_8_locals_19.PflW4syEJR ?? "[merged/unavailable]").Trim().ToLowerInvariant();
			List<object> list = new List<object>();
			int num2 = Y1x8gkTvcF(() => CS_8_locals_20.doc.Paragraphs.Count);
			for (int num3 = 1; num3 <= num2; num3++)
			{
				if (list.Count >= num)
				{
					break;
				}
				Paragraph paragraph = CS_8_locals_20.doc.Paragraphs[num3];
				int num4 = fSO88F0gne(paragraph);
				if (num4 >= 1 && num4 <= 9 && (CS_8_locals_19.KLAWj0WLqu <= 0 || num4 == CS_8_locals_19.KLAWj0WLqu))
				{
					string text2 = Pfn84MVBvM(paragraph.Range.Text);
					if (OYJgKddkFp(text2, CS_8_locals_19.NABWYo9U2i, text))
					{
						list.Add(new
						{
							document = CS_8_locals_20.doc.Name,
							documentFullName = CS_8_locals_20.doc.FullName,
							page = Y878QfFgDa(paragraph.Range),
							headingParagraphIndex = num3,
							paragraphIndex = num3,
							outlineLevel = num4,
							rangeStart = paragraph.Range.Start,
							rangeEnd = paragraph.Range.End,
							text = text2,
							sectionReadHint = new
							{
								tool = "| ",
								headingParagraphIndex = num3
							}
						});
					}
				}
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m(" | ", new
			{
				document = CS_8_locals_20.doc.Name,
				documentFullName = CS_8_locals_20.doc.FullName,
				query = (CS_8_locals_19.NABWYo9U2i ?? string.Empty),
				outlineLevel = ((CS_8_locals_19.KLAWj0WLqu <= 0) ? ((int?)null) : new int?(CS_8_locals_19.KLAWj0WLqu)),
				matchMode = text,
				returned = list.Count,
				truncated = (list.Count >= num),
				matches = list
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU gLSDIXjNAd(string P_0, bool P_1, bool P_2, int P_3)
	{
		_G_c__DisplayClass24_0 CS_8_locals_9 = new _G_c__DisplayClass24_0();
		CS_8_locals_9.kJMWMFbwEh = P_0;
		CS_8_locals_9.IraWb9i9wR = P_3;
		CS_8_locals_9.HMyWStZlE1 = P_1;
		CS_8_locals_9.PFZWwdLEQF = P_2;
		return gkrTwt4m8C("find_word_text", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(CS_8_locals_9.kJMWMFbwEh))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n(" |", "| ");
			}
			Document document = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(CS_8_locals_9.IraWb9i9wR, 100, 500);
			List<JLaVmTitkrKJCiFb1D5> list = jIegxGSM8E(app, document, CS_8_locals_9.kJMWMFbwEh, CS_8_locals_9.HMyWStZlE1, CS_8_locals_9.PFZWwdLEQF, num);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m(" | ", o9s8V9QIyZ(document, list, num));
		});
	}

	public rU18qH9owXvBsPZ0iiU HBMDif1QJi(string P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass25_0 CS_8_locals_7 = new _G_c__DisplayClass25_0();
		CS_8_locals_7.IOPWLBITxB = P_0;
		CS_8_locals_7.sjVWs8uNuc = P_2;
		CS_8_locals_7.EyLWlEVNRV = P_1;
		return gkrTwt4m8C("find_word_regex", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(CS_8_locals_7.IOPWLBITxB))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("---", " |");
			}
			Document document = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(CS_8_locals_7.sjVWs8uNuc, 100, 500);
			List<GrMBSXi2HFwNBUhA3m6> list = wS88Rn9xSe(document, CS_8_locals_7.IOPWLBITxB, CS_8_locals_7.EyLWlEVNRV, num);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("commentToken", pMT896JE6T(document, list, num));
		});
	}

	public rU18qH9owXvBsPZ0iiU N1hDHhepUD(string P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass26_0 CS_8_locals_10 = new _G_c__DisplayClass26_0();
		CS_8_locals_10.EJdWmMjUeA = P_0;
		CS_8_locals_10.GtCWo3eG2v = P_2;
		CS_8_locals_10.XQ2WGdsSr5 = P_1;
		return gkrTwt4m8C("find_word_table_text", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(CS_8_locals_10.EJdWmMjUeA))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("index", "author");
			}
			Document document = ca8TtvS05W(app);
			int num = Qb88EN6Ey5(CS_8_locals_10.GtCWo3eG2v, 100, 500);
			List<object> list = new List<object>();
			for (int i = 1; i <= document.Tables.Count; i++)
			{
				if (list.Count >= num)
				{
					break;
				}
				_G_c__DisplayClass26_1 CS_8_locals_12 = new _G_c__DisplayClass26_1();
				CS_8_locals_12.sEvWprZlaY = document.Tables[i];
				int num2 = Ex5TMxi7X1(() => CS_8_locals_12.sEvWprZlaY.Range.End, 0);
				Range range = CS_8_locals_12.sEvWprZlaY.Range.Duplicate;
				while (list.Count < num)
				{
					range.Find.ClearFormatting();
					Find find = range.Find;
					object FindText = CS_8_locals_10.EJdWmMjUeA;
					object MatchCase = CS_8_locals_10.XQ2WGdsSr5;
					object MatchWholeWord = false;
					object MatchWildcards = false;
					object MatchSoundsLike = false;
					object MatchAllWordForms = false;
					object Forward = true;
					object Wrap = WdFindWrap.wdFindStop;
					object Format = false;
					object ReplaceWith = Type.Missing;
					object Replace = Type.Missing;
					object MatchKashida = Type.Missing;
					object MatchDiacritics = Type.Missing;
					object MatchAlefHamza = Type.Missing;
					object MatchControl = Type.Missing;
					if (!find.Execute(ref FindText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref ReplaceWith, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl) || range.Start >= range.End)
					{
						break;
					}
					Range duplicate = range.Duplicate;
					list.Add(MAygkj8OcZ(document, CS_8_locals_12.sEvWprZlaY, i, duplicate));
					int num3 = Math.Max(duplicate.End, duplicate.Start + 1);
					if (num2 <= 0 || num3 >= num2)
					{
						break;
					}
					try
					{
						MatchControl = num3;
						MatchAlefHamza = num2;
						range = document.Range(ref MatchControl, ref MatchAlefHamza);
					}
					catch
					{
						break;
					}
				}
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("date", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				returned = list.Count,
				truncated = (list.Count >= num),
				matches = list
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU NQvDQtno1R(int P_0, int P_1)
	{
		_G_c__DisplayClass27_0 CS_8_locals_4 = new _G_c__DisplayClass27_0();
		CS_8_locals_4.yBuWn9FBJs = P_0;
		CS_8_locals_4.NSnW7NMjGb = P_1;
		return gkrTwt4m8C("select_word_range", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Range range = fyVTLmFfU6(document, CS_8_locals_4.yBuWn9FBJs, CS_8_locals_4.NSnW7NMjGb);
			document.Activate();
			range.Select();
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("done", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = Y878QfFgDa(range),
				rangeStart = range.Start,
				rangeEnd = range.End
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU IapD1WXBiw(int P_0)
	{
		_G_c__DisplayClass28_0 CS_8_locals_5 = new _G_c__DisplayClass28_0();
		CS_8_locals_5.GJUWc1Ct7n = P_0;
		return gkrTwt4m8C("select_word_table", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			if (CS_8_locals_5.GJUWc1Ct7n < 1 || CS_8_locals_5.GJUWc1Ct7n > document.Tables.Count)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("commentText", "replyCount", new
				{
					totalTables = document.Tables.Count
				});
			}
			Table table = document.Tables[CS_8_locals_5.GJUWc1Ct7n];
			document.Activate();
			table.Range.Select();
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("repliesReturned", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = CS_8_locals_5.GJUWc1Ct7n,
				page = Y878QfFgDa(table.Range),
				rangeStart = table.Range.Start,
				rangeEnd = table.Range.End
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU OnvDrm8kGg(string P_0)
	{
		_G_c__DisplayClass29_0 CS_8_locals_5 = new _G_c__DisplayClass29_0();
		CS_8_locals_5.po5WyTWvh4 = P_0;
		return gkrTwt4m8C("add_word_comment_at_selection", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass29_1 CS_8_locals_17 = new _G_c__DisplayClass29_1();
			CS_8_locals_17.DTFWhrapJW = CS_8_locals_5;
			if (string.IsNullOrWhiteSpace(CS_8_locals_5.po5WyTWvh4))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("repliesTruncated", "replies");
			}
			CS_8_locals_17.doc = ca8TtvS05W(app);
			CS_8_locals_17.IMfWFN3Nni = app.Selection;
			if (CS_8_locals_17.IMfWFN3Nni == null || CS_8_locals_17.IMfWFN3Nni.Range == null || string.IsNullOrWhiteSpace(Pfn84MVBvM(CS_8_locals_17.IMfWFN3Nni.Range.Text)))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("anchorRangeStart", "anchorRangeEnd");
			}
			return (!XMVgr0DwLb(CS_8_locals_17.IMfWFN3Nni.Range)) ? rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("anchorText", "commentToken") : oBKTTgZY41(app, "index", delegate
			{
				Comments comments = CS_8_locals_17.doc.Comments;
				Range range = CS_8_locals_17.IMfWFN3Nni.Range;
				object Text = CS_8_locals_17.DTFWhrapJW.po5WyTWvh4.Trim();
				Comment comment = comments.Add(range, ref Text);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("author", WWcgsjc2XU(CS_8_locals_17.doc, CS_8_locals_17.IMfWFN3Nni.Range, comment.Index, CS_8_locals_17.DTFWhrapJW.po5WyTWvh4));
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU qJwDJmPsvM(int P_0, int P_1, string P_2)
	{
		_G_c__DisplayClass30_0 CS_8_locals_12 = new _G_c__DisplayClass30_0();
		CS_8_locals_12.iYMWq6x2ON = P_2;
		CS_8_locals_12.bHXWPpRCjJ = P_0;
		CS_8_locals_12.WKMWApZUrG = P_1;
		return gkrTwt4m8C("add_word_comment_at_range", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass30_1 CS_8_locals_20 = new _G_c__DisplayClass30_1();
			CS_8_locals_20.NcsW0mbLbI = CS_8_locals_12;
			if (string.IsNullOrWhiteSpace(CS_8_locals_12.iYMWq6x2ON))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("date", "done");
			}
			CS_8_locals_20.doc = ca8TtvS05W(app);
			CS_8_locals_20.QVSWWNpqS5 = fyVTLmFfU6(CS_8_locals_20.doc, CS_8_locals_12.bHXWPpRCjJ, CS_8_locals_12.WKMWApZUrG);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = Q7Sg1pThfx(app, CS_8_locals_20.doc, CS_8_locals_20.QVSWWNpqS5);
			return (rU18qH9owXvBsPZ0iiU2 != null) ? rU18qH9owXvBsPZ0iiU2 : oBKTTgZY41(app, "commentText", delegate
			{
				Comments comments = CS_8_locals_20.doc.Comments;
				Range range = CS_8_locals_20.QVSWWNpqS5;
				object Text = CS_8_locals_20.NcsW0mbLbI.iYMWq6x2ON.Trim();
				Comment comment = comments.Add(range, ref Text);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("当前没有打开的 Word 文档。", WWcgsjc2XU(CS_8_locals_20.doc, CS_8_locals_20.QVSWWNpqS5, comment.Index, CS_8_locals_20.NcsW0mbLbI.iYMWq6x2ON));
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU YWPD3BVAmY(int P_0, int P_1, int P_2, string P_3)
	{
		_G_c__DisplayClass31_0 CS_8_locals_13 = new _G_c__DisplayClass31_0();
		CS_8_locals_13.JbiWxBXGfL = P_3;
		CS_8_locals_13.rNUWdaMass = P_0;
		CS_8_locals_13.r75WzWXpYy = P_1;
		CS_8_locals_13.FYo0RQ60pr = P_2;
		return gkrTwt4m8C("add_word_comment_at_paragraph_range", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass31_1 CS_8_locals_22 = new _G_c__DisplayClass31_1();
			CS_8_locals_22.JKv09xg9ic = CS_8_locals_13;
			if (string.IsNullOrWhiteSpace(CS_8_locals_13.JbiWxBXGfL))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("no_document", "commentToken 或正整数 commentIndex 至少需要提供一个。");
			}
			CS_8_locals_22.doc = ca8TtvS05W(app);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = JXpTldftkV(CS_8_locals_22.doc, CS_8_locals_13.rNUWdaMass, CS_8_locals_13.r75WzWXpYy, CS_8_locals_13.FYo0RQ60pr, out CS_8_locals_22.oo50BXZjWO);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = Q7Sg1pThfx(app, CS_8_locals_22.doc, CS_8_locals_22.oo50BXZjWO);
			return (rU18qH9owXvBsPZ0iiU3 != null) ? rU18qH9owXvBsPZ0iiU3 : oBKTTgZY41(app, "invalid_arguments", delegate
			{
				Comments comments = CS_8_locals_22.doc.Comments;
				Range range = CS_8_locals_22.oo50BXZjWO;
				object Text = CS_8_locals_22.JKv09xg9ic.JbiWxBXGfL.Trim();
				Comment comment = comments.Add(range, ref Text);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("未找到指定 index 的 Word 批注。请重新读取批注后再回复。", WWcgsjc2XU(CS_8_locals_22.doc, CS_8_locals_22.oo50BXZjWO, comment.Index, CS_8_locals_22.JKv09xg9ic.JbiWxBXGfL));
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU K64DU5dI6q(int P_0, int P_1, int P_2, string P_3)
	{
		_G_c__DisplayClass32_0 CS_8_locals_14 = new _G_c__DisplayClass32_0();
		CS_8_locals_14.Plj0uww7Lb = P_3;
		CS_8_locals_14.yl70DLkIZI = P_0;
		CS_8_locals_14.MVT0TM4BqQ = P_1;
		CS_8_locals_14.lDB0gUfIHi = P_2;
		return gkrTwt4m8C("add_word_comment_at_table_cell", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass32_1 CS_8_locals_29 = new _G_c__DisplayClass32_1();
			CS_8_locals_29.qQI0ilX6hg = CS_8_locals_14;
			if (string.IsNullOrWhiteSpace(CS_8_locals_14.Plj0uww7Lb))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("comment_not_found", "当前没有打开的 Word 文档。");
			}
			CS_8_locals_29.doc = ca8TtvS05W(app);
			CS_8_locals_29.U3N0IvjZMn = DOQTmyyLCk(CS_8_locals_29.doc, CS_8_locals_14.yl70DLkIZI, CS_8_locals_14.MVT0TM4BqQ, CS_8_locals_14.lDB0gUfIHi);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = Q7Sg1pThfx(app, CS_8_locals_29.doc, CS_8_locals_29.U3N0IvjZMn.Range);
			return (rU18qH9owXvBsPZ0iiU2 != null) ? rU18qH9owXvBsPZ0iiU2 : oBKTTgZY41(app, "no_document", delegate
			{
				Comments comments = CS_8_locals_29.doc.Comments;
				Range range = CS_8_locals_29.U3N0IvjZMn.Range;
				object Text = CS_8_locals_29.qQI0ilX6hg.Plj0uww7Lb.Trim();
				Comment comment = comments.Add(range, ref Text);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("commentToken 格式无效。请使用 read_word_comments 返回的 commentToken。", new
				{
					document = CS_8_locals_29.doc.Name,
					documentFullName = CS_8_locals_29.doc.FullName,
					commentIndex = comment.Index,
					tableIndex = CS_8_locals_29.qQI0ilX6hg.yl70DLkIZI,
					rowIndex = CS_8_locals_29.qQI0ilX6hg.MVT0TM4BqQ,
					columnIndex = CS_8_locals_29.qQI0ilX6hg.lDB0gUfIHi,
					page = Y878QfFgDa(CS_8_locals_29.U3N0IvjZMn.Range),
					rangeStart = CS_8_locals_29.U3N0IvjZMn.Range.Start,
					rangeEnd = CS_8_locals_29.U3N0IvjZMn.Range.End,
					targetPreview = rYN8Y355we(Pfn84MVBvM(CS_8_locals_29.U3N0IvjZMn.Range.Text), 240),
					comment = CS_8_locals_29.qQI0ilX6hg.Plj0uww7Lb.Trim()
				});
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU AqFDKAiaGP(int P_0, string P_1, string P_2, bool P_3)
	{
		_G_c__DisplayClass33_0 CS_8_locals_20 = new _G_c__DisplayClass33_0();
		CS_8_locals_20.VVi0Qol0Kp = P_0;
		CS_8_locals_20.li901Ehx74 = P_1;
		CS_8_locals_20.T0P0rR1iC0 = P_2;
		CS_8_locals_20.M430JdWIcm = P_3;
		return gkrTwt4m8C("insert_word_paragraph", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass33_1 CS_8_locals_43 = new _G_c__DisplayClass33_1();
			CS_8_locals_43.ilr02ghHeZ = CS_8_locals_20;
			CS_8_locals_43.doc = ca8TtvS05W(app);
			CS_8_locals_43.tKg0UkP7mM = U09ToZPpqq(CS_8_locals_43.doc, CS_8_locals_20.VVi0Qol0Kp);
			CS_8_locals_43.it80KSGhhX = (CS_8_locals_20.li901Ehx74 ?? "invalid_arguments").Trim().ToLowerInvariant();
			if (CS_8_locals_43.it80KSGhhX != "未找到指定 commentToken 对应的 Word 批注。请重新读取批注后再回复。" && CS_8_locals_43.it80KSGhhX != "comment_token_not_found")
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("commentToken 匹配到多条 Word 批注。请重新读取批注后使用新的 token。", "comment_token_ambiguous", new
				{
					position = CS_8_locals_20.li901Ehx74
				});
			}
			CS_8_locals_43.JMl0EihMlK = CS_8_locals_20.T0P0rR1iC0 ?? string.Empty;
			return PPXTOUDVLE(CS_8_locals_43.doc, CS_8_locals_20.M430JdWIcm, delegate
			{
				Range duplicate = CS_8_locals_43.tKg0UkP7mM.Range.Duplicate;
				if (CS_8_locals_43.it80KSGhhX == "comment-token-v1")
				{
					int start = duplicate.Start;
					object Direction = WdCollapseDirection.wdCollapseStart;
					duplicate.Collapse(ref Direction);
					duplicate.InsertBefore(CS_8_locals_43.JMl0EihMlK + "-");
					return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("CMT-", new
					{
						document = CS_8_locals_43.doc.Name,
						documentFullName = CS_8_locals_43.doc.FullName,
						paragraphIndex = CS_8_locals_43.ilr02ghHeZ.VVi0Qol0Kp,
						position = CS_8_locals_43.it80KSGhhX,
						page = Y878QfFgDa(CS_8_locals_43.tKg0UkP7mM.Range),
						rangeStart = start,
						useTrackChanges = CS_8_locals_43.ilr02ghHeZ.M430JdWIcm,
						characters = CS_8_locals_43.JMl0EihMlK.Length,
						textPreview = rYN8Y355we(CS_8_locals_43.JMl0EihMlK, 240)
					});
				}
				int num = Math.Max(CS_8_locals_43.tKg0UkP7mM.Range.Start, CS_8_locals_43.tKg0UkP7mM.Range.End - 1);
				duplicate.SetRange(num, num);
				duplicate.InsertAfter("CMT-" + CS_8_locals_43.JMl0EihMlK);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("-", new
				{
					document = CS_8_locals_43.doc.Name,
					documentFullName = CS_8_locals_43.doc.FullName,
					paragraphIndex = CS_8_locals_43.ilr02ghHeZ.VVi0Qol0Kp,
					position = CS_8_locals_43.it80KSGhhX,
					page = Y878QfFgDa(CS_8_locals_43.tKg0UkP7mM.Range),
					rangeStart = num,
					useTrackChanges = CS_8_locals_43.ilr02ghHeZ.M430JdWIcm,
					characters = CS_8_locals_43.JMl0EihMlK.Length,
					textPreview = rYN8Y355we(CS_8_locals_43.JMl0EihMlK, 240)
				});
			}, app, CS_8_locals_43.tKg0UkP7mM.Range, "CMT");
		});
	}

	public rU18qH9owXvBsPZ0iiU bRgDEmb7kg(int P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass34_0 CS_8_locals_49 = new _G_c__DisplayClass34_0();
		CS_8_locals_49.VSY0j7rVLY = P_2;
		CS_8_locals_49.rIb0YiqNvi = P_0;
		CS_8_locals_49.tBl0ZKmmgV = P_1;
		return gkrTwt4m8C("set_word_paragraph_outline_level", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass34_1 CS_8_locals_64 = new _G_c__DisplayClass34_1();
			CS_8_locals_64.ENA0sjUILf = CS_8_locals_49;
			if (CS_8_locals_49.VSY0j7rVLY < 0 || CS_8_locals_49.VSY0j7rVLY > 9)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("\\\\r\\\\n", "\n", new
				{
					outlineLevel = CS_8_locals_49.VSY0j7rVLY
				});
			}
			if (CS_8_locals_49.rIb0YiqNvi < 0 || CS_8_locals_49.tBl0ZKmmgV < 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("\\\\r", "\n", new
				{
					startParagraphIndex = CS_8_locals_49.rIb0YiqNvi,
					endParagraphIndex = CS_8_locals_49.tBl0ZKmmgV
				});
			}
			if (CS_8_locals_49.rIb0YiqNvi == 0 && CS_8_locals_49.tBl0ZKmmgV > 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("\\\\n", "\n", new
				{
					startParagraphIndex = CS_8_locals_49.rIb0YiqNvi,
					endParagraphIndex = CS_8_locals_49.tBl0ZKmmgV
				});
			}
			if (CS_8_locals_49.rIb0YiqNvi > 0 && CS_8_locals_49.tBl0ZKmmgV > 0 && CS_8_locals_49.tBl0ZKmmgV < CS_8_locals_49.rIb0YiqNvi)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("\r\n", "\n", new
				{
					startParagraphIndex = CS_8_locals_49.rIb0YiqNvi,
					endParagraphIndex = CS_8_locals_49.tBl0ZKmmgV
				});
			}
			CS_8_locals_64.doc = ca8TtvS05W(app);
			CS_8_locals_64.doc.Activate();
			int num = Y1x8gkTvcF(() => CS_8_locals_64.doc.Paragraphs.Count);
			if (CS_8_locals_49.rIb0YiqNvi > num)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("\\s+", " ", new
				{
					startParagraphIndex = CS_8_locals_49.rIb0YiqNvi,
					totalParagraphs = num
				});
			}
			if (CS_8_locals_49.tBl0ZKmmgV > num)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("tableRange", "cell", new
				{
					endParagraphIndex = CS_8_locals_49.tBl0ZKmmgV,
					totalParagraphs = num
				});
			}
			CS_8_locals_64.tt60bBXNOI = FMtTCCF91i(app, CS_8_locals_64.doc, CS_8_locals_49.rIb0YiqNvi, CS_8_locals_49.tBl0ZKmmgV);
			if (CS_8_locals_64.tt60bBXNOI.Count == 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n(":", "NameLocal", new
				{
					startParagraphIndex = CS_8_locals_49.rIb0YiqNvi,
					endParagraphIndex = CS_8_locals_49.tBl0ZKmmgV
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = Q7Sg1pThfx(app, CS_8_locals_64.doc, CS_8_locals_64.tt60bBXNOI[0].Paragraph.Range);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			CS_8_locals_64.wKn0SWcs43 = PZD8ivf3BX(CS_8_locals_49.VSY0j7rVLY);
			CS_8_locals_64.r4c0LaglLY = new List<object>();
			CS_8_locals_64.YFL0wKX8uQ = 0;
			CS_8_locals_64.AHE0tweHQB = 0;
			DyITDXSmDr(app, "Name", delegate
			{
				foreach (WKGvoki3QLNecqlT5em item in CS_8_locals_64.tt60bBXNOI)
				{
					Paragraph paragraph = item.Paragraph;
					int num2 = cjC8ImVBAy(fSO88F0gne(paragraph));
					string styleName = kBH8HcK06n(paragraph);
					string excerpt = rYN8Y355we(Pfn84MVBvM(paragraph.Range.Text), 160);
					bool flag = false;
					bool flag2 = false;
					string text = string.Empty;
					try
					{
						paragraph.OutlineLevel = (WdOutlineLevel)CS_8_locals_64.wKn0SWcs43;
						int num3 = cjC8ImVBAy(fSO88F0gne(paragraph));
						flag2 = num3 == CS_8_locals_64.ENA0sjUILf.VSY0j7rVLY;
						flag = flag2 && num2 != num3;
						if (!flag2)
						{
							text = "System.__ComObject";
						}
					}
					catch (Exception ex)
					{
						text = ex.GetBaseException().Message;
					}
					int afterOutlineLevel = cjC8ImVBAy(fSO88F0gne(paragraph));
					if (flag)
					{
						CS_8_locals_64.YFL0wKX8uQ++;
					}
					if (!flag2)
					{
						CS_8_locals_64.AHE0tweHQB++;
					}
					CS_8_locals_64.r4c0LaglLY.Add(new
					{
						paragraphIndex = item.ParagraphIndex,
						rangeStart = paragraph.Range.Start,
						rangeEnd = paragraph.Range.End,
						page = Y878QfFgDa(paragraph.Range),
						styleName = styleName,
						beforeOutlineLevel = num2,
						targetOutlineLevel = CS_8_locals_64.ENA0sjUILf.VSY0j7rVLY,
						afterOutlineLevel = afterOutlineLevel,
						changed = flag,
						success = flag2,
						error = (string.IsNullOrWhiteSpace(text) ? null : text),
						excerpt = excerpt
					});
				}
			});
			var anon = new
			{
				document = CS_8_locals_64.doc.Name,
				documentFullName = CS_8_locals_64.doc.FullName,
				startParagraphIndex = CS_8_locals_49.rIb0YiqNvi,
				endParagraphIndex = CS_8_locals_49.tBl0ZKmmgV,
				targetOutlineLevel = CS_8_locals_49.VSY0j7rVLY,
				targetOutlineKind = ((CS_8_locals_49.VSY0j7rVLY == 0) ? "[ \\\\t]+" : " "),
				totalParagraphs = CS_8_locals_64.tt60bBXNOI.Count,
				changedCount = CS_8_locals_64.YFL0wKX8uQ,
				failedCount = CS_8_locals_64.AHE0tweHQB,
				paragraphs = CS_8_locals_64.r4c0LaglLY
			};
			return (CS_8_locals_64.AHE0tweHQB == CS_8_locals_64.tt60bBXNOI.Count) ? rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("...", "...", anon) : rU18qH9owXvBsPZ0iiU.nt99CvEC4m((CS_8_locals_64.AHE0tweHQB > 0) ? "..." : "get_current_word_context", anon);
		});
	}

	public rU18qH9owXvBsPZ0iiU D79D2xoiP1(int P_0, int P_1, string P_2, string P_3, string P_4, bool P_5, bool P_6)
	{
		_G_c__DisplayClass35_0 CS_8_locals_45 = new _G_c__DisplayClass35_0();
		CS_8_locals_45.U3X0Nu9BTy = P_3;
		CS_8_locals_45.e950mqvdUW = P_4;
		CS_8_locals_45.Mb30oMnlMg = P_2;
		CS_8_locals_45.sVt0G0vaxH = P_0;
		CS_8_locals_45.hBZ0CqvlP0 = P_1;
		CS_8_locals_45.ftr0pKNh6J = P_5;
		CS_8_locals_45.Pnj0OjaV8W = P_6;
		return gkrTwt4m8C("fill_word_table_cells_by_model", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass35_1 CS_8_locals_69 = new _G_c__DisplayClass35_1();
			CS_8_locals_69.EqE0cr5Iep = CS_8_locals_45;
			string a = (CS_8_locals_45.U3X0Nu9BTy ?? "preview_word_document").Trim().ToLowerInvariant();
			if (!string.Equals(a, "preview_word_selection", StringComparison.Ordinal) && !string.Equals(a, "read_word_range", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("read_word_paragraphs", "read_word_outline", new
				{
					mode = CS_8_locals_45.U3X0Nu9BTy
				});
			}
			if (string.Equals(a, "read_word_section", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(CS_8_locals_45.e950mqvdUW))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("read_word_tables", "read_word_comments");
			}
			List<OGfXaqipg6f7TvJ8dbc> list;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = XIPTkGpqwW(CS_8_locals_45.Mb30oMnlMg, out list);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			CS_8_locals_69.doc = ca8TtvS05W(app);
			Range range;
			try
			{
				range = fyVTLmFfU6(CS_8_locals_69.doc, CS_8_locals_45.sVt0G0vaxH, CS_8_locals_45.hBZ0CqvlP0);
			}
			catch (Exception ex)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("reply_word_comment", "find_word_heading", new
				{
					rangeStart = CS_8_locals_45.sVt0G0vaxH,
					rangeEnd = CS_8_locals_45.hBZ0CqvlP0,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = yC3TxlssVj(range, list, out CS_8_locals_69.NsB07pVikL);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_69.T7P05P0rNv = EW0g9hbK9x(CS_8_locals_69.doc, CS_8_locals_45.sVt0G0vaxH, CS_8_locals_45.hBZ0CqvlP0, CS_8_locals_69.NsB07pVikL);
			object obj = iLJTdpgWxW(CS_8_locals_69.doc, CS_8_locals_45.sVt0G0vaxH, CS_8_locals_45.hBZ0CqvlP0, CS_8_locals_45.ftr0pKNh6J, CS_8_locals_45.Pnj0OjaV8W, CS_8_locals_69.T7P05P0rNv, CS_8_locals_69.NsB07pVikL);
			if (string.Equals(a, "find_word_text", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("find_word_regex", obj);
			}
			if (CS_8_locals_69.NsB07pVikL.Count((ICsQGCih5R8sKlcw64k change) => !change.Writable) > 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("find_word_table_text", "select_word_range", obj);
			}
			if (!mx2g6RGYxJ(CS_8_locals_69.T7P05P0rNv, CS_8_locals_45.e950mqvdUW))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("select_word_table", "add_word_comment_at_selection", new
				{
					rangeStart = CS_8_locals_45.sVt0G0vaxH,
					rangeEnd = CS_8_locals_45.hBZ0CqvlP0,
					expectedPreviewToken = CS_8_locals_45.e950mqvdUW,
					currentPreviewToken = CS_8_locals_69.T7P05P0rNv,
					preview = obj
				});
			}
			Range range2 = ((CS_8_locals_69.NsB07pVikL.Count > 0 && CS_8_locals_69.NsB07pVikL[0].Cell != null) ? NPITpB49xY(CS_8_locals_69.NsB07pVikL[0].Cell) : range);
			return PPXTOUDVLE(CS_8_locals_69.doc, CS_8_locals_45.Pnj0OjaV8W, delegate
			{
				List<object> list2 = new List<object>();
				int num = 0;
				for (int i = 0; i < CS_8_locals_69.NsB07pVikL.Count; i++)
				{
					_G_c__DisplayClass35_2 CS_8_locals_71 = new _G_c__DisplayClass35_2();
					CS_8_locals_71.T5O0X047np = CS_8_locals_69.NsB07pVikL[i];
					bool flag2;
					string text;
					bool flag = bIRgTubXiW(CS_8_locals_71.T5O0X047np.Cell, CS_8_locals_71.T5O0X047np.NewText, out flag2, out text);
					if (flag && flag2)
					{
						num++;
					}
					list2.Add(new
					{
						requestIndex = CS_8_locals_71.T5O0X047np.RequestIndex,
						localTableIndex = CS_8_locals_71.T5O0X047np.LocalTableIndex,
						rowIndex = CS_8_locals_71.T5O0X047np.RowIndex,
						columnIndex = CS_8_locals_71.T5O0X047np.ColumnIndex,
						isHeader = CS_8_locals_71.T5O0X047np.IsHeader,
						page = Y878QfFgDa(CS_8_locals_71.T5O0X047np.Cell.Range),
						rangeStart = Ex5TMxi7X1(() => CS_8_locals_71.T5O0X047np.Cell.Range.Start, CS_8_locals_71.T5O0X047np.RangeStart),
						rangeEnd = Ex5TMxi7X1(() => CS_8_locals_71.T5O0X047np.Cell.Range.End, CS_8_locals_71.T5O0X047np.RangeEnd),
						oldText = CS_8_locals_71.T5O0X047np.OldText,
						newText = CS_8_locals_71.T5O0X047np.NewText,
						changed = (flag && flag2),
						success = flag,
						error = (flag ? null : text)
					});
				}
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("add_word_comment_at_range", new
				{
					document = CS_8_locals_69.doc.Name,
					documentFullName = CS_8_locals_69.doc.FullName,
					rangeStart = CS_8_locals_69.EqE0cr5Iep.sVt0G0vaxH,
					rangeEnd = CS_8_locals_69.EqE0cr5Iep.hBZ0CqvlP0,
					totalRequests = CS_8_locals_69.NsB07pVikL.Count,
					changed = num,
					useTrackChanges = CS_8_locals_69.EqE0cr5Iep.Pnj0OjaV8W,
					allowHeaderEdit = CS_8_locals_69.EqE0cr5Iep.ftr0pKNh6J,
					previewToken = CS_8_locals_69.T7P05P0rNv,
					results = list2
				});
			}, app, range2, "add_word_comment_at_paragraph_range");
		});
	}

	public rU18qH9owXvBsPZ0iiU y8aD4JhP6i(int P_0, int P_1, int P_2, int P_3, string P_4, int P_5, string P_6, string P_7, bool P_8, string P_9)
	{
		_G_c__DisplayClass36_0 CS_8_locals_53 = new _G_c__DisplayClass36_0();
		CS_8_locals_53.oqq0hsqqAI = P_6;
		CS_8_locals_53.skx0ahCXbo = P_4;
		CS_8_locals_53.us70qblyBW = P_5;
		CS_8_locals_53.svA0P2EZkb = P_7;
		CS_8_locals_53.YXU0AnhhVg = P_0;
		CS_8_locals_53.PEy0vuw4bd = P_1;
		CS_8_locals_53.emx0WPoKaL = P_2;
		CS_8_locals_53.ivn00MgJWx = P_3;
		CS_8_locals_53.MyU0kcBnLJ = P_8;
		CS_8_locals_53.NcM0xJMhM5 = P_9;
		return gkrTwt4m8C("insert_word_table_rows_by_model", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass36_1 CS_8_locals_80 = new _G_c__DisplayClass36_1();
			CS_8_locals_80.gZUkBpLoZF = CS_8_locals_53;
			CS_8_locals_80.F6s0zNQf7g = app;
			string a = (CS_8_locals_53.oqq0hsqqAI ?? "add_word_comment_at_table_cell").Trim().ToLowerInvariant();
			if (!string.Equals(a, "insert_word_paragraph", StringComparison.Ordinal) && !string.Equals(a, "set_word_paragraph_outline_level", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("fill_word_table_cells_by_model", "insert_word_table_rows_by_model", new
				{
					mode = CS_8_locals_53.oqq0hsqqAI
				});
			}
			string text = vq0TXPC0AY(CS_8_locals_53.skx0ahCXbo);
			if (text == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("insert_word_table_at_range", "replace_word_range_with_track_changes", new
				{
					position = CS_8_locals_53.skx0ahCXbo
				});
			}
			if (CS_8_locals_53.us70qblyBW < 1 || CS_8_locals_53.us70qblyBW > 20)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("replace_word_selection_with_track_changes", "batch_replace_word_text_execute", new
				{
					count = CS_8_locals_53.us70qblyBW,
					min = 1,
					max = 20
				});
			}
			if (string.Equals(a, "export_word_comments", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(CS_8_locals_53.svA0P2EZkb))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("adjust_selected_word_tables_format", "adjust_selected_word_paragraphs_format");
			}
			CS_8_locals_80.doc = ca8TtvS05W(CS_8_locals_80.F6s0zNQf7g);
			Range range;
			try
			{
				range = fyVTLmFfU6(CS_8_locals_80.doc, CS_8_locals_53.YXU0AnhhVg, CS_8_locals_53.PEy0vuw4bd);
			}
			catch (Exception ex)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_", "Word table adjustment config read.", new
				{
					rangeStart = CS_8_locals_53.YXU0AnhhVg,
					rangeEnd = CS_8_locals_53.PEy0vuw4bd,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = NioTFK99GE(range, CS_8_locals_53.emx0WPoKaL, CS_8_locals_53.ivn00MgJWx, text, CS_8_locals_53.us70qblyBW, CS_8_locals_53.MyU0kcBnLJ, CS_8_locals_53.NcM0xJMhM5, out CS_8_locals_80.TGIkR4H0Wl);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			CS_8_locals_80.g0ikVawc3w = lKeTPQlpbN(CS_8_locals_80.doc, CS_8_locals_53.YXU0AnhhVg, CS_8_locals_53.PEy0vuw4bd, CS_8_locals_80.TGIkR4H0Wl);
			object obj = fYyThhstYU(CS_8_locals_80.doc, CS_8_locals_53.YXU0AnhhVg, CS_8_locals_53.PEy0vuw4bd, CS_8_locals_80.g0ikVawc3w, CS_8_locals_80.TGIkR4H0Wl);
			if (string.Equals(a, "table", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("表格配置_方案名", obj);
			}
			return (!mx2g6RGYxJ(CS_8_locals_80.g0ikVawc3w, CS_8_locals_53.svA0P2EZkb)) ? rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_单元格_上边距", "0", new
			{
				rangeStart = CS_8_locals_53.YXU0AnhhVg,
				rangeEnd = CS_8_locals_53.PEy0vuw4bd,
				expectedPreviewToken = CS_8_locals_53.svA0P2EZkb,
				currentPreviewToken = CS_8_locals_80.g0ikVawc3w,
				preview = obj
			}) : PPXTOUDVLE(CS_8_locals_80.doc, CS_8_locals_53.MyU0kcBnLJ, delegate
			{
				if (!M4PTA9V6B2(CS_8_locals_80.F6s0zNQf7g, CS_8_locals_80.TGIkR4H0Wl.AnchorCell, CS_8_locals_80.TGIkR4H0Wl.Position, CS_8_locals_80.TGIkR4H0Wl.Count, out var error))
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_单元格_下边距", "0", new
					{
						rangeStart = CS_8_locals_80.gZUkBpLoZF.YXU0AnhhVg,
						rangeEnd = CS_8_locals_80.gZUkBpLoZF.PEy0vuw4bd,
						LocalTableIndex = CS_8_locals_80.TGIkR4H0Wl.LocalTableIndex,
						AnchorRowIndex = CS_8_locals_80.TGIkR4H0Wl.AnchorRowIndex,
						Position = CS_8_locals_80.TGIkR4H0Wl.Position,
						Count = CS_8_locals_80.TGIkR4H0Wl.Count,
						error = error
					});
				}
				HbPTWYrAup(CS_8_locals_80.TGIkR4H0Wl.Table, out var rowsAfter, out var columnsAfter);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("表格_单元格_左边距", new
				{
					document = CS_8_locals_80.doc.Name,
					documentFullName = CS_8_locals_80.doc.FullName,
					rangeStart = CS_8_locals_80.gZUkBpLoZF.YXU0AnhhVg,
					rangeEnd = CS_8_locals_80.gZUkBpLoZF.PEy0vuw4bd,
					localTableIndex = CS_8_locals_80.TGIkR4H0Wl.LocalTableIndex,
					anchorRowIndex = CS_8_locals_80.TGIkR4H0Wl.AnchorRowIndex,
					position = CS_8_locals_80.TGIkR4H0Wl.Position,
					count = CS_8_locals_80.TGIkR4H0Wl.Count,
					useTrackChanges = CS_8_locals_80.gZUkBpLoZF.MyU0kcBnLJ,
					previewToken = CS_8_locals_80.g0ikVawc3w,
					rowsBefore = CS_8_locals_80.TGIkR4H0Wl.RowsBefore,
					rowsAfter = rowsAfter,
					columnsBefore = CS_8_locals_80.TGIkR4H0Wl.ColumnsBefore,
					columnsAfter = columnsAfter,
					insertedRows = h6ATqqIsId(CS_8_locals_80.TGIkR4H0Wl),
					anchor = emITal7V84(CS_8_locals_80.TGIkR4H0Wl)
				});
			}, CS_8_locals_80.F6s0zNQf7g, CS_8_locals_80.TGIkR4H0Wl.AnchorCell.Range, "7");
		});
	}

	public rU18qH9owXvBsPZ0iiU OCnDjfAYoX(int P_0, int P_1, int P_2, int P_3, string P_4, string P_5, string P_6, bool P_7, bool P_8)
	{
		_G_c__DisplayClass37_0 CS_8_locals_53 = new _G_c__DisplayClass37_0();
		CS_8_locals_53.xhnk6qWUAD = P_5;
		CS_8_locals_53.tBmkugaqPB = P_4;
		CS_8_locals_53.fnLkDwNHkT = P_2;
		CS_8_locals_53.FAJkTvvVfq = P_3;
		CS_8_locals_53.hIEkg4lPZD = P_6;
		CS_8_locals_53.N8Ik89nA2y = P_0;
		CS_8_locals_53.FHWkIpxSEj = P_1;
		CS_8_locals_53.tWBkiSc1VI = P_7;
		CS_8_locals_53.jdmkHkXOfG = P_8;
		return gkrTwt4m8C("insert_word_table_at_range", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass37_1 CS_8_locals_87 = new _G_c__DisplayClass37_1();
			CS_8_locals_87.SsLkJG4LDE = CS_8_locals_53;
			string a = (CS_8_locals_53.xhnk6qWUAD ?? "表格_单元格_右边距").Trim().ToLowerInvariant();
			if (!string.Equals(a, "7", StringComparison.Ordinal) && !string.Equals(a, "表格_单元格_底色", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("-16777216", "表格_行_行高", new
				{
					mode = CS_8_locals_53.xhnk6qWUAD
				});
			}
			string text = LvkTnN0GBt(CS_8_locals_53.tBmkugaqPB);
			if (text == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("0.7", "表格_宽度模式", new
				{
					placement = CS_8_locals_53.tBmkugaqPB
				});
			}
			if (CS_8_locals_53.fnLkDwNHkT < 1 || CS_8_locals_53.fnLkDwNHkT > 200)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("自适应宽度", "表格_最大列宽_宽度", new
				{
					rows = CS_8_locals_53.fnLkDwNHkT,
					min = 1,
					max = 200
				});
			}
			if (CS_8_locals_53.FAJkTvvVfq < 1 || CS_8_locals_53.FAJkTvvVfq > 63)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("18.5", "表格_段落格式_中文字体", new
				{
					columns = CS_8_locals_53.FAJkTvvVfq,
					min = 1,
					max = 63
				});
			}
			if (string.Equals(a, "宋体", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(CS_8_locals_53.hIEkg4lPZD))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_段落格式_西文字体", "宋体");
			}
			CS_8_locals_87.doc = ca8TtvS05W(app);
			Range range;
			try
			{
				range = k5cTsYBg89(CS_8_locals_87.doc, CS_8_locals_53.N8Ik89nA2y, CS_8_locals_53.FHWkIpxSEj);
			}
			catch (Exception ex)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_段落格式_字号", "9", new
				{
					rangeStart = CS_8_locals_53.N8Ik89nA2y,
					rangeEnd = CS_8_locals_53.FHWkIpxSEj,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = CofT7m3Hd8(CS_8_locals_87.doc, range, CS_8_locals_53.fnLkDwNHkT, CS_8_locals_53.FAJkTvvVfq, text, CS_8_locals_53.tWBkiSc1VI, CS_8_locals_53.jdmkHkXOfG, out CS_8_locals_87.yvek1TO5he);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			CS_8_locals_87.jhNkrgvp5I = BIJTcpAmqJ(CS_8_locals_87.doc, CS_8_locals_53.N8Ik89nA2y, CS_8_locals_53.FHWkIpxSEj, CS_8_locals_87.yvek1TO5he);
			object obj = XayT5NOjBp(CS_8_locals_87.doc, CS_8_locals_53.N8Ik89nA2y, CS_8_locals_53.FHWkIpxSEj, CS_8_locals_87.jhNkrgvp5I, CS_8_locals_87.yvek1TO5he);
			if (string.Equals(a, "表格_段落格式_加粗", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("1", obj);
			}
			return (!mx2g6RGYxJ(CS_8_locals_87.jhNkrgvp5I, CS_8_locals_53.hIEkg4lPZD)) ? rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_段落格式_行距样式", "4", new
			{
				rangeStart = CS_8_locals_53.N8Ik89nA2y,
				rangeEnd = CS_8_locals_53.FHWkIpxSEj,
				expectedPreviewToken = CS_8_locals_53.hIEkg4lPZD,
				currentPreviewToken = CS_8_locals_87.jhNkrgvp5I,
				preview = obj
			}) : PPXTOUDVLE(CS_8_locals_87.doc, CS_8_locals_53.tWBkiSc1VI, delegate
			{
				_G_c__DisplayClass37_2 CS_8_locals_91 = new _G_c__DisplayClass37_2();
				if (!psHTenZWYL(CS_8_locals_87.doc, CS_8_locals_87.yvek1TO5he, out CS_8_locals_91.QfLk2VFS6u, out var error))
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_段落格式_行距值", "18", new
					{
						rangeStart = CS_8_locals_87.SsLkJG4LDE.N8Ik89nA2y,
						rangeEnd = CS_8_locals_87.SsLkJG4LDE.FHWkIpxSEj,
						Rows = CS_8_locals_87.yvek1TO5he.Rows,
						Columns = CS_8_locals_87.yvek1TO5he.Columns,
						Placement = CS_8_locals_87.yvek1TO5he.Placement,
						error = error
					});
				}
				bool flag = false;
				string text2 = null;
				if (CS_8_locals_87.yvek1TO5he.AdjustAfterInsert)
				{
					flag = EOXTyRsfXn(CS_8_locals_91.QfLk2VFS6u, out text2);
					if (!flag)
					{
						return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_段落格式_段前距单位", "行", new
						{
							rangeStart = CS_8_locals_87.SsLkJG4LDE.N8Ik89nA2y,
							rangeEnd = CS_8_locals_87.SsLkJG4LDE.FHWkIpxSEj,
							Rows = CS_8_locals_87.yvek1TO5he.Rows,
							Columns = CS_8_locals_87.yvek1TO5he.Columns,
							Placement = CS_8_locals_87.yvek1TO5he.Placement,
							tableIndex = hRkT3V0ljO(CS_8_locals_87.doc, CS_8_locals_91.QfLk2VFS6u),
							tableRangeStart = Ex5TMxi7X1(() => CS_8_locals_91.QfLk2VFS6u.Range.Start, 0),
							tableRangeEnd = Ex5TMxi7X1(() => CS_8_locals_91.QfLk2VFS6u.Range.End, 0),
							error = text2
						});
					}
				}
				int tableIndex = hRkT3V0ljO(CS_8_locals_87.doc, CS_8_locals_91.QfLk2VFS6u);
				int num = Ex5TMxi7X1(() => CS_8_locals_91.QfLk2VFS6u.Range.Start, 0);
				int num2 = Ex5TMxi7X1(() => CS_8_locals_91.QfLk2VFS6u.Range.End, 0);
				HbPTWYrAup(CS_8_locals_91.QfLk2VFS6u, out var num3, out var num4);
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("表格_段落格式_段前距", new
				{
					document = CS_8_locals_87.doc.Name,
					documentFullName = CS_8_locals_87.doc.FullName,
					rangeStart = CS_8_locals_87.SsLkJG4LDE.N8Ik89nA2y,
					rangeEnd = CS_8_locals_87.SsLkJG4LDE.FHWkIpxSEj,
					placement = CS_8_locals_87.yvek1TO5he.Placement,
					rows = ((num3 > 0) ? num3 : CS_8_locals_87.yvek1TO5he.Rows),
					columns = ((num4 > 0) ? num4 : CS_8_locals_87.yvek1TO5he.Columns),
					requestedRows = CS_8_locals_87.yvek1TO5he.Rows,
					requestedColumns = CS_8_locals_87.yvek1TO5he.Columns,
					useTrackChanges = CS_8_locals_87.SsLkJG4LDE.tWBkiSc1VI,
					adjustAfterInsert = CS_8_locals_87.yvek1TO5he.AdjustAfterInsert,
					adjusted = flag,
					adjustError = text2,
					previewToken = CS_8_locals_87.jhNkrgvp5I,
					tableIndex = tableIndex,
					tableRangeStart = num,
					tableRangeEnd = num2,
					readStructureArgs = new
					{
						rangeStart = num,
						rangeEnd = num2
					},
					nextTools = new string[2]
					{
						"0",
						"表格_段落格式_段后距"
					}
				});
			}, app, CS_8_locals_87.yvek1TO5he.FocusRange, "0");
		});
	}

	public rU18qH9owXvBsPZ0iiU PR8DYyr1PS(int P_0, int P_1, string P_2)
	{
		_G_c__DisplayClass38_0 CS_8_locals_6 = new _G_c__DisplayClass38_0();
		CS_8_locals_6.Lnmkj0Ig23 = P_0;
		CS_8_locals_6.SeWkYUegMC = P_1;
		CS_8_locals_6.TlKkZRlAoO = P_2;
		return gkrTwt4m8C("replace_word_range_with_track_changes", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Range range = fyVTLmFfU6(document, CS_8_locals_6.Lnmkj0Ig23, CS_8_locals_6.SeWkYUegMC);
			return dX7gQtJOIx(app, document, range, CS_8_locals_6.TlKkZRlAoO ?? string.Empty);
		});
	}

	public rU18qH9owXvBsPZ0iiU CO4DZIpbSD(string P_0)
	{
		_G_c__DisplayClass39_0 CS_8_locals_2 = new _G_c__DisplayClass39_0();
		CS_8_locals_2.WvwkMdl2oR = P_0;
		return gkrTwt4m8C("replace_word_selection_with_track_changes", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Selection selection = app.Selection;
			if (selection == null || selection.Range == null || string.IsNullOrWhiteSpace(Pfn84MVBvM(selection.Range.Text)))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_合计处理_下划线", "3");
			}
			return (!XMVgr0DwLb(selection.Range)) ? rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_小计处理_下划线", "1") : dX7gQtJOIx(app, document, selection.Range, CS_8_locals_2.WvwkMdl2oR ?? string.Empty);
		});
	}

	public rU18qH9owXvBsPZ0iiU XYsDfGZnQW(string P_0, string P_1, int P_2, bool P_3, bool P_4, bool P_5, int P_6)
	{
		_G_c__DisplayClass40_0 CS_8_locals_12 = new _G_c__DisplayClass40_0();
		CS_8_locals_12.khBkSulZ54 = P_0;
		CS_8_locals_12.PibkwEgMgL = P_1;
		CS_8_locals_12.wQVktjGfvi = P_3;
		CS_8_locals_12.bfxkLTOfxK = P_4;
		CS_8_locals_12.EHhkspmqi7 = P_5;
		CS_8_locals_12.z44kl3DhgM = P_2;
		CS_8_locals_12.y4TkNemwQZ = P_6;
		return gkrTwt4m8C("batch_replace_word_text_execute", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass40_1 CS_8_locals_44 = new _G_c__DisplayClass40_1();
			CS_8_locals_44.obZkGStNVx = CS_8_locals_12;
			CS_8_locals_44.cQAkoUnyRF = app;
			if (string.IsNullOrEmpty(CS_8_locals_12.khBkSulZ54))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_合计小计处理_下划线包含文字", "表格_合计处理_下划线包含合计");
			}
			CS_8_locals_44.doc = ca8TtvS05W(CS_8_locals_44.cQAkoUnyRF);
			Document document = CS_8_locals_44.doc;
			object Start = CS_8_locals_44.doc.Content.Start;
			object End = Math.Min(CS_8_locals_44.doc.Content.End, CS_8_locals_44.doc.Content.Start + 1);
			Range range = document.Range(ref Start, ref End);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = Q7Sg1pThfx(CS_8_locals_44.cQAkoUnyRF, CS_8_locals_44.doc, range);
			return (rU18qH9owXvBsPZ0iiU2 != null) ? rU18qH9owXvBsPZ0iiU2 : oBKTTgZY41(CS_8_locals_44.cQAkoUnyRF, "0", delegate
			{
				bool trackRevisions = CS_8_locals_44.doc.TrackRevisions;
				bool screenUpdating = CS_8_locals_44.cQAkoUnyRF.ScreenUpdating;
				WdAlertLevel displayAlerts = CS_8_locals_44.cQAkoUnyRF.DisplayAlerts;
				try
				{
					CS_8_locals_44.cQAkoUnyRF.ScreenUpdating = false;
					CS_8_locals_44.cQAkoUnyRF.DisplayAlerts = WdAlertLevel.wdAlertsNone;
					CS_8_locals_44.doc.TrackRevisions = true;
					Find find = CS_8_locals_44.doc.Content.Duplicate.Find;
					find.ClearFormatting();
					find.Replacement.ClearFormatting();
					find.Text = CS_8_locals_44.obZkGStNVx.khBkSulZ54;
					find.Replacement.Text = CS_8_locals_44.obZkGStNVx.PibkwEgMgL ?? string.Empty;
					find.Forward = true;
					find.Wrap = WdFindWrap.wdFindStop;
					find.Format = false;
					find.MatchCase = CS_8_locals_44.obZkGStNVx.wQVktjGfvi;
					find.MatchWholeWord = CS_8_locals_44.obZkGStNVx.bfxkLTOfxK;
					find.MatchWildcards = false;
					find.MatchSoundsLike = false;
					find.MatchAllWordForms = false;
					object FindText = Type.Missing;
					object MatchCase = Type.Missing;
					object MatchWholeWord = Type.Missing;
					object MatchWildcards = Type.Missing;
					object MatchSoundsLike = Type.Missing;
					object MatchAllWordForms = Type.Missing;
					object Forward = Type.Missing;
					object Wrap = Type.Missing;
					object Format = Type.Missing;
					object ReplaceWith = Type.Missing;
					object Replace = WdReplace.wdReplaceAll;
					object MatchKashida = Type.Missing;
					object MatchDiacritics = Type.Missing;
					object MatchAlefHamza = Type.Missing;
					object MatchControl = Type.Missing;
					find.Execute(ref FindText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref ReplaceWith, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl);
					return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("表格_合计处理_加粗", new
					{
						document = CS_8_locals_44.doc.Name,
						documentFullName = CS_8_locals_44.doc.FullName,
						findText = CS_8_locals_44.obZkGStNVx.khBkSulZ54,
						replaceText = (CS_8_locals_44.obZkGStNVx.PibkwEgMgL ?? string.Empty),
						matchCase = CS_8_locals_44.obZkGStNVx.wQVktjGfvi,
						wholeWord = CS_8_locals_44.obZkGStNVx.bfxkLTOfxK,
						useTrackChanges = true,
						requestedUseTrackChanges = CS_8_locals_44.obZkGStNVx.EHhkspmqi7,
						forcedTrackChanges = true,
						replaceMethod = "0",
						expectedMatchCount = CS_8_locals_44.obZkGStNVx.z44kl3DhgM,
						replacedCountKnown = false,
						previewRequired = false,
						maxMatchesIgnored = CS_8_locals_44.obZkGStNVx.y4TkNemwQZ
					});
				}
				finally
				{
					CS_8_locals_44.doc.TrackRevisions = trackRevisions;
					CS_8_locals_44.cQAkoUnyRF.DisplayAlerts = displayAlerts;
					CS_8_locals_44.cQAkoUnyRF.ScreenUpdating = screenUpdating;
				}
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU QJUDMaARAF()
	{
		return gkrTwt4m8C("export_word_comments", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass41_0 CS_8_locals_4 = new _G_c__DisplayClass41_0();
			CS_8_locals_4.doc = ca8TtvS05W(app);
			GwPwjPKig3SC80BpOVZ.CKSKKAnPKH();
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("表格_小计处理_加粗", new
			{
				document = CS_8_locals_4.doc.Name,
				documentFullName = CS_8_locals_4.doc.FullName,
				commentCount = Y1x8gkTvcF(() => CS_8_locals_4.doc.Comments.Count)
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU hTGDbq1PWf()
	{
		return gkrTwt4m8C("adjust_selected_word_tables_format", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass42_0 CS_8_locals_7 = new _G_c__DisplayClass42_0();
			CS_8_locals_7.qYskOc2fjF = app;
			Document document = ca8TtvS05W(CS_8_locals_7.qYskOc2fjF);
			document.Activate();
			if (CS_8_locals_7.qYskOc2fjF.Selection == null || CS_8_locals_7.qYskOc2fjF.Selection.Range == null || !XMVgr0DwLb(CS_8_locals_7.qYskOc2fjF.Selection.Range))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("0", "表格_合计小计处理_加粗包含文字");
			}
			int num = Y1x8gkTvcF(() => CS_8_locals_7.qYskOc2fjF.Selection.Tables.Count);
			if (num <= 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表格_合计处理_加粗包含合计", "0");
			}
			DyITDXSmDr(CS_8_locals_7.qYskOc2fjF, "read_word_table_adjustment_config failed", MTM8HqftP23tlVOKhjT.HUeflwYrZr);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("config_error", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				selectedTables = num,
				adjustedTables = num
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU x67DS18Ej7()
	{
		return gkrTwt4m8C("adjust_selected_word_paragraphs_format", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass43_0 CS_8_locals_7 = new _G_c__DisplayClass43_0();
			CS_8_locals_7.nH8k74mNxM = app;
			Document document = ca8TtvS05W(CS_8_locals_7.nH8k74mNxM);
			document.Activate();
			if (CS_8_locals_7.nH8k74mNxM.Selection == null || CS_8_locals_7.nH8k74mNxM.Selection.Range == null || !XMVgr0DwLb(CS_8_locals_7.nH8k74mNxM.Selection.Range))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("一级", "二级");
			}
			int num = Y1x8gkTvcF(() => CS_8_locals_7.nH8k74mNxM.Selection.Paragraphs.Count);
			if (num <= 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("三级", "四级");
			}
			DyITDXSmDr(CS_8_locals_7.nH8k74mNxM, "五级", INe7hoMZ2egQUJDl6fB.BBAMen3SA4);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("其他", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				selectedParagraphs = num
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU oRjDwmqF5A()
	{
		try
		{
			ftu1AgSpErBKqc6vp9f.Current.m15SqmKUa9();
			Dictionary<string, object> dictionary = ftu1AgSpErBKqc6vp9f.Current.dnEScXBL9Y();
			Dictionary<string, string> raw = x9HT8Iew9Q(dictionary, "表格_");
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word table adjustment config read.", new
			{
				configType = "table",
				preset = QlpTIR1vVX(dictionary, "表格配置_方案名"),
				cellPadding = new
				{
					top = QlpTIR1vVX(dictionary, "表格_单元格_上边距", "0"),
					bottom = QlpTIR1vVX(dictionary, "表格_单元格_下边距", "0"),
					left = QlpTIR1vVX(dictionary, "表格_单元格_左边距", "7"),
					right = QlpTIR1vVX(dictionary, "表格_单元格_右边距", "7"),
					headerBackgroundColor = QlpTIR1vVX(dictionary, "表格_单元格_底色", "-16777216")
				},
				row = new
				{
					height = QlpTIR1vVX(dictionary, "表格_行_行高", "0.7")
				},
				width = new
				{
					mode = QlpTIR1vVX(dictionary, "表格_宽度模式", "自适应宽度"),
					maxColumnWidth = QlpTIR1vVX(dictionary, "表格_最大列宽_宽度", "18.5")
				},
				font = new
				{
					chineseFont = QlpTIR1vVX(dictionary, "表格_段落格式_中文字体", "宋体"),
					westernFont = QlpTIR1vVX(dictionary, "表格_段落格式_西文字体", "宋体"),
					size = QlpTIR1vVX(dictionary, "表格_段落格式_字号", "9"),
					headerBold = QlpTIR1vVX(dictionary, "表格_段落格式_加粗", "1")
				},
				paragraph = new
				{
					lineSpacingRule = QlpTIR1vVX(dictionary, "表格_段落格式_行距样式", "4"),
					lineSpacing = QlpTIR1vVX(dictionary, "表格_段落格式_行距值", "18"),
					spacingUnit = QlpTIR1vVX(dictionary, "表格_段落格式_段前距单位", "行"),
					spaceBefore = QlpTIR1vVX(dictionary, "表格_段落格式_段前距", "0"),
					spaceAfter = QlpTIR1vVX(dictionary, "表格_段落格式_段后距", "0")
				},
				borders = UpjTihUo1t(dictionary),
				alignment = gAdTHE0s6R(dictionary),
				summary = new
				{
					totalUnderline = QlpTIR1vVX(dictionary, "表格_合计处理_下划线", "3"),
					subtotalUnderline = QlpTIR1vVX(dictionary, "表格_小计处理_下划线", "1"),
					underlineIncludesText = QlpTIR1vVX(dictionary, "表格_合计小计处理_下划线包含文字", QlpTIR1vVX(dictionary, "表格_合计处理_下划线包含合计", "0")),
					totalBold = QlpTIR1vVX(dictionary, "表格_合计处理_加粗", "0"),
					subtotalBold = QlpTIR1vVX(dictionary, "表格_小计处理_加粗", "0"),
					boldIncludesText = QlpTIR1vVX(dictionary, "表格_合计小计处理_加粗包含文字", QlpTIR1vVX(dictionary, "表格_合计处理_加粗包含合计", "0"))
				},
				raw = raw
			});
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.g7A9nYlk8v("read_word_table_adjustment_config failed", "config_error", ex);
		}
	}

	public rU18qH9owXvBsPZ0iiU p9hDt1sKaD(string P_0)
	{
		try
		{
			_G_c__DisplayClass45_0 CS_8_locals_5 = new _G_c__DisplayClass45_0();
			ftu1AgSpErBKqc6vp9f.Current.m15SqmKUa9();
			CS_8_locals_5.UpVkclndys = ftu1AgSpErBKqc6vp9f.Current.dnEScXBL9Y();
			string text = If1TQ6sv5o(P_0);
			List<object> levels = ((!string.IsNullOrWhiteSpace(text)) ? new string[1] { text } : new string[9]
			{
				"一级",
				"二级",
				"三级",
				"四级",
				"五级",
				"其他",
				"表前单位",
				"表后注释",
				"表后段落"
			}).Select((string item) => DaWT1u9T3L(CS_8_locals_5.UpVkclndys, item)).ToList();
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Word paragraph adjustment config read.", new
			{
				configType = "paragraph",
				preset = QlpTIR1vVX(CS_8_locals_5.UpVkclndys, "段落配置_方案名", QlpTIR1vVX(CS_8_locals_5.UpVkclndys, "段落配置_当前方案")),
				level = (string.IsNullOrWhiteSpace(text) ? null : text),
				levels = levels,
				raw = x9HT8Iew9Q(CS_8_locals_5.UpVkclndys, "段落_")
			});
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.g7A9nYlk8v("read_word_paragraph_adjustment_config failed", "config_error", ex);
		}
	}

	public rU18qH9owXvBsPZ0iiU Y4WDLs3BoQ(int P_0)
	{
		_G_c__DisplayClass46_0 CS_8_locals_6 = new _G_c__DisplayClass46_0();
		CS_8_locals_6.f5Eky02Vmu = P_0;
		return gkrTwt4m8C("inspect_word_table_format", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass46_1 CS_8_locals_30 = new _G_c__DisplayClass46_1();
			Document document = ca8TtvS05W(app);
			CS_8_locals_30.Q8nxVy7ObF = LVOTrE16IP(app, document, CS_8_locals_6.f5Eky02Vmu);
			int tableIndex = hRkT3V0ljO(document, CS_8_locals_30.Q8nxVy7ObF);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("表前单位", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = CS_8_locals_6.f5Eky02Vmu,
				altTextTitle = TkI8jwiSoi(iOW8KTFwda(() => CS_8_locals_30.Q8nxVy7ObF.Title)),
				altTextDescription = TkI8jwiSoi(iOW8KTFwda(() => CS_8_locals_30.Q8nxVy7ObF.Descr)),
				page = Y878QfFgDa(CS_8_locals_30.Q8nxVy7ObF.Range),
				rangeStart = CS_8_locals_30.Q8nxVy7ObF.Range.Start,
				rangeEnd = CS_8_locals_30.Q8nxVy7ObF.Range.End,
				rows = PJm8rI8jwn(CS_8_locals_30.Q8nxVy7ObF),
				columns = ldc8JB4JIl(CS_8_locals_30.Q8nxVy7ObF),
				preferredWidthType = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.PreferredWidthType, WdPreferredWidthType.wdPreferredWidthAuto)),
				preferredWidth = Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.PreferredWidth, 0f),
				rowAlignment = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.Rows.Alignment, WdRowAlignment.wdAlignRowLeft)),
				allowPageBreaks = Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.AllowPageBreaks, ypQS6RTSiCdpSgKNQtr: false),
				spacing = Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.Spacing, 0f),
				cellPadding = new
				{
					top = Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.TopPadding, 0f),
					bottom = Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.BottomPadding, 0f),
					left = Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.LeftPadding, 0f),
					right = Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.RightPadding, 0f)
				},
				row = new
				{
					height = Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.Rows.Height, 0f),
					heightRule = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.Rows.HeightRule, WdRowHeightRule.wdRowHeightAuto)),
					allowBreakAcrossPages = Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.Rows.AllowBreakAcrossPages, 0),
					firstRowHeadingFormat = Ex5TMxi7X1(() => CS_8_locals_30.Q8nxVy7ObF.Rows[1].HeadingFormat, 0)
				},
				rangeFont = rROTUTwJ2p(CS_8_locals_30.Q8nxVy7ObF.Range.Font),
				paragraphFormat = pyaTKvLinx(CS_8_locals_30.Q8nxVy7ObF.Range.ParagraphFormat),
				borders = PruTEuRUN6(CS_8_locals_30.Q8nxVy7ObF),
				sampleCells = z71T41pygj(CS_8_locals_30.Q8nxVy7ObF)
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU M2oDshQo9M(int P_0)
	{
		_G_c__DisplayClass47_0 CS_8_locals_6 = new _G_c__DisplayClass47_0();
		CS_8_locals_6.jGQx9aU3Fq = P_0;
		return gkrTwt4m8C("inspect_word_paragraph_format", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = ca8TtvS05W(app);
			Paragraph paragraph = ((CS_8_locals_6.jGQx9aU3Fq > 0) ? U09ToZPpqq(document, CS_8_locals_6.jGQx9aU3Fq) : jNyTJ8ZWsU(app, document));
			int? paragraphIndex = ((CS_8_locals_6.jGQx9aU3Fq > 0) ? new int?(CS_8_locals_6.jGQx9aU3Fq) : EFt8ufX87I(document, paragraph.Range.Start));
			int num = fSO88F0gne(paragraph);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("表后注释", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				paragraphIndex = paragraphIndex,
				requestedParagraphIndex = CS_8_locals_6.jGQx9aU3Fq,
				page = Y878QfFgDa(paragraph.Range),
				rangeStart = paragraph.Range.Start,
				rangeEnd = paragraph.Range.End,
				isInTable = YsX81TpOe7(paragraph.Range),
				outlineLevel = cjC8ImVBAy(num),
				comOutlineLevelRaw = num,
				styleName = kBH8HcK06n(paragraph),
				excerpt = rYN8Y355we(Pfn84MVBvM(paragraph.Range.Text), 240),
				font = rROTUTwJ2p(paragraph.Range.Font),
				paragraphFormat = pyaTKvLinx(paragraph.Range.ParagraphFormat)
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU Gk4DlvZv44(int P_0, int P_1, string P_2)
	{
		_G_c__DisplayClass48_0 CS_8_locals_12 = new _G_c__DisplayClass48_0();
		CS_8_locals_12.hGNxuJMRRe = P_2;
		CS_8_locals_12.pc1xD89ckW = P_0;
		CS_8_locals_12.EJmxTow96I = P_1;
		return gkrTwt4m8C("preview_word_paragraph_format_change", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			TqHECLHh7ExNw6c0RJi tqHECLHh7ExNw6c0RJi;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = KESDFbjWCy(CS_8_locals_12.hGNxuJMRRe, out tqHECLHh7ExNw6c0RJi);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			Document document = ca8TtvS05W(app);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = fe5DGXtNeG(document, CS_8_locals_12.pc1xD89ckW, CS_8_locals_12.EJmxTow96I);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			List<WKGvoki3QLNecqlT5em> list = FMtTCCF91i(app, document, CS_8_locals_12.pc1xD89ckW, CS_8_locals_12.EJmxTow96I);
			return (list.Count == 0) ? rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("表后段落", "Word paragraph adjustment config read.", new
			{
				startParagraphIndex = CS_8_locals_12.pc1xD89ckW,
				endParagraphIndex = CS_8_locals_12.EJmxTow96I
			}) : rU18qH9owXvBsPZ0iiU.nt99CvEC4m("paragraph", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				startParagraphIndex = CS_8_locals_12.pc1xD89ckW,
				endParagraphIndex = CS_8_locals_12.EJmxTow96I,
				expectedChangeCount = list.Count,
				supportedFields = TqHECLHh7ExNw6c0RJi.CsBHPhLn0y,
				requestedChanges = tqHECLHh7ExNw6c0RJi.WK3Hqw863W(),
				paragraphs = list.Select((WKGvoki3QLNecqlT5em item) => UgBDC6Uhof(item)).ToList()
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU X5jDNRpGUB(int P_0, int P_1, string P_2, int P_3)
	{
		_G_c__DisplayClass49_0 CS_8_locals_23 = new _G_c__DisplayClass49_0();
		CS_8_locals_23.ocyx8jdfRq = P_3;
		CS_8_locals_23.EX1xIbMLCF = P_2;
		CS_8_locals_23.sexxiKXvvR = P_0;
		CS_8_locals_23.bwHxHImFm4 = P_1;
		return gkrTwt4m8C("apply_word_paragraph_format_change", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass49_1 CS_8_locals_30 = new _G_c__DisplayClass49_1();
			if (CS_8_locals_23.ocyx8jdfRq < 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("段落配置_方案名", "段落配置_当前方案");
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = KESDFbjWCy(CS_8_locals_23.EX1xIbMLCF, out CS_8_locals_30.JdkxrYYqxL);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			Document document = ca8TtvS05W(app);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = fe5DGXtNeG(document, CS_8_locals_23.sexxiKXvvR, CS_8_locals_23.bwHxHImFm4);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_30.IMjx1m8Vmd = FMtTCCF91i(app, document, CS_8_locals_23.sexxiKXvvR, CS_8_locals_23.bwHxHImFm4);
			if (CS_8_locals_30.IMjx1m8Vmd.Count != CS_8_locals_23.ocyx8jdfRq)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("段落_", "read_word_paragraph_adjustment_config failed", new
				{
					expectedChangeCount = CS_8_locals_23.ocyx8jdfRq,
					currentChangeCount = CS_8_locals_30.IMjx1m8Vmd.Count
				});
			}
			CS_8_locals_30.J7fx3kYs4A = new List<object>();
			CS_8_locals_30.pNtxJoT4sP = 0;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU4 = Q7Sg1pThfx(app, document, CS_8_locals_30.IMjx1m8Vmd[0].Paragraph.Range);
			if (rU18qH9owXvBsPZ0iiU4 != null)
			{
				return rU18qH9owXvBsPZ0iiU4;
			}
			DyITDXSmDr(app, "config_error", delegate
			{
				foreach (WKGvoki3QLNecqlT5em item in CS_8_locals_30.IMjx1m8Vmd)
				{
					object before = LIHDpX1o9Q(item.Paragraph);
					AIaD7XMwok(item.Paragraph.Range, CS_8_locals_30.JdkxrYYqxL);
					object after = LIHDpX1o9Q(item.Paragraph);
					CS_8_locals_30.pNtxJoT4sP++;
					CS_8_locals_30.J7fx3kYs4A.Add(new
					{
						paragraphIndex = item.ParagraphIndex,
						rangeStart = item.Paragraph.Range.Start,
						rangeEnd = item.Paragraph.Range.End,
						page = Y878QfFgDa(item.Paragraph.Range),
						excerpt = rYN8Y355we(Pfn84MVBvM(item.Paragraph.Range.Text), 160),
						before = before,
						after = after,
						changed = true
					});
				}
			});
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("inspect_word_table_format", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				startParagraphIndex = CS_8_locals_23.sexxiKXvvR,
				endParagraphIndex = CS_8_locals_23.bwHxHImFm4,
				expectedChangeCount = CS_8_locals_23.ocyx8jdfRq,
				changed = CS_8_locals_30.pNtxJoT4sP,
				requestedChanges = CS_8_locals_30.JdkxrYYqxL.WK3Hqw863W(),
				paragraphs = CS_8_locals_30.J7fx3kYs4A
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU P3nDmuGg5q(int P_0, string P_1, string P_2)
	{
		_G_c__DisplayClass50_0 CS_8_locals_7 = new _G_c__DisplayClass50_0();
		CS_8_locals_7.noTxKIkNHF = P_2;
		CS_8_locals_7.AsAxERVSg2 = P_0;
		CS_8_locals_7.gKUx2XUAJA = P_1;
		return gkrTwt4m8C("preview_word_table_format_change", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			XqsyBVQI7dsGuEiUT3v xqsyBVQI7dsGuEiUT3v;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = KRQDhebBe2(CS_8_locals_7.noTxKIkNHF, out xqsyBVQI7dsGuEiUT3v);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			Document document = ca8TtvS05W(app);
			Table table = LVOTrE16IP(app, document, CS_8_locals_7.AsAxERVSg2);
			int tableIndex = hRkT3V0ljO(document, table);
			Range range;
			string target;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = qoGDn2m06h(document, table, CS_8_locals_7.gKUx2XUAJA, out range, out target);
			return (rU18qH9owXvBsPZ0iiU3 != null) ? rU18qH9owXvBsPZ0iiU3 : rU18qH9owXvBsPZ0iiU.nt99CvEC4m("inspect_word_paragraph_format", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = CS_8_locals_7.AsAxERVSg2,
				target = target,
				expectedChangeCount = 1,
				supportedFields = XqsyBVQI7dsGuEiUT3v.TcvQQSKPF8,
				requestedChanges = xqsyBVQI7dsGuEiUT3v.hhNQHAECG8(),
				before = rWPDO6omwl(table, range)
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU nw3Dov9OIq(int P_0, string P_1, string P_2, int P_3)
	{
		_G_c__DisplayClass51_0 CS_8_locals_23 = new _G_c__DisplayClass51_0();
		CS_8_locals_23.Rrcxji1W2K = P_3;
		CS_8_locals_23.EeExY5NKTk = P_2;
		CS_8_locals_23.xkQxZS98ww = P_0;
		CS_8_locals_23.miExft7aTy = P_1;
		return gkrTwt4m8C("apply_word_table_format_change", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass51_1 CS_8_locals_27 = new _G_c__DisplayClass51_1();
			if (CS_8_locals_23.Rrcxji1W2K < 0)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("preview_word_paragraph_format_change", "apply_word_paragraph_format_change");
			}
			if (CS_8_locals_23.Rrcxji1W2K != 1)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("preview_word_table_format_change", "apply_word_table_format_change", new
				{
					expectedChangeCount = CS_8_locals_23.Rrcxji1W2K,
					currentChangeCount = 1
				});
			}
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = KRQDhebBe2(CS_8_locals_23.EeExY5NKTk, out CS_8_locals_27.vsUxwGPQsX);
			if (rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
			Document document = ca8TtvS05W(app);
			CS_8_locals_27.f62xbANknn = LVOTrE16IP(app, document, CS_8_locals_23.xkQxZS98ww);
			int tableIndex = hRkT3V0ljO(document, CS_8_locals_27.f62xbANknn);
			string target;
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU3 = qoGDn2m06h(document, CS_8_locals_27.f62xbANknn, CS_8_locals_23.miExft7aTy, out CS_8_locals_27.m5KxShGl5D, out target);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			object before = rWPDO6omwl(CS_8_locals_27.f62xbANknn, CS_8_locals_27.m5KxShGl5D);
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU4 = Q7Sg1pThfx(app, document, CS_8_locals_27.m5KxShGl5D);
			if (rU18qH9owXvBsPZ0iiU4 != null)
			{
				return rU18qH9owXvBsPZ0iiU4;
			}
			DyITDXSmDr(app, "startParagraphIndex 和 endParagraphIndex 不能为负数。", delegate
			{
				AmnD5qIsfE(CS_8_locals_27.f62xbANknn, CS_8_locals_27.m5KxShGl5D, CS_8_locals_27.vsUxwGPQsX);
			});
			object after = rWPDO6omwl(CS_8_locals_27.f62xbANknn, CS_8_locals_27.m5KxShGl5D);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("invalid_arguments", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = CS_8_locals_23.xkQxZS98ww,
				target = target,
				expectedChangeCount = CS_8_locals_23.Rrcxji1W2K,
				changed = 1,
				requestedChanges = CS_8_locals_27.vsUxwGPQsX.hhNQHAECG8(),
				before = before,
				after = after
			});
		});
	}

	private static rU18qH9owXvBsPZ0iiU fe5DGXtNeG(Document P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass52_0 CS_8_locals_2 = new _G_c__DisplayClass52_0();
		CS_8_locals_2.doc = P_0;
		if (P_1 < 0 || P_2 < 0)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("startParagraphIndex 和 endParagraphIndex 不能为负数。", "invalid_arguments", new
			{
				startParagraphIndex = P_1,
				endParagraphIndex = P_2
			});
		}
		if (P_1 == 0 && P_2 > 0)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("startParagraphIndex=0 表示当前选区，此时 endParagraphIndex 必须为 0。", "invalid_arguments", new
			{
				startParagraphIndex = P_1,
				endParagraphIndex = P_2
			});
		}
		if (P_1 > 0 && P_2 > 0 && P_2 < P_1)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("endParagraphIndex must be greater than or equal to startParagraphIndex.", "invalid_arguments", new
			{
				startParagraphIndex = P_1,
				endParagraphIndex = P_2
			});
		}
		int num = Y1x8gkTvcF(() => CS_8_locals_2.doc.Paragraphs.Count);
		if (P_1 > num)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("startParagraphIndex is out of range.", "invalid_arguments", new
			{
				startParagraphIndex = P_1,
				totalParagraphs = num
			});
		}
		if (P_2 > num)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("endParagraphIndex is out of range.", "invalid_arguments", new
			{
				endParagraphIndex = P_2,
				totalParagraphs = num
			});
		}
		return null;
	}

	private static object UgBDC6Uhof(WKGvoki3QLNecqlT5em P_0)
	{
		return new
		{
			paragraphIndex = P_0.ParagraphIndex,
			rangeStart = P_0.Paragraph.Range.Start,
			rangeEnd = P_0.Paragraph.Range.End,
			page = Y878QfFgDa(P_0.Paragraph.Range),
			outlineLevel = cjC8ImVBAy(fSO88F0gne(P_0.Paragraph)),
			styleName = kBH8HcK06n(P_0.Paragraph),
			excerpt = rYN8Y355we(Pfn84MVBvM(P_0.Paragraph.Range.Text), 160),
			current = LIHDpX1o9Q(P_0.Paragraph)
		};
	}

	private static object LIHDpX1o9Q(Paragraph P_0)
	{
		return new
		{
			outlineLevel = cjC8ImVBAy(fSO88F0gne(P_0)),
			styleName = kBH8HcK06n(P_0),
			font = rROTUTwJ2p(P_0.Range.Font),
			paragraphFormat = pyaTKvLinx(P_0.Range.ParagraphFormat)
		};
	}

	private static object rWPDO6omwl(Table P_0, Range P_1)
	{
		_G_c__DisplayClass55_0 CS_8_locals_13 = new _G_c__DisplayClass55_0();
		CS_8_locals_13.S1cxODjhIe = P_0;
		return new
		{
			rangeStart = P_1.Start,
			rangeEnd = P_1.End,
			page = Y878QfFgDa(P_1),
			rows = PJm8rI8jwn(CS_8_locals_13.S1cxODjhIe),
			columns = ldc8JB4JIl(CS_8_locals_13.S1cxODjhIe),
			preferredWidthType = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_13.S1cxODjhIe.PreferredWidthType, WdPreferredWidthType.wdPreferredWidthAuto)),
			preferredWidth = Ex5TMxi7X1(() => CS_8_locals_13.S1cxODjhIe.PreferredWidth, 0f),
			rowAlignment = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_13.S1cxODjhIe.Rows.Alignment, WdRowAlignment.wdAlignRowLeft)),
			cellPadding = new
			{
				top = Ex5TMxi7X1(() => CS_8_locals_13.S1cxODjhIe.TopPadding, 0f),
				bottom = Ex5TMxi7X1(() => CS_8_locals_13.S1cxODjhIe.BottomPadding, 0f),
				left = Ex5TMxi7X1(() => CS_8_locals_13.S1cxODjhIe.LeftPadding, 0f),
				right = Ex5TMxi7X1(() => CS_8_locals_13.S1cxODjhIe.RightPadding, 0f)
			},
			row = new
			{
				height = Ex5TMxi7X1(() => CS_8_locals_13.S1cxODjhIe.Rows.Height, 0f),
				heightRule = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_13.S1cxODjhIe.Rows.HeightRule, WdRowHeightRule.wdRowHeightAuto))
			},
			targetFont = rROTUTwJ2p(P_1.Font),
			targetParagraphFormat = pyaTKvLinx(P_1.ParagraphFormat),
			borders = PruTEuRUN6(CS_8_locals_13.S1cxODjhIe)
		};
	}

	private static rU18qH9owXvBsPZ0iiU qoGDn2m06h(Document P_0, Table P_1, string P_2, out Range P_3, out string P_4)
	{
		P_3 = null;
		P_4 = (P_2 ?? "wholeTable").Trim();
		string text = P_4.ToLowerInvariant();
		int num = PJm8rI8jwn(P_1);
		try
		{
			if (text == "wholetable" || text == "all" || text == "table")
			{
				P_4 = "wholeTable";
				P_3 = P_1.Range;
				return null;
			}
			if (text == "headerrow" || text == "header" || text == "firstrow")
			{
				if (num < 1)
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("该表格没有可设置的表头行。", "table_target_unavailable", new
					{
						target = P_2
					});
				}
				P_4 = "headerRow";
				P_3 = P_1.Rows[1].Range;
				return null;
			}
			if (text == "bodyrows" || text == "body" || text == "datarows" || text == "databody")
			{
				if (num < 2)
				{
					return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("该表格没有正文数据行。", "table_target_unavailable", new
					{
						target = P_2,
						rows = num
					});
				}
				P_4 = "bodyRows";
				object Start = P_1.Rows[2].Range.Start;
				object End = P_1.Rows[num].Range.End;
				P_3 = P_0.Range(ref Start, ref End);
				return null;
			}
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("无法解析表格格式目标区域，可能受合并单元格或表格结构影响。", "table_target_unavailable", new
			{
				target = P_2,
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("target 仅支持 wholeTable、headerRow、bodyRows。", "invalid_arguments", new
		{
			target = P_2
		});
	}

	private static void AIaD7XMwok(Range P_0, TqHECLHh7ExNw6c0RJi P_1)
	{
		PK7DcgUxme(P_0, P_1.FontName, P_1.EastAsianFontName, P_1.FontSize, P_1.Bold, P_1.Italic);
		fQfDekhQUN(P_0.ParagraphFormat, P_1);
	}

	private static void AmnD5qIsfE(Table P_0, Range P_1, XqsyBVQI7dsGuEiUT3v P_2)
	{
		PK7DcgUxme(P_1, P_2.FontName, P_2.EastAsianFontName, P_2.FontSize, P_2.Bold, P_2.Italic);
		if (P_2.Alignment != null)
		{
			P_1.ParagraphFormat.Alignment = Pi4Dx99j6C(P_2.Alignment);
		}
		if (P_2.VerticalAlignment != null)
		{
			DldDyvVadI(P_0, P_1, j0jDz8lcCe(P_2.VerticalAlignment));
		}
		if (P_2.RowAlignment != null)
		{
			P_0.Rows.Alignment = pH4DdWNJio(P_2.RowAlignment);
		}
		if (P_2.AutoFit != null)
		{
			P_0.AutoFitBehavior(zumTVgQhWS(P_2.AutoFit));
		}
		if (P_2.PreferredWidthPercent.HasValue)
		{
			P_0.PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
			P_0.PreferredWidth = P_2.PreferredWidthPercent.Value;
		}
		if (P_2.CellPaddingPt.HasValue)
		{
			P_0.TopPadding = P_2.CellPaddingPt.Value;
			P_0.BottomPadding = P_2.CellPaddingPt.Value;
			P_0.LeftPadding = P_2.CellPaddingPt.Value;
			P_0.RightPadding = P_2.CellPaddingPt.Value;
		}
		if (P_2.RowHeightPt.HasValue)
		{
			P_0.Rows.Height = P_2.RowHeightPt.Value;
		}
		if (P_2.RowHeightRule != null)
		{
			P_0.Rows.HeightRule = v88TBQGlgu(P_2.RowHeightRule);
		}
		if (P_2.BorderStyle != null)
		{
			PQGDXpu5sr(P_0, P_2.BorderStyle, P_2.BorderWidth);
		}
		if (P_2.HeaderRowBold.HasValue && PJm8rI8jwn(P_0) >= 1)
		{
			P_0.Rows[1].Range.Font.Bold = (P_2.HeaderRowBold.Value ? (-1) : 0);
		}
		if (P_2.HeaderRowShading.HasValue && PJm8rI8jwn(P_0) >= 1)
		{
			P_0.Rows[1].Range.Shading.BackgroundPatternColor = (WdColor)P_2.HeaderRowShading.Value;
		}
	}

	private static void PK7DcgUxme(Range P_0, string P_1, string P_2, float? P_3, bool? P_4, bool? P_5)
	{
		if (!string.IsNullOrWhiteSpace(P_1))
		{
			P_0.Font.Name = P_1;
			P_0.Font.NameAscii = P_1;
			P_0.Font.NameOther = P_1;
		}
		if (!string.IsNullOrWhiteSpace(P_2))
		{
			P_0.Font.NameFarEast = P_2;
		}
		if (P_3.HasValue)
		{
			P_0.Font.Size = P_3.Value;
		}
		if (P_4.HasValue)
		{
			P_0.Font.Bold = (P_4.Value ? (-1) : 0);
		}
		if (P_5.HasValue)
		{
			P_0.Font.Italic = (P_5.Value ? (-1) : 0);
		}
	}

	private static void fQfDekhQUN(ParagraphFormat P_0, TqHECLHh7ExNw6c0RJi P_1)
	{
		if (P_1.Alignment != null)
		{
			P_0.Alignment = Pi4Dx99j6C(P_1.Alignment);
		}
		if (P_1.LeftIndentCm.HasValue)
		{
			P_0.LeftIndent = bPYTuue3a0(P_1.LeftIndentCm.Value);
		}
		if (P_1.RightIndentCm.HasValue)
		{
			P_0.RightIndent = bPYTuue3a0(P_1.RightIndentCm.Value);
		}
		if (P_1.FirstLineIndentCm.HasValue)
		{
			P_0.FirstLineIndent = bPYTuue3a0(P_1.FirstLineIndentCm.Value);
		}
		if (P_1.FirstLineIndentChars.HasValue)
		{
			P_0.CharacterUnitFirstLineIndent = P_1.FirstLineIndentChars.Value;
		}
		if (P_1.SpaceBeforePt.HasValue)
		{
			P_0.SpaceBefore = P_1.SpaceBeforePt.Value;
		}
		if (P_1.SpaceAfterPt.HasValue)
		{
			P_0.SpaceAfter = P_1.SpaceAfterPt.Value;
		}
		if (P_1.LineSpacingRule != null)
		{
			P_0.LineSpacingRule = iTATRE4FUT(P_1.LineSpacingRule);
		}
		if (P_1.LineSpacingPt.HasValue)
		{
			P_0.LineSpacing = P_1.LineSpacingPt.Value;
		}
		if (P_1.LineSpacingMultiple.HasValue)
		{
			P_0.LineSpacingRule = WdLineSpacing.wdLineSpaceMultiple;
			P_0.LineSpacing = P_1.LineSpacingMultiple.Value * 12f;
		}
		if (P_1.KeepWithNext.HasValue)
		{
			P_0.KeepWithNext = (P_1.KeepWithNext.Value ? (-1) : 0);
		}
		if (P_1.KeepTogether.HasValue)
		{
			P_0.KeepTogether = (P_1.KeepTogether.Value ? (-1) : 0);
		}
		if (P_1.PageBreakBefore.HasValue)
		{
			P_0.PageBreakBefore = (P_1.PageBreakBefore.Value ? (-1) : 0);
		}
	}

	private static void DldDyvVadI(Table P_0, Range P_1, WdCellVerticalAlignment P_2)
	{
		_G_c__DisplayClass61_0 CS_8_locals_3 = new _G_c__DisplayClass61_0();
		CS_8_locals_3.Q65x7eilJi = P_1;
		int num = Y1x8gkTvcF(() => CS_8_locals_3.Q65x7eilJi.Cells.Count);
		for (int num2 = 1; num2 <= num; num2++)
		{
			try
			{
				CS_8_locals_3.Q65x7eilJi.Cells[num2].VerticalAlignment = P_2;
			}
			catch
			{
			}
		}
	}

	private static void PQGDXpu5sr(Table P_0, string P_1, float? P_2)
	{
		WdLineStyle wdLineStyle = y8jT9OIF7R(P_1);
		WdLineWidth lineWidth = BuwT6I6Dco(P_2);
		WdBorderType[] array = new WdBorderType[6]
		{
			WdBorderType.wdBorderLeft,
			WdBorderType.wdBorderRight,
			WdBorderType.wdBorderTop,
			WdBorderType.wdBorderBottom,
			WdBorderType.wdBorderHorizontal,
			WdBorderType.wdBorderVertical
		};
		foreach (WdBorderType index in array)
		{
			P_0.Borders[index].LineStyle = wdLineStyle;
			if (wdLineStyle != WdLineStyle.wdLineStyleNone)
			{
				P_0.Borders[index].LineWidth = lineWidth;
			}
		}
	}

	private static rU18qH9owXvBsPZ0iiU KESDFbjWCy(string P_0, out TqHECLHh7ExNw6c0RJi P_1)
	{
		P_1 = null;
		JObject jObject;
		rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = NcMDagD3kQ(P_0, TqHECLHh7ExNw6c0RJi.CsBHPhLn0y, out jObject);
		if (rU18qH9owXvBsPZ0iiU2 != null)
		{
			return rU18qH9owXvBsPZ0iiU2;
		}
		try
		{
			P_1 = new TqHECLHh7ExNw6c0RJi
			{
				FontName = DZ1DAYPqfs(jObject, "fontName"),
				EastAsianFontName = DZ1DAYPqfs(jObject, "eastAsianFontName", "chineseFontName"),
				FontSize = UT9DvfDdZU(jObject, "fontSize"),
				Bold = nHMDWge4Nq(jObject, "bold"),
				Italic = nHMDWge4Nq(jObject, "italic"),
				Alignment = DZ1DAYPqfs(jObject, "alignment"),
				LeftIndentCm = UT9DvfDdZU(jObject, "leftIndentCm"),
				RightIndentCm = UT9DvfDdZU(jObject, "rightIndentCm"),
				FirstLineIndentCm = UT9DvfDdZU(jObject, "firstLineIndentCm"),
				FirstLineIndentChars = UT9DvfDdZU(jObject, "firstLineIndentChars"),
				SpaceBeforePt = UT9DvfDdZU(jObject, "spaceBeforePt"),
				SpaceAfterPt = UT9DvfDdZU(jObject, "spaceAfterPt"),
				LineSpacingRule = DZ1DAYPqfs(jObject, "lineSpacingRule"),
				LineSpacingPt = UT9DvfDdZU(jObject, "lineSpacingPt"),
				LineSpacingMultiple = UT9DvfDdZU(jObject, "lineSpacingMultiple"),
				KeepWithNext = nHMDWge4Nq(jObject, "keepWithNext"),
				KeepTogether = nHMDWge4Nq(jObject, "keepTogether"),
				PageBreakBefore = nHMDWge4Nq(jObject, "pageBreakBefore")
			};
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("formatJson 字段类型不正确。", "invalid_arguments", new
			{
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		return PsrDqJDg6c(P_1);
	}

	private static rU18qH9owXvBsPZ0iiU KRQDhebBe2(string P_0, out XqsyBVQI7dsGuEiUT3v P_1)
	{
		P_1 = null;
		JObject jObject;
		rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = NcMDagD3kQ(P_0, XqsyBVQI7dsGuEiUT3v.TcvQQSKPF8, out jObject);
		if (rU18qH9owXvBsPZ0iiU2 != null)
		{
			return rU18qH9owXvBsPZ0iiU2;
		}
		try
		{
			P_1 = new XqsyBVQI7dsGuEiUT3v
			{
				FontName = DZ1DAYPqfs(jObject, "fontName"),
				EastAsianFontName = DZ1DAYPqfs(jObject, "eastAsianFontName", "chineseFontName"),
				FontSize = UT9DvfDdZU(jObject, "fontSize"),
				Bold = nHMDWge4Nq(jObject, "bold"),
				Italic = nHMDWge4Nq(jObject, "italic"),
				Alignment = DZ1DAYPqfs(jObject, "alignment"),
				RowAlignment = DZ1DAYPqfs(jObject, "rowAlignment"),
				VerticalAlignment = DZ1DAYPqfs(jObject, "verticalAlignment"),
				AutoFit = DZ1DAYPqfs(jObject, "autoFit"),
				PreferredWidthPercent = UT9DvfDdZU(jObject, "preferredWidthPercent"),
				CellPaddingPt = UT9DvfDdZU(jObject, "cellPaddingPt"),
				RowHeightPt = UT9DvfDdZU(jObject, "rowHeightPt"),
				RowHeightRule = DZ1DAYPqfs(jObject, "rowHeightRule"),
				BorderStyle = DZ1DAYPqfs(jObject, "borderStyle"),
				BorderWidth = UT9DvfDdZU(jObject, "borderWidthPt"),
				HeaderRowBold = nHMDWge4Nq(jObject, "headerRowBold"),
				HeaderRowShading = H0yD0BAvcr(jObject, "headerRowShading")
			};
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("formatJson 字段类型不正确。", "invalid_arguments", new
			{
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		return gqaDPUNTXq(P_1);
	}

	private static rU18qH9owXvBsPZ0iiU NcMDagD3kQ(string P_0, HashSet<string> P_1, out JObject P_2)
	{
		P_2 = null;
		if (string.IsNullOrWhiteSpace(P_0))
		{
			P_0 = "{}";
		}
		try
		{
			P_2 = JObject.Parse(P_0);
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("formatJson 不是有效的 JSON 对象。", "invalid_arguments", new
			{
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		foreach (JProperty item in P_2.Properties())
		{
			if (!P_1.Contains(item.Name))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("formatJson 包含不支持的字段。", "invalid_arguments", new
				{
					field = item.Name,
					supportedFields = P_1.OrderBy((string x) => x, StringComparer.OrdinalIgnoreCase).ToArray()
				});
			}
		}
		if (!P_2.Properties().Any())
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("formatJson 至少需要包含一个格式字段。", "invalid_arguments", new
			{
				supportedFields = P_1.OrderBy((string x) => x, StringComparer.OrdinalIgnoreCase).ToArray()
			});
		}
		return null;
	}

	private static rU18qH9owXvBsPZ0iiU PsrDqJDg6c(TqHECLHh7ExNw6c0RJi P_0)
	{
		if (P_0.FontSize.HasValue && (P_0.FontSize.Value < 1f || P_0.FontSize.Value > 100f))
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("fontSize 必须在 1..100 之间。", "invalid_arguments", new { P_0.FontSize });
		}
		try
		{
			if (P_0.Alignment != null)
			{
				Pi4Dx99j6C(P_0.Alignment);
			}
			if (P_0.LineSpacingRule != null)
			{
				iTATRE4FUT(P_0.LineSpacingRule);
			}
		}
		catch (ArgumentException ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n(ex.Message, "invalid_arguments");
		}
		return null;
	}

	private static rU18qH9owXvBsPZ0iiU gqaDPUNTXq(XqsyBVQI7dsGuEiUT3v P_0)
	{
		if (P_0.FontSize.HasValue && (P_0.FontSize.Value < 1f || P_0.FontSize.Value > 100f))
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("fontSize 必须在 1..100 之间。", "invalid_arguments", new { P_0.FontSize });
		}
		if (P_0.PreferredWidthPercent.HasValue && (P_0.PreferredWidthPercent.Value <= 0f || P_0.PreferredWidthPercent.Value > 100f))
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("preferredWidthPercent 必须在 0..100 之间。", "invalid_arguments", new { P_0.PreferredWidthPercent });
		}
		try
		{
			if (P_0.Alignment != null)
			{
				Pi4Dx99j6C(P_0.Alignment);
			}
			if (P_0.RowAlignment != null)
			{
				pH4DdWNJio(P_0.RowAlignment);
			}
			if (P_0.VerticalAlignment != null)
			{
				j0jDz8lcCe(P_0.VerticalAlignment);
			}
			if (P_0.AutoFit != null)
			{
				zumTVgQhWS(P_0.AutoFit);
			}
			if (P_0.RowHeightRule != null)
			{
				v88TBQGlgu(P_0.RowHeightRule);
			}
			if (P_0.BorderStyle != null)
			{
				y8jT9OIF7R(P_0.BorderStyle);
			}
		}
		catch (ArgumentException ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n(ex.Message, "invalid_arguments");
		}
		return null;
	}

	private static string DZ1DAYPqfs(JObject P_0, params string[] names)
	{
		foreach (string text in names)
		{
			if (tM3DkUIp9d(P_0, text, out var jToken) && jToken.Type != JTokenType.Null)
			{
				return jToken.ToString().Trim();
			}
		}
		return null;
	}

	private static float? UT9DvfDdZU(JObject P_0, string P_1)
	{
		if (!tM3DkUIp9d(P_0, P_1, out var jToken) || jToken.Type == JTokenType.Null)
		{
			return null;
		}
		return jToken.Value<float>();
	}

	private static bool? nHMDWge4Nq(JObject P_0, string P_1)
	{
		if (!tM3DkUIp9d(P_0, P_1, out var jToken) || jToken.Type == JTokenType.Null)
		{
			return null;
		}
		return jToken.Value<bool>();
	}

	private static int? H0yD0BAvcr(JObject P_0, string P_1)
	{
		string text = DZ1DAYPqfs(P_0, P_1);
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		text = text.Trim();
		if (text.StartsWith("#", StringComparison.Ordinal))
		{
			text = text.Substring(1);
		}
		if (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
		{
			text = text.Substring(2);
		}
		if (text.Length == 6)
		{
			int num = int.Parse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			int num2 = (num >> 16) & 0xFF;
			int num3 = (num >> 8) & 0xFF;
			int num4 = num & 0xFF;
			return num2 + num3 * 256 + num4 * 65536;
		}
		return int.Parse(text, CultureInfo.InvariantCulture);
	}

	private static bool tM3DkUIp9d(JObject P_0, string P_1, out JToken P_2)
	{
		foreach (JProperty item in P_0.Properties())
		{
			if (string.Equals(item.Name, P_1, StringComparison.OrdinalIgnoreCase))
			{
				P_2 = item.Value;
				return true;
			}
		}
		P_2 = null;
		return false;
	}

	private static WdParagraphAlignment Pi4Dx99j6C(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim().ToLowerInvariant();
		if (text != null)
		{
			switch (text.Length)
			{
			case 4:
			{
				char c = text[0];
				if (c != 'l')
				{
					if (c != '两')
					{
						if (c != '居' || !(text == "left"))
						{
							break;
						}
						goto IL_0300;
					}
					if (!(text == "居中对齐"))
					{
						break;
					}
					goto IL_0304;
				}
				if (!(text == "两端对齐"))
				{
					break;
				}
				goto IL_02fe;
			}
			case 1:
			{
				char c = text[0];
				if (c != '右')
				{
					if (c != '左')
					{
						break;
					}
					goto IL_02fe;
				}
				goto IL_0302;
			}
			case 3:
			{
				char c = text[0];
				if (c != '右')
				{
					if (c != '左' || !(text == "左对齐"))
					{
						break;
					}
					goto IL_02fe;
				}
				if (!(text == "右对齐"))
				{
					break;
				}
				goto IL_0302;
			}
			case 6:
			{
				char c = text[4];
				if (c != 'e')
				{
					if (c != 'r' || !(text == "center"))
					{
						break;
					}
				}
				else if (!(text == "centre"))
				{
					break;
				}
				goto IL_0300;
			}
			case 2:
			{
				char c = text[0];
				if (c != '两')
				{
					if (c != '居' || !(text == "居中"))
					{
						break;
					}
					goto IL_0300;
				}
				if (!(text == "两端"))
				{
					break;
				}
				goto IL_0304;
			}
			case 5:
				if (!(text == "right"))
				{
					break;
				}
				goto IL_0302;
			case 7:
				{
					if (!(text == "justify"))
					{
						break;
					}
					goto IL_0304;
				}
				IL_0300:
				return WdParagraphAlignment.wdAlignParagraphCenter;
				IL_0304:
				return WdParagraphAlignment.wdAlignParagraphJustify;
				IL_0302:
				return WdParagraphAlignment.wdAlignParagraphRight;
				IL_02fe:
				return WdParagraphAlignment.wdAlignParagraphLeft;
			}
		}
		throw new ArgumentException("alignment 仅支持 left/center/right/justify。");
	}

	private static WdRowAlignment pH4DdWNJio(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim().ToLowerInvariant();
		if (text != null)
		{
			switch (text.Length)
			{
			case 4:
			{
				char c = text[0];
				if (c != 'l')
				{
					if (c != '居' || !(text == "left"))
					{
						break;
					}
					goto IL_0240;
				}
				if (!(text == "居中对齐"))
				{
					break;
				}
				goto IL_023e;
			}
			case 1:
			{
				char c = text[0];
				if (c != '右')
				{
					if (c != '左')
					{
						break;
					}
					goto IL_023e;
				}
				goto IL_0242;
			}
			case 3:
			{
				char c = text[0];
				if (c != '右')
				{
					if (c != '左' || !(text == "左对齐"))
					{
						break;
					}
					goto IL_023e;
				}
				if (!(text == "右对齐"))
				{
					break;
				}
				goto IL_0242;
			}
			case 6:
			{
				char c = text[4];
				if (c != 'e')
				{
					if (c != 'r' || !(text == "center"))
					{
						break;
					}
				}
				else if (!(text == "centre"))
				{
					break;
				}
				goto IL_0240;
			}
			case 2:
				if (!(text == "居中"))
				{
					break;
				}
				goto IL_0240;
			case 5:
				{
					if (!(text == "right"))
					{
						break;
					}
					goto IL_0242;
				}
				IL_023e:
				return WdRowAlignment.wdAlignRowLeft;
				IL_0242:
				return WdRowAlignment.wdAlignRowRight;
				IL_0240:
				return WdRowAlignment.wdAlignRowCenter;
			}
		}
		throw new ArgumentException("rowAlignment 仅支持 left/center/right。");
	}

	private static WdCellVerticalAlignment j0jDz8lcCe(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim().ToLowerInvariant();
		if (text != null)
		{
			switch (text.Length)
			{
			case 1:
			{
				char c = text[0];
				if (c == '上')
				{
					goto IL_0239;
				}
				if (c != '下')
				{
					break;
				}
				goto IL_023d;
			}
			case 2:
			{
				char c = text[0];
				if (c != '居')
				{
					if (c != '底')
					{
						if (c != '顶' || !(text == "top"))
						{
							break;
						}
						goto IL_0239;
					}
					if (!(text == "顶端"))
					{
						break;
					}
					goto IL_023d;
				}
				if (!(text == "居中"))
				{
					break;
				}
				goto IL_023b;
			}
			case 6:
			{
				char c = text[0];
				if (c != 'b')
				{
					if (c != 'c')
					{
						if (c != 'm' || !(text == "底端"))
						{
							break;
						}
					}
					else if (!(text == "center"))
					{
						break;
					}
					goto IL_023b;
				}
				if (!(text == "middle"))
				{
					break;
				}
				goto IL_023d;
			}
			case 3:
				if (!(text == "bottom"))
				{
					break;
				}
				goto IL_0239;
			case 4:
				{
					if (!(text == "垂直居中"))
					{
						break;
					}
					goto IL_023b;
				}
				IL_0239:
				return WdCellVerticalAlignment.wdCellAlignVerticalTop;
				IL_023d:
				return WdCellVerticalAlignment.wdCellAlignVerticalBottom;
				IL_023b:
				return WdCellVerticalAlignment.wdCellAlignVerticalCenter;
			}
		}
		throw new ArgumentException("verticalAlignment 仅支持 top/center/bottom。");
	}

	private static WdLineSpacing iTATRE4FUT(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim().ToLowerInvariant();
		if (text != null)
		{
			switch (text.Length)
			{
			case 6:
			{
				char c = text[0];
				if (c != 'd')
				{
					if (c != 's' || !(text == "single"))
					{
						break;
					}
					goto IL_0381;
				}
				if (!(text == "double"))
				{
					break;
				}
				goto IL_0385;
			}
			case 2:
			{
				char c = text[0];
				if ((uint)c <= 21452u)
				{
					if (c != '单')
					{
						if (c != '双' || !(text == "单倍"))
						{
							break;
						}
						goto IL_0385;
					}
					if (!(text == "双倍"))
					{
						break;
					}
					goto IL_0381;
				}
				if (c != '固')
				{
					if (c != '多' || !(text == "固定"))
					{
						break;
					}
					goto IL_038b;
				}
				if (!(text == "多倍"))
				{
					break;
				}
				goto IL_0387;
			}
			case 3:
			{
				char c = text[0];
				if (c != '1')
				{
					if (c != '固')
					{
						if (c != '最' || !(text == "onepointfive"))
						{
							break;
						}
						goto IL_0389;
					}
					if (!(text == "1.5"))
					{
						break;
					}
					goto IL_0387;
				}
				if (!(text == "固定值"))
				{
					break;
				}
				goto IL_0383;
			}
			case 12:
				if (!(text == "最小值"))
				{
					break;
				}
				goto IL_0383;
			case 4:
				if (!(text == "1.5倍"))
				{
					break;
				}
				goto IL_0383;
			case 5:
				if (!(text == "fixed"))
				{
					break;
				}
				goto IL_0387;
			case 7:
				if (!(text == "atleast"))
				{
					break;
				}
				goto IL_0389;
			case 8:
				{
					if (!(text == "multiple"))
					{
						break;
					}
					goto IL_038b;
				}
				IL_0387:
				return WdLineSpacing.wdLineSpaceExactly;
				IL_0385:
				return WdLineSpacing.wdLineSpaceDouble;
				IL_0389:
				return WdLineSpacing.wdLineSpaceAtLeast;
				IL_0381:
				return WdLineSpacing.wdLineSpaceSingle;
				IL_038b:
				return WdLineSpacing.wdLineSpaceMultiple;
				IL_0383:
				return WdLineSpacing.wdLineSpace1pt5;
			}
		}
		throw new ArgumentException("lineSpacingRule 仅支持 single/onePointFive/double/fixed/atLeast/multiple。");
	}

	private static WdAutoFitBehavior zumTVgQhWS(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim().ToLowerInvariant();
		if (text != null)
		{
			switch (text.Length)
			{
			case 4:
			{
				char c = text[2];
				if (c != '内')
				{
					if (c != '窗' || !(text == "content"))
					{
						break;
					}
					goto IL_0201;
				}
				if (!(text == "contents"))
				{
					break;
				}
				goto IL_01ff;
			}
			case 2:
			{
				char c = text[0];
				if (c != '固')
				{
					if (c != '页' || !(text == "根据内容"))
					{
						break;
					}
					goto IL_0201;
				}
				if (!(text == "根据窗口"))
				{
					break;
				}
				goto IL_0203;
			}
			case 7:
				if (!(text == "window"))
				{
					break;
				}
				goto IL_01ff;
			case 8:
				if (!(text == "页面"))
				{
					break;
				}
				goto IL_01ff;
			case 6:
				if (!(text == "固定"))
				{
					break;
				}
				goto IL_0201;
			case 5:
				{
					if (!(text == "fixed"))
					{
						break;
					}
					goto IL_0203;
				}
				IL_01ff:
				return WdAutoFitBehavior.wdAutoFitContent;
				IL_0201:
				return WdAutoFitBehavior.wdAutoFitWindow;
				IL_0203:
				return WdAutoFitBehavior.wdAutoFitFixed;
			}
		}
		throw new ArgumentException("autoFit 仅支持 content/window/fixed。");
	}

	private static WdRowHeightRule v88TBQGlgu(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim().ToLowerInvariant();
		if (text != null)
		{
			switch (text.Length)
			{
			case 2:
			{
				char c = text[0];
				if (c != '固')
				{
					if (c != '自' || !(text == "auto"))
					{
						break;
					}
					goto IL_01fa;
				}
				if (!(text == "自动"))
				{
					break;
				}
				goto IL_01fe;
			}
			case 7:
			{
				char c = text[0];
				if (c != 'a')
				{
					if (c != 'e' || !(text == "固定"))
					{
						break;
					}
					goto IL_01fe;
				}
				if (!(text == "atleast"))
				{
					break;
				}
				goto IL_01fc;
			}
			case 3:
			{
				char c = text[0];
				if (c != '固')
				{
					if (c != '最' || !(text == "exactly"))
					{
						break;
					}
					goto IL_01fc;
				}
				if (!(text == "最小值"))
				{
					break;
				}
				goto IL_01fe;
			}
			case 4:
				{
					if (!(text == "固定值"))
					{
						break;
					}
					goto IL_01fa;
				}
				IL_01fe:
				return WdRowHeightRule.wdRowHeightExactly;
				IL_01fc:
				return WdRowHeightRule.wdRowHeightAtLeast;
				IL_01fa:
				return WdRowHeightRule.wdRowHeightAuto;
			}
		}
		throw new ArgumentException("rowHeightRule 仅支持 auto/atLeast/exactly。");
	}

	private static WdLineStyle y8jT9OIF7R(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim().ToLowerInvariant();
		if (text != null)
		{
			switch (text.Length)
			{
			case 2:
			{
				char c = text[0];
				if (c != '单')
				{
					if (c != '实' || !(text == "none"))
					{
						break;
					}
				}
				else if (!(text == "无"))
				{
					break;
				}
				goto IL_01bd;
			}
			case 4:
				if (!(text == "无边框"))
				{
					break;
				}
				goto IL_01bb;
			case 1:
				if (!(text == "single"))
				{
					break;
				}
				goto IL_01bb;
			case 3:
				if (!(text == "solid"))
				{
					break;
				}
				goto IL_01bb;
			case 6:
				if (!(text == "单线"))
				{
					break;
				}
				goto IL_01bd;
			case 5:
				{
					if (!(text == "实线"))
					{
						break;
					}
					goto IL_01bd;
				}
				IL_01bb:
				return WdLineStyle.wdLineStyleNone;
				IL_01bd:
				return WdLineStyle.wdLineStyleSingle;
			}
		}
		throw new ArgumentException("borderStyle 仅支持 none/single。");
	}

	private static WdLineWidth BuwT6I6Dco(float? P_0)
	{
		if (!P_0.HasValue)
		{
			return WdLineWidth.wdLineWidth050pt;
		}
		float value = P_0.Value;
		if (value <= 0.25f)
		{
			return WdLineWidth.wdLineWidth025pt;
		}
		if (value <= 0.5f)
		{
			return WdLineWidth.wdLineWidth050pt;
		}
		if (value <= 0.75f)
		{
			return WdLineWidth.wdLineWidth075pt;
		}
		if (value <= 1f)
		{
			return WdLineWidth.wdLineWidth100pt;
		}
		if (value <= 1.5f)
		{
			return WdLineWidth.wdLineWidth150pt;
		}
		if (value <= 2.25f)
		{
			return WdLineWidth.wdLineWidth225pt;
		}
		if (value <= 3f)
		{
			return WdLineWidth.wdLineWidth300pt;
		}
		if (value <= 4.5f)
		{
			return WdLineWidth.wdLineWidth450pt;
		}
		return WdLineWidth.wdLineWidth600pt;
	}

	private static float bPYTuue3a0(float P_0)
	{
		return P_0 * 28.346457f;
	}

	private static void DyITDXSmDr(Microsoft.Office.Interop.Word.Application P_0, string P_1, Action P_2)
	{
		if (P_2 == null)
		{
			return;
		}
		bool flag = false;
		try
		{
			try
			{
				P_0.UndoRecord.StartCustomRecord(P_1);
				flag = true;
			}
			catch
			{
			}
			P_2();
		}
		finally
		{
			if (flag)
			{
				try
				{
					P_0.UndoRecord.EndCustomRecord();
				}
				catch
				{
				}
			}
		}
	}

	private static leN7VeTgf6SMcL2iBhQ oBKTTgZY41<leN7VeTgf6SMcL2iBhQ>(Microsoft.Office.Interop.Word.Application P_0, string P_1, Func<leN7VeTgf6SMcL2iBhQ> P_2)
	{
		_G_c__DisplayClass83_0<leN7VeTgf6SMcL2iBhQ> CS_8_locals_6 = new _G_c__DisplayClass83_0<leN7VeTgf6SMcL2iBhQ>();
		CS_8_locals_6.action = P_2;
		if (CS_8_locals_6.action == null)
		{
			return default(leN7VeTgf6SMcL2iBhQ);
		}
		CS_8_locals_6.result = default(leN7VeTgf6SMcL2iBhQ);
		Action action = delegate
		{
			CS_8_locals_6.result = CS_8_locals_6.action();
		};
		DyITDXSmDr(P_0, P_1, action);
		return CS_8_locals_6.result;
	}

	private static Dictionary<string, string> x9HT8Iew9Q(Dictionary<string, object> P_0, string P_1)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (P_0 == null || string.IsNullOrEmpty(P_1))
		{
			return dictionary;
		}
		foreach (KeyValuePair<string, object> item in P_0.OrderBy((KeyValuePair<string, object> p) => p.Key, StringComparer.Ordinal))
		{
			if (item.Key != null && item.Key.StartsWith(P_1, StringComparison.Ordinal))
			{
				dictionary[item.Key] = item.Value?.ToString() ?? string.Empty;
			}
		}
		return dictionary;
	}

	private static string QlpTIR1vVX(Dictionary<string, object> P_0, string P_1, string P_2 = "")
	{
		if (P_0 != null && P_0.TryGetValue(P_1, out var value) && value != null)
		{
			return value.ToString();
		}
		return P_2;
	}

	private static object UpjTihUo1t(Dictionary<string, object> P_0)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string[] array = new string[12]
		{
			"左侧框线",
			"右侧框线",
			"上侧框线",
			"底边框线",
			"横向框线",
			"纵向框线",
			"表头底边框线",
			"首列右边框线",
			"合计行上边框线",
			"合计行下边框线",
			"小计行上边框线",
			"小计行下边框线"
		};
		foreach (string text in array)
		{
			string text2 = QlpTIR1vVX(P_0, "表格_边框样式_" + text, null);
			string text3 = QlpTIR1vVX(P_0, "表格_边框粗细_" + text, null);
			if (string.Equals(text, "合计行下边框线", StringComparison.Ordinal))
			{
				if (string.IsNullOrEmpty(text2))
				{
					text2 = QlpTIR1vVX(P_0, "表格_边框样式_表尾底边框线", null);
				}
				if (string.IsNullOrEmpty(text3))
				{
					text3 = QlpTIR1vVX(P_0, "表格_边框粗细_表尾底边框线", null);
				}
			}
			dictionary[text] = new
			{
				style = (string.IsNullOrEmpty(text2) ? ((text == "表头底边框线") ? "0" : "1") : text2),
				width = (string.IsNullOrEmpty(text3) ? "4" : text3)
			};
		}
		return dictionary;
	}

	private static object gAdTHE0s6R(Dictionary<string, object> P_0)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string[] array = new string[5]
		{
			"首列",
			"首行",
			"文字",
			"数字",
			"合计"
		};
		foreach (string text in array)
		{
			dictionary[text] = new
			{
				horizontal = QlpTIR1vVX(P_0, "表格_段落格式_" + text + "水平对齐", (text == "数字") ? "1" : "2"),
				vertical = QlpTIR1vVX(P_0, "表格_段落格式_" + text + "垂直对齐", "1")
			};
		}
		dictionary["序号列居中"] = QlpTIR1vVX(P_0, "表格_段落格式_序号列居中", "0");
		dictionary["首行首列冲突优先级"] = QlpTIR1vVX(P_0, "表格_段落格式_首行首列冲突优先级", "首行");
		return dictionary;
	}

	private static string If1TQ6sv5o(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return string.Empty;
		}
		string text = P_0.Trim();
		if (string.Equals(text, "表后间距", StringComparison.Ordinal))
		{
			return "表后段落";
		}
		return text;
	}

	private static object DaWT1u9T3L(Dictionary<string, object> P_0, string P_1)
	{
		string text = "段落_" + P_1 + "_";
		return new
		{
			level = P_1,
			font = new
			{
				chineseFont = QlpTIR1vVX(P_0, text + "中文字体", "宋体"),
				westernFont = QlpTIR1vVX(P_0, text + "西文字体", (P_1 == "一级") ? "宋体" : "Times New Roman"),
				size = QlpTIR1vVX(P_0, text + "字号", "10.5"),
				bold = QlpTIR1vVX(P_0, text + "加粗", "0")
			},
			paragraph = new
			{
				alignment = QlpTIR1vVX(P_0, text + "对齐方式", (P_1 == "表后注释" || P_1 == "表后段落") ? "0" : "3"),
				lineSpacingRule = QlpTIR1vVX(P_0, text + "行距样式", (P_1 == "表后注释") ? "4" : "0"),
				lineSpacing = QlpTIR1vVX(P_0, text + "行距值", "18"),
				spacingUnit = QlpTIR1vVX(P_0, text + "段前距单位", (P_1 == "表后段落") ? "行" : "磅"),
				spaceBefore = QlpTIR1vVX(P_0, text + "段前距", "0"),
				spaceAfter = QlpTIR1vVX(P_0, text + "段后距", (P_1 == "表后段落") ? "0" : "2.5")
			},
			indent = new
			{
				unit = QlpTIR1vVX(P_0, text + "缩进单位", (P_1 == "表后段落") ? "字符" : "厘米"),
				left = QlpTIR1vVX(P_0, text + "左缩进", "0"),
				right = QlpTIR1vVX(P_0, text + "右缩进", "0"),
				special = QlpTIR1vVX(P_0, text + "特殊缩进", (P_1 == "表后注释") ? "首行" : "无"),
				value = QlpTIR1vVX(P_0, text + "缩进值", (P_1 == "表后注释" || P_1 == "表后段落") ? "2" : "0")
			},
			raw = x9HT8Iew9Q(P_0, text)
		};
	}

	private static Table LVOTrE16IP(Microsoft.Office.Interop.Word.Application P_0, Document P_1, int P_2)
	{
		if (P_1 == null)
		{
			throw new InvalidOperationException("当前没有打开的 Word 文档。");
		}
		if (P_2 > 0)
		{
			if (P_2 > P_1.Tables.Count)
			{
				throw new ArgumentException("tableIndex is out of range.");
			}
			return P_1.Tables[P_2];
		}
		if (P_0?.Selection != null && P_0.Selection.Tables.Count > 0)
		{
			return P_0.Selection.Tables[1];
		}
		throw new ArgumentException("当前选区中没有表格，且 tableIndex 未指定。");
	}

	private static Paragraph jNyTJ8ZWsU(Microsoft.Office.Interop.Word.Application P_0, Document P_1)
	{
		if (P_1 == null)
		{
			throw new InvalidOperationException("当前没有打开的 Word 文档。");
		}
		if (P_0?.Selection != null && P_0.Selection.Paragraphs.Count > 0)
		{
			return P_0.Selection.Paragraphs[1];
		}
		throw new ArgumentException("当前选区中没有段落，且 paragraphIndex 未指定。");
	}

	private static int hRkT3V0ljO(Document P_0, Table P_1)
	{
		try
		{
			int start = P_1.Range.Start;
			int count = P_0.Tables.Count;
			for (int i = 1; i <= count; i++)
			{
				if (P_0.Tables[i].Range.Start == start)
				{
					return i;
				}
			}
		}
		catch
		{
		}
		return 0;
	}

	private static object rROTUTwJ2p(Font P_0)
	{
		_G_c__DisplayClass93_0 CS_8_locals_8 = new _G_c__DisplayClass93_0();
		CS_8_locals_8.NVTxqt1jLs = P_0;
		return new
		{
			nameFarEast = iOW8KTFwda(() => CS_8_locals_8.NVTxqt1jLs.NameFarEast),
			nameAscii = iOW8KTFwda(() => CS_8_locals_8.NVTxqt1jLs.NameAscii),
			nameOther = iOW8KTFwda(() => CS_8_locals_8.NVTxqt1jLs.NameOther),
			size = Ex5TMxi7X1(() => CS_8_locals_8.NVTxqt1jLs.Size, 0f),
			bold = Ex5TMxi7X1(() => CS_8_locals_8.NVTxqt1jLs.Bold, 0),
			italic = Ex5TMxi7X1(() => CS_8_locals_8.NVTxqt1jLs.Italic, 0),
			underline = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_8.NVTxqt1jLs.Underline, WdUnderline.wdUnderlineNone))
		};
	}

	private static object pyaTKvLinx(ParagraphFormat P_0)
	{
		_G_c__DisplayClass94_0 CS_8_locals_14 = new _G_c__DisplayClass94_0();
		CS_8_locals_14.S5gd6qUCLa = P_0;
		return new
		{
			alignment = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.Alignment, WdParagraphAlignment.wdAlignParagraphLeft)),
			lineSpacingRule = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.LineSpacingRule, WdLineSpacing.wdLineSpaceSingle)),
			lineSpacing = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.LineSpacing, 0f),
			spaceBefore = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.SpaceBefore, 0f),
			spaceAfter = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.SpaceAfter, 0f),
			lineUnitBefore = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.LineUnitBefore, 0f),
			lineUnitAfter = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.LineUnitAfter, 0f),
			leftIndent = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.LeftIndent, 0f),
			rightIndent = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.RightIndent, 0f),
			firstLineIndent = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.FirstLineIndent, 0f),
			characterUnitLeftIndent = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.CharacterUnitLeftIndent, 0f),
			characterUnitRightIndent = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.CharacterUnitRightIndent, 0f),
			characterUnitFirstLineIndent = Ex5TMxi7X1(() => CS_8_locals_14.S5gd6qUCLa.CharacterUnitFirstLineIndent, 0f)
		};
	}

	private static object PruTEuRUN6(Table P_0)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		FkpT20d5ct(dictionary, P_0, "left", WdBorderType.wdBorderLeft);
		FkpT20d5ct(dictionary, P_0, "right", WdBorderType.wdBorderRight);
		FkpT20d5ct(dictionary, P_0, "top", WdBorderType.wdBorderTop);
		FkpT20d5ct(dictionary, P_0, "bottom", WdBorderType.wdBorderBottom);
		FkpT20d5ct(dictionary, P_0, "horizontal", WdBorderType.wdBorderHorizontal);
		FkpT20d5ct(dictionary, P_0, "vertical", WdBorderType.wdBorderVertical);
		return dictionary;
	}

	private static void FkpT20d5ct(Dictionary<string, object> P_0, Table P_1, string P_2, WdBorderType P_3)
	{
		_G_c__DisplayClass96_0 CS_8_locals_6 = new _G_c__DisplayClass96_0();
		CS_8_locals_6.jp1dT3cVVx = P_1;
		CS_8_locals_6.Y1edgVLWWb = P_3;
		P_0[P_2] = new
		{
			lineStyle = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_6.jp1dT3cVVx.Borders[CS_8_locals_6.Y1edgVLWWb].LineStyle, WdLineStyle.wdLineStyleNone)),
			lineWidth = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_6.jp1dT3cVVx.Borders[CS_8_locals_6.Y1edgVLWWb].LineWidth, WdLineWidth.wdLineWidth025pt))
		};
	}

	private static object z71T41pygj(Table P_0)
	{
		List<object> list = new List<object>();
		RGSTjH6sqR(list, P_0, "firstCell", 1, 1);
		RGSTjH6sqR(list, P_0, "firstBodyCell", Math.Min(2, PJm8rI8jwn(P_0)), 1);
		int num = PJm8rI8jwn(P_0);
		int num2 = ldc8JB4JIl(P_0);
		if (num > 0 && num2 > 0)
		{
			RGSTjH6sqR(list, P_0, "lastCell", num, num2);
		}
		return list;
	}

	private static void RGSTjH6sqR(List<object> P_0, Table P_1, string P_2, int P_3, int P_4)
	{
		if (P_3 < 1 || P_4 < 1)
		{
			return;
		}
		try
		{
			_G_c__DisplayClass98_0 CS_8_locals_5 = new _G_c__DisplayClass98_0();
			CS_8_locals_5.gAJdIPCcIZ = P_1.Cell(P_3, P_4);
			P_0.Add(new
			{
				role = P_2,
				rowIndex = P_3,
				columnIndex = P_4,
				text = rYN8Y355we(Pfn84MVBvM(CS_8_locals_5.gAJdIPCcIZ.Range.Text), 120),
				font = rROTUTwJ2p(CS_8_locals_5.gAJdIPCcIZ.Range.Font),
				paragraphFormat = pyaTKvLinx(CS_8_locals_5.gAJdIPCcIZ.Range.ParagraphFormat),
				verticalAlignment = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_5.gAJdIPCcIZ.VerticalAlignment, WdCellVerticalAlignment.wdCellAlignVerticalTop))
			});
		}
		catch
		{
		}
	}

	private static object NYGTYpKoUO<dRrZRuTZCuWialCJa6A>(dRrZRuTZCuWialCJa6A TZst1wTfm3IVIg126Al) where dRrZRuTZCuWialCJa6A : struct
	{
		return new
		{
			value = Convert.ToInt32(TZst1wTfm3IVIg126Al, CultureInfo.InvariantCulture),
			name = TZst1wTfm3IVIg126Al.ToString()
		};
	}

	private static FWTDfCTb4Iku8JfLc66 Ex5TMxi7X1<FWTDfCTb4Iku8JfLc66>(Func<FWTDfCTb4Iku8JfLc66> P_0, FWTDfCTb4Iku8JfLc66 ypQS6RTSiCdpSgKNQtr)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return ypQS6RTSiCdpSgKNQtr;
		}
	}

	private rU18qH9owXvBsPZ0iiU gkrTwt4m8C(string P_0, Func<Microsoft.Office.Interop.Word.Application, rU18qH9owXvBsPZ0iiU> P_1)
	{
		_G_c__DisplayClass101_0 CS_8_locals_14 = new _G_c__DisplayClass101_0();
		CS_8_locals_14.DcQPO8MZst = P_0;
		CS_8_locals_14.ntwPnGtes4 = P_1;
		CS_8_locals_14.L8uP766qcr = Stopwatch.StartNew();
		try
		{
			return BoF8lSa1nx.MdXJlVhPku(CS_8_locals_14.DcQPO8MZst, delegate(Microsoft.Office.Interop.Word.Application app)
			{
				string text = TEu80pJf6BRff8wZLuh.gEFJbNPT5J(app);
				if (!string.IsNullOrWhiteSpace(text))
				{
					return TEu80pJf6BRff8wZLuh.dclJSetxGY(text);
				}
				yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[AI Tool][Word] " + CS_8_locals_14.DcQPO8MZst);
				rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = CS_8_locals_14.ntwPnGtes4(app);
				CS_8_locals_14.L8uP766qcr.Stop();
				yR9thasHZ73xXm8eKwj.swCsJ4IbrL(" failed; ElapsedMs=" + CS_8_locals_14.DcQPO8MZst + " failed" + (rU18qH9owXvBsPZ0iiU2?.success ?? false) + "word_error" + CS_8_locals_14.L8uP766qcr.ElapsedMilliseconds);
				return rU18qH9owXvBsPZ0iiU2;
			});
		}
		catch (Exception ex)
		{
			if (CS_8_locals_14.L8uP766qcr.IsRunning)
			{
				CS_8_locals_14.L8uP766qcr.Stop();
			}
			yR9thasHZ73xXm8eKwj.ujWsURly3F("startParagraphIndex=0 表示当前选区，此时 endParagraphIndex 必须为 0。" + CS_8_locals_14.DcQPO8MZst + "invalid_arguments" + CS_8_locals_14.L8uP766qcr.ElapsedMilliseconds, ex);
			return rU18qH9owXvBsPZ0iiU.g7A9nYlk8v(CS_8_locals_14.DcQPO8MZst + "endParagraphIndex must be greater than or equal to startParagraphIndex.", "invalid_arguments", ex);
		}
	}

	private static Document ca8TtvS05W(Microsoft.Office.Interop.Word.Application P_0)
	{
		return BZOrlUu1R80X7V7qPHv.zrqujYgRXw(P_0);
	}

	private static Range fyVTLmFfU6(Document P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			throw new InvalidOperationException("当前没有打开的 Word 文档。");
		}
		int start = P_0.Content.Start;
		int end = P_0.Content.End;
		if (P_1 < start || P_2 > end || P_2 <= P_1)
		{
			throw new ArgumentException("rangeStart/rangeEnd 超出文档范围或顺序无效。");
		}
		object Start = P_1;
		object End = P_2;
		return P_0.Range(ref Start, ref End);
	}

	private static Range k5cTsYBg89(Document P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			throw new InvalidOperationException("当前没有打开的 Word 文档。");
		}
		int start = P_0.Content.Start;
		int end = P_0.Content.End;
		if (P_1 < start || P_2 > end || P_2 < P_1)
		{
			throw new ArgumentException("rangeStart/rangeEnd 超出文档范围或顺序无效。");
		}
		object Start = P_1;
		object End = P_2;
		return P_0.Range(ref Start, ref End);
	}

	private static rU18qH9owXvBsPZ0iiU JXpTldftkV(Document P_0, int P_1, int P_2, int P_3, out Range P_4)
	{
		P_4 = null;
		if (P_0 == null)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前没有打开的 Word 文档。", "no_document");
		}
		if (P_1 < 1 || P_1 > P_0.Paragraphs.Count)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("paragraphIndex is out of range.", "invalid_arguments", new
			{
				paragraphIndex = P_1,
				totalParagraphs = P_0.Paragraphs.Count,
				coordinateRequirement = "add_word_comment_at_paragraph_range 只接受真实 Word COM 段落坐标。OpenXML/正则筛查返回的 paragraphIndex/charIndexStart/End 不能直接用于此工具。正文批注优先使用 find_word_text 获取 rangeStart/rangeEnd 后调用 add_word_comment_at_range。"
			});
		}
		if (P_2 < 1 || P_3 < P_2)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("charIndexStart/charIndexEnd are invalid.", "invalid_arguments", new
			{
				paragraphIndex = P_1,
				charIndexStart = P_2,
				charIndexEnd = P_3,
				coordinateRequirement = "段落和字符坐标必须来自真实 Word COM 坐标。"
			});
		}
		Paragraph paragraph = P_0.Paragraphs[P_1];
		string text = Pfn84MVBvM(paragraph.Range.Text);
		int num = Math.Max(1, text.Length);
		if (P_3 > num)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("charIndexEnd is out of range for the COM paragraph.", "invalid_arguments", new
			{
				paragraphIndex = P_1,
				charIndexStart = P_2,
				charIndexEnd = P_3,
				paragraphTextLength = num,
				paragraphPreview = rYN8Y355we(text, 240),
				coordinateRequirement = "add_word_comment_at_paragraph_range 只接受真实 Word COM 段落坐标。OpenXML/正则筛查返回的 paragraphIndex/charIndexStart/End 不能直接用于此工具。正文批注优先使用 find_word_text 获取 rangeStart/rangeEnd 后调用 add_word_comment_at_range。"
			});
		}
		int num2 = paragraph.Range.Start + P_2 - 1;
		int num3 = Math.Min(paragraph.Range.End - 1, paragraph.Range.Start + P_3);
		if (num3 <= num2)
		{
			num3 = Math.Min(paragraph.Range.End, num2 + 1);
		}
		object Start = num2;
		object End = num3;
		P_4 = P_0.Range(ref Start, ref End);
		return null;
	}

	private static Range c44TNm5vXa(Document P_0, int P_1, int P_2, int P_3)
	{
		if (P_1 < 1 || P_1 > P_0.Paragraphs.Count)
		{
			throw new ArgumentException("paragraphIndex is out of range.");
		}
		if (P_2 < 1 || P_3 < P_2)
		{
			throw new ArgumentException("charIndexStart/charIndexEnd are invalid.");
		}
		Paragraph paragraph = P_0.Paragraphs[P_1];
		string text = Pfn84MVBvM(paragraph.Range.Text);
		if (P_3 > Math.Max(1, text.Length))
		{
			throw new ArgumentException("charIndexEnd is out of range.");
		}
		int num = paragraph.Range.Start + P_2 - 1;
		int num2 = Math.Min(paragraph.Range.End - 1, paragraph.Range.Start + P_3);
		if (num2 <= num)
		{
			num2 = Math.Min(paragraph.Range.End, num + 1);
		}
		object Start = num;
		object End = num2;
		return P_0.Range(ref Start, ref End);
	}

	private static Cell DOQTmyyLCk(Document P_0, int P_1, int P_2, int P_3)
	{
		if (P_1 < 1 || P_1 > P_0.Tables.Count)
		{
			throw new ArgumentException("tableIndex is out of range.");
		}
		Table table = P_0.Tables[P_1];
		if (P_2 < 1 || P_2 > PJm8rI8jwn(table))
		{
			throw new ArgumentException("rowIndex is out of range.");
		}
		if (P_3 < 1 || P_3 > ldc8JB4JIl(table))
		{
			throw new ArgumentException("columnIndex is out of range.");
		}
		return table.Cell(P_2, P_3);
	}

	private static Paragraph U09ToZPpqq(Document P_0, int P_1)
	{
		if (P_0 == null)
		{
			throw new InvalidOperationException("当前没有打开的 Word 文档。");
		}
		if (P_1 < 1 || P_1 > P_0.Paragraphs.Count)
		{
			throw new ArgumentException("paragraphIndex is out of range.");
		}
		return P_0.Paragraphs[P_1];
	}

	private static rU18qH9owXvBsPZ0iiU t23TGJmlwr(Document P_0, int P_1, int P_2, int P_3, out Cell P_4)
	{
		P_4 = null;
		if (P_0 == null)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前没有打开的 Word 文档。", "no_document");
		}
		if (P_1 < 1 || P_1 > P_0.Tables.Count)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("tableIndex is out of range.", "invalid_arguments", new
			{
				tableIndex = P_1,
				totalTables = P_0.Tables.Count
			});
		}
		Table table = P_0.Tables[P_1];
		int num = PJm8rI8jwn(table);
		int num2 = ldc8JB4JIl(table);
		if (P_2 < 1 || P_2 > num)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("rowIndex is out of range.", "invalid_arguments", new
			{
				tableIndex = P_1,
				rowIndex = P_2,
				rows = num
			});
		}
		if (P_3 < 1 || P_3 > num2)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("columnIndex is out of range.", "invalid_arguments", new
			{
				tableIndex = P_1,
				columnIndex = P_3,
				columns = num2
			});
		}
		try
		{
			P_4 = table.Cell(P_2, P_3);
			return null;
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("该表格单元格无法通过行列坐标精确定位，可能存在合并单元格。", "table_cell_unavailable", new
			{
				tableIndex = P_1,
				rowIndex = P_2,
				columnIndex = P_3,
				rows = num,
				columns = num2,
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
	}

	private static List<WKGvoki3QLNecqlT5em> FMtTCCF91i(Microsoft.Office.Interop.Word.Application P_0, Document P_1, int P_2, int P_3)
	{
		List<WKGvoki3QLNecqlT5em> list = new List<WKGvoki3QLNecqlT5em>();
		if (P_2 == 0)
		{
			_G_c__DisplayClass110_0 CS_8_locals_5 = new _G_c__DisplayClass110_0();
			CS_8_locals_5.SxpPco33lP = P_0.Selection;
			if (CS_8_locals_5.SxpPco33lP == null || CS_8_locals_5.SxpPco33lP.Paragraphs == null)
			{
				return list;
			}
			int num = Y1x8gkTvcF(() => CS_8_locals_5.SxpPco33lP.Paragraphs.Count);
			HashSet<int> hashSet = new HashSet<int>();
			for (int num2 = 1; num2 <= num; num2++)
			{
				Paragraph paragraph = CS_8_locals_5.SxpPco33lP.Paragraphs[num2];
				int valueOrDefault = EFt8ufX87I(P_1, paragraph.Range.Start).GetValueOrDefault();
				if (valueOrDefault > 0 && XMVgr0DwLb(paragraph.Range) && hashSet.Add(valueOrDefault))
				{
					list.Add(new WKGvoki3QLNecqlT5em(valueOrDefault, paragraph));
				}
			}
			return list;
		}
		int num3 = ((P_3 > 0) ? P_3 : P_2);
		for (int num4 = P_2; num4 <= num3; num4++)
		{
			list.Add(new WKGvoki3QLNecqlT5em(num4, U09ToZPpqq(P_1, num4)));
		}
		return list;
	}

	private static Range NPITpB49xY(Cell P_0)
	{
		try
		{
			Range duplicate = P_0.Range.Duplicate;
			int start = duplicate.Start;
			int num = Math.Max(start, duplicate.End - 1);
			int num2 = Math.Min(num, start + 1);
			if (num2 <= start && num > start)
			{
				num2 = num;
			}
			duplicate.SetRange(start, num2);
			return duplicate;
		}
		catch
		{
			return P_0?.Range;
		}
	}

	private static rU18qH9owXvBsPZ0iiU PPXTOUDVLE(Document P_0, bool P_1, Func<rU18qH9owXvBsPZ0iiU> P_2, Microsoft.Office.Interop.Word.Application P_3 = null, Range P_4 = null, string P_5 = null)
	{
		_G_c__DisplayClass112_0 CS_8_locals_10 = new _G_c__DisplayClass112_0();
		CS_8_locals_10.doc = P_0;
		CS_8_locals_10.iHsPytK5nj = P_1;
		CS_8_locals_10.mL2PXSVZkT = P_2;
		if (P_3 != null && P_4 != null)
		{
			rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = Q7Sg1pThfx(P_3, CS_8_locals_10.doc, P_4);
			if (CS_8_locals_10.iHsPytK5nj && rU18qH9owXvBsPZ0iiU2 != null)
			{
				return rU18qH9owXvBsPZ0iiU2;
			}
		}
		Func<rU18qH9owXvBsPZ0iiU> func = delegate
		{
			bool trackRevisions = CS_8_locals_10.doc.TrackRevisions;
			try
			{
				CS_8_locals_10.doc.TrackRevisions = CS_8_locals_10.iHsPytK5nj;
				return CS_8_locals_10.mL2PXSVZkT();
			}
			finally
			{
				CS_8_locals_10.doc.TrackRevisions = trackRevisions;
			}
		};
		if (P_3 != null && !string.IsNullOrWhiteSpace(P_5))
		{
			return oBKTTgZY41(P_3, P_5, func);
		}
		return func();
	}

	private static string LvkTnN0GBt(string P_0)
	{
		string text = (P_0 ?? "replace_empty_paragraph").Trim().ToLowerInvariant();
		if (text == "replace_empty_paragraph" || text == "replace" || text == "current" || text == "空段落")
		{
			return "replace_empty_paragraph";
		}
		if (text == "before" || text == "above" || text == "前" || text == "上方")
		{
			return "before";
		}
		if (text == "after" || text == "below" || text == "后" || text == "下方")
		{
			return "after";
		}
		return null;
	}

	private static rU18qH9owXvBsPZ0iiU CofT7m3Hd8(Document P_0, Range P_1, int P_2, int P_3, string P_4, bool P_5, bool P_6, out kbbtxWHjbwr4EoVfC7y P_7)
	{
		_G_c__DisplayClass114_0 CS_8_locals_15 = new _G_c__DisplayClass114_0();
		CS_8_locals_15.KjZPAhp8aP = P_1;
		CS_8_locals_15.doc = P_0;
		P_7 = null;
		if (CS_8_locals_15.doc == null || CS_8_locals_15.KjZPAhp8aP == null)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("引用 Range 不可用。", "invalid_arguments");
		}
		if (Y1x8gkTvcF(() => CS_8_locals_15.KjZPAhp8aP.Tables.Count) > 0)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("目标 Range 位于已有表格中。插入新表请选中正文空段落；已有表内加行请使用 insert_word_table_rows_by_model。", "target_range_inside_table");
		}
		Paragraph paragraph;
		try
		{
			paragraph = CS_8_locals_15.KjZPAhp8aP.Paragraphs[1];
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("目标 Range 未落在可用正文段落中。", "paragraph_unavailable", new
			{
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		if (paragraph == null || paragraph.Range == null)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("目标 Range 未落在可用正文段落中。", "paragraph_unavailable");
		}
		CS_8_locals_15.irDPv8cQCT = paragraph.Range.Duplicate;
		string text = Pfn84MVBvM(iOW8KTFwda(() => CS_8_locals_15.irDPv8cQCT.Text));
		bool flag = string.IsNullOrWhiteSpace(text);
		if (string.Equals(P_4, "replace_empty_paragraph", StringComparison.Ordinal) && !flag)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("placement=replace_empty_paragraph 只能用于空段落。若要在非空段落前后插表，请传 placement=before 或 after。", "target_paragraph_not_empty", new
			{
				paragraphText = rYN8Y355we(text, 240)
			});
		}
		int num = Ex5TMxi7X1(() => CS_8_locals_15.irDPv8cQCT.Start, CS_8_locals_15.KjZPAhp8aP.Start);
		int num2 = Ex5TMxi7X1(() => CS_8_locals_15.irDPv8cQCT.End, CS_8_locals_15.KjZPAhp8aP.End);
		int insertionStart = num;
		if (string.Equals(P_4, "after", StringComparison.Ordinal))
		{
			insertionStart = num2;
		}
		P_7 = new kbbtxWHjbwr4EoVfC7y
		{
			Rows = P_2,
			Columns = P_3,
			Placement = P_4,
			UseTrackChanges = P_5,
			AdjustAfterInsert = P_6,
			ParagraphStart = num,
			ParagraphEnd = num2,
			InsertionStart = insertionStart,
			ParagraphText = text,
			ParagraphIsEmpty = flag,
			Page = Y878QfFgDa(CS_8_locals_15.irDPv8cQCT),
			TableCountBefore = Y1x8gkTvcF(() => CS_8_locals_15.doc.Tables.Count),
			FocusRange = CS_8_locals_15.irDPv8cQCT
		};
		return null;
	}

	private static object XayT5NOjBp(Document P_0, int P_1, int P_2, string P_3, kbbtxWHjbwr4EoVfC7y P_4)
	{
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			rangeStart = P_1,
			rangeEnd = P_2,
			placement = P_4.Placement,
			rows = P_4.Rows,
			columns = P_4.Columns,
			useTrackChanges = P_4.UseTrackChanges,
			adjustAfterInsert = P_4.AdjustAfterInsert,
			expectedChangeCount = 1,
			previewToken = P_3,
			paragraph = new
			{
				page = ((P_4.Page == 0) ? ((int?)null) : new int?(P_4.Page)),
				rangeStart = P_4.ParagraphStart,
				rangeEnd = P_4.ParagraphEnd,
				isEmpty = P_4.ParagraphIsEmpty,
				text = P_4.ParagraphText
			},
			tableCountBefore = P_4.TableCountBefore
		};
	}

	private static string BIJTcpAmqJ(Document P_0, int P_1, int P_2, kbbtxWHjbwr4EoVfC7y P_3)
	{
		_G_c__DisplayClass116_0 CS_8_locals_2 = new _G_c__DisplayClass116_0();
		CS_8_locals_2.doc = P_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(iOW8KTFwda(() => CS_8_locals_2.doc.FullName)).Append('|').Append(P_1.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_2.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.Rows.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.Columns.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.Placement)
			.Append('|')
			.Append(P_3.UseTrackChanges ? "F" : "T")
			.Append('|')
			.Append(P_3.AdjustAfterInsert ? "N" : "A")
			.Append('|')
			.Append(P_3.ParagraphStart.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.ParagraphEnd.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.InsertionStart.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.ParagraphIsEmpty ? "N" : "E")
			.Append('|')
			.Append(P_3.TableCountBefore.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.ParagraphText ?? string.Empty);
		using SHA256 sHA = SHA256.Create();
		byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
		return Convert.ToBase64String(sHA.ComputeHash(bytes)).TrimEnd('=').Replace('+', '-')
			.Replace('/', '_');
	}

	private static bool psHTenZWYL(Document P_0, kbbtxWHjbwr4EoVfC7y P_1, out Table P_2, out string P_3)
	{
		P_2 = null;
		P_3 = string.Empty;
		try
		{
			Range range2;
			object Start;
			object End;
			if (string.Equals(P_1.Placement, "replace_empty_paragraph", StringComparison.Ordinal))
			{
				Start = P_1.ParagraphStart;
				End = P_1.ParagraphEnd;
				Range range = P_0.Range(ref Start, ref End);
				End = Type.Missing;
				Start = Type.Missing;
				range.Delete(ref End, ref Start);
				int num = Math.Max(P_0.Content.Start, Math.Min(P_1.ParagraphStart, P_0.Content.End));
				Start = num;
				End = num;
				range2 = P_0.Range(ref Start, ref End);
			}
			else
			{
				int num2 = Math.Max(P_0.Content.Start, Math.Min(P_1.InsertionStart, P_0.Content.End));
				End = num2;
				Start = num2;
				range2 = P_0.Range(ref End, ref Start);
			}
			Tables tables = P_0.Tables;
			Range range3 = range2;
			int rows = P_1.Rows;
			int columns = P_1.Columns;
			Start = Type.Missing;
			End = Type.Missing;
			P_2 = tables.Add(range3, rows, columns, ref Start, ref End);
			try
			{
				P_2.Borders.Enable = 1;
			}
			catch
			{
			}
			try
			{
				P_2.Range.Select();
			}
			catch
			{
			}
			return P_2 != null;
		}
		catch (Exception ex)
		{
			P_3 = ex.GetType().Name + ": " + ex.Message;
			return false;
		}
	}

	private static bool EOXTyRsfXn(Table P_0, out string P_1)
	{
		P_1 = string.Empty;
		try
		{
			if (P_0 == null)
			{
				P_1 = "table is null";
				return false;
			}
			P_0.Range.Select();
			xfHg3PXS6T();
			MTM8HqftP23tlVOKhjT.HUeflwYrZr();
			try
			{
				P_0.Range.Select();
			}
			catch
			{
			}
			return true;
		}
		catch (Exception ex)
		{
			P_1 = ex.GetType().Name + ": " + ex.Message;
			return false;
		}
	}

	private static string vq0TXPC0AY(string P_0)
	{
		string text = (P_0 ?? "after").Trim().ToLowerInvariant();
		if (text == "before" || text == "above" || text == "前" || text == "上方")
		{
			return "before";
		}
		if (text == "after" || text == "below" || text == "后" || text == "下方")
		{
			return "after";
		}
		return null;
	}

	private static rU18qH9owXvBsPZ0iiU NioTFK99GE(Range P_0, int P_1, int P_2, string P_3, int P_4, bool P_5, string P_6, out cdmxD7HD8upDSKfXwCW P_7)
	{
		_G_c__DisplayClass120_0 CS_8_locals_10 = new _G_c__DisplayClass120_0();
		CS_8_locals_10.YFePdnGL8J = P_0;
		P_7 = null;
		if (CS_8_locals_10.YFePdnGL8J == null)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("引用 Range 不可用。", "invalid_arguments");
		}
		int num = Y1x8gkTvcF(() => CS_8_locals_10.YFePdnGL8J.Tables.Count);
		if (P_1 < 1 || P_1 > num)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("localTableIndex 超出引用选区内表格数量。", "local_table_index_out_of_range", new
			{
				localTableIndex = P_1,
				tableCount = num
			});
		}
		Table table;
		try
		{
			table = CS_8_locals_10.YFePdnGL8J.Tables[P_1];
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("无法读取引用选区内的目标表格。", "table_unavailable", new
			{
				localTableIndex = P_1,
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		HbPTWYrAup(table, out var num2, out var columnsBefore);
		if (num2 <= 0)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("无法读取目标表格行数。", "table_structure_unavailable", new
			{
				localTableIndex = P_1
			});
		}
		if (P_2 < 1 || P_2 > num2)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("anchorRowIndex 超出目标表格行数。", "anchor_row_out_of_range", new
			{
				anchorRowIndex = P_2,
				rows = num2
			});
		}
		if (!DoUTvWGE2o(table, P_2, out CS_8_locals_10.Og9PzULlg1))
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("无法在锚点行中找到可选中的真实 Word 单元格。", "anchor_row_unavailable", new
			{
				localTableIndex = P_1,
				anchorRowIndex = P_2
			});
		}
		string text = BlET0SQkk3(table, P_2, 500);
		string text2 = Pfn84MVBvM(P_6);
		if (!string.IsNullOrWhiteSpace(text2) && text.IndexOf(text2, StringComparison.CurrentCultureIgnoreCase) < 0)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("锚点行文本与 expectedAnchorText 不一致。请重新读取表格结构后再插行。", "anchor_text_mismatch", new
			{
				localTableIndex = P_1,
				anchorRowIndex = P_2,
				expectedAnchorText = text2,
				anchorRowText = text
			});
		}
		LAxgB3C8QE(CS_8_locals_10.Og9PzULlg1, out var _, out var anchorColumnIndex);
		P_7 = new cdmxD7HD8upDSKfXwCW
		{
			LocalTableIndex = P_1,
			AnchorRowIndex = P_2,
			AnchorColumnIndex = anchorColumnIndex,
			Position = P_3,
			Count = P_4,
			UseTrackChanges = P_5,
			ExpectedAnchorText = text2,
			AnchorRowText = text,
			RowsBefore = num2,
			ColumnsBefore = columnsBefore,
			AnchorRangeStart = Ex5TMxi7X1(() => CS_8_locals_10.Og9PzULlg1.Range.Start, 0),
			AnchorRangeEnd = Ex5TMxi7X1(() => CS_8_locals_10.Og9PzULlg1.Range.End, 0),
			Page = Y878QfFgDa(CS_8_locals_10.Og9PzULlg1.Range),
			Table = table,
			AnchorCell = CS_8_locals_10.Og9PzULlg1
		};
		return null;
	}

	private static object fYyThhstYU(Document P_0, int P_1, int P_2, string P_3, cdmxD7HD8upDSKfXwCW P_4)
	{
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			rangeStart = P_1,
			rangeEnd = P_2,
			coordinateSystem = "localTableIndex and anchorRowIndex are 1-based within the referenced Word range.",
			localTableIndex = P_4.LocalTableIndex,
			anchorRowIndex = P_4.AnchorRowIndex,
			position = P_4.Position,
			count = P_4.Count,
			useTrackChanges = P_4.UseTrackChanges,
			expectedChangeCount = P_4.Count,
			previewToken = P_3,
			rowsBefore = P_4.RowsBefore,
			columnsBefore = P_4.ColumnsBefore,
			insertedRows = h6ATqqIsId(P_4),
			anchor = emITal7V84(P_4)
		};
	}

	private static object emITal7V84(cdmxD7HD8upDSKfXwCW P_0)
	{
		return new
		{
			localTableIndex = P_0.LocalTableIndex,
			rowIndex = P_0.AnchorRowIndex,
			columnIndex = ((P_0.AnchorColumnIndex == 0) ? ((int?)null) : new int?(P_0.AnchorColumnIndex)),
			page = ((P_0.Page == 0) ? ((int?)null) : new int?(P_0.Page)),
			rangeStart = ((P_0.AnchorRangeStart == 0) ? ((int?)null) : new int?(P_0.AnchorRangeStart)),
			rangeEnd = ((P_0.AnchorRangeEnd == 0) ? ((int?)null) : new int?(P_0.AnchorRangeEnd)),
			rowText = P_0.AnchorRowText,
			expectedAnchorText = (string.IsNullOrWhiteSpace(P_0.ExpectedAnchorText) ? null : P_0.ExpectedAnchorText)
		};
	}

	private static List<object> h6ATqqIsId(cdmxD7HD8upDSKfXwCW P_0)
	{
		List<object> list = new List<object>();
		int num = (string.Equals(P_0.Position, "before", StringComparison.Ordinal) ? P_0.AnchorRowIndex : (P_0.AnchorRowIndex + 1));
		for (int i = 0; i < P_0.Count; i++)
		{
			list.Add(new
			{
				localTableIndex = P_0.LocalTableIndex,
				rowIndex = num + i
			});
		}
		return list;
	}

	private static string lKeTPQlpbN(Document P_0, int P_1, int P_2, cdmxD7HD8upDSKfXwCW P_3)
	{
		_G_c__DisplayClass124_0 CS_8_locals_2 = new _G_c__DisplayClass124_0();
		CS_8_locals_2.doc = P_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(iOW8KTFwda(() => CS_8_locals_2.doc.FullName)).Append('|').Append(P_1.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_2.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.LocalTableIndex.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.AnchorRowIndex.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.Position)
			.Append('|')
			.Append(P_3.Count.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.UseTrackChanges ? "F" : "T")
			.Append('|')
			.Append(P_3.RowsBefore.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.ColumnsBefore.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.AnchorColumnIndex.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.AnchorRangeStart.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.AnchorRangeEnd.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_3.AnchorRowText ?? string.Empty);
		using SHA256 sHA = SHA256.Create();
		byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
		return Convert.ToBase64String(sHA.ComputeHash(bytes)).TrimEnd('=').Replace('+', '-')
			.Replace('/', '_');
	}

	private static bool M4PTA9V6B2(Microsoft.Office.Interop.Word.Application P_0, Cell P_1, string P_2, int P_3, out string P_4)
	{
		P_4 = string.Empty;
		try
		{
			if (P_1 == null)
			{
				P_4 = "anchor cell is null";
				return false;
			}
			P_1.Select();
			xfHg3PXS6T();
			dynamic selection = P_0.Selection;
			if (selection == null)
			{
				P_4 = "Word selection is unavailable";
				return false;
			}
			if (string.Equals(P_2, "before", StringComparison.Ordinal))
			{
				if (_G_o__125.R5GdQcN6Hi == null)
				{
					_G_o__125.R5GdQcN6Hi = CallSite<object>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "TryInsertRowsAbove", null, typeof(kyVxiEuxDXgR94DylXE), new CSharpArgumentInfo[4]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsOut, null)
					}));
				}
				return (dynamic)((System.Delegate)(object)_G_o__125.R5GdQcN6Hi.Target).DynamicInvoke(_G_o__125.R5GdQcN6Hi, typeof(kyVxiEuxDXgR94DylXE), (object)selection, P_3, P_4);
			}
			if (_G_o__125.YnvdrUZ7MP == null)
			{
				_G_o__125.YnvdrUZ7MP = CallSite<object>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "TryInsertRowsBelow", null, typeof(kyVxiEuxDXgR94DylXE), new CSharpArgumentInfo[4]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsOut, null)
				}));
			}
			return (dynamic)((System.Delegate)(object)_G_o__125.YnvdrUZ7MP.Target).DynamicInvoke(_G_o__125.YnvdrUZ7MP, typeof(kyVxiEuxDXgR94DylXE), (object)selection, P_3, P_4);
		}
		catch (Exception ex)
		{
			P_4 = ex.GetType().Name + ": " + ex.Message;
			return false;
		}
	}

	private static bool TryInsertRowsBelow(dynamic selection, int count, out string failureReason)
	{
		failureReason = string.Empty;
		try
		{
			if (_G_o__126.KfAd3MVCte == null)
			{
				_G_o__126.KfAd3MVCte = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertRowsBelow", null, typeof(kyVxiEuxDXgR94DylXE), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			_G_o__126.KfAd3MVCte.Target(_G_o__126.KfAd3MVCte, (object)selection, count);
			return true;
		}
		catch
		{
		}
		try
		{
			for (int i = 0; i < count; i++)
			{
				if (_G_o__126.Nx0dUcI0Fd == null)
				{
					_G_o__126.Nx0dUcI0Fd = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertRowsBelow", null, typeof(kyVxiEuxDXgR94DylXE), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				_G_o__126.Nx0dUcI0Fd.Target(_G_o__126.Nx0dUcI0Fd, (object)selection);
			}
			return true;
		}
		catch (Exception ex)
		{
			failureReason = ex.GetType().Name + ": " + ex.Message;
			return false;
		}
	}

	private static bool TryInsertRowsAbove(dynamic selection, int count, out string failureReason)
	{
		failureReason = string.Empty;
		try
		{
			if (_G_o__127.b9pdKn5QbP == null)
			{
				_G_o__127.b9pdKn5QbP = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertRowsAbove", null, typeof(kyVxiEuxDXgR94DylXE), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			_G_o__127.b9pdKn5QbP.Target(_G_o__127.b9pdKn5QbP, (object)selection, count);
			return true;
		}
		catch
		{
		}
		try
		{
			for (int i = 0; i < count; i++)
			{
				if (_G_o__127.p2TdEhwotK == null)
				{
					_G_o__127.p2TdEhwotK = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertRowsAbove", null, typeof(kyVxiEuxDXgR94DylXE), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				_G_o__127.p2TdEhwotK.Target(_G_o__127.p2TdEhwotK, (object)selection);
			}
			return true;
		}
		catch (Exception ex)
		{
			failureReason = ex.GetType().Name + ": " + ex.Message;
			return false;
		}
	}

	private static bool DoUTvWGE2o(Table P_0, int P_1, out Cell P_2)
	{
		P_2 = null;
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		List<Tuple<int, Cell>> list = new List<Tuple<int, Cell>>();
		try
		{
			foreach (Cell cell in P_0.Range.Cells)
			{
				if (LAxgB3C8QE(cell, out var num, out var item) && num == P_1)
				{
					list.Add(Tuple.Create(item, cell));
				}
			}
		}
		catch
		{
		}
		using (IEnumerator<Tuple<int, Cell>> enumerator2 = list.OrderBy((Tuple<int, Cell> tuple) => tuple.Item1).GetEnumerator())
		{
			if (enumerator2.MoveNext())
			{
				Tuple<int, Cell> current = enumerator2.Current;
				P_2 = current.Item2;
				return true;
			}
		}
		HbPTWYrAup(P_0, out var _, out var val);
		val = Math.Max(1, val);
		for (int num3 = 1; num3 <= val; num3++)
		{
			try
			{
				P_2 = P_0.Cell(P_1, num3);
				return true;
			}
			catch
			{
			}
		}
		return false;
	}

	private static void HbPTWYrAup(Table P_0, out int P_1, out int P_2)
	{
		_G_c__DisplayClass129_0 CS_8_locals_5 = new _G_c__DisplayClass129_0();
		CS_8_locals_5.X4DA9OZanO = P_0;
		P_1 = 0;
		P_2 = 0;
		if (CS_8_locals_5.X4DA9OZanO == null)
		{
			return;
		}
		try
		{
			foreach (Cell cell in CS_8_locals_5.X4DA9OZanO.Range.Cells)
			{
				if (LAxgB3C8QE(cell, out var val, out var val2))
				{
					P_1 = Math.Max(P_1, val);
					P_2 = Math.Max(P_2, val2);
				}
			}
		}
		catch
		{
		}
		if (P_1 <= 0)
		{
			P_1 = Ex5TMxi7X1(() => CS_8_locals_5.X4DA9OZanO.Rows.Count, 0);
		}
		if (P_2 <= 0)
		{
			P_2 = Ex5TMxi7X1(() => CS_8_locals_5.X4DA9OZanO.Columns.Count, 0);
		}
	}

	private static string BlET0SQkk3(Table P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return string.Empty;
		}
		List<Tuple<int, string>> list = new List<Tuple<int, string>>();
		try
		{
			foreach (Cell cell in P_0.Range.Cells)
			{
				if (LAxgB3C8QE(cell, out var num, out var item) && num == P_1)
				{
					string text = Pfn84MVBvM(n3PgDM4geQ(cell));
					if (!string.IsNullOrWhiteSpace(text))
					{
						list.Add(Tuple.Create(item, text));
					}
				}
			}
		}
		catch
		{
		}
		return rYN8Y355we(string.Join(" | ", from tuple in list
			orderby tuple.Item1
			select tuple.Item2), Math.Max(80, P_2));
	}

	private static rU18qH9owXvBsPZ0iiU XIPTkGpqwW(string P_0, out List<OGfXaqipg6f7TvJ8dbc> P_1)
	{
		P_1 = null;
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("cellsJson must not be empty.", "invalid_arguments");
		}
		try
		{
			P_1 = JsonConvert.DeserializeObject<List<OGfXaqipg6f7TvJ8dbc>>(P_0);
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("cellsJson 不是有效的 JSON 数组。", "invalid_arguments", new
			{
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		if (P_1 == null || P_1.Count == 0)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("cellsJson 至少需要包含一个模型单元格填数请求。", "invalid_arguments");
		}
		if (P_1.Count > 500)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("单次模型填表最多支持 500 个单元格。", "invalid_arguments", new
			{
				count = P_1.Count,
				max = 500
			});
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			OGfXaqipg6f7TvJ8dbc oGfXaqipg6f7TvJ8dbc = P_1[i];
			if (oGfXaqipg6f7TvJ8dbc == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("cellsJson 包含空请求。", "invalid_arguments", new
				{
					requestIndex = i + 1
				});
			}
			if (oGfXaqipg6f7TvJ8dbc.LocalTableIndex <= 0 && oGfXaqipg6f7TvJ8dbc.TableIndex > 0)
			{
				oGfXaqipg6f7TvJ8dbc.LocalTableIndex = oGfXaqipg6f7TvJ8dbc.TableIndex;
			}
			if (oGfXaqipg6f7TvJ8dbc.RowIndex < 1 || oGfXaqipg6f7TvJ8dbc.ColumnIndex < 1 || oGfXaqipg6f7TvJ8dbc.LocalTableIndex < 1)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("localTableIndex、rowIndex、columnIndex 必须都是 1-based 正整数。", "invalid_arguments", new
				{
					requestIndex = i + 1,
					LocalTableIndex = oGfXaqipg6f7TvJ8dbc.LocalTableIndex,
					RowIndex = oGfXaqipg6f7TvJ8dbc.RowIndex,
					ColumnIndex = oGfXaqipg6f7TvJ8dbc.ColumnIndex
				});
			}
			if (oGfXaqipg6f7TvJ8dbc.Text == null)
			{
				oGfXaqipg6f7TvJ8dbc.Text = oGfXaqipg6f7TvJ8dbc.NewText ?? string.Empty;
			}
			else
			{
				oGfXaqipg6f7TvJ8dbc.Text = oGfXaqipg6f7TvJ8dbc.Text ?? string.Empty;
			}
		}
		return null;
	}

	private static rU18qH9owXvBsPZ0iiU yC3TxlssVj(Range P_0, List<OGfXaqipg6f7TvJ8dbc> P_1, out List<ICsQGCih5R8sKlcw64k> P_2)
	{
		_G_c__DisplayClass132_0 CS_8_locals_9 = new _G_c__DisplayClass132_0();
		CS_8_locals_9.TNqAud7svs = P_0;
		P_2 = new List<ICsQGCih5R8sKlcw64k>();
		if (CS_8_locals_9.TNqAud7svs == null)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("引用 Range 不可用。", "invalid_arguments");
		}
		int num = Y1x8gkTvcF(() => CS_8_locals_9.TNqAud7svs.Tables.Count);
		Dictionary<int, Table> dictionary = new Dictionary<int, Table>();
		Dictionary<int, Dictionary<string, Cell>> dictionary2 = new Dictionary<int, Dictionary<string, Cell>>();
		Dictionary<int, int> dictionary3 = new Dictionary<int, int>();
		for (int num2 = 0; num2 < P_1.Count; num2++)
		{
			_G_c__DisplayClass132_1 CS_8_locals_11 = new _G_c__DisplayClass132_1();
			OGfXaqipg6f7TvJ8dbc oGfXaqipg6f7TvJ8dbc = P_1[num2];
			ICsQGCih5R8sKlcw64k csQGCih5R8sKlcw64k = new ICsQGCih5R8sKlcw64k
			{
				RequestIndex = num2 + 1,
				LocalTableIndex = oGfXaqipg6f7TvJ8dbc.LocalTableIndex,
				RowIndex = oGfXaqipg6f7TvJ8dbc.RowIndex,
				ColumnIndex = oGfXaqipg6f7TvJ8dbc.ColumnIndex,
				NewText = (oGfXaqipg6f7TvJ8dbc.Text ?? string.Empty),
				ExpectedOldText = oGfXaqipg6f7TvJ8dbc.ExpectedOldText,
				IsHeader = oGfXaqipg6f7TvJ8dbc.IsHeader
			};
			P_2.Add(csQGCih5R8sKlcw64k);
			if (oGfXaqipg6f7TvJ8dbc.LocalTableIndex < 1 || oGfXaqipg6f7TvJ8dbc.LocalTableIndex > num)
			{
				lFIgR5VTrF(csQGCih5R8sKlcw64k, "local_table_index_out_of_range", "localTableIndex 超出引用选区内表格数量。");
				continue;
			}
			if (!dictionary.TryGetValue(oGfXaqipg6f7TvJ8dbc.LocalTableIndex, out var value))
			{
				try
				{
					value = CS_8_locals_9.TNqAud7svs.Tables[oGfXaqipg6f7TvJ8dbc.LocalTableIndex];
					dictionary[oGfXaqipg6f7TvJ8dbc.LocalTableIndex] = value;
				}
				catch (Exception ex)
				{
					lFIgR5VTrF(csQGCih5R8sKlcw64k, "table_unavailable", ex.Message);
					continue;
				}
			}
			if (!dictionary3.TryGetValue(oGfXaqipg6f7TvJ8dbc.LocalTableIndex, out var value2))
			{
				value2 = YGSggVPnQb(value);
				dictionary3[oGfXaqipg6f7TvJ8dbc.LocalTableIndex] = value2;
			}
			csQGCih5R8sKlcw64k.HeaderRowCount = value2;
			csQGCih5R8sKlcw64k.IsHeader = oGfXaqipg6f7TvJ8dbc.IsHeader || (value2 > 0 && oGfXaqipg6f7TvJ8dbc.RowIndex <= value2);
			if (!dictionary2.TryGetValue(oGfXaqipg6f7TvJ8dbc.LocalTableIndex, out var value3))
			{
				value3 = EeSgVa5ZwN(value);
				dictionary2[oGfXaqipg6f7TvJ8dbc.LocalTableIndex] = value3;
			}
			string key = O5fguuXJL8(oGfXaqipg6f7TvJ8dbc.RowIndex, oGfXaqipg6f7TvJ8dbc.ColumnIndex);
			if (!value3.TryGetValue(key, out CS_8_locals_11.bAiAg2Qtct))
			{
				lFIgR5VTrF(csQGCih5R8sKlcw64k, "model_cell_unavailable", "目标坐标不是 Word 真实单元格起点，可能是合并区域内部坐标。请使用 read_word_tables_in_range 返回的 origin/fillableCells 坐标。");
				continue;
			}
			csQGCih5R8sKlcw64k.Cell = CS_8_locals_11.bAiAg2Qtct;
			csQGCih5R8sKlcw64k.RangeStart = Ex5TMxi7X1(() => CS_8_locals_11.bAiAg2Qtct.Range.Start, 0);
			csQGCih5R8sKlcw64k.RangeEnd = Ex5TMxi7X1(() => CS_8_locals_11.bAiAg2Qtct.Range.End, 0);
			csQGCih5R8sKlcw64k.Page = Y878QfFgDa(CS_8_locals_11.bAiAg2Qtct.Range);
			csQGCih5R8sKlcw64k.OldText = Pfn84MVBvM(n3PgDM4geQ(CS_8_locals_11.bAiAg2Qtct));
			if (oGfXaqipg6f7TvJ8dbc.ExpectedOldText != null && !string.Equals(Pfn84MVBvM(oGfXaqipg6f7TvJ8dbc.ExpectedOldText), csQGCih5R8sKlcw64k.OldText, StringComparison.Ordinal))
			{
				lFIgR5VTrF(csQGCih5R8sKlcw64k, "old_text_mismatch", "目标单元格当前旧值与 expectedOldText 不一致。请重新读取表格模型后再写入。");
			}
			else
			{
				csQGCih5R8sKlcw64k.Writable = true;
			}
		}
		return null;
	}

	private static object iLJTdpgWxW(Document P_0, int P_1, int P_2, bool P_3, bool P_4, string P_5, List<ICsQGCih5R8sKlcw64k> P_6)
	{
		int num = P_6.Count((ICsQGCih5R8sKlcw64k change) => change.Writable);
		int errorCount = P_6.Count - num;
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			rangeStart = P_1,
			rangeEnd = P_2,
			coordinateSystem = "localTableIndex,rowIndex,columnIndex are 1-based within the referenced Word range.",
			totalRequests = P_6.Count,
			expectedChangeCount = num,
			writableCount = num,
			errorCount = errorCount,
			allowHeaderEdit = P_3,
			useTrackChanges = P_4,
			previewToken = P_5,
			items = P_6.Select(ogqTzQBuMn).ToList()
		};
	}

	private static object ogqTzQBuMn(ICsQGCih5R8sKlcw64k P_0)
	{
		return new
		{
			requestIndex = P_0.RequestIndex,
			localTableIndex = P_0.LocalTableIndex,
			rowIndex = P_0.RowIndex,
			columnIndex = P_0.ColumnIndex,
			headerRowCount = P_0.HeaderRowCount,
			isHeader = P_0.IsHeader,
			page = ((P_0.Page == 0) ? ((int?)null) : new int?(P_0.Page)),
			rangeStart = ((P_0.RangeStart == 0) ? ((int?)null) : new int?(P_0.RangeStart)),
			rangeEnd = ((P_0.RangeEnd == 0) ? ((int?)null) : new int?(P_0.RangeEnd)),
			oldText = (P_0.OldText ?? string.Empty),
			expectedOldText = P_0.ExpectedOldText,
			newText = (P_0.NewText ?? string.Empty),
			writable = P_0.Writable,
			errorCode = P_0.ErrorCode,
			message = P_0.ErrorMessage
		};
	}

	private static void lFIgR5VTrF(ICsQGCih5R8sKlcw64k P_0, string P_1, string P_2)
	{
		P_0.Writable = false;
		P_0.ErrorCode = P_1;
		P_0.ErrorMessage = P_2;
	}

	private static Dictionary<string, Cell> EeSgVa5ZwN(Table P_0)
	{
		Dictionary<string, Cell> dictionary = new Dictionary<string, Cell>(StringComparer.Ordinal);
		if (P_0 == null)
		{
			return dictionary;
		}
		try
		{
			foreach (Cell cell in P_0.Range.Cells)
			{
				if (LAxgB3C8QE(cell, out var num, out var num2))
				{
					string key = O5fguuXJL8(num, num2);
					if (!dictionary.ContainsKey(key))
					{
						dictionary[key] = cell;
					}
				}
			}
		}
		catch
		{
		}
		return dictionary;
	}

	private static bool LAxgB3C8QE(Cell P_0, out int P_1, out int P_2)
	{
		P_1 = 0;
		P_2 = 0;
		try
		{
			P_1 = P_0.RowIndex;
			P_2 = P_0.ColumnIndex;
			return P_1 > 0 && P_2 > 0;
		}
		catch
		{
			return false;
		}
	}

	private static string EW0g9hbK9x(Document P_0, int P_1, int P_2, List<ICsQGCih5R8sKlcw64k> P_3)
	{
		_G_c__DisplayClass138_0 CS_8_locals_2 = new _G_c__DisplayClass138_0();
		CS_8_locals_2.doc = P_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(iOW8KTFwda(() => CS_8_locals_2.doc.FullName)).Append('|').Append(P_1.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_2.ToString(CultureInfo.InvariantCulture));
		foreach (ICsQGCih5R8sKlcw64k item in P_3.OrderBy((ICsQGCih5R8sKlcw64k c) => c.RequestIndex))
		{
			stringBuilder.Append('\n').Append(item.RequestIndex.ToString(CultureInfo.InvariantCulture)).Append('|')
				.Append(item.LocalTableIndex.ToString(CultureInfo.InvariantCulture))
				.Append('|')
				.Append(item.RowIndex.ToString(CultureInfo.InvariantCulture))
				.Append('|')
				.Append(item.ColumnIndex.ToString(CultureInfo.InvariantCulture))
				.Append('|')
				.Append(item.RangeStart.ToString(CultureInfo.InvariantCulture))
				.Append('|')
				.Append(item.RangeEnd.ToString(CultureInfo.InvariantCulture))
				.Append('|')
				.Append(item.IsHeader ? "B" : "H")
				.Append('|')
				.Append(item.Writable ? "E" : "W")
				.Append('|')
				.Append(item.ErrorCode ?? string.Empty)
				.Append('|')
				.Append(item.OldText ?? string.Empty)
				.Append('|')
				.Append(item.NewText ?? string.Empty);
		}
		using SHA256 sHA = SHA256.Create();
		byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
		return Convert.ToBase64String(sHA.ComputeHash(bytes)).TrimEnd('=').Replace('+', '-')
			.Replace('/', '_');
	}

	private static bool mx2g6RGYxJ(string P_0, string P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		byte[] bytes = Encoding.UTF8.GetBytes(P_0);
		byte[] bytes2 = Encoding.UTF8.GetBytes(P_1);
		int num = bytes.Length ^ bytes2.Length;
		int num2 = Math.Max(bytes.Length, bytes2.Length);
		for (int i = 0; i < num2; i++)
		{
			byte b = (byte)((i < bytes.Length) ? bytes[i] : 0);
			byte b2 = (byte)((i < bytes2.Length) ? bytes2[i] : 0);
			num |= b ^ b2;
		}
		return num == 0;
	}

	private static string O5fguuXJL8(int P_0, int P_1)
	{
		return P_0.ToString(CultureInfo.InvariantCulture) + ":" + P_1.ToString(CultureInfo.InvariantCulture);
	}

	private static string n3PgDM4geQ(Cell P_0)
	{
		_G_c__DisplayClass141_0 CS_8_locals_3 = new _G_c__DisplayClass141_0();
		CS_8_locals_3.sXuAUW1XT9 = P_0;
		try
		{
			Range duplicate = CS_8_locals_3.sXuAUW1XT9.Range.Duplicate;
			duplicate.End = Math.Max(duplicate.Start, duplicate.End - 1);
			return duplicate.Text ?? string.Empty;
		}
		catch
		{
			return iOW8KTFwda(() => CS_8_locals_3.sXuAUW1XT9.Range.Text);
		}
	}

	private static bool bIRgTubXiW(Cell P_0, string P_1, out bool P_2, out string P_3)
	{
		P_2 = false;
		P_3 = string.Empty;
		try
		{
			string text = P_1 ?? string.Empty;
			Range duplicate = P_0.Range.Duplicate;
			duplicate.End = Math.Max(duplicate.Start, duplicate.End - 1);
			if (string.Equals(Pfn84MVBvM(duplicate.Text), Pfn84MVBvM(text), StringComparison.Ordinal))
			{
				return true;
			}
			duplicate.Text = text;
			P_2 = true;
			return true;
		}
		catch (Exception ex)
		{
			P_3 = ex.GetType().Name + ": " + ex.Message;
			return false;
		}
	}

	private static int YGSggVPnQb(Table P_0)
	{
		_G_c__DisplayClass143_0 CS_8_locals_2 = new _G_c__DisplayClass143_0();
		CS_8_locals_2.vk1AEfduQP = P_0;
		try
		{
			string text = iOW8KTFwda(() => CS_8_locals_2.vk1AEfduQP.Range.WordOpenXML);
			if (string.IsNullOrWhiteSpace(text))
			{
				return 1;
			}
			XDocument xDocument = XDocument.Parse(text);
			XElement xElement = (MRrgIiUJxs(xDocument, "/word/document.xml") ?? xDocument).Descendants(kCy8tdAKvt + "tbl").FirstOrDefault();
			if (xElement == null)
			{
				return 1;
			}
			int num = 0;
			List<JUgiWyHGaS7Mfjy1lqW> list = new List<JUgiWyHGaS7Mfjy1lqW>();
			Dictionary<int, JUgiWyHGaS7Mfjy1lqW> dictionary = new Dictionary<int, JUgiWyHGaS7Mfjy1lqW>();
			foreach (XElement item in xElement.Elements(kCy8tdAKvt + "tr"))
			{
				num++;
				int num2 = 1;
				HashSet<JUgiWyHGaS7Mfjy1lqW> hashSet = new HashSet<JUgiWyHGaS7Mfjy1lqW>();
				foreach (XElement item2 in item.Elements(kCy8tdAKvt + "tc"))
				{
					int num3 = OI5gi9KVVe(item2);
					string text2 = pDWgHCxJ4Z(item2);
					bool flag = text2 != null;
					bool flag2 = flag && !string.Equals(text2, "restart", StringComparison.OrdinalIgnoreCase);
					if (flag2 && dictionary.TryGetValue(num2, out var value))
					{
						if (!hashSet.Contains(value))
						{
							value.RowSpan++;
							hashSet.Add(value);
						}
					}
					else
					{
						value = new JUgiWyHGaS7Mfjy1lqW
						{
							RowIndex = num,
							ColumnIndex = num2,
							RowSpan = 1,
							ColumnSpan = num3
						};
						list.Add(value);
					}
					for (int num4 = 0; num4 < num3; num4++)
					{
						if (flag && !flag2 && value != null)
						{
							dictionary[num2 + num4] = value;
						}
						else if (!flag)
						{
							dictionary.Remove(num2 + num4);
						}
					}
					num2 += num3;
				}
			}
			List<JaeGYLH5MusMIC1Og5S> list2 = (from cell in list
				where cell.RowSpan > 1 || cell.ColumnSpan > 1
				select new JaeGYLH5MusMIC1Og5S
				{
					StartRow = cell.RowIndex,
					StartColumn = cell.ColumnIndex,
					EndRow = cell.RowIndex + cell.RowSpan - 1,
					EndColumn = cell.ColumnIndex + cell.ColumnSpan - 1
				}).ToList();
			return hoAg8EFU1J(num, list2);
		}
		catch
		{
			return 1;
		}
	}

	private static int hoAg8EFU1J(int P_0, List<JaeGYLH5MusMIC1Og5S> P_1)
	{
		if (P_0 <= 0)
		{
			return 0;
		}
		if (P_1 == null || P_1.Count == 0)
		{
			return 1;
		}
		int num = 0;
		_G_c__DisplayClass144_0 CS_8_locals_6 = new _G_c__DisplayClass144_0();
		CS_8_locals_6.R9eA4ukJ3b = 1;
		while (CS_8_locals_6.R9eA4ukJ3b <= P_0 && P_1.Any((JaeGYLH5MusMIC1Og5S merge) => merge.StartRow <= CS_8_locals_6.R9eA4ukJ3b && merge.EndRow >= CS_8_locals_6.R9eA4ukJ3b))
		{
			num = CS_8_locals_6.R9eA4ukJ3b;
			CS_8_locals_6.R9eA4ukJ3b++;
		}
		bool flag;
		do
		{
			flag = false;
			foreach (JaeGYLH5MusMIC1Og5S item in P_1)
			{
				if (item.StartRow <= num && item.EndRow > num)
				{
					num = item.EndRow;
					flag = true;
				}
			}
		}
		while (flag);
		return Math.Min(Math.Max(1, num), P_0);
	}

	private static XDocument MRrgIiUJxs(XDocument P_0, string P_1)
	{
		_G_c__DisplayClass145_0 CS_8_locals_3 = new _G_c__DisplayClass145_0();
		CS_8_locals_3.DojAYMESMP = P_1;
		if (P_0 == null || P_0.Root == null)
		{
			return null;
		}
		_ = P_0.Root.Attribute(hLV8L0pG1W + "name")?.Value;
		if (P_0.Root.Name == kCy8tdAKvt + "document" && string.Equals(CS_8_locals_3.DojAYMESMP, "/word/document.xml", StringComparison.OrdinalIgnoreCase))
		{
			return P_0;
		}
		XElement xElement = P_0.Root.Elements(hLV8L0pG1W + "part").FirstOrDefault((XElement p) => string.Equals(p.Attribute(hLV8L0pG1W + "xmlData")?.Value, CS_8_locals_3.DojAYMESMP, StringComparison.OrdinalIgnoreCase))?.Element(hLV8L0pG1W + "startParagraphIndex is out of range.")?.Elements().FirstOrDefault();
		if (xElement == null)
		{
			return null;
		}
		return new XDocument(new XElement(xElement));
	}

	private static int OI5gi9KVVe(XElement P_0)
	{
		if (!int.TryParse(P_0.Element(kCy8tdAKvt + "tcPr")?.Element(kCy8tdAKvt + "gridSpan")?.Attribute(kCy8tdAKvt + "val")?.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) || result < 1)
		{
			return 1;
		}
		return result;
	}

	private static string pDWgHCxJ4Z(XElement P_0)
	{
		XElement xElement = P_0.Element(kCy8tdAKvt + "tcPr")?.Element(kCy8tdAKvt + "vMerge");
		if (xElement == null)
		{
			return null;
		}
		string text = xElement.Attribute(kCy8tdAKvt + "val")?.Value;
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return "continue";
	}

	private static rU18qH9owXvBsPZ0iiU dX7gQtJOIx(Microsoft.Office.Interop.Word.Application P_0, Document P_1, Range P_2, string P_3)
	{
		_G_c__DisplayClass148_0 CS_8_locals_16 = new _G_c__DisplayClass148_0();
		CS_8_locals_16.doc = P_1;
		CS_8_locals_16.tI1AfO9S88 = P_2;
		CS_8_locals_16.w8yAMEApiM = P_3;
		rU18qH9owXvBsPZ0iiU rU18qH9owXvBsPZ0iiU2 = Q7Sg1pThfx(P_0, CS_8_locals_16.doc, CS_8_locals_16.tI1AfO9S88);
		if (rU18qH9owXvBsPZ0iiU2 != null)
		{
			return rU18qH9owXvBsPZ0iiU2;
		}
		return oBKTTgZY41(P_0, "AI 修订替换", delegate
		{
			bool trackRevisions = CS_8_locals_16.doc.TrackRevisions;
			try
			{
				CS_8_locals_16.doc.TrackRevisions = true;
				string text = Pfn84MVBvM(CS_8_locals_16.tI1AfO9S88.Text);
				int start = CS_8_locals_16.tI1AfO9S88.Start;
				CS_8_locals_16.tI1AfO9S88.Text = CS_8_locals_16.w8yAMEApiM ?? string.Empty;
				return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("invalid_arguments", new
				{
					document = CS_8_locals_16.doc.Name,
					documentFullName = CS_8_locals_16.doc.FullName,
					page = Y878QfFgDa(CS_8_locals_16.tI1AfO9S88),
					rangeStart = start,
					oldCharacters = text.Length,
					newCharacters = (CS_8_locals_16.w8yAMEApiM ?? string.Empty).Length,
					oldPreview = rYN8Y355we(text, 240)
				});
			}
			finally
			{
				CS_8_locals_16.doc.TrackRevisions = trackRevisions;
			}
		});
	}

	private static rU18qH9owXvBsPZ0iiU Q7Sg1pThfx(Microsoft.Office.Interop.Word.Application P_0, Document P_1, Range P_2)
	{
		if (P_0 == null || P_1 == null)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("Word 应用或目标文档不可用。", "word_not_ready");
		}
		try
		{
			P_0.Activate();
		}
		catch
		{
		}
		try
		{
			P_1.Activate();
		}
		catch
		{
		}
		try
		{
			P_0.ActiveWindow?.Activate();
		}
		catch
		{
		}
		try
		{
			if (P_0.ActiveWindow != null && P_0.ActiveWindow.View != null)
			{
				P_0.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
			}
		}
		catch
		{
		}
		try
		{
			Range range = P_2?.Duplicate;
			if (range == null || !XMVgr0DwLb(range))
			{
				object Start = P_1.Content.Start;
				object End = Math.Min(P_1.Content.End, P_1.Content.Start + 1);
				range = P_1.Range(ref Start, ref End);
			}
			int num = Math.Max(P_1.Content.Start, Math.Min(range.Start, P_1.Content.End));
			int num2 = Math.Max(num, Math.Min(range.End, P_1.Content.End));
			if (num2 <= num)
			{
				num2 = Math.Min(P_1.Content.End, num + 1);
			}
			range.SetRange(num, num2);
			range.Select();
			xfHg3PXS6T();
			if (!XMVgr0DwLb(uEGgJLYMWc(P_0)))
			{
				P_0.Selection.SetRange(num, num);
				xfHg3PXS6T();
			}
		}
		catch (Exception ex)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("无法将 Word 焦点切回正文区域。请点击正文后重试同一工具，不要改用无修订写入。", "main_document_focus_failed", new
			{
				exception = ex.GetType().Name,
				message = ex.Message,
				retrySameTool = true
			});
		}
		if (!XMVgr0DwLb(uEGgJLYMWc(P_0)))
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前 Word 焦点仍不在正文区域，可能仍选中了批注或批注窗格。请点击正文后重试同一工具，不要改用无修订写入。", "main_document_focus_failed", new
			{
				retrySameTool = true
			});
		}
		return null;
	}

	private static bool XMVgr0DwLb(Range P_0)
	{
		try
		{
			return P_0 != null && P_0.StoryType == WdStoryType.wdMainTextStory;
		}
		catch
		{
			return false;
		}
	}

	private static Range uEGgJLYMWc(Microsoft.Office.Interop.Word.Application P_0)
	{
		try
		{
			return P_0?.Selection?.Range;
		}
		catch
		{
			return null;
		}
	}

	private static void xfHg3PXS6T()
	{
		try
		{
			System.Windows.Forms.Application.DoEvents();
		}
		catch
		{
		}
	}

	private static Paragraph a2QgUnQhBr(Document P_0, string P_1, int P_2, int P_3, string P_4)
	{
		if (P_2 > 0)
		{
			if (P_2 > P_0.Paragraphs.Count)
			{
				return null;
			}
			return P_0.Paragraphs[P_2];
		}
		string text = (P_4 ?? "contains").Trim().ToLowerInvariant();
		for (int i = 1; i <= P_0.Paragraphs.Count; i++)
		{
			Paragraph paragraph = P_0.Paragraphs[i];
			int num = fSO88F0gne(paragraph);
			if (num >= 1 && num <= 9 && (P_3 <= 0 || num == P_3) && OYJgKddkFp(Pfn84MVBvM(paragraph.Range.Text), P_1, text))
			{
				return paragraph;
			}
		}
		return null;
	}

	private static bool OYJgKddkFp(string P_0, string P_1, string P_2)
	{
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return true;
		}
		P_0 = (P_0 ?? string.Empty).Trim();
		P_1 = P_1.Trim();
		if (!(P_2 == "equals"))
		{
			if (P_2 == "startswith")
			{
				return P_0.StartsWith(P_1, StringComparison.CurrentCultureIgnoreCase);
			}
			return P_0.IndexOf(P_1, StringComparison.CurrentCultureIgnoreCase) >= 0;
		}
		return string.Equals(P_0, P_1, StringComparison.CurrentCultureIgnoreCase);
	}

	private static object RTIgEY6EEf(Selection P_0, bool P_1, int P_2)
	{
		if (P_0 == null || P_0.Range == null)
		{
			return null;
		}
		string text = Pfn84MVBvM(P_0.Range.Text);
		bool flag = text.Length > P_2;
		return new
		{
			page = (P_1 ? new int?(Y878QfFgDa(P_0.Range)) : ((int?)null)),
			rangeStart = P_0.Range.Start,
			rangeEnd = P_0.Range.End,
			characters = text.Length,
			truncated = flag,
			excerpt = (flag ? text.Substring(0, P_2) : text)
		};
	}

	private static object C71g2s9eOp(Paragraph P_0, int P_1, int P_2)
	{
		string text = Pfn84MVBvM(P_0.Range.Text);
		bool flag = text.Length > P_2;
		int num = cjC8ImVBAy(fSO88F0gne(P_0));
		bool flag2 = num >= 1 && num <= 9;
		return new
		{
			paragraphIndex = P_1,
			isHeading = flag2,
			outlineKind = (flag2 ? "body" : "heading"),
			outlineLevel = num,
			rawOutlineLevel = num,
			rangeStart = P_0.Range.Start,
			rangeEnd = P_0.Range.End,
			characters = text.Length,
			truncated = flag,
			text = (flag ? text.Substring(0, P_2) : text)
		};
	}

	private static object KFSg410uKL(Paragraph P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass157_0 CS_8_locals_9 = new _G_c__DisplayClass157_0();
		CS_8_locals_9.XbCACwggdo = P_0;
		string text = Pfn84MVBvM(CS_8_locals_9.XbCACwggdo.Range.Text);
		bool flag = text.Length > P_2;
		int num = cjC8ImVBAy(fSO88F0gne(CS_8_locals_9.XbCACwggdo));
		bool flag2 = num >= 1 && num <= 9;
		string styleName = kBH8HcK06n(CS_8_locals_9.XbCACwggdo);
		return new
		{
			document = iOW8KTFwda(() => CS_8_locals_9.XbCACwggdo.Range.Document.Name),
			documentFullName = iOW8KTFwda(() => CS_8_locals_9.XbCACwggdo.Range.Document.FullName),
			page = Y878QfFgDa(CS_8_locals_9.XbCACwggdo.Range),
			paragraphIndex = P_1,
			isHeading = flag2,
			outlineKind = (flag2 ? "body" : "heading"),
			outlineLevel = num,
			rawOutlineLevel = num,
			styleName = styleName,
			rangeStart = CS_8_locals_9.XbCACwggdo.Range.Start,
			rangeEnd = CS_8_locals_9.XbCACwggdo.Range.End,
			characters = text.Length,
			truncated = flag,
			text = (flag ? text.Substring(0, P_2) : text)
		};
	}

	private static object WhFgjeRETB(Table P_0, int P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass158_0 CS_8_locals_28 = new _G_c__DisplayClass158_0();
		CS_8_locals_28.F3bAXyBVcX = P_0;
		int num = PJm8rI8jwn(CS_8_locals_28.F3bAXyBVcX);
		int num2 = ldc8JB4JIl(CS_8_locals_28.F3bAXyBVcX);
		string text = Pfn84MVBvM(CS_8_locals_28.F3bAXyBVcX.Range.Text);
		List<i1s1MAQmjhG3eDI6qOg> list = knfgZS9hyK(CS_8_locals_28.F3bAXyBVcX);
		List<string> list2 = new List<string>();
		int num3 = Math.Min(num, P_2);
		int num4 = Math.Min(num2, P_3);
		int num5 = 0;
		bool hasMergedOrUnavailableCells = num <= 0 || num2 <= 0;
		if (num <= 0 || num2 <= 0)
		{
			return new
			{
				document = iOW8KTFwda(() => CS_8_locals_28.F3bAXyBVcX.Range.Document.Name),
				documentFullName = iOW8KTFwda(() => CS_8_locals_28.F3bAXyBVcX.Range.Document.FullName),
				index = P_1,
				altTextTitle = TkI8jwiSoi(iOW8KTFwda(() => CS_8_locals_28.F3bAXyBVcX.Title)),
				altTextDescription = TkI8jwiSoi(iOW8KTFwda(() => CS_8_locals_28.F3bAXyBVcX.Descr)),
				rows = num,
				columns = num2,
				returnedRows = 0,
				returnedColumns = 0,
				page = Y878QfFgDa(CS_8_locals_28.F3bAXyBVcX.Range),
				paragraphIndex = EFt8ufX87I(CS_8_locals_28.F3bAXyBVcX.Range.Document, CS_8_locals_28.F3bAXyBVcX.Range.Start),
				rangeStart = CS_8_locals_28.F3bAXyBVcX.Range.Start,
				rangeEnd = CS_8_locals_28.F3bAXyBVcX.Range.End,
				previousParagraph = etKgYkrBNM(CS_8_locals_28.F3bAXyBVcX, -1),
				nextParagraph = etKgYkrBNM(CS_8_locals_28.F3bAXyBVcX, 1),
				truncated = (text.Length > 3000),
				rowsData = new object[0],
				cellsFlat = DTdgfbqppO(list),
				markdown = string.Empty,
				rawText = rYN8Y355we(text, 3000),
				hasMergedOrUnavailableCells = true,
				warnings = new string[1] { "The table has merged cells or mixed widths and could not be read by row/column coordinates." }
			};
		}
		List<List<string>> list3 = new List<List<string>>();
		for (int num6 = 1; num6 <= num3; num6++)
		{
			List<string> list4 = new List<string>();
			for (int num7 = 1; num7 <= num4; num7++)
			{
				if (num5 >= 2000)
				{
					list2.Add("Cell limit reached.");
					break;
				}
				try
				{
					string item = Pfn84MVBvM(CS_8_locals_28.F3bAXyBVcX.Cell(num6, num7).Range.Text);
					list4.Add(item);
					num5++;
				}
				catch
				{
					list4.Add("[merged/unavailable]");
					hasMergedOrUnavailableCells = true;
					list2.Add("Some merged cells could not be read by row/column coordinates.");
				}
			}
			list3.Add(list4);
		}
		bool flag = N9XgMAe5Dq(list3, list, num3, num4);
		if (flag)
		{
			list2.Add("Merged cells were expanded from table.Range.Cells where possible.");
		}
		List<object> rowsData = n0tgtWecy3(list3);
		string markdown = bQDgL0Qj6e(list3);
		return new
		{
			document = iOW8KTFwda(() => CS_8_locals_28.F3bAXyBVcX.Range.Document.Name),
			documentFullName = iOW8KTFwda(() => CS_8_locals_28.F3bAXyBVcX.Range.Document.FullName),
			index = P_1,
			altTextTitle = TkI8jwiSoi(iOW8KTFwda(() => CS_8_locals_28.F3bAXyBVcX.Title)),
			altTextDescription = TkI8jwiSoi(iOW8KTFwda(() => CS_8_locals_28.F3bAXyBVcX.Descr)),
			rows = num,
			columns = num2,
			returnedRows = num3,
			returnedColumns = num4,
			page = Y878QfFgDa(CS_8_locals_28.F3bAXyBVcX.Range),
			paragraphIndex = EFt8ufX87I(CS_8_locals_28.F3bAXyBVcX.Range.Document, CS_8_locals_28.F3bAXyBVcX.Range.Start),
			rangeStart = CS_8_locals_28.F3bAXyBVcX.Range.Start,
			rangeEnd = CS_8_locals_28.F3bAXyBVcX.Range.End,
			previousParagraph = etKgYkrBNM(CS_8_locals_28.F3bAXyBVcX, -1),
			nextParagraph = etKgYkrBNM(CS_8_locals_28.F3bAXyBVcX, 1),
			truncated = (num > num3 || num2 > num4 || num5 >= 2000),
			rowsData = rowsData,
			cellsFlat = DTdgfbqppO(list),
			markdown = markdown,
			rawText = rYN8Y355we(text, 3000),
			hasMergedOrUnavailableCells = hasMergedOrUnavailableCells,
			expandedMergedCells = flag,
			warnings = J6X8wOwgCa(list2)
		};
	}

	private static object etKgYkrBNM(Table P_0, int P_1)
	{
		try
		{
			_G_c__DisplayClass159_0 CS_8_locals_4 = new _G_c__DisplayClass159_0();
			CS_8_locals_4.doc = P_0.Range.Document;
			int num = Y1x8gkTvcF(() => CS_8_locals_4.doc.Paragraphs.Count);
			if (P_1 < 0)
			{
				for (int num2 = num; num2 >= 1; num2--)
				{
					Paragraph paragraph = CS_8_locals_4.doc.Paragraphs[num2];
					if (paragraph.Range.End <= P_0.Range.Start && !string.IsNullOrWhiteSpace(Pfn84MVBvM(paragraph.Range.Text)))
					{
						return KFSg410uKL(paragraph, num2, 500);
					}
				}
			}
			else
			{
				for (int num3 = 1; num3 <= num; num3++)
				{
					Paragraph paragraph2 = CS_8_locals_4.doc.Paragraphs[num3];
					if (paragraph2.Range.Start >= P_0.Range.End && !string.IsNullOrWhiteSpace(Pfn84MVBvM(paragraph2.Range.Text)))
					{
						return KFSg410uKL(paragraph2, num3, 500);
					}
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static List<i1s1MAQmjhG3eDI6qOg> knfgZS9hyK(Table P_0)
	{
		List<i1s1MAQmjhG3eDI6qOg> list = new List<i1s1MAQmjhG3eDI6qOg>();
		int num = 0;
		try
		{
			foreach (Cell cell in P_0.Range.Cells)
			{
				num++;
				if (num <= 2000)
				{
					list.Add(new i1s1MAQmjhG3eDI6qOg
					{
						CellIndex = num,
						RowIndex = bfl83TJXMI(cell),
						ColumnIndex = lJe8UuBPlV(cell),
						RowSpan = 1,
						ColumnSpan = 1,
						Page = Y878QfFgDa(cell.Range),
						RangeStart = cell.Range.Start,
						RangeEnd = cell.Range.End,
						Text = Pfn84MVBvM(cell.Range.Text)
					});
					continue;
				}
				break;
			}
		}
		catch
		{
		}
		return list;
	}

	private static List<object> DTdgfbqppO(List<i1s1MAQmjhG3eDI6qOg> P_0)
	{
		List<object> list = new List<object>();
		if (P_0 == null)
		{
			return list;
		}
		foreach (i1s1MAQmjhG3eDI6qOg item in P_0)
		{
			list.Add(new
			{
				cellIndex = item.CellIndex,
				rowIndex = item.RowIndex,
				columnIndex = item.ColumnIndex,
				rowSpan = item.RowSpan,
				columnSpan = item.ColumnSpan,
				page = item.Page,
				rangeStart = item.RangeStart,
				rangeEnd = item.RangeEnd,
				text = item.Text
			});
		}
		return list;
	}

	private static bool N9XgMAe5Dq(List<List<string>> P_0, List<i1s1MAQmjhG3eDI6qOg> P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 == null || P_1.Count == 0)
		{
			return false;
		}
		bool flag = false;
		List<i1s1MAQmjhG3eDI6qOg> list = new List<i1s1MAQmjhG3eDI6qOg>();
		foreach (i1s1MAQmjhG3eDI6qOg item in P_1)
		{
			if (item.RowIndex.HasValue && item.ColumnIndex.HasValue && item.RowIndex.Value >= 1 && item.RowIndex.Value <= P_2 && item.ColumnIndex.Value >= 1 && item.ColumnIndex.Value <= P_3)
			{
				list.Add(item);
				flag |= hB4gSKaYFF(P_0, item.RowIndex.Value, item.ColumnIndex.Value, item.Text);
			}
		}
		foreach (i1s1MAQmjhG3eDI6qOg item2 in list)
		{
			if (string.IsNullOrEmpty(item2.Text))
			{
				continue;
			}
			int value = item2.RowIndex.Value;
			int value2 = item2.ColumnIndex.Value;
			int num = P_3 + 1;
			foreach (i1s1MAQmjhG3eDI6qOg item3 in list)
			{
				if (item3 != item2 && item3.RowIndex == value && item3.ColumnIndex.HasValue && item3.ColumnIndex.Value > value2 && item3.ColumnIndex.Value < num)
				{
					num = item3.ColumnIndex.Value;
				}
			}
			int num2 = 1;
			for (int i = value2 + 1; i < num && i <= P_3; i++)
			{
				if (hB4gSKaYFF(P_0, value, i, item2.Text))
				{
					flag = true;
					num2 = Math.Max(num2, i - value2 + 1);
				}
			}
			item2.ColumnSpan = Math.Max(item2.ColumnSpan, num2);
			int num3 = 1;
			for (int j = value + 1; j <= P_2 && !yqMgbs8C9c(list, j, value2) && hB4gSKaYFF(P_0, j, value2, item2.Text); j++)
			{
				flag = true;
				num3 = Math.Max(num3, j - value + 1);
			}
			item2.RowSpan = Math.Max(item2.RowSpan, num3);
		}
		return flag;
	}

	private static bool yqMgbs8C9c(List<i1s1MAQmjhG3eDI6qOg> P_0, int P_1, int P_2)
	{
		foreach (i1s1MAQmjhG3eDI6qOg item in P_0)
		{
			if (item.RowIndex == P_1 && item.ColumnIndex == P_2)
			{
				return true;
			}
		}
		return false;
	}

	private static bool hB4gSKaYFF(List<List<string>> P_0, int P_1, int P_2, string P_3)
	{
		if (string.IsNullOrEmpty(P_3) || P_1 < 1 || P_2 < 1 || P_1 > P_0.Count)
		{
			return false;
		}
		List<string> list = P_0[P_1 - 1];
		if (P_2 > list.Count || !G3xgwymTG1(list[P_2 - 1]))
		{
			return false;
		}
		list[P_2 - 1] = P_3;
		return true;
	}

	private static bool G3xgwymTG1(string P_0)
	{
		return string.Equals(P_0, "[merged/unavailable]", StringComparison.Ordinal);
	}

	private static List<object> n0tgtWecy3(List<List<string>> P_0)
	{
		List<object> list = new List<object>();
		for (int i = 0; i < P_0.Count; i++)
		{
			list.Add(new
			{
				row = i + 1,
				cells = P_0[i]
			});
		}
		return list;
	}

	private static string bQDgL0Qj6e(List<List<string>> P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < P_0.Count; i++)
		{
			List<string> list = P_0[i];
			stringBuilder.Append("| ");
			stringBuilder.Append(string.Join(" | ", rX98SqsM2D(list)));
			stringBuilder.AppendLine(" |");
			if (i != 0)
			{
				continue;
			}
			stringBuilder.Append("| ");
			for (int j = 0; j < list.Count; j++)
			{
				if (j > 0)
				{
					stringBuilder.Append(" | ");
				}
				stringBuilder.Append("---");
			}
			stringBuilder.AppendLine(" |");
		}
		return stringBuilder.ToString().TrimEnd();
	}

	private static object WWcgsjc2XU(Document P_0, Range P_1, int P_2, string P_3)
	{
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			commentIndex = P_2,
			page = Y878QfFgDa(P_1),
			paragraphIndex = EFt8ufX87I(P_0, P_1.Start),
			rangeStart = P_1.Start,
			rangeEnd = P_1.End,
			targetPreview = rYN8Y355we(Pfn84MVBvM(P_1.Text), 240),
			comment = P_3.Trim()
		};
	}

	private static object qXYglKDlsW(Document P_0, Comment P_1, bool P_2, int P_3, int P_4)
	{
		_G_c__DisplayClass169_0 CS_8_locals_11 = new _G_c__DisplayClass169_0();
		CS_8_locals_11.GPkAA2kBUh = P_1;
		int num;
		bool flag;
		List<object> list = tmKgNwqeQC(P_0, CS_8_locals_11.GPkAA2kBUh, P_4, out num, out flag);
		Range range = QfAg7hyofH(CS_8_locals_11.GPkAA2kBUh) ?? Rt8gnHTE8S(CS_8_locals_11.GPkAA2kBUh);
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			["commentToken"] = qoRgqGAgBm(P_0, CS_8_locals_11.GPkAA2kBUh),
			["index"] = GQJgya6RkO(CS_8_locals_11.GPkAA2kBUh),
			["author"] = iOW8KTFwda(() => CS_8_locals_11.GPkAA2kBUh.Author),
			["date"] = MmigeqmiRt(CS_8_locals_11.GPkAA2kBUh),
			["done"] = Ex5TMxi7X1(() => CS_8_locals_11.GPkAA2kBUh.Done, ypQS6RTSiCdpSgKNQtr: false),
			["commentText"] = UNcg5o6WsG(CS_8_locals_11.GPkAA2kBUh),
			["replyCount"] = num,
			["repliesReturned"] = list.Count,
			["repliesTruncated"] = flag,
			["replies"] = list,
			["anchorRangeStart"] = UwYgF9f6Yb(range),
			["anchorRangeEnd"] = APoghQOd0q(range)
		};
		if (P_2)
		{
			dictionary["anchorText"] = rYN8Y355we(XPEgcZYWAO(CS_8_locals_11.GPkAA2kBUh), P_3);
		}
		return dictionary;
	}

	private static List<object> tmKgNwqeQC(Document P_0, Comment P_1, int P_2, out int P_3, out bool P_4)
	{
		_G_c__DisplayClass170_0 CS_8_locals_4 = new _G_c__DisplayClass170_0();
		List<object> list = new List<object>();
		CS_8_locals_4.cf4AdHv0sj = DOYgOEfqSy(P_1);
		P_3 = ((CS_8_locals_4.cf4AdHv0sj != null) ? Y1x8gkTvcF(() => CS_8_locals_4.cf4AdHv0sj.Count) : 0);
		int num = Math.Max(0, P_2);
		for (int num2 = 1; num2 <= P_3; num2++)
		{
			if (list.Count >= num)
			{
				break;
			}
			try
			{
				Comment comment = CS_8_locals_4.cf4AdHv0sj[num2];
				list.Add(EFLgm4wKb2(P_0, comment));
			}
			catch
			{
			}
		}
		P_4 = list.Count < P_3;
		return list;
	}

	private static object EFLgm4wKb2(Document P_0, Comment P_1)
	{
		_G_c__DisplayClass171_0 CS_8_locals_7 = new _G_c__DisplayClass171_0();
		CS_8_locals_7.SNfvVLBP8C = P_1;
		return new Dictionary<string, object>
		{
			["commentToken"] = qoRgqGAgBm(P_0, CS_8_locals_7.SNfvVLBP8C),
			["index"] = GQJgya6RkO(CS_8_locals_7.SNfvVLBP8C),
			["author"] = iOW8KTFwda(() => CS_8_locals_7.SNfvVLBP8C.Author),
			["date"] = MmigeqmiRt(CS_8_locals_7.SNfvVLBP8C),
			["done"] = Ex5TMxi7X1(() => CS_8_locals_7.SNfvVLBP8C.Done, ypQS6RTSiCdpSgKNQtr: false),
			["commentText"] = UNcg5o6WsG(CS_8_locals_7.SNfvVLBP8C)
		};
	}

	private static object XbygofR3TT(Document P_0, Comment P_1, Comment P_2, Comment P_3, string P_4)
	{
		Range range = QfAg7hyofH(P_1) ?? Rt8gnHTE8S(P_1);
		int? rangeStart = UwYgF9f6Yb(range);
		int? rangeEnd = APoghQOd0q(range);
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			targetCommentToken = qoRgqGAgBm(P_0, P_2),
			threadCommentToken = qoRgqGAgBm(P_0, P_1),
			replyCommentToken = qoRgqGAgBm(P_0, P_3),
			targetCommentIndex = GQJgya6RkO(P_2),
			threadCommentIndex = GQJgya6RkO(P_1),
			replyIndex = GQJgya6RkO(P_3),
			page = Y878QfFgDa(range),
			paragraphIndex = (rangeStart.HasValue ? EFt8ufX87I(P_0, rangeStart.Value) : ((int?)null)),
			rangeStart = rangeStart,
			rangeEnd = rangeEnd,
			scopeText = rYN8Y355we(XPEgcZYWAO(P_1), 500),
			commentText = UNcg5o6WsG(P_2),
			replyText = P_4,
			replyCount = K31gXUpeL7(P_1)
		};
	}

	private static rU18qH9owXvBsPZ0iiU xSQgG8pt5e(Document P_0, int P_1, out Comment P_2, out Comment P_3)
	{
		_G_c__DisplayClass173_0 CS_8_locals_8 = new _G_c__DisplayClass173_0();
		CS_8_locals_8.doc = P_0;
		P_2 = null;
		P_3 = null;
		if (CS_8_locals_8.doc == null)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前没有打开的 Word 文档。", "no_document");
		}
		if (P_1 <= 0)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("commentToken 或正整数 commentIndex 至少需要提供一个。", "invalid_arguments", new
			{
				commentIndex = P_1
			});
		}
		int num = Y1x8gkTvcF(() => CS_8_locals_8.doc.Comments.Count);
		for (int num2 = 1; num2 <= num; num2++)
		{
			_G_c__DisplayClass173_1 CS_8_locals_9 = new _G_c__DisplayClass173_1();
			Comment comment;
			try
			{
				comment = CS_8_locals_8.doc.Comments[num2];
			}
			catch
			{
				continue;
			}
			Comment comment2 = zBSgpYfGrc(comment);
			if (GQJgya6RkO(comment) == P_1)
			{
				P_2 = comment;
				P_3 = comment2 ?? comment;
				return null;
			}
			if (comment2 != null)
			{
				continue;
			}
			CS_8_locals_9.i0Hv6Nmgjt = DOYgOEfqSy(comment);
			int num3 = ((CS_8_locals_9.i0Hv6Nmgjt != null) ? Y1x8gkTvcF(() => CS_8_locals_9.i0Hv6Nmgjt.Count) : 0);
			for (int num4 = 1; num4 <= num3; num4++)
			{
				Comment comment3;
				try
				{
					comment3 = CS_8_locals_9.i0Hv6Nmgjt[num4];
				}
				catch
				{
					continue;
				}
				if (GQJgya6RkO(comment3) == P_1)
				{
					P_2 = comment3;
					P_3 = zBSgpYfGrc(comment3) ?? comment;
					return null;
				}
			}
		}
		return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("未找到指定 index 的 Word 批注。请重新读取批注后再回复。", "comment_not_found", new
		{
			commentIndex = P_1,
			totalComments = num
		});
	}

	private static rU18qH9owXvBsPZ0iiU CLCgCUGOui(Document P_0, string P_1, int P_2, out Comment P_3, out Comment P_4)
	{
		_G_c__DisplayClass174_0 CS_8_locals_7 = new _G_c__DisplayClass174_0();
		CS_8_locals_7.doc = P_0;
		P_3 = null;
		P_4 = null;
		if (CS_8_locals_7.doc == null)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前没有打开的 Word 文档。", "no_document");
		}
		string text = FRngW8eoao(P_1);
		if (string.IsNullOrWhiteSpace(text))
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("commentToken 格式无效。请使用 read_word_comments 返回的 commentToken。", "invalid_arguments", new
			{
				commentToken = P_1
			});
		}
		int num = Y1x8gkTvcF(() => CS_8_locals_7.doc.Comments.Count);
		if (P_2 > 0 && P_2 <= num)
		{
			try
			{
				Comment comment = CS_8_locals_7.doc.Comments[P_2];
				if (vHggP04cSD(CS_8_locals_7.doc, comment, text))
				{
					P_3 = comment;
					P_4 = zBSgpYfGrc(comment) ?? comment;
					return null;
				}
			}
			catch
			{
			}
		}
		List<Comment> list = new List<Comment>();
		for (int num2 = 1; num2 <= num; num2++)
		{
			Comment comment2;
			try
			{
				comment2 = CS_8_locals_7.doc.Comments[num2];
			}
			catch
			{
				continue;
			}
			if (vHggP04cSD(CS_8_locals_7.doc, comment2, text))
			{
				list.Add(comment2);
			}
		}
		if (list.Count == 0)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("未找到指定 commentToken 对应的 Word 批注。请重新读取批注后再回复。", "comment_token_not_found", new
			{
				commentToken = NywgvGXtAq(text),
				commentIndexHint = P_2,
				totalComments = num
			});
		}
		if (list.Count > 1)
		{
			return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("commentToken 匹配到多条 Word 批注。请重新读取批注后使用新的 token。", "comment_token_ambiguous", new
			{
				commentToken = NywgvGXtAq(text),
				commentIndexHint = P_2,
				matchedIndexes = list.Select(GQJgya6RkO).ToArray()
			});
		}
		P_3 = list[0];
		P_4 = zBSgpYfGrc(P_3) ?? P_3;
		return null;
	}

	private static Comment zBSgpYfGrc(Comment P_0)
	{
		try
		{
			return P_0?.Ancestor;
		}
		catch
		{
			return null;
		}
	}

	private static Comments DOYgOEfqSy(Comment P_0)
	{
		try
		{
			return P_0?.Replies;
		}
		catch
		{
			return null;
		}
	}

	private static Range Rt8gnHTE8S(Comment P_0)
	{
		try
		{
			return P_0?.Reference;
		}
		catch
		{
			return null;
		}
	}

	private static Range QfAg7hyofH(Comment P_0)
	{
		try
		{
			return P_0?.Scope;
		}
		catch
		{
			return null;
		}
	}

	private static string UNcg5o6WsG(Comment P_0)
	{
		_G_c__DisplayClass179_0 obj = new _G_c__DisplayClass179_0();
		obj.HThvTPlNIo = P_0;
		return Pfn84MVBvM(iOW8KTFwda(() => obj.HThvTPlNIo.Range.Text));
	}

	private static string XPEgcZYWAO(Comment P_0)
	{
		_G_c__DisplayClass180_0 obj = new _G_c__DisplayClass180_0();
		obj.z7dvrWsTRd = P_0;
		return Pfn84MVBvM(iOW8KTFwda(() => obj.z7dvrWsTRd.Scope.Text));
	}

	private static string MmigeqmiRt(Comment P_0)
	{
		_G_c__DisplayClass181_0 obj = new _G_c__DisplayClass181_0();
		obj.qQmv3ah72i = P_0;
		return iOW8KTFwda(() => obj.qQmv3ah72i.Date.ToString("endParagraphIndex is out of range.", CultureInfo.CurrentCulture));
	}

	private static int GQJgya6RkO(Comment P_0)
	{
		try
		{
			return P_0?.Index ?? 0;
		}
		catch
		{
			return 0;
		}
	}

	private static int K31gXUpeL7(Comment P_0)
	{
		_G_c__DisplayClass183_0 CS_8_locals_3 = new _G_c__DisplayClass183_0();
		CS_8_locals_3.ObJvKEDR9S = DOYgOEfqSy(P_0);
		if (CS_8_locals_3.ObJvKEDR9S != null)
		{
			return Y1x8gkTvcF(() => CS_8_locals_3.ObJvKEDR9S.Count);
		}
		return 0;
	}

	private static int? UwYgF9f6Yb(Range P_0)
	{
		try
		{
			return P_0?.Start;
		}
		catch
		{
			return null;
		}
	}

	private static int? APoghQOd0q(Range P_0)
	{
		try
		{
			return P_0?.End;
		}
		catch
		{
			return null;
		}
	}

	private static bool gxWgapxYhe(string P_0, string P_1)
	{
		string text = VkRg0Eonap(P_0);
		string value = VkRg0Eonap(P_1);
		if (!string.IsNullOrWhiteSpace(value))
		{
			return text.IndexOf(value, StringComparison.Ordinal) >= 0;
		}
		return true;
	}

	private static string qoRgqGAgBm(Document P_0, Comment P_1)
	{
		return NywgvGXtAq(z6cgA7I6fO(P_0, P_1));
	}

	private static bool vHggP04cSD(Document P_0, Comment P_1, string P_2)
	{
		if (P_1 == null || string.IsNullOrWhiteSpace(P_2))
		{
			return false;
		}
		return string.Equals(z6cgA7I6fO(P_0, P_1), P_2, StringComparison.OrdinalIgnoreCase);
	}

	private static string z6cgA7I6fO(Document P_0, Comment P_1)
	{
		_G_c__DisplayClass189_0 CS_8_locals_9 = new _G_c__DisplayClass189_0();
		CS_8_locals_9.doc = P_0;
		CS_8_locals_9.dZqvjvPh60 = P_1;
		Range range = QfAg7hyofH(CS_8_locals_9.dZqvjvPh60) ?? Rt8gnHTE8S(CS_8_locals_9.dZqvjvPh60);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("comment-token-v1").Append('\n').Append(iOW8KTFwda(() => CS_8_locals_9.doc.FullName))
			.Append('\n')
			.Append(iOW8KTFwda(() => CS_8_locals_9.doc.Name))
			.Append('\n')
			.Append(VkRg0Eonap(iOW8KTFwda(() => CS_8_locals_9.dZqvjvPh60.Author)))
			.Append('\n')
			.Append(MmigeqmiRt(CS_8_locals_9.dZqvjvPh60))
			.Append('\n')
			.Append(VkRg0Eonap(UNcg5o6WsG(CS_8_locals_9.dZqvjvPh60)))
			.Append('\n')
			.Append(UwYgF9f6Yb(range)?.ToString(CultureInfo.InvariantCulture) ?? string.Empty)
			.Append('\n')
			.Append(APoghQOd0q(range)?.ToString(CultureInfo.InvariantCulture) ?? string.Empty);
		using SHA256 sHA = SHA256.Create();
		return BitConverter.ToString(sHA.ComputeHash(Encoding.UTF8.GetBytes(stringBuilder.ToString()))).Replace("-", string.Empty).Substring(0, 8)
			.ToUpperInvariant();
	}

	private static string NywgvGXtAq(string P_0)
	{
		string text = FRngW8eoao(P_0);
		if (text.Length < 8)
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				return "CMT-" + text;
			}
			return string.Empty;
		}
		text = text.Substring(0, 8);
		return "CMT-" + text.Substring(0, 4) + "-" + text.Substring(4, 4);
	}

	private static string FRngW8eoao(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(P_0.Length);
		foreach (char c in P_0)
		{
			if (char.IsLetterOrDigit(c))
			{
				stringBuilder.Append(char.ToUpperInvariant(c));
			}
		}
		string text = stringBuilder.ToString();
		if (text.StartsWith("CMT", StringComparison.Ordinal))
		{
			text = text.Substring(3);
		}
		return text;
	}

	private static string VkRg0Eonap(string P_0)
	{
		return Regex.Replace(Pfn84MVBvM(P_0).Replace("\\\\r\\\\n", "\n").Replace("\\\\r", "\n").Replace("\\\\n", "\n")
			.Replace("\r\n", "\n")
			.Replace('\r', '\n'), "\\s+", " ").Trim();
	}

	private static object MAygkj8OcZ(Document P_0, Table P_1, int P_2, Range P_3)
	{
		_G_c__DisplayClass193_0 CS_8_locals_3 = new _G_c__DisplayClass193_0();
		CS_8_locals_3.v4mvtS4fDJ = P_1;
		int? rowIndex = null;
		int? columnIndex = null;
		string text = null;
		try
		{
			if (P_3 != null && P_3.Cells != null && P_3.Cells.Count > 0)
			{
				Cell cell = P_3.Cells[1];
				rowIndex = bfl83TJXMI(cell);
				columnIndex = lJe8UuBPlV(cell);
				text = Pfn84MVBvM(cell.Range.Text);
			}
		}
		catch
		{
		}
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			tableIndex = P_2,
			rowIndex = rowIndex,
			columnIndex = columnIndex,
			locationKind = ((rowIndex.HasValue && columnIndex.HasValue) ? "tableRange" : "cell"),
			page = Y878QfFgDa(P_3),
			rangeStart = P_3.Start,
			rangeEnd = P_3.End,
			matchText = Pfn84MVBvM(P_3.Text),
			excerpt = qjs8fKSXJR(P_0, P_3, 160),
			cellTextPreview = (string.IsNullOrEmpty(text) ? null : rYN8Y355we(text, 240)),
			tableRangeStart = Ex5TMxi7X1(() => CS_8_locals_3.v4mvtS4fDJ.Range.Start, 0),
			tableRangeEnd = Ex5TMxi7X1(() => CS_8_locals_3.v4mvtS4fDJ.Range.End, 0)
		};
	}

	private static List<JLaVmTitkrKJCiFb1D5> jIegxGSM8E(Microsoft.Office.Interop.Word.Application P_0, Document P_1, string P_2, bool P_3, bool P_4, int P_5)
	{
		_G_c__DisplayClass194_0 CS_8_locals_24 = new _G_c__DisplayClass194_0();
		CS_8_locals_24.Q3qvGo2NUJ = P_0;
		CS_8_locals_24.doc = P_1;
		List<JLaVmTitkrKJCiFb1D5> list = new List<JLaVmTitkrKJCiFb1D5>();
		if (CS_8_locals_24.Q3qvGo2NUJ == null || CS_8_locals_24.doc == null || string.IsNullOrEmpty(P_2))
		{
			return list;
		}
		CS_8_locals_24.KaavoKjFKG = CS_8_locals_24.Q3qvGo2NUJ.Selection;
		if (CS_8_locals_24.KaavoKjFKG == null || CS_8_locals_24.KaavoKjFKG.Range == null)
		{
			return list;
		}
		int num = Ex5TMxi7X1(() => CS_8_locals_24.KaavoKjFKG.Range.Start, CS_8_locals_24.doc.Content.Start);
		int end = Ex5TMxi7X1(() => CS_8_locals_24.KaavoKjFKG.Range.End, num);
		bool screenUpdating = Ex5TMxi7X1(() => CS_8_locals_24.Q3qvGo2NUJ.ScreenUpdating, ypQS6RTSiCdpSgKNQtr: true);
		int num2 = Ex5TMxi7X1(() => CS_8_locals_24.doc.Content.Start, 0);
		int num3 = Ex5TMxi7X1(() => CS_8_locals_24.doc.Content.End, num2);
		if (num3 <= num2)
		{
			return list;
		}
		HashSet<string> hashSet = new HashSet<string>(StringComparer.Ordinal);
		int num4 = num2;
		int num5 = 0;
		int num6 = Math.Max(20, P_5 * 5);
		try
		{
			try
			{
				CS_8_locals_24.Q3qvGo2NUJ.ScreenUpdating = false;
			}
			catch
			{
			}
			while (list.Count < P_5 && num4 < num3 && num5 < num6)
			{
				_G_c__DisplayClass194_1 CS_8_locals_26 = new _G_c__DisplayClass194_1();
				num5++;
				CS_8_locals_24.KaavoKjFKG.SetRange(num4, num4);
				Find find = CS_8_locals_24.KaavoKjFKG.Find;
				find.ClearFormatting();
				find.Text = P_2;
				find.MatchCase = P_3;
				find.MatchWholeWord = P_4;
				find.MatchWildcards = false;
				find.MatchSoundsLike = false;
				find.MatchAllWordForms = false;
				find.Forward = true;
				find.Wrap = WdFindWrap.wdFindStop;
				find.Format = false;
				object FindText = Type.Missing;
				object MatchCase = Type.Missing;
				object MatchWholeWord = Type.Missing;
				object MatchWildcards = Type.Missing;
				object MatchSoundsLike = Type.Missing;
				object MatchAllWordForms = Type.Missing;
				object Forward = Type.Missing;
				object Wrap = Type.Missing;
				object Format = Type.Missing;
				object ReplaceWith = Type.Missing;
				object Replace = Type.Missing;
				object MatchKashida = Type.Missing;
				object MatchDiacritics = Type.Missing;
				object MatchAlefHamza = Type.Missing;
				object MatchControl = Type.Missing;
				if (!find.Execute(ref FindText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref ReplaceWith, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl) || CS_8_locals_24.KaavoKjFKG.Range == null)
				{
					break;
				}
				CS_8_locals_26.NSNvOLlBYV = CS_8_locals_24.KaavoKjFKG.Range.Duplicate;
				int num7 = Ex5TMxi7X1(() => CS_8_locals_26.NSNvOLlBYV.Start, num4);
				int num8 = Ex5TMxi7X1(() => CS_8_locals_26.NSNvOLlBYV.End, num7);
				if (num8 <= num7)
				{
					num4 = Math.Min(num3, Math.Max(num4 + 1, num7 + 1));
					continue;
				}
				string item = num7.ToString(CultureInfo.InvariantCulture) + ":" + num8.ToString(CultureInfo.InvariantCulture);
				if (hashSet.Add(item))
				{
					list.Add(v6Egd1uyy4(CS_8_locals_26.NSNvOLlBYV));
				}
				int num9 = Math.Max(num8, num7 + 1);
				if (num9 <= num4)
				{
					num9 = num4 + 1;
				}
				num4 = Math.Min(num3, num9);
			}
		}
		finally
		{
			try
			{
				CS_8_locals_24.KaavoKjFKG.SetRange(num, end);
			}
			catch
			{
			}
			try
			{
				CS_8_locals_24.Q3qvGo2NUJ.ScreenUpdating = screenUpdating;
			}
			catch
			{
			}
		}
		return list;
	}

	private static JLaVmTitkrKJCiFb1D5 v6Egd1uyy4(Range P_0)
	{
		string text = d4dgzASeJE(P_0, 1200);
		int length = text.Length;
		bool flag = text.Length > 1200;
		return new JLaVmTitkrKJCiFb1D5
		{
			ParagraphIndex = null,
			RangeStart = P_0.Start,
			RangeEnd = P_0.End,
			MatchText = Pfn84MVBvM(P_0.Text),
			ParagraphText = (flag ? rYN8Y355we(text, 1200) : text),
			ParagraphTextCharacters = length,
			ParagraphTextTruncated = flag
		};
	}

	private static string d4dgzASeJE(Range P_0, int P_1)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		try
		{
			_G_c__DisplayClass196_0 obj = new _G_c__DisplayClass196_0();
			obj.doc = P_0.Document;
			int num = Math.Max(20, P_1 / 2);
			int val = Ex5TMxi7X1(() => obj.doc.Content.Start, P_0.Start);
			int val2 = Ex5TMxi7X1(() => obj.doc.Content.End, P_0.End);
			int num2 = Math.Max(val, P_0.Start - num);
			int num3 = Math.Min(val2, P_0.End + num);
			Document document = obj.doc;
			object Start = num2;
			object End = num3;
			return rYN8Y355we(Pfn84MVBvM(document.Range(ref Start, ref End).Text), P_1);
		}
		catch
		{
			return rYN8Y355we(Pfn84MVBvM(P_0.Text), P_1);
		}
	}

	private static List<GrMBSXi2HFwNBUhA3m6> wS88Rn9xSe(Document P_0, string P_1, bool P_2, int P_3)
	{
		_G_c__DisplayClass197_0 CS_8_locals_3 = new _G_c__DisplayClass197_0();
		CS_8_locals_3.doc = P_0;
		List<GrMBSXi2HFwNBUhA3m6> list = new List<GrMBSXi2HFwNBUhA3m6>();
		RegexOptions options = ((!P_2) ? RegexOptions.IgnoreCase : RegexOptions.None);
		Regex regex = new Regex(P_1, options);
		int num = Y1x8gkTvcF(() => CS_8_locals_3.doc.Paragraphs.Count);
		for (int num2 = 1; num2 <= num; num2++)
		{
			if (list.Count >= P_3)
			{
				break;
			}
			Paragraph paragraph = CS_8_locals_3.doc.Paragraphs[num2];
			string text = Pfn84MVBvM(paragraph.Range.Text);
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			foreach (Match item in regex.Matches(text))
			{
				if (list.Count >= P_3)
				{
					break;
				}
				int num3 = paragraph.Range.Start + item.Index;
				list.Add(new GrMBSXi2HFwNBUhA3m6
				{
					ParagraphIndex = num2,
					Page = Y878QfFgDa(paragraph.Range),
					CharIndexStart = item.Index + 1,
					CharIndexEnd = item.Index + item.Length,
					RangeStart = num3,
					RangeEnd = num3 + item.Length,
					MatchText = item.Value,
					Excerpt = sYQ8ZuMpMn(text, item.Index, item.Length)
				});
			}
		}
		return list;
	}

	private static object o9s8V9QIyZ(Document P_0, List<JLaVmTitkrKJCiFb1D5> P_1, int P_2)
	{
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			actionableRange = true,
			lightweight = true,
			includesParagraphText = true,
			returned = P_1.Count,
			truncated = (P_1.Count >= P_2),
			matches = hBu8Br0t8A(P_1)
		};
	}

	private static List<object> hBu8Br0t8A(IEnumerable<JLaVmTitkrKJCiFb1D5> P_0)
	{
		List<object> list = new List<object>();
		int num = 0;
		foreach (JLaVmTitkrKJCiFb1D5 item in P_0)
		{
			num++;
			list.Add(new
			{
				index = num,
				paragraphIndex = item.ParagraphIndex,
				rangeStart = item.RangeStart,
				rangeEnd = item.RangeEnd,
				matchText = item.MatchText,
				paragraphText = item.ParagraphText,
				paragraphTextCharacters = item.ParagraphTextCharacters,
				paragraphTextTruncated = item.ParagraphTextTruncated
			});
		}
		return list;
	}

	private static object pMT896JE6T(Document P_0, List<GrMBSXi2HFwNBUhA3m6> P_1, int P_2)
	{
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			returned = P_1.Count,
			truncated = (P_1.Count >= P_2),
			matches = kTK86wiIqP(P_0, P_1)
		};
	}

	private static List<object> kTK86wiIqP(Document P_0, IEnumerable<GrMBSXi2HFwNBUhA3m6> P_1)
	{
		List<object> list = new List<object>();
		foreach (GrMBSXi2HFwNBUhA3m6 item in P_1)
		{
			list.Add(new
			{
				document = P_0.Name,
				documentFullName = P_0.FullName,
				page = item.Page,
				paragraphIndex = item.ParagraphIndex,
				charIndexStart = item.CharIndexStart,
				charIndexEnd = item.CharIndexEnd,
				rangeStart = item.RangeStart,
				rangeEnd = item.RangeEnd,
				matchText = item.MatchText,
				excerpt = item.Excerpt
			});
		}
		return list;
	}

	private static int? EFt8ufX87I(Document P_0, int P_1)
	{
		try
		{
			int count = P_0.Paragraphs.Count;
			int num = 1;
			int num2 = count;
			while (num <= num2)
			{
				int num3 = (num + num2) / 2;
				Paragraph paragraph = P_0.Paragraphs[num3];
				if (P_1 < paragraph.Range.Start)
				{
					num2 = num3 - 1;
					continue;
				}
				if (P_1 >= paragraph.Range.End)
				{
					num = num3 + 1;
					continue;
				}
				return num3;
			}
		}
		catch
		{
		}
		return null;
	}

	private static int iSW8Dscw3U(Document P_0, WdStatistic P_1)
	{
		try
		{
			object IncludeFootnotesAndEndnotes = Type.Missing;
			return P_0.ComputeStatistics(P_1, ref IncludeFootnotesAndEndnotes);
		}
		catch
		{
			return 0;
		}
	}

	private static bool qYW8T4YgwR(Document P_0)
	{
		try
		{
			return P_0.TrackRevisions;
		}
		catch
		{
			return false;
		}
	}

	private static int Y1x8gkTvcF(Func<int> P_0)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return 0;
		}
	}

	private static int fSO88F0gne(Paragraph P_0)
	{
		try
		{
			return (int)P_0.OutlineLevel;
		}
		catch
		{
			return 10;
		}
	}

	private static int cjC8ImVBAy(int P_0)
	{
		if (P_0 < 1 || P_0 > 9)
		{
			return 0;
		}
		return P_0;
	}

	private static int PZD8ivf3BX(int P_0)
	{
		if (P_0 != 0)
		{
			return P_0;
		}
		return 10;
	}

	private static string kBH8HcK06n(Paragraph P_0)
	{
		try
		{
			_G_c__DisplayClass209_0 CS_8_locals_3 = new _G_c__DisplayClass209_0();
			object style = P_0.Range.get_Style();
			if (style == null)
			{
				return string.Empty;
			}
			CS_8_locals_3.ABCv01h65Y = style as Style;
			if (CS_8_locals_3.ABCv01h65Y != null)
			{
				string text = iOW8KTFwda(() => CS_8_locals_3.ABCv01h65Y.NameLocal);
				if (!string.IsNullOrWhiteSpace(text))
				{
					return text;
				}
			}
			string text2 = style as string;
			if (!string.IsNullOrWhiteSpace(text2))
			{
				return text2;
			}
			try
			{
				object arg = style;
				if (_G_o__209.faad26YgtT == null)
				{
					_G_o__209.faad26YgtT = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "NameLocal", typeof(kyVxiEuxDXgR94DylXE), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				string text3 = (dynamic)_G_o__209.faad26YgtT.Target(_G_o__209.faad26YgtT, arg);
				if (!string.IsNullOrWhiteSpace(text3))
				{
					return text3;
				}
			}
			catch
			{
			}
			try
			{
				object arg2 = style;
				if (_G_o__209.Tncdj71sno == null)
				{
					_G_o__209.Tncdj71sno = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Name", typeof(kyVxiEuxDXgR94DylXE), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				string text4 = (dynamic)_G_o__209.Tncdj71sno.Target(_G_o__209.Tncdj71sno, arg2);
				if (!string.IsNullOrWhiteSpace(text4))
				{
					return text4;
				}
			}
			catch
			{
			}
			string text5 = style.ToString();
			return string.Equals(text5, "System.__ComObject", StringComparison.OrdinalIgnoreCase) ? string.Empty : text5;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static int Y878QfFgDa(Range P_0)
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

	private static bool YsX81TpOe7(Range P_0)
	{
		try
		{
			return P_0 != null && (bool)(dynamic)P_0.get_Information(WdInformation.wdWithInTable);
		}
		catch
		{
			return false;
		}
	}

	private static int PJm8rI8jwn(Table P_0)
	{
		try
		{
			return P_0?.Rows.Count ?? 0;
		}
		catch
		{
			return 0;
		}
	}

	private static int ldc8JB4JIl(Table P_0)
	{
		try
		{
			return P_0?.Columns.Count ?? 0;
		}
		catch
		{
			return 0;
		}
	}

	private static int? bfl83TJXMI(Cell P_0)
	{
		try
		{
			return P_0.RowIndex;
		}
		catch
		{
			return null;
		}
	}

	private static int? lJe8UuBPlV(Cell P_0)
	{
		try
		{
			return P_0.ColumnIndex;
		}
		catch
		{
			return null;
		}
	}

	private static string iOW8KTFwda(Func<string> P_0)
	{
		try
		{
			return P_0() ?? string.Empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static int Qb88EN6Ey5(int P_0, int P_1, int P_2)
	{
		if (P_0 <= 0)
		{
			P_0 = P_1;
		}
		return Math.Max(1, Math.Min(P_0, P_2));
	}

	private static int mrd82RKl0E(int P_0)
	{
		if (P_0 <= 0)
		{
			P_0 = 1;
		}
		return Math.Max(1, Math.Min(P_0, 9));
	}

	private static string Pfn84MVBvM(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(P_0.Length);
		foreach (char c in P_0)
		{
			if (c == '\a' || c == '\a')
			{
				stringBuilder.Append(' ');
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return Regex.Replace(stringBuilder.ToString(), "[ \\\\t]+", " ").Trim();
	}

	private static string TkI8jwiSoi(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			return P_0;
		}
		return null;
	}

	private static string rYN8Y355we(string P_0, int P_1)
	{
		if (string.IsNullOrEmpty(P_0) || P_0.Length <= P_1)
		{
			return P_0 ?? string.Empty;
		}
		return P_0.Substring(0, P_1) + "...";
	}

	private static string sYQ8ZuMpMn(string P_0, int P_1, int P_2)
	{
		int num = Math.Max(20, (160 - P_2) / 2);
		int num2 = Math.Max(0, P_1 - num);
		int num3 = Math.Min(P_0.Length, P_1 + P_2 + num);
		string text = P_0.Substring(num2, num3 - num2).Trim();
		if (num2 > 0)
		{
			text = "..." + text;
		}
		if (num3 < P_0.Length)
		{
			text += "...";
		}
		return text;
	}

	private static string qjs8fKSXJR(Document P_0, Range P_1, int P_2)
	{
		try
		{
			int num = Math.Max(20, P_2 / 2);
			int num2 = Math.Max(P_0.Content.Start, P_1.Start - num);
			int num3 = Math.Min(P_0.Content.End, P_1.End + num);
			object Start = num2;
			object End = num3;
			return rYN8Y355we(Pfn84MVBvM(P_0.Range(ref Start, ref End).Text), P_2);
		}
		catch
		{
			return rYN8Y355we(Pfn84MVBvM(P_1?.Text), P_2);
		}
	}

	private static bool vvS8MMU2Ay(string P_0, int P_1, int P_2)
	{
		bool num = P_1 <= 0 || !uRT8biSIxp(P_0[P_1 - 1]);
		int num2 = P_1 + P_2;
		bool flag = num2 >= P_0.Length || !uRT8biSIxp(P_0[num2]);
		return num && flag;
	}

	private static bool uRT8biSIxp(char P_0)
	{
		if (!char.IsLetterOrDigit(P_0))
		{
			return P_0 == '_';
		}
		return true;
	}

	private static IEnumerable<string> rX98SqsM2D(IEnumerable<string> P_0)
	{
		foreach (string item in P_0)
		{
			yield return (item ?? string.Empty).Replace("invalid_arguments", "wholeTable").Replace("wholetable", "all").Replace("table", "wholeTable")
				.Replace("headerrow", "header");
		}
	}

	private static List<string> J6X8wOwgCa(List<string> P_0)
	{
		List<string> list = new List<string>();
		foreach (string item in P_0)
		{
			if (!string.IsNullOrWhiteSpace(item) && !list.Contains(item))
			{
				list.Add(item);
			}
		}
		return list;
	}

	static kyVxiEuxDXgR94DylXE()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		kCy8tdAKvt = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
		hLV8L0pG1W = "http://schemas.microsoft.com/office/2006/xmlPackage";
	}
}
