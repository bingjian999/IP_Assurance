using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SkillMarketResponse
{
	[JsonPropertyName("skills")]
	public List<SkillMarketSkillInfo> Skills { get; set; } = new List<SkillMarketSkillInfo>();

	[JsonPropertyName("pagination")]
	public SkillMarketPagination Pagination { get; set; } = new SkillMarketPagination();
}
