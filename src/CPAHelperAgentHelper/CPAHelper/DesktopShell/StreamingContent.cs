namespace CPAHelper.Agent.DesktopShell;

internal readonly struct StreamingContent(string text, bool isReasoning)
{
	public string Text { get; } = text;

	public bool IsReasoning { get; } = isReasoning;
}
