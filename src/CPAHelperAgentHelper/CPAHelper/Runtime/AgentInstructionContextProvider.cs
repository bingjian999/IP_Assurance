using System;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.Runtime;

public sealed class AgentInstructionContextProvider : AIContextProvider
{
	private readonly Func<AgentInstructionContext> _contextFactory;

	private readonly IAgentRuntimeContextBuilder _contextBuilder;

	public AgentInstructionContextProvider(Func<AgentInstructionContext> contextFactory, IAgentRuntimeContextBuilder contextBuilder)
	{
		_contextFactory = contextFactory;
		_contextBuilder = contextBuilder;
	}

	protected override ValueTask<AIContext> ProvideAIContextAsync(InvokingContext context, CancellationToken cancellationToken)
	{
		if (_contextFactory == null || _contextBuilder == null)
		{
			return new ValueTask<AIContext>(new AIContext());
		}
		string text = _contextBuilder.BuildRuntimeContext(_contextFactory());
		if (string.IsNullOrWhiteSpace(text))
		{
			return new ValueTask<AIContext>(new AIContext());
		}
		return new ValueTask<AIContext>(new AIContext
		{
			Instructions = text
		});
	}
}
