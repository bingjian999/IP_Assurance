using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using cI7VZv9FSW3H8i8Fwpp;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;

namespace zXs8EW9GijtvoeAXF0q;

internal sealed class rU18qH9owXvBsPZ0iiU
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
	private rPVh6f9Xpxr63Ufd97u t509yrTnoC;

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

	public rPVh6f9Xpxr63Ufd97u error
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

	public static rU18qH9owXvBsPZ0iiU nt99CvEC4m(string P_0, object P_1 = null)
	{
		return new rU18qH9owXvBsPZ0iiU
		{
			success = true,
			status = "success",
			message = P_0,
			data = P_1
		};
	}

	public static rU18qH9owXvBsPZ0iiU x719pAJQxl(string P_0, object P_1 = null)
	{
		return new rU18qH9owXvBsPZ0iiU
		{
			success = true,
			status = "warning",
			message = P_0,
			data = P_1
		};
	}

	public static rU18qH9owXvBsPZ0iiU QSD9OKWs4n(string P_0, string P_1 = "tool_error", object P_2 = null)
	{
		return new rU18qH9owXvBsPZ0iiU
		{
			success = false,
			status = "error",
			message = P_0,
			data = P_2,
			error = new rPVh6f9Xpxr63Ufd97u
			{
				code = P_1,
				message = P_0
			}
		};
	}

	public static rU18qH9owXvBsPZ0iiU g7A9nYlk8v(string P_0, string P_1, Exception P_2, object P_3 = null)
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

	public rU18qH9owXvBsPZ0iiU()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
	}
}
