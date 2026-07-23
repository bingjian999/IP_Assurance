using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class PipelineChatReducer : IChatReducer
{
	private readonly IReadOnlyList<IChatReducer> _reducers;

	internal PipelineChatReducer(IEnumerable<IChatReducer> reducers)
	{
		_reducers = (reducers ?? Array.Empty<IChatReducer>()).Where((IChatReducer reducer) => reducer != null).ToList();
	}

	public async Task<IEnumerable<ChatMessage>> ReduceAsync(IEnumerable<ChatMessage> messages, CancellationToken cancellationToken)
	{
		IEnumerable<ChatMessage> enumerable = (messages as IList<ChatMessage>) ?? messages?.ToList() ?? new List<ChatMessage>();
		foreach (IChatReducer reducer in _reducers)
		{
			enumerable = (await reducer.ReduceAsync(enumerable, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)).ToList();
		}
		return enumerable;
	}
}
