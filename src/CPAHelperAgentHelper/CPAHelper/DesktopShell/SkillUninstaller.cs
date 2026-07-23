using System;
using System.IO;
using CPAHelper.Agent.Contracts;
using CPAHelper.Agent.Runtime;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class SkillUninstaller
{
	public SkillUninstallResponse Uninstall(SkillUninstallRequest request)
	{
		if (request == null || string.IsNullOrWhiteSpace(request.Name))
		{
			throw new InvalidOperationException("Skill name is required.");
		}
		string text = AgentRuntime.ResolveSkillsPath();
		if (string.IsNullOrWhiteSpace(text) || !Directory.Exists(text))
		{
			throw new InvalidOperationException("Skills directory was not found (.agent/skills or .claude/skills).");
		}
		string text2 = SkillCatalogReader.FindSkillDirectoryByName(text, request.Name);
		if (string.IsNullOrWhiteSpace(text2) || !Directory.Exists(text2))
		{
			throw new InvalidOperationException("Skill was not found.");
		}
		string value = EnsureTrailingSeparator(Path.GetFullPath(text));
		string fullPath = Path.GetFullPath(text2);
		if (!EnsureTrailingSeparator(fullPath).StartsWith(value, StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException("Skill path is outside the skills directory.");
		}
		if (!File.Exists(Path.Combine(fullPath, "SKILL.md")))
		{
			throw new InvalidOperationException("Skill directory does not contain SKILL.md.");
		}
		Directory.Delete(fullPath, recursive: true);
		return new SkillUninstallResponse
		{
			Success = true,
			Name = request.Name.Trim(),
			Path = fullPath,
			Message = "Skill 已卸载"
		};
	}

	private static string EnsureTrailingSeparator(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return path;
		}
		if (!path.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal) && !path.EndsWith(Path.AltDirectorySeparatorChar.ToString(), StringComparison.Ordinal))
		{
			return path + Path.DirectorySeparatorChar;
		}
		return path;
	}
}
