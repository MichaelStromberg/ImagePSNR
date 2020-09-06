using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace ImagePSNR {
	/// <summary>
	/// Summary description for ImageForm.
	/// </summary>
	public class ImageForm : System.Windows.Forms.Form {
		public System.Windows.Forms.PictureBox m_LeftPictureBox;
		public System.Windows.Forms.PictureBox m_RightPictureBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label m_LeftImageBitsPerPixelLabel;
		public System.Windows.Forms.Label m_RightImageBitsPerPixelLabel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button m_SelectLeftImageButton;
		private System.Windows.Forms.Button m_SelectRightImageButton;

		private double m_BitsPerPixel = 0.0;
		public System.Windows.Forms.Label m_RedPSNRLabel;
		public System.Windows.Forms.Label m_RedRMSELabel;
		public System.Windows.Forms.Label m_GreenRMSELabel;
		public System.Windows.Forms.Label m_GreenPSNRLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label m_BlueRMSELabel;
		public System.Windows.Forms.Label m_BluePSNRLabel;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.Label m_GrayRMSELabel;
		public System.Windows.Forms.Label m_GrayPSNRLabel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ImageForm() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ImageForm));
			this.m_LeftPictureBox = new System.Windows.Forms.PictureBox();
			this.m_SelectLeftImageButton = new System.Windows.Forms.Button();
			this.m_SelectRightImageButton = new System.Windows.Forms.Button();
			this.m_RightPictureBox = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.m_LeftImageBitsPerPixelLabel = new System.Windows.Forms.Label();
			this.m_RightImageBitsPerPixelLabel = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.m_RedPSNRLabel = new System.Windows.Forms.Label();
			this.m_RedRMSELabel = new System.Windows.Forms.Label();
			this.m_GreenRMSELabel = new System.Windows.Forms.Label();
			this.m_GreenPSNRLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.m_BlueRMSELabel = new System.Windows.Forms.Label();
			this.m_BluePSNRLabel = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.m_GrayRMSELabel = new System.Windows.Forms.Label();
			this.m_GrayPSNRLabel = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_LeftPictureBox
			// 
			this.m_LeftPictureBox.BackColor = System.Drawing.Color.Black;
			this.m_LeftPictureBox.Location = new System.Drawing.Point(8, 8);
			this.m_LeftPictureBox.Name = "m_LeftPictureBox";
			this.m_LeftPictureBox.Size = new System.Drawing.Size(350, 350);
			this.m_LeftPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_LeftPictureBox.TabIndex = 0;
			this.m_LeftPictureBox.TabStop = false;
			// 
			// m_SelectLeftImageButton
			// 
			this.m_SelectLeftImageButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_SelectLeftImageButton.Location = new System.Drawing.Point(111, 400);
			this.m_SelectLeftImageButton.Name = "m_SelectLeftImageButton";
			this.m_SelectLeftImageButton.Size = new System.Drawing.Size(144, 23);
			this.m_SelectLeftImageButton.TabIndex = 1;
			this.m_SelectLeftImageButton.Text = "Select Left Image...";
			this.m_SelectLeftImageButton.Click += new System.EventHandler(this.m_SelectLeftImageButton_Click);
			// 
			// m_SelectRightImageButton
			// 
			this.m_SelectRightImageButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_SelectRightImageButton.Location = new System.Drawing.Point(471, 400);
			this.m_SelectRightImageButton.Name = "m_SelectRightImageButton";
			this.m_SelectRightImageButton.Size = new System.Drawing.Size(144, 23);
			this.m_SelectRightImageButton.TabIndex = 3;
			this.m_SelectRightImageButton.Text = "Select Right Image...";
			this.m_SelectRightImageButton.Click += new System.EventHandler(this.m_SelectRightImageButton_Click);
			// 
			// m_RightPictureBox
			// 
			this.m_RightPictureBox.BackColor = System.Drawing.Color.Black;
			this.m_RightPictureBox.Location = new System.Drawing.Point(368, 8);
			this.m_RightPictureBox.Name = "m_RightPictureBox";
			this.m_RightPictureBox.Size = new System.Drawing.Size(350, 350);
			this.m_RightPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_RightPictureBox.TabIndex = 4;
			this.m_RightPictureBox.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(728, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "PSNR:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(728, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "RMSE:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(112, 368);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 23);
			this.label7.TabIndex = 11;
			this.label7.Text = "bits/pixel:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_LeftImageBitsPerPixelLabel
			// 
			this.m_LeftImageBitsPerPixelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_LeftImageBitsPerPixelLabel.Location = new System.Drawing.Point(208, 368);
			this.m_LeftImageBitsPerPixelLabel.Name = "m_LeftImageBitsPerPixelLabel";
			this.m_LeftImageBitsPerPixelLabel.Size = new System.Drawing.Size(52, 23);
			this.m_LeftImageBitsPerPixelLabel.TabIndex = 12;
			this.m_LeftImageBitsPerPixelLabel.Text = " 0.00";
			this.m_LeftImageBitsPerPixelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_RightImageBitsPerPixelLabel
			// 
			this.m_RightImageBitsPerPixelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_RightImageBitsPerPixelLabel.Location = new System.Drawing.Point(568, 368);
			this.m_RightImageBitsPerPixelLabel.Name = "m_RightImageBitsPerPixelLabel";
			this.m_RightImageBitsPerPixelLabel.Size = new System.Drawing.Size(52, 23);
			this.m_RightImageBitsPerPixelLabel.TabIndex = 14;
			this.m_RightImageBitsPerPixelLabel.Text = " 0.00";
			this.m_RightImageBitsPerPixelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.Black;
			this.label10.Location = new System.Drawing.Point(472, 368);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 23);
			this.label10.TabIndex = 13;
			this.label10.Text = "bits/pixel:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_RedPSNRLabel
			// 
			this.m_RedPSNRLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_RedPSNRLabel.Location = new System.Drawing.Point(792, 16);
			this.m_RedPSNRLabel.Name = "m_RedPSNRLabel";
			this.m_RedPSNRLabel.Size = new System.Drawing.Size(72, 23);
			this.m_RedPSNRLabel.TabIndex = 15;
			this.m_RedPSNRLabel.Text = "0 dB";
			this.m_RedPSNRLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_RedRMSELabel
			// 
			this.m_RedRMSELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_RedRMSELabel.Location = new System.Drawing.Point(792, 40);
			this.m_RedRMSELabel.Name = "m_RedRMSELabel";
			this.m_RedRMSELabel.Size = new System.Drawing.Size(72, 23);
			this.m_RedRMSELabel.TabIndex = 16;
			this.m_RedRMSELabel.Text = "0";
			this.m_RedRMSELabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_GreenRMSELabel
			// 
			this.m_GreenRMSELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_GreenRMSELabel.Location = new System.Drawing.Point(792, 104);
			this.m_GreenRMSELabel.Name = "m_GreenRMSELabel";
			this.m_GreenRMSELabel.Size = new System.Drawing.Size(72, 23);
			this.m_GreenRMSELabel.TabIndex = 20;
			this.m_GreenRMSELabel.Text = "0";
			this.m_GreenRMSELabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_GreenPSNRLabel
			// 
			this.m_GreenPSNRLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_GreenPSNRLabel.Location = new System.Drawing.Point(792, 80);
			this.m_GreenPSNRLabel.Name = "m_GreenPSNRLabel";
			this.m_GreenPSNRLabel.Size = new System.Drawing.Size(72, 23);
			this.m_GreenPSNRLabel.TabIndex = 19;
			this.m_GreenPSNRLabel.Text = "0 dB";
			this.m_GreenPSNRLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(728, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 23);
			this.label5.TabIndex = 18;
			this.label5.Text = "RMSE:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(728, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 23);
			this.label6.TabIndex = 17;
			this.label6.Text = "PSNR:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_BlueRMSELabel
			// 
			this.m_BlueRMSELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_BlueRMSELabel.Location = new System.Drawing.Point(792, 168);
			this.m_BlueRMSELabel.Name = "m_BlueRMSELabel";
			this.m_BlueRMSELabel.Size = new System.Drawing.Size(72, 23);
			this.m_BlueRMSELabel.TabIndex = 24;
			this.m_BlueRMSELabel.Text = "0";
			this.m_BlueRMSELabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_BluePSNRLabel
			// 
			this.m_BluePSNRLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_BluePSNRLabel.Location = new System.Drawing.Point(792, 144);
			this.m_BluePSNRLabel.Name = "m_BluePSNRLabel";
			this.m_BluePSNRLabel.Size = new System.Drawing.Size(72, 23);
			this.m_BluePSNRLabel.TabIndex = 23;
			this.m_BluePSNRLabel.Text = "0 dB";
			this.m_BluePSNRLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.Blue;
			this.label11.Location = new System.Drawing.Point(728, 168);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 23);
			this.label11.TabIndex = 22;
			this.label11.Text = "RMSE:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.Blue;
			this.label12.Location = new System.Drawing.Point(728, 144);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 23);
			this.label12.TabIndex = 21;
			this.label12.Text = "PSNR:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_GrayRMSELabel
			// 
			this.m_GrayRMSELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_GrayRMSELabel.Location = new System.Drawing.Point(792, 232);
			this.m_GrayRMSELabel.Name = "m_GrayRMSELabel";
			this.m_GrayRMSELabel.Size = new System.Drawing.Size(72, 23);
			this.m_GrayRMSELabel.TabIndex = 28;
			this.m_GrayRMSELabel.Text = "0";
			this.m_GrayRMSELabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_GrayPSNRLabel
			// 
			this.m_GrayPSNRLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_GrayPSNRLabel.Location = new System.Drawing.Point(792, 208);
			this.m_GrayPSNRLabel.Name = "m_GrayPSNRLabel";
			this.m_GrayPSNRLabel.Size = new System.Drawing.Size(72, 23);
			this.m_GrayPSNRLabel.TabIndex = 27;
			this.m_GrayPSNRLabel.Text = "0 dB";
			this.m_GrayPSNRLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(728, 232);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 23);
			this.label8.TabIndex = 26;
			this.label8.Text = "RMSE:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(728, 208);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 23);
			this.label9.TabIndex = 25;
			this.label9.Text = "PSNR:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ImageForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(872, 432);
			this.Controls.Add(this.m_GrayRMSELabel);
			this.Controls.Add(this.m_GrayPSNRLabel);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.m_BlueRMSELabel);
			this.Controls.Add(this.m_BluePSNRLabel);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.m_GreenRMSELabel);
			this.Controls.Add(this.m_GreenPSNRLabel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.m_RedRMSELabel);
			this.Controls.Add(this.m_RedPSNRLabel);
			this.Controls.Add(this.m_RightImageBitsPerPixelLabel);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.m_LeftImageBitsPerPixelLabel);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_RightPictureBox);
			this.Controls.Add(this.m_SelectRightImageButton);
			this.Controls.Add(this.m_SelectLeftImageButton);
			this.Controls.Add(this.m_LeftPictureBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ImageForm";
			this.Text = "ImagePSNR";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.Run(new ImageForm());
		}

		private Image ReadImage() {

			Image img = null;

			// Displays an OpenFileDialog so the user can select an image
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "All Supported Image Files|*.bmp;*.jpg;*.tga;*.pgm;*.tif|BMP Files (*.bmp)|*.bmp|JPEG Files (*.jpg)|*.jpg|PGM Files (*.pgm)|*.pgm|Targa Files (*.tga)|*.tga|TIFF Files (*.tif)|*.tif|All Files (*.*)|*.*";
			openFileDialog.Title  = "Select an image File";

			// Show the Dialog.
			if (openFileDialog.ShowDialog() == DialogResult.OK) {

				// get the magic number
				byte[] magicNumber = FileUtils.ReadMagicNumber(openFileDialog.FileName);
				
				if(FileUtils.IsBMP(magicNumber) || FileUtils.IsJPG(magicNumber) || FileUtils.IsTIFF(magicNumber)) {
					img = Bitmap.FromFile(openFileDialog.FileName);
					FileInfo fi = new FileInfo(openFileDialog.FileName);
					m_BitsPerPixel = (int)fi.Length * 8 / (double)(img.Width * img.Height);
				} else if(FileUtils.IsPGM(magicNumber)) {
					img = PGMImages.LoadImage(openFileDialog.FileName);
					m_BitsPerPixel = PGMImages.m_BitsPerPixel;
				} else if(FileUtils.IsPPM(magicNumber)) {
					//img = PPMImages.LoadImage(openFileDialog.FileName);
				} else if(FileUtils.IsTGA(magicNumber)) {
					img = TGAImages.LoadImage(openFileDialog.FileName);
					m_BitsPerPixel = TGAImages.m_BitsPerPixel;
				}
			}

			return img;
		}

		private void m_SelectLeftImageButton_Click(object sender, System.EventArgs e) {

			ClearResults();
			Image img = ReadImage();

			if(img != null) {
				m_LeftPictureBox.Image = img;
				m_LeftImageBitsPerPixelLabel.Text = String.Format("{0:#0.00}",m_BitsPerPixel);
				CalculatePSNR();
			}
		}

		private void m_SelectRightImageButton_Click(object sender, System.EventArgs e) {
		
			ClearResults();
			Image img = ReadImage();

			if(img != null) {
				m_RightPictureBox.Image = img;
				m_RightImageBitsPerPixelLabel.Text = String.Format("{0:#0.00}",m_BitsPerPixel);
				CalculatePSNR();
			}
		}

		private void ClearResults() {
			m_RedPSNRLabel.Text   = "0.000 dB";
			m_RedRMSELabel.Text   = "0.000";
				
			m_GreenPSNRLabel.Text = "0.000 dB";
			m_GreenRMSELabel.Text = "0.000";

			m_BluePSNRLabel.Text  = "0.000 dB";
			m_BlueRMSELabel.Text  = "0.000";

			m_GrayPSNRLabel.Text  = "0.000 dB";
			m_GrayRMSELabel.Text  = "0.000";
		}

		private void CalculatePSNR() {

			// do not check unless both bitmaps are defined
			if(m_LeftPictureBox.Image == null) return;
			if(m_RightPictureBox.Image == null) return;

			// check to see that all of the required parameters are equal
			Bitmap lbmp = (Bitmap)m_LeftPictureBox.Image;
			Bitmap rbmp = (Bitmap)m_RightPictureBox.Image;

			if(lbmp.Height != rbmp.Height) {
				Debug.WriteLine("Heights are not equal.");
				return;
			}

			if(lbmp.Width != rbmp.Width) {
				Debug.WriteLine("Widths are not equal.");
				return;
			}
			
			// localize the bitmap size
			int height  = lbmp.Height;
			int width   = lbmp.Width;

			// read the bitmap data
			unsafe {

				BitmapData lbmd = lbmp.LockBits(new Rectangle(0,0,width,height),ImageLockMode.ReadOnly,PixelFormat.Format24bppRgb);
				BitmapData rbmd = rbmp.LockBits(new Rectangle(0,0,width,height),ImageLockMode.ReadOnly,PixelFormat.Format24bppRgb);

				/*
				int sgndiff;
				int maxposdiff = int.MinValue;
				int maxnegdiff = int.MaxValue;
				int maxabsdiff;
				*/

				// our sum of differences
				long rMeanSquaredSum = 0;
				long gMeanSquaredSum = 0;
				long bMeanSquaredSum = 0;
				double yMeanSquaredSum = 0;

				/*
				// partial sum-abs-diff component-pixels
				long psum_absdiff = 0L;
				
				// partial sum-square component-pixels
				long psum_sqr     = 0L;

				// total sum-square component-pixels
				double sum_sqr = 0.0;

				// total sum-abs-diff component-pixels
				double sum_absdiff = 0.0;

				long part_max = long.MaxValue >> 2;
				*/

				for(int y=0; y < height; y++) {

					byte* lrow = (byte*)lbmd.Scan0 + (y * lbmd.Stride);
					byte* rrow = (byte*)rbmd.Scan0 + (y * rbmd.Stride);

					int numLSubPixel = 0;
					int numRSubPixel = 0;
					for(int x=0; x < width; x++) {

						// blue
						int lblue  = lrow[numLSubPixel++];
						int rblue  = rrow[numRSubPixel++];

						// green
						int lgreen = lrow[numLSubPixel++];
						int rgreen = rrow[numRSubPixel++];

						// red
						int lred   = lrow[numLSubPixel++];
						int rred   = rrow[numRSubPixel++];

						// luminance
						double llum = 0.299 * lred + 0.587 * lgreen + 0.114 * lblue;
						double rlum = 0.299 * rred + 0.587 * rgreen + 0.114 * rblue;

						// compute differences
						int bDiff = lblue - rblue;
						int gDiff = lgreen - rgreen;
						int rDiff = lred - rred;
						double yDiff = llum - rlum;

						// compute the mean squared sum
						rMeanSquaredSum += rDiff * rDiff;
						gMeanSquaredSum += gDiff * gDiff;
						bMeanSquaredSum += bDiff * bDiff;
						yMeanSquaredSum += yDiff * yDiff;

						// check to make sure that we are not overflowing
						if((rMeanSquaredSum < 0) || (gMeanSquaredSum < 0) || (bMeanSquaredSum < 0) || (yMeanSquaredSum < 0)) {
							MessageBox.Show("Mean squared sum has overflowed.","Overflow",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						}



						/*
						sgndiff = lgreen - rgreen;
						
						// add to the partial accumulators and make sure they do not overflow
					
						
						psum_absdiff += Math.Abs(sgndiff);
						psum_sqr     += sgndiff*sgndiff;
						
						if(psum_absdiff < 0) {
							MessageBox.Show("ERROR: Sum difference overflow.");
							return;
						}

						if(psum_sqr < 0) {
							MessageBox.Show("ERROR: Sum square overflow.");
							return;
						}

						// check against the max pos and neg differences
						if(maxposdiff < sgndiff) maxposdiff = sgndiff;
						if(maxnegdiff > sgndiff) maxnegdiff = sgndiff;

						// if the partials are large enough, dump to the main accumulators
						if(psum_absdiff > part_max) {
							sum_absdiff += psum_absdiff;
							psum_absdiff = 0L;
						}

						if (psum_sqr > part_max) {
							sum_sqr += psum_sqr;
							psum_sqr = 0L;
						}
						*/
					}
				}

				// calculate the number of pixels
				int nPixels = height * width;

				// calculate mean squared error
				double rMSE = (double)rMeanSquaredSum / (double)nPixels;
				double gMSE = (double)gMeanSquaredSum / (double)nPixels;
				double bMSE = (double)bMeanSquaredSum / (double)nPixels;
				double yMSE = yMeanSquaredSum / (double)nPixels;
			
				// calculate RMSE
				double rRMSE = Math.Sqrt(rMSE);
				double gRMSE = Math.Sqrt(gMSE);
				double bRMSE = Math.Sqrt(bMSE);
				double yRMSE = Math.Sqrt(yMSE);

				// calculate PSNR
				double rPSNR = 20.0 * Math.Log10(255.0 / rRMSE);
				double gPSNR = 20.0 * Math.Log10(255.0 / gRMSE);
				double bPSNR = 20.0 * Math.Log10(255.0 / bRMSE);
				double yPSNR = 20.0 * Math.Log10(255.0 / yRMSE);

				/*
				// add the last of the partial sums to the main sums 
				// setting the partial to zero here is not needed but done as a precaution 
				sum_absdiff  += psum_absdiff;
				sum_sqr      += psum_sqr;
				psum_absdiff = 0L;
				psum_sqr     = 0L;

				// compute the root-mean-square-error
				int numPixels = height * width;
				double rmse = Math.Sqrt((double)sum_sqr / (double)numPixels);
				
				// compute the mean absolute difference 
				double mad = (double)sum_absdiff / (double)numPixels;
				
				// if the error is non-zero compute PSNR
				double psnr = 0.0;
				if(rmse > 0.0) psnr = 20 * Math.Log10((double)255 / rmse);

				// turn the maximum negative difference into a positive number
				maxnegdiff = - maxnegdiff;

				// max abs difference is the greater of max pos and max neg
				maxabsdiff = (maxposdiff > maxnegdiff) ? maxposdiff : maxnegdiff;
				*/

				// update the gui
				m_RedPSNRLabel.Text   = String.Format("{0:##0.000} dB",rPSNR);
				m_RedRMSELabel.Text   = String.Format("{0:##0.000}",rRMSE);
				
				m_GreenPSNRLabel.Text = String.Format("{0:##0.000} dB",gPSNR);
				m_GreenRMSELabel.Text = String.Format("{0:##0.000}",gRMSE);

				m_BluePSNRLabel.Text  = String.Format("{0:##0.000} dB",bPSNR);
				m_BlueRMSELabel.Text  = String.Format("{0:##0.000}",bRMSE);

				m_GrayPSNRLabel.Text  = String.Format("{0:##0.000} dB",yPSNR);
				m_GrayRMSELabel.Text  = String.Format("{0:##0.000}",bRMSE);

				rbmp.UnlockBits(rbmd);
				lbmp.UnlockBits(lbmd);
			}

		}
	}
}
