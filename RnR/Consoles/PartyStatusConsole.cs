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
		}

		public override void Render ()
		{
			base.Render ();

			Clear ();

			int i = 1;
			foreach (GameCharacter c in party) {
				VirtualCursor.Position = new Point (1, i);
				VirtualCursor.Print (c.Name);

				//VirtualCursor.Position = new Point (1, i + 2);

				var hitPointsPerc = (int)Math.Floor (c.HitPoints / (float)c.MaxHitPoints * Math.Min(20, (Width - 2)));

				var g = new CellAppearance (Color.Transparent, Color.Green, 0);
				var dg = new CellAppearance (Color.Transparent, MaterialColors.Green900, 0);

				for (int j = 0; j < hitPointsPerc; j++)
					g.CopyAppearanceTo (this [j + 1, i + 2]);
				for (int j = hitPointsPerc; j < Math.Min (20, (Width - 2)); j++)
					dg.CopyAppearanceTo (this [j + 1, i + 2]);

				if (c == party.Leader) {
					VirtualCursor.Position = new Point (3, i + 4);
					VirtualCursor.Print ("Leader");
				}

				i += 6;
				//break;
			}
		}
	}
}
