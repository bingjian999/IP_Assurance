using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SkillUninstallResponse
{
	[JsonPropertyName("success")]
	public bool Success { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("path")]
	public string Path { get; set; }

	[JsonPropertyName("message")]
	public string Message { get; set; }
}
