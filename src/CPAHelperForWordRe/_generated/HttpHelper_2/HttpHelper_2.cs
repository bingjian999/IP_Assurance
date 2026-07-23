using System;
using System.Net;
using AiSseStreamService3;

namespace HttpHelper_2;

internal static class HttpHelper_2
{
	public static void BNmLxKn8Mc()
	{
		try
		{
			AppContext.SetSwitch("Switch.System.Net.DontEnableSystemDefaultTlsVersions", isEnabled: false);
			AppContext.SetSwitch("Switch.System.Net.DontEnableSchUseStrongCrypto", isEnabled: false);
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
		}
		catch
		{
		}
	}
}
