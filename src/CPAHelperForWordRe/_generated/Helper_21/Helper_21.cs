using AiSseStreamService3;
using IntranetAiConfigService;

namespace Helper_21;

internal static class Helper_21
{
	public static string CurrentTitle
	{
		get
		{
			if (!IntranetAiConfigService.Instance.Nju6iKu8Ci().IsIntranetEnvironment)
			{
				return "IP_Assurance in Word";
			}
			return "IP in Word";
		}
	}
}
