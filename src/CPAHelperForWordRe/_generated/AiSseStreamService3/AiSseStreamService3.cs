using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using SseStreamInitializer;

namespace AiSseStreamService3;

internal class AiSseStreamService3
{
	private delegate void uYxSE2Vw0ltoiRVEnCoS(object o);

	internal class KQUBCcVwkSPZ6kvSnUlP : Attribute
	{
		internal class axZw0eVwxtDvwpZI4xqN<eUIGJRVwd6aI6rr5TZaK>
		{
			public axZw0eVwxtDvwpZI4xqN()
			{
				SseStreamInitializer.AlBVL0oCCKQ();
			}
		}

		public KQUBCcVwkSPZ6kvSnUlP(object P_0)
		{
		}
	}

	internal class yGR1deVwziPDHbXQMn02
	{
		internal static string FcLVtRs3WRg(string P_0, string P_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(P_0);
			byte[] key = new byte[32]
			{
				82, 102, 104, 110, 32, 77, 24, 34, 118, 181,
				51, 17, 18, 51, 12, 109, 10, 32, 77, 24,
				34, 158, 161, 41, 97, 28, 118, 181, 5, 25,
				1, 88
			};
			byte[] iV = I0YVSOaKkT7(Encoding.Unicode.GetBytes(P_1));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = iI8VSCYGOW0();
			symmetricAlgorithm.Key = key;
			symmetricAlgorithm.IV = iV;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate uint Ic5FQuVtV6hYMO6Hw8Wq(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr worQWhVtBRQbc7pulIBJ();

	internal struct mXOZ8GVt9O7JakK5brAx
	{
		internal bool SDxVt6rQVyT;

		internal byte[] XkWVtuKm4hT;
	}

	internal class pG2pc9VtDNfcA9tWEu1l
	{
		private BinaryReader k7nVtiJ0PdX;

		public pG2pc9VtDNfcA9tWEu1l(Stream P_0)
		{
			k7nVtiJ0PdX = new BinaryReader(P_0);
		}

		[SpecialName]
		internal Stream nW4lBacjpc()
		{
			return k7nVtiJ0PdX.BaseStream;
		}

		internal byte[] N58VtTHlnc1(int P_0)
		{
			return k7nVtiJ0PdX.ReadBytes(P_0);
		}

		internal int OiGVtg2fttc(byte[] P_0, int P_1, int P_2)
		{
			return k7nVtiJ0PdX.Read(P_0, P_1, P_2);
		}

		internal int xTbVt8qBXiV()
		{
			return k7nVtiJ0PdX.ReadInt32();
		}

		internal void nloVtInXWpT()
		{
			k7nVtiJ0PdX.Close();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private delegate IntPtr CnIuNqVtHwf5uVko3Y8l(IntPtr hModule, string lpName, uint lpType);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Y1YaG9VtQrL3P37IPnHL(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Iycf5vVt18eEBxTpyfZu(IntPtr hProcess, IntPtr lpBaseAddress, [In][Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int B6yMGEVtrP4FhxghXxwm(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr naVpbvVtJOgLxnw5rQgJ(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int GGm8yZVt3BnmMj8JtHec(IntPtr ptr);

	[Flags]
	private enum AYK1u4VtU2tJ8P7OxO9r
	{

	}

	private static bool MrsVw319ZOP;

	private static bool TLbVwEPcwER;

	internal static RSACryptoServiceProvider pBxVw4gXIEP;

	private static Dictionary<int, int> UCNVwjjwmBX;

	private static List<string> ASFVwMgcR10;

	private static byte[] jwFVwwn4Ymg;

	private static int P83VwGawLMQ;

	private static int uWPVw78g9Br;

	private static bool YtZVw5nSawh;

	private static CnIuNqVtHwf5uVko3Y8l lOnVwhDw2vP;

	private static Y1YaG9VtQrL3P37IPnHL gfyVwaBQbf6;

	private static GGm8yZVt3BnmMj8JtHec Vj2Vwvxv5ug;

	internal static Assembly auHVwUyvsY2;

	private static bool QoMVwmmMQpe;

	private static B6yMGEVtrP4FhxghXxwm FjEVwPDZt6J;

	private static naVpbvVtJOgLxnw5rQgJ gvPVwACSnZR;

	private static object zJgVwfnKSdt;

	private static IntPtr ra4VwyJ4ewv;

	internal static Ic5FQuVtV6hYMO6Hw8Wq GCLVwpE6P4X;

	private static byte[] lhSVwSSh4rK;

	private static int iEcVweSsGkg;

	private static int pLiVwZWwirQ;

	private static uint[] Hd8VwKOKvhh;

	private static long y4AVwCAC0Yh;

	private static bool KVKVw2yCJB8;

	[KQUBCcVwkSPZ6kvSnUlP(typeof(KQUBCcVwkSPZ6kvSnUlP.axZw0eVwxtDvwpZI4xqN<object>[]))]
	private static bool P32VwXHs5u8;

	private static bool wO7VwcdbIju;

	private static Iycf5vVt18eEBxTpyfZu NWZVwqYmPOO;

	private static long T1kVwnWkak5;

	internal static Ic5FQuVtV6hYMO6Hw8Wq dlfVwOGQmcw;

	private static List<int> dOEVwbBvEbj;

	private static int RJVVwN5cHMS;

	internal static Hashtable X9NVwFar7JP;

	private static IntPtr SCBVwt8e0Wv;

	private static object lL2VwY3JnIT;

	private static IntPtr HMyVwW9VJBv;

	private static IntPtr UWBVwLvoT9H;

	private static int[] dDlVwlisBLS;

	private static SortedList GVoVwojJ9BK;

	private static object YyFVwsU68eF;

	static AiSseStreamService3()
	{
		MrsVw319ZOP = false;
		auHVwUyvsY2 = typeof(AiSseStreamService3).Assembly;
		Hd8VwKOKvhh = new uint[64]
		{
			3614090360u, 3905402710u, 606105819u, 3250441966u, 4118548399u, 1200080426u, 2821735955u, 4249261313u, 1770035416u, 2336552879u,
			4294925233u, 2304563134u, 1804603682u, 4254626195u, 2792965006u, 1236535329u, 4129170786u, 3225465664u, 643717713u, 3921069994u,
			3593408605u, 38016083u, 3634488961u, 3889429448u, 568446438u, 3275163606u, 4107603335u, 1163531501u, 2850285829u, 4243563512u,
			1735328473u, 2368359562u, 4294588738u, 2272392833u, 1839030562u, 4259657740u, 2763975236u, 1272893353u, 4139469664u, 3200236656u,
			681279174u, 3936430074u, 3572445317u, 76029189u, 3654602809u, 3873151461u, 530742520u, 3299628645u, 4096336452u, 1126891415u,
			2878612391u, 4237533241u, 1700485571u, 2399980690u, 4293915773u, 2240044497u, 1873313359u, 4264355552u, 2734768916u, 1309151649u,
			4149444226u, 3174756917u, 718787259u, 3951481745u
		};
		TLbVwEPcwER = false;
		KVKVw2yCJB8 = false;
		pBxVw4gXIEP = null;
		UCNVwjjwmBX = null;
		lL2VwY3JnIT = new object();
		pLiVwZWwirQ = 0;
		zJgVwfnKSdt = new object();
		ASFVwMgcR10 = null;
		dOEVwbBvEbj = null;
		lhSVwSSh4rK = new byte[0];
		jwFVwwn4Ymg = new byte[0];
		SCBVwt8e0Wv = IntPtr.Zero;
		UWBVwLvoT9H = IntPtr.Zero;
		YyFVwsU68eF = new string[0];
		dDlVwlisBLS = new int[0];
		RJVVwN5cHMS = 1;
		QoMVwmmMQpe = false;
		GVoVwojJ9BK = new SortedList();
		P83VwGawLMQ = 0;
		y4AVwCAC0Yh = 0L;
		GCLVwpE6P4X = null;
		dlfVwOGQmcw = null;
		T1kVwnWkak5 = 0L;
		uWPVw78g9Br = 0;
		YtZVw5nSawh = false;
		wO7VwcdbIju = false;
		iEcVweSsGkg = 0;
		ra4VwyJ4ewv = IntPtr.Zero;
		P32VwXHs5u8 = false;
		X9NVwFar7JP = new Hashtable();
		lOnVwhDw2vP = null;
		gfyVwaBQbf6 = null;
		NWZVwqYmPOO = null;
		FjEVwPDZt6J = null;
		gvPVwACSnZR = null;
		Vj2Vwvxv5ug = null;
		HMyVwW9VJBv = IntPtr.Zero;
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	private void AKFVLW0YWeA()
	{
	}

	internal static byte[] yb6VStK7JQF(byte[] P_0)
	{
		uint[] array = new uint[16];
		uint num = (uint)((448 - P_0.Length * 8 % 512 + 512) % 512);
		if (num == 0)
		{
			num = 512u;
		}
		uint num2 = (uint)(P_0.Length + num / 8 + 8);
		ulong num3 = (ulong)P_0.Length * 8uL;
		byte[] array2 = new byte[num2];
		for (int i = 0; i < P_0.Length; i++)
		{
			array2[i] = P_0[i];
		}
		array2[P_0.Length] |= 128;
		for (int num4 = 8; num4 > 0; num4--)
		{
			array2[num2 - num4] = (byte)((num3 >> (8 - num4) * 8) & 0xFF);
		}
		uint num5 = (uint)(array2.Length * 8) / 32u;
		uint num6 = 1732584193u;
		uint num7 = 4023233417u;
		uint num8 = 2562383102u;
		uint num9 = 271733878u;
		for (uint num10 = 0u; num10 < num5 / 16; num10++)
		{
			uint num11 = num10 << 6;
			for (uint num12 = 0u; num12 < 61; num12 += 4)
			{
				array[num12 >> 2] = (uint)((array2[num11 + (num12 + 3)] << 24) | (array2[num11 + (num12 + 2)] << 16) | (array2[num11 + (num12 + 1)] << 8) | array2[num11 + num12]);
			}
			uint num13 = num6;
			uint num14 = num7;
			uint num15 = num8;
			uint num16 = num9;
			rABVSLgfaIV(ref num6, num7, num8, num9, 0u, 7, 1u, array);
			rABVSLgfaIV(ref num9, num6, num7, num8, 1u, 12, 2u, array);
			rABVSLgfaIV(ref num8, num9, num6, num7, 2u, 17, 3u, array);
			rABVSLgfaIV(ref num7, num8, num9, num6, 3u, 22, 4u, array);
			rABVSLgfaIV(ref num6, num7, num8, num9, 4u, 7, 5u, array);
			rABVSLgfaIV(ref num9, num6, num7, num8, 5u, 12, 6u, array);
			rABVSLgfaIV(ref num8, num9, num6, num7, 6u, 17, 7u, array);
			rABVSLgfaIV(ref num7, num8, num9, num6, 7u, 22, 8u, array);
			rABVSLgfaIV(ref num6, num7, num8, num9, 8u, 7, 9u, array);
			rABVSLgfaIV(ref num9, num6, num7, num8, 9u, 12, 10u, array);
			rABVSLgfaIV(ref num8, num9, num6, num7, 10u, 17, 11u, array);
			rABVSLgfaIV(ref num7, num8, num9, num6, 11u, 22, 12u, array);
			rABVSLgfaIV(ref num6, num7, num8, num9, 12u, 7, 13u, array);
			rABVSLgfaIV(ref num9, num6, num7, num8, 13u, 12, 14u, array);
			rABVSLgfaIV(ref num8, num9, num6, num7, 14u, 17, 15u, array);
			rABVSLgfaIV(ref num7, num8, num9, num6, 15u, 22, 16u, array);
			d3ZVSssx6X8(ref num6, num7, num8, num9, 1u, 5, 17u, array);
			d3ZVSssx6X8(ref num9, num6, num7, num8, 6u, 9, 18u, array);
			d3ZVSssx6X8(ref num8, num9, num6, num7, 11u, 14, 19u, array);
			d3ZVSssx6X8(ref num7, num8, num9, num6, 0u, 20, 20u, array);
			d3ZVSssx6X8(ref num6, num7, num8, num9, 5u, 5, 21u, array);
			d3ZVSssx6X8(ref num9, num6, num7, num8, 10u, 9, 22u, array);
			d3ZVSssx6X8(ref num8, num9, num6, num7, 15u, 14, 23u, array);
			d3ZVSssx6X8(ref num7, num8, num9, num6, 4u, 20, 24u, array);
			d3ZVSssx6X8(ref num6, num7, num8, num9, 9u, 5, 25u, array);
			d3ZVSssx6X8(ref num9, num6, num7, num8, 14u, 9, 26u, array);
			d3ZVSssx6X8(ref num8, num9, num6, num7, 3u, 14, 27u, array);
			d3ZVSssx6X8(ref num7, num8, num9, num6, 8u, 20, 28u, array);
			d3ZVSssx6X8(ref num6, num7, num8, num9, 13u, 5, 29u, array);
			d3ZVSssx6X8(ref num9, num6, num7, num8, 2u, 9, 30u, array);
			d3ZVSssx6X8(ref num8, num9, num6, num7, 7u, 14, 31u, array);
			d3ZVSssx6X8(ref num7, num8, num9, num6, 12u, 20, 32u, array);
			LQPVSlcK38P(ref num6, num7, num8, num9, 5u, 4, 33u, array);
			LQPVSlcK38P(ref num9, num6, num7, num8, 8u, 11, 34u, array);
			LQPVSlcK38P(ref num8, num9, num6, num7, 11u, 16, 35u, array);
			LQPVSlcK38P(ref num7, num8, num9, num6, 14u, 23, 36u, array);
			LQPVSlcK38P(ref num6, num7, num8, num9, 1u, 4, 37u, array);
			LQPVSlcK38P(ref num9, num6, num7, num8, 4u, 11, 38u, array);
			LQPVSlcK38P(ref num8, num9, num6, num7, 7u, 16, 39u, array);
			LQPVSlcK38P(ref num7, num8, num9, num6, 10u, 23, 40u, array);
			LQPVSlcK38P(ref num6, num7, num8, num9, 13u, 4, 41u, array);
			LQPVSlcK38P(ref num9, num6, num7, num8, 0u, 11, 42u, array);
			LQPVSlcK38P(ref num8, num9, num6, num7, 3u, 16, 43u, array);
			LQPVSlcK38P(ref num7, num8, num9, num6, 6u, 23, 44u, array);
			LQPVSlcK38P(ref num6, num7, num8, num9, 9u, 4, 45u, array);
			LQPVSlcK38P(ref num9, num6, num7, num8, 12u, 11, 46u, array);
			LQPVSlcK38P(ref num8, num9, num6, num7, 15u, 16, 47u, array);
			LQPVSlcK38P(ref num7, num8, num9, num6, 2u, 23, 48u, array);
			ROSVSNxeQva(ref num6, num7, num8, num9, 0u, 6, 49u, array);
			ROSVSNxeQva(ref num9, num6, num7, num8, 7u, 10, 50u, array);
			ROSVSNxeQva(ref num8, num9, num6, num7, 14u, 15, 51u, array);
			ROSVSNxeQva(ref num7, num8, num9, num6, 5u, 21, 52u, array);
			ROSVSNxeQva(ref num6, num7, num8, num9, 12u, 6, 53u, array);
			ROSVSNxeQva(ref num9, num6, num7, num8, 3u, 10, 54u, array);
			ROSVSNxeQva(ref num8, num9, num6, num7, 10u, 15, 55u, array);
			ROSVSNxeQva(ref num7, num8, num9, num6, 1u, 21, 56u, array);
			ROSVSNxeQva(ref num6, num7, num8, num9, 8u, 6, 57u, array);
			ROSVSNxeQva(ref num9, num6, num7, num8, 15u, 10, 58u, array);
			ROSVSNxeQva(ref num8, num9, num6, num7, 6u, 15, 59u, array);
			ROSVSNxeQva(ref num7, num8, num9, num6, 13u, 21, 60u, array);
			ROSVSNxeQva(ref num6, num7, num8, num9, 4u, 6, 61u, array);
			ROSVSNxeQva(ref num9, num6, num7, num8, 11u, 10, 62u, array);
			ROSVSNxeQva(ref num8, num9, num6, num7, 2u, 15, 63u, array);
			ROSVSNxeQva(ref num7, num8, num9, num6, 9u, 21, 64u, array);
			num6 += num13;
			num7 += num14;
			num8 += num15;
			num9 += num16;
		}
		byte[] array3 = new byte[16];
		Array.Copy(BitConverter.GetBytes(num6), 0, array3, 0, 4);
		Array.Copy(BitConverter.GetBytes(num7), 0, array3, 4, 4);
		Array.Copy(BitConverter.GetBytes(num8), 0, array3, 8, 4);
		Array.Copy(BitConverter.GetBytes(num9), 0, array3, 12, 4);
		return array3;
	}

	private static void rABVSLgfaIV(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + ClEVSmdvAVT(P_0 + ((P_1 & P_2) | (~P_1 & P_3)) + P_7[P_4] + Hd8VwKOKvhh[P_6 - 1], P_5);
	}

	private static void d3ZVSssx6X8(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + ClEVSmdvAVT(P_0 + ((P_1 & P_3) | (P_2 & ~P_3)) + P_7[P_4] + Hd8VwKOKvhh[P_6 - 1], P_5);
	}

	private static void LQPVSlcK38P(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + ClEVSmdvAVT(P_0 + (P_1 ^ P_2 ^ P_3) + P_7[P_4] + Hd8VwKOKvhh[P_6 - 1], P_5);
	}

	private static void ROSVSNxeQva(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
	{
		P_0 = P_1 + ClEVSmdvAVT(P_0 + (P_2 ^ (P_1 | ~P_3)) + P_7[P_4] + Hd8VwKOKvhh[P_6 - 1], P_5);
	}

	private static uint ClEVSmdvAVT(uint P_0, ushort P_1)
	{
		return (P_0 >> 32 - P_1) | (P_0 << (int)P_1);
	}

	internal static bool txAVSon061a()
	{
		if (!TLbVwEPcwER)
		{
			r5xVSpS7YWm();
			TLbVwEPcwER = true;
		}
		return KVKVw2yCJB8;
	}

	internal AiSseStreamService3()
	{
	}

	private void SLUVSGoY6ab(byte[] P_0, byte[] P_1, byte[] P_2)
	{
		int num = P_2.Length % 4;
		int num2 = P_2.Length / 4;
		byte[] array = new byte[P_2.Length];
		int num3 = P_0.Length / 4;
		uint num4 = 0u;
		uint num5 = 0u;
		uint num6 = 0u;
		if (num > 0)
		{
			num2++;
		}
		uint num7 = 0u;
		for (int i = 0; i < num2; i++)
		{
			int num8 = i % num3;
			int num9 = i * 4;
			num7 = (uint)(num8 * 4);
			num5 = (uint)((P_0[num7 + 3] << 24) | (P_0[num7 + 2] << 16) | (P_0[num7 + 1] << 8) | P_0[num7]);
			uint num10 = 255u;
			int num11 = 0;
			if (i == num2 - 1 && num > 0)
			{
				num6 = 0u;
				num4 += num5;
				for (int j = 0; j < num; j++)
				{
					if (j > 0)
					{
						num6 <<= 8;
					}
					num6 |= P_2[P_2.Length - (1 + j)];
				}
			}
			else
			{
				num4 += num5;
				num7 = (uint)num9;
				num6 = (uint)((P_2[num7 + 3] << 24) | (P_2[num7 + 2] << 16) | (P_2[num7 + 1] << 8) | P_2[num7]);
			}
			uint num12 = num4;
			num4 = 0u;
			uint num13 = num12;
			uint num14 = 681281522u;
			uint num15 = 140139475u;
			uint num16 = 1160141341u;
			uint num17 = 16362263u;
			if (num13 == 0)
			{
				num13--;
			}
			uint num18 = num16 / num13 + num13;
			num13 = ((num15 - num16) ^ num18) + num15;
			num16 = 8100471 * (num16 & 0x1FF) - (num16 >> 9);
			num13 = 8322706 * (num13 & 0x1FF) - (num13 >> 9);
			num15 = 11422 * num15 - num14;
			if (num15 == 0)
			{
				num15--;
			}
			num18 = num13 / num15 + num15;
			num15 = num13 + num13 + num18 + num13;
			uint num19 = num16 & 0xF0F0F0F;
			uint num20 = num16 & 0xF0F0F0F0u;
			num19 = ((num19 >> 4) | (num20 << 4)) ^ num13;
			num16 = (num16 << 8) | (num16 >> 24);
			num14 = 32268 * (num14 & 0x1FFFF) + (num14 >> 17);
			num15 = 8576 * (num15 & 0x1FFFF) + (num15 >> 17);
			num13 = 37358 * num13 - num16;
			num13 ^= num13 << 23;
			num13 += num15;
			num13 ^= num13 >> 9;
			num13 += num16;
			num13 ^= num13 << 12;
			num13 += num17;
			num13 = (((num13 << 6) - num15) ^ num15) + num13;
			num4 = num12 + (uint)(double)num13;
			if (i == num2 - 1 && num > 0)
			{
				uint num21 = num4 ^ num6;
				for (int k = 0; k < num; k++)
				{
					if (k > 0)
					{
						num10 <<= 8;
						num11 += 8;
					}
					array[num9 + k] = (byte)((num21 & num10) >> num11);
				}
			}
			else
			{
				uint num22 = num4 ^ num6;
				array[num9] = (byte)(num22 & 0xFF);
				array[num9 + 1] = (byte)((num22 & 0xFF00) >> 8);
				array[num9 + 2] = (byte)((num22 & 0xFF0000) >> 16);
				array[num9 + 3] = (byte)((num22 & 0xFF000000u) >> 24);
			}
		}
		lhSVwSSh4rK = array;
	}

	internal static SymmetricAlgorithm iI8VSCYGOW0()
	{
		SymmetricAlgorithm symmetricAlgorithm = null;
		if (txAVSon061a())
		{
			return new AesCryptoServiceProvider();
		}
		try
		{
			return new RijndaelManaged();
		}
		catch
		{
			try
			{
				return (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
			}
			catch
			{
				return (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
			}
		}
	}

	internal static void r5xVSpS7YWm()
	{
		try
		{
			new MD5CryptoServiceProvider();
		}
		catch
		{
			KVKVw2yCJB8 = true;
			return;
		}
		try
		{
			KVKVw2yCJB8 = CryptoConfig.AllowOnlyFipsAlgorithms;
		}
		catch
		{
		}
	}

	internal static byte[] I0YVSOaKkT7(byte[] P_0)
	{
		if (!txAVSon061a())
		{
			return new MD5CryptoServiceProvider().ComputeHash(P_0);
		}
		return yb6VStK7JQF(P_0);
	}

	internal static void f2hVSnrfd3P(HashAlgorithm P_0, Stream P_1, uint P_2, byte[] P_3)
	{
		while (P_2 != 0)
		{
			int num = ((P_2 > (uint)P_3.Length) ? P_3.Length : ((int)P_2));
			P_1.Read(P_3, 0, num);
			anJVS7vdfNA(P_0, P_3, 0, num);
			P_2 -= (uint)num;
		}
	}

	internal static void anJVS7vdfNA(HashAlgorithm P_0, byte[] P_1, int P_2, int P_3)
	{
		P_0.TransformBlock(P_1, P_2, P_3, P_1, P_2);
	}

	internal static uint kOlVS51UlUR(uint P_0, int P_1, long P_2, BinaryReader P_3)
	{
		for (int i = 0; i < P_1; i++)
		{
			P_3.BaseStream.Position = P_2 + (i * 40 + 8);
			uint num = P_3.ReadUInt32();
			uint num2 = P_3.ReadUInt32();
			P_3.ReadUInt32();
			uint num3 = P_3.ReadUInt32();
			if (num2 <= P_0 && P_0 < num2 + num)
			{
				return num3 + P_0 - num2;
			}
		}
		return 0u;
	}

	public static void R1WVSc3XvLY(RuntimeTypeHandle P_0)
	{
		try
		{
			Type typeFromHandle = Type.GetTypeFromHandle(P_0);
			if (UCNVwjjwmBX == null)
			{
				lock (lL2VwY3JnIT)
				{
					Dictionary<int, int> dictionary = new Dictionary<int, int>();
					BinaryReader binaryReader = new BinaryReader(typeof(AiSseStreamService3).Assembly.GetManifestResourceStream("2BWb04irCgC5cG0Wfb.3XyKq7HoOCWibfsyqt"));
					binaryReader.BaseStream.Position = 0L;
					byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
					binaryReader.Close();
					if (array.Length != 0)
					{
						int num = array.Length % 4;
						int num2 = array.Length / 4;
						byte[] array2 = new byte[array.Length];
						uint num3 = 0u;
						uint num4 = 0u;
						if (num > 0)
						{
							num2++;
						}
						uint num5 = 0u;
						for (int i = 0; i < num2; i++)
						{
							int num6 = i * 4;
							uint num7 = 255u;
							int num8 = 0;
							if (i == num2 - 1 && num > 0)
							{
								num4 = 0u;
								for (int j = 0; j < num; j++)
								{
									if (j > 0)
									{
										num4 <<= 8;
									}
									num4 |= array[array.Length - (1 + j)];
								}
							}
							else
							{
								num5 = (uint)num6;
								num4 = (uint)((array[num5 + 3] << 24) | (array[num5 + 2] << 16) | (array[num5 + 1] << 8) | array[num5]);
							}
							num3 = num3;
							num3 += a3dVSXOGFZb(num3);
							if (i == num2 - 1 && num > 0)
							{
								uint num9 = num3 ^ num4;
								for (int k = 0; k < num; k++)
								{
									if (k > 0)
									{
										num7 <<= 8;
										num8 += 8;
									}
									array2[num6 + k] = (byte)((num9 & num7) >> num8);
								}
							}
							else
							{
								uint num10 = num3 ^ num4;
								array2[num6] = (byte)(num10 & 0xFF);
								array2[num6 + 1] = (byte)((num10 & 0xFF00) >> 8);
								array2[num6 + 2] = (byte)((num10 & 0xFF0000) >> 16);
								array2[num6 + 3] = (byte)((num10 & 0xFF000000u) >> 24);
							}
						}
						array = array2;
						array2 = null;
						int num11 = array.Length / 8;
						pG2pc9VtDNfcA9tWEu1l pG2pc9VtDNfcA9tWEu1l2 = new pG2pc9VtDNfcA9tWEu1l(new MemoryStream(array));
						for (int l = 0; l < num11; l++)
						{
							int key = pG2pc9VtDNfcA9tWEu1l2.xTbVt8qBXiV();
							int value = pG2pc9VtDNfcA9tWEu1l2.xTbVt8qBXiV();
							dictionary.Add(key, value);
						}
						pG2pc9VtDNfcA9tWEu1l2.nloVtInXWpT();
					}
					UCNVwjjwmBX = dictionary;
				}
			}
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			for (int m = 0; m < fields.Length; m++)
			{
				try
				{
					FieldInfo fieldInfo = fields[m];
					int metadataToken = fieldInfo.MetadataToken;
					int num12 = UCNVwjjwmBX[metadataToken];
					bool flag = (num12 & 0x40000000) > 0;
					num12 &= 0x3FFFFFFF;
					MethodInfo methodInfo = (MethodInfo)typeof(AiSseStreamService3).Module.ResolveMethod(num12, typeFromHandle.GetGenericArguments(), new Type[0]);
					if (methodInfo.IsStatic)
					{
						fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo));
						continue;
					}
					ParameterInfo[] parameters = methodInfo.GetParameters();
					int num13 = parameters.Length + 1;
					Type[] array3 = new Type[num13];
					if (methodInfo.DeclaringType.IsValueType)
					{
						array3[0] = methodInfo.DeclaringType.MakeByRefType();
					}
					else
					{
						array3[0] = typeof(object);
					}
					for (int n = 0; n < parameters.Length; n++)
					{
						array3[n + 1] = parameters[n].ParameterType;
					}
					DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array3, typeFromHandle, skipVisibility: true);
					ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
					for (int num14 = 0; num14 < num13; num14++)
					{
						switch (num14)
						{
						case 0:
							iLGenerator.Emit(OpCodes.Ldarg_0);
							break;
						case 1:
							iLGenerator.Emit(OpCodes.Ldarg_1);
							break;
						case 2:
							iLGenerator.Emit(OpCodes.Ldarg_2);
							break;
						case 3:
							iLGenerator.Emit(OpCodes.Ldarg_3);
							break;
						default:
							iLGenerator.Emit(OpCodes.Ldarg_S, num14);
							break;
						}
					}
					iLGenerator.Emit(OpCodes.Tailcall);
					iLGenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
					iLGenerator.Emit(OpCodes.Ret);
					fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeFromHandle));
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static uint FF8VSy3IcAt(uint P_0)
	{
		return (uint)"{11111-22222-10009-11112}".Length;
	}

	private static uint a3dVSXOGFZb(uint P_0)
	{
		return 0u;
	}

	internal static void EcOVSFFwcdv()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Uo9VShsM3hK(Stream P_0, int P_1)
	{
		int num = 221;
		byte[] array = default(byte[]);
		int num6 = default(int);
		byte[] array2 = default(byte[]);
		int num5 = default(int);
		int num3 = default(int);
		int num4 = default(int);
		byte[] array3 = default(byte[]);
		byte[] array4 = default(byte[]);
		byte[] array6 = default(byte[]);
		Stream stream = default(Stream);
		byte[] array5 = default(byte[]);
		int num7 = default(int);
		ICryptoTransform transform = default(ICryptoTransform);
		while (true)
		{
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 27:
					array[11] = (byte)num6;
					num2 = 110;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 239;
					}
					continue;
				case 238:
					array[10] = 168;
					num2 = 320;
					continue;
				case 326:
					array2[4] = 49;
					num2 = 191;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 74;
					}
					continue;
				case 191:
					num5 = 108 + 114;
					num2 = 78;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 97;
					}
					continue;
				case 4:
					array[0] = (byte)num6;
					num2 = 29;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 38;
					}
					continue;
				case 106:
					array[1] = 220;
					num2 = 204;
					continue;
				case 197:
					array2[18] = 136;
					num2 = 124;
					continue;
				case 198:
					array[14] = (byte)num3;
					num = 260;
					break;
				case 202:
					array2[21] = 132;
					num2 = 94;
					continue;
				case 229:
					array2[11] = 28;
					num2 = 1;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 99;
					}
					continue;
				case 7:
					array[12] = 109;
					num2 = 69;
					continue;
				case 104:
					array2[6] = 92;
					num2 = 23;
					continue;
				case 6:
					array2[22] = (byte)num4;
					num = 46;
					break;
				case 131:
					array2[13] = (byte)num4;
					num2 = 196;
					continue;
				case 115:
					array[8] = (byte)num3;
					num2 = 335;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 246;
					}
					continue;
				case 119:
					num5 = 144 - 107;
					num2 = 29;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 21;
					}
					continue;
				case 97:
					array2[5] = (byte)num5;
					num2 = 80;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 268;
					}
					continue;
				case 349:
					num6 = 147 - 49;
					num2 = 77;
					continue;
				case 205:
					num6 = 170 - 56;
					num2 = 75;
					continue;
				case 137:
					array[14] = 75;
					num2 = 1;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 1;
					}
					continue;
				case 9:
					array3[15] = array4[7];
					num2 = 132;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 284;
					}
					continue;
				case 278:
					array[0] = (byte)num6;
					num2 = 63;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 14;
					}
					continue;
				case 266:
					array[7] = (byte)num6;
					num = 57;
					break;
				case 328:
					array[1] = 88;
					num2 = 126;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 188;
					}
					continue;
				case 13:
					num3 = 15 + 122;
					num2 = 261;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 303;
					}
					continue;
				case 59:
					num3 = 213 - 71;
					num2 = 96;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 62;
					}
					continue;
				case 316:
					array2[29] = (byte)num4;
					num2 = 190;
					continue;
				case 314:
					num5 = 8 + 94;
					num = 187;
					break;
				case 308:
					num6 = 239 - 79;
					num2 = 49;
					continue;
				case 58:
					num4 = 175 - 58;
					num2 = 347;
					continue;
				case 72:
					array2[23] = 98;
					num2 = 139;
					continue;
				case 204:
					num6 = 22 + 87;
					num = 121;
					break;
				case 87:
					array6 = lhSVwSSh4rK;
					num2 = 206;
					continue;
				case 293:
					array2[11] = (byte)num5;
					num2 = 287;
					continue;
				case 338:
					array2[17] = (byte)num5;
					num2 = 274;
					continue;
				case 65:
					array[8] = 115;
					num2 = 59;
					continue;
				case 335:
					array[8] = 118;
					num2 = 160;
					continue;
				case 155:
					array[12] = 73;
					num2 = 309;
					continue;
				case 25:
					array2[27] = (byte)num5;
					num = 32;
					break;
				case 323:
					num6 = 238 - 79;
					num = 278;
					break;
				case 156:
					num5 = 165 - 55;
					num2 = 36;
					continue;
				case 245:
					array2[30] = (byte)num5;
					num2 = 34;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 117;
					}
					continue;
				case 68:
					num5 = 151 - 107;
					num2 = 218;
					continue;
				case 258:
					array2[28] = 7;
					num2 = 327;
					continue;
				case 225:
					num3 = 161 - 53;
					num2 = 199;
					continue;
				case 269:
					array[10] = 200;
					num2 = 334;
					continue;
				case 178:
					num6 = 213 - 71;
					num2 = 66;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 49;
					}
					continue;
				case 215:
					array2[17] = (byte)num4;
					num2 = 170;
					continue;
				case 147:
					array2[3] = 131;
					num2 = 246;
					continue;
				case 356:
					array[7] = (byte)num6;
					num2 = 173;
					continue;
				case 339:
					num5 = 152 - 50;
					num2 = 200;
					continue;
				case 10:
					array[8] = (byte)num6;
					num2 = 65;
					continue;
				case 199:
					array[4] = (byte)num3;
					num2 = 109;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 95;
					}
					continue;
				case 230:
					num5 = 230 - 76;
					num2 = 17;
					continue;
				case 26:
					num5 = 38 + 63;
					num2 = 336;
					continue;
				case 85:
					array2[8] = (byte)num4;
					num2 = 58;
					continue;
				case 254:
					array2[2] = 88;
					num2 = 359;
					continue;
				case 232:
					num5 = 74 + 58;
					num2 = 40;
					continue;
				case 29:
					array2[19] = (byte)num5;
					num2 = 24;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 26;
					}
					continue;
				case 89:
					array2[14] = 132;
					num2 = 149;
					continue;
				case 165:
					array2[11] = 91;
					num2 = 172;
					continue;
				case 344:
					if (array4.Length == 0)
					{
						num2 = 91;
						if (zZkkIgVLmB2l0yHbdVg6() == null)
						{
							num2 = 158;
						}
						continue;
					}
					goto case 212;
				case 122:
					array2[20] = 208;
					num2 = 35;
					continue;
				case 91:
					num6 = 21 + 73;
					num2 = 27;
					continue;
				case 345:
					array2[26] = (byte)num5;
					num2 = 232;
					continue;
				case 211:
					num3 = 117 + 51;
					num2 = 18;
					continue;
				case 288:
					array3[11] = array4[5];
					num2 = 129;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 210;
					}
					continue;
				case 298:
					stream = (Stream)RysAegVLXHrEwKOvoDBR();
					num2 = 159;
					continue;
				case 11:
					num4 = 252 - 84;
					num2 = 279;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 148;
					}
					continue;
				case 92:
					array[15] = (byte)num3;
					num2 = 81;
					continue;
				case 48:
					num5 = 29 + 15;
					num2 = 338;
					continue;
				case 32:
					num4 = 54 + 42;
					num2 = 241;
					continue;
				case 292:
					array2[9] = 124;
					num2 = 306;
					continue;
				case 63:
					array[0] = 246;
					num2 = 152;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 317;
					}
					continue;
				case 172:
					num4 = 44 + 71;
					num2 = 28;
					continue;
				case 242:
					array2[7] = (byte)num5;
					num2 = 133;
					continue;
				case 135:
					array[14] = (byte)num3;
					num2 = 153;
					continue;
				case 126:
					array2[3] = (byte)num4;
					num2 = 4;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 52;
					}
					continue;
				case 209:
					array2[13] = 145;
					num2 = 259;
					continue;
				case 354:
					array[0] = 68;
					num2 = 276;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 23;
					}
					continue;
				case 18:
					array[5] = (byte)num3;
					num2 = 231;
					continue;
				case 128:
					array2[11] = 140;
					num2 = 229;
					continue;
				case 98:
					array2[26] = 77;
					num2 = 74;
					continue;
				case 80:
					num5 = 254 - 84;
					num2 = 25;
					continue;
				case 154:
					array2[1] = (byte)num5;
					num2 = 53;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 254;
					}
					continue;
				case 279:
					array2[8] = (byte)num4;
					num2 = 264;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 265;
					}
					continue;
				case 28:
					array2[12] = (byte)num4;
					num2 = 332;
					continue;
				case 50:
					array5 = array2;
					num2 = 193;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 85;
					}
					continue;
				case 273:
					array2[2] = (byte)num5;
					num2 = 101;
					continue;
				case 253:
					array[9] = 160;
					num2 = 130;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 163;
					}
					continue;
				case 114:
					array2[28] = 110;
					num = 258;
					break;
				case 301:
					return;
				case 291:
					array2[10] = 81;
					num2 = 104;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 167;
					}
					continue;
				case 45:
					array2[23] = (byte)num5;
					num2 = 103;
					continue;
				case 43:
					array2[2] = 75;
					num2 = 281;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 280;
					}
					continue;
				case 246:
					num5 = 33 + 61;
					num2 = 86;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 27;
					}
					continue;
				case 170:
					array2[18] = 139;
					num2 = 110;
					continue;
				case 240:
					num3 = 150 - 53;
					num2 = 88;
					continue;
				case 94:
					array2[21] = 156;
					num2 = 175;
					continue;
				case 327:
					array2[29] = 170;
					num2 = 194;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 156;
					}
					continue;
				case 325:
					num3 = 198 - 66;
					num2 = 136;
					continue;
				case 348:
					num3 = 90 + 99;
					num2 = 104;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 248;
					}
					continue;
				case 193:
					array = new byte[16];
					num2 = 354;
					continue;
				case 358:
					num5 = 72 - 43;
					num2 = 76;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 154;
					}
					continue;
				case 70:
					array2[1] = (byte)num4;
					num2 = 358;
					continue;
				case 239:
					num3 = 19 + 95;
					num2 = 252;
					continue;
				case 99:
					num5 = 61 + 17;
					num2 = 42;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 293;
					}
					continue;
				case 103:
					array2[24] = 117;
					num2 = 39;
					continue;
				case 96:
					array[8] = (byte)num3;
					num2 = 240;
					continue;
				case 30:
					array[2] = (byte)num6;
					num2 = 95;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 6;
					}
					continue;
				case 152:
					array2[15] = (byte)num4;
					num2 = 264;
					continue;
				case 353:
					array[10] = 182;
					num2 = 238;
					continue;
				case 168:
					num4 = 161 - 53;
					num2 = 70;
					continue;
				case 260:
					num6 = 26 + 116;
					num = 31;
					break;
				case 55:
					array2[31] = (byte)num5;
					num2 = 183;
					continue;
				case 333:
					array2[25] = 107;
					num2 = 277;
					continue;
				case 259:
					num4 = 235 - 78;
					num = 131;
					break;
				case 217:
					array[3] = 64;
					num2 = 195;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 228;
					}
					continue;
				case 35:
					array2[20] = 92;
					num2 = 176;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 189;
					}
					continue;
				case 83:
					num5 = 126 - 42;
					num2 = 216;
					continue;
				case 150:
					array2[12] = 165;
					num2 = 68;
					continue;
				case 107:
					array[7] = (byte)num3;
					num2 = 0;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 2;
					}
					continue;
				case 62:
					array[15] = 46;
					num2 = 16;
					continue;
				case 187:
					array2[18] = (byte)num5;
					num2 = 156;
					continue;
				case 305:
					array2[25] = 43;
					num2 = 98;
					continue;
				case 93:
					num5 = 216 - 72;
					num2 = 87;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 245;
					}
					continue;
				case 39:
					array2[24] = 103;
					num2 = 235;
					continue;
				case 352:
					array[7] = (byte)num6;
					num = 351;
					break;
				case 261:
					array2[15] = (byte)num4;
					num2 = 275;
					continue;
				case 252:
					array[11] = (byte)num3;
					num2 = 244;
					continue;
				case 16:
					num3 = 169 + 79;
					num2 = 92;
					continue;
				case 264:
					num4 = 133 - 44;
					num = 15;
					break;
				case 337:
					num7++;
					num = 310;
					break;
				case 201:
					array[13] = 51;
					num2 = 13;
					continue;
				case 346:
					array2[30] = 106;
					num2 = 192;
					continue;
				case 111:
					array[9] = (byte)num3;
					num2 = 24;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 269;
					}
					continue;
				case 60:
					array2[4] = (byte)num4;
					num2 = 148;
					continue;
				case 153:
					array[14] = 114;
					num2 = 222;
					continue;
				case 14:
					num4 = 134 + 108;
					num2 = 0;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 0;
					}
					continue;
				case 56:
					array[15] = (byte)num6;
					num2 = 62;
					continue;
				case 251:
					num4 = 64 + 11;
					num2 = 152;
					continue;
				case 243:
					array2[31] = (byte)num4;
					num2 = 50;
					continue;
				case 249:
					array[3] = 154;
					num2 = 3;
					continue;
				case 236:
					array2[6] = 68;
					num2 = 174;
					continue;
				case 307:
					array2[23] = (byte)num5;
					num2 = 312;
					continue;
				case 312:
					num5 = 141 - 106;
					num2 = 16;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 45;
					}
					continue;
				case 108:
					array2[28] = 83;
					num2 = 114;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 83;
					}
					continue;
				case 46:
					array2[22] = 169;
					num2 = 90;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 5;
					}
					continue;
				case 88:
					array[8] = (byte)num3;
					num2 = 178;
					continue;
				case 31:
					array[15] = (byte)num6;
					num2 = 76;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 151;
					}
					continue;
				case 44:
					array2[19] = 154;
					num2 = 119;
					continue;
				case 270:
					array[11] = (byte)num6;
					num2 = 233;
					continue;
				case 222:
					array[14] = 132;
					num2 = 112;
					continue;
				case 180:
					array2[9] = (byte)num4;
					num2 = 132;
					continue;
				case 313:
					num5 = 103 + 73;
					num2 = 242;
					continue;
				case 177:
					array2[9] = 165;
					num2 = 292;
					continue;
				case 163:
					num3 = 81 - 42;
					num2 = 111;
					continue;
				case 75:
					array[10] = (byte)num6;
					num2 = 353;
					continue;
				case 159:
				{
					CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write);
					F4qHdaVLFaJailqkY8yG(cryptoStream, array6, 0, array6.Length);
					CakkBIVLhD8uxhEEn6oP(cryptoStream);
					lhSVwSSh4rK = (byte[])KYPMC0VLaAomMaeM6Uk7(stream);
					y2Ta8HVLqncaAeXCduaF(stream);
					y2Ta8HVLqncaAeXCduaF(cryptoStream);
					num2 = 33;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 87;
					}
					continue;
				}
				case 167:
					array2[10] = 161;
					num2 = 97;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 227;
					}
					continue;
				case 276:
					num6 = 51 + 118;
					num2 = 0;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 4;
					}
					continue;
				case 224:
					array2[30] = (byte)num5;
					num2 = 271;
					continue;
				case 268:
					array2[5] = 211;
					num2 = 118;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 23;
					}
					continue;
				case 218:
					array2[12] = (byte)num5;
					num = 209;
					break;
				case 38:
					array[0] = 142;
					num2 = 182;
					continue;
				case 134:
					num4 = 32 + 116;
					num2 = 343;
					continue;
				case 241:
					array2[27] = (byte)num4;
					num2 = 195;
					continue;
				case 5:
					num4 = 117 - 82;
					num2 = 316;
					continue;
				case 220:
					array2 = new byte[32];
					num2 = 131;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 340;
					}
					continue;
				case 78:
				case 125:
					new AiSseStreamService3().SLUVSGoY6ab(array5, array3, array6);
					num2 = 301;
					continue;
				case 233:
					array[11] = 205;
					num2 = 348;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 61;
					}
					continue;
				case 311:
					array2[2] = (byte)num5;
					num2 = 43;
					continue;
				case 148:
					num4 = 18 + 21;
					num2 = 64;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 142;
					}
					continue;
				case 127:
					array2[12] = 103;
					num2 = 150;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 98;
					}
					continue;
				case 132:
					array2[9] = 190;
					num2 = 366;
					continue;
				case 213:
					array2[4] = 221;
					num2 = 234;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 326;
					}
					continue;
				case 306:
					num4 = 216 - 72;
					num2 = 180;
					continue;
				case 160:
					num6 = 232 - 77;
					num2 = 10;
					continue;
				case 194:
					num5 = 116 + 110;
					num2 = 171;
					continue;
				case 86:
					array2[4] = (byte)num5;
					num2 = 289;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 215;
					}
					continue;
				case 22:
					array[2] = (byte)num6;
					num2 = 157;
					continue;
				case 256:
					array2[16] = 144;
					num2 = 37;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 13;
					}
					continue;
				case 190:
					array2[30] = 219;
					num2 = 121;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 346;
					}
					continue;
				case 130:
					num4 = 133 - 44;
					num2 = 238;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 243;
					}
					continue;
				case 20:
					QwDss4VLndQTLjAoLp6X(array3);
					num2 = 263;
					continue;
				case 90:
					array2[22] = 65;
					num2 = 83;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 257;
					}
					continue;
				case 319:
					array2[3] = (byte)num5;
					num2 = 282;
					continue;
				case 42:
					num4 = 238 - 79;
					num2 = 324;
					continue;
				case 290:
					array2[0] = (byte)num4;
					num2 = 8;
					continue;
				default:
					array2[6] = (byte)num4;
					num2 = 47;
					continue;
				case 342:
					num5 = 182 - 60;
					num2 = 319;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 238;
					}
					continue;
				case 223:
					array2[17] = (byte)num4;
					num2 = 321;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 232;
					}
					continue;
				case 257:
					num4 = 177 - 59;
					num2 = 330;
					continue;
				case 329:
					num4 = 52 + 107;
					num2 = 123;
					continue;
				case 67:
					array[5] = 155;
					num2 = 211;
					continue;
				case 262:
					array2[16] = (byte)num4;
					num2 = 24;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 20;
					}
					continue;
				case 121:
					array[2] = (byte)num6;
					num2 = 302;
					continue;
				case 117:
					num5 = 131 - 61;
					num = 224;
					break;
				case 315:
					array2[31] = 151;
					num2 = 162;
					continue;
				case 360:
					array2[25] = (byte)num4;
					num2 = 333;
					continue;
				case 24:
					array2[16] = 146;
					num2 = 299;
					continue;
				case 310:
				case 331:
					if (num7 >= array3.Length)
					{
						num2 = 318;
						if (!L60ZsqVLNiYGf6Wn3Rd6())
						{
							num2 = 141;
						}
						continue;
					}
					goto case 71;
				case 235:
					array2[24] = 156;
					num2 = 33;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 8;
					}
					continue;
				case 100:
					array2[6] = (byte)num4;
					num2 = 236;
					continue;
				case 227:
					array2[10] = 182;
					num = 138;
					break;
				case 1:
					num3 = 72 - 8;
					num2 = 198;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 107;
					}
					continue;
				case 116:
					num4 = 53 + 58;
					num2 = 85;
					continue;
				case 157:
					num6 = 129 - 52;
					num2 = 30;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 29;
					}
					continue;
				case 110:
					array2[18] = 126;
					num2 = 231;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 314;
					}
					continue;
				case 366:
					array2[9] = 94;
					num2 = 291;
					continue;
				case 250:
					array2[20] = (byte)num5;
					num2 = 134;
					continue;
				case 302:
					num6 = 150 - 50;
					num2 = 21;
					continue;
				case 112:
					array[14] = 154;
					num2 = 137;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 85;
					}
					continue;
				case 79:
					num4 = 213 - 71;
					num = 64;
					break;
				case 359:
					num5 = 246 - 82;
					num2 = 273;
					continue;
				case 287:
					array2[11] = 145;
					num2 = 165;
					continue;
				case 2:
					num6 = 48 + 20;
					num2 = 356;
					continue;
				case 176:
					num5 = 190 - 63;
					num2 = 345;
					continue;
				case 281:
					num5 = 87 + 52;
					num2 = 143;
					continue;
				case 173:
					num6 = 25 + 96;
					num2 = 266;
					continue;
				case 81:
					array3 = array;
					num2 = 20;
					continue;
				case 120:
					array[1] = 89;
					num2 = 318;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 364;
					}
					continue;
				case 364:
					array[1] = 142;
					num2 = 106;
					continue;
				case 141:
					array3[9] = array4[4];
					num2 = 288;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 240;
					}
					continue;
				case 138:
					num5 = 125 + 21;
					num2 = 322;
					continue;
				case 317:
					num6 = 86 + 34;
					num2 = 296;
					continue;
				case 57:
					num6 = 104 - 85;
					num2 = 352;
					continue;
				case 299:
					array2[16] = 152;
					num2 = 172;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 300;
					}
					continue;
				case 365:
					num6 = 44 + 61;
					num = 270;
					break;
				case 206:
					if (!QVqeqBVLAe2qVaYQ9Z2r(qKt29EVLPLn4wAeiyG3L(auHVwUyvsY2), null))
					{
						num2 = 125;
						continue;
					}
					goto case 185;
				case 76:
					array3[3] = array4[1];
					num2 = 241;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 341;
					}
					continue;
				case 320:
					num3 = 179 - 120;
					num2 = 186;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 294;
					}
					continue;
				case 184:
					num4 = 191 - 63;
					num2 = 360;
					continue;
				case 69:
					array[12] = 101;
					num2 = 155;
					continue;
				case 49:
					array[9] = (byte)num6;
					num2 = 91;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 161;
					}
					continue;
				case 158:
				case 284:
				case 362:
					num7 = 0;
					num2 = 331;
					continue;
				case 221:
				{
					pG2pc9VtDNfcA9tWEu1l obj2 = new pG2pc9VtDNfcA9tWEu1l(P_0);
					WwfRCQVLGM2cCHodUlSD(N09gCxVLoXsSbvCFUhE5(obj2), 0L);
					array6 = (byte[])N50yaRVLp1I9b3cFxKuL(obj2, (int)qV2gcSVLCtWOMSUiGCTD(N09gCxVLoXsSbvCFUhE5(obj2)));
					c99WaNVLOwXmdXwWaVXB(obj2);
					num2 = 220;
					continue;
				}
				case 228:
					num6 = 33 + 61;
					num2 = 84;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 65;
					}
					continue;
				case 350:
					array[4] = (byte)num6;
					num2 = 349;
					continue;
				case 15:
					array2[15] = (byte)num4;
					num2 = 339;
					continue;
				case 143:
					array2[2] = (byte)num5;
					num2 = 251;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 272;
					}
					continue;
				case 361:
					num5 = 78 + 91;
					num2 = 55;
					continue;
				case 140:
					array2[27] = 90;
					num2 = 80;
					continue;
				case 283:
					num5 = 41 + 19;
					num2 = 179;
					continue;
				case 179:
					array2[3] = (byte)num5;
					num2 = 342;
					continue;
				case 294:
					array[10] = (byte)num3;
					num2 = 91;
					continue;
				case 151:
					num6 = 54 + 4;
					num2 = 43;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 56;
					}
					continue;
				case 34:
					num4 = 54 + 54;
					num2 = 261;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 64;
					}
					continue;
				case 212:
					array3[1] = array4[0];
					num2 = 19;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 76;
					}
					continue;
				case 248:
					array[11] = (byte)num3;
					num2 = 146;
					continue;
				case 17:
					array2[22] = (byte)num5;
					num2 = 39;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 54;
					}
					continue;
				case 324:
					array2[3] = (byte)num4;
					num2 = 126;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 147;
					}
					continue;
				case 330:
					array2[23] = (byte)num4;
					num2 = 285;
					continue;
				case 304:
					array2[0] = 182;
					num2 = 53;
					continue;
				case 274:
					num4 = 33 + 63;
					num2 = 223;
					continue;
				case 144:
					array2[1] = (byte)num4;
					num2 = 168;
					continue;
				case 363:
					num5 = 14 + 113;
					num2 = 19;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 6;
					}
					continue;
				case 183:
					array2[31] = 142;
					num2 = 315;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 229;
					}
					continue;
				case 82:
					array[6] = 168;
					num2 = 325;
					continue;
				case 36:
					array2[18] = (byte)num5;
					num2 = 186;
					continue;
				case 109:
					num6 = 170 - 108;
					num = 350;
					break;
				case 41:
					array2[14] = (byte)num5;
					num2 = 164;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 251;
					}
					continue;
				case 196:
					num5 = 45 + 108;
					num2 = 71;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 129;
					}
					continue;
				case 146:
					array[12] = 133;
					num2 = 7;
					continue;
				case 166:
					array2[16] = (byte)num5;
					num2 = 44;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 48;
					}
					continue;
				case 271:
					array2[31] = 81;
					num2 = 361;
					continue;
				case 51:
					array2[30] = 184;
					num2 = 93;
					continue;
				case 133:
					array2[7] = 251;
					num2 = 79;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 66;
					}
					continue;
				case 195:
					array2[27] = 22;
					num2 = 108;
					continue;
				case 189:
					num5 = 83 - 68;
					num2 = 250;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 195;
					}
					continue;
				case 161:
					array[9] = 47;
					num2 = 267;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 187;
					}
					continue;
				case 54:
					num4 = 21 + 105;
					num2 = 6;
					continue;
				case 231:
					num3 = 197 - 114;
					num2 = 247;
					continue;
				case 341:
					array3[5] = array4[2];
					num2 = 297;
					continue;
				case 280:
					array2[11] = 119;
					num2 = 128;
					continue;
				case 47:
					array2[7] = 118;
					num2 = 313;
					continue;
				case 74:
					array2[26] = 160;
					num2 = 363;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 124;
					}
					continue;
				case 162:
					array2[31] = 118;
					num2 = 130;
					continue;
				case 19:
					array2[26] = (byte)num5;
					num = 214;
					break;
				case 355:
					if (array4 == null)
					{
						num2 = 362;
						if (zZkkIgVLmB2l0yHbdVg6() != null)
						{
							num2 = 206;
						}
						continue;
					}
					goto case 344;
				case 142:
					array2[4] = (byte)num4;
					num2 = 116;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 213;
					}
					continue;
				case 33:
					array2[24] = 70;
					num2 = 255;
					continue;
				case 77:
					array[5] = (byte)num6;
					num2 = 67;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 37;
					}
					continue;
				case 169:
					array[11] = (byte)num3;
					num = 365;
					break;
				case 275:
					array2[15] = 205;
					num2 = 83;
					continue;
				case 102:
					array2[0] = (byte)num5;
					num2 = 304;
					continue;
				case 84:
					array[4] = (byte)num6;
					num2 = 225;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 161;
					}
					continue;
				case 336:
					array2[20] = (byte)num5;
					num2 = 122;
					continue;
				case 12:
					num3 = 165 - 55;
					num2 = 135;
					continue;
				case 185:
					pLiVwZWwirQ = 80;
					num2 = 1;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 78;
					}
					continue;
				case 296:
					array[1] = (byte)num6;
					num2 = 328;
					continue;
				case 53:
					array2[0] = 217;
					num2 = 357;
					continue;
				case 3:
					array[3] = 159;
					num = 217;
					break;
				case 272:
					array2[2] = 59;
					num2 = 283;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 60;
					}
					continue;
				case 234:
					num4 = 65 + 110;
					num2 = 100;
					continue;
				case 216:
					array2[16] = (byte)num5;
					num2 = 24;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 256;
					}
					continue;
				case 210:
					array3[13] = array4[6];
					num2 = 9;
					continue;
				case 300:
					num5 = 63 - 3;
					num2 = 166;
					continue;
				case 247:
					array[5] = (byte)num3;
					num = 82;
					break;
				case 182:
					num3 = 242 - 80;
					num2 = 38;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 61;
					}
					continue;
				case 226:
					array2[14] = 84;
					num2 = 89;
					continue;
				case 321:
					array2[17] = 180;
					num2 = 181;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 101;
					}
					continue;
				case 357:
					array2[1] = 102;
					num2 = 164;
					continue;
				case 309:
					num3 = 117 + 57;
					num2 = 219;
					continue;
				case 340:
					num4 = 64 + 4;
					num2 = 290;
					continue;
				case 244:
					num3 = 115 + 21;
					num2 = 169;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 15;
					}
					continue;
				case 118:
					array2[5] = 52;
					num2 = 91;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 234;
					}
					continue;
				case 175:
					array2[21] = 146;
					num2 = 230;
					continue;
				case 285:
					array2[23] = 133;
					num = 72;
					break;
				case 129:
					array2[13] = (byte)num5;
					num2 = 226;
					continue;
				case 73:
					array2[8] = 96;
					num2 = 38;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 177;
					}
					continue;
				case 343:
					array2[21] = (byte)num4;
					num2 = 202;
					continue;
				case 208:
					array[6] = 107;
					num2 = 295;
					continue;
				case 200:
					array2[15] = (byte)num5;
					num2 = 34;
					continue;
				case 123:
					array2[27] = (byte)num4;
					num2 = 140;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 138;
					}
					continue;
				case 318:
					if (P_1 == -1)
					{
						num2 = 6;
						if (L60ZsqVLNiYGf6Wn3Rd6())
						{
							num2 = 286;
						}
						continue;
					}
					goto case 206;
				case 95:
					num6 = 67 + 67;
					num2 = 105;
					continue;
				case 124:
					array2[19] = 115;
					num2 = 11;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 44;
					}
					continue;
				case 263:
					array4 = (byte[])XQiculVL5yHDvrPoU1Z1(GVTyv2VL7aglyt71B2T5(auHVwUyvsY2));
					num2 = 355;
					continue;
				case 149:
					num5 = 104 + 101;
					num2 = 41;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 38;
					}
					continue;
				case 255:
					array2[25] = 165;
					num = 113;
					break;
				case 282:
					num4 = 194 - 64;
					num2 = 126;
					continue;
				case 145:
					array2[30] = (byte)num5;
					num2 = 51;
					continue;
				case 203:
					num6 = 168 - 56;
					num = 22;
					break;
				case 267:
					array[9] = 111;
					num2 = 253;
					continue;
				case 164:
					num4 = 113 + 59;
					num2 = 144;
					continue;
				case 214:
					array2[26] = 198;
					num2 = 167;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 176;
					}
					continue;
				case 52:
					array2[3] = 154;
					num2 = 42;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 27;
					}
					continue;
				case 265:
					array2[8] = 84;
					num2 = 73;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 6;
					}
					continue;
				case 295:
					num3 = 239 - 79;
					num2 = 107;
					continue;
				case 113:
					array2[25] = 151;
					num2 = 184;
					continue;
				case 66:
					array[9] = (byte)num6;
					num2 = 308;
					continue;
				case 286:
				{
					object obj = SowsSCVLc9Ncon94VmxQ();
					NHVvr8VLeluyVsKI18Ls(obj, CipherMode.CBC);
					transform = (ICryptoTransform)XOFlZCVLyZfmMAqM7El5(obj, array5, array3);
					num2 = 298;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 268;
					}
					continue;
				}
				case 297:
					array3[7] = array4[3];
					num2 = 141;
					continue;
				case 71:
					array5[num7] ^= array3[num7];
					num2 = 337;
					continue;
				case 105:
					array[3] = (byte)num6;
					num2 = 249;
					continue;
				case 21:
					array[2] = (byte)num6;
					num2 = 56;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 203;
					}
					continue;
				case 61:
					array[0] = (byte)num3;
					num2 = 323;
					continue;
				case 351:
					num3 = 63 + 108;
					num2 = 31;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 115;
					}
					continue;
				case 207:
					array2[6] = (byte)num4;
					num2 = 14;
					continue;
				case 37:
					num4 = 169 - 56;
					num2 = 262;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 218;
					}
					continue;
				case 186:
					num5 = 194 - 64;
					num2 = 237;
					if (zZkkIgVLmB2l0yHbdVg6() != null)
					{
						num2 = 107;
					}
					continue;
				case 171:
					array2[29] = (byte)num5;
					num2 = 5;
					continue;
				case 139:
					num5 = 86 + 29;
					num2 = 307;
					if (!L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 44;
					}
					continue;
				case 219:
					array[13] = (byte)num3;
					num2 = 166;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 201;
					}
					continue;
				case 188:
					array[1] = 28;
					num2 = 120;
					continue;
				case 101:
					num5 = 66 + 49;
					num2 = 311;
					continue;
				case 237:
					array2[18] = (byte)num5;
					num = 197;
					break;
				case 64:
					array2[8] = (byte)num4;
					num2 = 116;
					continue;
				case 181:
					num4 = 73 - 7;
					num = 215;
					break;
				case 347:
					array2[8] = (byte)num4;
					num2 = 11;
					continue;
				case 192:
					num5 = 36 + 15;
					num2 = 63;
					if (L60ZsqVLNiYGf6Wn3Rd6())
					{
						num2 = 145;
					}
					continue;
				case 332:
					array2[12] = 109;
					num2 = 127;
					continue;
				case 289:
					num4 = 34 + 39;
					num2 = 60;
					continue;
				case 322:
					array2[10] = (byte)num5;
					num2 = 280;
					continue;
				case 40:
					array2[26] = (byte)num5;
					num2 = 329;
					continue;
				case 174:
					array2[6] = 101;
					num = 104;
					break;
				case 136:
					array[6] = (byte)num3;
					num2 = 208;
					continue;
				case 8:
					num5 = 178 - 59;
					num2 = 102;
					continue;
				case 334:
					array[10] = 190;
					num2 = 205;
					continue;
				case 23:
					num4 = 237 - 79;
					num2 = 207;
					continue;
				case 277:
					array2[25] = 77;
					num = 305;
					break;
				case 303:
					array[13] = (byte)num3;
					num2 = 2;
					if (zZkkIgVLmB2l0yHbdVg6() == null)
					{
						num2 = 12;
					}
					continue;
				}
				break;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string bjdVSa2BvFN(int P_0)
	{
		if (lhSVwSSh4rK.Length == 0)
		{
			ASFVwMgcR10 = new List<string>();
			dOEVwbBvEbj = new List<int>();
			try
			{
				var _stream = auHVwUyvsY2.GetManifestResourceStream("JmI6YdVEO5uX77WkHk.lmPHIDBA7YvWtgD3wV");
				byte[] _pktInit = auHVwUyvsY2.GetName().GetPublicKeyToken();
				string _pktInitStr = _pktInit == null ? "null" : (_pktInit.Length == 0 ? "empty" : BitConverter.ToString(_pktInit));
				byte[] _pk = auHVwUyvsY2.GetName().GetPublicKey();
				string _pkStr = _pk == null ? "null" : (_pk.Length == 0 ? "empty" : "len=" + _pk.Length);
				System.IO.File.AppendAllText(@"C:\Users\bingjian.wang\AppData\Roaming\IP_Assurance\debug.log",
					"[" + System.DateTime.Now.ToString("HH:mm:ss.fff") + "] bjdVSa2BvFN init: P_0=" + P_0 + ", stream=" + (_stream == null ? "NULL" : _stream.Length.ToString()) +
					", PKT=" + _pktInitStr + ", PK=" + _pkStr + ", AsmName=" + auHVwUyvsY2.GetName().Name + "\n");
				Uo9VShsM3hK(_stream, P_0);
				System.IO.File.AppendAllText(@"C:\Users\bingjian.wang\AppData\Roaming\IP_Assurance\debug.log",
					"[" + System.DateTime.Now.ToString("HH:mm:ss.fff") + "] After init: lhSVwSSh4rK.Length=" + lhSVwSSh4rK.Length + "\n");
				// Log first 32 bytes of decrypted data to verify correctness
				if (lhSVwSSh4rK.Length >= 32)
				{
					System.IO.File.AppendAllText(@"C:\Users\bingjian.wang\AppData\Roaming\IP_Assurance\debug.log",
						"[" + System.DateTime.Now.ToString("HH:mm:ss.fff") + "] First 32 bytes: " + BitConverter.ToString(lhSVwSSh4rK, 0, 32) + "\n");
				}
				// Verify first string at P_0=42184
				int _testNum = BitConverter.ToInt32(lhSVwSSh4rK, P_0);
				System.IO.File.AppendAllText(@"C:\Users\bingjian.wang\AppData\Roaming\IP_Assurance\debug.log",
					"[" + System.DateTime.Now.ToString("HH:mm:ss.fff") + "] First call string len at P_0=" + P_0 + ": " + _testNum + "\n");
			}
			catch (System.Exception _ex)
			{
				System.IO.File.AppendAllText(@"C:\Users\bingjian.wang\AppData\Roaming\IP_Assurance\debug.log",
					"[" + System.DateTime.Now.ToString("HH:mm:ss.fff") + "] EXCEPTION in init: " + _ex.ToString() + "\n");
			}
		}
		if (pLiVwZWwirQ < 75)
		{
			if (auHVwUyvsY2 != new StackFrame(1).GetMethod().DeclaringType.Assembly)
			{
				throw new Exception();
			}
			pLiVwZWwirQ++;
		}
		lock (zJgVwfnKSdt)
		{
			// DIAGNOSTIC: Log every call and validate P_0
			if (P_0 < 0 || P_0 + 4 > lhSVwSSh4rK.Length)
			{
				System.Diagnostics.StackFrame _sf = new System.Diagnostics.StackFrame(1);
				string _caller = _sf.GetMethod() != null ? _sf.GetMethod().DeclaringType.FullName + "." + _sf.GetMethod().Name : "unknown";
				byte[] _pkt = auHVwUyvsY2.GetName().GetPublicKeyToken();
				string _pktStr = _pkt == null ? "null" : (_pkt.Length == 0 ? "empty" : BitConverter.ToString(_pkt));
				System.IO.File.AppendAllText(@"C:\Users\bingjian.wang\AppData\Roaming\IP_Assurance\debug.log",
					"[" + System.DateTime.Now.ToString("HH:mm:ss.fff") + "] OUT_OF_RANGE: P_0=" + P_0 + ", len=" + lhSVwSSh4rK.Length +
					", caller=" + _caller + ", PKT=" + _pktStr + "\n");
				throw new ArgumentOutOfRangeException("P_0", "P_0=" + P_0 + " is out of range [0, " + (lhSVwSSh4rK.Length - 4) + "], caller=" + _caller);
			}
			int num = BitConverter.ToInt32(lhSVwSSh4rK, P_0);
			if (num < dOEVwbBvEbj.Count && dOEVwbBvEbj[num] == P_0)
			{
				return ASFVwMgcR10[num];
			}
			try
			{
				SseStreamInitializer.AlBVL0oCCKQ();
				byte[] array = new byte[num];
				Array.Copy(lhSVwSSh4rK, P_0 + 4, array, 0, num);
				string text = Encoding.Unicode.GetString(array, 0, array.Length);
				ASFVwMgcR10.Add(text);
				dOEVwbBvEbj.Add(P_0);
				Array.Copy(BitConverter.GetBytes(ASFVwMgcR10.Count - 1), 0, lhSVwSSh4rK, P_0, 4);
				return text;
			}
			catch
			{
			}
		}
		return "";
	}

	internal static string Wp7VSqBdHYW(string P_0)
	{
		"{11111-22222-50001-00000}".Trim();
		byte[] array = Convert.FromBase64String(P_0);
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	private static int Ec6VSPfF7Do()
	{
		return 5;
	}

	private static void gvNVSABtXbj()
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	private static Delegate LNUVSvUCpDj(IntPtr P_0, Type P_1)
	{
		return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[2]
		{
			typeof(IntPtr),
			typeof(Type)
		}).Invoke(null, new object[2] { P_0, P_1 });
	}

	internal static object a4SVSW2r6qt(object P_0)
	{
		try
		{
			if (File.Exists(((Assembly)P_0).Location))
			{
				return ((Assembly)P_0).Location;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(((Assembly)P_0).GetName().CodeBase.ToString().Replace("file:///", "")))
			{
				return ((Assembly)P_0).GetName().CodeBase.ToString().Replace("file:///", "");
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(P_0.GetType().GetProperty("Location").GetValue(P_0, new object[0])
				.ToString()))
			{
				return P_0.GetType().GetProperty("Location").GetValue(P_0, new object[0])
					.ToString();
			}
		}
		catch
		{
		}
		return "";
	}

	[DllImport("kernel32", EntryPoint = "LoadLibrary")]
	public static extern IntPtr RxuVS0tpP1r(string P_0);

	[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
	public static extern IntPtr MblVSkVIQnQ(IntPtr P_0, string P_1);

	private static IntPtr XDmVSxPYxQY(IntPtr P_0, string P_1, uint P_2)
	{
		if (lOnVwhDw2vP == null)
		{
			lOnVwhDw2vP = (CnIuNqVtHwf5uVko3Y8l)Marshal.GetDelegateForFunctionPointer(MblVSkVIQnQ(xTuFFuFOZ(), "Find ".Trim() + "ResourceA"), typeof(CnIuNqVtHwf5uVko3Y8l));
		}
		return lOnVwhDw2vP(P_0, P_1, P_2);
	}

	private static IntPtr a9NVSdt87cP(IntPtr P_0, uint P_1, uint P_2, uint P_3)
	{
		if (gfyVwaBQbf6 == null)
		{
			gfyVwaBQbf6 = (Y1YaG9VtQrL3P37IPnHL)Marshal.GetDelegateForFunctionPointer(MblVSkVIQnQ(xTuFFuFOZ(), "Virtual ".Trim() + "Alloc"), typeof(Y1YaG9VtQrL3P37IPnHL));
		}
		return gfyVwaBQbf6(P_0, P_1, P_2, P_3);
	}

	private static int heQVSzmS4FD(IntPtr P_0, IntPtr P_1, [In][Out] byte[] P_2, uint P_3, out IntPtr P_4)
	{
		if (NWZVwqYmPOO == null)
		{
			NWZVwqYmPOO = (Iycf5vVt18eEBxTpyfZu)Marshal.GetDelegateForFunctionPointer(MblVSkVIQnQ(xTuFFuFOZ(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(Iycf5vVt18eEBxTpyfZu));
		}
		return NWZVwqYmPOO(P_0, P_1, P_2, P_3, out P_4);
	}

	private static int D5JVwRYBm7A(IntPtr P_0, int P_1, int P_2, ref int P_3)
	{
		if (FjEVwPDZt6J == null)
		{
			FjEVwPDZt6J = (B6yMGEVtrP4FhxghXxwm)Marshal.GetDelegateForFunctionPointer(MblVSkVIQnQ(xTuFFuFOZ(), "Virtual ".Trim() + "Protect"), typeof(B6yMGEVtrP4FhxghXxwm));
		}
		return FjEVwPDZt6J(P_0, P_1, P_2, ref P_3);
	}

	private static IntPtr ko1VwVJ1ngE(uint P_0, int P_1, uint P_2)
	{
		if (gvPVwACSnZR == null)
		{
			gvPVwACSnZR = (naVpbvVtJOgLxnw5rQgJ)Marshal.GetDelegateForFunctionPointer(MblVSkVIQnQ(xTuFFuFOZ(), "Open ".Trim() + "Process"), typeof(naVpbvVtJOgLxnw5rQgJ));
		}
		return gvPVwACSnZR(P_0, P_1, P_2);
	}

	private static int dgPVwByK2pm(IntPtr P_0)
	{
		if (Vj2Vwvxv5ug == null)
		{
			Vj2Vwvxv5ug = (GGm8yZVt3BnmMj8JtHec)Marshal.GetDelegateForFunctionPointer(MblVSkVIQnQ(xTuFFuFOZ(), "Close ".Trim() + "Handle"), typeof(GGm8yZVt3BnmMj8JtHec));
		}
		return Vj2Vwvxv5ug(P_0);
	}

	[SpecialName]
	private static IntPtr xTuFFuFOZ()
	{
		if (HMyVwW9VJBv == IntPtr.Zero)
		{
			HMyVwW9VJBv = RxuVS0tpP1r("kernel ".Trim() + "32.dll");
		}
		return HMyVwW9VJBv;
	}

	private static byte[] dsGVw9WbI0A(string P_0)
	{
		using FileStream fileStream = new FileStream(P_0, FileMode.Open, FileAccess.Read, FileShare.Read);
		int num = 0;
		int num2 = (int)fileStream.Length;
		byte[] array = new byte[num2];
		while (num2 > 0)
		{
			int num3 = fileStream.Read(array, num, num2);
			num += num3;
			num2 -= num3;
		}
		return array;
	}

	internal static Stream YCnVw6sS3Dc()
	{
		return new MemoryStream();
	}

	internal static byte[] KhIVwuGpL3D(Stream P_0)
	{
		return ((MemoryStream)P_0).ToArray();
	}

	private static byte[] jFtVwD8MpFk(byte[] P_0)
	{
		Stream stream = YCnVw6sS3Dc();
		SymmetricAlgorithm symmetricAlgorithm = iI8VSCYGOW0();
		symmetricAlgorithm.Key = new byte[32]
		{
			124, 140, 54, 254, 34, 162, 129, 32, 40, 6,
			74, 144, 79, 135, 130, 237, 200, 245, 198, 139,
			187, 152, 83, 42, 193, 133, 211, 251, 126, 207,
			250, 189
		};
		symmetricAlgorithm.IV = new byte[16]
		{
			83, 77, 28, 150, 182, 243, 56, 86, 85, 153,
			45, 168, 202, 143, 139, 28
		};
		CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(P_0, 0, P_0.Length);
		cryptoStream.Close();
		byte[] result = KhIVwuGpL3D(stream);
		SseStreamInitializer.AlBVL0oCCKQ();
		return result;
	}

	private byte[] HluVwTpxFnA()
	{
		return null;
	}

	private byte[] IssVwgDHgl2()
	{
		return null;
	}

	private byte[] z6nVw8PmF9w()
	{
		_ = "{11111-22222-20001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	private byte[] Sd6VwIMRVIy()
	{
		_ = "{11111-22222-20001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	private byte[] c7gVwiGrKeU()
	{
		_ = "{11111-22222-30001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	private byte[] aSEVwHvIgxA()
	{
		_ = "{11111-22222-30001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] VuFVwQaRqpp()
	{
		_ = "{11111-22222-40001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] TXKVw1xana3()
	{
		_ = "{11111-22222-40001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] dCQVwrt3Y6w()
	{
		_ = "{11111-22222-50001-00001}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal byte[] LoLVwJGsJg2()
	{
		_ = "{11111-22222-50001-00002}".Length;
		_ = 0;
		return new byte[2] { 1, 2 };
	}

	internal static object N09gCxVLoXsSbvCFUhE5(object P_0)
	{
		return ((pG2pc9VtDNfcA9tWEu1l)P_0).nW4lBacjpc();
	}

	internal static void WwfRCQVLGM2cCHodUlSD(object P_0, long P_1)
	{
		((Stream)P_0).Position = P_1;
	}

	internal static long qV2gcSVLCtWOMSUiGCTD(object P_0)
	{
		return ((Stream)P_0).Length;
	}

	internal static object N50yaRVLp1I9b3cFxKuL(object P_0, int P_1)
	{
		return ((pG2pc9VtDNfcA9tWEu1l)P_0).N58VtTHlnc1(P_1);
	}

	internal static void c99WaNVLOwXmdXwWaVXB(object P_0)
	{
		((pG2pc9VtDNfcA9tWEu1l)P_0).nloVtInXWpT();
	}

	internal static void QwDss4VLndQTLjAoLp6X(object P_0)
	{
		Array.Reverse((Array)P_0);
	}

	internal static object GVTyv2VL7aglyt71B2T5(object P_0)
	{
		return ((Assembly)P_0).GetName();
	}

	internal static object XQiculVL5yHDvrPoU1Z1(object P_0)
	{
		return ((AssemblyName)P_0).GetPublicKeyToken();
	}

	internal static object SowsSCVLc9Ncon94VmxQ()
	{
		return iI8VSCYGOW0();
	}

	internal static void NHVvr8VLeluyVsKI18Ls(object P_0, CipherMode P_1)
	{
		((SymmetricAlgorithm)P_0).Mode = P_1;
	}

	internal static object XOFlZCVLyZfmMAqM7El5(object P_0, object P_1, object P_2)
	{
		return ((SymmetricAlgorithm)P_0).CreateDecryptor((byte[])P_1, (byte[])P_2);
	}

	internal static object RysAegVLXHrEwKOvoDBR()
	{
		return YCnVw6sS3Dc();
	}

	internal static void F4qHdaVLFaJailqkY8yG(object P_0, object P_1, int P_2, int P_3)
	{
		((Stream)P_0).Write((byte[])P_1, P_2, P_3);
	}

	internal static void CakkBIVLhD8uxhEEn6oP(object P_0)
	{
		((CryptoStream)P_0).FlushFinalBlock();
	}

	internal static object KYPMC0VLaAomMaeM6Uk7(object P_0)
	{
		return KhIVwuGpL3D((Stream)P_0);
	}

	internal static void y2Ta8HVLqncaAeXCduaF(object P_0)
	{
		((Stream)P_0).Close();
	}

	internal static object qKt29EVLPLn4wAeiyG3L(object P_0)
	{
		return ((Assembly)P_0).EntryPoint;
	}

	internal static bool QVqeqBVLAe2qVaYQ9Z2r(object P_0, object P_1)
	{
		return (MethodInfo)P_0 == (MethodInfo)P_1;
	}

	internal static bool L60ZsqVLNiYGf6Wn3Rd6()
	{
		return null == null;
	}

	internal static object zZkkIgVLmB2l0yHbdVg6()
	{
		return null;
	}
}
