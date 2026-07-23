using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

public sealed class TracingChatClient : IChatClient, IDisposable
{
	[CompilerGenerated]
	private sealed class <GetStreamingResponseAsync>d__4 : IAsyncEnumerable<ChatResponseUpdate>, IAsyncEnumerator<ChatResponseUpdate>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncIteratorMethodBuilder <>t__builder;

		public ManualResetValueTaskSourceCore<bool> <>v__promiseOfValueOrEnd;

		private ChatResponseUpdate <>2__current;

		private bool <>w__disposeMode;

		private CancellationTokenSource <>x__combinedTokens;

		private int <>l__initialThreadId;

		private IEnumerable<ChatMessage> messages;

		public IEnumerable<ChatMessage> <>3__messages;

		public TracingChatClient <>4__this;

		private ChatOptions options;

		public ChatOptions <>3__options;

		private CancellationToken cancellationToken;

		public CancellationToken <>3__cancellationToken;

		private ModelTraceRequest <request>5__2;

		private int <updateCount>5__3;

		private ChatFinishReason? <finishReason>5__4;

		private string <responseId>5__5;

		private string <modelId>5__6;

		private UsageDetails <usage>5__7;

		private bool <completed>5__8;

		private IAsyncEnumerator<ChatResponseUpdate> <enumerator>5__9;

		private object <>7__wrap9;

		private int <>7__wrap10;

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
		public <GetStreamingResponseAsync>d__4(int <>1__state)
		{
			<>t__builder = AsyncIteratorMethodBuilder.Create();
			this.<>1__state = <>1__state;
			<>l__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			int num = <>1__state;
			TracingChatClient tracingChatClient = <>4__this;
			try
			{
				ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (!<>w__disposeMode)
					{
						num = (<>1__state = -1);
						List<ChatMessage> list = (messages ?? Array.Empty<ChatMessage>()).ToList();
						<request>5__2 = tracingChatClient._traceSink.BeginRequest("streaming", list, options);
						<updateCount>5__3 = 0;
						<finishReason>5__4 = null;
						<responseId>5__5 = null;
						<modelId>5__6 = null;
						<usage>5__7 = null;
						<completed>5__8 = false;
						<enumerator>5__9 = tracingChatClient._inner.GetStreamingResponseAsync(list, options, cancellationToken).GetAsyncEnumerator(cancellationToken);
						<>7__wrap9 = null;
						<>7__wrap10 = 0;
						goto case -4;
					}
					goto end_IL_000e;
				case -4:
				case 0:
					try
					{
						if (num != -4)
						{
							goto IL_00e9;
						}
						num = (<>1__state = -1);
						if (!<>w__disposeMode)
						{
							goto IL_00e9;
						}
						goto end_IL_00de;
						IL_0194:
						<updateCount>5__3++;
						ChatResponseUpdate current;
						<finishReason>5__4 = current.FinishReason ?? <finishReason>5__4;
						<responseId>5__5 = <responseId>5__5 ?? current.ResponseId;
						<modelId>5__6 = <modelId>5__6 ?? current.ModelId;
						<usage>5__7 = AggregateUsage(<usage>5__7, current);
						<>2__current = current;
						num = (<>1__state = -4);
						goto IL_0451;
						IL_00e9:
						try
						{
							ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter2;
							if (num != 0)
							{
								<>2__current = null;
								awaiter2 = <enumerator>5__9.MoveNextAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (<>1__state = 0);
									<>u__1 = awaiter2;
									<GetStreamingResponseAsync>d__4 stateMachine = this;
									<>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
									return;
								}
							}
							else
							{
								awaiter2 = <>u__1;
								<>u__1 = default(ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter);
								num = (<>1__state = -1);
							}
							if (awaiter2.GetResult())
							{
								current = <enumerator>5__9.Current;
								goto IL_0194;
							}
						}
						catch (Exception exception)
						{
							tracingChatClient._traceSink.FailRequest(<request>5__2, exception);
							throw;
						}
						<completed>5__8 = true;
						tracingChatClient._traceSink.CompleteRequest(<request>5__2, new
						{
							updateCount = <updateCount>5__3,
							finishReason = <finishReason>5__4?.Value,
							responseId = <responseId>5__5,
							modelId = <modelId>5__6,
							usage = DescribeUsage(<usage>5__7)
						});
						end_IL_00de:;
					}
					catch (object obj)
					{
						<>7__wrap9 = obj;
					}
					_ = <completed>5__8;
					<>2__current = null;
					awaiter = <enumerator>5__9.DisposeAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (<>1__state = 1);
						<>u__2 = awaiter;
						<GetStreamingResponseAsync>d__4 stateMachine = this;
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
				object obj2 = <>7__wrap9;
				if (obj2 != null)
				{
					ExceptionDispatchInfo.Capture((obj2 as Exception) ?? throw obj2).Throw();
				}
				_ = <>7__wrap10;
				if (!<>w__disposeMode)
				{
					<>7__wrap9 = null;
				}
				end_IL_000e:;
			}
			catch (Exception exception2)
			{
				<>1__state = -2;
				<request>5__2 = null;
				<finishReason>5__4 = null;
				<responseId>5__5 = null;
				<modelId>5__6 = null;
				<usage>5__7 = null;
				<enumerator>5__9 = null;
				<>7__wrap9 = null;
				if (<>x__combinedTokens != null)
				{
					<>x__combinedTokens.Dispose();
					<>x__combinedTokens = null;
				}
				<>2__current = null;
				<>t__builder.Complete();
				<>v__promiseOfValueOrEnd.SetException(exception2);
				return;
			}
			<>1__state = -2;
			<request>5__2 = null;
			<finishReason>5__4 = null;
			<responseId>5__5 = null;
			<modelId>5__6 = null;
			<usage>5__7 = null;
			<enumerator>5__9 = null;
			<>7__wrap9 = null;
			if (<>x__combinedTokens != null)
			{
				<>x__combinedTokens.Dispose();
				<>x__combinedTokens = null;
			}
			<>2__current = null;
			<>t__builder.Complete();
			<>v__promiseOfValueOrEnd.SetResult(result: false);
			return;
			IL_0451:
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
			<GetStreamingResponseAsync>d__4 <GetStreamingResponseAsync>d__5;
			if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
			{
				<>1__state = -3;
				<>t__builder = AsyncIteratorMethodBuilder.Create();
				<>w__disposeMode = false;
				<GetStreamingResponseAsync>d__5 = this;
			}
			else
			{
				<GetStreamingResponseAsync>d__5 = new <GetStreamingResponseAsync>d__4(-3)
				{
					<>4__this = <>4__this
				};
			}
			<GetStreamingResponseAsync>d__5.messages = <>3__messages;
			<GetStreamingResponseAsync>d__5.options = <>3__options;
			if (<>3__cancellationToken.Equals(default(CancellationToken)))
			{
				<GetStreamingResponseAsync>d__5.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(<>3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				<GetStreamingResponseAsync>d__5.cancellationToken = <>3__cancellationToken;
			}
			else
			{
				<>x__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(<>3__cancellationToken, cancellationToken);
				<GetStreamingResponseAsync>d__5.cancellationToken = <>x__combinedTokens.Token;
			}
			return <GetStreamingResponseAsync>d__5;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<ChatResponseUpdate>.MoveNextAsync()
		{
			if (<>1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			<>v__promiseOfValueOrEnd.Reset();
			<GetStreamingResponseAsync>d__4 stateMachine = this;
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
			<GetStreamingResponseAsync>d__4 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, <>v__promiseOfValueOrEnd.Version);
		}
	}

	private readonly IChatClient _inner;

	private readonly IModelTraceSink _traceSink;

	public TracingChatClient(IChatClient inner, IModelTraceSink traceSink)
	{
		_inner = inner ?? throw new ArgumentNullException("inner");
		_traceSink = traceSink ?? throw new ArgumentNullException("traceSink");
	}

	public async Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		List<ChatMessage> messages2 = (messages ?? Array.Empty<ChatMessage>()).ToList();
		ModelTraceRequest request = _traceSink.BeginRequest("response", messages2, options);
		try
		{
			ChatResponse chatResponse = await _inner.GetResponseAsync(messages2, options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			_traceSink.CompleteRequest(request, new
			{
				messageCount = (chatResponse?.Messages?.Count).GetValueOrDefault(),
				finishReason = chatResponse?.FinishReason?.Value,
				responseId = chatResponse?.ResponseId,
				modelId = chatResponse?.ModelId,
				usage = DescribeUsage(chatResponse?.Usage)
			});
			return chatResponse;
		}
		catch (Exception exception)
		{
			_traceSink.FailRequest(request, exception);
			throw;
		}
	}

	[AsyncIteratorStateMachine(typeof(<GetStreamingResponseAsync>d__4))]
	public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		return new <GetStreamingResponseAsync>d__4(-2)
		{
			<>4__this = this,
			<>3__messages = messages,
			<>3__options = options,
			<>3__cancellationToken = cancellationToken
		};
	}

	public object GetService(Type serviceType, object serviceKey = null)
	{
		if (serviceType == typeof(TracingChatClient) || serviceType == typeof(IChatClient))
		{
			return this;
		}
		return _inner.GetService(serviceType, serviceKey);
	}

	public void Dispose()
	{
		_inner.Dispose();
	}

	private static UsageDetails AggregateUsage(UsageDetails aggregate, ChatResponseUpdate update)
	{
		if (update?.Contents == null || update.Contents.Count == 0)
		{
			return aggregate;
		}
		foreach (UsageContent item in update.Contents.OfType<UsageContent>())
		{
			if (item?.Details != null)
			{
				if (aggregate == null)
				{
					aggregate = new UsageDetails();
				}
				aggregate.InputTokenCount = Sum(aggregate.InputTokenCount, item.Details.InputTokenCount);
				aggregate.OutputTokenCount = Sum(aggregate.OutputTokenCount, item.Details.OutputTokenCount);
				aggregate.TotalTokenCount = Sum(aggregate.TotalTokenCount, item.Details.TotalTokenCount);
				aggregate.CachedInputTokenCount = Sum(aggregate.CachedInputTokenCount, item.Details.CachedInputTokenCount);
				AddAdditionalCount(aggregate, "prompt_cache_hit_tokens", GetAdditionalCount(item.Details, "prompt_cache_hit_tokens"));
				AddAdditionalCount(aggregate, "prompt_cache_miss_tokens", GetAdditionalCount(item.Details, "prompt_cache_miss_tokens"));
			}
		}
		return aggregate;
	}

	private static object DescribeUsage(UsageDetails usage)
	{
		if (usage == null)
		{
			return null;
		}
		long? prompt_cache_hit_tokens = GetAdditionalCount(usage, "prompt_cache_hit_tokens") ?? usage.CachedInputTokenCount;
		long? prompt_cache_miss_tokens = GetAdditionalCount(usage, "prompt_cache_miss_tokens");
		if (!prompt_cache_miss_tokens.HasValue && usage.InputTokenCount.HasValue && prompt_cache_hit_tokens.HasValue)
		{
			prompt_cache_miss_tokens = Math.Max(0L, usage.InputTokenCount.Value - prompt_cache_hit_tokens.Value);
		}
		return new
		{
			prompt_tokens = usage.InputTokenCount,
			completion_tokens = usage.OutputTokenCount,
			total_tokens = usage.TotalTokenCount,
			cached_input_tokens = usage.CachedInputTokenCount,
			prompt_cache_hit_tokens = prompt_cache_hit_tokens,
			prompt_cache_miss_tokens = prompt_cache_miss_tokens
		};
	}

	private static long? Sum(long? left, long? right)
	{
		if (!left.HasValue)
		{
			return right;
		}
		if (!right.HasValue)
		{
			return left;
		}
		return left.Value + right.Value;
	}

	private static void AddAdditionalCount(UsageDetails usage, string key, long? value)
	{
		if (usage != null && !string.IsNullOrWhiteSpace(key) && value.HasValue)
		{
			if (usage.AdditionalCounts == null)
			{
				usage.AdditionalCounts = new AdditionalPropertiesDictionary<long>();
			}
			if (usage.AdditionalCounts.TryGetValue(key, out var value2))
			{
				usage.AdditionalCounts[key] = value2 + value.Value;
			}
			else
			{
				usage.AdditionalCounts[key] = value.Value;
			}
		}
	}

	private static long? GetAdditionalCount(UsageDetails usage, string key)
	{
		if (usage?.AdditionalCounts == null || string.IsNullOrWhiteSpace(key))
		{
			return null;
		}
		if (!usage.AdditionalCounts.TryGetValue(key, out var value))
		{
			return null;
		}
		return value;
	}
}
