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

		public GameActor OnStep (GameActor target)
		{
			if (!picked && target is PlayerGameActor) {
				ApplyAction (target);
				picked = true;
			}
			return target;
		}

		protected abstract void ApplyAction (GameActor target);

		#region implemented abstract members of AbstractFloorElement

		public override SadConsole.CellAppearance Appearance (bool inFov)
		{
			if (inFov) 
				return new CellAppearance (Color.Green, Color.Transparent, 34);
			else
				return new CellAppearance (Color.DarkGreen, Color.Transparent, 34);
		}

		#endregion
	}
}
