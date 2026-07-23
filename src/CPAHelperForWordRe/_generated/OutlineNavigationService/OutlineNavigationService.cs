using System;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using WordTableToolService;
using LoggerInitializer;

namespace OutlineNavigationService;

internal static class OutlineNavigationService
{
	private static Application App => WordTableToolService.WordApp;

	public static void GoToNextTable()
	{
		try
		{
			Selection selection = App.Selection;
			object What = WdGoToItem.wdGoToTable;
			object Which = WdGoToDirection.wdGoToNext;
			object Count = Type.Missing;
			object Name = Type.Missing;
			selection.GoTo(ref What, ref Which, ref Count, ref Name);
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError(ex.Message, "IP_Assurance");
		}
	}

	public static void GoToNextHighlight()
	{
		try
		{
			Document activeDocument = App.ActiveDocument;
			object Start = Type.Missing;
			object End = Type.Missing;
			int end = activeDocument.Range(ref Start, ref End).End;
			int num = App.Selection.End;
			while (num < end)
			{
				End = num;
				Start = end;
				Range range = activeDocument.Range(ref End, ref Start);
				Find find = range.Find;
				find.ClearFormatting();
				find.Text = "?";
				find.Forward = true;
				find.Wrap = WdFindWrap.wdFindStop;
				find.Format = true;
				find.Highlight = 1;
				find.MatchCase = false;
				find.MatchWholeWord = false;
				find.MatchWildcards = true;
				find.MatchSoundsLike = false;
				find.MatchAllWordForms = false;
				Start = Type.Missing;
				End = Type.Missing;
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
				if (!find.Execute(ref Start, ref End, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref ReplaceWith, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl))
				{
					break;
				}
				if (NKuKTsCyLY(activeDocument, range, num, end, out var range2))
				{
					range2.Select();
					return;
				}
				num = Math.Min((range.End > num) ? range.End : (num + 1), end);
			}
			LoggerInitializer.ShowInfo("没有找到下一个高亮", "IP_Assurance");
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError(ex.Message, "IP_Assurance");
		}
	}

	private static bool NKuKTsCyLY(Document P_0, Range P_1, int P_2, int P_3, out Range P_4)
	{
		P_4 = null;
		if (P_1 == null || P_1.End <= P_1.Start)
		{
			return false;
		}
		if (!FindFirstHighlightedPosition(P_0, P_1.Start, P_1.End, P_3, out var num))
		{
			return false;
		}
		int num2 = num;
		while (num2 > P_2 && IsHighlighted(P_0, num2 - 1, num2))
		{
			num2--;
		}
		int i;
		for (i = num + 1; i < P_3 && IsHighlighted(P_0, i, i + 1); i++)
		{
		}
		if (i <= num2)
		{
			return false;
		}
		object Start = num2;
		object End = i;
		P_4 = P_0.Range(ref Start, ref End);
		return true;
	}

	private static bool FindFirstHighlightedPosition(Document P_0, int P_1, int P_2, int P_3, out int P_4)
	{
		P_4 = -1;
		int num = Math.Min(Math.Max(P_2, P_1 + 1), P_3);
		for (int i = P_1; i < num; i++)
		{
			if (IsHighlighted(P_0, i, i + 1))
			{
				P_4 = i;
				return true;
			}
		}
		return false;
	}

	private static bool IsHighlighted(Document P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_2 <= P_1)
		{
			return false;
		}
		try
		{
			object Start = P_1;
			object End = P_2;
			int highlightColorIndex = (int)P_0.Range(ref Start, ref End).HighlightColorIndex;
			return highlightColorIndex != 0 && highlightColorIndex != 9999999;
		}
		catch
		{
			return false;
		}
	}

	public static void GoToNextHeading()
	{
		Selection selection = App.Selection;
		int end = selection.End;
		int num = int.MaxValue;
		int num2 = -1;
		object MatchControl;
		object MatchAlefHamza;
		object MatchDiacritics;
		object MatchKashida;
		object Replace;
		object ReplaceWith;
		object Format;
		object Wrap;
		object Forward;
		object MatchAllWordForms;
		object MatchSoundsLike;
		object MatchWildcards;
		object MatchWholeWord;
		object MatchCase;
		object FindText;
		for (int i = 1; i <= 9; i++)
		{
			selection.Start = end;
			selection.End = end;
			selection.Find.ClearFormatting();
			selection.Find.ParagraphFormat.OutlineLevel = (WdOutlineLevel)i;
			Find find = selection.Find;
			find.Text = "";
			find.Forward = true;
			find.Wrap = WdFindWrap.wdFindStop;
			find.Format = true;
			find.MatchCase = false;
			find.MatchWholeWord = false;
			find.MatchWildcards = false;
			find.MatchSoundsLike = false;
			find.MatchAllWordForms = false;
			FindText = Type.Missing;
			MatchCase = Type.Missing;
			MatchWholeWord = Type.Missing;
			MatchWildcards = Type.Missing;
			MatchSoundsLike = Type.Missing;
			MatchAllWordForms = Type.Missing;
			Forward = Type.Missing;
			Wrap = Type.Missing;
			Format = Type.Missing;
			ReplaceWith = Type.Missing;
			Replace = Type.Missing;
			MatchKashida = Type.Missing;
			MatchDiacritics = Type.Missing;
			MatchAlefHamza = Type.Missing;
			MatchControl = Type.Missing;
			if (find.Execute(ref FindText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref ReplaceWith, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl) && selection.Start < num)
			{
				num = selection.Start;
				num2 = i;
			}
		}
		if (num2 < 0)
		{
			LoggerInitializer.ShowInfo("没有找到下一个标题", "IP_Assurance");
			return;
		}
		selection.Start = end;
		selection.End = end;
		selection.Find.ClearFormatting();
		selection.Find.ParagraphFormat.OutlineLevel = (WdOutlineLevel)num2;
		selection.Find.Text = "";
		selection.Find.Forward = true;
		selection.Find.Wrap = WdFindWrap.wdFindStop;
		selection.Find.Format = true;
		Find find2 = selection.Find;
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
		MatchSoundsLike = Type.Missing;
		MatchWildcards = Type.Missing;
		MatchWholeWord = Type.Missing;
		MatchCase = Type.Missing;
		FindText = Type.Missing;
		find2.Execute(ref MatchControl, ref MatchAlefHamza, ref MatchDiacritics, ref MatchKashida, ref Replace, ref ReplaceWith, ref Format, ref Wrap, ref Forward, ref MatchAllWordForms, ref MatchSoundsLike, ref MatchWildcards, ref MatchWholeWord, ref MatchCase, ref FindText);
	}
}
