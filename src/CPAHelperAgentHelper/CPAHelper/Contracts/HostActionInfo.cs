using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class HostActionInfo
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("label")]
	public string Label { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("icon")]
	public string Icon { get; set; }

	[JsonPropertyName("kind")]
	public string Kind { get; set; }
}
