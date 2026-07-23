using CPAHelper.Agent.Abstractions;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.Adapters;

public class JsonChatHistoryStoreFactory : IChatHistoryStoreFactory
{
	private readonly string _sessionsDir;

	public JsonChatHistoryStoreFactory()
	{
		_sessionsDir = JsonSessionIndexManager.GetSessionsDir();
	}

	public ChatHistoryProvider Create(string sessionId)
	{
		if (!string.IsNullOrEmpty(sessionId))
		{
			return new JsonChatHistoryProvider(_sessionsDir, sessionId);
		}
		return new InMemoryChatHistoryProvider();
	}
}
