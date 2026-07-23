using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ToolInfo
{
	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("groups")]
	public List<string> Groups { get; set; } = new List<string>();

	[JsonPropertyName("isDefault")]
	public bool IsDefault { get; set; }
}
