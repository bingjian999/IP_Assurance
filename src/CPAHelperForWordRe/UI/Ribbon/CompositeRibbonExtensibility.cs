using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using AiConfigBootstrap;
using TableBorderConfig;
using AiSseStreamService3;
using Microsoft.Office.Core;
using SseStreamInitializer;
using AiSseStreamService;
using WordTableToolService;
using stdole;
using ExcelDataSyncService;

namespace CPAHelperForWordRe.UI.Ribbon;

[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public sealed class CompositeRibbonExtensibility : IRibbonExtensibility, IReflect, IDisposable
{
	private sealed class SmS6GoVbbfh1MhoEaGD5 : AxHost
	{
		private SmS6GoVbbfh1MhoEaGD5() : base(null)
		{
			SseStreamInitializer.InitializeRuntime();
		}

		public static IPictureDisp z7NVbSHZprT(Image P_0)
		{
			return (IPictureDisp)AxHost.GetIPictureDispFromPicture(P_0);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass23_0
	{
		public string JnjVbsOyDYy;

		public _G_c__DisplayClass23_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool vLiVbLM0NPS(XElement group)
		{
			return yHTXBXWvOY(X9mXVna6Bn(group), JnjVbsOyDYy);
		}
	}

	[CompilerGenerated]
	private sealed class _G_c__DisplayClass31_0
	{
		public string WtHVbNq0x94;

		public _G_c__DisplayClass31_0()
		{
			SseStreamInitializer.InitializeRuntime();
		}

		internal bool aGkVblrAXTG(string name)
		{
			return name.EndsWith(WtHVbNq0x94, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static readonly XNamespace SRGXrKgLK0;

	private static readonly string[] Q2WXJBIxKt;

	private static readonly string[] oi4X3VCs68;

	private readonly IRibbonExtensibility tFKXUdudKk;

	private readonly IReflect CP2XKImP7l;

	private string AWbXE6MFgG;

	private static IRibbonUI PLaX24SrXo;

	private static IPictureDisp YJKX4T7rtv;

	private static Bitmap adVXjFPqT8;

	private static readonly Lazy<string[]> oekXYcfaSL;

	public Type UnderlyingSystemType => GetType();

	public CompositeRibbonExtensibility(IRibbonExtensibility designerRibbon)
	{
		SseStreamInitializer.InitializeRuntime();
		tFKXUdudKk = designerRibbon ?? throw new ArgumentNullException("designerRibbon");
		CP2XKImP7l = designerRibbon as IReflect;
	}

	public string GetCustomUI(string ribbonID)
	{
		string customUI = tFKXUdudKk.GetCustomUI(ribbonID);
		if (!iVCy0JrsSO(ribbonID))
		{
			return customUI;
		}
		try
		{
			return vOTyku7Tal(customUI, out AWbXE6MFgG);
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[Ribbon] Excel sync context menu XML merge skipped: " + ex.Message);
			return customUI;
		}
	}

	public bool GetExcelSyncContextMenuVisible(IRibbonControl control)
	{
		return ExcelDataSyncService.tE8XLlC6V1();
	}

	public void OnCompositeRibbonLoaded(IRibbonUI ribbonUi)
	{
		hgIXHQ6ueX(ribbonUi);
		ExcelDataSyncService.vpbXsP8YgS(ribbonUi);
		C0ZX6OAUiX(ribbonUi);
	}

	public string GetWordRibbonTabLabel(IRibbonControl control)
	{
		return I6GX97kGFn();
	}

	internal static void S0ZyWdvYIm()
	{
		try
		{
			PLaX24SrXo?.Invalidate();
		}
		catch
		{
		}
	}

	public void OnExcelSyncContextMenuAction(IRibbonControl control)
	{
		ExcelDataSyncService.T25Xl7T74U(control?.Id);
	}

	public IPictureDisp GetExcelSyncContextMenuImage(IRibbonControl control)
	{
		if (control == null || control.Id.IndexOf("Locate", StringComparison.OrdinalIgnoreCase) < 0)
		{
			return null;
		}
		return YJKX4T7rtv ?? (YJKX4T7rtv = w6uXDZc7qf());
	}

	public void Dispose()
	{
		(tFKXUdudKk as IDisposable)?.Dispose();
	}

	private static bool iVCy0JrsSO(string P_0)
	{
		if (!string.IsNullOrWhiteSpace(P_0))
		{
			return P_0.StartsWith("Microsoft.Word.", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static string vOTyku7Tal(string P_0, out string P_1)
	{
		P_1 = null;
		XDocument xDocument;
		if (string.IsNullOrWhiteSpace(P_0))
		{
			xDocument = new XDocument(new XElement(SRGXrKgLK0 + "customUI"));
		}
		else
		{
			XDocument xDocument2 = XDocument.Parse(P_0, LoadOptions.PreserveWhitespace);
			xDocument = ((xDocument2.Root == null) ? new XDocument(new XElement(SRGXrKgLK0 + "customUI")) : new XDocument(xDocument2.Declaration, Vl0X8bbp60(xDocument2.Root)));
		}
		P_1 = Convert.ToString(xDocument.Root.Attribute("onLoad")?.Value);
		if (string.Equals(P_1, "OnCompositeRibbonLoaded", StringComparison.OrdinalIgnoreCase))
		{
			P_1 = null;
		}
		xDocument.Root.SetAttributeValue("onLoad", "OnCompositeRibbonLoaded");
		zCDyxZtWun(xDocument);
		XElement xElement = xDocument.Root.Element(SRGXrKgLK0 + "contextMenus");
		if (xElement == null)
		{
			xElement = new XElement(SRGXrKgLK0 + "contextMenus");
			xDocument.Root.Add(xElement);
		}
		string[] array = (WordTableToolService.IsWps ? oi4X3VCs68 : Q2WXJBIxKt);
		foreach (string text in array)
		{
			xElement.Add(Sp4Xu1mFJA(text));
		}
		return xDocument.ToString(SaveOptions.DisableFormatting);
	}

	private static void zCDyxZtWun(XDocument P_0)
	{
		if (P_0?.Root == null)
		{
			return;
		}
		foreach (XElement item in P_0.Descendants(SRGXrKgLK0 + "tab"))
		{
			if (nOgyd9saLN(item))
			{
				item.SetAttributeValue("label", null);
				item.SetAttributeValue("getLabel", "GetWordRibbonTabLabel");
			}
		}
	}

	private static bool nOgyd9saLN(XElement P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (yHTXBXWvOY(X9mXVna6Bn(P_0), "tabCPA"))
		{
			return true;
		}
		string a = uveXRmmb02(P_0, "label");
		if ((string.Equals(a, "IP_Assurance", StringComparison.OrdinalIgnoreCase) || string.Equals(a, "IPA", StringComparison.OrdinalIgnoreCase) || string.Equals(a, "报告小帮手", StringComparison.OrdinalIgnoreCase)) && VnGyz8aONp(P_0, "grpParagraph"))
		{
			return VnGyz8aONp(P_0, "grpAbout");
		}
		return false;
	}

	private static bool VnGyz8aONp(XElement P_0, string P_1)
	{
		_G_c__DisplayClass23_0 CS_8_locals_2 = new _G_c__DisplayClass23_0();
		CS_8_locals_2.JnjVbsOyDYy = P_1;
		return P_0.Descendants(SRGXrKgLK0 + "group").Any((XElement group) => yHTXBXWvOY(X9mXVna6Bn(group), CS_8_locals_2.JnjVbsOyDYy));
	}

	private static string uveXRmmb02(XElement P_0, string P_1)
	{
		return Convert.ToString(P_0?.Attribute(P_1)?.Value) ?? string.Empty;
	}

	private static string X9mXVna6Bn(XElement P_0)
	{
		string text = uveXRmmb02(P_0, "id");
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		text = uveXRmmb02(P_0, "idQ");
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return uveXRmmb02(P_0, "idMso");
	}

	private static bool yHTXBXWvOY(string P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_0) || string.IsNullOrWhiteSpace(P_1))
		{
			return false;
		}
		if (!string.Equals(P_0, P_1, StringComparison.OrdinalIgnoreCase) && !P_0.EndsWith("." + P_1, StringComparison.OrdinalIgnoreCase) && !P_0.EndsWith(":" + P_1, StringComparison.OrdinalIgnoreCase))
		{
			return P_0.EndsWith("_" + P_1, StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static string I6GX97kGFn()
	{
		try
		{
			string tabName = TableBorderConfig.Current.Config.System.TabName;
			return string.IsNullOrWhiteSpace(tabName) ? "IP_Assurance" : tabName.Trim();
		}
		catch
		{
			return "IP_Assurance";
		}
	}

	private void C0ZX6OAUiX(IRibbonUI P_0)
	{
		if (string.IsNullOrWhiteSpace(AWbXE6MFgG) || CP2XKImP7l == null)
		{
			return;
		}
		try
		{
			CP2XKImP7l.InvokeMember(AWbXE6MFgG, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, tFKXUdudKk, new object[1] { P_0 }, null, CultureInfo.InvariantCulture, null);
		}
		catch (Exception ex)
		{
			AiConfigBootstrap.LogWarn("[Ribbon] Designer onLoad callback skipped: " + AWbXE6MFgG + "; " + ex.Message);
		}
	}

	private static XElement Sp4Xu1mFJA(string P_0)
	{
		string text = P_0.Replace("ContextMenu", string.Empty);
		return new XElement(SRGXrKgLK0 + "contextMenu", new XAttribute("idMso", P_0), new XElement(SRGXrKgLK0 + "button", new XAttribute("id", "IPAssuranceExcelSyncSync" + text), new XAttribute("label", "同步数据"), new XAttribute("imageMso", "RefreshAll"), new XAttribute("getVisible", "GetExcelSyncContextMenuVisible"), new XAttribute("onAction", "OnExcelSyncContextMenuAction")), new XElement(SRGXrKgLK0 + "button", new XAttribute("id", "IPAssuranceExcelSyncLocate" + text), new XAttribute("label", "定位数据"), new XAttribute("getImage", "GetExcelSyncContextMenuImage"), new XAttribute("getVisible", "GetExcelSyncContextMenuVisible"), new XAttribute("onAction", "OnExcelSyncContextMenuAction")));
	}

	private static IPictureDisp w6uXDZc7qf()
	{
		try
		{
			Image image = YrmXTkiDyY("Assets\\\\RibbonIcons\\\\Validation\\\\word_find_next_menu.png") ?? h35XgFNX3f("Assets\\\\RibbonIcons\\\\Validation\\\\word_find_next_menu.png");
			if (image == null)
			{
				return null;
			}
			using (image)
			{
				adVXjFPqT8 = new Bitmap(image);
			}
			return SmS6GoVbbfh1MhoEaGD5.z7NVbSHZprT(adVXjFPqT8);
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static Image YrmXTkiDyY(string P_0)
	{
		_G_c__DisplayClass31_0 CS_8_locals_2 = new _G_c__DisplayClass31_0();
		CS_8_locals_2.WtHVbNq0x94 = P_0.Replace('\\', '.').Replace('/', '.');
		string text = oekXYcfaSL.Value.FirstOrDefault((string name) => name.EndsWith(CS_8_locals_2.WtHVbNq0x94, StringComparison.OrdinalIgnoreCase));
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

	private static Image h35XgFNX3f(string P_0)
	{
		string path = (P_0.StartsWith("Assets\\\\RibbonIcons\\\\", StringComparison.OrdinalIgnoreCase) ? P_0.Substring("Assets\\\\RibbonIcons\\\\".Length) : P_0);
		string text = Path.Combine(AiSseStreamService.RibbonIconAssetsDir, path);
		if (!File.Exists(text))
		{
			return null;
		}
		using Image original = Image.FromFile(text);
		return new Bitmap(original);
	}

	private static XElement Vl0X8bbp60(XElement P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		XElement xElement = new XElement(SRGXrKgLK0 + P_0.Name.LocalName);
		foreach (XAttribute item in P_0.Attributes())
		{
			if (!item.IsNamespaceDeclaration)
			{
				xElement.Add(new XAttribute(item.Name, item.Value));
			}
		}
		foreach (XNode item2 in P_0.Nodes())
		{
			XElement xElement2 = item2 as XElement;
			xElement.Add((xElement2 == null) ? item2 : Vl0X8bbp60(xElement2));
		}
		return xElement;
	}

	public FieldInfo GetField(string name, BindingFlags bindingAttr)
	{
		FieldInfo field = GetType().GetField(name, bindingAttr);
		if ((object)field == null)
		{
			IReflect cP2XKImP7l = CP2XKImP7l;
			if (cP2XKImP7l == null)
			{
				return null;
			}
			field = cP2XKImP7l.GetField(name, bindingAttr);
		}
		return field;
	}

	public FieldInfo[] GetFields(BindingFlags bindingAttr)
	{
		return OLiXQjidww(GetType().GetFields(bindingAttr), CP2XKImP7l?.GetFields(bindingAttr));
	}

	public MemberInfo[] GetMember(string name, BindingFlags bindingAttr)
	{
		return OLiXQjidww(GetType().GetMember(name, bindingAttr), CP2XKImP7l?.GetMember(name, bindingAttr));
	}

	public MemberInfo[] GetMembers(BindingFlags bindingAttr)
	{
		return OLiXQjidww(GetType().GetMembers(bindingAttr), CP2XKImP7l?.GetMembers(bindingAttr));
	}

	public MethodInfo GetMethod(string name, BindingFlags bindingAttr)
	{
		MethodInfo method = GetType().GetMethod(name, bindingAttr);
		if ((object)method == null)
		{
			IReflect cP2XKImP7l = CP2XKImP7l;
			if (cP2XKImP7l == null)
			{
				return null;
			}
			method = cP2XKImP7l.GetMethod(name, bindingAttr);
		}
		return method;
	}

	public MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
	{
		MethodInfo method = GetType().GetMethod(name, bindingAttr, binder, types, modifiers);
		if ((object)method == null)
		{
			IReflect cP2XKImP7l = CP2XKImP7l;
			if (cP2XKImP7l == null)
			{
				return null;
			}
			method = cP2XKImP7l.GetMethod(name, bindingAttr, binder, types, modifiers);
		}
		return method;
	}

	public MethodInfo[] GetMethods(BindingFlags bindingAttr)
	{
		return OLiXQjidww(GetType().GetMethods(bindingAttr), CP2XKImP7l?.GetMethods(bindingAttr));
	}

	public PropertyInfo GetProperty(string name, BindingFlags bindingAttr)
	{
		PropertyInfo property = GetType().GetProperty(name, bindingAttr);
		if ((object)property == null)
		{
			IReflect cP2XKImP7l = CP2XKImP7l;
			if (cP2XKImP7l == null)
			{
				return null;
			}
			property = cP2XKImP7l.GetProperty(name, bindingAttr);
		}
		return property;
	}

	public PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
	{
		PropertyInfo property = GetType().GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
		if ((object)property == null)
		{
			IReflect cP2XKImP7l = CP2XKImP7l;
			if (cP2XKImP7l == null)
			{
				return null;
			}
			property = cP2XKImP7l.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
		}
		return property;
	}

	public PropertyInfo[] GetProperties(BindingFlags bindingAttr)
	{
		return OLiXQjidww(GetType().GetProperties(bindingAttr), CP2XKImP7l?.GetProperties(bindingAttr));
	}

	public object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
	{
		ecPXidPNnf(args);
		if (ii2XIyPRiB(name, invokeAttr))
		{
			return GetType().InvokeMember(name, invokeAttr, binder, this, args, modifiers, culture, namedParameters);
		}
		if (CP2XKImP7l != null)
		{
			return CP2XKImP7l.InvokeMember(name, invokeAttr, binder, tFKXUdudKk, args, modifiers, culture, namedParameters);
		}
		return GetType().InvokeMember(name, invokeAttr, binder, this, args, modifiers, culture, namedParameters);
	}

	private static bool ii2XIyPRiB(string P_0, BindingFlags P_1)
	{
		BindingFlags bindingAttr = P_1 | (BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		return typeof(CompositeRibbonExtensibility).GetMember(P_0, bindingAttr).Length != 0;
	}

	private static void ecPXidPNnf(object[] P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i] is IRibbonUI ribbonUI)
			{
				hgIXHQ6ueX(ribbonUI);
				ExcelDataSyncService.vpbXsP8YgS(ribbonUI);
				break;
			}
		}
	}

	private static void hgIXHQ6ueX(IRibbonUI P_0)
	{
		if (P_0 != null)
		{
			PLaX24SrXo = P_0;
		}
	}

	private static Unt8TkX1vKrrJRigm83[] OLiXQjidww<Unt8TkX1vKrrJRigm83>(Unt8TkX1vKrrJRigm83[] P_0, Unt8TkX1vKrrJRigm83[] P_1)
	{
		if (P_1 == null || P_1.Length == 0)
		{
			return P_0 ?? new Unt8TkX1vKrrJRigm83[0];
		}
		if (P_0 == null || P_0.Length == 0)
		{
			return P_1;
		}
		return P_0.Concat(P_1).ToArray();
	}

	static CompositeRibbonExtensibility()
	{
		SseStreamInitializer.InitializeRuntime();
		SRGXrKgLK0 = "http://schemas.microsoft.com/office/2009/07/customui";
		Q2WXJBIxKt = new string[5]
		{
			"ContextMenuText",
			"ContextMenuTextTable",
			"ContextMenuTableCell",
			"ContextMenuTable",
			"ContextMenuTableWhole"
		};
		oi4X3VCs68 = new string[0];
		oekXYcfaSL = new Lazy<string[]>(() => Assembly.GetExecutingAssembly().GetManifestResourceNames());
	}
}
