using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using Microsoft.Extensions.AI;

namespace CPAHelper.Agent.Runtime;

public sealed class HarnessShellToolProvider : IToolProvider
{
	private sealed class ProcessResult
	{
		public string Stdout { get; set; }

		public string Stderr { get; set; }

		public int ExitCode { get; set; }

		public bool TimedOut { get; set; }

		public bool StdoutTruncated { get; set; }

		public bool StderrTruncated { get; set; }
	}

	private const int DefaultTimeoutSeconds = 30;

	private const int MaxOutputChars = 20000;

	private readonly IHostContext _hostContext;

	public string ProviderName => "HarnessShell";

	public HarnessShellToolProvider(IHostContext hostContext)
	{
		_hostContext = hostContext;
	}

	public IList<AITool> GetTools()
	{
		MethodInfo method = GetType().GetMethod("RunShell", BindingFlags.Instance | BindingFlags.NonPublic);
		return new List<AITool> { AIFunctionFactory.Create(method, this, new AIFunctionFactoryOptions
		{
			Name = "run_shell",
			Description = BuildDescription()
		}) };
	}

	public IList<ToolMetadata> GetToolMetadata()
	{
		List<ToolMetadata> list = new List<ToolMetadata>();
		list.Add(new ToolMetadata("run_shell", new string[9] { "cli", "shell", "shell.execute", "execution", "python", "write", "risk.filesystem", "risk.confirm", "risk.high" }, "Execute a single local PowerShell command after host approval and return stdout, stderr, and exit code."));
		return list;
	}

	[Description("Execute a single shell command on the local machine and return stdout, stderr, and exit code.")]
	private async Task<string> RunShell([Description("The shell command to execute.")] string command)
	{
		if (string.IsNullOrWhiteSpace(command))
		{
			return "Command rejected by policy: command is empty.";
		}
		string cwd = ResolveWorkingDirectory();
		string shell = ResolvePowerShellPath();
		Stopwatch stopwatch = Stopwatch.StartNew();
		ProcessResult processResult = await Task.Run(() => ExecutePowerShell(shell, command, cwd, 30)).ConfigureAwait(continueOnCapturedContext: false);
		stopwatch.Stop();
		return FormatForModel(processResult.Stdout, processResult.Stderr, processResult.ExitCode, stopwatch.Elapsed, processResult.StdoutTruncated || processResult.StderrTruncated, processResult.TimedOut);
	}

	private string ResolveWorkingDirectory()
	{
		string text = _hostContext?.GetProjectPath();
		if (!string.IsNullOrWhiteSpace(text))
		{
			try
			{
				if (Directory.Exists(text))
				{
					return text;
				}
				string directoryName = Path.GetDirectoryName(text);
				if (!string.IsNullOrWhiteSpace(directoryName) && Directory.Exists(directoryName))
				{
					return directoryName;
				}
			}
			catch
			{
			}
		}
		return AppDomain.CurrentDomain.BaseDirectory;
	}

	private static string ResolvePowerShellPath()
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
		string text = (string.IsNullOrWhiteSpace(folderPath) ? null : Path.Combine(folderPath, "System32", "WindowsPowerShell", "v1.0", "powershell.exe"));
		if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
		{
			return text;
		}
		return "powershell.exe";
	}

	private static ProcessResult ExecutePowerShell(string shell, string command, string cwd, int timeoutSeconds)
	{
		string text = Convert.ToBase64String(Encoding.Unicode.GetBytes(command));
		using Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			FileName = shell,
			Arguments = "-NoProfile -NonInteractive -ExecutionPolicy Bypass -EncodedCommand " + text,
			WorkingDirectory = (string.IsNullOrWhiteSpace(cwd) ? AppDomain.CurrentDomain.BaseDirectory : cwd),
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
			CreateNoWindow = true,
			StandardOutputEncoding = Encoding.UTF8,
			StandardErrorEncoding = Encoding.UTF8
		};
		StringBuilder stdout = new StringBuilder();
		StringBuilder stderr = new StringBuilder();
		process.OutputDataReceived += delegate(object _, DataReceivedEventArgs e)
		{
			AppendLine(stdout, e.Data);
		};
		process.ErrorDataReceived += delegate(object _, DataReceivedEventArgs e)
		{
			AppendLine(stderr, e.Data);
		};
		process.Start();
		process.BeginOutputReadLine();
		process.BeginErrorReadLine();
		bool flag = !process.WaitForExit(timeoutSeconds * 1000);
		if (flag)
		{
			TryKill(process);
		}
		else
		{
			process.WaitForExit();
		}
		bool truncated;
		string stdout2 = Truncate(stdout.ToString(), out truncated);
		bool truncated2;
		string stderr2 = Truncate(stderr.ToString(), out truncated2);
		return new ProcessResult
		{
			ExitCode = (flag ? 124 : process.ExitCode),
			TimedOut = flag,
			Stdout = stdout2,
			Stderr = stderr2,
			StdoutTruncated = truncated,
			StderrTruncated = truncated2
		};
	}

	private static void AppendLine(StringBuilder builder, string value)
	{
		if (value == null)
		{
			return;
		}
		lock (builder)
		{
			builder.AppendLine(value);
		}
	}

	private static string Truncate(string value, out bool truncated)
	{
		value = value ?? string.Empty;
		truncated = value.Length > 20000;
		if (!truncated)
		{
			return value;
		}
		int num = 10000;
		return value.Substring(0, num) + Environment.NewLine + "[output truncated]" + Environment.NewLine + value.Substring(value.Length - num);
	}

	private static void TryKill(Process process)
	{
		try
		{
			if (!process.HasExited)
			{
				process.Kill();
			}
		}
		catch
		{
		}
	}

	private static string FormatForModel(string stdout, string stderr, int exitCode, TimeSpan duration, bool truncated, bool timedOut)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrEmpty(stdout))
		{
			stringBuilder.Append(stdout);
			if (truncated)
			{
				stringBuilder.AppendLine().Append("[stdout truncated]");
			}
			stringBuilder.AppendLine();
		}
		if (!string.IsNullOrEmpty(stderr))
		{
			stringBuilder.Append("stderr: ").Append(stderr).AppendLine();
		}
		if (timedOut)
		{
			stringBuilder.AppendLine("[command timed out]");
		}
		stringBuilder.Append("exit_code: ").Append(exitCode);
		stringBuilder.AppendLine();
		stringBuilder.Append("duration_ms: ").Append((int)duration.TotalMilliseconds);
		stringBuilder.AppendLine();
		stringBuilder.Append("next_action: Summarize this shell result to the user now. Do not call run_shell again for the same command.");
		return stringBuilder.ToString();
	}

	private static string BuildDescription()
	{
		return "Execute a single shell command on the local machine and return its stdout, stderr, and exit code. Operating system: Windows. Shell: Windows PowerShell. Use PowerShell syntax, not bash/sh. STATELESS MODE: each call runs in a fresh shell. Working directory and environment variables do not carry across calls. Per-call timeout: 30s. Output is truncated to 20000 characters. The user reviews and approves every call.";
	}
}
