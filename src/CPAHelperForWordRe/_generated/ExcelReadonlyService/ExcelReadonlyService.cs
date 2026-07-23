using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using CPAHelper.Agent.Abstractions;
using AiSseStreamService3;
using Microsoft.Extensions.AI;
using SseStreamInitializer;
using AiConfigBootstrap2;
using AiHelper_5;

namespace ExcelReadonlyService;

internal sealed class ExcelReadonlyService : IToolProvider
{
	private readonly AiConfigBootstrap2 _aiConfigBootstrap2;

	public string ProviderName => "ExcelRead";

	public ExcelReadonlyService(AiConfigBootstrap2 P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_aiConfigBootstrap2 = P_0 ?? throw new ArgumentNullException("excelService");
	}

	public IList<AITool> GetTools()
	{
		BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
		return new List<AITool>
		{
			FlX9lCO2pe("GetCurrentExcelContext", "get_current_excel_context", bindingFlags),
			FlX9lCO2pe("ListOpenExcelWorkbooks", "list_open_excel_workbooks", bindingFlags),
			FlX9lCO2pe("GetExcelSheetList", "get_excel_sheet_list", bindingFlags),
			FlX9lCO2pe("PreviewExcelSheet", "preview_excel_sheet", bindingFlags),
			FlX9lCO2pe("PreviewExcelRange", "preview_excel_range", bindingFlags),
			FlX9lCO2pe("GetExcelRangeValuesAndFormulas", "get_excel_range_values_and_formulas", bindingFlags),
			FlX9lCO2pe("GetCurrentSelectionValuesAndFormulas", "get_current_selection_values_and_formulas", bindingFlags),
			FlX9lCO2pe("FindExcelCells", "find_excel_cells", bindingFlags),
			FlX9lCO2pe("ManageExcelNamedRange", "manage_excel_named_range", bindingFlags)
		};
	}

	public IList<ToolMetadata> GetToolMetadata()
	{
		List<ToolMetadata> list = new List<ToolMetadata>();
		list.Add(new ToolMetadata("get_current_excel_context", new string[2]
		{
			"excel.core",
			"excel.read"
		}, "只读获取当前 Excel/WPS 表格工作簿、工作表和选区信息。"));
		list.Add(new ToolMetadata("list_open_excel_workbooks", new string[2]
		{
			"excel.core",
			"excel.read"
		}, "只读列出当前 Excel/WPS 表格实例中所有已打开的工作簿。"));
		list.Add(new ToolMetadata("get_excel_sheet_list", new string[2]
		{
			"excel.core",
			"excel.read"
		}, "只读列出指定或当前 Excel/WPS 工作簿中的所有工作表。"));
		list.Add(new ToolMetadata("preview_excel_sheet", new string[2]
		{
			"excel.core",
			"excel.read"
		}, "只读预览 Excel/WPS 工作表 UsedRange 前后若干行；用于底稿概览。"));
		list.Add(new ToolMetadata("preview_excel_range", new string[2]
		{
			"excel.core",
			"excel.read"
		}, "只读预览当前选区或指定 Excel/WPS 区域；用于底稿定位。"));
		list.Add(new ToolMetadata("get_excel_range_values_and_formulas", new string[1] { "excel.read" }, "只读精确读取指定 Excel/WPS 区域中的值和公式。"));
		list.Add(new ToolMetadata("get_current_selection_values_and_formulas", new string[2]
		{
			"excel.core",
			"excel.read"
		}, "只读读取当前 Excel/WPS 选区中的值和公式。"));
		list.Add(new ToolMetadata("find_excel_cells", new string[1] { "excel.read" }, "只读在 Excel/WPS 工作表中查找包含指定值的单元格。"));
		list.Add(new ToolMetadata("manage_excel_named_range", new string[2]
		{
			"excel.read",
			"excel.structure"
		}, "只读查询 Excel/WPS 名称区域；仅支持 action=get，不创建不修改。"));
		return list;
	}

	private AITool FlX9lCO2pe(string P_0, string P_1, BindingFlags P_2)
	{
		return AIFunctionFactory.Create(GetType().GetMethod(P_0, P_2), this, new AIFunctionFactoryOptions
		{
			Name = P_1
		});
	}

	[Description("只读获取当前 Excel/WPS 表格上下文，包括当前活动工作簿、活动工作表和当前选区地址。Office Word 连接 Excel，WPS 文字连接 WPS 表格。")]
	private AiHelper_5 GetCurrentExcelContext()
	{
		return _aiConfigBootstrap2.GetCurrentExcelContext();
	}

	[Description("只读列出当前 Excel/WPS 表格实例中所有已打开的工作簿，包括名称、路径、活动状态和基本属性。")]
	private AiHelper_5 ListOpenExcelWorkbooks()
	{
		return _aiConfigBootstrap2.ListOpenExcelWorkbooks();
	}

	[Description("只读列出 Excel/WPS 表格工作簿中的所有工作表名称。可选指定工作簿名，未指定时使用当前活动工作簿。")]
	private AiHelper_5 GetExcelSheetList(string workbookName = "")
	{
		return _aiConfigBootstrap2.GetExcelSheetList(workbookName);
	}

	[Description("只读快速预览指定工作表或当前工作表的 UsedRange，以及前几行/后几行内容；用于底稿概览，不修改工作簿。")]
	private AiHelper_5 PreviewExcelSheet(string sheetName = "", int headRows = 20, int tailRows = 20, int maxColumns = 40, bool includeFormulas = false, bool includeFormats = false, string workbookName = "")
	{
		return _aiConfigBootstrap2.dhorWDIpcu(sheetName, workbookName, EYw9NTHISY(headRows, 20), EYw9NTHISY(tailRows, 20), EYw9NTHISY(maxColumns, 40), includeFormulas, includeFormats);
	}

	[Description("只读快速预览当前选区或指定区域的前几行和后几行。sheetName/rangeAddress 为空时默认使用当前 Excel/WPS 表格选区；不修改工作簿。")]
	private AiHelper_5 PreviewExcelRange(string sheetName = "", string rangeAddress = "", int headRows = 15, int tailRows = 10, int maxColumns = 30, bool visibleOnly = false, bool includeFormulas = true, bool includeFormats = false, string workbookName = "")
	{
		return _aiConfigBootstrap2.PreviewExcelRange(sheetName, rangeAddress, workbookName, EYw9NTHISY(headRows, 15), EYw9NTHISY(tailRows, 10), EYw9NTHISY(maxColumns, 30), visibleOnly, includeFormulas, includeFormats);
	}

	[Description("只读按工作表名称和单元格区域地址读取 Excel/WPS 表格区域中的值和公式。可选指定工作簿名，未指定时默认使用当前活动工作簿。")]
	private AiHelper_5 GetExcelRangeValuesAndFormulas(string sheetName, string address, string workbookName = "", bool visibleOnly = false)
	{
		return _aiConfigBootstrap2.GetExcelRangeValuesAndFormulas(sheetName, address, workbookName, visibleOnly);
	}

	[Description("只读读取当前 Excel/WPS 表格选区中的值和公式。适合用户已经手动选中底稿区域时直接查看。")]
	private AiHelper_5 GetCurrentSelectionValuesAndFormulas()
	{
		return _aiConfigBootstrap2.GetCurrentSelectionValuesAndFormulas();
	}

	[Description("只读在 Excel/WPS 表格工作表中查找包含指定值的单元格，最多返回 50 个结果。")]
	private AiHelper_5 FindExcelCells(string sheetName, string searchValue, bool matchCase = false, string workbookName = "")
	{
		return _aiConfigBootstrap2.kpSrxrdvDy(sheetName, searchValue, matchCase, workbookName);
	}

	[Description("只读查询 Excel/WPS 表格名称区域。仅支持 action=get；不会创建或更新名称区域。nameScope 可选 workbook、worksheet 或留空。")]
	private AiHelper_5 ManageExcelNamedRange(string action, string name, string workbookName = "", string nameScope = "")
	{
		return _aiConfigBootstrap2.nCmrdMSTjR(action, name, workbookName, nameScope);
	}

	private static int EYw9NTHISY(int P_0, int P_1)
	{
		if (P_0 > 0)
		{
			return P_0;
		}
		return P_1;
	}
}
