using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WordWindowInfo;
using CPAHelper.Agent.Abstractions;
using AiSseStreamService3;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService4;
using DocumentLifecycleGuard;

namespace AiHelper_19;

internal sealed class AiHelper_19
{
	private readonly WordTableToolService4 _wordTableToolService4;

	public AiHelper_19() : this(new WordTableToolService4())
	{
		SseStreamInitializer.InitializeRuntime();
	}

	public AiHelper_19(WordTableToolService4 P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_wordTableToolService4 = P_0 ?? throw new ArgumentNullException("executor");
	}

	public AgentInstructionContext QhF3fbjxg1()
	{
		WordWindowInfo current = DocumentLifecycleGuard.Current;
		if (current != null)
		{
			return sIN3MDmcKU(current);
		}
		try
		{
			return _wordTableToolService4.MdXJlVhPku("instruction_context", delegate(Application app)
			{
				AgentInstructionContext agentInstructionContext = new AgentInstructionContext();
				Document activeDocument = app.ActiveDocument;
				if (activeDocument != null)
				{
					agentInstructionContext.Extra["instruction_context"] = activeDocument.Name ?? string.Empty;
					agentInstructionContext.Extra["documentName"] = activeDocument.FullName ?? string.Empty;
					Dictionary<string, string> extra = agentInstructionContext.Extra;
					string key = "documentPath";
					object IncludeFootnotesAndEndnotes = Type.Missing;
					extra[key] = activeDocument.ComputeStatistics(WdStatistic.wdStatisticPages, ref IncludeFootnotesAndEndnotes).ToString();
					Dictionary<string, string> extra2 = agentInstructionContext.Extra;
					string key2 = "currentPage";
					IncludeFootnotesAndEndnotes = Type.Missing;
					extra2[key2] = activeDocument.ComputeStatistics(WdStatistic.wdStatisticWords, ref IncludeFootnotesAndEndnotes).ToString();
					oH03bF09Vf(agentInstructionContext.Years, activeDocument.Name);
				}
				Selection selection = app.Selection;
				if (selection != null)
				{
					string text = selection.Range?.Text ?? string.Empty;
					agentInstructionContext.Extra["selectionRangeStart"] = text.Length.ToString();
					if (!string.IsNullOrWhiteSpace(text))
					{
						oH03bF09Vf(agentInstructionContext.Years, text);
					}
				}
				agentInstructionContext.Years.Sort(StringComparer.OrdinalIgnoreCase);
				return agentInstructionContext;
			});
		}
		catch
		{
			return new AgentInstructionContext();
		}
	}

	private static AgentInstructionContext sIN3MDmcKU(WordWindowInfo P_0)
	{
		AgentInstructionContext agentInstructionContext = new AgentInstructionContext();
		if (P_0 == null)
		{
			return agentInstructionContext;
		}
		if (!string.IsNullOrWhiteSpace(P_0.DocumentName))
		{
			agentInstructionContext.Extra["documentName"] = P_0.DocumentName;
			oH03bF09Vf(agentInstructionContext.Years, P_0.DocumentName);
		}
		if (!string.IsNullOrWhiteSpace(P_0.DocumentFullName))
		{
			agentInstructionContext.Extra["documentPath"] = P_0.DocumentFullName;
		}
		if (P_0.PageNumber > 0)
		{
			agentInstructionContext.Extra["currentPage"] = P_0.PageNumber.ToString();
		}
		if (P_0.SelectionStart > 0 || P_0.SelectionEnd > 0)
		{
			agentInstructionContext.Extra["selectionRangeStart"] = P_0.SelectionStart.ToString();
			agentInstructionContext.Extra["selectionRangeEnd"] = P_0.SelectionEnd.ToString();
		}
		agentInstructionContext.Extra["selectionTextLength"] = P_0.SelectionTextLength.ToString();
		agentInstructionContext.Years.Sort(StringComparer.OrdinalIgnoreCase);
		return agentInstructionContext;
	}

	private static void oH03bF09Vf(List<string> P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return;
		}
		foreach (Match item in Regex.Matches(P_1, "(?:19|20)\\d{2}"))
		{
			if (!P_0.Contains(item.Value))
			{
				P_0.Add(item.Value);
			}
		}
	}
}
