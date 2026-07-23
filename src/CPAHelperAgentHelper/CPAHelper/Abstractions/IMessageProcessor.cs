using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CPAHelper.Agent.Abstractions;

public interface IMessageProcessor
{
	Task<MessageProcessorResult> ProcessAsync(string userMessage, CancellationToken cancellationToken, Action<string> onProgress = null, Action<string> onStreamingText = null, Action<string> onReasoningText = null, Action<string> onToolCall = null, Action<string, string, IDictionary<string, object>> onToolCallBegin = null, Action<string, string> onToolCallResult = null);
}
