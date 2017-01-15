using System;
using System.Collections;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20
{
	public class Party : IEnumerable<GameCharacter>
	{
		int leaderPos;

		public List<GameObject> Inventory { get; private set; }

		public Party () 
			: this (new List<GameCharacter>())
		{
		}

		public Party (List<GameCharacter> members)
		{
			Members = members;
			Inventory = new List<GameObject> ();
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

		public IEnumerator<GameCharacter> GetEnumerator ()
		{
			return Members.GetEnumerator ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return Members.GetEnumerator ();
		}
	}
}
