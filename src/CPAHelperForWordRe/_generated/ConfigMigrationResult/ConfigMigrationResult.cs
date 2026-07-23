using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace ConfigMigrationResult;

internal sealed class ConfigMigrationResult
{
	[CompilerGenerated]
	private string _sourceConfigPath;

	[CompilerGenerated]
	private string _backupPath;

	[CompilerGenerated]
	private int _paragraphConfigCount;

	[CompilerGenerated]
	private int aekwXilqid;

	[CompilerGenerated]
	private int _otherConfigCount;

	[CompilerGenerated]
	private int _copiedParagraphPresetCount;

	[CompilerGenerated]
	private int kTnwaArgdV;

	[CompilerGenerated]
	private int _skippedParagraphPresetCount;

	[CompilerGenerated]
	private int _skippedTablePresetCount;

	[CompilerGenerated]
	private int _failedParagraphPresetCount;

	[CompilerGenerated]
	private int _failedTablePresetCount;

	[CompilerGenerated]
	private List<string> _failedPresetFiles;

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

	public string BackupPath
	{
		[CompilerGenerated]
		get
		{
			return _backupPath;
		}
		[CompilerGenerated]
		set
		{
			_backupPath = value;
		}
	}

	public int ParagraphConfigCount
	{
		[CompilerGenerated]
		get
		{
			return _paragraphConfigCount;
		}
		[CompilerGenerated]
		set
		{
			_paragraphConfigCount = value;
		}
	}

	public int TableConfigCount
	{
		[CompilerGenerated]
		get
		{
			return aekwXilqid;
		}
		[CompilerGenerated]
		set
		{
			aekwXilqid = value;
		}
	}

	public int OtherConfigCount
	{
		[CompilerGenerated]
		get
		{
			return _otherConfigCount;
		}
		[CompilerGenerated]
		set
		{
			_otherConfigCount = value;
		}
	}

	public int CopiedParagraphPresetCount
	{
		[CompilerGenerated]
		get
		{
			return _copiedParagraphPresetCount;
		}
		[CompilerGenerated]
		set
		{
			_copiedParagraphPresetCount = value;
		}
	}

	public int CopiedTablePresetCount
	{
		[CompilerGenerated]
		get
		{
			return kTnwaArgdV;
		}
		[CompilerGenerated]
		set
		{
			kTnwaArgdV = value;
		}
	}

	public int SkippedParagraphPresetCount
	{
		[CompilerGenerated]
		get
		{
			return _skippedParagraphPresetCount;
		}
		[CompilerGenerated]
		set
		{
			_skippedParagraphPresetCount = value;
		}
	}

	public int SkippedTablePresetCount
	{
		[CompilerGenerated]
		get
		{
			return _skippedTablePresetCount;
		}
		[CompilerGenerated]
		set
		{
			_skippedTablePresetCount = value;
		}
	}

	public int FailedParagraphPresetCount
	{
		[CompilerGenerated]
		get
		{
			return _failedParagraphPresetCount;
		}
		[CompilerGenerated]
		set
		{
			_failedParagraphPresetCount = value;
		}
	}

	public int FailedTablePresetCount
	{
		[CompilerGenerated]
		get
		{
			return _failedTablePresetCount;
		}
		[CompilerGenerated]
		set
		{
			_failedTablePresetCount = value;
		}
	}

	public List<string> FailedPresetFiles
	{
		[CompilerGenerated]
		get
		{
			return _failedPresetFiles;
		}
		[CompilerGenerated]
		set
		{
			_failedPresetFiles = value;
		}
	}

	public bool HasFailures => FailedPresetFiles.Count > 0;

	public ConfigMigrationResult()
	{
		SseStreamInitializer.InitializeRuntime();
		_sourceConfigPath = string.Empty;
		_backupPath = string.Empty;
		_failedPresetFiles = new List<string>();
	}
}
