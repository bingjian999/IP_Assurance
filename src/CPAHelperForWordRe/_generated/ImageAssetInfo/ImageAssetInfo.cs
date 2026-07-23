using System.Runtime.CompilerServices;
using SseStreamInitializer;

namespace ImageAssetInfo;

internal sealed class ImageAssetInfo
{
	[CompilerGenerated]
	private string _pngPath;

	[CompilerGenerated]
	private string AjVQkQadX8;

	[CompilerGenerated]
	private string _sourceHash;

	[CompilerGenerated]
	private int _pixelWidth;

	[CompilerGenerated]
	private int _pixelHeight;

	[CompilerGenerated]
	private long _pngBytes;

	public string PngPath
	{
		[CompilerGenerated]
		get
		{
			return _pngPath;
		}
		[CompilerGenerated]
		set
		{
			_pngPath = value;
		}
	}

	public string SourcePath
	{
		[CompilerGenerated]
		get
		{
			return AjVQkQadX8;
		}
		[CompilerGenerated]
		set
		{
			AjVQkQadX8 = value;
		}
	}

	public string SourceHash
	{
		[CompilerGenerated]
		get
		{
			return _sourceHash;
		}
		[CompilerGenerated]
		set
		{
			_sourceHash = value;
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

	public long PngBytes
	{
		[CompilerGenerated]
		get
		{
			return _pngBytes;
		}
		[CompilerGenerated]
		set
		{
			_pngBytes = value;
		}
	}

	public ImageAssetInfo()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
