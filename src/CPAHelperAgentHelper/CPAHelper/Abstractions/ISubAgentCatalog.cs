using System.Collections.Generic;

namespace CPAHelper.Agent.Abstractions;

public interface ISubAgentCatalog
{
	string ParentInstructions { get; }

	IReadOnlyList<SubAgentDefinition> GetSubAgents();
}
