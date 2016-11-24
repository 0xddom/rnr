using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	public abstract class AbstractMechanicalTrap : AbstractTrap
	{
		public AbstractMechanicalTrap (int c) : base (c)
		{
		}

		public override SkillType GetSkill ()
		{
			return SkillType.DODGE_TRAP;
		}
	}
}
