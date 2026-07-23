using System.IO;
using System.Net;
using System.Text;
using AiSseStreamService3;

namespace AiHelper_16;

internal static class AiHelper_16
{
	public static string HttpGetString(string P_0, int P_1 = 8000)
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
