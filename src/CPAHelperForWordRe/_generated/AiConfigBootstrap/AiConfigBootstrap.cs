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
	private static readonly object C10sMv1U6m;

	private static BlockingCollection<string> jPtsbvt3mL;

	private static Thread XAOsS5Zsxy;

	private static string rTyswvhLmE;

	private static string sYpstIgm9D;

	private static int x0vsLnuHe5;

	private static long gLYssQmZ4X;

	public static void nCOs10kYTP()
	{
		lock (C10sMv1U6m)
		{
			if (x0vsLnuHe5 != 1 && x0vsLnuHe5 != 2)
			{
				sYpstIgm9D = Path.Combine(Path.GetTempPath(), "IP_Assurance.log");
				try
				{
					string text = Path.Combine(AiSseStreamService.UserDataDir, "Logs");
					Directory.CreateDirectory(text);
					rTyswvhLmE = Path.Combine(text, "addin-runtime.log");
				}
				catch (Exception ex)
				{
					rTyswvhLmE = sYpstIgm9D;
					jZEsfgSt73("Logger directory unavailable; using temporary log. " + ex.Message);
				}
				jPtsbvt3mL = new BlockingCollection<string>(new ConcurrentQueue<string>(), 4096);
				x0vsLnuHe5 = 1;
				XAOsS5Zsxy = new Thread(ytNs2Um93C)
				{
					IsBackground = true,
					Name = "IP_Assurance.Logger"
				};
				XAOsS5Zsxy.Start();
			}
		}
	}

	public static void pnHsrIThtj()
	{
		Thread xAOsS5Zsxy;
		lock (C10sMv1U6m)
		{
			if (x0vsLnuHe5 != 1)
			{
				return;
			}
			x0vsLnuHe5 = 2;
			try
			{
				jPtsbvt3mL.CompleteAdding();
			}
			catch
			{
			}
			xAOsS5Zsxy = XAOsS5Zsxy;
		}
		if (xAOsS5Zsxy != null && !xAOsS5Zsxy.Join(TimeSpan.FromSeconds(2.0)))
		{
			jZEsfgSt73("Logger shutdown timed out after 2 seconds; remaining entries will be flushed by the background writer when possible.");
		}
	}

	public static void swCsJ4IbrL(string P_0)
	{
		LMasEID2rM("INFO", P_0, null);
	}

	public static void z7Us3dJ6Cl(string P_0)
	{
		LMasEID2rM("WARN", P_0, null);
	}

	public static void ujWsURly3F(string P_0, Exception P_1 = null)
	{
		LMasEID2rM("ERROR", P_0, P_1);
	}

	[Conditional("DEBUG")]
	public static void kPHsKe5Rot(string P_0)
	{
		LMasEID2rM("DEBUG", P_0, null);
	}

	private static void LMasEID2rM(string P_0, string P_1, Exception P_2)
	{
		string text = string.Format("{0:yyyy-MM-dd HH:mm:ss} [{1}] {2}{3}", DateTime.Now, P_0, P_1, (P_2 != null) ? (Environment.NewLine + P_2) : string.Empty);
		jZEsfgSt73(text);
		if (Volatile.Read(ref x0vsLnuHe5) == 0)
		{
			nCOs10kYTP();
		}
		BlockingCollection<string> blockingCollection = jPtsbvt3mL;
		if (Volatile.Read(ref x0vsLnuHe5) != 1 || blockingCollection == null)
		{
			return;
		}
		try
		{
			if (!blockingCollection.TryAdd(text))
			{
				long num = Interlocked.Increment(ref gLYssQmZ4X);
				jZEsfgSt73("Logger queue full; dropped line count=" + num + ".");
			}
		}
		catch (InvalidOperationException)
		{
			jZEsfgSt73("Logger is shutting down; the line was written only to Debug output.");
		}
		catch (Exception ex2)
		{
			jZEsfgSt73("Logger enqueue failed: " + ex2.Message);
		}
	}

	private static void ytNs2Um93C()
	{
		try
		{
			foreach (string item in jPtsbvt3mL.GetConsumingEnumerable())
			{
				long num = Interlocked.Exchange(ref gLYssQmZ4X, 0L);
				if (num > 0)
				{
					Pdms4aenQV(ShIsZDmoZx("Logger queue was full; dropped " + num + " log line(s)."));
				}
				Pdms4aenQV(item);
			}
			long num2 = Interlocked.Exchange(ref gLYssQmZ4X, 0L);
			if (num2 > 0)
			{
				Pdms4aenQV(ShIsZDmoZx("Logger queue was full; dropped " + num2 + " log line(s) before shutdown."));
			}
		}
		catch (Exception ex)
		{
			jZEsfgSt73("Logger writer failed: " + ex);
			RZisYqE1cm(ShIsZDmoZx("Logger writer failed: " + ex.Message));
		}
	}

	private static void Pdms4aenQV(string P_0)
	{
		string text = rTyswvhLmE ?? sYpstIgm9D;
		try
		{
			JMIsjaV0V3(text, Encoding.UTF8.GetByteCount(P_0 + Environment.NewLine));
			File.AppendAllText(text, P_0 + Environment.NewLine, Encoding.UTF8);
		}
		catch (Exception ex)
		{
			jZEsfgSt73("Logger disk write failed for '" + text + "': " + ex.Message);
			if (!string.Equals(text, sYpstIgm9D, StringComparison.OrdinalIgnoreCase))
			{
				RZisYqE1cm(ShIsZDmoZx("Primary log unavailable; original line follows. " + ex.Message));
				RZisYqE1cm(P_0);
			}
		}
	}

	private static void JMIsjaV0V3(string P_0, int P_1)
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
			jZEsfgSt73("Logger rotation failed: " + ex.Message);
			if (!string.Equals(P_0, sYpstIgm9D, StringComparison.OrdinalIgnoreCase))
			{
				RZisYqE1cm(ShIsZDmoZx("Logger rotation failed: " + ex.Message));
			}
		}
	}

	private static void RZisYqE1cm(string P_0)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(sYpstIgm9D))
			{
				sYpstIgm9D = Path.Combine(Path.GetTempPath(), "IP_Assurance.log");
			}
			JMIsjaV0V3(sYpstIgm9D, Encoding.UTF8.GetByteCount(P_0 + Environment.NewLine));
			File.AppendAllText(sYpstIgm9D, P_0 + Environment.NewLine, Encoding.UTF8);
		}
		catch (Exception ex)
		{
			jZEsfgSt73("Logger fallback write failed: " + ex.Message);
		}
	}

	private static string ShIsZDmoZx(string P_0)
	{
		return string.Format("{0:yyyy-MM-dd HH:mm:ss} [WARN] [Logger] {1}", DateTime.Now, P_0);
	}

	private static void jZEsfgSt73(string P_0)
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
		SseStreamInitializer.AlBVL0oCCKQ();
		C10sMv1U6m = new object();
	}
}
