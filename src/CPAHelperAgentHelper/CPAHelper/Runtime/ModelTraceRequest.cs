using System;

namespace CPAHelper.Agent.Runtime;

public sealed class ModelTraceRequest
{
	public string RequestId { get; }

	public DateTimeOffset StartedAt { get; }

	internal ModelTraceRequest(string requestId, DateTimeOffset startedAt)
	{
		RequestId = requestId;
		StartedAt = startedAt;
	}
}
