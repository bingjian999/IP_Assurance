using System;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HttpHelper_1;
using TableBorderConfig;
using AiSseStreamService3;
using Helper_18;
using SseStreamInitializer;
using Newtonsoft.Json.Linq;
using HttpHelper_2;
using AiHelper_12;

namespace AiSseStreamService4;

internal static class AiSseStreamService4
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass6_0
	{
		public bool flag;

		public _G_c__DisplayClass6_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal void h9VVEpKGc4r(AiHelper_12 c)
		{
			c.System = c.System ?? new Helper_18();
			c.System.AutoUpdate = flag;
		}
	}

	public static string GetAssemblyVersion()
	{
		Version version = Assembly.GetExecutingAssembly().GetName().Version;
		if (!(version != null))
		{
			return "0.0.0.0";
		}
		return version.ToString();
	}

	public static async Task<HttpHelper_1> PJYL5bLAxq(bool P_0 = false)
	{
		try
		{
			HttpHelper_2.BNmLxKn8Mc();
			HttpClient client = new HttpClient
			{
				Timeout = TimeSpan.FromSeconds(8.0)
			};
			try
			{
				return DpNLX6EZ8H(JObject.Parse(await client.GetStringAsync("0.0.0.0")));
			}
			finally
			{
				((IDisposable)client)?.Dispose();
			}
		}
		catch (Exception)
		{
			_ = P_0;
			return null;
		}
	}

	public static bool DodLcdpfxo(string P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		if (!Version.TryParse(P_0, out var result))
		{
			return true;
		}
		if (!Version.TryParse(P_1, out var result2))
		{
			return false;
		}
		return result2 > result;
	}

	public static bool pS8Leo78tt()
	{
		TableBorderConfig current = TableBorderConfig.Current;
		if (current == null)
		{
			return false;
		}
		return current.Config?.System?.AutoUpdate == true;
	}

	public static void KkHLyG7lhV(bool P_0)
	{
		_G_c__DisplayClass6_0 CS_8_locals_2 = new _G_c__DisplayClass6_0();
		CS_8_locals_2.flag = P_0;
		TableBorderConfig.Instance.UpdateConfig(delegate(AiHelper_12 c)
		{
			c.System = c.System ?? new Helper_18();
			c.System.AutoUpdate = CS_8_locals_2.flag;
		});
	}

	private static HttpHelper_1 DpNLX6EZ8H(JObject P_0)
	{
		JToken jToken = P_0?["data"]?["attributes"];
		if (jToken == null)
		{
			return null;
		}
		string text = jToken.Value<string>("downloadUrl");
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "https://www.cgzcpa.com/article/73";
		}
		return new HttpHelper_1
		{
			Name = jToken.Value<string>("name"),
			VersionText = jToken.Value<string>("version"),
			ReleaseDate = jToken.Value<string>("date"),
			Description = jToken.Value<string>("description"),
			DownloadUrl = text.Trim()
		};
	}
}
