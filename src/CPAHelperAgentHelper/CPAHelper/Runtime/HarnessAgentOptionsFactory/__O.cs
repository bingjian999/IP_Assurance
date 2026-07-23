using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class HarnessAgentOptionsFactory
{
	private readonly ToolAggregator _toolAggregator;

	private readonly SessionToolState _sessionToolState;

	private readonly IReadOnlyList<AIContextProvider> _baseContextProviders;

	private readonly IReadOnlyList<ISubAgentCatalog> _subAgentCatalogs;

	private readonly Func<AgentConfig, SubAgentDefinition, string, AIAgent> _createChildAgent;

	private const string BackgroundAgentSchedulingInstructions = "Background agent task discipline:\n- Treat MAF background task status as authoritative.\n- After starting background tasks, record every returned task id.\n- For user-requested batch analysis, parallel review, or any answer that summarizes multiple background tasks, wait for all relevant tasks to reach a terminal status by repeatedly using background_agents_wait_for_first_completion and/or background_agents_get_all_tasks.\n- For every Completed task, call background_agents_get_task_results before using or summarizing that task's findings.\n- Do not say all SubAgent tasks are complete while any relevant task is Running or while any Completed task result has not been retrieved.\n- If a task is Failed, Lost, cancelled, detached, or still Running, state that explicitly and do not invent its result.";

	internal HarnessAgentOptionsFactory(ToolAggregator toolAggregator, SessionToolState sessionToolState, IEnumerable<AIContextProvider> baseContextProviders, IEnumerable<ISubAgentCatalog> subAgentCatalogs, Func<AgentConfig, SubAgentDefinition, string, AIAgent> createChildAgent)
	{
		_toolAggregator = toolAggregator ?? throw new ArgumentNullException("toolAggregator");
		_sessionToolState = sessionToolState ?? throw new ArgumentNullException("sessionToolState");
		_baseContextProviders = (baseContextProviders ?? Array.Empty<AIContextProvider>()).Where((AIContextProvider provider) => provider != null).ToList();
		_subAgentCatalogs = (subAgentCatalogs ?? Array.Empty<ISubAgentCatalog>()).Where((ISubAgentCatalog catalog) => catalog != null).ToList();
		_createChildAgent = createChildAgent ?? throw new ArgumentNullException("createChildAgent");
	}

	internal HarnessAgentOptions Build(AgentConfig config, string instructions = null, bool includeBackgroundAgents = true, IChatReducer historyReducer = null)
	{
		AgentHarnessOptions harness = config?.Harness ?? new AgentHarnessOptions();
		ChatOptions chatOptions = new ChatOptions();
		AgentChatRuntimeOptions.ApplyProviderDefaults(chatOptions, config);
		if (!string.IsNullOrWhiteSpace(instructions))
		{
			chatOptions.Instructions = instructions;
		}
		HarnessAgentOptions harnessAgentOptions = new HarnessAgentOptions
		{
			Name = "CPA-Helper-Agent",
			Description = "AI Agent Runtime",
			ChatOptions = chatOptions,
			ChatHistoryProvider = CreateChatHistoryProvider(historyReducer),
			AIContextProviders = BuildAdditionalContextProviders(),
			DisableToolAutoApproval = false,
			ToolApprovalAgentOptions = CreateToolApprovalAgentOptions(),
			DisableWebSearch = true,
			DisableOpenTelemetry = false,
			OpenTelemetrySourceName = "CPAHelper.Agent.Harness"
		};
		ConfigureHostOwnedProviders(harnessAgentOptions);
		ConfigureHarnessFileProviders(harnessAgentOptions, harness);
		ConfigureHarnessSkills(harnessAgentOptions);
		if (includeBackgroundAgents)
		{
			ConfigureBackgroundAgents(harnessAgentOptions, config, instructions);
		}
		ConfigureCompletionLoop(harnessAgentOptions);
		return harnessAgentOptions;
	}

	internal static InMemoryChatHistoryProvider CreateChatHistoryProvider(IChatReducer historyReducer = null)
	{
		InMemoryChatHistoryProviderOptions inMemoryChatHistoryProviderOptions = new InMemoryChatHistoryProviderOptions
		{
			StorageInputResponseMessageFilter = AgentSessionSanitizer.SanitizeMessages,
			ProvideOutputMessageFilter = AgentSessionSanitizer.SanitizeMessages
		};
		if (historyReducer != null)
		{
			inMemoryChatHistoryProviderOptions.ChatReducer = historyReducer;
			inMemoryChatHistoryProviderOptions.ReducerTriggerEvent = InMemoryChatHistoryProviderOptions.ChatReducerTriggerEvent.AfterMessageAdded;
		}
		return new InMemoryChatHistoryProvider(inMemoryChatHistoryProviderOptions);
	}

	private static ToolApprovalAgentOptions CreateToolApprovalAgentOptions()
	{
		ToolApprovalAgentOptions toolApprovalAgentOptions = new ToolApprovalAgentOptions();
		toolApprovalAgentOptions.AutoApprovalRules = new Func<FunctionCallContent, ValueTask<bool>>[3]
		{
			FileAccessProvider.AllToolsAutoApprovalRule,
			FileMemoryAllToolsAutoApprovalRule,
			AgentSkillsProvider.ReadOnlyToolsAutoApprovalRule
		};
		return toolApprovalAgentOptions;
	}

	private static ValueTask<bool> FileMemoryAllToolsAutoApprovalRule(FunctionCallContent functionCall)
	{
		string a = functionCall?.Name;
		return new ValueTask<bool>(string.Equals(a, "file_memory_write", StringComparison.Ordinal) || string.Equals(a, "file_memory_read", StringComparison.Ordinal) || string.Equals(a, "file_memory_delete", StringComparison.Ordinal) || string.Equals(a, "file_memory_ls", StringComparison.Ordinal) || string.Equals(a, "file_memory_grep", StringComparison.Ordinal) || string.Equals(a, "file_memory_replace", StringComparison.Ordinal) || string.Equals(a, "file_memory_replace_lines", StringComparison.Ordinal));
	}

	internal HarnessAgentOptions BuildBackgroundAgentOptions(AgentConfig config, SubAgentDefinition definition, IChatReducer historyReducer = null)
	{
		return BuildBackgroundAgentOptions(config, definition, null, historyReducer);
	}

	internal HarnessAgentOptions BuildBackgroundAgentOptions(AgentConfig config, SubAgentDefinition definition, string parentInstructions, IChatReducer historyReducer = null)
	{
		if (definition == null)
		{
			throw new ArgumentNullException("definition");
		}
		IReadOnlyList<string> names = definition.ToolNames ?? Array.Empty<string>();
		IReadOnlyList<string> groups = definition.ToolGroups ?? Array.Empty<string>();
		IReadOnlyList<string> excludedGroups = definition.ExcludedToolGroups ?? Array.Empty<string>();
		List<string> notFound;
		IList<AITool> tools = _toolAggregator.ResolveTools(names, groups, excludedGroups, out notFound);
		List<AIContextProvider> list = (definition.UseRuntimeContext ? _baseContextProviders.OfType<AgentInstructionContextProvider>().Cast<AIContextProvider>().ToList() : new List<AIContextProvider>());
		AgentHarnessOptions harness = config?.Harness ?? new AgentHarnessOptions();
		ChatOptions chatOptions = new ChatOptions
		{
			Instructions = BuildBackgroundAgentInstructions(definition, parentInstructions),
			Tools = tools
		};
		AgentChatRuntimeOptions.ApplyProviderDefaults(chatOptions, config);
		HarnessAgentOptions obj = new HarnessAgentOptions
		{
			Name = definition.Name,
			Description = definition.Description,
			ChatOptions = chatOptions,
			ChatHistoryProvider = CreateChatHistoryProvider(historyReducer),
			AIContextProviders = ((list.Count > 0) ? list : null),
			DisableToolAutoApproval = false,
			DisableWebSearch = true,
			DisableFileAccess = true,
			DisableFileMemory = true,
			DisableAgentSkillsProvider = true,
			DisableTodoProvider = true,
			DisableAgentModeProvider = true,
			DisableOpenTelemetry = false,
			OpenTelemetrySourceName = "CPAHelper.Agent.Harness.Background"
		};
		ConfigureBackgroundFileMemory(obj, harness, definition);
		return obj;
	}

	private List<AIContextProvider> BuildAdditionalContextProviders()
	{
		List<AIContextProvider> list = new List<AIContextProvider>();
		list.AddRange(_baseContextProviders);
		list.Add(new ToolSelectionContextProvider(_toolAggregator, _sessionToolState));
		list.Add(new AgentsFileContextProvider());
		return list;
	}

	private void ConfigureHostOwnedProviders(HarnessAgentOptions options)
	{
		if (_baseContextProviders.OfType<TodoProvider>().Any())
		{
			options.DisableTodoProvider = true;
		}
		if (_baseContextProviders.OfType<AgentModeProvider>().Any())
		{
			options.DisableAgentModeProvider = true;
		}
	}

	private static void ConfigureHarnessFileProviders(HarnessAgentOptions options, AgentHarnessOptions harness)
	{
		if (harness != null && harness.FileAccessEnabled == false)
		{
			options.DisableFileAccess = true;
		}
		else
		{
			options.FileAccessStore = new FileSystemAgentFileStore(HarnessStoragePaths.ResolveHarnessRoot(harness?.FileAccessRoot, "files"));
		}
		if (harness != null && harness.FileMemoryEnabled == false)
		{
			options.DisableFileMemory = true;
		}
		else
		{
			options.FileMemoryStore = new FileSystemAgentFileStore(HarnessStoragePaths.ResolveHarnessRoot(harness?.FileMemoryRoot, "memory"));
		}
	}

	private static void ConfigureBackgroundFileMemory(HarnessAgentOptions options, AgentHarnessOptions harness, SubAgentDefinition definition)
	{
		if (definition == null || !definition.EnableFileMemory || (harness != null && harness.FileMemoryEnabled == false))
		{
			options.DisableFileMemory = true;
			options.FileMemoryStore = null;
		}
		else
		{
			options.DisableFileMemory = false;
			options.FileMemoryStore = new FileSystemAgentFileStore(HarnessStoragePaths.ResolveHarnessRoot(harness?.FileMemoryRoot, "memory"));
		}
	}

	private static void ConfigureHarnessSkills(HarnessAgentOptions options)
	{
		string text = HarnessStoragePaths.ResolveSkillsPath();
		if (string.IsNullOrWhiteSpace(text))
		{
			options.DisableAgentSkillsProvider = true;
			options.AgentSkillsSource = null;
		}
		else
		{
			AgentSkillsSource agentSkillsSource = CreateAgentFileSkillsSource(text);
			options.DisableAgentSkillsProvider = agentSkillsSource == null;
			options.AgentSkillsSource = agentSkillsSource;
		}
	}

	private static AgentSkillsSource CreateAgentFileSkillsSource(string skillsPath)
	{
		return new AgentFileSkillsSource(skillsPath, null, CreateAgentFileSkillsSourceOptions());
	}

	internal static AgentFileSkillsSourceOptions CreateAgentFileSkillsSourceOptions()
	{
		return new AgentFileSkillsSourceOptions
		{
			ResourceFilter = IsAllowedSkillFile,
			ScriptFilter = IsAllowedSkillFile
		};
	}

	internal static bool IsAllowedSkillFile(AgentFileSkillFilterContext context)
	{
		return IsAllowedSkillFilePath(context?.RelativeFilePath);
	}

	internal static bool IsAllowedSkillFilePath(string relativePath)
	{
		if (string.IsNullOrWhiteSpace(relativePath))
		{
			return false;
		}
		string[] array = relativePath.Replace('\\', '/').Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 0)
		{
			return false;
		}
		string text = array[array.Length - 1];
		if (string.Equals(text, ".cpahelper-skill-install.json", StringComparison.OrdinalIgnoreCase) || text.StartsWith(".", StringComparison.Ordinal) || text.EndsWith("~", StringComparison.Ordinal) || text.EndsWith(".tmp", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		foreach (string item in array.Take(array.Length - 1))
		{
			if (item.StartsWith(".", StringComparison.Ordinal) || string.Equals(item, "backup", StringComparison.OrdinalIgnoreCase) || string.Equals(item, "backups", StringComparison.OrdinalIgnoreCase) || string.Equals(item, ".backup", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
		}
		return true;
	}

	private void ConfigureBackgroundAgents(HarnessAgentOptions options, AgentConfig config, string parentInstructions)
	{
		if ((config?.Harness ?? new AgentHarnessOptions()).SubAgentsEnabled == false || _subAgentCatalogs.Count == 0)
		{
			return;
		}
		List<SubAgentDefinition> list = (from @group in (from definition in _subAgentCatalogs.SelectMany((ISubAgentCatalog catalog) => catalog.GetSubAgents() ?? Array.Empty<SubAgentDefinition>())
				where definition != null && !string.IsNullOrWhiteSpace(definition.Name)
				select definition).GroupBy((SubAgentDefinition definition) => definition.Name.Trim(), StringComparer.OrdinalIgnoreCase)
			select @group.First()).ToList();
		if (list.Count != 0)
		{
			List<AIAgent> list2 = (from definition in list
				select _createChildAgent(config, definition, parentInstructions) into agent
				where agent != null
				select agent).ToList();
			if (list2.Count != 0)
			{
				options.BackgroundAgents = list2;
				options.BackgroundAgentsProviderOptions = new BackgroundAgentsProviderOptions
				{
					Instructions = BuildParentInstructions(_subAgentCatalogs)
				};
			}
		}
	}

	private static void ConfigureCompletionLoop(HarnessAgentOptions options)
	{
		List<LoopEvaluator> list = new List<LoopEvaluator>();
		if (options.BackgroundAgents != null && options.BackgroundAgents.Any())
		{
			list.Add(new ObservableLoopEvaluator("BackgroundTaskCompletionLoopEvaluator", new BackgroundTaskCompletionLoopEvaluator()));
		}
		list.Add(new ObservableLoopEvaluator("TodoCompletionLoopEvaluator", new TodoCompletionLoopEvaluator(CreateTodoCompletionLoopEvaluatorOptions())));
		options.LoopEvaluators = list;
		options.LoopAgentOptions = new LoopAgentOptions
		{
			FreshContextPerIteration = false,
			ExcludeOnBehalfOfMessages = true,
			OnBehalfOfAuthorName = "maf-loop"
		};
	}

	internal static TodoCompletionLoopEvaluatorOptions CreateTodoCompletionLoopEvaluatorOptions()
	{
		TodoCompletionLoopEvaluatorOptions todoCompletionLoopEvaluatorOptions = new TodoCompletionLoopEvaluatorOptions();
		todoCompletionLoopEvaluatorOptions.Modes = new string[1] { "execute" };
		return todoCompletionLoopEvaluatorOptions;
	}

	private static string BuildParentInstructions(IEnumerable<ISubAgentCatalog> catalogs)
	{
		List<string> list = (from catalog in catalogs
			select catalog.ParentInstructions into instructions
			where !string.IsNullOrWhiteSpace(instructions)
			select instructions.Trim()).ToList();
		list.Add("Background agent task discipline:\n- Treat MAF background task status as authoritative.\n- After starting background tasks, record every returned task id.\n- For user-requested batch analysis, parallel review, or any answer that summarizes multiple background tasks, wait for all relevant tasks to reach a terminal status by repeatedly using background_agents_wait_for_first_completion and/or background_agents_get_all_tasks.\n- For every Completed task, call background_agents_get_task_results before using or summarizing that task's findings.\n- Do not say all SubAgent tasks are complete while any relevant task is Running or while any Completed task result has not been retrieved.\n- If a task is Failed, Lost, cancelled, detached, or still Running, state that explicitly and do not invent its result.");
		return string.Join(Environment.NewLine + Environment.NewLine, list);
	}

	private static string BuildBackgroundAgentInstructions(SubAgentDefinition definition, string parentInstructions)
	{
		string text = definition?.Instructions?.Trim();
		if (definition == null || !definition.UseParentInstructions)
		{
			return text;
		}
		IEnumerable<string> values = new string[2]
		{
			parentInstructions?.Trim(),
			text
		}.Where((string part) => !string.IsNullOrWhiteSpace(part));
		return string.Join(Environment.NewLine + Environment.NewLine, values);
	}
}
