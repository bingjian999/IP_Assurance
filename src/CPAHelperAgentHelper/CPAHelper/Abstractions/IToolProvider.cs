using System.Collections.Generic;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Abstractions;

public interface IToolProvider
{
	string ProviderName { get; }

	IList<AITool> GetTools();

	IList<ToolMetadata> GetToolMetadata();
}
