using BatchReplaceService3;
using SseStreamInitializer;
using AiHelper_5;

namespace Helper_6;

internal sealed class Helper_6
{
	private readonly BatchReplaceService3 _batchReplaceService3;

	public Helper_6(BatchReplaceService3 P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_batchReplaceService3 = P_0;
	}

	public AiHelper_5 FindTextInRange(string P_0, int P_1, string P_2, int P_3)
	{
		return _batchReplaceService3.ParagraphOperation(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 FindText(string P_0, bool P_1, bool P_2, int P_3)
	{
		return _batchReplaceService3.gLSDIXjNAd(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 FindTextWithOptions(string P_0, bool P_1, int P_2)
	{
		return _batchReplaceService3.SearchDocumentOperation(P_0, P_1, P_2);
	}

	public AiHelper_5 FindTableText(string P_0, bool P_1, int P_2)
	{
		return _batchReplaceService3.TableOperation(P_0, P_1, P_2);
	}

	public AiHelper_5 SelectRange(int P_0, int P_1)
	{
		return _batchReplaceService3.SelectWordRangeOperation(P_0, P_1);
	}

	public AiHelper_5 SelectTable(int P_0)
	{
		return _batchReplaceService3.ReplyToCommentOperation(P_0);
	}
}
