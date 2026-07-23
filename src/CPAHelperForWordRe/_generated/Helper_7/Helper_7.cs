using BatchReplaceService3;
using SseStreamInitializer;
using AiHelper_5;

namespace Helper_7;

internal sealed class Helper_7
{
	private readonly BatchReplaceService3 _batchReplaceService3;

	public Helper_7(BatchReplaceService3 P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_batchReplaceService3 = P_0;
	}

	public AiHelper_5 GetDocumentInfo(bool P_0, bool P_1, int P_2)
	{
		return _batchReplaceService3.GetCurrentWordContext(P_0, P_1, P_2);
	}

	public AiHelper_5 ReadRangeByPositions(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		return _batchReplaceService3.PreviewWordDocument(P_0, P_1, P_2, P_3, P_4);
	}

	public AiHelper_5 ReadParagraphByIndex(int P_0)
	{
		return _batchReplaceService3.PreviewWordSelection(P_0);
	}

	public AiHelper_5 ReadRange(int P_0, int P_1, int P_2)
	{
		return _batchReplaceService3.ReadWordRange(P_0, P_1, P_2);
	}

	public AiHelper_5 ReadTableRange(int P_0, int P_1, int P_2, int P_3)
	{
		return _batchReplaceService3.ReadWordParagraphs(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 ReadParagraphsWithOptions(int P_0, bool P_1, int P_2)
	{
		return _batchReplaceService3.SetParagraphOutlineOperation(P_0, P_1, P_2);
	}

	public AiHelper_5 ReplaceTextInRange(string P_0, int P_1, int P_2, string P_3, int P_4, int P_5, int P_6, int P_7, int P_8)
	{
		return _batchReplaceService3.ParagraphOperation(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8);
	}

	public AiHelper_5 ReadCellRange(int P_0, int P_1, int P_2, int P_3)
	{
		return _batchReplaceService3.ReadTableOperation(P_0, P_1, P_2, P_3);
	}
}
