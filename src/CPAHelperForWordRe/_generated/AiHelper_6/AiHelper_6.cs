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
		public Action fc5VEeB4nMu;

		public _G_c__DisplayClass1_0()
		{
			SseStreamInitializer.AlBVL0oCCKQ();
		}

		internal void YoHVEcN2Hk8(object _)
		{
			fc5VEeB4nMu();
		}
	}

	public static void uJJLaq5Qdq()
	{
		if (AiSseStreamService4.pS8Leo78tt())
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
			HttpHelper_1 rei3DhLlLQm1bCVIXFi = await AiSseStreamService4.PJYL5bLAxq( true);
			if (rei3DhLlLQm1bCVIXFi == null || !AiSseStreamService4.DodLcdpfxo(AiSseStreamService4.mVoL74rdRf(), rei3DhLlLQm1bCVIXFi.VersionText))
			{
				return;
			}
			CS_8_locals_3.fc5VEeB4nMu = delegate
			{
				WordTableToolService5.IPf5i0ZcV4(new UpdateWindow());
			};
			if (syncContext != null)
			{
				syncContext.Post(delegate
				{
					CS_8_locals_3.fc5VEeB4nMu();
				}, null);
			}
			else
			{
				CS_8_locals_3.fc5VEeB4nMu();
			}
		}
		catch (Exception)
		{
		}
	}
}
