using System;
using System.Collections.Generic;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Logging;

namespace CPAHelper.Agent.Runtime;

internal sealed class AgentFactory
{
	private readonly ChatClientFactory _chatClientFactory;

	private readonly HarnessAgentOptionsFactory _harnessOptionsFactory;

	private readonly ILoggerFactory _loggerFactory;

	private readonly IServiceProvider _serviceProvider;

	internal AgentFactory(ChatClientFactory chatClientFactory, ToolAggregator toolAggregator, SessionToolState sessionToolState, IEnumerable<AIContextProvider> baseContextProviders, IEnumerable<ISubAgentCatalog> subAgentCatalogs, ILoggerFactory loggerFactory = null, IServiceProvider serviceProvider = null)
	{
		_chatClientFactory = chatClientFactory ?? throw new ArgumentNullException("chatClientFactory");
		if (toolAggregator == null)
		{
			throw new ArgumentNullException("toolAggregator");
		}
		if (sessionToolState == null)
		{
			throw new ArgumentNullException("sessionToolState");
		}
		_loggerFactory = loggerFactory;
		_serviceProvider = serviceProvider;
		_harnessOptionsFactory = new HarnessAgentOptionsFactory(toolAggregator, sessionToolState, baseContextProviders ?? Array.Empty<AIContextProvider>(), subAgentCatalogs, CreateChildAgent);
	}

	internal AIAgent CreateAgent(AgentConfig config, string instructions)
	{
		IChatClient chatClient = _chatClientFactory.CreateChatClient();
		HarnessAgentOptions options = BuildHarnessOptions(config, instructions, includeBackgroundAgents: true, CreateHistoryCompactionReducer(chatClient, config, instructions));
		return HarnessAgentBuilder.Build(chatClient, config, options, _loggerFactory, _serviceProvider);
	}

	internal HarnessAgentOptions BuildHarnessOptions(AgentConfig config, string instructions = null, bool includeBackgroundAgents = true, IChatReducer historyReducer = null)
	{
		return _harnessOptionsFactory.Build(config, instructions, includeBackgroundAgents, historyReducer);
	}

	private AIAgent CreateChildAgent(AgentConfig config, SubAgentDefinition definition, string parentInstructions)
	{
		IChatClient chatClient = _chatClientFactory.CreateChatClient();
		HarnessAgentOptions options = _harnessOptionsFactory.BuildBackgroundAgentOptions(config, definition, parentInstructions, CreateHistoryCompactionReducer(chatClient, config, parentInstructions));
		return new ObservableSubAgent(HarnessAgentBuilder.Build(chatClient, config, options, _loggerFactory, _serviceProvider), definition);
	}

	private static IChatReducer CreateHistoryCompactionReducer(IChatClient chatClient, AgentConfig config, string instructions)
	{
		AgentChatRuntimeOptions.ResolvedSummaryOptions resolvedSummaryOptions = AgentChatRuntimeOptions.ResolveSummaryOptions(config?.Summary);
		IProviderBudgetingChatClient providerBudgetingChatClient = chatClient?.GetService(typeof(IProviderBudgetingChatClient)) as IProviderBudgetingChatClient;
		IChatClient chatClient2 = providerBudgetingChatClient?.InnerChatClient ?? chatClient;
		IChatReducer chatReducer = AgentChatRuntimeOptions.BuildHistoryCompactionReducer(chatClient2, resolvedSummaryOptions);
		if (providerBudgetingChatClient?.BudgetEstimator == null)
		{
			return chatReducer;
		}
		return new ProviderBudgetAwareChatReducer(chatReducer, AgentChatRuntimeOptions.BuildProviderBudgetForcedHistoryCompactionReducer(chatClient2, resolvedSummaryOptions), AgentChatRuntimeOptions.BuildProviderBudgetFallbackHistoryCompactionReducer(resolvedSummaryOptions), providerBudgetingChatClient.BudgetEstimator, resolvedSummaryOptions, new ChatOptions
		{
			Instructions = instructions
		});
	}
}
