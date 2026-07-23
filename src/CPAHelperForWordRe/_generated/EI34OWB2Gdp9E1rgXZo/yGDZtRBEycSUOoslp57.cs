using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using hJKpQrVSwRwMyI2RyDQN;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;
using Teqm8VBmQ2O0x8vmB7L;
using YNri0QclKMfRh2PQoZV;

namespace EI34OWB2Gdp9E1rgXZo;

internal static class yGDZtRBEycSUOoslp57
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0
	{
		public Document TrRhV0gxVq;

		public _G_c__DisplayClass2_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string sudhRsvTpt()
		{
			return TrRhV0gxVq.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass4_0
	{
		public Document LOthDsSCy9;

		public _G_c__DisplayClass4_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string QhVhBdk0xM()
		{
			return LOthDsSCy9.Path;
		}

		internal string fcPh9DS39f()
		{
			return LOthDsSCy9.FullName;
		}

		internal string oMgh6K0G10()
		{
			return LOthDsSCy9.Name;
		}

		internal bool ohwhuqJZqk()
		{
			return LOthDsSCy9.ReadOnly;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass5_0
	{
		public Document WRIhij4kSi;

		public _G_c__DisplayClass5_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal string g1WhTVKb0a()
		{
			return WRIhij4kSi.Name;
		}

		internal string JlEhg71oo6()
		{
			return WRIhij4kSi.FullName;
		}

		internal string Sfwh8GwEht()
		{
			return WRIhij4kSi.Path;
		}

		internal bool gc1hIpwXjJ()
		{
			return WRIhij4kSi.Saved;
		}
	}

	private static Application App => eSfxffslhXbaGAjFNv1.WordApp;

	internal static string p22B4gZ207()
	{
		_G_c__DisplayClass2_0 CS_8_locals_3 = new _G_c__DisplayClass2_0();
		CS_8_locals_3.TrRhV0gxVq = JrbBtdamCI();
		if (CS_8_locals_3.TrRhV0gxVq != null)
		{
			return fwlBshSt6y(() => CS_8_locals_3.TrRhV0gxVq.Name);
		}
		return null;
	}

	internal static string yNrBjmtqCf()
	{
		string text = p22B4gZ207();
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

	internal static bool NDgBYYaMnF(out string P_0)
	{
		_G_c__DisplayClass4_0 CS_8_locals_6 = new _G_c__DisplayClass4_0();
		CS_8_locals_6.LOthDsSCy9 = JrbBtdamCI();
		if (CS_8_locals_6.LOthDsSCy9 == null)
		{
			P_0 = "当前没有打开的 Word 文档。";
			return false;
		}
		string value = fwlBshSt6y(() => CS_8_locals_6.LOthDsSCy9.Path);
		string text = fwlBshSt6y(() => CS_8_locals_6.LOthDsSCy9.FullName);
		string value2 = vG2BwOq8Bw(fwlBshSt6y(() => CS_8_locals_6.LOthDsSCy9.Name), text);
		if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(value2))
		{
			P_0 = "当前文件无法重命名，请先保存文档。";
			return false;
		}
		if (A3eBlQ6j8f(() => CS_8_locals_6.LOthDsSCy9.ReadOnly, false))
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

	internal static j5TqonBNY02JxhgwfnS wqTBZIKo0s(string P_0, Func<string, bool> P_1 = null)
	{
		_G_c__DisplayClass5_0 CS_8_locals_7 = new _G_c__DisplayClass5_0();
		if (!NDgBYYaMnF(out var message))
		{
			throw new InvalidOperationException(message);
		}
		CS_8_locals_7.WRIhij4kSi = JrbBtdamCI();
		string text = fwlBshSt6y(() => CS_8_locals_7.WRIhij4kSi.Name);
		string text2 = fwlBshSt6y(() => CS_8_locals_7.WRIhij4kSi.FullName);
		string path = fwlBshSt6y(() => CS_8_locals_7.WRIhij4kSi.Path);
		string text3 = vG2BwOq8Bw(text, text2);
		string text4 = ur0Bb9fPt3(P_0);
		string text5 = Path.Combine(path, text4 + text3);
		if (cJXBLP7fcQ(text2, text5))
		{
			return j5TqonBNY02JxhgwfnS.Wm0BGukN7S(text2);
		}
		if (File.Exists(text5))
		{
			throw new InvalidOperationException("目标文件已存在，请更换一个文件名。");
		}
		if (!A3eBlQ6j8f(() => CS_8_locals_7.WRIhij4kSi.Saved, true))
		{
			string text6 = "当前文档有尚未保存的修改。继续重命名将保存这些修改，是否继续？";
			if (!(P_1?.Invoke(text6) ?? F2ZFeLcsiLlLr89kqUl.JWucG2ERAH(text6, "IP_Assurance")))
			{
				return j5TqonBNY02JxhgwfnS.UdoBCP2Rh6(text2);
			}
		}
		Y9cBf0FXlN(CS_8_locals_7.WRIhij4kSi, text5);
		if (!File.Exists(text5))
		{
			throw new InvalidOperationException("重命名失败：新文件未成功生成。");
		}
		try
		{
			CS_8_locals_7.WRIhij4kSi.Activate();
		}
		catch
		{
		}
		bool flag = true;
		string text7 = null;
		if (!cJXBLP7fcQ(text2, text5) && File.Exists(text2))
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
		return j5TqonBNY02JxhgwfnS.ONEBochSpq(text2, text5, flag, text7);
	}

	private static void Y9cBf0FXlN(Document P_0, string P_1)
	{
		object FileName = P_1;
		object FileFormat = wbXBMKescZ(P_0);
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
			FileFormat = wbXBMKescZ(P_0);
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
			FileFormat = wbXBMKescZ(P_0);
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

	private static object wbXBMKescZ(Document P_0)
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

	private static string ur0Bb9fPt3(string P_0)
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
		if (BrRBSEtSCs(text))
		{
			throw new InvalidOperationException("新文件名是 Windows 保留设备名，请重新输入。");
		}
		return text;
	}

	private static bool BrRBSEtSCs(string P_0)
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

	private static string vG2BwOq8Bw(string P_0, string P_1)
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

	private static Document JrbBtdamCI()
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

	private static bool cJXBLP7fcQ(string P_0, string P_1)
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

	private static string fwlBshSt6y(Func<string> P_0)
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

	private static bool A3eBlQ6j8f(Func<bool> P_0, bool P_1)
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
