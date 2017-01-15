using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Enemies
{
	public class Snake:EnemyCharacter
	{
		public Snake ()
			:base("Snake", new GameActor(5, 10, 6, 2, 2, 1)) 
		{
			(innerActor as GameActor).Skills.Add (SkillType.COMBAT, new Skill (SkillType.COMBAT, "COMBAT", 3, innerActor.STR ()));
		}

	}
}
