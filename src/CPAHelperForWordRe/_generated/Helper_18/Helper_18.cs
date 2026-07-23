using System;
using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;

namespace Helper_18;

internal sealed class Helper_18
{
	[CompilerGenerated]
	private string wSLtKyZfHV;

	[CompilerGenerated]
	private bool tjqtEPb984;

	[CompilerGenerated]
	private bool a4Ct2VEL1O;

	public string TabName
	{
		[CompilerGenerated]
		get
		{
			return wSLtKyZfHV;
		}
		[CompilerGenerated]
		set
		{
			wSLtKyZfHV = value;
		}
	}

	public bool AutoUpdate
	{
		[CompilerGenerated]
		get
		{
			return tjqtEPb984;
		}
		[CompilerGenerated]
		set
		{
			tjqtEPb984 = value;
		}
	}

	public bool DisableAutomaticStyleUpdate
	{
		[CompilerGenerated]
		get
		{
			return a4Ct2VEL1O;
		}
		[CompilerGenerated]
		set
		{
			a4Ct2VEL1O = value;
		}
	}

	public void qyxtULiSoA()
	{
		if (string.IsNullOrWhiteSpace(TabName))
		{
			TabName = "IP_Assurance";
			return;
		}
		TabName = TabName.Trim();
		if (string.Equals(TabName, "IPA", StringComparison.OrdinalIgnoreCase) ||
		    string.Equals(TabName, "IP_Assurance", StringComparison.OrdinalIgnoreCase))
		{
			TabName = "IP_Assurance";
		}
	}

	public Helper_18()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		wSLtKyZfHV = "IP_Assurance";
		a4Ct2VEL1O = true;
	}
}
