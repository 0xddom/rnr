using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20
{
	public class EnemyCharacter:GameCharacter
	{
		Random r;

		public EnemyCharacter (string name, GameActor gameActor)
			:base(name,gameActor)
		{
			r = new Random ();
		}

		public GameCharacter ChooseAttackTarget (List<GameCharacter> enemyParty)
		{
			return enemyParty [r.Next (enemyParty.Count)];
		}
	}
}
