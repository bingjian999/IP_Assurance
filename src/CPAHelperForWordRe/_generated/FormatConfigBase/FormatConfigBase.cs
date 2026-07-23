using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;
using Helper_24;

namespace FormatConfigBase;

internal sealed class FormatConfigBase
{
	[CompilerGenerated]
	private string _sourceConfigPath;

	[CompilerGenerated]
	private Dictionary<string, object> twIwN2awoR;

	[CompilerGenerated]
	private List<Helper_24> _paragraphPresetFiles;

	[CompilerGenerated]
	private List<Helper_24> _tablePresetFiles;

	public string SourceConfigPath
	{
		[CompilerGenerated]
		get
		{
			return _sourceConfigPath;
		}
		[CompilerGenerated]
		set
		{
			_sourceConfigPath = value;
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

	public List<Helper_24> ParagraphPresetFiles
	{
		[CompilerGenerated]
		get
		{
			return _paragraphPresetFiles;
		}
		[CompilerGenerated]
		set
		{
			_paragraphPresetFiles = value;
		}
	}

	public List<Helper_24> TablePresetFiles
	{
		[CompilerGenerated]
		get
		{
			return _tablePresetFiles;
		}
		[CompilerGenerated]
		set
		{
			_tablePresetFiles = value;
		}
	}

	public int ParagraphConfigCount => ConfigValues.Keys.Count((string key) => key.StartsWith("段落_", StringComparison.Ordinal));

	public int TableConfigCount => ConfigValues.Keys.Count((string key) => key.StartsWith("表格_", StringComparison.Ordinal));

	public int OtherConfigCount => ConfigValues.Count - ParagraphConfigCount - TableConfigCount;

	public int ParagraphPresetCopyCount => ParagraphPresetFiles.Count((Helper_24 file) => !file.ExistsInTarget);

	public int TablePresetCopyCount => TablePresetFiles.Count((Helper_24 file) => !file.ExistsInTarget);

	public int SkippedParagraphPresetCount => ParagraphPresetFiles.Count((Helper_24 file) => file.ExistsInTarget);

	public int SkippedTablePresetCount => TablePresetFiles.Count((Helper_24 file) => file.ExistsInTarget);

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

	public FormatConfigBase()
	{
		SseStreamInitializer.InitializeRuntime();
		_sourceConfigPath = string.Empty;
		twIwN2awoR = new Dictionary<string, object>(StringComparer.Ordinal);
		_paragraphPresetFiles = new List<Helper_24>();
		_tablePresetFiles = new List<Helper_24>();
	}
}
