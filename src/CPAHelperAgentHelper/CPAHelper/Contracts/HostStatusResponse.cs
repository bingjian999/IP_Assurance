using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class HostStatusResponse
{
	[JsonPropertyName("items")]
	public List<HostStatusItem> Items { get; set; } = new List<HostStatusItem>();
}
