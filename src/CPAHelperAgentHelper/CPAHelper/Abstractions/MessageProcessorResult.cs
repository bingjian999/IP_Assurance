namespace CPAHelper.Agent.Abstractions;

public class MessageProcessorResult
{
	public bool HasArtifact { get; set; }

	public bool HasDirectAnswer { get; set; }

	public string AssistantMessage { get; set; }

	public string ErrorMessage { get; set; }
}
