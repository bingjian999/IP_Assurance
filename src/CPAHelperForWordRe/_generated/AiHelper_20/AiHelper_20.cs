using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AiSseStreamService3;
using SseStreamInitializer;

namespace AiHelper_20;

internal static class AiHelper_20
{
	private static readonly (string, double)[] _chineseFontSizes;

	private static readonly double[] _numericFontSizes;

	private static readonly Dictionary<string, double> _fontSizeLookup;

	public static IEnumerable<(string, string)> GetFontSizeOptions()
	{
		(string Name, double Points)[] array = _chineseFontSizes;
		for (int i = 0; i < array.Length; i++)
		{
			(string, double) tuple = array[i];
			yield return (tuple.Item1, FormatFontSize(tuple.Item2));
		}
		double[] numericFontSizes = _numericFontSizes;
		foreach (double num in numericFontSizes)
		{
			yield return (FormatFontSize(num), FormatFontSize(num));
		}
	}

	public static bool TryFormatFontSize(string P_0, out string P_1)
	{
		if (TryParse(P_0, out var points))
		{
			P_1 = FormatFontSize(points);
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
		if (_fontSizeLookup.TryGetValue(text, out points))
		{
			return true;
		}
		string s = StripFontSizeSuffix(text);
		if ((double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out points) || double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out points)) && points >= 0.5 && points <= 1638.0)
		{
			return true;
		}
		points = 0.0;
		return false;
	}

	public static double GetConfigFontSize(string P_0, double P_1)
	{
		if (!TryParse(P_0, out var points))
		{
			return P_1;
		}
		return points;
	}

	public static string NormalizeFontSize(string P_0)
	{
		if (!TryParse(P_0, out var points))
		{
			return P_0 ?? string.Empty;
		}
		if (!DTcwDDncsI(points, out var result))
		{
			return FormatFontSize(points);
		}
		return result;
	}

	private static bool DTcwDDncsI(double P_0, out string P_1)
	{
		(string, double)[] array = _chineseFontSizes;
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

	private static string FormatFontSize(double P_0)
	{
		return P_0.ToString("0.###", CultureInfo.InvariantCulture);
	}

	private static Dictionary<string, double> BuildFontSizeLookup()
	{
		Dictionary<string, double> dictionary = new Dictionary<string, double>(StringComparer.Ordinal);
		(string, double)[] array = _chineseFontSizes;
		for (int i = 0; i < array.Length; i++)
		{
			(string, double) tuple = array[i];
			AddFontSizeAlias(dictionary, tuple.Item1, tuple.Item2);
			AddFontSizeAlias(dictionary, tuple.Item1 + "字", tuple.Item2);
			AddFontSizeAlias(dictionary, tuple.Item1 + "字号", tuple.Item2);
			if (tuple.Item1.StartsWith("小", StringComparison.Ordinal) && !tuple.Item1.EndsWith("号", StringComparison.Ordinal))
			{
				AddFontSizeAlias(dictionary, tuple.Item1 + "号", tuple.Item2);
				AddFontSizeAlias(dictionary, tuple.Item1 + "号字", tuple.Item2);
				AddFontSizeAlias(dictionary, tuple.Item1 + "号字号", tuple.Item2);
			}
		}
		return dictionary;
	}

	private static void AddFontSizeAlias(Dictionary<string, double> P_0, string P_1, double P_2)
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
			select c).Select(NormalizeFullWidthChar).ToArray());
	}

	private static char NormalizeFullWidthChar(char P_0)
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

	private static string StripFontSizeSuffix(string P_0)
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

	static AiHelper_20()
	{
		SseStreamInitializer.InitializeRuntime();
		_chineseFontSizes = new(string, double)[16]
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
		_numericFontSizes = new double[21]
		{
			5.0, 5.5, 6.5, 7.5, 8.0, 9.0, 10.0, 10.5, 11.0, 12.0,
			14.0, 16.0, 18.0, 20.0, 22.0, 24.0, 26.0, 28.0, 36.0, 48.0,
			72.0
		};
		_fontSizeLookup = BuildFontSizeLookup();
	}
}
