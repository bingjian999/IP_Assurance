using System;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class RunOptionsFactory
{
	private readonly IAgentConfigProvider _configProvider;

	private readonly ToolAggregator _toolAggregator;

	private readonly SessionToolState _sessionToolState;

	internal RunOptionsFactory(IAgentConfigProvider configProvider, ToolAggregator toolAggregator, SessionToolState sessionToolState)
	{
		_configProvider = configProvider ?? throw new ArgumentNullException("configProvider");
		_toolAggregator = toolAggregator ?? throw new ArgumentNullException("toolAggregator");
		_sessionToolState = sessionToolState ?? throw new ArgumentNullException("sessionToolState");
	}

	internal ChatClientAgentRunOptions Create(string sessionId, string instructions, string userMessage)
	{
		AgentConfig activeConfig = _configProvider.GetActiveConfig();
		string instructions2 = AgentRuntimeConfiguration.NormalizeInstructions(instructions);
		ChatOptions chatOptions = new ChatOptions();
		AgentChatRuntimeOptions.ApplyProviderDefaults(chatOptions, activeConfig);
		ModelContextDebugLogger.LogRunContext(sessionId, activeConfig, instructions2, userMessage, Array.Empty<AITool>(), _sessionToolState.GetTurnToolNames(sessionId), _toolAggregator.GetToolMetadata());
		return new ChatClientAgentRunOptions(chatOptions);
	}
}
