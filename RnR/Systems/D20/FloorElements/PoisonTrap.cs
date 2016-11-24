using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;

namespace RnR.Systems.D20.FloorElements
{
	public class PoisonTrap : AbstractEffectTrap
	{
		public PoisonTrap (int rate) : base (SkillType.DODGE_TRAP, new PoisonEffect (), rate)
		{
		}

		protected override AbstractGameActor ApplyEffect (AbstractGameActor target)
		{
			Effect.Target = target;
			return Effect;
		}
	}
}
