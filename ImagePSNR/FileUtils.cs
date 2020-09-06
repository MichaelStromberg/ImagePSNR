using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImagePSNR {
	/// <summary>
	/// Provide some extra file processing utilities
	/// </summary>
	public class FileUtils {

		public static byte[] TARGA_RGB = { 0x00, 0x00, 0x02, 0x00 };
		public static byte[] PGM = { 0x50, 0x35 };
		public static byte[] BMP = { 0x42, 0x4d };
		public static byte[] JPEG = { 0xff, 0xd8, 0xff, 0xe0 };
		public static byte[] TIFF_LE = { 0x49, 0x49, 0x2a, 0x00 };
		public static byte[] TIFF_BE = { 0x4D, 0x4D, 0x00, 0x2a };

		public FileUtils() { }

		public static bool IsBMP(byte[] magic) {

			bool b = false;
			if(magic[0] == BMP[0] && magic[1] == BMP[1]) b = true;

			return b;
		}

		public static bool IsPGM(byte[] magic) {

			bool b = false;
			if(magic[0] == PGM[0] && magic[1] == PGM[1]) b = true;

			return b;
		}

		public static bool IsPPM(byte[] magic) {

			bool b = false;

			return b;
		}

		public static bool IsTGA(byte[] magic) {

			bool b = false;
			if(magic[0] == TARGA_RGB[0] && magic[1] == TARGA_RGB[1] && magic[2] == TARGA_RGB[2] && magic[3] == TARGA_RGB[3]) b = true;

			return b;
		}

		public static bool IsJPG(byte[] magic) {

			bool b = false;
			if(magic[0] == JPEG[0] && magic[1] == JPEG[1] && magic[2] == JPEG[2] && magic[3] == JPEG[3]) b = true;

			return b;
		}

		public static bool IsTIFF(byte[] magic) {

			bool b = false;
			if(magic[0] == TIFF_LE[0] && magic[1] == TIFF_LE[1] && magic[2] == TIFF_LE[2] && magic[3] == TIFF_LE[3]) b = true;
			if(magic[0] == TIFF_BE[0] && magic[1] == TIFF_BE[1] && magic[2] == TIFF_BE[2] && magic[3] == TIFF_BE[3]) b = true;

			return b;
		}

		public static byte[] ReadMagicNumber(string filename) {

			byte[] bytes = new byte[4];

			try {
				using(FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
					fs.Read(bytes, 0, 4);
				}
			} catch(Exception e) {
				MessageBox.Show(e.Message, "Error reading image magic number", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return bytes;
		}

		public static string ReadNextLine(FileStream fs) {

			string s = null;

			int startPos = (int)fs.Position;
			int offset = 0;
			int b = 0;

			while(b != 0x0a) {

				// read the next byte
				b = fs.ReadByte();
				offset++;
			}

			byte[] bytes = new byte[offset];
			fs.Position = startPos;

			fs.Read(bytes, 0, offset);

			s = Encoding.Default.GetString(bytes, 0, offset);

			return s.Trim();
		}
	}
}