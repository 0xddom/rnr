using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Lain
{
	/// <summary>
	/// Configuration manager and constants.
	/// </summary>
	public class Configuration
	{
		/// <summary>
		/// Supported fonts in the system.
		/// </summary>
		private static string[] FONTS = new string[] { "Cheepicus12", "IBM", "C64" };

		/// <summary>
		/// The used font.
		/// </summary>
		/// <value>The font.</value>
		public static Font Font { get; private set; }

		/// <summary>
		/// Initializes the <see cref="Lain.Configuration"/> class.
		/// </summary>
		static Configuration() {
			Font = GetAvailableFont ();
		}

		/// <summary>
		/// Gets the display width.
		/// </summary>
		/// <value>The display width.</value>
		public static int DisplayWidth {
			get {
				return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			}
		}

		/// <summary>
		/// Gets the display height.
		/// </summary>
		/// <value>The display height.</value>
		public static int DisplayHeight {
			get { 
				return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			}
		}

		/// <summary>
		/// Gets the width of the grid based on the display width and the font width.
		/// </summary>
		/// <value>The width of the grid.</value>
		public static int GridWidth {
			get { return DisplayWidth / Font.GlyphWidth; }
		}

		/// <summary>
		/// Gets the height of the grid based on the display height and the font height.
		/// </summary>
		/// <value>The height of the grid.</value>
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

