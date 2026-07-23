using BatchReplaceService3;
using SseStreamInitializer;
using AiHelper_5;

namespace Helper_8;

internal sealed class Helper_8
{
	private readonly BatchReplaceService3 gvCIBFlSht;

	public Helper_8(BatchReplaceService3 P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		gvCIBFlSht = P_0;
	}

	public AiHelper_5 ReadComments(int P_0, bool P_1, int P_2, int P_3)
	{
		return gvCIBFlSht.CommentOperation(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 ReplyComment(string P_0, string P_1, int P_2, string P_3, string P_4)
	{
		return gvCIBFlSht.OhADgENodK(P_0, P_1, P_2, P_3, P_4);
	}

	public AiHelper_5 AddCommentAtSelection(string P_0)
	{
		return gvCIBFlSht.AddCommentOperation(P_0);
	}

	public AiHelper_5 AddCommentAtRange(int P_0, int P_1, string P_2)
	{
		return gvCIBFlSht.qJwDJmPsvM(P_0, P_1, P_2);
	}

	public AiHelper_5 AddCommentAtParagraphRange(int P_0, int P_1, int P_2, string P_3)
	{
		return gvCIBFlSht.AddCommentOperation(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 AddCommentAtTableCell(int P_0, int P_1, int P_2, string P_3)
	{
		return gvCIBFlSht.AddCommentOperation(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 ExportComments()
	{
		return gvCIBFlSht.QJUDMaARAF();
	}
}
