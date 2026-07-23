using System.Windows.Forms;
using WordTableToolService5;

namespace LoggerInitializer;

internal static class LoggerInitializer
{
	public static void Ay3cNuEgJo(string P_0, string P_1 = "IP_Assurance", IWin32Window P_2 = null)
	{
		MessageBox.Show(P_2 ?? WordTableToolService5.KJy58rGLXb(), P_0, P_1, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	public static void u0kcmnykTv(string P_0, string P_1 = "IP_Assurance", IWin32Window P_2 = null)
	{
		MessageBox.Show(P_2 ?? WordTableToolService5.KJy58rGLXb(), P_0, P_1, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	public static void F9Ycoqv2I8(string P_0, string P_1 = "IP_Assurance", IWin32Window P_2 = null)
	{
		MessageBox.Show(P_2 ?? WordTableToolService5.KJy58rGLXb(), P_0, P_1, MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	public static bool JWucG2ERAH(string P_0, string P_1 = "IP_Assurance", IWin32Window P_2 = null)
	{
		return MessageBox.Show(P_2 ?? WordTableToolService5.KJy58rGLXb(), P_0, P_1, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
	}
}
