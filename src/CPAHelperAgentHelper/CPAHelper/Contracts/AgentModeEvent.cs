using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class AgentModeEvent : SseEvent
{
	public override string Type => "agent-mode";

	[JsonPropertyName("mode")]
	public string Mode { get; set; }
}
