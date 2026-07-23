using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SkillsResponse
{
	[JsonPropertyName("path")]
	public string Path { get; set; }

	[JsonPropertyName("error")]
	public string Error { get; set; }

	[JsonPropertyName("skills")]
	public List<SkillInfo> Skills { get; set; } = new List<SkillInfo>();
}
