using System;
using System.Collections;
using System.Collections.Generic;

namespace RnR.Systems.D20.Util
{
	public class PartyMembersIterator : IEnumerator<GameCharacter>
	{
		List<GameCharacter> members;
		int p;

		public PartyMembersIterator (List<GameCharacter> members)
		{
			this.members = members;
			p = 0;
		}

		public GameCharacter Current {
			get {
				return members [p];
			}
		}

		object IEnumerator.Current {
			get {
				return members [p];
			}
		}

		public void Dispose ()
		{
		}

		public bool MoveNext ()
		{
			p++;
			return p < members.Count;
		}

		public void Reset ()
		{
			p = 0;
		}
	}
}
