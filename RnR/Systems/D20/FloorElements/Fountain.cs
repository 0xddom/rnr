using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RnR.Systems.D20.FloorElements
{
	public class Fountain : AbstractFloorElement, Stepable
	{
		bool exhausted;

		public Fountain ()
		{
			exhausted = false;
		}

		public string OnStep (Party target)
		{
			/*if (target is GameCharacter) {
				target.HitPoints = target.MaxHitPoints;
			}
			return target;*/
			if (!exhausted) {
				foreach (GameCharacter c in target) {
					c.HitPoints = c.MaxHitPoints;
				}
				exhausted = true;
				return "Your party recovers all its health";
			}
			return null;
		}

		#region implemented abstract members of AbstractFloorElement

		public override SadConsole.CellAppearance Appearance (bool inFov)
		{
			if (exhausted) {
				if (inFov)
					return new CellAppearance (Color.Beige, Color.Transparent, 102);
				return new CellAppearance (Color.Brown, Color.Transparent, 102);
			}
			if (inFov) 
				return new CellAppearance (Color.CornflowerBlue, Color.Transparent, 102);
			return new CellAppearance (Color.DarkBlue, Color.Transparent, 102);
		}

		#endregion
	}
}
