using System;
namespace RnR.Systems.Dice.VM.Instructions
{
	public class Nop : AbstractInstruction
	{
		public override void Execute (Context context)
		{
		}

		public override string ToString ()
		{
			return string.Format ("[Nop]");
		}
	}
}
