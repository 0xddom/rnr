using System;
using System.Collections;
using System.Collections.Generic;
using Lain;
using RnR.Systems.D20.Util;

namespace RnR.Systems.D20
{
	public class Combat : IEnumerable<GameCharacter>
	{
		public Party PlayerParty { get; private set; }
		public Party EnemyParty { get; private set; }

		readonly InitiativeOrderPartyMembersIterator turnOrderIterator;

		public Combat (Party playerParty, Party enemyParty)
		{
			PlayerParty = playerParty;
			EnemyParty = enemyParty;

			turnOrderIterator =
				new InitiativeOrderPartyMembersIterator (playerParty.Members ?? new List<GameCharacter>())
					.AddCharacters (enemyParty.Members ?? new List<GameCharacter>());
		}

		public void DoTurn (Dictionary<GameCharacter, IAction> actions)
		{
			foreach (var character in this) {
				if (actions.ContainsKey (character)) {
					actions [character].Execute ();
				}
			}
		}

		public IEnumerator<GameCharacter> GetEnumerator ()
		{
			return turnOrderIterator;
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return turnOrderIterator;
		}
	}
}
