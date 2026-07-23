using System;
using System.Collections.Generic;
using System.Linq;

namespace CPAHelper.Agent.Abstractions;

public sealed class ToolMetadata
{
	public string Name { get; set; }

	public string[] Groups { get; set; }

	public string Description { get; set; }

	public bool IsDefault { get; set; }

	public ToolMetadata()
	{
		Groups = Array.Empty<string>();
	}

	public ToolMetadata(string name, IEnumerable<string> groups, string description, bool isDefault = false)
	{
		Name = name;
		Groups = groups?.Where((string g) => !string.IsNullOrWhiteSpace(g)).ToArray() ?? Array.Empty<string>();
		Description = description;
		IsDefault = isDefault;
	}
}
