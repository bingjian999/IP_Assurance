using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class SkillInstallSessionResponse
{
	[JsonPropertyName("token")]
	public string Token { get; set; }
}
