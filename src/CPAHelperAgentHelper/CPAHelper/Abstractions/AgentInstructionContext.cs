using System.Collections.Generic;

namespace CPAHelper.Agent.Abstractions;

public class AgentInstructionContext
{
	public List<string> Companies { get; set; } = new List<string>();

	public List<string> Years { get; set; } = new List<string>();

	public Dictionary<string, string> Extra { get; set; } = new Dictionary<string, string>();
}
