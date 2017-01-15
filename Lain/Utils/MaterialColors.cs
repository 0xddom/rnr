using System;
using Microsoft.Xna.Framework;

namespace Lain.Utils
{
	public class MaterialColors
	{
		public static Color Red = new Color (0xf4, 0x43, 0x36);
		public static Color Red900 = new Color (0xb7, 0x1c, 0x1c);
		public static Color Purple = new Color (0x9c, 0x27, 0xb0);
		public static Color Indigo = new Color (0x3f, 0x51, 0xb5);
		public static Color LightBlue = new Color (0x03, 0xa9, 0xf4);
		public static Color Teal = new Color (0x00, 0x96, 0x88);
		public static Color Green = new Color (0x4c, 0xaf, 0x50);
		public static Color Green900 = new Color (0x1b, 0x5e, 0x20);
		public static Color Lime = new Color (0xcd, 0xdc, 0x39);
		public static Color Lime900 = new Color (0x82, 0x77, 0x17);

		static Random r;

		static MaterialColors ()
		{
			r = new Random ();
		}

		public static Color RandomMaterialColor ()
		{
			var arr = new Color [] { Red, Purple, Indigo, LightBlue, Teal, Green };
			return arr [r.Next (arr.Length)];
		}
	}
}
