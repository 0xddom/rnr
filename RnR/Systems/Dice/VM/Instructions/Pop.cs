using System;
namespace RnR.Systems.Dice.VM.Instructions
{
	public class Pop : AbstractInstruction
	{
		public override void Execute (Context context)
		{
			context.Pop ();
		}

		public override string ToString ()
		{
			return string.Format ("[Pop]");
		}
	}
}
