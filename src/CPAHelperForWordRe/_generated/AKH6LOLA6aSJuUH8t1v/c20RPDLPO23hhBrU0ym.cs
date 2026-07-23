using System;
using System.IO;

namespace AKH6LOLA6aSJuUH8t1v;

internal static class c20RPDLPO23hhBrU0ym
{
	public static bool nejLvR3Pvv(string P_0)
	{
		if (Uri.TryCreate(P_0, UriKind.Absolute, out var result))
		{
			return string.Equals(result.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	public static void z26LWVWmdm(string P_0)
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
