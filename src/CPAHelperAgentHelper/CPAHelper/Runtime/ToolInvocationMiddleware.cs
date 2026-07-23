using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Adapters;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal static class ToolInvocationMiddleware
{
	private sealed class NoopDisposable : IDisposable
	{
		public static readonly NoopDisposable Instance = new NoopDisposable();

		private NoopDisposable()
		{
		}

		public void Dispose()
		{
		}
	}

	private static readonly ToolInvocationRelay Relay = new ToolInvocationRelay();

	internal static async ValueTask<object> InvokeAsync(AIAgent agent, FunctionInvocationContext context, Func<FunctionInvocationContext, CancellationToken, ValueTask<object>> next, CancellationToken cancellationToken)
	{
		if (context == null)
		{
			return await next(context, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		if (context.Function is ApprovalRequiredAIFunction)
		{
			return await next(context, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		string toolName = context.Function?.Name ?? string.Empty;
		if (string.IsNullOrWhiteSpace(toolName))
		{
			return await next(context, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		IReadOnlyDictionary<string, object> readOnlyDictionary = SnapshotArguments(context.Arguments);
		IDisposable subAgentActivityRegistration = RegisterSubAgentActivity(toolName, readOnlyDictionary);
		SubAgentActivityCoordinator.SealLaunchGroup(toolName);
		if (ShouldSuppressVisibleToolInvocation(toolName))
		{
			try
			{
				object result = await next(context, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				InternalToolVisibilityRelay.RecordHiddenToolResult(toolName);
				return result;
			}
			catch
			{
				subAgentActivityRegistration.Dispose();
				throw;
			}
		}
		string invocationId = Relay.BeginToolInvocation(toolName, readOnlyDictionary);
		try
		{
			object result2 = await next(context, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			InternalToolVisibilityRelay.RecordHiddenToolResult(toolName);
			Relay.CompleteToolInvocation(invocationId, toolName, result2, null);
			return result2;
		}
		catch (Exception exception)
		{
			subAgentActivityRegistration.Dispose();
			Relay.CompleteToolInvocation(invocationId, toolName, null, exception);
			throw;
		}
	}

	internal static bool ShouldSuppressVisibleToolInvocation(string toolName)
	{
		return InternalToolVisibilityPolicy.ShouldHideToolCard(toolName);
	}

	private static IReadOnlyDictionary<string, object> SnapshotArguments(AIFunctionArguments arguments)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		if (arguments == null)
		{
			return dictionary;
		}
		foreach (KeyValuePair<string, object> argument in arguments)
		{
			dictionary[argument.Key] = argument.Value;
		}
		return dictionary;
	}

	private static IDisposable RegisterSubAgentActivity(string toolName, IReadOnlyDictionary<string, object> arguments)
	{
		if (!IsBackgroundAgentStartTaskTool(toolName))
		{
			return NoopDisposable.Instance;
		}
		if (!TryGetStringArgument(arguments, "description", out var value))
		{
			TryGetStringArgument(arguments, "title", out value);
		}
		TryGetStringArgument(arguments, "agentName", out var value2);
		return SubAgentActivityCoordinator.RegisterStartRequest(value2, value);
	}

	private static bool IsBackgroundAgentStartTaskTool(string toolName)
	{
		if (!string.Equals(toolName, "background_agents_start_task", StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(toolName, "background_agents_create_task", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static bool TryGetStringArgument(IReadOnlyDictionary<string, object> arguments, string key, out string value)
	{
		value = null;
		if (arguments == null || !arguments.TryGetValue(key, out var value2) || value2 == null)
		{
			return false;
		}
		if (value2 is string text)
		{
			value = text;
			return !string.IsNullOrWhiteSpace(value);
		}
		if (value2 is JsonElement jsonElement)
		{
			if (jsonElement.ValueKind == JsonValueKind.String)
			{
				value = jsonElement.GetString();
				return !string.IsNullOrWhiteSpace(value);
			}
			if (jsonElement.ValueKind != JsonValueKind.Null && jsonElement.ValueKind != JsonValueKind.Undefined)
			{
				value = jsonElement.ToString();
				return !string.IsNullOrWhiteSpace(value);
			}
		}
		value = value2.ToString();
		return !string.IsNullOrWhiteSpace(value);
	}
}
