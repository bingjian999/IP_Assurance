using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using AiConfigBootstrap;
using AiSseStreamService3;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using SseStreamInitializer;
using WordTableToolService;
using ExcelInteropService;
using AiHelper_5;

namespace AiConfigBootstrap2;

internal sealed class AiConfigBootstrap2
{
	private sealed class SpreadsheetOperationException : Exception
	{
		[CompilerGenerated]
		private readonly string _string;

		[CompilerGenerated]
		private readonly object _object;

		public string Code
		{
			[CompilerGenerated]
			get
			{
				return _string;
			}
		}

		public object DataObject
		{
			[CompilerGenerated]
			get
			{
				return _object;
			}
		}

		public SpreadsheetOperationException(string P_0, string P_1, object P_2 = null) : base(P_0)
		{
			SseStreamInitializer.InitializeRuntime();
			_string = P_1;
			_object = P_2;
		}
	}

	private sealed class ComObjectTracker : IDisposable
	{
		private readonly List<object> _comObjects;

		public T TrackComObject<T>(T comObject) where T : class
		{
			if (comObject != null && Marshal.IsComObject(comObject))
			{
				_comObjects.Add(comObject);
			}
			return comObject;
		}

		public void Dispose()
		{
			for (int num = _comObjects.Count - 1; num >= 0; num--)
			{
				try
				{
					if (_comObjects[num] != null && Marshal.IsComObject(_comObjects[num]))
					{
						Marshal.ReleaseComObject(_comObjects[num]);
					}
				}
				catch
				{
				}
			}
		}

		public ComObjectTracker()
		{
			SseStreamInitializer.InitializeRuntime();
			_comObjects = new List<object>();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_0
	{
		public AiHelper_5 aiHelper_5;

		public string text;

		public Func<Application, ComObjectTracker, AiHelper_5> excelOperationFunc;

		public Exception exception;

		public _G_c__DisplayClass10_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void GetHostName()
		{
			Application application = null;
			ComObjectTracker comTracker = new ComObjectTracker();
			try
			{
				application = ExcelInteropService.GetActiveExcelApp();
				if (application == null)
				{
					aiHelper_5 = AiHelper_5.CreateError("未检测到已打开的 " + GetSpreadsheetHostName() + "。请先打开对应的表格应用和工作簿。", "spreadsheet_not_running", new
					{
						host = GetSpreadsheetHostName()
					});
					return;
				}
				AiConfigBootstrap.LogInfo("[AI Tool][Excel] Begin: " + text);
				aiHelper_5 = excelOperationFunc(application, comTracker);
				AiConfigBootstrap.LogInfo("[AI Tool][Excel] End: " + text + "; Success=" + (aiHelper_5 != null && aiHelper_5.success));
			}
			catch (COMException ex)
			{
				AiConfigBootstrap.LogError("[AI Tool][Excel] " + text + " failed", ex);
				aiHelper_5 = AiHelper_5.CreateExceptionError(text + " failed", "spreadsheet_com_error", ex);
			}
			catch (SpreadsheetOperationException spreadsheetEx)
			{
				AiConfigBootstrap.LogWarn("[AI Tool][Excel] " + text + " failed: " + spreadsheetEx.Message);
				aiHelper_5 = AiHelper_5.CreateError(spreadsheetEx.Message, spreadsheetEx.Code, spreadsheetEx.DataObject);
			}
			catch (Exception ex2)
			{
				AiConfigBootstrap.LogError("[AI Tool][Excel] " + text + " failed", ex2);
				exception = ex2;
			}
			finally
			{
				comTracker.Dispose();
				if (application != null && Marshal.IsComObject(application))
				{
					try
					{
						Marshal.ReleaseComObject(application);
					}
					catch
					{
					}
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass11_0
	{
		public Workbooks workbooks;

		public Func<int> countFunc;

		public _G_c__DisplayClass11_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetWorkbooksCount2()
		{
			return workbooks.Count;
		}

		internal int GetCount7()
		{
			return workbooks.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass12_0
	{
		public Sheets sheets;

		public Func<int> countFuncSheets3;

		public _G_c__DisplayClass12_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetCount6()
		{
			return sheets.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_0
	{
		public Microsoft.Office.Interop.Excel.Range rangeField8;

		public Workbook workbook;

		public _G_c__DisplayClass16_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetRangeRowCount4()
		{
			return rangeField8.Rows.Count;
		}

		internal int GetRangeColumnCount4()
		{
			return rangeField8.Columns.Count;
		}

		internal string GetWorkbookFullName4()
		{
			return workbook.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_1
	{
		public Microsoft.Office.Interop.Excel.Range rangeField9;

		public _G_c__DisplayClass16_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool IsRangeHidden()
		{
			return (dynamic)rangeField9.Hidden;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass16_2
	{
		public Microsoft.Office.Interop.Excel.Range rangeField10;

		public _G_c__DisplayClass16_2()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetRangeFormulaAsString()
		{
			dynamic val;
			if (!(((dynamic)rangeField10.Formula == null) ? true : false))
			{
				if (_G_o__16.toStringCallSite4 == null)
				{
					_G_o__16.toStringCallSite4 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(AiConfigBootstrap2), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__16.toStringCallSite4.Target(_G_o__16.toStringCallSite4, rangeField10.Formula);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		}

		internal string GetNumberFormatAsString()
		{
			dynamic val;
			if (!(((dynamic)rangeField10.NumberFormat == null) ? true : false))
			{
				if (_G_o__16.toStringCallSite8 == null)
				{
					_G_o__16.toStringCallSite8 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(AiConfigBootstrap2), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__16.toStringCallSite8.Target(_G_o__16.toStringCallSite8, rangeField10.NumberFormat);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		}

		internal bool GetFontBold()
		{
			return (dynamic)rangeField10.Font.Bold;
		}

		internal string GetInteriorColor()
		{
			dynamic val;
			if (!(((dynamic)rangeField10.Interior.Color == null) ? true : false))
			{
				if (_G_o__16.uZHVDMnQAFH == null)
				{
					_G_o__16.uZHVDMnQAFH = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(AiConfigBootstrap2), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__16.uZHVDMnQAFH.Target(_G_o__16.uZHVDMnQAFH, rangeField10.Interior.Color);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass18_0
	{
		public Microsoft.Office.Interop.Excel.Range rangeField6;

		public _G_c__DisplayClass18_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetRangeRowCount()
		{
			return rangeField6.Rows.Count;
		}

		internal int GetRangeColumnCount3()
		{
			return rangeField6.Columns.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass19_0
	{
		public Microsoft.Office.Interop.Excel.Range rangeField2;

		public _G_c__DisplayClass19_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal object GetRangeValue2()
		{
			return rangeField2.Value2;
		}

		internal int GetRangeRow3()
		{
			return rangeField2.Row;
		}

		internal int GetRangeColumn2()
		{
			return rangeField2.Column;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass1_0
	{
		public Workbook workbook;

		public Microsoft.Office.Interop.Excel.Range rangeField7;

		public _G_c__DisplayClass1_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetWorkbookFullName2()
		{
			return workbook.FullName;
		}

		internal int GetRangeRowCount2()
		{
			return rangeField7.Rows.Count;
		}

		internal int GetRangeColumnCount()
		{
			return rangeField7.Columns.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass20_0
	{
		public Microsoft.Office.Interop.Excel.Range rangeField3;

		public _G_c__DisplayClass20_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetRangeRow5()
		{
			return rangeField3.Row;
		}

		internal int GetRangeColumn3()
		{
			return rangeField3.Column;
		}

		internal string GetRangeFormula()
		{
			dynamic val;
			if (!(((dynamic)rangeField3.Formula == null) ? true : false))
			{
				if (_G_o__20.toStringCallSite6 == null)
				{
					_G_o__20.toStringCallSite6 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(AiConfigBootstrap2), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__20.toStringCallSite6.Target(_G_o__20.toStringCallSite6, rangeField3.Formula);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass21_0
	{
		public Microsoft.Office.Interop.Excel.Range rangeField4;

		public _G_c__DisplayClass21_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetRangeRow4()
		{
			return rangeField4.Row;
		}

		internal int GetRangeColumn()
		{
			return rangeField4.Column;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_0
	{
		public Names names;

		public Func<int> countFuncNames;

		public _G_c__DisplayClass23_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetNamesCount()
		{
			return names.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_1
	{
		public Sheets nuvVuVXaUZa;

		public Func<int> countFuncSheets;

		public _G_c__DisplayClass23_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int FalVuRjaACn()
		{
			return nuvVuVXaUZa.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_2
	{
		public Names names;

		public Func<int> countFuncNames2;

		public _G_c__DisplayClass23_2()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetNamesCount3()
		{
			return names.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass24_0
	{
		public Name gMvVuTWFYAE;

		public _G_c__DisplayClass24_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string tPgVuDMSEvI()
		{
			return gMvVuTWFYAE.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass26_0
	{
		public Workbook workbook;

		public _G_c__DisplayClass26_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetWorkbookName()
		{
			return workbook.Name;
		}

		internal string GetWorkbookFullName()
		{
			return workbook.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass29_0
	{
		public Microsoft.Office.Interop.Excel.Range rangeField5;

		public _G_c__DisplayClass29_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetRangeText()
		{
			dynamic val;
			if (!(((dynamic)rangeField5.Text == null) ? true : false))
			{
				if (_G_o__29.toStringCallSite5 == null)
				{
					_G_o__29.toStringCallSite5 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(AiConfigBootstrap2), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__29.toStringCallSite5.Target(_G_o__29.toStringCallSite5, rangeField5.Text);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0
	{
		public Workbook _workbook;

		public Workbooks workbooks;

		public Func<int> countFuncSheets2;

		public _G_c__DisplayClass2_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetNameLocal2()
		{
			return _workbook.Name;
		}

		internal int GetWorkbooksCount()
		{
			return workbooks.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_1
	{
		public Workbook HitVuYWWWDt;

		public _G_c__DisplayClass2_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetNameLocal()
		{
			return HitVuYWWWDt.Name;
		}

		internal string BxtVuKHyLBk()
		{
			return HitVuYWWWDt.FullName;
		}

		internal string GetPathFromWorkbook()
		{
			return HitVuYWWWDt.Path;
		}

		internal bool IsReadOnly()
		{
			return HitVuYWWWDt.ReadOnly;
		}

		internal bool IsWorkbookSaved()
		{
			return HitVuYWWWDt.Saved;
		}

		internal int uBvVujXxMUF()
		{
			return HitVuYWWWDt.Worksheets.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass30_0
	{
		public Microsoft.Office.Interop.Excel.Range ccQVufmDjvb;

		public _G_c__DisplayClass30_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string kcrVuZuVhoR()
		{
			return ccQVufmDjvb.get_Address((object)false, (object)false, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass3_0
	{
		public string text;

		public _G_c__DisplayClass3_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 TWDVuMtXBUI(Application app, ComObjectTracker scope)
		{
			_G_c__DisplayClass3_1 CS_8_locals_7 = new _G_c__DisplayClass3_1();
			CS_8_locals_7.workbook = yFgJROsdyk(app, scope, text);
			CS_8_locals_7.vhoVutjxFsc = scope.TrackComObject(CS_8_locals_7.workbook.Worksheets);
			List<object> list = new List<object>();
			for (int i = 1; i <= TryEvaluateInt(() => CS_8_locals_7.vhoVutjxFsc.Count); i++)
			{
				Worksheet worksheet = scope.TrackComObject((Worksheet)(dynamic)CS_8_locals_7.vhoVutjxFsc[i]);
				list.Add(new
				{
					index = i,
					name = worksheet.Name
				});
			}
			return AiHelper_5.CreateSuccess("Worksheet list retrieved.", new
			{
				workbook = CS_8_locals_7.workbook.Name,
				workbookFullName = hjGJjwaZBM(() => CS_8_locals_7.workbook.FullName),
				count = list.Count,
				sheets = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass3_1
	{
		public Sheets vhoVutjxFsc;

		public Workbook workbook;

		public Func<int> countFuncWorkbooks2;

		public _G_c__DisplayClass3_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal int GetNamesCount2()
		{
			return vhoVutjxFsc.Count;
		}

		internal string GetWorkbookFullName3()
		{
			return workbook.FullName;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass4_0
	{
		public string text;

		public string hoIVumAoPTa;

		public int value;

		public int zqpVuGBMiia;

		public int value;

		public bool flag;

		public bool ECVVuOlhpGG;

		public _G_c__DisplayClass4_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 PreviewUsedRange(Application app, ComObjectTracker scope)
		{
			Workbook workbook = yFgJROsdyk(app, scope, text);
			Worksheet worksheet = nhKJVrFKUP(app, workbook, scope, hoIVumAoPTa);
			Microsoft.Office.Interop.Excel.Range range = scope.TrackComObject(worksheet.UsedRange);
			return AiHelper_5.CreateSuccess("Spreadsheet sheet preview prepared.", GetRangeValuesWithBounds(workbook, worksheet, range, "UsedRange", value, zqpVuGBMiia, value, false, flag, ECVVuOlhpGG, scope));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass5_0
	{
		public string text;

		public string text;

		public string text;

		public int tfHVueraXKO;

		public int value;

		public int value;

		public bool aPbVuFFmHHA;

		public bool flag;

		public bool cCPVuaUQwRs;

		public _G_c__DisplayClass5_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 GetRangeValues(Application app, ComObjectTracker scope)
		{
			Workbook workbook = yFgJROsdyk(app, scope, text);
			GetRangeByAddress2(app, workbook, scope, text, text, out var worksheet, out var range, out var text);
			return AiHelper_5.CreateSuccess("Spreadsheet range preview prepared.", GetRangeValuesWithBounds(workbook, worksheet, range, text, tfHVueraXKO, value, value, aPbVuFFmHHA, flag, cCPVuaUQwRs, scope));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass6_0
	{
		public string text;

		public string HTsVuAiAaQk;

		public string text;

		public bool trackRevisionsFlag;

		public _G_c__DisplayClass6_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 PreviewUsedRange3(Application app, ComObjectTracker scope)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return AiHelper_5.CreateError("address must not be empty.", "invalid_arguments");
			}
			Workbook workbook = yFgJROsdyk(app, scope, HTsVuAiAaQk);
			GetRangeByAddress2(app, workbook, scope, text, text, out var worksheet, out var range, out var text);
			return AiHelper_5.CreateSuccess(trackRevisionsFlag ? "Range values and formulas retrieved." : "Visible range values and formulas retrieved.", ybqJuWfEtN(workbook, worksheet, range, text, trackRevisionsFlag, true, false, scope));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass8_0
	{
		public string iuWVukLgGoV;

		public string text;

		public string usJVudwJBJr;

		public bool flag;

		public _G_c__DisplayClass8_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 PreviewUsedRange2(Application app, ComObjectTracker scope)
		{
			if (string.IsNullOrEmpty(iuWVukLgGoV))
			{
				return AiHelper_5.CreateError("searchValue must not be empty.", "invalid_arguments");
			}
			Workbook workbook = yFgJROsdyk(app, scope, text);
			Worksheet worksheet = nhKJVrFKUP(app, workbook, scope, usJVudwJBJr);
			Microsoft.Office.Interop.Excel.Range range = scope.TrackComObject(worksheet.UsedRange);
			List<object> list = new List<object>();
			string text;
			bool flag = FindRowIndices2(worksheet, range, iuWVukLgGoV, flag, scope, list, out text);
			string searchMethod = "excel_range_find";
			if (!flag)
			{
				list = ScanRangeValues(worksheet, range, iuWVukLgGoV, flag, scope);
				searchMethod = "value2_array_scan";
			}
			return AiHelper_5.CreateSuccess("Spreadsheet cell find completed.", new
			{
				workbook = workbook.Name,
				worksheet = worksheet.Name,
				searchValue = iuWVukLgGoV,
				matchCase = flag,
				searchMethod = searchMethod,
				nativeFindError = (flag ? null : text),
				returned = list.Count,
				truncated = (list.Count >= 50),
				matches = list
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass9_0
	{
		public string ELRVDVADLlW;

		public string kWOVDBeqpDL;

		public string text;

		public string text;

		public _G_c__DisplayClass9_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 CLTVDRfTkNP(Application app, ComObjectTracker scope)
		{
			_G_c__DisplayClass9_1 CS_8_locals_15 = new _G_c__DisplayClass9_1();
			if (!string.Equals(string.IsNullOrWhiteSpace(ELRVDVADLlW) ? "get" : ELRVDVADLlW.Trim().ToLowerInvariant(), "get", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateError("WordRe 中 manage_excel_named_range 只支持 action=get，不创建或更新名称区域。", "invalid_arguments", new
				{
					action = ELRVDVADLlW
				});
			}
			if (string.IsNullOrWhiteSpace(kWOVDBeqpDL))
			{
				return AiHelper_5.CreateError("name must not be empty.", "invalid_arguments");
			}
			Workbook workbook = yFgJROsdyk(app, scope, text);
			CS_8_locals_15.name = FindNamedRange(workbook, scope, kWOVDBeqpDL, text);
			if (CS_8_locals_15.name == null)
			{
				return AiHelper_5.CreateError("未找到指定名称区域。", "not_found", new
				{
					workbook = workbook.Name,
					name = kWOVDBeqpDL,
					nameScope = text
				});
			}
			CS_8_locals_15.rangeField = null;
			try
			{
				CS_8_locals_15.rangeField = scope.TrackComObject(CS_8_locals_15.name.RefersToRange);
			}
			catch
			{
			}
			return AiHelper_5.CreateSuccess("Named range retrieved.", new
			{
				workbook = workbook.Name,
				name = CS_8_locals_15.name.Name,
				nameScope = (string.IsNullOrWhiteSpace(text) ? "workbook_or_worksheet" : text),
				refersTo = hjGJjwaZBM(() => (dynamic)CS_8_locals_15.name.RefersTo),
				worksheet = ((CS_8_locals_15.rangeField == null) ? null : hjGJjwaZBM(() => CS_8_locals_15.rangeField.Worksheet.Name)),
				address = ((CS_8_locals_15.rangeField == null) ? null : tqdJKIVpyV(CS_8_locals_15.rangeField)),
				rows = ((CS_8_locals_15.rangeField != null) ? TryEvaluateInt(() => CS_8_locals_15.rangeField.Rows.Count) : 0),
				columns = ((CS_8_locals_15.rangeField != null) ? TryEvaluateInt(() => CS_8_locals_15.rangeField.Columns.Count) : 0)
			});
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass9_1
	{
		public Name name;

		public Microsoft.Office.Interop.Excel.Range rangeField;

		public _G_c__DisplayClass9_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal string GetRefersTo()
		{
			return (dynamic)name.RefersTo;
		}

		internal string GetNameLocal3()
		{
			return rangeField.Worksheet.Name;
		}

		internal int GetRangeRowCount3()
		{
			return rangeField.Rows.Count;
		}

		internal int GetRangeColumnCount2()
		{
			return rangeField.Columns.Count;
		}
	}

	[CompilerGenerated]
	private static class _G_o__16
	{
		public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> toRangeCallSite1;

		public static CallSite<Func<CallSite, object, bool>> toObjectCallSite7;

		public static CallSite<Func<CallSite, object, Microsoft.Office.Interop.Excel.Range>> toRangeCallSite2;

		public static CallSite<Func<CallSite, object, object, object>> YPpVDJlGjdi;

		public static CallSite<Func<CallSite, object, bool>> toObjectCallSite6;

		public static CallSite<Func<CallSite, object, object>> toStringCallSite4;

		public static CallSite<Func<CallSite, object, string>> toStringCallSite2;

		public static CallSite<Func<CallSite, object, object, object>> toObjectCallSite3;

		public static CallSite<Func<CallSite, object, bool>> toObjectCallSite8;

		public static CallSite<Func<CallSite, object, object>> toStringCallSite8;

		public static CallSite<Func<CallSite, object, string>> toStringCallSite3;

		public static CallSite<Func<CallSite, object, bool>> toObjectCallSite1;

		public static CallSite<Func<CallSite, object, object, object>> EclVDZaZqNp;

		public static CallSite<Func<CallSite, object, bool>> TTNVDfyPZJC;

		public static CallSite<Func<CallSite, object, object>> uZHVDMnQAFH;

		public static CallSite<Func<CallSite, object, string>> toStringCallSite1;
	}

	[CompilerGenerated]
	private static class _G_o__20
	{
		public static CallSite<Func<CallSite, object, object, object>> toObjectCallSite9;

		public static CallSite<Func<CallSite, object, bool>> toObjectCallSite4;

		public static CallSite<Func<CallSite, object, object>> toStringCallSite6;

		public static CallSite<Func<CallSite, object, string>> toStringCallSite7;
	}

	[CompilerGenerated]
	private static class _G_o__29
	{
		public static CallSite<Func<CallSite, object, object, object>> toObjectCallSite5;

		public static CallSite<Func<CallSite, object, bool>> toObjectCallSite2;

		public static CallSite<Func<CallSite, object, object>> toStringCallSite5;

		public static CallSite<Func<CallSite, object, string>> yWmVDpjviMN;
	}

	public AiHelper_5 GetCurrentExcelContext()
	{
		return oaarzjrmjs("get_current_excel_context", delegate(Application app, ComObjectTracker scope)
		{
			_G_c__DisplayClass1_0 CS_8_locals_10 = new _G_c__DisplayClass1_0();
			CS_8_locals_10.workbook = yFgJROsdyk(app, scope, string.Empty);
			Worksheet worksheet = scope.TrackComObject(app.ActiveSheet as Worksheet);
			CS_8_locals_10.rangeField7 = scope.TrackComObject(app.Selection as Microsoft.Office.Interop.Excel.Range);
			if (worksheet == null && CS_8_locals_10.rangeField7 != null)
			{
				worksheet = scope.TrackComObject(CS_8_locals_10.rangeField7.Worksheet);
			}
			return (worksheet == null) ? AiHelper_5.CreateError("get_current_excel_context", "list_open_excel_workbooks") : AiHelper_5.CreateSuccess("get_excel_sheet_list", new
			{
				host = GetSpreadsheetHostName(),
				workbook = CS_8_locals_10.workbook.Name,
				workbookFullName = hjGJjwaZBM(() => CS_8_locals_10.workbook.FullName),
				worksheet = worksheet.Name,
				selection = ((CS_8_locals_10.rangeField7 == null) ? null : new
				{
					address = tqdJKIVpyV(CS_8_locals_10.rangeField7),
					rows = TryEvaluateInt(() => CS_8_locals_10.rangeField7.Rows.Count),
					columns = TryEvaluateInt(() => CS_8_locals_10.rangeField7.Columns.Count)
				})
			});
		});
	}

	public AiHelper_5 ListOpenExcelWorkbooks()
	{
		return oaarzjrmjs("list_open_excel_workbooks", delegate(Application app, ComObjectTracker scope)
		{
			_G_c__DisplayClass2_0 CS_8_locals_8 = new _G_c__DisplayClass2_0();
			CS_8_locals_8.workbooks = scope.TrackComObject(app.Workbooks);
			CS_8_locals_8._workbook = scope.TrackComObject(app.ActiveWorkbook);
			string text = ((CS_8_locals_8._workbook == null) ? null : hjGJjwaZBM(() => CS_8_locals_8._workbook.Name));
			List<object> list = new List<object>();
			for (int num = 1; num <= TryEvaluateInt(() => CS_8_locals_8.workbooks.Count); num++)
			{
				_G_c__DisplayClass2_1 CS_8_locals_14 = new _G_c__DisplayClass2_1();
				CS_8_locals_14.HitVuYWWWDt = scope.TrackComObject(CS_8_locals_8.workbooks[num]);
				string text2 = hjGJjwaZBM(() => CS_8_locals_14.HitVuYWWWDt.Name);
				string fullName = hjGJjwaZBM(() => CS_8_locals_14.HitVuYWWWDt.FullName);
				list.Add(new
				{
					index = num,
					name = text2,
					fullName = fullName,
					path = hjGJjwaZBM(() => CS_8_locals_14.HitVuYWWWDt.Path),
					isActive = string.Equals(text2, text, StringComparison.OrdinalIgnoreCase),
					readOnly = TryEvaluateBool(() => CS_8_locals_14.HitVuYWWWDt.ReadOnly),
					saved = TryEvaluateBool(() => CS_8_locals_14.HitVuYWWWDt.Saved),
					sheetCount = TryEvaluateInt(() => CS_8_locals_14.HitVuYWWWDt.Worksheets.Count)
				});
			}
			return AiHelper_5.CreateSuccess("preview_excel_sheet", new
			{
				host = GetSpreadsheetHostName(),
				count = list.Count,
				activeWorkbook = text,
				workbooks = list
			});
		});
	}

	public AiHelper_5 GetExcelSheetList(string P_0)
	{
		_G_c__DisplayClass3_0 CS_8_locals_4 = new _G_c__DisplayClass3_0();
		CS_8_locals_4.text = P_0;
		return oaarzjrmjs("get_excel_sheet_list", delegate(Application app, ComObjectTracker scope)
		{
			_G_c__DisplayClass3_1 CS_8_locals_10 = new _G_c__DisplayClass3_1();
			CS_8_locals_10.workbook = yFgJROsdyk(app, scope, CS_8_locals_4.text);
			CS_8_locals_10.vhoVutjxFsc = scope.TrackComObject(CS_8_locals_10.workbook.Worksheets);
			List<object> list = new List<object>();
			for (int i = 1; i <= TryEvaluateInt(() => CS_8_locals_10.vhoVutjxFsc.Count); i++)
			{
				Worksheet worksheet = scope.TrackComObject((Worksheet)(dynamic)CS_8_locals_10.vhoVutjxFsc[i]);
				list.Add(new
				{
					index = i,
					name = worksheet.Name
				});
			}
			return AiHelper_5.CreateSuccess("preview_excel_range", new
			{
				workbook = CS_8_locals_10.workbook.Name,
				workbookFullName = hjGJjwaZBM(() => CS_8_locals_10.workbook.FullName),
				count = list.Count,
				sheets = list
			});
		});
	}

	public AiHelper_5 dhorWDIpcu(string P_0, string P_1, int P_2, int P_3, int P_4, bool P_5, bool P_6)
	{
		_G_c__DisplayClass4_0 CS_8_locals_14 = new _G_c__DisplayClass4_0();
		CS_8_locals_14.text = P_1;
		CS_8_locals_14.hoIVumAoPTa = P_0;
		CS_8_locals_14.value = P_2;
		CS_8_locals_14.zqpVuGBMiia = P_3;
		CS_8_locals_14.value = P_4;
		CS_8_locals_14.flag = P_5;
		CS_8_locals_14.ECVVuOlhpGG = P_6;
		return oaarzjrmjs("preview_excel_sheet", delegate(Application app, ComObjectTracker scope)
		{
			Workbook workbook = yFgJROsdyk(app, scope, CS_8_locals_14.text);
			Worksheet worksheet = nhKJVrFKUP(app, workbook, scope, CS_8_locals_14.hoIVumAoPTa);
			Microsoft.Office.Interop.Excel.Range range = scope.TrackComObject(worksheet.UsedRange);
			return AiHelper_5.CreateSuccess("get_excel_range_values_and_formulas", GetRangeValuesWithBounds(workbook, worksheet, range, "get_current_selection_values_and_formulas", CS_8_locals_14.value, CS_8_locals_14.zqpVuGBMiia, CS_8_locals_14.value, false, CS_8_locals_14.flag, CS_8_locals_14.ECVVuOlhpGG, scope));
		});
	}

	public AiHelper_5 PreviewExcelRange(string P_0, string P_1, string P_2, int P_3, int P_4, int P_5, bool P_6, bool P_7, bool P_8)
	{
		_G_c__DisplayClass5_0 CS_8_locals_18 = new _G_c__DisplayClass5_0();
		CS_8_locals_18.text = P_2;
		CS_8_locals_18.text = P_0;
		CS_8_locals_18.text = P_1;
		CS_8_locals_18.tfHVueraXKO = P_3;
		CS_8_locals_18.value = P_4;
		CS_8_locals_18.value = P_5;
		CS_8_locals_18.aPbVuFFmHHA = P_6;
		CS_8_locals_18.flag = P_7;
		CS_8_locals_18.cCPVuaUQwRs = P_8;
		return oaarzjrmjs("preview_excel_range", delegate(Application app, ComObjectTracker scope)
		{
			Workbook workbook = yFgJROsdyk(app, scope, CS_8_locals_18.text);
			GetRangeByAddress2(app, workbook, scope, CS_8_locals_18.text, CS_8_locals_18.text, out var worksheet, out var range, out var text);
			return AiHelper_5.CreateSuccess("find_excel_cells", GetRangeValuesWithBounds(workbook, worksheet, range, text, CS_8_locals_18.tfHVueraXKO, CS_8_locals_18.value, CS_8_locals_18.value, CS_8_locals_18.aPbVuFFmHHA, CS_8_locals_18.flag, CS_8_locals_18.cCPVuaUQwRs, scope));
		});
	}

	public AiHelper_5 GetExcelRangeValuesAndFormulas(string P_0, string P_1, string P_2, bool P_3)
	{
		_G_c__DisplayClass6_0 CS_8_locals_10 = new _G_c__DisplayClass6_0();
		CS_8_locals_10.text = P_1;
		CS_8_locals_10.HTsVuAiAaQk = P_2;
		CS_8_locals_10.text = P_0;
		CS_8_locals_10.trackRevisionsFlag = P_3;
		return oaarzjrmjs("get_excel_range_values_and_formulas", delegate(Application app, ComObjectTracker scope)
		{
			if (string.IsNullOrWhiteSpace(CS_8_locals_10.text))
			{
				return AiHelper_5.CreateError("manage_excel_named_range", " failed");
			}
			Workbook workbook = yFgJROsdyk(app, scope, CS_8_locals_10.HTsVuAiAaQk);
			GetRangeByAddress2(app, workbook, scope, CS_8_locals_10.text, CS_8_locals_10.text, out var worksheet, out var range, out var text);
			return AiHelper_5.CreateSuccess(CS_8_locals_10.trackRevisionsFlag ? "spreadsheet_error" : "Unknown spreadsheet error.", ybqJuWfEtN(workbook, worksheet, range, text, CS_8_locals_10.trackRevisionsFlag, true, false, scope));
		});
	}

	public AiHelper_5 GetCurrentSelectionValuesAndFormulas()
	{
		return oaarzjrmjs("get_current_selection_values_and_formulas", delegate(Application app, ComObjectTracker scope)
		{
			Workbook workbook = yFgJROsdyk(app, scope, string.Empty);
			Microsoft.Office.Interop.Excel.Range range = scope.TrackComObject(app.Selection as Microsoft.Office.Interop.Excel.Range);
			if (range == null)
			{
				return AiHelper_5.CreateError("当前没有打开的工作簿。", "no_workbook");
			}
			Worksheet worksheet = scope.TrackComObject(range.Worksheet);
			return AiHelper_5.CreateSuccess("Excel selection values and formulas read.", ybqJuWfEtN(workbook, worksheet, range, tqdJKIVpyV(range), false, true, false, scope));
		});
	}

	public AiHelper_5 kpSrxrdvDy(string P_0, string P_1, bool P_2, string P_3)
	{
		_G_c__DisplayClass8_0 CS_8_locals_13 = new _G_c__DisplayClass8_0();
		CS_8_locals_13.iuWVukLgGoV = P_1;
		CS_8_locals_13.text = P_3;
		CS_8_locals_13.usJVudwJBJr = P_0;
		CS_8_locals_13.flag = P_2;
		return oaarzjrmjs("find_excel_cells", delegate(Application app, ComObjectTracker scope)
		{
			if (string.IsNullOrEmpty(CS_8_locals_13.iuWVukLgGoV))
			{
				return AiHelper_5.CreateError("未找到指定工作簿。", "no_workbook");
			}
			Workbook workbook = yFgJROsdyk(app, scope, CS_8_locals_13.text);
			Worksheet worksheet = nhKJVrFKUP(app, workbook, scope, CS_8_locals_13.usJVudwJBJr);
			Microsoft.Office.Interop.Excel.Range range = scope.TrackComObject(worksheet.UsedRange);
			List<object> list = new List<object>();
			string text;
			bool flag = FindRowIndices2(worksheet, range, CS_8_locals_13.iuWVukLgGoV, CS_8_locals_13.flag, scope, list, out text);
			string searchMethod = "native_find";
			if (!flag)
			{
				list = ScanRangeValues(worksheet, range, CS_8_locals_13.iuWVukLgGoV, CS_8_locals_13.flag, scope);
				searchMethod = "scan_range_values";
			}
			return AiHelper_5.CreateSuccess("Excel cells found.", new
			{
				workbook = workbook.Name,
				worksheet = worksheet.Name,
				searchValue = CS_8_locals_13.iuWVukLgGoV,
				matchCase = CS_8_locals_13.flag,
				searchMethod = searchMethod,
				nativeFindError = (flag ? null : text),
				returned = list.Count,
				truncated = (list.Count >= 50),
				matches = list
			});
		});
	}

	public AiHelper_5 nCmrdMSTjR(string P_0, string P_1, string P_2, string P_3)
	{
		_G_c__DisplayClass9_0 CS_8_locals_22 = new _G_c__DisplayClass9_0();
		CS_8_locals_22.ELRVDVADLlW = P_0;
		CS_8_locals_22.kWOVDBeqpDL = P_1;
		CS_8_locals_22.text = P_2;
		CS_8_locals_22.text = P_3;
		return oaarzjrmjs("manage_excel_named_range", delegate(Application app, ComObjectTracker scope)
		{
			_G_c__DisplayClass9_1 CS_8_locals_31 = new _G_c__DisplayClass9_1();
			if (!string.Equals(string.IsNullOrWhiteSpace(CS_8_locals_22.ELRVDVADLlW) ? "未找到指定工作表。" : CS_8_locals_22.ELRVDVADLlW.Trim().ToLowerInvariant(), "worksheet_not_found", StringComparison.Ordinal))
			{
				return AiHelper_5.CreateError("!", "!", new
				{
					action = CS_8_locals_22.ELRVDVADLlW
				});
			}
			if (string.IsNullOrWhiteSpace(CS_8_locals_22.kWOVDBeqpDL))
			{
				return AiHelper_5.CreateError("!UsedRange", "当前 Excel/WPS 表格选区不是可读取区域。");
			}
			Workbook workbook = yFgJROsdyk(app, scope, CS_8_locals_22.text);
			CS_8_locals_31.name = FindNamedRange(workbook, scope, CS_8_locals_22.kWOVDBeqpDL, CS_8_locals_22.text);
			if (CS_8_locals_31.name == null)
			{
				return AiHelper_5.CreateError("empty_selection", "!", new
				{
					workbook = workbook.Name,
					name = CS_8_locals_22.kWOVDBeqpDL,
					nameScope = CS_8_locals_22.text
				});
			}
			CS_8_locals_31.rangeField = null;
			try
			{
				CS_8_locals_31.rangeField = scope.TrackComObject(CS_8_locals_31.name.RefersToRange);
			}
			catch
			{
			}
			return AiHelper_5.CreateSuccess("Excel named range read.", new
			{
				workbook = workbook.Name,
				name = CS_8_locals_31.name.Name,
				nameScope = (string.IsNullOrWhiteSpace(CS_8_locals_22.text) ? "no_worksheet" : CS_8_locals_22.text),
				refersTo = hjGJjwaZBM(() => (dynamic)CS_8_locals_31.name.RefersTo),
				worksheet = ((CS_8_locals_31.rangeField == null) ? null : hjGJjwaZBM(() => CS_8_locals_31.rangeField.Worksheet.Name)),
				address = ((CS_8_locals_31.rangeField == null) ? null : tqdJKIVpyV(CS_8_locals_31.rangeField)),
				rows = ((CS_8_locals_31.rangeField != null) ? TryEvaluateInt(() => CS_8_locals_31.rangeField.Rows.Count) : 0),
				columns = ((CS_8_locals_31.rangeField != null) ? TryEvaluateInt(() => CS_8_locals_31.rangeField.Columns.Count) : 0)
			});
		});
	}

	private static AiHelper_5 oaarzjrmjs(string P_0, Func<Application, ComObjectTracker, AiHelper_5> P_1)
	{
		_G_c__DisplayClass10_0 CS_8_locals_22 = new _G_c__DisplayClass10_0();
		CS_8_locals_22.text = P_0;
		CS_8_locals_22.excelOperationFunc = P_1;
		CS_8_locals_22.aiHelper_5 = null;
		CS_8_locals_22.exception = null;
		Thread thread = new Thread((ThreadStart)delegate
		{
			Application application = null;
			ComObjectTracker comTracker = new ComObjectTracker();
			try
			{
				application = ExcelInteropService.GetActiveExcelApp();
				if (application == null)
				{
					CS_8_locals_22.aiHelper_5 = AiHelper_5.CreateError(" failed" + GetSpreadsheetHostName() + "spreadsheet_error", "Unknown spreadsheet error.", new
					{
						host = GetSpreadsheetHostName()
					});
				}
				else
				{
					AiConfigBootstrap.LogInfo("address must not be empty." + CS_8_locals_22.text);
					CS_8_locals_22.aiHelper_5 = CS_8_locals_22.excelOperationFunc(application, comTracker);
					AiConfigBootstrap.LogInfo("invalid_arguments" + CS_8_locals_22.text + "区域地址无效：" + (CS_8_locals_22.aiHelper_5 != null && CS_8_locals_22.aiHelper_5.success));
				}
			}
			catch (COMException ex)
			{
				AiConfigBootstrap.LogError("invalid_arguments" + CS_8_locals_22.text + ": ", ex);
				CS_8_locals_22.aiHelper_5 = AiHelper_5.CreateExceptionError(CS_8_locals_22.text + ":", "yyyy-MM-dd HH:mm:ss", ex);
			}
			catch (SpreadsheetOperationException spreadsheetEx)
			{
				AiConfigBootstrap.LogWarn("workbook_or_worksheet" + CS_8_locals_22.text + "workbook" + spreadsheetEx.Message);
				CS_8_locals_22.aiHelper_5 = AiHelper_5.CreateError(spreadsheetEx.Message, spreadsheetEx.Code, spreadsheetEx.DataObject);
			}
			catch (Exception ex2)
			{
				AiConfigBootstrap.LogError("workbook_or_worksheet" + CS_8_locals_22.text + "worksheet", ex2);
				CS_8_locals_22.exception = ex2;
			}
			finally
			{
				comTracker.Dispose();
				if (application != null && Marshal.IsComObject(application))
				{
					try
					{
						Marshal.ReleaseComObject(application);
					}
					catch
					{
					}
				}
			}
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
		if (CS_8_locals_22.aiHelper_5 != null)
		{
			return CS_8_locals_22.aiHelper_5;
		}
		return AiHelper_5.CreateExceptionError(CS_8_locals_22.text + "workbook_or_worksheet", "'", CS_8_locals_22.exception ?? new InvalidOperationException("'"));
	}

	private static Workbook yFgJROsdyk(Application P_0, ComObjectTracker P_1, string P_2)
	{
		_G_c__DisplayClass11_0 CS_8_locals_4 = new _G_c__DisplayClass11_0();
		CS_8_locals_4.workbooks = P_1.TrackComObject(P_0.Workbooks);
		if (TryEvaluateInt(() => CS_8_locals_4.workbooks.Count) <= 0)
		{
			throw new SpreadsheetOperationException("当前没有打开的工作簿。", "no_workbook");
		}
		if (string.IsNullOrWhiteSpace(P_2))
		{
			return P_1.TrackComObject(P_0.ActiveWorkbook) ?? throw new SpreadsheetOperationException("当前没有活动工作簿。", "no_workbook");
		}
		for (int num = 1; num <= TryEvaluateInt(() => CS_8_locals_4.workbooks.Count); num++)
		{
			Workbook workbook = P_1.TrackComObject(CS_8_locals_4.workbooks[num]);
			if (skJJrNGIkj(workbook, P_2))
			{
				return workbook;
			}
		}
		throw new SpreadsheetOperationException("未找到指定工作簿。", "workbook_not_found", new
		{
			workbookName = P_2
		});
	}

	private static Worksheet nhKJVrFKUP(Application P_0, Workbook P_1, ComObjectTracker P_2, string P_3)
	{
		_G_c__DisplayClass12_0 CS_8_locals_3 = new _G_c__DisplayClass12_0();
		if (P_1 == null)
		{
			throw new SpreadsheetOperationException("当前没有打开的工作簿。", "no_workbook");
		}
		if (string.IsNullOrWhiteSpace(P_3))
		{
			Worksheet worksheet = P_2.TrackComObject(P_0.ActiveSheet as Worksheet);
			if (worksheet != null && GetWorkbookFullName5(worksheet, P_1))
			{
				return worksheet;
			}
			return P_2.TrackComObject((Worksheet)(dynamic)P_1.Worksheets[1]);
		}
		CS_8_locals_3.sheets = P_2.TrackComObject(P_1.Worksheets);
		for (int i = 1; i <= TryEvaluateInt(() => CS_8_locals_3.sheets.Count); i++)
		{
			Worksheet worksheet2 = P_2.TrackComObject((Worksheet)(dynamic)CS_8_locals_3.sheets[i]);
			if (string.Equals(worksheet2.Name, P_3, StringComparison.OrdinalIgnoreCase))
			{
				return worksheet2;
			}
		}
		throw new SpreadsheetOperationException("未找到指定工作表。", "worksheet_not_found", new
		{
			workbook = P_1.Name,
			sheetName = P_3
		});
	}

	private static void GetRangeByAddress2(Application P_0, Workbook P_1, ComObjectTracker P_2, string P_3, string P_4, out Worksheet P_5, out Microsoft.Office.Interop.Excel.Range P_6, out string P_7)
	{
		if (GetFullName2(P_4, out var text, out var text2))
		{
			P_5 = nhKJVrFKUP(P_0, P_1, P_2, text);
			P_6 = GetRangeByAddress(P_5, P_2, text2);
			P_7 = P_5.Name + "!" + text2;
			return;
		}
		if (!string.IsNullOrWhiteSpace(P_4))
		{
			P_5 = nhKJVrFKUP(P_0, P_1, P_2, P_3);
			P_6 = GetRangeByAddress(P_5, P_2, P_4);
			P_7 = P_5.Name + "!" + P_4;
			return;
		}
		if (!string.IsNullOrWhiteSpace(P_3))
		{
			P_5 = nhKJVrFKUP(P_0, P_1, P_2, P_3);
			P_6 = P_2.TrackComObject(P_5.UsedRange);
			P_7 = P_5.Name + "!UsedRange";
			return;
		}
		P_6 = P_2.TrackComObject(P_0.Selection as Microsoft.Office.Interop.Excel.Range);
		if (P_6 == null)
		{
			throw new SpreadsheetOperationException("当前 Excel/WPS 表格选区不是可读取区域。", "empty_selection");
		}
		P_5 = P_2.TrackComObject(P_6.Worksheet);
		P_7 = P_5.Name + "!" + tqdJKIVpyV(P_6);
	}

	private static Microsoft.Office.Interop.Excel.Range GetRangeByAddress(Worksheet P_0, ComObjectTracker P_1, string P_2)
	{
		if (P_0 == null)
		{
			throw new SpreadsheetOperationException("当前没有活动工作表。", "no_worksheet");
		}
		if (string.IsNullOrWhiteSpace(P_2))
		{
			throw new SpreadsheetOperationException("address must not be empty.", "invalid_arguments");
		}
		try
		{
			return P_1.TrackComObject(((_Worksheet)P_0).get_Range((object)P_2, Type.Missing));
		}
		catch (Exception ex)
		{
			throw new SpreadsheetOperationException("区域地址无效：" + P_2, "invalid_arguments", new
			{
				address = P_2,
				exception = ex.GetType().Name
			});
		}
	}

	private static object GetRangeValuesWithBounds(Workbook P_0, Worksheet P_1, Microsoft.Office.Interop.Excel.Range P_2, string P_3, int P_4, int P_5, int P_6, bool P_7, bool P_8, bool P_9, ComObjectTracker P_10)
	{
		return ybqJuWfEtN(P_0, P_1, P_2, P_3, P_7, P_8, P_9, P_10, P_4, P_5, P_6);
	}

	private static object ybqJuWfEtN(Workbook P_0, Worksheet P_1, Microsoft.Office.Interop.Excel.Range P_2, string P_3, bool P_4, bool P_5, bool P_6, ComObjectTracker P_7, int P_8 = 0, int P_9 = 0, int P_10 = 0)
	{
		_G_c__DisplayClass16_0 CS_8_locals_19 = new _G_c__DisplayClass16_0();
		CS_8_locals_19.rangeField8 = P_2;
		CS_8_locals_19.workbook = P_0;
		int num = TryEvaluateInt(() => CS_8_locals_19.rangeField8.Rows.Count);
		int num2 = TryEvaluateInt(() => CS_8_locals_19.rangeField8.Columns.Count);
		int num3 = ((P_10 > 0) ? Math.Min(num2, Math.Max(1, P_10)) : num2);
		List<object> list = new List<object>();
		List<int> list2 = FindRowIndices(num, P_8, P_9);
		if (list2.Count == 0)
		{
			for (int num4 = 1; num4 <= num; num4++)
			{
				list2.Add(num4);
			}
		}
		foreach (int item in list2)
		{
			if (P_4)
			{
				_G_c__DisplayClass16_1 obj = new _G_c__DisplayClass16_1();
				obj.rangeField9 = P_7.TrackComObject((Microsoft.Office.Interop.Excel.Range)(dynamic)CS_8_locals_19.rangeField8.Rows[item, Type.Missing]);
				if (TryEvaluateBool(() => (dynamic)obj.rangeField9.Hidden))
				{
					continue;
				}
			}
			List<object> list3 = new List<object>();
			List<object> list4 = (P_5 ? new List<object>() : null);
			List<object> list5 = (P_6 ? new List<object>() : null);
			for (int num5 = 1; num5 <= num3; num5++)
			{
				_G_c__DisplayClass16_2 CS_8_locals_18 = new _G_c__DisplayClass16_2();
				CS_8_locals_18.rangeField10 = P_7.TrackComObject((Microsoft.Office.Interop.Excel.Range)(dynamic)CS_8_locals_19.rangeField8.Cells[item, num5]);
				list3.Add(GetRangeValue(CS_8_locals_18.rangeField10));
				if (P_5)
				{
					list4.Add(hjGJjwaZBM(delegate
					{
						dynamic val;
						if (!(((dynamic)CS_8_locals_18.rangeField10.Formula == null) ? true : false))
						{
							if (_G_o__16.toStringCallSite4 == null)
							{
								_G_o__16.toStringCallSite4 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "''", null, typeof(AiConfigBootstrap2), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							val = _G_o__16.toStringCallSite4.Target(_G_o__16.toStringCallSite4, CS_8_locals_18.rangeField10.Formula);
						}
						else
						{
							val = string.Empty;
						}
						return val;
					}));
				}
				if (!P_6)
				{
					continue;
				}
				list5.Add(new
				{
					numberFormat = hjGJjwaZBM(delegate
					{
						dynamic val;
						if (!(((dynamic)CS_8_locals_18.rangeField10.NumberFormat == null) ? true : false))
						{
							if (_G_o__16.toStringCallSite8 == null)
							{
								_G_o__16.toStringCallSite8 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "'", null, typeof(AiConfigBootstrap2), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							val = _G_o__16.toStringCallSite8.Target(_G_o__16.toStringCallSite8, CS_8_locals_18.rangeField10.NumberFormat);
						}
						else
						{
							val = string.Empty;
						}
						return val;
					}),
					bold = TryEvaluateBool(() => (dynamic)CS_8_locals_18.rangeField10.Font.Bold),
					interiorColor = hjGJjwaZBM(delegate
					{
						dynamic val;
						if (!(((dynamic)CS_8_locals_18.rangeField10.Interior.Color == null) ? true : false))
						{
							if (_G_o__16.uZHVDMnQAFH == null)
							{
								_G_o__16.uZHVDMnQAFH = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "yyyy-MM-dd HH:mm:ss", null, typeof(AiConfigBootstrap2), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							val = _G_o__16.uZHVDMnQAFH.Target(_G_o__16.uZHVDMnQAFH, CS_8_locals_18.rangeField10.Interior.Color);
						}
						else
						{
							val = string.Empty;
						}
						return val;
					})
				});
			}
			list.Add(new
			{
				rowIndex = item,
				values = list3,
				formulas = list4,
				formats = list5
			});
		}
		return new
		{
			workbook = CS_8_locals_19.workbook.Name,
			workbookFullName = hjGJjwaZBM(() => CS_8_locals_19.workbook.FullName),
			worksheet = P_1.Name,
			requestedAddress = P_3,
			address = tqdJKIVpyV(CS_8_locals_19.rangeField8),
			rows = num,
			columns = num2,
			returnedRows = list.Count,
			returnedColumns = num3,
			truncated = (list.Count < num || num3 < num2),
			visibleOnly = P_4,
			includeFormulas = P_5,
			includeFormats = P_6,
			data = list
		};
	}

	private static List<int> FindRowIndices(int P_0, int P_1, int P_2)
	{
		List<int> list = new List<int>();
		if (P_1 <= 0 && P_2 <= 0)
		{
			return list;
		}
		int num = Math.Min(P_0, Math.Max(0, P_1));
		for (int i = 1; i <= num; i++)
		{
			list.Add(i);
		}
		int num2 = Math.Min(P_0, Math.Max(0, P_2));
		for (int j = Math.Max(num + 1, P_0 - num2 + 1); j <= P_0; j++)
		{
			list.Add(j);
		}
		return list;
	}

	private static bool FindRowIndices2(Worksheet P_0, Microsoft.Office.Interop.Excel.Range P_1, string P_2, bool P_3, ComObjectTracker P_4, List<object> P_5, out string P_6)
	{
		_G_c__DisplayClass18_0 CS_8_locals_6 = new _G_c__DisplayClass18_0();
		CS_8_locals_6.rangeField6 = P_1;
		P_6 = null;
		try
		{
			int num = TryEvaluateInt(() => CS_8_locals_6.rangeField6.Rows.Count);
			int num2 = TryEvaluateInt(() => CS_8_locals_6.rangeField6.Columns.Count);
			if (num <= 0 || num2 <= 0)
			{
				return true;
			}
			Microsoft.Office.Interop.Excel.Range after = P_4.TrackComObject((Microsoft.Office.Interop.Excel.Range)(dynamic)CS_8_locals_6.rangeField6.Cells[num, num2]);
			Microsoft.Office.Interop.Excel.Range range = P_4.TrackComObject(CS_8_locals_6.rangeField6.Find(P_2, after, XlFindLookIn.xlValues, XlLookAt.xlPart, XlSearchOrder.xlByRows, XlSearchDirection.xlNext, P_3, Type.Missing, Type.Missing));
			if (range == null)
			{
				return true;
			}
			string b = GetRangeRow2(range);
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			Microsoft.Office.Interop.Excel.Range range2 = range;
			while (range2 != null && P_5.Count < 50)
			{
				string text = GetRangeRow2(range2);
				if (string.IsNullOrEmpty(text) || !hashSet.Add(text))
				{
					break;
				}
				P_5.Add(GetRangeRow(P_0, range2));
				Microsoft.Office.Interop.Excel.Range range3 = P_4.TrackComObject(CS_8_locals_6.rangeField6.FindNext(range2));
				if (range3 == null || string.Equals(GetRangeRow2(range3), b, StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				range2 = range3;
			}
			return true;
		}
		catch (Exception ex)
		{
			P_6 = ex.GetType().Name + ": " + ex.Message;
			return false;
		}
	}

	private static List<object> ScanRangeValues(Worksheet P_0, Microsoft.Office.Interop.Excel.Range P_1, string P_2, bool P_3, ComObjectTracker P_4)
	{
		_G_c__DisplayClass19_0 CS_8_locals_5 = new _G_c__DisplayClass19_0();
		CS_8_locals_5.rangeField2 = P_1;
		List<object> list = new List<object>();
		StringComparison comparisonType = (P_3 ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
		object obj = lEYJYSoNMC(() => CS_8_locals_5.rangeField2.Value2);
		int num = LgrJEVbBNo(() => CS_8_locals_5.rangeField2.Row);
		int num2 = LgrJEVbBNo(() => CS_8_locals_5.rangeField2.Column);
		if (obj is object[,] array)
		{
			int lowerBound = array.GetLowerBound(0);
			int upperBound = array.GetUpperBound(0);
			int lowerBound2 = array.GetLowerBound(1);
			int upperBound2 = array.GetUpperBound(1);
			for (int num3 = lowerBound; num3 <= upperBound; num3++)
			{
				if (list.Count >= 50)
				{
					break;
				}
				for (int num4 = lowerBound2; num4 <= upperBound2; num4++)
				{
					if (list.Count >= 50)
					{
						break;
					}
					if (DjOJiRNjpT(array[num3, num4]).IndexOf(P_2, comparisonType) >= 0)
					{
						int num5 = num + (num3 - lowerBound);
						int num6 = num2 + (num4 - lowerBound2);
						Microsoft.Office.Interop.Excel.Range range = P_4.TrackComObject((Microsoft.Office.Interop.Excel.Range)(dynamic)P_0.Cells[num5, num6]);
						list.Add(GetRangeRow(P_0, range));
					}
				}
			}
			return list;
		}
		if (DjOJiRNjpT(obj).IndexOf(P_2, comparisonType) >= 0)
		{
			Microsoft.Office.Interop.Excel.Range range2 = P_4.TrackComObject((Microsoft.Office.Interop.Excel.Range)(dynamic)CS_8_locals_5.rangeField2.Cells[1, 1]);
			list.Add(GetRangeRow(P_0, range2));
		}
		return list;
	}

	private static object GetRangeRow(Worksheet P_0, Microsoft.Office.Interop.Excel.Range P_1)
	{
		_G_c__DisplayClass20_0 CS_8_locals_8 = new _G_c__DisplayClass20_0();
		CS_8_locals_8.rangeField3 = P_1;
		return new
		{
			sheetName = P_0.Name,
			address = tqdJKIVpyV(CS_8_locals_8.rangeField3),
			row = LgrJEVbBNo(() => CS_8_locals_8.rangeField3.Row),
			column = LgrJEVbBNo(() => CS_8_locals_8.rangeField3.Column),
			value = GetRangeValue(CS_8_locals_8.rangeField3),
			text = GetRangeAddress(CS_8_locals_8.rangeField3),
			formula = hjGJjwaZBM(delegate
			{
				dynamic val;
				if (!(((dynamic)CS_8_locals_8.rangeField3.Formula == null) ? true : false))
				{
					if (_G_o__20.toStringCallSite6 == null)
					{
						_G_o__20.toStringCallSite6 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Excel", null, typeof(AiConfigBootstrap2), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					val = _G_o__20.toStringCallSite6.Target(_G_o__20.toStringCallSite6, CS_8_locals_8.rangeField3.Formula);
				}
				else
				{
					val = string.Empty;
				}
				return val;
			})
		};
	}

	private static string GetRangeRow2(Microsoft.Office.Interop.Excel.Range P_0)
	{
		_G_c__DisplayClass21_0 CS_8_locals_3 = new _G_c__DisplayClass21_0();
		CS_8_locals_3.rangeField4 = P_0;
		return LgrJEVbBNo(() => CS_8_locals_3.rangeField4.Row).ToString(CultureInfo.InvariantCulture) + ":" + LgrJEVbBNo(() => CS_8_locals_3.rangeField4.Column).ToString(CultureInfo.InvariantCulture);
	}

	private static string DjOJiRNjpT(object P_0)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		if (P_0 is DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
		}
		return Convert.ToString(P_0, CultureInfo.InvariantCulture) ?? string.Empty;
	}

	private static Name FindNamedRange(Workbook P_0, ComObjectTracker P_1, string P_2, string P_3)
	{
		string text = (string.IsNullOrWhiteSpace(P_3) ? "workbook_or_worksheet" : P_3.Trim().ToLowerInvariant());
		if (text == "workbook" || text == "workbook_or_worksheet")
		{
			_G_c__DisplayClass23_0 CS_8_locals_9 = new _G_c__DisplayClass23_0();
			CS_8_locals_9.names = P_1.TrackComObject(P_0.Names);
			for (int i = 1; i <= TryEvaluateInt(() => CS_8_locals_9.names.Count); i++)
			{
				Name name = P_1.TrackComObject(CS_8_locals_9.names.Item(i, Type.Missing, Type.Missing));
				if (ObsJQvCckC(name, P_2))
				{
					return name;
				}
			}
		}
		if (text == "worksheet" || text == "workbook_or_worksheet")
		{
			_G_c__DisplayClass23_1 CS_8_locals_10 = new _G_c__DisplayClass23_1();
			CS_8_locals_10.nuvVuVXaUZa = P_1.TrackComObject(P_0.Worksheets);
			for (int num = 1; num <= TryEvaluateInt(() => CS_8_locals_10.nuvVuVXaUZa.Count); num++)
			{
				_G_c__DisplayClass23_2 CS_8_locals_11 = new _G_c__DisplayClass23_2();
				Worksheet worksheet = P_1.TrackComObject((Worksheet)(dynamic)CS_8_locals_10.nuvVuVXaUZa[num]);
				CS_8_locals_11.names = P_1.TrackComObject(worksheet.Names);
				for (int num2 = 1; num2 <= TryEvaluateInt(() => CS_8_locals_11.names.Count); num2++)
				{
					Name name2 = P_1.TrackComObject(CS_8_locals_11.names.Item(num2, Type.Missing, Type.Missing));
					if (ObsJQvCckC(name2, P_2))
					{
						return name2;
					}
				}
			}
		}
		return null;
	}

	private static bool ObsJQvCckC(Name P_0, string P_1)
	{
		_G_c__DisplayClass24_0 obj = new _G_c__DisplayClass24_0();
		obj.gMvVuTWFYAE = P_0;
		string text;
		string a = (text = hjGJjwaZBM(() => obj.gMvVuTWFYAE.Name));
		int num = text.LastIndexOf('!');
		if (num >= 0 && num < text.Length - 1)
		{
			text = text.Substring(num + 1);
		}
		if (!string.Equals(a, P_1, StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(text, P_1, StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static bool GetFullName2(string P_0, out string P_1, out string P_2)
	{
		P_1 = string.Empty;
		P_2 = string.Empty;
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		int num = P_0.LastIndexOf('!');
		if (num <= 0 || num >= P_0.Length - 1)
		{
			return false;
		}
		P_1 = P_0.Substring(0, num).Trim();
		P_2 = P_0.Substring(num + 1).Trim();
		if (P_1.StartsWith("'", StringComparison.Ordinal) && P_1.EndsWith("'", StringComparison.Ordinal))
		{
			P_1 = P_1.Substring(1, P_1.Length - 2).Replace("''", "'");
		}
		int num2 = P_1.LastIndexOf(']');
		if (num2 >= 0 && num2 < P_1.Length - 1)
		{
			P_1 = P_1.Substring(num2 + 1);
		}
		if (!string.IsNullOrWhiteSpace(P_1))
		{
			return !string.IsNullOrWhiteSpace(P_2);
		}
		return false;
	}

	private static bool skJJrNGIkj(Workbook P_0, string P_1)
	{
		_G_c__DisplayClass26_0 CS_8_locals_3 = new _G_c__DisplayClass26_0();
		CS_8_locals_3.workbook = P_0;
		if (!string.Equals(hjGJjwaZBM(() => CS_8_locals_3.workbook.Name), P_1, StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(hjGJjwaZBM(() => CS_8_locals_3.workbook.FullName), P_1, StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static bool GetWorkbookFullName5(Worksheet P_0, Workbook P_1)
	{
		try
		{
			return P_0.Parent is Workbook workbook && skJJrNGIkj(workbook, P_1.FullName);
		}
		catch
		{
			return false;
		}
	}

	private static object GetRangeValue(Microsoft.Office.Interop.Excel.Range P_0)
	{
		try
		{
			object value = P_0.Value2;
			if (value is DateTime dateTime)
			{
				return dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
			}
			return value;
		}
		catch
		{
			return null;
		}
	}

	private static string GetRangeAddress(Microsoft.Office.Interop.Excel.Range P_0)
	{
		_G_c__DisplayClass29_0 CS_8_locals_4 = new _G_c__DisplayClass29_0();
		CS_8_locals_4.rangeField5 = P_0;
		string text = hjGJjwaZBM(delegate
		{
			dynamic val;
			if (!(((dynamic)CS_8_locals_4.rangeField5.Text == null) ? true : false))
			{
				if (_G_o__29.toStringCallSite5 == null)
				{
					_G_o__29.toStringCallSite5 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "WPS 表格", null, typeof(AiConfigBootstrap2), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				val = _G_o__29.toStringCallSite5.Target(_G_o__29.toStringCallSite5, CS_8_locals_4.rangeField5.Text);
			}
			else
			{
				val = string.Empty;
			}
			return val;
		});
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		object obj = GetRangeValue(CS_8_locals_4.rangeField5);
		if (obj != null)
		{
			return Convert.ToString(obj, CultureInfo.InvariantCulture);
		}
		return string.Empty;
	}

	private static string tqdJKIVpyV(Microsoft.Office.Interop.Excel.Range P_0)
	{
		_G_c__DisplayClass30_0 obj = new _G_c__DisplayClass30_0();
		obj.ccQVufmDjvb = P_0;
		return hjGJjwaZBM(() => obj.ccQVufmDjvb.get_Address((object)false, (object)false, XlReferenceStyle.xlA1, Type.Missing, Type.Missing));
	}

	private static int LgrJEVbBNo(Func<int> P_0)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return 0;
		}
	}

	private static int TryEvaluateInt(Func<int> P_0)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return 0;
		}
	}

	private static bool TryEvaluateBool(Func<bool> P_0)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return false;
		}
	}

	private static string hjGJjwaZBM(Func<string> P_0)
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

	private static object lEYJYSoNMC(Func<object> P_0)
	{
		try
		{
			return P_0();
		}
		catch
		{
			return null;
		}
	}

	private static string GetSpreadsheetHostName()
	{
		if (!WordTableToolService.IsWps)
		{
			return "Excel";
		}
		return "WPS 表格";
	}

	public AiConfigBootstrap2()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
