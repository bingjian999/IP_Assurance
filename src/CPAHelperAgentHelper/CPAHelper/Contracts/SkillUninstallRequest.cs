using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SkillUninstallRequest
{
	[JsonPropertyName("name")]
	public string Name { get; set; }
}
