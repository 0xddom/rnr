using System;
namespace RnR.Systems.D20
{
	public class Combat
	{
		public Party PlayerParty { get; private set; }
		public Party EnemyParty { get; private set; }

		public Combat (Party playerParty, Party enemyParty)
		{
			PlayerParty = playerParty;
			EnemyParty = enemyParty;
		}
	}
}
