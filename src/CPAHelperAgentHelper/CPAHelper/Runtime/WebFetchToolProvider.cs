using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Abstractions;
using Microsoft.Extensions.AI;
using Newtonsoft.Json;

namespace CPAHelper.Agent.Runtime;

public sealed class WebFetchToolProvider : IToolProvider
{
	private sealed class WebFetchResponse
	{
		public Uri FinalUri { get; set; }

		public HttpStatusCode StatusCode { get; set; }

		public string ContentType { get; set; }

		public byte[] Bytes { get; set; }
	}

	internal const int DefaultMaxChars = 20000;

	internal const int HardMaxChars = 50000;

	internal const int MaxResponseBytes = 2097152;

	private const int TimeoutSeconds = 15;

	private const int MaxRedirects = 5;

	private const int MinimumDelayMilliseconds = 1000;

	private static readonly SemaphoreSlim RateLimitLock = new SemaphoreSlim(1, 1);

	private static DateTimeOffset _lastRequestAt = DateTimeOffset.MinValue;

	public string ProviderName => "WebFetch";

	public IList<AITool> GetTools()
	{
		MethodInfo method = GetType().GetMethod("WebFetch", BindingFlags.Instance | BindingFlags.NonPublic);
		return new List<AITool> { AIFunctionFactory.Create(method, this, new AIFunctionFactoryOptions
		{
			Name = "web_fetch",
			Description = "Fetch a public HTTP/HTTPS URL and return cleaned text content. Only public web URLs on ports 80/443 are allowed; localhost and private network addresses are blocked."
		}) };
	}

	public IList<ToolMetadata> GetToolMetadata()
	{
		List<ToolMetadata> list = new List<ToolMetadata>();
		list.Add(new ToolMetadata("web_fetch", new string[3] { "web", "network", "read" }, "Fetch a public HTTP/HTTPS URL and return cleaned text content.", isDefault: true));
		return list;
	}

	[Description("Fetch a public HTTP/HTTPS URL and return cleaned text content.")]
	private async Task<string> WebFetch([Description("The public HTTP/HTTPS URL to fetch.")] string url, [Description("Optional maximum number of text characters to return.")] int? maxChars = null)
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		try
		{
			Uri requestedUri = await ValidatePublicHttpUriAsync(url).ConfigureAwait(continueOnCapturedContext: false);
			int outputLimit = ResolveMaxChars(maxChars);
			HttpClientHandler handler = CreateHandler();
			try
			{
				HttpClient client = CreateClient((HttpMessageHandler)(object)handler);
				try
				{
					WebFetchResponse webFetchResponse = await FetchWithRedirectsAsync(client, requestedUri).ConfigureAwait(continueOnCapturedContext: false);
					if (webFetchResponse.StatusCode == HttpStatusCode.Forbidden || webFetchResponse.StatusCode == (HttpStatusCode)429)
					{
						await FetchHomepageForCookiesAsync(client, webFetchResponse.FinalUri).ConfigureAwait(continueOnCapturedContext: false);
						await Task.Delay(TimeSpan.FromSeconds(2.0)).ConfigureAwait(continueOnCapturedContext: false);
						webFetchResponse = await FetchWithRedirectsAsync(client, requestedUri).ConfigureAwait(continueOnCapturedContext: false);
					}
					stopwatch.Stop();
					return ToJson(BuildSuccessResult(url, webFetchResponse, outputLimit, stopwatch.Elapsed));
				}
				finally
				{
					((IDisposable)client)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)handler)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			stopwatch.Stop();
			return ToJson(new
			{
				ok = false,
				url = (url ?? string.Empty),
				error = ex.Message,
				durationMs = (int)stopwatch.Elapsed.TotalMilliseconds
			});
		}
	}

	internal static async Task<Uri> ValidatePublicHttpUriAsync(string url)
	{
		if (string.IsNullOrWhiteSpace(url))
		{
			throw new InvalidOperationException("URL is empty.");
		}
		if (!Uri.TryCreate(url.Trim(), UriKind.Absolute, out var uri))
		{
			throw new InvalidOperationException("URL must be absolute.");
		}
		await ValidatePublicHttpUriAsync(uri).ConfigureAwait(continueOnCapturedContext: false);
		return uri;
	}

	internal static async Task ValidatePublicHttpUriAsync(Uri uri)
	{
		if (uri == null || !uri.IsAbsoluteUri)
		{
			throw new InvalidOperationException("URL must be absolute.");
		}
		string text = uri.Scheme?.ToLowerInvariant();
		if (text != Uri.UriSchemeHttp && text != Uri.UriSchemeHttps)
		{
			throw new InvalidOperationException("Only http and https URLs are allowed.");
		}
		if (!uri.IsDefaultPort && uri.Port != 80 && uri.Port != 443)
		{
			throw new InvalidOperationException("Only default, 80, and 443 ports are allowed.");
		}
		string text2 = (uri.DnsSafeHost ?? string.Empty).Trim().TrimEnd('.');
		if (string.IsNullOrWhiteSpace(text2))
		{
			throw new InvalidOperationException("URL host is empty.");
		}
		if (string.Equals(text2, "localhost", StringComparison.OrdinalIgnoreCase) || text2.EndsWith(".localhost", StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException("Localhost URLs are not allowed.");
		}
		if (IPAddress.TryParse(text2, out var address))
		{
			ValidatePublicIpAddress(address);
			return;
		}
		IPAddress[] array;
		try
		{
			array = await Dns.GetHostAddressesAsync(text2).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (SocketException ex)
		{
			throw new InvalidOperationException("URL host could not be resolved: " + ex.Message);
		}
		if (array == null || array.Length == 0)
		{
			throw new InvalidOperationException("URL host did not resolve to any address.");
		}
		IPAddress[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			ValidatePublicIpAddress(array2[i]);
		}
	}

	internal static void ValidatePublicIpAddress(IPAddress address)
	{
		if (address == null)
		{
			throw new InvalidOperationException("Resolved IP address is empty.");
		}
		if (address.IsIPv4MappedToIPv6)
		{
			address = address.MapToIPv4();
		}
		if (IPAddress.IsLoopback(address))
		{
			throw new InvalidOperationException("Loopback addresses are not allowed.");
		}
		if (address.AddressFamily == AddressFamily.InterNetwork)
		{
			byte[] addressBytes = address.GetAddressBytes();
			if (addressBytes[0] == 10 || addressBytes[0] == 127 || (addressBytes[0] == 172 && addressBytes[1] >= 16 && addressBytes[1] <= 31) || (addressBytes[0] == 192 && addressBytes[1] == 168) || (addressBytes[0] == 169 && addressBytes[1] == 254) || addressBytes[0] == 0 || addressBytes[0] >= 224)
			{
				throw new InvalidOperationException("Private, local, multicast, or unspecified addresses are not allowed.");
			}
		}
		else if (address.AddressFamily == AddressFamily.InterNetworkV6)
		{
			if (address.IsIPv6LinkLocal || address.IsIPv6Multicast || address.IsIPv6SiteLocal || address.Equals(IPAddress.IPv6Any) || address.Equals(IPAddress.IPv6Loopback) || address.Equals(IPAddress.IPv6None))
			{
				throw new InvalidOperationException("Private, local, multicast, or unspecified addresses are not allowed.");
			}
			if ((address.GetAddressBytes()[0] & 0xFE) == 252)
			{
				throw new InvalidOperationException("Private IPv6 addresses are not allowed.");
			}
		}
	}

	internal static string ExtractReadableText(string contentType, byte[] bytes, int maxChars, out string title, out bool truncated)
	{
		title = string.Empty;
		truncated = false;
		if (bytes == null || bytes.Length == 0)
		{
			return string.Empty;
		}
		string text = DecodeBytes(contentType, bytes);
		if (IsHtml(contentType))
		{
			title = ExtractTitle(text);
			text = CleanHtml(text);
		}
		else if (!IsTextLike(contentType))
		{
			text = SanitizeBinaryPreview(text);
		}
		if (text.Length > maxChars)
		{
			truncated = true;
			text = text.Substring(0, maxChars);
		}
		return text;
	}

	private static async Task<WebFetchResponse> FetchWithRedirectsAsync(HttpClient client, Uri initialUri)
	{
		Uri current = initialUri;
		for (int redirectCount = 0; redirectCount <= 5; redirectCount++)
		{
			await ValidatePublicHttpUriAsync(current).ConfigureAwait(continueOnCapturedContext: false);
			await WaitForRateLimitAsync().ConfigureAwait(continueOnCapturedContext: false);
			HttpRequestMessage request = CreateRequest(current);
			try
			{
				HttpResponseMessage response = await client.SendAsync(request, (HttpCompletionOption)1).ConfigureAwait(continueOnCapturedContext: false);
				try
				{
					if (IsRedirect(response.StatusCode))
					{
						if (redirectCount == 5)
						{
							throw new InvalidOperationException("Too many redirects.");
						}
						Uri location = response.Headers.Location;
						current = await ResolveAndValidateRedirectAsync(current, location).ConfigureAwait(continueOnCapturedContext: false);
						continue;
					}
					byte[] bytes = await ReadLimitedBytesAsync(response.Content).ConfigureAwait(continueOnCapturedContext: false);
					return new WebFetchResponse
					{
						FinalUri = current,
						StatusCode = response.StatusCode,
						ContentType = (((object)response.Content.Headers.ContentType)?.ToString() ?? string.Empty),
						Bytes = bytes
					};
				}
				finally
				{
					((IDisposable)response)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)request)?.Dispose();
			}
		}
		throw new InvalidOperationException("Too many redirects.");
	}

	internal static async Task<Uri> ResolveAndValidateRedirectAsync(Uri currentUri, Uri location)
	{
		if (location == null)
		{
			throw new InvalidOperationException("Redirect response did not include a Location header.");
		}
		Uri redirectedUri = (location.IsAbsoluteUri ? location : new Uri(currentUri, location));
		await ValidatePublicHttpUriAsync(redirectedUri).ConfigureAwait(continueOnCapturedContext: false);
		return redirectedUri;
	}

	private static async Task FetchHomepageForCookiesAsync(HttpClient client, Uri finalUri)
	{
		if (finalUri == null)
		{
			return;
		}
		UriBuilder uriBuilder = new UriBuilder(finalUri.Scheme, finalUri.Host, finalUri.Port, "/");
		try
		{
			await FetchWithRedirectsAsync(client, uriBuilder.Uri).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch
		{
		}
	}

	private static HttpClientHandler CreateHandler()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		return new HttpClientHandler
		{
			AllowAutoRedirect = false,
			AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate),
			CookieContainer = new CookieContainer(),
			UseCookies = true
		};
	}

	private static HttpClient CreateClient(HttpMessageHandler handler)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		return new HttpClient(handler)
		{
			Timeout = TimeSpan.FromSeconds(15.0)
		};
	}

	private static HttpRequestMessage CreateRequest(Uri uri)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		HttpRequestMessage val = new HttpRequestMessage(HttpMethod.Get, uri);
		val.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) CPAHelperAgentHelper/1.0");
		val.Headers.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,text/plain;q=0.8,*/*;q=0.5");
		val.Headers.AcceptLanguage.ParseAdd("zh-CN,zh;q=0.9,en;q=0.8");
		return val;
	}

	private static async Task<byte[]> ReadLimitedBytesAsync(HttpContent content)
	{
		using Stream stream = await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
		using MemoryStream memory = new MemoryStream();
		byte[] buffer = new byte[8192];
		while (true)
		{
			int num = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(continueOnCapturedContext: false);
			if (num == 0)
			{
				break;
			}
			if (memory.Length + num > 2097152)
			{
				int num2 = 2097152 - (int)memory.Length;
				if (num2 > 0)
				{
					memory.Write(buffer, 0, num2);
				}
				break;
			}
			memory.Write(buffer, 0, num);
		}
		return memory.ToArray();
	}

	private static object BuildSuccessResult(string requestedUrl, WebFetchResponse response, int maxChars, TimeSpan duration)
	{
		string title;
		bool truncated;
		string text = ExtractReadableText(response.ContentType, response.Bytes, maxChars, out title, out truncated);
		bool flag = response.Bytes != null && response.Bytes.Length >= 2097152;
		return new
		{
			ok = true,
			url = (requestedUrl ?? string.Empty),
			finalUrl = (response.FinalUri?.AbsoluteUri ?? string.Empty),
			statusCode = (int)response.StatusCode,
			contentType = (response.ContentType ?? string.Empty),
			title = title,
			text = text,
			truncated = (truncated || flag),
			durationMs = (int)duration.TotalMilliseconds
		};
	}

	private static int ResolveMaxChars(int? maxChars)
	{
		if (!maxChars.HasValue || maxChars.Value <= 0)
		{
			return 20000;
		}
		return Math.Min(maxChars.Value, 50000);
	}

	private static bool IsRedirect(HttpStatusCode statusCode)
	{
		if (statusCode >= HttpStatusCode.MultipleChoices)
		{
			return statusCode <= (HttpStatusCode)399;
		}
		return false;
	}

	private static async Task WaitForRateLimitAsync()
	{
		await RateLimitLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			TimeSpan timeSpan = TimeSpan.FromMilliseconds(1000.0) - (utcNow - _lastRequestAt);
			if (timeSpan > TimeSpan.Zero)
			{
				await Task.Delay(timeSpan).ConfigureAwait(continueOnCapturedContext: false);
			}
			_lastRequestAt = DateTimeOffset.UtcNow;
		}
		finally
		{
			RateLimitLock.Release();
		}
	}

	private static string DecodeBytes(string contentType, byte[] bytes)
	{
		return (ResolveEncoding(contentType) ?? Encoding.UTF8).GetString(bytes);
	}

	private static Encoding ResolveEncoding(string contentType)
	{
		if (string.IsNullOrWhiteSpace(contentType))
		{
			return null;
		}
		Match match = Regex.Match(contentType, "charset\\s*=\\s*[\"']?([^;\"']+)", RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return null;
		}
		try
		{
			return Encoding.GetEncoding(match.Groups[1].Value.Trim());
		}
		catch
		{
			return null;
		}
	}

	private static bool IsHtml(string contentType)
	{
		if (!string.IsNullOrWhiteSpace(contentType))
		{
			return contentType.IndexOf("html", StringComparison.OrdinalIgnoreCase) >= 0;
		}
		return false;
	}

	private static bool IsTextLike(string contentType)
	{
		if (string.IsNullOrWhiteSpace(contentType))
		{
			return true;
		}
		if (!contentType.StartsWith("text/", StringComparison.OrdinalIgnoreCase) && contentType.IndexOf("json", StringComparison.OrdinalIgnoreCase) < 0 && contentType.IndexOf("xml", StringComparison.OrdinalIgnoreCase) < 0)
		{
			return contentType.IndexOf("javascript", StringComparison.OrdinalIgnoreCase) >= 0;
		}
		return true;
	}

	private static string ExtractTitle(string html)
	{
		Match match = Regex.Match(html ?? string.Empty, "<title[^>]*>(.*?)</title>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
		if (!match.Success)
		{
			return string.Empty;
		}
		return NormalizeWhitespace(WebUtility.HtmlDecode(match.Groups[1].Value));
	}

	private static string CleanHtml(string html)
	{
		return NormalizeWhitespace(WebUtility.HtmlDecode(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(html ?? string.Empty, "<\\s*(script|style|noscript|svg)\\b[^>]*>.*?<\\s*/\\s*\\1\\s*>", " ", RegexOptions.IgnoreCase | RegexOptions.Singleline), "<!--.*?-->", " ", RegexOptions.Singleline), "</?(p|div|section|article|header|footer|main|aside|nav|br|li|ul|ol|h[1-6]|tr|table|blockquote)\\b[^>]*>", "\n", RegexOptions.IgnoreCase), "<[^>]+>", " ")));
	}

	private static string SanitizeBinaryPreview(string text)
	{
		text = text ?? string.Empty;
		StringBuilder stringBuilder = new StringBuilder();
		string text2 = text;
		foreach (char c in text2)
		{
			if (c == '\r' || c == '\n' || c == '\t' || !char.IsControl(c))
			{
				stringBuilder.Append(c);
			}
			if (stringBuilder.Length >= 1000)
			{
				break;
			}
		}
		return NormalizeWhitespace(stringBuilder.ToString());
	}

	private static string NormalizeWhitespace(string value)
	{
		value = value ?? string.Empty;
		value = value.Replace("\r\n", "\n").Replace('\r', '\n');
		value = Regex.Replace(value, "[ \\t\\f\\v]+", " ");
		value = Regex.Replace(value, "\\s+([,.;:!?])", "$1");
		value = Regex.Replace(value, " *\\n *", "\n");
		value = Regex.Replace(value, "\\n{3,}", "\n\n");
		return value.Trim();
	}

	private static string ToJson(object value)
	{
		return JsonConvert.SerializeObject(value);
	}
}
