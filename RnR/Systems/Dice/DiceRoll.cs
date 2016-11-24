using System;
using System.Collections.Generic;
using System.Linq;

namespace RnR.Systems.Dice.DiceOperations
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
			CalculateSum ();
		}

		private void CalculateSum ()
		{
			sum = dices.Aggregate (0, (n, acc) => n + acc);
		}

		public int Sum {
			get {
				CalculateSum ();
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
