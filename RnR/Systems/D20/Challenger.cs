using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20
{
	public interface Challenger
	{
		Skill GetSkill (SkillType type);
	}
}
