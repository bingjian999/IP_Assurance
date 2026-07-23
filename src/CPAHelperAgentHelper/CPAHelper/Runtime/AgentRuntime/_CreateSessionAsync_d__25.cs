using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Logging;

namespace CPAHelper.Agent.Runtime;

public class AgentRuntime : IDisposable
{
	[CompilerGenerated]
	private sealed class <RunStreamingAsync>d__22 : IAsyncEnumerable<AgentResponseUpdate>, IAsyncEnumerator<AgentResponseUpdate>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncIteratorMethodBuilder <>t__builder;

		public ManualResetValueTaskSourceCore<bool> <>v__promiseOfValueOrEnd;

		private AgentResponseUpdate <>2__current;

		private bool <>w__disposeMode;

		private CancellationTokenSource <>x__combinedTokens;

		private int <>l__initialThreadId;

		public AgentRuntime <>4__this;

		private string userMessage;

		public string <>3__userMessage;

		private AgentSession session;

		public AgentSession <>3__session;

		private string instructions;

		public string <>3__instructions;

		private string sessionId;

		public string <>3__sessionId;

		private Action<string, string> statusObserver;

		public Action<string, string> <>3__statusObserver;

		private Action<MafCompactionMetricsSnapshot> compactionObserver;

		public Action<MafCompactionMetricsSnapshot> <>3__compactionObserver;

		private CancellationToken cancellationToken;

		public CancellationToken <>3__cancellationToken;

		private ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator <>7__wrap1;

		private object <>7__wrap2;

		private int <>7__wrap3;

		private ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter <>u__1;

		private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter <>u__2;

		AgentResponseUpdate IAsyncEnumerator<AgentResponseUpdate>.Current
		{
			[DebuggerHidden]
			get
			{
				return <>2__current;
			}
		}

		[DebuggerHidden]
		public <RunStreamingAsync>d__22(int <>1__state)
		{
			<>t__builder = AsyncIteratorMethodBuilder.Create();
			this.<>1__state = <>1__state;
			<>l__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			int num = <>1__state;
			AgentRuntime agentRuntime = <>4__this;
			try
			{
				ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (!<>w__disposeMode)
					{
						num = (<>1__state = -1);
						<>7__wrap1 = agentRuntime._runner.RunStreamingAsync(userMessage, session, instructions, sessionId, statusObserver, compactionObserver, cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAsyncEnumerator();
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
								goto IL_00e2;
							}
							awaiter2 = <>u__1;
							<>u__1 = default(ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter);
							num = (<>1__state = -1);
							goto IL_014d;
						}
						num = (<>1__state = -1);
						if (!<>w__disposeMode)
						{
							goto IL_00e2;
						}
						goto end_IL_009d;
						IL_00e2:
						<>2__current = null;
						awaiter2 = <>7__wrap1.MoveNextAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (<>1__state = 0);
							<>u__1 = awaiter2;
							<RunStreamingAsync>d__22 stateMachine = this;
							<>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_014d;
						IL_014d:
						if (awaiter2.GetResult())
						{
							AgentResponseUpdate current = <>7__wrap1.Current;
							<>2__current = current;
							num = (<>1__state = -4);
							goto IL_02ce;
						}
						end_IL_009d:;
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
						<RunStreamingAsync>d__22 stateMachine = this;
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
					<>7__wrap1 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				<>1__state = -2;
				<>7__wrap1 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
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
			<>7__wrap1 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
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
			IL_02ce:
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
			<RunStreamingAsync>d__22 <RunStreamingAsync>d__24;
			if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
			{
				<>1__state = -3;
				<>t__builder = AsyncIteratorMethodBuilder.Create();
				<>w__disposeMode = false;
				<RunStreamingAsync>d__24 = this;
			}
			else
			{
				<RunStreamingAsync>d__24 = new <RunStreamingAsync>d__22(-3)
				{
					<>4__this = <>4__this
				};
			}
			<RunStreamingAsync>d__24.userMessage = <>3__userMessage;
			<RunStreamingAsync>d__24.session = <>3__session;
			<RunStreamingAsync>d__24.instructions = <>3__instructions;
			<RunStreamingAsync>d__24.sessionId = <>3__sessionId;
			<RunStreamingAsync>d__24.statusObserver = <>3__statusObserver;
			<RunStreamingAsync>d__24.compactionObserver = <>3__compactionObserver;
			if (<>3__cancellationToken.Equals(default(CancellationToken)))
			{
				<RunStreamingAsync>d__24.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(<>3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				<RunStreamingAsync>d__24.cancellationToken = <>3__cancellationToken;
			}
			else
			{
				<>x__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(<>3__cancellationToken, cancellationToken);
				<RunStreamingAsync>d__24.cancellationToken = <>x__combinedTokens.Token;
			}
			return <RunStreamingAsync>d__24;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<AgentResponseUpdate>.MoveNextAsync()
		{
			if (<>1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			<>v__promiseOfValueOrEnd.Reset();
			<RunStreamingAsync>d__22 stateMachine = this;
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
			<RunStreamingAsync>d__22 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, <>v__promiseOfValueOrEnd.Version);
		}
	}

	[CompilerGenerated]
	private sealed class <RunStreamingAsync>d__23 : IAsyncEnumerable<AgentResponseUpdate>, IAsyncEnumerator<AgentResponseUpdate>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncIteratorMethodBuilder <>t__builder;

		public ManualResetValueTaskSourceCore<bool> <>v__promiseOfValueOrEnd;

		private AgentResponseUpdate <>2__current;

		private bool <>w__disposeMode;

		private CancellationTokenSource <>x__combinedTokens;

		private int <>l__initialThreadId;

		public AgentRuntime <>4__this;

		private IEnumerable<ChatMessage> messages;

		public IEnumerable<ChatMessage> <>3__messages;

		private AgentSession session;

		public AgentSession <>3__session;

		private string instructions;

		public string <>3__instructions;

		private string sessionId;

		public string <>3__sessionId;

		private Action<string, string> statusObserver;

		public Action<string, string> <>3__statusObserver;

		private Action<MafCompactionMetricsSnapshot> compactionObserver;

		public Action<MafCompactionMetricsSnapshot> <>3__compactionObserver;

		private CancellationToken cancellationToken;

		public CancellationToken <>3__cancellationToken;

		private ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator <>7__wrap1;

		private object <>7__wrap2;

		private int <>7__wrap3;

		private ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter <>u__1;

		private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter <>u__2;

		AgentResponseUpdate IAsyncEnumerator<AgentResponseUpdate>.Current
		{
			[DebuggerHidden]
			get
			{
				return <>2__current;
			}
		}

		[DebuggerHidden]
		public <RunStreamingAsync>d__23(int <>1__state)
		{
			<>t__builder = AsyncIteratorMethodBuilder.Create();
			this.<>1__state = <>1__state;
			<>l__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			int num = <>1__state;
			AgentRuntime agentRuntime = <>4__this;
			try
			{
				ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (!<>w__disposeMode)
					{
						num = (<>1__state = -1);
						<>7__wrap1 = agentRuntime._runner.RunStreamingAsync(messages, session, instructions, sessionId, statusObserver, compactionObserver, cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAsyncEnumerator();
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
								goto IL_00e2;
							}
							awaiter2 = <>u__1;
							<>u__1 = default(ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter);
							num = (<>1__state = -1);
							goto IL_014d;
						}
						num = (<>1__state = -1);
						if (!<>w__disposeMode)
						{
							goto IL_00e2;
						}
						goto end_IL_009d;
						IL_00e2:
						<>2__current = null;
						awaiter2 = <>7__wrap1.MoveNextAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (<>1__state = 0);
							<>u__1 = awaiter2;
							<RunStreamingAsync>d__23 stateMachine = this;
							<>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_014d;
						IL_014d:
						if (awaiter2.GetResult())
						{
							AgentResponseUpdate current = <>7__wrap1.Current;
							<>2__current = current;
							num = (<>1__state = -4);
							goto IL_02ce;
						}
						end_IL_009d:;
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
						<RunStreamingAsync>d__23 stateMachine = this;
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
					<>7__wrap1 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				<>1__state = -2;
				<>7__wrap1 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
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
			<>7__wrap1 = default(ConfiguredCancelableAsyncEnumerable<AgentResponseUpdate>.Enumerator);
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
			IL_02ce:
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
			<RunStreamingAsync>d__23 <RunStreamingAsync>d__24;
			if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
			{
				<>1__state = -3;
				<>t__builder = AsyncIteratorMethodBuilder.Create();
				<>w__disposeMode = false;
				<RunStreamingAsync>d__24 = this;
			}
			else
			{
				<RunStreamingAsync>d__24 = new <RunStreamingAsync>d__23(-3)
				{
					<>4__this = <>4__this
				};
			}
			<RunStreamingAsync>d__24.messages = <>3__messages;
			<RunStreamingAsync>d__24.session = <>3__session;
			<RunStreamingAsync>d__24.instructions = <>3__instructions;
			<RunStreamingAsync>d__24.sessionId = <>3__sessionId;
			<RunStreamingAsync>d__24.statusObserver = <>3__statusObserver;
			<RunStreamingAsync>d__24.compactionObserver = <>3__compactionObserver;
			if (<>3__cancellationToken.Equals(default(CancellationToken)))
			{
				<RunStreamingAsync>d__24.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(<>3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				<RunStreamingAsync>d__24.cancellationToken = <>3__cancellationToken;
			}
			else
			{
				<>x__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(<>3__cancellationToken, cancellationToken);
				<RunStreamingAsync>d__24.cancellationToken = <>x__combinedTokens.Token;
			}
			return <RunStreamingAsync>d__24;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<AgentResponseUpdate>.MoveNextAsync()
		{
			if (<>1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			<>v__promiseOfValueOrEnd.Reset();
			<RunStreamingAsync>d__23 stateMachine = this;
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
			<RunStreamingAsync>d__23 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, <>v__promiseOfValueOrEnd.Version);
		}
	}

	private readonly IAgentConfigProvider _configProvider;

	private readonly ToolAggregator _toolAggregator;

	private readonly IReadOnlyList<AIContextProvider> _contextProviders;

	private readonly SessionToolState _sessionToolState;

	private readonly AgentRuntimeAgentCache _agentCache;

	private readonly AgentRuntimeSessionService _sessionService;

	private readonly AgentRuntimeRunner _runner;

	internal TodoProvider TodoProvider => _contextProviders.OfType<TodoProvider>().FirstOrDefault();

	internal AgentModeProvider AgentModeProvider => _contextProviders.OfType<AgentModeProvider>().FirstOrDefault();

	public AgentRuntime(IAgentConfigProvider configProvider, ToolAggregator toolAggregator, IAgentSessionStore agentSessionStore, ChatClientFactory chatClientFactory, IEnumerable<AIContextProvider> contextProviders = null, IEnumerable<ISubAgentCatalog> subAgentCatalogs = null, ILoggerFactory loggerFactory = null, IServiceProvider serviceProvider = null)
	{
		_configProvider = configProvider ?? throw new ArgumentNullException("configProvider");
		_toolAggregator = toolAggregator ?? throw new ArgumentNullException("toolAggregator");
		if (agentSessionStore == null)
		{
			throw new ArgumentNullException("agentSessionStore");
		}
		if (chatClientFactory == null)
		{
			throw new ArgumentNullException("chatClientFactory");
		}
		_contextProviders = (contextProviders ?? Array.Empty<AIContextProvider>()).Where((AIContextProvider provider) => provider != null).ToList();
		_sessionToolState = new SessionToolState(_toolAggregator);
		RunOptionsFactory runOptionsFactory = new RunOptionsFactory(_configProvider, _toolAggregator, _sessionToolState);
		AgentFactory agentFactory = new AgentFactory(chatClientFactory, _toolAggregator, _sessionToolState, _contextProviders, subAgentCatalogs, loggerFactory, serviceProvider);
		_agentCache = new AgentRuntimeAgentCache(_configProvider, _sessionToolState, agentFactory.CreateAgent);
		_sessionService = new AgentRuntimeSessionService(_configProvider, agentSessionStore, _sessionToolState, GetOrCreateAgent);
		_runner = new AgentRuntimeRunner(GetOrCreateAgent, runOptionsFactory, _sessionToolState);
	}

	public AIAgent GetOrCreateAgent(string instructions = null, string sessionId = null)
	{
		return _agentCache.GetOrCreate(instructions, sessionId);
	}

	public void RemoveSession(string sessionId)
	{
		_agentCache.RemoveSession(sessionId);
	}

	public void ResetSessionState(string sessionId)
	{
		_agentCache.ResetSessionState(sessionId);
	}

	public IReadOnlyList<ToolMetadata> GetToolMetadata()
	{
		return _toolAggregator.GetToolMetadata();
	}

	public void RefreshToolCatalog()
	{
		_toolAggregator.RefreshCatalog();
		_sessionToolState.Clear();
		_agentCache.Clear();
	}

	public McpWarmupStatus StartMcpWarmup()
	{
		return _toolAggregator.StartMcpWarmup();
	}

	public McpWarmupStatus GetMcpWarmupStatus()
	{
		return _toolAggregator.GetMcpWarmupStatus();
	}

	public IReadOnlyList<string> EnsureToolsLoaded(string sessionId, IEnumerable<string> toolNames)
	{
		return _sessionToolState.EnsureToolsLoaded(sessionId, toolNames);
	}

	public IReadOnlyList<string> EnsureToolsLoaded(AgentSession session, string sessionId, IEnumerable<string> toolNames)
	{
		return _sessionToolState.EnsureToolsLoaded(session, sessionId, toolNames);
	}

	public async Task<AgentResponse> RunAsync(string userMessage, AgentSession session = null, string instructions = null, string sessionId = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return await _runner.RunAsync(userMessage, session, instructions, sessionId, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	[AsyncIteratorStateMachine(typeof(<RunStreamingAsync>d__22))]
	public IAsyncEnumerable<AgentResponseUpdate> RunStreamingAsync(string userMessage, AgentSession session = null, string instructions = null, string sessionId = null, Action<string, string> statusObserver = null, Action<MafCompactionMetricsSnapshot> compactionObserver = null, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		return new <RunStreamingAsync>d__22(-2)
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

	[AsyncIteratorStateMachine(typeof(<RunStreamingAsync>d__23))]
	public IAsyncEnumerable<AgentResponseUpdate> RunStreamingAsync(IEnumerable<ChatMessage> messages, AgentSession session = null, string instructions = null, string sessionId = null, Action<string, string> statusObserver = null, Action<MafCompactionMetricsSnapshot> compactionObserver = null, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		return new <RunStreamingAsync>d__23(-2)
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

	public void EndTurn(AgentSession session, string sessionId = null)
	{
		_runner.EndTurn(session, sessionId);
	}

	public async Task<AgentSession> CreateSessionAsync(string instructions = null, string sessionId = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return await _sessionService.CreateSessionAsync(instructions, sessionId, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task SaveSessionAsync(AgentSession session, string instructions = null, string sessionId = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		await _sessionService.SaveSessionAsync(session, instructions, sessionId, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task<MafCompactionMetricsSnapshot> GetCurrentCompactionMetricsAsync(AgentSession session, string instructions = null, string sessionId = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return await _sessionService.GetCurrentCompactionMetricsAsync(session, instructions, sessionId, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	internal static string ResolveSkillsPath()
	{
		return HarnessStoragePaths.ResolveSkillsPath();
	}

	internal static string EnsureSkillsPath()
	{
		return HarnessStoragePaths.EnsureSkillsPath();
	}

	public void Dispose()
	{
	}
}
