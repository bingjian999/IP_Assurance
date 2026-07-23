using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_23;

internal sealed class Helper_23
{
	[CompilerGenerated]
	private string _rememberedUsername;

	[CompilerGenerated]
	private string _rememberedPassword;

	[CompilerGenerated]
	private bool JWULjyoYZ5;

	public string RememberedUsername
	{
		[CompilerGenerated]
		get
		{
			return _rememberedUsername;
		}
		[CompilerGenerated]
		set
		{
			_rememberedUsername = value;
		}
	}

	public string RememberedPassword
	{
		[CompilerGenerated]
		get
		{
			return _rememberedPassword;
		}
		[CompilerGenerated]
		set
		{
			_rememberedPassword = value;
		}
	}

	public bool AutoLoginEnabled
	{
		[CompilerGenerated]
		get
		{
			return JWULjyoYZ5;
		}
		[CompilerGenerated]
		set
		{
			JWULjyoYZ5 = value;
		}
	}

	public void EnsureDefaults()
	{
		RememberedUsername = RememberedUsername ?? "";
		RememberedPassword = RememberedPassword ?? "";
	}

	public Helper_23()
	{
		SseStreamInitializer.InitializeRuntime();
		_rememberedUsername = "";
		_rememberedPassword = "";
	}
}
