using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using CPAHelper.Agent.Contracts;
using AiConfigBootstrap;
using WordAgentRuntimeGuard2;
using AiSseStreamService3;
using AiTargetBinder;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService4;
using DocumentLifecycleGuard;

namespace HostActionDispatcher;

internal sealed class HostActionDispatcher : IHostActionProvider
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass8_0
	{
		public Range g0kVDhnm1D8;

		public _G_c__DisplayClass8_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal int JjrVDX2DsjM()
		{
			return g0kVDhnm1D8.Tables.Count;
		}

		internal int PmWVDFgx9Kt()
		{
			return g0kVDhnm1D8.Paragraphs.Count;
		}
	}

	private readonly AiTargetBinder V74JW1QeEM;

	private readonly WordTableToolService4 eQWJ06Z12e;

	private static readonly IReadOnlyList<HostActionInfo> wgFJkXRbS4;

	public HostActionDispatcher() : this(null)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
	}

	public HostActionDispatcher(AiTargetBinder P_0)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		V74JW1QeEM = P_0;
		eQWJ06Z12e = new WordTableToolService4(P_0);
	}

	public Task<IReadOnlyList<HostActionInfo>> GetActionsAsync(CancellationToken P_0 = default(CancellationToken))
	{
		return Task.FromResult(wgFJkXRbS4);
	}

	public Task<HostContextItem> InvokeAsync(string P_0, HostActionInvokeRequest P_1, CancellationToken P_2 = default(CancellationToken))
	{
		if (!string.Equals(P_0, "word.currentSelection", StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException("未知的宿主动作用：" + P_0);
		}
		return Task.FromResult(Qt0JFe6yQV());
	}

	private HostContextItem Qt0JFe6yQV()
	{
		try
		{
			return GOEJh7vQUv(delegate(Application app)
			{
				_G_c__DisplayClass8_0 CS_8_locals_7 = new _G_c__DisplayClass8_0();
				string text = WordAgentRuntimeGuard2.gEFJbNPT5J(app);
				if (!string.IsNullOrWhiteSpace(text))
				{
					throw new InvalidOperationException(text);
				}
				Document document = DocumentLifecycleGuard.zrqujYgRXw(app);
				Selection selection = app.Selection;
				if (document == null)
				{
					throw new InvalidOperationException("引用当前 Word 选区失败：");
				}
				if (selection == null || selection.Range == null)
				{
					throw new InvalidOperationException("word.currentSelection");
				}
				CS_8_locals_7.g0kVDhnm1D8 = selection.Range.Duplicate;
				int start = CS_8_locals_7.g0kVDhnm1D8.Start;
				int end = CS_8_locals_7.g0kVDhnm1D8.End;
				int num = vufJALQMfa(() => CS_8_locals_7.g0kVDhnm1D8.Tables.Count);
				int num2 = vufJALQMfa(() => CS_8_locals_7.g0kVDhnm1D8.Paragraphs.Count);
				string text2 = q9DJqvf9jN(CS_8_locals_7.g0kVDhnm1D8.Text);
				if (string.IsNullOrWhiteSpace(text2) && num <= 0 && num2 <= 0)
				{
					throw new InvalidOperationException("未知的宿主动作用：");
				}
				string text3 = BEoJPWtMP7(text2, 10);
				if (string.IsNullOrWhiteSpace(text3))
				{
					text3 = ((num2 > 0) ? "引用当前 Word 选区失败：" : "host_action_word_selection");
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("\\r");
				stringBuilder.AppendLine("\\r" + start.ToString(CultureInfo.InvariantCulture) + "\\r" + end.ToString(CultureInfo.InvariantCulture));
				stringBuilder.AppendLine(" " + text3);
				stringBuilder.AppendLine("\n" + ((num > 0) ? " " : "表格选区"));
				stringBuilder.AppendLine("..." + num.ToString(CultureInfo.InvariantCulture));
				stringBuilder.AppendLine("SelectedParagraphCount：" + num2.ToString(CultureInfo.InvariantCulture));
				stringBuilder.AppendLine("如需读取正文内容，调用 read_word_range(rangeStart, rangeEnd)。");
				stringBuilder.AppendLine("如需在空段落新建表格，调用 insert_word_table_at_range(rangeStart, rangeEnd, rows, columns)，该工具默认会插入后调用一键表格调整。");
				stringBuilder.AppendLine("如需读取复杂表格结构，调用 read_word_tables_in_range(rangeStart, rangeEnd)。");
				stringBuilder.AppendLine("如需插入复杂表格行，先读取表格模型，再调用 insert_word_table_rows_by_model。");
				stringBuilder.AppendLine("如需填写复杂表格单元格，先读取表格模型，再调用 fill_word_table_cells_by_model。");
				return new HostContextItem
				{
					Id = "word-selection-" + DateTime.Now.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture),
					Kind = "reference",
					Label = "Word选区",
					DisplayText = text3,
					PromptText = stringBuilder.ToString().Trim(),
					Metadata = new Dictionary<string, object>
					{
						["document"] = document.Name,
						["documentFullName"] = document.FullName,
						["page"] = XvEJvBp6mc(CS_8_locals_7.g0kVDhnm1D8),
						["rangeStart"] = start,
						["rangeEnd"] = end,
						["preview"] = text3,
						["characters"] = text2.Length,
						["containsTable"] = num > 0,
						["selectedTableCount"] = num,
						["selectedParagraphCount"] = num2,
						["truncated"] = text2.Length > text3.Length
					}
				};
			});
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.z7Us3dJ6Cl("引用当前 Word 选区失败：" + ex.Message);
			throw;
		}
	}

	private ckEnEPJapYGYC9Kvom5 GOEJh7vQUv<ckEnEPJapYGYC9Kvom5>(Func<Application, ckEnEPJapYGYC9Kvom5> P_0)
	{
		return eQWJ06Z12e.MdXJlVhPku("host_action_word_selection", P_0);
	}

	private static string q9DJqvf9jN(string P_0)
	{
		return (P_0 ?? string.Empty).Replace("\\r", "\\r").Replace('\a', ' ').Trim();
	}

	private static string BEoJPWtMP7(string P_0, int P_1)
	{
		string text = q9DJqvf9jN(P_0).Replace("\\r", " ").Replace("\n", " ");
		if (string.IsNullOrWhiteSpace(text))
		{
			return "表格选区";
		}
		int num = Math.Max(1, P_1);
		if (text.Length <= num)
		{
			return text;
		}
		return text.Substring(0, num) + "...";
	}

	private static int vufJALQMfa(Func<int> P_0)
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

	private static int XvEJvBp6mc(Range P_0)
	{
		try
		{
			return (P_0 != null) ? ((int)(dynamic)P_0.get_Information(WdInformation.wdActiveEndPageNumber)) : 0;
		}
		catch
		{
			return 0;
		}
	}

	static HostActionDispatcher()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		wgFJkXRbS4 = new HostActionInfo[1]
		{
			new HostActionInfo
			{
				Id = "word.currentSelection",
				Label = "引用当前选区",
				Description = "把 Word 当前选区的坐标和预览加入本次提问",
				Icon = "text-cursor-input",
				Kind = "reference"
			}
		};
	}
}
