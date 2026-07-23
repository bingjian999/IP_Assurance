namespace CPAHelper.Agent.Abstractions;

public interface IAgentAuthenticationRecovery
{
	bool TryRecoverFromUnauthorized(string errorMessage);
}
