using System.Drawing;

namespace GraphicsFromFRX
{

	partial class MainForm
	{

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources sould be disposed;</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this.cmdSave = new System.Windows.Forms.Button();
			this.cmdOpen = new System.Windows.Forms.Button();
			this.List1 = new System.Windows.Forms.ListBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.openDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveDialog = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			//
			// Picture1
			//
			this.Picture1.Location = new System.Drawing.Point(312, 24);
			this.Picture1.Size = new System.Drawing.Size(165, 181);
			this.Picture1.TabIndex = 4;
			this.Picture1.TabStop = false;
			this.Picture1.Name = "Picture1";
			//
			// cmdSave
			//
			this.cmdSave.Location = new System.Drawing.Point(164, 274);
			this.cmdSave.Size = new System.Drawing.Size(132, 30);
			this.cmdSave.TabIndex = 3;
			this.cmdSave.Text = "Save selected graphic...";
			this.cmdSave.Name = "cmdSave";
			//
			// cmdOpen
			//
			this.cmdOpen.Location = new System.Drawing.Point(12, 274);
			this.cmdOpen.Size = new System.Drawing.Size(132, 30);
			this.cmdOpen.TabIndex = 2;
			this.cmdOpen.Text = "Open VB binary file...";
			this.cmdOpen.Name = "cmdOpen";
			//
			// List1
			//
			this.List1.Location = new System.Drawing.Point(12, 24);
			this.List1.Size = new System.Drawing.Size(285, 224);
			this.List1.TabIndex = 0;
			this.List1.IntegralHeight = false;
			this.List1.CustomTabOffsets.Add(85);
			this.List1.CustomTabOffsets.Add(125);
			this.List1.CustomTabOffsets.Add(165);
			this.List1.Name = "List1";
			//
			// Label2
			//
			this.Label2.Location = new System.Drawing.Point(12, 252);
			this.Label2.Size = new System.Drawing.Size(291, 15);
			this.Label2.TabIndex = 5;
			this.Label2.Text = "File Size: ";
			this.Label2.Name = "Label2";
			//
			// Label1
			//
			this.Label1.Location = new System.Drawing.Point(16, 10);
			this.Label1.Size = new System.Drawing.Size(281, 15);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "File type                Hdr Size     File offset   Image size";
			this.Label1.Name = "Label1";
			//
			// openDialog
			//
			this.openDialog.Filter = "VB Binary Files (*.frx;*.ctx;*.dsx;*.dox;*.pgx)|*.frx;*.ctx;*.dsx;*.dox;*.pgx|All Files (*.*)|*.*.";
			this.openDialog.Title = "Open VB binary file";
			//
			// saveDialog
			//
			this.saveDialog.Filter = "All Picture Files|*.bmp;*.dib;*.gif;*.jpg;*.wmf;*.emf;*.ico;*.cur|All Files (*.*)|*.*";
			this.saveDialog.Title = "Save selected graphic";
			//
			// MainForm
			//
			this.ClientSize = new System.Drawing.Size(558, 318);
			this.Location = new System.Drawing.Point(122, 135);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Text = "VB binary file grpahics extractor";
			this.Name = "MainForm";
			this.Controls.Add(this.Picture1);
			this.Controls.Add(this.cmdSave);
			this.Controls.Add(this.cmdOpen);
			this.Controls.Add(this.List1);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Load += new System.EventHandler(this.MainForm_Open);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.List1.SelectedIndexChanged += new System.EventHandler(this.List1_SelectedIndexChanged);
			this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.PictureBox Picture1;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.Button cmdOpen;
		private System.Windows.Forms.ListBox List1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.OpenFileDialog openDialog;
		private System.Windows.Forms.SaveFileDialog saveDialog;

		#endregion

	}

}