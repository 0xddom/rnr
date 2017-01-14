using System;
using Newtonsoft.Json;
using System.IO;

namespace Lain
{
	/// <summary>
	/// Represents a font in the system.
	/// </summary>
	public class Font
	{
		/// <summary>
		/// The JSON structure of the font file.
		/// </summary>
		struct FontStruct {
			private int glyphWidth;
			private int glyphHeight;
			private int glyphPadding;
			private string name;
			private string filePath;
			private int solidGlyphIndex;

			public int GlyphHeight {
				get {
					return glyphHeight;
				}

				set {
					glyphHeight = value;
				}
			}

			public int GlyphWidth {
				get {
					return glyphWidth;
				}

				set {
					glyphWidth = value;
				}
			}

			public int GlyphPadding {
				get {
					return glyphPadding;
				}

				set {
					glyphPadding = value;
				}
			}

			public string Name {
				get {
					return name;
				}

				set {
					name = value;
				}
			}

			public string FilePath {
				get {
					return filePath;
				}

				set {
					filePath = value;
				}
			}

			public int SolidGlyphIndex {
				get {
					return solidGlyphIndex;
				}

				set {
					solidGlyphIndex = value;
				}
			}
		}

		/// <summary>
		/// Gets the path of the font file.
		/// </summary>
		/// <value>The path.</value>
		public string Path { get; private set; }
		/// <summary>
		/// The font struct.
		/// </summary>
		private FontStruct fontStruct;

		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.Font"/> class.
		/// </summary>
		/// <param name="path">Path.</param>
		public Font (string path)
		{
			Path = path;
			LoadStruct ();
		}

		/// <summary>
		/// Loads the struct from the JSON file.
		/// </summary>
		private void LoadStruct ()
		{
			fontStruct = JsonConvert.DeserializeObject<FontStruct> (File.ReadAllText (Path));
		}

		/// <summary>
		/// Gets the width of the glyph.
		/// </summary>
		/// <value>The width of the glyph.</value>
		public int GlyphWidth {
			get {
				return fontStruct.GlyphWidth;
			}
		}

		/// <summary>
		/// Gets the height of the glyph.
		/// </summary>
		/// <value>The height of the glyph.</value>
		public int GlyphHeight {
			get {
				return fontStruct.GlyphHeight;
			}
		}
	}
}

