using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class AgentRuntimeRunner
{
	[CompilerGenerated]
	private sealed class <RunStreamingAsync>d__5 : IAsyncEnumerable<AgentResponseUpdate>, IAsyncEnumerator<AgentResponseUpdate>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncIteratorMethodBuilder <>t__builder;

		public ManualResetValueTaskSourceCore<bool> <>v__promiseOfValueOrEnd;

		private AgentResponseUpdate <>2__current;

		private bool <>w__disposeMode;

		private CancellationTokenSource <>x__combinedTokens;

		private int <>l__initialThreadId;

		public AgentRuntimeRunner <>4__this;

		private string instructions;

		public string <>3__instructions;

		private string sessionId;

		public string <>3__sessionId;

		private string userMessage;

		public string <>3__userMessage;

		private AgentSession session;

		public AgentSession <>3__session;

		private CancellationToken cancellationToken;

		public CancellationToken <>3__cancellationToken;

		private Action<string, string> statusObserver;

		public Action<string, string> <>3__statusObserver;

		private Action<MafCompactionMetricsSnapshot> compactionObserver;

		public Action<MafCompactionMetricsSnapshot> <>3__compactionObserver;

		private AIAgent <agent>5__2;

		private ChatClientAgentRunOptions <runOptions>5__3;

		private ConfiguredValueTaskAwaitable<AgentSession>.ConfiguredValueTaskAwaiter <>u__1;

		private IDisposable <>7__wrap3;

		private IDisposable <>7__wrap4;

		private IDisposable <>7__wrap5;

		private ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator <>7__wrap6;

		private object <>7__wrap7;

		private int <>7__wrap8;

		private ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter <>u__2;

		private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter <>u__3;

		AgentResponseUpdate IAsyncEnumerator<AgentResponseUpdate>.Current
		{
			[DebuggerHidden]
			get
			{
				return <>2__current;
			}
		}

		[DebuggerHidden]
		public <RunStreamingAsync>d__5(int <>1__state)
		{
			<>t__builder = AsyncIteratorMethodBuilder.Create();
			this.<>1__state = <>1__state;
			<>l__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			int num = <>1__state;
			AgentRuntimeRunner agentRuntimeRunner = <>4__this;
			try
			{
				ConfiguredValueTaskAwaitable<AgentSession>.ConfiguredValueTaskAwaiter awaiter;
				AgentSession result;
				switch (num)
				{
				default:
					if (!<>w__disposeMode)
					{
						num = (<>1__state = -1);
						<agent>5__2 = agentRuntimeRunner._getOrCreateAgent(instructions, sessionId);
						<runOptions>5__3 = agentRuntimeRunner._runOptionsFactory.Create(sessionId, instructions, userMessage);
						if (session == null)
						{
							<>2__current = null;
							awaiter = <agent>5__2.CreateSessionAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (<>1__state = 0);
								<>u__1 = awaiter;
								<RunStreamingAsync>d__5 stateMachine = this;
								<>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								return;
							}
							goto IL_010c;
						}
						goto IL_011b;
					}
					goto end_IL_000e;
				case 0:
					awaiter = <>u__1;
					<>u__1 = default(ConfiguredValueTaskAwaitable<AgentSession>.ConfiguredValueTaskAwaiter);
					num = (<>1__state = -1);
					goto IL_010c;
				case -4:
				case 1:
				case 2:
					break;
					IL_011b:
					<>7__wrap3 = ModelTraceContext.Begin(sessionId, userMessage);
					break;
					IL_010c:
					result = awaiter.GetResult();
					session = result;
					goto IL_011b;
				}
				try
				{
					if (num != -4 && (uint)(num - 1) > 1u)
					{
						<>7__wrap4 = ObservableChatReducer.BeginObserve(statusObserver);
					}
					try
					{
						if (num != -4 && (uint)(num - 1) > 1u)
						{
							<>7__wrap5 = MafCompactionMetrics.BeginObserve(compactionObserver);
						}
						try
						{
							ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter2;
							if (num != -4 && num != 1)
							{
								if (num == 2)
								{
									awaiter2 = <>u__3;
									<>u__3 = default(ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter);
									num = (<>1__state = -1);
									goto IL_02fc;
								}
								<>7__wrap6 = <agent>5__2.RunStreamingAsync(userMessage, session, <runOptions>5__3, cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAsyncEnumerator();
								<>7__wrap7 = null;
								<>7__wrap8 = 0;
							}
							try
							{
								ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter3;
								if (num != -4)
								{
									if (num != 1)
									{
										goto IL_020c;
									}
									awaiter3 = <>u__2;
									<>u__2 = default(ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter);
									num = (<>1__state = -1);
									goto IL_0277;
								}
								num = (<>1__state = -1);
								if (!<>w__disposeMode)
								{
									goto IL_020c;
								}
								goto end_IL_01c4;
								IL_020c:
								<>2__current = null;
								awaiter3 = <>7__wrap6.MoveNextAsync().GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (<>1__state = 1);
									<>u__2 = awaiter3;
									<RunStreamingAsync>d__5 stateMachine = this;
									<>t__builder.AwaitUnsafeOnCompleted(ref awaiter3, ref stateMachine);
									return;
								}
								goto IL_0277;
								IL_0277:
								if (!awaiter3.GetResult())
								{
									goto end_IL_01c4;
								}
								AgentResponseUpdate current = <>7__wrap6.Current;
								<>2__current = current;
								num = (<>1__state = -4);
								goto end_IL_016d;
								end_IL_01c4:;
							}
							catch (object obj)
							{
								<>7__wrap7 = obj;
							}
							<>2__current = null;
							awaiter2 = <>7__wrap6.DisposeAsync().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (<>1__state = 2);
								<>u__3 = awaiter2;
								<RunStreamingAsync>d__5 stateMachine = this;
								<>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_02fc;
							IL_02fc:
							awaiter2.GetResult();
							object obj2 = <>7__wrap7;
							if (obj2 != null)
							{
								ExceptionDispatchInfo.Capture((obj2 as Exception) ?? throw obj2).Throw();
							}
							_ = <>7__wrap8;
							if (!<>w__disposeMode)
							{
								<>7__wrap7 = null;
								<>7__wrap6 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
							}
							goto IL_0362;
							end_IL_016d:;
						}
						finally
						{
							if (num == -1 && <>7__wrap5 != null)
							{
								<>7__wrap5.Dispose();
							}
						}
						goto end_IL_0150;
						IL_0362:
						if (!<>w__disposeMode)
						{
							<>7__wrap5 = null;
						}
						goto IL_038b;
						end_IL_0150:;
					}
					finally
					{
						if (num == -1 && <>7__wrap4 != null)
						{
							<>7__wrap4.Dispose();
						}
					}
					goto end_IL_0133;
					IL_038b:
					if (!<>w__disposeMode)
					{
						<>7__wrap4 = null;
					}
					goto IL_03b4;
					end_IL_0133:;
				}
				finally
				{
					if (num == -1 && <>7__wrap3 != null)
					{
						<>7__wrap3.Dispose();
					}
				}
				goto IL_04bf;
				IL_03b4:
				if (!<>w__disposeMode)
				{
					<>7__wrap3 = null;
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				<>1__state = -2;
				<agent>5__2 = null;
				<runOptions>5__3 = null;
				<>7__wrap3 = null;
				<>7__wrap4 = null;
				<>7__wrap5 = null;
				<>7__wrap6 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
				<>7__wrap7 = null;
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
			<agent>5__2 = null;
			<runOptions>5__3 = null;
			<>7__wrap3 = null;
			<>7__wrap4 = null;
			<>7__wrap5 = null;
			<>7__wrap6 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
			<>7__wrap7 = null;
			if (<>x__combinedTokens != null)
			{
				<>x__combinedTokens.Dispose();
				<>x__combinedTokens = null;
			}
			<>2__current = null;
			<>t__builder.Complete();
			<>v__promiseOfValueOrEnd.SetResult(result: false);
			return;
			IL_04bf:
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
		IAsyncEnumerator<AgentResponseUpdate> IAsyncEnumerable<AgentResponseUpdate>.GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			<RunStreamingAsync>d__5 <RunStreamingAsync>d__7;
			if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
			{
				<>1__state = -3;
				<>t__builder = AsyncIteratorMethodBuilder.Create();
				<>w__disposeMode = false;
				<RunStreamingAsync>d__7 = this;
			}
			else
			{
				<RunStreamingAsync>d__7 = new <RunStreamingAsync>d__5(-3)
				{
					<>4__this = <>4__this
				};
			}
			<RunStreamingAsync>d__7.userMessage = <>3__userMessage;
			<RunStreamingAsync>d__7.session = <>3__session;
			<RunStreamingAsync>d__7.instructions = <>3__instructions;
			<RunStreamingAsync>d__7.sessionId = <>3__sessionId;
			<RunStreamingAsync>d__7.statusObserver = <>3__statusObserver;
			<RunStreamingAsync>d__7.compactionObserver = <>3__compactionObserver;
			if (<>3__cancellationToken.Equals(default(CancellationToken)))
			{
				<RunStreamingAsync>d__7.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(<>3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				<RunStreamingAsync>d__7.cancellationToken = <>3__cancellationToken;
			}
			else
			{
				<>x__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(<>3__cancellationToken, cancellationToken);
				<RunStreamingAsync>d__7.cancellationToken = <>x__combinedTokens.Token;
			}
			return <RunStreamingAsync>d__7;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<AgentResponseUpdate>.MoveNextAsync()
		{
			if (<>1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			<>v__promiseOfValueOrEnd.Reset();
			<RunStreamingAsync>d__5 stateMachine = this;
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
			<RunStreamingAsync>d__5 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, <>v__promiseOfValueOrEnd.Version);
		}
	}

	[CompilerGenerated]
	private sealed class <RunStreamingAsync>d__6 : IAsyncEnumerable<AgentResponseUpdate>, IAsyncEnumerator<AgentResponseUpdate>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncIteratorMethodBuilder <>t__builder;

		public ManualResetValueTaskSourceCore<bool> <>v__promiseOfValueOrEnd;

		private AgentResponseUpdate <>2__current;

		private bool <>w__disposeMode;

		private CancellationTokenSource <>x__combinedTokens;

		private int <>l__initialThreadId;

		private IEnumerable<ChatMessage> messages;

		public IEnumerable<ChatMessage> <>3__messages;

		public AgentRuntimeRunner <>4__this;

		private string instructions;

		public string <>3__instructions;

		private string sessionId;

		public string <>3__sessionId;

		private AgentSession session;

		public AgentSession <>3__session;

		private CancellationToken cancellationToken;

		public CancellationToken <>3__cancellationToken;

		private Action<string, string> statusObserver;

		public Action<string, string> <>3__statusObserver;

		private Action<MafCompactionMetricsSnapshot> compactionObserver;

		public Action<MafCompactionMetricsSnapshot> <>3__compactionObserver;

		private List<ChatMessage> <messageList>5__2;

		private string <userMessage>5__3;

		private AIAgent <agent>5__4;

		private ChatClientAgentRunOptions <runOptions>5__5;

		private ConfiguredValueTaskAwaitable<AgentSession>.ConfiguredValueTaskAwaiter <>u__1;

		private IDisposable <>7__wrap5;

		private IDisposable <>7__wrap6;

		private IDisposable <>7__wrap7;

		private ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator <>7__wrap8;

		private object <>7__wrap9;

		private int <>7__wrap10;

		private ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter <>u__2;

		private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter <>u__3;

		AgentResponseUpdate IAsyncEnumerator<AgentResponseUpdate>.Current
		{
			[DebuggerHidden]
			get
			{
				return <>2__current;
			}
		}

		[DebuggerHidden]
		public <RunStreamingAsync>d__6(int <>1__state)
		{
			<>t__builder = AsyncIteratorMethodBuilder.Create();
			this.<>1__state = <>1__state;
			<>l__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			int num = <>1__state;
			AgentRuntimeRunner agentRuntimeRunner = <>4__this;
			try
			{
				ConfiguredValueTaskAwaitable<AgentSession>.ConfiguredValueTaskAwaiter awaiter;
				AgentSession result;
				switch (num)
				{
				default:
					if (!<>w__disposeMode)
					{
						num = (<>1__state = -1);
						<messageList>5__2 = messages?.ToList() ?? new List<ChatMessage>();
						<userMessage>5__3 = ExtractUserText(<messageList>5__2);
						<agent>5__4 = agentRuntimeRunner._getOrCreateAgent(instructions, sessionId);
						<runOptions>5__5 = agentRuntimeRunner._runOptionsFactory.Create(sessionId, instructions, <userMessage>5__3);
						if (session == null)
						{
							<>2__current = null;
							awaiter = <agent>5__4.CreateSessionAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (<>1__state = 0);
								<>u__1 = awaiter;
								<RunStreamingAsync>d__6 stateMachine = this;
								<>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
								return;
							}
							goto IL_013e;
						}
						goto IL_014d;
					}
					goto end_IL_000e;
				case 0:
					awaiter = <>u__1;
					<>u__1 = default(ConfiguredValueTaskAwaitable<AgentSession>.ConfiguredValueTaskAwaiter);
					num = (<>1__state = -1);
					goto IL_013e;
				case -4:
				case 1:
				case 2:
					break;
					IL_013e:
					result = awaiter.GetResult();
					session = result;
					goto IL_014d;
					IL_014d:
					<>7__wrap5 = ModelTraceContext.Begin(sessionId, <userMessage>5__3);
					break;
				}
				try
				{
					if (num != -4 && (uint)(num - 1) > 1u)
					{
						<>7__wrap6 = ObservableChatReducer.BeginObserve(statusObserver);
					}
					try
					{
						if (num != -4 && (uint)(num - 1) > 1u)
						{
							<>7__wrap7 = MafCompactionMetrics.BeginObserve(compactionObserver);
						}
						try
						{
							ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter2;
							if (num != -4 && num != 1)
							{
								if (num == 2)
								{
									awaiter2 = <>u__3;
									<>u__3 = default(ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter);
									num = (<>1__state = -1);
									goto IL_032e;
								}
								<>7__wrap8 = <agent>5__4.RunStreamingAsync(<messageList>5__2, session, <runOptions>5__5, cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAsyncEnumerator();
								<>7__wrap9 = null;
								<>7__wrap10 = 0;
							}
							try
							{
								ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter awaiter3;
								if (num != -4)
								{
									if (num != 1)
									{
										goto IL_023e;
									}
									awaiter3 = <>u__2;
									<>u__2 = default(ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter);
									num = (<>1__state = -1);
									goto IL_02a9;
								}
								num = (<>1__state = -1);
								if (!<>w__disposeMode)
								{
									goto IL_023e;
								}
								goto end_IL_01f6;
								IL_023e:
								<>2__current = null;
								awaiter3 = <>7__wrap8.MoveNextAsync().GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (<>1__state = 1);
									<>u__2 = awaiter3;
									<RunStreamingAsync>d__6 stateMachine = this;
									<>t__builder.AwaitUnsafeOnCompleted(ref awaiter3, ref stateMachine);
									return;
								}
								goto IL_02a9;
								IL_02a9:
								if (!awaiter3.GetResult())
								{
									goto end_IL_01f6;
								}
								AgentResponseUpdate current = <>7__wrap8.Current;
								<>2__current = current;
								num = (<>1__state = -4);
								goto end_IL_019f;
								end_IL_01f6:;
							}
							catch (object obj)
							{
								<>7__wrap9 = obj;
							}
							<>2__current = null;
							awaiter2 = <>7__wrap8.DisposeAsync().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (<>1__state = 2);
								<>u__3 = awaiter2;
								<RunStreamingAsync>d__6 stateMachine = this;
								<>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_032e;
							IL_032e:
							awaiter2.GetResult();
							object obj2 = <>7__wrap9;
							if (obj2 != null)
							{
								ExceptionDispatchInfo.Capture((obj2 as Exception) ?? throw obj2).Throw();
							}
							_ = <>7__wrap10;
							if (!<>w__disposeMode)
							{
								<>7__wrap9 = null;
								<>7__wrap8 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
							}
							goto IL_0394;
							end_IL_019f:;
						}
						finally
						{
							if (num == -1 && <>7__wrap7 != null)
							{
								<>7__wrap7.Dispose();
							}
						}
						goto end_IL_0182;
						IL_0394:
						if (!<>w__disposeMode)
						{
							<>7__wrap7 = null;
						}
						goto IL_03bd;
						end_IL_0182:;
					}
					finally
					{
						if (num == -1 && <>7__wrap6 != null)
						{
							<>7__wrap6.Dispose();
						}
					}
					goto end_IL_0165;
					IL_03bd:
					if (!<>w__disposeMode)
					{
						<>7__wrap6 = null;
					}
					goto IL_03e6;
					end_IL_0165:;
				}
				finally
				{
					if (num == -1 && <>7__wrap5 != null)
					{
						<>7__wrap5.Dispose();
					}
				}
				goto IL_0510;
				IL_03e6:
				if (!<>w__disposeMode)
				{
					<>7__wrap5 = null;
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				<>1__state = -2;
				<messageList>5__2 = null;
				<userMessage>5__3 = null;
				<agent>5__4 = null;
				<runOptions>5__5 = null;
				<>7__wrap5 = null;
				<>7__wrap6 = null;
				<>7__wrap7 = null;
				<>7__wrap8 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
				<>7__wrap9 = null;
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
			<messageList>5__2 = null;
			<userMessage>5__3 = null;
			<agent>5__4 = null;
			<runOptions>5__5 = null;
			<>7__wrap5 = null;
			<>7__wrap6 = null;
			<>7__wrap7 = null;
			<>7__wrap8 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
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
			IL_0510:
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
		IAsyncEnumerator<AgentResponseUpdate> IAsyncEnumerable<AgentResponseUpdate>.GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			<RunStreamingAsync>d__6 <RunStreamingAsync>d__7;
			if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
			{
				<>1__state = -3;
				<>t__builder = AsyncIteratorMethodBuilder.Create();
				<>w__disposeMode = false;
				<RunStreamingAsync>d__7 = this;
			}
			else
			{
				<RunStreamingAsync>d__7 = new <RunStreamingAsync>d__6(-3)
				{
					<>4__this = <>4__this
				};
			}
			<RunStreamingAsync>d__7.messages = <>3__messages;
			<RunStreamingAsync>d__7.session = <>3__session;
			<RunStreamingAsync>d__7.instructions = <>3__instructions;
			<RunStreamingAsync>d__7.sessionId = <>3__sessionId;
			<RunStreamingAsync>d__7.statusObserver = <>3__statusObserver;
			<RunStreamingAsync>d__7.compactionObserver = <>3__compactionObserver;
			if (<>3__cancellationToken.Equals(default(CancellationToken)))
			{
				<RunStreamingAsync>d__7.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(<>3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				<RunStreamingAsync>d__7.cancellationToken = <>3__cancellationToken;
			}
			else
			{
				<>x__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(<>3__cancellationToken, cancellationToken);
				<RunStreamingAsync>d__7.cancellationToken = <>x__combinedTokens.Token;
			}
			return <RunStreamingAsync>d__7;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<AgentResponseUpdate>.MoveNextAsync()
		{
			if (<>1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			<>v__promiseOfValueOrEnd.Reset();
			<RunStreamingAsync>d__6 stateMachine = this;
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
			<RunStreamingAsync>d__6 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, <>v__promiseOfValueOrEnd.Version);
		}
	}

	private readonly Func<string, string, AIAgent> _getOrCreateAgent;

	private readonly RunOptionsFactory _runOptionsFactory;

	private readonly SessionToolState _sessionToolState;

	internal AgentRuntimeRunner(Func<string, string, AIAgent> getOrCreateAgent, RunOptionsFactory runOptionsFactory, SessionToolState sessionToolState)
	{
		_getOrCreateAgent = getOrCreateAgent ?? throw new ArgumentNullException("getOrCreateAgent");
		_runOptionsFactory = runOptionsFactory ?? throw new ArgumentNullException("runOptionsFactory");
		_sessionToolState = sessionToolState ?? throw new ArgumentNullException("sessionToolState");
	}

	internal async Task<AgentResponse> RunAsync(string userMessage, AgentSession session = null, string instructions = null, string sessionId = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		AIAgent agent = _getOrCreateAgent(instructions, sessionId);
		ChatClientAgentRunOptions runOptions = _runOptionsFactory.Create(sessionId, instructions, userMessage);
		if (session == null)
		{
			session = await agent.CreateSessionAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		using (ModelTraceContext.Begin(sessionId, userMessage))
		{
			return await agent.RunAsync(userMessage, session, runOptions, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[AsyncIteratorStateMachine(typeof(<RunStreamingAsync>d__5))]
	internal IAsyncEnumerable<AgentResponseUpdate> RunStreamingAsync(string userMessage, AgentSession session = null, string instructions = null, string sessionId = null, Action<string, string> statusObserver = null, Action<MafCompactionMetricsSnapshot> compactionObserver = null, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		return new <RunStreamingAsync>d__5(-2)
		{
			<>4__this = this,
			<>3__userMessage = userMessage,
			<>3__session = session,
			<>3__instructions = instructions,
			<>3__sessionId = sessionId,
			<>3__statusObserver = statusObserver,
			<>3__compactionObserver = compactionObserver,
			<>3__cancellationToken = cancellationToken
		};
	}

	[AsyncIteratorStateMachine(typeof(<RunStreamingAsync>d__6))]
	internal IAsyncEnumerable<AgentResponseUpdate> RunStreamingAsync(IEnumerable<ChatMessage> messages, AgentSession session = null, string instructions = null, string sessionId = null, Action<string, string> statusObserver = null, Action<MafCompactionMetricsSnapshot> compactionObserver = null, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		return new <RunStreamingAsync>d__6(-2)
		{
			<>4__this = this,
			<>3__messages = messages,
			<>3__session = session,
			<>3__instructions = instructions,
			<>3__sessionId = sessionId,
			<>3__statusObserver = statusObserver,
			<>3__compactionObserver = compactionObserver,
			<>3__cancellationToken = cancellationToken
		};
	}

	internal void EndTurn(AgentSession session, string sessionId)
	{
		_sessionToolState.ClearTurnTools(session, sessionId);
		_sessionToolState.AdvanceRetainedTools(session);
	}

	internal static string ExtractUserText(IEnumerable<ChatMessage> messages)
	{
		return string.Join(Environment.NewLine, from message in messages ?? Array.Empty<ChatMessage>()
			where message?.Role == ChatRole.User
			select message.Text into text
			where !string.IsNullOrEmpty(text)
			select text);
	}
}
