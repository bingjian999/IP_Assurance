using BatchReplaceService3;
using SseStreamInitializer;
using AiHelper_5;

namespace AiHelper_18;

internal sealed class AiHelper_18
{
	private readonly BatchReplaceService3 _batchReplaceService3;

	public AiHelper_18(BatchReplaceService3 P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_batchReplaceService3 = P_0;
	}

	public AiHelper_5 TxQIuiTrjK(int P_0, string P_1, string P_2, bool P_3)
	{
		return _batchReplaceService3.AqFDKAiaGP(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 mSiIDBBjNV(int P_0, int P_1, int P_2)
	{
		return _batchReplaceService3.SetParagraphOutlineOperation(P_0, P_1, P_2);
	}

	public AiHelper_5 hgrITjuGVa(int P_0, int P_1, string P_2)
	{
		return _batchReplaceService3.ReplaceTextOperation(P_0, P_1, P_2);
	}

	public AiHelper_5 TD9IgEm2tj(string P_0)
	{
		return _batchReplaceService3.ReplaceTextOperation(P_0);
	}

	public AiHelper_5 BTDI8F9Iro(string P_0, string P_1, int P_2, bool P_3, bool P_4, bool P_5, int P_6)
	{
		return _batchReplaceService3.XYsDfGZnQW(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}
}
