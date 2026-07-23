using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AiAssistantHost2;
using CPAHelper.Agent.Abstractions;
using AiConfigBootstrap;
using AiSseStreamService3;
using AiTargetBinder;

namespace AiHelper_17;

internal static class AiHelper_17
{
	[CompilerGenerated]
	private static Action<AiTargetBinder, AgentArtifact> _artifactHandler;

	[SpecialName]
	[CompilerGenerated]
	public static void fWnUBnsIYw(Action<AiTargetBinder, AgentArtifact> P_0)
	{
		Action<AiTargetBinder, AgentArtifact> action = _artifactHandler;
		Action<AiTargetBinder, AgentArtifact> action2;
		do
		{
			action2 = action;
			Action<AiTargetBinder, AgentArtifact> value = (Action<AiTargetBinder, AgentArtifact>)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref _artifactHandler, value, action2);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	[CompilerGenerated]
	public static void remove_ArtifactHandler(Action<AiTargetBinder, AgentArtifact> P_0)
	{
		Action<AiTargetBinder, AgentArtifact> action = _artifactHandler;
		Action<AiTargetBinder, AgentArtifact> action2;
		do
		{
			action2 = action;
			Action<AiTargetBinder, AgentArtifact> value = (Action<AiTargetBinder, AgentArtifact>)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref _artifactHandler, value, action2);
		}
		while ((object)action != action2);
	}

	public static void PublishArtifact(AgentArtifact P_0)
	{
		VYkUViDjLf(null, P_0);
	}

	public static void VYkUViDjLf(AiTargetBinder P_0, AgentArtifact P_1)
	{
		if (P_1 != null)
		{
			AiConfigBootstrap.LogInfo("Agent artifact published: " + (P_1.Type ?? "unknown") + " / " + (P_1.Title ?? "(no-title)"));
			if (P_0 == null)
			{
				AiAssistantHost2.EnsureAssistantPaneVisible();
			}
			else
			{
				AiAssistantHost2.EnsureTargetPaneVisible(P_0);
			}
			_artifactHandler?.Invoke(P_0, P_1);
		}
	}
}
