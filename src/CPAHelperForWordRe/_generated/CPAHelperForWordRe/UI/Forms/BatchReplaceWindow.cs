using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using ghWYvT5gdl6wakj5jtn;
using hJKpQrVSwRwMyI2RyDQN;
using Microsoft.Office.Interop.Word;
using ndRERvVtEjasqN2cQqiN;
using sNVQvmsNbF4pw13wHyu;
using YNri0QclKMfRh2PQoZV;

namespace CPAHelperForWordRe.UI.Forms;

public sealed class BatchReplaceWindow : System.Windows.Window, IComponentConnector
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass4_0
	{
		public string GKrV4HZK6Dk;

		public _G_c__DisplayClass4_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal IEnumerable<string> RxXV4iAvo15(string pattern)
		{
			return Directory.GetFiles(GKrV4HZK6Dk, pattern, SearchOption.TopDirectoryOnly);
		}
	}

	internal System.Windows.Controls.TextBox txtFolder;

	internal System.Windows.Controls.TextBox txtFind;

	internal System.Windows.Controls.TextBox txtReplace;

	internal System.Windows.Controls.CheckBox chkWildcards;

	internal System.Windows.Controls.CheckBox chkDoc;

	internal System.Windows.Controls.CheckBox chkDocx;

	private bool dnbCLN7KgP;

	public BatchReplaceWindow()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		InitializeComponent();
		base.PreviewKeyDown += delegate(object P_0, System.Windows.Input.KeyEventArgs P_1)
		{
			if (P_1.Key == Key.Escape)
			{
				Close();
			}
		};
	}

	private void NtICYYYvxu(object P_0, RoutedEventArgs P_1)
	{
		string text = txtFolder.Text ?? string.Empty;
		if (string.IsNullOrWhiteSpace(text) || !Directory.Exists(text))
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("请选择待替换文件所在文件夹。", "IP_Assurance");
			return;
		}
		string text2 = txtFind.Text ?? string.Empty;
		if (string.IsNullOrEmpty(text2))
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("请输入查找内容。", "IP_Assurance");
			return;
		}
		string[] array = NGTCMHOyQr(text).ToArray();
		if (array.Length == 0)
		{
			F2ZFeLcsiLlLr89kqUl.u0kcmnykTv("所选文件夹中没有可处理的 Word 文档。", "IP_Assurance");
			return;
		}
		Microsoft.Office.Interop.Word.Application wordApp = eSfxffslhXbaGAjFNv1.WordApp;
		ProgressWindow progressWindow = new ProgressWindow();
		rA7neb5TDVvwyWyxwua.IPf5i0ZcV4(progressWindow);
		int num = 0;
		wordApp.ScreenUpdating = false;
		try
		{
			string[] array2 = array;
			foreach (string text3 in array2)
			{
				if (!progressWindow.IsCancelRequested && progressWindow.IsVisible)
				{
					num++;
					progressWindow.SetProgress((int)Math.Round((double)num * 100.0 / (double)array.Length), string.Format("当前进度：{0} / {1}", num, array.Length));
					ndYCwK9LP7(progressWindow);
					LKsCb2eSxj(wordApp, text3, text2, txtReplace.Text ?? string.Empty, chkWildcards.IsChecked == true);
					continue;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8(ex.ToString(), "IP_Assurance");
		}
		finally
		{
			wordApp.ScreenUpdating = true;
			try
			{
				progressWindow.Close();
			}
			catch
			{
			}
		}
		F2ZFeLcsiLlLr89kqUl.Ay3cNuEgJo(string.Format("批量替换完成：{0} / {1}", num, array.Length), "IP_Assurance");
	}

	private void JVRCZQmyQv(object P_0, RoutedEventArgs P_1)
	{
		using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
		{
			SelectedPath = "C:\\\\"
		};
		if (folderBrowserDialog.ShowDialog(rA7neb5TDVvwyWyxwua.KJy58rGLXb()) == System.Windows.Forms.DialogResult.OK)
		{
			txtFolder.Text = folderBrowserDialog.SelectedPath;
		}
	}

	private void NnqCfjhqey(object P_0, RoutedEventArgs P_1)
	{
		Close();
	}

	private IEnumerable<string> NGTCMHOyQr(string P_0)
	{
		_G_c__DisplayClass4_0 CS_8_locals_2 = new _G_c__DisplayClass4_0();
		CS_8_locals_2.GKrV4HZK6Dk = P_0;
		List<string> list = new List<string>();
		if (chkDoc.IsChecked == true)
		{
			list.Add("*.doc");
		}
		if (chkDocx.IsChecked == true)
		{
			list.Add("*.docx");
		}
		if (list.Count == 0)
		{
			list.Add("*.doc");
		}
		return (from path in list.SelectMany((string pattern) => Directory.GetFiles(CS_8_locals_2.GKrV4HZK6Dk, pattern, SearchOption.TopDirectoryOnly))
			where !Path.GetFileName(path).StartsWith("请选择待替换文件所在文件夹。", StringComparison.Ordinal)
			select path).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy((string path) => path, StringComparer.CurrentCultureIgnoreCase);
	}

	private static void LKsCb2eSxj(Microsoft.Office.Interop.Word.Application P_0, string P_1, string P_2, string P_3, bool P_4)
	{
		Document document = null;
		try
		{
			Documents documents = P_0.Documents;
			object FileName = P_1;
			object ConfirmConversions = Type.Missing;
			object ReadOnly = false;
			object AddToRecentFiles = false;
			object PasswordDocument = Type.Missing;
			object PasswordTemplate = Type.Missing;
			object Revert = Type.Missing;
			object WritePasswordDocument = Type.Missing;
			object WritePasswordTemplate = Type.Missing;
			object Format = Type.Missing;
			object Encoding = Type.Missing;
			object Visible = false;
			object OpenAndRepair = Type.Missing;
			object DocumentDirection = Type.Missing;
			object NoEncodingDialog = Type.Missing;
			object XMLTransform = Type.Missing;
			document = documents.Open(ref FileName, ref ConfirmConversions, ref ReadOnly, ref AddToRecentFiles, ref PasswordDocument, ref PasswordTemplate, ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format, ref Encoding, ref Visible, ref OpenAndRepair, ref DocumentDirection, ref NoEncodingDialog, ref XMLTransform);
			foreach (Range storyRange in document.StoryRanges)
			{
				for (Range range = storyRange; range != null; range = range.NextStoryRange)
				{
					SZgCSYIbGX(range, P_2, P_3, P_4);
				}
			}
			document.Save();
			Document document2 = document;
			XMLTransform = false;
			NoEncodingDialog = Type.Missing;
			DocumentDirection = Type.Missing;
			document2.Close(ref XMLTransform, ref NoEncodingDialog, ref DocumentDirection);
		}
		finally
		{
			if (document != null)
			{
				try
				{
					Marshal.ReleaseComObject(document);
				}
				catch
				{
				}
			}
		}
	}

	private static void SZgCSYIbGX(Range P_0, string P_1, string P_2, bool P_3)
	{
		Find find = P_0.Find;
		find.ClearFormatting();
		find.Replacement.ClearFormatting();
		find.Text = P_1;
		find.Replacement.Text = P_2;
		find.Forward = true;
		find.Wrap = WdFindWrap.wdFindContinue;
		find.Format = false;
		find.MatchCase = false;
		find.MatchWholeWord = false;
		find.MatchByte = true;
		find.MatchWildcards = P_3;
		find.MatchSoundsLike = false;
		find.MatchAllWordForms = false;
		object FindText = Type.Missing;
		object MatchCase = Type.Missing;
		object MatchWholeWord = Type.Missing;
		object MatchWildcards = Type.Missing;
		object MatchSoundsLike = Type.Missing;
		object MatchAllWordForms = Type.Missing;
		object Forward = Type.Missing;
		object Wrap = Type.Missing;
		object Format = Type.Missing;
		object ReplaceWith = Type.Missing;
		object Replace = WdReplace.wdReplaceAll;
		object MatchKashida = Type.Missing;
		object MatchDiacritics = Type.Missing;
		object MatchAlefHamza = Type.Missing;
		object MatchControl = Type.Missing;
		find.Execute(ref FindText, ref MatchCase, ref MatchWholeWord, ref MatchWildcards, ref MatchSoundsLike, ref MatchAllWordForms, ref Forward, ref Wrap, ref Format, ref ReplaceWith, ref Replace, ref MatchKashida, ref MatchDiacritics, ref MatchAlefHamza, ref MatchControl);
	}

	private static void ndYCwK9LP7(ProgressWindow P_0)
	{
		try
		{
			P_0.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
			{
			});
		}
		catch
		{
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!dnbCLN7KgP)
		{
			dnbCLN7KgP = true;
			Uri resourceLocator = new Uri("/CPAHelperForWordRe;component/ui/forms/batchreplacewindow.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			txtFolder = (System.Windows.Controls.TextBox)target;
			break;
		case 2:
			((System.Windows.Controls.Button)target).Click += JVRCZQmyQv;
			break;
		case 3:
			txtFind = (System.Windows.Controls.TextBox)target;
			break;
		case 4:
			txtReplace = (System.Windows.Controls.TextBox)target;
			break;
		case 5:
			chkWildcards = (System.Windows.Controls.CheckBox)target;
			break;
		case 6:
			chkDoc = (System.Windows.Controls.CheckBox)target;
			break;
		case 7:
			chkDocx = (System.Windows.Controls.CheckBox)target;
			break;
		case 8:
			((System.Windows.Controls.Button)target).Click += NtICYYYvxu;
			break;
		case 9:
			((System.Windows.Controls.Button)target).Click += NnqCfjhqey;
			break;
		default:
			dnbCLN7KgP = true;
			break;
		}
	}

	[CompilerGenerated]
	private void soiCt9SAog(object P_0, System.Windows.Input.KeyEventArgs P_1)
	{
		if (P_1.Key == Key.Escape)
		{
			Close();
		}
	}
}
