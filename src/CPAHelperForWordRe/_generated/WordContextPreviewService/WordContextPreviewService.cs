using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using WordWindowInfo;
using CPAHelper.Agent.Abstractions;
using AiHelper_15;
using AiSseStreamService3;
using Helper_16;
using Microsoft.Extensions.AI;
using ScreenshotCaptureHelper3;
using SseStreamInitializer;
using ImageAssetInfo;
using BatchReplaceService2;
using DocumentLifecycleGuard;
using AiHelper_5;

namespace WordContextPreviewService;

internal sealed class WordContextPreviewService : IToolProvider
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass26_0
	{
		public WordContextPreviewService RdghySAEWH;

		public string text;

		public _G_c__DisplayClass26_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 bcVheyShJl()
		{
			return RdghySAEWH.wordService.AddCommentAtSelection(text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass27_0
	{
		public WordContextPreviewService wordContextPreviewService;

		public int MpjhaLqo84;

		public int value;

		public string text;

		public _G_c__DisplayClass27_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 AddCommentAtRangeWrapper()
		{
			return wordContextPreviewService.wordService.AddCommentAtRange(MpjhaLqo84, value, text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_0
	{
		public WordContextPreviewService qMAhvYQWYZ;

		public int value;

		public int value;

		public int value;

		public string text;

		public _G_c__DisplayClass28_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 AddCommentAtParagraphRangeWrapper()
		{
			return qMAhvYQWYZ.wordService.AddCommentAtParagraphRange(value, value, value, text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass29_0
	{
		public WordContextPreviewService wordContextPreviewService;

		public int PkjaRdcyn1;

		public int AyfaVtiOZ9;

		public int lWcaBAniD2;

		public string text;

		public _G_c__DisplayClass29_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 q0rhd5d2p4()
		{
			return wordContextPreviewService.wordService.AddCommentAtTableCell(PkjaRdcyn1, AyfaVtiOZ9, lWcaBAniD2, text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_0
	{
		public WordContextPreviewService wordContextPreviewService;

		public string oKBaDhopyK;

		public string text;

		public int value;

		public string text;

		public string text;

		public _G_c__DisplayClass30_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ReplyCommentWrapper()
		{
			return wordContextPreviewService.wordService.ReplyComment(oKBaDhopyK, text, value, text, text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass31_0
	{
		public WordContextPreviewService wordContextPreviewService;

		public int rsBaQjgKT7;

		public string text;

		public string text;

		public bool IIAaJWJrJK;

		public _G_c__DisplayClass31_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 mDsaiJGfM4()
		{
			return wordContextPreviewService.wordService.InsertParagraph(rsBaQjgKT7, text, text, IIAaJWJrJK);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass32_0
	{
		public WordContextPreviewService wkkaUnjGT3;

		public int value;

		public int value;

		public int value;

		public _G_c__DisplayClass32_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 SetParagraphOutlineLevelWrapper()
		{
			return wkkaUnjGT3.wordService.SetParagraphOutlineLevel(value, value, value);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass33_0
	{
		public WordContextPreviewService SXLajQRDl3;

		public int value;

		public int value;

		public int value;

		public int value;

		public string iSgabAXZd9;

		public string cZhaSeWbRr;

		public string BDKawxvrDO;

		public bool flag;

		public bool flag;

		public _G_c__DisplayClass33_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 InsertTableAtRangeWrapper()
		{
			return SXLajQRDl3.wordService.InsertTableAtRange(value, value, value, value, iSgabAXZd9, cZhaSeWbRr, BDKawxvrDO, flag, flag);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass34_0
	{
		public WordContextPreviewService wordContextPreviewService;

		public int value;

		public int value;

		public int value;

		public int iZGaGQklFb;

		public string text;

		public int cHWapViHjw;

		public string AhwaOdWUbS;

		public string TxPaniFSNw;

		public bool flag;

		public string text;

		public _G_c__DisplayClass34_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 InsertTableRowsByModelWrapper()
		{
			return wordContextPreviewService.wordService.InsertTableRowsByModel(value, value, value, iZGaGQklFb, text, cHWapViHjw, AhwaOdWUbS, TxPaniFSNw, flag, text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass35_0
	{
		public WordContextPreviewService aPjaexnfHZ;

		public int value;

		public int value;

		public string FIdaFYJiPG;

		public string text;

		public string text;

		public bool xWfaqrOdsQ;

		public bool flag;

		public _G_c__DisplayClass35_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 FillTableCellsByModelWrapper()
		{
			return aPjaexnfHZ.wordService.FillTableCellsByModel(value, value, FIdaFYJiPG, text, text, xWfaqrOdsQ, flag);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass43_0
	{
		public WordContextPreviewService wordContextPreviewService;

		public int value;

		public int value;

		public string WFHakOwMjy;

		public int auTaxcOVp7;

		public _G_c__DisplayClass43_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ApplyParagraphFormatChangeWrapper()
		{
			return wordContextPreviewService.wordService.ApplyParagraphFormatChange(value, value, WFHakOwMjy, auTaxcOVp7);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass45_0
	{
		public WordContextPreviewService NFfazEqpm1;

		public int value;

		public string text;

		public string text;

		public int value;

		public _G_c__DisplayClass45_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ApplyTableFormatChangeWrapper()
		{
			return NFfazEqpm1.wordService.ApplyTableFormatChange(value, text, text, value);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass46_0
	{
		public WordContextPreviewService wordContextPreviewService;

		public int value;

		public int value;

		public string text;

		public _G_c__DisplayClass46_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ReplaceRangeWithTrackChangesWrapper()
		{
			return wordContextPreviewService.wordService.ReplaceRangeWithTrackChanges(value, value, text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass47_0
	{
		public WordContextPreviewService wordContextPreviewService;

		public string text;

		public _G_c__DisplayClass47_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 ReplaceSelectionWithTrackChangesWrapper()
		{
			return wordContextPreviewService.wordService.ReplaceSelectionWithTrackChanges(text);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass48_0
	{
		public WordContextPreviewService wordContextPreviewService;

		public string text;

		public string text;

		public int WGTqJqIKx2;

		public bool flag;

		public bool flag;

		public bool flag;

		public int HqmqERBfs1;

		public _G_c__DisplayClass48_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 dfqqHRcnGU()
		{
			return wordContextPreviewService.wordService.BatchReplaceTextExecute(text, text, WGTqJqIKx2, flag, flag, flag, HqmqERBfs1);
		}
	}

	private readonly AiHelper_15 wordService;

	private readonly BatchReplaceService2 openXmlService;

	private readonly ScreenshotCaptureHelper3 screenshotHelper;

	public string ProviderName => "Word";

	public WordContextPreviewService(AiHelper_15 P_0, BatchReplaceService2 P_1)
	{
		SseStreamInitializer.InitializeRuntime();
		wordService = P_0 ?? throw new ArgumentNullException("wordService");
		openXmlService = P_1 ?? throw new ArgumentNullException("openXmlService");
		screenshotHelper = new ScreenshotCaptureHelper3();
	}

	public IList<AITool> GetTools()
	{
		BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
		return new List<AITool>
		{
			CreateTool("GetCurrentWordContext", "get_current_word_context", bindingFlags),
			CreateTool("PreviewWordDocument", "preview_word_document", bindingFlags),
			CreateTool("PreviewWordSelection", "preview_word_selection", bindingFlags),
			CreateTool("ReadWordRange", "read_word_range", bindingFlags),
			CreateTool("ReadWordParagraphs", "read_word_paragraphs", bindingFlags),
			CreateTool("ReadWordOutline", "read_word_outline", bindingFlags),
			CreateTool("ReadWordSection", "read_word_section", bindingFlags),
			CreateTool("ReadWordTables", "read_word_tables", bindingFlags),
			CreateTool("ReadWordTablesInRange", "read_word_tables_in_range", bindingFlags),
			CreateTool("ReadWordComments", "read_word_comments", bindingFlags),
			CreateTool("FindWordHeading", "find_word_heading", bindingFlags),
			CreateTool("FindWordText", "find_word_text", bindingFlags),
			CreateTool("FindWordRegex", "find_word_regex", bindingFlags),
			CreateTool("FindWordTableText", "find_word_table_text", bindingFlags),
			CreateTool("SelectWordRange", "select_word_range", bindingFlags),
			CreateTool("SelectWordTable", "select_word_table", bindingFlags),
			CreateTool("CreateHtmlVisual", "create_html_visual", bindingFlags),
			CreateTool("AddWordCommentAtSelection", "add_word_comment_at_selection", bindingFlags),
			CreateTool("AddWordCommentAtRange", "add_word_comment_at_range", bindingFlags),
			CreateTool("AddWordCommentAtParagraphRange", "add_word_comment_at_paragraph_range", bindingFlags),
			CreateTool("AddWordCommentAtTableCell", "add_word_comment_at_table_cell", bindingFlags),
			CreateTool("ReplyWordComment", "reply_word_comment", bindingFlags),
			CreateTool("InsertWordParagraph", "insert_word_paragraph", bindingFlags),
			CreateTool("SetWordParagraphOutlineLevel", "set_word_paragraph_outline_level", bindingFlags),
			CreateTool("InsertWordTableAtRange", "insert_word_table_at_range", bindingFlags),
			CreateTool("InsertWordTableRowsByModel", "insert_word_table_rows_by_model", bindingFlags),
			CreateTool("FillWordTableCellsByModel", "fill_word_table_cells_by_model", bindingFlags),
			CreateTool("AdjustSelectedWordTablesFormat", "adjust_selected_word_tables_format", bindingFlags),
			CreateTool("AdjustSelectedWordParagraphsFormat", "adjust_selected_word_paragraphs_format", bindingFlags),
			CreateTool("ReadWordTableAdjustmentConfig", "read_word_table_adjustment_config", bindingFlags),
			CreateTool("ReadWordParagraphAdjustmentConfig", "read_word_paragraph_adjustment_config", bindingFlags),
			CreateTool("InspectWordTableFormat", "inspect_word_table_format", bindingFlags),
			CreateTool("InspectWordParagraphFormat", "inspect_word_paragraph_format", bindingFlags),
			CreateTool("PreviewWordParagraphFormatChange", "preview_word_paragraph_format_change", bindingFlags),
			CreateTool("ApplyWordParagraphFormatChange", "apply_word_paragraph_format_change", bindingFlags),
			CreateTool("PreviewWordTableFormatChange", "preview_word_table_format_change", bindingFlags),
			CreateTool("ApplyWordTableFormatChange", "apply_word_table_format_change", bindingFlags),
			CreateTool("ReplaceWordRangeWithTrackChanges", "replace_word_range_with_track_changes", bindingFlags),
			CreateTool("ReplaceWordSelectionWithTrackChanges", "replace_word_selection_with_track_changes", bindingFlags),
			CreateTool("BatchReplaceWordTextExecute", "batch_replace_word_text_execute", bindingFlags),
			CreateTool("ExportWordComments", "export_word_comments", bindingFlags)
		};
	}

	public IList<ToolMetadata> GetToolMetadata()
	{
		List<ToolMetadata> list = new List<ToolMetadata>();
		list.Add(new ToolMetadata("get_current_word_context", new string[2]
		{
			"word.core",
			"word.read"
		}, "获取当前 Word 文档、选区摘要和基础计数；用于定向，不替代精读。", isDefault: true));
		list.Add(new ToolMetadata("preview_word_document", new string[2]
		{
			"word.core",
			"word.read"
		}, "轻量预览首尾段落、一级标题和当前选区；不返回可直接写入的完整定位。", isDefault: true));
		list.Add(new ToolMetadata("preview_word_selection", new string[2]
		{
			"word.core",
			"word.read"
		}, "只读预览当前 Word 选区文本；写入选区应使用 Range 型或 Selection 型写入工具。", isDefault: true));
		list.Add(new ToolMetadata("read_word_range", new string[1] { "word.read" }, "按真实 Word Range.Start/End 读取文本；若范围含表格且要看结构，应改用 read_word_tables_in_range。", isDefault: true));
		list.Add(new ToolMetadata("read_word_paragraphs", new string[1] { "word.read" }, "按 OpenXML 段落序号只读预览段落；返回的 paragraphIndex 不是 COM 写入坐标。"));
		list.Add(new ToolMetadata("read_word_outline", new string[2]
		{
			"word.read",
			"word.structure"
		}, "按标题级次只读读取 Word 大纲；返回的 paragraphIndex 只用于继续阅读，写入前需重新取 COM Range。", isDefault: true));
		list.Add(new ToolMetadata("read_word_section", new string[2]
		{
			"word.read",
			"word.structure"
		}, "按标题文本或标题段落序号读取章节内容；返回内容用于理解，写入前仍需真实 COM Range。", isDefault: true));
		list.Add(new ToolMetadata("read_word_tables", new string[2]
		{
			"word.read",
			"word.structure"
		}, "纯预览全文表格或指定全文 tableIndex；不返回可写模型坐标，不作为填表/改表头前置。", isDefault: true));
		list.Add(new ToolMetadata("read_word_tables_in_range", new string[2]
		{
			"word.read",
			"word.structure"
		}, "按真实 Range 读取相交表格结构模型；返回 localTableIndex,rowIndex,columnIndex 和单元格 Range，是表格写入前置。", isDefault: true));
		list.Add(new ToolMetadata("read_word_comments", new string[2]
		{
			"word.read",
			"word.comment"
		}, "轻量读取 Word 文档现有批注线程；默认返回可回复的 commentToken、index、批注文本、回复和锚点 Range，不读取页码或段落号。", isDefault: true));
		list.Add(new ToolMetadata("find_word_heading", new string[3]
		{
			"word.read",
			"word.find",
			"word.structure"
		}, "按标题文本查找标题段落，返回可用于 read_word_section 的 headingParagraphIndex。", isDefault: true));
		list.Add(new ToolMetadata("find_word_text", new string[2]
		{
			"word.read",
			"word.find"
		}, "普通文本查找；用 Word COM Range.Find 返回可写入的真实 rangeStart/rangeEnd、matchText 和段落上下文。", isDefault: true));
		list.Add(new ToolMetadata("find_word_regex", new string[2]
		{
			"word.read",
			"word.find"
		}, "快速 .NET/OpenXML 正则筛查；返回的 paragraphIndex/charIndex 只读，不是 COM 写入坐标。", isDefault: true));
		list.Add(new ToolMetadata("find_word_table_text", new string[3]
		{
			"word.read",
			"word.find",
			"word.structure"
		}, "在全文表格单元格中查找文本，返回全文 tableIndex/rowIndex/columnIndex；不用于表格写入前置。", isDefault: true));
		list.Add(new ToolMetadata("select_word_range", new string[3]
		{
			"word.core",
			"word.read",
			"word.write"
		}, "按真实 Range.Start/End 选中文档位置，便于人工核对。"));
		list.Add(new ToolMetadata("select_word_table", new string[3]
		{
			"word.core",
			"word.read",
			"word.write"
		}, "按全文 tableIndex 选中 Word 表格；不要传 read_word_tables_in_range 的 localTableIndex。"));
		list.Add(new ToolMetadata("create_html_visual", new string[3]
		{
			"word.visual",
			"word.write",
			"risk.confirm"
		}, "将受限的静态 HTML/CSS/SVG 离屏渲染为 PNG，并作为内嵌图片插入目标 Word 文档。"));
		list.Add(new ToolMetadata("add_word_comment_at_selection", new string[2]
		{
			"word.comment",
			"word.write"
		}, "给当前正文选区添加批注；已有 Range 时优先用 add_word_comment_at_range。", isDefault: true));
		list.Add(new ToolMetadata("add_word_comment_at_range", new string[2]
		{
			"word.comment",
			"word.write"
		}, "按真实 Range.Start/End 添加批注；正文和表格单元格 Range 均可用。", isDefault: true));
		list.Add(new ToolMetadata("add_word_comment_at_paragraph_range", new string[2]
		{
			"word.comment",
			"word.write"
		}, "按真实 Word COM 段落序号和段内字符范围添加批注；不要使用 OpenXML 坐标。", isDefault: true));
		list.Add(new ToolMetadata("add_word_comment_at_table_cell", new string[3]
		{
			"word.comment",
			"word.write",
			"word.structure"
		}, "按全文 tableIndex,rowIndex,columnIndex 添加简单表格批注；复杂/合并表格优先用单元格 Range 批注。", isDefault: true));
		list.Add(new ToolMetadata("reply_word_comment", new string[2]
		{
			"word.comment",
			"word.write"
		}, "按 read_word_comments 返回的 commentToken 回复现有批注线程；commentIndex 仅作加速 hint；不支持时不会降级为普通新批注。", isDefault: true));
		list.Add(new ToolMetadata("insert_word_paragraph", new string[2]
		{
			"word.write",
			"risk.confirm"
		}, "在真实 Word COM paragraphIndex 前或后插入新段落；不要使用 OpenXML paragraphIndex，useTrackChanges 默认 true。"));
		list.Add(new ToolMetadata("set_word_paragraph_outline_level", new string[3]
		{
			"word.write",
			"word.structure",
			"risk.confirm"
		}, "按真实 Word COM 段落范围或当前选区设置大纲级次；不要使用 OpenXML paragraphIndex。"));
		list.Add(new ToolMetadata("insert_word_table_at_range", new string[3]
		{
			"word.write",
			"word.structure",
			"risk.confirm"
		}, "在真实 Word Range 所在位置插入一张新表，并默认套用一键表格调整；适合空段落插表，必须 preview 取 token 后 execute。"));
		list.Add(new ToolMetadata("insert_word_table_rows_by_model", new string[3]
		{
			"word.write",
			"word.structure",
			"risk.confirm"
		}, "基于 read_word_tables_in_range 同一 Range 的 localTableIndex 和 rowIndex 插入表格行；必须 preview 取 token 后 execute。"));
		list.Add(new ToolMetadata("fill_word_table_cells_by_model", new string[3]
		{
			"word.write",
			"word.structure",
			"risk.confirm"
		}, "基于 read_word_tables_in_range 同一 Range 的模型坐标写表；必须 preview 取 token 后 execute。"));
		list.Add(new ToolMetadata("adjust_selected_word_tables_format", new string[3]
		{
			"word.write",
			"word.structure",
			"risk.confirm"
		}, "对当前选区/光标所在表格应用项目内置格式；只调格式，不填数。"));
		list.Add(new ToolMetadata("adjust_selected_word_paragraphs_format", new string[2]
		{
			"word.write",
			"risk.confirm"
		}, "对当前选区段落应用项目内置段落格式；跳过表格内段落，不替换正文。"));
		list.Add(new ToolMetadata("read_word_table_adjustment_config", new string[2]
		{
			"word.read",
			"word.structure"
		}, "读取用户保存的表格格式配置；不是当前表格实际格式。", isDefault: true));
		list.Add(new ToolMetadata("read_word_paragraph_adjustment_config", new string[1] { "word.read" }, "读取用户保存的段落格式配置；不是当前段落实际格式。", isDefault: true));
		list.Add(new ToolMetadata("inspect_word_table_format", new string[2]
		{
			"word.read",
			"word.structure"
		}, "读取指定全文 tableIndex 或当前选区表格的实际格式；不读取保存配置。", isDefault: true));
		list.Add(new ToolMetadata("inspect_word_paragraph_format", new string[1] { "word.read" }, "读取真实 Word COM paragraphIndex 或当前选区第一段的实际格式；不要使用 OpenXML paragraphIndex。", isDefault: true));
		list.Add(new ToolMetadata("preview_word_paragraph_format_change", new string[1] { "word.read" }, "预览一次性段落格式修改；段落参数必须是真实 Word COM paragraphIndex 或 0 表示当前选区。", isDefault: true));
		list.Add(new ToolMetadata("apply_word_paragraph_format_change", new string[2]
		{
			"word.write",
			"risk.confirm"
		}, "执行一次性段落格式修改；必须基于预览的 expectedChangeCount，不接受 OpenXML paragraphIndex。"));
		list.Add(new ToolMetadata("preview_word_table_format_change", new string[2]
		{
			"word.read",
			"word.structure"
		}, "预览一次性表格格式修改；tableIndex 为全文表格序号，0 表示当前选区表格。", isDefault: true));
		list.Add(new ToolMetadata("apply_word_table_format_change", new string[3]
		{
			"word.write",
			"word.structure",
			"risk.confirm"
		}, "执行一次性表格格式修改；必须基于预览的 expectedChangeCount，tableIndex 不用 localTableIndex。"));
		list.Add(new ToolMetadata("replace_word_range_with_track_changes", new string[2]
		{
			"word.write",
			"risk.confirm"
		}, "按真实 Range 替换正文并强制使用 Word 修订；正文编辑首选。"));
		list.Add(new ToolMetadata("replace_word_selection_with_track_changes", new string[2]
		{
			"word.write",
			"risk.confirm"
		}, "替换当前正文选区并强制使用 Word 修订；已有坐标时优先用 Range 替换。"));
		list.Add(new ToolMetadata("batch_replace_word_text_execute", new string[3]
		{
			"word.write",
			"word.find",
			"risk.confirm"
		}, "全文批量替换，直接执行且强制使用 Word 修订；不适合局部精确替换。"));
		list.Add(new ToolMetadata("export_word_comments", new string[1] { "word.comment" }, "导出 Word 批注到 Excel。"));
		return list;
	}

	private AITool CreateTool(string P_0, string P_1, BindingFlags P_2)
	{
		return AIFunctionFactory.Create(GetType().GetMethod(P_0, P_2), this, new AIFunctionFactoryOptions
		{
			Name = P_1
		});
	}

	[Description("获取当前 Word 文档上下文，包括文档名、路径、段落数、表格数、批注数、修订状态和当前选区摘要；用于定向，并建立本轮全文 OpenXML 读取缓存。")]
	private AiHelper_5 GetCurrentWordContext(int maxSelectionCharacters = 240)
	{
		return openXmlService.GetCurrentContext(maxSelectionCharacters);
	}

	[Description("轻量预览当前 Word 文档：返回首尾段落、一级标题、当前选区、段落/表格/批注计数和修订状态；不返回可直接写入的完整定位。")]
	private AiHelper_5 PreviewWordDocument(int headParagraphs = 8, int tailParagraphs = 4, int maxHeadings = 50, int maxCharactersPerParagraph = 180, int maxSelectionCharacters = 240)
	{
		return openXmlService.PreviewDocument(headParagraphs, tailParagraphs, maxHeadings, maxCharactersPerParagraph, maxSelectionCharacters);
	}

	[Description("只读预览当前 Word 选区文本和轻量定位；如需修改当前正文选区，使用 replace_word_selection_with_track_changes。")]
	private AiHelper_5 PreviewWordSelection(int maxCharacters = 6000)
	{
		return openXmlService.PreviewSelection(maxCharacters);
	}

	[Description("按真实 Word Range.Start/End 精确读取文本；若范围包含表格且需要结构模型或写入，请使用 read_word_tables_in_range。")]
	private AiHelper_5 ReadWordRange(int rangeStart, int rangeEnd, int maxCharacters = 30000)
	{
		return openXmlService.ReadRange(rangeStart, rangeEnd, maxCharacters);
	}

	[Description("按 OpenXML 段落序号只读预览段落。startParagraphIndex/endParagraphIndex 均为 1-based；endParagraphIndex>0 时按范围读取，否则按 count 读取；返回的 paragraphIndex/charIndex 不是 Word COM 写入坐标。")]
	private AiHelper_5 ReadWordParagraphs(int startParagraphIndex = 1, int count = 20, int endParagraphIndex = 0, int maxCharactersPerParagraph = 1000)
	{
		return openXmlService.ReadParagraphs(startParagraphIndex, count, endParagraphIndex, maxCharactersPerParagraph);
	}

	[Description("只读读取当前 Word 文档大纲。maxOutlineLevel 控制返回到几级标题，默认 1；传 2/3/9 可逐级展开；返回的 paragraphIndex 只用于继续阅读，写入前需重新取得真实 COM Range。")]
	private AiHelper_5 ReadWordOutline(int maxItems = 300, bool includeBodyText = false, int maxOutlineLevel = 1)
	{
		return openXmlService.ReadOutline(maxItems, includeBodyText, maxOutlineLevel);
	}

	[Description("按标题文本或标题段落序号读取章节内容。headingParagraphIndex 优先；未传时按 headingText 查找。matchMode 支持 contains/equals/startswith。返回内容用于阅读，写入前仍需真实 Word COM Range。")]
	private AiHelper_5 ReadWordSection(string headingText = "", int headingParagraphIndex = 0, int outlineLevel = 0, string matchMode = "contains", int startBlock = 0, int maxBlocks = 200, int maxCharactersPerBlock = 1000, int maxTableRows = 80, int maxTableColumns = 20)
	{
		return openXmlService.ReadSection(headingText, headingParagraphIndex, outlineLevel, matchMode, startBlock, maxBlocks, maxCharactersPerBlock, maxTableRows, maxTableColumns);
	}

	[Description("纯预览 Word 表格。tableIndex=0 时预览全文前 maxTables 个表格；tableIndex>0 时预览指定全文表格。返回替代文字、Markdown、矩阵和前后段落；不返回可写模型坐标，不作为填表或改表头前置。")]
	private AiHelper_5 ReadWordTables(int tableIndex = 0, int maxTables = 5, int maxRows = 80, int maxColumns = 20)
	{
		return openXmlService.ReadTables(tableIndex, maxTables, maxRows, maxColumns);
	}

	[Description("按真实 Word Range.Start/End 预览范围内相交表格，并读取编辑前必须使用的统一结构模型。返回展开矩阵、headerRowCount、多级列头路径、行标签路径、合并区域、localTableIndex,rowIndex,columnIndex 和单元格 Range。")]
	private AiHelper_5 ReadWordTablesInRange(int rangeStart, int rangeEnd, int maxTables = 20, int maxRows = 80, int maxColumns = 40)
	{
		return openXmlService.ReadTablesInRange(rangeStart, rangeEnd, maxTables, maxRows, maxColumns);
	}

	[Description("轻量读取当前 Word 文档现有批注线程。默认返回 commentToken、index、commentText、replies 和 anchorRangeStart/anchorRangeEnd；需要原文短预览时传 includeAnchorText=true。")]
	private AiHelper_5 ReadWordComments(int maxComments = 200, bool includeAnchorText = false, int maxAnchorTextCharacters = 120, int maxRepliesPerComment = 20)
	{
		return wordService.ReadComments(maxComments, includeAnchorText, maxAnchorTextCharacters, maxRepliesPerComment);
	}

	[Description("按标题文本查找 Word 标题段落。matchMode 支持 contains/equals/startswith；outlineLevel=0 表示不限级次。返回 headingParagraphIndex，可直接传给 read_word_section。")]
	private AiHelper_5 FindWordHeading(string headingText, int outlineLevel = 0, string matchMode = "contains", int maxMatches = 50)
	{
		return openXmlService.FindHeading(headingText, outlineLevel, matchMode, maxMatches);
	}

	[Description("普通文本查找。使用 Word COM Range.Find.Execute 获取真实 Word rangeStart/rangeEnd，并返回命中文本 matchText 和所在段落文本 paragraphText；rangeStart/rangeEnd 可直接用于批注、选中或替换。")]
	private AiHelper_5 FindWordText(string text, bool matchCase = false, bool wholeWord = false, int maxMatches = 100)
	{
		return wordService.FindText(text, matchCase, wholeWord, maxMatches);
	}

	[Description("快速 .NET/OpenXML 正则筛查。只返回只读 paragraphIndex、charIndexStart/End、matchText、excerpt，rangeStart/rangeEnd 为 null；不能直接用于任何 COM 写入。需要写入时用 matchText 再调用 find_word_text 获取真实 COM Range。")]
	private AiHelper_5 FindWordRegex(string pattern, bool matchCase = false, int maxMatches = 100)
	{
		return openXmlService.FindRegex(pattern, matchCase, maxMatches);
	}

	[Description("在全文 Word 表格单元格中查找文本，返回全文 tableIndex,rowIndex,columnIndex 和单元格文本；用于查找或简单表格批注，不用于 fill_word_table_cells_by_model 写入前置。")]
	private AiHelper_5 FindWordTableText(string text, bool matchCase = false, int maxMatches = 100)
	{
		return wordService.FindTableText(text, matchCase, maxMatches);
	}

	[Description("按真实 Word Range.Start/End 选中文档位置，便于人工核对。")]
	private AiHelper_5 SelectWordRange(int rangeStart, int rangeEnd)
	{
		return wordService.SelectRange(rangeStart, rangeEnd);
	}

	[Description("按全文 1-based tableIndex 选中 Word 表格；不要传 read_word_tables_in_range 返回的 localTableIndex。")]
	private AiHelper_5 SelectWordTable(int tableIndex)
	{
		return wordService.SelectTable(tableIndex);
	}

	[Description("将 AI 生成的静态 HTML/CSS/SVG 片段渲染为高清 PNG，并作为内嵌图片插入本轮绑定的 Word 文档。适用于封面视觉、信息图、流程图、数据卡片和复杂排版；结果不会随源数据自动刷新。仅允许内联 HTML/CSS/SVG 和 data: 图片，禁止 script、事件处理器、iframe、外部网址和网络资源。")]
	private AiHelper_5 CreateHtmlVisual([Description("要渲染的 HTML 片段，可包含 <style>、普通 HTML 和内联 SVG；不要包含 html/head/body 外层标签、Markdown 代码围栏、script 或外部资源")] string html, [Description("插入位置：selection（本轮初始选区末端）、range_start、range_end 或 document_end；默认 selection")] string position = "selection", [Description("position 为 range_start/range_end 时使用的真实 Word Range.Start；selection 一般无需传")] int rangeStart = -1, [Description("position 为 range_start/range_end 时使用的真实 Word Range.End；selection 一般无需传")] int rangeEnd = -1, [Description("渲染宽度，单位 CSS 像素，范围 240-1920，默认 960")] int width = 960, [Description("渲染高度，单位 CSS 像素，范围 120-1080，默认 540")] int height = 540, [Description("插入 Word 后的宽度，单位磅；默认 432（约 6 英寸，适合常见页面版心），传 0 时按 96 DPI 从渲染宽度换算")] double displayWidthPoints = 432.0, [Description("插入 Word 后的高度，单位磅；0 表示保持渲染宽高比自动换算")] double displayHeightPoints = 0.0, [Description("画布背景色，仅支持 #RGB、#RRGGBB 或 transparent，默认 #ffffff")] string backgroundColor = "#ffffff", [Description("视觉稿名称，写入图片标题和替代文字")] string visualName = "HTML视觉")
	{
		ImageAssetInfo imageAsset = null;
		try
		{
			int num = rangeStart;
			int num2 = rangeEnd;
			if (string.Equals(position?.Trim(), "selection", StringComparison.OrdinalIgnoreCase) && rangeStart < 0 && rangeEnd < 0)
			{
				WordWindowInfo current = DocumentLifecycleGuard.Current;
				if (current != null && current.HasDocument)
				{
					num = current.SelectionStart;
					num2 = current.SelectionEnd;
				}
			}
			imageAsset = screenshotHelper.RenderHtmlToPng(new Helper_16
			{
				HtmlFragment = html,
				PixelWidth = width,
				PixelHeight = height,
				BackgroundColor = (string.IsNullOrWhiteSpace(backgroundColor) ? "#ffffff" : backgroundColor.Trim())
			});
			double num3 = displayWidthPoints;
			double num4 = displayHeightPoints;
			if (num3 <= 0.0 && num4 <= 0.0)
			{
				num3 = (double)width * 72.0 / 96.0;
				num4 = (double)height * 72.0 / 96.0;
			}
			else if (num3 <= 0.0)
			{
				num3 = num4 * (double)width / (double)height;
			}
			else if (num4 <= 0.0)
			{
				num4 = num3 * (double)height / (double)width;
			}
			AiHelper_5 insertResult = wordService.InsertHtmlVisual(imageAsset.PngPath, position, num, num2, num3, num4, visualName, imageAsset.SourceHash);
			if (!insertResult.success)
			{
				return insertResult;
			}
			return AiHelper_5.CreateSuccess("HTML visual rendered and inserted into Word.", new
			{
				render = new
				{
					pixelWidth = imageAsset.PixelWidth,
					pixelHeight = imageAsset.PixelHeight,
					pngBytes = imageAsset.PngBytes,
					sourceHash = imageAsset.SourceHash,
					sourceFile = imageAsset.SourcePath,
					scriptsEnabled = false,
					externalResourcesAllowed = false
				},
				insertion = insertResult.data
			});
		}
		catch (Exception ex)
		{
			Exception baseException = ex.GetBaseException();
			return AiHelper_5.CreateExceptionError("Create HTML visual failed", (baseException is ArgumentException) ? "html_visual_error" : "invalid_arguments", ex);
		}
		finally
		{
			ScreenshotCaptureHelper3.DeleteTempPng(imageAsset?.PngPath);
		}
	}

	[Description("给当前正文选区添加批注；已有 rangeStart/rangeEnd 时优先使用 add_word_comment_at_range。")]
	private AiHelper_5 AddWordCommentAtSelection(string commentText)
	{
		_G_c__DisplayClass26_0 obj = new _G_c__DisplayClass26_0();
		obj.RdghySAEWH = this;
		obj.text = commentText;
		return ExecuteWithLifecycleGuard(() => obj.RdghySAEWH.wordService.AddCommentAtSelection(obj.text));
	}

	[Description("按真实 Word Range.Start/End 添加批注；正文 Range 和 read_word_tables_in_range 返回的单元格 Range 均可使用。")]
	private AiHelper_5 AddWordCommentAtRange(int rangeStart, int rangeEnd, string commentText)
	{
		_G_c__DisplayClass27_0 obj = new _G_c__DisplayClass27_0();
		obj.wordContextPreviewService = this;
		obj.MpjhaLqo84 = rangeStart;
		obj.value = rangeEnd;
		obj.text = commentText;
		return ExecuteWithLifecycleGuard(() => obj.wordContextPreviewService.wordService.AddCommentAtRange(obj.MpjhaLqo84, obj.value, obj.text));
	}

	[Description("按真实 Word COM 段落序号和段内字符范围添加批注。段落和字符均为 1-based；不要使用 read_word_section/find_word_regex 等 OpenXML 返回的 paragraphIndex/charIndex。正文批注优先用 find_word_text 获取 rangeStart/rangeEnd 后调用 add_word_comment_at_range。")]
	private AiHelper_5 AddWordCommentAtParagraphRange(int paragraphIndex, int charIndexStart, int charIndexEnd, string commentText)
	{
		_G_c__DisplayClass28_0 obj = new _G_c__DisplayClass28_0();
		obj.qMAhvYQWYZ = this;
		obj.value = paragraphIndex;
		obj.value = charIndexStart;
		obj.value = charIndexEnd;
		obj.text = commentText;
		return ExecuteWithLifecycleGuard(() => obj.qMAhvYQWYZ.wordService.AddCommentAtParagraphRange(obj.value, obj.value, obj.value, obj.text));
	}

	[Description("按全文 Word tableIndex,rowIndex,columnIndex 添加批注。全部为 1-based；复杂/合并表格优先用 read_word_tables_in_range 返回的单元格 Range 调用 add_word_comment_at_range。")]
	private AiHelper_5 AddWordCommentAtTableCell(int tableIndex, int rowIndex, int columnIndex, string commentText)
	{
		_G_c__DisplayClass29_0 obj = new _G_c__DisplayClass29_0();
		obj.wordContextPreviewService = this;
		obj.PkjaRdcyn1 = tableIndex;
		obj.AyfaVtiOZ9 = rowIndex;
		obj.lWcaBAniD2 = columnIndex;
		obj.text = commentText;
		return ExecuteWithLifecycleGuard(() => obj.wordContextPreviewService.wordService.AddCommentAtTableCell(obj.PkjaRdcyn1, obj.AyfaVtiOZ9, obj.lWcaBAniD2, obj.text));
	}

	[Description("按 read_word_comments 返回的 commentToken 回复现有批注线程；commentIndex 仅作加速 hint。未传 commentToken 时兼容旧的 commentIndex 定位。expectedCommentText/expectedScopeText 仅作额外校验。")]
	private AiHelper_5 ReplyWordComment(string commentToken = "", string replyText = "", int commentIndex = 0, string expectedCommentText = "", string expectedScopeText = "")
	{
		_G_c__DisplayClass30_0 obj = new _G_c__DisplayClass30_0();
		obj.wordContextPreviewService = this;
		obj.oKBaDhopyK = commentToken;
		obj.text = replyText;
		obj.value = commentIndex;
		obj.text = expectedCommentText;
		obj.text = expectedScopeText;
		return ExecuteWithLifecycleGuard(() => obj.wordContextPreviewService.wordService.ReplyComment(obj.oKBaDhopyK, obj.text, obj.value, obj.text, obj.text));
	}

	[Description("在指定真实 Word COM 段落前或后插入新段落。position 仅支持 before/after；不要使用 OpenXML paragraphIndex；不用于替换现有正文；useTrackChanges 默认 true。")]
	private AiHelper_5 InsertWordParagraph(int paragraphIndex, string position = "after", string text = "", bool useTrackChanges = true)
	{
		_G_c__DisplayClass31_0 obj = new _G_c__DisplayClass31_0();
		obj.wordContextPreviewService = this;
		obj.rsBaQjgKT7 = paragraphIndex;
		obj.text = position;
		obj.text = text;
		obj.IIAaJWJrJK = useTrackChanges;
		return ExecuteWithLifecycleGuard(() => obj.wordContextPreviewService.wordService.InsertParagraph(obj.rsBaQjgKT7, obj.text, obj.text, obj.IIAaJWJrJK));
	}

	[Description("按真实 Word COM 段落范围或当前选区设置段落大纲级次。startParagraphIndex=0 表示当前选区；不要使用 OpenXML paragraphIndex；outlineLevel=0 表示正文，1..9 表示标题级次。")]
	private AiHelper_5 SetWordParagraphOutlineLevel(int startParagraphIndex = 0, int endParagraphIndex = 0, int outlineLevel = 0)
	{
		_G_c__DisplayClass32_0 obj = new _G_c__DisplayClass32_0();
		obj.wkkaUnjGT3 = this;
		obj.value = startParagraphIndex;
		obj.value = endParagraphIndex;
		obj.value = outlineLevel;
		return ExecuteWithLifecycleGuard(() => obj.wkkaUnjGT3.wordService.SetParagraphOutlineLevel(obj.value, obj.value, obj.value));
	}

	[Description("在真实 Word Range 所在位置插入一张新空表，并默认调用一键表格调整套用当前保存的表格格式。placement 默认 replace_empty_paragraph，仅当目标段落为空时替换该空段落；也支持 before/after 插在目标段落前后。rows 1..200，columns 1..63；mode=preview 不写入并返回 previewToken，mode=execute 必须带 previewToken；useTrackChanges 默认 true；adjustAfterInsert 默认 true。")]
	private AiHelper_5 InsertWordTableAtRange(int rangeStart, int rangeEnd, int rows, int columns, string placement = "replace_empty_paragraph", string mode = "preview", string previewToken = "", bool useTrackChanges = true, bool adjustAfterInsert = true)
	{
		_G_c__DisplayClass33_0 obj = new _G_c__DisplayClass33_0();
		obj.SXLajQRDl3 = this;
		obj.value = rangeStart;
		obj.value = rangeEnd;
		obj.value = rows;
		obj.value = columns;
		obj.iSgabAXZd9 = placement;
		obj.cZhaSeWbRr = mode;
		obj.BDKawxvrDO = previewToken;
		obj.flag = useTrackChanges;
		obj.flag = adjustAfterInsert;
		return ExecuteWithLifecycleGuard(() => obj.SXLajQRDl3.wordService.InsertTableAtRange(obj.value, obj.value, obj.value, obj.value, obj.iSgabAXZd9, obj.cZhaSeWbRr, obj.BDKawxvrDO, obj.flag, obj.flag));
	}

	[Description("按 read_word_tables_in_range 在同一 Range 内返回的 localTableIndex 和 rowIndex 插入表格行。position 仅支持 before/after；count 默认 1，最多 20；mode=preview 不写入并返回 previewToken，mode=execute 必须带 previewToken；useTrackChanges 默认 true。")]
	private AiHelper_5 InsertWordTableRowsByModel(int rangeStart, int rangeEnd, int localTableIndex, int anchorRowIndex, string position = "after", int count = 1, string mode = "preview", string previewToken = "", bool useTrackChanges = true, string expectedAnchorText = "")
	{
		_G_c__DisplayClass34_0 obj = new _G_c__DisplayClass34_0();
		obj.wordContextPreviewService = this;
		obj.value = rangeStart;
		obj.value = rangeEnd;
		obj.value = localTableIndex;
		obj.iZGaGQklFb = anchorRowIndex;
		obj.text = position;
		obj.cHWapViHjw = count;
		obj.AhwaOdWUbS = mode;
		obj.TxPaniFSNw = previewToken;
		obj.flag = useTrackChanges;
		obj.text = expectedAnchorText;
		return ExecuteWithLifecycleGuard(() => obj.wordContextPreviewService.wordService.InsertTableRowsByModel(obj.value, obj.value, obj.value, obj.iZGaGQklFb, obj.text, obj.cHWapViHjw, obj.AhwaOdWUbS, obj.TxPaniFSNw, obj.flag, obj.text));
	}

	[Description("按 read_word_tables_in_range 在同一 Range 内返回的模型坐标预览或执行复杂表格写入。cellsJson 为数组：[{\"localTableIndex\":2,\"rowIndex\":4,\"columnIndex\":2,\"expectedOldText\":\"\",\"text\":\"123.45\",\"isHeader\":false}]；mode=preview 不写入并返回 previewToken；mode=execute 必须带 previewToken。不要传全文 tableIndex；表头和正文真实单元格都可写；useTrackChanges 默认 true。allowHeaderEdit 仅为兼容旧调用保留。")]
	private AiHelper_5 FillWordTableCellsByModel(int rangeStart, int rangeEnd, string cellsJson, string mode = "preview", string previewToken = "", bool allowHeaderEdit = true, bool useTrackChanges = true)
	{
		_G_c__DisplayClass35_0 obj = new _G_c__DisplayClass35_0();
		obj.aPjaexnfHZ = this;
		obj.value = rangeStart;
		obj.value = rangeEnd;
		obj.FIdaFYJiPG = cellsJson;
		obj.text = mode;
		obj.text = previewToken;
		obj.xWfaqrOdsQ = allowHeaderEdit;
		obj.flag = useTrackChanges;
		return ExecuteWithLifecycleGuard(() => obj.aPjaexnfHZ.wordService.FillTableCellsByModel(obj.value, obj.value, obj.FIdaFYJiPG, obj.text, obj.text, obj.xWfaqrOdsQ, obj.flag));
	}

	[Description("对当前 Word 选区中的表格运行项目内置表格格式调整功能。请先确保目标表格已被选中，或光标位于目标表格内；只调整格式，不填写数据。")]
	private AiHelper_5 AdjustSelectedWordTablesFormat()
	{
		return ExecuteWithLifecycleGuard(() => wordService.AdjustSelectedTablesFormat());
	}

	[Description("对当前 Word 选区中的段落运行项目内置段落格式调整功能。会跳过表格内段落，并按段落大纲级次套用现有配置；不替换正文。")]
	private AiHelper_5 AdjustSelectedWordParagraphsFormat()
	{
		return ExecuteWithLifecycleGuard(() => wordService.AdjustSelectedParagraphsFormat());
	}

	[Description("读取当前用户保存的表格格式配置，包括字体、字号、行高、单元格边距、边框、对齐、合计/小计规则和宽度模式；不是当前表格实际格式。")]
	private AiHelper_5 ReadWordTableAdjustmentConfig()
	{
		return wordService.ReadTableAdjustmentConfig();
	}

	[Description("读取当前用户保存的段落格式配置。level 为空返回全部级别；可传 一级/二级/三级/四级/五级/其他/表前单位/表后注释/表后段落；不是当前段落实际格式。")]
	private AiHelper_5 ReadWordParagraphAdjustmentConfig(string level = "")
	{
		return wordService.ReadParagraphAdjustmentConfig(level);
	}

	[Description("读取指定全文 tableIndex 或当前选区表格的实际格式。tableIndex=0 表示当前选区内表格；tableIndex>0 表示全文表格序号；不读取保存配置。")]
	private AiHelper_5 InspectWordTableFormat(int tableIndex = 0)
	{
		return wordService.InspectTableFormat(tableIndex);
	}

	[Description("读取指定真实 Word COM paragraphIndex 或当前选区第一段的实际格式。paragraphIndex=0 表示当前选区第一段；不要使用 OpenXML paragraphIndex；不读取保存配置。")]
	private AiHelper_5 InspectWordParagraphFormat(int paragraphIndex = 0)
	{
		return wordService.InspectParagraphFormat(paragraphIndex);
	}

	[Description("预览一次性段落格式修改，不修改文档和用户保存配置。startParagraphIndex=0 表示当前选区；start/end >0 必须是真实 Word COM paragraphIndex，不要使用 OpenXML paragraphIndex；formatJson 仅支持白名单字段。")]
	private AiHelper_5 PreviewWordParagraphFormatChange(int startParagraphIndex = 0, int endParagraphIndex = 0, string formatJson = "{}")
	{
		return wordService.PreviewParagraphFormatChange(startParagraphIndex, endParagraphIndex, formatJson);
	}

	[Description("执行一次性段落格式修改，不修改用户保存配置。必须先调用 preview_word_paragraph_format_change，并传入 expectedChangeCount；段落坐标口径必须与预览一致。")]
	private AiHelper_5 ApplyWordParagraphFormatChange(int expectedChangeCount, int startParagraphIndex = 0, int endParagraphIndex = 0, string formatJson = "{}")
	{
		_G_c__DisplayClass43_0 obj = new _G_c__DisplayClass43_0();
		obj.wordContextPreviewService = this;
		obj.value = startParagraphIndex;
		obj.value = endParagraphIndex;
		obj.WFHakOwMjy = formatJson;
		obj.auTaxcOVp7 = expectedChangeCount;
		return ExecuteWithLifecycleGuard(() => obj.wordContextPreviewService.wordService.ApplyParagraphFormatChange(obj.value, obj.value, obj.WFHakOwMjy, obj.auTaxcOVp7));
	}

	[Description("预览一次性表格格式修改，不修改文档和用户保存配置。tableIndex=0 表示当前选区表格；tableIndex>0 表示全文表格序号，不是 localTableIndex；target 支持 wholeTable/headerRow/bodyRows；formatJson 支持 fontName/fontSize/bold/alignment/verticalAlignment/autoFit/preferredWidthPercent/cellPaddingPt/rowHeightPt/borderStyle/headerRowBold/headerRowShading。")]
	private AiHelper_5 PreviewWordTableFormatChange(int tableIndex = 0, string target = "wholeTable", string formatJson = "{}")
	{
		return wordService.PreviewTableFormatChange(tableIndex, target, formatJson);
	}

	[Description("执行一次性表格格式修改，不修改用户保存配置。必须先调用 preview_word_table_format_change，并传入 expectedChangeCount；tableIndex 口径与预览一致，为全文表格序号或 0 表示当前选区。")]
	private AiHelper_5 ApplyWordTableFormatChange(int expectedChangeCount, int tableIndex = 0, string target = "wholeTable", string formatJson = "{}")
	{
		_G_c__DisplayClass45_0 obj = new _G_c__DisplayClass45_0();
		obj.NFfazEqpm1 = this;
		obj.value = tableIndex;
		obj.text = target;
		obj.text = formatJson;
		obj.value = expectedChangeCount;
		return ExecuteWithLifecycleGuard(() => obj.NFfazEqpm1.wordService.ApplyTableFormatChange(obj.value, obj.text, obj.text, obj.value));
	}

	[Description("按真实 Word Range.Start/End 替换正文，并自动开启后恢复 Word 修订状态。正文精确修改首选此工具。")]
	private AiHelper_5 ReplaceWordRangeWithTrackChanges(int rangeStart, int rangeEnd, string text)
	{
		_G_c__DisplayClass46_0 obj = new _G_c__DisplayClass46_0();
		obj.wordContextPreviewService = this;
		obj.value = rangeStart;
		obj.value = rangeEnd;
		obj.text = text;
		return ExecuteWithLifecycleGuard(() => obj.wordContextPreviewService.wordService.ReplaceRangeWithTrackChanges(obj.value, obj.value, obj.text));
	}

	[Description("替换当前 Word 正文选区，并自动开启后恢复 Word 修订状态。已有 rangeStart/rangeEnd 时优先用 replace_word_range_with_track_changes。")]
	private AiHelper_5 ReplaceWordSelectionWithTrackChanges(string text)
	{
		_G_c__DisplayClass47_0 obj = new _G_c__DisplayClass47_0();
		obj.wordContextPreviewService = this;
		obj.text = text;
		return ExecuteWithLifecycleGuard(() => obj.wordContextPreviewService.wordService.ReplaceSelectionWithTrackChanges(obj.text));
	}

	[Description("执行全文批量替换。直接使用 Word 原生 Find.ReplaceAll，不需要预览；expectedMatchCount/maxMatches 仅为兼容旧调用保留；useTrackChanges 会被强制视为 true；不适合局部精确替换。")]
	private AiHelper_5 BatchReplaceWordTextExecute(string findText, string replaceText, int expectedMatchCount = -1, bool matchCase = false, bool wholeWord = false, bool useTrackChanges = true, int maxMatches = 100)
	{
		_G_c__DisplayClass48_0 obj = new _G_c__DisplayClass48_0();
		obj.wordContextPreviewService = this;
		obj.text = findText;
		obj.text = replaceText;
		obj.WGTqJqIKx2 = expectedMatchCount;
		obj.flag = matchCase;
		obj.flag = wholeWord;
		obj.flag = useTrackChanges;
		obj.HqmqERBfs1 = maxMatches;
		return ExecuteWithLifecycleGuard(() => obj.wordContextPreviewService.wordService.BatchReplaceTextExecute(obj.text, obj.text, obj.WGTqJqIKx2, obj.flag, obj.flag, obj.flag, obj.HqmqERBfs1));
	}

	[Description("导出当前 Word 文档批注到 Excel。")]
	private AiHelper_5 ExportWordComments()
	{
		return wordService.ExportComments();
	}

	private static AiHelper_5 ExecuteWithLifecycleGuard(Func<AiHelper_5> P_0)
	{
		DocumentLifecycleGuard.ClearWordOpenXmlCache();
		try
		{
			return P_0();
		}
		finally
		{
			DocumentLifecycleGuard.ClearWordOpenXmlCache();
		}
	}

	[CompilerGenerated]
	private AiHelper_5 AdjustTablesFormatWrapper()
	{
		return wordService.AdjustSelectedTablesFormat();
	}

	[CompilerGenerated]
	private AiHelper_5 AdjustParagraphsFormatWrapper()
	{
		return wordService.AdjustSelectedParagraphsFormat();
	}
}
