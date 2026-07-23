using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using AiSseStreamService3;
using SseStreamInitializer;
using AiSseStreamService;

namespace AiConfigBootstrap;

internal static class AiConfigBootstrap
{
	private static readonly object _lockObj;

	private static BlockingCollection<string> _logQueue;

	private static Thread _loggerThread;

	private static string _logFilePath;

	private static string _tempLogPath;

	private static int _logState;

	private static long _droppedCount;

	public static void InitializeLogger()
	{
		lock (_lockObj)
		{
			if (_logState != 1 && _logState != 2)
			{
				_tempLogPath = Path.Combine(Path.GetTempPath(), "IP_Assurance.log");
				try
				{
					string text = Path.Combine(AiSseStreamService.UserDataDir, "Logs");
					Directory.CreateDirectory(text);
					_logFilePath = Path.Combine(text, "addin-runtime.log");
				}
				catch (Exception ex)
				{
					_logFilePath = _tempLogPath;
					WriteToDebug("Logger directory unavailable; using temporary log. " + ex.Message);
				}
				_logQueue = new BlockingCollection<string>(new ConcurrentQueue<string>(), 4096);
				_logState = 1;
				_loggerThread = new Thread(LoggerThreadMain)
				{
					IsBackground = true,
					Name = "IP_Assurance.Logger"
				};
				_loggerThread.Start();
			}
		}
	}

	public static void ShutdownLogger()
	{
		Thread loggerThread;
		lock (_lockObj)
		{
			if (_logState != 1)
			{
				return;
			}
			_logState = 2;
			try
			{
				_logQueue.CompleteAdding();
			}
			catch
			{
			}
			loggerThread = _loggerThread;
		}
		if (loggerThread != null && !loggerThread.Join(TimeSpan.FromSeconds(2.0)))
		{
			WriteToDebug("Logger shutdown timed out after 2 seconds; remaining entries will be flushed by the background writer when possible.");
		}
	}

	public static void LogInfo(string P_0)
	{
		WriteLogEntry("INFO", P_0, null);
	}

	public static void LogWarn(string P_0)
	{
		WriteLogEntry("WARN", P_0, null);
	}

	public static void LogError(string P_0, Exception P_1 = null)
	{
		WriteLogEntry("ERROR", P_0, P_1);
	}

	[Conditional("DEBUG")]
	public static void LogDebug(string P_0)
	{
		WriteLogEntry("DEBUG", P_0, null);
	}

	private static void WriteLogEntry(string P_0, string P_1, Exception P_2)
	{
		string text = string.Format("{0:yyyy-MM-dd HH:mm:ss} [{1}] {2}{3}", DateTime.Now, P_0, P_1, (P_2 != null) ? (Environment.NewLine + P_2) : string.Empty);
		WriteToDebug(text);
		if (Volatile.Read(ref _logState) == 0)
		{
			InitializeLogger();
		}
		BlockingCollection<string> blockingCollection = _logQueue;
		if (Volatile.Read(ref _logState) != 1 || blockingCollection == null)
		{
			return;
		}
		try
		{
			if (!blockingCollection.TryAdd(text))
			{
				long num = Interlocked.Increment(ref _droppedCount);
				WriteToDebug("Logger queue full; dropped line count=" + num + ".");
			}
		}
		catch (InvalidOperationException)
		{
			WriteToDebug("Logger is shutting down; the line was written only to Debug output.");
		}
		catch (Exception ex2)
		{
			WriteToDebug("Logger enqueue failed: " + ex2.Message);
		}
	}

	private static void LoggerThreadMain()
	{
		try
		{
			foreach (string item in _logQueue.GetConsumingEnumerable())
			{
				long num = Interlocked.Exchange(ref _droppedCount, 0L);
				if (num > 0)
				{
					WriteToFile(FormatLogEntry("Logger queue was full; dropped " + num + " log line(s)."));
				}
				WriteToFile(item);
			}
			long num2 = Interlocked.Exchange(ref _droppedCount, 0L);
			if (num2 > 0)
			{
				WriteToFile(FormatLogEntry("Logger queue was full; dropped " + num2 + " log line(s) before shutdown."));
			}
		}
		catch (Exception ex)
		{
			WriteToDebug("Logger writer failed: " + ex);
			WriteToTempLog(FormatLogEntry("Logger writer failed: " + ex.Message));
		}
	}

	private static void WriteToFile(string P_0)
	{
		string text = _logFilePath ?? _tempLogPath;
		try
		{
			TrimLogIfNeeded(text, Encoding.UTF8.GetByteCount(P_0 + Environment.NewLine));
			File.AppendAllText(text, P_0 + Environment.NewLine, Encoding.UTF8);
		}
		catch (Exception ex)
		{
			WriteToDebug("Logger disk write failed for '" + text + "': " + ex.Message);
			if (!string.Equals(text, _tempLogPath, StringComparison.OrdinalIgnoreCase))
			{
				WriteToTempLog(FormatLogEntry("Primary log unavailable; original line follows. " + ex.Message));
				WriteToTempLog(P_0);
			}
		}
	}

	private static void TrimLogIfNeeded(string P_0, int P_1)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(P_0);
			if (!fileInfo.Exists || fileInfo.Length + P_1 <= 5242880)
			{
				return;
			}
			string path = P_0 + "." + 5;
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			for (int num = 4; num >= 1; num--)
			{
				string text = P_0 + "." + num;
				if (File.Exists(text))
				{
					File.Move(text, P_0 + "." + (num + 1));
				}
			}
			if (File.Exists(P_0))
			{
				File.Move(P_0, P_0 + ".1");
			}
		}
		catch (Exception ex)
		{
			WriteToDebug("Logger rotation failed: " + ex.Message);
			if (!string.Equals(P_0, _tempLogPath, StringComparison.OrdinalIgnoreCase))
			{
				WriteToTempLog(FormatLogEntry("Logger rotation failed: " + ex.Message));
			}
		}
	}

	private static void WriteToTempLog(string P_0)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(_tempLogPath))
			{
				_tempLogPath = Path.Combine(Path.GetTempPath(), "IP_Assurance.log");
			}
			TrimLogIfNeeded(_tempLogPath, Encoding.UTF8.GetByteCount(P_0 + Environment.NewLine));
			File.AppendAllText(_tempLogPath, P_0 + Environment.NewLine, Encoding.UTF8);
		}
		catch (Exception ex)
		{
			WriteToDebug("Logger fallback write failed: " + ex.Message);
		}
	}

	private static string FormatLogEntry(string P_0)
	{
		return string.Format("{0:yyyy-MM-dd HH:mm:ss} [WARN] [Logger] {1}", DateTime.Now, P_0);
	}

	private static void WriteToDebug(string P_0)
	{
		try
		{
		}
		catch
		{
		}
	}

	static AiConfigBootstrap()
	{
		SseStreamInitializer.InitializeRuntime();
		_lockObj = new object();
	}
}
