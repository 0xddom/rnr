using System;
using System.Collections.Generic;
using System.Linq;

namespace RnR.Systems.Dice
{
    /// <summary>
    ///   Contains the result of a dice roll.
    /// </summary>
    public class DiceRoll
    {
        readonly List<int> dices;
        int sum;
        int sides;
        bool sum_calculated;

        public DiceRoll (List<int> dices, int sides)
        {
            this.dices = dices;
            this.sides = sides;
            this.sum = 0;
            this.sum_calculated = false;
        }

        private void CalculateSum ()
        {
            sum = dices.Aggregate (0, (n, acc) => n + acc);
            sum_calculated = true;
        }

        public int Sum {
            get {
                // Lazily calculate the sum. But calculate it only once
                if (!sum_calculated) CalculateSum ();
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
