using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;

namespace ImagePSNR {
	/// <summary>
	/// Handles Loading Targa files
	/// </summary>
	public class TGAImages {

		public static double m_BitsPerPixel = 0.0;

		public TGAImages() {}

		public static Bitmap LoadImage(string filename) {

			Bitmap offScreenBmp = null;

			// read the file
			FileStream fs = new FileStream(filename,FileMode.Open);
			BinaryReader br = new BinaryReader(fs);

			int fileLength = (int)fs.Length;

			int IDsize              = br.ReadByte();
			int colorMapType        = br.ReadByte();
			int imageType           = br.ReadByte();
			int colorMapOrigin      = br.ReadInt16();
			int colorMapLength      = br.ReadInt16();
			int colorMapEntrySize   = br.ReadByte();
			int xOrigin             = br.ReadInt16();
			int yOrigin             = br.ReadInt16();
			int width               = br.ReadInt16();
			int height              = br.ReadInt16();
			int imagePixelSize      = br.ReadByte();
			int imageDescriptorByte = br.ReadByte();

			int numPixels = height * width;
			
			byte[] data = br.ReadBytes(numPixels * 3);
			
			br.Close();
			fs.Close();

			//
			// update the bits/pixel
			//
			m_BitsPerPixel = fileLength * 8 / (double)numPixels;

			//
			// initialize
			//
				
			PixelFormat pixFormat = PixelFormat.Format24bppRgb;

			offScreenBmp = new Bitmap(width,height,pixFormat);
			int dataReadOffset = 0;
				
			unsafe {

				BitmapData bmd = offScreenBmp.LockBits(new Rectangle(0,0,width,height),ImageLockMode.ReadOnly,pixFormat);

				for(int y=height-1; y >= 0; y--) {

					byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);

					int numSubPixel = 0;
					for(int x=0; x < width; x++) {

						row[numSubPixel++] = data[dataReadOffset++];	// blue
						row[numSubPixel++] = data[dataReadOffset++];	// green
						row[numSubPixel++] = data[dataReadOffset++];	// red

					}
				}

				offScreenBmp.UnlockBits(bmd);
			}

			return offScreenBmp;
		}
	}
}
