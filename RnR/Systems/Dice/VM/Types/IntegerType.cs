using System;
namespace RnR.Systems.Dice.VM.Types
{
	public class IntegerType : VMType, SubstraibleType, AddableType
	{
		int value;

		public IntegerType (int value)
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
