using System;
using System.Collections.Generic;

namespace CPAHelper.Agent.Abstractions;

public interface IToolInvocationSink
{
	string BeginToolInvocation(string toolName, IReadOnlyDictionary<string, object> args);

	void CompleteToolInvocation(string invocationId, string toolName, object result, Exception exception);
}
