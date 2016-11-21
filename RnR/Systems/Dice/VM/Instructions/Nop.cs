using System;
namespace RnR.Systems.Dice.VM.Instructions
{
	public class Nop : Instruction
	{
		public Nop ()
		{
		}

		public void Execute (Context context)
		{
		}

		public override string ToString ()
		{
			return string.Format ("[Nop]");
		}
	}
}
