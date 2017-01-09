using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;

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
	}
}
