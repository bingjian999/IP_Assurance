using System.Runtime.CompilerServices;
using AiSseStreamService3;
using SseStreamInitializer;

namespace HotkeyHookService2;

internal sealed class HotkeyHookService2
{
	[CompilerGenerated]
	private bool mUutpfCRYy;

	[CompilerGenerated]
	private string vUStOZktxx;

	public bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return mUutpfCRYy;
		}
		[CompilerGenerated]
		set
		{
			mUutpfCRYy = value;
		}
	}

	public string Hotkey
	{
		[CompilerGenerated]
		get
		{
			return vUStOZktxx;
		}
		[CompilerGenerated]
		set
		{
			vUStOZktxx = value;
		}
	}

	public void IEntCn565B()
	{
		if (string.IsNullOrWhiteSpace(Hotkey))
		{
			Hotkey = "F1";
		}
		else
		{
			Hotkey = Hotkey.Trim();
		}
	}

	public HotkeyHookService2()
	{
		SseStreamInitializer.InitializeRuntime();
		vUStOZktxx = "F1";
	}
}
