using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_10;

internal sealed class Helper_10
{
	[CompilerGenerated]
	private readonly string PEpBpqhFor;

	[CompilerGenerated]
	private readonly string _string;

	[CompilerGenerated]
	private readonly bool _bool;

	[CompilerGenerated]
	private readonly string _string;

	[CompilerGenerated]
	private readonly bool _bool;

	[CompilerGenerated]
	private readonly bool QMUBcaypD1;

	internal string OriginalPath
	{
		[CompilerGenerated]
		get
		{
			return PEpBpqhFor;
		}
	}

	internal string TargetPath
	{
		[CompilerGenerated]
		get
		{
			return _string;
		}
	}

	internal bool OldFileDeleted
	{
		[CompilerGenerated]
		get
		{
			return _bool;
		}
	}

	internal string OldFileDeleteError
	{
		[CompilerGenerated]
		get
		{
			return _string;
		}
	}

	internal bool IsNoChange
	{
		[CompilerGenerated]
		get
		{
			return _bool;
		}
	}

	internal bool IsCanceled
	{
		[CompilerGenerated]
		get
		{
			return QMUBcaypD1;
		}
	}

	private Helper_10(string P_0, string P_1, bool P_2, string P_3, bool P_4, bool P_5)
	{
		SseStreamInitializer.InitializeRuntime();
		PEpBpqhFor = P_0 ?? string.Empty;
		_string = P_1 ?? string.Empty;
		_bool = P_2;
		_string = P_3 ?? string.Empty;
		_bool = P_4;
		QMUBcaypD1 = P_5;
	}

	internal static Helper_10 ONEBochSpq(string P_0, string P_1, bool P_2, string P_3)
	{
		return new Helper_10(P_0, P_1, P_2, P_3, false, false);
	}

	internal static Helper_10 Wm0BGukN7S(string P_0)
	{
		return new Helper_10(P_0, P_0, true, null, true, false);
	}

	internal static Helper_10 UdoBCP2Rh6(string P_0)
	{
		return new Helper_10(P_0, P_0, true, null, false, true);
	}
}
