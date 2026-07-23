using System;
using System.Runtime.CompilerServices;
using System.Threading;
using HttpHelper_1;
using CPAHelperForWordRe.UI.Forms;
using WordTableToolService5;
using SseStreamInitializer;
using AiSseStreamService4;

namespace AiHelper_6;

internal static class AiHelper_6
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass1_0
	{
		public Action action;

		public _G_c__DisplayClass1_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void PostAction(object _)
		{
			action();
		}
	}

	public static void CheckForUpdate()
	{
		if (AiSseStreamService4.isAutoUpdateEnabled())
		{
			VKALqeAadh();
		}
	}

	private static async void VKALqeAadh()
	{
		SynchronizationContext syncContext = SynchronizationContext.Current;
		try
		{
			_G_c__DisplayClass1_0 CS_8_locals_3 = new _G_c__DisplayClass1_0();
			HttpHelper_1 updateInfo = await AiSseStreamService4.fetchUpdateInfo( true);
			if (updateInfo == null || !AiSseStreamService4.isNewerVersion(AiSseStreamService4.GetAssemblyVersion(), updateInfo.VersionText))
			{
				return;
			}
			CS_8_locals_3.action = delegate
			{
				WordTableToolService5.ShowWpfWindow(new UpdateWindow());
			};
			if (syncContext != null)
			{
				syncContext.Post(delegate
				{
					CS_8_locals_3.action();
				}, null);
			}
			else
			{
				CS_8_locals_3.action();
			}
		}
		catch (Exception)
		{
		}
	}
}
