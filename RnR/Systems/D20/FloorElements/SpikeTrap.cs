using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;
using SadConsole;
using Microsoft.Xna.Framework;

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

		public override SadConsole.CellAppearance Appearance ()
		{
			if (this.Armed)
				return new CellAppearance (Color.DarkGray, Color.Transparent, 46);
			return new CellAppearance (Color.MediumSpringGreen, Color.Transparent, 116);
		}

		#endregion
	}
}
