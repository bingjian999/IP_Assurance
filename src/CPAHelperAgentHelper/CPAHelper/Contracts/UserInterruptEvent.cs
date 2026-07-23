using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class UserInterruptEvent : SseEvent
{
	public override string Type => "user-interrupt";

	[JsonPropertyName("injectionId")]
	public string InjectionId { get; set; }

	[JsonPropertyName("displayMessage")]
	public string DisplayMessage { get; set; }

	[JsonPropertyName("selectedSkills")]
	public List<string> SelectedSkills { get; set; } = new List<string>();

	[JsonPropertyName("selectedTools")]
	public List<string> SelectedTools { get; set; } = new List<string>();

	[JsonPropertyName("hostContextItems")]
	public List<HostContextItem> HostContextItems { get; set; } = new List<HostContextItem>();

	[JsonPropertyName("status")]
	public string Status { get; set; }
}
