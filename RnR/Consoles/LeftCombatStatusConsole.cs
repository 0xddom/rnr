﻿using System;
using Lain.Utils;
using Microsoft.Xna.Framework;
using RnR.Systems.D20;
using SadConsole;

namespace RnR.Consoles
{
	public class LeftCombatStatusConsole : AbstractCombatStatusConsole
	{
		public LeftCombatStatusConsole (GameCharacter character, int w, int h)
			: base (character, w, h)
		{
		}

		protected override void RenderStatus ()
		{
			Clear ();

			VirtualCursor.Position = new Point (4, STARTY);
			VirtualCursor.Print (Character.Name);

			if (IsSelected)
				(new CellAppearance (Color.White, Color.Transparent, 17)).CopyAppearanceTo (this [(int)Math.Floor(Width * 0.6), STARTY]);

			// Draw health bar
			VirtualCursor.Position = new Point (4, STARTY + 2);
			var hitPointsPerc = (int)Math.Floor (((float)Character.HitPoints / (float)Character.MaxHitPoints) * 10.0);

			var g = new CellAppearance (Color.Transparent, Color.Green, 0);
			var dg = new CellAppearance (Color.Transparent, MaterialColors.Green900, 0);

			for (int i = 0; i < hitPointsPerc; i++)
				g.CopyAppearanceTo (this [i + 4, STARTY + 2]);
			for (int i = hitPointsPerc; i < 10; i++)
				dg.CopyAppearanceTo (this [i + 4, STARTY + 2]);

			VirtualCursor.Position = new Point (15, STARTY + 2);
			VirtualCursor.Print (string.Format ("{0}/{1}", Character.HitPoints, Character.MaxHitPoints));
		}
	}
}
