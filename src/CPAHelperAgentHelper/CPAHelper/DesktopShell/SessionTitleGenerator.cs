using System;
using System.Linq;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Adapters;
using CPAHelper.Agent.Runtime;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class SessionTitleGenerator
{
	private readonly IAgentConfigProvider _configProvider;

	public SessionTitleGenerator(IAgentConfigProvider configProvider)
	{
		_configProvider = configProvider ?? throw new ArgumentNullException("configProvider");
	}

	public static bool ShouldGenerateTitle(JsonSessionIndexManager.SessionSummary sessionSummary, string firstUserMessage)
	{
		if (sessionSummary != null && !sessionSummary.IsCustomTitle && sessionSummary.MessageCount == 0)
		{
			return !string.IsNullOrWhiteSpace(firstUserMessage);
		}
		return false;
	}

	public async Task GenerateInBackgroundAsync(string threadId, string firstUserMessage)
	{
		try
		{
			JsonSessionIndexManager.ApplyGeneratedTitle(threadId, await GenerateAsync(firstUserMessage).ConfigureAwait(continueOnCapturedContext: false));
		}
		catch
		{
			JsonSessionIndexManager.ApplyGeneratedTitle(threadId, null);
		}
	}

	private async Task<string> GenerateAsync(string firstUserMessage)
	{
		AgentConfig activeConfig = _configProvider.GetActiveConfig();
		if (activeConfig == null || !activeConfig.IsValid())
		{
			return BuildFallbackTitle(firstUserMessage);
		}
		IDisposable clientOwner = null;
		IChatClient titleClient = null;
		try
		{
			titleClient = ChatClientFactory.CreateChatClientCore(activeConfig, out clientOwner);
			return SanitizeTitle(ExtractPlainText(await titleClient.GetResponseAsync(new ChatMessage[2]
			{
				new ChatMessage(ChatRole.System, "你是一个会话标题生成器。请根据用户的第一条消息生成一个简洁、专业、可读的中文标题。要求：1. 8到16个字为宜；2. 不要引号、句号、编号；3. 直接输出标题文本，不要解释；4. 如果信息不足，概括核心意图。"),
				new ChatMessage(ChatRole.User, firstUserMessage)
			}, new ChatOptions
			{
				Temperature = 0.2f,
				MaxOutputTokens = 32
			}).ConfigureAwait(continueOnCapturedContext: false)), firstUserMessage);
		}
		catch
		{
			return BuildFallbackTitle(firstUserMessage);
		}
		finally
		{
			titleClient?.Dispose();
			if (clientOwner != null && clientOwner != titleClient)
			{
				clientOwner.Dispose();
			}
		}
	}

	private static string ExtractPlainText(ChatResponse response)
	{
		if (response == null)
		{
			return string.Empty;
		}
		if (!string.IsNullOrWhiteSpace(response.Text))
		{
			return response.Text;
		}
		if (response.Messages != null)
		{
			string text = string.Concat(from content in response.Messages.Where((ChatMessage message) => message?.Contents != null).SelectMany((ChatMessage message) => message.Contents.OfType<TextContent>())
				select content.Text);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
		}
		return string.Empty;
	}

	private static string SanitizeTitle(string title, string fallbackSource)
	{
		string text = (title ?? string.Empty).Replace("\r", " ").Replace("\n", " ").Trim()
			.Trim('"', '\'', '“', '”', '‘', '’', '。', '，', ',', '.', '：', ':', '；', ';');
		if (string.IsNullOrWhiteSpace(text))
		{
			return BuildFallbackTitle(fallbackSource);
		}
		if (text.Length > 20)
		{
			text = text.Substring(0, 20).Trim();
		}
		return text;
	}

	private static string BuildFallbackTitle(string source)
	{
		string text = (source ?? string.Empty).Replace("\r", " ").Replace("\n", " ").Trim();
		if (string.IsNullOrWhiteSpace(text))
		{
			return "新会话";
		}
		if (text.Length <= 18)
		{
			return text;
		}
		return text.Substring(0, 18).Trim() + "…";
	}
}
