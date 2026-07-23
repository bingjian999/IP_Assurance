using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using CPAHelper.Agent.Runtime;

namespace CPAHelper.Agent.Adapters;

public static class JsonSessionIndexManager
{
	public class SessionIndexDto
	{
		public List<SessionSummary> Sessions { get; set; } = new List<SessionSummary>();
	}

	public class SessionSummary
	{
		public string SessionId { get; set; }

		public string Title { get; set; }

		public bool IsCustomTitle { get; set; }

		public bool IsTitleGenerating { get; set; }

		public string CreatedAt { get; set; }

		public string UpdatedAt { get; set; }

		public int MessageCount { get; set; }
	}

	public class SessionDetailDto
	{
		public string SessionId { get; set; }

		public string Title { get; set; }

		public List<SessionMessageDto> Messages { get; set; } = new List<SessionMessageDto>();

		public List<RuntimeMessageDto> RuntimeMessages { get; set; }

		public long? ConversationRevision { get; set; }

		public long? RuntimeMessagesRevision { get; set; }

		public JsonElement? SerializedAgentSession { get; set; }

		public string AgentSessionFingerprint { get; set; }

		public long? AgentSessionRevision { get; set; }
	}

	public class SessionMessageDto
	{
		public string Role { get; set; }

		public string Text { get; set; }

		public List<JsonElement> Parts { get; set; }

		public string FinishReason { get; set; }
	}

	public class RuntimeMessageDto
	{
		public string Role { get; set; }

		public string Text { get; set; }

		public string ReasoningContent { get; set; }

		public List<RuntimeToolCallDto> ToolCalls { get; set; }

		public string ToolCallId { get; set; }

		public string ToolResult { get; set; }
	}

	public class RuntimeToolCallDto
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string ArgumentsJson { get; set; }
	}

	private static string _configuredSessionsDir;

	private static readonly JsonSerializerOptions WriteOptions = new JsonSerializerOptions
	{
		WriteIndented = true
	};

	private static readonly JsonSerializerOptions ReadOptions = new JsonSerializerOptions
	{
		PropertyNameCaseInsensitive = true
	};

	private static readonly object _lock = new object();

	private static string SessionsDir => _configuredSessionsDir ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config", "chat-sessions");

	private static string IndexFilePath => Path.Combine(SessionsDir, "sessions-index.json");

	public static void Initialize(string sessionsDir)
	{
		_configuredSessionsDir = sessionsDir;
	}

	public static string GetSessionsDir()
	{
		return SessionsDir;
	}

	public static List<SessionSummary> ListSessions()
	{
		lock (_lock)
		{
			return LoadIndex().Sessions.OrderByDescending((SessionSummary s) => s.UpdatedAt).ToList();
		}
	}

	public static SessionSummary CreateSession(string sessionId = null, string title = null)
	{
		lock (_lock)
		{
			SessionIndexDto sessionIndexDto = LoadIndex();
			SessionSummary sessionSummary = ((!string.IsNullOrWhiteSpace(sessionId)) ? sessionIndexDto.Sessions.FirstOrDefault((SessionSummary s) => s.SessionId == sessionId) : null);
			if (sessionSummary != null)
			{
				return sessionSummary;
			}
			SessionSummary sessionSummary2 = new SessionSummary
			{
				SessionId = (sessionId ?? GenerateSessionId()),
				Title = (title ?? "新会话"),
				IsCustomTitle = !string.IsNullOrWhiteSpace(title),
				IsTitleGenerating = false,
				CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
				UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
				MessageCount = 0
			};
			sessionIndexDto.Sessions.Add(sessionSummary2);
			SaveIndex(sessionIndexDto);
			EnsureSessionFile(sessionSummary2.SessionId);
			return sessionSummary2;
		}
	}

	public static void UpdateSessionActivity(string sessionsDir, string sessionId, string title = null, int? messageCount = null)
	{
		lock (_lock)
		{
			SessionIndexDto sessionIndexDto = LoadIndex();
			SessionSummary sessionSummary = sessionIndexDto.Sessions.FirstOrDefault((SessionSummary s) => s.SessionId == sessionId);
			if (sessionSummary != null)
			{
				sessionSummary.UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				if (!sessionSummary.IsCustomTitle && !sessionSummary.IsTitleGenerating && !string.IsNullOrWhiteSpace(title) && (string.IsNullOrWhiteSpace(sessionSummary.Title) || string.Equals(sessionSummary.Title, "新会话", StringComparison.Ordinal)))
				{
					sessionSummary.Title = title;
				}
				sessionSummary.MessageCount = messageCount ?? (sessionSummary.MessageCount + 1);
			}
			else
			{
				sessionIndexDto.Sessions.Add(new SessionSummary
				{
					SessionId = sessionId,
					Title = (title ?? "新会话"),
					IsCustomTitle = false,
					IsTitleGenerating = false,
					CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
					UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
					MessageCount = (messageCount ?? 1)
				});
			}
			SaveIndex(sessionIndexDto);
		}
	}

	public static SessionSummary SetTitleGenerationState(string sessionId, bool isGenerating)
	{
		lock (_lock)
		{
			SessionIndexDto sessionIndexDto = LoadIndex();
			SessionSummary sessionSummary = sessionIndexDto.Sessions.FirstOrDefault((SessionSummary s) => s.SessionId == sessionId);
			if (sessionSummary == null)
			{
				sessionSummary = new SessionSummary
				{
					SessionId = sessionId,
					Title = "新会话",
					IsCustomTitle = false,
					IsTitleGenerating = false,
					CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
					UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
					MessageCount = 0
				};
				sessionIndexDto.Sessions.Add(sessionSummary);
			}
			sessionSummary.IsTitleGenerating = isGenerating;
			sessionSummary.UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			SaveIndex(sessionIndexDto);
			return sessionSummary;
		}
	}

	public static SessionSummary ApplyGeneratedTitle(string sessionId, string title)
	{
		lock (_lock)
		{
			SessionIndexDto sessionIndexDto = LoadIndex();
			SessionSummary sessionSummary = sessionIndexDto.Sessions.FirstOrDefault((SessionSummary s) => s.SessionId == sessionId);
			if (sessionSummary == null)
			{
				sessionSummary = new SessionSummary
				{
					SessionId = sessionId,
					Title = "新会话",
					IsCustomTitle = false,
					IsTitleGenerating = false,
					CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
					UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
					MessageCount = 0
				};
				sessionIndexDto.Sessions.Add(sessionSummary);
			}
			sessionSummary.IsTitleGenerating = false;
			if (!sessionSummary.IsCustomTitle && !string.IsNullOrWhiteSpace(title))
			{
				sessionSummary.Title = title.Trim();
			}
			sessionSummary.UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			SaveIndex(sessionIndexDto);
			return sessionSummary;
		}
	}

	public static SessionSummary RenameSession(string sessionId, string title)
	{
		lock (_lock)
		{
			SessionIndexDto sessionIndexDto = LoadIndex();
			SessionSummary sessionSummary = sessionIndexDto.Sessions.FirstOrDefault((SessionSummary s) => s.SessionId == sessionId);
			if (sessionSummary == null)
			{
				return null;
			}
			sessionSummary.Title = (string.IsNullOrWhiteSpace(title) ? sessionSummary.Title : title.Trim());
			sessionSummary.IsCustomTitle = true;
			sessionSummary.IsTitleGenerating = false;
			sessionSummary.UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			SaveIndex(sessionIndexDto);
			return sessionSummary;
		}
	}

	public static SessionDetailDto SaveSessionDetail(string sessionId, List<SessionMessageDto> messages, List<RuntimeMessageDto> runtimeMessages = null)
	{
		lock (_lock)
		{
			EnsureDirectory();
			SessionDetailDto sessionDetailDto = ReadSessionDetailUnsafe(sessionId);
			long value = (sessionDetailDto?.ConversationRevision).GetValueOrDefault() + 1;
			List<SessionMessageDto> list = PreserveExistingMessageParts(sessionId, messages ?? new List<SessionMessageDto>());
			List<RuntimeMessageDto> runtimeMessages2 = runtimeMessages ?? PreserveExistingRuntimeMessages(sessionId);
			SessionDetailDto sessionDetailDto2 = PreserveExistingAgentSession(sessionDetailDto);
			SessionSummary sessionSummary = GetSessionSummary(sessionId) ?? CreateSession(sessionId);
			SessionDetailDto sessionDetailDto3 = new SessionDetailDto
			{
				SessionId = sessionId,
				Title = sessionSummary.Title,
				Messages = list,
				RuntimeMessages = runtimeMessages2,
				ConversationRevision = value,
				RuntimeMessagesRevision = ((runtimeMessages != null) ? new long?(value) : sessionDetailDto?.RuntimeMessagesRevision),
				SerializedAgentSession = sessionDetailDto2?.SerializedAgentSession,
				AgentSessionFingerprint = sessionDetailDto2?.AgentSessionFingerprint,
				AgentSessionRevision = sessionDetailDto2?.AgentSessionRevision
			};
			string filePath = Path.Combine(SessionsDir, sessionId + ".json");
			string content = JsonSerializer.Serialize(sessionDetailDto3, WriteOptions);
			JsonFileStore.WriteAllTextAtomic(filePath, content, Encoding.UTF8);
			SessionIndexDto sessionIndexDto = LoadIndex();
			SessionSummary sessionSummary2 = sessionIndexDto.Sessions.FirstOrDefault((SessionSummary s) => s.SessionId == sessionId);
			if (sessionSummary2 == null)
			{
				sessionSummary2 = new SessionSummary
				{
					SessionId = sessionId,
					CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
				};
				sessionIndexDto.Sessions.Add(sessionSummary2);
			}
			sessionSummary2.UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			sessionSummary2.MessageCount = list.Count;
			sessionSummary2.IsTitleGenerating = false;
			if (!sessionSummary2.IsCustomTitle && (string.IsNullOrWhiteSpace(sessionSummary2.Title) || string.Equals(sessionSummary2.Title, "新会话", StringComparison.Ordinal)))
			{
				sessionSummary2.Title = BuildAutoTitle(list);
			}
			sessionDetailDto3.Title = sessionSummary2.Title;
			SaveIndex(sessionIndexDto);
			return sessionDetailDto3;
		}
	}

	public static bool TryGetSerializedAgentSession(string sessionId, string fingerprint, out JsonElement serializedSession)
	{
		serializedSession = default(JsonElement);
		if (string.IsNullOrWhiteSpace(sessionId) || string.IsNullOrWhiteSpace(fingerprint))
		{
			return false;
		}
		lock (_lock)
		{
			SessionDetailDto sessionDetailDto = ReadSessionDetailUnsafe(sessionId);
			if (sessionDetailDto == null || !sessionDetailDto.SerializedAgentSession.HasValue)
			{
				return false;
			}
			if (!string.Equals(sessionDetailDto.AgentSessionFingerprint, fingerprint, StringComparison.Ordinal))
			{
				return false;
			}
			if (!HasConsistentAgentSessionRevision(sessionDetailDto))
			{
				return false;
			}
			serializedSession = sessionDetailDto.SerializedAgentSession.Value.Clone();
			return true;
		}
	}

	public static void SaveSerializedAgentSession(string sessionId, JsonElement serializedSession, string fingerprint)
	{
		SaveSerializedAgentSessionCore(sessionId, serializedSession, fingerprint, null);
	}

	internal static long GetConversationRevision(string sessionId)
	{
		if (string.IsNullOrWhiteSpace(sessionId))
		{
			return 0L;
		}
		lock (_lock)
		{
			return (ReadSessionDetailUnsafe(sessionId)?.ConversationRevision).GetValueOrDefault();
		}
	}

	internal static bool TrySaveSerializedAgentSession(string sessionId, JsonElement serializedSession, string fingerprint, long expectedConversationRevision)
	{
		return SaveSerializedAgentSessionCore(sessionId, serializedSession, fingerprint, expectedConversationRevision);
	}

	private static bool SaveSerializedAgentSessionCore(string sessionId, JsonElement serializedSession, string fingerprint, long? expectedConversationRevision)
	{
		if (string.IsNullOrWhiteSpace(sessionId) || string.IsNullOrWhiteSpace(fingerprint))
		{
			return false;
		}
		lock (_lock)
		{
			EnsureDirectory();
			SessionSummary sessionSummary = GetSessionSummary(sessionId) ?? CreateSession(sessionId);
			SessionDetailDto sessionDetailDto = ReadSessionDetailUnsafe(sessionId) ?? new SessionDetailDto
			{
				SessionId = sessionId,
				Title = sessionSummary.Title,
				Messages = new List<SessionMessageDto>()
			};
			long valueOrDefault = sessionDetailDto.ConversationRevision.GetValueOrDefault();
			if (expectedConversationRevision.HasValue && valueOrDefault != expectedConversationRevision.Value)
			{
				return false;
			}
			bool flag = IsLegacyRevisionEnvelope(sessionDetailDto);
			sessionDetailDto.SessionId = sessionId;
			sessionDetailDto.Title = sessionSummary.Title;
			SessionDetailDto sessionDetailDto2 = sessionDetailDto;
			if (sessionDetailDto2.Messages == null)
			{
				List<SessionMessageDto> list = (sessionDetailDto2.Messages = new List<SessionMessageDto>());
			}
			sessionDetailDto.ConversationRevision = valueOrDefault;
			sessionDetailDto.SerializedAgentSession = AgentSessionSanitizer.SanitizeSerializedSession(serializedSession);
			sessionDetailDto.AgentSessionFingerprint = fingerprint;
			sessionDetailDto.AgentSessionRevision = valueOrDefault;
			if (flag && sessionDetailDto.RuntimeMessages != null && sessionDetailDto.RuntimeMessages.Count > 0 && !sessionDetailDto.RuntimeMessagesRevision.HasValue)
			{
				sessionDetailDto.RuntimeMessagesRevision = valueOrDefault;
			}
			string filePath = Path.Combine(SessionsDir, sessionId + ".json");
			string content = JsonSerializer.Serialize(sessionDetailDto, WriteOptions);
			JsonFileStore.WriteAllTextAtomic(filePath, content, Encoding.UTF8);
			return true;
		}
	}

	private static List<SessionMessageDto> PreserveExistingMessageParts(string sessionId, List<SessionMessageDto> incomingMessages)
	{
		if (incomingMessages == null || incomingMessages.Count == 0)
		{
			return incomingMessages ?? new List<SessionMessageDto>();
		}
		string path = Path.Combine(SessionsDir, sessionId + ".json");
		if (!File.Exists(path))
		{
			return incomingMessages;
		}
		SessionDetailDto sessionDetailDto;
		try
		{
			sessionDetailDto = JsonSerializer.Deserialize<SessionDetailDto>(File.ReadAllText(path, Encoding.UTF8), ReadOptions);
		}
		catch
		{
			return incomingMessages;
		}
		List<SessionMessageDto> list = sessionDetailDto?.Messages;
		if (list == null || list.Count == 0)
		{
			return incomingMessages;
		}
		int num = 0;
		foreach (SessionMessageDto incomingMessage in incomingMessages)
		{
			if (incomingMessage?.Parts != null && incomingMessage.Parts.Count > 0)
			{
				continue;
			}
			for (int i = num; i < list.Count; i++)
			{
				SessionMessageDto sessionMessageDto = list[i];
				if (sessionMessageDto?.Parts != null && sessionMessageDto.Parts.Count != 0 && string.Equals(sessionMessageDto.Role, incomingMessage?.Role, StringComparison.OrdinalIgnoreCase) && string.Equals(sessionMessageDto.Text ?? string.Empty, incomingMessage?.Text ?? string.Empty, StringComparison.Ordinal))
				{
					incomingMessage.Parts = sessionMessageDto.Parts;
					num = i + 1;
					break;
				}
			}
		}
		return incomingMessages;
	}

	private static List<RuntimeMessageDto> PreserveExistingRuntimeMessages(string sessionId)
	{
		return ReadSessionDetailUnsafe(sessionId)?.RuntimeMessages;
	}

	private static SessionDetailDto PreserveExistingAgentSession(SessionDetailDto existingDetail)
	{
		if (existingDetail == null || !existingDetail.SerializedAgentSession.HasValue)
		{
			return null;
		}
		return new SessionDetailDto
		{
			SerializedAgentSession = existingDetail.SerializedAgentSession.Value.Clone(),
			AgentSessionFingerprint = existingDetail.AgentSessionFingerprint,
			AgentSessionRevision = existingDetail.AgentSessionRevision.GetValueOrDefault()
		};
	}

	private static bool HasConsistentAgentSessionRevision(SessionDetailDto detail)
	{
		if (detail == null)
		{
			return false;
		}
		if (!detail.ConversationRevision.HasValue && !detail.AgentSessionRevision.HasValue)
		{
			return true;
		}
		if (detail.ConversationRevision.HasValue && detail.AgentSessionRevision.HasValue)
		{
			return detail.ConversationRevision.Value == detail.AgentSessionRevision.Value;
		}
		return false;
	}

	private static bool IsLegacyRevisionEnvelope(SessionDetailDto detail)
	{
		if (detail != null && !detail.ConversationRevision.HasValue && !detail.RuntimeMessagesRevision.HasValue)
		{
			return !detail.AgentSessionRevision.HasValue;
		}
		return false;
	}

	public static void DeleteSession(string sessionId)
	{
		lock (_lock)
		{
			SessionIndexDto sessionIndexDto = LoadIndex();
			sessionIndexDto.Sessions.RemoveAll((SessionSummary s) => s.SessionId == sessionId);
			SaveIndex(sessionIndexDto);
			string path = Path.Combine(SessionsDir, sessionId + ".json");
			if (File.Exists(path))
			{
				try
				{
					File.Delete(path);
					return;
				}
				catch
				{
					return;
				}
			}
		}
	}

	public static SessionDetailDto GetSessionDetail(string sessionId)
	{
		SessionSummary sessionSummary = GetSessionSummary(sessionId);
		string path = Path.Combine(SessionsDir, sessionId + ".json");
		if (!File.Exists(path))
		{
			if (sessionSummary == null)
			{
				return null;
			}
			EnsureSessionFile(sessionId);
			return new SessionDetailDto
			{
				SessionId = sessionId,
				Title = sessionSummary.Title,
				ConversationRevision = 0L,
				Messages = new List<SessionMessageDto>()
			};
		}
		try
		{
			SessionDetailDto sessionDetailDto = JsonSerializer.Deserialize<SessionDetailDto>(File.ReadAllText(path, Encoding.UTF8), ReadOptions);
			if (sessionDetailDto != null)
			{
				sessionDetailDto.Title = sessionSummary?.Title ?? sessionDetailDto.Title;
				SessionDetailDto sessionDetailDto2 = sessionDetailDto;
				if (sessionDetailDto2.Messages == null)
				{
					List<SessionMessageDto> list = (sessionDetailDto2.Messages = new List<SessionMessageDto>());
				}
			}
			return sessionDetailDto;
		}
		catch
		{
			return null;
		}
	}

	public static SessionSummary GetSessionSummary(string sessionId)
	{
		lock (_lock)
		{
			return LoadIndex().Sessions.FirstOrDefault((SessionSummary s) => s.SessionId == sessionId);
		}
	}

	private static SessionIndexDto LoadIndex()
	{
		try
		{
			EnsureDirectory();
			if (File.Exists(IndexFilePath))
			{
				SessionIndexDto sessionIndexDto = JsonSerializer.Deserialize<SessionIndexDto>(File.ReadAllText(IndexFilePath, Encoding.UTF8), ReadOptions);
				if (sessionIndexDto?.Sessions != null)
				{
					return sessionIndexDto;
				}
			}
		}
		catch
		{
		}
		return new SessionIndexDto
		{
			Sessions = new List<SessionSummary>()
		};
	}

	private static void SaveIndex(SessionIndexDto index)
	{
		try
		{
			EnsureDirectory();
			string content = JsonSerializer.Serialize(index, WriteOptions);
			JsonFileStore.WriteAllTextAtomic(IndexFilePath, content, Encoding.UTF8);
		}
		catch
		{
		}
	}

	private static void EnsureDirectory()
	{
		if (!Directory.Exists(SessionsDir))
		{
			Directory.CreateDirectory(SessionsDir);
		}
	}

	private static void EnsureSessionFile(string sessionId)
	{
		EnsureDirectory();
		string text = Path.Combine(SessionsDir, sessionId + ".json");
		if (!File.Exists(text))
		{
			string content = JsonSerializer.Serialize(new SessionDetailDto
			{
				SessionId = sessionId,
				ConversationRevision = 0L,
				Messages = new List<SessionMessageDto>()
			}, WriteOptions);
			JsonFileStore.WriteAllTextAtomic(text, content, Encoding.UTF8);
		}
	}

	private static SessionDetailDto ReadSessionDetailUnsafe(string sessionId)
	{
		string path = Path.Combine(SessionsDir, sessionId + ".json");
		if (!File.Exists(path))
		{
			return null;
		}
		try
		{
			return JsonSerializer.Deserialize<SessionDetailDto>(File.ReadAllText(path, Encoding.UTF8), ReadOptions);
		}
		catch
		{
			return null;
		}
	}

	private static string GenerateSessionId()
	{
		return "s-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + Guid.NewGuid().ToString("N").Substring(0, 6);
	}

	private static string BuildAutoTitle(List<SessionMessageDto> messages)
	{
		string text = messages?.FirstOrDefault((SessionMessageDto m) => string.Equals(m.Role, "user", StringComparison.OrdinalIgnoreCase))?.Text?.Trim();
		if (string.IsNullOrWhiteSpace(text))
		{
			return "新会话";
		}
		if (text.Length <= 30)
		{
			return text;
		}
		return text.Substring(0, 30) + "…";
	}
}
