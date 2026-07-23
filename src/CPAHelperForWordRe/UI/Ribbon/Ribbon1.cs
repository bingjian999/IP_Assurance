using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using AiAssistantHost2;
using TableValidationService;
using BatchReplaceService;
using CPAHelperForWordRe.UI.Forms;
using CPAHelperForWordRe.UI.Forms.General;
using BatchTableAdjustService;
using ScreenshotService;
using AiAssistantService;
using TableBorderConfig;
using WordTableToolService5;
using AiSseStreamService3;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Ribbon;
using SseStreamInitializer;
using ThousandsSeparatorService;
using PageSplitService;
using AiSseStreamService;
using AiHelper_3;
using WordTableToolService;
using AiHelper_12;
using UiHelper_1;
using AiHelper_7;
using OutlineNavigationService;

namespace CPAHelperForWordRe.UI.Ribbon;

public class Ribbon1 : RibbonBase
{
	[CompilerGenerated]
	private static Ribbon1 sxheiiecRW;

	private bool EOBeHRhbTd;

	private IContainer X8IeQ09MRY;

	internal RibbonTab LIxe17aZeb;

	internal RibbonGroup V8Geru9rQe;

	internal RibbonGroup r5VeJk9IFm;

	internal RibbonGroup Qcme36brMZ;

	internal RibbonGroup UULeULqlBm;

	internal RibbonGroup nMfeKu7MhY;

	internal RibbonGroup p2oeEOBmqI;

	internal RibbonGroup ttCe2WZOxK;

	internal RibbonGroup rACe4liUgJ;

	internal RibbonGroup wxBej1rKZn;

	internal RibbonButton AZAeYmLFnX;

	internal RibbonButton ObyeZaW2w9;

	internal RibbonButton QQkefaO87T;

	internal RibbonSplitButton GH0eMf7VqG;

	internal RibbonButton PEcebFj4uu;

	internal RibbonButton XtceSdypsH;

	internal RibbonButton aRDewydID6;

	internal RibbonButton YQletHXVWR;

	internal RibbonSplitButton U6weLyMaIs;

	internal RibbonButton cDLesnRHse;

	internal RibbonButton KR0el1JrZB;

	internal RibbonCheckBox mNaeNSP9JX;

	internal RibbonButton PsQemjAYEX;

	internal RibbonButton O2neocYeVm;

	internal RibbonMenu uhBeGMidU6;

	internal RibbonButton bLLeCoCtqb;

	internal RibbonButton YBwepj7oQk;

	internal RibbonSplitButton XuKeOjATgB;

	internal RibbonButton DpUenM8VkU;

	internal RibbonButton hjme7a7ldE;

	internal RibbonButton Xaje5BbwlX;

	internal RibbonMenu rJXecbOgQg;

	internal RibbonButton y00eeSplD5;

	internal RibbonButton XMReyfDAJ6;

	internal RibbonButton JYyeXQZPep;

	internal RibbonSplitButton DDFeFR1h9o;

	internal RibbonButton QclehQJ0Qe;

	internal RibbonMenu nhweay61dH;

	internal RibbonButton Y4weqgO6Ip;

	internal RibbonButton GSseP3ATQx;

	internal RibbonButton JHKeAsJpU4;

	internal RibbonButton eIievpV7yo;

	internal RibbonSplitButton lQMeWPEgFZ;

	internal RibbonButton jUPe0WVcH5;

	internal RibbonButton O1Nek8dtjg;

	internal RibbonButton AfNexqU5xE;

	internal RibbonButton E4NednknFu;

	internal RibbonMenu OlVez8DVQb;

	internal RibbonButton DDYyRiDwU0;

	internal RibbonButton F3SyViFQfi;

	internal RibbonMenu snjyBetBK5;

	internal RibbonButton gvCy9TVUH2;

	internal RibbonButton 批量替换;

	internal RibbonMenu vgMy6lHtI3;

	internal RibbonButton WOoyup6EfT;

	internal RibbonButton GS0yDJ0IHx;

	internal RibbonButton QXuyTpqqg5;

	internal RibbonButton QxVygurCMp;

	internal RibbonButton Jgty8WWI8v;

	internal RibbonButton L4byIXApGn;

	internal RibbonButton KjyyiTpBqf;

	internal RibbonButton StJyHMefXC;

	internal RibbonMenu RkVyQhB0BG;

	internal RibbonButton c99y1e88Ah;

	internal RibbonButton VFKyroq1pl;

	internal RibbonButton oAlyJlhmwW;

	internal RibbonMenu ARky3sm6Hj;

	internal RibbonButton FUPyUfkrpN;

	internal RibbonButton kVXyKrngMn;

	internal RibbonButton f82yEnEnAi;

	internal RibbonButton OCPy2sVgbO;

	internal RibbonButton gRty4Mu1gv;

	internal RibbonButton BhByjXGxgN;

	internal RibbonButton Lg5yYCLRLo;

	internal RibbonButton OKDyZCymnC;

	internal RibbonButton CtnyfNejNN;

	internal RibbonMenu aDkyMcIU5v;

	internal RibbonMenu ULEybERcmZ;

	internal RibbonButton NSUySeG74c;

	internal RibbonButton lRiywfx5RI;

	internal RibbonButton Ttiyto9c3J;

	internal RibbonMenu iUwyLRMxYn;

	internal RibbonButton Mykys9pFbA;

	internal RibbonButton x1myldNW5p;

	internal RibbonButton gLjyNtF5wS;

	internal RibbonButton PJlym1E13O;

	internal RibbonSplitButton stZyopAEjj;

	internal RibbonButton NCjyGburcY;

	internal RibbonButton xg0yCgJFpq;

	internal RibbonButton h0WyplNuXA;

	internal RibbonButton lXiyOWFVa5;

	internal RibbonMenu Ybtyny6IuG;

	internal RibbonMenu SMPy7URxdn;

	internal RibbonButton IeJy52VjG7;

	internal RibbonButton FjOycmk3RK;

	internal RibbonButton sdlyedNyXA;

	internal RibbonButton Go4yyvMTqe;

	internal RibbonButton IclyXnfJ75;

	internal RibbonMenu WGkyFT7Qna;

	internal RibbonButton V7pyhA6tbO;

	internal RibbonButton zPjyasMy9S;

	internal RibbonButton tWiyqkQmfh;

	internal RibbonButton ueWyPmEhpB;

	internal RibbonButton 检查更新;

	internal RibbonSplitButton PdeyAnLaqI;

	internal RibbonButton s22yvkIREp;

	internal static Ribbon1 Current
	{
		[CompilerGenerated]
		get
		{
			return sxheiiecRW;
		}
		[CompilerGenerated]
		private set
		{
			sxheiiecRW = value;
		}
	}

	private void DAgc0ePsPG(object P_0, RibbonUIEventArgs P_1)
	{
		Current = this;
		pgscd6mb8l();
		fwIcxJIPYU();
		mNaeNSP9JX.Checked = TableBorderConfig.Current.Config.System.DisableAutomaticStyleUpdate;
		AiAssistantService.ApplyRibbonIcons(this);
	}

	internal static void PMEckKFWry()
	{
		Ribbon1 current = Current;
		if (current != null)
		{
			current.fwIcxJIPYU();
		}
		else
		{
			CompositeRibbonExtensibility.S0ZyWdvYIm();
		}
	}

	internal void fwIcxJIPYU()
	{
		string tabName = TableBorderConfig.Current.Config.System.TabName;
		LIxe17aZeb.Label = (string.IsNullOrWhiteSpace(tabName) ? "IP_Assurance" : tabName.Trim());
		CompositeRibbonExtensibility.S0ZyWdvYIm();
	}

	private void pgscd6mb8l()
	{
		if (!EOBeHRhbTd)
		{
			EOBeHRhbTd = true;
			TcDczCZyGu();
		}
	}

	private void TcDczCZyGu()
	{
		AZAeYmLFnX.Click += delegate
		{
			AiHelper_7.RunCommand(AiAssistantHost2.OpenAssistantPane, "IP_Assurance");
		};
		ObyeZaW2w9.Click += delegate
		{
			AiHelper_7.RunCommand(AiAssistantHost2.ShowConfigWindow, "Template_OpenFolder");
		};
		QQkefaO87T.Click += delegate
		{
			AiHelper_7.RunCommand(AiAssistantHost2.InvokeAiHelper3Action, "打开目录");
		};
		GH0eMf7VqG.Click += delegate
		{
			AiHelper_7.RunCommand(ScreenshotService.CaptureScreenshot, "TemplateFolder_");
		};
		PEcebFj4uu.Click += delegate
		{
			AiHelper_7.RunCommand(ScreenshotService.LaunchSnippingTool, "*.*");
		};
		XtceSdypsH.Click += delegate
		{
			AiHelper_7.RunCommand(ScreenshotService.QuickCapture, "~");
		};
		aRDewydID6.Click += delegate
		{
			AiHelper_7.RunCommand(ScreenshotService.CloseAllDesktopPins, "Template_");
		};
		YQletHXVWR.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfDialog(new DesktopPinConfigWindow());
			}, "N");
		};
		U6weLyMaIs.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchReplaceService.FormatSelectionParagraphs, "_");
		};
		KR0el1JrZB.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfWindow(new ParagraphConfigWindow());
			}, "IP_Assurance");
		};
		PsQemjAYEX.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchReplaceService.OTQMCTfGfe, "tabCPA");
		};
		O2neocYeVm.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchReplaceService.FormatAfterTableNote, "通用");
		};
		bLLeCoCtqb.Click += delegate
		{
			AiHelper_7.RunCommand(BatchReplaceService.SelectAllAfterTableFirstParagraphs, "grpGeneral");
		};
		YBwepj7oQk.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchReplaceService.ProcessAfterTableSpacing, "智能助手");
		};
		XuKeOjATgB.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchTableAdjustService.BatchAdjustTables, "SBAI助手");
		};
		DpUenM8VkU.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfWindow(new TableConfigWindow());
			}, "配置");
		};
		hjme7a7ldE.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchTableAdjustService.SetHeaderRowRepeat, "BtnAI配置");
		};
		Xaje5BbwlX.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchReplaceService.PasteTableWithFormat, "帮助");
		};
		y00eeSplD5.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchTableAdjustService.AlignColumnWidths, "BtnAI帮助");
		};
		XMReyfDAJ6.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchTableAdjustService.AdjustTableWidth, "最大列宽");
		};
		JYyeXQZPep.Click += delegate
		{
			AiHelper_7.RunCommand(BatchTableAdjustService.SelectAllTables, "全选表格");
		};
		DDFeFR1h9o.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.ApplyThousandsSeparator, "千分位符");
		};
		QclehQJ0Qe.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfWindow(new ThousandsSeparatorConfigWindow());
			}, "SplitBtn钉桌面");
		};
		Y4weqgO6Ip.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.ConvertDatesToDotFormat, "系统截图/录屏");
		};
		GSseP3ATQx.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.ConvertDatesToSlashFormat, "Btn开始截图");
		};
		JHKeAsJpU4.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.ConvertDatesToDashFormat, "快速全屏截图");
		};
		eIievpV7yo.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.ConvertDatesToChineseFormat, "Btn快速全屏截图");
		};
		lQMeWPEgFZ.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.DivideByTenThousand, "除以万");
		};
		jUPe0WVcH5.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.AddWanSuffix, "Btn关闭所有钉图");
		};
		O1Nek8dtjg.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.MultiplyByHundred, "配置");
		};
		AfNexqU5xE.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.AddPercentSign, "Btn钉图配置");
		};
		E4NednknFu.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfWindow(new AreaSumWindow());
			}, "全局配置");
		};
		DDYyRiDwU0.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.CleanSpacesAndParagraphs, "B全局配置");
		};
		F3SyViFQfi.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.ToggleHighlight, "使用帮助");
		};
		gvCy9TVUH2.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(ThousandsSeparatorService.ConvertFullWidthToHalfWidthPunctuation, "B说明");
		};
		批量替换.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfWindow(new BatchReplaceWindow());
			}, "段落");
		};
		WOoyup6EfT.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchReplaceService.MergeConsecutiveBlankParagraphs, "grpParagraph");
		};
		GS0yDJ0IHx.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(BatchReplaceService.RemoveParagraphMarksInRange, "段落调整");
		};
		QXuyTpqqg5.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(delegate
			{
				BatchReplaceService.SetOutlineLevel(1);
			}, "B段落格式调整");
		};
		QxVygurCMp.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(delegate
			{
				BatchReplaceService.SetOutlineLevel(2);
			}, "段落配置");
		};
		Jgty8WWI8v.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(delegate
			{
				BatchReplaceService.SetOutlineLevel(3);
			}, "B段落配置");
		};
		L4byIXApGn.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(delegate
			{
				BatchReplaceService.SetOutlineLevel(4);
			}, "关闭样式自动更新");
		};
		KjyyiTpBqf.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(delegate
			{
				BatchReplaceService.SetOutlineLevel(5);
			}, "C关闭自动样式");
		};
		StJyHMefXC.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(delegate
			{
				BatchReplaceService.SetOutlineLevel(10);
			}, "表前单位");
		};
		c99y1e88Ah.Click += delegate
		{
			AiHelper_7.RunCommand(TableValidationService.ValidateByRow, "b表前单位");
		};
		VFKyroq1pl.Click += delegate
		{
			AiHelper_7.RunCommand(TableValidationService.ValidateByColumn, "表后注释");
		};
		oAlyJlhmwW.Click += delegate
		{
			AiHelper_7.RunCommand(TableValidationService.SumSelectedCells, "b表后注释");
		};
		FUPyUfkrpN.Click += delegate
		{
			AiHelper_7.RunCommand(crmeVUrrhp, "表后段落");
		};
		kVXyKrngMn.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfWindow(new ExcelSyncWindow());
			}, "m表后段落");
		};
		OCPy2sVgbO.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfWindow(new ExcelSyncWindow());
			}, "全选表后第一段");
		};
		Lg5yYCLRLo.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfWindow(new ExcelSyncWindow());
			}, "b全选表后第一段");
		};
		OKDyZCymnC.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(TableValidationService.CleanDocument, "表后间距处理");
		};
		CtnyfNejNN.Click += delegate
		{
			AiHelper_7.RunCommand(TableValidationService.ExportCommentsToExcel, "b表后段落处理");
		};
		NSUySeG74c.Click += delegate
		{
			AiHelper_7.RunCommand(OutlineNavigationService.GoToNextTable, "表格");
		};
		lRiywfx5RI.Click += delegate
		{
			AiHelper_7.RunCommand(OutlineNavigationService.GoToNextHighlight, "grpTable");
		};
		Ttiyto9c3J.Click += delegate
		{
			AiHelper_7.RunCommand(OutlineNavigationService.GoToNextHeading, "表格调整");
		};
		Mykys9pFbA.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(PageSplitService.ApplyNotesPageSetup, "B表格调整");
		};
		x1myldNW5p.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(PageSplitService.ApplyCoverPageSetup, "表格配置");
		};
		gLjyNtF5wS.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(PageSplitService.ApplyBodyPageSetup, "B表格配置");
		};
		PJlym1E13O.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(PageSplitService.ToggleOrientationWithBreak, "重复标题");
		};
		lXiyOWFVa5.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfDialog(new RenameDocumentWindow());
			}, "B重复首行");
		};
		stZyopAEjj.Click += delegate
		{
			AiHelper_7.RunCommandWithUndo(PageSplitService.InsertPageNumbers, "粘贴表格");
		};
		NCjyGburcY.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfDialog(new PageNumberStartWindow());
			}, "bEW粘贴");
		};
		xg0yCgJFpq.Click += delegate
		{
			AiHelper_7.RunCommand(PageSplitService.BatchConvertToPdf, "其他调整");
		};
		h0WyplNuXA.Click += delegate
		{
			AiHelper_7.RunCommand(PageSplitService.MergeDocuments, "M列宽");
		};
		IeJy52VjG7.Click += delegate
		{
			AiHelper_7.RunCommand(PageSplitService.SplitByPages, "统一列宽");
		};
		FjOycmk3RK.Click += delegate
		{
			AiHelper_7.RunCommand(PageSplitService.SplitByPageRanges, "b统一列宽");
		};
		sdlyedNyXA.Click += delegate
		{
			AiHelper_7.RunCommand(PageSplitService.SplitBySections, "最大列宽");
		};
		Go4yyvMTqe.Click += delegate
		{
			AiHelper_7.RunCommand(AiHelper_3.BWIBRayGaa, "b列宽调整");
		};
		IclyXnfJ75.Click += delegate
		{
			AiHelper_7.RunCommand(AiHelper_3.YWiVzgIWFQ, "全选表格");
		};
		V7pyhA6tbO.Click += delegate
		{
			AiHelper_7.RunCommand(AiHelper_3.kTVBVZcQB1, "B全选表格");
		};
		zPjyasMy9S.Click += delegate
		{
			AiHelper_7.RunCommand(AiHelper_3.OpenHelpArticle, "数字");
		};
		tWiyqkQmfh.Click += delegate
		{
			AiHelper_7.RunCommand(AiHelper_3.OpenAiCourse, "grpNumber");
		};
		ueWyPmEhpB.Click += delegate
		{
			AiHelper_7.RunCommand(AiHelper_3.OpenTutorialArticle, "千分位符");
		};
		检查更新.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfWindow(new UpdateWindow());
			}, "b千分符");
		};
		PdeyAnLaqI.Click += delegate
		{
			AiHelper_7.RunCommand(AiHelper_3.OpenSponsorshipPage, "千分位符配置");
		};
		s22yvkIREp.Click += delegate
		{
			AiHelper_7.RunCommand(delegate
			{
				WordTableToolService5.ShowWpfWindow(new GlobalConfigWindow());
			}, "B千分符配置");
		};
		mNaeNSP9JX.Click += delegate
		{
			TableBorderConfig.Current.UpdateConfig(delegate(AiHelper_12 configData)
			{
				configData.System.DisableAutomaticStyleUpdate = mNaeNSP9JX.Checked;
			});
		};
	}

	internal void SetRibbonActiveState(bool P_0)
	{
	}

	private void crmeVUrrhp()
	{
		AiSseStreamService.EnsureDirectory(AiSseStreamService.TemplateDir);
		while (ARky3sm6Hj.Items.Count > 1)
		{
			ARky3sm6Hj.Items.RemoveAt(ARky3sm6Hj.Items.Count - 1);
		}
		RibbonButton ribbonButton = base.Factory.CreateRibbonButton();
		ribbonButton.Name = "Template_OpenFolder";
		ribbonButton.Label = "打开目录";
		ribbonButton.ShowImage = false;
		ribbonButton.Click += delegate
		{
			AiHelper_7.RunCommand(IpUeDmgi1F, "TemplateFolder_");
		};
		ARky3sm6Hj.Items.Add(ribbonButton);
		string[] directories = Directory.GetDirectories(AiSseStreamService.TemplateDir);
		foreach (string text in directories)
		{
			string fileName = Path.GetFileName(text);
			RibbonMenu ribbonMenu = base.Factory.CreateRibbonMenu();
			ribbonMenu.Name = "选段求和" + H3Ee9w9sVB(fileName);
			ribbonMenu.Label = fileName;
			ribbonMenu.ShowImage = false;
			ribbonMenu.Dynamic = false;
			prseB4Xlwr(text, ribbonMenu);
			ARky3sm6Hj.Items.Add(ribbonMenu);
		}
		prseB4Xlwr(AiSseStreamService.TemplateDir, ARky3sm6Hj);
	}

	private void prseB4Xlwr(string P_0, RibbonMenu P_1)
	{
		string[] files = Directory.GetFiles(P_0, "*.*", SearchOption.TopDirectoryOnly);
		foreach (string text in files)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
			if (!fileNameWithoutExtension.StartsWith("~", StringComparison.Ordinal))
			{
				RibbonButton ribbonButton = base.Factory.CreateRibbonButton();
				ribbonButton.Name = "Template_" + H3Ee9w9sVB(Path.GetFileName(text));
				ribbonButton.Label = fileNameWithoutExtension;
				ribbonButton.Tag = text;
				ribbonButton.ShowImage = false;
				ribbonButton.Click += IdLeu4WFjM;
				P_1.Items.Add(ribbonButton);
			}
		}
	}

	private static string H3Ee9w9sVB(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return Guid.NewGuid().ToString("N");
		}
		char[] array = P_0.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (!char.IsLetterOrDigit(array[i]) && array[i] != '_')
			{
				array[i] = '_';
			}
		}
		return new string(array) + "_" + Math.Abs(P_0.GetHashCode()).ToString("X");
	}

	private void bWse6tIIpp(object P_0, RibbonControlEventArgs P_1)
	{
		crmeVUrrhp();
	}

	private static void IdLeu4WFjM(object P_0, RibbonControlEventArgs P_1)
	{
		string text = ((RibbonButton)P_0).Tag?.ToString();
		if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
		{
			Documents documents = WordTableToolService.WordApp.Documents;
			object Template = text;
			object NewTemplate = Type.Missing;
			object DocumentType = Type.Missing;
			object Visible = Type.Missing;
			documents.Add(ref Template, ref NewTemplate, ref DocumentType, ref Visible);
		}
	}

	private static void IpUeDmgi1F()
	{
		AiSseStreamService.EnsureDirectory(AiSseStreamService.TemplateDir);
		Process.Start(new ProcessStartInfo(AiSseStreamService.TemplateDir)
		{
			UseShellExecute = true
		});
	}

	public Ribbon1() : base(UiHelper_1.Factory.GetRibbonFactory())
	{
		SseStreamInitializer.InitializeRuntime();
		HVYeTxmVvj();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && X8IeQ09MRY != null)
		{
			X8IeQ09MRY.Dispose();
		}
		base.Dispose(disposing);
	}

	private void HVYeTxmVvj()
	{
		LIxe17aZeb = base.Factory.CreateRibbonTab();
		V8Geru9rQe = base.Factory.CreateRibbonGroup();
		AZAeYmLFnX = base.Factory.CreateRibbonButton();
		ObyeZaW2w9 = base.Factory.CreateRibbonButton();
		QQkefaO87T = base.Factory.CreateRibbonButton();
		GH0eMf7VqG = base.Factory.CreateRibbonSplitButton();
		PEcebFj4uu = base.Factory.CreateRibbonButton();
		XtceSdypsH = base.Factory.CreateRibbonButton();
		aRDewydID6 = base.Factory.CreateRibbonButton();
		YQletHXVWR = base.Factory.CreateRibbonButton();
		s22yvkIREp = base.Factory.CreateRibbonButton();
		Go4yyvMTqe = base.Factory.CreateRibbonButton();
		r5VeJk9IFm = base.Factory.CreateRibbonGroup();
		U6weLyMaIs = base.Factory.CreateRibbonSplitButton();
		KR0el1JrZB = base.Factory.CreateRibbonButton();
		mNaeNSP9JX = base.Factory.CreateRibbonCheckBox();
		PsQemjAYEX = base.Factory.CreateRibbonButton();
		O2neocYeVm = base.Factory.CreateRibbonButton();
		uhBeGMidU6 = base.Factory.CreateRibbonMenu();
		bLLeCoCtqb = base.Factory.CreateRibbonButton();
		YBwepj7oQk = base.Factory.CreateRibbonButton();
		Qcme36brMZ = base.Factory.CreateRibbonGroup();
		XuKeOjATgB = base.Factory.CreateRibbonSplitButton();
		DpUenM8VkU = base.Factory.CreateRibbonButton();
		hjme7a7ldE = base.Factory.CreateRibbonButton();
		Xaje5BbwlX = base.Factory.CreateRibbonButton();
		rJXecbOgQg = base.Factory.CreateRibbonMenu();
		y00eeSplD5 = base.Factory.CreateRibbonButton();
		XMReyfDAJ6 = base.Factory.CreateRibbonButton();
		JYyeXQZPep = base.Factory.CreateRibbonButton();
		UULeULqlBm = base.Factory.CreateRibbonGroup();
		DDFeFR1h9o = base.Factory.CreateRibbonSplitButton();
		QclehQJ0Qe = base.Factory.CreateRibbonButton();
		E4NednknFu = base.Factory.CreateRibbonButton();
		lQMeWPEgFZ = base.Factory.CreateRibbonSplitButton();
		O1Nek8dtjg = base.Factory.CreateRibbonButton();
		OlVez8DVQb = base.Factory.CreateRibbonMenu();
		jUPe0WVcH5 = base.Factory.CreateRibbonButton();
		AfNexqU5xE = base.Factory.CreateRibbonButton();
		nhweay61dH = base.Factory.CreateRibbonMenu();
		Y4weqgO6Ip = base.Factory.CreateRibbonButton();
		GSseP3ATQx = base.Factory.CreateRibbonButton();
		JHKeAsJpU4 = base.Factory.CreateRibbonButton();
		eIievpV7yo = base.Factory.CreateRibbonButton();
		nMfeKu7MhY = base.Factory.CreateRibbonGroup();
		DDYyRiDwU0 = base.Factory.CreateRibbonButton();
		F3SyViFQfi = base.Factory.CreateRibbonButton();
		snjyBetBK5 = base.Factory.CreateRibbonMenu();
		gvCy9TVUH2 = base.Factory.CreateRibbonButton();
		批量替换 = base.Factory.CreateRibbonButton();
		vgMy6lHtI3 = base.Factory.CreateRibbonMenu();
		WOoyup6EfT = base.Factory.CreateRibbonButton();
		GS0yDJ0IHx = base.Factory.CreateRibbonButton();
		ARky3sm6Hj = base.Factory.CreateRibbonMenu();
		FUPyUfkrpN = base.Factory.CreateRibbonButton();
		p2oeEOBmqI = base.Factory.CreateRibbonGroup();
		QXuyTpqqg5 = base.Factory.CreateRibbonButton();
		QxVygurCMp = base.Factory.CreateRibbonButton();
		Jgty8WWI8v = base.Factory.CreateRibbonButton();
		L4byIXApGn = base.Factory.CreateRibbonButton();
		KjyyiTpBqf = base.Factory.CreateRibbonButton();
		StJyHMefXC = base.Factory.CreateRibbonButton();
		ttCe2WZOxK = base.Factory.CreateRibbonGroup();
		kVXyKrngMn = base.Factory.CreateRibbonButton();
		RkVyQhB0BG = base.Factory.CreateRibbonMenu();
		c99y1e88Ah = base.Factory.CreateRibbonButton();
		VFKyroq1pl = base.Factory.CreateRibbonButton();
		oAlyJlhmwW = base.Factory.CreateRibbonButton();
		ULEybERcmZ = base.Factory.CreateRibbonMenu();
		aDkyMcIU5v = base.Factory.CreateRibbonMenu();
		NSUySeG74c = base.Factory.CreateRibbonButton();
		lRiywfx5RI = base.Factory.CreateRibbonButton();
		Ttiyto9c3J = base.Factory.CreateRibbonButton();
		OKDyZCymnC = base.Factory.CreateRibbonButton();
		CtnyfNejNN = base.Factory.CreateRibbonButton();
		rACe4liUgJ = base.Factory.CreateRibbonGroup();
		iUwyLRMxYn = base.Factory.CreateRibbonMenu();
		Mykys9pFbA = base.Factory.CreateRibbonButton();
		x1myldNW5p = base.Factory.CreateRibbonButton();
		gLjyNtF5wS = base.Factory.CreateRibbonButton();
		stZyopAEjj = base.Factory.CreateRibbonSplitButton();
		NCjyGburcY = base.Factory.CreateRibbonButton();
		SMPy7URxdn = base.Factory.CreateRibbonMenu();
		PJlym1E13O = base.Factory.CreateRibbonButton();
		lXiyOWFVa5 = base.Factory.CreateRibbonButton();
		xg0yCgJFpq = base.Factory.CreateRibbonButton();
		h0WyplNuXA = base.Factory.CreateRibbonButton();
		Ybtyny6IuG = base.Factory.CreateRibbonMenu();
		IeJy52VjG7 = base.Factory.CreateRibbonButton();
		FjOycmk3RK = base.Factory.CreateRibbonButton();
		sdlyedNyXA = base.Factory.CreateRibbonButton();
		wxBej1rKZn = base.Factory.CreateRibbonGroup();
		WGkyFT7Qna = base.Factory.CreateRibbonMenu();
		V7pyhA6tbO = base.Factory.CreateRibbonButton();
		zPjyasMy9S = base.Factory.CreateRibbonButton();
		tWiyqkQmfh = base.Factory.CreateRibbonButton();
		ueWyPmEhpB = base.Factory.CreateRibbonButton();
		检查更新 = base.Factory.CreateRibbonButton();
		PdeyAnLaqI = base.Factory.CreateRibbonSplitButton();
		IclyXnfJ75 = base.Factory.CreateRibbonButton();
		f82yEnEnAi = base.Factory.CreateRibbonButton();
		OCPy2sVgbO = base.Factory.CreateRibbonButton();
		gRty4Mu1gv = base.Factory.CreateRibbonButton();
		BhByjXGxgN = base.Factory.CreateRibbonButton();
		Lg5yYCLRLo = base.Factory.CreateRibbonButton();
		LIxe17aZeb.SuspendLayout();
		V8Geru9rQe.SuspendLayout();
		r5VeJk9IFm.SuspendLayout();
		Qcme36brMZ.SuspendLayout();
		UULeULqlBm.SuspendLayout();
		nMfeKu7MhY.SuspendLayout();
		p2oeEOBmqI.SuspendLayout();
		ttCe2WZOxK.SuspendLayout();
		rACe4liUgJ.SuspendLayout();
		wxBej1rKZn.SuspendLayout();
		SuspendLayout();
		LIxe17aZeb.Groups.Add(V8Geru9rQe);
		LIxe17aZeb.Groups.Add(UULeULqlBm);
		LIxe17aZeb.Groups.Add(nMfeKu7MhY);
		LIxe17aZeb.Groups.Add(p2oeEOBmqI);
		LIxe17aZeb.Groups.Add(ttCe2WZOxK);
		LIxe17aZeb.Label = "IP_Assurance";
		LIxe17aZeb.Name = "tabCPA";
		V8Geru9rQe.Items.Add(AZAeYmLFnX);
		V8Geru9rQe.Items.Add(ObyeZaW2w9);
		V8Geru9rQe.Items.Add(s22yvkIREp);
		V8Geru9rQe.Label = "通用";
		V8Geru9rQe.Name = "grpGeneral";
		AZAeYmLFnX.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		AZAeYmLFnX.OfficeImageId = "SmartLookup";
		AZAeYmLFnX.Label = "智能助手";
		AZAeYmLFnX.Name = "SBAI助手";
		AZAeYmLFnX.ShowImage = true;
		ObyeZaW2w9.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		ObyeZaW2w9.Label = "AI配置";
		ObyeZaW2w9.Name = "BtnAIConfig";
		ObyeZaW2w9.OfficeImageId = "ControlsGallery";
		ObyeZaW2w9.ShowImage = true;
		GH0eMf7VqG.Items.Add(PEcebFj4uu);
		GH0eMf7VqG.Items.Add(XtceSdypsH);
		GH0eMf7VqG.Items.Add(aRDewydID6);
		GH0eMf7VqG.Items.Add(YQletHXVWR);
		GH0eMf7VqG.Label = "桌面钉图";
		GH0eMf7VqG.Name = "SplitBtn钉桌面";
		PEcebFj4uu.Label = "系统截图/录屏";
		PEcebFj4uu.Name = "Btn开始截图";
		PEcebFj4uu.ShowImage = true;
		XtceSdypsH.Label = "快速全屏截图";
		XtceSdypsH.Name = "Btn快速全屏截图";
		XtceSdypsH.ShowImage = true;
		aRDewydID6.Label = "关闭所有钉图";
		aRDewydID6.Name = "Btn关闭所有钉图";
		aRDewydID6.ShowImage = true;
		YQletHXVWR.Label = "配置";
		YQletHXVWR.Name = "Btn钉图配置";
		YQletHXVWR.ShowImage = true;
		s22yvkIREp.Label = "全局配置";
		s22yvkIREp.Name = "B全局配置";
		s22yvkIREp.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		s22yvkIREp.OfficeImageId = "DatabaseGear";
		s22yvkIREp.ShowImage = true;
		Go4yyvMTqe.Label = "使用帮助";
		Go4yyvMTqe.Name = "B说明";
		Go4yyvMTqe.ShowImage = true;
		r5VeJk9IFm.Items.Add(U6weLyMaIs);
		r5VeJk9IFm.Items.Add(PsQemjAYEX);
		r5VeJk9IFm.Items.Add(O2neocYeVm);
		r5VeJk9IFm.Items.Add(uhBeGMidU6);
		r5VeJk9IFm.Label = "段落";
		r5VeJk9IFm.Name = "grpParagraph";
		U6weLyMaIs.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		U6weLyMaIs.Items.Add(KR0el1JrZB);
		U6weLyMaIs.Items.Add(mNaeNSP9JX);
		U6weLyMaIs.Label = "段落调整";
		U6weLyMaIs.Name = "B段落格式调整";
		KR0el1JrZB.Label = "段落配置";
		KR0el1JrZB.Name = "B段落配置";
		KR0el1JrZB.ShowImage = true;
		mNaeNSP9JX.Label = "关闭样式自动更新";
		mNaeNSP9JX.Name = "C关闭自动样式";
		PsQemjAYEX.Label = "表前单位";
		PsQemjAYEX.Name = "b表前单位";
		O2neocYeVm.Label = "表后注释";
		O2neocYeVm.Name = "b表后注释";
		uhBeGMidU6.Items.Add(bLLeCoCtqb);
		uhBeGMidU6.Items.Add(YBwepj7oQk);
		uhBeGMidU6.Label = "表后段落";
		uhBeGMidU6.Name = "m表后段落";
		bLLeCoCtqb.Label = "全选表后第一段";
		bLLeCoCtqb.Name = "b全选表后第一段";
		bLLeCoCtqb.ShowImage = true;
		YBwepj7oQk.Label = "表后间距处理";
		YBwepj7oQk.Name = "b表后段落处理";
		YBwepj7oQk.ShowImage = true;
		Qcme36brMZ.Items.Add(XuKeOjATgB);
		Qcme36brMZ.Items.Add(hjme7a7ldE);
		Qcme36brMZ.Items.Add(Xaje5BbwlX);
		Qcme36brMZ.Items.Add(rJXecbOgQg);
		Qcme36brMZ.Label = "表格";
		Qcme36brMZ.Name = "grpTable";
		XuKeOjATgB.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		XuKeOjATgB.Items.Add(DpUenM8VkU);
		XuKeOjATgB.Label = "表格调整";
		XuKeOjATgB.Name = "B表格调整";
		DpUenM8VkU.Label = "表格配置";
		DpUenM8VkU.Name = "B表格配置";
		DpUenM8VkU.ShowImage = true;
		hjme7a7ldE.Label = "重复标题";
		hjme7a7ldE.Name = "B重复首行";
		Xaje5BbwlX.Label = "粘贴表格";
		Xaje5BbwlX.Name = "bEW粘贴";
		rJXecbOgQg.Items.Add(y00eeSplD5);
		rJXecbOgQg.Items.Add(XMReyfDAJ6);
		rJXecbOgQg.Items.Add(JYyeXQZPep);
		rJXecbOgQg.Label = "其他调整";
		rJXecbOgQg.Name = "M列宽";
		y00eeSplD5.Label = "统一列宽";
		y00eeSplD5.Name = "b统一列宽";
		y00eeSplD5.ShowImage = true;
		XMReyfDAJ6.Label = "最大列宽";
		XMReyfDAJ6.Name = "b列宽调整";
		XMReyfDAJ6.ShowImage = true;
		JYyeXQZPep.Label = "全选表格";
		JYyeXQZPep.Name = "B全选表格";
		JYyeXQZPep.ShowImage = true;
		UULeULqlBm.Items.Add(DDFeFR1h9o);
		UULeULqlBm.Items.Add(E4NednknFu);
		UULeULqlBm.Items.Add(lQMeWPEgFZ);
		UULeULqlBm.Items.Add(OlVez8DVQb);
		UULeULqlBm.Label = "数字";
		UULeULqlBm.Name = "grpNumber";
		DDFeFR1h9o.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		DDFeFR1h9o.OfficeImageId = "NumberFormat";
		DDFeFR1h9o.Items.Add(QclehQJ0Qe);
		DDFeFR1h9o.Label = "千分位符";
		DDFeFR1h9o.Name = "b千分符";
		QclehQJ0Qe.Label = "千分位符配置";
		QclehQJ0Qe.Name = "B千分符配置";
		QclehQJ0Qe.OfficeImageId = "Gear";
		QclehQJ0Qe.ShowImage = true;
		E4NednknFu.Label = "选段求和";
		E4NednknFu.Name = "B选段求和";
		E4NednknFu.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		E4NednknFu.OfficeImageId = "AutoSum";
		E4NednknFu.ShowImage = true;
		lQMeWPEgFZ.Items.Add(O1Nek8dtjg);
		lQMeWPEgFZ.Label = "除以一万";
		lQMeWPEgFZ.Name = "b除以万";
		lQMeWPEgFZ.OfficeImageId = "Calculator";
		O1Nek8dtjg.Label = "乘以100";
		O1Nek8dtjg.Name = "B乘以一百";
		O1Nek8dtjg.OfficeImageId = "Calculator";
		O1Nek8dtjg.ShowImage = true;
		OlVez8DVQb.Items.Add(jUPe0WVcH5);
		OlVez8DVQb.Items.Add(AfNexqU5xE);
		OlVez8DVQb.Items.Add(nhweay61dH);
		OlVez8DVQb.Label = "更多数字";
		OlVez8DVQb.Name = "M数字更多";
		OlVez8DVQb.OfficeImageId = "MoreControls";
		OlVez8DVQb.ShowImage = true;
		jUPe0WVcH5.Label = "添加万";
		jUPe0WVcH5.Name = "b添加万";
		jUPe0WVcH5.ShowImage = true;
		AfNexqU5xE.Label = "加百分号";
		AfNexqU5xE.Name = "B添加百分号";
		AfNexqU5xE.ShowImage = true;
		nhweay61dH.Items.Add(Y4weqgO6Ip);
		nhweay61dH.Items.Add(GSseP3ATQx);
		nhweay61dH.Items.Add(JHKeAsJpU4);
		nhweay61dH.Items.Add(eIievpV7yo);
		nhweay61dH.Label = "日期转换";
		nhweay61dH.Name = "M日期转换";
		nhweay61dH.ShowImage = true;
		Y4weqgO6Ip.Label = "转为 yyyy.MM.dd";
		Y4weqgO6Ip.Name = "B日期转点号";
		Y4weqgO6Ip.ShowImage = true;
		GSseP3ATQx.Label = "转为 yyyy/MM/dd";
		GSseP3ATQx.Name = "B日期转斜杠";
		GSseP3ATQx.ShowImage = true;
		JHKeAsJpU4.Label = "转为 yyyy-MM-dd";
		JHKeAsJpU4.Name = "B日期转横杠";
		JHKeAsJpU4.ShowImage = true;
		eIievpV7yo.Label = "转为 yyyy年MM月dd日";
		eIievpV7yo.Name = "B日期转年月日";
		eIievpV7yo.ShowImage = true;
		nMfeKu7MhY.Items.Add(DDYyRiDwU0);
		nMfeKu7MhY.Items.Add(F3SyViFQfi);
		nMfeKu7MhY.Items.Add(snjyBetBK5);
		nMfeKu7MhY.Label = "文字";
		nMfeKu7MhY.Name = "grpText";
		DDYyRiDwU0.Label = "去除空白";
		DDYyRiDwU0.Name = "b去除空白";
		DDYyRiDwU0.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		DDYyRiDwU0.OfficeImageId = "TextRemoveSpace";
		DDYyRiDwU0.ShowImage = true;
		F3SyViFQfi.Label = "标记高亮";
		F3SyViFQfi.Name = "b高亮";
		F3SyViFQfi.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		F3SyViFQfi.OfficeImageId = "HighlightDefault";
		F3SyViFQfi.ShowImage = true;
		snjyBetBK5.Items.Add(gvCy9TVUH2);
		snjyBetBK5.Items.Add(批量替换);
		snjyBetBK5.Items.Add(vgMy6lHtI3);
		snjyBetBK5.Label = "更多文字";
		snjyBetBK5.Name = "M文字更多";
		snjyBetBK5.OfficeImageId = "MoreControls";
		snjyBetBK5.ShowImage = true;
		gvCy9TVUH2.Label = "全角符号";
		gvCy9TVUH2.Name = "B中英符号";
		gvCy9TVUH2.ShowImage = true;
		批量替换.Label = "批量替换";
		批量替换.Name = "批量替换";
		批量替换.ShowImage = true;
		vgMy6lHtI3.Items.Add(WOoyup6EfT);
		vgMy6lHtI3.Items.Add(GS0yDJ0IHx);
		vgMy6lHtI3.Label = "删空白段";
		vgMy6lHtI3.Name = "Menu1";
		vgMy6lHtI3.ShowImage = true;
		WOoyup6EfT.Label = "删空白段";
		WOoyup6EfT.Name = "Btn去除空行";
		WOoyup6EfT.ShowImage = true;
		GS0yDJ0IHx.Label = "去除换行符";
		GS0yDJ0IHx.Name = "Btn去除换行符";
		GS0yDJ0IHx.ShowImage = true;
		ARky3sm6Hj.Dynamic = true;
		ARky3sm6Hj.Items.Add(FUPyUfkrpN);
		ARky3sm6Hj.Label = "模板目录";
		ARky3sm6Hj.Name = "M模板库";
		ARky3sm6Hj.ShowImage = true;
		ARky3sm6Hj.ItemsLoading += bWse6tIIpp;
		FUPyUfkrpN.Label = "刷新列表";
		FUPyUfkrpN.Name = "B刷新列表";
		FUPyUfkrpN.ShowImage = true;
		p2oeEOBmqI.Items.Add(QXuyTpqqg5);
		p2oeEOBmqI.Items.Add(QxVygurCMp);
		p2oeEOBmqI.Items.Add(Jgty8WWI8v);
		p2oeEOBmqI.Items.Add(L4byIXApGn);
		p2oeEOBmqI.Items.Add(KjyyiTpBqf);
		p2oeEOBmqI.Items.Add(StJyHMefXC);
		p2oeEOBmqI.Label = "大纲级次";
		p2oeEOBmqI.Name = "grpOutline";
		QXuyTpqqg5.Label = "一级";
		QXuyTpqqg5.Name = "b一级";
		QXuyTpqqg5.OfficeImageId = "OutlineLevel1";
		QXuyTpqqg5.ShowImage = true;
		QxVygurCMp.Label = "二级";
		QxVygurCMp.Name = "b二级";
		QxVygurCMp.OfficeImageId = "OutlineLevel2";
		QxVygurCMp.ShowImage = true;
		Jgty8WWI8v.Label = "三级";
		Jgty8WWI8v.Name = "b三级";
		Jgty8WWI8v.OfficeImageId = "OutlineLevel3";
		Jgty8WWI8v.ShowImage = true;
		L4byIXApGn.Label = "四级";
		L4byIXApGn.Name = "b四级";
		L4byIXApGn.OfficeImageId = "OutlineLevel4";
		L4byIXApGn.ShowImage = true;
		KjyyiTpBqf.Label = "五级";
		KjyyiTpBqf.Name = "b五级";
		KjyyiTpBqf.OfficeImageId = "OutlineLevel5";
		KjyyiTpBqf.ShowImage = true;
		StJyHMefXC.Label = "正文";
		StJyHMefXC.Name = "b正文";
		StJyHMefXC.OfficeImageId = "OutlineBodyText";
		StJyHMefXC.ShowImage = true;
		ttCe2WZOxK.Items.Add(c99y1e88Ah);
		ttCe2WZOxK.Items.Add(VFKyroq1pl);
		ttCe2WZOxK.Items.Add(oAlyJlhmwW);
		ttCe2WZOxK.Items.Add(aDkyMcIU5v);
		ttCe2WZOxK.Items.Add(OKDyZCymnC);
		ttCe2WZOxK.Items.Add(CtnyfNejNN);
		ttCe2WZOxK.Label = "校验/同步";
		ttCe2WZOxK.Name = "grpValidation";
		c99y1e88Ah.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		c99y1e88Ah.Label = "行校验";
		c99y1e88Ah.Name = "b行校验";
		c99y1e88Ah.OfficeImageId = "TableCheckRow";
		c99y1e88Ah.ShowImage = true;
		VFKyroq1pl.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		VFKyroq1pl.Label = "列校验";
		VFKyroq1pl.Name = "b列校验";
		VFKyroq1pl.OfficeImageId = "TableCheckColumn";
		VFKyroq1pl.ShowImage = true;
		oAlyJlhmwW.Label = "区域求和";
		oAlyJlhmwW.Name = "b区域求和";
		oAlyJlhmwW.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		oAlyJlhmwW.OfficeImageId = "FunctionWizard";
		oAlyJlhmwW.ShowImage = true;
		aDkyMcIU5v.Items.Add(NSUySeG74c);
		aDkyMcIU5v.Items.Add(lRiywfx5RI);
		aDkyMcIU5v.Items.Add(Ttiyto9c3J);
		aDkyMcIU5v.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		aDkyMcIU5v.Label = "找下一个";
		aDkyMcIU5v.Name = "M查找下一个";
		aDkyMcIU5v.OfficeImageId = "FindNext";
		aDkyMcIU5v.ShowImage = true;
		NSUySeG74c.Label = "下一个表格";
		NSUySeG74c.Name = "B下一个表格";
		NSUySeG74c.ShowImage = true;
		lRiywfx5RI.Label = "下一个高亮";
		lRiywfx5RI.Name = "B下一个高亮";
		lRiywfx5RI.ShowImage = true;
		Ttiyto9c3J.Label = "下一个标题";
		Ttiyto9c3J.Name = "B下一个标题";
		Ttiyto9c3J.ShowImage = true;
		OKDyZCymnC.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		OKDyZCymnC.Label = "清洁定稿";
		OKDyZCymnC.Name = "B清洁文档";
		OKDyZCymnC.OfficeImageId = "DocumentReview";
		OKDyZCymnC.ShowImage = true;
		CtnyfNejNN.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
		CtnyfNejNN.Label = "批注导出";
		CtnyfNejNN.Name = "B批注导出";
		CtnyfNejNN.OfficeImageId = "ReviewComments";
		CtnyfNejNN.ShowImage = true;
		rACe4liUgJ.Items.Add(iUwyLRMxYn);
		rACe4liUgJ.Items.Add(stZyopAEjj);
		rACe4liUgJ.Items.Add(SMPy7URxdn);
		rACe4liUgJ.Label = "页面";
		rACe4liUgJ.Name = "grpPage";
		iUwyLRMxYn.Items.Add(Mykys9pFbA);
		iUwyLRMxYn.Items.Add(x1myldNW5p);
		iUwyLRMxYn.Items.Add(gLjyNtF5wS);
		iUwyLRMxYn.Label = "边距设置";
		iUwyLRMxYn.Name = "g页边距设置";
		Mykys9pFbA.Label = "附注页";
		Mykys9pFbA.Name = "b附注页";
		Mykys9pFbA.ShowImage = true;
		x1myldNW5p.Label = "封面页";
		x1myldNW5p.Name = "b封面页";
		x1myldNW5p.ShowImage = true;
		gLjyNtF5wS.Label = "正文页";
		gLjyNtF5wS.Name = "b正文页";
		gLjyNtF5wS.ShowImage = true;
		stZyopAEjj.Items.Add(NCjyGburcY);
		stZyopAEjj.Label = "添加页码";
		stZyopAEjj.Name = "b添加页码";
		NCjyGburcY.Label = "页码起始值";
		NCjyGburcY.Name = "b页码起始值";
		NCjyGburcY.ShowImage = true;
		SMPy7URxdn.Items.Add(PJlym1E13O);
		SMPy7URxdn.Items.Add(lXiyOWFVa5);
		SMPy7URxdn.Items.Add(xg0yCgJFpq);
		SMPy7URxdn.Items.Add(h0WyplNuXA);
		SMPy7URxdn.Items.Add(Ybtyny6IuG);
		SMPy7URxdn.Label = "更多页面";
		SMPy7URxdn.Name = "M页面更多";
		SMPy7URxdn.ShowImage = true;
		PJlym1E13O.Label = "插入横页";
		PJlym1E13O.Name = "b插入横页";
		PJlym1E13O.ShowImage = true;
		lXiyOWFVa5.Label = "重命名文档";
		lXiyOWFVa5.Name = "Btn重命名文档";
		lXiyOWFVa5.ShowImage = true;
		xg0yCgJFpq.Label = "批量转为PDF";
		xg0yCgJFpq.Name = "b批量pdf";
		xg0yCgJFpq.ShowImage = true;
		h0WyplNuXA.Label = "批量合并文档";
		h0WyplNuXA.Name = "b批量合并文档";
		h0WyplNuXA.ShowImage = true;
		Ybtyny6IuG.Items.Add(IeJy52VjG7);
		Ybtyny6IuG.Items.Add(FjOycmk3RK);
		Ybtyny6IuG.Items.Add(sdlyedNyXA);
		Ybtyny6IuG.Label = "批量拆分文档";
		Ybtyny6IuG.Name = "M拆分文档";
		Ybtyny6IuG.ShowImage = true;
		IeJy52VjG7.Label = "按固定页拆分";
		IeJy52VjG7.Name = "b拆分文档";
		IeJy52VjG7.ShowImage = true;
		FjOycmk3RK.Label = "按指定页拆分";
		FjOycmk3RK.Name = "b指定页拆分";
		FjOycmk3RK.ShowImage = true;
		sdlyedNyXA.Label = "按分节符拆分";
		sdlyedNyXA.Name = "b分节符拆分";
		sdlyedNyXA.ShowImage = true;
		wxBej1rKZn.Items.Add(WGkyFT7Qna);
		wxBej1rKZn.Items.Add(检查更新);
		wxBej1rKZn.Items.Add(PdeyAnLaqI);
		wxBej1rKZn.Label = "其他";
		wxBej1rKZn.Name = "grpAbout";
		WGkyFT7Qna.Items.Add(V7pyhA6tbO);
		WGkyFT7Qna.Items.Add(zPjyasMy9S);
		WGkyFT7Qna.Items.Add(tWiyqkQmfh);
		WGkyFT7Qna.Items.Add(ueWyPmEhpB);
		WGkyFT7Qna.Label = "数智课程";
		WGkyFT7Qna.Name = "Menu数字化课";
		WGkyFT7Qna.ShowImage = true;
		V7pyhA6tbO.Label = "Excel课程";
		V7pyhA6tbO.Name = "Btn课程Excel";
		V7pyhA6tbO.ShowImage = true;
		zPjyasMy9S.Label = "Word课程";
		zPjyasMy9S.Name = "Btn课程Word";
		zPjyasMy9S.ShowImage = true;
		tWiyqkQmfh.Label = "AI实战课程";
		tWiyqkQmfh.Name = "Btn课程AI";
		tWiyqkQmfh.ShowImage = true;
		ueWyPmEhpB.Label = "VBA课程";
		ueWyPmEhpB.Name = "Btn课程VBA";
		ueWyPmEhpB.ShowImage = true;
		检查更新.Label = "检查更新";
		检查更新.Name = "检查更新";
		PdeyAnLaqI.Items.Add(IclyXnfJ75);
		PdeyAnLaqI.Label = "打赏一下";
		PdeyAnLaqI.Name = "捐赠";
		IclyXnfJ75.Label = "关于作者";
		IclyXnfJ75.Name = "关于作者";
		IclyXnfJ75.ShowImage = true;
		f82yEnEnAi.Label = "导出全部表并绑定";
		f82yEnEnAi.Name = "B导出全部表并绑定";
		f82yEnEnAi.ShowImage = true;
		OCPy2sVgbO.Label = "Excel同步";
		OCPy2sVgbO.Name = "B同步当前表";
		OCPy2sVgbO.ShowImage = true;
		gRty4Mu1gv.Label = "同步全部表";
		gRty4Mu1gv.Name = "B同步全部表";
		gRty4Mu1gv.ShowImage = true;
		BhByjXGxgN.Label = "重新绑定";
		BhByjXGxgN.Name = "B重新绑定";
		BhByjXGxgN.ShowImage = true;
		Lg5yYCLRLo.Label = "Excel同步";
		Lg5yYCLRLo.Name = "B管理绑定";
		Lg5yYCLRLo.ShowImage = true;
		base.Name = "Ribbon1";
		base.RibbonType = "Microsoft.Word.Document";
		base.Tabs.Add(LIxe17aZeb);
		base.Load += DAgc0ePsPG;
		LIxe17aZeb.ResumeLayout(performLayout: false);
		LIxe17aZeb.PerformLayout();
		V8Geru9rQe.ResumeLayout(performLayout: false);
		V8Geru9rQe.PerformLayout();
		r5VeJk9IFm.ResumeLayout(performLayout: false);
		r5VeJk9IFm.PerformLayout();
		Qcme36brMZ.ResumeLayout(performLayout: false);
		Qcme36brMZ.PerformLayout();
		UULeULqlBm.ResumeLayout(performLayout: false);
		UULeULqlBm.PerformLayout();
		nMfeKu7MhY.ResumeLayout(performLayout: false);
		nMfeKu7MhY.PerformLayout();
		p2oeEOBmqI.ResumeLayout(performLayout: false);
		p2oeEOBmqI.PerformLayout();
		ttCe2WZOxK.ResumeLayout(performLayout: false);
		ttCe2WZOxK.PerformLayout();
		rACe4liUgJ.ResumeLayout(performLayout: false);
		rACe4liUgJ.PerformLayout();
		wxBej1rKZn.ResumeLayout(performLayout: false);
		wxBej1rKZn.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private void e7pegctZBX(object P_0, RibbonControlEventArgs P_1)
	{
		AiHelper_7.RunCommand(crmeVUrrhp, "刷新模板列表");
	}

	[CompilerGenerated]
	private void Knwe85eEQJ(object P_0, RibbonControlEventArgs P_1)
	{
		TableBorderConfig.Current.UpdateConfig(delegate(AiHelper_12 configData)
		{
			configData.System.DisableAutomaticStyleUpdate = mNaeNSP9JX.Checked;
		});
	}

	[CompilerGenerated]
	private void cKreIAfSTl(AiHelper_12 P_0)
	{
		P_0.System.DisableAutomaticStyleUpdate = mNaeNSP9JX.Checked;
	}
}
