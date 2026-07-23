using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AiSseStreamService3;
using Helper_15;
using SseStreamInitializer;

namespace Helper_9;

internal sealed class Helper_9
{
	public static readonly HashSet<string> TcvQQSKPF8;

	[CompilerGenerated]
	private string _fontName;

	[CompilerGenerated]
	private string _eastAsianFontName;

	[CompilerGenerated]
	private float? avmQJXlCo7;

	[CompilerGenerated]
	private bool? _bold;

	[CompilerGenerated]
	private bool? _italic;

	[CompilerGenerated]
	private string ExnQKcUoSa;

	[CompilerGenerated]
	private string _rowAlignment;

	[CompilerGenerated]
	private string _verticalAlignment;

	[CompilerGenerated]
	private string _autoFit;

	[CompilerGenerated]
	private float? _preferredWidthPercent;

	[CompilerGenerated]
	private float? _cellPaddingPt;

	[CompilerGenerated]
	private float? _rowHeightPt;

	[CompilerGenerated]
	private string _rowHeightRule;

	[CompilerGenerated]
	private string _borderStyle;

	[CompilerGenerated]
	private float? EwDQbpfKeB;

	[CompilerGenerated]
	private bool? _headerRowBold;

	[CompilerGenerated]
	private int? _headerRowShading;

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
			return avmQJXlCo7;
		}
		[CompilerGenerated]
		set
		{
			avmQJXlCo7 = value;
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
			return ExnQKcUoSa;
		}
		[CompilerGenerated]
		set
		{
			ExnQKcUoSa = value;
		}
	}

	public string RowAlignment
	{
		[CompilerGenerated]
		get
		{
			return _rowAlignment;
		}
		[CompilerGenerated]
		set
		{
			_rowAlignment = value;
		}
	}

	public string VerticalAlignment
	{
		[CompilerGenerated]
		get
		{
			return _verticalAlignment;
		}
		[CompilerGenerated]
		set
		{
			_verticalAlignment = value;
		}
	}

	public string AutoFit
	{
		[CompilerGenerated]
		get
		{
			return _autoFit;
		}
		[CompilerGenerated]
		set
		{
			_autoFit = value;
		}
	}

	public float? PreferredWidthPercent
	{
		[CompilerGenerated]
		get
		{
			return _preferredWidthPercent;
		}
		[CompilerGenerated]
		set
		{
			_preferredWidthPercent = value;
		}
	}

	public float? CellPaddingPt
	{
		[CompilerGenerated]
		get
		{
			return _cellPaddingPt;
		}
		[CompilerGenerated]
		set
		{
			_cellPaddingPt = value;
		}
	}

	public float? RowHeightPt
	{
		[CompilerGenerated]
		get
		{
			return _rowHeightPt;
		}
		[CompilerGenerated]
		set
		{
			_rowHeightPt = value;
		}
	}

	public string RowHeightRule
	{
		[CompilerGenerated]
		get
		{
			return _rowHeightRule;
		}
		[CompilerGenerated]
		set
		{
			_rowHeightRule = value;
		}
	}

	public string BorderStyle
	{
		[CompilerGenerated]
		get
		{
			return _borderStyle;
		}
		[CompilerGenerated]
		set
		{
			_borderStyle = value;
		}
	}

	public float? BorderWidth
	{
		[CompilerGenerated]
		get
		{
			return EwDQbpfKeB;
		}
		[CompilerGenerated]
		set
		{
			EwDQbpfKeB = value;
		}
	}

	public bool? HeaderRowBold
	{
		[CompilerGenerated]
		get
		{
			return _headerRowBold;
		}
		[CompilerGenerated]
		set
		{
			_headerRowBold = value;
		}
	}

	public int? HeaderRowShading
	{
		[CompilerGenerated]
		get
		{
			return _headerRowShading;
		}
		[CompilerGenerated]
		set
		{
			_headerRowShading = value;
		}
	}

	public object hhNQHAECG8()
	{
		Dictionary<string, object> result = new Dictionary<string, object>();
		Helper_15.Add(result, "fontName", FontName);
		Helper_15.Add(result, "eastAsianFontName", EastAsianFontName);
		Helper_15.Add(result, "fontSize", FontSize);
		Helper_15.Add(result, "bold", Bold);
		Helper_15.Add(result, "italic", Italic);
		Helper_15.Add(result, "alignment", Alignment);
		Helper_15.Add(result, "rowAlignment", RowAlignment);
		Helper_15.Add(result, "verticalAlignment", VerticalAlignment);
		Helper_15.Add(result, "autoFit", AutoFit);
		Helper_15.Add(result, "preferredWidthPercent", PreferredWidthPercent);
		Helper_15.Add(result, "cellPaddingPt", CellPaddingPt);
		Helper_15.Add(result, "rowHeightPt", RowHeightPt);
		Helper_15.Add(result, "rowHeightRule", RowHeightRule);
		Helper_15.Add(result, "borderStyle", BorderStyle);
		Helper_15.Add(result, "borderWidthPt", BorderWidth);
		Helper_15.Add(result, "headerRowBold", HeaderRowBold);
		Helper_15.Add(result, "headerRowShading", HeaderRowShading);
		return result;
	}

	public Helper_9()
	{
		SseStreamInitializer.InitializeRuntime();
	}

	static Helper_9()
	{
		SseStreamInitializer.InitializeRuntime();
		TcvQQSKPF8 = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
		{
			"fontName",
			"eastAsianFontName",
			"chineseFontName",
			"fontSize",
			"bold",
			"italic",
			"alignment",
			"rowAlignment",
			"verticalAlignment",
			"autoFit",
			"preferredWidthPercent",
			"cellPaddingPt",
			"rowHeightPt",
			"rowHeightRule",
			"borderStyle",
			"borderWidthPt",
			"headerRowBold",
			"headerRowShading"
		};
	}
}
