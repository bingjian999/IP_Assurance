using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_10;

internal sealed class Helper_10
{
	[CompilerGenerated]
	private readonly string PEpBpqhFor;

	[CompilerGenerated]
	private readonly string sYSBO49R9W;

	[CompilerGenerated]
	private readonly bool IrZBnoR4go;

	[CompilerGenerated]
	private readonly string bMLB7nKMiZ;

	[CompilerGenerated]
	private readonly bool WqxB5B83TT;

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
			return sYSBO49R9W;
		}
	}

	internal bool OldFileDeleted
	{
		[CompilerGenerated]
		get
		{
			return IrZBnoR4go;
		}
	}

	internal string OldFileDeleteError
	{
		[CompilerGenerated]
		get
		{
			return bMLB7nKMiZ;
		}
	}

	internal bool IsNoChange
	{
		[CompilerGenerated]
		get
		{
			return WqxB5B83TT;
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
		SseStreamInitializer.AlBVL0oCCKQ();
		PEpBpqhFor = P_0 ?? string.Empty;
		sYSBO49R9W = P_1 ?? string.Empty;
		IrZBnoR4go = P_2;
		bMLB7nKMiZ = P_3 ?? string.Empty;
		WqxB5B83TT = P_4;
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
