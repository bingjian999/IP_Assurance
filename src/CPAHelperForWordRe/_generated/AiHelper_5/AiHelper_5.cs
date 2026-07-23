using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Helper_11;
using AiSseStreamService3;
using SseStreamInitializer;

namespace AiHelper_5;

internal sealed class AiHelper_5
{
	[CompilerGenerated]
	private bool oFP97dtat8;

	[CompilerGenerated]
	private string SXX959Bk2v;

	[CompilerGenerated]
	private string TYy9ch4Q4M;

	[CompilerGenerated]
	private object EtS9e16MLU;

	[CompilerGenerated]
	private Helper_11 t509yrTnoC;

	public bool success
	{
		[CompilerGenerated]
		get
		{
			return oFP97dtat8;
		}
		[CompilerGenerated]
		set
		{
			oFP97dtat8 = value;
		}
	}

	public string status
	{
		[CompilerGenerated]
		get
		{
			return SXX959Bk2v;
		}
		[CompilerGenerated]
		set
		{
			SXX959Bk2v = value;
		}
	}

	public string message
	{
		[CompilerGenerated]
		get
		{
			return TYy9ch4Q4M;
		}
		[CompilerGenerated]
		set
		{
			TYy9ch4Q4M = value;
		}
	}

	public object data
	{
		[CompilerGenerated]
		get
		{
			return EtS9e16MLU;
		}
		[CompilerGenerated]
		set
		{
			EtS9e16MLU = value;
		}
	}

	public Helper_11 error
	{
		[CompilerGenerated]
		get
		{
			return t509yrTnoC;
		}
		[CompilerGenerated]
		set
		{
			t509yrTnoC = value;
		}
	}

	public static AiHelper_5 nt99CvEC4m(string P_0, object P_1 = null)
	{
		return new AiHelper_5
		{
			success = true,
			status = "success",
			message = P_0,
			data = P_1
		};
	}

	public static AiHelper_5 x719pAJQxl(string P_0, object P_1 = null)
	{
		return new AiHelper_5
		{
			success = true,
			status = "warning",
			message = P_0,
			data = P_1
		};
	}

	public static AiHelper_5 QSD9OKWs4n(string P_0, string P_1 = "tool_error", object P_2 = null)
	{
		return new AiHelper_5
		{
			success = false,
			status = "error",
			message = P_0,
			data = P_2,
			error = new Helper_11
			{
				code = P_1,
				message = P_0
			}
		};
	}

	public static AiHelper_5 g7A9nYlk8v(string P_0, string P_1, Exception P_2, object P_3 = null)
	{
		Exception ex = P_2?.GetBaseException() ?? P_2;
		string text = (string.IsNullOrWhiteSpace(ex?.Message) ? "Unknown error." : ex.Message);
		return QSD9OKWs4n((P_0 ?? "Tool failed") + ": " + text, P_1, new
		{
			exception = ex?.GetType().Name,
			message = text,
			hResult = ((ex == null) ? null : ("0x" + ex.HResult.ToString("X8", CultureInfo.InvariantCulture))),
			details = P_3
		});
	}

	public AiHelper_5()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
	}
}
