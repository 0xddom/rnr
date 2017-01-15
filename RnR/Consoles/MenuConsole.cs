using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using SadConsole;

namespace RnR.Consoles
{
	[DataContract]
	public class MenuConsole : SadConsole.Consoles.Console
	{
		[DataMember]
		List<MenuItem> items;
		const int STARTX = 1;
		const int STARTY = 1;

		[DataMember]
		CellAppearance selectedCellAppearance;

		public MenuConsole (List<MenuItem> items, int w, int h)
			: base (w, h)
		{
			this.items = items;

			selectedCellAppearance = new CellAppearance (Color.White, Color.Transparent, 16);
		}

		public override void Render ()
		{
			base.Render ();

			Clear ();

			int i = STARTY;
			foreach (MenuItem item in items) {
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
