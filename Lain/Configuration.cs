using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Lain
{
	public class Configuration
	{
		private static string[] FONTS = new string[] { /*"Cheepicus12",*/ "IBM", "C64" };

		public static Font Font { get; private set; }

		static Configuration() {
			Font = GetAvailableFont ();
		}

		public static int DisplayWidth {
			get {
				return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			}
		}

		public static int DisplayHeight {
			get { 
				return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			}
		}

		public static int GridWidth {
			get { return DisplayWidth / Font.GlyphWidth; }
		}

		public static int GridHeight {
			get { return DisplayHeight / Font.GlyphHeight; }
		}

		/// <summary>
		/// Search for fonts and returns the first one found.
		/// In case no font is found. Aborts the execution and exits the program.
		/// </summary>
		/// <returns>The available font.</returns>
		public static Font GetAvailableFont ()
		{
			Font availableFont = (new List<string> (FONTS))
				.ConvertAll<Font> ((font) => new Font(string.Format ("{0}.font", font)))
				.Find ((font) => File.Exists (font.Path));

			if (availableFont != null) {
				return availableFont;
			} else {
				System.Console.WriteLine ("Font not found");
				Environment.Exit (1);
				return null;
			}
		}
	}
}

