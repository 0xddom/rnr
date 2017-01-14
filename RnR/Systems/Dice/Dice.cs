using System;
using System.Collections.Generic;

namespace RnR.Systems.Dice
{
	/// <summary>
	/// Represents a Dice. A dice can be rolled, thus returning DiceRoll instances.
	/// </summary>
	public static class Dice
	{
		private static readonly Random r;

		/// <summary>
		/// Initializes the <see cref="T:RnR.Systems.Dice.Dice"/> class.
		/// </summary>
		static Dice ()
		{
			r = new Random ();
		}

		/// <summary>
		/// Roll the specified number of dices.
		/// </summary>
		/// <param name="dices">Dices.</param>
		/// <param name="sides">Sides.</param>
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
