using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenshotCaptureHelper;

internal static class ScreenshotCaptureHelper
{
	public static Rectangle o2DcMOKyEe()
	{
		if (Screen.AllScreens.Length == 0)
		{
			return SystemInformation.VirtualScreen;
		}
		int num = int.MaxValue;
		int num2 = int.MaxValue;
		int num3 = int.MinValue;
		int num4 = int.MinValue;
		Screen[] allScreens = Screen.AllScreens;
		foreach (Screen screen in allScreens)
		{
			num = Math.Min(num, screen.Bounds.Left);
			num2 = Math.Min(num2, screen.Bounds.Top);
			num3 = Math.Max(num3, screen.Bounds.Right);
			num4 = Math.Max(num4, screen.Bounds.Bottom);
		}
		return new Rectangle(num, num2, num3 - num, num4 - num2);
	}

	public static Bitmap SEvcbGvKps()
	{
		Bitmap bitmap = null;
		try
		{
			bitmap = Rr5cS2CmV7();
			if (!r8ucLBRc5h(bitmap))
			{
				return bitmap;
			}
			bitmap.Dispose();
			return ovBcwMo51L();
		}
		catch
		{
			bitmap?.Dispose();
			return ovBcwMo51L();
		}
	}

	public static Bitmap Rr5cS2CmV7()
	{
		Rectangle rectangle = o2DcMOKyEe();
		Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, rectangle.Size, CopyPixelOperation.SourceCopy);
		return bitmap;
	}

	public static Bitmap ovBcwMo51L()
	{
		Rectangle rectangle = o2DcMOKyEe();
		Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.Clear(Color.Black);
		Screen[] allScreens = Screen.AllScreens;
		foreach (Screen screen in allScreens)
		{
			using Bitmap image = w9tctZct0n(screen.Bounds);
			graphics.DrawImageUnscaled(image, new Point(screen.Bounds.X - rectangle.X, screen.Bounds.Y - rectangle.Y));
		}
		return bitmap;
	}

	private static Bitmap w9tctZct0n(Rectangle P_0)
	{
		Bitmap bitmap = new Bitmap(Math.Max(P_0.Width, 1), Math.Max(P_0.Height, 1), PixelFormat.Format32bppArgb);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.CopyFromScreen(P_0.X, P_0.Y, 0, 0, P_0.Size, CopyPixelOperation.SourceCopy);
		return bitmap;
	}

	private static bool r8ucLBRc5h(Bitmap P_0)
	{
		if (P_0 == null || P_0.Width <= 1 || P_0.Height <= 1)
		{
			return true;
		}
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = Math.Max(P_0.Width / 8, 1);
			int num4 = Math.Max(P_0.Height / 8, 1);
			for (int i = P_0.Width / 4; i < P_0.Width * 3 / 4; i += num3)
			{
				for (int j = P_0.Height / 4; j < P_0.Height * 3 / 4; j += num4)
				{
					Color pixel = P_0.GetPixel(Math.Min(i, P_0.Width - 1), Math.Min(j, P_0.Height - 1));
					num2++;
					if (pixel.ToArgb() == Color.Black.ToArgb() || pixel.ToArgb() == Color.Red.ToArgb())
					{
						num++;
					}
				}
			}
			return num2 == 0 || num > num2 / 2;
		}
		catch
		{
			return true;
		}
	}
}
