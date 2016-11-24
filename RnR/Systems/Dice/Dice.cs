using System;
using System.Collections.Generic;

namespace RnR.Systems.Dice
{
	public class Dice
	{
		private static Random r;

		static Dice ()
		{
			r = new Random ();
		}

		public static DiceRoll Roll (int dices, int sides)
		{
			List<int> dicesLst = new List<int> ();
			for (int i = 0; i < dices; i++) {
				dicesLst.Add (r.Next (1, sides));
			}

			return new DiceRoll (dicesLst, sides);
		}
	}
}
