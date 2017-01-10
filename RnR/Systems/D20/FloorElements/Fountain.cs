using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RnR.Systems.D20.FloorElements
{
	public class Fountain : AbstractFloorElement, OnStepListener
	{
		public GameActor OnStep (GameActor target)
		{
			if (target is PlayerGameActor) {
				target.HitPoints = target.MaxHitPoints;
			}
			return target;
		}

		#region implemented abstract members of AbstractFloorElement

		public override SadConsole.CellAppearance Appearance ()
		{
			return new CellAppearance (Color.CornflowerBlue, Color.Transparent, 102);
		}

		#endregion
	}
}
