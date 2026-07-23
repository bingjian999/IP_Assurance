using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Runtime;
using AiSseStreamService3;
using Microsoft.Extensions.AI;

namespace AiConfigManager;

internal static class AiConfigManager
{
	public static Task TestConnection(string P_0, string P_1, string P_2, string P_3)
	{
		return TestConnectionAsync(new AgentConfig
		{
			Name = "Agent连接测试",
			Provider = P_0,
			ApiKey = (P_1?.Trim() ?? string.Empty),
			BaseUrl = (P_2?.Trim() ?? string.Empty),
			Model = (P_3?.Trim() ?? string.Empty)
		});
	}

	private static async Task TestConnectionAsync(AgentConfig P_0)
	{
		ValidateConfig(P_0);
		IChatClient client = null;
		IDisposable clientOwner = null;
		try
		{
			client = ChatClientFactory.CreateChatClientCore(P_0, out clientOwner);
			List<ChatMessage> messages = new List<ChatMessage>
			{
				new ChatMessage(ChatRole.User, "Agent连接测试")
			};
			await client.GetResponseAsync(messages).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			client?.Dispose();
			if (clientOwner != null && clientOwner != client)
			{
				clientOwner.Dispose();
			}
		}
	}

	private static void ValidateConfig(AgentConfig P_0)
	{
		if (P_0 == null)
		{
			throw new InvalidOperationException("配置为空，无法测试连接。");
		}
		if (string.IsNullOrWhiteSpace(P_0.ApiKey))
		{
			throw new InvalidOperationException("请先填写 API Key。");
		}
		if (!string.IsNullOrWhiteSpace(P_0.BaseUrl) && !Uri.IsWellFormedUriString(P_0.BaseUrl, UriKind.Absolute))
		{
			throw new InvalidOperationException("Base URL 格式不正确，请填写完整地址。");
		}
		if (string.IsNullOrWhiteSpace(P_0.Model))
		{
			throw new InvalidOperationException("请先填写模型名称。");
		}
	}
}
