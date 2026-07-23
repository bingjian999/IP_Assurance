using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class DeepSeekOpenAIChatClient : IChatClient, IDisposable, IProviderRequestBudgetEstimator
{
	private sealed class StreamingState
	{
		private readonly Dictionary<int, ToolCallBuilder> _toolCalls = new Dictionary<int, ToolCallBuilder>();

		private readonly StringBuilder _pendingAnswerText = new StringBuilder();

		public StringBuilder ReasoningText { get; } = new StringBuilder();

		public bool BufferAnswerTextUntilOutcome { get; }

		public bool HasToolCalls => _toolCalls.Count > 0;

		public ChatFinishReason? FinishReason { get; set; }

		private string ResponseId { get; set; }

		private string ModelId { get; set; }

		private DateTimeOffset? CreatedAt { get; set; }

		public StreamingState(bool bufferAnswerTextUntilOutcome)
		{
			BufferAnswerTextUntilOutcome = bufferAnswerTextUntilOutcome;
		}

		public void ObserveResponseMetadata(string responseId, string modelId, DateTimeOffset? createdAt)
		{
			ResponseId = ResponseId ?? responseId;
			ModelId = ModelId ?? modelId;
			CreatedAt = CreatedAt ?? createdAt;
		}

		public void AppendPendingAnswerText(string text)
		{
			if (!string.IsNullOrEmpty(text))
			{
				_pendingAnswerText.Append(text);
			}
		}

		public ChatResponseUpdate DrainPendingAnswerText(bool asReasoning)
		{
			if (_pendingAnswerText.Length == 0)
			{
				return null;
			}
			string text = _pendingAnswerText.ToString();
			_pendingAnswerText.Clear();
			if (!asReasoning)
			{
				return new ChatResponseUpdate(ChatRole.Assistant, text)
				{
					ResponseId = ResponseId,
					ModelId = ModelId,
					CreatedAt = CreatedAt
				};
			}
			ReasoningText.Append(text);
			TextReasoningContent item = new TextReasoningContent(text)
			{
				AdditionalProperties = new AdditionalPropertiesDictionary { ["reasoning_content"] = text }
			};
			return new ChatResponseUpdate(ChatRole.Assistant, new List<AIContent> { item })
			{
				ResponseId = ResponseId,
				ModelId = ModelId,
				CreatedAt = CreatedAt
			};
		}

		public void AppendToolCalls(JsonElement toolCalls)
		{
			foreach (JsonElement item in toolCalls.EnumerateArray())
			{
				int key = 0;
				if (item.TryGetProperty("index", out var value) && value.ValueKind == JsonValueKind.Number)
				{
					key = value.GetInt32();
				}
				if (!_toolCalls.TryGetValue(key, out var value2))
				{
					value2 = new ToolCallBuilder();
					_toolCalls[key] = value2;
				}
				value2.Append(item);
			}
		}

		public ChatResponseUpdate CreateFinalToolCallUpdate()
		{
			if (_toolCalls.Count == 0)
			{
				return null;
			}
			List<AIContent> list = (from kv in _toolCalls
				orderby kv.Key
				select kv.Value.ToFunctionCallContent() into c
				where c != null
				select c).Cast<AIContent>().ToList();
			if (list.Count == 0)
			{
				return null;
			}
			ChatResponseUpdate chatResponseUpdate = new ChatResponseUpdate(ChatRole.Assistant, list)
			{
				FinishReason = ChatFinishReason.ToolCalls
			};
			if (ReasoningText.Length > 0)
			{
				chatResponseUpdate.AdditionalProperties = new AdditionalPropertiesDictionary { ["reasoning_content"] = ReasoningText.ToString() };
			}
			return chatResponseUpdate;
		}
	}

	private sealed class ToolCallBuilder
	{
		private readonly StringBuilder _arguments = new StringBuilder();

		private string _id;

		private string _name;

		public void Append(JsonElement item)
		{
			string text = GetString(item, "id");
			if (!string.IsNullOrWhiteSpace(text))
			{
				_id = text;
			}
			if (item.TryGetProperty("function", out var value) && value.ValueKind == JsonValueKind.Object)
			{
				string text2 = GetString(value, "name");
				if (!string.IsNullOrWhiteSpace(text2))
				{
					_name = text2;
				}
				string value2 = GetString(value, "arguments");
				if (!string.IsNullOrEmpty(value2))
				{
					_arguments.Append(value2);
				}
			}
		}

		public FunctionCallContent ToFunctionCallContent()
		{
			if (string.IsNullOrWhiteSpace(_name))
			{
				return null;
			}
			return new FunctionCallContent(string.IsNullOrWhiteSpace(_id) ? Guid.NewGuid().ToString("N") : _id, _name, ParseArguments(_arguments.ToString()));
		}
	}

	[CompilerGenerated]
	private sealed class <GetStreamingResponseAsync>d__13 : IAsyncEnumerable<ChatResponseUpdate>, IAsyncEnumerator<ChatResponseUpdate>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
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

		public DeepSeekOpenAIChatClient <>4__this;

		private ChatOptions options;

		public ChatOptions <>3__options;

		private CancellationToken cancellationToken;

		public CancellationToken <>3__cancellationToken;

		private Dictionary<string, object> <requestBody>5__2;

		private HttpRequestMessage <request>5__3;

		private HttpResponseMessage <response>5__4;

		private ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter <>u__1;

		private ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter <>u__2;

		private Stream <stream>5__5;

		private ConfiguredTaskAwaitable<Stream>.ConfiguredTaskAwaiter <>u__3;

		private StreamReader <reader>5__6;

		private StreamingState <state>5__7;

		private IEnumerator<ChatResponseUpdate> <>7__wrap7;

		ChatResponseUpdate IAsyncEnumerator<ChatResponseUpdate>.Current
		{
			[DebuggerHidden]
			get
			{
				return <>2__current;
			}
		}

		[DebuggerHidden]
		public <GetStreamingResponseAsync>d__13(int <>1__state)
		{
			<>t__builder = AsyncIteratorMethodBuilder.Create();
			this.<>1__state = <>1__state;
			<>l__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Expected O, but got Unknown
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Expected O, but got Unknown
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
			int num = <>1__state;
			DeepSeekOpenAIChatClient deepSeekOpenAIChatClient = <>4__this;
			try
			{
				string text = default(string);
				switch (num)
				{
				default:
					if (!<>w__disposeMode)
					{
						num = (<>1__state = -1);
						List<ChatMessage> list = (messages ?? Array.Empty<ChatMessage>()).ToList();
						<requestBody>5__2 = deepSeekOpenAIChatClient.BuildRequestBody(list, options, stream: true);
						WriteWireDebug(<requestBody>5__2);
						text = JsonSerializer.Serialize(<requestBody>5__2, JsonOptions);
						<request>5__3 = new HttpRequestMessage(HttpMethod.Post, deepSeekOpenAIChatClient._endpoint);
						break;
					}
					goto end_IL_000e;
				case -6:
				case -5:
				case -4:
				case 0:
				case 1:
				case 2:
				case 3:
					break;
				}
				try
				{
					ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter awaiter;
					HttpResponseMessage result;
					switch (num)
					{
					default:
						<request>5__3.Headers.Authorization = new AuthenticationHeaderValue("Bearer", deepSeekOpenAIChatClient._apiKey);
						<request>5__3.Headers.Accept.ParseAdd("text/event-stream");
						<request>5__3.Content = (HttpContent)new StringContent(text, Encoding.UTF8, "application/json");
						<>2__current = null;
						awaiter = deepSeekOpenAIChatClient._httpClient.SendAsync(<request>5__3, (HttpCompletionOption)1, cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (<>1__state = 0);
							<>u__1 = awaiter;
							<GetStreamingResponseAsync>d__13 stateMachine = this;
							<>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_01b5;
					case 0:
						awaiter = <>u__1;
						<>u__1 = default(ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter);
						num = (<>1__state = -1);
						goto IL_01b5;
					case -6:
					case -5:
					case -4:
					case 1:
					case 2:
					case 3:
						break;
						IL_01b5:
						result = awaiter.GetResult();
						<response>5__4 = result;
						break;
					}
					try
					{
						ConfiguredTaskAwaitable<Stream>.ConfiguredTaskAwaiter awaiter2;
						string result2;
						Stream result3;
						ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter awaiter3;
						switch (num)
						{
						default:
							if (!<response>5__4.IsSuccessStatusCode)
							{
								<>2__current = null;
								awaiter3 = <response>5__4.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (<>1__state = 1);
									<>u__2 = awaiter3;
									<GetStreamingResponseAsync>d__13 stateMachine = this;
									<>t__builder.AwaitUnsafeOnCompleted(ref awaiter3, ref stateMachine);
									return;
								}
								goto IL_027e;
							}
							<>2__current = null;
							awaiter2 = <response>5__4.Content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (<>1__state = 2);
								<>u__3 = awaiter2;
								<GetStreamingResponseAsync>d__13 stateMachine = this;
								<>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_0337;
						case 1:
							awaiter3 = <>u__2;
							<>u__2 = default(ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter);
							num = (<>1__state = -1);
							goto IL_027e;
						case 2:
							awaiter2 = <>u__3;
							<>u__3 = default(ConfiguredTaskAwaitable<Stream>.ConfiguredTaskAwaiter);
							num = (<>1__state = -1);
							goto IL_0337;
						case -6:
						case -5:
						case -4:
						case 3:
							break;
							IL_027e:
							result2 = awaiter3.GetResult();
							LogProviderErrorBudget(<requestBody>5__2, result2);
							throw new HttpRequestException($"DeepSeek API returned {(int)<response>5__4.StatusCode} ({<response>5__4.ReasonPhrase}): {result2}");
							IL_0337:
							result3 = awaiter2.GetResult();
							<stream>5__5 = result3;
							break;
						}
						try
						{
							if ((uint)(num - -6) > 2u && num != 3)
							{
								<reader>5__6 = new StreamReader(<stream>5__5, Encoding.UTF8);
							}
							try
							{
								ChatResponseUpdate chatResponseUpdate;
								ChatResponseUpdate chatResponseUpdate2;
								string result4;
								string text2;
								switch (num)
								{
								default:
									<state>5__7 = new StreamingState(options?.Tools != null && options.Tools.Count > 0);
									goto IL_0514;
								case 3:
									awaiter3 = <>u__2;
									<>u__2 = default(ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter);
									num = (<>1__state = -1);
									goto IL_043d;
								case -4:
									try
									{
										if (num != -4)
										{
											goto IL_04db;
										}
										num = (<>1__state = -1);
										if (!<>w__disposeMode)
										{
											goto IL_04db;
										}
										goto end_IL_049f;
										IL_04db:
										if (!<>7__wrap7.MoveNext())
										{
											goto end_IL_049f;
										}
										ChatResponseUpdate current = <>7__wrap7.Current;
										<>2__current = current;
										num = (<>1__state = -4);
										goto end_IL_0349;
										end_IL_049f:;
									}
									finally
									{
										if (num == -1 && <>7__wrap7 != null)
										{
											<>7__wrap7.Dispose();
										}
									}
									if (!<>w__disposeMode)
									{
										<>7__wrap7 = null;
										goto IL_0514;
									}
									goto end_IL_036b;
								case -5:
									num = (<>1__state = -1);
									if (!<>w__disposeMode)
									{
										goto IL_0568;
									}
									goto end_IL_036b;
								case -6:
									{
										num = (<>1__state = -1);
										if (!<>w__disposeMode)
										{
											break;
										}
										goto end_IL_036b;
									}
									IL_0514:
									if (!<reader>5__6.EndOfStream)
									{
										cancellationToken.ThrowIfCancellationRequested();
										<>2__current = null;
										awaiter3 = <reader>5__6.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
										if (!awaiter3.IsCompleted)
										{
											num = (<>1__state = 3);
											<>u__2 = awaiter3;
											<GetStreamingResponseAsync>d__13 stateMachine = this;
											<>t__builder.AwaitUnsafeOnCompleted(ref awaiter3, ref stateMachine);
											return;
										}
										goto IL_043d;
									}
									goto IL_0524;
									IL_0524:
									chatResponseUpdate = <state>5__7.DrainPendingAnswerText(<state>5__7.HasToolCalls);
									if (chatResponseUpdate == null)
									{
										goto IL_0568;
									}
									<>2__current = chatResponseUpdate;
									num = (<>1__state = -5);
									goto end_IL_0349;
									IL_0568:
									chatResponseUpdate2 = <state>5__7.CreateFinalToolCallUpdate();
									if (chatResponseUpdate2 == null)
									{
										break;
									}
									deepSeekOpenAIChatClient.RememberToolReasoning(chatResponseUpdate2, <state>5__7.ReasoningText);
									<>2__current = chatResponseUpdate2;
									num = (<>1__state = -6);
									goto end_IL_0349;
									IL_043d:
									result4 = awaiter3.GetResult();
									if (string.IsNullOrWhiteSpace(result4) || !result4.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
									{
										goto IL_0514;
									}
									text2 = result4.Substring(5).Trim();
									if (!string.Equals(text2, "[DONE]", StringComparison.Ordinal))
									{
										<>7__wrap7 = deepSeekOpenAIChatClient.ParseStreamingChunk(text2, <state>5__7).GetEnumerator();
										goto case -4;
									}
									goto IL_0524;
								}
								<state>5__7 = null;
								end_IL_036b:;
							}
							finally
							{
								if (num == -1 && <reader>5__6 != null)
								{
									((IDisposable)<reader>5__6).Dispose();
								}
							}
							if (!<>w__disposeMode)
							{
								<reader>5__6 = null;
							}
							goto IL_05fe;
							end_IL_0349:;
						}
						finally
						{
							if (num == -1 && <stream>5__5 != null)
							{
								((IDisposable)<stream>5__5).Dispose();
							}
						}
						goto end_IL_01c7;
						IL_05fe:
						if (!<>w__disposeMode)
						{
							<stream>5__5 = null;
						}
						goto IL_0627;
						end_IL_01c7:;
					}
					finally
					{
						if (num == -1 && <response>5__4 != null)
						{
							((IDisposable)<response>5__4).Dispose();
						}
					}
					goto end_IL_00b1;
					IL_0627:
					if (!<>w__disposeMode)
					{
						<response>5__4 = null;
					}
					goto IL_0650;
					end_IL_00b1:;
				}
				finally
				{
					if (num == -1 && <request>5__3 != null)
					{
						((IDisposable)<request>5__3).Dispose();
					}
				}
				goto IL_074b;
				IL_0650:
				if (!<>w__disposeMode)
				{
					<request>5__3 = null;
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				<>1__state = -2;
				<requestBody>5__2 = null;
				<request>5__3 = null;
				<response>5__4 = null;
				<stream>5__5 = null;
				<reader>5__6 = null;
				<state>5__7 = null;
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
			<requestBody>5__2 = null;
			<request>5__3 = null;
			<response>5__4 = null;
			<stream>5__5 = null;
			<reader>5__6 = null;
			<state>5__7 = null;
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
			IL_074b:
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
			<GetStreamingResponseAsync>d__13 <GetStreamingResponseAsync>d__14;
			if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
			{
				<>1__state = -3;
				<>t__builder = AsyncIteratorMethodBuilder.Create();
				<>w__disposeMode = false;
				<GetStreamingResponseAsync>d__14 = this;
			}
			else
			{
				<GetStreamingResponseAsync>d__14 = new <GetStreamingResponseAsync>d__13(-3)
				{
					<>4__this = <>4__this
				};
			}
			<GetStreamingResponseAsync>d__14.messages = <>3__messages;
			<GetStreamingResponseAsync>d__14.options = <>3__options;
			if (<>3__cancellationToken.Equals(default(CancellationToken)))
			{
				<GetStreamingResponseAsync>d__14.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(<>3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				<GetStreamingResponseAsync>d__14.cancellationToken = <>3__cancellationToken;
			}
			else
			{
				<>x__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(<>3__cancellationToken, cancellationToken);
				<GetStreamingResponseAsync>d__14.cancellationToken = <>x__combinedTokens.Token;
			}
			return <GetStreamingResponseAsync>d__14;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<ChatResponseUpdate>.MoveNextAsync()
		{
			if (<>1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			<>v__promiseOfValueOrEnd.Reset();
			<GetStreamingResponseAsync>d__13 stateMachine = this;
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
			<GetStreamingResponseAsync>d__13 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, <>v__promiseOfValueOrEnd.Version);
		}
	}

	private const string ReasoningContentKey = "reasoning_content";

	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		PropertyNamingPolicy = null,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
	};

	private readonly HttpClient _httpClient;

	private readonly string _endpoint;

	private readonly string _apiKey;

	private readonly string _model;

	private readonly bool _ownsHttpClient;

	internal HttpClient Transport => _httpClient;

	public DeepSeekOpenAIChatClient(string apiKey, string baseUrl, string model)
		: this(apiKey, baseUrl, model, null, ownsHttpClient: true)
	{
	}

	internal DeepSeekOpenAIChatClient(string apiKey, string baseUrl, string model, HttpClient httpClient)
		: this(apiKey, baseUrl, model, httpClient, ownsHttpClient: true)
	{
	}

	internal DeepSeekOpenAIChatClient(string apiKey, string baseUrl, string model, HttpClient httpClient, bool ownsHttpClient)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(apiKey))
		{
			throw new ArgumentException("API key is required.", "apiKey");
		}
		if (string.IsNullOrWhiteSpace(model))
		{
			throw new ArgumentException("Model is required.", "model");
		}
		_apiKey = apiKey;
		_model = model;
		_endpoint = NormalizeEndpoint(baseUrl);
		_httpClient = (HttpClient)(((object)httpClient) ?? ((object)new HttpClient
		{
			Timeout = TimeSpan.FromMinutes(10.0)
		}));
		_ownsHttpClient = httpClient == null || ownsHttpClient;
	}

	public async Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		List<ChatMessage> responseMessages = new List<ChatMessage>();
		List<AIContent> contents = new List<AIContent>();
		StringBuilder textBuilder = new StringBuilder();
		StringBuilder reasoningBuilder = new StringBuilder();
		ChatFinishReason? finishReason = null;
		string responseId = null;
		string modelId = null;
		DateTimeOffset? createdAt = null;
		UsageDetails usage = null;
		await foreach (ChatResponseUpdate item in GetStreamingResponseAsync(messages, options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
		{
			responseId = responseId ?? item.ResponseId;
			modelId = modelId ?? item.ModelId;
			createdAt = createdAt ?? item.CreatedAt;
			finishReason = item.FinishReason ?? finishReason;
			foreach (AIContent item2 in item.Contents ?? Array.Empty<AIContent>())
			{
				if (item2 is UsageContent usageContent)
				{
					usage = MergeUsage(usage, usageContent.Details);
					continue;
				}
				contents.Add(item2);
				if (item2 is TextContent textContent)
				{
					textBuilder.Append(textContent.Text);
				}
				else if (item2 is TextReasoningContent textReasoningContent)
				{
					reasoningBuilder.Append(textReasoningContent.Text);
				}
			}
		}
		if (contents.Count == 0 && textBuilder.Length > 0)
		{
			contents.Add(new TextContent(textBuilder.ToString()));
		}
		ChatMessage chatMessage = new ChatMessage(ChatRole.Assistant, contents);
		if (reasoningBuilder.Length > 0)
		{
			SetReasoning(chatMessage, reasoningBuilder.ToString());
		}
		responseMessages.Add(chatMessage);
		return new ChatResponse(responseMessages)
		{
			ResponseId = responseId,
			ModelId = (modelId ?? _model),
			CreatedAt = createdAt,
			FinishReason = finishReason,
			Usage = usage
		};
	}

	[AsyncIteratorStateMachine(typeof(<GetStreamingResponseAsync>d__13))]
	public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		return new <GetStreamingResponseAsync>d__13(-2)
		{
			<>4__this = this,
			<>3__messages = messages,
			<>3__options = options,
			<>3__cancellationToken = cancellationToken
		};
	}

	public object GetService(Type serviceType, object serviceKey = null)
	{
		if (serviceType == typeof(DeepSeekOpenAIChatClient) || serviceType == typeof(IChatClient))
		{
			return this;
		}
		if (serviceType == typeof(IProviderRequestBudgetEstimator))
		{
			return this;
		}
		return null;
	}

	public ProviderRequestBudgetSnapshot Estimate(IEnumerable<ChatMessage> messages, ChatOptions options, bool stream, AgentChatRuntimeOptions.ResolvedSummaryOptions summaryOptions)
	{
		return ProviderRequestBudgetEstimator.EstimateRequestBody(BuildRequestBody(messages ?? Array.Empty<ChatMessage>(), options, stream), JsonOptions, "deepseek-compatible", summaryOptions);
	}

	public void Dispose()
	{
		if (_ownsHttpClient)
		{
			((HttpMessageInvoker)_httpClient).Dispose();
		}
	}

	private Dictionary<string, object> BuildRequestBody(IEnumerable<ChatMessage> messages, ChatOptions options, bool stream)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			["model"] = (string.IsNullOrWhiteSpace(options?.ModelId) ? _model : options.ModelId),
			["messages"] = BuildWireMessages(messages, options),
			["stream"] = stream,
			["thinking"] = new Dictionary<string, object> { ["type"] = "enabled" }
		};
		string effort = options?.Reasoning?.Effort?.ToString();
		dictionary["reasoning_effort"] = NormalizeReasoningEffort(effort);
		if (options != null && options.MaxOutputTokens.HasValue)
		{
			dictionary["max_tokens"] = options.MaxOutputTokens.Value;
		}
		if (stream && ShouldRequestStreamUsage())
		{
			dictionary["stream_options"] = new Dictionary<string, object> { ["include_usage"] = true };
		}
		List<Dictionary<string, object>> list = BuildTools(options?.Tools);
		if (list.Count > 0)
		{
			dictionary["tools"] = list;
			dictionary["tool_choice"] = "auto";
		}
		return dictionary;
	}

	private static void WriteWireDebug(Dictionary<string, object> requestBody)
	{
		if (!string.Equals(Environment.GetEnvironmentVariable("CPAHELPER_DEEPSEEK_WIRE_DEBUG"), "1", StringComparison.Ordinal))
		{
			return;
		}
		try
		{
			string path = Path.Combine(Path.GetTempPath(), "cpahelper-deepseek-wire.log");
			string path2 = Path.Combine(ResolveRepoRootForWireDebug(), ".dev", "wire-traces", $"deepseek-wire-{Process.GetCurrentProcess().Id}.jsonl");
			List<string> list = new List<string> { $"--- {DateTimeOffset.Now:O} ---" };
			if (requestBody.TryGetValue("messages", out var value) && value is IEnumerable<Dictionary<string, object>> enumerable)
			{
				int num = 0;
				foreach (Dictionary<string, object> item in enumerable)
				{
					item.TryGetValue("role", out var value2);
					item.TryGetValue("content", out var value3);
					item.TryGetValue("tool_calls", out var value4);
					item.TryGetValue("tool_call_id", out var value5);
					list.Add($"{num++}: role={value2}; toolCalls={CountWireItems(value4)}; toolCallIds={DescribeToolCallIds(value4, value5)}; content={TruncateForWireDebug(value3)}");
				}
			}
			File.AppendAllLines(path, list, Encoding.UTF8);
			Directory.CreateDirectory(Path.GetDirectoryName(path2));
			File.AppendAllText(path2, JsonSerializer.Serialize(new
			{
				timestamp = DateTimeOffset.Now,
				body = requestBody
			}, JsonOptions) + Environment.NewLine, Encoding.UTF8);
		}
		catch
		{
		}
	}

	private static void LogProviderErrorBudget(Dictionary<string, object> requestBody, string error)
	{
		try
		{
			ProviderRequestBudgetSnapshot snapshot = ProviderRequestBudgetEstimator.EstimateRequestBody(requestBody, JsonOptions, "deepseek-compatible", null);
			int? num = TryParseRequestedTokens(error);
			ProviderBudgetDiagnostics.Log("provider-error", snapshot, (!num.HasValue) ? null : $"ProviderRequestedTokens={num.Value}", forceConsole: true);
		}
		catch
		{
		}
	}

	private static int? TryParseRequestedTokens(string error)
	{
		if (string.IsNullOrWhiteSpace(error))
		{
			return null;
		}
		Match match = Regex.Match(error, "requested:\\s*(\\d+)", RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return null;
		}
		if (!int.TryParse(match.Groups[1].Value, out var result))
		{
			return null;
		}
		return result;
	}

	private static string ResolveRepoRootForWireDebug()
	{
		for (DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory); directoryInfo != null; directoryInfo = directoryInfo.Parent)
		{
			if (Directory.Exists(Path.Combine(directoryInfo.FullName, ".git")) || File.Exists(Path.Combine(directoryInfo.FullName, "run-devhost.ps1")))
			{
				return directoryInfo.FullName;
			}
		}
		return Path.GetTempPath();
	}

	private static string TruncateForWireDebug(object value)
	{
		if (value == null)
		{
			return "<null>";
		}
		string text = (value as string) ?? JsonSerializer.Serialize(value, JsonOptions);
		text = text.Replace("\r", "\\r").Replace("\n", "\n");
		if (text.Length > 360)
		{
			return text.Substring(0, 360) + "...";
		}
		return text;
	}

	private static int CountWireItems(object value)
	{
		if (value == null)
		{
			return 0;
		}
		if (value is ICollection collection)
		{
			return collection.Count;
		}
		return 1;
	}

	private static string DescribeToolCallIds(object toolCalls, object toolCallId)
	{
		if (toolCallId != null)
		{
			return toolCallId.ToString();
		}
		if (!(toolCalls is IEnumerable<Dictionary<string, object>> source))
		{
			return string.Empty;
		}
		return string.Join(",", from id in source.Select(delegate(Dictionary<string, object> call)
			{
				call.TryGetValue("id", out var value);
				return value?.ToString();
			})
			where !string.IsNullOrWhiteSpace(id)
			select id);
	}

	private List<Dictionary<string, object>> BuildWireMessages(IEnumerable<ChatMessage> messages, ChatOptions options)
	{
		List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
		if (!string.IsNullOrWhiteSpace(options?.Instructions))
		{
			list.Add(new Dictionary<string, object>
			{
				["role"] = "system",
				["content"] = options.Instructions
			});
		}
		list.AddRange(from message in NormalizeMessagesForWire(messages).SelectMany(ToWireMessages)
			where message != null
			select message);
		return list;
	}

	private static IEnumerable<ChatMessage> NormalizeMessagesForWire(IEnumerable<ChatMessage> messages)
	{
		List<ChatMessage> visibleMessages = (messages ?? Array.Empty<ChatMessage>()).Where((ChatMessage message) => !IsProviderInvisibleApprovalMessage(message)).ToList();
		int index = 0;
		while (index < visibleMessages.Count)
		{
			ChatMessage chatMessage = visibleMessages[index];
			List<string> functionCallIds = GetFunctionCallIds(chatMessage);
			if (functionCallIds.Count == 0)
			{
				yield return (chatMessage.Role == ChatRole.Tool) ? ConvertOrphanToolMessageToUserMessage(chatMessage) : chatMessage;
				index++;
				continue;
			}
			List<ChatMessage> list = new List<ChatMessage> { chatMessage };
			HashSet<string> hashSet = new HashSet<string>(functionCallIds, StringComparer.Ordinal);
			int scan;
			for (scan = index + 1; scan < visibleMessages.Count; scan++)
			{
				if (hashSet.Count <= 0)
				{
					break;
				}
				ChatMessage chatMessage2 = visibleMessages[scan];
				if (chatMessage2.Role != ChatRole.Tool)
				{
					break;
				}
				list.Add(chatMessage2);
				foreach (string functionResultCallId in GetFunctionResultCallIds(chatMessage2))
				{
					if (!string.IsNullOrWhiteSpace(functionResultCallId))
					{
						hashSet.Remove(functionResultCallId);
					}
				}
			}
			if (hashSet.Count == 0 || scan >= visibleMessages.Count)
			{
				foreach (ChatMessage item in list)
				{
					yield return item;
				}
			}
			index = scan;
		}
	}

	private static bool IsProviderInvisibleApprovalMessage(ChatMessage message)
	{
		ChatRole? chatRole = message?.Role;
		ChatRole user = ChatRole.User;
		if (!chatRole.HasValue || chatRole.GetValueOrDefault() != user || message.Contents == null || message.Contents.Count == 0)
		{
			return false;
		}
		return message.Contents.All(IsProviderInvisibleApprovalContent);
	}

	private static bool IsProviderInvisibleApprovalContent(AIContent content)
	{
		if (content == null)
		{
			return true;
		}
		string name = content.GetType().Name;
		if (!string.Equals(name, "ToolApprovalRequestContent", StringComparison.Ordinal) && !string.Equals(name, "ToolApprovalResponseContent", StringComparison.Ordinal))
		{
			return string.Equals(name, "AlwaysApproveToolApprovalResponseContent", StringComparison.Ordinal);
		}
		return true;
	}

	private static List<string> GetFunctionCallIds(ChatMessage message)
	{
		return (from call in GetFunctionCalls(message)
			select call.CallId into callId
			where !string.IsNullOrWhiteSpace(callId)
			select callId).ToList();
	}

	private static IEnumerable<string> GetFunctionResultCallIds(ChatMessage message)
	{
		if (message?.Contents != null)
		{
			foreach (FunctionResultContent item in message.Contents.OfType<FunctionResultContent>())
			{
				yield return item.CallId;
			}
		}
		string text = GetString(message?.AdditionalProperties, "tool_call_id");
		if (!string.IsNullOrWhiteSpace(text))
		{
			yield return text;
		}
	}

	private static ChatMessage ConvertOrphanToolMessageToUserMessage(ChatMessage message)
	{
		List<FunctionResultContent> list = message?.Contents?.OfType<FunctionResultContent>().ToList();
		if (list == null || list.Count == 0)
		{
			return new ChatMessage(ChatRole.User, "Tool result: " + (message?.Text ?? string.Empty));
		}
		List<string> list2 = new List<string>();
		foreach (FunctionResultContent item in list)
		{
			string text = (string.IsNullOrWhiteSpace(item.CallId) ? "unknown" : item.CallId);
			list2.Add("Tool result for " + text + ": " + ConvertToolResultToText(item.Result, item.Exception));
		}
		return new ChatMessage(ChatRole.User, string.Join(Environment.NewLine, list2));
	}

	private IEnumerable<Dictionary<string, object>> ToWireMessages(ChatMessage message)
	{
		if (message == null)
		{
			yield break;
		}
		if (message.Role != ChatRole.Tool)
		{
			Dictionary<string, object> dictionary = ToWireMessage(message);
			if (dictionary != null)
			{
				yield return dictionary;
			}
			yield break;
		}
		List<FunctionResultContent> list = message.Contents?.OfType<FunctionResultContent>().ToList();
		if (list == null || list.Count == 0)
		{
			yield return new Dictionary<string, object>
			{
				["role"] = "tool",
				["tool_call_id"] = GetString(message.AdditionalProperties, "tool_call_id"),
				["content"] = message.Text ?? string.Empty
			};
			yield break;
		}
		foreach (FunctionResultContent item in list)
		{
			yield return new Dictionary<string, object>
			{
				["role"] = "tool",
				["tool_call_id"] = item.CallId,
				["content"] = ConvertToolResultToText(item.Result, item.Exception)
			};
		}
	}

	private Dictionary<string, object> ToWireMessage(ChatMessage message)
	{
		if (message == null)
		{
			return null;
		}
		string value = message.Role.Value;
		Dictionary<string, object> dictionary = new Dictionary<string, object> { ["role"] = value };
		List<FunctionCallContent> list = GetFunctionCalls(message).ToList();
		string reasoning = GetReasoning(message);
		if (list.Count > 0)
		{
			dictionary["content"] = (string.IsNullOrEmpty(message.Text) ? null : message.Text);
			dictionary["tool_calls"] = list.Select(ToWireToolCall).ToList();
			dictionary["reasoning_content"] = reasoning ?? string.Empty;
			return dictionary;
		}
		object value2 = ToWireContent(message);
		dictionary["content"] = value2;
		if (message.Role == ChatRole.Assistant && !string.IsNullOrWhiteSpace(reasoning))
		{
			dictionary["reasoning_content"] = reasoning;
		}
		return dictionary;
	}

	private object ToWireContent(ChatMessage message)
	{
		if (message?.Contents == null || message.Contents.Count == 0)
		{
			return message?.Text ?? string.Empty;
		}
		List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
		foreach (AIContent content in message.Contents)
		{
			if (content is TextContent textContent && !string.IsNullOrEmpty(textContent.Text))
			{
				list.Add(new Dictionary<string, object>
				{
					["type"] = "text",
					["text"] = textContent.Text
				});
			}
			else if (content is DataContent dataContent && dataContent.HasTopLevelMediaType("image"))
			{
				list.Add(new Dictionary<string, object>
				{
					["type"] = "image_url",
					["image_url"] = new Dictionary<string, object>
					{
						["url"] = dataContent.Uri,
						["detail"] = "high"
					}
				});
			}
			else if (content is UriContent uriContent && IsImageMediaType(uriContent.MediaType))
			{
				list.Add(new Dictionary<string, object>
				{
					["type"] = "image_url",
					["image_url"] = new Dictionary<string, object>
					{
						["url"] = uriContent.Uri.ToString(),
						["detail"] = "high"
					}
				});
			}
		}
		if (list.Count == 0)
		{
			return message.Text ?? string.Empty;
		}
		if (list.Count == 1 && list[0].TryGetValue("type", out var value) && string.Equals(value?.ToString(), "text", StringComparison.Ordinal))
		{
			return list[0]["text"];
		}
		return list;
	}

	private static bool IsImageMediaType(string mediaType)
	{
		if (!string.IsNullOrWhiteSpace(mediaType))
		{
			return mediaType.StartsWith("image/", StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	private static IEnumerable<FunctionCallContent> GetFunctionCalls(ChatMessage message)
	{
		if (message?.Contents == null)
		{
			yield break;
		}
		foreach (FunctionCallContent item in message.Contents.OfType<FunctionCallContent>())
		{
			yield return item;
		}
	}

	private Dictionary<string, object> ToWireToolCall(FunctionCallContent call)
	{
		return new Dictionary<string, object>
		{
			["id"] = call.CallId,
			["type"] = "function",
			["function"] = new Dictionary<string, object>
			{
				["name"] = call.Name,
				["arguments"] = SerializeArguments(call.Arguments)
			}
		};
	}

	private List<Dictionary<string, object>> BuildTools(IList<AITool> tools)
	{
		List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
		if (tools == null)
		{
			return list;
		}
		foreach (AITool tool in tools)
		{
			if (tool is AIFunction aIFunction)
			{
				list.Add(new Dictionary<string, object>
				{
					["type"] = "function",
					["function"] = new Dictionary<string, object>
					{
						["name"] = aIFunction.Name,
						["description"] = aIFunction.Description ?? string.Empty,
						["parameters"] = ((aIFunction.JsonSchema.ValueKind == JsonValueKind.Undefined) ? new Dictionary<string, object>
						{
							["type"] = "object",
							["properties"] = new Dictionary<string, object>(),
							["additionalProperties"] = false
						} : NormalizeToolParameters(aIFunction.JsonSchema))
					}
				});
			}
		}
		return list;
	}

	private static object NormalizeToolParameters(JsonElement schema)
	{
		Dictionary<string, object> dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(schema.GetRawText(), JsonOptions) ?? new Dictionary<string, object>();
		if (!dictionary.ContainsKey("additionalProperties"))
		{
			dictionary["additionalProperties"] = false;
		}
		return dictionary;
	}

	private IEnumerable<ChatResponseUpdate> ParseStreamingChunk(string json, StreamingState state)
	{
		using JsonDocument doc = JsonDocument.Parse(json);
		JsonElement root = doc.RootElement;
		string responseId = GetString(root, "id");
		string model = GetString(root, "model");
		DateTimeOffset? createdAt = GetUnixTimestamp(root, "created");
		state.ObserveResponseMetadata(responseId, model, createdAt);
		if (root.TryGetProperty("usage", out var value) && value.ValueKind == JsonValueKind.Object)
		{
			ChatResponseUpdate chatResponseUpdate = CreateUsageUpdate(value, responseId, model, createdAt);
			if (chatResponseUpdate != null)
			{
				yield return chatResponseUpdate;
			}
		}
		if (!root.TryGetProperty("choices", out var value2) || value2.ValueKind != JsonValueKind.Array || value2.GetArrayLength() == 0)
		{
			yield break;
		}
		JsonElement element = value2[0];
		ChatFinishReason? finishReason = FromFinishReason(GetString(element, "finish_reason"));
		if (finishReason.HasValue)
		{
			state.FinishReason = finishReason;
		}
		if (!element.TryGetProperty("delta", out var delta) || delta.ValueKind != JsonValueKind.Object)
		{
			yield break;
		}
		string text = GetString(delta, "reasoning_content");
		if (!string.IsNullOrEmpty(text))
		{
			state.ReasoningText.Append(text);
			TextReasoningContent textReasoningContent = new TextReasoningContent(text);
			textReasoningContent.AdditionalProperties = new AdditionalPropertiesDictionary { ["reasoning_content"] = text };
			yield return new ChatResponseUpdate(ChatRole.Assistant, new List<AIContent> { textReasoningContent })
			{
				ResponseId = responseId,
				ModelId = model,
				CreatedAt = createdAt
			};
		}
		string text2 = GetString(delta, "content");
		if (!string.IsNullOrEmpty(text2))
		{
			if (state.BufferAnswerTextUntilOutcome)
			{
				state.AppendPendingAnswerText(text2);
			}
			else
			{
				yield return new ChatResponseUpdate(ChatRole.Assistant, text2)
				{
					ResponseId = responseId,
					ModelId = model,
					CreatedAt = createdAt
				};
			}
		}
		if (delta.TryGetProperty("tool_calls", out var value3) && value3.ValueKind == JsonValueKind.Array)
		{
			state.AppendToolCalls(value3);
			ChatResponseUpdate chatResponseUpdate2 = state.DrainPendingAnswerText(asReasoning: true);
			if (chatResponseUpdate2 != null)
			{
				yield return chatResponseUpdate2;
			}
		}
		if (finishReason.HasValue && finishReason != ChatFinishReason.ToolCalls)
		{
			ChatResponseUpdate chatResponseUpdate3 = state.DrainPendingAnswerText(asReasoning: false);
			if (chatResponseUpdate3 != null)
			{
				yield return chatResponseUpdate3;
			}
			yield return new ChatResponseUpdate
			{
				Role = ChatRole.Assistant,
				ResponseId = responseId,
				ModelId = model,
				CreatedAt = createdAt,
				FinishReason = finishReason
			};
		}
	}

	private static ChatResponseUpdate CreateUsageUpdate(JsonElement usage, string responseId, string model, DateTimeOffset? createdAt)
	{
		long? num = GetLong(usage, "prompt_tokens") ?? GetLong(usage, "input_tokens");
		long? num2 = GetLong(usage, "completion_tokens") ?? GetLong(usage, "output_tokens");
		long? num3 = GetLong(usage, "total_tokens");
		long? num4 = GetLong(usage, "prompt_cache_hit_tokens") ?? GetNestedLong(usage, "prompt_tokens_details", "cached_tokens") ?? GetNestedLong(usage, "input_tokens_details", "cached_tokens");
		long? cacheMissTokens = GetLong(usage, "prompt_cache_miss_tokens");
		if (!cacheMissTokens.HasValue && num.HasValue && num4.HasValue)
		{
			cacheMissTokens = Math.Max(0L, num.Value - num4.Value);
		}
		if (!num.HasValue && !num2.HasValue && !num3.HasValue && !num4.HasValue && !cacheMissTokens.HasValue)
		{
			return null;
		}
		UsageDetails obj = new UsageDetails
		{
			InputTokenCount = num,
			OutputTokenCount = num2,
			TotalTokenCount = (num3 ?? Sum(num, num2)),
			CachedInputTokenCount = num4
		};
		SetPromptCacheCounts(obj, num4, cacheMissTokens);
		UsageContent usageContent = new UsageContent(obj);
		if (num4.HasValue || cacheMissTokens.HasValue)
		{
			usageContent.AdditionalProperties = new AdditionalPropertiesDictionary();
			if (num4.HasValue)
			{
				usageContent.AdditionalProperties["prompt_cache_hit_tokens"] = num4.Value;
			}
			if (cacheMissTokens.HasValue)
			{
				usageContent.AdditionalProperties["prompt_cache_miss_tokens"] = cacheMissTokens.Value;
			}
		}
		return new ChatResponseUpdate
		{
			Role = ChatRole.Assistant,
			ResponseId = responseId,
			ModelId = model,
			CreatedAt = createdAt,
			Contents = new List<AIContent> { usageContent }
		};
	}

	private static UsageDetails MergeUsage(UsageDetails aggregate, UsageDetails next)
	{
		if (next == null)
		{
			return aggregate;
		}
		if (aggregate == null)
		{
			aggregate = new UsageDetails();
		}
		aggregate.InputTokenCount = Sum(aggregate.InputTokenCount, next.InputTokenCount);
		aggregate.OutputTokenCount = Sum(aggregate.OutputTokenCount, next.OutputTokenCount);
		aggregate.TotalTokenCount = Sum(aggregate.TotalTokenCount, next.TotalTokenCount);
		aggregate.CachedInputTokenCount = Sum(aggregate.CachedInputTokenCount, next.CachedInputTokenCount);
		AddPromptCacheCounts(aggregate, next);
		return aggregate;
	}

	private static void SetPromptCacheCounts(UsageDetails usage, long? cacheHitTokens, long? cacheMissTokens)
	{
		if (usage != null && (cacheHitTokens.HasValue || cacheMissTokens.HasValue))
		{
			usage.AdditionalCounts = new AdditionalPropertiesDictionary<long>();
			if (cacheHitTokens.HasValue)
			{
				usage.AdditionalCounts["prompt_cache_hit_tokens"] = cacheHitTokens.Value;
			}
			if (cacheMissTokens.HasValue)
			{
				usage.AdditionalCounts["prompt_cache_miss_tokens"] = cacheMissTokens.Value;
			}
		}
	}

	private static void AddPromptCacheCounts(UsageDetails aggregate, UsageDetails next)
	{
		AddAdditionalCount(aggregate, "prompt_cache_hit_tokens", GetAdditionalCount(next, "prompt_cache_hit_tokens"));
		AddAdditionalCount(aggregate, "prompt_cache_miss_tokens", GetAdditionalCount(next, "prompt_cache_miss_tokens"));
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

	private void RememberToolReasoning(ChatResponseUpdate update, StringBuilder reasoning)
	{
		if (update?.Contents == null || reasoning == null || reasoning.Length == 0)
		{
			return;
		}
		string reasoning2 = reasoning.ToString();
		foreach (FunctionCallContent item in update.Contents.OfType<FunctionCallContent>())
		{
			SetReasoning(item, reasoning2);
		}
		SetReasoning(update, reasoning2);
	}

	private static string GetReasoning(ChatMessage message)
	{
		if (message == null)
		{
			return null;
		}
		string text = GetString(message.AdditionalProperties, "reasoning_content");
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		IEnumerable<string> enumerable = (from c in message.Contents?.OfType<TextReasoningContent>()
			select c.Text into t
			where !string.IsNullOrEmpty(t)
			select t);
		string text2 = ((enumerable == null) ? null : string.Concat(enumerable));
		if (!string.IsNullOrWhiteSpace(text2))
		{
			return text2;
		}
		return (from c in message.Contents?.OfType<FunctionCallContent>()
			select GetString(c.AdditionalProperties, "reasoning_content")).FirstOrDefault((string v) => !string.IsNullOrWhiteSpace(v));
	}

	private static void SetReasoning(ChatMessage message, string reasoning)
	{
		if (message != null && !string.IsNullOrWhiteSpace(reasoning))
		{
			if (message.AdditionalProperties == null)
			{
				message.AdditionalProperties = new AdditionalPropertiesDictionary();
			}
			message.AdditionalProperties["reasoning_content"] = reasoning;
		}
	}

	private static void SetReasoning(AIContent content, string reasoning)
	{
		if (content != null && !string.IsNullOrWhiteSpace(reasoning))
		{
			if (content.AdditionalProperties == null)
			{
				content.AdditionalProperties = new AdditionalPropertiesDictionary();
			}
			content.AdditionalProperties["reasoning_content"] = reasoning;
		}
	}

	private static void SetReasoning(ChatResponseUpdate update, string reasoning)
	{
		if (update != null && !string.IsNullOrWhiteSpace(reasoning))
		{
			if (update.AdditionalProperties == null)
			{
				update.AdditionalProperties = new AdditionalPropertiesDictionary();
			}
			update.AdditionalProperties["reasoning_content"] = reasoning;
		}
	}

	private static string SerializeArguments(IDictionary<string, object> arguments)
	{
		if (arguments != null && arguments.Count != 0)
		{
			return JsonSerializer.Serialize(arguments, JsonOptions);
		}
		return "{}";
	}

	private static string ConvertToolResultToText(object result, Exception exception)
	{
		if (exception != null)
		{
			return "Error: " + exception.Message;
		}
		if (result == null)
		{
			return string.Empty;
		}
		if (result is string result2)
		{
			return result2;
		}
		return JsonSerializer.Serialize(result, JsonOptions);
	}

	private static Dictionary<string, object> ParseArguments(string json)
	{
		if (string.IsNullOrWhiteSpace(json))
		{
			return new Dictionary<string, object>();
		}
		try
		{
			return JsonSerializer.Deserialize<Dictionary<string, object>>(json, JsonOptions) ?? new Dictionary<string, object>();
		}
		catch
		{
			return new Dictionary<string, object>();
		}
	}

	private static string GetString(AdditionalPropertiesDictionary properties, string key)
	{
		if (properties == null || string.IsNullOrEmpty(key))
		{
			return null;
		}
		if (!properties.TryGetValue(key, out object value))
		{
			return null;
		}
		return value?.ToString();
	}

	private static string GetString(JsonElement element, string propertyName)
	{
		if (element.ValueKind != JsonValueKind.Object || !element.TryGetProperty(propertyName, out var value) || value.ValueKind == JsonValueKind.Null || value.ValueKind == JsonValueKind.Undefined)
		{
			return null;
		}
		if (value.ValueKind != JsonValueKind.String)
		{
			return value.ToString();
		}
		return value.GetString();
	}

	private static DateTimeOffset? GetUnixTimestamp(JsonElement element, string propertyName)
	{
		if (element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out var value) && value.ValueKind == JsonValueKind.Number && value.TryGetInt64(out var value2))
		{
			return DateTimeOffset.FromUnixTimeSeconds(value2);
		}
		return null;
	}

	private static long? GetLong(JsonElement element, string propertyName)
	{
		if (element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out var value) && value.ValueKind == JsonValueKind.Number && value.TryGetInt64(out var value2))
		{
			return value2;
		}
		return null;
	}

	private static long? GetNestedLong(JsonElement element, string parentName, string propertyName)
	{
		if (element.ValueKind == JsonValueKind.Object && element.TryGetProperty(parentName, out var value) && value.ValueKind == JsonValueKind.Object)
		{
			return GetLong(value, propertyName);
		}
		return null;
	}

	private static ChatFinishReason? FromFinishReason(string finishReason)
	{
		if (string.IsNullOrWhiteSpace(finishReason))
		{
			return null;
		}
		return finishReason switch
		{
			"stop" => ChatFinishReason.Stop, 
			"length" => ChatFinishReason.Length, 
			"tool_calls" => ChatFinishReason.ToolCalls, 
			"content_filter" => ChatFinishReason.ContentFilter, 
			_ => new ChatFinishReason(finishReason), 
		};
	}

	private static string NormalizeReasoningEffort(string effort)
	{
		if (string.IsNullOrWhiteSpace(effort))
		{
			return "high";
		}
		string text = effort.Trim().ToLowerInvariant();
		switch (text)
		{
		case "xhigh":
			return "max";
		case "low":
		case "medium":
			return "high";
		default:
			return text;
		}
	}

	private static string NormalizeEndpoint(string baseUrl)
	{
		string text = (string.IsNullOrWhiteSpace(baseUrl) ? "https://api.deepseek.com" : baseUrl.TrimEnd('/'));
		if (text.EndsWith("/chat/completions", StringComparison.OrdinalIgnoreCase))
		{
			return text;
		}
		return text + "/chat/completions";
	}

	private bool ShouldRequestStreamUsage()
	{
		if (!ContainsIgnoreCase(_model, "deepseek") && !ContainsIgnoreCase(_endpoint, "deepseek") && !ContainsIgnoreCase(_endpoint, "tzcpa"))
		{
			return ContainsIgnoreCase(_endpoint, "bailian");
		}
		return true;
	}

	private static bool ContainsIgnoreCase(string value, string pattern)
	{
		if (!string.IsNullOrWhiteSpace(value))
		{
			return value.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) >= 0;
		}
		return false;
	}
}
