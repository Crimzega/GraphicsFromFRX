using System;
using System.Drawing;
using System.Formats.Tar;
using System.Runtime.InteropServices;

namespace GraphicsFromFRX{

	internal class FrxItem{

		private const uint SHGFI_USEFILEATTRIBUTES = 0x10u;
		private const uint SHGFI_TYPENAME = 0x400u;

		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

		private byte[] _bytes;
		private int _headerSize;
		private int _imageSize;
		private long _fileOffset;
		private PictureTypes _pictureType;
		private string _fileTypeName;
		private string _fileExtension;

		public FrxItem(byte[] data, int headerSize, long offset, int imageSize, PictureTypes picType){
			_bytes = data;
			_headerSize = headerSize;
			_imageSize = imageSize;
			_fileOffset = offset;
			_pictureType = picType;
			_fileTypeName = picType.GetTypeName();
			_fileExtension = picType.GetExtension();
			if(picType != PictureTypes.None){
				string typeName = $".{_fileExtension}";
				SHFILEINFO sfi = new SHFILEINFO();
				IntPtr ptr = SHGetFileInfo(typeName, 0u, ref sfi, 0u, SHGFI_TYPENAME | SHGFI_USEFILEATTRIBUTES);
				if(ptr != IntPtr.Zero) _fileTypeName = sfi.szTypeName;
			}
		}

		public byte[] Bytes => _bytes;

		public Image Image => _pictureType != PictureTypes.None? FrxModule.PictureFromBytes(_bytes): null;

		public int HeaderSize => _headerSize;

		public int ImageSize => _imageSize;

		public long FileOffset => _fileOffset;

		public PictureTypes PictureType => _pictureType;

		public string FileTypeName => _fileTypeName;

		public string FileExtension => _fileExtension;

	}

}