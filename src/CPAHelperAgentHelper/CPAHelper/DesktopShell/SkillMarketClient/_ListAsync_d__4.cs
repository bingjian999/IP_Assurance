using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class SkillMarketClient : ISkillMarketClient
{
	private static readonly Uri BaseUri = new Uri("https://www.cgzcpa.com/api/skills");

	private readonly HttpClient _httpClient;

	public SkillMarketClient()
		: this(new HttpClient())
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)
	//IL_000b: Expected O, but got Unknown


	internal SkillMarketClient(HttpClient httpClient)
	{
		_httpClient = httpClient ?? throw new ArgumentNullException("httpClient");
		_httpClient.Timeout = TimeSpan.FromSeconds(18.0);
	}

	public async Task<SkillMarketResponse> ListAsync(SkillMarketQuery query)
	{
		query = NormalizeQuery(query);
		Uri uri = BuildUri(query);
		HttpResponseMessage response = await _httpClient.GetAsync(uri, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			response.EnsureSuccessStatusCode();
			return ParseResponse(await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false));
		}
		finally
		{
			((IDisposable)response)?.Dispose();
		}
	}

	internal static SkillMarketQuery NormalizeQuery(SkillMarketQuery query)
	{
		query = query ?? new SkillMarketQuery();
		return new SkillMarketQuery
		{
			Search = (string.IsNullOrWhiteSpace(query.Search) ? null : query.Search.Trim()),
			Page = ((query.Page <= 0) ? 1 : query.Page),
			PageSize = ((query.PageSize <= 0) ? 12 : Math.Min(query.PageSize, 50)),
			Sort = (string.IsNullOrWhiteSpace(query.Sort) ? "popular" : query.Sort.Trim())
		};
	}

	internal static Uri BuildUri(SkillMarketQuery query)
	{
		query = NormalizeQuery(query);
		List<string> list = new List<string>
		{
			"page=" + Uri.EscapeDataString(query.Page.ToString()),
			"pageSize=" + Uri.EscapeDataString(query.PageSize.ToString()),
			"sort=" + Uri.EscapeDataString(query.Sort)
		};
		if (!string.IsNullOrWhiteSpace(query.Search))
		{
			list.Add("search=" + Uri.EscapeDataString(query.Search));
		}
		return new Uri(BaseUri?.ToString() + "?" + string.Join("&", list));
	}

	internal static SkillMarketResponse ParseResponse(string json)
	{
		SkillMarketResponse skillMarketResponse = new SkillMarketResponse();
		if (string.IsNullOrWhiteSpace(json))
		{
			return skillMarketResponse;
		}
		using (JsonDocument jsonDocument = JsonDocument.Parse(json))
		{
			JsonElement rootElement = jsonDocument.RootElement;
			if (rootElement.TryGetProperty("data", out var value) && value.ValueKind == JsonValueKind.Array)
			{
				foreach (JsonElement item in value.EnumerateArray())
				{
					skillMarketResponse.Skills.Add(ParseSkill(item));
				}
			}
			if (rootElement.TryGetProperty("meta", out var value2) && value2.TryGetProperty("pagination", out var value3) && value3.ValueKind == JsonValueKind.Object)
			{
				skillMarketResponse.Pagination = new SkillMarketPagination
				{
					Page = GetInt(value3, "page"),
					PageSize = GetInt(value3, "pageSize"),
					Total = GetInt(value3, "total"),
					PageCount = GetInt(value3, "pageCount")
				};
			}
		}
		return skillMarketResponse;
	}

	private static SkillMarketSkillInfo ParseSkill(JsonElement item)
	{
		return new SkillMarketSkillInfo
		{
			Slug = GetString(item, "slug"),
			Name = GetString(item, "name"),
			Description = GetString(item, "description"),
			AuthorName = GetString(item, "authorName"),
			Version = GetString(item, "version"),
			Category = GetString(item, "category"),
			Categories = GetStringArray(item, "categories"),
			Tags = GetStringArray(item, "tags"),
			RiskNotice = GetString(item, "riskNotice"),
			SkillMd = GetString(item, "skillMd"),
			ArchiveUrl = NormalizeArchiveUrl(GetNestedString(item, "file", "url")),
			DownloadCount = GetInt(item, "downloadCount"),
			ViewCount = GetInt(item, "viewCount"),
			LikeCount = GetInt(item, "likeCount"),
			UpdatedAt = GetString(item, "updatedAt")
		};
	}

	private static string GetString(JsonElement item, string name)
	{
		if (!item.TryGetProperty(name, out var value) || value.ValueKind == JsonValueKind.Null)
		{
			return null;
		}
		if (value.ValueKind != JsonValueKind.String)
		{
			return value.ToString();
		}
		return value.GetString();
	}

	private static string GetNestedString(JsonElement item, string objectName, string propertyName)
	{
		if (!item.TryGetProperty(objectName, out var value) || value.ValueKind != JsonValueKind.Object)
		{
			return null;
		}
		return GetString(value, propertyName);
	}

	internal static string NormalizeArchiveUrl(string archiveUrl)
	{
		if (string.IsNullOrWhiteSpace(archiveUrl))
		{
			return null;
		}
		if (!Uri.TryCreate(archiveUrl.Trim(), UriKind.Absolute, out var result))
		{
			return archiveUrl.Trim();
		}
		if (string.Equals(result.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) && (result.Host.Equals("www.cgzcpa.com", StringComparison.OrdinalIgnoreCase) || result.Host.Equals("cgzcpa.com", StringComparison.OrdinalIgnoreCase)))
		{
			return new UriBuilder(result)
			{
				Scheme = Uri.UriSchemeHttps,
				Port = -1
			}.Uri.ToString();
		}
		return result.ToString();
	}

	private static int GetInt(JsonElement item, string name)
	{
		if (!item.TryGetProperty(name, out var value))
		{
			return 0;
		}
		if (value.ValueKind == JsonValueKind.Number && value.TryGetInt32(out var value2))
		{
			return value2;
		}
		if (value.ValueKind != JsonValueKind.String || !int.TryParse(value.GetString(), out value2))
		{
			return 0;
		}
		return value2;
	}

	private static List<string> GetStringArray(JsonElement item, string name)
	{
		List<string> list = new List<string>();
		if (!item.TryGetProperty(name, out var value) || value.ValueKind != JsonValueKind.Array)
		{
			return list;
		}
		foreach (JsonElement item2 in value.EnumerateArray())
		{
			string text = ((item2.ValueKind == JsonValueKind.String) ? item2.GetString() : item2.ToString());
			if (!string.IsNullOrWhiteSpace(text))
			{
				list.Add(text.Trim());
			}
		}
		return list;
	}
}
