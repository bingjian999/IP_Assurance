using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace CPAHelperForWordRe.Properties;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "18.0.0.0")]
[CompilerGenerated]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance;

	public static Settings Default => defaultInstance;

	public Settings()
	{
		SseStreamInitializer.InitializeRuntime();
	}

	static Settings()
	{
		SseStreamInitializer.InitializeRuntime();
		defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
