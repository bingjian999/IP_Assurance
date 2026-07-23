using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WordWindowInfo;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;

namespace AiTargetBinder;

internal sealed class AiTargetBinder
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_0
	{
		public Document doc;

		public _G_c__DisplayClass30_0()
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
	private sealed class _G_c__DisplayClass32_0
	{
		public Document doc;

		public _G_c__DisplayClass32_0()
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
	private sealed class _G_c__DisplayClass38_0
	{
		public Document document;

		public _G_c__DisplayClass38_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetFullName()
		{
			return document.FullName;
		}

		internal string GetName()
		{
			return document.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass39_0
	{
		public Document doc;

		public _G_c__DisplayClass39_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetFullName()
		{
			return doc.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass40_0
	{
		public Document document;

		public _G_c__DisplayClass40_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetName()
		{
			return document.Name;
		}
	}

	[CompilerGenerated]
	private string _windowKey;

	[CompilerGenerated]
	private int _windowHwnd;

	[CompilerGenerated]
	private string _documentName;

	[CompilerGenerated]
	private string _documentFullName;

	[CompilerGenerated]
	private string _documentPath;

	private Window _window;

	private Document _document;

	public string WindowKey
	{
		[CompilerGenerated]
		get
		{
			return _windowKey;
		}
		[CompilerGenerated]
		private set
		{
			_windowKey = value;
		}
	}

	public int WindowHwnd
	{
		[CompilerGenerated]
		get
		{
			return _windowHwnd;
		}
		[CompilerGenerated]
		private set
		{
			_windowHwnd = value;
		}
	}

	public string DocumentName
	{
		[CompilerGenerated]
		get
		{
			return _documentName;
		}
		[CompilerGenerated]
		private set
		{
			_documentName = value;
		}
	}

	public string DocumentFullName
	{
		[CompilerGenerated]
		get
		{
			return _documentFullName;
		}
		[CompilerGenerated]
		private set
		{
			_documentFullName = value;
		}
	}

	public string DocumentPath
	{
		[CompilerGenerated]
		get
		{
			return _documentPath;
		}
		[CompilerGenerated]
		private set
		{
			_documentPath = value;
		}
	}

	public bool HasWindow => !string.IsNullOrWhiteSpace(WindowKey);

	public bool HasDocument
	{
		get
		{
			if (string.IsNullOrWhiteSpace(DocumentName))
			{
				return !string.IsNullOrWhiteSpace(DocumentFullName);
			}
			return true;
		}
	}

	public string DisplayName
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(DocumentName))
			{
				return DocumentName;
			}
			if (!string.IsNullOrWhiteSpace(DocumentFullName))
			{
				return Path.GetFileName(DocumentFullName);
			}
			return WindowKey ?? string.Empty;
		}
	}

	public static AiTargetBinder FromWindow(Window P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		AiTargetBinder targetBinder = new AiTargetBinder
		{
			_window = P_0,
			WindowHwnd = GetWindowHwnd(P_0)
		};
		try
		{
			targetBinder.BindDocument(P_0.Document);
		}
		catch
		{
		}
		targetBinder.WindowKey = BuildWindowKeyString(targetBinder.WindowHwnd, targetBinder.DocumentFullName, targetBinder.DocumentName);
		return targetBinder;
	}

	public static AiTargetBinder FromWordWindowInfo(WordWindowInfo P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new AiTargetBinder
		{
			WindowKey = P_0.WindowKey,
			WindowHwnd = P_0.WindowHwnd,
			DocumentName = P_0.DocumentName,
			DocumentFullName = P_0.DocumentFullName,
			DocumentPath = P_0.DocumentPath
		};
	}

	public static string BuildWindowKey(Window P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		int num = GetWindowHwnd(P_0);
		string text = string.Empty;
		string text2 = string.Empty;
		try
		{
			_G_c__DisplayClass30_0 CS_8_locals_4 = new _G_c__DisplayClass30_0();
			CS_8_locals_4.doc = P_0.Document;
			if (CS_8_locals_4.doc != null)
			{
				text = SafeInvokeStringFunc(() => CS_8_locals_4.doc.FullName);
				text2 = SafeInvokeStringFunc(() => CS_8_locals_4.doc.Name);
			}
		}
		catch
		{
		}
		return BuildWindowKeyString(num, text, text2);
	}

	public static int GetWindowHwnd(Window P_0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		try
		{
			return P_0.Hwnd;
		}
		catch
		{
			return 0;
		}
	}

	public void BindDocument(Document P_0)
	{
		_G_c__DisplayClass32_0 CS_8_locals_6 = new _G_c__DisplayClass32_0();
		CS_8_locals_6.doc = P_0;
		if (CS_8_locals_6.doc != null)
		{
			DocumentName = SafeInvokeStringFunc(() => CS_8_locals_6.doc.Name);
			DocumentFullName = SafeInvokeStringFunc(() => CS_8_locals_6.doc.FullName);
			DocumentPath = SafeInvokeStringFunc(() => CS_8_locals_6.doc.Path);
			_document = CS_8_locals_6.doc;
		}
	}

	public Window FindWindow(Application P_0)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(WindowKey))
		{
			return null;
		}
		try
		{
			foreach (Window window in P_0.Windows)
			{
				if (window == null)
				{
					continue;
				}
				if (IsSameComObject(window, _window))
				{
					return window;
				}
				if (EqualsOrdinalIgnoreCase(BuildWindowKey(window), WindowKey))
				{
					return window;
				}
				try
				{
					Document document = window.Document;
					if (IsDocumentMatch(document))
					{
						_window = window;
						return window;
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return null;
	}

	public Document ResolveDocument(Application P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		Document document = FindDocumentByReference(P_0);
		if (document != null)
		{
			return document;
		}
		Window window = FindWindow(P_0);
		if (window != null)
		{
			try
			{
				Document document2 = window.Document;
				BindDocument(document2);
				return document2;
			}
			catch
			{
			}
		}
		return FindDocumentByFullName(P_0, DocumentFullName) ?? FindDocumentByName(P_0, DocumentName);
	}

	public bool TryActivate(Application P_0, out string P_1)
	{
		P_1 = null;
		if (P_0 == null)
		{
			P_1 = "Word 应用尚未初始化。";
			return false;
		}
		Window window = FindWindow(P_0);
		if (window != null)
		{
			try
			{
				window.Activate();
				BindDocument(window.Document);
				return true;
			}
			catch (Exception ex)
			{
				P_1 = "无法激活目标 Word 窗口：" + ex.Message;
				return false;
			}
		}
		Document document = ResolveDocument(P_0);
		if (document != null)
		{
			try
			{
				document.Activate();
				BindDocument(document);
				return true;
			}
			catch (Exception ex2)
			{
				P_1 = "无法激活目标 Word 文档：" + ex2.Message;
				return false;
			}
		}
		P_1 = BuildUnavailableMessage();
		return false;
	}

	public string BuildUnavailableMessage()
	{
		string text = DisplayName;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "(未知目标)";
		}
		return "AI 助手绑定的目标 Word 文档已关闭或不可用，已停止读取/写入以避免操作当前活动文档。目标文档：" + text;
	}

	private Document FindDocumentByReference(Application P_0)
	{
		if (P_0 == null || _document == null)
		{
			return null;
		}
		try
		{
			foreach (Document document in P_0.Documents)
			{
				if (IsSameComObject(document, _document))
				{
					BindDocument(document);
					return document;
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private bool IsDocumentMatch(Document P_0)
	{
		_G_c__DisplayClass38_0 CS_8_locals_5 = new _G_c__DisplayClass38_0();
		CS_8_locals_5.document = P_0;
		if (CS_8_locals_5.document == null)
		{
			return false;
		}
		if (IsSameComObject(CS_8_locals_5.document, _document))
		{
			return true;
		}
		if (!StringEqualsIgnoreCase(SafeInvokeStringFunc(() => CS_8_locals_5.document.FullName), DocumentFullName))
		{
			return StringEqualsIgnoreCase(SafeInvokeStringFunc(() => CS_8_locals_5.document.Name), DocumentName);
		}
		return true;
	}

	private static Document FindDocumentByFullName(Application P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		string text = P_1.Trim();
		try
		{
			IEnumerator enumerator = P_0.Documents.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					_G_c__DisplayClass39_0 CS_8_locals_3 = new _G_c__DisplayClass39_0();
					CS_8_locals_3.doc = (Document)enumerator.Current;
					if (StringEqualsIgnoreCase(SafeInvokeStringFunc(() => CS_8_locals_3.doc.FullName), text))
					{
						return CS_8_locals_3.doc;
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
		}
		catch
		{
		}
		return null;
	}

	private static Document FindDocumentByName(Application P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		string text = P_1.Trim();
		try
		{
			IEnumerator enumerator = P_0.Documents.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					_G_c__DisplayClass40_0 CS_8_locals_3 = new _G_c__DisplayClass40_0();
					CS_8_locals_3.document = (Document)enumerator.Current;
					if (StringEqualsIgnoreCase(SafeInvokeStringFunc(() => CS_8_locals_3.document.Name), text))
					{
						return CS_8_locals_3.document;
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
		}
		catch
		{
		}
		return null;
	}

	private static bool StringEqualsIgnoreCase(string P_0, string P_1)
	{
		return EqualsOrdinalIgnoreCase(P_0, P_1);
	}

	private static string BuildWindowKeyString(int P_0, string P_1, string P_2)
	{
		string text = ((!string.IsNullOrWhiteSpace(P_1)) ? P_1 : P_2);
		if (P_0 != 0 && !string.IsNullOrWhiteSpace(text))
		{
			return "hwnd:" + P_0.ToString(CultureInfo.InvariantCulture) + "|doc:" + text;
		}
		if (P_0 != 0)
		{
			return "hwnd:" + P_0.ToString(CultureInfo.InvariantCulture);
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			return "doc:" + text;
		}
		return string.Empty;
	}

	private static bool EqualsOrdinalIgnoreCase(string P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_0) || string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		return string.Equals(P_0.Trim(), P_1.Trim(), StringComparison.OrdinalIgnoreCase);
	}

	private static bool IsSameComObject(object P_0, object P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		if (P_0 == P_1)
		{
			return true;
		}
		if (!Marshal.IsComObject(P_0) || !Marshal.IsComObject(P_1))
		{
			return false;
		}
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			intPtr = Marshal.GetIUnknownForObject(P_0);
			intPtr2 = Marshal.GetIUnknownForObject(P_1);
			return intPtr == intPtr2;
		}
		catch
		{
			return false;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.Release(intPtr);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				Marshal.Release(intPtr2);
			}
		}
	}

	private static string SafeInvokeStringFunc(Func<string> P_0)
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

	public AiTargetBinder()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
