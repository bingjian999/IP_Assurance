using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Helper_1;
using AiHelper_11;
using HotkeyHookService2;
using Helper_22;
using Helper_18;
using SseStreamInitializer;

namespace AiHelper_12;

internal sealed class AiHelper_12
{
	[CompilerGenerated]
	private Helper_18 UPstIQSoRt;

	[CompilerGenerated]
	private Helper_1 SRytiDQYmK;

	[CompilerGenerated]
	private HotkeyHookService2 ogctHhYAgX;

	[CompilerGenerated]
	private AiHelper_11 _excelSync;

	[CompilerGenerated]
	private Helper_22 _ai;

	[CompilerGenerated]
	private Dictionary<string, object> _legacy;

	public Helper_18 System
	{
		[CompilerGenerated]
		get
		{
			return UPstIQSoRt;
		}
		[CompilerGenerated]
		set
		{
			UPstIQSoRt = value;
		}
	}

	public Helper_1 OfficeTab
	{
		[CompilerGenerated]
		get
		{
			return SRytiDQYmK;
		}
		[CompilerGenerated]
		set
		{
			SRytiDQYmK = value;
		}
	}

	public HotkeyHookService2 DesktopPin
	{
		[CompilerGenerated]
		get
		{
			return ogctHhYAgX;
		}
		[CompilerGenerated]
		set
		{
			ogctHhYAgX = value;
		}
	}

	public AiHelper_11 ExcelSync
	{
		[CompilerGenerated]
		get
		{
			return _excelSync;
		}
		[CompilerGenerated]
		set
		{
			_excelSync = value;
		}
	}

	public Helper_22 Ai
	{
		[CompilerGenerated]
		get
		{
			return _ai;
		}
		[CompilerGenerated]
		set
		{
			_ai = value;
		}
	}

	public Dictionary<string, object> Legacy
	{
		[CompilerGenerated]
		get
		{
			return _legacy;
		}
		[CompilerGenerated]
		set
		{
			_legacy = value;
		}
	}

	public void EnsureConfigLoaded()
	{
		if (System == null)
		{
			System = new Helper_18();
		}
		if (OfficeTab == null)
		{
			OfficeTab = new Helper_1();
		}
		if (DesktopPin == null)
		{
			DesktopPin = new HotkeyHookService2();
		}
		if (ExcelSync == null)
		{
			ExcelSync = new AiHelper_11();
		}
		if (Ai == null)
		{
			Ai = new Helper_22();
		}
		if (Legacy == null)
		{
			Legacy = new Dictionary<string, object>();
		}
		System.qyxtULiSoA();
		OfficeTab.AdjustHeight();
		DesktopPin.EnsureDefaultHotkey();
		ExcelSync.Initialize();
		Ai.DuXtXcAhKd();
	}

	public AiHelper_12()
	{
		SseStreamInitializer.InitializeRuntime();
		UPstIQSoRt = new Helper_18();
		SRytiDQYmK = new Helper_1();
		ogctHhYAgX = new HotkeyHookService2();
		_excelSync = new AiHelper_11();
		_ai = new Helper_22();
		_legacy = new Dictionary<string, object>();
	}
}
