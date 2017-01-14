using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RnR.Systems.D20.FloorElements
{
	public class Fountain : AbstractFloorElement, Stepable
	{
		public IGameActor OnStep (IGameActor target)
		{
			if (target is GameCharacter) {
				target.HitPoints = target.MaxHitPoints;
			}
			return target;
		}

		#region implemented abstract members of AbstractFloorElement

		public override SadConsole.CellAppearance Appearance (bool inFov)
		{
			if (inFov) {
				return new CellAppearance (Color.CornflowerBlue, Color.Transparent, 102);
			} else
				return new CellAppearance (Color.DarkBlue, Color.Transparent, 102);
		}

		#endregion
	}
}
