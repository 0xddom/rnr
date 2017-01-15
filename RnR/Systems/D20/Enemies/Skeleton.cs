using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Enemies
{
	public class Skeleton:EnemyCharacter
	{
		public Skeleton ()
			:base("Skeleton", new GameActor(12, 10, 5, 2, 1, 3)) 
		{
			(innerActor as GameActor).Skills.Add (SkillType.COMBAT, new Skill (SkillType.COMBAT, "COMBAT", 6, innerActor.STR ()));
		}

	}
}
