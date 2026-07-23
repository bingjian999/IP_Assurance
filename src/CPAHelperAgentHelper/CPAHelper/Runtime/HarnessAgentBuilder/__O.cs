using System;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Logging;

namespace CPAHelper.Agent.Runtime;

internal static class HarnessAgentBuilder
{
	internal static AIAgent Build(IChatClient chatClient, AgentConfig config, HarnessAgentOptions options, ILoggerFactory loggerFactory = null, IServiceProvider serviceProvider = null)
	{
		if (chatClient == null)
		{
			throw new ArgumentNullException("chatClient");
		}
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		AgentChatRuntimeOptions.ResolvedSummaryOptions options2 = AgentChatRuntimeOptions.ResolveSummaryOptions(config?.Summary);
		options.CompactionStrategy = AgentChatRuntimeOptions.BuildCompactionStrategy(chatClient, options2);
		options.DisableCompaction = false;
		return chatClient.AsHarnessAgent(options, loggerFactory, serviceProvider).AsBuilder().Use(ToolInvocationMiddleware.InvokeAsync)
			.Build();
	}
}
