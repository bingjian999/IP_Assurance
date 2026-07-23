using System;
using System.Runtime.CompilerServices;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;

namespace EQmQmjtjVXFMF2PY0es;

internal sealed class HUo9Z2t4U0P9mYi11IG
{
	[CompilerGenerated]
	private bool ar1tbt07s2;

	[CompilerGenerated]
	private int IGrtSxQreL;

	[CompilerGenerated]
	private int GvttwcTshP;

	[CompilerGenerated]
	private string z6nttIbwZ9;

	[CompilerGenerated]
	private double NFStLVSjpw;

	[CompilerGenerated]
	private bool Im1ts8SZ1U;

	[CompilerGenerated]
	private string O3RtlbAEQK;

	[CompilerGenerated]
	private string YGxtNh1o9X;

	[CompilerGenerated]
	private int Oq7tmkJj2K;

	public bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return ar1tbt07s2;
		}
		[CompilerGenerated]
		set
		{
			ar1tbt07s2 = value;
		}
	}

	public int Height
	{
		[CompilerGenerated]
		get
		{
			return IGrtSxQreL;
		}
		[CompilerGenerated]
		set
		{
			IGrtSxQreL = value;
		}
	}

	public int TabMaxWidth
	{
		[CompilerGenerated]
		get
		{
			return GvttwcTshP;
		}
		[CompilerGenerated]
		set
		{
			GvttwcTshP = value;
		}
	}

	public string FontName
	{
		[CompilerGenerated]
		get
		{
			return z6nttIbwZ9;
		}
		[CompilerGenerated]
		set
		{
			z6nttIbwZ9 = value;
		}
	}

	public double FontSize
	{
		[CompilerGenerated]
		get
		{
			return NFStLVSjpw;
		}
		[CompilerGenerated]
		set
		{
			NFStLVSjpw = value;
		}
	}

	public bool AutoHideOnDeactivate
	{
		[CompilerGenerated]
		get
		{
			return Im1ts8SZ1U;
		}
		[CompilerGenerated]
		set
		{
			Im1ts8SZ1U = value;
		}
	}

	public string ActiveAccentColor
	{
		[CompilerGenerated]
		get
		{
			return O3RtlbAEQK;
		}
		[CompilerGenerated]
		set
		{
			O3RtlbAEQK = value;
		}
	}

	public string DocumentNameDisplayMode
	{
		[CompilerGenerated]
		get
		{
			return YGxtNh1o9X;
		}
		[CompilerGenerated]
		set
		{
			YGxtNh1o9X = value;
		}
	}

	public int DocumentNamePrefixLength
	{
		[CompilerGenerated]
		get
		{
			return Oq7tmkJj2K;
		}
		[CompilerGenerated]
		set
		{
			Oq7tmkJj2K = value;
		}
	}

	public void O77tY1qK6N()
	{
		if (Height < 22)
		{
			Height = 22;
		}
		else if (Height > 40)
		{
			Height = 26;
		}
		if (TabMaxWidth < 120)
		{
			TabMaxWidth = 120;
		}
		else if (TabMaxWidth > 360)
		{
			TabMaxWidth = 360;
		}
		if (string.IsNullOrWhiteSpace(FontName))
		{
			FontName = "Microsoft YaHei UI";
		}
		if (FontSize < 7.0)
		{
			FontSize = 7.0;
		}
		else if (FontSize > 18.0)
		{
			FontSize = 18.0;
		}
		ActiveAccentColor = n1qtMYWGjR(ActiveAccentColor, "#2B74F2");
		DocumentNameDisplayMode = hVCtftMMFT(DocumentNameDisplayMode);
		if (DocumentNamePrefixLength < 1)
		{
			DocumentNamePrefixLength = 1;
		}
		else if (DocumentNamePrefixLength > 120)
		{
			DocumentNamePrefixLength = 120;
		}
	}

	public bool FuAtZSN641()
	{
		return string.Equals(DocumentNameDisplayMode, "Prefix", StringComparison.OrdinalIgnoreCase);
	}

	private static string hVCtftMMFT(string P_0)
	{
		if (!string.Equals((P_0 ?? string.Empty).Trim(), "Prefix", StringComparison.OrdinalIgnoreCase))
		{
			return "Full";
		}
		return "Prefix";
	}

	private static string n1qtMYWGjR(string P_0, string P_1)
	{
		string text = (P_0 ?? string.Empty).Trim();
		if (text.Length == 6)
		{
			text = "#" + text;
		}
		if (text.Length != 7 || text[0] != '#')
		{
			return P_1;
		}
		for (int i = 1; i < text.Length; i++)
		{
			char c = text[i];
			if ((c < '0' || c > '9') && (c < 'a' || c > 'f') && (c < 'A' || c > 'F'))
			{
				return P_1;
			}
		}
		return text.ToUpperInvariant();
	}

	public HUo9Z2t4U0P9mYi11IG()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		ar1tbt07s2 = true;
		IGrtSxQreL = 26;
		GvttwcTshP = 220;
		z6nttIbwZ9 = "Microsoft YaHei UI";
		NFStLVSjpw = 9.0;
		O3RtlbAEQK = "#2B74F2";
		YGxtNh1o9X = "Full";
		Oq7tmkJj2K = 12;
	}
}
