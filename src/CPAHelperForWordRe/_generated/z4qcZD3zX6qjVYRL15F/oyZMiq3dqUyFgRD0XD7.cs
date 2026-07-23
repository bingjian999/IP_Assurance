using System;
using System.Runtime.CompilerServices;
using System.Threading;
using aQChPyBaZdbEBOJn4tr;
using CPAHelper.Agent.Abstractions;
using dL7TFPsQbAGqPywtHUK;
using hJKpQrVSwRwMyI2RyDQN;
using IE65okus88MbfGVSFao;

namespace z4qcZD3zX6qjVYRL15F;

internal static class oyZMiq3dqUyFgRD0XD7
{
	[CompilerGenerated]
	private static Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact> f5UUuAwKhH;

	[SpecialName]
	[CompilerGenerated]
	public static void fWnUBnsIYw(Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact> P_0)
	{
		Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact> action = f5UUuAwKhH;
		Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact> action2;
		do
		{
			action2 = action;
			Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact> value = (Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact>)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref f5UUuAwKhH, value, action2);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	[CompilerGenerated]
	public static void vIPU93N8BE(Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact> P_0)
	{
		Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact> action = f5UUuAwKhH;
		Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact> action2;
		do
		{
			action2 = action;
			Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact> value = (Action<RkZt4ZuLjXTP5cAL48p, AgentArtifact>)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref f5UUuAwKhH, value, action2);
		}
		while ((object)action != action2);
	}

	public static void geJUR2mtQx(AgentArtifact P_0)
	{
		VYkUViDjLf(null, P_0);
	}

	public static void VYkUViDjLf(RkZt4ZuLjXTP5cAL48p P_0, AgentArtifact P_1)
	{
		if (P_1 != null)
		{
			yR9thasHZ73xXm8eKwj.swCsJ4IbrL("Agent artifact published: " + (P_1.Type ?? "unknown") + " / " + (P_1.Title ?? "(no-title)"));
			if (P_0 == null)
			{
				RmFJn1BhW81y5YhCApL.v7iBkI3KGG();
			}
			else
			{
				RmFJn1BhW81y5YhCApL.zRLBxbssPX(P_0);
			}
			f5UUuAwKhH?.Invoke(P_0, P_1);
		}
	}
}
