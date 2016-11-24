using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	/// <summary>
	/// This trap applies an effect to the target using the decorator pattern
	/// </summary>
	public abstract class AbstractEffectTrap : AbstractTrap
	{
		private GameActorDecorator effect;

		public AbstractEffectTrap (SkillType skill, GameActorDecorator effect, int rate) : base(skill, rate)
		{
			this.effect = effect;
		}

		public GameActorDecorator Effect { get { return effect; } }
	}
}
