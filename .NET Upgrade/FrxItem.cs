using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace GraphicsFromFRX{

	enum PicType{
		None,
		BMP,
		DIB,
		GIF,
		JPG,
		WMF,
		EMF,
		ICO,
		CUR,
	}

	static class TypeExtension{
		
		public static string GetTypeName(this PicType self){
			switch(this){
				case PicType.BMP:
				case PicType.DIB: return "Bitmap Image";
				case PicType.GIF: return "GIF Image";
				case PicType.JPG: return "JPEG Image";
				case PicType.WMF: return "Metatfile";
				case PicType.EMF: return "Enhanced Metatfile";
				case PicType.ICO: return "Icon File";
				case PicType.CUR: return "Cursor File";
				default: return "Binary Data"
			}
		}

		public static string GetTypeExtension(this PicType self){
			switch(self){
				case PicType.None: return "txt";
				case PicType.DIB: return "bmp";
				default: return self.ToString().ToLower();
			}
		}
		
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct SHFILEINFO{
		public IntPtr hIcon;
		public int iIcon;
		public uint dwAttributes;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szDisplayName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szTypeName;
	}

	public class FrxItem{

		private const uint SHGFI_USEFILEATTRIBUTES = 0x10u;
		private const uint SHGFI_TYPENAME = 0x400u;
		private byte[] m_abItem;
		private int m_dwSizeHdr;
		private int m_dwFileOffset;
		private int m_dwSizeImage;
		private PicType m_dwPicType;
		private string m_sTypeName;
		private string m_sExtension;

		[DllImport("shell32.dll")]
		private static extern int SHGetFileInfo(string psZPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

		public byte[] Bits{ get => m_abItem; }

		public int HeaderSize{ get => m_dwSizeHdr; }

		public int FileOffset{ get => m_dwFileOffset; }

		public int ImageSize{ get => m_dwSizeImage; }

		public PicType PictureType{ get => m_dwPicType; }

		public string FileTypeName{ get => m_sTypeName; }

		public string FileExtension{ get => m_sExtension; }

		public Image Picture{ get => m_dwPicType != PicType.None? PictureFromBits(m_abItem): null; }

		protected void Init(byte[] abBits, int dwSizeHdr, int dwOffset, int dwSizeImage, PicType dwPicType){
			m_abItem = abBits;
			m_dwSizeHdr = dwSizeHdr;
			m_dwFileOffset = dwOffset;
			m_dwSizeImage = dwSizeImage;
			m_dwPicType = dwPicType;
		}

		private void FillPictureInfo(){
			string sTypeName;
			m_sTypeName = m_dwPicType.GetTypeName();
			m_sExtension = m_dwFileOffset.GetTypeExtension();
			if(m_dwPicType != PicType.NONE){
				sTypeName = GetFileTypeName($".$m_sExtension");
				if(sTypeName.Length > 0) m_sTypeName = sTypeName;
			}
		}

	}

}
