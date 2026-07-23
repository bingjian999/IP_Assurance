using System;
using System.Threading;

namespace CPAHelper.Agent.Runtime;

internal sealed class ModelTraceContext : IDisposable
{
	private static readonly AsyncLocal<ModelTraceContext> CurrentContext = new AsyncLocal<ModelTraceContext>();

	private readonly ModelTraceContext _previous;

	public string SessionId { get; }

	public string UserMessage { get; }

	public string TurnId { get; }

	public DateTimeOffset StartedAt { get; }

	public static ModelTraceContext Current => CurrentContext.Value;

	private ModelTraceContext(string sessionId, string userMessage)
	{
		_previous = CurrentContext.Value;
		SessionId = sessionId ?? string.Empty;
		UserMessage = userMessage ?? string.Empty;
		TurnId = Guid.NewGuid().ToString("N");
		StartedAt = DateTimeOffset.Now;
		CurrentContext.Value = this;
	}

	public static IDisposable Begin(string sessionId, string userMessage)
	{
		return new ModelTraceContext(sessionId, userMessage);
	}

	public void Dispose()
	{
		CurrentContext.Value = _previous;
	}
}
