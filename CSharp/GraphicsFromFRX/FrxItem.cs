using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GraphicsFromFrx{

	internal class FrxItem{

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct SHFILEINFO{
			public IntPtr hIcon;
			public int iIcon;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string sqDisplayName;
		}

		[DllImport("shell32.dll", EntryPoint = "SHGetFileInfoA")]
		private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO sfi, int cdFileInfo, uint uFlags);
		
		private const int MAX_PATH = 260;
		private const uint SHGFI_TYPENAME = 0x00000400u, SHGFI_USEFILEATTRIBUTES = 0x00000010u;

		private byte[] m_abItem;
		private uint m_dwFileOffset, m_dwSizeHdr, m_dwSizeImage;
		private PictureTypes m_dwPicType;
		private string m_sExtension, m_sTypeName;

		public byte[] Bits{ get => m_abItem; }

		public Image Picture{ get => m_dwPicType != PictureTypes.ptNone? FrxModule.PictureFromBits(m_abItem): null; }

		public PictureTypes PictureType{ get => m_dwPicType; }

		public uint FileOffset{ get => m_dwFileOffset; }

		public uint HeaderSize{ get => m_dwSizeHdr; }

		public uint ImageSize{ get => m_dwSizeImage; }

		public string FileExtension{ get => m_sExtension; }

		public string FileTypeName{ get => m_sTypeName; }

		internal void Init(byte[] abBits, uint dwSizeHdr, uint dwOffset, uint dwSizeImage, PictureTypes dwPicType){
			m_abItem = abBits;
			m_dwSizeHdr = dwSizeHdr;
			m_dwFileOffset = dwOffset;
			m_dwSizeImage = dwSizeImage;
			m_dwPicType = dwPicType;
			FillPictureInfo();
		}

		private void FillPictureInfo(){
			string sTypeName;
			switch(m_dwPicType){
				case PictureTypes.ptBMP:
				case PictureTypes.ptDIB:
					m_sTypeName = "Bitmap Image";
					m_sExtension = "bmp";
				break;
				case PictureTypes.ptGIF:
					m_sTypeName = "GIF Image";
					m_sExtension = "bmp";
				break;
				case PictureTypes.ptJPG:
					m_sTypeName = "JPEG Image";
					m_sExtension = "bmp";
				break;
				case PictureTypes.ptWMF:
					m_sTypeName = "Metatfile";
					m_sExtension = "wmf";
				break;
				case PictureTypes.ptEMF:
					m_sTypeName = "Enhanced Metatfile";
					m_sExtension = "emf";
				break;
				case PictureTypes.ptICO:
					m_sTypeName = "Icon File";
					m_sExtension = "ico";
				break;
				case PictureTypes.ptCUR:
					m_sTypeName = "Cursor File";
					m_sExtension = "cur";
				break;
				default:
					m_sTypeName = "Binary data";
					m_sExtension = "txt";
				break;
			}
			if(m_dwPicType != PictureTypes.ptNone){
				sTypeName = GetFileTypeName($".{m_sExtension}");
				if(sTypeName != null && sTypeName.Length > 0) m_sTypeName = sTypeName;
			}
		}

		private string GetFileTypeName(string sFile){
			SHFILEINFO sfi;
			return SHGetFileInfo(sFile, 0u, out sfi, Marshal.SizeOf(typeof(SHFILEINFO)),
				SHGFI_TYPENAME | SHGFI_USEFILEATTRIBUTES) != IntPtr.Zero?
				FrxModule.GetStrFromBufferA(sfi.sqDisplayName): "";
		}

	}

}