using gLbVIZKLH6Vb5OK2mnj;
using VZXZf1ccDRAexK4cV58;
using YNri0QclKMfRh2PQoZV;

namespace wRnHPKcpkuhmwE9uGcA;

internal static class un7uUxcCbw6Q36geOYj
{
	public static void CsKcO7u6di(Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs P_0, string P_1 = "Excel同步")
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_0.Message))
		{
			return;
		}
		string text = P_0.Message.Trim();
		if (P_0.Success)
		{
			lRTy9Ic5uax0jm0RR1L.SeXce6fgLN(text, P_1);
		}
		else if (P_0.Cancelled)
		{
			lRTy9Ic5uax0jm0RR1L.Kn6cyKZe85(text, P_1);
		}
		else if (P_0.RequiresUserAction)
		{
			if (string.IsNullOrWhiteSpace(P_0.TechnicalDetail))
			{
				F2ZFeLcsiLlLr89kqUl.u0kcmnykTv(text, P_1);
			}
			else
			{
				F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8(text, P_1);
			}
		}
		else
		{
			lRTy9Ic5uax0jm0RR1L.Kn6cyKZe85(text, P_1);
		}
	}

	public static void psZcncX5UL(string P_0, string P_1 = "Excel同步")
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			lRTy9Ic5uax0jm0RR1L.SeXce6fgLN(P_0.Trim(), P_1);
		}
	}

	public static void kX7c742XgE(string P_0, string P_1 = "Excel同步")
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			lRTy9Ic5uax0jm0RR1L.Kn6cyKZe85(P_0.Trim(), P_1);
		}
	}
}
