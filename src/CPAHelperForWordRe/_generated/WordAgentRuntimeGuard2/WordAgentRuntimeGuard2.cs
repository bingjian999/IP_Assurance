using System;
using System.Runtime.InteropServices;
using AiConfigBootstrap;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using AiHelper_5;

namespace WordAgentRuntimeGuard2;

internal static class WordAgentRuntimeGuard2
{
	public static string GetNotReadyMessage(Application P_0)
	{
		if (P_0 == null)
		{
			return "Word 应用尚未初始化。";
		}
		try
		{
			if (P_0.Documents == null || P_0.Documents.Count < 1)
			{
				return "当前没有打开的 Word 文档。";
			}
			_ = P_0.ActiveDocument;
		}
		catch (COMException ex) when (IsWordBusyCOMException(ex))
		{
			AiConfigBootstrap.LogWarn("Word 当前正在编辑、弹窗或处理其他操作，暂时不能执行这个 Word 工具。这是临时状态；请稍后重试同一个工具，不要改用 CLI 或其它绕开的方法。" + ex.Message);
			return "Unable to check Word ready state before AI automation: ";
		}
		catch (Exception ex2)
		{
			AiConfigBootstrap.LogWarn("当前没有可用的 Word 活动文档。" + ex2.Message);
			return "Word 应用尚未初始化。";
		}
		return null;
	}

	public static AiHelper_5 CreateNotReadyError(string P_0)
	{
		return AiHelper_5.CreateError(P_0, "word_not_ready", new
		{
			retryable = string.Equals(P_0, "Word 当前正在编辑、弹窗或处理其他操作，暂时不能执行这个 Word 工具。这是临时状态；请稍后重试同一个工具，不要改用 CLI 或其它绕开的方法。", StringComparison.Ordinal),
			retrySameTool = string.Equals(P_0, "Word 当前正在编辑、弹窗或处理其他操作，暂时不能执行这个 Word 工具。这是临时状态；请稍后重试同一个工具，不要改用 CLI 或其它绕开的方法。", StringComparison.Ordinal),
			instruction = "Word 当前正在编辑、弹窗或处理其他操作，暂时不能执行这个 Word 工具。这是临时状态；请稍后重试同一个工具，不要改用 CLI 或其它绕开的方法。"
		});
	}

	public static bool IsRetryableError(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			if (!string.Equals(P_0, "Word 当前正在编辑、弹窗或处理其他操作，暂时不能执行这个 Word 工具。这是临时状态；请稍后重试同一个工具，不要改用 CLI 或其它绕开的方法。", StringComparison.Ordinal) && P_0.IndexOf("Word 应用尚未初始化", StringComparison.OrdinalIgnoreCase) < 0 && P_0.IndexOf("当前没有打开的 Word 文档", StringComparison.OrdinalIgnoreCase) < 0)
			{
				return P_0.IndexOf("当前没有可用的 Word 活动文档", StringComparison.OrdinalIgnoreCase) >= 0;
			}
			return true;
		}
		return false;
	}

	private static bool IsWordBusyCOMException(COMException P_0)
	{
		if (P_0 != null)
		{
			if (P_0.ErrorCode != -2146777998)
			{
				return P_0.ErrorCode == -2146827284;
			}
			return true;
		}
		return false;
	}
}
