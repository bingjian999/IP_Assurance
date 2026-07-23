using BatchReplaceService3;
using Helper_13;
using Helper_25;
using AiTargetBinder;
using AiHelper_2;
using Helper_6;
using SseStreamInitializer;
using Helper_8;
using Helper_7;
using AiHelper_18;
using AiHelper_5;

namespace AiHelper_15;

internal sealed class AiHelper_15
{
	private readonly Helper_7 _helper7;

	private readonly Helper_6 _helper_6;

	private readonly Helper_8 _commentHelper;

	private readonly AiHelper_18 _aiHelper_18;

	private readonly Helper_13 _helper_13;

	private readonly Helper_25 _formatAdjustHelper;

	private readonly AiHelper_2 _aiHelper_2;

	public AiHelper_15() : this(null)
	{
		SseStreamInitializer.InitializeRuntime();
	}

	public AiHelper_15(AiTargetBinder P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		BatchReplaceService3 batchReplaceService = new BatchReplaceService3(P_0);
		_helper7 = new Helper_7(batchReplaceService);
		_helper_6 = new Helper_6(batchReplaceService);
		_commentHelper = new Helper_8(batchReplaceService);
		_aiHelper_18 = new AiHelper_18(batchReplaceService);
		_helper_13 = new Helper_13(batchReplaceService);
		_formatAdjustHelper = new Helper_25(batchReplaceService);
		_aiHelper_2 = new AiHelper_2(P_0);
	}

	public AiHelper_5 GetDocumentInfo(bool P_0, bool P_1, int P_2)
	{
		return _helper7.GetDocumentInfo(P_0, P_1, P_2);
	}

	public AiHelper_5 ReadRangeByPositions(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		return _helper7.ReadRangeByPositions(P_0, P_1, P_2, P_3, P_4);
	}

	public AiHelper_5 ReadParagraphByIndex(int P_0)
	{
		return _helper7.ReadParagraphByIndex(P_0);
	}

	public AiHelper_5 ReadRange(int P_0, int P_1, int P_2)
	{
		return _helper7.ReadRange(P_0, P_1, P_2);
	}

	public AiHelper_5 ReadTableRange(int P_0, int P_1, int P_2, int P_3)
	{
		return _helper7.ReadTableRange(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 ReadParagraphsWithOptions(int P_0, bool P_1, int P_2)
	{
		return _helper7.ReadParagraphsWithOptions(P_0, P_1, P_2);
	}

	public AiHelper_5 ReplaceTextInRange(string P_0, int P_1, int P_2, string P_3, int P_4, int P_5, int P_6, int P_7, int P_8)
	{
		return _helper7.ReplaceTextInRange(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8);
	}

	public AiHelper_5 ReadCellRange(int P_0, int P_1, int P_2, int P_3)
	{
		return _helper7.ReadCellRange(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 ReadComments(int P_0, bool P_1, int P_2, int P_3)
	{
		return _commentHelper.ReadComments(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 ReplyComment(string P_0, string P_1, int P_2, string P_3, string P_4)
	{
		return _commentHelper.ReplyComment(P_0, P_1, P_2, P_3, P_4);
	}

	public AiHelper_5 FindTextInRange(string P_0, int P_1, string P_2, int P_3)
	{
		return _helper_6.FindTextInRange(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 FindText(string P_0, bool P_1, bool P_2, int P_3)
	{
		return _helper_6.FindText(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 FindTextWithOptions(string P_0, bool P_1, int P_2)
	{
		return _helper_6.FindTextWithOptions(P_0, P_1, P_2);
	}

	public AiHelper_5 FindTableText(string P_0, bool P_1, int P_2)
	{
		return _helper_6.FindTableText(P_0, P_1, P_2);
	}

	public AiHelper_5 SelectRange(int P_0, int P_1)
	{
		return _helper_6.SelectRange(P_0, P_1);
	}

	public AiHelper_5 SelectTable(int P_0)
	{
		return _helper_6.SelectTable(P_0);
	}

	public AiHelper_5 AddCommentAtSelection(string P_0)
	{
		return _commentHelper.AddCommentAtSelection(P_0);
	}

	public AiHelper_5 AddCommentAtRange(int P_0, int P_1, string P_2)
	{
		return _commentHelper.AddCommentAtRange(P_0, P_1, P_2);
	}

	public AiHelper_5 AddCommentAtParagraphRange(int P_0, int P_1, int P_2, string P_3)
	{
		return _commentHelper.AddCommentAtParagraphRange(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 AddCommentAtTableCell(int P_0, int P_1, int P_2, string P_3)
	{
		return _commentHelper.AddCommentAtTableCell(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 InsertParagraph(int P_0, string P_1, string P_2, bool P_3)
	{
		return _aiHelper_18.InsertParagraph(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 SetParagraphOutlineLevel(int P_0, int P_1, int P_2)
	{
		return _aiHelper_18.SetParagraphOutlineLevel(P_0, P_1, P_2);
	}

	public AiHelper_5 FillTableCellsByModel(int P_0, int P_1, string P_2, string P_3, string P_4, bool P_5, bool P_6)
	{
		return _helper_13.FillTableCellsByModel(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	public AiHelper_5 InsertTableRowsByModel(int P_0, int P_1, int P_2, int P_3, string P_4, int P_5, string P_6, string P_7, bool P_8, string P_9)
	{
		return _helper_13.InsertTableRowsByModel(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9);
	}

	public AiHelper_5 InsertTableAtRange(int P_0, int P_1, int P_2, int P_3, string P_4, string P_5, string P_6, bool P_7, bool P_8)
	{
		return _helper_13.InsertTableAtRange(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8);
	}

	public AiHelper_5 ReplaceRangeWithTrackChanges(int P_0, int P_1, string P_2)
	{
		return _aiHelper_18.ReplaceRangeWithTrackChanges(P_0, P_1, P_2);
	}

	public AiHelper_5 ReplaceSelectionWithTrackChanges(string P_0)
	{
		return _aiHelper_18.ReplaceSelectionWithTrackChanges(P_0);
	}

	public AiHelper_5 BatchReplaceTextExecute(string P_0, string P_1, int P_2, bool P_3, bool P_4, bool P_5, int P_6)
	{
		return _aiHelper_18.BatchReplaceTextExecute(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	public AiHelper_5 ExportComments()
	{
		return _commentHelper.ExportComments();
	}

	public AiHelper_5 AdjustSelectedTablesFormat()
	{
		return _formatAdjustHelper.AdjustSelectedTablesFormat();
	}

	public AiHelper_5 AdjustSelectedParagraphsFormat()
	{
		return _formatAdjustHelper.AdjustSelectedParagraphsFormat();
	}

	public AiHelper_5 ReadTableAdjustmentConfig()
	{
		return _formatAdjustHelper.ReadTableAdjustmentConfig();
	}

	public AiHelper_5 ReadParagraphAdjustmentConfig(string P_0)
	{
		return _formatAdjustHelper.ReadParagraphAdjustmentConfig(P_0);
	}

	public AiHelper_5 InspectTableFormat(int P_0)
	{
		return _formatAdjustHelper.InspectTableFormat(P_0);
	}

	public AiHelper_5 InspectParagraphFormat(int P_0)
	{
		return _formatAdjustHelper.InspectParagraphFormat(P_0);
	}

	public AiHelper_5 PreviewParagraphFormatChange(int P_0, int P_1, string P_2)
	{
		return _formatAdjustHelper.PreviewParagraphFormatChange(P_0, P_1, P_2);
	}

	public AiHelper_5 ApplyParagraphFormatChange(int P_0, int P_1, string P_2, int P_3)
	{
		return _formatAdjustHelper.ApplyParagraphFormatChange(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 PreviewTableFormatChange(int P_0, string P_1, string P_2)
	{
		return _formatAdjustHelper.PreviewTableFormatChange(P_0, P_1, P_2);
	}

	public AiHelper_5 ApplyTableFormatChange(int P_0, string P_1, string P_2, int P_3)
	{
		return _formatAdjustHelper.ApplyTableFormatChange(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 InsertHtmlVisual(string P_0, string P_1, int P_2, int P_3, double P_4, double P_5, string P_6, string P_7)
	{
		return _aiHelper_2.InsertHtmlVisual(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7);
	}
}
