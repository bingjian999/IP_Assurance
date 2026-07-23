using System;

namespace CPAHelper.Agent.Abstractions;

public interface IHostContext
{
	string GetProjectPath();

	void InvokeOnUiThread(Action action);

	string EnsureDataSourceReady();
}
