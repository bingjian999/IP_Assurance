using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AiConfigBootstrap;
using AiSseStreamService3;
using SseStreamInitializer;
using Newtonsoft.Json;
using AiSseStreamService;
using AiHelper_12;

namespace TableBorderConfig;

internal sealed class TableBorderConfig
{
	private static readonly Lazy<TableBorderConfig> _instance;

	private AiHelper_12 _configData;

	private string _configPath;

	private readonly object _configLock;

	public static TableBorderConfig Current => _instance.Value;

	public static TableBorderConfig Instance => _instance.Value;

	public string ConfigPath => _configPath ?? AiSseStreamService.MainConfigFilePath;

	public AiHelper_12 Config
	{
		get
		{
			lock (_configLock)
			{
				return _configData;
			}
		}
	}

	public Dictionary<string, object> Data
	{
		get
		{
			lock (_configLock)
			{
				return _configData.Legacy;
			}
		}
	}

	public wSx55RS7lsLReJ1W8jr mZ2Sn1wU53<wSx55RS7lsLReJ1W8jr>(Func<AiHelper_12, wSx55RS7lsLReJ1W8jr> P_0)
	{
		lock (_configLock)
		{
			return P_0(_configData);
		}
	}

	public void UpdateConfig(Action<AiHelper_12> P_0, bool P_1 = true)
	{
		if (P_0 == null)
		{
			return;
		}
		lock (_configLock)
		{
			P_0(_configData);
			_configData.BkGt8QpMWu();
			if (P_1)
			{
				PersistConfig();
			}
		}
	}

	public Dictionary<string, object> GetAllLegacy()
	{
		lock (_configLock)
		{
			return (_configData?.Legacy == null) ? new Dictionary<string, object>() : new Dictionary<string, object>(_configData.Legacy);
		}
	}

	public void SetAllLegacy(Dictionary<string, object> P_0, bool P_1 = true)
	{
		lock (_configLock)
		{
			_configData.Legacy = P_0 ?? new Dictionary<string, object>();
			ValidateConfig(_configData);
			if (P_1)
			{
				PersistConfig();
			}
		}
	}

	public void SetValue(string P_0, object P_1, bool P_2 = true)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return;
		}
		lock (_configLock)
		{
			if (_configData.Legacy == null)
			{
				_configData.Legacy = new Dictionary<string, object>();
			}
			_configData.Legacy[P_0] = P_1;
			if (P_2)
			{
				PersistConfig();
			}
		}
	}

	public string GetString(string P_0, string P_1 = "")
	{
		lock (_configLock)
		{
			if (_configData?.Legacy != null && _configData.Legacy.TryGetValue(P_0, out var value) && value != null)
			{
				return value.ToString();
			}
			return P_1;
		}
	}

	public double GetDouble(string P_0, double P_1 = 0.0)
	{
		if (double.TryParse(GetString(P_0, null), out var result))
		{
			return result;
		}
		return P_1;
	}

	public int GetInt(string P_0, int P_1 = 0)
	{
		string s = GetString(P_0, null);
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
			AiSseStreamService.EnsureAllDirectories();
			_configPath = AiSseStreamService.MainConfigFilePath;
			if (!File.Exists(_configPath))
			{
				_configData = bm6SAF0HvB();
				PersistConfig();
			}
			SaveToFile();
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[Config] Initialize failed", ex);
		}
	}

	public void SaveToFile()
	{
		try
		{
			if (!string.IsNullOrEmpty(_configPath) && File.Exists(_configPath))
			{
				AiHelper_12 nKy3wjtTwmsradOXPDy = JsonConvert.DeserializeObject<AiHelper_12>(File.ReadAllText(_configPath, Encoding.UTF8)) ?? new AiHelper_12();
				nKy3wjtTwmsradOXPDy.BkGt8QpMWu();
				bool flag = ValidateConfig(nKy3wjtTwmsradOXPDy);
				lock (_configLock)
				{
					_configData = nKy3wjtTwmsradOXPDy;
				}
				if (flag)
				{
					PersistConfig();
				}
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[Config] Reload failed", ex);
		}
	}

	public void PersistConfig()
	{
		try
		{
			lock (_configLock)
			{
				_configData.BkGt8QpMWu();
				string contents = JsonConvert.SerializeObject(_configData, Formatting.Indented);
				File.WriteAllText(_configPath, contents, Encoding.UTF8);
			}
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("[Config] Save failed", ex);
		}
	}

	private static AiHelper_12 bm6SAF0HvB()
	{
		AiHelper_12 nKy3wjtTwmsradOXPDy = new AiHelper_12();
		nKy3wjtTwmsradOXPDy.BkGt8QpMWu();
		try
		{
			string legacyConfigFilePath = AiSseStreamService.LegacyConfigFilePath;
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
			AiConfigBootstrap.LogWarn("[Config] Legacy config migration skipped: " + ex.Message);
		}
		ValidateConfig(nKy3wjtTwmsradOXPDy);
		return nKy3wjtTwmsradOXPDy;
	}

	private static bool ValidateConfig(AiHelper_12 P_0)
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
			AiConfigBootstrap.LogWarn("[Config] Initialize failed" + ex.Message);
			return new Dictionary<string, object>();
		}
	}

	public TableBorderConfig()
	{
		SseStreamInitializer.InitializeRuntime();
		_configData = new AiHelper_12();
		_configPath = AiSseStreamService.MainConfigFilePath;
		_configLock = new object();
	}

	static TableBorderConfig()
	{
		SseStreamInitializer.InitializeRuntime();
		_instance = new Lazy<TableBorderConfig>(() => new TableBorderConfig());
	}
}
