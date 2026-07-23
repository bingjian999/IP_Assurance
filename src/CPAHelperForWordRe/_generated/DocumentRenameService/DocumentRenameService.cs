using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService;
using Helper_10;
using LoggerInitializer;

namespace DocumentRenameService;

internal static class DocumentRenameService
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0
	{
		public Document doc;

		public _G_c__DisplayClass2_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string getDocumentName()
		{
			return doc.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass4_0
	{
		public Document document;

		public _G_c__DisplayClass4_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string getDocumentPath()
		{
			return document.Path;
		}

		internal string getDocumentFullName()
		{
			return document.FullName;
		}

		internal string getDocumentName()
		{
			return document.Name;
		}

		internal bool isReadOnly()
		{
			return document.ReadOnly;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass5_0
	{
		public Document doc;

		public _G_c__DisplayClass5_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string getDocumentName()
		{
			return doc.Name;
		}

		internal string getDocumentFullName()
		{
			return doc.FullName;
		}

		internal string getDocumentPath()
		{
			return doc.Path;
		}

		internal bool isDocumentSaved()
		{
			return doc.Saved;
		}
	}

	private static Application App => WordTableToolService.WordApp;

	internal static string getActiveDocumentName()
	{
		_G_c__DisplayClass2_0 CS_8_locals_3 = new _G_c__DisplayClass2_0();
		CS_8_locals_3.doc = getActiveDocument();
		if (CS_8_locals_3.doc != null)
		{
			return tryGetString(() => CS_8_locals_3.doc.Name);
		}
		return null;
	}

	internal static string getActiveDocumentNameWithoutExtension()
	{
		string text = getActiveDocumentName();
		if (string.IsNullOrWhiteSpace(text))
		{
			return string.Empty;
		}
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
		if (!string.IsNullOrWhiteSpace(fileNameWithoutExtension))
		{
			return fileNameWithoutExtension;
		}
		return text;
	}

	internal static bool validateRenamePreconditions(out string P_0)
	{
		_G_c__DisplayClass4_0 CS_8_locals_6 = new _G_c__DisplayClass4_0();
		CS_8_locals_6.document = getActiveDocument();
		if (CS_8_locals_6.document == null)
		{
			P_0 = "当前没有打开的 Word 文档。";
			return false;
		}
		string value = tryGetString(() => CS_8_locals_6.document.Path);
		string text = tryGetString(() => CS_8_locals_6.document.FullName);
		string value2 = getFileExtension(tryGetString(() => CS_8_locals_6.document.Name), text);
		if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(value2))
		{
			P_0 = "当前文件无法重命名，请先保存文档。";
			return false;
		}
		if (tryGetBool(() => CS_8_locals_6.document.ReadOnly, false))
		{
			P_0 = "当前文档为只读状态，无法重命名。";
			return false;
		}
		if (!File.Exists(text))
		{
			P_0 = "当前文档原文件不存在或路径不可访问，无法重命名。";
			return false;
		}
		P_0 = null;
		return true;
	}

	internal static Helper_10 renameDocument(string P_0, Func<string, bool> P_1 = null)
	{
		_G_c__DisplayClass5_0 CS_8_locals_7 = new _G_c__DisplayClass5_0();
		if (!validateRenamePreconditions(out var message))
		{
			throw new InvalidOperationException(message);
		}
		CS_8_locals_7.doc = getActiveDocument();
		string text = tryGetString(() => CS_8_locals_7.doc.Name);
		string text2 = tryGetString(() => CS_8_locals_7.doc.FullName);
		string path = tryGetString(() => CS_8_locals_7.doc.Path);
		string text3 = getFileExtension(text, text2);
		string text4 = validateNewFileName(P_0);
		string text5 = Path.Combine(path, text4 + text3);
		if (arePathsEqual(text2, text5))
		{
			return Helper_10.CreateNoChangeResult(text2);
		}
		if (File.Exists(text5))
		{
			throw new InvalidOperationException("目标文件已存在，请更换一个文件名。");
		}
		if (!tryGetBool(() => CS_8_locals_7.doc.Saved, true))
		{
			string text6 = "当前文档有尚未保存的修改。继续重命名将保存这些修改，是否继续？";
			if (!(P_1?.Invoke(text6) ?? LoggerInitializer.ShowConfirm(text6, "IP_Assurance")))
			{
				return Helper_10.CreateCancelledResult(text2);
			}
		}
		saveDocumentAs(CS_8_locals_7.doc, text5);
		if (!File.Exists(text5))
		{
			throw new InvalidOperationException("重命名失败：新文件未成功生成。");
		}
		try
		{
			CS_8_locals_7.doc.Activate();
		}
		catch
		{
		}
		bool flag = true;
		string text7 = null;
		if (!arePathsEqual(text2, text5) && File.Exists(text2))
		{
			try
			{
				File.Delete(text2);
				flag = !File.Exists(text2);
				if (!flag)
				{
					text7 = "旧文件仍然存在，可能被其他程序占用。";
				}
			}
			catch (Exception ex)
			{
				flag = false;
				text7 = ex.Message;
			}
		}
		return Helper_10.ONEBochSpq(text2, text5, flag, text7);
	}

	private static void saveDocumentAs(Document P_0, string P_1)
	{
		object FileName = P_1;
		object FileFormat = getSaveFormat(P_0);
		try
		{
			object LockComments = Type.Missing;
			object Password = Type.Missing;
			object AddToRecentFiles = Type.Missing;
			object WritePassword = Type.Missing;
			object ReadOnlyRecommended = Type.Missing;
			object EmbedTrueTypeFonts = Type.Missing;
			object SaveNativePictureFormat = Type.Missing;
			object SaveFormsData = Type.Missing;
			object SaveAsAOCELetter = Type.Missing;
			object Encoding = Type.Missing;
			object InsertLineBreaks = Type.Missing;
			object AllowSubstitutions = Type.Missing;
			object LineEnding = Type.Missing;
			object AddBiDiMarks = Type.Missing;
			object CompatibilityMode = Type.Missing;
			P_0.SaveAs2(ref FileName, ref FileFormat, ref LockComments, ref Password, ref AddToRecentFiles, ref WritePassword, ref ReadOnlyRecommended, ref EmbedTrueTypeFonts, ref SaveNativePictureFormat, ref SaveFormsData, ref SaveAsAOCELetter, ref Encoding, ref InsertLineBreaks, ref AllowSubstitutions, ref LineEnding, ref AddBiDiMarks, ref CompatibilityMode);
		}
		catch (COMException)
		{
			FileName = P_1;
			FileFormat = getSaveFormat(P_0);
			object CompatibilityMode = Type.Missing;
			object AddBiDiMarks = Type.Missing;
			object LineEnding = Type.Missing;
			object AllowSubstitutions = Type.Missing;
			object InsertLineBreaks = Type.Missing;
			object Encoding = Type.Missing;
			object SaveAsAOCELetter = Type.Missing;
			object SaveFormsData = Type.Missing;
			object SaveNativePictureFormat = Type.Missing;
			object EmbedTrueTypeFonts = Type.Missing;
			object ReadOnlyRecommended = Type.Missing;
			object WritePassword = Type.Missing;
			object AddToRecentFiles = Type.Missing;
			object Password = Type.Missing;
			P_0.SaveAs(ref FileName, ref FileFormat, ref CompatibilityMode, ref AddBiDiMarks, ref LineEnding, ref AllowSubstitutions, ref InsertLineBreaks, ref Encoding, ref SaveAsAOCELetter, ref SaveFormsData, ref SaveNativePictureFormat, ref EmbedTrueTypeFonts, ref ReadOnlyRecommended, ref WritePassword, ref AddToRecentFiles, ref Password);
		}
		catch (MissingMethodException)
		{
			FileName = P_1;
			FileFormat = getSaveFormat(P_0);
			object Password = Type.Missing;
			object AddToRecentFiles = Type.Missing;
			object WritePassword = Type.Missing;
			object ReadOnlyRecommended = Type.Missing;
			object EmbedTrueTypeFonts = Type.Missing;
			object SaveNativePictureFormat = Type.Missing;
			object SaveFormsData = Type.Missing;
			object SaveAsAOCELetter = Type.Missing;
			object Encoding = Type.Missing;
			object InsertLineBreaks = Type.Missing;
			object AllowSubstitutions = Type.Missing;
			object LineEnding = Type.Missing;
			object AddBiDiMarks = Type.Missing;
			object CompatibilityMode = Type.Missing;
			P_0.SaveAs(ref FileName, ref FileFormat, ref Password, ref AddToRecentFiles, ref WritePassword, ref ReadOnlyRecommended, ref EmbedTrueTypeFonts, ref SaveNativePictureFormat, ref SaveFormsData, ref SaveAsAOCELetter, ref Encoding, ref InsertLineBreaks, ref AllowSubstitutions, ref LineEnding, ref AddBiDiMarks, ref CompatibilityMode);
		}
	}

	private static object getSaveFormat(Document P_0)
	{
		try
		{
			return P_0.SaveFormat;
		}
		catch
		{
			return Type.Missing;
		}
	}

	private static string validateNewFileName(string P_0)
	{
		string text = (P_0 ?? string.Empty).Trim();
		if (string.IsNullOrWhiteSpace(text))
		{
			throw new InvalidOperationException("新文件名不能为空。");
		}
		if (text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
		{
			throw new InvalidOperationException("新文件名包含非法字符，请重新输入。");
		}
		if (text.EndsWith(".", StringComparison.Ordinal) || text.EndsWith(" ", StringComparison.Ordinal))
		{
			throw new InvalidOperationException("新文件名不能以空格或点号结尾。");
		}
		if (isReservedDeviceName(text))
		{
			throw new InvalidOperationException("新文件名是 Windows 保留设备名，请重新输入。");
		}
		return text;
	}

	private static bool isReservedDeviceName(string P_0)
	{
		string text = P_0;
		int num = text.IndexOf('.');
		if (num >= 0)
		{
			text = text.Substring(0, num);
		}
		text = text.TrimEnd(' ', '.');
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		string text2 = text.ToUpperInvariant();
		if (text2 == "CON" || text2 == "PRN" || text2 == "AUX" || text2 == "NUL")
		{
			return true;
		}
		if (text2.Length == 4 && (text2.StartsWith("COM", StringComparison.Ordinal) || text2.StartsWith("LPT", StringComparison.Ordinal)) && text2[3] >= '1' && text2[3] <= '9')
		{
			return true;
		}
		return false;
	}

	private static string getFileExtension(string P_0, string P_1)
	{
		string extension = Path.GetExtension(P_0);
		if (string.IsNullOrWhiteSpace(extension) || extension == ".")
		{
			extension = Path.GetExtension(P_1);
		}
		if (!string.IsNullOrWhiteSpace(extension) && !(extension == "."))
		{
			return extension;
		}
		return string.Empty;
	}

	private static Document getActiveDocument()
	{
		try
		{
			return App?.ActiveDocument;
		}
		catch
		{
			return null;
		}
	}

	private static bool arePathsEqual(string P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_0) || string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		try
		{
			return string.Equals(Path.GetFullPath(P_0), Path.GetFullPath(P_1), StringComparison.OrdinalIgnoreCase);
		}
		catch
		{
			return string.Equals(P_0, P_1, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static string tryGetString(Func<string> P_0)
	{
		try
		{
			return P_0() ?? string.Empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static bool tryGetBool(Func<bool> P_0, bool P_1)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return P_1;
		}
	}
}
