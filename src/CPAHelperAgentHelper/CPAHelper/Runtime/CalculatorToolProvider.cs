using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using CPAHelper.Agent.Abstractions;
using Microsoft.Extensions.AI;
using Newtonsoft.Json;

namespace CPAHelper.Agent.Runtime;

public sealed class CalculatorToolProvider : IToolProvider
{
	public string ProviderName => "Calculator";

	public IList<AITool> GetTools()
	{
		MethodInfo method = GetType().GetMethod("CalcEvalExpression", BindingFlags.Instance | BindingFlags.NonPublic);
		return new List<AITool> { AIFunctionFactory.Create(method, this, new AIFunctionFactoryOptions
		{
			Name = "calc_eval_expression",
			Description = "Evaluate a local arithmetic expression with decimal arithmetic. Supports +, -, *, /, parentheses, thousands separators, full-width digits, percentages, and common accounting number formats."
		}) };
	}

	public IList<ToolMetadata> GetToolMetadata()
	{
		List<ToolMetadata> list = new List<ToolMetadata>();
		list.Add(new ToolMetadata("calc_eval_expression", new string[5] { "calc", "calc.core", "read", "word.read", "excel.read" }, "Evaluate a local arithmetic expression with decimal arithmetic.", isDefault: true));
		return list;
	}

	[Description("Evaluate a local arithmetic expression with decimal arithmetic. The expression may contain numbers, +, -, *, /, parentheses, thousands separators, full-width digits, percentages, and common accounting number formats.")]
	private string CalcEvalExpression([Description("Arithmetic expression to evaluate, for example: 1,234.56 - 200.00 * 3.")] string expression)
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		try
		{
			CalculatorEvaluation calculatorEvaluation = CalculatorExpressionEvaluator.Evaluate(expression);
			stopwatch.Stop();
			return JsonConvert.SerializeObject(new
			{
				ok = true,
				expression = (expression ?? string.Empty),
				normalizedExpression = calculatorEvaluation.NormalizedExpression,
				result = calculatorEvaluation.Result,
				resultText = CalculatorExpressionEvaluator.FormatDecimal(calculatorEvaluation.Result),
				durationMs = (int)stopwatch.Elapsed.TotalMilliseconds
			});
		}
		catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException || ex is DivideByZeroException || ex is OverflowException)
		{
			stopwatch.Stop();
			return JsonConvert.SerializeObject(new
			{
				ok = false,
				expression = (expression ?? string.Empty),
				error = ex.Message,
				durationMs = (int)stopwatch.Elapsed.TotalMilliseconds
			});
		}
	}
}
