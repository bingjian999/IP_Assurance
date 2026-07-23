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
	private bool _successBacking;

	[CompilerGenerated]
	private string _statusBacking;

	[CompilerGenerated]
	private string _messageBacking;

	[CompilerGenerated]
	private object _dataBacking;

	[CompilerGenerated]
	private Helper_11 _errorBacking;

	public bool success
	{
		[CompilerGenerated]
		get
		{
			return _successBacking;
		}
		[CompilerGenerated]
		set
		{
			_successBacking = value;
		}
	}

	public string status
	{
		[CompilerGenerated]
		get
		{
			return _statusBacking;
		}
		[CompilerGenerated]
		set
		{
			_statusBacking = value;
		}
	}

	public string message
	{
		[CompilerGenerated]
		get
		{
			return _messageBacking;
		}
		[CompilerGenerated]
		set
		{
			_messageBacking = value;
		}
	}

	public object data
	{
		[CompilerGenerated]
		get
		{
			return _dataBacking;
		}
		[CompilerGenerated]
		set
		{
			_dataBacking = value;
		}
	}

	public Helper_11 error
	{
		[CompilerGenerated]
		get
		{
			return _errorBacking;
		}
		[CompilerGenerated]
		set
		{
			_errorBacking = value;
		}
	}

	public static AiHelper_5 CreateSuccess(string P_0, object P_1 = null)
	{
		return new AiHelper_5
		{
			success = true,
			status = "success",
			message = P_0,
			data = P_1
		};
	}

	public static AiHelper_5 CreateWarning(string P_0, object P_1 = null)
	{
		return new AiHelper_5
		{
			success = true,
			status = "warning",
			message = P_0,
			data = P_1
		};
	}

	public static AiHelper_5 CreateError(string P_0, string P_1 = "tool_error", object P_2 = null)
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

	public static AiHelper_5 CreateExceptionError(string P_0, string P_1, Exception P_2, object P_3 = null)
	{
		Exception ex = P_2?.GetBaseException() ?? P_2;
		string text = (string.IsNullOrWhiteSpace(ex?.Message) ? "Unknown error." : ex.Message);
		return CreateError((P_0 ?? "Tool failed") + ": " + text, P_1, new
		{
			exception = ex?.GetType().Name,
			message = text,
			hResult = ((ex == null) ? null : ("0x" + ex.HResult.ToString("X8", CultureInfo.InvariantCulture))),
			details = P_3
		});
	}

	public AiHelper_5()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
