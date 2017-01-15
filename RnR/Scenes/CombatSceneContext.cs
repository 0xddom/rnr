using System;
using System.Collections.Generic;
using Lain;
using RnR.Consoles;
using RnR.Systems.D20;

namespace RnR.Scenes
{
	public class CombatSceneContext
	{
		public List<string> Log { get; set; }
		public List<string> AvailableActions { get; set; }

		public Combat Combat { get; set; }

		public CombatSceneState State { get; set; }

		public IEnumerator<GameCharacter> It { get; set; }

		public List<AbstractCombatStatusConsole> EnemyPartyStatusConsoles { get; set; }
		public List<AbstractCombatStatusConsole> PlayerPartyStatusConsoles { get; set; }

		public Dictionary<GameCharacter, IAction> Actions { get; set; }
	}
}
