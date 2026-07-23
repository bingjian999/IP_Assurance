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
		public static CallSite<Func<CallSite, Sheets, object, object>> yWZVTsqLW75;

		public static CallSite<Func<CallSite, object, Worksheet>> RlgVTlEOwEs;
	}

	[CompilerGenerated]
	private static class _G_o__11
	{
		public static CallSite<Func<CallSite, object, object>> MTDVTNjq95L;

		public static CallSite<Func<CallSite, object, int, object>> LUZVTmenb1g;

		public static CallSite<Func<CallSite, object, object>> SUFVTov2Kyj;

		public static CallSite<Func<CallSite, object, int>> MANVTGBRPuO;

		public static CallSite<Func<CallSite, object, object>> jtZVTCjwVp8;

		public static CallSite<Func<CallSite, Type, object, object>> rmjVTpISiO9;

		public static CallSite<Func<CallSite, object, string>> lwmVTONYYud;
	}

	[CompilerGenerated]
	private static class _G_o__15
	{
		public static CallSite<Func<CallSite, Type, object, object>> vVBVT5nYc16;

		public static CallSite<object> d3GVTctkt06;

		public static CallSite<Func<CallSite, object, bool>> WI6VTebksbB;
	}

	[CompilerGenerated]
	private static class _G_o__5
	{
		public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> epxVTyCnHjF;

		public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> UR6VTXS4LNO;

		public static CallSite<Func<CallSite, Type, object, object>> tLZVTFA6XNG;

		public static CallSite<Func<CallSite, object, string, object>> kp2VThDv5jD;

		public static CallSite<Func<CallSite, object, bool>> BIVVTabJpX9;

		public static CallSite<Func<CallSite, object, object>> gXmVTq4CdC4;

		public static CallSite<Func<CallSite, Type, object, object>> Y9xVTPOsWB8;

		public static CallSite<Func<CallSite, object, string, object>> zRHVTABsAY5;

		public static CallSite<Func<CallSite, object, bool>> r3vVTvCbUY3;

		public static CallSite<Func<CallSite, object, string, object>> B4NVTW744L1;
	}

	private static Microsoft.Office.Interop.Word.Application App => WordTableToolService.WordApp;

	public static void vG5KQkPQxL()
	{
		L3OKrbE2FM( true);
	}

	public static void aguK1H8YCQ()
	{
		L3OKrbE2FM( false);
	}

	private static void L3OKrbE2FM(bool P_0)
	{
		Microsoft.Office.Interop.Excel.Application application = ExcelInteropService.gM4XBr1Rq();
		if (application == null)
		{
			LoggerInitializer.F9Ycoqv2I8("无法启动 Excel/WPS 表格。", "IP_Assurance");
			return;
		}
		application.Visible = true;
		Tables tables = App.Selection.Tables;
		if (tables.Count == 0)
		{
			LoggerInitializer.u0kcmnykTv("No tables selected.", "IP_Assurance");
			return;
		}
		Worksheet worksheet = yekKEcMdXi(application.ActiveWorkbook ?? application.Workbooks.Add(Type.Missing), "Word表格校验");
		int num = YV1K26qhk7(worksheet);
		ProgressWindow progressWindow = null;
		try
		{
			int count = tables.Count;
			int num2 = 0;
			progressWindow = kreKbuS50W();
			foreach (Table item in tables)
			{
				num2++;
				item.Select();
				App.Selection.Copy();
				OS9K47eF2M(worksheet, num);
				int count2 = item.Rows.Count;
				int count3 = item.Columns.Count;
				Microsoft.Office.Interop.Excel.Range cell = (dynamic)worksheet.Cells[num, 1];
				Microsoft.Office.Interop.Excel.Range cell2 = (dynamic)worksheet.Cells[count2 + num - 1, count3];
				Microsoft.Office.Interop.Excel.Range range = ((_Worksheet)worksheet).get_Range((object)cell, (object)cell2);
				if (_G_o__5.tLZVTFA6XNG == null)
				{
					_G_o__5.tLZVTFA6XNG = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(TableValidationService), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				if ((dynamic)_G_o__5.tLZVTFA6XNG.Target(_G_o__5.tLZVTFA6XNG, typeof(Convert), ((_Worksheet)worksheet).get_Range((object)("A" + (count2 + num - 1)), Type.Missing).get_Value(Type.Missing)) == string.Empty)
				{
					((_Worksheet)worksheet).get_Range((object)("A" + (count2 + num - 1)), Type.Missing).set_Value(Type.Missing, (object)" ");
				}
				if (_G_o__5.Y9xVTPOsWB8 == null)
				{
					_G_o__5.Y9xVTPOsWB8 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(TableValidationService), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, Type, object, object> target = _G_o__5.Y9xVTPOsWB8.Target;
				CallSite<Func<CallSite, Type, object, object>> y9xVTPOsWB = _G_o__5.Y9xVTPOsWB8;
				Type typeFromHandle = typeof(Convert);
				if (_G_o__5.gXmVTq4CdC4 == null)
				{
					_G_o__5.gXmVTq4CdC4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value", typeof(TableValidationService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				if ((dynamic)target(y9xVTPOsWB, typeFromHandle, _G_o__5.gXmVTq4CdC4.Target(_G_o__5.gXmVTq4CdC4, worksheet.Cells[count2 + num - 1, count3])) == string.Empty)
				{
					if (_G_o__5.B4NVTW744L1 == null)
					{
						_G_o__5.B4NVTW744L1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Value", typeof(TableValidationService), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					_G_o__5.B4NVTW744L1.Target(_G_o__5.B4NVTW744L1, worksheet.Cells[count2 + num - 1, count3], " ");
				}
				int num3 = range.Row + range.Rows.Count - 1;
				int count4 = range.Columns.Count;
				if (P_0)
				{
					GGNKjyGQM7(worksheet, num, num3, count4);
				}
				else
				{
					VkCKY5Yqse(worksheet, num, num3, count4);
				}
				try
				{
					range.get_Offset((object)1, Type.Missing).get_Resize((object)range.Rows.Count, (object)(range.Columns.Count + 1)).Style = "Comma";
				}
				catch
				{
				}
				num = num3 + 3;
				if (!Dt0KSlvqhl(progressWindow, num2, count))
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
			LoggerInitializer.F9Ycoqv2I8(ex.ToString(), "IP_Assurance");
		}
		finally
		{
			FwUKwKcu65(progressWindow);
			App.ScreenUpdating = true;
		}
	}

	public static void pSAKJ3DAt3()
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
					string text = wpRKfrQQkw(cell);
					double num3;
					if (text.EndsWith("%", StringComparison.Ordinal))
					{
						if (qvYKM0nKBw(text.Substring(0, text.Length - 1), out var num2))
						{
							num += num2 / 100.0;
						}
					}
					else if (qvYKM0nKBw(text, out num3))
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
				LoggerInitializer.Ay3cNuEgJo(text2 + "  可直接粘贴", "IP_Assurance");
			}
			App.StatusBar = text2 + "可直接粘贴";
			Clipboard.SetText(num.ToString("#,##0.00;-#,##0.00; ", CultureInfo.CurrentCulture));
		}
		catch (Exception ex)
		{
			LoggerInitializer.F9Ycoqv2I8(ex.ToString(), "IP_Assurance");
		}
		finally
		{
			App.ScreenUpdating = true;
		}
	}

	public static void BFXK3Dv3Bc()
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
					if (S7SKUowlLy(field))
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

	private static bool S7SKUowlLy(Field P_0)
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

	public static void CKSKKAnPKH()
	{
		Microsoft.Office.Interop.Excel.Application application = ExcelInteropService.gM4XBr1Rq();
		if (application == null)
		{
			LoggerInitializer.F9Ycoqv2I8("无法启动 Excel/WPS 表格。", "IP_Assurance");
			return;
		}
		application.Visible = true;
		Worksheet worksheet = yekKEcMdXi(application.ActiveWorkbook ?? application.Workbooks.Add(Type.Missing), "Word批注导出");
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
			progressWindow = kreKbuS50W();
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
				if (!Dt0KSlvqhl(progressWindow, num2, count))
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
			LoggerInitializer.F9Ycoqv2I8(ex.ToString(), "IP_Assurance");
		}
		finally
		{
			FwUKwKcu65(progressWindow);
			App.ScreenUpdating = true;
		}
	}

	private static Worksheet yekKEcMdXi(Workbook P_0, string P_1)
	{
		foreach (Worksheet worksheet in P_0.Worksheets)
		{
			if (string.Equals(worksheet.Name, P_1, StringComparison.OrdinalIgnoreCase))
			{
				return worksheet;
			}
		}
		if (_G_o__10.yWZVTsqLW75 == null)
		{
			_G_o__10.yWZVTsqLW75 = CallSite<Func<CallSite, Sheets, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Add", null, typeof(TableValidationService), new CSharpArgumentInfo[2]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.NamedArgument, "After")
			}));
		}
		Worksheet obj = (Worksheet)(dynamic)_G_o__10.yWZVTsqLW75.Target(_G_o__10.yWZVTsqLW75, P_0.Worksheets, P_0.Sheets[P_0.Sheets.Count]);
		obj.Name = P_1;
		return obj;
	}

	private static int YV1K26qhk7(Worksheet P_0)
	{
		if (_G_o__11.SUFVTov2Kyj == null)
		{
			_G_o__11.SUFVTov2Kyj = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Row", typeof(TableValidationService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
		}
		Func<CallSite, object, object> target = _G_o__11.SUFVTov2Kyj.Target;
		CallSite<Func<CallSite, object, object>> sUFVTov2Kyj = _G_o__11.SUFVTov2Kyj;
		if (_G_o__11.MTDVTNjq95L == null)
		{
			_G_o__11.MTDVTNjq95L = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.ResultIndexed, "End", typeof(TableValidationService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
		}
		int num = (dynamic)target(sUFVTov2Kyj, (object)((dynamic)_G_o__11.MTDVTNjq95L.Target(_G_o__11.MTDVTNjq95L, P_0.Cells[P_0.Rows.Count, 1]))[-4162]);
		if (_G_o__11.rmjVTpISiO9 == null)
		{
			_G_o__11.rmjVTpISiO9 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(TableValidationService), new CSharpArgumentInfo[2]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		Func<CallSite, Type, object, object> target2 = _G_o__11.rmjVTpISiO9.Target;
		CallSite<Func<CallSite, Type, object, object>> rmjVTpISiO = _G_o__11.rmjVTpISiO9;
		Type typeFromHandle = typeof(Convert);
		if (_G_o__11.jtZVTCjwVp8 == null)
		{
			_G_o__11.jtZVTCjwVp8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value", typeof(TableValidationService), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
		}
		string value = (dynamic)target2(rmjVTpISiO, typeFromHandle, _G_o__11.jtZVTCjwVp8.Target(_G_o__11.jtZVTCjwVp8, P_0.Cells[1, 1]));
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

	private static void OS9K47eF2M(Worksheet P_0, int P_1)
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

	private static void GGNKjyGQM7(Worksheet P_0, int P_1, int P_2, int P_3)
	{
		for (int i = P_1; i <= P_2; i++)
		{
			Microsoft.Office.Interop.Excel.Range obj = (dynamic)P_0.Cells[i, P_3 + 1];
			obj.FormulaR1C1 = "=IFERROR(RC[-1]-SUM(RC[" + -P_3 + "]:RC[-2]),\"\")";
			A5PKZIhH0W(obj);
		}
	}

	private static void VkCKY5Yqse(Worksheet P_0, int P_1, int P_2, int P_3)
	{
		for (int i = 1; i <= P_3; i++)
		{
			Microsoft.Office.Interop.Excel.Range obj = (dynamic)P_0.Cells[P_2 + 1, i];
			obj.FormulaR1C1 = "=IFERROR(R[-1]C-SUM(R[" + -(P_2 - P_1) + "]C:R[-2]C),\"\")";
			A5PKZIhH0W(obj);
		}
	}

	private static void A5PKZIhH0W(Microsoft.Office.Interop.Excel.Range P_0)
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

	private static string wpRKfrQQkw(Cell P_0)
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

	private static bool qvYKM0nKBw(string P_0, out double P_1)
	{
		string s = (P_0 ?? string.Empty).Trim().Trim('\r', '\a', '\a').Replace(",", string.Empty);
		if (!double.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out P_1))
		{
			return double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out P_1);
		}
		return true;
	}

	private static ProgressWindow kreKbuS50W()
	{
		try
		{
			ProgressWindow progressWindow = new ProgressWindow();
			WordTableToolService5.IPf5i0ZcV4(progressWindow);
			return progressWindow;
		}
		catch
		{
			return null;
		}
	}

	private static bool Dt0KSlvqhl(ProgressWindow P_0, int P_1, int P_2)
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

	private static void FwUKwKcu65(ProgressWindow P_0)
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
