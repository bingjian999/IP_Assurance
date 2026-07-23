using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class ObservableChatReducer : IChatReducer
{
	private sealed class Scope : IDisposable
	{
		private readonly Action _dispose;

		private bool _disposed;

		internal Scope(Action dispose)
		{
			_dispose = dispose;
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				_dispose?.Invoke();
			}
		}
	}

	private static readonly AsyncLocal<Action<string, string>> CurrentObserver = new AsyncLocal<Action<string, string>>();

	private readonly IChatReducer _inner;

	private readonly IChatReducer _fallback;

	private readonly TimeSpan _timeout;

	internal ObservableChatReducer(IChatReducer inner, TimeSpan timeout, IChatReducer fallback = null)
	{
		_inner = inner ?? throw new ArgumentNullException("inner");
		_fallback = fallback;
		_timeout = timeout;
	}

	internal static IDisposable BeginObserve(Action<string, string> observer)
	{
		Action<string, string> previous = CurrentObserver.Value;
		CurrentObserver.Value = observer;
		return new Scope(delegate
		{
			CurrentObserver.Value = previous;
		});
	}

	internal static void PublishStatus(string status, string message)
	{
		CurrentObserver.Value?.Invoke(status, message);
	}

	public async Task<IEnumerable<ChatMessage>> ReduceAsync(IEnumerable<ChatMessage> messages, CancellationToken cancellationToken)
	{
		IList<ChatMessage> materializedMessages = (messages as IList<ChatMessage>) ?? messages?.ToList() ?? new List<ChatMessage>();
		IEnumerable<ChatMessage> reduced;
		using (CancellationTokenSource timeoutCts = CreateTimeoutTokenSource(cancellationToken))
		{
			try
			{
				reduced = await _inner.ReduceAsync(materializedMessages, timeoutCts.Token).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested && timeoutCts.IsCancellationRequested)
			{
				PublishStatus("analyzing", "上下文整理超时，正在继续处理请求...");
				return await ReduceWithFallbackAsync(materializedMessages, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex2)
			{
				_ = ex2;
				PublishStatus("analyzing", "上下文整理失败，正在使用安全压缩继续处理请求...");
				return await ReduceWithFallbackAsync(materializedMessages, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		return reduced;
	}

	private async Task<IEnumerable<ChatMessage>> ReduceWithFallbackAsync(IList<ChatMessage> messages, CancellationToken cancellationToken)
	{
		if (_fallback == null)
		{
			return messages;
		}
		try
		{
			return await _fallback.ReduceAsync(messages, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
		{
			throw;
		}
		catch (Exception)
		{
			return messages;
		}
	}

	private CancellationTokenSource CreateTimeoutTokenSource(CancellationToken cancellationToken)
	{
		CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
		if (_timeout > TimeSpan.Zero)
		{
			cancellationTokenSource.CancelAfter(_timeout);
		}
		return cancellationTokenSource;
	}
}
