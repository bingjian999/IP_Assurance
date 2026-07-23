using System;

namespace CPAHelper.Agent.Abstractions;

public class AgentConfig
{
	public string Name { get; set; } = "";

	public string Provider { get; set; } = "openai";

	public string ApiKey { get; set; } = "";

	public string BaseUrl { get; set; } = "";

	public string Model { get; set; } = "";

	public AgentSummaryOptions Summary { get; set; } = new AgentSummaryOptions();

	public AgentHarnessOptions Harness { get; set; } = new AgentHarnessOptions();

	public DateTime CreatedAt { get; set; } = DateTime.Now;

	public DateTime UpdatedAt { get; set; } = DateTime.Now;

	public bool IsValid()
	{
		if (string.IsNullOrWhiteSpace(ApiKey) || string.IsNullOrWhiteSpace(Model))
		{
			return false;
		}
		switch ((Provider ?? "openai").Trim().ToLowerInvariant())
		{
		case "openai":
		case "anthropic":
			return true;
		case "deepseek":
			return true;
		default:
			return !string.IsNullOrWhiteSpace(BaseUrl);
		}
	}
}
