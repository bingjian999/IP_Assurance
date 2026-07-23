using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace CPAHelper.Agent.Runtime;

internal static class ProviderRequestBudgetEstimator
{
	internal static ProviderRequestBudgetSnapshot EstimateRequestBody(IDictionary<string, object> requestBody, JsonSerializerOptions jsonOptions, string provider, AgentChatRuntimeOptions.ResolvedSummaryOptions summaryOptions)
	{
		if (requestBody == null)
		{
			throw new ArgumentNullException("requestBody");
		}
		string text = JsonSerializer.Serialize(requestBody, jsonOptions);
		int byteCount = Encoding.UTF8.GetByteCount(text);
		int num = CountCjkLikeChars(text);
		int num2 = Math.Max(0, text.Length - num);
		double val = (double)byteCount / 3.0;
		double val2 = (double)num + (double)num2 / 3.0;
		ProviderRequestBudgetSnapshot providerRequestBudgetSnapshot = new ProviderRequestBudgetSnapshot
		{
			Provider = provider,
			RequestJsonChars = text.Length,
			RequestUtf8Bytes = byteCount,
			ProviderEstimatedTokens = Math.Max(1, (int)Math.Ceiling(Math.Max(val, val2))),
			TriggerTokens = (summaryOptions?.TriggerTokens ?? 0),
			TargetTokens = (summaryOptions?.TargetTokens ?? 0),
			HardLimitTokens = (summaryOptions?.HardLimitTokens ?? 0)
		};
		if (requestBody.TryGetValue("messages", out var value))
		{
			providerRequestBudgetSnapshot.MessageChars = MeasureSerialized(value, jsonOptions);
			foreach (IDictionary<string, object> item in EnumerateDictionaries(value))
			{
				string a = GetString(item, "role");
				if (string.Equals(a, "system", StringComparison.OrdinalIgnoreCase))
				{
					providerRequestBudgetSnapshot.InstructionsChars += MeasureObjectContent(GetValue(item, "content"), jsonOptions);
				}
				if (string.Equals(a, "tool", StringComparison.OrdinalIgnoreCase))
				{
					providerRequestBudgetSnapshot.ToolResultChars += MeasureObjectContent(GetValue(item, "content"), jsonOptions);
				}
				providerRequestBudgetSnapshot.ReasoningChars += MeasureObjectContent(GetValue(item, "reasoning_content"), jsonOptions);
				foreach (IDictionary<string, object> item2 in EnumerateDictionaries(GetValue(item, "tool_calls")))
				{
					foreach (IDictionary<string, object> item3 in EnumerateDictionaries(GetValue(item2, "function")).Take(1))
					{
						providerRequestBudgetSnapshot.ToolCallArgumentChars += MeasureObjectContent(GetValue(item3, "arguments"), jsonOptions);
					}
				}
			}
		}
		if (requestBody.TryGetValue("tools", out var value2))
		{
			providerRequestBudgetSnapshot.ToolSchemaChars = MeasureSerialized(value2, jsonOptions);
		}
		return providerRequestBudgetSnapshot;
	}

	private static object GetValue(IDictionary<string, object> dictionary, string key)
	{
		if (dictionary == null || string.IsNullOrEmpty(key))
		{
			return null;
		}
		if (!dictionary.TryGetValue(key, out var value))
		{
			return null;
		}
		return value;
	}

	private static string GetString(IDictionary<string, object> dictionary, string key)
	{
		return GetValue(dictionary, key)?.ToString();
	}

	private static int MeasureObjectContent(object value, JsonSerializerOptions jsonOptions)
	{
		if (value == null)
		{
			return 0;
		}
		if (!(value is string text))
		{
			return MeasureSerialized(value, jsonOptions);
		}
		return text.Length;
	}

	private static int MeasureSerialized(object value, JsonSerializerOptions jsonOptions)
	{
		if (value == null)
		{
			return 0;
		}
		return JsonSerializer.Serialize(value, jsonOptions).Length;
	}

	private static IEnumerable<IDictionary<string, object>> EnumerateDictionaries(object value)
	{
		if (value is IDictionary<string, object> dictionary)
		{
			yield return dictionary;
		}
		else
		{
			if (!(value is IEnumerable enumerable) || value is string)
			{
				yield break;
			}
			foreach (object item in enumerable)
			{
				if (item is IDictionary<string, object> dictionary2)
				{
					yield return dictionary2;
				}
			}
		}
	}

	private static int CountCjkLikeChars(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < text.Length; i++)
		{
			if (IsCjkLike(text[i]))
			{
				num++;
			}
		}
		return num;
	}

	private static bool IsCjkLike(char ch)
	{
		if ((ch < '⺀' || ch > '\u2eff') && (ch < '\u3000' || ch > '〿') && (ch < '\u3040' || ch > 'ヿ') && (ch < '\u3100' || ch > 'ㄯ') && (ch < 'ㆠ' || ch > 'ㆿ') && (ch < '㐀' || ch > '䶿') && (ch < '一' || ch > '鿿') && (ch < '가' || ch > '\ud7af') && (ch < '豈' || ch > '\ufaff'))
		{
			if (ch >= '\uff00')
			{
				return ch <= '\uffef';
			}
			return false;
		}
		return true;
	}
}
