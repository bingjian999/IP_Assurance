using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class UpdateSessionRequest
{
	[JsonPropertyName("messages")]
	public List<SessionMessagePayload> Messages { get; set; } = new List<SessionMessagePayload>();
}
