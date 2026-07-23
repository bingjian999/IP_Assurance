using System;
using System.Reflection;
using SseStreamInitializer;

namespace AiSseStreamService2;

internal class AiSseStreamService2
{
	internal delegate void ModuleInitCallback(object o);

	internal static Module _manifestModule;

	internal static void InitializeModuleDelegates(int typemdt)
	{
		Type type = _manifestModule.ResolveType(33554432 + typemdt);
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			MethodInfo method = (MethodInfo)_manifestModule.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	public AiSseStreamService2()
	{
		SseStreamInitializer.InitializeRuntime();
	}

	static AiSseStreamService2()
	{
		SseStreamInitializer.InitializeRuntime();
		_manifestModule = typeof(AiSseStreamService2).Assembly.ManifestModule;
	}
}
