using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;
using oYrvWhwCA5mHJk8IDhH;

namespace GdddxFwsHWSb6CsKNZy;

internal sealed class A6h5sUwLEOvWuLQLmiB
{
	[CompilerGenerated]
	private string Ji9wlrhbTG;

	[CompilerGenerated]
	private Dictionary<string, object> twIwN2awoR;

	[CompilerGenerated]
	private List<H2vq9wwGY8vBw2m8e3D> XLdwm7wdJt;

	[CompilerGenerated]
	private List<H2vq9wwGY8vBw2m8e3D> w4vwoTTKUt;

	public string SourceConfigPath
	{
		[CompilerGenerated]
		get
		{
			return Ji9wlrhbTG;
		}
		[CompilerGenerated]
		set
		{
			Ji9wlrhbTG = value;
		}
	}

	public Dictionary<string, object> ConfigValues
	{
		[CompilerGenerated]
		get
		{
			return twIwN2awoR;
		}
		[CompilerGenerated]
		set
		{
			twIwN2awoR = value;
		}
	}

	public List<H2vq9wwGY8vBw2m8e3D> ParagraphPresetFiles
	{
		[CompilerGenerated]
		get
		{
			return XLdwm7wdJt;
		}
		[CompilerGenerated]
		set
		{
			XLdwm7wdJt = value;
		}
	}

	public List<H2vq9wwGY8vBw2m8e3D> TablePresetFiles
	{
		[CompilerGenerated]
		get
		{
			return w4vwoTTKUt;
		}
		[CompilerGenerated]
		set
		{
			w4vwoTTKUt = value;
		}
	}

	public int ParagraphConfigCount => ConfigValues.Keys.Count((string key) => key.StartsWith("段落_", StringComparison.Ordinal));

	public int TableConfigCount => ConfigValues.Keys.Count((string key) => key.StartsWith("表格_", StringComparison.Ordinal));

	public int OtherConfigCount => ConfigValues.Count - ParagraphConfigCount - TableConfigCount;

	public int ParagraphPresetCopyCount => ParagraphPresetFiles.Count((H2vq9wwGY8vBw2m8e3D file) => !file.ExistsInTarget);

	public int TablePresetCopyCount => TablePresetFiles.Count((H2vq9wwGY8vBw2m8e3D file) => !file.ExistsInTarget);

	public int SkippedParagraphPresetCount => ParagraphPresetFiles.Count((H2vq9wwGY8vBw2m8e3D file) => file.ExistsInTarget);

	public int SkippedTablePresetCount => TablePresetFiles.Count((H2vq9wwGY8vBw2m8e3D file) => file.ExistsInTarget);

	public bool HasMigratableItems
	{
		get
		{
			if (ConfigValues.Count <= 0 && ParagraphPresetFiles.Count <= 0)
			{
				return TablePresetFiles.Count > 0;
			}
			return true;
		}
	}

	public A6h5sUwLEOvWuLQLmiB()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		Ji9wlrhbTG = string.Empty;
		twIwN2awoR = new Dictionary<string, object>(StringComparer.Ordinal);
		XLdwm7wdJt = new List<H2vq9wwGY8vBw2m8e3D>();
		w4vwoTTKUt = new List<H2vq9wwGY8vBw2m8e3D>();
	}
}
