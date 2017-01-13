using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;
using SadConsole;
using Microsoft.Xna.Framework;
using RnR.Consoles;

namespace RnR.Systems.D20.FloorElements
{
	public class SpikeTrap : AbstractDamageTrap
	{
		public SpikeTrap (int dices, int damage, int rate) 
			: base (SkillType.DODGE_TRAP, dices, damage, rate)
		{
		}

		protected override GameActor ApplyEffect (GameActor target)
		{
			target.HitPoints -= CalculateDamage();
			return target;
		}

		#region implemented abstract members of AbstractFloorElement

		public override SadConsole.CellAppearance Appearance (bool inFov)
		{
			if (inFov) {
				if (this.Armed)
					return new FloorInFovAppearance ();
				return new CellAppearance (Color.Red, Color.Transparent, 116);
			} else {
				if (this.Armed)
					return new FloorAppearance ();
				return new CellAppearance (Color.Red, Color.Transparent, 116);
			}
		}

		#endregion
	}
}
