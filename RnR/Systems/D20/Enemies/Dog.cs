using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Enemies
{
	public class Dog:EnemyCharacter
	{
		public Dog ()
			:base("Dog", new GameActor(8, 3, 6, 3, 1, 3)) 
		{
			(innerActor as GameActor).Skills.Add (SkillType.COMBAT, new Skill (SkillType.COMBAT, "COMBAT", 3, innerActor.STR ()));
		}

	}
}
