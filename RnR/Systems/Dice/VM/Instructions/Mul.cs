using System;
namespace RnR.Systems.Dice.VM.Instructions
{
	public class Mul : Instruction
	{
		public Mul ()
		{
		}

		public void Execute (Context context)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return string.Format ("[Mul]");
		}
	}
}
