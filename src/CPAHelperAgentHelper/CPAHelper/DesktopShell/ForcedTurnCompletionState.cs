namespace CPAHelper.Agent.DesktopShell;

internal sealed class ForcedTurnCompletionState
{
	private readonly object _syncRoot = new object();

	private bool _isSet;

	private string _assistantText;

	public bool TrySet(string assistantText)
	{
		if (string.IsNullOrWhiteSpace(assistantText))
		{
			return false;
		}
		lock (_syncRoot)
		{
			if (_isSet)
			{
				return false;
			}
			_isSet = true;
			_assistantText = assistantText;
			return true;
		}
	}

	public bool TryGet(out string assistantText)
	{
		lock (_syncRoot)
		{
			assistantText = _assistantText;
			return _isSet && !string.IsNullOrWhiteSpace(_assistantText);
		}
	}

	public void Reset()
	{
		lock (_syncRoot)
		{
			_isSet = false;
			_assistantText = null;
		}
	}
}
