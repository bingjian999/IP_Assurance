using System.Collections.Generic;

namespace Helper_15;

internal static class Helper_15
{
	public static void Add(Dictionary<string, object> result, string name, object value)
	{
		if (value != null && (!(value is string value2) || !string.IsNullOrWhiteSpace(value2)))
		{
			result[name] = value;
		}
	}
}
