using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using dL7TFPsQbAGqPywtHUK;
using hJKpQrVSwRwMyI2RyDQN;
using ndRERvVtEjasqN2cQqiN;
using qDDKriLz2Bft1Ehv17i;

namespace fEL1IrFiIQNNkrppxDT;

internal static class FU3jS0FIce4DwhYZInu
{
	[CompilerGenerated]
	private sealed class _G_c__DisplayClass10_0
	{
		public string F13Vbxled7l;

		public _G_c__DisplayClass10_0()
		{
			hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		}

		internal bool k4wVbkhEuvP(string name)
		{
			return name.EndsWith(F13Vbxled7l, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static readonly Dictionary<string, string> d69FfDi4LM;

	private static readonly Lazy<string[]> SV1FMjfGfH;

	private static readonly Dictionary<string, string> BbmFbp3fVM;

	public static void fxBFHYusB4(object P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		FieldInfo[] fields = P_0.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			object value = fieldInfo.GetValue(P_0);
			if (value != null && nLjFQFh4Xx(value))
			{
				string text = IhtFrb1C8L(value, "Name");
				if (string.IsNullOrWhiteSpace(text))
				{
					text = fieldInfo.Name;
				}
				if (yNWFJL4VZB(value, text))
				{
					num++;
					continue;
				}
				l75F2C0ERo(value, EmCFE6WmEH(text));
				num2++;
			}
		}
		if (num == 0 && num2 > 0)
		{
			yR9thasHZ73xXm8eKwj.z7Us3dJ6Cl("[Ribbon] PNG icons were not matched; controls fell back to OfficeImageId.");
		}
	}

	private static bool nLjFQFh4Xx(object P_0)
	{
		Type type = P_0.GetType();
		if (!V6QF1FBcWI(type, "Image", typeof(Image)))
		{
			return V6QF1FBcWI(type, "OfficeImageId", typeof(string));
		}
		return true;
	}

	private static bool V6QF1FBcWI(Type P_0, string P_1, Type P_2)
	{
		PropertyInfo property = P_0.GetProperty(P_1);
		if (property != null && property.CanWrite)
		{
			return property.PropertyType == P_2;
		}
		return false;
	}

	private static string IhtFrb1C8L(object P_0, string P_1)
	{
		return P_0.GetType().GetProperty(P_1)?.GetValue(P_0) as string;
	}

	private static bool yNWFJL4VZB(object P_0, string P_1)
	{
		Image image = YJEF3B0exu(P_1);
		if (image == null)
		{
			return false;
		}
		wccFYaly0r(P_0);
		jfUFjaIgoI(P_0, image);
		DACFZXVOvc(P_0, true);
		return true;
	}

	private static Image YJEF3B0exu(string P_0)
	{
		if (!d69FfDi4LM.TryGetValue(P_0, out var value) || string.IsNullOrWhiteSpace(value))
		{
			return null;
		}
		Image image = mvFFUAPkpP(value);
		if (image != null)
		{
			return image;
		}
		return gjbFKwdfIx(value);
	}

	private static Image mvFFUAPkpP(string P_0)
	{
		try
		{
			_G_c__DisplayClass10_0 CS_8_locals_2 = new _G_c__DisplayClass10_0();
			CS_8_locals_2.F13Vbxled7l = P_0.Replace('\\', '.').Replace('/', '.');
			string text = SV1FMjfGfH.Value.FirstOrDefault((string name) => name.EndsWith(CS_8_locals_2.F13Vbxled7l, StringComparison.OrdinalIgnoreCase));
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}
			using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(text);
			if (stream == null)
			{
				return null;
			}
			using Image original = Image.FromStream(stream);
			return new Bitmap(original);
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static Image gjbFKwdfIx(string P_0)
	{
		try
		{
			string text = P_0;
			if (text.StartsWith("Assets\\\\RibbonIcons\\\\", StringComparison.OrdinalIgnoreCase))
			{
				text = text.Substring("Assets\\\\RibbonIcons\\\\".Length);
			}
			string text2 = Path.Combine(W6xTwMLd5RvSHoqDfEV.RibbonIconAssetsDir, text);
			if (!File.Exists(text2))
			{
				return null;
			}
			using Image original = Image.FromFile(text2);
			return new Bitmap(original);
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static string EmCFE6WmEH(string P_0)
	{
		if (BbmFbp3fVM.TryGetValue(P_0, out var value) && !string.IsNullOrWhiteSpace(value))
		{
			return value;
		}
		return "FileSaveAs";
	}

	private static void l75F2C0ERo(object P_0, string P_1)
	{
		MXUF43ki3E(P_0);
		PropertyInfo property = P_0.GetType().GetProperty("OfficeImageId");
		if (property != null && property.CanWrite && property.PropertyType == typeof(string))
		{
			property.SetValue(P_0, P_1, null);
		}
		DACFZXVOvc(P_0, true);
	}

	private static void MXUF43ki3E(object P_0)
	{
		jfUFjaIgoI(P_0, null);
	}

	private static void jfUFjaIgoI(object P_0, Image P_1)
	{
		PropertyInfo property = P_0.GetType().GetProperty("Image");
		if (property != null && property.CanWrite && typeof(Image).IsAssignableFrom(property.PropertyType))
		{
			property.SetValue(P_0, P_1, null);
		}
	}

	private static void wccFYaly0r(object P_0)
	{
		PropertyInfo property = P_0.GetType().GetProperty("OfficeImageId");
		if (property != null && property.CanWrite && property.PropertyType == typeof(string))
		{
			property.SetValue(P_0, null, null);
		}
	}

	private static void DACFZXVOvc(object P_0, bool P_1)
	{
		PropertyInfo property = P_0.GetType().GetProperty("ShowImage");
		if (property != null && property.CanWrite && property.PropertyType == typeof(bool))
		{
			property.SetValue(P_0, P_1, null);
		}
	}

	static FU3jS0FIce4DwhYZInu()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		d69FfDi4LM = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
		{
			{
				"SBAI助手",
				"Assets\\\\RibbonIcons\\\\General\\\\word_ai_assistant.png"
			},
			{
				"SplitBtn钉桌面",
				"Assets\\\\RibbonIcons\\\\General\\\\word_desktop_pin.png"
			},
			{
				"Btn开始截图",
				"Assets\\\\RibbonIcons\\\\General\\\\word_desktop_pin.png"
			},
			{
				"Btn快速全屏截图",
				"Assets\\\\RibbonIcons\\\\General\\\\word_desktop_pin.png"
			},
			{
				"Btn关闭所有钉图",
				"Assets\\\\RibbonIcons\\\\General\\\\word_desktop_unpin.png"
			},
			{
				"Btn钉图配置",
				"Assets\\\\RibbonIcons\\\\General\\\\word_settings.png"
			},
			{
				"BtnAI配置",
				"Assets\\\\RibbonIcons\\\\General\\\\word_settings.png"
			},
			{
				"BtnAI帮助",
				"Assets\\\\RibbonIcons\\\\General\\\\word_ai_help.png"
			},
			{
				"B段落格式调整",
				"Assets\\\\RibbonIcons\\\\Paragraphs\\\\word_paragraph_settings.png"
			},
			{
				"B段落配置",
				"Assets\\\\RibbonIcons\\\\Paragraphs\\\\word_paragraph_settings.png"
			},
			{
				"b表前单位",
				"Assets\\\\RibbonIcons\\\\Paragraphs\\\\word_table_unit.png"
			},
			{
				"b表后注释",
				"Assets\\\\RibbonIcons\\\\Paragraphs\\\\word_after_table_note.png"
			},
			{
				"m表后段落",
				"Assets\\\\RibbonIcons\\\\Paragraphs\\\\word_after_table_paragraph.png"
			},
			{
				"b全选表后第一段",
				"Assets\\\\RibbonIcons\\\\Paragraphs\\\\word_select_first_after_table.png"
			},
			{
				"b表后段落处理",
				"Assets\\\\RibbonIcons\\\\Paragraphs\\\\word_after_table_process.png"
			},
			{
				"B表格调整",
				"Assets\\\\RibbonIcons\\\\Tables\\\\word_table_adjust.png"
			},
			{
				"B表格配置",
				"Assets\\\\RibbonIcons\\\\Tables\\\\word_table_settings.png"
			},
			{
				"B重复首行",
				"Assets\\\\RibbonIcons\\\\Tables\\\\word_repeat_header.png"
			},
			{
				"bEW粘贴",
				"Assets\\\\RibbonIcons\\\\Tables\\\\word_paste_table.png"
			},
			{
				"M列宽",
				"Assets\\\\RibbonIcons\\\\Tables\\\\word_column_menu.png"
			},
			{
				"b统一列宽",
				"Assets\\\\RibbonIcons\\\\Tables\\\\word_uniform_column_width.png"
			},
			{
				"b列宽调整",
				"Assets\\\\RibbonIcons\\\\Tables\\\\word_max_column_width.png"
			},
			{
				"B全选表格",
				"Assets\\\\RibbonIcons\\\\Tables\\\\word_select_all_tables.png"
			},
			{
				"b除以万",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_divide.png"
			},
			{
				"b添加万",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_add_wan.png"
			},
			{
				"B乘以一百",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_multiply.png"
			},
			{
				"B添加百分号",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_percent.png"
			},
			{
				"B选段求和",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_sum.png"
			},
			{
				"M数字更多",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_sum.png"
			},
			{
				"B千分符配置",
				"Assets\\\\RibbonIcons\\\\General\\\\word_settings.png"
			},
			{
				"M日期转换",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_thousands.png"
			},
			{
				"B日期转点号",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_thousands.png"
			},
			{
				"B日期转斜杠",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_thousands.png"
			},
			{
				"B日期转横杠",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_thousands.png"
			},
			{
				"B日期转年月日",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_thousands.png"
			},
			{
				"b去除空白",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_clear_blank.png"
			},
			{
				"b高亮",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_highlight.png"
			},
			{
				"M文字更多",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_empty_line_menu.png"
			},
			{
				"B中英符号",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_languages.png"
			},
			{
				"批量替换",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_batch_replace.png"
			},
			{
				"Menu1",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_empty_line_menu.png"
			},
			{
				"Btn去除空行",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_delete_empty_lines.png"
			},
			{
				"Btn去除换行符",
				"Assets\\\\RibbonIcons\\\\TextNumber\\\\word_delete_line_breaks.png"
			},
			{
				"b一级",
				"Assets\\\\RibbonIcons\\\\Outline\\\\word_heading_1.png"
			},
			{
				"b二级",
				"Assets\\\\RibbonIcons\\\\Outline\\\\word_heading_2.png"
			},
			{
				"b三级",
				"Assets\\\\RibbonIcons\\\\Outline\\\\word_heading_3.png"
			},
			{
				"b四级",
				"Assets\\\\RibbonIcons\\\\Outline\\\\word_heading_4.png"
			},
			{
				"b五级",
				"Assets\\\\RibbonIcons\\\\Outline\\\\word_heading_5.png"
			},
			{
				"b正文",
				"Assets\\\\RibbonIcons\\\\Outline\\\\word_body_text.png"
			},
			{
				"M行列校验",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_row_column_check.png"
			},
			{
				"b行校验",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_row_check.png"
			},
			{
				"b列校验",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_column_check.png"
			},
			{
				"b区域求和",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_area_sum.png"
			},
			{
				"M模板库",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_template_menu.png"
			},
			{
				"B刷新列表",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_refresh_list.png"
			},
			{
				"B绑定Excel区域",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_update_link.png"
			},
			{
				"B导出全部表并绑定",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_create_link.png"
			},
			{
				"B同步当前表",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_update_link.png"
			},
			{
				"B同步全部表",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_update_link.png"
			},
			{
				"B重新绑定",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_replace_link.png"
			},
			{
				"B管理绑定",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_link_menu.png"
			},
			{
				"B清洁文档",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_clean_document.png"
			},
			{
				"B批注导出",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_export_comments.png"
			},
			{
				"M校验更多",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_serial_process.png"
			},
			{
				"M查找下一个",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_find_next_menu.png"
			},
			{
				"B下一个表格",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_next_table.png"
			},
			{
				"B下一个高亮",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_next_highlight.png"
			},
			{
				"B下一个标题",
				"Assets\\\\RibbonIcons\\\\Validation\\\\word_next_heading.png"
			},
			{
				"g页边距设置",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_margin_menu.png"
			},
			{
				"b附注页",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_note_page.png"
			},
			{
				"b封面页",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_cover_page.png"
			},
			{
				"b正文页",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_body_page.png"
			},
			{
				"b插入横页",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_insert_landscape.png"
			},
			{
				"b添加页码",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_page_number.png"
			},
			{
				"b页码起始值",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_page_number.png"
			},
			{
				"b批量pdf",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_pdf.png"
			},
			{
				"b批量合并文档",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_merge_documents.png"
			},
			{
				"M页面更多",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_split_menu.png"
			},
			{
				"M拆分文档",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_split_menu.png"
			},
			{
				"b拆分文档",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_split_by_page.png"
			},
			{
				"b指定页拆分",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_split_by_page.png"
			},
			{
				"b分节符拆分",
				"Assets\\\\RibbonIcons\\\\Pages\\\\word_split_by_section.png"
			},
			{
				"B说明",
				"Assets\\\\RibbonIcons\\\\Misc\\\\word_help.png"
			},
			{
				"关于作者",
				"Assets\\\\RibbonIcons\\\\Misc\\\\word_about_author.png"
			},
			{
				"Menu数字化课",
				"Assets\\\\RibbonIcons\\\\Misc\\\\word_course_menu.png"
			},
			{
				"Btn课程Excel",
				"Assets\\\\RibbonIcons\\\\Misc\\\\word_course_excel.png"
			},
			{
				"Btn课程Word",
				"Assets\\\\RibbonIcons\\\\Misc\\\\word_course_word.png"
			},
			{
				"Btn课程AI",
				"Assets\\\\RibbonIcons\\\\General\\\\word_ai_assistant.png"
			},
			{
				"Btn课程VBA",
				"Assets\\\\RibbonIcons\\\\Misc\\\\word_course_vba.png"
			},
			{
				"检查更新",
				"Assets\\\\RibbonIcons\\\\Misc\\\\word_update.png"
			},
			{
				"捐赠",
				"Assets\\\\RibbonIcons\\\\Misc\\\\word_donate.png"
			},
			{
				"B全局配置",
				"Assets\\\\RibbonIcons\\\\Misc\\\\word_global_settings.png"
			}
		};
		SV1FMjfGfH = new Lazy<string[]>(() => Assembly.GetExecutingAssembly().GetManifestResourceNames());
		BbmFbp3fVM = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
		{
			{
				"SBAI助手",
				"FileProperties"
			},
			{
				"BtnAI配置",
				"FileProperties"
			},
			{
				"BtnAI帮助",
				"Help"
			},
			{
				"SplitBtn钉桌面",
				"ScreenClipping"
			},
			{
				"Btn开始截图",
				"ScreenClipping"
			},
			{
				"Btn快速全屏截图",
				"ScreenClipping"
			},
			{
				"Btn关闭所有钉图",
				"Delete"
			},
			{
				"Btn钉图配置",
				"FileProperties"
			},
			{
				"B段落格式调整",
				"ParagraphSpacing"
			},
			{
				"B段落配置",
				"FileProperties"
			},
			{
				"B表格调整",
				"TableProperties"
			},
			{
				"B表格配置",
				"FileProperties"
			},
			{
				"B重复首行",
				"TableRowsRepeatHeader"
			},
			{
				"bEW粘贴",
				"Paste"
			},
			{
				"b千分符",
				"CommaStyle"
			},
			{
				"b除以万",
				"FunctionWizard"
			},
			{
				"b添加万",
				"FileNew"
			},
			{
				"B乘以一百",
				"FunctionWizard"
			},
			{
				"B添加百分号",
				"PercentStyle"
			},
			{
				"B选段求和",
				"AutoSum"
			},
			{
				"M数字更多",
				"AutoSum"
			},
			{
				"B千分符配置",
				"FileProperties"
			},
			{
				"M日期转换",
				"DateAndTimeInsert"
			},
			{
				"B日期转点号",
				"DateAndTimeInsert"
			},
			{
				"B日期转斜杠",
				"DateAndTimeInsert"
			},
			{
				"B日期转横杠",
				"DateAndTimeInsert"
			},
			{
				"B日期转年月日",
				"DateAndTimeInsert"
			},
			{
				"b去除空白",
				"Clear"
			},
			{
				"b高亮",
				"TextHighlightColorPicker"
			},
			{
				"M文字更多",
				"ReplaceDialog"
			},
			{
				"B中英符号",
				"GroupLanguage"
			},
			{
				"批量替换",
				"ReplaceDialog"
			},
			{
				"M行列校验",
				"AcceptInvitation"
			},
			{
				"M校验更多",
				"ListMacros"
			},
			{
				"b区域求和",
				"AutoSum"
			},
			{
				"M模板库",
				"FileNew"
			},
			{
				"B绑定Excel区域",
				"RefreshAll"
			},
			{
				"B导出全部表并绑定",
				"HyperlinkInsert"
			},
			{
				"B同步当前表",
				"RefreshAll"
			},
			{
				"B同步全部表",
				"RefreshAll"
			},
			{
				"B重新绑定",
				"HyperlinkInsert"
			},
			{
				"B管理绑定",
				"ListMacros"
			},
			{
				"B清洁文档",
				"Clear"
			},
			{
				"B批注导出",
				"ReviewNewComment"
			},
			{
				"g页边距设置",
				"PageMarginsGallery"
			},
			{
				"b插入横页",
				"PageOrientationLandscape"
			},
			{
				"Btn重命名文档",
				"FileSaveAs"
			},
			{
				"b添加页码",
				"PageNumbersInsertGallery"
			},
			{
				"b页码起始值",
				"PageNumbersFormat"
			},
			{
				"b批量pdf",
				"FileSaveAsPdfOrXps"
			},
			{
				"b批量合并文档",
				"FileOpen"
			},
			{
				"M页面更多",
				"FileSaveAs"
			},
			{
				"M拆分文档",
				"FileSaveAs"
			},
			{
				"b指定页拆分",
				"FileSaveAs"
			},
			{
				"B说明",
				"Help"
			},
			{
				"关于作者",
				"HappyFace"
			},
			{
				"检查更新",
				"RefreshAll"
			},
			{
				"捐赠",
				"HappyFace"
			},
			{
				"B全局配置",
				"FileProperties"
			}
		};
	}
}
