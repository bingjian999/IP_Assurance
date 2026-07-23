using System.Collections.Generic;

namespace CPAHelper.Agent.Abstractions;

public sealed class SubAgentDefinition
{
	public string Name { get; set; }

	public string Description { get; set; }

	public string Instructions { get; set; }

	public IReadOnlyList<string> ToolNames { get; set; } = new List<string>();

	public bool UseParentInstructions { get; set; }

	public IReadOnlyList<string> ToolGroups { get; set; } = new List<string>();

	public IReadOnlyList<string> ExcludedToolGroups { get; set; } = new List<string>();

	public bool EnableFileMemory { get; set; }

	public bool UseRuntimeContext { get; set; } = true;
}
