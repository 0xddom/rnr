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
			if (!Attacker.IsDead && !Target.IsDead) {

				var contest = new Contest (Target, Attacker);
				string result = contest.Resolve ();
				if(result != null)
					log.Add (result);
			}
			return true;
		}
	}
}
