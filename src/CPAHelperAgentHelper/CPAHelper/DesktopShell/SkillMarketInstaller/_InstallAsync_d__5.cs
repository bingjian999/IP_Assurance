using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Contracts;
using CPAHelper.Agent.Runtime;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class SkillMarketInstaller
{
	private sealed class SkillInstallManifest
	{
		public string Source { get; set; }

		public string Slug { get; set; }

		public string Name { get; set; }

		public string InstalledName { get; set; }

		public string Version { get; set; }

		public string ArchiveUrl { get; set; }

		public DateTimeOffset InstalledAt { get; set; }
	}

	private const int MaxFileCount = 300;

	private const long MaxArchiveBytes = 20971520L;

	private const long MaxExpandedBytes = 62914560L;

	private static readonly HttpClient HttpClient = new HttpClient
	{
		Timeout = TimeSpan.FromSeconds(45.0)
	};

	private static readonly Regex WhitespaceRegex = new Regex("\\s+", RegexOptions.Compiled);

	public async Task<SkillInstallResponse> InstallAsync(SkillInstallRequest request, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (request == null)
		{
			throw new InvalidOperationException("Install request is required.");
		}
		string skillsDirectory = AgentRuntime.EnsureSkillsPath();
		string tempRoot = Path.Combine(Path.GetTempPath(), "CPAHelperSkillInstall", Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(tempRoot);
		try
		{
			string text;
			if (!string.IsNullOrWhiteSpace(request.ArchiveUrl))
			{
				text = await DownloadAndExtractAsync(request.ArchiveUrl, tempRoot, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				if (string.IsNullOrWhiteSpace(request.SkillMd))
				{
					throw new InvalidOperationException("archiveUrl or skillMd is required.");
				}
				text = CreateSkillMdDirectory(request, tempRoot);
			}
			string text2 = FindSkillFile(text);
			if (text2 == null)
			{
				throw new InvalidOperationException("The skill package must contain SKILL.md.");
			}
			string text3 = ResolveInstallSourceDirectory(text, text2);
			string text4 = SanitizeSkillDirectoryName(ReadSkillFrontMatterName(text2)) ?? SanitizeSkillDirectoryName(request.Name) ?? SanitizeSkillDirectoryName(Path.GetFileName(text3)) ?? SanitizeSkillDirectoryName(request.Slug) ?? ("skill-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"));
			string text5 = Path.Combine(skillsDirectory, text4);
			string manifestPath = Path.Combine(text5, ".cpahelper-skill-install.json");
			SkillInstallManifest skillInstallManifest = ReadManifest(manifestPath);
			bool flag = Directory.Exists(text5);
			string text6 = null;
			string text7 = (string.IsNullOrWhiteSpace(request.Version) ? null : request.Version.Trim());
			if (Directory.Exists(text5) && skillInstallManifest != null && string.Equals(skillInstallManifest.Version, text7, StringComparison.OrdinalIgnoreCase))
			{
				return new SkillInstallResponse
				{
					Success = true,
					Status = "alreadyInstalled",
					Name = text4,
					Version = text7,
					Path = text5,
					Message = "Skill is already installed."
				};
			}
			if (flag)
			{
				text6 = text5 + ".bak-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
				Directory.Move(text5, text6);
			}
			try
			{
				CopyDirectory(text3, text5);
				WriteManifest(manifestPath, request, text4);
			}
			catch
			{
				TryDeleteDirectory(text5);
				if (!string.IsNullOrWhiteSpace(text6) && Directory.Exists(text6) && !Directory.Exists(text5))
				{
					Directory.Move(text6, text5);
				}
				throw;
			}
			return new SkillInstallResponse
			{
				Success = true,
				Status = (flag ? "updated" : "installed"),
				Name = text4,
				Version = text7,
				Path = text5,
				Message = ((skillInstallManifest == null) ? "Skill installed." : "Skill updated.")
			};
		}
		finally
		{
			TryDeleteDirectory(tempRoot);
		}
	}

	private static async Task<string> DownloadAndExtractAsync(string archiveUrl, string tempRoot, CancellationToken cancellationToken)
	{
		Uri uri = ValidateArchiveUri(archiveUrl);
		string archivePath = Path.Combine(tempRoot, "skill.zip");
		HttpResponseMessage response = await HttpClient.GetAsync(uri, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			response.EnsureSuccessStatusCode();
			long? contentLength = response.Content.Headers.ContentLength;
			if (contentLength.HasValue && contentLength.Value > 20971520)
			{
				throw new InvalidOperationException("Skill archive is too large.");
			}
			using Stream input = await response.Content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
			using FileStream output = File.Create(archivePath);
			await CopyWithLimitAsync(input, output, 20971520L, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			((IDisposable)response)?.Dispose();
		}
		string text = Path.Combine(tempRoot, "extract");
		Directory.CreateDirectory(text);
		ExtractZipSafely(archivePath, text);
		return text;
	}

	private static Uri ValidateArchiveUri(string archiveUrl)
	{
		if (!Uri.TryCreate(archiveUrl, UriKind.Absolute, out var result))
		{
			throw new InvalidOperationException("archiveUrl must be an absolute URL.");
		}
		if (!string.Equals(result.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException("Only HTTPS skill archive URLs are allowed.");
		}
		string text = result.Host.ToLowerInvariant();
		if (text != "www.cgzcpa.com" && text != "cgzcpa.com")
		{
			throw new InvalidOperationException("Only cgzcpa.com skill archives are allowed.");
		}
		return result;
	}

	private static async Task CopyWithLimitAsync(Stream input, Stream output, long maxBytes, CancellationToken cancellationToken)
	{
		byte[] buffer = new byte[81920];
		long total = 0L;
		int num;
		while ((num = await input.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)) > 0)
		{
			total += num;
			if (total > maxBytes)
			{
				throw new InvalidOperationException("Skill archive is too large.");
			}
			await output.WriteAsync(buffer, 0, num, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private static void ExtractZipSafely(string archivePath, string extractDirectory)
	{
		ZipArchive val = ZipFile.OpenRead(archivePath);
		try
		{
			if (val.Entries.Count > 300)
			{
				throw new InvalidOperationException("Skill archive contains too many files.");
			}
			long num = 0L;
			string text = Path.GetFullPath(extractDirectory);
			if (!text.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
			{
				text += Path.DirectorySeparatorChar;
			}
			foreach (ZipArchiveEntry entry in val.Entries)
			{
				string text2 = entry.FullName.Replace('\\', '/');
				if (!string.IsNullOrWhiteSpace(text2))
				{
					num += entry.Length;
					if (num > 62914560)
					{
						throw new InvalidOperationException("Skill archive expands to too much data.");
					}
					string fullPath = Path.GetFullPath(Path.Combine(extractDirectory, text2));
					if (!fullPath.StartsWith(text, StringComparison.OrdinalIgnoreCase))
					{
						throw new InvalidOperationException("Skill archive contains an unsafe path.");
					}
					if (text2.EndsWith("/", StringComparison.Ordinal))
					{
						Directory.CreateDirectory(fullPath);
						continue;
					}
					Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
					entry.ExtractToFile(fullPath, overwrite: true);
				}
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private static string CreateSkillMdDirectory(SkillInstallRequest request, string tempRoot)
	{
		string text = Path.Combine(tempRoot, "skill-md");
		Directory.CreateDirectory(text);
		File.WriteAllText(Path.Combine(text, "SKILL.md"), request.SkillMd, Encoding.UTF8);
		return text;
	}

	private static string FindSkillFile(string directory)
	{
		return (from path in Directory.GetFiles(directory, "SKILL.md", SearchOption.AllDirectories)
			orderby path.Length
			select path).FirstOrDefault();
	}

	private static string ResolveInstallSourceDirectory(string sourceDirectory, string skillFile)
	{
		string directoryName = Path.GetDirectoryName(skillFile);
		bool num = Directory.GetFiles(sourceDirectory).Any();
		string[] directories = Directory.GetDirectories(sourceDirectory);
		if (!num && directories.Length == 1)
		{
			return directories[0];
		}
		if (!string.Equals(directoryName, sourceDirectory, StringComparison.OrdinalIgnoreCase))
		{
			return directoryName;
		}
		return sourceDirectory;
	}

	private static string SanitizeSkillDirectoryName(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return null;
		}
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		StringBuilder stringBuilder = new StringBuilder(value.Trim().Length);
		string text = value.Trim();
		foreach (char c in text)
		{
			stringBuilder.Append(invalidFileNameChars.Contains(c) ? '-' : c);
		}
		string text2 = WhitespaceRegex.Replace(stringBuilder.ToString(), "-").Trim('.', '-', '_');
		if (string.IsNullOrWhiteSpace(text2))
		{
			return null;
		}
		if (IsReservedWindowsName(text2))
		{
			text2 = "_" + text2;
		}
		if (text2.Length <= 80)
		{
			return text2;
		}
		return text2.Substring(0, 80);
	}

	private static string ReadSkillFrontMatterName(string skillFile)
	{
		try
		{
			string[] array = File.ReadAllLines(skillFile, Encoding.UTF8);
			if (array.Length == 0 || !string.Equals(array[0].Trim(), "---", StringComparison.Ordinal))
			{
				return null;
			}
			for (int i = 1; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (!string.Equals(text, "---", StringComparison.Ordinal))
				{
					if (text.StartsWith("name:", StringComparison.OrdinalIgnoreCase))
					{
						string text2 = text.Substring("name:".Length).Trim().Trim('"', '\'');
						return string.IsNullOrWhiteSpace(text2) ? null : text2;
					}
					continue;
				}
				break;
			}
		}
		catch
		{
			return null;
		}
		return null;
	}

	private static bool IsReservedWindowsName(string value)
	{
		string text = value;
		int num = value.IndexOf('.');
		if (num >= 0)
		{
			text = value.Substring(0, num);
		}
		string text2 = text.ToUpperInvariant();
		if (text2 != null)
		{
			int length = text2.Length;
			if (length != 3)
			{
				if (length == 4)
				{
					switch (text2[3])
					{
					case '1':
						break;
					case '2':
						goto IL_0125;
					case '3':
						goto IL_014a;
					case '4':
						goto IL_016f;
					case '5':
						goto IL_0194;
					case '6':
						goto IL_01b0;
					case '7':
						goto IL_01cc;
					case '8':
						goto IL_01e8;
					case '9':
						goto IL_0204;
					default:
						goto IL_0220;
					}
					if (text2 == "COM1" || text2 == "LPT1")
					{
						goto IL_021e;
					}
				}
			}
			else
			{
				char c = text2[0];
				if ((uint)c <= 67u)
				{
					if (c != 'A')
					{
						if (c == 'C' && text2 == "CON")
						{
							goto IL_021e;
						}
					}
					else if (text2 == "AUX")
					{
						goto IL_021e;
					}
				}
				else if (c != 'N')
				{
					if (c == 'P' && text2 == "PRN")
					{
						goto IL_021e;
					}
				}
				else if (text2 == "NUL")
				{
					goto IL_021e;
				}
			}
		}
		goto IL_0220;
		IL_0204:
		if (text2 == "COM9" || text2 == "LPT9")
		{
			goto IL_021e;
		}
		goto IL_0220;
		IL_01e8:
		if (text2 == "COM8" || text2 == "LPT8")
		{
			goto IL_021e;
		}
		goto IL_0220;
		IL_0194:
		if (text2 == "COM5" || text2 == "LPT5")
		{
			goto IL_021e;
		}
		goto IL_0220;
		IL_0125:
		if (text2 == "COM2" || text2 == "LPT2")
		{
			goto IL_021e;
		}
		goto IL_0220;
		IL_016f:
		if (text2 == "COM4" || text2 == "LPT4")
		{
			goto IL_021e;
		}
		goto IL_0220;
		IL_021e:
		return true;
		IL_014a:
		if (text2 == "COM3" || text2 == "LPT3")
		{
			goto IL_021e;
		}
		goto IL_0220;
		IL_0220:
		return false;
		IL_01cc:
		if (text2 == "COM7" || text2 == "LPT7")
		{
			goto IL_021e;
		}
		goto IL_0220;
		IL_01b0:
		if (text2 == "COM6" || text2 == "LPT6")
		{
			goto IL_021e;
		}
		goto IL_0220;
	}

	private static SkillInstallManifest ReadManifest(string manifestPath)
	{
		try
		{
			if (!File.Exists(manifestPath))
			{
				return null;
			}
			return JsonSerializer.Deserialize<SkillInstallManifest>(File.ReadAllText(manifestPath, Encoding.UTF8));
		}
		catch
		{
			return null;
		}
	}

	private static void WriteManifest(string manifestPath, SkillInstallRequest request, string skillName)
	{
		string contents = JsonSerializer.Serialize(new SkillInstallManifest
		{
			Source = "cgzcpa.com",
			Slug = request.Slug,
			Name = request.Name,
			InstalledName = skillName,
			Version = (string.IsNullOrWhiteSpace(request.Version) ? null : request.Version.Trim()),
			ArchiveUrl = request.ArchiveUrl,
			InstalledAt = DateTimeOffset.Now
		}, new JsonSerializerOptions
		{
			WriteIndented = true
		});
		File.WriteAllText(manifestPath, contents, Encoding.UTF8);
	}

	private static void CopyDirectory(string sourceDirectory, string targetDirectory)
	{
		Directory.CreateDirectory(targetDirectory);
		string[] directories = Directory.GetDirectories(sourceDirectory, "*", SearchOption.AllDirectories);
		for (int i = 0; i < directories.Length; i++)
		{
			string path = directories[i].Substring(sourceDirectory.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			Directory.CreateDirectory(Path.Combine(targetDirectory, path));
		}
		directories = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories);
		foreach (string text in directories)
		{
			string path2 = text.Substring(sourceDirectory.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			string text2 = Path.Combine(targetDirectory, path2);
			Directory.CreateDirectory(Path.GetDirectoryName(text2));
			File.Copy(text, text2, overwrite: true);
		}
	}

	private static void TryDeleteDirectory(string directory)
	{
		try
		{
			if (Directory.Exists(directory))
			{
				Directory.Delete(directory, recursive: true);
			}
		}
		catch
		{
		}
	}
}
