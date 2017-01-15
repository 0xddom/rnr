using System;
using Lain;
using RnR.Scenes;

namespace RnR.Actions
{
	public class TryEncounterAction:IAction
	{
		static Random r = new Random();


		public TryEncounterAction ()
		{
			
		}

		public bool Execute ()
		{
			int chance = r.Next (100);
			System.Console.WriteLine (chance);

			if (chance > 95) {
				var director = Director.Instance;
				director.PushScene (new CombatScene (), false);
			}
			return false;
		}
	}
}
