using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImagePSNR {
	/// <summary>
	/// Handles Loading PGM files
	/// </summary>
	public class PGMImages {

		public static double m_BitsPerPixel = 0.0;

		public PGMImages() {}

		public static Bitmap LoadImage(string filename) {

			Bitmap offScreenBmp = null; 
            int fileLength;
            int width;
            int height;
            byte[] data;

            // read the file
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                // Check the magic number
                string tempString = "#";

                do
                {
                    tempString = ReadLine(fs);
                } while (tempString.StartsWith("#"));

                // read in the pixel height and width
                do
                {
                    tempString = ReadLine(fs);
                } while (tempString.StartsWith("#"));

                string[] sizeStrings = tempString.Split(' ');
                width = Convert.ToInt32(sizeStrings[0]);
                height = Convert.ToInt32(sizeStrings[1]);

                // read in the maximum gray value
                do
                {
                    tempString = ReadLine(fs);
                } while (tempString.StartsWith("#"));

                int maxGrayValue = Convert.ToInt32(tempString);

                // read the rest of the file
                fileLength = (int)fs.Length;
                int startPosition = (int)fs.Position;
                int arrayLength = fileLength - startPosition;

                data = new byte[arrayLength];
                fs.Read(data, 0, arrayLength);
            }

            //
            // update the bits/pixel
            //
            m_BitsPerPixel = fileLength * 8 / (double)(width * height);

			//
			// initialize
			//
				
			PixelFormat pixFormat = PixelFormat.Format24bppRgb;

			offScreenBmp = new Bitmap(width,height,pixFormat);
			int dataReadOffset = 0;
				
			unsafe {

				BitmapData bmd = offScreenBmp.LockBits(new Rectangle(0,0,width,height),ImageLockMode.ReadOnly,pixFormat);

				for(int y=0; y < height; y++) {

					byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);

					int numSubPixel = 0;
					for(int x=0; x < width; x++) {

						row[numSubPixel++] = data[dataReadOffset];		// blue
						row[numSubPixel++] = data[dataReadOffset];		// green
						row[numSubPixel++] = data[dataReadOffset++];	// red

					}
				}

				offScreenBmp.UnlockBits(bmd);
			}

			return offScreenBmp;
		}

        private static string ReadLine(FileStream fs)
        {
            var bytes = new System.Collections.Generic.List<byte>();

            while(true)
            {
                byte b = (byte)fs.ReadByte();
                if (b == 0x0a) break;
                bytes.Add(b);
            }


            return System.Text.Encoding.UTF8.GetString(bytes.ToArray());
        }
    }
}
