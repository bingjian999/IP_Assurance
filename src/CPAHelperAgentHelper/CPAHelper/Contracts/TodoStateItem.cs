using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class TodoStateItem
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("status")]
	public string Status { get; set; }
}
