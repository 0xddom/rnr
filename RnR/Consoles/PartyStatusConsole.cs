using System;
using Lain.Utils;
using Microsoft.Xna.Framework;
using RnR.Systems.D20;
using SadConsole;
using SadConsole.Consoles;

namespace RnR.Consoles
{
	public class PartyStatusConsole : SadConsole.Consoles.Console
	{
		Party party;

		public PartyStatusConsole (Party party, int w, int h)
			: base (w, h)
		{
			this.party = party;
			this.TextSurface.AbsoluteArea = new Rectangle (0, 0, w, h);
		}

		public override void Render ()
		{
			base.Render ();

			Clear ();

			for (int x = 0; x < Width; x++)
				for (int j = 0; j < Height; j++)
					(new CellAppearance (Color.Transparent, MaterialColors.Indigo, 0)).CopyAppearanceTo (this [x, j]);

			int i = 1;
			foreach (GameCharacter c in party) {
				try {
					VirtualCursor.Position = new Point (1, i);
					VirtualCursor.Print (c.Name);

					VirtualCursor.PrintAppearance = new CellAppearance (Color.White, MaterialColors.Indigo);

					//VirtualCursor.Position = new Point (1, i + 2);

					var hitPointsPerc = (int)Math.Floor (c.HitPoints / (float)c.MaxHitPoints * Math.Min (20, (Width - 2)));

					var g = new CellAppearance (Color.Transparent, MaterialColors.Red, 0);
					var dg = new CellAppearance (Color.Transparent, MaterialColors.Red900, 0);

					i += 2;

					for (int j = 0; j < hitPointsPerc; j++)
						g.CopyAppearanceTo (this [j + 1, i]);
					for (int j = hitPointsPerc; j < Math.Min (20, (Width - 2)); j++)
						dg.CopyAppearanceTo (this [j + 1, i]);

					i++;

					var hungerPerc = (int)Math.Floor (c.Hunger / (float)c.MaxHunger * Math.Min (20, (Width - 2)));

					var y = new CellAppearance (Color.Transparent, MaterialColors.Lime, 0);
					var dy = new CellAppearance (Color.Transparent, MaterialColors.Lime900, 0);

					for (int j = 0; j < hungerPerc; j++)
						y.CopyAppearanceTo (this [j + 1, i]);
					for (int j = hungerPerc; j < Math.Min (20, (Width - 2)); j++)
						dy.CopyAppearanceTo (this [j + 1, i]);

					if (c == party.Leader) {
						i += 2;

						VirtualCursor.Position = new Point (3, i);
						VirtualCursor.Print ("Leader");
					}

					i += 2;
					//break;
				} catch (Exception e) {
					System.Console.WriteLine (i);
					System.Console.WriteLine (e.Message);
				}
			}
		}
	}
}
