using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Threading;
using CPAHelperForWordRe.UI.Forms;
using WordTableToolService5;
using AiSseStreamService3;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using WordTableToolService;
using ExcelInteropService;
using LoggerInitializer;

namespace TableValidationService;

internal static class TableValidationService
{
	[CompilerGenerated]
	private static class _G_o__10
	{
		public static CallSite<Func<CallSite, Sheets, object, object>> sheetsAddCallSite;

		public static CallSite<Func<CallSite, object, Worksheet>> toWorksheetCallSite;
	}

	[CompilerGenerated]
	private static class _G_o__11
	{
		public static CallSite<Func<CallSite, object, object>> endMemberCallSite;

		public static CallSite<Func<CallSite, object, int, object>> intIndexerCallSite;

		public static CallSite<Func<CallSite, object, object>> rowMemberCallSite;

		public static CallSite<Func<CallSite, object, int>> toIntCallSite;

		public static CallSite<Func<CallSite, object, object>> valueMemberCallSite;

		public static CallSite<Func<CallSite, Type, object, object>> convertToStringCallSite;

		public static CallSite<Func<CallSite, object, string>> stringMemberCallSite;
	}

	[CompilerGenerated]
	private static class _G_o__15
	{
		public static CallSite<Func<CallSite, Type, object, object>> convertCallSite;

		public static CallSite<object> dynamicInvokeCallSite;

		public static CallSite<Func<CallSite, object, bool>> boolMemberCallSite;
	}

	[CompilerGenerated]
	private static class _G_o__5
	{
		public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> toRangeCallSite1;

		public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> toRangeCallSite2;

		public static CallSite<Func<CallSite, Type, object, object>> convertToStringCallSite1;

		public static CallSite<Func<CallSite, object, string, object>> setStringMemberCallSite1;

		public static CallSite<Func<CallSite, object, bool>> boolMemberCallSite1;

		public static CallSite<Func<CallSite, object, object>> valueGetCallSite;

		public static CallSite<Func<CallSite, Type, object, object>> convertToStringCallSite2;

		public static CallSite<Func<CallSite, object, string, object>> setStringMemberCallSite2;

		public static CallSite<Func<CallSite, object, bool>> boolMemberCallSite2;

		public static CallSite<Func<CallSite, object, string, object>> valueSetCallSite;
	}

	private static Microsoft.Office.Interop.Word.Application App => WordTableToolService.WordApp;

	public static void ValidateByRow()
	{
		ExportTablesAndValidate( true);
	}

	public static void ValidateByColumn()
	{
		ExportTablesAndValidate( false);
	}

	private static void ExportTablesAndValidate(bool P_0)
	{
		Microsoft.Office.Interop.Excel.Application application = ExcelInteropService.GetOrCreateExcelApp();
		if (application == null)
		{
			LoggerInitializer.ShowError("无法启动 Excel/WPS 表格。", "IP_Assurance");
			return;
		}
		application.Visible = true;
		Tables tables = App.Selection.Tables;
		if (tables.Count == 0)
		{
			LoggerInitializer.ShowWarning("No tables selected.", "IP_Assurance");
			return;
		}
		Worksheet worksheet = GetOrAddWorksheet(application.ActiveWorkbook ?? application.Workbooks.Add(Type.Missing), "Word表格校验");
		int num = FindNextEmptyRow(worksheet);
		ProgressWindow progressWindow = null;
		try
		{
			int count = tables.Count;
			int num2 = 0;
			progressWindow = CreateProgressWindow();
			foreach (Table item in tables)
			{
				num2++;
				item.Select();
				App.Selection.Copy();
				PasteWithRetry(worksheet, num);
				int count2 = item.Rows.Count;
				int count3 = item.Columns.Count;
				Microsoft.Office.Interop.Excel.Range cell = (dynamic)worksheet.Cells[num, 1];
				Microsoft.Office.Interop.Excel.Range cell2 = (dynamic)worksheet.Cells[count2 + num - 1, count3];
				Microsoft.Office.Interop.Excel.Range range = ((_Worksheet)worksheet).get_Range((object)cell, (object)cell2);
				if (_G_o__5.convertToStringCallSite1 == null)
				{
					_G_o__5.convertToStringCallSite1 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(TableValidationService), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				if ((dynamic)_G_o__5.convertToStringCallSite1.Target(_G_o__5.convertToStringCallSite1, typeof(Convert), ((_Worksheet)worksheet).get_Range((object)("A" + (count2 + num - 1)), Type.Missing).get_Value(Type.Missing)) == string.Empty)
				{
					((_Worksheet)worksheet).get_Range((object)("A" + (count2 + num - 1)), Type.Missing).set_Value(Type.Missing, (object)" ");
				}
				if (_G_o__5.convertToStringCallSite2 == null)
				{
					_G_o__5.convertToStringCallSite2 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(TableValidationService), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, Type, object, object> target = _G_o__5.convertToStringCallSite2.Target;
				CallSite<Func<CallSite, Type, object, object>> toStringSite = _G_o__5.convertToStringCallSite2;
				Type typeFromHandle = typeof(Convert);
				if (_G_o__5.valueGetCallSite == null)
				{
					_G_o__5.valueGetCallSite = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value", typeof(TableValidationService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				if ((dynamic)target(toStringSite, typeFromHandle, _G_o__5.valueGetCallSite.Target(_G_o__5.valueGetCallSite, worksheet.Cells[count2 + num - 1, count3])) == string.Empty)
				{
					if (_G_o__5.valueSetCallSite == null)
					{
						_G_o__5.valueSetCallSite = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Value", typeof(TableValidationService), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					_G_o__5.valueSetCallSite.Target(_G_o__5.valueSetCallSite, worksheet.Cells[count2 + num - 1, count3], " ");
				}
				int num3 = range.Row + range.Rows.Count - 1;
				int count4 = range.Columns.Count;
				if (P_0)
				{
					AddRowSumChecks(worksheet, num, num3, count4);
				}
				else
				{
					AddColumnSumChecks(worksheet, num, num3, count4);
				}
				try
				{
					range.get_Offset((object)1, Type.Missing).get_Resize((object)range.Rows.Count, (object)(range.Columns.Count + 1)).Style = "Comma";
				}
				catch
				{
				}
				num = num3 + 3;
				if (!UpdateProgress(progressWindow, num2, count))
				{
					break;
				}
			}
			try
			{
				((_Worksheet)worksheet).get_Range((object)("A" + num), Type.Missing).Select();
			}
			catch
			{
			}
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError(ex.ToString(), "IP_Assurance");
		}
		finally
		{
			CloseProgressWindow(progressWindow);
			App.ScreenUpdating = true;
		}
	}

	public static void SumSelectedCells()
	{
		try
		{
			double num = 0.0;
			Selection selection = App.Selection;
			string text2;
			if (selection.Type == WdSelectionType.wdSelectionRow || selection.Type == WdSelectionType.wdSelectionColumn)
			{
				foreach (Cell cell in selection.Cells)
				{
					string text = GetCellText(cell);
					double num3;
					if (text.EndsWith("%", StringComparison.Ordinal))
					{
						if (TryParseNumber(text.Substring(0, text.Length - 1), out var num2))
						{
							num += num2 / 100.0;
						}
					}
					else if (TryParseNumber(text, out num3))
					{
						num += num3;
					}
				}
				text2 = "合计:" + num.ToString("#,##0.00;-#,##0.00; ", CultureInfo.CurrentCulture);
			}
			else
			{
				text2 = "只支持表格内行或列求和!";
			}
			if (WordTableToolService.IsWps)
			{
				LoggerInitializer.ShowInfo(text2 + "  可直接粘贴", "IP_Assurance");
			}
			App.StatusBar = text2 + "可直接粘贴";
			Clipboard.SetText(num.ToString("#,##0.00;-#,##0.00; ", CultureInfo.CurrentCulture));
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError(ex.ToString(), "IP_Assurance");
		}
		finally
		{
			App.ScreenUpdating = true;
		}
	}

	public static void CleanDocument()
	{
		WdAlertLevel displayAlerts = App.DisplayAlerts;
		App.ScreenUpdating = false;
		App.DisplayAlerts = WdAlertLevel.wdAlertsNone;
		try
		{
			Document activeDocument = App.ActiveDocument;
			try
			{
				activeDocument.AcceptAllRevisions();
			}
			catch
			{
			}
			try
			{
				activeDocument.TrackRevisions = false;
			}
			catch
			{
			}
			foreach (Comment comment in activeDocument.Comments)
			{
				try
				{
					comment.DeleteRecursively();
				}
				catch
				{
					try
					{
						comment.Delete();
					}
					catch
					{
					}
				}
			}
			try
			{
				activeDocument.TablesOfContents[1].UpdatePageNumbers();
			}
			catch
			{
			}
			activeDocument.Content.HighlightColorIndex = WdColorIndex.wdAuto;
			activeDocument.Content.Font.ColorIndex = WdColorIndex.wdBlack;
			App.Selection.WholeStory();
			App.Selection.Fields.Locked = 0;
			foreach (Field field in App.Selection.Fields)
			{
				try
				{
					if (IsLinkField(field))
					{
						field.Unlink();
					}
				}
				catch
				{
				}
			}
		}
		finally
		{
			App.DisplayAlerts = displayAlerts;
			App.ScreenUpdating = true;
		}
	}

	private static bool IsLinkField(Field P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		WdFieldType type;
		try
		{
			type = P_0.Type;
		}
		catch
		{
			return false;
		}
		switch (type)
		{
		case WdFieldType.wdFieldRefDoc:
		case WdFieldType.wdFieldInclude:
		case WdFieldType.wdFieldDDE:
		case WdFieldType.wdFieldDDEAuto:
		case WdFieldType.wdFieldImport:
		case WdFieldType.wdFieldLink:
		case WdFieldType.wdFieldIncludePicture:
		case WdFieldType.wdFieldIncludeText:
		case WdFieldType.wdFieldDatabase:
		case WdFieldType.wdFieldHyperlink:
			return true;
		default:
			return false;
		}
	}

	public static void ExportCommentsToExcel()
	{
		Microsoft.Office.Interop.Excel.Application application = ExcelInteropService.GetOrCreateExcelApp();
		if (application == null)
		{
			LoggerInitializer.ShowError("无法启动 Excel/WPS 表格。", "IP_Assurance");
			return;
		}
		application.Visible = true;
		Worksheet worksheet = GetOrAddWorksheet(application.ActiveWorkbook ?? application.Workbooks.Add(Type.Missing), "Word批注导出");
		Document activeDocument = App.ActiveDocument;
		ProgressWindow progressWindow = null;
		try
		{
			worksheet.Cells.Clear();
			object[,] array = new object[1, 5] { 
			{
				"文件路径",
				"原文内容",
				"批注内容",
				"页码",
				"在文档中的位置"
			} };
			((_Worksheet)worksheet).get_Range((object)"A1", (object)"E1").set_Value(Type.Missing, (object)array);
			int count = activeDocument.Comments.Count;
			int num = 2;
			int num2 = 0;
			progressWindow = CreateProgressWindow();
			foreach (Comment comment in activeDocument.Comments)
			{
				num2++;
				worksheet.Cells[num, 1] = activeDocument.Path + "\\\\" + activeDocument.Name;
				try
				{
					worksheet.Cells[num, 2] = comment.Scope.Text;
				}
				catch
				{
				}
				try
				{
					worksheet.Cells[num, 3] = comment.Range.Text;
				}
				catch
				{
				}
				try
				{
					worksheet.Cells[num, 4] = comment.Reference.get_Information(WdInformation.wdActiveEndPageNumber);
				}
				catch
				{
				}
				try
				{
					worksheet.Cells[num, 5] = comment.Scope.Start;
				}
				catch
				{
				}
				num++;
				if (!UpdateProgress(progressWindow, num2, count))
				{
					break;
				}
			}
			try
			{
				worksheet.Columns.AutoFit();
			}
			catch
			{
			}
		}
		catch (Exception ex)
		{
			LoggerInitializer.ShowError(ex.ToString(), "IP_Assurance");
		}
		finally
		{
			CloseProgressWindow(progressWindow);
			App.ScreenUpdating = true;
		}
	}

	private static Worksheet GetOrAddWorksheet(Workbook P_0, string P_1)
	{
		foreach (Worksheet worksheet in P_0.Worksheets)
		{
			if (string.Equals(worksheet.Name, P_1, StringComparison.OrdinalIgnoreCase))
			{
				return worksheet;
			}
		}
		if (_G_o__10.sheetsAddCallSite == null)
		{
			_G_o__10.sheetsAddCallSite = CallSite<Func<CallSite, Sheets, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Add", null, typeof(TableValidationService), new CSharpArgumentInfo[2]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.NamedArgument, "After")
			}));
		}
		Worksheet obj = (Worksheet)(dynamic)_G_o__10.sheetsAddCallSite.Target(_G_o__10.sheetsAddCallSite, P_0.Worksheets, P_0.Sheets[P_0.Sheets.Count]);
		obj.Name = P_1;
		return obj;
	}

	private static int FindNextEmptyRow(Worksheet P_0)
	{
		if (_G_o__11.rowMemberCallSite == null)
		{
			_G_o__11.rowMemberCallSite = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Row", typeof(TableValidationService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
		}
		Func<CallSite, object, object> target = _G_o__11.rowMemberCallSite.Target;
		CallSite<Func<CallSite, object, object>> rowCallSite = _G_o__11.rowMemberCallSite;
		if (_G_o__11.endMemberCallSite == null)
		{
			_G_o__11.endMemberCallSite = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "End", typeof(TableValidationService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
		}
		int num = (dynamic)target(rowCallSite, (object)((dynamic)_G_o__11.endMemberCallSite.Target(_G_o__11.endMemberCallSite, P_0.Cells[P_0.Rows.Count, 1]))[-4162]);
		if (_G_o__11.convertToStringCallSite == null)
		{
			_G_o__11.convertToStringCallSite = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(TableValidationService), new CSharpArgumentInfo[2]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		Func<CallSite, Type, object, object> target2 = _G_o__11.convertToStringCallSite.Target;
		CallSite<Func<CallSite, Type, object, object>> toStringSite2 = _G_o__11.convertToStringCallSite;
		Type typeFromHandle = typeof(Convert);
		if (_G_o__11.valueMemberCallSite == null)
		{
			_G_o__11.valueMemberCallSite = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value", typeof(TableValidationService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
		}
		string value = (dynamic)target2(toStringSite2, typeFromHandle, _G_o__11.valueMemberCallSite.Target(_G_o__11.valueMemberCallSite, P_0.Cells[1, 1]));
		if (num == 1 && string.IsNullOrEmpty(value))
		{
			return 1;
		}
		if (num != 1)
		{
			return num + 3;
		}
		return 1;
	}

	private static void PasteWithRetry(Worksheet P_0, int P_1)
	{
		int num = 0;
		while (true)
		{
			try
			{
				P_0.Paste(((_Worksheet)P_0).get_Range((object)("A" + P_1), Type.Missing), Type.Missing);
				break;
			}
			catch
			{
				num++;
				if (num >= 3)
				{
					throw;
				}
			}
		}
	}

	private static void AddRowSumChecks(Worksheet P_0, int P_1, int P_2, int P_3)
	{
		for (int i = P_1; i <= P_2; i++)
		{
			Microsoft.Office.Interop.Excel.Range obj = (dynamic)P_0.Cells[i, P_3 + 1];
			obj.FormulaR1C1 = "=IFERROR(RC[-1]-SUM(RC[" + -P_3 + "]:RC[-2]),\"\")";
			ColorCheckCell(obj);
		}
	}

	private static void AddColumnSumChecks(Worksheet P_0, int P_1, int P_2, int P_3)
	{
		for (int i = 1; i <= P_3; i++)
		{
			Microsoft.Office.Interop.Excel.Range obj = (dynamic)P_0.Cells[P_2 + 1, i];
			obj.FormulaR1C1 = "=IFERROR(R[-1]C-SUM(R[" + -(P_2 - P_1) + "]C:R[-2]C),\"\")";
			ColorCheckCell(obj);
		}
	}

	private static void ColorCheckCell(Microsoft.Office.Interop.Excel.Range P_0)
	{
		try
		{
			double arg = default(double);
			object cellValue = P_0.get_Value(Type.Missing);
			if (double.TryParse(cellValue?.ToString(), out arg))
			{
				P_0.Interior.Color = ((Math.Abs(arg) > 0.001) ? 255 : 5296274);
			}
		}
		catch
		{
		}
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

	private static bool TryParseNumber(string P_0, out double P_1)
	{
		string s = (P_0 ?? string.Empty).Trim().Trim('\r', '\a', '\a').Replace(",", string.Empty);
		if (!double.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out P_1))
		{
			return double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out P_1);
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
}
