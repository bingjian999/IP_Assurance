using System;
using System.IO;
using System.Text;

namespace CPAHelper.Agent.Adapters;

internal static class JsonFileStore
{
	public static void WriteAllTextAtomic(string filePath, string content, Encoding encoding)
	{
		string directoryName = Path.GetDirectoryName(filePath);
		if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		string text = filePath + "." + Guid.NewGuid().ToString("N") + ".tmp";
		try
		{
			File.WriteAllText(text, content, encoding);
			if (File.Exists(filePath))
			{
				File.Replace(text, filePath, null);
			}
			else
			{
				File.Move(text, filePath);
			}
		}
		finally
		{
			if (File.Exists(text))
			{
				try
				{
					File.Delete(text);
				}
				catch
				{
				}
			}
		}
	}
}
