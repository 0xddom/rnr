using System;
using System.Collections.Generic;

namespace RnR.Systems.D20
{
	public class Party
	{
		int leaderPos;

		public Party () 
			: this (new List<PlayerGameActor>())
		{
		}

		public Party (List<PlayerGameActor> members)
		{
			Members = members;
			leaderPos = 0;
		}

		public PlayerGameActor Leader {
			get {
				return Members [leaderPos];
			}
			set {
				leaderPos = Members.IndexOf (value);
				if (leaderPos < 0) leaderPos = 0;
			}
		}

		public List<PlayerGameActor> Members { get; private set; }
	}
}
