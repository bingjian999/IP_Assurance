using System;
using System.IO;

namespace FileDownloadHelper2;

internal static class FileDownloadHelper2
{
	public static bool IsHttpsUrl(string P_0)
	{
		if (Uri.TryCreate(P_0, UriKind.Absolute, out var result))
		{
			return string.Equals(result.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	public static void DeleteFileIfExists(string P_0)
	{
		try
		{
			if (!string.IsNullOrWhiteSpace(P_0) && File.Exists(P_0))
			{
				File.Delete(P_0);
			}
		}
		catch
		{
		}
	}
}
