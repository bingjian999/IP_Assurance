using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class NonOwningChatClient : IChatClient, IDisposable
{
	[CompilerGenerated]
	private sealed class <GetStreamingResponseAsync>d__3 : IAsyncEnumerable<ChatResponseUpdate>, IAsyncEnumerator<ChatResponseUpdate>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncIteratorMethodBuilder <>t__builder;

		public ManualResetValueTaskSourceCore<bool> <>v__promiseOfValueOrEnd;

		private ChatResponseUpdate <>2__current;

		private bool <>w__disposeMode;

		private CancellationTokenSource <>x__combinedTokens;

		private int <>l__initialThreadId;

		public NonOwningChatClient <>4__this;

		private IEnumerable<ChatMessage> messages;

		public IEnumerable<ChatMessage> <>3__messages;

		private ChatOptions options;

		public ChatOptions <>3__options;

		private CancellationToken cancellationToken;

		public CancellationToken <>3__cancellationToken;

		private ConfiguredCancelableAsyncEnumerable<ChatResponseUpdate>.Enumerator <>7__wrap1;

		private object <>7__wrap2;

		private int <>7__wrap3;

		private ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter <>u__1;

		private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter <>u__2;

		ChatResponseUpdate IAsyncEnumerator<ChatResponseUpdate>.Current
		{
			[DebuggerHidden]
			get
			{
				return <>2__current;
			}
		}

		[DebuggerHidden]
		public <GetStreamingResponseAsync>d__3(int <>1__state)
		{
			<>t__builder = AsyncIteratorMethodBuilder.Create();
			this.<>1__state = <>1__state;
			<>l__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			int num = <>1__state;
			NonOwningChatClient nonOwningChatClient = <>4__this;
			try
			{
				ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (!<>w__disposeMode)
					{
						num = (<>1__state = -1);
						<>7__wrap1 = nonOwningChatClient._inner.GetStreamingResponseAsync(messages, options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAsyncEnumerator();
						<>7__wrap2 = null;
						<>7__wrap3 = 0;
						goto case -4;
					}
					goto end_IL_000e;
				case -4:
				case 0:
					try
					{
						ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter2;
						if (num != -4)
						{
							if (num != 0)
							{
								goto IL_00ca;
							}
							awaiter2 = <>u__1;
							<>u__1 = default(ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter);
							num = (<>1__state = -1);
							goto IL_0135;
						}
						num = (<>1__state = -1);
						if (!<>w__disposeMode)
						{
							goto IL_00ca;
						}
						goto end_IL_0085;
						IL_00ca:
						<>2__current = null;
						awaiter2 = <>7__wrap1.MoveNextAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (<>1__state = 0);
							<>u__1 = awaiter2;
							<GetStreamingResponseAsync>d__3 stateMachine = this;
							<>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_0135;
						IL_0135:
						if (awaiter2.GetResult())
						{
							ChatResponseUpdate current = <>7__wrap1.Current;
							<>2__current = current;
							num = (<>1__state = -4);
							goto IL_02b6;
						}
						end_IL_0085:;
					}
					catch (object obj)
					{
						<>7__wrap2 = obj;
					}
					<>2__current = null;
					awaiter = <>7__wrap1.DisposeAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (<>1__state = 1);
						<>u__2 = awaiter;
						<GetStreamingResponseAsync>d__3 stateMachine = this;
						<>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
						return;
					}
					break;
				case 1:
					awaiter = <>u__2;
					<>u__2 = default(ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter);
					num = (<>1__state = -1);
					break;
				}
				awaiter.GetResult();
				object obj2 = <>7__wrap2;
				if (obj2 != null)
				{
					ExceptionDispatchInfo.Capture((obj2 as Exception) ?? throw obj2).Throw();
				}
				_ = <>7__wrap3;
				if (!<>w__disposeMode)
				{
					<>7__wrap2 = null;
					<>7__wrap1 = default(ConfiguredCancelableAsyncEnumerable<ChatResponseUpdate>.Enumerator);
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				<>1__state = -2;
				<>7__wrap1 = default(ConfiguredCancelableAsyncEnumerable<ChatResponseUpdate>.Enumerator);
				<>7__wrap2 = null;
				if (<>x__combinedTokens != null)
				{
					<>x__combinedTokens.Dispose();
					<>x__combinedTokens = null;
				}
				<>2__current = null;
				<>t__builder.Complete();
				<>v__promiseOfValueOrEnd.SetException(exception);
				return;
			}
			<>1__state = -2;
			<>7__wrap1 = default(ConfiguredCancelableAsyncEnumerable<ChatResponseUpdate>.Enumerator);
			<>7__wrap2 = null;
			if (<>x__combinedTokens != null)
			{
				<>x__combinedTokens.Dispose();
				<>x__combinedTokens = null;
			}
			<>2__current = null;
			<>t__builder.Complete();
			<>v__promiseOfValueOrEnd.SetResult(result: false);
			return;
			IL_02b6:
			<>v__promiseOfValueOrEnd.SetResult(result: true);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}

		[DebuggerHidden]
		IAsyncEnumerator<ChatResponseUpdate> IAsyncEnumerable<ChatResponseUpdate>.GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			<GetStreamingResponseAsync>d__3 <GetStreamingResponseAsync>d__4;
			if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
			{
				<>1__state = -3;
				<>t__builder = AsyncIteratorMethodBuilder.Create();
				<>w__disposeMode = false;
				<GetStreamingResponseAsync>d__4 = this;
			}
			else
			{
				<GetStreamingResponseAsync>d__4 = new <GetStreamingResponseAsync>d__3(-3)
				{
					<>4__this = <>4__this
				};
			}
			<GetStreamingResponseAsync>d__4.messages = <>3__messages;
			<GetStreamingResponseAsync>d__4.options = <>3__options;
			if (<>3__cancellationToken.Equals(default(CancellationToken)))
			{
				<GetStreamingResponseAsync>d__4.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(<>3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				<GetStreamingResponseAsync>d__4.cancellationToken = <>3__cancellationToken;
			}
			else
			{
				<>x__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(<>3__cancellationToken, cancellationToken);
				<GetStreamingResponseAsync>d__4.cancellationToken = <>x__combinedTokens.Token;
			}
			return <GetStreamingResponseAsync>d__4;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<ChatResponseUpdate>.MoveNextAsync()
		{
			if (<>1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			<>v__promiseOfValueOrEnd.Reset();
			<GetStreamingResponseAsync>d__3 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			short version = <>v__promiseOfValueOrEnd.Version;
			if (<>v__promiseOfValueOrEnd.GetStatus(version) == ValueTaskSourceStatus.Succeeded)
			{
				return new ValueTask<bool>(<>v__promiseOfValueOrEnd.GetResult(version));
			}
			return new ValueTask<bool>(this, version);
		}

		[DebuggerHidden]
		bool IValueTaskSource<bool>.GetResult(short token)
		{
			return <>v__promiseOfValueOrEnd.GetResult(token);
		}

		[DebuggerHidden]
		ValueTaskSourceStatus IValueTaskSource<bool>.GetStatus(short token)
		{
			return <>v__promiseOfValueOrEnd.GetStatus(token);
		}

		[DebuggerHidden]
		void IValueTaskSource<bool>.OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			<>v__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
		}

		[DebuggerHidden]
		void IValueTaskSource.GetResult(short token)
		{
			<>v__promiseOfValueOrEnd.GetResult(token);
		}

		[DebuggerHidden]
		ValueTaskSourceStatus IValueTaskSource.GetStatus(short token)
		{
			return <>v__promiseOfValueOrEnd.GetStatus(token);
		}

		[DebuggerHidden]
		void IValueTaskSource.OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			<>v__promiseOfValueOrEnd.OnCompleted(continuation, state, token, flags);
		}

		[DebuggerHidden]
		ValueTask IAsyncDisposable.DisposeAsync()
		{
			if (<>1__state >= -1)
			{
				throw new NotSupportedException();
			}
			if (<>1__state == -2)
			{
				return default(ValueTask);
			}
			<>w__disposeMode = true;
			<>v__promiseOfValueOrEnd.Reset();
			<GetStreamingResponseAsync>d__3 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, <>v__promiseOfValueOrEnd.Version);
		}
	}

	private readonly IChatClient _inner;

	public NonOwningChatClient(IChatClient inner)
	{
		_inner = inner ?? throw new ArgumentNullException("inner");
	}

	public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _inner.GetResponseAsync(messages, options, cancellationToken);
	}

	[AsyncIteratorStateMachine(typeof(<GetStreamingResponseAsync>d__3))]
	public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		return new <GetStreamingResponseAsync>d__3(-2)
		{
			<>4__this = this,
			<>3__messages = messages,
			<>3__options = options,
			<>3__cancellationToken = cancellationToken
		};
	}

	public object GetService(Type serviceType, object serviceKey = null)
	{
		if (serviceType == typeof(NonOwningChatClient) || serviceType == typeof(IChatClient))
		{
			return this;
		}
		return _inner.GetService(serviceType, serviceKey);
	}

	public void Dispose()
	{
	}
}
