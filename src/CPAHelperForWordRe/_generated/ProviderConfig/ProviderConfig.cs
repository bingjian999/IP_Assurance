using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AiProviderConfig;
using AiSseStreamService3;
using Helper_23;
using SseStreamInitializer;
using AiHelper_8;
using AiHelper_9;

namespace ProviderConfig;

internal sealed class ProviderConfig
{
	[CompilerGenerated]
	private string _webUrl;

	[CompilerGenerated]
	private AiHelper_8 VHjtvPHku3;

	[CompilerGenerated]
	private List<AiProviderConfig> _providers;

	[CompilerGenerated]
	private int _activeProviderIndex;

	[CompilerGenerated]
	private Helper_23 _intranet;

	[CompilerGenerated]
	private AiHelper_9 _summary;

	public string WebUrl
	{
		[CompilerGenerated]
		get
		{
			return _webUrl;
		}
		[CompilerGenerated]
		set
		{
			_webUrl = value;
		}
	}

	public AiHelper_8 Runtime
	{
		[CompilerGenerated]
		get
		{
			return VHjtvPHku3;
		}
		[CompilerGenerated]
		set
		{
			VHjtvPHku3 = value;
		}
	}

	public List<AiProviderConfig> Providers
	{
		[CompilerGenerated]
		get
		{
			return _providers;
		}
		[CompilerGenerated]
		set
		{
			_providers = value;
		}
	}

	public int ActiveProviderIndex
	{
		[CompilerGenerated]
		get
		{
			return _activeProviderIndex;
		}
		[CompilerGenerated]
		set
		{
			_activeProviderIndex = value;
		}
	}

	public Helper_23 Intranet
	{
		[CompilerGenerated]
		get
		{
			return _intranet;
		}
		[CompilerGenerated]
		set
		{
			_intranet = value;
		}
	}

	public AiHelper_9 Summary
	{
		[CompilerGenerated]
		get
		{
			return _summary;
		}
		[CompilerGenerated]
		set
		{
			_summary = value;
		}
	}

	public void Initialize()
	{
		Runtime = Runtime ?? new AiHelper_8();
		Providers = Providers ?? new List<AiProviderConfig>();
		Intranet = Intranet ?? new Helper_23();
		Summary = Summary ?? new AiHelper_9();
		Intranet.EnsureDefaults();
		Summary.qBDLf9An1g();
		if (Providers.Count == 0)
		{
			if (Runtime.g0DLRYEicD())
			{
				Providers.Add(AiProviderConfig.PZwLIR4Stn("当前配置", Runtime));
			}
			foreach (AiProviderConfig item in AiProviderConfig.dV6LHfPZVP())
			{
				if (!xXMtPd2I0I(item))
				{
					Providers.Add(item);
				}
			}
		}
		for (int i = 0; i < Providers.Count; i++)
		{
			AiProviderConfig tjgkXoLTQE08rAvKTCC = Providers[i] ?? new AiProviderConfig();
			tjgkXoLTQE08rAvKTCC.Name = AiProviderConfig.wFmLiEaskI(tjgkXoLTQE08rAvKTCC.Name, "配置" + (i + 1));
			tjgkXoLTQE08rAvKTCC.Provider = AiHelper_8.CVZLBdQFXa(tjgkXoLTQE08rAvKTCC.Provider);
			Providers[i] = tjgkXoLTQE08rAvKTCC;
		}
		if (Providers.Count == 0)
		{
			Providers.Add(new AiProviderConfig
			{
				Name = "默认配置"
			});
		}
		if (ActiveProviderIndex < 0 || ActiveProviderIndex >= Providers.Count)
		{
			ActiveProviderIndex = 0;
		}
		Runtime.FVULVTGET5(Providers[ActiveProviderIndex].OsCL8QJeMd());
	}

	private bool xXMtPd2I0I(AiProviderConfig P_0)
	{
		foreach (AiProviderConfig provider in Providers)
		{
			if (provider != null && string.Equals((provider.Provider ?? string.Empty).Trim(), (P_0.Provider ?? string.Empty).Trim(), StringComparison.OrdinalIgnoreCase) && string.Equals((provider.BaseUrl ?? string.Empty).Trim().TrimEnd('/'), (P_0.BaseUrl ?? string.Empty).Trim().TrimEnd('/'), StringComparison.OrdinalIgnoreCase) && string.Equals((provider.Model ?? string.Empty).Trim(), (P_0.Model ?? string.Empty).Trim(), StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public ProviderConfig()
	{
		SseStreamInitializer.InitializeRuntime();
		_webUrl = "";
		VHjtvPHku3 = new AiHelper_8();
		_providers = new List<AiProviderConfig>();
		_intranet = new Helper_23();
		_summary = new AiHelper_9();
	}
}
