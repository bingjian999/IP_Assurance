using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using eSIXwQcfnNLVB8362qX;
using hJKpQrVSwRwMyI2RyDQN;
using k8LXB7hGUKsi7uGVKR;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;

namespace xCR41qcT3c17DlG5tyi;

internal sealed class rv5mvGcDycFl26EPlB1 : Form
{
	private enum BPuOTVVZI70taClJes5e
	{

	}

	private readonly Rectangle yMLcQrPaCU;

	private Bitmap oeNc1QNjFw;

	private Point Bo2crjs2bE;

	private Point QNZcJpxRon;

	private bool j9bc3T9ITS;

	private bool vP3cUZAQXU;

	private IntPtr U1xcKye0r1;

	private bool JgxcE0hviE;

	private WdWindowState QNMc2oPqdb;

	private bool Plhc4jjZkZ;

	[CompilerGenerated]
	private Bitmap uXucj3uJYV;

	[CompilerGenerated]
	private Rectangle IiEcYbc1lk;

	public Bitmap CapturedImage
	{
		[CompilerGenerated]
		get
		{
			return uXucj3uJYV;
		}
		[CompilerGenerated]
		private set
		{
			uXucj3uJYV = value;
		}
	}

	public Rectangle CaptureBounds
	{
		[CompilerGenerated]
		get
		{
			return IiEcYbc1lk;
		}
		[CompilerGenerated]
		private set
		{
			IiEcYbc1lk = value;
		}
	}

	public rv5mvGcDycFl26EPlB1()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		JgxcE0hviE = true;
		yMLcQrPaCU = AVLlS1cZQQwJQ2RsefC.o2DcMOKyEe();
		oeNc1QNjFw = AVLlS1cZQQwJQ2RsefC.SEvcbGvKps();
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
			Bo2crjs2bE = P_0.Location;
			QNZcJpxRon = P_0.Location;
			j9bc3T9ITS = true;
			vP3cUZAQXU = true;
			Invalidate();
			base.OnMouseDown(P_0);
		}
	}

	protected override void OnMouseMove(MouseEventArgs P_0)
	{
		QNZcJpxRon = P_0.Location;
		Invalidate();
		_ = j9bc3T9ITS;
		base.OnMouseMove(P_0);
	}

	protected override void OnMouseUp(MouseEventArgs P_0)
	{
		if (P_0.Button != MouseButtons.Left || !j9bc3T9ITS)
		{
			return;
		}
		j9bc3T9ITS = false;
		QNZcJpxRon = P_0.Location;
		Rectangle srcRect = h24cHU7RGI();
		if (srcRect.Width >= 8 && srcRect.Height >= 8)
		{
			CaptureBounds = new Rectangle(srcRect.X + yMLcQrPaCU.X, srcRect.Y + yMLcQrPaCU.Y, srcRect.Width, srcRect.Height);
			CapturedImage = new Bitmap(srcRect.Width, srcRect.Height);
			using (Graphics graphics = Graphics.FromImage(CapturedImage))
			{
				graphics.DrawImage(oeNc1QNjFw, new Rectangle(0, 0, srcRect.Width, srcRect.Height), srcRect, GraphicsUnit.Pixel);
			}
			base.DialogResult = DialogResult.OK;
		}
		else
		{
			base.DialogResult = DialogResult.Cancel;
		}
		vP3cUZAQXU = false;
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
		P_0.Graphics.DrawImageUnscaled(oeNc1QNjFw, Point.Empty);
		using (SolidBrush brush = new SolidBrush(Color.FromArgb(120, Color.Black)))
		{
			P_0.Graphics.FillRectangle(brush, base.ClientRectangle);
		}
		Rectangle rectangle = (vP3cUZAQXU ? h24cHU7RGI() : Rectangle.Empty);
		if (rectangle.Width > 0 && rectangle.Height > 0)
		{
			P_0.Graphics.DrawImage(oeNc1QNjFw, rectangle, rectangle, GraphicsUnit.Pixel);
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
			oeNc1QNjFw.Dispose();
			wiociuwGol();
		}
		base.Dispose(P_0);
	}

	private void T0dcgIxXI1()
	{
		Microsoft.Office.Interop.Word.Application wordApp = eSfxffslhXbaGAjFNv1.WordApp;
		if (wordApp == null)
		{
			return;
		}
		try
		{
			Window activeWindow = wordApp.ActiveWindow;
			U1xcKye0r1 = ((activeWindow == null) ? IntPtr.Zero : new IntPtr(activeWindow.Hwnd));
		}
		catch
		{
			U1xcKye0r1 = IntPtr.Zero;
		}
		try
		{
			JgxcE0hviE = wordApp.Visible;
		}
		catch
		{
			JgxcE0hviE = true;
		}
		try
		{
			QNMc2oPqdb = wordApp.WindowState;
		}
		catch
		{
			QNMc2oPqdb = WdWindowState.wdWindowStateNormal;
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
			Microsoft.Office.Interop.Word.Application wordApp = eSfxffslhXbaGAjFNv1.WordApp;
			if (wordApp != null)
			{
				try
				{
					wordApp.WindowState = WdWindowState.wdWindowStateMinimize;
					Plhc4jjZkZ = true;
				}
				catch
				{
				}
			}
			if (U1xcKye0r1 != IntPtr.Zero)
			{
				try
				{
					MvNn6aFvruJxs6t79C.eq5dmBARf(U1xcKye0r1, 6);
					Plhc4jjZkZ = true;
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
				(BPuOTVVZI70taClJes5e)1 => AVLlS1cZQQwJQ2RsefC.ovBcwMo51L(), 
				(BPuOTVVZI70taClJes5e)2 => AVLlS1cZQQwJQ2RsefC.Rr5cS2CmV7(), 
				_ => AVLlS1cZQQwJQ2RsefC.SEvcbGvKps(), 
			};
			Bitmap bitmap2 = oeNc1QNjFw;
			oeNc1QNjFw = bitmap;
			bitmap2.Dispose();
		}
		catch
		{
			bitmap?.Dispose();
		}
	}

	private void wiociuwGol()
	{
		Microsoft.Office.Interop.Word.Application wordApp = eSfxffslhXbaGAjFNv1.WordApp;
		if (wordApp != null)
		{
			try
			{
				wordApp.Visible = JgxcE0hviE;
			}
			catch
			{
			}
			if (Plhc4jjZkZ)
			{
				try
				{
					wordApp.WindowState = QNMc2oPqdb;
				}
				catch
				{
				}
			}
		}
		if (U1xcKye0r1 == IntPtr.Zero)
		{
			return;
		}
		try
		{
			if (Plhc4jjZkZ)
			{
				switch (QNMc2oPqdb)
				{
				case WdWindowState.wdWindowStateMaximize:
					MvNn6aFvruJxs6t79C.eq5dmBARf(U1xcKye0r1, 3);
					break;
				case WdWindowState.wdWindowStateMinimize:
					MvNn6aFvruJxs6t79C.eq5dmBARf(U1xcKye0r1, 9);
					break;
				default:
					MvNn6aFvruJxs6t79C.eq5dmBARf(U1xcKye0r1, 5);
					break;
				}
			}
			MvNn6aFvruJxs6t79C.d2kP0Du2a(U1xcKye0r1);
		}
		catch
		{
		}
	}

	private Rectangle h24cHU7RGI()
	{
		int num = Math.Min(Bo2crjs2bE.X, QNZcJpxRon.X);
		int num2 = Math.Min(Bo2crjs2bE.Y, QNZcJpxRon.Y);
		int num3 = Math.Abs(QNZcJpxRon.X - Bo2crjs2bE.X);
		int num4 = Math.Abs(QNZcJpxRon.Y - Bo2crjs2bE.Y);
		return new Rectangle(num, num2, num3, num4);
	}
}
