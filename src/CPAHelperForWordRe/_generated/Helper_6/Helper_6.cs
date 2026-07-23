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

	public AiHelper_5 cIk8XmXs2r(string P_0, int P_1, string P_2, int P_3)
	{
		return _batchReplaceService3.ParagraphOperation(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 Ye58Fd0h55(string P_0, bool P_1, bool P_2, int P_3)
	{
		return _batchReplaceService3.gLSDIXjNAd(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 I9K8hx7QFt(string P_0, bool P_1, int P_2)
	{
		return _batchReplaceService3.SearchDocumentOperation(P_0, P_1, P_2);
	}

	public AiHelper_5 H3P8ahHXM5(string P_0, bool P_1, int P_2)
	{
		return _batchReplaceService3.TableOperation(P_0, P_1, P_2);
	}

	public AiHelper_5 sXv8qRO3B1(int P_0, int P_1)
	{
		return _batchReplaceService3.SelectWordRangeOperation(P_0, P_1);
	}

	public AiHelper_5 mfW8PinRZN(int P_0)
	{
		return _batchReplaceService3.ReplyToCommentOperation(P_0);
	}
}
