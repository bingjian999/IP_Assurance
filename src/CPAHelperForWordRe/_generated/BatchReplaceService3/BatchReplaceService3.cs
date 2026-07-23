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
using TableValidationService;
using BatchReplaceService;
using TableCellSpan;
using AiHelper_1;
using AiConfigBootstrap;
using BatchTableAdjustService;
using Helper_9;
using Helper_20;
using TableBorderConfig;
using WordAgentRuntimeGuard2;
using AiSseStreamService3;
using AiTargetBinder;
using AiHelper_21;
using ParagraphFormatConfig;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WordTableToolService2;
using RegexMatchResult;
using WordSearchResult;
using WordTableToolService3;
using Helper_4;
using TableCellModel;
using Helper_3;
using WordTableToolService4;
using DocumentLifecycleGuard;
using AiHelper_5;

namespace BatchReplaceService3;

internal sealed class BatchReplaceService3
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass101_0
	{
		public string OperationName;

		public Func<Microsoft.Office.Interop.Word.Application, AiHelper_5> ntwPnGtes4;

		public Stopwatch Timer;

		public _G_c__DisplayClass101_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 FmkPphZYfT(Microsoft.Office.Interop.Word.Application app)
		{
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return WordAgentRuntimeGuard2.CreateNotReadyError(text);
			}
			AiConfigBootstrap.LogInfo("[AI Tool][Word] Begin: " + OperationName);
			AiHelper_5 insertResult = ntwPnGtes4(app);
			Timer.Stop();
			AiConfigBootstrap.LogInfo("[AI Tool][Word] End: " + OperationName + "; Success=" + (insertResult?.success ?? false) + "; ElapsedMs=" + Timer.ElapsedMilliseconds);
			return insertResult;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass110_0
	{
		public Selection CurrentSelection;

		public _G_c__DisplayClass110_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetParagraphCount()
		{
			return CurrentSelection.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass112_0
	{
		public Document doc;

		public bool UseTrackChanges;

		public Func<AiHelper_5> ActionDelegate;

		public _G_c__DisplayClass112_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteWithTrackChanges()
		{
			bool trackRevisions = doc.TrackRevisions;
			try
			{
				doc.TrackRevisions = UseTrackChanges;
				return ActionDelegate();
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
		public Range RangeForTableCount;

		public Range TargetRange;

		public Document doc;

		public _G_c__DisplayClass114_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int kLKPFHqUgc()
		{
			return RangeForTableCount.Tables.Count;
		}

		internal string GetText()
		{
			return TargetRange.Text;
		}

		internal int GetRangeStart()
		{
			return TargetRange.Start;
		}

		internal int GetRangeEnd()
		{
			return TargetRange.End;
		}

		internal int GetTableCount()
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetDocumentFullName()
		{
			return doc.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass120_0
	{
		public Range RangeForTableCount;

		public Cell AnchorCell;

		public _G_c__DisplayClass120_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetTableCount()
		{
			return RangeForTableCount.Tables.Count;
		}

		internal int WoFPkInXyF()
		{
			return AnchorCell.Range.Start;
		}

		internal int GetRangeEnd()
		{
			return AnchorCell.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass124_0
	{
		public Document doc;

		public _G_c__DisplayClass124_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string BokARIDrEs()
		{
			return doc.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass129_0
	{
		public Table TargetTable;

		public _G_c__DisplayClass129_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetRowCount()
		{
			return TargetTable.Rows.Count;
		}

		internal int GetColumnCount()
		{
			return TargetTable.Columns.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass132_0
	{
		public Range RangeForTableCount;

		public _G_c__DisplayClass132_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetTableCount()
		{
			return RangeForTableCount.Tables.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass132_1
	{
		public Cell AnchorCell;

		public _G_c__DisplayClass132_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int mBsADRNVfJ()
		{
			return AnchorCell.Range.Start;
		}

		internal int GetRangeEnd()
		{
			return AnchorCell.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass138_0
	{
		public Document doc;

		public _G_c__DisplayClass138_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetDocumentFullName()
		{
			return doc.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass13_0
	{
		public int MaxCharLimit;

		public bool IncludeStatistics;

		public bool XVvAQYyUwY;

		public _G_c__DisplayClass13_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 RJvAIofXPq(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass13_1 CS_8_locals_9 = new _G_c__DisplayClass13_1();
			CS_8_locals_9.doc = GetActiveDocument(app);
			Selection selection = app.Selection;
			int num = ClampValue(MaxCharLimit, 240, 2000);
			return AiHelper_5.CreateSuccess("Word context read.", new
			{
				document = CS_8_locals_9.doc.Name,
				documentFullName = CS_8_locals_9.doc.FullName,
				pageCount = (IncludeStatistics ? new int?(ComputeIntValue(CS_8_locals_9.doc, WdStatistic.wdStatisticPages)) : ((int?)null)),
				wordCount = (IncludeStatistics ? new int?(ComputeIntValue(CS_8_locals_9.doc, WdStatistic.wdStatisticWords)) : ((int?)null)),
				statisticsIncluded = IncludeStatistics,
				paragraphCount = ComputeIntValue(() => CS_8_locals_9.doc.Paragraphs.Count),
				tableCount = ComputeIntValue(() => CS_8_locals_9.doc.Tables.Count),
				commentCount = ComputeIntValue(() => CS_8_locals_9.doc.Comments.Count),
				trackRevisions = CheckCondition(CS_8_locals_9.doc),
				selection = BuildResultObject(selection, XVvAQYyUwY, num)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass13_1
	{
		public Document doc;

		public _G_c__DisplayClass13_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetParagraphCount()
		{
			return doc.Paragraphs.Count;
		}

		internal int GetTableCount()
		{
			return doc.Tables.Count;
		}

		internal int GetCommentCount()
		{
			return doc.Comments.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass141_0
	{
		public Cell TargetCell;

		public _G_c__DisplayClass141_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetRangeText()
		{
			return TargetCell.Range.Text;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass143_0
	{
		public Table TableForXml;

		public _G_c__DisplayClass143_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetRangeOpenXml()
		{
			return TableForXml.Range.WordOpenXML;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass144_0
	{
		public int MergeCheckRow;

		public _G_c__DisplayClass144_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsRowInMergeRange(Helper_4 merge)
		{
			if (merge.StartRow <= MergeCheckRow)
			{
				return merge.EndRow >= MergeCheckRow;
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool MatchElementByName(XElement p)
		{
			return string.Equals(p.Attribute(WordNamespace + "name")?.Value, DojAYMESMP, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass148_0
	{
		public Document doc;

		public Range TargetRange;

		public string ReplacementText;

		public _G_c__DisplayClass148_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 joXAZFdTOi()
		{
			bool trackRevisions = doc.TrackRevisions;
			try
			{
				doc.TrackRevisions = true;
				string text = NormalizeText(TargetRange.Text);
				int start = TargetRange.Start;
				TargetRange.Text = ReplacementText ?? string.Empty;
				return AiHelper_5.CreateSuccess("Word range replaced with track changes.", new
				{
					document = doc.Name,
					documentFullName = doc.FullName,
					page = ComputeIntValue(TargetRange),
					rangeStart = start,
					oldCharacters = text.Length,
					newCharacters = (ReplacementText ?? string.Empty).Length,
					oldPreview = TruncateText(text, 240)
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

		public int TailParagraphCount;

		public int HeadingCount;

		public int MaxPreviewChars;

		public int MaxCharLimit;

		public _G_c__DisplayClass14_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 FormatParagraphs(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass14_1 CS_8_locals_10 = new _G_c__DisplayClass14_1();
			CS_8_locals_10.doc = GetActiveDocument(app);
			Selection selection = app.Selection;
			int num = ComputeIntValue(() => CS_8_locals_10.doc.Paragraphs.Count);
			int num2 = ClampValue(fYKASMsLjm, 8, 50);
			int num3 = ClampValue(TailParagraphCount, 4, 50);
			int num4 = ClampValue(HeadingCount, 50, 300);
			int num5 = ClampValue(MaxPreviewChars, 180, 1000);
			int num6 = ClampValue(MaxCharLimit, 240, 2000);
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
				if (!string.IsNullOrWhiteSpace(NormalizeText(paragraph.Range.Text)))
				{
					list.Add(BuildParagraphInfo(paragraph, num7, num5));
				}
			}
			for (int num8 = Math.Max(1, num - num3 + 1); num8 <= num; num8++)
			{
				Paragraph paragraph2 = CS_8_locals_10.doc.Paragraphs[num8];
				if (!string.IsNullOrWhiteSpace(NormalizeText(paragraph2.Range.Text)))
				{
					list2.Add(BuildParagraphInfo(paragraph2, num8, num5));
				}
			}
			for (int num9 = 1; num9 <= num; num9++)
			{
				if (list3.Count >= num4)
				{
					break;
				}
				Paragraph paragraph3 = CS_8_locals_10.doc.Paragraphs[num9];
				if (GetOutlineLevel(paragraph3) == 1 && !string.IsNullOrWhiteSpace(NormalizeText(paragraph3.Range.Text)))
				{
					list3.Add(BuildParagraphInfo(paragraph3, num9, num5));
				}
			}
			return AiHelper_5.CreateSuccess("Word document preview prepared.", new
			{
				document = CS_8_locals_10.doc.Name,
				documentFullName = CS_8_locals_10.doc.FullName,
				paragraphCount = num,
				tableCount = ComputeIntValue(() => CS_8_locals_10.doc.Tables.Count),
				commentCount = ComputeIntValue(() => CS_8_locals_10.doc.Comments.Count),
				trackRevisions = CheckCondition(CS_8_locals_10.doc),
				selection = BuildResultObject(selection, false, num6),
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int FZuAldQelb()
		{
			return doc.Paragraphs.Count;
		}

		internal int VmXANckOSX()
		{
			return doc.Tables.Count;
		}

		internal int GetCommentCount()
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetDocumentName()
		{
			return XbCACwggdo.Range.Document.Name;
		}

		internal string GetDocumentFullName()
		{
			return XbCACwggdo.Range.Document.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass158_0
	{
		public Table TargetTable;

		public _G_c__DisplayClass158_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetDocumentName()
		{
			return TargetTable.Range.Document.Name;
		}

		internal string GetDocumentFullName()
		{
			return TargetTable.Range.Document.FullName;
		}

		internal string GetTableTitle()
		{
			return TargetTable.Title;
		}

		internal string GetTableDescription()
		{
			return TargetTable.Descr;
		}

		internal string GetDocumentName()
		{
			return TargetTable.Range.Document.Name;
		}

		internal string wwjAcsiftb()
		{
			return TargetTable.Range.Document.FullName;
		}

		internal string GetTableTitle()
		{
			return TargetTable.Title;
		}

		internal string mrvAyFTqpY()
		{
			return TargetTable.Descr;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass159_0
	{
		public Document doc;

		public _G_c__DisplayClass159_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetParagraphCount()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass15_0
	{
		public int MaxCharLimit;

		public _G_c__DisplayClass15_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 gkxAhXRqiI(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Selection selection = app.Selection;
			if (selection == null || selection.Range == null)
			{
				return AiHelper_5.CreateError("当前没有可读取的 Word 选区。", "empty_selection");
			}
			int num = ClampValue(MaxCharLimit, 6000, 30000);
			string text = NormalizeText(selection.Range.Text);
			bool flag = text.Length > num;
			return AiHelper_5.CreateSuccess("Word selection preview prepared.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = ComputeIntValue(selection.Range),
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
		public Comment TargetComment;

		public _G_c__DisplayClass169_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetCommentAuthor()
		{
			return TargetComment.Author;
		}

		internal bool GetCommentDone()
		{
			return TargetComment.Done;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_0
	{
		public int bEEAWaNvfx;

		public int RangeEndPosition;

		public int MaxCharLimit;

		public _G_c__DisplayClass16_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ReadRange(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Range range = GetRangeByPosition(document, bEEAWaNvfx, RangeEndPosition);
			int num = ClampValue(MaxCharLimit, 30000, 30000);
			string text = NormalizeText(range.Text);
			bool flag = text.Length > num;
			return AiHelper_5.CreateSuccess("Word range read.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = ComputeIntValue(range),
				paragraphIndex = FindParagraphIndex(document, range.Start),
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
		public Comments CommentsCollection;

		public _G_c__DisplayClass170_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int sQqAxpEtin()
		{
			return CommentsCollection.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass171_0
	{
		public Comment TargetComment;

		public _G_c__DisplayClass171_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string VNXAzPAdJT()
		{
			return TargetComment.Author;
		}

		internal bool GetCommentDone()
		{
			return TargetComment.Done;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass173_0
	{
		public Document doc;

		public _G_c__DisplayClass173_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetCommentCount()
		{
			return doc.Comments.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass173_1
	{
		public Comments CommentsCollection;

		public _G_c__DisplayClass173_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetCount()
		{
			return CommentsCollection.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass174_0
	{
		public Document doc;

		public _G_c__DisplayClass174_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetCommentCount()
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetRangeText()
		{
			return HThvTPlNIo.Range.Text;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass17_0
	{
		public int NumericParameter;

		public int xYgvIDRxGK;

		public int MaxSnippetLength;

		public int MaxCharLimit;

		public _G_c__DisplayClass17_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ReadParagraphRange(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass17_1 CS_8_locals_5 = new _G_c__DisplayClass17_1();
			CS_8_locals_5.doc = GetActiveDocument(app);
			int num = ComputeIntValue(() => CS_8_locals_5.doc.Paragraphs.Count);
			int num2 = Math.Max(1, (NumericParameter <= 0) ? 1 : NumericParameter);
			if (num2 > num)
			{
				return AiHelper_5.CreateError("startParagraphIndex is out of range.", "invalid_arguments", new
				{
					totalParagraphs = num
				});
			}
			int num3;
			if (xYgvIDRxGK > 0)
			{
				if (xYgvIDRxGK < num2)
				{
					return AiHelper_5.CreateError("endParagraphIndex must be greater than or equal to startParagraphIndex.", "invalid_arguments");
				}
				num3 = Math.Min(num, xYgvIDRxGK);
			}
			else
			{
				int num4 = ClampValue(MaxSnippetLength, 20, 300);
				num3 = Math.Min(num, num2 + num4 - 1);
			}
			int num5 = ClampValue(MaxCharLimit, 1000, 5000);
			List<object> list = new List<object>();
			for (int num6 = num2; num6 <= num3; num6++)
			{
				list.Add(BuildParagraphInfo(CS_8_locals_5.doc.Paragraphs[num6], num6, num5));
			}
			return AiHelper_5.CreateSuccess("Word paragraphs read.", new
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int PqEvQuygdD()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass180_0
	{
		public Comment CommentForScope;

		public _G_c__DisplayClass180_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetCommentScope()
		{
			return CommentForScope.Scope.Text;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass181_0
	{
		public Comment CommentForDate;

		public _G_c__DisplayClass181_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string iANvJlsHhm()
		{
			return CommentForDate.Date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass183_0
	{
		public Comments CommentsCollection;

		public _G_c__DisplayClass183_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int ffIvUKbuZI()
		{
			return CommentsCollection.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass189_0
	{
		public Document doc;

		public Comment TargetComment;

		public _G_c__DisplayClass189_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string HlRvEAifbI()
		{
			return doc.FullName;
		}

		internal string GetDocumentName()
		{
			return doc.Name;
		}

		internal string GetCommentAuthor()
		{
			return TargetComment.Author;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass18_0
	{
		public int qdXvZGOPXC;

		public int TableCount;

		public bool IncludeBodyText;

		public _G_c__DisplayClass18_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 FormatParagraphs(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass18_1 CS_8_locals_5 = new _G_c__DisplayClass18_1();
			CS_8_locals_5.doc = GetActiveDocument(app);
			int num = ClampValue(qdXvZGOPXC, 300, 1000);
			int num2 = ClampValue(TableCount);
			int num3 = ComputeIntValue(() => CS_8_locals_5.doc.Paragraphs.Count);
			List<object> list = new List<object>();
			int num4 = 0;
			for (int num5 = 1; num5 <= num3; num5++)
			{
				if (list.Count >= num)
				{
					break;
				}
				Paragraph paragraph = CS_8_locals_5.doc.Paragraphs[num5];
				int num6 = GetOutlineLevel(paragraph);
				bool flag = num6 >= 1 && num6 <= 9;
				if ((flag || IncludeBodyText) && (!flag || num6 <= num2) && !string.IsNullOrWhiteSpace(NormalizeText(paragraph.Range.Text)))
				{
					if (flag)
					{
						num4++;
					}
					list.Add(BuildParagraphInfo(paragraph, num5, 240));
				}
			}
			return AiHelper_5.CreateSuccess("Word outline read.", new
			{
				document = CS_8_locals_5.doc.Name,
				documentFullName = CS_8_locals_5.doc.FullName,
				maxOutlineLevel = num2,
				includeBodyText = IncludeBodyText,
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int kRTvbnOjRj()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass193_0
	{
		public Table TargetTable;

		public _G_c__DisplayClass193_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetRangeStart()
		{
			return TargetTable.Range.Start;
		}

		internal int GetRangeEnd()
		{
			return TargetTable.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass194_0
	{
		public Selection KaavoKjFKG;

		public Microsoft.Office.Interop.Word.Application WordApplication;

		public Document doc;

		public _G_c__DisplayClass194_0()
		{
			SseStreamInitializer.InitializeRuntime();
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
			return WordApplication.ScreenUpdating;
		}

		internal int GetContent()
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int EhSvCUAjhB()
		{
			return NSNvOLlBYV.Start;
		}

		internal int GetRangeEnd()
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetContent()
		{
			return doc.Content.Start;
		}

		internal int GetContent()
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetParagraphCount()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass19_0
	{
		public string PxqveKcgAE;

		public int ParagraphNumber;

		public int ParagraphNumber;

		public string SearchPattern;

		public int kDLvhCZhco;

		public int MaxSnippetLength;

		public int MaxCharLimit;

		public int MaxSnippetLength;

		public int MaxSnippetLength;

		public _G_c__DisplayClass19_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ParagraphOperation(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass19_1 CS_8_locals_11 = new _G_c__DisplayClass19_1();
			CS_8_locals_11.doc = GetActiveDocument(app);
			Paragraph paragraph = GetParagraphByIndex(CS_8_locals_11.doc, PxqveKcgAE, ParagraphNumber, ParagraphNumber, SearchPattern);
			if (paragraph == null)
			{
				return AiHelper_5.CreateError("未找到匹配的标题段落。", "not_found");
			}
			int num = ((ParagraphNumber > 0) ? ParagraphNumber : FindParagraphIndex(CS_8_locals_11.doc, paragraph.Range.Start).GetValueOrDefault());
			int num2 = GetOutlineLevel(paragraph);
			if (num2 < 1 || num2 > 9)
			{
				return AiHelper_5.CreateError("目标段落不是 Word 标题/大纲段落。", "invalid_arguments", new
				{
					headingParagraphIndex = num
				});
			}
			int num3 = ComputeIntValue(() => CS_8_locals_11.doc.Paragraphs.Count);
			int num4 = num3;
			for (int num5 = num + 1; num5 <= num3; num5++)
			{
				int num6 = GetOutlineLevel(CS_8_locals_11.doc.Paragraphs[num5]);
				if (num6 >= 1 && num6 <= num2)
				{
					num4 = num5 - 1;
					break;
				}
			}
			int num7 = Math.Max(0, kDLvhCZhco);
			int num8 = ClampValue(MaxSnippetLength, 200, 1000);
			int num9 = ClampValue(MaxCharLimit, 1000, 5000);
			int num10 = ClampValue(MaxSnippetLength, 80, 500);
			int num11 = ClampValue(MaxSnippetLength, 20, 100);
			int start = paragraph.Range.Start;
			int end = CS_8_locals_11.doc.Paragraphs[num4].Range.End;
			List<Helper_20> list = new List<Helper_20>();
			for (int num12 = num; num12 <= num4; num12++)
			{
				Paragraph paragraph2 = CS_8_locals_11.doc.Paragraphs[num12];
				if (!IsRangeInTable(paragraph2.Range))
				{
					list.Add(new Helper_20
					{
						Type = "paragraph",
						RangeStart = paragraph2.Range.Start,
						Data = BuildParagraphInfo(paragraph2, num12, num9)
					});
				}
			}
			for (int num13 = 1; num13 <= CS_8_locals_11.doc.Tables.Count; num13++)
			{
				Table table = CS_8_locals_11.doc.Tables[num13];
				if (table.Range.Start >= start && table.Range.End <= end)
				{
					list.Add(new Helper_20
					{
						Type = "table",
						RangeStart = table.Range.Start,
						Data = WhFgjeRETB(table, num13, num10, num11)
					});
				}
			}
			list.Sort((Helper_20 left, Helper_20 right) => left.RangeStart.CompareTo(right.RangeStart));
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
				Helper_20 jaDcyWQtOojM0IicNQ8 = list[num15];
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
			return AiHelper_5.CreateSuccess("Word section read.", new
			{
				document = CS_8_locals_11.doc.Name,
				documentFullName = CS_8_locals_11.doc.FullName,
				heading = BuildParagraphInfo(paragraph, num, 500),
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetParagraphCount()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass209_0
	{
		public Style TargetStyle;

		public _G_c__DisplayClass209_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string vfUvWndrUx()
		{
			return TargetStyle.NameLocal;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass20_0
	{
		public int XVXvxrblxn;

		public int umIvdDfpSj;

		public int MaxSnippetLength;

		public int MaxSnippetLength;

		public _G_c__DisplayClass20_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ReadTable(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass20_1 CS_8_locals_7 = new _G_c__DisplayClass20_1();
			CS_8_locals_7.doc = GetActiveDocument(app);
			int num = ComputeIntValue(() => CS_8_locals_7.doc.Tables.Count);
			if (num == 0)
			{
				return AiHelper_5.CreateSuccess("No tables found.", new
				{
					document = CS_8_locals_7.doc.Name,
					documentFullName = CS_8_locals_7.doc.FullName,
					totalTables = 0,
					tables = new object[0]
				});
			}
			int num2 = ((XVXvxrblxn <= 0) ? 1 : XVXvxrblxn);
			int num3 = ((XVXvxrblxn > 0) ? XVXvxrblxn : Math.Min(num, ClampValue(umIvdDfpSj, 5, 100)));
			if (num2 < 1 || num2 > num)
			{
				return AiHelper_5.CreateError("tableIndex is out of range.", "invalid_arguments", new
				{
					totalTables = num
				});
			}
			int num4 = ClampValue(MaxSnippetLength, 80, 500);
			int num5 = ClampValue(MaxSnippetLength, 20, 100);
			List<object> list = new List<object>();
			for (int num6 = num2; num6 <= num3; num6++)
			{
				list.Add(WhFgjeRETB(CS_8_locals_7.doc.Tables[num6], num6, num4, num5));
			}
			return AiHelper_5.CreateSuccess("Word tables read.", new
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetTableCount()
		{
			return doc.Tables.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass21_0
	{
		public int MaxSnippetLength;

		public int MaxSnippetLength;

		public int TjwWuYNRhv;

		public bool BooleanFlag;

		public _G_c__DisplayClass21_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 dAwWBlBdqL(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass21_1 CS_8_locals_6 = new _G_c__DisplayClass21_1();
			CS_8_locals_6.doc = GetActiveDocument(app);
			int num = ClampValue(MaxSnippetLength, 200, 1000);
			int num2 = ClampValue(MaxSnippetLength, 120, 1000);
			int num3 = ((TjwWuYNRhv < 0) ? 20 : Math.Min(TjwWuYNRhv, 200));
			List<object> list = new List<object>();
			int num4 = ComputeIntValue(() => CS_8_locals_6.doc.Comments.Count);
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
					list.Add(qXYglKDlsW(CS_8_locals_6.doc, comment, BooleanFlag, num2, num3));
				}
			}
			return AiHelper_5.CreateSuccess("Word comments read.", new
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetCommentCount()
		{
			return doc.Comments.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass22_0
	{
		public string ReplyText;

		public string CommentToken;

		public int CommentIndex;

		public string ExpectedScopeText;

		public string ExpectedScopeText;

		public _G_c__DisplayClass22_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteWordOperation(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass22_1 CS_8_locals_34 = new _G_c__DisplayClass22_1();
			CS_8_locals_34.rvpWKhLSmL = this;
			if (string.IsNullOrWhiteSpace(ReplyText))
			{
				return AiHelper_5.CreateError("replyText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_34.doc = GetActiveDocument(app);
			AiHelper_5 insertResult = (string.IsNullOrWhiteSpace(CommentToken) ? ExecuteOperation(CS_8_locals_34.doc, CommentIndex, out CS_8_locals_34.TargetComment, out CS_8_locals_34.FUKWrYRDvi) : CLCgCUGOui(CS_8_locals_34.doc, CommentToken, CommentIndex, out CS_8_locals_34.TargetComment, out CS_8_locals_34.FUKWrYRDvi));
			if (insertResult != null)
			{
				return insertResult;
			}
			string text = GetCommentText(CS_8_locals_34.TargetComment);
			string text2 = XPEgcZYWAO(CS_8_locals_34.FUKWrYRDvi);
			string text3 = NormalizeScopeText(ExpectedScopeText);
			string text4 = NormalizeScopeText(ExpectedScopeText);
			if (!string.IsNullOrWhiteSpace(text3) && !string.Equals(NormalizeScopeText(text), text3, StringComparison.Ordinal))
			{
				return AiHelper_5.CreateError("当前批注内容与 expectedCommentText 不一致。请重新读取批注后再回复。", "comment_target_mismatch", new
				{
					commentToken = SanitizeToken(CommentToken),
					commentIndex = CommentIndex,
					expectedCommentText = text3,
					currentCommentText = text
				});
			}
			if (!string.IsNullOrWhiteSpace(text4) && !gxWgapxYhe(text2, text4))
			{
				return AiHelper_5.CreateError("当前批注原文与 expectedScopeText 不一致。请重新读取批注后再回复。", "comment_target_mismatch", new
				{
					commentToken = SanitizeToken(CommentToken),
					commentIndex = CommentIndex,
					expectedScopeText = text4,
					currentScopeText = TruncateText(text2, 500)
				});
			}
			CS_8_locals_34.ComputedRange = GetCommentAnchorRange(CS_8_locals_34.FUKWrYRDvi) ?? GetCommentScopeRange(CS_8_locals_34.FUKWrYRDvi);
			if (CS_8_locals_34.ComputedRange == null)
			{
				return AiHelper_5.CreateError("无法定位批注对应的正文范围。请重新读取批注后再回复。", "comment_anchor_unavailable", new
				{
					commentToken = SanitizeToken(CommentToken),
					commentIndex = CommentIndex,
					threadCommentIndex = GetCommentThreadIndex(CS_8_locals_34.FUKWrYRDvi)
				});
			}
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ValidateRange(app, CS_8_locals_34.doc, CS_8_locals_34.ComputedRange);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_34.ReplyText = ReplyText.Trim();
			return oBKTTgZY41(app, "AI 回复批注", delegate
			{
				try
				{
					Comments comments = DOYgOEfqSy(CS_8_locals_34.FUKWrYRDvi);
					if (comments == null)
					{
						return AiHelper_5.CreateError("replyText must not be empty.", "invalid_arguments", new
						{
							commentToken = SanitizeToken(CS_8_locals_34.rvpWKhLSmL.CommentToken),
							commentIndex = CS_8_locals_34.rvpWKhLSmL.CommentIndex,
							threadCommentIndex = GetCommentThreadIndex(CS_8_locals_34.FUKWrYRDvi)
						});
					}
					object Text = CS_8_locals_34.ReplyText;
					Comment comment = comments.Add(CS_8_locals_34.ComputedRange, ref Text);
					if (comment == null)
					{
						return AiHelper_5.CreateError("当前批注内容与 expectedCommentText 不一致。请重新读取批注后再回复。", "comment_target_mismatch", new
						{
							commentToken = SanitizeToken(CS_8_locals_34.rvpWKhLSmL.CommentToken),
							commentIndex = CS_8_locals_34.rvpWKhLSmL.CommentIndex,
							threadCommentIndex = GetCommentThreadIndex(CS_8_locals_34.FUKWrYRDvi)
						});
					}
					return AiHelper_5.CreateSuccess("当前批注原文与 expectedScopeText 不一致。请重新读取批注后再回复。", BuildCommentReplyInfo(CS_8_locals_34.doc, CS_8_locals_34.FUKWrYRDvi, CS_8_locals_34.TargetComment, comment, CS_8_locals_34.ReplyText));
				}
				catch (Exception ex)
				{
					return AiHelper_5.CreateExceptionError("comment_target_mismatch", "无法定位批注对应的正文范围。请重新读取批注后再回复。", ex, new
					{
						commentToken = SanitizeToken(CS_8_locals_34.rvpWKhLSmL.CommentToken),
						commentIndex = CS_8_locals_34.rvpWKhLSmL.CommentIndex,
						threadCommentIndex = GetCommentThreadIndex(CS_8_locals_34.FUKWrYRDvi)
					});
				}
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass22_1
	{
		public Comment FUKWrYRDvi;

		public string ReplyText;

		public Range ComputedRange;

		public Document doc;

		public Comment TargetComment;

		public _G_c__DisplayClass22_0 rvpWKhLSmL;

		public _G_c__DisplayClass22_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ReplyToComment()
		{
			try
			{
				Comments comments = DOYgOEfqSy(FUKWrYRDvi);
				if (comments == null)
				{
					return AiHelper_5.CreateError("当前 Word/WPS 不支持通过 COM 回复批注。", "comment_reply_not_supported", new
					{
						commentToken = SanitizeToken(rvpWKhLSmL.CommentToken),
						commentIndex = rvpWKhLSmL.CommentIndex,
						threadCommentIndex = GetCommentThreadIndex(FUKWrYRDvi)
					});
				}
				object Text = ReplyText;
				Comment comment = comments.Add(ComputedRange, ref Text);
				if (comment == null)
				{
					return AiHelper_5.CreateError("Word 未返回新增的批注回复。", "comment_reply_failed", new
					{
						commentToken = SanitizeToken(rvpWKhLSmL.CommentToken),
						commentIndex = rvpWKhLSmL.CommentIndex,
						threadCommentIndex = GetCommentThreadIndex(FUKWrYRDvi)
					});
				}
				return AiHelper_5.CreateSuccess("Word comment reply added.", BuildCommentReplyInfo(doc, FUKWrYRDvi, TargetComment, comment, ReplyText));
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateExceptionError("Word comment reply failed", "comment_reply_not_supported", ex, new
				{
					commentToken = SanitizeToken(rvpWKhLSmL.CommentToken),
					commentIndex = rvpWKhLSmL.CommentIndex,
					threadCommentIndex = GetCommentThreadIndex(FUKWrYRDvi)
				});
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_0
	{
		public int HeadingCount;

		public string MatchMode;

		public int OutlineLevel;

		public string SearchQuery;

		public _G_c__DisplayClass23_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 SearchParagraphs(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass23_1 CS_8_locals_7 = new _G_c__DisplayClass23_1();
			CS_8_locals_7.doc = GetActiveDocument(app);
			int num = ClampValue(HeadingCount, 50, 300);
			string text = (MatchMode ?? "contains").Trim().ToLowerInvariant();
			List<object> list = new List<object>();
			int num2 = ComputeIntValue(() => CS_8_locals_7.doc.Paragraphs.Count);
			for (int num3 = 1; num3 <= num2; num3++)
			{
				if (list.Count >= num)
				{
					break;
				}
				Paragraph paragraph = CS_8_locals_7.doc.Paragraphs[num3];
				int num4 = GetOutlineLevel(paragraph);
				if (num4 >= 1 && num4 <= 9 && (OutlineLevel <= 0 || num4 == OutlineLevel))
				{
					string text2 = NormalizeText(paragraph.Range.Text);
					if (OYJgKddkFp(text2, SearchQuery, text))
					{
						list.Add(new
						{
							document = CS_8_locals_7.doc.Name,
							documentFullName = CS_8_locals_7.doc.FullName,
							page = ComputeIntValue(paragraph.Range),
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
			return AiHelper_5.CreateSuccess("Word heading find completed.", new
			{
				document = CS_8_locals_7.doc.Name,
				documentFullName = CS_8_locals_7.doc.FullName,
				query = (SearchQuery ?? string.Empty),
				outlineLevel = ((OutlineLevel <= 0) ? ((int?)null) : new int?(OutlineLevel)),
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetParagraphCount()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass24_0
	{
		public string kJMWMFbwEh;

		public int MaxResultCount;

		public bool BooleanFlag;

		public bool PFZWwdLEQF;

		public _G_c__DisplayClass24_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ValidateTextOperation(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(kJMWMFbwEh))
			{
				return AiHelper_5.CreateError("text must not be empty.", "invalid_arguments");
			}
			Document document = GetActiveDocument(app);
			int num = ClampValue(MaxResultCount, 100, 500);
			List<WordSearchResult> list = BuildList(app, document, kJMWMFbwEh, BooleanFlag, PFZWwdLEQF, num);
			return AiHelper_5.CreateSuccess("Word text range find completed.", BuildResultObject(document, list, num));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass25_0
	{
		public string IOPWLBITxB;

		public int MaxResultCount;

		public bool EyLWlEVNRV;

		public _G_c__DisplayClass25_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 SearchDocument(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(IOPWLBITxB))
			{
				return AiHelper_5.CreateError("pattern must not be empty.", "invalid_arguments");
			}
			Document document = GetActiveDocument(app);
			int num = ClampValue(MaxResultCount, 100, 500);
			List<RegexMatchResult> list = FindRegexMatches(document, IOPWLBITxB, EyLWlEVNRV, num);
			return AiHelper_5.CreateSuccess("Word regex find completed.", BuildRegexResults(document, list, num));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass26_0
	{
		public string EJdWmMjUeA;

		public int MaxResultCount;

		public bool MatchCase;

		public _G_c__DisplayClass26_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ValidateTextOperation(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(EJdWmMjUeA))
			{
				return AiHelper_5.CreateError("text must not be empty.", "invalid_arguments");
			}
			Document document = GetActiveDocument(app);
			int num = ClampValue(MaxResultCount, 100, 500);
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
					object MatchCase = MatchCase;
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
					list.Add(BuildTableInfo(document, CS_8_locals_4.sEvWprZlaY, i, duplicate));
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
			return AiHelper_5.CreateSuccess("Word table text find completed.", new
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetRangeEnd()
		{
			return sEvWprZlaY.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass27_0
	{
		public int RangeEndPosition;

		public int RangeEndPosition;

		public _G_c__DisplayClass27_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 SelectRange(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Range range = GetRangeByPosition(document, RangeEndPosition, RangeEndPosition);
			document.Activate();
			range.Select();
			return AiHelper_5.CreateSuccess("Word range selected.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = ComputeIntValue(range),
				rangeStart = range.Start,
				rangeEnd = range.End
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_0
	{
		public int TableIndex;

		public _G_c__DisplayClass28_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 EditTable(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			if (TableIndex < 1 || TableIndex > document.Tables.Count)
			{
				return AiHelper_5.CreateError("tableIndex is out of range.", "invalid_arguments", new
				{
					totalTables = document.Tables.Count
				});
			}
			Table table = document.Tables[TableIndex];
			document.Activate();
			table.Range.Select();
			return AiHelper_5.CreateSuccess("Word table selected.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = TableIndex,
				page = ComputeIntValue(table.Range),
				rangeStart = table.Range.Start,
				rangeEnd = table.Range.End
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass29_0
	{
		public string CommentText;

		public _G_c__DisplayClass29_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 zQhWespjjC(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass29_1 CS_8_locals_13 = new _G_c__DisplayClass29_1();
			CS_8_locals_13.DTFWhrapJW = this;
			if (string.IsNullOrWhiteSpace(CommentText))
			{
				return AiHelper_5.CreateError("commentText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_13.doc = GetActiveDocument(app);
			CS_8_locals_13.CurrentSelection = app.Selection;
			if (CS_8_locals_13.CurrentSelection == null || CS_8_locals_13.CurrentSelection.Range == null || string.IsNullOrWhiteSpace(NormalizeText(CS_8_locals_13.CurrentSelection.Range.Text)))
			{
				return AiHelper_5.CreateError("当前没有可批注的正文选区。请先选中正文，或用 find_word_text 获取真实 Range 后调用 add_word_comment_at_range。", "empty_selection");
			}
			if (!IsRangeValid(CS_8_locals_13.CurrentSelection.Range))
			{
				return AiHelper_5.CreateError("当前选区不在正文区域，可能选中了批注或批注窗格。请先选中正文，或用 find_word_text 获取真实 Range 后调用 add_word_comment_at_range。", "selection_not_in_main_document");
			}
			return oBKTTgZY41(app, "AI 添加批注", delegate
			{
				Comments comments = CS_8_locals_13.doc.Comments;
				Range range = CS_8_locals_13.CurrentSelection.Range;
				object Text = CS_8_locals_13.DTFWhrapJW.CommentText.Trim();
				Comment comment = comments.Add(range, ref Text);
				return AiHelper_5.CreateSuccess("commentText must not be empty.", BuildCommentAddedInfo(CS_8_locals_13.doc, CS_8_locals_13.CurrentSelection.Range, comment.Index, CS_8_locals_13.DTFWhrapJW.CommentText));
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass29_1
	{
		public Document doc;

		public Selection CurrentSelection;

		public _G_c__DisplayClass29_0 DTFWhrapJW;

		public _G_c__DisplayClass29_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 MRrWXOwniT()
		{
			Comments comments = doc.Comments;
			Range range = CurrentSelection.Range;
			object Text = DTFWhrapJW.CommentText.Trim();
			Comment comment = comments.Add(range, ref Text);
			return AiHelper_5.CreateSuccess("Word comment added.", BuildCommentAddedInfo(doc, CurrentSelection.Range, comment.Index, DTFWhrapJW.CommentText));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_0
	{
		public string CommentText;

		public int bHXWPpRCjJ;

		public int WKMWApZUrG;

		public _G_c__DisplayClass30_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 CommentOperation(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass30_1 CS_8_locals_12 = new _G_c__DisplayClass30_1();
			CS_8_locals_12.ClosureScope = this;
			if (string.IsNullOrWhiteSpace(CommentText))
			{
				return AiHelper_5.CreateError("commentText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_12.doc = GetActiveDocument(app);
			CS_8_locals_12.ComputedRange = GetRangeByPosition(CS_8_locals_12.doc, bHXWPpRCjJ, WKMWApZUrG);
			AiHelper_5 insertResult = ValidateRange(app, CS_8_locals_12.doc, CS_8_locals_12.ComputedRange);
			if (insertResult != null)
			{
				return insertResult;
			}
			return oBKTTgZY41(app, "AI 添加批注", delegate
			{
				Comments comments = CS_8_locals_12.doc.Comments;
				Range range = CS_8_locals_12.ComputedRange;
				object Text = CS_8_locals_12.ClosureScope.CommentText.Trim();
				Comment comment = comments.Add(range, ref Text);
				return AiHelper_5.CreateSuccess("commentText must not be empty.", BuildCommentAddedInfo(CS_8_locals_12.doc, CS_8_locals_12.ComputedRange, comment.Index, CS_8_locals_12.ClosureScope.CommentText));
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_1
	{
		public Document doc;

		public Range ComputedRange;

		public _G_c__DisplayClass30_0 ClosureScope;

		public _G_c__DisplayClass30_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 AddComment()
		{
			Comments comments = doc.Comments;
			Range range = ComputedRange;
			object Text = ClosureScope.CommentText.Trim();
			Comment comment = comments.Add(range, ref Text);
			return AiHelper_5.CreateSuccess("Word comment added.", BuildCommentAddedInfo(doc, ComputedRange, comment.Index, ClosureScope.CommentText));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass31_0
	{
		public string JbiWxBXGfL;

		public int rNUWdaMass;

		public int NumericParameter;

		public int NumericParameter;

		public _G_c__DisplayClass31_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 DepWkJtShM(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass31_1 CS_8_locals_12 = new _G_c__DisplayClass31_1();
			CS_8_locals_12.ClosureScope = this;
			if (string.IsNullOrWhiteSpace(JbiWxBXGfL))
			{
				return AiHelper_5.CreateError("commentText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_12.doc = GetActiveDocument(app);
			AiHelper_5 insertResult = JXpTldftkV(CS_8_locals_12.doc, rNUWdaMass, NumericParameter, NumericParameter, out CS_8_locals_12.ComputedRange);
			if (insertResult != null)
			{
				return insertResult;
			}
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ValidateRange(app, CS_8_locals_12.doc, CS_8_locals_12.ComputedRange);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			return oBKTTgZY41(app, "AI 添加批注", delegate
			{
				Comments comments = CS_8_locals_12.doc.Comments;
				Range range = CS_8_locals_12.ComputedRange;
				object Text = CS_8_locals_12.ClosureScope.JbiWxBXGfL.Trim();
				Comment comment = comments.Add(range, ref Text);
				return AiHelper_5.CreateSuccess("commentText must not be empty.", BuildCommentAddedInfo(CS_8_locals_12.doc, CS_8_locals_12.ComputedRange, comment.Index, CS_8_locals_12.ClosureScope.JbiWxBXGfL));
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass31_1
	{
		public Document doc;

		public Range ComputedRange;

		public _G_c__DisplayClass31_0 ClosureScope;

		public _G_c__DisplayClass31_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 AddComment()
		{
			Comments comments = doc.Comments;
			Range range = ComputedRange;
			object Text = ClosureScope.JbiWxBXGfL.Trim();
			Comment comment = comments.Add(range, ref Text);
			return AiHelper_5.CreateSuccess("Word comment added.", BuildCommentAddedInfo(doc, ComputedRange, comment.Index, ClosureScope.JbiWxBXGfL));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass32_0
	{
		public string CommentText;

		public int TableIndex;

		public int RowIndex;

		public int ColumnIndex;

		public _G_c__DisplayClass32_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 CommentOperation(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass32_1 CS_8_locals_19 = new _G_c__DisplayClass32_1();
			CS_8_locals_19.ClosureScope = this;
			if (string.IsNullOrWhiteSpace(CommentText))
			{
				return AiHelper_5.CreateError("commentText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_19.doc = GetActiveDocument(app);
			CS_8_locals_19.TargetCell = DOQTmyyLCk(CS_8_locals_19.doc, TableIndex, RowIndex, ColumnIndex);
			AiHelper_5 insertResult = ValidateRange(app, CS_8_locals_19.doc, CS_8_locals_19.TargetCell.Range);
			if (insertResult != null)
			{
				return insertResult;
			}
			return oBKTTgZY41(app, "AI 添加表格批注", delegate
			{
				Comments comments = CS_8_locals_19.doc.Comments;
				Range range = CS_8_locals_19.TargetCell.Range;
				object Text = CS_8_locals_19.ClosureScope.CommentText.Trim();
				Comment comment = comments.Add(range, ref Text);
				return AiHelper_5.CreateSuccess("commentText must not be empty.", new
				{
					document = CS_8_locals_19.doc.Name,
					documentFullName = CS_8_locals_19.doc.FullName,
					commentIndex = comment.Index,
					tableIndex = CS_8_locals_19.ClosureScope.TableIndex,
					rowIndex = CS_8_locals_19.ClosureScope.RowIndex,
					columnIndex = CS_8_locals_19.ClosureScope.ColumnIndex,
					page = ComputeIntValue(CS_8_locals_19.TargetCell.Range),
					rangeStart = CS_8_locals_19.TargetCell.Range.Start,
					rangeEnd = CS_8_locals_19.TargetCell.Range.End,
					targetPreview = TruncateText(NormalizeText(CS_8_locals_19.TargetCell.Range.Text), 240),
					comment = CS_8_locals_19.ClosureScope.CommentText.Trim()
				});
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass32_1
	{
		public Document doc;

		public Cell TargetCell;

		public _G_c__DisplayClass32_0 ClosureScope;

		public _G_c__DisplayClass32_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 AddComment()
		{
			Comments comments = doc.Comments;
			Range range = TargetCell.Range;
			object Text = ClosureScope.CommentText.Trim();
			Comment comment = comments.Add(range, ref Text);
			return AiHelper_5.CreateSuccess("Word table cell comment added.", new
			{
				document = doc.Name,
				documentFullName = doc.FullName,
				commentIndex = comment.Index,
				tableIndex = ClosureScope.TableIndex,
				rowIndex = ClosureScope.RowIndex,
				columnIndex = ClosureScope.ColumnIndex,
				page = ComputeIntValue(TargetCell.Range),
				rangeStart = TargetCell.Range.Start,
				rangeEnd = TargetCell.Range.End,
				targetPreview = TruncateText(NormalizeText(TargetCell.Range.Text), 240),
				comment = ClosureScope.CommentText.Trim()
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass33_0
	{
		public int ParagraphIndex;

		public string InsertPosition;

		public string InsertText;

		public bool UseTrackChanges;

		public _G_c__DisplayClass33_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteWordOperation(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass33_1 CS_8_locals_32 = new _G_c__DisplayClass33_1();
			CS_8_locals_32.ClosureScope = this;
			CS_8_locals_32.doc = GetActiveDocument(app);
			CS_8_locals_32.TargetParagraph = GetParagraphByIndex(CS_8_locals_32.doc, ParagraphIndex);
			CS_8_locals_32.InsertPosition = (InsertPosition ?? "after").Trim().ToLowerInvariant();
			if (CS_8_locals_32.InsertPosition != "before" && CS_8_locals_32.InsertPosition != "after")
			{
				return AiHelper_5.CreateError("position 只支持 before 或 after。", "invalid_arguments", new
				{
					position = InsertPosition
				});
			}
			CS_8_locals_32.InsertText = InsertText ?? string.Empty;
			return PPXTOUDVLE(CS_8_locals_32.doc, UseTrackChanges, delegate
			{
				Range duplicate = CS_8_locals_32.TargetParagraph.Range.Duplicate;
				if (CS_8_locals_32.InsertPosition == "AI 插入段落")
				{
					int start = duplicate.Start;
					object Direction = WdCollapseDirection.wdCollapseStart;
					duplicate.Collapse(ref Direction);
					duplicate.InsertBefore(CS_8_locals_32.InsertText + "after");
					return AiHelper_5.CreateSuccess("before", new
					{
						document = CS_8_locals_32.doc.Name,
						documentFullName = CS_8_locals_32.doc.FullName,
						paragraphIndex = CS_8_locals_32.ClosureScope.ParagraphIndex,
						position = CS_8_locals_32.InsertPosition,
						page = ComputeIntValue(CS_8_locals_32.TargetParagraph.Range),
						rangeStart = start,
						useTrackChanges = CS_8_locals_32.ClosureScope.UseTrackChanges,
						characters = CS_8_locals_32.InsertText.Length,
						textPreview = TruncateText(CS_8_locals_32.InsertText, 240)
					});
				}
				int num = Math.Max(CS_8_locals_32.TargetParagraph.Range.Start, CS_8_locals_32.TargetParagraph.Range.End - 1);
				duplicate.SetRange(num, num);
				duplicate.InsertAfter("after" + CS_8_locals_32.InsertText);
				return AiHelper_5.CreateSuccess("position 只支持 before 或 after。", new
				{
					document = CS_8_locals_32.doc.Name,
					documentFullName = CS_8_locals_32.doc.FullName,
					paragraphIndex = CS_8_locals_32.ClosureScope.ParagraphIndex,
					position = CS_8_locals_32.InsertPosition,
					page = ComputeIntValue(CS_8_locals_32.TargetParagraph.Range),
					rangeStart = num,
					useTrackChanges = CS_8_locals_32.ClosureScope.UseTrackChanges,
					characters = CS_8_locals_32.InsertText.Length,
					textPreview = TruncateText(CS_8_locals_32.InsertText, 240)
				});
			}, app, CS_8_locals_32.TargetParagraph.Range, "invalid_arguments");
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass33_1
	{
		public Paragraph TargetParagraph;

		public string InsertPosition;

		public string InsertText;

		public Document doc;

		public _G_c__DisplayClass33_0 ClosureScope;

		public _G_c__DisplayClass33_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteOperation()
		{
			Range duplicate = TargetParagraph.Range.Duplicate;
			if (InsertPosition == "before")
			{
				int start = duplicate.Start;
				object Direction = WdCollapseDirection.wdCollapseStart;
				duplicate.Collapse(ref Direction);
				duplicate.InsertBefore(InsertText + "\\r");
				return AiHelper_5.CreateSuccess("Word paragraph inserted.", new
				{
					document = doc.Name,
					documentFullName = doc.FullName,
					paragraphIndex = ClosureScope.ParagraphIndex,
					position = InsertPosition,
					page = ComputeIntValue(TargetParagraph.Range),
					rangeStart = start,
					useTrackChanges = ClosureScope.UseTrackChanges,
					characters = InsertText.Length,
					textPreview = TruncateText(InsertText, 240)
				});
			}
			int num = Math.Max(TargetParagraph.Range.Start, TargetParagraph.Range.End - 1);
			duplicate.SetRange(num, num);
			duplicate.InsertAfter("\\r" + InsertText);
			return AiHelper_5.CreateSuccess("Word paragraph inserted.", new
			{
				document = doc.Name,
				documentFullName = doc.FullName,
				paragraphIndex = ClosureScope.ParagraphIndex,
				position = InsertPosition,
				page = ComputeIntValue(TargetParagraph.Range),
				rangeStart = num,
				useTrackChanges = ClosureScope.UseTrackChanges,
				characters = InsertText.Length,
				textPreview = TruncateText(InsertText, 240)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass34_0
	{
		public int OutlineLevel;

		public int ParagraphIndex;

		public int ParagraphIndex;

		public _G_c__DisplayClass34_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 SetParagraphOutlineLevel(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass34_1 CS_8_locals_29 = new _G_c__DisplayClass34_1();
			CS_8_locals_29.ClosureScope = this;
			if (OutlineLevel < 0 || OutlineLevel > 9)
			{
				return AiHelper_5.CreateError("outlineLevel 必须为 0..9；0 表示正文，1..9 表示标题级次。", "invalid_arguments", new
				{
					outlineLevel = OutlineLevel
				});
			}
			if (ParagraphIndex < 0 || ParagraphIndex < 0)
			{
				return AiHelper_5.CreateError("startParagraphIndex 和 endParagraphIndex 不能为负数。", "invalid_arguments", new
				{
					startParagraphIndex = ParagraphIndex,
					endParagraphIndex = ParagraphIndex
				});
			}
			if (ParagraphIndex == 0 && ParagraphIndex > 0)
			{
				return AiHelper_5.CreateError("startParagraphIndex=0 表示当前选区，此时 endParagraphIndex 必须为 0。", "invalid_arguments", new
				{
					startParagraphIndex = ParagraphIndex,
					endParagraphIndex = ParagraphIndex
				});
			}
			if (ParagraphIndex > 0 && ParagraphIndex > 0 && ParagraphIndex < ParagraphIndex)
			{
				return AiHelper_5.CreateError("endParagraphIndex must be greater than or equal to startParagraphIndex.", "invalid_arguments", new
				{
					startParagraphIndex = ParagraphIndex,
					endParagraphIndex = ParagraphIndex
				});
			}
			CS_8_locals_29.doc = GetActiveDocument(app);
			CS_8_locals_29.doc.Activate();
			int num = ComputeIntValue(() => CS_8_locals_29.doc.Paragraphs.Count);
			if (ParagraphIndex > num)
			{
				return AiHelper_5.CreateError("startParagraphIndex is out of range.", "invalid_arguments", new
				{
					startParagraphIndex = ParagraphIndex,
					totalParagraphs = num
				});
			}
			if (ParagraphIndex > num)
			{
				return AiHelper_5.CreateError("endParagraphIndex is out of range.", "invalid_arguments", new
				{
					endParagraphIndex = ParagraphIndex,
					totalParagraphs = num
				});
			}
			CS_8_locals_29.ParagraphList = CollectParagraphs(app, CS_8_locals_29.doc, ParagraphIndex, ParagraphIndex);
			if (CS_8_locals_29.ParagraphList.Count == 0)
			{
				return AiHelper_5.CreateError("当前没有可设置大纲级次的段落。", "no_paragraph_selection", new
				{
					startParagraphIndex = ParagraphIndex,
					endParagraphIndex = ParagraphIndex
				});
			}
			AiHelper_5 insertResult = ValidateRange(app, CS_8_locals_29.doc, CS_8_locals_29.ParagraphList[0].Paragraph.Range);
			if (insertResult != null)
			{
				return insertResult;
			}
			CS_8_locals_29.OutlineLevelValue = ClampOutlineLevel(OutlineLevel);
			CS_8_locals_29.ResultList = new List<object>();
			CS_8_locals_29.ChangedCount = 0;
			CS_8_locals_29.OutlineLevel = 0;
			DyITDXSmDr(app, "AI 设置段落大纲级次", delegate
			{
				foreach (AiHelper_1 item in CS_8_locals_29.ParagraphList)
				{
					Paragraph paragraph = item.Paragraph;
					int num2 = ClampOutlineLevel(GetOutlineLevel(paragraph));
					string styleName = GetParagraphStyleName(paragraph);
					string excerpt = TruncateText(NormalizeText(paragraph.Range.Text), 160);
					bool flag = false;
					bool flag2 = false;
					string text = string.Empty;
					try
					{
						paragraph.OutlineLevel = (WdOutlineLevel)CS_8_locals_29.OutlineLevelValue;
						int num3 = ClampOutlineLevel(GetOutlineLevel(paragraph));
						flag2 = num3 == CS_8_locals_29.ClosureScope.OutlineLevel;
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
					int afterOutlineLevel = ClampOutlineLevel(GetOutlineLevel(paragraph));
					if (flag)
					{
						CS_8_locals_29.ChangedCount++;
					}
					if (!flag2)
					{
						CS_8_locals_29.OutlineLevel++;
					}
					CS_8_locals_29.ResultList.Add(new
					{
						paragraphIndex = item.ParagraphIndex,
						rangeStart = paragraph.Range.Start,
						rangeEnd = paragraph.Range.End,
						page = ComputeIntValue(paragraph.Range),
						styleName = styleName,
						beforeOutlineLevel = num2,
						targetOutlineLevel = CS_8_locals_29.ClosureScope.OutlineLevel,
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
				startParagraphIndex = ParagraphIndex,
				endParagraphIndex = ParagraphIndex,
				targetOutlineLevel = OutlineLevel,
				targetOutlineKind = ((OutlineLevel == 0) ? "body" : "未能设置任何段落的大纲级次。"),
				totalParagraphs = CS_8_locals_29.ParagraphList.Count,
				changedCount = CS_8_locals_29.ChangedCount,
				failedCount = CS_8_locals_29.OutlineLevel,
				paragraphs = CS_8_locals_29.ResultList
			};
			if (CS_8_locals_29.OutlineLevel == CS_8_locals_29.ParagraphList.Count)
			{
				return AiHelper_5.CreateError("outline_level_not_applied", "Word paragraph outline level updated.", anon);
			}
			return AiHelper_5.CreateSuccess((CS_8_locals_29.OutlineLevel > 0) ? "Word paragraph outline level updated with failures." : "outlineLevel 必须为 0..9；0 表示正文，1..9 表示标题级次。", anon);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass34_1
	{
		public Document doc;

		public List<AiHelper_1> ParagraphList;

		public int OutlineLevelValue;

		public int ChangedCount;

		public int OutlineLevel;

		public List<object> ResultList;

		public _G_c__DisplayClass34_0 ClosureScope;

		public _G_c__DisplayClass34_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetParagraphCount()
		{
			return doc.Paragraphs.Count;
		}

		internal void ExecuteAction()
		{
			foreach (AiHelper_1 item in ParagraphList)
			{
				Paragraph paragraph = item.Paragraph;
				int num = ClampOutlineLevel(GetOutlineLevel(paragraph));
				string styleName = GetParagraphStyleName(paragraph);
				string excerpt = TruncateText(NormalizeText(paragraph.Range.Text), 160);
				bool flag = false;
				bool flag2 = false;
				string text = string.Empty;
				try
				{
					paragraph.OutlineLevel = (WdOutlineLevel)OutlineLevelValue;
					int num2 = ClampOutlineLevel(GetOutlineLevel(paragraph));
					flag2 = num2 == ClosureScope.OutlineLevel;
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
				int afterOutlineLevel = ClampOutlineLevel(GetOutlineLevel(paragraph));
				if (flag)
				{
					ChangedCount++;
				}
				if (!flag2)
				{
					OutlineLevel++;
				}
				ResultList.Add(new
				{
					paragraphIndex = item.ParagraphIndex,
					rangeStart = paragraph.Range.Start,
					rangeEnd = paragraph.Range.End,
					page = ComputeIntValue(paragraph.Range),
					styleName = styleName,
					beforeOutlineLevel = num,
					targetOutlineLevel = ClosureScope.OutlineLevel,
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
		public string OperationMode;

		public string ExpectedPreviewToken;

		public string ConfigJson;

		public int RangeStart;

		public int RangeEnd;

		public bool AllowHeaderEdit;

		public bool UseTrackChanges;

		public _G_c__DisplayClass35_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 PreviewChanges(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass35_1 CS_8_locals_41 = new _G_c__DisplayClass35_1();
			CS_8_locals_41.ClosureScope = this;
			string a = (OperationMode ?? "preview").Trim().ToLowerInvariant();
			if (!string.Equals(a, "preview", StringComparison.Ordinal) && !string.Equals(a, "execute", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateError("mode 仅支持 preview 或 execute。", "invalid_arguments", new
				{
					mode = OperationMode
				});
			}
			if (string.Equals(a, "execute", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(ExpectedPreviewToken))
			{
				return AiHelper_5.CreateError("执行模型填表前必须先调用 mode=preview，并把 previewToken 传入 execute。", "preview_required");
			}
			List<TableCellModel> list;
			AiHelper_5 insertResult = XIPTkGpqwW(ConfigJson, out list);
			if (insertResult != null)
			{
				return insertResult;
			}
			CS_8_locals_41.doc = GetActiveDocument(app);
			Range range;
			try
			{
				range = GetRangeByPosition(CS_8_locals_41.doc, RangeStart, RangeEnd);
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateError("rangeStart/rangeEnd 超出文档范围或顺序无效。", "invalid_arguments", new
				{
					rangeStart = RangeStart,
					rangeEnd = RangeEnd,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ExecuteOperation(range, list, out CS_8_locals_41.CellChangeList);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_41.PreviewToken = BuildPreviewToken(CS_8_locals_41.doc, RangeStart, RangeEnd, CS_8_locals_41.CellChangeList);
			object obj = iLJTdpgWxW(CS_8_locals_41.doc, RangeStart, RangeEnd, AllowHeaderEdit, UseTrackChanges, CS_8_locals_41.PreviewToken, CS_8_locals_41.CellChangeList);
			if (string.Equals(a, "preview", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateSuccess("Model table cell fill preview prepared.", obj);
			}
			if (CS_8_locals_41.CellChangeList.Count((AiHelper_21 change) => !change.Writable) > 0)
			{
				return AiHelper_5.CreateError("当前填表请求中存在不可写单元格，已停止执行。请根据 preview 结果修正后重试。", "model_cell_not_writable", obj);
			}
			if (!ValidatePreviewToken(CS_8_locals_41.PreviewToken, ExpectedPreviewToken))
			{
				return AiHelper_5.CreateError("当前表格旧值或坐标与预览结果不一致，已停止执行。请重新 preview 后再 execute。", "preview_mismatch", new
				{
					rangeStart = RangeStart,
					rangeEnd = RangeEnd,
					expectedPreviewToken = ExpectedPreviewToken,
					currentPreviewToken = CS_8_locals_41.PreviewToken,
					preview = obj
				});
			}
			Range range2 = ((CS_8_locals_41.CellChangeList.Count > 0 && CS_8_locals_41.CellChangeList[0].Cell != null) ? GetCellRange(CS_8_locals_41.CellChangeList[0].Cell) : range);
			return PPXTOUDVLE(CS_8_locals_41.doc, UseTrackChanges, delegate
			{
				List<object> list2 = new List<object>();
				int num = 0;
				for (int i = 0; i < CS_8_locals_41.CellChangeList.Count; i++)
				{
					_G_c__DisplayClass35_2 CS_8_locals_43 = new _G_c__DisplayClass35_2();
					CS_8_locals_43.CellChange = CS_8_locals_41.CellChangeList[i];
					bool flag2;
					string text;
					bool flag = bIRgTubXiW(CS_8_locals_43.CellChange.Cell, CS_8_locals_43.CellChange.NewText, out flag2, out text);
					if (flag && flag2)
					{
						num++;
					}
					list2.Add(new
					{
						requestIndex = CS_8_locals_43.CellChange.RequestIndex,
						localTableIndex = CS_8_locals_43.CellChange.LocalTableIndex,
						rowIndex = CS_8_locals_43.CellChange.RowIndex,
						columnIndex = CS_8_locals_43.CellChange.ColumnIndex,
						isHeader = CS_8_locals_43.CellChange.IsHeader,
						page = ComputeIntValue(CS_8_locals_43.CellChange.Cell.Range),
						rangeStart = Ex5TMxi7X1(() => CS_8_locals_43.CellChange.Cell.Range.Start, CS_8_locals_43.CellChange.RangeStart),
						rangeEnd = Ex5TMxi7X1(() => CS_8_locals_43.CellChange.Cell.Range.End, CS_8_locals_43.CellChange.RangeEnd),
						oldText = CS_8_locals_43.CellChange.OldText,
						newText = CS_8_locals_43.CellChange.NewText,
						changed = (flag && flag2),
						success = flag,
						error = (flag ? null : text)
					});
				}
				return AiHelper_5.CreateSuccess("AI 模型填表", new
				{
					document = CS_8_locals_41.doc.Name,
					documentFullName = CS_8_locals_41.doc.FullName,
					rangeStart = CS_8_locals_41.ClosureScope.RangeStart,
					rangeEnd = CS_8_locals_41.ClosureScope.RangeEnd,
					totalRequests = CS_8_locals_41.CellChangeList.Count,
					changed = num,
					useTrackChanges = CS_8_locals_41.ClosureScope.UseTrackChanges,
					allowHeaderEdit = CS_8_locals_41.ClosureScope.AllowHeaderEdit,
					previewToken = CS_8_locals_41.PreviewToken,
					results = list2
				});
			}, app, range2, "preview");
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass35_1
	{
		public List<AiHelper_21> CellChangeList;

		public Document doc;

		public string PreviewToken;

		public _G_c__DisplayClass35_0 ClosureScope;

		public _G_c__DisplayClass35_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteOperation()
		{
			List<object> list = new List<object>();
			int num = 0;
			for (int i = 0; i < CellChangeList.Count; i++)
			{
				_G_c__DisplayClass35_2 CS_8_locals_15 = new _G_c__DisplayClass35_2();
				CS_8_locals_15.CellChange = CellChangeList[i];
				bool flag2;
				string text;
				bool flag = bIRgTubXiW(CS_8_locals_15.CellChange.Cell, CS_8_locals_15.CellChange.NewText, out flag2, out text);
				if (flag && flag2)
				{
					num++;
				}
				list.Add(new
				{
					requestIndex = CS_8_locals_15.CellChange.RequestIndex,
					localTableIndex = CS_8_locals_15.CellChange.LocalTableIndex,
					rowIndex = CS_8_locals_15.CellChange.RowIndex,
					columnIndex = CS_8_locals_15.CellChange.ColumnIndex,
					isHeader = CS_8_locals_15.CellChange.IsHeader,
					page = ComputeIntValue(CS_8_locals_15.CellChange.Cell.Range),
					rangeStart = Ex5TMxi7X1(() => CS_8_locals_15.CellChange.Cell.Range.Start, CS_8_locals_15.CellChange.RangeStart),
					rangeEnd = Ex5TMxi7X1(() => CS_8_locals_15.CellChange.Cell.Range.End, CS_8_locals_15.CellChange.RangeEnd),
					oldText = CS_8_locals_15.CellChange.OldText,
					newText = CS_8_locals_15.CellChange.NewText,
					changed = (flag && flag2),
					success = flag,
					error = (flag ? null : text)
				});
			}
			return AiHelper_5.CreateSuccess("Model table cell fill executed.", new
			{
				document = doc.Name,
				documentFullName = doc.FullName,
				rangeStart = ClosureScope.RangeStart,
				rangeEnd = ClosureScope.RangeEnd,
				totalRequests = CellChangeList.Count,
				changed = num,
				useTrackChanges = ClosureScope.UseTrackChanges,
				allowHeaderEdit = ClosureScope.AllowHeaderEdit,
				previewToken = PreviewToken,
				results = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass35_2
	{
		public AiHelper_21 CellChange;

		public _G_c__DisplayClass35_2()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetCell()
		{
			return CellChange.Cell.Range.Start;
		}

		internal int GetCell()
		{
			return CellChange.Cell.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass36_0
	{
		public string OperationMode;

		public string PositionParam;

		public int InsertCount;

		public string ExpectedPreviewToken;

		public int RangeStart;

		public int RangeEnd;

		public int InsertCount;

		public int InsertCount;

		public bool UseTrackChanges;

		public string AnchorText;

		public _G_c__DisplayClass36_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 PreviewChanges(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass36_1 CS_8_locals_42 = new _G_c__DisplayClass36_1();
			CS_8_locals_42.gZUkBpLoZF = this;
			CS_8_locals_42.WordApplication = app;
			string a = (OperationMode ?? "preview").Trim().ToLowerInvariant();
			if (!string.Equals(a, "preview", StringComparison.Ordinal) && !string.Equals(a, "execute", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateError("mode 仅支持 preview 或 execute。", "invalid_arguments", new
				{
					mode = OperationMode
				});
			}
			string text = ParsePosition(PositionParam);
			if (text == null)
			{
				return AiHelper_5.CreateError("position 仅支持 before 或 after。", "invalid_arguments", new
				{
					position = PositionParam
				});
			}
			if (InsertCount < 1 || InsertCount > 20)
			{
				return AiHelper_5.CreateError("count 必须在 1 到 20 之间。", "invalid_arguments", new
				{
					count = InsertCount,
					min = 1,
					max = 20
				});
			}
			if (string.Equals(a, "execute", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(ExpectedPreviewToken))
			{
				return AiHelper_5.CreateError("执行模型表格插行前必须先调用 mode=preview，并把 previewToken 传入 execute。", "preview_required");
			}
			CS_8_locals_42.doc = GetActiveDocument(CS_8_locals_42.WordApplication);
			Range range;
			try
			{
				range = GetRangeByPosition(CS_8_locals_42.doc, RangeStart, RangeEnd);
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateError("rangeStart/rangeEnd 超出文档范围或顺序无效。", "invalid_arguments", new
				{
					rangeStart = RangeStart,
					rangeEnd = RangeEnd,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			AiHelper_5 insertResult = ExecuteOperation(range, InsertCount, InsertCount, text, InsertCount, UseTrackChanges, AnchorText, out CS_8_locals_42.TableToolService);
			if (insertResult != null)
			{
				return insertResult;
			}
			CS_8_locals_42.PreviewToken = lKeTPQlpbN(CS_8_locals_42.doc, RangeStart, RangeEnd, CS_8_locals_42.TableToolService);
			object obj = fYyThhstYU(CS_8_locals_42.doc, RangeStart, RangeEnd, CS_8_locals_42.PreviewToken, CS_8_locals_42.TableToolService);
			if (string.Equals(a, "preview", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateSuccess("Model table row insert preview prepared.", obj);
			}
			if (!ValidatePreviewToken(CS_8_locals_42.PreviewToken, ExpectedPreviewToken))
			{
				return AiHelper_5.CreateError("当前表格锚点或结构与预览结果不一致，已停止执行。请重新 preview 后再 execute。", "preview_mismatch", new
				{
					rangeStart = RangeStart,
					rangeEnd = RangeEnd,
					expectedPreviewToken = ExpectedPreviewToken,
					currentPreviewToken = CS_8_locals_42.PreviewToken,
					preview = obj
				});
			}
			return PPXTOUDVLE(CS_8_locals_42.doc, UseTrackChanges, delegate
			{
				if (!M4PTA9V6B2(CS_8_locals_42.WordApplication, CS_8_locals_42.TableToolService.AnchorCell, CS_8_locals_42.TableToolService.Position, CS_8_locals_42.TableToolService.Count, out var error))
				{
					return AiHelper_5.CreateError("AI 表格插行", "preview", new
					{
						rangeStart = CS_8_locals_42.gZUkBpLoZF.RangeStart,
						rangeEnd = CS_8_locals_42.gZUkBpLoZF.RangeEnd,
						LocalTableIndex = CS_8_locals_42.TableToolService.LocalTableIndex,
						AnchorRowIndex = CS_8_locals_42.TableToolService.AnchorRowIndex,
						Position = CS_8_locals_42.TableToolService.Position,
						Count = CS_8_locals_42.TableToolService.Count,
						error = error
					});
				}
				HbPTWYrAup(CS_8_locals_42.TableToolService.Table, out var rowsAfter, out var columnsAfter);
				return AiHelper_5.CreateSuccess("preview", new
				{
					document = CS_8_locals_42.doc.Name,
					documentFullName = CS_8_locals_42.doc.FullName,
					rangeStart = CS_8_locals_42.gZUkBpLoZF.RangeStart,
					rangeEnd = CS_8_locals_42.gZUkBpLoZF.RangeEnd,
					localTableIndex = CS_8_locals_42.TableToolService.LocalTableIndex,
					anchorRowIndex = CS_8_locals_42.TableToolService.AnchorRowIndex,
					position = CS_8_locals_42.TableToolService.Position,
					count = CS_8_locals_42.TableToolService.Count,
					useTrackChanges = CS_8_locals_42.gZUkBpLoZF.UseTrackChanges,
					previewToken = CS_8_locals_42.PreviewToken,
					rowsBefore = CS_8_locals_42.TableToolService.RowsBefore,
					rowsAfter = rowsAfter,
					columnsBefore = CS_8_locals_42.TableToolService.ColumnsBefore,
					columnsAfter = columnsAfter,
					insertedRows = BuildList(CS_8_locals_42.TableToolService),
					anchor = BuildAnchorInfo(CS_8_locals_42.TableToolService)
				});
			}, CS_8_locals_42.WordApplication, CS_8_locals_42.TableToolService.AnchorCell.Range, "execute");
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass36_1
	{
		public Microsoft.Office.Interop.Word.Application WordApplication;

		public WordTableToolService2 TableToolService;

		public Document doc;

		public string PreviewToken;

		public _G_c__DisplayClass36_0 gZUkBpLoZF;

		public _G_c__DisplayClass36_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 EditTableCells()
		{
			if (!M4PTA9V6B2(WordApplication, TableToolService.AnchorCell, TableToolService.Position, TableToolService.Count, out var error))
			{
				return AiHelper_5.CreateError("表格插行失败。", "table_row_insert_failed", new
				{
					rangeStart = gZUkBpLoZF.RangeStart,
					rangeEnd = gZUkBpLoZF.RangeEnd,
					LocalTableIndex = TableToolService.LocalTableIndex,
					AnchorRowIndex = TableToolService.AnchorRowIndex,
					Position = TableToolService.Position,
					Count = TableToolService.Count,
					error = error
				});
			}
			HbPTWYrAup(TableToolService.Table, out var rowsAfter, out var columnsAfter);
			return AiHelper_5.CreateSuccess("Model table row insert executed.", new
			{
				document = doc.Name,
				documentFullName = doc.FullName,
				rangeStart = gZUkBpLoZF.RangeStart,
				rangeEnd = gZUkBpLoZF.RangeEnd,
				localTableIndex = TableToolService.LocalTableIndex,
				anchorRowIndex = TableToolService.AnchorRowIndex,
				position = TableToolService.Position,
				count = TableToolService.Count,
				useTrackChanges = gZUkBpLoZF.UseTrackChanges,
				previewToken = PreviewToken,
				rowsBefore = TableToolService.RowsBefore,
				rowsAfter = rowsAfter,
				columnsBefore = TableToolService.ColumnsBefore,
				columnsAfter = columnsAfter,
				insertedRows = BuildList(TableToolService),
				anchor = BuildAnchorInfo(TableToolService)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass37_0
	{
		public string OperationMode;

		public string tBmkugaqPB;

		public int fnLkDwNHkT;

		public int FAJkTvvVfq;

		public string ExpectedPreviewToken;

		public int RangeStart;

		public int FHWkIpxSEj;

		public bool UseTrackChanges;

		public bool jdmkHkXOfG;

		public _G_c__DisplayClass37_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 PreviewChanges(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass37_1 CS_8_locals_48 = new _G_c__DisplayClass37_1();
			CS_8_locals_48.ClosureScope = this;
			string a = (OperationMode ?? "preview").Trim().ToLowerInvariant();
			if (!string.Equals(a, "preview", StringComparison.Ordinal) && !string.Equals(a, "execute", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateError("mode 仅支持 preview 或 execute。", "invalid_arguments", new
				{
					mode = OperationMode
				});
			}
			string text = NormalizeConfigKey(tBmkugaqPB);
			if (text == null)
			{
				return AiHelper_5.CreateError("placement 仅支持 replace_empty_paragraph、before 或 after。", "invalid_arguments", new
				{
					placement = tBmkugaqPB
				});
			}
			if (fnLkDwNHkT < 1 || fnLkDwNHkT > 200)
			{
				return AiHelper_5.CreateError("rows 必须在 1 到 200 之间。", "invalid_arguments", new
				{
					rows = fnLkDwNHkT,
					min = 1,
					max = 200
				});
			}
			if (FAJkTvvVfq < 1 || FAJkTvvVfq > 63)
			{
				return AiHelper_5.CreateError("columns 必须在 1 到 63 之间。", "invalid_arguments", new
				{
					columns = FAJkTvvVfq,
					min = 1,
					max = 63
				});
			}
			if (string.Equals(a, "execute", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(ExpectedPreviewToken))
			{
				return AiHelper_5.CreateError("执行插入表格前必须先调用 mode=preview，并把 previewToken 传入 execute。", "preview_required");
			}
			CS_8_locals_48.doc = GetActiveDocument(app);
			Range range;
			try
			{
				range = GetRangeByPosition(CS_8_locals_48.doc, RangeStart, FHWkIpxSEj);
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateError("rangeStart/rangeEnd 超出文档范围或顺序无效。", "invalid_arguments", new
				{
					rangeStart = RangeStart,
					rangeEnd = FHWkIpxSEj,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			AiHelper_5 insertResult = ExecuteTableEdit(CS_8_locals_48.doc, range, fnLkDwNHkT, FAJkTvvVfq, text, UseTrackChanges, jdmkHkXOfG, out CS_8_locals_48.TableEditService);
			if (insertResult != null)
			{
				return insertResult;
			}
			CS_8_locals_48.PreviewToken = BIJTcpAmqJ(CS_8_locals_48.doc, RangeStart, FHWkIpxSEj, CS_8_locals_48.TableEditService);
			object obj = BuildResultObject(CS_8_locals_48.doc, RangeStart, FHWkIpxSEj, CS_8_locals_48.PreviewToken, CS_8_locals_48.TableEditService);
			if (string.Equals(a, "preview", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateSuccess("Word table insert preview prepared.", obj);
			}
			if (!ValidatePreviewToken(CS_8_locals_48.PreviewToken, ExpectedPreviewToken))
			{
				return AiHelper_5.CreateError("当前插表位置与预览结果不一致，已停止执行。请重新 preview 后再 execute。", "preview_mismatch", new
				{
					rangeStart = RangeStart,
					rangeEnd = FHWkIpxSEj,
					expectedPreviewToken = ExpectedPreviewToken,
					currentPreviewToken = CS_8_locals_48.PreviewToken,
					preview = obj
				});
			}
			return PPXTOUDVLE(CS_8_locals_48.doc, UseTrackChanges, delegate
			{
				_G_c__DisplayClass37_2 CS_8_locals_52 = new _G_c__DisplayClass37_2();
				if (!psHTenZWYL(CS_8_locals_48.doc, CS_8_locals_48.TableEditService, out CS_8_locals_52.TargetTable, out var error))
				{
					return AiHelper_5.CreateError("AI 插入表格", "preview", new
					{
						rangeStart = CS_8_locals_48.ClosureScope.RangeStart,
						rangeEnd = CS_8_locals_48.ClosureScope.FHWkIpxSEj,
						Rows = CS_8_locals_48.TableEditService.Rows,
						Columns = CS_8_locals_48.TableEditService.Columns,
						Placement = CS_8_locals_48.TableEditService.Placement,
						error = error
					});
				}
				bool flag = false;
				string text2 = null;
				if (CS_8_locals_48.TableEditService.AdjustAfterInsert)
				{
					flag = EOXTyRsfXn(CS_8_locals_52.TargetTable, out text2);
					if (!flag)
					{
						return AiHelper_5.CreateError("preview", "execute", new
						{
							rangeStart = CS_8_locals_48.ClosureScope.RangeStart,
							rangeEnd = CS_8_locals_48.ClosureScope.FHWkIpxSEj,
							Rows = CS_8_locals_48.TableEditService.Rows,
							Columns = CS_8_locals_48.TableEditService.Columns,
							Placement = CS_8_locals_48.TableEditService.Placement,
							tableIndex = GetTableIndex(CS_8_locals_48.doc, CS_8_locals_52.TargetTable),
							tableRangeStart = Ex5TMxi7X1(() => CS_8_locals_52.TargetTable.Range.Start, 0),
							tableRangeEnd = Ex5TMxi7X1(() => CS_8_locals_52.TargetTable.Range.End, 0),
							error = text2
						});
					}
				}
				int tableIndex = GetTableIndex(CS_8_locals_48.doc, CS_8_locals_52.TargetTable);
				int num = Ex5TMxi7X1(() => CS_8_locals_52.TargetTable.Range.Start, 0);
				int num2 = Ex5TMxi7X1(() => CS_8_locals_52.TargetTable.Range.End, 0);
				HbPTWYrAup(CS_8_locals_52.TargetTable, out var num3, out var num4);
				return AiHelper_5.CreateSuccess("mode 仅支持 preview 或 execute。", new
				{
					document = CS_8_locals_48.doc.Name,
					documentFullName = CS_8_locals_48.doc.FullName,
					rangeStart = CS_8_locals_48.ClosureScope.RangeStart,
					rangeEnd = CS_8_locals_48.ClosureScope.FHWkIpxSEj,
					placement = CS_8_locals_48.TableEditService.Placement,
					rows = ((num3 > 0) ? num3 : CS_8_locals_48.TableEditService.Rows),
					columns = ((num4 > 0) ? num4 : CS_8_locals_48.TableEditService.Columns),
					requestedRows = CS_8_locals_48.TableEditService.Rows,
					requestedColumns = CS_8_locals_48.TableEditService.Columns,
					useTrackChanges = CS_8_locals_48.ClosureScope.UseTrackChanges,
					adjustAfterInsert = CS_8_locals_48.TableEditService.AdjustAfterInsert,
					adjusted = flag,
					adjustError = text2,
					previewToken = CS_8_locals_48.PreviewToken,
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
			}, app, CS_8_locals_48.TableEditService.FocusRange, "invalid_arguments");
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass37_1
	{
		public Document doc;

		public WordTableToolService3 TableEditService;

		public string PreviewToken;

		public _G_c__DisplayClass37_0 ClosureScope;

		public _G_c__DisplayClass37_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 InsertTableRow()
		{
			_G_c__DisplayClass37_2 CS_8_locals_9 = new _G_c__DisplayClass37_2();
			if (!psHTenZWYL(doc, TableEditService, out CS_8_locals_9.TargetTable, out var error))
			{
				return AiHelper_5.CreateError("插入 Word 表格失败。", "table_insert_failed", new
				{
					rangeStart = ClosureScope.RangeStart,
					rangeEnd = ClosureScope.FHWkIpxSEj,
					Rows = TableEditService.Rows,
					Columns = TableEditService.Columns,
					Placement = TableEditService.Placement,
					error = error
				});
			}
			bool flag = false;
			string text = null;
			if (TableEditService.AdjustAfterInsert)
			{
				flag = EOXTyRsfXn(CS_8_locals_9.TargetTable, out text);
				if (!flag)
				{
					return AiHelper_5.CreateError("表格已插入，但一键表格调整失败。", "table_inserted_adjust_failed", new
					{
						rangeStart = ClosureScope.RangeStart,
						rangeEnd = ClosureScope.FHWkIpxSEj,
						Rows = TableEditService.Rows,
						Columns = TableEditService.Columns,
						Placement = TableEditService.Placement,
						tableIndex = GetTableIndex(doc, CS_8_locals_9.TargetTable),
						tableRangeStart = Ex5TMxi7X1(() => CS_8_locals_9.TargetTable.Range.Start, 0),
						tableRangeEnd = Ex5TMxi7X1(() => CS_8_locals_9.TargetTable.Range.End, 0),
						error = text
					});
				}
			}
			int tableIndex = GetTableIndex(doc, CS_8_locals_9.TargetTable);
			int num = Ex5TMxi7X1(() => CS_8_locals_9.TargetTable.Range.Start, 0);
			int num2 = Ex5TMxi7X1(() => CS_8_locals_9.TargetTable.Range.End, 0);
			HbPTWYrAup(CS_8_locals_9.TargetTable, out var num3, out var num4);
			return AiHelper_5.CreateSuccess("Word table inserted.", new
			{
				document = doc.Name,
				documentFullName = doc.FullName,
				rangeStart = ClosureScope.RangeStart,
				rangeEnd = ClosureScope.FHWkIpxSEj,
				placement = TableEditService.Placement,
				rows = ((num3 > 0) ? num3 : TableEditService.Rows),
				columns = ((num4 > 0) ? num4 : TableEditService.Columns),
				requestedRows = TableEditService.Rows,
				requestedColumns = TableEditService.Columns,
				useTrackChanges = ClosureScope.UseTrackChanges,
				adjustAfterInsert = TableEditService.AdjustAfterInsert,
				adjusted = flag,
				adjustError = text,
				previewToken = PreviewToken,
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
		public Table TargetTable;

		public _G_c__DisplayClass37_2()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetRangeStart()
		{
			return TargetTable.Range.Start;
		}

		internal int GetRangeEnd()
		{
			return TargetTable.Range.End;
		}

		internal int GetRangeStart()
		{
			return TargetTable.Range.Start;
		}

		internal int jhEkEvllsj()
		{
			return TargetTable.Range.End;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass38_0
	{
		public int RangeEndPosition;

		public int SeWkYUegMC;

		public string TlKkZRlAoO;

		public _G_c__DisplayClass38_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteTableEdit(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Range range = GetRangeByPosition(document, RangeEndPosition, SeWkYUegMC);
			return ExecuteOperation(app, document, range, TlKkZRlAoO ?? string.Empty);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass39_0
	{
		public string ConfigJson;

		public _G_c__DisplayClass39_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 HnYkfgiwLF(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Selection selection = app.Selection;
			if (selection == null || selection.Range == null || string.IsNullOrWhiteSpace(NormalizeText(selection.Range.Text)))
			{
				return AiHelper_5.CreateError("当前没有可替换的正文选区。请先选中正文，或用 find_word_text 获取真实 Range 后使用 Range 替换工具。", "empty_selection");
			}
			if (!IsRangeValid(selection.Range))
			{
				return AiHelper_5.CreateError("当前选区不在正文区域，可能选中了批注或批注窗格。请先选中正文，或用 find_word_text 获取真实 Range 后使用 Range 替换工具。", "selection_not_in_main_document");
			}
			return ExecuteOperation(app, document, selection.Range, ConfigJson ?? string.Empty);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass40_0
	{
		public string FindText;

		public string PibkwEgMgL;

		public bool wQVktjGfvi;

		public bool bfxkLTOfxK;

		public bool UseTrackChanges;

		public int ExpectedCount;

		public int MaxMatchesIgnored;

		public _G_c__DisplayClass40_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 SearchDocument(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass40_1 CS_8_locals_34 = new _G_c__DisplayClass40_1();
			CS_8_locals_34.obZkGStNVx = this;
			CS_8_locals_34.cQAkoUnyRF = app;
			if (string.IsNullOrEmpty(FindText))
			{
				return AiHelper_5.CreateError("findText must not be empty.", "invalid_arguments");
			}
			CS_8_locals_34.doc = GetActiveDocument(CS_8_locals_34.cQAkoUnyRF);
			Document document = CS_8_locals_34.doc;
			object Start = CS_8_locals_34.doc.Content.Start;
			object End = Math.Min(CS_8_locals_34.doc.Content.End, CS_8_locals_34.doc.Content.Start + 1);
			Range range = document.Range(ref Start, ref End);
			AiHelper_5 insertResult = ValidateRange(CS_8_locals_34.cQAkoUnyRF, CS_8_locals_34.doc, range);
			if (insertResult != null)
			{
				return insertResult;
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
					find.Text = CS_8_locals_34.obZkGStNVx.FindText;
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
					return AiHelper_5.CreateSuccess("findText must not be empty.", new
					{
						document = CS_8_locals_34.doc.Name,
						documentFullName = CS_8_locals_34.doc.FullName,
						findText = CS_8_locals_34.obZkGStNVx.FindText,
						replaceText = (CS_8_locals_34.obZkGStNVx.PibkwEgMgL ?? string.Empty),
						matchCase = CS_8_locals_34.obZkGStNVx.wQVktjGfvi,
						wholeWord = CS_8_locals_34.obZkGStNVx.bfxkLTOfxK,
						useTrackChanges = true,
						requestedUseTrackChanges = CS_8_locals_34.obZkGStNVx.UseTrackChanges,
						forcedTrackChanges = true,
						replaceMethod = "invalid_arguments",
						expectedMatchCount = CS_8_locals_34.obZkGStNVx.ExpectedCount,
						replacedCountKnown = false,
						previewRequired = false,
						maxMatchesIgnored = CS_8_locals_34.obZkGStNVx.MaxMatchesIgnored
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 SearchDocument()
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
				find.Text = obZkGStNVx.FindText;
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
				return AiHelper_5.CreateSuccess("Batch replace executed.", new
				{
					document = doc.Name,
					documentFullName = doc.FullName,
					findText = obZkGStNVx.FindText,
					replaceText = (obZkGStNVx.PibkwEgMgL ?? string.Empty),
					matchCase = obZkGStNVx.wQVktjGfvi,
					wholeWord = obZkGStNVx.bfxkLTOfxK,
					useTrackChanges = true,
					requestedUseTrackChanges = obZkGStNVx.UseTrackChanges,
					forcedTrackChanges = true,
					replaceMethod = "word_find_replace_all",
					expectedMatchCount = obZkGStNVx.ExpectedCount,
					replacedCountKnown = false,
					previewRequired = false,
					maxMatchesIgnored = obZkGStNVx.MaxMatchesIgnored
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
			SseStreamInitializer.InitializeRuntime();
		}

		internal int vdckCjHjSK()
		{
			return doc.Comments.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass42_0
	{
		public Microsoft.Office.Interop.Word.Application WordApplication;

		public _G_c__DisplayClass42_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetSelection()
		{
			return WordApplication.Selection.Tables.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass43_0
	{
		public Microsoft.Office.Interop.Word.Application WordApplication;

		public _G_c__DisplayClass43_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetSelection()
		{
			return WordApplication.Selection.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass45_0
	{
		public Dictionary<string, object> UpVkclndys;

		public _G_c__DisplayClass45_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal object GetDictValue(string item)
		{
			return GetDictValue(UpVkclndys, item);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass46_0
	{
		public int TableIndex;

		public _G_c__DisplayClass46_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 UjgkeDHLMq(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass46_1 CS_8_locals_26 = new _G_c__DisplayClass46_1();
			Document document = GetActiveDocument(app);
			CS_8_locals_26.TargetTable = GetTableByIndex(app, document, TableIndex);
			int tableIndex = GetTableIndex(document, CS_8_locals_26.TargetTable);
			return AiHelper_5.CreateSuccess("Word table format inspected.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = TableIndex,
				altTextTitle = SanitizeToken(SafeExecute(() => CS_8_locals_26.TargetTable.Title)),
				altTextDescription = SanitizeToken(SafeExecute(() => CS_8_locals_26.TargetTable.Descr)),
				page = ComputeIntValue(CS_8_locals_26.TargetTable.Range),
				rangeStart = CS_8_locals_26.TargetTable.Range.Start,
				rangeEnd = CS_8_locals_26.TargetTable.Range.End,
				rows = GetTableRowCount(CS_8_locals_26.TargetTable),
				columns = GetTableColumnCount(CS_8_locals_26.TargetTable),
				preferredWidthType = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.PreferredWidthType, WdPreferredWidthType.wdPreferredWidthAuto)),
				preferredWidth = Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.PreferredWidth, 0f),
				rowAlignment = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.Rows.Alignment, WdRowAlignment.wdAlignRowLeft)),
				allowPageBreaks = Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.AllowPageBreaks, ypQS6RTSiCdpSgKNQtr: false),
				spacing = Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.Spacing, 0f),
				cellPadding = new
				{
					top = Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.TopPadding, 0f),
					bottom = Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.BottomPadding, 0f),
					left = Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.LeftPadding, 0f),
					right = Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.RightPadding, 0f)
				},
				row = new
				{
					height = Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.Rows.Height, 0f),
					heightRule = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.Rows.HeightRule, WdRowHeightRule.wdRowHeightAuto)),
					allowBreakAcrossPages = Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.Rows.AllowBreakAcrossPages, 0),
					firstRowHeadingFormat = Ex5TMxi7X1(() => CS_8_locals_26.TargetTable.Rows[1].HeadingFormat, 0)
				},
				rangeFont = BuildFontInfo(CS_8_locals_26.TargetTable.Range.Font),
				paragraphFormat = pyaTKvLinx(CS_8_locals_26.TargetTable.Range.ParagraphFormat),
				borders = BuildResultObject(CS_8_locals_26.TargetTable),
				sampleCells = BuildResultObject(CS_8_locals_26.TargetTable)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass46_1
	{
		public Table TargetTable;

		public _G_c__DisplayClass46_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetTableTitle()
		{
			return TargetTable.Title;
		}

		internal string GetTableDescription()
		{
			return TargetTable.Descr;
		}

		internal WdPreferredWidthType GetPreferredWidthType()
		{
			return TargetTable.PreferredWidthType;
		}

		internal float GetPreferredWidth()
		{
			return TargetTable.PreferredWidth;
		}

		internal WdRowAlignment OTgkqFcCvn()
		{
			return TargetTable.Rows.Alignment;
		}

		internal bool uPhkPcNasu()
		{
			return TargetTable.AllowPageBreaks;
		}

		internal float GetTableSpacing()
		{
			return TargetTable.Spacing;
		}

		internal float GetTopPadding()
		{
			return TargetTable.TopPadding;
		}

		internal float GetBottomPadding()
		{
			return TargetTable.BottomPadding;
		}

		internal float GetLeftPadding()
		{
			return TargetTable.LeftPadding;
		}

		internal float wUpkkOJxJK()
		{
			return TargetTable.RightPadding;
		}

		internal float yaQkxeXKrG()
		{
			return TargetTable.Rows.Height;
		}

		internal WdRowHeightRule GetRowHeightRule()
		{
			return TargetTable.Rows.HeightRule;
		}

		internal int GetRowCount()
		{
			return TargetTable.Rows.AllowBreakAcrossPages;
		}

		internal int GetRowCount()
		{
			return TargetTable.Rows[1].HeadingFormat;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass47_0
	{
		public int ParagraphIndex;

		public _G_c__DisplayClass47_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ajwxBUxtBx(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Paragraph paragraph = ((ParagraphIndex > 0) ? GetParagraphByIndex(document, ParagraphIndex) : GetFirstParagraph(app, document));
			int? paragraphIndex = ((ParagraphIndex > 0) ? new int?(ParagraphIndex) : FindParagraphIndex(document, paragraph.Range.Start));
			int num = GetOutlineLevel(paragraph);
			return AiHelper_5.CreateSuccess("Word paragraph format inspected.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				paragraphIndex = paragraphIndex,
				requestedParagraphIndex = ParagraphIndex,
				page = ComputeIntValue(paragraph.Range),
				rangeStart = paragraph.Range.Start,
				rangeEnd = paragraph.Range.End,
				isInTable = IsRangeInTable(paragraph.Range),
				outlineLevel = ClampOutlineLevel(num),
				comOutlineLevelRaw = num,
				styleName = GetParagraphStyleName(paragraph),
				excerpt = TruncateText(NormalizeText(paragraph.Range.Text), 240),
				font = BuildFontInfo(paragraph.Range.Font),
				paragraphFormat = pyaTKvLinx(paragraph.Range.ParagraphFormat)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass48_0
	{
		public string hGNxuJMRRe;

		public int ParagraphIndex;

		public int ParagraphIndex;

		public _G_c__DisplayClass48_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 FormatParagraphs(Microsoft.Office.Interop.Word.Application app)
		{
			ParagraphFormatConfig tqHECLHh7ExNw6c0RJi;
			AiHelper_5 insertResult = KESDFbjWCy(hGNxuJMRRe, out tqHECLHh7ExNw6c0RJi);
			if (insertResult != null)
			{
				return insertResult;
			}
			Document document = GetActiveDocument(app);
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ReadParagraphRange(document, ParagraphIndex, ParagraphIndex);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			List<AiHelper_1> list = CollectParagraphs(app, document, ParagraphIndex, ParagraphIndex);
			if (list.Count == 0)
			{
				return AiHelper_5.CreateError("当前没有可设置格式的段落。", "no_paragraph_selection", new
				{
					startParagraphIndex = ParagraphIndex,
					endParagraphIndex = ParagraphIndex
				});
			}
			return AiHelper_5.CreateSuccess("Word paragraph format change preview prepared.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				startParagraphIndex = ParagraphIndex,
				endParagraphIndex = ParagraphIndex,
				expectedChangeCount = list.Count,
				supportedFields = ParagraphFormatConfig.CsBHPhLn0y,
				requestedChanges = tqHECLHh7ExNw6c0RJi.WK3Hqw863W(),
				paragraphs = list.Select((AiHelper_1 item) => BuildParagraphChangeInfo(item)).ToList()
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass49_0
	{
		public int ExpectedCount;

		public string ConfigJson;

		public int sexxiKXvvR;

		public int ParagraphIndex;

		public _G_c__DisplayClass49_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 FormatParagraphs(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass49_1 CS_8_locals_14 = new _G_c__DisplayClass49_1();
			if (ExpectedCount < 0)
			{
				return AiHelper_5.CreateError("执行段落格式修改前必须先调用 preview_word_paragraph_format_change，并把 expectedChangeCount 传入执行工具。", "preview_required");
			}
			AiHelper_5 insertResult = KESDFbjWCy(ConfigJson, out CS_8_locals_14.JdkxrYYqxL);
			if (insertResult != null)
			{
				return insertResult;
			}
			Document document = GetActiveDocument(app);
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ReadParagraphRange(document, sexxiKXvvR, ParagraphIndex);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_14.ParagraphList = CollectParagraphs(app, document, sexxiKXvvR, ParagraphIndex);
			if (CS_8_locals_14.ParagraphList.Count != ExpectedCount)
			{
				return AiHelper_5.CreateError("当前段落数量与预览结果不一致，已停止执行。请重新预览后再执行。", "preview_mismatch", new
				{
					expectedChangeCount = ExpectedCount,
					currentChangeCount = CS_8_locals_14.ParagraphList.Count
				});
			}
			CS_8_locals_14.ResultList = new List<object>();
			CS_8_locals_14.ChangedCount = 0;
			AiHelper_5 rU18qH9owXvBsPZ0iiU4 = ValidateRange(app, document, CS_8_locals_14.ParagraphList[0].Paragraph.Range);
			if (rU18qH9owXvBsPZ0iiU4 != null)
			{
				return rU18qH9owXvBsPZ0iiU4;
			}
			DyITDXSmDr(app, "AI 自定义段落格式", delegate
			{
				foreach (AiHelper_1 item in CS_8_locals_14.ParagraphList)
				{
					object before = BuildParagraphRangeInfo(item.Paragraph);
					ApplyParagraphFormat(item.Paragraph.Range, CS_8_locals_14.JdkxrYYqxL);
					object after = BuildParagraphRangeInfo(item.Paragraph);
					CS_8_locals_14.ChangedCount++;
					CS_8_locals_14.ResultList.Add(new
					{
						paragraphIndex = item.ParagraphIndex,
						rangeStart = item.Paragraph.Range.Start,
						rangeEnd = item.Paragraph.Range.End,
						page = ComputeIntValue(item.Paragraph.Range),
						excerpt = TruncateText(NormalizeText(item.Paragraph.Range.Text), 160),
						before = before,
						after = after,
						changed = true
					});
				}
			});
			return AiHelper_5.CreateSuccess("Word paragraph format changed.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				startParagraphIndex = sexxiKXvvR,
				endParagraphIndex = ParagraphIndex,
				expectedChangeCount = ExpectedCount,
				changed = CS_8_locals_14.ChangedCount,
				requestedChanges = CS_8_locals_14.JdkxrYYqxL.WK3Hqw863W(),
				paragraphs = CS_8_locals_14.ResultList
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass49_1
	{
		public List<AiHelper_1> ParagraphList;

		public ParagraphFormatConfig JdkxrYYqxL;

		public int ChangedCount;

		public List<object> ResultList;

		public _G_c__DisplayClass49_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void UNoxQXVbiW()
		{
			foreach (AiHelper_1 item in ParagraphList)
			{
				object before = BuildParagraphRangeInfo(item.Paragraph);
				ApplyParagraphFormat(item.Paragraph.Range, JdkxrYYqxL);
				object after = BuildParagraphRangeInfo(item.Paragraph);
				ChangedCount++;
				ResultList.Add(new
				{
					paragraphIndex = item.ParagraphIndex,
					rangeStart = item.Paragraph.Range.Start,
					rangeEnd = item.Paragraph.Range.End,
					page = ComputeIntValue(item.Paragraph.Range),
					excerpt = TruncateText(NormalizeText(item.Paragraph.Range.Text), 160),
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

		public int TableIndex;

		public string CellSelector;

		public _G_c__DisplayClass50_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ExecuteTableConfig(Microsoft.Office.Interop.Word.Application app)
		{
			Helper_9 xqsyBVQI7dsGuEiUT3v;
			AiHelper_5 insertResult = ParseTableConfig(noTxKIkNHF, out xqsyBVQI7dsGuEiUT3v);
			if (insertResult != null)
			{
				return insertResult;
			}
			Document document = GetActiveDocument(app);
			Table table = GetTableByIndex(app, document, TableIndex);
			int tableIndex = GetTableIndex(document, table);
			Range range;
			string target;
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ResolveTableCell(document, table, CellSelector, out range, out target);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			return AiHelper_5.CreateSuccess("Word table format change preview prepared.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = TableIndex,
				target = target,
				expectedChangeCount = 1,
				supportedFields = Helper_9.TcvQQSKPF8,
				requestedChanges = xqsyBVQI7dsGuEiUT3v.hhNQHAECG8(),
				before = BuildRangeSnapshot(table, range)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass51_0
	{
		public int ExpectedCount;

		public string ConfigJson;

		public int TableIndex;

		public string CellSelector;

		public _G_c__DisplayClass51_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 PreviewTable(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass51_1 CS_8_locals_14 = new _G_c__DisplayClass51_1();
			if (ExpectedCount < 0)
			{
				return AiHelper_5.CreateError("执行表格格式修改前必须先调用 preview_word_table_format_change，并把 expectedChangeCount 传入执行工具。", "preview_required");
			}
			if (ExpectedCount != 1)
			{
				return AiHelper_5.CreateError("当前表格格式修改预期数量不一致，已停止执行。请重新预览后再执行。", "preview_mismatch", new
				{
					expectedChangeCount = ExpectedCount,
					currentChangeCount = 1
				});
			}
			AiHelper_5 insertResult = ParseTableConfig(ConfigJson, out CS_8_locals_14.vsUxwGPQsX);
			if (insertResult != null)
			{
				return insertResult;
			}
			Document document = GetActiveDocument(app);
			CS_8_locals_14.TargetTable = GetTableByIndex(app, document, TableIndex);
			int tableIndex = GetTableIndex(document, CS_8_locals_14.TargetTable);
			string target;
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ResolveTableCell(document, CS_8_locals_14.TargetTable, CellSelector, out CS_8_locals_14.ComputedRange, out target);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			object before = BuildRangeSnapshot(CS_8_locals_14.TargetTable, CS_8_locals_14.ComputedRange);
			AiHelper_5 rU18qH9owXvBsPZ0iiU4 = ValidateRange(app, document, CS_8_locals_14.ComputedRange);
			if (rU18qH9owXvBsPZ0iiU4 != null)
			{
				return rU18qH9owXvBsPZ0iiU4;
			}
			DyITDXSmDr(app, "AI 自定义表格格式", delegate
			{
				ApplyTableChanges(CS_8_locals_14.TargetTable, CS_8_locals_14.ComputedRange, CS_8_locals_14.vsUxwGPQsX);
			});
			object after = BuildRangeSnapshot(CS_8_locals_14.TargetTable, CS_8_locals_14.ComputedRange);
			return AiHelper_5.CreateSuccess("Word table format changed.", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = TableIndex,
				target = target,
				expectedChangeCount = ExpectedCount,
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
		public Table TargetTable;

		public Range ComputedRange;

		public Helper_9 vsUxwGPQsX;

		public _G_c__DisplayClass51_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ExecuteAction()
		{
			ApplyTableChanges(TargetTable, ComputedRange, vsUxwGPQsX);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass52_0
	{
		public Document doc;

		public _G_c__DisplayClass52_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetParagraphCount()
		{
			return doc.Paragraphs.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass55_0
	{
		public Table TableForProperties;

		public _G_c__DisplayClass55_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal WdPreferredWidthType eawxLOhAFX()
		{
			return TableForProperties.PreferredWidthType;
		}

		internal float GetPreferredWidth()
		{
			return TableForProperties.PreferredWidth;
		}

		internal WdRowAlignment GetRowAlignment()
		{
			return TableForProperties.Rows.Alignment;
		}

		internal float GetTopPadding()
		{
			return TableForProperties.TopPadding;
		}

		internal float GetBottomPadding()
		{
			return TableForProperties.BottomPadding;
		}

		internal float xTKxorsjvd()
		{
			return TableForProperties.LeftPadding;
		}

		internal float KswxGsfymk()
		{
			return TableForProperties.RightPadding;
		}

		internal float GetRowCount()
		{
			return TableForProperties.Rows.Height;
		}

		internal WdRowHeightRule GetRowHeightRule()
		{
			return TableForProperties.Rows.HeightRule;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass61_0
	{
		public Range TargetRange;

		public _G_c__DisplayClass61_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetCellCount()
		{
			return TargetRange.Cells.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass83_0<T>
	{
		public T result;

		public Func<T> action;

		public _G_c__DisplayClass83_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void ExecuteAction()
		{
			result = action();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass93_0
	{
		public Font TargetFont;

		public _G_c__DisplayClass93_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetFontNameFarEast()
		{
			return TargetFont.NameFarEast;
		}

		internal string JabxedgRUi()
		{
			return TargetFont.NameAscii;
		}

		internal string GetFontNameOther()
		{
			return TargetFont.NameOther;
		}

		internal float GetFontSize()
		{
			return TargetFont.Size;
		}

		internal int GetFontBold()
		{
			return TargetFont.Bold;
		}

		internal int GetFontItalic()
		{
			return TargetFont.Italic;
		}

		internal WdUnderline xwHxauAWPv()
		{
			return TargetFont.Underline;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass94_0
	{
		public ParagraphFormat TargetParagraphFormat;

		public _G_c__DisplayClass94_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal WdParagraphAlignment GetParagraphAlignment()
		{
			return TargetParagraphFormat.Alignment;
		}

		internal WdLineSpacing FYPxAGPeUU()
		{
			return TargetParagraphFormat.LineSpacingRule;
		}

		internal float GetLineSpacing()
		{
			return TargetParagraphFormat.LineSpacing;
		}

		internal float GetSpaceBefore()
		{
			return TargetParagraphFormat.SpaceBefore;
		}

		internal float GetSpaceAfter()
		{
			return TargetParagraphFormat.SpaceAfter;
		}

		internal float LxBxkVeSxa()
		{
			return TargetParagraphFormat.LineUnitBefore;
		}

		internal float GetLineUnitAfter()
		{
			return TargetParagraphFormat.LineUnitAfter;
		}

		internal float GetLeftIndent()
		{
			return TargetParagraphFormat.LeftIndent;
		}

		internal float GetRightIndent()
		{
			return TargetParagraphFormat.RightIndent;
		}

		internal float GetFirstLineIndent()
		{
			return TargetParagraphFormat.FirstLineIndent;
		}

		internal float GetCharacterUnitLeftIndent()
		{
			return TargetParagraphFormat.CharacterUnitLeftIndent;
		}

		internal float GetCharacterUnitRightIndent()
		{
			return TargetParagraphFormat.CharacterUnitRightIndent;
		}

		internal float GetCharacterUnitFirstLineIndent()
		{
			return TargetParagraphFormat.CharacterUnitFirstLineIndent;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass96_0
	{
		public Table TableForBorders;

		public WdBorderType BorderType;

		public _G_c__DisplayClass96_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal WdLineStyle tBSdugEQRd()
		{
			return TableForBorders.Borders[BorderType].LineStyle;
		}

		internal WdLineWidth GetLineWidth()
		{
			return TableForBorders.Borders[BorderType].LineWidth;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass98_0
	{
		public Cell gAJdIPCcIZ;

		public _G_c__DisplayClass98_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal WdCellVerticalAlignment GetVerticalAlignment()
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

	private static readonly XNamespace WordmlNamespace;

	private static readonly XNamespace WordNamespace;

	private readonly AiTargetBinder TargetBinder;

	private readonly WordTableToolService4 TableToolService;

	public BatchReplaceService3() : this(null)
	{
		SseStreamInitializer.InitializeRuntime();
	}

	public BatchReplaceService3(AiTargetBinder P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		TargetBinder = P_0;
		TableToolService = new WordTableToolService4(P_0);
	}

	public AiHelper_5 GetCurrentWordContext(bool P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass13_0 CS_8_locals_15 = new _G_c__DisplayClass13_0();
		CS_8_locals_15.MaxCharLimit = P_2;
		CS_8_locals_15.IncludeStatistics = P_0;
		CS_8_locals_15.XVvAQYyUwY = P_1;
		return GetCurrentWordContext("get_current_word_context", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass13_1 CS_8_locals_18 = new _G_c__DisplayClass13_1();
			CS_8_locals_18.doc = GetActiveDocument(app);
			Selection selection = app.Selection;
			int num = ClampValue(CS_8_locals_15.MaxCharLimit, 240, 2000);
			return AiHelper_5.CreateSuccess("B", new
			{
				document = CS_8_locals_18.doc.Name,
				documentFullName = CS_8_locals_18.doc.FullName,
				pageCount = (CS_8_locals_15.IncludeStatistics ? new int?(ComputeIntValue(CS_8_locals_18.doc, WdStatistic.wdStatisticPages)) : ((int?)null)),
				wordCount = (CS_8_locals_15.IncludeStatistics ? new int?(ComputeIntValue(CS_8_locals_18.doc, WdStatistic.wdStatisticWords)) : ((int?)null)),
				statisticsIncluded = CS_8_locals_15.IncludeStatistics,
				paragraphCount = ComputeIntValue(() => CS_8_locals_18.doc.Paragraphs.Count),
				tableCount = ComputeIntValue(() => CS_8_locals_18.doc.Tables.Count),
				commentCount = ComputeIntValue(() => CS_8_locals_18.doc.Comments.Count),
				trackRevisions = CheckCondition(CS_8_locals_18.doc),
				selection = BuildResultObject(selection, CS_8_locals_15.XVvAQYyUwY, num)
			});
		});
	}

	public AiHelper_5 PreviewWordDocument(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		_G_c__DisplayClass14_0 CS_8_locals_12 = new _G_c__DisplayClass14_0();
		CS_8_locals_12.fYKASMsLjm = P_0;
		CS_8_locals_12.TailParagraphCount = P_1;
		CS_8_locals_12.HeadingCount = P_2;
		CS_8_locals_12.MaxPreviewChars = P_3;
		CS_8_locals_12.MaxCharLimit = P_4;
		return GetCurrentWordContext("preview_word_document", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass14_1 CS_8_locals_21 = new _G_c__DisplayClass14_1();
			CS_8_locals_21.doc = GetActiveDocument(app);
			Selection selection = app.Selection;
			int num = ComputeIntValue(() => CS_8_locals_21.doc.Paragraphs.Count);
			int num2 = ClampValue(CS_8_locals_12.fYKASMsLjm, 8, 50);
			int num3 = ClampValue(CS_8_locals_12.TailParagraphCount, 4, 50);
			int num4 = ClampValue(CS_8_locals_12.HeadingCount, 50, 300);
			int num5 = ClampValue(CS_8_locals_12.MaxPreviewChars, 180, 1000);
			int num6 = ClampValue(CS_8_locals_12.MaxCharLimit, 240, 2000);
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
				if (!string.IsNullOrWhiteSpace(NormalizeText(paragraph.Range.Text)))
				{
					list.Add(BuildParagraphInfo(paragraph, num7, num5));
				}
			}
			for (int num8 = Math.Max(1, num - num3 + 1); num8 <= num; num8++)
			{
				Paragraph paragraph2 = CS_8_locals_21.doc.Paragraphs[num8];
				if (!string.IsNullOrWhiteSpace(NormalizeText(paragraph2.Range.Text)))
				{
					list2.Add(BuildParagraphInfo(paragraph2, num8, num5));
				}
			}
			for (int num9 = 1; num9 <= num; num9++)
			{
				if (list3.Count >= num4)
				{
					break;
				}
				Paragraph paragraph3 = CS_8_locals_21.doc.Paragraphs[num9];
				if (GetOutlineLevel(paragraph3) == 1 && !string.IsNullOrWhiteSpace(NormalizeText(paragraph3.Range.Text)))
				{
					list3.Add(BuildParagraphInfo(paragraph3, num9, num5));
				}
			}
			return AiHelper_5.CreateSuccess("H", new
			{
				document = CS_8_locals_21.doc.Name,
				documentFullName = CS_8_locals_21.doc.FullName,
				paragraphCount = num,
				tableCount = ComputeIntValue(() => CS_8_locals_21.doc.Tables.Count),
				commentCount = ComputeIntValue(() => CS_8_locals_21.doc.Comments.Count),
				trackRevisions = CheckCondition(CS_8_locals_21.doc),
				selection = BuildResultObject(selection, false, num6),
				headingLevel = 1,
				headings = list3,
				head = list,
				tail = list2,
				truncated = (num > list.Count + list2.Count || list3.Count >= num4)
			});
		});
	}

	public AiHelper_5 PreviewWordSelection(int P_0)
	{
		_G_c__DisplayClass15_0 CS_8_locals_2 = new _G_c__DisplayClass15_0();
		CS_8_locals_2.MaxCharLimit = P_0;
		return GetCurrentWordContext("preview_word_selection", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Selection selection = app.Selection;
			if (selection == null || selection.Range == null)
			{
				return AiHelper_5.CreateError("E", "W");
			}
			int num = ClampValue(CS_8_locals_2.MaxCharLimit, 6000, 30000);
			string text = NormalizeText(selection.Range.Text);
			bool flag = text.Length > num;
			return AiHelper_5.CreateSuccess(":", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = ComputeIntValue(selection.Range),
				rangeStart = selection.Range.Start,
				rangeEnd = selection.Range.End,
				characters = text.Length,
				truncated = flag,
				text = (flag ? text.Substring(0, num) : text)
			});
		});
	}

	public AiHelper_5 ReadWordRange(int P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass16_0 CS_8_locals_6 = new _G_c__DisplayClass16_0();
		CS_8_locals_6.bEEAWaNvfx = P_0;
		CS_8_locals_6.RangeEndPosition = P_1;
		CS_8_locals_6.MaxCharLimit = P_2;
		return GetCurrentWordContext("read_word_range", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Range range = GetRangeByPosition(document, CS_8_locals_6.bEEAWaNvfx, CS_8_locals_6.RangeEndPosition);
			int num = ClampValue(CS_8_locals_6.MaxCharLimit, 30000, 30000);
			string text = NormalizeText(range.Text);
			bool flag = text.Length > num;
			return AiHelper_5.CreateSuccess(": ", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = ComputeIntValue(range),
				paragraphIndex = FindParagraphIndex(document, range.Start),
				rangeStart = range.Start,
				rangeEnd = range.End,
				characters = text.Length,
				truncated = flag,
				text = (flag ? text.Substring(0, num) : text)
			});
		});
	}

	public AiHelper_5 ReadWordParagraphs(int P_0, int P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass17_0 CS_8_locals_17 = new _G_c__DisplayClass17_0();
		CS_8_locals_17.NumericParameter = P_0;
		CS_8_locals_17.xYgvIDRxGK = P_2;
		CS_8_locals_17.MaxSnippetLength = P_1;
		CS_8_locals_17.MaxCharLimit = P_3;
		return GetCurrentWordContext("read_word_paragraphs", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass17_1 CS_8_locals_18 = new _G_c__DisplayClass17_1();
			CS_8_locals_18.doc = GetActiveDocument(app);
			int num = ComputeIntValue(() => CS_8_locals_18.doc.Paragraphs.Count);
			int num2 = Math.Max(1, (CS_8_locals_17.NumericParameter <= 0) ? 1 : CS_8_locals_17.NumericParameter);
			if (num2 > num)
			{
				return AiHelper_5.CreateError("/word/document.xml", "tbl", new
				{
					totalParagraphs = num
				});
			}
			int num3;
			if (CS_8_locals_17.xYgvIDRxGK > 0)
			{
				if (CS_8_locals_17.xYgvIDRxGK < num2)
				{
					return AiHelper_5.CreateError("tr", "tc");
				}
				num3 = Math.Min(num, CS_8_locals_17.xYgvIDRxGK);
			}
			else
			{
				int num4 = ClampValue(CS_8_locals_17.MaxSnippetLength, 20, 300);
				num3 = Math.Min(num, num2 + num4 - 1);
			}
			int num5 = ClampValue(CS_8_locals_17.MaxCharLimit, 1000, 5000);
			List<object> list = new List<object>();
			for (int num6 = num2; num6 <= num3; num6++)
			{
				list.Add(BuildParagraphInfo(CS_8_locals_18.doc.Paragraphs[num6], num6, num5));
			}
			return AiHelper_5.CreateSuccess("restart", new
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

	public AiHelper_5 SetParagraphOutlineOperation(int P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass18_0 CS_8_locals_12 = new _G_c__DisplayClass18_0();
		CS_8_locals_12.qdXvZGOPXC = P_0;
		CS_8_locals_12.TableCount = P_2;
		CS_8_locals_12.IncludeBodyText = P_1;
		return GetCurrentWordContext("read_word_outline", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass18_1 CS_8_locals_13 = new _G_c__DisplayClass18_1();
			CS_8_locals_13.doc = GetActiveDocument(app);
			int num = ClampValue(CS_8_locals_12.qdXvZGOPXC, 300, 1000);
			int num2 = ClampValue(CS_8_locals_12.TableCount);
			int num3 = ComputeIntValue(() => CS_8_locals_13.doc.Paragraphs.Count);
			List<object> list = new List<object>();
			int num4 = 0;
			for (int num5 = 1; num5 <= num3; num5++)
			{
				if (list.Count >= num)
				{
					break;
				}
				Paragraph paragraph = CS_8_locals_13.doc.Paragraphs[num5];
				int num6 = GetOutlineLevel(paragraph);
				bool flag = num6 >= 1 && num6 <= 9;
				if ((flag || CS_8_locals_12.IncludeBodyText) && (!flag || num6 <= num2) && !string.IsNullOrWhiteSpace(NormalizeText(paragraph.Range.Text)))
				{
					if (flag)
					{
						num4++;
					}
					list.Add(BuildParagraphInfo(paragraph, num5, 240));
				}
			}
			return AiHelper_5.CreateSuccess("name", new
			{
				document = CS_8_locals_13.doc.Name,
				documentFullName = CS_8_locals_13.doc.FullName,
				maxOutlineLevel = num2,
				includeBodyText = CS_8_locals_12.IncludeBodyText,
				headings = num4,
				returned = list.Count,
				truncated = (list.Count >= num),
				items = list
			});
		});
	}

	public AiHelper_5 ParagraphOperation(string P_0, int P_1, int P_2, string P_3, int P_4, int P_5, int P_6, int P_7, int P_8)
	{
		_G_c__DisplayClass19_0 CS_8_locals_25 = new _G_c__DisplayClass19_0();
		CS_8_locals_25.PxqveKcgAE = P_0;
		CS_8_locals_25.ParagraphNumber = P_1;
		CS_8_locals_25.ParagraphNumber = P_2;
		CS_8_locals_25.SearchPattern = P_3;
		CS_8_locals_25.kDLvhCZhco = P_4;
		CS_8_locals_25.MaxSnippetLength = P_5;
		CS_8_locals_25.MaxCharLimit = P_6;
		CS_8_locals_25.MaxSnippetLength = P_7;
		CS_8_locals_25.MaxSnippetLength = P_8;
		return GetCurrentWordContext("read_word_section", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass19_1 CS_8_locals_32 = new _G_c__DisplayClass19_1();
			CS_8_locals_32.doc = GetActiveDocument(app);
			Paragraph paragraph = GetParagraphByIndex(CS_8_locals_32.doc, CS_8_locals_25.PxqveKcgAE, CS_8_locals_25.ParagraphNumber, CS_8_locals_25.ParagraphNumber, CS_8_locals_25.SearchPattern);
			if (paragraph == null)
			{
				return AiHelper_5.CreateError("document", "/word/document.xml");
			}
			int num = ((CS_8_locals_25.ParagraphNumber > 0) ? CS_8_locals_25.ParagraphNumber : FindParagraphIndex(CS_8_locals_32.doc, paragraph.Range.Start).GetValueOrDefault());
			int num2 = GetOutlineLevel(paragraph);
			if (num2 < 1 || num2 > 9)
			{
				return AiHelper_5.CreateError("part", "xmlData", new
				{
					headingParagraphIndex = num
				});
			}
			int num3 = ComputeIntValue(() => CS_8_locals_32.doc.Paragraphs.Count);
			int num4 = num3;
			for (int num5 = num + 1; num5 <= num3; num5++)
			{
				int num6 = GetOutlineLevel(CS_8_locals_32.doc.Paragraphs[num5]);
				if (num6 >= 1 && num6 <= num2)
				{
					num4 = num5 - 1;
					break;
				}
			}
			int num7 = Math.Max(0, CS_8_locals_25.kDLvhCZhco);
			int num8 = ClampValue(CS_8_locals_25.MaxSnippetLength, 200, 1000);
			int num9 = ClampValue(CS_8_locals_25.MaxCharLimit, 1000, 5000);
			int num10 = ClampValue(CS_8_locals_25.MaxSnippetLength, 80, 500);
			int num11 = ClampValue(CS_8_locals_25.MaxSnippetLength, 20, 100);
			int start = paragraph.Range.Start;
			int end = CS_8_locals_32.doc.Paragraphs[num4].Range.End;
			List<Helper_20> list = new List<Helper_20>();
			for (int num12 = num; num12 <= num4; num12++)
			{
				Paragraph paragraph2 = CS_8_locals_32.doc.Paragraphs[num12];
				if (!IsRangeInTable(paragraph2.Range))
				{
					list.Add(new Helper_20
					{
						Type = "tcPr",
						RangeStart = paragraph2.Range.Start,
						Data = BuildParagraphInfo(paragraph2, num12, num9)
					});
				}
			}
			for (int num13 = 1; num13 <= CS_8_locals_32.doc.Tables.Count; num13++)
			{
				Table table = CS_8_locals_32.doc.Tables[num13];
				if (table.Range.Start >= start && table.Range.End <= end)
				{
					list.Add(new Helper_20
					{
						Type = "gridSpan",
						RangeStart = table.Range.Start,
						Data = WhFgjeRETB(table, num13, num10, num11)
					});
				}
			}
			list.Sort((Helper_20 left, Helper_20 right) => left.RangeStart.CompareTo(right.RangeStart));
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
				Helper_20 jaDcyWQtOojM0IicNQ8 = list[num15];
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
			return AiHelper_5.CreateSuccess("vMerge", new
			{
				document = CS_8_locals_32.doc.Name,
				documentFullName = CS_8_locals_32.doc.FullName,
				heading = BuildParagraphInfo(paragraph, num, 500),
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

	public AiHelper_5 ReadTableOperation(int P_0, int P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass20_0 CS_8_locals_15 = new _G_c__DisplayClass20_0();
		CS_8_locals_15.XVXvxrblxn = P_0;
		CS_8_locals_15.umIvdDfpSj = P_1;
		CS_8_locals_15.MaxSnippetLength = P_2;
		CS_8_locals_15.MaxSnippetLength = P_3;
		return GetCurrentWordContext("read_word_tables", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass20_1 CS_8_locals_19 = new _G_c__DisplayClass20_1();
			CS_8_locals_19.doc = GetActiveDocument(app);
			int num = ComputeIntValue(() => CS_8_locals_19.doc.Tables.Count);
			if (num == 0)
			{
				return AiHelper_5.CreateSuccess("val", new
				{
					document = CS_8_locals_19.doc.Name,
					documentFullName = CS_8_locals_19.doc.FullName,
					totalTables = 0,
					tables = new object[0]
				});
			}
			int num2 = ((CS_8_locals_15.XVXvxrblxn <= 0) ? 1 : CS_8_locals_15.XVXvxrblxn);
			int num3 = ((CS_8_locals_15.XVXvxrblxn > 0) ? CS_8_locals_15.XVXvxrblxn : Math.Min(num, ClampValue(CS_8_locals_15.umIvdDfpSj, 5, 100)));
			if (num2 < 1 || num2 > num)
			{
				return AiHelper_5.CreateError("continue", "AI 修订替换", new
				{
					totalTables = num
				});
			}
			int num4 = ClampValue(CS_8_locals_15.MaxSnippetLength, 80, 500);
			int num5 = ClampValue(CS_8_locals_15.MaxSnippetLength, 20, 100);
			List<object> list = new List<object>();
			for (int num6 = num2; num6 <= num3; num6++)
			{
				list.Add(WhFgjeRETB(CS_8_locals_19.doc.Tables[num6], num6, num4, num5));
			}
			return AiHelper_5.CreateSuccess("Word 应用或目标文档不可用。", new
			{
				document = CS_8_locals_19.doc.Name,
				documentFullName = CS_8_locals_19.doc.FullName,
				totalTables = num,
				returned = list.Count,
				tables = list
			});
		});
	}

	public AiHelper_5 CommentOperation(int P_0, bool P_1, int P_2, int P_3)
	{
		_G_c__DisplayClass21_0 CS_8_locals_13 = new _G_c__DisplayClass21_0();
		CS_8_locals_13.MaxSnippetLength = P_0;
		CS_8_locals_13.MaxSnippetLength = P_2;
		CS_8_locals_13.TjwWuYNRhv = P_3;
		CS_8_locals_13.BooleanFlag = P_1;
		return GetCurrentWordContext("read_word_comments", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass21_1 CS_8_locals_16 = new _G_c__DisplayClass21_1();
			CS_8_locals_16.doc = GetActiveDocument(app);
			int num = ClampValue(CS_8_locals_13.MaxSnippetLength, 200, 1000);
			int num2 = ClampValue(CS_8_locals_13.MaxSnippetLength, 120, 1000);
			int num3 = ((CS_8_locals_13.TjwWuYNRhv < 0) ? 20 : Math.Min(CS_8_locals_13.TjwWuYNRhv, 200));
			List<object> list = new List<object>();
			int num4 = ComputeIntValue(() => CS_8_locals_16.doc.Comments.Count);
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
					list.Add(qXYglKDlsW(CS_8_locals_16.doc, comment, CS_8_locals_13.BooleanFlag, num2, num3));
				}
			}
			return AiHelper_5.CreateSuccess("word_not_ready", new
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

	public AiHelper_5 OhADgENodK(string P_0, string P_1, int P_2, string P_3, string P_4)
	{
		_G_c__DisplayClass22_0 CS_8_locals_39 = new _G_c__DisplayClass22_0();
		CS_8_locals_39.ReplyText = P_1;
		CS_8_locals_39.CommentToken = P_0;
		CS_8_locals_39.CommentIndex = P_2;
		CS_8_locals_39.ExpectedScopeText = P_3;
		CS_8_locals_39.ExpectedScopeText = P_4;
		return GetCurrentWordContext("reply_word_comment", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass22_1 CS_8_locals_55 = new _G_c__DisplayClass22_1();
			CS_8_locals_55.rvpWKhLSmL = CS_8_locals_39;
			if (string.IsNullOrWhiteSpace(CS_8_locals_39.ReplyText))
			{
				return AiHelper_5.CreateError("无法将 Word 焦点切回正文区域。请点击正文后重试同一工具，不要改用无修订写入。", "main_document_focus_failed");
			}
			CS_8_locals_55.doc = GetActiveDocument(app);
			AiHelper_5 insertResult = (string.IsNullOrWhiteSpace(CS_8_locals_39.CommentToken) ? ExecuteOperation(CS_8_locals_55.doc, CS_8_locals_39.CommentIndex, out CS_8_locals_55.TargetComment, out CS_8_locals_55.FUKWrYRDvi) : CLCgCUGOui(CS_8_locals_55.doc, CS_8_locals_39.CommentToken, CS_8_locals_39.CommentIndex, out CS_8_locals_55.TargetComment, out CS_8_locals_55.FUKWrYRDvi));
			if (insertResult != null)
			{
				return insertResult;
			}
			string text = GetCommentText(CS_8_locals_55.TargetComment);
			string text2 = XPEgcZYWAO(CS_8_locals_55.FUKWrYRDvi);
			string text3 = NormalizeScopeText(CS_8_locals_39.ExpectedScopeText);
			string text4 = NormalizeScopeText(CS_8_locals_39.ExpectedScopeText);
			if (!string.IsNullOrWhiteSpace(text3) && !string.Equals(NormalizeScopeText(text), text3, StringComparison.Ordinal))
			{
				return AiHelper_5.CreateError("当前 Word 焦点仍不在正文区域，可能仍选中了批注或批注窗格。请点击正文后重试同一工具，不要改用无修订写入。", "main_document_focus_failed", new
				{
					commentToken = SanitizeToken(CS_8_locals_39.CommentToken),
					commentIndex = CS_8_locals_39.CommentIndex,
					expectedCommentText = text3,
					currentCommentText = text
				});
			}
			if (!string.IsNullOrWhiteSpace(text4) && !gxWgapxYhe(text2, text4))
			{
				return AiHelper_5.CreateError("contains", "equals", new
				{
					commentToken = SanitizeToken(CS_8_locals_39.CommentToken),
					commentIndex = CS_8_locals_39.CommentIndex,
					expectedScopeText = text4,
					currentScopeText = TruncateText(text2, 500)
				});
			}
			CS_8_locals_55.ComputedRange = GetCommentAnchorRange(CS_8_locals_55.FUKWrYRDvi) ?? GetCommentScopeRange(CS_8_locals_55.FUKWrYRDvi);
			if (CS_8_locals_55.ComputedRange == null)
			{
				return AiHelper_5.CreateError("startswith", "body", new
				{
					commentToken = SanitizeToken(CS_8_locals_39.CommentToken),
					commentIndex = CS_8_locals_39.CommentIndex,
					threadCommentIndex = GetCommentThreadIndex(CS_8_locals_55.FUKWrYRDvi)
				});
			}
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ValidateRange(app, CS_8_locals_55.doc, CS_8_locals_55.ComputedRange);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_55.ReplyText = CS_8_locals_39.ReplyText.Trim();
			return oBKTTgZY41(app, "heading", delegate
			{
				try
				{
					Comments comments = DOYgOEfqSy(CS_8_locals_55.FUKWrYRDvi);
					if (comments == null)
					{
						return AiHelper_5.CreateError("body", "heading", new
						{
							commentToken = SanitizeToken(CS_8_locals_55.rvpWKhLSmL.CommentToken),
							commentIndex = CS_8_locals_55.rvpWKhLSmL.CommentIndex,
							threadCommentIndex = GetCommentThreadIndex(CS_8_locals_55.FUKWrYRDvi)
						});
					}
					object Text = CS_8_locals_55.ReplyText;
					Comment comment = comments.Add(CS_8_locals_55.ComputedRange, ref Text);
					if (comment == null)
					{
						return AiHelper_5.CreateError("The table has merged cells or mixed widths and could not be read by row/column coordinates.", "Cell limit reached.", new
						{
							commentToken = SanitizeToken(CS_8_locals_55.rvpWKhLSmL.CommentToken),
							commentIndex = CS_8_locals_55.rvpWKhLSmL.CommentIndex,
							threadCommentIndex = GetCommentThreadIndex(CS_8_locals_55.FUKWrYRDvi)
						});
					}
					return AiHelper_5.CreateSuccess("[merged/unavailable]", BuildCommentReplyInfo(CS_8_locals_55.doc, CS_8_locals_55.FUKWrYRDvi, CS_8_locals_55.TargetComment, comment, CS_8_locals_55.ReplyText));
				}
				catch (Exception ex)
				{
					return AiHelper_5.CreateExceptionError("Some merged cells could not be read by row/column coordinates.", "Merged cells were expanded from table.Range.Cells where possible.", ex, new
					{
						commentToken = SanitizeToken(CS_8_locals_55.rvpWKhLSmL.CommentToken),
						commentIndex = CS_8_locals_55.rvpWKhLSmL.CommentIndex,
						threadCommentIndex = GetCommentThreadIndex(CS_8_locals_55.FUKWrYRDvi)
					});
				}
			});
		});
	}

	public AiHelper_5 ParagraphOperation(string P_0, int P_1, string P_2, int P_3)
	{
		_G_c__DisplayClass23_0 CS_8_locals_19 = new _G_c__DisplayClass23_0();
		CS_8_locals_19.HeadingCount = P_3;
		CS_8_locals_19.MatchMode = P_2;
		CS_8_locals_19.OutlineLevel = P_1;
		CS_8_locals_19.SearchQuery = P_0;
		return GetCurrentWordContext("find_word_heading", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass23_1 CS_8_locals_20 = new _G_c__DisplayClass23_1();
			CS_8_locals_20.doc = GetActiveDocument(app);
			int num = ClampValue(CS_8_locals_19.HeadingCount, 50, 300);
			string text = (CS_8_locals_19.MatchMode ?? "[merged/unavailable]").Trim().ToLowerInvariant();
			List<object> list = new List<object>();
			int num2 = ComputeIntValue(() => CS_8_locals_20.doc.Paragraphs.Count);
			for (int num3 = 1; num3 <= num2; num3++)
			{
				if (list.Count >= num)
				{
					break;
				}
				Paragraph paragraph = CS_8_locals_20.doc.Paragraphs[num3];
				int num4 = GetOutlineLevel(paragraph);
				if (num4 >= 1 && num4 <= 9 && (CS_8_locals_19.OutlineLevel <= 0 || num4 == CS_8_locals_19.OutlineLevel))
				{
					string text2 = NormalizeText(paragraph.Range.Text);
					if (OYJgKddkFp(text2, CS_8_locals_19.SearchQuery, text))
					{
						list.Add(new
						{
							document = CS_8_locals_20.doc.Name,
							documentFullName = CS_8_locals_20.doc.FullName,
							page = ComputeIntValue(paragraph.Range),
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
			return AiHelper_5.CreateSuccess(" | ", new
			{
				document = CS_8_locals_20.doc.Name,
				documentFullName = CS_8_locals_20.doc.FullName,
				query = (CS_8_locals_19.SearchQuery ?? string.Empty),
				outlineLevel = ((CS_8_locals_19.OutlineLevel <= 0) ? ((int?)null) : new int?(CS_8_locals_19.OutlineLevel)),
				matchMode = text,
				returned = list.Count,
				truncated = (list.Count >= num),
				matches = list
			});
		});
	}

	public AiHelper_5 gLSDIXjNAd(string P_0, bool P_1, bool P_2, int P_3)
	{
		_G_c__DisplayClass24_0 CS_8_locals_9 = new _G_c__DisplayClass24_0();
		CS_8_locals_9.kJMWMFbwEh = P_0;
		CS_8_locals_9.MaxResultCount = P_3;
		CS_8_locals_9.BooleanFlag = P_1;
		CS_8_locals_9.PFZWwdLEQF = P_2;
		return GetCurrentWordContext("find_word_text", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(CS_8_locals_9.kJMWMFbwEh))
			{
				return AiHelper_5.CreateError(" |", "| ");
			}
			Document document = GetActiveDocument(app);
			int num = ClampValue(CS_8_locals_9.MaxResultCount, 100, 500);
			List<WordSearchResult> list = BuildList(app, document, CS_8_locals_9.kJMWMFbwEh, CS_8_locals_9.BooleanFlag, CS_8_locals_9.PFZWwdLEQF, num);
			return AiHelper_5.CreateSuccess(" | ", BuildResultObject(document, list, num));
		});
	}

	public AiHelper_5 SearchDocumentOperation(string P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass25_0 CS_8_locals_7 = new _G_c__DisplayClass25_0();
		CS_8_locals_7.IOPWLBITxB = P_0;
		CS_8_locals_7.MaxResultCount = P_2;
		CS_8_locals_7.EyLWlEVNRV = P_1;
		return GetCurrentWordContext("find_word_regex", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(CS_8_locals_7.IOPWLBITxB))
			{
				return AiHelper_5.CreateError("---", " |");
			}
			Document document = GetActiveDocument(app);
			int num = ClampValue(CS_8_locals_7.MaxResultCount, 100, 500);
			List<RegexMatchResult> list = FindRegexMatches(document, CS_8_locals_7.IOPWLBITxB, CS_8_locals_7.EyLWlEVNRV, num);
			return AiHelper_5.CreateSuccess("commentToken", BuildRegexResults(document, list, num));
		});
	}

	public AiHelper_5 TableOperation(string P_0, bool P_1, int P_2)
	{
		_G_c__DisplayClass26_0 CS_8_locals_10 = new _G_c__DisplayClass26_0();
		CS_8_locals_10.EJdWmMjUeA = P_0;
		CS_8_locals_10.MaxResultCount = P_2;
		CS_8_locals_10.MatchCase = P_1;
		return GetCurrentWordContext("find_word_table_text", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			if (string.IsNullOrEmpty(CS_8_locals_10.EJdWmMjUeA))
			{
				return AiHelper_5.CreateError("index", "author");
			}
			Document document = GetActiveDocument(app);
			int num = ClampValue(CS_8_locals_10.MaxResultCount, 100, 500);
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
					object MatchCase = CS_8_locals_10.MatchCase;
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
					list.Add(BuildTableInfo(document, CS_8_locals_12.sEvWprZlaY, i, duplicate));
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
			return AiHelper_5.CreateSuccess("date", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				returned = list.Count,
				truncated = (list.Count >= num),
				matches = list
			});
		});
	}

	public AiHelper_5 SelectWordRangeOperation(int P_0, int P_1)
	{
		_G_c__DisplayClass27_0 CS_8_locals_4 = new _G_c__DisplayClass27_0();
		CS_8_locals_4.RangeEndPosition = P_0;
		CS_8_locals_4.RangeEndPosition = P_1;
		return GetCurrentWordContext("select_word_range", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Range range = GetRangeByPosition(document, CS_8_locals_4.RangeEndPosition, CS_8_locals_4.RangeEndPosition);
			document.Activate();
			range.Select();
			return AiHelper_5.CreateSuccess("done", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				page = ComputeIntValue(range),
				rangeStart = range.Start,
				rangeEnd = range.End
			});
		});
	}

	public AiHelper_5 ReplyToCommentOperation(int P_0)
	{
		_G_c__DisplayClass28_0 CS_8_locals_5 = new _G_c__DisplayClass28_0();
		CS_8_locals_5.TableIndex = P_0;
		return GetCurrentWordContext("select_word_table", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			if (CS_8_locals_5.TableIndex < 1 || CS_8_locals_5.TableIndex > document.Tables.Count)
			{
				return AiHelper_5.CreateError("commentText", "replyCount", new
				{
					totalTables = document.Tables.Count
				});
			}
			Table table = document.Tables[CS_8_locals_5.TableIndex];
			document.Activate();
			table.Range.Select();
			return AiHelper_5.CreateSuccess("repliesReturned", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = CS_8_locals_5.TableIndex,
				page = ComputeIntValue(table.Range),
				rangeStart = table.Range.Start,
				rangeEnd = table.Range.End
			});
		});
	}

	public AiHelper_5 AddCommentOperation(string P_0)
	{
		_G_c__DisplayClass29_0 CS_8_locals_5 = new _G_c__DisplayClass29_0();
		CS_8_locals_5.CommentText = P_0;
		return GetCurrentWordContext("add_word_comment_at_selection", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass29_1 CS_8_locals_17 = new _G_c__DisplayClass29_1();
			CS_8_locals_17.DTFWhrapJW = CS_8_locals_5;
			if (string.IsNullOrWhiteSpace(CS_8_locals_5.CommentText))
			{
				return AiHelper_5.CreateError("repliesTruncated", "replies");
			}
			CS_8_locals_17.doc = GetActiveDocument(app);
			CS_8_locals_17.CurrentSelection = app.Selection;
			if (CS_8_locals_17.CurrentSelection == null || CS_8_locals_17.CurrentSelection.Range == null || string.IsNullOrWhiteSpace(NormalizeText(CS_8_locals_17.CurrentSelection.Range.Text)))
			{
				return AiHelper_5.CreateError("anchorRangeStart", "anchorRangeEnd");
			}
			return (!IsRangeValid(CS_8_locals_17.CurrentSelection.Range)) ? AiHelper_5.CreateError("anchorText", "commentToken") : oBKTTgZY41(app, "index", delegate
			{
				Comments comments = CS_8_locals_17.doc.Comments;
				Range range = CS_8_locals_17.CurrentSelection.Range;
				object Text = CS_8_locals_17.DTFWhrapJW.CommentText.Trim();
				Comment comment = comments.Add(range, ref Text);
				return AiHelper_5.CreateSuccess("author", BuildCommentAddedInfo(CS_8_locals_17.doc, CS_8_locals_17.CurrentSelection.Range, comment.Index, CS_8_locals_17.DTFWhrapJW.CommentText));
			});
		});
	}

	public AiHelper_5 qJwDJmPsvM(int P_0, int P_1, string P_2)
	{
		_G_c__DisplayClass30_0 CS_8_locals_12 = new _G_c__DisplayClass30_0();
		CS_8_locals_12.CommentText = P_2;
		CS_8_locals_12.bHXWPpRCjJ = P_0;
		CS_8_locals_12.WKMWApZUrG = P_1;
		return GetCurrentWordContext("add_word_comment_at_range", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass30_1 CS_8_locals_20 = new _G_c__DisplayClass30_1();
			CS_8_locals_20.ClosureScope = CS_8_locals_12;
			if (string.IsNullOrWhiteSpace(CS_8_locals_12.CommentText))
			{
				return AiHelper_5.CreateError("date", "done");
			}
			CS_8_locals_20.doc = GetActiveDocument(app);
			CS_8_locals_20.ComputedRange = GetRangeByPosition(CS_8_locals_20.doc, CS_8_locals_12.bHXWPpRCjJ, CS_8_locals_12.WKMWApZUrG);
			AiHelper_5 insertResult = ValidateRange(app, CS_8_locals_20.doc, CS_8_locals_20.ComputedRange);
			return (insertResult != null) ? insertResult : oBKTTgZY41(app, "commentText", delegate
			{
				Comments comments = CS_8_locals_20.doc.Comments;
				Range range = CS_8_locals_20.ComputedRange;
				object Text = CS_8_locals_20.ClosureScope.CommentText.Trim();
				Comment comment = comments.Add(range, ref Text);
				return AiHelper_5.CreateSuccess("当前没有打开的 Word 文档。", BuildCommentAddedInfo(CS_8_locals_20.doc, CS_8_locals_20.ComputedRange, comment.Index, CS_8_locals_20.ClosureScope.CommentText));
			});
		});
	}

	public AiHelper_5 AddCommentOperation(int P_0, int P_1, int P_2, string P_3)
	{
		_G_c__DisplayClass31_0 CS_8_locals_13 = new _G_c__DisplayClass31_0();
		CS_8_locals_13.JbiWxBXGfL = P_3;
		CS_8_locals_13.rNUWdaMass = P_0;
		CS_8_locals_13.NumericParameter = P_1;
		CS_8_locals_13.NumericParameter = P_2;
		return GetCurrentWordContext("add_word_comment_at_paragraph_range", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass31_1 CS_8_locals_22 = new _G_c__DisplayClass31_1();
			CS_8_locals_22.ClosureScope = CS_8_locals_13;
			if (string.IsNullOrWhiteSpace(CS_8_locals_13.JbiWxBXGfL))
			{
				return AiHelper_5.CreateError("no_document", "commentToken 或正整数 commentIndex 至少需要提供一个。");
			}
			CS_8_locals_22.doc = GetActiveDocument(app);
			AiHelper_5 insertResult = JXpTldftkV(CS_8_locals_22.doc, CS_8_locals_13.rNUWdaMass, CS_8_locals_13.NumericParameter, CS_8_locals_13.NumericParameter, out CS_8_locals_22.ComputedRange);
			if (insertResult != null)
			{
				return insertResult;
			}
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ValidateRange(app, CS_8_locals_22.doc, CS_8_locals_22.ComputedRange);
			return (rU18qH9owXvBsPZ0iiU3 != null) ? rU18qH9owXvBsPZ0iiU3 : oBKTTgZY41(app, "invalid_arguments", delegate
			{
				Comments comments = CS_8_locals_22.doc.Comments;
				Range range = CS_8_locals_22.ComputedRange;
				object Text = CS_8_locals_22.ClosureScope.JbiWxBXGfL.Trim();
				Comment comment = comments.Add(range, ref Text);
				return AiHelper_5.CreateSuccess("未找到指定 index 的 Word 批注。请重新读取批注后再回复。", BuildCommentAddedInfo(CS_8_locals_22.doc, CS_8_locals_22.ComputedRange, comment.Index, CS_8_locals_22.ClosureScope.JbiWxBXGfL));
			});
		});
	}

	public AiHelper_5 AddCommentOperation(int P_0, int P_1, int P_2, string P_3)
	{
		_G_c__DisplayClass32_0 CS_8_locals_14 = new _G_c__DisplayClass32_0();
		CS_8_locals_14.CommentText = P_3;
		CS_8_locals_14.TableIndex = P_0;
		CS_8_locals_14.RowIndex = P_1;
		CS_8_locals_14.ColumnIndex = P_2;
		return GetCurrentWordContext("add_word_comment_at_table_cell", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass32_1 CS_8_locals_29 = new _G_c__DisplayClass32_1();
			CS_8_locals_29.ClosureScope = CS_8_locals_14;
			if (string.IsNullOrWhiteSpace(CS_8_locals_14.CommentText))
			{
				return AiHelper_5.CreateError("comment_not_found", "当前没有打开的 Word 文档。");
			}
			CS_8_locals_29.doc = GetActiveDocument(app);
			CS_8_locals_29.TargetCell = DOQTmyyLCk(CS_8_locals_29.doc, CS_8_locals_14.TableIndex, CS_8_locals_14.RowIndex, CS_8_locals_14.ColumnIndex);
			AiHelper_5 insertResult = ValidateRange(app, CS_8_locals_29.doc, CS_8_locals_29.TargetCell.Range);
			return (insertResult != null) ? insertResult : oBKTTgZY41(app, "no_document", delegate
			{
				Comments comments = CS_8_locals_29.doc.Comments;
				Range range = CS_8_locals_29.TargetCell.Range;
				object Text = CS_8_locals_29.ClosureScope.CommentText.Trim();
				Comment comment = comments.Add(range, ref Text);
				return AiHelper_5.CreateSuccess("commentToken 格式无效。请使用 read_word_comments 返回的 commentToken。", new
				{
					document = CS_8_locals_29.doc.Name,
					documentFullName = CS_8_locals_29.doc.FullName,
					commentIndex = comment.Index,
					tableIndex = CS_8_locals_29.ClosureScope.TableIndex,
					rowIndex = CS_8_locals_29.ClosureScope.RowIndex,
					columnIndex = CS_8_locals_29.ClosureScope.ColumnIndex,
					page = ComputeIntValue(CS_8_locals_29.TargetCell.Range),
					rangeStart = CS_8_locals_29.TargetCell.Range.Start,
					rangeEnd = CS_8_locals_29.TargetCell.Range.End,
					targetPreview = TruncateText(NormalizeText(CS_8_locals_29.TargetCell.Range.Text), 240),
					comment = CS_8_locals_29.ClosureScope.CommentText.Trim()
				});
			});
		});
	}

	public AiHelper_5 AqFDKAiaGP(int P_0, string P_1, string P_2, bool P_3)
	{
		_G_c__DisplayClass33_0 CS_8_locals_20 = new _G_c__DisplayClass33_0();
		CS_8_locals_20.ParagraphIndex = P_0;
		CS_8_locals_20.InsertPosition = P_1;
		CS_8_locals_20.InsertText = P_2;
		CS_8_locals_20.UseTrackChanges = P_3;
		return GetCurrentWordContext("insert_word_paragraph", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass33_1 CS_8_locals_43 = new _G_c__DisplayClass33_1();
			CS_8_locals_43.ClosureScope = CS_8_locals_20;
			CS_8_locals_43.doc = GetActiveDocument(app);
			CS_8_locals_43.TargetParagraph = GetParagraphByIndex(CS_8_locals_43.doc, CS_8_locals_20.ParagraphIndex);
			CS_8_locals_43.InsertPosition = (CS_8_locals_20.InsertPosition ?? "invalid_arguments").Trim().ToLowerInvariant();
			if (CS_8_locals_43.InsertPosition != "未找到指定 commentToken 对应的 Word 批注。请重新读取批注后再回复。" && CS_8_locals_43.InsertPosition != "comment_token_not_found")
			{
				return AiHelper_5.CreateError("commentToken 匹配到多条 Word 批注。请重新读取批注后使用新的 token。", "comment_token_ambiguous", new
				{
					position = CS_8_locals_20.InsertPosition
				});
			}
			CS_8_locals_43.InsertText = CS_8_locals_20.InsertText ?? string.Empty;
			return PPXTOUDVLE(CS_8_locals_43.doc, CS_8_locals_20.UseTrackChanges, delegate
			{
				Range duplicate = CS_8_locals_43.TargetParagraph.Range.Duplicate;
				if (CS_8_locals_43.InsertPosition == "comment-token-v1")
				{
					int start = duplicate.Start;
					object Direction = WdCollapseDirection.wdCollapseStart;
					duplicate.Collapse(ref Direction);
					duplicate.InsertBefore(CS_8_locals_43.InsertText + "-");
					return AiHelper_5.CreateSuccess("CMT-", new
					{
						document = CS_8_locals_43.doc.Name,
						documentFullName = CS_8_locals_43.doc.FullName,
						paragraphIndex = CS_8_locals_43.ClosureScope.ParagraphIndex,
						position = CS_8_locals_43.InsertPosition,
						page = ComputeIntValue(CS_8_locals_43.TargetParagraph.Range),
						rangeStart = start,
						useTrackChanges = CS_8_locals_43.ClosureScope.UseTrackChanges,
						characters = CS_8_locals_43.InsertText.Length,
						textPreview = TruncateText(CS_8_locals_43.InsertText, 240)
					});
				}
				int num = Math.Max(CS_8_locals_43.TargetParagraph.Range.Start, CS_8_locals_43.TargetParagraph.Range.End - 1);
				duplicate.SetRange(num, num);
				duplicate.InsertAfter("CMT-" + CS_8_locals_43.InsertText);
				return AiHelper_5.CreateSuccess("-", new
				{
					document = CS_8_locals_43.doc.Name,
					documentFullName = CS_8_locals_43.doc.FullName,
					paragraphIndex = CS_8_locals_43.ClosureScope.ParagraphIndex,
					position = CS_8_locals_43.InsertPosition,
					page = ComputeIntValue(CS_8_locals_43.TargetParagraph.Range),
					rangeStart = num,
					useTrackChanges = CS_8_locals_43.ClosureScope.UseTrackChanges,
					characters = CS_8_locals_43.InsertText.Length,
					textPreview = TruncateText(CS_8_locals_43.InsertText, 240)
				});
			}, app, CS_8_locals_43.TargetParagraph.Range, "CMT");
		});
	}

	public AiHelper_5 SetParagraphOutlineOperation(int P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass34_0 CS_8_locals_49 = new _G_c__DisplayClass34_0();
		CS_8_locals_49.OutlineLevel = P_2;
		CS_8_locals_49.ParagraphIndex = P_0;
		CS_8_locals_49.ParagraphIndex = P_1;
		return GetCurrentWordContext("set_word_paragraph_outline_level", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass34_1 CS_8_locals_64 = new _G_c__DisplayClass34_1();
			CS_8_locals_64.ClosureScope = CS_8_locals_49;
			if (CS_8_locals_49.OutlineLevel < 0 || CS_8_locals_49.OutlineLevel > 9)
			{
				return AiHelper_5.CreateError("\\\\r\\\\n", "\n", new
				{
					outlineLevel = CS_8_locals_49.OutlineLevel
				});
			}
			if (CS_8_locals_49.ParagraphIndex < 0 || CS_8_locals_49.ParagraphIndex < 0)
			{
				return AiHelper_5.CreateError("\\\\r", "\n", new
				{
					startParagraphIndex = CS_8_locals_49.ParagraphIndex,
					endParagraphIndex = CS_8_locals_49.ParagraphIndex
				});
			}
			if (CS_8_locals_49.ParagraphIndex == 0 && CS_8_locals_49.ParagraphIndex > 0)
			{
				return AiHelper_5.CreateError("\\\\n", "\n", new
				{
					startParagraphIndex = CS_8_locals_49.ParagraphIndex,
					endParagraphIndex = CS_8_locals_49.ParagraphIndex
				});
			}
			if (CS_8_locals_49.ParagraphIndex > 0 && CS_8_locals_49.ParagraphIndex > 0 && CS_8_locals_49.ParagraphIndex < CS_8_locals_49.ParagraphIndex)
			{
				return AiHelper_5.CreateError("\r\n", "\n", new
				{
					startParagraphIndex = CS_8_locals_49.ParagraphIndex,
					endParagraphIndex = CS_8_locals_49.ParagraphIndex
				});
			}
			CS_8_locals_64.doc = GetActiveDocument(app);
			CS_8_locals_64.doc.Activate();
			int num = ComputeIntValue(() => CS_8_locals_64.doc.Paragraphs.Count);
			if (CS_8_locals_49.ParagraphIndex > num)
			{
				return AiHelper_5.CreateError("\\s+", " ", new
				{
					startParagraphIndex = CS_8_locals_49.ParagraphIndex,
					totalParagraphs = num
				});
			}
			if (CS_8_locals_49.ParagraphIndex > num)
			{
				return AiHelper_5.CreateError("tableRange", "cell", new
				{
					endParagraphIndex = CS_8_locals_49.ParagraphIndex,
					totalParagraphs = num
				});
			}
			CS_8_locals_64.ParagraphList = CollectParagraphs(app, CS_8_locals_64.doc, CS_8_locals_49.ParagraphIndex, CS_8_locals_49.ParagraphIndex);
			if (CS_8_locals_64.ParagraphList.Count == 0)
			{
				return AiHelper_5.CreateError(":", "NameLocal", new
				{
					startParagraphIndex = CS_8_locals_49.ParagraphIndex,
					endParagraphIndex = CS_8_locals_49.ParagraphIndex
				});
			}
			AiHelper_5 insertResult = ValidateRange(app, CS_8_locals_64.doc, CS_8_locals_64.ParagraphList[0].Paragraph.Range);
			if (insertResult != null)
			{
				return insertResult;
			}
			CS_8_locals_64.OutlineLevelValue = ClampOutlineLevel(CS_8_locals_49.OutlineLevel);
			CS_8_locals_64.ResultList = new List<object>();
			CS_8_locals_64.ChangedCount = 0;
			CS_8_locals_64.OutlineLevel = 0;
			DyITDXSmDr(app, "Name", delegate
			{
				foreach (AiHelper_1 item in CS_8_locals_64.ParagraphList)
				{
					Paragraph paragraph = item.Paragraph;
					int num2 = ClampOutlineLevel(GetOutlineLevel(paragraph));
					string styleName = GetParagraphStyleName(paragraph);
					string excerpt = TruncateText(NormalizeText(paragraph.Range.Text), 160);
					bool flag = false;
					bool flag2 = false;
					string text = string.Empty;
					try
					{
						paragraph.OutlineLevel = (WdOutlineLevel)CS_8_locals_64.OutlineLevelValue;
						int num3 = ClampOutlineLevel(GetOutlineLevel(paragraph));
						flag2 = num3 == CS_8_locals_64.ClosureScope.OutlineLevel;
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
					int afterOutlineLevel = ClampOutlineLevel(GetOutlineLevel(paragraph));
					if (flag)
					{
						CS_8_locals_64.ChangedCount++;
					}
					if (!flag2)
					{
						CS_8_locals_64.OutlineLevel++;
					}
					CS_8_locals_64.ResultList.Add(new
					{
						paragraphIndex = item.ParagraphIndex,
						rangeStart = paragraph.Range.Start,
						rangeEnd = paragraph.Range.End,
						page = ComputeIntValue(paragraph.Range),
						styleName = styleName,
						beforeOutlineLevel = num2,
						targetOutlineLevel = CS_8_locals_64.ClosureScope.OutlineLevel,
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
				startParagraphIndex = CS_8_locals_49.ParagraphIndex,
				endParagraphIndex = CS_8_locals_49.ParagraphIndex,
				targetOutlineLevel = CS_8_locals_49.OutlineLevel,
				targetOutlineKind = ((CS_8_locals_49.OutlineLevel == 0) ? "[ \\\\t]+" : " "),
				totalParagraphs = CS_8_locals_64.ParagraphList.Count,
				changedCount = CS_8_locals_64.ChangedCount,
				failedCount = CS_8_locals_64.OutlineLevel,
				paragraphs = CS_8_locals_64.ResultList
			};
			return (CS_8_locals_64.OutlineLevel == CS_8_locals_64.ParagraphList.Count) ? AiHelper_5.CreateError("...", "...", anon) : AiHelper_5.CreateSuccess((CS_8_locals_64.OutlineLevel > 0) ? "..." : "get_current_word_context", anon);
		});
	}

	public AiHelper_5 PreviewWordDocument(int P_0, int P_1, string P_2, string P_3, string P_4, bool P_5, bool P_6)
	{
		_G_c__DisplayClass35_0 CS_8_locals_45 = new _G_c__DisplayClass35_0();
		CS_8_locals_45.OperationMode = P_3;
		CS_8_locals_45.ExpectedPreviewToken = P_4;
		CS_8_locals_45.ConfigJson = P_2;
		CS_8_locals_45.RangeStart = P_0;
		CS_8_locals_45.RangeEnd = P_1;
		CS_8_locals_45.AllowHeaderEdit = P_5;
		CS_8_locals_45.UseTrackChanges = P_6;
		return GetCurrentWordContext("fill_word_table_cells_by_model", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass35_1 CS_8_locals_69 = new _G_c__DisplayClass35_1();
			CS_8_locals_69.ClosureScope = CS_8_locals_45;
			string a = (CS_8_locals_45.OperationMode ?? "preview_word_document").Trim().ToLowerInvariant();
			if (!string.Equals(a, "preview_word_selection", StringComparison.Ordinal) && !string.Equals(a, "read_word_range", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateError("read_word_paragraphs", "read_word_outline", new
				{
					mode = CS_8_locals_45.OperationMode
				});
			}
			if (string.Equals(a, "read_word_section", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(CS_8_locals_45.ExpectedPreviewToken))
			{
				return AiHelper_5.CreateError("read_word_tables", "read_word_comments");
			}
			List<TableCellModel> list;
			AiHelper_5 insertResult = XIPTkGpqwW(CS_8_locals_45.ConfigJson, out list);
			if (insertResult != null)
			{
				return insertResult;
			}
			CS_8_locals_69.doc = GetActiveDocument(app);
			Range range;
			try
			{
				range = GetRangeByPosition(CS_8_locals_69.doc, CS_8_locals_45.RangeStart, CS_8_locals_45.RangeEnd);
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateError("reply_word_comment", "find_word_heading", new
				{
					rangeStart = CS_8_locals_45.RangeStart,
					rangeEnd = CS_8_locals_45.RangeEnd,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ExecuteOperation(range, list, out CS_8_locals_69.CellChangeList);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_69.PreviewToken = BuildPreviewToken(CS_8_locals_69.doc, CS_8_locals_45.RangeStart, CS_8_locals_45.RangeEnd, CS_8_locals_69.CellChangeList);
			object obj = iLJTdpgWxW(CS_8_locals_69.doc, CS_8_locals_45.RangeStart, CS_8_locals_45.RangeEnd, CS_8_locals_45.AllowHeaderEdit, CS_8_locals_45.UseTrackChanges, CS_8_locals_69.PreviewToken, CS_8_locals_69.CellChangeList);
			if (string.Equals(a, "find_word_text", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateSuccess("find_word_regex", obj);
			}
			if (CS_8_locals_69.CellChangeList.Count((AiHelper_21 change) => !change.Writable) > 0)
			{
				return AiHelper_5.CreateError("find_word_table_text", "select_word_range", obj);
			}
			if (!ValidatePreviewToken(CS_8_locals_69.PreviewToken, CS_8_locals_45.ExpectedPreviewToken))
			{
				return AiHelper_5.CreateError("select_word_table", "add_word_comment_at_selection", new
				{
					rangeStart = CS_8_locals_45.RangeStart,
					rangeEnd = CS_8_locals_45.RangeEnd,
					expectedPreviewToken = CS_8_locals_45.ExpectedPreviewToken,
					currentPreviewToken = CS_8_locals_69.PreviewToken,
					preview = obj
				});
			}
			Range range2 = ((CS_8_locals_69.CellChangeList.Count > 0 && CS_8_locals_69.CellChangeList[0].Cell != null) ? GetCellRange(CS_8_locals_69.CellChangeList[0].Cell) : range);
			return PPXTOUDVLE(CS_8_locals_69.doc, CS_8_locals_45.UseTrackChanges, delegate
			{
				List<object> list2 = new List<object>();
				int num = 0;
				for (int i = 0; i < CS_8_locals_69.CellChangeList.Count; i++)
				{
					_G_c__DisplayClass35_2 CS_8_locals_71 = new _G_c__DisplayClass35_2();
					CS_8_locals_71.CellChange = CS_8_locals_69.CellChangeList[i];
					bool flag2;
					string text;
					bool flag = bIRgTubXiW(CS_8_locals_71.CellChange.Cell, CS_8_locals_71.CellChange.NewText, out flag2, out text);
					if (flag && flag2)
					{
						num++;
					}
					list2.Add(new
					{
						requestIndex = CS_8_locals_71.CellChange.RequestIndex,
						localTableIndex = CS_8_locals_71.CellChange.LocalTableIndex,
						rowIndex = CS_8_locals_71.CellChange.RowIndex,
						columnIndex = CS_8_locals_71.CellChange.ColumnIndex,
						isHeader = CS_8_locals_71.CellChange.IsHeader,
						page = ComputeIntValue(CS_8_locals_71.CellChange.Cell.Range),
						rangeStart = Ex5TMxi7X1(() => CS_8_locals_71.CellChange.Cell.Range.Start, CS_8_locals_71.CellChange.RangeStart),
						rangeEnd = Ex5TMxi7X1(() => CS_8_locals_71.CellChange.Cell.Range.End, CS_8_locals_71.CellChange.RangeEnd),
						oldText = CS_8_locals_71.CellChange.OldText,
						newText = CS_8_locals_71.CellChange.NewText,
						changed = (flag && flag2),
						success = flag,
						error = (flag ? null : text)
					});
				}
				return AiHelper_5.CreateSuccess("add_word_comment_at_range", new
				{
					document = CS_8_locals_69.doc.Name,
					documentFullName = CS_8_locals_69.doc.FullName,
					rangeStart = CS_8_locals_69.ClosureScope.RangeStart,
					rangeEnd = CS_8_locals_69.ClosureScope.RangeEnd,
					totalRequests = CS_8_locals_69.CellChangeList.Count,
					changed = num,
					useTrackChanges = CS_8_locals_69.ClosureScope.UseTrackChanges,
					allowHeaderEdit = CS_8_locals_69.ClosureScope.AllowHeaderEdit,
					previewToken = CS_8_locals_69.PreviewToken,
					results = list2
				});
			}, app, range2, "add_word_comment_at_paragraph_range");
		});
	}

	public AiHelper_5 AddCommentOperation(int P_0, int P_1, int P_2, int P_3, string P_4, int P_5, string P_6, string P_7, bool P_8, string P_9)
	{
		_G_c__DisplayClass36_0 CS_8_locals_53 = new _G_c__DisplayClass36_0();
		CS_8_locals_53.OperationMode = P_6;
		CS_8_locals_53.PositionParam = P_4;
		CS_8_locals_53.InsertCount = P_5;
		CS_8_locals_53.ExpectedPreviewToken = P_7;
		CS_8_locals_53.RangeStart = P_0;
		CS_8_locals_53.RangeEnd = P_1;
		CS_8_locals_53.InsertCount = P_2;
		CS_8_locals_53.InsertCount = P_3;
		CS_8_locals_53.UseTrackChanges = P_8;
		CS_8_locals_53.AnchorText = P_9;
		return GetCurrentWordContext("insert_word_table_rows_by_model", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass36_1 CS_8_locals_80 = new _G_c__DisplayClass36_1();
			CS_8_locals_80.gZUkBpLoZF = CS_8_locals_53;
			CS_8_locals_80.WordApplication = app;
			string a = (CS_8_locals_53.OperationMode ?? "add_word_comment_at_table_cell").Trim().ToLowerInvariant();
			if (!string.Equals(a, "insert_word_paragraph", StringComparison.Ordinal) && !string.Equals(a, "set_word_paragraph_outline_level", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateError("fill_word_table_cells_by_model", "insert_word_table_rows_by_model", new
				{
					mode = CS_8_locals_53.OperationMode
				});
			}
			string text = ParsePosition(CS_8_locals_53.PositionParam);
			if (text == null)
			{
				return AiHelper_5.CreateError("insert_word_table_at_range", "replace_word_range_with_track_changes", new
				{
					position = CS_8_locals_53.PositionParam
				});
			}
			if (CS_8_locals_53.InsertCount < 1 || CS_8_locals_53.InsertCount > 20)
			{
				return AiHelper_5.CreateError("replace_word_selection_with_track_changes", "batch_replace_word_text_execute", new
				{
					count = CS_8_locals_53.InsertCount,
					min = 1,
					max = 20
				});
			}
			if (string.Equals(a, "export_word_comments", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(CS_8_locals_53.ExpectedPreviewToken))
			{
				return AiHelper_5.CreateError("adjust_selected_word_tables_format", "adjust_selected_word_paragraphs_format");
			}
			CS_8_locals_80.doc = GetActiveDocument(CS_8_locals_80.WordApplication);
			Range range;
			try
			{
				range = GetRangeByPosition(CS_8_locals_80.doc, CS_8_locals_53.RangeStart, CS_8_locals_53.RangeEnd);
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateError("表格_", "Word table adjustment config read.", new
				{
					rangeStart = CS_8_locals_53.RangeStart,
					rangeEnd = CS_8_locals_53.RangeEnd,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			AiHelper_5 insertResult = ExecuteOperation(range, CS_8_locals_53.InsertCount, CS_8_locals_53.InsertCount, text, CS_8_locals_53.InsertCount, CS_8_locals_53.UseTrackChanges, CS_8_locals_53.AnchorText, out CS_8_locals_80.TableToolService);
			if (insertResult != null)
			{
				return insertResult;
			}
			CS_8_locals_80.PreviewToken = lKeTPQlpbN(CS_8_locals_80.doc, CS_8_locals_53.RangeStart, CS_8_locals_53.RangeEnd, CS_8_locals_80.TableToolService);
			object obj = fYyThhstYU(CS_8_locals_80.doc, CS_8_locals_53.RangeStart, CS_8_locals_53.RangeEnd, CS_8_locals_80.PreviewToken, CS_8_locals_80.TableToolService);
			if (string.Equals(a, "table", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateSuccess("表格配置_方案名", obj);
			}
			return (!ValidatePreviewToken(CS_8_locals_80.PreviewToken, CS_8_locals_53.ExpectedPreviewToken)) ? AiHelper_5.CreateError("表格_单元格_上边距", "0", new
			{
				rangeStart = CS_8_locals_53.RangeStart,
				rangeEnd = CS_8_locals_53.RangeEnd,
				expectedPreviewToken = CS_8_locals_53.ExpectedPreviewToken,
				currentPreviewToken = CS_8_locals_80.PreviewToken,
				preview = obj
			}) : PPXTOUDVLE(CS_8_locals_80.doc, CS_8_locals_53.UseTrackChanges, delegate
			{
				if (!M4PTA9V6B2(CS_8_locals_80.WordApplication, CS_8_locals_80.TableToolService.AnchorCell, CS_8_locals_80.TableToolService.Position, CS_8_locals_80.TableToolService.Count, out var error))
				{
					return AiHelper_5.CreateError("表格_单元格_下边距", "0", new
					{
						rangeStart = CS_8_locals_80.gZUkBpLoZF.RangeStart,
						rangeEnd = CS_8_locals_80.gZUkBpLoZF.RangeEnd,
						LocalTableIndex = CS_8_locals_80.TableToolService.LocalTableIndex,
						AnchorRowIndex = CS_8_locals_80.TableToolService.AnchorRowIndex,
						Position = CS_8_locals_80.TableToolService.Position,
						Count = CS_8_locals_80.TableToolService.Count,
						error = error
					});
				}
				HbPTWYrAup(CS_8_locals_80.TableToolService.Table, out var rowsAfter, out var columnsAfter);
				return AiHelper_5.CreateSuccess("表格_单元格_左边距", new
				{
					document = CS_8_locals_80.doc.Name,
					documentFullName = CS_8_locals_80.doc.FullName,
					rangeStart = CS_8_locals_80.gZUkBpLoZF.RangeStart,
					rangeEnd = CS_8_locals_80.gZUkBpLoZF.RangeEnd,
					localTableIndex = CS_8_locals_80.TableToolService.LocalTableIndex,
					anchorRowIndex = CS_8_locals_80.TableToolService.AnchorRowIndex,
					position = CS_8_locals_80.TableToolService.Position,
					count = CS_8_locals_80.TableToolService.Count,
					useTrackChanges = CS_8_locals_80.gZUkBpLoZF.UseTrackChanges,
					previewToken = CS_8_locals_80.PreviewToken,
					rowsBefore = CS_8_locals_80.TableToolService.RowsBefore,
					rowsAfter = rowsAfter,
					columnsBefore = CS_8_locals_80.TableToolService.ColumnsBefore,
					columnsAfter = columnsAfter,
					insertedRows = BuildList(CS_8_locals_80.TableToolService),
					anchor = BuildAnchorInfo(CS_8_locals_80.TableToolService)
				});
			}, CS_8_locals_80.WordApplication, CS_8_locals_80.TableToolService.AnchorCell.Range, "7");
		});
	}

	public AiHelper_5 OCnDjfAYoX(int P_0, int P_1, int P_2, int P_3, string P_4, string P_5, string P_6, bool P_7, bool P_8)
	{
		_G_c__DisplayClass37_0 CS_8_locals_53 = new _G_c__DisplayClass37_0();
		CS_8_locals_53.OperationMode = P_5;
		CS_8_locals_53.tBmkugaqPB = P_4;
		CS_8_locals_53.fnLkDwNHkT = P_2;
		CS_8_locals_53.FAJkTvvVfq = P_3;
		CS_8_locals_53.ExpectedPreviewToken = P_6;
		CS_8_locals_53.RangeStart = P_0;
		CS_8_locals_53.FHWkIpxSEj = P_1;
		CS_8_locals_53.UseTrackChanges = P_7;
		CS_8_locals_53.jdmkHkXOfG = P_8;
		return GetCurrentWordContext("insert_word_table_at_range", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass37_1 CS_8_locals_87 = new _G_c__DisplayClass37_1();
			CS_8_locals_87.ClosureScope = CS_8_locals_53;
			string a = (CS_8_locals_53.OperationMode ?? "表格_单元格_右边距").Trim().ToLowerInvariant();
			if (!string.Equals(a, "7", StringComparison.Ordinal) && !string.Equals(a, "表格_单元格_底色", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateError("-16777216", "表格_行_行高", new
				{
					mode = CS_8_locals_53.OperationMode
				});
			}
			string text = NormalizeConfigKey(CS_8_locals_53.tBmkugaqPB);
			if (text == null)
			{
				return AiHelper_5.CreateError("0.7", "表格_宽度模式", new
				{
					placement = CS_8_locals_53.tBmkugaqPB
				});
			}
			if (CS_8_locals_53.fnLkDwNHkT < 1 || CS_8_locals_53.fnLkDwNHkT > 200)
			{
				return AiHelper_5.CreateError("自适应宽度", "表格_最大列宽_宽度", new
				{
					rows = CS_8_locals_53.fnLkDwNHkT,
					min = 1,
					max = 200
				});
			}
			if (CS_8_locals_53.FAJkTvvVfq < 1 || CS_8_locals_53.FAJkTvvVfq > 63)
			{
				return AiHelper_5.CreateError("18.5", "表格_段落格式_中文字体", new
				{
					columns = CS_8_locals_53.FAJkTvvVfq,
					min = 1,
					max = 63
				});
			}
			if (string.Equals(a, "宋体", StringComparison.Ordinal) && string.IsNullOrWhiteSpace(CS_8_locals_53.ExpectedPreviewToken))
			{
				return AiHelper_5.CreateError("表格_段落格式_西文字体", "宋体");
			}
			CS_8_locals_87.doc = GetActiveDocument(app);
			Range range;
			try
			{
				range = GetRangeByPosition(CS_8_locals_87.doc, CS_8_locals_53.RangeStart, CS_8_locals_53.FHWkIpxSEj);
			}
			catch (Exception ex)
			{
				return AiHelper_5.CreateError("表格_段落格式_字号", "9", new
				{
					rangeStart = CS_8_locals_53.RangeStart,
					rangeEnd = CS_8_locals_53.FHWkIpxSEj,
					exception = ex.GetType().Name,
					message = ex.Message
				});
			}
			AiHelper_5 insertResult = ExecuteTableEdit(CS_8_locals_87.doc, range, CS_8_locals_53.fnLkDwNHkT, CS_8_locals_53.FAJkTvvVfq, text, CS_8_locals_53.UseTrackChanges, CS_8_locals_53.jdmkHkXOfG, out CS_8_locals_87.TableEditService);
			if (insertResult != null)
			{
				return insertResult;
			}
			CS_8_locals_87.PreviewToken = BIJTcpAmqJ(CS_8_locals_87.doc, CS_8_locals_53.RangeStart, CS_8_locals_53.FHWkIpxSEj, CS_8_locals_87.TableEditService);
			object obj = BuildResultObject(CS_8_locals_87.doc, CS_8_locals_53.RangeStart, CS_8_locals_53.FHWkIpxSEj, CS_8_locals_87.PreviewToken, CS_8_locals_87.TableEditService);
			if (string.Equals(a, "表格_段落格式_加粗", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateSuccess("1", obj);
			}
			return (!ValidatePreviewToken(CS_8_locals_87.PreviewToken, CS_8_locals_53.ExpectedPreviewToken)) ? AiHelper_5.CreateError("表格_段落格式_行距样式", "4", new
			{
				rangeStart = CS_8_locals_53.RangeStart,
				rangeEnd = CS_8_locals_53.FHWkIpxSEj,
				expectedPreviewToken = CS_8_locals_53.ExpectedPreviewToken,
				currentPreviewToken = CS_8_locals_87.PreviewToken,
				preview = obj
			}) : PPXTOUDVLE(CS_8_locals_87.doc, CS_8_locals_53.UseTrackChanges, delegate
			{
				_G_c__DisplayClass37_2 CS_8_locals_91 = new _G_c__DisplayClass37_2();
				if (!psHTenZWYL(CS_8_locals_87.doc, CS_8_locals_87.TableEditService, out CS_8_locals_91.TargetTable, out var error))
				{
					return AiHelper_5.CreateError("表格_段落格式_行距值", "18", new
					{
						rangeStart = CS_8_locals_87.ClosureScope.RangeStart,
						rangeEnd = CS_8_locals_87.ClosureScope.FHWkIpxSEj,
						Rows = CS_8_locals_87.TableEditService.Rows,
						Columns = CS_8_locals_87.TableEditService.Columns,
						Placement = CS_8_locals_87.TableEditService.Placement,
						error = error
					});
				}
				bool flag = false;
				string text2 = null;
				if (CS_8_locals_87.TableEditService.AdjustAfterInsert)
				{
					flag = EOXTyRsfXn(CS_8_locals_91.TargetTable, out text2);
					if (!flag)
					{
						return AiHelper_5.CreateError("表格_段落格式_段前距单位", "行", new
						{
							rangeStart = CS_8_locals_87.ClosureScope.RangeStart,
							rangeEnd = CS_8_locals_87.ClosureScope.FHWkIpxSEj,
							Rows = CS_8_locals_87.TableEditService.Rows,
							Columns = CS_8_locals_87.TableEditService.Columns,
							Placement = CS_8_locals_87.TableEditService.Placement,
							tableIndex = GetTableIndex(CS_8_locals_87.doc, CS_8_locals_91.TargetTable),
							tableRangeStart = Ex5TMxi7X1(() => CS_8_locals_91.TargetTable.Range.Start, 0),
							tableRangeEnd = Ex5TMxi7X1(() => CS_8_locals_91.TargetTable.Range.End, 0),
							error = text2
						});
					}
				}
				int tableIndex = GetTableIndex(CS_8_locals_87.doc, CS_8_locals_91.TargetTable);
				int num = Ex5TMxi7X1(() => CS_8_locals_91.TargetTable.Range.Start, 0);
				int num2 = Ex5TMxi7X1(() => CS_8_locals_91.TargetTable.Range.End, 0);
				HbPTWYrAup(CS_8_locals_91.TargetTable, out var num3, out var num4);
				return AiHelper_5.CreateSuccess("表格_段落格式_段前距", new
				{
					document = CS_8_locals_87.doc.Name,
					documentFullName = CS_8_locals_87.doc.FullName,
					rangeStart = CS_8_locals_87.ClosureScope.RangeStart,
					rangeEnd = CS_8_locals_87.ClosureScope.FHWkIpxSEj,
					placement = CS_8_locals_87.TableEditService.Placement,
					rows = ((num3 > 0) ? num3 : CS_8_locals_87.TableEditService.Rows),
					columns = ((num4 > 0) ? num4 : CS_8_locals_87.TableEditService.Columns),
					requestedRows = CS_8_locals_87.TableEditService.Rows,
					requestedColumns = CS_8_locals_87.TableEditService.Columns,
					useTrackChanges = CS_8_locals_87.ClosureScope.UseTrackChanges,
					adjustAfterInsert = CS_8_locals_87.TableEditService.AdjustAfterInsert,
					adjusted = flag,
					adjustError = text2,
					previewToken = CS_8_locals_87.PreviewToken,
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
			}, app, CS_8_locals_87.TableEditService.FocusRange, "0");
		});
	}

	public AiHelper_5 ReplaceTextOperation(int P_0, int P_1, string P_2)
	{
		_G_c__DisplayClass38_0 CS_8_locals_6 = new _G_c__DisplayClass38_0();
		CS_8_locals_6.RangeEndPosition = P_0;
		CS_8_locals_6.SeWkYUegMC = P_1;
		CS_8_locals_6.TlKkZRlAoO = P_2;
		return GetCurrentWordContext("replace_word_range_with_track_changes", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Range range = GetRangeByPosition(document, CS_8_locals_6.RangeEndPosition, CS_8_locals_6.SeWkYUegMC);
			return ExecuteOperation(app, document, range, CS_8_locals_6.TlKkZRlAoO ?? string.Empty);
		});
	}

	public AiHelper_5 ReplaceTextOperation(string P_0)
	{
		_G_c__DisplayClass39_0 CS_8_locals_2 = new _G_c__DisplayClass39_0();
		CS_8_locals_2.ConfigJson = P_0;
		return GetCurrentWordContext("replace_word_selection_with_track_changes", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Selection selection = app.Selection;
			if (selection == null || selection.Range == null || string.IsNullOrWhiteSpace(NormalizeText(selection.Range.Text)))
			{
				return AiHelper_5.CreateError("表格_合计处理_下划线", "3");
			}
			return (!IsRangeValid(selection.Range)) ? AiHelper_5.CreateError("表格_小计处理_下划线", "1") : ExecuteOperation(app, document, selection.Range, CS_8_locals_2.ConfigJson ?? string.Empty);
		});
	}

	public AiHelper_5 XYsDfGZnQW(string P_0, string P_1, int P_2, bool P_3, bool P_4, bool P_5, int P_6)
	{
		_G_c__DisplayClass40_0 CS_8_locals_12 = new _G_c__DisplayClass40_0();
		CS_8_locals_12.FindText = P_0;
		CS_8_locals_12.PibkwEgMgL = P_1;
		CS_8_locals_12.wQVktjGfvi = P_3;
		CS_8_locals_12.bfxkLTOfxK = P_4;
		CS_8_locals_12.UseTrackChanges = P_5;
		CS_8_locals_12.ExpectedCount = P_2;
		CS_8_locals_12.MaxMatchesIgnored = P_6;
		return GetCurrentWordContext("batch_replace_word_text_execute", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass40_1 CS_8_locals_44 = new _G_c__DisplayClass40_1();
			CS_8_locals_44.obZkGStNVx = CS_8_locals_12;
			CS_8_locals_44.cQAkoUnyRF = app;
			if (string.IsNullOrEmpty(CS_8_locals_12.FindText))
			{
				return AiHelper_5.CreateError("表格_合计小计处理_下划线包含文字", "表格_合计处理_下划线包含合计");
			}
			CS_8_locals_44.doc = GetActiveDocument(CS_8_locals_44.cQAkoUnyRF);
			Document document = CS_8_locals_44.doc;
			object Start = CS_8_locals_44.doc.Content.Start;
			object End = Math.Min(CS_8_locals_44.doc.Content.End, CS_8_locals_44.doc.Content.Start + 1);
			Range range = document.Range(ref Start, ref End);
			AiHelper_5 insertResult = ValidateRange(CS_8_locals_44.cQAkoUnyRF, CS_8_locals_44.doc, range);
			return (insertResult != null) ? insertResult : oBKTTgZY41(CS_8_locals_44.cQAkoUnyRF, "0", delegate
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
					find.Text = CS_8_locals_44.obZkGStNVx.FindText;
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
					return AiHelper_5.CreateSuccess("表格_合计处理_加粗", new
					{
						document = CS_8_locals_44.doc.Name,
						documentFullName = CS_8_locals_44.doc.FullName,
						findText = CS_8_locals_44.obZkGStNVx.FindText,
						replaceText = (CS_8_locals_44.obZkGStNVx.PibkwEgMgL ?? string.Empty),
						matchCase = CS_8_locals_44.obZkGStNVx.wQVktjGfvi,
						wholeWord = CS_8_locals_44.obZkGStNVx.bfxkLTOfxK,
						useTrackChanges = true,
						requestedUseTrackChanges = CS_8_locals_44.obZkGStNVx.UseTrackChanges,
						forcedTrackChanges = true,
						replaceMethod = "0",
						expectedMatchCount = CS_8_locals_44.obZkGStNVx.ExpectedCount,
						replacedCountKnown = false,
						previewRequired = false,
						maxMatchesIgnored = CS_8_locals_44.obZkGStNVx.MaxMatchesIgnored
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

	public AiHelper_5 QJUDMaARAF()
	{
		return GetCurrentWordContext("export_word_comments", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass41_0 CS_8_locals_4 = new _G_c__DisplayClass41_0();
			CS_8_locals_4.doc = GetActiveDocument(app);
			TableValidationService.CKSKKAnPKH();
			return AiHelper_5.CreateSuccess("表格_小计处理_加粗", new
			{
				document = CS_8_locals_4.doc.Name,
				documentFullName = CS_8_locals_4.doc.FullName,
				commentCount = ComputeIntValue(() => CS_8_locals_4.doc.Comments.Count)
			});
		});
	}

	public AiHelper_5 TableOperation()
	{
		return GetCurrentWordContext("adjust_selected_word_tables_format", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass42_0 CS_8_locals_7 = new _G_c__DisplayClass42_0();
			CS_8_locals_7.WordApplication = app;
			Document document = GetActiveDocument(CS_8_locals_7.WordApplication);
			document.Activate();
			if (CS_8_locals_7.WordApplication.Selection == null || CS_8_locals_7.WordApplication.Selection.Range == null || !IsRangeValid(CS_8_locals_7.WordApplication.Selection.Range))
			{
				return AiHelper_5.CreateError("0", "表格_合计小计处理_加粗包含文字");
			}
			int num = ComputeIntValue(() => CS_8_locals_7.WordApplication.Selection.Tables.Count);
			if (num <= 0)
			{
				return AiHelper_5.CreateError("表格_合计处理_加粗包含合计", "0");
			}
			DyITDXSmDr(CS_8_locals_7.WordApplication, "read_word_table_adjustment_config failed", BatchTableAdjustService.HUeflwYrZr);
			return AiHelper_5.CreateSuccess("config_error", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				selectedTables = num,
				adjustedTables = num
			});
		});
	}

	public AiHelper_5 FormatParagraphsOperation()
	{
		return GetCurrentWordContext("adjust_selected_word_paragraphs_format", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass43_0 CS_8_locals_7 = new _G_c__DisplayClass43_0();
			CS_8_locals_7.WordApplication = app;
			Document document = GetActiveDocument(CS_8_locals_7.WordApplication);
			document.Activate();
			if (CS_8_locals_7.WordApplication.Selection == null || CS_8_locals_7.WordApplication.Selection.Range == null || !IsRangeValid(CS_8_locals_7.WordApplication.Selection.Range))
			{
				return AiHelper_5.CreateError("一级", "二级");
			}
			int num = ComputeIntValue(() => CS_8_locals_7.WordApplication.Selection.Paragraphs.Count);
			if (num <= 0)
			{
				return AiHelper_5.CreateError("三级", "四级");
			}
			DyITDXSmDr(CS_8_locals_7.WordApplication, "五级", BatchReplaceService.BBAMen3SA4);
			return AiHelper_5.CreateSuccess("其他", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				selectedParagraphs = num
			});
		});
	}

	public AiHelper_5 SetTableBorders()
	{
		try
		{
			TableBorderConfig.Current.SaveToFile();
			Dictionary<string, object> dictionary = TableBorderConfig.Current.GetAllLegacy();
			Dictionary<string, string> raw = ExtractConfigEntries(dictionary, "表格_");
			return AiHelper_5.CreateSuccess("Word table adjustment config read.", new
			{
				configType = "table",
				preset = GetConfigValue(dictionary, "表格配置_方案名"),
				cellPadding = new
				{
					top = GetConfigValue(dictionary, "表格_单元格_上边距", "0"),
					bottom = GetConfigValue(dictionary, "表格_单元格_下边距", "0"),
					left = GetConfigValue(dictionary, "表格_单元格_左边距", "7"),
					right = GetConfigValue(dictionary, "表格_单元格_右边距", "7"),
					headerBackgroundColor = GetConfigValue(dictionary, "表格_单元格_底色", "-16777216")
				},
				row = new
				{
					height = GetConfigValue(dictionary, "表格_行_行高", "0.7")
				},
				width = new
				{
					mode = GetConfigValue(dictionary, "表格_宽度模式", "自适应宽度"),
					maxColumnWidth = GetConfigValue(dictionary, "表格_最大列宽_宽度", "18.5")
				},
				font = new
				{
					chineseFont = GetConfigValue(dictionary, "表格_段落格式_中文字体", "宋体"),
					westernFont = GetConfigValue(dictionary, "表格_段落格式_西文字体", "宋体"),
					size = GetConfigValue(dictionary, "表格_段落格式_字号", "9"),
					headerBold = GetConfigValue(dictionary, "表格_段落格式_加粗", "1")
				},
				paragraph = new
				{
					lineSpacingRule = GetConfigValue(dictionary, "表格_段落格式_行距样式", "4"),
					lineSpacing = GetConfigValue(dictionary, "表格_段落格式_行距值", "18"),
					spacingUnit = GetConfigValue(dictionary, "表格_段落格式_段前距单位", "行"),
					spaceBefore = GetConfigValue(dictionary, "表格_段落格式_段前距", "0"),
					spaceAfter = GetConfigValue(dictionary, "表格_段落格式_段后距", "0")
				},
				borders = BuildBorderConfig(dictionary),
				alignment = BuildAlignmentConfig(dictionary),
				summary = new
				{
					totalUnderline = GetConfigValue(dictionary, "表格_合计处理_下划线", "3"),
					subtotalUnderline = GetConfigValue(dictionary, "表格_小计处理_下划线", "1"),
					underlineIncludesText = GetConfigValue(dictionary, "表格_合计小计处理_下划线包含文字", GetConfigValue(dictionary, "表格_合计处理_下划线包含合计", "0")),
					totalBold = GetConfigValue(dictionary, "表格_合计处理_加粗", "0"),
					subtotalBold = GetConfigValue(dictionary, "表格_小计处理_加粗", "0"),
					boldIncludesText = GetConfigValue(dictionary, "表格_合计小计处理_加粗包含文字", GetConfigValue(dictionary, "表格_合计处理_加粗包含合计", "0"))
				},
				raw = raw
			});
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateExceptionError("read_word_table_adjustment_config failed", "config_error", ex);
		}
	}

	public AiHelper_5 SetTableBorders(string P_0)
	{
		try
		{
			_G_c__DisplayClass45_0 CS_8_locals_5 = new _G_c__DisplayClass45_0();
			TableBorderConfig.Current.SaveToFile();
			CS_8_locals_5.UpVkclndys = TableBorderConfig.Current.GetAllLegacy();
			string text = NormalizeKey(P_0);
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
			}).Select((string item) => GetDictValue(CS_8_locals_5.UpVkclndys, item)).ToList();
			return AiHelper_5.CreateSuccess("Word paragraph adjustment config read.", new
			{
				configType = "paragraph",
				preset = GetConfigValue(CS_8_locals_5.UpVkclndys, "段落配置_方案名", GetConfigValue(CS_8_locals_5.UpVkclndys, "段落配置_当前方案")),
				level = (string.IsNullOrWhiteSpace(text) ? null : text),
				levels = levels,
				raw = ExtractConfigEntries(CS_8_locals_5.UpVkclndys, "段落_")
			});
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateExceptionError("read_word_paragraph_adjustment_config failed", "config_error", ex);
		}
	}

	public AiHelper_5 EditTableCellsOperation(int P_0)
	{
		_G_c__DisplayClass46_0 CS_8_locals_6 = new _G_c__DisplayClass46_0();
		CS_8_locals_6.TableIndex = P_0;
		return GetCurrentWordContext("inspect_word_table_format", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass46_1 CS_8_locals_30 = new _G_c__DisplayClass46_1();
			Document document = GetActiveDocument(app);
			CS_8_locals_30.TargetTable = GetTableByIndex(app, document, CS_8_locals_6.TableIndex);
			int tableIndex = GetTableIndex(document, CS_8_locals_30.TargetTable);
			return AiHelper_5.CreateSuccess("表前单位", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = CS_8_locals_6.TableIndex,
				altTextTitle = SanitizeToken(SafeExecute(() => CS_8_locals_30.TargetTable.Title)),
				altTextDescription = SanitizeToken(SafeExecute(() => CS_8_locals_30.TargetTable.Descr)),
				page = ComputeIntValue(CS_8_locals_30.TargetTable.Range),
				rangeStart = CS_8_locals_30.TargetTable.Range.Start,
				rangeEnd = CS_8_locals_30.TargetTable.Range.End,
				rows = GetTableRowCount(CS_8_locals_30.TargetTable),
				columns = GetTableColumnCount(CS_8_locals_30.TargetTable),
				preferredWidthType = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.PreferredWidthType, WdPreferredWidthType.wdPreferredWidthAuto)),
				preferredWidth = Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.PreferredWidth, 0f),
				rowAlignment = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.Rows.Alignment, WdRowAlignment.wdAlignRowLeft)),
				allowPageBreaks = Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.AllowPageBreaks, ypQS6RTSiCdpSgKNQtr: false),
				spacing = Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.Spacing, 0f),
				cellPadding = new
				{
					top = Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.TopPadding, 0f),
					bottom = Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.BottomPadding, 0f),
					left = Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.LeftPadding, 0f),
					right = Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.RightPadding, 0f)
				},
				row = new
				{
					height = Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.Rows.Height, 0f),
					heightRule = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.Rows.HeightRule, WdRowHeightRule.wdRowHeightAuto)),
					allowBreakAcrossPages = Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.Rows.AllowBreakAcrossPages, 0),
					firstRowHeadingFormat = Ex5TMxi7X1(() => CS_8_locals_30.TargetTable.Rows[1].HeadingFormat, 0)
				},
				rangeFont = BuildFontInfo(CS_8_locals_30.TargetTable.Range.Font),
				paragraphFormat = pyaTKvLinx(CS_8_locals_30.TargetTable.Range.ParagraphFormat),
				borders = BuildResultObject(CS_8_locals_30.TargetTable),
				sampleCells = BuildResultObject(CS_8_locals_30.TargetTable)
			});
		});
	}

	public AiHelper_5 TableOperation(int P_0)
	{
		_G_c__DisplayClass47_0 CS_8_locals_6 = new _G_c__DisplayClass47_0();
		CS_8_locals_6.ParagraphIndex = P_0;
		return GetCurrentWordContext("inspect_word_paragraph_format", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Document document = GetActiveDocument(app);
			Paragraph paragraph = ((CS_8_locals_6.ParagraphIndex > 0) ? GetParagraphByIndex(document, CS_8_locals_6.ParagraphIndex) : GetFirstParagraph(app, document));
			int? paragraphIndex = ((CS_8_locals_6.ParagraphIndex > 0) ? new int?(CS_8_locals_6.ParagraphIndex) : FindParagraphIndex(document, paragraph.Range.Start));
			int num = GetOutlineLevel(paragraph);
			return AiHelper_5.CreateSuccess("表后注释", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				paragraphIndex = paragraphIndex,
				requestedParagraphIndex = CS_8_locals_6.ParagraphIndex,
				page = ComputeIntValue(paragraph.Range),
				rangeStart = paragraph.Range.Start,
				rangeEnd = paragraph.Range.End,
				isInTable = IsRangeInTable(paragraph.Range),
				outlineLevel = ClampOutlineLevel(num),
				comOutlineLevelRaw = num,
				styleName = GetParagraphStyleName(paragraph),
				excerpt = TruncateText(NormalizeText(paragraph.Range.Text), 240),
				font = BuildFontInfo(paragraph.Range.Font),
				paragraphFormat = pyaTKvLinx(paragraph.Range.ParagraphFormat)
			});
		});
	}

	public AiHelper_5 FormatParagraphsOperation(int P_0, int P_1, string P_2)
	{
		_G_c__DisplayClass48_0 CS_8_locals_12 = new _G_c__DisplayClass48_0();
		CS_8_locals_12.hGNxuJMRRe = P_2;
		CS_8_locals_12.ParagraphIndex = P_0;
		CS_8_locals_12.ParagraphIndex = P_1;
		return GetCurrentWordContext("preview_word_paragraph_format_change", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			ParagraphFormatConfig tqHECLHh7ExNw6c0RJi;
			AiHelper_5 insertResult = KESDFbjWCy(CS_8_locals_12.hGNxuJMRRe, out tqHECLHh7ExNw6c0RJi);
			if (insertResult != null)
			{
				return insertResult;
			}
			Document document = GetActiveDocument(app);
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ReadParagraphRange(document, CS_8_locals_12.ParagraphIndex, CS_8_locals_12.ParagraphIndex);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			List<AiHelper_1> list = CollectParagraphs(app, document, CS_8_locals_12.ParagraphIndex, CS_8_locals_12.ParagraphIndex);
			return (list.Count == 0) ? AiHelper_5.CreateError("表后段落", "Word paragraph adjustment config read.", new
			{
				startParagraphIndex = CS_8_locals_12.ParagraphIndex,
				endParagraphIndex = CS_8_locals_12.ParagraphIndex
			}) : AiHelper_5.CreateSuccess("paragraph", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				startParagraphIndex = CS_8_locals_12.ParagraphIndex,
				endParagraphIndex = CS_8_locals_12.ParagraphIndex,
				expectedChangeCount = list.Count,
				supportedFields = ParagraphFormatConfig.CsBHPhLn0y,
				requestedChanges = tqHECLHh7ExNw6c0RJi.WK3Hqw863W(),
				paragraphs = list.Select((AiHelper_1 item) => BuildParagraphChangeInfo(item)).ToList()
			});
		});
	}

	public AiHelper_5 FormatParagraphsOperation(int P_0, int P_1, string P_2, int P_3)
	{
		_G_c__DisplayClass49_0 CS_8_locals_23 = new _G_c__DisplayClass49_0();
		CS_8_locals_23.ExpectedCount = P_3;
		CS_8_locals_23.ConfigJson = P_2;
		CS_8_locals_23.sexxiKXvvR = P_0;
		CS_8_locals_23.ParagraphIndex = P_1;
		return GetCurrentWordContext("apply_word_paragraph_format_change", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass49_1 CS_8_locals_30 = new _G_c__DisplayClass49_1();
			if (CS_8_locals_23.ExpectedCount < 0)
			{
				return AiHelper_5.CreateError("段落配置_方案名", "段落配置_当前方案");
			}
			AiHelper_5 insertResult = KESDFbjWCy(CS_8_locals_23.ConfigJson, out CS_8_locals_30.JdkxrYYqxL);
			if (insertResult != null)
			{
				return insertResult;
			}
			Document document = GetActiveDocument(app);
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ReadParagraphRange(document, CS_8_locals_23.sexxiKXvvR, CS_8_locals_23.ParagraphIndex);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			CS_8_locals_30.ParagraphList = CollectParagraphs(app, document, CS_8_locals_23.sexxiKXvvR, CS_8_locals_23.ParagraphIndex);
			if (CS_8_locals_30.ParagraphList.Count != CS_8_locals_23.ExpectedCount)
			{
				return AiHelper_5.CreateError("段落_", "read_word_paragraph_adjustment_config failed", new
				{
					expectedChangeCount = CS_8_locals_23.ExpectedCount,
					currentChangeCount = CS_8_locals_30.ParagraphList.Count
				});
			}
			CS_8_locals_30.ResultList = new List<object>();
			CS_8_locals_30.ChangedCount = 0;
			AiHelper_5 rU18qH9owXvBsPZ0iiU4 = ValidateRange(app, document, CS_8_locals_30.ParagraphList[0].Paragraph.Range);
			if (rU18qH9owXvBsPZ0iiU4 != null)
			{
				return rU18qH9owXvBsPZ0iiU4;
			}
			DyITDXSmDr(app, "config_error", delegate
			{
				foreach (AiHelper_1 item in CS_8_locals_30.ParagraphList)
				{
					object before = BuildParagraphRangeInfo(item.Paragraph);
					ApplyParagraphFormat(item.Paragraph.Range, CS_8_locals_30.JdkxrYYqxL);
					object after = BuildParagraphRangeInfo(item.Paragraph);
					CS_8_locals_30.ChangedCount++;
					CS_8_locals_30.ResultList.Add(new
					{
						paragraphIndex = item.ParagraphIndex,
						rangeStart = item.Paragraph.Range.Start,
						rangeEnd = item.Paragraph.Range.End,
						page = ComputeIntValue(item.Paragraph.Range),
						excerpt = TruncateText(NormalizeText(item.Paragraph.Range.Text), 160),
						before = before,
						after = after,
						changed = true
					});
				}
			});
			return AiHelper_5.CreateSuccess("inspect_word_table_format", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				startParagraphIndex = CS_8_locals_23.sexxiKXvvR,
				endParagraphIndex = CS_8_locals_23.ParagraphIndex,
				expectedChangeCount = CS_8_locals_23.ExpectedCount,
				changed = CS_8_locals_30.ChangedCount,
				requestedChanges = CS_8_locals_30.JdkxrYYqxL.WK3Hqw863W(),
				paragraphs = CS_8_locals_30.ResultList
			});
		});
	}

	public AiHelper_5 PreviewTableOperation(int P_0, string P_1, string P_2)
	{
		_G_c__DisplayClass50_0 CS_8_locals_7 = new _G_c__DisplayClass50_0();
		CS_8_locals_7.noTxKIkNHF = P_2;
		CS_8_locals_7.TableIndex = P_0;
		CS_8_locals_7.CellSelector = P_1;
		return GetCurrentWordContext("preview_word_table_format_change", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			Helper_9 xqsyBVQI7dsGuEiUT3v;
			AiHelper_5 insertResult = ParseTableConfig(CS_8_locals_7.noTxKIkNHF, out xqsyBVQI7dsGuEiUT3v);
			if (insertResult != null)
			{
				return insertResult;
			}
			Document document = GetActiveDocument(app);
			Table table = GetTableByIndex(app, document, CS_8_locals_7.TableIndex);
			int tableIndex = GetTableIndex(document, table);
			Range range;
			string target;
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ResolveTableCell(document, table, CS_8_locals_7.CellSelector, out range, out target);
			return (rU18qH9owXvBsPZ0iiU3 != null) ? rU18qH9owXvBsPZ0iiU3 : AiHelper_5.CreateSuccess("inspect_word_paragraph_format", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = CS_8_locals_7.TableIndex,
				target = target,
				expectedChangeCount = 1,
				supportedFields = Helper_9.TcvQQSKPF8,
				requestedChanges = xqsyBVQI7dsGuEiUT3v.hhNQHAECG8(),
				before = BuildRangeSnapshot(table, range)
			});
		});
	}

	public AiHelper_5 PreviewTableOperation(int P_0, string P_1, string P_2, int P_3)
	{
		_G_c__DisplayClass51_0 CS_8_locals_23 = new _G_c__DisplayClass51_0();
		CS_8_locals_23.ExpectedCount = P_3;
		CS_8_locals_23.ConfigJson = P_2;
		CS_8_locals_23.TableIndex = P_0;
		CS_8_locals_23.CellSelector = P_1;
		return GetCurrentWordContext("apply_word_table_format_change", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			_G_c__DisplayClass51_1 CS_8_locals_27 = new _G_c__DisplayClass51_1();
			if (CS_8_locals_23.ExpectedCount < 0)
			{
				return AiHelper_5.CreateError("preview_word_paragraph_format_change", "apply_word_paragraph_format_change");
			}
			if (CS_8_locals_23.ExpectedCount != 1)
			{
				return AiHelper_5.CreateError("preview_word_table_format_change", "apply_word_table_format_change", new
				{
					expectedChangeCount = CS_8_locals_23.ExpectedCount,
					currentChangeCount = 1
				});
			}
			AiHelper_5 insertResult = ParseTableConfig(CS_8_locals_23.ConfigJson, out CS_8_locals_27.vsUxwGPQsX);
			if (insertResult != null)
			{
				return insertResult;
			}
			Document document = GetActiveDocument(app);
			CS_8_locals_27.TargetTable = GetTableByIndex(app, document, CS_8_locals_23.TableIndex);
			int tableIndex = GetTableIndex(document, CS_8_locals_27.TargetTable);
			string target;
			AiHelper_5 rU18qH9owXvBsPZ0iiU3 = ResolveTableCell(document, CS_8_locals_27.TargetTable, CS_8_locals_23.CellSelector, out CS_8_locals_27.ComputedRange, out target);
			if (rU18qH9owXvBsPZ0iiU3 != null)
			{
				return rU18qH9owXvBsPZ0iiU3;
			}
			object before = BuildRangeSnapshot(CS_8_locals_27.TargetTable, CS_8_locals_27.ComputedRange);
			AiHelper_5 rU18qH9owXvBsPZ0iiU4 = ValidateRange(app, document, CS_8_locals_27.ComputedRange);
			if (rU18qH9owXvBsPZ0iiU4 != null)
			{
				return rU18qH9owXvBsPZ0iiU4;
			}
			DyITDXSmDr(app, "startParagraphIndex 和 endParagraphIndex 不能为负数。", delegate
			{
				ApplyTableChanges(CS_8_locals_27.TargetTable, CS_8_locals_27.ComputedRange, CS_8_locals_27.vsUxwGPQsX);
			});
			object after = BuildRangeSnapshot(CS_8_locals_27.TargetTable, CS_8_locals_27.ComputedRange);
			return AiHelper_5.CreateSuccess("invalid_arguments", new
			{
				document = document.Name,
				documentFullName = document.FullName,
				tableIndex = tableIndex,
				requestedTableIndex = CS_8_locals_23.TableIndex,
				target = target,
				expectedChangeCount = CS_8_locals_23.ExpectedCount,
				changed = 1,
				requestedChanges = CS_8_locals_27.vsUxwGPQsX.hhNQHAECG8(),
				before = before,
				after = after
			});
		});
	}

	private static AiHelper_5 ReadParagraphRange(Document P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass52_0 CS_8_locals_2 = new _G_c__DisplayClass52_0();
		CS_8_locals_2.doc = P_0;
		if (P_1 < 0 || P_2 < 0)
		{
			return AiHelper_5.CreateError("startParagraphIndex 和 endParagraphIndex 不能为负数。", "invalid_arguments", new
			{
				startParagraphIndex = P_1,
				endParagraphIndex = P_2
			});
		}
		if (P_1 == 0 && P_2 > 0)
		{
			return AiHelper_5.CreateError("startParagraphIndex=0 表示当前选区，此时 endParagraphIndex 必须为 0。", "invalid_arguments", new
			{
				startParagraphIndex = P_1,
				endParagraphIndex = P_2
			});
		}
		if (P_1 > 0 && P_2 > 0 && P_2 < P_1)
		{
			return AiHelper_5.CreateError("endParagraphIndex must be greater than or equal to startParagraphIndex.", "invalid_arguments", new
			{
				startParagraphIndex = P_1,
				endParagraphIndex = P_2
			});
		}
		int num = ComputeIntValue(() => CS_8_locals_2.doc.Paragraphs.Count);
		if (P_1 > num)
		{
			return AiHelper_5.CreateError("startParagraphIndex is out of range.", "invalid_arguments", new
			{
				startParagraphIndex = P_1,
				totalParagraphs = num
			});
		}
		if (P_2 > num)
		{
			return AiHelper_5.CreateError("endParagraphIndex is out of range.", "invalid_arguments", new
			{
				endParagraphIndex = P_2,
				totalParagraphs = num
			});
		}
		return null;
	}

	private static object BuildParagraphChangeInfo(AiHelper_1 P_0)
	{
		return new
		{
			paragraphIndex = P_0.ParagraphIndex,
			rangeStart = P_0.Paragraph.Range.Start,
			rangeEnd = P_0.Paragraph.Range.End,
			page = ComputeIntValue(P_0.Paragraph.Range),
			outlineLevel = ClampOutlineLevel(GetOutlineLevel(P_0.Paragraph)),
			styleName = GetParagraphStyleName(P_0.Paragraph),
			excerpt = TruncateText(NormalizeText(P_0.Paragraph.Range.Text), 160),
			current = BuildParagraphRangeInfo(P_0.Paragraph)
		};
	}

	private static object BuildParagraphRangeInfo(Paragraph P_0)
	{
		return new
		{
			outlineLevel = ClampOutlineLevel(GetOutlineLevel(P_0)),
			styleName = GetParagraphStyleName(P_0),
			font = BuildFontInfo(P_0.Range.Font),
			paragraphFormat = pyaTKvLinx(P_0.Range.ParagraphFormat)
		};
	}

	private static object BuildRangeSnapshot(Table P_0, Range P_1)
	{
		_G_c__DisplayClass55_0 CS_8_locals_13 = new _G_c__DisplayClass55_0();
		CS_8_locals_13.TableForProperties = P_0;
		return new
		{
			rangeStart = P_1.Start,
			rangeEnd = P_1.End,
			page = ComputeIntValue(P_1),
			rows = GetTableRowCount(CS_8_locals_13.TableForProperties),
			columns = GetTableColumnCount(CS_8_locals_13.TableForProperties),
			preferredWidthType = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_13.TableForProperties.PreferredWidthType, WdPreferredWidthType.wdPreferredWidthAuto)),
			preferredWidth = Ex5TMxi7X1(() => CS_8_locals_13.TableForProperties.PreferredWidth, 0f),
			rowAlignment = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_13.TableForProperties.Rows.Alignment, WdRowAlignment.wdAlignRowLeft)),
			cellPadding = new
			{
				top = Ex5TMxi7X1(() => CS_8_locals_13.TableForProperties.TopPadding, 0f),
				bottom = Ex5TMxi7X1(() => CS_8_locals_13.TableForProperties.BottomPadding, 0f),
				left = Ex5TMxi7X1(() => CS_8_locals_13.TableForProperties.LeftPadding, 0f),
				right = Ex5TMxi7X1(() => CS_8_locals_13.TableForProperties.RightPadding, 0f)
			},
			row = new
			{
				height = Ex5TMxi7X1(() => CS_8_locals_13.TableForProperties.Rows.Height, 0f),
				heightRule = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_13.TableForProperties.Rows.HeightRule, WdRowHeightRule.wdRowHeightAuto))
			},
			targetFont = BuildFontInfo(P_1.Font),
			targetParagraphFormat = pyaTKvLinx(P_1.ParagraphFormat),
			borders = BuildResultObject(CS_8_locals_13.TableForProperties)
		};
	}

	private static AiHelper_5 ResolveTableCell(Document P_0, Table P_1, string P_2, out Range P_3, out string P_4)
	{
		P_3 = null;
		P_4 = (P_2 ?? "wholeTable").Trim();
		string text = P_4.ToLowerInvariant();
		int num = GetTableRowCount(P_1);
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
					return AiHelper_5.CreateError("该表格没有可设置的表头行。", "table_target_unavailable", new
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
					return AiHelper_5.CreateError("该表格没有正文数据行。", "table_target_unavailable", new
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
			return AiHelper_5.CreateError("无法解析表格格式目标区域，可能受合并单元格或表格结构影响。", "table_target_unavailable", new
			{
				target = P_2,
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		return AiHelper_5.CreateError("target 仅支持 wholeTable、headerRow、bodyRows。", "invalid_arguments", new
		{
			target = P_2
		});
	}

	private static void ApplyParagraphFormat(Range P_0, ParagraphFormatConfig P_1)
	{
		ExecuteAction(P_0, P_1.FontName, P_1.EastAsianFontName, P_1.FontSize, P_1.Bold, P_1.Italic);
		fQfDekhQUN(P_0.ParagraphFormat, P_1);
	}

	private static void ApplyTableChanges(Table P_0, Range P_1, Helper_9 P_2)
	{
		ExecuteAction(P_1, P_2.FontName, P_2.EastAsianFontName, P_2.FontSize, P_2.Bold, P_2.Italic);
		if (P_2.Alignment != null)
		{
			P_1.ParagraphFormat.Alignment = ParseAlignment(P_2.Alignment);
		}
		if (P_2.VerticalAlignment != null)
		{
			DldDyvVadI(P_0, P_1, ParseVerticalAlignment(P_2.VerticalAlignment));
		}
		if (P_2.RowAlignment != null)
		{
			P_0.Rows.Alignment = ParseRowAlignment(P_2.RowAlignment);
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
			P_0.Rows.HeightRule = ParseRowHeightRule(P_2.RowHeightRule);
		}
		if (P_2.BorderStyle != null)
		{
			ApplyTableBorder(P_0, P_2.BorderStyle, P_2.BorderWidth);
		}
		if (P_2.HeaderRowBold.HasValue && GetTableRowCount(P_0) >= 1)
		{
			P_0.Rows[1].Range.Font.Bold = (P_2.HeaderRowBold.Value ? (-1) : 0);
		}
		if (P_2.HeaderRowShading.HasValue && GetTableRowCount(P_0) >= 1)
		{
			P_0.Rows[1].Range.Shading.BackgroundPatternColor = (WdColor)P_2.HeaderRowShading.Value;
		}
	}

	private static void ExecuteAction(Range P_0, string P_1, string P_2, float? P_3, bool? P_4, bool? P_5)
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

	private static void fQfDekhQUN(ParagraphFormat P_0, ParagraphFormatConfig P_1)
	{
		if (P_1.Alignment != null)
		{
			P_0.Alignment = ParseAlignment(P_1.Alignment);
		}
		if (P_1.LeftIndentCm.HasValue)
		{
			P_0.LeftIndent = CmToPoints(P_1.LeftIndentCm.Value);
		}
		if (P_1.RightIndentCm.HasValue)
		{
			P_0.RightIndent = CmToPoints(P_1.RightIndentCm.Value);
		}
		if (P_1.FirstLineIndentCm.HasValue)
		{
			P_0.FirstLineIndent = CmToPoints(P_1.FirstLineIndentCm.Value);
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
			P_0.LineSpacingRule = ParseLineSpacing(P_1.LineSpacingRule);
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
		CS_8_locals_3.TargetRange = P_1;
		int num = ComputeIntValue(() => CS_8_locals_3.TargetRange.Cells.Count);
		for (int num2 = 1; num2 <= num; num2++)
		{
			try
			{
				CS_8_locals_3.TargetRange.Cells[num2].VerticalAlignment = P_2;
			}
			catch
			{
			}
		}
	}

	private static void ApplyTableBorder(Table P_0, string P_1, float? P_2)
	{
		WdLineStyle wdLineStyle = ParseLineStyle(P_1);
		WdLineWidth lineWidth = ParseLineWidth(P_2);
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

	private static AiHelper_5 KESDFbjWCy(string P_0, out ParagraphFormatConfig P_1)
	{
		P_1 = null;
		JObject jObject;
		AiHelper_5 insertResult = ParseFormatConfig(P_0, ParagraphFormatConfig.CsBHPhLn0y, out jObject);
		if (insertResult != null)
		{
			return insertResult;
		}
		try
		{
			P_1 = new ParagraphFormatConfig
			{
				FontName = GetAlignment(jObject, "fontName"),
				EastAsianFontName = GetAlignment(jObject, "eastAsianFontName", "chineseFontName"),
				FontSize = GetJsonFloat(jObject, "fontSize"),
				Bold = GetJsonBool(jObject, "bold"),
				Italic = GetJsonBool(jObject, "italic"),
				Alignment = GetAlignment(jObject, "alignment"),
				LeftIndentCm = GetJsonFloat(jObject, "leftIndentCm"),
				RightIndentCm = GetJsonFloat(jObject, "rightIndentCm"),
				FirstLineIndentCm = GetJsonFloat(jObject, "firstLineIndentCm"),
				FirstLineIndentChars = GetJsonFloat(jObject, "firstLineIndentChars"),
				SpaceBeforePt = GetJsonFloat(jObject, "spaceBeforePt"),
				SpaceAfterPt = GetJsonFloat(jObject, "spaceAfterPt"),
				LineSpacingRule = GetAlignment(jObject, "lineSpacingRule"),
				LineSpacingPt = GetJsonFloat(jObject, "lineSpacingPt"),
				LineSpacingMultiple = GetJsonFloat(jObject, "lineSpacingMultiple"),
				KeepWithNext = GetJsonBool(jObject, "keepWithNext"),
				KeepTogether = GetJsonBool(jObject, "keepTogether"),
				PageBreakBefore = GetJsonBool(jObject, "pageBreakBefore")
			};
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateError("formatJson 字段类型不正确。", "invalid_arguments", new
			{
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		return ValidateFormatConfig(P_1);
	}

	private static AiHelper_5 ParseTableConfig(string P_0, out Helper_9 P_1)
	{
		P_1 = null;
		JObject jObject;
		AiHelper_5 insertResult = ParseFormatConfig(P_0, Helper_9.TcvQQSKPF8, out jObject);
		if (insertResult != null)
		{
			return insertResult;
		}
		try
		{
			P_1 = new Helper_9
			{
				FontName = GetAlignment(jObject, "fontName"),
				EastAsianFontName = GetAlignment(jObject, "eastAsianFontName", "chineseFontName"),
				FontSize = GetJsonFloat(jObject, "fontSize"),
				Bold = GetJsonBool(jObject, "bold"),
				Italic = GetJsonBool(jObject, "italic"),
				Alignment = GetAlignment(jObject, "alignment"),
				RowAlignment = GetAlignment(jObject, "rowAlignment"),
				VerticalAlignment = GetAlignment(jObject, "verticalAlignment"),
				AutoFit = GetAlignment(jObject, "autoFit"),
				PreferredWidthPercent = GetJsonFloat(jObject, "preferredWidthPercent"),
				CellPaddingPt = GetJsonFloat(jObject, "cellPaddingPt"),
				RowHeightPt = GetJsonFloat(jObject, "rowHeightPt"),
				RowHeightRule = GetAlignment(jObject, "rowHeightRule"),
				BorderStyle = GetAlignment(jObject, "borderStyle"),
				BorderWidth = GetJsonFloat(jObject, "borderWidthPt"),
				HeaderRowBold = GetJsonBool(jObject, "headerRowBold"),
				HeaderRowShading = GetJsonInt(jObject, "headerRowShading")
			};
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateError("formatJson 字段类型不正确。", "invalid_arguments", new
			{
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		return gqaDPUNTXq(P_1);
	}

	private static AiHelper_5 ParseFormatConfig(string P_0, HashSet<string> P_1, out JObject P_2)
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
			return AiHelper_5.CreateError("formatJson 不是有效的 JSON 对象。", "invalid_arguments", new
			{
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		foreach (JProperty item in P_2.Properties())
		{
			if (!P_1.Contains(item.Name))
			{
				return AiHelper_5.CreateError("formatJson 包含不支持的字段。", "invalid_arguments", new
				{
					field = item.Name,
					supportedFields = P_1.OrderBy((string x) => x, StringComparer.OrdinalIgnoreCase).ToArray()
				});
			}
		}
		if (!P_2.Properties().Any())
		{
			return AiHelper_5.CreateError("formatJson 至少需要包含一个格式字段。", "invalid_arguments", new
			{
				supportedFields = P_1.OrderBy((string x) => x, StringComparer.OrdinalIgnoreCase).ToArray()
			});
		}
		return null;
	}

	private static AiHelper_5 ValidateFormatConfig(ParagraphFormatConfig P_0)
	{
		if (P_0.FontSize.HasValue && (P_0.FontSize.Value < 1f || P_0.FontSize.Value > 100f))
		{
			return AiHelper_5.CreateError("fontSize 必须在 1..100 之间。", "invalid_arguments", new { P_0.FontSize });
		}
		try
		{
			if (P_0.Alignment != null)
			{
				ParseAlignment(P_0.Alignment);
			}
			if (P_0.LineSpacingRule != null)
			{
				ParseLineSpacing(P_0.LineSpacingRule);
			}
		}
		catch (ArgumentException ex)
		{
			return AiHelper_5.CreateError(ex.Message, "invalid_arguments");
		}
		return null;
	}

	private static AiHelper_5 gqaDPUNTXq(Helper_9 P_0)
	{
		if (P_0.FontSize.HasValue && (P_0.FontSize.Value < 1f || P_0.FontSize.Value > 100f))
		{
			return AiHelper_5.CreateError("fontSize 必须在 1..100 之间。", "invalid_arguments", new { P_0.FontSize });
		}
		if (P_0.PreferredWidthPercent.HasValue && (P_0.PreferredWidthPercent.Value <= 0f || P_0.PreferredWidthPercent.Value > 100f))
		{
			return AiHelper_5.CreateError("preferredWidthPercent 必须在 0..100 之间。", "invalid_arguments", new { P_0.PreferredWidthPercent });
		}
		try
		{
			if (P_0.Alignment != null)
			{
				ParseAlignment(P_0.Alignment);
			}
			if (P_0.RowAlignment != null)
			{
				ParseRowAlignment(P_0.RowAlignment);
			}
			if (P_0.VerticalAlignment != null)
			{
				ParseVerticalAlignment(P_0.VerticalAlignment);
			}
			if (P_0.AutoFit != null)
			{
				zumTVgQhWS(P_0.AutoFit);
			}
			if (P_0.RowHeightRule != null)
			{
				ParseRowHeightRule(P_0.RowHeightRule);
			}
			if (P_0.BorderStyle != null)
			{
				ParseLineStyle(P_0.BorderStyle);
			}
		}
		catch (ArgumentException ex)
		{
			return AiHelper_5.CreateError(ex.Message, "invalid_arguments");
		}
		return null;
	}

	private static string GetAlignment(JObject P_0, params string[] names)
	{
		foreach (string text in names)
		{
			if (CheckCondition(P_0, text, out var jToken) && jToken.Type != JTokenType.Null)
			{
				return jToken.ToString().Trim();
			}
		}
		return null;
	}

	private static float? GetJsonFloat(JObject P_0, string P_1)
	{
		if (!CheckCondition(P_0, P_1, out var jToken) || jToken.Type == JTokenType.Null)
		{
			return null;
		}
		return jToken.Value<float>();
	}

	private static bool? GetJsonBool(JObject P_0, string P_1)
	{
		if (!CheckCondition(P_0, P_1, out var jToken) || jToken.Type == JTokenType.Null)
		{
			return null;
		}
		return jToken.Value<bool>();
	}

	private static int? GetJsonInt(JObject P_0, string P_1)
	{
		string text = GetAlignment(P_0, P_1);
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

	private static bool CheckCondition(JObject P_0, string P_1, out JToken P_2)
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

	private static WdParagraphAlignment ParseAlignment(string P_0)
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

	private static WdRowAlignment ParseRowAlignment(string P_0)
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

	private static WdCellVerticalAlignment ParseVerticalAlignment(string P_0)
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

	private static WdLineSpacing ParseLineSpacing(string P_0)
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

	private static WdRowHeightRule ParseRowHeightRule(string P_0)
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

	private static WdLineStyle ParseLineStyle(string P_0)
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

	private static WdLineWidth ParseLineWidth(float? P_0)
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

	private static float CmToPoints(float P_0)
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

	private static Dictionary<string, string> ExtractConfigEntries(Dictionary<string, object> P_0, string P_1)
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

	private static string GetConfigValue(Dictionary<string, object> P_0, string P_1, string P_2 = "")
	{
		if (P_0 != null && P_0.TryGetValue(P_1, out var value) && value != null)
		{
			return value.ToString();
		}
		return P_2;
	}

	private static object BuildBorderConfig(Dictionary<string, object> P_0)
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
			string text2 = GetConfigValue(P_0, "表格_边框样式_" + text, null);
			string text3 = GetConfigValue(P_0, "表格_边框粗细_" + text, null);
			if (string.Equals(text, "合计行下边框线", StringComparison.Ordinal))
			{
				if (string.IsNullOrEmpty(text2))
				{
					text2 = GetConfigValue(P_0, "表格_边框样式_表尾底边框线", null);
				}
				if (string.IsNullOrEmpty(text3))
				{
					text3 = GetConfigValue(P_0, "表格_边框粗细_表尾底边框线", null);
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

	private static object BuildAlignmentConfig(Dictionary<string, object> P_0)
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
				horizontal = GetConfigValue(P_0, "表格_段落格式_" + text + "水平对齐", (text == "数字") ? "1" : "2"),
				vertical = GetConfigValue(P_0, "表格_段落格式_" + text + "垂直对齐", "1")
			};
		}
		dictionary["序号列居中"] = GetConfigValue(P_0, "表格_段落格式_序号列居中", "0");
		dictionary["首行首列冲突优先级"] = GetConfigValue(P_0, "表格_段落格式_首行首列冲突优先级", "首行");
		return dictionary;
	}

	private static string NormalizeKey(string P_0)
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

	private static object GetDictValue(Dictionary<string, object> P_0, string P_1)
	{
		string text = "段落_" + P_1 + "_";
		return new
		{
			level = P_1,
			font = new
			{
				chineseFont = GetConfigValue(P_0, text + "中文字体", "宋体"),
				westernFont = GetConfigValue(P_0, text + "西文字体", (P_1 == "一级") ? "宋体" : "Times New Roman"),
				size = GetConfigValue(P_0, text + "字号", "10.5"),
				bold = GetConfigValue(P_0, text + "加粗", "0")
			},
			paragraph = new
			{
				alignment = GetConfigValue(P_0, text + "对齐方式", (P_1 == "表后注释" || P_1 == "表后段落") ? "0" : "3"),
				lineSpacingRule = GetConfigValue(P_0, text + "行距样式", (P_1 == "表后注释") ? "4" : "0"),
				lineSpacing = GetConfigValue(P_0, text + "行距值", "18"),
				spacingUnit = GetConfigValue(P_0, text + "段前距单位", (P_1 == "表后段落") ? "行" : "磅"),
				spaceBefore = GetConfigValue(P_0, text + "段前距", "0"),
				spaceAfter = GetConfigValue(P_0, text + "段后距", (P_1 == "表后段落") ? "0" : "2.5")
			},
			indent = new
			{
				unit = GetConfigValue(P_0, text + "缩进单位", (P_1 == "表后段落") ? "字符" : "厘米"),
				left = GetConfigValue(P_0, text + "左缩进", "0"),
				right = GetConfigValue(P_0, text + "右缩进", "0"),
				special = GetConfigValue(P_0, text + "特殊缩进", (P_1 == "表后注释") ? "首行" : "无"),
				value = GetConfigValue(P_0, text + "缩进值", (P_1 == "表后注释" || P_1 == "表后段落") ? "2" : "0")
			},
			raw = ExtractConfigEntries(P_0, text)
		};
	}

	private static Table GetTableByIndex(Microsoft.Office.Interop.Word.Application P_0, Document P_1, int P_2)
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

	private static Paragraph GetFirstParagraph(Microsoft.Office.Interop.Word.Application P_0, Document P_1)
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

	private static int GetTableIndex(Document P_0, Table P_1)
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

	private static object BuildFontInfo(Font P_0)
	{
		_G_c__DisplayClass93_0 CS_8_locals_8 = new _G_c__DisplayClass93_0();
		CS_8_locals_8.TargetFont = P_0;
		return new
		{
			nameFarEast = SafeExecute(() => CS_8_locals_8.TargetFont.NameFarEast),
			nameAscii = SafeExecute(() => CS_8_locals_8.TargetFont.NameAscii),
			nameOther = SafeExecute(() => CS_8_locals_8.TargetFont.NameOther),
			size = Ex5TMxi7X1(() => CS_8_locals_8.TargetFont.Size, 0f),
			bold = Ex5TMxi7X1(() => CS_8_locals_8.TargetFont.Bold, 0),
			italic = Ex5TMxi7X1(() => CS_8_locals_8.TargetFont.Italic, 0),
			underline = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_8.TargetFont.Underline, WdUnderline.wdUnderlineNone))
		};
	}

	private static object pyaTKvLinx(ParagraphFormat P_0)
	{
		_G_c__DisplayClass94_0 CS_8_locals_14 = new _G_c__DisplayClass94_0();
		CS_8_locals_14.TargetParagraphFormat = P_0;
		return new
		{
			alignment = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.Alignment, WdParagraphAlignment.wdAlignParagraphLeft)),
			lineSpacingRule = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.LineSpacingRule, WdLineSpacing.wdLineSpaceSingle)),
			lineSpacing = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.LineSpacing, 0f),
			spaceBefore = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.SpaceBefore, 0f),
			spaceAfter = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.SpaceAfter, 0f),
			lineUnitBefore = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.LineUnitBefore, 0f),
			lineUnitAfter = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.LineUnitAfter, 0f),
			leftIndent = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.LeftIndent, 0f),
			rightIndent = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.RightIndent, 0f),
			firstLineIndent = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.FirstLineIndent, 0f),
			characterUnitLeftIndent = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.CharacterUnitLeftIndent, 0f),
			characterUnitRightIndent = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.CharacterUnitRightIndent, 0f),
			characterUnitFirstLineIndent = Ex5TMxi7X1(() => CS_8_locals_14.TargetParagraphFormat.CharacterUnitFirstLineIndent, 0f)
		};
	}

	private static object BuildResultObject(Table P_0)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		CollectBorderInfo(dictionary, P_0, "left", WdBorderType.wdBorderLeft);
		CollectBorderInfo(dictionary, P_0, "right", WdBorderType.wdBorderRight);
		CollectBorderInfo(dictionary, P_0, "top", WdBorderType.wdBorderTop);
		CollectBorderInfo(dictionary, P_0, "bottom", WdBorderType.wdBorderBottom);
		CollectBorderInfo(dictionary, P_0, "horizontal", WdBorderType.wdBorderHorizontal);
		CollectBorderInfo(dictionary, P_0, "vertical", WdBorderType.wdBorderVertical);
		return dictionary;
	}

	private static void CollectBorderInfo(Dictionary<string, object> P_0, Table P_1, string P_2, WdBorderType P_3)
	{
		_G_c__DisplayClass96_0 CS_8_locals_6 = new _G_c__DisplayClass96_0();
		CS_8_locals_6.TableForBorders = P_1;
		CS_8_locals_6.BorderType = P_3;
		P_0[P_2] = new
		{
			lineStyle = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_6.TableForBorders.Borders[CS_8_locals_6.BorderType].LineStyle, WdLineStyle.wdLineStyleNone)),
			lineWidth = NYGTYpKoUO(Ex5TMxi7X1(() => CS_8_locals_6.TableForBorders.Borders[CS_8_locals_6.BorderType].LineWidth, WdLineWidth.wdLineWidth025pt))
		};
	}

	private static object BuildResultObject(Table P_0)
	{
		List<object> list = new List<object>();
		AddCellInfo(list, P_0, "firstCell", 1, 1);
		AddCellInfo(list, P_0, "firstBodyCell", Math.Min(2, GetTableRowCount(P_0)), 1);
		int num = GetTableRowCount(P_0);
		int num2 = GetTableColumnCount(P_0);
		if (num > 0 && num2 > 0)
		{
			AddCellInfo(list, P_0, "lastCell", num, num2);
		}
		return list;
	}

	private static void AddCellInfo(List<object> P_0, Table P_1, string P_2, int P_3, int P_4)
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
				text = TruncateText(NormalizeText(CS_8_locals_5.gAJdIPCcIZ.Range.Text), 120),
				font = BuildFontInfo(CS_8_locals_5.gAJdIPCcIZ.Range.Font),
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

	private AiHelper_5 GetCurrentWordContext(string P_0, Func<Microsoft.Office.Interop.Word.Application, AiHelper_5> P_1)
	{
		_G_c__DisplayClass101_0 CS_8_locals_14 = new _G_c__DisplayClass101_0();
		CS_8_locals_14.OperationName = P_0;
		CS_8_locals_14.ntwPnGtes4 = P_1;
		CS_8_locals_14.Timer = Stopwatch.StartNew();
		try
		{
			return TableToolService.MdXJlVhPku(CS_8_locals_14.OperationName, delegate(Microsoft.Office.Interop.Word.Application app)
			{
				string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
				if (!string.IsNullOrWhiteSpace(text))
				{
					return WordAgentRuntimeGuard2.CreateNotReadyError(text);
				}
				AiConfigBootstrap.LogInfo("[AI Tool][Word] " + CS_8_locals_14.OperationName);
				AiHelper_5 insertResult = CS_8_locals_14.ntwPnGtes4(app);
				CS_8_locals_14.Timer.Stop();
				AiConfigBootstrap.LogInfo(" failed; ElapsedMs=" + CS_8_locals_14.OperationName + " failed" + (insertResult?.success ?? false) + "word_error" + CS_8_locals_14.Timer.ElapsedMilliseconds);
				return insertResult;
			});
		}
		catch (Exception ex)
		{
			if (CS_8_locals_14.Timer.IsRunning)
			{
				CS_8_locals_14.Timer.Stop();
			}
			AiConfigBootstrap.LogError("startParagraphIndex=0 表示当前选区，此时 endParagraphIndex 必须为 0。" + CS_8_locals_14.OperationName + "invalid_arguments" + CS_8_locals_14.Timer.ElapsedMilliseconds, ex);
			return AiHelper_5.CreateExceptionError(CS_8_locals_14.OperationName + "endParagraphIndex must be greater than or equal to startParagraphIndex.", "invalid_arguments", ex);
		}
	}

	private static Document GetActiveDocument(Microsoft.Office.Interop.Word.Application P_0)
	{
		return DocumentLifecycleGuard.GetActiveDocument(P_0);
	}

	private static Range GetRangeByPosition(Document P_0, int P_1, int P_2)
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

	private static Range GetRangeByPosition(Document P_0, int P_1, int P_2)
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

	private static AiHelper_5 JXpTldftkV(Document P_0, int P_1, int P_2, int P_3, out Range P_4)
	{
		P_4 = null;
		if (P_0 == null)
		{
			return AiHelper_5.CreateError("当前没有打开的 Word 文档。", "no_document");
		}
		if (P_1 < 1 || P_1 > P_0.Paragraphs.Count)
		{
			return AiHelper_5.CreateError("paragraphIndex is out of range.", "invalid_arguments", new
			{
				paragraphIndex = P_1,
				totalParagraphs = P_0.Paragraphs.Count,
				coordinateRequirement = "add_word_comment_at_paragraph_range 只接受真实 Word COM 段落坐标。OpenXML/正则筛查返回的 paragraphIndex/charIndexStart/End 不能直接用于此工具。正文批注优先使用 find_word_text 获取 rangeStart/rangeEnd 后调用 add_word_comment_at_range。"
			});
		}
		if (P_2 < 1 || P_3 < P_2)
		{
			return AiHelper_5.CreateError("charIndexStart/charIndexEnd are invalid.", "invalid_arguments", new
			{
				paragraphIndex = P_1,
				charIndexStart = P_2,
				charIndexEnd = P_3,
				coordinateRequirement = "段落和字符坐标必须来自真实 Word COM 坐标。"
			});
		}
		Paragraph paragraph = P_0.Paragraphs[P_1];
		string text = NormalizeText(paragraph.Range.Text);
		int num = Math.Max(1, text.Length);
		if (P_3 > num)
		{
			return AiHelper_5.CreateError("charIndexEnd is out of range for the COM paragraph.", "invalid_arguments", new
			{
				paragraphIndex = P_1,
				charIndexStart = P_2,
				charIndexEnd = P_3,
				paragraphTextLength = num,
				paragraphPreview = TruncateText(text, 240),
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

	private static Range GetRangeByPosition(Document P_0, int P_1, int P_2, int P_3)
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
		string text = NormalizeText(paragraph.Range.Text);
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
		if (P_2 < 1 || P_2 > GetTableRowCount(table))
		{
			throw new ArgumentException("rowIndex is out of range.");
		}
		if (P_3 < 1 || P_3 > GetTableColumnCount(table))
		{
			throw new ArgumentException("columnIndex is out of range.");
		}
		return table.Cell(P_2, P_3);
	}

	private static Paragraph GetParagraphByIndex(Document P_0, int P_1)
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

	private static AiHelper_5 TryGetTableCell(Document P_0, int P_1, int P_2, int P_3, out Cell P_4)
	{
		P_4 = null;
		if (P_0 == null)
		{
			return AiHelper_5.CreateError("当前没有打开的 Word 文档。", "no_document");
		}
		if (P_1 < 1 || P_1 > P_0.Tables.Count)
		{
			return AiHelper_5.CreateError("tableIndex is out of range.", "invalid_arguments", new
			{
				tableIndex = P_1,
				totalTables = P_0.Tables.Count
			});
		}
		Table table = P_0.Tables[P_1];
		int num = GetTableRowCount(table);
		int num2 = GetTableColumnCount(table);
		if (P_2 < 1 || P_2 > num)
		{
			return AiHelper_5.CreateError("rowIndex is out of range.", "invalid_arguments", new
			{
				tableIndex = P_1,
				rowIndex = P_2,
				rows = num
			});
		}
		if (P_3 < 1 || P_3 > num2)
		{
			return AiHelper_5.CreateError("columnIndex is out of range.", "invalid_arguments", new
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
			return AiHelper_5.CreateError("该表格单元格无法通过行列坐标精确定位，可能存在合并单元格。", "table_cell_unavailable", new
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

	private static List<AiHelper_1> CollectParagraphs(Microsoft.Office.Interop.Word.Application P_0, Document P_1, int P_2, int P_3)
	{
		List<AiHelper_1> list = new List<AiHelper_1>();
		if (P_2 == 0)
		{
			_G_c__DisplayClass110_0 CS_8_locals_5 = new _G_c__DisplayClass110_0();
			CS_8_locals_5.CurrentSelection = P_0.Selection;
			if (CS_8_locals_5.CurrentSelection == null || CS_8_locals_5.CurrentSelection.Paragraphs == null)
			{
				return list;
			}
			int num = ComputeIntValue(() => CS_8_locals_5.CurrentSelection.Paragraphs.Count);
			HashSet<int> hashSet = new HashSet<int>();
			for (int num2 = 1; num2 <= num; num2++)
			{
				Paragraph paragraph = CS_8_locals_5.CurrentSelection.Paragraphs[num2];
				int valueOrDefault = FindParagraphIndex(P_1, paragraph.Range.Start).GetValueOrDefault();
				if (valueOrDefault > 0 && IsRangeValid(paragraph.Range) && hashSet.Add(valueOrDefault))
				{
					list.Add(new AiHelper_1(valueOrDefault, paragraph));
				}
			}
			return list;
		}
		int num3 = ((P_3 > 0) ? P_3 : P_2);
		for (int num4 = P_2; num4 <= num3; num4++)
		{
			list.Add(new AiHelper_1(num4, GetParagraphByIndex(P_1, num4)));
		}
		return list;
	}

	private static Range GetCellRange(Cell P_0)
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

	private static AiHelper_5 PPXTOUDVLE(Document P_0, bool P_1, Func<AiHelper_5> P_2, Microsoft.Office.Interop.Word.Application P_3 = null, Range P_4 = null, string P_5 = null)
	{
		_G_c__DisplayClass112_0 CS_8_locals_10 = new _G_c__DisplayClass112_0();
		CS_8_locals_10.doc = P_0;
		CS_8_locals_10.UseTrackChanges = P_1;
		CS_8_locals_10.ActionDelegate = P_2;
		if (P_3 != null && P_4 != null)
		{
			AiHelper_5 insertResult = ValidateRange(P_3, CS_8_locals_10.doc, P_4);
			if (CS_8_locals_10.UseTrackChanges && insertResult != null)
			{
				return insertResult;
			}
		}
		Func<AiHelper_5> func = delegate
		{
			bool trackRevisions = CS_8_locals_10.doc.TrackRevisions;
			try
			{
				CS_8_locals_10.doc.TrackRevisions = CS_8_locals_10.UseTrackChanges;
				return CS_8_locals_10.ActionDelegate();
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

	private static string NormalizeConfigKey(string P_0)
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

	private static AiHelper_5 ExecuteTableEdit(Document P_0, Range P_1, int P_2, int P_3, string P_4, bool P_5, bool P_6, out WordTableToolService3 P_7)
	{
		_G_c__DisplayClass114_0 CS_8_locals_15 = new _G_c__DisplayClass114_0();
		CS_8_locals_15.RangeForTableCount = P_1;
		CS_8_locals_15.doc = P_0;
		P_7 = null;
		if (CS_8_locals_15.doc == null || CS_8_locals_15.RangeForTableCount == null)
		{
			return AiHelper_5.CreateError("引用 Range 不可用。", "invalid_arguments");
		}
		if (ComputeIntValue(() => CS_8_locals_15.RangeForTableCount.Tables.Count) > 0)
		{
			return AiHelper_5.CreateError("目标 Range 位于已有表格中。插入新表请选中正文空段落；已有表内加行请使用 insert_word_table_rows_by_model。", "target_range_inside_table");
		}
		Paragraph paragraph;
		try
		{
			paragraph = CS_8_locals_15.RangeForTableCount.Paragraphs[1];
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateError("目标 Range 未落在可用正文段落中。", "paragraph_unavailable", new
			{
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		if (paragraph == null || paragraph.Range == null)
		{
			return AiHelper_5.CreateError("目标 Range 未落在可用正文段落中。", "paragraph_unavailable");
		}
		CS_8_locals_15.TargetRange = paragraph.Range.Duplicate;
		string text = NormalizeText(SafeExecute(() => CS_8_locals_15.TargetRange.Text));
		bool flag = string.IsNullOrWhiteSpace(text);
		if (string.Equals(P_4, "replace_empty_paragraph", StringComparison.Ordinal) && !flag)
		{
			return AiHelper_5.CreateError("placement=replace_empty_paragraph 只能用于空段落。若要在非空段落前后插表，请传 placement=before 或 after。", "target_paragraph_not_empty", new
			{
				paragraphText = TruncateText(text, 240)
			});
		}
		int num = Ex5TMxi7X1(() => CS_8_locals_15.TargetRange.Start, CS_8_locals_15.RangeForTableCount.Start);
		int num2 = Ex5TMxi7X1(() => CS_8_locals_15.TargetRange.End, CS_8_locals_15.RangeForTableCount.End);
		int insertionStart = num;
		if (string.Equals(P_4, "after", StringComparison.Ordinal))
		{
			insertionStart = num2;
		}
		P_7 = new WordTableToolService3
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
			Page = ComputeIntValue(CS_8_locals_15.TargetRange),
			TableCountBefore = ComputeIntValue(() => CS_8_locals_15.doc.Tables.Count),
			FocusRange = CS_8_locals_15.TargetRange
		};
		return null;
	}

	private static object BuildResultObject(Document P_0, int P_1, int P_2, string P_3, WordTableToolService3 P_4)
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

	private static string BIJTcpAmqJ(Document P_0, int P_1, int P_2, WordTableToolService3 P_3)
	{
		_G_c__DisplayClass116_0 CS_8_locals_2 = new _G_c__DisplayClass116_0();
		CS_8_locals_2.doc = P_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(SafeExecute(() => CS_8_locals_2.doc.FullName)).Append('|').Append(P_1.ToString(CultureInfo.InvariantCulture))
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

	private static bool psHTenZWYL(Document P_0, WordTableToolService3 P_1, out Table P_2, out string P_3)
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
			InitializeRuntime();
			BatchTableAdjustService.HUeflwYrZr();
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

	private static string ParsePosition(string P_0)
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

	private static AiHelper_5 ExecuteOperation(Range P_0, int P_1, int P_2, string P_3, int P_4, bool P_5, string P_6, out WordTableToolService2 P_7)
	{
		_G_c__DisplayClass120_0 CS_8_locals_10 = new _G_c__DisplayClass120_0();
		CS_8_locals_10.RangeForTableCount = P_0;
		P_7 = null;
		if (CS_8_locals_10.RangeForTableCount == null)
		{
			return AiHelper_5.CreateError("引用 Range 不可用。", "invalid_arguments");
		}
		int num = ComputeIntValue(() => CS_8_locals_10.RangeForTableCount.Tables.Count);
		if (P_1 < 1 || P_1 > num)
		{
			return AiHelper_5.CreateError("localTableIndex 超出引用选区内表格数量。", "local_table_index_out_of_range", new
			{
				localTableIndex = P_1,
				tableCount = num
			});
		}
		Table table;
		try
		{
			table = CS_8_locals_10.RangeForTableCount.Tables[P_1];
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateError("无法读取引用选区内的目标表格。", "table_unavailable", new
			{
				localTableIndex = P_1,
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		HbPTWYrAup(table, out var num2, out var columnsBefore);
		if (num2 <= 0)
		{
			return AiHelper_5.CreateError("无法读取目标表格行数。", "table_structure_unavailable", new
			{
				localTableIndex = P_1
			});
		}
		if (P_2 < 1 || P_2 > num2)
		{
			return AiHelper_5.CreateError("anchorRowIndex 超出目标表格行数。", "anchor_row_out_of_range", new
			{
				anchorRowIndex = P_2,
				rows = num2
			});
		}
		if (!CheckCondition(table, P_2, out CS_8_locals_10.AnchorCell))
		{
			return AiHelper_5.CreateError("无法在锚点行中找到可选中的真实 Word 单元格。", "anchor_row_unavailable", new
			{
				localTableIndex = P_1,
				anchorRowIndex = P_2
			});
		}
		string text = GetCellPreviewText(table, P_2, 500);
		string text2 = NormalizeText(P_6);
		if (!string.IsNullOrWhiteSpace(text2) && text.IndexOf(text2, StringComparison.CurrentCultureIgnoreCase) < 0)
		{
			return AiHelper_5.CreateError("锚点行文本与 expectedAnchorText 不一致。请重新读取表格结构后再插行。", "anchor_text_mismatch", new
			{
				localTableIndex = P_1,
				anchorRowIndex = P_2,
				expectedAnchorText = text2,
				anchorRowText = text
			});
		}
		CheckCondition(CS_8_locals_10.AnchorCell, out var _, out var anchorColumnIndex);
		P_7 = new WordTableToolService2
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
			AnchorRangeStart = Ex5TMxi7X1(() => CS_8_locals_10.AnchorCell.Range.Start, 0),
			AnchorRangeEnd = Ex5TMxi7X1(() => CS_8_locals_10.AnchorCell.Range.End, 0),
			Page = ComputeIntValue(CS_8_locals_10.AnchorCell.Range),
			Table = table,
			AnchorCell = CS_8_locals_10.AnchorCell
		};
		return null;
	}

	private static object fYyThhstYU(Document P_0, int P_1, int P_2, string P_3, WordTableToolService2 P_4)
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
			insertedRows = BuildList(P_4),
			anchor = BuildAnchorInfo(P_4)
		};
	}

	private static object BuildAnchorInfo(WordTableToolService2 P_0)
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

	private static List<object> BuildList(WordTableToolService2 P_0)
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

	private static string lKeTPQlpbN(Document P_0, int P_1, int P_2, WordTableToolService2 P_3)
	{
		_G_c__DisplayClass124_0 CS_8_locals_2 = new _G_c__DisplayClass124_0();
		CS_8_locals_2.doc = P_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(SafeExecute(() => CS_8_locals_2.doc.FullName)).Append('|').Append(P_1.ToString(CultureInfo.InvariantCulture))
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
			InitializeRuntime();
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
					_G_o__125.R5GdQcN6Hi = CallSite<object>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "TryInsertRowsAbove", null, typeof(BatchReplaceService3), new CSharpArgumentInfo[4]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsOut, null)
					}));
				}
				return (dynamic)((System.Delegate)(object)_G_o__125.R5GdQcN6Hi.Target).DynamicInvoke(_G_o__125.R5GdQcN6Hi, typeof(BatchReplaceService3), (object)selection, P_3, P_4);
			}
			if (_G_o__125.YnvdrUZ7MP == null)
			{
				_G_o__125.YnvdrUZ7MP = CallSite<object>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "TryInsertRowsBelow", null, typeof(BatchReplaceService3), new CSharpArgumentInfo[4]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsOut, null)
				}));
			}
			return (dynamic)((System.Delegate)(object)_G_o__125.YnvdrUZ7MP.Target).DynamicInvoke(_G_o__125.YnvdrUZ7MP, typeof(BatchReplaceService3), (object)selection, P_3, P_4);
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
				_G_o__126.KfAd3MVCte = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertRowsBelow", null, typeof(BatchReplaceService3), new CSharpArgumentInfo[2]
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
					_G_o__126.Nx0dUcI0Fd = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertRowsBelow", null, typeof(BatchReplaceService3), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
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
				_G_o__127.b9pdKn5QbP = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertRowsAbove", null, typeof(BatchReplaceService3), new CSharpArgumentInfo[2]
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
					_G_o__127.p2TdEhwotK = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "InsertRowsAbove", null, typeof(BatchReplaceService3), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
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

	private static bool CheckCondition(Table P_0, int P_1, out Cell P_2)
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
				if (CheckCondition(cell, out var num, out var item) && num == P_1)
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
		CS_8_locals_5.TargetTable = P_0;
		P_1 = 0;
		P_2 = 0;
		if (CS_8_locals_5.TargetTable == null)
		{
			return;
		}
		try
		{
			foreach (Cell cell in CS_8_locals_5.TargetTable.Range.Cells)
			{
				if (CheckCondition(cell, out var val, out var val2))
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
			P_1 = Ex5TMxi7X1(() => CS_8_locals_5.TargetTable.Rows.Count, 0);
		}
		if (P_2 <= 0)
		{
			P_2 = Ex5TMxi7X1(() => CS_8_locals_5.TargetTable.Columns.Count, 0);
		}
	}

	private static string GetCellPreviewText(Table P_0, int P_1, int P_2)
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
				if (CheckCondition(cell, out var num, out var item) && num == P_1)
				{
					string text = NormalizeText(ProcessString(cell));
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
		return TruncateText(string.Join(" | ", from tuple in list
			orderby tuple.Item1
			select tuple.Item2), Math.Max(80, P_2));
	}

	private static AiHelper_5 XIPTkGpqwW(string P_0, out List<TableCellModel> P_1)
	{
		P_1 = null;
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return AiHelper_5.CreateError("cellsJson must not be empty.", "invalid_arguments");
		}
		try
		{
			P_1 = JsonConvert.DeserializeObject<List<TableCellModel>>(P_0);
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateError("cellsJson 不是有效的 JSON 数组。", "invalid_arguments", new
			{
				exception = ex.GetType().Name,
				message = ex.Message
			});
		}
		if (P_1 == null || P_1.Count == 0)
		{
			return AiHelper_5.CreateError("cellsJson 至少需要包含一个模型单元格填数请求。", "invalid_arguments");
		}
		if (P_1.Count > 500)
		{
			return AiHelper_5.CreateError("单次模型填表最多支持 500 个单元格。", "invalid_arguments", new
			{
				count = P_1.Count,
				max = 500
			});
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			TableCellModel oGfXaqipg6f7TvJ8dbc = P_1[i];
			if (oGfXaqipg6f7TvJ8dbc == null)
			{
				return AiHelper_5.CreateError("cellsJson 包含空请求。", "invalid_arguments", new
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
				return AiHelper_5.CreateError("localTableIndex、rowIndex、columnIndex 必须都是 1-based 正整数。", "invalid_arguments", new
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

	private static AiHelper_5 ExecuteOperation(Range P_0, List<TableCellModel> P_1, out List<AiHelper_21> P_2)
	{
		_G_c__DisplayClass132_0 CS_8_locals_9 = new _G_c__DisplayClass132_0();
		CS_8_locals_9.RangeForTableCount = P_0;
		P_2 = new List<AiHelper_21>();
		if (CS_8_locals_9.RangeForTableCount == null)
		{
			return AiHelper_5.CreateError("引用 Range 不可用。", "invalid_arguments");
		}
		int num = ComputeIntValue(() => CS_8_locals_9.RangeForTableCount.Tables.Count);
		Dictionary<int, Table> dictionary = new Dictionary<int, Table>();
		Dictionary<int, Dictionary<string, Cell>> dictionary2 = new Dictionary<int, Dictionary<string, Cell>>();
		Dictionary<int, int> dictionary3 = new Dictionary<int, int>();
		for (int num2 = 0; num2 < P_1.Count; num2++)
		{
			_G_c__DisplayClass132_1 CS_8_locals_11 = new _G_c__DisplayClass132_1();
			TableCellModel oGfXaqipg6f7TvJ8dbc = P_1[num2];
			AiHelper_21 csQGCih5R8sKlcw64k = new AiHelper_21
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
				SetCellError(csQGCih5R8sKlcw64k, "local_table_index_out_of_range", "localTableIndex 超出引用选区内表格数量。");
				continue;
			}
			if (!dictionary.TryGetValue(oGfXaqipg6f7TvJ8dbc.LocalTableIndex, out var value))
			{
				try
				{
					value = CS_8_locals_9.RangeForTableCount.Tables[oGfXaqipg6f7TvJ8dbc.LocalTableIndex];
					dictionary[oGfXaqipg6f7TvJ8dbc.LocalTableIndex] = value;
				}
				catch (Exception ex)
				{
					SetCellError(csQGCih5R8sKlcw64k, "table_unavailable", ex.Message);
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
				value3 = BuildCellMap(value);
				dictionary2[oGfXaqipg6f7TvJ8dbc.LocalTableIndex] = value3;
			}
			string key = ProcessString(oGfXaqipg6f7TvJ8dbc.RowIndex, oGfXaqipg6f7TvJ8dbc.ColumnIndex);
			if (!value3.TryGetValue(key, out CS_8_locals_11.AnchorCell))
			{
				SetCellError(csQGCih5R8sKlcw64k, "model_cell_unavailable", "目标坐标不是 Word 真实单元格起点，可能是合并区域内部坐标。请使用 read_word_tables_in_range 返回的 origin/fillableCells 坐标。");
				continue;
			}
			csQGCih5R8sKlcw64k.Cell = CS_8_locals_11.AnchorCell;
			csQGCih5R8sKlcw64k.RangeStart = Ex5TMxi7X1(() => CS_8_locals_11.AnchorCell.Range.Start, 0);
			csQGCih5R8sKlcw64k.RangeEnd = Ex5TMxi7X1(() => CS_8_locals_11.AnchorCell.Range.End, 0);
			csQGCih5R8sKlcw64k.Page = ComputeIntValue(CS_8_locals_11.AnchorCell.Range);
			csQGCih5R8sKlcw64k.OldText = NormalizeText(ProcessString(CS_8_locals_11.AnchorCell));
			if (oGfXaqipg6f7TvJ8dbc.ExpectedOldText != null && !string.Equals(NormalizeText(oGfXaqipg6f7TvJ8dbc.ExpectedOldText), csQGCih5R8sKlcw64k.OldText, StringComparison.Ordinal))
			{
				SetCellError(csQGCih5R8sKlcw64k, "old_text_mismatch", "目标单元格当前旧值与 expectedOldText 不一致。请重新读取表格模型后再写入。");
			}
			else
			{
				csQGCih5R8sKlcw64k.Writable = true;
			}
		}
		return null;
	}

	private static object iLJTdpgWxW(Document P_0, int P_1, int P_2, bool P_3, bool P_4, string P_5, List<AiHelper_21> P_6)
	{
		int num = P_6.Count((AiHelper_21 change) => change.Writable);
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

	private static object ogqTzQBuMn(AiHelper_21 P_0)
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

	private static void SetCellError(AiHelper_21 P_0, string P_1, string P_2)
	{
		P_0.Writable = false;
		P_0.ErrorCode = P_1;
		P_0.ErrorMessage = P_2;
	}

	private static Dictionary<string, Cell> BuildCellMap(Table P_0)
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
				if (CheckCondition(cell, out var num, out var num2))
				{
					string key = ProcessString(num, num2);
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

	private static bool CheckCondition(Cell P_0, out int P_1, out int P_2)
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

	private static string BuildPreviewToken(Document P_0, int P_1, int P_2, List<AiHelper_21> P_3)
	{
		_G_c__DisplayClass138_0 CS_8_locals_2 = new _G_c__DisplayClass138_0();
		CS_8_locals_2.doc = P_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(SafeExecute(() => CS_8_locals_2.doc.FullName)).Append('|').Append(P_1.ToString(CultureInfo.InvariantCulture))
			.Append('|')
			.Append(P_2.ToString(CultureInfo.InvariantCulture));
		foreach (AiHelper_21 item in P_3.OrderBy((AiHelper_21 c) => c.RequestIndex))
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

	private static bool ValidatePreviewToken(string P_0, string P_1)
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

	private static string ProcessString(int P_0, int P_1)
	{
		return P_0.ToString(CultureInfo.InvariantCulture) + ":" + P_1.ToString(CultureInfo.InvariantCulture);
	}

	private static string ProcessString(Cell P_0)
	{
		_G_c__DisplayClass141_0 CS_8_locals_3 = new _G_c__DisplayClass141_0();
		CS_8_locals_3.TargetCell = P_0;
		try
		{
			Range duplicate = CS_8_locals_3.TargetCell.Range.Duplicate;
			duplicate.End = Math.Max(duplicate.Start, duplicate.End - 1);
			return duplicate.Text ?? string.Empty;
		}
		catch
		{
			return SafeExecute(() => CS_8_locals_3.TargetCell.Range.Text);
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
			if (string.Equals(NormalizeText(duplicate.Text), NormalizeText(text), StringComparison.Ordinal))
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
		CS_8_locals_2.TableForXml = P_0;
		try
		{
			string text = SafeExecute(() => CS_8_locals_2.TableForXml.Range.WordOpenXML);
			if (string.IsNullOrWhiteSpace(text))
			{
				return 1;
			}
			XDocument xDocument = XDocument.Parse(text);
			XElement xElement = (MRrgIiUJxs(xDocument, "/word/document.xml") ?? xDocument).Descendants(WordmlNamespace + "tbl").FirstOrDefault();
			if (xElement == null)
			{
				return 1;
			}
			int num = 0;
			List<TableCellSpan> list = new List<TableCellSpan>();
			Dictionary<int, TableCellSpan> dictionary = new Dictionary<int, TableCellSpan>();
			foreach (XElement item in xElement.Elements(WordmlNamespace + "tr"))
			{
				num++;
				int num2 = 1;
				HashSet<TableCellSpan> hashSet = new HashSet<TableCellSpan>();
				foreach (XElement item2 in item.Elements(WordmlNamespace + "tc"))
				{
					int num3 = GetXmlElementRowSpan(item2);
					string text2 = GetXmlElementText(item2);
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
						value = new TableCellSpan
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
			List<Helper_4> list2 = (from cell in list
				where cell.RowSpan > 1 || cell.ColumnSpan > 1
				select new Helper_4
				{
					StartRow = cell.RowIndex,
					StartColumn = cell.ColumnIndex,
					EndRow = cell.RowIndex + cell.RowSpan - 1,
					EndColumn = cell.ColumnIndex + cell.ColumnSpan - 1
				}).ToList();
			return ComputeIntValue(num, list2);
		}
		catch
		{
			return 1;
		}
	}

	private static int ComputeIntValue(int P_0, List<Helper_4> P_1)
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
		CS_8_locals_6.MergeCheckRow = 1;
		while (CS_8_locals_6.MergeCheckRow <= P_0 && P_1.Any((Helper_4 merge) => merge.StartRow <= CS_8_locals_6.MergeCheckRow && merge.EndRow >= CS_8_locals_6.MergeCheckRow))
		{
			num = CS_8_locals_6.MergeCheckRow;
			CS_8_locals_6.MergeCheckRow++;
		}
		bool flag;
		do
		{
			flag = false;
			foreach (Helper_4 item in P_1)
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
		_ = P_0.Root.Attribute(WordNamespace + "name")?.Value;
		if (P_0.Root.Name == WordmlNamespace + "document" && string.Equals(CS_8_locals_3.DojAYMESMP, "/word/document.xml", StringComparison.OrdinalIgnoreCase))
		{
			return P_0;
		}
		XElement xElement = P_0.Root.Elements(WordNamespace + "part").FirstOrDefault((XElement p) => string.Equals(p.Attribute(WordNamespace + "xmlData")?.Value, CS_8_locals_3.DojAYMESMP, StringComparison.OrdinalIgnoreCase))?.Element(WordNamespace + "startParagraphIndex is out of range.")?.Elements().FirstOrDefault();
		if (xElement == null)
		{
			return null;
		}
		return new XDocument(new XElement(xElement));
	}

	private static int GetXmlElementRowSpan(XElement P_0)
	{
		if (!int.TryParse(P_0.Element(WordmlNamespace + "tcPr")?.Element(WordmlNamespace + "gridSpan")?.Attribute(WordmlNamespace + "val")?.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) || result < 1)
		{
			return 1;
		}
		return result;
	}

	private static string GetXmlElementText(XElement P_0)
	{
		XElement xElement = P_0.Element(WordmlNamespace + "tcPr")?.Element(WordmlNamespace + "vMerge");
		if (xElement == null)
		{
			return null;
		}
		string text = xElement.Attribute(WordmlNamespace + "val")?.Value;
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return "continue";
	}

	private static AiHelper_5 ExecuteOperation(Microsoft.Office.Interop.Word.Application P_0, Document P_1, Range P_2, string P_3)
	{
		_G_c__DisplayClass148_0 CS_8_locals_16 = new _G_c__DisplayClass148_0();
		CS_8_locals_16.doc = P_1;
		CS_8_locals_16.TargetRange = P_2;
		CS_8_locals_16.ReplacementText = P_3;
		AiHelper_5 insertResult = ValidateRange(P_0, CS_8_locals_16.doc, CS_8_locals_16.TargetRange);
		if (insertResult != null)
		{
			return insertResult;
		}
		return oBKTTgZY41(P_0, "AI 修订替换", delegate
		{
			bool trackRevisions = CS_8_locals_16.doc.TrackRevisions;
			try
			{
				CS_8_locals_16.doc.TrackRevisions = true;
				string text = NormalizeText(CS_8_locals_16.TargetRange.Text);
				int start = CS_8_locals_16.TargetRange.Start;
				CS_8_locals_16.TargetRange.Text = CS_8_locals_16.ReplacementText ?? string.Empty;
				return AiHelper_5.CreateSuccess("invalid_arguments", new
				{
					document = CS_8_locals_16.doc.Name,
					documentFullName = CS_8_locals_16.doc.FullName,
					page = ComputeIntValue(CS_8_locals_16.TargetRange),
					rangeStart = start,
					oldCharacters = text.Length,
					newCharacters = (CS_8_locals_16.ReplacementText ?? string.Empty).Length,
					oldPreview = TruncateText(text, 240)
				});
			}
			finally
			{
				CS_8_locals_16.doc.TrackRevisions = trackRevisions;
			}
		});
	}

	private static AiHelper_5 ValidateRange(Microsoft.Office.Interop.Word.Application P_0, Document P_1, Range P_2)
	{
		if (P_0 == null || P_1 == null)
		{
			return AiHelper_5.CreateError("Word 应用或目标文档不可用。", "word_not_ready");
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
			if (range == null || !IsRangeValid(range))
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
			InitializeRuntime();
			if (!IsRangeValid(uEGgJLYMWc(P_0)))
			{
				P_0.Selection.SetRange(num, num);
				InitializeRuntime();
			}
		}
		catch (Exception ex)
		{
			return AiHelper_5.CreateError("无法将 Word 焦点切回正文区域。请点击正文后重试同一工具，不要改用无修订写入。", "main_document_focus_failed", new
			{
				exception = ex.GetType().Name,
				message = ex.Message,
				retrySameTool = true
			});
		}
		if (!IsRangeValid(uEGgJLYMWc(P_0)))
		{
			return AiHelper_5.CreateError("当前 Word 焦点仍不在正文区域，可能仍选中了批注或批注窗格。请点击正文后重试同一工具，不要改用无修订写入。", "main_document_focus_failed", new
			{
				retrySameTool = true
			});
		}
		return null;
	}

	private static bool IsRangeValid(Range P_0)
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

	private static void InitializeRuntime()
	{
		try
		{
			System.Windows.Forms.Application.DoEvents();
		}
		catch
		{
		}
	}

	private static Paragraph GetParagraphByIndex(Document P_0, string P_1, int P_2, int P_3, string P_4)
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
			int num = GetOutlineLevel(paragraph);
			if (num >= 1 && num <= 9 && (P_3 <= 0 || num == P_3) && OYJgKddkFp(NormalizeText(paragraph.Range.Text), P_1, text))
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

	private static object BuildResultObject(Selection P_0, bool P_1, int P_2)
	{
		if (P_0 == null || P_0.Range == null)
		{
			return null;
		}
		string text = NormalizeText(P_0.Range.Text);
		bool flag = text.Length > P_2;
		return new
		{
			page = (P_1 ? new int?(ComputeIntValue(P_0.Range)) : ((int?)null)),
			rangeStart = P_0.Range.Start,
			rangeEnd = P_0.Range.End,
			characters = text.Length,
			truncated = flag,
			excerpt = (flag ? text.Substring(0, P_2) : text)
		};
	}

	private static object BuildParagraphInfo(Paragraph P_0, int P_1, int P_2)
	{
		string text = NormalizeText(P_0.Range.Text);
		bool flag = text.Length > P_2;
		int num = ClampOutlineLevel(GetOutlineLevel(P_0));
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

	private static object BuildParagraphInfo(Paragraph P_0, int P_1, int P_2)
	{
		_G_c__DisplayClass157_0 CS_8_locals_9 = new _G_c__DisplayClass157_0();
		CS_8_locals_9.XbCACwggdo = P_0;
		string text = NormalizeText(CS_8_locals_9.XbCACwggdo.Range.Text);
		bool flag = text.Length > P_2;
		int num = ClampOutlineLevel(GetOutlineLevel(CS_8_locals_9.XbCACwggdo));
		bool flag2 = num >= 1 && num <= 9;
		string styleName = GetParagraphStyleName(CS_8_locals_9.XbCACwggdo);
		return new
		{
			document = SafeExecute(() => CS_8_locals_9.XbCACwggdo.Range.Document.Name),
			documentFullName = SafeExecute(() => CS_8_locals_9.XbCACwggdo.Range.Document.FullName),
			page = ComputeIntValue(CS_8_locals_9.XbCACwggdo.Range),
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
		CS_8_locals_28.TargetTable = P_0;
		int num = GetTableRowCount(CS_8_locals_28.TargetTable);
		int num2 = GetTableColumnCount(CS_8_locals_28.TargetTable);
		string text = NormalizeText(CS_8_locals_28.TargetTable.Range.Text);
		List<Helper_3> list = GetCellSpans(CS_8_locals_28.TargetTable);
		List<string> list2 = new List<string>();
		int num3 = Math.Min(num, P_2);
		int num4 = Math.Min(num2, P_3);
		int num5 = 0;
		bool hasMergedOrUnavailableCells = num <= 0 || num2 <= 0;
		if (num <= 0 || num2 <= 0)
		{
			return new
			{
				document = SafeExecute(() => CS_8_locals_28.TargetTable.Range.Document.Name),
				documentFullName = SafeExecute(() => CS_8_locals_28.TargetTable.Range.Document.FullName),
				index = P_1,
				altTextTitle = SanitizeToken(SafeExecute(() => CS_8_locals_28.TargetTable.Title)),
				altTextDescription = SanitizeToken(SafeExecute(() => CS_8_locals_28.TargetTable.Descr)),
				rows = num,
				columns = num2,
				returnedRows = 0,
				returnedColumns = 0,
				page = ComputeIntValue(CS_8_locals_28.TargetTable.Range),
				paragraphIndex = FindParagraphIndex(CS_8_locals_28.TargetTable.Range.Document, CS_8_locals_28.TargetTable.Range.Start),
				rangeStart = CS_8_locals_28.TargetTable.Range.Start,
				rangeEnd = CS_8_locals_28.TargetTable.Range.End,
				previousParagraph = etKgYkrBNM(CS_8_locals_28.TargetTable, -1),
				nextParagraph = etKgYkrBNM(CS_8_locals_28.TargetTable, 1),
				truncated = (text.Length > 3000),
				rowsData = new object[0],
				cellsFlat = DTdgfbqppO(list),
				markdown = string.Empty,
				rawText = TruncateText(text, 3000),
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
					string item = NormalizeText(CS_8_locals_28.TargetTable.Cell(num6, num7).Range.Text);
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
		bool flag = ValidateTableData(list3, list, num3, num4);
		if (flag)
		{
			list2.Add("Merged cells were expanded from table.Range.Cells where possible.");
		}
		List<object> rowsData = BuildList(list3);
		string markdown = ProcessString(list3);
		return new
		{
			document = SafeExecute(() => CS_8_locals_28.TargetTable.Range.Document.Name),
			documentFullName = SafeExecute(() => CS_8_locals_28.TargetTable.Range.Document.FullName),
			index = P_1,
			altTextTitle = SanitizeToken(SafeExecute(() => CS_8_locals_28.TargetTable.Title)),
			altTextDescription = SanitizeToken(SafeExecute(() => CS_8_locals_28.TargetTable.Descr)),
			rows = num,
			columns = num2,
			returnedRows = num3,
			returnedColumns = num4,
			page = ComputeIntValue(CS_8_locals_28.TargetTable.Range),
			paragraphIndex = FindParagraphIndex(CS_8_locals_28.TargetTable.Range.Document, CS_8_locals_28.TargetTable.Range.Start),
			rangeStart = CS_8_locals_28.TargetTable.Range.Start,
			rangeEnd = CS_8_locals_28.TargetTable.Range.End,
			previousParagraph = etKgYkrBNM(CS_8_locals_28.TargetTable, -1),
			nextParagraph = etKgYkrBNM(CS_8_locals_28.TargetTable, 1),
			truncated = (num > num3 || num2 > num4 || num5 >= 2000),
			rowsData = rowsData,
			cellsFlat = DTdgfbqppO(list),
			markdown = markdown,
			rawText = TruncateText(text, 3000),
			hasMergedOrUnavailableCells = hasMergedOrUnavailableCells,
			expandedMergedCells = flag,
			warnings = DeduplicateWarnings(list2)
		};
	}

	private static object etKgYkrBNM(Table P_0, int P_1)
	{
		try
		{
			_G_c__DisplayClass159_0 CS_8_locals_4 = new _G_c__DisplayClass159_0();
			CS_8_locals_4.doc = P_0.Range.Document;
			int num = ComputeIntValue(() => CS_8_locals_4.doc.Paragraphs.Count);
			if (P_1 < 0)
			{
				for (int num2 = num; num2 >= 1; num2--)
				{
					Paragraph paragraph = CS_8_locals_4.doc.Paragraphs[num2];
					if (paragraph.Range.End <= P_0.Range.Start && !string.IsNullOrWhiteSpace(NormalizeText(paragraph.Range.Text)))
					{
						return BuildParagraphInfo(paragraph, num2, 500);
					}
				}
			}
			else
			{
				for (int num3 = 1; num3 <= num; num3++)
				{
					Paragraph paragraph2 = CS_8_locals_4.doc.Paragraphs[num3];
					if (paragraph2.Range.Start >= P_0.Range.End && !string.IsNullOrWhiteSpace(NormalizeText(paragraph2.Range.Text)))
					{
						return BuildParagraphInfo(paragraph2, num3, 500);
					}
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static List<Helper_3> GetCellSpans(Table P_0)
	{
		List<Helper_3> list = new List<Helper_3>();
		int num = 0;
		try
		{
			foreach (Cell cell in P_0.Range.Cells)
			{
				num++;
				if (num <= 2000)
				{
					list.Add(new Helper_3
					{
						CellIndex = num,
						RowIndex = GetCellRowIndex(cell),
						ColumnIndex = GetCellColumnIndex(cell),
						RowSpan = 1,
						ColumnSpan = 1,
						Page = ComputeIntValue(cell.Range),
						RangeStart = cell.Range.Start,
						RangeEnd = cell.Range.End,
						Text = NormalizeText(cell.Range.Text)
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

	private static List<object> DTdgfbqppO(List<Helper_3> P_0)
	{
		List<object> list = new List<object>();
		if (P_0 == null)
		{
			return list;
		}
		foreach (Helper_3 item in P_0)
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

	private static bool ValidateTableData(List<List<string>> P_0, List<Helper_3> P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 == null || P_1.Count == 0)
		{
			return false;
		}
		bool flag = false;
		List<Helper_3> list = new List<Helper_3>();
		foreach (Helper_3 item in P_1)
		{
			if (item.RowIndex.HasValue && item.ColumnIndex.HasValue && item.RowIndex.Value >= 1 && item.RowIndex.Value <= P_2 && item.ColumnIndex.Value >= 1 && item.ColumnIndex.Value <= P_3)
			{
				list.Add(item);
				flag |= TrySetCellValue(P_0, item.RowIndex.Value, item.ColumnIndex.Value, item.Text);
			}
		}
		foreach (Helper_3 item2 in list)
		{
			if (string.IsNullOrEmpty(item2.Text))
			{
				continue;
			}
			int value = item2.RowIndex.Value;
			int value2 = item2.ColumnIndex.Value;
			int num = P_3 + 1;
			foreach (Helper_3 item3 in list)
			{
				if (item3 != item2 && item3.RowIndex == value && item3.ColumnIndex.HasValue && item3.ColumnIndex.Value > value2 && item3.ColumnIndex.Value < num)
				{
					num = item3.ColumnIndex.Value;
				}
			}
			int num2 = 1;
			for (int i = value2 + 1; i < num && i <= P_3; i++)
			{
				if (TrySetCellValue(P_0, value, i, item2.Text))
				{
					flag = true;
					num2 = Math.Max(num2, i - value2 + 1);
				}
			}
			item2.ColumnSpan = Math.Max(item2.ColumnSpan, num2);
			int num3 = 1;
			for (int j = value + 1; j <= P_2 && !CheckCondition(list, j, value2) && TrySetCellValue(P_0, j, value2, item2.Text); j++)
			{
				flag = true;
				num3 = Math.Max(num3, j - value + 1);
			}
			item2.RowSpan = Math.Max(item2.RowSpan, num3);
		}
		return flag;
	}

	private static bool CheckCondition(List<Helper_3> P_0, int P_1, int P_2)
	{
		foreach (Helper_3 item in P_0)
		{
			if (item.RowIndex == P_1 && item.ColumnIndex == P_2)
			{
				return true;
			}
		}
		return false;
	}

	private static bool TrySetCellValue(List<List<string>> P_0, int P_1, int P_2, string P_3)
	{
		if (string.IsNullOrEmpty(P_3) || P_1 < 1 || P_2 < 1 || P_1 > P_0.Count)
		{
			return false;
		}
		List<string> list = P_0[P_1 - 1];
		if (P_2 > list.Count || !IsNonEmptyText(list[P_2 - 1]))
		{
			return false;
		}
		list[P_2 - 1] = P_3;
		return true;
	}

	private static bool IsNonEmptyText(string P_0)
	{
		return string.Equals(P_0, "[merged/unavailable]", StringComparison.Ordinal);
	}

	private static List<object> BuildList(List<List<string>> P_0)
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

	private static string ProcessString(List<List<string>> P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < P_0.Count; i++)
		{
			List<string> list = P_0[i];
			stringBuilder.Append("| ");
			stringBuilder.Append(string.Join(" | ", NormalizeCellSelectors(list)));
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

	private static object BuildCommentAddedInfo(Document P_0, Range P_1, int P_2, string P_3)
	{
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			commentIndex = P_2,
			page = ComputeIntValue(P_1),
			paragraphIndex = FindParagraphIndex(P_0, P_1.Start),
			rangeStart = P_1.Start,
			rangeEnd = P_1.End,
			targetPreview = TruncateText(NormalizeText(P_1.Text), 240),
			comment = P_3.Trim()
		};
	}

	private static object qXYglKDlsW(Document P_0, Comment P_1, bool P_2, int P_3, int P_4)
	{
		_G_c__DisplayClass169_0 CS_8_locals_11 = new _G_c__DisplayClass169_0();
		CS_8_locals_11.TargetComment = P_1;
		int num;
		bool flag;
		List<object> list = tmKgNwqeQC(P_0, CS_8_locals_11.TargetComment, P_4, out num, out flag);
		Range range = GetCommentAnchorRange(CS_8_locals_11.TargetComment) ?? GetCommentScopeRange(CS_8_locals_11.TargetComment);
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			["commentToken"] = qoRgqGAgBm(P_0, CS_8_locals_11.TargetComment),
			["index"] = GetCommentThreadIndex(CS_8_locals_11.TargetComment),
			["author"] = SafeExecute(() => CS_8_locals_11.TargetComment.Author),
			["date"] = MmigeqmiRt(CS_8_locals_11.TargetComment),
			["done"] = Ex5TMxi7X1(() => CS_8_locals_11.TargetComment.Done, ypQS6RTSiCdpSgKNQtr: false),
			["commentText"] = GetCommentText(CS_8_locals_11.TargetComment),
			["replyCount"] = num,
			["repliesReturned"] = list.Count,
			["repliesTruncated"] = flag,
			["replies"] = list,
			["anchorRangeStart"] = GetRangeStart(range),
			["anchorRangeEnd"] = GetRangeEnd(range)
		};
		if (P_2)
		{
			dictionary["anchorText"] = TruncateText(XPEgcZYWAO(CS_8_locals_11.TargetComment), P_3);
		}
		return dictionary;
	}

	private static List<object> tmKgNwqeQC(Document P_0, Comment P_1, int P_2, out int P_3, out bool P_4)
	{
		_G_c__DisplayClass170_0 CS_8_locals_4 = new _G_c__DisplayClass170_0();
		List<object> list = new List<object>();
		CS_8_locals_4.CommentsCollection = DOYgOEfqSy(P_1);
		P_3 = ((CS_8_locals_4.CommentsCollection != null) ? ComputeIntValue(() => CS_8_locals_4.CommentsCollection.Count) : 0);
		int num = Math.Max(0, P_2);
		for (int num2 = 1; num2 <= P_3; num2++)
		{
			if (list.Count >= num)
			{
				break;
			}
			try
			{
				Comment comment = CS_8_locals_4.CommentsCollection[num2];
				list.Add(BuildCommentInfo(P_0, comment));
			}
			catch
			{
			}
		}
		P_4 = list.Count < P_3;
		return list;
	}

	private static object BuildCommentInfo(Document P_0, Comment P_1)
	{
		_G_c__DisplayClass171_0 CS_8_locals_7 = new _G_c__DisplayClass171_0();
		CS_8_locals_7.TargetComment = P_1;
		return new Dictionary<string, object>
		{
			["commentToken"] = qoRgqGAgBm(P_0, CS_8_locals_7.TargetComment),
			["index"] = GetCommentThreadIndex(CS_8_locals_7.TargetComment),
			["author"] = SafeExecute(() => CS_8_locals_7.TargetComment.Author),
			["date"] = MmigeqmiRt(CS_8_locals_7.TargetComment),
			["done"] = Ex5TMxi7X1(() => CS_8_locals_7.TargetComment.Done, ypQS6RTSiCdpSgKNQtr: false),
			["commentText"] = GetCommentText(CS_8_locals_7.TargetComment)
		};
	}

	private static object BuildCommentReplyInfo(Document P_0, Comment P_1, Comment P_2, Comment P_3, string P_4)
	{
		Range range = GetCommentAnchorRange(P_1) ?? GetCommentScopeRange(P_1);
		int? rangeStart = GetRangeStart(range);
		int? rangeEnd = GetRangeEnd(range);
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			targetCommentToken = qoRgqGAgBm(P_0, P_2),
			threadCommentToken = qoRgqGAgBm(P_0, P_1),
			replyCommentToken = qoRgqGAgBm(P_0, P_3),
			targetCommentIndex = GetCommentThreadIndex(P_2),
			threadCommentIndex = GetCommentThreadIndex(P_1),
			replyIndex = GetCommentThreadIndex(P_3),
			page = ComputeIntValue(range),
			paragraphIndex = (rangeStart.HasValue ? FindParagraphIndex(P_0, rangeStart.Value) : ((int?)null)),
			rangeStart = rangeStart,
			rangeEnd = rangeEnd,
			scopeText = TruncateText(XPEgcZYWAO(P_1), 500),
			commentText = GetCommentText(P_2),
			replyText = P_4,
			replyCount = GetCommentReplyCount(P_1)
		};
	}

	private static AiHelper_5 ExecuteOperation(Document P_0, int P_1, out Comment P_2, out Comment P_3)
	{
		_G_c__DisplayClass173_0 CS_8_locals_8 = new _G_c__DisplayClass173_0();
		CS_8_locals_8.doc = P_0;
		P_2 = null;
		P_3 = null;
		if (CS_8_locals_8.doc == null)
		{
			return AiHelper_5.CreateError("当前没有打开的 Word 文档。", "no_document");
		}
		if (P_1 <= 0)
		{
			return AiHelper_5.CreateError("commentToken 或正整数 commentIndex 至少需要提供一个。", "invalid_arguments", new
			{
				commentIndex = P_1
			});
		}
		int num = ComputeIntValue(() => CS_8_locals_8.doc.Comments.Count);
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
			if (GetCommentThreadIndex(comment) == P_1)
			{
				P_2 = comment;
				P_3 = comment2 ?? comment;
				return null;
			}
			if (comment2 != null)
			{
				continue;
			}
			CS_8_locals_9.CommentsCollection = DOYgOEfqSy(comment);
			int num3 = ((CS_8_locals_9.CommentsCollection != null) ? ComputeIntValue(() => CS_8_locals_9.CommentsCollection.Count) : 0);
			for (int num4 = 1; num4 <= num3; num4++)
			{
				Comment comment3;
				try
				{
					comment3 = CS_8_locals_9.CommentsCollection[num4];
				}
				catch
				{
					continue;
				}
				if (GetCommentThreadIndex(comment3) == P_1)
				{
					P_2 = comment3;
					P_3 = zBSgpYfGrc(comment3) ?? comment;
					return null;
				}
			}
		}
		return AiHelper_5.CreateError("未找到指定 index 的 Word 批注。请重新读取批注后再回复。", "comment_not_found", new
		{
			commentIndex = P_1,
			totalComments = num
		});
	}

	private static AiHelper_5 CLCgCUGOui(Document P_0, string P_1, int P_2, out Comment P_3, out Comment P_4)
	{
		_G_c__DisplayClass174_0 CS_8_locals_7 = new _G_c__DisplayClass174_0();
		CS_8_locals_7.doc = P_0;
		P_3 = null;
		P_4 = null;
		if (CS_8_locals_7.doc == null)
		{
			return AiHelper_5.CreateError("当前没有打开的 Word 文档。", "no_document");
		}
		string text = NormalizeToken(P_1);
		if (string.IsNullOrWhiteSpace(text))
		{
			return AiHelper_5.CreateError("commentToken 格式无效。请使用 read_word_comments 返回的 commentToken。", "invalid_arguments", new
			{
				commentToken = P_1
			});
		}
		int num = ComputeIntValue(() => CS_8_locals_7.doc.Comments.Count);
		if (P_2 > 0 && P_2 <= num)
		{
			try
			{
				Comment comment = CS_8_locals_7.doc.Comments[P_2];
				if (ValidateCommentScope(CS_8_locals_7.doc, comment, text))
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
			if (ValidateCommentScope(CS_8_locals_7.doc, comment2, text))
			{
				list.Add(comment2);
			}
		}
		if (list.Count == 0)
		{
			return AiHelper_5.CreateError("未找到指定 commentToken 对应的 Word 批注。请重新读取批注后再回复。", "comment_token_not_found", new
			{
				commentToken = NywgvGXtAq(text),
				commentIndexHint = P_2,
				totalComments = num
			});
		}
		if (list.Count > 1)
		{
			return AiHelper_5.CreateError("commentToken 匹配到多条 Word 批注。请重新读取批注后使用新的 token。", "comment_token_ambiguous", new
			{
				commentToken = NywgvGXtAq(text),
				commentIndexHint = P_2,
				matchedIndexes = list.Select(GetCommentThreadIndex).ToArray()
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

	private static Range GetCommentScopeRange(Comment P_0)
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

	private static Range GetCommentAnchorRange(Comment P_0)
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

	private static string GetCommentText(Comment P_0)
	{
		_G_c__DisplayClass179_0 obj = new _G_c__DisplayClass179_0();
		obj.HThvTPlNIo = P_0;
		return NormalizeText(SafeExecute(() => obj.HThvTPlNIo.Range.Text));
	}

	private static string XPEgcZYWAO(Comment P_0)
	{
		_G_c__DisplayClass180_0 obj = new _G_c__DisplayClass180_0();
		obj.CommentForScope = P_0;
		return NormalizeText(SafeExecute(() => obj.CommentForScope.Scope.Text));
	}

	private static string MmigeqmiRt(Comment P_0)
	{
		_G_c__DisplayClass181_0 obj = new _G_c__DisplayClass181_0();
		obj.CommentForDate = P_0;
		return SafeExecute(() => obj.CommentForDate.Date.ToString("endParagraphIndex is out of range.", CultureInfo.CurrentCulture));
	}

	private static int GetCommentThreadIndex(Comment P_0)
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

	private static int GetCommentReplyCount(Comment P_0)
	{
		_G_c__DisplayClass183_0 CS_8_locals_3 = new _G_c__DisplayClass183_0();
		CS_8_locals_3.CommentsCollection = DOYgOEfqSy(P_0);
		if (CS_8_locals_3.CommentsCollection != null)
		{
			return ComputeIntValue(() => CS_8_locals_3.CommentsCollection.Count);
		}
		return 0;
	}

	private static int? GetRangeStart(Range P_0)
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

	private static int? GetRangeEnd(Range P_0)
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
		string text = NormalizeScopeText(P_0);
		string value = NormalizeScopeText(P_1);
		if (!string.IsNullOrWhiteSpace(value))
		{
			return text.IndexOf(value, StringComparison.Ordinal) >= 0;
		}
		return true;
	}

	private static string qoRgqGAgBm(Document P_0, Comment P_1)
	{
		return NywgvGXtAq(GetCommentScopeText(P_0, P_1));
	}

	private static bool ValidateCommentScope(Document P_0, Comment P_1, string P_2)
	{
		if (P_1 == null || string.IsNullOrWhiteSpace(P_2))
		{
			return false;
		}
		return string.Equals(GetCommentScopeText(P_0, P_1), P_2, StringComparison.OrdinalIgnoreCase);
	}

	private static string GetCommentScopeText(Document P_0, Comment P_1)
	{
		_G_c__DisplayClass189_0 CS_8_locals_9 = new _G_c__DisplayClass189_0();
		CS_8_locals_9.doc = P_0;
		CS_8_locals_9.TargetComment = P_1;
		Range range = GetCommentAnchorRange(CS_8_locals_9.TargetComment) ?? GetCommentScopeRange(CS_8_locals_9.TargetComment);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("comment-token-v1").Append('\n').Append(SafeExecute(() => CS_8_locals_9.doc.FullName))
			.Append('\n')
			.Append(SafeExecute(() => CS_8_locals_9.doc.Name))
			.Append('\n')
			.Append(NormalizeScopeText(SafeExecute(() => CS_8_locals_9.TargetComment.Author)))
			.Append('\n')
			.Append(MmigeqmiRt(CS_8_locals_9.TargetComment))
			.Append('\n')
			.Append(NormalizeScopeText(GetCommentText(CS_8_locals_9.TargetComment)))
			.Append('\n')
			.Append(GetRangeStart(range)?.ToString(CultureInfo.InvariantCulture) ?? string.Empty)
			.Append('\n')
			.Append(GetRangeEnd(range)?.ToString(CultureInfo.InvariantCulture) ?? string.Empty);
		using SHA256 sHA = SHA256.Create();
		return BitConverter.ToString(sHA.ComputeHash(Encoding.UTF8.GetBytes(stringBuilder.ToString()))).Replace("-", string.Empty).Substring(0, 8)
			.ToUpperInvariant();
	}

	private static string NywgvGXtAq(string P_0)
	{
		string text = NormalizeToken(P_0);
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

	private static string NormalizeToken(string P_0)
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

	private static string NormalizeScopeText(string P_0)
	{
		return Regex.Replace(NormalizeText(P_0).Replace("\\\\r\\\\n", "\n").Replace("\\\\r", "\n").Replace("\\\\n", "\n")
			.Replace("\r\n", "\n")
			.Replace('\r', '\n'), "\\s+", " ").Trim();
	}

	private static object BuildTableInfo(Document P_0, Table P_1, int P_2, Range P_3)
	{
		_G_c__DisplayClass193_0 CS_8_locals_3 = new _G_c__DisplayClass193_0();
		CS_8_locals_3.TargetTable = P_1;
		int? rowIndex = null;
		int? columnIndex = null;
		string text = null;
		try
		{
			if (P_3 != null && P_3.Cells != null && P_3.Cells.Count > 0)
			{
				Cell cell = P_3.Cells[1];
				rowIndex = GetCellRowIndex(cell);
				columnIndex = GetCellColumnIndex(cell);
				text = NormalizeText(cell.Range.Text);
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
			page = ComputeIntValue(P_3),
			rangeStart = P_3.Start,
			rangeEnd = P_3.End,
			matchText = NormalizeText(P_3.Text),
			excerpt = GetRangeExcerpt(P_0, P_3, 160),
			cellTextPreview = (string.IsNullOrEmpty(text) ? null : TruncateText(text, 240)),
			tableRangeStart = Ex5TMxi7X1(() => CS_8_locals_3.TargetTable.Range.Start, 0),
			tableRangeEnd = Ex5TMxi7X1(() => CS_8_locals_3.TargetTable.Range.End, 0)
		};
	}

	private static List<WordSearchResult> BuildList(Microsoft.Office.Interop.Word.Application P_0, Document P_1, string P_2, bool P_3, bool P_4, int P_5)
	{
		_G_c__DisplayClass194_0 CS_8_locals_24 = new _G_c__DisplayClass194_0();
		CS_8_locals_24.WordApplication = P_0;
		CS_8_locals_24.doc = P_1;
		List<WordSearchResult> list = new List<WordSearchResult>();
		if (CS_8_locals_24.WordApplication == null || CS_8_locals_24.doc == null || string.IsNullOrEmpty(P_2))
		{
			return list;
		}
		CS_8_locals_24.KaavoKjFKG = CS_8_locals_24.WordApplication.Selection;
		if (CS_8_locals_24.KaavoKjFKG == null || CS_8_locals_24.KaavoKjFKG.Range == null)
		{
			return list;
		}
		int num = Ex5TMxi7X1(() => CS_8_locals_24.KaavoKjFKG.Range.Start, CS_8_locals_24.doc.Content.Start);
		int end = Ex5TMxi7X1(() => CS_8_locals_24.KaavoKjFKG.Range.End, num);
		bool screenUpdating = Ex5TMxi7X1(() => CS_8_locals_24.WordApplication.ScreenUpdating, ypQS6RTSiCdpSgKNQtr: true);
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
				CS_8_locals_24.WordApplication.ScreenUpdating = false;
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
					list.Add(BuildSearchResult(CS_8_locals_26.NSNvOLlBYV));
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
				CS_8_locals_24.WordApplication.ScreenUpdating = screenUpdating;
			}
			catch
			{
			}
		}
		return list;
	}

	private static WordSearchResult BuildSearchResult(Range P_0)
	{
		string text = GetRangeExcerpt(P_0, 1200);
		int length = text.Length;
		bool flag = text.Length > 1200;
		return new WordSearchResult
		{
			ParagraphIndex = null,
			RangeStart = P_0.Start,
			RangeEnd = P_0.End,
			MatchText = NormalizeText(P_0.Text),
			ParagraphText = (flag ? TruncateText(text, 1200) : text),
			ParagraphTextCharacters = length,
			ParagraphTextTruncated = flag
		};
	}

	private static string GetRangeExcerpt(Range P_0, int P_1)
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
			return TruncateText(NormalizeText(document.Range(ref Start, ref End).Text), P_1);
		}
		catch
		{
			return TruncateText(NormalizeText(P_0.Text), P_1);
		}
	}

	private static List<RegexMatchResult> FindRegexMatches(Document P_0, string P_1, bool P_2, int P_3)
	{
		_G_c__DisplayClass197_0 CS_8_locals_3 = new _G_c__DisplayClass197_0();
		CS_8_locals_3.doc = P_0;
		List<RegexMatchResult> list = new List<RegexMatchResult>();
		RegexOptions options = ((!P_2) ? RegexOptions.IgnoreCase : RegexOptions.None);
		Regex regex = new Regex(P_1, options);
		int num = ComputeIntValue(() => CS_8_locals_3.doc.Paragraphs.Count);
		for (int num2 = 1; num2 <= num; num2++)
		{
			if (list.Count >= P_3)
			{
				break;
			}
			Paragraph paragraph = CS_8_locals_3.doc.Paragraphs[num2];
			string text = NormalizeText(paragraph.Range.Text);
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
				list.Add(new RegexMatchResult
				{
					ParagraphIndex = num2,
					Page = ComputeIntValue(paragraph.Range),
					CharIndexStart = item.Index + 1,
					CharIndexEnd = item.Index + item.Length,
					RangeStart = num3,
					RangeEnd = num3 + item.Length,
					MatchText = item.Value,
					Excerpt = GetTextExcerpt(text, item.Index, item.Length)
				});
			}
		}
		return list;
	}

	private static object BuildResultObject(Document P_0, List<WordSearchResult> P_1, int P_2)
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
			matches = BuildList(P_1)
		};
	}

	private static List<object> BuildList(IEnumerable<WordSearchResult> P_0)
	{
		List<object> list = new List<object>();
		int num = 0;
		foreach (WordSearchResult item in P_0)
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

	private static object BuildRegexResults(Document P_0, List<RegexMatchResult> P_1, int P_2)
	{
		return new
		{
			document = P_0.Name,
			documentFullName = P_0.FullName,
			returned = P_1.Count,
			truncated = (P_1.Count >= P_2),
			matches = BuildList(P_0, P_1)
		};
	}

	private static List<object> BuildList(Document P_0, IEnumerable<RegexMatchResult> P_1)
	{
		List<object> list = new List<object>();
		foreach (RegexMatchResult item in P_1)
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

	private static int? FindParagraphIndex(Document P_0, int P_1)
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

	private static int ComputeIntValue(Document P_0, WdStatistic P_1)
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

	private static bool CheckCondition(Document P_0)
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

	private static int ComputeIntValue(Func<int> P_0)
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

	private static int GetOutlineLevel(Paragraph P_0)
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

	private static int ClampOutlineLevel(int P_0)
	{
		if (P_0 < 1 || P_0 > 9)
		{
			return 0;
		}
		return P_0;
	}

	private static int ClampOutlineLevel(int P_0)
	{
		if (P_0 != 0)
		{
			return P_0;
		}
		return 10;
	}

	private static string GetParagraphStyleName(Paragraph P_0)
	{
		try
		{
			_G_c__DisplayClass209_0 CS_8_locals_3 = new _G_c__DisplayClass209_0();
			object style = P_0.Range.get_Style();
			if (style == null)
			{
				return string.Empty;
			}
			CS_8_locals_3.TargetStyle = style as Style;
			if (CS_8_locals_3.TargetStyle != null)
			{
				string text = SafeExecute(() => CS_8_locals_3.TargetStyle.NameLocal);
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
					_G_o__209.faad26YgtT = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "NameLocal", typeof(BatchReplaceService3), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
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
					_G_o__209.Tncdj71sno = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Name", typeof(BatchReplaceService3), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
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

	private static int ComputeIntValue(Range P_0)
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

	private static bool IsRangeInTable(Range P_0)
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

	private static int GetTableRowCount(Table P_0)
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

	private static int GetTableColumnCount(Table P_0)
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

	private static int? GetCellRowIndex(Cell P_0)
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

	private static int? GetCellColumnIndex(Cell P_0)
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

	private static string SafeExecute(Func<string> P_0)
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

	private static int ClampValue(int P_0, int P_1, int P_2)
	{
		if (P_0 <= 0)
		{
			P_0 = P_1;
		}
		return Math.Max(1, Math.Min(P_0, P_2));
	}

	private static int ClampValue(int P_0)
	{
		if (P_0 <= 0)
		{
			P_0 = 1;
		}
		return Math.Max(1, Math.Min(P_0, 9));
	}

	private static string NormalizeText(string P_0)
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

	private static string SanitizeToken(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			return P_0;
		}
		return null;
	}

	private static string TruncateText(string P_0, int P_1)
	{
		if (string.IsNullOrEmpty(P_0) || P_0.Length <= P_1)
		{
			return P_0 ?? string.Empty;
		}
		return P_0.Substring(0, P_1) + "...";
	}

	private static string GetTextExcerpt(string P_0, int P_1, int P_2)
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

	private static string GetRangeExcerpt(Document P_0, Range P_1, int P_2)
	{
		try
		{
			int num = Math.Max(20, P_2 / 2);
			int num2 = Math.Max(P_0.Content.Start, P_1.Start - num);
			int num3 = Math.Min(P_0.Content.End, P_1.End + num);
			object Start = num2;
			object End = num3;
			return TruncateText(NormalizeText(P_0.Range(ref Start, ref End).Text), P_2);
		}
		catch
		{
			return TruncateText(NormalizeText(P_1?.Text), P_2);
		}
	}

	private static bool CheckCondition(string P_0, int P_1, int P_2)
	{
		bool num = P_1 <= 0 || !CheckCondition(P_0[P_1 - 1]);
		int num2 = P_1 + P_2;
		bool flag = num2 >= P_0.Length || !CheckCondition(P_0[num2]);
		return num && flag;
	}

	private static bool CheckCondition(char P_0)
	{
		if (!char.IsLetterOrDigit(P_0))
		{
			return P_0 == '_';
		}
		return true;
	}

	private static IEnumerable<string> NormalizeCellSelectors(IEnumerable<string> P_0)
	{
		foreach (string item in P_0)
		{
			yield return (item ?? string.Empty).Replace("invalid_arguments", "wholeTable").Replace("wholetable", "all").Replace("table", "wholeTable")
				.Replace("headerrow", "header");
		}
	}

	private static List<string> DeduplicateWarnings(List<string> P_0)
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

	static BatchReplaceService3()
	{
		SseStreamInitializer.InitializeRuntime();
		WordmlNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
		WordNamespace = "http://schemas.microsoft.com/office/2006/xmlPackage";
	}
}
