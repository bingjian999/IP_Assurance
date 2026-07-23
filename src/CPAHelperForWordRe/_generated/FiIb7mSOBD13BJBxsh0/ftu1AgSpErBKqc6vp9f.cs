using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using dL7TFPsQbAGqPywtHUK;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;
using Newtonsoft.Json;
using qDDKriLz2Bft1Ehv17i;
using t5EreDtgt3Im6sTEmsd;

namespace FiIb7mSOBD13BJBxsh0;

internal sealed class ftu1AgSpErBKqc6vp9f
{
	private static readonly Lazy<ftu1AgSpErBKqc6vp9f> EsoSkPa5xe;

	private NKy3wjtTwmsradOXPDy NeMSxdgZVf;

	private string ygUSdyrv11;

	private readonly object S2JSzFMl3n;

	public static ftu1AgSpErBKqc6vp9f Current => EsoSkPa5xe.Value;

	public static ftu1AgSpErBKqc6vp9f Instance => EsoSkPa5xe.Value;

	public string ConfigPath => ygUSdyrv11 ?? W6xTwMLd5RvSHoqDfEV.MainConfigFilePath;

	public NKy3wjtTwmsradOXPDy Config
	{
		get
		{
			lock (S2JSzFMl3n)
			{
				return NeMSxdgZVf;
			}
		}
	}

	public Dictionary<string, object> Data
	{
		get
		{
			lock (S2JSzFMl3n)
			{
				return NeMSxdgZVf.Legacy;
			}
		}
	}

	public wSx55RS7lsLReJ1W8jr mZ2Sn1wU53<wSx55RS7lsLReJ1W8jr>(Func<NKy3wjtTwmsradOXPDy, wSx55RS7lsLReJ1W8jr> P_0)
	{
		lock (S2JSzFMl3n)
		{
			return P_0(NeMSxdgZVf);
		}
	}

	public void wpmS5yUw9A(Action<NKy3wjtTwmsradOXPDy> P_0, bool P_1 = true)
	{
		if (P_0 == null)
		{
			return;
		}
		lock (S2JSzFMl3n)
		{
			P_0(NeMSxdgZVf);
			NeMSxdgZVf.BkGt8QpMWu();
			if (P_1)
			{
				cPLSPKGCNb();
			}
		}
	}

	public Dictionary<string, object> dnEScXBL9Y()
	{
		lock (S2JSzFMl3n)
		{
			return (NeMSxdgZVf?.Legacy == null) ? new Dictionary<string, object>() : new Dictionary<string, object>(NeMSxdgZVf.Legacy);
		}
	}

	public void TTVSewUqXZ(Dictionary<string, object> P_0, bool P_1 = true)
	{
		lock (S2JSzFMl3n)
		{
			NeMSxdgZVf.Legacy = P_0 ?? new Dictionary<string, object>();
			viUSvQ8ndh(NeMSxdgZVf);
			if (P_1)
			{
				cPLSPKGCNb();
			}
		}
	}

	public void pE1SyAiPWc(string P_0, object P_1, bool P_2 = true)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return;
		}
		lock (S2JSzFMl3n)
		{
			if (NeMSxdgZVf.Legacy == null)
			{
				NeMSxdgZVf.Legacy = new Dictionary<string, object>();
			}
			NeMSxdgZVf.Legacy[P_0] = P_1;
			if (P_2)
			{
				cPLSPKGCNb();
			}
		}
	}

	public string KxPSXHwy4c(string P_0, string P_1 = "")
	{
		lock (S2JSzFMl3n)
		{
			if (NeMSxdgZVf?.Legacy != null && NeMSxdgZVf.Legacy.TryGetValue(P_0, out var value) && value != null)
			{
				return value.ToString();
			}
			return P_1;
		}
	}

	public double hB5SFqa39l(string P_0, double P_1 = 0.0)
	{
		if (double.TryParse(KxPSXHwy4c(P_0, null), out var result))
		{
			return result;
		}
		return P_1;
	}

	public int HYsSh2NDxY(string P_0, int P_1 = 0)
	{
		string s = KxPSXHwy4c(P_0, null);
		if (int.TryParse(s, out var result))
		{
			return result;
		}
		if (double.TryParse(s, out var result2))
		{
			return (int)result2;
		}
		return P_1;
	}

	public void GZ2SaDxkVl()
	{
		try
		{
			W6xTwMLd5RvSHoqDfEV.c6JsBBJkO2();
			ygUSdyrv11 = W6xTwMLd5RvSHoqDfEV.MainConfigFilePath;
			if (!File.Exists(ygUSdyrv11))
			{
				NeMSxdgZVf = bm6SAF0HvB();
				cPLSPKGCNb();
			}
			m15SqmKUa9();
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[Config] Initialize failed", ex);
		}
	}

	public void m15SqmKUa9()
	{
		try
		{
			if (!string.IsNullOrEmpty(ygUSdyrv11) && File.Exists(ygUSdyrv11))
			{
				NKy3wjtTwmsradOXPDy nKy3wjtTwmsradOXPDy = JsonConvert.DeserializeObject<NKy3wjtTwmsradOXPDy>(File.ReadAllText(ygUSdyrv11, Encoding.UTF8)) ?? new NKy3wjtTwmsradOXPDy();
				nKy3wjtTwmsradOXPDy.BkGt8QpMWu();
				bool flag = viUSvQ8ndh(nKy3wjtTwmsradOXPDy);
				lock (S2JSzFMl3n)
				{
					NeMSxdgZVf = nKy3wjtTwmsradOXPDy;
				}
				if (flag)
				{
					cPLSPKGCNb();
				}
			}
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[Config] Reload failed", ex);
		}
	}

	public void cPLSPKGCNb()
	{
		try
		{
			lock (S2JSzFMl3n)
			{
				NeMSxdgZVf.BkGt8QpMWu();
				string contents = JsonConvert.SerializeObject(NeMSxdgZVf, Formatting.Indented);
				File.WriteAllText(ygUSdyrv11, contents, Encoding.UTF8);
			}
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.ujWsURly3F("[Config] Save failed", ex);
		}
	}

	private static NKy3wjtTwmsradOXPDy bm6SAF0HvB()
	{
		NKy3wjtTwmsradOXPDy nKy3wjtTwmsradOXPDy = new NKy3wjtTwmsradOXPDy();
		nKy3wjtTwmsradOXPDy.BkGt8QpMWu();
		try
		{
			string legacyConfigFilePath = W6xTwMLd5RvSHoqDfEV.LegacyConfigFilePath;
			if (File.Exists(legacyConfigFilePath))
			{
				Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(legacyConfigFilePath, Encoding.UTF8));
				if (dictionary != null)
				{
					nKy3wjtTwmsradOXPDy.Legacy = dictionary;
				}
			}
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[Config] Legacy config migration skipped: " + ex.Message);
		}
		viUSvQ8ndh(nKy3wjtTwmsradOXPDy);
		return nKy3wjtTwmsradOXPDy;
	}

	private static bool viUSvQ8ndh(NKy3wjtTwmsradOXPDy P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.Legacy == null)
		{
			P_0.Legacy = new Dictionary<string, object>();
		}
		bool flag = false;
		flag |= OutSW34unI(P_0.Legacy);
		foreach (KeyValuePair<string, object> item in SLGS0RVi41())
		{
			if (!P_0.Legacy.ContainsKey(item.Key))
			{
				P_0.Legacy[item.Key] = item.Value;
				flag = true;
			}
		}
		return flag;
	}

	private static bool OutSW34unI(Dictionary<string, object> P_0)
	{
		bool result = false;
		if (!P_0.ContainsKey("表格_边框样式_合计行下边框线") && P_0.TryGetValue("表格_边框样式_表尾底边框线", out var value))
		{
			P_0["表格_边框样式_合计行下边框线"] = value;
			result = true;
		}
		if (!P_0.ContainsKey("表格_边框粗细_合计行下边框线") && P_0.TryGetValue("表格_边框粗细_表尾底边框线", out var value2))
		{
			P_0["表格_边框粗细_合计行下边框线"] = value2;
			result = true;
		}
		return result;
	}

	private static Dictionary<string, object> SLGS0RVi41()
	{
		try
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string text = executingAssembly.GetManifestResourceNames().FirstOrDefault((string name) => name.EndsWith("[Config] Default legacy config load skipped: ", StringComparison.OrdinalIgnoreCase));
			if (string.IsNullOrWhiteSpace(text))
			{
				return new Dictionary<string, object>();
			}
			using Stream stream = executingAssembly.GetManifestResourceStream(text);
			using StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
			return JsonConvert.DeserializeObject<Dictionary<string, object>>(streamReader.ReadToEnd()) ?? new Dictionary<string, object>();
		}
		catch (Exception ex)
		{
			yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[Config] Initialize failed" + ex.Message);
			return new Dictionary<string, object>();
		}
	}

	public ftu1AgSpErBKqc6vp9f()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		NeMSxdgZVf = new NKy3wjtTwmsradOXPDy();
		ygUSdyrv11 = W6xTwMLd5RvSHoqDfEV.MainConfigFilePath;
		S2JSzFMl3n = new object();
	}

	static ftu1AgSpErBKqc6vp9f()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		EsoSkPa5xe = new Lazy<ftu1AgSpErBKqc6vp9f>(() => new ftu1AgSpErBKqc6vp9f());
	}
}
