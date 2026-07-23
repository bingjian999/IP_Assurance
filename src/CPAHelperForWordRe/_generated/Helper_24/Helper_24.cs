using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_24;

internal sealed class Helper_24
{
	[CompilerGenerated]
	private string _sourcePath;

	[CompilerGenerated]
	private string _targetPath;

	[CompilerGenerated]
	private bool _existsInTarget;

	public string SourcePath
	{
		[CompilerGenerated]
		get
		{
			return _sourcePath;
		}
		[CompilerGenerated]
		set
		{
			_sourcePath = value;
		}
	}

	public string TargetPath
	{
		[CompilerGenerated]
		get
		{
			return _targetPath;
		}
		[CompilerGenerated]
		set
		{
			_targetPath = value;
		}
	}

	public bool ExistsInTarget
	{
		[CompilerGenerated]
		get
		{
			return _existsInTarget;
		}
		[CompilerGenerated]
		set
		{
			_existsInTarget = value;
		}
	}

	public Helper_24()
	{
		SseStreamInitializer.InitializeRuntime();
		_sourcePath = string.Empty;
		_targetPath = string.Empty;
	}
}
