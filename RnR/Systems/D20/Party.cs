using System;
using System.Collections.Generic;

namespace RnR.Systems.D20
{
	public class Party
	{
		int leaderPos;

		public Party () 
			: this (new List<GameCharacter>())
		{
		}

		public Party (List<GameCharacter> members)
		{
			Members = members;
			leaderPos = 0;
		}

		public GameCharacter Leader {
			get {
				return Members [leaderPos];
			}
			set {
				leaderPos = Members.IndexOf (value);
				if (leaderPos < 0) leaderPos = 0;
			}
		}

		public List<GameCharacter> Members { get; private set; }
	}
}
