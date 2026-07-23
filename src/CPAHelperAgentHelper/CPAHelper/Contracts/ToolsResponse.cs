using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class ToolsResponse
{
	[JsonPropertyName("tools")]
	public List<ToolInfo> Tools { get; set; } = new List<ToolInfo>();
}
