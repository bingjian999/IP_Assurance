using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class BridgeRequestRouter
{
	private delegate bool RouteMatcher(HttpListenerRequest request, out string routeValue);

	private sealed class Route
	{
		public string Method { get; }

		public string Path { get; }

		public RouteMatcher Match { get; }

		public Func<HttpListenerRequest, HttpListenerResponse, string, Task> Handler { get; }

		public Route(string method, string path, RouteMatcher match, Func<HttpListenerRequest, HttpListenerResponse, string, Task> handler)
		{
			Method = method;
			Path = path;
			Match = match;
			Handler = handler ?? throw new ArgumentNullException("handler");
		}
	}

	private readonly List<Route> _routes = new List<Route>();

	public BridgeRequestRouter Map(string method, string path, Func<HttpListenerRequest, HttpListenerResponse, string, Task> handler)
	{
		_routes.Add(new Route(method, path, null, handler));
		return this;
	}

	public BridgeRequestRouter MapSessionTitle(Func<HttpListenerRequest, HttpListenerResponse, string, Task> handler)
	{
		_routes.Add(new Route("PUT", null, MatchSessionTitle, handler));
		return this;
	}

	public BridgeRequestRouter MapSession(string method, Func<HttpListenerRequest, HttpListenerResponse, string, Task> handler)
	{
		_routes.Add(new Route(method, null, MatchSession, handler));
		return this;
	}

	public BridgeRequestRouter MapHostAction(Func<HttpListenerRequest, HttpListenerResponse, string, Task> handler)
	{
		_routes.Add(new Route("POST", null, MatchHostAction, handler));
		return this;
	}

	public BridgeRequestRouter MapMcpServerTools(Func<HttpListenerRequest, HttpListenerResponse, string, Task> handler)
	{
		_routes.Add(new Route("GET", null, MatchMcpServerTools, handler));
		return this;
	}

	public async Task<bool> TryDispatchAsync(HttpListenerRequest request, HttpListenerResponse response)
	{
		string a = request.Url.AbsolutePath.ToLowerInvariant();
		foreach (Route route in _routes)
		{
			if (!string.Equals(request.HttpMethod, route.Method, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			string routeValue = null;
			if (route.Path != null)
			{
				if (!string.Equals(a, route.Path, StringComparison.Ordinal))
				{
					continue;
				}
			}
			else if (route.Match == null || !route.Match(request, out routeValue))
			{
				continue;
			}
			await route.Handler(request, response, routeValue).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}
		return false;
	}

	private static bool MatchSessionTitle(HttpListenerRequest request, out string sessionId)
	{
		string absolutePath = request.Url.AbsolutePath;
		string text = absolutePath.ToLowerInvariant();
		sessionId = null;
		if (!text.StartsWith("/api/sessions/", StringComparison.Ordinal) || !text.EndsWith("/title", StringComparison.Ordinal))
		{
			return false;
		}
		string text2 = absolutePath.Substring("/api/sessions/".Length);
		sessionId = text2.Substring(0, text2.Length - "/title".Length);
		return true;
	}

	private static bool MatchSession(HttpListenerRequest request, out string sessionId)
	{
		string absolutePath = request.Url.AbsolutePath;
		string text = absolutePath.ToLowerInvariant();
		sessionId = null;
		if (!text.StartsWith("/api/sessions/", StringComparison.Ordinal))
		{
			return false;
		}
		sessionId = absolutePath.Substring("/api/sessions/".Length);
		return !string.IsNullOrWhiteSpace(sessionId);
	}

	private static bool MatchHostAction(HttpListenerRequest request, out string actionId)
	{
		string absolutePath = request.Url.AbsolutePath;
		string text = absolutePath.ToLowerInvariant();
		actionId = null;
		if (!text.StartsWith("/api/host/actions/", StringComparison.Ordinal))
		{
			return false;
		}
		actionId = WebUtility.UrlDecode(absolutePath.Substring("/api/host/actions/".Length));
		return !string.IsNullOrWhiteSpace(actionId);
	}

	private static bool MatchMcpServerTools(HttpListenerRequest request, out string serverId)
	{
		string absolutePath = request.Url.AbsolutePath;
		string text = absolutePath.ToLowerInvariant();
		serverId = null;
		if (!text.StartsWith("/api/settings/mcp/", StringComparison.Ordinal) || !text.EndsWith("/tools", StringComparison.Ordinal))
		{
			return false;
		}
		string text2 = absolutePath.Substring("/api/settings/mcp/".Length);
		serverId = WebUtility.UrlDecode(text2.Substring(0, text2.Length - "/tools".Length));
		return !string.IsNullOrWhiteSpace(serverId);
	}
}
