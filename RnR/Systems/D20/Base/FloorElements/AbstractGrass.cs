using System;
using RnR.Systems.D20.Base.Actors;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RnR.Systems.D20.Base.FloorElements
{
	public abstract class AbstractGrass : AbstractFloorElement, Stepable
	{
		protected bool picked;

		public AbstractGrass ()
		{
			picked = false;
		}

		public string OnStep (Party target)
		{
			if (!picked) {
				picked = true;
				return ApplyAction (target);
			}

			return null;
		}

		protected abstract string ApplyAction (Party target);

		#region implemented abstract members of AbstractFloorElement

		public override CellAppearance Appearance (bool inFov)
		{
			int glyph = picked ? 96 : 34;
			if (inFov)
				return new CellAppearance (Color.Green, Color.Transparent, glyph);
			return new CellAppearance (Color.DarkGreen, Color.Transparent, glyph);
		}

		#endregion
	}
}
