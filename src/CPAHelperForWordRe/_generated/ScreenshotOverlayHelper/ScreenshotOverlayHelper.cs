using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ScreenshotCaptureHelper;
using AiSseStreamService3;
using ScreenshotCaptureHelper2;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService;

namespace ScreenshotOverlayHelper;

internal sealed class ScreenshotOverlayHelper : Form
{
	private enum BPuOTVVZI70taClJes5e
	{

	}

	private readonly Rectangle yMLcQrPaCU;

	private Bitmap _bitmap;

	private Point _point;

	private Point QNZcJpxRon;

	private bool _bool;

	private bool _bool;

	private IntPtr _intPtr;

	private bool _bool;

	private WdWindowState _wdWindowState;

	private bool _bool;

	[CompilerGenerated]
	private Bitmap _capturedImage;

	[CompilerGenerated]
	private Rectangle _captureBounds;

	public Bitmap CapturedImage
	{
		[CompilerGenerated]
		get
		{
			return _capturedImage;
		}
		[CompilerGenerated]
		private set
		{
			_capturedImage = value;
		}
	}

	public Rectangle CaptureBounds
	{
		[CompilerGenerated]
		get
		{
			return _captureBounds;
		}
		[CompilerGenerated]
		private set
		{
			_captureBounds = value;
		}
	}

	public ScreenshotOverlayHelper()
	{
		SseStreamInitializer.InitializeRuntime();
		_bool = true;
		yMLcQrPaCU = ScreenshotCaptureHelper.o2DcMOKyEe();
		_bitmap = ScreenshotCaptureHelper.SEvcbGvKps();
		T0dcgIxXI1();
		base.FormBorderStyle = FormBorderStyle.None;
		base.StartPosition = FormStartPosition.Manual;
		base.Bounds = yMLcQrPaCU;
		base.ShowInTaskbar = false;
		base.TopMost = true;
		Cursor = Cursors.Default;
		base.KeyPreview = true;
		DoubleBuffered = true;
		Font = new System.Drawing.Font("Microsoft YaHei UI", 10f);
	}

	protected override void OnShown(EventArgs P_0)
	{
		base.OnShown(P_0);
		QNZcJpxRon = PointToClient(Control.MousePosition);
		Activate();
		BringToFront();
		Focus();
		Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs P_0)
	{
		if (P_0.Button == MouseButtons.Left)
		{
			_point = P_0.Location;
			QNZcJpxRon = P_0.Location;
			_bool = true;
			_bool = true;
			Invalidate();
			base.OnMouseDown(P_0);
		}
	}

	protected override void OnMouseMove(MouseEventArgs P_0)
	{
		QNZcJpxRon = P_0.Location;
		Invalidate();
		_ = _bool;
		base.OnMouseMove(P_0);
	}

	protected override void OnMouseUp(MouseEventArgs P_0)
	{
		if (P_0.Button != MouseButtons.Left || !_bool)
		{
			return;
		}
		_bool = false;
		QNZcJpxRon = P_0.Location;
		Rectangle srcRect = h24cHU7RGI();
		if (srcRect.Width >= 8 && srcRect.Height >= 8)
		{
			CaptureBounds = new Rectangle(srcRect.X + yMLcQrPaCU.X, srcRect.Y + yMLcQrPaCU.Y, srcRect.Width, srcRect.Height);
			CapturedImage = new Bitmap(srcRect.Width, srcRect.Height);
			using (Graphics graphics = Graphics.FromImage(CapturedImage))
			{
				graphics.DrawImage(_bitmap, new Rectangle(0, 0, srcRect.Width, srcRect.Height), srcRect, GraphicsUnit.Pixel);
			}
			base.DialogResult = DialogResult.OK;
		}
		else
		{
			base.DialogResult = DialogResult.Cancel;
		}
		_bool = false;
		Close();
		base.OnMouseUp(P_0);
	}

	protected override void OnKeyDown(KeyEventArgs P_0)
	{
		if (P_0.KeyCode == Keys.Escape)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}
		else if (P_0.KeyCode == Keys.F1)
		{
			R0Ec81fI6J();
		}
		else if (P_0.KeyCode == Keys.F2)
		{
			QCXcIiOuET((BPuOTVVZI70taClJes5e)1);
		}
		else if (P_0.KeyCode == Keys.F3)
		{
			QCXcIiOuET((BPuOTVVZI70taClJes5e)2);
		}
		else
		{
			base.OnKeyDown(P_0);
		}
	}

	protected override void OnPaint(PaintEventArgs P_0)
	{
		P_0.Graphics.DrawImageUnscaled(_bitmap, Point.Empty);
		using (SolidBrush brush = new SolidBrush(Color.FromArgb(120, Color.Black)))
		{
			P_0.Graphics.FillRectangle(brush, base.ClientRectangle);
		}
		Rectangle rectangle = (_bool ? h24cHU7RGI() : Rectangle.Empty);
		if (rectangle.Width > 0 && rectangle.Height > 0)
		{
			P_0.Graphics.DrawImage(_bitmap, rectangle, rectangle, GraphicsUnit.Pixel);
			using Pen pen = new Pen(Color.DeepSkyBlue, 2f);
			P_0.Graphics.DrawRectangle(pen, rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);
		}
		using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(180, Color.Black)))
		{
			using SolidBrush brush3 = new SolidBrush(Color.White);
			P_0.Graphics.DrawString("拖拽选择区域，Esc 取消，F1 隐藏 Word 重拍，F2/F3 刷新截图", Font, brush2, 13f, 13f);
			P_0.Graphics.DrawString("拖拽选择区域，Esc 取消，F1 隐藏 Word 重拍，F2/F3 刷新截图", Font, brush3, 12f, 12f);
		}
		base.OnPaint(P_0);
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0)
		{
			_bitmap.Dispose();
			wiociuwGol();
		}
		base.Dispose(P_0);
	}

	private void T0dcgIxXI1()
	{
		Microsoft.Office.Interop.Word.Application wordApp = WordTableToolService.WordApp;
		if (wordApp == null)
		{
			return;
		}
		try
		{
			Window activeWindow = wordApp.ActiveWindow;
			_intPtr = ((activeWindow == null) ? IntPtr.Zero : new IntPtr(activeWindow.Hwnd));
		}
		catch
		{
			_intPtr = IntPtr.Zero;
		}
		try
		{
			_bool = wordApp.Visible;
		}
		catch
		{
			_bool = true;
		}
		try
		{
			_wdWindowState = wordApp.WindowState;
		}
		catch
		{
			_wdWindowState = WdWindowState.wdWindowStateNormal;
		}
	}

	private void R0Ec81fI6J()
	{
		bool topMost = base.TopMost;
		try
		{
			base.TopMost = false;
			base.Visible = false;
			System.Windows.Forms.Application.DoEvents();
			Microsoft.Office.Interop.Word.Application wordApp = WordTableToolService.WordApp;
			if (wordApp != null)
			{
				try
				{
					wordApp.WindowState = WdWindowState.wdWindowStateMinimize;
					_bool = true;
				}
				catch
				{
				}
			}
			if (_intPtr != IntPtr.Zero)
			{
				try
				{
					ScreenshotCaptureHelper2.CaptureScreen(_intPtr, 6);
					_bool = true;
				}
				catch
				{
				}
			}
			System.Windows.Forms.Application.DoEvents();
			Thread.Sleep(120);
			QCXcIiOuET((BPuOTVVZI70taClJes5e)0);
		}
		finally
		{
			base.Visible = true;
			base.TopMost = topMost || true;
			Activate();
			BringToFront();
			Focus();
			Invalidate();
		}
	}

	private void QCXcIiOuET(BPuOTVVZI70taClJes5e P_0)
	{
		Bitmap bitmap = null;
		try
		{
			bitmap = P_0 switch
			{
				(BPuOTVVZI70taClJes5e)1 => ScreenshotCaptureHelper.ovBcwMo51L(), 
				(BPuOTVVZI70taClJes5e)2 => ScreenshotCaptureHelper.Rr5cS2CmV7(), 
				_ => ScreenshotCaptureHelper.SEvcbGvKps(), 
			};
			Bitmap bitmap2 = _bitmap;
			_bitmap = bitmap;
			bitmap2.Dispose();
		}
		catch
		{
			bitmap?.Dispose();
		}
	}

	private void wiociuwGol()
	{
		Microsoft.Office.Interop.Word.Application wordApp = WordTableToolService.WordApp;
		if (wordApp != null)
		{
			try
			{
				wordApp.Visible = _bool;
			}
			catch
			{
			}
			if (_bool)
			{
				try
				{
					wordApp.WindowState = _wdWindowState;
				}
				catch
				{
				}
			}
		}
		if (_intPtr == IntPtr.Zero)
		{
			return;
		}
		try
		{
			if (_bool)
			{
				switch (_wdWindowState)
				{
				case WdWindowState.wdWindowStateMaximize:
					ScreenshotCaptureHelper2.CaptureScreen(_intPtr, 3);
					break;
				case WdWindowState.wdWindowStateMinimize:
					ScreenshotCaptureHelper2.CaptureScreen(_intPtr, 9);
					break;
				default:
					ScreenshotCaptureHelper2.CaptureScreen(_intPtr, 5);
					break;
				}
			}
			ScreenshotCaptureHelper2.d2kP0Du2a(_intPtr);
		}
		catch
		{
		}
	}

	private Rectangle h24cHU7RGI()
	{
		int num = Math.Min(_point.X, QNZcJpxRon.X);
		int num2 = Math.Min(_point.Y, QNZcJpxRon.Y);
		int num3 = Math.Abs(QNZcJpxRon.X - _point.X);
		int num4 = Math.Abs(QNZcJpxRon.Y - _point.Y);
		return new Rectangle(num, num2, num3, num4);
	}
}
