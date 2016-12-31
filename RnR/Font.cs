using System;
using Newtonsoft.Json;
using System.IO;

namespace RnR
{
	public class Font
	{
		struct FontStruct {
			public int GlyphWidth;
			public int GlyphHeight;
			public int GlyphPadding;
			public string Name;
			public string FilePath;
			public int SolidGlyphIndex;
		}

		public string Path { get; private set; }
		private FontStruct fontStruct;

		public Font (string path)
		{
			Path = path;
			LoadStruct ();
		}

		private void LoadStruct() {
			fontStruct = JsonConvert.DeserializeObject<FontStruct>(File.ReadAllText(Path));
		}

		public int GlyphWidth {
			get {
				return fontStruct.GlyphWidth;
			}
		}

		public int GlyphHeight {
			get {
				return fontStruct.GlyphHeight;
			}
		}
	}
}

