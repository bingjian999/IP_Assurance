using System;
using System.Reflection;
using ndRERvVtEjasqN2cQqiN;

namespace oCGCxFVSfC0vkeUi83SN;

internal class H6AcESVSZXO1TtFeraiE
{
	internal delegate void Lk2xOtVSblTlsxpCTYbe(object o);

	internal static Module jWYVSMB4Mr2;

	internal static void lZxVLv5NYmU(int typemdt)
	{
		Type type = jWYVSMB4Mr2.ResolveType(33554432 + typemdt);
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			MethodInfo method = (MethodInfo)jWYVSMB4Mr2.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	public H6AcESVSZXO1TtFeraiE()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
	}

	static H6AcESVSZXO1TtFeraiE()
	{
		hdFXkSVtKBHNJ9MQ8VcZ.AlBVL0oCCKQ();
		jWYVSMB4Mr2 = typeof(H6AcESVSZXO1TtFeraiE).Assembly.ManifestModule;
	}
}
