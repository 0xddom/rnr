using System;
namespace RnR.Systems.Dice.VM.Instructions
{
	public class Times : AbstractInstruction
	{
		public override void Execute (Context context)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return string.Format ("[Times]");
		}
	}
}
