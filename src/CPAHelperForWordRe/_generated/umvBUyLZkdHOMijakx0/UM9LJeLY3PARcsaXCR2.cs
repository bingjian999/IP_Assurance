using System.Runtime.CompilerServices;
using CPAHelper.Agent.Abstractions;
using ndRERvVtEjasqN2cQqiN;

namespace umvBUyLZkdHOMijakx0;

internal sealed class UM9LJeLY3PARcsaXCR2
{
	[CompilerGenerated]
	private int Xx3LbndFEP;

	[CompilerGenerated]
	private double gl8LS780sf;

	[CompilerGenerated]
	private double oirLwSpKS6;

	[CompilerGenerated]
	private double T6fLtaKAXJ;

	[CompilerGenerated]
	private int zciLLLqyI2;

	[CompilerGenerated]
	private int vuGLssGfpe;

	public int ContextWindowTokens
	{
		[CompilerGenerated]
		get
		{
			return Xx3LbndFEP;
		}
		[CompilerGenerated]
		set
		{
			Xx3LbndFEP = value;
		}
	}

	public double TriggerRatio
	{
		[CompilerGenerated]
		get
		{
			return gl8LS780sf;
		}
		[CompilerGenerated]
		set
		{
			gl8LS780sf = value;
		}
	}

	public double TargetRatio
	{
		[CompilerGenerated]
		get
		{
			return oirLwSpKS6;
		}
		[CompilerGenerated]
		set
		{
			oirLwSpKS6 = value;
		}
	}

	public double HardLimitRatio
	{
		[CompilerGenerated]
		get
		{
			return T6fLtaKAXJ;
		}
		[CompilerGenerated]
		set
		{
			T6fLtaKAXJ = value;
		}
	}

	public int RecentMessageCount
	{
		[CompilerGenerated]
		get
		{
			return zciLLLqyI2;
		}
		[CompilerGenerated]
		set
		{
			zciLLLqyI2 = value;
		}
	}

	public int TimeoutSeconds
	{
		[CompilerGenerated]
		get
		{
			return vuGLssGfpe;
		}
		[CompilerGenerated]
		set
		{
			vuGLssGfpe = value;
		}
	}

	public void qBDLf9An1g()
	{
		if (ContextWindowTokens <= 0)
		{
			ContextWindowTokens = 200000;
		}
		if (TriggerRatio <= 0.0 || TriggerRatio >= 1.0)
		{
			TriggerRatio = 0.7;
		}
		if (TargetRatio <= 0.0 || TargetRatio >= 1.0 || TargetRatio >= TriggerRatio)
		{
			TargetRatio = 0.45;
		}
		if (HardLimitRatio <= 0.0 || HardLimitRatio >= 1.0 || HardLimitRatio <= TriggerRatio)
		{
			HardLimitRatio = 0.9;
		}
		if (RecentMessageCount <= 0)
		{
			RecentMessageCount = 12;
		}
		if (TimeoutSeconds <= 0)
		{
			TimeoutSeconds = 30;
		}
	}

	public AgentSummaryOptions uMGLMZ4rvG()
	{
		qBDLf9An1g();
		return new AgentSummaryOptions
		{
			ContextWindowTokens = ContextWindowTokens,
			TriggerRatio = TriggerRatio,
			TargetRatio = TargetRatio,
			HardLimitRatio = HardLimitRatio,
			RecentMessageCount = RecentMessageCount,
			TimeoutSeconds = TimeoutSeconds
		};
	}

	public UM9LJeLY3PARcsaXCR2()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		Xx3LbndFEP = 200000;
		gl8LS780sf = 0.7;
		oirLwSpKS6 = 0.45;
		T6fLtaKAXJ = 0.9;
		zciLLLqyI2 = 12;
		vuGLssGfpe = 30;
	}
}
