using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using BatchReplaceService;
using CPAHelperForWordRe.UI.Forms;
using AiConfigBootstrap;
using BatchTableAdjustService;
using WordTableToolService5;
using AiSseStreamService3;
using Markdig;
using Markdig.Extensions.Tables;
using Markdig.Extensions.TaskLists;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService;
using LoggerInitializer;

namespace MarkdownImportService;

internal static class MarkdownImportService
{
	private sealed class MarkdownImportContext
	{
		private readonly Application _application;

		private readonly Document _document;

		private readonly List<InlineStyleSpan> _inlineStyleSpans;

		private readonly List<HeadingNumberingRange> _headingRanges;

		private Range _range;

		private int _int;

		private int _int;

		private int _quoteDepth;

		[CompilerGenerated]
		private int _headingCount;

		[CompilerGenerated]
		private int _paragraphCount;

		[CompilerGenerated]
		private int _tableCount;

		[CompilerGenerated]
		private int _inlineStyleFailureCount;

		[CompilerGenerated]
		private int _headingNumberingFailureCount;

		public int HeadingCount
		{
			[CompilerGenerated]
			get
			{
				return _headingCount;
			}
			[CompilerGenerated]
			private set
			{
				_headingCount = value;
			}
		}

		public int ParagraphCount
		{
			[CompilerGenerated]
			get
			{
				return _paragraphCount;
			}
			[CompilerGenerated]
			private set
			{
				_paragraphCount = value;
			}
		}

		public int TableCount
		{
			[CompilerGenerated]
			get
			{
				return _tableCount;
			}
			[CompilerGenerated]
			private set
			{
				_tableCount = value;
			}
		}

		public int InlineStyleFailureCount
		{
			[CompilerGenerated]
			get
			{
				return _inlineStyleFailureCount;
			}
			[CompilerGenerated]
			private set
			{
				_inlineStyleFailureCount = value;
			}
		}

		public int HeadingNumberingFailureCount
		{
			[CompilerGenerated]
			get
			{
				return _headingNumberingFailureCount;
			}
			[CompilerGenerated]
			private set
			{
				_headingNumberingFailureCount = value;
			}
		}

		public MarkdownImportContext(Application P_0, Document P_1)
		{
			SseStreamInitializer.InitializeRuntime();
			_inlineStyleSpans = new List<InlineStyleSpan>();
			_headingRanges = new List<HeadingNumberingRange>();
			_application = P_0;
			_document = P_1;
		}

		public void ImportDocument(MarkdownDocument P_0)
		{
			InitializeInsertionRange();
			foreach (Block item in P_0)
			{
				ProcessBlock(item);
			}
			_int = _range.Start;
		}

		public Range GetImportedRange()
		{
			if (_int <= _int)
			{
				return null;
			}
			Document document = _document;
			object Start = _int;
			object End = _int;
			return document.Range(ref Start, ref End);
		}

		public void ApplyInlineStyles()
		{
			InlineStyleFailureCount = 0;
			int num = 0;
			string text = null;
			foreach (InlineStyleSpan item in _inlineStyleSpans)
			{
				StyleApplyResult styleApplyResult = item.Apply(_document);
				if (!styleApplyResult.Success)
				{
					InlineStyleFailureCount++;
					num += styleApplyResult.FailureCount;
					if (string.IsNullOrWhiteSpace(text))
					{
						text = styleApplyResult.FirstFailure;
					}
				}
			}
			if (InlineStyleFailureCount > 0)
			{
				AiConfigBootstrap.LogWarn(string.Format("[MarkdownImport] Inline styles partially applied; TotalSpans={0}; FailedSpans={1}; FailedProperties={2}; FirstFailure={3}", _inlineStyleSpans.Count, InlineStyleFailureCount, num, text ?? string.Empty));
			}
		}

		public void ApplyHeadingNumbering()
		{
			HeadingNumberingFailureCount = 0;
			if (_headingRanges.Count == 0)
			{
				return;
			}
			ListTemplate listTemplate = CreateHeadingListTemplate();
			if (listTemplate == null)
			{
				HeadingNumberingFailureCount = _headingRanges.Count;
				return;
			}
			bool flag = true;
			int num = 0;
			string text = null;
			foreach (HeadingNumberingRange item in _headingRanges)
			{
				try
				{
					Document document = _document;
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
				AiConfigBootstrap.LogWarn(string.Format("[MarkdownImport] Heading numbering partially applied; Total={0}; Failed={1}; FirstFailure={2}", _headingRanges.Count, num, text ?? string.Empty));
			}
		}

		public void SelectImportedRange()
		{
			try
			{
				Document document = _document;
				object Start = _int;
				object End = _int;
				document.Range(ref Start, ref End).Select();
			}
			catch
			{
			}
		}

		private void InitializeInsertionRange()
		{
			Selection selection = _application.Selection;
			Range range = ((selection != null) ? selection.Range.Duplicate : _document.Content.Duplicate);
			int num = ((range != null) ? Math.Max(range.Start, range.End) : Math.Max(0, _document.Content.End - 1));
			Document document = _document;
			object Start = num;
			object End = num;
			_range = document.Range(ref Start, ref End);
			_range.Select();
			_int = num;
			_int = num;
		}

		private void ProcessBlock(Block P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			if (P_0 is HeadingBlock headingBlock)
			{
				ProcessHeading(headingBlock);
			}
			else if (P_0 is ParagraphBlock paragraphBlock)
			{
				WriteParagraph(paragraphBlock.Inline, WdOutlineLevel.wdOutlineLevelBodyText, string.Empty);
			}
			else if (P_0 is Markdig.Extensions.Tables.Table table)
			{
				ProcessTable(table);
			}
			else if (P_0 is ListBlock listBlock)
			{
				ProcessList(listBlock, 0);
			}
			else if (P_0 is QuoteBlock quoteBlock)
			{
				ProcessQuote(quoteBlock);
			}
			else if (P_0 is CodeBlock codeBlock)
			{
				ProcessCodeBlock(codeBlock);
			}
			else if (P_0 is ThematicBreakBlock)
			{
				ProcessThematicBreak();
			}
			else if (P_0 is HtmlBlock htmlBlock)
			{
				ProcessHtmlBlock(htmlBlock.Lines.ToString());
			}
			else
			{
				if (!(P_0 is ContainerBlock containerBlock))
				{
					return;
				}
				foreach (Block item in containerBlock)
				{
					ProcessBlock(item);
				}
			}
		}

		private void ProcessHeading(HeadingBlock P_0)
		{
			int num = Math.Max(1, Math.Min(5, P_0.Level));
			Range range = WriteParagraph(P_0.Inline, (WdOutlineLevel)num, string.Empty);
			if (range != null)
			{
				_headingRanges.Add(new HeadingNumberingRange(range.Start, range.End, num));
			}
			HeadingCount++;
		}

		private Range WriteParagraph(ContainerInline P_0, WdOutlineLevel P_1, string P_2)
		{
			int start = _range.Start;
			string text = BuildQuotePrefix() + (P_2 ?? string.Empty);
			if (text.Length > 0)
			{
				InsertStyledText(text, InlineStyle.Normal);
			}
			ProcessInlines(P_0, InlineStyle.Normal);
			InsertText("\\r");
			Document document = _document;
			object Start = start;
			object End = _range.Start;
			Range range = document.Range(ref Start, ref End);
			range.ParagraphFormat.OutlineLevel = P_1;
			ParagraphCount++;
			return range;
		}

		private void ProcessHtmlBlock(string P_0)
		{
			string text = NormalizeLineEndings(P_0);
			if (!string.IsNullOrEmpty(text))
			{
				string[] array = text.Split(new char[1] { '\n' }, StringSplitOptions.None);
				foreach (string text2 in array)
				{
					WriteParagraph(CreateInlineFromString(text2), WdOutlineLevel.wdOutlineLevelBodyText, string.Empty);
				}
			}
		}

		private void ProcessCodeBlock(CodeBlock P_0)
		{
			string text = NormalizeLineEndings(P_0.Lines.ToString());
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
				int start = _range.Start;
				InsertStyledText(BuildQuotePrefix(), InlineStyle.Normal);
				InsertStyledText(text2, InlineStyle.CodeStyle);
				InsertText("\\r");
				Document document = _document;
				object Start = start;
				object End = _range.Start;
				document.Range(ref Start, ref End).ParagraphFormat.OutlineLevel = WdOutlineLevel.wdOutlineLevelBodyText;
				ParagraphCount++;
			}
		}

		private void ProcessThematicBreak()
		{
			WriteParagraph(CreateInlineFromString("____________________________"), WdOutlineLevel.wdOutlineLevelBodyText, string.Empty);
		}

		private void ProcessQuote(QuoteBlock P_0)
		{
			_quoteDepth++;
			try
			{
				foreach (Block item in P_0)
				{
					ProcessBlock(item);
				}
			}
			finally
			{
				_quoteDepth = Math.Max(0, _quoteDepth - 1);
			}
		}

		private void ProcessList(ListBlock P_0, int P_1)
		{
			int num = GetListStartNumber(P_0);
			foreach (Block item in P_0)
			{
				if (item is ListItemBlock listItemBlock)
				{
					ProcessListItem(P_0, listItemBlock, P_1, num);
					if (P_0.IsOrdered)
					{
						num++;
					}
				}
			}
		}

		private void ProcessListItem(ListBlock P_0, ListItemBlock P_1, int P_2, int P_3)
		{
			bool flag = true;
			bool flag2 = false;
			foreach (Block item in P_1)
			{
				if (item is ParagraphBlock paragraphBlock)
				{
					string text = (flag ? BuildListPrefix(P_0, P_2, P_3) : new string(' ', Math.Max(0, P_2 * 2 + 2)));
					WriteParagraph(paragraphBlock.Inline, WdOutlineLevel.wdOutlineLevelBodyText, text);
					flag = false;
					flag2 = true;
				}
				else if (item is ListBlock listBlock)
				{
					ProcessList(listBlock, P_2 + 1);
					flag2 = true;
				}
				else
				{
					ProcessBlock(item);
					flag2 = true;
				}
			}
			if (!flag2)
			{
				WriteParagraph(CreateInlineFromString(string.Empty), WdOutlineLevel.wdOutlineLevelBodyText, BuildListPrefix(P_0, P_2, P_3));
			}
		}

		private static int GetListStartNumber(ListBlock P_0)
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

		private static string BuildListPrefix(ListBlock P_0, int P_1, int P_2)
		{
			string text = new string(' ', Math.Max(0, P_1 * 2));
			if (P_0.IsOrdered)
			{
				return text + P_2 + ". ";
			}
			return text + "- ";
		}

		private void ProcessTable(Markdig.Extensions.Tables.Table P_0)
		{
			List<List<string>> list = ExtractTableRows(P_0);
			if (list.Count == 0)
			{
				return;
			}
			int count = list.Count;
			int num = Math.Max(1, list.Max((List<string> row) => row.Count));
			Tables tables = _document.Tables;
			Range insertionRange = _range;
			object DefaultTableBehavior = Type.Missing;
			object AutoFitBehavior = Type.Missing;
			Microsoft.Office.Interop.Word.Table table = tables.Add(insertionRange, count, num, ref DefaultTableBehavior, ref AutoFitBehavior);
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
			_range = duplicate.Duplicate;
			_int = _range.Start;
			TableCount++;
		}

		private List<List<string>> ExtractTableRows(Markdig.Extensions.Tables.Table P_0)
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
						list2.Add(ExtractContainerText(tableCell));
					}
				}
				list.Add(list2);
			}
			return list;
		}

		private void ProcessInlines(ContainerInline P_0, InlineStyle P_1)
		{
			if (P_0 != null)
			{
				for (Inline inline = P_0.FirstChild; inline != null; inline = inline.NextSibling)
				{
					ProcessInline(inline, P_1);
				}
			}
		}

		private void ProcessInline(Inline P_0, InlineStyle P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			if (P_0 is LiteralInline literalInline)
			{
				InsertStyledText(literalInline.Content.ToString(), P_1);
			}
			else if (P_0 is CodeInline codeInline)
			{
				InlineStyle codeStyle = P_1.Clone();
				codeStyle.Code = true;
				InsertStyledText(codeInline.Content ?? string.Empty, codeStyle);
			}
			else if (P_0 is LineBreakInline)
			{
				InsertStyledText("", P_1);
			}
			else if (P_0 is TaskList taskList)
			{
				InsertStyledText(taskList.Checked ? "[ ] " : "[x] ", P_1);
			}
			else if (P_0 is EmphasisInline emphasisInline)
			{
				InlineStyle emphasisStyle = P_1.Clone();
				if (emphasisInline.DelimiterChar == '~')
				{
					emphasisStyle.Strike = true;
				}
				else if (emphasisInline.DelimiterCount >= 2)
				{
					emphasisStyle.Bold = true;
				}
				else
				{
					emphasisStyle.Italic = true;
				}
				ProcessInlines(emphasisInline, emphasisStyle);
			}
			else if (P_0 is LinkInline linkInline)
			{
				InlineStyle linkStyle = P_1.Clone();
				if (linkInline.IsImage)
				{
					string text = ExtractInlineText(linkInline);
					InsertStyledText(string.IsNullOrWhiteSpace(text) ? "[image: " : ("]" + text + "[image]"), P_1);
				}
				else
				{
					linkStyle.Link = true;
					ProcessInlines(linkInline, linkStyle);
				}
			}
			else if (P_0 is AutolinkInline autolinkInline)
			{
				InlineStyle autolinkStyle = P_1.Clone();
				autolinkStyle.Link = true;
				InsertStyledText(autolinkInline.Url ?? string.Empty, autolinkStyle);
			}
			else if (P_0 is HtmlEntityInline htmlEntityInline)
			{
				InsertStyledText(WebUtility.HtmlDecode(htmlEntityInline.Original.ToString()), P_1);
			}
			else if (P_0 is HtmlInline htmlInline)
			{
				InsertStyledText(StripHtml(htmlInline.Tag), P_1);
			}
			else if (P_0 is ContainerInline containerInline)
			{
				ProcessInlines(containerInline, P_1);
			}
			else
			{
				InsertStyledText(P_0.ToString(), P_1);
			}
		}

		private void InsertStyledText(string P_0, InlineStyle P_1)
		{
			string text = NormalizeForInline(P_0);
			if (text.Length != 0)
			{
				int start = _range.Start;
				InsertText(text);
				int start2 = _range.Start;
				if (P_1.HasFormatting)
				{
					InlineStyleSpan item = new InlineStyleSpan(start, start2, P_1.Clone());
					_inlineStyleSpans.Add(item);
				}
			}
		}

		private void InsertText(string P_0)
		{
			if (!string.IsNullOrEmpty(P_0))
			{
				int start = _range.Start;
				_range.Text = P_0;
				int num;
				try
				{
					num = _range.End;
				}
				catch
				{
					num = start + P_0.Length;
				}
				if (num <= start)
				{
					num = start + P_0.Length;
				}
				Document document = _document;
				object Start = num;
				object End = num;
				_range = document.Range(ref Start, ref End);
				_int = num;
			}
		}

		private string BuildQuotePrefix()
		{
			if (_quoteDepth <= 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < _quoteDepth; i++)
			{
				stringBuilder.Append("> ");
			}
			return stringBuilder.ToString();
		}

		private static ContainerInline CreateInlineFromString(string P_0)
		{
			ContainerInline containerInline = new ContainerInline();
			containerInline.AppendChild(new LiteralInline(P_0 ?? string.Empty));
			return containerInline;
		}

		private static string ExtractContainerText(ContainerBlock P_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Block item in P_0)
			{
				string text = ExtractBlockText(item);
				if (text.Length != 0)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append('\n');
					}
					stringBuilder.Append(text);
				}
			}
			return CollapseWhitespace(stringBuilder.ToString());
		}

		private static string ExtractBlockText(Block P_0)
		{
			if (P_0 == null)
			{
				return string.Empty;
			}
			if (P_0 is ParagraphBlock paragraphBlock)
			{
				return ExtractInlineText(paragraphBlock.Inline);
			}
			if (P_0 is HeadingBlock headingBlock)
			{
				return ExtractInlineText(headingBlock.Inline);
			}
			if (P_0 is CodeBlock codeBlock)
			{
				return NormalizeLineEndings(codeBlock.Lines.ToString());
			}
			if (P_0 is HtmlBlock htmlBlock)
			{
				return StripHtml(htmlBlock.Lines.ToString());
			}
			if (P_0 is ContainerBlock containerBlock)
			{
				return ExtractContainerText(containerBlock);
			}
			return string.Empty;
		}

		private static string ExtractInlineText(ContainerInline P_0)
		{
			if (P_0 == null)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			AppendInlineText(P_0, stringBuilder);
			return CollapseWhitespace(stringBuilder.ToString());
		}

		private static void AppendInlineText(Inline P_0, StringBuilder P_1)
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
				P_1.Append(StripHtml(htmlInline.Tag));
			}
			else if (P_0 is ContainerInline containerInline)
			{
				for (Inline inline = containerInline.FirstChild; inline != null; inline = inline.NextSibling)
				{
					AppendInlineText(inline, P_1);
				}
			}
		}

		private static string NormalizeForInline(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return string.Empty;
			}
			return P_0.Replace("\r\n", "").Replace('\r', '\v').Replace('\n', '\v');
		}

		private static string NormalizeLineEndings(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return string.Empty;
			}
			return P_0.Replace("\r\n", "\n").Replace('\r', '\n').TrimEnd('\n');
		}

		private static string CollapseWhitespace(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return string.Empty;
			}
			return Regex.Replace(NormalizeLineEndings(P_0), "[ \\\\t]*\\\\n[ \\\\t]*", "\\r").Trim();
		}

		private static string StripHtml(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return string.Empty;
			}
			return WebUtility.HtmlDecode(Regex.Replace(P_0, "<.*?>", string.Empty));
		}

		private ListTemplate CreateHeadingListTemplate()
		{
			ListTemplate listTemplate = null;
			try
			{
				ListTemplates listTemplates = _document.ListTemplates;
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
					ListTemplates listTemplates2 = _application.ListGalleries[WdListGalleryType.wdOutlineNumberGallery].ListTemplates;
					object Name = 1;
					listTemplate = listTemplates2[ref Name];
				}
				catch (Exception ex2)
				{
					AiConfigBootstrap.LogWarn("[MarkdownImport] Use outline number gallery failed: " + ex2.Message);
					return null;
				}
			}
			ConfigureListTemplate(listTemplate);
			return listTemplate;
		}

		private void ConfigureListTemplate(ListTemplate P_0)
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
					listLevel.NumberFormat = GetNumberFormat(i);
					listLevel.NumberStyle = GetNumberStyle(i);
					listLevel.StartAt = 1;
					listLevel.ResetOnHigher = ((i != 1) ? (i - 1) : 0);
					listLevel.TrailingCharacter = WdTrailingCharacter.wdTrailingNone;
					listLevel.Alignment = WdListLevelAlignment.wdListLevelAlignLeft;
					float numberPosition = _application.CentimetersToPoints((float)((double)(i - 1) * 0.65));
					float num2 = _application.CentimetersToPoints((float)((double)i * 0.65));
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
				AiConfigBootstrap.LogWarn(string.Format("[MarkdownImport] Heading number template partially configured; FailedLevels={0}; FirstFailure={1}", num, text ?? string.Empty));
			}
		}

		private static string GetNumberFormat(int P_0)
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

		private static WdListNumberStyle GetNumberStyle(int P_0)
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

	private sealed class HeadingNumberingRange
	{
		[CompilerGenerated]
		private readonly int _int;

		[CompilerGenerated]
		private readonly int _int;

		[CompilerGenerated]
		private readonly int _level;

		public int Start
		{
			[CompilerGenerated]
			get
			{
				return _int;
			}
		}

		public int End
		{
			[CompilerGenerated]
			get
			{
				return _int;
			}
		}

		public int Level
		{
			[CompilerGenerated]
			get
			{
				return _level;
			}
		}

		public HeadingNumberingRange(int P_0, int P_1, int P_2)
		{
			SseStreamInitializer.InitializeRuntime();
			_int = P_0;
			_int = P_1;
			_level = P_2;
		}
	}

	private sealed class InlineStyle
	{
		public static readonly InlineStyle Normal;

		public static readonly InlineStyle CodeStyle;

		[CompilerGenerated]
		private bool _bold;

		[CompilerGenerated]
		private bool _italic;

		[CompilerGenerated]
		private bool _strike;

		[CompilerGenerated]
		private bool _code;

		[CompilerGenerated]
		private bool _link;

		public bool Bold
		{
			[CompilerGenerated]
			get
			{
				return _bold;
			}
			[CompilerGenerated]
			set
			{
				_bold = value;
			}
		}

		public bool Italic
		{
			[CompilerGenerated]
			get
			{
				return _italic;
			}
			[CompilerGenerated]
			set
			{
				_italic = value;
			}
		}

		public bool Strike
		{
			[CompilerGenerated]
			get
			{
				return _strike;
			}
			[CompilerGenerated]
			set
			{
				_strike = value;
			}
		}

		public bool Code
		{
			[CompilerGenerated]
			get
			{
				return _code;
			}
			[CompilerGenerated]
			set
			{
				_code = value;
			}
		}

		public bool Link
		{
			[CompilerGenerated]
			get
			{
				return _link;
			}
			[CompilerGenerated]
			set
			{
				_link = value;
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

		public InlineStyle Clone()
		{
			return new InlineStyle
			{
				Bold = Bold,
				Italic = Italic,
				Strike = Strike,
				Code = Code,
				Link = Link
			};
		}

		public InlineStyle()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		static InlineStyle()
		{
			SseStreamInitializer.InitializeRuntime();
			Normal = new InlineStyle();
			CodeStyle = new InlineStyle
			{
				Code = true
			};
		}
	}

	private sealed class InlineStyleSpan
	{
		[CompilerGenerated]
		private sealed class _G_c__DisplayClass4_0
		{
			public Range range;

			public _G_c__DisplayClass4_0()
			{
				SseStreamInitializer.InitializeRuntime();
			}

			internal void ApplyBold()
			{
				range.Font.Bold = -1;
			}

			internal void ApplyItalic()
			{
				range.Font.Italic = -1;
			}

			internal void ApplyStrikeThrough()
			{
				range.Font.StrikeThrough = -1;
			}

			internal void ApplyCodeFontAscii()
			{
				range.Font.NameAscii = "Consolas";
			}

			internal void ApplyCodeFontOther()
			{
				range.Font.NameOther = "Consolas";
			}

			internal void ApplyUnderline()
			{
				range.Font.Underline = WdUnderline.wdUnderlineSingle;
			}

			internal void ApplyLinkColor()
			{
				range.Font.Color = WdColor.wdColorBlue;
			}
		}

		private readonly int _start;

		private readonly int _int;

		private readonly InlineStyle _style;

		public InlineStyleSpan(int P_0, int P_1, InlineStyle P_2)
		{
			SseStreamInitializer.InitializeRuntime();
			_start = P_0;
			_int = P_1;
			_style = P_2;
		}

		public StyleApplyResult Apply(Document P_0)
		{
			_G_c__DisplayClass4_0 CS_8_locals_8 = new _G_c__DisplayClass4_0();
			StyleApplyResult styleApplyResult = new StyleApplyResult(_start, _int);
			if (P_0 == null)
			{
				styleApplyResult.RecordFailure("Document", 0, new InvalidOperationException("Word document is unavailable."));
				return styleApplyResult;
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
				styleApplyResult.RecordFailure("DocumentRange", 0, ex);
				return styleApplyResult;
			}
			if (_int <= _start || _start < start || _int > end)
			{
				styleApplyResult.RecordFailure("Range", end, new ArgumentOutOfRangeException("range", string.Format("Inline range {0}-{1} is outside document range {2}-{3}.", _start, _int, start, end)));
				return styleApplyResult;
			}
			try
			{
				object Start = _start;
				object End = _int;
				CS_8_locals_8.range = P_0.Range(ref Start, ref End);
			}
			catch (Exception ex2)
			{
				styleApplyResult.RecordFailure("Range", end, ex2);
				return styleApplyResult;
			}
			if (_style.Bold)
			{
				TryApplyFormat(styleApplyResult, "Bold", end, delegate
				{
					CS_8_locals_8.range.Font.Bold = -1;
				});
			}
			if (_style.Italic)
			{
				TryApplyFormat(styleApplyResult, "Italic", end, delegate
				{
					CS_8_locals_8.range.Font.Italic = -1;
				});
			}
			if (_style.Strike)
			{
				TryApplyFormat(styleApplyResult, "StrikeThrough", end, delegate
				{
					CS_8_locals_8.range.Font.StrikeThrough = -1;
				});
			}
			if (_style.Code)
			{
				TryApplyFormat(styleApplyResult, "NameAscii", end, delegate
				{
					CS_8_locals_8.range.Font.NameAscii = "NameOther";
				});
				TryApplyFormat(styleApplyResult, "Underline", end, delegate
				{
					CS_8_locals_8.range.Font.NameOther = "Color";
				});
			}
			if (_style.Link)
			{
				TryApplyFormat(styleApplyResult, "Document", end, delegate
				{
					CS_8_locals_8.range.Font.Underline = WdUnderline.wdUnderlineSingle;
				});
				TryApplyFormat(styleApplyResult, "Word document is unavailable.", end, delegate
				{
					CS_8_locals_8.range.Font.Color = WdColor.wdColorBlue;
				});
			}
			return styleApplyResult;
		}

		private static void TryApplyFormat(StyleApplyResult P_0, string P_1, int P_2, Action P_3)
		{
			try
			{
				P_3();
			}
			catch (Exception ex)
			{
				P_0.RecordFailure(P_1, P_2, ex);
			}
		}
	}

	private sealed class StyleApplyResult
	{
		private readonly int _int;

		private readonly int _end;

		[CompilerGenerated]
		private int _failureCount;

		[CompilerGenerated]
		private string _firstFailure;

		public int FailureCount
		{
			[CompilerGenerated]
			get
			{
				return _failureCount;
			}
			[CompilerGenerated]
			private set
			{
				_failureCount = value;
			}
		}

		public string FirstFailure
		{
			[CompilerGenerated]
			get
			{
				return _firstFailure;
			}
			[CompilerGenerated]
			private set
			{
				_firstFailure = value;
			}
		}

		public bool Success => FailureCount == 0;

		public StyleApplyResult(int P_0, int P_1)
		{
			SseStreamInitializer.InitializeRuntime();
			_int = P_0;
			_end = P_1;
		}

		public void RecordFailure(string P_0, int P_1, Exception P_2)
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
		public ProgressWindow progressWindow;

		public _G_c__DisplayClass2_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool ReportParagraphProgress(int current, int count, string message)
		{
			return UpdateProgress(progressWindow, InterpolateProgress(42, 70, current, count), message);
		}

		internal bool ReportTableProgress(int current, int count, string message)
		{
			return UpdateProgress(progressWindow, InterpolateProgress(72, 86, current, count), message);
		}
	}

	private static readonly MarkdownPipeline _markdownPipeline;

	public static bool Import(string P_0)
	{
		return ImportMarkdown(P_0, true);
	}

	public static bool ImportMarkdown(string P_0, bool P_1)
	{
		_G_c__DisplayClass2_0 CS_8_locals_19 = new _G_c__DisplayClass2_0();
		if (string.IsNullOrWhiteSpace(P_0))
		{
			LoggerInitializer.ShowWarning("请先粘贴 Markdown 文本。", "IP_Assurance");
			return false;
		}
		Application wordApp = WordTableToolService.WordApp;
		if (wordApp == null)
		{
			LoggerInitializer.ShowError("未找到 Word/WPS 文档窗口。", "IP_Assurance");
			return false;
		}
		Document activeDocument;
		try
		{
			activeDocument = wordApp.ActiveDocument;
		}
		catch
		{
			LoggerInitializer.ShowError("请先打开一个 Word/WPS 文档。", "IP_Assurance");
			return false;
		}
		if (activeDocument == null)
		{
			LoggerInitializer.ShowError("请先打开一个 Word/WPS 文档。", "IP_Assurance");
			return false;
		}
		CS_8_locals_19.progressWindow = null;
		MarkdownDocument markdownDocument;
		try
		{
			CS_8_locals_19.progressWindow = CreateProgressWindow();
			if (!UpdateProgress(CS_8_locals_19.progressWindow, 5, "正在解析 Markdown..."))
			{
				CloseProgressWindow(CS_8_locals_19.progressWindow);
				return ShowCancelledWarning();
			}
			markdownDocument = Markdown.Parse(P_0, _markdownPipeline);
		}
		catch (Exception ex)
		{
			CloseProgressWindow(CS_8_locals_19.progressWindow);
			AiConfigBootstrap.LogError("[MarkdownImport] Parse failed", ex);
			LoggerInitializer.ShowError("Markdown 解析失败：" + ex.Message, "IP_Assurance");
			return false;
		}
		bool screenUpdating = wordApp.ScreenUpdating;
		try
		{
			wordApp.ScreenUpdating = false;
			if (!UpdateProgress(CS_8_locals_19.progressWindow, 15, "正在写入 Word 内容..."))
			{
				return ShowCancelledWarning();
			}
			MarkdownImportContext importContext = new MarkdownImportContext(wordApp, activeDocument);
			importContext.ImportDocument(markdownDocument);
			Range range = importContext.GetImportedRange();
			if (range == null || range.End <= range.Start)
			{
				LoggerInitializer.ShowWarning("未生成可导入的 Word 内容。", "IP_Assurance");
				return false;
			}
			if (P_1)
			{
				if (!UpdateProgress(CS_8_locals_19.progressWindow, 35, "正在应用标题编号..."))
				{
					return ShowCancelledWarning();
				}
				importContext.ApplyHeadingNumbering();
				if (IsCancelled(CS_8_locals_19.progressWindow))
				{
					return ShowCancelledWarning();
				}
			}
			if (!UpdateProgress(CS_8_locals_19.progressWindow, 42, "正在设置段落格式..."))
			{
				return ShowCancelledWarning();
			}
			BatchReplaceService.FormatRangeParagraphsWithCallback(range.Duplicate, false, (int current, int count, string message) => UpdateProgress(CS_8_locals_19.progressWindow, InterpolateProgress(42, 70, current, count), message));
			if (IsCancelled(CS_8_locals_19.progressWindow))
			{
				return ShowCancelledWarning();
			}
			if (!UpdateProgress(CS_8_locals_19.progressWindow, 72, "正在设置表格格式..."))
			{
				return ShowCancelledWarning();
			}
			BatchTableAdjustService.AdjustTablesInRangeWithCallback(range.Duplicate, false, (int current, int count, string message) => UpdateProgress(CS_8_locals_19.progressWindow, InterpolateProgress(72, 86, current, count), message));
			if (IsCancelled(CS_8_locals_19.progressWindow))
			{
				return ShowCancelledWarning();
			}
			if (!UpdateProgress(CS_8_locals_19.progressWindow, 92, "正在应用行内样式..."))
			{
				return ShowCancelledWarning();
			}
			importContext.ApplyInlineStyles();
			if (IsCancelled(CS_8_locals_19.progressWindow))
			{
				return ShowCancelledWarning();
			}
			UpdateProgress(CS_8_locals_19.progressWindow, 98, "正在定位导入结束位置...");
			importContext.SelectImportedRange();
			UpdateProgress(CS_8_locals_19.progressWindow, 100, "Markdown 导入完成。");
			LoggerInitializer.ShowInfo(BuildSummaryMessage(importContext), "IP_Assurance");
			return true;
		}
		catch (Exception ex2)
		{
			AiConfigBootstrap.LogError("[MarkdownImport] Import failed", ex2);
			LoggerInitializer.ShowError("Markdown 导入失败：" + ex2.Message, "IP_Assurance");
			return false;
		}
		finally
		{
			CloseProgressWindow(CS_8_locals_19.progressWindow);
			wordApp.ScreenUpdating = screenUpdating;
		}
	}

	private static ProgressWindow CreateProgressWindow()
	{
		try
		{
			ProgressWindow obj = new ProgressWindow
			{
				Title = "Markdown 导入"
			};
			WordTableToolService5.ShowWpfWindow(obj);
			return obj;
		}
		catch
		{
			return null;
		}
	}

	private static bool UpdateProgress(ProgressWindow P_0, int P_1, string P_2)
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

	private static bool IsCancelled(ProgressWindow P_0)
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

	private static int InterpolateProgress(int P_0, int P_1, int P_2, int P_3)
	{
		if (P_3 <= 0)
		{
			return P_1;
		}
		double num = Math.Max(0.0, Math.Min(1.0, (double)P_2 * 1.0 / (double)P_3));
		return P_0 + (int)Math.Round((double)(P_1 - P_0) * num);
	}

	private static bool ShowCancelledWarning()
	{
		LoggerInitializer.ShowWarning("Markdown 导入已取消，可使用 Word 撤销回退本次导入。", "IP_Assurance");
		return false;
	}

	private static void CloseProgressWindow(ProgressWindow P_0)
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

	private static string BuildSummaryMessage(MarkdownImportContext P_0)
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

	static MarkdownImportService()
	{
		SseStreamInitializer.InitializeRuntime();
		_markdownPipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
	}
}
