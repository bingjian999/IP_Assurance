using System.Threading;
using System.Threading.Tasks;
using Microsoft.Agents.AI.Compaction;
using Microsoft.Extensions.Logging;

namespace CPAHelper.Agent.Runtime;

internal sealed class MafCompactionMetricsStrategy : CompactionStrategy
{
	private readonly string _stage;

	private readonly int _triggerTokens;

	private readonly int _targetTokens;

	private readonly int _hardLimitTokens;

	internal MafCompactionMetricsStrategy(string stage, int triggerTokens, int targetTokens, int hardLimitTokens)
		: base(CompactionTriggers.Always)
	{
		_stage = (string.IsNullOrWhiteSpace(stage) ? "unknown" : stage);
		_triggerTokens = triggerTokens;
		_targetTokens = targetTokens;
		_hardLimitTokens = hardLimitTokens;
	}

	protected override ValueTask<bool> CompactCoreAsync(CompactionMessageIndex index, ILogger logger, CancellationToken cancellationToken)
	{
		if (index != null)
		{
			MafCompactionMetrics.Publish(new MafCompactionMetricsSnapshot
			{
				Stage = _stage,
				IncludedTokenCount = index.IncludedTokenCount,
				TotalTokenCount = index.TotalTokenCount,
				IncludedMessageCount = index.IncludedMessageCount,
				TotalMessageCount = index.TotalMessageCount,
				IncludedGroupCount = index.IncludedGroupCount,
				TotalGroupCount = index.TotalGroupCount,
				TriggerTokens = _triggerTokens,
				TargetTokens = _targetTokens,
				HardLimitTokens = _hardLimitTokens
			});
		}
		return new ValueTask<bool>(result: false);
	}
}
