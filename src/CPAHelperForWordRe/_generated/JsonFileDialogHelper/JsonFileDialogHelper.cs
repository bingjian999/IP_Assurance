using System.Drawing;
using System.Windows.Forms;
using CPAHelperForWordRe.UI.Forms.Common;
using Helper_12;
using WordTableToolService5;
using AiSseStreamService3;
using SseStreamInitializer;
using LoggerInitializer;

namespace JsonFileDialogHelper;

internal sealed class JsonFileDialogHelper : HDS8hJGbnCWyNGfO01j
{
	public string hveVL8NJXjM(string P_0, string P_1, string P_2)
	{
		TextPromptWindow textPromptWindow = new TextPromptWindow(P_0, P_1, P_2);
		if (WordTableToolService5.ShowWpfDialog(textPromptWindow) != true)
		{
			return null;
		}
		return textPromptWindow.InputText;
	}

	public string BxkVLIlDE06(string P_0)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = "JSON 文件 (*.json)|*.json",
			Title = P_0
		};
		return (openFileDialog.ShowDialog(WordTableToolService5.GetOwnerWindow()) == DialogResult.OK) ? openFileDialog.FileName : null;
	}

	public string SA6VLiTt8Ir(string P_0, string P_1)
	{
		using SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Filter = "JSON 文件 (*.json)|*.json",
			Title = P_0,
			FileName = P_1
		};
		return (saveFileDialog.ShowDialog(WordTableToolService5.GetOwnerWindow()) == DialogResult.OK) ? saveFileDialog.FileName : null;
	}

	public int? KutVLHOhcIC(int? P_0)
	{
		using ColorDialog colorDialog = new ColorDialog
		{
			FullOpen = true
		};
		if (P_0.HasValue && P_0.Value != -16777216)
		{
			int value = P_0.Value;
			colorDialog.Color = Color.FromArgb(value & 0xFF, (value >> 8) & 0xFF, (value >> 16) & 0xFF);
		}
		if (colorDialog.ShowDialog(WordTableToolService5.GetOwnerWindow()) != DialogResult.OK)
		{
			return null;
		}
		return colorDialog.Color.R | (colorDialog.Color.G << 8) | (colorDialog.Color.B << 16);
	}

	public bool LDCVLQYyCaG(string P_0, string P_1 = "IP_Assurance")
	{
		return LoggerInitializer.ShowConfirm(P_0, P_1);
	}

	public void LogWarning(string P_0, string P_1 = "IP_Assurance")
	{
		LoggerInitializer.ShowInfo(P_0, P_1);
	}

	public void LogMessage(string P_0, string P_1 = "IP_Assurance")
	{
		LoggerInitializer.ShowWarning(P_0, P_1);
	}

	public void LogDebugMessage(string P_0, string P_1 = "IP_Assurance")
	{
		LoggerInitializer.ShowError(P_0, P_1);
	}

	public JsonFileDialogHelper()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
