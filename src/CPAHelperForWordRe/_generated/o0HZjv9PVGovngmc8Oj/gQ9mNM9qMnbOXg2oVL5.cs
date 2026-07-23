using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using CPAHelper.Agent.Abstractions;
using dBbrDaJdu6miTY58iu3;
using HGQOfdJM683ZRGDQPGT;
using hJKpQrVSwRwMyI2RyDQN;
using Microsoft.Extensions.AI;
using ndRERvVtEjasqN2cQqiN;
using zXs8EW9GijtvoeAXF0q;

namespace o0HZjv9PVGovngmc8Oj;

internal sealed class gQ9mNM9qMnbOXg2oVL5 : IToolProvider
{
	private readonly cIMGclJxkpROIkrXJFx NdH9vpTUbm;

	public string ProviderName => "VBA";

	public gQ9mNM9qMnbOXg2oVL5(cIMGclJxkpROIkrXJFx P_0)
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		NdH9vpTUbm = P_0 ?? throw new ArgumentNullException("vbaService");
	}

	public IList<AITool> GetTools()
	{
		BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
		return new List<AITool>
		{
			z4m9AMMS1P("ValidateVbaSnippet", "validate_vba_snippet", bindingFlags),
			z4m9AMMS1P("RunVbaSnippet", "run_vba_snippet", bindingFlags)
		};
	}

	public IList<ToolMetadata> GetToolMetadata()
	{
		List<ToolMetadata> list = new List<ToolMetadata>();
		list.Add(new ToolMetadata("validate_vba_snippet", new string[2]
		{
			"vba",
			"word.read"
		}, "验证 Word VBA 代码片段是否合法；运行 VBA 前必须先调用。"));
		list.Add(new ToolMetadata("run_vba_snippet", new string[3]
		{
			"vba",
			"risk.confirm",
			"risk.high"
		}, "高风险兜底：确认后在本轮目标 Word 文档运行已验证的 VBA；不替代专用 Word 工具。"));
		return list;
	}

	private AITool z4m9AMMS1P(string P_0, string P_1, BindingFlags P_2)
	{
		return AIFunctionFactory.Create(GetType().GetMethod(P_0, P_2), this, new AIFunctionFactoryOptions
		{
			Name = P_1
		});
	}

	[Description("验证 Word VBA 代码片段是否合法，检查是否包含无参数 Sub 入口。run_vba_snippet 前必须先调用此工具；VBA 是专用 Word 工具覆盖不了时的高风险兜底。")]
	private rU18qH9owXvBsPZ0iiU ValidateVbaSnippet([Description("完整的 Word VBA 代码字符串，必须包含一个无参数 Sub ... End Sub 入口过程。")] string vbaCode)
	{
		string text = NdH9vpTUbm.R1tJz1VIhA(vbaCode);
		if (text.StartsWith("验证通过", StringComparison.Ordinal))
		{
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("VBA snippet is valid.", new
			{
				valid = true,
				warning = false,
				details = text
			});
		}
		if (text.StartsWith("验证警告", StringComparison.Ordinal))
		{
			return rU18qH9owXvBsPZ0iiU.x719pAJQxl("VBA snippet has a warning.", new
			{
				valid = true,
				warning = true,
				details = text
			});
		}
		return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("VBA snippet is invalid.", "invalid_vba", new
		{
			valid = false,
			details = text
		});
	}

	[Description("在本轮 Agent 请求开始时的目标 Word 文档中注入并执行 VBA 代码片段。高风险兜底工具：仅在专用 Word 工具无法完成明确任务时使用；执行前必须先调用 validate_vba_snippet。宿主会在真正执行前弹出原生确认窗口，请不要要求用户在聊天中再次输入确认。代码执行完毕后临时模块会自动清理。需要 Word 信任中心已启用『信任对 VBA 工程对象模型的访问』。")]
	private rU18qH9owXvBsPZ0iiU RunVbaSnippet([Description("完整的 Word VBA 代码字符串，必须包含一个无参数 Sub ... End Sub 入口过程，且代码应面向本轮目标文档。")] string vbaCode)
	{
		try
		{
			string text = NdH9vpTUbm.R1tJz1VIhA(vbaCode);
			if (!text.StartsWith("验证通过", StringComparison.Ordinal) && !text.StartsWith("验证警告", StringComparison.Ordinal))
			{
				return rU18qH9owXvBsPZ0iiU.QSD9OKWs4n("VBA snippet is invalid.", "invalid_vba", new
				{
					details = text
				});
			}
			string details = NdH9vpTUbm.zer3R7UqTK(vbaCode);
			return rU18qH9owXvBsPZ0iiU.nt99CvEC4m("VBA snippet executed.", new
			{
				executed = true,
				details = details
			});
		}
		catch (Exception ex)
		{
			if (TEu80pJf6BRff8wZLuh.r6TJwEkoUc(ex.GetBaseException()?.Message) || TEu80pJf6BRff8wZLuh.r6TJwEkoUc(ex.Message))
			{
				return TEu80pJf6BRff8wZLuh.dclJSetxGY(ex.GetBaseException()?.Message ?? ex.Message);
			}
			return rU18qH9owXvBsPZ0iiU.g7A9nYlk8v("VBA execution failed", "vba_error", ex);
		}
	}
}
