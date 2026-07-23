using System;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cd59RULNsbZAAg3AwXt;
using FiIb7mSOBD13BJBxsh0;
using hJKpQrVSwRwMyI2RyDQN;
using LPV5Zit3IuD5JcHUFkw;
using ndRERvVtEjasqN2cQqiN;
using Newtonsoft.Json.Linq;
using P4BD1rLkpPbD4GJiVHK;
using t5EreDtgt3Im6sTEmsd;

namespace W3oCNxLnfOxdoFQL0mU;

internal static class jgKlnXLOdt7NkxsJ5rg
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass6_0
	{
		public bool FV0VEOPyELZ;

		public _G_c__DisplayClass6_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal void h9VVEpKGc4r(NKy3wjtTwmsradOXPDy c)
		{
			c.System = c.System ?? new hjDjw6tJ6NvPemlGtsT();
			c.System.AutoUpdate = FV0VEOPyELZ;
		}
	}

	public static string mVoL74rdRf()
	{
		Version version = Assembly.GetExecutingAssembly().GetName().Version;
		if (!(version != null))
		{
			return "0.0.0.0";
		}
		return version.ToString();
	}

	public static async Task<Rei3DhLlLQm1bCVIXFi> PJYL5bLAxq(bool P_0 = false)
	{
		try
		{
			KN3FylL0CcE4FxM6SF8.BNmLxKn8Mc();
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
		ftu1AgSpErBKqc6vp9f current = ftu1AgSpErBKqc6vp9f.Current;
		if (current == null)
		{
			return false;
		}
		return current.Config?.System?.AutoUpdate == true;
	}

	public static void KkHLyG7lhV(bool P_0)
	{
		_G_c__DisplayClass6_0 CS_8_locals_2 = new _G_c__DisplayClass6_0();
		CS_8_locals_2.FV0VEOPyELZ = P_0;
		ftu1AgSpErBKqc6vp9f.Instance.wpmS5yUw9A(delegate(NKy3wjtTwmsradOXPDy c)
		{
			c.System = c.System ?? new hjDjw6tJ6NvPemlGtsT();
			c.System.AutoUpdate = CS_8_locals_2.FV0VEOPyELZ;
		});
	}

	private static Rei3DhLlLQm1bCVIXFi DpNLX6EZ8H(JObject P_0)
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
		return new Rei3DhLlLQm1bCVIXFi
		{
			Name = jToken.Value<string>("name"),
			VersionText = jToken.Value<string>("version"),
			ReleaseDate = jToken.Value<string>("date"),
			Description = jToken.Value<string>("description"),
			DownloadUrl = text.Trim()
		};
	}
}
