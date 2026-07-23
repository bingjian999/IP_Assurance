using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.Runtime;

public sealed class AgentsFileContextProvider : AIContextProvider
{
	internal const string InstructionsHeader = "## Custom Instructions from AGENTS.md";

	protected override ValueTask<AIContext> ProvideAIContextAsync(InvokingContext context, CancellationToken cancellationToken)
	{
		string text = BuildInstructions(ReadContent());
		if (string.IsNullOrWhiteSpace(text))
		{
			return new ValueTask<AIContext>(new AIContext());
		}
		return new ValueTask<AIContext>(new AIContext
		{
			Instructions = text
		});
	}

	internal static string BuildInstructions(string content)
	{
		if (string.IsNullOrWhiteSpace(content))
		{
			return null;
		}
		return "## Custom Instructions from AGENTS.md" + Environment.NewLine + Environment.NewLine + content.Trim();
	}

	private static string ReadContent()
	{
		try
		{
			return AgentsFileStore.Read().Content;
		}
		catch (Exception)
		{
			return null;
		}
	}
}
