using System.Runtime.InteropServices;

namespace GraphicsFromFrx{

	class FrxModule{

		public enum CBoolean{

			CFalse = 0,
			CTrue

		}

		public struct FRXITEMHDRW{
			public uint dwSizeText;
		}

		public struct FRXITEMHDR{
			public uint dwSizeImageEx;
			public uint dwKey;
			public uint dwSizeImage;
		}

		public struct FRXITEMHDREX{
			public uint sqSizeImageEx;
			public GUID clsid;
			public uint dwKey;
			public uint dwSizeImage;
		}

		public struct FRXITEMHDRDW{
			public uint dwSizeImage;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct GUID{
			public uint dwData1;
			public ushort wData2;
			public ushort wData3;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public byte[] abData4;
		}

		public struct METAHEADER{
			public ushort mtType;
			public ushort mtHeaderSize;
			public ushort mtVersion;
			public uint mtSize;
			public ushort mtNoObjects;
			public uint mtMaxRecord;
			public ushort mtNoParameters;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct NEWHEADER{
			public short Reserved;
			public short ResType;
			public short ResCount;
		}

		[DllImport("ole32.dll")]
		public static int CreateStreamOnHGlobal(IntPtr hGlobal, CBoolean fDeleteOnReleasem);

		public const int RES_ICON = 1;
		public const int RES_CURSOR = 2;
		public const int SIZEOFDIRENTRY = 16;
		public const int SIZEOFBOTMAPINFOHEADER = 40;
		public const int S_OK = 0;
		public const uint FIH_Key = 0x746C;
		public const uint IMGSIG_CUR = 0x20000u;
		public const uint IMGSIG_GIF = 0x464947u;
		public const uint IMGSIG_ICO = 0x10000u;
		public const uint IMGSIG_WMF_APM = 0x9AC6CDD7u;
		public const ushort IMGSIG_BMPDIB = (ushort)0x4D42u;
		public const ushort IMGTERM_GIF = (ushort)0x3Bu;
		public const ushort IMGSIG_JPG = (ushort)0xD8FFu;
		public const ushort IMGTERM_JPG = (ushort)0xD9FFu;

		public static string GetStrFromBufferA(string szA) =>
			szA.Contains('\x00')? szA.Substring(0, szA.IndexOf('\x00')): szA;

	}

}
