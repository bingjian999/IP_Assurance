using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Microsoft.Extensions.AI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CPAHelper.Agent.Runtime;

public sealed class AnthropicChatClient : IChatClient, IDisposable, IUsageTrackingChatClient
{
	private sealed class UsageContext
	{
		public UsageDetails Usage { get; set; }
	}

	[CompilerGenerated]
	private sealed class <GetStreamingResponseCoreAsync>d__17 : IAsyncEnumerable<ChatResponseUpdate>, IAsyncEnumerator<ChatResponseUpdate>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncIteratorMethodBuilder <>t__builder;

		public ManualResetValueTaskSourceCore<bool> <>v__promiseOfValueOrEnd;

		private ChatResponseUpdate <>2__current;

		private bool <>w__disposeMode;

		private CancellationTokenSource <>x__combinedTokens;

		private int <>l__initialThreadId;

		public AnthropicChatClient <>4__this;

		private IEnumerable<ChatMessage> messages;

		public IEnumerable<ChatMessage> <>3__messages;

		private ChatOptions options;

		public ChatOptions <>3__options;

		private CancellationToken cancellationToken;

		public CancellationToken <>3__cancellationToken;

		private UsageContext usageContext;

		public UsageContext <>3__usageContext;

		private HttpRequestMessage <httpRequest>5__2;

		private HttpResponseMessage <response>5__3;

		private ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter <>u__1;

		private ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter <>u__2;

		private Stream <stream>5__4;

		private ConfiguredTaskAwaitable<Stream>.ConfiguredTaskAwaiter <>u__3;

		private StreamReader <reader>5__5;

		private long? <inputTokens>5__6;

		private long? <outputTokens>5__7;

		private bool <usageEmitted>5__8;

		private Dictionary<int, JObject> <toolUseAccumulator>5__9;

		private Dictionary<int, StringBuilder> <toolJsonAccumulator>5__10;

		private HashSet<int> <thinkingBlocks>5__11;

		private int <index>5__12;

		ChatResponseUpdate IAsyncEnumerator<ChatResponseUpdate>.Current
		{
			[DebuggerHidden]
			get
			{
				return <>2__current;
			}
		}

		[DebuggerHidden]
		public <GetStreamingResponseCoreAsync>d__17(int <>1__state)
		{
			<>t__builder = AsyncIteratorMethodBuilder.Create();
			this.<>1__state = <>1__state;
			<>l__initialThreadId = Environment.CurrentManagedThreadId;
		}

		private void MoveNext()
		{
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			int num = <>1__state;
			AnthropicChatClient anthropicChatClient = <>4__this;
			try
			{
				switch (num)
				{
				default:
					if (!<>w__disposeMode)
					{
						num = (<>1__state = -1);
						string json = JsonConvert.SerializeObject(anthropicChatClient.BuildRequest(messages, options, stream: true), Formatting.None, JsonSettings);
						<httpRequest>5__2 = anthropicChatClient.CreateRequest(json);
						break;
					}
					goto end_IL_000e;
				case -8:
				case -7:
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
						<>2__current = null;
						awaiter = anthropicChatClient._httpClient.SendAsync(<httpRequest>5__2, (HttpCompletionOption)1, cancellationToken).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (<>1__state = 0);
							<>u__1 = awaiter;
							<GetStreamingResponseCoreAsync>d__17 stateMachine = this;
							<>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
							return;
						}
						goto IL_0141;
					case 0:
						awaiter = <>u__1;
						<>u__1 = default(ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter);
						num = (<>1__state = -1);
						goto IL_0141;
					case -8:
					case -7:
					case -6:
					case -5:
					case -4:
					case 1:
					case 2:
					case 3:
						break;
						IL_0141:
						result = awaiter.GetResult();
						<response>5__3 = result;
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
							if (!<response>5__3.IsSuccessStatusCode)
							{
								<>2__current = null;
								awaiter3 = <response>5__3.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (<>1__state = 1);
									<>u__2 = awaiter3;
									<GetStreamingResponseCoreAsync>d__17 stateMachine = this;
									<>t__builder.AwaitUnsafeOnCompleted(ref awaiter3, ref stateMachine);
									return;
								}
								goto IL_0210;
							}
							<>2__current = null;
							awaiter2 = <response>5__3.Content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (<>1__state = 2);
								<>u__3 = awaiter2;
								<GetStreamingResponseCoreAsync>d__17 stateMachine = this;
								<>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
								return;
							}
							goto IL_02b1;
						case 1:
							awaiter3 = <>u__2;
							<>u__2 = default(ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter);
							num = (<>1__state = -1);
							goto IL_0210;
						case 2:
							awaiter2 = <>u__3;
							<>u__3 = default(ConfiguredTaskAwaitable<Stream>.ConfiguredTaskAwaiter);
							num = (<>1__state = -1);
							goto IL_02b1;
						case -8:
						case -7:
						case -6:
						case -5:
						case -4:
						case 3:
							break;
							IL_0210:
							result2 = awaiter3.GetResult();
							throw new HttpRequestException($"Anthropic API error ({<response>5__3.StatusCode}): {result2}");
							IL_02b1:
							result3 = awaiter2.GetResult();
							<stream>5__4 = result3;
							break;
						}
						try
						{
							if ((uint)(num - -8) > 4u && num != 3)
							{
								<reader>5__5 = new StreamReader(<stream>5__4);
							}
							try
							{
								int key;
								JObject jObject;
								JToken jToken;
								ChatResponseUpdate chatResponseUpdate;
								string result4;
								ChatResponseUpdate chatResponseUpdate2;
								JObject jObject2;
								string callId;
								string name;
								string value;
								Dictionary<string, object> arguments;
								switch (num)
								{
								default:
									<inputTokens>5__6 = null;
									<outputTokens>5__7 = null;
									<usageEmitted>5__8 = false;
									<toolUseAccumulator>5__9 = new Dictionary<int, JObject>();
									<toolJsonAccumulator>5__10 = new Dictionary<int, StringBuilder>();
									<thinkingBlocks>5__11 = new HashSet<int>();
									goto IL_08f2;
								case 3:
									awaiter3 = <>u__2;
									<>u__2 = default(ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter);
									num = (<>1__state = -1);
									goto IL_03c5;
								case -4:
									num = (<>1__state = -1);
									if (!<>w__disposeMode)
									{
										goto IL_08f2;
									}
									goto end_IL_02e0;
								case -5:
									num = (<>1__state = -1);
									if (!<>w__disposeMode)
									{
										goto IL_08f2;
									}
									goto end_IL_02e0;
								case -6:
									num = (<>1__state = -1);
									if (!<>w__disposeMode)
									{
										<toolUseAccumulator>5__9.Remove(<index>5__12);
										<toolJsonAccumulator>5__10.Remove(<index>5__12);
										goto IL_07f8;
									}
									goto end_IL_02e0;
								case -7:
									num = (<>1__state = -1);
									if (!<>w__disposeMode)
									{
										goto IL_0902;
									}
									goto end_IL_02e0;
								case -8:
									{
										num = (<>1__state = -1);
										if (!<>w__disposeMode)
										{
											break;
										}
										goto end_IL_02e0;
									}
									IL_07f8:
									<thinkingBlocks>5__11.Remove(<index>5__12);
									goto IL_08f2;
									IL_08f2:
									if (!<reader>5__5.EndOfStream)
									{
										cancellationToken.ThrowIfCancellationRequested();
										<>2__current = null;
										awaiter3 = <reader>5__5.ReadLineAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
										if (!awaiter3.IsCompleted)
										{
											num = (<>1__state = 3);
											<>u__2 = awaiter3;
											<GetStreamingResponseCoreAsync>d__17 stateMachine = this;
											<>t__builder.AwaitUnsafeOnCompleted(ref awaiter3, ref stateMachine);
											return;
										}
										goto IL_03c5;
									}
									goto IL_0902;
									IL_055d:
									key = jObject.Value<int>("index");
									jToken = jObject["delta"];
									switch (jToken?.Value<string>("type"))
									{
									case "text_delta":
									{
										string text3 = jToken.Value<string>("text");
										if (string.IsNullOrEmpty(text3))
										{
											break;
										}
										<>2__current = new ChatResponseUpdate
										{
											Role = ChatRole.Assistant,
											Contents = new List<AIContent>
											{
												new TextContent(text3)
											}
										};
										num = (<>1__state = -4);
										goto end_IL_02c3;
									}
									case "thinking_delta":
									{
										string text2 = jToken.Value<string>("thinking");
										if (string.IsNullOrEmpty(text2))
										{
											break;
										}
										<>2__current = new ChatResponseUpdate
										{
											Role = ChatRole.Assistant,
											Contents = new List<AIContent>
											{
												new TextReasoningContent(text2)
											}
										};
										num = (<>1__state = -5);
										goto end_IL_02c3;
									}
									case "input_json_delta":
									{
										string text = jToken.Value<string>("partial_json");
										if (<toolJsonAccumulator>5__10.ContainsKey(key) && text != null)
										{
											<toolJsonAccumulator>5__10[key].Append(text);
										}
										break;
									}
									}
									goto IL_08f2;
									IL_0890:
									SetUsage(usageContext, <inputTokens>5__6, <outputTokens>5__7);
									chatResponseUpdate = CreateUsageUpdate(<inputTokens>5__6, <outputTokens>5__7);
									if (chatResponseUpdate == null)
									{
										goto IL_0902;
									}
									<usageEmitted>5__8 = true;
									<>2__current = chatResponseUpdate;
									num = (<>1__state = -7);
									goto end_IL_02c3;
									IL_03c5:
									result4 = awaiter3.GetResult();
									if (!string.IsNullOrEmpty(result4) && result4.StartsWith("data: "))
									{
										string text4 = result4.Substring(6);
										if (text4 == "[DONE]")
										{
											goto IL_0902;
										}
										try
										{
											jObject = JObject.Parse(text4);
										}
										catch
										{
											goto IL_08f2;
										}
										switch (jObject.Value<string>("type"))
										{
										case "message_start":
										{
											JToken jToken3 = jObject["message"]?["usage"];
											if (jToken3 != null)
											{
												<inputTokens>5__6 = jToken3.Value<long?>("input_tokens") ?? <inputTokens>5__6;
												<outputTokens>5__7 = jToken3.Value<long?>("output_tokens") ?? <outputTokens>5__7;
											}
											goto IL_08f2;
										}
										case "content_block_start":
											break;
										case "content_block_delta":
											goto IL_055d;
										case "content_block_stop":
											goto IL_06f7;
										case "message_delta":
										{
											JToken jToken2 = jObject["usage"];
											if (jToken2 != null)
											{
												<inputTokens>5__6 = jToken2.Value<long?>("input_tokens") ?? <inputTokens>5__6;
												<outputTokens>5__7 = jToken2.Value<long?>("output_tokens") ?? <outputTokens>5__7;
											}
											goto IL_08f2;
										}
										case "message_stop":
											goto IL_0890;
										default:
											goto IL_08f2;
										}
										int num2 = jObject.Value<int>("index");
										JToken jToken4 = jObject["content_block"];
										string text5 = jToken4?.Value<string>("type");
										if (text5 == "tool_use")
										{
											<toolUseAccumulator>5__9[num2] = (JObject)jToken4;
											<toolJsonAccumulator>5__10[num2] = new StringBuilder();
										}
										else if (text5 == "thinking")
										{
											<thinkingBlocks>5__11.Add(num2);
										}
									}
									goto IL_08f2;
									IL_0902:
									SetUsage(usageContext, <inputTokens>5__6, <outputTokens>5__7);
									if (<usageEmitted>5__8)
									{
										break;
									}
									chatResponseUpdate2 = CreateUsageUpdate(<inputTokens>5__6, <outputTokens>5__7);
									if (chatResponseUpdate2 == null)
									{
										break;
									}
									<>2__current = chatResponseUpdate2;
									num = (<>1__state = -8);
									goto end_IL_02c3;
									IL_06f7:
									<index>5__12 = jObject.Value<int>("index");
									if (!<toolUseAccumulator>5__9.ContainsKey(<index>5__12))
									{
										goto IL_07f8;
									}
									jObject2 = <toolUseAccumulator>5__9[<index>5__12];
									callId = jObject2.Value<string>("id");
									name = jObject2.Value<string>("name");
									value = <toolJsonAccumulator>5__10[<index>5__12].ToString();
									arguments = (string.IsNullOrEmpty(value) ? new Dictionary<string, object>() : JsonConvert.DeserializeObject<Dictionary<string, object>>(value));
									<>2__current = new ChatResponseUpdate
									{
										Role = ChatRole.Assistant,
										Contents = new List<AIContent>
										{
											new FunctionCallContent(callId, name, arguments)
										}
									};
									num = (<>1__state = -6);
									goto end_IL_02c3;
								}
								<toolUseAccumulator>5__9 = null;
								<toolJsonAccumulator>5__10 = null;
								<thinkingBlocks>5__11 = null;
								end_IL_02e0:;
							}
							finally
							{
								if (num == -1 && <reader>5__5 != null)
								{
									((IDisposable)<reader>5__5).Dispose();
								}
							}
							if (!<>w__disposeMode)
							{
								<reader>5__5 = null;
							}
							goto IL_09b8;
							end_IL_02c3:;
						}
						finally
						{
							if (num == -1 && <stream>5__4 != null)
							{
								((IDisposable)<stream>5__4).Dispose();
							}
						}
						goto end_IL_0151;
						IL_09b8:
						if (!<>w__disposeMode)
						{
							<stream>5__4 = null;
						}
						goto IL_09e1;
						end_IL_0151:;
					}
					finally
					{
						if (num == -1 && <response>5__3 != null)
						{
							((IDisposable)<response>5__3).Dispose();
						}
					}
					goto end_IL_008a;
					IL_09e1:
					if (!<>w__disposeMode)
					{
						<response>5__3 = null;
					}
					goto IL_0a0a;
					end_IL_008a:;
				}
				finally
				{
					if (num == -1 && <httpRequest>5__2 != null)
					{
						((IDisposable)<httpRequest>5__2).Dispose();
					}
				}
				goto IL_0b05;
				IL_0a0a:
				if (!<>w__disposeMode)
				{
					<httpRequest>5__2 = null;
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				<>1__state = -2;
				<httpRequest>5__2 = null;
				<response>5__3 = null;
				<stream>5__4 = null;
				<reader>5__5 = null;
				<toolUseAccumulator>5__9 = null;
				<toolJsonAccumulator>5__10 = null;
				<thinkingBlocks>5__11 = null;
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
			<httpRequest>5__2 = null;
			<response>5__3 = null;
			<stream>5__4 = null;
			<reader>5__5 = null;
			<toolUseAccumulator>5__9 = null;
			<toolJsonAccumulator>5__10 = null;
			<thinkingBlocks>5__11 = null;
			if (<>x__combinedTokens != null)
			{
				<>x__combinedTokens.Dispose();
				<>x__combinedTokens = null;
			}
			<>2__current = null;
			<>t__builder.Complete();
			<>v__promiseOfValueOrEnd.SetResult(result: false);
			return;
			IL_0b05:
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
			<GetStreamingResponseCoreAsync>d__17 <GetStreamingResponseCoreAsync>d__18;
			if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
			{
				<>1__state = -3;
				<>t__builder = AsyncIteratorMethodBuilder.Create();
				<>w__disposeMode = false;
				<GetStreamingResponseCoreAsync>d__18 = this;
			}
			else
			{
				<GetStreamingResponseCoreAsync>d__18 = new <GetStreamingResponseCoreAsync>d__17(-3)
				{
					<>4__this = <>4__this
				};
			}
			<GetStreamingResponseCoreAsync>d__18.messages = <>3__messages;
			<GetStreamingResponseCoreAsync>d__18.options = <>3__options;
			<GetStreamingResponseCoreAsync>d__18.usageContext = <>3__usageContext;
			if (<>3__cancellationToken.Equals(default(CancellationToken)))
			{
				<GetStreamingResponseCoreAsync>d__18.cancellationToken = cancellationToken;
			}
			else if (cancellationToken.Equals(<>3__cancellationToken) || cancellationToken.Equals(default(CancellationToken)))
			{
				<GetStreamingResponseCoreAsync>d__18.cancellationToken = <>3__cancellationToken;
			}
			else
			{
				<>x__combinedTokens = CancellationTokenSource.CreateLinkedTokenSource(<>3__cancellationToken, cancellationToken);
				<GetStreamingResponseCoreAsync>d__18.cancellationToken = <>x__combinedTokens.Token;
			}
			return <GetStreamingResponseCoreAsync>d__18;
		}

		[DebuggerHidden]
		ValueTask<bool> IAsyncEnumerator<ChatResponseUpdate>.MoveNextAsync()
		{
			if (<>1__state == -2)
			{
				return default(ValueTask<bool>);
			}
			<>v__promiseOfValueOrEnd.Reset();
			<GetStreamingResponseCoreAsync>d__17 stateMachine = this;
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
			<GetStreamingResponseCoreAsync>d__17 stateMachine = this;
			<>t__builder.MoveNext(ref stateMachine);
			return new ValueTask(this, <>v__promiseOfValueOrEnd.Version);
		}
	}

	private readonly HttpClient _httpClient;

	private readonly string _apiKey;

	private readonly string _endpoint;

	private readonly string _model;

	private readonly bool _ownsHttpClient;

	private readonly AsyncLocal<UsageContext> _usageContext = new AsyncLocal<UsageContext>();

	private const string AnthropicVersion = "2023-06-01";

	private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
	{
		NullValueHandling = NullValueHandling.Ignore
	};

	public ChatClientMetadata Metadata => new ChatClientMetadata("anthropic", null, _model);

	internal HttpClient Transport => _httpClient;

	public AnthropicChatClient(string apiKey, string baseUrl, string model)
		: this(apiKey, baseUrl, model, null, ownsHttpClient: true)
	{
	}

	internal AnthropicChatClient(string apiKey, string baseUrl, string model, HttpClient httpClient)
		: this(apiKey, baseUrl, model, httpClient, ownsHttpClient: true)
	{
	}

	internal AnthropicChatClient(string apiKey, string baseUrl, string model, HttpClient httpClient, bool ownsHttpClient)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(apiKey))
		{
			throw new ArgumentNullException("apiKey");
		}
		if (string.IsNullOrWhiteSpace(model))
		{
			throw new ArgumentNullException("model");
		}
		_apiKey = apiKey;
		_model = model;
		_endpoint = (string.IsNullOrWhiteSpace(baseUrl) ? "https://api.anthropic.com" : baseUrl.TrimEnd('/')) + "/v1/messages";
		_httpClient = (HttpClient)(((object)httpClient) ?? ((object)new HttpClient()));
		_ownsHttpClient = httpClient == null || ownsHttpClient;
	}

	public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		UsageContext usageContext = BeginUsageContext();
		return GetResponseCoreAsync(messages, options, usageContext, cancellationToken);
	}

	private async Task<ChatResponse> GetResponseCoreAsync(IEnumerable<ChatMessage> messages, ChatOptions options, UsageContext usageContext, CancellationToken cancellationToken)
	{
		string json = JsonConvert.SerializeObject(BuildRequest(messages, options, stream: false), Formatting.None, JsonSettings);
		HttpRequestMessage httpRequest = CreateRequest(json);
		try
		{
			HttpResponseMessage response = await ((HttpMessageInvoker)_httpClient).SendAsync(httpRequest, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				string text = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
				if (!response.IsSuccessStatusCode)
				{
					throw new HttpRequestException($"Anthropic API error ({response.StatusCode}): {text}");
				}
				JObject result = JObject.Parse(text);
				return ParseResponse(result, usageContext);
			}
			finally
			{
				((IDisposable)response)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)httpRequest)?.Dispose();
		}
	}

	public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		UsageContext usageContext = BeginUsageContext();
		return GetStreamingResponseCoreAsync(messages, options, usageContext, cancellationToken);
	}

	[AsyncIteratorStateMachine(typeof(<GetStreamingResponseCoreAsync>d__17))]
	private IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseCoreAsync(IEnumerable<ChatMessage> messages, ChatOptions options, UsageContext usageContext, [EnumeratorCancellation] CancellationToken cancellationToken)
	{
		return new <GetStreamingResponseCoreAsync>d__17(-2)
		{
			<>4__this = this,
			<>3__messages = messages,
			<>3__options = options,
			<>3__usageContext = usageContext,
			<>3__cancellationToken = cancellationToken
		};
	}

	public object GetService(Type serviceType, object serviceKey = null)
	{
		if (serviceType == typeof(AnthropicChatClient))
		{
			return this;
		}
		if (serviceType == typeof(IUsageTrackingChatClient))
		{
			return this;
		}
		return null;
	}

	public void ResetUsage()
	{
		BeginUsageContext();
	}

	public UsageDetails GetUsageSnapshot()
	{
		return CloneUsage(_usageContext.Value?.Usage);
	}

	public void Dispose()
	{
		if (_ownsHttpClient)
		{
			HttpClient httpClient = _httpClient;
			if (httpClient != null)
			{
				((HttpMessageInvoker)httpClient).Dispose();
			}
		}
	}

	private object BuildRequest(IEnumerable<ChatMessage> messages, ChatOptions options, bool stream)
	{
		List<ChatMessage> list = messages.ToList();
		string value = null;
		List<object> list2 = new List<object>();
		foreach (ChatMessage item in list)
		{
			if (item.Role == ChatRole.System)
			{
				value = GetTextContent(item);
			}
			else if (item.Role == ChatRole.Assistant)
			{
				List<object> list3 = BuildAssistantContent(item);
				if (list3.Count > 0)
				{
					list2.Add(new
					{
						role = "assistant",
						content = list3
					});
				}
			}
			else if (item.Role == ChatRole.Tool)
			{
				List<object> list4 = BuildToolResultContent(item);
				if (list4.Count > 0)
				{
					list2.Add(new
					{
						role = "user",
						content = list4
					});
				}
			}
			else
			{
				list2.Add(new
				{
					role = "user",
					content = GetTextContent(item)
				});
			}
		}
		int num = options?.MaxOutputTokens ?? 4096;
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			["model"] = _model,
			["messages"] = list2,
			["max_tokens"] = num,
			["stream"] = stream
		};
		if (!string.IsNullOrEmpty(value))
		{
			dictionary["system"] = value;
		}
		if (options != null && options.Temperature.HasValue)
		{
			dictionary["temperature"] = options.Temperature.Value;
		}
		if (options != null && options.TopP.HasValue)
		{
			dictionary["top_p"] = options.TopP.Value;
		}
		if (options?.Reasoning != null && options.Reasoning.Effort.HasValue)
		{
			int num2 = MapReasoningBudget(options.Reasoning.Effort.Value, num);
			dictionary["thinking"] = new Dictionary<string, object>
			{
				["type"] = "enabled",
				["budget_tokens"] = num2
			};
			if (num <= num2)
			{
				dictionary["max_tokens"] = num2 + 4096;
			}
		}
		if (options?.Tools != null && options.Tools.Count > 0)
		{
			List<object> list5 = new List<object>();
			foreach (AITool tool in options.Tools)
			{
				if (tool is AIFunction func)
				{
					list5.Add(BuildToolDefinition(func));
				}
			}
			if (list5.Count > 0)
			{
				dictionary["tools"] = list5;
			}
		}
		return dictionary;
	}

	private static int MapReasoningBudget(ReasoningEffort effort, int maxOutputTokens)
	{
		return effort switch
		{
			ReasoningEffort.Low => 1024, 
			ReasoningEffort.High => Math.Max(10240, maxOutputTokens), 
			_ => Math.Max(4096, maxOutputTokens / 2), 
		};
	}

	private static object BuildToolDefinition(AIFunction func)
	{
		JsonElement jsonSchema = func.JsonSchema;
		JObject input_schema = ((jsonSchema.ValueKind != JsonValueKind.Undefined) ? JObject.Parse(jsonSchema.GetRawText()) : new JObject
		{
			["type"] = "object",
			["properties"] = new JObject()
		});
		return new
		{
			name = func.Name,
			description = (func.Description ?? ""),
			input_schema = input_schema
		};
	}

	private static string GetTextContent(ChatMessage msg)
	{
		if (msg.Contents != null)
		{
			foreach (AIContent content in msg.Contents)
			{
				if (content is TextContent textContent)
				{
					return textContent.Text;
				}
			}
		}
		return msg.Text ?? "";
	}

	private static List<object> BuildAssistantContent(ChatMessage msg)
	{
		List<object> list = new List<object>();
		if (msg.Contents != null)
		{
			foreach (AIContent content in msg.Contents)
			{
				if (content is TextContent textContent && !string.IsNullOrEmpty(textContent.Text))
				{
					list.Add(new
					{
						type = "text",
						text = textContent.Text
					});
				}
				else if (content is FunctionCallContent functionCallContent)
				{
					list.Add(new
					{
						type = "tool_use",
						id = functionCallContent.CallId,
						name = functionCallContent.Name,
						input = (functionCallContent.Arguments ?? new Dictionary<string, object>())
					});
				}
			}
		}
		if (list.Count == 0 && !string.IsNullOrEmpty(msg.Text))
		{
			list.Add(new
			{
				type = "text",
				text = msg.Text
			});
		}
		return list;
	}

	private static List<object> BuildToolResultContent(ChatMessage msg)
	{
		List<object> list = new List<object>();
		if (msg.Contents != null)
		{
			foreach (AIContent content in msg.Contents)
			{
				if (content is FunctionResultContent functionResultContent)
				{
					list.Add(new
					{
						type = "tool_result",
						tool_use_id = functionResultContent.CallId,
						content = (functionResultContent.Result?.ToString() ?? "")
					});
				}
			}
		}
		return list;
	}

	private ChatResponse ParseResponse(JObject result, UsageContext usageContext)
	{
		JArray jArray = result["content"] as JArray;
		List<AIContent> list = new List<AIContent>();
		if (jArray != null)
		{
			foreach (JToken item in jArray)
			{
				switch (item.Value<string>("type"))
				{
				case "text":
				{
					string text2 = item.Value<string>("text");
					list.Add(new TextContent(text2));
					break;
				}
				case "thinking":
				{
					string text = item.Value<string>("thinking");
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(new TextReasoningContent(text));
					}
					break;
				}
				case "tool_use":
				{
					string callId = item.Value<string>("id");
					string name = item.Value<string>("name");
					JToken jToken = item["input"];
					Dictionary<string, object> arguments = ((jToken != null) ? JsonConvert.DeserializeObject<Dictionary<string, object>>(jToken.ToString()) : new Dictionary<string, object>());
					list.Add(new FunctionCallContent(callId, name, arguments));
					break;
				}
				}
			}
		}
		ChatResponse chatResponse = new ChatResponse(new ChatMessage(ChatRole.Assistant, list));
		JToken jToken2 = result["usage"];
		if (jToken2 != null)
		{
			chatResponse.Usage = new UsageDetails
			{
				InputTokenCount = jToken2.Value<long?>("input_tokens"),
				OutputTokenCount = jToken2.Value<long?>("output_tokens"),
				TotalTokenCount = jToken2.Value<long?>("input_tokens").GetValueOrDefault() + jToken2.Value<long?>("output_tokens").GetValueOrDefault()
			};
			SetUsage(usageContext, chatResponse.Usage.InputTokenCount, chatResponse.Usage.OutputTokenCount);
		}
		switch (result.Value<string>("stop_reason"))
		{
		case "end_turn":
		case "stop":
			chatResponse.FinishReason = ChatFinishReason.Stop;
			break;
		case "tool_use":
			chatResponse.FinishReason = ChatFinishReason.ToolCalls;
			break;
		case "max_tokens":
			chatResponse.FinishReason = ChatFinishReason.Length;
			break;
		}
		return chatResponse;
	}

	private UsageContext BeginUsageContext()
	{
		UsageContext usageContext = new UsageContext();
		_usageContext.Value = usageContext;
		return usageContext;
	}

	private static void SetUsage(UsageContext context, long? inputTokens, long? outputTokens)
	{
		if (context != null)
		{
			if (!inputTokens.HasValue && !outputTokens.HasValue)
			{
				context.Usage = null;
				return;
			}
			context.Usage = new UsageDetails
			{
				InputTokenCount = inputTokens,
				OutputTokenCount = outputTokens,
				TotalTokenCount = inputTokens.GetValueOrDefault() + outputTokens.GetValueOrDefault()
			};
		}
	}

	private HttpRequestMessage CreateRequest(string json)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		HttpRequestMessage val = new HttpRequestMessage(HttpMethod.Post, _endpoint)
		{
			Content = (HttpContent)new StringContent(json, Encoding.UTF8, "application/json")
		};
		((HttpHeaders)val.Headers).TryAddWithoutValidation("x-api-key", _apiKey);
		val.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
		((HttpHeaders)val.Headers).TryAddWithoutValidation("anthropic-version", "2023-06-01");
		return val;
	}

	private static ChatResponseUpdate CreateUsageUpdate(long? inputTokens, long? outputTokens)
	{
		if (!inputTokens.HasValue && !outputTokens.HasValue)
		{
			return null;
		}
		return new ChatResponseUpdate
		{
			Role = ChatRole.Assistant,
			Contents = new List<AIContent>
			{
				new UsageContent(new UsageDetails
				{
					InputTokenCount = inputTokens,
					OutputTokenCount = outputTokens,
					TotalTokenCount = inputTokens.GetValueOrDefault() + outputTokens.GetValueOrDefault()
				})
			}
		};
	}

	private static UsageDetails CloneUsage(UsageDetails usage)
	{
		if (usage == null)
		{
			return null;
		}
		return new UsageDetails
		{
			InputTokenCount = usage.InputTokenCount,
			OutputTokenCount = usage.OutputTokenCount,
			TotalTokenCount = usage.TotalTokenCount
		};
	}
}
