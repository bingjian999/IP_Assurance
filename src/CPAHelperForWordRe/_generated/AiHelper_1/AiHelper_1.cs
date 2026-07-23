using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;

namespace AiHelper_1;

internal sealed class AiHelper_1
{
	[CompilerGenerated]
	private readonly int _paragraphIndex;

	[CompilerGenerated]
	private readonly Paragraph _paragraph;

	public int ParagraphIndex
	{
		[CompilerGenerated]
		get
		{
			return _paragraphIndex;
		}
	}

	public Paragraph Paragraph
	{
		[CompilerGenerated]
		get
		{
			return _paragraph;
		}
	}

	public AiHelper_1(int P_0, Paragraph P_1)
	{
		SseStreamInitializer.InitializeRuntime();
		_paragraphIndex = P_0;
		_paragraph = P_1;
	}
}
