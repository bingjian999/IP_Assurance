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

	public AiHelper_5 qWG8oA4Yub(bool P_0, bool P_1, int P_2)
	{
		return _batchReplaceService3.GetCurrentWordContext(P_0, P_1, P_2);
	}

	public AiHelper_5 k5f8GPur1X(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		return _batchReplaceService3.PreviewWordDocument(P_0, P_1, P_2, P_3, P_4);
	}

	public AiHelper_5 LoY8Cfe4u0(int P_0)
	{
		return _batchReplaceService3.PreviewWordSelection(P_0);
	}

	public AiHelper_5 QVx8pOa3YT(int P_0, int P_1, int P_2)
	{
		return _batchReplaceService3.ReadWordRange(P_0, P_1, P_2);
	}

	public AiHelper_5 kBo8OaDSuD(int P_0, int P_1, int P_2, int P_3)
	{
		return _batchReplaceService3.ReadWordParagraphs(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 zSB8nLdPMx(int P_0, bool P_1, int P_2)
	{
		return _batchReplaceService3.SetParagraphOutlineOperation(P_0, P_1, P_2);
	}

	public AiHelper_5 DYb87GMvDw(string P_0, int P_1, int P_2, string P_3, int P_4, int P_5, int P_6, int P_7, int P_8)
	{
		return _batchReplaceService3.ParagraphOperation(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8);
	}

	public AiHelper_5 sHV85viBuH(int P_0, int P_1, int P_2, int P_3)
	{
		return _batchReplaceService3.ReadTableOperation(P_0, P_1, P_2, P_3);
	}
}
