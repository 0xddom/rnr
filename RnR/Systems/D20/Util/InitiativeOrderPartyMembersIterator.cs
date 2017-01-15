using System;
using System.Collections;
using System.Collections.Generic;

namespace RnR.Systems.D20.Util
{
	public class InitiativeOrderPartyMembersIterator : IEnumerator<GameCharacter>
	{
		struct MemberWrapper
		{
			GameCharacter character;
			int rolledInitiative;

			public GameCharacter Character {
				get {
					return character;
				}

				set {
					character = value;
				}
			}

			public int RolledInitiative {
				get {
					return rolledInitiative;
				}

				set {
					rolledInitiative = value;
				}
			}
		}

		private class InitiativeComparer<K> : IComparer<K> where K : IComparable
		{
			public int Compare (K x, K y)
			{
				int result = x.CompareTo (y);
				if (result == 0)
					return 1;
				else
					return result;
			}
		}

		SortedList<int, GameCharacter> membersByInitiative;

		public InitiativeOrderPartyMembersIterator (List<GameCharacter> members)
		{
			membersByInitiative = new SortedList<int, GameCharacter> (new InitiativeComparer<int>());
			AddCharacters (members);
		}

		public InitiativeOrderPartyMembersIterator AddCharacters (List<GameCharacter> characters)
		{
			characters.ConvertAll ((character) => {
				var mw = new MemberWrapper ();
				mw.Character = character;
				mw.RolledInitiative = Dice.Dice.Roll (1, 20).Sum + character.DEX ().Mod;
				return mw;
			}).ForEach ((mw) => {
				membersByInitiative.Add (mw.RolledInitiative, mw.Character);
			});

			return this;
		}

		bool loaded;
		IEnumerator<KeyValuePair<int, GameCharacter>> e;

		void LazyLoadEnumerator ()
		{
			if (!loaded) {
				e = membersByInitiative.GetEnumerator ();
				loaded = true;
			}
		}

		public GameCharacter Current {
			get {
				LazyLoadEnumerator ();
				return e.Current.Value;
			}
		}

		object IEnumerator.Current {
			get {
				LazyLoadEnumerator ();
				return e.Current.Value;
			}
		}

		public void Dispose ()
		{
			LazyLoadEnumerator ();
			e.Dispose ();
		}

		public bool MoveNext ()
		{
			LazyLoadEnumerator ();
			return e.MoveNext ();
		}

		public void Reset ()
		{
			LazyLoadEnumerator ();
			e.Reset ();
		}
	}
}
