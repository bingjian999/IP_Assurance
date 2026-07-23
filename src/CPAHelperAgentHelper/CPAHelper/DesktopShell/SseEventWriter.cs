using System.IO;
using System.Threading.Tasks;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal static class SseEventWriter
{
	public static Task WriteAsync(StreamWriter writer, SseEvent evt, object syncRoot)
	{
		WriteSync(writer, syncRoot, evt);
		return Task.CompletedTask;
	}

	public static void WriteSync(StreamWriter writer, object syncRoot, SseEvent evt)
	{
		try
		{
			lock (syncRoot)
			{
				writer.Write(evt.ToSseLine());
				writer.Flush();
			}
		}
		catch
		{
		}
	}

	public static void WriteCommentSync(StreamWriter writer, object syncRoot, string comment)
	{
		try
		{
			lock (syncRoot)
			{
				writer.Write(": ");
				writer.Write(string.IsNullOrWhiteSpace(comment) ? "heartbeat" : comment);
				writer.Write("\n\n");
				writer.Flush();
			}
		}
		catch
		{
		}
	}
}
