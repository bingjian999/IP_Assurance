using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace AiHelper_11;

internal sealed class AiHelper_11
{
	[CompilerGenerated]
	private bool _syncHeaders;

	public bool SyncHeaders
	{
		[CompilerGenerated]
		get
		{
			return _syncHeaders;
		}
		[CompilerGenerated]
		set
		{
			_syncHeaders = value;
		}
	}

	public void Initialize()
	{
	}

	public AiHelper_11()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
