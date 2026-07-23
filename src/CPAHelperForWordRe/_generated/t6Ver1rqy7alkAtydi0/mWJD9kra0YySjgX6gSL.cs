using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using dL7TFPsQbAGqPywtHUK;
using hJKpQrVSwRwMyI2RyDQN;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;
using x89WxLeaSJIPrFI7Yj;
using zXs8EW9GijtvoeAXF0q;

namespace t6Ver1rqy7alkAtydi0;

internal sealed class mWJD9kra0YySjgX6gSL
{
	private sealed class onEqFoV6VqxGOBHbQtJW : Exception
	{
		[CompilerGenerated]
		private readonly string xQGV6Bfh2VH;

		[CompilerGenerated]
		private readonly object GAYV69ai91n;

		public string Code
		{
			[CompilerGenerated]
			get
			{
				return xQGV6Bfh2VH;
			}
		}

		public object DataObject
		{
			[CompilerGenerated]
			get
			{
				return GAYV69ai91n;
			}
		}

		public onEqFoV6VqxGOBHbQtJW(string P_0, string P_1, object P_2 = null) : base(P_0)
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			xQGV6Bfh2VH = P_1;
			GAYV69ai91n = P_2;
		}
	}

	private sealed class XFNayjV66fonCSKcSbOJ : IDisposable
	{
		private readonly List<object> EYPV6gY5voB;

		public Dy6bBfV6DuSuayxpQdkX eKvV6uFJpGF<Dy6bBfV6DuSuayxpQdkX>(Dy6bBfV6DuSuayxpQdkX avPcJCV6TkJuYPNVrrLv) where Dy6bBfV6DuSuayxpQdkX : class
		{
			if (avPcJCV6TkJuYPNVrrLv != null && Marshal.IsComObject(avPcJCV6TkJuYPNVrrLv))
			{
				EYPV6gY5voB.Add(avPcJCV6TkJuYPNVrrLv);
			}
			return avPcJCV6TkJuYPNVrrLv;
		}

		public void Dispose()
		{
			for (int num = EYPV6gY5voB.Count - 1; num >= 0; num--)
			{
				try
				{
					if (EYPV6gY5voB[num] != null && Marshal.IsComObject(EYPV6gY5voB[num]))
					{
						Marshal.ReleaseComObject(EYPV6gY5voB[num]);
					}
				}
				catch
				{
				}
			}
		}

		public XFNayjV66fonCSKcSbOJ()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			EYPV6gY5voB = new List<object>();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_0
	{
		public rU18qH9owXvBsPZ0iiU HxcV63kMOK7;

		public string tNlV6Uc69Ov;

		public Func<Application, XFNayjV66fonCSKcSbOJ, rU18qH9owXvBsPZ0iiU> ALPV6KJXDoZ;

		public Exception S0RV6EnSD9i;

		public _G_c__DisplayClass10_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void QrkV6J1ibaQ()
		{
			Application application = null;
			XFNayjV66fonCSKcSbOJ xFNayjV66fonCSKcSbOJ = new XFNayjV66fonCSKcSbOJ();
			try
			{
				application = xcAKcictyYcoMl6ObA.X11yRCCGO();
				if (application == null)
				{
					HxcV63kMOK7 = rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("未检测到已打开的 " + i0rJZwDpdH() + "。请先打开对应的表格应用和工作簿。", "spreadsheet_not_running", new
					{
						host = i0rJZwDpdH()
					});
					return;
				}
				yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[AI Tool][Excel] Begin: " + tNlV6Uc69Ov);
				HxcV63kMOK7 = ALPV6KJXDoZ(application, xFNayjV66fonCSKcSbOJ);
				yR9thasHZ73xXm8eKwj.swCsJ4IbrL("[AI Tool][Excel] End: " + tNlV6Uc69Ov + "; Success=" + (HxcV63kMOK7 != null && HxcV63kMOK7.success));
			}
			catch (COMException ex)
			{
				yR9thasHZ73xXm8eKwj.ujWsURly3F("[AI Tool][Excel] " + tNlV6Uc69Ov + " failed", ex);
				HxcV63kMOK7 = rU18qH9owXvBsPZ0iiU.g7A9nYlk8v(tNlV6Uc69Ov + " failed", "spreadsheet_com_error", ex);
			}
			catch (onEqFoV6VqxGOBHbQtJW onEqFoV6VqxGOBHbQtJW2)
			{
				yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[AI Tool][Excel] " + tNlV6Uc69Ov + " failed: " + onEqFoV6VqxGOBHbQtJW2.Message);
				HxcV63kMOK7 = rU18qH9owXvBsPZ0iiU.QSD9OKWs4n(onEqFoV6VqxGOBHbQtJW2.Message, onEqFoV6VqxGOBHbQtJW2.Code, onEqFoV6VqxGOBHbQtJW2.DataObject);
			}
			catch (Exception ex2)
			{
				yR9thasHZ73xXm8eKwj.ujWsURly3F("[AI Tool][Excel] " + tNlV6Uc69Ov + " failed", ex2);
				S0RV6EnSD9i = ex2;
			}
			finally
			{
				xFNayjV66fonCSKcSbOJ.Dispose();
				if (application != null && Marshal.IsComObject(application))
				{
					try
					{
						Marshal.ReleaseComObject(application);
					}
					catch
					{
					}
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass11_0
	{
		public Workbooks CpKV6jX7XS8;

		public Func<int> AFfV6YsKxMA;

		public _G_c__DisplayClass11_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int TB7V62gMQ0q()
		{
			return CpKV6jX7XS8.Count;
		}

		internal int wLaV64PhZcw()
		{
			return CpKV6jX7XS8.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass12_0
	{
		public Sheets IECV6f5YUIC;

		public Func<int> z12V6MPx6rV;

		public _G_c__DisplayClass12_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int w5lV6Z8wKMI()
		{
			return IECV6f5YUIC.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_0
	{
		public Microsoft.Office.Interop.Excel.Range agZV6tbacUb;

		public Workbook XkPV6LkxPkZ;

		public _G_c__DisplayClass16_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int dOWV6bgMLm6()
		{
			return agZV6tbacUb.Rows.Count;
		}

		internal int uu5V6St1mIO()
		{
			return agZV6tbacUb.Columns.Count;
		}

		internal string ztIV6wpXj70()
		{
			return XkPV6LkxPkZ.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_1
	{
		public Microsoft.Office.Interop.Excel.Range fP3V6lZeaH2;

		public _G_c__DisplayClass16_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal bool yN5V6sp6LoY()
		{
			return (dynamic)fP3V6lZeaH2.Hidden;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_2
	{
		public Microsoft.Office.Interop.Excel.Range pNlV6CBr7t1;

		public _G_c__DisplayClass16_2()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string SImV6N7QuKb()
		{
			dynamic val;
			if (!(((dynamic)pNlV6CBr7t1.Formula == null) ? true : false))
			{
				if (_G_o__16.KEgVDU5cs3b == null)
				{
					_G_o__16.KEgVDU5cs3b = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(mWJD9kra0YySjgX6gSL), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__16.KEgVDU5cs3b.Target(_G_o__16.KEgVDU5cs3b, pNlV6CBr7t1.Formula);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		}

		internal string TbjV6mlM2t6()
		{
			dynamic val;
			if (!(((dynamic)pNlV6CBr7t1.NumberFormat == null) ? true : false))
			{
				if (_G_o__16.yglVD4Gxfsw == null)
				{
					_G_o__16.yglVD4Gxfsw = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(mWJD9kra0YySjgX6gSL), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__16.yglVD4Gxfsw.Target(_G_o__16.yglVD4Gxfsw, pNlV6CBr7t1.NumberFormat);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		}

		internal bool T5RV6oWCHTi()
		{
			return (dynamic)pNlV6CBr7t1.Font.Bold;
		}

		internal string QHLV6GlcpyH()
		{
			dynamic val;
			if (!(((dynamic)pNlV6CBr7t1.Interior.Color == null) ? true : false))
			{
				if (_G_o__16.uZHVDMnQAFH == null)
				{
					_G_o__16.uZHVDMnQAFH = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(mWJD9kra0YySjgX6gSL), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__16.uZHVDMnQAFH.Target(_G_o__16.uZHVDMnQAFH, pNlV6CBr7t1.Interior.Color);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass18_0
	{
		public Microsoft.Office.Interop.Excel.Range UxyV6nWori1;

		public _G_c__DisplayClass18_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int L2tV6pPcMua()
		{
			return UxyV6nWori1.Rows.Count;
		}

		internal int gP7V6OucRW5()
		{
			return UxyV6nWori1.Columns.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass19_0
	{
		public Microsoft.Office.Interop.Excel.Range IrtV6e49vaj;

		public _G_c__DisplayClass19_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal object ANqV675qvYQ()
		{
			return IrtV6e49vaj.Value2;
		}

		internal int pwoV65uf3pI()
		{
			return IrtV6e49vaj.Row;
		}

		internal int L7TV6c20uCT()
		{
			return IrtV6e49vaj.Column;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass1_0
	{
		public Workbook gkiV6hLLvMu;

		public Microsoft.Office.Interop.Excel.Range Uy3V6aJaiSk;

		public _G_c__DisplayClass1_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string bhDV6yBhVoC()
		{
			return gkiV6hLLvMu.FullName;
		}

		internal int TcEV6XrljnS()
		{
			return Uy3V6aJaiSk.Rows.Count;
		}

		internal int Y0XV6FGK0cS()
		{
			return Uy3V6aJaiSk.Columns.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass20_0
	{
		public Microsoft.Office.Interop.Excel.Range JifV6vA3iT1;

		public _G_c__DisplayClass20_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int uh9V6qsXOtu()
		{
			return JifV6vA3iT1.Row;
		}

		internal int TLfV6P8WkO1()
		{
			return JifV6vA3iT1.Column;
		}

		internal string BPXV6AyyAPd()
		{
			dynamic val;
			if (!(((dynamic)JifV6vA3iT1.Formula == null) ? true : false))
			{
				if (_G_o__20.a3AVDlVXcmE == null)
				{
					_G_o__20.a3AVDlVXcmE = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(mWJD9kra0YySjgX6gSL), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__20.a3AVDlVXcmE.Target(_G_o__20.a3AVDlVXcmE, JifV6vA3iT1.Formula);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass21_0
	{
		public Microsoft.Office.Interop.Excel.Range K2lV6kSYl1J;

		public _G_c__DisplayClass21_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int suMV6W9q4wR()
		{
			return K2lV6kSYl1J.Row;
		}

		internal int ER1V60axrbA()
		{
			return K2lV6kSYl1J.Column;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_0
	{
		public Names EsbV6djlCSO;

		public Func<int> OABV6zVyGRF;

		public _G_c__DisplayClass23_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int GU4V6xZclog()
		{
			return EsbV6djlCSO.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_1
	{
		public Sheets nuvVuVXaUZa;

		public Func<int> L6XVuBlg5HQ;

		public _G_c__DisplayClass23_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int FalVuRjaACn()
		{
			return nuvVuVXaUZa.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_2
	{
		public Names hClVu63L3hp;

		public Func<int> z2xVuuhK3AW;

		public _G_c__DisplayClass23_2()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int rBMVu9rwCSr()
		{
			return hClVu63L3hp.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass24_0
	{
		public Name gMvVuTWFYAE;

		public _G_c__DisplayClass24_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string tPgVuDMSEvI()
		{
			return gMvVuTWFYAE.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass26_0
	{
		public Workbook i5mVuITLgOH;

		public _G_c__DisplayClass26_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string Wx9Vug0DerK()
		{
			return i5mVuITLgOH.Name;
		}

		internal string DDtVu8HY9gn()
		{
			return i5mVuITLgOH.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass29_0
	{
		public Microsoft.Office.Interop.Excel.Range QPxVuHFBKg9;

		public _G_c__DisplayClass29_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string i8HVuiGv6MV()
		{
			dynamic val;
			if (!(((dynamic)QPxVuHFBKg9.Text == null) ? true : false))
			{
				if (_G_o__29.LRuVDC0PlSQ == null)
				{
					_G_o__29.LRuVDC0PlSQ = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(mWJD9kra0YySjgX6gSL), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__29.LRuVDC0PlSQ.Target(_G_o__29.LRuVDC0PlSQ, QPxVuHFBKg9.Text);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0
	{
		public Workbook zmaVurdydP4;

		public Workbooks bDFVuJ7xY4x;

		public Func<int> ns3Vu30RDmQ;

		public _G_c__DisplayClass2_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string U1PVuQP0nq2()
		{
			return zmaVurdydP4.Name;
		}

		internal int HkZVu1BQPDg()
		{
			return bDFVuJ7xY4x.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_1
	{
		public Workbook HitVuYWWWDt;

		public _G_c__DisplayClass2_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string OyUVuUFgW3Z()
		{
			return HitVuYWWWDt.Name;
		}

		internal string BxtVuKHyLBk()
		{
			return HitVuYWWWDt.FullName;
		}

		internal string Li2VuE8xk40()
		{
			return HitVuYWWWDt.Path;
		}

		internal bool UFmVu22lSY9()
		{
			return HitVuYWWWDt.ReadOnly;
		}

		internal bool XgCVu47Mk6C()
		{
			return HitVuYWWWDt.Saved;
		}

		internal int uBvVujXxMUF()
		{
			return HitVuYWWWDt.Worksheets.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_0
	{
		public Microsoft.Office.Interop.Excel.Range ccQVufmDjvb;

		public _G_c__DisplayClass30_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string kcrVuZuVhoR()
		{
			return ccQVufmDjvb.get_Address((object)false, (object)false, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass3_0
	{
		public string AhDVubjV0nx;

		public _G_c__DisplayClass3_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU TWDVuMtXBUI(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			_G_c__DisplayClass3_1 CS_8_locals_7 = new _G_c__DisplayClass3_1();
			CS_8_locals_7.iUYVuL0KBFm = yFgJROsdyk(app, scope, AhDVubjV0nx);
			CS_8_locals_7.vhoVutjxFsc = scope.eKvV6uFJpGF(CS_8_locals_7.iUYVuL0KBFm.Worksheets);
			List<object> list = new List<object>();
			for (int i = 1; i <= pCPJ2o3f45(() => CS_8_locals_7.vhoVutjxFsc.Count); i++)
			{
				Worksheet worksheet = scope.eKvV6uFJpGF((Worksheet)(dynamic)CS_8_locals_7.vhoVutjxFsc[i]);
				list.Add(new
				{
					index = i,
					name = worksheet.Name
				});
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Worksheet list retrieved.", new
			{
				workbook = CS_8_locals_7.iUYVuL0KBFm.Name,
				workbookFullName = hjGJjwaZBM(() => CS_8_locals_7.iUYVuL0KBFm.FullName),
				count = list.Count,
				sheets = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass3_1
	{
		public Sheets vhoVutjxFsc;

		public Workbook iUYVuL0KBFm;

		public Func<int> AndVusk9e6t;

		public _G_c__DisplayClass3_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal int fK4VuSSq2sG()
		{
			return vhoVutjxFsc.Count;
		}

		internal string jAbVuwGU5F4()
		{
			return iUYVuL0KBFm.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass4_0
	{
		public string Ai0VuNvsdOk;

		public string hoIVumAoPTa;

		public int i00VuoRDxHB;

		public int zqpVuGBMiia;

		public int Kt0VuCSfkUD;

		public bool jXVVup6LQdh;

		public bool ECVVuOlhpGG;

		public _G_c__DisplayClass4_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU N1CVulNfYof(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			Workbook workbook = yFgJROsdyk(app, scope, Ai0VuNvsdOk);
			Worksheet worksheet = nhKJVrFKUP(app, workbook, scope, hoIVumAoPTa);
			Microsoft.Office.Interop.Excel.Range range = scope.eKvV6uFJpGF(worksheet.UsedRange);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Spreadsheet sheet preview prepared.", w5bJ6d8hYp(workbook, worksheet, range, "UsedRange", i00VuoRDxHB, zqpVuGBMiia, Kt0VuCSfkUD, false, jXVVup6LQdh, ECVVuOlhpGG, scope));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass5_0
	{
		public string vw5Vu7gFWG8;

		public string hyUVu5N6iji;

		public string T88VucH6ZmS;

		public int tfHVueraXKO;

		public int QHvVuy8GSJG;

		public int mwJVuX7Ymgi;

		public bool aPbVuFFmHHA;

		public bool x8LVuhPui3M;

		public bool cCPVuaUQwRs;

		public _G_c__DisplayClass5_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU mT5Vunm0jMn(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			Workbook workbook = yFgJROsdyk(app, scope, vw5Vu7gFWG8);
			qqRJBchH8m(app, workbook, scope, hyUVu5N6iji, T88VucH6ZmS, out var worksheet, out var range, out var text);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Spreadsheet range preview prepared.", w5bJ6d8hYp(workbook, worksheet, range, text, tfHVueraXKO, QHvVuy8GSJG, mwJVuX7Ymgi, aPbVuFFmHHA, x8LVuhPui3M, cCPVuaUQwRs, scope));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass6_0
	{
		public string cR4VuPnFnfp;

		public string HTsVuAiAaQk;

		public string ed5VuvmAfsi;

		public bool tANVuWCfBa3;

		public _G_c__DisplayClass6_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU wdcVuq4QmYP(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			if (string.IsNullOrWhiteSpace(cR4VuPnFnfp))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("address must not be empty.", "invalid_arguments");
			}
			Workbook workbook = yFgJROsdyk(app, scope, HTsVuAiAaQk);
			qqRJBchH8m(app, workbook, scope, ed5VuvmAfsi, cR4VuPnFnfp, out var worksheet, out var range, out var text);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m(tANVuWCfBa3 ? "Range values and formulas retrieved." : "Visible range values and formulas retrieved.", ybqJuWfEtN(workbook, worksheet, range, text, tANVuWCfBa3, true, false, scope));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass8_0
	{
		public string iuWVukLgGoV;

		public string jmyVuxJ74ES;

		public string usJVudwJBJr;

		public bool HpxVuzsk4xt;

		public _G_c__DisplayClass8_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU VJJVu0Tur8G(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			if (string.IsNullOrEmpty(iuWVukLgGoV))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("searchValue must not be empty.", "invalid_arguments");
			}
			Workbook workbook = yFgJROsdyk(app, scope, jmyVuxJ74ES);
			Worksheet worksheet = nhKJVrFKUP(app, workbook, scope, usJVudwJBJr);
			Microsoft.Office.Interop.Excel.Range range = scope.eKvV6uFJpGF(worksheet.UsedRange);
			List<object> list = new List<object>();
			string text;
			bool flag = h8CJTM4gse(worksheet, range, iuWVukLgGoV, HpxVuzsk4xt, scope, list, out text);
			string searchMethod = "excel_range_find";
			if (!flag)
			{
				list = UtOJgG2Q1H(worksheet, range, iuWVukLgGoV, HpxVuzsk4xt, scope);
				searchMethod = "value2_array_scan";
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Spreadsheet cell find completed.", new
			{
				workbook = workbook.Name,
				worksheet = worksheet.Name,
				searchValue = iuWVukLgGoV,
				matchCase = HpxVuzsk4xt,
				searchMethod = searchMethod,
				nativeFindError = (flag ? null : text),
				returned = list.Count,
				truncated = (list.Count >= 50),
				matches = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass9_0
	{
		public string ELRVDVADLlW;

		public string kWOVDBeqpDL;

		public string t21VD9iumWB;

		public string UT6VD6A2EYk;

		public _G_c__DisplayClass9_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal rU18qH9owXvBsPZ0iiU CLTVDRfTkNP(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			_G_c__DisplayClass9_1 CS_8_locals_15 = new _G_c__DisplayClass9_1();
			if (!string.Equals(string.IsNullOrWhiteSpace(ELRVDVADLlW) ? "get" : ELRVDVADLlW.Trim().ToLowerInvariant(), "get", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("WordRe 中 manage_excel_named_range 只支持 action=get，不创建或更新名称区域。", "invalid_arguments", new
				{
					action = ELRVDVADLlW
				});
			}
			if (string.IsNullOrWhiteSpace(kWOVDBeqpDL))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("name must not be empty.", "invalid_arguments");
			}
			Workbook workbook = yFgJROsdyk(app, scope, t21VD9iumWB);
			CS_8_locals_15.nA1VD8sEAwo = FLbJHX5Yf0(workbook, scope, kWOVDBeqpDL, UT6VD6A2EYk);
			if (CS_8_locals_15.nA1VD8sEAwo == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("未找到指定名称区域。", "not_found", new
				{
					workbook = workbook.Name,
					name = kWOVDBeqpDL,
					nameScope = UT6VD6A2EYk
				});
			}
			CS_8_locals_15.I0WVDIhUTqI = null;
			try
			{
				CS_8_locals_15.I0WVDIhUTqI = scope.eKvV6uFJpGF(CS_8_locals_15.nA1VD8sEAwo.RefersToRange);
			}
			catch
			{
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("Named range retrieved.", new
			{
				workbook = workbook.Name,
				name = CS_8_locals_15.nA1VD8sEAwo.Name,
				nameScope = (string.IsNullOrWhiteSpace(UT6VD6A2EYk) ? "workbook_or_worksheet" : UT6VD6A2EYk),
				refersTo = hjGJjwaZBM(() => (dynamic)CS_8_locals_15.nA1VD8sEAwo.RefersTo),
				worksheet = ((CS_8_locals_15.I0WVDIhUTqI == null) ? null : hjGJjwaZBM(() => CS_8_locals_15.I0WVDIhUTqI.Worksheet.Name)),
				address = ((CS_8_locals_15.I0WVDIhUTqI == null) ? null : tqdJKIVpyV(CS_8_locals_15.I0WVDIhUTqI)),
				rows = ((CS_8_locals_15.I0WVDIhUTqI != null) ? pCPJ2o3f45(() => CS_8_locals_15.I0WVDIhUTqI.Rows.Count) : 0),
				columns = ((CS_8_locals_15.I0WVDIhUTqI != null) ? pCPJ2o3f45(() => CS_8_locals_15.I0WVDIhUTqI.Columns.Count) : 0)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass9_1
	{
		public Name nA1VD8sEAwo;

		public Microsoft.Office.Interop.Excel.Range I0WVDIhUTqI;

		public _G_c__DisplayClass9_1()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string U77VDuR5bqs()
		{
			return (dynamic)nA1VD8sEAwo.RefersTo;
		}

		internal string pSlVDDIlX8P()
		{
			return I0WVDIhUTqI.Worksheet.Name;
		}

		internal int aoEVDT7gUtL()
		{
			return I0WVDIhUTqI.Rows.Count;
		}

		internal int fZfVDgh83Co()
		{
			return I0WVDIhUTqI.Columns.Count;
		}
	}

	[CompilerGenerated]
	private static class _G_o__16
	{
		public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> dVuVDQARv7G;

		public static CallSite<Func<CallSite, object, bool>> taZVD1sV05l;

		public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> w5RVDr8YTTN;

		public static CallSite<Func<CallSite, object, object, object>> YPpVDJlGjdi;

		public static CallSite<Func<CallSite, object, bool>> qo8VD3PAjJB;

		public static CallSite<Func<CallSite, object, object>> KEgVDU5cs3b;

		public static CallSite<Func<CallSite, object, string>> J6XVDKpOnkx;

		public static CallSite<Func<CallSite, object, object, object>> WEcVDE1MFUf;

		public static CallSite<Func<CallSite, object, bool>> vVHVD2eZGRN;

		public static CallSite<Func<CallSite, object, object>> yglVD4Gxfsw;

		public static CallSite<Func<CallSite, object, string>> JvGVDjysrV0;

		public static CallSite<Func<CallSite, object, bool>> F08VDYngDwS;

		public static CallSite<Func<CallSite, object, object, object>> EclVDZaZqNp;

		public static CallSite<Func<CallSite, object, bool>> TTNVDfyPZJC;

		public static CallSite<Func<CallSite, object, object>> uZHVDMnQAFH;

		public static CallSite<Func<CallSite, object, string>> AjeVDblBN5S;
	}

	[CompilerGenerated]
	private static class _G_o__20
	{
		public static CallSite<Func<CallSite, object, object, object>> zmBVDLh7uRn;

		public static CallSite<Func<CallSite, object, bool>> cyfVDs3vBxt;

		public static CallSite<Func<CallSite, object, object>> a3AVDlVXcmE;

		public static CallSite<Func<CallSite, object, string>> gGJVDNdg0mJ;
	}

	[CompilerGenerated]
	private static class _G_o__29
	{
		public static CallSite<Func<CallSite, object, object, object>> h24VDomgeZo;

		public static CallSite<Func<CallSite, object, bool>> IJ3VDGwBYUT;

		public static CallSite<Func<CallSite, object, object>> LRuVDC0PlSQ;

		public static CallSite<Func<CallSite, object, string>> yWmVDpjviMN;
	}

	public rU18qH9owXvBsPZ0iiU H1trPxTugZ()
	{
		return oaarzjrmjs("get_current_excel_context", delegate(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			_G_c__DisplayClass1_0 CS_8_locals_10 = new _G_c__DisplayClass1_0();
			CS_8_locals_10.gkiV6hLLvMu = yFgJROsdyk(app, scope, string.Empty);
			Worksheet worksheet = scope.eKvV6uFJpGF(app.ActiveSheet as Worksheet);
			CS_8_locals_10.Uy3V6aJaiSk = scope.eKvV6uFJpGF(app.Selection as Microsoft.Office.Interop.Excel.Range);
			if (worksheet == null && CS_8_locals_10.Uy3V6aJaiSk != null)
			{
				worksheet = scope.eKvV6uFJpGF(CS_8_locals_10.Uy3V6aJaiSk.Worksheet);
			}
			return (worksheet == null) ? rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("get_current_excel_context", "list_open_excel_workbooks") : rU18qH9owXvBsPZ0iiU.nt99CvEC4m("get_excel_sheet_list", new
			{
				host = i0rJZwDpdH(),
				workbook = CS_8_locals_10.gkiV6hLLvMu.Name,
				workbookFullName = hjGJjwaZBM(() => CS_8_locals_10.gkiV6hLLvMu.FullName),
				worksheet = worksheet.Name,
				selection = ((CS_8_locals_10.Uy3V6aJaiSk == null) ? null : new
				{
					address = tqdJKIVpyV(CS_8_locals_10.Uy3V6aJaiSk),
					rows = pCPJ2o3f45(() => CS_8_locals_10.Uy3V6aJaiSk.Rows.Count),
					columns = pCPJ2o3f45(() => CS_8_locals_10.Uy3V6aJaiSk.Columns.Count)
				})
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU dE6rAOoIGx()
	{
		return oaarzjrmjs("list_open_excel_workbooks", delegate(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			_G_c__DisplayClass2_0 CS_8_locals_8 = new _G_c__DisplayClass2_0();
			CS_8_locals_8.bDFVuJ7xY4x = scope.eKvV6uFJpGF(app.Workbooks);
			CS_8_locals_8.zmaVurdydP4 = scope.eKvV6uFJpGF(app.ActiveWorkbook);
			string text = ((CS_8_locals_8.zmaVurdydP4 == null) ? null : hjGJjwaZBM(() => CS_8_locals_8.zmaVurdydP4.Name));
			List<object> list = new List<object>();
			for (int num = 1; num <= pCPJ2o3f45(() => CS_8_locals_8.bDFVuJ7xY4x.Count); num++)
			{
				_G_c__DisplayClass2_1 CS_8_locals_14 = new _G_c__DisplayClass2_1();
				CS_8_locals_14.HitVuYWWWDt = scope.eKvV6uFJpGF(CS_8_locals_8.bDFVuJ7xY4x[num]);
				string text2 = hjGJjwaZBM(() => CS_8_locals_14.HitVuYWWWDt.Name);
				string fullName = hjGJjwaZBM(() => CS_8_locals_14.HitVuYWWWDt.FullName);
				list.Add(new
				{
					index = num,
					name = text2,
					fullName = fullName,
					path = hjGJjwaZBM(() => CS_8_locals_14.HitVuYWWWDt.Path),
					isActive = string.Equals(text2, text, StringComparison.OrdinalIgnoreCase),
					readOnly = IVrJ4G8MCE(() => CS_8_locals_14.HitVuYWWWDt.ReadOnly),
					saved = IVrJ4G8MCE(() => CS_8_locals_14.HitVuYWWWDt.Saved),
					sheetCount = pCPJ2o3f45(() => CS_8_locals_14.HitVuYWWWDt.Worksheets.Count)
				});
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("preview_excel_sheet", new
			{
				host = i0rJZwDpdH(),
				count = list.Count,
				activeWorkbook = text,
				workbooks = list
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU vgirvnM1Fs(string P_0)
	{
		_G_c__DisplayClass3_0 CS_8_locals_4 = new _G_c__DisplayClass3_0();
		CS_8_locals_4.AhDVubjV0nx = P_0;
		return oaarzjrmjs("get_excel_sheet_list", delegate(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			_G_c__DisplayClass3_1 CS_8_locals_10 = new _G_c__DisplayClass3_1();
			CS_8_locals_10.iUYVuL0KBFm = yFgJROsdyk(app, scope, CS_8_locals_4.AhDVubjV0nx);
			CS_8_locals_10.vhoVutjxFsc = scope.eKvV6uFJpGF(CS_8_locals_10.iUYVuL0KBFm.Worksheets);
			List<object> list = new List<object>();
			for (int i = 1; i <= pCPJ2o3f45(() => CS_8_locals_10.vhoVutjxFsc.Count); i++)
			{
				Worksheet worksheet = scope.eKvV6uFJpGF((Worksheet)(dynamic)CS_8_locals_10.vhoVutjxFsc[i]);
				list.Add(new
				{
					index = i,
					name = worksheet.Name
				});
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("preview_excel_range", new
			{
				workbook = CS_8_locals_10.iUYVuL0KBFm.Name,
				workbookFullName = hjGJjwaZBM(() => CS_8_locals_10.iUYVuL0KBFm.FullName),
				count = list.Count,
				sheets = list
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU dhorWDIpcu(string P_0, string P_1, int P_2, int P_3, int P_4, bool P_5, bool P_6)
	{
		_G_c__DisplayClass4_0 CS_8_locals_14 = new _G_c__DisplayClass4_0();
		CS_8_locals_14.Ai0VuNvsdOk = P_1;
		CS_8_locals_14.hoIVumAoPTa = P_0;
		CS_8_locals_14.i00VuoRDxHB = P_2;
		CS_8_locals_14.zqpVuGBMiia = P_3;
		CS_8_locals_14.Kt0VuCSfkUD = P_4;
		CS_8_locals_14.jXVVup6LQdh = P_5;
		CS_8_locals_14.ECVVuOlhpGG = P_6;
		return oaarzjrmjs("preview_excel_sheet", delegate(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			Workbook workbook = yFgJROsdyk(app, scope, CS_8_locals_14.Ai0VuNvsdOk);
			Worksheet worksheet = nhKJVrFKUP(app, workbook, scope, CS_8_locals_14.hoIVumAoPTa);
			Microsoft.Office.Interop.Excel.Range range = scope.eKvV6uFJpGF(worksheet.UsedRange);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("get_excel_range_values_and_formulas", w5bJ6d8hYp(workbook, worksheet, range, "get_current_selection_values_and_formulas", CS_8_locals_14.i00VuoRDxHB, CS_8_locals_14.zqpVuGBMiia, CS_8_locals_14.Kt0VuCSfkUD, false, CS_8_locals_14.jXVVup6LQdh, CS_8_locals_14.ECVVuOlhpGG, scope));
		});
	}

	public rU18qH9owXvBsPZ0iiU kDNr0R99Bs(string P_0, string P_1, string P_2, int P_3, int P_4, int P_5, bool P_6, bool P_7, bool P_8)
	{
		_G_c__DisplayClass5_0 CS_8_locals_18 = new _G_c__DisplayClass5_0();
		CS_8_locals_18.vw5Vu7gFWG8 = P_2;
		CS_8_locals_18.hyUVu5N6iji = P_0;
		CS_8_locals_18.T88VucH6ZmS = P_1;
		CS_8_locals_18.tfHVueraXKO = P_3;
		CS_8_locals_18.QHvVuy8GSJG = P_4;
		CS_8_locals_18.mwJVuX7Ymgi = P_5;
		CS_8_locals_18.aPbVuFFmHHA = P_6;
		CS_8_locals_18.x8LVuhPui3M = P_7;
		CS_8_locals_18.cCPVuaUQwRs = P_8;
		return oaarzjrmjs("preview_excel_range", delegate(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			Workbook workbook = yFgJROsdyk(app, scope, CS_8_locals_18.vw5Vu7gFWG8);
			qqRJBchH8m(app, workbook, scope, CS_8_locals_18.hyUVu5N6iji, CS_8_locals_18.T88VucH6ZmS, out var worksheet, out var range, out var text);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("find_excel_cells", w5bJ6d8hYp(workbook, worksheet, range, text, CS_8_locals_18.tfHVueraXKO, CS_8_locals_18.QHvVuy8GSJG, CS_8_locals_18.mwJVuX7Ymgi, CS_8_locals_18.aPbVuFFmHHA, CS_8_locals_18.x8LVuhPui3M, CS_8_locals_18.cCPVuaUQwRs, scope));
		});
	}

	public rU18qH9owXvBsPZ0iiU XY6rk05nUf(string P_0, string P_1, string P_2, bool P_3)
	{
		_G_c__DisplayClass6_0 CS_8_locals_10 = new _G_c__DisplayClass6_0();
		CS_8_locals_10.cR4VuPnFnfp = P_1;
		CS_8_locals_10.HTsVuAiAaQk = P_2;
		CS_8_locals_10.ed5VuvmAfsi = P_0;
		CS_8_locals_10.tANVuWCfBa3 = P_3;
		return oaarzjrmjs("get_excel_range_values_and_formulas", delegate(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			if (string.IsNullOrWhiteSpace(CS_8_locals_10.cR4VuPnFnfp))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("manage_excel_named_range", " failed");
			}
			Workbook workbook = yFgJROsdyk(app, scope, CS_8_locals_10.HTsVuAiAaQk);
			qqRJBchH8m(app, workbook, scope, CS_8_locals_10.ed5VuvmAfsi, CS_8_locals_10.cR4VuPnFnfp, out var worksheet, out var range, out var text);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m(CS_8_locals_10.tANVuWCfBa3 ? "spreadsheet_error" : "Unknown spreadsheet error.", ybqJuWfEtN(workbook, worksheet, range, text, CS_8_locals_10.tANVuWCfBa3, true, false, scope));
		});
	}

	public rU18qH9owXvBsPZ0iiU GetCurrentSelectionValuesAndFormulas()
	{
		return oaarzjrmjs("get_current_selection_values_and_formulas", delegate(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			Workbook workbook = yFgJROsdyk(app, scope, string.Empty);
			Microsoft.Office.Interop.Excel.Range range = scope.eKvV6uFJpGF(app.Selection as Microsoft.Office.Interop.Excel.Range);
			if (range == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("当前没有打开的工作簿。", "no_workbook");
			}
			Worksheet worksheet = scope.eKvV6uFJpGF(range.Worksheet);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("当前没有活动工作簿。", ybqJuWfEtN(workbook, worksheet, range, tqdJKIVpyV(range), false, true, false, scope));
		});
	}

	public rU18qH9owXvBsPZ0iiU kpSrxrdvDy(string P_0, string P_1, bool P_2, string P_3)
	{
		_G_c__DisplayClass8_0 CS_8_locals_13 = new _G_c__DisplayClass8_0();
		CS_8_locals_13.iuWVukLgGoV = P_1;
		CS_8_locals_13.jmyVuxJ74ES = P_3;
		CS_8_locals_13.usJVudwJBJr = P_0;
		CS_8_locals_13.HpxVuzsk4xt = P_2;
		return oaarzjrmjs("find_excel_cells", delegate(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			if (string.IsNullOrEmpty(CS_8_locals_13.iuWVukLgGoV))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("no_workbook", "未找到指定工作簿。");
			}
			Workbook workbook = yFgJROsdyk(app, scope, CS_8_locals_13.jmyVuxJ74ES);
			Worksheet worksheet = nhKJVrFKUP(app, workbook, scope, CS_8_locals_13.usJVudwJBJr);
			Microsoft.Office.Interop.Excel.Range range = scope.eKvV6uFJpGF(worksheet.UsedRange);
			List<object> list = new List<object>();
			string text;
			bool flag = h8CJTM4gse(worksheet, range, CS_8_locals_13.iuWVukLgGoV, CS_8_locals_13.HpxVuzsk4xt, scope, list, out text);
			string searchMethod = "workbook_not_found";
			if (!flag)
			{
				list = UtOJgG2Q1H(worksheet, range, CS_8_locals_13.iuWVukLgGoV, CS_8_locals_13.HpxVuzsk4xt, scope);
				searchMethod = "当前没有打开的工作簿。";
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("no_workbook", new
			{
				workbook = workbook.Name,
				worksheet = worksheet.Name,
				searchValue = CS_8_locals_13.iuWVukLgGoV,
				matchCase = CS_8_locals_13.HpxVuzsk4xt,
				searchMethod = searchMethod,
				nativeFindError = (flag ? null : text),
				returned = list.Count,
				truncated = (list.Count >= 50),
				matches = list
			});
		});
	}

	public rU18qH9owXvBsPZ0iiU nCmrdMSTjR(string P_0, string P_1, string P_2, string P_3)
	{
		_G_c__DisplayClass9_0 CS_8_locals_22 = new _G_c__DisplayClass9_0();
		CS_8_locals_22.ELRVDVADLlW = P_0;
		CS_8_locals_22.kWOVDBeqpDL = P_1;
		CS_8_locals_22.t21VD9iumWB = P_2;
		CS_8_locals_22.UT6VD6A2EYk = P_3;
		return oaarzjrmjs("manage_excel_named_range", delegate(Application app, XFNayjV66fonCSKcSbOJ scope)
		{
			_G_c__DisplayClass9_1 CS_8_locals_31 = new _G_c__DisplayClass9_1();
			if (!string.Equals(string.IsNullOrWhiteSpace(CS_8_locals_22.ELRVDVADLlW) ? "未找到指定工作表。" : CS_8_locals_22.ELRVDVADLlW.Trim().ToLowerInvariant(), "worksheet_not_found", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("!", "!", new
				{
					action = CS_8_locals_22.ELRVDVADLlW
				});
			}
			if (string.IsNullOrWhiteSpace(CS_8_locals_22.kWOVDBeqpDL))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("!UsedRange", "当前 Excel/WPS 表格选区不是可读取区域。");
			}
			Workbook workbook = yFgJROsdyk(app, scope, CS_8_locals_22.t21VD9iumWB);
			CS_8_locals_31.nA1VD8sEAwo = FLbJHX5Yf0(workbook, scope, CS_8_locals_22.kWOVDBeqpDL, CS_8_locals_22.UT6VD6A2EYk);
			if (CS_8_locals_31.nA1VD8sEAwo == null)
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("empty_selection", "!", new
				{
					workbook = workbook.Name,
					name = CS_8_locals_22.kWOVDBeqpDL,
					nameScope = CS_8_locals_22.UT6VD6A2EYk
				});
			}
			CS_8_locals_31.I0WVDIhUTqI = null;
			try
			{
				CS_8_locals_31.I0WVDIhUTqI = scope.eKvV6uFJpGF(CS_8_locals_31.nA1VD8sEAwo.RefersToRange);
			}
			catch
			{
			}
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("当前没有活动工作表。", new
			{
				workbook = workbook.Name,
				name = CS_8_locals_31.nA1VD8sEAwo.Name,
				nameScope = (string.IsNullOrWhiteSpace(CS_8_locals_22.UT6VD6A2EYk) ? "no_worksheet" : CS_8_locals_22.UT6VD6A2EYk),
				refersTo = hjGJjwaZBM(() => (dynamic)CS_8_locals_31.nA1VD8sEAwo.RefersTo),
				worksheet = ((CS_8_locals_31.I0WVDIhUTqI == null) ? null : hjGJjwaZBM(() => CS_8_locals_31.I0WVDIhUTqI.Worksheet.Name)),
				address = ((CS_8_locals_31.I0WVDIhUTqI == null) ? null : tqdJKIVpyV(CS_8_locals_31.I0WVDIhUTqI)),
				rows = ((CS_8_locals_31.I0WVDIhUTqI != null) ? pCPJ2o3f45(() => CS_8_locals_31.I0WVDIhUTqI.Rows.Count) : 0),
				columns = ((CS_8_locals_31.I0WVDIhUTqI != null) ? pCPJ2o3f45(() => CS_8_locals_31.I0WVDIhUTqI.Columns.Count) : 0)
			});
		});
	}

	private static rU18qH9owXvBsPZ0iiU oaarzjrmjs(string P_0, Func<Application, XFNayjV66fonCSKcSbOJ, rU18qH9owXvBsPZ0iiU> P_1)
	{
		_G_c__DisplayClass10_0 CS_8_locals_22 = new _G_c__DisplayClass10_0();
		CS_8_locals_22.tNlV6Uc69Ov = P_0;
		CS_8_locals_22.ALPV6KJXDoZ = P_1;
		CS_8_locals_22.HxcV63kMOK7 = null;
		CS_8_locals_22.S0RV6EnSD9i = null;
		Thread thread = new Thread((ThreadStart)delegate
		{
			Application application = null;
			XFNayjV66fonCSKcSbOJ xFNayjV66fonCSKcSbOJ = new XFNayjV66fonCSKcSbOJ();
			try
			{
				application = xcAKcictyYcoMl6ObA.X11yRCCGO();
				if (application == null)
				{
					CS_8_locals_22.HxcV63kMOK7 = rU18qH9owXvBsPZ0iiU.QSD9OKWs4n(" failed" + i0rJZwDpdH() + "spreadsheet_error", "Unknown spreadsheet error.", new
					{
						host = i0rJZwDpdH()
					});
				}
				else
				{
					yR9thasHZ73xXm8eKwj.swCsJ4IbrL("address must not be empty." + CS_8_locals_22.tNlV6Uc69Ov);
					CS_8_locals_22.HxcV63kMOK7 = CS_8_locals_22.ALPV6KJXDoZ(application, xFNayjV66fonCSKcSbOJ);
					yR9thasHZ73xXm8eKwj.swCsJ4IbrL("invalid_arguments" + CS_8_locals_22.tNlV6Uc69Ov + "区域地址无效：" + (CS_8_locals_22.HxcV63kMOK7 != null && CS_8_locals_22.HxcV63kMOK7.success));
				}
			}
			catch (COMException ex)
			{
				yR9thasHZ73xXm8eKwj.ujWsURly3F("invalid_arguments" + CS_8_locals_22.tNlV6Uc69Ov + ": ", ex);
				CS_8_locals_22.HxcV63kMOK7 = rU18qH9owXvBsPZ0iiU.g7A9nYlk8v(CS_8_locals_22.tNlV6Uc69Ov + ":", "yyyy-MM-dd HH:mm:ss", ex);
			}
			catch (onEqFoV6VqxGOBHbQtJW onEqFoV6VqxGOBHbQtJW2)
			{
				yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("workbook_or_worksheet" + CS_8_locals_22.tNlV6Uc69Ov + "workbook" + onEqFoV6VqxGOBHbQtJW2.Message);
				CS_8_locals_22.HxcV63kMOK7 = rU18qH9owXvBsPZ0iiU.QSD9OKWs4n(onEqFoV6VqxGOBHbQtJW2.Message, onEqFoV6VqxGOBHbQtJW2.Code, onEqFoV6VqxGOBHbQtJW2.DataObject);
			}
			catch (Exception ex2)
			{
				yR9thasHZ73xXm8eKwj.ujWsURly3F("workbook_or_worksheet" + CS_8_locals_22.tNlV6Uc69Ov + "worksheet", ex2);
				CS_8_locals_22.S0RV6EnSD9i = ex2;
			}
			finally
			{
				xFNayjV66fonCSKcSbOJ.Dispose();
				if (application != null && Marshal.IsComObject(application))
				{
					try
					{
						Marshal.ReleaseComObject(application);
					}
					catch
					{
					}
				}
			}
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
		if (CS_8_locals_22.HxcV63kMOK7 != null)
		{
			return CS_8_locals_22.HxcV63kMOK7;
		}
		return rU18qH9owXvBsPZ0iiU.g7A9nYlk8v(CS_8_locals_22.tNlV6Uc69Ov + "workbook_or_worksheet", "'", CS_8_locals_22.S0RV6EnSD9i ?? new InvalidOperationException("'"));
	}

	private static Workbook yFgJROsdyk(Application P_0, XFNayjV66fonCSKcSbOJ P_1, string P_2)
	{
		_G_c__DisplayClass11_0 CS_8_locals_4 = new _G_c__DisplayClass11_0();
		CS_8_locals_4.CpKV6jX7XS8 = P_1.eKvV6uFJpGF(P_0.Workbooks);
		if (pCPJ2o3f45(() => CS_8_locals_4.CpKV6jX7XS8.Count) <= 0)
		{
			throw new onEqFoV6VqxGOBHbQtJW("当前没有打开的工作簿。", "no_workbook");
		}
		if (string.IsNullOrWhiteSpace(P_2))
		{
			return P_1.eKvV6uFJpGF(P_0.ActiveWorkbook) ?? throw new onEqFoV6VqxGOBHbQtJW("当前没有活动工作簿。", "no_workbook");
		}
		for (int num = 1; num <= pCPJ2o3f45(() => CS_8_locals_4.CpKV6jX7XS8.Count); num++)
		{
			Workbook workbook = P_1.eKvV6uFJpGF(CS_8_locals_4.CpKV6jX7XS8[num]);
			if (skJJrNGIkj(workbook, P_2))
			{
				return workbook;
			}
		}
		throw new onEqFoV6VqxGOBHbQtJW("未找到指定工作簿。", "workbook_not_found", new
		{
			workbookName = P_2
		});
	}

	private static Worksheet nhKJVrFKUP(Application P_0, Workbook P_1, XFNayjV66fonCSKcSbOJ P_2, string P_3)
	{
		_G_c__DisplayClass12_0 CS_8_locals_3 = new _G_c__DisplayClass12_0();
		if (P_1 == null)
		{
			throw new onEqFoV6VqxGOBHbQtJW("当前没有打开的工作簿。", "no_workbook");
		}
		if (string.IsNullOrWhiteSpace(P_3))
		{
			Worksheet worksheet = P_2.eKvV6uFJpGF(P_0.ActiveSheet as Worksheet);
			if (worksheet != null && u1VJJFd45C(worksheet, P_1))
			{
				return worksheet;
			}
			return P_2.eKvV6uFJpGF((Worksheet)(dynamic)P_1.Worksheets[1]);
		}
		CS_8_locals_3.IECV6f5YUIC = P_2.eKvV6uFJpGF(P_1.Worksheets);
		for (int i = 1; i <= pCPJ2o3f45(() => CS_8_locals_3.IECV6f5YUIC.Count); i++)
		{
			Worksheet worksheet2 = P_2.eKvV6uFJpGF((Worksheet)(dynamic)CS_8_locals_3.IECV6f5YUIC[i]);
			if (string.Equals(worksheet2.Name, P_3, StringComparison.OrdinalIgnoreCase))
			{
				return worksheet2;
			}
		}
		throw new onEqFoV6VqxGOBHbQtJW("未找到指定工作表。", "worksheet_not_found", new
		{
			workbook = P_1.Name,
			sheetName = P_3
		});
	}

	private static void qqRJBchH8m(Application P_0, Workbook P_1, XFNayjV66fonCSKcSbOJ P_2, string P_3, string P_4, out Worksheet P_5, out Microsoft.Office.Interop.Excel.Range P_6, out string P_7)
	{
		if (Ld5J1HvxtL(P_4, out var text, out var text2))
		{
			P_5 = nhKJVrFKUP(P_0, P_1, P_2, text);
			P_6 = IQ0J9JwFS4(P_5, P_2, text2);
			P_7 = P_5.Name + "!" + text2;
			return;
		}
		if (!string.IsNullOrWhiteSpace(P_4))
		{
			P_5 = nhKJVrFKUP(P_0, P_1, P_2, P_3);
			P_6 = IQ0J9JwFS4(P_5, P_2, P_4);
			P_7 = P_5.Name + "!" + P_4;
			return;
		}
		if (!string.IsNullOrWhiteSpace(P_3))
		{
			P_5 = nhKJVrFKUP(P_0, P_1, P_2, P_3);
			P_6 = P_2.eKvV6uFJpGF(P_5.UsedRange);
			P_7 = P_5.Name + "!UsedRange";
			return;
		}
		P_6 = P_2.eKvV6uFJpGF(P_0.Selection as Microsoft.Office.Interop.Excel.Range);
		if (P_6 == null)
		{
			throw new onEqFoV6VqxGOBHbQtJW("当前 Excel/WPS 表格选区不是可读取区域。", "empty_selection");
		}
		P_5 = P_2.eKvV6uFJpGF(P_6.Worksheet);
		P_7 = P_5.Name + "!" + tqdJKIVpyV(P_6);
	}

	private static Microsoft.Office.Interop.Excel.Range IQ0J9JwFS4(Worksheet P_0, XFNayjV66fonCSKcSbOJ P_1, string P_2)
	{
		if (P_0 == null)
		{
			throw new onEqFoV6VqxGOBHbQtJW("当前没有活动工作表。", "no_worksheet");
		}
		if (string.IsNullOrWhiteSpace(P_2))
		{
			throw new onEqFoV6VqxGOBHbQtJW("address must not be empty.", "invalid_arguments");
		}
		try
		{
			return P_1.eKvV6uFJpGF(((_Worksheet)P_0).get_Range((object)P_2, Type.Missing));
		}
		catch (Exception ex)
		{
			throw new onEqFoV6VqxGOBHbQtJW("区域地址无效：" + P_2, "invalid_arguments", new
			{
				address = P_2,
				exception = ex.GetType().Name
			});
		}
	}

	private static object w5bJ6d8hYp(Workbook P_0, Worksheet P_1, Microsoft.Office.Interop.Excel.Range P_2, string P_3, int P_4, int P_5, int P_6, bool P_7, bool P_8, bool P_9, XFNayjV66fonCSKcSbOJ P_10)
	{
		return ybqJuWfEtN(P_0, P_1, P_2, P_3, P_7, P_8, P_9, P_10, P_4, P_5, P_6);
	}

	private static object ybqJuWfEtN(Workbook P_0, Worksheet P_1, Microsoft.Office.Interop.Excel.Range P_2, string P_3, bool P_4, bool P_5, bool P_6, XFNayjV66fonCSKcSbOJ P_7, int P_8 = 0, int P_9 = 0, int P_10 = 0)
	{
		_G_c__DisplayClass16_0 CS_8_locals_19 = new _G_c__DisplayClass16_0();
		CS_8_locals_19.agZV6tbacUb = P_2;
		CS_8_locals_19.XkPV6LkxPkZ = P_0;
		int num = pCPJ2o3f45(() => CS_8_locals_19.agZV6tbacUb.Rows.Count);
		int num2 = pCPJ2o3f45(() => CS_8_locals_19.agZV6tbacUb.Columns.Count);
		int num3 = ((P_10 > 0) ? Math.Min(num2, Math.Max(1, P_10)) : num2);
		List<object> list = new List<object>();
		List<int> list2 = UnfJDvu7GV(num, P_8, P_9);
		if (list2.Count == 0)
		{
			for (int num4 = 1; num4 <= num; num4++)
			{
				list2.Add(num4);
			}
		}
		foreach (int item in list2)
		{
			if (P_4)
			{
				_G_c__DisplayClass16_1 obj = new _G_c__DisplayClass16_1();
				obj.fP3V6lZeaH2 = P_7.eKvV6uFJpGF((Microsoft.Office.Interop.Excel.Range)(dynamic)CS_8_locals_19.agZV6tbacUb.Rows[item, Type.Missing]);
				if (IVrJ4G8MCE(() => (dynamic)obj.fP3V6lZeaH2.Hidden))
				{
					continue;
				}
			}
			List<object> list3 = new List<object>();
			List<object> list4 = (P_5 ? new List<object>() : null);
			List<object> list5 = (P_6 ? new List<object>() : null);
			for (int num5 = 1; num5 <= num3; num5++)
			{
				_G_c__DisplayClass16_2 CS_8_locals_18 = new _G_c__DisplayClass16_2();
				CS_8_locals_18.pNlV6CBr7t1 = P_7.eKvV6uFJpGF((Microsoft.Office.Interop.Excel.Range)(dynamic)CS_8_locals_19.agZV6tbacUb.Cells[item, num5]);
				list3.Add(rNBJ3SlLVd(CS_8_locals_18.pNlV6CBr7t1));
				if (P_5)
				{
					list4.Add(hjGJjwaZBM(delegate
					{
						dynamic val;
						if (!(((dynamic)CS_8_locals_18.pNlV6CBr7t1.Formula == null) ? true : false))
						{
							if (_G_o__16.KEgVDU5cs3b == null)
							{
								_G_o__16.KEgVDU5cs3b = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "''", null, typeof(mWJD9kra0YySjgX6gSL), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							val = _G_o__16.KEgVDU5cs3b.Target(_G_o__16.KEgVDU5cs3b, CS_8_locals_18.pNlV6CBr7t1.Formula);
						}
						else
						{
							val = string.Empty;
						}
						return val;
					}));
				}
				if (!P_6)
				{
					continue;
				}
				list5.Add(new
				{
					numberFormat = hjGJjwaZBM(delegate
					{
						dynamic val;
						if (!(((dynamic)CS_8_locals_18.pNlV6CBr7t1.NumberFormat == null) ? true : false))
						{
							if (_G_o__16.yglVD4Gxfsw == null)
							{
								_G_o__16.yglVD4Gxfsw = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "'", null, typeof(mWJD9kra0YySjgX6gSL), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							val = _G_o__16.yglVD4Gxfsw.Target(_G_o__16.yglVD4Gxfsw, CS_8_locals_18.pNlV6CBr7t1.NumberFormat);
						}
						else
						{
							val = string.Empty;
						}
						return val;
					}),
					bold = IVrJ4G8MCE(() => (dynamic)CS_8_locals_18.pNlV6CBr7t1.Font.Bold),
					interiorColor = hjGJjwaZBM(delegate
					{
						dynamic val;
						if (!(((dynamic)CS_8_locals_18.pNlV6CBr7t1.Interior.Color == null) ? true : false))
						{
							if (_G_o__16.uZHVDMnQAFH == null)
							{
								_G_o__16.uZHVDMnQAFH = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "yyyy-MM-dd HH:mm:ss", null, typeof(mWJD9kra0YySjgX6gSL), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							val = _G_o__16.uZHVDMnQAFH.Target(_G_o__16.uZHVDMnQAFH, CS_8_locals_18.pNlV6CBr7t1.Interior.Color);
						}
						else
						{
							val = string.Empty;
						}
						return val;
					})
				});
			}
			list.Add(new
			{
				rowIndex = item,
				values = list3,
				formulas = list4,
				formats = list5
			});
		}
		return new
		{
			workbook = CS_8_locals_19.XkPV6LkxPkZ.Name,
			workbookFullName = hjGJjwaZBM(() => CS_8_locals_19.XkPV6LkxPkZ.FullName),
			worksheet = P_1.Name,
			requestedAddress = P_3,
			address = tqdJKIVpyV(CS_8_locals_19.agZV6tbacUb),
			rows = num,
			columns = num2,
			returnedRows = list.Count,
			returnedColumns = num3,
			truncated = (list.Count < num || num3 < num2),
			visibleOnly = P_4,
			includeFormulas = P_5,
			includeFormats = P_6,
			data = list
		};
	}

	private static List<int> UnfJDvu7GV(int P_0, int P_1, int P_2)
	{
		List<int> list = new List<int>();
		if (P_1 <= 0 && P_2 <= 0)
		{
			return list;
		}
		int num = Math.Min(P_0, Math.Max(0, P_1));
		for (int i = 1; i <= num; i++)
		{
			list.Add(i);
		}
		int num2 = Math.Min(P_0, Math.Max(0, P_2));
		for (int j = Math.Max(num + 1, P_0 - num2 + 1); j <= P_0; j++)
		{
			list.Add(j);
		}
		return list;
	}

	private static bool h8CJTM4gse(Worksheet P_0, Microsoft.Office.Interop.Excel.Range P_1, string P_2, bool P_3, XFNayjV66fonCSKcSbOJ P_4, List<object> P_5, out string P_6)
	{
		_G_c__DisplayClass18_0 CS_8_locals_6 = new _G_c__DisplayClass18_0();
		CS_8_locals_6.UxyV6nWori1 = P_1;
		P_6 = null;
		try
		{
			int num = pCPJ2o3f45(() => CS_8_locals_6.UxyV6nWori1.Rows.Count);
			int num2 = pCPJ2o3f45(() => CS_8_locals_6.UxyV6nWori1.Columns.Count);
			if (num <= 0 || num2 <= 0)
			{
				return true;
			}
			Microsoft.Office.Interop.Excel.Range after = P_4.eKvV6uFJpGF((Microsoft.Office.Interop.Excel.Range)(dynamic)CS_8_locals_6.UxyV6nWori1.Cells[num, num2]);
			Microsoft.Office.Interop.Excel.Range range = P_4.eKvV6uFJpGF(CS_8_locals_6.UxyV6nWori1.Find(P_2, after, XlFindLookIn.xlValues, XlLookAt.xlPart, XlSearchOrder.xlByRows, XlSearchDirection.xlNext, P_3, Type.Missing, Type.Missing));
			if (range == null)
			{
				return true;
			}
			string b = kn3JIaDIXo(range);
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			Microsoft.Office.Interop.Excel.Range range2 = range;
			while (range2 != null && P_5.Count < 50)
			{
				string text = kn3JIaDIXo(range2);
				if (string.IsNullOrEmpty(text) || !hashSet.Add(text))
				{
					break;
				}
				P_5.Add(LOhJ8PRsj6(P_0, range2));
				Microsoft.Office.Interop.Excel.Range range3 = P_4.eKvV6uFJpGF(CS_8_locals_6.UxyV6nWori1.FindNext(range2));
				if (range3 == null || string.Equals(kn3JIaDIXo(range3), b, StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				range2 = range3;
			}
			return true;
		}
		catch (Exception ex)
		{
			P_6 = ex.GetType().Name + ": " + ex.Message;
			return false;
		}
	}

	private static List<object> UtOJgG2Q1H(Worksheet P_0, Microsoft.Office.Interop.Excel.Range P_1, string P_2, bool P_3, XFNayjV66fonCSKcSbOJ P_4)
	{
		_G_c__DisplayClass19_0 CS_8_locals_5 = new _G_c__DisplayClass19_0();
		CS_8_locals_5.IrtV6e49vaj = P_1;
		List<object> list = new List<object>();
		StringComparison comparisonType = (P_3 ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
		object obj = lEYJYSoNMC(() => CS_8_locals_5.IrtV6e49vaj.Value2);
		int num = LgrJEVbBNo(() => CS_8_locals_5.IrtV6e49vaj.Row);
		int num2 = LgrJEVbBNo(() => CS_8_locals_5.IrtV6e49vaj.Column);
		if (obj is object[,] array)
		{
			int lowerBound = array.GetLowerBound(0);
			int upperBound = array.GetUpperBound(0);
			int lowerBound2 = array.GetLowerBound(1);
			int upperBound2 = array.GetUpperBound(1);
			for (int num3 = lowerBound; num3 <= upperBound; num3++)
			{
				if (list.Count >= 50)
				{
					break;
				}
				for (int num4 = lowerBound2; num4 <= upperBound2; num4++)
				{
					if (list.Count >= 50)
					{
						break;
					}
					if (DjOJiRNjpT(array[num3, num4]).IndexOf(P_2, comparisonType) >= 0)
					{
						int num5 = num + (num3 - lowerBound);
						int num6 = num2 + (num4 - lowerBound2);
						Microsoft.Office.Interop.Excel.Range range = P_4.eKvV6uFJpGF((Microsoft.Office.Interop.Excel.Range)(dynamic)P_0.Cells[num5, num6]);
						list.Add(LOhJ8PRsj6(P_0, range));
					}
				}
			}
			return list;
		}
		if (DjOJiRNjpT(obj).IndexOf(P_2, comparisonType) >= 0)
		{
			Microsoft.Office.Interop.Excel.Range range2 = P_4.eKvV6uFJpGF((Microsoft.Office.Interop.Excel.Range)(dynamic)CS_8_locals_5.IrtV6e49vaj.Cells[1, 1]);
			list.Add(LOhJ8PRsj6(P_0, range2));
		}
		return list;
	}

	private static object LOhJ8PRsj6(Worksheet P_0, Microsoft.Office.Interop.Excel.Range P_1)
	{
		_G_c__DisplayClass20_0 CS_8_locals_8 = new _G_c__DisplayClass20_0();
		CS_8_locals_8.JifV6vA3iT1 = P_1;
		return new
		{
			sheetName = P_0.Name,
			address = tqdJKIVpyV(CS_8_locals_8.JifV6vA3iT1),
			row = LgrJEVbBNo(() => CS_8_locals_8.JifV6vA3iT1.Row),
			column = LgrJEVbBNo(() => CS_8_locals_8.JifV6vA3iT1.Column),
			value = rNBJ3SlLVd(CS_8_locals_8.JifV6vA3iT1),
			text = mjyJUctF2A(CS_8_locals_8.JifV6vA3iT1),
			formula = hjGJjwaZBM(delegate
			{
				dynamic val;
				if (!(((dynamic)CS_8_locals_8.JifV6vA3iT1.Formula == null) ? true : false))
				{
					if (_G_o__20.a3AVDlVXcmE == null)
					{
						_G_o__20.a3AVDlVXcmE = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Excel", null, typeof(mWJD9kra0YySjgX6gSL), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					val = _G_o__20.a3AVDlVXcmE.Target(_G_o__20.a3AVDlVXcmE, CS_8_locals_8.JifV6vA3iT1.Formula);
				}
				else
				{
					val = string.Empty;
				}
				return val;
			})
		};
	}

	private static string kn3JIaDIXo(Microsoft.Office.Interop.Excel.Range P_0)
	{
		_G_c__DisplayClass21_0 CS_8_locals_3 = new _G_c__DisplayClass21_0();
		CS_8_locals_3.K2lV6kSYl1J = P_0;
		return LgrJEVbBNo(() => CS_8_locals_3.K2lV6kSYl1J.Row).ToString(CultureInfo.InvariantCulture) + ":" + LgrJEVbBNo(() => CS_8_locals_3.K2lV6kSYl1J.Column).ToString(CultureInfo.InvariantCulture);
	}

	private static string DjOJiRNjpT(object P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		if (P_0 is DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
		}
		return Convert.ToString(P_0, CultureInfo.InvariantCulture) ?? string.Empty;
	}

	private static Name FLbJHX5Yf0(Workbook P_0, XFNayjV66fonCSKcSbOJ P_1, string P_2, string P_3)
	{
		string text = (string.IsNullOrWhiteSpace(P_3) ? "workbook_or_worksheet" : P_3.Trim().ToLowerInvariant());
		if (text == "workbook" || text == "workbook_or_worksheet")
		{
			_G_c__DisplayClass23_0 CS_8_locals_9 = new _G_c__DisplayClass23_0();
			CS_8_locals_9.EsbV6djlCSO = P_1.eKvV6uFJpGF(P_0.Names);
			for (int i = 1; i <= pCPJ2o3f45(() => CS_8_locals_9.EsbV6djlCSO.Count); i++)
			{
				Name name = P_1.eKvV6uFJpGF(CS_8_locals_9.EsbV6djlCSO.Item(i, Type.Missing, Type.Missing));
				if (ObsJQvCckC(name, P_2))
				{
					return name;
				}
			}
		}
		if (text == "worksheet" || text == "workbook_or_worksheet")
		{
			_G_c__DisplayClass23_1 CS_8_locals_10 = new _G_c__DisplayClass23_1();
			CS_8_locals_10.nuvVuVXaUZa = P_1.eKvV6uFJpGF(P_0.Worksheets);
			for (int num = 1; num <= pCPJ2o3f45(() => CS_8_locals_10.nuvVuVXaUZa.Count); num++)
			{
				_G_c__DisplayClass23_2 CS_8_locals_11 = new _G_c__DisplayClass23_2();
				Worksheet worksheet = P_1.eKvV6uFJpGF((Worksheet)(dynamic)CS_8_locals_10.nuvVuVXaUZa[num]);
				CS_8_locals_11.hClVu63L3hp = P_1.eKvV6uFJpGF(worksheet.Names);
				for (int num2 = 1; num2 <= pCPJ2o3f45(() => CS_8_locals_11.hClVu63L3hp.Count); num2++)
				{
					Name name2 = P_1.eKvV6uFJpGF(CS_8_locals_11.hClVu63L3hp.Item(num2, Type.Missing, Type.Missing));
					if (ObsJQvCckC(name2, P_2))
					{
						return name2;
					}
				}
			}
		}
		return null;
	}

	private static bool ObsJQvCckC(Name P_0, string P_1)
	{
		_G_c__DisplayClass24_0 obj = new _G_c__DisplayClass24_0();
		obj.gMvVuTWFYAE = P_0;
		string text;
		string a = (text = hjGJjwaZBM(() => obj.gMvVuTWFYAE.Name));
		int num = text.LastIndexOf('!');
		if (num >= 0 && num < text.Length - 1)
		{
			text = text.Substring(num + 1);
		}
		if (!string.Equals(a, P_1, StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(text, P_1, StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static bool Ld5J1HvxtL(string P_0, out string P_1, out string P_2)
	{
		P_1 = string.Empty;
		P_2 = string.Empty;
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		int num = P_0.LastIndexOf('!');
		if (num <= 0 || num >= P_0.Length - 1)
		{
			return false;
		}
		P_1 = P_0.Substring(0, num).Trim();
		P_2 = P_0.Substring(num + 1).Trim();
		if (P_1.StartsWith("'", StringComparison.Ordinal) && P_1.EndsWith("'", StringComparison.Ordinal))
		{
			P_1 = P_1.Substring(1, P_1.Length - 2).Replace("''", "'");
		}
		int num2 = P_1.LastIndexOf(']');
		if (num2 >= 0 && num2 < P_1.Length - 1)
		{
			P_1 = P_1.Substring(num2 + 1);
		}
		if (!string.IsNullOrWhiteSpace(P_1))
		{
			return !string.IsNullOrWhiteSpace(P_2);
		}
		return false;
	}

	private static bool skJJrNGIkj(Workbook P_0, string P_1)
	{
		_G_c__DisplayClass26_0 CS_8_locals_3 = new _G_c__DisplayClass26_0();
		CS_8_locals_3.i5mVuITLgOH = P_0;
		if (!string.Equals(hjGJjwaZBM(() => CS_8_locals_3.i5mVuITLgOH.Name), P_1, StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(hjGJjwaZBM(() => CS_8_locals_3.i5mVuITLgOH.FullName), P_1, StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static bool u1VJJFd45C(Worksheet P_0, Workbook P_1)
	{
		try
		{
			return P_0.Parent is Workbook workbook && skJJrNGIkj(workbook, P_1.FullName);
		}
		catch
		{
			return false;
		}
	}

	private static object rNBJ3SlLVd(Microsoft.Office.Interop.Excel.Range P_0)
	{
		try
		{
			object value = P_0.Value2;
			if (value is DateTime dateTime)
			{
				return dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
			}
			return value;
		}
		catch
		{
			return null;
		}
	}

	private static string mjyJUctF2A(Microsoft.Office.Interop.Excel.Range P_0)
	{
		_G_c__DisplayClass29_0 CS_8_locals_4 = new _G_c__DisplayClass29_0();
		CS_8_locals_4.QPxVuHFBKg9 = P_0;
		string text = hjGJjwaZBM(delegate
		{
			dynamic val;
			if (!(((dynamic)CS_8_locals_4.QPxVuHFBKg9.Text == null) ? true : false))
			{
				if (_G_o__29.LRuVDC0PlSQ == null)
				{
					_G_o__29.LRuVDC0PlSQ = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "WPS 表格", null, typeof(mWJD9kra0YySjgX6gSL), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__29.LRuVDC0PlSQ.Target(_G_o__29.LRuVDC0PlSQ, CS_8_locals_4.QPxVuHFBKg9.Text);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		});
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		object obj = rNBJ3SlLVd(CS_8_locals_4.QPxVuHFBKg9);
		if (obj != null)
		{
			return Convert.ToString(obj, CultureInfo.InvariantCulture);
		}
		return string.Empty;
	}

	private static string tqdJKIVpyV(Microsoft.Office.Interop.Excel.Range P_0)
	{
		_G_c__DisplayClass30_0 obj = new _G_c__DisplayClass30_0();
		obj.ccQVufmDjvb = P_0;
		return hjGJjwaZBM(() => obj.ccQVufmDjvb.get_Address((object)false, (object)false, XlReferenceStyle.xlA1, Type.Missing, Type.Missing));
	}

	private static int LgrJEVbBNo(Func<int> P_0)
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

	private static int pCPJ2o3f45(Func<int> P_0)
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

	private static bool IVrJ4G8MCE(Func<bool> P_0)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return false;
		}
	}

	private static string hjGJjwaZBM(Func<string> P_0)
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

	private static object lEYJYSoNMC(Func<object> P_0)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return null;
		}
	}

	private static string i0rJZwDpdH()
	{
		if (!eSfxffslhXbaGAjFNv1.IsWps)
		{
			return "Excel";
		}
		return "WPS 表格";
	}

	public mWJD9kra0YySjgX6gSL()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
	}
}
