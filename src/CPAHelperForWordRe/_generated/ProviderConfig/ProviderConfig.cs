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
	private string iUCtAH02WK;

	[CompilerGenerated]
	private AiHelper_8 VHjtvPHku3;

	[CompilerGenerated]
	private List<AiProviderConfig> sVotWsIL6U;

	[CompilerGenerated]
	private int EBCt0TZyy8;

	[CompilerGenerated]
	private Helper_23 n1ZtkSy3m4;

	[CompilerGenerated]
	private AiHelper_9 d3ktx5jnwX;

	public string WebUrl
	{
		[CompilerGenerated]
		get
		{
			return iUCtAH02WK;
		}
		[CompilerGenerated]
		set
		{
			iUCtAH02WK = value;
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
			return sVotWsIL6U;
		}
		[CompilerGenerated]
		set
		{
			sVotWsIL6U = value;
		}
	}

	public int ActiveProviderIndex
	{
		[CompilerGenerated]
		get
		{
			return EBCt0TZyy8;
		}
		[CompilerGenerated]
		set
		{
			EBCt0TZyy8 = value;
		}
	}

	public Helper_23 Intranet
	{
		[CompilerGenerated]
		get
		{
			return n1ZtkSy3m4;
		}
		[CompilerGenerated]
		set
		{
			n1ZtkSy3m4 = value;
		}
	}

	public AiHelper_9 Summary
	{
		[CompilerGenerated]
		get
		{
			return d3ktx5jnwX;
		}
		[CompilerGenerated]
		set
		{
			d3ktx5jnwX = value;
		}
	}

	public void SH0tq5ryQE()
	{
		Runtime = Runtime ?? new AiHelper_8();
		Providers = Providers ?? new List<AiProviderConfig>();
		Intranet = Intranet ?? new Helper_23();
		Summary = Summary ?? new AiHelper_9();
		Intranet.fb6LEfM5qk();
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
		SseStreamInitializer.AlBVL0oCCKQ();
		iUCtAH02WK = "";
		VHjtvPHku3 = new AiHelper_8();
		sVotWsIL6U = new List<AiProviderConfig>();
		n1ZtkSy3m4 = new Helper_23();
		d3ktx5jnwX = new AiHelper_9();
	}
}
