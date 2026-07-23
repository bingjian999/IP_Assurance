using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Threading;
using PageRange;
using CPAHelperForWordRe.UI.Forms;
using TableBorderConfig;
using WordTableToolService5;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using WordTableToolService;
using LoggerInitializer;

namespace PageSplitService;

internal static class PageSplitService
{
	private static Microsoft.Office.Interop.Word.Application App => WordTableToolService.WordApp;

	private static TableBorderConfig Cfg => TableBorderConfig.Current;

	public static void r35fVUVyl3()
	{
		CO7f6S6Mxg("附注页");
	}

	public static void uqUfBw6cB5()
	{
		CO7f6S6Mxg("正文页");
	}

	public static void pIHf9JibWB()
	{
		CO7f6S6Mxg("封面页");
	}

	private static void CO7f6S6Mxg(string P_0)
	{
		Cfg.SaveToFile();
		PageSetup pageSetup = App.ActiveDocument.PageSetup;
		pageSetup.Orientation = WdOrientation.wdOrientPortrait;
		pageSetup.TopMargin = App.CentimetersToPoints((float)Cfg.GetDouble("页面_" + P_0 + "_上边距", 2.54));
		pageSetup.BottomMargin = App.CentimetersToPoints((float)Cfg.GetDouble("页面_" + P_0 + "_下边距", 2.54));
		pageSetup.LeftMargin = App.CentimetersToPoints((float)Cfg.GetDouble("页面_" + P_0 + "_左边距", 3.18));
		pageSetup.RightMargin = App.CentimetersToPoints((float)Cfg.GetDouble("页面_" + P_0 + "_右边距", 3.18));
		pageSetup.HeaderDistance = App.CentimetersToPoints((float)Cfg.GetDouble("页面_" + P_0 + "_页眉", 1.5));
		pageSetup.FooterDistance = App.CentimetersToPoints((float)Cfg.GetDouble("页面_" + P_0 + "_页脚", 1.75));
	}

	public static void q6BfuLcjaG()
	{
		Selection selection = App.Selection;
		object Type = WdBreakType.wdSectionBreakNextPage;
		selection.InsertBreak(ref Type);
		Selection selection2 = App.Selection;
		Type = WdBreakType.wdSectionBreakNextPage;
		selection2.InsertBreak(ref Type);
		Selection selection3 = App.Selection;
		Type = WdGoToItem.wdGoToPage;
		object Which = WdGoToDirection.wdGoToPrevious;
		object Count = 1;
		object Name = System.Type.Missing;
		selection3.GoTo(ref Type, ref Which, ref Count, ref Name);
		PageSetup pageSetup = App.Selection.PageSetup;
		pageSetup.Orientation = ((pageSetup.Orientation == WdOrientation.wdOrientPortrait) ? WdOrientation.wdOrientLandscape : WdOrientation.wdOrientPortrait);
	}

	public static void a1VfDCrrNS()
	{
		App.ScreenUpdating = false;
		try
		{
			Cfg.SaveToFile();
			Document activeDocument = App.ActiveDocument;
			int num = PageNumberStartWindow.dXHnSRT5B2(Cfg.GetInt("页面_页码_起始值", 1));
			WwJfTF0CF3(activeDocument, num);
			HeaderFooter headerFooter = activeDocument.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
			PageNumbers pageNumbers = headerFooter.PageNumbers;
			object PageNumberAlignment = WdPageNumberAlignment.wdAlignPageNumberCenter;
			object FirstPage = true;
			pageNumbers.Add(ref PageNumberAlignment, ref FirstPage);
			headerFooter.Range.Font.Size = 9f;
			headerFooter.Range.Font.Name = "宋体";
			Range range = headerFooter.Range;
			FirstPage = WdCollapseDirection.wdCollapseEnd;
			range.Collapse(ref FirstPage);
			Range range2 = activeDocument.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
			FirstPage = Type.Missing;
			PageNumberAlignment = Type.Missing;
			range2.Delete(ref FirstPage, ref PageNumberAlignment);
			range2.ParagraphFormat.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError("插入页码失败：" + ex.Message, "IP_Assurance");
		}
		finally
		{
			App.ScreenUpdating = true;
		}
	}

	private static void WwJfTF0CF3(Document P_0, int P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		WdHeaderFooterIndex[] array = new WdHeaderFooterIndex[3]
		{
			WdHeaderFooterIndex.wdHeaderFooterPrimary,
			WdHeaderFooterIndex.wdHeaderFooterFirstPage,
			WdHeaderFooterIndex.wdHeaderFooterEvenPages
		};
		foreach (Section section in P_0.Sections)
		{
			WdHeaderFooterIndex[] array2 = array;
			foreach (WdHeaderFooterIndex index in array2)
			{
				try
				{
					PageNumbers pageNumbers = section.Footers[index].PageNumbers;
					pageNumbers.RestartNumberingAtSection = true;
					pageNumbers.StartingNumber = P_1;
				}
				catch
				{
				}
			}
		}
	}

	public static void ykFfgO7l4C()
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Multiselect = true,
			Filter = "Word 文档 (*.doc;*.docx)|*.doc;*.docx"
		};
		int num = 0;
		int num2 = 0;
		bool flag = false;
		try
		{
			App.ScreenUpdating = false;
			if (openFileDialog.ShowDialog(WordTableToolService5.GetOwnerWindow()) != DialogResult.OK)
			{
				return;
			}
			flag = true;
			num2 = openFileDialog.FileNames.Length;
			string[] fileNames = openFileDialog.FileNames;
			foreach (string obj in fileNames)
			{
				num++;
				cK9f89ck81(obj);
				App.StatusBar = string.Format("已转换{0}/{1}", num, num2);
			}
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError(ex.ToString(), "IP_Assurance");
		}
		finally
		{
			App.ScreenUpdating = true;
			App.StatusBar = string.Empty;
		}
		if (flag)
		{
			LoggerInitializer.ShowInfo(string.Format("批量转为 PDF 完成：{0} / {1}", num, num2), "IP_Assurance");
		}
	}

	public static void cK9f89ck81(string P_0)
	{
		Documents documents = App.Documents;
		object FileName = P_0;
		object ConfirmConversions = Type.Missing;
		object ReadOnly = Type.Missing;
		object AddToRecentFiles = Type.Missing;
		object PasswordDocument = Type.Missing;
		object PasswordTemplate = Type.Missing;
		object Revert = Type.Missing;
		object WritePasswordDocument = Type.Missing;
		object WritePasswordTemplate = Type.Missing;
		object Format = Type.Missing;
		object Encoding = Type.Missing;
		object Visible = Type.Missing;
		object OpenAndRepair = Type.Missing;
		object DocumentDirection = Type.Missing;
		object NoEncodingDialog = Type.Missing;
		object XMLTransform = Type.Missing;
		Document document = documents.Open(ref FileName, ref ConfirmConversions, ref ReadOnly, ref AddToRecentFiles, ref PasswordDocument, ref PasswordTemplate, ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format, ref Encoding, ref Visible, ref OpenAndRepair, ref DocumentDirection, ref NoEncodingDialog, ref XMLTransform);
		try
		{
			string outputFileName = Path.ChangeExtension(P_0, ".pdf");
			XMLTransform = Type.Missing;
			document.ExportAsFixedFormat(outputFileName, WdExportFormat.wdExportFormatPDF, OpenAfterExport: false, WdExportOptimizeFor.wdExportOptimizeForPrint, WdExportRange.wdExportAllDocument, 1, 1, WdExportItem.wdExportDocumentContent, IncludeDocProps: false, KeepIRM: true, WdExportCreateBookmarks.wdExportCreateNoBookmarks, DocStructureTags: true, BitmapMissingFonts: true, UseISO19005_1: false, ref XMLTransform);
		}
		finally
		{
			XMLTransform = false;
			NoEncodingDialog = Type.Missing;
			DocumentDirection = Type.Missing;
			document.Close(ref XMLTransform, ref NoEncodingDialog, ref DocumentDirection);
		}
	}

	public static void DglfI2k05r(string P_0, string P_1)
	{
		Documents documents = App.Documents;
		object FileName = P_0;
		object ConfirmConversions = Type.Missing;
		object ReadOnly = true;
		object AddToRecentFiles = false;
		object PasswordDocument = Type.Missing;
		object PasswordTemplate = Type.Missing;
		object Revert = Type.Missing;
		object WritePasswordDocument = Type.Missing;
		object WritePasswordTemplate = Type.Missing;
		object Format = Type.Missing;
		object Encoding = Type.Missing;
		object Visible = false;
		object OpenAndRepair = Type.Missing;
		object DocumentDirection = Type.Missing;
		object NoEncodingDialog = Type.Missing;
		object XMLTransform = Type.Missing;
		Document document = documents.Open(ref FileName, ref ConfirmConversions, ref ReadOnly, ref AddToRecentFiles, ref PasswordDocument, ref PasswordTemplate, ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format, ref Encoding, ref Visible, ref OpenAndRepair, ref DocumentDirection, ref NoEncodingDialog, ref XMLTransform);
		try
		{
			XMLTransform = Type.Missing;
			document.ExportAsFixedFormat(P_1, WdExportFormat.wdExportFormatPDF, OpenAfterExport: false, WdExportOptimizeFor.wdExportOptimizeForPrint, WdExportRange.wdExportAllDocument, 1, 1, WdExportItem.wdExportDocumentContent, IncludeDocProps: false, KeepIRM: true, WdExportCreateBookmarks.wdExportCreateNoBookmarks, DocStructureTags: true, BitmapMissingFonts: true, UseISO19005_1: false, ref XMLTransform);
		}
		finally
		{
			XMLTransform = false;
			NoEncodingDialog = Type.Missing;
			DocumentDirection = Type.Missing;
			document.Close(ref XMLTransform, ref NoEncodingDialog, ref DocumentDirection);
		}
	}

	public static void Y5Tfix9LLg()
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Multiselect = true,
			Filter = "Word 文档 (*.doc;*.docx)|*.doc;*.docx"
		};
		try
		{
			App.ScreenUpdating = false;
			if (openFileDialog.ShowDialog(WordTableToolService5.GetOwnerWindow()) != DialogResult.OK)
			{
				return;
			}
			Documents documents = App.Documents;
			object Template = Type.Missing;
			object NewTemplate = Type.Missing;
			object DocumentType = Type.Missing;
			object Visible = Type.Missing;
			documents.Add(ref Template, ref NewTemplate, ref DocumentType, ref Visible).Activate();
			string[] fileNames = openFileDialog.FileNames;
			foreach (string text in fileNames)
			{
				if (File.Exists(text))
				{
					Selection selection = App.Selection;
					Visible = Type.Missing;
					DocumentType = Type.Missing;
					NewTemplate = Type.Missing;
					Template = Type.Missing;
					selection.InsertFile(text, ref Visible, ref DocumentType, ref NewTemplate, ref Template);
					Selection selection2 = App.Selection;
					Template = WdCollapseDirection.wdCollapseEnd;
					selection2.Collapse(ref Template);
					Selection selection3 = App.Selection;
					Template = WdBreakType.wdPageBreak;
					selection3.InsertBreak(ref Template);
					Selection selection4 = App.Selection;
					Template = WdCollapseDirection.wdCollapseEnd;
					selection4.Collapse(ref Template);
				}
			}
			if (openFileDialog.FileNames.Length != 0)
			{
				App.Selection.SetRange(App.Selection.Start, App.Selection.End - 1);
				Selection selection5 = App.Selection;
				Template = Type.Missing;
				NewTemplate = Type.Missing;
				selection5.Delete(ref Template, ref NewTemplate);
			}
			App.StatusBar = "已完成 " + openFileDialog.FileNames.Length + " 个文档的合并";
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError(ex.ToString(), "IP_Assurance");
		}
		finally
		{
			App.ScreenUpdating = true;
			App.StatusBar = string.Empty;
		}
	}

	public static void TpofHWy9aJ()
	{
		kB3fQeM4Kl();
	}

	public static void kB3fQeM4Kl()
	{
		Document activeDocument = App.ActiveDocument;
		if (string.IsNullOrEmpty(activeDocument.Path))
		{
			LoggerInitializer.ShowWarning("请先保存当前文档", "IP_Assurance");
			return;
		}
		if (!activeDocument.Saved)
		{
			if (!LoggerInitializer.ShowConfirm("当前文档有未保存的修改。按页拆分需要先保存当前文档，是否保存并继续？", "IP_Assurance"))
			{
				return;
			}
			activeDocument.Save();
		}
		object IncludeFootnotesAndEndnotes = Type.Missing;
		int num = activeDocument.ComputeStatistics(WdStatistic.wdStatisticPages, ref IncludeFootnotesAndEndnotes);
		if (num <= 0)
		{
			LoggerInitializer.ShowInfo("当前文档没有可拆分的页面。", "IP_Assurance");
			return;
		}
		int num2 = LUVfb1Q91y(num);
		if (num2 <= 0)
		{
			return;
		}
		int num3 = (int)Math.Ceiling((double)num / (double)num2);
		string fullName = activeDocument.FullName;
		int num4 = 1;
		int num5 = 0;
		bool flag = false;
		ProgressWindow progressWindow = null;
		try
		{
			App.ScreenUpdating = false;
			progressWindow = DkefYd6IAp();
			if (!Ip0ffGT6jx(progressWindow, 0, string.Format("准备按页拆分，共 {0} 页，预计生成 {1} 个文档", num, num3)))
			{
				flag = true;
			}
			int num6 = 1;
			while (!flag && num4 <= num)
			{
				int num7 = Math.Min(num4 + num2 - 1, num);
				string text = string.Format("正在按页拆分：第 {0} - {1} 页 / 共 {2} 页", num4, num7, num);
				App.StatusBar = text;
				if (!Ip0ffGT6jx(progressWindow, (num3 <= 0) ? 100 : ((int)Math.Round((double)num5 * 100.0 / (double)num3)), text))
				{
					flag = true;
					break;
				}
				string text2 = L2efJ9DkxU(fullName, num6);
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
				File.Copy(fullName, text2);
				Document document = null;
				try
				{
					Documents documents = App.Documents;
					IncludeFootnotesAndEndnotes = text2;
					object ConfirmConversions = Type.Missing;
					object ReadOnly = false;
					object AddToRecentFiles = false;
					object PasswordDocument = Type.Missing;
					object PasswordTemplate = Type.Missing;
					object Revert = Type.Missing;
					object WritePasswordDocument = Type.Missing;
					object WritePasswordTemplate = Type.Missing;
					object Format = Type.Missing;
					object Encoding = Type.Missing;
					object Visible = false;
					object OpenAndRepair = Type.Missing;
					object DocumentDirection = Type.Missing;
					object NoEncodingDialog = Type.Missing;
					object XMLTransform = Type.Missing;
					document = documents.Open(ref IncludeFootnotesAndEndnotes, ref ConfirmConversions, ref ReadOnly, ref AddToRecentFiles, ref PasswordDocument, ref PasswordTemplate, ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format, ref Encoding, ref Visible, ref OpenAndRepair, ref DocumentDirection, ref NoEncodingDialog, ref XMLTransform);
					UvgfKJerOK(document, num4, num7, num);
					try
					{
						document.UpdateStylesOnOpen = false;
					}
					catch
					{
					}
					document.Save();
				}
				finally
				{
					if (document != null)
					{
						Document document2 = document;
						object XMLTransform = false;
						object NoEncodingDialog = Type.Missing;
						object DocumentDirection = Type.Missing;
						document2.Close(ref XMLTransform, ref NoEncodingDialog, ref DocumentDirection);
					}
				}
				num5++;
				num4 = num7 + 1;
				if (!IFPfZT0w76(progressWindow, num5, num3))
				{
					flag = true;
					break;
				}
				num6++;
			}
		}
		finally
		{
			RtKfMFEACg(progressWindow);
			App.ScreenUpdating = true;
			App.StatusBar = string.Empty;
			try
			{
				activeDocument.Activate();
			}
			catch
			{
			}
		}
		if (flag)
		{
			LoggerInitializer.ShowInfo(string.Format("按页拆分已取消，已生成 {0} / {1} 个文档。", num5, num3), "IP_Assurance");
		}
		else
		{
			LoggerInitializer.ShowInfo(string.Format("按页拆分完成，共生成 {0} 个文档。", num5), "IP_Assurance");
		}
	}

	public static void Wq4f1QfrnV()
	{
		Document activeDocument = App.ActiveDocument;
		if (string.IsNullOrEmpty(activeDocument.Path))
		{
			LoggerInitializer.ShowWarning("请先保存当前文档", "IP_Assurance");
			return;
		}
		if (!activeDocument.Saved)
		{
			if (!LoggerInitializer.ShowConfirm("当前文档有未保存的修改。按指定页拆分需要先保存当前文档，是否保存并继续？", "IP_Assurance"))
			{
				return;
			}
			activeDocument.Save();
		}
		object IncludeFootnotesAndEndnotes = Type.Missing;
		int num = activeDocument.ComputeStatistics(WdStatistic.wdStatisticPages, ref IncludeFootnotesAndEndnotes);
		if (num <= 0)
		{
			LoggerInitializer.ShowInfo("当前文档没有可拆分的页面。", "IP_Assurance");
			return;
		}
		IReadOnlyList<PageRange> readOnlyList = imKfSm7rVB(num);
		if (readOnlyList == null || readOnlyList.Count == 0)
		{
			return;
		}
		string fullName = activeDocument.FullName;
		int count = readOnlyList.Count;
		int num2 = 0;
		bool flag = false;
		ProgressWindow progressWindow = null;
		try
		{
			App.ScreenUpdating = false;
			progressWindow = DkefYd6IAp();
			if (!Ip0ffGT6jx(progressWindow, 0, string.Format("准备按指定页拆分，共 {0} 个页段", count)))
			{
				flag = true;
			}
			int num3 = 0;
			while (!flag && num3 < readOnlyList.Count)
			{
				PageRange rsQuUTnPQGmBy8VcAkC = readOnlyList[num3];
				string text = string.Format("正在按指定页拆分：第 {0} 页 / {1} / {2}", rsQuUTnPQGmBy8VcAkC.DisplayText, num3 + 1, count);
				App.StatusBar = text;
				if (!Ip0ffGT6jx(progressWindow, (count <= 0) ? 100 : ((int)Math.Round((double)num2 * 100.0 / (double)count)), text))
				{
					flag = true;
					break;
				}
				string text2 = BiIf3e4mrZ(fullName, rsQuUTnPQGmBy8VcAkC);
				File.Copy(fullName, text2);
				Document document = null;
				try
				{
					Documents documents = App.Documents;
					IncludeFootnotesAndEndnotes = text2;
					object ConfirmConversions = Type.Missing;
					object ReadOnly = false;
					object AddToRecentFiles = false;
					object PasswordDocument = Type.Missing;
					object PasswordTemplate = Type.Missing;
					object Revert = Type.Missing;
					object WritePasswordDocument = Type.Missing;
					object WritePasswordTemplate = Type.Missing;
					object Format = Type.Missing;
					object Encoding = Type.Missing;
					object Visible = false;
					object OpenAndRepair = Type.Missing;
					object DocumentDirection = Type.Missing;
					object NoEncodingDialog = Type.Missing;
					object XMLTransform = Type.Missing;
					document = documents.Open(ref IncludeFootnotesAndEndnotes, ref ConfirmConversions, ref ReadOnly, ref AddToRecentFiles, ref PasswordDocument, ref PasswordTemplate, ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format, ref Encoding, ref Visible, ref OpenAndRepair, ref DocumentDirection, ref NoEncodingDialog, ref XMLTransform);
					UvgfKJerOK(document, rsQuUTnPQGmBy8VcAkC.StartPage, rsQuUTnPQGmBy8VcAkC.EndPage, num);
					try
					{
						document.UpdateStylesOnOpen = false;
					}
					catch
					{
					}
					document.Save();
				}
				finally
				{
					if (document != null)
					{
						Document document2 = document;
						object XMLTransform = false;
						object NoEncodingDialog = Type.Missing;
						object DocumentDirection = Type.Missing;
						document2.Close(ref XMLTransform, ref NoEncodingDialog, ref DocumentDirection);
					}
				}
				num2++;
				if (!IFPfZT0w76(progressWindow, num2, count))
				{
					flag = true;
					break;
				}
				num3++;
			}
		}
		finally
		{
			RtKfMFEACg(progressWindow);
			App.ScreenUpdating = true;
			App.StatusBar = string.Empty;
			try
			{
				activeDocument.Activate();
			}
			catch
			{
			}
		}
		if (flag)
		{
			LoggerInitializer.ShowInfo(string.Format("按指定页拆分已取消，已生成 {0} / {1} 个文档。", num2, count), "IP_Assurance");
		}
		else
		{
			LoggerInitializer.ShowInfo(string.Format("按指定页拆分完成，共生成 {0} 个文档。", num2), "IP_Assurance");
		}
	}

	public static void vFrfrDlytO()
	{
		Document activeDocument = App.ActiveDocument;
		if (string.IsNullOrEmpty(activeDocument.Path))
		{
			LoggerInitializer.ShowWarning("请先保存当前文档", "IP_Assurance");
			return;
		}
		if (!activeDocument.Saved)
		{
			if (!LoggerInitializer.ShowConfirm("当前文档有未保存的修改。按分节符拆分需要先保存当前文档，是否保存并继续？", "IP_Assurance"))
			{
				return;
			}
			activeDocument.Save();
		}
		string fullName = activeDocument.FullName;
		int count = activeDocument.Sections.Count;
		if (count <= 1)
		{
			LoggerInitializer.ShowInfo("未发现可用于拆分的分节符。", "IP_Assurance");
			return;
		}
		int num = 0;
		bool flag = false;
		ProgressWindow progressWindow = null;
		try
		{
			App.ScreenUpdating = false;
			progressWindow = DkefYd6IAp();
			if (!Ip0ffGT6jx(progressWindow, 0, string.Format("准备按分节符拆分，共 {0} 个分节", count)))
			{
				flag = true;
			}
			int num2 = 1;
			while (!flag && num2 <= count)
			{
				string text = string.Format("正在按分节符拆分：{0} / {1}", num2, count);
				App.StatusBar = text;
				if (!Ip0ffGT6jx(progressWindow, (count <= 0) ? 100 : ((int)Math.Round((double)(num2 - 1) * 100.0 / (double)count)), text))
				{
					flag = true;
					break;
				}
				string text2 = L2efJ9DkxU(fullName, num2);
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
				File.Copy(fullName, text2);
				Document document = null;
				try
				{
					Documents documents = App.Documents;
					object FileName = text2;
					object ConfirmConversions = Type.Missing;
					object ReadOnly = false;
					object AddToRecentFiles = false;
					object PasswordDocument = Type.Missing;
					object PasswordTemplate = Type.Missing;
					object Revert = Type.Missing;
					object WritePasswordDocument = Type.Missing;
					object WritePasswordTemplate = Type.Missing;
					object Format = Type.Missing;
					object Encoding = Type.Missing;
					object Visible = false;
					object OpenAndRepair = Type.Missing;
					object DocumentDirection = Type.Missing;
					object NoEncodingDialog = Type.Missing;
					object XMLTransform = Type.Missing;
					document = documents.Open(ref FileName, ref ConfirmConversions, ref ReadOnly, ref AddToRecentFiles, ref PasswordDocument, ref PasswordTemplate, ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format, ref Encoding, ref Visible, ref OpenAndRepair, ref DocumentDirection, ref NoEncodingDialog, ref XMLTransform);
					EMafEonbO8(document, activeDocument, num2);
					try
					{
						document.UpdateStylesOnOpen = false;
					}
					catch
					{
					}
					document.Save();
				}
				finally
				{
					if (document != null)
					{
						Document document2 = document;
						object XMLTransform = false;
						object NoEncodingDialog = Type.Missing;
						object DocumentDirection = Type.Missing;
						document2.Close(ref XMLTransform, ref NoEncodingDialog, ref DocumentDirection);
					}
				}
				num++;
				if (!IFPfZT0w76(progressWindow, num, count))
				{
					flag = true;
					break;
				}
				num2++;
			}
		}
		finally
		{
			RtKfMFEACg(progressWindow);
			App.ScreenUpdating = true;
			App.StatusBar = string.Empty;
			try
			{
				activeDocument.Activate();
			}
			catch
			{
			}
		}
		if (flag)
		{
			LoggerInitializer.ShowInfo(string.Format("按分节符拆分已取消，已生成 {0} / {1} 个文档。", num, count), "IP_Assurance");
		}
		else
		{
			LoggerInitializer.ShowInfo(string.Format("按分节符拆分完成，共生成 {0} 个文档。", num), "IP_Assurance");
		}
	}

	private static string L2efJ9DkxU(string P_0, int P_1)
	{
		string directoryName = Path.GetDirectoryName(P_0);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(P_0);
		string text = Path.GetExtension(P_0);
		if (string.IsNullOrWhiteSpace(text))
		{
			text = ".docx";
		}
		return Path.Combine(directoryName, string.Format("{0}_{1}{2}", fileNameWithoutExtension, P_1, text));
	}

	private static string BiIf3e4mrZ(string P_0, PageRange P_1)
	{
		string directoryName = Path.GetDirectoryName(P_0);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(P_0);
		string text = Path.GetExtension(P_0);
		if (string.IsNullOrWhiteSpace(text))
		{
			text = ".docx";
		}
		return HRtfUPMcCt(Path.Combine(directoryName, fileNameWithoutExtension + "_指定页_" + P_1.DisplayText + text));
	}

	private static string HRtfUPMcCt(string P_0)
	{
		if (!File.Exists(P_0))
		{
			return P_0;
		}
		string directoryName = Path.GetDirectoryName(P_0);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(P_0);
		string text = Path.GetExtension(P_0);
		if (string.IsNullOrWhiteSpace(text))
		{
			text = ".docx";
		}
		int num = 2;
		string text2;
		while (true)
		{
			text2 = Path.Combine(directoryName, string.Format("{0}_{1}{2}", fileNameWithoutExtension, num, text));
			if (!File.Exists(text2))
			{
				break;
			}
			num++;
		}
		return text2;
	}

	private static void UvgfKJerOK(Document P_0, int P_1, int P_2, int P_3)
	{
		object Start = Type.Missing;
		object End = Type.Missing;
		int start = P_0.Range(ref Start, ref End).Start;
		End = Type.Missing;
		Start = Type.Missing;
		int end = P_0.Range(ref End, ref Start).End;
		int num;
		if (P_1 > 1)
		{
			Start = WdGoToItem.wdGoToPage;
			End = WdGoToDirection.wdGoToFirst;
			object Count = P_1;
			object Name = Type.Missing;
			num = P_0.GoTo(ref Start, ref End, ref Count, ref Name).Start;
		}
		else
		{
			num = start;
		}
		int num2 = num;
		int num3;
		if (P_2 >= P_3)
		{
			num3 = end;
		}
		else
		{
			object Name = WdGoToItem.wdGoToPage;
			object Count = WdGoToDirection.wdGoToFirst;
			End = P_2 + 1;
			Start = Type.Missing;
			num3 = P_0.GoTo(ref Name, ref Count, ref End, ref Start).Start;
		}
		int num4 = num3;
		if (num4 < end)
		{
			object Count = num4;
			object Name = end;
			Range range = P_0.Range(ref Count, ref Name);
			Start = Type.Missing;
			End = Type.Missing;
			range.Delete(ref Start, ref End);
		}
		if (num2 > start)
		{
			object Name = start;
			object Count = num2;
			Range range2 = P_0.Range(ref Name, ref Count);
			End = Type.Missing;
			Start = Type.Missing;
			range2.Delete(ref End, ref Start);
		}
		IDYfwqQp60(P_0);
	}

	private static void EMafEonbO8(Document P_0, Document P_1, int P_2)
	{
		int count = P_0.Sections.Count;
		object Start = Type.Missing;
		object End = Type.Missing;
		int start = P_0.Range(ref Start, ref End).Start;
		End = Type.Missing;
		Start = Type.Missing;
		int end = P_0.Range(ref End, ref Start).End;
		int start2 = P_0.Sections[P_2].Range.Start;
		int end2 = P_0.Sections[P_2].Range.End;
		int num = ((P_2 < count && end2 > start2) ? (end2 - 1) : end2);
		if (num < end)
		{
			object Start2 = num;
			object End2 = end;
			Range range = P_0.Range(ref Start2, ref End2);
			Start = Type.Missing;
			End = Type.Missing;
			range.Delete(ref Start, ref End);
		}
		if (start2 > start)
		{
			object End2 = start;
			object Start2 = start2;
			Range range2 = P_0.Range(ref End2, ref Start2);
			End = Type.Missing;
			Start = Type.Missing;
			range2.Delete(ref End, ref Start);
		}
		if (P_0.Sections.Count > 0)
		{
			Section section = P_1.Sections[P_2];
			Section section2 = P_0.Sections[1];
			jclf2V0rIq(section, section2);
			pywf4j9iKC(section, section2);
		}
	}

	private static void jclf2V0rIq(Section P_0, Section P_1)
	{
		try
		{
			P_1.PageSetup = P_0.PageSetup;
		}
		catch
		{
		}
	}

	private static void pywf4j9iKC(Section P_0, Section P_1)
	{
		vHGfjF4i2Y(P_0.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary], P_1.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary]);
		vHGfjF4i2Y(P_0.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage], P_1.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage]);
		vHGfjF4i2Y(P_0.Headers[WdHeaderFooterIndex.wdHeaderFooterEvenPages], P_1.Headers[WdHeaderFooterIndex.wdHeaderFooterEvenPages]);
		vHGfjF4i2Y(P_0.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary], P_1.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary]);
		vHGfjF4i2Y(P_0.Footers[WdHeaderFooterIndex.wdHeaderFooterFirstPage], P_1.Footers[WdHeaderFooterIndex.wdHeaderFooterFirstPage]);
		vHGfjF4i2Y(P_0.Footers[WdHeaderFooterIndex.wdHeaderFooterEvenPages], P_1.Footers[WdHeaderFooterIndex.wdHeaderFooterEvenPages]);
	}

	private static void vHGfjF4i2Y(HeaderFooter P_0, HeaderFooter P_1)
	{
		try
		{
			P_1.LinkToPrevious = false;
		}
		catch
		{
		}
		try
		{
			P_1.Range.FormattedText = P_0.Range.FormattedText;
		}
		catch
		{
		}
	}

	private static ProgressWindow DkefYd6IAp()
	{
		try
		{
			ProgressWindow progressWindow = new ProgressWindow();
			WordTableToolService5.ShowWpfWindow(progressWindow);
			return progressWindow;
		}
		catch
		{
			return null;
		}
	}

	private static bool IFPfZT0w76(ProgressWindow P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return true;
		}
		if (!P_0.IsVisible)
		{
			return false;
		}
		int percent = ((P_2 <= 0) ? 100 : ((int)Math.Round((double)P_1 * 100.0 / (double)P_2)));
		P_0.SetProgress(percent, string.Format("当前进度：{0} / {1}", P_1, P_2));
		try
		{
			P_0.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
		}
		catch
		{
		}
		return P_0.IsVisible;
	}

	private static bool Ip0ffGT6jx(ProgressWindow P_0, int P_1, string P_2)
	{
		if (P_0 == null)
		{
			return true;
		}
		if (!P_0.IsVisible)
		{
			return false;
		}
		P_0.SetProgress(P_1, P_2);
		try
		{
			P_0.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
		}
		catch
		{
		}
		return P_0.IsVisible;
	}

	private static void RtKfMFEACg(ProgressWindow P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		try
		{
			P_0.Close();
		}
		catch
		{
		}
	}

	private static int LUVfb1Q91y(int P_0)
	{
		try
		{
			SplitPagesWindow splitPagesWindow = new SplitPagesWindow(P_0);
			return (WordTableToolService5.ShowWpfDialog(splitPagesWindow) == true) ? splitPagesWindow.PagesPerDocument : 0;
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError("打开拆分页数窗口失败：" + ex.Message, "IP_Assurance");
			return 0;
		}
	}

	private static IReadOnlyList<PageRange> imKfSm7rVB(int P_0)
	{
		try
		{
			SplitPageRangesWindow splitPageRangesWindow = new SplitPageRangesWindow(P_0);
			return (WordTableToolService5.ShowWpfDialog(splitPageRangesWindow) == true) ? splitPageRangesWindow.PageRanges : null;
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError("打开指定页拆分窗口失败：" + ex.Message, "IP_Assurance");
			return null;
		}
	}

	private static void IDYfwqQp60(Document P_0)
	{
		try
		{
			if (P_0.Paragraphs.Last.Range.Text.Trim() == string.Empty)
			{
				Range range = P_0.Paragraphs.Last.Range;
				object Unit = Type.Missing;
				object Count = Type.Missing;
				range.Delete(ref Unit, ref Count);
			}
		}
		catch
		{
		}
	}
}
