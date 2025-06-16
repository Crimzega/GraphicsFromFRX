using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using PathIO = System.IO.Path;

namespace GraphicsFromFRX{

	internal class FrxFile: IEnumerable<FrxItem>{

		private static string[] allowedExceptions = {".frx", ".ctx", ".dxs", ".dox", ".pgx"};
		private long _fileSize;
		private List<FrxItem> _items = new List<FrxItem>();
		private string _path;

		public long FileSize => _fileSize;

		public string Path => _path;

		public FrxItem this[int index] => _items[index];

		public IEnumerator<FrxItem> GetEnumerator() => _items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public void Load(string path){}

	}

}
