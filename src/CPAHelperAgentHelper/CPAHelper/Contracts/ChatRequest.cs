using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ChatRequest
{
	[JsonPropertyName("threadId")]
	public string ThreadId { get; set; }

	[JsonPropertyName("message")]
	public string Message { get; set; }

	[JsonPropertyName("displayMessage")]
	public string DisplayMessage { get; set; }

	[JsonPropertyName("selectedSkill")]
	public string SelectedSkill { get; set; }

	[JsonPropertyName("selectedSkills")]
	public List<string> SelectedSkills { get; set; }

	[JsonPropertyName("selectedTools")]
	public List<string> SelectedTools { get; set; }

	[JsonPropertyName("hostContextItems")]
	public List<HostContextItem> HostContextItems { get; set; }

	[JsonPropertyName("agentMode")]
	public string AgentMode { get; set; }

	[JsonPropertyName("skipInterruptedRecovery")]
	public bool SkipInterruptedRecovery { get; set; }
}
