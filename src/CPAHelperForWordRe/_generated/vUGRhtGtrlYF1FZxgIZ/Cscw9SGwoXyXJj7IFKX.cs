using System.Drawing;
using System.Windows.Forms;
using CPAHelperForWordRe.UI.Forms.Common;
using e4N8U9GSjO7sNI12Lpf;
using ghWYvT5gdl6wakj5jtn;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;
using YNri0QclKMfRh2PQoZV;

namespace vUGRhtGtrlYF1FZxgIZ;

internal sealed class Cscw9SGwoXyXJj7IFKX : HDS8hJGbnCWyNGfO01j
{
	public string hveVL8NJXjM(string P_0, string P_1, string P_2)
	{
		TextPromptWindow textPromptWindow = new TextPromptWindow(P_0, P_1, P_2);
		if (rA7neb5TDVvwyWyxwua.NJs5HCHQjv(textPromptWindow) != true)
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
		return (openFileDialog.ShowDialog(rA7neb5TDVvwyWyxwua.KJy58rGLXb()) == DialogResult.OK) ? openFileDialog.FileName : null;
	}

	public string SA6VLiTt8Ir(string P_0, string P_1)
	{
		using SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Filter = "JSON 文件 (*.json)|*.json",
			Title = P_0,
			FileName = P_1
		};
		return (saveFileDialog.ShowDialog(rA7neb5TDVvwyWyxwua.KJy58rGLXb()) == DialogResult.OK) ? saveFileDialog.FileName : null;
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
		if (colorDialog.ShowDialog(rA7neb5TDVvwyWyxwua.KJy58rGLXb()) != DialogResult.OK)
		{
			return null;
		}
		return colorDialog.Color.R | (colorDialog.Color.G << 8) | (colorDialog.Color.B << 16);
	}

	public bool LDCVLQYyCaG(string P_0, string P_1 = "IP_Assurance")
	{
		return F2ZFeLcsiLlLr89kqUl.JWucG2ERAH(P_0, P_1);
	}

	public void tfDVL1SJK0M(string P_0, string P_1 = "IP_Assurance")
	{
		F2ZFeLcsiLlLr89kqUl.Ay3cNuEgJo(P_0, P_1);
	}

	public void GZdVLrQIdas(string P_0, string P_1 = "IP_Assurance")
	{
		F2ZFeLcsiLlLr89kqUl.u0kcmnykTv(P_0, P_1);
	}

	public void ULjVLJjCx1c(string P_0, string P_1 = "IP_Assurance")
	{
		F2ZFeLcsiLlLr89kqUl.F9Ycoqv2I8(P_0, P_1);
	}

	public Cscw9SGwoXyXJj7IFKX()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
	}
}
