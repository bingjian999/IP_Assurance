using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Adapters;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopTurnPreparationService
{
	private readonly string _threadId;

	private readonly IAgentConfigProvider _configProvider;

	private readonly IAgentInstructionBuilder _instructionBuilder;

	private readonly IHostContext _hostContext;

	private readonly Func<AgentInstructionContext> _instructionContextFactory;

	private readonly Func<string, CancellationToken, Task<AgentSession>> _createSessionAsync;

	private readonly Action _resetSessionState;

	private readonly Func<AgentSession, IEnumerable<string>, IReadOnlyList<string>> _ensureToolsLoaded;

	public DesktopTurnPreparationService(string threadId, IAgentConfigProvider configProvider, IAgentInstructionBuilder instructionBuilder, IHostContext hostContext, Func<AgentInstructionContext> instructionContextFactory, Func<string, CancellationToken, Task<AgentSession>> createSessionAsync, Action resetSessionState, Func<AgentSession, IEnumerable<string>, IReadOnlyList<string>> ensureToolsLoaded)
	{
		_threadId = threadId ?? string.Empty;
		_configProvider = configProvider ?? throw new ArgumentNullException("configProvider");
		_instructionBuilder = instructionBuilder ?? throw new ArgumentNullException("instructionBuilder");
		_hostContext = hostContext ?? throw new ArgumentNullException("hostContext");
		_instructionContextFactory = instructionContextFactory ?? ((Func<AgentInstructionContext>)(() => new AgentInstructionContext()));
		_createSessionAsync = createSessionAsync ?? throw new ArgumentNullException("createSessionAsync");
		_resetSessionState = resetSessionState ?? throw new ArgumentNullException("resetSessionState");
		_ensureToolsLoaded = ensureToolsLoaded ?? throw new ArgumentNullException("ensureToolsLoaded");
	}

	public async Task<DesktopTurnPreparationResult> PrepareAsync(DesktopTurnPreparationRequest request, CancellationToken cancellationToken)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request");
		}
		if (!_configProvider.IsConfigValid())
		{
			return DesktopTurnPreparationResult.Failed("AI配置无效，请先在设置中配置API参数", "config_invalid");
		}
		string text = _hostContext.EnsureDataSourceReady();
		if (text != null)
		{
			return DesktopTurnPreparationResult.Failed(text, "db_not_connected");
		}
		AgentInstructionContext agentInstructionContext = ((!(_instructionBuilder is IAgentRuntimeContextBuilder)) ? (await Task.Run(() => _instructionContextFactory()).ConfigureAwait(continueOnCapturedContext: false)) : new AgentInstructionContext());
		AgentInstructionContext context = agentInstructionContext;
		string instructions = _instructionBuilder.BuildInstructions(context);
		JsonSessionIndexManager.SessionSummary sessionSummary = JsonSessionIndexManager.CreateSession(_threadId);
		AgentSession agentSession = request.CurrentAgentSession;
		string text2 = request.CurrentSessionInstructions;
		bool resetForEmptyConversation = (sessionSummary?.MessageCount ?? 0) == 0;
		if (resetForEmptyConversation)
		{
			_resetSessionState();
			agentSession = null;
			text2 = null;
		}
		bool refreshedSession = agentSession == null || !string.Equals(text2, instructions, StringComparison.Ordinal);
		if (refreshedSession)
		{
			agentSession = await _createSessionAsync(instructions, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			text2 = instructions;
		}
		IReadOnlyList<string> loadedTools = Array.Empty<string>();
		if (request.SelectedTools != null && request.SelectedTools.Count > 0)
		{
			loadedTools = _ensureToolsLoaded(agentSession, request.SelectedTools) ?? Array.Empty<string>();
		}
		return DesktopTurnPreparationResult.Ready(instructions, agentSession, text2, sessionSummary, loadedTools, resetForEmptyConversation, refreshedSession);
	}
}
