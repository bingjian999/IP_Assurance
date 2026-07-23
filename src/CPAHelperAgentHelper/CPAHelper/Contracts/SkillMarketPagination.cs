using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SkillMarketPagination
{
	[JsonPropertyName("page")]
	public int Page { get; set; }

	[JsonPropertyName("pageSize")]
	public int PageSize { get; set; }

	[JsonPropertyName("total")]
	public int Total { get; set; }

	[JsonPropertyName("pageCount")]
	public int PageCount { get; set; }
}
