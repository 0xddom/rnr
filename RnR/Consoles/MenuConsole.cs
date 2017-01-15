using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using SadConsole;

namespace RnR.Consoles
{
	public class MenuConsole : SadConsole.Consoles.Console
	{
		public List<MenuItem> Items { get; set; }
		const int STARTX = 1;
		const int STARTY = 1;

		CellAppearance selectedCellAppearance;

		public MenuConsole (List<MenuItem> items, int w, int h)
			: base (w, h)
		{
			Items = items;

			selectedCellAppearance = new CellAppearance (Color.White, Color.Transparent, 16);
		}

		public override void Render ()
		{
			base.Render ();

			Clear ();

			int i = STARTY;
			foreach (MenuItem item in Items) {
				if (item.Selected) {
					selectedCellAppearance.CopyAppearanceTo (this [STARTX, i]);
				}

				VirtualCursor.Position = new Point (STARTX + 2, i);
				VirtualCursor.Print (item.Entry);

				i += 2;
			}
		}
	}
}
