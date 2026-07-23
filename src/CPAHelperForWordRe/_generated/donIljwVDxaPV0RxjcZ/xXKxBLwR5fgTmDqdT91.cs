using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;

namespace donIljwVDxaPV0RxjcZ;

internal static class xXKxBLwR5fgTmDqdT91
{
	private static readonly (string, double)[] lc9wQgDIqS;

	private static readonly double[] UtWw10nBJG;

	private static readonly Dictionary<string, double> zW7wrYN8Yx;

	public static IEnumerable<(string, string)> csfwB6TYGU()
	{
		(string Name, double Points)[] array = lc9wQgDIqS;
		for (int i = 0; i < array.Length; i++)
		{
			(string, double) tuple = array[i];
			yield return (tuple.Item1, GlAwT6GVSk(tuple.Item2));
		}
		double[] utWw10nBJG = UtWw10nBJG;
		foreach (double num in utWw10nBJG)
		{
			yield return (GlAwT6GVSk(num), GlAwT6GVSk(num));
		}
	}

	public static bool WmHw9yYx65(string P_0, out string P_1)
	{
		if (TryParse(P_0, out var points))
		{
			P_1 = GlAwT6GVSk(points);
			return true;
		}
		P_1 = string.Empty;
		return false;
	}

	public static bool TryParse(string value, out double points)
	{
		points = 0.0;
		string text = upKwIEipHe(value);
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		if (zW7wrYN8Yx.TryGetValue(text, out points))
		{
			return true;
		}
		string s = ymvwHJov3n(text);
		if ((double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out points) || double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out points)) && points >= 0.5 && points <= 1638.0)
		{
			return true;
		}
		points = 0.0;
		return false;
	}

	public static double NgZw6CkHuw(string P_0, double P_1)
	{
		if (!TryParse(P_0, out var points))
		{
			return P_1;
		}
		return points;
	}

	public static string v8Ewuw33fP(string P_0)
	{
		if (!TryParse(P_0, out var points))
		{
			return P_0 ?? string.Empty;
		}
		if (!DTcwDDncsI(points, out var result))
		{
			return GlAwT6GVSk(points);
		}
		return result;
	}

	private static bool DTcwDDncsI(double P_0, out string P_1)
	{
		(string, double)[] array = lc9wQgDIqS;
		for (int i = 0; i < array.Length; i++)
		{
			(string, double) tuple = array[i];
			if (Math.Abs(tuple.Item2 - P_0) < 0.001)
			{
				(P_1, _) = tuple;
				return true;
			}
		}
		P_1 = string.Empty;
		return false;
	}

	private static string GlAwT6GVSk(double P_0)
	{
		return P_0.ToString("0.###", CultureInfo.InvariantCulture);
	}

	private static Dictionary<string, double> GCEwgjiP0A()
	{
		Dictionary<string, double> dictionary = new Dictionary<string, double>(StringComparer.Ordinal);
		(string, double)[] array = lc9wQgDIqS;
		for (int i = 0; i < array.Length; i++)
		{
			(string, double) tuple = array[i];
			agWw8HEiDr(dictionary, tuple.Item1, tuple.Item2);
			agWw8HEiDr(dictionary, tuple.Item1 + "字", tuple.Item2);
			agWw8HEiDr(dictionary, tuple.Item1 + "字号", tuple.Item2);
			if (tuple.Item1.StartsWith("小", StringComparison.Ordinal) && !tuple.Item1.EndsWith("号", StringComparison.Ordinal))
			{
				agWw8HEiDr(dictionary, tuple.Item1 + "号", tuple.Item2);
				agWw8HEiDr(dictionary, tuple.Item1 + "号字", tuple.Item2);
				agWw8HEiDr(dictionary, tuple.Item1 + "号字号", tuple.Item2);
			}
		}
		return dictionary;
	}

	private static void agWw8HEiDr(Dictionary<string, double> P_0, string P_1, double P_2)
	{
		string key = upKwIEipHe(P_1);
		if (!P_0.ContainsKey(key))
		{
			P_0.Add(key, P_2);
		}
	}

	private static string upKwIEipHe(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return string.Empty;
		}
		return new string((from c in P_0.Trim()
			where !char.IsWhiteSpace(c)
			select c).Select(xBVwieTH6H).ToArray());
	}

	private static char xBVwieTH6H(char P_0)
	{
		if (P_0 >= '０' && P_0 <= '９')
		{
			return (char)(48 + P_0 - 65296);
		}
		if (P_0 == '．')
		{
			return '.';
		}
		return P_0;
	}

	private static string ymvwHJov3n(string P_0)
	{
		string text = P_0;
		if (text.EndsWith("磅", StringComparison.Ordinal))
		{
			text = text.Substring(0, text.Length - 1);
		}
		if (text.EndsWith("pt", StringComparison.OrdinalIgnoreCase))
		{
			text = text.Substring(0, text.Length - 2);
		}
		return text;
	}

	static xXKxBLwR5fgTmDqdT91()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		lc9wQgDIqS = new(string, double)[16]
		{
			("初号", 42.0),
			("小初", 36.0),
			("一号", 26.0),
			("小一", 24.0),
			("二号", 22.0),
			("小二", 18.0),
			("三号", 16.0),
			("小三", 15.0),
			("四号", 14.0),
			("小四", 12.0),
			("五号", 10.5),
			("小五", 9.0),
			("六号", 7.5),
			("小六", 6.5),
			("七号", 5.5),
			("八号", 5.0)
		};
		UtWw10nBJG = new double[21]
		{
			5.0, 5.5, 6.5, 7.5, 8.0, 9.0, 10.0, 10.5, 11.0, 12.0,
			14.0, 16.0, 18.0, 20.0, 22.0, 24.0, 26.0, 28.0, 36.0, 48.0,
			72.0
		};
		zW7wrYN8Yx = GCEwgjiP0A();
	}
}
