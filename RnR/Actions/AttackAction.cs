using System;
using System.Collections.Generic;
using Lain;
using RnR.Systems.D20;

namespace RnR.Actions
{
	public class AttackAction : IAction
	{
		public GameCharacter Attacker { get; set; }
		public GameCharacter Target { get; set; }

		List<string> log;

		public AttackAction (List<string> log)
		{
			this.log = log;
		}

		public bool Execute ()
		{
			log.Add (string.Format ("{0} has attacked {1}", Attacker.Name, Target.Name));

			return true;
		}
	}
}
