using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ArtifactEvent : SseEvent
{
	public override string Type => "artifact";

	[JsonPropertyName("artifactType")]
	public string ArtifactType { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("recordCount")]
	public int? RecordCount { get; set; }
}
