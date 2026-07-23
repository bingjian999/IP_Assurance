using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class HostActionsResponse
{
	[JsonPropertyName("actions")]
	public List<HostActionInfo> Actions { get; set; } = new List<HostActionInfo>();
}
