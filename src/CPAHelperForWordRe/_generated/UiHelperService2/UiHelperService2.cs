using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Helper_19;

namespace UiHelperService2;

internal struct UiHelperService2
{
	[CompilerGenerated]
	private HotkeyAction _modifiers;

	[CompilerGenerated]
	private Keys _key;

	public HotkeyAction Modifiers
	{
		[CompilerGenerated]
		get
		{
			return _modifiers;
		}
		[CompilerGenerated]
		set
		{
			_modifiers = value;
		}
	}

	public Keys Key
	{
		[CompilerGenerated]
		get
		{
			return _key;
		}
		[CompilerGenerated]
		set
		{
			_key = value;
		}
	}
}
