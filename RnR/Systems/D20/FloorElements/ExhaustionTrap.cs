using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RnR.Systems.D20.FloorElements
{
	public class ExhaustionTrap : AbstractDamageTrap
	{
		public ExhaustionTrap (int dices, int damage, int rate) 
			: base (SkillType.DETECT_MAGIC, dices, damage, rate)
		{
		}

		protected override GameActor ApplyEffect (GameActor target)
		{
			if (target is PlayerGameActor) {
				var player = (PlayerGameActor)target;
				player.Hunger -= CalculateDamage();
			}
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
