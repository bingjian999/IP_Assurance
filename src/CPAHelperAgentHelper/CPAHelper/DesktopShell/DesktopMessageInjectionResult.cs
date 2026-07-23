namespace CPAHelper.Agent.DesktopShell;

public sealed class DesktopMessageInjectionResult
{
	public bool Success { get; set; }

	public string InjectionId { get; set; }

	public string Code { get; set; }

	public string Message { get; set; }

	public static DesktopMessageInjectionResult Accepted(string injectionId)
	{
		return new DesktopMessageInjectionResult
		{
			Success = true,
			InjectionId = injectionId
		};
	}

	public static DesktopMessageInjectionResult Rejected(string code, string message)
	{
		return new DesktopMessageInjectionResult
		{
			Success = false,
			Code = code,
			Message = message
		};
	}
}
