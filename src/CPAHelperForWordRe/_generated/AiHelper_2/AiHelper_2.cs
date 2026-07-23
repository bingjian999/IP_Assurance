using System;
using System.IO;
using System.Runtime.CompilerServices;
using AiConfigBootstrap;
using WordAgentRuntimeGuard2;
using AiSseStreamService3;
using AiTargetBinder;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Word;
using SseStreamInitializer;
using WordTableToolService4;
using DocumentLifecycleGuard;
using AiHelper_5;

namespace AiHelper_2;

internal sealed class AiHelper_2
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass2_0
	{
		public string fardXZwHxs;

		public int value;

		public int value;

		public string TpddahokY1;

		public double hKqdqALOn1;

		public double double;

		public string text;

		public string text;

		public _G_c__DisplayClass2_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal AiHelper_5 w4mdyDK6GA(Application app)
		{
			string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return WordAgentRuntimeGuard2.CreateNotReadyError(text);
			}
			Document document = DocumentLifecycleGuard.GetActiveDocument(app);
			Range range = no8143nY9C(app, document, fardXZwHxs, value, value);
			int start = range.Start;
			InlineShape inlineShape = null;
			try
			{
				InlineShapes inlineShapes = document.InlineShapes;
				string fileName = TpddahokY1;
				object LinkToFile = false;
				object SaveWithDocument = true;
				object Range = range;
				inlineShape = inlineShapes.AddPicture(fileName, ref LinkToFile, ref SaveWithDocument, ref Range);
				object arg = inlineShape;
				if (_G_o__2.kxxdWPKgCB == null)
				{
					_G_o__2.kxxdWPKgCB = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LockAspectRatio", typeof(AiHelper_2), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				_G_o__2.kxxdWPKgCB.Target(_G_o__2.kxxdWPKgCB, arg, 0);
				inlineShape.Width = (float)hKqdqALOn1;
				inlineShape.Height = (float)double;
				string text2 = (string.IsNullOrWhiteSpace(text) ? "HTML视觉" : text.Trim());
				try
				{
					inlineShape.Title = text2;
				}
				catch
				{
				}
				try
				{
					inlineShape.AlternativeText = "IP_Assurance HTML Visual; name=" + text2 + "; hash=" + (text ?? string.Empty);
				}
				catch
				{
				}
				DocumentLifecycleGuard.ClearWordOpenXmlCache();
				return AiHelper_5.CreateSuccess("HTML visual inserted into Word.", new
				{
					document = document.Name,
					position = nmD1YFmls9(fardXZwHxs),
					insertionPosition = start,
					rangeStart = inlineShape.Range.Start,
					rangeEnd = inlineShape.Range.End,
					visualName = text2,
					widthPoints = hKqdqALOn1,
					heightPoints = double,
					sourceHash = text,
					inlineShapeType = inlineShape.Type.ToString(),
					embedded = true
				});
			}
			catch
			{
				if (inlineShape != null)
				{
					try
					{
						inlineShape.Delete();
					}
					catch
					{
					}
				}
				throw;
			}
		}
	}

	[CompilerGenerated]
	private static class _G_o__2
	{
		public static CallSite<Func<CallSite, object, int, object>> kxxdWPKgCB;
	}

	private readonly WordTableToolService4 _wordTableToolService4;

	public AiHelper_2(AiTargetBinder P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		_wordTableToolService4 = new WordTableToolService4(P_0);
	}

	public AiHelper_5 InsertHtmlVisual(string P_0, string P_1, int P_2, int P_3, double P_4, double P_5, string P_6, string P_7)
	{
		_G_c__DisplayClass2_0 CS_8_locals_25 = new _G_c__DisplayClass2_0();
		CS_8_locals_25.fardXZwHxs = P_1;
		CS_8_locals_25.value = P_2;
		CS_8_locals_25.value = P_3;
		CS_8_locals_25.TpddahokY1 = P_0;
		CS_8_locals_25.hKqdqALOn1 = P_4;
		CS_8_locals_25.double = P_5;
		CS_8_locals_25.text = P_6;
		CS_8_locals_25.text = P_7;
		try
		{
			if (string.IsNullOrWhiteSpace(CS_8_locals_25.TpddahokY1) || !File.Exists(CS_8_locals_25.TpddahokY1))
			{
				throw new ArgumentException("HTML visual PNG file does not exist.", "imagePath");
			}
			if (CS_8_locals_25.hKqdqALOn1 <= 0.0 || CS_8_locals_25.double <= 0.0)
			{
				throw new ArgumentException("HTML visual display size must be greater than zero.");
			}
			return _wordTableToolService4.runOperation("create_html_visual", delegate(Application app)
			{
				string text = WordAgentRuntimeGuard2.GetNotReadyMessage(app);
				if (!string.IsNullOrWhiteSpace(text))
				{
					return WordAgentRuntimeGuard2.CreateNotReadyError(text);
				}
				Document document = DocumentLifecycleGuard.GetActiveDocument(app);
				Range range = no8143nY9C(app, document, CS_8_locals_25.fardXZwHxs, CS_8_locals_25.value, CS_8_locals_25.value);
				int start = range.Start;
				InlineShape inlineShape = null;
				try
				{
					InlineShapes inlineShapes = document.InlineShapes;
					string fileName = CS_8_locals_25.TpddahokY1;
					object LinkToFile = false;
					object SaveWithDocument = true;
					object Range = range;
					inlineShape = inlineShapes.AddPicture(fileName, ref LinkToFile, ref SaveWithDocument, ref Range);
					object arg = inlineShape;
					if (_G_o__2.kxxdWPKgCB == null)
					{
						_G_o__2.kxxdWPKgCB = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "[AI Tool][Word] Insert HTML visual failed.", typeof(AiHelper_2), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					_G_o__2.kxxdWPKgCB.Target(_G_o__2.kxxdWPKgCB, arg, 0);
					inlineShape.Width = (float)CS_8_locals_25.hKqdqALOn1;
					inlineShape.Height = (float)CS_8_locals_25.double;
					string text2 = (string.IsNullOrWhiteSpace(CS_8_locals_25.text) ? "Insert HTML visual failed" : CS_8_locals_25.text.Trim());
					try
					{
						inlineShape.Title = text2;
					}
					catch
					{
					}
					try
					{
						inlineShape.AlternativeText = "word_error" + text2 + "invalid_arguments" + (CS_8_locals_25.text ?? string.Empty);
					}
					catch
					{
					}
					DocumentLifecycleGuard.ClearWordOpenXmlCache();
					return AiHelper_5.CreateSuccess("HTML visual PNG file does not exist.", new
					{
						document = document.Name,
						position = nmD1YFmls9(CS_8_locals_25.fardXZwHxs),
						insertionPosition = start,
						rangeStart = inlineShape.Range.Start,
						rangeEnd = inlineShape.Range.End,
						visualName = text2,
						widthPoints = CS_8_locals_25.hKqdqALOn1,
						heightPoints = CS_8_locals_25.double,
						sourceHash = CS_8_locals_25.text,
						inlineShapeType = inlineShape.Type.ToString(),
						embedded = true
					});
				}
				catch
				{
					if (inlineShape != null)
					{
						try
						{
							inlineShape.Delete();
						}
						catch
						{
						}
					}
					throw;
				}
			});
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogError("imagePath", ex);
			Exception baseException = ex.GetBaseException();
			return AiHelper_5.CreateExceptionError("HTML visual display size must be greater than zero.", (baseException is ArgumentException) ? "create_html_visual" : "[AI Tool][Word] Insert HTML visual failed.", ex);
		}
	}

	private static Range no8143nY9C(Application P_0, Document P_1, string P_2, int P_3, int P_4)
	{
		string text = nmD1YFmls9(P_2);
		object End;
		if (text == "document_end")
		{
			int num = Math.Max(P_1.Content.Start, P_1.Content.End - 1);
			object Start = num;
			End = num;
			return P_1.Range(ref Start, ref End);
		}
		if (text == "range_start" || text == "range_end")
		{
			MLS1jdScQs(P_1, P_3, P_4);
			int num2 = ((text == "range_start") ? P_3 : P_4);
			End = num2;
			object Start = num2;
			return P_1.Range(ref End, ref Start);
		}
		if (P_3 >= 0 && P_4 >= P_3)
		{
			MLS1jdScQs(P_1, P_3, P_4);
			object Start = P_4;
			End = P_4;
			return P_1.Range(ref Start, ref End);
		}
		Range range = P_0.Selection?.Range;
		if (range == null || range.Document != P_1)
		{
			throw new InvalidOperationException("无法取得目标文档中的当前选区。");
		}
		Range duplicate = range.Duplicate;
		End = WdCollapseDirection.wdCollapseEnd;
		duplicate.Collapse(ref End);
		return duplicate;
	}

	private static void MLS1jdScQs(Document P_0, int P_1, int P_2)
	{
		int start = P_0.Content.Start;
		int end = P_0.Content.End;
		if (P_1 < start || P_2 < P_1 || P_2 > end)
		{
			throw new ArgumentException("rangeStart/rangeEnd 超出目标文档范围或顺序无效。");
		}
	}

	private static string nmD1YFmls9(string P_0)
	{
		string text = (string.IsNullOrWhiteSpace(P_0) ? "selection" : P_0.Trim().ToLowerInvariant());
		if (text == "selection" || text == "range_start" || text == "range_end" || text == "document_end")
		{
			return text;
		}
		throw new ArgumentException("position must be selection, range_start, range_end, or document_end.", "position");
	}
}
