using BatchReplaceService3;
using SseStreamInitializer;
using AiHelper_5;

namespace Helper_13;

internal sealed class Helper_13
{
	private readonly BatchReplaceService3 UtjIJCXMh5;

	public Helper_13(BatchReplaceService3 P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		UtjIJCXMh5 = P_0;
	}

	public AiHelper_5 FillTableCellsByModel(int P_0, int P_1, string P_2, string P_3, string P_4, bool P_5, bool P_6)
	{
		return UtjIJCXMh5.PreviewWordDocument(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	public AiHelper_5 InsertTableRowsByModel(int P_0, int P_1, int P_2, int P_3, string P_4, int P_5, string P_6, string P_7, bool P_8, string P_9)
	{
		return UtjIJCXMh5.AddCommentOperation(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9);
	}

	public AiHelper_5 InsertTableAtRange(int P_0, int P_1, int P_2, int P_3, string P_4, string P_5, string P_6, bool P_7, bool P_8)
	{
		return UtjIJCXMh5.OCnDjfAYoX(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8);
	}
}
