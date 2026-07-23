using System.Runtime.CompilerServices;
using CPAHelper.Agent.Abstractions;
using SseStreamInitializer;

namespace AiHelper_9;

internal sealed class AiHelper_9
{
	[CompilerGenerated]
	private int _contextWindowTokens;

	[CompilerGenerated]
	private double _triggerRatio;

	[CompilerGenerated]
	private double oirLwSpKS6;

	[CompilerGenerated]
	private double _hardLimitRatio;

	[CompilerGenerated]
	private int zciLLLqyI2;

	[CompilerGenerated]
	private int vuGLssGfpe;

	public int ContextWindowTokens
	{
		[CompilerGenerated]
		get
		{
			return _contextWindowTokens;
		}
		[CompilerGenerated]
		set
		{
			_contextWindowTokens = value;
		}
	}

	public double TriggerRatio
	{
		[CompilerGenerated]
		get
		{
			return _triggerRatio;
		}
		[CompilerGenerated]
		set
		{
			_triggerRatio = value;
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
			return _hardLimitRatio;
		}
		[CompilerGenerated]
		set
		{
			_hardLimitRatio = value;
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

	public AiHelper_9()
	{
		SseStreamInitializer.InitializeRuntime();
		_contextWindowTokens = 200000;
		_triggerRatio = 0.7;
		oirLwSpKS6 = 0.45;
		_hardLimitRatio = 0.9;
		zciLLLqyI2 = 12;
		vuGLssGfpe = 30;
	}
}
