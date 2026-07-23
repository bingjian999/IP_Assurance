using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace Helper_16;

internal sealed class Helper_16
{
	[CompilerGenerated]
	private string _htmlFragment;

	[CompilerGenerated]
	private int _pixelWidth;

	[CompilerGenerated]
	private int _pixelHeight;

	[CompilerGenerated]
	private string _backgroundColor;

	public string HtmlFragment
	{
		[CompilerGenerated]
		get
		{
			return _htmlFragment;
		}
		[CompilerGenerated]
		set
		{
			_htmlFragment = value;
		}
	}

	public int PixelWidth
	{
		[CompilerGenerated]
		get
		{
			return _pixelWidth;
		}
		[CompilerGenerated]
		set
		{
			_pixelWidth = value;
		}
	}

	public int PixelHeight
	{
		[CompilerGenerated]
		get
		{
			return _pixelHeight;
		}
		[CompilerGenerated]
		set
		{
			_pixelHeight = value;
		}
	}

	public string BackgroundColor
	{
		[CompilerGenerated]
		get
		{
			return _backgroundColor;
		}
		[CompilerGenerated]
		set
		{
			_backgroundColor = value;
		}
	}

	public Helper_16()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
