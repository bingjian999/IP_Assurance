using System;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Adapters;
using Microsoft.Agents.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CPAHelper.Agent.Runtime;

public static class AgentRuntimeServiceExtensions
{
	private const string TodoProviderInstructions = "## Task Tracking\r\n\r\nUse the todo list proactively for work that has meaningful execution progress, not just when the user asks for a plan.\r\n\r\n- Unless the request is simple conversation, clarification-only, or a one-shot tool operation, you must create concise todos with TodoList_Add before doing the work.\r\n- If the task may require planning, multiple visible steps, more than one tool call, host-state changes, generated deliverables, or external execution, TodoList_Add must be called before request_tools or any other execution tool.\r\n- Do not start executing a non-trivial task until the todo list exists.\r\n- Create todos before execution for tasks that modify host state, call external execution tools, or produce multi-step deliverables.\r\n- Create todos when the request combines analysis with action, or has multiple visible steps even if some steps are conceptual.\r\n- While working, use TodoList_GetRemaining when you need to check what is left.\r\n- Mark a todo complete with TodoList_Complete immediately after finishing that step.\r\n- Remove todos with TodoList_Remove if they become irrelevant or blocked.\r\n- Do not create todos only for greetings, simple Q&A, clarification-only replies, one-shot read-only lookups, or trivial one-step operations.\r\n- Keep todo titles short and action-oriented.\r\n- You are usually in execute mode. Work through the todo list autonomously unless the user asks to plan first or approve before acting.";

	public static IServiceCollection AddAgentRuntime(this IServiceCollection services)
	{
		services.AddSingleton<ChatClientFactory>();
		services.AddSingleton<IToolProvider, CalculatorToolProvider>();
		services.AddSingleton<IToolProvider, SkillWriteToolProvider>();
		services.AddSingleton<IToolProvider, GenericFileEditToolProvider>();
		services.AddSingleton<IToolProvider, HarnessShellToolProvider>();
		services.AddSingleton<IToolProvider, WebFetchToolProvider>();
		services.AddSingleton<IToolProvider, McpToolProvider>();
		services.AddSingleton<ToolAggregator>();
		services.AddSingleton<IAgentSessionStore, JsonAgentSessionStore>();
		services.AddSingleton((IServiceProvider _) => new TodoProvider(new TodoProviderOptions
		{
			Instructions = "## Task Tracking\r\n\r\nUse the todo list proactively for work that has meaningful execution progress, not just when the user asks for a plan.\r\n\r\n- Unless the request is simple conversation, clarification-only, or a one-shot tool operation, you must create concise todos with TodoList_Add before doing the work.\r\n- If the task may require planning, multiple visible steps, more than one tool call, host-state changes, generated deliverables, or external execution, TodoList_Add must be called before request_tools or any other execution tool.\r\n- Do not start executing a non-trivial task until the todo list exists.\r\n- Create todos before execution for tasks that modify host state, call external execution tools, or produce multi-step deliverables.\r\n- Create todos when the request combines analysis with action, or has multiple visible steps even if some steps are conceptual.\r\n- While working, use TodoList_GetRemaining when you need to check what is left.\r\n- Mark a todo complete with TodoList_Complete immediately after finishing that step.\r\n- Remove todos with TodoList_Remove if they become irrelevant or blocked.\r\n- Do not create todos only for greetings, simple Q&A, clarification-only replies, one-shot read-only lookups, or trivial one-step operations.\r\n- Keep todo titles short and action-oriented.\r\n- You are usually in execute mode. Work through the todo list autonomously unless the user asks to plan first or approve before acting."
		}));
		services.AddSingleton((IServiceProvider _) => new AgentModeProvider(new AgentModeProviderOptions
		{
			DefaultMode = "execute"
		}));
		services.AddSingleton((Func<IServiceProvider, AIContextProvider>)((IServiceProvider provider) => new AgentInstructionContextProvider(provider.GetService<Func<AgentInstructionContext>>(), provider.GetService<IAgentInstructionBuilder>() as IAgentRuntimeContextBuilder)));
		services.AddSingleton((Func<IServiceProvider, AIContextProvider>)((IServiceProvider provider) => provider.GetRequiredService<TodoProvider>()));
		services.AddSingleton((Func<IServiceProvider, AIContextProvider>)((IServiceProvider provider) => provider.GetRequiredService<AgentModeProvider>()));
		services.AddSingleton((IServiceProvider provider) => new AgentRuntime(provider.GetRequiredService<IAgentConfigProvider>(), provider.GetRequiredService<ToolAggregator>(), provider.GetRequiredService<IAgentSessionStore>(), provider.GetRequiredService<ChatClientFactory>(), provider.GetServices<AIContextProvider>(), provider.GetServices<ISubAgentCatalog>(), provider.GetService<ILoggerFactory>(), provider));
		services.AddSingleton<IApprovalService, ApprovalServiceRelay>();
		return services;
	}
}
