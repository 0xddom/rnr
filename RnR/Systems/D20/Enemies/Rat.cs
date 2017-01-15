using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Enemies
{
	public class Rat:EnemyCharacter
	{
		public Rat ()
			:base("Rat", new GameActor(6, 5, 6, 1, 1, 1)) 
		{
			(innerActor as GameActor).Skills.Add (SkillType.COMBAT, new Skill (SkillType.COMBAT, "COMBAT", 2, innerActor.STR ()));
		}

	}
}
