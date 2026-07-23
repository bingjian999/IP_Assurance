using System.Threading.Tasks;
using CPAHelper.Agent.Adapters;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopTitleGenerationCoordinator
{
	private readonly string _threadId;

	private readonly SessionTitleGenerator _titleGenerator;

	public DesktopTitleGenerationCoordinator(string threadId, SessionTitleGenerator titleGenerator)
	{
		_threadId = threadId ?? string.Empty;
		_titleGenerator = titleGenerator;
	}

	public Task StartIfNeeded(JsonSessionIndexManager.SessionSummary sessionSummary, string visibleUserMessage, ActiveSseStream stream)
	{
		if (_titleGenerator == null || !SessionTitleGenerator.ShouldGenerateTitle(sessionSummary, visibleUserMessage))
		{
			return null;
		}
		JsonSessionIndexManager.SessionSummary summary = JsonSessionIndexManager.SetTitleGenerationState(_threadId, isGenerating: true);
		stream?.WriteSync(DesktopTurnFinalizer.ToSessionSummaryEvent(summary));
		return _titleGenerator.GenerateInBackgroundAsync(_threadId, visibleUserMessage);
	}

	public void ObserveQuietly(Task titleGenerationTask)
	{
		titleGenerationTask?.ContinueWith(delegate
		{
		}, TaskScheduler.Default);
	}
}
