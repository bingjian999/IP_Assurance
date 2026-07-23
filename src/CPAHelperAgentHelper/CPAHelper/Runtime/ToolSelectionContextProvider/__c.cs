using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class ToolSelectionContextProvider : AIContextProvider
{
	private readonly ToolAggregator _toolAggregator;

	private readonly SessionToolState _sessionToolState;

	internal ToolSelectionContextProvider(ToolAggregator toolAggregator, SessionToolState sessionToolState)
	{
		_toolAggregator = toolAggregator ?? throw new ArgumentNullException("toolAggregator");
		_sessionToolState = sessionToolState ?? throw new ArgumentNullException("sessionToolState");
	}

	protected override ValueTask<AIContext> ProvideAIContextAsync(InvokingContext context, CancellationToken cancellationToken)
	{
		List<AITool> list = new List<AITool>();
		AddUniqueTools(list, new DynamicToolCatalogTools(_toolAggregator, _sessionToolState, context?.Session).CreateTools());
		AddUniqueTools(list, _toolAggregator.ResolveDefaultTools());
		IEnumerable<string> visibleToolNames = _sessionToolState.GetVisibleToolNames(context?.Session);
		AddUniqueTools(list, _toolAggregator.ResolveToolsByName(visibleToolNames));
		return new ValueTask<AIContext>(new AIContext
		{
			Tools = list
		});
	}

	private static void AddUniqueTools(IList<AITool> target, IEnumerable<AITool> source)
	{
		if (source == null)
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>(from tool in target.OfType<AIFunction>()
			select tool.Name, StringComparer.OrdinalIgnoreCase);
		foreach (AITool item in source)
		{
			string text = (item as AIFunction)?.Name;
			if (!string.IsNullOrWhiteSpace(text) && hashSet.Add(text))
			{
				target.Add(item);
			}
		}
	}
}
