using System;
using System.Collections.Generic;

namespace RnR.Systems.D20
{
	public class EnemyPartyFactory
	{
		static Random r = new Random ();

		public EnemyPartyFactory ()
		{
		}

		public static Party Create ()
		{
			var members = new List<GameCharacter>();
			GameEnemyFactory ef = new RandomEnemyFactory ();
			int nMembers = r.Next (1, 4);

			for (int i = 0; i < nMembers; i++) {
				members.Add (ef.CreateEnemyObject ());
			}

			return new Party (members);
		}
	}
}
