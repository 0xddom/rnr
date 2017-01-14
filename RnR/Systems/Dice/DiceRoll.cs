using System;
using System.Collections.Generic;
using System.Linq;

namespace RnR.Systems.Dice
{
    /// <summary>
    /// Contains the result of a dice roll.
    /// </summary>
    public class DiceRoll
    {
        readonly List<int> dices;
        int sum;
        int sides;
        bool sum_calculated;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Systems.Dice.DiceRoll"/> class.
		/// </summary>
		/// <param name="dices">Dices.</param>
		/// <param name="sides">Sides.</param>
        public DiceRoll (List<int> dices, int sides)
        {
            this.dices = dices;
            this.sides = sides;
            this.sum = 0;
            this.sum_calculated = false;
        }

		/// <summary>
		/// Calculates the sum.
		/// </summary>
        private void CalculateSum ()
        {
            sum = dices.Aggregate (0, (n, acc) => n + acc);
            sum_calculated = true;
        }

		/// <summary>
		/// Gets the sum.
		/// </summary>
		/// <value>The sum.</value>
        public int Sum {
            get {
                // Lazily calculate the sum. But calculate it only once
                if (!sum_calculated) CalculateSum ();
                return sum;
            }
        }

		/// <summary>
		/// Gets the count.
		/// </summary>
		/// <value>The count.</value>
        public int Count {
            get { return dices.Count; }
        }

		/// <summary>
		/// Gets the dices.
		/// </summary>
		/// <value>The dices.</value>
        public List<int> Dices {
            get { return dices; }
        }
    }
}
