using System;
using System.Collections.Generic;
using System.Linq;

namespace RnR.Systems.Dice
{
	public class DiceRoll
	{
		readonly List<int> dices;
		int sum;
		int sides;

		public DiceRoll (List<int> dices, int sides)
		{
			this.dices = dices;
			this.sides = sides;
			this.sum = -1;
			//CalculateSum ();
		}

		private void CalculateSum ()
		{
			sum = dices.Aggregate (0, (n, acc) => n + acc);
		}

		public int Sum {
			get {
				// Lazily calculate the sum. But calculate it only once
				if (sum == -1) CalculateSum ();
				return sum;
			}
		}

		public int Count {
			get { return dices.Count; }
		}

		public List<int> Dices {
			get { return dices; }
		}
	}
}
