namespace CPAHelper.Agent.Abstractions;

public interface ISubAgentActivitySink
{
	void PublishSubAgentActivity(SubAgentActivityUpdate update);
}
