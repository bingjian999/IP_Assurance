using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using dL7TFPsQbAGqPywtHUK;
using gLbVIZKLH6Vb5OK2mnj;
using hJKpQrVSwRwMyI2RyDQN;
using Microsoft.Office.Interop.Word;
using Hyperlink = System.Windows.Documents.Hyperlink;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;
using Vn2FNvXfBBVtqPcjIyB;
using VZXZf1ccDRAexK4cV58;
using w5Oql9FwFDU9FYHJXvj;
using wRnHPKcpkuhmwE9uGcA;
using YNri0QclKMfRh2PQoZV;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class ExcelSyncWindow : System.Windows.Window, IComponentConnector
{
	private sealed class ffokv1V4hncupjXCMk8a
	{
		[CompilerGenerated]
		private int ULxV4aE1r9e;

		[CompilerGenerated]
		private string b80V4qFCs3r;

		public int WordColumnIndex
		{
			[CompilerGenerated]
			get
			{
				return ULxV4aE1r9e;
			}
			[CompilerGenerated]
			set
			{
				ULxV4aE1r9e = value;
			}
		}

		public string WordColumnLabel => "第 " + WordColumnIndex + " 列";

		public string ExcelColumnText
		{
			[CompilerGenerated]
			get
			{
				return b80V4qFCs3r;
			}
			[CompilerGenerated]
			set
			{
				b80V4qFCs3r = value;
			}
		}

		public ffokv1V4hncupjXCMk8a()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}
	}

	private sealed class WR0uULV4PciwXYvPdaNd : INotifyPropertyChanged
	{
		private bool weTV4v6h7MM;

		private bool TwOV4W9RFKy;

		[CompilerGenerated]
		private readonly ObservableCollection<WR0uULV4PciwXYvPdaNd> KWdV40XCEZg;

		[CompilerGenerated]
		private WR0uULV4PciwXYvPdaNd fEHV4kyDnOF;

		[CompilerGenerated]
		private Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve PoMV4xPNrt4;

		[CompilerGenerated]
		private string y46V4dQvJP8;

		[CompilerGenerated]
		private string M06V4zUnGVb;

		[CompilerGenerated]
		private int REqVjRKiDLT;

		[CompilerGenerated]
		private bool L2nVjVNEE6j;

		[CompilerGenerated]
		private bool EAZVjBXMI2e;

		[CompilerGenerated]
		private bool fKXVj9qHeDk;

		[CompilerGenerated]
		private PropertyChangedEventHandler m_PropertyChanged;

		public ObservableCollection<WR0uULV4PciwXYvPdaNd> Children
		{
			[CompilerGenerated]
			get
			{
				return KWdV40XCEZg;
			}
		}

		public WR0uULV4PciwXYvPdaNd Parent
		{
			[CompilerGenerated]
			get
			{
				return fEHV4kyDnOF;
			}
			[CompilerGenerated]
			set
			{
				fEHV4kyDnOF = value;
			}
		}

		public Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve Binding
		{
			[CompilerGenerated]
			get
			{
				return PoMV4xPNrt4;
			}
			[CompilerGenerated]
			set
			{
				PoMV4xPNrt4 = value;
			}
		}

		public string Text
		{
			[CompilerGenerated]
			get
			{
				return y46V4dQvJP8;
			}
			[CompilerGenerated]
			set
			{
				y46V4dQvJP8 = value;
			}
		}

		public string StatusBadge
		{
			[CompilerGenerated]
			get
			{
				return M06V4zUnGVb;
			}
			[CompilerGenerated]
			set
			{
				M06V4zUnGVb = value;
			}
		}

		public int Level
		{
			[CompilerGenerated]
			get
			{
				return REqVjRKiDLT;
			}
			[CompilerGenerated]
			set
			{
				REqVjRKiDLT = value;
			}
		}

		public bool IsHeading
		{
			[CompilerGenerated]
			get
			{
				return L2nVjVNEE6j;
			}
			[CompilerGenerated]
			set
			{
				L2nVjVNEE6j = value;
			}
		}

		public bool IsTable
		{
			[CompilerGenerated]
			get
			{
				return EAZVjBXMI2e;
			}
			[CompilerGenerated]
			set
			{
				EAZVjBXMI2e = value;
			}
		}

		public bool IsError
		{
			[CompilerGenerated]
			get
			{
				return fKXVj9qHeDk;
			}
			[CompilerGenerated]
			set
			{
				fKXVj9qHeDk = value;
			}
		}

		public bool IsExpanded
		{
			get
			{
				return weTV4v6h7MM;
			}
			set
			{
				if (weTV4v6h7MM != value)
				{
					weTV4v6h7MM = value;
					Ul7V4A45fcH("IsExpanded");
				}
			}
		}

		public bool IsSelected
		{
			get
			{
				return TwOV4W9RFKy;
			}
			set
			{
				if (TwOV4W9RFKy != value)
				{
					TwOV4W9RFKy = value;
					Ul7V4A45fcH("IsSelected");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.m_PropertyChanged;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.m_PropertyChanged;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		private void Ul7V4A45fcH([CallerMemberName] string propertyName = null)
		{
			this.m_PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public WR0uULV4PciwXYvPdaNd()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
			KWdV40XCEZg = new ObservableCollection<WR0uULV4PciwXYvPdaNd>();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass28_0
	{
		public int YCyVjLWQnEc;

		public ExcelSyncWindow Vd4Vjs388ul;

		public int hwxVjlUkQL8;

		public bool OwfVjNqotwf;

		public bool Gl3VjmsCxHn;

		public List<int> BnZVjocH3eE;

		public _G_c__DisplayClass28_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs AdqVjtn3bOl()
		{
			return Jk2boJKtvpW0C9HFNVs.v1r4oDajjF(YCyVjLWQnEc, Vd4Vjs388ul.chkSortEnabled.IsChecked == true, hwxVjlUkQL8, OwfVjNqotwf, Gl3VjmsCxHn, BnZVjocH3eE);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass29_0
	{
		public Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve yCkVjCuDhM5;

		public int Hp6VjpxIhZG;

		public ExcelSyncWindow r3sVjOsNBP6;

		public int bdBVjnriyke;

		public bool letVj7Vyv3E;

		public bool EAUVj5Fo2tZ;

		public List<int> VqiVjcFNj2A;

		public _G_c__DisplayClass29_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs zvxVjGNIPWX()
		{
			return Jk2boJKtvpW0C9HFNVs.bym4O8y0yd(yCkVjCuDhM5.BindingId, Hp6VjpxIhZG, r3sVjOsNBP6.chkAllSortEnabled.IsChecked == true, bdBVjnriyke, letVj7Vyv3E, EAUVj5Fo2tZ, VqiVjcFNj2A);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass36_0
	{
		public Jk2boJKtvpW0C9HFNVs.CkyBTaV87qVM3TwBrVFZ g8vVjyuYugM;

		public _G_c__DisplayClass36_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs FeFVjeEaljg()
		{
			Jk2boJKtvpW0C9HFNVs.BgnmcfV8ArSDWAKRwk0q bgnmcfV8ArSDWAKRwk0q = Jk2boJKtvpW0C9HFNVs.ebNEiWQuCH(g8vVjyuYugM);
			return new Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs
			{
				Success = bgnmcfV8ArSDWAKRwk0q.Success,
				RequiresUserAction = !bgnmcfV8ArSDWAKRwk0q.Success,
				Bound = bgnmcfV8ArSDWAKRwk0q.UpdatedCount,
				Failed = bgnmcfV8ArSDWAKRwk0q.SkippedCount,
				Message = bgnmcfV8ArSDWAKRwk0q.Message
			};
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass58_0
	{
		public ExcelSyncWindow L4IVjFYA0VL;

		public bool VR9VjhT7fJF;

		public bool VdaVjasONDp;

		public int exnVjqnH0MM;

		public _G_c__DisplayClass58_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void oaCVjXCqqYD()
		{
			try
			{
				if (!L4IVjFYA0VL.r7mnIQ3VfX && L4IVjFYA0VL.IsVisible)
				{
					L4IVjFYA0VL.XvJOKeRLxt(VR9VjhT7fJF);
				}
			}
			finally
			{
				if (VdaVjasONDp)
				{
					L4IVjFYA0VL.KwHOUY7w6K(exnVjqnH0MM);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass62_0
	{
		public ExcelSyncWindow cexVjAsRxWj;

		public string AUGVjv0lCH2;

		public _G_c__DisplayClass62_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void D4hVjPvPASJ()
		{
			cexVjAsRxWj.UJCO2ZWoW0(AUGVjv0lCH2);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass66_0
	{
		public string vwOVj0875AY;

		public _G_c__DisplayClass66_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal bool gKjVjWYbDZj(Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE group)
		{
			return string.Equals(group.ResolvedExcelPath, vwOVj0875AY, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass75_0
	{
		public Jk2boJKtvpW0C9HFNVs.zjEQMmV8xiap53qf2leG No1VjxXO7vN;

		public string ksKVjdTM071;

		public _G_c__DisplayClass75_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal bool lyWVjku7WgL(WR0uULV4PciwXYvPdaNd existing)
		{
			if (existing.IsHeading && existing.Level == No1VjxXO7vN.Level)
			{
				return string.Equals(existing.Text, ksKVjdTM071, StringComparison.Ordinal);
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass87_0
	{
		public int c73VYRUyF58;

		public _G_c__DisplayClass87_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal bool Vn5VjzmlJbD(Jk2boJKtvpW0C9HFNVs.l0FhISVIRyyYwtV64iqd item)
		{
			return item.WordColumnIndex == c73VYRUyF58;
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass92_0
	{
		public Func<Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs> cASVYBwvli2;

		public Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs xBZVY9np7wP;

		public _G_c__DisplayClass92_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void lneVYVoU6dm()
		{
			xBZVY9np7wP = cASVYBwvli2();
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass93_0
	{
		public Func<Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs> Yb0VYumO4a9;

		public Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs gTxVYDrAlNL;

		public _G_c__DisplayClass93_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void WBPVY6j54IW()
		{
			gTxVYDrAlNL = Yb0VYumO4a9();
		}
	}

	private readonly ObservableCollection<Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve> E3mn6NEThs;

	private readonly ObservableCollection<WR0uULV4PciwXYvPdaNd> nf4nuLGTDv;

	private readonly ObservableCollection<Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE> B9nnDK9dBG;

	private readonly ObservableCollection<ffokv1V4hncupjXCMk8a> VyXnT2klLm;

	private readonly ObservableCollection<ffokv1V4hncupjXCMk8a> PtTngkISNu;

	private readonly DispatcherTimer s7un8F22Xj;

	private bool r7mnIQ3VfX;

	private bool MZEniWtslN;

	private bool ubhnH7KepY;

	private bool OMKnQSfJqs;

	private bool k32n1upDwO;

	private bool UMlnrm6j8x;

	private bool kvinJXJO8H;

	private int W6Gn3PIlip;

	private Microsoft.Office.Interop.Word.Application ClanUwKOlF;

	private Jk2boJKtvpW0C9HFNVs.gMo5J5VI9LOS3nqRiEJZ bNZnKlpICU;

	private WR0uULV4PciwXYvPdaNd e9anEqjZMJ;

	internal System.Windows.Controls.TabControl tabSync;

	internal TabItem tabCurrent;

	internal System.Windows.Controls.ProgressBar barCurrentLoading;

	internal TextBlock txtCurrentCardTitle;

	internal System.Windows.Controls.Button btnRefreshExcelSelection;

	internal TextBlock txtWordStatus;

	internal TextBlock txtWordTable;

	internal TextBlock txtBindingSourceSummary;

	internal Hyperlink linkCurrentBindingSource;

	internal Run runBindingSourceSummary;

	internal TextBlock txtHeaderSetting;

	internal TextBlock lblExcelSelectionSummary;

	internal TextBlock txtExcelSelectionSummary;

	internal System.Windows.Controls.TextBox txtBindingId;

	internal System.Windows.Controls.TextBox txtExcelName;

	internal System.Windows.Controls.TextBox txtBoundPath;

	internal System.Windows.Controls.TextBox txtBoundSheet;

	internal System.Windows.Controls.TextBox txtExcelStatus;

	internal System.Windows.Controls.TextBox txtExcelWorkbook;

	internal System.Windows.Controls.TextBox txtExcelSheet;

	internal System.Windows.Controls.TextBox txtExcelAddress;

	internal System.Windows.Controls.TextBox txtExcelSize;

	internal System.Windows.Controls.TextBox txtHeaderRows;

	internal System.Windows.Controls.CheckBox chkSortEnabled;

	internal System.Windows.Controls.TextBox txtSortColumnIndex;

	internal System.Windows.Controls.ComboBox cboSortDirection;

	internal System.Windows.Controls.CheckBox chkSortPinOtherLast;

	internal System.Windows.Controls.DataGrid gridColumnMappings;

	internal System.Windows.Controls.Button btnSaveHeaderSetting;

	internal System.Windows.Controls.Button btnPrimaryCurrent;

	internal System.Windows.Controls.Button btnSplitCurrentTable;

	internal System.Windows.Controls.Button btnRebind;

	internal System.Windows.Controls.Button btnUnbind;

	internal System.Windows.Controls.ProgressBar barCurrentProgress;

	internal TextBlock txtCurrentStatus;

	internal System.Windows.Controls.Button btnCancelCurrent;

	internal TabItem tabAll;

	internal TextBlock txtAllSummary;

	internal System.Windows.Controls.Button btnRefreshAll;

	internal System.Windows.Controls.Button btnCleanInvalidBindings;

	internal System.Windows.Controls.ProgressBar barAllLoading;

	internal System.Windows.Controls.TreeView treeBindings;

	internal TextBlock txtAllDetailEmpty;

	internal ScrollViewer panelAllDetailContent;

	internal TextBlock txtAllDetailTitle;

	internal TextBlock txtAllDetailHeading;

	internal TextBlock txtAllDetailStatus;

	internal TextBlock txtAllDetailWordTable;

	internal TextBlock txtAllDetailWorkbook;

	internal TextBlock txtAllDetailSheet;

	internal TextBlock txtAllDetailName;

	internal Hyperlink linkAllDetailPath;

	internal Run runAllDetailPath;

	internal System.Windows.Controls.TextBox txtAllHeaderRows;

	internal System.Windows.Controls.CheckBox chkAllSortEnabled;

	internal System.Windows.Controls.TextBox txtAllSortColumnIndex;

	internal System.Windows.Controls.ComboBox cboAllSortDirection;

	internal System.Windows.Controls.CheckBox chkAllSortPinOtherLast;

	internal System.Windows.Controls.DataGrid gridAllColumnMappings;

	internal System.Windows.Controls.Button btnSaveAllHeaderSetting;

	internal StackPanel panelAllAdvancedDetails;

	internal TextBlock txtAllDetailBindingId;

	internal TextBlock txtAllDetailBookmark;

	internal System.Windows.Controls.Border borderAllError;

	internal TextBlock txtAllError;

	internal System.Windows.Controls.ProgressBar barAllProgress;

	internal TextBlock txtAllStatus;

	internal System.Windows.Controls.Button btnSyncSelected;

	internal System.Windows.Controls.Button btnSyncAll;

	internal System.Windows.Controls.Button btnExportAll;

	internal System.Windows.Controls.Button btnCancelAll;

	internal TabItem tabDataSources;

	internal TextBlock txtDataSourceSummary;

	internal System.Windows.Controls.Button btnRefreshDataSources;

	internal System.Windows.Controls.DataGrid gridDataSources;

	internal TextBlock txtDataSourceEmpty;

	internal ScrollViewer panelDataSourceDetailContent;

	internal TextBlock txtDataSourceTitle;

	internal TextBlock txtDataSourceStatus;

	internal TextBlock txtDataSourceBindingCount;

	internal TextBlock txtDataSourceNormalCount;

	internal TextBlock txtDataSourceMissingPathCount;

	internal TextBlock txtDataSourcePath;

	internal System.Windows.Controls.Button btnReplaceDataSource;

	internal System.Windows.Controls.Button btnOpenDataSourceFolder;

	internal System.Windows.Controls.Button btnJumpDataSourceBinding;

	internal System.Windows.Controls.ListBox listDataSourceBindings;

	internal TextBlock txtDataSourceStatusBar;

	internal TabItem tabOptions;

	internal System.Windows.Controls.CheckBox chkSyncHeaders;

	internal TextBlock txtContextMenuStatus;

	internal System.Windows.Controls.Button btnToggleContextMenu;

	internal System.Windows.Controls.CheckBox chkShowAdvancedColumns;

	internal TextBlock txtOptionsStatus;

	private bool Mven2dRYND;

	private Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve SelectedBinding
	{
		get
		{
			if (e9anEqjZMJ == null || !e9anEqjZMJ.IsTable)
			{
				return null;
			}
			return e9anEqjZMJ.Binding;
		}
	}

	private Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE SelectedDataSourceGroup => gridDataSources?.SelectedItem as Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE;

	private Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve SelectedDataSourceBinding => listDataSourceBindings?.SelectedItem as Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve;

	public ExcelSyncWindow()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		E3mn6NEThs = new ObservableCollection<Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve>();
		nf4nuLGTDv = new ObservableCollection<WR0uULV4PciwXYvPdaNd>();
		B9nnDK9dBG = new ObservableCollection<Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE>();
		VyXnT2klLm = new ObservableCollection<ffokv1V4hncupjXCMk8a>();
		PtTngkISNu = new ObservableCollection<ffokv1V4hncupjXCMk8a>();
		InitializeComponent();
		treeBindings.ItemsSource = nf4nuLGTDv;
		gridDataSources.ItemsSource = B9nnDK9dBG;
		gridColumnMappings.ItemsSource = VyXnT2klLm;
		gridAllColumnMappings.ItemsSource = PtTngkISNu;
		s7un8F22Xj = new DispatcherTimer
		{
			Interval = TimeSpan.FromMilliseconds(150.0)
		};
		s7un8F22Xj.Tick += yeyOrHb3JZ;
		base.PreviewKeyDown += delegate(object P_0, System.Windows.Input.KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
		base.Loaded += delegate
		{
			txtAllSummary.Text = "数据同步";
			txtDataSourceSummary.Text = "绑定当前表";
			jpROigfFHQ();
			mxOOHYibqA();
			r5TOJtV7Bf(false, true);
			odEOteY3dg();
			R2SOLEqQR7();
			sJTOjaskhb();
			wl5OM5OnNS();
			anROS5dIum();
			EohOwGuhvN();
		};
		base.Closed += delegate
		{
			YQpOQgxdib();
		};
	}

	private void ShXp5vDsqH(object P_0, RoutedEventArgs P_1)
	{
		if (bNZnKlpICU != null && bNZnKlpICU.HasBinding)
		{
			UCrOh343Aw("数据同步", () => Jk2boJKtvpW0C9HFNVs.XVJ45smyDw(XGtOAmBcpX), false);
		}
		else if (bNZnKlpICU != null && bNZnKlpICU.HasWordTable)
		{
			UCrOh343Aw("绑定当前表", () => Jk2boJKtvpW0C9HFNVs.kKW4bxDk3L( false), true);
		}
		else
		{
			UCrOh343Aw("插入Excel选区", Jk2boJKtvpW0C9HFNVs.wnb4SOWqhT, false);
		}
	}

	private void tbkpcqdVrT(object P_0, RoutedEventArgs P_1)
	{
		UCrOh343Aw("重新绑定当前表", () => Jk2boJKtvpW0C9HFNVs.kKW4bxDk3L( true), true);
	}

	private void xifpeRxOvW(object P_0, RoutedEventArgs P_1)
	{
		UCrOh343Aw("拆分表", Jk2boJKtvpW0C9HFNVs.XtH4lqGh7A, true);
	}

	private void HSdpyZZZ4x(object P_0, RoutedEventArgs P_1)
	{
		if (System.Windows.MessageBox.Show(this, "确定要解除当前 Word 表格的 Excel 绑定吗？\\n\\n只会清理 Word 文档中的绑定信息，不会删除 Excel 工作簿里的名称区域。", "解除绑定", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			UCrOh343Aw("解除当前表绑定", Jk2boJKtvpW0C9HFNVs.saY4G3LNKR, true);
		}
	}

	private void aWCpXc4wCW(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass28_0 CS_8_locals_12 = new _G_c__DisplayClass28_0();
		CS_8_locals_12.Vd4Vjs388ul = this;
		ebvOFufDA6(gridColumnMappings);
		if (dmsOy55xZ6(txtHeaderRows, chkSortEnabled, txtSortColumnIndex, cboSortDirection, chkSortPinOtherLast, VyXnT2klLm, out CS_8_locals_12.YCyVjLWQnEc, out CS_8_locals_12.hwxVjlUkQL8, out CS_8_locals_12.OwfVjNqotwf, out CS_8_locals_12.Gl3VjmsCxHn, out CS_8_locals_12.BnZVjocH3eE))
		{
			UCrOh343Aw("保存表格配置", () => Jk2boJKtvpW0C9HFNVs.v1r4oDajjF(CS_8_locals_12.YCyVjLWQnEc, CS_8_locals_12.Vd4Vjs388ul.chkSortEnabled.IsChecked == true, CS_8_locals_12.hwxVjlUkQL8, CS_8_locals_12.OwfVjNqotwf, CS_8_locals_12.Gl3VjmsCxHn, CS_8_locals_12.BnZVjocH3eE), false);
		}
	}

	private void afQpFDqfMW(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass29_0 CS_8_locals_15 = new _G_c__DisplayClass29_0();
		CS_8_locals_15.r3sVjOsNBP6 = this;
		ebvOFufDA6(gridAllColumnMappings);
		CS_8_locals_15.yCkVjCuDhM5 = SelectedBinding;
		if (CS_8_locals_15.yCkVjCuDhM5 == null)
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("请先在左侧选择一张表。", "IP_Assurance");
		}
		else if (dmsOy55xZ6(txtAllHeaderRows, chkAllSortEnabled, txtAllSortColumnIndex, cboAllSortDirection, chkAllSortPinOtherLast, PtTngkISNu, out CS_8_locals_15.Hp6VjpxIhZG, out CS_8_locals_15.bdBVjnriyke, out CS_8_locals_15.letVj7Vyv3E, out CS_8_locals_15.EAUVj5Fo2tZ, out CS_8_locals_15.VqiVjcFNj2A))
		{
			UCrOh343Aw("保存表格配置", () => Jk2boJKtvpW0C9HFNVs.bym4O8y0yd(CS_8_locals_15.yCkVjCuDhM5.BindingId, CS_8_locals_15.Hp6VjpxIhZG, CS_8_locals_15.r3sVjOsNBP6.chkAllSortEnabled.IsChecked == true, CS_8_locals_15.bdBVjnriyke, CS_8_locals_15.letVj7Vyv3E, CS_8_locals_15.EAUVj5Fo2tZ, CS_8_locals_15.VqiVjcFNj2A), true);
		}
	}

	private void QWrphxw7m1(object P_0, RoutedEventArgs P_1)
	{
		if (!r7mnIQ3VfX)
		{
			r5TOJtV7Bf(false, true);
		}
	}

	private void knGpaQGvb3(object P_0, RoutedEventArgs P_1)
	{
		if (!r7mnIQ3VfX && bNZnKlpICU != null && bNZnKlpICU.HasBinding)
		{
			wIcOa8l5mb("跳转Excel", Jk2boJKtvpW0C9HFNVs.VuQ4c2ipxq);
		}
	}

	private void ERtpqoZ4JG(object P_0, RoutedEventArgs P_1)
	{
		UCrOh343Aw("导出全部表并绑定", () => Jk2boJKtvpW0C9HFNVs.TcXEXakPZc(XGtOAmBcpX), true);
	}

	private void FJXpPgme4M(object P_0, RoutedEventArgs P_1)
	{
		UCrOh343Aw("刷新绑定信息", Jk2boJKtvpW0C9HFNVs.nvSKNublsd, true);
	}

	private void TT4pAnStVL(object P_0, RoutedEventArgs P_1)
	{
		int num = E3mn6NEThs.Count((Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve item) => string.Equals(item.Status, "没有需要清理的失效绑定。", StringComparison.OrdinalIgnoreCase));
		if (num == 0)
		{
			QmRO0PPQsB("没有需要清理的失效绑定。");
			un7uUxcCbw6Q36geOYj.psZcncX5UL("Excel同步", "将删除 {0} 个表格锚点丢失的绑定记录。\\n\\n不会删除 Excel 文件，也不会删除 Excel 名称区域。确定继续吗？");
		}
		else if (System.Windows.MessageBox.Show(this, string.Format("清理失效绑定", num), "清理失效绑定", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			UCrOh343Aw("插入Excel选区", Jk2boJKtvpW0C9HFNVs.AarKmV38oK, true);
		}
	}

	private void vR2pvrSv6A(object P_0, RoutedEventArgs P_1)
	{
		lmoOEgXMdh(SelectedBinding?.BindingId);
	}

	private void g5gpWglTKb(object P_0, RoutedEventArgs P_1)
	{
		_G_c__DisplayClass36_0 CS_8_locals_6 = new _G_c__DisplayClass36_0();
		Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE selectedDataSourceGroup = SelectedDataSourceGroup;
		if (selectedDataSourceGroup == null)
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("请先选择一个 Excel 数据源。", "IP_Assurance");
			return;
		}
		string fileName;
		using (OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = "选择新的 Excel 数据源",
			Filter = "Excel 工作簿 (*.xlsx;*.xlsm)|*.xlsx;*.xlsm",
			Multiselect = false
		})
		{
			if (!string.IsNullOrWhiteSpace(selectedDataSourceGroup.ResolvedExcelPath) && File.Exists(selectedDataSourceGroup.ResolvedExcelPath))
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(selectedDataSourceGroup.ResolvedExcelPath);
			}
			if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
			{
				return;
			}
			fileName = openFileDialog.FileName;
		}
		if (Jk2boJKtvpW0C9HFNVs.aDXEHKSHuA(fileName) && System.Windows.MessageBox.Show(this, "新 Excel 文件当前正在打开。\\n\\n更换数据源会读取该文件已经保存到磁盘的内容；如果 Excel 中有未保存修改，请先保存后继续。\\n\\n是否继续？", "更换数据源", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
		{
			return;
		}
		if (!Jk2boJKtvpW0C9HFNVs.G4JEIoJeN1(selectedDataSourceGroup, fileName, out CS_8_locals_6.g8vVjyuYugM, out var text))
		{
			un7uUxcCbw6Q36geOYj.CsKcO7u6di(new Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs
			{
				Success = false,
				RequiresUserAction = true,
				Message = (string.IsNullOrWhiteSpace(text) ? "更换数据源预检失败。" : text)
			}, "Excel同步");
		}
		else if (CS_8_locals_6.g8vVjyuYugM.MatchedItems == null || CS_8_locals_6.g8vVjyuYugM.MatchedItems.Count == 0)
		{
			System.Windows.MessageBox.Show(this, LHnOCV7osD(CS_8_locals_6.g8vVjyuYugM, false), "更换数据源", MessageBoxButton.OK, MessageBoxImage.Exclamation);
		}
		else if (System.Windows.MessageBox.Show(this, LHnOCV7osD(CS_8_locals_6.g8vVjyuYugM, true), "确认更换数据源", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			UCrOh343Aw("更换数据源", delegate
			{
				Jk2boJKtvpW0C9HFNVs.BgnmcfV8ArSDWAKRwk0q bgnmcfV8ArSDWAKRwk0q = Jk2boJKtvpW0C9HFNVs.ebNEiWQuCH(CS_8_locals_6.g8vVjyuYugM);
				return new Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs
				{
					Success = bgnmcfV8ArSDWAKRwk0q.Success,
					RequiresUserAction = !bgnmcfV8ArSDWAKRwk0q.Success,
					Bound = bgnmcfV8ArSDWAKRwk0q.UpdatedCount,
					Failed = bgnmcfV8ArSDWAKRwk0q.SkippedCount,
					Message = bgnmcfV8ArSDWAKRwk0q.Message
				};
			}, true);
		}
	}

	private void tTnp0BpuM9(object P_0, RoutedEventArgs P_1)
	{
		string text = SelectedDataSourceGroup?.ResolvedExcelPath;
		if (string.IsNullOrWhiteSpace(text))
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("当前数据源没有可打开的路径。", "IP_Assurance");
			return;
		}
		try
		{
			if (File.Exists(text))
			{
				Process.Start(new ProcessStartInfo("explorer.exe", "/select,\"" + text + "\"")
				{
					UseShellExecute = true
				});
				return;
			}
			string directoryName = Path.GetDirectoryName(text);
			if (!string.IsNullOrWhiteSpace(directoryName) && Directory.Exists(directoryName))
			{
				Process.Start(new ProcessStartInfo("explorer.exe", "\"" + directoryName + "\"")
				{
					UseShellExecute = true
				});
			}
			else
			{
				F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("未找到 Excel 文件或所在文件夹。", "IP_Assurance");
			}
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[ExcelSync] Open data source folder failed", ex);
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("打开文件位置失败。", "IP_Assurance");
		}
	}

	private void X2YpkbCXJI(object P_0, RoutedEventArgs P_1)
	{
		Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve selectedDataSourceBinding = SelectedDataSourceBinding;
		if (selectedDataSourceBinding == null)
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("请先在关联表中选择一张表。", "IP_Assurance");
			return;
		}
		tabAll.IsSelected = true;
		WR0uULV4PciwXYvPdaNd wR0uULV4PciwXYvPdaNd = OQ7OGh5thu(nf4nuLGTDv, selectedDataSourceBinding.BindingId);
		rAUOlemBfZ(wR0uULV4PciwXYvPdaNd);
		if (wR0uULV4PciwXYvPdaNd != null && NulOgKoF3O())
		{
			QmRO0PPQsB("已定位到 Word 表格。");
		}
	}

	private void OWypxBxIqE(object P_0, RoutedEventArgs P_1)
	{
		Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve selectedBinding = SelectedBinding;
		if (selectedBinding != null && selectedBinding.CanJumpExcel)
		{
			R8KOqA1Zsf(selectedBinding);
		}
	}

	private void vsWpd2MBoZ(object P_0, RoutedEventArgs P_1)
	{
		if (SelectedBinding == null)
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("请先选择一个绑定关系。", "IP_Assurance");
			return;
		}
		UCrOh343Aw("数据同步", () => (!VhjO8cZh01(out var text, out var requiresUserAction)) ? new Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs
		{
			Success = false,
			RequiresUserAction = requiresUserAction,
			Message = (string.IsNullOrWhiteSpace(text) ? "重新绑定当前表" : text)
		} : Jk2boJKtvpW0C9HFNVs.XVJ45smyDw(XGtOAmBcpX), false);
	}

	private void GCCpzSGYn1(object P_0, RoutedEventArgs P_1)
	{
		UCrOh343Aw("数据同步", () => Jk2boJKtvpW0C9HFNVs.zxS4eKlv5S(XGtOAmBcpX), false);
	}

	private void EjMORiBgG9(object P_0, RoutedEventArgs P_1)
	{
		string text = Xwl2EJXZ1waT9LlFYjb.hlWXMtJ6TA();
		txtOptionsStatus.Text = text;
		QmRO0PPQsB(text);
		odEOteY3dg();
		if (Xwl2EJXZ1waT9LlFYjb.IsLoaded || text.StartsWith("已卸载", StringComparison.OrdinalIgnoreCase))
		{
			un7uUxcCbw6Q36geOYj.psZcncX5UL(text, "Excel同步");
		}
		else
		{
			un7uUxcCbw6Q36geOYj.kX7c742XgE(text, "Excel同步");
		}
	}

	private void vNHOVaYlKI(object P_0, RoutedEventArgs P_1)
	{
		MZEniWtslN = true;
		QmRO0PPQsB("正在取消，请等待当前表格处理完成...");
	}

	private void VX7OBtsx3k(object P_0, RoutedEventArgs P_1)
	{
		if (!OMKnQSfJqs)
		{
			bool valueOrDefault = chkSyncHeaders.IsChecked == true;
			Jk2boJKtvpW0C9HFNVs.VIP491iKru(valueOrDefault);
			txtOptionsStatus.Text = (valueOrDefault ? "已关闭同步表头内容；后续同步只写入数据区。" : "已开启同步表头内容。");
		}
	}

	private void C96O97btI4(object P_0, RoutedEventArgs P_1)
	{
		R2SOLEqQR7();
	}

	private void fIpO6e9sPM(object P_0, RoutedEventArgs P_1)
	{
		jlKObjnrQv();
		anROS5dIum();
	}

	private void Av2OunZW4w(object P_0, RoutedPropertyChangedEventArgs<object> P_1)
	{
		WR0uULV4PciwXYvPdaNd wR0uULV4PciwXYvPdaNd = P_1.NewValue as WR0uULV4PciwXYvPdaNd;
		e9anEqjZMJ = ((wR0uULV4PciwXYvPdaNd != null && wR0uULV4PciwXYvPdaNd.IsTable) ? wR0uULV4PciwXYvPdaNd : null);
		sJTOjaskhb();
		anROS5dIum();
		if (!r7mnIQ3VfX && !k32n1upDwO && tabAll.IsSelected && SelectedBinding != null && NulOgKoF3O())
		{
			QmRO0PPQsB("已定位到 Word 表格。");
		}
	}

	private void bB1OD28UTM(object P_0, SelectionChangedEventArgs P_1)
	{
		wl5OM5OnNS();
		EohOwGuhvN();
	}

	private void aKAOT11OGe(object P_0, SelectionChangedEventArgs P_1)
	{
		EohOwGuhvN();
	}

	private bool NulOgKoF3O()
	{
		string text;
		bool flag;
		return VhjO8cZh01(out text, out flag);
	}

	private bool VhjO8cZh01(out string P_0, out bool P_1)
	{
		bool num = Jk2boJKtvpW0C9HFNVs.pNqZ2V22ob(SelectedBinding, out P_0, out P_1);
		if (!num && !string.IsNullOrWhiteSpace(P_0))
		{
			QmRO0PPQsB(P_0);
		}
		sJTOjaskhb();
		anROS5dIum();
		return num;
	}

	private void fFuOIGKZTj(object P_0, SelectionChangedEventArgs P_1)
	{
		if (P_1.Source == tabSync && (tabAll.IsSelected || tabDataSources.IsSelected) && !UMlnrm6j8x && !k32n1upDwO)
		{
			lmoOEgXMdh(bNZnKlpICU?.BindingId);
		}
	}

	private void jpROigfFHQ()
	{
		OMKnQSfJqs = true;
		try
		{
			chkSyncHeaders.IsChecked = Jk2boJKtvpW0C9HFNVs.Bek4BpHLYy();
		}
		finally
		{
			OMKnQSfJqs = false;
		}
	}

	private void mxOOHYibqA()
	{
		if (ubhnH7KepY)
		{
			return;
		}
		ClanUwKOlF = eSfxffslhXbaGAjFNv1.WordApp;
		if (ClanUwKOlF == null)
		{
			return;
		}
		try
		{
			new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").AddEventHandler(ClanUwKOlF, new ApplicationEvents4_WindowSelectionChangeEventHandler(fWpO1ohXLE));
			ubhnH7KepY = true;
		}
		catch
		{
		}
	}

	private void YQpOQgxdib()
	{
		if (ubhnH7KepY && ClanUwKOlF != null)
		{
			try
			{
				new ComAwareEventInfo(typeof(ApplicationEvents4_Event), "WindowSelectionChange").RemoveEventHandler(ClanUwKOlF, new ApplicationEvents4_WindowSelectionChangeEventHandler(fWpO1ohXLE));
			}
			catch
			{
			}
			ubhnH7KepY = false;
			ClanUwKOlF = null;
		}
	}

	private void fWpO1ohXLE(Selection P_0)
	{
		if (r7mnIQ3VfX || !base.IsVisible)
		{
			return;
		}
		try
		{
			base.Dispatcher.BeginInvoke((Action)delegate
			{
				if (tabCurrent.IsSelected)
				{
					gtPO3hNFRn();
				}
				s7un8F22Xj.Stop();
				s7un8F22Xj.Start();
			}, DispatcherPriority.Background);
		}
		catch
		{
		}
	}

	private void yeyOrHb3JZ(object P_0, EventArgs P_1)
	{
		s7un8F22Xj.Stop();
		if (!r7mnIQ3VfX && base.IsVisible)
		{
			r5TOJtV7Bf( false, tabCurrent.IsSelected);
		}
		else
		{
			KwHOUY7w6K();
		}
	}

	private void r5TOJtV7Bf(bool P_0, bool P_1)
	{
		_G_c__DisplayClass58_0 CS_8_locals_13 = new _G_c__DisplayClass58_0();
		CS_8_locals_13.L4IVjFYA0VL = this;
		CS_8_locals_13.VR9VjhT7fJF = P_0;
		CS_8_locals_13.VdaVjasONDp = P_1;
		if (r7mnIQ3VfX || !base.IsVisible)
		{
			return;
		}
		CS_8_locals_13.exnVjqnH0MM = W6Gn3PIlip;
		if (CS_8_locals_13.VdaVjasONDp)
		{
			CS_8_locals_13.exnVjqnH0MM = ++W6Gn3PIlip;
			gtPO3hNFRn();
		}
		base.Dispatcher.BeginInvoke((Action)delegate
		{
			try
			{
				if (!CS_8_locals_13.L4IVjFYA0VL.r7mnIQ3VfX && CS_8_locals_13.L4IVjFYA0VL.IsVisible)
				{
					CS_8_locals_13.L4IVjFYA0VL.XvJOKeRLxt(CS_8_locals_13.VR9VjhT7fJF);
				}
			}
			finally
			{
				if (CS_8_locals_13.VdaVjasONDp)
				{
					CS_8_locals_13.L4IVjFYA0VL.KwHOUY7w6K(CS_8_locals_13.exnVjqnH0MM);
				}
			}
		}, DispatcherPriority.Background);
	}

	private void gtPO3hNFRn()
	{
		try
		{
			barCurrentLoading.Visibility = Visibility.Visible;
			txtCurrentStatus.Text = "正在刷新当前表...";
		}
		catch
		{
		}
	}

	private void KwHOUY7w6K(int? P_0 = null)
	{
		try
		{
			if (!P_0.HasValue || P_0.Value == W6Gn3PIlip)
			{
				barCurrentLoading.Visibility = Visibility.Collapsed;
			}
		}
		catch
		{
		}
	}

	private void XvJOKeRLxt(bool P_0)
	{
		bNZnKlpICU = Jk2boJKtvpW0C9HFNVs.inT4f2XO4S(P_0);
		txtCurrentCardTitle.Text = ddYOpUEEfn(bNZnKlpICU);
		txtWordStatus.Text = zePOO1f9yx(bNZnKlpICU);
		txtWordTable.Text = bNZnKlpICU.WordTableLabel ?? string.Empty;
		txtBindingId.Text = (bNZnKlpICU.HasBinding ? bNZnKlpICU.BindingId : "未绑定");
		txtHeaderSetting.Text = VN9OnoyF9f(bNZnKlpICU);
		txtHeaderRows.Text = (bNZnKlpICU.HeaderRowCount.HasValue ? bNZnKlpICU.HeaderRowCount.Value.ToString() : string.Empty);
		chkSortEnabled.IsChecked = bNZnKlpICU.SortEnabled;
		txtSortColumnIndex.Text = (bNZnKlpICU.SortColumnIndex ?? 2).ToString();
		cboSortDirection.SelectedIndex = ((bNZnKlpICU.SortDescending == false) ? 1 : 0);
		chkSortPinOtherLast.IsChecked = bNZnKlpICU.SortPinOtherLast != false;
		yTAOcfuoN8(VyXnT2klLm, bNZnKlpICU.ColumnMappings, bNZnKlpICU.WordColumnCount);
		runBindingSourceSummary.Text = nWIO77Lyj2(bNZnKlpICU);
		txtExcelStatus.Text = bNZnKlpICU.ExcelStatus ?? string.Empty;
		txtExcelWorkbook.Text = bNZnKlpICU.ExcelWorkbook ?? string.Empty;
		txtExcelSheet.Text = bNZnKlpICU.ExcelSheet ?? string.Empty;
		txtExcelAddress.Text = bNZnKlpICU.ExcelAddress ?? string.Empty;
		txtExcelSize.Text = bNZnKlpICU.ExcelSize ?? string.Empty;
		txtExcelSelectionSummary.Text = LFhO5FvQ1M(bNZnKlpICU);
		bool flag = !bNZnKlpICU.HasBinding || bNZnKlpICU.HasExcelSelection;
		lblExcelSelectionSummary.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		txtExcelSelectionSummary.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		txtBoundPath.Text = ((!string.IsNullOrWhiteSpace(bNZnKlpICU.BoundFullPath)) ? bNZnKlpICU.BoundFullPath : (bNZnKlpICU.BoundWorkbook ?? string.Empty));
		txtBoundSheet.Text = bNZnKlpICU.BoundSheet ?? string.Empty;
		txtExcelName.Text = bNZnKlpICU.BoundExcelName ?? string.Empty;
		txtCurrentStatus.Text = bNZnKlpICU.Message ?? string.Empty;
		jlKObjnrQv();
	}

	private void lmoOEgXMdh(string P_0)
	{
		_G_c__DisplayClass62_0 CS_8_locals_4 = new _G_c__DisplayClass62_0();
		CS_8_locals_4.cexVjAsRxWj = this;
		if (!r7mnIQ3VfX && !k32n1upDwO)
		{
			CS_8_locals_4.AUGVjv0lCH2 = P_0 ?? SelectedBinding?.BindingId;
			UMlnrm6j8x = true;
			k32n1upDwO = true;
			barAllLoading.Visibility = Visibility.Visible;
			treeBindings.IsEnabled = false;
			txtAllSummary.Text = "正在读取当前文档绑定...";
			anROS5dIum();
			base.Dispatcher.BeginInvoke((Action)delegate
			{
				CS_8_locals_4.cexVjAsRxWj.UJCO2ZWoW0(CS_8_locals_4.AUGVjv0lCH2);
			}, DispatcherPriority.Background);
		}
	}

	private void UJCO2ZWoW0(string P_0)
	{
		try
		{
			E3mn6NEThs.Clear();
			foreach (Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve item in Jk2boJKtvpW0C9HFNVs.cZEKsyo7XD())
			{
				E3mn6NEThs.Add(item);
			}
			M2NOsQbWyU();
			cMdOYLAOjc();
			WR0uULV4PciwXYvPdaNd wR0uULV4PciwXYvPdaNd = ((!string.IsNullOrWhiteSpace(P_0)) ? OQ7OGh5thu(nf4nuLGTDv, P_0) : null);
			rAUOlemBfZ(wR0uULV4PciwXYvPdaNd ?? wDeOoeMhoh(nf4nuLGTDv));
			if (gridDataSources.SelectedItem == null && B9nnDK9dBG.Count > 0)
			{
				gridDataSources.SelectedIndex = 0;
			}
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[ExcelSync] Load binding list failed", ex);
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8("读取绑定列表失败，请保存 Word 文档后重新打开 Excel 同步窗口。", "IP_Assurance");
		}
		finally
		{
			treeBindings.IsEnabled = true;
			barAllLoading.Visibility = Visibility.Collapsed;
			k32n1upDwO = false;
			NnEO4BS9fi();
			sJTOjaskhb();
			s31OfhyUie();
			wl5OM5OnNS();
			anROS5dIum();
			EohOwGuhvN();
		}
	}

	private void NnEO4BS9fi()
	{
		int count = E3mn6NEThs.Count;
		int num = E3mn6NEThs.Count((Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve item) => string.Equals(item.Status, "共 {0} 个绑定，正常 {1} 个，异常 {2} 个。", StringComparison.OrdinalIgnoreCase));
		txtAllSummary.Text = ((count == 0) ? "当前文档未发现 Excel 绑定关系。" : string.Format("当前绑定还没有 Word 标题层级缓存；点击“刷新绑定信息”后会按 Word 标题树归类。", count, num, count - num));
		if (count > 0 && !E3mn6NEThs.Any((Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve item) => item.HeadingPath != null && item.HeadingPath.Count > 0))
		{
			txtAllStatus.Text = "选择左侧表格会定位 Word 表格；可在右侧 Excel 路径处跳转源区域。";
		}
		else if (string.IsNullOrWhiteSpace(txtAllStatus.Text))
		{
			txtAllStatus.Text = ((count == 0) ? string.Empty : "拆分表");
		}
	}

	private void sJTOjaskhb()
	{
		Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve selectedBinding = SelectedBinding;
		txtAllDetailEmpty.Visibility = ((selectedBinding != null) ? Visibility.Collapsed : Visibility.Visible);
		panelAllDetailContent.Visibility = ((selectedBinding == null) ? Visibility.Collapsed : Visibility.Visible);
		if (selectedBinding != null)
		{
			txtAllDetailTitle.Text = selectedBinding.DisplayTitle ?? selectedBinding.WordTableLabel ?? string.Empty;
			txtAllDetailHeading.Text = (string.IsNullOrWhiteSpace(selectedBinding.HeadingPathText) ? "未归类表格" : selectedBinding.HeadingPathText);
			txtAllDetailStatus.Text = selectedBinding.Status ?? string.Empty;
			txtAllDetailWordTable.Text = selectedBinding.WordTableLabel ?? string.Empty;
			txtAllDetailWorkbook.Text = selectedBinding.WorkbookName ?? string.Empty;
			txtAllDetailSheet.Text = selectedBinding.SheetName ?? string.Empty;
			txtAllDetailName.Text = selectedBinding.ExcelName ?? string.Empty;
			runAllDetailPath.Text = selectedBinding.ResolvedExcelPath ?? selectedBinding.ExcelFullPath ?? string.Empty;
			txtAllHeaderRows.Text = (selectedBinding.HeaderRowCount.HasValue ? selectedBinding.HeaderRowCount.Value.ToString() : string.Empty);
			chkAllSortEnabled.IsChecked = selectedBinding.SortEnabled;
			txtAllSortColumnIndex.Text = (selectedBinding.SortColumnIndex ?? 2).ToString();
			cboAllSortDirection.SelectedIndex = ((selectedBinding.SortDescending == false) ? 1 : 0);
			chkAllSortPinOtherLast.IsChecked = selectedBinding.SortPinOtherLast != false;
			yTAOcfuoN8(PtTngkISNu, selectedBinding.ColumnMappings, selectedBinding.WordColumnCount);
			txtAllDetailBindingId.Text = "绑定ID：" + (selectedBinding.BindingId ?? string.Empty);
			txtAllDetailBookmark.Text = "Word书签：" + (selectedBinding.WordBookmark ?? string.Empty);
		}
		else
		{
			txtAllDetailTitle.Text = string.Empty;
			txtAllDetailHeading.Text = string.Empty;
			txtAllDetailStatus.Text = string.Empty;
			txtAllDetailWordTable.Text = string.Empty;
			txtAllDetailWorkbook.Text = string.Empty;
			txtAllDetailSheet.Text = string.Empty;
			txtAllDetailName.Text = string.Empty;
			runAllDetailPath.Text = string.Empty;
			txtAllHeaderRows.Text = string.Empty;
			chkAllSortEnabled.IsChecked = false;
			txtAllSortColumnIndex.Text = "2";
			cboAllSortDirection.SelectedIndex = 0;
			chkAllSortPinOtherLast.IsChecked = true;
			PtTngkISNu.Clear();
			txtAllDetailBindingId.Text = string.Empty;
			txtAllDetailBookmark.Text = string.Empty;
		}
		string text = string.Empty;
		if (selectedBinding != null && !string.IsNullOrWhiteSpace(selectedBinding.ErrorMessage))
		{
			text = selectedBinding.ErrorMessage;
		}
		else if (selectedBinding != null && !string.Equals(selectedBinding.Status, "正常", StringComparison.OrdinalIgnoreCase))
		{
			text = selectedBinding.Status ?? string.Empty;
		}
		bool flag = !string.IsNullOrWhiteSpace(text);
		borderAllError.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
		txtAllError.Text = (flag ? text : string.Empty);
	}

	private void cMdOYLAOjc()
	{
		_G_c__DisplayClass66_0 CS_8_locals_3 = new _G_c__DisplayClass66_0();
		CS_8_locals_3.vwOVj0875AY = SelectedDataSourceGroup?.ResolvedExcelPath;
		B9nnDK9dBG.Clear();
		foreach (Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE item in YEhOZcKFuM())
		{
			B9nnDK9dBG.Add(item);
		}
		Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE iqV0YlV8NdDqM9efX4pE = null;
		if (!string.IsNullOrWhiteSpace(CS_8_locals_3.vwOVj0875AY))
		{
			iqV0YlV8NdDqM9efX4pE = B9nnDK9dBG.FirstOrDefault((Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE group) => string.Equals(group.ResolvedExcelPath, CS_8_locals_3.vwOVj0875AY, StringComparison.OrdinalIgnoreCase));
		}
		if (iqV0YlV8NdDqM9efX4pE != null)
		{
			gridDataSources.SelectedItem = iqV0YlV8NdDqM9efX4pE;
		}
		else if (B9nnDK9dBG.Count > 0)
		{
			gridDataSources.SelectedIndex = 0;
		}
	}

	private IList<Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE> YEhOZcKFuM()
	{
		return Jk2boJKtvpW0C9HFNVs.BCbE8b10BK(E3mn6NEThs);
	}

	private void s31OfhyUie()
	{
		int count = B9nnDK9dBG.Count;
		int num = B9nnDK9dBG.Sum((Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE group) => group.BindingCount);
		int num2 = B9nnDK9dBG.Sum((Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE group) => group.MissingPathCount);
		txtDataSourceSummary.Text = ((count == 0) ? "共 {0} 个数据源，{1} 个绑定，路径异常 {2} 个。" : string.Format("当前文档未发现 Excel 数据源。", count, num, num2));
		if (string.IsNullOrWhiteSpace(txtDataSourceStatusBar.Text))
		{
			txtDataSourceStatusBar.Text = ((count == 0) ? string.Empty : "选择一个 Excel 数据源后，可以查看关联表或更换来源。");
		}
	}

	private void wl5OM5OnNS()
	{
		Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE selectedDataSourceGroup = SelectedDataSourceGroup;
		txtDataSourceEmpty.Visibility = ((selectedDataSourceGroup != null) ? Visibility.Collapsed : Visibility.Visible);
		panelDataSourceDetailContent.Visibility = ((selectedDataSourceGroup == null) ? Visibility.Collapsed : Visibility.Visible);
		if (selectedDataSourceGroup != null)
		{
			txtDataSourceTitle.Text = (string.IsNullOrWhiteSpace(selectedDataSourceGroup.WorkbookName) ? "未命名数据源" : selectedDataSourceGroup.WorkbookName);
			txtDataSourceStatus.Text = selectedDataSourceGroup.Status ?? string.Empty;
			txtDataSourcePath.Text = selectedDataSourceGroup.ResolvedExcelPath ?? string.Empty;
			txtDataSourceBindingCount.Text = selectedDataSourceGroup.BindingCount.ToString();
			txtDataSourceNormalCount.Text = selectedDataSourceGroup.NormalCount.ToString();
			txtDataSourceMissingPathCount.Text = selectedDataSourceGroup.MissingPathCount.ToString();
			listDataSourceBindings.ItemsSource = selectedDataSourceGroup.Bindings ?? new List<Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve>();
			if (listDataSourceBindings.SelectedItem == null && listDataSourceBindings.Items.Count > 0)
			{
				listDataSourceBindings.SelectedIndex = 0;
			}
		}
		else
		{
			txtDataSourceTitle.Text = string.Empty;
			txtDataSourceStatus.Text = string.Empty;
			txtDataSourcePath.Text = string.Empty;
			txtDataSourceBindingCount.Text = string.Empty;
			txtDataSourceNormalCount.Text = string.Empty;
			txtDataSourceMissingPathCount.Text = string.Empty;
			listDataSourceBindings.ItemsSource = null;
		}
	}

	private void jlKObjnrQv()
	{
		bool flag = bNZnKlpICU != null && bNZnKlpICU.HasWordTable;
		bool flag2 = bNZnKlpICU != null && bNZnKlpICU.HasBinding;
		bool flag3 = bNZnKlpICU != null && bNZnKlpICU.HasExcelSelection;
		bool isEnabled = !r7mnIQ3VfX && flag && flag2 && chkSortEnabled.IsChecked == true;
		if (flag2)
		{
			btnPrimaryCurrent.Content = "同步当前表";
		}
		else if (flag)
		{
			btnPrimaryCurrent.Content = "绑定当前表";
		}
		else
		{
			btnPrimaryCurrent.Content = "插入Excel选区";
		}
		btnPrimaryCurrent.IsEnabled = !r7mnIQ3VfX && (flag2 || (flag && flag3) || (!flag && flag3));
		btnSplitCurrentTable.IsEnabled = !r7mnIQ3VfX && flag && flag2;
		btnRebind.IsEnabled = !r7mnIQ3VfX && flag && flag2 && flag3;
		btnUnbind.IsEnabled = !r7mnIQ3VfX && flag && flag2;
		btnSaveHeaderSetting.IsEnabled = !r7mnIQ3VfX && flag && flag2;
		btnRefreshExcelSelection.IsEnabled = !r7mnIQ3VfX;
		linkCurrentBindingSource.IsEnabled = !r7mnIQ3VfX && flag2;
		txtHeaderRows.IsEnabled = !r7mnIQ3VfX && flag && flag2;
		gridColumnMappings.IsEnabled = !r7mnIQ3VfX && flag && flag2;
		gridColumnMappings.IsReadOnly = !(!r7mnIQ3VfX && flag && flag2);
		chkSortEnabled.IsEnabled = !r7mnIQ3VfX && flag && flag2;
		txtSortColumnIndex.IsEnabled = isEnabled;
		cboSortDirection.IsEnabled = isEnabled;
		chkSortPinOtherLast.IsEnabled = isEnabled;
	}

	private void anROS5dIum()
	{
		Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve selectedBinding = SelectedBinding;
		bool flag = selectedBinding != null;
		bool flag2 = !r7mnIQ3VfX && !k32n1upDwO && !kvinJXJO8H;
		bool flag3 = E3mn6NEThs.Any((Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve item) => string.Equals(item.Status, "确定要解除当前 Word 表格的 Excel 绑定吗？\\n\\n只会清理 Word 文档中的绑定信息，不会删除 Excel 工作簿里的名称区域。", StringComparison.OrdinalIgnoreCase));
		bool isEnabled = flag2 && flag && selectedBinding.CanSync && chkAllSortEnabled.IsChecked == true;
		btnRefreshAll.IsEnabled = flag2;
		linkAllDetailPath.IsEnabled = flag2 && flag && selectedBinding.CanJumpExcel;
		btnSyncSelected.IsEnabled = flag2 && flag && selectedBinding.CanSync;
		btnSyncAll.IsEnabled = flag2;
		btnExportAll.IsEnabled = flag2;
		btnCleanInvalidBindings.IsEnabled = flag2 && flag3;
		btnSaveAllHeaderSetting.IsEnabled = flag2 && flag && selectedBinding.CanSync;
		txtAllHeaderRows.IsEnabled = flag2 && flag && selectedBinding.CanSync;
		gridAllColumnMappings.IsEnabled = flag2 && flag && selectedBinding.CanSync;
		gridAllColumnMappings.IsReadOnly = !(flag2 && flag) || !selectedBinding.CanSync;
		chkAllSortEnabled.IsEnabled = flag2 && flag && selectedBinding.CanSync;
		txtAllSortColumnIndex.IsEnabled = isEnabled;
		cboAllSortDirection.IsEnabled = isEnabled;
		chkAllSortPinOtherLast.IsEnabled = isEnabled;
	}

	private void EohOwGuhvN()
	{
		Jk2boJKtvpW0C9HFNVs.IqV0YlV8NdDqM9efX4pE selectedDataSourceGroup = SelectedDataSourceGroup;
		bool flag = selectedDataSourceGroup != null;
		bool flag2 = !r7mnIQ3VfX && !k32n1upDwO && !kvinJXJO8H;
		bool flag3 = flag && !string.IsNullOrWhiteSpace(selectedDataSourceGroup.ResolvedExcelPath);
		btnRefreshDataSources.IsEnabled = flag2;
		gridDataSources.IsEnabled = flag2;
		listDataSourceBindings.IsEnabled = flag2 && flag;
		btnReplaceDataSource.IsEnabled = flag2 && flag && selectedDataSourceGroup.BindingCount > 0;
		btnOpenDataSourceFolder.IsEnabled = flag2 && flag3;
		btnJumpDataSourceBinding.IsEnabled = flag2 && SelectedDataSourceBinding != null;
	}

	private void odEOteY3dg()
	{
		bool isLoaded = Xwl2EJXZ1waT9LlFYjb.IsLoaded;
		btnToggleContextMenu.Content = (isLoaded ? "加载右键菜单" : "卸载右键菜单");
		txtContextMenuStatus.Text = (isLoaded ? "状态：未加载。" : "状态：已加载。");
	}

	private void R2SOLEqQR7()
	{
		Visibility visibility = ((chkShowAdvancedColumns.IsChecked != true) ? Visibility.Collapsed : Visibility.Visible);
		panelAllAdvancedDetails.Visibility = visibility;
	}

	private void M2NOsQbWyU()
	{
		nf4nuLGTDv.Clear();
		WR0uULV4PciwXYvPdaNd wR0uULV4PciwXYvPdaNd = null;
		foreach (Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve item in E3mn6NEThs.OrderBy((Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve binding) => (binding.WordTableIndex > 0) ? binding.WordTableIndex : int.MaxValue))
		{
			IList<Jk2boJKtvpW0C9HFNVs.zjEQMmV8xiap53qf2leG> list = item.HeadingPath ?? new List<Jk2boJKtvpW0C9HFNVs.zjEQMmV8xiap53qf2leG>();
			ObservableCollection<WR0uULV4PciwXYvPdaNd> children = nf4nuLGTDv;
			WR0uULV4PciwXYvPdaNd parent = null;
			if (list.Count == 0)
			{
				if (wR0uULV4PciwXYvPdaNd == null)
				{
					wR0uULV4PciwXYvPdaNd = new WR0uULV4PciwXYvPdaNd
					{
						Text = "未归类表格",
						IsHeading = true,
						IsExpanded = true
					};
					nf4nuLGTDv.Add(wR0uULV4PciwXYvPdaNd);
				}
				parent = wR0uULV4PciwXYvPdaNd;
				children = wR0uULV4PciwXYvPdaNd.Children;
			}
			else
			{
				using IEnumerator<Jk2boJKtvpW0C9HFNVs.zjEQMmV8xiap53qf2leG> enumerator2 = list.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_G_c__DisplayClass75_0 CS_8_locals_9 = new _G_c__DisplayClass75_0();
					CS_8_locals_9.No1VjxXO7vN = enumerator2.Current;
					CS_8_locals_9.ksKVjdTM071 = (string.IsNullOrWhiteSpace(CS_8_locals_9.No1VjxXO7vN.Text) ? "未命名标题" : CS_8_locals_9.No1VjxXO7vN.Text);
					WR0uULV4PciwXYvPdaNd wR0uULV4PciwXYvPdaNd2 = children.FirstOrDefault((WR0uULV4PciwXYvPdaNd existing) => existing.IsHeading && existing.Level == CS_8_locals_9.No1VjxXO7vN.Level && string.Equals(existing.Text, CS_8_locals_9.ksKVjdTM071, StringComparison.Ordinal));
					if (wR0uULV4PciwXYvPdaNd2 == null)
					{
						wR0uULV4PciwXYvPdaNd2 = new WR0uULV4PciwXYvPdaNd
						{
							Text = CS_8_locals_9.ksKVjdTM071,
							Level = CS_8_locals_9.No1VjxXO7vN.Level,
							IsHeading = true,
							IsExpanded = (CS_8_locals_9.No1VjxXO7vN.Level <= 3),
							Parent = parent
						};
						children.Add(wR0uULV4PciwXYvPdaNd2);
					}
					parent = wR0uULV4PciwXYvPdaNd2;
					children = wR0uULV4PciwXYvPdaNd2.Children;
				}
			}
			bool flag = !string.Equals(item.Status, "正常", StringComparison.OrdinalIgnoreCase);
			children.Add(new WR0uULV4PciwXYvPdaNd
			{
				Text = (item.DisplayTitle ?? item.WordTableLabel ?? item.BindingId),
				StatusBadge = (flag ? item.Status : string.Empty),
				IsTable = true,
				IsError = flag,
				Binding = item,
				Parent = parent
			});
		}
	}

	private void rAUOlemBfZ(WR0uULV4PciwXYvPdaNd P_0)
	{
		XfbONW5dhI(nf4nuLGTDv);
		e9anEqjZMJ = ((P_0 != null && P_0.IsTable) ? P_0 : null);
		if (P_0 != null)
		{
			mSbOmO30nE(P_0);
			P_0.IsSelected = true;
		}
		sJTOjaskhb();
		anROS5dIum();
	}

	private static void XfbONW5dhI(IEnumerable<WR0uULV4PciwXYvPdaNd> P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		foreach (WR0uULV4PciwXYvPdaNd item in P_0)
		{
			item.IsSelected = false;
			XfbONW5dhI(item.Children);
		}
	}

	private static void mSbOmO30nE(WR0uULV4PciwXYvPdaNd P_0)
	{
		for (WR0uULV4PciwXYvPdaNd wR0uULV4PciwXYvPdaNd = P_0?.Parent; wR0uULV4PciwXYvPdaNd != null; wR0uULV4PciwXYvPdaNd = wR0uULV4PciwXYvPdaNd.Parent)
		{
			wR0uULV4PciwXYvPdaNd.IsExpanded = true;
		}
	}

	private static WR0uULV4PciwXYvPdaNd wDeOoeMhoh(IEnumerable<WR0uULV4PciwXYvPdaNd> P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		foreach (WR0uULV4PciwXYvPdaNd item in P_0)
		{
			if (item.IsTable)
			{
				return item;
			}
			WR0uULV4PciwXYvPdaNd wR0uULV4PciwXYvPdaNd = wDeOoeMhoh(item.Children);
			if (wR0uULV4PciwXYvPdaNd != null)
			{
				return wR0uULV4PciwXYvPdaNd;
			}
		}
		return null;
	}

	private static WR0uULV4PciwXYvPdaNd OQ7OGh5thu(IEnumerable<WR0uULV4PciwXYvPdaNd> P_0, string P_1)
	{
		if (P_0 == null || string.IsNullOrWhiteSpace(P_1))
		{
			return null;
		}
		foreach (WR0uULV4PciwXYvPdaNd item in P_0)
		{
			if (item.IsTable && item.Binding != null && string.Equals(item.Binding.BindingId, P_1, StringComparison.OrdinalIgnoreCase))
			{
				return item;
			}
			WR0uULV4PciwXYvPdaNd wR0uULV4PciwXYvPdaNd = OQ7OGh5thu(item.Children, P_1);
			if (wR0uULV4PciwXYvPdaNd != null)
			{
				return wR0uULV4PciwXYvPdaNd;
			}
		}
		return null;
	}

	private static string LHnOCV7osD(Jk2boJKtvpW0C9HFNVs.CkyBTaV87qVM3TwBrVFZ P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return "未生成更换数据源预检结果。";
		}
		int num = P_0.MatchedItems?.Count ?? 0;
		int num2 = P_0.MissingItems?.Count ?? 0;
		List<string> list = new List<string>
		{
			"旧数据源：",
			P_0.OldPath ?? string.Empty,
			string.Empty,
			"新数据源：",
			P_0.NewPath ?? string.Empty,
			string.Empty,
			string.Format("可更换：{0} 个绑定", num),
			string.Format("缺失名称区域：{0} 个绑定", num2)
		};
		if (num2 > 0)
		{
			list.Add(string.Empty);
			list.Add("缺失清单：");
			foreach (Jk2boJKtvpW0C9HFNVs.kY8DvBV8FJH80M7vjngB item in P_0.MissingItems.Take(10))
			{
				list.Add("- " + (item.DisplayTitle ?? item.BindingId ?? string.Empty) + " / " + (item.ExcelName ?? string.Empty));
			}
			if (num2 > 10)
			{
				list.Add(string.Format("... 还有 {0} 个", num2 - 10));
			}
		}
		list.Add(string.Empty);
		list.Add(P_1 ? "新文件没有匹配到任何名称区域，未修改绑定。" : "确认后只会更新匹配项；缺失项保留旧数据源。是否继续？");
		return string.Join(Environment.NewLine, list);
	}

	private static string ddYOpUEEfn(Jk2boJKtvpW0C9HFNVs.gMo5J5VI9LOS3nqRiEJZ P_0)
	{
		if (P_0 == null)
		{
			return "请选择 Word 表格或 Excel 区域";
		}
		if (!P_0.HasWordTable)
		{
			if (!P_0.HasExcelSelection)
			{
				return "请选择 Word 表格或 Excel 区域";
			}
			return "可插入 Excel 选区";
		}
		if (!P_0.HasBinding)
		{
			return "当前表未绑定";
		}
		return "当前表已绑定";
	}

	private static string zePOO1f9yx(Jk2boJKtvpW0C9HFNVs.gMo5J5VI9LOS3nqRiEJZ P_0)
	{
		if (P_0 == null)
		{
			return "将光标放到 Word 表格内可绑定/同步；也可以先在 Excel 中选择区域，再插入为 Word 表格。";
		}
		if (!P_0.HasWordTable)
		{
			if (P_0.HasExcelSelection)
			{
				return "未定位到 Word 表格。可以将当前 Excel 选区插入到 Word 当前段落下方，并自动建立同步绑定。";
			}
			return "将光标放到 Word 表格内可绑定/同步；也可以先在 Excel 中选择区域，再插入并绑定为 Word 表格。";
		}
		if (P_0.HasBinding)
		{
			return "可以直接同步当前表；如需变更来源，可点击“重新绑定”。";
		}
		if (P_0.HasExcelSelection)
		{
			return "已检测到 Excel 选区，可以绑定当前 Word 表格。";
		}
		return "请在 Excel 中选择源区域后绑定当前 Word 表格。";
	}

	private static string VN9OnoyF9f(Jk2boJKtvpW0C9HFNVs.gMo5J5VI9LOS3nqRiEJZ P_0)
	{
		if (P_0 == null || !P_0.HasBinding)
		{
			return "绑定后可设置表头行数。";
		}
		if (!string.IsNullOrWhiteSpace(P_0.HeaderSettingText))
		{
			return P_0.HeaderSettingText;
		}
		return "表头行数：尚未识别";
	}

	private static string nWIO77Lyj2(Jk2boJKtvpW0C9HFNVs.gMo5J5VI9LOS3nqRiEJZ P_0)
	{
		if (P_0 == null || !P_0.HasWordTable)
		{
			if (P_0 == null || !P_0.HasExcelSelection)
			{
				return "未定位 Word 表格。";
			}
			return "可从当前 Excel 选区插入并绑定表格。";
		}
		if (!P_0.HasBinding)
		{
			return "尚未绑定。";
		}
		string text = ((!string.IsNullOrWhiteSpace(P_0.BoundFullPath)) ? P_0.BoundFullPath : (P_0.BoundWorkbook ?? string.Empty));
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return "已绑定。";
	}

	private static string LFhO5FvQ1M(Jk2boJKtvpW0C9HFNVs.gMo5J5VI9LOS3nqRiEJZ P_0)
	{
		if (P_0 == null || !P_0.HasExcelSelection)
		{
			return P_0?.ExcelStatus ?? "未检测到 Excel 选区。";
		}
		string text = P_0.ExcelWorkbook ?? string.Empty;
		string text2 = P_0.ExcelSheet ?? string.Empty;
		string text3 = P_0.ExcelAddress ?? string.Empty;
		string text4 = P_0.ExcelSize ?? string.Empty;
		string text5 = string.Join(" / ", new string[3] { text, text2, text3 }.Where((string item) => !string.IsNullOrWhiteSpace(item)));
		if (!string.IsNullOrWhiteSpace(text4))
		{
			if (!string.IsNullOrWhiteSpace(text5))
			{
				return text5 + "（" + text4 + "）";
			}
			return text4;
		}
		if (!string.IsNullOrWhiteSpace(text5))
		{
			return text5;
		}
		return "已检测到 Excel 当前选区。";
	}

	private static void yTAOcfuoN8(ObservableCollection<ffokv1V4hncupjXCMk8a> P_0, IList<Jk2boJKtvpW0C9HFNVs.l0FhISVIRyyYwtV64iqd> P_1, int P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		P_0.Clear();
		int num = Math.Max(0, P_2);
		if (num == 0 && P_1 != null)
		{
			num = P_1.Count;
		}
		_G_c__DisplayClass87_0 CS_8_locals_6 = new _G_c__DisplayClass87_0();
		CS_8_locals_6.c73VYRUyF58 = 1;
		while (CS_8_locals_6.c73VYRUyF58 <= num)
		{
			Jk2boJKtvpW0C9HFNVs.l0FhISVIRyyYwtV64iqd l0FhISVIRyyYwtV64iqd = P_1?.FirstOrDefault((Jk2boJKtvpW0C9HFNVs.l0FhISVIRyyYwtV64iqd item) => item.WordColumnIndex == CS_8_locals_6.c73VYRUyF58);
			int num2 = ((l0FhISVIRyyYwtV64iqd != null && l0FhISVIRyyYwtV64iqd.ExcelColumnIndex > 0) ? l0FhISVIRyyYwtV64iqd.ExcelColumnIndex : CS_8_locals_6.c73VYRUyF58);
			P_0.Add(new ffokv1V4hncupjXCMk8a
			{
				WordColumnIndex = CS_8_locals_6.c73VYRUyF58,
				ExcelColumnText = num2.ToString()
			});
			CS_8_locals_6.c73VYRUyF58++;
		}
	}

	private bool ivyOeDvgeh(System.Windows.Controls.TextBox P_0, out int P_1)
	{
		P_1 = 0;
		if (P_0 == null || !int.TryParse((P_0.Text ?? string.Empty).Trim(), out var result) || result < 0)
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("表头行数请输入 0 或正整数。", "IP_Assurance");
			P_0?.Focus();
			P_0?.SelectAll();
			return false;
		}
		P_1 = result;
		return true;
	}

	private bool dmsOy55xZ6(System.Windows.Controls.TextBox P_0, System.Windows.Controls.CheckBox P_1, System.Windows.Controls.TextBox P_2, System.Windows.Controls.ComboBox P_3, System.Windows.Controls.CheckBox P_4, IEnumerable<ffokv1V4hncupjXCMk8a> P_5, out int P_6, out int P_7, out bool P_8, out bool P_9, out List<int> P_10)
	{
		P_7 = 2;
		P_8 = true;
		P_9 = true;
		P_10 = null;
		if (!ivyOeDvgeh(P_0, out P_6))
		{
			return false;
		}
		if (!int.TryParse((P_2.Text ?? string.Empty).Trim(), out P_7) || P_7 < 1)
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("排序列请输入 1 或更大的整数。", "IP_Assurance");
			P_2.Focus();
			P_2.SelectAll();
			return false;
		}
		P_8 = P_3 == null || P_3.SelectedIndex != 1;
		P_9 = P_4 == null || P_4.IsChecked != false;
		if (!IVaOXNp6kw(P_5, out P_10))
		{
			return false;
		}
		return true;
	}

	private bool IVaOXNp6kw(IEnumerable<ffokv1V4hncupjXCMk8a> P_0, out List<int> P_1)
	{
		P_1 = new List<int>();
		if (P_0 == null)
		{
			return true;
		}
		int num = 0;
		foreach (ffokv1V4hncupjXCMk8a item in P_0)
		{
			if (item != null)
			{
				if (!int.TryParse((item.ExcelColumnText ?? string.Empty).Trim(), out var result) || result < 1)
				{
					F2ZFeLcsiLlLr89kqUl.u0kcmnykTv(string.Format("第 {0} 个 Word 列的 Excel 列号请输入 1 或更大的整数。", item.WordColumnIndex), "IP_Assurance");
					return false;
				}
				if (result <= num)
				{
					F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("列映射中的 Excel 列号需要从左到右递增。", "IP_Assurance");
					return false;
				}
				P_1.Add(result);
				num = result;
			}
		}
		return true;
	}

	private static void ebvOFufDA6(System.Windows.Controls.DataGrid P_0)
	{
		if (P_0 != null)
		{
			P_0.CommitEdit(DataGridEditingUnit.Cell, exitEditingMode: true);
			P_0.CommitEdit(DataGridEditingUnit.Row, exitEditingMode: true);
		}
	}

	private void UCrOh343Aw(string P_0, Func<Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs> P_1, bool P_2)
	{
		_G_c__DisplayClass92_0 CS_8_locals_7 = new _G_c__DisplayClass92_0();
		CS_8_locals_7.cASVYBwvli2 = P_1;
		if (r7mnIQ3VfX || CS_8_locals_7.cASVYBwvli2 == null)
		{
			return;
		}
		string text = bNZnKlpICU?.BindingId;
		nSaOWTWy29( true);
		MZEniWtslN = false;
		barCurrentProgress.IsIndeterminate = false;
		barAllProgress.IsIndeterminate = false;
		barCurrentProgress.Value = 0.0;
		barAllProgress.Value = 0.0;
		QmRO0PPQsB("正在处理...");
		ex9Ovtlm40();
		string text2 = string.Empty;
		try
		{
			CS_8_locals_7.xBZVY9np7wP = null;
			okTG2rFSnxjcTsuMG3L.sY9FLcxGhc(delegate
			{
				CS_8_locals_7.xBZVY9np7wP = CS_8_locals_7.cASVYBwvli2();
			}, P_0);
			AJLOPDSt5a(CS_8_locals_7.xBZVY9np7wP);
			text2 = CS_8_locals_7.xBZVY9np7wP?.Message ?? string.Empty;
		}
		finally
		{
			nSaOWTWy29( false);
			XvJOKeRLxt( false);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				QmRO0PPQsB(text2);
			}
			if (UMlnrm6j8x && P_2)
			{
				lmoOEgXMdh(bNZnKlpICU?.BindingId ?? text);
			}
		}
	}

	private void wIcOa8l5mb(string P_0, Func<Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs> P_1)
	{
		_G_c__DisplayClass93_0 CS_8_locals_7 = new _G_c__DisplayClass93_0();
		CS_8_locals_7.Yb0VYumO4a9 = P_1;
		if (r7mnIQ3VfX || CS_8_locals_7.Yb0VYumO4a9 == null)
		{
			return;
		}
		nSaOWTWy29( true);
		QmRO0PPQsB("正在处理...");
		string text = string.Empty;
		try
		{
			CS_8_locals_7.gTxVYDrAlNL = null;
			okTG2rFSnxjcTsuMG3L.iHUFttreO8(delegate
			{
				CS_8_locals_7.gTxVYDrAlNL = CS_8_locals_7.Yb0VYumO4a9();
			}, P_0);
			AJLOPDSt5a(CS_8_locals_7.gTxVYDrAlNL);
			text = CS_8_locals_7.gTxVYDrAlNL?.Message ?? string.Empty;
		}
		finally
		{
			nSaOWTWy29( false);
			XvJOKeRLxt( false);
			if (!string.IsNullOrWhiteSpace(text))
			{
				QmRO0PPQsB(text);
			}
		}
	}

	private void R8KOqA1Zsf(Jk2boJKtvpW0C9HFNVs.eEHsHgVgzpw09onBAkve P_0)
	{
		if (!r7mnIQ3VfX && !kvinJXJO8H && P_0 != null && P_0.CanJumpExcel)
		{
			kvinJXJO8H = true;
			base.Cursor = System.Windows.Input.Cursors.Wait;
			QmRO0PPQsB("正在打开 Excel 并定位源区域，请稍候...");
			anROS5dIum();
			ex9Ovtlm40();
			bool flag = false;
			string empty = string.Empty;
			bool requiresUserAction = false;
			try
			{
				flag = Jk2boJKtvpW0C9HFNVs.jfJEYZIKi1(P_0, out empty, out requiresUserAction);
			}
			finally
			{
				kvinJXJO8H = false;
				base.Cursor = (r7mnIQ3VfX ? System.Windows.Input.Cursors.Wait : null);
				anROS5dIum();
			}
			if (flag)
			{
				QmRO0PPQsB("已定位到 Excel 区域。");
				lRTy9Ic5uax0jm0RR1L.SeXce6fgLN("已定位到 Excel 区域。", "Excel同步");
				return;
			}
			string text = (string.IsNullOrWhiteSpace(empty) ? "未能定位到 Excel 区域。" : empty);
			QmRO0PPQsB(text);
			un7uUxcCbw6Q36geOYj.CsKcO7u6di(new Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs
			{
				Success = false,
				RequiresUserAction = requiresUserAction,
				Message = text
			}, "Excel同步");
		}
	}

	private void AJLOPDSt5a(Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs P_0)
	{
		if (P_0 != null)
		{
			QmRO0PPQsB(P_0.Message ?? string.Empty);
			un7uUxcCbw6Q36geOYj.CsKcO7u6di(P_0, "Excel同步");
		}
	}

	private bool XGtOAmBcpX(int P_0, int P_1, string P_2)
	{
		if (P_1 <= 0)
		{
			barCurrentProgress.IsIndeterminate = true;
			barAllProgress.IsIndeterminate = true;
			QmRO0PPQsB(P_2 ?? string.Empty);
			try
			{
				base.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
				{
				});
			}
			catch
			{
			}
			if (!MZEniWtslN)
			{
				return base.IsVisible;
			}
			return false;
		}
		barCurrentProgress.IsIndeterminate = false;
		barAllProgress.IsIndeterminate = false;
		int num = ((P_1 <= 0) ? 100 : ((int)Math.Round((double)P_0 * 100.0 / (double)P_1)));
		if (num < 0)
		{
			num = 0;
		}
		if (num > 100)
		{
			num = 100;
		}
		barCurrentProgress.Value = num;
		barAllProgress.Value = num;
		QmRO0PPQsB(P_2 ?? string.Empty);
		try
		{
			base.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
		}
		catch
		{
		}
		if (!MZEniWtslN)
		{
			return base.IsVisible;
		}
		return false;
	}

	private void ex9Ovtlm40()
	{
		try
		{
			base.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
		}
		catch
		{
		}
	}

	private void nSaOWTWy29(bool P_0)
	{
		r7mnIQ3VfX = P_0;
		if (P_0)
		{
			KwHOUY7w6K();
		}
		base.Cursor = (P_0 ? System.Windows.Input.Cursors.Wait : null);
		btnCancelCurrent.IsEnabled = P_0;
		btnCancelAll.IsEnabled = P_0;
		btnCancelCurrent.Visibility = ((!P_0) ? Visibility.Collapsed : Visibility.Visible);
		btnCancelAll.Visibility = ((!P_0) ? Visibility.Collapsed : Visibility.Visible);
		barCurrentProgress.Visibility = ((!P_0) ? Visibility.Collapsed : Visibility.Visible);
		barAllProgress.Visibility = ((!P_0) ? Visibility.Collapsed : Visibility.Visible);
		if (!P_0)
		{
			barCurrentProgress.IsIndeterminate = false;
			barAllProgress.IsIndeterminate = false;
		}
		chkSyncHeaders.IsEnabled = !P_0;
		chkShowAdvancedColumns.IsEnabled = !P_0;
		btnToggleContextMenu.IsEnabled = !P_0;
		jlKObjnrQv();
		anROS5dIum();
		EohOwGuhvN();
	}

	private void QmRO0PPQsB(string P_0)
	{
		string text = P_0 ?? string.Empty;
		txtCurrentStatus.Text = text;
		txtAllStatus.Text = text;
		txtDataSourceStatusBar.Text = text;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!Mven2dRYND)
		{
			Mven2dRYND = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/excelsyncwindow.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			tabSync = (System.Windows.Controls.TabControl)target;
			tabSync.SelectionChanged += fFuOIGKZTj;
			break;
		case 2:
			tabCurrent = (TabItem)target;
			break;
		case 3:
			barCurrentLoading = (System.Windows.Controls.ProgressBar)target;
			break;
		case 4:
			txtCurrentCardTitle = (TextBlock)target;
			break;
		case 5:
			btnRefreshExcelSelection = (System.Windows.Controls.Button)target;
			btnRefreshExcelSelection.Click += QWrphxw7m1;
			break;
		case 6:
			txtWordStatus = (TextBlock)target;
			break;
		case 7:
			txtWordTable = (TextBlock)target;
			break;
		case 8:
			txtBindingSourceSummary = (TextBlock)target;
			break;
		case 9:
			linkCurrentBindingSource = (Hyperlink)target;
			linkCurrentBindingSource.Click += knGpaQGvb3;
			break;
		case 10:
			runBindingSourceSummary = (Run)target;
			break;
		case 11:
			txtHeaderSetting = (TextBlock)target;
			break;
		case 12:
			lblExcelSelectionSummary = (TextBlock)target;
			break;
		case 13:
			txtExcelSelectionSummary = (TextBlock)target;
			break;
		case 14:
			txtBindingId = (System.Windows.Controls.TextBox)target;
			break;
		case 15:
			txtExcelName = (System.Windows.Controls.TextBox)target;
			break;
		case 16:
			txtBoundPath = (System.Windows.Controls.TextBox)target;
			break;
		case 17:
			txtBoundSheet = (System.Windows.Controls.TextBox)target;
			break;
		case 18:
			txtExcelStatus = (System.Windows.Controls.TextBox)target;
			break;
		case 19:
			txtExcelWorkbook = (System.Windows.Controls.TextBox)target;
			break;
		case 20:
			txtExcelSheet = (System.Windows.Controls.TextBox)target;
			break;
		case 21:
			txtExcelAddress = (System.Windows.Controls.TextBox)target;
			break;
		case 22:
			txtExcelSize = (System.Windows.Controls.TextBox)target;
			break;
		case 23:
			txtHeaderRows = (System.Windows.Controls.TextBox)target;
			break;
		case 24:
			chkSortEnabled = (System.Windows.Controls.CheckBox)target;
			chkSortEnabled.Checked += fIpO6e9sPM;
			chkSortEnabled.Unchecked += fIpO6e9sPM;
			break;
		case 25:
			txtSortColumnIndex = (System.Windows.Controls.TextBox)target;
			break;
		case 26:
			cboSortDirection = (System.Windows.Controls.ComboBox)target;
			break;
		case 27:
			chkSortPinOtherLast = (System.Windows.Controls.CheckBox)target;
			break;
		case 28:
			gridColumnMappings = (System.Windows.Controls.DataGrid)target;
			break;
		case 29:
			btnSaveHeaderSetting = (System.Windows.Controls.Button)target;
			btnSaveHeaderSetting.Click += aWCpXc4wCW;
			break;
		case 30:
			btnPrimaryCurrent = (System.Windows.Controls.Button)target;
			btnPrimaryCurrent.Click += ShXp5vDsqH;
			break;
		case 31:
			btnSplitCurrentTable = (System.Windows.Controls.Button)target;
			btnSplitCurrentTable.Click += xifpeRxOvW;
			break;
		case 32:
			btnRebind = (System.Windows.Controls.Button)target;
			btnRebind.Click += tbkpcqdVrT;
			break;
		case 33:
			btnUnbind = (System.Windows.Controls.Button)target;
			btnUnbind.Click += HSdpyZZZ4x;
			break;
		case 34:
			barCurrentProgress = (System.Windows.Controls.ProgressBar)target;
			break;
		case 35:
			txtCurrentStatus = (TextBlock)target;
			break;
		case 36:
			btnCancelCurrent = (System.Windows.Controls.Button)target;
			btnCancelCurrent.Click += vNHOVaYlKI;
			break;
		case 37:
			tabAll = (TabItem)target;
			break;
		case 38:
			txtAllSummary = (TextBlock)target;
			break;
		case 39:
			btnRefreshAll = (System.Windows.Controls.Button)target;
			btnRefreshAll.Click += FJXpPgme4M;
			break;
		case 40:
			btnCleanInvalidBindings = (System.Windows.Controls.Button)target;
			btnCleanInvalidBindings.Click += TT4pAnStVL;
			break;
		case 41:
			barAllLoading = (System.Windows.Controls.ProgressBar)target;
			break;
		case 42:
			treeBindings = (System.Windows.Controls.TreeView)target;
			treeBindings.SelectedItemChanged += Av2OunZW4w;
			break;
		case 43:
			txtAllDetailEmpty = (TextBlock)target;
			break;
		case 44:
			panelAllDetailContent = (ScrollViewer)target;
			break;
		case 45:
			txtAllDetailTitle = (TextBlock)target;
			break;
		case 46:
			txtAllDetailHeading = (TextBlock)target;
			break;
		case 47:
			txtAllDetailStatus = (TextBlock)target;
			break;
		case 48:
			txtAllDetailWordTable = (TextBlock)target;
			break;
		case 49:
			txtAllDetailWorkbook = (TextBlock)target;
			break;
		case 50:
			txtAllDetailSheet = (TextBlock)target;
			break;
		case 51:
			txtAllDetailName = (TextBlock)target;
			break;
		case 52:
			linkAllDetailPath = (Hyperlink)target;
			linkAllDetailPath.Click += OWypxBxIqE;
			break;
		case 53:
			runAllDetailPath = (Run)target;
			break;
		case 54:
			txtAllHeaderRows = (System.Windows.Controls.TextBox)target;
			break;
		case 55:
			chkAllSortEnabled = (System.Windows.Controls.CheckBox)target;
			chkAllSortEnabled.Checked += fIpO6e9sPM;
			chkAllSortEnabled.Unchecked += fIpO6e9sPM;
			break;
		case 56:
			txtAllSortColumnIndex = (System.Windows.Controls.TextBox)target;
			break;
		case 57:
			cboAllSortDirection = (System.Windows.Controls.ComboBox)target;
			break;
		case 58:
			chkAllSortPinOtherLast = (System.Windows.Controls.CheckBox)target;
			break;
		case 59:
			gridAllColumnMappings = (System.Windows.Controls.DataGrid)target;
			break;
		case 60:
			btnSaveAllHeaderSetting = (System.Windows.Controls.Button)target;
			btnSaveAllHeaderSetting.Click += afQpFDqfMW;
			break;
		case 61:
			panelAllAdvancedDetails = (StackPanel)target;
			break;
		case 62:
			txtAllDetailBindingId = (TextBlock)target;
			break;
		case 63:
			txtAllDetailBookmark = (TextBlock)target;
			break;
		case 64:
			borderAllError = (System.Windows.Controls.Border)target;
			break;
		case 65:
			txtAllError = (TextBlock)target;
			break;
		case 66:
			barAllProgress = (System.Windows.Controls.ProgressBar)target;
			break;
		case 67:
			txtAllStatus = (TextBlock)target;
			break;
		case 68:
			btnSyncSelected = (System.Windows.Controls.Button)target;
			btnSyncSelected.Click += vsWpd2MBoZ;
			break;
		case 69:
			btnSyncAll = (System.Windows.Controls.Button)target;
			btnSyncAll.Click += GCCpzSGYn1;
			break;
		case 70:
			btnExportAll = (System.Windows.Controls.Button)target;
			btnExportAll.Click += ERtpqoZ4JG;
			break;
		case 71:
			btnCancelAll = (System.Windows.Controls.Button)target;
			btnCancelAll.Click += vNHOVaYlKI;
			break;
		case 72:
			tabDataSources = (TabItem)target;
			break;
		case 73:
			txtDataSourceSummary = (TextBlock)target;
			break;
		case 74:
			btnRefreshDataSources = (System.Windows.Controls.Button)target;
			btnRefreshDataSources.Click += vR2pvrSv6A;
			break;
		case 75:
			gridDataSources = (System.Windows.Controls.DataGrid)target;
			gridDataSources.SelectionChanged += bB1OD28UTM;
			break;
		case 76:
			txtDataSourceEmpty = (TextBlock)target;
			break;
		case 77:
			panelDataSourceDetailContent = (ScrollViewer)target;
			break;
		case 78:
			txtDataSourceTitle = (TextBlock)target;
			break;
		case 79:
			txtDataSourceStatus = (TextBlock)target;
			break;
		case 80:
			txtDataSourceBindingCount = (TextBlock)target;
			break;
		case 81:
			txtDataSourceNormalCount = (TextBlock)target;
			break;
		case 82:
			txtDataSourceMissingPathCount = (TextBlock)target;
			break;
		case 83:
			txtDataSourcePath = (TextBlock)target;
			break;
		case 84:
			btnReplaceDataSource = (System.Windows.Controls.Button)target;
			btnReplaceDataSource.Click += g5gpWglTKb;
			break;
		case 85:
			btnOpenDataSourceFolder = (System.Windows.Controls.Button)target;
			btnOpenDataSourceFolder.Click += tTnp0BpuM9;
			break;
		case 86:
			btnJumpDataSourceBinding = (System.Windows.Controls.Button)target;
			btnJumpDataSourceBinding.Click += X2YpkbCXJI;
			break;
		case 87:
			listDataSourceBindings = (System.Windows.Controls.ListBox)target;
			listDataSourceBindings.SelectionChanged += aKAOT11OGe;
			break;
		case 88:
			txtDataSourceStatusBar = (TextBlock)target;
			break;
		case 89:
			tabOptions = (TabItem)target;
			break;
		case 90:
			chkSyncHeaders = (System.Windows.Controls.CheckBox)target;
			chkSyncHeaders.Checked += VX7OBtsx3k;
			chkSyncHeaders.Unchecked += VX7OBtsx3k;
			break;
		case 91:
			txtContextMenuStatus = (TextBlock)target;
			break;
		case 92:
			btnToggleContextMenu = (System.Windows.Controls.Button)target;
			btnToggleContextMenu.Click += EjMORiBgG9;
			break;
		case 93:
			chkShowAdvancedColumns = (System.Windows.Controls.CheckBox)target;
			chkShowAdvancedColumns.Checked += C96O97btI4;
			chkShowAdvancedColumns.Unchecked += C96O97btI4;
			break;
		case 94:
			txtOptionsStatus = (TextBlock)target;
			break;
		default:
			Mven2dRYND = true;
			break;
		}
	}

	[CompilerGenerated]
	private void sj7OkAhdks(object P_0, System.Windows.Input.KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}

	[CompilerGenerated]
	private void UEoOxsPH1f(object P_0, RoutedEventArgs P_1)
	{
		txtAllSummary.Text = "切换到“全部表”后读取当前文档绑定。";
		txtDataSourceSummary.Text = "切换到“数据源”后按 Excel 文件路径查看绑定来源。";
		jpROigfFHQ();
		mxOOHYibqA();
		r5TOJtV7Bf(false, true);
		odEOteY3dg();
		R2SOLEqQR7();
		sJTOjaskhb();
		wl5OM5OnNS();
		anROS5dIum();
		EohOwGuhvN();
	}

	[CompilerGenerated]
	private void zxrOdnuicL(object P_0, EventArgs P_1)
	{
		YQpOQgxdib();
	}

	[CompilerGenerated]
	private Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs B8vOzIRuaO()
	{
		return Jk2boJKtvpW0C9HFNVs.XVJ45smyDw(XGtOAmBcpX);
	}

	[CompilerGenerated]
	private Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs ttlnRHBwlD()
	{
		return Jk2boJKtvpW0C9HFNVs.TcXEXakPZc(XGtOAmBcpX);
	}

	[CompilerGenerated]
	private Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs hi9nVctXsA()
	{
		if (!VhjO8cZh01(out var text, out var requiresUserAction))
		{
			return new Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs
			{
				Success = false,
				RequiresUserAction = requiresUserAction,
				Message = (string.IsNullOrWhiteSpace(text) ? "未能定位到选中的 Word 表格，无法同步选中表。" : text)
			};
		}
		return Jk2boJKtvpW0C9HFNVs.XVJ45smyDw(XGtOAmBcpX);
	}

	[CompilerGenerated]
	private Jk2boJKtvpW0C9HFNVs.B8Id9rVIwgTW2spgYNvs NmBnBxPu59()
	{
		return Jk2boJKtvpW0C9HFNVs.zxS4eKlv5S(XGtOAmBcpX);
	}

	[CompilerGenerated]
	private void AfJn9Q4JoL()
	{
		if (tabCurrent.IsSelected)
		{
			gtPO3hNFRn();
		}
		s7un8F22Xj.Stop();
		s7un8F22Xj.Start();
	}
}
