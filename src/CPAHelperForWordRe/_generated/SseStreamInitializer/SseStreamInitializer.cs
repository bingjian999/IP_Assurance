using System;

namespace SseStreamInitializer;

/// <summary>
/// Runtime initializer stub.
/// Originally contained a .NET Reactor license time-bomb that would throw
/// after 2026-07-26. The check has been removed for open-source development.
/// All constructor call-sites still invoke InitializeRuntime() as a no-op
/// to preserve the original call graph.
/// </summary>
internal class SseStreamInitializer
{
	private static bool _initialized;

	internal static void InitializeRuntime()
	{
		// No-op: .NET Reactor time-bomb removed for open-source development.
		// Original code threw after 14 days from 2026-07-12.
		_initialized = true;
	}
}
