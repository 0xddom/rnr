using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;

namespace RnR.Systems.D20.FloorElements
{
	public class ExhaustionTrap : AbstractDamageTrap
	{
		public ExhaustionTrap (int dices, int damage, int rate) 
			: base (SkillType.DETECT_MAGIC, dices, damage, rate)
		{
		}

		protected override AbstractGameActor ApplyEffect (AbstractGameActor target)
		{
			if (target is PlayerGameActor) {
				var player = (PlayerGameActor)target;
				player.Hunger -= CalculateDamage();
			}
			return target;
		}
	}
}
