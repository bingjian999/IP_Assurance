using System;
using System.Threading;
using System.Threading.Tasks;
using CPAHelper.Agent.DesktopShell;
using Microsoft.Agents.AI;

namespace CPAHelper.Agent.Runtime;

internal sealed class ObservableLoopEvaluator : LoopEvaluator
{
	private readonly string _name;

	internal LoopEvaluator InnerEvaluator { get; }

	internal ObservableLoopEvaluator(string name, LoopEvaluator innerEvaluator)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new ArgumentException("Evaluator name is required.", "name");
		}
		_name = name;
		InnerEvaluator = innerEvaluator ?? throw new ArgumentNullException("innerEvaluator");
	}

	public override async ValueTask<LoopEvaluation> EvaluateAsync(LoopContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		try
		{
			LoopEvaluation loopEvaluation = await InnerEvaluator.EvaluateAsync(context, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			AgentRuntimeLogger.Info("MAF loop evaluator decision. ThreadId=" + (ModelTraceContext.Current?.SessionId ?? string.Empty) + "; TurnId=" + (ModelTraceContext.Current?.TurnId ?? string.Empty) + "; " + $"Iteration={context.Iteration}; Evaluator={_name}; " + "Decision=" + (loopEvaluation.ShouldReinvoke ? "continue" : "stop") + "; " + $"FeedbackLength={loopEvaluation.Feedback?.Length ?? 0}; " + $"LastResponseMessages={(context.LastResponse?.Messages?.Count).GetValueOrDefault()}");
			return loopEvaluation;
		}
		catch (Exception ex)
		{
			AgentRuntimeLogger.Error("MAF loop evaluator failed. ThreadId=" + (ModelTraceContext.Current?.SessionId ?? string.Empty) + "; TurnId=" + (ModelTraceContext.Current?.TurnId ?? string.Empty) + "; " + $"Iteration={context.Iteration}; Evaluator={_name}; ErrorType={ex.GetType().FullName}; " + "ErrorMessage=" + ex.Message, ex);
			throw;
		}
	}
}
