using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace CPAHelper.Agent.Runtime;

public static class McpSettingsImporter
{
	public static McpSettingsImportPreview Preview(string content, McpSettings existingSettings)
	{
		McpSettingsImportParseResult mcpSettingsImportParseResult = Parse(content);
		McpSettings mcpSettings = McpSettingsStore.NormalizeForSave(new McpSettings
		{
			Servers = mcpSettingsImportParseResult.Servers
		});
		HashSet<string> existingIds = new HashSet<string>(from server in existingSettings?.Servers ?? new List<McpServerConfig>()
			where !string.IsNullOrWhiteSpace(server?.Id)
			select server.Id, StringComparer.OrdinalIgnoreCase);
		return new McpSettingsImportPreview
		{
			Servers = mcpSettings.Servers,
			Unsupported = mcpSettingsImportParseResult.Unsupported,
			Conflicts = (from server in mcpSettings.Servers
				where existingIds.Contains(server.Id)
				select server.Id).ToList()
		};
	}

	public static McpSettings Merge(McpSettings existingSettings, IEnumerable<McpServerConfig> importedServers)
	{
		List<McpServerConfig> list = new List<McpServerConfig>();
		Dictionary<string, McpServerConfig> dictionary = (importedServers ?? Enumerable.Empty<McpServerConfig>()).Where((McpServerConfig server) => server != null && !string.IsNullOrWhiteSpace(server.Id)).ToDictionary((McpServerConfig server) => server.Id, (McpServerConfig server) => server.Clone(), StringComparer.OrdinalIgnoreCase);
		foreach (McpServerConfig item in existingSettings?.Servers ?? new List<McpServerConfig>())
		{
			if (item != null && !string.IsNullOrWhiteSpace(item.Id))
			{
				if (dictionary.TryGetValue(item.Id, out var value))
				{
					list.Add(value);
					dictionary.Remove(item.Id);
				}
				else
				{
					list.Add(item.Clone());
				}
			}
		}
		list.AddRange(dictionary.Values);
		return new McpSettings
		{
			Servers = list
		};
	}

	private static McpSettingsImportParseResult Parse(string content)
	{
		if (string.IsNullOrWhiteSpace(content))
		{
			throw new InvalidOperationException("MCP import content is empty.");
		}
		JsonDocument jsonDocument;
		try
		{
			jsonDocument = JsonDocument.Parse(content);
		}
		catch (JsonException ex)
		{
			throw new InvalidOperationException("Invalid MCP JSON: " + ex.Message, ex);
		}
		using (jsonDocument)
		{
			JsonElement rootElement = jsonDocument.RootElement;
			if (rootElement.ValueKind != JsonValueKind.Object)
			{
				throw new InvalidOperationException("MCP import JSON must be an object.");
			}
			if (TryGetProperty(rootElement, "mcpServers", out var value) && value.ValueKind == JsonValueKind.Object)
			{
				return ParseMcpServersObject(value);
			}
			if (TryGetProperty(rootElement, "servers", out var value2) && value2.ValueKind == JsonValueKind.Array)
			{
				return ParseServersArray(value2);
			}
			throw new InvalidOperationException("MCP import JSON must contain 'mcpServers' or 'servers'.");
		}
	}

	private static McpSettingsImportParseResult ParseMcpServersObject(JsonElement mcpServers)
	{
		McpSettingsImportParseResult result = new McpSettingsImportParseResult();
		foreach (JsonProperty item in mcpServers.EnumerateObject())
		{
			ParseServerElement(item.Name, item.Value, result);
		}
		return result;
	}

	private static McpSettingsImportParseResult ParseServersArray(JsonElement servers)
	{
		McpSettingsImportParseResult result = new McpSettingsImportParseResult();
		foreach (JsonElement item in servers.EnumerateArray())
		{
			ParseServerElement(GetString(item, "id"), item, result);
		}
		return result;
	}

	private static void ParseServerElement(string fallbackId, JsonElement element, McpSettingsImportParseResult result)
	{
		if (element.ValueKind != JsonValueKind.Object)
		{
			result.Unsupported.Add(new McpSettingsImportIssue
			{
				Id = fallbackId,
				Reason = "MCP server entry must be an object."
			});
			return;
		}
		string text = GetString(element, "id");
		if (string.IsNullOrWhiteSpace(text))
		{
			text = fallbackId;
		}
		string text2 = GetString(element, "transport") ?? GetString(element, "transportType") ?? GetString(element, "type");
		JsonElement value;
		bool flag = TryGetProperty(element, "baseUrl", out value) || TryGetProperty(element, "url", out value) || TryGetProperty(element, "endpoint", out value);
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = (flag ? "http" : "stdio");
		}
		if (!string.Equals(text2, "stdio", StringComparison.OrdinalIgnoreCase))
		{
			result.Unsupported.Add(new McpSettingsImportIssue
			{
				Id = text,
				Reason = "Only stdio MCP transport is supported. Found '" + text2 + "'."
			});
			return;
		}
		List<string> stringList = GetStringList(element, "groups");
		if (!string.IsNullOrWhiteSpace(text))
		{
			stringList.Add("mcp." + text.Trim());
		}
		result.Servers.Add(new McpServerConfig
		{
			Id = text,
			Name = (GetString(element, "name") ?? text),
			Enabled = (GetNullableBool(element, "enabled") ?? (GetNullableBool(element, "isActive") == true)),
			Transport = "stdio",
			Command = GetString(element, "command"),
			Args = GetStringList(element, "args"),
			Env = GetStringDictionary(element, "env"),
			Groups = stringList,
			RequireApproval = true,
			WorkingDirectory = (GetString(element, "workingDirectory") ?? GetString(element, "cwd"))
		});
	}

	private static bool TryGetProperty(JsonElement element, string name, out JsonElement value)
	{
		if (element.ValueKind == JsonValueKind.Object)
		{
			foreach (JsonProperty item in element.EnumerateObject())
			{
				if (string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase))
				{
					value = item.Value;
					return true;
				}
			}
		}
		value = default(JsonElement);
		return false;
	}

	private static string GetString(JsonElement element, string name)
	{
		if (!TryGetProperty(element, name, out var value))
		{
			return null;
		}
		if (value.ValueKind == JsonValueKind.String)
		{
			return value.GetString();
		}
		if (value.ValueKind != JsonValueKind.Null && value.ValueKind != JsonValueKind.Undefined)
		{
			return value.ToString();
		}
		return null;
	}

	private static bool? GetNullableBool(JsonElement element, string name)
	{
		if (!TryGetProperty(element, name, out var value))
		{
			return null;
		}
		if (value.ValueKind == JsonValueKind.True)
		{
			return true;
		}
		if (value.ValueKind == JsonValueKind.False)
		{
			return false;
		}
		if (value.ValueKind == JsonValueKind.String && bool.TryParse(value.GetString(), out var result))
		{
			return result;
		}
		return null;
	}

	private static List<string> GetStringList(JsonElement element, string name)
	{
		List<string> list = new List<string>();
		if (!TryGetProperty(element, name, out var value))
		{
			return list;
		}
		if (value.ValueKind == JsonValueKind.Array)
		{
			foreach (JsonElement item in value.EnumerateArray())
			{
				string text = ((item.ValueKind == JsonValueKind.String) ? item.GetString() : item.ToString());
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add(text);
				}
			}
		}
		else if (value.ValueKind == JsonValueKind.String)
		{
			list.AddRange(value.GetString().Split(new char[4] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
		}
		return list;
	}

	private static Dictionary<string, string> GetStringDictionary(JsonElement element, string name)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.Ordinal);
		if (!TryGetProperty(element, name, out var value) || value.ValueKind != JsonValueKind.Object)
		{
			return dictionary;
		}
		foreach (JsonProperty item in value.EnumerateObject())
		{
			if (!string.IsNullOrWhiteSpace(item.Name))
			{
				dictionary[item.Name] = ((item.Value.ValueKind == JsonValueKind.String) ? item.Value.GetString() : item.Value.ToString());
			}
		}
		return dictionary;
	}
}
