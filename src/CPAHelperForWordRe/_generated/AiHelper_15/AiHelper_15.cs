using BatchReplaceService3;
using Helper_13;
using Helper_25;
using AiTargetBinder;
using AiHelper_2;
using Helper_6;
using SseStreamInitializer;
using Helper_8;
using Helper_7;
using AiHelper_18;
using AiHelper_5;

namespace AiHelper_15;

internal sealed class AiHelper_15
{
	private readonly Helper_7 hfHiIsUWQN;

	private readonly Helper_6 _helper_6;

	private readonly Helper_8 xCfiHuovAO;

	private readonly AiHelper_18 _aiHelper_18;

	private readonly Helper_13 _helper_13;

	private readonly Helper_25 VNAirQtm55;

	private readonly AiHelper_2 _aiHelper_2;

	public AiHelper_15() : this(null)
	{
		SseStreamInitializer.InitializeRuntime();
	}

	public AiHelper_15(AiTargetBinder P_0)
	{
		SseStreamInitializer.InitializeRuntime();
		BatchReplaceService3 kyVxiEuxDXgR94DylXE2 = new BatchReplaceService3(P_0);
		hfHiIsUWQN = new Helper_7(kyVxiEuxDXgR94DylXE2);
		_helper_6 = new Helper_6(kyVxiEuxDXgR94DylXE2);
		xCfiHuovAO = new Helper_8(kyVxiEuxDXgR94DylXE2);
		_aiHelper_18 = new AiHelper_18(kyVxiEuxDXgR94DylXE2);
		_helper_13 = new Helper_13(kyVxiEuxDXgR94DylXE2);
		VNAirQtm55 = new Helper_25(kyVxiEuxDXgR94DylXE2);
		_aiHelper_2 = new AiHelper_2(P_0);
	}

	public AiHelper_5 uBEILO8rUi(bool P_0, bool P_1, int P_2)
	{
		return hfHiIsUWQN.qWG8oA4Yub(P_0, P_1, P_2);
	}

	public AiHelper_5 VeqIs57Xhr(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		return hfHiIsUWQN.k5f8GPur1X(P_0, P_1, P_2, P_3, P_4);
	}

	public AiHelper_5 xIWIlcABp3(int P_0)
	{
		return hfHiIsUWQN.LoY8Cfe4u0(P_0);
	}

	public AiHelper_5 fC6INRnIrt(int P_0, int P_1, int P_2)
	{
		return hfHiIsUWQN.QVx8pOa3YT(P_0, P_1, P_2);
	}

	public AiHelper_5 zfSIm4yRjA(int P_0, int P_1, int P_2, int P_3)
	{
		return hfHiIsUWQN.kBo8OaDSuD(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 ImhIo42sy6(int P_0, bool P_1, int P_2)
	{
		return hfHiIsUWQN.zSB8nLdPMx(P_0, P_1, P_2);
	}

	public AiHelper_5 LylIGH7ndw(string P_0, int P_1, int P_2, string P_3, int P_4, int P_5, int P_6, int P_7, int P_8)
	{
		return hfHiIsUWQN.DYb87GMvDw(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8);
	}

	public AiHelper_5 lqaIC39p4o(int P_0, int P_1, int P_2, int P_3)
	{
		return hfHiIsUWQN.sHV85viBuH(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 ReadComments(int P_0, bool P_1, int P_2, int P_3)
	{
		return xCfiHuovAO.U1380SKJZB(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 ReplyComment(string P_0, string P_1, int P_2, string P_3, string P_4)
	{
		return xCfiHuovAO.Iqb8krajox(P_0, P_1, P_2, P_3, P_4);
	}

	public AiHelper_5 CDOIn5SU4e(string P_0, int P_1, string P_2, int P_3)
	{
		return _helper_6.cIk8XmXs2r(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 FindText(string P_0, bool P_1, bool P_2, int P_3)
	{
		return _helper_6.Ye58Fd0h55(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 pkZI56ofmA(string P_0, bool P_1, int P_2)
	{
		return _helper_6.I9K8hx7QFt(P_0, P_1, P_2);
	}

	public AiHelper_5 FindTableText(string P_0, bool P_1, int P_2)
	{
		return _helper_6.H3P8ahHXM5(P_0, P_1, P_2);
	}

	public AiHelper_5 SelectRange(int P_0, int P_1)
	{
		return _helper_6.sXv8qRO3B1(P_0, P_1);
	}

	public AiHelper_5 SelectTable(int P_0)
	{
		return _helper_6.mfW8PinRZN(P_0);
	}

	public AiHelper_5 AddCommentAtSelection(string P_0)
	{
		return xCfiHuovAO.TQ38xtPp96(P_0);
	}

	public AiHelper_5 AddCommentAtRange(int P_0, int P_1, string P_2)
	{
		return xCfiHuovAO.T0Z8dqcqya(P_0, P_1, P_2);
	}

	public AiHelper_5 AddCommentAtParagraphRange(int P_0, int P_1, int P_2, string P_3)
	{
		return xCfiHuovAO.pvR8zmjLqE(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 AddCommentAtTableCell(int P_0, int P_1, int P_2, string P_3)
	{
		return xCfiHuovAO.FT0IReMmH6(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 InsertParagraph(int P_0, string P_1, string P_2, bool P_3)
	{
		return _aiHelper_18.TxQIuiTrjK(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 SetParagraphOutlineLevel(int P_0, int P_1, int P_2)
	{
		return _aiHelper_18.mSiIDBBjNV(P_0, P_1, P_2);
	}

	public AiHelper_5 FillTableCellsByModel(int P_0, int P_1, string P_2, string P_3, string P_4, bool P_5, bool P_6)
	{
		return _helper_13.tHtIQ7n6Hr(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	public AiHelper_5 InsertTableRowsByModel(int P_0, int P_1, int P_2, int P_3, string P_4, int P_5, string P_6, string P_7, bool P_8, string P_9)
	{
		return _helper_13.VTlI16elaN(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, P_9);
	}

	public AiHelper_5 InsertTableAtRange(int P_0, int P_1, int P_2, int P_3, string P_4, string P_5, string P_6, bool P_7, bool P_8)
	{
		return _helper_13.XDTIrnQQlA(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8);
	}

	public AiHelper_5 ReplaceRangeWithTrackChanges(int P_0, int P_1, string P_2)
	{
		return _aiHelper_18.hgrITjuGVa(P_0, P_1, P_2);
	}

	public AiHelper_5 ReplaceSelectionWithTrackChanges(string P_0)
	{
		return _aiHelper_18.TD9IgEm2tj(P_0);
	}

	public AiHelper_5 BatchReplaceTextExecute(string P_0, string P_1, int P_2, bool P_3, bool P_4, bool P_5, int P_6)
	{
		return _aiHelper_18.BTDI8F9Iro(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	public AiHelper_5 ExportComments()
	{
		return xCfiHuovAO.tavIV7ukDC();
	}

	public AiHelper_5 AdjustSelectedTablesFormat()
	{
		return VNAirQtm55.NnnIKC5mJ9();
	}

	public AiHelper_5 AdjustSelectedParagraphsFormat()
	{
		return VNAirQtm55.P2LIEGm9IC();
	}

	public AiHelper_5 ReadTableAdjustmentConfig()
	{
		return VNAirQtm55.i3BI2Qgx5s();
	}

	public AiHelper_5 ReadParagraphAdjustmentConfig(string P_0)
	{
		return VNAirQtm55.qTYI4wGWbF(P_0);
	}

	public AiHelper_5 InspectTableFormat(int P_0)
	{
		return VNAirQtm55.PVGIjeKTkD(P_0);
	}

	public AiHelper_5 InspectParagraphFormat(int P_0)
	{
		return VNAirQtm55.KeeIYhlnfb(P_0);
	}

	public AiHelper_5 PreviewParagraphFormatChange(int P_0, int P_1, string P_2)
	{
		return VNAirQtm55.I9tIZ6k62i(P_0, P_1, P_2);
	}

	public AiHelper_5 ApplyParagraphFormatChange(int P_0, int P_1, string P_2, int P_3)
	{
		return VNAirQtm55.S5gIfEtjgY(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 PreviewTableFormatChange(int P_0, string P_1, string P_2)
	{
		return VNAirQtm55.KGOIMTDmaX(P_0, P_1, P_2);
	}

	public AiHelper_5 ApplyTableFormatChange(int P_0, string P_1, string P_2, int P_3)
	{
		return VNAirQtm55.XGCIbOUGlH(P_0, P_1, P_2, P_3);
	}

	public AiHelper_5 InsertHtmlVisual(string P_0, string P_1, int P_2, int P_3, double P_4, double P_5, string P_6, string P_7)
	{
		return _aiHelper_2.Uwp128MQKQ(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7);
	}
}
