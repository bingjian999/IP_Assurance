using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class HostContextItem
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("kind")]
	public string Kind { get; set; }

	[JsonPropertyName("label")]
	public string Label { get; set; }

	[JsonPropertyName("displayText")]
	public string DisplayText { get; set; }

	[JsonPropertyName("promptText")]
	public string PromptText { get; set; }

	[JsonPropertyName("metadata")]
	public IDictionary<string, object> Metadata { get; set; }
}
