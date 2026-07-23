using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace CPAHelper.Agent.Runtime;

public static class McpSettingsStore
{
	private const string FileName = "mcp.json";

	private static readonly Regex IdPattern = new Regex("^[A-Za-z0-9][A-Za-z0-9_-]{0,63}$", RegexOptions.Compiled);

	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		PropertyNameCaseInsensitive = true,
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		WriteIndented = true,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
	};

	public static string ResolvePath()
	{
		return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".agent", "mcp.json");
	}

	public static McpSettingsSnapshot Read()
	{
		string path = ResolvePath();
		if (!File.Exists(path))
		{
			return new McpSettingsSnapshot(path, new McpSettings());
		}
		string text = File.ReadAllText(path, Encoding.UTF8);
		McpSettings settings = (string.IsNullOrWhiteSpace(text) ? new McpSettings() : (JsonSerializer.Deserialize<McpSettings>(text, JsonOptions) ?? new McpSettings()));
		return new McpSettingsSnapshot(path, Normalize(settings, validateForSave: false));
	}

	public static McpSettingsSnapshot Save(McpSettings settings)
	{
		McpSettings mcpSettings = Normalize(settings ?? new McpSettings(), validateForSave: true);
		string path = ResolvePath();
		string directoryName = Path.GetDirectoryName(path);
		if (!string.IsNullOrWhiteSpace(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		File.WriteAllText(path, JsonSerializer.Serialize(mcpSettings, JsonOptions), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
		return new McpSettingsSnapshot(path, mcpSettings);
	}

	public static McpSettings NormalizeForSave(McpSettings settings)
	{
		return Normalize(settings ?? new McpSettings(), validateForSave: true);
	}

	public static McpServerConfig NormalizeServerForTest(McpServerConfig server)
	{
		return Normalize(new McpSettings
		{
			Servers = new List<McpServerConfig> { server ?? new McpServerConfig() }
		}, validateForSave: true).Servers[0];
	}

	private static McpSettings Normalize(McpSettings settings, bool validateForSave)
	{
		McpSettings mcpSettings = new McpSettings();
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		foreach (McpServerConfig item in settings.Servers ?? new List<McpServerConfig>())
		{
			if (item != null)
			{
				McpServerConfig mcpServerConfig = item.Clone();
				mcpServerConfig.Id = (mcpServerConfig.Id ?? string.Empty).Trim();
				mcpServerConfig.Name = (string.IsNullOrWhiteSpace(mcpServerConfig.Name) ? mcpServerConfig.Id : mcpServerConfig.Name.Trim());
				mcpServerConfig.Transport = (string.IsNullOrWhiteSpace(mcpServerConfig.Transport) ? "stdio" : mcpServerConfig.Transport.Trim().ToLowerInvariant());
				mcpServerConfig.Command = mcpServerConfig.Command?.Trim();
				mcpServerConfig.WorkingDirectory = (string.IsNullOrWhiteSpace(mcpServerConfig.WorkingDirectory) ? null : mcpServerConfig.WorkingDirectory.Trim());
				mcpServerConfig.Args = (from arg in mcpServerConfig.Args ?? new List<string>()
					where arg != null
					select arg.Trim() into arg
					where arg.Length > 0
					select arg).ToList();
				mcpServerConfig.Groups = (from @group in mcpServerConfig.Groups ?? new List<string>()
					where !string.IsNullOrWhiteSpace(@group)
					select @group.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
				mcpServerConfig.Env = (mcpServerConfig.Env ?? new Dictionary<string, string>()).Where((KeyValuePair<string, string> pair) => !string.IsNullOrWhiteSpace(pair.Key)).ToDictionary((KeyValuePair<string, string> pair) => pair.Key.Trim(), (KeyValuePair<string, string> pair) => pair.Value ?? string.Empty, StringComparer.Ordinal);
				if (validateForSave)
				{
					ValidateServer(mcpServerConfig, hashSet);
				}
				if (!string.IsNullOrWhiteSpace(mcpServerConfig.Id))
				{
					hashSet.Add(mcpServerConfig.Id);
				}
				mcpSettings.Servers.Add(mcpServerConfig);
			}
		}
		return mcpSettings;
	}

	private static void ValidateServer(McpServerConfig server, HashSet<string> usedIds)
	{
		if (string.IsNullOrWhiteSpace(server.Id) || !IdPattern.IsMatch(server.Id))
		{
			throw new InvalidOperationException("MCP server id must start with a letter or number and contain only letters, numbers, '_' or '-'.");
		}
		if (!usedIds.Add(server.Id))
		{
			throw new InvalidOperationException("Duplicate MCP server id: " + server.Id);
		}
		if (!string.Equals(server.Transport, "stdio", StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException("Only stdio MCP transport is supported in this version.");
		}
		if (server.Enabled && string.IsNullOrWhiteSpace(server.Command))
		{
			throw new InvalidOperationException("MCP server '" + server.Id + "' is enabled but command is empty.");
		}
	}
}
