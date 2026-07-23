using Microsoft.CodeAnalysis;
using SseStreamInitializer;

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
[Microsoft.CodeAnalysis.Embedded]
[CompilerGenerated]
internal sealed class NullableContextAttribute : Attribute
{
	public readonly byte Flag;

	public NullableContextAttribute(byte P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		Flag = P_0;
	}
}
