using System.Collections.Generic;
using System.Text.RegularExpressions;
using AiSseStreamService3;
using SseStreamInitializer;
using UiHelper_4;
using TextRange;

namespace UiHelper_5;

internal static class UiHelper_5
{
	public static readonly Regex K4hSE7usVJ;

	private static readonly Regex o28S2q7DEq;

	public static List<TextRange> teSSr7AnNl(string P_0)
	{
		List<TextRange> list = new List<TextRange>();
		if (string.IsNullOrEmpty(P_0))
		{
			return list;
		}
		foreach (Match item in o28S2q7DEq.Matches(P_0))
		{
			list.Add(new TextRange(item.Index, item.Length));
		}
		return list;
	}

	public static bool bcbSJ1pxpn(string P_0, Match P_1, UiHelper_4 P_2, IList<TextRange> P_3)
	{
		if (P_1 == null || P_2 == null)
		{
			return false;
		}
		if (P_2.ExcludeDateFormat && tnNSKM7Uqc(P_1.Index, P_1.Length, P_3))
		{
			return true;
		}
		int num = P_1.Index + P_1.Length;
		if (!string.IsNullOrEmpty(P_0) && num < P_0.Length)
		{
			char c = P_0[num];
			if (P_2.ExcludeYear && c == '年')
			{
				return true;
			}
			if (P_2.ExcludeMonth && c == '月')
			{
				return true;
			}
			if (P_2.ExcludeDay && c == '日')
			{
				return true;
			}
			if (P_2.ExcludeNumber && c == '号')
			{
				return true;
			}
			if (P_2.ExcludePercent && (c == '%' || c == '％'))
			{
				return true;
			}
		}
		if (P_2.ExcludeOrdinal && !string.IsNullOrEmpty(P_0) && P_1.Index > 0 && P_0[P_1.Index - 1] == '第')
		{
			return true;
		}
		if (P_2.IncludeUnitOnly)
		{
			return !q4TS36j7cA(P_0, P_1, P_2.UnitText);
		}
		return false;
	}

	public static bool q4TS36j7cA(string P_0, Match P_1, string P_2)
	{
		if (string.IsNullOrEmpty(P_0) || P_1 == null || string.IsNullOrWhiteSpace(P_2))
		{
			return false;
		}
		int i;
		for (i = P_1.Index + P_1.Length; i < P_0.Length && VYxSUGqOsC(P_0[i]); i++)
		{
		}
		if (i + P_2.Length <= P_0.Length)
		{
			return string.CompareOrdinal(P_0, i, P_2, 0, P_2.Length) == 0;
		}
		return false;
	}

	private static bool VYxSUGqOsC(char P_0)
	{
		if (P_0 != ' ' && P_0 != '\t' && P_0 != '\u00a0')
		{
			return P_0 == '\u3000';
		}
		return true;
	}

	private static bool tnNSKM7Uqc(int P_0, int P_1, IList<TextRange> P_2)
	{
		if (P_2 == null || P_2.Count == 0)
		{
			return false;
		}
		int num = P_0 + P_1;
		foreach (TextRange item in P_2)
		{
			if (P_0 >= item.Start && num <= item.End)
			{
				return true;
			}
		}
		return false;
	}

	static UiHelper_5()
	{
		SseStreamInitializer.InitializeRuntime();
		K4hSE7usVJ = new Regex("(-?\\d{1,3}(,\\d{3})*(,\\d{3}|\\d{0,13})(\\.\\d+)?)", RegexOptions.Compiled);
		o28S2q7DEq = new Regex("(?<!\\d)\\d{2,4}\\s*[-/.]\\s*\\d{1,2}\\s*[-/.]\\s*\\d{1,2}(?!\\d)", RegexOptions.Compiled);
	}
}
