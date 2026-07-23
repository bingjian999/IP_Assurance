using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SkillInstallRequest
{
	[JsonPropertyName("slug")]
	public string Slug { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("version")]
	public string Version { get; set; }

	[JsonPropertyName("archiveUrl")]
	public string ArchiveUrl { get; set; }

	[JsonPropertyName("skillMd")]
	public string SkillMd { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("riskNotice")]
	public string RiskNotice { get; set; }
}
