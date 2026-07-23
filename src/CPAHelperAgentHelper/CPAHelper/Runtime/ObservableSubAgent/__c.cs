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
using CPAHelper.Agent.Adapters;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class ObservableSubAgent : DelegatingAIAgent
{
	[CompilerGenerated]
	private sealed class <ObserveStreamingUpdates>d__4 : IAsyncEnumerable<AgentResponseUpdate>, IAsyncEnumerator<AgentResponseUpdate>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncIteratorMethodBuilder <>t__builder;

		public ManualResetValueTaskSourceCore<bool> <>v__promiseOfValueOrEnd;

		private AgentResponseUpdate <>2__current;

		private bool <>w__disposeMode;

		private CancellationTokenSource <>x__combinedTokens;

		private int <>l__initialThreadId;

		private IAsyncEnumerable<AgentResponseUpdate> updates;

		public IAsyncEnumerable<AgentResponseUpdate> <>3__updates;

		private CancellationToken cancellationToken;

		public CancellationToken <>3__cancellationToken;

		public ObservableSubAgent <>4__this;

		private SubAgentActivityDescriptor activity;

		public SubAgentActivityDescriptor <>3__activity;

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
		public <ObserveStreamingUpdates>d__4(int <>1__state)
		{
			<>t__builder = AsyncIteratorMethodBuilder.Create();
			this.<>1__state = <>1__state;
			<>l__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			int num = <>1__state;
			ObservableSubAgent observableSubAgent = <>4__this;
			try
			{
				ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (!<>w__disposeMode)
					{
						num = (<>1__state = -1);
						<>7__wrap1 = updates.ConfigureAwait(continueOnCapturedContext: false).GetAsyncEnumerator();
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
								goto IL_0112;
							}
							awaiter2 = <>u__1;
							<>u__1 = default(ConfiguredValueTaskAwaitable<bool>.ConfiguredValueTaskAwaiter);
							num = (<>1__state = -1);
							goto IL_017d;
						}
						num = (<>1__state = -1);
						if (!<>w__disposeMode)
						{
							goto IL_0112;
						}
						goto end_IL_006e;
						IL_0112:
						<>2__current = null;
						awaiter2 = <>7__wrap1.MoveNextAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (<>1__state = 0);
							<>u__1 = awaiter2;
							<ObserveStreamingUpdates>d__4 stateMachine = this;
							<>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
							return;
						}
						goto IL_017d;
						IL_017d:
						if (awaiter2.GetResult())
						{
							AgentResponseUpdate current = <>7__wrap1.Current;
							cancellationToken.ThrowIfCancellationRequested();
							IEnumerator<string> enumerator = ExtractReasoningText(current).GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									string current2 = enumerator.Current;
									observableSubAgent.PublishReasoning(activity, current2);
								}
							}
							finally
							{
								if (num == -1)
								{
									enumerator?.Dispose();
								}
							}
							if (!<>w__disposeMode)
							{
								<>2__current = current;
								num = (<>1__state = -4);
								goto IL_02fe;
							}
						}
						end_IL_006e:;
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
						<ObserveStreamingUpdates>d__4 stateMachine = this;
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
			IL_02fe:
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
			<ObserveStreamingUpdates>d__4 <ObserveStreamingUpdates>d__5;
			if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
			{
				<>1__state = -3;
				<>t__builder = AsyncIteratorMethodBuilder.Create();
				<>w__disposeMode = false;
				<ObserveStreamingUpdates>d__5 = this;
			}
			else
			{
				<ObserveStreamingUpdates>d__5 = new <ObserveStreamingUpdates>d__4(-3)
				{
					<>4__this = <>4__this
				};
			}
			<ObserveStreamingUpdates>d__5.updates = <>3__updates;
			<ObserveStreamingUpdates>d__5.activity = <>3__activity;
			if (<>3__cancellationToken.Equals(default(CancellationToken)))
			{
				<ObserveStreamingUpdates>d__5.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(<>3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				<ObserveStreamingUpdates>d__5.cancellationToken = <>3__cancellationToken;
			}
			else
			{
				<>x__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(<>3__cancellationToken, cancellationToken);
				<ObserveStreamingUpdates>d__5.cancellationToken = <>x__combinedTokens.Token;
			}
			return <ObserveStreamingUpdates>d__5;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<AgentResponseUpdate>.MoveNextAsync()
		{
			if (<>1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			<>v__promiseOfValueOrEnd.Reset();
			<ObserveStreamingUpdates>d__4 stateMachine = this;
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
			<ObserveStreamingUpdates>d__4 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, <>v__promiseOfValueOrEnd.Version);
		}
	}

	private const int PreviewLimit = 2400;

	private readonly SubAgentDefinition _definition;

	internal ObservableSubAgent(AIAgent innerAgent, SubAgentDefinition definition)
		: base(innerAgent)
	{
		_definition = definition ?? throw new ArgumentNullException("definition");
	}

	protected override async Task<AgentResponse> RunCoreAsync(IEnumerable<ChatMessage> messages, AgentSession session, AgentRunOptions options, CancellationToken cancellationToken)
	{
		List<ChatMessage> messages2 = (messages ?? Array.Empty<ChatMessage>()).ToList();
		SubAgentActivityDescriptor activity = SubAgentActivityCoordinator.ClaimActivity(_definition.Name ?? Name ?? string.Empty, ResolveRequestedDescription(messages2), _definition.Description ?? Description ?? _definition.Name ?? Name ?? string.Empty);
		Publish(activity, "starting", "子 agent 正在启动。", null);
		Publish(activity, "running", "子 agent 正在读取上下文并执行探索。", null);
		try
		{
			AgentResponse agentResponse;
			using (SubAgentActivityRelay.EnterActivity(activity.ActivityId))
			{
				agentResponse = await ObserveStreamingUpdates(RunCoreStreamingAsync(messages2, session, options, cancellationToken), activity, cancellationToken).ToAgentResponseAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			Publish(activity, "completed", "子 agent 已完成。", CreatePreview(agentResponse?.Text));
			return agentResponse;
		}
		catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
		{
			Publish(activity, "cancelled", "子 agent 已取消。", null);
			throw;
		}
		catch (Exception ex2)
		{
			Publish(activity, "failed", "子 agent 失败：" + ex2.Message, null);
			throw;
		}
	}

	[AsyncIteratorStateMachine(typeof(<ObserveStreamingUpdates>d__4))]
	private IAsyncEnumerable<AgentResponseUpdate> ObserveStreamingUpdates(IAsyncEnumerable<AgentResponseUpdate> updates, SubAgentActivityDescriptor activity, [EnumeratorCancellation] CancellationToken cancellationToken)
	{
		return new <ObserveStreamingUpdates>d__4(-2)
		{
			<>4__this = this,
			<>3__updates = updates,
			<>3__activity = activity,
			<>3__cancellationToken = cancellationToken
		};
	}

	private static IEnumerable<string> ExtractReasoningText(AgentResponseUpdate update)
	{
		if (update?.Contents == null || update.Contents.Count == 0)
		{
			yield break;
		}
		foreach (AIContent content in update.Contents)
		{
			if (content is TextReasoningContent textReasoningContent && !string.IsNullOrEmpty(textReasoningContent.Text))
			{
				yield return textReasoningContent.Text;
			}
		}
	}

	private static string ResolveRequestedDescription(IReadOnlyList<ChatMessage> messages)
	{
		return messages?.LastOrDefault((ChatMessage message) => message?.Role == ChatRole.User)?.Text;
	}

	private void Publish(SubAgentActivityDescriptor activity, string status, string detail, string resultPreview)
	{
		SubAgentActivityUpdate update = new SubAgentActivityUpdate
		{
			ActivityId = activity.ActivityId,
			AgentName = (_definition.Name ?? Name ?? string.Empty),
			Title = activity.Title,
			Status = status,
			Detail = detail,
			ResultPreview = resultPreview,
			ActivityGroupId = activity.ActivityGroupId,
			ActivityGroupTitle = activity.ActivityGroupTitle,
			UpdatedAt = DateTimeOffset.Now.ToString("O")
		};
		SubAgentActivityCoordinator.ObserveActivityUpdate(update);
		SubAgentActivityRelay.Publish(update);
	}

	private void PublishReasoning(SubAgentActivityDescriptor activity, string reasoningDelta)
	{
		if (!string.IsNullOrEmpty(reasoningDelta))
		{
			SubAgentActivityUpdate update = new SubAgentActivityUpdate
			{
				ActivityId = activity.ActivityId,
				AgentName = (_definition.Name ?? Name ?? string.Empty),
				Title = activity.Title,
				Status = "running",
				ReasoningDelta = reasoningDelta,
				ActivityGroupId = activity.ActivityGroupId,
				ActivityGroupTitle = activity.ActivityGroupTitle,
				UpdatedAt = DateTimeOffset.Now.ToString("O")
			};
			SubAgentActivityCoordinator.ObserveActivityUpdate(update);
			SubAgentActivityRelay.Publish(update);
		}
	}

	private static string CreatePreview(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		string text2 = text.Trim();
		if (text2.Length > 2400)
		{
			return text2.Substring(0, 2400) + "...";
		}
		return text2;
	}
}
