using BatchReplaceService3;
using SseStreamInitializer;
using AiHelper_5;

namespace Helper_25;

internal sealed class Helper_25
{
	private readonly BatchReplaceService3 _batchReplaceService3;

	public Helper_25(BatchReplaceService3 P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_batchReplaceService3 = P_0;
	}

	public AiHelper_5 NnnIKC5mJ9()
	{
		return _batchReplaceService3.TableOperation();
	}

	public AiHelper_5 P2LIEGm9IC()
	{
		return _batchReplaceService3.FormatParagraphsOperation();
	}

	public AiHelper_5 i3BI2Qgx5s()
	{
		return _batchReplaceService3.SetTableBorders();
	}

	public AiHelper_5 qTYI4wGWbF(string P_0)
	{
		return _batchReplaceService3.SetTableBorders(P_0);
	}

	public AiHelper_5 PVGIjeKTkD(int P_0)
	{
		return _batchReplaceService3.EditTableCellsOperation(P_0);
	}

	public AiHelper_5 KeeIYhlnfb(int P_0)
	{
		return _batchReplaceService3.TableOperation(P_0);
	}

	public AiHelper_5 I9tIZ6k62i(int P_0, int P_1, string P_2)
	{
		return _batchReplaceService3.FormatParagraphsOperation(P_0, P_1, P_2);
	}

	public AiHelper_5 S5gIfEtjgY(int P_0, int P_1, string P_2, int P_3)
	{
		return _batchReplaceService3.FormatParagraphsOperation(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 KGOIMTDmaX(int P_0, string P_1, string P_2)
	{
		return _batchReplaceService3.PreviewTableOperation(P_0, P_1, P_2);
	}

	public AiHelper_5 XGCIbOUGlH(int P_0, string P_1, string P_2, int P_3)
	{
		return _batchReplaceService3.PreviewTableOperation(P_0, P_1, P_2, P_3);
	}
}
