using System;
using System.Collections.Generic;
using System.IO;

namespace CPAHelper.Agent.Runtime;

internal static class HarnessStoragePaths
{
	internal static string ResolveSkillsPath()
	{
		foreach (string item in EnumerateSkillsPathCandidates())
		{
			if (!string.IsNullOrWhiteSpace(item) && Directory.Exists(item))
			{
				return item;
			}
		}
		return null;
	}

	internal static string EnsureSkillsPath()
	{
		string text = ResolveSkillsPath();
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		string text2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".agent", "skills");
		Directory.CreateDirectory(text2);
		return text2;
	}

	internal static string ResolveHarnessRoot(string configuredRoot, string leaf)
	{
		if (!string.IsNullOrWhiteSpace(configuredRoot))
		{
			return configuredRoot;
		}
		return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CPAHelperAgentHelper", "Agent", leaf);
	}

	private static IEnumerable<string> EnumerateSkillsPathCandidates()
	{
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		yield return Path.Combine(baseDirectory, ".agent", "skills");
		yield return Path.Combine(baseDirectory, ".claude", "skills");
	}
}
