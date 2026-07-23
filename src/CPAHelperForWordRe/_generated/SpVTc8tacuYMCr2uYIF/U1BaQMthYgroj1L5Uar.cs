using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using fGoxrBLg8puPL9tYJjH;
using hJKpQrVSwRwMyI2RyDQN;
using k73DZ2LKfdneKP0TqSV;
using ndRERvVtEjasqN2cQqiN;
using oBj8i4tzkFO0U03EgiU;
using umvBUyLZkdHOMijakx0;

namespace SpVTc8tacuYMCr2uYIF;

internal sealed class U1BaQMthYgroj1L5Uar
{
	[CompilerGenerated]
	private string iUCtAH02WK;

	[CompilerGenerated]
	private cn1I4Itdi2pbX0gWYAr VHjtvPHku3;

	[CompilerGenerated]
	private List<TjgkXoLTQE08rAvKTCC> sVotWsIL6U;

	[CompilerGenerated]
	private int EBCt0TZyy8;

	[CompilerGenerated]
	private D3mDanLUdMRipgtVYRZ n1ZtkSy3m4;

	[CompilerGenerated]
	private UM9LJeLY3PARcsaXCR2 d3ktx5jnwX;

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

	public cn1I4Itdi2pbX0gWYAr Runtime
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

	public List<TjgkXoLTQE08rAvKTCC> Providers
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

	public D3mDanLUdMRipgtVYRZ Intranet
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

	public UM9LJeLY3PARcsaXCR2 Summary
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
		Runtime = Runtime ?? new cn1I4Itdi2pbX0gWYAr();
		Providers = Providers ?? new List<TjgkXoLTQE08rAvKTCC>();
		Intranet = Intranet ?? new D3mDanLUdMRipgtVYRZ();
		Summary = Summary ?? new UM9LJeLY3PARcsaXCR2();
		Intranet.fb6LEfM5qk();
		Summary.qBDLf9An1g();
		if (Providers.Count == 0)
		{
			if (Runtime.g0DLRYEicD())
			{
				Providers.Add(TjgkXoLTQE08rAvKTCC.PZwLIR4Stn("当前配置", Runtime));
			}
			foreach (TjgkXoLTQE08rAvKTCC item in TjgkXoLTQE08rAvKTCC.dV6LHfPZVP())
			{
				if (!xXMtPd2I0I(item))
				{
					Providers.Add(item);
				}
			}
		}
		for (int i = 0; i < Providers.Count; i++)
		{
			TjgkXoLTQE08rAvKTCC tjgkXoLTQE08rAvKTCC = Providers[i] ?? new TjgkXoLTQE08rAvKTCC();
			tjgkXoLTQE08rAvKTCC.Name = TjgkXoLTQE08rAvKTCC.wFmLiEaskI(tjgkXoLTQE08rAvKTCC.Name, "配置" + (i + 1));
			tjgkXoLTQE08rAvKTCC.Provider = cn1I4Itdi2pbX0gWYAr.CVZLBdQFXa(tjgkXoLTQE08rAvKTCC.Provider);
			Providers[i] = tjgkXoLTQE08rAvKTCC;
		}
		if (Providers.Count == 0)
		{
			Providers.Add(new TjgkXoLTQE08rAvKTCC
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

	private bool xXMtPd2I0I(TjgkXoLTQE08rAvKTCC P_0)
	{
		foreach (TjgkXoLTQE08rAvKTCC provider in Providers)
		{
			if (provider != null && string.Equals((provider.Provider ?? string.Empty).Trim(), (P_0.Provider ?? string.Empty).Trim(), StringComparison.OrdinalIgnoreCase) && string.Equals((provider.BaseUrl ?? string.Empty).Trim().TrimEnd('/'), (P_0.BaseUrl ?? string.Empty).Trim().TrimEnd('/'), StringComparison.OrdinalIgnoreCase) && string.Equals((provider.Model ?? string.Empty).Trim(), (P_0.Model ?? string.Empty).Trim(), StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public U1BaQMthYgroj1L5Uar()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		iUCtAH02WK = "";
		VHjtvPHku3 = new cn1I4Itdi2pbX0gWYAr();
		sVotWsIL6U = new List<TjgkXoLTQE08rAvKTCC>();
		n1ZtkSy3m4 = new D3mDanLUdMRipgtVYRZ();
		d3ktx5jnwX = new UM9LJeLY3PARcsaXCR2();
	}
}
