using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GraphicsFromFRX{

	public partial class MainForm: Form{

		private FrxFile _frxFile = new FrxFile();
		private string _formCaption;
		private string _saveFilter;
		private string _fileSizeText;

		public MainForm(){
			InitializeComponent();
			_formCaption = Text;
			_saveFilter = saveDialog.Filter;
			_fileSizeText = Label2.Text;
			cmdSave.Enabled = false;
		}

		public void MainForm_Open(object sender, EventArgs evt) => CenterToScreen();

		private void MainForm_Resize(object sender, EventArgs evt){
			Picture1.Width = Width - Picture1.Left - (cmdOpen.Height / 2);
			Picture1.Height = Height - Picture1.Top - (cmdOpen.Height / 2);
		}

		private void List1_SelectedIndexChanged(object sender, EventArgs evt)
		{
			FrxItem frxItem = _frxFile[List1.SelectedIndex];
			if(frxItem.PictureType != PictureTypes.None){
				
			}
		}

		private void cmdOpen_Click(object sender, EventArgs evt){}
	
		private void cmdSave_Click(object sender, EventArgs evt){}

	}

}