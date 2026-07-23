using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AiSseStreamService3;
using Helper_15;
using SseStreamInitializer;

namespace ParagraphFormatConfig;

internal sealed class ParagraphFormatConfig
{
	public static readonly HashSet<string> supportedFields;

	[CompilerGenerated]
	private string _fontName;

	[CompilerGenerated]
	private string _eastAsianFontName;

	[CompilerGenerated]
	private float? _fontSize;

	[CompilerGenerated]
	private bool? _bold;

	[CompilerGenerated]
	private bool? _italic;

	[CompilerGenerated]
	private string GnkHxKTUEj;

	[CompilerGenerated]
	private float? ILqHdpZqjo;

	[CompilerGenerated]
	private float? bjTHzyMZHI;

	[CompilerGenerated]
	private float? _firstLineIndentCm;

	[CompilerGenerated]
	private float? TiFQVGRXmp;

	[CompilerGenerated]
	private float? ccXQBKTldL;

	[CompilerGenerated]
	private float? _spaceAfterPt;

	[CompilerGenerated]
	private string _lineSpacingRule;

	[CompilerGenerated]
	private float? orUQurOjG6;

	[CompilerGenerated]
	private float? ztKQDafxDo;

	[CompilerGenerated]
	private bool? _keepWithNext;

	[CompilerGenerated]
	private bool? MNFQgAYa67;

	[CompilerGenerated]
	private bool? _pageBreakBefore;

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

	public string EastAsianFontName
	{
		[CompilerGenerated]
		get
		{
			return _eastAsianFontName;
		}
		[CompilerGenerated]
		set
		{
			_eastAsianFontName = value;
		}
	}

	public float? FontSize
	{
		[CompilerGenerated]
		get
		{
			return _fontSize;
		}
		[CompilerGenerated]
		set
		{
			_fontSize = value;
		}
	}

	public bool? Bold
	{
		[CompilerGenerated]
		get
		{
			return _bold;
		}
		[CompilerGenerated]
		set
		{
			_bold = value;
		}
	}

	public bool? Italic
	{
		[CompilerGenerated]
		get
		{
			return _italic;
		}
		[CompilerGenerated]
		set
		{
			_italic = value;
		}
	}

	public string Alignment
	{
		[CompilerGenerated]
		get
		{
			return GnkHxKTUEj;
		}
		[CompilerGenerated]
		set
		{
			GnkHxKTUEj = value;
		}
	}

	public float? LeftIndentCm
	{
		[CompilerGenerated]
		get
		{
			return ILqHdpZqjo;
		}
		[CompilerGenerated]
		set
		{
			ILqHdpZqjo = value;
		}
	}

	public float? RightIndentCm
	{
		[CompilerGenerated]
		get
		{
			return bjTHzyMZHI;
		}
		[CompilerGenerated]
		set
		{
			bjTHzyMZHI = value;
		}
	}

	public float? FirstLineIndentCm
	{
		[CompilerGenerated]
		get
		{
			return _firstLineIndentCm;
		}
		[CompilerGenerated]
		set
		{
			_firstLineIndentCm = value;
		}
	}

	public float? FirstLineIndentChars
	{
		[CompilerGenerated]
		get
		{
			return TiFQVGRXmp;
		}
		[CompilerGenerated]
		set
		{
			TiFQVGRXmp = value;
		}
	}

	public float? SpaceBeforePt
	{
		[CompilerGenerated]
		get
		{
			return ccXQBKTldL;
		}
		[CompilerGenerated]
		set
		{
			ccXQBKTldL = value;
		}
	}

	public float? SpaceAfterPt
	{
		[CompilerGenerated]
		get
		{
			return _spaceAfterPt;
		}
		[CompilerGenerated]
		set
		{
			_spaceAfterPt = value;
		}
	}

	public string LineSpacingRule
	{
		[CompilerGenerated]
		get
		{
			return _lineSpacingRule;
		}
		[CompilerGenerated]
		set
		{
			_lineSpacingRule = value;
		}
	}

	public float? LineSpacingPt
	{
		[CompilerGenerated]
		get
		{
			return orUQurOjG6;
		}
		[CompilerGenerated]
		set
		{
			orUQurOjG6 = value;
		}
	}

	public float? LineSpacingMultiple
	{
		[CompilerGenerated]
		get
		{
			return ztKQDafxDo;
		}
		[CompilerGenerated]
		set
		{
			ztKQDafxDo = value;
		}
	}

	public bool? KeepWithNext
	{
		[CompilerGenerated]
		get
		{
			return _keepWithNext;
		}
		[CompilerGenerated]
		set
		{
			_keepWithNext = value;
		}
	}

	public bool? KeepTogether
	{
		[CompilerGenerated]
		get
		{
			return MNFQgAYa67;
		}
		[CompilerGenerated]
		set
		{
			MNFQgAYa67 = value;
		}
	}

	public bool? PageBreakBefore
	{
		[CompilerGenerated]
		get
		{
			return _pageBreakBefore;
		}
		[CompilerGenerated]
		set
		{
			_pageBreakBefore = value;
		}
	}

	public object getRequestedChangeCount()
	{
		Dictionary<string, object> result = new Dictionary<string, object>();
		Helper_15.Add(result, "fontName", FontName);
		Helper_15.Add(result, "eastAsianFontName", EastAsianFontName);
		Helper_15.Add(result, "fontSize", FontSize);
		Helper_15.Add(result, "bold", Bold);
		Helper_15.Add(result, "italic", Italic);
		Helper_15.Add(result, "alignment", Alignment);
		Helper_15.Add(result, "leftIndentCm", LeftIndentCm);
		Helper_15.Add(result, "rightIndentCm", RightIndentCm);
		Helper_15.Add(result, "firstLineIndentCm", FirstLineIndentCm);
		Helper_15.Add(result, "firstLineIndentChars", FirstLineIndentChars);
		Helper_15.Add(result, "spaceBeforePt", SpaceBeforePt);
		Helper_15.Add(result, "spaceAfterPt", SpaceAfterPt);
		Helper_15.Add(result, "lineSpacingRule", LineSpacingRule);
		Helper_15.Add(result, "lineSpacingPt", LineSpacingPt);
		Helper_15.Add(result, "lineSpacingMultiple", LineSpacingMultiple);
		Helper_15.Add(result, "keepWithNext", KeepWithNext);
		Helper_15.Add(result, "keepTogether", KeepTogether);
		Helper_15.Add(result, "pageBreakBefore", PageBreakBefore);
		return result;
	}

	public ParagraphFormatConfig()
	{
		SseStreamInitializer.InitializeRuntime();
	}

	static ParagraphFormatConfig()
	{
		SseStreamInitializer.InitializeRuntime();
		supportedFields = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
		{
			"fontName",
			"eastAsianFontName",
			"chineseFontName",
			"fontSize",
			"bold",
			"italic",
			"alignment",
			"leftIndentCm",
			"rightIndentCm",
			"firstLineIndentCm",
			"firstLineIndentChars",
			"spaceBeforePt",
			"spaceAfterPt",
			"lineSpacingRule",
			"lineSpacingPt",
			"lineSpacingMultiple",
			"keepWithNext",
			"keepTogether",
			"pageBreakBefore"
		};
	}
}
