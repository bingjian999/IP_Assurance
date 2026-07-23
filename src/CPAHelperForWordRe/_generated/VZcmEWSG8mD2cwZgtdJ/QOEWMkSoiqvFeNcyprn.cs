using System.IO;
using System.Net;
using System.Text;
using hJKpQrVSwRwMyI2RyDQN;

namespace VZcmEWSG8mD2cwZgtdJ;

internal static class QOEWMkSoiqvFeNcyprn
{
	public static string YEGSCr7bHN(string P_0, int P_1 = 8000)
	{
		try
		{
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(P_0);
			obj.Method = "GET";
			obj.Timeout = P_1;
			obj.UserAgent = "CPAHelperForWordRe";
			using HttpWebResponse httpWebResponse = (HttpWebResponse)obj.GetResponse();
			using Stream stream = httpWebResponse.GetResponseStream();
			using StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
			return streamReader.ReadToEnd();
		}
		catch
		{
			return null;
		}
	}
}
