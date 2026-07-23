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

internal sealed class ProviderBudgetingChatClient : IChatClient, IDisposable, IProviderBudgetingChatClient
{
	[CompilerGenerated]
	private sealed class <GetStreamingResponseAsync>d__11 : IAsyncEnumerable<ChatResponseUpdate>, IAsyncEnumerator<ChatResponseUpdate>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncIteratorMethodBuilder <>t__builder;

		public ManualResetValueTaskSourceCore<bool> <>v__promiseOfValueOrEnd;

		private ChatResponseUpdate <>2__current;

		private bool <>w__disposeMode;

		private CancellationTokenSource <>x__combinedTokens;

		private int <>l__initialThreadId;

		public ProviderBudgetingChatClient <>4__this;

		private IEnumerable<ChatMessage> messages;

		public IEnumerable<ChatMessage> <>3__messages;

		private ChatOptions options;

		public ChatOptions <>3__options;

		private CancellationToken cancellationToken;

		public CancellationToken <>3__cancellationToken;

		private ConfiguredTaskAwaitable<IReadOnlyList<ChatMessage>>.ConfiguredTaskAwaiter <>u__1;

		private ConfiguredCancelableAsyncEnumerable<ChatResponseUpdate>.Enumerator <>7__wrap1;

		private object <>7__wrap2;

		private int <>7__wrap3;

		private ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter <>u__2;

		private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter <>u__3;

		ChatResponseUpdate IAsyncEnumerator<ChatResponseUpdate>.Current
		{
			[DebuggerHidden]
			get
			{
				return <>2__current;
			}
		}

		[DebuggerHidden]
		public <GetStreamingResponseAsync>d__11(int <>1__state)
		{
			<>t__builder = AsyncIteratorMethodBuilder.Create();
			this.<>1__state = <>1__state;
			<>l__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			int num = <>1__state;
			ProviderBudgetingChatClient providerBudgetingChatClient = <>4__this;
			try
			{
				ConfiguredTaskAwaitable<IReadOnlyList<ChatMessage>>.ConfiguredTaskAwaiter awaiter2;
				ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter;
				IReadOnlyList<ChatMessage> result;
				switch (num)
				{
				default:
					if (!<>w__disposeMode)
					{
						num = (<>1__state = -1);
						<>2__current = null;
						awaiter2 = providerBudgetingChatClient.EnsureWithinBudgetAsync(messages, options, stream: true, cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (<>1__state = 0);
							<>u__1 = awaiter2;
							<GetStreamingResponseAsync>d__11 stateMachine = this;
							<>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_00c5;
					}
					goto end_IL_000e;
				case 0:
					awaiter2 = <>u__1;
					<>u__1 = default(ConfiguredTaskAwaitable<IReadOnlyList<ChatMessage>>.ConfiguredTaskAwaiter);
					num = (<>1__state = -1);
					goto IL_00c5;
				case -4:
				case 1:
					try
					{
						ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter3;
						if (num != -4)
						{
							if (num != 1)
							{
								goto IL_0151;
							}
							awaiter3 = <>u__2;
							<>u__2 = default(ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter);
							num = (<>1__state = -1);
							goto IL_01bc;
						}
						num = (<>1__state = -1);
						if (!<>w__disposeMode)
						{
							goto IL_0151;
						}
						goto end_IL_0109;
						IL_0151:
						<>2__current = null;
						awaiter3 = <>7__wrap1.MoveNextAsync().GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (<>1__state = 1);
							<>u__2 = awaiter3;
							<GetStreamingResponseAsync>d__11 stateMachine = this;
							<>t__builder.AwaitUnsafeOnCompleted(ref awaiter3, ref stateMachine);
							return;
						}
						goto IL_01bc;
						IL_01bc:
						if (awaiter3.GetResult())
						{
							ChatResponseUpdate current = <>7__wrap1.Current;
							<>2__current = current;
							num = (<>1__state = -4);
							goto IL_033d;
						}
						end_IL_0109:;
					}
					catch (object obj)
					{
						<>7__wrap2 = obj;
					}
					<>2__current = null;
					awaiter = <>7__wrap1.DisposeAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (<>1__state = 2);
						<>u__3 = awaiter;
						<GetStreamingResponseAsync>d__11 stateMachine = this;
						<>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
						return;
					}
					break;
				case 2:
					{
						awaiter = <>u__3;
						<>u__3 = default(ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter);
						num = (<>1__state = -1);
						break;
					}
					IL_00c5:
					result = awaiter2.GetResult();
					<>7__wrap1 = providerBudgetingChatClient._inner.GetStreamingResponseAsync(result, options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAsyncEnumerator();
					<>7__wrap2 = null;
					<>7__wrap3 = 0;
					goto case -4;
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
			IL_033d:
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
			<GetStreamingResponseAsync>d__11 <GetStreamingResponseAsync>d__12;
			if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
			{
				<>1__state = -3;
				<>t__builder = AsyncIteratorMethodBuilder.Create();
				<>w__disposeMode = false;
				<GetStreamingResponseAsync>d__12 = this;
			}
			else
			{
				<GetStreamingResponseAsync>d__12 = new <GetStreamingResponseAsync>d__11(-3)
				{
					<>4__this = <>4__this
				};
			}
			<GetStreamingResponseAsync>d__12.messages = <>3__messages;
			<GetStreamingResponseAsync>d__12.options = <>3__options;
			if (<>3__cancellationToken.Equals(default(CancellationToken)))
			{
				<GetStreamingResponseAsync>d__12.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(<>3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				<GetStreamingResponseAsync>d__12.cancellationToken = <>3__cancellationToken;
			}
			else
			{
				<>x__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(<>3__cancellationToken, cancellationToken);
				<GetStreamingResponseAsync>d__12.cancellationToken = <>x__combinedTokens.Token;
			}
			return <GetStreamingResponseAsync>d__12;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<ChatResponseUpdate>.MoveNextAsync()
		{
			if (<>1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			<>v__promiseOfValueOrEnd.Reset();
			<GetStreamingResponseAsync>d__11 stateMachine = this;
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
			<GetStreamingResponseAsync>d__11 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, <>v__promiseOfValueOrEnd.Version);
		}
	}

	private readonly IChatClient _inner;

	private readonly IProviderRequestBudgetEstimator _budgetEstimator;

	private readonly AgentChatRuntimeOptions.ResolvedSummaryOptions _summaryOptions;

	private readonly IChatReducer _forcedReducer;

	private readonly IChatReducer _fallbackReducer;

	public IChatClient InnerChatClient => _inner;

	public IProviderRequestBudgetEstimator BudgetEstimator => _budgetEstimator;

	internal ProviderBudgetingChatClient(IChatClient inner, IProviderRequestBudgetEstimator budgetEstimator, AgentChatRuntimeOptions.ResolvedSummaryOptions summaryOptions, IChatReducer forcedReducer, IChatReducer fallbackReducer)
	{
		_inner = inner ?? throw new ArgumentNullException("inner");
		_budgetEstimator = budgetEstimator ?? throw new ArgumentNullException("budgetEstimator");
		_summaryOptions = summaryOptions ?? throw new ArgumentNullException("summaryOptions");
		_forcedReducer = forcedReducer ?? throw new ArgumentNullException("forcedReducer");
		_fallbackReducer = fallbackReducer ?? throw new ArgumentNullException("fallbackReducer");
	}

	public async Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		IReadOnlyList<ChatMessage> messages2 = await EnsureWithinBudgetAsync(messages, options, stream: false, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		return await _inner.GetResponseAsync(messages2, options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	[AsyncIteratorStateMachine(typeof(<GetStreamingResponseAsync>d__11))]
	public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		return new <GetStreamingResponseAsync>d__11(-2)
		{
			<>4__this = this,
			<>3__messages = messages,
			<>3__options = options,
			<>3__cancellationToken = cancellationToken
		};
	}

	public object GetService(Type serviceType, object serviceKey = null)
	{
		if (serviceType == typeof(ProviderBudgetingChatClient) || serviceType == typeof(IProviderBudgetingChatClient))
		{
			return this;
		}
		if (serviceType == typeof(IProviderRequestBudgetEstimator))
		{
			return _budgetEstimator;
		}
		if (serviceType == typeof(IChatClient))
		{
			return this;
		}
		return _inner.GetService(serviceType, serviceKey);
	}

	public void Dispose()
	{
		_inner.Dispose();
	}

	private async Task<IReadOnlyList<ChatMessage>> EnsureWithinBudgetAsync(IEnumerable<ChatMessage> messages, ChatOptions options, bool stream, CancellationToken cancellationToken)
	{
		IReadOnlyList<ChatMessage> readOnlyList = (messages as IReadOnlyList<ChatMessage>) ?? messages?.ToList() ?? new List<ChatMessage>();
		ProviderRequestBudgetSnapshot providerRequestBudgetSnapshot = _budgetEstimator.Estimate(readOnlyList, options, stream, _summaryOptions);
		ProviderBudgetDiagnostics.Log("preflight-before", providerRequestBudgetSnapshot);
		if (!providerRequestBudgetSnapshot.ExceedsTrigger)
		{
			return readOnlyList;
		}
		ProviderBudgetDiagnostics.Log("preflight-force", providerRequestBudgetSnapshot, "Action=force-compact", forceConsole: true);
		ObservableChatReducer.PublishStatus("compacting", "正在按模型请求大小整理上下文...");
		IReadOnlyList<ChatMessage> readOnlyList2 = await ReduceSafelyAsync(_forcedReducer, readOnlyList, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		ProviderRequestBudgetSnapshot providerRequestBudgetSnapshot2 = _budgetEstimator.Estimate(readOnlyList2, options, stream, _summaryOptions);
		ProviderBudgetDiagnostics.Log("preflight-after-force", providerRequestBudgetSnapshot2, null, providerRequestBudgetSnapshot2.ExceedsHardLimit);
		if (!providerRequestBudgetSnapshot2.ExceedsHardLimit)
		{
			return readOnlyList2;
		}
		ProviderBudgetDiagnostics.Log("preflight-fallback", providerRequestBudgetSnapshot2, "Action=fallback-compact", forceConsole: true);
		IReadOnlyList<ChatMessage> readOnlyList3 = await ReduceSafelyAsync(_fallbackReducer, readOnlyList2, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		ProviderRequestBudgetSnapshot providerRequestBudgetSnapshot3 = _budgetEstimator.Estimate(readOnlyList3, options, stream, _summaryOptions);
		ProviderBudgetDiagnostics.Log("preflight-after-fallback", providerRequestBudgetSnapshot3, null, forceConsole: true);
		if (!providerRequestBudgetSnapshot3.ExceedsHardLimit)
		{
			return readOnlyList3;
		}
		throw new InvalidOperationException("上下文过大，按模型请求大小强制压缩后仍超过安全上限。请开启新会话，或先让助手总结当前复核进度后继续。" + $" EstimatedTokens={providerRequestBudgetSnapshot3.ProviderEstimatedTokens}; HardLimitTokens={providerRequestBudgetSnapshot3.HardLimitTokens}.");
	}

	private static async Task<IReadOnlyList<ChatMessage>> ReduceSafelyAsync(IChatReducer reducer, IReadOnlyList<ChatMessage> messages, CancellationToken cancellationToken)
	{
		List<ChatMessage> list = AgentSessionSanitizer.SanitizeReducedMessagesPreservingLiveToolTail(messages, await reducer.ReduceAsync(messages, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		IReadOnlyList<ChatMessage> result;
		if (list.Count != 0)
		{
			IReadOnlyList<ChatMessage> readOnlyList = list;
			result = readOnlyList;
		}
		else
		{
			result = messages;
		}
		return result;
	}
}
