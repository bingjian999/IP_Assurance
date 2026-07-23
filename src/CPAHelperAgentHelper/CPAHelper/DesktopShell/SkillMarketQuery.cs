namespace CPAHelper.Agent.DesktopShell;

internal sealed class SkillMarketQuery
{
	public string Search { get; set; }

	public int Page { get; set; } = 1;

	public int PageSize { get; set; } = 12;

	public string Sort { get; set; } = "popular";
}
