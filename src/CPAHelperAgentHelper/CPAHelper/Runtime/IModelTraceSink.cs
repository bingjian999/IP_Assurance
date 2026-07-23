using System;
using System.Collections.Generic;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

public interface IModelTraceSink
{
	ModelTraceRequest BeginRequest(string requestKind, IEnumerable<ChatMessage> messages, ChatOptions options);

	void CompleteRequest(ModelTraceRequest request, object responseSummary);

	void FailRequest(ModelTraceRequest request, Exception exception);
}
