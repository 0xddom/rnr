using System;
namespace RnR.Systems.Dice.VM.Instructions
{
	public class Halt : Nop
	{
		public Halt ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[Halt]");
		}
	}
}
