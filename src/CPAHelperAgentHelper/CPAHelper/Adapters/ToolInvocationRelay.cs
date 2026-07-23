using System;
using System.Collections.Generic;
using System.Threading;
using CPAHelper.Agent.Abstractions;

namespace CPAHelper.Agent.Adapters;

public sealed class ToolInvocationRelay : IToolInvocationSink
{
	private static readonly AsyncLocal<IToolInvocationSink> CurrentSink = new AsyncLocal<IToolInvocationSink>();

	public static void SetCurrent(IToolInvocationSink sink)
	{
		CurrentSink.Value = sink;
	}

	public static void ClearCurrent()
	{
		CurrentSink.Value = null;
	}

	public string BeginToolInvocation(string toolName, IReadOnlyDictionary<string, object> args)
	{
		return CurrentSink.Value?.BeginToolInvocation(toolName, args);
	}

	public void CompleteToolInvocation(string invocationId, string toolName, object result, Exception exception)
	{
		CurrentSink.Value?.CompleteToolInvocation(invocationId, toolName, result, exception);
	}
}
