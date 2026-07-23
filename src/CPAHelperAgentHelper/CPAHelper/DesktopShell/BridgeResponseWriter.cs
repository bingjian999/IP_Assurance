using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CPAHelper.Agent.DesktopShell;

internal static class BridgeResponseWriter
{
	public static async Task WriteJsonAsync(HttpListenerResponse response, object value, JsonSerializerOptions jsonOptions)
	{
		string s = JsonSerializer.Serialize(value, jsonOptions);
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		response.ContentType = "application/json";
		response.ContentEncoding = Encoding.UTF8;
		response.ContentLength64 = bytes.Length;
		await response.OutputStream.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(continueOnCapturedContext: false);
		response.Close();
	}

	public static async Task WriteJsonErrorAsync(HttpListenerResponse response, int statusCode, string message, JsonSerializerOptions jsonOptions)
	{
		try
		{
			response.StatusCode = statusCode;
			await WriteJsonAsync(response, new
			{
				error = message
			}, jsonOptions).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch
		{
			try
			{
				response.Close();
			}
			catch
			{
			}
		}
	}
}
