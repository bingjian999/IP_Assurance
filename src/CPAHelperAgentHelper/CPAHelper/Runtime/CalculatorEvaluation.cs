namespace CPAHelper.Agent.Runtime;

internal sealed class CalculatorEvaluation
{
	internal decimal Result { get; }

	internal string NormalizedExpression { get; }

	internal CalculatorEvaluation(decimal result, string normalizedExpression)
	{
		Result = result;
		NormalizedExpression = normalizedExpression;
	}
}
