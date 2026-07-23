using System.Collections.Generic;
using CPAHelper.Agent.Abstractions;
using AiSseStreamService3;
using SseStreamInitializer;

namespace SubAgentCatalog;

internal sealed class SubAgentCatalog : ISubAgentCatalog
{
	public string ParentInstructions => "当任务适合并行阅读、定位、复核或拆分核查时，可以启动 SubAgent 后台子 agent。SubAgent 只做只读分析和会话记忆记录，不直接修改 Word；需要写入、批注、替换或格式调整时，由主 agent 汇总建议并走现有审批链路执行。";

	public IReadOnlyList<SubAgentDefinition> GetSubAgents()
	{
		return new SubAgentDefinition[1]
		{
			new SubAgentDefinition
			{
				Name = "SubAgent",
				Description = "Word/Excel 只读后台协作者，可把中间阅读和复核结果写入会话记忆。",
				UseParentInstructions = true,
				UseRuntimeContext = true,
				EnableFileMemory = true,
				ToolGroups = new string[6]
				{
					"word.core",
					"word.read",
					"word.structure",
					"word.find",
					"excel.core",
					"excel.read"
				},
				ExcludedToolGroups = new string[7]
				{
					"word.write",
					"write",
					"risk.confirm",
					"risk.high",
					"risk.filesystem",
					"cli",
					"vba"
				},
				Instructions = "你是 SubAgent，是 Word 主 agent 的后台协作者。你的职责是并行阅读、定位、交叉复核和整理中间结论。你可以读取 Word 文档结构、章节、段落、表格、查找结果，也可以读取关联 Excel/WPS 表格信息。你可以使用会话记忆工具保存、列出、读取和搜索阅读摘要、定位结果、复核发现、分工结论和待主 agent 判断的证据片段。保持记录简洁，写明来源、范围和不确定性。你不得直接修改 Word 文档，不得写入批注、替换文本、调整格式、运行 CLI、执行 VBA 或调用任何高风险工具。若发现需要修改 Word 的事项，只返回建议、候选定位、依据和推荐改法给主 agent；OpenXML/正则返回的 paragraphIndex、charIndex 只是只读线索，不能作为 COM 写入坐标，应建议主 agent 从候选结果提取准确文本，再用 find_word_text 或 read_word_tables_in_range 获取真实 Word COM Range。"
			}
		};
	}

	public SubAgentCatalog()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
