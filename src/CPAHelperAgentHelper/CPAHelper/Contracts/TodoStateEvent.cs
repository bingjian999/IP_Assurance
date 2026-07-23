using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CPAHelper.Agent.Contracts;

public class TodoStateEvent : SseEvent
{
	public override string Type => "todo-state";

	[JsonPropertyName("runStatus")]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string RunStatus { get; set; }

	[JsonPropertyName("items")]
	public List<TodoStateItem> Items { get; set; } = new List<TodoStateItem>();

	[JsonPropertyName("completedCount")]
	public int CompletedCount { get; set; }

	[JsonPropertyName("totalCount")]
	public int TotalCount { get; set; }

	[JsonPropertyName("activeTodoId")]
	public int? ActiveTodoId { get; set; }
}
