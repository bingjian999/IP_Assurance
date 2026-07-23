using System;
using System.IO;
using System.Text;

namespace CPAHelper.Agent.Runtime;

internal static class AgentsFileStore
{
	internal const string FileName = "AGENTS.md";

	internal static string ResolvePath()
	{
		return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".agent", "AGENTS.md");
	}

	internal static AgentsFileSnapshot Read()
	{
		string path = EnsureFile();
		return new AgentsFileSnapshot(path, File.ReadAllText(path, Encoding.UTF8));
	}

	internal static AgentsFileSnapshot Save(string content)
	{
		string path = EnsureFile();
		File.WriteAllText(path, content ?? string.Empty, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
		return new AgentsFileSnapshot(path, content ?? string.Empty);
	}

	private static string EnsureFile()
	{
		string text = ResolvePath();
		string directoryName = Path.GetDirectoryName(text);
		if (!string.IsNullOrWhiteSpace(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		if (!File.Exists(text))
		{
			using (File.Create(text))
			{
			}
		}
		return text;
	}
}
