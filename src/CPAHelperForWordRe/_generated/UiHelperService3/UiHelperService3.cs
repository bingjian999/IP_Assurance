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
	private enum TabHitZone
	{
		None
	}

	private struct TabHitTestResult
	{
		public TabHitZone tabHitZone;

		public string tabKey;

		public string ToolTip;
	}

	private struct TabLayoutItem
	{
		public AiHelper_10 aiHelper_10;

		public string text;

		public Rectangle bounds;

		public Rectangle rectangle;

		public Rectangle rectangle;
	}

	private sealed class TabLayoutResult
	{
		[CompilerGenerated]
		private readonly List<TabLayoutItem> _items;

		[CompilerGenerated]
		private int _rowCount;

		[CompilerGenerated]
		private int _desiredHeight;

		public List<TabLayoutItem> Items
		{
			[CompilerGenerated]
			get
			{
				return _items;
			}
		}

		public int RowCount
		{
			[CompilerGenerated]
			get
			{
				return _rowCount;
			}
			[CompilerGenerated]
			set
			{
				_rowCount = value;
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

		public TabLayoutResult()
		{
			SseStreamInitializer.InitializeRuntime();
			_items = new List<TabLayoutItem>();
		}
	}

	private struct TabLayoutMetrics
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

	private List<AiHelper_10> _tabs;

	private string _string;

	private string _string;

	private Font _font;

	private string _string;

	private float _float;

	private TabLayoutMetrics _layoutMetrics;

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
		_tabs = new List<AiHelper_10>();
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		base.FormBorderStyle = FormBorderStyle.None;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.Manual;
		BackColor = Color.FromArgb(242, 244, 248);
		UpdateLayout();
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

	public void ShowOverlay()
	{
		UpdateLayout();
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

	public void SetTabs(List<AiHelper_10> P_0)
	{
		UpdateLayout();
		_tabs = P_0 ?? new List<AiHelper_10>();
		Invalidate();
	}

	public int GetDesiredHeight(int P_0)
	{
		UpdateLayout();
		if (P_0 <= 0)
		{
			return _layoutMetrics.value;
		}
		using Graphics graphics = CreateGraphics();
		return CalculateLayout(graphics, P_0).DesiredHeight;
	}

	public int GetDesiredWidth(int P_0)
	{
		UpdateLayout();
		if (P_0 <= 0)
		{
			return 0;
		}
		using Graphics graphics = CreateGraphics();
		int val = MeasureTotalWidth(graphics);
		return Math.Min(P_0, Math.Max(_layoutMetrics.value * 2 + 1, val));
	}

	protected override void OnPaint(PaintEventArgs P_0)
	{
		base.OnPaint(P_0);
		UpdateLayout();
		Graphics graphics = P_0.Graphics;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		using (SolidBrush brush = new SolidBrush(BackColor))
		{
			graphics.FillRectangle(brush, base.ClientRectangle);
		}
		foreach (TabLayoutItem item in CalculateLayout(graphics, base.Width).Items)
		{
			DrawTabItem(graphics, item);
		}
		using Pen pen = new Pen(Color.FromArgb(211, 216, 224));
		graphics.DrawLine(pen, 0, base.Height - 1, base.Width, base.Height - 1);
	}

	protected override void OnMouseMove(MouseEventArgs P_0)
	{
		base.OnMouseMove(P_0);
		TabHitTestResult hitTestResult = HitTest(P_0.Location);
		string tabKey = hitTestResult.tabKey;
		string text = ((hitTestResult.tabHitZone == (TabHitZone)2) ? hitTestResult.tabKey : null);
		Cursor = ((hitTestResult.tabHitZone == TabHitZone.None) ? Cursors.Default : Cursors.Hand);
		_toolTip.SetToolTip(this, hitTestResult.ToolTip ?? string.Empty);
		if (tabKey != _string || text != _string)
		{
			_string = tabKey;
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
			TabHitTestResult hitTestResult = HitTest(P_0.Location);
			if (hitTestResult.tabHitZone == (TabHitZone)2)
			{
				AiHelper_13.CloseTab(hitTestResult.tabKey);
			}
			else if (hitTestResult.tabHitZone == (TabHitZone)1)
			{
				AiHelper_13.ActivateTab(hitTestResult.tabKey);
			}
		}
	}

	private TabLayoutResult CalculateLayout(Graphics P_0, int P_1)
	{
		int num = Math.Max(P_1, _layoutMetrics.value * 2 + 1);
		int num2 = _layoutMetrics.value;
		int num3 = 0;
		TabLayoutResult layoutResult = new TabLayoutResult();
		foreach (AiHelper_10 item in _tabs)
		{
			string text = GetTabDisplayText(item);
			int num4 = MeasureTabWidth(P_0, text);
			if (num2 > _layoutMetrics.value && num2 + num4 > num - _layoutMetrics.value)
			{
				num3++;
				num2 = _layoutMetrics.value;
			}
			int num5 = num3 * _layoutMetrics.RowHeight + (_layoutMetrics.RowHeight - _layoutMetrics.value) / 2;
			Rectangle bounds = new Rectangle(num2, num5, num4, _layoutMetrics.value);
			Rectangle closeButtonBounds = new Rectangle(bounds.Right - _layoutMetrics.value - _layoutMetrics.value, bounds.Top + (bounds.Height - _layoutMetrics.value) / 2, _layoutMetrics.value, _layoutMetrics.value);
			Rectangle textBounds = Rectangle.FromLTRB(bounds.Left + _layoutMetrics.value, bounds.Top + _layoutMetrics.value, Math.Max(bounds.Left + _layoutMetrics.value, closeButtonBounds.Left - _layoutMetrics.value), bounds.Bottom + _layoutMetrics.value);
			layoutResult.Items.Add(new TabLayoutItem
			{
				aiHelper_10 = item,
				text = text,
				bounds = bounds,
				rectangle = textBounds,
				rectangle = closeButtonBounds
			});
			num2 += num4 + _layoutMetrics.value;
		}
		layoutResult.RowCount = ((_tabs.Count == 0) ? 1 : (num3 + 1));
		layoutResult.DesiredHeight = Math.Max(_layoutMetrics.value, layoutResult.RowCount * _layoutMetrics.RowHeight);
		return layoutResult;
	}

	private int MeasureTabWidth(Graphics P_0, string P_1)
	{
		int num = TextRenderer.MeasureText(P_0, P_1 ?? string.Empty, Font).Width + _layoutMetrics.value * 2 + _layoutMetrics.value + _layoutMetrics.value * 2;
		Helper_1 officeTab = TableBorderConfig.Current.Config.OfficeTab;
		officeTab.AdjustHeight();
		if (officeTab.IsMaxWidthEnabled())
		{
			return Math.Min(num, ScaleInt(officeTab.TabMaxWidth));
		}
		return num;
	}

	private int MeasureTotalWidth(Graphics P_0)
	{
		int num = _layoutMetrics.value * 2;
		for (int i = 0; i < _tabs.Count; i++)
		{
			num += MeasureTabWidth(P_0, GetTabDisplayText(_tabs[i]));
			if (i < _tabs.Count - 1)
			{
				num += _layoutMetrics.value;
			}
		}
		return num;
	}

	private void DrawTabItem(Graphics P_0, TabLayoutItem P_1)
	{
		bool isActive = P_1.aiHelper_10.IsActive;
		bool flag = P_1.aiHelper_10.Key == _string;
		Color color = (isActive ? Color.White : (flag ? Color.FromArgb(248, 250, 253) : Color.FromArgb(235, 239, 245)));
		Color color2 = (isActive ? Color.FromArgb(183, 194, 210) : Color.FromArgb(211, 218, 229));
		Color foreColor = (isActive ? Color.FromArgb(30, 32, 36) : Color.FromArgb(82, 88, 98));
		using (GraphicsPath path = CreateTabPath(P_1.bounds, _layoutMetrics.CornerRadius))
		{
			using SolidBrush brush = new SolidBrush(color);
			using Pen pen = new Pen(color2);
			P_0.FillPath(brush, path);
			P_0.DrawPath(pen, path);
		}
		if (isActive)
		{
			using (SolidBrush brush2 = new SolidBrush(ParseColorFromHtml(TableBorderConfig.Current.Config.OfficeTab.ActiveAccentColor, Color.FromArgb(43, 116, 242))))
			{
				P_0.FillRectangle(brush2, P_1.bounds.Left + 2, P_1.bounds.Top + 1, Math.Max(1, P_1.bounds.Width - 4), 2);
			}
			using SolidBrush brush3 = new SolidBrush(Color.White);
			P_0.FillRectangle(brush3, P_1.bounds.Left + 1, P_1.bounds.Bottom - 2, Math.Max(1, P_1.bounds.Width - 2), 3);
		}
		TextRenderer.DrawText(P_0, P_1.text, Font, P_1.rectangle, foreColor, TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter);
		DrawCloseButton(P_0, P_1.rectangle, P_1.aiHelper_10.Key == _string, isActive);
	}

	private void DrawCloseButton(Graphics P_0, Rectangle P_1, bool P_2, bool P_3)
	{
		if (P_2)
		{
			using GraphicsPath path = CreateRoundedRectanglePath(P_1, Math.Max(3, P_1.Width / 2));
			using SolidBrush brush = new SolidBrush(Color.FromArgb(229, 88, 88));
			P_0.FillPath(brush, path);
		}
		using Pen pen = new Pen(P_2 ? Color.White : (P_3 ? Color.FromArgb(120, 120, 120) : Color.FromArgb(150, 150, 150)), Math.Max(1f, ScaleFloat(1.05f)));
		int num = Math.Max(3, ScaleInt(3));
		P_0.DrawLine(pen, P_1.Left + num, P_1.Top + num, P_1.Right - num - 1, P_1.Bottom - num - 1);
		P_0.DrawLine(pen, P_1.Right - num - 1, P_1.Top + num, P_1.Left + num, P_1.Bottom - num - 1);
	}

	private TabHitTestResult HitTest(Point P_0)
	{
		UpdateLayout();
		using (Graphics graphics = CreateGraphics())
		{
			foreach (TabLayoutItem item in CalculateLayout(graphics, base.Width).Items)
			{
				Rectangle bounds = item.bounds;
				if (bounds.Contains(P_0))
				{
					string toolTip = (string.IsNullOrWhiteSpace(item.aiHelper_10.FullName) ? item.aiHelper_10.Name : item.aiHelper_10.FullName);
					bounds = item.rectangle;
					if (bounds.Contains(P_0))
					{
						return new TabHitTestResult
						{
							tabHitZone = (TabHitZone)2,
							tabKey = item.aiHelper_10.Key,
							ToolTip = "关闭 " + item.aiHelper_10.Name
						};
					}
					return new TabHitTestResult
					{
						tabHitZone = (TabHitZone)1,
						tabKey = item.aiHelper_10.Key,
						ToolTip = toolTip
					};
				}
			}
		}
		return new TabHitTestResult
		{
			tabHitZone = TabHitZone.None
		};
	}

	private static string GetTabDisplayText(AiHelper_10 P_0)
	{
		string text = P_0?.Name ?? string.Empty;
		if (!string.IsNullOrWhiteSpace(P_0?.FullName))
		{
			text = Path.GetFileName(P_0.FullName);
		}
		Helper_1 officeTab = TableBorderConfig.Current.Config.OfficeTab;
		officeTab.AdjustHeight();
		if (officeTab.IsMaxWidthEnabled() && text.Length > officeTab.DocumentNamePrefixLength)
		{
			text = text.Substring(0, officeTab.DocumentNamePrefixLength) + "..";
		}
		return ((P_0 != null && !P_0.IsSaved) ? "*" : string.Empty) + text;
	}

	private void UpdateLayout()
	{
		Helper_1 officeTab = TableBorderConfig.Current.Config.OfficeTab;
		officeTab.AdjustHeight();
		string text = (string.IsNullOrWhiteSpace(officeTab.FontName) ? "Microsoft YaHei UI" : officeTab.FontName);
		float num = Math.Max(7f, Math.Min(18f, (float)officeTab.FontSize));
		if (_font == null || !string.Equals(_string, text, StringComparison.Ordinal) || Math.Abs(_float - num) > 0.01f)
		{
			Font font = CreateFont(text, num);
			Font font2 = _font;
			_font = font;
			_string = text;
			_float = num;
			Font = font;
			font2?.Dispose();
		}
		int num2 = TextRenderer.MeasureText("Mg", Font).Height;
		int num3 = Math.Max(ScaleInt(20), num2 + ScaleInt(10));
		_layoutMetrics = new TabLayoutMetrics
		{
			value = Math.Max(ScaleInt(26), officeTab.Height),
			value = num3,
			RowHeight = Math.Max(ScaleInt(26), num3),
			value = ScaleInt(14),
			value = ScaleInt(6),
			value = ScaleInt(2),
			CornerRadius = ScaleInt(4),
			value = Math.Min(ScaleInt(12), Math.Max(8, num3 - ScaleInt(6))),
			value = ScaleInt(5),
			value = ScaleInt(4),
			value = ScaleInt(1)
		};
	}

	private static Font CreateFont(string P_0, float P_1)
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

	private static Color ParseColorFromHtml(string P_0, Color P_1)
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

	private static GraphicsPath CreateRoundedRectanglePath(Rectangle P_0, int P_1)
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

	private static GraphicsPath CreateTabPath(Rectangle P_0, int P_1)
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

	private int ScaleInt(int P_0)
	{
		return Math.Max(1, (int)Math.Round((float)P_0 * ScaleRatio));
	}

	private float ScaleFloat(float P_0)
	{
		return Math.Max(0.5f, P_0 * ScaleRatio);
	}

	private static int Clamp(int P_0, int P_1, int P_2)
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
