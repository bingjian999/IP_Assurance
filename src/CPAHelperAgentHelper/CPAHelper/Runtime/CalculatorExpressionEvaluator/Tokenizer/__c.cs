using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CPAHelper.Agent.Runtime;

internal static class CalculatorExpressionEvaluator
{
	private sealed class Tokenizer
	{
		private readonly string _expression;

		private readonly List<Token> _tokens = new List<Token>();

		private int _index;

		internal Tokenizer(string expression)
		{
			_expression = expression ?? string.Empty;
		}

		internal List<Token> Tokenize()
		{
			while (_index < _expression.Length)
			{
				char c = _expression[_index];
				if (!char.IsWhiteSpace(c))
				{
					switch (c)
					{
					case '¥':
					case '￥':
						break;
					case '–':
					case '—':
						AddNumber(0m, "0");
						_index++;
						continue;
					default:
					{
						if (char.IsDigit(c) || c == '.')
						{
							AddNumber(ParseNumberToken(out var normalizedText), normalizedText);
							continue;
						}
						if (c == '(' && TryParseAccountingNegative(out var value, out var normalizedText2))
						{
							AddNumber(value, normalizedText2);
							continue;
						}
						switch (c)
						{
						case '*':
						case '+':
						case '-':
						case '/':
							Add(new Token(TokenKind.Operator, c.ToString(), c, 0m));
							_index++;
							break;
						case '(':
							Add(new Token(TokenKind.LeftParen, "(", '\0', 0m));
							_index++;
							break;
						case ')':
							Add(new Token(TokenKind.RightParen, ")", '\0', 0m));
							_index++;
							break;
						default:
							throw new ArgumentException("Expression contains an unsupported character: " + c);
						}
						continue;
					}
					}
				}
				_index++;
			}
			Add(new Token(TokenKind.End, string.Empty, '\0', 0m));
			return _tokens;
		}

		private void AddNumber(decimal value, string text)
		{
			Add(new Token(TokenKind.Number, text, '\0', value));
		}

		private void Add(Token token)
		{
			if (_tokens.Count >= 1000)
			{
				throw new ArgumentException("Expression contains too many terms.");
			}
			_tokens.Add(token);
		}

		private decimal ParseNumberToken(out string normalizedText)
		{
			int index = _index;
			while (_index < _expression.Length && (char.IsDigit(_expression[_index]) || _expression[_index] == ',' || _expression[_index] == '.'))
			{
				_index++;
			}
			decimal value = ParseDecimal(_expression.Substring(index, _index - index));
			value = ApplyUnitSuffix(value);
			value = ApplyPercentSuffix(value);
			normalizedText = FormatDecimal(value);
			return value;
		}

		private bool TryParseAccountingNegative(out decimal value, out string normalizedText)
		{
			value = default(decimal);
			normalizedText = null;
			int num = _expression.IndexOf(')', _index + 1);
			if (num < 0)
			{
				return false;
			}
			string text = _expression.Substring(_index + 1, num - _index - 1).Trim();
			if (!LooksLikeAccountingNumber(text))
			{
				return false;
			}
			List<Token> list = new Tokenizer(text).Tokenize();
			if (list.Count != 2 || list[0].Kind != TokenKind.Number)
			{
				return false;
			}
			value = -list[0].Value;
			normalizedText = "(" + FormatDecimal(value) + ")";
			_index = num + 1;
			return true;
		}

		private static bool LooksLikeAccountingNumber(string inner)
		{
			if (string.IsNullOrWhiteSpace(inner))
			{
				return false;
			}
			if (inner.Any((char ch) => ch == '+' || ch == '*' || ch == '/'))
			{
				return false;
			}
			if (inner.IndexOf(',') < 0 && inner.IndexOf('.') < 0 && inner.IndexOf('%') < 0 && inner.IndexOf('¥') < 0 && inner.IndexOf('￥') < 0 && inner.IndexOf('万') < 0 && inner.IndexOf('千') < 0)
			{
				return inner.IndexOf('元') >= 0;
			}
			return true;
		}

		private decimal ApplyUnitSuffix(decimal value)
		{
			if (StartsWith("万元"))
			{
				_index += 2;
				return value * 10000m;
			}
			if (StartsWith("万"))
			{
				_index++;
				return value * 10000m;
			}
			if (StartsWith("千元"))
			{
				_index += 2;
				return value * 1000m;
			}
			if (StartsWith("千"))
			{
				_index++;
				return value * 1000m;
			}
			if (StartsWith("元"))
			{
				_index++;
			}
			return value;
		}

		private decimal ApplyPercentSuffix(decimal value)
		{
			if (_index < _expression.Length && _expression[_index] == '%')
			{
				_index++;
				return value / 100m;
			}
			return value;
		}

		private bool StartsWith(string value)
		{
			if (string.IsNullOrEmpty(value) || _index + value.Length > _expression.Length)
			{
				return false;
			}
			return string.Compare(_expression, _index, value, 0, value.Length, StringComparison.Ordinal) == 0;
		}

		private static decimal ParseDecimal(string rawNumber)
		{
			string text = (rawNumber ?? string.Empty).Replace(",", string.Empty);
			if (string.IsNullOrWhiteSpace(text) || text == ".")
			{
				throw new ArgumentException("Invalid number: " + rawNumber);
			}
			if (text.Count((char ch) => ch == '.') > 1)
			{
				throw new ArgumentException("Invalid number: " + rawNumber);
			}
			if (!decimal.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var result))
			{
				throw new ArgumentException("Invalid number: " + rawNumber);
			}
			return result;
		}
	}

	private sealed class Parser
	{
		private readonly IReadOnlyList<Token> _tokens;

		private int _index;

		private Token Current => _tokens[_index];

		internal Parser(IReadOnlyList<Token> tokens)
		{
			_tokens = tokens ?? throw new ArgumentNullException("tokens");
		}

		internal decimal Parse()
		{
			decimal result = ParseExpression();
			if (Current.Kind != TokenKind.End)
			{
				throw new ArgumentException("Unexpected token: " + Current.Text);
			}
			return result;
		}

		private decimal ParseExpression()
		{
			decimal num = ParseTerm();
			while (Current.Kind == TokenKind.Operator && (Current.Operator == '+' || Current.Operator == '-'))
			{
				char num2 = Current.Operator;
				Advance();
				decimal num3 = ParseTerm();
				num = ((num2 == '+') ? (num + num3) : (num - num3));
			}
			return num;
		}

		private decimal ParseTerm()
		{
			decimal num = ParseFactor();
			while (Current.Kind == TokenKind.Operator && (Current.Operator == '*' || Current.Operator == '/'))
			{
				char num2 = Current.Operator;
				Advance();
				decimal num3 = ParseFactor();
				num = ((num2 == '*') ? (num * num3) : Divide(num, num3));
			}
			return num;
		}

		private decimal ParseFactor()
		{
			if (Current.Kind == TokenKind.Operator && (Current.Operator == '+' || Current.Operator == '-'))
			{
				char num = Current.Operator;
				Advance();
				decimal num2 = ParseFactor();
				if (num != '-')
				{
					return num2;
				}
				return -num2;
			}
			if (Current.Kind == TokenKind.Number)
			{
				decimal value = Current.Value;
				Advance();
				return value;
			}
			if (Current.Kind == TokenKind.LeftParen)
			{
				Advance();
				decimal result = ParseExpression();
				if (Current.Kind != TokenKind.RightParen)
				{
					throw new ArgumentException("Missing closing parenthesis.");
				}
				Advance();
				return result;
			}
			throw new ArgumentException("Expected a number or parenthesized expression.");
		}

		private static decimal Divide(decimal left, decimal right)
		{
			if (right == 0m)
			{
				throw new DivideByZeroException("Division by zero.");
			}
			return left / right;
		}

		private void Advance()
		{
			if (_index < _tokens.Count - 1)
			{
				_index++;
			}
		}
	}

	private sealed class Token
	{
		internal TokenKind Kind { get; }

		internal string Text { get; }

		internal char Operator { get; }

		internal decimal Value { get; }

		internal Token(TokenKind kind, string text, char op, decimal value)
		{
			Kind = kind;
			Text = text;
			Operator = op;
			Value = value;
		}
	}

	private enum TokenKind
	{
		Number,
		Operator,
		LeftParen,
		RightParen,
		End
	}

	private const int MaxExpressionLength = 8000;

	private const int MaxTokenCount = 1000;

	internal static CalculatorEvaluation Evaluate(string expression)
	{
		if (string.IsNullOrWhiteSpace(expression))
		{
			throw new ArgumentException("Expression is empty.");
		}
		if (expression.Length > 8000)
		{
			throw new ArgumentException("Expression is too long.");
		}
		List<Token> list = new Tokenizer(NormalizeCharacters(expression)).Tokenize();
		decimal result = new Parser(list).Parse();
		string normalizedExpression = string.Join(" ", from token in list
			where token.Kind != TokenKind.End
			select token.Text);
		return new CalculatorEvaluation(result, normalizedExpression);
	}

	internal static string FormatDecimal(decimal value)
	{
		return value.ToString("0.############################", CultureInfo.InvariantCulture);
	}

	private static string NormalizeCharacters(string expression)
	{
		StringBuilder stringBuilder = new StringBuilder(expression.Length);
		foreach (char c in expression)
		{
			if (c >= '０' && c <= '９')
			{
				stringBuilder.Append((char)(48 + c - 65296));
				continue;
			}
			switch (c)
			{
			case '٬':
			case '，':
				stringBuilder.Append(',');
				break;
			case '。':
			case '．':
				stringBuilder.Append('.');
				break;
			case '（':
				stringBuilder.Append('(');
				break;
			case '）':
				stringBuilder.Append(')');
				break;
			case '＋':
				stringBuilder.Append('+');
				break;
			case '－':
				stringBuilder.Append('-');
				break;
			case '×':
			case '✕':
				stringBuilder.Append('*');
				break;
			case '÷':
				stringBuilder.Append('/');
				break;
			case '％':
				stringBuilder.Append('%');
				break;
			case '\u3000':
				stringBuilder.Append(' ');
				break;
			default:
				stringBuilder.Append(c);
				break;
			}
		}
		return stringBuilder.ToString();
	}
}
