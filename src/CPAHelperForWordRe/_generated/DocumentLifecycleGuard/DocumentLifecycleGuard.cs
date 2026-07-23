using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using WordWindowInfo;
using AiSseStreamService3;
using AiTargetBinder;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;

namespace DocumentLifecycleGuard;

internal static class DocumentLifecycleGuard
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass11_0
	{
		public Document doc;

		public _G_c__DisplayClass11_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetFullName()
		{
			return doc.FullName;
		}

		internal string GetName()
		{
			return doc.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass12_0
	{
		public Document doc;

		public _G_c__DisplayClass12_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetName()
		{
			return doc.Name;
		}

		internal string GetFullName()
		{
			return doc.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass17_0
	{
		public Document doc;

		public _G_c__DisplayClass17_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetName()
		{
			return doc.Name;
		}

		internal string GetFullName()
		{
			return doc.FullName;
		}

		internal string GetPath()
		{
			return doc.Path;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass17_1
	{
		public Selection selection;

		public _G_c__DisplayClass17_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetSelectionText()
		{
			return selection.Range.Text;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass7_0
	{
		public Document doc;

		public Selection selection;

		public _G_c__DisplayClass7_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetName()
		{
			return doc.Name;
		}

		internal string GetFullName()
		{
			return doc.FullName;
		}

		internal string GetPath()
		{
			return doc.Path;
		}

		internal string GetSelectionText()
		{
			return selection.Range.Text;
		}
	}

	private static readonly AsyncLocal<WordWindowInfo> _currentWindow;

	public static WordWindowInfo Current => _currentWindow.Value;

	public static void SetCurrentWindow(WordWindowInfo P_0)
	{
		_currentWindow.Value = P_0;
	}

	public static object GetCachedProperty(string P_0)
	{
		WordWindowInfo current = Current;
		if (current == null || string.IsNullOrWhiteSpace(P_0))
		{
			return null;
		}
		if (!MatchesCacheKey(current.WordOpenXmlCacheDocumentKey, P_0))
		{
			return null;
		}
		return current.WordOpenXmlCache;
	}

	public static void SetCachedProperty(string P_0, object P_1)
	{
		WordWindowInfo current = Current;
		if (current != null && !string.IsNullOrWhiteSpace(P_0) && P_1 != null)
		{
			current.WordOpenXmlCacheDocumentKey = P_0;
			current.WordOpenXmlCache = P_1;
		}
	}

	public static void ClearWordOpenXmlCache()
	{
		WordWindowInfo current = Current;
		if (current != null)
		{
			current.WordOpenXmlCacheDocumentKey = null;
			current.WordOpenXmlCache = null;
		}
	}

	public static WordWindowInfo CaptureWindowInfo(Application P_0)
	{
		WordWindowInfo windowInfo = new WordWindowInfo();
		if (P_0 == null)
		{
			return windowInfo;
		}
		try
		{
			_G_c__DisplayClass7_0 CS_8_locals_12 = new _G_c__DisplayClass7_0();
			CS_8_locals_12.doc = P_0.ActiveDocument;
			if (CS_8_locals_12.doc != null)
			{
				windowInfo.DocumentName = SafeReadString(() => CS_8_locals_12.doc.Name);
				windowInfo.DocumentFullName = SafeReadString(() => CS_8_locals_12.doc.FullName);
				windowInfo.DocumentPath = SafeReadString(() => CS_8_locals_12.doc.Path);
			}
			CS_8_locals_12.selection = P_0.Selection;
			if (CS_8_locals_12.selection != null && CS_8_locals_12.selection.Range != null)
			{
				windowInfo.SelectionStart = CS_8_locals_12.selection.Range.Start;
				windowInfo.SelectionEnd = CS_8_locals_12.selection.Range.End;
				windowInfo.SelectionTextLength = SafeReadString(() => CS_8_locals_12.selection.Range.Text).Length;
				windowInfo.PageNumber = GetPageNumber(CS_8_locals_12.selection.Range);
			}
		}
		catch
		{
		}
		return windowInfo;
	}

	public static WordWindowInfo CaptureWindowInfoWithBinder(Application P_0, AiTargetBinder P_1)
	{
		if (P_1 == null)
		{
			return CaptureWindowInfo(P_0);
		}
		if (P_0 == null)
		{
			throw new InvalidOperationException("Word 应用尚未初始化。");
		}
		if (!P_1.TryActivate(P_0, out var message))
		{
			throw new InvalidOperationException(message);
		}
		Document document = P_1.ResolveDocument(P_0);
		if (document == null)
		{
			throw new InvalidOperationException(P_1.BuildUnavailableMessage());
		}
		WordWindowInfo windowInfo = BuildWindowInfo(P_0, document, P_1.WindowKey, P_1.WindowHwnd);
		if (!windowInfo.HasDocument)
		{
			throw new InvalidOperationException(P_1.BuildUnavailableMessage());
		}
		P_1.BindDocument(document);
		return windowInfo;
	}

	public static void ValidatePaneTarget(Application P_0)
	{
		WordWindowInfo current = Current;
		if (current == null || !current.HasPaneTarget || AiTargetBinder.FromWordWindowInfo(current).TryActivate(P_0, out var message))
		{
			return;
		}
		throw new InvalidOperationException(message);
	}

	public static Document GetActiveDocument(Application P_0, string P_1 = "")
	{
		if (P_0 == null)
		{
			throw new InvalidOperationException("Word 应用尚未初始化。");
		}
		string text = P_1;
		bool flag = false;
		WordWindowInfo current = Current;
		if (string.IsNullOrWhiteSpace(text) && current != null && current.HasPaneTarget)
		{
			Document document = AiTargetBinder.FromWordWindowInfo(current).ResolveDocument(P_0);
			if (document != null)
			{
				return document;
			}
			flag = true;
			text = ((!string.IsNullOrWhiteSpace(current.DocumentFullName)) ? current.DocumentFullName : current.DocumentName);
		}
		if (string.IsNullOrWhiteSpace(text) && current != null && current.HasDocument)
		{
			text = ((!string.IsNullOrWhiteSpace(current.DocumentFullName)) ? current.DocumentFullName : current.DocumentName);
			flag = true;
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			if (flag)
			{
				throw new InvalidOperationException("本轮 Agent 请求开始时的目标文档已关闭或不可用，已停止写入以避免改到当前活动文档。目标文档：" + ((current == null) ? string.Empty : current.DocumentName));
			}
			return P_0.ActiveDocument ?? throw new InvalidOperationException("当前没有打开的 Word 文档。");
		}
		Document document2 = FindDocumentByName(P_0, text);
		if (document2 != null)
		{
			return document2;
		}
		if (flag)
		{
			throw new InvalidOperationException("本轮 Agent 请求开始时的目标文档已关闭或不可用，已停止写入以避免改到当前活动文档。目标文档：" + text);
		}
		throw new InvalidOperationException("未找到 Word 文档“" + P_1 + "”。");
	}

	public static bool IsCurrentDocument(Document P_0)
	{
		_G_c__DisplayClass11_0 CS_8_locals_4 = new _G_c__DisplayClass11_0();
		CS_8_locals_4.doc = P_0;
		WordWindowInfo current = Current;
		if (CS_8_locals_4.doc == null || current == null || !current.HasDocument)
		{
			return false;
		}
		string text = SafeReadString(() => CS_8_locals_4.doc.FullName);
		string text2 = SafeReadString(() => CS_8_locals_4.doc.Name);
		if (!MatchesCacheKey(text, current.DocumentFullName) && !MatchesCacheKey(text2, current.DocumentName))
		{
			return MatchesCacheKey(text2, Path.GetFileName(current.DocumentFullName ?? string.Empty));
		}
		return true;
	}

	private static Document FindDocumentByName(Application P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		string text = P_1.Trim();
		string fileName = Path.GetFileName(text);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
		bool flag = IsAbsolutePath(text);
		IEnumerator enumerator = P_0.Documents.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				_G_c__DisplayClass12_0 CS_8_locals_5 = new _G_c__DisplayClass12_0();
				CS_8_locals_5.doc = (Document)enumerator.Current;
				string text2 = SafeReadString(() => CS_8_locals_5.doc.Name);
				if (MatchesCacheKey(SafeReadString(() => CS_8_locals_5.doc.FullName), text))
				{
					return CS_8_locals_5.doc;
				}
				if (!flag && (MatchesCacheKey(text2, text) || MatchesCacheKey(text2, fileName) || MatchesCacheKey(Path.GetFileNameWithoutExtension(text2), fileNameWithoutExtension)))
				{
					return CS_8_locals_5.doc;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}

	private static bool IsAbsolutePath(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		if (P_0.IndexOf('\\') < 0 && P_0.IndexOf('/') < 0)
		{
			return P_0.IndexOf(':') >= 0;
		}
		return true;
	}

	private static bool MatchesCacheKey(string P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_0) || string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		return string.Equals(P_0.Trim(), P_1.Trim(), StringComparison.OrdinalIgnoreCase);
	}

	private static string SafeReadString(Func<string> P_0)
	{
		try
		{
			string text = P_0();
			return (text == null) ? string.Empty : Convert.ToString(text, CultureInfo.InvariantCulture);
		}
		catch
		{
			return string.Empty;
		}
	}

	private static int GetPageNumber(Range P_0)
	{
		try
		{
			return (P_0 != null) ? ((int)(dynamic)P_0.get_Information(WdInformation.wdActiveEndPageNumber)) : 0;
		}
		catch
		{
			return 0;
		}
	}

	private static WordWindowInfo BuildWindowInfo(Application P_0, Document P_1, string P_2, int P_3)
	{
		_G_c__DisplayClass17_0 CS_8_locals_11 = new _G_c__DisplayClass17_0();
		CS_8_locals_11.doc = P_1;
		WordWindowInfo windowInfo = new WordWindowInfo
		{
			WindowKey = (P_2 ?? string.Empty),
			WindowHwnd = P_3,
			DocumentName = SafeReadString(() => CS_8_locals_11.doc.Name),
			DocumentFullName = SafeReadString(() => CS_8_locals_11.doc.FullName),
			DocumentPath = SafeReadString(() => CS_8_locals_11.doc.Path)
		};
		try
		{
			_G_c__DisplayClass17_1 CS_8_locals_12 = new _G_c__DisplayClass17_1();
			CS_8_locals_12.selection = P_0.Selection;
			if (CS_8_locals_12.selection != null && CS_8_locals_12.selection.Range != null)
			{
				windowInfo.SelectionStart = CS_8_locals_12.selection.Range.Start;
				windowInfo.SelectionEnd = CS_8_locals_12.selection.Range.End;
				windowInfo.SelectionTextLength = SafeReadString(() => CS_8_locals_12.selection.Range.Text).Length;
				windowInfo.PageNumber = GetPageNumber(CS_8_locals_12.selection.Range);
			}
		}
		catch
		{
		}
		return windowInfo;
	}

	static DocumentLifecycleGuard()
	{
		SseStreamInitializer.InitializeRuntime();
		_currentWindow = new AsyncLocal<WordWindowInfo>();
	}
}
