using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal static class SkillCatalogReader
{
	public static List<SkillInfo> ListSkills(string skillsDirectory)
	{
		return (from @group in (from skill in Directory.GetFiles(skillsDirectory, "SKILL.md", SearchOption.AllDirectories).Select(ReadSkillInfo)
				where skill != null && !string.IsNullOrWhiteSpace(skill.Name)
				select skill).GroupBy((SkillInfo skill) => skill.Name, StringComparer.OrdinalIgnoreCase)
			select @group.First()).OrderBy((SkillInfo skill) => skill.Name, StringComparer.OrdinalIgnoreCase).ToList();
	}

	public static string FindSkillDirectoryByName(string skillsDirectory, string skillName)
	{
		if (string.IsNullOrWhiteSpace(skillsDirectory) || string.IsNullOrWhiteSpace(skillName))
		{
			return null;
		}
		return (from skillFile in Directory.GetFiles(skillsDirectory, "SKILL.md", SearchOption.AllDirectories)
			select new
			{
				SkillFile = skillFile,
				Skill = ReadSkillInfo(skillFile)
			} into item
			where item.Skill != null
			where string.Equals(item.Skill.Name, skillName.Trim(), StringComparison.OrdinalIgnoreCase)
			select Path.GetDirectoryName(item.SkillFile)).FirstOrDefault();
	}

	private static SkillInfo ReadSkillInfo(string skillFilePath)
	{
		string fileName = Path.GetFileName(Path.GetDirectoryName(skillFilePath));
		string text = fileName;
		string text2 = null;
		try
		{
			string[] array = File.ReadAllLines(skillFilePath, Encoding.UTF8);
			if (array.Length != 0 && string.Equals(array[0].Trim(), "---", StringComparison.Ordinal))
			{
				for (int i = 1; i < array.Length && !string.Equals(array[i].Trim(), "---", StringComparison.Ordinal); i++)
				{
					string value2;
					if (TryReadFrontMatterValue(array, ref i, "name", out var value))
					{
						text = value;
					}
					else if (TryReadFrontMatterValue(array, ref i, "description", out value2))
					{
						text2 = value2;
					}
				}
			}
		}
		catch (Exception exception)
		{
			AgentRuntimeLogger.Error("Failed to read skill metadata: " + skillFilePath, exception);
		}
		return new SkillInfo
		{
			Name = (string.IsNullOrWhiteSpace(text) ? fileName : text.Trim()),
			Description = (string.IsNullOrWhiteSpace(text2) ? null : text2.Trim())
		};
	}

	private static bool TryReadFrontMatterValue(string[] lines, ref int index, string key, out string value)
	{
		value = null;
		if (lines == null || index < 0 || index >= lines.Length)
		{
			return false;
		}
		string text = lines[index].Trim();
		string text2 = key + ":";
		if (!text.StartsWith(text2, StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		string text3 = text.Substring(text2.Length).Trim();
		if (IsYamlBlockIndicator(text3, out var folded))
		{
			value = ReadYamlBlock(lines, ref index, folded);
			return !string.IsNullOrWhiteSpace(value);
		}
		if (string.IsNullOrWhiteSpace(text3))
		{
			value = ReadIndentedContinuationBlock(lines, ref index);
			return !string.IsNullOrWhiteSpace(value);
		}
		value = text3.Trim().Trim('"', '\'');
		return true;
	}

	private static bool IsYamlBlockIndicator(string value, out bool folded)
	{
		folded = false;
		if (string.IsNullOrWhiteSpace(value))
		{
			return false;
		}
		string text = value.Trim();
		if (text.StartsWith(">", StringComparison.Ordinal))
		{
			folded = true;
			return true;
		}
		return text.StartsWith("|", StringComparison.Ordinal);
	}

	private static string ReadYamlBlock(string[] lines, ref int index, bool folded)
	{
		List<string> list = new List<string>();
		int num = -1;
		for (int i = index + 1; i < lines.Length; i++)
		{
			string text = lines[i];
			string text2 = text.Trim();
			if (string.Equals(text2, "---", StringComparison.Ordinal))
			{
				break;
			}
			if (text2.Length == 0)
			{
				if (num >= 0)
				{
					list.Add(string.Empty);
					index = i;
				}
				continue;
			}
			int num2 = CountLeadingSpaces(text);
			if (num < 0)
			{
				num = num2;
			}
			if (num2 < num)
			{
				break;
			}
			list.Add(text.Substring(Math.Min(num, text.Length)).TrimEnd());
			index = i;
		}
		return (folded ? string.Join(" ", from line in list
			where !string.IsNullOrWhiteSpace(line)
			select line.Trim()) : string.Join(Environment.NewLine, list)).Trim();
	}

	private static string ReadIndentedContinuationBlock(string[] lines, ref int index)
	{
		List<string> list = new List<string>();
		int num = -1;
		for (int i = index + 1; i < lines.Length; i++)
		{
			string text = lines[i];
			string text2 = text.Trim();
			if (string.Equals(text2, "---", StringComparison.Ordinal))
			{
				break;
			}
			if (text2.Length == 0)
			{
				if (num >= 0)
				{
					list.Add(string.Empty);
					index = i;
				}
				continue;
			}
			int num2 = CountLeadingSpaces(text);
			if (num2 == 0)
			{
				break;
			}
			if (num < 0)
			{
				num = num2;
			}
			if (num2 < num)
			{
				break;
			}
			list.Add(text.Substring(Math.Min(num, text.Length)).Trim());
			index = i;
		}
		return string.Join(Environment.NewLine, list).Trim();
	}

	private static int CountLeadingSpaces(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return 0;
		}
		int i;
		for (i = 0; i < value.Length && value[i] == ' '; i++)
		{
		}
		return i;
	}
}
