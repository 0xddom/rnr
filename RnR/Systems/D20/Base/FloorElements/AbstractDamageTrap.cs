using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	public abstract class AbstractDamageTrap : AbstractTrap
	{
		protected int dices;
		protected int damage;

		public AbstractDamageTrap (SkillType skill, int dices, int damage, int rate) : base (skill, rate)
		{
			this.damage = damage;
			this.dices = dices;
		}

		public int CalculateDamage ()
		{
			return Dice.Dice.Roll (dices, damage).Sum;
		}
	}
}
