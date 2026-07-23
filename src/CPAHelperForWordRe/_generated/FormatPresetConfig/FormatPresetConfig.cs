using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using RibbonMenuItem;
using Helper_14;
using AiHelper_20;
using Helper_12;
using TableBorderConfig;
using AiSseStreamService3;
using ConfigHelper_1;
using DelegateCommand;
using SseStreamInitializer;
using UiHelper_2;
using Helper_2;

namespace FormatPresetConfig;

internal sealed class FormatPresetConfig : Helper_2
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	internal struct _G_c__DisplayClass207_0
	{
		public Dictionary<string, string> JaJV2wnEdlA;
	}

	private readonly ConfigHelper_1 yQQNd0wXRg;

	private readonly HDS8hJGbnCWyNGfO01j pkKNzOr6LG;

	private bool RMtmRY12mx;

	private string lBCmVvFJW1;

	private string lvSmBtqVbD;

	private string yn0m94hKbc;

	private string LRRm6GJjZc;

	private string LOnmuvqlNR;

	private string q5gmDGwQab;

	private string xeXmTiV9oo;

	private string eWfmg5QVHT;

	private string qRTm8EPoIW;

	private string rTmmIkKnjo;

	private string gcCmiV6cbg;

	private string x6qmHNANFi;

	private string UngmQPZX68;

	private string LWYm1RkllA;

	private string c3smrV1DxY;

	private string cPnmJcv99d;

	private bool SPxm3K29gl;

	private bool pSCmUXAujA;

	private bool b5rmKWR3ab;

	private bool tsVmEAU2a6;

	private bool y9tm2Ru4Ul;

	private bool FD5m42lnbF;

	private string lxbmjAhYOJ;

	private string GV0mYEIRys;

	private string H3wmZp6A9e;

	private string v6amfDoirJ;

	[CompilerGenerated]
	private Action ArZmM2P3y7;

	[CompilerGenerated]
	private Action RlvmbRoGbi;

	[CompilerGenerated]
	private readonly ObservableCollection<string> VGNmSO6Hlg;

	[CompilerGenerated]
	private readonly ObservableCollection<string> pKnmw78MJc;

	[CompilerGenerated]
	private readonly ObservableCollection<string> ffwmtWuisC;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> OR8mL3kjTo;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> eVnmsVkyKM;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> xcNmlJmkSE;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> FRrmNHcoVE;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> du2mmkgfp1;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> sdTmo5DDjr;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> o36mGVIJNU;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> w8ymC0CB32;

	[CompilerGenerated]
	private readonly ObservableCollection<Helper_14> mSAmpOS99K;

	[CompilerGenerated]
	private readonly ObservableCollection<RibbonMenuItem> GoGmOKiS63;

	[CompilerGenerated]
	private readonly ObservableCollection<UiHelper_2> vZgmnXFbbI;

	[CompilerGenerated]
	private readonly ICommand tomm7DBPfh;

	[CompilerGenerated]
	private readonly ICommand IhVm5xUNLe;

	[CompilerGenerated]
	private readonly ICommand JY8mcSWuME;

	[CompilerGenerated]
	private readonly ICommand QvBmes1bFF;

	[CompilerGenerated]
	private readonly ICommand UUSmyMNmVS;

	[CompilerGenerated]
	private readonly ICommand G02mXu6PhS;

	[CompilerGenerated]
	private readonly ICommand bUWmFMuVAY;

	[CompilerGenerated]
	private readonly ICommand z15mhuUrcG;

	[CompilerGenerated]
	private readonly ICommand fqVmaPE7FN;

	public ObservableCollection<string> PresetNames
	{
		[CompilerGenerated]
		get
		{
			return VGNmSO6Hlg;
		}
	}

	public ObservableCollection<string> Fonts
	{
		[CompilerGenerated]
		get
		{
			return pKnmw78MJc;
		}
	}

	public ObservableCollection<string> FontSizes
	{
		[CompilerGenerated]
		get
		{
			return ffwmtWuisC;
		}
	}

	public ObservableCollection<Helper_14> BorderStyles
	{
		[CompilerGenerated]
		get
		{
			return OR8mL3kjTo;
		}
	}

	public ObservableCollection<Helper_14> BorderWidths
	{
		[CompilerGenerated]
		get
		{
			return eVnmsVkyKM;
		}
	}

	public ObservableCollection<Helper_14> HorizontalAlignments
	{
		[CompilerGenerated]
		get
		{
			return xcNmlJmkSE;
		}
	}

	public ObservableCollection<Helper_14> VerticalAlignments
	{
		[CompilerGenerated]
		get
		{
			return FRrmNHcoVE;
		}
	}

	public ObservableCollection<Helper_14> LineSpacingRules
	{
		[CompilerGenerated]
		get
		{
			return du2mmkgfp1;
		}
	}

	public ObservableCollection<Helper_14> SpacingUnits
	{
		[CompilerGenerated]
		get
		{
			return sdTmo5DDjr;
		}
	}

	public ObservableCollection<Helper_14> WidthModes
	{
		[CompilerGenerated]
		get
		{
			return o36mGVIJNU;
		}
	}

	public ObservableCollection<Helper_14> UnderlineOptions
	{
		[CompilerGenerated]
		get
		{
			return w8ymC0CB32;
		}
	}

	public ObservableCollection<Helper_14> HeaderPriorityOptions
	{
		[CompilerGenerated]
		get
		{
			return mSAmpOS99K;
		}
	}

	public ObservableCollection<RibbonMenuItem> BorderFields
	{
		[CompilerGenerated]
		get
		{
			return GoGmOKiS63;
		}
	}

	public ObservableCollection<UiHelper_2> AlignmentFields
	{
		[CompilerGenerated]
		get
		{
			return vZgmnXFbbI;
		}
	}

	public ICommand NewPresetCommand
	{
		[CompilerGenerated]
		get
		{
			return tomm7DBPfh;
		}
	}

	public ICommand DeletePresetCommand
	{
		[CompilerGenerated]
		get
		{
			return IhVm5xUNLe;
		}
	}

	public ICommand ImportPresetCommand
	{
		[CompilerGenerated]
		get
		{
			return JY8mcSWuME;
		}
	}

	public ICommand ExportPresetCommand
	{
		[CompilerGenerated]
		get
		{
			return QvBmes1bFF;
		}
	}

	public ICommand ChooseColorCommand
	{
		[CompilerGenerated]
		get
		{
			return UUSmyMNmVS;
		}
	}

	public ICommand ClearColorCommand
	{
		[CompilerGenerated]
		get
		{
			return G02mXu6PhS;
		}
	}

	public ICommand SaveCommand
	{
		[CompilerGenerated]
		get
		{
			return bUWmFMuVAY;
		}
	}

	public ICommand OpenParagraphCommand
	{
		[CompilerGenerated]
		get
		{
			return z15mhuUrcG;
		}
	}

	public ICommand CloseCommand
	{
		[CompilerGenerated]
		get
		{
			return fqVmaPE7FN;
		}
	}

	public string SelectedPreset
	{
		get
		{
			return lBCmVvFJW1;
		}
		set
		{
			if (RMtmRY12mx || string.IsNullOrWhiteSpace(value) || string.Equals(lBCmVvFJW1, value, StringComparison.Ordinal))
			{
				return;
			}
			try
			{
				if (!yQQNd0wXRg.haGSSyJWCc(value))
				{
					fpVsxno8nm("SelectedPreset");
					return;
				}
				lBCmVvFJW1 = value;
				fpVsxno8nm("SelectedPreset");
				HchNCvEEG9(yQQNd0wXRg.COQStnlspT(value));
			}
			catch (Exception ex)
			{
				pkKNzOr6LG.ULjVLJjCx1c("切换表格方案失败：" + ex.Message, "IP_Assurance");
			}
		}
	}

	public string TopPadding
	{
		get
		{
			return lvSmBtqVbD;
		}
		set
		{
			MrCsWWMvwp(ref lvSmBtqVbD, value, "TopPadding");
		}
	}

	public string BottomPadding
	{
		get
		{
			return yn0m94hKbc;
		}
		set
		{
			MrCsWWMvwp(ref yn0m94hKbc, value, "BottomPadding");
		}
	}

	public string LeftPadding
	{
		get
		{
			return LRRm6GJjZc;
		}
		set
		{
			MrCsWWMvwp(ref LRRm6GJjZc, value, "LeftPadding");
		}
	}

	public string RightPadding
	{
		get
		{
			return LOnmuvqlNR;
		}
		set
		{
			MrCsWWMvwp(ref LOnmuvqlNR, value, "RightPadding");
		}
	}

	public string RowHeight
	{
		get
		{
			return q5gmDGwQab;
		}
		set
		{
			MrCsWWMvwp(ref q5gmDGwQab, value, "RowHeight");
		}
	}

	public string WidthMode
	{
		get
		{
			return xeXmTiV9oo;
		}
		set
		{
			if (MrCsWWMvwp(ref xeXmTiV9oo, sonNFtgWGK(value), "WidthMode"))
			{
				fpVsxno8nm("IsMaxColumnWidthEnabled");
			}
		}
	}

	public string MaxColumnWidth
	{
		get
		{
			return eWfmg5QVHT;
		}
		set
		{
			MrCsWWMvwp(ref eWfmg5QVHT, value, "MaxColumnWidth");
		}
	}

	public bool IsMaxColumnWidthEnabled => WidthMode == "自定义宽度";

	public string ChineseFont
	{
		get
		{
			return qRTm8EPoIW;
		}
		set
		{
			MrCsWWMvwp(ref qRTm8EPoIW, value, "ChineseFont");
		}
	}

	public string WesternFont
	{
		get
		{
			return rTmmIkKnjo;
		}
		set
		{
			MrCsWWMvwp(ref rTmmIkKnjo, value, "WesternFont");
		}
	}

	public string FontSize
	{
		get
		{
			return gcCmiV6cbg;
		}
		set
		{
			MrCsWWMvwp(ref gcCmiV6cbg, value, "FontSize");
		}
	}

	public string LineSpacingRule
	{
		get
		{
			return x6qmHNANFi;
		}
		set
		{
			if (MrCsWWMvwp(ref x6qmHNANFi, value, "LineSpacingRule"))
			{
				fpVsxno8nm("LineSpacingLabel");
				fpVsxno8nm("IsLineSpacingValueEnabled");
			}
		}
	}

	public string LineSpacing
	{
		get
		{
			return UngmQPZX68;
		}
		set
		{
			MrCsWWMvwp(ref UngmQPZX68, value, "LineSpacing");
		}
	}

	public string SpacingUnit
	{
		get
		{
			return LWYm1RkllA;
		}
		set
		{
			MrCsWWMvwp(ref LWYm1RkllA, value, "SpacingUnit");
		}
	}

	public string SpaceBefore
	{
		get
		{
			return c3smrV1DxY;
		}
		set
		{
			MrCsWWMvwp(ref c3smrV1DxY, value, "SpaceBefore");
		}
	}

	public string SpaceAfter
	{
		get
		{
			return cPnmJcv99d;
		}
		set
		{
			MrCsWWMvwp(ref cPnmJcv99d, value, "SpaceAfter");
		}
	}

	public bool HeaderBold
	{
		get
		{
			return SPxm3K29gl;
		}
		set
		{
			MrCsWWMvwp(ref SPxm3K29gl, value, "HeaderBold");
		}
	}

	public bool SerialColumnCenter
	{
		get
		{
			return pSCmUXAujA;
		}
		set
		{
			MrCsWWMvwp(ref pSCmUXAujA, value, "SerialColumnCenter");
		}
	}

	public string HeaderPriority
	{
		get
		{
			return lxbmjAhYOJ;
		}
		set
		{
			MrCsWWMvwp(ref lxbmjAhYOJ, b0NNXGD9aO(value), "HeaderPriority");
		}
	}

	public string TotalUnderline
	{
		get
		{
			return GV0mYEIRys;
		}
		set
		{
			MrCsWWMvwp(ref GV0mYEIRys, value, "TotalUnderline");
		}
	}

	public string SubtotalUnderline
	{
		get
		{
			return H3wmZp6A9e;
		}
		set
		{
			MrCsWWMvwp(ref H3wmZp6A9e, value, "SubtotalUnderline");
		}
	}

	public bool SummaryUnderlineIncludesText
	{
		get
		{
			return b5rmKWR3ab;
		}
		set
		{
			MrCsWWMvwp(ref b5rmKWR3ab, value, "SummaryUnderlineIncludesText");
		}
	}

	public bool TotalBold
	{
		get
		{
			return tsVmEAU2a6;
		}
		set
		{
			MrCsWWMvwp(ref tsVmEAU2a6, value, "TotalBold");
		}
	}

	public bool SummaryBoldIncludesText
	{
		get
		{
			return y9tm2Ru4Ul;
		}
		set
		{
			MrCsWWMvwp(ref y9tm2Ru4Ul, value, "SummaryBoldIncludesText");
		}
	}

	public bool SubtotalBold
	{
		get
		{
			return FD5m42lnbF;
		}
		set
		{
			MrCsWWMvwp(ref FD5m42lnbF, value, "SubtotalBold");
		}
	}

	public string HeaderColorValue
	{
		get
		{
			return v6amfDoirJ;
		}
		set
		{
			if (MrCsWWMvwp(ref v6amfDoirJ, value, "HeaderColorValue"))
			{
				fpVsxno8nm("HeaderColorText");
				fpVsxno8nm("HeaderColorBrush");
			}
		}
	}

	public string HeaderColorText
	{
		get
		{
			if (!int.TryParse(HeaderColorValue, out var result) || result == -16777216)
			{
				return "无底色";
			}
			return HeaderColorValue;
		}
	}

	public Brush HeaderColorBrush
	{
		get
		{
			if (!int.TryParse(HeaderColorValue, out var result) || result == -16777216)
			{
				return Brushes.White;
			}
			return new SolidColorBrush(Color.FromRgb((byte)(result & 0xFF), (byte)((result >> 8) & 0xFF), (byte)((result >> 16) & 0xFF)));
		}
	}

	public string LineSpacingLabel
	{
		get
		{
			if (!(LineSpacingRule == "3") && !(LineSpacingRule == "4"))
			{
				if (!(LineSpacingRule == "5"))
				{
					return "设置值";
				}
				return "设置值(倍数)";
			}
			return "设置值(磅)";
		}
	}

	public bool IsLineSpacingValueEnabled
	{
		get
		{
			if (!(LineSpacingRule == "3") && !(LineSpacingRule == "4"))
			{
				return LineSpacingRule == "5";
			}
			return true;
		}
	}

	public FormatPresetConfig(HDS8hJGbnCWyNGfO01j P_0)
	{
		SseStreamInitializer.AlBVL0oCCKQ();
		yQQNd0wXRg = new ConfigHelper_1("表格预设");
		v6amfDoirJ = "-16777216";
		VGNmSO6Hlg = new ObservableCollection<string>();
		GoGmOKiS63 = new ObservableCollection<RibbonMenuItem>();
		vZgmnXFbbI = new ObservableCollection<UiHelper_2>();
		pkKNzOr6LG = P_0 ?? throw new ArgumentNullException("dialogs");
		pKnmw78MJc = new ObservableCollection<string>(new string[9]
		{
			"宋体",
			"黑体",
			"微软雅黑",
			"楷体",
			"仿宋",
			"等线",
			"Arial",
			"Times New Roman",
			"Calibri"
		});
		ffwmtWuisC = new ObservableCollection<string>(from item in AiHelper_20.csfwB6TYGU()
			select item.Item2);
		OR8mL3kjTo = BAiNsYbegG(("无边框", "0"), ("单实线", "1"), ("点线", "2"), ("短划线", "3"), ("点划线", "4"), ("双点划线", "5"), ("细虚线", "6"), ("双实线", "7"), ("粗-细双线", "9"), ("细-粗双线", "10"));
		eVnmsVkyKM = BAiNsYbegG(("0.25磅", "2"), ("0.5磅", "4"), ("0.75磅", "6"), ("1磅", "8"), ("1.5磅", "12"), ("2.25磅", "18"), ("3磅", "24"), ("4.5磅", "36"), ("6磅", "48"));
		xcNmlJmkSE = BAiNsYbegG(("左对齐", "0"), ("居中", "1"), ("右对齐", "2"), ("两端对齐", "3"));
		FRrmNHcoVE = BAiNsYbegG(("顶端", "0"), ("居中", "1"), ("底端", "3"));
		du2mmkgfp1 = BAiNsYbegG(("单倍行距", "0"), ("1.5倍行距", "1"), ("双倍行距", "2"), ("最小值", "3"), ("固定值", "4"), ("多倍行距", "5"));
		sdTmo5DDjr = BAiNsYbegG(("行", "行"), ("磅", "磅"));
		o36mGVIJNU = BAiNsYbegG(("自适应宽度", "自适应宽度"), ("自定义宽度", "自定义宽度"));
		w8ymC0CB32 = BAiNsYbegG(("无", "0"), ("单下划线", "1"), ("双下划线", "3"));
		mSAmpOS99K = BAiNsYbegG(("首行优先", "首行"), ("首列优先", "首列"));
		SPhNl4gZtt();
		tomm7DBPfh = new DelegateCommand(Oo6Nnxg7FW);
		IhVm5xUNLe = new DelegateCommand(v3tN7yQU9v);
		JY8mcSWuME = new DelegateCommand(f2JN5t390X);
		QvBmes1bFF = new DelegateCommand(qZDNc8B8of);
		UUSmyMNmVS = new DelegateCommand(cxfNejZcGA);
		G02mXu6PhS = new DelegateCommand((Action)delegate
		{
			HeaderColorValue = "SelectedPreset";
		}, (Func<bool>)null);
		bUWmFMuVAY = new DelegateCommand(CmaNyetNlS);
		z15mhuUrcG = new DelegateCommand((Action)delegate
		{
			RlvmbRoGbi?.Invoke();
		}, (Func<bool>)null);
		fqVmaPE7FN = new DelegateCommand((Action)delegate
		{
			ArZmM2P3y7?.Invoke();
		}, (Func<bool>)null);
		YIaNmkmpjo();
		AeiNGYhXCg();
	}

	[SpecialName]
	[CompilerGenerated]
	public void BBoNAij429(Action P_0)
	{
		Action action = ArZmM2P3y7;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref ArZmM2P3y7, value, action2);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	[CompilerGenerated]
	public void X7CNvN0M4s(Action P_0)
	{
		Action action = ArZmM2P3y7;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref ArZmM2P3y7, value, action2);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	[CompilerGenerated]
	public void QdBN0W28SI(Action P_0)
	{
		Action action = RlvmbRoGbi;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Combine(action2, P_0);
			action = Interlocked.CompareExchange(ref RlvmbRoGbi, value, action2);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	[CompilerGenerated]
	public void NnNNkK5FPe(Action P_0)
	{
		Action action = RlvmbRoGbi;
		Action action2;
		do
		{
			action2 = action;
			Action value = (Action)Delegate.Remove(action2, P_0);
			action = Interlocked.CompareExchange(ref RlvmbRoGbi, value, action2);
		}
		while ((object)action != action2);
	}

	private static ObservableCollection<Helper_14> BAiNsYbegG(params (string, string)[] values)
	{
		return new ObservableCollection<Helper_14>(values.Select(((string Text, string Value) value) => new Helper_14(value.Text, value.Value)));
	}

	private void SPhNl4gZtt()
	{
		NlQNNi4w7f("通用表格边框", "左侧框线", "右侧框线", "上侧框线", "底边框线", "横向框线", "纵向框线");
		NlQNNi4w7f("特殊行/列边框", "表头底边框线", "首列右边框线", "合计行上边框线", "合计行下边框线", "小计行上边框线", "小计行下边框线");
		string[] array = new string[5]
		{
			"首列",
			"首行",
			"文字",
			"数字",
			"合计"
		};
		foreach (string text in array)
		{
			AlignmentFields.Add(new UiHelper_2(text));
		}
	}

	private void NlQNNi4w7f(string P_0, params string[] keys)
	{
		BorderFields.Add(RibbonMenuItem.SObmA0Jxbq(P_0));
		foreach (string text in keys)
		{
			BorderFields.Add(new RibbonMenuItem(text));
		}
	}

	private void YIaNmkmpjo()
	{
		string text = TableBorderConfig.Current.KxPSXHwy4c("表格配置_方案名", string.Empty).Trim();
		string text2 = ((!string.IsNullOrWhiteSpace(text) && yQQNd0wXRg.haGSSyJWCc(text)) ? text : yQQNd0wXRg.ExsSbMHeGd().FirstOrDefault());
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = "默认方案";
			yQQNd0wXRg.D73SsBjrqd(text2, sSpNoDVtIq());
		}
		lBCmVvFJW1 = text2;
		HchNCvEEG9(yQQNd0wXRg.COQStnlspT(text2));
	}

	private static Dictionary<string, string> sSpNoDVtIq()
	{
		return (from pair in TableBorderConfig.Current.dnEScXBL9Y()
			where pair.Key.StartsWith("SelectedPreset", StringComparison.Ordinal)
			select pair).ToDictionary((KeyValuePair<string, object> pair) => pair.Key, (KeyValuePair<string, object> pair) => pair.Value?.ToString() ?? string.Empty);
	}

	private void AeiNGYhXCg()
	{
		RMtmRY12mx = true;
		PresetNames.Clear();
		foreach (string item in yQQNd0wXRg.ExsSbMHeGd())
		{
			PresetNames.Add(item);
		}
		fpVsxno8nm("SelectedPreset");
		RMtmRY12mx = false;
	}

	private void HchNCvEEG9(Dictionary<string, string> P_0)
	{
		_G_c__DisplayClass207_0 _G_c__DisplayClass207_1 = default(_G_c__DisplayClass207_0);
		_G_c__DisplayClass207_1.JaJV2wnEdlA = P_0;
		TopPadding = jZDNPJ22Xd("表格_单元格_上边距", "0", ref _G_c__DisplayClass207_1);
		BottomPadding = jZDNPJ22Xd("表格_单元格_下边距", "0", ref _G_c__DisplayClass207_1);
		LeftPadding = jZDNPJ22Xd("表格_单元格_左边距", "7", ref _G_c__DisplayClass207_1);
		RightPadding = jZDNPJ22Xd("表格_单元格_右边距", "7", ref _G_c__DisplayClass207_1);
		RowHeight = jZDNPJ22Xd("表格_行_行高", "0.7", ref _G_c__DisplayClass207_1);
		WidthMode = jZDNPJ22Xd("表格_宽度模式", "自适应宽度", ref _G_c__DisplayClass207_1);
		MaxColumnWidth = jZDNPJ22Xd("表格_最大列宽_宽度", "18.5", ref _G_c__DisplayClass207_1);
		ChineseFont = jZDNPJ22Xd("表格_段落格式_中文字体", "宋体", ref _G_c__DisplayClass207_1);
		WesternFont = jZDNPJ22Xd("表格_段落格式_西文字体", "宋体", ref _G_c__DisplayClass207_1);
		FontSize = AiHelper_20.v8Ewuw33fP(jZDNPJ22Xd("表格_段落格式_字号", "9", ref _G_c__DisplayClass207_1));
		LineSpacingRule = jZDNPJ22Xd("表格_段落格式_行距样式", "4", ref _G_c__DisplayClass207_1);
		LineSpacing = jZDNPJ22Xd("表格_段落格式_行距值", "18", ref _G_c__DisplayClass207_1);
		SpacingUnit = jZDNPJ22Xd("表格_段落格式_段前距单位", "行", ref _G_c__DisplayClass207_1);
		SpaceBefore = jZDNPJ22Xd("表格_段落格式_段前距", "0", ref _G_c__DisplayClass207_1);
		SpaceAfter = jZDNPJ22Xd("表格_段落格式_段后距", "0", ref _G_c__DisplayClass207_1);
		HeaderBold = jZDNPJ22Xd("表格_段落格式_加粗", "1", ref _G_c__DisplayClass207_1) == "1";
		SerialColumnCenter = jZDNPJ22Xd("表格_段落格式_序号列居中", "0", ref _G_c__DisplayClass207_1) == "1";
		HeaderPriority = jZDNPJ22Xd("表格_段落格式_首行首列冲突优先级", "首行", ref _G_c__DisplayClass207_1);
		TotalUnderline = jZDNPJ22Xd("表格_合计处理_下划线", "3", ref _G_c__DisplayClass207_1);
		SubtotalUnderline = jZDNPJ22Xd("表格_小计处理_下划线", "1", ref _G_c__DisplayClass207_1);
		SummaryUnderlineIncludesText = jZDNPJ22Xd("表格_合计小计处理_下划线包含文字", jZDNPJ22Xd("表格_合计处理_下划线包含合计", "0", ref _G_c__DisplayClass207_1), ref _G_c__DisplayClass207_1) == "1";
		TotalBold = jZDNPJ22Xd("表格_合计处理_加粗", "0", ref _G_c__DisplayClass207_1) == "1";
		SummaryBoldIncludesText = jZDNPJ22Xd("表格_合计小计处理_加粗包含文字", jZDNPJ22Xd("表格_合计处理_加粗包含合计", "0", ref _G_c__DisplayClass207_1), ref _G_c__DisplayClass207_1) == "1";
		SubtotalBold = jZDNPJ22Xd("表格_小计处理_加粗", "0", ref _G_c__DisplayClass207_1) == "1";
		HeaderColorValue = jZDNPJ22Xd("表格_单元格_底色", "-16777216", ref _G_c__DisplayClass207_1);
		foreach (RibbonMenuItem item in BorderFields.Where((RibbonMenuItem field) => !field.IsSection))
		{
			item.StyleValue = TEfNpP7OSQ(_G_c__DisplayClass207_1.JaJV2wnEdlA, "表格_边框样式_", item.Key, (item.Key == "表头底边框线") ? "0" : "1");
			item.WidthValue = TEfNpP7OSQ(_G_c__DisplayClass207_1.JaJV2wnEdlA, "表格_边框粗细_", item.Key, "4");
		}
		foreach (UiHelper_2 alignmentField in AlignmentFields)
		{
			alignmentField.HorizontalValue = jZDNPJ22Xd("表格_段落格式_" + alignmentField.Key + "水平对齐", (alignmentField.Key == "数字") ? "1" : "2", ref _G_c__DisplayClass207_1);
			alignmentField.VerticalValue = jZDNPJ22Xd("表格_段落格式_" + alignmentField.Key + "垂直对齐", "1", ref _G_c__DisplayClass207_1);
		}
	}

	private static string TEfNpP7OSQ(Dictionary<string, string> P_0, string P_1, string P_2, string P_3)
	{
		if (P_0.TryGetValue(P_1 + P_2, out var value) && !string.IsNullOrEmpty(value))
		{
			return value;
		}
		if (P_2 == "合计行下边框线" && P_0.TryGetValue(P_1 + "表尾底边框线", out value) && !string.IsNullOrEmpty(value))
		{
			return value;
		}
		return P_3;
	}

	private bool LsWNObRqVx(out Dictionary<string, string> P_0)
	{
		P_0 = null;
		if (!AiHelper_20.WmHw9yYx65(FontSize, out var value))
		{
			pkKNzOr6LG.GZdVLrQIdas("字号填写有误，请选择 Word 字号或输入数字磅值。", "IP_Assurance");
			return false;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			["表格_单元格_上边距"] = TopPadding ?? string.Empty,
			["表格_单元格_下边距"] = BottomPadding ?? string.Empty,
			["表格_单元格_左边距"] = LeftPadding ?? string.Empty,
			["表格_单元格_右边距"] = RightPadding ?? string.Empty,
			["表格_行_行高"] = RowHeight ?? string.Empty,
			["表格_宽度模式"] = sonNFtgWGK(WidthMode),
			["表格_最大列宽_宽度"] = MaxColumnWidth ?? string.Empty,
			["表格_段落格式_中文字体"] = ChineseFont ?? string.Empty,
			["表格_段落格式_西文字体"] = WesternFont ?? string.Empty,
			["表格_段落格式_字号"] = value,
			["表格_段落格式_行距样式"] = LineSpacingRule ?? string.Empty,
			["表格_段落格式_行距值"] = LineSpacing ?? string.Empty,
			["表格_段落格式_段前距单位"] = SpacingUnit ?? string.Empty,
			["表格_段落格式_段前距"] = SpaceBefore ?? string.Empty,
			["表格_段落格式_段后距"] = SpaceAfter ?? string.Empty,
			["表格_段落格式_加粗"] = (HeaderBold ? "0" : "1"),
			["表格_段落格式_序号列居中"] = (SerialColumnCenter ? "0" : "1"),
			["表格_段落格式_首行首列冲突优先级"] = b0NNXGD9aO(HeaderPriority),
			["表格_合计处理_下划线"] = TotalUnderline ?? string.Empty,
			["表格_合计小计处理_下划线包含文字"] = (SummaryUnderlineIncludesText ? "0" : "1"),
			["表格_合计处理_下划线包含合计"] = (SummaryUnderlineIncludesText ? "0" : "1"),
			["表格_小计处理_下划线"] = SubtotalUnderline ?? string.Empty,
			["表格_合计处理_加粗"] = (TotalBold ? "0" : "1"),
			["表格_合计小计处理_加粗包含文字"] = (SummaryBoldIncludesText ? "0" : "1"),
			["表格_合计处理_加粗包含合计"] = (SummaryBoldIncludesText ? "0" : "1"),
			["表格_小计处理_加粗"] = (SubtotalBold ? "0" : "1"),
			["表格_单元格_底色"] = HeaderColorValue ?? "-16777216"
		};
		foreach (RibbonMenuItem item in BorderFields.Where((RibbonMenuItem field) => !field.IsSection))
		{
			dictionary["表格_边框样式_" + item.Key] = item.StyleValue ?? string.Empty;
			dictionary["表格_边框粗细_" + item.Key] = item.WidthValue ?? string.Empty;
		}
		foreach (UiHelper_2 alignmentField in AlignmentFields)
		{
			dictionary["表格_段落格式_" + alignmentField.Key + "水平对齐"] = alignmentField.HorizontalValue ?? string.Empty;
			dictionary["表格_段落格式_" + alignmentField.Key + "垂直对齐"] = alignmentField.VerticalValue ?? string.Empty;
		}
		P_0 = dictionary;
		return true;
	}

	private void Oo6Nnxg7FW()
	{
		string text = pkKNzOr6LG.hveVL8NJXjM("新建方案", "请输入新方案名称：", "我的方案");
		if (!string.IsNullOrWhiteSpace(text) && LsWNObRqVx(out var dictionary))
		{
			string text2 = yQQNd0wXRg.Ky0SN0Vqdg(text);
			yQQNd0wXRg.D73SsBjrqd(text2, dictionary);
			lBCmVvFJW1 = text2;
			AeiNGYhXCg();
		}
	}

	private void v3tN7yQU9v()
	{
		yQQNd0wXRg.Delete(lBCmVvFJW1);
		YIaNmkmpjo();
		AeiNGYhXCg();
	}

	private void f2JN5t390X()
	{
		string text = pkKNzOr6LG.BxkVLIlDE06("导入表格配置方案");
		if (text != null)
		{
			Dictionary<string, string> dictionary = yQQNd0wXRg.Pb7SLGhc8Y(text);
			if (!dictionary.Keys.Any((string key) => key.StartsWith("所选文件不包含表格配置数据。", StringComparison.Ordinal)))
			{
				pkKNzOr6LG.GZdVLrQIdas("IP_Assurance", "切换表格方案失败：");
				return;
			}
			string text2 = yQQNd0wXRg.Ky0SN0Vqdg(Path.GetFileNameWithoutExtension(text));
			yQQNd0wXRg.D73SsBjrqd(text2, dictionary);
			lBCmVvFJW1 = text2;
			HchNCvEEG9(dictionary);
			AeiNGYhXCg();
		}
	}

	private void qZDNc8B8of()
	{
		string text = pkKNzOr6LG.SA6VLiTt8Ir("导出表格配置方案", lBCmVvFJW1 + ".json");
		if (text != null && LsWNObRqVx(out var dictionary))
		{
			ConfigHelper_1.lRlSlvdQT7(text, dictionary);
		}
	}

	private void cxfNejZcGA()
	{
		int result;
		int? num = (int.TryParse(HeaderColorValue, out result) ? new int?(result) : ((int?)null));
		int? num2 = pkKNzOr6LG.KutVLHOhcIC(num);
		if (num2.HasValue)
		{
			HeaderColorValue = num2.Value.ToString();
		}
	}

	private void CmaNyetNlS()
	{
		try
		{
			if (!LsWNObRqVx(out var dictionary))
			{
				return;
			}
			Dictionary<string, object> dictionary2 = TableBorderConfig.Current.dnEScXBL9Y();
			dictionary2.Remove("表格_边框样式_表尾底边框线");
			dictionary2.Remove("表格_边框粗细_表尾底边框线");
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				dictionary2[item.Key] = item.Value;
			}
			dictionary2["表格配置_方案名"] = lBCmVvFJW1;
			TableBorderConfig.Current.TTVSewUqXZ(dictionary2);
			yQQNd0wXRg.D73SsBjrqd(lBCmVvFJW1, dictionary);
			pkKNzOr6LG.tfDVL1SJK0M("表格配置已保存。", "IP_Assurance");
		}
		catch (Exception ex)
		{
			pkKNzOr6LG.ULjVLJjCx1c("保存表格配置失败：" + ex.Message, "IP_Assurance");
		}
	}

	private static string b0NNXGD9aO(string P_0)
	{
		if (!string.Equals((P_0 ?? string.Empty).Trim(), "首列", StringComparison.Ordinal))
		{
			return "首行";
		}
		return "首列";
	}

	private static string sonNFtgWGK(string P_0)
	{
		if (!string.Equals((P_0 ?? string.Empty).Trim(), "自定义宽度", StringComparison.Ordinal))
		{
			return "自适应宽度";
		}
		return "自定义宽度";
	}

	[CompilerGenerated]
	private void dLdNhwmUFD()
	{
		HeaderColorValue = "-16777216";
	}

	[CompilerGenerated]
	private void sMGNaYQAsr()
	{
		RlvmbRoGbi?.Invoke();
	}

	[CompilerGenerated]
	private void lmeNqrlVVC()
	{
		ArZmM2P3y7?.Invoke();
	}

	[CompilerGenerated]
	internal static string jZDNPJ22Xd(string P_0, string P_1, ref _G_c__DisplayClass207_0 P_2)
	{
		if (!P_2.JaJV2wnEdlA.TryGetValue(P_0, out var value) || string.IsNullOrEmpty(value))
		{
			return P_1;
		}
		return value;
	}
}
