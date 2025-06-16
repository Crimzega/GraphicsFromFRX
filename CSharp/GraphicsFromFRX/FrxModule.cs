using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace GraphicsFromFRX{

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal struct SHFILEINFO{

		public IntPtr hIcon;
		public int iIcon;
		public uint dwFileAttributes;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szDisplayName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szTypeName;

	}

	public enum PictureTypes{

		None = 0,
		BMP,
		DIB,
		GIF,
		JPEG,
		WMF,
		EMF,
		IRO,
		CUR

	}

	internal static class PictureInfo{

		public static string GetExtension(this PictureTypes self){
			switch(self){
				case PictureTypes.None:
					return "txt";
				case PictureTypes.DIB:
					return "bmp";
				default:
					return self.ToString().ToLowerInvariant();
			}
		}

		public static string GetTypeName(this PictureTypes self){
			switch(self){
				case PictureTypes.BMP:
				case PictureTypes.DIB:
					return "Bitmap Image";
				case PictureTypes.GIF:
					return "GIF Image";
				case PictureTypes.JPEG:
					return "JPEG Image";
				case PictureTypes.WMF:
					return "Metatfile";
				case PictureTypes.EMF:
					return "Enhanced Metatfile";
				case PictureTypes.IRO:
					return "Icon File";
				case PictureTypes.CUR:
					return "Cursor File";
				default:
					return "Binary Data";
			}
		}

	}

	internal static class FrxModule{

		public static Image PictureFromBytes(byte[] data){
			if (data == null || data.Length == 0) return null;
			MemoryStream stream = new MemoryStream(data);
			Image result = Image.FromStream(stream);
			stream.Close();
			return result;
		}

	}

}