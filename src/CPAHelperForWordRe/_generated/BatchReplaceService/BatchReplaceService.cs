using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Threading;
using CPAHelperForWordRe.UI.Forms;
using AiConfigBootstrap;
using AiHelper_20;
using TableBorderConfig;
using WordTableToolService5;
using AiSseStreamService3;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService;
using ExcelInteropService;
using LoggerInitializer;

namespace BatchReplaceService;

internal static class BatchReplaceService
{
	private struct R2YhBSV3zlYwiRqrxZHs
	{
		[CompilerGenerated]
		private readonly int nOyVURBbIRW;

		[CompilerGenerated]
		private readonly int wuMVUVdrX5y;

		public int Start
		{
			[CompilerGenerated]
			get
			{
				return nOyVURBbIRW;
			}
		}

		public int End
		{
			[CompilerGenerated]
			get
			{
				return wuMVUVdrX5y;
			}
		}

		public R2YhBSV3zlYwiRqrxZHs(int P_0, int P_1)
		{
			SseStreamInitializer.AlBVL0oCCKQ();
			nOyVURBbIRW = P_0;
			wuMVUVdrX5y = P_1;
		}
	}

	private sealed class lK59I4VUBQWVJpoki7MO
	{
		[CompilerGenerated]
		private string KgkVU9tJsbA;

		[CompilerGenerated]
		private string fUkVU6l3A2m;

		[CompilerGenerated]
		private string hGOVUu7in9u;

		[CompilerGenerated]
		private float? SX2VUDpiZ4w;

		[CompilerGenerated]
		private int? v4VVUTu90ND;

		[CompilerGenerated]
		private int? fBfVUgAv0D2;

		[CompilerGenerated]
		private WdUnderline? jf6VU8wB0BY;

		[CompilerGenerated]
		private WdParagraphAlignment? OwLVUINNXFp;

		[CompilerGenerated]
		private WdCellVerticalAlignment? kSJVUiEkH09;

		public string NameFarEast
		{
			[CompilerGenerated]
			get
			{
				return KgkVU9tJsbA;
			}
			[CompilerGenerated]
			set
			{
				KgkVU9tJsbA = value;
			}
		}

		public string NameAscii
		{
			[CompilerGenerated]
			get
			{
				return fUkVU6l3A2m;
			}
			[CompilerGenerated]
			set
			{
				fUkVU6l3A2m = value;
			}
		}

		public string NameOther
		{
			[CompilerGenerated]
			get
			{
				return hGOVUu7in9u;
			}
			[CompilerGenerated]
			set
			{
				hGOVUu7in9u = value;
			}
		}

		public float? Size
		{
			[CompilerGenerated]
			get
			{
				return SX2VUDpiZ4w;
			}
			[CompilerGenerated]
			set
			{
				SX2VUDpiZ4w = value;
			}
		}

		public int? Bold
		{
			[CompilerGenerated]
			get
			{
				return v4VVUTu90ND;
			}
			[CompilerGenerated]
			set
			{
				v4VVUTu90ND = value;
			}
		}

		public int? Italic
		{
			[CompilerGenerated]
			get
			{
				return fBfVUgAv0D2;
			}
			[CompilerGenerated]
			set
			{
				fBfVUgAv0D2 = value;
			}
		}

		public WdUnderline? Underline
		{
			[CompilerGenerated]
			get
			{
				return jf6VU8wB0BY;
			}
			[CompilerGenerated]
			set
			{
				jf6VU8wB0BY = value;
			}
		}

		public WdParagraphAlignment? ParagraphAlignment
		{
			[CompilerGenerated]
			get
			{
				return OwLVUINNXFp;
			}
			[CompilerGenerated]
			set
			{
				OwLVUINNXFp = value;
			}
		}

		public WdCellVerticalAlignment? VerticalAlignment
		{
			[CompilerGenerated]
			get
			{
				return kSJVUiEkH09;
			}
			[CompilerGenerated]
			set
			{
				kSJVUiEkH09 = value;
			}
		}

		public lK59I4VUBQWVJpoki7MO()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}
	}

	[CompilerGenerated]
	private static class _G_o__17
	{
		public static CallSite<Func<CallSite, object, object>> Od9VU2HR5gW;

		public static CallSite<Func<CallSite, object, object>> qehVU4CkmLe;

		public static CallSite<Func<CallSite, Type, object, object>> SLFVUj7dyZt;

		public static CallSite<Func<CallSite, object, int>> X5sVUYorLpq;

		public static CallSite<Func<CallSite, object, object>> HOgVUZShiuk;

		public static CallSite<Func<CallSite, object, object>> EaiVUfwFhWg;

		public static CallSite<Func<CallSite, Type, object, object>> KfbVUMxDE0h;

		public static CallSite<Func<CallSite, object, int>> v2rVUb6foRt;
	}

	private static readonly List<R2YhBSV3zlYwiRqrxZHs> HnMb6R7ZKw;

	private static string Tv0buOiKWt;

	private static Microsoft.Office.Interop.Word.Application App => WordTableToolService.WordApp;

	private static TableBorderConfig Cfg => TableBorderConfig.Current;

	public static void lyrMMMAAtt(int P_0)
	{
		Paragraphs paragraphs = App.Selection.Paragraphs;
		if (paragraphs.OutlineLevel != (WdOutlineLevel)P_0)
		{
			paragraphs.OutlineLevel = (WdOutlineLevel)P_0;
			if (paragraphs.OutlineLevel != (WdOutlineLevel)P_0)
			{
				LoggerInitializer.F9Ycoqv2I8("无法直接调整该段落的大纲级次，请检查是否已设置样式，请取消样式或手动调整样式级次", "IP_Assurance");
			}
		}
	}

	public static void q3PMb6fekY()
	{
		Selection selection = App.Selection;
		object Direction = WdCollapseDirection.wdCollapseEnd;
		selection.Collapse(ref Direction);
		Comments comments = App.ActiveDocument.Comments;
		Range range = App.Selection.Range;
		Direction = "";
		comments.Add(range, ref Direction);
	}

	public static void dR8MSOK1CL()
	{
		try
		{
			App.Selection.Comments[1].Delete();
		}
		catch
		{
			LoggerInitializer.Ay3cNuEgJo("你需要先选中一个批注", "IP_Assurance");
		}
	}

	public static void vJhMwyuHtR()
	{
		foreach (Revision revision in App.ActiveDocument.Revisions)
		{
			revision.Range.HighlightColorIndex = WdColorIndex.wdYellow;
		}
	}

	public static void kcGMtYHAg8()
	{
		try
		{
			if (!dGUMmCaDyi(out var num, out var num2))
			{
				LoggerInitializer.F9Ycoqv2I8("未获取到 Excel/WPS 复制区域。请先在 Excel 中复制表格，或关闭任务管理器中的残留 Excel 后重试。", "IP_Assurance");
				return;
			}
			Selection selection = App.Selection;
			if (selection.Tables.Count == 0)
			{
				LoggerInitializer.Ay3cNuEgJo("请将光标放在要粘贴的 Word 表格内", "IP_Assurance");
				return;
			}
			int num3 = (dynamic)selection.get_Information(WdInformation.wdEndOfRangeColumnNumber);
			int num4 = (dynamic)selection.get_Information(WdInformation.wdEndOfRangeRowNumber);
			rmcMGCPGL3(num4, num3, num, num2);
			List<lK59I4VUBQWVJpoki7MO> list = new List<lK59I4VUBQWVJpoki7MO>();
			foreach (Cell cell3 in App.Selection.Cells)
			{
				list.Add(T9LMLoTdMc(cell3));
			}
			if (num == 1 && num2 == 1)
			{
				App.Selection.PasteAndFormat(WdRecoveryType.wdFormatPlainText);
			}
			else
			{
				App.Selection.CopyFormat();
				App.Selection.PasteAndFormat(WdRecoveryType.wdFormatPlainText);
				App.Selection.PasteFormat();
				cNwMlU2l5J(App.Selection.Range);
			}
			rmcMGCPGL3(num4, num3, num, num2);
			int num5 = 0;
			foreach (Cell cell4 in App.Selection.Cells)
			{
				if (num5 < list.Count)
				{
					brRMsIh3Cb(cell4, list[num5]);
				}
				num5++;
			}
		}
		catch (Exception ex)
		{
			LoggerInitializer.F9Ycoqv2I8("请检查任务管理器后台进程中是否有残留Excel " + ex.Message, "IP_Assurance");
		}
	}

	private static lK59I4VUBQWVJpoki7MO T9LMLoTdMc(Cell P_0)
	{
		lK59I4VUBQWVJpoki7MO lK59I4VUBQWVJpoki7MO2 = new lK59I4VUBQWVJpoki7MO();
		Font font = P_0.Range.Font;
		try
		{
			lK59I4VUBQWVJpoki7MO2.NameFarEast = font.NameFarEast;
		}
		catch
		{
		}
		try
		{
			lK59I4VUBQWVJpoki7MO2.NameAscii = font.NameAscii;
		}
		catch
		{
		}
		try
		{
			lK59I4VUBQWVJpoki7MO2.NameOther = font.NameOther;
		}
		catch
		{
		}
		try
		{
			float size = font.Size;
			if (size > 0f && size != 9999999f)
			{
				lK59I4VUBQWVJpoki7MO2.Size = size;
			}
		}
		catch
		{
		}
		try
		{
			int bold = font.Bold;
			if (bold != 9999999)
			{
				lK59I4VUBQWVJpoki7MO2.Bold = bold;
			}
		}
		catch
		{
		}
		try
		{
			int italic = font.Italic;
			if (italic != 9999999)
			{
				lK59I4VUBQWVJpoki7MO2.Italic = italic;
			}
		}
		catch
		{
		}
		try
		{
			WdUnderline underline = font.Underline;
			if (underline != (WdUnderline)9999999)
			{
				lK59I4VUBQWVJpoki7MO2.Underline = underline;
			}
		}
		catch
		{
		}
		try
		{
			WdParagraphAlignment alignment = P_0.Range.ParagraphFormat.Alignment;
			if (alignment != (WdParagraphAlignment)9999999)
			{
				lK59I4VUBQWVJpoki7MO2.ParagraphAlignment = alignment;
			}
		}
		catch
		{
		}
		try
		{
			WdCellVerticalAlignment verticalAlignment = P_0.VerticalAlignment;
			if (verticalAlignment != (WdCellVerticalAlignment)9999999)
			{
				lK59I4VUBQWVJpoki7MO2.VerticalAlignment = verticalAlignment;
			}
		}
		catch
		{
		}
		return lK59I4VUBQWVJpoki7MO2;
	}

	private static void brRMsIh3Cb(Cell P_0, lK59I4VUBQWVJpoki7MO P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		Font font = P_0.Range.Font;
		try
		{
			if (!string.IsNullOrEmpty(P_1.NameFarEast))
			{
				font.NameFarEast = P_1.NameFarEast;
			}
		}
		catch
		{
		}
		try
		{
			if (!string.IsNullOrEmpty(P_1.NameAscii))
			{
				font.NameAscii = P_1.NameAscii;
			}
		}
		catch
		{
		}
		try
		{
			if (!string.IsNullOrEmpty(P_1.NameOther))
			{
				font.NameOther = P_1.NameOther;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.Size.HasValue)
			{
				font.Size = P_1.Size.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.Bold.HasValue)
			{
				font.Bold = P_1.Bold.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.Italic.HasValue)
			{
				font.Italic = P_1.Italic.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.Underline.HasValue)
			{
				font.Underline = P_1.Underline.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.ParagraphAlignment.HasValue)
			{
				P_0.Range.ParagraphFormat.Alignment = P_1.ParagraphAlignment.Value;
			}
		}
		catch
		{
		}
		try
		{
			if (P_1.VerticalAlignment.HasValue)
			{
				P_0.VerticalAlignment = P_1.VerticalAlignment.Value;
			}
		}
		catch
		{
		}
	}

	private static void cNwMlU2l5J(Range P_0)
	{
		mayMNkmhY0(P_0, " ", "");
		mayMNkmhY0(P_0, "　", "");
	}

	private static void mayMNkmhY0(Range P_0, string P_1, string P_2)
	{
		Find find = P_0.Duplicate.Find;
		find.ClearFormatting();
		find.Replacement.ClearFormatting();
		find.Text = P_1;
		find.Replacement.Text = P_2;
		find.Forward = true;
		find.Wrap = WdFindWrap.wdFindStop;
		find.Format = false;
		find.MatchCase = false;
		find.MatchWholeWord = false;
		find.MatchByte = true;
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
	}

	private static bool dGUMmCaDyi(out int P_0, out int P_1)
	{
		P_0 = 0;
		P_1 = 0;
		try
		{
			object obj = ExcelInteropService.X11yRCCGO()?.Selection;
			if (obj != null)
			{
				object arg = obj;
				if (_G_o__17.SLFVUj7dyZt == null)
				{
					_G_o__17.SLFVUj7dyZt = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToInt32", null, typeof(BatchReplaceService), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, Type, object, object> target = _G_o__17.SLFVUj7dyZt.Target;
				CallSite<Func<CallSite, Type, object, object>> sLFVUj7dyZt = _G_o__17.SLFVUj7dyZt;
				Type typeFromHandle = typeof(Convert);
				if (_G_o__17.qehVU4CkmLe == null)
				{
					_G_o__17.qehVU4CkmLe = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Count", typeof(BatchReplaceService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, object> target2 = _G_o__17.qehVU4CkmLe.Target;
				CallSite<Func<CallSite, object, object>> qehVU4CkmLe = _G_o__17.qehVU4CkmLe;
				if (_G_o__17.Od9VU2HR5gW == null)
				{
					_G_o__17.Od9VU2HR5gW = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Rows", typeof(BatchReplaceService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				P_0 = (dynamic)target(sLFVUj7dyZt, typeFromHandle, target2(qehVU4CkmLe, _G_o__17.Od9VU2HR5gW.Target(_G_o__17.Od9VU2HR5gW, arg)));
				if (_G_o__17.KfbVUMxDE0h == null)
				{
					_G_o__17.KfbVUMxDE0h = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToInt32", null, typeof(BatchReplaceService), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, Type, object, object> target3 = _G_o__17.KfbVUMxDE0h.Target;
				CallSite<Func<CallSite, Type, object, object>> kfbVUMxDE0h = _G_o__17.KfbVUMxDE0h;
				Type typeFromHandle2 = typeof(Convert);
				if (_G_o__17.EaiVUfwFhWg == null)
				{
					_G_o__17.EaiVUfwFhWg = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Count", typeof(BatchReplaceService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, object> target4 = _G_o__17.EaiVUfwFhWg.Target;
				CallSite<Func<CallSite, object, object>> eaiVUfwFhWg = _G_o__17.EaiVUfwFhWg;
				if (_G_o__17.HOgVUZShiuk == null)
				{
					_G_o__17.HOgVUZShiuk = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Columns", typeof(BatchReplaceService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				P_1 = (dynamic)target3(kfbVUMxDE0h, typeFromHandle2, target4(eaiVUfwFhWg, _G_o__17.HOgVUZShiuk.Target(_G_o__17.HOgVUZShiuk, arg)));
				if (P_0 > 0 && P_1 > 0)
				{
					return true;
				}
			}
		}
		catch (Exception)
		{
		}
		return YIZMoRKpVb(out P_0, out P_1);
	}

	private static bool YIZMoRKpVb(out int P_0, out int P_1)
	{
		P_0 = 0;
		P_1 = 0;
		try
		{
			string text = null;
			if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
			{
				text = Clipboard.GetText(TextDataFormat.UnicodeText);
			}
			else if (Clipboard.ContainsText(TextDataFormat.Text))
			{
				text = Clipboard.GetText(TextDataFormat.Text);
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			string[] array = text.Replace("\r\n", "\n").Replace('\r', '\n').TrimEnd('\n')
				.Split(new char[1] { '\n' }, StringSplitOptions.None);
			if (array.Length == 0)
			{
				return false;
			}
			P_0 = array.Length;
			P_1 = array.Max((string line) => line.Split('\t').Length);
			return P_0 > 0 && P_1 > 0;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static void rmcMGCPGL3(int P_0, int P_1, int P_2, int P_3)
	{
		Selection selection = App.Selection;
		selection.Tables[1].Cell(P_0, P_1).Select();
		object Direction = WdCollapseDirection.wdCollapseStart;
		selection.Collapse(ref Direction);
		int start = selection.Start;
		selection.Tables[1].Cell(P_0 + P_2 - 1, P_1 + P_3 - 1).Select();
		Direction = WdCollapseDirection.wdCollapseEnd;
		selection.Collapse(ref Direction);
		int end = selection.End;
		Document activeDocument = App.ActiveDocument;
		Direction = start;
		object End = end;
		activeDocument.Range(ref Direction, ref End).Select();
	}

	public static void OTQMCTfGfe()
	{
		Cfg.m15SqmKUa9();
		App.ScreenUpdating = false;
		try
		{
			foreach (Paragraph paragraph in App.Selection.Paragraphs)
			{
				ParagraphFormat paragraphFormat = paragraph.Range.ParagraphFormat;
				paragraphFormat.LeftIndent = App.CentimetersToPoints(0f);
				paragraphFormat.RightIndent = App.CentimetersToPoints(0f);
				paragraphFormat.SpaceBefore = 0f;
				paragraphFormat.SpaceBeforeAuto = 0;
				paragraphFormat.SpaceAfter = 0f;
				paragraphFormat.SpaceAfterAuto = 0;
				paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
				paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
				paragraphFormat.FirstLineIndent = App.CentimetersToPoints(0f);
				paragraphFormat.CharacterUnitLeftIndent = 0f;
				paragraphFormat.CharacterUnitRightIndent = 0f;
				paragraphFormat.CharacterUnitFirstLineIndent = 0f;
				paragraphFormat.LineUnitBefore = 0f;
				paragraphFormat.LineUnitAfter = 0f;
				paragraph.Range.Font.NameFarEast = Cfg.KxPSXHwy4c("段落_表前单位_中文字体", "宋体");
				paragraph.Range.Font.NameAscii = Cfg.KxPSXHwy4c("段落_表前单位_西文字体", "Times New Roman");
				paragraph.Range.Font.NameOther = Cfg.KxPSXHwy4c("段落_表前单位_西文字体", "Times New Roman");
				paragraph.Range.Font.Size = LKIMOlo9Fh("段落_表前单位_字号", 10.5);
				paragraph.Range.Font.Bold = 0;
			}
		}
		finally
		{
			App.ScreenUpdating = true;
		}
	}

	public static void xgwMpXfu5F()
	{
		Cfg.m15SqmKUa9();
		App.ScreenUpdating = false;
		try
		{
			foreach (Paragraph paragraph in App.Selection.Paragraphs)
			{
				ParagraphFormat paragraphFormat = paragraph.Range.ParagraphFormat;
				paragraphFormat.LeftIndent = App.CentimetersToPoints(0f);
				paragraphFormat.RightIndent = App.CentimetersToPoints(0f);
				paragraphFormat.SpaceBeforeAuto = 0;
				paragraphFormat.SpaceAfterAuto = 0;
				paragraphFormat.FirstLineIndent = App.CentimetersToPoints(0f);
				paragraphFormat.CharacterUnitLeftIndent = 0f;
				paragraphFormat.CharacterUnitRightIndent = 0f;
				paragraphFormat.CharacterUnitFirstLineIndent = 0f;
				paragraph.Range.Font.NameFarEast = Cfg.KxPSXHwy4c("段落_表后注释_中文字体", "宋体");
				paragraph.Range.Font.NameAscii = Cfg.KxPSXHwy4c("段落_表后注释_西文字体", "Times New Roman");
				paragraph.Range.Font.NameOther = Cfg.KxPSXHwy4c("段落_表后注释_西文字体", "Times New Roman");
				paragraph.Range.Font.Size = LKIMOlo9Fh("段落_表后注释_字号", 10.5);
				paragraph.Range.Font.Bold = 0;
				j8WM7tPosj(paragraphFormat, "表后注释", "无", 0.0, "字符");
				Q96McYSHJA(paragraphFormat, "表后注释", 3, 0, "行");
			}
		}
		finally
		{
			App.ScreenUpdating = true;
		}
	}

	private static float LKIMOlo9Fh(string P_0, double P_1)
	{
		return (float)AiHelper_20.NgZw6CkHuw(Cfg.KxPSXHwy4c(P_0, string.Empty), P_1);
	}

	private static void S3UMntpQqj(ParagraphFormat P_0)
	{
		P_0.LeftIndent = 0f;
		P_0.RightIndent = 0f;
		P_0.FirstLineIndent = 0f;
		P_0.CharacterUnitLeftIndent = 0f;
		P_0.CharacterUnitRightIndent = 0f;
		P_0.CharacterUnitFirstLineIndent = 0f;
		P_0.LeftIndent = 0f;
		P_0.RightIndent = 0f;
		P_0.FirstLineIndent = 0f;
		P_0.CharacterUnitLeftIndent = 0f;
		P_0.CharacterUnitRightIndent = 0f;
		P_0.CharacterUnitFirstLineIndent = 0f;
	}

	private static void j8WM7tPosj(ParagraphFormat P_0, string P_1, string P_2, double P_3, string P_4 = "字符")
	{
		S3UMntpQqj(P_0);
		double num = Cfg.hB5SFqa39l("段落_" + P_1 + "_左缩进");
		double num2 = Cfg.hB5SFqa39l("段落_" + P_1 + "_右缩进");
		string text = (Cfg.KxPSXHwy4c("段落_" + P_1 + "_缩进单位", P_4) ?? string.Empty).ToLower();
		if (text == "字符")
		{
			P_0.CharacterUnitLeftIndent = (float)num;
			P_0.CharacterUnitRightIndent = (float)num2;
		}
		else if (text == "厘米")
		{
			P_0.LeftIndent = App.CentimetersToPoints((float)num);
			P_0.RightIndent = App.CentimetersToPoints((float)num2);
		}
		string text2 = (Cfg.KxPSXHwy4c("段落_" + P_1 + "_特殊缩进", P_2) ?? string.Empty).ToLower();
		double num3 = Cfg.hB5SFqa39l("段落_" + P_1 + "_缩进值", P_3);
		if (text2 == "首行")
		{
			if (text == "字符")
			{
				P_0.CharacterUnitFirstLineIndent = (float)num3;
			}
			else if (text == "厘米")
			{
				P_0.FirstLineIndent = App.CentimetersToPoints((float)num3);
			}
		}
		else if (text2 == "悬挂")
		{
			if (text == "字符")
			{
				P_0.CharacterUnitFirstLineIndent = (float)(0.0 - num3);
			}
			else if (text == "厘米")
			{
				P_0.FirstLineIndent = 0f - App.CentimetersToPoints((float)num3);
			}
		}
	}

	private static void ubNM5IVjYp(ParagraphFormat P_0)
	{
		P_0.SpaceBeforeAuto = 0;
		P_0.SpaceAfterAuto = 0;
		P_0.SpaceBefore = 0f;
		P_0.SpaceAfter = 0f;
		P_0.LineUnitBefore = 0f;
		P_0.LineUnitAfter = 0f;
		P_0.SpaceBeforeAuto = 0;
		P_0.SpaceAfterAuto = 0;
		P_0.SpaceBefore = 0f;
		P_0.SpaceAfter = 0f;
		P_0.LineUnitBefore = 0f;
		P_0.LineUnitAfter = 0f;
	}

	private static void Q96McYSHJA(ParagraphFormat P_0, string P_1, int P_2, int P_3, string P_4 = "行", double P_5 = 0.0, double P_6 = 0.0, bool P_7 = true)
	{
		ubNM5IVjYp(P_0);
		if (P_7)
		{
			P_0.Alignment = (WdParagraphAlignment)Cfg.HYsSh2NDxY("段落_" + P_1 + "_对齐方式", P_2);
		}
		switch ((int)(P_0.LineSpacingRule = (WdLineSpacing)Cfg.HYsSh2NDxY("段落_" + P_1 + "_行距样式", P_3)))
		{
		case 3:
		case 4:
			P_0.LineSpacing = (float)Cfg.hB5SFqa39l("段落_" + P_1 + "_行距值", 18.0);
			break;
		case 5:
			P_0.LineSpacing = App.LinesToPoints((float)Cfg.hB5SFqa39l("段落_" + P_1 + "_行距值", 1.0));
			break;
		}
		if (Cfg.KxPSXHwy4c("段落_" + P_1 + "_段前距单位", P_4) == "行")
		{
			P_0.SpaceBefore = 0f;
			P_0.SpaceAfter = 0f;
			P_0.LineUnitBefore = (float)Cfg.hB5SFqa39l("段落_" + P_1 + "_段前距", P_5);
			P_0.LineUnitAfter = (float)Cfg.hB5SFqa39l("段落_" + P_1 + "_段后距", P_6);
		}
		else
		{
			P_0.LineUnitBefore = 0f;
			P_0.LineUnitAfter = 0f;
			P_0.SpaceBefore = (float)Cfg.hB5SFqa39l("段落_" + P_1 + "_段前距", P_5);
			P_0.SpaceAfter = (float)Cfg.hB5SFqa39l("段落_" + P_1 + "_段后距", P_6);
		}
	}

	public static void BBAMen3SA4()
	{
		gJhMybnA3f(App.Selection.Range, true);
	}

	internal static void gJhMybnA3f(Range P_0, bool P_1)
	{
		hn7MXTwgTj(P_0, P_1, null);
	}

	internal static void hn7MXTwgTj(Range P_0, bool P_1, Func<int, int, string, bool> P_2)
	{
		Cfg.m15SqmKUa9();
		App.ScreenUpdating = false;
		ProgressWindow progressWindow = null;
		try
		{
			if (P_0 == null)
			{
				return;
			}
			int count = P_0.Paragraphs.Count;
			int num = 0;
			int num2 = 0;
			Exception ex = null;
			bool flag = P_1 && P_2 == null;
			if (flag)
			{
				progressWindow = KZ1bRCaswy();
			}
			foreach (Paragraph paragraph in P_0.Paragraphs)
			{
				num++;
				bool flag2 = false;
				try
				{
					flag2 = (bool)(dynamic)paragraph.Range.get_Information(WdInformation.wdWithInTable);
				}
				catch
				{
				}
				if (!flag2)
				{
					string text = "其他";
					int outlineLevel = (int)paragraph.OutlineLevel;
					if (outlineLevel >= 1 && outlineLevel <= 5)
					{
						text = TwVMhPQDZD(outlineLevel);
					}
					if (!iduMFMMQXY(paragraph, text, out var ex2))
					{
						num2++;
						if (ex == null)
						{
							ex = ex2;
						}
					}
				}
				string arg = string.Format("正在设置段落格式：{0} / {1}", num, count);
				if (P_2 != null)
				{
					if (!P_2(num, count, arg))
					{
						break;
					}
				}
				else if (flag && !LUqbVxwwvy(progressWindow, num, count))
				{
					break;
				}
			}
			if (num2 > 0)
			{
				AiConfigBootstrap.ujWsURly3F(string.Format("[FormatParagraph] Paragraph formatting partially failed; Total={0}; Failed={1}", count, num2), ex);
			}
		}
		finally
		{
			AVsb9xRHFx(progressWindow);
			App.ScreenUpdating = true;
		}
	}

	private static bool iduMFMMQXY(Paragraph P_0, string P_1, out Exception P_2)
	{
		P_2 = null;
		try
		{
			P_0.Range.Font.Bold = Cfg.HYsSh2NDxY("段落_" + P_1 + "_加粗");
			P_0.Range.Font.NameFarEast = Cfg.KxPSXHwy4c("段落_" + P_1 + "_中文字体", "宋体");
			P_0.Range.Font.NameAscii = Cfg.KxPSXHwy4c("段落_" + P_1 + "_西文字体", "Times New Roman");
			P_0.Range.Font.NameOther = Cfg.KxPSXHwy4c("段落_" + P_1 + "_西文字体", "Times New Roman");
			P_0.Range.Font.Size = LKIMOlo9Fh("段落_" + P_1 + "_字号", 10.5);
			ParagraphFormat paragraphFormat = P_0.Range.ParagraphFormat;
			j8WM7tPosj(paragraphFormat, P_1, "无", 0.0, "字符");
			Q96McYSHJA(paragraphFormat, P_1, 3, 0, "行");
			return true;
		}
		catch (Exception ex)
		{
			P_2 = ex;
			return false;
		}
	}

	private static string TwVMhPQDZD(int P_0)
	{
		return P_0 switch
		{
			1 => "一级", 
			2 => "二级", 
			3 => "三级", 
			4 => "四级", 
			5 => "五级", 
			_ => "其他", 
		};
	}

	public static void IlFMa7FUcE()
	{
		Document activeDocument = App.ActiveDocument;
		ProgressWindow progressWindow = null;
		int num = 0;
		string text = null;
		bool flag = false;
		bool flag2 = false;
		try
		{
			YHNM0Sk6OR();
			Tv0buOiKWt = BeyMkY7TTX(activeDocument);
			int count = activeDocument.Tables.Count;
			int num2 = 0;
			progressWindow = KZ1bRCaswy();
			AC9bBhOofI(progressWindow, 0, "正在清理上次选择标记...");
			flag = true;
			object EditorID = WdEditorType.wdEditorEveryone;
			activeDocument.DeleteAllEditableRanges(ref EditorID);
			flag = false;
			for (int i = 1; i <= count; i++)
			{
				num2++;
				Table table = activeDocument.Tables[i];
				int num3;
				if (i >= count)
				{
					EditorID = Type.Missing;
					object End = Type.Missing;
					num3 = activeDocument.Range(ref EditorID, ref End).End;
				}
				else
				{
					num3 = activeDocument.Tables[i + 1].Range.Start;
				}
				int num4 = num3;
				Paragraph paragraph = c36MxXjenX(activeDocument, table, num4);
				if (paragraph != null)
				{
					flag = true;
					Editors editors = paragraph.Range.Editors;
					object End = WdEditorType.wdEditorEveryone;
					editors.Add(ref End);
					HnMb6R7ZKw.Add(new R2YhBSV3zlYwiRqrxZHs(paragraph.Range.Start, paragraph.Range.End));
					num++;
				}
				if (!LUqbVxwwvy(progressWindow, num2, count))
				{
					break;
				}
			}
			if (num == 0)
			{
				YHNM0Sk6OR();
			}
			if (num > 0)
			{
				object End = WdEditorType.wdEditorEveryone;
				activeDocument.SelectAllEditableRanges(ref End);
			}
			if (flag)
			{
				AC9bBhOofI(progressWindow, 100, "正在清理选择标记，耗时可能较长，请耐心等待...");
				object End = WdEditorType.wdEditorEveryone;
				activeDocument.DeleteAllEditableRanges(ref End);
				flag2 = true;
				flag = false;
			}
			text = ((num > 0) ? string.Format("未找到表后第一段。", num) : "已选中 {0} 个表后第一段。");
		}
		finally
		{
			AVsb9xRHFx(progressWindow);
			if (flag && !flag2)
			{
				try
				{
					object End = WdEditorType.wdEditorEveryone;
					activeDocument.DeleteAllEditableRanges(ref End);
				}
				catch
				{
				}
			}
			App.ScreenUpdating = true;
		}
		LoggerInitializer.Ay3cNuEgJo(text, "IP_Assurance");
	}

	public static void a3lMqZdKO0()
	{
		Cfg.m15SqmKUa9();
		App.ScreenUpdating = false;
		ProgressWindow progressWindow = null;
		int num = 0;
		string text = null;
		try
		{
			Document activeDocument = App.ActiveDocument;
			if (OOQMWQhlVh(activeDocument))
			{
				progressWindow = KZ1bRCaswy();
				num = NJWMPFP8I4(activeDocument, progressWindow);
				YHNM0Sk6OR();
			}
			else
			{
				if (HnMb6R7ZKw.Count > 0)
				{
					YHNM0Sk6OR();
				}
				progressWindow = KZ1bRCaswy();
				num = hQLMABhHAB(progressWindow);
			}
			text = ((num > 0) ? string.Format("未找到可处理的表后段落，请先执行“全选表后第一段”或手动选中表后段落。", num) : "表后间距处理完成，共处理 {0} 段。");
		}
		finally
		{
			AVsb9xRHFx(progressWindow);
			App.ScreenUpdating = true;
		}
		LoggerInitializer.Ay3cNuEgJo(text, "IP_Assurance");
	}

	private static int NJWMPFP8I4(Document P_0, ProgressWindow P_1)
	{
		int num = 0;
		object Start = Type.Missing;
		object End = Type.Missing;
		int end = P_0.Range(ref Start, ref End).End;
		int count = HnMb6R7ZKw.Count;
		int num2 = 0;
		foreach (R2YhBSV3zlYwiRqrxZHs item in HnMb6R7ZKw)
		{
			num2++;
			if (item.Start < 0 || item.End <= item.Start || item.End > end)
			{
				if (!LUqbVxwwvy(P_1, num2, count))
				{
					break;
				}
				continue;
			}
			End = item.Start;
			Start = item.End;
			Range range = P_0.Range(ref End, ref Start);
			if (range.Paragraphs.Count == 0)
			{
				if (!LUqbVxwwvy(P_1, num2, count))
				{
					break;
				}
				continue;
			}
			if (pl6MvbKkEA(range.Paragraphs[1]))
			{
				num++;
			}
			if (!LUqbVxwwvy(P_1, num2, count))
			{
				break;
			}
		}
		return num;
	}

	private static int hQLMABhHAB(ProgressWindow P_0)
	{
		int num = 0;
		Paragraphs paragraphs = App.Selection.Paragraphs;
		int count = paragraphs.Count;
		int num2 = 0;
		foreach (Paragraph item in paragraphs)
		{
			num2++;
			if (pl6MvbKkEA(item))
			{
				num++;
			}
			if (!LUqbVxwwvy(P_0, num2, count))
			{
				break;
			}
		}
		return num;
	}

	private static bool pl6MvbKkEA(Paragraph P_0)
	{
		bool flag = false;
		try
		{
			flag = (bool)(dynamic)P_0.Range.get_Information(WdInformation.wdWithInTable);
		}
		catch
		{
		}
		if (flag)
		{
			return false;
		}
		Q96McYSHJA(P_0.Range.ParagraphFormat, "表后段落", 3, 4, "磅", 0.0, 2.5, false);
		return true;
	}

	private static bool OOQMWQhlVh(Document P_0)
	{
		if (HnMb6R7ZKw.Count == 0)
		{
			return false;
		}
		return string.Equals(Tv0buOiKWt, BeyMkY7TTX(P_0), StringComparison.Ordinal);
	}

	private static void YHNM0Sk6OR()
	{
		HnMb6R7ZKw.Clear();
		Tv0buOiKWt = string.Empty;
	}

	private static string BeyMkY7TTX(Document P_0)
	{
		try
		{
			return P_0.FullName ?? string.Empty;
		}
		catch
		{
		}
		try
		{
			return P_0.Name ?? string.Empty;
		}
		catch
		{
		}
		return string.Empty;
	}

	private static Paragraph c36MxXjenX(Document P_0, Table P_1, int P_2)
	{
		int end = P_1.Range.End;
		if (end >= P_2)
		{
			return null;
		}
		object Start = end;
		object End = P_2;
		Range range = P_0.Range(ref Start, ref End);
		int count = range.Paragraphs.Count;
		for (int i = 1; i <= count; i++)
		{
			Paragraph paragraph = range.Paragraphs[i];
			bool flag = false;
			try
			{
				flag = (bool)(dynamic)paragraph.Range.get_Information(WdInformation.wdWithInTable);
			}
			catch
			{
			}
			if (!flag)
			{
				return paragraph;
			}
		}
		return null;
	}

	public static void lUNMdtyonR()
	{
		try
		{
			Find find = App.Selection.Range.Find;
			find.ClearFormatting();
			find.Replacement.ClearFormatting();
			find.Text = "^p^p";
			find.Replacement.Text = "^p";
			find.Forward = true;
			find.Wrap = WdFindWrap.wdFindStop;
			find.Format = false;
			find.MatchCase = false;
			find.MatchWholeWord = false;
			find.MatchWildcards = false;
			find.MatchSoundsLike = false;
			find.MatchAllWordForms = false;
			int num = 0;
			do
			{
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
				if (find.Execute(ref FindText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref ReplaceWith, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl))
				{
					num++;
					continue;
				}
				break;
			}
			while (num <= 100);
		}
		finally
		{
			App.ScreenUpdating = true;
		}
	}

	public static void JasMzZGiuF()
	{
		try
		{
			Find find = App.Selection.Range.Find;
			find.ClearFormatting();
			find.Replacement.ClearFormatting();
			find.Text = "^p";
			find.Replacement.Text = "";
			find.Forward = true;
			find.Wrap = WdFindWrap.wdFindStop;
			find.Format = false;
			find.MatchCase = false;
			find.MatchWholeWord = false;
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
			find.Text = "^l";
			find.Replacement.Text = "";
			MatchControl = Type.Missing;
			MatchAlefHamza = Type.Missing;
			MatchDiacritics = Type.Missing;
			MatchKashida = Type.Missing;
			Replace = Type.Missing;
			ReplaceWith = Type.Missing;
			Format = Type.Missing;
			Wrap = Type.Missing;
			Forward = Type.Missing;
			MatchAllWordForms = Type.Missing;
			MatchSoundsLike = WdReplace.wdReplaceAll;
			MatchWildcards = Type.Missing;
			MatchWholeWord = Type.Missing;
			MatchCase = Type.Missing;
			FindText = Type.Missing;
			find.Execute(ref MatchControl, ref MatchAlefHamza, ref MatchDiacritics, ref MatchKashida, ref Replace, ref ReplaceWith, ref Format, ref Wrap, ref Forward, ref MatchAllWordForms, ref MatchSoundsLike, ref MatchWildcards, ref MatchWholeWord, ref MatchCase, ref FindText);
		}
		finally
		{
			App.ScreenUpdating = true;
		}
	}

	private static ProgressWindow KZ1bRCaswy()
	{
		try
		{
			ProgressWindow progressWindow = new ProgressWindow();
			WordTableToolService5.IPf5i0ZcV4(progressWindow);
			return progressWindow;
		}
		catch
		{
			return null;
		}
	}

	private static bool LUqbVxwwvy(ProgressWindow P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return true;
		}
		if (!P_0.IsVisible)
		{
			return false;
		}
		int percent = ((P_2 <= 0) ? 100 : ((int)Math.Round((double)P_1 * 100.0 / (double)P_2)));
		P_0.SetProgress(percent, string.Format("当前进度：{0} / {1}", P_1, P_2));
		try
		{
			P_0.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
		}
		catch
		{
		}
		return P_0.IsVisible;
	}

	private static bool AC9bBhOofI(ProgressWindow P_0, int P_1, string P_2)
	{
		if (P_0 == null)
		{
			return true;
		}
		if (!P_0.IsVisible)
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
		return P_0.IsVisible;
	}

	private static void AVsb9xRHFx(ProgressWindow P_0)
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

	static BatchReplaceService()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		HnMb6R7ZKw = new List<R2YhBSV3zlYwiRqrxZHs>();
		Tv0buOiKWt = string.Empty;
	}
}
