using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SkillMarketSkillInfo
{
	[JsonPropertyName("slug")]
	public string Slug { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("authorName")]
	public string AuthorName { get; set; }

	[JsonPropertyName("version")]
	public string Version { get; set; }

	[JsonPropertyName("category")]
	public string Category { get; set; }

	[JsonPropertyName("categories")]
	public List<string> Categories { get; set; } = new List<string>();

	[JsonPropertyName("tags")]
	public List<string> Tags { get; set; } = new List<string>();

	[JsonPropertyName("riskNotice")]
	public string RiskNotice { get; set; }

	[JsonPropertyName("skillMd")]
	public string SkillMd { get; set; }

	[JsonPropertyName("archiveUrl")]
	public string ArchiveUrl { get; set; }

	[JsonPropertyName("downloadCount")]
	public int DownloadCount { get; set; }

	[JsonPropertyName("viewCount")]
	public int ViewCount { get; set; }

	[JsonPropertyName("likeCount")]
	public int LikeCount { get; set; }

	[JsonPropertyName("updatedAt")]
	public string UpdatedAt { get; set; }
}
