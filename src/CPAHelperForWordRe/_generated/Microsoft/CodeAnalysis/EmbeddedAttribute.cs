using System;
using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Microsoft.CodeAnalysis;

[CompilerGenerated]
[Microsoft.CodeAnalysis.Embedded]
internal sealed class EmbeddedAttribute : Attribute
{
	public EmbeddedAttribute()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
