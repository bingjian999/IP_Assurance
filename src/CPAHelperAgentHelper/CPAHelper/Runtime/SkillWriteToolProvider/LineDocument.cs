using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using CPAHelper.Agent.Abstractions;
using Microsoft.Extensions.AI;
using Newtonsoft.Json;

namespace CPAHelper.Agent.Runtime;

public sealed class SkillWriteToolProvider : IToolProvider
{
	private sealed class SkillFileTarget
	{
		internal string FullPath { get; }

		internal string RelativePath { get; }

		internal SkillFileTarget(string fullPath, string relativePath)
		{
			FullPath = fullPath;
			RelativePath = relativePath;
		}
	}

	private sealed class LineDocument
	{
		public List<string> Lines { get; }

		private string Newline { get; }

		private bool TrailingNewline { get; }

		private LineDocument(List<string> lines, string newline, bool trailingNewline)
		{
			Lines = lines;
			Newline = newline;
			TrailingNewline = trailingNewline;
		}

		public static LineDocument Parse(string text)
		{
			text = text ?? string.Empty;
			string newline = DetectNewline(text);
			string text2 = NormalizeNewlines(text);
			bool flag = text2.EndsWith("\n", StringComparison.Ordinal);
			if (flag)
			{
				text2 = text2.Substring(0, text2.Length - 1);
			}
			return new LineDocument((text2.Length == 0) ? new List<string> { string.Empty } : text2.Split('\n').ToList(), newline, flag);
		}

		public static List<string> SplitContentLines(string content)
		{
			return NormalizeNewlines(content ?? string.Empty).Split('\n').ToList();
		}

		public string Render()
		{
			string text = string.Join(Newline, Lines);
			if (!TrailingNewline)
			{
				return text;
			}
			return text + Newline;
		}

		private static string DetectNewline(string text)
		{
			if ((text ?? string.Empty).IndexOf("\r\n", StringComparison.Ordinal) >= 0)
			{
				return "\r\n";
			}
			if ((text ?? string.Empty).IndexOf("\n", StringComparison.Ordinal) >= 0)
			{
				return "\n";
			}
			if ((text ?? string.Empty).IndexOf("\r", StringComparison.Ordinal) >= 0)
			{
				return "\r";
			}
			return Environment.NewLine;
		}

		private static string NormalizeNewlines(string text)
		{
			return (text ?? string.Empty).Replace("\r\n", "\n").Replace('\r', '\n');
		}
	}

	internal const string ToolName = "skill_write";

	private static readonly UTF8Encoding Utf8NoBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

	private readonly Func<string> _skillsRootFactory;

	public string ProviderName => "SkillWrite";

	public SkillWriteToolProvider()
		: this(HarnessStoragePaths.EnsureSkillsPath)
	{
	}

	internal SkillWriteToolProvider(Func<string> skillsRootFactory)
	{
		_skillsRootFactory = skillsRootFactory ?? throw new ArgumentNullException("skillsRootFactory");
	}

	public IList<AITool> GetTools()
	{
		MethodInfo method = GetType().GetMethod("SkillWrite", BindingFlags.Instance | BindingFlags.NonPublic);
		return new List<AITool> { AIFunctionFactory.Create(method, this, new AIFunctionFactoryOptions
		{
			Name = "skill_write",
			Description = "Write or edit text files inside the host .agent/skills directory. Supports write, append, replace, and replace_lines. This tool is scoped to skills and does not require approval."
		}) };
	}

	public IList<ToolMetadata> GetToolMetadata()
	{
		List<ToolMetadata> list = new List<ToolMetadata>();
		list.Add(new ToolMetadata("skill_write", new string[3] { "skill", "skill.write", "write" }, "Write or edit text files inside the host .agent/skills directory. Supports write, append, replace, and replace_lines."));
		return list;
	}

	[Description("Write or edit text files inside the host .agent/skills directory. Supports write, append, replace, and replace_lines.")]
	internal string SkillWrite([Description("Operation to perform: write, append, replace, or replace_lines.")] string operation, [Description("Skill folder name under .agent/skills. Must be a single folder name, not a path.")] string skillName, [Description("File path inside the skill folder. Defaults to SKILL.md. Examples: SKILL.md, references/guide.md, scripts/build.py.")] string relativePath = "SKILL.md", [Description("Text content for write, append, and replace_lines. Empty string is allowed; omitted content is invalid for those operations.")] string content = null, [Description("For write only. If false and the target file exists, the operation fails. Accepts true/false or \"true\"/\"false\". Defaults to true.")] object overwrite = null, [Description("For replace only. Existing text to find.")] string oldString = null, [Description("For replace only. Replacement text. Empty string is allowed.")] string newString = null, [Description("For replace only. If true, replace all occurrences; otherwise replace only the first occurrence. Accepts true/false or \"true\"/\"false\". Defaults to false.")] object replaceAll = null, [Description("For replace_lines only. 1-based inclusive start line. Accepts a number or numeric string.")] object startLine = null, [Description("For replace_lines only. 1-based inclusive end line. Accepts a number or numeric string. Defaults to startLine.")] object endLine = null)
	{
		string text = (operation ?? string.Empty).Trim().ToLowerInvariant();
		string path = null;
		string text2 = null;
		try
		{
			SkillFileTarget skillFileTarget = ResolveSkillFilePath(skillName, relativePath);
			path = skillFileTarget.FullPath;
			text2 = skillFileTarget.RelativePath;
			return text switch
			{
				"write" => WriteFile(skillName, text2, path, content, ResolveBool(overwrite, defaultValue: true, "overwrite")), 
				"append" => AppendFile(skillName, text2, path, content), 
				"replace" => ReplaceText(skillName, text2, path, oldString, newString, ResolveBool(replaceAll, defaultValue: false, "replaceAll")), 
				"replace_lines" => ReplaceLines(skillName, text2, path, content, ResolveNullableInt(startLine, "startLine"), ResolveNullableInt(endLine, "endLine")), 
				_ => Failure(text, skillName, text2 ?? relativePath, path, "Invalid operation. Use write, append, replace, or replace_lines."), 
			};
		}
		catch (Exception ex)
		{
			return Failure(text, skillName, text2 ?? relativePath, path, ex.Message);
		}
	}

	private string WriteFile(string skillName, string relativePath, string path, string content, bool overwrite)
	{
		RequireContent(content, "write");
		EnsureFileTarget(path);
		if (!overwrite && File.Exists(path))
		{
			return Failure("write", skillName, relativePath, path, "File already exists and overwrite is false.");
		}
		File.WriteAllText(path, content, Utf8NoBom);
		return Success(new
		{
			success = true,
			operation = "write",
			skillName = NormalizeSkillNameForResponse(skillName),
			relativePath = relativePath,
			path = path,
			bytesWritten = Utf8NoBom.GetByteCount(content),
			message = "Skill file written."
		});
	}

	private string AppendFile(string skillName, string relativePath, string path, string content)
	{
		RequireContent(content, "append");
		EnsureFileTarget(path);
		File.AppendAllText(path, content, Utf8NoBom);
		return Success(new
		{
			success = true,
			operation = "append",
			skillName = NormalizeSkillNameForResponse(skillName),
			relativePath = relativePath,
			path = path,
			bytesWritten = Utf8NoBom.GetByteCount(content),
			message = "Skill file content appended."
		});
	}

	private string ReplaceText(string skillName, string relativePath, string path, string oldString, string newString, bool replaceAll)
	{
		EnsureExistingFile(path);
		if (string.IsNullOrEmpty(oldString))
		{
			return Failure("replace", skillName, relativePath, path, "oldString is required and must not be empty.");
		}
		if (newString == null)
		{
			return Failure("replace", skillName, relativePath, path, "newString is required. Use an empty string to remove text.");
		}
		int replacements;
		string text = ReplaceText(File.ReadAllText(path, Encoding.UTF8), oldString, newString, replaceAll, out replacements);
		if (replacements == 0)
		{
			return Failure("replace", skillName, relativePath, path, "oldString was not found.");
		}
		File.WriteAllText(path, text, Utf8NoBom);
		return Success(new
		{
			success = true,
			operation = "replace",
			skillName = NormalizeSkillNameForResponse(skillName),
			relativePath = relativePath,
			path = path,
			replacements = replacements,
			bytesWritten = Utf8NoBom.GetByteCount(text),
			message = "Skill file text replaced."
		});
	}

	private string ReplaceLines(string skillName, string relativePath, string path, string content, int? startLine, int? endLine)
	{
		EnsureExistingFile(path);
		RequireContent(content, "replace_lines");
		if (!startLine.HasValue || startLine.Value < 1)
		{
			return Failure("replace_lines", skillName, relativePath, path, "startLine is required and must be greater than 0.");
		}
		int num = endLine ?? startLine.Value;
		if (num < startLine.Value)
		{
			return Failure("replace_lines", skillName, relativePath, path, "endLine must be greater than or equal to startLine.");
		}
		LineDocument lineDocument = LineDocument.Parse(File.ReadAllText(path, Encoding.UTF8));
		if (startLine.Value > lineDocument.Lines.Count)
		{
			return Failure("replace_lines", skillName, relativePath, path, "startLine is beyond the end of the file.");
		}
		if (num > lineDocument.Lines.Count)
		{
			return Failure("replace_lines", skillName, relativePath, path, "endLine is beyond the end of the file.");
		}
		List<string> collection = LineDocument.SplitContentLines(content);
		int num2 = num - startLine.Value + 1;
		lineDocument.Lines.RemoveRange(startLine.Value - 1, num2);
		lineDocument.Lines.InsertRange(startLine.Value - 1, collection);
		string text = lineDocument.Render();
		File.WriteAllText(path, text, Utf8NoBom);
		return Success(new
		{
			success = true,
			operation = "replace_lines",
			skillName = NormalizeSkillNameForResponse(skillName),
			relativePath = relativePath,
			path = path,
			replacements = num2,
			bytesWritten = Utf8NoBom.GetByteCount(text),
			message = "Skill file lines replaced."
		});
	}

	private SkillFileTarget ResolveSkillFilePath(string skillName, string relativePath)
	{
		string path = NormalizeSkillName(skillName);
		string text = NormalizeRelativeFilePath(relativePath);
		string text2 = _skillsRootFactory();
		if (string.IsNullOrWhiteSpace(text2))
		{
			throw new InvalidOperationException("Skills root could not be resolved.");
		}
		string fullPath = Path.GetFullPath(text2);
		string fullPath2 = Path.GetFullPath(Path.Combine(fullPath, path));
		if (!IsSubPathOf(fullPath2, fullPath))
		{
			throw new InvalidOperationException("skillName resolves outside the skills root.");
		}
		string path2 = text.Replace('/', Path.DirectorySeparatorChar);
		string fullPath3 = Path.GetFullPath(Path.Combine(fullPath2, path2));
		if (!IsSubPathOf(fullPath3, fullPath2))
		{
			throw new InvalidOperationException("relativePath resolves outside the skill directory.");
		}
		if (string.IsNullOrWhiteSpace(Path.GetFileName(fullPath3)))
		{
			throw new InvalidOperationException("relativePath must point to a file, not a directory.");
		}
		return new SkillFileTarget(fullPath3, text);
	}

	private static string NormalizeSkillName(string skillName)
	{
		if (string.IsNullOrWhiteSpace(skillName))
		{
			throw new InvalidOperationException("skillName is required.");
		}
		string text = skillName.Trim();
		if (IsRootedPath(text))
		{
			throw new InvalidOperationException("skillName must be a folder name, not an absolute path.");
		}
		if (text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
		{
			throw new InvalidOperationException("skillName contains invalid characters.");
		}
		if (text.IndexOf("..", StringComparison.Ordinal) >= 0)
		{
			throw new InvalidOperationException("skillName must not contain '..'.");
		}
		if (text.StartsWith(".", StringComparison.Ordinal))
		{
			throw new InvalidOperationException("skillName must not be hidden.");
		}
		return text;
	}

	private static string NormalizeSkillNameForResponse(string skillName)
	{
		if (!string.IsNullOrWhiteSpace(skillName))
		{
			return skillName.Trim();
		}
		return string.Empty;
	}

	private static string NormalizeRelativeFilePath(string relativePath)
	{
		string obj = (string.IsNullOrWhiteSpace(relativePath) ? "SKILL.md" : relativePath.Trim());
		if (obj.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
		{
			throw new InvalidOperationException("relativePath contains invalid characters.");
		}
		if (IsRootedPath(obj))
		{
			throw new InvalidOperationException("relativePath must be relative to the skill folder.");
		}
		if (EndsWithDirectorySeparator(obj))
		{
			throw new InvalidOperationException("relativePath must point to a file, not a directory.");
		}
		string[] array = obj.Replace('\\', '/').Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 0)
		{
			throw new InvalidOperationException("relativePath must point to a file.");
		}
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (string.Equals(text, ".", StringComparison.Ordinal) || string.Equals(text, "..", StringComparison.Ordinal))
			{
				throw new InvalidOperationException("relativePath must not contain '.' or '..' segments.");
			}
			if (text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
			{
				throw new InvalidOperationException("relativePath contains invalid characters.");
			}
		}
		string text2 = string.Join("/", array);
		if (!HarnessAgentOptionsFactory.IsAllowedSkillFilePath(text2))
		{
			throw new InvalidOperationException("relativePath is not allowed for skill resources or scripts.");
		}
		return text2;
	}

	private static bool IsRootedPath(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			return false;
		}
		if (path.Length >= 2 && path[1] == ':' && (path.Length == 2 || !IsDirectorySeparator(path[2])))
		{
			throw new InvalidOperationException("Drive-relative paths are not supported.");
		}
		return Path.IsPathRooted(path);
	}

	private static bool EndsWithDirectorySeparator(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return false;
		}
		return IsDirectorySeparator(path[path.Length - 1]);
	}

	private static bool IsDirectorySeparator(char ch)
	{
		if (ch != Path.DirectorySeparatorChar)
		{
			return ch == Path.AltDirectorySeparatorChar;
		}
		return true;
	}

	private static bool IsSubPathOf(string path, string root)
	{
		string fullPath = Path.GetFullPath(path);
		string value = EnsureTrailingSeparator(Path.GetFullPath(root));
		return fullPath.StartsWith(value, StringComparison.OrdinalIgnoreCase);
	}

	private static string EnsureTrailingSeparator(string path)
	{
		if (string.IsNullOrEmpty(path) || EndsWithDirectorySeparator(path))
		{
			return path;
		}
		return path + Path.DirectorySeparatorChar;
	}

	private static void EnsureFileTarget(string path)
	{
		if (Directory.Exists(path))
		{
			throw new InvalidOperationException("relativePath points to an existing directory.");
		}
		string directoryName = Path.GetDirectoryName(path);
		if (string.IsNullOrWhiteSpace(directoryName))
		{
			throw new InvalidOperationException("relativePath does not include a parent directory.");
		}
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
	}

	private static void EnsureExistingFile(string path)
	{
		if (Directory.Exists(path))
		{
			throw new InvalidOperationException("relativePath points to an existing directory.");
		}
		if (!File.Exists(path))
		{
			throw new InvalidOperationException("File does not exist.");
		}
	}

	private static void RequireContent(string content, string operation)
	{
		if (content == null)
		{
			throw new InvalidOperationException("content is required for " + operation + ". Use an empty string when intentionally writing no text.");
		}
	}

	private static bool ResolveBool(object value, bool defaultValue, string parameterName)
	{
		if (value == null)
		{
			return defaultValue;
		}
		if (value is bool)
		{
			return (bool)value;
		}
		if (value is JsonElement jsonElement)
		{
			switch (jsonElement.ValueKind)
			{
			case JsonValueKind.True:
				return true;
			case JsonValueKind.False:
				return false;
			case JsonValueKind.Undefined:
			case JsonValueKind.Null:
				return defaultValue;
			case JsonValueKind.String:
				return ParseBoolString(jsonElement.GetString(), defaultValue, parameterName);
			case JsonValueKind.Number:
			{
				if (jsonElement.TryGetInt32(out var value2))
				{
					return ParseBoolNumber(value2, parameterName);
				}
				break;
			}
			}
		}
		if (value is string value3)
		{
			return ParseBoolString(value3, defaultValue, parameterName);
		}
		if (value is int value4)
		{
			return ParseBoolNumber(value4, parameterName);
		}
		if (value is long num && num >= int.MinValue && num <= int.MaxValue)
		{
			return ParseBoolNumber((int)num, parameterName);
		}
		throw new InvalidOperationException(parameterName + " must be true or false.");
	}

	private static bool ParseBoolString(string value, bool defaultValue, string parameterName)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return defaultValue;
		}
		string text = value.Trim();
		if (bool.TryParse(text, out var result))
		{
			return result;
		}
		if (int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2))
		{
			return ParseBoolNumber(result2, parameterName);
		}
		throw new InvalidOperationException(parameterName + " must be true or false.");
	}

	private static bool ParseBoolNumber(int value, string parameterName)
	{
		return value switch
		{
			0 => false, 
			1 => true, 
			_ => throw new InvalidOperationException(parameterName + " must be true or false."), 
		};
	}

	private static int? ResolveNullableInt(object value, string parameterName)
	{
		if (value == null)
		{
			return null;
		}
		if (value is int)
		{
			return (int)value;
		}
		if (value is long num && num >= int.MinValue && num <= int.MaxValue)
		{
			return (int)num;
		}
		if (value is JsonElement { ValueKind: var valueKind } jsonElement)
		{
			switch (valueKind)
			{
			case JsonValueKind.Undefined:
			case JsonValueKind.Null:
				return null;
			case JsonValueKind.Number:
			{
				if (jsonElement.TryGetInt32(out var value2))
				{
					return value2;
				}
				break;
			}
			case JsonValueKind.String:
				return ParseNullableIntString(jsonElement.GetString(), parameterName);
			}
		}
		if (value is string value3)
		{
			return ParseNullableIntString(value3, parameterName);
		}
		throw new InvalidOperationException(parameterName + " must be an integer.");
	}

	private static int? ParseNullableIntString(string value, string parameterName)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return null;
		}
		if (int.TryParse(value.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		throw new InvalidOperationException(parameterName + " must be an integer.");
	}

	private static string ReplaceText(string text, string oldString, string newString, bool replaceAll, out int replacements)
	{
		text = text ?? string.Empty;
		replacements = 0;
		int num = text.IndexOf(oldString, StringComparison.Ordinal);
		if (num < 0)
		{
			return text;
		}
		if (!replaceAll)
		{
			replacements = 1;
			return text.Remove(num, oldString.Length).Insert(num, newString);
		}
		StringBuilder stringBuilder = new StringBuilder(text.Length);
		int num2 = 0;
		while (num >= 0)
		{
			stringBuilder.Append(text, num2, num - num2);
			stringBuilder.Append(newString);
			num2 = num + oldString.Length;
			replacements++;
			num = text.IndexOf(oldString, num2, StringComparison.Ordinal);
		}
		stringBuilder.Append(text, num2, text.Length - num2);
		return stringBuilder.ToString();
	}

	private static string Success(object value)
	{
		return JsonConvert.SerializeObject(value);
	}

	private static string Failure(string operation, string skillName, string relativePath, string path, string message)
	{
		return JsonConvert.SerializeObject(new
		{
			success = false,
			operation = (operation ?? string.Empty),
			skillName = NormalizeSkillNameForResponse(skillName),
			relativePath = (relativePath ?? string.Empty),
			path = (path ?? string.Empty),
			message = (message ?? "Operation failed.")
		});
	}
}
