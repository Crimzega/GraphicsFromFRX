using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

partial class Form1{

	private IContainer components = null;
	PictureBox Picture1;
	Button cmdSave;
	Button cmdOpen;
	ListBox List1;
	Label Label1;
	Label Label2;

	private void InitializeComponent(){
		SuspendLayout();
		FormBorderStyle = FormBorderStyle.None;
		Picture1.Location = new Point(312, 24);
		Picture1.Size = new Size(165, 181);
		Picture1.TabIndex = 4;
		Controls.Add(Picture1);
		ClientSize = new Size(558, 318);
		Name = "Form1";
		Text = "VB binary graphics extractor";
		ResumeLayout(false);
	}

}