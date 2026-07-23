using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class HostStatusItem
{
	[JsonPropertyName("key")]
	public string Key { get; set; }

	[JsonPropertyName("label")]
	public string Label { get; set; }

	[JsonPropertyName("value")]
	public string Value { get; set; }
}
