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
	private bool _disableAutomaticStyleUpdate;

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
			return _disableAutomaticStyleUpdate;
		}
		[CompilerGenerated]
		set
		{
			_disableAutomaticStyleUpdate = value;
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
		SseStreamInitializer.InitializeRuntime();
		wSLtKyZfHV = "IP_Assurance";
		_disableAutomaticStyleUpdate = true;
	}
}
