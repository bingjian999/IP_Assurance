using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using WordWindowInfo;
using AiConfigBootstrap;
using WordAgentRuntimeGuard2;
using AiSseStreamService3;
using AiTargetBinder;
using Microsoft.Office.Interop.Word;
using Microsoft.Vbe.Interop;
using SseStreamInitializer;
using WordTableToolService;
using WordTableToolService4;
using DocumentLifecycleGuard;

namespace WpsVbaCompatService;

internal sealed class WpsVbaCompatService
{
	private sealed class oWlUArVDqaaXQZpBqfXR
	{
		[CompilerGenerated]
		private string BtvVDPrWS4J;

		[CompilerGenerated]
		private bool y8NVDAxPHEo;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return BtvVDPrWS4J;
			}
			[CompilerGenerated]
			set
			{
				BtvVDPrWS4J = value;
			}
		}

		public bool HasParameters
		{
			[CompilerGenerated]
			get
			{
				return y8NVDAxPHEo;
			}
			[CompilerGenerated]
			set
			{
				y8NVDAxPHEo = value;
			}
		}

		public oWlUArVDqaaXQZpBqfXR()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}
	}

	private sealed class RP3HO3VDvRbxmE03MaWl
	{
		[CompilerGenerated]
		private string A9WVDW25cbh;

		[CompilerGenerated]
		private string gjVVD07TgyQ;

		[CompilerGenerated]
		private int BHaVDkXuHxH;

		[CompilerGenerated]
		private int EH6VDxhQrLa;

		public string DocumentName
		{
			[CompilerGenerated]
			get
			{
				return A9WVDW25cbh;
			}
			[CompilerGenerated]
			set
			{
				A9WVDW25cbh = value;
			}
		}

		public string DocumentFullName
		{
			[CompilerGenerated]
			get
			{
				return gjVVD07TgyQ;
			}
			[CompilerGenerated]
			set
			{
				gjVVD07TgyQ = value;
			}
		}

		public int SelectionStart
		{
			[CompilerGenerated]
			get
			{
				return BHaVDkXuHxH;
			}
			[CompilerGenerated]
			set
			{
				BHaVDkXuHxH = value;
			}
		}

		public int SelectionEnd
		{
			[CompilerGenerated]
			get
			{
				return EH6VDxhQrLa;
			}
			[CompilerGenerated]
			set
			{
				EH6VDxhQrLa = value;
			}
		}

		public RP3HO3VDvRbxmE03MaWl()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_0
	{
		public Document rT4VTRei3P0;

		public _G_c__DisplayClass10_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal string hsFVDdt9S8M()
		{
			return rT4VTRei3P0.FullName;
		}

		internal string xBlVDz1T55k()
		{
			return rT4VTRei3P0.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass14_0<T>
	{
		public Func<Microsoft.Office.Interop.Word.Application, T> action;

		public _G_c__DisplayClass14_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal T t6bVTVe8sHA(Microsoft.Office.Interop.Word.Application app)
		{
			string text = WordAgentRuntimeGuard2.gEFJbNPT5J(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				throw new InvalidOperationException(text);
			}
			return action(app);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass6_0
	{
		public string ORRVT9wefPb;

		public oWlUArVDqaaXQZpBqfXR EWVVT67lkGF;

		public _G_c__DisplayClass6_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal string AT2VTB4UV5B(Microsoft.Office.Interop.Word.Application app)
		{
			if (WordTableToolService.IsWps)
			{
				throw new InvalidOperationException("WPS 文字不支持通过 Word VBIDE 注入并运行 VBA 代码。");
			}
			Document document = null;
			VBProject vBProject = null;
			VBComponent vBComponent = null;
			RP3HO3VDvRbxmE03MaWl rP3HO3VDvRbxmE03MaWl = null;
			WdAlertLevel displayAlerts = WdAlertLevel.wdAlertsAll;
			bool flag = false;
			bool flag2 = false;
			try
			{
				rP3HO3VDvRbxmE03MaWl = R8K36HVqty(app);
				document = DocumentLifecycleGuard.zrqujYgRXw(app);
				if (document == null)
				{
					throw new InvalidOperationException("未找到活动 Word 文档，请先打开一个文档再运行代码。");
				}
				m3O39L5WZm(app, document);
				displayAlerts = app.DisplayAlerts;
				app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
				flag2 = true;
				vBProject = document.VBProject;
				string text = "IPAssuranceWordModule_" + Guid.NewGuid().ToString("N").Substring(0, 8);
				vBComponent = vBProject.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule);
				vBComponent.Name = text;
				vBComponent.CodeModule.AddFromString(ORRVT9wefPb);
				try
				{
					app.UndoRecord.StartCustomRecord("AI执行Word VBA代码片段");
					flag = true;
				}
				catch
				{
				}
				try
				{
					string macroName = text + "." + EWVVT67lkGF.Name;
					object varg = Type.Missing;
					object varg2 = Type.Missing;
					object varg3 = Type.Missing;
					object varg4 = Type.Missing;
					object varg5 = Type.Missing;
					object varg6 = Type.Missing;
					object varg7 = Type.Missing;
					object varg8 = Type.Missing;
					object varg9 = Type.Missing;
					object varg10 = Type.Missing;
					object varg11 = Type.Missing;
					object varg12 = Type.Missing;
					object varg13 = Type.Missing;
					object varg14 = Type.Missing;
					object varg15 = Type.Missing;
					object varg16 = Type.Missing;
					object varg17 = Type.Missing;
					object varg18 = Type.Missing;
					object varg19 = Type.Missing;
					object varg20 = Type.Missing;
					object varg21 = Type.Missing;
					object varg22 = Type.Missing;
					object varg23 = Type.Missing;
					object varg24 = Type.Missing;
					object varg25 = Type.Missing;
					object varg26 = Type.Missing;
					object varg27 = Type.Missing;
					object varg28 = Type.Missing;
					object varg29 = Type.Missing;
					object varg30 = Type.Missing;
					app.Run(macroName, ref varg, ref varg2, ref varg3, ref varg4, ref varg5, ref varg6, ref varg7, ref varg8, ref varg9, ref varg10, ref varg11, ref varg12, ref varg13, ref varg14, ref varg15, ref varg16, ref varg17, ref varg18, ref varg19, ref varg20, ref varg21, ref varg22, ref varg23, ref varg24, ref varg25, ref varg26, ref varg27, ref varg28, ref varg29, ref varg30);
				}
				catch (Exception ex)
				{
					throw new InvalidOperationException("VBA 代码执行错误：" + ex.Message, ex);
				}
				RQW3BQ6tRO(vBProject, vBComponent);
				vBComponent = null;
				return "VBA 代码执行成功。\\n入口过程：" + EWVVT67lkGF.Name + "\\n文档：" + document.Name;
			}
			catch (COMException ex2)
			{
				RQW3BQ6tRO(vBProject, vBComponent);
				vBComponent = null;
				if (ex2.Message.IndexOf("programmatic access", StringComparison.OrdinalIgnoreCase) >= 0 || ex2.ErrorCode == -2146827284)
				{
					throw new InvalidOperationException("无法访问 VBA 工程。请在 Word 文件→选项→信任中心→信任中心设置→宏设置 中勾选『信任对 VBA 工程对象模型的访问』。", ex2);
				}
				throw new InvalidOperationException("COM 错误：" + ex2.Message, ex2);
			}
			catch (UnauthorizedAccessException innerException)
			{
				RQW3BQ6tRO(vBProject, vBComponent);
				vBComponent = null;
				throw new InvalidOperationException("权限不足，请启用信任访问 VBA 工程。", innerException);
			}
			catch (InvalidOperationException)
			{
				RQW3BQ6tRO(vBProject, vBComponent);
				vBComponent = null;
				throw;
			}
			catch (Exception ex4)
			{
				RQW3BQ6tRO(vBProject, vBComponent);
				vBComponent = null;
				throw new InvalidOperationException("VBA 执行失败：" + ex4.Message, ex4);
			}
			finally
			{
				if (flag)
				{
					try
					{
						app.UndoRecord.EndCustomRecord();
					}
					catch
					{
					}
				}
				if (flag2)
				{
					try
					{
						app.DisplayAlerts = displayAlerts;
					}
					catch
					{
					}
				}
				nsM3uRTY4F(app, rP3HO3VDvRbxmE03MaWl);
				Rx73TfSp8r(vBComponent);
				Rx73TfSp8r(vBProject);
			}
		}
	}

	private static readonly Regex nQm3IPMNhu;

	private readonly AiTargetBinder G6T3iub9oa;

	private readonly WordTableToolService4 D8c3HsQYl2;

	public WpsVbaCompatService() : this(null)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
	}

	public WpsVbaCompatService(AiTargetBinder P_0)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		G6T3iub9oa = P_0;
		D8c3HsQYl2 = new WordTableToolService4(P_0);
	}

	public string R1tJz1VIhA(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return "验证失败：VBA 代码不能为空。";
		}
		oWlUArVDqaaXQZpBqfXR oWlUArVDqaaXQZpBqfXR2 = yHA3Vrmjt9(P_0);
		if (oWlUArVDqaaXQZpBqfXR2 == null)
		{
			return "验证失败：代码中未找到有效的 Sub 过程。请确保代码包含一个 Sub ... End Sub 入口。";
		}
		if (oWlUArVDqaaXQZpBqfXR2.HasParameters)
		{
			return "验证失败：入口 Sub 不能带参数。请使用无参数 Sub，并在代码内部读取 ActiveDocument 或 Selection。";
		}
		if (P_0.IndexOf("End Sub", StringComparison.OrdinalIgnoreCase) < 0)
		{
			return "验证失败：代码中未找到 End Sub。";
		}
		if (P_0.IndexOf("Application.ScreenUpdating", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return "验证警告：代码中包含 Application.ScreenUpdating，执行后请确保恢复屏幕刷新。检测到的入口过程名：" + oWlUArVDqaaXQZpBqfXR2.Name;
		}
		return "验证通过。入口过程名：" + oWlUArVDqaaXQZpBqfXR2.Name;
	}

	public string zer3R7UqTK(string P_0)
	{
		_G_c__DisplayClass6_0 CS_8_locals_9 = new _G_c__DisplayClass6_0();
		CS_8_locals_9.ORRVT9wefPb = P_0;
		if (string.IsNullOrWhiteSpace(CS_8_locals_9.ORRVT9wefPb))
		{
			return "执行失败：VBA 代码不能为空。";
		}
		CS_8_locals_9.EWVVT67lkGF = yHA3Vrmjt9(CS_8_locals_9.ORRVT9wefPb);
		if (CS_8_locals_9.EWVVT67lkGF == null)
		{
			return "执行失败：代码中未找到有效的 Sub 过程。请确保代码包含一个 Sub ... End Sub 入口。";
		}
		if (CS_8_locals_9.EWVVT67lkGF.HasParameters)
		{
			return "执行失败：入口 Sub 不能带参数。";
		}
		return rki3gClQ9S("执行Word VBA代码片段", delegate(Microsoft.Office.Interop.Word.Application app)
		{
			if (WordTableToolService.IsWps)
			{
				throw new InvalidOperationException("验证失败：VBA 代码不能为空。");
			}
			Document document = null;
			VBProject vBProject = null;
			VBComponent vBComponent = null;
			RP3HO3VDvRbxmE03MaWl rP3HO3VDvRbxmE03MaWl = null;
			WdAlertLevel displayAlerts = WdAlertLevel.wdAlertsAll;
			bool flag = false;
			bool flag2 = false;
			try
			{
				rP3HO3VDvRbxmE03MaWl = R8K36HVqty(app);
				document = DocumentLifecycleGuard.zrqujYgRXw(app);
				if (document == null)
				{
					throw new InvalidOperationException("验证失败：代码中未找到有效的 Sub 过程。请确保代码包含一个 Sub ... End Sub 入口。");
				}
				m3O39L5WZm(app, document);
				displayAlerts = app.DisplayAlerts;
				app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
				flag2 = true;
				vBProject = document.VBProject;
				string text = "验证失败：入口 Sub 不能带参数。请使用无参数 Sub，并在代码内部读取 ActiveDocument 或 Selection。" + Guid.NewGuid().ToString("End Sub").Substring(0, 8);
				vBComponent = vBProject.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule);
				vBComponent.Name = text;
				vBComponent.CodeModule.AddFromString(CS_8_locals_9.ORRVT9wefPb);
				try
				{
					app.UndoRecord.StartCustomRecord("验证失败：代码中未找到 End Sub。");
					flag = true;
				}
				catch
				{
				}
				try
				{
					string macroName = text + "Application.ScreenUpdating" + CS_8_locals_9.EWVVT67lkGF.Name;
					object varg = Type.Missing;
					object varg2 = Type.Missing;
					object varg3 = Type.Missing;
					object varg4 = Type.Missing;
					object varg5 = Type.Missing;
					object varg6 = Type.Missing;
					object varg7 = Type.Missing;
					object varg8 = Type.Missing;
					object varg9 = Type.Missing;
					object varg10 = Type.Missing;
					object varg11 = Type.Missing;
					object varg12 = Type.Missing;
					object varg13 = Type.Missing;
					object varg14 = Type.Missing;
					object varg15 = Type.Missing;
					object varg16 = Type.Missing;
					object varg17 = Type.Missing;
					object varg18 = Type.Missing;
					object varg19 = Type.Missing;
					object varg20 = Type.Missing;
					object varg21 = Type.Missing;
					object varg22 = Type.Missing;
					object varg23 = Type.Missing;
					object varg24 = Type.Missing;
					object varg25 = Type.Missing;
					object varg26 = Type.Missing;
					object varg27 = Type.Missing;
					object varg28 = Type.Missing;
					object varg29 = Type.Missing;
					object varg30 = Type.Missing;
					app.Run(macroName, ref varg, ref varg2, ref varg3, ref varg4, ref varg5, ref varg6, ref varg7, ref varg8, ref varg9, ref varg10, ref varg11, ref varg12, ref varg13, ref varg14, ref varg15, ref varg16, ref varg17, ref varg18, ref varg19, ref varg20, ref varg21, ref varg22, ref varg23, ref varg24, ref varg25, ref varg26, ref varg27, ref varg28, ref varg29, ref varg30);
				}
				catch (Exception ex)
				{
					throw new InvalidOperationException("验证警告：代码中包含 Application.ScreenUpdating，执行后请确保恢复屏幕刷新。检测到的入口过程名：" + ex.Message, ex);
				}
				RQW3BQ6tRO(vBProject, vBComponent);
				vBComponent = null;
				return "验证通过。入口过程名：" + CS_8_locals_9.EWVVT67lkGF.Name + "执行失败：VBA 代码不能为空。" + document.Name;
			}
			catch (COMException ex2)
			{
				RQW3BQ6tRO(vBProject, vBComponent);
				vBComponent = null;
				if (ex2.Message.IndexOf("执行失败：代码中未找到有效的 Sub 过程。请确保代码包含一个 Sub ... End Sub 入口。", StringComparison.OrdinalIgnoreCase) >= 0 || ex2.ErrorCode == -2146827284)
				{
					throw new InvalidOperationException("执行失败：入口 Sub 不能带参数。", ex2);
				}
				throw new InvalidOperationException("执行Word VBA代码片段" + ex2.Message, ex2);
			}
			catch (UnauthorizedAccessException innerException)
			{
				RQW3BQ6tRO(vBProject, vBComponent);
				vBComponent = null;
				throw new InvalidOperationException("vba_", innerException);
			}
			catch (InvalidOperationException)
			{
				RQW3BQ6tRO(vBProject, vBComponent);
				vBComponent = null;
				throw;
			}
			catch (Exception ex4)
			{
				RQW3BQ6tRO(vBProject, vBComponent);
				vBComponent = null;
				throw new InvalidOperationException("[VbaExecution] " + ex4.Message, ex4);
			}
			finally
			{
				if (flag)
				{
					try
					{
						app.UndoRecord.EndCustomRecord();
					}
					catch
					{
					}
				}
				if (flag2)
				{
					try
					{
						app.DisplayAlerts = displayAlerts;
					}
					catch
					{
					}
				}
				nsM3uRTY4F(app, rP3HO3VDvRbxmE03MaWl);
				Rx73TfSp8r(vBComponent);
				Rx73TfSp8r(vBProject);
			}
		});
	}

	private static oWlUArVDqaaXQZpBqfXR yHA3Vrmjt9(string P_0)
	{
		Match match = nQm3IPMNhu.Match(P_0 ?? string.Empty);
		if (!match.Success)
		{
			return null;
		}
		return new oWlUArVDqaaXQZpBqfXR
		{
			Name = match.Groups[2].Value,
			HasParameters = (match.Groups.Count > 3 && !string.IsNullOrWhiteSpace(match.Groups[3].Value))
		};
	}

	private static void RQW3BQ6tRO(VBProject P_0, VBComponent P_1)
	{
		try
		{
			if (P_0 != null && P_1 != null)
			{
				P_0.VBComponents.Remove(P_1);
			}
		}
		catch
		{
		}
	}

	private static void m3O39L5WZm(Microsoft.Office.Interop.Word.Application P_0, Document P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		P_1.Activate();
		WordWindowInfo current = DocumentLifecycleGuard.Current;
		if (!DocumentLifecycleGuard.Se3uYFg09e(P_1) || current == null)
		{
			return;
		}
		try
		{
			int start = P_1.Content.Start;
			int end = P_1.Content.End;
			int num = Math.Max(start, Math.Min(current.SelectionStart, end));
			int num2 = Math.Max(num, Math.Min(current.SelectionEnd, end));
			object Start = num;
			object End = num2;
			P_1.Range(ref Start, ref End).Select();
		}
		catch
		{
		}
	}

	private static RP3HO3VDvRbxmE03MaWl R8K36HVqty(Microsoft.Office.Interop.Word.Application P_0)
	{
		try
		{
			_G_c__DisplayClass10_0 CS_8_locals_4 = new _G_c__DisplayClass10_0();
			CS_8_locals_4.rT4VTRei3P0 = P_0?.ActiveDocument;
			Selection selection = P_0?.Selection;
			if (CS_8_locals_4.rT4VTRei3P0 == null || selection?.Range == null)
			{
				return null;
			}
			return new RP3HO3VDvRbxmE03MaWl
			{
				DocumentFullName = eFq3DxlR5e(() => CS_8_locals_4.rT4VTRei3P0.FullName),
				DocumentName = eFq3DxlR5e(() => CS_8_locals_4.rT4VTRei3P0.Name),
				SelectionStart = selection.Range.Start,
				SelectionEnd = selection.Range.End
			};
		}
		catch
		{
			return null;
		}
	}

	private static void nsM3uRTY4F(Microsoft.Office.Interop.Word.Application P_0, RP3HO3VDvRbxmE03MaWl P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		try
		{
			Document document = DocumentLifecycleGuard.zrqujYgRXw(P_0, (!string.IsNullOrWhiteSpace(P_1.DocumentFullName)) ? P_1.DocumentFullName : P_1.DocumentName);
			document.Activate();
			int start = document.Content.Start;
			int end = document.Content.End;
			int num = Math.Max(start, Math.Min(P_1.SelectionStart, end));
			int num2 = Math.Max(num, Math.Min(P_1.SelectionEnd, end));
			object Start = num;
			object End = num2;
			document.Range(ref Start, ref End).Select();
		}
		catch
		{
		}
	}

	private static string eFq3DxlR5e(Func<string> P_0)
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

	private static void Rx73TfSp8r(object P_0)
	{
		try
		{
			if (P_0 != null && Marshal.IsComObject(P_0))
			{
				Marshal.FinalReleaseComObject(P_0);
			}
		}
		catch
		{
		}
	}

	private fdJEaP38mFSOHURh7Yw rki3gClQ9S<fdJEaP38mFSOHURh7Yw>(string P_0, Func<Microsoft.Office.Interop.Word.Application, fdJEaP38mFSOHURh7Yw> P_1)
	{
		_G_c__DisplayClass14_0<fdJEaP38mFSOHURh7Yw> CS_8_locals_2 = new _G_c__DisplayClass14_0<fdJEaP38mFSOHURh7Yw>();
		CS_8_locals_2.action = P_1;
		try
		{
			return D8c3HsQYl2.MdXJlVhPku("失败：" + P_0, delegate(Microsoft.Office.Interop.Word.Application app)
			{
				string text = WordAgentRuntimeGuard2.gEFJbNPT5J(app);
				if (!string.IsNullOrWhiteSpace(text))
				{
					throw new InvalidOperationException(text);
				}
				return CS_8_locals_2.action(app);
			});
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.ujWsURly3F("失败：" + P_0 + "失败：" + ex.Message);
			throw new InvalidOperationException(P_0 + "失败：" + ex.Message, ex);
		}
	}

	static WpsVbaCompatService()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		nQm3IPMNhu = new Regex("^\\s*(?:(Public|Private|Friend|Static)\\s+|\\s+)*Sub\\s+([\\p{L}_][\\p{L}\\p{N}_]*)\\s*(?:\\(([^)]*)\\))?", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
	}
}
