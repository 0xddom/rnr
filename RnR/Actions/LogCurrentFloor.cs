using System;
using Lain;
using System.Collections.Generic;

namespace RnR.Actions
{
	public class LogCurrentFloor : IAction
	{
		GameState gs;
		List<string> log;

		public LogCurrentFloor (GameState gs, List<string> log)
		{
			this.gs = gs;
			this.log = log;
		}

		#region IAction implementation

		public bool Execute ()
		{
			log.Add ($"You are in floor #{gs.Dungeon.CurrentFloor.Level + 1}");
			return true;
		}

		#endregion
	}
}

