using System;
using RnR.Systems.Dice.DiceOperations;

namespace RnR.Systems.Dice.VM.Types
{
	public class DiceRollType : VMType, SubstraibleType, AddableType
	{
		DiceRoll roll;

		public DiceRollType (DiceRoll roll)
		{
			this.roll = roll;
		}

		public double GetAddableValue ()
		{
			throw new NotImplementedException ();
		}

		public double GetSubstraibleValue ()
		{
			throw new NotImplementedException ();
		}

		public object GetValue ()
		{
			return roll;
		}
	}
}
