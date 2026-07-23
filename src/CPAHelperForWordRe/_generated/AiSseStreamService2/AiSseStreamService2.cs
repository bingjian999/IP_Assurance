using System;
using System.Reflection;
using SseStreamInitializer;

namespace AiSseStreamService2;

internal class AiSseStreamService2
{
	internal delegate void Lk2xOtVSblTlsxpCTYbe(object o);

	internal static Module jWYVSMB4Mr2;

	internal static void lZxVLv5NYmU(int typemdt)
	{
		Type type = jWYVSMB4Mr2.ResolveType(33554432 + typemdt);
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			MethodInfo method = (MethodInfo)jWYVSMB4Mr2.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	public AiSseStreamService2()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
	}

	static AiSseStreamService2()
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		jWYVSMB4Mr2 = typeof(AiSseStreamService2).Assembly.ManifestModule;
	}
}
