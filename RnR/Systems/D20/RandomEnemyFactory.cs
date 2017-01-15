using System;
using RnR.Systems.D20.Base.Actors;
using System.Collections.Generic;
using System.Linq;

namespace RnR.Systems.D20
{
	public class RandomEnemyFactory:GameEnemyFactory
	{

		IEnumerable<Type> availableEnemies;
		Random r;

		public RandomEnemyFactory ()
		{
			availableEnemies =
				from assembly in AppDomain.CurrentDomain.GetAssemblies ()
				from type in assembly.GetTypes ()
				where type.IsSubclassOf (typeof (EnemyCharacter))
				select type;

			r = new Random ();
		}

		EnemyCharacter GameEnemyFactory.CreateEnemyObject ()
		{
			var list = new List<Type> (availableEnemies);

			// Instantiate a random subclass of EnemyCharacter
			return (EnemyCharacter)Activator.CreateInstance (list [r.Next (list.Count)]);
		}
	}
}
