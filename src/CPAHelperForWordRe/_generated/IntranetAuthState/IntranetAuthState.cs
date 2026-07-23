using System;
using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace IntranetAuthState;

internal sealed class IntranetAuthState
{
	[CompilerGenerated]
	private bool _isIntranetEnvironment;

	[CompilerGenerated]
	private bool _isManagedModeActive;

	[CompilerGenerated]
	private bool _isAuthenticated;

	[CompilerGenerated]
	private bool mov651p2xq;

	[CompilerGenerated]
	private string _accessToken;

	[CompilerGenerated]
	private string _userName;

	[CompilerGenerated]
	private string _chatModel;

	[CompilerGenerated]
	private string _chatBaseUrl;

	[CompilerGenerated]
	private string _managedVersion;

	[CompilerGenerated]
	private string _rememberedUsername;

	[CompilerGenerated]
	private string _rememberedPassword;

	[CompilerGenerated]
	private string _lastErrorMessage;

	[CompilerGenerated]
	private DateTime _lastProbeUtc;

	[CompilerGenerated]
	private DateTime _lastLoginUtc;

	public bool IsIntranetEnvironment
	{
		[CompilerGenerated]
		get
		{
			return _isIntranetEnvironment;
		}
		[CompilerGenerated]
		set
		{
			_isIntranetEnvironment = value;
		}
	}

	public bool IsManagedModeActive
	{
		[CompilerGenerated]
		get
		{
			return _isManagedModeActive;
		}
		[CompilerGenerated]
		set
		{
			_isManagedModeActive = value;
		}
	}

	public bool IsAuthenticated
	{
		[CompilerGenerated]
		get
		{
			return _isAuthenticated;
		}
		[CompilerGenerated]
		set
		{
			_isAuthenticated = value;
		}
	}

	public bool AutoLoginEnabled
	{
		[CompilerGenerated]
		get
		{
			return mov651p2xq;
		}
		[CompilerGenerated]
		set
		{
			mov651p2xq = value;
		}
	}

	public string AccessToken
	{
		[CompilerGenerated]
		get
		{
			return _accessToken;
		}
		[CompilerGenerated]
		set
		{
			_accessToken = value;
		}
	}

	public string UserName
	{
		[CompilerGenerated]
		get
		{
			return _userName;
		}
		[CompilerGenerated]
		set
		{
			_userName = value;
		}
	}

	public string ChatModel
	{
		[CompilerGenerated]
		get
		{
			return _chatModel;
		}
		[CompilerGenerated]
		set
		{
			_chatModel = value;
		}
	}

	public string ChatBaseUrl
	{
		[CompilerGenerated]
		get
		{
			return _chatBaseUrl;
		}
		[CompilerGenerated]
		set
		{
			_chatBaseUrl = value;
		}
	}

	public string ManagedVersion
	{
		[CompilerGenerated]
		get
		{
			return _managedVersion;
		}
		[CompilerGenerated]
		set
		{
			_managedVersion = value;
		}
	}

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

	public string LastErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _lastErrorMessage;
		}
		[CompilerGenerated]
		set
		{
			_lastErrorMessage = value;
		}
	}

	public DateTime LastProbeUtc
	{
		[CompilerGenerated]
		get
		{
			return _lastProbeUtc;
		}
		[CompilerGenerated]
		set
		{
			_lastProbeUtc = value;
		}
	}

	public DateTime LastLoginUtc
	{
		[CompilerGenerated]
		get
		{
			return _lastLoginUtc;
		}
		[CompilerGenerated]
		set
		{
			_lastLoginUtc = value;
		}
	}

	public bool HasManagedMeta
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(ChatModel))
			{
				return !string.IsNullOrWhiteSpace(ChatBaseUrl);
			}
			return false;
		}
	}

	public IntranetAuthState Clone()
	{
		return (IntranetAuthState)MemberwiseClone();
	}

	public IntranetAuthState()
	{
		SseStreamInitializer.InitializeRuntime();
		_accessToken = string.Empty;
		_userName = string.Empty;
		_chatModel = string.Empty;
		_chatBaseUrl = string.Empty;
		_managedVersion = string.Empty;
		_rememberedUsername = string.Empty;
		_rememberedPassword = string.Empty;
		_lastErrorMessage = string.Empty;
	}
}
