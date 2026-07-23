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

public sealed class GenericFileEditToolProvider : IToolProvider
{
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

	internal const string ToolName = "file_edit";

	private static readonly UTF8Encoding Utf8NoBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

	private readonly IHostContext _hostContext;

	public string ProviderName => "GenericFileEdit";

	public GenericFileEditToolProvider(IHostContext hostContext)
	{
		_hostContext = hostContext;
	}

	public IList<AITool> GetTools()
	{
		MethodInfo method = GetType().GetMethod("FileEdit", BindingFlags.Instance | BindingFlags.NonPublic);
		return new List<AITool> { AIFunctionFactory.Create(method, this, new AIFunctionFactoryOptions
		{
			Name = "file_edit",
			Description = "Edit local text files anywhere on this machine. Supports write, append, replace, replace_lines, and delete. This is a high-risk filesystem tool and requires approval."
		}) };
	}

	public IList<ToolMetadata> GetToolMetadata()
	{
		List<ToolMetadata> list = new List<ToolMetadata>();
		list.Add(new ToolMetadata("file_edit", new string[7] { "file", "file.write", "file.edit", "write", "risk.filesystem", "risk.confirm", "risk.high" }, "Edit local text files anywhere on this machine. Supports write, append, replace, replace_lines, and delete."));
		return list;
	}

	[Description("Edit local text files anywhere on this machine. Supports write, append, replace, replace_lines, and delete.")]
	internal string FileEdit([Description("Operation to perform: write, append, replace, replace_lines, or delete.")] string operation, [Description("File path. Absolute paths are accepted. Relative paths resolve from the host project directory when available, otherwise from the app base directory.")] string path, [Description("Text content for write, append, and replace_lines. Empty string is allowed; omitted content is invalid for those operations.")] string content = null, [Description("For write only. If false and the target file exists, the operation fails. Accepts true/false or \"true\"/\"false\". Defaults to true.")] object overwrite = null, [Description("For replace only. Existing text to find.")] string oldString = null, [Description("For replace only. Replacement text. Empty string is allowed.")] string newString = null, [Description("For replace only. If true, replace all occurrences; otherwise replace only the first occurrence. Accepts true/false or \"true\"/\"false\". Defaults to false.")] object replaceAll = null, [Description("For replace_lines only. 1-based inclusive start line. Accepts a number or numeric string.")] object startLine = null, [Description("For replace_lines only. 1-based inclusive end line. Accepts a number or numeric string. Defaults to startLine.")] object endLine = null, [Description("For write and append. Create parent directories when missing. Accepts true/false or \"true\"/\"false\". Defaults to true.")] object createParents = null)
	{
		string text = (operation ?? string.Empty).Trim().ToLowerInvariant();
		try
		{
			string path2 = ResolveFilePath(path);
			return text switch
			{
				"write" => WriteFile(path2, content, ResolveBool(overwrite, defaultValue: true, "overwrite"), ResolveBool(createParents, defaultValue: true, "createParents")), 
				"append" => AppendFile(path2, content, ResolveBool(createParents, defaultValue: true, "createParents")), 
				"replace" => ReplaceText(path2, oldString, newString, ResolveBool(replaceAll, defaultValue: false, "replaceAll")), 
				"replace_lines" => ReplaceLines(path2, content, ResolveNullableInt(startLine, "startLine"), ResolveNullableInt(endLine, "endLine")), 
				"delete" => DeleteFile(path2), 
				_ => Failure(text, path, "Invalid operation. Use write, append, replace, replace_lines, or delete."), 
			};
		}
		catch (Exception ex)
		{
			return Failure(text, path, ex.Message);
		}
	}

	private string WriteFile(string path, string content, bool overwrite, bool createParents)
	{
		RequireContent(content, "write");
		EnsureFileTarget(path, createParents);
		if (!overwrite && File.Exists(path))
		{
			return Failure("write", path, "File already exists and overwrite is false.");
		}
		File.WriteAllText(path, content, Utf8NoBom);
		return Success(new
		{
			success = true,
			operation = "write",
			path = path,
			bytesWritten = Utf8NoBom.GetByteCount(content),
			message = "File written."
		});
	}

	private string AppendFile(string path, string content, bool createParents)
	{
		RequireContent(content, "append");
		EnsureFileTarget(path, createParents);
		File.AppendAllText(path, content, Utf8NoBom);
		return Success(new
		{
			success = true,
			operation = "append",
			path = path,
			bytesWritten = Utf8NoBom.GetByteCount(content),
			message = "Content appended."
		});
	}

	private string ReplaceText(string path, string oldString, string newString, bool replaceAll)
	{
		EnsureExistingFile(path);
		if (string.IsNullOrEmpty(oldString))
		{
			return Failure("replace", path, "oldString is required and must not be empty.");
		}
		if (newString == null)
		{
			return Failure("replace", path, "newString is required. Use an empty string to remove text.");
		}
		int replacements;
		string text = ReplaceText(File.ReadAllText(path, Encoding.UTF8), oldString, newString, replaceAll, out replacements);
		if (replacements == 0)
		{
			return Failure("replace", path, "oldString was not found.");
		}
		File.WriteAllText(path, text, Utf8NoBom);
		return Success(new
		{
			success = true,
			operation = "replace",
			path = path,
			replacements = replacements,
			bytesWritten = Utf8NoBom.GetByteCount(text),
			message = "Text replaced."
		});
	}

	private string ReplaceLines(string path, string content, int? startLine, int? endLine)
	{
		EnsureExistingFile(path);
		RequireContent(content, "replace_lines");
		if (!startLine.HasValue || startLine.Value < 1)
		{
			return Failure("replace_lines", path, "startLine is required and must be greater than 0.");
		}
		int num = endLine ?? startLine.Value;
		if (num < startLine.Value)
		{
			return Failure("replace_lines", path, "endLine must be greater than or equal to startLine.");
		}
		LineDocument lineDocument = LineDocument.Parse(File.ReadAllText(path, Encoding.UTF8));
		if (startLine.Value > lineDocument.Lines.Count)
		{
			return Failure("replace_lines", path, "startLine is beyond the end of the file.");
		}
		if (num > lineDocument.Lines.Count)
		{
			return Failure("replace_lines", path, "endLine is beyond the end of the file.");
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
			path = path,
			replacements = num2,
			bytesWritten = Utf8NoBom.GetByteCount(text),
			message = "Lines replaced."
		});
	}

	private string DeleteFile(string path)
	{
		if (Directory.Exists(path))
		{
			return Failure("delete", path, "Path is a directory. file_edit delete only removes files and does not delete directories.");
		}
		if (!File.Exists(path))
		{
			return Failure("delete", path, "File does not exist.");
		}
		File.Delete(path);
		return Success(new
		{
			success = true,
			operation = "delete",
			path = path,
			message = "File deleted."
		});
	}

	private string ResolveFilePath(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			throw new InvalidOperationException("path is required.");
		}
		string text = path.Trim();
		if (text.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
		{
			throw new InvalidOperationException("path contains invalid characters.");
		}
		string path2 = ((!IsRootedPath(text)) ? Path.Combine(ResolveBaseDirectory(), text) : text);
		string fullPath = Path.GetFullPath(path2);
		if (string.IsNullOrWhiteSpace(Path.GetFileName(fullPath)))
		{
			throw new InvalidOperationException("path must point to a file, not a directory root.");
		}
		return fullPath;
	}

	private string ResolveBaseDirectory()
	{
		string text = _hostContext?.GetProjectPath();
		if (!string.IsNullOrWhiteSpace(text))
		{
			if (Directory.Exists(text))
			{
				return text;
			}
			string directoryName = Path.GetDirectoryName(text);
			if (!string.IsNullOrWhiteSpace(directoryName))
			{
				return directoryName;
			}
		}
		return AppDomain.CurrentDomain.BaseDirectory;
	}

	private static bool IsRootedPath(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			return false;
		}
		if (path.Length >= 2 && path[1] == ':' && (path.Length == 2 || !IsDirectorySeparator(path[2])))
		{
			throw new InvalidOperationException("Drive-relative paths are not supported. Use an absolute path like C:\\folder\\file.txt or a normal relative path.");
		}
		return Path.IsPathRooted(path);
	}

	private static bool IsDirectorySeparator(char ch)
	{
		if (ch != Path.DirectorySeparatorChar)
		{
			return ch == Path.AltDirectorySeparatorChar;
		}
		return true;
	}

	private static void EnsureFileTarget(string path, bool createParents)
	{
		if (Directory.Exists(path))
		{
			throw new InvalidOperationException("path points to an existing directory.");
		}
		string directoryName = Path.GetDirectoryName(path);
		if (string.IsNullOrWhiteSpace(directoryName))
		{
			throw new InvalidOperationException("path does not include a parent directory.");
		}
		if (!Directory.Exists(directoryName))
		{
			if (!createParents)
			{
				throw new InvalidOperationException("Parent directory does not exist and createParents is false.");
			}
			Directory.CreateDirectory(directoryName);
		}
	}

	private static void EnsureExistingFile(string path)
	{
		if (Directory.Exists(path))
		{
			throw new InvalidOperationException("path points to an existing directory.");
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

	private static string Failure(string operation, string path, string message)
	{
		return JsonConvert.SerializeObject(new
		{
			success = false,
			operation = (operation ?? string.Empty),
			path = (path ?? string.Empty),
			message = (message ?? "Operation failed.")
		});
	}
}
