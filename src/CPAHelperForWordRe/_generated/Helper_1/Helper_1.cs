using System;
using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;

namespace Helper_1;

internal sealed class Helper_1
{
	[CompilerGenerated]
	private bool ar1tbt07s2;

	[CompilerGenerated]
	private int IGrtSxQreL;

	[CompilerGenerated]
	private int GvttwcTshP;

	[CompilerGenerated]
	private string _fontName;

	[CompilerGenerated]
	private double NFStLVSjpw;

	[CompilerGenerated]
	private bool _autoHideOnDeactivate;

	[CompilerGenerated]
	private string _activeAccentColor;

	[CompilerGenerated]
	private string _documentNameDisplayMode;

	[CompilerGenerated]
	private int _documentNamePrefixLength;

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
			return _fontName;
		}
		[CompilerGenerated]
		set
		{
			_fontName = value;
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
			return _autoHideOnDeactivate;
		}
		[CompilerGenerated]
		set
		{
			_autoHideOnDeactivate = value;
		}
	}

	public string ActiveAccentColor
	{
		[CompilerGenerated]
		get
		{
			return _activeAccentColor;
		}
		[CompilerGenerated]
		set
		{
			_activeAccentColor = value;
		}
	}

	public string DocumentNameDisplayMode
	{
		[CompilerGenerated]
		get
		{
			return _documentNameDisplayMode;
		}
		[CompilerGenerated]
		set
		{
			_documentNameDisplayMode = value;
		}
	}

	public int DocumentNamePrefixLength
	{
		[CompilerGenerated]
		get
		{
			return _documentNamePrefixLength;
		}
		[CompilerGenerated]
		set
		{
			_documentNamePrefixLength = value;
		}
	}

	public void AdjustHeight()
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

	public bool IsMaxWidthEnabled()
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

	public Helper_1()
	{
		SseStreamInitializer.InitializeRuntime();
		ar1tbt07s2 = true;
		IGrtSxQreL = 26;
		GvttwcTshP = 220;
		_fontName = "Microsoft YaHei UI";
		NFStLVSjpw = 9.0;
		_activeAccentColor = "#2B74F2";
		_documentNameDisplayMode = "Full";
		_documentNamePrefixLength = 12;
	}
}
