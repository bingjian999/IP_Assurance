using System.Text.Json;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public abstract class SseEvent
{
	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
	};

	[JsonPropertyName("type")]
	public abstract string Type { get; }

	public string ToSseLine()
	{
		return "data: " + JsonSerializer.Serialize(this, GetType(), JsonOptions) + "\n\n";
	}
}
