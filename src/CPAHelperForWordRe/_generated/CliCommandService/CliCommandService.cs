using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using AiSseStreamService3;
using Microsoft.Extensions.AI;
using SseStreamInitializer;
using AiSseStreamService;
using AiHelper_5;

namespace CliCommandService;

internal sealed class CliCommandService : IToolProvider
{
	private sealed class peDdSyhbcuP9ypMdOqG
	{
		[CompilerGenerated]
		private int? RPqhSjYT1e;

		[CompilerGenerated]
		private bool CbnhwE3cv6;

		[CompilerGenerated]
		private string gaFhtZlfcl;

		[CompilerGenerated]
		private string VZjhLAAR2l;

		public int? ExitCode
		{
			[CompilerGenerated]
			get
			{
				return RPqhSjYT1e;
			}
			[CompilerGenerated]
			set
			{
				RPqhSjYT1e = value;
			}
		}

		public bool TimedOut
		{
			[CompilerGenerated]
			get
			{
				return CbnhwE3cv6;
			}
			[CompilerGenerated]
			set
			{
				CbnhwE3cv6 = value;
			}
		}

		public string Stdout
		{
			[CompilerGenerated]
			get
			{
				return gaFhtZlfcl;
			}
			[CompilerGenerated]
			set
			{
				gaFhtZlfcl = value;
			}
		}

		public string Stderr
		{
			[CompilerGenerated]
			get
			{
				return VZjhLAAR2l;
			}
			[CompilerGenerated]
			set
			{
				VZjhLAAR2l = value;
			}
		}

		public peDdSyhbcuP9ypMdOqG()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_0
	{
		public int MxxhlOwAEk;

		public string tuAhNGVMve;

		public string IX2hmNBk9j;

		public _G_c__DisplayClass10_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal peDdSyhbcuP9ypMdOqG aq7hsMdx5p()
		{
			return fju9MgoMBK(Anl9Ssa2lw(), "-NoProfile -NonInteractive -ExecutionPolicy Bypass -EncodedCommand " + tuAhNGVMve, IX2hmNBk9j, ebt9Z4TRlv(MxxhlOwAEk));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass11_0
	{
		public string IvihGyHUks;

		public int gnGhCfkl5Z;

		public string OZohpSLKEr;

		public string xaghOgYyIZ;

		public _G_c__DisplayClass11_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal peDdSyhbcuP9ypMdOqG sFLhokwAUy()
		{
			return fju9MgoMBK(OZohpSLKEr, IvihGyHUks ?? string.Empty, xaghOgYyIZ, ebt9Z4TRlv(gnGhCfkl5Z));
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass17_0
	{
		public StringBuilder f79h59X2Ay;

		public StringBuilder i1hhcwGXZT;

		public _G_c__DisplayClass17_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void oWShnDR48h(object _, DataReceivedEventArgs args)
		{
			Q4y9bTxUyf(f79h59X2Ay, args.Data);
		}

		internal void cxlh7wwFYQ(object _, DataReceivedEventArgs args)
		{
			Q4y9bTxUyf(i1hhcwGXZT, args.Data);
		}
	}

	private readonly IHostContext gh79twQlGS;

	public string ProviderName => "CLI";

	public CliCommandService(IHostContext P_0)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		gh79twQlGS = P_0 ?? throw new ArgumentNullException("hostContext");
	}

	public IList<AITool> GetTools()
	{
		BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
		return new List<AITool>
		{
			Tcw92PFFCn("RunCliCommand", "run_cli_command", bindingFlags),
			Tcw92PFFCn("RunExeCommand", "run_exe_command", bindingFlags)
		};
	}

	public IList<ToolMetadata> GetToolMetadata()
	{
		List<ToolMetadata> list = new List<ToolMetadata>();
		list.Add(new ToolMetadata("run_cli_command", new string[3]
		{
			"cli",
			"risk.filesystem",
			"risk.high"
		}, "执行非交互式 Windows PowerShell 命令；用于文件/脚本辅助，不绕过 Word 专用工具。"));
		list.Add(new ToolMetadata("run_exe_command", new string[3]
		{
			"cli",
			"risk.filesystem",
			"risk.high"
		}, "直接执行非交互式 Windows 可执行文件；不经过 shell，不绕过 Word 专用工具。"));
		return list;
	}

	private AITool Tcw92PFFCn(string P_0, string P_1, BindingFlags P_2)
	{
		return AIFunctionFactory.Create(GetType().GetMethod(P_0, P_2), this, new AIFunctionFactoryOptions
		{
			Name = P_1
		});
	}

	[Description("在 Windows 上运行非交互式 PowerShell 命令。默认工作目录为当前 Word 文档所在目录；用于文件处理或调用脚本，不用于绕过已有 Word/Excel 专用工具。")]
	private async Task<AiHelper_5> RunCliCommand([Description("要执行的非交互式 PowerShell 命令文本。")] string command, [Description("工作目录，可为空；相对路径基于当前 Word 文档所在目录。")] string cwd = "", [Description("超时时间，秒。默认30，最大120。")] int timeoutSeconds = 30)
	{
		_G_c__DisplayClass10_0 CS_8_locals_8 = new _G_c__DisplayClass10_0();
		CS_8_locals_8.MxxhlOwAEk = timeoutSeconds;
		if (string.IsNullOrWhiteSpace(command))
		{
			return AiHelper_5.QSD9OKWs4n("CLI", "RunCliCommand");
		}
		if (AMR9fi0nye(command))
		{
			return AiHelper_5.QSD9OKWs4n("run_cli_command", "RunExeCommand");
		}
		try
		{
			CS_8_locals_8.IX2hmNBk9j = sAl94Dv122(cwd);
			CS_8_locals_8.tuAhNGVMve = Convert.ToBase64String(Encoding.Unicode.GetBytes(command));
			peDdSyhbcuP9ypMdOqG peDdSyhbcuP9ypMdOqG2 = await Task.Run(() => fju9MgoMBK(Anl9Ssa2lw(), "run_exe_command" + CS_8_locals_8.tuAhNGVMve, CS_8_locals_8.IX2hmNBk9j, ebt9Z4TRlv(CS_8_locals_8.MxxhlOwAEk))).ConfigureAwait(continueOnCapturedContext: false);
			KOn9w5WDpJ("run_cli_command", command, CS_8_locals_8.IX2hmNBk9j, peDdSyhbcuP9ypMdOqG2);
			return AiHelper_5.nt99CvEC4m("cli", new
			{
				command = command,
				cwd = CS_8_locals_8.IX2hmNBk9j,
				exitCode = peDdSyhbcuP9ypMdOqG2.ExitCode,
				timedOut = peDdSyhbcuP9ypMdOqG2.TimedOut,
				stdout = peDdSyhbcuP9ypMdOqG2.Stdout,
				stderr = peDdSyhbcuP9ypMdOqG2.Stderr
			});
		}
		catch (Exception ex)
		{
			return AiHelper_5.g7A9nYlk8v("risk.filesystem", "risk.high", ex);
		}
	}

	[Description("直接执行非交互式 Windows 可执行文件，不经过 shell。不支持管道、重定向等 shell 语法；用于调用确定的本地工具，不用于绕过已有 Word/Excel 专用工具。")]
	private async Task<AiHelper_5> RunExeCommand([Description("可执行文件路径或 PATH 中的程序名。")] string exePath, [Description("原样传给 exe 的参数字符串；不会经过 shell 解析。")] string arguments = "", [Description("工作目录，可为空；相对路径基于当前 Word 文档所在目录。")] string cwd = "", [Description("超时时间，秒。默认30，最大120。")] int timeoutSeconds = 30)
	{
		_G_c__DisplayClass11_0 CS_8_locals_15 = new _G_c__DisplayClass11_0();
		CS_8_locals_15.IvihGyHUks = arguments;
		CS_8_locals_15.gnGhCfkl5Z = timeoutSeconds;
		if (string.IsNullOrWhiteSpace(exePath))
		{
			return AiHelper_5.QSD9OKWs4n("执行非交互式 Windows PowerShell 命令；用于文件/脚本辅助，不绕过 Word 专用工具。", "run_exe_command");
		}
		try
		{
			CS_8_locals_15.xaghOgYyIZ = sAl94Dv122(cwd);
			CS_8_locals_15.OZohpSLKEr = hku9jRL7Cj(exePath, CS_8_locals_15.xaghOgYyIZ);
			peDdSyhbcuP9ypMdOqG peDdSyhbcuP9ypMdOqG2 = await Task.Run(() => fju9MgoMBK(CS_8_locals_15.OZohpSLKEr, CS_8_locals_15.IvihGyHUks ?? string.Empty, CS_8_locals_15.xaghOgYyIZ, ebt9Z4TRlv(CS_8_locals_15.gnGhCfkl5Z))).ConfigureAwait(continueOnCapturedContext: false);
			KOn9w5WDpJ("cli", CS_8_locals_15.OZohpSLKEr + "risk.filesystem" + (CS_8_locals_15.IvihGyHUks ?? string.Empty), CS_8_locals_15.xaghOgYyIZ, peDdSyhbcuP9ypMdOqG2);
			return AiHelper_5.nt99CvEC4m("risk.high", new
			{
				exePath = CS_8_locals_15.OZohpSLKEr,
				arguments = (CS_8_locals_15.IvihGyHUks ?? string.Empty),
				cwd = CS_8_locals_15.xaghOgYyIZ,
				exitCode = peDdSyhbcuP9ypMdOqG2.ExitCode,
				timedOut = peDdSyhbcuP9ypMdOqG2.TimedOut,
				stdout = peDdSyhbcuP9ypMdOqG2.Stdout,
				stderr = peDdSyhbcuP9ypMdOqG2.Stderr
			});
		}
		catch (Exception ex)
		{
			return AiHelper_5.g7A9nYlk8v("直接执行非交互式 Windows 可执行文件；不经过 shell，不绕过 Word 专用工具。", "Agent", ex);
		}
	}

	private string sAl94Dv122(string P_0)
	{
		string text = null;
		string projectPath = gh79twQlGS.GetProjectPath();
		if (!string.IsNullOrWhiteSpace(projectPath))
		{
			text = (Directory.Exists(projectPath) ? projectPath : Path.GetDirectoryName(projectPath));
		}
		if (string.IsNullOrWhiteSpace(text) || !Directory.Exists(text))
		{
			text = AiSseStreamService.XOes64flqb("Agent", "CliWorkspace");
		}
		string path = (string.IsNullOrWhiteSpace(P_0) ? text : (Path.IsPathRooted(P_0) ? P_0 : Path.Combine(text, P_0)));
		path = Path.GetFullPath(path);
		if (!Directory.Exists(path))
		{
			throw new DirectoryNotFoundException("cwd does not exist: " + path);
		}
		return path;
	}

	private static string hku9jRL7Cj(string P_0, string P_1)
	{
		string text = (P_0 ?? string.Empty).Trim();
		if (!ihI9Y9MXOP(text))
		{
			return text;
		}
		string path = (Path.IsPathRooted(text) ? text : Path.Combine(P_1, text));
		path = Path.GetFullPath(path);
		if (!File.Exists(path))
		{
			throw new FileNotFoundException("exePath does not exist.", path);
		}
		return path;
	}

	private static bool ihI9Y9MXOP(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			if (P_0.IndexOf('\\') < 0 && P_0.IndexOf('/') < 0)
			{
				return P_0.IndexOf(':') >= 0;
			}
			return true;
		}
		return false;
	}

	private static int ebt9Z4TRlv(int P_0)
	{
		if (P_0 > 0)
		{
			return Math.Min(P_0, 120);
		}
		return 30;
	}

	private static bool AMR9fi0nye(string P_0)
	{
		string text = " " + (P_0 ?? string.Empty).Replace("\\r", " ").Replace("\n", " ").ToLowerInvariant() + " ";
		string[] array = new string[10]
		{
			"format ",
			"diskpart",
			"shutdown",
			"restart-computer",
			"bcdedit",
			"set-executionpolicy",
			"reg delete",
			"net user",
			"schtasks ",
			"cipher /w"
		};
		foreach (string value in array)
		{
			if (text.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return true;
			}
		}
		return false;
	}

	private static peDdSyhbcuP9ypMdOqG fju9MgoMBK(string P_0, string P_1, string P_2, int P_3)
	{
		_G_c__DisplayClass17_0 CS_8_locals_8 = new _G_c__DisplayClass17_0();
		CS_8_locals_8.f79h59X2Ay = new StringBuilder();
		CS_8_locals_8.i1hhcwGXZT = new StringBuilder();
		using Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			FileName = P_0,
			Arguments = (P_1 ?? string.Empty),
			WorkingDirectory = P_2,
			UseShellExecute = false,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			CreateNoWindow = true,
			StandardOutputEncoding = Encoding.UTF8,
			StandardErrorEncoding = Encoding.UTF8
		};
		process.OutputDataReceived += delegate(object _, DataReceivedEventArgs args)
		{
			Q4y9bTxUyf(CS_8_locals_8.f79h59X2Ay, args.Data);
		};
		process.ErrorDataReceived += delegate(object _, DataReceivedEventArgs args)
		{
			Q4y9bTxUyf(CS_8_locals_8.i1hhcwGXZT, args.Data);
		};
		process.Start();
		process.BeginOutputReadLine();
		process.BeginErrorReadLine();
		if (!process.WaitForExit(P_3 * 1000))
		{
			try
			{
				process.Kill();
			}
			catch
			{
			}
			return new peDdSyhbcuP9ypMdOqG
			{
				ExitCode = null,
				TimedOut = true,
				Stdout = CS_8_locals_8.f79h59X2Ay.ToString(),
				Stderr = CS_8_locals_8.i1hhcwGXZT.ToString()
			};
		}
		process.WaitForExit();
		return new peDdSyhbcuP9ypMdOqG
		{
			ExitCode = process.ExitCode,
			TimedOut = false,
			Stdout = CS_8_locals_8.f79h59X2Ay.ToString(),
			Stderr = CS_8_locals_8.i1hhcwGXZT.ToString()
		};
	}

	private static void Q4y9bTxUyf(StringBuilder P_0, string P_1)
	{
		if (P_1 != null && P_0.Length < 20000)
		{
			string text = P_1 + Environment.NewLine;
			int num = 20000 - P_0.Length;
			P_0.Append((text.Length <= num) ? text : text.Substring(0, num));
		}
	}

	private static string Anl9Ssa2lw()
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
		string text = (string.IsNullOrWhiteSpace(folderPath) ? null : Path.Combine(folderPath, "System32", "WindowsPowerShell", "v1.0", "powershell.exe"));
		if (string.IsNullOrWhiteSpace(text) || !File.Exists(text))
		{
			return "powershell.exe";
		}
		return text;
	}

	private static void KOn9w5WDpJ(string P_0, string P_1, string P_2, peDdSyhbcuP9ypMdOqG P_3)
	{
		try
		{
			string path = AiSseStreamService.mSfs9VWIdb("Agent", "cli-logs");
			string text = string.Format("[{0:yyyy-MM-dd HH:mm:ss.fff}] backend={1} cwd=\"{2}\" exit={3} timeout={4} command={5}", DateTime.Now, P_0, P_2, P_3.ExitCode, P_3.TimedOut, P_1.Replace("\\r", "\\\\r").Replace("\n", "\\\\n"));
			File.AppendAllText(Path.Combine(path, "cli-tool.log"), text + Environment.NewLine, Encoding.UTF8);
		}
		catch
		{
		}
	}
}
