using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using CPAHelperForWordRe.UI.Forms;
using AiConfigBootstrap;
using AiHelper_20;
using TableBorderConfig;
using WordTableToolService5;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService;
using LoggerInitializer;

namespace BatchTableAdjustService;

internal static class BatchTableAdjustService
{
	private struct TableRange
	{
		[CompilerGenerated]
		private readonly int _int;

		[CompilerGenerated]
		private readonly int _int;

		public int Start
		{
			[CompilerGenerated]
			get
			{
				return _int;
			}
		}

		public int End
		{
			[CompilerGenerated]
			get
			{
				return _int;
			}
		}

		public TableRange(int P_0, int P_1)
		{
			SseStreamInitializer.InitializeRuntime();
			_int = P_0;
			_int = P_1;
		}
	}

	private static readonly List<TableRange> _tableRanges;

	private static string _selectedDocumentName;

	private static Application App => WordTableToolService.WordApp;

	private static TableBorderConfig Cfg => TableBorderConfig.Current;

	public static void AdjustTableLayout()
	{
		Cfg.SaveToFile();
		App.ScreenUpdating = false;
		WdAlertLevel displayAlerts = App.DisplayAlerts;
		App.DisplayAlerts = WdAlertLevel.wdAlertsNone;
		try
		{
			if (App.Selection.Tables.Count == 0)
			{
				LoggerInitializer.ShowInfo("请将光标放在表格内", "IP_Assurance");
			}
			else
			{
				ApplyTableFormat(App.Selection.Tables[1]);
			}
		}
		finally
		{
			App.DisplayAlerts = displayAlerts;
			App.ScreenUpdating = true;
		}
	}

	public static void BatchAdjustTables()
	{
		Cfg.SaveToFile();
		App.ScreenUpdating = false;
		WdAlertLevel displayAlerts = App.DisplayAlerts;
		ProgressWindow progressWindow = null;
		App.DisplayAlerts = WdAlertLevel.wdAlertsNone;
		try
		{
			List<Table> list = new List<Table>();
			Document activeDocument = App.ActiveDocument;
			if (App.Selection.Tables.Count > 1)
			{
				if (_tableRanges.Count > 0)
				{
					ClearSavedTableRanges();
				}
				foreach (Table table in App.Selection.Tables)
				{
					list.Add(table);
				}
			}
			else if (IsSelectionValid(activeDocument))
			{
				int count = _tableRanges.Count;
				if (!LoggerInitializer.ShowConfirm(string.Format("将批量调整 {0} 个表格，是否确认？", count), "IP_Assurance"))
				{
					ClearSavedTableRanges();
					CollapseSelectionToStart();
					return;
				}
				list.AddRange(EnumerateTablesByRanges(activeDocument));
				ClearSavedTableRanges();
			}
			else
			{
				if (_tableRanges.Count > 0)
				{
					ClearSavedTableRanges();
				}
				foreach (Table table2 in App.Selection.Tables)
				{
					list.Add(table2);
				}
			}
			int count2 = list.Count;
			if (count2 == 0)
			{
				LoggerInitializer.ShowInfo("请选择一个或多个表格", "IP_Assurance");
				return;
			}
			progressWindow = CreateProgressWindow();
			int num = 0;
			foreach (Table item in list)
			{
				num++;
				ApplyTableFormat(item);
				if (!UpdateProgress(progressWindow, num, count2))
				{
					break;
				}
			}
		}
		finally
		{
			CloseProgressWindow(progressWindow);
			App.DisplayAlerts = displayAlerts;
			App.ScreenUpdating = true;
		}
	}

	internal static void AdjustTablesInRange(Range P_0, bool P_1)
	{
		AdjustTablesInRangeWithCallback(P_0, P_1, null);
	}

	internal static void AdjustTablesInRangeWithCallback(Range P_0, bool P_1, Func<int, int, string, bool> P_2)
	{
		Cfg.SaveToFile();
		App.ScreenUpdating = false;
		WdAlertLevel displayAlerts = App.DisplayAlerts;
		ProgressWindow progressWindow = null;
		App.DisplayAlerts = WdAlertLevel.wdAlertsNone;
		try
		{
			if (P_0 == null)
			{
				return;
			}
			List<Table> list = new List<Table>();
			foreach (Table table in P_0.Tables)
			{
				list.Add(table);
			}
			int count = list.Count;
			if (count == 0)
			{
				return;
			}
			bool flag = P_1 && P_2 == null;
			if (flag)
			{
				progressWindow = CreateProgressWindow();
			}
			int num = 0;
			foreach (Table item in list)
			{
				num++;
				ApplyTableFormat(item);
				string arg = string.Format("正在设置表格格式：{0} / {1}", num, count);
				if (P_2 != null)
				{
					if (!P_2(num, count, arg))
					{
						break;
					}
				}
				else if (flag && !UpdateProgress(progressWindow, num, count))
				{
					break;
				}
			}
		}
		finally
		{
			CloseProgressWindow(progressWindow);
			App.DisplayAlerts = displayAlerts;
			App.ScreenUpdating = true;
		}
	}

	private static void ApplyTableFormat(Table P_0)
	{
		try
		{
			ClearShadingAndSetStyle(P_0);
			SetCellPadding(P_0);
			SetBorderStyles(P_0);
			SetFirstColumnRightBorder(P_0);
			SetRowProperties(P_0);
			SetFontAndParagraphFormat(P_0);
			ClassifyAndFormatCells(P_0);
			FormatHeaderRow(P_0);
			P_0.Columns.PreferredWidthType = WdPreferredWidthType.wdPreferredWidthAuto;
			P_0.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
			ApplyWidthMode(P_0);
		}
		catch (Exception ex)
		{
			LogTableAdjustWarning("表格调整失败", ex);
		}
	}

	private static void ClearShadingAndSetStyle(Table P_0)
	{
		try
		{
			P_0.Shading.ForegroundPatternColor = WdColor.wdColorAutomatic;
			P_0.Shading.BackgroundPatternColor = WdColor.wdColorAutomatic;
			App.Options.DefaultHighlightColorIndex = WdColorIndex.wdAuto;
			P_0.Range.HighlightColorIndex = WdColorIndex.wdAuto;
			object prop = "表格主题";
			P_0.set_Style(ref prop);
		}
		catch (Exception ex)
		{
			LogTableAdjustWarning("检查表格底色/样式", ex);
		}
	}

	private static void SetCellPadding(Table P_0)
	{
		try
		{
			P_0.TopPadding = App.CentimetersToPoints((float)Cfg.GetDouble("表格_单元格_上边距"));
			P_0.BottomPadding = App.CentimetersToPoints((float)Cfg.GetDouble("表格_单元格_下边距"));
			Application app = App;
			float pixels = (float)Cfg.GetDouble("表格_单元格_左边距", 7.0);
			object fVertical = true;
			P_0.LeftPadding = app.PixelsToPoints(pixels, ref fVertical);
			Application app2 = App;
			float pixels2 = (float)Cfg.GetDouble("表格_单元格_右边距", 7.0);
			fVertical = true;
			P_0.RightPadding = app2.PixelsToPoints(pixels2, ref fVertical);
			Application app3 = App;
			fVertical = true;
			P_0.Spacing = app3.PixelsToPoints(0f, ref fVertical);
			P_0.AllowPageBreaks = true;
		}
		catch (Exception ex)
		{
			LogTableAdjustWarning("检查单元格边距配置", ex);
		}
	}

	private static void SetBorderStyles(Table P_0)
	{
		string[] array = new string[8]
		{
			"表格_边框样式_左侧框线",
			"表格_边框样式_右侧框线",
			"表格_边框样式_上侧框线",
			"表格_边框样式_底边框线",
			"表格_边框样式_横向框线",
			"表格_边框样式_纵向框线",
			"表格_边框样式_左上角开始的斜向边框线",
			"表格_边框样式_左下角开始的斜向边框线"
		};
		WdBorderType[] array2 = new WdBorderType[8]
		{
			WdBorderType.wdBorderLeft,
			WdBorderType.wdBorderRight,
			WdBorderType.wdBorderTop,
			WdBorderType.wdBorderBottom,
			WdBorderType.wdBorderHorizontal,
			WdBorderType.wdBorderVertical,
			WdBorderType.wdBorderDiagonalDown,
			WdBorderType.wdBorderDiagonalUp
		};
		for (int i = 0; i < array.Length; i++)
		{
			try
			{
				P_0.Borders[array2[i]].LineStyle = (WdLineStyle)Cfg.GetInt(array[i]);
			}
			catch (Exception ex)
			{
				LogTableAdjustWarning("检查边框样式配置: " + array[i], ex);
			}
		}
		string[] array3 = new string[6]
		{
			"表格_边框粗细_左侧框线",
			"表格_边框粗细_右侧框线",
			"表格_边框粗细_上侧框线",
			"表格_边框粗细_底边框线",
			"表格_边框粗细_横向框线",
			"表格_边框粗细_纵向框线"
		};
		for (int j = 0; j < array3.Length; j++)
		{
			if (Cfg.GetInt(array[j]) != 0)
			{
				try
				{
					P_0.Borders[array2[j]].LineWidth = (WdLineWidth)Cfg.GetInt(array3[j], 4);
				}
				catch (Exception ex2)
				{
					LogTableAdjustWarning("检查边框粗细配置: " + array3[j], ex2);
				}
			}
		}
	}

	private static void SetFirstColumnRightBorder(Table P_0)
	{
		int num = Cfg.GetInt("表格_边框样式_首列右边框线");
		if (num == 0)
		{
			return;
		}
		int lineWidth = Cfg.GetInt("表格_边框粗细_首列右边框线", 4);
		try
		{
			foreach (Cell cell in P_0.Range.Cells)
			{
				try
				{
					if (cell.ColumnIndex == 1)
					{
						cell.Borders[WdBorderType.wdBorderRight].LineStyle = (WdLineStyle)num;
						cell.Borders[WdBorderType.wdBorderRight].LineWidth = (WdLineWidth)lineWidth;
					}
				}
				catch (Exception ex)
				{
					LogTableAdjustWarning("检查首列右边框配置", ex);
				}
			}
		}
		catch (Exception ex2)
		{
			LogTableAdjustWarning("检查首列右边框配置", ex2);
		}
	}

	private static void SetRowProperties(Table P_0)
	{
		try
		{
			P_0.Rows.WrapAroundText = 0;
			P_0.Rows.AllowBreakAcrossPages = 0;
			P_0.Rows.Height = App.CentimetersToPoints((float)Cfg.GetDouble("表格_行_行高", 0.7));
			P_0.Rows.HeightRule = WdRowHeightRule.wdRowHeightAtLeast;
			P_0.Rows.LeftIndent = App.CentimetersToPoints(0f);
		}
		catch (Exception ex)
		{
			LogTableAdjustWarning("检查行高配置", ex);
		}
	}

	private static float GetFloatConfig(string P_0, double P_1)
	{
		return (float)AiHelper_20.GetConfigFontSize(Cfg.GetString(P_0, string.Empty), P_1);
	}

	private static void SetFontAndParagraphFormat(Table P_0)
	{
		try
		{
			Font font = P_0.Range.Font;
			font.NameFarEast = Cfg.GetString("表格_段落格式_中文字体", "宋体");
			font.NameAscii = Cfg.GetString("表格_段落格式_西文字体", "宋体");
			font.NameOther = Cfg.GetString("表格_段落格式_西文字体", "宋体");
			font.Size = GetFloatConfig("表格_段落格式_字号", 9.0);
			font.Kerning = 0f;
			font.DisableCharacterSpaceGrid = true;
		}
		catch (Exception ex)
		{
			LogTableAdjustWarning("检查字体配置", ex);
		}
		try
		{
			ParagraphFormat paragraphFormat = P_0.Range.ParagraphFormat;
			paragraphFormat.LineUnitBefore = 0f;
			paragraphFormat.LineUnitAfter = 0f;
			paragraphFormat.SpaceBefore = 0f;
			paragraphFormat.SpaceAfter = 0f;
			paragraphFormat.CharacterUnitFirstLineIndent = 0f;
			paragraphFormat.FirstLineIndent = App.CentimetersToPoints(0f);
			switch ((int)(paragraphFormat.LineSpacingRule = (WdLineSpacing)Cfg.GetInt("表格_段落格式_行距样式", 4)))
			{
			case 3:
			case 4:
				paragraphFormat.LineSpacing = (float)Cfg.GetDouble("表格_段落格式_行距值", 18.0);
				break;
			case 5:
				paragraphFormat.LineSpacing = App.LinesToPoints((float)Cfg.GetDouble("表格_段落格式_行距值", 1.0));
				break;
			}
			if (Cfg.GetString("表格_段落格式_段前距单位", "行") == "行")
			{
				paragraphFormat.SpaceBefore = 0f;
				paragraphFormat.SpaceAfter = 0f;
				paragraphFormat.LineUnitBefore = (float)Cfg.GetDouble("表格_段落格式_段前距");
				paragraphFormat.LineUnitAfter = (float)Cfg.GetDouble("表格_段落格式_段后距");
			}
			else
			{
				paragraphFormat.LineUnitBefore = 0f;
				paragraphFormat.LineUnitAfter = 0f;
				paragraphFormat.SpaceBefore = (float)Cfg.GetDouble("表格_段落格式_段前距");
				paragraphFormat.SpaceAfter = (float)Cfg.GetDouble("表格_段落格式_段后距");
			}
			paragraphFormat.AutoAdjustRightIndent = 0;
			paragraphFormat.DisableLineHeightGrid = -1;
			P_0.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
		}
		catch (Exception ex2)
		{
			LogTableAdjustWarning("检查段落格式配置", ex2);
		}
	}

	private static void ClassifyAndFormatCells(Table P_0)
	{
		HashSet<int> hashSet = FindSerialNumberColumns(P_0);
		Dictionary<int, bool> dictionary = FindTotalColumns(P_0);
		bool flag = GetInvertedBoolConfig("表格_合计小计处理_下划线包含文字", GetInvertedBoolConfig("表格_合计处理_下划线包含合计", false));
		bool flag2 = GetInvertedBoolConfig("表格_合计小计处理_加粗包含文字", GetInvertedBoolConfig("表格_合计处理_加粗包含合计", false));
		foreach (Cell cell in P_0.Range.Cells)
		{
			string text = (GetCellText(cell) ?? string.Empty).Trim();
			try
			{
				if (hashSet.Contains(cell.ColumnIndex))
				{
					cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
					cell.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
					continue;
				}
				bool value;
				bool flag3 = dictionary.TryGetValue(cell.ColumnIndex, out value);
				if (flag3 && cell.RowIndex == 1)
				{
					continue;
				}
				if (flag3)
				{
					ApplyColumnTotalStyle(cell, value);
				}
				bool flag4 = IsTotalText(text);
				bool flag5 = IsSubtotalText(text);
				bool flag6 = EndsWithTotal(text);
				bool flag7 = EndsWithSubtotal(text);
				if (flag4 || flag5)
				{
					SetCellAlignment(cell, "合计");
					if (cell.Next != null && cell.Next.RowIndex == cell.RowIndex)
					{
						ApplyTotalSubtotalRowFormat(P_0, cell, flag4);
					}
					ApplyTotalCellStyle(cell, flag4, flag, flag2);
					SetTotalSubtotalRowBorders(P_0, cell.RowIndex, flag4);
				}
				else if (flag6 || flag7)
				{
					ApplyTotalSubtotalRowFormat(P_0, cell, flag6);
					ApplyTotalCellStyle(cell, flag6, flag, flag2);
					SetTotalSubtotalRowBorders(P_0, cell.RowIndex, flag6);
				}
				else if (cell.ColumnIndex == 1)
				{
					SetCellAlignment(cell, "首列");
				}
				else if (IsNumericText(text))
				{
					SetCellAlignment(cell, "数字");
				}
				else
				{
					SetCellAlignment(cell, "文字");
				}
			}
			catch (Exception ex)
			{
				LogTableAdjustWarning("检查单元格分类格式", ex);
			}
		}
	}

	internal static void SyncTotalSubtotalFormat(Table P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		try
		{
			Dictionary<int, bool> dictionary = FindTotalColumns(P_0);
			bool flag = GetInvertedBoolConfig("表格_合计小计处理_下划线包含文字", GetInvertedBoolConfig("表格_合计处理_下划线包含合计", false));
			bool flag2 = GetInvertedBoolConfig("表格_合计小计处理_加粗包含文字", GetInvertedBoolConfig("表格_合计处理_加粗包含合计", false));
			foreach (Cell cell in P_0.Range.Cells)
			{
				try
				{
					string text = (GetCellText(cell) ?? string.Empty).Trim();
					bool value;
					bool flag3 = dictionary.TryGetValue(cell.ColumnIndex, out value);
					if (flag3 && cell.RowIndex == 1)
					{
						continue;
					}
					if (flag3)
					{
						ApplyColumnTotalStyle(cell, value);
					}
					bool flag4 = IsTotalText(text);
					bool flag5 = IsSubtotalText(text);
					bool flag6 = EndsWithTotal(text);
					bool flag7 = EndsWithSubtotal(text);
					if (flag4 || flag5)
					{
						SetCellAlignment(cell, "合计");
						if (cell.Next != null && cell.Next.RowIndex == cell.RowIndex)
						{
							ApplyTotalSubtotalRowFormat(P_0, cell, flag4);
						}
						ApplyTotalCellStyle(cell, flag4, flag, flag2);
						SetTotalSubtotalRowBorders(P_0, cell.RowIndex, flag4);
					}
					else if (flag6 || flag7)
					{
						ApplyTotalSubtotalRowFormat(P_0, cell, flag6);
						ApplyTotalCellStyle(cell, flag6, flag, flag2);
						SetTotalSubtotalRowBorders(P_0, cell.RowIndex, flag6);
					}
				}
				catch (Exception ex)
				{
					LogTableAdjustWarning("同步后合计/小计格式处理", ex);
				}
			}
		}
		catch (Exception ex2)
		{
			LogTableAdjustWarning("同步后应用合计/小计格式", ex2);
		}
	}

	private static HashSet<int> FindSerialNumberColumns(Table P_0)
	{
		HashSet<int> hashSet = new HashSet<int>();
		if (!GetInvertedBoolConfig("表格_段落格式_序号列居中", false))
		{
			return hashSet;
		}
		try
		{
			Regex regex = new Regex("^\\s*序\\s*号\\s*$");
			foreach (Cell cell in P_0.Range.Cells)
			{
				if (cell.RowIndex <= 1)
				{
					if (regex.IsMatch(GetCellText(cell).Trim()))
					{
						hashSet.Add(cell.ColumnIndex);
					}
					continue;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			LogTableAdjustWarning("检查序号列识别", ex);
		}
		return hashSet;
	}

	private static Dictionary<int, bool> FindTotalColumns(Table P_0)
	{
		Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
		try
		{
			foreach (Cell cell in P_0.Range.Cells)
			{
				if (cell.RowIndex <= 1)
				{
					string text = GetCellText(cell).Trim();
					bool flag = IsTotalText(text) || EndsWithTotal(text);
					bool flag2 = IsSubtotalText(text) || EndsWithSubtotal(text);
					if (flag || flag2)
					{
						dictionary[cell.ColumnIndex] = flag;
					}
					continue;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			LogTableAdjustWarning("检查合计列识别", ex);
		}
		return dictionary;
	}

	private static void FormatHeaderRow(Table P_0)
	{
		try
		{
			if (P_0.Rows.Count >= 1)
			{
				Range range = GetHeaderRowRange(P_0);
				range.Rows.HeadingFormat = -1;
				range.ParagraphFormat.Alignment = (WdParagraphAlignment)Cfg.GetInt("表格_段落格式_首行水平对齐", 1);
				range.Cells.VerticalAlignment = (WdCellVerticalAlignment)Cfg.GetInt("表格_段落格式_首行垂直对齐", 1);
				range.Font.Bold = Cfg.GetInt("表格_段落格式_加粗", 1);
				range.Borders[WdBorderType.wdBorderBottom].LineStyle = (WdLineStyle)Cfg.GetInt("表格_边框样式_表头底边框线", 1);
				range.Borders[WdBorderType.wdBorderBottom].LineWidth = (WdLineWidth)Cfg.GetInt("表格_边框粗细_表头底边框线", 4);
				range.Shading.ForegroundPatternColor = WdColor.wdColorAutomatic;
				range.Shading.BackgroundPatternColor = (WdColor)Cfg.GetInt("表格_单元格_底色", -16777216);
				ApplyFirstColumnPriority(P_0);
			}
		}
		catch (Exception ex)
		{
			LogTableAdjustWarning("检查首行格式配置", ex);
		}
	}

	private static Range GetHeaderRowRange(Table P_0)
	{
		try
		{
			P_0.Cell(1, 1).Select();
			App.Selection.SelectRow();
			return App.Selection.Range.Duplicate;
		}
		catch
		{
			return P_0.Rows[1].Range;
		}
	}

	private static void ApplyFirstColumnPriority(Table P_0)
	{
		if (!string.Equals(Cfg.GetString("表格_段落格式_首行首列冲突优先级", "首行"), "首列", StringComparison.Ordinal))
		{
			return;
		}
		foreach (Cell cell in P_0.Range.Cells)
		{
			try
			{
				if (cell.RowIndex == 1 && cell.ColumnIndex == 1)
				{
					SetCellAlignment(cell, "首列");
				}
			}
			catch (Exception ex)
			{
				LogTableAdjustWarning("检查首行首列对齐优先级", ex);
			}
		}
	}

	public static void AdjustTableWidth()
	{
		Cfg.SaveToFile();
		if (App.Selection.Tables.Count == 0)
		{
			LoggerInitializer.ShowInfo("请将光标放在表格内", "IP_Assurance");
		}
		else
		{
			SetFixedWidth(App.Selection.Tables[1]);
		}
	}

	public static void AutoFitSelectedTables()
	{
		Cfg.SaveToFile();
		if (App.Selection.Tables.Count == 0)
		{
			return;
		}
		foreach (Table table in App.Selection.Tables)
		{
			ApplyWidthMode(table);
		}
	}

	private static void ApplyWidthMode(Table P_0)
	{
		if (IsCustomWidthMode())
		{
			SetFixedWidth(P_0);
		}
		else
		{
			AutoFitToWindow(P_0);
		}
	}

	private static void AutoFitToWindow(Table P_0)
	{
		P_0.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);
	}

	private static void SetFixedWidth(Table P_0)
	{
		P_0.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitFixed);
		P_0.PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPoints;
		P_0.PreferredWidth = GetTableWidthInPoints();
		P_0.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
	}

	private static bool IsCustomWidthMode()
	{
		return string.Equals(Cfg.GetString("表格_宽度模式", "自适应宽度").Trim(), "自定义宽度", StringComparison.Ordinal);
	}

	private static float GetTableWidthInPoints()
	{
		double num = Cfg.GetDouble("表格_最大列宽_宽度", 18.5);
		if (num <= 0.0)
		{
			num = 18.5;
		}
		return App.CentimetersToPoints((float)num);
	}

	public static void AlignColumnWidths()
	{
		try
		{
			Tables tables = App.Selection.Tables;
			int count = tables.Count;
			if (count < 2)
			{
				LoggerInitializer.ShowInfo("请选择大于一个表", "IP_Assurance");
				return;
			}
			List<float> list = new List<float>();
			Table table = tables[1];
			table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitFixed);
			int num = 2;
			try
			{
				table.Cell(1, 1).Select();
				App.Selection.SelectRow();
				int num2 = (dynamic)App.Selection.get_Information(WdInformation.wdEndOfRangeRowNumber);
				int num3 = (dynamic)App.Selection.get_Information(WdInformation.wdStartOfRangeRowNumber);
				num = num2 - num3 + 2;
			}
			catch
			{
			}
			if (num != 2)
			{
				LoggerInitializer.ShowInfo("当前无法处理表头中有纵向合并单元格的表格", "IP_Assurance");
				return;
			}
			for (int i = 1; i <= table.Columns.Count; i++)
			{
				list.Add(table.Columns[i].Width);
			}
			for (int j = 2; j <= count; j++)
			{
				Table table2 = tables[j];
				int num4 = Math.Min(table2.Columns.Count, list.Count);
				for (int k = 1; k <= num4; k++)
				{
					table2.Columns[k].Width = list[k - 1];
				}
			}
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError(ex.Message, "IP_Assurance");
		}
	}

	public static void SetHeaderRowRepeat()
	{
		if (App.Selection.Tables.Count != 0)
		{
			App.Selection.Tables[1].Cell(1, 1).Select();
			App.Selection.SelectRow();
			App.Selection.Rows.HeadingFormat = 9999998;
		}
	}

	public static void SelectAllTables()
	{
		Document activeDocument = App.ActiveDocument;
		try
		{
			if (activeDocument.ProtectionType == WdProtectionType.wdAllowOnlyFormFields)
			{
				LoggerInitializer.ShowInfo("文档已保护，此时不能选中多个表格！", "IP_Assurance");
				return;
			}
			ClearSavedTableRanges();
			_selectedDocumentName = GetDocumentName(activeDocument);
			object EditorID = WdEditorType.wdEditorEveryone;
			activeDocument.DeleteAllEditableRanges(ref EditorID);
			foreach (Table table in activeDocument.Tables)
			{
				Editors editors = table.Range.Editors;
				EditorID = WdEditorType.wdEditorEveryone;
				editors.Add(ref EditorID);
				_tableRanges.Add(new TableRange(table.Range.Start, table.Range.End));
			}
			EditorID = WdEditorType.wdEditorEveryone;
			activeDocument.SelectAllEditableRanges(ref EditorID);
			EditorID = WdEditorType.wdEditorEveryone;
			activeDocument.DeleteAllEditableRanges(ref EditorID);
			LoggerInitializer.ShowInfo(string.Format("已选中 {0} 个表格。", _tableRanges.Count), "IP_Assurance");
		}
		finally
		{
			try
			{
				object EditorID = WdEditorType.wdEditorEveryone;
				activeDocument.DeleteAllEditableRanges(ref EditorID);
			}
			catch
			{
			}
		}
	}

	private static IEnumerable<Table> EnumerateTablesByRanges(Document P_0)
	{
		object Start = Type.Missing;
		object End = Type.Missing;
		int documentEnd = P_0.Range(ref Start, ref End).End;
		foreach (TableRange item in _tableRanges)
		{
			if (item.Start >= 0 && item.End > item.Start && item.End <= documentEnd)
			{
				End = item.Start;
				Start = item.End;
				Range range = P_0.Range(ref End, ref Start);
				if (range.Tables.Count > 0)
				{
					yield return range.Tables[1];
				}
			}
		}
	}

	private static bool IsSelectionValid(Document P_0)
	{
		if (_tableRanges.Count == 0)
		{
			return false;
		}
		return string.Equals(_selectedDocumentName, GetDocumentName(P_0), StringComparison.Ordinal);
	}

	private static void ClearSavedTableRanges()
	{
		_tableRanges.Clear();
		_selectedDocumentName = string.Empty;
	}

	private static void CollapseSelectionToStart()
	{
		try
		{
			int start = App.Selection.Range.Start;
			App.Selection.SetRange(start, start);
		}
		catch
		{
			try
			{
				Selection selection = App.Selection;
				object Direction = WdCollapseDirection.wdCollapseStart;
				selection.Collapse(ref Direction);
			}
			catch
			{
			}
		}
	}

	private static string GetDocumentName(Document P_0)
	{
		try
		{
			return P_0.FullName ?? string.Empty;
		}
		catch
		{
		}
		try
		{
			return P_0.Name ?? string.Empty;
		}
		catch
		{
		}
		return string.Empty;
	}

	private static void SetCellAlignment(Cell P_0, string P_1)
	{
		P_0.Range.ParagraphFormat.Alignment = (WdParagraphAlignment)Cfg.GetInt("表格_段落格式_" + P_1 + "水平对齐", (!(P_1 == "数字")) ? 1 : 2);
		P_0.Range.Cells.VerticalAlignment = (WdCellVerticalAlignment)Cfg.GetInt("表格_段落格式_" + P_1 + "垂直对齐", 1);
	}

	private static void ApplyTotalSubtotalRowFormat(Table P_0, Cell P_1, bool P_2)
	{
		int underline = Cfg.GetInt(P_2 ? "表格_小计处理_下划线" : "表格_合计处理_下划线", (!P_2) ? 1 : 3);
		int bold = Cfg.GetInt(P_2 ? "表格_小计处理_加粗" : "表格_合计处理_加粗");
		try
		{
			bool flag = false;
			foreach (Cell cell in P_0.Rows[P_1.RowIndex].Cells)
			{
				if (cell.Range.Start == P_1.Range.Start)
				{
					flag = true;
				}
				else if (flag)
				{
					cell.Range.Font.Underline = (WdUnderline)underline;
					cell.Range.Font.Bold = bold;
				}
			}
		}
		catch
		{
			try
			{
				Cell next = P_1.Next;
				int rowIndex = P_1.RowIndex;
				while (next != null && next.RowIndex <= rowIndex)
				{
					if (next.RowIndex == rowIndex)
					{
						next.Range.Font.Underline = (WdUnderline)underline;
						next.Range.Font.Bold = bold;
					}
					next = next.Next;
				}
			}
			catch
			{
			}
		}
	}

	private static void SetTotalSubtotalRowBorders(Table P_0, int P_1, bool P_2)
	{
		SetRowBorder(P_0, P_1, P_2, "上边框线", WdBorderType.wdBorderTop);
		SetRowBorder(P_0, P_1, P_2, "下边框线", WdBorderType.wdBorderBottom);
	}

	private static void SetRowBorder(Table P_0, int P_1, bool P_2, string P_3, WdBorderType P_4)
	{
		string text = (P_2 ? "小计行" : "合计行") + P_3;
		int num = Cfg.GetInt("表格_边框样式_" + text);
		if (num == 0)
		{
			return;
		}
		int lineWidth = Cfg.GetInt("表格_边框粗细_" + text, 4);
		try
		{
			Row row = P_0.Rows[P_1];
			row.Borders[P_4].LineStyle = (WdLineStyle)num;
			row.Borders[P_4].LineWidth = (WdLineWidth)lineWidth;
		}
		catch
		{
			try
			{
				foreach (Cell cell in P_0.Range.Cells)
				{
					if (cell.RowIndex == P_1)
					{
						cell.Borders[P_4].LineStyle = (WdLineStyle)num;
						cell.Borders[P_4].LineWidth = (WdLineWidth)lineWidth;
					}
				}
			}
			catch (Exception ex)
			{
				LogTableAdjustWarning("检查合计/小计行边框配置: " + text, ex);
			}
		}
	}

	private static void ApplyTotalCellStyle(Cell P_0, bool P_1, bool P_2, bool P_3)
	{
		int num = Cfg.GetInt(P_1 ? "表格_小计处理_下划线" : "表格_合计处理_下划线", (!P_1) ? 1 : 3);
		int num2 = Cfg.GetInt(P_1 ? "表格_小计处理_加粗" : "表格_合计处理_加粗");
		P_0.Range.Font.Underline = (P_2 ? ((WdUnderline)num) : WdUnderline.wdUnderlineNone);
		P_0.Range.Font.Bold = (P_3 ? num2 : 0);
	}

	private static void ApplyColumnTotalStyle(Cell P_0, bool P_1)
	{
		int underline = Cfg.GetInt(P_1 ? "表格_小计处理_下划线" : "表格_合计处理_下划线", (!P_1) ? 1 : 3);
		int bold = Cfg.GetInt(P_1 ? "表格_小计处理_加粗" : "表格_合计处理_加粗");
		P_0.Range.Font.Underline = (WdUnderline)underline;
		P_0.Range.Font.Bold = bold;
	}

	private static string GetCellText(Cell P_0)
	{
		try
		{
			Document activeDocument = App.ActiveDocument;
			object Start = P_0.Range.Start;
			object End = P_0.Range.End - 1;
			return activeDocument.Range(ref Start, ref End).Text ?? string.Empty;
		}
		catch
		{
			return (P_0.Range.Text ?? string.Empty).Trim('\r', '\a', '\a');
		}
	}

	private static bool IsTotalText(string P_0)
	{
		string text = RemoveWhitespace(P_0);
		if (!(text == "合计"))
		{
			return text == "总计";
		}
		return true;
	}

	private static bool IsSubtotalText(string P_0)
	{
		return RemoveWhitespace(P_0) == "小计";
	}

	private static bool EndsWithTotal(string P_0)
	{
		string text = RemoveWhitespace(P_0);
		if (text.Length > 2)
		{
			return text.EndsWith("合计", StringComparison.Ordinal);
		}
		return false;
	}

	private static bool EndsWithSubtotal(string P_0)
	{
		string text = RemoveWhitespace(P_0);
		if (text.Length > 2)
		{
			return text.EndsWith("小计", StringComparison.Ordinal);
		}
		return false;
	}

	private static string RemoveWhitespace(string P_0)
	{
		return Regex.Replace(P_0 ?? string.Empty, "\\s+", string.Empty);
	}

	private static bool IsNumericText(string P_0)
	{
		if (P_0 == "-")
		{
			return true;
		}
		if (Regex.IsMatch(P_0, "^\\d+(\\.\\d+)?%$"))
		{
			return true;
		}
		string s = P_0.Replace(",", string.Empty).Replace("%", string.Empty).Replace("(", "-")
			.Replace(")", string.Empty)
			.Replace("（", "-")
			.Replace("）", string.Empty);
		if (!double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
		{
			return double.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out result);
		}
		return true;
	}

	private static bool GetInvertedBoolConfig(string P_0, bool P_1)
	{
		string text = Cfg.GetString(P_0, P_1 ? "0" : "1");
		if (!(text == "1"))
		{
			return text.Equals("true", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static ProgressWindow CreateProgressWindow()
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

	private static bool UpdateProgress(ProgressWindow P_0, int P_1, int P_2)
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

	private static void CloseProgressWindow(ProgressWindow P_0)
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

	private static void LogTableAdjustWarning(string P_0, Exception P_1)
	{
		AiConfigBootstrap.LogWarn("[Tables] " + P_0 + " | " + P_1.Message);
	}

	static BatchTableAdjustService()
	{
		SseStreamInitializer.InitializeRuntime();
		_tableRanges = new List<TableRange>();
		_selectedDocumentName = string.Empty;
	}
}
