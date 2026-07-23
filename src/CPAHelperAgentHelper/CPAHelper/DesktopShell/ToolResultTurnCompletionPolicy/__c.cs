using System;
using System.Collections.Generic;
using System.Linq;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class ToolResultTurnCompletionPolicy
{
	private static readonly TimeSpan DefaultCancelDelay = TimeSpan.FromMilliseconds(750.0);

	public bool TryCreateCompletion(string toolName, object result, Exception exception, out ToolResultTurnCompletion completion)
	{
		completion = null;
		if (exception != null || !string.Equals(toolName, "run_shell", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		string text = BuildShellResultSummary(result);
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		completion = new ToolResultTurnCompletion(text, DefaultCancelDelay);
		return true;
	}

	private static string BuildShellResultSummary(object result)
	{
		string text = result?.ToString() ?? string.Empty;
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		List<string> list = (from line in text.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None)
			select line.Trim() into line
			where !string.IsNullOrWhiteSpace(line)
			select line).ToList();
		if (list.Count == 0)
		{
			return null;
		}
		string text2 = list.FirstOrDefault((string line) => line.StartsWith("exit_code:", StringComparison.OrdinalIgnoreCase))?.Substring("exit_code:".Length).Trim();
		string text3 = list.FirstOrDefault((string line) => !line.StartsWith("stderr:", StringComparison.OrdinalIgnoreCase) && !line.StartsWith("exit_code:", StringComparison.OrdinalIgnoreCase) && !line.StartsWith("duration_ms:", StringComparison.OrdinalIgnoreCase) && !line.StartsWith("next_action:", StringComparison.OrdinalIgnoreCase) && !line.StartsWith("[", StringComparison.Ordinal));
		if (string.IsNullOrWhiteSpace(text3))
		{
			text3 = "(empty)";
		}
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = "unknown";
		}
		return "Shell completed. stdout: " + text3 + "; exit_code: " + text2 + ".";
	}
}
