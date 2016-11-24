using System;
namespace RnR.Systems.Dice.VM.Types
{
	public class NumberType : VMType, SubstraibleType, AddableType
	{
		double value;

		public NumberType (double value)
		{
			this.value = value;
		}

		public double GetAddableValue ()
		{
			return value;
		}

		public double GetSubstraibleValue ()
		{
			return value;
		}

		public object GetValue ()
		{
			return value;
		}
	}
}
