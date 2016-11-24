using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	/// <summary>
	/// This trap applies an effect to the target using the decorator pattern
	/// </summary>
	public abstract class AbstractEffectTrap : AbstractTrap
	{
		private TrapEffect effect;

		public AbstractEffectTrap (SkillType skill, TrapEffect effect, int rate) : base(skill, rate)
		{
			this.effect = effect;
		}

		public TrapEffect Effect { get { return effect; } }
	}
}
