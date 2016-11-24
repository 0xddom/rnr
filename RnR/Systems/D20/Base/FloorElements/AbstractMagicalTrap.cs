using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	public abstract class AbstractMagicalTrap : AbstractTrap
	{
		public AbstractMagicalTrap (int c) : base(c)
		{
		}

		public override SkillType GetSkill ()
		{
			return SkillType.DETECT_MAGIC;
		}
	}
}
