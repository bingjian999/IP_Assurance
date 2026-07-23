using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace ConfigMigrationResult;

internal sealed class ConfigMigrationResult
{
	[CompilerGenerated]
	private string HC2wcQCJu9;

	[CompilerGenerated]
	private string crqweB6dQE;

	[CompilerGenerated]
	private int e8swyCAlhw;

	[CompilerGenerated]
	private int aekwXilqid;

	[CompilerGenerated]
	private int E08wFBb0i6;

	[CompilerGenerated]
	private int Pk7whtQGY8;

	[CompilerGenerated]
	private int kTnwaArgdV;

	[CompilerGenerated]
	private int wIIwqar6nQ;

	[CompilerGenerated]
	private int C0JwPqgnsd;

	[CompilerGenerated]
	private int agXwAOJ7ZK;

	[CompilerGenerated]
	private int Wy0wvjUHiR;

	[CompilerGenerated]
	private List<string> U68wWlmmI8;

	public string SourceConfigPath
	{
		[CompilerGenerated]
		get
		{
			return HC2wcQCJu9;
		}
		[CompilerGenerated]
		set
		{
			HC2wcQCJu9 = value;
		}
	}

	public string BackupPath
	{
		[CompilerGenerated]
		get
		{
			return crqweB6dQE;
		}
		[CompilerGenerated]
		set
		{
			crqweB6dQE = value;
		}
	}

	public int ParagraphConfigCount
	{
		[CompilerGenerated]
		get
		{
			return e8swyCAlhw;
		}
		[CompilerGenerated]
		set
		{
			e8swyCAlhw = value;
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
			return E08wFBb0i6;
		}
		[CompilerGenerated]
		set
		{
			E08wFBb0i6 = value;
		}
	}

	public int CopiedParagraphPresetCount
	{
		[CompilerGenerated]
		get
		{
			return Pk7whtQGY8;
		}
		[CompilerGenerated]
		set
		{
			Pk7whtQGY8 = value;
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
			return wIIwqar6nQ;
		}
		[CompilerGenerated]
		set
		{
			wIIwqar6nQ = value;
		}
	}

	public int SkippedTablePresetCount
	{
		[CompilerGenerated]
		get
		{
			return C0JwPqgnsd;
		}
		[CompilerGenerated]
		set
		{
			C0JwPqgnsd = value;
		}
	}

	public int FailedParagraphPresetCount
	{
		[CompilerGenerated]
		get
		{
			return agXwAOJ7ZK;
		}
		[CompilerGenerated]
		set
		{
			agXwAOJ7ZK = value;
		}
	}

	public int FailedTablePresetCount
	{
		[CompilerGenerated]
		get
		{
			return Wy0wvjUHiR;
		}
		[CompilerGenerated]
		set
		{
			Wy0wvjUHiR = value;
		}
	}

	public List<string> FailedPresetFiles
	{
		[CompilerGenerated]
		get
		{
			return U68wWlmmI8;
		}
		[CompilerGenerated]
		set
		{
			U68wWlmmI8 = value;
		}
	}

	public bool HasFailures => FailedPresetFiles.Count > 0;

	public ConfigMigrationResult()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		HC2wcQCJu9 = string.Empty;
		crqweB6dQE = string.Empty;
		U68wWlmmI8 = new List<string>();
	}
}
