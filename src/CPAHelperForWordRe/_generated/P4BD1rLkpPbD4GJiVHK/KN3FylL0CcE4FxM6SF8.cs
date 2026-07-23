using System;
using System.Net;
using hJKpQrVSwRwMyI2RyDQN;

namespace P4BD1rLkpPbD4GJiVHK;

internal static class KN3FylL0CcE4FxM6SF8
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
