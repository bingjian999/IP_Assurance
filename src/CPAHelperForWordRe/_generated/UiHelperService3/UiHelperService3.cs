using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Helper_1;
using TableBorderConfig;
using AiSseStreamService3;
using ScreenshotCaptureHelper2;
using SseStreamInitializer;
using AiHelper_10;
using AiHelper_13;

namespace UiHelperService3;

internal sealed class UiHelperService3 : Form
{
	private enum YB3JfAVY2lmMnyG9udwr
	{
		None
	}

	private struct s64GrAVY4oaB7t7vkJ1d
	{
		public YB3JfAVY2lmMnyG9udwr yB3JfAVY2lmMnyG9udwr;

		public string vlwVYYOlrqX;

		public string ToolTip;
	}

	private struct DrhxL2VYZcXZxBQhNUGG
	{
		public AiHelper_10 aiHelper_10;

		public string text;

		public Rectangle ybLVYbRtSje;

		public Rectangle rectangle;

		public Rectangle rectangle;
	}

	private sealed class k1OnlOVYt3JiSMCcv4U3
	{
		[CompilerGenerated]
		private readonly List<DrhxL2VYZcXZxBQhNUGG> gU0VYL38pjI;

		[CompilerGenerated]
		private int IDTVYsQZcoh;

		[CompilerGenerated]
		private int _desiredHeight;

		public List<DrhxL2VYZcXZxBQhNUGG> Items
		{
			[CompilerGenerated]
			get
			{
				return gU0VYL38pjI;
			}
		}

		public int RowCount
		{
			[CompilerGenerated]
			get
			{
				return IDTVYsQZcoh;
			}
			[CompilerGenerated]
			set
			{
				IDTVYsQZcoh = value;
			}
		}

		public int DesiredHeight
		{
			[CompilerGenerated]
			get
			{
				return _desiredHeight;
			}
			[CompilerGenerated]
			set
			{
				_desiredHeight = value;
			}
		}

		public k1OnlOVYt3JiSMCcv4U3()
		{
			SseStreamInitializer.InitializeRuntime();
			gU0VYL38pjI = new List<DrhxL2VYZcXZxBQhNUGG>();
		}
	}

	private struct KHeUdEVYNDni2Diabntx
	{
		public int value;

		public int value;

		public int RowHeight;

		public int value;

		public int value;

		public int value;

		public int CornerRadius;

		public int value;

		public int value;

		public int value;

		public int value;
	}

	private readonly ToolTip _toolTip;

	private List<AiHelper_10> TkZ7O3mOur;

	private string _string;

	private string _string;

	private Font _font;

	private string _string;

	private float _float;

	private KHeUdEVYNDni2Diabntx _kHeUdEVYNDni2Diabntx;

	protected override bool ShowWithoutActivation => true;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams obj = base.CreateParams;
			obj.ExStyle |= 128;
			return obj;
		}
	}

	private float ScaleRatio => (_font?.Size ?? 9f) / 9f;

	public UiHelperService3()
	{
		SseStreamInitializer.InitializeRuntime();
		_toolTip = new ToolTip();
		TkZ7O3mOur = new List<AiHelper_10>();
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		base.FormBorderStyle = FormBorderStyle.None;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.Manual;
		BackColor = Color.FromArgb(242, 244, 248);
		DNm7LNT9WI();
	}

	protected override void WndProc(ref Message P_0)
	{
		if (P_0.Msg == 33)
		{
			P_0.Result = (IntPtr)3;
		}
		else
		{
			base.WndProc(ref P_0);
		}
	}

	public void lr57EfRfpj()
	{
		DNm7LNT9WI();
		if (!base.Visible)
		{
			ScreenshotCaptureHelper2.CaptureScreen(base.Handle, 4);
			base.Visible = true;
		}
	}

	public void LoadConfig()
	{
		base.Visible = false;
	}

	public void WNa744ZxJ3(List<AiHelper_10> P_0)
	{
		DNm7LNT9WI();
		TkZ7O3mOur = P_0 ?? new List<AiHelper_10>();
		Invalidate();
	}

	public int o1Y7jLQCiS(int P_0)
	{
		DNm7LNT9WI();
		if (P_0 <= 0)
		{
			return _kHeUdEVYNDni2Diabntx.value;
		}
		using Graphics graphics = CreateGraphics();
		return bpQ7Z6Vn1c(graphics, P_0).DesiredHeight;
	}

	public int til7YV9F4s(int P_0)
	{
		DNm7LNT9WI();
		if (P_0 <= 0)
		{
			return 0;
		}
		using Graphics graphics = CreateGraphics();
		int val = R9D7MNqcbg(graphics);
		return Math.Min(P_0, Math.Max(_kHeUdEVYNDni2Diabntx.value * 2 + 1, val));
	}

	protected override void OnPaint(PaintEventArgs P_0)
	{
		base.OnPaint(P_0);
		DNm7LNT9WI();
		Graphics graphics = P_0.Graphics;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		using (SolidBrush brush = new SolidBrush(BackColor))
		{
			graphics.FillRectangle(brush, base.ClientRectangle);
		}
		foreach (DrhxL2VYZcXZxBQhNUGG item in bpQ7Z6Vn1c(graphics, base.Width).Items)
		{
			Doh7bjag9i(graphics, item);
		}
		using Pen pen = new Pen(Color.FromArgb(211, 216, 224));
		graphics.DrawLine(pen, 0, base.Height - 1, base.Width, base.Height - 1);
	}

	protected override void OnMouseMove(MouseEventArgs P_0)
	{
		base.OnMouseMove(P_0);
		s64GrAVY4oaB7t7vkJ1d s64GrAVY4oaB7t7vkJ1d2 = t3R7wwREte(P_0.Location);
		string vlwVYYOlrqX = s64GrAVY4oaB7t7vkJ1d2.vlwVYYOlrqX;
		string text = ((s64GrAVY4oaB7t7vkJ1d2.yB3JfAVY2lmMnyG9udwr == (YB3JfAVY2lmMnyG9udwr)2) ? s64GrAVY4oaB7t7vkJ1d2.vlwVYYOlrqX : null);
		Cursor = ((s64GrAVY4oaB7t7vkJ1d2.yB3JfAVY2lmMnyG9udwr == YB3JfAVY2lmMnyG9udwr.None) ? Cursors.Default : Cursors.Hand);
		_toolTip.SetToolTip(this, s64GrAVY4oaB7t7vkJ1d2.ToolTip ?? string.Empty);
		if (vlwVYYOlrqX != _string || text != _string)
		{
			_string = vlwVYYOlrqX;
			_string = text;
			Invalidate();
		}
	}

	protected override void OnMouseLeave(EventArgs P_0)
	{
		base.OnMouseLeave(P_0);
		_string = null;
		_string = null;
		Cursor = Cursors.Default;
		Invalidate();
	}

	protected override void OnMouseClick(MouseEventArgs P_0)
	{
		base.OnMouseClick(P_0);
		if (P_0.Button == MouseButtons.Left)
		{
			s64GrAVY4oaB7t7vkJ1d s64GrAVY4oaB7t7vkJ1d2 = t3R7wwREte(P_0.Location);
			if (s64GrAVY4oaB7t7vkJ1d2.yB3JfAVY2lmMnyG9udwr == (YB3JfAVY2lmMnyG9udwr)2)
			{
				AiHelper_13.hMTU1YUAHc(s64GrAVY4oaB7t7vkJ1d2.vlwVYYOlrqX);
			}
			else if (s64GrAVY4oaB7t7vkJ1d2.yB3JfAVY2lmMnyG9udwr == (YB3JfAVY2lmMnyG9udwr)1)
			{
				AiHelper_13.fgqUQKfffo(s64GrAVY4oaB7t7vkJ1d2.vlwVYYOlrqX);
			}
		}
	}

	private k1OnlOVYt3JiSMCcv4U3 bpQ7Z6Vn1c(Graphics P_0, int P_1)
	{
		int num = Math.Max(P_1, _kHeUdEVYNDni2Diabntx.value * 2 + 1);
		int num2 = _kHeUdEVYNDni2Diabntx.value;
		int num3 = 0;
		k1OnlOVYt3JiSMCcv4U3 k1OnlOVYt3JiSMCcv4U4 = new k1OnlOVYt3JiSMCcv4U3();
		foreach (AiHelper_10 item in TkZ7O3mOur)
		{
			string text = oQE7t3oZKo(item);
			int num4 = wZO7fDKJMZ(P_0, text);
			if (num2 > _kHeUdEVYNDni2Diabntx.value && num2 + num4 > num - _kHeUdEVYNDni2Diabntx.value)
			{
				num3++;
				num2 = _kHeUdEVYNDni2Diabntx.value;
			}
			int num5 = num3 * _kHeUdEVYNDni2Diabntx.RowHeight + (_kHeUdEVYNDni2Diabntx.RowHeight - _kHeUdEVYNDni2Diabntx.value) / 2;
			Rectangle ybLVYbRtSje = new Rectangle(num2, num5, num4, _kHeUdEVYNDni2Diabntx.value);
			Rectangle poEVYwtO3x = new Rectangle(ybLVYbRtSje.Right - _kHeUdEVYNDni2Diabntx.value - _kHeUdEVYNDni2Diabntx.value, ybLVYbRtSje.Top + (ybLVYbRtSje.Height - _kHeUdEVYNDni2Diabntx.value) / 2, _kHeUdEVYNDni2Diabntx.value, _kHeUdEVYNDni2Diabntx.value);
			Rectangle sW3VYSDk01u = Rectangle.FromLTRB(ybLVYbRtSje.Left + _kHeUdEVYNDni2Diabntx.value, ybLVYbRtSje.Top + _kHeUdEVYNDni2Diabntx.value, Math.Max(ybLVYbRtSje.Left + _kHeUdEVYNDni2Diabntx.value, poEVYwtO3x.Left - _kHeUdEVYNDni2Diabntx.value), ybLVYbRtSje.Bottom + _kHeUdEVYNDni2Diabntx.value);
			k1OnlOVYt3JiSMCcv4U4.Items.Add(new DrhxL2VYZcXZxBQhNUGG
			{
				aiHelper_10 = item,
				text = text,
				ybLVYbRtSje = ybLVYbRtSje,
				rectangle = sW3VYSDk01u,
				rectangle = poEVYwtO3x
			});
			num2 += num4 + _kHeUdEVYNDni2Diabntx.value;
		}
		k1OnlOVYt3JiSMCcv4U4.RowCount = ((TkZ7O3mOur.Count == 0) ? 1 : (num3 + 1));
		k1OnlOVYt3JiSMCcv4U4.DesiredHeight = Math.Max(_kHeUdEVYNDni2Diabntx.value, k1OnlOVYt3JiSMCcv4U4.RowCount * _kHeUdEVYNDni2Diabntx.RowHeight);
		return k1OnlOVYt3JiSMCcv4U4;
	}

	private int wZO7fDKJMZ(Graphics P_0, string P_1)
	{
		int num = TextRenderer.MeasureText(P_0, P_1 ?? string.Empty, Font).Width + _kHeUdEVYNDni2Diabntx.value * 2 + _kHeUdEVYNDni2Diabntx.value + _kHeUdEVYNDni2Diabntx.value * 2;
		Helper_1 officeTab = TableBorderConfig.Current.Config.OfficeTab;
		officeTab.AdjustHeight();
		if (officeTab.FuAtZSN641())
		{
			return Math.Min(num, jTo7oGwydx(officeTab.TabMaxWidth));
		}
		return num;
	}

	private int R9D7MNqcbg(Graphics P_0)
	{
		int num = _kHeUdEVYNDni2Diabntx.value * 2;
		for (int i = 0; i < TkZ7O3mOur.Count; i++)
		{
			num += wZO7fDKJMZ(P_0, oQE7t3oZKo(TkZ7O3mOur[i]));
			if (i < TkZ7O3mOur.Count - 1)
			{
				num += _kHeUdEVYNDni2Diabntx.value;
			}
		}
		return num;
	}

	private void Doh7bjag9i(Graphics P_0, DrhxL2VYZcXZxBQhNUGG P_1)
	{
		bool isActive = P_1.aiHelper_10.IsActive;
		bool flag = P_1.aiHelper_10.Key == _string;
		Color color = (isActive ? Color.White : (flag ? Color.FromArgb(248, 250, 253) : Color.FromArgb(235, 239, 245)));
		Color color2 = (isActive ? Color.FromArgb(183, 194, 210) : Color.FromArgb(211, 218, 229));
		Color foreColor = (isActive ? Color.FromArgb(30, 32, 36) : Color.FromArgb(82, 88, 98));
		using (GraphicsPath path = SOF7muKw5d(P_1.ybLVYbRtSje, _kHeUdEVYNDni2Diabntx.CornerRadius))
		{
			using SolidBrush brush = new SolidBrush(color);
			using Pen pen = new Pen(color2);
			P_0.FillPath(brush, path);
			P_0.DrawPath(pen, path);
		}
		if (isActive)
		{
			using (SolidBrush brush2 = new SolidBrush(sPs7lnEAFq(TableBorderConfig.Current.Config.OfficeTab.ActiveAccentColor, Color.FromArgb(43, 116, 242))))
			{
				P_0.FillRectangle(brush2, P_1.ybLVYbRtSje.Left + 2, P_1.ybLVYbRtSje.Top + 1, Math.Max(1, P_1.ybLVYbRtSje.Width - 4), 2);
			}
			using SolidBrush brush3 = new SolidBrush(Color.White);
			P_0.FillRectangle(brush3, P_1.ybLVYbRtSje.Left + 1, P_1.ybLVYbRtSje.Bottom - 2, Math.Max(1, P_1.ybLVYbRtSje.Width - 2), 3);
		}
		TextRenderer.DrawText(P_0, P_1.text, Font, P_1.rectangle, foreColor, TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter);
		BSR7SPwLy0(P_0, P_1.rectangle, P_1.aiHelper_10.Key == _string, isActive);
	}

	private void BSR7SPwLy0(Graphics P_0, Rectangle P_1, bool P_2, bool P_3)
	{
		if (P_2)
		{
			using GraphicsPath path = X387NXy68g(P_1, Math.Max(3, P_1.Width / 2));
			using SolidBrush brush = new SolidBrush(Color.FromArgb(229, 88, 88));
			P_0.FillPath(brush, path);
		}
		using Pen pen = new Pen(P_2 ? Color.White : (P_3 ? Color.FromArgb(120, 120, 120) : Color.FromArgb(150, 150, 150)), Math.Max(1f, elV7GLw3rs(1.05f)));
		int num = Math.Max(3, jTo7oGwydx(3));
		P_0.DrawLine(pen, P_1.Left + num, P_1.Top + num, P_1.Right - num - 1, P_1.Bottom - num - 1);
		P_0.DrawLine(pen, P_1.Right - num - 1, P_1.Top + num, P_1.Left + num, P_1.Bottom - num - 1);
	}

	private s64GrAVY4oaB7t7vkJ1d t3R7wwREte(Point P_0)
	{
		DNm7LNT9WI();
		using (Graphics graphics = CreateGraphics())
		{
			foreach (DrhxL2VYZcXZxBQhNUGG item in bpQ7Z6Vn1c(graphics, base.Width).Items)
			{
				Rectangle ybLVYbRtSje = item.ybLVYbRtSje;
				if (ybLVYbRtSje.Contains(P_0))
				{
					string toolTip = (string.IsNullOrWhiteSpace(item.aiHelper_10.FullName) ? item.aiHelper_10.Name : item.aiHelper_10.FullName);
					ybLVYbRtSje = item.rectangle;
					if (ybLVYbRtSje.Contains(P_0))
					{
						return new s64GrAVY4oaB7t7vkJ1d
						{
							yB3JfAVY2lmMnyG9udwr = (YB3JfAVY2lmMnyG9udwr)2,
							vlwVYYOlrqX = item.aiHelper_10.Key,
							ToolTip = "关闭 " + item.aiHelper_10.Name
						};
					}
					return new s64GrAVY4oaB7t7vkJ1d
					{
						yB3JfAVY2lmMnyG9udwr = (YB3JfAVY2lmMnyG9udwr)1,
						vlwVYYOlrqX = item.aiHelper_10.Key,
						ToolTip = toolTip
					};
				}
			}
		}
		return new s64GrAVY4oaB7t7vkJ1d
		{
			yB3JfAVY2lmMnyG9udwr = YB3JfAVY2lmMnyG9udwr.None
		};
	}

	private static string oQE7t3oZKo(AiHelper_10 P_0)
	{
		string text = P_0?.Name ?? string.Empty;
		if (!string.IsNullOrWhiteSpace(P_0?.FullName))
		{
			text = Path.GetFileName(P_0.FullName);
		}
		Helper_1 officeTab = TableBorderConfig.Current.Config.OfficeTab;
		officeTab.AdjustHeight();
		if (officeTab.FuAtZSN641() && text.Length > officeTab.DocumentNamePrefixLength)
		{
			text = text.Substring(0, officeTab.DocumentNamePrefixLength) + "..";
		}
		return ((P_0 != null && !P_0.IsSaved) ? "*" : string.Empty) + text;
	}

	private void DNm7LNT9WI()
	{
		Helper_1 officeTab = TableBorderConfig.Current.Config.OfficeTab;
		officeTab.AdjustHeight();
		string text = (string.IsNullOrWhiteSpace(officeTab.FontName) ? "Microsoft YaHei UI" : officeTab.FontName);
		float num = Math.Max(7f, Math.Min(18f, (float)officeTab.FontSize));
		if (_font == null || !string.Equals(_string, text, StringComparison.Ordinal) || Math.Abs(_float - num) > 0.01f)
		{
			Font font = MRy7syHbkg(text, num);
			Font font2 = _font;
			_font = font;
			_string = text;
			_float = num;
			Font = font;
			font2?.Dispose();
		}
		int num2 = TextRenderer.MeasureText("Mg", Font).Height;
		int num3 = Math.Max(jTo7oGwydx(20), num2 + jTo7oGwydx(10));
		_kHeUdEVYNDni2Diabntx = new KHeUdEVYNDni2Diabntx
		{
			value = Math.Max(jTo7oGwydx(26), officeTab.Height),
			value = num3,
			RowHeight = Math.Max(jTo7oGwydx(26), num3),
			value = jTo7oGwydx(14),
			value = jTo7oGwydx(6),
			value = jTo7oGwydx(2),
			CornerRadius = jTo7oGwydx(4),
			value = Math.Min(jTo7oGwydx(12), Math.Max(8, num3 - jTo7oGwydx(6))),
			value = jTo7oGwydx(5),
			value = jTo7oGwydx(4),
			value = jTo7oGwydx(1)
		};
	}

	private static Font MRy7syHbkg(string P_0, float P_1)
	{
		try
		{
			return new Font(P_0, P_1, FontStyle.Regular, GraphicsUnit.Point);
		}
		catch
		{
			return new Font("Microsoft YaHei UI", P_1, FontStyle.Regular, GraphicsUnit.Point);
		}
	}

	private static Color sPs7lnEAFq(string P_0, Color P_1)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(P_0))
			{
				return P_1;
			}
			return ColorTranslator.FromHtml(P_0.Trim());
		}
		catch
		{
			return P_1;
		}
	}

	private static GraphicsPath X387NXy68g(Rectangle P_0, int P_1)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (P_0.Width <= 0 || P_0.Height <= 0)
		{
			return graphicsPath;
		}
		int num = Math.Min(P_1 * 2, Math.Min(P_0.Width, P_0.Height));
		if (num <= 1)
		{
			graphicsPath.AddRectangle(P_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		Rectangle rect = new Rectangle(P_0.X, P_0.Y, num, num);
		graphicsPath.AddArc(rect, 180f, 90f);
		rect.X = P_0.Right - num;
		graphicsPath.AddArc(rect, 270f, 90f);
		rect.Y = P_0.Bottom - num;
		graphicsPath.AddArc(rect, 0f, 90f);
		rect.X = P_0.X;
		graphicsPath.AddArc(rect, 90f, 90f);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	private static GraphicsPath SOF7muKw5d(Rectangle P_0, int P_1)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (P_0.Width <= 0 || P_0.Height <= 0)
		{
			return graphicsPath;
		}
		int num = Math.Min(P_1 * 2, Math.Min(P_0.Width, P_0.Height));
		if (num <= 1)
		{
			graphicsPath.AddRectangle(P_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		Rectangle rect = new Rectangle(P_0.X, P_0.Y, num, num);
		graphicsPath.AddArc(rect, 180f, 90f);
		rect.X = P_0.Right - num;
		graphicsPath.AddArc(rect, 270f, 90f);
		graphicsPath.AddLine(P_0.Right, P_0.Bottom, P_0.Left, P_0.Bottom);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	private int jTo7oGwydx(int P_0)
	{
		return Math.Max(1, (int)Math.Round((float)P_0 * ScaleRatio));
	}

	private float elV7GLw3rs(float P_0)
	{
		return Math.Max(0.5f, P_0 * ScaleRatio);
	}

	private static int Y6R7CQ87kJ(int P_0, int P_1, int P_2)
	{
		if (P_0 < P_1)
		{
			return P_1;
		}
		if (P_0 > P_2)
		{
			return P_2;
		}
		return P_0;
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0)
		{
			_toolTip.Dispose();
			_font?.Dispose();
		}
		base.Dispose(P_0);
	}
}
