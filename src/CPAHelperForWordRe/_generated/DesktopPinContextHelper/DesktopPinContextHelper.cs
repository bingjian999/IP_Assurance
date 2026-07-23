using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AiSseStreamService3;
using SseStreamInitializer;

namespace DesktopPinContextHelper;

internal class DesktopPinContextHelper : Form
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_0
	{
		public double double;

		public DesktopPinContextHelper zkqVZDdaibO;

		public _G_c__DisplayClass23_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void gC7VZ69pkvH(object _, EventArgs __)
		{
			zkqVZDdaibO.AVx5CX60a1(double);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_1
	{
		public int value;

		public DesktopPinContextHelper desktopPinContextHelper;

		public _G_c__DisplayClass23_1()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void rtUVZTmATRl(object _, EventArgs __)
		{
			desktopPinContextHelper.Opacity = (double)value / 100.0;
			desktopPinContextHelper.Invalidate();
		}
	}

	private readonly Image _image;

	private readonly ContextMenuStrip _contextMenuStrip;

	private readonly Timer _timer;

	private ToolStripMenuItem _toolStripMenuItem;

	private ToolStripMenuItem _toolStripMenuItem;

	private bool iJncVAFqx1;

	private Point hdWcBtSmSo;

	private double _double;

	private bool _bool;

	private string _string;

	public DesktopPinContextHelper(Image P_0, Point? P_1 = null, double P_2 = 1.0)
	{
		SseStreamInitializer.InitializeRuntime();
		_bool = true;
		_image = P_0 ?? throw new ArgumentNullException("image");
		_double = vxZ5yKGr8m(P_2);
		Font = new Font("Microsoft YaHei UI", 9f);
		base.FormBorderStyle = FormBorderStyle.None;
		base.KeyPreview = true;
		base.Name = "PinnedImageForm";
		base.ShowInTaskbar = false;
		base.StartPosition = ((!P_1.HasValue) ? FormStartPosition.CenterScreen : FormStartPosition.Manual);
		Text = "钉图";
		base.TopMost = true;
		BackColor = Color.Black;
		DoubleBuffered = true;
		FHT5O4ouqE();
		if (P_1.HasValue)
		{
			base.Location = P_1.Value;
		}
		_contextMenuStrip = gnZ5sArDPc();
		ContextMenuStrip = _contextMenuStrip;
		_timer = new Timer
		{
			Interval = 1000
		};
		_timer.Tick += JFo5FdcSkH;
		base.DoubleClick += delegate
		{
			Close();
		};
		base.MouseDown += SGn5STtVxD;
		base.MouseMove += OiP5wPGJVh;
		base.MouseUp += VtL5tIkqVF;
		base.MouseWheel += E4G5LDGJVX;
		base.KeyDown += Wn55MugekH;
		base.FormClosed += Ybr5bphpiG;
		base.MouseEnter += delegate
		{
			Focus();
		};
	}

	private void Wn55MugekH(object P_0, KeyEventArgs P_1)
	{
		if (P_1.KeyCode == Keys.Escape)
		{
			Close();
		}
		else if (P_1.Control && P_1.KeyCode == Keys.C)
		{
			dv55ljYQbl();
		}
		else if (P_1.Control && P_1.KeyCode == Keys.S)
		{
			Ik05NdFNPN();
		}
		else if (P_1.Control && (P_1.KeyCode == Keys.Oemplus || P_1.KeyCode == Keys.Add))
		{
			Rv65onvxdk(0.1, new Point(base.ClientSize.Width / 2, base.ClientSize.Height / 2));
		}
		else if (P_1.Control && (P_1.KeyCode == Keys.OemMinus || P_1.KeyCode == Keys.Subtract))
		{
			Rv65onvxdk(-0.1, new Point(base.ClientSize.Width / 2, base.ClientSize.Height / 2));
		}
		else if (P_1.Control && (P_1.KeyCode == Keys.D0 || P_1.KeyCode == Keys.NumPad0))
		{
			Gty5GKE6Ph();
		}
		else if (P_1.Control && P_1.KeyCode == Keys.B)
		{
			NIp5pEGFUW(!_bool);
		}
	}

	private void Ybr5bphpiG(object P_0, FormClosedEventArgs P_1)
	{
		_timer.Stop();
		_timer.Dispose();
		_contextMenuStrip.Dispose();
		_image.Dispose();
	}

	protected override void OnPaint(PaintEventArgs P_0)
	{
		base.OnPaint(P_0);
		P_0.Graphics.Clear(BackColor);
		Rectangle rect = NSp57mPLhM();
		P_0.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		P_0.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
		P_0.Graphics.SmoothingMode = SmoothingMode.HighQuality;
		P_0.Graphics.DrawImage(_image, rect);
		if (_bool)
		{
			using Pen pen = new Pen(Color.Gray, 2f);
			P_0.Graphics.DrawRectangle(pen, rect);
		}
		string value = nTD5cAMJI9();
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		using Font font = new Font("Microsoft YaHei UI", 9f, FontStyle.Bold);
		Size size = TextRenderer.MeasureText(value, font);
		Rectangle rect2 = new Rectangle(Math.Max(12, (base.ClientSize.Width - size.Width) / 2 - 12), Math.Max(12, base.ClientSize.Height - size.Height - 24), size.Width + 24, size.Height + 10);
		using SolidBrush brush = new SolidBrush(Color.FromArgb(180, Color.Black));
		using (new SolidBrush(Color.White))
		{
			P_0.Graphics.FillRectangle(brush, rect2);
			TextRenderer.DrawText(P_0.Graphics, value, font, new Point(rect2.X + 12, rect2.Y + 5), Color.White, TextFormatFlags.NoPadding);
		}
	}

	private void SGn5STtVxD(object P_0, MouseEventArgs P_1)
	{
		if (P_1.Button == MouseButtons.Left)
		{
			iJncVAFqx1 = true;
			hdWcBtSmSo = P_1.Location;
		}
	}

	private void OiP5wPGJVh(object P_0, MouseEventArgs P_1)
	{
		if (iJncVAFqx1)
		{
			base.Location = new Point(base.Location.X + P_1.X - hdWcBtSmSo.X, base.Location.Y + P_1.Y - hdWcBtSmSo.Y);
		}
	}

	private void VtL5tIkqVF(object P_0, MouseEventArgs P_1)
	{
		iJncVAFqx1 = false;
	}

	private void E4G5LDGJVX(object P_0, MouseEventArgs P_1)
	{
		if (Control.ModifierKeys == Keys.Control)
		{
			double val = base.Opacity + ((P_1.Delta > 0) ? 0.1 : (-0.1));
			base.Opacity = Math.Max(0.1, Math.Min(1.0, val));
			PeS5Xuey1N(string.Format("透明度: {0}%", (int)Math.Round(base.Opacity * 100.0)));
			Invalidate();
		}
		else
		{
			Rv65onvxdk((P_1.Delta > 0) ? 0.1 : (-0.1), P_1.Location);
		}
	}

	private ContextMenuStrip gnZ5sArDPc()
	{
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("复制到剪贴板");
		toolStripMenuItem.Click += delegate
		{
			dv55ljYQbl();
		};
		contextMenuStrip.Items.Add(toolStripMenuItem);
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("保存到文件...");
		toolStripMenuItem2.Click += delegate
		{
			Ik05NdFNPN();
		};
		contextMenuStrip.Items.Add(toolStripMenuItem2);
		contextMenuStrip.Items.Add(new ToolStripSeparator());
		ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("缩放");
		ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem("重置到100%");
		toolStripMenuItem4.Click += delegate
		{
			Gty5GKE6Ph();
		};
		toolStripMenuItem3.DropDownItems.Add(toolStripMenuItem4);
		toolStripMenuItem3.DropDownItems.Add(new ToolStripSeparator());
		double[] array = new double[7] { 0.25, 0.5, 0.75, 1.0, 1.25, 1.5, 2.0 };
		foreach (double double in array)
		{
			_G_c__DisplayClass23_0 CS_8_locals_9 = new _G_c__DisplayClass23_0();
			CS_8_locals_9.zkqVZDdaibO = this;
			CS_8_locals_9.double = double;
			ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem(string.Format("{0}%", (int)(CS_8_locals_9.double * 100.0)));
			toolStripMenuItem5.Click += delegate
			{
				CS_8_locals_9.zkqVZDdaibO.AVx5CX60a1(CS_8_locals_9.double);
			};
			toolStripMenuItem3.DropDownItems.Add(toolStripMenuItem5);
		}
		contextMenuStrip.Items.Add(toolStripMenuItem3);
		contextMenuStrip.Items.Add(new ToolStripSeparator());
		ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem("透明度");
		for (int num2 = 10; num2 <= 100; num2 += 10)
		{
			_G_c__DisplayClass23_1 CS_8_locals_12 = new _G_c__DisplayClass23_1();
			CS_8_locals_12.desktopPinContextHelper = this;
			CS_8_locals_12.value = num2;
			ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem(string.Format("{0}%", CS_8_locals_12.value));
			toolStripMenuItem7.Click += delegate
			{
				CS_8_locals_12.desktopPinContextHelper.Opacity = (double)CS_8_locals_12.value / 100.0;
				CS_8_locals_12.desktopPinContextHelper.Invalidate();
			};
			toolStripMenuItem6.DropDownItems.Add(toolStripMenuItem7);
		}
		contextMenuStrip.Items.Add(toolStripMenuItem6);
		contextMenuStrip.Items.Add(new ToolStripSeparator());
		ToolStripMenuItem toolStripMenuItem8 = new ToolStripMenuItem("边框");
		_toolStripMenuItem = new ToolStripMenuItem("显示边框");
		_toolStripMenuItem.Click += delegate
		{
			NIp5pEGFUW( true);
		};
		_toolStripMenuItem = new ToolStripMenuItem("隐藏边框");
		_toolStripMenuItem.Click += delegate
		{
			NIp5pEGFUW( false);
		};
		toolStripMenuItem8.DropDownItems.Add(_toolStripMenuItem);
		toolStripMenuItem8.DropDownItems.Add(_toolStripMenuItem);
		contextMenuStrip.Items.Add(toolStripMenuItem8);
		contextMenuStrip.Items.Add(new ToolStripSeparator());
		ToolStripMenuItem toolStripMenuItem9 = new ToolStripMenuItem("操作说明");
		toolStripMenuItem9.DropDownItems.Add(new ToolStripMenuItem("滚轮：缩放图片")
		{
			Enabled = false
		});
		toolStripMenuItem9.DropDownItems.Add(new ToolStripMenuItem("Ctrl+滚轮：调整透明度")
		{
			Enabled = false
		});
		toolStripMenuItem9.DropDownItems.Add(new ToolStripMenuItem("Ctrl+0：重置缩放")
		{
			Enabled = false
		});
		toolStripMenuItem9.DropDownItems.Add(new ToolStripMenuItem("Ctrl+B：切换边框")
		{
			Enabled = false
		});
		toolStripMenuItem9.DropDownItems.Add(new ToolStripMenuItem("双击：关闭")
		{
			Enabled = false
		});
		contextMenuStrip.Items.Add(toolStripMenuItem9);
		contextMenuStrip.Items.Add(new ToolStripSeparator());
		ToolStripMenuItem toolStripMenuItem10 = new ToolStripMenuItem("关闭");
		toolStripMenuItem10.Click += delegate
		{
			Close();
		};
		contextMenuStrip.Items.Add(toolStripMenuItem10);
		Y6W5ea9aYR();
		return contextMenuStrip;
	}

	private void dv55ljYQbl()
	{
		try
		{
			Clipboard.SetImage(_image);
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "复制到剪贴板失败：" + ex.Message, "IP_Assurance", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void Ik05NdFNPN()
	{
		using SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "PNG文件|*.png|JPEG文件|*.jpg|BMP文件|*.bmp";
		saveFileDialog.DefaultExt = "png";
		saveFileDialog.FileName = string.Format("截图_{0:yyyyMMdd_HHmmss}", DateTime.Now);
		if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		try
		{
			_image.Save(saveFileDialog.FileName, vxK5m4IL5D(saveFileDialog.FileName));
			MessageBox.Show(this, "保存成功。", "IP_Assurance", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "保存文件失败：" + ex.Message, "IP_Assurance", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static ImageFormat vxK5m4IL5D(string P_0)
	{
		string text = Path.GetExtension(P_0)?.ToLowerInvariant();
		if (!(text == ".jpg") && !(text == ".jpeg"))
		{
			if (text == ".bmp")
			{
				return ImageFormat.Bmp;
			}
			return ImageFormat.Png;
		}
		return ImageFormat.Jpeg;
	}

	private void Rv65onvxdk(double P_0, Point P_1)
	{
		double num = vxZ5yKGr8m(_double + P_0);
		if (!(Math.Abs(num - _double) < 0.001))
		{
			Rectangle rectangle = NSp57mPLhM();
			Point point = PointToScreen(P_1);
			double val = ((rectangle.Width > 0) ? ((double)(P_1.X - rectangle.X) / (double)rectangle.Width) : 0.5);
			double val2 = ((rectangle.Height > 0) ? ((double)(P_1.Y - rectangle.Y) / (double)rectangle.Height) : 0.5);
			val = Math.Max(0.0, Math.Min(1.0, val));
			val2 = Math.Max(0.0, Math.Min(1.0, val2));
			_double = num;
			Size size = ItL5nwIcAP();
			Rectangle rectangle2 = Yfh55ZW0I6(size);
			base.ClientSize = size;
			base.Location = new Point(point.X - (int)Math.Round((double)rectangle2.X + (double)rectangle2.Width * val), point.Y - (int)Math.Round((double)rectangle2.Y + (double)rectangle2.Height * val2));
			PeS5Xuey1N(string.Format("缩放: {0}%", (int)Math.Round(_double * 100.0)));
			Invalidate();
		}
	}

	private void Gty5GKE6Ph()
	{
		AVx5CX60a1(1.0);
	}

	private void AVx5CX60a1(double P_0)
	{
		_double = vxZ5yKGr8m(P_0);
		FHT5O4ouqE();
		Invalidate();
	}

	private void NIp5pEGFUW(bool P_0)
	{
		if (_bool != P_0)
		{
			_bool = P_0;
			FHT5O4ouqE();
			Y6W5ea9aYR();
			PeS5Xuey1N(_bool ? "已隐藏边框" : "已显示边框");
			Invalidate();
		}
	}

	private void FHT5O4ouqE()
	{
		base.ClientSize = ItL5nwIcAP();
	}

	private Size ItL5nwIcAP()
	{
		int num = (_bool ? 4 : 0);
		int num2 = Math.Max(1, (int)Math.Round((double)_image.Width * _double));
		int num3 = Math.Max(1, (int)Math.Round((double)_image.Height * _double));
		return new Size(num2 + num, num3 + num);
	}

	private Rectangle NSp57mPLhM()
	{
		return Yfh55ZW0I6(base.ClientSize);
	}

	private Rectangle Yfh55ZW0I6(Size P_0)
	{
		int num = (_bool ? 2 : 0);
		return new Rectangle(num, num, Math.Max(1, P_0.Width - num * 2), Math.Max(1, P_0.Height - num * 2));
	}

	private string nTD5cAMJI9()
	{
		return _string;
	}

	private void Y6W5ea9aYR()
	{
		if (_toolStripMenuItem != null && _toolStripMenuItem != null)
		{
			_toolStripMenuItem.Checked = _bool;
			_toolStripMenuItem.Checked = !_bool;
		}
	}

	private static double vxZ5yKGr8m(double P_0)
	{
		return Math.Max(0.2, Math.Min(3.0, P_0));
	}

	private void PeS5Xuey1N(string P_0)
	{
		_string = P_0;
		_timer.Stop();
		_timer.Start();
	}

	private void JFo5FdcSkH(object P_0, EventArgs P_1)
	{
		_timer.Stop();
		_string = null;
		Invalidate();
	}

	[CompilerGenerated]
	private void DrH5hRN8iy(object P_0, EventArgs P_1)
	{
		Close();
	}

	[CompilerGenerated]
	private void Xpb5acg4CY(object P_0, EventArgs P_1)
	{
		Focus();
	}

	[CompilerGenerated]
	private void ceq5qYtqKR(object P_0, EventArgs P_1)
	{
		dv55ljYQbl();
	}

	[CompilerGenerated]
	private void Pn55PZykQw(object P_0, EventArgs P_1)
	{
		Ik05NdFNPN();
	}

	[CompilerGenerated]
	private void rXP5ALkgsH(object P_0, EventArgs P_1)
	{
		Gty5GKE6Ph();
	}

	[CompilerGenerated]
	private void ia25vxXoFY(object P_0, EventArgs P_1)
	{
		NIp5pEGFUW( true);
	}

	[CompilerGenerated]
	private void Qgq5WWCmqA(object P_0, EventArgs P_1)
	{
		NIp5pEGFUW( false);
	}

	[CompilerGenerated]
	private void FP750j6gFS(object P_0, EventArgs P_1)
	{
		Close();
	}
}
