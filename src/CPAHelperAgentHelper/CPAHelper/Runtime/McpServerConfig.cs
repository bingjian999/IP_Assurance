using System;
using System.Collections.Generic;
using System.Linq;

namespace CPAHelper.Agent.Runtime;

public sealed class McpServerConfig
{
	public string Id { get; set; }

	public string Name { get; set; }

	public bool Enabled { get; set; }

	public string Transport { get; set; } = "stdio";

	public string Command { get; set; }

	public List<string> Args { get; set; } = new List<string>();

	public Dictionary<string, string> Env { get; set; } = new Dictionary<string, string>(StringComparer.Ordinal);

	public List<string> Groups { get; set; } = new List<string>();

	public bool RequireApproval { get; set; } = true;

	public string WorkingDirectory { get; set; }

	public McpServerConfig Clone()
	{
		return new McpServerConfig
		{
			Id = Id,
			Name = Name,
			Enabled = Enabled,
			Transport = Transport,
			Command = Command,
			Args = (Args?.ToList() ?? new List<string>()),
			Env = ((Env != null) ? new Dictionary<string, string>(Env, StringComparer.Ordinal) : new Dictionary<string, string>(StringComparer.Ordinal)),
			Groups = (Groups?.ToList() ?? new List<string>()),
			RequireApproval = RequireApproval,
			WorkingDirectory = WorkingDirectory
		};
	}
}
