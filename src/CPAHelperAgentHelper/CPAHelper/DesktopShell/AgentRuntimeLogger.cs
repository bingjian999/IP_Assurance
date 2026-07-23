using System;
using System.IO;
using System.Text;

namespace CPAHelper.Agent.DesktopShell;

public static class AgentRuntimeLogger
{
	private static readonly object SyncRoot = new object();

	private static Action<string, string, Exception> _sink;

	private static string _logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CPAHelperAgentHelper", "Logs", "agent-runtime.log");

	public static string LogFilePath => _logFilePath;

	public static void Configure(Action<string, string, Exception> sink, string logFilePath = null)
	{
		lock (SyncRoot)
		{
			_sink = sink;
			if (!string.IsNullOrWhiteSpace(logFilePath))
			{
				_logFilePath = logFilePath;
			}
		}
	}

	public static void Reset()
	{
		lock (SyncRoot)
		{
			_sink = null;
			_logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CPAHelperAgentHelper", "Logs", "agent-runtime.log");
		}
	}

	public static void Info(string message)
	{
		Write("INFO", message, null);
	}

	public static void Error(string message, Exception exception = null)
	{
		Write("ERROR", message, exception);
	}

	private static void Write(string level, string message, Exception exception)
	{
		try
		{
			lock (SyncRoot)
			{
				if (_sink != null)
				{
					_sink(level, message, exception);
					return;
				}
				string directoryName = Path.GetDirectoryName(_logFilePath);
				if (!string.IsNullOrWhiteSpace(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				using StreamWriter streamWriter = new StreamWriter(_logFilePath, append: true, Encoding.UTF8);
				streamWriter.WriteLine($"[{level}] {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {message}");
				if (exception != null)
				{
					streamWriter.WriteLine(exception);
				}
			}
		}
		catch
		{
		}
	}
}
